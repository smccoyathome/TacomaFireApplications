using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmTCEditController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdNotes_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNotes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdDeleteNotes_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdDeleteNotes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboKOT_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboKOT_SelectionChangeCommitted(logic.ViewModel.cboKOT[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAAType_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAAType_SelectionChangeCommitted(logic.ViewModel.cboAAType[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboLeave_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboLeave_SelectionChangeCommitted(logic.ViewModel.cboLeave[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboLeaveAA_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboLeaveAA_SelectionChangeCommitted(logic.ViewModel.cboLeaveAA[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboJobCode_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboJobCode_SelectionChangeCommitted(logic.ViewModel.cboJobCode[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboStep_SelectionChangeCommitted(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboStep_SelectionChangeCommitted(logic.ViewModel.cboStep[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtHours_TextChanged(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.txtHours_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCancel_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCancel_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSchedule_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSchedule_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdTrade_Click(PTSProject.ViewModels.frmTCEditViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdTrade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmTCEdit logic { get; set; }

	}

}