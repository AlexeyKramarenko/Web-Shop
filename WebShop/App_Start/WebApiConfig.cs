using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebShop.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "webapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
              
            config.Routes.MapHttpRoute(
               name: "ProductList",
               routeTemplate: "webapi/{controller}/{action}/{materialId}/{sortByDiameter}/{sortByPrice}/{maximumRows}/{currentPageNumber}",
               defaults: new
               {
                   materialId = RouteParameter.Optional,
                   sortByDiameter = RouteParameter.Optional,
                   sortByPrice = RouteParameter.Optional,
                   itemsPerPage = RouteParameter.Optional,
                   currentPageNumber = RouteParameter.Optional 
               });
        }
    }
}
