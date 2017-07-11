using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UpgradeHelpers.WebMap.Server
{
	public class DefaultEventHandlerRouteHandler<TReferenceController> : IRouteHandler
	{
		#region IRouteHandler Members

		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			string controller = requestContext.RouteData.Values["controller"].ToString();
			if (controller != "Home" && controller != "favicon.ico")
			{
				string action = requestContext.RouteData.Values["action"].ToString();
				Type referenceControllerType = typeof (TReferenceController);
				Assembly websiteAssembly = referenceControllerType.Assembly;
				Type controllerType = websiteAssembly.GetType(string.Format("{0}.{1}Controller", referenceControllerType.Namespace, controller), false);
				if (controllerType == null)
				{
					requestContext.RouteData.Values["controller"] = "Home";
					requestContext.RouteData.Values["action"] = "DefaultEventHandler";
					requestContext.RouteData.Values["id"] = action;
					requestContext.RouteData.Values.Add("form", controller);
				}
				else
				{
					MethodInfo method = controllerType.GetMethod(action);
					if (method == null)
					{
						requestContext.RouteData.Values["controller"] = "Home";
						requestContext.RouteData.Values["action"] = "DefaultEventHandler";
						requestContext.RouteData.Values["id"] = action;
						requestContext.RouteData.Values.Add("form", controller);
					}
				}
			}
			return new MvcHandler(requestContext);
		}

		#endregion
	}
}