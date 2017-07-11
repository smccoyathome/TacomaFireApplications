using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPTSTrain))]
	public class frmPTSTrainViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboUnitList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnitList
			// 
			this.cboUnitList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUnitList.Enabled = true;
			this.cboUnitList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboUnitList.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.cboUnitList.Name = "cboUnitList";
			this.cboUnitList.TabIndex = 25;
			this.cboUnitList.Text = "cboUnitList";
			this.cboUnitList.Visible = true;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 255, 255);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 26;
			this.Label1.Text = "Note:  Select \"Oper\" for staff on Special Assignment...";
			this.lstUnitStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstUnitStaff
			// 
			this.lstUnitStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstUnitStaff.Enabled = true;
			this.lstUnitStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstUnitStaff.Name = "lstUnitStaff";
			this.lstUnitStaff.TabIndex = 22;
			this.lstUnitStaff.Visible = true;
			this.lstUnitStaff.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.cboAllStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllStaff
			// 
			this.cboAllStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllStaff.Enabled = true;
			this.cboAllStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAllStaff.Name = "cboAllStaff";
			this.cboAllStaff.TabIndex = 21;
			this.cboAllStaff.Text = "cboAllStaff";
			this.cboAllStaff.Visible = true;
			this.lstTrainStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrainStaff
			// 
			this.lstTrainStaff.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.lstTrainStaff.Enabled = true;
			this.lstTrainStaff.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lstTrainStaff.Name = "lstTrainStaff";
			this.lstTrainStaff.TabIndex = 20;
			this.lstTrainStaff.Visible = true;
			this.lstTrainStaff.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstSpecific = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSpecific
			// 
			this.lstSpecific.Name = "lstSpecific";
			this.lstSpecific.TabIndex = 3;
			this.cboHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHours
			// 
			this.cboHours.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.cboHours.Enabled = true;
			this.cboHours.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboHours.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHours.Name = "cboHours";
			this.cboHours.TabIndex = 4;
			this.cboHours.Text = "cboHours";
			this.cboHours.Visible = true;
			this.txtComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComments.Name = "txtComments";
			this.txtComments.TabIndex = 5;
			this.OptCat3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.OptCat3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.OptCat3.Checked = false;
			this.OptCat3.Enabled = true;
			this.OptCat3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OptCat3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.OptCat3.Name = "OptCat3";
			this.OptCat3.TabIndex = 33;
			this.OptCat3.Text = "Category III";
			this.OptCat3.Visible = true;
			this.OptCat2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.OptCat2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.OptCat2.Checked = false;
			this.OptCat2.Enabled = true;
			this.OptCat2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OptCat2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.OptCat2.Name = "OptCat2";
			this.OptCat2.TabIndex = 32;
			this.OptCat2.Text = "Category II";
			this.OptCat2.Visible = true;
			this.OptCat1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.OptCat1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.OptCat1.Checked = false;
			this.OptCat1.Enabled = true;
			this.OptCat1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OptCat1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.OptCat1.Name = "OptCat1";
			this.OptCat1.TabIndex = 31;
			this.OptCat1.Text = "Category I";
			this.OptCat1.Visible = true;
			this.OptCat4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.OptCat4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.OptCat4.Checked = false;
			this.OptCat4.Enabled = true;
			this.OptCat4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OptCat4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.OptCat4.Name = "OptCat4";
			this.OptCat4.TabIndex = 34;
			this.OptCat4.Text = "Category IV";
			this.OptCat4.Visible = true;
			this.optFail = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optFail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.optFail.Checked = false;
			this.optFail.Enabled = true;
			this.optFail.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optFail.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optFail.Name = "optFail";
			this.optFail.TabIndex = 37;
			this.optFail.Text = "Fail";
			this.optFail.Visible = true;
			this.optPass = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.optPass.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.optPass.Checked = true;
			this.optPass.Enabled = true;
			this.optPass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.optPass.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.optPass.Name = "optPass";
			this.optPass.TabIndex = 36;
			this.optPass.Text = "Pass";
			this.optPass.Visible = true;
			this._lbSubTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHours
			// 
			this.lbHours.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHours.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbHours.Name = "lbHours";
			this.lbHours.TabIndex = 11;
			this.lbHours.Text = "Hours Spent Training";
			this._lbSubTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSubTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbSaveMsg = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSaveMsg
			// 
			this.lbSaveMsg.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbSaveMsg.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSaveMsg.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.lbSaveMsg.Name = "lbSaveMsg";
			this.lbSaveMsg.TabIndex = 8;
			this.lbSaveMsg.Text = "Training Record(s) Saved";
			this.lbSaveMsg.Visible = false;
			this.Image1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.Image1.Enabled = true;
			this.Image1.Name = "Image1";
			this.Image1.Visible = true;
			this.calTrainDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calTrainDate.Name = "calTrainDate";
			this.calTrainDate.TabIndex = 38;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 24;
			this.cmdClear.Text = "Clear Fields";
			this._cmdAdd_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdAdd_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdAdd_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdRemove_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdRemove_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cboPrimary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboPrimary.Name = "cboPrimary";
			this.cboPrimary.TabIndex = 2;
			this.cboSecondary = ctx.Resolve<UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper>();
			this.cboSecondary.Name = "cboSecondary";
			this.cboSecondary.TabIndex = 1;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 7;
			this.cmdClose.Text = "Close";
			this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSave
			// 
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Enabled = false;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 6;
			this.cmdSave.Text = "Save";
			this.Text = "Field Training Tracker";
			this.NoLimitUpdate = false;
			this.PreventionOnly = false;
			this.FieldOnly = false;
			this.FirstTime = false;
			this.frmPassFail = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmPassFail
			// 
			this.frmPassFail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.frmPassFail.Enabled = true;
			this.frmPassFail.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmPassFail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmPassFail.Name = "frmPassFail";
			this.frmPassFail.TabIndex = 35;
			this.frmPassFail.Visible = false;
			this.chkInstructor = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkInstructor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.chkInstructor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkInstructor.Enabled = true;
			this.chkInstructor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkInstructor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkInstructor.Name = "chkInstructor";
			this.chkInstructor.TabIndex = 28;
			this.chkInstructor.Text = "Instructor";
			this.chkInstructor.Visible = true;
			this.chkProvider = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkProvider.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.chkProvider.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkProvider.Enabled = true;
			this.chkProvider.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkProvider.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkProvider.Name = "chkProvider";
			this.chkProvider.TabIndex = 29;
			this.chkProvider.Text = "Provider";
			this.chkProvider.Visible = true;
			this.frmProvInst = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmProvInst
			// 
			this.frmProvInst.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.frmProvInst.Enabled = true;
			this.frmProvInst.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmProvInst.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmProvInst.Name = "frmProvInst";
			this.frmProvInst.TabIndex = 27;
			this.frmProvInst.Visible = false;
			this.frmCategories = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmCategories
			// 
			this.frmCategories.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.frmCategories.Enabled = true;
			this.frmCategories.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmCategories.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmCategories.Name = "frmCategories";
			this.frmCategories.TabIndex = 30;
			this.frmCategories.Visible = false;
			this.lSpecificID = 0;
			cmdAdd = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(3);
			cmdAdd[0] = _cmdAdd_0;
			cmdAdd[1] = _cmdAdd_1;
			cmdAdd[2] = _cmdAdd_2;
			cmdAdd[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[0].Name = "_cmdAdd_0";
			cmdAdd[0].TabIndex = 19;
			cmdAdd[0].Text = ">";
			cmdAdd[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[1].Name = "_cmdAdd_1";
			cmdAdd[1].TabIndex = 18;
			cmdAdd[1].Text = ">>";
			cmdAdd[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdAdd[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdAdd[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdAdd[2].Name = "_cmdAdd_2";
			cmdAdd[2].TabIndex = 17;
			cmdAdd[2].Text = ">";
			cmdRemove = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(2);
			cmdRemove[0] = _cmdRemove_0;
			cmdRemove[1] = _cmdRemove_1;
			cmdRemove[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdRemove[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdRemove[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdRemove[0].Name = "_cmdRemove_0";
			cmdRemove[0].TabIndex = 16;
			cmdRemove[0].Text = "<";
			cmdRemove[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdRemove[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdRemove[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdRemove[1].Name = "_cmdRemove_1";
			cmdRemove[1].TabIndex = 15;
			cmdRemove[1].Text = "<<";
			lbSubTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbSubTitle[0] = _lbSubTitle_0;
			lbSubTitle[1] = _lbSubTitle_1;
			lbSubTitle[3] = _lbSubTitle_3;
			lbSubTitle[4] = _lbSubTitle_4;
			lbSubTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.White;
			lbSubTitle[0].Name = "_lbSubTitle_0";
			lbSubTitle[0].TabIndex = 13;
			lbSubTitle[0].Text = "Primary Training Type";
			lbSubTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.White;
			lbSubTitle[1].Name = "_lbSubTitle_1";
			lbSubTitle[1].TabIndex = 12;
			lbSubTitle[1].Text = "Secondary Training Type";
			lbSubTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.White;
			lbSubTitle[3].Name = "_lbSubTitle_3";
			lbSubTitle[3].TabIndex = 10;
			lbSubTitle[3].Text = "Specific Training ";
			lbSubTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSubTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.White;
			lbSubTitle[4].Name = "_lbSubTitle_4";
			lbSubTitle[4].TabIndex = 9;
			lbSubTitle[4].Text = "Comments";
			this.Name = "PTSProject.frmPTSTrain";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnitList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstUnitStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrainStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSpecific { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptCat3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptCat2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptCat1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel OptCat4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optFail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optPass { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSubTitle_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSaveMsg { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Image1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calTrainDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdAdd_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdRemove_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdRemove_1 { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboPrimary { get; set; }

		public virtual UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper cboSecondary { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NoLimitUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean PreventionOnly { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FieldOnly { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmPassFail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInstructor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkProvider { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmProvInst { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmCategories { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 lSpecificID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdAdd { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdRemove { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSubTitle { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}