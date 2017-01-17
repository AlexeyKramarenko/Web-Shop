using ApplicationCore.ApplicationServices;
using AutoMapper;
using WebShop.Controls;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.Models;
using WebShop.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class WebForm1 : BasePage
    {      
        [Inject]
        public IOrderRepository OrderRepository { get; set; }
      
        public List<CartItemViewModel> GetShoppingCart()
        {
            if (CurrentCart != null)
            {
                if (CurrentCart.Items.Count > 0)
                {
                    var ctrl = (DeliveryServiceControl)LoadControl("~/Controls/DeliveryServiceControl.ascx");                    
                    ctrl.CurrentCart = this.CurrentCart;
                    ctrl.OrderRepository = this.OrderRepository;
                    PlaceHolder1.Controls.Add(ctrl);
                }
                return CurrentCart.Items;
            }
            return null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUserId.Value = this.UserID;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //IEnumerable<Delivery> deliveryServices = OrderRepository.GetDeliveryServices();
            //var collection = new ListItem[deliveryServices.Count()];
            //int selectedDeliveryId = CurrentCart.DeliveryID;
            //for (int i = 0; i < deliveryServices.Count(); i++)
            //{
            //    Delivery service = deliveryServices.ElementAt(i);
            //    collection[i] = new ListItem { Value = service.DeliveryID.ToString(), Text = service.DeliveryService + " (" + service.DeliveryPrice + " грн)" };

            //    if (i == (selectedDeliveryId - 1))
            //        collection[i].Selected = true;
            //}
            //deliveryService.Items.AddRange(collection);
        }
    }
}