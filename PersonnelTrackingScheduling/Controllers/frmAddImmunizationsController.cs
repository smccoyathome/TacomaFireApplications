using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmAddImmunizationsController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optAll_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optAll_CheckedChanged(logic.ViewModel.optAll, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt182_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt182_CheckedChanged(logic.ViewModel.opt182, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt181_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt181_CheckedChanged(logic.ViewModel.opt181, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult opt183_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.opt183_CheckedChanged(logic.ViewModel.opt183, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnit_SelectionChangeCommitted(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optA_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optA_CheckedChanged(logic.ViewModel.optA, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optC_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optC_CheckedChanged(logic.ViewModel.optC, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optB_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optB_CheckedChanged(logic.ViewModel.optB, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optD_CheckedChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optD_CheckedChanged(logic.ViewModel.optD, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAssignmentCode_SelectionChangeCommitted(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAssignmentCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(logic.ViewModel.cmdAdd[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemove_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemove_Click(logic.ViewModel.cmdRemove[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkImmuneDate_CheckStateChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkImmuneDate_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNewRecord_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNewRecord_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboType_SelectionChangeCommitted(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddRecord_Click(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddRecord_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkResults_CheckStateChanged(PTSProject.ViewModels.frmAddImmunizationsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkResults_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmAddImmunizations logic { get; set; }

	}

}