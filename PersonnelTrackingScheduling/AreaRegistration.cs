using System.Web.Mvc;
using PTSProject.Controllers;
using UpgradeHelpers.WebMap.Server;

namespace PTSProject.Areas
{
    public class Project1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TFDPTS";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            var route = context.MapRoute("TFDPTS_default", "TFDPTS/{controller}/{action}/{id}", new {id = UrlParameter.Optional },new [] { "PTSProject.Controllers"} );
            route.RouteHandler = new DefaultEventHandlerRouteHandler<HomeController>();
        }
    }
}


