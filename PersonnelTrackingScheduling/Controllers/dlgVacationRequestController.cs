using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgVacationRequestController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optRequest_CheckedChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optRequest_CheckedChanged(logic.ViewModel.optRequest, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optDelete_CheckedChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optDelete_CheckedChanged(logic.ViewModel.optDelete, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optUpdate_CheckedChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optUpdate_CheckedChanged(logic.ViewModel.optUpdate, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optAvailable_CheckedChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optAvailable_CheckedChanged(logic.ViewModel.optAvailable, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboReqNameList_SelectionChangeCommitted(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboReqNameList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkPMOnly_CheckStateChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkPMOnly_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkHZMOnly_CheckStateChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkHZMOnly_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearRequest_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearRequest_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calAvail_DateChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calAvail_DateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAvailDone_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAvailDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboNameList_SelectionChangeCommitted(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboNameList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstCurrSched_SelectedIndexChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstCurrSched_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReqDone_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReqDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUpdateNameList_SelectionChangeCommitted(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUpdateNameList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUpdateNameList_TextChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUpdateNameList_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboKOT_SelectionChangeCommitted(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboKOT_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboKOT_TextChanged(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboKOT_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUpdateDone_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUpdateDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearAvail_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearAvail_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(PTSProject.ViewModels.dlgVacationRequestViewModel viewFromClient, object eventSender)
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

		public PTSProject.dlgVacationRequest logic { get; set; }

	}

}