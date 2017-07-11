using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmRosterFiltered))]
	public class frmRosterFilteredViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprPhone = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPhone.TabIndex = 15;
			this.sprPhone.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprContact = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprContact.TabIndex = 16;
			this.sprContact.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this._Label4_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label4_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboShift
			// 
			this.cboShift.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboShift.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboShift.Name = "cboShift";
			this.cboShift.TabIndex = 21;
			this.cboShift.Text = "cboShift";
			this.cboBatt = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBatt
			// 
			this.cboBatt.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBatt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBatt.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBatt.Name = "cboBatt";
			this.cboBatt.TabIndex = 19;
			this.cboBatt.Text = "cboBatt";
			this.cboEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmployee
			// 
			this.cboEmployee.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmployee.Name = "cboEmployee";
			this.cboEmployee.TabIndex = 12;
			this.cboEmployee.Text = "cboEmployee";
			this.cboZipCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboZipCode
			// 
			this.cboZipCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboZipCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboZipCode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboZipCode.Name = "cboZipCode";
			this.cboZipCode.TabIndex = 5;
			this.cboZipCode.Text = "cboZipCode";
			this.cboCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCity
			// 
			this.cboCity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCity.Name = "cboCity";
			this.cboCity.TabIndex = 4;
			this.cboCity.Text = "cboCity";
			this.cboRank = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRank
			// 
			this.cboRank.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRank.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRank.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboRank.Name = "cboRank";
			this.cboRank.TabIndex = 3;
			this.cboRank.Text = "cboRank";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 22;
			this.Label6.Text = "Shift";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 20;
			this.Label5.Text = "Batt";
			this._Label4_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 11;
			this.lbCount.Text = "List Count:  ";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Zip Code";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 9;
			this.Label2.Text = "City";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Rank";
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 0;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Rank";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "EmpID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Batt";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shift";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Position";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Address";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 8].Value = "City";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 9].Value = "State";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 10].Value = "Zip Code";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 11].Value = "Home Phone";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 12].Value = "ID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 38F;
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 190F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Rank";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 83F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "EmpID";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 78F;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Label = "Batt";
			//this.sprEmployeeList_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Width = 51F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Shift";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 37F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "Unit";
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 57F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "Position";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 90F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "Address";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 191F;
			this.sprEmployeeList_Sheet1.Columns.Get(8).Label = "City";
			this.sprEmployeeList_Sheet1.Columns.Get(8).Width = 129F;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Label = "State";
			this.sprEmployeeList_Sheet1.Columns.Get(9).Width = 41F;
			this.sprEmployeeList_Sheet1.Columns.Get(10).Label = "Zip Code";
			this.sprEmployeeList_Sheet1.Columns.Get(10).Width = 84F;
			this.sprEmployeeList_Sheet1.Columns.Get(11).Label = "Home Phone";
			this.sprEmployeeList_Sheet1.Columns.Get(11).Width = 101F;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Label = "ID";
			this.sprEmployeeList_Sheet1.Columns.Get(12).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprContact_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprContact_Sheet1.SheetName = "Sheet1";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 0].Value = "Contact";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 1].Value = "Relationship";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 2].Value = "Primary ?";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 3].Value = "Phone Number";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 4].Value = "Type";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 5].Value = "Time Of Day";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 6].Value = "Comments";
			this.sprContact_Sheet1.ColumnHeader.Cells[0, 7].Value = "ID";
			this.sprContact_Sheet1.ColumnHeader.Rows.Get(0).Height = 37F;
			this.sprContact_Sheet1.Columns.Get(0).Label = "Contact";
			this.sprContact_Sheet1.Columns.Get(0).Width = 148F;
			this.sprContact_Sheet1.Columns.Get(1).Label = "Relationship";
			this.sprContact_Sheet1.Columns.Get(1).Width = 79F;
			this.sprContact_Sheet1.Columns.Get(2).Label = "Primary ?";
			this.sprContact_Sheet1.Columns.Get(2).Width = 57F;
			this.sprContact_Sheet1.Columns.Get(3).Label = "Phone Number";
			this.sprContact_Sheet1.Columns.Get(3).Width = 95F;
			this.sprContact_Sheet1.Columns.Get(4).Label = "Type";
			this.sprContact_Sheet1.Columns.Get(4).Width = 76F;
			this.sprContact_Sheet1.Columns.Get(6).Label = "Comments";
			this.sprContact_Sheet1.Columns.Get(6).Width = 166F;
			this.sprContact_Sheet1.Columns.Get(7).Label = "ID";
			this.sprContact_Sheet1.Columns.Get(7).Visible = false;
			this.sprContact_Sheet1.Columns.Get(7).Width = 0F;
			this.sprContact_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPhone_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPhone_Sheet1.SheetName = "Sheet1";
			this.sprPhone_Sheet1.ColumnHeader.Cells[0, 0].Value = "Type";
			this.sprPhone_Sheet1.ColumnHeader.Cells[0, 1].Value = "Phone Number";
			this.sprPhone_Sheet1.ColumnHeader.Cells[0, 2].Value = "Call Back # ?";
			this.sprPhone_Sheet1.ColumnHeader.Cells[0, 3].Value = "Comments";
			this.sprPhone_Sheet1.ColumnHeader.Cells[0, 4].Value = "ID";
			this.sprPhone_Sheet1.ColumnHeader.Rows.Get(0).Height = 48F;
			this.sprPhone_Sheet1.Columns.Get(0).Label = "Type";
			this.sprPhone_Sheet1.Columns.Get(0).Width = 80F;
			this.sprPhone_Sheet1.Columns.Get(1).Label = "Phone Number";
			this.sprPhone_Sheet1.Columns.Get(1).Width = 112F;
			this.sprPhone_Sheet1.Columns.Get(2).Label = "Call Back # ?";
			this.sprPhone_Sheet1.Columns.Get(2).Width = 54F;
			this.sprPhone_Sheet1.Columns.Get(3).Label = "Comments";
			this.sprPhone_Sheet1.Columns.Get(3).Width = 132F;
			this.sprPhone_Sheet1.Columns.Get(4).Label = "ID";
			this.sprPhone_Sheet1.Columns.Get(4).Visible = false;
			this.sprPhone_Sheet1.Columns.Get(4).Width = 0F;
			this.sprPhone_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 7;
			this.cmdClear.Text = "Clear Filters";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 6;
			this.cmdPrint.Text = "Print Employee List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "Close";
			this.Text = "TFD Employee Roster ";
			this.CurrEmp = 0;
			this.CurrRow = 0;
			Label4 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(3);
			Label4[2] = _Label4_2;
			Label4[1] = _Label4_1;
			Label4[0] = _Label4_0;
			Label4[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label4[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label4[2].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label4[2].Name = "_Label4_2";
			Label4[2].TabIndex = 18;
			Label4[2].Text = "Emergency Contact List";
			Label4[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label4[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label4[1].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label4[1].Name = "_Label4_1";
			Label4[1].TabIndex = 17;
			Label4[1].Text = "Phone Numbers, etc.";
			Label4[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label4[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label4[0].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			Label4[0].Name = "_Label4_0";
			Label4[0].TabIndex = 13;
			Label4[0].Text = "Employee";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234764470131396", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234764470141161", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234764563269966", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234764563289496", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234764379102066", "DataAreaDefault");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text307636234764379111831", "DataAreaDefault");
			namedStyle6.CellType = textCellType3;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmRosterFiltered";
			IsMdiChild = true;
			this.sprPhone.NamedStyles.Add(namedStyle1);
			this.sprPhone.NamedStyles.Add(namedStyle2);
			this.sprPhone.Sheets.Add(this.sprPhone_Sheet1);
			this.sprContact.NamedStyles.Add(namedStyle3);
			this.sprContact.NamedStyles.Add(namedStyle4);
			this.sprContact.Sheets.Add(this.sprContact_Sheet1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle5);
			this.sprEmployeeList.NamedStyles.Add(namedStyle6);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPhone { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprContact { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label4_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label4_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBatt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboZipCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRank { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label4_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprContact_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPhone_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrEmp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label4 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}