using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmPayrollController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optAll_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optAll_CheckedChanged(logic.ViewModel.optAll, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt182_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt182_CheckedChanged(logic.ViewModel.opt182, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt181_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt181_CheckedChanged(logic.ViewModel.opt181, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt183_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt183_CheckedChanged(logic.ViewModel.opt183, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBenefit_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBenefit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnit_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboClose_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPayPeriod_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPayPeriod_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAssignmentCode_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAssignmentCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboYear_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboYear_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optA_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optA_CheckedChanged(logic.ViewModel.optA, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optC_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optC_CheckedChanged(logic.ViewModel.optC, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optB_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optB_CheckedChanged(logic.ViewModel.optB, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optD_CheckedChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optD_CheckedChanged(logic.ViewModel.optD, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReport_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkNotUploaded_CheckStateChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkNotUploaded_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtNameSearch_TextChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtNameSearch_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrintList_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrintList_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUploadALL_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUploadALL_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdOKToPay_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdOKToPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkAll_CheckStateChanged(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkAll_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSave_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAAType1_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAAType1_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboJobCode1_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboJobCode1_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdApply1_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdApply1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAAType2_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAAType2_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboJobCode2_SelectionChangeCommitted(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboJobCode2_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdApply2_Click(PTSProject.ViewModels.frmPayrollViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdApply2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmPayroll logic { get; set; }

	}

}