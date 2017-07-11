using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgSpecialAssign))]
	public class dlgSpecialAssignViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this._optType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.calStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calStart.Name = "calStart";
			this.calStart.TabIndex = 5;
			this.calStart.Value = System.DateTime.Today;
			this.calStart.Visible = false;
			this.calEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calEnd.Name = "calEnd";
			this.calEnd.TabIndex = 6;
			this.calEnd.Visible = false;
			this.lbWarning = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWarning
			// 
			this.lbWarning.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbWarning.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWarning.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbWarning.Name = "lbWarning";
			this.lbWarning.TabIndex = 11;
			this.lbWarning.Text
			= "WARNING!!  This action will change the Employee's Schedule... this day forward until the end!!  The only way to restore it will be to adjust each scheduled day individually.";
			this.lbWarning.Visible = false;
			this.lbEnd = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnd
			// 
			this.lbEnd.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEnd.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.TabIndex = 10;
			this.lbEnd.Text = "End Date:           Last Date of Special Assignment";
			this.lbEnd.Visible = false;
			this.lbStart = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStart
			// 
			this.lbStart.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.lbStart.Name = "lbStart";
			this.lbStart.TabIndex = 9;
			this.lbStart.Text = "Special Assignment - Start Date:";
			this.lbStart.Visible = false;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 7;
			this.cmdOK.Text = "&OK";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "&Cancel";
			this.Text = "Schedule Special Assignment";
			this.chkBothShifts = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkBothShifts.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkBothShifts.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkBothShifts.Enabled = true;
			this.chkBothShifts.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkBothShifts.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 192);
			this.chkBothShifts.Name = "chkBothShifts";
			this.chkBothShifts.TabIndex = 4;
			this.chkBothShifts.Text = "Schedule Both AM an PM Shifts";
			this.chkBothShifts.Visible = false;
			optType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optType[2] = _optType_2;
			optType[1] = _optType_1;
			optType[0] = _optType_0;
			optType[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optType[2].Checked = false;
			optType[2].Enabled = true;
			optType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[2].Name = "_optType_2";
			optType[2].TabIndex = 3;
			optType[2].Text = "For the Rest of the Schedule";
			optType[2].Visible = true;
			optType[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optType[1].Checked = false;
			optType[1].Enabled = true;
			optType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[1].Name = "_optType_1";
			optType[1].TabIndex = 2;
			optType[1].Text = "For a Specified Date Range";
			optType[1].Visible = true;
			optType[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optType[0].Checked = true;
			optType[0].Enabled = true;
			optType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[0].Name = "_optType_0";
			optType[0].TabIndex = 1;
			optType[0].Text = "Today Only";
			optType[0].Visible = true;
			this.Name = "PTSProject.dlgSpecialAssign";
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_0 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWarning { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkBothShifts { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}