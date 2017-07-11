using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.MDIForm1))]
	public class MDIForm1ViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);

            // 
            // mnuExit
            // 
            this.mnuExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuExit.Available = true;
			this.mnuExit.Enabled = true;
			this.mnuExit.Text = "Exit";
            // 
            // mnuSystem
            // 
            this.mnuSystem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSystem.Available = true;
			this.mnuSystem.Enabled = true;
			this.mnuSystem.Text = "System";
            // 
            // mnuAddnew
            // 
            this.mnuAddnew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuAddnew.Available = true;
			this.mnuAddnew.Enabled = true;
			this.mnuAddnew.Text = "Add New Employee";
            // 
            // mnuEmpInfo
            // 
            this.mnuEmpInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuEmpInfo.Available = true;
			this.mnuEmpInfo.Enabled = true;
			this.mnuEmpInfo.Text = "Update Employee Information";
            // 
            // mnuPosition
            // 
            this.mnuPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPosition.Available = true;
			this.mnuPosition.Enabled = true;
			this.mnuPosition.Text = "Assign Employee Position";
            // 
            // mnuPhone
            // 
            this.mnuPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPhone.Available = true;
			this.mnuPhone.Enabled = true;
			this.mnuPhone.Text = "Manage Phone List";
            // 
            // mnuAddress
            // 
            this.mnuAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuAddress.Available = true;
			this.mnuAddress.Enabled = true;
			this.mnuAddress.Text = "Manage Address List";
            // 
            // mnuEmergency
            // 
            this.mnuEmergency = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuEmergency.Available = true;
			this.mnuEmergency.Enabled = true;
			this.mnuEmergency.Text = "Manage Emergency Contacts";
            // 
            // mnuImmune
            // 
            this.mnuImmune = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuImmune.Available = true;
			this.mnuImmune.Enabled = true;
            this.mnuImmune.Text = "Manage Employee Immunizations";
            // 
            // mnuPromoli
            // 
            this.mnuPromoli = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPromoli.Available = true;
			this.mnuPromoli.Enabled = true;
			this.mnuPromoli.Text = "Update Promotion Lists";
            // 
            // mnuSeniorInq
            // 
            this.mnuSeniorInq = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuSeniorInq.Available = true;
			this.mnuSeniorInq.Enabled = true;
			this.mnuSeniorInq.Text = "Seniority Ranking Inquiry";
            // 
            // mnu_transfer_req
            // 
            this.mnu_transfer_req = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_transfer_req.Available = true;
			this.mnu_transfer_req.Enabled = true;
			this.mnu_transfer_req.Text = "Manage Requests For Transfer";
            // 
            // mnuPMCerts
            // 
            this.mnuPMCerts = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPMCerts.Available = true;
			this.mnuPMCerts.Enabled = true;
			this.mnuPMCerts.Text = "Manage Paramedic Certifications";
            // 
            // mnuPPE (Remove This?)
            // 
            this.mnuPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPPE.Available = true;
			this.mnuPPE.Enabled = true;
			this.mnuPPE.Text = "Manage WDL and PPE Info";
            //
			this._mnuPersonnel_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            // 
            // mnuIndSchedule
            // 
            this.mnuIndSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuIndSchedule.Available = true;
			this.mnuIndSchedule.Enabled = true;
			this.mnuIndSchedule.Text = "Individual Schedule";
            // 
            // mnuBattalion (Battalion 1)
            // 
            this.mnuBattalion = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBattalion.Available = true;
			this.mnuBattalion.Enabled = true;
			this.mnuBattalion.Text = "Battalion 1 Schedule";
            // 
            // mnuBattalion2 (Battalion 2)
            // 
            this.mnuBattalion2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBattalion2.Available = true;
			this.mnuBattalion2.Enabled = true;
			this.mnuBattalion2.Text = "Battalion 2 Schedule";
            // 
            // mnuNewBatt3 (Battalion 3)
            // 
            this.mnuNewBatt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuNewBatt3.Available = true;
			this.mnuNewBatt3.Enabled = true;
			this.mnuNewBatt3.Text = "Battalion 3 Schedule";
            // 
            // mnuBattalion3 (Battalion 4)
            // 
            this.mnuBattalion3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBattalion3.Available = true;
			this.mnuBattalion3.Enabled = true;
			this.mnuBattalion3.Text = "Batt 4 Sched (Special Unit)";
            // 
            // mnuBattalion4 (Battalion 5)
            // 
            this.mnuBattalion4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBattalion4.Available = true;
			this.mnuBattalion4.Enabled = true;
			this.mnuBattalion4.Text = "Batt 5 Sched (Reserve Unit)";
            // 
            // mnuEMS
            // 
            this.mnuEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuEMS.Available = true;
			this.mnuEMS.Enabled = true;
			this.mnuEMS.Text = "EMS Schedule";
            // 
            // mnuEMSDaily (Remove This)
            // 
            this.mnuEMSDaily = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuEMSDaily.Available = true;
			this.mnuEMSDaily.Enabled = true;
			this.mnuEMSDaily.Text = "EMS Daily Scheduler";
            // 
            // mnuHazmat
            // 
            this.mnuHazmat = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuHazmat.Available = true;
			this.mnuHazmat.Enabled = true;
			this.mnuHazmat.Text = "Hazmat Schedule";
            // 
            // mnuMarine
            // 
            this.mnuMarine = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuMarine.Available = true;
			this.mnuMarine.Enabled = true;
			this.mnuMarine.Text = "Marine Schedule";
            // 
            // mnuBattStaff
            // 
            this.mnuBattStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBattStaff.Available = true;
			this.mnuBattStaff.Enabled = true;
            this.mnuBattStaff.Text = "Battalion Staff Schedule";
            // 
            // mnuDispatch
            // 
            this.mnuDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuDispatch.Available = true;
			this.mnuDispatch.Enabled = true;
			this.mnuDispatch.Text = "Dispatch Schedule";
            // 
            // mnu_watch_duty
            // 
            this.mnu_watch_duty = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_watch_duty.Available = true;
			this.mnu_watch_duty.Enabled = true;
			this.mnu_watch_duty.Text = "Assign Watch Duty ";
            // 
            // mnu_Vacation (Need Yearly Calander Control)
            // 
            this.mnu_Vacation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Vacation.Available = true;
			this.mnu_Vacation.Enabled = true;
			this.mnu_Vacation.Text = "Vacation Scheduler";
            // 
            // mnu_PMVacationSched (Need Yearly Calander Control)
            // 
            this.mnu_PMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PMVacationSched.Available = true;
			this.mnu_PMVacationSched.Enabled = true;
			this.mnu_PMVacationSched.Text = "Paramedic Vacation Scheduler";
            // 
            // mnu_HZMVacationSched (Need Yearly Calander Control)
            // 
            this.mnu_HZMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_HZMVacationSched.Available = true;
			this.mnu_HZMVacationSched.Enabled = true;
			this.mnu_HZMVacationSched.Text = "Hazmat Vacation Scheduler";
            // 
            // mnu_FCCVacationSched (Need Yearly Calander Control)
            // 
            this.mnu_FCCVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_FCCVacationSched.Available = true;
			this.mnu_FCCVacationSched.Enabled = true;
			this.mnu_FCCVacationSched.Text = "Dispatch Vacation Available";
            // 
            // mnuNewBatt1 (Remove This)
            // 
            this.mnuNewBatt1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuNewBatt1.Available = true;
			this.mnuNewBatt1.Enabled = true;
			this.mnuNewBatt1.Text = "New Battalion 1 Scheduler";
            // 
            // mnuNewBatt2 (Remove This)
            // 
            this.mnuNewBatt2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuNewBatt2.Available = true;
			this.mnuNewBatt2.Enabled = true;
			this.mnuNewBatt2.Text = "New Battalion 2 Scheduler";
            // 
            // mnu_old  (Remove This)
            // 
            this.mnu_old = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_old.Available = false;
			this.mnu_old.Enabled = true;
			this.mnu_old.Text = "Hidden Battalion Schedulers";
            // 
            // mnuSchedule
            // 
            this.mnuSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuSchedule.Available = true;
			this.mnuSchedule.Enabled = true;
			this.mnuSchedule.Text = "Scheduling";
            // 
            // mnuAssign
            // 
            this.mnuAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuAssign.Available = true;
			this.mnuAssign.Enabled = true;
			this.mnuAssign.Text = "Assignments";
            // 
            // mnuRoster
            // 
            this.mnuRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuRoster.Available = true;
			this.mnuRoster.Enabled = true;
			this.mnuRoster.Text = "Roster";
            // 
            // mnuFRoster
            // 
            this.mnuFRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuFRoster.Available = true;
			this.mnuFRoster.Enabled = true;
			this.mnuFRoster.Text = "Filtered Roster";
            // 
            // mnuPublicRoster
            // 
            this.mnuPublicRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPublicRoster.Available = true;
			this.mnuPublicRoster.Enabled = true;
			this.mnuPublicRoster.Text = "Public Roster";
            // 
            // mnu_DDGroups
            // 
            this.mnu_DDGroups = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_DDGroups.Available = true;
			this.mnu_DDGroups.Enabled = true;
			this.mnu_DDGroups.Text = "Debit Day Groups";
            // 
            // mnuProlist
            // 
            this.mnuProlist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuProlist.Available = true;
			this.mnuProlist.Enabled = true;
			this.mnuProlist.Text = "Promotion Lists";
            // 
            // mnuSenior
            // 
            this.mnuSenior = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuSenior.Available = true;
			this.mnuSenior.Enabled = true;
			this.mnuSenior.Text = "Seniority Ranking Lists";
            // 
            // mnuBenefit
            // 
            this.mnuBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBenefit.Available = true;
			this.mnuBenefit.Enabled = true;
			this.mnuBenefit.Text = "CF1 Benefit Listing";
            // 
            // mnu_dailydispatchwork
            // 
            this.mnu_dailydispatchwork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_dailydispatchwork.Available = false;
			this.mnu_dailydispatchwork.Enabled = true;
			this.mnu_dailydispatchwork.Text = "Daily Dispatch Work Report";
            // 
            // mnu_rankedops
            // 
            this.mnu_rankedops = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_rankedops.Available = true;
			this.mnu_rankedops.Enabled = true;
			this.mnu_rankedops.Text = "Ranked Operation Staff List";
            // 
            // mnu_emp_facility
            // 
            this.mnu_emp_facility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_emp_facility.Available = true;
			this.mnu_emp_facility.Enabled = true;
			this.mnu_emp_facility.Text = "Employee List by Facility";
            // 
            // MnuAuditDDHOL
            // 
            this.MnuAuditDDHOL = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.MnuAuditDDHOL.Available = true;
			this.MnuAuditDDHOL.Enabled = true;
			this.MnuAuditDDHOL.Text = "Debit Day / Holiday Audit";
            // 
            // mnu_IndivPayrollSO
            // 
            this.mnu_IndivPayrollSO = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_IndivPayrollSO.Available = true;
			this.mnu_IndivPayrollSO.Enabled = true;
			this.mnu_IndivPayrollSO.Text = "Individual Payroll SignOff ";
            // 
            // mnuIndTimeCard2
            // 
            this.mnuIndTimeCard2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuIndTimeCard2.Available = true;
			this.mnuIndTimeCard2.Enabled = true;
			this.mnuIndTimeCard2.Text = "Individual Time Cards";
            // 
            // mnuPhoneList
            // 
            this.mnuPhoneList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPhoneList.Available = true;
			this.mnuPhoneList.Enabled = true;
			this.mnuPhoneList.Text = "Master Phone Lists";
            //
			this._mnuPerson_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            // 
            // mnu181
            // 
            this.mnu181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu181.Available = true;
			this.mnu181.Enabled = true;
			this.mnu181.Text = "Battalion 1";
            // 
            // mnu182
            // 
            this.mnu182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu182.Available = true;
			this.mnu182.Enabled = true;
			this.mnu182.Text = "Battalion 2";
            // 
            // mnu183
            // 
            this.mnu183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu183.Available = true;
			this.mnu183.Enabled = true;
			this.mnu183.Text = "Battalion 3";
            // 
            // mnuBDWork
            // 
            this.mnuBDWork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBDWork.Available = true;
			this.mnuBDWork.Enabled = true;
			this.mnuBDWork.Text = "Battalion TimeCard Worksheets";
            // 
            // mnuEMSWeekly
            // 
            this.mnuEMSWeekly = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuEMSWeekly.Available = true;
			this.mnuEMSWeekly.Enabled = true;
			this.mnuEMSWeekly.Text = "EMS";
            // 
            // mnuHZMWeekly
            // 
            this.mnuHZMWeekly = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuHZMWeekly.Available = true;
			this.mnuHZMWeekly.Enabled = true;
			this.mnuHZMWeekly.Text = "HazMat";
            // 
            // mnuMRNWeekly
            // 
            this.mnuMRNWeekly = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuMRNWeekly.Available = true;
			this.mnuMRNWeekly.Enabled = true;
			this.mnuMRNWeekly.Text = "Marine";
            // 
            // mnuBatWeekly
            // 
            this.mnuBatWeekly = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuBatWeekly.Available = true;
			this.mnuBatWeekly.Enabled = true;
			this.mnuBatWeekly.Text = "Battalion Staff";
            // 
            // mnuDispWeekly
            // 
            this.mnuDispWeekly = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuDispWeekly.Available = true;
			this.mnuDispWeekly.Enabled = true;
			this.mnuDispWeekly.Text = "Dispatch Staff";
            // 
            // mnuWeek
            // 
            this.mnuWeek = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuWeek.Available = true;
			this.mnuWeek.Enabled = true;
			this.mnuWeek.Text = "Exception Worksheets";
            // 
            // mnuIndYearSched
            // 
            this.mnuIndYearSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuIndYearSched.Available = true;
			this.mnuIndYearSched.Enabled = true;
			this.mnuIndYearSched.Text = "Individual Yearly Schedule";
            // 
            // mnuDailyStaffing
            // 
            this.mnuDailyStaffing = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuDailyStaffing.Available = true;
			this.mnuDailyStaffing.Enabled = true;
			this.mnuDailyStaffing.Text = "Daily Staffing Report";
            // 
            // mnuOvertime
            // 
            this.mnuOvertime = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuOvertime.Available = true;
			this.mnuOvertime.Enabled = true;
			this.mnuOvertime.Text = "Overtime Detail Report";
            // 
            // mnuExtraOff
            // 
            this.mnuExtraOff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuExtraOff.Available = true;
			this.mnuExtraOff.Enabled = true;
			this.mnuExtraOff.Text = "Extra-Unplanned Days Off Report";
            // 
            // mnu_sa_report
            //
            this.mnu_sa_report = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_sa_report.Available = true;
			this.mnu_sa_report.Enabled = true;
            this.mnu_sa_report.Text = "Special Assignment Yearly Report";
            // 
            // mnuCalendar
            // 
            this.mnuCalendar = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCalendar.Available = true;
			this.mnuCalendar.Enabled = true;
			this.mnuCalendar.Text = "Shift Calendar";
            // 
            // mnuTransfer
            // 
            this.mnuTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTransfer.Available = true;
			this.mnuTransfer.Enabled = true;
			this.mnuTransfer.Text = "Transfer Schedule";
            // 
            // mnuSchedul
            // 
            this.mnuSchedul = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuSchedul.Available = true;
			this.mnuSchedul.Enabled = true;
			this.mnuSchedul.Text = "Schedule";
            // 
            // mnu_daily
            // 
            this.mnu_daily = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_daily.Available = true;
			this.mnu_daily.Enabled = true;
			this.mnu_daily.Text = "Daily Leave";
            // 
            // mnu_Annual
            // 
            this.mnu_Annual = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Annual.Available = true;
			this.mnu_Annual.Enabled = true;
			this.mnu_Annual.Text = "Annual Leave";
            // 
            // mnu_dailysickleave
            // 
            this.mnu_dailysickleave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_dailysickleave.Available = true;
			this.mnu_dailysickleave.Enabled = true;
			this.mnu_dailysickleave.Text = "Daily Sick Leave";
            // 
            // mnu_Individual
            // 
            this.mnu_Individual = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Individual.Available = true;
			this.mnu_Individual.Enabled = true;
			this.mnu_Individual.Text = "Individual Leave";
            // 
            // mnu_sick_usage
            // 
            this.mnu_sick_usage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_sick_usage.Available = true;
			this.mnu_sick_usage.Enabled = true;
			this.mnu_sick_usage.Text = "Sick Leave Usage Report";
            // 
            // mnu_PMLeave
            // 
            this.mnu_PMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PMLeave.Available = true;
			this.mnu_PMLeave.Enabled = true;
			this.mnu_PMLeave.Text = "Paramedic Leave Report";
            // 
            // mnuDispatchLeave
            // 
            this.mnuDispatchLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuDispatchLeave.Available = true;
			this.mnuDispatchLeave.Enabled = true;
			this.mnuDispatchLeave.Text = "Dispatch Leave Report";
            // 
            // mnu_HZMLeave
            // 
            this.mnu_HZMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_HZMLeave.Available = true;
			this.mnu_HZMLeave.Enabled = true;
			this.mnu_HZMLeave.Text = "Hazmat Leave Report";
            // 
            // mnu_Leave
            // 
            this.mnu_Leave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Leave.Available = true;
			this.mnu_Leave.Enabled = true;
			this.mnu_Leave.Text = "Leave";
            // 
            // mnuCBStaffing
            // 
            this.mnuCBStaffing = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCBStaffing.Available = true;
			this.mnuCBStaffing.Enabled = true;
			this.mnuCBStaffing.Text = "Staffing To Determine Callbacks";
            // 
            // mnu_LeaveNoSched
            // 
            this.mnu_LeaveNoSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_LeaveNoSched.Available = true;
			this.mnu_LeaveNoSched.Enabled = true;
			this.mnu_LeaveNoSched.Text = "Leave without Schedule";
            // 
            // mnuInsteadOfSCKLeave
            // 
            this.mnuInsteadOfSCKLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuInsteadOfSCKLeave.Available = true;
			this.mnuInsteadOfSCKLeave.Enabled = true;
			this.mnuInsteadOfSCKLeave.Text = "Instead Of SCK Leave List";
            // 
            // mnu_staffdiscrepancy
            // 
            this.mnu_staffdiscrepancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_staffdiscrepancy.Available = true;
			this.mnu_staffdiscrepancy.Enabled = true;
			this.mnu_staffdiscrepancy.Text = "Staffing Discrepancy";
            // 
            // mnu_PMCSRCalc
            // 
            this.mnu_PMCSRCalc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PMCSRCalc.Available = true;
			this.mnu_PMCSRCalc.Enabled = true;
			this.mnu_PMCSRCalc.Text = "Paramedic CSR Calculator";
            // 
            // mnu_EmpNotes
            // 
            this.mnu_EmpNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_EmpNotes.Available = true;
			this.mnu_EmpNotes.Enabled = true;
			this.mnu_EmpNotes.Text = "Add Employee Notes";
            // 
            // mnu_SchedNotes
            // 
            this.mnu_SchedNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_SchedNotes.Available = true;
			this.mnu_SchedNotes.Enabled = true;
			this.mnu_SchedNotes.Text = "Query Personnel Sched Notes";
            // 
            // mnuCycleHrs
            // 
            this.mnuCycleHrs = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCycleHrs.Available = true;
			this.mnuCycleHrs.Enabled = true;
			this.mnuCycleHrs.Text = "Employee Working Hrs By Cycle";
            // 
            // mnu_PPEQuery
            // 
            this.mnu_PPEQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PPEQuery.Available = true;
			this.mnu_PPEQuery.Enabled = true;
			this.mnu_PPEQuery.Text = "PPE Query Tool";
            // 
            // mnu_Battalion
            // 
            this.mnu_Battalion = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Battalion.Available = true;
			this.mnu_Battalion.Enabled = true;
			this.mnu_Battalion.Text = "Battalion";
            // 
            // mnuPPAudit
            // 
            this.mnuPPAudit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPPAudit.Available = true;
			this.mnuPPAudit.Enabled = true;
			this.mnuPPAudit.Text = "Pay Period Audit";
            // 
            // mnuTimeCard
            // 
            this.mnuTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTimeCard.Available = true;
			this.mnuTimeCard.Enabled = true;
			this.mnuTimeCard.Text = "Individual Time Cards";
            // 
            // mnuIndAnnualPayroll
            // 
            this.mnuIndAnnualPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuIndAnnualPayroll.Available = true;
			this.mnuIndAnnualPayroll.Enabled = true;
			this.mnuIndAnnualPayroll.Text = "Individual Payroll Report";
            // 
            // mnu_personnelsignoff
            // 
            this.mnu_personnelsignoff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_personnelsignoff.Available = true;
			this.mnu_personnelsignoff.Enabled = true;
			this.mnu_personnelsignoff.Text = "Payroll Sign Off ";
            // 
            // mnu_BCApprovedTC
            // 
            this.mnu_BCApprovedTC = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_BCApprovedTC.Available = true;
			this.mnu_BCApprovedTC.Enabled = true;
			this.mnu_BCApprovedTC.Text = "BC Approved Payroll Report";

            // 
            // mnuPayrollReports
            // 
            this.mnuPayrollReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPayrollReports.Available = true;
			this.mnuPayrollReports.Enabled = true;
			this.mnuPayrollReports.Text = "Payroll";

            // 
            // mnu_QuarterlyMinimumDrill
            // 
            this.mnu_QuarterlyMinimumDrill = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_QuarterlyMinimumDrill.Available = true;
			this.mnu_QuarterlyMinimumDrill.Enabled = true;
			this.mnu_QuarterlyMinimumDrill.Text = "Minimum Standards Drills";

            // 
            // mnu_FCCMinDrills
            // 
            this.mnu_FCCMinDrills = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_FCCMinDrills.Available = true;
			this.mnu_FCCMinDrills.Enabled = true;
			this.mnu_FCCMinDrills.Text = "FCC Min Standards Drills";

            // 
            // mnu_ReadingAssign
            // 
            this.mnu_ReadingAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_ReadingAssign.Available = true;
			this.mnu_ReadingAssign.Enabled = true;
			this.mnu_ReadingAssign.Text = "Required Reading Assignments";

            // 
            // mnu_OTEPReport
            // 
            this.mnu_OTEPReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_OTEPReport.Available = true;
			this.mnu_OTEPReport.Enabled = true;
			this.mnu_OTEPReport.Text = "Annual OTEP Training Report";

            // 
            // mnu_PMRecertReport
            // 
            this.mnu_PMRecertReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PMRecertReport.Available = true;
			this.mnu_PMRecertReport.Enabled = true;
			this.mnu_PMRecertReport.Text = "Paramedic Recertification Report";

            // 
            // mnu_PMBaseStaReport
            // 
            this.mnu_PMBaseStaReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_PMBaseStaReport.Available = true;
			this.mnu_PMBaseStaReport.Enabled = true;
			this.mnu_PMBaseStaReport.Text = "Paramedic Base Station Report";

            // 
            // mnu_TrainingQuerynew
            // 
            this.mnu_TrainingQuerynew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_TrainingQuerynew.Available = true;
			this.mnu_TrainingQuerynew.Enabled = true;
			this.mnu_TrainingQuerynew.Text = "Training Query Tool";

            // 
            // mnu_TrainingReports
            // 
            this.mnu_TrainingReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_TrainingReports.Available = true;
			this.mnu_TrainingReports.Enabled = true;
			this.mnu_TrainingReports.Text = "Training";

            // 
            // mnuReports
            // 
            this.mnuReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuReports.Available = true;
			this.mnuReports.Enabled = true;
			this.mnuReports.Text = "Reports";

            // 
            // mnu_trainingtracker
            // 
            this.mnu_trainingtracker = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_trainingtracker.Available = true;
			this.mnu_trainingtracker.Enabled = true;
			this.mnu_trainingtracker.Text = "Field Training Tracker";

            // 
            // mnu_IndTrainReport
            // 
            this.mnu_IndTrainReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_IndTrainReport.Available = true;
			this.mnu_IndTrainReport.Enabled = true;
			this.mnu_IndTrainReport.Text = "Individual Training Report";

            // 
            // mnu_IndPMRecert
            // 
            this.mnu_IndPMRecert = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_IndPMRecert.Available = true;
			this.mnu_IndPMRecert.Enabled = true;
			this.mnu_IndPMRecert.Text = "Individual PM Recert Report";

            // 
            // mnuALSProc
            // 
            this.mnuALSProc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuALSProc.Available = true;
			this.mnuALSProc.Enabled = true;
			this.mnuALSProc.Text = "Individual ALS Procedures (IRS)";

            // 
            // mnuTrnReports
            // 
            this.mnuTrnReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTrnReports.Available = true;
			this.mnuTrnReports.Enabled = true;
			this.mnuTrnReports.Text = "Training Reports";

            // 
            // mnu_TrainingQueryTool
            // 
            this.mnu_TrainingQueryTool = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_TrainingQueryTool.Available = true;
			this.mnu_TrainingQueryTool.Enabled = true;
			this.mnu_TrainingQueryTool.Text = "Training Query Tool (new)";

            // 
            // mnuNewTrainQuery
            // 
            this.mnuNewTrainQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuNewTrainQuery.Available = true;
			this.mnuNewTrainQuery.Enabled = true;
			this.mnuNewTrainQuery.Text = "Training Class Query";

            // 
            // mnuTrainQuery
            // 
            this.mnuTrainQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTrainQuery.Available = true;
			this.mnuTrainQuery.Enabled = true;
			this.mnuTrainQuery.Text = "Old Training Attendance Query";

            // 
            // mnu_Queries
            // 
            this.mnu_Queries = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_Queries.Available = true;
			this.mnu_Queries.Enabled = true;
			this.mnu_Queries.Text = "Training Class Queries";

            // 
            // mnuTraining
            // 
            this.mnuTraining = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTraining.Available = true;
			this.mnuTraining.Enabled = true;
			this.mnuTraining.Text = "Training";

            // 
            // mnuReviewPay
            // 
            this.mnuReviewPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuReviewPay.Available = true;
			this.mnuReviewPay.Enabled = true;
			this.mnuReviewPay.Text = "Review Pay Period";

            // 
            // mnuIndTimeCard
            // 
            this.mnuIndTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuIndTimeCard.Available = true;
			this.mnuIndTimeCard.Enabled = true;
			this.mnuIndTimeCard.Text = "Review Individual Time Cards";

            // 
            // mnu_ReportPayroll
            // 
            this.mnu_ReportPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_ReportPayroll.Available = true;
			this.mnu_ReportPayroll.Enabled = true;
			this.mnu_ReportPayroll.Text = "Pay Period Audit Report";

            // 
            // mnuOtherPayroll
            // 
            this.mnuOtherPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuOtherPayroll.Available = true;
			this.mnuOtherPayroll.Enabled = true;
			this.mnuOtherPayroll.Text = "Payroll For Adm, CIV, etc";

            // 
            // mnuPayroll
            // 
            this.mnuPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPayroll.Available = true;
			this.mnuPayroll.Enabled = true;
			this.mnuPayroll.Text = "Payroll";

            // 
            // mnuResource
            // 
            this.mnuResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuResource.Available = true;
			this.mnuResource.Enabled = true;
			this.mnuResource.Text = "Manage Resource Table";

            // 
            // mnuPersonnelCodes
            // 
            this.mnuPersonnelCodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPersonnelCodes.Available = true;
			this.mnuPersonnelCodes.Enabled = true;
			this.mnuPersonnelCodes.Text = "Personnel Code Tables";

            // 
            // mnuCodes
            // 
            this.mnuCodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCodes.Available = true;
			this.mnuCodes.Enabled = true;
			this.mnuCodes.Text = "Manage Code Tables";

            // 
            // mnuMakeNewSched
            // 
            this.mnuMakeNewSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuMakeNewSched.Available = true;
			this.mnuMakeNewSched.Enabled = true;
			this.mnuMakeNewSched.Text = "Manage Schedule/Calendar Records";

            // 
            // mnuTable
            // 
            this.mnuTable = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTable.Available = true;
			this.mnuTable.Enabled = true;
			this.mnuTable.Text = "Table Management";

            // 
            // mnuSecure
            // 
            this.mnuSecure = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuSecure.Available = true;
			this.mnuSecure.Enabled = true;
			this.mnuSecure.Text = "Security Management";

            // 
            // mnuUtil
            // 
            this.mnuUtil = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuUtil.Available = true;
			this.mnuUtil.Enabled = true;
			this.mnuUtil.Text = "Utilities";

            // 
            // mnuCascade (Remove This)
            // 
            this.mnuCascade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCascade.Available = true;
			this.mnuCascade.Enabled = true;
			this.mnuCascade.Text = "Cascade Windows";

            // 
            // mnuPrintScreen (Remove This)
            // 
            this.mnuPrintScreen = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuPrintScreen.Available = true;
			this.mnuPrintScreen.Enabled = true;
			this.mnuPrintScreen.Text = "Print Screen";

            // 
            // mnuWindow (Remove This)
            // 
            this.mnuWindow = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuWindow.Available = true;
			this.mnuWindow.Enabled = true;
			this.mnuWindow.Text = "Window";

            // 
            // mnuCon (Remove This)
            // 
            this.mnuCon = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCon.Available = false;
			this.mnuCon.Enabled = false;
			this.mnuCon.Text = "Contents";

            // 
            // mnuAbout
            // 
            this.mnuAbout = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuAbout.Available = true;
			this.mnuAbout.Enabled = true;
			this.mnuAbout.Text = "About PTS";

            // 
            // mnu_HelpPrntScrn
            // 
            this.mnu_HelpPrntScrn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_HelpPrntScrn.Available = true;
			this.mnu_HelpPrntScrn.Enabled = true;
			this.mnu_HelpPrntScrn.Text = "How to Print Screen";

            // 
            // mnu_timecodes
            // 
            this.mnu_timecodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_timecodes.Available = true;
			this.mnu_timecodes.Enabled = true;
			this.mnu_timecodes.Text = "Payroll Time Card codes";

            // 
            // mnu_payrolllegend
            // 
            this.mnu_payrolllegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_payrolllegend.Available = true;
			this.mnu_payrolllegend.Enabled = true;
			this.mnu_payrolllegend.Text = "Payroll Timecard Legend";

            // 
            // mnu_legend
            // 
            this.mnu_legend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_legend.Available = true;
			this.mnu_legend.Enabled = true;
			this.mnu_legend.Text = "Battalion Scheduler Legend";

            // 
            // mnu_IndLegend
            // 
            this.mnu_IndLegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_IndLegend.Available = true;
			this.mnu_IndLegend.Enabled = true;
			this.mnu_IndLegend.Text = "Individual Scheduler Legend";

            // 
            // mnu_payup_calc
            // 
            this.mnu_payup_calc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnu_payup_calc.Available = true;
			this.mnu_payup_calc.Enabled = true;
			this.mnu_payup_calc.Text = "Employee Pay Up/Step Calculator";

            // 
            // mnuTrainCodeHelp
            //
            this.mnuTrainCodeHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuTrainCodeHelp.Available = true;
			this.mnuTrainCodeHelp.Enabled = true;
			this.mnuTrainCodeHelp.Text = "Training Codes";

            // 
            // mnuCalendarHelp
            // 
            this.mnuCalendarHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuCalendarHelp.Available = true;
			this.mnuCalendarHelp.Enabled = true;
			this.mnuCalendarHelp.Text = "Calendar Year Shift Totals";

            // 
            // mnuHelp
            // 
            this.mnuHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
            this.mnuHelp.Available = true;
			this.mnuHelp.Enabled = true;
			this.mnuHelp.Text = "Help";

			this.sprResource_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprContact_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPhone_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPhoneList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCheckList2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCheckList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSummary_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCallBackDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReportGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCSRs_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprImmunizationList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDaysOff_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPositions_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLaunderGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRepairGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprBunkerList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprUniformList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPrintList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprInd_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPastComments_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSpecialtyList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprMonth2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAvailable_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRequests_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprGranted_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprMissing_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeaveAllowed_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprOrderCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTimeCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprJobCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployee_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprNewReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprQ1_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprBatt_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIndiv_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprWeek1_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprWeek2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTimeSheet_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPay_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprShift_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTrans_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSenior_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCF1_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPromo_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAssign_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDebit_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRoster_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAnnual_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprOT_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDaily_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprWeek_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprExcept_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeave_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSeniority_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPromoList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();

			this.Text = "TFD - Personnel Tracking and Scheduling";
			this.AppOpen = 0;
			// 
			// MDIForm1
			// 
			this.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 255);
			//this.CmDialog1 = ctx.Resolve<UpgradeStubs.MSComDlg_CommonDialog>();
			//this.CmDialog1Print = ctx.Resolve<Stubs._System.Windows.Forms.PrintDialog>();
			//this.CmDialog1Print.PrinterSettings = ctx.Resolve<Stubs._System.Drawing.Printing.PrinterSettings>();
			mnuPersonnel = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>>(1);
			mnuPersonnel[0] = _mnuPersonnel_0;
			mnuPersonnel[0].Available = true;
			mnuPersonnel[0].Enabled = true;
			mnuPersonnel[0].Text = "Personnel";
			mnuPerson = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>>(1);
			mnuPerson[0] = _mnuPerson_0;
			mnuPerson[0].Available = true;
			mnuPerson[0].Enabled = true;
			mnuPerson[0].Text = "Personnel";
			this.Name = "PTSProject.MDIForm1";
			IsMdiParent = true;
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> ActiveMdiChild { get; set; }

		//public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintSetup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSystem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAddnew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEmpInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEmergency { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuImmune { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPromoli { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSeniorInq { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_transfer_req { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPMCerts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel _mnuPersonnel_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSDaily { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHazmat { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMarine { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_watch_duty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Vacation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HZMVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_FCCVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_old { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuFRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPublicRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_DDGroups { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuProlist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSenior { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_dailydispatchwork { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_rankedops { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_emp_facility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuAuditDDHOL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndivPayrollSO { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPhoneList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel _mnuPerson_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBDWork { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSWeekly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHZMWeekly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMRNWeekly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBatWeekly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispWeekly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuWeek { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndYearSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyStaffing { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuOvertime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuExtraOff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sa_report { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCalendar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTransfer { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedul { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_daily { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Annual { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_dailysickleave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Individual { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sick_usage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatchLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HZMLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Leave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCBStaffing { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_LeaveNoSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuInsteadOfSCKLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_staffdiscrepancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMCSRCalc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_EmpNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_SchedNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCycleHrs { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PPEQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Battalion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPPAudit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndAnnualPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_personnelsignoff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_BCApprovedTC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayrollReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_QuarterlyMinimumDrill { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_FCCMinDrills { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_ReadingAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_OTEPReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMRecertReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMBaseStaReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingQuerynew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_trainingtracker { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndTrainReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndPMRecert { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuALSProc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrnReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingQueryTool { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewTrainQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Queries { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTraining { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReviewPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_ReportPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuOtherPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPersonnelCodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMakeNewSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSecure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuUtil { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCascade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintScreen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuWindow { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCon { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAbout { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_HelpPrntScrn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_timecodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payrolllegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_legend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndLegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payup_calc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainCodeHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCalendarHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHelp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprResource_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprContact_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPhone_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPhoneList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCheckList2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCheckList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSummary_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCallBackDetail_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReportGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCSRs_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprImmunizationList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDaysOff_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPositions_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLaunderGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRepairGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprBunkerList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUniformList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPrintList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprInd_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPastComments_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSpecialtyList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprMonth2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDetail_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAvailable_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRequests_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprGranted_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprMissing_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeaveAllowed_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprOrderCode_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeCode_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprJobCode_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPPEList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployee_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprNewReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprQ1_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprBatt_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIndiv_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek1_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeSheet_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPay_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprShift_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTrans_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSenior_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCF1_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPromo_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAssign_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDebit_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRoster_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAnnual_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprOT_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDaily_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprWeek_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprExcept_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeave_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSeniority_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPromoList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 AppOpen { get; set; }

		public virtual UpgradeHelpers.Helpers.Color Override  { get; set; }

		//public virtual UpgradeStubs.MSComDlg_CommonDialog CmDialog1 { get; set; }

		//[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		//public virtual Stubs._System.Windows.Forms.PrintDialog CmDialog1Print { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> mnuPersonnel { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> mnuPerson { get; set; }

		public virtual bool IsMdiParent { get; set; }

	}

}