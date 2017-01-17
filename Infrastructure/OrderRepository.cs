using WebShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.DAL.POCO;
using Infrastructure;

namespace WebShop.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }
        public Order GetOrderByID(int orderId)
        {
            Order order = db.Orders.Include("Delivery").FirstOrDefault(a=>a.OrderID== orderId);
            return order;
        }
        public IEnumerable<Order> GetOrdersByDate(DateTime from, DateTime to)
        {
            IEnumerable<Order> orders = db.Orders.Where(a => from <= a.OrderDate && to >= a.OrderDate);
            return orders;
        }
        public IEnumerable<Order> GetOrdersByLastName(string lastname)
        {
            IEnumerable<Order> orders = db.Orders.Where(a => a.LastName.StartsWith(lastname));
            return orders;
        }
        public IEnumerable<Order> GetOrdersByProductMaterial(string material)
        {
            //IQueryable<Order> orders = from order in db.Orders
            //                           join item in db.OrderItems
            //                           on order.OrderID equals item.OrderID
            //                           where item.Product.Material.MaterialName == material
            //                           select order;

            //return orders;
            return null;
        }
        public IEnumerable<Order> GetOrdersByTown(string town)
        {
            return db.Orders.Include("OrderItems").Where(a => a.Town == town);
        }
        public double GetDeliveryPriceById(int deliveryId)
        {
            Delivery deliveryService = db.Delivery.Find(deliveryId);
            if (deliveryService != null)
                return deliveryService.DeliveryPrice;
            else
                return 0;
        }
        public IEnumerable<Delivery> GetDeliveryServices()
        {
            return db.Delivery.ToList();
        }

        public void RemoveOrder(int orderId)
        {
            Order order = db.Orders.Find(orderId);
            if (order != null)
                db.Orders.Remove(order);
        }

        public string GetDeliveryServiceByID(int deliveryID)
        {
           var service = db.Delivery.Find(deliveryID);
            if (service != null)
                return service.DeliveryService;
            return null;
        }
    }
}
