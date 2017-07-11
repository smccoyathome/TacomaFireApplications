using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmSickLeaveUsage))]
	public class frmSickLeaveUsageViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			FarPoint.ViewModels.NamedStyle namedStyle22;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprDaysOff = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprDaysOff.MaxRows = 40;
			this.sprDaysOff.TabIndex = 8;
			this.sprDaysOff.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboMonth = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMonth
			// 
			this.cboMonth.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMonth.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMonth.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboMonth.Name = "cboMonth";
			this.cboMonth.TabIndex = 4;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 3;
			this.sprDetail = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprDetail.TabIndex = 0;
			this.sprDetail.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Report Month";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Report Year";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "^^^^^  Click On cell amount to display daily detail below... ^^^^^";
			this.sprDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDetail_Sheet1.SheetName = "Sheet1";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 0].Value = "Shift Date";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 1].Value = "Employee";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 2].Value = "Record Created by";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 3].Value = "Created On";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 4].Value = "Leave KOT";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 5].Value = "Assoc Note...";
			this.sprDetail_Sheet1.ColumnHeader.Rows.Get(0).Height = 29F;
			this.sprDetail_Sheet1.Columns.Get(0).Label = "Shift Date";
			this.sprDetail_Sheet1.Columns.Get(0).Width = 90F;
			this.sprDetail_Sheet1.Columns.Get(1).Label = "Employee";
			this.sprDetail_Sheet1.Columns.Get(1).Width = 131F;
			this.sprDetail_Sheet1.Columns.Get(2).Label = "Record Created by";
			this.sprDetail_Sheet1.Columns.Get(2).Width = 131F;
			this.sprDetail_Sheet1.Columns.Get(3).Label = "Created On";
			this.sprDetail_Sheet1.Columns.Get(3).Width = 115F;
			this.sprDetail_Sheet1.Columns.Get(4).Label = "Leave KOT";
			this.sprDetail_Sheet1.Columns.Get(4).Width = 57F;
			this.sprDetail_Sheet1.Columns.Get(5).Label = "Assoc Note...";
			this.sprDetail_Sheet1.Columns.Get(5).Width = 210F;
			this.sprDetail_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprDaysOff_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDaysOff_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprDaysOff_Sheet1.Cells.Get(0, 0).ColumnSpan = 15;
			this.sprDaysOff_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			//this.sprDaysOff_Sheet1.Cells.Get(1, 0).ColumnSpan = 15;
			this.sprDaysOff_Sheet1.Cells.Get(1, 0).Value = "Sick Leave Usage Report";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 3).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 3).Value = "HOL (Recognized)";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 5).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 5).Value = "DDF (Scheduled)";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 7).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 7).Value = "TRD (Scheduled)";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 9).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 9).Value = "Weekend (Fri - Sun)";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 11).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 11).Value = "Associated w/ VAC or HOL";
			//this.sprDaysOff_Sheet1.Cells.Get(2, 13).ColumnSpan = 2;
			this.sprDaysOff_Sheet1.Cells.Get(2, 13).Value = "Total Sick Leave";
			this.sprDaysOff_Sheet1.Cells.Get(3, 0).Value = "Date";
			this.sprDaysOff_Sheet1.Cells.Get(3, 2).Value = "Shf";
			this.sprDaysOff_Sheet1.Cells.Get(3, 3).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 4).Value = "PM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 5).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 6).Value = "PM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 7).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 8).Value = "PM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 9).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 10).Value = "PM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 11).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 12).Value = "PM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 13).Value = "AM";
			this.sprDaysOff_Sheet1.Cells.Get(3, 14).Value = "PM";
			this.sprDaysOff_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprDaysOff_Sheet1.Columns.Get(0).Width = 69F;
			this.sprDaysOff_Sheet1.Columns.Get(1).Width = 36F;
			this.sprDaysOff_Sheet1.Columns.Get(2).Width = 24F;
			this.sprDaysOff_Sheet1.Columns.Get(3).Width = 49F;
			this.sprDaysOff_Sheet1.Columns.Get(4).Width = 49F;
			this.sprDaysOff_Sheet1.Columns.Get(5).Width = 44F;
			this.sprDaysOff_Sheet1.Columns.Get(6).Width = 44F;
			this.sprDaysOff_Sheet1.Columns.Get(7).Width = 44F;
			this.sprDaysOff_Sheet1.Columns.Get(8).Width = 44F;
			this.sprDaysOff_Sheet1.Columns.Get(9).Width = 53F;
			this.sprDaysOff_Sheet1.Columns.Get(10).Width = 53F;
			this.sprDaysOff_Sheet1.Columns.Get(11).Width = 62F;
			this.sprDaysOff_Sheet1.Columns.Get(12).Width = 62F;
			this.sprDaysOff_Sheet1.Columns.Get(13).Width = 44F;
			this.sprDaysOff_Sheet1.Columns.Get(14).Width = 44F;
			this.sprDaysOff_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprDaysOff_Sheet1.Rows.Get(0).Height = 22F;
			this.sprDaysOff_Sheet1.Rows.Get(1).Height = 22F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 1;
			this.cmdPrint.Text = "&Print";
			this.Text = "Sick Leave Usage Report";
			this.OTMonth = 0;
			this.OTYear = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234767399748576", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text455636234767399768106", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1568636234767399855991");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1613636234767399865756");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1631636234767399875521");
			namedStyle5.CellType = textCellType2;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType2;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1731636234767399904816");
			namedStyle6.CellType = textCellType3;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1785636234767399914581");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1834636234767399924346");
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1948636234767399934111");
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1966636234767399943876");
			namedStyle10.CellType = textCellType4;
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Renderer = textCellType4;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2035636234767400070821");
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2734636234767400227061");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2752636234767400236826");
			namedStyle13.CellType = textCellType5;
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType5;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2921636234767400266121");
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2939636234767400275886");
			namedStyle15.CellType = textCellType6;
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType6;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2994636234767400285651");
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3012636234767400295416");
			namedStyle17.CellType = textCellType7;
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType7;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3842636234767400490716");
			namedStyle18.CellType = textCellType8;
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType8;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3898636234767400500481");
			namedStyle19.CellType = textCellType9;
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType9;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3824636234767400480951");
			namedStyle20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static526636234767400705546");
			namedStyle21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			namedStyle21.CellType = textCellType10;
			namedStyle21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType10;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx564636234767400705546");
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234767501040921", "DataAreaDefault");
			namedStyle23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Parent = "DataAreaDefault";
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text307636234767501050686", "DataAreaDefault");
			namedStyle24.CellType = textCellType11;
			namedStyle24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Parent = "DataAreaDefault";
			namedStyle24.Renderer = textCellType11;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmSickLeaveUsage";
			IsMdiChild = true;
			cboMonth.Items.Add("January");
			cboMonth.Items.Add("February");
			cboMonth.Items.Add("March");
			cboMonth.Items.Add("April");
			cboMonth.Items.Add("May");
			cboMonth.Items.Add("June");
			cboMonth.Items.Add("July");
			cboMonth.Items.Add("August");
			cboMonth.Items.Add("September");
			cboMonth.Items.Add("October");
			cboMonth.Items.Add("November");
			cboMonth.Items.Add("December");
			cboYear.Items.Add("1998");
			cboYear.Items.Add("1999");
			cboYear.Items.Add("2000");
			cboYear.Items.Add("2001");
			cboYear.Items.Add("2002");
			cboYear.Items.Add("2003");
			cboYear.Items.Add("2004");
			cboYear.Items.Add("2005");
			this.sprDaysOff.NamedStyles.Add(namedStyle1);
			this.sprDaysOff.NamedStyles.Add(namedStyle2);
			this.sprDaysOff.NamedStyles.Add(namedStyle3);
			this.sprDaysOff.NamedStyles.Add(namedStyle4);
			this.sprDaysOff.NamedStyles.Add(namedStyle5);
			this.sprDaysOff.NamedStyles.Add(namedStyle6);
			this.sprDaysOff.NamedStyles.Add(namedStyle7);
			this.sprDaysOff.NamedStyles.Add(namedStyle8);
			this.sprDaysOff.NamedStyles.Add(namedStyle9);
			this.sprDaysOff.NamedStyles.Add(namedStyle10);
			this.sprDaysOff.NamedStyles.Add(namedStyle11);
			this.sprDaysOff.NamedStyles.Add(namedStyle12);
			this.sprDaysOff.NamedStyles.Add(namedStyle13);
			this.sprDaysOff.NamedStyles.Add(namedStyle14);
			this.sprDaysOff.NamedStyles.Add(namedStyle15);
			this.sprDaysOff.NamedStyles.Add(namedStyle16);
			this.sprDaysOff.NamedStyles.Add(namedStyle17);
			this.sprDaysOff.NamedStyles.Add(namedStyle18);
			this.sprDaysOff.NamedStyles.Add(namedStyle19);
			this.sprDaysOff.NamedStyles.Add(namedStyle20);
			this.sprDaysOff.NamedStyles.Add(namedStyle21);
			this.sprDaysOff.NamedStyles.Add(namedStyle22);
			this.sprDaysOff.Sheets.Add(this.sprDaysOff_Sheet1);
			this.sprDetail.NamedStyles.Add(namedStyle23);
			this.sprDetail.NamedStyles.Add(namedStyle24);
			this.sprDetail.Sheets.Add(this.sprDetail_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprDaysOff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMonth { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDetail_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDaysOff_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OTMonth { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OTYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}