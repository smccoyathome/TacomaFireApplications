using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmNotification))]
	public class frmNotificationViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.lbMessageText = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMessageText
			// 
			this.lbMessageText.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbMessageText.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbMessageText.Name = "lbMessageText";
			this.lbMessageText.TabIndex = 5;
			this.lbMessageText.Text = "lbMessageText";
			this.lbDateMessageCreated = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDateMessageCreated
			// 
			this.lbDateMessageCreated.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbDateMessageCreated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
			this.lbDateMessageCreated.Name = "lbDateMessageCreated";
			this.lbDateMessageCreated.TabIndex = 4;
			this.lbDateMessageCreated.Text = "lbDateMessageCreated";
			this.lbNote1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNote1
			// 
			this.lbNote1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNote1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbNote1.Name = "lbNote1";
			this.lbNote1.TabIndex = 3;
			this.lbNote1.Text = "Date Message Created:";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "You Have Received The Following Notification Messages:";
			this.cmdNext = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNext
			// 
			this.cmdNext.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNext.Enabled = false;
			this.cmdNext.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNext.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.TabIndex = 2;
			this.cmdNext.Text = "Next";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 0;
			this.cmdExit.Text = "Exit";
			this.Text = "IRS Notification System";
			this.Name = "TFDIncident.frmNotification";
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMessageText { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDateMessageCreated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNote1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNext { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}