using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
    public class WebMapViewManagerController : Controller
    {
        public IViewManager ViewManager { get; set; }
        public System.Web.Mvc.ActionResult QueryClose(string viewId)
        {
            //Find corresponding Form Type

            var genericInterface = typeof(UpgradeHelpers.Interfaces.ILogicWithViewModel<>);
            var view = StateManager.Current.GetObject(viewId) as UpgradeHelpers.Interfaces.IViewModel;
			if (view==null)
			{
                TraceUtil.TraceError("QueryClose issue for View {0}", viewId);
				return new UpgradeHelpers.WebMap.Server.AppChanges();
			}
            var viewType = view.GetType();
            //Get original type if View was instrumented
            TypeCacheUtils.GetOriginalType(ref viewType);

            var interfaceBindingFormAndViewTogether = genericInterface.MakeGenericType(viewType);
           
            //I assume that the matching form logic is defined in the same assembly and that there is only one
            foreach(var clazz in viewType.Assembly.GetTypes())
            {
                if (interfaceBindingFormAndViewTogether.IsAssignableFrom(clazz))
                {
                    var logic = IocContainerImplWithUnity.Current.Resolve(clazz, new object[] { view, }) as UpgradeHelpers.Interfaces.ILogicWithViewModel<UpgradeHelpers.Interfaces.IViewModel>;
                    if (logic == null)
                    {
                        TraceUtil.WriteLine("WebMapViewManagerController::QueryClose error could not recover form object");
                    }
                    else
                    {
                        ViewManager.DisposeView(logic);
                    }
                    break;
                }
            }
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }


        /// <summary>
        /// Results a JSON object with all the current representation of the application state
        /// </summary>
        /// <returns></returns>
        public ActionResult AppState()
        {
			Response.ContentType = "application/json";
            using (var streamWriter = new System.IO.StreamWriter(Response.OutputStream))
            {
                StateManager.Current.GenerateCurrentStateAsJSON(Response.Output);
            }
			return new EmptyResult();
        }

        public ActionResult ResumePendingOperation(string dialogResult, string requestedInput)
        {
            ViewManager.ResumePendingOperation(dialogResult, requestedInput);
            return new AppChanges();
        }
    }
}
