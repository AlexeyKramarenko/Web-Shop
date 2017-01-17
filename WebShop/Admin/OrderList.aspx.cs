using AutoMapper;
using WebShop.Admin.Models;
using WebShop.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop.Admin
{
    public partial class OrderList : System.Web.UI.Page
    {
        [Inject]
        public IOrderRepository OrderRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }        
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int orderId = int.Parse(e.CommandArgument.ToString());
                OrderRepository.RemoveOrder(orderId);
                int result = OrderRepository.Save();
            }
        }
        public List<OrderItemViewModel> GetOrders()
        {
            var orders = OrderRepository.GetAllOrders();
            var ordersVM = Mapper.Map<IEnumerable<WebShop.DAL.POCO.Order>, List<WebShop.Admin.Models.OrderItemViewModel>>(orders);
            return ordersVM;
        }
    }
}