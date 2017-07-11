using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmLaunderMgmt))]
	public class frmLaunderMgmtViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtLaundryComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLaundryComment.Name = "txtLaundryComment";
			this.txtLaundryComment.TabIndex = 22;
			this.cboName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboName
			// 
			this.cboName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboName.Name = "cboName";
			this.cboName.TabIndex = 21;
			this.cboName.Text = "cboName";
			this.dteDateCleaned = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateCleaned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateCleaned.Name = "dteDateCleaned";
			this.dteDateCleaned.TabIndex = 20;
			this.lbLaunderID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLaunderID
			// 
			this.lbLaunderID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbLaunderID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbLaunderID.Name = "lbLaunderID";
			this.lbLaunderID.TabIndex = 29;
			this.lbLaunderID.Text = "lbLaunderID";
			this.lbLaunderID.Visible = false;
			this.txtPPEInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// txtPPEInfo
			// 
			this.txtPPEInfo.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.txtPPEInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPPEInfo.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.txtPPEInfo.Name = "txtPPEInfo";
			this.txtPPEInfo.TabIndex = 26;
			this.txtPPEInfo.Text = "txtPPEInfo";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 25;
			this.Label4.Text = "Comments";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 24;
			this.Label3.Text = "Cleaned By";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 23;
			this.Label2.Text = "Date Cleaned";
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 14;
			this.cboType.Text = "cboType";
			this.cboBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBrand
			// 
			this.cboBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBrand.Name = "cboBrand";
			this.cboBrand.TabIndex = 13;
			this.cboBrand.Text = "cboBrand";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 11;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 10;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 9;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 8;
			this.optA.Text = "Shift A";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt183.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 32;
			this.opt183.Text = "Batt 3";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 6;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 5;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 4;
			this.opt181.Text = "Batt 1";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 18;
			this.Label1.Text = "Item Type: ";
			this.lbBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBrand
			// 
			this.lbBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbBrand.Name = "lbBrand";
			this.lbBrand.TabIndex = 17;
			this.lbBrand.Text = "Manufacturer: ";
			this.lbTotalCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalCount
			// 
			this.lbTotalCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalCount.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbTotalCount.Name = "lbTotalCount";
			this.lbTotalCount.TabIndex = 16;
			this.lbTotalCount.Text = "List Count:  0";
			this.sprList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprList.MaxRows = 5000;
			this.sprList.TabIndex = 0;
			this.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprList_Sheet1.SheetName = "Sheet1";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Sta #";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Type";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Tracking #";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Size/Color";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Brand";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Issued Date";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Issued To";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Last Inspected";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Out for Repair";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Flagged for Cleaning";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 10].Value = "UniformID";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 11].Value = "LaunderID";
			this.sprList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
			this.sprList_Sheet1.Columns.Get(0).Label = "Sta #";
			this.sprList_Sheet1.Columns.Get(0).Width = 34F;
			this.sprList_Sheet1.Columns.Get(1).Label = "Type";
			this.sprList_Sheet1.Columns.Get(1).Width = 81F;
			this.sprList_Sheet1.Columns.Get(2).Label = "Tracking #";
			this.sprList_Sheet1.Columns.Get(2).Width = 74F;
			this.sprList_Sheet1.Columns.Get(3).Label = "Size/Color";
			this.sprList_Sheet1.Columns.Get(3).Width = 77F;
			this.sprList_Sheet1.Columns.Get(4).Label = "Brand";
			this.sprList_Sheet1.Columns.Get(4).Width = 90F;
			this.sprList_Sheet1.Columns.Get(5).Label = "Issued Date";
			this.sprList_Sheet1.Columns.Get(5).Width = 52F;
			this.sprList_Sheet1.Columns.Get(6).Label = "Issued To";
			this.sprList_Sheet1.Columns.Get(6).Width = 110F;
			this.sprList_Sheet1.Columns.Get(9).Label = "Flagged for Cleaning";
			this.sprList_Sheet1.Columns.Get(9).Width = 67F;
			this.sprList_Sheet1.Columns.Get(10).Label = "UniformID";
			//this.sprList_Sheet1.Columns.Get(10).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprList_Sheet1.Columns.Get(10).Visible = false;
			this.sprList_Sheet1.Columns.Get(10).Width = 0F;
			this.sprList_Sheet1.Columns.Get(11).Label = "LaunderID";
			this.sprList_Sheet1.Columns.Get(11).Visible = false;
			this.sprList_Sheet1.Columns.Get(11).Width = 0F;
			this.sprList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprList_Sheet1.Rows.Get(0).Height = 14F;
			this.sprList_Sheet1.Rows.Get(2).Height = 14F;
			this.chkVendor = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkVendor
			// 
			this.chkVendor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkVendor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkVendor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkVendor.Name = "chkVendor";
			this.chkVendor.TabIndex = 31;
			this.chkVendor.Text = "Vendor?";
			this.cmdClearFields = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearFields
			// 
			this.cmdClearFields.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearFields.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearFields.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearFields.Name = "cmdClearFields";
			this.cmdClearFields.TabIndex = 28;
			this.cmdClearFields.Text = "Clear Fields";
			this.cmdUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdate.Enabled = false;
			this.cmdUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpdate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.TabIndex = 27;
			this.cmdUpdate.Text = "Update Information";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 15;
			this.cmdClose.Text = "&Close";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 12;
			this.cmdClear.Text = "Clear Filters";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.Text = "Print List";
			this.Text = "PPE Cleaning/Launder Management";
			this.CurrRow = 0;
			this.sHeadingFilter = "";
			this.CurrBatt = "";
			this.CurrShift = "";
			this.chkApproveItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkApproveItem
			// 
			this.chkApproveItem.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkApproveItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkApproveItem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkApproveItem.Name = "chkApproveItem";
			this.chkApproveItem.TabIndex = 30;
			this.chkApproveItem.Text = "PPE Item Can Be Used";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234730488634476", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text307636234730488654006", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmLaunderMgmt";
			IsMdiChild = true;
			this.sprList.NamedStyles.Add(namedStyle1);
			this.sprList.NamedStyles.Add(namedStyle2);
			this.sprList.Sheets.Add(this.sprList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLaundryComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboName { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateCleaned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLaunderID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel txtPPEInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalCount { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkVendor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearFields { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sHeadingFilter { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkApproveItem { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}