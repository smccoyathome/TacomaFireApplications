using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAddImmunizations))]
	public class frmAddImmunizationsViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.optNegative = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optNegative.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optNegative.Checked = true;
			this.optNegative.Enabled = true;
			this.optNegative.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optNegative.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.optNegative.Name = "optNegative";
			this.optNegative.TabIndex = 20;
			this.optNegative.Text = "Negative";
			this.optNegative.Visible = true;
			this.optPositive = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optPositive.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optPositive.Checked = false;
			this.optPositive.Enabled = true;
			this.optPositive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optPositive.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.optPositive.Name = "optPositive";
			this.optPositive.TabIndex = 19;
			this.optPositive.Text = "Positive";
			this.optPositive.Visible = true;
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboType.Enabled = true;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 14;
			this.cboType.Text = "cboType";
			this.cboType.Visible = true;
			this.txtComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComments.Name = "txtComments";
			this.txtComments.TabIndex = 11;
			this.dteShotDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteShotDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.dteShotDate.MinDate = System.DateTime.Parse("1980/1/1");
			this.dteShotDate.Name = "dteShotDate";
			this.dteShotDate.TabIndex = 17;
			this.dteShotDate.Visible = false;
			this.lbSaveMsg = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSaveMsg
			// 
			this.lbSaveMsg.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSaveMsg.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSaveMsg.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.lbSaveMsg.Name = "lbSaveMsg";
			this.lbSaveMsg.TabIndex = 28;
			this.lbSaveMsg.Text = "Record(s) Saved";
			this.lbSaveMsg.Visible = false;
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 22;
			this.Label14.Text = "Immunization Type";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Comments";
			this.lstUnitStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstUnitStaff
			// 
			this.lstUnitStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstUnitStaff.Enabled = true;
			this.lstUnitStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstUnitStaff.Name = "lstUnitStaff";
			this.lstUnitStaff.TabIndex = 9;
			this.lstUnitStaff.Visible = true;
			this.lstUnitStaff.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.cboAllStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllStaff
			// 
			this.cboAllStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllStaff.Enabled = true;
			this.cboAllStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAllStaff.Name = "cboAllStaff";
			this.cboAllStaff.TabIndex = 8;
			this.cboAllStaff.Text = "cboAllStaff";
			this.cboAllStaff.Visible = true;
			this.lstSelectedStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSelectedStaff
			// 
			this.lstSelectedStaff.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 128, 255);
			this.lstSelectedStaff.Enabled = true;
			this.lstSelectedStaff.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lstSelectedStaff.Name = "lstSelectedStaff";
			this.lstSelectedStaff.TabIndex = 7;
			this.lstSelectedStaff.Visible = true;
			this.lstSelectedStaff.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.opt183.Checked = false;
			this.opt183.Enabled = true;
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 39;
			this.opt183.Text = "Batt 3";
			this.opt183.Visible = true;
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optAll.Checked = false;
			this.optAll.Enabled = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 37;
			this.optAll.Text = "ALL";
			this.optAll.Visible = true;
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.opt182.Checked = false;
			this.opt182.Enabled = true;
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 36;
			this.opt182.Text = "Batt 2";
			this.opt182.Visible = true;
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.opt181.Checked = false;
			this.opt181.Enabled = true;
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 35;
			this.opt181.Text = "Batt 1";
			this.opt181.Visible = true;
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optD.Checked = false;
			this.optD.Enabled = true;
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optD.Name = "optD";
			this.optD.TabIndex = 33;
			this.optD.Text = "Shift D";
			this.optD.Visible = true;
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optC.Checked = false;
			this.optC.Enabled = true;
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optC.Name = "optC";
			this.optC.TabIndex = 32;
			this.optC.Text = "Shift C";
			this.optC.Visible = true;
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optB.Checked = false;
			this.optB.Enabled = true;
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optB.Name = "optB";
			this.optB.TabIndex = 31;
			this.optB.Text = "Shift B";
			this.optB.Visible = true;
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.optA.Checked = false;
			this.optA.Enabled = true;
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optA.Name = "optA";
			this.optA.TabIndex = 30;
			this.optA.Text = "Shift A";
			this.optA.Visible = true;
			this.cboUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnit
			// 
			this.cboUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUnit.Enabled = true;
			this.cboUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 26;
			this.cboUnit.Text = "cboUnit";
			this.cboUnit.Visible = true;
			this.cboAssignmentCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAssignmentCode
			// 
			this.cboAssignmentCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAssignmentCode.Enabled = true;
			this.cboAssignmentCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAssignmentCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAssignmentCode.Name = "cboAssignmentCode";
			this.cboAssignmentCode.TabIndex = 24;
			this.cboAssignmentCode.Text = "cboAssignmentCode";
			this.cboAssignmentCode.Visible = true;
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cmdAddRecord = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddRecord
			// 
			this.cmdAddRecord.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddRecord.Enabled = false;
			this.cmdAddRecord.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddRecord.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddRecord.Name = "cmdAddRecord";
			this.cmdAddRecord.TabIndex = 16;
			this.cmdAddRecord.Tag = "1";
			this.cmdAddRecord.Text = "Add";
			this.cmdNewRecord = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewRecord
			// 
			this.cmdNewRecord.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewRecord.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNewRecord.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewRecord.Name = "cmdNewRecord";
			this.cmdNewRecord.TabIndex = 15;
			this.cmdNewRecord.Text = "New Record";
			this.chkImmuneDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkImmuneDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkImmuneDate.Enabled = true;
			this.chkImmuneDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkImmuneDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.chkImmuneDate.Name = "chkImmuneDate";
			this.chkImmuneDate.TabIndex = 13;
			this.chkImmuneDate.Text = "Immunization Date";
			this.chkImmuneDate.Visible = true;
			this.chkResults = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkResults.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkResults.Enabled = true;
			this.chkResults.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkResults.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkResults.Name = "chkResults";
			this.chkResults.TabIndex = 12;
			this.chkResults.Text = "Results";
			this.chkResults.Visible = true;
			this._cmdAdd_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdAdd_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdAdd_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdRemove_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdRemove_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 38;
			this.cmdClear.Text = "Clear Selected Staff Fields / Filters";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 23;
			this.cmdClose.Text = "Close";
			this.Text = "Add Immunizations";
			this.CurrBatt = "";
			this.CurrUnit = "";
			this.CurrShift = "";
			this.CurrGroup = "";
			this.frmResults = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmResults
			// 
			this.frmResults.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.frmResults.Enabled = true;
			this.frmResults.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmResults.Name = "frmResults";
			this.frmResults.TabIndex = 18;
			this.frmResults.Visible = false;
			cmdAdd = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(3);
			cmdAdd[0] = _cmdAdd_0;
			cmdAdd[1] = _cmdAdd_1;
			cmdAdd[2] = _cmdAdd_2;
			cmdAdd[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[0].Name = "_cmdAdd_0";
			cmdAdd[0].TabIndex = 6;
			cmdAdd[0].Text = ">";
			cmdAdd[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[1].Name = "_cmdAdd_1";
			cmdAdd[1].TabIndex = 5;
			cmdAdd[1].Text = ">>";
			cmdAdd[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[2].Name = "_cmdAdd_2";
			cmdAdd[2].TabIndex = 4;
			cmdAdd[2].Text = ">";
			this.FirstTime = false;
			cmdRemove = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(2);
			cmdRemove[0] = _cmdRemove_0;
			cmdRemove[1] = _cmdRemove_1;
			cmdRemove[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdRemove[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdRemove[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdRemove[0].Name = "_cmdRemove_0";
			cmdRemove[0].TabIndex = 3;
			cmdRemove[0].Text = "<";
			cmdRemove[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdRemove[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdRemove[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdRemove[1].Name = "_cmdRemove_1";
			cmdRemove[1].TabIndex = 2;
			cmdRemove[1].Text = "<<";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label3[0] = _Label3_0;
			Label3[1] = _Label3_1;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 128);
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 27;
			Label3[0].Text = "Select by Unit";
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 128);
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 25;
			Label3[1].Text = "Select by Group Code";
			this.Name = "PTSProject.frmAddImmunizations";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optNegative { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optPositive { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComments { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteShotDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSaveMsg { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstUnitStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSelectedStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAssignmentCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddRecord { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewRecord { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkImmuneDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkResults { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdRemove_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdRemove_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrGroup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmResults { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdAdd { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdRemove { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}