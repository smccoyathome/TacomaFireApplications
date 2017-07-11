using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPPEInspHistory))]
	public class frmPPEInspHistoryViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var checkBoxCellType1 = ctx.Resolve<FarPoint.ViewModels.CheckBoxCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprList.TabIndex = 15;
			this.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboType
			// 
			this.cboType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboType.Name = "cboType";
			this.cboType.TabIndex = 8;
			this.cboType.Text = "cboType";
			this.cboBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBrand
			// 
			this.cboBrand.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBrand.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboBrand.Name = "cboBrand";
			this.cboBrand.TabIndex = 9;
			this.cboBrand.Text = "cboBrand";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optD.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 7;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 6;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optB.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 5;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.optA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 4;
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
			this.optAll.TabIndex = 1;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt182.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 3;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt181.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 2;
			this.opt181.Text = "Batt 1";
			this.opt12Month = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt12Month
			// 
			this.opt12Month.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt12Month.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt12Month.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt12Month.Name = "opt12Month";
			this.opt12Month.TabIndex = 11;
			this.opt12Month.Text = "Items Not Inspected past year";
			this.opt6Month = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt6Month
			// 
			this.opt6Month.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.opt6Month.Checked = true;
			this.opt6Month.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.opt6Month.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.opt6Month.Name = "opt6Month";
			this.opt6Month.TabIndex = 10;
			this.opt6Month.Text = "Items Not Inspected past 6 months";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 31;
			this.Label1.Text = "Item Type: ";
			this.lbBrand = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBrand
			// 
			this.lbBrand.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBrand.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBrand.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbBrand.Name = "lbBrand";
			this.lbBrand.TabIndex = 30;
			this.lbBrand.Text = "Manufacturer: ";
			this.txtTrackingNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTrackingNum.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTrackingNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTrackingNum.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTrackingNum.Name = "txtTrackingNum";
			this.txtTrackingNum.TabIndex = 20;
			this.txtTrackingNum.Text = "txtTrackingNum";
			this.cboEmpList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEmpList
			// 
			this.cboEmpList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEmpList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEmpList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEmpList.Name = "cboEmpList";
			this.cboEmpList.TabIndex = 18;
			this.cboEmpList.Text = "cboEmpList";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 23;
			this.Label2.Text = "Display Inspections for a specific Employee";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 22;
			this.Label11.Text = "OR Display Inspections for a specific Item by Tracking #";
			this.lbEmpID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmpID
			// 
			this.lbEmpID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbEmpID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbEmpID.Name = "lbEmpID";
			this.lbEmpID.TabIndex = 17;
			this.lbEmpID.Text = "lbEmpID";
			this.lbEmpID.Visible = false;
			this.lbTotalCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotalCount
			// 
			this.lbTotalCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotalCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalCount.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbTotalCount.Name = "lbTotalCount";
			this.lbTotalCount.TabIndex = 24;
			this.lbTotalCount.Text = "List Count:  0";
			this.sprList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprList_Sheet1.SheetName = "Sheet1";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Insp Date";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Issued To";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Inspected By";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Uniform Item";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Tracking #";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Brand";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Size / Color";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Passed?";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Returned Date";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Retired Date";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 10].Value = "UniformID";
			this.sprList_Sheet1.ColumnHeader.Cells[0, 11].Value = "InspectionID";
			this.sprList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
			this.sprList_Sheet1.Columns.Get(0).Label = "Insp Date";
			this.sprList_Sheet1.Columns.Get(0).Width = 57F;
			this.sprList_Sheet1.Columns.Get(1).Label = "Issued To";
			this.sprList_Sheet1.Columns.Get(1).Width = 87F;
			this.sprList_Sheet1.Columns.Get(2).Label = "Inspected By";
			this.sprList_Sheet1.Columns.Get(2).Width = 89F;
			this.sprList_Sheet1.Columns.Get(3).Label = "Uniform Item";
			this.sprList_Sheet1.Columns.Get(3).Width = 73F;
			this.sprList_Sheet1.Columns.Get(4).Label = "Tracking #";
			this.sprList_Sheet1.Columns.Get(4).Width = 83F;
			this.sprList_Sheet1.Columns.Get(5).Label = "Brand";
			this.sprList_Sheet1.Columns.Get(5).Width = 90F;
			this.sprList_Sheet1.Columns.Get(6).Label = "Size / Color";
			this.sprList_Sheet1.Columns.Get(6).Width = 64F;
			this.sprList_Sheet1.Columns.Get(7).Label = "Passed?";
			this.sprList_Sheet1.Columns.Get(7).StyleName = "CheckBox1061636234756954596796";
			this.sprList_Sheet1.Columns.Get(7).Width = 50F;
			this.sprList_Sheet1.Columns.Get(8).Label = "Returned Date";
			this.sprList_Sheet1.Columns.Get(8).Width = 59F;
			this.sprList_Sheet1.Columns.Get(9).Label = "Retired Date";
			this.sprList_Sheet1.Columns.Get(9).Width = 57F;
			this.sprList_Sheet1.Columns.Get(10).Label = "UniformID";
			this.sprList_Sheet1.Columns.Get(10).Visible = false;
			this.sprList_Sheet1.Columns.Get(10).Width = 0F;
			this.sprList_Sheet1.Columns.Get(11).Label = "InspectionID";
			this.sprList_Sheet1.Columns.Get(11).Visible = false;
			this.sprList_Sheet1.Columns.Get(11).Width = 0F;
			this.sprList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 13;
			this.cmdClose.Text = "Close";
			this.cmdPrintList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintList
			// 
			this.cmdPrintList.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintList.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintList.Name = "cmdPrintList";
			this.cmdPrintList.TabIndex = 14;
			this.cmdPrintList.Text = "Print List";
			this.chkDisplayOption = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDisplayOption
			// 
			this.chkDisplayOption.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkDisplayOption.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDisplayOption.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.chkDisplayOption.Name = "chkDisplayOption";
			this.chkDisplayOption.TabIndex = 0;
			this.chkDisplayOption.Text = "Change to \"Not Inspected\" Options";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 12;
			this.cmdClear.Text = "Clear Filters";
			this.cmdSearchNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSearchNum
			// 
			this.cmdSearchNum.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSearchNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSearchNum.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSearchNum.Name = "cmdSearchNum";
			this.cmdSearchNum.TabIndex = 21;
			this.cmdSearchNum.Text = "Search";
			this.chkInactive = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkInactive
			// 
			this.chkInactive.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.chkInactive.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkInactive.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.TabIndex = 19;
			this.chkInactive.Text = "Display Inactive Employees";
			this.Text = "PPE Inspection History";
			this.iMonth = 0;
			this.CurrBatt = "";
			this.CurrShift = "";
			this.sFilter = "";
			this.frmNotInspectedOptions = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmNotInspectedOptions
			// 
			this.frmNotInspectedOptions.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.frmNotInspectedOptions.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, ((
						UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmNotInspectedOptions.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.frmNotInspectedOptions.Name = "frmNotInspectedOptions";
			this.frmNotInspectedOptions.TabIndex = 26;
			this.frmNotInspectedOptions.Text = "List Not Inspected Items by following filters:";
			this.frmInpectedOptions = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmInpectedOptions
			// 
			this.frmInpectedOptions.BackColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.frmInpectedOptions.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmInpectedOptions.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.frmInpectedOptions.Name = "frmInpectedOptions";
			this.frmInpectedOptions.TabIndex = 16;
			this.frmInpectedOptions.Text = "List Inspections by one of the options:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234756954538206", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234756954547971", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("CheckBox1061636234756954596796");
			namedStyle3.CellType = checkBoxCellType1;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = checkBoxCellType1;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmPPEInspHistory";
			IsMdiChild = true;
			this.sprList.NamedStyles.Add(namedStyle1);
			this.sprList.NamedStyles.Add(namedStyle2);
			this.sprList.NamedStyles.Add(namedStyle3);
			this.sprList.Sheets.Add(this.sprList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprList { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt12Month { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt6Month { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBrand { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTrackingNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEmpList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmpID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotalCount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDisplayOption { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSearchNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkInactive { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 iMonth { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sFilter { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmNotInspectedOptions { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmInpectedOptions { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}