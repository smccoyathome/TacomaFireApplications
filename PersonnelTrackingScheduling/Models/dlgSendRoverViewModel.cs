using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgSendRover))]
	public class dlgSendRoverViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.lbTrade = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTrade
			// 
			this.lbTrade.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrade.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTrade.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
			this.lbTrade.Name = "lbTrade";
			this.lbTrade.TabIndex = 7;
			this.lbTrade.Text = "Confirm or Cancel Trade Employee Move";
			this.lbTrade.Visible = false;
			this.chkDebit = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkDebit.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkDebit.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkDebit.Enabled = true;
			this.chkDebit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkDebit.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.chkDebit.Name = "chkDebit";
			this.chkDebit.TabIndex = 6;
			this.chkDebit.Text = "Debit";
			this.chkDebit.Visible = true;
			this.chkRover = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkRover.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkRover.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkRover.Enabled = true;
			this.chkRover.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkRover.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.chkRover.Name = "chkRover";
			this.chkRover.TabIndex = 5;
			this.chkRover.Text = "Rover";
			this.chkRover.Visible = true;
			this.chkBoth = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkBoth.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkBoth.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkBoth.Enabled = true;
			this.chkBoth.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkBoth.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.chkBoth.Name = "chkBoth";
			this.chkBoth.TabIndex = 4;
			this.chkBoth.Text = "Both AM and PM Shifts";
			this.chkBoth.Visible = true;
			this.chkPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkPM.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkPM.Enabled = true;
			this.chkPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkPM.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.chkPM.Name = "chkPM";
			this.chkPM.TabIndex = 3;
			this.chkPM.Text = "PM";
			this.chkPM.Visible = true;
			this.chkAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAM.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAM.Enabled = true;
			this.chkAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAM.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.chkAM.Name = "chkAM";
			this.chkAM.TabIndex = 2;
			this.chkAM.Text = "AM";
			this.chkAM.Visible = true;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&OK";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 0;
			this.cmdCancel.Text = "&Cancel";
			this.Text = "Send to Battalion ";
			this.Name = "PTSProject.dlgSendRover";
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTrade { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDebit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkRover { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkBoth { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}