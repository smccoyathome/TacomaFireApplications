using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmGlobeData))]
	public class frmGlobeDataViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.cboStyle = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStyle
			// 
			this.cboStyle.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStyle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStyle.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStyle.Name = "cboStyle";
			this.cboStyle.TabIndex = 24;
			this.cboStyle.Text = "cboStyle";
			this.cboManufDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboManufDate
			// 
			this.cboManufDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboManufDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboManufDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboManufDate.Name = "cboManufDate";
			this.cboManufDate.TabIndex = 22;
			this.cboManufDate.Text = "cboManufDate";
			this.cboOrder = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOrder
			// 
			this.cboOrder.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboOrder.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboOrder.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboOrder.Name = "cboOrder";
			this.cboOrder.TabIndex = 16;
			this.cboOrder.Text = "cboOrder";
			this.cboColor = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboColor
			// 
			this.cboColor.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboColor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboColor.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboColor.Name = "cboColor";
			this.cboColor.TabIndex = 14;
			this.cboColor.Text = "cboColor";
			this.cboSleeve = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSleeve
			// 
			this.cboSleeve.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSleeve.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSleeve.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSleeve.Name = "cboSleeve";
			this.cboSleeve.TabIndex = 12;
			this.cboSleeve.Text = "cboSleeve";
			this.cboLength = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLength
			// 
			this.cboLength.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboLength.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboLength.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboLength.Name = "cboLength";
			this.cboLength.TabIndex = 10;
			this.cboLength.Text = "cboLength";
			this.cboChstWaist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboChstWaist
			// 
			this.cboChstWaist.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboChstWaist.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboChstWaist.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboChstWaist.Name = "cboChstWaist";
			this.cboChstWaist.TabIndex = 8;
			this.cboChstWaist.Text = "cboChstWaist";
			this.txtNameSearch = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNameSearch.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNameSearch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtNameSearch.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtNameSearch.Name = "txtNameSearch";
			this.txtNameSearch.TabIndex = 7;
			this.txtNameSearch.Text = "txtNameSearch";
			this.cboStation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStation
			// 
			this.cboStation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboStation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboStation.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboStation.Name = "cboStation";
			this.cboStation.TabIndex = 4;
			this.cboStation.Text = "cboStation";
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 2;
			this.cboType.Text = "cboType";
			this.sprList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprList.MaxRows = 5000;
			this.sprList.TabIndex = 0;
			this.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 23;
			this.Label10.Text = "Manufactured Date: ";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 18;
			this.Label9.Text = "Style #: ";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 17;
			this.Label8.Text = "Order #: ";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 15;
			this.Label7.Text = "Color: ";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 13;
			this.Label6.Text = "Sleeve Length: ";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 11;
			this.Label5.Text = "Length: ";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 9;
			this.Label4.Text = "Chest/Waiste Size: ";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 6;
			this.Label3.Text = "By Name: ";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Station: ";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Item Type: ";
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 1;
			this.lbCount.Text = "Total Count:  ";
			this.sprList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprList_Sheet1.SheetName = "Sheet1";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Co";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Type";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Serial #";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Order #";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Color";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Chst/Waist";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Length";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Sleeve";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Manuf. Date";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Style#";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 10].Value = "Issued To / Location";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 11].Value = "Issued / Retired Date";
			this.sprList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
			this.sprList_Sheet1.Columns.Get(0).Label = "Co";
			this.sprList_Sheet1.Columns.Get(0).Width = 22F;
			this.sprList_Sheet1.Columns.Get(1).Label = "Type";
			this.sprList_Sheet1.Columns.Get(1).Width = 48F;
			this.sprList_Sheet1.Columns.Get(2).Label = "Serial #";
			this.sprList_Sheet1.Columns.Get(2).Width = 70F;
			this.sprList_Sheet1.Columns.Get(3).Label = "Order #";
			this.sprList_Sheet1.Columns.Get(3).Width = 64F;
			this.sprList_Sheet1.Columns.Get(4).Label = "Color";
			this.sprList_Sheet1.Columns.Get(4).Width = 35F;
			this.sprList_Sheet1.Columns.Get(5).Label = "Chst/Waist";
			this.sprList_Sheet1.Columns.Get(5).Width = 58F;
			this.sprList_Sheet1.Columns.Get(6).Label = "Length";
			this.sprList_Sheet1.Columns.Get(6).Width = 40F;
			this.sprList_Sheet1.Columns.Get(7).Label = "Sleeve";
			this.sprList_Sheet1.Columns.Get(7).Width = 42F;
			this.sprList_Sheet1.Columns.Get(8).Label = "Manuf. Date";
			this.sprList_Sheet1.Columns.Get(8).Width = 57F;
			this.sprList_Sheet1.Columns.Get(9).Label = "Style#";
			this.sprList_Sheet1.Columns.Get(9).Width = 57F;
			this.sprList_Sheet1.Columns.Get(10).Label = "Issued To / Location";
			this.sprList_Sheet1.Columns.Get(10).Width = 101F;
			this.sprList_Sheet1.Columns.Get(11).Label = "Issued / Retired Date";
			//this.sprList_Sheet1.Columns.Get(11).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprList_Sheet1.Columns.Get(11).Width = 80F;
			this.sprList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprList_Sheet1.Rows.Get(0).Height = 14F;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 21;
			this.cmdClear.Text = "Clear Filters";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 20;
			this.cmdPrint.Text = "Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 19;
			this.cmdClose.Text = "Exit";
			this.Text = "Globe Data (Spreadsheet)";
			this.sHeadingFilter = "";
			this.FirstTime = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234712236818871", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static291636234712236838401", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmGlobeData";
			IsMdiChild = true;
			this.sprList.NamedStyles.Add(namedStyle1);
			this.sprList.NamedStyles.Add(namedStyle2);
			this.sprList.Sheets.Add(this.sprList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStyle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboManufDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOrder { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboColor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSleeve { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLength { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboChstWaist { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNameSearch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboType { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sHeadingFilter { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtNameSearch_TextChanged()
		{
			if ( _txtNameSearch_TextChanged != null )
				_txtNameSearch_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNameSearch_TextChanged;
	}

}