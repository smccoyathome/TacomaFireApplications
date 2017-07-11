using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmReportEMS))]
	public class frmReportEMSViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.sprEMSReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEMSReport.MaxRows = 1010;
			this.sprEMSReport.TabIndex = 3;
			this.sprEMSReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprHIPAAReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprHIPAAReport.MaxRows = 100;
			this.sprHIPAAReport.TabIndex = 5;
			this.sprHIPAAReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "EMS Patient Contact Report - Print Preview";
			this.sprHIPAAReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprHIPAAReport_Sheet1.SheetName = "Sheet1";
			this.sprHIPAAReport_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE REPORT";
			this.sprHIPAAReport_Sheet1.Cells.Get(0, 3).Value = "Print Date:";
			this.sprHIPAAReport_Sheet1.Cells.Get(1, 0).Value = "HIPAA ACCESS HISTORY REPORT";
			this.sprHIPAAReport_Sheet1.Cells.Get(3, 0).Value = "Patient Contact Report - Data Access History";
			this.sprHIPAAReport_Sheet1.Cells.Get(4, 0).Value = "Access Date";
			this.sprHIPAAReport_Sheet1.Cells.Get(4, 1).Value = "Accessed By";
			this.sprHIPAAReport_Sheet1.Cells.Get(4, 2).Value = "Access Type";
			this.sprHIPAAReport_Sheet1.Cells.Get(4, 3).Value = "Released To";
			this.sprHIPAAReport_Sheet1.Cells.Get(4, 4).Value = "Reason Released";
			this.sprHIPAAReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprHIPAAReport_Sheet1.Columns.Get(0).Width = 112F;
			this.sprHIPAAReport_Sheet1.Columns.Get(1).StyleName = "Font901636234562124916666";
			this.sprHIPAAReport_Sheet1.Columns.Get(1).Width = 166F;
			this.sprHIPAAReport_Sheet1.Columns.Get(2).StyleName = "Font901636234562124916666";
			this.sprHIPAAReport_Sheet1.Columns.Get(2).Width = 98F;
			this.sprHIPAAReport_Sheet1.Columns.Get(3).StyleName = "Font901636234562124916666";
			this.sprHIPAAReport_Sheet1.Columns.Get(3).Width = 142F;
			this.sprHIPAAReport_Sheet1.Columns.Get(4).StyleName = "Font901636234562124916666";
			this.sprHIPAAReport_Sheet1.Columns.Get(4).Width = 262F;
			this.sprHIPAAReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprHIPAAReport_Sheet1.Rows.Get(0).Height = 23F;
			this.sprHIPAAReport_Sheet1.Rows.Get(1).Height = 21F;
			this.sprHIPAAReport_Sheet1.Rows.Get(4).Height = 19F;
			this.sprEMSReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEMSReport_Sheet1.SheetName = "Sheet1";
			this.sprEMSReport_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE REPORT";
			this.sprEMSReport_Sheet1.Cells.Get(0, 6).Value = "Print Date:";
			this.sprEMSReport_Sheet1.Cells.Get(1, 0).Value = "EMS PATIENT CONTACT REPORT";
			this.sprEMSReport_Sheet1.Cells.Get(3, 0).Value = "Incident Information";
			this.sprEMSReport_Sheet1.Cells.Get(4, 0).Value = "Incident Number:";
			this.sprEMSReport_Sheet1.Cells.Get(4, 5).Value = "Units";
			this.sprEMSReport_Sheet1.Cells.Get(4, 6).Value = "Dispatched";
			this.sprEMSReport_Sheet1.Cells.Get(4, 7).Value = "Onscene";
			this.sprEMSReport_Sheet1.Cells.Get(4, 8).Value = "Transport";
			this.sprEMSReport_Sheet1.Cells.Get(4, 9).Value = "Transport Complete";
			this.sprEMSReport_Sheet1.Cells.Get(4, 10).Value = "Available";
			this.sprEMSReport_Sheet1.Cells.Get(5, 0).Value = "Incident Date:";
			this.sprEMSReport_Sheet1.Cells.Get(6, 0).Value = "Location:";
			this.sprEMSReport_Sheet1.Cells.Get(7, 0).Value = "Incident Zipcode:";
			this.sprEMSReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprEMSReport_Sheet1.Columns.Get(0).Width = 122F;
			this.sprEMSReport_Sheet1.Columns.Get(1).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(1).Width = 49F;
			this.sprEMSReport_Sheet1.Columns.Get(2).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(2).Width = 51F;
			this.sprEMSReport_Sheet1.Columns.Get(3).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(3).Width = 52F;
			this.sprEMSReport_Sheet1.Columns.Get(4).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(4).Width = 62F;
			this.sprEMSReport_Sheet1.Columns.Get(5).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(5).Width = 65F;
			this.sprEMSReport_Sheet1.Columns.Get(6).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(6).Width = 78F;
			this.sprEMSReport_Sheet1.Columns.Get(7).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(7).Width = 65F;
			this.sprEMSReport_Sheet1.Columns.Get(8).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(8).Width = 71F;
			this.sprEMSReport_Sheet1.Columns.Get(9).StyleName = "Font901636234560853513666";
			this.sprEMSReport_Sheet1.Columns.Get(9).Width = 65F;
			this.sprEMSReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprEMSReport_Sheet1.Rows.Get(0).Height = 23F;
			this.sprEMSReport_Sheet1.Rows.Get(1).Height = 21F;
			this.sprEMSReport_Sheet1.Rows.Get(4).Height = 32F;
			this.sprEMSReport_Sheet1.Rows.Get(5).Height = 20F;
			this.sprEMSReport_Sheet1.Rows.Get(6).Height = 20F;
			this.sprEMSReport_Sheet1.Rows.Get(7).Height = 20F;
			this.sprEMSReport_Sheet1.Rows.Get(8).Height = 20F;
			this.cmdViewHIPAA = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdViewHIPAA
			// 
			this.cmdViewHIPAA.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdViewHIPAA.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdViewHIPAA.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdViewHIPAA.Name = "cmdViewHIPAA";
			this.cmdViewHIPAA.TabIndex = 4;
			this.cmdViewHIPAA.Text = "View HIPAA Access ";
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
			this.Text = "EMS Patient Contact Report";
			this.CurrRow = 0;
			this.IncidentNumber = "";
			this.PageCountRow = 0;
			this.PatientID = 0;
			this.SaveRow = 0;
			this.LastRow = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234560853484371", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text553636234560853494136", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font901636234560853513666");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font587636234560853621081");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font636636234560853650376");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font707636234560853669906");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font775636234560853689436");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color808636234560853699201");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color881636234560853738261");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1189636234560854050741");
			namedStyle10.CellType = textCellType2;
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = textCellType2;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1619636234560854412046");
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234562124887371", "DataAreaDefault");
			namedStyle12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Parent = "DataAreaDefault";
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text553636234562124906901", "DataAreaDefault");
			namedStyle13.CellType = textCellType3;
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Parent = "DataAreaDefault";
			namedStyle13.Renderer = textCellType3;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font901636234562124916666");
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1261636234562124955726");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1310636234562124975256");
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1370636234562125092436");
			namedStyle17.CellType = textCellType4;
			namedStyle17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType4;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1415636234562125131496");
			namedStyle18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1484636234562125151026");
			namedStyle19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1517636234562125170556");
			namedStyle20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1614636234562125199851");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1747636234562125277971");
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1827636234562125326796");
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2240636234562125707631");
			namedStyle24.CellType = textCellType5;
			namedStyle24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F);
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType5;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1108636234562130238591");
			namedStyle25.CellType = textCellType6;
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType6;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "TFDIncident.frmReportEMS";
			this.sprEMSReport.NamedStyles.Add(namedStyle1);
			this.sprEMSReport.NamedStyles.Add(namedStyle2);
			this.sprEMSReport.NamedStyles.Add(namedStyle3);
			this.sprEMSReport.NamedStyles.Add(namedStyle4);
			this.sprEMSReport.NamedStyles.Add(namedStyle5);
			this.sprEMSReport.NamedStyles.Add(namedStyle6);
			this.sprEMSReport.NamedStyles.Add(namedStyle7);
			this.sprEMSReport.NamedStyles.Add(namedStyle8);
			this.sprEMSReport.NamedStyles.Add(namedStyle9);
			this.sprEMSReport.NamedStyles.Add(namedStyle10);
			this.sprEMSReport.NamedStyles.Add(namedStyle11);
			this.sprEMSReport.Sheets.Add(this.sprEMSReport_Sheet1);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle12);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle13);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle14);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle15);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle16);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle17);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle18);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle19);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle20);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle21);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle22);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle23);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle24);
			this.sprHIPAAReport.NamedStyles.Add(namedStyle25);
			this.sprHIPAAReport.Sheets.Add(this.sprHIPAAReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEMSReport { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprHIPAAReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprHIPAAReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEMSReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdViewHIPAA { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String IncidentNumber { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PageCountRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PatientID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SaveRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 LastRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}