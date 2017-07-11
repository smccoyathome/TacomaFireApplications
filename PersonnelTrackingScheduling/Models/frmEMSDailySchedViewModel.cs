using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmEMSDailySched))]
	public class frmEMSDailySchedViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.mnuPrintPayPeriodReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPrintPayPeriodReport.Text = "&Print Pay Periord Report";
			this.mnuClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuClose.Text = "Close Paramedic Daily Scheduler";
			this.mnuSystem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSystem.Text = "System";
			this.mnuEmpInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEmpInfo.Text = "&Update Employee Information";
			this.mnuSeniorityInq = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSeniorityInq.Text = "&Seniority Ranking Inquiry";
			this.mnuImmune = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuImmune.Text = "Manage Employee Immunizations";
			this.mnu_transfer_req = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_transfer_req.Text = "Manage Requests For Transfer";
			this.mnuPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPPE.Text = "&Manage WDL and PPE Info";
			this.mnupersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupersonnel.Text = "Personnel";
			this.mnuIndSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndSchedule.Text = "&Individual Scheduler ";
			this.mnuBattalion1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion1.Text = "Battalion &1 Scheduler ";
			this.mnuBattalion2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion2.Text = "Battalion &2 Scheduler ";
			this.mnuNewBatt3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewBatt3.Text = "Battalion &3 Scheduler";
			this.mnuBattalion3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion3.Text = "Battalion &4 Scheduler ";
			this.mnuBattalion4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattalion4.Text = "Battalion &5 Scheduler";
			this.mnuEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMS.Text = "&EMS Weekly Scheduler ";
			this.mnuHazmat = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHazmat.Text = "&HazMat Scheduler ";
			this.mnuMarine = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuMarine.Text = "&Marine Scheduler ";
			this.mnuBattStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattStaff.Text = "&Battalion Staff Scheduler ";
			this.mnuDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDispatch.Text = "&Dispatch Scheduler ";
			this.mnu_watch_duty = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_watch_duty.Text = "Assign Watch Duty";
			this.mnu_Vacation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_Vacation.Text = "Vacation Scheduler ";
			this.mnu_PMVacationSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMVacationSched.Text = "Paramedic Vacation Scheduler";
			this.mnuSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSchedule.Text = "Scheduling";
			this.mnuAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAssign.Text = "&Assignments ";
			this.mnuRoster = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuRoster.Text = "&Roster ";
			this.mnu_DDGroups = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_DDGroups.Text = "&Debit Day Groups ";
			this.mnuProlist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuProlist.Text = "&Promotion Lists ";
			this.mnuSenior = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSenior.Text = "&Seniority Ranking Lists ";
			this.mnuBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBenefit.Text = "CF&1 Benefit Listing ";
			this.mnu_emp_facility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_emp_facility.Text = "Employee List by Facility";
			this.mnu_IndivPayrollSO = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndivPayrollSO.Text = "Individual Payroll SignOff ";
			this.mnuIndTimeCard2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndTimeCard2.Text = "Individual Time Cards";
			this.mnuperson = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuperson.Text = "&Personnel ";
			this.mnu181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu181.Text = "Battalion &1 ";
			this.mnu182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu182.Text = "Battalion &2 ";
			this.mnu183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu183.Text = "Battalion &3";
			this.mnuBDWork = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBDWork.Text = "&Battalion Time Card Worksheets ";
			this.mnuEMSPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMSPay.Text = "&EMS ";
			this.mnuHazPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHazPay.Text = "&HazMat ";
			this.mnuMarPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuMarPay.Text = "&Marine ";
			this.mnuBattPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuBattPay.Text = "&Battalion Staff ";
			this.mnuDisPay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDisPay.Text = "&Dispatch ";
			this.mnupayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupayroll.Text = "&Payroll Worksheets ";
			this.mnuIndTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndTimeCard.Text = "&Individual Time Cards ";
			this.mnuIndYearSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndYearSched.Text = "Individual &Yearly Schedule ";
			this.mnuDailyStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDailyStaff.Text = "&Daily Staffing Report ";
			this.mnuOvertime = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuOvertime.Text = "&Overtime Detail Report ";
			this.mnu_sa_report = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_sa_report.Text = "Special Assignment Yearly Report";
			this.mnuShiftCal = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuShiftCal.Text = "&Shift Calendar ";
			this.mnuTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTransfer.Text = "&Transfer Schedule ";
			this.mnuSchedul = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSchedul.Text = "&Schedule ";
			this.mnuDailyLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDailyLeave.Text = "&Daily Leave ";
			this.mnuAnnual = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAnnual.Text = "&Annual Leave ";
			this.mnu_dailysickleave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_dailysickleave.Text = "Daily Sick Leave ";
			this.mnuIndLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuIndLeave.Text = "&Individual Leave ";
			this.mnu_PMLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMLeave.Text = "Paramedic Leave Report ";
			this.mnuDispatchLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuDispatchLeave.Text = "Dispatch Leave Report";
			this.mnuLeaveReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuLeaveReports.Text = "&Leave ";
			this.mnutimecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnutimecard.Text = "Individual Time Cards";
			this.mnuindannualpayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuindannualpayroll.Text = "Individual Payroll Report";
			this.mnupersonnelsignoff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupersonnelsignoff.Text = "Payroll Sign Off";
			this.mnupayrollreports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnupayrollreports.Text = "Payroll";
			this.mnu_QuarterlyMinimumDrill = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_QuarterlyMinimumDrill.Text = "Quarterly Minimum Standards Drills";
			this.mnu_ReadingAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_ReadingAssign.Text = "Required Reading Assignments";
			this.mnu_OTEPReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_OTEPReport.Text = "Annual OTEP Training Report";
			this.mnu_PMRecertReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_PMRecertReport.Text = "Paramedic Recertification Report";
			this.mnu_TrainingReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_TrainingReports.Text = "Training";
			this.mnuReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuReports.Text = "Reports";
			this.mnu_trainingtracker = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_trainingtracker.Text = "Field Training Tracker ";
			this.mnu_IndTrainReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndTrainReport.Text = "Individual Training Report";
			this.mnu_IndPMRecert = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndPMRecert.Text = "Individual PM Recert Report";
			this.MnuTrnReports = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.MnuTrnReports.Text = "Training Reports";
			this.mnuTrainQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrainQuery.Text = "&Training Class Attendance Query ";
			this.mnu_TrainingQuerynew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_TrainingQuerynew.Text = "Training Query Tool (new)";
			this.mnu_Queries = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_Queries.Text = "Training Class Queries";
			this.mnuTraining = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTraining.Text = "Training";
			this.mnuCascade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuCascade.Text = "&Cascade Windows ";
			this.mnuPrintScreen = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPrintScreen.Text = "Print Screen";
			this.mnuWindow = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuWindow.Text = "Window";
			this.mnuContents = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			// 
			// mnuContents
			// 
			this.mnuContents.Enabled = false;
			this.mnuContents.Text = "Contents";
			this.mnuAbout = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuAbout.Text = "&About PTS ";
			this.mnu_timecodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_timecodes.Text = "Payroll Time Card codes ";
			this.mnu_payrolllegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_payrolllegend.Text = "Payroll Timecard Legend ";
			this.mnu_legend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_legend.Text = "Battalion Scheduler Legend ";
			this.mnu_IndLegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_IndLegend.Text = "Individual Scheduler Legend ";
			this.mnu_payup_calc = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_payup_calc.Text = "Employee Pay Up/Step Calculator ";
			this.mnuTrainCodeHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrainCodeHelp.Text = "New Training Codes";
			this.mnuHelp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuHelp.Text = "Help";
			this.mnuNewSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuNewSched.Text = "Schedule Employee ";
			this.mnuLeave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuLeave.Text = "Schedule Leave ";
			this.mnuPayUp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPayUp.Text = "Upgrade Pay ";
			this.mnuPayDown = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuPayDown.Text = "Remove Pay Upgrade ";
			this.mnuKOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuKOT.Text = "Change KOT ";
			this.mnuTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuTrade.Text = "Enact a Trade ";
			this.mnuRemove = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuRemove.Text = "Remove from Schedule ";
			this.mnuSendTo181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSendTo181.Text = "Send to Battalion 1 ";
			this.mnuSendTo182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSendTo182.Text = "Send to Battalion 2 ";
			this.mnuSendTo183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuSendTo183.Text = "Send to Battalion 3";
			this.mnu_viewtimecard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnu_viewtimecard.Text = "View Time Card ";
			this.mnuReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuReport.Text = "View This Individual Leave Report ";
			this.mnuViewDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuViewDetail.Text = "View Schedule Detail ";
			this.mnuEMSPopup = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel>();
			this.mnuEMSPopup.Text = "Update Schedule Info ";
			this.sprLeave = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprLeave.AllowDrop = true;
			this.sprLeave.CellNoteIndicator = true;
			this.sprLeave.MaxRows = 25;
			this.sprLeave.TabIndex = 0;
			this.sprLeave.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboSelectName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSelectName
			// 
			this.cboSelectName.AllowDrop = true;
			this.cboSelectName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSelectName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSelectName.Name = "cboSelectName";
			this.cboSelectName.TabIndex = 166;
			this.cboSelectName.Text = "cboSelectName";
			this.picTrash = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picTrash
			// 
			this.picTrash.AllowDrop = true;
			this.picTrash.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.picTrash.Name = "picTrash";
			this.calSchedDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			// 
			// calSchedDate
			// 
			this.calSchedDate.AllowDrop = true;
			this.calSchedDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calSchedDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calSchedDate.Name = "calSchedDate";
			this.calSchedDate.TabIndex = 3;
			this._shpPayUpPM_39 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_38 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_37 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_36 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_39 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_38 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_37 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_36 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 167;
			this.Label5.Text = "Paramedic List";
			this.pnSelected = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// pnSelected
			// 
			this.pnSelected.AllowDrop = true;
			this.pnSelected.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.pnSelected.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.pnSelected.Name = "pnSelected";
			this.pnSelected.TabIndex = 162;
			this.pnSelected.Visible = false;
			this.lbLocked = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocked
			// 
			this.lbLocked.AllowDrop = true;
			this.lbLocked.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocked.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocked.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbLocked.Name = "lbLocked";
			this.lbLocked.TabIndex = 161;
			this.lbLocked.Text = "Schedule Locked";
			this.lbLocked.Visible = false;
			this.lbPeriodClosed = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPeriodClosed
			// 
			this.lbPeriodClosed.AllowDrop = true;
			this.lbPeriodClosed.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPeriodClosed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPeriodClosed.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbPeriodClosed.Name = "lbPeriodClosed";
			this.lbPeriodClosed.TabIndex = 160;
			this.lbPeriodClosed.Text = "PayPeriod Closed";
			this.lbPeriodClosed.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 159;
			this.Label1.Text = "Select Date";
			this._lbUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbUnit_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPositionPM_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPositionPM_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._boxUnit_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.lbShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbShift
			// 
			this.lbShift.AllowDrop = true;
			this.lbShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbShift.Name = "lbShift";
			this.lbShift.TabIndex = 5;
			this.lbShift.Text = "A";
			this._shpPayUpAM_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_0 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_10 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_11 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_12 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_13 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_14 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_15 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_16 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_17 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_18 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_19 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_20 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_21 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_22 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_23 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_24 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_25 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_26 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_27 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_28 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_29 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_30 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_31 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_32 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_33 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_34 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpAM_35 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_7 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_8 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_9 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_10 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_11 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_12 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_13 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_14 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_15 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_16 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_17 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_18 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_19 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_20 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_21 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_22 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_23 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_24 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_25 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_26 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_27 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_28 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_29 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_30 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_31 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_32 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_33 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_34 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._shpPayUpPM_35 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 4;
			this.Label4.Text = "On Leave";
			this._lbPosam_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._boxUnit_6 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this._lbPosam_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosam_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPospm_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Ctx_mnuEMSPopup = ctx.Resolve<UpgradeHelpers.BasicViewModels.ToolStripViewModel>();
			// 
			// Ctx_mnuEMSPopup
			// 
			this.Ctx_mnuEMSPopup.Name = "Ctx_mnuEMSPopup";
			this.sprLeave_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeave_Sheet1.SheetName = "Sheet1";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 1].Value = "AM";
			this.sprLeave_Sheet1.ColumnHeader.Cells[0, 2].Value = "PM";
			this.sprLeave_Sheet1.Columns.Get(0).Label = "Employee";
			this.sprLeave_Sheet1.Columns.Get(0).Width = 168F;
			this.sprLeave_Sheet1.Columns.Get(1).Label = "AM";
			this.sprLeave_Sheet1.Columns.Get(1).Width = 39F;
			this.sprLeave_Sheet1.Columns.Get(2).Label = "PM";
			this.sprLeave_Sheet1.Columns.Get(2).Width = 34F;
			this.sprLeave_Sheet1.Columns.Get(3).Visible = false;
			this.sprLeave_Sheet1.Columns.Get(3).Width = 0F;
			this.sprLeave_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReport
			// 
			this.cmdReport.AllowDrop = true;
			this.cmdReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReport.Name = "cmdReport";
			this.cmdReport.TabIndex = 165;
			this.cmdReport.Text = "&Pay Period Rpt";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.AllowDrop = true;
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 164;
			this.cmdClose.Text = "&Close";
			this.cmdPayroll = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPayroll
			// 
			this.cmdPayroll.AllowDrop = true;
			this.cmdPayroll.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPayroll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPayroll.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPayroll.Name = "cmdPayroll";
			this.cmdPayroll.TabIndex = 163;
			this.cmdPayroll.Text = "Payroll";
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.AllowDrop = true;
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 1;
			this.cmdRefresh.Text = "&Refresh";
			this.Text = "Paramedic Daily Scheduler";
			lbPosam = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(40);
			lbPosam[0] = _lbPosam_0;
			lbPosam[1] = _lbPosam_1;
			lbPosam[2] = _lbPosam_2;
			lbPosam[3] = _lbPosam_3;
			lbPosam[20] = _lbPosam_20;
			lbPosam[21] = _lbPosam_21;
			lbPosam[22] = _lbPosam_22;
			lbPosam[23] = _lbPosam_23;
			lbPosam[4] = _lbPosam_4;
			lbPosam[5] = _lbPosam_5;
			lbPosam[6] = _lbPosam_6;
			lbPosam[7] = _lbPosam_7;
			lbPosam[8] = _lbPosam_8;
			lbPosam[9] = _lbPosam_9;
			lbPosam[10] = _lbPosam_10;
			lbPosam[11] = _lbPosam_11;
			lbPosam[24] = _lbPosam_24;
			lbPosam[25] = _lbPosam_25;
			lbPosam[26] = _lbPosam_26;
			lbPosam[27] = _lbPosam_27;
			lbPosam[28] = _lbPosam_28;
			lbPosam[29] = _lbPosam_29;
			lbPosam[30] = _lbPosam_30;
			lbPosam[31] = _lbPosam_31;
			lbPosam[12] = _lbPosam_12;
			lbPosam[13] = _lbPosam_13;
			lbPosam[14] = _lbPosam_14;
			lbPosam[15] = _lbPosam_15;
			lbPosam[16] = _lbPosam_16;
			lbPosam[17] = _lbPosam_17;
			lbPosam[18] = _lbPosam_18;
			lbPosam[19] = _lbPosam_19;
			lbPosam[32] = _lbPosam_32;
			lbPosam[33] = _lbPosam_33;
			lbPosam[34] = _lbPosam_34;
			lbPosam[35] = _lbPosam_35;
			lbPosam[36] = _lbPosam_36;
			lbPosam[37] = _lbPosam_37;
			lbPosam[38] = _lbPosam_38;
			lbPosam[39] = _lbPosam_39;
			lbPosam[0].AllowDrop = true;
			lbPosam[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[0].Name = "_lbPosam_0";
			lbPosam[0].TabIndex = 131;
			lbPosam[1].AllowDrop = true;
			lbPosam[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[1].Name = "_lbPosam_1";
			lbPosam[1].TabIndex = 115;
			lbPosam[1].Text = " ";
			lbPosam[2].AllowDrop = true;
			lbPosam[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[2].Name = "_lbPosam_2";
			lbPosam[2].TabIndex = 114;
			lbPosam[2].Text = " ";
			lbPosam[3].AllowDrop = true;
			lbPosam[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[3].Name = "_lbPosam_3";
			lbPosam[3].TabIndex = 113;
			lbPosam[3].Text = " ";
			lbPosam[20].AllowDrop = true;
			lbPosam[20].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[20].Name = "_lbPosam_20";
			lbPosam[20].TabIndex = 76;
			lbPosam[20].Text = " ";
			lbPosam[21].AllowDrop = true;
			lbPosam[21].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[21].Name = "_lbPosam_21";
			lbPosam[21].TabIndex = 75;
			lbPosam[21].Text = " ";
			lbPosam[22].AllowDrop = true;
			lbPosam[22].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[22].Name = "_lbPosam_22";
			lbPosam[22].TabIndex = 74;
			lbPosam[22].Text = " ";
			lbPosam[23].AllowDrop = true;
			lbPosam[23].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[23].Name = "_lbPosam_23";
			lbPosam[23].TabIndex = 73;
			lbPosam[23].Text = " ";
			lbPosam[23].Visible = false;
			lbPosam[4].AllowDrop = true;
			lbPosam[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[4].Name = "_lbPosam_4";
			lbPosam[4].TabIndex = 112;
			lbPosam[4].Text = " ";
			lbPosam[5].AllowDrop = true;
			lbPosam[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[5].Name = "_lbPosam_5";
			lbPosam[5].TabIndex = 111;
			lbPosam[5].Text = " ";
			lbPosam[6].AllowDrop = true;
			lbPosam[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[6].Name = "_lbPosam_6";
			lbPosam[6].TabIndex = 110;
			lbPosam[6].Text = " ";
			lbPosam[7].AllowDrop = true;
			lbPosam[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[7].Name = "_lbPosam_7";
			lbPosam[7].TabIndex = 109;
			lbPosam[7].Text = " ";
			lbPosam[8].AllowDrop = true;
			lbPosam[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[8].Name = "_lbPosam_8";
			lbPosam[8].TabIndex = 108;
			lbPosam[8].Text = " ";
			lbPosam[8].Visible = false;
			lbPosam[9].AllowDrop = true;
			lbPosam[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[9].Name = "_lbPosam_9";
			lbPosam[9].TabIndex = 107;
			lbPosam[9].Text = " ";
			lbPosam[9].Visible = false;
			lbPosam[10].AllowDrop = true;
			lbPosam[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[10].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbPosam[10].Name = "_lbPosam_10";
			lbPosam[10].TabIndex = 106;
			lbPosam[10].Text = " ";
			lbPosam[10].Visible = false;
			lbPosam[11].AllowDrop = true;
			lbPosam[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[11].Name = "_lbPosam_11";
			lbPosam[11].TabIndex = 105;
			lbPosam[11].Text = " ";
			lbPosam[11].Visible = false;
			lbPosam[24].AllowDrop = true;
			lbPosam[24].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[24].Name = "_lbPosam_24";
			lbPosam[24].TabIndex = 67;
			lbPosam[24].Text = " ";
			lbPosam[25].AllowDrop = true;
			lbPosam[25].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[25].Name = "_lbPosam_25";
			lbPosam[25].TabIndex = 66;
			lbPosam[25].Text = " ";
			lbPosam[26].AllowDrop = true;
			lbPosam[26].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[26].Name = "_lbPosam_26";
			lbPosam[26].TabIndex = 65;
			lbPosam[26].Text = " ";
			lbPosam[27].AllowDrop = true;
			lbPosam[27].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[27].Name = "_lbPosam_27";
			lbPosam[27].TabIndex = 64;
			lbPosam[27].Text = " ";
			lbPosam[27].Visible = false;
			lbPosam[28].AllowDrop = true;
			lbPosam[28].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[28].Name = "_lbPosam_28";
			lbPosam[28].TabIndex = 58;
			lbPosam[28].Text = " ";
			lbPosam[29].AllowDrop = true;
			lbPosam[29].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[29].Name = "_lbPosam_29";
			lbPosam[29].TabIndex = 57;
			lbPosam[29].Text = " ";
			lbPosam[30].AllowDrop = true;
			lbPosam[30].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[30].Name = "_lbPosam_30";
			lbPosam[30].TabIndex = 56;
			lbPosam[30].Text = " ";
			lbPosam[31].AllowDrop = true;
			lbPosam[31].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[31].Name = "_lbPosam_31";
			lbPosam[31].TabIndex = 55;
			lbPosam[31].Text = " ";
			lbPosam[31].Visible = false;
			lbPosam[12].AllowDrop = true;
			lbPosam[12].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[12].Name = "_lbPosam_12";
			lbPosam[12].TabIndex = 104;
			lbPosam[12].Text = " ";
			lbPosam[13].AllowDrop = true;
			lbPosam[13].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[13].Name = "_lbPosam_13";
			lbPosam[13].TabIndex = 103;
			lbPosam[13].Text = " ";
			lbPosam[14].AllowDrop = true;
			lbPosam[14].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[14].Name = "_lbPosam_14";
			lbPosam[14].TabIndex = 102;
			lbPosam[14].Text = " ";
			lbPosam[15].AllowDrop = true;
			lbPosam[15].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[15].Name = "_lbPosam_15";
			lbPosam[15].TabIndex = 101;
			lbPosam[15].Text = " ";
			lbPosam[16].AllowDrop = true;
			lbPosam[16].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[16].Name = "_lbPosam_16";
			lbPosam[16].TabIndex = 100;
			lbPosam[16].Text = " ";
			lbPosam[17].AllowDrop = true;
			lbPosam[17].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[17].Name = "_lbPosam_17";
			lbPosam[17].TabIndex = 99;
			lbPosam[17].Text = " ";
			lbPosam[18].AllowDrop = true;
			lbPosam[18].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[18].Name = "_lbPosam_18";
			lbPosam[18].TabIndex = 98;
			lbPosam[18].Text = " ";
			lbPosam[19].AllowDrop = true;
			lbPosam[19].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[19].Name = "_lbPosam_19";
			lbPosam[19].TabIndex = 97;
			lbPosam[19].Text = " ";
			lbPosam[19].Visible = false;
			lbPosam[32].AllowDrop = true;
			lbPosam[32].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[32].Name = "_lbPosam_32";
			lbPosam[32].TabIndex = 49;
			lbPosam[32].Text = " ";
			lbPosam[33].AllowDrop = true;
			lbPosam[33].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[33].Name = "_lbPosam_33";
			lbPosam[33].TabIndex = 48;
			lbPosam[33].Text = " ";
			lbPosam[34].AllowDrop = true;
			lbPosam[34].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[34].Name = "_lbPosam_34";
			lbPosam[34].TabIndex = 47;
			lbPosam[34].Text = " ";
			lbPosam[35].AllowDrop = true;
			lbPosam[35].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[35].Name = "_lbPosam_35";
			lbPosam[35].TabIndex = 46;
			lbPosam[35].Text = " ";
			lbPosam[35].Visible = false;
			lbPosam[36].AllowDrop = true;
			lbPosam[36].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[36].Name = "_lbPosam_36";
			lbPosam[36].TabIndex = 177;
			lbPosam[36].Text = " ";
			lbPosam[37].AllowDrop = true;
			lbPosam[37].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[37].Name = "_lbPosam_37";
			lbPosam[37].TabIndex = 178;
			lbPosam[37].Text = " ";
			lbPosam[38].AllowDrop = true;
			lbPosam[38].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbPosam[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[38].Name = "_lbPosam_38";
			lbPosam[38].TabIndex = 179;
			lbPosam[38].Text = " ";
			lbPosam[39].AllowDrop = true;
			lbPosam[39].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPosam[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosam[39].Name = "_lbPosam_39";
			lbPosam[39].TabIndex = 180;
			lbPosam[39].Text = " ";
			lbPosam[39].Visible = false;
			lbPospm = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(40);
			lbPospm[0] = _lbPospm_0;
			lbPospm[1] = _lbPospm_1;
			lbPospm[2] = _lbPospm_2;
			lbPospm[3] = _lbPospm_3;
			lbPospm[20] = _lbPospm_20;
			lbPospm[21] = _lbPospm_21;
			lbPospm[22] = _lbPospm_22;
			lbPospm[23] = _lbPospm_23;
			lbPospm[4] = _lbPospm_4;
			lbPospm[5] = _lbPospm_5;
			lbPospm[6] = _lbPospm_6;
			lbPospm[7] = _lbPospm_7;
			lbPospm[8] = _lbPospm_8;
			lbPospm[9] = _lbPospm_9;
			lbPospm[10] = _lbPospm_10;
			lbPospm[11] = _lbPospm_11;
			lbPospm[24] = _lbPospm_24;
			lbPospm[25] = _lbPospm_25;
			lbPospm[26] = _lbPospm_26;
			lbPospm[27] = _lbPospm_27;
			lbPospm[28] = _lbPospm_28;
			lbPospm[29] = _lbPospm_29;
			lbPospm[30] = _lbPospm_30;
			lbPospm[31] = _lbPospm_31;
			lbPospm[12] = _lbPospm_12;
			lbPospm[13] = _lbPospm_13;
			lbPospm[14] = _lbPospm_14;
			lbPospm[15] = _lbPospm_15;
			lbPospm[16] = _lbPospm_16;
			lbPospm[17] = _lbPospm_17;
			lbPospm[18] = _lbPospm_18;
			lbPospm[19] = _lbPospm_19;
			lbPospm[32] = _lbPospm_32;
			lbPospm[33] = _lbPospm_33;
			lbPospm[34] = _lbPospm_34;
			lbPospm[35] = _lbPospm_35;
			lbPospm[36] = _lbPospm_36;
			lbPospm[37] = _lbPospm_37;
			lbPospm[38] = _lbPospm_38;
			lbPospm[39] = _lbPospm_39;
			lbPospm[0].AllowDrop = true;
			lbPospm[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[0].Name = "_lbPospm_0";
			lbPospm[0].TabIndex = 130;
			lbPospm[0].Text = " ";
			lbPospm[1].AllowDrop = true;
			lbPospm[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[1].Name = "_lbPospm_1";
			lbPospm[1].TabIndex = 96;
			lbPospm[1].Text = " ";
			lbPospm[2].AllowDrop = true;
			lbPospm[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[2].Name = "_lbPospm_2";
			lbPospm[2].TabIndex = 95;
			lbPospm[2].Text = " ";
			lbPospm[3].AllowDrop = true;
			lbPospm[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[3].Name = "_lbPospm_3";
			lbPospm[3].TabIndex = 94;
			lbPospm[3].Text = " ";
			lbPospm[20].AllowDrop = true;
			lbPospm[20].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[20].Name = "_lbPospm_20";
			lbPospm[20].TabIndex = 72;
			lbPospm[20].Text = " ";
			lbPospm[21].AllowDrop = true;
			lbPospm[21].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[21].Name = "_lbPospm_21";
			lbPospm[21].TabIndex = 71;
			lbPospm[21].Text = " ";
			lbPospm[22].AllowDrop = true;
			lbPospm[22].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[22].Name = "_lbPospm_22";
			lbPospm[22].TabIndex = 70;
			lbPospm[22].Text = " ";
			lbPospm[23].AllowDrop = true;
			lbPospm[23].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[23].Name = "_lbPospm_23";
			lbPospm[23].TabIndex = 69;
			lbPospm[23].Text = " ";
			lbPospm[23].Visible = false;
			lbPospm[4].AllowDrop = true;
			lbPospm[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[4].Name = "_lbPospm_4";
			lbPospm[4].TabIndex = 93;
			lbPospm[4].Text = " ";
			lbPospm[5].AllowDrop = true;
			lbPospm[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[5].Name = "_lbPospm_5";
			lbPospm[5].TabIndex = 92;
			lbPospm[5].Text = " ";
			lbPospm[6].AllowDrop = true;
			lbPospm[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[6].Name = "_lbPospm_6";
			lbPospm[6].TabIndex = 91;
			lbPospm[6].Text = " ";
			lbPospm[7].AllowDrop = true;
			lbPospm[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[7].Name = "_lbPospm_7";
			lbPospm[7].TabIndex = 90;
			lbPospm[7].Text = " ";
			lbPospm[8].AllowDrop = true;
			lbPospm[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[8].Name = "_lbPospm_8";
			lbPospm[8].TabIndex = 89;
			lbPospm[8].Text = " ";
			lbPospm[8].Visible = false;
			lbPospm[9].AllowDrop = true;
			lbPospm[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[9].Name = "_lbPospm_9";
			lbPospm[9].TabIndex = 88;
			lbPospm[9].Text = " ";
			lbPospm[9].Visible = false;
			lbPospm[10].AllowDrop = true;
			lbPospm[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[10].Name = "_lbPospm_10";
			lbPospm[10].TabIndex = 87;
			lbPospm[10].Text = " ";
			lbPospm[10].Visible = false;
			lbPospm[11].AllowDrop = true;
			lbPospm[11].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[11].Name = "_lbPospm_11";
			lbPospm[11].TabIndex = 86;
			lbPospm[11].Text = " ";
			lbPospm[11].Visible = false;
			lbPospm[24].AllowDrop = true;
			lbPospm[24].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[24].Name = "_lbPospm_24";
			lbPospm[24].TabIndex = 63;
			lbPospm[24].Text = " ";
			lbPospm[25].AllowDrop = true;
			lbPospm[25].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[25].Name = "_lbPospm_25";
			lbPospm[25].TabIndex = 62;
			lbPospm[25].Text = " ";
			lbPospm[26].AllowDrop = true;
			lbPospm[26].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[26].Name = "_lbPospm_26";
			lbPospm[26].TabIndex = 61;
			lbPospm[26].Text = " ";
			lbPospm[27].AllowDrop = true;
			lbPospm[27].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[27].Name = "_lbPospm_27";
			lbPospm[27].TabIndex = 60;
			lbPospm[27].Text = " ";
			lbPospm[27].Visible = false;
			lbPospm[28].AllowDrop = true;
			lbPospm[28].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[28].Name = "_lbPospm_28";
			lbPospm[28].TabIndex = 54;
			lbPospm[28].Text = " ";
			lbPospm[29].AllowDrop = true;
			lbPospm[29].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[29].Name = "_lbPospm_29";
			lbPospm[29].TabIndex = 53;
			lbPospm[29].Text = " ";
			lbPospm[30].AllowDrop = true;
			lbPospm[30].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[30].Name = "_lbPospm_30";
			lbPospm[30].TabIndex = 52;
			lbPospm[30].Text = " ";
			lbPospm[31].AllowDrop = true;
			lbPospm[31].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[31].Name = "_lbPospm_31";
			lbPospm[31].TabIndex = 51;
			lbPospm[31].Text = " ";
			lbPospm[31].Visible = false;
			lbPospm[12].AllowDrop = true;
			lbPospm[12].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[12].Name = "_lbPospm_12";
			lbPospm[12].TabIndex = 85;
			lbPospm[12].Text = " ";
			lbPospm[13].AllowDrop = true;
			lbPospm[13].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[13].Name = "_lbPospm_13";
			lbPospm[13].TabIndex = 84;
			lbPospm[13].Text = " ";
			lbPospm[14].AllowDrop = true;
			lbPospm[14].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[14].Name = "_lbPospm_14";
			lbPospm[14].TabIndex = 83;
			lbPospm[14].Text = " ";
			lbPospm[15].AllowDrop = true;
			lbPospm[15].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[15].Name = "_lbPospm_15";
			lbPospm[15].TabIndex = 82;
			lbPospm[15].Text = " ";
			lbPospm[16].AllowDrop = true;
			lbPospm[16].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[16].Name = "_lbPospm_16";
			lbPospm[16].TabIndex = 81;
			lbPospm[16].Text = " ";
			lbPospm[17].AllowDrop = true;
			lbPospm[17].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[17].Name = "_lbPospm_17";
			lbPospm[17].TabIndex = 80;
			lbPospm[17].Text = " ";
			lbPospm[18].AllowDrop = true;
			lbPospm[18].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[18].Name = "_lbPospm_18";
			lbPospm[18].TabIndex = 79;
			lbPospm[18].Text = " ";
			lbPospm[19].AllowDrop = true;
			lbPospm[19].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[19].Name = "_lbPospm_19";
			lbPospm[19].TabIndex = 78;
			lbPospm[19].Text = " ";
			lbPospm[19].Visible = false;
			lbPospm[32].AllowDrop = true;
			lbPospm[32].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[32].Name = "_lbPospm_32";
			lbPospm[32].TabIndex = 45;
			lbPospm[32].Text = " ";
			lbPospm[33].AllowDrop = true;
			lbPospm[33].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[33].Name = "_lbPospm_33";
			lbPospm[33].TabIndex = 44;
			lbPospm[33].Text = " ";
			lbPospm[34].AllowDrop = true;
			lbPospm[34].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[34].Name = "_lbPospm_34";
			lbPospm[34].TabIndex = 43;
			lbPospm[34].Text = " ";
			lbPospm[35].AllowDrop = true;
			lbPospm[35].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[35].Name = "_lbPospm_35";
			lbPospm[35].TabIndex = 42;
			lbPospm[35].Text = " ";
			lbPospm[35].Visible = false;
			lbPospm[36].AllowDrop = true;
			lbPospm[36].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[36].Name = "_lbPospm_36";
			lbPospm[36].TabIndex = 181;
			lbPospm[36].Text = " ";
			lbPospm[37].AllowDrop = true;
			lbPospm[37].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[37].Name = "_lbPospm_37";
			lbPospm[37].TabIndex = 182;
			lbPospm[37].Text = " ";
			lbPospm[38].AllowDrop = true;
			lbPospm[38].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbPospm[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[38].Name = "_lbPospm_38";
			lbPospm[38].TabIndex = 183;
			lbPospm[38].Text = " ";
			lbPospm[39].AllowDrop = true;
			lbPospm[39].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			lbPospm[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPospm[39].Name = "_lbPospm_39";
			lbPospm[39].TabIndex = 184;
			lbPospm[39].Text = " ";
			lbPospm[39].Visible = false;
			shpPayUpAM = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(40);
			shpPayUpAM[39] = _shpPayUpAM_39;
			shpPayUpAM[38] = _shpPayUpAM_38;
			shpPayUpAM[37] = _shpPayUpAM_37;
			shpPayUpAM[36] = _shpPayUpAM_36;
			shpPayUpAM[0] = _shpPayUpAM_0;
			shpPayUpAM[1] = _shpPayUpAM_1;
			shpPayUpAM[2] = _shpPayUpAM_2;
			shpPayUpAM[3] = _shpPayUpAM_3;
			shpPayUpAM[4] = _shpPayUpAM_4;
			shpPayUpAM[5] = _shpPayUpAM_5;
			shpPayUpAM[6] = _shpPayUpAM_6;
			shpPayUpAM[7] = _shpPayUpAM_7;
			shpPayUpAM[8] = _shpPayUpAM_8;
			shpPayUpAM[9] = _shpPayUpAM_9;
			shpPayUpAM[10] = _shpPayUpAM_10;
			shpPayUpAM[11] = _shpPayUpAM_11;
			shpPayUpAM[12] = _shpPayUpAM_12;
			shpPayUpAM[13] = _shpPayUpAM_13;
			shpPayUpAM[14] = _shpPayUpAM_14;
			shpPayUpAM[15] = _shpPayUpAM_15;
			shpPayUpAM[16] = _shpPayUpAM_16;
			shpPayUpAM[17] = _shpPayUpAM_17;
			shpPayUpAM[18] = _shpPayUpAM_18;
			shpPayUpAM[19] = _shpPayUpAM_19;
			shpPayUpAM[20] = _shpPayUpAM_20;
			shpPayUpAM[21] = _shpPayUpAM_21;
			shpPayUpAM[22] = _shpPayUpAM_22;
			shpPayUpAM[23] = _shpPayUpAM_23;
			shpPayUpAM[24] = _shpPayUpAM_24;
			shpPayUpAM[25] = _shpPayUpAM_25;
			shpPayUpAM[26] = _shpPayUpAM_26;
			shpPayUpAM[27] = _shpPayUpAM_27;
			shpPayUpAM[28] = _shpPayUpAM_28;
			shpPayUpAM[29] = _shpPayUpAM_29;
			shpPayUpAM[30] = _shpPayUpAM_30;
			shpPayUpAM[31] = _shpPayUpAM_31;
			shpPayUpAM[32] = _shpPayUpAM_32;
			shpPayUpAM[33] = _shpPayUpAM_33;
			shpPayUpAM[34] = _shpPayUpAM_34;
			shpPayUpAM[35] = _shpPayUpAM_35;
			shpPayUpAM[39].AllowDrop = true;
			shpPayUpAM[39].Enabled = false;
			shpPayUpAM[39].Name = "_shpPayUpAM_39";
			shpPayUpAM[39].TabIndex = 171;
			shpPayUpAM[39].Visible = false;
			shpPayUpAM[38].AllowDrop = true;
			shpPayUpAM[38].Enabled = false;
			shpPayUpAM[38].Name = "_shpPayUpAM_38";
			shpPayUpAM[38].TabIndex = 172;
			shpPayUpAM[38].Visible = false;
			shpPayUpAM[37].AllowDrop = true;
			shpPayUpAM[37].Enabled = false;
			shpPayUpAM[37].Name = "_shpPayUpAM_37";
			shpPayUpAM[37].TabIndex = 173;
			shpPayUpAM[37].Visible = false;
			shpPayUpAM[36].AllowDrop = true;
			shpPayUpAM[36].Enabled = false;
			shpPayUpAM[36].Name = "_shpPayUpAM_36";
			shpPayUpAM[36].TabIndex = 174;
			shpPayUpAM[36].Visible = false;
			shpPayUpAM[0].AllowDrop = true;
			shpPayUpAM[0].Enabled = false;
			shpPayUpAM[0].Name = "_shpPayUpAM_0";
			shpPayUpAM[0].TabIndex = 186;
			shpPayUpAM[0].Visible = false;
			shpPayUpAM[1].AllowDrop = true;
			shpPayUpAM[1].Enabled = false;
			shpPayUpAM[1].Name = "_shpPayUpAM_1";
			shpPayUpAM[1].TabIndex = 188;
			shpPayUpAM[1].Visible = false;
			shpPayUpAM[2].AllowDrop = true;
			shpPayUpAM[2].Enabled = false;
			shpPayUpAM[2].Name = "_shpPayUpAM_2";
			shpPayUpAM[2].TabIndex = 189;
			shpPayUpAM[2].Visible = false;
			shpPayUpAM[3].AllowDrop = true;
			shpPayUpAM[3].Enabled = false;
			shpPayUpAM[3].Name = "_shpPayUpAM_3";
			shpPayUpAM[3].TabIndex = 190;
			shpPayUpAM[3].Visible = false;
			shpPayUpAM[4].AllowDrop = true;
			shpPayUpAM[4].Enabled = false;
			shpPayUpAM[4].Name = "_shpPayUpAM_4";
			shpPayUpAM[4].TabIndex = 191;
			shpPayUpAM[4].Visible = false;
			shpPayUpAM[5].AllowDrop = true;
			shpPayUpAM[5].Enabled = false;
			shpPayUpAM[5].Name = "_shpPayUpAM_5";
			shpPayUpAM[5].TabIndex = 192;
			shpPayUpAM[5].Visible = false;
			shpPayUpAM[6].AllowDrop = true;
			shpPayUpAM[6].Enabled = false;
			shpPayUpAM[6].Name = "_shpPayUpAM_6";
			shpPayUpAM[6].TabIndex = 193;
			shpPayUpAM[6].Visible = false;
			shpPayUpAM[7].AllowDrop = true;
			shpPayUpAM[7].Enabled = false;
			shpPayUpAM[7].Name = "_shpPayUpAM_7";
			shpPayUpAM[7].TabIndex = 194;
			shpPayUpAM[7].Visible = false;
			shpPayUpAM[8].AllowDrop = true;
			shpPayUpAM[8].Enabled = false;
			shpPayUpAM[8].Name = "_shpPayUpAM_8";
			shpPayUpAM[8].TabIndex = 195;
			shpPayUpAM[8].Visible = false;
			shpPayUpAM[9].AllowDrop = true;
			shpPayUpAM[9].Enabled = false;
			shpPayUpAM[9].Name = "_shpPayUpAM_9";
			shpPayUpAM[9].TabIndex = 196;
			shpPayUpAM[9].Visible = false;
			shpPayUpAM[10].AllowDrop = true;
			shpPayUpAM[10].Enabled = false;
			shpPayUpAM[10].Name = "_shpPayUpAM_10";
			shpPayUpAM[10].TabIndex = 197;
			shpPayUpAM[10].Visible = false;
			shpPayUpAM[11].AllowDrop = true;
			shpPayUpAM[11].Enabled = false;
			shpPayUpAM[11].Name = "_shpPayUpAM_11";
			shpPayUpAM[11].TabIndex = 198;
			shpPayUpAM[11].Visible = false;
			shpPayUpAM[12].AllowDrop = true;
			shpPayUpAM[12].Enabled = false;
			shpPayUpAM[12].Name = "_shpPayUpAM_12";
			shpPayUpAM[12].TabIndex = 199;
			shpPayUpAM[12].Visible = false;
			shpPayUpAM[13].AllowDrop = true;
			shpPayUpAM[13].Enabled = false;
			shpPayUpAM[13].Name = "_shpPayUpAM_13";
			shpPayUpAM[13].TabIndex = 200;
			shpPayUpAM[13].Visible = false;
			shpPayUpAM[14].AllowDrop = true;
			shpPayUpAM[14].Enabled = false;
			shpPayUpAM[14].Name = "_shpPayUpAM_14";
			shpPayUpAM[14].TabIndex = 201;
			shpPayUpAM[14].Visible = false;
			shpPayUpAM[15].AllowDrop = true;
			shpPayUpAM[15].Enabled = false;
			shpPayUpAM[15].Name = "_shpPayUpAM_15";
			shpPayUpAM[15].TabIndex = 202;
			shpPayUpAM[15].Visible = false;
			shpPayUpAM[16].AllowDrop = true;
			shpPayUpAM[16].Enabled = false;
			shpPayUpAM[16].Name = "_shpPayUpAM_16";
			shpPayUpAM[16].TabIndex = 203;
			shpPayUpAM[16].Visible = false;
			shpPayUpAM[17].AllowDrop = true;
			shpPayUpAM[17].Enabled = false;
			shpPayUpAM[17].Name = "_shpPayUpAM_17";
			shpPayUpAM[17].TabIndex = 204;
			shpPayUpAM[17].Visible = false;
			shpPayUpAM[18].AllowDrop = true;
			shpPayUpAM[18].Enabled = false;
			shpPayUpAM[18].Name = "_shpPayUpAM_18";
			shpPayUpAM[18].TabIndex = 205;
			shpPayUpAM[18].Visible = false;
			shpPayUpAM[19].AllowDrop = true;
			shpPayUpAM[19].Enabled = false;
			shpPayUpAM[19].Name = "_shpPayUpAM_19";
			shpPayUpAM[19].TabIndex = 206;
			shpPayUpAM[19].Visible = false;
			shpPayUpAM[20].AllowDrop = true;
			shpPayUpAM[20].Enabled = false;
			shpPayUpAM[20].Name = "_shpPayUpAM_20";
			shpPayUpAM[20].TabIndex = 207;
			shpPayUpAM[20].Visible = false;
			shpPayUpAM[21].AllowDrop = true;
			shpPayUpAM[21].Enabled = false;
			shpPayUpAM[21].Name = "_shpPayUpAM_21";
			shpPayUpAM[21].TabIndex = 208;
			shpPayUpAM[21].Visible = false;
			shpPayUpAM[22].AllowDrop = true;
			shpPayUpAM[22].Enabled = false;
			shpPayUpAM[22].Name = "_shpPayUpAM_22";
			shpPayUpAM[22].TabIndex = 209;
			shpPayUpAM[22].Visible = false;
			shpPayUpAM[23].AllowDrop = true;
			shpPayUpAM[23].Enabled = false;
			shpPayUpAM[23].Name = "_shpPayUpAM_23";
			shpPayUpAM[23].TabIndex = 210;
			shpPayUpAM[23].Visible = false;
			shpPayUpAM[24].AllowDrop = true;
			shpPayUpAM[24].Enabled = false;
			shpPayUpAM[24].Name = "_shpPayUpAM_24";
			shpPayUpAM[24].TabIndex = 211;
			shpPayUpAM[24].Visible = false;
			shpPayUpAM[25].AllowDrop = true;
			shpPayUpAM[25].Enabled = false;
			shpPayUpAM[25].Name = "_shpPayUpAM_25";
			shpPayUpAM[25].TabIndex = 212;
			shpPayUpAM[25].Visible = false;
			shpPayUpAM[26].AllowDrop = true;
			shpPayUpAM[26].Enabled = false;
			shpPayUpAM[26].Name = "_shpPayUpAM_26";
			shpPayUpAM[26].TabIndex = 213;
			shpPayUpAM[26].Visible = false;
			shpPayUpAM[27].AllowDrop = true;
			shpPayUpAM[27].Enabled = false;
			shpPayUpAM[27].Name = "_shpPayUpAM_27";
			shpPayUpAM[27].TabIndex = 214;
			shpPayUpAM[27].Visible = false;
			shpPayUpAM[28].AllowDrop = true;
			shpPayUpAM[28].Enabled = false;
			shpPayUpAM[28].Name = "_shpPayUpAM_28";
			shpPayUpAM[28].TabIndex = 215;
			shpPayUpAM[28].Visible = false;
			shpPayUpAM[29].AllowDrop = true;
			shpPayUpAM[29].Enabled = false;
			shpPayUpAM[29].Name = "_shpPayUpAM_29";
			shpPayUpAM[29].TabIndex = 216;
			shpPayUpAM[29].Visible = false;
			shpPayUpAM[30].AllowDrop = true;
			shpPayUpAM[30].Enabled = false;
			shpPayUpAM[30].Name = "_shpPayUpAM_30";
			shpPayUpAM[30].TabIndex = 217;
			shpPayUpAM[30].Visible = false;
			shpPayUpAM[31].AllowDrop = true;
			shpPayUpAM[31].Enabled = false;
			shpPayUpAM[31].Name = "_shpPayUpAM_31";
			shpPayUpAM[31].TabIndex = 218;
			shpPayUpAM[31].Visible = false;
			shpPayUpAM[32].AllowDrop = true;
			shpPayUpAM[32].Enabled = false;
			shpPayUpAM[32].Name = "_shpPayUpAM_32";
			shpPayUpAM[32].TabIndex = 219;
			shpPayUpAM[32].Visible = false;
			shpPayUpAM[33].AllowDrop = true;
			shpPayUpAM[33].Enabled = false;
			shpPayUpAM[33].Name = "_shpPayUpAM_33";
			shpPayUpAM[33].TabIndex = 220;
			shpPayUpAM[33].Visible = false;
			shpPayUpAM[34].AllowDrop = true;
			shpPayUpAM[34].Enabled = false;
			shpPayUpAM[34].Name = "_shpPayUpAM_34";
			shpPayUpAM[34].TabIndex = 221;
			shpPayUpAM[34].Visible = false;
			shpPayUpAM[35].AllowDrop = true;
			shpPayUpAM[35].Enabled = false;
			shpPayUpAM[35].Name = "_shpPayUpAM_35";
			shpPayUpAM[35].TabIndex = 222;
			shpPayUpAM[35].Visible = false;
			shpPayUpPM = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(40);
			shpPayUpPM[39] = _shpPayUpPM_39;
			shpPayUpPM[38] = _shpPayUpPM_38;
			shpPayUpPM[37] = _shpPayUpPM_37;
			shpPayUpPM[36] = _shpPayUpPM_36;
			shpPayUpPM[0] = _shpPayUpPM_0;
			shpPayUpPM[1] = _shpPayUpPM_1;
			shpPayUpPM[2] = _shpPayUpPM_2;
			shpPayUpPM[3] = _shpPayUpPM_3;
			shpPayUpPM[4] = _shpPayUpPM_4;
			shpPayUpPM[5] = _shpPayUpPM_5;
			shpPayUpPM[6] = _shpPayUpPM_6;
			shpPayUpPM[7] = _shpPayUpPM_7;
			shpPayUpPM[8] = _shpPayUpPM_8;
			shpPayUpPM[9] = _shpPayUpPM_9;
			shpPayUpPM[10] = _shpPayUpPM_10;
			shpPayUpPM[11] = _shpPayUpPM_11;
			shpPayUpPM[12] = _shpPayUpPM_12;
			shpPayUpPM[13] = _shpPayUpPM_13;
			shpPayUpPM[14] = _shpPayUpPM_14;
			shpPayUpPM[15] = _shpPayUpPM_15;
			shpPayUpPM[16] = _shpPayUpPM_16;
			shpPayUpPM[17] = _shpPayUpPM_17;
			shpPayUpPM[18] = _shpPayUpPM_18;
			shpPayUpPM[19] = _shpPayUpPM_19;
			shpPayUpPM[20] = _shpPayUpPM_20;
			shpPayUpPM[21] = _shpPayUpPM_21;
			shpPayUpPM[22] = _shpPayUpPM_22;
			shpPayUpPM[23] = _shpPayUpPM_23;
			shpPayUpPM[24] = _shpPayUpPM_24;
			shpPayUpPM[25] = _shpPayUpPM_25;
			shpPayUpPM[26] = _shpPayUpPM_26;
			shpPayUpPM[27] = _shpPayUpPM_27;
			shpPayUpPM[28] = _shpPayUpPM_28;
			shpPayUpPM[29] = _shpPayUpPM_29;
			shpPayUpPM[30] = _shpPayUpPM_30;
			shpPayUpPM[31] = _shpPayUpPM_31;
			shpPayUpPM[32] = _shpPayUpPM_32;
			shpPayUpPM[33] = _shpPayUpPM_33;
			shpPayUpPM[34] = _shpPayUpPM_34;
			shpPayUpPM[35] = _shpPayUpPM_35;
			shpPayUpPM[39].AllowDrop = true;
			shpPayUpPM[39].Enabled = false;
			shpPayUpPM[39].Name = "_shpPayUpPM_39";
			shpPayUpPM[39].TabIndex = 167;
			shpPayUpPM[39].Visible = false;
			shpPayUpPM[38].AllowDrop = true;
			shpPayUpPM[38].Enabled = false;
			shpPayUpPM[38].Name = "_shpPayUpPM_38";
			shpPayUpPM[38].TabIndex = 168;
			shpPayUpPM[38].Visible = false;
			shpPayUpPM[37].AllowDrop = true;
			shpPayUpPM[37].Enabled = false;
			shpPayUpPM[37].Name = "_shpPayUpPM_37";
			shpPayUpPM[37].TabIndex = 169;
			shpPayUpPM[37].Visible = false;
			shpPayUpPM[36].AllowDrop = true;
			shpPayUpPM[36].Enabled = false;
			shpPayUpPM[36].Name = "_shpPayUpPM_36";
			shpPayUpPM[36].TabIndex = 170;
			shpPayUpPM[36].Visible = false;
			shpPayUpPM[0].AllowDrop = true;
			shpPayUpPM[0].Enabled = false;
			shpPayUpPM[0].Name = "_shpPayUpPM_0";
			shpPayUpPM[0].TabIndex = 187;
			shpPayUpPM[0].Visible = false;
			shpPayUpPM[1].AllowDrop = true;
			shpPayUpPM[1].Enabled = false;
			shpPayUpPM[1].Name = "_shpPayUpPM_1";
			shpPayUpPM[1].TabIndex = 223;
			shpPayUpPM[1].Visible = false;
			shpPayUpPM[2].AllowDrop = true;
			shpPayUpPM[2].Enabled = false;
			shpPayUpPM[2].Name = "_shpPayUpPM_2";
			shpPayUpPM[2].TabIndex = 224;
			shpPayUpPM[2].Visible = false;
			shpPayUpPM[3].AllowDrop = true;
			shpPayUpPM[3].Enabled = false;
			shpPayUpPM[3].Name = "_shpPayUpPM_3";
			shpPayUpPM[3].TabIndex = 225;
			shpPayUpPM[3].Visible = false;
			shpPayUpPM[4].AllowDrop = true;
			shpPayUpPM[4].Enabled = false;
			shpPayUpPM[4].Name = "_shpPayUpPM_4";
			shpPayUpPM[4].TabIndex = 226;
			shpPayUpPM[4].Visible = false;
			shpPayUpPM[5].AllowDrop = true;
			shpPayUpPM[5].Enabled = false;
			shpPayUpPM[5].Name = "_shpPayUpPM_5";
			shpPayUpPM[5].TabIndex = 227;
			shpPayUpPM[5].Visible = false;
			shpPayUpPM[6].AllowDrop = true;
			shpPayUpPM[6].Enabled = false;
			shpPayUpPM[6].Name = "_shpPayUpPM_6";
			shpPayUpPM[6].TabIndex = 228;
			shpPayUpPM[6].Visible = false;
			shpPayUpPM[7].AllowDrop = true;
			shpPayUpPM[7].Enabled = false;
			shpPayUpPM[7].Name = "_shpPayUpPM_7";
			shpPayUpPM[7].TabIndex = 229;
			shpPayUpPM[7].Visible = false;
			shpPayUpPM[8].AllowDrop = true;
			shpPayUpPM[8].Enabled = false;
			shpPayUpPM[8].Name = "_shpPayUpPM_8";
			shpPayUpPM[8].TabIndex = 230;
			shpPayUpPM[8].Visible = false;
			shpPayUpPM[9].AllowDrop = true;
			shpPayUpPM[9].Enabled = false;
			shpPayUpPM[9].Name = "_shpPayUpPM_9";
			shpPayUpPM[9].TabIndex = 231;
			shpPayUpPM[9].Visible = false;
			shpPayUpPM[10].AllowDrop = true;
			shpPayUpPM[10].Enabled = false;
			shpPayUpPM[10].Name = "_shpPayUpPM_10";
			shpPayUpPM[10].TabIndex = 232;
			shpPayUpPM[10].Visible = false;
			shpPayUpPM[11].AllowDrop = true;
			shpPayUpPM[11].Enabled = false;
			shpPayUpPM[11].Name = "_shpPayUpPM_11";
			shpPayUpPM[11].TabIndex = 233;
			shpPayUpPM[11].Visible = false;
			shpPayUpPM[12].AllowDrop = true;
			shpPayUpPM[12].Enabled = false;
			shpPayUpPM[12].Name = "_shpPayUpPM_12";
			shpPayUpPM[12].TabIndex = 234;
			shpPayUpPM[12].Visible = false;
			shpPayUpPM[13].AllowDrop = true;
			shpPayUpPM[13].Enabled = false;
			shpPayUpPM[13].Name = "_shpPayUpPM_13";
			shpPayUpPM[13].TabIndex = 235;
			shpPayUpPM[13].Visible = false;
			shpPayUpPM[14].AllowDrop = true;
			shpPayUpPM[14].Enabled = false;
			shpPayUpPM[14].Name = "_shpPayUpPM_14";
			shpPayUpPM[14].TabIndex = 236;
			shpPayUpPM[14].Visible = false;
			shpPayUpPM[15].AllowDrop = true;
			shpPayUpPM[15].Enabled = false;
			shpPayUpPM[15].Name = "_shpPayUpPM_15";
			shpPayUpPM[15].TabIndex = 237;
			shpPayUpPM[15].Visible = false;
			shpPayUpPM[16].AllowDrop = true;
			shpPayUpPM[16].Enabled = false;
			shpPayUpPM[16].Name = "_shpPayUpPM_16";
			shpPayUpPM[16].TabIndex = 238;
			shpPayUpPM[16].Visible = false;
			shpPayUpPM[17].AllowDrop = true;
			shpPayUpPM[17].Enabled = false;
			shpPayUpPM[17].Name = "_shpPayUpPM_17";
			shpPayUpPM[17].TabIndex = 239;
			shpPayUpPM[17].Visible = false;
			shpPayUpPM[18].AllowDrop = true;
			shpPayUpPM[18].Enabled = false;
			shpPayUpPM[18].Name = "_shpPayUpPM_18";
			shpPayUpPM[18].TabIndex = 240;
			shpPayUpPM[18].Visible = false;
			shpPayUpPM[19].AllowDrop = true;
			shpPayUpPM[19].Enabled = false;
			shpPayUpPM[19].Name = "_shpPayUpPM_19";
			shpPayUpPM[19].TabIndex = 241;
			shpPayUpPM[19].Visible = false;
			shpPayUpPM[20].AllowDrop = true;
			shpPayUpPM[20].Enabled = false;
			shpPayUpPM[20].Name = "_shpPayUpPM_20";
			shpPayUpPM[20].TabIndex = 242;
			shpPayUpPM[20].Visible = false;
			shpPayUpPM[21].AllowDrop = true;
			shpPayUpPM[21].Enabled = false;
			shpPayUpPM[21].Name = "_shpPayUpPM_21";
			shpPayUpPM[21].TabIndex = 243;
			shpPayUpPM[21].Visible = false;
			shpPayUpPM[22].AllowDrop = true;
			shpPayUpPM[22].Enabled = false;
			shpPayUpPM[22].Name = "_shpPayUpPM_22";
			shpPayUpPM[22].TabIndex = 244;
			shpPayUpPM[22].Visible = false;
			shpPayUpPM[23].AllowDrop = true;
			shpPayUpPM[23].Enabled = false;
			shpPayUpPM[23].Name = "_shpPayUpPM_23";
			shpPayUpPM[23].TabIndex = 245;
			shpPayUpPM[23].Visible = false;
			shpPayUpPM[24].AllowDrop = true;
			shpPayUpPM[24].Enabled = false;
			shpPayUpPM[24].Name = "_shpPayUpPM_24";
			shpPayUpPM[24].TabIndex = 246;
			shpPayUpPM[24].Visible = false;
			shpPayUpPM[25].AllowDrop = true;
			shpPayUpPM[25].Enabled = false;
			shpPayUpPM[25].Name = "_shpPayUpPM_25";
			shpPayUpPM[25].TabIndex = 247;
			shpPayUpPM[25].Visible = false;
			shpPayUpPM[26].AllowDrop = true;
			shpPayUpPM[26].Enabled = false;
			shpPayUpPM[26].Name = "_shpPayUpPM_26";
			shpPayUpPM[26].TabIndex = 248;
			shpPayUpPM[26].Visible = false;
			shpPayUpPM[27].AllowDrop = true;
			shpPayUpPM[27].Enabled = false;
			shpPayUpPM[27].Name = "_shpPayUpPM_27";
			shpPayUpPM[27].TabIndex = 249;
			shpPayUpPM[27].Visible = false;
			shpPayUpPM[28].AllowDrop = true;
			shpPayUpPM[28].Enabled = false;
			shpPayUpPM[28].Name = "_shpPayUpPM_28";
			shpPayUpPM[28].TabIndex = 250;
			shpPayUpPM[28].Visible = false;
			shpPayUpPM[29].AllowDrop = true;
			shpPayUpPM[29].Enabled = false;
			shpPayUpPM[29].Name = "_shpPayUpPM_29";
			shpPayUpPM[29].TabIndex = 251;
			shpPayUpPM[29].Visible = false;
			shpPayUpPM[30].AllowDrop = true;
			shpPayUpPM[30].Enabled = false;
			shpPayUpPM[30].Name = "_shpPayUpPM_30";
			shpPayUpPM[30].TabIndex = 252;
			shpPayUpPM[30].Visible = false;
			shpPayUpPM[31].AllowDrop = true;
			shpPayUpPM[31].Enabled = false;
			shpPayUpPM[31].Name = "_shpPayUpPM_31";
			shpPayUpPM[31].TabIndex = 253;
			shpPayUpPM[31].Visible = false;
			shpPayUpPM[32].AllowDrop = true;
			shpPayUpPM[32].Enabled = false;
			shpPayUpPM[32].Name = "_shpPayUpPM_32";
			shpPayUpPM[32].TabIndex = 254;
			shpPayUpPM[32].Visible = false;
			shpPayUpPM[33].AllowDrop = true;
			shpPayUpPM[33].Enabled = false;
			shpPayUpPM[33].Name = "_shpPayUpPM_33";
			shpPayUpPM[33].TabIndex = 255;
			shpPayUpPM[33].Visible = false;
			shpPayUpPM[34].AllowDrop = true;
			shpPayUpPM[34].Enabled = false;
			shpPayUpPM[34].Name = "_shpPayUpPM_34";
			shpPayUpPM[34].TabIndex = 256;
			shpPayUpPM[34].Visible = false;
			shpPayUpPM[35].AllowDrop = true;
			shpPayUpPM[35].Enabled = false;
			shpPayUpPM[35].Name = "_shpPayUpPM_35";
			shpPayUpPM[35].TabIndex = 257;
			shpPayUpPM[35].Visible = false;
			lbUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			lbUnit[9] = _lbUnit_9;
			lbUnit[0] = _lbUnit_0;
			lbUnit[1] = _lbUnit_1;
			lbUnit[2] = _lbUnit_2;
			lbUnit[3] = _lbUnit_3;
			lbUnit[4] = _lbUnit_4;
			lbUnit[5] = _lbUnit_5;
			lbUnit[6] = _lbUnit_6;
			lbUnit[7] = _lbUnit_7;
			lbUnit[8] = _lbUnit_8;
			lbUnit[9].AllowDrop = true;
			lbUnit[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[9].Name = "_lbUnit_9";
			lbUnit[9].TabIndex = 172;
			lbUnit[9].Text = "M02";
			lbUnit[0].AllowDrop = true;
			lbUnit[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[0].Name = "_lbUnit_0";
			lbUnit[0].TabIndex = 158;
			lbUnit[0].Text = "E03";
			lbUnit[1].AllowDrop = true;
			lbUnit[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[1].Name = "_lbUnit_1";
			lbUnit[1].TabIndex = 149;
			lbUnit[1].Text = "E10";
			lbUnit[2].AllowDrop = true;
			lbUnit[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[2].Name = "_lbUnit_2";
			lbUnit[2].TabIndex = 140;
			lbUnit[2].Visible = false;
			lbUnit[3].AllowDrop = true;
			lbUnit[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[3].Name = "_lbUnit_3";
			lbUnit[3].TabIndex = 129;
			lbUnit[3].Text = "E17";
			lbUnit[4].AllowDrop = true;
			lbUnit[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[4].Name = "_lbUnit_4";
			lbUnit[4].TabIndex = 120;
			lbUnit[4].Text = "M01";
			lbUnit[5].AllowDrop = true;
			lbUnit[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[5].Name = "_lbUnit_5";
			lbUnit[5].TabIndex = 77;
			lbUnit[5].Text = "M03";
			lbUnit[6].AllowDrop = true;
			lbUnit[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[6].Name = "_lbUnit_6";
			lbUnit[6].TabIndex = 68;
			lbUnit[6].Text = "M04";
			lbUnit[7].AllowDrop = true;
			lbUnit[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[7].Name = "_lbUnit_7";
			lbUnit[7].TabIndex = 59;
			lbUnit[7].Text = "M05";
			lbUnit[8].AllowDrop = true;
			lbUnit[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			lbUnit[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbUnit[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[8].Name = "_lbUnit_8";
			lbUnit[8].TabIndex = 50;
			lbUnit[8].Text = "M06";
			lbPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(40);
			lbPosition[39] = _lbPosition_39;
			lbPosition[38] = _lbPosition_38;
			lbPosition[37] = _lbPosition_37;
			lbPosition[36] = _lbPosition_36;
			lbPosition[0] = _lbPosition_0;
			lbPosition[1] = _lbPosition_1;
			lbPosition[2] = _lbPosition_2;
			lbPosition[3] = _lbPosition_3;
			lbPosition[4] = _lbPosition_4;
			lbPosition[5] = _lbPosition_5;
			lbPosition[6] = _lbPosition_6;
			lbPosition[7] = _lbPosition_7;
			lbPosition[8] = _lbPosition_8;
			lbPosition[9] = _lbPosition_9;
			lbPosition[10] = _lbPosition_10;
			lbPosition[11] = _lbPosition_11;
			lbPosition[12] = _lbPosition_12;
			lbPosition[13] = _lbPosition_13;
			lbPosition[14] = _lbPosition_14;
			lbPosition[15] = _lbPosition_15;
			lbPosition[16] = _lbPosition_16;
			lbPosition[17] = _lbPosition_17;
			lbPosition[18] = _lbPosition_18;
			lbPosition[19] = _lbPosition_19;
			lbPosition[20] = _lbPosition_20;
			lbPosition[21] = _lbPosition_21;
			lbPosition[22] = _lbPosition_22;
			lbPosition[23] = _lbPosition_23;
			lbPosition[24] = _lbPosition_24;
			lbPosition[25] = _lbPosition_25;
			lbPosition[26] = _lbPosition_26;
			lbPosition[27] = _lbPosition_27;
			lbPosition[28] = _lbPosition_28;
			lbPosition[29] = _lbPosition_29;
			lbPosition[30] = _lbPosition_30;
			lbPosition[31] = _lbPosition_31;
			lbPosition[32] = _lbPosition_32;
			lbPosition[33] = _lbPosition_33;
			lbPosition[34] = _lbPosition_34;
			lbPosition[35] = _lbPosition_35;
			lbPosition[39].AllowDrop = true;
			lbPosition[39].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[39].Name = "_lbPosition_39";
			lbPosition[39].TabIndex = 171;
			lbPosition[39].Text = "4TH";
			lbPosition[39].Visible = false;
			lbPosition[38].AllowDrop = true;
			lbPosition[38].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[38].Name = "_lbPosition_38";
			lbPosition[38].TabIndex = 170;
			lbPosition[38].Text = "STUDENT";
			lbPosition[37].AllowDrop = true;
			lbPosition[37].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[37].Name = "_lbPosition_37";
			lbPosition[37].TabIndex = 169;
			lbPosition[37].Text = "DR";
			lbPosition[36].AllowDrop = true;
			lbPosition[36].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[36].Name = "_lbPosition_36";
			lbPosition[36].TabIndex = 168;
			lbPosition[36].Text = "INCHG";
			lbPosition[0].AllowDrop = true;
			lbPosition[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[0].Name = "_lbPosition_0";
			lbPosition[0].TabIndex = 157;
			lbPosition[0].Text = "OFF";
			lbPosition[1].AllowDrop = true;
			lbPosition[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[1].Name = "_lbPosition_1";
			lbPosition[1].TabIndex = 156;
			lbPosition[1].Text = "DR";
			lbPosition[2].AllowDrop = true;
			lbPosition[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[2].Name = "_lbPosition_2";
			lbPosition[2].TabIndex = 155;
			lbPosition[2].Text = "3RD";
			lbPosition[3].AllowDrop = true;
			lbPosition[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[3].Name = "_lbPosition_3";
			lbPosition[3].TabIndex = 154;
			lbPosition[3].Text = "4TH";
			lbPosition[4].AllowDrop = true;
			lbPosition[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[4].Name = "_lbPosition_4";
			lbPosition[4].TabIndex = 153;
			lbPosition[4].Text = "OFF";
			lbPosition[5].AllowDrop = true;
			lbPosition[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[5].Name = "_lbPosition_5";
			lbPosition[5].TabIndex = 152;
			lbPosition[5].Text = "DR";
			lbPosition[6].AllowDrop = true;
			lbPosition[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[6].Name = "_lbPosition_6";
			lbPosition[6].TabIndex = 151;
			lbPosition[6].Text = "3RD";
			lbPosition[7].AllowDrop = true;
			lbPosition[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[7].Name = "_lbPosition_7";
			lbPosition[7].TabIndex = 150;
			lbPosition[7].Text = "4TH";
			lbPosition[8].AllowDrop = true;
			lbPosition[8].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[8].Name = "_lbPosition_8";
			lbPosition[8].TabIndex = 148;
			lbPosition[8].Visible = false;
			lbPosition[9].AllowDrop = true;
			lbPosition[9].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[9].Name = "_lbPosition_9";
			lbPosition[9].TabIndex = 147;
			lbPosition[9].Visible = false;
			lbPosition[10].AllowDrop = true;
			lbPosition[10].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[10].Name = "_lbPosition_10";
			lbPosition[10].TabIndex = 146;
			lbPosition[10].Visible = false;
			lbPosition[11].AllowDrop = true;
			lbPosition[11].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[11].Name = "_lbPosition_11";
			lbPosition[11].TabIndex = 145;
			lbPosition[11].Visible = false;
			lbPosition[12].AllowDrop = true;
			lbPosition[12].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[12].Name = "_lbPosition_12";
			lbPosition[12].TabIndex = 144;
			lbPosition[12].Text = "OFF";
			lbPosition[13].AllowDrop = true;
			lbPosition[13].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[13].Name = "_lbPosition_13";
			lbPosition[13].TabIndex = 143;
			lbPosition[13].Text = "DR";
			lbPosition[14].AllowDrop = true;
			lbPosition[14].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[14].Name = "_lbPosition_14";
			lbPosition[14].TabIndex = 142;
			lbPosition[14].Text = "3RD";
			lbPosition[15].AllowDrop = true;
			lbPosition[15].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[15].Name = "_lbPosition_15";
			lbPosition[15].TabIndex = 141;
			lbPosition[15].Text = "4TH";
			lbPosition[16].AllowDrop = true;
			lbPosition[16].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[16].Name = "_lbPosition_16";
			lbPosition[16].TabIndex = 139;
			lbPosition[16].Text = "INCHG";
			lbPosition[17].AllowDrop = true;
			lbPosition[17].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[17].Name = "_lbPosition_17";
			lbPosition[17].TabIndex = 138;
			lbPosition[17].Text = "DR";
			lbPosition[18].AllowDrop = true;
			lbPosition[18].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[18].Name = "_lbPosition_18";
			lbPosition[18].TabIndex = 137;
			lbPosition[18].Text = "STUDENT";
			lbPosition[19].AllowDrop = true;
			lbPosition[19].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[19].Name = "_lbPosition_19";
			lbPosition[19].TabIndex = 136;
			lbPosition[19].Text = "4TH";
			lbPosition[19].Visible = false;
			lbPosition[20].AllowDrop = true;
			lbPosition[20].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[20].Name = "_lbPosition_20";
			lbPosition[20].TabIndex = 135;
			lbPosition[20].Text = "INCHG";
			lbPosition[21].AllowDrop = true;
			lbPosition[21].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[21].Name = "_lbPosition_21";
			lbPosition[21].TabIndex = 134;
			lbPosition[21].Text = "DR";
			lbPosition[22].AllowDrop = true;
			lbPosition[22].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[22].Name = "_lbPosition_22";
			lbPosition[22].TabIndex = 133;
			lbPosition[22].Text = "STUDENT";
			lbPosition[23].AllowDrop = true;
			lbPosition[23].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[23].Name = "_lbPosition_23";
			lbPosition[23].TabIndex = 132;
			lbPosition[23].Text = "4TH";
			lbPosition[23].Visible = false;
			lbPosition[24].AllowDrop = true;
			lbPosition[24].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[24].Name = "_lbPosition_24";
			lbPosition[24].TabIndex = 128;
			lbPosition[24].Text = "INCHG";
			lbPosition[25].AllowDrop = true;
			lbPosition[25].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[25].Name = "_lbPosition_25";
			lbPosition[25].TabIndex = 127;
			lbPosition[25].Text = "DR";
			lbPosition[26].AllowDrop = true;
			lbPosition[26].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[26].Name = "_lbPosition_26";
			lbPosition[26].TabIndex = 126;
			lbPosition[26].Text = "STUDENT";
			lbPosition[27].AllowDrop = true;
			lbPosition[27].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[27].Name = "_lbPosition_27";
			lbPosition[27].TabIndex = 125;
			lbPosition[27].Text = "4TH";
			lbPosition[27].Visible = false;
			lbPosition[28].AllowDrop = true;
			lbPosition[28].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[28].Name = "_lbPosition_28";
			lbPosition[28].TabIndex = 124;
			lbPosition[28].Text = "INCHG";
			lbPosition[29].AllowDrop = true;
			lbPosition[29].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[29].Name = "_lbPosition_29";
			lbPosition[29].TabIndex = 123;
			lbPosition[29].Text = "DR";
			lbPosition[30].AllowDrop = true;
			lbPosition[30].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[30].Name = "_lbPosition_30";
			lbPosition[30].TabIndex = 122;
			lbPosition[30].Text = "STUDENT";
			lbPosition[31].AllowDrop = true;
			lbPosition[31].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[31].Name = "_lbPosition_31";
			lbPosition[31].TabIndex = 121;
			lbPosition[31].Text = "4TH";
			lbPosition[31].Visible = false;
			lbPosition[32].AllowDrop = true;
			lbPosition[32].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[32].Name = "_lbPosition_32";
			lbPosition[32].TabIndex = 119;
			lbPosition[32].Text = "INCHG";
			lbPosition[33].AllowDrop = true;
			lbPosition[33].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[33].Name = "_lbPosition_33";
			lbPosition[33].TabIndex = 118;
			lbPosition[33].Text = "DR";
			lbPosition[34].AllowDrop = true;
			lbPosition[34].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[34].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[34].Name = "_lbPosition_34";
			lbPosition[34].TabIndex = 117;
			lbPosition[34].Text = "STUDENT";
			lbPosition[35].AllowDrop = true;
			lbPosition[35].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPosition[35].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPosition[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[35].Name = "_lbPosition_35";
			lbPosition[35].TabIndex = 116;
			lbPosition[35].Text = "4TH";
			lbPosition[35].Visible = false;
			lbPositionPM = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(40);
			lbPositionPM[39] = _lbPositionPM_39;
			lbPositionPM[38] = _lbPositionPM_38;
			lbPositionPM[37] = _lbPositionPM_37;
			lbPositionPM[36] = _lbPositionPM_36;
			lbPositionPM[0] = _lbPositionPM_0;
			lbPositionPM[1] = _lbPositionPM_1;
			lbPositionPM[2] = _lbPositionPM_2;
			lbPositionPM[3] = _lbPositionPM_3;
			lbPositionPM[4] = _lbPositionPM_4;
			lbPositionPM[5] = _lbPositionPM_5;
			lbPositionPM[6] = _lbPositionPM_6;
			lbPositionPM[7] = _lbPositionPM_7;
			lbPositionPM[8] = _lbPositionPM_8;
			lbPositionPM[9] = _lbPositionPM_9;
			lbPositionPM[10] = _lbPositionPM_10;
			lbPositionPM[11] = _lbPositionPM_11;
			lbPositionPM[12] = _lbPositionPM_12;
			lbPositionPM[13] = _lbPositionPM_13;
			lbPositionPM[14] = _lbPositionPM_14;
			lbPositionPM[15] = _lbPositionPM_15;
			lbPositionPM[16] = _lbPositionPM_16;
			lbPositionPM[17] = _lbPositionPM_17;
			lbPositionPM[18] = _lbPositionPM_18;
			lbPositionPM[19] = _lbPositionPM_19;
			lbPositionPM[20] = _lbPositionPM_20;
			lbPositionPM[21] = _lbPositionPM_21;
			lbPositionPM[22] = _lbPositionPM_22;
			lbPositionPM[23] = _lbPositionPM_23;
			lbPositionPM[24] = _lbPositionPM_24;
			lbPositionPM[25] = _lbPositionPM_25;
			lbPositionPM[26] = _lbPositionPM_26;
			lbPositionPM[27] = _lbPositionPM_27;
			lbPositionPM[28] = _lbPositionPM_28;
			lbPositionPM[29] = _lbPositionPM_29;
			lbPositionPM[30] = _lbPositionPM_30;
			lbPositionPM[31] = _lbPositionPM_31;
			lbPositionPM[32] = _lbPositionPM_32;
			lbPositionPM[33] = _lbPositionPM_33;
			lbPositionPM[34] = _lbPositionPM_34;
			lbPositionPM[35] = _lbPositionPM_35;
			lbPositionPM[39].AllowDrop = true;
			lbPositionPM[39].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[39].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[39].Name = "_lbPositionPM_39";
			lbPositionPM[39].TabIndex = 176;
			lbPositionPM[39].Text = "4TH";
			lbPositionPM[39].Visible = false;
			lbPositionPM[38].AllowDrop = true;
			lbPositionPM[38].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[38].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[38].Name = "_lbPositionPM_38";
			lbPositionPM[38].TabIndex = 175;
			lbPositionPM[38].Text = "STUDENT";
			lbPositionPM[38].Visible = false;
			lbPositionPM[37].AllowDrop = true;
			lbPositionPM[37].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[37].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[37].Name = "_lbPositionPM_37";
			lbPositionPM[37].TabIndex = 174;
			lbPositionPM[37].Text = "DR";
			lbPositionPM[37].Visible = false;
			lbPositionPM[36].AllowDrop = true;
			lbPositionPM[36].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[36].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[36].Name = "_lbPositionPM_36";
			lbPositionPM[36].TabIndex = 173;
			lbPositionPM[36].Text = "INCHG";
			lbPositionPM[36].Visible = false;
			lbPositionPM[0].AllowDrop = true;
			lbPositionPM[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[0].Name = "_lbPositionPM_0";
			lbPositionPM[0].TabIndex = 41;
			lbPositionPM[0].Text = "OFF";
			lbPositionPM[0].Visible = false;
			lbPositionPM[1].AllowDrop = true;
			lbPositionPM[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[1].Name = "_lbPositionPM_1";
			lbPositionPM[1].TabIndex = 40;
			lbPositionPM[1].Text = "DR";
			lbPositionPM[1].Visible = false;
			lbPositionPM[2].AllowDrop = true;
			lbPositionPM[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[2].Name = "_lbPositionPM_2";
			lbPositionPM[2].TabIndex = 39;
			lbPositionPM[2].Text = "3RD";
			lbPositionPM[2].Visible = false;
			lbPositionPM[3].AllowDrop = true;
			lbPositionPM[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[3].Name = "_lbPositionPM_3";
			lbPositionPM[3].TabIndex = 38;
			lbPositionPM[3].Text = "4TH";
			lbPositionPM[3].Visible = false;
			lbPositionPM[4].AllowDrop = true;
			lbPositionPM[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[4].Name = "_lbPositionPM_4";
			lbPositionPM[4].TabIndex = 37;
			lbPositionPM[4].Text = "OFF";
			lbPositionPM[4].Visible = false;
			lbPositionPM[5].AllowDrop = true;
			lbPositionPM[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[5].Name = "_lbPositionPM_5";
			lbPositionPM[5].TabIndex = 36;
			lbPositionPM[5].Text = "DR";
			lbPositionPM[5].Visible = false;
			lbPositionPM[6].AllowDrop = true;
			lbPositionPM[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[6].Name = "_lbPositionPM_6";
			lbPositionPM[6].TabIndex = 35;
			lbPositionPM[6].Text = "3RD";
			lbPositionPM[6].Visible = false;
			lbPositionPM[7].AllowDrop = true;
			lbPositionPM[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[7].Name = "_lbPositionPM_7";
			lbPositionPM[7].TabIndex = 34;
			lbPositionPM[7].Text = "4TH";
			lbPositionPM[7].Visible = false;
			lbPositionPM[8].AllowDrop = true;
			lbPositionPM[8].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[8].Name = "_lbPositionPM_8";
			lbPositionPM[8].TabIndex = 33;
			lbPositionPM[8].Visible = false;
			lbPositionPM[9].AllowDrop = true;
			lbPositionPM[9].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[9].Name = "_lbPositionPM_9";
			lbPositionPM[9].TabIndex = 32;
			lbPositionPM[9].Visible = false;
			lbPositionPM[10].AllowDrop = true;
			lbPositionPM[10].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[10].Name = "_lbPositionPM_10";
			lbPositionPM[10].TabIndex = 31;
			lbPositionPM[10].Visible = false;
			lbPositionPM[11].AllowDrop = true;
			lbPositionPM[11].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[11].Name = "_lbPositionPM_11";
			lbPositionPM[11].TabIndex = 30;
			lbPositionPM[11].Visible = false;
			lbPositionPM[12].AllowDrop = true;
			lbPositionPM[12].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[12].Name = "_lbPositionPM_12";
			lbPositionPM[12].TabIndex = 29;
			lbPositionPM[12].Text = "OFF";
			lbPositionPM[12].Visible = false;
			lbPositionPM[13].AllowDrop = true;
			lbPositionPM[13].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[13].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[13].Name = "_lbPositionPM_13";
			lbPositionPM[13].TabIndex = 28;
			lbPositionPM[13].Text = "DR";
			lbPositionPM[13].Visible = false;
			lbPositionPM[14].AllowDrop = true;
			lbPositionPM[14].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[14].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[14].Name = "_lbPositionPM_14";
			lbPositionPM[14].TabIndex = 27;
			lbPositionPM[14].Text = "3RD";
			lbPositionPM[14].Visible = false;
			lbPositionPM[15].AllowDrop = true;
			lbPositionPM[15].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[15].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[15].Name = "_lbPositionPM_15";
			lbPositionPM[15].TabIndex = 26;
			lbPositionPM[15].Text = "4TH";
			lbPositionPM[15].Visible = false;
			lbPositionPM[16].AllowDrop = true;
			lbPositionPM[16].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[16].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[16].Name = "_lbPositionPM_16";
			lbPositionPM[16].TabIndex = 25;
			lbPositionPM[16].Text = "INCHG";
			lbPositionPM[16].Visible = false;
			lbPositionPM[17].AllowDrop = true;
			lbPositionPM[17].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[17].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[17].Name = "_lbPositionPM_17";
			lbPositionPM[17].TabIndex = 24;
			lbPositionPM[17].Text = "DR";
			lbPositionPM[17].Visible = false;
			lbPositionPM[18].AllowDrop = true;
			lbPositionPM[18].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[18].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[18].Name = "_lbPositionPM_18";
			lbPositionPM[18].TabIndex = 23;
			lbPositionPM[18].Text = "STUDENT";
			lbPositionPM[18].Visible = false;
			lbPositionPM[19].AllowDrop = true;
			lbPositionPM[19].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[19].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[19].Name = "_lbPositionPM_19";
			lbPositionPM[19].TabIndex = 22;
			lbPositionPM[19].Text = "4TH";
			lbPositionPM[19].Visible = false;
			lbPositionPM[20].AllowDrop = true;
			lbPositionPM[20].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[20].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[20].Name = "_lbPositionPM_20";
			lbPositionPM[20].TabIndex = 21;
			lbPositionPM[20].Text = "INCHG";
			lbPositionPM[20].Visible = false;
			lbPositionPM[21].AllowDrop = true;
			lbPositionPM[21].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[21].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[21].Name = "_lbPositionPM_21";
			lbPositionPM[21].TabIndex = 20;
			lbPositionPM[21].Text = "DR";
			lbPositionPM[21].Visible = false;
			lbPositionPM[22].AllowDrop = true;
			lbPositionPM[22].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[22].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[22].Name = "_lbPositionPM_22";
			lbPositionPM[22].TabIndex = 19;
			lbPositionPM[22].Text = "STUDENT";
			lbPositionPM[22].Visible = false;
			lbPositionPM[23].AllowDrop = true;
			lbPositionPM[23].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[23].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[23].Name = "_lbPositionPM_23";
			lbPositionPM[23].TabIndex = 18;
			lbPositionPM[23].Text = "4TH";
			lbPositionPM[23].Visible = false;
			lbPositionPM[24].AllowDrop = true;
			lbPositionPM[24].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[24].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[24].Name = "_lbPositionPM_24";
			lbPositionPM[24].TabIndex = 17;
			lbPositionPM[24].Text = "INCHG";
			lbPositionPM[24].Visible = false;
			lbPositionPM[25].AllowDrop = true;
			lbPositionPM[25].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[25].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[25].Name = "_lbPositionPM_25";
			lbPositionPM[25].TabIndex = 16;
			lbPositionPM[25].Text = "DR";
			lbPositionPM[25].Visible = false;
			lbPositionPM[26].AllowDrop = true;
			lbPositionPM[26].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[26].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[26].Name = "_lbPositionPM_26";
			lbPositionPM[26].TabIndex = 15;
			lbPositionPM[26].Text = "STUDENT";
			lbPositionPM[26].Visible = false;
			lbPositionPM[27].AllowDrop = true;
			lbPositionPM[27].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[27].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[27].Name = "_lbPositionPM_27";
			lbPositionPM[27].TabIndex = 14;
			lbPositionPM[27].Text = "4TH";
			lbPositionPM[27].Visible = false;
			lbPositionPM[28].AllowDrop = true;
			lbPositionPM[28].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[28].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[28].Name = "_lbPositionPM_28";
			lbPositionPM[28].TabIndex = 13;
			lbPositionPM[28].Text = "INCHG";
			lbPositionPM[28].Visible = false;
			lbPositionPM[29].AllowDrop = true;
			lbPositionPM[29].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[29].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[29].Name = "_lbPositionPM_29";
			lbPositionPM[29].TabIndex = 12;
			lbPositionPM[29].Text = "DR";
			lbPositionPM[29].Visible = false;
			lbPositionPM[30].AllowDrop = true;
			lbPositionPM[30].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[30].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[30].Name = "_lbPositionPM_30";
			lbPositionPM[30].TabIndex = 11;
			lbPositionPM[30].Text = "STUDENT";
			lbPositionPM[30].Visible = false;
			lbPositionPM[31].AllowDrop = true;
			lbPositionPM[31].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[31].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[31].Name = "_lbPositionPM_31";
			lbPositionPM[31].TabIndex = 10;
			lbPositionPM[31].Text = "4TH";
			lbPositionPM[31].Visible = false;
			lbPositionPM[32].AllowDrop = true;
			lbPositionPM[32].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[32].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[32].Name = "_lbPositionPM_32";
			lbPositionPM[32].TabIndex = 9;
			lbPositionPM[32].Text = "INCHG";
			lbPositionPM[32].Visible = false;
			lbPositionPM[33].AllowDrop = true;
			lbPositionPM[33].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[33].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[33].Name = "_lbPositionPM_33";
			lbPositionPM[33].TabIndex = 8;
			lbPositionPM[33].Text = "DR";
			lbPositionPM[33].Visible = false;
			lbPositionPM[34].AllowDrop = true;
			lbPositionPM[34].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[34].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[34].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[34].Name = "_lbPositionPM_34";
			lbPositionPM[34].TabIndex = 7;
			lbPositionPM[34].Text = "STUDENT";
			lbPositionPM[34].Visible = false;
			lbPositionPM[35].AllowDrop = true;
			lbPositionPM[35].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbPositionPM[35].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPositionPM[35].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPositionPM[35].Name = "_lbPositionPM_35";
			lbPositionPM[35].TabIndex = 6;
			lbPositionPM[35].Text = "4TH";
			lbPositionPM[35].Visible = false;
			this.SelectedLabel = null;
			this.SelectedSA = "";
			this.SelectedSAName = "";
			this.ClickedLeave = false;
			boxUnit = ctx.Resolve<System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel>>(10);
			boxUnit[9] = _boxUnit_9;
			boxUnit[5] = _boxUnit_5;
			boxUnit[0] = _boxUnit_0;
			boxUnit[3] = _boxUnit_3;
			boxUnit[4] = _boxUnit_4;
			boxUnit[7] = _boxUnit_7;
			boxUnit[8] = _boxUnit_8;
			boxUnit[2] = _boxUnit_2;
			boxUnit[1] = _boxUnit_1;
			boxUnit[6] = _boxUnit_6;
			boxUnit[9].AllowDrop = true;
			boxUnit[9].Enabled = false;
			boxUnit[9].Name = "_boxUnit_9";
			boxUnit[9].TabIndex = 177;
			boxUnit[5].AllowDrop = true;
			boxUnit[5].Enabled = false;
			boxUnit[5].Name = "_boxUnit_5";
			boxUnit[5].TabIndex = 178;
			boxUnit[0].AllowDrop = true;
			boxUnit[0].Enabled = false;
			boxUnit[0].Name = "_boxUnit_0";
			boxUnit[0].TabIndex = 179;
			boxUnit[3].AllowDrop = true;
			boxUnit[3].Enabled = false;
			boxUnit[3].Name = "_boxUnit_3";
			boxUnit[3].TabIndex = 180;
			boxUnit[4].AllowDrop = true;
			boxUnit[4].Enabled = false;
			boxUnit[4].Name = "_boxUnit_4";
			boxUnit[4].TabIndex = 181;
			boxUnit[7].AllowDrop = true;
			boxUnit[7].Enabled = false;
			boxUnit[7].Name = "_boxUnit_7";
			boxUnit[7].TabIndex = 182;
			boxUnit[8].AllowDrop = true;
			boxUnit[8].Enabled = false;
			boxUnit[8].Name = "_boxUnit_8";
			boxUnit[8].TabIndex = 183;
			boxUnit[2].AllowDrop = true;
			boxUnit[2].Enabled = false;
			boxUnit[2].Name = "_boxUnit_2";
			boxUnit[2].TabIndex = 184;
			boxUnit[1].AllowDrop = true;
			boxUnit[1].Enabled = false;
			boxUnit[1].Name = "_boxUnit_1";
			boxUnit[1].TabIndex = 185;
			boxUnit[6].AllowDrop = true;
			boxUnit[6].Enabled = false;
			boxUnit[6].Name = "_boxUnit_6";
			boxUnit[6].TabIndex = 258;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636251761468939633", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text340636251761468959161", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx945636251761468998217");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static985636251761469007981");
			namedStyle4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle4.CellType = textCellType2;
			namedStyle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1023636251761469017745");
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1063636251761469027509");
			namedStyle6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle6.CellType = textCellType3;
			namedStyle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1246636251761469056801");
			namedStyle7.CellType = textCellType4;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1302636251761469066565");
			namedStyle8.CellType = textCellType5;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType5;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmEMSDailySched";
			IsMdiChild = true;
			this.sprLeave.NamedStyles.Add(namedStyle1);
			this.sprLeave.NamedStyles.Add(namedStyle2);
			this.sprLeave.NamedStyles.Add(namedStyle3);
			this.sprLeave.NamedStyles.Add(namedStyle4);
			this.sprLeave.NamedStyles.Add(namedStyle5);
			this.sprLeave.NamedStyles.Add(namedStyle6);
			this.sprLeave.NamedStyles.Add(namedStyle7);
			this.sprLeave.NamedStyles.Add(namedStyle8);
			this.sprLeave.Sheets.Add(this.sprLeave_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintPayPeriodReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSystem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEmpInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSeniorityInq { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuImmune { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_transfer_req { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewBatt3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattalion4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHazmat { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuMarine { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBattStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_watch_duty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Vacation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMVacationSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRoster { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_DDGroups { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuProlist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSenior { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_emp_facility { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndYearSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuOvertime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_sa_report { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuShiftCal { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTransfer { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSchedul { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDailyLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAnnual { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_dailysickleave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuIndLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuDispatchLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuLeaveReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnutimecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuindannualpayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupersonnelsignoff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnupayrollreports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_QuarterlyMinimumDrill { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_ReadingAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_OTEPReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_PMRecertReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_trainingtracker { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndTrainReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndPMRecert { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel MnuTrnReports { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_TrainingQuerynew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_Queries { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTraining { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuCascade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPrintScreen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuWindow { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuContents { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuAbout { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_timecodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payrolllegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_legend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_IndLegend { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_payup_calc { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrainCodeHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuHelp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuNewSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayUp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuPayDown { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuKOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuRemove { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuSendTo183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnu_viewtimecard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuViewDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel mnuEMSPopup { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprLeave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSelectName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picTrash { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calSchedDate { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_39 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_38 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_37 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_36 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_39 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_38 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_37 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_36 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_36 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel pnSelected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocked { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPeriodClosed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_35 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPositionPM_35 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbShift { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_9 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_10 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_12 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_13 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_14 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_15 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_16 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_17 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_18 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_19 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_20 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_21 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_22 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_23 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_24 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_25 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_26 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_27 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_28 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_29 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_30 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_31 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_32 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_33 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_34 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpAM_35 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_1 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_5 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_6 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_7 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_8 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_9 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_10 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_11 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_12 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_13 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_14 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_15 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_16 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_17 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_18 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_19 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_20 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_21 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_22 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_23 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_24 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_25 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_26 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_27 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_28 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_29 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_30 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_31 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_32 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_33 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_34 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _shpPayUpPM_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel _boxUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosam_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPospm_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ToolStripViewModel Ctx_mnuEMSPopup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeave_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPayroll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPosam { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPospm { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpPayUpAM { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> shpPayUpPM { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbUnit { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPositionPM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.Helpers.ControlViewModel SelectedLabel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSA { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSAName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean ClickedLeave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<VB6Helpers.ViewModels.ShapeHelperViewModel> boxUnit { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}