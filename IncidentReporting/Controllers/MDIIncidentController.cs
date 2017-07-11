using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class MDIIncidentController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult mnuExit_Click(TFDIncident.ViewModels.MDIIncidentViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuExit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.MDIIncident logic { get; set; }

	}

}