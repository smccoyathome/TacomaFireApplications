using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class frmQueryResultsController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdPrint_Click(TFDIncident.ViewModels.frmQueryResultsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(TFDIncident.ViewModels.frmQueryResultsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.frmQueryResults logic { get; set; }

	}

}