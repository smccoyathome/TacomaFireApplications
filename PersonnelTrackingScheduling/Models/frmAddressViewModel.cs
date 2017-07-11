using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAddress))]
	public class frmAddressViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtState = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtState.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtState.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtState.Name = "txtState";
			this.txtState.TabIndex = 6;
			this.txtState.Text = "txtState";
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 5;
			this.txtCity.Text = "txtCity";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 8;
			this.txtComment.Text = "txtComment";
			this.txtZip = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZip.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtZip.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtZip.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtZip.Name = "txtZip";
			this.txtZip.TabIndex = 7;
			this.txtZip.Text = "txtZip";
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.cboType.Enabled = true;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 4;
			this.cboType.Text = "cboType";
			this.cboType.Visible = true;
			this.txtAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAddress.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.TabIndex = 3;
			this.txtAddress.Text = "txtAddress";
			this.lstAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstAddress
			// 
			this.lstAddress.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstAddress.Enabled = true;
			this.lstAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstAddress.Name = "lstAddress";
			this.lstAddress.TabIndex = 2;
			this.lstAddress.Visible = true;
			this.lstAddress.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Enabled = true;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 1;
			this.cboEmpList.Text = "cboEmpList";
			this.cboEmpList.Visible = true;
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 22;
			this.Label8.Text = "(Optional)";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 21;
			this.Label9.Text = "State";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 20;
			this.Label7.Text = "Comment";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 19;
			this.Label6.Text = "Zip Code";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 18;
			this.Label5.Text = "City";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Address Type ";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 16;
			this.Label3.Text = "Address";
			this.lbAddressID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAddressID
			// 
			this.lbAddressID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAddressID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAddressID.Name = "lbAddressID";
			this.lbAddressID.TabIndex = 15;
			this.lbAddressID.Text = "lbAddressID";
			this.lbAddressID.Visible = false;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 14;
			this.Label2.Text = "Select Address to Edit";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 13;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Select Employee";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 9;
			this.cmdAdd.Tag = "2";
			this.cmdAdd.Text = "&Add New Address";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 12;
			this.cmdClose.Text = "&Close";
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 11;
			this.cmdDelete.Text = "&Delete";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 10;
			this.cmdUpdate.Text = "&Update";
			this.Text = "Personnel Address Entry/Update";
			this.Name = "PTSProject.frmAddress";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZip { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAddressID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}