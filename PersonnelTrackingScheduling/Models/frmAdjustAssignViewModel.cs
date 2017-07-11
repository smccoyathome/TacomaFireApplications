using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAdjustAssign))]
	public class frmAdjustAssignViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this._opbEmp_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._opbEmp_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._opbEmp_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._opbEmp_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._opbEmp_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._opbEmp_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lbShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbShift
			// 
			this.lbShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbShift.Name = "lbShift";
			this.lbShift.TabIndex = 12;
			this.lbShift.Text = "lbShift";
			this.lbPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPosition
			// 
			this.lbPosition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPosition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbPosition.Name = "lbPosition";
			this.lbPosition.TabIndex = 11;
			this.lbPosition.Text = "lbPosition";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 10;
			this.lbUnit.Text = "lbUnit";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Select Active Employee for this Position";
			this.cmdDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDone
			// 
			this.cmdDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.TabIndex = 1;
			this.cmdDone.Text = "Done";
			this.Text = "Adjust Assignment Status";
			this.CurrentAssignment = 0;
			opbEmp = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(6);
			opbEmp[5] = _opbEmp_5;
			opbEmp[4] = _opbEmp_4;
			opbEmp[3] = _opbEmp_3;
			opbEmp[2] = _opbEmp_2;
			opbEmp[1] = _opbEmp_1;
			opbEmp[0] = _opbEmp_0;
			opbEmp[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[5].Checked = false;
			opbEmp[5].Enabled = true;
			opbEmp[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[5].Name = "_opbEmp_5";
			opbEmp[5].TabIndex = 8;
			opbEmp[5].Text = "Option1";
			opbEmp[5].Visible = false;
			opbEmp[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[4].Checked = false;
			opbEmp[4].Enabled = true;
			opbEmp[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[4].Name = "_opbEmp_4";
			opbEmp[4].TabIndex = 7;
			opbEmp[4].Text = "Option1";
			opbEmp[4].Visible = false;
			opbEmp[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[3].Checked = false;
			opbEmp[3].Enabled = true;
			opbEmp[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[3].Name = "_opbEmp_3";
			opbEmp[3].TabIndex = 6;
			opbEmp[3].Text = "Option1";
			opbEmp[3].Visible = false;
			opbEmp[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[2].Checked = false;
			opbEmp[2].Enabled = true;
			opbEmp[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[2].Name = "_opbEmp_2";
			opbEmp[2].TabIndex = 5;
			opbEmp[2].Text = "Option1";
			opbEmp[2].Visible = false;
			opbEmp[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[1].Checked = false;
			opbEmp[1].Enabled = true;
			opbEmp[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[1].Name = "_opbEmp_1";
			opbEmp[1].TabIndex = 4;
			opbEmp[1].Text = "Option1";
			opbEmp[1].Visible = false;
			opbEmp[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			opbEmp[0].Checked = false;
			opbEmp[0].Enabled = true;
			opbEmp[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			opbEmp[0].Name = "_opbEmp_0";
			opbEmp[0].TabIndex = 3;
			opbEmp[0].Text = "Option1";
			opbEmp[0].Visible = false;
			this.CurrentActive = 0;
			this.Name = "PTSProject.frmAdjustAssign";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _opbEmp_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDone { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrentAssignment { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> opbEmp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrentActive { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}