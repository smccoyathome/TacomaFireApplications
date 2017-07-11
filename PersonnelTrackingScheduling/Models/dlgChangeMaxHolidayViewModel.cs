using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgChangeMaxHoliday))]
	public class dlgChangeMaxHolidayViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtTotal = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTotal.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTotal.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtTotal.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.TabIndex = 0;
			this.txtTotal.Text = "txtTotal";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "New Total:";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 128, 128);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Change the Holiday Max total for:";
			this.lblEmployeeName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmployeeName
			// 
			this.lblEmployeeName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.lblEmployeeName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblEmployeeName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.lblEmployeeName.Name = "lblEmployeeName";
			this.lblEmployeeName.TabIndex = 3;
			this.lblEmployeeName.Text = "lblEmployeeName";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 2;
			this.CancelButton_Renamed.Text = "Cancel";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "Done";
			this.Text = "Change Holiday Max Totals";
			this.Name = "PTSProject.dlgChangeMaxHoliday";
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTotal { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmployeeName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}