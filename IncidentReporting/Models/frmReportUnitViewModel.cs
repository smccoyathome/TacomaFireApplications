using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmReportUnit))]
	public class frmReportUnitViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
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
			this.sprUnitRpt = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprUnitRpt.MaxRows = 1010;
			this.sprUnitRpt.TabIndex = 3;
			this.sprUnitRpt.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Unit Report - Print Preview";
			this.sprUnitRpt_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprUnitRpt_Sheet1.SheetName = "Sheet1";
			this.sprUnitRpt_Sheet1.Cells.Get(0, 0).Value = "TACOMA FIRE REPORT";
			this.sprUnitRpt_Sheet1.Cells.Get(0, 4).Value = "Print Date";
			this.sprUnitRpt_Sheet1.Cells.Get(1, 0).Value = "UNIT REPORT";
			this.sprUnitRpt_Sheet1.Cells.Get(3, 0).Value = "Incident Information";
			this.sprUnitRpt_Sheet1.Cells.Get(4, 0).Value = "Incident Number:";
			this.sprUnitRpt_Sheet1.Cells.Get(5, 0).Value = "Initial Type:";
			this.sprUnitRpt_Sheet1.Cells.Get(6, 0).Value = "Final Type:";
			this.sprUnitRpt_Sheet1.Cells.Get(9, 0).Value = "Unit Response - Time Stamps";
			this.sprUnitRpt_Sheet1.Cells.Get(10, 1).Value = "Date";
			this.sprUnitRpt_Sheet1.Cells.Get(10, 2).Value = "CAD Time";
			this.sprUnitRpt_Sheet1.Cells.Get(10, 3).Value = "Amended Time";
			this.sprUnitRpt_Sheet1.Cells.Get(10, 4).Value = "Reason Amended";
			this.sprUnitRpt_Sheet1.Cells.Get(11, 0).Value = "Unit Dispatched:";
			this.sprUnitRpt_Sheet1.Cells.Get(12, 0).Value = "Unit Turnout:";
			this.sprUnitRpt_Sheet1.Cells.Get(13, 0).Value = "Unit Onscene:";
			this.sprUnitRpt_Sheet1.Cells.Get(14, 0).Value = "Unit Transport:";
			this.sprUnitRpt_Sheet1.Cells.Get(15, 0).Value = "Unit Transport Complete:";
			this.sprUnitRpt_Sheet1.Cells.Get(16, 0).Value = "Unit Available:";
			this.sprUnitRpt_Sheet1.Cells.Get(19, 0).Value = "Unit Delay:";
			this.sprUnitRpt_Sheet1.Cells.Get(23, 0).Value = "Unit Actions";
			this.sprUnitRpt_Sheet1.Cells.Get(25, 0).Value = "Action Category";
			this.sprUnitRpt_Sheet1.Cells.Get(25, 1).Value = "Unit Action";
			this.sprUnitRpt_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprUnitRpt_Sheet1.Columns.Get(0).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(0).Width = 158F;
			this.sprUnitRpt_Sheet1.Columns.Get(1).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(1).Width = 65F;
			this.sprUnitRpt_Sheet1.Columns.Get(2).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(2).Width = 69F;
			this.sprUnitRpt_Sheet1.Columns.Get(3).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(3).Width = 97F;
			this.sprUnitRpt_Sheet1.Columns.Get(4).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(4).Width = 98F;
			this.sprUnitRpt_Sheet1.Columns.Get(5).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(5).Width = 62F;
			this.sprUnitRpt_Sheet1.Columns.Get(6).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(6).Width = 41F;
			this.sprUnitRpt_Sheet1.Columns.Get(7).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(7).Width = 68F;
			this.sprUnitRpt_Sheet1.Columns.Get(8).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(8).Width = 71F;
			this.sprUnitRpt_Sheet1.Columns.Get(9).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(9).Width = 38F;
			this.sprUnitRpt_Sheet1.Columns.Get(10).StyleName = "Font813636234565487416296";
			this.sprUnitRpt_Sheet1.Columns.Get(10).Width = 50F;
			this.sprUnitRpt_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprUnitRpt_Sheet1.Rows.Get(0).Height = 28F;
			this.sprUnitRpt_Sheet1.Rows.Get(1).Height = 21F;
			this.sprUnitRpt_Sheet1.Rows.Get(2).Height = 6F;
			this.sprUnitRpt_Sheet1.Rows.Get(3).Height = 23F;
			this.sprUnitRpt_Sheet1.Rows.Get(23).Height = 21F;
			this.Text = "Unit Report";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234565487377236", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text517636234565487396766", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font813636234565487416296");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font610636234565487709246");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font659636234565487728776");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font729636234565487767836");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color835636234565487797131");
			namedStyle7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))));
			namedStyle7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color908636234565487826426");
			namedStyle8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1781636234565488578331");
			namedStyle9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2527636234565489506006");
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2619636234565489632951");
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "TFDIncident.frmReportUnit";
			this.sprUnitRpt.NamedStyles.Add(namedStyle1);
			this.sprUnitRpt.NamedStyles.Add(namedStyle2);
			this.sprUnitRpt.NamedStyles.Add(namedStyle3);
			this.sprUnitRpt.NamedStyles.Add(namedStyle4);
			this.sprUnitRpt.NamedStyles.Add(namedStyle5);
			this.sprUnitRpt.NamedStyles.Add(namedStyle6);
			this.sprUnitRpt.NamedStyles.Add(namedStyle7);
			this.sprUnitRpt.NamedStyles.Add(namedStyle8);
			this.sprUnitRpt.NamedStyles.Add(namedStyle9);
			this.sprUnitRpt.NamedStyles.Add(namedStyle10);
			this.sprUnitRpt.NamedStyles.Add(namedStyle11);
			this.sprUnitRpt.Sheets.Add(this.sprUnitRpt_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprUnitRpt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprUnitRpt_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}