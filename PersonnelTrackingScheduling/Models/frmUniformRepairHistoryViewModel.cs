using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUniformRepairHistory))]
	public class frmUniformRepairHistoryViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var checkBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 31;
			this.cboRepairer = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRepairer
			// 
			this.cboRepairer.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRepairer.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRepairer.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboRepairer.Name = "cboRepairer";
			this.cboRepairer.TabIndex = 27;
			this.cboRepairer.Text = "cboRepairer";
			this.dteDateIn = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateIn.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateIn.Name = "dteDateIn";
			this.dteDateIn.TabIndex = 26;
			this.sprRepairGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRepairGrid.TabIndex = 21;
			this.sprRepairGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNumber.Name = "txtTrackingNumber";
			this.txtTrackingNumber.TabIndex = 19;
			this.txtTrackingNumber.Text = "txtTrackingNumber";
			this.lbLastInspDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastInspDate
			// 
			this.lbLastInspDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastInspDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLastInspDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbLastInspDate.Name = "lbLastInspDate";
			this.lbLastInspDate.TabIndex = 24;
			this.lbLastInspDate.Text = "lbLastInspDate";
			this._Label_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbUniformID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUniformID
			// 
			this.lbUniformID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUniformID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUniformID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbUniformID.Name = "lbUniformID";
			this.lbUniformID.TabIndex = 10;
			this.lbUniformID.Text = "lbUniformID";
			this.lbUniformID.Visible = false;
			this._Label_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItem
			// 
			this.lbItem.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbItem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbItem.Name = "lbItem";
			this.lbItem.TabIndex = 8;
			this.lbItem.Text = "lbItem";
			this.lbTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTrackingNumber
			// 
			this.lbTrackingNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrackingNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrackingNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbTrackingNumber.Name = "lbTrackingNumber";
			this.lbTrackingNumber.TabIndex = 7;
			this.lbTrackingNumber.Text = "lbTrackingNumber";
			this.lbRetiredReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredReason
			// 
			this.lbRetiredReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetiredReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbRetiredReason.Name = "lbRetiredReason";
			this.lbRetiredReason.TabIndex = 6;
			this.lbRetiredReason.Text = "lbRetiredReason";
			this.lbBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBrand
			// 
			this.lbBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbBrand.Name = "lbBrand";
			this.lbBrand.TabIndex = 5;
			this.lbBrand.Text = "lbBrand";
			this.lbManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbManufDate
			// 
			this.lbManufDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbManufDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbManufDate.Name = "lbManufDate";
			this.lbManufDate.TabIndex = 4;
			this.lbManufDate.Text = "lbManufDate";
			this.lbColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbColorSize
			// 
			this.lbColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbColorSize.Name = "lbColorSize";
			this.lbColorSize.TabIndex = 3;
			this.lbColorSize.Text = "lbColorSize";
			this.lbRetiredDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredDate
			// 
			this.lbRetiredDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetiredDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbRetiredDate.Name = "lbRetiredDate";
			this.lbRetiredDate.TabIndex = 2;
			this.lbRetiredDate.Text = "lbRetiredDate";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 1;
			this.lbLocation.Text = "lbLocation";
			this.dteDateOut = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteDateOut.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteDateOut.Name = "dteDateOut";
			this.dteDateOut.TabIndex = 33;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 30;
			this.Label2.Text = "Repairs Made & Comments:";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 29;
			this.Label1.Text = "Repaired By";
			this.lbRepairID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRepairID
			// 
			this.lbRepairID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRepairID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRepairID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRepairID.Name = "lbRepairID";
			this.lbRepairID.TabIndex = 28;
			this.lbRepairID.Text = "lbRepairID";
			this.lbRepairID.Visible = false;
			this._Label_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprRepairGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRepairGrid_Sheet1.SheetName = "Sheet1";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Date In";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date Out";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 2].Value = "Repaired By";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 3].Value = "Repairs Made & Comments";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 4].Value = "Vendor Cleaned?";
			this.sprRepairGrid_Sheet1.ColumnHeader.Cells[0, 5].Value = "RepairID";
			this.sprRepairGrid_Sheet1.ColumnHeader.Rows.Get(0).Height = 28F;
			this.sprRepairGrid_Sheet1.Columns.Get(0).Label = "Date In";
			this.sprRepairGrid_Sheet1.Columns.Get(0).Width = 64F;
			this.sprRepairGrid_Sheet1.Columns.Get(2).Label = "Repaired By";
			this.sprRepairGrid_Sheet1.Columns.Get(2).Width = 129F;
			this.sprRepairGrid_Sheet1.Columns.Get(3).Label = "Repairs Made & Comments";
			this.sprRepairGrid_Sheet1.Columns.Get(3).Width = 264F;
			this.sprRepairGrid_Sheet1.Columns.Get(4).Label = "Vendor Cleaned?";
			this.sprRepairGrid_Sheet1.Columns.Get(4).Width = 54F;
			this.sprRepairGrid_Sheet1.Columns.Get(5).Label = "RepairID";
			//this.sprRepairGrid_Sheet1.Columns.Get(5).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprRepairGrid_Sheet1.Columns.Get(5).Visible = false;
			this.sprRepairGrid_Sheet1.Columns.Get(5).Width = 0F;
			this.sprRepairGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdNewItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewItem
			// 
			this.cmdNewItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewItem.Name = "cmdNewItem";
			this.cmdNewItem.TabIndex = 35;
			this.cmdNewItem.Text = "New Item";
			this.cmdEdit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEdit
			// 
			this.cmdEdit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 34;
			this.cmdEdit.Tag = "1";
			this.cmdEdit.Text = "Add";
			this.chkDateOut = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDateOut
			// 
			this.chkDateOut.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkDateOut.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDateOut.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkDateOut.Name = "chkDateOut";
			this.chkDateOut.TabIndex = 32;
			this.chkDateOut.Text = "Date Out";
			this.chkDateIn = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDateIn
			// 
			this.chkDateIn.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkDateIn.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDateIn.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkDateIn.Name = "chkDateIn";
			this.chkDateIn.TabIndex = 25;
			this.chkDateIn.Text = "Date In";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 22;
			this.cmdClose.Text = "&Close";
			this.cmdFind = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdFind.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdFind.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.TabIndex = 18;
			this.cmdFind.Text = "Search...";
			this.Text = "PPE Uniform Repair History";
			this.LaundryRecordExists = false;
			this.chkVendor = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkVendor
			// 
			this.chkVendor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkVendor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkVendor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkVendor.Name = "chkVendor";
			this.chkVendor.TabIndex = 36;
			this.chkVendor.Text = "Vendor Cleaned Item";
			this.iCurrRow = 0;
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			Label[7] = _Label_7;
			Label[8] = _Label_8;
			Label[4] = _Label_4;
			Label[3] = _Label_3;
			Label[0] = _Label_0;
			Label[5] = _Label_5;
			Label[2] = _Label_2;
			Label[1] = _Label_1;
			Label[6] = _Label_6;
			Label[9] = _Label_9;
			Label[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[7].Name = "_Label_7";
			Label[7].TabIndex = 23;
			Label[7].Text = "Last Inspected:";
			Label[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[8].Name = "_Label_8";
			Label[8].TabIndex = 17;
			Label[8].Text = "Retired Date:";
			Label[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[4].Name = "_Label_4";
			Label[4].TabIndex = 16;
			Label[4].Text = "Retire Reason:";
			Label[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[3].Name = "_Label_3";
			Label[3].TabIndex = 15;
			Label[3].Text = "Location:";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 14;
			Label[0].Text = "PPE Item:";
			Label[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[5].Name = "_Label_5";
			Label[5].TabIndex = 13;
			Label[5].Text = "Brand:";
			Label[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[2].Name = "_Label_2";
			Label[2].TabIndex = 12;
			Label[2].Text = "Size/Color:";
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 11;
			Label[1].Text = "Tracking #:";
			Label[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label[6].Name = "_Label_6";
			Label[6].TabIndex = 9;
			Label[6].Text = "Manuf Date:";
			Label[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label[9].Name = "_Label_9";
			Label[9].TabIndex = 20;
			Label[9].Text = "Search by Tracking #:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234786393513366", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234786393523131", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1144636234786393562191");
			namedStyle3.CellType = checkBoxCellType1;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = checkBoxCellType1;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox3437636234786393581721");
			namedStyle4.CellType = checkBoxCellType2;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = checkBoxCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmUniformRepairHistory";
			IsMdiChild = true;
			this.sprRepairGrid.NamedStyles.Add(namedStyle1);
			this.sprRepairGrid.NamedStyles.Add(namedStyle2);
			this.sprRepairGrid.NamedStyles.Add(namedStyle3);
			this.sprRepairGrid.NamedStyles.Add(namedStyle4);
			this.sprRepairGrid.Sheets.Add(this.sprRepairGrid_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRepairer { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateIn { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRepairGrid { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastInspDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUniformID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTrackingNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteDateOut { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRepairID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_9 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRepairGrid_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEdit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDateOut { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDateIn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdFind { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean LaundryRecordExists { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkVendor { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iCurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}