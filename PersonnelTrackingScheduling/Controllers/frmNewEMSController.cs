using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmNewEMSController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmNewEMS_Activated(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmNewEMS_Activated(logic.ViewModel, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult frmNewEMS_Deactivate(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmNewEMS_Deactivate(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintPayReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintPayReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuClose_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEmpInfo_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEmpInfo_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuImmune_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuImmune_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSeniorInq_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSeniorInq_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_transfer_req_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_transfer_req_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPMCerts_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPMCerts_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPPE_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPPE_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndSchedule_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndSchedule_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion1_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion2_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewBatt3_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewBatt3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion3_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattalion4_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattalion4_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMSDaily_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMSDaily_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazmat_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazmat_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarine_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarine_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattStaff_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatch_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatch_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_watch_duty_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_watch_duty_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_Vacation_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_Vacation_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMVacationSched_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_HZMVacationSched_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_HZMVacationSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewBatt1_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewBatt1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewBatt2_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewBatt2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAssign_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRoster_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRoster_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuFRoster_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuFRoster_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_DDGroups_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_DDGroups_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuProlist_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuProlist_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSenior_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSenior_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBenefit_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBenefit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_emp_facility_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_emp_facility_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndivPayrollSO_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndivPayrollSO_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard2_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu181_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu181_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu182_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu183_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu183_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuEMSPay_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuEMSPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuHazPay_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuHazPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuMarPay_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuMarPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuBattPay_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuBattPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDisPay_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDisPay_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndTimeCard_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndTimeCard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndYearSched_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndYearSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyStaff_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyStaff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuOvertime_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuOvertime_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_sa_report_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_sa_report_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuShiftCal_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuShiftCal_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTransfer_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTransfer_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDailyLeave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDailyLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAnnual_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAnnual_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_dailysickleave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_dailysickleave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndLeave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_sick_usage_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_sick_usage_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMLeave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuDispatchLeave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuDispatchLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTimeCard_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTimeCard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuIndAnnualPayroll_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuIndAnnualPayroll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnupersonnelsignoff_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnupersonnelsignoff_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_QuarterlyMinimumDrill_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_QuarterlyMinimumDrill_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_FCCMinDrills_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_FCCMinDrills_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_ReadingAssign_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_ReadingAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_OTEPReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_OTEPReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMRecertReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMRecertReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_PMBaseStaReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_PMBaseStaReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_trainingtracker_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_trainingtracker_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndTrainReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndTrainReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndPMRecert_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndPMRecert_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuALSProc_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuALSProc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainQuery_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainQuery_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_TrainingQuerynew_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_TrainingQuerynew_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuCascade_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuCascade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPrintScreen_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPrintScreen_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuAbout_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuAbout_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_HelpPrntScrn_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_HelpPrntScrn_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_timecodes_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_timecodes_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payrolllegend_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payrolllegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_legend_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_legend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_IndLegend_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_IndLegend_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_payup_calc_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_payup_calc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrainCodeHelp_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrainCodeHelp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuNewSched_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuNewSched_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuLeave_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayUp_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayUp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuPayDown_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuPayDown_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuKOT_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuKOT_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuTrade_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuTrade_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuRemove_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuRemove_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo181_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo181_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo182_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo182_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuSendTo183_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuSendTo183_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnu_viewtimecard_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnu_viewtimecard_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult mnuViewDetail_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.mnuViewDetail_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnuNewEMSPopup_Opening(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnuNewEMSPopup_Opening(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Ctx_mnuNewEMSPopup_Closing(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Ctx_mnuNewEMSPopup_Closing(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calWeek_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calWeek_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragDrop(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult picTrash_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId)
		{
			logic.ViewModel = viewFromClient;
			logic.picTrash_DragOver(null, logic.ViewModel.picTrash.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult pnSelected_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.pnSelected_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSelectName_SelectionChangeCommitted(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSelectName_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPayroll_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPayroll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReport_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1am_DragDrop(logic.ViewModel.lbPos1am[index], logic.ViewModel._lbPos1am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1am_MouseDown(logic.ViewModel.lbPos1am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1am_DragOver(null, logic.ViewModel._lbPos1am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCSRCalc_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCSRCalc_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1pm_DragDrop(logic.ViewModel.lbPos1pm[index], logic.ViewModel._lbPos1pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1pm_MouseDown(logic.ViewModel.lbPos1pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos1pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos1pm_DragOver(null, logic.ViewModel._lbPos1pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos1pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos1pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2am_DragDrop(logic.ViewModel.lbPos2am[index], logic.ViewModel._lbPos2am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2am_MouseDown(logic.ViewModel.lbPos2am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2am_DragOver(null, logic.ViewModel._lbPos2am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2pm_DragDrop(logic.ViewModel.lbPos2pm[index], logic.ViewModel._lbPos2pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2pm_MouseDown(logic.ViewModel.lbPos2pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos2pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos2pm_DragOver(null, logic.ViewModel._lbPos2pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos2pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos2pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboLeave_SelectionChangeCommitted(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboLeave_SelectionChangeCommitted(logic.ViewModel.cboLeave[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboAvailable_SelectionChangeCommitted(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cboAvailable_SelectionChangeCommitted(logic.ViewModel.cboAvailable[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3am_DragDrop(logic.ViewModel.lbPos3am[index], logic.ViewModel._lbPos3am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3am_MouseDown(logic.ViewModel.lbPos3am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3am_DragOver(null, logic.ViewModel._lbPos3am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3pm_DragDrop(logic.ViewModel.lbPos3pm[index], logic.ViewModel._lbPos3pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3pm_MouseDown(logic.ViewModel.lbPos3pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos3pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos3pm_DragOver(null, logic.ViewModel._lbPos3pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos3pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos3pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4am_DragDrop(logic.ViewModel.lbPos4am[index], logic.ViewModel._lbPos4am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4am_MouseDown(logic.ViewModel.lbPos4am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4am_DragOver(null, logic.ViewModel._lbPos4am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4pm_DragDrop(logic.ViewModel.lbPos4pm[index], logic.ViewModel._lbPos4pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4pm_MouseDown(logic.ViewModel.lbPos4pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos4pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos4pm_DragOver(null, logic.ViewModel._lbPos4pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos4pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos4pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5am_DragDrop(logic.ViewModel.lbPos5am[index], logic.ViewModel._lbPos5am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5am_MouseDown(logic.ViewModel.lbPos5am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5am_DragOver(null, logic.ViewModel._lbPos5am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5pm_DragDrop(logic.ViewModel.lbPos5pm[index], logic.ViewModel._lbPos5pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5pm_MouseDown(logic.ViewModel.lbPos5pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos5pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos5pm_DragOver(null, logic.ViewModel._lbPos5pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos5pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos5pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6am_DragDrop(logic.ViewModel.lbPos6am[index], logic.ViewModel._lbPos6am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6am_MouseDown(logic.ViewModel.lbPos6am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6am_DragOver(null, logic.ViewModel._lbPos6am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6pm_DragDrop(logic.ViewModel.lbPos6pm[index], logic.ViewModel._lbPos6pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6pm_MouseDown(logic.ViewModel.lbPos6pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos6pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos6pm_DragOver(null, logic.ViewModel._lbPos6pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos6pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos6pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7am_DragDrop(logic.ViewModel.lbPos7am[index], logic.ViewModel._lbPos7am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7am_MouseDown(logic.ViewModel.lbPos7am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7am_DragOver(null, logic.ViewModel._lbPos7am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7pm_DragDrop(logic.ViewModel.lbPos7pm[index], logic.ViewModel._lbPos7pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7pm_MouseDown(logic.ViewModel.lbPos7pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos7pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos7pm_DragOver(null, logic.ViewModel._lbPos7pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos7pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos7pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8am_DragDrop(logic.ViewModel.lbPos8am[index], logic.ViewModel._lbPos8am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8am_MouseDown(logic.ViewModel.lbPos8am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8am_DragOver(null, logic.ViewModel._lbPos8am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8pm_DragDrop(logic.ViewModel.lbPos8pm[index], logic.ViewModel._lbPos8pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8pm_MouseDown(logic.ViewModel.lbPos8pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos8pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos8pm_DragOver(null, logic.ViewModel._lbPos8pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos8pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos8pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9am_DragDrop(logic.ViewModel.lbPos9am[index], logic.ViewModel._lbPos9am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9am_MouseDown(logic.ViewModel.lbPos9am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9am_DragOver(null, logic.ViewModel._lbPos9am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9pm_DragDrop(logic.ViewModel.lbPos9pm[index], logic.ViewModel._lbPos9pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9pm_MouseDown(logic.ViewModel.lbPos9pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos9pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos9pm_DragOver(null, logic.ViewModel._lbPos9pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos9pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos9pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10am_DragDrop(logic.ViewModel.lbPos10am[index], logic.ViewModel._lbPos10am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10am_MouseDown(logic.ViewModel.lbPos10am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10am_DragOver(null, logic.ViewModel._lbPos10am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10pm_DragDrop(logic.ViewModel.lbPos10pm[index], logic.ViewModel._lbPos10pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10pm_MouseDown(logic.ViewModel.lbPos10pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos10pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos10pm_DragOver(null, logic.ViewModel._lbPos10pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos10pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos10pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11am_DragDrop(logic.ViewModel.lbPos11am[index], logic.ViewModel._lbPos11am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11am_MouseDown(logic.ViewModel.lbPos11am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11am_DragOver(null, logic.ViewModel._lbPos11am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11pm_DragDrop(logic.ViewModel.lbPos11pm[index], logic.ViewModel._lbPos11pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11pm_MouseDown(logic.ViewModel.lbPos11pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos11pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos11pm_DragOver(null, logic.ViewModel._lbPos11pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos11pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos11pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12am_DragDrop(logic.ViewModel.lbPos12am[index], logic.ViewModel._lbPos12am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12am_MouseDown(logic.ViewModel.lbPos12am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12am_DragOver(null, logic.ViewModel._lbPos12am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12pm_DragDrop(logic.ViewModel.lbPos12pm[index], logic.ViewModel._lbPos12pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12pm_MouseDown(logic.ViewModel.lbPos12pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos12pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos12pm_DragOver(null, logic.ViewModel._lbPos12pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos12pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos12pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13am_DragDrop(logic.ViewModel.lbPos13am[index], logic.ViewModel._lbPos13am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13am_MouseDown(logic.ViewModel.lbPos13am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13am_DragOver(null, logic.ViewModel._lbPos13am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13pm_DragDrop(logic.ViewModel.lbPos13pm[index], logic.ViewModel._lbPos13pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13pm_MouseDown(logic.ViewModel.lbPos13pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos13pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos13pm_DragOver(null, logic.ViewModel._lbPos13pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos13pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos13pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14am_DragDrop(logic.ViewModel.lbPos14am[index], logic.ViewModel._lbPos14am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14am_MouseDown(logic.ViewModel.lbPos14am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14am_DragOver(null, logic.ViewModel._lbPos14am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14pm_DragDrop(logic.ViewModel.lbPos14pm[index], logic.ViewModel._lbPos14pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14pm_MouseDown(logic.ViewModel.lbPos14pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos14pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos14pm_DragOver(null, logic.ViewModel._lbPos14pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos14pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos14pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15am_DragDrop(logic.ViewModel.lbPos15am[index], logic.ViewModel._lbPos15am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15am_MouseDown(logic.ViewModel.lbPos15am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15am_DragOver(null, logic.ViewModel._lbPos15am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15pm_DragDrop(logic.ViewModel.lbPos15pm[index], logic.ViewModel._lbPos15pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15pm_MouseDown(logic.ViewModel.lbPos15pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos15pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos15pm_DragOver(null, logic.ViewModel._lbPos15pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos15pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos15pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16am_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16am_DragDrop(logic.ViewModel.lbPos16am[index], logic.ViewModel._lbPos16am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16am_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16am_MouseDown(logic.ViewModel.lbPos16am[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16am_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16am_DragOver(null, logic.ViewModel._lbPos16am_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16am_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16am_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16pm_DragDrop(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16pm_DragDrop(logic.ViewModel.lbPos16pm[index], logic.ViewModel._lbPos16pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16pm_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16pm_MouseDown(logic.ViewModel.lbPos16pm[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_0_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_0_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lbPos16pm_DragOver(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, object objectForId, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.lbPos16pm_DragOver(null, logic.ViewModel._lbPos16pm_0.createDragEventArgs(objectForId));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_1_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_1_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_2_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_2_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_3_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_3_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_4_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_4_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_5_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_5_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult _lbPos16pm_6_MouseDown(PTSProject.ViewModels.frmNewEMSViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic._lbPos16pm_6_MouseDown(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmNewEMS logic { get; set; }

	}

}