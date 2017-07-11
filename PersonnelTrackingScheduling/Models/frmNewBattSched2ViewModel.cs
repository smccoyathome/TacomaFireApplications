using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmNewBattSched2))]
	public class frmNewBattSched2ViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.calSchedDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			// 
			// calSchedDate
			// 
			this.calSchedDate.AllowDrop = true;
			this.calSchedDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calSchedDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calSchedDate.Name = "calSchedDate";
			this.calSchedDate.TabIndex = 0;
			this.mnuTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTimeCard.Text = "Print &Timecard Worksheet";
			this.mnuException = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuException.Text = "Print &Exception Report";
			this.mnuPrintDailyLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPrintDailyLeave.Text = "Print &Daily Leave Report";
			this.mnuPrintAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPrintAll.Text = "Print &All Battalion Schedule Reports";
			this.mnuClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuClose.Text = "&Close Battalion Scheduler";
			this.mnuSystem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSystem.Text = "&System";
			this.mnuEmpInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEmpInfo.Text = "&Update Employee Information";
			this.mnuSeniorInq = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSeniorInq.Text = "&Senority Ranking Inquiry";
			this.mnuImmune = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuImmune.Text = "Manage Employee Immunizations";
			this.mnu_transfer_req = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_transfer_req.Text = "Manage Requests For Transfer";
			this.mnuPMCerts = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPMCerts.Text = "Manage Paramedic Certifications";
			this.mnuPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPPE.Text = "Manage WDL and PPE Info";
			this.mnupersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupersonnel.Text = "&Personnel";
			this.mnuIndSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndSchedule.Text = "&Individual Leave Scheduler";
			this.mnuBattalion1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion1.Text = "Battalion &1 Scheduler";
			this.mnuNewBatt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewBatt3.Text = "Battalion &3 Scheduler";
			this.mnuBattalion3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion3.Text = "Batt &4 Sched (Special Unit)";
			this.mnuBattalion4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion4.Text = "Batt &5 Sched (Reserve Unit)";
			this.mnuEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMS.Text = "&EMS Scheduler";
			this.mnuEMSDaily = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMSDaily.Text = "EMS Daily Scheduler";
			this.mnuHazmat = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHazmat.Text = "&HazMat Scheduler";
			this.mnuMarine = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuMarine.Text = "&Marine Scheduler";
			this.mnuBattStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattStaff.Text = "&Battalion Staff Scheduler";
			this.mnuDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDispatch.Text = "&Dispatch Scheduler";
			this.mnu_watch_duty = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_watch_duty.Text = "Assign Watch Duty";
			this.mnu_Vacation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_Vacation.Text = "Vacation Scheduler";
			this.mnu_PMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMVacationSched.Text = "Paramedic Vacation Scheduler";
			this.mnu_HZMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_HZMVacationSched.Text = "Hazmat Vacation Scheduler";
			this.mnu_FCCVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_FCCVacationSched.Text = "Dispatch Vacation Available";
			this.mnuNewBatt1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewBatt1.Text = "New Battalion 1 Scheduler";
			this.mnuNewBatt2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewBatt2.Text = "New Battalion 2 Scheduler";
			this.mnu_old = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_old.Text = "Hidden Battalion Schedulers";
			this.mnuSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSchedule.Text = "Sche&duling";
			this.mnuAssignment = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAssignment.Text = "&Assignment Report";
			this.mnuRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuRoster.Text = "&Roster";
			this.mnuFRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuFRoster.Text = "Filtered Roster";
			this.mnuDebitReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDebitReport.Text = "&Debit Day Groups";
			this.mnuProlist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuProlist.Text = "&Promotion Lists";
			this.mnuSenior = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSenior.Text = "&Seniority Ranking Lists";
			this.mnuBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBenefit.Text = "CF&1 Benefit Listing";
			this.mnu_emp_facility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_emp_facility.Text = "Employee List by Facility";
			this.MnuAuditDDHOL = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.MnuAuditDDHOL.Text = "Debit Day / Holiday Audit";
			this.mnu_IndivPayrollSO = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndivPayrollSO.Text = "Individual Payroll SignOff ";
			this.mnuIndTimeCard2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndTimeCard2.Text = "Individual Time Cards";
			this.mnuPersonnelReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPersonnelReports.Text = "&Personnel";
			this.mnu181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu181.Text = "Battalion &1";
			this.mnu182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu182.Text = "Battalion &2";
			this.mnu183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu183.Text = "Battalion &3";
			this.mnuBDWork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBDWork.Text = "&Battalion Timecard Worksheets";
			this.mnuEMSPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMSPay.Text = "&EMS";
			this.mnuHazPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHazPay.Text = "&HazMat";
			this.mnuMarPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuMarPay.Text = "&Marine";
			this.mnuBattPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattPay.Text = "&Battalion Staff";
			this.mnuDisPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDisPay.Text = "&Dispatch";
			this.mnupayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupayroll.Text = "&Payroll Worksheets";
			this.mnuIndTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndTimeCard.Text = "&Individual Time Cards";
			this.mnuIndYearSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndYearSched.Text = "Individual &Yearly Schedule";
			this.mnuDailyStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDailyStaff.Text = "&Daily Staffing Report";
			this.mnuOvertime = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuOvertime.Text = "&Overtime Detail Report";
			this.MnuExtraOff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.MnuExtraOff.Text = "Extra-Unplanned Days Off Report";
			this.mnu_sa_report = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_sa_report.Text = "Special Assignment Yearly Report";
			this.mnuCalendar = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuCalendar.Text = "Shift &Calendar";
			this.mnuTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTransfer.Text = "&Transfer Schedule";
			this.mnuSchedul = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSchedul.Text = "&Schedule";
			this.mnuDailyLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDailyLeave.Text = "&Daily Leave";
			this.mnuAnnual = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAnnual.Text = "&Annual Leave";
			this.mnu_dailysickleave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_dailysickleave.Text = "Daily Sick Leave";
			this.mnuIndLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndLeave.Text = "&Individual Leave";
			this.mnu_sick_usage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_sick_usage.Text = "Sick Leave Usage";
			this.mnu_PMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMLeave.Text = "Paramedic Leave Report";
			this.mnuDispatchLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDispatchLeave.Text = "Dispatch Leave Report";
			this.mnu_HZMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_HZMLeave.Text = "Hazmat Leave Report";
			this.mnuLeaveReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuLeaveReports.Text = "&Leave";
			this.MnuCBStaffing = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.MnuCBStaffing.Text = "Staffing To Determine Callbacks";
			this.mnu_LeaveNoSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_LeaveNoSched.Text = "Leave without Schedule";
			this.MnuInsteadOfSCKLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.MnuInsteadOfSCKLeave.Text = "Instead Of SCK Leave List";
			this.mnu_staffdiscrepancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_staffdiscrepancy.Text = "Staffing Discrepancy";
			this.mnu_PMCSRCalc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMCSRCalc.Text = "Paramedic CSR Calculator";
			this.mnu_SchedNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_SchedNotes.Text = "Query Personnel Sched Notes";
			this.mnu_PPEQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PPEQuery.Text = "PPE Query Tool";
			this.mnu_Battalion = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_Battalion.Text = "Battalion";
			this.mnu_timecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_timecard.Text = "Individual Time Cards";
			this.mnuindannualpayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuindannualpayroll.Text = "Individual Payroll Report";
			this.mnupersonnelsignoff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupersonnelsignoff.Text = "Payroll Sign Off";
			this.mnupayrollreports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupayrollreports.Text = "Payroll";
			this.mnu_QuarterlyMinimumDrill = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_QuarterlyMinimumDrill.Text = "Quarterly Minimum Standards Drills";
			this.mnu_FCCMinDrills = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_FCCMinDrills.Text = "FCC Min Standards Drills";
			this.mnu_ReadingAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_ReadingAssign.Text = "Required Reading Assignments";
			this.mnu_OTEPReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_OTEPReport.Text = "Annual OTEP Training Report";
			this.mnu_PMRecertReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMRecertReport.Text = "Paramedic Recertification Report";
			this.mnu_PMBaseStaReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMBaseStaReport.Text = "Paramedic Base Station Report";
			this.mnu_TrainingReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_TrainingReports.Text = "Training";
			this.mnuReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuReports.Text = "&Reports";
			this.mnu_trainingtracker = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_trainingtracker.Text = "Field Training Tracker";
			this.mnu_IndTrainReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndTrainReport.Text = "Individual Training Report";
			this.mnu_IndPMRecert = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndPMRecert.Text = "Individual PM Recert Report";
			this.mnuALSProc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuALSProc.Text = "Individual ALS Procedures (IRS)";
			this.mnuTrnReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrnReports.Text = "Training Reports";
			this.mnuTrainQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrainQuery.Text = "&Training Class Attendance Query";
			this.mnu_TrainingQuerynew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_TrainingQuerynew.Text = "Training Query Tool (new)";
			this.mnu_Queries = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_Queries.Text = "Training Class Queries";
			this.mnuTraining = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTraining.Text = "&Training";
			this.mnuCascade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuCascade.Text = "&Cascade Windows";
			this.mnuPrintScreen = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPrintScreen.Text = "Print Screen";
			this.mnuWindow = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuWindow.Text = "&Window";
			this.mnuContents = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuContents
			// 
			this.mnuContents.Enabled = false;
			this.mnuContents.Text = "&Contents";
			this.mnuAbout = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAbout.Text = "&About PTS";
			this.mnu_HelpPrntScrn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_HelpPrntScrn.Text = "How to Print Screen";
			this.mnu_timecodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_timecodes.Text = "Payroll Time Card codes";
			this.mnu_payrolllegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_payrolllegend.Text = "Payroll Timecard Legend";
			this.mnu_legend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_legend.Text = "Battalion Scheduler Legend";
			this.mnu_IndLegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndLegend.Text = "Individual Scheduler Legend";
			this.mnu_payup_calc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_payup_calc.Text = "Employee Pay Up/Step Calculator";
			this.mnuTrainCodeHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrainCodeHelp.Text = "Training Codes";
			this.mnuHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHelp.Text = "&Help";
			this.mnuLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuLeave.Text = "Schedule Leave";
			this.mnuNewSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewSched.Text = "Schedule Employee";
			this.mnuPayUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPayUp.Text = "Upgrade Pay";
			this.mnuPayDown = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPayDown.Text = "Remove Pay Upgrade";
			this.mnuKOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuKOT.Text = "Change KOT";
			this.mnuRover = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuRover.Text = "Place in Rover List";
			this.mnuDebit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDebit.Text = "Place in Debit List";
			this.mnuTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrade.Text = "Enact a Trade";
			this.mnuCancelTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuCancelTrade.Text = "Cancel Trade";
			this.mnuRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuRemove.Text = "Remove from Schedule";
			this.mnuSendTo181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSendTo181.Text = "Send to Battalion 1";
			this.mnuSendTo183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSendTo183.Text = "Send to Battalion 3";
			this.mnuReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuReport.Text = "View this Individuals Leave Report";
			this.mnuTradeDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTradeDetail.Text = "View Trade Detail";
			this.mnu_viewtimecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_viewtimecard.Text = "View Time Card";
			this.mnuSADetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSADetail.Text = "View Schedule Detail";
			this.mnuReschedSA = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuReschedSA.Text = "Reschedule Employee";
			this.mnu182PopUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu182PopUp.Text = "Battalion 182 PopUp Menu";
			this.sprLeave = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprLeave.AllowDrop = true;
			this.sprLeave.CellNoteIndicator = true;
			this.sprLeave.MaxRows = 100;
			this.sprLeave.TabIndex = 211;
			this.sprLeave.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.picTrash = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picTrash
			// 
			this.picTrash.AllowDrop = true;
			this.picTrash.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.picTrash.Name = "picTrash";
			this.lstSA = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSA
			// 
			this.lstSA.AllowDrop = true;
			this.lstSA.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstSA.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstSA.Name = "lstSA";
			this.lstSA.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstSA.TabIndex = 198;
			this.cboDebit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDebit
			// 
			this.cboDebit.AllowDrop = true;
			this.cboDebit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboDebit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboDebit.Name = "cboDebit";
			this.cboDebit.TabIndex = 2;
			this.cboDebit.Text = "cboDebit";
			this.cboRovers = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRovers
			// 
			this.cboRovers.AllowDrop = true;
			this.cboRovers.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRovers.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboRovers.Name = "cboRovers";
			this.cboRovers.TabIndex = 1;
			this.cboRovers.Text = "cboRovers";
			this._boxUnit_12 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 267;
			this.Label1.Text = "Date";
			this._lbDrillGroup_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDrillGroup_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbTo183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTo183
			// 
			this.lbTo183.AllowDrop = true;
			this.lbTo183.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbTo183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTo183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbTo183.Name = "lbTo183";
			this.lbTo183.TabIndex = 254;
			this.lbTo183.Text = "Send To Batt 3";
			this._shpPayUpPM_48 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_48 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.boxFCC = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			// 
			// boxFCC
			// 
			this.boxFCC.AllowDrop = true;
			this.boxFCC.Enabled = false;
			this.boxFCC.Name = "boxFCC";
			this.boxFCC.TabIndex = 273;
			this._lbPosition_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpAM_44 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_45 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_46 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_44 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_45 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_46 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPosition_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpAM_47 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_47 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPosition_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpAM_49 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_49 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPosition_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpAM_50 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_50 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_53 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_53 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpPM_52 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_52 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._shpPayUpAM_51 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_51 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 213;
			this.Label5.Text = "Dispatch";
			this._lbUnit_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.AllowDrop = true;
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 206;
			this.Label7.Text = "DbGrp";
			this.lbDebitGroup = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDebitGroup
			// 
			this.lbDebitGroup.AllowDrop = true;
			this.lbDebitGroup.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDebitGroup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbDebitGroup.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbDebitGroup.Name = "lbDebitGroup";
			this.lbDebitGroup.TabIndex = 205;
			this.lbDebitGroup.Text = "A";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 204;
			this.Label4.Text = "On Leave";
			this.lbTo181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTo181
			// 
			this.lbTo181.AllowDrop = true;
			this.lbTo181.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.lbTo181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTo181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbTo181.Name = "lbTo181";
			this.lbTo181.TabIndex = 199;
			this.lbTo181.Text = "Send To Batt 1";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 197;
			this.Label6.Text = "Spec Assign";
			this._shpPayUpPM_43 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_42 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_41 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_40 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_39 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_38 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_37 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_36 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_35 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_34 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_33 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_32 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_31 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_30 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_29 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_28 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_27 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_26 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_25 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_24 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_23 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_22 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_21 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_20 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_19 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_18 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_17 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_16 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_15 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_14 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_13 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_12 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_11 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_10 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_43 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_42 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_41 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_40 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_39 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_38 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_37 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_36 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_35 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_34 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_33 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_32 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_31 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_30 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_29 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_28 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_27 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_26 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_25 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_24 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_23 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_22 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_21 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_20 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_19 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_18 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_17 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_16 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_15 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_14 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_13 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_12 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_11 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_10 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.pnSelected = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// pnSelected
			// 
			this.pnSelected.AllowDrop = true;
			this.pnSelected.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.pnSelected.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.pnSelected.Name = "pnSelected";
			this.pnSelected.TabIndex = 195;
			this.pnSelected.Visible = false;
			this.lbShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbShift
			// 
			this.lbShift.AllowDrop = true;
			this.lbShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbShift.Name = "lbShift";
			this.lbShift.TabIndex = 196;
			this.lbShift.Text = "A";
			this._boxUnit_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 194;
			this.Label3.Text = "Debit";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 193;
			this.Label2.Text = "Rovers";
			this._lbPositionPM_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_13 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_11 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_10 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPospm_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbPeriodClosed = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPeriodClosed
			// 
			this.lbPeriodClosed.AllowDrop = true;
			this.lbPeriodClosed.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPeriodClosed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPeriodClosed.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbPeriodClosed.Name = "lbPeriodClosed";
			this.lbPeriodClosed.TabIndex = 203;
			this.lbPeriodClosed.Text = "PayPeriod Closed";
			this.lbPeriodClosed.Visible = false;
			this.lbLocked = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocked
			// 
			this.lbLocked.AllowDrop = true;
			this.lbLocked.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocked.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocked.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbLocked.Name = "lbLocked";
			this.lbLocked.TabIndex = 202;
			this.lbLocked.Text = "Schedule Locked";
			this.lbLocked.Visible = false;
			this.Ctx_mnu182PopUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripViewModel>();
			// 
			// Ctx_mnu182PopUp
			// 
			this.Ctx_mnu182PopUp.Name = "Ctx_mnu182PopUp";
			this.sprLeave_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeave_Sheet1.SheetName = "Sheet1";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 1].Value = "AM";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 2].Value = "PM";
			this.sprLeave_Sheet1.Columns.Get(0).Label = "Employee";
			this.sprLeave_Sheet1.Columns.Get(0).Width = 130F;
			this.sprLeave_Sheet1.Columns.Get(1).Label = "AM";
			this.sprLeave_Sheet1.Columns.Get(1).StyleName = "Static720636251767849430477";
			this.sprLeave_Sheet1.Columns.Get(1).Width = 53F;
			this.sprLeave_Sheet1.Columns.Get(2).Label = "PM";
			this.sprLeave_Sheet1.Columns.Get(2).Width = 53F;
			this.sprLeave_Sheet1.Columns.Get(3).Visible = false;
			this.sprLeave_Sheet1.Columns.Get(3).Width = 0F;
			//this.sprLeave_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdToday = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdToday
			// 
			this.cmdToday.AllowDrop = true;
			this.cmdToday.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdToday.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdToday.Name = "cmdToday";
			this.cmdToday.TabIndex = 268;
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.AllowDrop = true;
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 200;
			this.cmdRefresh.Text = "&Refresh";
			this.cmdListGray = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdListGray
			// 
			this.cmdListGray.AllowDrop = true;
			this.cmdListGray.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdListGray.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdListGray.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdListGray.Name = "cmdListGray";
			this.cmdListGray.TabIndex = 269;
			this.cmdListGray.Text = "List Grayed Staff";
			this.cmdBatt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdBatt3
			// 
			this.cmdBatt3.AllowDrop = true;
			this.cmdBatt3.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdBatt3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdBatt3.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdBatt3.Name = "cmdBatt3";
			this.cmdBatt3.TabIndex = 255;
			this.cmdBatt3.Text = "Batt &3 Sched";
			this.cmdAvailToWork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAvailToWork
			// 
			this.cmdAvailToWork.AllowDrop = true;
			this.cmdAvailToWork.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAvailToWork.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAvailToWork.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAvailToWork.Name = "cmdAvailToWork";
			this.cmdAvailToWork.TabIndex = 209;
			this.cmdAvailToWork.Text = "Available To Work";
			this.cmdPayRoll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPayRoll
			// 
			this.cmdPayRoll.AllowDrop = true;
			this.cmdPayRoll.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPayRoll.Enabled = false;
			this.cmdPayRoll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPayRoll.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPayRoll.Name = "cmdPayRoll";
			this.cmdPayRoll.TabIndex = 208;
			this.cmdPayRoll.Text = "&Payroll";
			this.cmdMissing = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMissing
			// 
			this.cmdMissing.AllowDrop = true;
			this.cmdMissing.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMissing.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdMissing.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMissing.Name = "cmdMissing";
			this.cmdMissing.TabIndex = 207;
			this.cmdMissing.Text = "List of Possible Missing";
			this.cmdSignOff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSignOff
			// 
			this.cmdSignOff.AllowDrop = true;
			this.cmdSignOff.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSignOff.Enabled = false;
			this.cmdSignOff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSignOff.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSignOff.Name = "cmdSignOff";
			this.cmdSignOff.TabIndex = 201;
			this.cmdSignOff.Tag = "1";
			this.cmdSignOff.Text = "&Lock Sched";
			this.cmdNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNotes
			// 
			this.cmdNotes.AllowDrop = true;
			this.cmdNotes.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNotes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNotes.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNotes.Name = "cmdNotes";
			this.cmdNotes.TabIndex = 3;
			this.cmdNotes.Text = "&Notes....";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.AllowDrop = true;
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "&Close";
			this.cmdBatt1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdBatt1
			// 
			this.cmdBatt1.AllowDrop = true;
			this.cmdBatt1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdBatt1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdBatt1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdBatt1.Name = "cmdBatt1";
			this.cmdBatt1.TabIndex = 4;
			this.cmdBatt1.Text = "Batt &1 Sched";
			this.Text = "Battalion 2 Scheduler";
			this.MinUnitPos = 0;
			this.MaxUnitPos = 0;
			this.SignOffAuthority = false;
			this.PayPeriodClosed = 0;
			this.CurrPayPeriod = 0;
			this.CurrSignOff = 0;
			this.SaveSecurity = "";
			this.RovNoClick = 0;
			this.DebNoClick = 0;
			lbUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(12);
			lbUnit[11] = _lbUnit_11;
			lbUnit[10] = _lbUnit_10;
			lbUnit[9] = _lbUnit_9;
			lbUnit[8] = _lbUnit_8;
			lbUnit[7] = _lbUnit_7;
			lbUnit[6] = _lbUnit_6;
			lbUnit[5] = _lbUnit_5;
			lbUnit[4] = _lbUnit_4;
			lbUnit[3] = _lbUnit_3;
			lbUnit[2] = _lbUnit_2;
			lbUnit[1] = _lbUnit_1;
			lbUnit[0] = _lbUnit_0;
			lbUnit[11].AllowDrop = true;
			lbUnit[11].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[11].Name = "_lbUnit_11";
			lbUnit[11].TabIndex = 212;
			lbUnit[11].Text = "FCC";
			lbUnit[11].Visible = false;
			lbUnit[10].AllowDrop = true;
			lbUnit[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[10].Name = "_lbUnit_10";
			lbUnit[10].TabIndex = 140;
			lbUnit[10].Text = "SAF03";
			lbUnit[9].AllowDrop = true;
			lbUnit[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[9].Name = "_lbUnit_9";
			lbUnit[9].TabIndex = 131;
			lbUnit[9].Text = "SQ06";
			lbUnit[8].AllowDrop = true;
			lbUnit[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[8].Name = "_lbUnit_8";
			lbUnit[8].TabIndex = 122;
			lbUnit[8].Text = "M03";
			lbUnit[7].AllowDrop = true;
			lbUnit[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[7].Name = "_lbUnit_7";
			lbUnit[7].TabIndex = 113;
			lbUnit[7].Text = "L04";
			lbUnit[6].AllowDrop = true;
			lbUnit[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[6].Name = "_lbUnit_6";
			lbUnit[6].TabIndex = 104;
			lbUnit[6].Text = "E12";
			lbUnit[5].AllowDrop = true;
			lbUnit[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[5].Name = "_lbUnit_5";
			lbUnit[5].TabIndex = 91;
			lbUnit[5].Text = "E06";
			lbUnit[4].AllowDrop = true;
			lbUnit[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[4].Name = "_lbUnit_4";
			lbUnit[4].TabIndex = 44;
			lbUnit[4].Text = "E03";
			lbUnit[3].AllowDrop = true;
			lbUnit[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[3].Name = "_lbUnit_3";
			lbUnit[3].TabIndex = 35;
			lbUnit[3].Text = "E02";
			lbUnit[2].AllowDrop = true;
			lbUnit[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[2].Name = "_lbUnit_2";
			lbUnit[2].TabIndex = 24;
			lbUnit[2].Text = "L01";
			lbUnit[1].AllowDrop = true;
			lbUnit[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[1].Name = "_lbUnit_1";
			lbUnit[1].TabIndex = 15;
			lbUnit[1].Text = "E01";
			lbUnit[0].AllowDrop = true;
			lbUnit[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[0].Name = "_lbUnit_0";
			lbUnit[0].TabIndex = 6;
			lbUnit[0].Text = "BC02";
			lbDrillGroup = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(11);
			lbDrillGroup[10] = _lbDrillGroup_10;
			lbDrillGroup[9] = _lbDrillGroup_9;
			lbDrillGroup[8] = _lbDrillGroup_8;
			lbDrillGroup[7] = _lbDrillGroup_7;
			lbDrillGroup[6] = _lbDrillGroup_6;
			lbDrillGroup[5] = _lbDrillGroup_5;
			lbDrillGroup[4] = _lbDrillGroup_4;
			lbDrillGroup[3] = _lbDrillGroup_3;
			lbDrillGroup[2] = _lbDrillGroup_2;
			lbDrillGroup[1] = _lbDrillGroup_1;
			lbDrillGroup[0] = _lbDrillGroup_0;
			lbDrillGroup[10].AllowDrop = true;
			lbDrillGroup[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[10].Name = "_lbDrillGroup_10";
			lbDrillGroup[10].TabIndex = 266;
			lbDrillGroup[10].Text = "Grp:  #";
			lbDrillGroup[10].Visible = false;
			lbDrillGroup[9].AllowDrop = true;
			lbDrillGroup[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[9].Name = "_lbDrillGroup_9";
			lbDrillGroup[9].TabIndex = 265;
			lbDrillGroup[9].Text = "Grp:  #";
			lbDrillGroup[9].Visible = false;
			lbDrillGroup[8].AllowDrop = true;
			lbDrillGroup[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[8].Name = "_lbDrillGroup_8";
			lbDrillGroup[8].TabIndex = 264;
			lbDrillGroup[8].Text = "Grp:  #";
			lbDrillGroup[8].Visible = false;
			lbDrillGroup[7].AllowDrop = true;
			lbDrillGroup[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[7].Name = "_lbDrillGroup_7";
			lbDrillGroup[7].TabIndex = 263;
			lbDrillGroup[7].Text = "Grp:  #";
			lbDrillGroup[7].Visible = false;
			lbDrillGroup[6].AllowDrop = true;
			lbDrillGroup[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[6].Name = "_lbDrillGroup_6";
			lbDrillGroup[6].TabIndex = 262;
			lbDrillGroup[6].Text = "Grp:  #";
			lbDrillGroup[6].Visible = false;
			lbDrillGroup[5].AllowDrop = true;
			lbDrillGroup[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[5].Name = "_lbDrillGroup_5";
			lbDrillGroup[5].TabIndex = 261;
			lbDrillGroup[5].Text = "Grp:  #";
			lbDrillGroup[5].Visible = false;
			lbDrillGroup[4].AllowDrop = true;
			lbDrillGroup[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[4].Name = "_lbDrillGroup_4";
			lbDrillGroup[4].TabIndex = 260;
			lbDrillGroup[4].Text = "Grp:  #";
			lbDrillGroup[4].Visible = false;
			lbDrillGroup[3].AllowDrop = true;
			lbDrillGroup[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[3].Name = "_lbDrillGroup_3";
			lbDrillGroup[3].TabIndex = 259;
			lbDrillGroup[3].Text = "Grp:  #";
			lbDrillGroup[3].Visible = false;
			lbDrillGroup[2].AllowDrop = true;
			lbDrillGroup[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[2].Name = "_lbDrillGroup_2";
			lbDrillGroup[2].TabIndex = 258;
			lbDrillGroup[2].Text = "Grp:  #";
			lbDrillGroup[2].Visible = false;
			lbDrillGroup[1].AllowDrop = true;
			lbDrillGroup[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[1].Name = "_lbDrillGroup_1";
			lbDrillGroup[1].TabIndex = 257;
			lbDrillGroup[1].Text = "Grp:  #";
			lbDrillGroup[1].Visible = false;
			lbDrillGroup[0].AllowDrop = true;
			lbDrillGroup[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			lbDrillGroup[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDrillGroup[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbDrillGroup[0].Name = "_lbDrillGroup_0";
			lbDrillGroup[0].TabIndex = 256;
			lbDrillGroup[0].Text = "Grp:  #";
			lbDrillGroup[0].Visible = false;
			lbPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(54);
			lbPosition[48] = _lbPosition_48;
			lbPosition[44] = _lbPosition_44;
			lbPosition[45] = _lbPosition_45;
			lbPosition[46] = _lbPosition_46;
			lbPosition[47] = _lbPosition_47;
			lbPosition[49] = _lbPosition_49;
			lbPosition[50] = _lbPosition_50;
			lbPosition[53] = _lbPosition_53;
			lbPosition[52] = _lbPosition_52;
			lbPosition[51] = _lbPosition_51;
			lbPosition[43] = _lbPosition_43;
			lbPosition[42] = _lbPosition_42;
			lbPosition[41] = _lbPosition_41;
			lbPosition[40] = _lbPosition_40;
			lbPosition[39] = _lbPosition_39;
			lbPosition[38] = _lbPosition_38;
			lbPosition[37] = _lbPosition_37;
			lbPosition[36] = _lbPosition_36;
			lbPosition[35] = _lbPosition_35;
			lbPosition[34] = _lbPosition_34;
			lbPosition[33] = _lbPosition_33;
			lbPosition[32] = _lbPosition_32;
			lbPosition[31] = _lbPosition_31;
			lbPosition[30] = _lbPosition_30;
			lbPosition[29] = _lbPosition_29;
			lbPosition[28] = _lbPosition_28;
			lbPosition[27] = _lbPosition_27;
			lbPosition[26] = _lbPosition_26;
			lbPosition[25] = _lbPosition_25;
			lbPosition[24] = _lbPosition_24;
			lbPosition[23] = _lbPosition_23;
			lbPosition[22] = _lbPosition_22;
			lbPosition[21] = _lbPosition_21;
			lbPosition[20] = _lbPosition_20;
			lbPosition[19] = _lbPosition_19;
			lbPosition[18] = _lbPosition_18;
			lbPosition[17] = _lbPosition_17;
			lbPosition[16] = _lbPosition_16;
			lbPosition[15] = _lbPosition_15;
			lbPosition[14] = _lbPosition_14;
			lbPosition[13] = _lbPosition_13;
			lbPosition[12] = _lbPosition_12;
			lbPosition[11] = _lbPosition_11;
			lbPosition[10] = _lbPosition_10;
			lbPosition[9] = _lbPosition_9;
			lbPosition[8] = _lbPosition_8;
			lbPosition[7] = _lbPosition_7;
			lbPosition[6] = _lbPosition_6;
			lbPosition[5] = _lbPosition_5;
			lbPosition[4] = _lbPosition_4;
			lbPosition[3] = _lbPosition_3;
			lbPosition[2] = _lbPosition_2;
			lbPosition[1] = _lbPosition_1;
			lbPosition[0] = _lbPosition_0;
			lbPosition[48].AllowDrop = true;
			lbPosition[48].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[48].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[48].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[48].Name = "_lbPosition_48";
			lbPosition[48].TabIndex = 240;
			lbPosition[48].Text = "FFDISP2";
			lbPosition[44].AllowDrop = true;
			lbPosition[44].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[44].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[44].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[44].Name = "_lbPosition_44";
			lbPosition[44].TabIndex = 239;
			lbPosition[44].Text = "FCCCP";
			lbPosition[45].AllowDrop = true;
			lbPosition[45].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[45].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[45].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[45].Name = "_lbPosition_45";
			lbPosition[45].TabIndex = 238;
			lbPosition[45].Text = "FCCCTO";
			lbPosition[46].AllowDrop = true;
			lbPosition[46].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[46].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[46].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[46].Name = "_lbPosition_46";
			lbPosition[46].TabIndex = 237;
			lbPosition[46].Text = "FCCOFF";
			lbPosition[47].AllowDrop = true;
			lbPosition[47].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[47].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[47].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[47].Name = "_lbPosition_47";
			lbPosition[47].TabIndex = 228;
			lbPosition[47].Text = "FFDISP1";
			lbPosition[49].AllowDrop = true;
			lbPosition[49].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[49].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[49].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[49].Name = "_lbPosition_49";
			lbPosition[49].TabIndex = 224;
			lbPosition[49].Text = "FFDISP3";
			lbPosition[50].AllowDrop = true;
			lbPosition[50].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[50].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[50].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[50].Name = "_lbPosition_50";
			lbPosition[50].TabIndex = 222;
			lbPosition[50].Text = "FFDISP4";
			lbPosition[53].AllowDrop = true;
			lbPosition[53].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[53].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[53].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[53].Name = "_lbPosition_53";
			lbPosition[53].TabIndex = 219;
			lbPosition[53].Text = "FFDISP7";
			lbPosition[52].AllowDrop = true;
			lbPosition[52].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[52].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[52].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[52].Name = "_lbPosition_52";
			lbPosition[52].TabIndex = 217;
			lbPosition[52].Text = "FFDISP6";
			lbPosition[51].AllowDrop = true;
			lbPosition[51].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[51].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[51].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[51].Name = "_lbPosition_51";
			lbPosition[51].TabIndex = 216;
			lbPosition[51].Text = "FFDISP5";
			lbPosition[43].AllowDrop = true;
			lbPosition[43].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[43].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[43].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[43].Name = "_lbPosition_43";
			lbPosition[43].TabIndex = 95;
			lbPosition[43].Visible = false;
			lbPosition[42].AllowDrop = true;
			lbPosition[42].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[42].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[42].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[42].Name = "_lbPosition_42";
			lbPosition[42].TabIndex = 94;
			lbPosition[42].Visible = false;
			lbPosition[41].AllowDrop = true;
			lbPosition[41].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[41].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[41].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[41].Name = "_lbPosition_41";
			lbPosition[41].TabIndex = 93;
			lbPosition[41].Text = " ";
			lbPosition[41].Visible = false;
			lbPosition[40].AllowDrop = true;
			lbPosition[40].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[40].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[40].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[40].Name = "_lbPosition_40";
			lbPosition[40].TabIndex = 92;
			lbPosition[40].Text = "SAFLT";
			lbPosition[39].AllowDrop = true;
			lbPosition[39].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[39].Name = "_lbPosition_39";
			lbPosition[39].TabIndex = 52;
			lbPosition[39].Visible = false;
			lbPosition[38].AllowDrop = true;
			lbPosition[38].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[38].Name = "_lbPosition_38";
			lbPosition[38].TabIndex = 51;
			lbPosition[38].Visible = false;
			lbPosition[37].AllowDrop = true;
			lbPosition[37].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[37].Name = "_lbPosition_37";
			lbPosition[37].TabIndex = 50;
			lbPosition[37].Text = "DR";
			lbPosition[36].AllowDrop = true;
			lbPosition[36].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[36].Name = "_lbPosition_36";
			lbPosition[36].TabIndex = 49;
			lbPosition[36].Text = "OFF";
			lbPosition[35].AllowDrop = true;
			lbPosition[35].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[35].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[35].Name = "_lbPosition_35";
			lbPosition[35].TabIndex = 48;
			lbPosition[35].Text = "4TH";
			lbPosition[35].Visible = false;
			lbPosition[34].AllowDrop = true;
			lbPosition[34].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[34].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[34].Name = "_lbPosition_34";
			lbPosition[34].TabIndex = 47;
			lbPosition[34].Text = "STUDENT";
			lbPosition[33].AllowDrop = true;
			lbPosition[33].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[33].Name = "_lbPosition_33";
			lbPosition[33].TabIndex = 46;
			lbPosition[33].Text = "DR";
			lbPosition[32].AllowDrop = true;
			lbPosition[32].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[32].Name = "_lbPosition_32";
			lbPosition[32].TabIndex = 45;
			lbPosition[32].Text = "INCHG";
			lbPosition[31].AllowDrop = true;
			lbPosition[31].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[31].Name = "_lbPosition_31";
			lbPosition[31].TabIndex = 43;
			lbPosition[31].Text = "4TH";
			lbPosition[30].AllowDrop = true;
			lbPosition[30].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[30].Name = "_lbPosition_30";
			lbPosition[30].TabIndex = 42;
			lbPosition[30].Text = "3RD";
			lbPosition[29].AllowDrop = true;
			lbPosition[29].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[29].Name = "_lbPosition_29";
			lbPosition[29].TabIndex = 41;
			lbPosition[29].Text = "DR";
			lbPosition[28].AllowDrop = true;
			lbPosition[28].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[28].Name = "_lbPosition_28";
			lbPosition[28].TabIndex = 40;
			lbPosition[28].Text = "OFF";
			lbPosition[27].AllowDrop = true;
			lbPosition[27].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[27].Name = "_lbPosition_27";
			lbPosition[27].TabIndex = 39;
			lbPosition[27].Text = "4TH";
			lbPosition[26].AllowDrop = true;
			lbPosition[26].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[26].Name = "_lbPosition_26";
			lbPosition[26].TabIndex = 38;
			lbPosition[26].Text = "3RD";
			lbPosition[25].AllowDrop = true;
			lbPosition[25].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[25].Name = "_lbPosition_25";
			lbPosition[25].TabIndex = 37;
			lbPosition[25].Text = "DR";
			lbPosition[24].AllowDrop = true;
			lbPosition[24].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[24].Name = "_lbPosition_24";
			lbPosition[24].TabIndex = 36;
			lbPosition[24].Text = "OFF";
			lbPosition[23].AllowDrop = true;
			lbPosition[23].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[23].Name = "_lbPosition_23";
			lbPosition[23].TabIndex = 32;
			lbPosition[23].Text = "4TH";
			lbPosition[22].AllowDrop = true;
			lbPosition[22].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[22].Name = "_lbPosition_22";
			lbPosition[22].TabIndex = 31;
			lbPosition[22].Text = "3RD";
			lbPosition[21].AllowDrop = true;
			lbPosition[21].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[21].Name = "_lbPosition_21";
			lbPosition[21].TabIndex = 30;
			lbPosition[21].Text = "DR";
			lbPosition[20].AllowDrop = true;
			lbPosition[20].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[20].Name = "_lbPosition_20";
			lbPosition[20].TabIndex = 29;
			lbPosition[20].Text = "OFF";
			lbPosition[19].AllowDrop = true;
			lbPosition[19].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[19].Name = "_lbPosition_19";
			lbPosition[19].TabIndex = 28;
			lbPosition[19].Text = "4TH";
			lbPosition[18].AllowDrop = true;
			lbPosition[18].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[18].Name = "_lbPosition_18";
			lbPosition[18].TabIndex = 27;
			lbPosition[18].Text = "3RD";
			lbPosition[17].AllowDrop = true;
			lbPosition[17].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[17].Name = "_lbPosition_17";
			lbPosition[17].TabIndex = 26;
			lbPosition[17].Text = "DR";
			lbPosition[16].AllowDrop = true;
			lbPosition[16].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[16].Name = "_lbPosition_16";
			lbPosition[16].TabIndex = 25;
			lbPosition[16].Text = "OFF";
			lbPosition[15].AllowDrop = true;
			lbPosition[15].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[15].Name = "_lbPosition_15";
			lbPosition[15].TabIndex = 23;
			lbPosition[15].Text = "4TH";
			lbPosition[14].AllowDrop = true;
			lbPosition[14].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[14].Name = "_lbPosition_14";
			lbPosition[14].TabIndex = 22;
			lbPosition[14].Text = "3RD";
			lbPosition[13].AllowDrop = true;
			lbPosition[13].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[13].Name = "_lbPosition_13";
			lbPosition[13].TabIndex = 21;
			lbPosition[13].Text = "DR";
			lbPosition[12].AllowDrop = true;
			lbPosition[12].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[12].Name = "_lbPosition_12";
			lbPosition[12].TabIndex = 20;
			lbPosition[12].Text = "OFF";
			lbPosition[11].AllowDrop = true;
			lbPosition[11].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[11].Name = "_lbPosition_11";
			lbPosition[11].TabIndex = 19;
			lbPosition[11].Text = "4TH";
			lbPosition[10].AllowDrop = true;
			lbPosition[10].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[10].Name = "_lbPosition_10";
			lbPosition[10].TabIndex = 18;
			lbPosition[10].Text = "3RD";
			lbPosition[9].AllowDrop = true;
			lbPosition[9].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[9].Name = "_lbPosition_9";
			lbPosition[9].TabIndex = 17;
			lbPosition[9].Text = "DR";
			lbPosition[8].AllowDrop = true;
			lbPosition[8].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[8].Name = "_lbPosition_8";
			lbPosition[8].TabIndex = 16;
			lbPosition[8].Text = "OFF";
			lbPosition[7].AllowDrop = true;
			lbPosition[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[7].Name = "_lbPosition_7";
			lbPosition[7].TabIndex = 14;
			lbPosition[7].Text = "4TH";
			lbPosition[6].AllowDrop = true;
			lbPosition[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[6].Name = "_lbPosition_6";
			lbPosition[6].TabIndex = 13;
			lbPosition[6].Text = "3RD";
			lbPosition[5].AllowDrop = true;
			lbPosition[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[5].Name = "_lbPosition_5";
			lbPosition[5].TabIndex = 12;
			lbPosition[5].Text = "DR";
			lbPosition[4].AllowDrop = true;
			lbPosition[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[4].Name = "_lbPosition_4";
			lbPosition[4].TabIndex = 11;
			lbPosition[4].Text = "OFF";
			lbPosition[3].AllowDrop = true;
			lbPosition[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[3].Name = "_lbPosition_3";
			lbPosition[3].TabIndex = 10;
			lbPosition[3].Visible = false;
			lbPosition[2].AllowDrop = true;
			lbPosition[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[2].Name = "_lbPosition_2";
			lbPosition[2].TabIndex = 9;
			lbPosition[2].Visible = false;
			lbPosition[1].AllowDrop = true;
			lbPosition[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[1].Name = "_lbPosition_1";
			lbPosition[1].TabIndex = 8;
			lbPosition[1].Text = "PLNOFF";
			lbPosition[0].AllowDrop = true;
			lbPosition[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[0].Name = "_lbPosition_0";
			lbPosition[0].TabIndex = 7;
			lbPosition[0].Text = "BC";
			lbPosam = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(54);
			lbPosam[43] = _lbPosam_43;
			lbPosam[42] = _lbPosam_42;
			lbPosam[41] = _lbPosam_41;
			lbPosam[40] = _lbPosam_40;
			lbPosam[39] = _lbPosam_39;
			lbPosam[38] = _lbPosam_38;
			lbPosam[37] = _lbPosam_37;
			lbPosam[36] = _lbPosam_36;
			lbPosam[35] = _lbPosam_35;
			lbPosam[34] = _lbPosam_34;
			lbPosam[33] = _lbPosam_33;
			lbPosam[32] = _lbPosam_32;
			lbPosam[31] = _lbPosam_31;
			lbPosam[30] = _lbPosam_30;
			lbPosam[29] = _lbPosam_29;
			lbPosam[28] = _lbPosam_28;
			lbPosam[27] = _lbPosam_27;
			lbPosam[26] = _lbPosam_26;
			lbPosam[25] = _lbPosam_25;
			lbPosam[24] = _lbPosam_24;
			lbPosam[23] = _lbPosam_23;
			lbPosam[22] = _lbPosam_22;
			lbPosam[21] = _lbPosam_21;
			lbPosam[20] = _lbPosam_20;
			lbPosam[19] = _lbPosam_19;
			lbPosam[18] = _lbPosam_18;
			lbPosam[17] = _lbPosam_17;
			lbPosam[16] = _lbPosam_16;
			lbPosam[15] = _lbPosam_15;
			lbPosam[14] = _lbPosam_14;
			lbPosam[13] = _lbPosam_13;
			lbPosam[12] = _lbPosam_12;
			lbPosam[11] = _lbPosam_11;
			lbPosam[10] = _lbPosam_10;
			lbPosam[9] = _lbPosam_9;
			lbPosam[8] = _lbPosam_8;
			lbPosam[7] = _lbPosam_7;
			lbPosam[6] = _lbPosam_6;
			lbPosam[5] = _lbPosam_5;
			lbPosam[4] = _lbPosam_4;
			lbPosam[3] = _lbPosam_3;
			lbPosam[2] = _lbPosam_2;
			lbPosam[1] = _lbPosam_1;
			lbPosam[0] = _lbPosam_0;
			lbPosam[44] = _lbPosam_44;
			lbPosam[45] = _lbPosam_45;
			lbPosam[46] = _lbPosam_46;
			lbPosam[47] = _lbPosam_47;
			lbPosam[53] = _lbPosam_53;
			lbPosam[52] = _lbPosam_52;
			lbPosam[51] = _lbPosam_51;
			lbPosam[50] = _lbPosam_50;
			lbPosam[49] = _lbPosam_49;
			lbPosam[48] = _lbPosam_48;
			lbPosam[43].AllowDrop = true;
			lbPosam[43].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[43].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[43].Name = "_lbPosam_43";
			lbPosam[43].TabIndex = 144;
			lbPosam[43].Visible = false;
			lbPosam[42].AllowDrop = true;
			lbPosam[42].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[42].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[42].Name = "_lbPosam_42";
			lbPosam[42].TabIndex = 143;
			lbPosam[42].Visible = false;
			lbPosam[41].AllowDrop = true;
			lbPosam[41].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[41].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[41].Name = "_lbPosam_41";
			lbPosam[41].TabIndex = 142;
			lbPosam[41].Visible = false;
			lbPosam[40].AllowDrop = true;
			lbPosam[40].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[40].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[40].Name = "_lbPosam_40";
			lbPosam[40].TabIndex = 141;
			lbPosam[39].AllowDrop = true;
			lbPosam[39].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[39].Name = "_lbPosam_39";
			lbPosam[39].TabIndex = 135;
			lbPosam[39].Visible = false;
			lbPosam[38].AllowDrop = true;
			lbPosam[38].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[38].Name = "_lbPosam_38";
			lbPosam[38].TabIndex = 134;
			lbPosam[38].Visible = false;
			lbPosam[37].AllowDrop = true;
			lbPosam[37].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[37].Name = "_lbPosam_37";
			lbPosam[37].TabIndex = 133;
			lbPosam[36].AllowDrop = true;
			lbPosam[36].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[36].Name = "_lbPosam_36";
			lbPosam[36].TabIndex = 132;
			lbPosam[35].AllowDrop = true;
			lbPosam[35].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[35].Name = "_lbPosam_35";
			lbPosam[35].TabIndex = 126;
			lbPosam[35].Visible = false;
			lbPosam[34].AllowDrop = true;
			lbPosam[34].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[34].Name = "_lbPosam_34";
			lbPosam[34].TabIndex = 125;
			lbPosam[33].AllowDrop = true;
			lbPosam[33].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[33].Name = "_lbPosam_33";
			lbPosam[33].TabIndex = 124;
			lbPosam[32].AllowDrop = true;
			lbPosam[32].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[32].Name = "_lbPosam_32";
			lbPosam[32].TabIndex = 123;
			lbPosam[31].AllowDrop = true;
			lbPosam[31].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[31].Name = "_lbPosam_31";
			lbPosam[31].TabIndex = 117;
			lbPosam[30].AllowDrop = true;
			lbPosam[30].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[30].Name = "_lbPosam_30";
			lbPosam[30].TabIndex = 116;
			lbPosam[29].AllowDrop = true;
			lbPosam[29].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[29].Name = "_lbPosam_29";
			lbPosam[29].TabIndex = 115;
			lbPosam[28].AllowDrop = true;
			lbPosam[28].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[28].Name = "_lbPosam_28";
			lbPosam[28].TabIndex = 114;
			lbPosam[27].AllowDrop = true;
			lbPosam[27].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[27].Name = "_lbPosam_27";
			lbPosam[27].TabIndex = 108;
			lbPosam[26].AllowDrop = true;
			lbPosam[26].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[26].Name = "_lbPosam_26";
			lbPosam[26].TabIndex = 107;
			lbPosam[25].AllowDrop = true;
			lbPosam[25].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[25].Name = "_lbPosam_25";
			lbPosam[25].TabIndex = 106;
			lbPosam[24].AllowDrop = true;
			lbPosam[24].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[24].Name = "_lbPosam_24";
			lbPosam[24].TabIndex = 105;
			lbPosam[23].AllowDrop = true;
			lbPosam[23].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[23].Name = "_lbPosam_23";
			lbPosam[23].TabIndex = 99;
			lbPosam[22].AllowDrop = true;
			lbPosam[22].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[22].Name = "_lbPosam_22";
			lbPosam[22].TabIndex = 98;
			lbPosam[21].AllowDrop = true;
			lbPosam[21].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[21].Name = "_lbPosam_21";
			lbPosam[21].TabIndex = 97;
			lbPosam[20].AllowDrop = true;
			lbPosam[20].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[20].Name = "_lbPosam_20";
			lbPosam[20].TabIndex = 96;
			lbPosam[19].AllowDrop = true;
			lbPosam[19].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[19].Name = "_lbPosam_19";
			lbPosam[19].TabIndex = 71;
			lbPosam[18].AllowDrop = true;
			lbPosam[18].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[18].Name = "_lbPosam_18";
			lbPosam[18].TabIndex = 70;
			lbPosam[17].AllowDrop = true;
			lbPosam[17].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[17].Name = "_lbPosam_17";
			lbPosam[17].TabIndex = 69;
			lbPosam[16].AllowDrop = true;
			lbPosam[16].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[16].Name = "_lbPosam_16";
			lbPosam[16].TabIndex = 68;
			lbPosam[15].AllowDrop = true;
			lbPosam[15].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[15].Name = "_lbPosam_15";
			lbPosam[15].TabIndex = 67;
			lbPosam[14].AllowDrop = true;
			lbPosam[14].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[14].Name = "_lbPosam_14";
			lbPosam[14].TabIndex = 66;
			lbPosam[13].AllowDrop = true;
			lbPosam[13].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[13].Name = "_lbPosam_13";
			lbPosam[13].TabIndex = 65;
			lbPosam[12].AllowDrop = true;
			lbPosam[12].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[12].Name = "_lbPosam_12";
			lbPosam[12].TabIndex = 64;
			lbPosam[11].AllowDrop = true;
			lbPosam[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[11].Name = "_lbPosam_11";
			lbPosam[11].TabIndex = 63;
			lbPosam[10].AllowDrop = true;
			lbPosam[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[10].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbPosam[10].Name = "_lbPosam_10";
			lbPosam[10].TabIndex = 62;
			lbPosam[9].AllowDrop = true;
			lbPosam[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[9].Name = "_lbPosam_9";
			lbPosam[9].TabIndex = 61;
			lbPosam[8].AllowDrop = true;
			lbPosam[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[8].Name = "_lbPosam_8";
			lbPosam[8].TabIndex = 60;
			lbPosam[7].AllowDrop = true;
			lbPosam[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[7].Name = "_lbPosam_7";
			lbPosam[7].TabIndex = 59;
			lbPosam[6].AllowDrop = true;
			lbPosam[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[6].Name = "_lbPosam_6";
			lbPosam[6].TabIndex = 58;
			lbPosam[5].AllowDrop = true;
			lbPosam[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[5].Name = "_lbPosam_5";
			lbPosam[5].TabIndex = 57;
			lbPosam[4].AllowDrop = true;
			lbPosam[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[4].Name = "_lbPosam_4";
			lbPosam[4].TabIndex = 56;
			lbPosam[3].AllowDrop = true;
			lbPosam[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[3].Name = "_lbPosam_3";
			lbPosam[3].TabIndex = 55;
			lbPosam[3].Visible = false;
			lbPosam[2].AllowDrop = true;
			lbPosam[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[2].Name = "_lbPosam_2";
			lbPosam[2].TabIndex = 54;
			lbPosam[2].Visible = false;
			lbPosam[1].AllowDrop = true;
			lbPosam[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[1].Name = "_lbPosam_1";
			lbPosam[1].TabIndex = 53;
			lbPosam[0].AllowDrop = true;
			lbPosam[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[0].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbPosam[0].Name = "_lbPosam_0";
			lbPosam[0].TabIndex = 33;
			lbPosam[44].AllowDrop = true;
			lbPosam[44].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[44].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[44].Name = "_lbPosam_44";
			lbPosam[44].TabIndex = 234;
			lbPosam[44].Text = " ";
			lbPosam[45].AllowDrop = true;
			lbPosam[45].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[45].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[45].Name = "_lbPosam_45";
			lbPosam[45].TabIndex = 233;
			lbPosam[45].Text = " ";
			lbPosam[46].AllowDrop = true;
			lbPosam[46].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[46].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[46].Name = "_lbPosam_46";
			lbPosam[46].TabIndex = 232;
			lbPosam[46].Text = " ";
			lbPosam[47].AllowDrop = true;
			lbPosam[47].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[47].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[47].Name = "_lbPosam_47";
			lbPosam[47].TabIndex = 226;
			lbPosam[47].Text = " ";
			lbPosam[53].AllowDrop = true;
			lbPosam[53].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[53].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[53].Name = "_lbPosam_53";
			lbPosam[53].TabIndex = 252;
			lbPosam[53].Text = " ";
			lbPosam[52].AllowDrop = true;
			lbPosam[52].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[52].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[52].Name = "_lbPosam_52";
			lbPosam[52].TabIndex = 250;
			lbPosam[52].Text = " ";
			lbPosam[51].AllowDrop = true;
			lbPosam[51].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[51].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[51].Name = "_lbPosam_51";
			lbPosam[51].TabIndex = 248;
			lbPosam[51].Text = " ";
			lbPosam[50].AllowDrop = true;
			lbPosam[50].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[50].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[50].Name = "_lbPosam_50";
			lbPosam[50].TabIndex = 246;
			lbPosam[50].Text = " ";
			lbPosam[49].AllowDrop = true;
			lbPosam[49].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[49].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[49].Name = "_lbPosam_49";
			lbPosam[49].TabIndex = 244;
			lbPosam[49].Text = " ";
			lbPosam[48].AllowDrop = true;
			lbPosam[48].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[48].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[48].Name = "_lbPosam_48";
			lbPosam[48].TabIndex = 242;
			lbPosam[48].Text = " ";
			shpPayUpAM = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(54);
			shpPayUpAM[48] = _shpPayUpAM_48;
			shpPayUpAM[44] = _shpPayUpAM_44;
			shpPayUpAM[45] = _shpPayUpAM_45;
			shpPayUpAM[46] = _shpPayUpAM_46;
			shpPayUpAM[47] = _shpPayUpAM_47;
			shpPayUpAM[49] = _shpPayUpAM_49;
			shpPayUpAM[50] = _shpPayUpAM_50;
			shpPayUpAM[53] = _shpPayUpAM_53;
			shpPayUpAM[52] = _shpPayUpAM_52;
			shpPayUpAM[51] = _shpPayUpAM_51;
			shpPayUpAM[43] = _shpPayUpAM_43;
			shpPayUpAM[42] = _shpPayUpAM_42;
			shpPayUpAM[41] = _shpPayUpAM_41;
			shpPayUpAM[40] = _shpPayUpAM_40;
			shpPayUpAM[39] = _shpPayUpAM_39;
			shpPayUpAM[38] = _shpPayUpAM_38;
			shpPayUpAM[37] = _shpPayUpAM_37;
			shpPayUpAM[36] = _shpPayUpAM_36;
			shpPayUpAM[35] = _shpPayUpAM_35;
			shpPayUpAM[34] = _shpPayUpAM_34;
			shpPayUpAM[33] = _shpPayUpAM_33;
			shpPayUpAM[32] = _shpPayUpAM_32;
			shpPayUpAM[31] = _shpPayUpAM_31;
			shpPayUpAM[30] = _shpPayUpAM_30;
			shpPayUpAM[29] = _shpPayUpAM_29;
			shpPayUpAM[28] = _shpPayUpAM_28;
			shpPayUpAM[27] = _shpPayUpAM_27;
			shpPayUpAM[26] = _shpPayUpAM_26;
			shpPayUpAM[25] = _shpPayUpAM_25;
			shpPayUpAM[24] = _shpPayUpAM_24;
			shpPayUpAM[23] = _shpPayUpAM_23;
			shpPayUpAM[22] = _shpPayUpAM_22;
			shpPayUpAM[21] = _shpPayUpAM_21;
			shpPayUpAM[20] = _shpPayUpAM_20;
			shpPayUpAM[19] = _shpPayUpAM_19;
			shpPayUpAM[18] = _shpPayUpAM_18;
			shpPayUpAM[17] = _shpPayUpAM_17;
			shpPayUpAM[16] = _shpPayUpAM_16;
			shpPayUpAM[15] = _shpPayUpAM_15;
			shpPayUpAM[14] = _shpPayUpAM_14;
			shpPayUpAM[13] = _shpPayUpAM_13;
			shpPayUpAM[12] = _shpPayUpAM_12;
			shpPayUpAM[11] = _shpPayUpAM_11;
			shpPayUpAM[10] = _shpPayUpAM_10;
			shpPayUpAM[9] = _shpPayUpAM_9;
			shpPayUpAM[8] = _shpPayUpAM_8;
			shpPayUpAM[7] = _shpPayUpAM_7;
			shpPayUpAM[6] = _shpPayUpAM_6;
			shpPayUpAM[5] = _shpPayUpAM_5;
			shpPayUpAM[4] = _shpPayUpAM_4;
			shpPayUpAM[3] = _shpPayUpAM_3;
			shpPayUpAM[2] = _shpPayUpAM_2;
			shpPayUpAM[1] = _shpPayUpAM_1;
			shpPayUpAM[0] = _shpPayUpAM_0;
			shpPayUpAM[48].AllowDrop = true;
			shpPayUpAM[48].Enabled = false;
			shpPayUpAM[48].Name = "_shpPayUpAM_48";
			shpPayUpAM[48].TabIndex = 272;
			shpPayUpAM[48].Visible = false;
			shpPayUpAM[44].AllowDrop = true;
			shpPayUpAM[44].Enabled = false;
			shpPayUpAM[44].Name = "_shpPayUpAM_44";
			shpPayUpAM[44].TabIndex = 274;
			shpPayUpAM[44].Visible = false;
			shpPayUpAM[45].AllowDrop = true;
			shpPayUpAM[45].Enabled = false;
			shpPayUpAM[45].Name = "_shpPayUpAM_45";
			shpPayUpAM[45].TabIndex = 275;
			shpPayUpAM[45].Visible = false;
			shpPayUpAM[46].AllowDrop = true;
			shpPayUpAM[46].Enabled = false;
			shpPayUpAM[46].Name = "_shpPayUpAM_46";
			shpPayUpAM[46].TabIndex = 276;
			shpPayUpAM[46].Visible = false;
			shpPayUpAM[47].AllowDrop = true;
			shpPayUpAM[47].Enabled = false;
			shpPayUpAM[47].Name = "_shpPayUpAM_47";
			shpPayUpAM[47].TabIndex = 280;
			shpPayUpAM[47].Visible = false;
			shpPayUpAM[49].AllowDrop = true;
			shpPayUpAM[49].Enabled = false;
			shpPayUpAM[49].Name = "_shpPayUpAM_49";
			shpPayUpAM[49].TabIndex = 282;
			shpPayUpAM[49].Visible = false;
			shpPayUpAM[50].AllowDrop = true;
			shpPayUpAM[50].Enabled = false;
			shpPayUpAM[50].Name = "_shpPayUpAM_50";
			shpPayUpAM[50].TabIndex = 284;
			shpPayUpAM[50].Visible = false;
			shpPayUpAM[53].AllowDrop = true;
			shpPayUpAM[53].Enabled = false;
			shpPayUpAM[53].Name = "_shpPayUpAM_53";
			shpPayUpAM[53].TabIndex = 287;
			shpPayUpAM[53].Visible = false;
			shpPayUpAM[52].AllowDrop = true;
			shpPayUpAM[52].Enabled = false;
			shpPayUpAM[52].Name = "_shpPayUpAM_52";
			shpPayUpAM[52].TabIndex = 289;
			shpPayUpAM[52].Visible = false;
			shpPayUpAM[51].AllowDrop = true;
			shpPayUpAM[51].Enabled = false;
			shpPayUpAM[51].Name = "_shpPayUpAM_51";
			shpPayUpAM[51].TabIndex = 290;
			shpPayUpAM[51].Visible = false;
			shpPayUpAM[43].AllowDrop = true;
			shpPayUpAM[43].Enabled = false;
			shpPayUpAM[43].Name = "_shpPayUpAM_43";
			shpPayUpAM[43].TabIndex = 335;
			shpPayUpAM[43].Visible = false;
			shpPayUpAM[42].AllowDrop = true;
			shpPayUpAM[42].Enabled = false;
			shpPayUpAM[42].Name = "_shpPayUpAM_42";
			shpPayUpAM[42].TabIndex = 336;
			shpPayUpAM[42].Visible = false;
			shpPayUpAM[41].AllowDrop = true;
			shpPayUpAM[41].Enabled = false;
			shpPayUpAM[41].Name = "_shpPayUpAM_41";
			shpPayUpAM[41].TabIndex = 337;
			shpPayUpAM[41].Visible = false;
			shpPayUpAM[40].AllowDrop = true;
			shpPayUpAM[40].Enabled = false;
			shpPayUpAM[40].Name = "_shpPayUpAM_40";
			shpPayUpAM[40].TabIndex = 338;
			shpPayUpAM[40].Visible = false;
			shpPayUpAM[39].AllowDrop = true;
			shpPayUpAM[39].Enabled = false;
			shpPayUpAM[39].Name = "_shpPayUpAM_39";
			shpPayUpAM[39].TabIndex = 339;
			shpPayUpAM[39].Visible = false;
			shpPayUpAM[38].AllowDrop = true;
			shpPayUpAM[38].Enabled = false;
			shpPayUpAM[38].Name = "_shpPayUpAM_38";
			shpPayUpAM[38].TabIndex = 340;
			shpPayUpAM[38].Visible = false;
			shpPayUpAM[37].AllowDrop = true;
			shpPayUpAM[37].Enabled = false;
			shpPayUpAM[37].Name = "_shpPayUpAM_37";
			shpPayUpAM[37].TabIndex = 341;
			shpPayUpAM[37].Visible = false;
			shpPayUpAM[36].AllowDrop = true;
			shpPayUpAM[36].Enabled = false;
			shpPayUpAM[36].Name = "_shpPayUpAM_36";
			shpPayUpAM[36].TabIndex = 342;
			shpPayUpAM[36].Visible = false;
			shpPayUpAM[35].AllowDrop = true;
			shpPayUpAM[35].Enabled = false;
			shpPayUpAM[35].Name = "_shpPayUpAM_35";
			shpPayUpAM[35].TabIndex = 343;
			shpPayUpAM[35].Visible = false;
			shpPayUpAM[34].AllowDrop = true;
			shpPayUpAM[34].Enabled = false;
			shpPayUpAM[34].Name = "_shpPayUpAM_34";
			shpPayUpAM[34].TabIndex = 344;
			shpPayUpAM[34].Visible = false;
			shpPayUpAM[33].AllowDrop = true;
			shpPayUpAM[33].Enabled = false;
			shpPayUpAM[33].Name = "_shpPayUpAM_33";
			shpPayUpAM[33].TabIndex = 345;
			shpPayUpAM[33].Visible = false;
			shpPayUpAM[32].AllowDrop = true;
			shpPayUpAM[32].Enabled = false;
			shpPayUpAM[32].Name = "_shpPayUpAM_32";
			shpPayUpAM[32].TabIndex = 346;
			shpPayUpAM[32].Visible = false;
			shpPayUpAM[31].AllowDrop = true;
			shpPayUpAM[31].Enabled = false;
			shpPayUpAM[31].Name = "_shpPayUpAM_31";
			shpPayUpAM[31].TabIndex = 347;
			shpPayUpAM[31].Visible = false;
			shpPayUpAM[30].AllowDrop = true;
			shpPayUpAM[30].Enabled = false;
			shpPayUpAM[30].Name = "_shpPayUpAM_30";
			shpPayUpAM[30].TabIndex = 348;
			shpPayUpAM[30].Visible = false;
			shpPayUpAM[29].AllowDrop = true;
			shpPayUpAM[29].Enabled = false;
			shpPayUpAM[29].Name = "_shpPayUpAM_29";
			shpPayUpAM[29].TabIndex = 349;
			shpPayUpAM[29].Visible = false;
			shpPayUpAM[28].AllowDrop = true;
			shpPayUpAM[28].Enabled = false;
			shpPayUpAM[28].Name = "_shpPayUpAM_28";
			shpPayUpAM[28].TabIndex = 350;
			shpPayUpAM[28].Visible = false;
			shpPayUpAM[27].AllowDrop = true;
			shpPayUpAM[27].Enabled = false;
			shpPayUpAM[27].Name = "_shpPayUpAM_27";
			shpPayUpAM[27].TabIndex = 351;
			shpPayUpAM[27].Visible = false;
			shpPayUpAM[26].AllowDrop = true;
			shpPayUpAM[26].Enabled = false;
			shpPayUpAM[26].Name = "_shpPayUpAM_26";
			shpPayUpAM[26].TabIndex = 352;
			shpPayUpAM[26].Visible = false;
			shpPayUpAM[25].AllowDrop = true;
			shpPayUpAM[25].Enabled = false;
			shpPayUpAM[25].Name = "_shpPayUpAM_25";
			shpPayUpAM[25].TabIndex = 353;
			shpPayUpAM[25].Visible = false;
			shpPayUpAM[24].AllowDrop = true;
			shpPayUpAM[24].Enabled = false;
			shpPayUpAM[24].Name = "_shpPayUpAM_24";
			shpPayUpAM[24].TabIndex = 354;
			shpPayUpAM[24].Visible = false;
			shpPayUpAM[23].AllowDrop = true;
			shpPayUpAM[23].Enabled = false;
			shpPayUpAM[23].Name = "_shpPayUpAM_23";
			shpPayUpAM[23].TabIndex = 355;
			shpPayUpAM[23].Visible = false;
			shpPayUpAM[22].AllowDrop = true;
			shpPayUpAM[22].Enabled = false;
			shpPayUpAM[22].Name = "_shpPayUpAM_22";
			shpPayUpAM[22].TabIndex = 356;
			shpPayUpAM[22].Visible = false;
			shpPayUpAM[21].AllowDrop = true;
			shpPayUpAM[21].Enabled = false;
			shpPayUpAM[21].Name = "_shpPayUpAM_21";
			shpPayUpAM[21].TabIndex = 357;
			shpPayUpAM[21].Visible = false;
			shpPayUpAM[20].AllowDrop = true;
			shpPayUpAM[20].Enabled = false;
			shpPayUpAM[20].Name = "_shpPayUpAM_20";
			shpPayUpAM[20].TabIndex = 358;
			shpPayUpAM[20].Visible = false;
			shpPayUpAM[19].AllowDrop = true;
			shpPayUpAM[19].Enabled = false;
			shpPayUpAM[19].Name = "_shpPayUpAM_19";
			shpPayUpAM[19].TabIndex = 359;
			shpPayUpAM[19].Visible = false;
			shpPayUpAM[18].AllowDrop = true;
			shpPayUpAM[18].Enabled = false;
			shpPayUpAM[18].Name = "_shpPayUpAM_18";
			shpPayUpAM[18].TabIndex = 360;
			shpPayUpAM[18].Visible = false;
			shpPayUpAM[17].AllowDrop = true;
			shpPayUpAM[17].Enabled = false;
			shpPayUpAM[17].Name = "_shpPayUpAM_17";
			shpPayUpAM[17].TabIndex = 361;
			shpPayUpAM[17].Visible = false;
			shpPayUpAM[16].AllowDrop = true;
			shpPayUpAM[16].Enabled = false;
			shpPayUpAM[16].Name = "_shpPayUpAM_16";
			shpPayUpAM[16].TabIndex = 362;
			shpPayUpAM[16].Visible = false;
			shpPayUpAM[15].AllowDrop = true;
			shpPayUpAM[15].Enabled = false;
			shpPayUpAM[15].Name = "_shpPayUpAM_15";
			shpPayUpAM[15].TabIndex = 363;
			shpPayUpAM[15].Visible = false;
			shpPayUpAM[14].AllowDrop = true;
			shpPayUpAM[14].Enabled = false;
			shpPayUpAM[14].Name = "_shpPayUpAM_14";
			shpPayUpAM[14].TabIndex = 364;
			shpPayUpAM[14].Visible = false;
			shpPayUpAM[13].AllowDrop = true;
			shpPayUpAM[13].Enabled = false;
			shpPayUpAM[13].Name = "_shpPayUpAM_13";
			shpPayUpAM[13].TabIndex = 365;
			shpPayUpAM[13].Visible = false;
			shpPayUpAM[12].AllowDrop = true;
			shpPayUpAM[12].Enabled = false;
			shpPayUpAM[12].Name = "_shpPayUpAM_12";
			shpPayUpAM[12].TabIndex = 366;
			shpPayUpAM[12].Visible = false;
			shpPayUpAM[11].AllowDrop = true;
			shpPayUpAM[11].Enabled = false;
			shpPayUpAM[11].Name = "_shpPayUpAM_11";
			shpPayUpAM[11].TabIndex = 367;
			shpPayUpAM[11].Visible = false;
			shpPayUpAM[10].AllowDrop = true;
			shpPayUpAM[10].Enabled = false;
			shpPayUpAM[10].Name = "_shpPayUpAM_10";
			shpPayUpAM[10].TabIndex = 368;
			shpPayUpAM[10].Visible = false;
			shpPayUpAM[9].AllowDrop = true;
			shpPayUpAM[9].Enabled = false;
			shpPayUpAM[9].Name = "_shpPayUpAM_9";
			shpPayUpAM[9].TabIndex = 369;
			shpPayUpAM[9].Visible = false;
			shpPayUpAM[8].AllowDrop = true;
			shpPayUpAM[8].Enabled = false;
			shpPayUpAM[8].Name = "_shpPayUpAM_8";
			shpPayUpAM[8].TabIndex = 370;
			shpPayUpAM[8].Visible = false;
			shpPayUpAM[7].AllowDrop = true;
			shpPayUpAM[7].Enabled = false;
			shpPayUpAM[7].Name = "_shpPayUpAM_7";
			shpPayUpAM[7].TabIndex = 371;
			shpPayUpAM[7].Visible = false;
			shpPayUpAM[6].AllowDrop = true;
			shpPayUpAM[6].Enabled = false;
			shpPayUpAM[6].Name = "_shpPayUpAM_6";
			shpPayUpAM[6].TabIndex = 372;
			shpPayUpAM[6].Visible = false;
			shpPayUpAM[5].AllowDrop = true;
			shpPayUpAM[5].Enabled = false;
			shpPayUpAM[5].Name = "_shpPayUpAM_5";
			shpPayUpAM[5].TabIndex = 373;
			shpPayUpAM[5].Visible = false;
			shpPayUpAM[4].AllowDrop = true;
			shpPayUpAM[4].Enabled = false;
			shpPayUpAM[4].Name = "_shpPayUpAM_4";
			shpPayUpAM[4].TabIndex = 374;
			shpPayUpAM[4].Visible = false;
			shpPayUpAM[3].AllowDrop = true;
			shpPayUpAM[3].Enabled = false;
			shpPayUpAM[3].Name = "_shpPayUpAM_3";
			shpPayUpAM[3].TabIndex = 375;
			shpPayUpAM[3].Visible = false;
			shpPayUpAM[2].AllowDrop = true;
			shpPayUpAM[2].Enabled = false;
			shpPayUpAM[2].Name = "_shpPayUpAM_2";
			shpPayUpAM[2].TabIndex = 376;
			shpPayUpAM[2].Visible = false;
			shpPayUpAM[1].AllowDrop = true;
			shpPayUpAM[1].Enabled = false;
			shpPayUpAM[1].Name = "_shpPayUpAM_1";
			shpPayUpAM[1].TabIndex = 377;
			shpPayUpAM[1].Visible = false;
			shpPayUpAM[0].AllowDrop = true;
			shpPayUpAM[0].Enabled = false;
			shpPayUpAM[0].Name = "_shpPayUpAM_0";
			shpPayUpAM[0].TabIndex = 379;
			shpPayUpAM[0].Visible = false;
			lbPositionPM = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(54);
			lbPositionPM[48] = _lbPositionPM_48;
			lbPositionPM[45] = _lbPositionPM_45;
			lbPositionPM[46] = _lbPositionPM_46;
			lbPositionPM[47] = _lbPositionPM_47;
			lbPositionPM[49] = _lbPositionPM_49;
			lbPositionPM[50] = _lbPositionPM_50;
			lbPositionPM[53] = _lbPositionPM_53;
			lbPositionPM[52] = _lbPositionPM_52;
			lbPositionPM[51] = _lbPositionPM_51;
			lbPositionPM[44] = _lbPositionPM_44;
			lbPositionPM[43] = _lbPositionPM_43;
			lbPositionPM[42] = _lbPositionPM_42;
			lbPositionPM[41] = _lbPositionPM_41;
			lbPositionPM[40] = _lbPositionPM_40;
			lbPositionPM[39] = _lbPositionPM_39;
			lbPositionPM[38] = _lbPositionPM_38;
			lbPositionPM[37] = _lbPositionPM_37;
			lbPositionPM[36] = _lbPositionPM_36;
			lbPositionPM[35] = _lbPositionPM_35;
			lbPositionPM[34] = _lbPositionPM_34;
			lbPositionPM[33] = _lbPositionPM_33;
			lbPositionPM[32] = _lbPositionPM_32;
			lbPositionPM[31] = _lbPositionPM_31;
			lbPositionPM[30] = _lbPositionPM_30;
			lbPositionPM[29] = _lbPositionPM_29;
			lbPositionPM[28] = _lbPositionPM_28;
			lbPositionPM[27] = _lbPositionPM_27;
			lbPositionPM[26] = _lbPositionPM_26;
			lbPositionPM[25] = _lbPositionPM_25;
			lbPositionPM[24] = _lbPositionPM_24;
			lbPositionPM[23] = _lbPositionPM_23;
			lbPositionPM[22] = _lbPositionPM_22;
			lbPositionPM[21] = _lbPositionPM_21;
			lbPositionPM[20] = _lbPositionPM_20;
			lbPositionPM[19] = _lbPositionPM_19;
			lbPositionPM[18] = _lbPositionPM_18;
			lbPositionPM[17] = _lbPositionPM_17;
			lbPositionPM[16] = _lbPositionPM_16;
			lbPositionPM[15] = _lbPositionPM_15;
			lbPositionPM[14] = _lbPositionPM_14;
			lbPositionPM[13] = _lbPositionPM_13;
			lbPositionPM[12] = _lbPositionPM_12;
			lbPositionPM[11] = _lbPositionPM_11;
			lbPositionPM[10] = _lbPositionPM_10;
			lbPositionPM[9] = _lbPositionPM_9;
			lbPositionPM[8] = _lbPositionPM_8;
			lbPositionPM[7] = _lbPositionPM_7;
			lbPositionPM[6] = _lbPositionPM_6;
			lbPositionPM[5] = _lbPositionPM_5;
			lbPositionPM[4] = _lbPositionPM_4;
			lbPositionPM[3] = _lbPositionPM_3;
			lbPositionPM[2] = _lbPositionPM_2;
			lbPositionPM[1] = _lbPositionPM_1;
			lbPositionPM[0] = _lbPositionPM_0;
			lbPositionPM[48].AllowDrop = true;
			lbPositionPM[48].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[48].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[48].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[48].Name = "_lbPositionPM_48";
			lbPositionPM[48].TabIndex = 241;
			lbPositionPM[48].Text = "FFDISP2";
			lbPositionPM[48].Visible = false;
			lbPositionPM[45].AllowDrop = true;
			lbPositionPM[45].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[45].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[45].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[45].Name = "_lbPositionPM_45";
			lbPositionPM[45].TabIndex = 236;
			lbPositionPM[45].Text = "FCCCTO";
			lbPositionPM[45].Visible = false;
			lbPositionPM[46].AllowDrop = true;
			lbPositionPM[46].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[46].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[46].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[46].Name = "_lbPositionPM_46";
			lbPositionPM[46].TabIndex = 235;
			lbPositionPM[46].Text = "FCCOFF";
			lbPositionPM[46].Visible = false;
			lbPositionPM[47].AllowDrop = true;
			lbPositionPM[47].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[47].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[47].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[47].Name = "_lbPositionPM_47";
			lbPositionPM[47].TabIndex = 227;
			lbPositionPM[47].Text = "FFDISP1";
			lbPositionPM[47].Visible = false;
			lbPositionPM[49].AllowDrop = true;
			lbPositionPM[49].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[49].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[49].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[49].Name = "_lbPositionPM_49";
			lbPositionPM[49].TabIndex = 223;
			lbPositionPM[49].Text = "FFDISP3";
			lbPositionPM[49].Visible = false;
			lbPositionPM[50].AllowDrop = true;
			lbPositionPM[50].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[50].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[50].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[50].Name = "_lbPositionPM_50";
			lbPositionPM[50].TabIndex = 221;
			lbPositionPM[50].Text = "FFDISP4";
			lbPositionPM[50].Visible = false;
			lbPositionPM[53].AllowDrop = true;
			lbPositionPM[53].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[53].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[53].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[53].Name = "_lbPositionPM_53";
			lbPositionPM[53].TabIndex = 220;
			lbPositionPM[53].Text = "FFDISP7";
			lbPositionPM[53].Visible = false;
			lbPositionPM[52].AllowDrop = true;
			lbPositionPM[52].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[52].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[52].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[52].Name = "_lbPositionPM_52";
			lbPositionPM[52].TabIndex = 218;
			lbPositionPM[52].Text = "FFDISP6";
			lbPositionPM[52].Visible = false;
			lbPositionPM[51].AllowDrop = true;
			lbPositionPM[51].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[51].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[51].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[51].Name = "_lbPositionPM_51";
			lbPositionPM[51].TabIndex = 215;
			lbPositionPM[51].Text = "FFDISP5";
			lbPositionPM[51].Visible = false;
			lbPositionPM[44].AllowDrop = true;
			lbPositionPM[44].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[44].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[44].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[44].Name = "_lbPositionPM_44";
			lbPositionPM[44].TabIndex = 214;
			lbPositionPM[44].Text = "FCCCP";
			lbPositionPM[44].Visible = false;
			lbPositionPM[43].AllowDrop = true;
			lbPositionPM[43].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[43].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[43].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[43].Name = "_lbPositionPM_43";
			lbPositionPM[43].TabIndex = 192;
			lbPositionPM[43].Visible = false;
			lbPositionPM[42].AllowDrop = true;
			lbPositionPM[42].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[42].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[42].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[42].Name = "_lbPositionPM_42";
			lbPositionPM[42].TabIndex = 191;
			lbPositionPM[42].Visible = false;
			lbPositionPM[41].AllowDrop = true;
			lbPositionPM[41].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[41].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[41].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[41].Name = "_lbPositionPM_41";
			lbPositionPM[41].TabIndex = 190;
			lbPositionPM[41].Text = " ";
			lbPositionPM[41].Visible = false;
			lbPositionPM[40].AllowDrop = true;
			lbPositionPM[40].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[40].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[40].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[40].Name = "_lbPositionPM_40";
			lbPositionPM[40].TabIndex = 189;
			lbPositionPM[40].Text = "SAFLT";
			lbPositionPM[40].Visible = false;
			lbPositionPM[39].AllowDrop = true;
			lbPositionPM[39].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[39].Name = "_lbPositionPM_39";
			lbPositionPM[39].TabIndex = 188;
			lbPositionPM[39].Visible = false;
			lbPositionPM[38].AllowDrop = true;
			lbPositionPM[38].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[38].Name = "_lbPositionPM_38";
			lbPositionPM[38].TabIndex = 187;
			lbPositionPM[38].Visible = false;
			lbPositionPM[37].AllowDrop = true;
			lbPositionPM[37].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[37].Name = "_lbPositionPM_37";
			lbPositionPM[37].TabIndex = 186;
			lbPositionPM[37].Text = "DR";
			lbPositionPM[37].Visible = false;
			lbPositionPM[36].AllowDrop = true;
			lbPositionPM[36].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[36].Name = "_lbPositionPM_36";
			lbPositionPM[36].TabIndex = 185;
			lbPositionPM[36].Text = "OFF";
			lbPositionPM[36].Visible = false;
			lbPositionPM[35].AllowDrop = true;
			lbPositionPM[35].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[35].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[35].Name = "_lbPositionPM_35";
			lbPositionPM[35].TabIndex = 184;
			lbPositionPM[35].Text = "4TH";
			lbPositionPM[35].Visible = false;
			lbPositionPM[34].AllowDrop = true;
			lbPositionPM[34].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[34].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[34].Name = "_lbPositionPM_34";
			lbPositionPM[34].TabIndex = 183;
			lbPositionPM[34].Text = "STUDENT";
			lbPositionPM[34].Visible = false;
			lbPositionPM[33].AllowDrop = true;
			lbPositionPM[33].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[33].Name = "_lbPositionPM_33";
			lbPositionPM[33].TabIndex = 182;
			lbPositionPM[33].Text = "DR";
			lbPositionPM[33].Visible = false;
			lbPositionPM[32].AllowDrop = true;
			lbPositionPM[32].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[32].Name = "_lbPositionPM_32";
			lbPositionPM[32].TabIndex = 181;
			lbPositionPM[32].Text = "INCHG";
			lbPositionPM[32].Visible = false;
			lbPositionPM[31].AllowDrop = true;
			lbPositionPM[31].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[31].Name = "_lbPositionPM_31";
			lbPositionPM[31].TabIndex = 180;
			lbPositionPM[31].Text = "4TH";
			lbPositionPM[31].Visible = false;
			lbPositionPM[30].AllowDrop = true;
			lbPositionPM[30].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[30].Name = "_lbPositionPM_30";
			lbPositionPM[30].TabIndex = 179;
			lbPositionPM[30].Text = "3RD";
			lbPositionPM[30].Visible = false;
			lbPositionPM[29].AllowDrop = true;
			lbPositionPM[29].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[29].Name = "_lbPositionPM_29";
			lbPositionPM[29].TabIndex = 178;
			lbPositionPM[29].Text = "DR";
			lbPositionPM[29].Visible = false;
			lbPositionPM[28].AllowDrop = true;
			lbPositionPM[28].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[28].Name = "_lbPositionPM_28";
			lbPositionPM[28].TabIndex = 177;
			lbPositionPM[28].Text = "OFF";
			lbPositionPM[28].Visible = false;
			lbPositionPM[27].AllowDrop = true;
			lbPositionPM[27].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[27].Name = "_lbPositionPM_27";
			lbPositionPM[27].TabIndex = 176;
			lbPositionPM[27].Text = "4TH";
			lbPositionPM[27].Visible = false;
			lbPositionPM[26].AllowDrop = true;
			lbPositionPM[26].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[26].Name = "_lbPositionPM_26";
			lbPositionPM[26].TabIndex = 175;
			lbPositionPM[26].Text = "3RD";
			lbPositionPM[26].Visible = false;
			lbPositionPM[25].AllowDrop = true;
			lbPositionPM[25].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[25].Name = "_lbPositionPM_25";
			lbPositionPM[25].TabIndex = 174;
			lbPositionPM[25].Text = "DR";
			lbPositionPM[25].Visible = false;
			lbPositionPM[24].AllowDrop = true;
			lbPositionPM[24].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[24].Name = "_lbPositionPM_24";
			lbPositionPM[24].TabIndex = 173;
			lbPositionPM[24].Text = "OFF";
			lbPositionPM[24].Visible = false;
			lbPositionPM[23].AllowDrop = true;
			lbPositionPM[23].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[23].Name = "_lbPositionPM_23";
			lbPositionPM[23].TabIndex = 172;
			lbPositionPM[23].Text = "4TH";
			lbPositionPM[23].Visible = false;
			lbPositionPM[22].AllowDrop = true;
			lbPositionPM[22].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[22].Name = "_lbPositionPM_22";
			lbPositionPM[22].TabIndex = 171;
			lbPositionPM[22].Text = "3RD";
			lbPositionPM[22].Visible = false;
			lbPositionPM[21].AllowDrop = true;
			lbPositionPM[21].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[21].Name = "_lbPositionPM_21";
			lbPositionPM[21].TabIndex = 170;
			lbPositionPM[21].Text = "DR";
			lbPositionPM[21].Visible = false;
			lbPositionPM[20].AllowDrop = true;
			lbPositionPM[20].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[20].Name = "_lbPositionPM_20";
			lbPositionPM[20].TabIndex = 169;
			lbPositionPM[20].Text = "OFF";
			lbPositionPM[20].Visible = false;
			lbPositionPM[19].AllowDrop = true;
			lbPositionPM[19].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[19].Name = "_lbPositionPM_19";
			lbPositionPM[19].TabIndex = 168;
			lbPositionPM[19].Text = "4TH";
			lbPositionPM[19].Visible = false;
			lbPositionPM[18].AllowDrop = true;
			lbPositionPM[18].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[18].Name = "_lbPositionPM_18";
			lbPositionPM[18].TabIndex = 167;
			lbPositionPM[18].Text = "3RD";
			lbPositionPM[18].Visible = false;
			lbPositionPM[17].AllowDrop = true;
			lbPositionPM[17].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[17].Name = "_lbPositionPM_17";
			lbPositionPM[17].TabIndex = 166;
			lbPositionPM[17].Text = "DR";
			lbPositionPM[17].Visible = false;
			lbPositionPM[16].AllowDrop = true;
			lbPositionPM[16].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[16].Name = "_lbPositionPM_16";
			lbPositionPM[16].TabIndex = 165;
			lbPositionPM[16].Text = "OFF";
			lbPositionPM[16].Visible = false;
			lbPositionPM[15].AllowDrop = true;
			lbPositionPM[15].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[15].Name = "_lbPositionPM_15";
			lbPositionPM[15].TabIndex = 164;
			lbPositionPM[15].Text = "4TH";
			lbPositionPM[15].Visible = false;
			lbPositionPM[14].AllowDrop = true;
			lbPositionPM[14].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[14].Name = "_lbPositionPM_14";
			lbPositionPM[14].TabIndex = 163;
			lbPositionPM[14].Text = "3RD";
			lbPositionPM[14].Visible = false;
			lbPositionPM[13].AllowDrop = true;
			lbPositionPM[13].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[13].Name = "_lbPositionPM_13";
			lbPositionPM[13].TabIndex = 162;
			lbPositionPM[13].Text = "DR";
			lbPositionPM[13].Visible = false;
			lbPositionPM[12].AllowDrop = true;
			lbPositionPM[12].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[12].Name = "_lbPositionPM_12";
			lbPositionPM[12].TabIndex = 161;
			lbPositionPM[12].Text = "OFF";
			lbPositionPM[12].Visible = false;
			lbPositionPM[11].AllowDrop = true;
			lbPositionPM[11].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[11].Name = "_lbPositionPM_11";
			lbPositionPM[11].TabIndex = 160;
			lbPositionPM[11].Text = "4TH";
			lbPositionPM[11].Visible = false;
			lbPositionPM[10].AllowDrop = true;
			lbPositionPM[10].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[10].Name = "_lbPositionPM_10";
			lbPositionPM[10].TabIndex = 159;
			lbPositionPM[10].Text = "3RD";
			lbPositionPM[10].Visible = false;
			lbPositionPM[9].AllowDrop = true;
			lbPositionPM[9].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[9].Name = "_lbPositionPM_9";
			lbPositionPM[9].TabIndex = 158;
			lbPositionPM[9].Text = "DR";
			lbPositionPM[9].Visible = false;
			lbPositionPM[8].AllowDrop = true;
			lbPositionPM[8].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[8].Name = "_lbPositionPM_8";
			lbPositionPM[8].TabIndex = 157;
			lbPositionPM[8].Text = "OFF";
			lbPositionPM[8].Visible = false;
			lbPositionPM[7].AllowDrop = true;
			lbPositionPM[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[7].Name = "_lbPositionPM_7";
			lbPositionPM[7].TabIndex = 156;
			lbPositionPM[7].Text = "4TH";
			lbPositionPM[7].Visible = false;
			lbPositionPM[6].AllowDrop = true;
			lbPositionPM[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[6].Name = "_lbPositionPM_6";
			lbPositionPM[6].TabIndex = 155;
			lbPositionPM[6].Text = "3RD";
			lbPositionPM[6].Visible = false;
			lbPositionPM[5].AllowDrop = true;
			lbPositionPM[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[5].Name = "_lbPositionPM_5";
			lbPositionPM[5].TabIndex = 154;
			lbPositionPM[5].Text = "DR";
			lbPositionPM[5].Visible = false;
			lbPositionPM[4].AllowDrop = true;
			lbPositionPM[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[4].Name = "_lbPositionPM_4";
			lbPositionPM[4].TabIndex = 153;
			lbPositionPM[4].Text = "OFF";
			lbPositionPM[4].Visible = false;
			lbPositionPM[3].AllowDrop = true;
			lbPositionPM[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[3].Name = "_lbPositionPM_3";
			lbPositionPM[3].TabIndex = 152;
			lbPositionPM[3].Visible = false;
			lbPositionPM[2].AllowDrop = true;
			lbPositionPM[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[2].Name = "_lbPositionPM_2";
			lbPositionPM[2].TabIndex = 151;
			lbPositionPM[2].Visible = false;
			lbPositionPM[1].AllowDrop = true;
			lbPositionPM[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[1].Name = "_lbPositionPM_1";
			lbPositionPM[1].TabIndex = 150;
			lbPositionPM[1].Text = "PLNOFF";
			lbPositionPM[1].Visible = false;
			lbPositionPM[0].AllowDrop = true;
			lbPositionPM[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[0].Name = "_lbPositionPM_0";
			lbPositionPM[0].TabIndex = 149;
			lbPositionPM[0].Text = "BC";
			lbPositionPM[0].Visible = false;
			lbPospm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(54);
			lbPospm[43] = _lbPospm_43;
			lbPospm[42] = _lbPospm_42;
			lbPospm[41] = _lbPospm_41;
			lbPospm[40] = _lbPospm_40;
			lbPospm[39] = _lbPospm_39;
			lbPospm[38] = _lbPospm_38;
			lbPospm[37] = _lbPospm_37;
			lbPospm[36] = _lbPospm_36;
			lbPospm[35] = _lbPospm_35;
			lbPospm[34] = _lbPospm_34;
			lbPospm[33] = _lbPospm_33;
			lbPospm[32] = _lbPospm_32;
			lbPospm[31] = _lbPospm_31;
			lbPospm[30] = _lbPospm_30;
			lbPospm[29] = _lbPospm_29;
			lbPospm[28] = _lbPospm_28;
			lbPospm[27] = _lbPospm_27;
			lbPospm[26] = _lbPospm_26;
			lbPospm[25] = _lbPospm_25;
			lbPospm[24] = _lbPospm_24;
			lbPospm[23] = _lbPospm_23;
			lbPospm[22] = _lbPospm_22;
			lbPospm[21] = _lbPospm_21;
			lbPospm[20] = _lbPospm_20;
			lbPospm[19] = _lbPospm_19;
			lbPospm[18] = _lbPospm_18;
			lbPospm[17] = _lbPospm_17;
			lbPospm[16] = _lbPospm_16;
			lbPospm[15] = _lbPospm_15;
			lbPospm[14] = _lbPospm_14;
			lbPospm[13] = _lbPospm_13;
			lbPospm[12] = _lbPospm_12;
			lbPospm[11] = _lbPospm_11;
			lbPospm[10] = _lbPospm_10;
			lbPospm[9] = _lbPospm_9;
			lbPospm[8] = _lbPospm_8;
			lbPospm[7] = _lbPospm_7;
			lbPospm[6] = _lbPospm_6;
			lbPospm[5] = _lbPospm_5;
			lbPospm[4] = _lbPospm_4;
			lbPospm[3] = _lbPospm_3;
			lbPospm[2] = _lbPospm_2;
			lbPospm[1] = _lbPospm_1;
			lbPospm[0] = _lbPospm_0;
			lbPospm[44] = _lbPospm_44;
			lbPospm[45] = _lbPospm_45;
			lbPospm[46] = _lbPospm_46;
			lbPospm[47] = _lbPospm_47;
			lbPospm[53] = _lbPospm_53;
			lbPospm[52] = _lbPospm_52;
			lbPospm[51] = _lbPospm_51;
			lbPospm[50] = _lbPospm_50;
			lbPospm[49] = _lbPospm_49;
			lbPospm[48] = _lbPospm_48;
			lbPospm[43].AllowDrop = true;
			lbPospm[43].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[43].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[43].Name = "_lbPospm_43";
			lbPospm[43].TabIndex = 148;
			lbPospm[43].Visible = false;
			lbPospm[42].AllowDrop = true;
			lbPospm[42].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[42].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[42].Name = "_lbPospm_42";
			lbPospm[42].TabIndex = 147;
			lbPospm[42].Visible = false;
			lbPospm[41].AllowDrop = true;
			lbPospm[41].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[41].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[41].Name = "_lbPospm_41";
			lbPospm[41].TabIndex = 146;
			lbPospm[41].Visible = false;
			lbPospm[40].AllowDrop = true;
			lbPospm[40].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[40].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[40].Name = "_lbPospm_40";
			lbPospm[40].TabIndex = 145;
			lbPospm[39].AllowDrop = true;
			lbPospm[39].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[39].Name = "_lbPospm_39";
			lbPospm[39].TabIndex = 139;
			lbPospm[39].Visible = false;
			lbPospm[38].AllowDrop = true;
			lbPospm[38].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[38].Name = "_lbPospm_38";
			lbPospm[38].TabIndex = 138;
			lbPospm[38].Visible = false;
			lbPospm[37].AllowDrop = true;
			lbPospm[37].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[37].Name = "_lbPospm_37";
			lbPospm[37].TabIndex = 137;
			lbPospm[36].AllowDrop = true;
			lbPospm[36].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[36].Name = "_lbPospm_36";
			lbPospm[36].TabIndex = 136;
			lbPospm[35].AllowDrop = true;
			lbPospm[35].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[35].Name = "_lbPospm_35";
			lbPospm[35].TabIndex = 130;
			lbPospm[35].Visible = false;
			lbPospm[34].AllowDrop = true;
			lbPospm[34].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[34].Name = "_lbPospm_34";
			lbPospm[34].TabIndex = 129;
			lbPospm[33].AllowDrop = true;
			lbPospm[33].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[33].Name = "_lbPospm_33";
			lbPospm[33].TabIndex = 128;
			lbPospm[32].AllowDrop = true;
			lbPospm[32].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[32].Name = "_lbPospm_32";
			lbPospm[32].TabIndex = 127;
			lbPospm[31].AllowDrop = true;
			lbPospm[31].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[31].Name = "_lbPospm_31";
			lbPospm[31].TabIndex = 121;
			lbPospm[30].AllowDrop = true;
			lbPospm[30].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[30].Name = "_lbPospm_30";
			lbPospm[30].TabIndex = 120;
			lbPospm[29].AllowDrop = true;
			lbPospm[29].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[29].Name = "_lbPospm_29";
			lbPospm[29].TabIndex = 119;
			lbPospm[28].AllowDrop = true;
			lbPospm[28].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[28].Name = "_lbPospm_28";
			lbPospm[28].TabIndex = 118;
			lbPospm[27].AllowDrop = true;
			lbPospm[27].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[27].Name = "_lbPospm_27";
			lbPospm[27].TabIndex = 112;
			lbPospm[26].AllowDrop = true;
			lbPospm[26].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[26].Name = "_lbPospm_26";
			lbPospm[26].TabIndex = 111;
			lbPospm[25].AllowDrop = true;
			lbPospm[25].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[25].Name = "_lbPospm_25";
			lbPospm[25].TabIndex = 110;
			lbPospm[24].AllowDrop = true;
			lbPospm[24].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[24].Name = "_lbPospm_24";
			lbPospm[24].TabIndex = 109;
			lbPospm[23].AllowDrop = true;
			lbPospm[23].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[23].Name = "_lbPospm_23";
			lbPospm[23].TabIndex = 103;
			lbPospm[22].AllowDrop = true;
			lbPospm[22].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[22].Name = "_lbPospm_22";
			lbPospm[22].TabIndex = 102;
			lbPospm[21].AllowDrop = true;
			lbPospm[21].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[21].Name = "_lbPospm_21";
			lbPospm[21].TabIndex = 101;
			lbPospm[20].AllowDrop = true;
			lbPospm[20].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[20].Name = "_lbPospm_20";
			lbPospm[20].TabIndex = 100;
			lbPospm[19].AllowDrop = true;
			lbPospm[19].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[19].Name = "_lbPospm_19";
			lbPospm[19].TabIndex = 90;
			lbPospm[18].AllowDrop = true;
			lbPospm[18].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[18].Name = "_lbPospm_18";
			lbPospm[18].TabIndex = 89;
			lbPospm[17].AllowDrop = true;
			lbPospm[17].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[17].Name = "_lbPospm_17";
			lbPospm[17].TabIndex = 88;
			lbPospm[16].AllowDrop = true;
			lbPospm[16].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[16].Name = "_lbPospm_16";
			lbPospm[16].TabIndex = 87;
			lbPospm[15].AllowDrop = true;
			lbPospm[15].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[15].Name = "_lbPospm_15";
			lbPospm[15].TabIndex = 86;
			lbPospm[14].AllowDrop = true;
			lbPospm[14].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[14].Name = "_lbPospm_14";
			lbPospm[14].TabIndex = 85;
			lbPospm[13].AllowDrop = true;
			lbPospm[13].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[13].Name = "_lbPospm_13";
			lbPospm[13].TabIndex = 84;
			lbPospm[12].AllowDrop = true;
			lbPospm[12].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[12].Name = "_lbPospm_12";
			lbPospm[12].TabIndex = 83;
			lbPospm[11].AllowDrop = true;
			lbPospm[11].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[11].Name = "_lbPospm_11";
			lbPospm[11].TabIndex = 82;
			lbPospm[10].AllowDrop = true;
			lbPospm[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[10].Name = "_lbPospm_10";
			lbPospm[10].TabIndex = 81;
			lbPospm[9].AllowDrop = true;
			lbPospm[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[9].Name = "_lbPospm_9";
			lbPospm[9].TabIndex = 80;
			lbPospm[8].AllowDrop = true;
			lbPospm[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[8].Name = "_lbPospm_8";
			lbPospm[8].TabIndex = 79;
			lbPospm[7].AllowDrop = true;
			lbPospm[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[7].Name = "_lbPospm_7";
			lbPospm[7].TabIndex = 78;
			lbPospm[6].AllowDrop = true;
			lbPospm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[6].Name = "_lbPospm_6";
			lbPospm[6].TabIndex = 77;
			lbPospm[5].AllowDrop = true;
			lbPospm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[5].Name = "_lbPospm_5";
			lbPospm[5].TabIndex = 76;
			lbPospm[4].AllowDrop = true;
			lbPospm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[4].Name = "_lbPospm_4";
			lbPospm[4].TabIndex = 75;
			lbPospm[3].AllowDrop = true;
			lbPospm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[3].Name = "_lbPospm_3";
			lbPospm[3].TabIndex = 74;
			lbPospm[3].Visible = false;
			lbPospm[2].AllowDrop = true;
			lbPospm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[2].Name = "_lbPospm_2";
			lbPospm[2].TabIndex = 73;
			lbPospm[2].Visible = false;
			lbPospm[1].AllowDrop = true;
			lbPospm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[1].Name = "_lbPospm_1";
			lbPospm[1].TabIndex = 72;
			lbPospm[0].AllowDrop = true;
			lbPospm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[0].Name = "_lbPospm_0";
			lbPospm[0].TabIndex = 34;
			lbPospm[44].AllowDrop = true;
			lbPospm[44].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[44].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[44].Name = "_lbPospm_44";
			lbPospm[44].TabIndex = 231;
			lbPospm[44].Text = " ";
			lbPospm[45].AllowDrop = true;
			lbPospm[45].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[45].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[45].Name = "_lbPospm_45";
			lbPospm[45].TabIndex = 230;
			lbPospm[45].Text = " ";
			lbPospm[46].AllowDrop = true;
			lbPospm[46].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[46].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[46].Name = "_lbPospm_46";
			lbPospm[46].TabIndex = 229;
			lbPospm[46].Text = " ";
			lbPospm[47].AllowDrop = true;
			lbPospm[47].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[47].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[47].Name = "_lbPospm_47";
			lbPospm[47].TabIndex = 225;
			lbPospm[47].Text = " ";
			lbPospm[53].AllowDrop = true;
			lbPospm[53].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[53].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[53].Name = "_lbPospm_53";
			lbPospm[53].TabIndex = 253;
			lbPospm[53].Text = " ";
			lbPospm[52].AllowDrop = true;
			lbPospm[52].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[52].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[52].Name = "_lbPospm_52";
			lbPospm[52].TabIndex = 251;
			lbPospm[52].Text = " ";
			lbPospm[51].AllowDrop = true;
			lbPospm[51].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[51].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[51].Name = "_lbPospm_51";
			lbPospm[51].TabIndex = 249;
			lbPospm[51].Text = " ";
			lbPospm[50].AllowDrop = true;
			lbPospm[50].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[50].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[50].Name = "_lbPospm_50";
			lbPospm[50].TabIndex = 247;
			lbPospm[50].Text = " ";
			lbPospm[49].AllowDrop = true;
			lbPospm[49].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[49].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[49].Name = "_lbPospm_49";
			lbPospm[49].TabIndex = 245;
			lbPospm[49].Text = " ";
			lbPospm[48].AllowDrop = true;
			lbPospm[48].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[48].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[48].Name = "_lbPospm_48";
			lbPospm[48].TabIndex = 243;
			lbPospm[48].Text = " ";
			shpPayUpPM = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(54);
			shpPayUpPM[48] = _shpPayUpPM_48;
			shpPayUpPM[44] = _shpPayUpPM_44;
			shpPayUpPM[45] = _shpPayUpPM_45;
			shpPayUpPM[46] = _shpPayUpPM_46;
			shpPayUpPM[47] = _shpPayUpPM_47;
			shpPayUpPM[49] = _shpPayUpPM_49;
			shpPayUpPM[50] = _shpPayUpPM_50;
			shpPayUpPM[53] = _shpPayUpPM_53;
			shpPayUpPM[52] = _shpPayUpPM_52;
			shpPayUpPM[51] = _shpPayUpPM_51;
			shpPayUpPM[43] = _shpPayUpPM_43;
			shpPayUpPM[42] = _shpPayUpPM_42;
			shpPayUpPM[41] = _shpPayUpPM_41;
			shpPayUpPM[40] = _shpPayUpPM_40;
			shpPayUpPM[39] = _shpPayUpPM_39;
			shpPayUpPM[38] = _shpPayUpPM_38;
			shpPayUpPM[37] = _shpPayUpPM_37;
			shpPayUpPM[36] = _shpPayUpPM_36;
			shpPayUpPM[35] = _shpPayUpPM_35;
			shpPayUpPM[34] = _shpPayUpPM_34;
			shpPayUpPM[33] = _shpPayUpPM_33;
			shpPayUpPM[32] = _shpPayUpPM_32;
			shpPayUpPM[31] = _shpPayUpPM_31;
			shpPayUpPM[30] = _shpPayUpPM_30;
			shpPayUpPM[29] = _shpPayUpPM_29;
			shpPayUpPM[28] = _shpPayUpPM_28;
			shpPayUpPM[27] = _shpPayUpPM_27;
			shpPayUpPM[26] = _shpPayUpPM_26;
			shpPayUpPM[25] = _shpPayUpPM_25;
			shpPayUpPM[24] = _shpPayUpPM_24;
			shpPayUpPM[23] = _shpPayUpPM_23;
			shpPayUpPM[22] = _shpPayUpPM_22;
			shpPayUpPM[21] = _shpPayUpPM_21;
			shpPayUpPM[20] = _shpPayUpPM_20;
			shpPayUpPM[19] = _shpPayUpPM_19;
			shpPayUpPM[18] = _shpPayUpPM_18;
			shpPayUpPM[17] = _shpPayUpPM_17;
			shpPayUpPM[16] = _shpPayUpPM_16;
			shpPayUpPM[15] = _shpPayUpPM_15;
			shpPayUpPM[14] = _shpPayUpPM_14;
			shpPayUpPM[13] = _shpPayUpPM_13;
			shpPayUpPM[12] = _shpPayUpPM_12;
			shpPayUpPM[11] = _shpPayUpPM_11;
			shpPayUpPM[10] = _shpPayUpPM_10;
			shpPayUpPM[9] = _shpPayUpPM_9;
			shpPayUpPM[8] = _shpPayUpPM_8;
			shpPayUpPM[7] = _shpPayUpPM_7;
			shpPayUpPM[6] = _shpPayUpPM_6;
			shpPayUpPM[5] = _shpPayUpPM_5;
			shpPayUpPM[4] = _shpPayUpPM_4;
			shpPayUpPM[3] = _shpPayUpPM_3;
			shpPayUpPM[2] = _shpPayUpPM_2;
			shpPayUpPM[1] = _shpPayUpPM_1;
			shpPayUpPM[0] = _shpPayUpPM_0;
			shpPayUpPM[48].AllowDrop = true;
			shpPayUpPM[48].Enabled = false;
			shpPayUpPM[48].Name = "_shpPayUpPM_48";
			shpPayUpPM[48].TabIndex = 271;
			shpPayUpPM[48].Visible = false;
			shpPayUpPM[44].AllowDrop = true;
			shpPayUpPM[44].Enabled = false;
			shpPayUpPM[44].Name = "_shpPayUpPM_44";
			shpPayUpPM[44].TabIndex = 277;
			shpPayUpPM[44].Visible = false;
			shpPayUpPM[45].AllowDrop = true;
			shpPayUpPM[45].Enabled = false;
			shpPayUpPM[45].Name = "_shpPayUpPM_45";
			shpPayUpPM[45].TabIndex = 278;
			shpPayUpPM[45].Visible = false;
			shpPayUpPM[46].AllowDrop = true;
			shpPayUpPM[46].Enabled = false;
			shpPayUpPM[46].Name = "_shpPayUpPM_46";
			shpPayUpPM[46].TabIndex = 279;
			shpPayUpPM[46].Visible = false;
			shpPayUpPM[47].AllowDrop = true;
			shpPayUpPM[47].Enabled = false;
			shpPayUpPM[47].Name = "_shpPayUpPM_47";
			shpPayUpPM[47].TabIndex = 281;
			shpPayUpPM[47].Visible = false;
			shpPayUpPM[49].AllowDrop = true;
			shpPayUpPM[49].Enabled = false;
			shpPayUpPM[49].Name = "_shpPayUpPM_49";
			shpPayUpPM[49].TabIndex = 283;
			shpPayUpPM[49].Visible = false;
			shpPayUpPM[50].AllowDrop = true;
			shpPayUpPM[50].Enabled = false;
			shpPayUpPM[50].Name = "_shpPayUpPM_50";
			shpPayUpPM[50].TabIndex = 285;
			shpPayUpPM[50].Visible = false;
			shpPayUpPM[53].AllowDrop = true;
			shpPayUpPM[53].Enabled = false;
			shpPayUpPM[53].Name = "_shpPayUpPM_53";
			shpPayUpPM[53].TabIndex = 286;
			shpPayUpPM[53].Visible = false;
			shpPayUpPM[52].AllowDrop = true;
			shpPayUpPM[52].Enabled = false;
			shpPayUpPM[52].Name = "_shpPayUpPM_52";
			shpPayUpPM[52].TabIndex = 288;
			shpPayUpPM[52].Visible = false;
			shpPayUpPM[51].AllowDrop = true;
			shpPayUpPM[51].Enabled = false;
			shpPayUpPM[51].Name = "_shpPayUpPM_51";
			shpPayUpPM[51].TabIndex = 291;
			shpPayUpPM[51].Visible = false;
			shpPayUpPM[43].AllowDrop = true;
			shpPayUpPM[43].Enabled = false;
			shpPayUpPM[43].Name = "_shpPayUpPM_43";
			shpPayUpPM[43].TabIndex = 292;
			shpPayUpPM[43].Visible = false;
			shpPayUpPM[42].AllowDrop = true;
			shpPayUpPM[42].Enabled = false;
			shpPayUpPM[42].Name = "_shpPayUpPM_42";
			shpPayUpPM[42].TabIndex = 293;
			shpPayUpPM[42].Visible = false;
			shpPayUpPM[41].AllowDrop = true;
			shpPayUpPM[41].Enabled = false;
			shpPayUpPM[41].Name = "_shpPayUpPM_41";
			shpPayUpPM[41].TabIndex = 294;
			shpPayUpPM[41].Visible = false;
			shpPayUpPM[40].AllowDrop = true;
			shpPayUpPM[40].Enabled = false;
			shpPayUpPM[40].Name = "_shpPayUpPM_40";
			shpPayUpPM[40].TabIndex = 295;
			shpPayUpPM[40].Visible = false;
			shpPayUpPM[39].AllowDrop = true;
			shpPayUpPM[39].Enabled = false;
			shpPayUpPM[39].Name = "_shpPayUpPM_39";
			shpPayUpPM[39].TabIndex = 296;
			shpPayUpPM[39].Visible = false;
			shpPayUpPM[38].AllowDrop = true;
			shpPayUpPM[38].Enabled = false;
			shpPayUpPM[38].Name = "_shpPayUpPM_38";
			shpPayUpPM[38].TabIndex = 297;
			shpPayUpPM[38].Visible = false;
			shpPayUpPM[37].AllowDrop = true;
			shpPayUpPM[37].Enabled = false;
			shpPayUpPM[37].Name = "_shpPayUpPM_37";
			shpPayUpPM[37].TabIndex = 298;
			shpPayUpPM[37].Visible = false;
			shpPayUpPM[36].AllowDrop = true;
			shpPayUpPM[36].Enabled = false;
			shpPayUpPM[36].Name = "_shpPayUpPM_36";
			shpPayUpPM[36].TabIndex = 299;
			shpPayUpPM[36].Visible = false;
			shpPayUpPM[35].AllowDrop = true;
			shpPayUpPM[35].Enabled = false;
			shpPayUpPM[35].Name = "_shpPayUpPM_35";
			shpPayUpPM[35].TabIndex = 300;
			shpPayUpPM[35].Visible = false;
			shpPayUpPM[34].AllowDrop = true;
			shpPayUpPM[34].Enabled = false;
			shpPayUpPM[34].Name = "_shpPayUpPM_34";
			shpPayUpPM[34].TabIndex = 301;
			shpPayUpPM[34].Visible = false;
			shpPayUpPM[33].AllowDrop = true;
			shpPayUpPM[33].Enabled = false;
			shpPayUpPM[33].Name = "_shpPayUpPM_33";
			shpPayUpPM[33].TabIndex = 302;
			shpPayUpPM[33].Visible = false;
			shpPayUpPM[32].AllowDrop = true;
			shpPayUpPM[32].Enabled = false;
			shpPayUpPM[32].Name = "_shpPayUpPM_32";
			shpPayUpPM[32].TabIndex = 303;
			shpPayUpPM[32].Visible = false;
			shpPayUpPM[31].AllowDrop = true;
			shpPayUpPM[31].Enabled = false;
			shpPayUpPM[31].Name = "_shpPayUpPM_31";
			shpPayUpPM[31].TabIndex = 304;
			shpPayUpPM[31].Visible = false;
			shpPayUpPM[30].AllowDrop = true;
			shpPayUpPM[30].Enabled = false;
			shpPayUpPM[30].Name = "_shpPayUpPM_30";
			shpPayUpPM[30].TabIndex = 305;
			shpPayUpPM[30].Visible = false;
			shpPayUpPM[29].AllowDrop = true;
			shpPayUpPM[29].Enabled = false;
			shpPayUpPM[29].Name = "_shpPayUpPM_29";
			shpPayUpPM[29].TabIndex = 306;
			shpPayUpPM[29].Visible = false;
			shpPayUpPM[28].AllowDrop = true;
			shpPayUpPM[28].Enabled = false;
			shpPayUpPM[28].Name = "_shpPayUpPM_28";
			shpPayUpPM[28].TabIndex = 307;
			shpPayUpPM[28].Visible = false;
			shpPayUpPM[27].AllowDrop = true;
			shpPayUpPM[27].Enabled = false;
			shpPayUpPM[27].Name = "_shpPayUpPM_27";
			shpPayUpPM[27].TabIndex = 308;
			shpPayUpPM[27].Visible = false;
			shpPayUpPM[26].AllowDrop = true;
			shpPayUpPM[26].Enabled = false;
			shpPayUpPM[26].Name = "_shpPayUpPM_26";
			shpPayUpPM[26].TabIndex = 309;
			shpPayUpPM[26].Visible = false;
			shpPayUpPM[25].AllowDrop = true;
			shpPayUpPM[25].Enabled = false;
			shpPayUpPM[25].Name = "_shpPayUpPM_25";
			shpPayUpPM[25].TabIndex = 310;
			shpPayUpPM[25].Visible = false;
			shpPayUpPM[24].AllowDrop = true;
			shpPayUpPM[24].Enabled = false;
			shpPayUpPM[24].Name = "_shpPayUpPM_24";
			shpPayUpPM[24].TabIndex = 311;
			shpPayUpPM[24].Visible = false;
			shpPayUpPM[23].AllowDrop = true;
			shpPayUpPM[23].Enabled = false;
			shpPayUpPM[23].Name = "_shpPayUpPM_23";
			shpPayUpPM[23].TabIndex = 312;
			shpPayUpPM[23].Visible = false;
			shpPayUpPM[22].AllowDrop = true;
			shpPayUpPM[22].Enabled = false;
			shpPayUpPM[22].Name = "_shpPayUpPM_22";
			shpPayUpPM[22].TabIndex = 313;
			shpPayUpPM[22].Visible = false;
			shpPayUpPM[21].AllowDrop = true;
			shpPayUpPM[21].Enabled = false;
			shpPayUpPM[21].Name = "_shpPayUpPM_21";
			shpPayUpPM[21].TabIndex = 314;
			shpPayUpPM[21].Visible = false;
			shpPayUpPM[20].AllowDrop = true;
			shpPayUpPM[20].Enabled = false;
			shpPayUpPM[20].Name = "_shpPayUpPM_20";
			shpPayUpPM[20].TabIndex = 315;
			shpPayUpPM[20].Visible = false;
			shpPayUpPM[19].AllowDrop = true;
			shpPayUpPM[19].Enabled = false;
			shpPayUpPM[19].Name = "_shpPayUpPM_19";
			shpPayUpPM[19].TabIndex = 316;
			shpPayUpPM[19].Visible = false;
			shpPayUpPM[18].AllowDrop = true;
			shpPayUpPM[18].Enabled = false;
			shpPayUpPM[18].Name = "_shpPayUpPM_18";
			shpPayUpPM[18].TabIndex = 317;
			shpPayUpPM[18].Visible = false;
			shpPayUpPM[17].AllowDrop = true;
			shpPayUpPM[17].Enabled = false;
			shpPayUpPM[17].Name = "_shpPayUpPM_17";
			shpPayUpPM[17].TabIndex = 318;
			shpPayUpPM[17].Visible = false;
			shpPayUpPM[16].AllowDrop = true;
			shpPayUpPM[16].Enabled = false;
			shpPayUpPM[16].Name = "_shpPayUpPM_16";
			shpPayUpPM[16].TabIndex = 319;
			shpPayUpPM[16].Visible = false;
			shpPayUpPM[15].AllowDrop = true;
			shpPayUpPM[15].Enabled = false;
			shpPayUpPM[15].Name = "_shpPayUpPM_15";
			shpPayUpPM[15].TabIndex = 320;
			shpPayUpPM[15].Visible = false;
			shpPayUpPM[14].AllowDrop = true;
			shpPayUpPM[14].Enabled = false;
			shpPayUpPM[14].Name = "_shpPayUpPM_14";
			shpPayUpPM[14].TabIndex = 321;
			shpPayUpPM[14].Visible = false;
			shpPayUpPM[13].AllowDrop = true;
			shpPayUpPM[13].Enabled = false;
			shpPayUpPM[13].Name = "_shpPayUpPM_13";
			shpPayUpPM[13].TabIndex = 322;
			shpPayUpPM[13].Visible = false;
			shpPayUpPM[12].AllowDrop = true;
			shpPayUpPM[12].Enabled = false;
			shpPayUpPM[12].Name = "_shpPayUpPM_12";
			shpPayUpPM[12].TabIndex = 323;
			shpPayUpPM[12].Visible = false;
			shpPayUpPM[11].AllowDrop = true;
			shpPayUpPM[11].Enabled = false;
			shpPayUpPM[11].Name = "_shpPayUpPM_11";
			shpPayUpPM[11].TabIndex = 324;
			shpPayUpPM[11].Visible = false;
			shpPayUpPM[10].AllowDrop = true;
			shpPayUpPM[10].Enabled = false;
			shpPayUpPM[10].Name = "_shpPayUpPM_10";
			shpPayUpPM[10].TabIndex = 325;
			shpPayUpPM[10].Visible = false;
			shpPayUpPM[9].AllowDrop = true;
			shpPayUpPM[9].Enabled = false;
			shpPayUpPM[9].Name = "_shpPayUpPM_9";
			shpPayUpPM[9].TabIndex = 326;
			shpPayUpPM[9].Visible = false;
			shpPayUpPM[8].AllowDrop = true;
			shpPayUpPM[8].Enabled = false;
			shpPayUpPM[8].Name = "_shpPayUpPM_8";
			shpPayUpPM[8].TabIndex = 327;
			shpPayUpPM[8].Visible = false;
			shpPayUpPM[7].AllowDrop = true;
			shpPayUpPM[7].Enabled = false;
			shpPayUpPM[7].Name = "_shpPayUpPM_7";
			shpPayUpPM[7].TabIndex = 328;
			shpPayUpPM[7].Visible = false;
			shpPayUpPM[6].AllowDrop = true;
			shpPayUpPM[6].Enabled = false;
			shpPayUpPM[6].Name = "_shpPayUpPM_6";
			shpPayUpPM[6].TabIndex = 329;
			shpPayUpPM[6].Visible = false;
			shpPayUpPM[5].AllowDrop = true;
			shpPayUpPM[5].Enabled = false;
			shpPayUpPM[5].Name = "_shpPayUpPM_5";
			shpPayUpPM[5].TabIndex = 330;
			shpPayUpPM[5].Visible = false;
			shpPayUpPM[4].AllowDrop = true;
			shpPayUpPM[4].Enabled = false;
			shpPayUpPM[4].Name = "_shpPayUpPM_4";
			shpPayUpPM[4].TabIndex = 331;
			shpPayUpPM[4].Visible = false;
			shpPayUpPM[3].AllowDrop = true;
			shpPayUpPM[3].Enabled = false;
			shpPayUpPM[3].Name = "_shpPayUpPM_3";
			shpPayUpPM[3].TabIndex = 332;
			shpPayUpPM[3].Visible = false;
			shpPayUpPM[2].AllowDrop = true;
			shpPayUpPM[2].Enabled = false;
			shpPayUpPM[2].Name = "_shpPayUpPM_2";
			shpPayUpPM[2].TabIndex = 333;
			shpPayUpPM[2].Visible = false;
			shpPayUpPM[1].AllowDrop = true;
			shpPayUpPM[1].Enabled = false;
			shpPayUpPM[1].Name = "_shpPayUpPM_1";
			shpPayUpPM[1].TabIndex = 334;
			shpPayUpPM[1].Visible = false;
			shpPayUpPM[0].AllowDrop = true;
			shpPayUpPM[0].Enabled = false;
			shpPayUpPM[0].Name = "_shpPayUpPM_0";
			shpPayUpPM[0].TabIndex = 378;
			shpPayUpPM[0].Visible = false;
			this.FirstTime = false;
			this.SelectedLabel = null;
			this.SelectedSAName = "";
			this.SelectedSA = "";
			this.SARow = 0;
			this.ClickedLeave = false;
			boxUnit = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(14);
			boxUnit[12] = _boxUnit_12;
			boxUnit[1] = _boxUnit_1;
			boxUnit[2] = _boxUnit_2;
			boxUnit[13] = _boxUnit_13;
			boxUnit[11] = _boxUnit_11;
			boxUnit[10] = _boxUnit_10;
			boxUnit[9] = _boxUnit_9;
			boxUnit[8] = _boxUnit_8;
			boxUnit[7] = _boxUnit_7;
			boxUnit[6] = _boxUnit_6;
			boxUnit[5] = _boxUnit_5;
			boxUnit[4] = _boxUnit_4;
			boxUnit[3] = _boxUnit_3;
			boxUnit[0] = _boxUnit_0;
			boxUnit[12].AllowDrop = true;
			boxUnit[12].Enabled = false;
			boxUnit[12].Name = "_boxUnit_12";
			boxUnit[12].TabIndex = 270;
			boxUnit[1].AllowDrop = true;
			boxUnit[1].Enabled = false;
			boxUnit[1].Name = "_boxUnit_1";
			boxUnit[1].TabIndex = 380;
			boxUnit[2].AllowDrop = true;
			boxUnit[2].Enabled = false;
			boxUnit[2].Name = "_boxUnit_2";
			boxUnit[2].TabIndex = 381;
			boxUnit[13].AllowDrop = true;
			boxUnit[13].Enabled = false;
			boxUnit[13].Name = "_boxUnit_13";
			boxUnit[13].TabIndex = 382;
			boxUnit[11].AllowDrop = true;
			boxUnit[11].Enabled = false;
			boxUnit[11].Name = "_boxUnit_11";
			boxUnit[11].TabIndex = 383;
			boxUnit[10].AllowDrop = true;
			boxUnit[10].Enabled = false;
			boxUnit[10].Name = "_boxUnit_10";
			boxUnit[10].TabIndex = 384;
			boxUnit[9].AllowDrop = true;
			boxUnit[9].Enabled = false;
			boxUnit[9].Name = "_boxUnit_9";
			boxUnit[9].TabIndex = 385;
			boxUnit[8].AllowDrop = true;
			boxUnit[8].Enabled = false;
			boxUnit[8].Name = "_boxUnit_8";
			boxUnit[8].TabIndex = 386;
			boxUnit[7].AllowDrop = true;
			boxUnit[7].Enabled = false;
			boxUnit[7].Name = "_boxUnit_7";
			boxUnit[7].TabIndex = 387;
			boxUnit[6].AllowDrop = true;
			boxUnit[6].Enabled = false;
			boxUnit[6].Name = "_boxUnit_6";
			boxUnit[6].TabIndex = 388;
			boxUnit[5].AllowDrop = true;
			boxUnit[5].Enabled = false;
			boxUnit[5].Name = "_boxUnit_5";
			boxUnit[5].TabIndex = 389;
			boxUnit[4].AllowDrop = true;
			boxUnit[4].Enabled = false;
			boxUnit[4].Name = "_boxUnit_4";
			boxUnit[4].TabIndex = 390;
			boxUnit[3].AllowDrop = true;
			boxUnit[3].Enabled = false;
			boxUnit[3].Name = "_boxUnit_3";
			boxUnit[3].TabIndex = 391;
			boxUnit[0].AllowDrop = true;
			boxUnit[0].Enabled = false;
			boxUnit[0].Name = "_boxUnit_0";
			boxUnit[0].TabIndex = 392;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636251767849401185", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text332636251767849420713", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static720636251767849430477");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx973636251767849459769");
			namedStyle4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1013636251767849469533");
			namedStyle5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle5.CellType = textCellType3;
			namedStyle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1051636251767849469533");
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1151636251767849489061");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle7.CellType = textCellType4;
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1256636251767849498825");
			namedStyle8.CellType = textCellType5;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType5;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1350636251767849518353");
			namedStyle9.CellType = textCellType6;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType6;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmNewBattSched2";
			IsMdiChild = true;
			this.sprLeave.NamedStyles.Add(namedStyle1);
			this.sprLeave.NamedStyles.Add(namedStyle2);
			this.sprLeave.NamedStyles.Add(namedStyle3);
			this.sprLeave.NamedStyles.Add(namedStyle4);
			this.sprLeave.NamedStyles.Add(namedStyle5);
			this.sprLeave.NamedStyles.Add(namedStyle6);
			this.sprLeave.NamedStyles.Add(namedStyle7);
			this.sprLeave.NamedStyles.Add(namedStyle8);
			this.sprLeave.NamedStyles.Add(namedStyle9);
			this.sprLeave.Sheets.Add(this.sprLeave_Sheet1);
		}
		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calSchedDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuException { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintDailyLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintAll { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAssignment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuFRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDebitReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuProlist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSenior { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_emp_facility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuAuditDDHOL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndivPayrollSO { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPersonnelReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBDWork { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHazPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMarPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDisPay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndYearSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuOvertime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuExtraOff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sa_report { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCalendar { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuCBStaffing { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_LeaveNoSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuInsteadOfSCKLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_staffdiscrepancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMCSRCalc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_SchedNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PPEQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Battalion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_timecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuindannualpayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupersonnelsignoff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupayrollreports { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayUp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayDown { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuKOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRover { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDebit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCancelTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTradeDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_viewtimecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSADetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReschedSA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu182PopUp { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picTrash { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDebit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRovers { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDrillGroup_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTo183 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_48 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_48 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel boxFCC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_46 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_44 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_45 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_46 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_44 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_45 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_47 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_47 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_49 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_49 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_50 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_50 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_50 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_50 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_53 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_53 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_52 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_51 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_51 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDebitGroup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTo181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_43 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_42 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_41 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_40 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_39 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_38 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_37 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_36 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_35 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_34 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_33 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_32 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_31 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_30 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_29 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_28 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_27 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_26 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_25 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_24 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_23 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_22 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_21 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_20 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_19 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_18 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_17 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_16 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_15 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_14 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_13 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_12 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_10 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_9 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_43 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_42 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_41 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_40 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_39 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_38 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_37 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_36 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_35 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_34 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_33 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_32 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_31 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_30 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_29 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_28 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_27 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_26 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_25 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_24 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_23 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_22 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_21 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_20 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_19 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_18 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_17 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_16 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_15 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_14 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_13 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_12 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_10 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_9 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel pnSelected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbShift { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_13 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_10 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_9 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_50 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_50 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPeriodClosed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocked { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripViewModel Ctx_mnu182PopUp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeave_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdToday { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdListGray { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdBatt3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAvailToWork { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPayRoll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMissing { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSignOff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdBatt1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MinUnitPos { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MaxUnitPos { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean SignOffAuthority { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PayPeriodClosed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPayPeriod { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrSignOff { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SaveSecurity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 RovNoClick { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DebNoClick { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbUnit { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbDrillGroup { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPosam { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpPayUpAM { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPositionPM { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPospm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpPayUpPM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.Helpers.ControlViewModel SelectedLabel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSAName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSA { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SARow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean ClickedLeave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> boxUnit { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}