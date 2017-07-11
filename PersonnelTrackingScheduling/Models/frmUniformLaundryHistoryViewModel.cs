using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUniformLaundryHistory))]
	public class frmUniformLaundryHistoryViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.cboCleanedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCleanedBy
			// 
			this.cboCleanedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCleanedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCleanedBy.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCleanedBy.Name = "cboCleanedBy";
			this.cboCleanedBy.TabIndex = 39;
			this.cboCleanedBy.Text = "cboCleanedBy";
			this.dteDateCleaned = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateCleaned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateCleaned.Name = "dteDateCleaned";
			this.dteDateCleaned.TabIndex = 36;
			this.txtLaundryComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLaundryComment.Name = "txtLaundryComment";
			this.txtLaundryComment.TabIndex = 42;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 40;
			this.Label4.Text = "Laundry Comment";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 38;
			this.Label2.Text = "Cleaned By";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 26;
			this.lbLocation.Text = "lbLocation";
			this.lbRetiredDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredDate
			// 
			this.lbRetiredDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetiredDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbRetiredDate.Name = "lbRetiredDate";
			this.lbRetiredDate.TabIndex = 25;
			this.lbRetiredDate.Text = "lbRetiredDate";
			this.lbColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbColorSize
			// 
			this.lbColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbColorSize.Name = "lbColorSize";
			this.lbColorSize.TabIndex = 24;
			this.lbColorSize.Text = "lbColorSize";
			this.lbManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbManufDate
			// 
			this.lbManufDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbManufDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbManufDate.Name = "lbManufDate";
			this.lbManufDate.TabIndex = 23;
			this.lbManufDate.Text = "lbManufDate";
			this.lbBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBrand
			// 
			this.lbBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbBrand.Name = "lbBrand";
			this.lbBrand.TabIndex = 22;
			this.lbBrand.Text = "lbBrand";
			this.lbRetiredReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredReason
			// 
			this.lbRetiredReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetiredReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbRetiredReason.Name = "lbRetiredReason";
			this.lbRetiredReason.TabIndex = 21;
			this.lbRetiredReason.Text = "lbRetiredReason";
			this.lbTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTrackingNumber
			// 
			this.lbTrackingNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrackingNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrackingNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbTrackingNumber.Name = "lbTrackingNumber";
			this.lbTrackingNumber.TabIndex = 20;
			this.lbTrackingNumber.Text = "lbTrackingNumber";
			this.lbItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItem
			// 
			this.lbItem.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbItem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbItem.Name = "lbItem";
			this.lbItem.TabIndex = 19;
			this.lbItem.Text = "lbItem";
			this._Label_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbUniformID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUniformID
			// 
			this.lbUniformID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUniformID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUniformID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbUniformID.Name = "lbUniformID";
			this.lbUniformID.TabIndex = 17;
			this.lbUniformID.Text = "lbUniformID";
			this.lbUniformID.Visible = false;
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbLastInspDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastInspDate
			// 
			this.lbLastInspDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastInspDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLastInspDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbLastInspDate.Name = "lbLastInspDate";
			this.lbLastInspDate.TabIndex = 8;
			this.lbLastInspDate.Text = "lbLastInspDate";
			this.txtTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTrackingNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNumber.Name = "txtTrackingNumber";
			this.txtTrackingNumber.TabIndex = 1;
			this.txtTrackingNumber.Text = "txtTrackingNumber";
			this.sprLaunderGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprLaunderGrid.TabIndex = 6;
			this.sprLaunderGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboFlaggedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFlaggedBy
			// 
			this.cboFlaggedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFlaggedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboFlaggedBy.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFlaggedBy.Name = "cboFlaggedBy";
			this.cboFlaggedBy.TabIndex = 33;
			this.cboFlaggedBy.Text = "cboFlaggedBy";
			this.dteDateFlagged = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateFlagged.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateFlagged.Name = "dteDateFlagged";
			this.dteDateFlagged.TabIndex = 30;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 41;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 34;
			this.Label3.Text = "Comment";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 32;
			this.Label1.Text = "Flagged By";
			this.lbLaunderID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLaunderID
			// 
			this.lbLaunderID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLaunderID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLaunderID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbLaunderID.Name = "lbLaunderID";
			this.lbLaunderID.TabIndex = 27;
			this.lbLaunderID.Text = "lbLaunderID";
			this.lbLaunderID.Visible = false;
			this._Label_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprLaunderGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLaunderGrid_Sheet1.SheetName = "Sheet1";
			this.sprLaunderGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Flagged - Date/By";
			this.sprLaunderGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "Cleaned - Date/By";
			this.sprLaunderGrid_Sheet1.ColumnHeader.Cells[0, 2].Value = "Approved - Date/By";
			this.sprLaunderGrid_Sheet1.ColumnHeader.Cells[0, 3].Value = "LaunderID";
			this.sprLaunderGrid_Sheet1.Columns.Get(0).Label = "Flagged - Date/By";
			this.sprLaunderGrid_Sheet1.Columns.Get(0).Width = 169F;
			this.sprLaunderGrid_Sheet1.Columns.Get(1).Label = "Cleaned - Date/By";
			this.sprLaunderGrid_Sheet1.Columns.Get(1).Width = 179F;
			this.sprLaunderGrid_Sheet1.Columns.Get(2).Label = "Approved - Date/By";
			this.sprLaunderGrid_Sheet1.Columns.Get(2).Width = 174F;
			this.sprLaunderGrid_Sheet1.Columns.Get(3).Label = "LaunderID";
			//this.sprLaunderGrid_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprLaunderGrid_Sheet1.Columns.Get(3).Visible = false;
			this.sprLaunderGrid_Sheet1.Columns.Get(3).Width = 0F;
			this.sprLaunderGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.chkVendor = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkVendor
			// 
			this.chkVendor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkVendor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkVendor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkVendor.Name = "chkVendor";
			this.chkVendor.TabIndex = 43;
			this.chkVendor.Text = "Vendor?";
			this.chkCleaned = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCleaned
			// 
			this.chkCleaned.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkCleaned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCleaned.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkCleaned.Name = "chkCleaned";
			this.chkCleaned.TabIndex = 37;
			this.chkCleaned.Text = "Cleaned?";
			this.chkApproved = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkApproved
			// 
			this.chkApproved.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkApproved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkApproved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkApproved.Name = "chkApproved";
			this.chkApproved.TabIndex = 28;
			this.chkApproved.Text = "PPE Item is ready for Use?";
			this.cmdEdit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEdit
			// 
			this.cmdEdit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 5;
			this.cmdEdit.Tag = "1";
			this.cmdEdit.Text = "Add";
			this.cmdNewItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewItem
			// 
			this.cmdNewItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewItem.Name = "cmdNewItem";
			this.cmdNewItem.TabIndex = 4;
			this.cmdNewItem.Text = "New Item";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 3;
			this.cmdClose.Text = "&Close";
			this.cmdFind = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdFind.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdFind.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.TabIndex = 0;
			this.cmdFind.Text = "Search...";
			this.chkFlagged = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkFlagged
			// 
			this.chkFlagged.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkFlagged.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkFlagged.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkFlagged.Name = "chkFlagged";
			this.chkFlagged.TabIndex = 31;
			this.chkFlagged.Text = "Flagged?";
			this.Text = "frmUniformLaundryHistory";
			this.iCurrRow = 0;
			this.bAllowUpdate = false;
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			Label[6] = _Label_6;
			Label[1] = _Label_1;
			Label[2] = _Label_2;
			Label[5] = _Label_5;
			Label[0] = _Label_0;
			Label[3] = _Label_3;
			Label[4] = _Label_4;
			Label[8] = _Label_8;
			Label[7] = _Label_7;
			Label[9] = _Label_9;
			Label[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[6].Name = "_Label_6";
			Label[6].TabIndex = 18;
			Label[6].Text = "Manuf Date:";
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 16;
			Label[1].Text = "Tracking #:";
			Label[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[2].Name = "_Label_2";
			Label[2].TabIndex = 15;
			Label[2].Text = "Size/Color:";
			Label[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[5].Name = "_Label_5";
			Label[5].TabIndex = 14;
			Label[5].Text = "Brand:";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 13;
			Label[0].Text = "PPE Item:";
			Label[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[3].Name = "_Label_3";
			Label[3].TabIndex = 12;
			Label[3].Text = "Location:";
			Label[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[4].Name = "_Label_4";
			Label[4].TabIndex = 11;
			Label[4].Text = "Retire Reason:";
			Label[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[8].Name = "_Label_8";
			Label[8].TabIndex = 10;
			Label[8].Text = "Retired Date:";
			Label[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[7].Name = "_Label_7";
			Label[7].TabIndex = 9;
			Label[7].Text = "Last Inspected:";
			Label[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label[9].Name = "_Label_9";
			Label[9].TabIndex = 2;
			Label[9].Text = "Search by Tracking #:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234785674438296", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234785674448061", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmUniformLaundryHistory";
			IsMdiChild = true;
			this.sprLaunderGrid.NamedStyles.Add(namedStyle1);
			this.sprLaunderGrid.NamedStyles.Add(namedStyle2);
			this.sprLaunderGrid.Sheets.Add(this.sprLaunderGrid_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCleanedBy { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateCleaned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLaundryComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTrackingNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUniformID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastInspDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNumber { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprLaunderGrid { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFlaggedBy { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateFlagged { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLaunderID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_9 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLaunderGrid_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkVendor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCleaned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkApproved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEdit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdFind { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkFlagged { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iCurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bAllowUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}