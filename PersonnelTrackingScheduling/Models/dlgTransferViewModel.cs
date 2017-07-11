using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgTransfer))]
	public class dlgTransferViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.calStartDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calStartDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calStartDate.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calStartDate.MinDate = System.DateTime.Parse("1997/1/1");
			this.calStartDate.Name = "calStartDate";
			this.calStartDate.TabIndex = 2;
			this.calEndDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calEndDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calEndDate.MaxDate = System.DateTime.Parse("2999/12/31");
			this.calEndDate.MinDate = System.DateTime.Parse("1997/1/1");
			this.calEndDate.Name = "calEndDate";
			this.calEndDate.TabIndex = 4;
			this.calEndDate.Visible = false;
			this.lbEndDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEndDate
			// 
			this.lbEndDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEndDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEndDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbEndDate.Name = "lbEndDate";
			this.lbEndDate.TabIndex = 5;
			this.lbEndDate.Text = "Transfer End Date";
			this.lbEndDate.Visible = false;
			this.lbStartDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStartDate
			// 
			this.lbStartDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStartDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStartDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbStartDate.Name = "lbStartDate";
			this.lbStartDate.TabIndex = 3;
			this.lbStartDate.Text = "Transfer Start Date";
			this.chkTemp = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkTemp.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkTemp.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkTemp.Enabled = true;
			this.chkTemp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkTemp.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkTemp.Name = "chkTemp";
			this.chkTemp.TabIndex = 6;
			this.chkTemp.Text = "Temporary Transfer?";
			this.chkTemp.Visible = true;
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "&Cancel";
			this.cmdDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDone
			// 
			this.cmdDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.TabIndex = 0;
			this.cmdDone.Text = "&Done";
			this.Text = "Transfer Information";
			this.Name = "PTSProject.dlgTransfer";
		}

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calStartDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calEndDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEndDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStartDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkTemp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDone { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}