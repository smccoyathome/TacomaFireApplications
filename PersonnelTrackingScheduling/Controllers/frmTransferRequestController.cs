using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmTransferRequestController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optNewPosition_CheckedChanged(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optNewPosition_CheckedChanged(logic.ViewModel.optNewPosition, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optRequest_CheckedChanged(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optRequest_CheckedChanged(logic.ViewModel.optRequest, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboReqNameList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboReqNameList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearRequest_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearRequest_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboReqPositionList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboReqPositionList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnitList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnitList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPositionList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPositionList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboShiftList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboShiftList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dteOpenDate_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dteOpenDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddPosition_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddPosition_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboNameList_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboNameList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstAvailPositions_SelectedIndexChanged(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstAvailPositions_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboPriority_SelectionChangeCommitted(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboPriority_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReqDone_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReqDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAssign_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkActiveOnly_CheckStateChanged(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkActiveOnly_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdInactivate_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdInactivate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdDisplay_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdDisplay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(PTSProject.ViewModels.frmTransferRequestViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmTransferRequest logic { get; set; }

	}

}