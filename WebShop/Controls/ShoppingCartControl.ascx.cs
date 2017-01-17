using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop.UserControls
{
    public partial class ShoppingCartControl : System.Web.UI.UserControl
    {
        public BasePage BasePage
        {
            get
            {
                bool result = this.Page is BasePage;
                if (result)
                    return (BasePage)this.Page;
                else
                    return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BasePage != null)
                cartItemsAmount.Text = BasePage.ShoppingCart.GetSummaryItemsCount(BasePage.UserID).ToString();
        }
    }
}