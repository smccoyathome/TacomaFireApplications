using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// This filter prevents someone triggers an action of some visual control from JavaScript Console,
    /// where the visual control is not enabled at that moment
    /// 
    /// TODO:
    /// As a further improvement this mechanism can be extended by providing an interface on Core Project
    /// that is implement by the class validates whether or not the widget is a valid state for triggering the
    /// event
    /// </summary>
    public class SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Normally, the Action Name has this pattern: ControlName_Action
            var actionName = filterContext.ActionDescriptor.ActionName;
            int idx = actionName.LastIndexOf('_');
            if (idx > 0)
            {
                object obj = null;
                //Only apply filter if there is a WebMapAction.VIEWFROMCLIENT or WebMapAction.USERCONTROL argument
                string objectName = JSONAjaxValueProvider.WebMapAction.VIEWFROMCLIENT;
                bool skip = true;
                if (!filterContext.ActionParameters.TryGetValue(objectName, out obj))
                {
                    objectName = JSONAjaxValueProvider.WebMapAction.USERCONTROL;
                    if (filterContext.ActionParameters.TryGetValue(objectName, out obj))
                        skip = false;
                }
                else skip = false;
                if (!skip)
                    FilterAction(obj, actionName, idx);
            }
            base.OnActionExecuting(filterContext);
        }
        private void FilterAction(object obj, string actionName, int idx)
        {
            if (obj != null)
            {
                var controlName = actionName.Substring(0, idx);
                var prop = obj.GetType().GetProperty(controlName);
                if (prop != null)
                {
                    object propObject = prop.GetValue(obj, null);
                    if (propObject != null)
                    {
                        var enableProp = propObject.GetType().GetProperty("Enabled");
                        if (enableProp != null && enableProp.PropertyType == typeof(bool))
                        {
                            var isEnabled = (bool)enableProp.GetValue(propObject, null);
                            if (!isEnabled)
                            {
                                throw new System.Security.SecurityException("Action Denied. Detected invalid state while trying to trigger event " + actionName);
                            }

                        }
                    }
                }
            }
        }
    }
}
