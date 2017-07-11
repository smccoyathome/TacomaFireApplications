using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmNewPPEWDLController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult opt181_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt181_CheckedChanged(logic.ViewModel.opt181, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt183_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt183_CheckedChanged(logic.ViewModel.opt183, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt182_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt182_CheckedChanged(logic.ViewModel.opt182, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optAll_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optAll_CheckedChanged(logic.ViewModel.optAll, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optA_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optA_CheckedChanged(logic.ViewModel.optA, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optC_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optC_CheckedChanged(logic.ViewModel.optC, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optB_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optB_CheckedChanged(logic.ViewModel.optB, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optD_CheckedChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optD_CheckedChanged(logic.ViewModel.optD, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrintChecklist_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrintChecklist_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkInactive_CheckStateChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkInactive_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEmpList_SelectionChangeCommitted(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEmpList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSearch_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSearch_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSizes_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSizes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUniformQuery_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUniformQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdGlobe_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdGlobe_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUpdateWDL_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUpdateWDL_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdLaundryMgmt_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdLaundryMgmt_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUniformInventory_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUniformInventory_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdLastInsp_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdLastInsp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdInspection_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdInspection_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRepair_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRepair_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCleaning_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCleaning_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtInspection_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtInspection_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtInspection_ValueChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtInspection_ValueChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAllOK_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAllOK_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddNew_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddNew_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNewItem_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNewItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEditItem_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdEditItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdFind_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdFind_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReplaceItem_Click(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReplaceItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboItemType_SelectionChangeCommitted(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboItemType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkManufDate_CheckStateChanged(PTSProject.ViewModels.frmNewPPEWDLViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkManufDate_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmNewPPEWDL logic { get; set; }

	}

}