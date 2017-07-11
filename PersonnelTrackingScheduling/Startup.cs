using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using UpgradeHelpers.WebMap.Server;
using System.Web.Routing;
using System.Web.UI;
using Microsoft.Practices.Unity;

[assembly: OwinStartupAttribute(typeof(WebSite.Startup))]
namespace WebSite
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			ExternalConfig.RegisterLocalScripts();
			//The current assembly must be sent to register any ViewModels defined in it
			Bootstrapper.Initialize(this.GetType().Assembly);
			ConfigureAuth(app);
		}
	}
}
