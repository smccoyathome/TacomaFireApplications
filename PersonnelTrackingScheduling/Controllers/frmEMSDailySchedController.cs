using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmEMSDailySchedController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmEMSDailySched_Activated(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmEMSDailySched_Activated(logic.ViewModel, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult frmEMSDailySched_Deactivate(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmEMSDailySched_Deactivate(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintPayPeriodReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintPayPeriodReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuClose_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEmpInfo_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEmpInfo_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSeniorityInq_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSeniorityInq_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuImmune_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuImmune_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_transfer_req_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_transfer_req_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPPE_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndSchedule_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndSchedule_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion1_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion2_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewBatt3_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewBatt3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion3_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion4_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion4_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMS_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMS_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazmat_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazmat_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarine_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarine_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattStaff_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatch_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatch_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_watch_duty_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_watch_duty_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_Vacation_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_Vacation_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMVacationSched_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAssign_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRoster_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRoster_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_DDGroups_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_DDGroups_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuProlist_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuProlist_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSenior_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSenior_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBenefit_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBenefit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_emp_facility_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_emp_facility_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndivPayrollSO_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndivPayrollSO_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard2_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu181_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu181_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu182_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu183_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu183_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMSPay_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMSPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazPay_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarPay_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattPay_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDisPay_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDisPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndYearSched_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndYearSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyStaff_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuOvertime_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuOvertime_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_sa_report_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_sa_report_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuShiftCal_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuShiftCal_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTransfer_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTransfer_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyLeave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAnnual_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAnnual_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_dailysickleave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_dailysickleave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndLeave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMLeave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatchLeave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatchLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnutimecard_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnutimecard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuindannualpayroll_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuindannualpayroll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnupersonnelsignoff_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnupersonnelsignoff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_QuarterlyMinimumDrill_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_QuarterlyMinimumDrill_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_ReadingAssign_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_ReadingAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_OTEPReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_OTEPReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMRecertReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMRecertReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_trainingtracker_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_trainingtracker_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndTrainReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndTrainReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndPMRecert_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndPMRecert_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainQuery_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_TrainingQuerynew_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_TrainingQuerynew_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuCascade_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuCascade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintScreen_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintScreen_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAbout_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAbout_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_timecodes_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_timecodes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payrolllegend_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payrolllegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_legend_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_legend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndLegend_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndLegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payup_calc_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payup_calc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainCodeHelp_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainCodeHelp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewSched_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuLeave_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayUp_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayUp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayDown_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayDown_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuKOT_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuKOT_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRemove_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRemove_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo181_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo181_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo182_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo183_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo183_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_viewtimecard_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_viewtimecard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuViewDetail_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuViewDetail_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnuEMSPopup_Closing(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnuEMSPopup_Closing(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnuEMSPopup_Opening(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnuEMSPopup_Opening(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calSchedDate_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calSchedDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult pnSelected_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.pnSelected_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSelectName_SelectionChangeCommitted(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSelectName_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPosam_DragDrop(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPosam_DragDrop(logic.ViewModel.lbPosam[index], logic.ViewModel._lbPosam_36.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPosam_DragOver(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPosam_DragOver(null, logic.ViewModel._lbPosam_36.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_36_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_36_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_0_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_4_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_8_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_8_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_12_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_12_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_16_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_16_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPospm_DragDrop(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPospm_DragDrop(logic.ViewModel.lbPospm[index], logic.ViewModel._lbPospm_36.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPospm_DragOver(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPospm_DragOver(null, logic.ViewModel._lbPospm_36.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_36_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_36_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_0_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_4_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_8_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_8_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_12_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_12_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_16_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_16_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_37_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_37_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_1_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_5_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_9_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_9_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_13_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_13_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_17_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_17_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_37_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_37_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_1_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_5_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_9_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_9_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_13_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_13_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_17_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_17_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_38_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_38_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_2_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_6_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_10_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_10_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_14_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_14_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_18_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_18_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_38_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_38_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_2_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_6_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_10_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_10_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_14_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_14_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_18_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_18_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_39_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_39_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_3_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_7_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_7_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_11_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_11_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_15_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_15_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_19_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_19_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_39_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_39_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_3_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_7_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_7_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_15_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_15_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_19_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_19_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_11_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_11_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_20_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_20_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_24_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_24_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_28_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_28_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_32_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_32_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_20_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_20_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_24_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_24_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_28_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_28_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_32_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_32_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_21_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_21_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_25_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_25_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_29_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_29_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_33_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_33_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_21_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_21_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_25_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_25_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_29_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_29_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_33_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_33_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_22_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_22_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_26_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_26_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_30_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_30_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_34_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_34_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_22_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_22_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_26_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_26_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_30_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_30_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_34_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_34_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_23_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_23_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_27_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_27_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_31_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_31_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPosam_35_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPosam_35_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_23_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_23_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_27_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_27_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_31_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_31_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPospm_35_MouseDown(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPospm_35_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragDrop(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragDrop(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragOver(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragOver(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPayroll_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPayroll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReport_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmEMSDailySchedViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmEMSDailySched logic { get; set; }

	}

}