using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgIndSchedLegendController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(PTSProject.ViewModels.dlgIndSchedLegendViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.CancelButton_Renamed_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.dlgIndSchedLegend logic { get; set; }

	}

}