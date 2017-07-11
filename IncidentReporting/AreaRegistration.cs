using System.Web.Mvc;
using TFDIncident.Controllers;
using UpgradeHelpers.WebMap.Server;

namespace TFDIncident.Areas
{
    public class Project1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "prjIncident";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            var route = context.MapRoute("prjIncident_default", "prjIncident/{controller}/{action}/{id}", new {id = UrlParameter.Optional },new [] { "TFDIncident.Controllers"} );
            route.RouteHandler = new DefaultEventHandlerRouteHandler<HomeController>();
        }
    }
}


