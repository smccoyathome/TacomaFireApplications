using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmNewPPEWDL))]
	public class frmNewPPEWDLViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var checkBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNumber.Name = "txtTrackingNumber";
			this.txtTrackingNumber.TabIndex = 29;
			this.txtTrackingNumber.Text = "txtTrackingNumber";
			this.cboColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboColorSize
			// 
			this.cboColorSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboColorSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboColorSize.Name = "cboColorSize";
			this.cboColorSize.TabIndex = 32;
			this.cboColorSize.Text = "cboColorSize";
			this.cboItemBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemBrand
			// 
			this.cboItemBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemBrand.Name = "cboItemBrand";
			this.cboItemBrand.TabIndex = 33;
			this.cboItemBrand.Text = "cboItemBrand";
			this.cboItemType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemType
			// 
			this.cboItemType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemType.Name = "cboItemType";
			this.cboItemType.TabIndex = 31;
			this.cboItemType.Text = "cboItemType";
			this.dteIssued = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteIssued.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dteIssued.Name = "dteIssued";
			this.dteIssued.TabIndex = 28;
			this.dteManufDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteManufDate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dteManufDate.Name = "dteManufDate";
			this.dteManufDate.TabIndex = 35;
			this.dteManufDate.Visible = false;
			this.lbUniformID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUniformID
			// 
			this.lbUniformID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUniformID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUniformID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbUniformID.Name = "lbUniformID";
			this.lbUniformID.TabIndex = 68;
			this.lbUniformID.Text = "lbUniformID";
			this.lbUniformID.Visible = false;
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 67;
			this.Label17.Text = "Tracking / Barcode";
			this.lblColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblColorSize
			// 
			this.lblColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblColorSize.Name = "lblColorSize";
			this.lblColorSize.TabIndex = 66;
			this.lblColorSize.Text = "Size/Color";
			this.lblBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblBrand
			// 
			this.lblBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblBrand.Name = "lblBrand";
			this.lblBrand.TabIndex = 65;
			this.lblBrand.Text = "Brand/Manufacturer";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 64;
			this.Label14.Text = "PPE Item";
			this.label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// label13
			// 
			this.label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.label13.Name = "label13";
			this.label13.TabIndex = 63;
			this.label13.Text = "Issued Date";
			this.txtInspComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtInspComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtInspComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtInspComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtInspComment.Name = "txtInspComment";
			this.txtInspComment.TabIndex = 26;
			this.txtInspComment.Text = "txtInspComment";
			this.dtInspection = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtInspection.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtInspection.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtInspection.Name = "dtInspection";
			this.dtInspection.TabIndex = 23;
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 61;
			this.Label12.Text = "Comment:";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 60;
			this.Label8.Text = "Select Inspection Date:";
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 8;
			this.cboEmpList.Text = "cboEmpList";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 72;
			this.opt183.Text = "Batt 3";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 0;
			this.opt181.Text = "Batt 1";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 1;
			this.opt182.Text = "Batt 2";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 2;
			this.optAll.Text = "ALL";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 3;
			this.optA.Text = "Shift A";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 4;
			this.optB.Text = "Shift B";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 5;
			this.optC.Text = "Shift C";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 6;
			this.optD.Text = "Shift D";
			this.txtTrackingNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNum.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTrackingNum.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNum.Name = "txtTrackingNum";
			this.txtTrackingNum.TabIndex = 9;
			this.txtTrackingNum.Text = "txtTrackingNum";
			this.lbLicenseID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLicenseID
			// 
			this.lbLicenseID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbLicenseID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLicenseID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbLicenseID.Name = "lbLicenseID";
			this.lbLicenseID.TabIndex = 58;
			this.lbLicenseID.Text = "lbLicenseID";
			this.lbLicenseID.Visible = false;
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 57;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 56;
			this.Label1.Text = "To Filter the Employee List, Click a Battalion and/or Shift";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 55;
			this.Label2.Text = "To Clear the Filter, Click ALL (ALL = Everyone in TFD)";
			this.lbBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBirthdate
			// 
			this.lbBirthdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBirthdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbBirthdate.Name = "lbBirthdate";
			this.lbBirthdate.TabIndex = 54;
			this.lbBirthdate.Text = "lbBirthdate";
			this.lbBirthdate.Visible = false;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 53;
			this.Label11.Text = "Search by Barcode/Tracking #:";
			this.txtWDL = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWDL.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWDL.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtWDL.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtWDL.Name = "txtWDL";
			this.txtWDL.TabIndex = 13;
			this.txtWDL.Text = "txtWDL";
			this.txtExpireDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExpireDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExpireDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtExpireDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtExpireDate.Name = "txtExpireDate";
			this.txtExpireDate.TabIndex = 14;
			this.txtExpireDate.Text = "txtExpireDate";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 49;
			this.Label3.Text = "Name:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 48;
			this.Label4.Text = "Employee #:";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 47;
			this.Label5.Text = "Assignment:";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 46;
			this.Label6.Text = "Washington Driver License #:";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 45;
			this.lblName.Text = "lblName";
			this.lblEmpNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmpNum
			// 
			this.lblEmpNum.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblEmpNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmpNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblEmpNum.Name = "lblEmpNum";
			this.lblEmpNum.TabIndex = 44;
			this.lblEmpNum.Text = "lblEmpNum";
			this.lblAssignment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblAssignment
			// 
			this.lblAssignment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblAssignment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblAssignment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblAssignment.Name = "lblAssignment";
			this.lblAssignment.TabIndex = 43;
			this.lblAssignment.Text = "lblAssignment";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 42;
			this.Label7.Text = "WDL Expiration Date:";
			this.lblVerify = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblVerify
			// 
			this.lblVerify.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblVerify.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblVerify.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lblVerify.Name = "lblVerify";
			this.lblVerify.TabIndex = 41;
			this.lblVerify.Text = "lblVerify";
			this.lblVerify.Visible = false;
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 40;
			this.Label9.Text = "Label9";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 39;
			this.Label10.Text = "m/d/yyyy";
			this.sprPPEList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPPEList.TabIndex = 22;
			this.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1.SheetName = "Sheet1";
			this.sprPPEList_Sheet1.Cells.Get(2, 8).Value = "0";
			this.sprPPEList_Sheet1.Cells.Get(3, 8).Value = "0";
			this.sprPPEList_Sheet1.Cells.Get(19, 8).Value = "1";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 0].Value = "ITEM";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 1].Value = "ISSUE DATE";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 2].Value = "BRAND NAME";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 3].Value = "SIZE or COLOR";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Barcode / Tracking #";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 5].Value = "OK?";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Not Insp";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Repair?";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Needs Cleaned / Laundered?";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 9].Value = "uniform_id";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 10].Value = "inspection_id";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 11].Value = "repair_id";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 12].Value = "type_code";
			this.sprPPEList_Sheet1.ColumnHeader.Rows.Get(0).Height = 52F;
			this.sprPPEList_Sheet1.Columns.Get(0).Label = "ITEM";
			this.sprPPEList_Sheet1.Columns.Get(0).StyleName = "Style1";
			this.sprPPEList_Sheet1.Columns.Get(0).Width = 88F;
			this.sprPPEList_Sheet1.Columns.Get(1).Label = "ISSUE DATE";
			this.sprPPEList_Sheet1.Columns.Get(1).StyleName = "Text822636234737817940761";
			this.sprPPEList_Sheet1.Columns.Get(1).Width = 55F;
			this.sprPPEList_Sheet1.Columns.Get(2).Label = "BRAND NAME";
			this.sprPPEList_Sheet1.Columns.Get(2).StyleName = "Static907636234737817950526";
			this.sprPPEList_Sheet1.Columns.Get(2).Width = 85F;
			this.sprPPEList_Sheet1.Columns.Get(3).Label = "SIZE or COLOR";
			this.sprPPEList_Sheet1.Columns.Get(3).StyleName = "Static907636234737817950526";
			this.sprPPEList_Sheet1.Columns.Get(3).Width = 50F;
			this.sprPPEList_Sheet1.Columns.Get(4).Label = "Barcode / Tracking #";
			this.sprPPEList_Sheet1.Columns.Get(4).StyleName = "Style1";
			this.sprPPEList_Sheet1.Columns.Get(4).Width = 68F;
			this.sprPPEList_Sheet1.Columns.Get(5).Label = "OK?";
			this.sprPPEList_Sheet1.Columns.Get(5).StyleName = "CheckBox1155636234737818311831";
			this.sprPPEList_Sheet1.Columns.Get(5).Width = 27F;
			this.sprPPEList_Sheet1.Columns.Get(6).Label = "Not Insp";
			//this.sprPPEList_Sheet1.Columns.Get(6).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprPPEList_Sheet1.Columns.Get(6).Width = 42F;
			this.sprPPEList_Sheet1.Columns.Get(7).Label = "Repair?";
			this.sprPPEList_Sheet1.Columns.Get(7).StyleName = "CheckBox1155636234737818311831";
			this.sprPPEList_Sheet1.Columns.Get(7).Width = 47F;
			this.sprPPEList_Sheet1.Columns.Get(8).Label = "Needs Cleaned / Laundered?";
			this.sprPPEList_Sheet1.Columns.Get(8).StyleName = "CheckBox1155636234737818311831";
			this.sprPPEList_Sheet1.Columns.Get(8).Width = 68F;
			this.sprPPEList_Sheet1.Columns.Get(9).Label = "uniform_id";
			this.sprPPEList_Sheet1.Columns.Get(9).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(9).Width = 0F;
			this.sprPPEList_Sheet1.Columns.Get(10).Label = "inspection_id";
			this.sprPPEList_Sheet1.Columns.Get(10).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(10).Width = 0F;
			this.sprPPEList_Sheet1.Columns.Get(11).Label = "repair_id";
			this.sprPPEList_Sheet1.Columns.Get(11).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(11).Width = 0F;
			this.sprPPEList_Sheet1.Columns.Get(12).Label = "type_code";
			this.sprPPEList_Sheet1.Columns.Get(12).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(12).Width = 0F;
			this.sprPPEList_Sheet1.RowHeader.Columns.Get(0).Width = 14F;
			this.sprPPEList_Sheet1.Rows.Get(0).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(1).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(2).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(3).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(4).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(5).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(6).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(7).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(8).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(9).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(10).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(11).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(11).Visible = false;
			this.sprPPEList_Sheet1.Rows.Get(12).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(13).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(14).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(15).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(16).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(17).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(18).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(19).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(20).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(21).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(22).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(23).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(24).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(25).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(26).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(27).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(28).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(29).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(30).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(31).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(32).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(33).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(34).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(35).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(36).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(37).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(38).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(39).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(40).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(41).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(42).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(43).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(44).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(45).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(46).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(47).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(48).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(49).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(50).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(51).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(52).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(53).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(54).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(55).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(56).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(57).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(58).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(59).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(60).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(61).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(62).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(63).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(64).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(65).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(66).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(67).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(68).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(69).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(70).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(71).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(72).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(73).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(74).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(75).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(76).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(77).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(78).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(79).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(80).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(81).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(82).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(83).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(84).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(85).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(86).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(87).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(88).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(89).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(90).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(91).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(92).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(93).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(94).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(95).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(96).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(97).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(98).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(99).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(100).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(101).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(102).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(103).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(104).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(105).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(106).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(107).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(108).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(109).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(110).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(111).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(112).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(113).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(114).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(115).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(116).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(117).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(118).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(119).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(120).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(121).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(122).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(123).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(124).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(125).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(126).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(127).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(128).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(129).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(130).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(131).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(132).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(133).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(134).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(135).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(136).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(137).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(138).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(139).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(140).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(141).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(142).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(143).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(144).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(145).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(146).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(147).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(148).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(149).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(150).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(151).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(152).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(153).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(154).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(155).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(156).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(157).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(158).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(159).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(160).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(161).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(162).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(163).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(164).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(165).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(166).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(167).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(168).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(169).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(170).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(171).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(172).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(173).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(174).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(175).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(176).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(177).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(178).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(179).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(180).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(181).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(182).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(183).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(184).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(185).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(186).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(187).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(188).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(189).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(190).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(191).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(192).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(193).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(194).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(195).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(196).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(197).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(198).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(199).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(200).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(201).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(202).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(203).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(204).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(205).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(206).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(207).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(208).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(209).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(210).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(211).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(212).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(213).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(214).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(215).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(216).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(217).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(218).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(219).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(220).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(221).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(222).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(223).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(224).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(225).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(226).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(227).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(228).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(229).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(230).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(231).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(232).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(233).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(234).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(235).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(236).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(237).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(238).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(239).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(240).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(241).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(242).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(243).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(244).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(245).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(246).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(247).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(248).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(249).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(250).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(251).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(252).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(253).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(254).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(255).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(256).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(257).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(258).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(259).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(260).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(261).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(262).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(263).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(264).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(265).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(266).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(267).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(268).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(269).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(270).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(271).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(272).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(273).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(274).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(275).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(276).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(277).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(278).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(279).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(280).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(281).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(282).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(283).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(284).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(285).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(286).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(287).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(288).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(289).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(290).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(291).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(292).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(293).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(294).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(295).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(296).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(297).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(298).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(299).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(300).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(301).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(302).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(303).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(304).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(305).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(306).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(307).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(308).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(309).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(310).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(311).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(312).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(313).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(314).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(315).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(316).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(317).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(318).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(319).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(320).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(321).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(322).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(323).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(324).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(325).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(326).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(327).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(328).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(329).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(330).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(331).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(332).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(333).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(334).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(335).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(336).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(337).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(338).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(339).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(340).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(341).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(342).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(343).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(344).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(345).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(346).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(347).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(348).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(349).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(350).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(351).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(352).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(353).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(354).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(355).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(356).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(357).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(358).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(359).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(360).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(361).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(362).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(363).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(364).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(365).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(366).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(367).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(368).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(369).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(370).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(371).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(372).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(373).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(374).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(375).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(376).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(377).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(378).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(379).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(380).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(381).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(382).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(383).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(384).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(385).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(386).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(387).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(388).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(389).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(390).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(391).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(392).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(393).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(394).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(395).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(396).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(397).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(398).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(399).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(400).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(401).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(402).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(403).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(404).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(405).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(406).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(407).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(408).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(409).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(410).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(411).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(412).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(413).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(414).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(415).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(416).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(417).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(418).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(419).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(420).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(421).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(422).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(423).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(424).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(425).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(426).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(427).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(428).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(429).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(430).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(431).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(432).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(433).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(434).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(435).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(436).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(437).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(438).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(439).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(440).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(441).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(442).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(443).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(444).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(445).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(446).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(447).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(448).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(449).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(450).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(451).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(452).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(453).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(454).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(455).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(456).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(457).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(458).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(459).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(460).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(461).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(462).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(463).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(464).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(465).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(466).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(467).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(468).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(469).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(470).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(471).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(472).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(473).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(474).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(475).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(476).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(477).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(478).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(479).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(480).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(481).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(482).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(483).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(484).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(485).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(486).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(487).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(488).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(489).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(490).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(491).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(492).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(493).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(494).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(495).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(496).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(497).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(498).Height = 15F;
			this.sprPPEList_Sheet1.Rows.Get(499).Height = 15F;
			this.cmdFind = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdFind.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdFind.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.TabIndex = 30;
			this.cmdFind.Text = "Find...";
			this.cmdCleaning = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCleaning
			// 
			this.cmdCleaning.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCleaning.Enabled = false;
			this.cmdCleaning.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCleaning.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCleaning.Name = "cmdCleaning";
			this.cmdCleaning.TabIndex = 21;
			this.cmdCleaning.Text = "Laundry History";
			this.chkManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkManufDate
			// 
			this.chkManufDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkManufDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkManufDate.Name = "chkManufDate";
			this.chkManufDate.TabIndex = 34;
			this.chkManufDate.Text = "PPE Manufacturered Date?";
			this.cmdReplaceItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReplaceItem
			// 
			this.cmdReplaceItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReplaceItem.Enabled = false;
			this.cmdReplaceItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReplaceItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReplaceItem.Name = "cmdReplaceItem";
			this.cmdReplaceItem.TabIndex = 37;
			this.cmdReplaceItem.Text = "Replace";
			this.cmdNewItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewItem
			// 
			this.cmdNewItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewItem.Name = "cmdNewItem";
			this.cmdNewItem.TabIndex = 27;
			this.cmdNewItem.Text = "New Item";
			this.cmdEditItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEditItem
			// 
			this.cmdEditItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEditItem.Enabled = false;
			this.cmdEditItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEditItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEditItem.Name = "cmdEditItem";
			this.cmdEditItem.TabIndex = 36;
			this.cmdEditItem.Tag = "1";
			this.cmdEditItem.Text = "Add";
			this.cmdLastInsp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdLastInsp
			// 
			this.cmdLastInsp.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdLastInsp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdLastInsp.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdLastInsp.Name = "cmdLastInsp";
			this.cmdLastInsp.TabIndex = 18;
			this.cmdLastInsp.Text = "Get Last Inspection";
			this.cmdInspection = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdInspection
			// 
			this.cmdInspection.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdInspection.Enabled = false;
			this.cmdInspection.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdInspection.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdInspection.Name = "cmdInspection";
			this.cmdInspection.TabIndex = 19;
			this.cmdInspection.Text = "Inspect History";
			this.cmdRepair = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRepair
			// 
			this.cmdRepair.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRepair.Enabled = false;
			this.cmdRepair.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRepair.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRepair.Name = "cmdRepair";
			this.cmdRepair.TabIndex = 20;
			this.cmdRepair.Text = "Repair History";
			this.cmdAddNew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNew
			// 
			this.cmdAddNew.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNew.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddNew.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.TabIndex = 25;
			this.cmdAddNew.Tag = "0";
			this.cmdAddNew.Text = "Add PPE Inspection";
			this.cmdAllOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAllOK
			// 
			this.cmdAllOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAllOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAllOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAllOK.Name = "cmdAllOK";
			this.cmdAllOK.TabIndex = 24;
			this.cmdAllOK.Text = "All PPE OK";
			this.cmdSizes = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSizes
			// 
			this.cmdSizes.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSizes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSizes.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSizes.Name = "cmdSizes";
			this.cmdSizes.TabIndex = 69;
			this.cmdSizes.Text = "Employee Sizes";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 12;
			this.cmdClose.Text = "&Close";
			this.cmdPrintChecklist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintChecklist
			// 
			this.cmdPrintChecklist.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintChecklist.Enabled = false;
			this.cmdPrintChecklist.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers
					.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintChecklist.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintChecklist.Name = "cmdPrintChecklist";
			this.cmdPrintChecklist.TabIndex = 11;
			this.cmdPrintChecklist.Text = "Print Inspection Check List";
			this.chkInactive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInactive
			// 
			this.chkInactive.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkInactive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInactive.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.TabIndex = 7;
			this.chkInactive.Text = "Display Inactive Employees";
			this.cmdSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSearch
			// 
			this.cmdSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.TabIndex = 10;
			this.cmdSearch.Text = "Search";
			this.cmdLaundryMgmt = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdLaundryMgmt
			// 
			this.cmdLaundryMgmt.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdLaundryMgmt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdLaundryMgmt.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdLaundryMgmt.Name = "cmdLaundryMgmt";
			this.cmdLaundryMgmt.TabIndex = 71;
			this.cmdLaundryMgmt.Text = "PPE Launder Mgmt";
			this.cmdGlobe = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdGlobe
			// 
			this.cmdGlobe.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdGlobe.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdGlobe.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdGlobe.Name = "cmdGlobe";
			this.cmdGlobe.TabIndex = 70;
			this.cmdGlobe.Text = "Query Globe Info";
			this.cmdUniformQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUniformQuery
			// 
			this.cmdUniformQuery.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUniformQuery.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUniformQuery.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUniformQuery.Name = "cmdUniformQuery";
			this.cmdUniformQuery.TabIndex = 17;
			this.cmdUniformQuery.Text = "Query PPE Information";
			this.cmdUniformInventory = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUniformInventory
			// 
			this.cmdUniformInventory.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUniformInventory.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUniformInventory.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUniformInventory.Name = "cmdUniformInventory";
			this.cmdUniformInventory.TabIndex = 16;
			this.cmdUniformInventory.Text = "Manage Turn Out Inventory";
			this.cmdUpdateWDL = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdateWDL
			// 
			this.cmdUpdateWDL.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdateWDL.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpdateWDL.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdateWDL.Name = "cmdUpdateWDL";
			this.cmdUpdateWDL.TabIndex = 15;
			this.cmdUpdateWDL.Text = "Verify and Update WDL";
			this.Text = "TFD WDL & PPE Information";
			this.NoLimitUpdate = false;
			this.LaunderOnly = false;
			this.CurrRow = 0;
			this.SkipLogic = false;
			this.GetLastInsp = false;
			this.FirstTime = false;
			this.CurrBatt = "";
			this.CurrShift = "";
			this.frmPPEItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmPPEItem
			// 
			this.frmPPEItem.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmPPEItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmPPEItem.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.frmPPEItem.Name = "frmPPEItem";
			this.frmPPEItem.TabIndex = 62;
			this.frmPPEItem.Text = "PPE Item";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234737817901701", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text359636234737817921231", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Style1");
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.Locked = true;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text822636234737817940761");
			namedStyle4.CellType = textCellType2;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.Locked = true;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static907636234737817950526");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.Locked = true;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1155636234737818311831");
			namedStyle6.CellType = checkBoxCellType1;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = checkBoxCellType1;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox3437636234737818956321");
			namedStyle7.CellType = checkBoxCellType2;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = checkBoxCellType2;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3500636234737819014911");
			namedStyle8.CellType = textCellType4;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType4;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmNewPPEWDL";
			IsMdiChild = true;
			this.sprPPEList.NamedStyles.Add(namedStyle1);
			this.sprPPEList.NamedStyles.Add(namedStyle2);
			this.sprPPEList.NamedStyles.Add(namedStyle3);
			this.sprPPEList.NamedStyles.Add(namedStyle4);
			this.sprPPEList.NamedStyles.Add(namedStyle5);
			this.sprPPEList.NamedStyles.Add(namedStyle6);
			this.sprPPEList.NamedStyles.Add(namedStyle7);
			this.sprPPEList.NamedStyles.Add(namedStyle8);
			this.sprPPEList.Sheets.Add(this.sprPPEList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemType { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteIssued { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUniformID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtInspComment { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtInspection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLicenseID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWDL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExpireDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmpNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblAssignment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblVerify { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPPEList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPPEList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdFind { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCleaning { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReplaceItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEditItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdLastInsp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdInspection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRepair { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAllOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSizes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintChecklist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInactive { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdLaundryMgmt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdGlobe { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUniformQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUniformInventory { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdateWDL { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NoLimitUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean LaunderOnly { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean SkipLogic { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean GetLastInsp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmPPEItem { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}