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
                new { controller = @"Account|Manage|Profiles|Quacks" }
            );

            routes.MapRoute(
                "Profile",
                "{userName}",
                new {controller = "Profiles", action = "Show"}
            );

            routes.MapRoute(
                "Quacks",
                "",
                new { controller = "Quacks", action = "Index" }
            );
        }
    }
}
