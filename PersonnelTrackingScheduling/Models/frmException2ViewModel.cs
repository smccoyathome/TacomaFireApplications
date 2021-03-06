using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmException2))]
	public class frmException2ViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
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
			this.sprExcept = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprExcept.TabIndex = 4;
			this.sprExcept.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.calDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calDate.Name = "calDate";
			this.calDate.TabIndex = 0;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Select  Date";
			this.sprExcept_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprExcept_Sheet1.SheetName = "Sheet1";
			this.sprExcept_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprExcept_Sheet1.Cells.Get(1, 0).Value = "Battalion 2 Time Card Exception Report";
			this.sprExcept_Sheet1.Cells.Get(3, 0).Value = "Employee";
			this.sprExcept_Sheet1.Cells.Get(3, 1).Value = "KOT/Worked";
			this.sprExcept_Sheet1.Cells.Get(3, 2).Value = "KOT/Leave";
			this.sprExcept_Sheet1.Cells.Get(3, 3).Value = "Pay Up";
			this.sprExcept_Sheet1.Cells.Get(3, 4).Value = "Job Code";
			this.sprExcept_Sheet1.Cells.Get(3, 5).Value = "Step";
			this.sprExcept_Sheet1.Cells.Get(3, 6).Value = "Shifts";
			this.sprExcept_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprExcept_Sheet1.Columns.Get(0).Width = 196F;
			this.sprExcept_Sheet1.Columns.Get(1).Width = 93F;
			this.sprExcept_Sheet1.Columns.Get(2).Width = 104F;
			this.sprExcept_Sheet1.Columns.Get(3).Width = 52F;
			this.sprExcept_Sheet1.Columns.Get(4).Width = 67F;
			this.sprExcept_Sheet1.Columns.Get(5).Width = 34F;
			this.sprExcept_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
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
			this.Text = "Battalion 2 Time Card Exception Report";
			this.FirstTime = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234707016352221", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text418636234707016381516", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font120636234707016430341");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static138636234707016449871");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static193636234707016469401");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font831636234707016908826");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static849636234707016918591");
			namedStyle7.CellType = textCellType4;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1330636234707017348251");
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1364636234707017397076");
			namedStyle9.CellType = textCellType5;
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1402636234707017416606");
			namedStyle10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1602636234707017631436");
			namedStyle11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle11.CellType = textCellType6;
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.Renderer = textCellType6;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1640636234707017641201");
			namedStyle12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1734636234707017787676");
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1086636234707035989636");
			namedStyle14.CellType = textCellType7;
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.Renderer = textCellType7;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1389636234707036223996");
			namedStyle15.CellType = textCellType8;
			namedStyle15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.Renderer = textCellType8;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1555636234707043889521");
			namedStyle16.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1611636234707043938346");
			namedStyle17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			namedStyle17.CellType = textCellType9;
			namedStyle17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType9;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmException2";
			IsMdiChild = true;
			this.sprExcept.NamedStyles.Add(namedStyle1);
			this.sprExcept.NamedStyles.Add(namedStyle2);
			this.sprExcept.NamedStyles.Add(namedStyle3);
			this.sprExcept.NamedStyles.Add(namedStyle4);
			this.sprExcept.NamedStyles.Add(namedStyle5);
			this.sprExcept.NamedStyles.Add(namedStyle6);
			this.sprExcept.NamedStyles.Add(namedStyle7);
			this.sprExcept.NamedStyles.Add(namedStyle8);
			this.sprExcept.NamedStyles.Add(namedStyle9);
			this.sprExcept.NamedStyles.Add(namedStyle10);
			this.sprExcept.NamedStyles.Add(namedStyle11);
			this.sprExcept.NamedStyles.Add(namedStyle12);
			this.sprExcept.NamedStyles.Add(namedStyle13);
			this.sprExcept.NamedStyles.Add(namedStyle14);
			this.sprExcept.NamedStyles.Add(namedStyle15);
			this.sprExcept.NamedStyles.Add(namedStyle16);
			this.sprExcept.NamedStyles.Add(namedStyle17);
			this.sprExcept.Sheets.Add(this.sprExcept_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprExcept { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprExcept_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}