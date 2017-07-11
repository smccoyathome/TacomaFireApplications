using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPPELaunder))]
	public class frmPPELaunderViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var checkBoxCellType5 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var checkBoxCellType4 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var checkBoxCellType3 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var checkBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var dateTimeCellType1 = ctx.Resolve<FarPoint.ViewModels.DateTimeCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var comboBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			var comboBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			this.sprPPEList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPPEList.MaxRows = 100;
			this.sprPPEList.TabIndex = 0;
			this.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 8;
			this.Label3.Text = "Name:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 7;
			this.Label4.Text = "Employee #:";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 6;
			this.Label5.Text = "Assignment:";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 5;
			this.lblName.Text = "lblName";
			this.lblEmpNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmpNum
			// 
			this.lblEmpNum.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblEmpNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmpNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblEmpNum.Name = "lblEmpNum";
			this.lblEmpNum.TabIndex = 4;
			this.lblEmpNum.Text = "lblEmpNum";
			this.lblAssignment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblAssignment
			// 
			this.lblAssignment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblAssignment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblAssignment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblAssignment.Name = "lblAssignment";
			this.lblAssignment.TabIndex = 3;
			this.lblAssignment.Text = "lblAssignment";
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1.SheetName = "Sheet1";
			this.sprPPEList_Sheet1.Cells.Get(0, 4).Value = "0";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 0].Value = "TurnOut Gear";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date Flagged";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Date Approved";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Laundry Instructions and Comments";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Cleaned?";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Launder_id";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 6].Value = "UniformID";
			this.sprPPEList_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
			this.sprPPEList_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
			this.sprPPEList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			this.sprPPEList_Sheet1.Columns.Get(0).Label = "TurnOut Gear";
			this.sprPPEList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.sprPPEList_Sheet1.Columns.Get(0).Width = 143F;
			this.sprPPEList_Sheet1.Columns.Get(1).Label = "Date Flagged";
			this.sprPPEList_Sheet1.Columns.Get(1).StyleName = "DateTime741636234758102472546";
			this.sprPPEList_Sheet1.Columns.Get(1).Width = 90F;
			this.sprPPEList_Sheet1.Columns.Get(2).Label = "Date Approved";
			this.sprPPEList_Sheet1.Columns.Get(2).StyleName = "DateTime741636234758102472546";
			this.sprPPEList_Sheet1.Columns.Get(2).Width = 83F;
			this.sprPPEList_Sheet1.Columns.Get(3).Label = "Laundry Instructions and Comments";
			this.sprPPEList_Sheet1.Columns.Get(3).StyleName = "Text909636234758102501841";
			this.sprPPEList_Sheet1.Columns.Get(3).Width = 253F;
			this.sprPPEList_Sheet1.Columns.Get(4).Label = "Cleaned?";
			//this.sprPPEList_Sheet1.Columns.Get(4).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprPPEList_Sheet1.Columns.Get(4).Width = 59F;
			this.sprPPEList_Sheet1.Columns.Get(5).Label = "Launder_id";
			this.sprPPEList_Sheet1.Columns.Get(5).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(5).Width = 0F;
			this.sprPPEList_Sheet1.Columns.Get(6).Label = "UniformID";
			this.sprPPEList_Sheet1.Columns.Get(6).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(6).Width = 0F;
			this.sprPPEList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 2;
			this.CancelButton_Renamed.Text = "Cancel";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.Text = "Emloyee\'s PPE Launder Information";
			this.iUniformID = 0;
			this.sDateFlagged = "";
			this.sDateApproved = "";
			this.sComment = "";
			this.iLaunderID = 0;
			this.UniformDescription = "";
			this.UniformTrackingNumber = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234758101701111", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234758101710876", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("ComboEx636636234758101994061");
			namedStyle3.CellType = comboBoxCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = comboBoxCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("DateTime741636234758102472546");
			namedStyle4.CellType = dateTimeCellType1;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = dateTimeCellType1;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text909636234758102501841");
			namedStyle5.CellType = textCellType2;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType2;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1457636234758102531136");
			namedStyle6.CellType = checkBoxCellType1;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = checkBoxCellType1;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text1560636234758102531136");
			namedStyle7.CellType = textCellType3;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1637636234758102824086");
			namedStyle8.CellType = checkBoxCellType2;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = checkBoxCellType2;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox3437636234758102872911");
			namedStyle9.CellType = checkBoxCellType3;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = checkBoxCellType3;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox3437636234758102960796");
			namedStyle10.CellType = checkBoxCellType4;
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = checkBoxCellType4;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox2317636234758118008661");
			namedStyle11.CellType = checkBoxCellType5;
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = checkBoxCellType5;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmPPELaunder";
			this.sprPPEList.NamedStyles.Add(namedStyle1);
			this.sprPPEList.NamedStyles.Add(namedStyle2);
			this.sprPPEList.NamedStyles.Add(namedStyle3);
			this.sprPPEList.NamedStyles.Add(namedStyle4);
			this.sprPPEList.NamedStyles.Add(namedStyle5);
			this.sprPPEList.NamedStyles.Add(namedStyle6);
			this.sprPPEList.NamedStyles.Add(namedStyle7);
			this.sprPPEList.NamedStyles.Add(namedStyle8);
			this.sprPPEList.NamedStyles.Add(namedStyle9);
			this.sprPPEList.NamedStyles.Add(namedStyle10);
			this.sprPPEList.NamedStyles.Add(namedStyle11);
			this.sprPPEList.Sheets.Add(this.sprPPEList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPPEList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmpNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblAssignment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPPEList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iUniformID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDateFlagged { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDateApproved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sComment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iLaunderID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String UniformDescription { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String UniformTrackingNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}