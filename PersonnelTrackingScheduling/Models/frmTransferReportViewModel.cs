using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTransferReport))]
	public class frmTransferReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle26;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle21;
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			FarPoint.ViewModels.NamedStyle namedStyle17;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle14;
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle11;
			FarPoint.ViewModels.NamedStyle namedStyle10;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprIndiv = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprIndiv.MaxRows = 250;
			this.sprIndiv.TabIndex = 2;
			this.sprIndiv.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprIndiv_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprIndiv_Sheet1.SheetName = "Sheet1";
			this.sprIndiv_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprIndiv_Sheet1.Cells.Get(1, 0).Value = "Individual Transfer Report";
			this.sprIndiv_Sheet1.Cells.Get(1, 6).Value = "Print Date";
			this.sprIndiv_Sheet1.Cells.Get(1, 7).Value = "Date";
			this.sprIndiv_Sheet1.Cells.Get(3, 0).Value = "Name";
			this.sprIndiv_Sheet1.Cells.Get(3, 4).Value = "EmpID";
			this.sprIndiv_Sheet1.Cells.Get(4, 0).Value = "Current Position";
			this.sprIndiv_Sheet1.Cells.Get(4, 4).Value = "New Position";
			this.sprIndiv_Sheet1.Cells.Get(5, 0).Value = "Transfer Date";
			this.sprIndiv_Sheet1.Cells.Get(5, 4).Value = "Transfer Type";
			this.sprIndiv_Sheet1.Cells.Get(7, 0).Value = "Scheduled Leave/Debits for Old Position";
			this.sprIndiv_Sheet1.Cells.Get(7, 5).Value = "Canceled Trades";
			this.sprIndiv_Sheet1.Cells.Get(8, 0).Value = "Date";
			this.sprIndiv_Sheet1.Cells.Get(8, 1).Value = "KOT Type";
			this.sprIndiv_Sheet1.Cells.Get(8, 2).Value = "Shift";
			this.sprIndiv_Sheet1.Cells.Get(8, 4).Value = "Trade Date";
			this.sprIndiv_Sheet1.Cells.Get(8, 5).Value = "Scheduled Employee";
			this.sprIndiv_Sheet1.Cells.Get(8, 6).Value = "Working Employee";
			this.sprIndiv_Sheet1.Cells.Get(8, 7).Value = "Assignment";
			this.sprIndiv_Sheet1.Cells.Get(8, 8).Value = "Shift";
			this.sprIndiv_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprIndiv_Sheet1.Columns.Get(0).Width = 100F;
			this.sprIndiv_Sheet1.Columns.Get(1).Width = 73F;
			this.sprIndiv_Sheet1.Columns.Get(2).Width = 41F;
			this.sprIndiv_Sheet1.Columns.Get(3).Width = 18F;
			this.sprIndiv_Sheet1.Columns.Get(4).Width = 92F;
			this.sprIndiv_Sheet1.Columns.Get(5).Width = 134F;
			this.sprIndiv_Sheet1.Columns.Get(6).Width = 121F;
			this.sprIndiv_Sheet1.Columns.Get(7).Width = 82F;
			this.sprIndiv_Sheet1.Columns.Get(8).Width = 33F;
			this.sprIndiv_Sheet1.Columns.Get(9).Width = 14F;
			this.sprIndiv_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprIndiv_Sheet1.Rows.Get(6).Height = 17F;
			this.cmdOK = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdOK.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdOK.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "&Approve Transfer";
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
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&Cancel Transfer";
			this.Text = "Individual Transfer Report";
			this.Empid = "";
			this.NewPos = 0;
			this.CurrRow = 0;
			this.LastRow = 0;
			this.OldPos = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234781979957961", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text502636234781979977491", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1266636234781980006786");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1368636234781980055611");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1402636234781980065376");
			namedStyle5.CellType = textCellType2;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType2;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1481636234781980075141");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1750636234781980143496");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Italic);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1823636234781980182556");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1841636234781980231381");
			namedStyle9.CellType = textCellType3;
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType3;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1898636234781980250911");
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1932636234781980270441");
			namedStyle11.CellType = textCellType4;
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType4;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1970636234781980289971");
			namedStyle12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2024636234781980338796");
			namedStyle13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2074636234781980504801");
			namedStyle14.CellType = textCellType5;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType5;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2132636234781980524331");
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2166636234781980553626");
			namedStyle16.CellType = textCellType6;
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.Renderer = textCellType6;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2348636234781980670806");
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2420636234781980719631");
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2454636234781980758691");
			namedStyle19.CellType = textCellType7;
			namedStyle19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType7;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2492636234781980768456");
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2526636234781980817281");
			namedStyle21.CellType = textCellType8;
			namedStyle21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.Renderer = textCellType8;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2560636234781980895401");
			namedStyle22.CellType = textCellType9;
			namedStyle22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType9;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx2625636234781980914931");
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static2677636234781980953991");
			namedStyle24.CellType = textCellType10;
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType10;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static294636234781982936286");
			namedStyle25.CellType = textCellType11;
			namedStyle25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.Renderer = textCellType11;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static472636234781983229236");
			namedStyle26.CellType = textCellType12;
			namedStyle26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F);
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Renderer = textCellType12;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Bottom;
			this.Name = "PTSProject.frmTransferReport";
			this.sprIndiv.NamedStyles.Add(namedStyle1);
			this.sprIndiv.NamedStyles.Add(namedStyle2);
			this.sprIndiv.NamedStyles.Add(namedStyle3);
			this.sprIndiv.NamedStyles.Add(namedStyle4);
			this.sprIndiv.NamedStyles.Add(namedStyle5);
			this.sprIndiv.NamedStyles.Add(namedStyle6);
			this.sprIndiv.NamedStyles.Add(namedStyle7);
			this.sprIndiv.NamedStyles.Add(namedStyle8);
			this.sprIndiv.NamedStyles.Add(namedStyle9);
			this.sprIndiv.NamedStyles.Add(namedStyle10);
			this.sprIndiv.NamedStyles.Add(namedStyle11);
			this.sprIndiv.NamedStyles.Add(namedStyle12);
			this.sprIndiv.NamedStyles.Add(namedStyle13);
			this.sprIndiv.NamedStyles.Add(namedStyle14);
			this.sprIndiv.NamedStyles.Add(namedStyle15);
			this.sprIndiv.NamedStyles.Add(namedStyle16);
			this.sprIndiv.NamedStyles.Add(namedStyle17);
			this.sprIndiv.NamedStyles.Add(namedStyle18);
			this.sprIndiv.NamedStyles.Add(namedStyle19);
			this.sprIndiv.NamedStyles.Add(namedStyle20);
			this.sprIndiv.NamedStyles.Add(namedStyle21);
			this.sprIndiv.NamedStyles.Add(namedStyle22);
			this.sprIndiv.NamedStyles.Add(namedStyle23);
			this.sprIndiv.NamedStyles.Add(namedStyle24);
			this.sprIndiv.NamedStyles.Add(namedStyle25);
			this.sprIndiv.NamedStyles.Add(namedStyle26);
			this.sprIndiv.Sheets.Add(this.sprIndiv_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprIndiv { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprIndiv_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOK { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String Empid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NewPos { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 LastRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OldPos { get; set; }

	}

}