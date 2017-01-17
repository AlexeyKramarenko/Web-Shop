using WebShop.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class Site : System.Web.UI.MasterPage
    {

        //public BasePage BasePage
        //{
        //    get
        //    {
        //        bool result = this.Page is BasePage;
        //        if (result)
        //            return (BasePage)this.Page;
        //        else
        //            return null;
        //    }
        //}
      

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //if (BasePage != null)
            //    cartItemsAmount.Text = BasePage.ShoppingCart.GetSummaryItemsCount(BasePage.UserID).ToString();
        }
    }
}