using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgPPERepair))]
	public class dlgPPERepairViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var dateTimeCellType1 = ctx.Resolve<FarPoint.ViewModels.DateTimeCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var comboBoxCellType3 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			var comboBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			this.sprPPEList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPPEList.MaxRows = 100;
			this.sprPPEList.TabIndex = 8;
			this.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lblAssignment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblAssignment
			// 
			this.lblAssignment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblAssignment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblAssignment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblAssignment.Name = "lblAssignment";
			this.lblAssignment.TabIndex = 5;
			this.lblAssignment.Text = "lblAssignment";
			this.lblEmpNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmpNum
			// 
			this.lblEmpNum.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblEmpNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmpNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblEmpNum.Name = "lblEmpNum";
			this.lblEmpNum.TabIndex = 4;
			this.lblEmpNum.Text = "lblEmpNum";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 3;
			this.lblName.Text = "lblName";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 2;
			this.Label5.Text = "Assignment:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 1;
			this.Label4.Text = "Employee #:";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 0;
			this.Label3.Text = "Name:";
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1.SheetName = "Sheet1";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 0].Value = "TurnOut Gear";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Repairer";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Date In";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Date Out";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Repairs Made and Comments";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Vendor Cleaned?";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 6].Value = "RepairID";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 7].Value = "UniformID";
			this.sprPPEList_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
			this.sprPPEList_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
			this.sprPPEList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			this.sprPPEList_Sheet1.Columns.Get(0).Label = "TurnOut Gear";
			this.sprPPEList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.sprPPEList_Sheet1.Columns.Get(0).Width = 104F;
			this.sprPPEList_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
			this.sprPPEList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			this.sprPPEList_Sheet1.Columns.Get(1).Label = "Repairer";
			this.sprPPEList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.sprPPEList_Sheet1.Columns.Get(1).Width = 103F;
			this.sprPPEList_Sheet1.Columns.Get(2).Label = "Date In";
			this.sprPPEList_Sheet1.Columns.Get(2).StyleName = "DateTime803636234648919215786";
			this.sprPPEList_Sheet1.Columns.Get(3).Label = "Date Out";
			this.sprPPEList_Sheet1.Columns.Get(3).StyleName = "DateTime803636234648919215786";
			this.sprPPEList_Sheet1.Columns.Get(4).Label = "Repairs Made and Comments";
			this.sprPPEList_Sheet1.Columns.Get(4).StyleName = "Text931636234648919293906";
			this.sprPPEList_Sheet1.Columns.Get(4).Width = 253F;
			this.sprPPEList_Sheet1.Columns.Get(5).Label = "Vendor Cleaned?";
			this.sprPPEList_Sheet1.Columns.Get(5).StyleName = "CheckBox1031636234648920026281";
			this.sprPPEList_Sheet1.Columns.Get(6).Label = "RepairID";
			this.sprPPEList_Sheet1.Columns.Get(6).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(6).Width = 0F;
			this.sprPPEList_Sheet1.Columns.Get(7).Label = "UniformID";
			this.sprPPEList_Sheet1.Columns.Get(7).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(7).Width = 0F;
			this.sprPPEList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 7;
			this.OKButton.Text = "OK";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 6;
			this.CancelButton_Renamed.Text = "Cancel";
			this.Text = "Emloyee\'s PPE Repair Information";
			this.NoLimitUpdate = false;
			this.iUniformID = 0;
			this.iRepairerID = 0;
			this.CreateLaunderRecord = false;
			this.iRepairID = 0;
			this.sDateIn = "";
			this.sDateOut = "";
			this.sComment = "";
			this.UniformDescription = "";
			this.UniformTrackingNumber = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234648919157196", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234648919176726", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("ComboEx636636234648919186491");
			namedStyle3.CellType = comboBoxCellType3;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = comboBoxCellType3;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("DateTime803636234648919215786");
			namedStyle4.CellType = dateTimeCellType1;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = dateTimeCellType1;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text931636234648919293906");
			namedStyle5.CellType = textCellType2;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType2;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1031636234648920026281");
			namedStyle6.CellType = checkBoxCellType1;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = checkBoxCellType1;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text1508636234648920055576");
			namedStyle7.CellType = textCellType3;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.dlgPPERepair";
			this.sprPPEList.NamedStyles.Add(namedStyle1);
			this.sprPPEList.NamedStyles.Add(namedStyle2);
			this.sprPPEList.NamedStyles.Add(namedStyle3);
			this.sprPPEList.NamedStyles.Add(namedStyle4);
			this.sprPPEList.NamedStyles.Add(namedStyle5);
			this.sprPPEList.NamedStyles.Add(namedStyle6);
			this.sprPPEList.NamedStyles.Add(namedStyle7);
			this.sprPPEList.Sheets.Add(this.sprPPEList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPPEList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblAssignment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmpNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPPEList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NoLimitUpdate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iUniformID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iRepairerID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean CreateLaunderRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iRepairID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDateIn { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDateOut { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sComment { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String UniformDescription { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String UniformTrackingNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}