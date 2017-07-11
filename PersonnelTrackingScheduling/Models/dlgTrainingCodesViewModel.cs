using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgTrainingCodes))]
	public class dlgTrainingCodesViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboSpecificCodes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSpecificCodes
			// 
			this.cboSpecificCodes.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSpecificCodes.Enabled = true;
			this.cboSpecificCodes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSpecificCodes.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSpecificCodes.Name = "cboSpecificCodes";
			this.cboSpecificCodes.TabIndex = 4;
			this.cboSpecificCodes.Text = "cboSpecificCodes";
			this.cboSpecificCodes.Visible = true;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Search for...";
			this.cmdExpand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExpand
			// 
			this.cmdExpand.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExpand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdExpand.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExpand.Name = "cmdExpand";
			this.cmdExpand.TabIndex = 3;
			this.cmdExpand.Tag = "1";
			this.cmdExpand.Text = "Expand All";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 0;
			this.cmdExit.Text = "Exit";
			this.Text = "New Training Codes";
			this.tvwTraining = ctx.Resolve<UpgradeHelpers.BasicViewModels.TreeViewViewModel>();
			this.tvwTraining.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.tvwTraining.LabelEdit = true;
			this.tvwTraining.Name = "tvwTraining";
			this.tvwTraining.TabIndex = 1;
			this.Name = "PTSProject.dlgTrainingCodes";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecificCodes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExpand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TreeViewViewModel tvwTraining { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}