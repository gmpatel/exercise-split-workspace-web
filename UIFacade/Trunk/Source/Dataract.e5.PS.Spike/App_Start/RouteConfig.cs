using System.Web.Mvc;
using System.Web.Routing;

namespace Dataract.e5.PS.Spike.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index4", id = UrlParameter.Optional }
            );
        }
    }
}