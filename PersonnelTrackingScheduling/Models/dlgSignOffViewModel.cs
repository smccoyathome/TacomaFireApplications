using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgSignOff))]
	public class dlgSignOffViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.TabIndex = 1;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprPrintList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPrintList.MaxRows = 35;
			this.sprPrintList.TabIndex = 5;
			this.sprPrintList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprPrintList.Visible = false;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 2;
			this._Label11_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprPrintList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPrintList_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprPrintList_Sheet1.Cells.Get(0, 0).ColumnSpan = 3;
			this.sprPrintList_Sheet1.Cells.Get(0, 0).Value = "Payroll Sign Off for";
			this.sprPrintList_Sheet1.Cells.Get(0, 1).Value = "Payroll Sign Off for";
			this.sprPrintList_Sheet1.Cells.Get(0, 2).Value = "Payroll Sign Off for";
			this.sprPrintList_Sheet1.Cells.Get(1, 2).Value = "Printed mm/dd/yyyy";
			this.sprPrintList_Sheet1.Cells.Get(2, 0).Value = "Payperiod Start -End";
			this.sprPrintList_Sheet1.Cells.Get(2, 1).Value = "Accepted Datetime";
			this.sprPrintList_Sheet1.Cells.Get(2, 2).Value = "Message";
			this.sprPrintList_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprPrintList_Sheet1.Columns.Get(0).Width = 184F;
			this.sprPrintList_Sheet1.Columns.Get(1).Width = 164F;
			this.sprPrintList_Sheet1.Columns.Get(2).Width = 263F;
			this.sprPrintList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPrintList_Sheet1.Rows.Get(6).Height = 19F;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Payperiod Start/End";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Accept Datetime";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Message";
			this.sprReport_Sheet1.Columns.Get(0).Label = "Payperiod Start/End";
			this.sprReport_Sheet1.Columns.Get(0).Width = 130F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Accept Datetime";
			this.sprReport_Sheet1.Columns.Get(1).Width = 111F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Message";
			this.sprReport_Sheet1.Columns.Get(2).Width = 326F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 4;
			this.cmdPrint.Text = "Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "Close";
			this.Text = "Personnel Payroll SignOff ";
			this.CurrSAPID = 0;
			this.CurrEmpID = "";
			this.CurrPersID = 0;
			Label11 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label11[0] = _Label11_0;
			Label11[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label11[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label11[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			Label11[0].Name = "_Label11_0";
			Label11[0].TabIndex = 3;
			Label11[0].Text = "Select Employee";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234659845879716", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234659845889481", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static865636234659845928541");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234660666159246", "DataAreaDefault");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text348636234660666188541", "DataAreaDefault");
			namedStyle5.CellType = textCellType3;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx871636234660666217836");
			namedStyle6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static927636234660666237366");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle7.CellType = textCellType4;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1000636234660666266661");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1129636234660666295956");
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1379636234660666335016");
			namedStyle10.CellType = textCellType5;
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Right;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = textCellType5;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1461636234660666344781");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1501636234660666354546");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle12.CellType = textCellType6;
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType6;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1574636234660666354546");
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.dlgSignOff";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
			this.sprPrintList.NamedStyles.Add(namedStyle4);
			this.sprPrintList.NamedStyles.Add(namedStyle5);
			this.sprPrintList.NamedStyles.Add(namedStyle6);
			this.sprPrintList.NamedStyles.Add(namedStyle7);
			this.sprPrintList.NamedStyles.Add(namedStyle8);
			this.sprPrintList.NamedStyles.Add(namedStyle9);
			this.sprPrintList.NamedStyles.Add(namedStyle10);
			this.sprPrintList.NamedStyles.Add(namedStyle11);
			this.sprPrintList.NamedStyles.Add(namedStyle12);
			this.sprPrintList.NamedStyles.Add(namedStyle13);
			this.sprPrintList.Sheets.Add(this.sprPrintList_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPrintList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label11_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPrintList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrSAPID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPersID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label11 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}