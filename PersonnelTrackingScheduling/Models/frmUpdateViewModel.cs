using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUpdate))]
	public class frmUpdateViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtCostCenter = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCostCenter.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCostCenter.Enabled = false;
			this.txtCostCenter.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCostCenter.Name = "txtCostCenter";
			this.txtCostCenter.TabIndex = 24;
			this.txtCostCenter.Visible = false;
			this.picEmp = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picEmp
			// 
			this.picEmp.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.picEmp.Enabled = true;
			this.picEmp.Name = "picEmp";
			this.picEmp.Visible = true;
			this.cboJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode
			// 
			this.cboJobCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode.Enabled = true;
			this.cboJobCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode.Name = "cboJobCode";
			this.cboJobCode.TabIndex = 39;
			this.cboJobCode.Text = "cboJobCode";
			this.cboJobCode.Visible = true;
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Enabled = true;
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 0;
			this.cboEmpList.Text = "cboEmpList";
			this.cboEmpList.Visible = true;
			this.txtWDLDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWDLDate.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.txtWDLDate.Enabled = false;
			this.txtWDLDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtWDLDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWDLDate.Name = "txtWDLDate";
			this.txtWDLDate.TabIndex = 38;
			this.txtWDL = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWDL.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.txtWDL.Enabled = false;
			this.txtWDL.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtWDL.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWDL.Name = "txtWDL";
			this.txtWDL.TabIndex = 37;
			this.txtNameKnownBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameKnownBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameKnownBy.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameKnownBy.Name = "txtNameKnownBy";
			this.txtNameKnownBy.TabIndex = 6;
			this.txtNameKnownBy.Text = " ";
			this.txtFName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFName.Name = "txtFName";
			this.txtFName.TabIndex = 1;
			this.txtZip = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZip.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtZip.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtZip.Name = "txtZip";
			this.txtZip.TabIndex = 15;
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 13;
			this.txtAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAddress.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.TabIndex = 11;
			this.txtSex = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSex.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSex.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSex.Name = "txtSex";
			this.txtSex.TabIndex = 10;
			this.txtPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.TabIndex = 8;
			this.txtBDay = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBDay.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtBDay.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtBDay.Name = "txtBDay";
			this.txtBDay.TabIndex = 7;
			this.txtSName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSName.Name = "txtSName";
			this.txtSName.TabIndex = 5;
			this.txtLName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtLName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtLName.Name = "txtLName";
			this.txtLName.TabIndex = 4;
			this.txtMName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMName.Name = "txtMName";
			this.txtMName.TabIndex = 2;
			this.txtExitComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExitComments.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExitComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExitComments.Name = "txtExitComments";
			this.txtExitComments.TabIndex = 29;
			this.txtExitComments.Visible = false;
			this.cboExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboExitType
			// 
			this.cboExitType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboExitType.Enabled = true;
			this.cboExitType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboExitType.Name = "cboExitType";
			this.cboExitType.TabIndex = 28;
			this.cboExitType.Visible = false;
			this.txtExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExit.Name = "txtExit";
			this.txtExit.TabIndex = 27;
			this.txtExit.Visible = false;
			this.txtState = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtState.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtState.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtState.Name = "txtState";
			this.txtState.TabIndex = 14;
			this.txtStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStep.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStep.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtStep.Name = "txtStep";
			this.txtStep.TabIndex = 23;
			this.txtExceptDay = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExceptDay.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExceptDay.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExceptDay.Name = "txtExceptDay";
			this.txtExceptDay.TabIndex = 22;
			this.txtUnion = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtUnion.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtUnion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtUnion.Name = "txtUnion";
			this.txtUnion.TabIndex = 21;
			this.cboBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBenefit
			// 
			this.cboBenefit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBenefit.Enabled = true;
			this.cboBenefit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBenefit.Name = "cboBenefit";
			this.cboBenefit.TabIndex = 20;
			this.cboBenefit.Visible = true;
			this.txtTFD = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTFD.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTFD.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTFD.Name = "txtTFD";
			this.txtTFD.TabIndex = 19;
			this.txtCOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCOT.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCOT.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCOT.Name = "txtCOT";
			this.txtCOT.TabIndex = 18;
			this.txtSSN = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSSN.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSSN.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSSN.Name = "txtSSN";
			this.txtSSN.TabIndex = 17;
			this.lbWarning = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWarning
			// 
			this.lbWarning.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
			this.lbWarning.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWarning.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbWarning.Name = "lbWarning";
			this.lbWarning.TabIndex = 75;
			this.lbWarning.Text = "Employee's Job Code is not in PTS Database!! Call Debra Lewandowsky x5068 to add it.";
			this.lbWarning.Visible = false;
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 74;
			this.Label20.Text = "Employee ID";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 73;
			this.Label4.Text = "Job Code";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 72;
			this.Label3.Text = "Job Title";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 71;
			this.Label2.Text = "Select Employee";
			this.lbVerified = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVerified
			// 
			this.lbVerified.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbVerified.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVerified.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbVerified.Name = "lbVerified";
			this.lbVerified.TabIndex = 70;
			this.lbVerified.Text = "Last Verified on";
			this.lbVerified.Visible = false;
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label23.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 69;
			this.Label23.Text = "WDL / Exp. Date";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label21.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 68;
			this.Label21.Text = "NameKnownBy";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 67;
			this.Label7.Text = "Birth Day";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 66;
			this.Label10.Text = "Suffix";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 65;
			this.Label11.Text = "Sex";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label22.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 64;
			this.Label22.Text = "State";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 63;
			this.Label14.Text = "Zip";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label13.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 62;
			this.Label13.Text = "City";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 61;
			this.Label12.Text = "Address";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 60;
			this.Label9.Text = "Home Phone";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 59;
			this.Label8.Text = "Last Name";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 58;
			this.Label6.Text = "MI";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 57;
			this.Label5.Text = "First Name";
			this.lbExitComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExitComments
			// 
			this.lbExitComments.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExitComments.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExitComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExitComments.Name = "lbExitComments";
			this.lbExitComments.TabIndex = 56;
			this.lbExitComments.Text = "Exit Comments";
			this.lbExitComments.Visible = false;
			this.lbExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExitType
			// 
			this.lbExitType.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExitType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExitType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExitType.Name = "lbExitType";
			this.lbExitType.TabIndex = 55;
			this.lbExitType.Text = "Exit Type";
			this.lbExitType.Visible = false;
			this.lbExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExit
			// 
			this.lbExit.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExit.Name = "lbExit";
			this.lbExit.TabIndex = 54;
			this.lbExit.Text = "Exit Date";
			this.lbExit.Visible = false;
			this.lbStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStep
			// 
			this.lbStep.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbStep.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStep.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbStep.Name = "lbStep";
			this.lbStep.TabIndex = 53;
			this.lbStep.Text = "Step";
			this.lbStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStatus
			// 
			this.lbStatus.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStatus.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.TabIndex = 52;
			this.lbStatus.Text = "Uncheck Status to Inactivate Employee";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 51;
			this.Label1.Text = "Exception Days";
			this.lbUnion = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnion
			// 
			this.lbUnion.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbUnion.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbUnion.Name = "lbUnion";
			this.lbUnion.TabIndex = 50;
			this.lbUnion.Text = "Union";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label18.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 49;
			this.Label18.Text = "Benefit Program";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label17.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 48;
			this.Label17.Text = "TFD Hire Date";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label16.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 47;
			this.Label16.Text = "COT Service Date";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label15.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 46;
			this.Label15.Text = "Social Security #";
			this.Shape5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape5.Enabled = false;
			this.Shape5.Name = "Shape5";
			this.Shape5.Visible = true;
			this.lbPerArcID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPerArcID
			// 
			this.lbPerArcID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPerArcID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPerArcID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbPerArcID.Name = "lbPerArcID";
			this.lbPerArcID.TabIndex = 45;
			this.lbPerArcID.Visible = false;
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 44;
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 192);
			this.lbEmpID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 43;
			this.lbEmpID.Visible = false;
			this.lbJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJobCode
			// 
			this.lbJobCode.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 192, 192);
			this.lbJobCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbJobCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbJobCode.Name = "lbJobCode";
			this.lbJobCode.TabIndex = 42;
			this.lbJobCode.Visible = false;
			this.Shape3 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape3.Enabled = false;
			this.Shape3.Name = "Shape3";
			this.Shape3.Visible = true;
			this.Shape4 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape4.Enabled = false;
			this.Shape4.Name = "Shape4";
			this.Shape4.Visible = true;
			this.Shape2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape2.Enabled = false;
			this.Shape2.Name = "Shape2";
			this.Shape2.Visible = true;
			this.cmdNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNote
			// 
			this.cmdNote.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNote.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNote.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNote.Name = "cmdNote";
			this.cmdNote.TabIndex = 76;
			this.cmdNote.Text = "Notes";
			this.cmdChangeCC = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdChangeCC
			// 
			this.cmdChangeCC.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdChangeCC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdChangeCC.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdChangeCC.Name = "cmdChangeCC";
			this.cmdChangeCC.TabIndex = 25;
			this.cmdChangeCC.Tag = "0";
			this.cmdChangeCC.Text = "Cost Center";
			this.cmdChangeCC.Visible = false;
			this.cmdSwitch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSwitch
			// 
			this.cmdSwitch.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSwitch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSwitch.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSwitch.Name = "cmdSwitch";
			this.cmdSwitch.TabIndex = 40;
			this.cmdSwitch.Tag = "1";
			this.cmdSwitch.Text = "&View Archived Personnel";
			this.cmdVerify = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdVerify
			// 
			this.cmdVerify.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdVerify.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdVerify.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdVerify.Name = "cmdVerify";
			this.cmdVerify.TabIndex = 16;
			this.cmdVerify.Text = "WDL / PPE Info";
			this.cmdAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddress
			// 
			this.cmdAddress.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddress.Name = "cmdAddress";
			this.cmdAddress.TabIndex = 12;
			this.cmdAddress.Text = "&More Addresses";
			this.cmdEmergency = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEmergency
			// 
			this.cmdEmergency.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEmergency.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdEmergency.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEmergency.Name = "cmdEmergency";
			this.cmdEmergency.TabIndex = 3;
			this.cmdEmergency.Text = "&Emergency Contact";
			this.cmdPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPhone
			// 
			this.cmdPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPhone.Name = "cmdPhone";
			this.cmdPhone.TabIndex = 9;
			this.cmdPhone.Text = "Additional &Numbers";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 35;
			this.cmdClose.Text = "&Close";
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 34;
			this.cmdDelete.Text = "&Delete Employee";
			this.cmdNewPromo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewPromo
			// 
			this.cmdNewPromo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewPromo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdNewPromo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewPromo.Name = "cmdNewPromo";
			this.cmdNewPromo.TabIndex = 33;
			this.cmdNewPromo.Text = "New &Promotion";
			this.cmdAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAssign
			// 
			this.cmdAssign.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAssign.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAssign.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAssign.Name = "cmdAssign";
			this.cmdAssign.TabIndex = 32;
			this.cmdAssign.Text = "&Assign";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 31;
			this.cmdUpdate.Text = "&Update";
			this.cmdUndo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUndo
			// 
			this.cmdUndo.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUndo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdUndo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUndo.Name = "cmdUndo";
			this.cmdUndo.TabIndex = 30;
			this.cmdUndo.Text = "Und&o Changes";
			this.Text = "Update Employee";
			this.chkStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkStatus.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkStatus.Enabled = true;
			this.chkStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.TabIndex = 26;
			this.chkStatus.Text = "Status";
			this.chkStatus.Visible = true;
			this.iLicenseID = 0;
			this.sLicenseNumber = "";
			this.dLicenseExpDate = "";
			this.dVerifyDate = "";
			this.sVerifyBy = "";
			this.lPersSysID = 0;
			this.Name = "PTSProject.frmUpdate";
			IsMdiChild = true;
			cboExitType.Items.Add("Retirement");
			cboExitType.Items.Add("Transfer");
			cboExitType.Items.Add("Resignation");
			cboExitType.Items.Add("Termination");
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCostCenter { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picEmp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWDLDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWDL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameKnownBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZip { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSex { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBDay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExitComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExceptDay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtUnion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTFD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSSN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWarning { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVerified { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExitComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPerArcID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJobCode { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape3 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape4 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdChangeCC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSwitch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdVerify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEmergency { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewPromo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUndo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkStatus { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iLicenseID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sLicenseNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String dLicenseExpDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String dVerifyDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sVerifyBy { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 lPersSysID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtSex_TextChanged()
		{
			if ( _txtSex_TextChanged != null )
				_txtSex_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtSex_TextChanged;
	}

}