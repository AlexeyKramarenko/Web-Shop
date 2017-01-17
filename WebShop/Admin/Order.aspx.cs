using AutoMapper;
using WebShop.Admin.Models;
using WebShop.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop.Admin
{
    public partial class Order : System.Web.UI.Page
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }
        [Inject]
        public IOrderRepository OrderRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public WebShop.Admin.Models.OrderViewModel GetOrder([RouteData] int id)
        {
            WebShop.DAL.POCO.Order order = OrderRepository.GetOrderByID(id);
            OrderViewModel model = Mapper.Map<WebShop.DAL.POCO.Order, OrderViewModel>(order);
            for (int i = 0; i < model.OrderedItems.Count; i++)
            {
                OrderedProductViewModel product = model.OrderedItems[i];
                product.ThumbImgPath = ProductRepository.GetThumbnailImage(product.ProductID);
            }
            return model;
        }
    }
}