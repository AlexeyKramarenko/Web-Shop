using AutoMapper;
using WebShop.Admin.Models;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
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
    public partial class EditProduct : System.Web.UI.Page
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        
        public EditProductViewModel GetProduct([RouteData]int id)
        {
            Product product = ProductRepository.GetProductByID(id);
            var model = Mapper.Map<Product, EditProductViewModel>(product);
            model.Materials = ProductRepository.GetMaterials();
            return model;
        }
        public void UpdateProduct(EditProductViewModel model)
        {
            Product product = Mapper.Map<EditProductViewModel, Product>(model);
            ProductRepository.UpdateProduct(product);
            int result = ProductRepository.Save();
        }
    }
}