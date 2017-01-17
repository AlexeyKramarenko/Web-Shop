using AutoMapper;
using WebShop.App_Start;
using WebShop.DAL;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.SignalR
{
    public class Cart
    {
        public string UserID = null;
        public List<string> ConnectionIDs = new List<string>();
        public List<CartItemViewModel> Items = new List<CartItemViewModel>();
        public double DeliveryPrice = 0;
        public int DeliveryID = 1;
        public double SummaryPrice = 0;
        public DateTime LastActivityTime = DateTime.Now;
    }

    public class ShoppingCart : Hub
    {
        private static List<Cart> carts = new List<Cart>();
        IProductRepository productRepository = null;
        IMapper mapper = null;
        IOrderRepository orderRepository = null;

        public ShoppingCart()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            mapper = config.CreateMapper();
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
        }
        public void RemoveUnactiveCarts()
        {
            for (int i = 0; i < carts.Count; i++)
            {
                Cart cart = carts[i];
                int dayDiff = DateTime.Now.Day - cart.LastActivityTime.Day;
                if (dayDiff > 0)
                {
                    int cartAge = DateTime.Now.Hour + (24 - cart.LastActivityTime.Hour);
                    if (cartAge > 3)
                        carts.Remove(cart);
                }
            }
        }
        public void RemoveShoppingCart(string userId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
                carts.Remove(cart);
        }
        public int GetSummaryItemsCount(string userId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
            {
                int summaryAmount = 0;
                foreach (var item in cart.Items)
                    summaryAmount += item.Amount;
                return summaryAmount;
            }
            return 0;
        }
        public void Connect(string userId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
            {
                cart.ConnectionIDs.Add(Context.ConnectionId);
                cart.DeliveryPrice = orderRepository.GetDeliveryPriceById(cart.DeliveryID);
            }
            else
                CreateEmptyShoppingCart(userId);
        }
        public void UpdateDeliveryPrice(string userId, int deliveryId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
            {
                cart.DeliveryPrice = orderRepository.GetDeliveryPriceById(deliveryId);
                cart.DeliveryID = deliveryId;
                CalculateSummaryOrderPrice(userId);
            }
        }

        public void CalculateSummaryOrderPrice(string userId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
            {
                double summaryPrice = 0;
                foreach (var item in cart.Items)
                    summaryPrice += item.Price;

                summaryPrice += cart.DeliveryPrice;

                cart.SummaryPrice = summaryPrice;
                foreach (string id in cart.ConnectionIDs)
                    Clients.Client(id).showSummaryPrice(summaryPrice);
            }
        }
        public Cart GetCart(string userId)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
                cart.Items = cart.Items.OrderBy(a => a.ProductID).ThenBy(a => a.Length).ToList();
            return cart;
        }
        public void AddProductToCart(string userId, int productId, int length)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            Product product = productRepository.GetProductByID(productId);
            CartItemViewModel item = mapper.Map<Product, CartItemViewModel>(product);

            if (cart != null)
            {
                if (!cart.ConnectionIDs.Contains(Context.ConnectionId))
                    cart.ConnectionIDs.Add(Context.ConnectionId);

                var _item = cart.Items.FirstOrDefault(a => a.ProductID == productId && a.Length == length);
                if (_item != null)
                {
                    _item.Amount += 1;
                    _item.Price = _item.Amount * _item.PricePerMeter * _item.Length;
                }
                else
                {
                    item.Length = length;
                    item.Price = item.Amount * item.PricePerMeter * item.Length;
                    cart.Items.Add(item);
                }
            }
            else
            {
                cart = new Cart { UserID = userId };
                cart.ConnectionIDs.Add(Context.ConnectionId);
                item.Length = length;
                item.Price = item.Amount * item.PricePerMeter * item.Length;
                cart.Items.Add(item);
                carts.Add(cart);
            }
            foreach (string id in cart.ConnectionIDs)
                Clients.Client(id).refreshShoppingCart(cart.Items);

            CalculateSummaryOrderPrice(userId);
        }
        
        public void RemoveProductFromCart(string userId, int productId, int length)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);
            if (cart != null)
            {
                if (!cart.ConnectionIDs.Contains(Context.ConnectionId))
                    cart.ConnectionIDs.Add(Context.ConnectionId);

                var _item = cart.Items.FirstOrDefault(a => a.ProductID == productId && a.Length == length);
                if (_item != null)
                    cart.Items.Remove(_item);

                foreach (string id in cart.ConnectionIDs)
                    Clients.Client(id).refreshShoppingCart(cart.Items);

                CalculateSummaryOrderPrice(userId);
            }
        }

        public void UpdateProductInCart(string userId, int productId, int length, int amount)
        {
            Cart cart = carts.FirstOrDefault(a => a.UserID == userId);

            if (cart != null)
            {
                var _item = cart.Items.FirstOrDefault(a => a.ProductID == productId && a.Length == length);

                if (_item != null)
                {
                    _item.Amount = amount;
                    _item.Price = _item.Amount * _item.PricePerMeter * _item.Length;
                }

                foreach (string id in cart.ConnectionIDs)
                    Clients.Client(id).refreshShoppingCart(cart.Items);

                CalculateSummaryOrderPrice(userId);
            }
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        private Cart CreateEmptyShoppingCart(string userId)
        {
            var cart = new Cart { UserID = userId };
            cart.ConnectionIDs.Add(Context.ConnectionId);
            carts.Add(cart);
            return cart;
        }
    }
}
