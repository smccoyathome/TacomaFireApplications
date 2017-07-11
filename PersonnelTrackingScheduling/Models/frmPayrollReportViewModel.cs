using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmPayrollReport))]
	public class frmPayrollReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 15;
			this.cboYear.Text = "cboYear";
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 5000;
			this.sprReport.TabIndex = 14;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.optD = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optD
			// 
			this.optD.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optD.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optD.Name = "optD";
			this.optD.TabIndex = 10;
			this.optD.Text = "Shift D";
			this.optC = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optC
			// 
			this.optC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optC.Name = "optC";
			this.optC.TabIndex = 9;
			this.optC.Text = "Shift C";
			this.optB = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optB
			// 
			this.optB.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optB.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optB.Name = "optB";
			this.optB.TabIndex = 8;
			this.optB.Text = "Shift B";
			this.optA = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optA
			// 
			this.optA.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optA.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optA.Name = "optA";
			this.optA.TabIndex = 7;
			this.optA.Text = "Shift A";
			this.opt183 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt183
			// 
			this.opt183.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt183.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt183.Name = "opt183";
			this.opt183.TabIndex = 17;
			this.opt183.Text = "Batt 3";
			this.optAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAll
			// 
			this.optAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAll.Checked = true;
			this.optAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.optAll.Name = "optAll";
			this.optAll.TabIndex = 5;
			this.optAll.Text = "ALL";
			this.opt182 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt182
			// 
			this.opt182.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt182.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt182.Name = "opt182";
			this.opt182.TabIndex = 4;
			this.opt182.Text = "Batt 2";
			this.opt181 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// opt181
			// 
			this.opt181.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.opt181.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.opt181.Name = "opt181";
			this.opt181.TabIndex = 3;
			this.opt181.Text = "Batt 1";
			this.cboPayPeriod = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPayPeriod
			// 
			this.cboPayPeriod.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPayPeriod.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPayPeriod.Name = "cboPayPeriod";
			this.cboPayPeriod.TabIndex = 0;
			this.cboPayPeriod.Text = "cboPayPeriod";
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label6_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(0, 0).ColumnSpan = 11;
			this.sprReport_Sheet1.Cells.Get(0, 0).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 1).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 2).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 3).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 4).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 5).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(0, 6).Value = "Payroll Payperiod Report for ";
			this.sprReport_Sheet1.Cells.Get(2, 2).Value = "Payroll Date";
			this.sprReport_Sheet1.Cells.Get(2, 3).Value = "A/A Type";
			this.sprReport_Sheet1.Cells.Get(2, 4).Value = "Hours";
			this.sprReport_Sheet1.Cells.Get(2, 5).Value = "PS Group";
			this.sprReport_Sheet1.Cells.Get(2, 6).Value = "Level";
			this.sprReport_Sheet1.Cells.Get(2, 7).Value = "Activity";
			this.sprReport_Sheet1.Cells.Get(2, 8).Value = "Order";
			this.sprReport_Sheet1.Cells.Get(2, 9).Value = "WBS Element";
			this.sprReport_Sheet1.Cells.Get(2, 10).Value = "Cost Center";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprReport_Sheet1.Columns.Get(0).Width = 50F;
			this.sprReport_Sheet1.Columns.Get(1).Width = 173F;
			this.sprReport_Sheet1.Columns.Get(2).Width = 82F;
			this.sprReport_Sheet1.Columns.Get(3).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(3).Width = 58F;
			this.sprReport_Sheet1.Columns.Get(4).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(4).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(5).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(5).Width = 69F;
			this.sprReport_Sheet1.Columns.Get(6).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(6).Width = 43F;
			this.sprReport_Sheet1.Columns.Get(7).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(7).Width = 68F;
			this.sprReport_Sheet1.Columns.Get(8).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(8).Width = 93F;
			this.sprReport_Sheet1.Columns.Get(9).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(9).Width = 107F;
			this.sprReport_Sheet1.Columns.Get(10).StyleName = "Static875636234754173573621";
			this.sprReport_Sheet1.Columns.Get(10).Width = 82F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 30F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 13;
			this.cmdPrint.Text = "Print Report";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 12;
			this.cmdClear.Text = "Clear Filters";
			this.cboClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cboClose
			// 
			this.cboClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cboClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cboClose.Name = "cboClose";
			this.cboClose.TabIndex = 11;
			this.cboClose.Text = "Close";
			this.Text = "Payroll Report";
			this.CurrStartDate = "";
			this.CurrEndDate = "";
			this.CurrBatt = "";
			this.CurrShift = "";
			this.FirstTime = false;
			Label6 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label6[0] = _Label6_0;
			Label6[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label6[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label6[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label6[0].Name = "_Label6_0";
			Label6[0].TabIndex = 1;
			Label6[0].Text = "Select a Pay Period:";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label3[1] = _Label3_1;
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 16;
			Label3[1].Text = "Year";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234754173515031", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text389636234754173544326", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static875636234754173573621");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1369636234754173641976");
			namedStyle4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 13F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1432636234754173651741");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1816636234754173720096");
			namedStyle6.CellType = textCellType4;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmPayrollReport";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.NamedStyles.Add(namedStyle4);
			this.sprReport.NamedStyles.Add(namedStyle5);
			this.sprReport.NamedStyles.Add(namedStyle6);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optD { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optB { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt183 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAll { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt182 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel opt181 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPayPeriod { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label6_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cboClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrStartDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEndDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label6 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}