using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace WebShop.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute(null, routeUrl: "", physicalFile: "~/Products.aspx");
            routes.MapPageRoute(null, routeUrl: "о_нас", physicalFile: "~/About.aspx");
            routes.MapPageRoute(null, routeUrl: "контакты", physicalFile: "~/Contacts.aspx");
            routes.MapPageRoute(null, routeUrl: "логин", physicalFile: "~/Login.aspx");

            routes.MapPageRoute(null, routeUrl: "оформление_заказа", physicalFile: "~/OrderInformation.aspx");
            routes.MapPageRoute(null, routeUrl: "шнур/{id}", physicalFile: "~/ProductDetails.aspx");
            routes.MapPageRoute(null, routeUrl: "шнуры", physicalFile: "~/Products.aspx");
            routes.MapPageRoute(null, routeUrl: "корзина", physicalFile: "~/ShoppingCart.aspx");
            routes.MapPageRoute(null, routeUrl: "статьи", physicalFile: "~/Articles.aspx");

            routes.MapPageRoute(null, routeUrl: "админ/добавить_шнур", physicalFile: "~/Admin/AddProduct.aspx");
            routes.MapPageRoute(null, routeUrl: "админ", physicalFile: "~/Admin/Admin.aspx");
            routes.MapPageRoute(null, routeUrl: "админ/редактировать_описание/{id}", physicalFile: "~/Admin/EditProduct.aspx");
            routes.MapPageRoute(null, routeUrl: "админ/заказ/{id}", physicalFile: "~/Admin/Order.aspx");
            routes.MapPageRoute(null, routeUrl: "админ/список_заказов", physicalFile: "~/Admin/OrderList.aspx");
            routes.MapPageRoute(null, routeUrl: "админ/список_шнуров", physicalFile: "~/Admin/ProductList.aspx");
            routes.MapPageRoute(null, routeUrl: "админ/посетители", physicalFile: "~/Admin/Visitors.aspx");

        }
    }
}
