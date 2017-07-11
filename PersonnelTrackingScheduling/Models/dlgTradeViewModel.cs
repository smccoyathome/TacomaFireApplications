using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgTrade))]
	public class dlgTradeViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboFullList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFullList
			// 
			this.cboFullList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFullList.Enabled = true;
			this.cboFullList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFullList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFullList.Name = "cboFullList";
			this.cboFullList.TabIndex = 1;
			this.cboFullList.Text = "cboFullList";
			this.cboFullList.Visible = true;
			this.lbAMPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAMPM
			// 
			this.lbAMPM.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAMPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbAMPM.Name = "lbAMPM";
			this.lbAMPM.TabIndex = 5;
			this.lbAMPM.Text = "Schedule Both AM and PM Shifts";
			this.lbAMPM.Visible = false;
			this.boxAMPM = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.boxAMPM.Enabled = false;
			this.boxAMPM.Name = "boxAMPM";
			this.boxAMPM.Visible = false;
			this.lbTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "Select New Working Employee";
			this.chkAMPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAMPM.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkAMPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAMPM.Enabled = true;
			this.chkAMPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.chkAMPM.Name = "chkAMPM";
			this.chkAMPM.TabIndex = 4;
			this.chkAMPM.Text = "Check1";
			this.chkAMPM.Visible = false;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "OK";
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCancel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCancel.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 0;
			this.cmdCancel.Text = "Cancel";
			this.Text = "Schedule Trade";
			this.Name = "PTSProject.dlgTrade";
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFullList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAMPM { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel boxAMPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAMPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}