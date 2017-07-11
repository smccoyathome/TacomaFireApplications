using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmStaffingDiscrepancyController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult chkDateFilter_CheckStateChanged(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkDateFilter_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdExit_Click(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtStartDate_Click(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtStartDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtEndDate_Click(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtEndDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmStaffingDiscrepancyViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmStaffingDiscrepancy logic { get; set; }

	}

}