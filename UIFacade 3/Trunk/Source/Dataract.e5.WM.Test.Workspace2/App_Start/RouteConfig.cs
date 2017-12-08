using System.Web.Mvc;
using System.Web.Routing;

namespace Dataract.e5.WM.Test.Workspace2.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "WS2", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}