using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPPEInventory))]
	public class frmPPEInventoryViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtInspComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtInspComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtInspComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtInspComment.Name = "txtInspComment";
			this.txtInspComment.TabIndex = 45;
			this.txtInspComment.Text = "txtInspComment";
			this.dtInspection = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtInspection.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtInspection.Name = "dtInspection";
			this.dtInspection.TabIndex = 47;
			this.lbInspID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInspID
			// 
			this.lbInspID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInspID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbInspID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbInspID.Name = "lbInspID";
			this.lbInspID.TabIndex = 51;
			this.lbInspID.Text = "lbInspID";
			this.lbInspID.Visible = false;
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 49;
			this.Label8.Text = "Inspection Date";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 48;
			this.Label12.Text = "Comment";
			this.txtAlternate = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAlternate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAlternate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAlternate.Name = "txtAlternate";
			this.txtAlternate.TabIndex = 53;
			this.txtAlternate.Text = "txtAlternate";
			this.cboStation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStation
			// 
			this.cboStation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStation.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStation.Name = "cboStation";
			this.cboStation.TabIndex = 43;
			this.cboStation.Text = "cboStation";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 16;
			this.cboReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReason
			// 
			this.cboReason.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboReason.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReason.Name = "cboReason";
			this.cboReason.TabIndex = 14;
			this.cboReason.Text = "cboReason";
			this.cboItemType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemType
			// 
			this.cboItemType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemType.Name = "cboItemType";
			this.cboItemType.TabIndex = 11;
			this.cboItemType.Text = "cboItemType";
			this.cboItemBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemBrand
			// 
			this.cboItemBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemBrand.Name = "cboItemBrand";
			this.cboItemBrand.TabIndex = 13;
			this.cboItemBrand.Text = "cboItemBrand";
			this.cboItemColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboItemColorSize
			// 
			this.cboItemColorSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboItemColorSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboItemColorSize.Name = "cboItemColorSize";
			this.cboItemColorSize.TabIndex = 12;
			this.cboItemColorSize.Text = "cboItemColorSize";
			this.txtTrackingNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNumber.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNumber.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNumber.Name = "txtTrackingNumber";
			this.txtTrackingNumber.TabIndex = 7;
			this.txtTrackingNumber.Text = "txtTrackingNumber";
			this.dteManufDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteManufDate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dteManufDate.Name = "dteManufDate";
			this.dteManufDate.TabIndex = 10;
			this.dteManufDate.Visible = false;
			this.dteRetired = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteRetired.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dteRetired.Name = "dteRetired";
			this.dteRetired.TabIndex = 15;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 54;
			this.Label3.Text = "<< Rack #";
			this.lbRetiredDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetiredDate
			// 
			this.lbRetiredDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetiredDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetiredDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbRetiredDate.Name = "lbRetiredDate";
			this.lbRetiredDate.TabIndex = 37;
			this.lbRetiredDate.Text = "Retired Date";
			this.lbRetireComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRetireComment
			// 
			this.lbRetireComment.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRetireComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRetireComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbRetireComment.Name = "lbRetireComment";
			this.lbRetireComment.TabIndex = 36;
			this.lbRetireComment.Text = "Retire Comment";
			this.lbReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReason
			// 
			this.lbReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbReason.Name = "lbReason";
			this.lbReason.TabIndex = 34;
			this.lbReason.Text = "Retire Reason";
			this.label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// label13
			// 
			this.label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.label13.Name = "label13";
			this.label13.TabIndex = 33;
			this.label13.Text = "Station";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 32;
			this.Label14.Text = "PPE Item";
			this.lbItemBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItemBrand
			// 
			this.lbItemBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItemBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbItemBrand.Name = "lbItemBrand";
			this.lbItemBrand.TabIndex = 31;
			this.lbItemBrand.Text = "Brand/Manufacturer";
			this.lbItemColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbItemColorSize
			// 
			this.lbItemColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbItemColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbItemColorSize.Name = "lbItemColorSize";
			this.lbItemColorSize.TabIndex = 30;
			this.lbItemColorSize.Text = "Size/Color";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 29;
			this.Label17.Text = "Tracking / Barcode";
			this.lbUniformID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUniformID
			// 
			this.lbUniformID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUniformID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUniformID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbUniformID.Name = "lbUniformID";
			this.lbUniformID.TabIndex = 28;
			this.lbUniformID.Text = "lbUniformID";
			this.lbUniformID.Visible = false;
			this.sprPPEList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPPEList.MaxRows = 1000;
			this.sprPPEList.TabIndex = 20;
			this.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboColorSize
			// 
			this.cboColorSize.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboColorSize.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboColorSize.Name = "cboColorSize";
			this.cboColorSize.TabIndex = 3;
			this.cboColorSize.Text = "cboColorSize";
			this.cboBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBrand
			// 
			this.cboBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBrand.Name = "cboBrand";
			this.cboBrand.TabIndex = 2;
			this.cboBrand.Text = "cboBrand";
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 1;
			this.cboType.Text = "cboType";
			this.cboLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLocation
			// 
			this.cboLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboLocation.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboLocation.Name = "cboLocation";
			this.cboLocation.TabIndex = 0;
			this.cboLocation.Text = "cboLocation";
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 35;
			this.lbCount.Text = "List Count:  ";
			this.lbColorSize = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbColorSize
			// 
			this.lbColorSize.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbColorSize.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbColorSize.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbColorSize.Name = "lbColorSize";
			this.lbColorSize.TabIndex = 26;
			this.lbColorSize.Text = "Color / Size: ";
			this.lbBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBrand
			// 
			this.lbBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbBrand.Name = "lbBrand";
			this.lbBrand.TabIndex = 25;
			this.lbBrand.Text = "Manufacturer: ";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 24;
			this.Label2.Text = "Item Type: ";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 23;
			this.Label1.Text = "Station: ";
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 1000;
			this.sprReport.TabIndex = 38;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport.Visible = false;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //Mobilize: Not supported:[AnGamboa]
            //this.sprReport_Sheet1.AlternatingRows[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.sprReport_Sheet1.AlternatingRows[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Station";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Item";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Tracking #";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Rack #";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Color / Size";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 5].Value = "Manufacturer";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 6].Value = "Manuf Date";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 7].Value = "Last Insp";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 8].Value = "System ID";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 49F;
			this.sprReport_Sheet1.Columns.Get(0).Label = "Station";
			this.sprReport_Sheet1.Columns.Get(0).Width = 52F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Item";
			this.sprReport_Sheet1.Columns.Get(1).Width = 74F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Tracking #";
			this.sprReport_Sheet1.Columns.Get(2).Width = 90F;
			this.sprReport_Sheet1.Columns.Get(3).Label = "Rack #";
			this.sprReport_Sheet1.Columns.Get(3).Width = 85F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Color / Size";
			this.sprReport_Sheet1.Columns.Get(4).Width = 102F;
			this.sprReport_Sheet1.Columns.Get(5).Label = "Manufacturer";
			this.sprReport_Sheet1.Columns.Get(5).Width = 119F;
			this.sprReport_Sheet1.Columns.Get(6).Label = "Manuf Date";
			this.sprReport_Sheet1.Columns.Get(6).Width = 75F;
			this.sprReport_Sheet1.Columns.Get(7).Label = "Last Insp";
			this.sprReport_Sheet1.Columns.Get(7).Width = 68F;
			this.sprReport_Sheet1.Columns.Get(8).Label = "System ID";
			this.sprReport_Sheet1.Columns.Get(8).Width = 73F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1.SheetName = "Sheet1";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Sta";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Item";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Tracking #";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Rack #";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Color / Size";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Manufacturer";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Manuf Date";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Last Inspected";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 8].Value = "System ID";
			this.sprPPEList_Sheet1.ColumnHeader.Rows.Get(0).Height = 29F;
			this.sprPPEList_Sheet1.Columns.Get(0).Label = "Sta";
			this.sprPPEList_Sheet1.Columns.Get(0).Width = 32F;
			this.sprPPEList_Sheet1.Columns.Get(1).Label = "Item";
			this.sprPPEList_Sheet1.Columns.Get(1).Width = 54F;
			this.sprPPEList_Sheet1.Columns.Get(2).Label = "Tracking #";
			this.sprPPEList_Sheet1.Columns.Get(2).Width = 71F;
			this.sprPPEList_Sheet1.Columns.Get(3).Label = "Rack #";
			//this.sprPPEList_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprPPEList_Sheet1.Columns.Get(3).Width = 65F;
			this.sprPPEList_Sheet1.Columns.Get(4).Label = "Color / Size";
			this.sprPPEList_Sheet1.Columns.Get(4).Width = 54F;
			this.sprPPEList_Sheet1.Columns.Get(5).Label = "Manufacturer";
			this.sprPPEList_Sheet1.Columns.Get(5).Width = 93F;
			this.sprPPEList_Sheet1.Columns.Get(6).Label = "Manuf Date";
			this.sprPPEList_Sheet1.Columns.Get(6).Width = 67F;
			this.sprPPEList_Sheet1.Columns.Get(8).Label = "System ID";
			this.sprPPEList_Sheet1.Columns.Get(8).Width = 42F;
			this.sprPPEList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPPEList_Sheet1.Rows.Get(0).Height = 14F;
			this.cmdLastInsp = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdLastInsp
			// 
			this.cmdLastInsp.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdLastInsp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdLastInsp.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdLastInsp.Name = "cmdLastInsp";
			this.cmdLastInsp.TabIndex = 50;
			this.cmdLastInsp.Tag = "0";
			this.cmdLastInsp.Text = "Get Last Inspection";
			this.cmdAddNew = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNew
			// 
			this.cmdAddNew.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNew.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddNew.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.TabIndex = 46;
			this.cmdAddNew.Tag = "0";
			this.cmdAddNew.Text = "Add Inspection";
			this.cmdRepair = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRepair
			// 
			this.cmdRepair.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRepair.Enabled = false;
			this.cmdRepair.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRepair.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRepair.Name = "cmdRepair";
			this.cmdRepair.TabIndex = 41;
			this.cmdRepair.Text = "Repair History";
			this.cmdCleaning = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCleaning
			// 
			this.cmdCleaning.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCleaning.Enabled = false;
			this.cmdCleaning.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCleaning.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCleaning.Name = "cmdCleaning";
			this.cmdCleaning.TabIndex = 40;
			this.cmdCleaning.Text = "Laundry History";
			this.cmdReactivate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReactivate
			// 
			this.cmdReactivate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReactivate.Enabled = false;
			this.cmdReactivate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReactivate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReactivate.Name = "cmdReactivate";
			this.cmdReactivate.TabIndex = 39;
			this.cmdReactivate.Text = "Unretire Item";
			this.cmdFind = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdFind.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdFind.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.TabIndex = 8;
			this.cmdFind.Text = "Find...";
			this.cmdEditItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEditItem
			// 
			this.cmdEditItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEditItem.Enabled = false;
			this.cmdEditItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEditItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEditItem.Name = "cmdEditItem";
			this.cmdEditItem.TabIndex = 17;
			this.cmdEditItem.Tag = "1";
			this.cmdEditItem.Text = "Add";
			this.cmdNewItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdNewItem
			// 
			this.cmdNewItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdNewItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdNewItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdNewItem.Name = "cmdNewItem";
			this.cmdNewItem.TabIndex = 6;
			this.cmdNewItem.Text = "New Item";
			this.cmdRetireItem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRetireItem
			// 
			this.cmdRetireItem.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRetireItem.Enabled = false;
			this.cmdRetireItem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRetireItem.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRetireItem.Name = "cmdRetireItem";
			this.cmdRetireItem.TabIndex = 18;
			this.cmdRetireItem.Text = "Retire Item";
			this.chkManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkManufDate
			// 
			this.chkManufDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkManufDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkManufDate.Name = "chkManufDate";
			this.chkManufDate.TabIndex = 9;
			this.chkManufDate.Text = "PPE Manufacturered Date?";
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 42;
			this.cmdRefresh.Text = "Refresh Grid";
			this.chkInactive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInactive
			// 
			this.chkInactive.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkInactive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, ((UpgradeHelpers.
					Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInactive.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.TabIndex = 21;
			this.chkInactive.Text = "Display Retired/Inactive Items";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 5;
			this.cmdPrint.Text = "Print List";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 4;
			this.cmdClear.Text = "Clear Filters";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 19;
			this.cmdExit.Text = "Exit";
			this.Text = "TFD PPE Inventory Management";
			this.chkPassed = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPassed
			// 
			this.chkPassed.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkPassed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPassed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.chkPassed.Name = "chkPassed";
			this.chkPassed.TabIndex = 52;
			this.chkPassed.Text = "OK? (Passed)";
			this.bRetireItem = false;
			this.CurrRow = 0;
			this.FirstTime = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234757681952586", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static249636234757681972116", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234757786242786", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static265636234757786252551", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmPPEInventory";
			IsMdiChild = true;
			this.sprPPEList.NamedStyles.Add(namedStyle1);
			this.sprPPEList.NamedStyles.Add(namedStyle2);
			this.sprPPEList.Sheets.Add(this.sprPPEList_Sheet1);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.NamedStyles.Add(namedStyle4);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtInspComment { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtInspection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInspID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAlternate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboItemColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNumber { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteManufDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteRetired { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetiredDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRetireComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItemBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbItemColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUniformID { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPPEList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbColorSize { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPPEList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdLastInsp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNew { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRepair { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCleaning { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReactivate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdFind { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEditItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdNewItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRetireItem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInactive { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPassed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean bRetireItem { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtTrackingNumber_TextChanged()
		{
			if ( _txtTrackingNumber_TextChanged != null )
				_txtTrackingNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtTrackingNumber_TextChanged;
	}

}