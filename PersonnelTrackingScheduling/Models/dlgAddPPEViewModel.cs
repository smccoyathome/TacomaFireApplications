using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgAddPPE))]
	public class dlgAddPPEViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var comboBoxCellType20 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var dateTimeCellType1 = ctx.Resolve<FarPoint.ViewModels.DateTimeCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var comboBoxCellType19 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			var comboBoxCellType18 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType17 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType16 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType15 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType14 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType13 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType12 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType11 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType10 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType9 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType8 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType7 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType6 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType5 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType4 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType3 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType2 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			var comboBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.ComboBoxCellType>();
			this.sprPPEList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPPEList.MaxRows = 8;
			this.sprPPEList.TabIndex = 2;
			this.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 9;
			this.Label1.Text = "*NOTE:  If there is no information added for an item, then it will not be added";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 8;
			this.Label3.Text = "Name:";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 7;
			this.Label4.Text = "Employee #:";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 6;
			this.Label5.Text = "Assignment:";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 5;
			this.lblName.Text = "lblName";
			this.lblEmpNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmpNum
			// 
			this.lblEmpNum.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lblEmpNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmpNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblEmpNum.Name = "lblEmpNum";
			this.lblEmpNum.TabIndex = 4;
			this.lblEmpNum.Text = "lblEmpNum";
			this.lblAssignment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblAssignment
			// 
			this.lblAssignment.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lblAssignment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblAssignment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblAssignment.Name = "lblAssignment";
			this.lblAssignment.TabIndex = 3;
			this.lblAssignment.Text = "lblAssignment";
			this.sprPPEList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPPEList_Sheet1.SheetName = "Sheet1";
			this.sprPPEList_Sheet1.Cells.Get(0, 1).CellType = comboBoxCellType1;
			this.sprPPEList_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(0, 2).CellType = comboBoxCellType2;
			this.sprPPEList_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(1, 1).CellType = comboBoxCellType3;
			this.sprPPEList_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(1, 2).CellType = comboBoxCellType4;
			this.sprPPEList_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(2, 1).CellType = comboBoxCellType5;
			this.sprPPEList_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(2, 2).CellType = comboBoxCellType6;
			this.sprPPEList_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(3, 1).CellType = comboBoxCellType7;
			this.sprPPEList_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(3, 2).CellType = comboBoxCellType8;
			this.sprPPEList_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(4, 1).CellType = comboBoxCellType9;
			this.sprPPEList_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(4, 2).CellType = comboBoxCellType10;
			this.sprPPEList_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(5, 1).CellType = comboBoxCellType11;
			this.sprPPEList_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(5, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(5, 2).CellType = comboBoxCellType12;
			this.sprPPEList_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(5, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(6, 1).CellType = comboBoxCellType13;
			this.sprPPEList_Sheet1.Cells.Get(6, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(6, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(6, 2).CellType = comboBoxCellType14;
			this.sprPPEList_Sheet1.Cells.Get(6, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(6, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(7, 1).CellType = comboBoxCellType15;
			this.sprPPEList_Sheet1.Cells.Get(7, 1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(7, 1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(7, 2).CellType = comboBoxCellType16;
			this.sprPPEList_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			this.sprPPEList_Sheet1.Cells.Get(7, 2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 0].Value = "ISSUE DATE";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 1].Value = "BRAND NAME";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 2].Value = "SIZE or COLOR";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 3].Value = "TRACKING NUMBER";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 4].Value = "MANUFACTURED  DATE";
			this.sprPPEList_Sheet1.ColumnHeader.Cells[0, 5].Value = "uniform_id";
			this.sprPPEList_Sheet1.ColumnHeader.Rows.Get(0).Height = 48F;
			this.sprPPEList_Sheet1.Columns.Get(0).Label = "ISSUE DATE";
			this.sprPPEList_Sheet1.Columns.Get(0).Width = 86F;
			this.sprPPEList_Sheet1.Columns.Get(1).CellType = comboBoxCellType17;
			this.sprPPEList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			this.sprPPEList_Sheet1.Columns.Get(1).Label = "BRAND NAME";
			this.sprPPEList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.sprPPEList_Sheet1.Columns.Get(1).Width = 110F;
			this.sprPPEList_Sheet1.Columns.Get(2).CellType = comboBoxCellType18;
			this.sprPPEList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			this.sprPPEList_Sheet1.Columns.Get(2).Label = "SIZE or COLOR";
			this.sprPPEList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.sprPPEList_Sheet1.Columns.Get(2).Width = 89F;
			this.sprPPEList_Sheet1.Columns.Get(3).Label = "TRACKING NUMBER";
			this.sprPPEList_Sheet1.Columns.Get(3).Width = 98F;
			this.sprPPEList_Sheet1.Columns.Get(4).Label = "MANUFACTURED  DATE";
			this.sprPPEList_Sheet1.Columns.Get(4).Width = 94F;
			this.sprPPEList_Sheet1.Columns.Get(5).Label = "uniform_id";
			this.sprPPEList_Sheet1.Columns.Get(5).Visible = false;
			this.sprPPEList_Sheet1.Columns.Get(5).Width = 0F;
			this.sprPPEList_Sheet1.RowHeader.Cells[0, 0].Value = "COAT";
			this.sprPPEList_Sheet1.RowHeader.Cells[1, 0].Value = "PANTS";
			this.sprPPEList_Sheet1.RowHeader.Cells[2, 0].Value = "HELMET";
			this.sprPPEList_Sheet1.RowHeader.Cells[3, 0].Value = "BOOTS";
			this.sprPPEList_Sheet1.RowHeader.Cells[4, 0].Value = "EAR FLAPS";
			this.sprPPEList_Sheet1.RowHeader.Cells[5, 0].Value = "FLASH HOOD";
			this.sprPPEList_Sheet1.RowHeader.Cells[6, 0].Value = "GLOVES";
			this.sprPPEList_Sheet1.RowHeader.Cells[7, 0].Value = "FIELD JACKET";
			this.sprPPEList_Sheet1.RowHeader.Columns.Get(0).Width = 61F;
			this.sprPPEList_Sheet1.Rows.Get(0).Height = 22F;
			this.sprPPEList_Sheet1.Rows.Get(0).Label = "COAT";
			this.sprPPEList_Sheet1.Rows.Get(1).Height = 22F;
			this.sprPPEList_Sheet1.Rows.Get(1).Label = "PANTS";
			this.sprPPEList_Sheet1.Rows.Get(2).Height = 22F;
			this.sprPPEList_Sheet1.Rows.Get(2).Label = "HELMET";
			this.sprPPEList_Sheet1.Rows.Get(3).Height = 22F;
			this.sprPPEList_Sheet1.Rows.Get(3).Label = "BOOTS";
			this.sprPPEList_Sheet1.Rows.Get(4).Height = 31F;
			this.sprPPEList_Sheet1.Rows.Get(4).Label = "EAR FLAPS";
			this.sprPPEList_Sheet1.Rows.Get(5).Height = 28F;
			this.sprPPEList_Sheet1.Rows.Get(5).Label = "FLASH HOOD";
			this.sprPPEList_Sheet1.Rows.Get(6).Height = 22F;
			this.sprPPEList_Sheet1.Rows.Get(6).Label = "GLOVES";
			this.sprPPEList_Sheet1.Rows.Get(7).Height = 29F;
			this.sprPPEList_Sheet1.Rows.Get(7).Label = "FIELD JACKET";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 1;
			this.CancelButton_Renamed.Text = "Cancel";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.Text = "Issue PPE to Employee";
			this.CurrRow = 0;
			this.EmployeeID = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234569260348641", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text342636234569260387701", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("ComboEx759636234569261071251");
			namedStyle3.CellType = comboBoxCellType19;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = comboBoxCellType19;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("DateTime1361636234569264713596");
			namedStyle4.CellType = dateTimeCellType1;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = dateTimeCellType1;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("ComboEx1385636234569264723361");
			namedStyle5.CellType = comboBoxCellType20;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = comboBoxCellType20;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text1465636234569264781951");
			namedStyle6.CellType = textCellType2;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType2;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.dlgAddPPE";
			this.sprPPEList.NamedStyles.Add(namedStyle1);
			this.sprPPEList.NamedStyles.Add(namedStyle2);
			this.sprPPEList.NamedStyles.Add(namedStyle3);
			this.sprPPEList.NamedStyles.Add(namedStyle4);
			this.sprPPEList.NamedStyles.Add(namedStyle5);
			this.sprPPEList.NamedStyles.Add(namedStyle6);
			this.sprPPEList.Sheets.Add(this.sprPPEList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPPEList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

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
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String EmployeeID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}