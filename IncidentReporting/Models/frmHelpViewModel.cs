using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmHelp))]
	public class frmHelpViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtHelpText = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHelpText.Name = "txtHelpText";
			this.txtHelpText.TabIndex = 1;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 5;
			this.Label1.Text = "Select Help Topic to View";
			this.lbHelpTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHelpTitle
			// 
			this.lbHelpTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHelpTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHelpTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 0);
			this.lbHelpTitle.Name = "lbHelpTitle";
			this.lbHelpTitle.TabIndex = 0;
			this.lbHelpTitle.Text = "lbHelpTitle";
			this.tvHelpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.TreeViewViewModel>();
			this.tvHelpList.LabelEdit = true;
			this.tvHelpList.Name = "tvHelpList";
			this.tvHelpList.TabIndex = 4;
			this.cmdCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdCode.Name = "cmdCode";
			this.cmdCode.TabIndex = 2;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 3;
			this.Text = "IRS Help System";
			this.CurrentHelpID = 0;
			this.mNode = null;
			this.Name = "TFDIncident.frmHelp";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHelpText { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHelpTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TreeViewViewModel tvHelpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrentHelpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.BasicViewModels.TreeNodeViewModel mNode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}