using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndSched))]
	public class frmIndSchedViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Enabled = true;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 0;
			this.cboNameList.Text = "cboNameList";
			this.cboNameList.Visible = true;
			this.calLeaveDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calLeaveDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calLeaveDate.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calLeaveDate.MinDate = System.DateTime.Parse("1996/1/1");
			this.calLeaveDate.Name = "calLeaveDate";
			this.calLeaveDate.TabIndex = 43;
			this._optLeaveType_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLeaveType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 69;
			this.Label2.Text = "Time Type";
			this.Line2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line2
			// 
			this.Line2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Line2.Enabled = false;
			this.Line2.Name = "Line2";
			this.Line2.Visible = true;
			this.lbSpecEvent = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecEvent
			// 
			this.lbSpecEvent.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecEvent.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSpecEvent.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 128);
			this.lbSpecEvent.Name = "lbSpecEvent";
			this.lbSpecEvent.TabIndex = 92;
			this.lbSpecEvent.Text = "lbSpecEvent";
			this.lbCallBackNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCallBackNum
			// 
			this.lbCallBackNum.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCallBackNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCallBackNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 255);
			this.lbCallBackNum.Name = "lbCallBackNum";
			this.lbCallBackNum.TabIndex = 90;
			this.lbCallBackNum.Text = "lbCallBackNum";
			this.lbMILInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMILInfo
			// 
			this.lbMILInfo.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMILInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial Narrow", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMILInfo.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			this.lbMILInfo.Name = "lbMILInfo";
			this.lbMILInfo.TabIndex = 89;
			this.lbMILInfo.Text = "*3 shifts available as of 6/12/2008";
			this.lbMILInfo.Visible = false;
			this.Shape4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape4.Enabled = false;
			this.Shape4.Name = "Shape4";
			this.Shape4.Visible = true;
			this.lbSelectTitle7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle7
			// 
			this.lbSelectTitle7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle7.Name = "lbSelectTitle7";
			this.lbSelectTitle7.TabIndex = 86;
			this.lbSelectTitle7.Text = "FCC";
			this.lbSelectTitle7.Visible = false;
			this.lbFCCam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFCCam
			// 
			this.lbFCCam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFCCam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFCCam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbFCCam.Name = "lbFCCam";
			this.lbFCCam.TabIndex = 85;
			this.lbFCCam.Visible = false;
			this.lbFCCpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFCCpm
			// 
			this.lbFCCpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFCCpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFCCpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbFCCpm.Name = "lbFCCpm";
			this.lbFCCpm.TabIndex = 84;
			this.lbFCCpm.Visible = false;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Teal;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 81;
			this.Label4.Text = "Note:  The * on the calendar indicates a \"cycle day\"";
			this.lbYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbYear
			// 
			this.lbYear.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 8.4f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbYear.Name = "lbYear";
			this.lbYear.TabIndex = 80;
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 79;
			this.Label21.Text = "VAC";
			this.lbVacation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVacation
			// 
			this.lbVacation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVacation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVacation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.lbVacation.Name = "lbVacation";
			this.lbVacation.TabIndex = 78;
			this.Label30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label30
			// 
			this.Label30.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label30.Name = "Label30";
			this.Label30.TabIndex = 77;
			this.Label30.Text = "Open";
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 76;
			this.Label29.Text = "Sched";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 71;
			this.Label3.Text = "VAC-Bank";
			this.lbVacBank = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVacBank
			// 
			this.lbVacBank.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVacBank.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVacBank.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.lbVacBank.Name = "lbVacBank";
			this.lbVacBank.TabIndex = 70;
			this.lbKelOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbKelOpen
			// 
			this.lbKelOpen.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbKelOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbKelOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbKelOpen.Name = "lbKelOpen";
			this.lbKelOpen.TabIndex = 67;
			this.lbKelly = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbKelly
			// 
			this.lbKelly.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbKelly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbKelly.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 128, 0);
			this.lbKelly.Name = "lbKelly";
			this.lbKelly.TabIndex = 66;
			this.lbKellyTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbKellyTitle
			// 
			this.lbKellyTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbKellyTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbKellyTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.lbKellyTitle.Name = "lbKellyTitle";
			this.lbKellyTitle.TabIndex = 65;
			this.lbKellyTitle.Text = "Kelly";
			this.lbKellyTitle.Visible = false;
			this.lbBATpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBATpm
			// 
			this.lbBATpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBATpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBATpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbBATpm.Name = "lbBATpm";
			this.lbBATpm.TabIndex = 64;
			this.lbBATpm.Visible = false;
			this.lbBATam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBATam
			// 
			this.lbBATam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBATam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBATam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbBATam.Name = "lbBATam";
			this.lbBATam.TabIndex = 63;
			this.lbBATam.Visible = false;
			this.lbSelectTitle6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle6
			// 
			this.lbSelectTitle6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle6.Name = "lbSelectTitle6";
			this.lbSelectTitle6.TabIndex = 62;
			this.lbSelectTitle6.Text = "BATT";
			this.lbSelectTitle6.Visible = false;
			this.lbTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.TabIndex = 7;
			this.lbAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAddress
			// 
			this.lbAddress.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAddress.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbAddress.Name = "lbAddress";
			this.lbAddress.TabIndex = 6;
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 41;
			this.Label20.Text = "Update Schedule";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.Visible = true;
			this.lbTotalDebits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalDebits
			// 
			this.lbTotalDebits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalDebits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTotalDebits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbTotalDebits.Name = "lbTotalDebits";
			this.lbTotalDebits.TabIndex = 22;
			this.lbPos = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPos
			// 
			this.lbPos.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPos.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPos.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbPos.Name = "lbPos";
			this.lbPos.TabIndex = 21;
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 20;
			this.lbShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbShift
			// 
			this.lbShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbShift.Name = "lbShift";
			this.lbShift.TabIndex = 19;
			this.lbBatt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBatt
			// 
			this.lbBatt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBatt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBatt.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbBatt.Name = "lbBatt";
			this.lbBatt.TabIndex = 18;
			this.lbDebit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDebit
			// 
			this.lbDebit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDebit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDebit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbDebit.Name = "lbDebit";
			this.lbDebit.TabIndex = 17;
			this.lbDebit.Text = "Debit Group";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 16;
			this.Label12.Text = "Position";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 15;
			this.Label11.Text = "Select Employee";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 14;
			this.Label10.Text = "Unit";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 13;
			this.Label9.Text = "Shift";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 12;
			this.Label8.Text = "Batt";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.Visible = true;
			this.lbCOThire = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCOThire
			// 
			this.lbCOThire.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCOThire.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCOThire.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbCOThire.Name = "lbCOThire";
			this.lbCOThire.TabIndex = 11;
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 10;
			this.Label6.Text = "COT SD";
			this.lbPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhone
			// 
			this.lbPhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbPhone.Name = "lbPhone";
			this.lbPhone.TabIndex = 9;
			this.lbCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCity
			// 
			this.lbCity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbCity.Name = "lbCity";
			this.lbCity.TabIndex = 8;
			this.lbZip = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbZip
			// 
			this.lbZip.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbZip.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbZip.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbZip.Name = "lbZip";
			this.lbZip.TabIndex = 5;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "TFD HD";
			this.lbTFDhire = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTFDhire
			// 
			this.lbTFDhire.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTFDhire.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTFDhire.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbTFDhire.Name = "lbTFDhire";
			this.lbTFDhire.TabIndex = 3;
			this.lbType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbType
			// 
			this.lbType.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbType.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbType.Name = "lbType";
			this.lbType.TabIndex = 2;
			this.lbType.Text = "lbType";
			this.lbType.Visible = false;
			this.lbMilOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMilOpen
			// 
			this.lbMilOpen.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMilOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMilOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbMilOpen.Name = "lbMilOpen";
			this.lbMilOpen.TabIndex = 31;
			this.lbHolOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHolOpen
			// 
			this.lbHolOpen.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHolOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHolOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbHolOpen.Name = "lbHolOpen";
			this.lbHolOpen.TabIndex = 30;
			this.Line7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line7
			// 
			this.Line7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 0);
			this.Line7.Enabled = false;
			this.Line7.Name = "Line7";
			this.Line7.Visible = true;
			this.lbMilitary = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMilitary
			// 
			this.lbMilitary.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMilitary.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMilitary.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.lbMilitary.Name = "lbMilitary";
			this.lbMilitary.TabIndex = 28;
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 27;
			this.Label23.Text = "Military";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 26;
			this.Label22.Text = "Holiday";
			this.LeaveTot = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// LeaveTot
			// 
			this.LeaveTot.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.LeaveTot.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.LeaveTot.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.LeaveTot.Name = "LeaveTot";
			this.LeaveTot.TabIndex = 25;
			this.LeaveTot.Text = "Leave Totals";
			this.lbHoliday = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHoliday
			// 
			this.lbHoliday.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHoliday.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHoliday.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbHoliday.Name = "lbHoliday";
			this.lbHoliday.TabIndex = 24;
			this.lbSelectTitle1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle1
			// 
			this.lbSelectTitle1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle1.Name = "lbSelectTitle1";
			this.lbSelectTitle1.TabIndex = 58;
			this.lbSelectTitle1.Text = "Sched Leave Totals:";
			this.lbSelectTitle1.Visible = false;
			this.lbSelectPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectPM
			// 
			this.lbSelectPM.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbSelectPM.Name = "lbSelectPM";
			this.lbSelectPM.TabIndex = 57;
			this.lbSelectPM.Visible = false;
			this.lbSelectAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectAM
			// 
			this.lbSelectAM.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectAM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbSelectAM.Name = "lbSelectAM";
			this.lbSelectAM.TabIndex = 56;
			this.lbSelectAM.Visible = false;
			this.lbMRNpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMRNpm
			// 
			this.lbMRNpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMRNpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMRNpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbMRNpm.Name = "lbMRNpm";
			this.lbMRNpm.TabIndex = 55;
			this.lbMRNpm.Visible = false;
			this.lbHZMpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHZMpm
			// 
			this.lbHZMpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHZMpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHZMpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbHZMpm.Name = "lbHZMpm";
			this.lbHZMpm.TabIndex = 54;
			this.lbHZMpm.Visible = false;
			this.lbPMpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPMpm
			// 
			this.lbPMpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPMpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPMpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbPMpm.Name = "lbPMpm";
			this.lbPMpm.TabIndex = 53;
			this.lbPMpm.Visible = false;
			this.lbREGpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGpm
			// 
			this.lbREGpm.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbREGpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbREGpm.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbREGpm.Name = "lbREGpm";
			this.lbREGpm.TabIndex = 52;
			this.lbREGpm.Visible = false;
			this.lbPMam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPMam
			// 
			this.lbPMam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPMam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPMam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbPMam.Name = "lbPMam";
			this.lbPMam.TabIndex = 51;
			this.lbPMam.Visible = false;
			this.lbMRNam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMRNam
			// 
			this.lbMRNam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMRNam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMRNam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbMRNam.Name = "lbMRNam";
			this.lbMRNam.TabIndex = 50;
			this.lbMRNam.Visible = false;
			this.lbHZMam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHZMam
			// 
			this.lbHZMam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHZMam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHZMam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbHZMam.Name = "lbHZMam";
			this.lbHZMam.TabIndex = 49;
			this.lbHZMam.Visible = false;
			this.lbREGam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGam
			// 
			this.lbREGam.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbREGam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbREGam.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbREGam.Name = "lbREGam";
			this.lbREGam.TabIndex = 48;
			this.lbREGam.Visible = false;
			this.lbSelectTitle3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle3
			// 
			this.lbSelectTitle3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle3.Name = "lbSelectTitle3";
			this.lbSelectTitle3.TabIndex = 47;
			this.lbSelectTitle3.Text = "PAR";
			this.lbSelectTitle3.Visible = false;
			this.lbSelectTitle5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle5
			// 
			this.lbSelectTitle5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle5.Name = "lbSelectTitle5";
			this.lbSelectTitle5.TabIndex = 46;
			this.lbSelectTitle5.Text = "MRN";
			this.lbSelectTitle5.Visible = false;
			this.lbSelectTitle4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle4
			// 
			this.lbSelectTitle4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle4.Name = "lbSelectTitle4";
			this.lbSelectTitle4.TabIndex = 45;
			this.lbSelectTitle4.Text = "HZM";
			this.lbSelectTitle4.Visible = false;
			this.lbSelectTitle2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle2
			// 
			this.lbSelectTitle2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSelectTitle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSelectTitle2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSelectTitle2.Name = "lbSelectTitle2";
			this.lbSelectTitle2.TabIndex = 44;
			this.lbSelectTitle2.Text = "REG";
			this.lbSelectTitle2.Visible = false;
			this.Shape3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape3.Enabled = false;
			this.Shape3.Name = "Shape3";
			this.Shape3.Visible = true;
			this.lbVacBankOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVacBankOpen
			// 
			this.lbVacBankOpen.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVacBankOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVacBankOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbVacBankOpen.Name = "lbVacBankOpen";
			this.lbVacBankOpen.TabIndex = 72;
			this.lbVacOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVacOpen
			// 
			this.lbVacOpen.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVacOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVacOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbVacOpen.Name = "lbVacOpen";
			this.lbVacOpen.TabIndex = 29;
			this.Shape2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape2.Enabled = false;
			this.Shape2.Name = "Shape2";
			this.Shape2.Visible = true;
			this.cmdNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNotes
			// 
			this.cmdNotes.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNotes.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNotes.Name = "cmdNotes";
			this.cmdNotes.TabIndex = 100;
			this.cmdNotes.Text = "Notes";
			this.cmdPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPhone
			// 
			this.cmdPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPhone.Name = "cmdPhone";
			this.cmdPhone.TabIndex = 99;
			this.cmdPhone.Text = "Update Phone(s)";
			this.cmdAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddress
			// 
			this.cmdAddress.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddress.Name = "cmdAddress";
			this.cmdAddress.TabIndex = 98;
			this.cmdAddress.Text = "Update Address(es)";
			this.cmdContacts = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdContacts
			// 
			this.cmdContacts.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdContacts.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdContacts.Name = "cmdContacts";
			this.cmdContacts.TabIndex = 97;
			this.cmdContacts.Text = "Update Contact(s)";
			this.cmdAvailable = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAvailable
			// 
			this.cmdAvailable.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAvailable.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAvailable.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAvailable.Name = "cmdAvailable";
			this.cmdAvailable.TabIndex = 96;
			this.cmdAvailable.Text = "Manage Available To Work Days";
			this.cmdAvailable.Visible = false;
			this.chkRecert = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkRecert.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.chkRecert.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkRecert.Enabled = true;
			this.chkRecert.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkRecert.ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			this.chkRecert.Name = "chkRecert";
			this.chkRecert.TabIndex = 94;
			this.chkRecert.Text = "PM Recert Skills";
			this.chkRecert.Visible = false;
			this.cmdCallBack = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCallBack
			// 
			this.cmdCallBack.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCallBack.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCallBack.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCallBack.Name = "cmdCallBack";
			this.cmdCallBack.TabIndex = 91;
			this.cmdCallBack.Text = "Change Callback #";
			this.cmdCallBack.Visible = false;
			this.cmdReqTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReqTransfer
			// 
			this.cmdReqTransfer.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReqTransfer.Enabled = false;
			this.cmdReqTransfer.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdReqTransfer.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReqTransfer.Name = "cmdReqTransfer";
			this.cmdReqTransfer.TabIndex = 87;
			this.cmdReqTransfer.Text = "Request Transfer";
			this.cmdRequestVAC = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRequestVAC
			// 
			this.cmdRequestVAC.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRequestVAC.Enabled = false;
			this.cmdRequestVAC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRequestVAC.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRequestVAC.Name = "cmdRequestVAC";
			this.cmdRequestVAC.TabIndex = 83;
			this.cmdRequestVAC.Text = "Request Vacation";
			this.cmdAdjustHOLMax = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdjustHOLMax
			// 
			this.cmdAdjustHOLMax.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdjustHOLMax.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdjustHOLMax.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdjustHOLMax.Name = "cmdAdjustHOLMax";
			this.cmdAdjustHOLMax.TabIndex = 82;
			this.cmdAdjustHOLMax.Text = "Change HOL Max";
			this.cmdSchedReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSchedReport
			// 
			this.cmdSchedReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSchedReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSchedReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSchedReport.Name = "cmdSchedReport";
			this.cmdSchedReport.TabIndex = 75;
			this.cmdSchedReport.Text = "Sched &Report";
			this.cmdTimeCard = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdTimeCard
			// 
			this.cmdTimeCard.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdTimeCard.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdTimeCard.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdTimeCard.Name = "cmdTimeCard";
			this.cmdTimeCard.TabIndex = 74;
			this.cmdTimeCard.Text = "&Time Card";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 1;
			this.cmdPrint.Text = "&Leave Report";
			this.cmdSenority = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSenority
			// 
			this.cmdSenority.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSenority.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSenority.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSenority.Name = "cmdSenority";
			this.cmdSenority.TabIndex = 23;
			this.cmdSenority.Text = "&Seniority Ranking";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 32;
			this.cmdClose.Text = "&Close";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 61;
			this.cmdUpdate.Text = "&Update";
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 60;
			this.cmdDelete.Text = "&Delete";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 59;
			this.cmdAdd.Text = "&Add";
			this.chkSCKflag = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkSCKflag.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.chkSCKflag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkSCKflag.Enabled = true;
			this.chkSCKflag.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkSCKflag.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkSCKflag.Name = "chkSCKflag";
			this.chkSCKflag.TabIndex = 88;
			this.chkSCKflag.Text = "Instead of SCK Leave";
			this.chkSCKflag.Visible = true;
			this.calSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			// 
			// calSched
			// 
			this.calSched.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 6.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calSched.Name = "calSched";
			this.calSched.TabIndex = 42;
			this.calSched.Width = 449;
			this.Text = "Individual Leave Scheduling";
			this.FirstTime = 0;
			this.chkAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkAM.Enabled = true;
			this.chkAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkAM.Name = "chkAM";
			this.chkAM.TabIndex = 39;
			this.chkAM.Text = "AM";
			this.chkAM.Visible = true;
			this.chkPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkPM.Enabled = true;
			this.chkPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkPM.Name = "chkPM";
			this.chkPM.TabIndex = 40;
			this.chkPM.Text = "PM";
			this.chkPM.Visible = true;
			this.SkipProcess = 0;
			this.NoteFlag = false;
			this.TrdFlag = false;
			this.OTFlag = false;
			this.BankFlag = false;
			this.TotMil1 = 0;
			this.TotMil2 = 0;
			this.TotKel = 0;
			this.TotHolOverride = 0;
			this.bUseNewMILMAX = false;
			this.bBothMILMAX = false;
			optLeaveType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(9);
			optLeaveType[8] = _optLeaveType_8;
			optLeaveType[7] = _optLeaveType_7;
			optLeaveType[6] = _optLeaveType_6;
			optLeaveType[5] = _optLeaveType_5;
			optLeaveType[4] = _optLeaveType_4;
			optLeaveType[3] = _optLeaveType_3;
			optLeaveType[2] = _optLeaveType_2;
			optLeaveType[1] = _optLeaveType_1;
			optLeaveType[0] = _optLeaveType_0;
			optLeaveType[8].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[8].Checked = false;
			optLeaveType[8].Enabled = true;
			optLeaveType[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[8].Name = "_optLeaveType_8";
			optLeaveType[8].TabIndex = 95;
			optLeaveType[8].Text = "Unsched Debit";
			optLeaveType[8].Visible = true;
			optLeaveType[7].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[7].Checked = false;
			optLeaveType[7].Enabled = true;
			optLeaveType[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[7].Name = "_optLeaveType_7";
			optLeaveType[7].TabIndex = 93;
			optLeaveType[7].Text = "PTO";
			optLeaveType[7].Visible = true;
			optLeaveType[6].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[6].Checked = false;
			optLeaveType[6].Enabled = true;
			optLeaveType[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[6].Name = "_optLeaveType_6";
			optLeaveType[6].TabIndex = 73;
			optLeaveType[6].Text = "VAC Bank";
			optLeaveType[6].Visible = true;
			optLeaveType[5].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[5].Checked = false;
			optLeaveType[5].Enabled = true;
			optLeaveType[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[5].Name = "_optLeaveType_5";
			optLeaveType[5].TabIndex = 68;
			optLeaveType[5].Text = "Regular ";
			optLeaveType[5].Visible = true;
			optLeaveType[4].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[4].Checked = false;
			optLeaveType[4].Enabled = true;
			optLeaveType[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[4].Name = "_optLeaveType_4";
			optLeaveType[4].TabIndex = 38;
			optLeaveType[4].Text = "Debit ";
			optLeaveType[4].Visible = true;
			optLeaveType[3].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[3].Checked = false;
			optLeaveType[3].Enabled = true;
			optLeaveType[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[3].Name = "_optLeaveType_3";
			optLeaveType[3].TabIndex = 37;
			optLeaveType[3].Text = "Other";
			optLeaveType[3].Visible = true;
			optLeaveType[2].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[2].Checked = false;
			optLeaveType[2].Enabled = true;
			optLeaveType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[2].Name = "_optLeaveType_2";
			optLeaveType[2].TabIndex = 36;
			optLeaveType[2].Text = "Military Leave";
			optLeaveType[2].Visible = true;
			optLeaveType[1].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[1].Checked = false;
			optLeaveType[1].Enabled = true;
			optLeaveType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[1].Name = "_optLeaveType_1";
			optLeaveType[1].TabIndex = 35;
			optLeaveType[1].Text = "Holiday";
			optLeaveType[1].Visible = true;
			optLeaveType[0].BackColor = UpgradeHelpers.Helpers.Color.Silver;
			optLeaveType[0].Checked = true;
			optLeaveType[0].Enabled = true;
			optLeaveType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optLeaveType[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			optLeaveType[0].Name = "_optLeaveType_0";
			optLeaveType[0].TabIndex = 34;
			optLeaveType[0].Text = "Vacation";
			optLeaveType[0].Visible = true;
			this.Name = "PTSProject.frmIndSched";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calLeaveDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLeaveType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecEvent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCallBackNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMILInfo { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFCCam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFCCpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVacation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVacBank { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbKelOpen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbKelly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbKellyTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBATpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBATam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalDebits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPos { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBatt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDebit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCOThire { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbZip { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTFDhire { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMilOpen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHolOpen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMilitary { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel LeaveTot { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHoliday { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMRNpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHZMpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPMpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPMam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMRNam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHZMam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle2 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVacBankOpen { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVacOpen { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdContacts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkRecert { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCallBack { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReqTransfer { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRequestVAC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdjustHOLMax { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSchedReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdTimeCard { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSenority { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSCKflag { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calSched { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SkipProcess { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NoteFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean TrdFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean OTFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean BankFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single TotMil1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single TotMil2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single TotKel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Single TotHolOverride { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bUseNewMILMAX { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bBothMILMAX { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optLeaveType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}