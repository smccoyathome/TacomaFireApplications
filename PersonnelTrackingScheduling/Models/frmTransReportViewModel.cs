using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTransReport))]
	public class frmTransReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprTrans = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprTrans.MaxRows = 420;
			this.sprTrans.TabIndex = 4;
			this.sprTrans.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 1;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Select Report Year";
			this.sprTrans_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTrans_Sheet1.SheetName = "Sheet1";
			this.sprTrans_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprTrans_Sheet1.Cells.Get(1, 0).Value = "Transfer Schedule";
			this.sprTrans_Sheet1.Cells.Get(2, 0).Value = "Date";
			this.sprTrans_Sheet1.Cells.Get(2, 1).Value = "Wkdy";
			this.sprTrans_Sheet1.Cells.Get(2, 2).Value = "Shift";
			this.sprTrans_Sheet1.Cells.Get(2, 3).Value = "YTD Worked";
			this.sprTrans_Sheet1.Cells.Get(2, 4).Value = "YTD Remain";
			this.sprTrans_Sheet1.Cells.Get(2, 5).Value = "Debit Grp";
			this.sprTrans_Sheet1.Cells.Get(2, 6).Value = "YTD Dbt Worked";
			this.sprTrans_Sheet1.Cells.Get(2, 7).Value = "YTD Dbt Remain";
			this.sprTrans_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprTrans_Sheet1.Columns.Get(0).Width = 77F;
			this.sprTrans_Sheet1.Columns.Get(1).Width = 52F;
			this.sprTrans_Sheet1.Columns.Get(2).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(2).Width = 38F;
			this.sprTrans_Sheet1.Columns.Get(3).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(3).Width = 99F;
			this.sprTrans_Sheet1.Columns.Get(4).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(4).Width = 96F;
			this.sprTrans_Sheet1.Columns.Get(5).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(5).Width = 77F;
			this.sprTrans_Sheet1.Columns.Get(6).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(6).Width = 126F;
			this.sprTrans_Sheet1.Columns.Get(7).StyleName = "Static883636234783667115601";
			this.sprTrans_Sheet1.Columns.Get(7).Width = 130F;
			this.sprTrans_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprTrans_Sheet1.Rows.Get(0).Height = 21F;
			this.sprTrans_Sheet1.Rows.Get(1).Height = 30F;
			this.sprTrans_Sheet1.Rows.Get(2).Height = 21F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 3;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.Text = "&Print";
			this.Text = "Transfer Schedule Report";
			this.ReportYear = "";
			this.CurrRow = 0;
			this.PageRow = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234783667086306", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text454636234783667105836", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static883636234783667115601");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1272636234783667164426");
			namedStyle4.CellType = textCellType3;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType3;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1288636234783667164426");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1306636234783667164426");
			namedStyle6.CellType = textCellType4;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1454636234783667203486");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1617636234783667291371");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1651636234783667310901");
			namedStyle9.CellType = textCellType5;
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1708636234783667320666");
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1742636234783667349961");
			namedStyle11.CellType = textCellType6;
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1799636234783667369491");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2192636234783667525731");
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2282636234783667574556");
			namedStyle14.CellType = textCellType7;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType7;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color2445636234783667799151");
			namedStyle15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2479636234783667828446");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle16.CellType = textCellType8;
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType8;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color2501636234783667847976");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmTransReport";
			IsMdiChild = true;
			cboYear.Items.Add("1997");
			cboYear.Items.Add("1998");
			cboYear.Items.Add("1999");
			cboYear.Items.Add("2000");
			cboYear.Items.Add("2001");
			cboYear.Items.Add("2002");
			cboYear.Items.Add("2003");
			cboYear.Items.Add("2004");
			cboYear.Items.Add("2005");
			this.sprTrans.NamedStyles.Add(namedStyle1);
			this.sprTrans.NamedStyles.Add(namedStyle2);
			this.sprTrans.NamedStyles.Add(namedStyle3);
			this.sprTrans.NamedStyles.Add(namedStyle4);
			this.sprTrans.NamedStyles.Add(namedStyle5);
			this.sprTrans.NamedStyles.Add(namedStyle6);
			this.sprTrans.NamedStyles.Add(namedStyle7);
			this.sprTrans.NamedStyles.Add(namedStyle8);
			this.sprTrans.NamedStyles.Add(namedStyle9);
			this.sprTrans.NamedStyles.Add(namedStyle10);
			this.sprTrans.NamedStyles.Add(namedStyle11);
			this.sprTrans.NamedStyles.Add(namedStyle12);
			this.sprTrans.NamedStyles.Add(namedStyle13);
			this.sprTrans.NamedStyles.Add(namedStyle14);
			this.sprTrans.NamedStyles.Add(namedStyle15);
			this.sprTrans.NamedStyles.Add(namedStyle16);
			this.sprTrans.NamedStyles.Add(namedStyle17);
			this.sprTrans.Sheets.Add(this.sprTrans_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprTrans { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTrans_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReportYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PageRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}