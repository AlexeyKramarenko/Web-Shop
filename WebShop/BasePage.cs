using WebShop.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class BasePage : System.Web.UI.Page
    {
        public string UserID
        {
            get
            {
                if (Session["UserID"] == null)
                {
                    Session["UserID"] = Guid.NewGuid().ToString();
                }
                return Session["UserID"].ToString();
            }
        }
        public Cart CurrentCart
        {
            get
            {
                var cart = ShoppingCart.GetCart(UserID);
                return cart;
            }
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return new ShoppingCart();
            }
        }
    }
}
