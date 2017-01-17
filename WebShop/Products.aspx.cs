using ApplicationCore.ApplicationServices;
using AutoMapper;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class Products : BasePage
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        double pageCount;        
        public List<ProductItemViewModel> GetProducts()
        {
            int itemsPerPage = int.Parse(itemsPerPageList.SelectedValue);
            int currentPageNumber = 1;

            List<Product> products = ProductRepository.GetProducts(0, "asc", "asc", itemsPerPage, currentPageNumber, out pageCount);
            List<ProductItemViewModel> model = Mapper.Map<List<Product>, List<ProductItemViewModel>>(products);
            return model.ToList();
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            string content = "<li><a href='#' class='currentPage' style='background-color:yellow'>1</a></li>";
            for (int i = 2; i <= pageCount; i++)
                content += "<li><a href='#'>" + i + "</a></li>";
            Literal1.Text = content;
            Literal2.Text = content;

            sessionUserId.Value = this.UserID;
        }

    }
}