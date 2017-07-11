using System.Web.Mvc;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace PTSProject.Controllers
{
    /// <summary>
    /// This controller is just for conventions resolution or helper actions
    /// </summary>
    public partial class HomeController : Controller
    {

        /// <summary>
        /// Triggers the application main if it has not been started yet
        /// </summary>
        private void StartApplication()
        {
            var applicationHasStarted = Session["ApplicationHasStarted"];
            if (applicationHasStarted == null || !((bool)applicationHasStarted))
            {
                WebSite.Startup.EntryPoint(UpgradeHelpers.Helpers.StaticContainer.Instance);
                Session["ApplicationHasStarted"] = true;
            }

        }
        public ActionResult Index()
        {
			return View();
        }

        /// <summary>
        /// Results a JSON object with all the current representation of the application state
        /// </summary>
        /// <returns></returns>
        public ActionResult AppState()
        {
            StartApplication();
            return new AppState();
        }

        public ActionResult DefaultEventHandler(string id, string form, [ModelBinder(typeof(GenericViewModelBinder))] IStateObject viewFromClient, string eventSender)
        {
            return ConventionBasedHelper.DefaultEventHandlerBasedOnConventions(typeof(HomeController) ,id, form, viewFromClient, eventSender);
        }
    }
}




