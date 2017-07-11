using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmEmergencyContact))]
	public class frmEmergencyContactViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboBestTime = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBestTime
			// 
			this.cboBestTime.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.cboBestTime.Enabled = true;
			this.cboBestTime.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBestTime.Name = "cboBestTime";
			this.cboBestTime.TabIndex = 9;
			this.cboBestTime.Text = "cboBestTime";
			this.cboBestTime.Visible = true;
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
			this.cboPhoneType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPhoneType
			// 
			this.cboPhoneType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.cboPhoneType.Enabled = true;
			this.cboPhoneType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPhoneType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPhoneType.Name = "cboPhoneType";
			this.cboPhoneType.TabIndex = 8;
			this.cboPhoneType.Text = "cboPhoneType";
			this.cboPhoneType.Visible = true;
			this.txtPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPhone.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.TabIndex = 7;
			this.txtPhone.Text = "txtPhone";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 10;
			this.txtComment.Text = "txtComment";
			this.cboRelationship = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRelationship
			// 
			this.cboRelationship.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.cboRelationship.Enabled = true;
			this.cboRelationship.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboRelationship.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboRelationship.Name = "cboRelationship";
			this.cboRelationship.TabIndex = 5;
			this.cboRelationship.Text = "cboRelationship";
			this.cboRelationship.Visible = true;
			this.txtName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 255, 255);
			this.txtName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 4;
			this.txtName.Text = "txtName";
			this.lstPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPhone
			// 
			this.lstPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstPhone.Enabled = true;
			this.lstPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstPhone.Name = "lstPhone";
			this.lstPhone.TabIndex = 3;
			this.lstPhone.Visible = true;
			this.lstPhone.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstContacts = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContacts
			// 
			this.lstContacts.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstContacts.Enabled = true;
			this.lstContacts.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstContacts.Name = "lstContacts";
			this.lstContacts.TabIndex = 2;
			this.lstContacts.Visible = true;
			this.lstContacts.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 26;
			this.Label11.Text = "(optional)";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 25;
			this.Label9.Text = "Check Box if this is the Primary Contact for Employee";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 24;
			this.Label10.Text = "Time Available";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 23;
			this.Label8.Text = "Comment";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 22;
			this.Label7.Text = "Phone Type";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 21;
			this.Label6.Text = "Phone Number";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 20;
			this.Label5.Text = "Relationship";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 19;
			this.Label4.Text = "Contact Name";
			this.lbPhoneID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhoneID
			// 
			this.lbPhoneID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbPhoneID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbPhoneID.Name = "lbPhoneID";
			this.lbPhoneID.TabIndex = 29;
			this.lbPhoneID.Text = "lbPhoneID";
			this.lbPhoneID.Visible = false;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 18;
			this.Label3.Text = "Select Phone Number to Edit";
			this.lbContactID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContactID
			// 
			this.lbContactID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbContactID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbContactID.Name = "lbContactID";
			this.lbContactID.TabIndex = 28;
			this.lbContactID.Text = "lbContactID";
			this.lbContactID.Visible = false;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 17;
			this.Label2.Text = "Select Contact to Edit";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Select Employee";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 27;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 11;
			this.cmdClose.Text = "&Close";
			this.cmdDelPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelPhone
			// 
			this.cmdDelPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDelPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelPhone.Name = "cmdDelPhone";
			this.cmdDelPhone.TabIndex = 15;
			this.cmdDelPhone.Text = "Delete &Phone";
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 13;
			this.cmdDelete.Text = "&Delete Contact";
			this.cmdAddPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddPhone
			// 
			this.cmdAddPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddPhone.Name = "cmdAddPhone";
			this.cmdAddPhone.TabIndex = 16;
			this.cmdAddPhone.Tag = "1";
			this.cmdAddPhone.Text = "&New Phone";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 14;
			this.cmdUpdate.Text = "&Update Info";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 12;
			this.cmdAdd.Tag = "1";
			this.cmdAdd.Text = "New &Contact";
			this.Text = "Emergency Contact Entry/Update";
			this.chkPrimary = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkPrimary.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkPrimary.Enabled = true;
			this.chkPrimary.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkPrimary.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.chkPrimary.Name = "chkPrimary";
			this.chkPrimary.TabIndex = 6;
			this.chkPrimary.Text = "Primary Contact";
			this.chkPrimary.Visible = true;
			this.Name = "PTSProject.frmEmergencyContact";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBestTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPhoneType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRelationship { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContacts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhoneID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContactID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPrimary { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}