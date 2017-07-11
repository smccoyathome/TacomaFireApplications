using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class frmOtherReportsController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdSave_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSave_Click(logic.ViewModel.cmdSave[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

        public System.Web.Mvc.ActionResult cmdDone_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
        {
            logic.ViewModel = viewFromClient;
            logic.cmdDone_Click(null, null);
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }

        public System.Web.Mvc.ActionResult cboFPEEquipment_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboFPEEquipment_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboFPEStatus_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboFPEStatus_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboFPEProblem_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboFPEProblem_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddPPE_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddPPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemovePPE_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemovePPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInjurySeverity_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInjurySeverity_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEDITFPE_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdEDITFPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkFPEProblem_CheckStateChanged(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkFPEProblem_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboActivity_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboActivity_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboWhereOccured_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboWhereOccured_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInjuryCausedBy_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInjuryCausedBy_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboLocationAtInjury_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboLocationAtInjury_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboCivNarrList_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboCivNarrList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkEMR_CheckStateChanged(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkEMR_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEMSPatient_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEMSPatient_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSeverity_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSeverity_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInjuryCause_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInjuryCause_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboCCLocation_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboCCLocation_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCivAddNarration_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCivAddNarration_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboServiceType_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboServiceType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtStandbyHours_TextChanged(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtStandbyHours_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtNumberSafePlace_TextChanged(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtNumberSafePlace_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboServiceNarrList_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboServiceNarrList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdServAddNarration_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdServAddNarration_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboNarrList_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboNarrList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAllInfo1_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAllInfo1_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAllInfo2_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAllInfo2_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAllInfo3_SelectionChangeCommitted(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAllInfo3_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtAllInfo1_TextChanged(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtAllInfo1_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddNarration_Click(TFDIncident.ViewModels.frmOtherReportsViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddNarration_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.frmOtherReports logic { get; set; }

	}

}