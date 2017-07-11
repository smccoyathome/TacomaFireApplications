using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTCEdit))]
	public class frmTCEditViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var _chkSCKFlag_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSCKFlag_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._cboLeaveAA_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeaveAA_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAAType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.txtNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNote.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.txtNote.Enabled = false;
			this.txtNote.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNote.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.txtNote.Name = "txtNote";
			this.txtNote.TabIndex = 0;
			this.txtNote.Text = "txtNote";
			this.txtNote.Visible = false;
			this._txtHours_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtHours_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboStep_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboStep_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtHours_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboStep_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboJobCode_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboLeave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboKOT_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._Label3_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbWarn = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWarn
			// 
			this.lbWarn.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWarn.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWarn.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbWarn.Name = "lbWarn";
			this.lbWarn.TabIndex = 67;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 66;
			this.Label4.Text = "Checked >> means KOT is used in place of SCK Leave";
			this._Line1_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDate
			// 
			this.lbDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			this.lbDate.Name = "lbDate";
			this.lbDate.TabIndex = 64;
			this.lbDate.Text = "lbDate";
			this.lbEmpName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpName
			// 
			this.lbEmpName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEmpName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmpName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			this.lbEmpName.Name = "lbEmpName";
			this.lbEmpName.TabIndex = 63;
			this.lbEmpName.Text = "lbEmpName";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 62;
			this.Label2.Text = "Date:";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 61;
			this.Label1.Text = "Employee:";
			this._Label3_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cmdSchedule = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSchedule
			// 
			this.cmdSchedule.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSchedule.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSchedule.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSchedule.Name = "cmdSchedule";
			this.cmdSchedule.TabIndex = 93;
			this.cmdSchedule.Text = "&View Schedule Detail";
			this.cmdDeleteNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDeleteNotes
			// 
			this.cmdDeleteNotes.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDeleteNotes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDeleteNotes.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDeleteNotes.Name = "cmdDeleteNotes";
			this.cmdDeleteNotes.TabIndex = 92;
			this.cmdDeleteNotes.Tag = "0";
			this.cmdDeleteNotes.Text = "Delete Note";
			this.cmdDeleteNotes.Visible = false;
			this.cmdNotes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNotes
			// 
			this.cmdNotes.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNotes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNotes.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNotes.Name = "cmdNotes";
			this.cmdNotes.TabIndex = 57;
			this.cmdNotes.Tag = "0";
			this.cmdNotes.Text = "New Note";
			this.cmdNotes.Visible = false;
			this.cmdTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdTrade
			// 
			this.cmdTrade.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdTrade.Enabled = false;
			this.cmdTrade.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdTrade.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdTrade.Name = "cmdTrade";
			this.cmdTrade.TabIndex = 60;
			this.cmdTrade.Text = "&View Trade Detail";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 59;
			this.cmdCancel.Text = "&Cancel";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Enabled = false;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 58;
			this.cmdClose.Text = "&Done";
			this.Text = "Time Card Selected Date Detail";
			cboKOT = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboKOT[7] = _cboKOT_7;
			cboKOT[6] = _cboKOT_6;
			cboKOT[5] = _cboKOT_5;
			cboKOT[4] = _cboKOT_4;
			cboKOT[3] = _cboKOT_3;
			cboKOT[2] = _cboKOT_2;
			cboKOT[1] = _cboKOT_1;
			cboKOT[0] = _cboKOT_0;
			cboKOT[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[7].Enabled = true;
			cboKOT[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[7].Name = "_cboKOT_7";
			cboKOT[7].TabIndex = 50;
			cboKOT[7].Visible = true;
			cboKOT[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[6].Enabled = true;
			cboKOT[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[6].Name = "_cboKOT_6";
			cboKOT[6].TabIndex = 43;
			cboKOT[6].Visible = true;
			cboKOT[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[5].Enabled = true;
			cboKOT[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[5].Name = "_cboKOT_5";
			cboKOT[5].TabIndex = 36;
			cboKOT[5].Visible = true;
			cboKOT[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[4].Enabled = true;
			cboKOT[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[4].Name = "_cboKOT_4";
			cboKOT[4].TabIndex = 29;
			cboKOT[4].Visible = true;
			cboKOT[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[3].Enabled = true;
			cboKOT[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[3].Name = "_cboKOT_3";
			cboKOT[3].TabIndex = 22;
			cboKOT[3].Visible = true;
			cboKOT[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[2].Enabled = true;
			cboKOT[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[2].Name = "_cboKOT_2";
			cboKOT[2].TabIndex = 15;
			cboKOT[2].Visible = true;
			cboKOT[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[1].Enabled = true;
			cboKOT[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[1].Name = "_cboKOT_1";
			cboKOT[1].TabIndex = 8;
			cboKOT[1].Visible = true;
			cboKOT[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboKOT[0].Enabled = true;
			cboKOT[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboKOT[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboKOT[0].Name = "_cboKOT_0";
			cboKOT[0].TabIndex = 1;
			cboKOT[0].Visible = true;
			cboAAType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboAAType[7] = _cboAAType_7;
			cboAAType[6] = _cboAAType_6;
			cboAAType[5] = _cboAAType_5;
			cboAAType[4] = _cboAAType_4;
			cboAAType[3] = _cboAAType_3;
			cboAAType[2] = _cboAAType_2;
			cboAAType[1] = _cboAAType_1;
			cboAAType[0] = _cboAAType_0;
			cboAAType[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[7].Enabled = true;
			cboAAType[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[7].Name = "_cboAAType_7";
			cboAAType[7].TabIndex = 51;
			cboAAType[7].Visible = true;
			cboAAType[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[6].Enabled = true;
			cboAAType[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[6].Name = "_cboAAType_6";
			cboAAType[6].TabIndex = 44;
			cboAAType[6].Visible = true;
			cboAAType[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[5].Enabled = true;
			cboAAType[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[5].Name = "_cboAAType_5";
			cboAAType[5].TabIndex = 37;
			cboAAType[5].Visible = true;
			cboAAType[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[4].Enabled = true;
			cboAAType[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[4].Name = "_cboAAType_4";
			cboAAType[4].TabIndex = 30;
			cboAAType[4].Visible = true;
			cboAAType[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[3].Enabled = true;
			cboAAType[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[3].Name = "_cboAAType_3";
			cboAAType[3].TabIndex = 23;
			cboAAType[3].Visible = true;
			cboAAType[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[2].Enabled = true;
			cboAAType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[2].Name = "_cboAAType_2";
			cboAAType[2].TabIndex = 16;
			cboAAType[2].Visible = true;
			cboAAType[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[1].Enabled = true;
			cboAAType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[1].Name = "_cboAAType_1";
			cboAAType[1].TabIndex = 9;
			cboAAType[1].Visible = true;
			cboAAType[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboAAType[0].Enabled = true;
			cboAAType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAAType[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAAType[0].Name = "_cboAAType_0";
			cboAAType[0].TabIndex = 2;
			cboAAType[0].Visible = true;
			cboLeave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboLeave[7] = _cboLeave_7;
			cboLeave[6] = _cboLeave_6;
			cboLeave[5] = _cboLeave_5;
			cboLeave[4] = _cboLeave_4;
			cboLeave[3] = _cboLeave_3;
			cboLeave[2] = _cboLeave_2;
			cboLeave[1] = _cboLeave_1;
			cboLeave[0] = _cboLeave_0;
			cboLeave[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[7].Enabled = true;
			cboLeave[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[7].Name = "_cboLeave_7";
			cboLeave[7].TabIndex = 52;
			cboLeave[7].Visible = true;
			cboLeave[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[6].Enabled = true;
			cboLeave[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[6].Name = "_cboLeave_6";
			cboLeave[6].TabIndex = 45;
			cboLeave[6].Visible = true;
			cboLeave[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[5].Enabled = true;
			cboLeave[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[5].Name = "_cboLeave_5";
			cboLeave[5].TabIndex = 38;
			cboLeave[5].Visible = true;
			cboLeave[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[4].Enabled = true;
			cboLeave[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[4].Name = "_cboLeave_4";
			cboLeave[4].TabIndex = 31;
			cboLeave[4].Visible = true;
			cboLeave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[3].Enabled = true;
			cboLeave[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[3].Name = "_cboLeave_3";
			cboLeave[3].TabIndex = 24;
			cboLeave[3].Visible = true;
			cboLeave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[2].Enabled = true;
			cboLeave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[2].Name = "_cboLeave_2";
			cboLeave[2].TabIndex = 17;
			cboLeave[2].Visible = true;
			cboLeave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[1].Enabled = true;
			cboLeave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[1].Name = "_cboLeave_1";
			cboLeave[1].TabIndex = 10;
			cboLeave[1].Visible = true;
			cboLeave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeave[0].Enabled = true;
			cboLeave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeave[0].Name = "_cboLeave_0";
			cboLeave[0].TabIndex = 3;
			cboLeave[0].Visible = true;
			cboLeaveAA = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboLeaveAA[7] = _cboLeaveAA_7;
			cboLeaveAA[6] = _cboLeaveAA_6;
			cboLeaveAA[5] = _cboLeaveAA_5;
			cboLeaveAA[4] = _cboLeaveAA_4;
			cboLeaveAA[3] = _cboLeaveAA_3;
			cboLeaveAA[2] = _cboLeaveAA_2;
			cboLeaveAA[1] = _cboLeaveAA_1;
			cboLeaveAA[0] = _cboLeaveAA_0;
			cboLeaveAA[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[7].Enabled = true;
			cboLeaveAA[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[7].Name = "_cboLeaveAA_7";
			cboLeaveAA[7].TabIndex = 53;
			cboLeaveAA[7].Visible = true;
			cboLeaveAA[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[6].Enabled = true;
			cboLeaveAA[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[6].Name = "_cboLeaveAA_6";
			cboLeaveAA[6].TabIndex = 46;
			cboLeaveAA[6].Visible = true;
			cboLeaveAA[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[5].Enabled = true;
			cboLeaveAA[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[5].Name = "_cboLeaveAA_5";
			cboLeaveAA[5].TabIndex = 39;
			cboLeaveAA[5].Visible = true;
			cboLeaveAA[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[4].Enabled = true;
			cboLeaveAA[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[4].Name = "_cboLeaveAA_4";
			cboLeaveAA[4].TabIndex = 32;
			cboLeaveAA[4].Visible = true;
			cboLeaveAA[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[3].Enabled = true;
			cboLeaveAA[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[3].Name = "_cboLeaveAA_3";
			cboLeaveAA[3].TabIndex = 25;
			cboLeaveAA[3].Visible = true;
			cboLeaveAA[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[2].Enabled = true;
			cboLeaveAA[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[2].Name = "_cboLeaveAA_2";
			cboLeaveAA[2].TabIndex = 18;
			cboLeaveAA[2].Visible = true;
			cboLeaveAA[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[1].Enabled = true;
			cboLeaveAA[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[1].Name = "_cboLeaveAA_1";
			cboLeaveAA[1].TabIndex = 11;
			cboLeaveAA[1].Visible = true;
			cboLeaveAA[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboLeaveAA[0].Enabled = true;
			cboLeaveAA[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboLeaveAA[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboLeaveAA[0].Name = "_cboLeaveAA_0";
			cboLeaveAA[0].TabIndex = 4;
			cboLeaveAA[0].Visible = true;
			cboJobCode = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboJobCode[7] = _cboJobCode_7;
			cboJobCode[6] = _cboJobCode_6;
			cboJobCode[5] = _cboJobCode_5;
			cboJobCode[4] = _cboJobCode_4;
			cboJobCode[3] = _cboJobCode_3;
			cboJobCode[2] = _cboJobCode_2;
			cboJobCode[1] = _cboJobCode_1;
			cboJobCode[0] = _cboJobCode_0;
			cboJobCode[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[7].Enabled = true;
			cboJobCode[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[7].Name = "_cboJobCode_7";
			cboJobCode[7].TabIndex = 54;
			cboJobCode[7].Visible = true;
			cboJobCode[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[6].Enabled = true;
			cboJobCode[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[6].Name = "_cboJobCode_6";
			cboJobCode[6].TabIndex = 47;
			cboJobCode[6].Visible = true;
			cboJobCode[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[5].Enabled = true;
			cboJobCode[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[5].Name = "_cboJobCode_5";
			cboJobCode[5].TabIndex = 40;
			cboJobCode[5].Visible = true;
			cboJobCode[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[4].Enabled = true;
			cboJobCode[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[4].Name = "_cboJobCode_4";
			cboJobCode[4].TabIndex = 33;
			cboJobCode[4].Visible = true;
			cboJobCode[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[3].Enabled = true;
			cboJobCode[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[3].Name = "_cboJobCode_3";
			cboJobCode[3].TabIndex = 26;
			cboJobCode[3].Visible = true;
			cboJobCode[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[2].Enabled = true;
			cboJobCode[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[2].Name = "_cboJobCode_2";
			cboJobCode[2].TabIndex = 19;
			cboJobCode[2].Visible = true;
			cboJobCode[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[1].Enabled = true;
			cboJobCode[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[1].Name = "_cboJobCode_1";
			cboJobCode[1].TabIndex = 12;
			cboJobCode[1].Visible = true;
			cboJobCode[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboJobCode[0].Enabled = true;
			cboJobCode[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboJobCode[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboJobCode[0].Name = "_cboJobCode_0";
			cboJobCode[0].TabIndex = 5;
			cboJobCode[0].Visible = true;
			this.DisplayNotes = false;
			this.Empid = "";
			this.StartDate = "";
			this.EndDate = "";
			chkSCKFlag = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkSCKFlag[7] = _chkSCKFlag_7;
			chkSCKFlag[6] = _chkSCKFlag_6;
			chkSCKFlag[5] = _chkSCKFlag_5;
			chkSCKFlag[4] = _chkSCKFlag_4;
			chkSCKFlag[3] = _chkSCKFlag_3;
			chkSCKFlag[2] = _chkSCKFlag_2;
			chkSCKFlag[1] = _chkSCKFlag_1;
			chkSCKFlag[0] = _chkSCKFlag_0;
			chkSCKFlag[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[7].Enabled = true;
			chkSCKFlag[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[7].Name = "_chkSCKFlag_7";
			chkSCKFlag[7].TabIndex = 101;
			chkSCKFlag[7].Text = "";
			chkSCKFlag[7].Visible = true;
			chkSCKFlag[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[6].Enabled = true;
			chkSCKFlag[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[6].Name = "_chkSCKFlag_6";
			chkSCKFlag[6].TabIndex = 100;
			chkSCKFlag[6].Text = "";
			chkSCKFlag[6].Visible = true;
			chkSCKFlag[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[5].Enabled = true;
			chkSCKFlag[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[5].Name = "_chkSCKFlag_5";
			chkSCKFlag[5].TabIndex = 99;
			chkSCKFlag[5].Text = "";
			chkSCKFlag[5].Visible = true;
			chkSCKFlag[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[4].Enabled = true;
			chkSCKFlag[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[4].Name = "_chkSCKFlag_4";
			chkSCKFlag[4].TabIndex = 98;
			chkSCKFlag[4].Text = "";
			chkSCKFlag[4].Visible = true;
			chkSCKFlag[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[3].Enabled = true;
			chkSCKFlag[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[3].Name = "_chkSCKFlag_3";
			chkSCKFlag[3].TabIndex = 97;
			chkSCKFlag[3].Text = "";
			chkSCKFlag[3].Visible = true;
			chkSCKFlag[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[2].Enabled = true;
			chkSCKFlag[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[2].Name = "_chkSCKFlag_2";
			chkSCKFlag[2].TabIndex = 96;
			chkSCKFlag[2].Text = "";
			chkSCKFlag[2].Visible = true;
			chkSCKFlag[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[1].Enabled = true;
			chkSCKFlag[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[1].Name = "_chkSCKFlag_1";
			chkSCKFlag[1].TabIndex = 95;
			chkSCKFlag[1].Text = "";
			chkSCKFlag[1].Visible = true;
			chkSCKFlag[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			chkSCKFlag[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSCKFlag[0].Enabled = true;
			chkSCKFlag[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkSCKFlag[0].Name = "_chkSCKFlag_0";
			chkSCKFlag[0].TabIndex = 94;
			chkSCKFlag[0].Text = "";
			chkSCKFlag[0].Visible = true;
			cboStep = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboStep[7] = _cboStep_7;
			cboStep[6] = _cboStep_6;
			cboStep[5] = _cboStep_5;
			cboStep[4] = _cboStep_4;
			cboStep[3] = _cboStep_3;
			cboStep[2] = _cboStep_2;
			cboStep[1] = _cboStep_1;
			cboStep[0] = _cboStep_0;
			cboStep[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[7].Enabled = true;
			cboStep[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[7].Name = "_cboStep_7";
			cboStep[7].TabIndex = 55;
			cboStep[7].Visible = true;
			cboStep[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[6].Enabled = true;
			cboStep[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[6].Name = "_cboStep_6";
			cboStep[6].TabIndex = 48;
			cboStep[6].Visible = true;
			cboStep[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[5].Enabled = true;
			cboStep[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[5].Name = "_cboStep_5";
			cboStep[5].TabIndex = 41;
			cboStep[5].Visible = true;
			cboStep[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[4].Enabled = true;
			cboStep[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[4].Name = "_cboStep_4";
			cboStep[4].TabIndex = 34;
			cboStep[4].Visible = true;
			cboStep[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[3].Enabled = true;
			cboStep[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[3].Name = "_cboStep_3";
			cboStep[3].TabIndex = 27;
			cboStep[3].Visible = true;
			cboStep[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[2].Enabled = true;
			cboStep[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[2].Name = "_cboStep_2";
			cboStep[2].TabIndex = 20;
			cboStep[2].Visible = true;
			cboStep[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[1].Enabled = true;
			cboStep[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[1].Name = "_cboStep_1";
			cboStep[1].TabIndex = 13;
			cboStep[1].Visible = true;
			cboStep[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboStep[0].Enabled = true;
			cboStep[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboStep[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboStep[0].Name = "_cboStep_0";
			cboStep[0].TabIndex = 6;
			cboStep[0].Visible = true;
			txtHours = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(8);
			txtHours[7] = _txtHours_7;
			txtHours[6] = _txtHours_6;
			txtHours[5] = _txtHours_5;
			txtHours[4] = _txtHours_4;
			txtHours[3] = _txtHours_3;
			txtHours[2] = _txtHours_2;
			txtHours[1] = _txtHours_1;
			txtHours[0] = _txtHours_0;
			txtHours[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[7].Name = "_txtHours_7";
			txtHours[7].TabIndex = 56;
			txtHours[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[6].Name = "_txtHours_6";
			txtHours[6].TabIndex = 49;
			txtHours[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[5].Name = "_txtHours_5";
			txtHours[5].TabIndex = 42;
			txtHours[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[4].Name = "_txtHours_4";
			txtHours[4].TabIndex = 35;
			txtHours[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[3].Name = "_txtHours_3";
			txtHours[3].TabIndex = 28;
			txtHours[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[2].Name = "_txtHours_2";
			txtHours[2].TabIndex = 21;
			txtHours[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[1].Name = "_txtHours_1";
			txtHours[1].TabIndex = 14;
			txtHours[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtHours[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtHours[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			txtHours[0].Name = "_txtHours_0";
			txtHours[0].TabIndex = 7;
			lbUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(8);
			lbUnit[7] = _lbUnit_7;
			lbUnit[6] = _lbUnit_6;
			lbUnit[5] = _lbUnit_5;
			lbUnit[4] = _lbUnit_4;
			lbUnit[3] = _lbUnit_3;
			lbUnit[2] = _lbUnit_2;
			lbUnit[1] = _lbUnit_1;
			lbUnit[0] = _lbUnit_0;
			lbUnit[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[7].Name = "_lbUnit_7";
			lbUnit[7].TabIndex = 75;
			lbUnit[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[6].Name = "_lbUnit_6";
			lbUnit[6].TabIndex = 74;
			lbUnit[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[5].Name = "_lbUnit_5";
			lbUnit[5].TabIndex = 73;
			lbUnit[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[4].Name = "_lbUnit_4";
			lbUnit[4].TabIndex = 72;
			lbUnit[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[3].Name = "_lbUnit_3";
			lbUnit[3].TabIndex = 71;
			lbUnit[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[2].Name = "_lbUnit_2";
			lbUnit[2].TabIndex = 70;
			lbUnit[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[1].Name = "_lbUnit_1";
			lbUnit[1].TabIndex = 69;
			lbUnit[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbUnit[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbUnit[0].Name = "_lbUnit_0";
			lbUnit[0].TabIndex = 68;
			lbPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(8);
			lbPosition[7] = _lbPosition_7;
			lbPosition[6] = _lbPosition_6;
			lbPosition[5] = _lbPosition_5;
			lbPosition[4] = _lbPosition_4;
			lbPosition[3] = _lbPosition_3;
			lbPosition[2] = _lbPosition_2;
			lbPosition[1] = _lbPosition_1;
			lbPosition[0] = _lbPosition_0;
			lbPosition[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[7].Name = "_lbPosition_7";
			lbPosition[7].TabIndex = 83;
			lbPosition[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[6].Name = "_lbPosition_6";
			lbPosition[6].TabIndex = 82;
			lbPosition[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[5].Name = "_lbPosition_5";
			lbPosition[5].TabIndex = 81;
			lbPosition[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[4].Name = "_lbPosition_4";
			lbPosition[4].TabIndex = 80;
			lbPosition[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[3].Name = "_lbPosition_3";
			lbPosition[3].TabIndex = 79;
			lbPosition[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[2].Name = "_lbPosition_2";
			lbPosition[2].TabIndex = 78;
			lbPosition[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[1].Name = "_lbPosition_1";
			lbPosition[1].TabIndex = 77;
			lbPosition[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			lbPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPosition[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbPosition[0].Name = "_lbPosition_0";
			lbPosition[0].TabIndex = 76;
			this.TotalLines = 0;
			this.UpdateFlag = 0;
			Line1 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			Line1[6] = _Line1_6;
			Line1[5] = _Line1_5;
			Line1[4] = _Line1_4;
			Line1[3] = _Line1_3;
			Line1[2] = _Line1_2;
			Line1[1] = _Line1_1;
			Line1[0] = _Line1_0;
			Line1[6].BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			Line1[6].Enabled = false;
			Line1[6].Name = "_Line1_6";
			Line1[6].Visible = true;
			Line1[5].BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			Line1[5].Enabled = false;
			Line1[5].Name = "_Line1_5";
			Line1[5].Visible = true;
			Line1[4].BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			Line1[4].Enabled = false;
			Line1[4].Name = "_Line1_4";
			Line1[4].Visible = true;
			Line1[3].BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			Line1[3].Enabled = false;
			Line1[3].Name = "_Line1_3";
			Line1[3].Visible = true;
			Line1[2].BackColor = UpgradeHelpers.Helpers.Color.Red;
			Line1[2].Enabled = false;
			Line1[2].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			Line1[2].Name = "_Line1_2";
			Line1[2].Text = "_Line1_2";
			Line1[2].Visible = true;
			Line1[1].BackColor = UpgradeHelpers.Helpers.Color.Red;
			Line1[1].Enabled = false;
			Line1[1].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			Line1[1].Name = "_Line1_1";
			Line1[1].Text = "_Line1_1";
			Line1[1].Visible = true;
			Line1[0].BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			Line1[0].Enabled = false;
			Line1[0].Name = "_Line1_0";
			Line1[0].Visible = true;
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(9);
			Label3[8] = _Label3_8;
			Label3[7] = _Label3_7;
			Label3[5] = _Label3_5;
			Label3[4] = _Label3_4;
			Label3[3] = _Label3_3;
			Label3[2] = _Label3_2;
			Label3[0] = _Label3_0;
			Label3[6] = _Label3_6;
			Label3[1] = _Label3_1;
			Label3[8].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[8].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[8].Name = "_Label3_8";
			Label3[8].TabIndex = 91;
			Label3[8].Text = "A/A Type";
			Label3[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[7].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[7].Name = "_Label3_7";
			Label3[7].TabIndex = 90;
			Label3[7].Text = "A/A Type";
			Label3[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[5].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[5].Name = "_Label3_5";
			Label3[5].TabIndex = 88;
			Label3[5].Text = "Hours";
			Label3[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[4].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[4].Name = "_Label3_4";
			Label3[4].TabIndex = 87;
			Label3[4].Text = "Step";
			Label3[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[3].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[3].Name = "_Label3_3";
			Label3[3].TabIndex = 86;
			Label3[3].Text = "Pay Upgrade";
			Label3[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[2].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[2].Name = "_Label3_2";
			Label3[2].TabIndex = 85;
			Label3[2].Text = "Leave";
			Label3[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 65;
			Label3[0].Text = "KOT";
			Label3[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[6].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[6].Name = "_Label3_6";
			Label3[6].TabIndex = 89;
			Label3[6].Text = "Unit";
			Label3[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 84;
			Label3[1].Text = "Position";
			this.Name = "PTSProject.frmTCEdit";
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeaveAA_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAAType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtHours_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboStep_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboJobCode_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboLeave_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboKOT_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWarn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSchedule { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDeleteNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNotes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboKOT { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboAAType { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboLeave { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboLeaveAA { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboJobCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean DisplayNotes { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String Empid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String StartDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String EndDate { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkSCKFlag { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboStep { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtHours { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbUnit { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPosition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalLines { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 UpdateFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line1 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public void OntxtHours_TextChanged()
		{
			if ( _txtHours_TextChanged != null )
				_txtHours_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHours_TextChanged;
	}

}