using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("TypeInfoRoute",new Route("TypeInfo/GetAll", new UpgradeHelpers.WebMap.Server.TypeInfoHandler()));
            routes.IgnoreRoute("{*staticfile}", new { staticfile = @".*\.(css|js|gif|jpg|png|map)(/.*)?" });
            routes.IgnoreRoute("undefined");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "WebSite.Controllers" }
            );
        }
    }
}