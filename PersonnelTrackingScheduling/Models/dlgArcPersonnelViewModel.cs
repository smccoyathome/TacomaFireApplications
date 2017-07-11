using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgArcPersonnel))]
	public class dlgArcPersonnelViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComments.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComments.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComments.Name = "txtComments";
			this.txtComments.TabIndex = 3;
			this.txtComments.Visible = false;
			this.cboExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboExitType
			// 
			this.cboExitType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboExitType.Enabled = true;
			this.cboExitType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboExitType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboExitType.Name = "cboExitType";
			this.cboExitType.TabIndex = 2;
			this.cboExitType.Visible = false;
			this.txtExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExit.Name = "txtExit";
			this.txtExit.TabIndex = 1;
			this.txtExit.Visible = false;
			this.lbComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbComments
			// 
			this.lbComments.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbComments.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbComments.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbComments.Name = "lbComments";
			this.lbComments.TabIndex = 9;
			this.lbComments.Text = "Comments";
			this.lbComments.Visible = false;
			this.lbExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExitType
			// 
			this.lbExitType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExitType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExitType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbExitType.Name = "lbExitType";
			this.lbExitType.TabIndex = 8;
			this.lbExitType.Text = "Reason for Leaving";
			this.lbExitType.Visible = false;
			this.lbExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExit
			// 
			this.lbExit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbExit.Name = "lbExit";
			this.lbExit.TabIndex = 7;
			this.lbExit.Text = "Exit Date";
			this.lbExit.Visible = false;
			this.lbInstruct1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInstruct1
			// 
			this.lbInstruct1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInstruct1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbInstruct1.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbInstruct1.Name = "lbInstruct1";
			this.lbInstruct1.TabIndex = 6;
			this.lbInstruct1.Text = "Changing This Employees Status to Inactive will Archive all Personnel Records and remove all future Schedule and Leave Records - Click OK to continue or Cancel to Quit";
			this.lbInstruct2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInstruct2
			// 
			this.lbInstruct2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInstruct2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbInstruct2.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbInstruct2.Name = "lbInstruct2";
			this.lbInstruct2.TabIndex = 5;
			this.lbInstruct2.Text = "Please enter Employee's Exit Date,             Reason for Leaving and any desired Comments";
			this.lbInstruct2.Visible = false;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
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
			this.Text = "Archive Personnel Records";
			this.FirstTime = 0;
			this.Name = "PTSProject.dlgArcPersonnel";
			cboExitType.Items.Add("Retirement");
			cboExitType.Items.Add("Transfer");
			cboExitType.Items.Add("Resignation");
			cboExitType.Items.Add("Termination");
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInstruct1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInstruct2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}