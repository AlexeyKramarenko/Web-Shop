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
    public partial class ProductList : System.Web.UI.Page
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        private int selectedMaterialId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var materials = ProductRepository.GetMaterials();
                var items = new ListItem[materials.Count];
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = new ListItem
                    {
                        Value = materials[i].MaterialID.ToString(),
                        Text = materials[i].MaterialName.ToString()
                    };
                }
                materialList.Items.Add(new ListItem { Value = 0.ToString(), Text = "Всё" });
                materialList.Items.AddRange(items);
            }
        }
        protected void materialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMaterialId = int.Parse(materialList.SelectedValue);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int productId = int.Parse(e.CommandArgument.ToString());
                ProductRepository.RemoveProduct(productId);
                int result = ProductRepository.Save();
            }
        }
        public List<ProductItemViewModel> GetProducts()
        {
            var products = ProductRepository.GetProducts(selectedMaterialId);
            var productsVM = Mapper.Map<List<WebShop.DAL.POCO.Product>, List<ProductItemViewModel>>(products);
            return productsVM;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetProducts();
            Repeater1.DataBind();
        }

    }
}