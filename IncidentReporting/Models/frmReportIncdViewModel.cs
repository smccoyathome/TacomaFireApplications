using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmReportIncd))]
	public class frmReportIncdViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
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
			this.sprIncidentRpt = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprIncidentRpt.MaxRows = 1010;
			this.sprIncidentRpt.TabIndex = 3;
			this.sprIncidentRpt.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Incident Report - Print Preview";
			this.sprIncidentRpt_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIncidentRpt_Sheet1.SheetName = "Sheet1";
			this.sprIncidentRpt_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE REPORT";
			this.sprIncidentRpt_Sheet1.Cells.Get(0, 6).Value = "Print Date";
			this.sprIncidentRpt_Sheet1.Cells.Get(1, 0).Value = "INCIDENT REPORT";
			this.sprIncidentRpt_Sheet1.Cells.Get(3, 0).Value = "Incident Information";
			this.sprIncidentRpt_Sheet1.Cells.Get(4, 0).Value = "Incident Number:";
			this.sprIncidentRpt_Sheet1.Cells.Get(4, 3).Value = "Location:";
			this.sprIncidentRpt_Sheet1.Cells.Get(4, 8).Value = "Clearing Unit:";
			this.sprIncidentRpt_Sheet1.Cells.Get(5, 0).Value = "Initial Type:";
			this.sprIncidentRpt_Sheet1.Cells.Get(5, 3).Value = "Common Place:";
			this.sprIncidentRpt_Sheet1.Cells.Get(6, 0).Value = "Final Type:";
			this.sprIncidentRpt_Sheet1.Cells.Get(6, 3).Value = "Initial Alarm Level:";
			this.sprIncidentRpt_Sheet1.Cells.Get(6, 8).Value = "Dispatcher 1:";
			this.sprIncidentRpt_Sheet1.Cells.Get(7, 0).Value = "Number of Patients:";
			this.sprIncidentRpt_Sheet1.Cells.Get(7, 3).Value = "Final Alarm Level:";
			this.sprIncidentRpt_Sheet1.Cells.Get(7, 8).Value = "Dispatcher 2:";
			this.sprIncidentRpt_Sheet1.Cells.Get(8, 3).Value = "Mutual Aid?";
			this.sprIncidentRpt_Sheet1.Cells.Get(9, 3).Value = "Catchup Event?";
			this.sprIncidentRpt_Sheet1.Cells.Get(10, 1).Value = "Date";
			this.sprIncidentRpt_Sheet1.Cells.Get(10, 2).Value = "Time";
			this.sprIncidentRpt_Sheet1.Cells.Get(11, 0).Value = "Call Received E911:";
			this.sprIncidentRpt_Sheet1.Cells.Get(11, 5).Value = "Reporting Name:";
			this.sprIncidentRpt_Sheet1.Cells.Get(12, 0).Value = "Call Entered:";
			this.sprIncidentRpt_Sheet1.Cells.Get(12, 5).Value = "Reporting Addr:";
			this.sprIncidentRpt_Sheet1.Cells.Get(13, 0).Value = "Call Dispatched:";
			this.sprIncidentRpt_Sheet1.Cells.Get(13, 5).Value = "Reporting Phone:";
			this.sprIncidentRpt_Sheet1.Cells.Get(14, 0).Value = "1st Unit Enroute:";
			this.sprIncidentRpt_Sheet1.Cells.Get(15, 0).Value = "1st Unit Onscene:";
			this.sprIncidentRpt_Sheet1.Cells.Get(15, 4).Value = "Incident Reports";
			this.sprIncidentRpt_Sheet1.Cells.Get(16, 0).Value = "TFD Transport:";
			this.sprIncidentRpt_Sheet1.Cells.Get(16, 3).Value = "Report";
			this.sprIncidentRpt_Sheet1.Cells.Get(16, 5).Value = "Status";
			this.sprIncidentRpt_Sheet1.Cells.Get(16, 7).Value = "Responsible Unit";
			this.sprIncidentRpt_Sheet1.Cells.Get(17, 0).Value = "Transport Complete:";
			this.sprIncidentRpt_Sheet1.Cells.Get(18, 0).Value = "Incident Closed:";
			this.sprIncidentRpt_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprIncidentRpt_Sheet1.Columns.Get(0).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(0).Width = 126F;
			this.sprIncidentRpt_Sheet1.Columns.Get(1).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(1).Width = 65F;
			this.sprIncidentRpt_Sheet1.Columns.Get(2).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(2).Width = 49F;
			this.sprIncidentRpt_Sheet1.Columns.Get(3).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(3).Width = 61F;
			this.sprIncidentRpt_Sheet1.Columns.Get(4).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(4).Width = 51F;
			this.sprIncidentRpt_Sheet1.Columns.Get(5).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(5).Width = 62F;
			this.sprIncidentRpt_Sheet1.Columns.Get(6).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(6).Width = 41F;
			this.sprIncidentRpt_Sheet1.Columns.Get(7).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(7).Width = 68F;
			this.sprIncidentRpt_Sheet1.Columns.Get(8).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(8).Width = 81F;
			this.sprIncidentRpt_Sheet1.Columns.Get(9).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.Columns.Get(9).Width = 65F;
			this.sprIncidentRpt_Sheet1.Columns.Get(10).StyleName = "Font813636234564503201946";
			this.sprIncidentRpt_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprIncidentRpt_Sheet1.Rows.Get(0).Height = 28F;
			this.sprIncidentRpt_Sheet1.Rows.Get(1).Height = 21F;
			this.sprIncidentRpt_Sheet1.Rows.Get(2).Height = 6F;
			this.sprIncidentRpt_Sheet1.Rows.Get(3).Height = 23F;
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
			this.Text = "Incident Report";
			this.CurrIncident = 0;
			this.PageCountRow = 0;
			this.CurrRow = 0;
			this.sDisplay = "";
			this.ReportType = 0;
			this.IncidentReportID = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234564503172651", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text517636234564503182416", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font813636234564503201946");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font587636234564503319126");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font636636234564503338656");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font706636234564503377716");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color816636234564503436306");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color889636234564503465601");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2524636234564505047531");
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2562636234564505086591");
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2647636234564505203771");
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2761636234564505350246");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "TFDIncident.frmReportIncd";
			this.sprIncidentRpt.NamedStyles.Add(namedStyle1);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle2);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle3);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle4);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle5);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle6);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle7);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle8);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle9);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle10);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle11);
			this.sprIncidentRpt.NamedStyles.Add(namedStyle12);
			this.sprIncidentRpt.Sheets.Add(this.sprIncidentRpt_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprIncidentRpt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIncidentRpt_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PageCountRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDisplay { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 IncidentReportID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}