using System.Web.Mvc;
using System.Web.Routing;

namespace Quacka
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = @"Account|Flocks|Manage|Ponds" }
            );

            routes.MapRoute(
                "MyFlocks",
                "{myFlocks}",
                new { controller = "Flocks", action = "Index" },
                new { myFlocks = @"MyFlocks" }
            );

            routes.MapRoute(
                "Pond",
                "{userName}",
                new {controller = "Ponds", action = "Show"}
            );

            routes.MapRoute(
                "Quacks",
                "",
                new {controller = "Quacks", action = "Index"}
            );
            //routes.MapRoute(
            //    "Quacks",
            //    "{*url}",
            //    new { controller = "Quacks", action = "Index" }
            //);
        }
    }
}
