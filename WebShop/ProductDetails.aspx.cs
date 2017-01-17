using ApplicationCore.ApplicationServices;
using AutoMapper;
using WebShop.DAL;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class ProductDetails : BasePage
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        
        public ProductDetailsViewModel GetProduct([RouteData] int? id)
        {
            if (id != null)
            {
                Product product = ProductRepository.GetProductByID(id.Value);
                var model = Mapper.Map<Product, ProductDetailsViewModel>(product);
                return model;
            }
            
            Response.Redirect("404.aspx");
            return null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUserId.Value = this.UserID;
        }
    }
}