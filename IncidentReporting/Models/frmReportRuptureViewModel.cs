using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmReportRupture))]
	public class frmReportRuptureViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprRuptureReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRuptureReport.MaxRows = 1010;
			this.sprRuptureReport.TabIndex = 3;
			this.sprRuptureReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Rupture Report - Print Preview";
			this.sprRuptureReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRuptureReport_Sheet1.SheetName = "Sheet1";
			this.sprRuptureReport_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE REPORT";
			this.sprRuptureReport_Sheet1.Cells.Get(0, 6).Value = "Print Date";
			this.sprRuptureReport_Sheet1.Cells.Get(1, 0).Value = "RUPTURE/EXPLOSION REPORT";
			this.sprRuptureReport_Sheet1.Cells.Get(3, 0).Value = "Incident Information";
			this.sprRuptureReport_Sheet1.Cells.Get(4, 0).Value = "Incident Number:";
			this.sprRuptureReport_Sheet1.Cells.Get(4, 4).Value = "Unit";
			this.sprRuptureReport_Sheet1.Cells.Get(4, 6).Value = "Dispatched";
			this.sprRuptureReport_Sheet1.Cells.Get(4, 7).Value = "Onscene";
			this.sprRuptureReport_Sheet1.Cells.Get(4, 8).Value = "Available";
			this.sprRuptureReport_Sheet1.Cells.Get(5, 0).Value = "Incident Date:";
			this.sprRuptureReport_Sheet1.Cells.Get(6, 0).Value = "Incident Location:";
			this.sprRuptureReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprRuptureReport_Sheet1.Columns.Get(0).Width = 138F;
			this.sprRuptureReport_Sheet1.Columns.Get(1).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(1).Width = 65F;
			this.sprRuptureReport_Sheet1.Columns.Get(2).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(2).Width = 53F;
			this.sprRuptureReport_Sheet1.Columns.Get(3).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(3).Width = 54F;
			this.sprRuptureReport_Sheet1.Columns.Get(4).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(4).Width = 30F;
			this.sprRuptureReport_Sheet1.Columns.Get(5).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(5).Width = 110F;
			this.sprRuptureReport_Sheet1.Columns.Get(6).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(6).Width = 78F;
			this.sprRuptureReport_Sheet1.Columns.Get(7).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(7).Width = 65F;
			this.sprRuptureReport_Sheet1.Columns.Get(8).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(8).Width = 71F;
			this.sprRuptureReport_Sheet1.Columns.Get(9).StyleName = "Font901636234564133196331";
			this.sprRuptureReport_Sheet1.Columns.Get(9).Width = 65F;
			this.sprRuptureReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprRuptureReport_Sheet1.Rows.Get(0).Height = 23F;
			this.sprRuptureReport_Sheet1.Rows.Get(1).Height = 21F;
			this.sprRuptureReport_Sheet1.Rows.Get(4).Height = 21F;
			this.sprRuptureReport_Sheet1.Rows.Get(5).Height = 20F;
			this.sprRuptureReport_Sheet1.Rows.Get(6).Height = 20F;
			this.sprRuptureReport_Sheet1.Rows.Get(7).Height = 20F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 0;
			this.cmdPrint.Text = "Print Report";
			this.Text = "Rupture Report";
			this.ReportType = 0;
			this.RuptureReportID = 0;
			this.CurrRow = 0;
			this.CurrIncident = 0;
			this.PageCountRow = 0;
			this.IncidentNumber = "";
			this.SaveRow = 0;
			this.LastRow = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234564133157271", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text553636234564133176801", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font901636234564133196331");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font587636234564133313511");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font636636234564133342806");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font706636234564133372101");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font772636234564133381866");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color805636234564133401396");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color878636234564133440456");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "TFDIncident.frmReportRupture";
			this.sprRuptureReport.NamedStyles.Add(namedStyle1);
			this.sprRuptureReport.NamedStyles.Add(namedStyle2);
			this.sprRuptureReport.NamedStyles.Add(namedStyle3);
			this.sprRuptureReport.NamedStyles.Add(namedStyle4);
			this.sprRuptureReport.NamedStyles.Add(namedStyle5);
			this.sprRuptureReport.NamedStyles.Add(namedStyle6);
			this.sprRuptureReport.NamedStyles.Add(namedStyle7);
			this.sprRuptureReport.NamedStyles.Add(namedStyle8);
			this.sprRuptureReport.NamedStyles.Add(namedStyle9);
			this.sprRuptureReport.Sheets.Add(this.sprRuptureReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRuptureReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRuptureReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 RuptureReportID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PageCountRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String IncidentNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SaveRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 LastRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}