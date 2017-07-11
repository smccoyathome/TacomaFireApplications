using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.dlgFDCares))]
	public class dlgFDCaresViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Please explain reasons for patient referral";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 3;
			this.CancelButton_Renamed.Text = "Cancel";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.Text = "FDCares Referral";
			this.txtReferComment = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.txtReferComment.Enabled = true;
			this.txtReferComment.Name = "txtReferComment";
			this.txtReferComment.TabIndex = 0;
			this.Name = "TFDIncident.dlgFDCares";
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox txtReferComment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}