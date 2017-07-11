using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmDailyBattWorksheetController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult dtReportDate_Click(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtReportDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtReportDate_ValueChanged(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtReportDate_ValueChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optBatt1_CheckedChanged(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optBatt1_CheckedChanged(logic.ViewModel.optBatt1, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optBatt2_CheckedChanged(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optBatt2_CheckedChanged(logic.ViewModel.optBatt2, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmDailyBattWorksheetViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmDailyBattWorksheet logic { get; set; }

	}

}