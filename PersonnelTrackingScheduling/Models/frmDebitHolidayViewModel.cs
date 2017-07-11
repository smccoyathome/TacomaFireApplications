using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmDebitHoliday))]
	public class frmDebitHolidayViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var numberCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
            var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
            FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.dteReportDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteReportDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteReportDate.Name = "dteReportDate";
			this.dteReportDate.TabIndex = 17;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 12;
			this.cboYear.Text = "cboYear";
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 8;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 7;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 6;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 5;
			this.optA.Text = "Shift A";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 20;
			this.opt183.Text = "Batt 3";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 3;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 2;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 1;
			this.opt181.Text = "Batt 1";
			this.sprEmployeeList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeList.TabIndex = 13;
			this.sprEmployeeList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 19;
			this.Label2.Text = "bold red means take <> payrolled";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 18;
			this.Label1.Text = "* means no assigned debit group";
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label6_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 14;
			this.lbCount.Text = "List Count:  ";
			this.sprEmployeeList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeList_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Empl #";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Name";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 2].Value = "Batt";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 3].Value = "Unit";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shift";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 5].Value = "DD Taken";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 6].Value = "DD Payrolled";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 7].Value = "UDD Payrolled";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 8].Value = "Future DD";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 9].Value = "Total DD";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 10].Value = "HOL Taken";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 11].Value = "HOL Payrolled";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 12].Value = "Future HOL";
			this.sprEmployeeList_Sheet1.ColumnHeader.Cells[0, 13].Value = "Total HOL";
			this.sprEmployeeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 27F;
			this.sprEmployeeList_Sheet1.Columns.Get(0).Label = "Empl #";
			this.sprEmployeeList_Sheet1.Columns.Get(0).Width = 56F;
			this.sprEmployeeList_Sheet1.Columns.Get(1).Label = "Name";
			this.sprEmployeeList_Sheet1.Columns.Get(1).Width = 135F;
			this.sprEmployeeList_Sheet1.Columns.Get(2).Label = "Batt";
			this.sprEmployeeList_Sheet1.Columns.Get(2).Width = 28F;
			this.sprEmployeeList_Sheet1.Columns.Get(3).Label = "Unit";
			this.sprEmployeeList_Sheet1.Columns.Get(3).Width = 28F;
			this.sprEmployeeList_Sheet1.Columns.Get(4).Label = "Shift";
			this.sprEmployeeList_Sheet1.Columns.Get(4).Width = 28F;
			this.sprEmployeeList_Sheet1.Columns.Get(5).Label = "DD Taken";
			this.sprEmployeeList_Sheet1.Columns.Get(5).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(6).Label = "DD Payrolled";
			this.sprEmployeeList_Sheet1.Columns.Get(6).Width = 56F;
			this.sprEmployeeList_Sheet1.Columns.Get(7).Label = "UDD Payrolled";
			this.sprEmployeeList_Sheet1.Columns.Get(7).Width = 57F;
			this.sprEmployeeList_Sheet1.Columns.Get(8).Label = "Future DD";
			this.sprEmployeeList_Sheet1.Columns.Get(8).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(9).Label = "Total DD";
			this.sprEmployeeList_Sheet1.Columns.Get(9).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(10).Label = "HOL Taken";
			this.sprEmployeeList_Sheet1.Columns.Get(10).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(11).Label = "HOL Payrolled";
			this.sprEmployeeList_Sheet1.Columns.Get(11).Width = 56F;
			this.sprEmployeeList_Sheet1.Columns.Get(12).Label = "Future HOL";
			this.sprEmployeeList_Sheet1.Columns.Get(12).Width = 40F;
			this.sprEmployeeList_Sheet1.Columns.Get(13).Label = "Total HOL";
			this.sprEmployeeList_Sheet1.Columns.Get(13).Width = 40F;
            //SortIndicator is OBSOLETE
            //this.sprEmployeeList_Sheet1.Columns.Get(14).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprEmployeeList_Sheet1.Columns.Get(14).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(14).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(15).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(15).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(16).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(16).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(17).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(17).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(18).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(18).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(19).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(19).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(20).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(20).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(21).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(21).Width = 0F;
			this.sprEmployeeList_Sheet1.Columns.Get(22).Visible = false;
			this.sprEmployeeList_Sheet1.Columns.Get(22).Width = 0F;
			this.sprEmployeeList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 11;
			this.cmdPrint.Text = "Print List";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 10;
			this.cmdClear.Text = "Clear Filters";
			this.cboClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cboClose
			// 
			this.cboClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cboClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cboClose.Name = "cboClose";
			this.cboClose.TabIndex = 9;
			this.cboClose.Text = "Exit";
			this.Text = "Debit Day / Holiday Audit";
			this.ReportYear = "";
			this.ReportBatt = "";
			this.ReportShift = "";
			this.ReportDate = "";
			this.FirstTime = false;
			Label6 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label6[0] = _Label6_0;
			Label6[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label6[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label6[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label6[0].Name = "_Label6_0";
			Label6[0].TabIndex = 15;
			Label6[0].Text = "Select As Of Date";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label3[1] = _Label3_1;
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 16;
			Label3[1].Text = "Select Year";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234691510186476", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234691510206006", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Number2384636234691511973471");
			namedStyle3.CellType = numberCellType1;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Right;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = numberCellType1;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmDebitHoliday";
			IsMdiChild = true;
			this.sprEmployeeList.NamedStyles.Add(namedStyle1);
			this.sprEmployeeList.NamedStyles.Add(namedStyle2);
			this.sprEmployeeList.NamedStyles.Add(namedStyle3);
			this.sprEmployeeList.Sheets.Add(this.sprEmployeeList_Sheet1);
		}
		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteReportDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label6_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cboClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label6 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}