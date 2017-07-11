using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmWeekly))]
	public class frmWeeklyViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.mnuPrintPayReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPrintPayReport
			// 
			this.mnuPrintPayReport.Available = true;
			this.mnuPrintPayReport.Enabled = true;
			this.mnuPrintPayReport.Text = "&Print Pay Period Report";
			this.mnuClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuClose
			// 
			this.mnuClose.Available = true;
			this.mnuClose.Enabled = true;
			this.mnuClose.Text = "&Close Weekly Scheduler";
			this.mnuSystem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSystem
			// 
			this.mnuSystem.Available = true;
			this.mnuSystem.Enabled = true;
			this.mnuSystem.Text = "&System";
			this.mnuEmpInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuEmpInfo
			// 
			this.mnuEmpInfo.Available = true;
			this.mnuEmpInfo.Enabled = true;
			this.mnuEmpInfo.Text = "&Update Employee Information";
			this.mnuSeniorInq = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSeniorInq
			// 
			this.mnuSeniorInq.Available = true;
			this.mnuSeniorInq.Enabled = true;
			this.mnuSeniorInq.Text = "&Seniority Ranking Inquiry";
			this.mnuImmune = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuImmune
			// 
			this.mnuImmune.Available = true;
			this.mnuImmune.Enabled = true;
			this.mnuImmune.Text = "Manage Employee Immunizations";
			this.mnu_transfer_req = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_transfer_req
			// 
			this.mnu_transfer_req.Available = true;
			this.mnu_transfer_req.Enabled = true;
			this.mnu_transfer_req.Text = "Manage Requests For Transfer";
			this.mnuPMCerts = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPMCerts
			// 
			this.mnuPMCerts.Available = true;
			this.mnuPMCerts.Enabled = true;
			this.mnuPMCerts.Text = "Manage Paramedic Certifications";
			this.mnuPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPPE
			// 
			this.mnuPPE.Available = true;
			this.mnuPPE.Enabled = true;
			this.mnuPPE.Text = "Manage WDL and PPE Info";
			this.mnupersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnupersonnel
			// 
			this.mnupersonnel.Available = true;
			this.mnupersonnel.Enabled = true;
			this.mnupersonnel.Text = "&Personnel";
			this.mnuIndSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndSchedule
			// 
			this.mnuIndSchedule.Available = true;
			this.mnuIndSchedule.Enabled = true;
			this.mnuIndSchedule.Text = "&Individual Scheduler";
			this.mnuBattalion1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattalion1
			// 
			this.mnuBattalion1.Available = true;
			this.mnuBattalion1.Enabled = true;
			this.mnuBattalion1.Text = "Battalion &1 Scheduler";
			this.mnuBattalion2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattalion2
			// 
			this.mnuBattalion2.Available = true;
			this.mnuBattalion2.Enabled = true;
			this.mnuBattalion2.Text = "Battalion &2 Scheduler";
			this.mnuNewBatt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuNewBatt3
			// 
			this.mnuNewBatt3.Available = true;
			this.mnuNewBatt3.Enabled = true;
			this.mnuNewBatt3.Text = "Battalion &3 Scheduler";
			this.mnuBattalion3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattalion3
			// 
			this.mnuBattalion3.Available = true;
			this.mnuBattalion3.Enabled = true;
			this.mnuBattalion3.Text = "Batt &4 Sched (Special Unit)";
			this.mnuBattalion4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattalion4
			// 
			this.mnuBattalion4.Available = true;
			this.mnuBattalion4.Enabled = true;
			this.mnuBattalion4.Text = "Batt &5 Sched (Reserve Unit)";
			this.mnuEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuEMS
			// 
			this.mnuEMS.Available = true;
			this.mnuEMS.Enabled = true;
			this.mnuEMS.Text = "&EMS Scheduler";
			this.mnuEMSDaily = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuEMSDaily
			// 
			this.mnuEMSDaily.Available = true;
			this.mnuEMSDaily.Enabled = true;
			this.mnuEMSDaily.Text = "EMS Daily Scheduler";
			this.mnuHazmat = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuHazmat
			// 
			this.mnuHazmat.Available = true;
			this.mnuHazmat.Enabled = true;
			this.mnuHazmat.Text = "&Hazmat Schedule";
			this.mnuBattStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattStaff
			// 
			this.mnuBattStaff.Available = true;
			this.mnuBattStaff.Enabled = true;
			this.mnuBattStaff.Text = "Battalion &Staff Schedule";
			this.mnuDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuDispatch
			// 
			this.mnuDispatch.Available = true;
			this.mnuDispatch.Enabled = true;
			this.mnuDispatch.Text = "&Dispatch Schedule";
			this.mnu_watch_duty = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_watch_duty
			// 
			this.mnu_watch_duty.Available = true;
			this.mnu_watch_duty.Enabled = true;
			this.mnu_watch_duty.Text = "Assign Watch Duty";
			this.mnu_Vacation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_Vacation
			// 
			this.mnu_Vacation.Available = true;
			this.mnu_Vacation.Enabled = true;
			this.mnu_Vacation.Text = "Vacation Scheduler";
			this.mnu_PMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_PMVacationSched
			// 
			this.mnu_PMVacationSched.Available = true;
			this.mnu_PMVacationSched.Enabled = true;
			this.mnu_PMVacationSched.Text = "Paramedic Vacation Scheduler";
			this.mnu_HZMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_HZMVacationSched
			// 
			this.mnu_HZMVacationSched.Available = true;
			this.mnu_HZMVacationSched.Enabled = true;
			this.mnu_HZMVacationSched.Text = "Hazmat Vacation Scheduler";
			this.mnuNewBatt1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuNewBatt1
			// 
			this.mnuNewBatt1.Available = true;
			this.mnuNewBatt1.Enabled = true;
			this.mnuNewBatt1.Text = "New Battalion 1 Scheduler";
			this.mnuNewBatt2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuNewBatt2
			// 
			this.mnuNewBatt2.Available = true;
			this.mnuNewBatt2.Enabled = true;
			this.mnuNewBatt2.Text = "New Battalion 2 Scheduler";
			this.mnu_old = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_old
			// 
			this.mnu_old.Available = false;
			this.mnu_old.Enabled = true;
			this.mnu_old.Text = "Hidden Battalion Schedulers";
			this.mnuSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSchedule
			// 
			this.mnuSchedule.Available = true;
			this.mnuSchedule.Enabled = true;
			this.mnuSchedule.Text = "Sche&duling";
			this.mnuAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuAssign
			// 
			this.mnuAssign.Available = true;
			this.mnuAssign.Enabled = true;
			this.mnuAssign.Text = "&Assignments";
			this.mnuRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuRoster
			// 
			this.mnuRoster.Available = true;
			this.mnuRoster.Enabled = true;
			this.mnuRoster.Text = "&Roster";
			this.mnuFRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuFRoster
			// 
			this.mnuFRoster.Available = true;
			this.mnuFRoster.Enabled = true;
			this.mnuFRoster.Text = "Filtered Roster";
			this.mnu_DDGroups = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_DDGroups
			// 
			this.mnu_DDGroups.Available = true;
			this.mnu_DDGroups.Enabled = true;
			this.mnu_DDGroups.Text = "&Debit Day Groups";
			this.mnuProlist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuProlist
			// 
			this.mnuProlist.Available = true;
			this.mnuProlist.Enabled = true;
			this.mnuProlist.Text = "&Promotion Lists";
			this.mnuSenior = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSenior
			// 
			this.mnuSenior.Available = true;
			this.mnuSenior.Enabled = true;
			this.mnuSenior.Text = "&Serniority Ranking Lists";
			this.mnuBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBenefit
			// 
			this.mnuBenefit.Available = true;
			this.mnuBenefit.Enabled = true;
			this.mnuBenefit.Text = "CF&1 Benefit Listing";
			this.mnu_emp_facility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_emp_facility
			// 
			this.mnu_emp_facility.Available = true;
			this.mnu_emp_facility.Enabled = true;
			this.mnu_emp_facility.Text = "Employee List by Facility";
			this.MnuAuditDDHOL = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// MnuAuditDDHOL
			// 
			this.MnuAuditDDHOL.Available = true;
			this.MnuAuditDDHOL.Enabled = true;
			this.MnuAuditDDHOL.Text = "Debit Day / Holiday Audit";
			this.mnu_IndivPayrollSO = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_IndivPayrollSO
			// 
			this.mnu_IndivPayrollSO.Available = true;
			this.mnu_IndivPayrollSO.Enabled = true;
			this.mnu_IndivPayrollSO.Text = "Individual Payroll SignOff ";
			this.mnuIndTimeCard2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndTimeCard2
			// 
			this.mnuIndTimeCard2.Available = true;
			this.mnuIndTimeCard2.Enabled = true;
			this.mnuIndTimeCard2.Text = "Individual Time Cards";
			this.mnuperson = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuperson
			// 
			this.mnuperson.Available = true;
			this.mnuperson.Enabled = true;
			this.mnuperson.Text = "&Personnel";
			this.mnu181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu181
			// 
			this.mnu181.Available = true;
			this.mnu181.Enabled = true;
			this.mnu181.Text = "Battalion &1";
			this.mnu182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu182
			// 
			this.mnu182.Available = true;
			this.mnu182.Enabled = true;
			this.mnu182.Text = "Battalion &2";
			this.mnu183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu183
			// 
			this.mnu183.Available = true;
			this.mnu183.Enabled = true;
			this.mnu183.Text = "Battalion &3";
			this.mnuBDWork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBDWork
			// 
			this.mnuBDWork.Available = true;
			this.mnuBDWork.Enabled = true;
			this.mnuBDWork.Text = "&Battalion Time Card Worksheets";
			this.mnuEMSPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuEMSPay
			// 
			this.mnuEMSPay.Available = true;
			this.mnuEMSPay.Enabled = true;
			this.mnuEMSPay.Text = "&EMS";
			this.mnuHazPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuHazPay
			// 
			this.mnuHazPay.Available = true;
			this.mnuHazPay.Enabled = true;
			this.mnuHazPay.Text = "&HazMat";
			this.mnuMarPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuMarPay
			// 
			this.mnuMarPay.Available = true;
			this.mnuMarPay.Enabled = true;
			this.mnuMarPay.Text = "&Marine";
			this.mnuBattPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuBattPay
			// 
			this.mnuBattPay.Available = true;
			this.mnuBattPay.Enabled = true;
			this.mnuBattPay.Text = "&Battalion Staff";
			this.mnuDisPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuDisPay
			// 
			this.mnuDisPay.Available = true;
			this.mnuDisPay.Enabled = true;
			this.mnuDisPay.Text = "&Dispatch";
			this.mnuPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPayroll
			// 
			this.mnuPayroll.Available = true;
			this.mnuPayroll.Enabled = true;
			this.mnuPayroll.Text = "&Payroll Worksheets";
			this.mnuIndTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndTimeCard
			// 
			this.mnuIndTimeCard.Available = true;
			this.mnuIndTimeCard.Enabled = true;
			this.mnuIndTimeCard.Text = "&Individual Time Cards";
			this.mnuIndYearSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndYearSched
			// 
			this.mnuIndYearSched.Available = true;
			this.mnuIndYearSched.Enabled = true;
			this.mnuIndYearSched.Text = "Individual &Yearly Schedule";
			this.mnuDailyStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuDailyStaff
			// 
			this.mnuDailyStaff.Available = true;
			this.mnuDailyStaff.Enabled = true;
			this.mnuDailyStaff.Text = "&Daily Staffing Report";
			this.mnuOvertime = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuOvertime
			// 
			this.mnuOvertime.Available = true;
			this.mnuOvertime.Enabled = true;
			this.mnuOvertime.Text = "&Overtime Detail Report";
			this.mnuExtraOff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuExtraOff
			// 
			this.mnuExtraOff.Available = true;
			this.mnuExtraOff.Enabled = true;
			this.mnuExtraOff.Text = "Extra-Unplanned Days Off Report";
			this.mnu_sa_report = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_sa_report
			// 
			this.mnu_sa_report.Available = true;
			this.mnu_sa_report.Enabled = true;
			this.mnu_sa_report.Text = "Special Assignment Yearly Report";
			this.mnuShiftCal = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuShiftCal
			// 
			this.mnuShiftCal.Available = true;
			this.mnuShiftCal.Enabled = true;
			this.mnuShiftCal.Text = "Shift &Calendar";
			this.mnuTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTransfer
			// 
			this.mnuTransfer.Available = true;
			this.mnuTransfer.Enabled = true;
			this.mnuTransfer.Text = "&Transfer Schedule";
			this.mnuSchedul = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSchedul
			// 
			this.mnuSchedul.Available = true;
			this.mnuSchedul.Enabled = true;
			this.mnuSchedul.Text = "&Schedule";
			this.mnuDailyLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuDailyLeave
			// 
			this.mnuDailyLeave.Available = true;
			this.mnuDailyLeave.Enabled = true;
			this.mnuDailyLeave.Text = "&Daily Leave";
			this.mnuAnnual = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuAnnual
			// 
			this.mnuAnnual.Available = true;
			this.mnuAnnual.Enabled = true;
			this.mnuAnnual.Text = "&Annual Leave";
			this.mnu_dailysickleave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_dailysickleave
			// 
			this.mnu_dailysickleave.Available = true;
			this.mnu_dailysickleave.Enabled = true;
			this.mnu_dailysickleave.Text = "Daily Sick Leave";
			this.mnuIndLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndLeave
			// 
			this.mnuIndLeave.Available = true;
			this.mnuIndLeave.Enabled = true;
			this.mnuIndLeave.Text = "&Individual Leave";
			this.mnu_sick_usage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_sick_usage
			// 
			this.mnu_sick_usage.Available = true;
			this.mnu_sick_usage.Enabled = true;
			this.mnu_sick_usage.Text = "Sick Leave Usage Report";
			this.mnu_PMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_PMLeave
			// 
			this.mnu_PMLeave.Available = true;
			this.mnu_PMLeave.Enabled = true;
			this.mnu_PMLeave.Text = "Paramedic Leave Report";
			this.mnuDispatchLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuDispatchLeave
			// 
			this.mnuDispatchLeave.Available = true;
			this.mnuDispatchLeave.Enabled = true;
			this.mnuDispatchLeave.Text = "Dispatch Leave Report";
			this.mnu_HZMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_HZMLeave
			// 
			this.mnu_HZMLeave.Available = true;
			this.mnu_HZMLeave.Enabled = true;
			this.mnu_HZMLeave.Text = "Hazmat Leave Report";
			this.mnuLeaveReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuLeaveReports
			// 
			this.mnuLeaveReports.Available = true;
			this.mnuLeaveReports.Enabled = true;
			this.mnuLeaveReports.Text = "&Leave";
			this.mnutimecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnutimecard
			// 
			this.mnutimecard.Available = true;
			this.mnutimecard.Enabled = true;
			this.mnutimecard.Text = "Individual Time Cards";
			this.mnuIndAnnualPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuIndAnnualPayroll
			// 
			this.mnuIndAnnualPayroll.Available = true;
			this.mnuIndAnnualPayroll.Enabled = true;
			this.mnuIndAnnualPayroll.Text = "Individual Payroll Report";
			this.mnupersonnelsignoff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnupersonnelsignoff
			// 
			this.mnupersonnelsignoff.Available = true;
			this.mnupersonnelsignoff.Enabled = true;
			this.mnupersonnelsignoff.Text = "Payroll Sign Off";
			this.mnuPayrollReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPayrollReports
			// 
			this.mnuPayrollReports.Available = true;
			this.mnuPayrollReports.Enabled = true;
			this.mnuPayrollReports.Text = "Payroll";
			this.mnu_QuarterlyMinimumDrill = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_QuarterlyMinimumDrill
			// 
			this.mnu_QuarterlyMinimumDrill.Available = true;
			this.mnu_QuarterlyMinimumDrill.Enabled = true;
			this.mnu_QuarterlyMinimumDrill.Text = "Quarterly Minimum Standards Drills";
			this.mnu_FCCMinDrills = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_FCCMinDrills
			// 
			this.mnu_FCCMinDrills.Available = true;
			this.mnu_FCCMinDrills.Enabled = true;
			this.mnu_FCCMinDrills.Text = "FCC Min Standards Drills";
			this.mnu_ReadingAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_ReadingAssign
			// 
			this.mnu_ReadingAssign.Available = true;
			this.mnu_ReadingAssign.Enabled = true;
			this.mnu_ReadingAssign.Text = "Required Reading Assignments";
			this.mnu_OTEPReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_OTEPReport
			// 
			this.mnu_OTEPReport.Available = true;
			this.mnu_OTEPReport.Enabled = true;
			this.mnu_OTEPReport.Text = "Annual OTEP Training Report";
			this.mnu_PMRecertReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_PMRecertReport
			// 
			this.mnu_PMRecertReport.Available = true;
			this.mnu_PMRecertReport.Enabled = true;
			this.mnu_PMRecertReport.Text = "Paramedic Recertification Report";
			this.mnu_PMBaseStaReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_PMBaseStaReport
			// 
			this.mnu_PMBaseStaReport.Available = true;
			this.mnu_PMBaseStaReport.Enabled = true;
			this.mnu_PMBaseStaReport.Text = "Paramedic Base Station Report";
			this.mnu_TrainingReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_TrainingReports
			// 
			this.mnu_TrainingReports.Available = true;
			this.mnu_TrainingReports.Enabled = true;
			this.mnu_TrainingReports.Text = "Training";
			this.mnuReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuReports
			// 
			this.mnuReports.Available = true;
			this.mnuReports.Enabled = true;
			this.mnuReports.Text = "&Reports";
			this.mnu_trainingtracker = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_trainingtracker
			// 
			this.mnu_trainingtracker.Available = true;
			this.mnu_trainingtracker.Enabled = true;
			this.mnu_trainingtracker.Text = "Field Training Tracker";
			this.mnu_IndTrainReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_IndTrainReport
			// 
			this.mnu_IndTrainReport.Available = true;
			this.mnu_IndTrainReport.Enabled = true;
			this.mnu_IndTrainReport.Text = "Individual Training Report";
			this.mnu_IndPMRecert = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_IndPMRecert
			// 
			this.mnu_IndPMRecert.Available = true;
			this.mnu_IndPMRecert.Enabled = true;
			this.mnu_IndPMRecert.Text = "Individual PM Recert Report";
			this.mnuALSProc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuALSProc
			// 
			this.mnuALSProc.Available = true;
			this.mnuALSProc.Enabled = true;
			this.mnuALSProc.Text = "Individual ALS Procedures (IRS)";
			this.mnuTrnReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTrnReports
			// 
			this.mnuTrnReports.Available = true;
			this.mnuTrnReports.Enabled = true;
			this.mnuTrnReports.Text = "Training Reports";
			this.mnuTrainQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTrainQuery
			// 
			this.mnuTrainQuery.Available = true;
			this.mnuTrainQuery.Enabled = true;
			this.mnuTrainQuery.Text = "&Training Class Attendance Query";
			this.mnu_TrainingQuerynew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_TrainingQuerynew
			// 
			this.mnu_TrainingQuerynew.Available = true;
			this.mnu_TrainingQuerynew.Enabled = true;
			this.mnu_TrainingQuerynew.Text = "Training Query Tool (new)";
			this.mnu_Queries = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_Queries
			// 
			this.mnu_Queries.Available = true;
			this.mnu_Queries.Enabled = true;
			this.mnu_Queries.Text = "Training Class Queries";
			this.mnuTraining = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTraining
			// 
			this.mnuTraining.Available = true;
			this.mnuTraining.Enabled = true;
			this.mnuTraining.Text = "&Training";
			this.mnuCascade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuCascade
			// 
			this.mnuCascade.Available = true;
			this.mnuCascade.Enabled = true;
			this.mnuCascade.Text = "&Cascade Windows";
			this.mnuPrintScreen = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPrintScreen
			// 
			this.mnuPrintScreen.Available = true;
			this.mnuPrintScreen.Enabled = true;
			this.mnuPrintScreen.Text = "Print Screen";
			this.mnuWindow = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuWindow
			// 
			this.mnuWindow.Available = true;
			this.mnuWindow.Enabled = true;
			this.mnuWindow.Text = "&Window";
			this.mnuContents = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuContents
			// 
			this.mnuContents.Available = true;
			this.mnuContents.Enabled = false;
			this.mnuContents.Text = "&Contents";
			this.mnuAbout = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuAbout
			// 
			this.mnuAbout.Available = true;
			this.mnuAbout.Enabled = true;
			this.mnuAbout.Text = "&About PTS";
			this.mnu_HelpPrntScrn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_HelpPrntScrn
			// 
			this.mnu_HelpPrntScrn.Available = true;
			this.mnu_HelpPrntScrn.Enabled = true;
			this.mnu_HelpPrntScrn.Text = "How to Print Screen";
			this.mnu_timecodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_timecodes
			// 
			this.mnu_timecodes.Available = true;
			this.mnu_timecodes.Enabled = true;
			this.mnu_timecodes.Text = "Payroll Time Card codes";
			this.mnu_payrolllegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_payrolllegend
			// 
			this.mnu_payrolllegend.Available = true;
			this.mnu_payrolllegend.Enabled = true;
			this.mnu_payrolllegend.Text = "Payroll Timecard Legend";
			this.mnu_legend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_legend
			// 
			this.mnu_legend.Available = true;
			this.mnu_legend.Enabled = true;
			this.mnu_legend.Text = "Battalion Scheduler Legend";
			this.mnu_IndLegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_IndLegend
			// 
			this.mnu_IndLegend.Available = true;
			this.mnu_IndLegend.Enabled = true;
			this.mnu_IndLegend.Text = "Individual Scheduler Legend";
			this.mnu_payup_calc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_payup_calc
			// 
			this.mnu_payup_calc.Available = true;
			this.mnu_payup_calc.Enabled = true;
			this.mnu_payup_calc.Text = "Employee Pay Up / Step Calculator";
			this.mnuTrainCodeHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTrainCodeHelp
			// 
			this.mnuTrainCodeHelp.Available = true;
			this.mnuTrainCodeHelp.Enabled = true;
			this.mnuTrainCodeHelp.Text = "Training Codes";
			this.mnuHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuHelp
			// 
			this.mnuHelp.Available = true;
			this.mnuHelp.Enabled = true;
			this.mnuHelp.Text = "&Help";
			this.mnuLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuLeave
			// 
			this.mnuLeave.Available = true;
			this.mnuLeave.Enabled = true;
			this.mnuLeave.Text = "Schedule Leave";
			this.mnuPayUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPayUp
			// 
			this.mnuPayUp.Available = true;
			this.mnuPayUp.Enabled = true;
			this.mnuPayUp.Text = "Upgrade Pay";
			this.mnuPayDown = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuPayDown
			// 
			this.mnuPayDown.Available = true;
			this.mnuPayDown.Enabled = true;
			this.mnuPayDown.Text = "Remove Pay Upgrade";
			this.mnuKOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuKOT
			// 
			this.mnuKOT.Available = true;
			this.mnuKOT.Enabled = true;
			this.mnuKOT.Text = "Change KOT";
			this.mnuTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuTrade
			// 
			this.mnuTrade.Available = true;
			this.mnuTrade.Enabled = false;
			this.mnuTrade.Text = "Enact a Trade";
			this.mnuRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuRemove
			// 
			this.mnuRemove.Available = true;
			this.mnuRemove.Enabled = true;
			this.mnuRemove.Text = "Remove From Schedule";
			this.mnuSendTo181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSendTo181
			// 
			this.mnuSendTo181.Available = true;
			this.mnuSendTo181.Enabled = true;
			this.mnuSendTo181.Text = "Send to Battalion 1";
			this.mnuSendTo182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuSendTo182
			// 
			this.mnuSendTo182.Available = true;
			this.mnuSendTo182.Enabled = true;
			this.mnuSendTo182.Text = "Send to Battalion 2";
			this.mnuReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuReport
			// 
			this.mnuReport.Available = true;
			this.mnuReport.Enabled = true;
			this.mnuReport.Text = "View This Individuals Leave Report";
			this.mnu_viewtimecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnu_viewtimecard
			// 
			this.mnu_viewtimecard.Available = true;
			this.mnu_viewtimecard.Enabled = true;
			this.mnu_viewtimecard.Text = "View Time Card";
			this.mnuViewDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuViewDetail
			// 
			this.mnuViewDetail.Available = true;
			this.mnuViewDetail.Enabled = true;
			this.mnuViewDetail.Text = "View Schedule Detail";
			this.mnuWeeklyPopUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuWeeklyPopUp
			// 
			this.mnuWeeklyPopUp.Available = false;
			this.mnuWeeklyPopUp.Enabled = true;
			this.mnuWeeklyPopUp.Text = "Update Schedule Info";
			this.cboFullList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFullList
			// 
			this.cboFullList.AllowDrop = true;
			this.cboFullList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFullList.Enabled = true;
			this.cboFullList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFullList.Name = "cboFullList";
			this.cboFullList.TabIndex = 230;
			this.cboFullList.Text = "cboFullList";
			this.cboFullList.Visible = true;
			this.picTrash = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picTrash
			// 
			this.picTrash.AllowDrop = true;
			this.picTrash.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.picTrash.Enabled = true;
			this.picTrash.Name = "picTrash";
			this.picTrash.Visible = true;
			this.cboSelectName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSelectName
			// 
			this.cboSelectName.AllowDrop = true;
			this.cboSelectName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSelectName.Enabled = true;
			this.cboSelectName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSelectName.Name = "cboSelectName";
			this.cboSelectName.TabIndex = 1;
			this.cboSelectName.Text = "cboSelectName";
			this.cboSelectName.Visible = true;
			this._lstLeave_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this._lstLeave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this.calWeek = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			// 
			// calWeek
			// 
			this.calWeek.AllowDrop = true;
			this.calWeek.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calWeek.MinDate = System.DateTime.Parse("1996/1/1");
			this.calWeek.Name = "calWeek";
			this.calWeek.TabIndex = 0;
			this.lbStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStaff
			// 
			this.lbStaff.AllowDrop = true;
			this.lbStaff.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStaff.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbStaff.Name = "lbStaff";
			this.lbStaff.TabIndex = 233;
			this.lbStaff.Text = "Battalion";
			this.lbAllStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllStaff
			// 
			this.lbAllStaff.AllowDrop = true;
			this.lbAllStaff.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllStaff.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbAllStaff.Name = "lbAllStaff";
			this.lbAllStaff.TabIndex = 231;
			this.lbAllStaff.Text = "All Staff";
			this._shpP10pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP10am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP9am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP8am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP7am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP6am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP5am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP4am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP3am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP2am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1pm_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpP1am_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPos7am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 220;
			this.Label4.Text = "On Leave";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.Visible = true;
			this._lbShiftArray_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbShiftArray_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAMPM_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos10am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos9am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos8am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos7pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos6am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos5am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos4am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos3am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos2am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1pm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPos1am_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbWeekDay_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 45;
			this.Label3.Text = "Position";
			this._lbPositionArray_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionArray_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 24;
			this.Label2.Text = "Unit";
			this._lbUnitArray_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnitArray_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Select Week";
			this.lbLocked = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocked
			// 
			this.lbLocked.AllowDrop = true;
			this.lbLocked.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocked.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocked.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbLocked.Name = "lbLocked";
			this.lbLocked.TabIndex = 234;
			this.lbLocked.Text = "Schedule Locked";
			this.lbLocked.Visible = false;
			this.pnSelected = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// pnSelected
			// 
			this.pnSelected.AllowDrop = true;
			this.pnSelected.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.pnSelected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.pnSelected.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.pnSelected.Name = "pnSelected";
			this.pnSelected.TabIndex = 221;
			this.pnSelected.Visible = false;
			this.Ctx_mnuWeeklyPopUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripViewModel>();
			this.cmdPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPayroll
			// 
			this.cmdPayroll.AllowDrop = true;
			this.cmdPayroll.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPayroll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdPayroll.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPayroll.Name = "cmdPayroll";
			this.cmdPayroll.TabIndex = 235;
			this.cmdPayroll.Text = "Dispatch Payroll";
			this.cmdPayroll.Visible = false;
			this.cmdReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReport
			// 
			this.cmdReport.AllowDrop = true;
			this.cmdReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReport.Name = "cmdReport";
			this.cmdReport.TabIndex = 232;
			this.cmdReport.Text = "&Pay Period Report";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.AllowDrop = true;
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "&Close";
			this.Text = "Weekly Scheduler";
			this.SchedLock = 0;
			lbPos1am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos1am[6] = _lbPos1am_6;
			lbPos1am[5] = _lbPos1am_5;
			lbPos1am[4] = _lbPos1am_4;
			lbPos1am[3] = _lbPos1am_3;
			lbPos1am[2] = _lbPos1am_2;
			lbPos1am[1] = _lbPos1am_1;
			lbPos1am[0] = _lbPos1am_0;
			lbPos1am[6].AllowDrop = true;
			lbPos1am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[6].Name = "_lbPos1am_6";
			lbPos1am[6].TabIndex = 59;
			lbPos1am[6].Text = "1-AM";
			lbPos1am[6].Visible = false;
			lbPos1am[5].AllowDrop = true;
			lbPos1am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[5].Name = "_lbPos1am_5";
			lbPos1am[5].TabIndex = 58;
			lbPos1am[5].Text = "1-AM";
			lbPos1am[5].Visible = false;
			lbPos1am[4].AllowDrop = true;
			lbPos1am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[4].Name = "_lbPos1am_4";
			lbPos1am[4].TabIndex = 57;
			lbPos1am[4].Text = "1-AM";
			lbPos1am[4].Visible = false;
			lbPos1am[3].AllowDrop = true;
			lbPos1am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[3].Name = "_lbPos1am_3";
			lbPos1am[3].TabIndex = 56;
			lbPos1am[3].Text = "1-AM";
			lbPos1am[3].Visible = false;
			lbPos1am[2].AllowDrop = true;
			lbPos1am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[2].Name = "_lbPos1am_2";
			lbPos1am[2].TabIndex = 55;
			lbPos1am[2].Text = "1-AM";
			lbPos1am[2].Visible = false;
			lbPos1am[1].AllowDrop = true;
			lbPos1am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[1].Name = "_lbPos1am_1";
			lbPos1am[1].TabIndex = 54;
			lbPos1am[1].Text = "1-AM";
			lbPos1am[1].Visible = false;
			lbPos1am[0].AllowDrop = true;
			lbPos1am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos1am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1am[0].Name = "_lbPos1am_0";
			lbPos1am[0].TabIndex = 53;
			lbPos1am[0].Text = "1-AM";
			lbPos1am[0].Visible = false;
			lbPos1pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos1pm[6] = _lbPos1pm_6;
			lbPos1pm[5] = _lbPos1pm_5;
			lbPos1pm[4] = _lbPos1pm_4;
			lbPos1pm[3] = _lbPos1pm_3;
			lbPos1pm[2] = _lbPos1pm_2;
			lbPos1pm[1] = _lbPos1pm_1;
			lbPos1pm[0] = _lbPos1pm_0;
			lbPos1pm[6].AllowDrop = true;
			lbPos1pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[6].Name = "_lbPos1pm_6";
			lbPos1pm[6].TabIndex = 66;
			lbPos1pm[6].Text = "1-PM";
			lbPos1pm[6].Visible = false;
			lbPos1pm[5].AllowDrop = true;
			lbPos1pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[5].Name = "_lbPos1pm_5";
			lbPos1pm[5].TabIndex = 65;
			lbPos1pm[5].Text = "1-PM";
			lbPos1pm[5].Visible = false;
			lbPos1pm[4].AllowDrop = true;
			lbPos1pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[4].Name = "_lbPos1pm_4";
			lbPos1pm[4].TabIndex = 64;
			lbPos1pm[4].Text = "1-PM";
			lbPos1pm[4].Visible = false;
			lbPos1pm[3].AllowDrop = true;
			lbPos1pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[3].Name = "_lbPos1pm_3";
			lbPos1pm[3].TabIndex = 63;
			lbPos1pm[3].Text = "1-PM";
			lbPos1pm[3].Visible = false;
			lbPos1pm[2].AllowDrop = true;
			lbPos1pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[2].Name = "_lbPos1pm_2";
			lbPos1pm[2].TabIndex = 62;
			lbPos1pm[2].Text = "1-PM";
			lbPos1pm[2].Visible = false;
			lbPos1pm[1].AllowDrop = true;
			lbPos1pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[1].Name = "_lbPos1pm_1";
			lbPos1pm[1].TabIndex = 61;
			lbPos1pm[1].Text = "1-PM";
			lbPos1pm[1].Visible = false;
			lbPos1pm[0].AllowDrop = true;
			lbPos1pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos1pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos1pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos1pm[0].Name = "_lbPos1pm_0";
			lbPos1pm[0].TabIndex = 60;
			lbPos1pm[0].Text = "1-PM";
			lbPos1pm[0].Visible = false;
			lbPos2am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos2am[6] = _lbPos2am_6;
			lbPos2am[5] = _lbPos2am_5;
			lbPos2am[4] = _lbPos2am_4;
			lbPos2am[3] = _lbPos2am_3;
			lbPos2am[2] = _lbPos2am_2;
			lbPos2am[1] = _lbPos2am_1;
			lbPos2am[0] = _lbPos2am_0;
			lbPos2am[6].AllowDrop = true;
			lbPos2am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[6].Name = "_lbPos2am_6";
			lbPos2am[6].TabIndex = 73;
			lbPos2am[6].Text = "2-AM";
			lbPos2am[6].Visible = false;
			lbPos2am[5].AllowDrop = true;
			lbPos2am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[5].Name = "_lbPos2am_5";
			lbPos2am[5].TabIndex = 72;
			lbPos2am[5].Text = "2-AM";
			lbPos2am[5].Visible = false;
			lbPos2am[4].AllowDrop = true;
			lbPos2am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[4].Name = "_lbPos2am_4";
			lbPos2am[4].TabIndex = 71;
			lbPos2am[4].Text = "2-AM";
			lbPos2am[4].Visible = false;
			lbPos2am[3].AllowDrop = true;
			lbPos2am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[3].Name = "_lbPos2am_3";
			lbPos2am[3].TabIndex = 70;
			lbPos2am[3].Text = "2-AM";
			lbPos2am[3].Visible = false;
			lbPos2am[2].AllowDrop = true;
			lbPos2am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[2].Name = "_lbPos2am_2";
			lbPos2am[2].TabIndex = 69;
			lbPos2am[2].Text = "2-AM";
			lbPos2am[2].Visible = false;
			lbPos2am[1].AllowDrop = true;
			lbPos2am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[1].Name = "_lbPos2am_1";
			lbPos2am[1].TabIndex = 68;
			lbPos2am[1].Text = "2-AM";
			lbPos2am[1].Visible = false;
			lbPos2am[0].AllowDrop = true;
			lbPos2am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos2am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2am[0].Name = "_lbPos2am_0";
			lbPos2am[0].TabIndex = 67;
			lbPos2am[0].Text = "2-AM";
			lbPos2am[0].Visible = false;
			lbPos2pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos2pm[6] = _lbPos2pm_6;
			lbPos2pm[5] = _lbPos2pm_5;
			lbPos2pm[4] = _lbPos2pm_4;
			lbPos2pm[3] = _lbPos2pm_3;
			lbPos2pm[2] = _lbPos2pm_2;
			lbPos2pm[1] = _lbPos2pm_1;
			lbPos2pm[0] = _lbPos2pm_0;
			lbPos2pm[6].AllowDrop = true;
			lbPos2pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[6].Name = "_lbPos2pm_6";
			lbPos2pm[6].TabIndex = 80;
			lbPos2pm[6].Text = "2-PM";
			lbPos2pm[6].Visible = false;
			lbPos2pm[5].AllowDrop = true;
			lbPos2pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[5].Name = "_lbPos2pm_5";
			lbPos2pm[5].TabIndex = 79;
			lbPos2pm[5].Text = "2-PM";
			lbPos2pm[5].Visible = false;
			lbPos2pm[4].AllowDrop = true;
			lbPos2pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[4].Name = "_lbPos2pm_4";
			lbPos2pm[4].TabIndex = 78;
			lbPos2pm[4].Text = "2-PM";
			lbPos2pm[4].Visible = false;
			lbPos2pm[3].AllowDrop = true;
			lbPos2pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[3].Name = "_lbPos2pm_3";
			lbPos2pm[3].TabIndex = 77;
			lbPos2pm[3].Text = "2-PM";
			lbPos2pm[3].Visible = false;
			lbPos2pm[2].AllowDrop = true;
			lbPos2pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[2].Name = "_lbPos2pm_2";
			lbPos2pm[2].TabIndex = 76;
			lbPos2pm[2].Text = "2-PM";
			lbPos2pm[2].Visible = false;
			lbPos2pm[1].AllowDrop = true;
			lbPos2pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[1].Name = "_lbPos2pm_1";
			lbPos2pm[1].TabIndex = 75;
			lbPos2pm[1].Text = "2-PM";
			lbPos2pm[1].Visible = false;
			lbPos2pm[0].AllowDrop = true;
			lbPos2pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos2pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos2pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos2pm[0].Name = "_lbPos2pm_0";
			lbPos2pm[0].TabIndex = 74;
			lbPos2pm[0].Text = "2-PM";
			lbPos2pm[0].Visible = false;
			lbPos3am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos3am[6] = _lbPos3am_6;
			lbPos3am[5] = _lbPos3am_5;
			lbPos3am[4] = _lbPos3am_4;
			lbPos3am[3] = _lbPos3am_3;
			lbPos3am[2] = _lbPos3am_2;
			lbPos3am[1] = _lbPos3am_1;
			lbPos3am[0] = _lbPos3am_0;
			lbPos3am[6].AllowDrop = true;
			lbPos3am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[6].Name = "_lbPos3am_6";
			lbPos3am[6].TabIndex = 87;
			lbPos3am[6].Text = "3-AM";
			lbPos3am[6].Visible = false;
			lbPos3am[5].AllowDrop = true;
			lbPos3am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[5].Name = "_lbPos3am_5";
			lbPos3am[5].TabIndex = 86;
			lbPos3am[5].Text = "3-AM";
			lbPos3am[5].Visible = false;
			lbPos3am[4].AllowDrop = true;
			lbPos3am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[4].Name = "_lbPos3am_4";
			lbPos3am[4].TabIndex = 85;
			lbPos3am[4].Text = "3-AM";
			lbPos3am[4].Visible = false;
			lbPos3am[3].AllowDrop = true;
			lbPos3am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[3].Name = "_lbPos3am_3";
			lbPos3am[3].TabIndex = 84;
			lbPos3am[3].Text = "3-AM";
			lbPos3am[3].Visible = false;
			lbPos3am[2].AllowDrop = true;
			lbPos3am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[2].Name = "_lbPos3am_2";
			lbPos3am[2].TabIndex = 83;
			lbPos3am[2].Text = "3-AM";
			lbPos3am[2].Visible = false;
			lbPos3am[1].AllowDrop = true;
			lbPos3am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[1].Name = "_lbPos3am_1";
			lbPos3am[1].TabIndex = 82;
			lbPos3am[1].Text = "3-AM";
			lbPos3am[1].Visible = false;
			lbPos3am[0].AllowDrop = true;
			lbPos3am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos3am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3am[0].Name = "_lbPos3am_0";
			lbPos3am[0].TabIndex = 81;
			lbPos3am[0].Text = "3-AM";
			lbPos3am[0].Visible = false;
			lbPos3pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos3pm[6] = _lbPos3pm_6;
			lbPos3pm[5] = _lbPos3pm_5;
			lbPos3pm[4] = _lbPos3pm_4;
			lbPos3pm[3] = _lbPos3pm_3;
			lbPos3pm[2] = _lbPos3pm_2;
			lbPos3pm[1] = _lbPos3pm_1;
			lbPos3pm[0] = _lbPos3pm_0;
			lbPos3pm[6].AllowDrop = true;
			lbPos3pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[6].Name = "_lbPos3pm_6";
			lbPos3pm[6].TabIndex = 94;
			lbPos3pm[6].Text = "3-PM";
			lbPos3pm[6].Visible = false;
			lbPos3pm[5].AllowDrop = true;
			lbPos3pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[5].Name = "_lbPos3pm_5";
			lbPos3pm[5].TabIndex = 93;
			lbPos3pm[5].Text = "3-PM";
			lbPos3pm[5].Visible = false;
			lbPos3pm[4].AllowDrop = true;
			lbPos3pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[4].Name = "_lbPos3pm_4";
			lbPos3pm[4].TabIndex = 92;
			lbPos3pm[4].Text = "3-PM";
			lbPos3pm[4].Visible = false;
			lbPos3pm[3].AllowDrop = true;
			lbPos3pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[3].Name = "_lbPos3pm_3";
			lbPos3pm[3].TabIndex = 91;
			lbPos3pm[3].Text = "3-PM";
			lbPos3pm[3].Visible = false;
			lbPos3pm[2].AllowDrop = true;
			lbPos3pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[2].Name = "_lbPos3pm_2";
			lbPos3pm[2].TabIndex = 90;
			lbPos3pm[2].Text = "3-PM";
			lbPos3pm[2].Visible = false;
			lbPos3pm[1].AllowDrop = true;
			lbPos3pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[1].Name = "_lbPos3pm_1";
			lbPos3pm[1].TabIndex = 89;
			lbPos3pm[1].Text = "3-PM";
			lbPos3pm[1].Visible = false;
			lbPos3pm[0].AllowDrop = true;
			lbPos3pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos3pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos3pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos3pm[0].Name = "_lbPos3pm_0";
			lbPos3pm[0].TabIndex = 88;
			lbPos3pm[0].Text = "3-PM";
			lbPos3pm[0].Visible = false;
			lbPos4am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos4am[6] = _lbPos4am_6;
			lbPos4am[5] = _lbPos4am_5;
			lbPos4am[4] = _lbPos4am_4;
			lbPos4am[3] = _lbPos4am_3;
			lbPos4am[2] = _lbPos4am_2;
			lbPos4am[1] = _lbPos4am_1;
			lbPos4am[0] = _lbPos4am_0;
			lbPos4am[6].AllowDrop = true;
			lbPos4am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[6].Name = "_lbPos4am_6";
			lbPos4am[6].TabIndex = 101;
			lbPos4am[6].Text = "4-AM";
			lbPos4am[6].Visible = false;
			lbPos4am[5].AllowDrop = true;
			lbPos4am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[5].Name = "_lbPos4am_5";
			lbPos4am[5].TabIndex = 100;
			lbPos4am[5].Text = "4-AM";
			lbPos4am[5].Visible = false;
			lbPos4am[4].AllowDrop = true;
			lbPos4am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[4].Name = "_lbPos4am_4";
			lbPos4am[4].TabIndex = 99;
			lbPos4am[4].Text = "4-AM";
			lbPos4am[4].Visible = false;
			lbPos4am[3].AllowDrop = true;
			lbPos4am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[3].Name = "_lbPos4am_3";
			lbPos4am[3].TabIndex = 98;
			lbPos4am[3].Text = "4-AM";
			lbPos4am[3].Visible = false;
			lbPos4am[2].AllowDrop = true;
			lbPos4am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[2].Name = "_lbPos4am_2";
			lbPos4am[2].TabIndex = 97;
			lbPos4am[2].Text = "4-AM";
			lbPos4am[2].Visible = false;
			lbPos4am[1].AllowDrop = true;
			lbPos4am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[1].Name = "_lbPos4am_1";
			lbPos4am[1].TabIndex = 96;
			lbPos4am[1].Text = "4-AM";
			lbPos4am[1].Visible = false;
			lbPos4am[0].AllowDrop = true;
			lbPos4am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos4am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4am[0].Name = "_lbPos4am_0";
			lbPos4am[0].TabIndex = 95;
			lbPos4am[0].Text = "4-AM";
			lbPos4am[0].Visible = false;
			lbPos4pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos4pm[6] = _lbPos4pm_6;
			lbPos4pm[5] = _lbPos4pm_5;
			lbPos4pm[4] = _lbPos4pm_4;
			lbPos4pm[3] = _lbPos4pm_3;
			lbPos4pm[2] = _lbPos4pm_2;
			lbPos4pm[1] = _lbPos4pm_1;
			lbPos4pm[0] = _lbPos4pm_0;
			lbPos4pm[6].AllowDrop = true;
			lbPos4pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[6].Name = "_lbPos4pm_6";
			lbPos4pm[6].TabIndex = 108;
			lbPos4pm[6].Text = "4-PM";
			lbPos4pm[6].Visible = false;
			lbPos4pm[5].AllowDrop = true;
			lbPos4pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[5].Name = "_lbPos4pm_5";
			lbPos4pm[5].TabIndex = 107;
			lbPos4pm[5].Text = "4-PM";
			lbPos4pm[5].Visible = false;
			lbPos4pm[4].AllowDrop = true;
			lbPos4pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[4].Name = "_lbPos4pm_4";
			lbPos4pm[4].TabIndex = 106;
			lbPos4pm[4].Text = "4-PM";
			lbPos4pm[4].Visible = false;
			lbPos4pm[3].AllowDrop = true;
			lbPos4pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[3].Name = "_lbPos4pm_3";
			lbPos4pm[3].TabIndex = 105;
			lbPos4pm[3].Text = "4-PM";
			lbPos4pm[3].Visible = false;
			lbPos4pm[2].AllowDrop = true;
			lbPos4pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[2].Name = "_lbPos4pm_2";
			lbPos4pm[2].TabIndex = 104;
			lbPos4pm[2].Text = "4-PM";
			lbPos4pm[2].Visible = false;
			lbPos4pm[1].AllowDrop = true;
			lbPos4pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[1].Name = "_lbPos4pm_1";
			lbPos4pm[1].TabIndex = 103;
			lbPos4pm[1].Text = "4-PM";
			lbPos4pm[1].Visible = false;
			lbPos4pm[0].AllowDrop = true;
			lbPos4pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos4pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos4pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos4pm[0].Name = "_lbPos4pm_0";
			lbPos4pm[0].TabIndex = 102;
			lbPos4pm[0].Text = "4-PM";
			lbPos4pm[0].Visible = false;
			lbPos5am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos5am[6] = _lbPos5am_6;
			lbPos5am[5] = _lbPos5am_5;
			lbPos5am[4] = _lbPos5am_4;
			lbPos5am[3] = _lbPos5am_3;
			lbPos5am[2] = _lbPos5am_2;
			lbPos5am[1] = _lbPos5am_1;
			lbPos5am[0] = _lbPos5am_0;
			lbPos5am[6].AllowDrop = true;
			lbPos5am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[6].Name = "_lbPos5am_6";
			lbPos5am[6].TabIndex = 115;
			lbPos5am[6].Text = "5-AM";
			lbPos5am[6].Visible = false;
			lbPos5am[5].AllowDrop = true;
			lbPos5am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[5].Name = "_lbPos5am_5";
			lbPos5am[5].TabIndex = 114;
			lbPos5am[5].Text = "5-AM";
			lbPos5am[5].Visible = false;
			lbPos5am[4].AllowDrop = true;
			lbPos5am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[4].Name = "_lbPos5am_4";
			lbPos5am[4].TabIndex = 113;
			lbPos5am[4].Text = "5-AM";
			lbPos5am[4].Visible = false;
			lbPos5am[3].AllowDrop = true;
			lbPos5am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[3].Name = "_lbPos5am_3";
			lbPos5am[3].TabIndex = 112;
			lbPos5am[3].Text = "5-AM";
			lbPos5am[3].Visible = false;
			lbPos5am[2].AllowDrop = true;
			lbPos5am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[2].Name = "_lbPos5am_2";
			lbPos5am[2].TabIndex = 111;
			lbPos5am[2].Text = "5-AM";
			lbPos5am[2].Visible = false;
			lbPos5am[1].AllowDrop = true;
			lbPos5am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[1].Name = "_lbPos5am_1";
			lbPos5am[1].TabIndex = 110;
			lbPos5am[1].Text = "5-AM";
			lbPos5am[1].Visible = false;
			lbPos5am[0].AllowDrop = true;
			lbPos5am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos5am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5am[0].Name = "_lbPos5am_0";
			lbPos5am[0].TabIndex = 109;
			lbPos5am[0].Text = "5-AM";
			lbPos5am[0].Visible = false;
			lbPos5pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos5pm[6] = _lbPos5pm_6;
			lbPos5pm[5] = _lbPos5pm_5;
			lbPos5pm[4] = _lbPos5pm_4;
			lbPos5pm[3] = _lbPos5pm_3;
			lbPos5pm[2] = _lbPos5pm_2;
			lbPos5pm[1] = _lbPos5pm_1;
			lbPos5pm[0] = _lbPos5pm_0;
			lbPos5pm[6].AllowDrop = true;
			lbPos5pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[6].Name = "_lbPos5pm_6";
			lbPos5pm[6].TabIndex = 122;
			lbPos5pm[6].Text = "5-PM";
			lbPos5pm[6].Visible = false;
			lbPos5pm[5].AllowDrop = true;
			lbPos5pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[5].Name = "_lbPos5pm_5";
			lbPos5pm[5].TabIndex = 121;
			lbPos5pm[5].Text = "5-PM";
			lbPos5pm[5].Visible = false;
			lbPos5pm[4].AllowDrop = true;
			lbPos5pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[4].Name = "_lbPos5pm_4";
			lbPos5pm[4].TabIndex = 120;
			lbPos5pm[4].Text = "5-PM";
			lbPos5pm[4].Visible = false;
			lbPos5pm[3].AllowDrop = true;
			lbPos5pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[3].Name = "_lbPos5pm_3";
			lbPos5pm[3].TabIndex = 119;
			lbPos5pm[3].Text = "5-PM";
			lbPos5pm[3].Visible = false;
			lbPos5pm[2].AllowDrop = true;
			lbPos5pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[2].Name = "_lbPos5pm_2";
			lbPos5pm[2].TabIndex = 118;
			lbPos5pm[2].Text = "5-PM";
			lbPos5pm[2].Visible = false;
			lbPos5pm[1].AllowDrop = true;
			lbPos5pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[1].Name = "_lbPos5pm_1";
			lbPos5pm[1].TabIndex = 117;
			lbPos5pm[1].Text = "5-PM";
			lbPos5pm[1].Visible = false;
			lbPos5pm[0].AllowDrop = true;
			lbPos5pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos5pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos5pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos5pm[0].Name = "_lbPos5pm_0";
			lbPos5pm[0].TabIndex = 116;
			lbPos5pm[0].Text = "5-PM";
			lbPos5pm[0].Visible = false;
			lbPos6am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos6am[6] = _lbPos6am_6;
			lbPos6am[5] = _lbPos6am_5;
			lbPos6am[4] = _lbPos6am_4;
			lbPos6am[3] = _lbPos6am_3;
			lbPos6am[2] = _lbPos6am_2;
			lbPos6am[1] = _lbPos6am_1;
			lbPos6am[0] = _lbPos6am_0;
			lbPos6am[6].AllowDrop = true;
			lbPos6am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[6].Name = "_lbPos6am_6";
			lbPos6am[6].TabIndex = 129;
			lbPos6am[6].Text = "6-AM";
			lbPos6am[6].Visible = false;
			lbPos6am[5].AllowDrop = true;
			lbPos6am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[5].Name = "_lbPos6am_5";
			lbPos6am[5].TabIndex = 128;
			lbPos6am[5].Text = "6-AM";
			lbPos6am[5].Visible = false;
			lbPos6am[4].AllowDrop = true;
			lbPos6am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[4].Name = "_lbPos6am_4";
			lbPos6am[4].TabIndex = 127;
			lbPos6am[4].Text = "6-AM";
			lbPos6am[4].Visible = false;
			lbPos6am[3].AllowDrop = true;
			lbPos6am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[3].Name = "_lbPos6am_3";
			lbPos6am[3].TabIndex = 126;
			lbPos6am[3].Text = "6-AM";
			lbPos6am[3].Visible = false;
			lbPos6am[2].AllowDrop = true;
			lbPos6am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[2].Name = "_lbPos6am_2";
			lbPos6am[2].TabIndex = 125;
			lbPos6am[2].Text = "6-AM";
			lbPos6am[2].Visible = false;
			lbPos6am[1].AllowDrop = true;
			lbPos6am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[1].Name = "_lbPos6am_1";
			lbPos6am[1].TabIndex = 124;
			lbPos6am[1].Text = "6-AM";
			lbPos6am[1].Visible = false;
			lbPos6am[0].AllowDrop = true;
			lbPos6am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos6am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6am[0].Name = "_lbPos6am_0";
			lbPos6am[0].TabIndex = 123;
			lbPos6am[0].Text = "6-AM";
			lbPos6am[0].Visible = false;
			lbPos6pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos6pm[6] = _lbPos6pm_6;
			lbPos6pm[5] = _lbPos6pm_5;
			lbPos6pm[4] = _lbPos6pm_4;
			lbPos6pm[3] = _lbPos6pm_3;
			lbPos6pm[2] = _lbPos6pm_2;
			lbPos6pm[1] = _lbPos6pm_1;
			lbPos6pm[0] = _lbPos6pm_0;
			lbPos6pm[6].AllowDrop = true;
			lbPos6pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[6].Name = "_lbPos6pm_6";
			lbPos6pm[6].TabIndex = 136;
			lbPos6pm[6].Text = "6-PM";
			lbPos6pm[6].Visible = false;
			lbPos6pm[5].AllowDrop = true;
			lbPos6pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[5].Name = "_lbPos6pm_5";
			lbPos6pm[5].TabIndex = 135;
			lbPos6pm[5].Text = "6-PM";
			lbPos6pm[5].Visible = false;
			lbPos6pm[4].AllowDrop = true;
			lbPos6pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[4].Name = "_lbPos6pm_4";
			lbPos6pm[4].TabIndex = 134;
			lbPos6pm[4].Text = "6-PM";
			lbPos6pm[4].Visible = false;
			lbPos6pm[3].AllowDrop = true;
			lbPos6pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[3].Name = "_lbPos6pm_3";
			lbPos6pm[3].TabIndex = 133;
			lbPos6pm[3].Text = "6-PM";
			lbPos6pm[3].Visible = false;
			lbPos6pm[2].AllowDrop = true;
			lbPos6pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[2].Name = "_lbPos6pm_2";
			lbPos6pm[2].TabIndex = 132;
			lbPos6pm[2].Text = "6-PM";
			lbPos6pm[2].Visible = false;
			lbPos6pm[1].AllowDrop = true;
			lbPos6pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[1].Name = "_lbPos6pm_1";
			lbPos6pm[1].TabIndex = 131;
			lbPos6pm[1].Text = "6-PM";
			lbPos6pm[1].Visible = false;
			lbPos6pm[0].AllowDrop = true;
			lbPos6pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos6pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos6pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos6pm[0].Name = "_lbPos6pm_0";
			lbPos6pm[0].TabIndex = 130;
			lbPos6pm[0].Text = "6-PM";
			lbPos6pm[0].Visible = false;
			lbPos7am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos7am[6] = _lbPos7am_6;
			lbPos7am[5] = _lbPos7am_5;
			lbPos7am[4] = _lbPos7am_4;
			lbPos7am[3] = _lbPos7am_3;
			lbPos7am[2] = _lbPos7am_2;
			lbPos7am[1] = _lbPos7am_1;
			lbPos7am[0] = _lbPos7am_0;
			lbPos7am[6].AllowDrop = true;
			lbPos7am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[6].Name = "_lbPos7am_6";
			lbPos7am[6].TabIndex = 229;
			lbPos7am[6].Text = "7-AM";
			lbPos7am[6].Visible = false;
			lbPos7am[5].AllowDrop = true;
			lbPos7am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[5].Name = "_lbPos7am_5";
			lbPos7am[5].TabIndex = 228;
			lbPos7am[5].Text = "7-AM";
			lbPos7am[5].Visible = false;
			lbPos7am[4].AllowDrop = true;
			lbPos7am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[4].Name = "_lbPos7am_4";
			lbPos7am[4].TabIndex = 227;
			lbPos7am[4].Text = "7-AM";
			lbPos7am[4].Visible = false;
			lbPos7am[3].AllowDrop = true;
			lbPos7am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[3].Name = "_lbPos7am_3";
			lbPos7am[3].TabIndex = 226;
			lbPos7am[3].Text = "7-AM";
			lbPos7am[3].Visible = false;
			lbPos7am[2].AllowDrop = true;
			lbPos7am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[2].Name = "_lbPos7am_2";
			lbPos7am[2].TabIndex = 225;
			lbPos7am[2].Text = "7-AM";
			lbPos7am[2].Visible = false;
			lbPos7am[1].AllowDrop = true;
			lbPos7am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[1].Name = "_lbPos7am_1";
			lbPos7am[1].TabIndex = 224;
			lbPos7am[1].Text = "7-AM";
			lbPos7am[1].Visible = false;
			lbPos7am[0].AllowDrop = true;
			lbPos7am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos7am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7am[0].Name = "_lbPos7am_0";
			lbPos7am[0].TabIndex = 223;
			lbPos7am[0].Text = "7-AM";
			lbPos7am[0].Visible = false;
			lbPos7pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos7pm[6] = _lbPos7pm_6;
			lbPos7pm[5] = _lbPos7pm_5;
			lbPos7pm[4] = _lbPos7pm_4;
			lbPos7pm[3] = _lbPos7pm_3;
			lbPos7pm[2] = _lbPos7pm_2;
			lbPos7pm[1] = _lbPos7pm_1;
			lbPos7pm[0] = _lbPos7pm_0;
			lbPos7pm[6].AllowDrop = true;
			lbPos7pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[6].Name = "_lbPos7pm_6";
			lbPos7pm[6].TabIndex = 143;
			lbPos7pm[6].Text = "7-PM";
			lbPos7pm[6].Visible = false;
			lbPos7pm[5].AllowDrop = true;
			lbPos7pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[5].Name = "_lbPos7pm_5";
			lbPos7pm[5].TabIndex = 142;
			lbPos7pm[5].Text = "7-PM";
			lbPos7pm[5].Visible = false;
			lbPos7pm[4].AllowDrop = true;
			lbPos7pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[4].Name = "_lbPos7pm_4";
			lbPos7pm[4].TabIndex = 141;
			lbPos7pm[4].Text = "7-PM";
			lbPos7pm[4].Visible = false;
			lbPos7pm[3].AllowDrop = true;
			lbPos7pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[3].Name = "_lbPos7pm_3";
			lbPos7pm[3].TabIndex = 140;
			lbPos7pm[3].Text = "7-PM";
			lbPos7pm[3].Visible = false;
			lbPos7pm[2].AllowDrop = true;
			lbPos7pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[2].Name = "_lbPos7pm_2";
			lbPos7pm[2].TabIndex = 139;
			lbPos7pm[2].Text = "7-PM";
			lbPos7pm[2].Visible = false;
			lbPos7pm[1].AllowDrop = true;
			lbPos7pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[1].Name = "_lbPos7pm_1";
			lbPos7pm[1].TabIndex = 138;
			lbPos7pm[1].Text = "7-PM";
			lbPos7pm[1].Visible = false;
			lbPos7pm[0].AllowDrop = true;
			lbPos7pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos7pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos7pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos7pm[0].Name = "_lbPos7pm_0";
			lbPos7pm[0].TabIndex = 137;
			lbPos7pm[0].Text = "7-PM";
			lbPos7pm[0].Visible = false;
			lbPos8am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos8am[6] = _lbPos8am_6;
			lbPos8am[5] = _lbPos8am_5;
			lbPos8am[4] = _lbPos8am_4;
			lbPos8am[3] = _lbPos8am_3;
			lbPos8am[2] = _lbPos8am_2;
			lbPos8am[1] = _lbPos8am_1;
			lbPos8am[0] = _lbPos8am_0;
			lbPos8am[6].AllowDrop = true;
			lbPos8am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[6].Name = "_lbPos8am_6";
			lbPos8am[6].TabIndex = 150;
			lbPos8am[6].Text = "8-AM";
			lbPos8am[6].Visible = false;
			lbPos8am[5].AllowDrop = true;
			lbPos8am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[5].Name = "_lbPos8am_5";
			lbPos8am[5].TabIndex = 149;
			lbPos8am[5].Text = "8-AM";
			lbPos8am[5].Visible = false;
			lbPos8am[4].AllowDrop = true;
			lbPos8am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[4].Name = "_lbPos8am_4";
			lbPos8am[4].TabIndex = 148;
			lbPos8am[4].Text = "8-AM";
			lbPos8am[4].Visible = false;
			lbPos8am[3].AllowDrop = true;
			lbPos8am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[3].Name = "_lbPos8am_3";
			lbPos8am[3].TabIndex = 147;
			lbPos8am[3].Text = "8-AM";
			lbPos8am[3].Visible = false;
			lbPos8am[2].AllowDrop = true;
			lbPos8am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[2].Name = "_lbPos8am_2";
			lbPos8am[2].TabIndex = 146;
			lbPos8am[2].Text = "8-AM";
			lbPos8am[2].Visible = false;
			lbPos8am[1].AllowDrop = true;
			lbPos8am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[1].Name = "_lbPos8am_1";
			lbPos8am[1].TabIndex = 145;
			lbPos8am[1].Text = "8-AM";
			lbPos8am[1].Visible = false;
			lbPos8am[0].AllowDrop = true;
			lbPos8am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos8am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8am[0].Name = "_lbPos8am_0";
			lbPos8am[0].TabIndex = 144;
			lbPos8am[0].Text = "8-AM";
			lbPos8am[0].Visible = false;
			lbPos8pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos8pm[6] = _lbPos8pm_6;
			lbPos8pm[5] = _lbPos8pm_5;
			lbPos8pm[4] = _lbPos8pm_4;
			lbPos8pm[3] = _lbPos8pm_3;
			lbPos8pm[2] = _lbPos8pm_2;
			lbPos8pm[1] = _lbPos8pm_1;
			lbPos8pm[0] = _lbPos8pm_0;
			lbPos8pm[6].AllowDrop = true;
			lbPos8pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[6].Name = "_lbPos8pm_6";
			lbPos8pm[6].TabIndex = 157;
			lbPos8pm[6].Text = "8-PM";
			lbPos8pm[6].Visible = false;
			lbPos8pm[5].AllowDrop = true;
			lbPos8pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[5].Name = "_lbPos8pm_5";
			lbPos8pm[5].TabIndex = 156;
			lbPos8pm[5].Text = "8-PM";
			lbPos8pm[5].Visible = false;
			lbPos8pm[4].AllowDrop = true;
			lbPos8pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[4].Name = "_lbPos8pm_4";
			lbPos8pm[4].TabIndex = 155;
			lbPos8pm[4].Text = "8-PM";
			lbPos8pm[4].Visible = false;
			lbPos8pm[3].AllowDrop = true;
			lbPos8pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[3].Name = "_lbPos8pm_3";
			lbPos8pm[3].TabIndex = 154;
			lbPos8pm[3].Text = "8-PM";
			lbPos8pm[3].Visible = false;
			lbPos8pm[2].AllowDrop = true;
			lbPos8pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[2].Name = "_lbPos8pm_2";
			lbPos8pm[2].TabIndex = 153;
			lbPos8pm[2].Text = "8-PM";
			lbPos8pm[2].Visible = false;
			lbPos8pm[1].AllowDrop = true;
			lbPos8pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[1].Name = "_lbPos8pm_1";
			lbPos8pm[1].TabIndex = 152;
			lbPos8pm[1].Text = "8-PM";
			lbPos8pm[1].Visible = false;
			lbPos8pm[0].AllowDrop = true;
			lbPos8pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos8pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos8pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos8pm[0].Name = "_lbPos8pm_0";
			lbPos8pm[0].TabIndex = 151;
			lbPos8pm[0].Text = "8-PM";
			lbPos8pm[0].Visible = false;
			lbPos9am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos9am[6] = _lbPos9am_6;
			lbPos9am[5] = _lbPos9am_5;
			lbPos9am[4] = _lbPos9am_4;
			lbPos9am[3] = _lbPos9am_3;
			lbPos9am[2] = _lbPos9am_2;
			lbPos9am[1] = _lbPos9am_1;
			lbPos9am[0] = _lbPos9am_0;
			lbPos9am[6].AllowDrop = true;
			lbPos9am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[6].Name = "_lbPos9am_6";
			lbPos9am[6].TabIndex = 164;
			lbPos9am[6].Text = "9-AM";
			lbPos9am[6].Visible = false;
			lbPos9am[5].AllowDrop = true;
			lbPos9am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[5].Name = "_lbPos9am_5";
			lbPos9am[5].TabIndex = 163;
			lbPos9am[5].Text = "9-AM";
			lbPos9am[5].Visible = false;
			lbPos9am[4].AllowDrop = true;
			lbPos9am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[4].Name = "_lbPos9am_4";
			lbPos9am[4].TabIndex = 162;
			lbPos9am[4].Text = "9-AM";
			lbPos9am[4].Visible = false;
			lbPos9am[3].AllowDrop = true;
			lbPos9am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[3].Name = "_lbPos9am_3";
			lbPos9am[3].TabIndex = 161;
			lbPos9am[3].Text = "9-AM";
			lbPos9am[3].Visible = false;
			lbPos9am[2].AllowDrop = true;
			lbPos9am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[2].Name = "_lbPos9am_2";
			lbPos9am[2].TabIndex = 160;
			lbPos9am[2].Text = "9-AM";
			lbPos9am[2].Visible = false;
			lbPos9am[1].AllowDrop = true;
			lbPos9am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[1].Name = "_lbPos9am_1";
			lbPos9am[1].TabIndex = 159;
			lbPos9am[1].Text = "9-AM";
			lbPos9am[1].Visible = false;
			lbPos9am[0].AllowDrop = true;
			lbPos9am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos9am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9am[0].Name = "_lbPos9am_0";
			lbPos9am[0].TabIndex = 158;
			lbPos9am[0].Text = "9-AM";
			lbPos9am[0].Visible = false;
			lbPos9pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos9pm[6] = _lbPos9pm_6;
			lbPos9pm[5] = _lbPos9pm_5;
			lbPos9pm[4] = _lbPos9pm_4;
			lbPos9pm[3] = _lbPos9pm_3;
			lbPos9pm[2] = _lbPos9pm_2;
			lbPos9pm[1] = _lbPos9pm_1;
			lbPos9pm[0] = _lbPos9pm_0;
			lbPos9pm[6].AllowDrop = true;
			lbPos9pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[6].Name = "_lbPos9pm_6";
			lbPos9pm[6].TabIndex = 171;
			lbPos9pm[6].Text = "9-PM";
			lbPos9pm[6].Visible = false;
			lbPos9pm[5].AllowDrop = true;
			lbPos9pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[5].Name = "_lbPos9pm_5";
			lbPos9pm[5].TabIndex = 170;
			lbPos9pm[5].Text = "9-PM";
			lbPos9pm[5].Visible = false;
			lbPos9pm[4].AllowDrop = true;
			lbPos9pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[4].Name = "_lbPos9pm_4";
			lbPos9pm[4].TabIndex = 169;
			lbPos9pm[4].Text = "9-PM";
			lbPos9pm[4].Visible = false;
			lbPos9pm[3].AllowDrop = true;
			lbPos9pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[3].Name = "_lbPos9pm_3";
			lbPos9pm[3].TabIndex = 168;
			lbPos9pm[3].Text = "9-PM";
			lbPos9pm[3].Visible = false;
			lbPos9pm[2].AllowDrop = true;
			lbPos9pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[2].Name = "_lbPos9pm_2";
			lbPos9pm[2].TabIndex = 167;
			lbPos9pm[2].Text = "9-PM";
			lbPos9pm[2].Visible = false;
			lbPos9pm[1].AllowDrop = true;
			lbPos9pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[1].Name = "_lbPos9pm_1";
			lbPos9pm[1].TabIndex = 166;
			lbPos9pm[1].Text = "9-PM";
			lbPos9pm[1].Visible = false;
			lbPos9pm[0].AllowDrop = true;
			lbPos9pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos9pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos9pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos9pm[0].Name = "_lbPos9pm_0";
			lbPos9pm[0].TabIndex = 165;
			lbPos9pm[0].Text = "9-PM";
			lbPos9pm[0].Visible = false;
			lbPos10am = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos10am[6] = _lbPos10am_6;
			lbPos10am[5] = _lbPos10am_5;
			lbPos10am[4] = _lbPos10am_4;
			lbPos10am[3] = _lbPos10am_3;
			lbPos10am[2] = _lbPos10am_2;
			lbPos10am[1] = _lbPos10am_1;
			lbPos10am[0] = _lbPos10am_0;
			lbPos10am[6].AllowDrop = true;
			lbPos10am[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[6].Name = "_lbPos10am_6";
			lbPos10am[6].TabIndex = 178;
			lbPos10am[6].Text = "10-AM";
			lbPos10am[6].Visible = false;
			lbPos10am[5].AllowDrop = true;
			lbPos10am[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[5].Name = "_lbPos10am_5";
			lbPos10am[5].TabIndex = 177;
			lbPos10am[5].Text = "10-AM";
			lbPos10am[5].Visible = false;
			lbPos10am[4].AllowDrop = true;
			lbPos10am[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[4].Name = "_lbPos10am_4";
			lbPos10am[4].TabIndex = 176;
			lbPos10am[4].Text = "10-AM";
			lbPos10am[4].Visible = false;
			lbPos10am[3].AllowDrop = true;
			lbPos10am[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[3].Name = "_lbPos10am_3";
			lbPos10am[3].TabIndex = 175;
			lbPos10am[3].Text = "10-AM";
			lbPos10am[3].Visible = false;
			lbPos10am[2].AllowDrop = true;
			lbPos10am[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[2].Name = "_lbPos10am_2";
			lbPos10am[2].TabIndex = 174;
			lbPos10am[2].Text = "10-AM";
			lbPos10am[2].Visible = false;
			lbPos10am[1].AllowDrop = true;
			lbPos10am[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[1].Name = "_lbPos10am_1";
			lbPos10am[1].TabIndex = 173;
			lbPos10am[1].Text = "10-AM";
			lbPos10am[1].Visible = false;
			lbPos10am[0].AllowDrop = true;
			lbPos10am[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lbPos10am[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10am[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10am[0].Name = "_lbPos10am_0";
			lbPos10am[0].TabIndex = 172;
			lbPos10am[0].Text = "10-AM";
			lbPos10am[0].Visible = false;
			lbPos10pm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbPos10pm[6] = _lbPos10pm_6;
			lbPos10pm[5] = _lbPos10pm_5;
			lbPos10pm[4] = _lbPos10pm_4;
			lbPos10pm[3] = _lbPos10pm_3;
			lbPos10pm[2] = _lbPos10pm_2;
			lbPos10pm[1] = _lbPos10pm_1;
			lbPos10pm[0] = _lbPos10pm_0;
			lbPos10pm[6].AllowDrop = true;
			lbPos10pm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[6].Name = "_lbPos10pm_6";
			lbPos10pm[6].TabIndex = 185;
			lbPos10pm[6].Text = "10-PM";
			lbPos10pm[6].Visible = false;
			lbPos10pm[5].AllowDrop = true;
			lbPos10pm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[5].Name = "_lbPos10pm_5";
			lbPos10pm[5].TabIndex = 184;
			lbPos10pm[5].Text = "10-PM";
			lbPos10pm[5].Visible = false;
			lbPos10pm[4].AllowDrop = true;
			lbPos10pm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[4].Name = "_lbPos10pm_4";
			lbPos10pm[4].TabIndex = 183;
			lbPos10pm[4].Text = "10-PM";
			lbPos10pm[4].Visible = false;
			lbPos10pm[3].AllowDrop = true;
			lbPos10pm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[3].Name = "_lbPos10pm_3";
			lbPos10pm[3].TabIndex = 182;
			lbPos10pm[3].Text = "10-PM";
			lbPos10pm[3].Visible = false;
			lbPos10pm[2].AllowDrop = true;
			lbPos10pm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[2].Name = "_lbPos10pm_2";
			lbPos10pm[2].TabIndex = 181;
			lbPos10pm[2].Text = "10-PM";
			lbPos10pm[2].Visible = false;
			lbPos10pm[1].AllowDrop = true;
			lbPos10pm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[1].Name = "_lbPos10pm_1";
			lbPos10pm[1].TabIndex = 180;
			lbPos10pm[1].Text = "10-PM";
			lbPos10pm[1].Visible = false;
			lbPos10pm[0].AllowDrop = true;
			lbPos10pm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPos10pm[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPos10pm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lbPos10pm[0].Name = "_lbPos10pm_0";
			lbPos10pm[0].TabIndex = 179;
			lbPos10pm[0].Text = "10-PM";
			lbPos10pm[0].Visible = false;
			lbWeekDay = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbWeekDay[6] = _lbWeekDay_6;
			lbWeekDay[5] = _lbWeekDay_5;
			lbWeekDay[4] = _lbWeekDay_4;
			lbWeekDay[3] = _lbWeekDay_3;
			lbWeekDay[2] = _lbWeekDay_2;
			lbWeekDay[1] = _lbWeekDay_1;
			lbWeekDay[0] = _lbWeekDay_0;
			lbWeekDay[6].AllowDrop = true;
			lbWeekDay[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[6].Name = "_lbWeekDay_6";
			lbWeekDay[6].TabIndex = 52;
			lbWeekDay[6].Text = "lbWeekDay";
			lbWeekDay[5].AllowDrop = true;
			lbWeekDay[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[5].Name = "_lbWeekDay_5";
			lbWeekDay[5].TabIndex = 51;
			lbWeekDay[5].Text = "lbWeekDay";
			lbWeekDay[4].AllowDrop = true;
			lbWeekDay[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[4].Name = "_lbWeekDay_4";
			lbWeekDay[4].TabIndex = 50;
			lbWeekDay[4].Text = "lbWeekDay";
			lbWeekDay[3].AllowDrop = true;
			lbWeekDay[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[3].Name = "_lbWeekDay_3";
			lbWeekDay[3].TabIndex = 49;
			lbWeekDay[3].Text = "lbWeekDay";
			lbWeekDay[2].AllowDrop = true;
			lbWeekDay[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[2].Name = "_lbWeekDay_2";
			lbWeekDay[2].TabIndex = 48;
			lbWeekDay[2].Text = "lbWeekDay";
			lbWeekDay[1].AllowDrop = true;
			lbWeekDay[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[1].Name = "_lbWeekDay_1";
			lbWeekDay[1].TabIndex = 47;
			lbWeekDay[1].Text = "lbWeekDay";
			lbWeekDay[0].AllowDrop = true;
			lbWeekDay[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbWeekDay[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbWeekDay[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbWeekDay[0].Name = "_lbWeekDay_0";
			lbWeekDay[0].TabIndex = 46;
			lbWeekDay[0].Text = "lbWeekDay";
			shpP1am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP1am[6] = _shpP1am_6;
			shpP1am[5] = _shpP1am_5;
			shpP1am[4] = _shpP1am_4;
			shpP1am[3] = _shpP1am_3;
			shpP1am[2] = _shpP1am_2;
			shpP1am[1] = _shpP1am_1;
			shpP1am[0] = _shpP1am_0;
			shpP1am[6].AllowDrop = true;
			shpP1am[6].Enabled = false;
			shpP1am[6].Name = "_shpP1am_6";
			shpP1am[6].Visible = false;
			shpP1am[5].AllowDrop = true;
			shpP1am[5].Enabled = false;
			shpP1am[5].Name = "_shpP1am_5";
			shpP1am[5].Visible = false;
			shpP1am[4].AllowDrop = true;
			shpP1am[4].Enabled = false;
			shpP1am[4].Name = "_shpP1am_4";
			shpP1am[4].Visible = false;
			shpP1am[3].AllowDrop = true;
			shpP1am[3].Enabled = false;
			shpP1am[3].Name = "_shpP1am_3";
			shpP1am[3].Visible = false;
			shpP1am[2].AllowDrop = true;
			shpP1am[2].Enabled = false;
			shpP1am[2].Name = "_shpP1am_2";
			shpP1am[2].Visible = false;
			shpP1am[1].AllowDrop = true;
			shpP1am[1].Enabled = false;
			shpP1am[1].Name = "_shpP1am_1";
			shpP1am[1].Visible = false;
			shpP1am[0].AllowDrop = true;
			shpP1am[0].Enabled = false;
			shpP1am[0].Name = "_shpP1am_0";
			shpP1am[0].Visible = false;
			shpP1pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP1pm[6] = _shpP1pm_6;
			shpP1pm[5] = _shpP1pm_5;
			shpP1pm[4] = _shpP1pm_4;
			shpP1pm[3] = _shpP1pm_3;
			shpP1pm[2] = _shpP1pm_2;
			shpP1pm[1] = _shpP1pm_1;
			shpP1pm[0] = _shpP1pm_0;
			shpP1pm[6].AllowDrop = true;
			shpP1pm[6].Enabled = false;
			shpP1pm[6].Name = "_shpP1pm_6";
			shpP1pm[6].Visible = false;
			shpP1pm[5].AllowDrop = true;
			shpP1pm[5].Enabled = false;
			shpP1pm[5].Name = "_shpP1pm_5";
			shpP1pm[5].Visible = false;
			shpP1pm[4].AllowDrop = true;
			shpP1pm[4].Enabled = false;
			shpP1pm[4].Name = "_shpP1pm_4";
			shpP1pm[4].Visible = false;
			shpP1pm[3].AllowDrop = true;
			shpP1pm[3].Enabled = false;
			shpP1pm[3].Name = "_shpP1pm_3";
			shpP1pm[3].Visible = false;
			shpP1pm[2].AllowDrop = true;
			shpP1pm[2].Enabled = false;
			shpP1pm[2].Name = "_shpP1pm_2";
			shpP1pm[2].Visible = false;
			shpP1pm[1].AllowDrop = true;
			shpP1pm[1].Enabled = false;
			shpP1pm[1].Name = "_shpP1pm_1";
			shpP1pm[1].Visible = false;
			shpP1pm[0].AllowDrop = true;
			shpP1pm[0].Enabled = false;
			shpP1pm[0].Name = "_shpP1pm_0";
			shpP1pm[0].Visible = false;
			shpP2am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP2am[6] = _shpP2am_6;
			shpP2am[5] = _shpP2am_5;
			shpP2am[4] = _shpP2am_4;
			shpP2am[3] = _shpP2am_3;
			shpP2am[2] = _shpP2am_2;
			shpP2am[1] = _shpP2am_1;
			shpP2am[0] = _shpP2am_0;
			shpP2am[6].AllowDrop = true;
			shpP2am[6].Enabled = false;
			shpP2am[6].Name = "_shpP2am_6";
			shpP2am[6].Visible = false;
			shpP2am[5].AllowDrop = true;
			shpP2am[5].Enabled = false;
			shpP2am[5].Name = "_shpP2am_5";
			shpP2am[5].Visible = false;
			shpP2am[4].AllowDrop = true;
			shpP2am[4].Enabled = false;
			shpP2am[4].Name = "_shpP2am_4";
			shpP2am[4].Visible = false;
			shpP2am[3].AllowDrop = true;
			shpP2am[3].Enabled = false;
			shpP2am[3].Name = "_shpP2am_3";
			shpP2am[3].Visible = false;
			shpP2am[2].AllowDrop = true;
			shpP2am[2].Enabled = false;
			shpP2am[2].Name = "_shpP2am_2";
			shpP2am[2].Visible = false;
			shpP2am[1].AllowDrop = true;
			shpP2am[1].Enabled = false;
			shpP2am[1].Name = "_shpP2am_1";
			shpP2am[1].Visible = false;
			shpP2am[0].AllowDrop = true;
			shpP2am[0].Enabled = false;
			shpP2am[0].Name = "_shpP2am_0";
			shpP2am[0].Visible = false;
			shpP2pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP2pm[6] = _shpP2pm_6;
			shpP2pm[5] = _shpP2pm_5;
			shpP2pm[4] = _shpP2pm_4;
			shpP2pm[3] = _shpP2pm_3;
			shpP2pm[2] = _shpP2pm_2;
			shpP2pm[1] = _shpP2pm_1;
			shpP2pm[0] = _shpP2pm_0;
			shpP2pm[6].AllowDrop = true;
			shpP2pm[6].Enabled = false;
			shpP2pm[6].Name = "_shpP2pm_6";
			shpP2pm[6].Visible = false;
			shpP2pm[5].AllowDrop = true;
			shpP2pm[5].Enabled = false;
			shpP2pm[5].Name = "_shpP2pm_5";
			shpP2pm[5].Visible = false;
			shpP2pm[4].AllowDrop = true;
			shpP2pm[4].Enabled = false;
			shpP2pm[4].Name = "_shpP2pm_4";
			shpP2pm[4].Visible = false;
			shpP2pm[3].AllowDrop = true;
			shpP2pm[3].Enabled = false;
			shpP2pm[3].Name = "_shpP2pm_3";
			shpP2pm[3].Visible = false;
			shpP2pm[2].AllowDrop = true;
			shpP2pm[2].Enabled = false;
			shpP2pm[2].Name = "_shpP2pm_2";
			shpP2pm[2].Visible = false;
			shpP2pm[1].AllowDrop = true;
			shpP2pm[1].Enabled = false;
			shpP2pm[1].Name = "_shpP2pm_1";
			shpP2pm[1].Visible = false;
			shpP2pm[0].AllowDrop = true;
			shpP2pm[0].Enabled = false;
			shpP2pm[0].Name = "_shpP2pm_0";
			shpP2pm[0].Visible = false;
			shpP3am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP3am[6] = _shpP3am_6;
			shpP3am[5] = _shpP3am_5;
			shpP3am[4] = _shpP3am_4;
			shpP3am[3] = _shpP3am_3;
			shpP3am[2] = _shpP3am_2;
			shpP3am[1] = _shpP3am_1;
			shpP3am[0] = _shpP3am_0;
			shpP3am[6].AllowDrop = true;
			shpP3am[6].Enabled = false;
			shpP3am[6].Name = "_shpP3am_6";
			shpP3am[6].Visible = false;
			shpP3am[5].AllowDrop = true;
			shpP3am[5].Enabled = false;
			shpP3am[5].Name = "_shpP3am_5";
			shpP3am[5].Visible = false;
			shpP3am[4].AllowDrop = true;
			shpP3am[4].Enabled = false;
			shpP3am[4].Name = "_shpP3am_4";
			shpP3am[4].Visible = false;
			shpP3am[3].AllowDrop = true;
			shpP3am[3].Enabled = false;
			shpP3am[3].Name = "_shpP3am_3";
			shpP3am[3].Visible = false;
			shpP3am[2].AllowDrop = true;
			shpP3am[2].Enabled = false;
			shpP3am[2].Name = "_shpP3am_2";
			shpP3am[2].Visible = false;
			shpP3am[1].AllowDrop = true;
			shpP3am[1].Enabled = false;
			shpP3am[1].Name = "_shpP3am_1";
			shpP3am[1].Visible = false;
			shpP3am[0].AllowDrop = true;
			shpP3am[0].Enabled = false;
			shpP3am[0].Name = "_shpP3am_0";
			shpP3am[0].Visible = false;
			shpP3pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP3pm[6] = _shpP3pm_6;
			shpP3pm[5] = _shpP3pm_5;
			shpP3pm[4] = _shpP3pm_4;
			shpP3pm[3] = _shpP3pm_3;
			shpP3pm[2] = _shpP3pm_2;
			shpP3pm[1] = _shpP3pm_1;
			shpP3pm[0] = _shpP3pm_0;
			shpP3pm[6].AllowDrop = true;
			shpP3pm[6].Enabled = false;
			shpP3pm[6].Name = "_shpP3pm_6";
			shpP3pm[6].Visible = false;
			shpP3pm[5].AllowDrop = true;
			shpP3pm[5].Enabled = false;
			shpP3pm[5].Name = "_shpP3pm_5";
			shpP3pm[5].Visible = false;
			shpP3pm[4].AllowDrop = true;
			shpP3pm[4].Enabled = false;
			shpP3pm[4].Name = "_shpP3pm_4";
			shpP3pm[4].Visible = false;
			shpP3pm[3].AllowDrop = true;
			shpP3pm[3].Enabled = false;
			shpP3pm[3].Name = "_shpP3pm_3";
			shpP3pm[3].Visible = false;
			shpP3pm[2].AllowDrop = true;
			shpP3pm[2].Enabled = false;
			shpP3pm[2].Name = "_shpP3pm_2";
			shpP3pm[2].Visible = false;
			shpP3pm[1].AllowDrop = true;
			shpP3pm[1].Enabled = false;
			shpP3pm[1].Name = "_shpP3pm_1";
			shpP3pm[1].Visible = false;
			shpP3pm[0].AllowDrop = true;
			shpP3pm[0].Enabled = false;
			shpP3pm[0].Name = "_shpP3pm_0";
			shpP3pm[0].Visible = false;
			shpP4am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP4am[6] = _shpP4am_6;
			shpP4am[5] = _shpP4am_5;
			shpP4am[4] = _shpP4am_4;
			shpP4am[3] = _shpP4am_3;
			shpP4am[2] = _shpP4am_2;
			shpP4am[1] = _shpP4am_1;
			shpP4am[0] = _shpP4am_0;
			shpP4am[6].AllowDrop = true;
			shpP4am[6].Enabled = false;
			shpP4am[6].Name = "_shpP4am_6";
			shpP4am[6].Visible = false;
			shpP4am[5].AllowDrop = true;
			shpP4am[5].Enabled = false;
			shpP4am[5].Name = "_shpP4am_5";
			shpP4am[5].Visible = false;
			shpP4am[4].AllowDrop = true;
			shpP4am[4].Enabled = false;
			shpP4am[4].Name = "_shpP4am_4";
			shpP4am[4].Visible = false;
			shpP4am[3].AllowDrop = true;
			shpP4am[3].Enabled = false;
			shpP4am[3].Name = "_shpP4am_3";
			shpP4am[3].Visible = false;
			shpP4am[2].AllowDrop = true;
			shpP4am[2].Enabled = false;
			shpP4am[2].Name = "_shpP4am_2";
			shpP4am[2].Visible = false;
			shpP4am[1].AllowDrop = true;
			shpP4am[1].Enabled = false;
			shpP4am[1].Name = "_shpP4am_1";
			shpP4am[1].Visible = false;
			shpP4am[0].AllowDrop = true;
			shpP4am[0].Enabled = false;
			shpP4am[0].Name = "_shpP4am_0";
			shpP4am[0].Visible = false;
			shpP4pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP4pm[6] = _shpP4pm_6;
			shpP4pm[5] = _shpP4pm_5;
			shpP4pm[4] = _shpP4pm_4;
			shpP4pm[3] = _shpP4pm_3;
			shpP4pm[2] = _shpP4pm_2;
			shpP4pm[1] = _shpP4pm_1;
			shpP4pm[0] = _shpP4pm_0;
			shpP4pm[6].AllowDrop = true;
			shpP4pm[6].Enabled = false;
			shpP4pm[6].Name = "_shpP4pm_6";
			shpP4pm[6].Visible = false;
			shpP4pm[5].AllowDrop = true;
			shpP4pm[5].Enabled = false;
			shpP4pm[5].Name = "_shpP4pm_5";
			shpP4pm[5].Visible = false;
			shpP4pm[4].AllowDrop = true;
			shpP4pm[4].Enabled = false;
			shpP4pm[4].Name = "_shpP4pm_4";
			shpP4pm[4].Visible = false;
			shpP4pm[3].AllowDrop = true;
			shpP4pm[3].Enabled = false;
			shpP4pm[3].Name = "_shpP4pm_3";
			shpP4pm[3].Visible = false;
			shpP4pm[2].AllowDrop = true;
			shpP4pm[2].Enabled = false;
			shpP4pm[2].Name = "_shpP4pm_2";
			shpP4pm[2].Visible = false;
			shpP4pm[1].AllowDrop = true;
			shpP4pm[1].Enabled = false;
			shpP4pm[1].Name = "_shpP4pm_1";
			shpP4pm[1].Visible = false;
			shpP4pm[0].AllowDrop = true;
			shpP4pm[0].Enabled = false;
			shpP4pm[0].Name = "_shpP4pm_0";
			shpP4pm[0].Visible = false;
			shpP5am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP5am[6] = _shpP5am_6;
			shpP5am[5] = _shpP5am_5;
			shpP5am[4] = _shpP5am_4;
			shpP5am[3] = _shpP5am_3;
			shpP5am[2] = _shpP5am_2;
			shpP5am[1] = _shpP5am_1;
			shpP5am[0] = _shpP5am_0;
			shpP5am[6].AllowDrop = true;
			shpP5am[6].Enabled = false;
			shpP5am[6].Name = "_shpP5am_6";
			shpP5am[6].Visible = false;
			shpP5am[5].AllowDrop = true;
			shpP5am[5].Enabled = false;
			shpP5am[5].Name = "_shpP5am_5";
			shpP5am[5].Visible = false;
			shpP5am[4].AllowDrop = true;
			shpP5am[4].Enabled = false;
			shpP5am[4].Name = "_shpP5am_4";
			shpP5am[4].Visible = false;
			shpP5am[3].AllowDrop = true;
			shpP5am[3].Enabled = false;
			shpP5am[3].Name = "_shpP5am_3";
			shpP5am[3].Visible = false;
			shpP5am[2].AllowDrop = true;
			shpP5am[2].Enabled = false;
			shpP5am[2].Name = "_shpP5am_2";
			shpP5am[2].Visible = false;
			shpP5am[1].AllowDrop = true;
			shpP5am[1].Enabled = false;
			shpP5am[1].Name = "_shpP5am_1";
			shpP5am[1].Visible = false;
			shpP5am[0].AllowDrop = true;
			shpP5am[0].Enabled = false;
			shpP5am[0].Name = "_shpP5am_0";
			shpP5am[0].Visible = false;
			shpP5pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP5pm[6] = _shpP5pm_6;
			shpP5pm[5] = _shpP5pm_5;
			shpP5pm[4] = _shpP5pm_4;
			shpP5pm[3] = _shpP5pm_3;
			shpP5pm[2] = _shpP5pm_2;
			shpP5pm[1] = _shpP5pm_1;
			shpP5pm[0] = _shpP5pm_0;
			shpP5pm[6].AllowDrop = true;
			shpP5pm[6].Enabled = false;
			shpP5pm[6].Name = "_shpP5pm_6";
			shpP5pm[6].Visible = false;
			shpP5pm[5].AllowDrop = true;
			shpP5pm[5].Enabled = false;
			shpP5pm[5].Name = "_shpP5pm_5";
			shpP5pm[5].Visible = false;
			shpP5pm[4].AllowDrop = true;
			shpP5pm[4].Enabled = false;
			shpP5pm[4].Name = "_shpP5pm_4";
			shpP5pm[4].Visible = false;
			shpP5pm[3].AllowDrop = true;
			shpP5pm[3].Enabled = false;
			shpP5pm[3].Name = "_shpP5pm_3";
			shpP5pm[3].Visible = false;
			shpP5pm[2].AllowDrop = true;
			shpP5pm[2].Enabled = false;
			shpP5pm[2].Name = "_shpP5pm_2";
			shpP5pm[2].Visible = false;
			shpP5pm[1].AllowDrop = true;
			shpP5pm[1].Enabled = false;
			shpP5pm[1].Name = "_shpP5pm_1";
			shpP5pm[1].Visible = false;
			shpP5pm[0].AllowDrop = true;
			shpP5pm[0].Enabled = false;
			shpP5pm[0].Name = "_shpP5pm_0";
			shpP5pm[0].Visible = false;
			shpP6am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP6am[6] = _shpP6am_6;
			shpP6am[5] = _shpP6am_5;
			shpP6am[4] = _shpP6am_4;
			shpP6am[3] = _shpP6am_3;
			shpP6am[2] = _shpP6am_2;
			shpP6am[1] = _shpP6am_1;
			shpP6am[0] = _shpP6am_0;
			shpP6am[6].AllowDrop = true;
			shpP6am[6].Enabled = false;
			shpP6am[6].Name = "_shpP6am_6";
			shpP6am[6].Visible = false;
			shpP6am[5].AllowDrop = true;
			shpP6am[5].Enabled = false;
			shpP6am[5].Name = "_shpP6am_5";
			shpP6am[5].Visible = false;
			shpP6am[4].AllowDrop = true;
			shpP6am[4].Enabled = false;
			shpP6am[4].Name = "_shpP6am_4";
			shpP6am[4].Visible = false;
			shpP6am[3].AllowDrop = true;
			shpP6am[3].Enabled = false;
			shpP6am[3].Name = "_shpP6am_3";
			shpP6am[3].Visible = false;
			shpP6am[2].AllowDrop = true;
			shpP6am[2].Enabled = false;
			shpP6am[2].Name = "_shpP6am_2";
			shpP6am[2].Visible = false;
			shpP6am[1].AllowDrop = true;
			shpP6am[1].Enabled = false;
			shpP6am[1].Name = "_shpP6am_1";
			shpP6am[1].Visible = false;
			shpP6am[0].AllowDrop = true;
			shpP6am[0].Enabled = false;
			shpP6am[0].Name = "_shpP6am_0";
			shpP6am[0].Visible = false;
			shpP6pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP6pm[6] = _shpP6pm_6;
			shpP6pm[5] = _shpP6pm_5;
			shpP6pm[4] = _shpP6pm_4;
			shpP6pm[3] = _shpP6pm_3;
			shpP6pm[2] = _shpP6pm_2;
			shpP6pm[1] = _shpP6pm_1;
			shpP6pm[0] = _shpP6pm_0;
			shpP6pm[6].AllowDrop = true;
			shpP6pm[6].Enabled = false;
			shpP6pm[6].Name = "_shpP6pm_6";
			shpP6pm[6].Visible = false;
			shpP6pm[5].AllowDrop = true;
			shpP6pm[5].Enabled = false;
			shpP6pm[5].Name = "_shpP6pm_5";
			shpP6pm[5].Visible = false;
			shpP6pm[4].AllowDrop = true;
			shpP6pm[4].Enabled = false;
			shpP6pm[4].Name = "_shpP6pm_4";
			shpP6pm[4].Visible = false;
			shpP6pm[3].AllowDrop = true;
			shpP6pm[3].Enabled = false;
			shpP6pm[3].Name = "_shpP6pm_3";
			shpP6pm[3].Visible = false;
			shpP6pm[2].AllowDrop = true;
			shpP6pm[2].Enabled = false;
			shpP6pm[2].Name = "_shpP6pm_2";
			shpP6pm[2].Visible = false;
			shpP6pm[1].AllowDrop = true;
			shpP6pm[1].Enabled = false;
			shpP6pm[1].Name = "_shpP6pm_1";
			shpP6pm[1].Visible = false;
			shpP6pm[0].AllowDrop = true;
			shpP6pm[0].Enabled = false;
			shpP6pm[0].Name = "_shpP6pm_0";
			shpP6pm[0].Visible = false;
			shpP7am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP7am[6] = _shpP7am_6;
			shpP7am[5] = _shpP7am_5;
			shpP7am[4] = _shpP7am_4;
			shpP7am[3] = _shpP7am_3;
			shpP7am[2] = _shpP7am_2;
			shpP7am[1] = _shpP7am_1;
			shpP7am[0] = _shpP7am_0;
			shpP7am[6].AllowDrop = true;
			shpP7am[6].Enabled = false;
			shpP7am[6].Name = "_shpP7am_6";
			shpP7am[6].Visible = false;
			shpP7am[5].AllowDrop = true;
			shpP7am[5].Enabled = false;
			shpP7am[5].Name = "_shpP7am_5";
			shpP7am[5].Visible = false;
			shpP7am[4].AllowDrop = true;
			shpP7am[4].Enabled = false;
			shpP7am[4].Name = "_shpP7am_4";
			shpP7am[4].Visible = false;
			shpP7am[3].AllowDrop = true;
			shpP7am[3].Enabled = false;
			shpP7am[3].Name = "_shpP7am_3";
			shpP7am[3].Visible = false;
			shpP7am[2].AllowDrop = true;
			shpP7am[2].Enabled = false;
			shpP7am[2].Name = "_shpP7am_2";
			shpP7am[2].Visible = false;
			shpP7am[1].AllowDrop = true;
			shpP7am[1].Enabled = false;
			shpP7am[1].Name = "_shpP7am_1";
			shpP7am[1].Visible = false;
			shpP7am[0].AllowDrop = true;
			shpP7am[0].Enabled = false;
			shpP7am[0].Name = "_shpP7am_0";
			shpP7am[0].Visible = false;
			shpP7pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP7pm[6] = _shpP7pm_6;
			shpP7pm[5] = _shpP7pm_5;
			shpP7pm[4] = _shpP7pm_4;
			shpP7pm[3] = _shpP7pm_3;
			shpP7pm[2] = _shpP7pm_2;
			shpP7pm[1] = _shpP7pm_1;
			shpP7pm[0] = _shpP7pm_0;
			shpP7pm[6].AllowDrop = true;
			shpP7pm[6].Enabled = false;
			shpP7pm[6].Name = "_shpP7pm_6";
			shpP7pm[6].Visible = false;
			shpP7pm[5].AllowDrop = true;
			shpP7pm[5].Enabled = false;
			shpP7pm[5].Name = "_shpP7pm_5";
			shpP7pm[5].Visible = false;
			shpP7pm[4].AllowDrop = true;
			shpP7pm[4].Enabled = false;
			shpP7pm[4].Name = "_shpP7pm_4";
			shpP7pm[4].Visible = false;
			shpP7pm[3].AllowDrop = true;
			shpP7pm[3].Enabled = false;
			shpP7pm[3].Name = "_shpP7pm_3";
			shpP7pm[3].Visible = false;
			shpP7pm[2].AllowDrop = true;
			shpP7pm[2].Enabled = false;
			shpP7pm[2].Name = "_shpP7pm_2";
			shpP7pm[2].Visible = false;
			shpP7pm[1].AllowDrop = true;
			shpP7pm[1].Enabled = false;
			shpP7pm[1].Name = "_shpP7pm_1";
			shpP7pm[1].Visible = false;
			shpP7pm[0].AllowDrop = true;
			shpP7pm[0].Enabled = false;
			shpP7pm[0].Name = "_shpP7pm_0";
			shpP7pm[0].Visible = false;
			shpP8am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP8am[6] = _shpP8am_6;
			shpP8am[5] = _shpP8am_5;
			shpP8am[4] = _shpP8am_4;
			shpP8am[3] = _shpP8am_3;
			shpP8am[2] = _shpP8am_2;
			shpP8am[1] = _shpP8am_1;
			shpP8am[0] = _shpP8am_0;
			shpP8am[6].AllowDrop = true;
			shpP8am[6].Enabled = false;
			shpP8am[6].Name = "_shpP8am_6";
			shpP8am[6].Visible = false;
			shpP8am[5].AllowDrop = true;
			shpP8am[5].Enabled = false;
			shpP8am[5].Name = "_shpP8am_5";
			shpP8am[5].Visible = false;
			shpP8am[4].AllowDrop = true;
			shpP8am[4].Enabled = false;
			shpP8am[4].Name = "_shpP8am_4";
			shpP8am[4].Visible = false;
			shpP8am[3].AllowDrop = true;
			shpP8am[3].Enabled = false;
			shpP8am[3].Name = "_shpP8am_3";
			shpP8am[3].Visible = false;
			shpP8am[2].AllowDrop = true;
			shpP8am[2].Enabled = false;
			shpP8am[2].Name = "_shpP8am_2";
			shpP8am[2].Visible = false;
			shpP8am[1].AllowDrop = true;
			shpP8am[1].Enabled = false;
			shpP8am[1].Name = "_shpP8am_1";
			shpP8am[1].Visible = false;
			shpP8am[0].AllowDrop = true;
			shpP8am[0].Enabled = false;
			shpP8am[0].Name = "_shpP8am_0";
			shpP8am[0].Visible = false;
			shpP8pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP8pm[6] = _shpP8pm_6;
			shpP8pm[5] = _shpP8pm_5;
			shpP8pm[4] = _shpP8pm_4;
			shpP8pm[3] = _shpP8pm_3;
			shpP8pm[2] = _shpP8pm_2;
			shpP8pm[1] = _shpP8pm_1;
			shpP8pm[0] = _shpP8pm_0;
			shpP8pm[6].AllowDrop = true;
			shpP8pm[6].Enabled = false;
			shpP8pm[6].Name = "_shpP8pm_6";
			shpP8pm[6].Visible = false;
			shpP8pm[5].AllowDrop = true;
			shpP8pm[5].Enabled = false;
			shpP8pm[5].Name = "_shpP8pm_5";
			shpP8pm[5].Visible = false;
			shpP8pm[4].AllowDrop = true;
			shpP8pm[4].Enabled = false;
			shpP8pm[4].Name = "_shpP8pm_4";
			shpP8pm[4].Visible = false;
			shpP8pm[3].AllowDrop = true;
			shpP8pm[3].Enabled = false;
			shpP8pm[3].Name = "_shpP8pm_3";
			shpP8pm[3].Visible = false;
			shpP8pm[2].AllowDrop = true;
			shpP8pm[2].Enabled = false;
			shpP8pm[2].Name = "_shpP8pm_2";
			shpP8pm[2].Visible = false;
			shpP8pm[1].AllowDrop = true;
			shpP8pm[1].Enabled = false;
			shpP8pm[1].Name = "_shpP8pm_1";
			shpP8pm[1].Visible = false;
			shpP8pm[0].AllowDrop = true;
			shpP8pm[0].Enabled = false;
			shpP8pm[0].Name = "_shpP8pm_0";
			shpP8pm[0].Visible = false;
			shpP9am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP9am[6] = _shpP9am_6;
			shpP9am[5] = _shpP9am_5;
			shpP9am[4] = _shpP9am_4;
			shpP9am[3] = _shpP9am_3;
			shpP9am[2] = _shpP9am_2;
			shpP9am[1] = _shpP9am_1;
			shpP9am[0] = _shpP9am_0;
			shpP9am[6].AllowDrop = true;
			shpP9am[6].Enabled = false;
			shpP9am[6].Name = "_shpP9am_6";
			shpP9am[6].Visible = false;
			shpP9am[5].AllowDrop = true;
			shpP9am[5].Enabled = false;
			shpP9am[5].Name = "_shpP9am_5";
			shpP9am[5].Visible = false;
			shpP9am[4].AllowDrop = true;
			shpP9am[4].Enabled = false;
			shpP9am[4].Name = "_shpP9am_4";
			shpP9am[4].Visible = false;
			shpP9am[3].AllowDrop = true;
			shpP9am[3].Enabled = false;
			shpP9am[3].Name = "_shpP9am_3";
			shpP9am[3].Visible = false;
			shpP9am[2].AllowDrop = true;
			shpP9am[2].Enabled = false;
			shpP9am[2].Name = "_shpP9am_2";
			shpP9am[2].Visible = false;
			shpP9am[1].AllowDrop = true;
			shpP9am[1].Enabled = false;
			shpP9am[1].Name = "_shpP9am_1";
			shpP9am[1].Visible = false;
			shpP9am[0].AllowDrop = true;
			shpP9am[0].Enabled = false;
			shpP9am[0].Name = "_shpP9am_0";
			shpP9am[0].Visible = false;
			shpP9pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP9pm[6] = _shpP9pm_6;
			shpP9pm[5] = _shpP9pm_5;
			shpP9pm[4] = _shpP9pm_4;
			shpP9pm[3] = _shpP9pm_3;
			shpP9pm[2] = _shpP9pm_2;
			shpP9pm[1] = _shpP9pm_1;
			shpP9pm[0] = _shpP9pm_0;
			shpP9pm[6].AllowDrop = true;
			shpP9pm[6].Enabled = false;
			shpP9pm[6].Name = "_shpP9pm_6";
			shpP9pm[6].Visible = false;
			shpP9pm[5].AllowDrop = true;
			shpP9pm[5].Enabled = false;
			shpP9pm[5].Name = "_shpP9pm_5";
			shpP9pm[5].Visible = false;
			shpP9pm[4].AllowDrop = true;
			shpP9pm[4].Enabled = false;
			shpP9pm[4].Name = "_shpP9pm_4";
			shpP9pm[4].Visible = false;
			shpP9pm[3].AllowDrop = true;
			shpP9pm[3].Enabled = false;
			shpP9pm[3].Name = "_shpP9pm_3";
			shpP9pm[3].Visible = false;
			shpP9pm[2].AllowDrop = true;
			shpP9pm[2].Enabled = false;
			shpP9pm[2].Name = "_shpP9pm_2";
			shpP9pm[2].Visible = false;
			shpP9pm[1].AllowDrop = true;
			shpP9pm[1].Enabled = false;
			shpP9pm[1].Name = "_shpP9pm_1";
			shpP9pm[1].Visible = false;
			shpP9pm[0].AllowDrop = true;
			shpP9pm[0].Enabled = false;
			shpP9pm[0].Name = "_shpP9pm_0";
			shpP9pm[0].Visible = false;
			shpP10am = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP10am[6] = _shpP10am_6;
			shpP10am[5] = _shpP10am_5;
			shpP10am[4] = _shpP10am_4;
			shpP10am[3] = _shpP10am_3;
			shpP10am[2] = _shpP10am_2;
			shpP10am[1] = _shpP10am_1;
			shpP10am[0] = _shpP10am_0;
			shpP10am[6].AllowDrop = true;
			shpP10am[6].Enabled = false;
			shpP10am[6].Name = "_shpP10am_6";
			shpP10am[6].Visible = false;
			shpP10am[5].AllowDrop = true;
			shpP10am[5].Enabled = false;
			shpP10am[5].Name = "_shpP10am_5";
			shpP10am[5].Visible = false;
			shpP10am[4].AllowDrop = true;
			shpP10am[4].Enabled = false;
			shpP10am[4].Name = "_shpP10am_4";
			shpP10am[4].Visible = false;
			shpP10am[3].AllowDrop = true;
			shpP10am[3].Enabled = false;
			shpP10am[3].Name = "_shpP10am_3";
			shpP10am[3].Visible = false;
			shpP10am[2].AllowDrop = true;
			shpP10am[2].Enabled = false;
			shpP10am[2].Name = "_shpP10am_2";
			shpP10am[2].Visible = false;
			shpP10am[1].AllowDrop = true;
			shpP10am[1].Enabled = false;
			shpP10am[1].Name = "_shpP10am_1";
			shpP10am[1].Visible = false;
			shpP10am[0].AllowDrop = true;
			shpP10am[0].Enabled = false;
			shpP10am[0].Name = "_shpP10am_0";
			shpP10am[0].Visible = false;
			shpP10pm = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(7);
			shpP10pm[6] = _shpP10pm_6;
			shpP10pm[5] = _shpP10pm_5;
			shpP10pm[4] = _shpP10pm_4;
			shpP10pm[3] = _shpP10pm_3;
			shpP10pm[2] = _shpP10pm_2;
			shpP10pm[1] = _shpP10pm_1;
			shpP10pm[0] = _shpP10pm_0;
			shpP10pm[6].AllowDrop = true;
			shpP10pm[6].Enabled = false;
			shpP10pm[6].Name = "_shpP10pm_6";
			shpP10pm[6].Visible = false;
			shpP10pm[5].AllowDrop = true;
			shpP10pm[5].Enabled = false;
			shpP10pm[5].Name = "_shpP10pm_5";
			shpP10pm[5].Visible = false;
			shpP10pm[4].AllowDrop = true;
			shpP10pm[4].Enabled = false;
			shpP10pm[4].Name = "_shpP10pm_4";
			shpP10pm[4].Visible = false;
			shpP10pm[3].AllowDrop = true;
			shpP10pm[3].Enabled = false;
			shpP10pm[3].Name = "_shpP10pm_3";
			shpP10pm[3].Visible = false;
			shpP10pm[2].AllowDrop = true;
			shpP10pm[2].Enabled = false;
			shpP10pm[2].Name = "_shpP10pm_2";
			shpP10pm[2].Visible = false;
			shpP10pm[1].AllowDrop = true;
			shpP10pm[1].Enabled = false;
			shpP10pm[1].Name = "_shpP10pm_1";
			shpP10pm[1].Visible = false;
			shpP10pm[0].AllowDrop = true;
			shpP10pm[0].Enabled = false;
			shpP10pm[0].Name = "_shpP10pm_0";
			shpP10pm[0].Visible = false;
			lbShiftArray = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbShiftArray[6] = _lbShiftArray_6;
			lbShiftArray[5] = _lbShiftArray_5;
			lbShiftArray[4] = _lbShiftArray_4;
			lbShiftArray[3] = _lbShiftArray_3;
			lbShiftArray[2] = _lbShiftArray_2;
			lbShiftArray[1] = _lbShiftArray_1;
			lbShiftArray[0] = _lbShiftArray_0;
			lbShiftArray[6].AllowDrop = true;
			lbShiftArray[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[6].Name = "_lbShiftArray_6";
			lbShiftArray[6].TabIndex = 212;
			lbShiftArray[6].Text = "A";
			lbShiftArray[5].AllowDrop = true;
			lbShiftArray[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[5].Name = "_lbShiftArray_5";
			lbShiftArray[5].TabIndex = 211;
			lbShiftArray[5].Text = "A";
			lbShiftArray[4].AllowDrop = true;
			lbShiftArray[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[4].Name = "_lbShiftArray_4";
			lbShiftArray[4].TabIndex = 210;
			lbShiftArray[4].Text = "A";
			lbShiftArray[3].AllowDrop = true;
			lbShiftArray[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[3].Name = "_lbShiftArray_3";
			lbShiftArray[3].TabIndex = 209;
			lbShiftArray[3].Text = "A";
			lbShiftArray[2].AllowDrop = true;
			lbShiftArray[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[2].Name = "_lbShiftArray_2";
			lbShiftArray[2].TabIndex = 208;
			lbShiftArray[2].Text = "A";
			lbShiftArray[1].AllowDrop = true;
			lbShiftArray[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[1].Name = "_lbShiftArray_1";
			lbShiftArray[1].TabIndex = 207;
			lbShiftArray[1].Text = "A";
			lbShiftArray[0].AllowDrop = true;
			lbShiftArray[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbShiftArray[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbShiftArray[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			lbShiftArray[0].Name = "_lbShiftArray_0";
			lbShiftArray[0].TabIndex = 206;
			lbShiftArray[0].Text = "A";
			lbUnitArray = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(20);
			lbUnitArray[19] = _lbUnitArray_19;
			lbUnitArray[18] = _lbUnitArray_18;
			lbUnitArray[17] = _lbUnitArray_17;
			lbUnitArray[16] = _lbUnitArray_16;
			lbUnitArray[15] = _lbUnitArray_15;
			lbUnitArray[14] = _lbUnitArray_14;
			lbUnitArray[13] = _lbUnitArray_13;
			lbUnitArray[12] = _lbUnitArray_12;
			lbUnitArray[11] = _lbUnitArray_11;
			lbUnitArray[10] = _lbUnitArray_10;
			lbUnitArray[9] = _lbUnitArray_9;
			lbUnitArray[8] = _lbUnitArray_8;
			lbUnitArray[7] = _lbUnitArray_7;
			lbUnitArray[6] = _lbUnitArray_6;
			lbUnitArray[5] = _lbUnitArray_5;
			lbUnitArray[4] = _lbUnitArray_4;
			lbUnitArray[3] = _lbUnitArray_3;
			lbUnitArray[2] = _lbUnitArray_2;
			lbUnitArray[1] = _lbUnitArray_1;
			lbUnitArray[0] = _lbUnitArray_0;
			lbUnitArray[19].AllowDrop = true;
			lbUnitArray[19].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[19].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[19].Name = "_lbUnitArray_19";
			lbUnitArray[19].TabIndex = 23;
			lbUnitArray[19].Text = "E03";
			lbUnitArray[19].Visible = false;
			lbUnitArray[18].AllowDrop = true;
			lbUnitArray[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[18].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[18].Name = "_lbUnitArray_18";
			lbUnitArray[18].TabIndex = 22;
			lbUnitArray[18].Text = "E03";
			lbUnitArray[18].Visible = false;
			lbUnitArray[17].AllowDrop = true;
			lbUnitArray[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[17].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[17].Name = "_lbUnitArray_17";
			lbUnitArray[17].TabIndex = 21;
			lbUnitArray[17].Text = "E03";
			lbUnitArray[17].Visible = false;
			lbUnitArray[16].AllowDrop = true;
			lbUnitArray[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[16].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[16].Name = "_lbUnitArray_16";
			lbUnitArray[16].TabIndex = 20;
			lbUnitArray[16].Text = "E03";
			lbUnitArray[16].Visible = false;
			lbUnitArray[15].AllowDrop = true;
			lbUnitArray[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[15].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[15].Name = "_lbUnitArray_15";
			lbUnitArray[15].TabIndex = 19;
			lbUnitArray[15].Text = "E03";
			lbUnitArray[15].Visible = false;
			lbUnitArray[14].AllowDrop = true;
			lbUnitArray[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[14].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[14].Name = "_lbUnitArray_14";
			lbUnitArray[14].TabIndex = 18;
			lbUnitArray[14].Text = "E03";
			lbUnitArray[14].Visible = false;
			lbUnitArray[13].AllowDrop = true;
			lbUnitArray[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[13].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[13].Name = "_lbUnitArray_13";
			lbUnitArray[13].TabIndex = 17;
			lbUnitArray[13].Text = "E03";
			lbUnitArray[13].Visible = false;
			lbUnitArray[12].AllowDrop = true;
			lbUnitArray[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[12].Name = "_lbUnitArray_12";
			lbUnitArray[12].TabIndex = 16;
			lbUnitArray[12].Text = "E03";
			lbUnitArray[12].Visible = false;
			lbUnitArray[11].AllowDrop = true;
			lbUnitArray[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[11].Name = "_lbUnitArray_11";
			lbUnitArray[11].TabIndex = 15;
			lbUnitArray[11].Text = "E03";
			lbUnitArray[11].Visible = false;
			lbUnitArray[10].AllowDrop = true;
			lbUnitArray[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[10].Name = "_lbUnitArray_10";
			lbUnitArray[10].TabIndex = 14;
			lbUnitArray[10].Text = "E03";
			lbUnitArray[10].Visible = false;
			lbUnitArray[9].AllowDrop = true;
			lbUnitArray[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[9].Name = "_lbUnitArray_9";
			lbUnitArray[9].TabIndex = 13;
			lbUnitArray[9].Text = "E03";
			lbUnitArray[9].Visible = false;
			lbUnitArray[8].AllowDrop = true;
			lbUnitArray[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[8].Name = "_lbUnitArray_8";
			lbUnitArray[8].TabIndex = 12;
			lbUnitArray[8].Text = "E03";
			lbUnitArray[8].Visible = false;
			lbUnitArray[7].AllowDrop = true;
			lbUnitArray[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[7].Name = "_lbUnitArray_7";
			lbUnitArray[7].TabIndex = 11;
			lbUnitArray[7].Text = "E03";
			lbUnitArray[7].Visible = false;
			lbUnitArray[6].AllowDrop = true;
			lbUnitArray[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[6].Name = "_lbUnitArray_6";
			lbUnitArray[6].TabIndex = 10;
			lbUnitArray[6].Text = "E03";
			lbUnitArray[6].Visible = false;
			lbUnitArray[5].AllowDrop = true;
			lbUnitArray[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[5].Name = "_lbUnitArray_5";
			lbUnitArray[5].TabIndex = 9;
			lbUnitArray[5].Text = "E03";
			lbUnitArray[5].Visible = false;
			lbUnitArray[4].AllowDrop = true;
			lbUnitArray[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[4].Name = "_lbUnitArray_4";
			lbUnitArray[4].TabIndex = 8;
			lbUnitArray[4].Text = "E03";
			lbUnitArray[4].Visible = false;
			lbUnitArray[3].AllowDrop = true;
			lbUnitArray[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[3].Name = "_lbUnitArray_3";
			lbUnitArray[3].TabIndex = 7;
			lbUnitArray[3].Text = "E03";
			lbUnitArray[3].Visible = false;
			lbUnitArray[2].AllowDrop = true;
			lbUnitArray[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[2].Name = "_lbUnitArray_2";
			lbUnitArray[2].TabIndex = 6;
			lbUnitArray[2].Text = "E03";
			lbUnitArray[2].Visible = false;
			lbUnitArray[1].AllowDrop = true;
			lbUnitArray[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[1].Name = "_lbUnitArray_1";
			lbUnitArray[1].TabIndex = 5;
			lbUnitArray[1].Text = "E03";
			lbUnitArray[1].Visible = false;
			lbUnitArray[0].AllowDrop = true;
			lbUnitArray[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbUnitArray[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnitArray[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnitArray[0].Name = "_lbUnitArray_0";
			lbUnitArray[0].TabIndex = 4;
			lbUnitArray[0].Text = "E03";
			lbUnitArray[0].Visible = false;
			lbPositionArray = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(20);
			lbPositionArray[19] = _lbPositionArray_19;
			lbPositionArray[18] = _lbPositionArray_18;
			lbPositionArray[17] = _lbPositionArray_17;
			lbPositionArray[16] = _lbPositionArray_16;
			lbPositionArray[15] = _lbPositionArray_15;
			lbPositionArray[14] = _lbPositionArray_14;
			lbPositionArray[13] = _lbPositionArray_13;
			lbPositionArray[12] = _lbPositionArray_12;
			lbPositionArray[11] = _lbPositionArray_11;
			lbPositionArray[10] = _lbPositionArray_10;
			lbPositionArray[9] = _lbPositionArray_9;
			lbPositionArray[8] = _lbPositionArray_8;
			lbPositionArray[7] = _lbPositionArray_7;
			lbPositionArray[6] = _lbPositionArray_6;
			lbPositionArray[5] = _lbPositionArray_5;
			lbPositionArray[4] = _lbPositionArray_4;
			lbPositionArray[3] = _lbPositionArray_3;
			lbPositionArray[2] = _lbPositionArray_2;
			lbPositionArray[1] = _lbPositionArray_1;
			lbPositionArray[0] = _lbPositionArray_0;
			lbPositionArray[19].AllowDrop = true;
			lbPositionArray[19].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[19].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[19].Name = "_lbPositionArray_19";
			lbPositionArray[19].TabIndex = 44;
			lbPositionArray[19].Text = "4th";
			lbPositionArray[19].Visible = false;
			lbPositionArray[18].AllowDrop = true;
			lbPositionArray[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[18].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[18].Name = "_lbPositionArray_18";
			lbPositionArray[18].TabIndex = 43;
			lbPositionArray[18].Text = "4th";
			lbPositionArray[18].Visible = false;
			lbPositionArray[17].AllowDrop = true;
			lbPositionArray[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[17].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[17].Name = "_lbPositionArray_17";
			lbPositionArray[17].TabIndex = 42;
			lbPositionArray[17].Text = "4th";
			lbPositionArray[17].Visible = false;
			lbPositionArray[16].AllowDrop = true;
			lbPositionArray[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[16].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[16].Name = "_lbPositionArray_16";
			lbPositionArray[16].TabIndex = 41;
			lbPositionArray[16].Text = "4th";
			lbPositionArray[16].Visible = false;
			lbPositionArray[15].AllowDrop = true;
			lbPositionArray[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[15].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[15].Name = "_lbPositionArray_15";
			lbPositionArray[15].TabIndex = 40;
			lbPositionArray[15].Text = "4th";
			lbPositionArray[15].Visible = false;
			lbPositionArray[14].AllowDrop = true;
			lbPositionArray[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[14].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[14].Name = "_lbPositionArray_14";
			lbPositionArray[14].TabIndex = 39;
			lbPositionArray[14].Text = "4th";
			lbPositionArray[14].Visible = false;
			lbPositionArray[13].AllowDrop = true;
			lbPositionArray[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[13].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[13].Name = "_lbPositionArray_13";
			lbPositionArray[13].TabIndex = 38;
			lbPositionArray[13].Text = "4th";
			lbPositionArray[13].Visible = false;
			lbPositionArray[12].AllowDrop = true;
			lbPositionArray[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[12].Name = "_lbPositionArray_12";
			lbPositionArray[12].TabIndex = 37;
			lbPositionArray[12].Text = "4th";
			lbPositionArray[12].Visible = false;
			lbPositionArray[11].AllowDrop = true;
			lbPositionArray[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[11].Name = "_lbPositionArray_11";
			lbPositionArray[11].TabIndex = 36;
			lbPositionArray[11].Text = "4th";
			lbPositionArray[11].Visible = false;
			lbPositionArray[10].AllowDrop = true;
			lbPositionArray[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[10].Name = "_lbPositionArray_10";
			lbPositionArray[10].TabIndex = 35;
			lbPositionArray[10].Text = "4th";
			lbPositionArray[10].Visible = false;
			lbPositionArray[9].AllowDrop = true;
			lbPositionArray[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[9].Name = "_lbPositionArray_9";
			lbPositionArray[9].TabIndex = 34;
			lbPositionArray[9].Text = "4th";
			lbPositionArray[9].Visible = false;
			lbPositionArray[8].AllowDrop = true;
			lbPositionArray[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[8].Name = "_lbPositionArray_8";
			lbPositionArray[8].TabIndex = 33;
			lbPositionArray[8].Text = "4th";
			lbPositionArray[8].Visible = false;
			lbPositionArray[7].AllowDrop = true;
			lbPositionArray[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[7].Name = "_lbPositionArray_7";
			lbPositionArray[7].TabIndex = 32;
			lbPositionArray[7].Text = "4th";
			lbPositionArray[7].Visible = false;
			lbPositionArray[6].AllowDrop = true;
			lbPositionArray[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[6].Name = "_lbPositionArray_6";
			lbPositionArray[6].TabIndex = 31;
			lbPositionArray[6].Text = "4th";
			lbPositionArray[6].Visible = false;
			lbPositionArray[5].AllowDrop = true;
			lbPositionArray[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[5].Name = "_lbPositionArray_5";
			lbPositionArray[5].TabIndex = 30;
			lbPositionArray[5].Text = "4th";
			lbPositionArray[5].Visible = false;
			lbPositionArray[4].AllowDrop = true;
			lbPositionArray[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[4].Name = "_lbPositionArray_4";
			lbPositionArray[4].TabIndex = 29;
			lbPositionArray[4].Text = "4th";
			lbPositionArray[4].Visible = false;
			lbPositionArray[3].AllowDrop = true;
			lbPositionArray[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[3].Name = "_lbPositionArray_3";
			lbPositionArray[3].TabIndex = 28;
			lbPositionArray[3].Text = "4th";
			lbPositionArray[3].Visible = false;
			lbPositionArray[2].AllowDrop = true;
			lbPositionArray[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[2].Name = "_lbPositionArray_2";
			lbPositionArray[2].TabIndex = 27;
			lbPositionArray[2].Text = "4th";
			lbPositionArray[2].Visible = false;
			lbPositionArray[1].AllowDrop = true;
			lbPositionArray[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[1].Name = "_lbPositionArray_1";
			lbPositionArray[1].TabIndex = 26;
			lbPositionArray[1].Text = "4th";
			lbPositionArray[1].Visible = false;
			lbPositionArray[0].AllowDrop = true;
			lbPositionArray[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPositionArray[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPositionArray[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbPositionArray[0].Name = "_lbPositionArray_0";
			lbPositionArray[0].TabIndex = 25;
			lbPositionArray[0].Text = "INCHARG";
			lbPositionArray[0].Visible = false;
			lstLeave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ListBoxViewModel>>(7);
			lstLeave[6] = _lstLeave_6;
			lstLeave[5] = _lstLeave_5;
			lstLeave[4] = _lstLeave_4;
			lstLeave[3] = _lstLeave_3;
			lstLeave[2] = _lstLeave_2;
			lstLeave[1] = _lstLeave_1;
			lstLeave[0] = _lstLeave_0;
			lstLeave[6].AllowDrop = true;
			lstLeave[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[6].Enabled = true;
			lstLeave[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[6].Name = "_lstLeave_6";
			lstLeave[6].TabIndex = 219;
			lstLeave[6].Visible = true;
			lstLeave[5].AllowDrop = true;
			lstLeave[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[5].Enabled = true;
			lstLeave[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[5].Name = "_lstLeave_5";
			lstLeave[5].TabIndex = 218;
			lstLeave[5].Visible = true;
			lstLeave[4].AllowDrop = true;
			lstLeave[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[4].Enabled = true;
			lstLeave[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[4].Name = "_lstLeave_4";
			lstLeave[4].TabIndex = 217;
			lstLeave[4].Visible = true;
			lstLeave[3].AllowDrop = true;
			lstLeave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[3].Enabled = true;
			lstLeave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[3].Name = "_lstLeave_3";
			lstLeave[3].TabIndex = 216;
			lstLeave[3].Visible = true;
			lstLeave[2].AllowDrop = true;
			lstLeave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[2].Enabled = true;
			lstLeave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[2].Name = "_lstLeave_2";
			lstLeave[2].TabIndex = 215;
			lstLeave[2].Visible = true;
			lstLeave[1].AllowDrop = true;
			lstLeave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[1].Enabled = true;
			lstLeave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[1].Name = "_lstLeave_1";
			lstLeave[1].TabIndex = 214;
			lstLeave[1].Visible = true;
			lstLeave[0].AllowDrop = true;
			lstLeave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			lstLeave[0].Enabled = true;
			lstLeave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			lstLeave[0].Name = "_lstLeave_0";
			lstLeave[0].TabIndex = 213;
			lstLeave[0].Visible = true;
			lstLeave[6].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[5].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[4].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[3].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[2].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[1].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lstLeave[0].SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			lbAMPM = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(20);
			lbAMPM[19] = _lbAMPM_19;
			lbAMPM[18] = _lbAMPM_18;
			lbAMPM[17] = _lbAMPM_17;
			lbAMPM[16] = _lbAMPM_16;
			lbAMPM[15] = _lbAMPM_15;
			lbAMPM[14] = _lbAMPM_14;
			lbAMPM[13] = _lbAMPM_13;
			lbAMPM[12] = _lbAMPM_12;
			lbAMPM[11] = _lbAMPM_11;
			lbAMPM[10] = _lbAMPM_10;
			lbAMPM[9] = _lbAMPM_9;
			lbAMPM[8] = _lbAMPM_8;
			lbAMPM[7] = _lbAMPM_7;
			lbAMPM[6] = _lbAMPM_6;
			lbAMPM[5] = _lbAMPM_5;
			lbAMPM[4] = _lbAMPM_4;
			lbAMPM[3] = _lbAMPM_3;
			lbAMPM[2] = _lbAMPM_2;
			lbAMPM[1] = _lbAMPM_1;
			lbAMPM[0] = _lbAMPM_0;
			lbAMPM[19].AllowDrop = true;
			lbAMPM[19].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[19].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[19].Name = "_lbAMPM_19";
			lbAMPM[19].TabIndex = 205;
			lbAMPM[19].Text = "PM";
			lbAMPM[19].Visible = false;
			lbAMPM[18].AllowDrop = true;
			lbAMPM[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[18].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[18].Name = "_lbAMPM_18";
			lbAMPM[18].TabIndex = 204;
			lbAMPM[18].Text = "AM";
			lbAMPM[18].Visible = false;
			lbAMPM[17].AllowDrop = true;
			lbAMPM[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[17].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[17].Name = "_lbAMPM_17";
			lbAMPM[17].TabIndex = 203;
			lbAMPM[17].Text = "PM";
			lbAMPM[17].Visible = false;
			lbAMPM[16].AllowDrop = true;
			lbAMPM[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[16].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[16].Name = "_lbAMPM_16";
			lbAMPM[16].TabIndex = 202;
			lbAMPM[16].Text = "AM";
			lbAMPM[16].Visible = false;
			lbAMPM[15].AllowDrop = true;
			lbAMPM[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[15].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[15].Name = "_lbAMPM_15";
			lbAMPM[15].TabIndex = 201;
			lbAMPM[15].Text = "PM";
			lbAMPM[15].Visible = false;
			lbAMPM[14].AllowDrop = true;
			lbAMPM[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[14].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[14].Name = "_lbAMPM_14";
			lbAMPM[14].TabIndex = 200;
			lbAMPM[14].Text = "AM";
			lbAMPM[14].Visible = false;
			lbAMPM[13].AllowDrop = true;
			lbAMPM[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[13].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[13].Name = "_lbAMPM_13";
			lbAMPM[13].TabIndex = 199;
			lbAMPM[13].Text = "PM";
			lbAMPM[13].Visible = false;
			lbAMPM[12].AllowDrop = true;
			lbAMPM[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[12].Name = "_lbAMPM_12";
			lbAMPM[12].TabIndex = 198;
			lbAMPM[12].Text = "AM";
			lbAMPM[12].Visible = false;
			lbAMPM[11].AllowDrop = true;
			lbAMPM[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[11].Name = "_lbAMPM_11";
			lbAMPM[11].TabIndex = 197;
			lbAMPM[11].Text = "PM";
			lbAMPM[11].Visible = false;
			lbAMPM[10].AllowDrop = true;
			lbAMPM[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[10].Name = "_lbAMPM_10";
			lbAMPM[10].TabIndex = 196;
			lbAMPM[10].Text = "AM";
			lbAMPM[10].Visible = false;
			lbAMPM[9].AllowDrop = true;
			lbAMPM[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[9].Name = "_lbAMPM_9";
			lbAMPM[9].TabIndex = 195;
			lbAMPM[9].Text = "PM";
			lbAMPM[9].Visible = false;
			lbAMPM[8].AllowDrop = true;
			lbAMPM[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[8].Name = "_lbAMPM_8";
			lbAMPM[8].TabIndex = 194;
			lbAMPM[8].Text = "AM";
			lbAMPM[8].Visible = false;
			lbAMPM[7].AllowDrop = true;
			lbAMPM[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[7].Name = "_lbAMPM_7";
			lbAMPM[7].TabIndex = 193;
			lbAMPM[7].Text = "PM";
			lbAMPM[7].Visible = false;
			lbAMPM[6].AllowDrop = true;
			lbAMPM[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[6].Name = "_lbAMPM_6";
			lbAMPM[6].TabIndex = 192;
			lbAMPM[6].Text = "AM";
			lbAMPM[6].Visible = false;
			lbAMPM[5].AllowDrop = true;
			lbAMPM[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[5].Name = "_lbAMPM_5";
			lbAMPM[5].TabIndex = 191;
			lbAMPM[5].Text = "PM";
			lbAMPM[5].Visible = false;
			lbAMPM[4].AllowDrop = true;
			lbAMPM[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[4].Name = "_lbAMPM_4";
			lbAMPM[4].TabIndex = 190;
			lbAMPM[4].Text = "AM";
			lbAMPM[4].Visible = false;
			lbAMPM[3].AllowDrop = true;
			lbAMPM[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[3].Name = "_lbAMPM_3";
			lbAMPM[3].TabIndex = 189;
			lbAMPM[3].Text = "PM";
			lbAMPM[3].Visible = false;
			lbAMPM[2].AllowDrop = true;
			lbAMPM[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[2].Name = "_lbAMPM_2";
			lbAMPM[2].TabIndex = 188;
			lbAMPM[2].Text = "AM";
			lbAMPM[2].Visible = false;
			lbAMPM[1].AllowDrop = true;
			lbAMPM[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			lbAMPM[1].Name = "_lbAMPM_1";
			lbAMPM[1].TabIndex = 187;
			lbAMPM[1].Text = "PM";
			lbAMPM[1].Visible = false;
			lbAMPM[0].AllowDrop = true;
			lbAMPM[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbAMPM[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbAMPM[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbAMPM[0].Name = "_lbAMPM_0";
			lbAMPM[0].TabIndex = 186;
			lbAMPM[0].Text = "AM";
			lbAMPM[0].Visible = false;
			Line1 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(9);
			Line1[8] = _Line1_8;
			Line1[7] = _Line1_7;
			Line1[6] = _Line1_6;
			Line1[5] = _Line1_5;
			Line1[4] = _Line1_4;
			Line1[3] = _Line1_3;
			Line1[2] = _Line1_2;
			Line1[0] = _Line1_0;
			Line1[1] = _Line1_1;
			Line1[8].AllowDrop = true;
			Line1[8].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[8].Enabled = false;
			Line1[8].Name = "_Line1_8";
			Line1[8].Visible = false;
			Line1[7].AllowDrop = true;
			Line1[7].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[7].Enabled = false;
			Line1[7].Name = "_Line1_7";
			Line1[7].Visible = false;
			Line1[6].AllowDrop = true;
			Line1[6].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[6].Enabled = false;
			Line1[6].Name = "_Line1_6";
			Line1[6].Visible = false;
			Line1[5].AllowDrop = true;
			Line1[5].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[5].Enabled = false;
			Line1[5].Name = "_Line1_5";
			Line1[5].Visible = false;
			Line1[4].AllowDrop = true;
			Line1[4].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[4].Enabled = false;
			Line1[4].Name = "_Line1_4";
			Line1[4].Visible = false;
			Line1[3].AllowDrop = true;
			Line1[3].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[3].Enabled = false;
			Line1[3].Name = "_Line1_3";
			Line1[3].Visible = false;
			Line1[2].AllowDrop = true;
			Line1[2].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[2].Enabled = false;
			Line1[2].Name = "_Line1_2";
			Line1[2].Visible = false;
			Line1[0].AllowDrop = true;
			Line1[0].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[0].Enabled = false;
			Line1[0].Name = "_Line1_0";
			Line1[0].Visible = false;
			Line1[1].AllowDrop = true;
			Line1[1].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			Line1[1].Enabled = false;
			Line1[1].Name = "_Line1_1";
			Line1[1].Visible = false;
			this.DoNotLock = false;
			this.SelectedLabel = null;
			this.SelectedSA = "";
			this.SelectedSAName = "";
			this.SelectedDate = "";
			this.ClickedLeave = false;
			this.Name = "PTSProject.frmWeekly";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintPayReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSystem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEmpInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSeniorInq { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuImmune { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_transfer_req { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPMCerts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSDaily { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHazmat { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_watch_duty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Vacation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HZMVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_old { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuFRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_DDGroups { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuProlist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSenior { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_emp_facility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuAuditDDHOL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndivPayrollSO { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuperson { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBDWork { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHazPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMarPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDisPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndYearSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuOvertime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuExtraOff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sa_report { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuShiftCal { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTransfer { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedul { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAnnual { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_dailysickleave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sick_usage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatchLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HZMLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuLeaveReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnutimecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndAnnualPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupersonnelsignoff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayrollReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_QuarterlyMinimumDrill { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_FCCMinDrills { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_ReadingAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_OTEPReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMRecertReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMBaseStaReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_trainingtracker { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndTrainReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndPMRecert { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuALSProc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrnReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingQuerynew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Queries { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTraining { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCascade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintScreen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuWindow { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuContents { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAbout { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HelpPrntScrn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_timecodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payrolllegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_legend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndLegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payup_calc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainCodeHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayUp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayDown { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuKOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_viewtimecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuViewDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuWeeklyPopUp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFullList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picTrash { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSelectName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel _lstLeave_0 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calWeek { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllStaff { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP10am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP9am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP8am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP7am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP6am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP5am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP4am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP3am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP2am_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1pm_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpP1am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbShiftArray_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAMPM_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos10am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos9am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos8am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos7pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos6am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos5am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos4am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos3am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos2am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1pm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPos1am_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbWeekDay_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionArray_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnitArray_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocked { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel pnSelected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripViewModel Ctx_mnuWeeklyPopUp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SchedLock { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos1am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos1pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos2am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos2pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos3am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos3pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos4am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos4pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos5am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos5pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos6am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos6pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos7am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos7pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos8am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos8pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos9am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos9pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos10am { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPos10pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbWeekDay { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP1am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP1pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP2am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP2pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP3am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP3pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP4am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP4pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP5am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP5pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP6am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP6pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP7am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP7pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP8am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP8pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP9am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP9pm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP10am { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpP10pm { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbShiftArray { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbUnitArray { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPositionArray { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ListBoxViewModel> lstLeave { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbAMPM { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean DoNotLock { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.Helpers.ControlViewModel SelectedLabel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSA { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSAName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean ClickedLeave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}