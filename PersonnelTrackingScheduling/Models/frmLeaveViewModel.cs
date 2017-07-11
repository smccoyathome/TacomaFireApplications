using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmLeave))]
	public class frmLeaveViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType16 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle32;
			var textCellType15 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle31;
			FarPoint.ViewModels.NamedStyle namedStyle30;
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			FarPoint.ViewModels.NamedStyle namedStyle27;
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle26;
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle20;
			FarPoint.ViewModels.NamedStyle namedStyle19;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.sprLeave = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprLeave.MaxRows = 49;
			this.sprLeave.TabIndex = 4;
			this.sprLeave.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.calDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calDate.MinDate = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
			this.calDate.Name = "calDate";
			this.calDate.TabIndex = 0;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "* = Instead Of Sick Leave...";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Select Report Date";
			this.sprLeave_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeave_Sheet1.SheetName = "Sheet1";
			this.sprLeave_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprLeave_Sheet1.Cells.Get(1, 0).Value = "Daily Leave Report";
			this.sprLeave_Sheet1.Cells.Get(1, 4).Value = "MM/DD/YY";
			this.sprLeave_Sheet1.Cells.Get(1, 6).Value = "Shift";
			this.sprLeave_Sheet1.Cells.Get(1, 8).Value = "Debit Grp";
			this.sprLeave_Sheet1.Cells.Get(3, 0).Value = "Scheduled Leave";
			this.sprLeave_Sheet1.Cells.Get(3, 6).Value = "Not Sched & Trades";
			this.sprLeave_Sheet1.Cells.Get(4, 0).Value = "All Battalions";
			this.sprLeave_Sheet1.Cells.Get(4, 6).Value = "All Battalions";
			this.sprLeave_Sheet1.Cells.Get(5, 0).Value = "Employee";
			this.sprLeave_Sheet1.Cells.Get(5, 1).Value = "AM";
			this.sprLeave_Sheet1.Cells.Get(5, 2).Value = "PM";
			this.sprLeave_Sheet1.Cells.Get(5, 3).Value = "Unit";
			this.sprLeave_Sheet1.Cells.Get(5, 4).Value = "Pos (Batt)";
			this.sprLeave_Sheet1.Cells.Get(5, 6).Value = "Employee";
			this.sprLeave_Sheet1.Cells.Get(5, 7).Value = "AM";
			this.sprLeave_Sheet1.Cells.Get(5, 8).Value = "PM";
			this.sprLeave_Sheet1.Cells.Get(5, 9).Value = "Unit";
			this.sprLeave_Sheet1.Cells.Get(5, 10).Value = "Pos (Batt)";
			this.sprLeave_Sheet1.Cells.Get(34, 0).Value = "Leave Totals";
			this.sprLeave_Sheet1.Cells.Get(34, 1).Value = "AM";
			this.sprLeave_Sheet1.Cells.Get(34, 2).Value = "PM";
			this.sprLeave_Sheet1.Cells.Get(34, 6).Value = "FCC";
			this.sprLeave_Sheet1.Cells.Get(35, 0).Value = "REG";
			this.sprLeave_Sheet1.Cells.Get(35, 6).Value = "Employee";
			this.sprLeave_Sheet1.Cells.Get(35, 7).Value = "AM";
			this.sprLeave_Sheet1.Cells.Get(35, 8).Value = "PM";
			this.sprLeave_Sheet1.Cells.Get(35, 9).Value = "Unit";
			this.sprLeave_Sheet1.Cells.Get(35, 10).Value = "Position";
			this.sprLeave_Sheet1.Cells.Get(36, 0).Value = "Paramedic";
			this.sprLeave_Sheet1.Cells.Get(37, 0).Value = "HazMat";
			this.sprLeave_Sheet1.Cells.Get(38, 0).Value = "Marine";
			this.sprLeave_Sheet1.Cells.Get(39, 0).Value = "Battalion Staff";
			this.sprLeave_Sheet1.Cells.Get(45, 0).Value = "TFD Daily Leave Report";
			this.sprLeave_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprLeave_Sheet1.Columns.Get(0).Width = 152F;
			this.sprLeave_Sheet1.Columns.Get(1).Width = 51F;
			this.sprLeave_Sheet1.Columns.Get(2).Width = 52F;
			this.sprLeave_Sheet1.Columns.Get(3).Width = 45F;
			this.sprLeave_Sheet1.Columns.Get(4).Width = 69F;
			this.sprLeave_Sheet1.Columns.Get(5).Width = 10F;
			this.sprLeave_Sheet1.Columns.Get(6).Width = 152F;
			this.sprLeave_Sheet1.Columns.Get(7).Width = 52F;
			this.sprLeave_Sheet1.Columns.Get(8).Width = 52F;
			this.sprLeave_Sheet1.Columns.Get(9).Width = 46F;
			this.sprLeave_Sheet1.Columns.Get(10).StyleName = "Static1235636234731154675831";
			this.sprLeave_Sheet1.Columns.Get(10).Width = 70F;
			this.sprLeave_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprLeave_Sheet1.Rows.Get(0).Height = 24F;
			this.sprLeave_Sheet1.Rows.Get(1).Height = 27F;
			this.sprLeave_Sheet1.Rows.Get(3).Height = 21F;
			this.sprLeave_Sheet1.Rows.Get(5).Height = 21F;
			this.sprLeave_Sheet1.Rows.Get(6).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(7).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(8).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(9).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(10).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(11).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(12).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(13).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(14).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(15).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(16).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(17).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(18).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(19).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(20).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(21).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(22).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(23).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(24).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(25).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(26).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(27).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(28).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(29).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(30).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(31).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(32).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(33).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(34).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(35).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(36).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(37).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(38).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(39).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(40).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(41).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(42).Height = 19F;
			this.sprLeave_Sheet1.Rows.Get(43).Height = 15F;
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
			this.Text = "Daily Leave Report";
			this.FirstTime = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234731154597711", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text486636234731154617241", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1235636234731154675831");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1350636234731154685596");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1368636234731154685596");
			namedStyle5.CellType = textCellType3;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1743636234731154880896");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1970636234731154998076");
			namedStyle7.CellType = textCellType4;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Right;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2086636234731155193376");
			namedStyle8.CellType = textCellType5;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = textCellType5;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font2718636234731155603506");
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2785636234731155623036");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2803636234731155632801");
			namedStyle11.CellType = textCellType6;
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2864636234731155652331");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2882636234731155671861");
			namedStyle13.CellType = textCellType7;
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType7;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3085636234731155779276");
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3103636234731155798806");
			namedStyle15.CellType = textCellType8;
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3146636234731155886691");
			namedStyle16.CellType = textCellType9;
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType9;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3184636234731155906221");
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3202636234731155935516");
			namedStyle18.CellType = textCellType10;
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.Renderer = textCellType10;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3263636234731155955046");
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3281636234731155984341");
			namedStyle20.CellType = textCellType11;
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType11;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3484636234731156150346");
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3502636234731156179641");
			namedStyle22.CellType = textCellType12;
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType12;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx139636234731156912016");
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static157636234731156941311");
			namedStyle24.CellType = textCellType13;
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType13;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx249636234731157058491");
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static267636234731157078021");
			namedStyle26.CellType = textCellType14;
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Renderer = textCellType14;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1957636234731164489656");
			namedStyle27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3977636234731166257121");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx4015636234731166286416");
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx38636234731166354771");
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1784636234731167995291");
			namedStyle31.CellType = textCellType15;
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType15;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle32 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1894636234731168171061");
			namedStyle32.CellType = textCellType16;
			namedStyle32.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle32.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle32.Renderer = textCellType16;
			namedStyle32.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmLeave";
			IsMdiChild = true;
			this.sprLeave.NamedStyles.Add(namedStyle1);
			this.sprLeave.NamedStyles.Add(namedStyle2);
			this.sprLeave.NamedStyles.Add(namedStyle3);
			this.sprLeave.NamedStyles.Add(namedStyle4);
			this.sprLeave.NamedStyles.Add(namedStyle5);
			this.sprLeave.NamedStyles.Add(namedStyle6);
			this.sprLeave.NamedStyles.Add(namedStyle7);
			this.sprLeave.NamedStyles.Add(namedStyle8);
			this.sprLeave.NamedStyles.Add(namedStyle9);
			this.sprLeave.NamedStyles.Add(namedStyle10);
			this.sprLeave.NamedStyles.Add(namedStyle11);
			this.sprLeave.NamedStyles.Add(namedStyle12);
			this.sprLeave.NamedStyles.Add(namedStyle13);
			this.sprLeave.NamedStyles.Add(namedStyle14);
			this.sprLeave.NamedStyles.Add(namedStyle15);
			this.sprLeave.NamedStyles.Add(namedStyle16);
			this.sprLeave.NamedStyles.Add(namedStyle17);
			this.sprLeave.NamedStyles.Add(namedStyle18);
			this.sprLeave.NamedStyles.Add(namedStyle19);
			this.sprLeave.NamedStyles.Add(namedStyle20);
			this.sprLeave.NamedStyles.Add(namedStyle21);
			this.sprLeave.NamedStyles.Add(namedStyle22);
			this.sprLeave.NamedStyles.Add(namedStyle23);
			this.sprLeave.NamedStyles.Add(namedStyle24);
			this.sprLeave.NamedStyles.Add(namedStyle25);
			this.sprLeave.NamedStyles.Add(namedStyle26);
			this.sprLeave.NamedStyles.Add(namedStyle27);
			this.sprLeave.NamedStyles.Add(namedStyle28);
			this.sprLeave.NamedStyles.Add(namedStyle29);
			this.sprLeave.NamedStyles.Add(namedStyle30);
			this.sprLeave.NamedStyles.Add(namedStyle31);
			this.sprLeave.NamedStyles.Add(namedStyle32);
			this.sprLeave.Sheets.Add(this.sprLeave_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprLeave { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeave_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}