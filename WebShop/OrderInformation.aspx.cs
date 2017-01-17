using ApplicationCore.ApplicationServices;
using AutoMapper;
using WebShop.DAL;
using WebShop.DAL.POCO;
using WebShop.Models;
using WebShop.SignalR;
using Ninject;
using System;
using System.Collections.Generic;

namespace WebShop
{
    public partial class OrderInformation : BasePage
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
         
        public void SendOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = Mapper.Map<OrderViewModel, Order>(model);
                order.OrderedItems = Mapper.Map<List<CartItemViewModel>, List<OrderItem>>(CurrentCart.Items);
                order.SummaryPrice = CurrentCart.SummaryPrice;
                order.DeliveryID = CurrentCart.DeliveryID;
                order.OrderDate = DateTime.Now;

                OperationResult result = OrderService.SendOrder(order);

                if (result.Succeded)
                {                    
                    ShoppingCart.RemoveShoppingCart(this.UserID);
                    orderForm.Visible = false;
                    panelOrderSucceded.Visible = true;
                }
                else
                    ModelState.AddModelError("error", result.Message); 
            }
        }
    }
}