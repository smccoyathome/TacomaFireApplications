using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmBattSchedNewController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmBattSchedNew_Activated(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmBattSchedNew_Activated(logic.ViewModel, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult frmBattSchedNew_Deactivate(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmBattSchedNew_Deactivate(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTimeCard_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTimeCard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuException_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuException_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintDailyLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintDailyLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintAll_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintAll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuClose_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEmpInfo_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEmpInfo_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSenoirInq_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSenoirInq_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuImmune_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuImmune_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_transfer_req_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_transfer_req_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPMCerts_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPMCerts_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPPE_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndSchedule_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndSchedule_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewBatt2_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewBatt2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion3_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion4_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion4_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMS_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMS_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazmat_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazmat_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarine_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarine_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattStaff_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatch_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatch_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_watch_duty_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_watch_duty_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_Vacation_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_Vacation_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMVacationSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_HZMVacationSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_HZMVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_FCCVacationSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_FCCVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAssignReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAssignReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRoster_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRoster_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuFRoster_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuFRoster_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDebitReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDebitReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuProlist_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuProlist_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSenior_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSenior_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_emp_facility_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_emp_facility_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult MnuAuditDDHOL_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.MnuAuditDDHOL_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndivPayrollSO_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndivPayrollSO_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard2_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu181_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu181_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu182_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMSPay_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMSPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazPay_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarPay_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattPay_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDisPay_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDisPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndYearSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndYearSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyStaff_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuOvertime_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuOvertime_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult MnuExtraOff_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.MnuExtraOff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_sa_report_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_sa_report_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuShiftCal_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuShiftCal_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTransfer_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTransfer_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAnnual_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAnnual_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_dailysickleave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_dailysickleave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_sick_usage_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_sick_usage_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatchLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatchLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_HZMLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_HZMLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult MnuCBStaffing_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.MnuCBStaffing_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_LeaveNoSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_LeaveNoSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_staffdiscrepancy_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_staffdiscrepancy_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMCSRCalc_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMCSRCalc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_SchedNotes_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_SchedNotes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PPEQuery_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PPEQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_timecard_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_timecard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuindannualpayroll_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuindannualpayroll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnupersonnelsignoff_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnupersonnelsignoff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_QuarterlyMinimumDrill_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_QuarterlyMinimumDrill_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_FCCMinDrills_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_FCCMinDrills_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_ReadingAssign_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_ReadingAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_OTEPReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_OTEPReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMRecertReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMRecertReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMBaseStaReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMBaseStaReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_trainingtracker_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_trainingtracker_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndTrainReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndTrainReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndPMRecert_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndPMRecert_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuALSProc_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuALSProc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainQuery_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_TrainingQuerynew_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_TrainingQuerynew_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuCascade_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuCascade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintScreen_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintScreen_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAbout_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAbout_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_timecodes_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_timecodes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainCodeHelp_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainCodeHelp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_HelpPrntScrn_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_HelpPrntScrn_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payup_calc_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payup_calc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payrolllegend_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payrolllegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_legend_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_legend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndLegend_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndLegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuLeave_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewSched_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayUp_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayUp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayDown_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayDown_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuKOT_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuKOT_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRover_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRover_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDebit_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDebit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrade_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuCancelTrade_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuCancelTrade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRemove_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRemove_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo182_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuReport_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTradeDetail_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTradeDetail_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_viewtimecard_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_viewtimecard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSADetail_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSADetail_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuReschedSA_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuReschedSA_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnu181PopUp_Closing(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnu181PopUp_Closing(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnu181PopUp_Opening(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnu181PopUp_Opening(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calSchedDate_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calSchedDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRovers_SelectionChangeCommitted(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRovers_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRovers_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRovers_DragOver(null, logic.ViewModel.cboRovers.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboRovers_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.cboRovers_DragDrop(null, logic.ViewModel.cboRovers.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboDebit_SelectionChangeCommitted(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboDebit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboDebit_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.cboDebit_DragOver(null, logic.ViewModel.cboDebit.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboDebit_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.cboDebit_DragDrop(null, logic.ViewModel.cboDebit.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdToday_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdToday_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult pnSelected_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.pnSelected_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPosam_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPosam_DragDrop(logic.ViewModel.lbPosam[index], logic.ViewModel._lbPosam_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPosam_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPosam_DragOver(null, logic.ViewModel._lbPosam_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_0_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_4_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_8_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_8_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_12_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_12_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_16_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_16_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_68_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_68_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPospm_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPospm_DragDrop(logic.ViewModel.lbPospm[index], logic.ViewModel._lbPospm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPospm_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPospm_DragOver(null, logic.ViewModel._lbPospm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_0_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_4_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_8_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_8_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_12_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_12_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_16_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_16_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_68_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_68_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_1_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_5_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_9_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_9_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_13_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_13_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_17_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_17_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_69_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_69_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_1_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_5_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_9_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_9_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_13_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_13_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_17_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_17_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_69_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_69_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_2_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_6_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_10_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_10_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_14_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_14_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_18_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_18_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_70_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_70_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_2_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_6_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_10_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_10_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_14_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_14_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_18_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_18_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_70_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_70_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_3_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_7_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_7_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_11_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_11_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_15_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_15_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_19_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_19_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_71_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_71_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_3_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_7_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_7_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_11_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_11_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_15_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_15_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_19_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_19_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_71_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_71_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_72_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_72_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_20_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_20_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_24_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_24_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_28_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_28_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_32_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_32_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_36_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_36_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_72_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_72_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_20_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_20_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_24_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_24_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_28_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_28_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_32_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_32_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_36_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_36_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_73_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_73_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_21_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_21_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_25_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_25_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_29_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_29_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_33_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_33_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_37_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_37_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_73_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_73_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_21_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_21_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_25_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_25_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_29_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_29_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_33_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_33_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_37_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_37_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_74_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_74_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_22_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_22_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_26_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_26_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_30_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_30_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_34_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_34_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_38_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_38_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_74_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_74_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_22_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_22_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_26_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_26_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_30_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_30_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_34_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_34_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_38_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_38_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_75_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_75_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_23_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_23_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_27_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_27_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_31_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_31_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_35_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_35_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_39_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_39_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_75_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_75_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_27_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_27_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_31_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_31_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_35_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_35_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_23_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_23_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_39_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_39_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_76_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_76_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_76_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_76_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_40_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_40_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_44_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_44_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_48_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_48_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_52_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_52_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_56_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_56_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_77_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_77_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_40_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_40_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_44_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_44_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_48_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_48_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_52_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_52_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_56_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_56_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_77_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_77_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_41_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_41_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_45_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_45_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_49_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_49_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_53_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_53_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_57_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_57_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_78_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_78_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_41_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_41_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_45_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_45_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_49_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_49_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_53_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_53_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_57_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_57_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_78_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_78_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_42_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_42_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_46_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_46_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_50_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_50_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_54_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_54_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_58_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_58_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_79_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_79_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_42_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_42_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_46_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_46_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_50_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_50_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_54_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_54_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_58_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_58_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_79_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_79_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_43_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_43_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_47_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_47_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_51_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_51_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_55_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_55_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_59_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_59_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_80_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_80_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_43_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_43_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_47_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_47_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_51_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_51_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_55_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_55_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_59_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_59_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_80_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_80_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_60_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_60_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_64_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_64_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstSA_SelectedIndexChanged(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstSA_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdBattWorkSheet_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdBattWorkSheet_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_60_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_60_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_64_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_64_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_61_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_61_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_65_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_65_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_61_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_61_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_65_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_65_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_62_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_62_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_66_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_66_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_62_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_62_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_66_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_66_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbTo182_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.lbTo182_DragDrop(null, logic.ViewModel.lbTo182.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbTo182_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.lbTo182_DragOver(null, logic.ViewModel.lbTo182.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_63_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_63_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_67_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_67_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_63_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_63_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_67_MouseDown(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_67_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPayRoll_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPayRoll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdMissing_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdMissing_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSignOff_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSignOff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdListGray_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdListGray_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragDrop(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragDrop(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragOver(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragOver(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdBatt2_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdBatt2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAvailToWork_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAvailToWork_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNotes_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNotes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmBattSchedNewViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmBattSchedNew logic { get; set; }

	}

}