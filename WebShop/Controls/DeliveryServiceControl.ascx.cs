using AutoMapper;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop.Controls
{
    public partial class DeliveryServiceControl : System.Web.UI.UserControl
    {    
        public IOrderRepository OrderRepository { get; set; }
        public Cart CurrentCart { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Delivery> deliveryServices = OrderRepository.GetDeliveryServices();
            var collection = new ListItem[deliveryServices.Count()];
            int selectedDeliveryId = CurrentCart.DeliveryID;
            for (int i = 0; i < deliveryServices.Count(); i++)
            {
                Delivery service = deliveryServices.ElementAt(i);
                collection[i] = new ListItem { Value = service.DeliveryID.ToString(), Text = service.DeliveryService + " (" + service.DeliveryPrice + " грн)" };

                if (i == (selectedDeliveryId - 1))
                    collection[i].Selected = true;
            }
            
            deliveryService.Items.AddRange(collection);
        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    IEnumerable<Delivery> deliveryServices = OrderRepository.GetDeliveryServices();
        //    var collection = new ListItem[deliveryServices.Count()];
        //    int selectedDeliveryId = CurrentCart.DeliveryID;
        //    for (int i = 0; i < deliveryServices.Count(); i++)
        //    {
        //        Delivery service = deliveryServices.ElementAt(i);
        //        collection[i] = new ListItem { Value = service.DeliveryID.ToString(), Text = service.DeliveryService + " (" + service.DeliveryPrice + " грн)" };

        //        if (i == (selectedDeliveryId - 1))
        //            collection[i].Selected = true;
        //    }
        //    deliveryService.Items.AddRange(collection);
        //}
    }
}