using System.Web.Mvc;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.Controls.Controllers
{
    /// <summary>
    /// This controller is just for conventions resolution or helper actions
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult DefaultEventHandler(string id, string form, [ModelBinder(typeof(GenericViewModelBinder))] IStateObject viewFromClient, string eventSender)
        {
            return ConventionBasedHelper.DefaultEventHandlerBasedOnConventions(typeof(HomeController) ,id, form, viewFromClient, eventSender);
        }

    }
}

