using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmSecurity))]
	public class frmSecurityViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboSecurity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSecurity
			// 
			this.cboSecurity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSecurity.Enabled = true;
			this.cboSecurity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSecurity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSecurity.Name = "cboSecurity";
			this.cboSecurity.TabIndex = 8;
			this.cboSecurity.Visible = true;
			this.txtUserID = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtUserID.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtUserID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtUserID.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.TabIndex = 2;
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Enabled = true;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 0;
			this.cboEmpList.Text = "cboEmpList";
			this.cboEmpList.Visible = true;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 7;
			this.Label3.Text = "Security Clearance";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 6;
			this.lbName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbName
			// 
			this.lbName.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5f, UpgradeHelpers.
					Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbName.Name = "lbName";
			this.lbName.TabIndex = 5;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Selected Employee";
			this.lbUser = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUser
			// 
			this.lbUser.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUser.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUser.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbUser.Name = "lbUser";
			this.lbUser.TabIndex = 3;
			this.lbUser.Text = "User ID";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.Visible = true;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 1;
			this.Label2.Text = "Select Employee";
			this.cmdNext = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNext
			// 
			this.cmdNext.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNext.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNext.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.TabIndex = 11;
			this.cmdNext.Text = "&Next User ID";
			this.cmdNext.Visible = false;
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 10;
			this.cmdUpdate.Text = "&Update";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 9;
			this.cmdClose.Text = "&Close";
			this.Text = "Personnel Tracking and Scheduling - Security Management";
			this.UserArray = new string[] { "", "", "", "", "", "" };
			this.CurrUser = 0;
			this.TotalUsers = 0;
			this.Name = "PTSProject.frmSecurity";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSecurity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtUserID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUser { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNext { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String[] UserArray { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrUser { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalUsers { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}