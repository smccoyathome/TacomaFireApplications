using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmUniformCheckList))]
	public class frmUniformCheckListViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType15 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle30;
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			FarPoint.ViewModels.NamedStyle namedStyle27;
			FarPoint.ViewModels.NamedStyle namedStyle26;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			FarPoint.ViewModels.NamedStyle namedStyle24;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprCheckList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprCheckList.TabIndex = 3;
			this.sprCheckList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprCheckList2 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprCheckList2.MaxRows = 1000;
			this.sprCheckList2.TabIndex = 4;
			this.sprCheckList2.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprCheckList2.Visible = false;
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 2;
			this.lbCount.Text = "Total Count:  ";
			this.sprCheckList2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCheckList2_Sheet1.SheetName = "Sheet1";
			this.sprCheckList2_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprCheckList2_Sheet1.Columns.Get(0).Width = 158F;
			this.sprCheckList2_Sheet1.Columns.Get(1).Width = 132F;
			this.sprCheckList2_Sheet1.Columns.Get(2).Width = 118F;
			this.sprCheckList2_Sheet1.Columns.Get(3).StyleName = "Static831636234785362934796";
			this.sprCheckList2_Sheet1.Columns.Get(3).Width = 81F;
			this.sprCheckList2_Sheet1.Columns.Get(4).StyleName = "Static831636234785362934796";
			this.sprCheckList2_Sheet1.Columns.Get(4).Width = 130F;
			this.sprCheckList2_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprCheckList2_Sheet1.Rows.Get(0).Height = 22F;
			this.sprCheckList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCheckList_Sheet1.SheetName = "Sheet1";
            //RowSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 0).RowSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 0).Value = "Name / WDL #";
            //RowSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 1).RowSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 1).Value = "WDL Exp Date";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 2).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 2).Value = "Coat";
			this.sprCheckList_Sheet1.Cells.Get(0, 3).Value = "Coat";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 4).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 4).Value = "Pants";
			this.sprCheckList_Sheet1.Cells.Get(0, 5).Value = "Pants";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 6).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 6).Value = "Helmet";
			this.sprCheckList_Sheet1.Cells.Get(0, 7).Value = "Helmet";
			this.sprCheckList_Sheet1.Cells.Get(0, 8).Value = "Helmet Ear Flaps";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 9).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 9).Value = "Flash Hood";
			this.sprCheckList_Sheet1.Cells.Get(0, 10).Value = "Flash Hood";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 11).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 11).Value = "Gloves";
			this.sprCheckList_Sheet1.Cells.Get(0, 12).Value = "Gloves";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 13).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 13).Value = "Boots";
			this.sprCheckList_Sheet1.Cells.Get(0, 14).Value = "Boots";
            //ColumnSpan is OBSOLETE
            //this.sprCheckList_Sheet1.Cells.Get(0, 15).ColumnSpan = 2;
			this.sprCheckList_Sheet1.Cells.Get(0, 15).Value = "Field Jacket";
			this.sprCheckList_Sheet1.Cells.Get(0, 16).Value = "Field Jacket";
			this.sprCheckList_Sheet1.Cells.Get(0, 17).Value = "Accountability Tag";
			this.sprCheckList_Sheet1.Cells.Get(1, 0).Value = "Name / WDL #";
			this.sprCheckList_Sheet1.Cells.Get(1, 1).Value = "WDL Exp Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 2).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 3).Value = "Brand     Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 4).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 5).Value = "Brand     Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 6).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 7).Value = "Brand     Color";
			this.sprCheckList_Sheet1.Cells.Get(1, 8).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 9).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 10).Value = "Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 11).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 12).Value = "Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 13).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 14).Value = "Brand     Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 15).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(1, 16).Value = "Brand     Size";
			this.sprCheckList_Sheet1.Cells.Get(1, 17).Value = "Tracking #   Issued Date";
			this.sprCheckList_Sheet1.Cells.Get(2, 2).Value = "Coat";
			this.sprCheckList_Sheet1.Cells.Get(2, 3).Value = "Coat";
			this.sprCheckList_Sheet1.Cells.Get(2, 4).Value = "Pants";
			this.sprCheckList_Sheet1.Cells.Get(2, 5).Value = "Pants";
			this.sprCheckList_Sheet1.Cells.Get(2, 6).Value = "Helmet";
			this.sprCheckList_Sheet1.Cells.Get(2, 7).Value = "Helmet";
			this.sprCheckList_Sheet1.Cells.Get(2, 8).Value = "Helmet Ear Flaps";
			this.sprCheckList_Sheet1.Cells.Get(2, 9).Value = "Flash Hood";
			this.sprCheckList_Sheet1.Cells.Get(2, 10).Value = "Flash Hood";
			this.sprCheckList_Sheet1.Cells.Get(2, 11).Value = "Gloves";
			this.sprCheckList_Sheet1.Cells.Get(2, 12).Value = "Gloves";
			this.sprCheckList_Sheet1.Cells.Get(2, 13).Value = "Boots";
			this.sprCheckList_Sheet1.Cells.Get(2, 14).Value = "Boots";
			this.sprCheckList_Sheet1.Cells.Get(2, 15).Value = "Field Jacket";
			this.sprCheckList_Sheet1.Cells.Get(2, 16).Value = "Field Jacket";
			this.sprCheckList_Sheet1.Cells.Get(2, 17).Value = "Accountability Tag";
			this.sprCheckList_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprCheckList_Sheet1.Columns.Get(0).Width = 128F;
			this.sprCheckList_Sheet1.Columns.Get(3).Width = 64F;
			this.sprCheckList_Sheet1.Columns.Get(8).Visible = false;
			this.sprCheckList_Sheet1.Columns.Get(8).Width = 0F;
			this.sprCheckList_Sheet1.Columns.Get(17).Visible = false;
			this.sprCheckList_Sheet1.Columns.Get(17).Width = 0F;
			this.sprCheckList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprCheckList_Sheet1.Rows.Get(2).Visible = false;
			this.chkOldFormat = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkOldFormat
			// 
			this.chkOldFormat.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkOldFormat.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.
					Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkOldFormat.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkOldFormat.Name = "chkOldFormat";
			this.chkOldFormat.TabIndex = 5;
			this.chkOldFormat.Text = "Print Old Format...";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 1;
			this.cmdExit.Text = "Exit";
			this.cmdPrintChecklist = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintChecklist
			// 
			this.cmdPrintChecklist.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintChecklist.Enabled = false;
			this.cmdPrintChecklist.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintChecklist.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintChecklist.Name = "cmdPrintChecklist";
			this.cmdPrintChecklist.TabIndex = 0;
			this.cmdPrintChecklist.Text = "Print Inspection Check List";
			this.Text = "TFD PPE Checklist for Batt - Shift";
			this.CurrBatt = "";
			this.CurrShift = "";
			this.sHeadingFilter = "";
			this.PrintOldFormat = false;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234785077767501", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text309636234785077777266", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1377636234785077806561");
			namedStyle3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1424636234785077806561");
			namedStyle4.CellType = textCellType2;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1469636234785077826091");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1534636234785077826091");
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1552636234785077835856");
			namedStyle7.CellType = textCellType4;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1609636234785077845621");
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1627636234785077845621");
			namedStyle9.CellType = textCellType5;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1990636234785077923741");
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2008636234785077923741");
			namedStyle11.CellType = textCellType6;
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2941636234785078167866");
			namedStyle12.CellType = textCellType7;
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.Renderer = textCellType7;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3036636234785078187396");
			namedStyle13.CellType = textCellType8;
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType8;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3464636234785078245986");
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3482636234785078255751");
			namedStyle15.CellType = textCellType9;
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType9;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3672636234785078285046");
			namedStyle16.CellType = textCellType10;
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType10;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color259636234785078372931");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2923636234785078167866");
			namedStyle18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3018636234785078177631");
			namedStyle19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			namedStyle19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx484636234785078402226");
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx564636234785078411991");
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1465636234785078548701");
			namedStyle22.CellType = textCellType11;
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType11;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1483636234785078558466");
			namedStyle23.CellType = textCellType12;
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.Renderer = textCellType12;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color1505636234785078558466");
			namedStyle24.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1523636234785078558466");
			namedStyle25.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle25.CellType = textCellType13;
			namedStyle25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType13;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1436636234785078548701");
			namedStyle26.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2336636234785078861181");
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234785362895736", "DataAreaDefault");
			namedStyle28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.Parent = "DataAreaDefault";
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text288636234785362905501", "DataAreaDefault");
			namedStyle29.CellType = textCellType14;
			namedStyle29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Parent = "DataAreaDefault";
			namedStyle29.Renderer = textCellType14;
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static831636234785362934796");
			namedStyle30.CellType = textCellType15;
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.Renderer = textCellType15;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmUniformCheckList";
			this.sprCheckList.NamedStyles.Add(namedStyle1);
			this.sprCheckList.NamedStyles.Add(namedStyle2);
			this.sprCheckList.NamedStyles.Add(namedStyle3);
			this.sprCheckList.NamedStyles.Add(namedStyle4);
			this.sprCheckList.NamedStyles.Add(namedStyle5);
			this.sprCheckList.NamedStyles.Add(namedStyle6);
			this.sprCheckList.NamedStyles.Add(namedStyle7);
			this.sprCheckList.NamedStyles.Add(namedStyle8);
			this.sprCheckList.NamedStyles.Add(namedStyle9);
			this.sprCheckList.NamedStyles.Add(namedStyle10);
			this.sprCheckList.NamedStyles.Add(namedStyle11);
			this.sprCheckList.NamedStyles.Add(namedStyle12);
			this.sprCheckList.NamedStyles.Add(namedStyle13);
			this.sprCheckList.NamedStyles.Add(namedStyle14);
			this.sprCheckList.NamedStyles.Add(namedStyle15);
			this.sprCheckList.NamedStyles.Add(namedStyle16);
			this.sprCheckList.NamedStyles.Add(namedStyle17);
			this.sprCheckList.NamedStyles.Add(namedStyle18);
			this.sprCheckList.NamedStyles.Add(namedStyle19);
			this.sprCheckList.NamedStyles.Add(namedStyle20);
			this.sprCheckList.NamedStyles.Add(namedStyle21);
			this.sprCheckList.NamedStyles.Add(namedStyle22);
			this.sprCheckList.NamedStyles.Add(namedStyle23);
			this.sprCheckList.NamedStyles.Add(namedStyle24);
			this.sprCheckList.NamedStyles.Add(namedStyle25);
			this.sprCheckList.NamedStyles.Add(namedStyle26);
			this.sprCheckList.NamedStyles.Add(namedStyle27);
			this.sprCheckList.Sheets.Add(this.sprCheckList_Sheet1);
			this.sprCheckList2.NamedStyles.Add(namedStyle28);
			this.sprCheckList2.NamedStyles.Add(namedStyle29);
			this.sprCheckList2.NamedStyles.Add(namedStyle30);
			this.sprCheckList2.Sheets.Add(this.sprCheckList2_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprCheckList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprCheckList2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCheckList2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCheckList_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkOldFormat { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintChecklist { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrBatt { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sHeadingFilter { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean PrintOldFormat { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}