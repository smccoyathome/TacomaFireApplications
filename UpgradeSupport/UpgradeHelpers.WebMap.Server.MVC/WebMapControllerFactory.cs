using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using UpgradeHelpers.Interfaces;
using System.Web.Routing;

namespace UpgradeHelpers.WebMap.Server
{

    public class WebMapControllerFactory : DefaultControllerFactory
    {

        public WebMapControllerFactory() : base() { }
        public WebMapControllerFactory(IControllerActivator controllerActivator) : base(controllerActivator)
        {
        }


        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var res = base.CreateController(requestContext, controllerName);
            if (res != null)
            {
                DoDefaultInjectionInController(res);
            }
            return res;

        }

        internal static void DoDefaultInjectionInController(object controller)
        {
            var controllerType = controller.GetType();
            ///This will force a call to StartRequest
            WebMapLifeCycle.StartRequest(DefaultRequestProvider: WebMapMVCUtils.DefaultJsonProviderFromPOST);
            var viewManagerInstance = ViewManager.Instance;
            PropertyInfo logicProperty = controllerType.GetProperty("logic");

            if (logicProperty != null)
            {

                object logic = IocContainerImplWithUnity.Current.Resolve(logicProperty.PropertyType, flags: IIocContainerFlags.NoView);
                logicProperty.SetValue(controller, logic, null);
            }

            var viewManagerProperty = controllerType.GetProperty("viewManager");
            if (viewManagerProperty != null)
            {
                viewManagerProperty.SetValue(controller, viewManagerInstance, null);
            }
            else
            {
                viewManagerProperty = controllerType.GetProperty("ViewManager");
                if (viewManagerProperty != null)
                {
                    viewManagerProperty.SetValue(controller, viewManagerInstance, null);
                }
            }

        }
    }

}