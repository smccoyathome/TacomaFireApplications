using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmMasterPhoneLists))]
	public class frmMasterPhoneListsViewModel
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
			this._optList_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optList_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboFFacility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFFacility
			// 
			this.cboFFacility.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFFacility.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboFFacility.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFFacility.Name = "cboFFacility";
			this.cboFFacility.TabIndex = 10;
			this.cboFFacility.Text = "cboFFacility";
			this.cboFType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFType
			// 
			this.cboFType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboFType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboFType.Name = "cboFType";
			this.cboFType.TabIndex = 9;
			this.cboFType.Text = "cboFType";
			this.sprResource = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprResource.TabIndex = 7;
			this.sprResource.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lbFacilityCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFacilityCount
			// 
			this.lbFacilityCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFacilityCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbFacilityCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbFacilityCount.Name = "lbFacilityCount";
			this.lbFacilityCount.TabIndex = 25;
			this.lbFacilityCount.Text = "Total Rows";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 12;
			this.Label1.Text = "Facility \\ Resource";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 11;
			this.Label2.Text = "Phone Type";
			this.cboGroup = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGroup
			// 
			this.cboGroup.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGroup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGroup.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.TabIndex = 22;
			this.cboGroup.Text = "cboGroup";
			this.cboEFacility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEFacility
			// 
			this.cboEFacility.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEFacility.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEFacility.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEFacility.Name = "cboEFacility";
			this.cboEFacility.TabIndex = 20;
			this.cboEFacility.Text = "cboEFacility";
			this.cboUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnit
			// 
			this.cboUnit.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnit.Name = "cboUnit";
			this.cboUnit.TabIndex = 18;
			this.cboUnit.Text = "cboUnit";
			this.cboAssignType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAssignType
			// 
			this.cboAssignType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAssignType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAssignType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboAssignType.Name = "cboAssignType";
			this.cboAssignType.TabIndex = 15;
			this.cboAssignType.Text = "cboAssignType";
			this.cboEType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEType
			// 
			this.cboEType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEType.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEType.Name = "cboEType";
			this.cboEType.TabIndex = 14;
			this.cboEType.Text = "cboEType";
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 1;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.lbEmployeeCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmployeeCount
			// 
			this.lbEmployeeCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEmployeeCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEmployeeCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbEmployeeCount.Name = "lbEmployeeCount";
			this.lbEmployeeCount.TabIndex = 26;
			this.lbEmployeeCount.Text = "Total Rows";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 23;
			this.Label7.Text = "Group";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 21;
			this.Label6.Text = "Facility ";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 19;
			this.Label5.Text = "Unit";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Assign Type";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 16;
			this.Label3.Text = "Phone Type";
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Facility";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Position";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shift";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "Assign Type";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "Group Type";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "Phone Type";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Phone Number";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Comments";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 10].Value = "Call Back # ?";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 11].Value = "PhoneID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 12].Value = "PerSysID";
			this.sprEmployeeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 41F;
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 165F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Facility";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 83F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "Unit";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 46F;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Label = "Position";
			this.sprEmployeeList_Sheet1.Columns.Get(3).Width = 66F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Shift";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "Assign Type";
			//this.sprEmployeeList_Sheet1.Columns.Get(5).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 77F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "Group Type";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 62F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "Phone Type";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 73F;
			this.sprEmployeeList_Sheet1.Columns.Get(8).Label = "Phone Number";
			this.sprEmployeeList_Sheet1.Columns.Get(8).Width = 98F;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Label = "Comments";
			this.sprEmployeeList_Sheet1.Columns.Get(9).Width = 111F;
			this.sprEmployeeList_Sheet1.Columns.Get(10).Label = "Call Back # ?";
			this.sprEmployeeList_Sheet1.Columns.Get(11).Label = "PhoneID";
			this.sprEmployeeList_Sheet1.Columns.Get(11).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(11).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Label = "PerSysID";
			this.sprEmployeeList_Sheet1.Columns.Get(12).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprResource_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprResource_Sheet1.SheetName = "Sheet1";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 0].Value = "Facility \\ Resource Name";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 1].Value = "Phone Type";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 2].Value = "Phone Number";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 3].Value = "Comments";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 4].Value = "PhoneID";
			this.sprResource_Sheet1.ColumnHeader.Cells[0, 5].Value = "FacilityID";
			this.sprResource_Sheet1.ColumnHeader.Rows.Get(0).Height = 31F;
			this.sprResource_Sheet1.Columns.Get(0).Label = "Facility \\ Resource Name";
			this.sprResource_Sheet1.Columns.Get(0).Width = 181F;
			this.sprResource_Sheet1.Columns.Get(1).Label = "Phone Type";
			this.sprResource_Sheet1.Columns.Get(1).Width = 109F;
			this.sprResource_Sheet1.Columns.Get(2).Label = "Phone Number";
			this.sprResource_Sheet1.Columns.Get(2).Width = 114F;
			this.sprResource_Sheet1.Columns.Get(3).Label = "Comments";
			this.sprResource_Sheet1.Columns.Get(3).Width = 169F;
			this.sprResource_Sheet1.Columns.Get(4).Label = "PhoneID";
			this.sprResource_Sheet1.Columns.Get(4).Visible = false;
			this.sprResource_Sheet1.Columns.Get(4).Width = 0F;
			this.sprResource_Sheet1.Columns.Get(5).Label = "FacilityID";
			this.sprResource_Sheet1.Columns.Get(5).Visible = false;
			this.sprResource_Sheet1.Columns.Get(5).Width = 0F;
			this.sprResource_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 4;
			this.cmdClose.Text = "Close";
			this.cmdPrintFacility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintFacility
			// 
			this.cmdPrintFacility.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintFacility.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintFacility.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintFacility.Name = "cmdPrintFacility";
			this.cmdPrintFacility.TabIndex = 28;
			this.cmdPrintFacility.Text = "Print List";
			this.cmdClearFacility = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearFacility
			// 
			this.cmdClearFacility.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearFacility.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearFacility.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearFacility.Name = "cmdClearFacility";
			this.cmdClearFacility.TabIndex = 8;
			this.cmdClearFacility.Text = "Clear Filters";
			this.cmdPrintEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintEmployee
			// 
			this.cmdPrintEmployee.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintEmployee.Name = "cmdPrintEmployee";
			this.cmdPrintEmployee.TabIndex = 27;
			this.cmdPrintEmployee.Text = "Print List";
			this.chkCBOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCBOnly
			// 
			this.chkCBOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkCBOnly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCBOnly.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.chkCBOnly.Name = "chkCBOnly";
			this.chkCBOnly.TabIndex = 24;
			this.chkCBOnly.Text = "Call Back Only";
			this.cmdClearEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearEmployee
			// 
			this.cmdClearEmployee.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearEmployee.Name = "cmdClearEmployee";
			this.cmdClearEmployee.TabIndex = 13;
			this.cmdClearEmployee.Text = "Clear Filters";
			this.Text = "TFD Phone Lists";
			this.frmEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmEmployee
			// 
			this.frmEmployee.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.frmEmployee.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmEmployee.Name = "frmEmployee";
			this.frmEmployee.TabIndex = 0;
			this.frmResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmResource
			// 
			this.frmResource.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.frmResource.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmResource.Name = "frmResource";
			this.frmResource.TabIndex = 6;
			optList = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optList[1] = _optList_1;
			optList[0] = _optList_0;
			optList[1].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			optList[1].Checked = true;
			optList[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optList[1].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			optList[1].Name = "_optList_1";
			optList[1].TabIndex = 5;
			optList[1].Text = "Employee Phone List";
			optList[0].BackColor = UpgradeHelpers.Helpers.Color.Gray;
			optList[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optList[0].ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			optList[0].Name = "_optList_0";
			optList[0].TabIndex = 3;
			optList[0].Text = "Facility \\ Resource Phone List";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234731911512156", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234731911521921", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234732000959556", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234732000979086", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmMasterPhoneLists";
			IsMdiChild = true;
			this.sprResource.NamedStyles.Add(namedStyle1);
			this.sprResource.NamedStyles.Add(namedStyle2);
			this.sprResource.Sheets.Add(this.sprResource_Sheet1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle3);
			this.sprEmployeeList.NamedStyles.Add(namedStyle4);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optList_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optList_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFFacility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFType { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFacilityCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGroup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEFacility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAssignType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEType { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmployeeCount { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprResource_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintFacility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearFacility { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCBOnly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmResource { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optList { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}