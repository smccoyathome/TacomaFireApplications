using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmAddNew))]
	public class frmAddNewViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtSAPEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSAPEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSAPEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSAPEmpID.Name = "txtSAPEmpID";
			this.txtSAPEmpID.TabIndex = 54;
			this.txtEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtEmpID.Name = "txtEmpID";
			this.txtEmpID.TabIndex = 52;
			this.cboJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboJobCode
			// 
			this.cboJobCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboJobCode.Enabled = true;
			this.cboJobCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboJobCode.Name = "cboJobCode";
			this.cboJobCode.TabIndex = 42;
			this.cboJobCode.Text = "cboJobCode";
			this.cboJobCode.Visible = true;
			this.txtStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStep.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStep.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtStep.Name = "txtStep";
			this.txtStep.TabIndex = 41;
			this.txtStep.Text = " ";
			this.txtNameKnownBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameKnownBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameKnownBy.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameKnownBy.Name = "txtNameKnownBy";
			this.txtNameKnownBy.TabIndex = 23;
			this.txtNameKnownBy.Text = " ";
			this.txtCOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCOT.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCOT.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCOT.Name = "txtCOT";
			this.txtCOT.TabIndex = 22;
			this.txtSex = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSex.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSex.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSex.Name = "txtSex";
			this.txtSex.TabIndex = 21;
			this.txtTFD = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTFD.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTFD.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTFD.Name = "txtTFD";
			this.txtTFD.TabIndex = 20;
			this.txtBDay = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBDay.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtBDay.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtBDay.Name = "txtBDay";
			this.txtBDay.TabIndex = 19;
			this.txtException = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtException.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtException.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtException.Name = "txtException";
			this.txtException.TabIndex = 18;
			this.txtPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPhone.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.TabIndex = 17;
			this.cboBenefit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBenefit
			// 
			this.cboBenefit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBenefit.Enabled = true;
			this.cboBenefit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBenefit.Name = "cboBenefit";
			this.cboBenefit.TabIndex = 16;
			this.cboBenefit.Visible = true;
			this.txtAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAddress.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.TabIndex = 15;
			this.txtState = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtState.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtState.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtState.Name = "txtState";
			this.txtState.TabIndex = 14;
			this.txtZip = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZip.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtZip.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtZip.Name = "txtZip";
			this.txtZip.TabIndex = 13;
			this.txtUnion = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtUnion.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtUnion.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtUnion.Name = "txtUnion";
			this.txtUnion.TabIndex = 12;
			this.txtSSN = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSSN.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSSN.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSSN.Name = "txtSSN";
			this.txtSSN.TabIndex = 10;
			this.txtExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExit.Name = "txtExit";
			this.txtExit.TabIndex = 9;
			this.txtExit.Visible = false;
			this.cboExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboExitType
			// 
			this.cboExitType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboExitType.Enabled = true;
			this.cboExitType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboExitType.Name = "cboExitType";
			this.cboExitType.TabIndex = 8;
			this.cboExitType.Visible = false;
			this.txtExitComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExitComments.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExitComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExitComments.Name = "txtExitComments";
			this.txtExitComments.TabIndex = 7;
			this.txtExitComments.Visible = false;
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 6;
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label18.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 40;
			this.Label18.Text = "Name Known By";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 39;
			this.Label7.Text = "COT Service Date";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 38;
			this.Label9.Text = "Birth Date";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 37;
			this.Label14.Text = "Sex";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 36;
			this.Label8.Text = "TFD Hire Date";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 35;
			this.Label20.Text = "Exception Days";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 34;
			this.Label13.Text = "Home Phone";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 33;
			this.Label10.Text = "Address";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 32;
			this.Label16.Text = "Benefit Program";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 31;
			this.Label11.Text = "State";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 30;
			this.Label17.Text = "City";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 29;
			this.Label12.Text = "Zip";
			this.lbUnion = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnion
			// 
			this.lbUnion.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnion.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnion.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbUnion.Name = "lbUnion";
			this.lbUnion.TabIndex = 28;
			this.lbUnion.Text = "Union";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 27;
			this.Label15.Text = "Social Security #";
			this.lbExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExit
			// 
			this.lbExit.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExit.Name = "lbExit";
			this.lbExit.TabIndex = 26;
			this.lbExit.Text = "Exit Date";
			this.lbExit.Visible = false;
			this.lbExitType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExitType
			// 
			this.lbExitType.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExitType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExitType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExitType.Name = "lbExitType";
			this.lbExitType.TabIndex = 25;
			this.lbExitType.Text = "Exit Type";
			this.lbExitType.Visible = false;
			this.lbExitComments = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExitComments
			// 
			this.lbExitComments.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbExitComments.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExitComments.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lbExitComments.Name = "lbExitComments";
			this.lbExitComments.TabIndex = 24;
			this.lbExitComments.Text = "Exit Comments";
			this.lbExitComments.Visible = false;
			this.txtSName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtSName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtSName.Name = "txtSName";
			this.txtSName.TabIndex = 47;
			this.txtSName.Text = " ";
			this.txtLName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtLName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtLName.Name = "txtLName";
			this.txtLName.TabIndex = 46;
			this.txtMName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtMName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtMName.Name = "txtMName";
			this.txtMName.TabIndex = 45;
			this.txtFName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFName.Name = "txtFName";
			this.txtFName.TabIndex = 44;
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 51;
			this.Label6.Text = "Suffix";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 50;
			this.Label3.Text = "Last Name";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 49;
			this.Label2.Text = "MI";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 48;
			this.Label1.Text = "First Name";
			this.Picture1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// Picture1
			// 
			this.Picture1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Picture1.Enabled = true;
			this.Picture1.Name = "Picture1";
			this.Picture1.Visible = true;
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 60;
			this.Label19.Text = "SAP Employee #";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 59;
			this.Label22.Text = "TFD Employee #";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 58;
			this.Label4.Text = "Job Title";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 57;
			this.Label5.Text = "Job Code";
			this.lbStep = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStep
			// 
			this.lbStep.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStep.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStep.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbStep.Name = "lbStep";
			this.lbStep.TabIndex = 56;
			this.lbStep.Text = "Step";
			this.lbJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJobCode
			// 
			this.lbJobCode.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbJobCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbJobCode.ForeColor = UpgradeHelpers.Helpers.Color.Silver;
			this.lbJobCode.Name = "lbJobCode";
			this.lbJobCode.TabIndex = 55;
			this.Shape5 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape5.Enabled = false;
			this.Shape5.Name = "Shape5";
			this.Shape5.Visible = true;
			this.cmdSwitch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSwitch
			// 
			this.cmdSwitch.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSwitch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSwitch.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSwitch.Name = "cmdSwitch";
			this.cmdSwitch.TabIndex = 53;
			this.cmdSwitch.Tag = "1";
			this.cmdSwitch.Text = "Add New Archived &Employee";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 4;
			this.cmdClose.Text = "&Close";
			this.cmdAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAssign
			// 
			this.cmdAssign.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAssign.Enabled = false;
			this.cmdAssign.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAssign.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAssign.Name = "cmdAssign";
			this.cmdAssign.TabIndex = 3;
			this.cmdAssign.Text = "A&ssign";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "&Add New Employee";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8.25f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 1;
			this.cmdClear.Text = "C&lear";
			this.Text = "ADD NEW EMPLOYEE";
			this.chkStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkStatus.BackColor = UpgradeHelpers.Helpers.Color.Silver;
			this.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkStatus.Enabled = true;
			this.chkStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.TabIndex = 11;
			this.chkStatus.Text = "Active?";
			this.chkStatus.Visible = true;
			this.Name = "PTSProject.frmAddNew";
			IsMdiChild = true;
			cboExitType.Items.Add("Retirement");
			cboExitType.Items.Add("Transfer");
			cboExitType.Items.Add("Resignation");
			cboExitType.Items.Add("Termination");
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSAPEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameKnownBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSex { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTFD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBDay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtException { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBenefit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZip { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtUnion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSSN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExitComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnion { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExitType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExitComments { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtSName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel Picture1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStep { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJobCode { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSwitch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkStatus { get; set; }

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