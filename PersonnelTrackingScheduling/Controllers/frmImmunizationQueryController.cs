using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmImmunizationQueryController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optAll_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optAll_CheckedChanged(logic.ViewModel.optAll, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt182_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt182_CheckedChanged(logic.ViewModel.opt182, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt181_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt181_CheckedChanged(logic.ViewModel.opt181, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt183_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt183_CheckedChanged(logic.ViewModel.opt183, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optA_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optA_CheckedChanged(logic.ViewModel.optA, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optC_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optC_CheckedChanged(logic.ViewModel.optC, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optB_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optB_CheckedChanged(logic.ViewModel.optB, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optD_CheckedChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optD_CheckedChanged(logic.ViewModel.optD, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtStart_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtStart_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtEnd_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtEnd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkNotReceived_CheckStateChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkNotReceived_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAssignmentCode_SelectionChangeCommitted(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAssignmentCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdQuery_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtNameSearch_TextChanged(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtNameSearch_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmImmunizationQueryViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmImmunizationQuery logic { get; set; }

	}

}