using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P03MVCRoute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Default3",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            constraints: new { id = @"\d*" }, namespaces: new string[1] { "P03MVCRoute.Controllers" }
        );
            routes.MapRoute(
              name: "Default4",
              url: "{controller}/{action}/{name}",
              defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional },
            constraints: new { name = @"[a-zA-z]*" }, namespaces: new string[1] { "P03MVCRoute.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "P03MVCRoute.Controllers" }
            );
            routes.MapRoute(
              name: "Default2",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              constraints: new { controller = @"\d{4}", action = @"\d{2}", id = @"\d*" },
                namespaces: new string[1] { "P03MVCRoute.Controllers" }
          );
           
        }
        // new string[1] { "P03UserArea.Controllers" }
        //namespaces:new string[1] { "P03MVCRoute.Controllers" }
    }
}