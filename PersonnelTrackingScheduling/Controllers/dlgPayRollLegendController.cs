using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgPayRollLegendController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdCancel_Click(PTSProject.ViewModels.dlgPayRollLegendViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCancel_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.dlgPayRollLegend logic { get; set; }

	}

}