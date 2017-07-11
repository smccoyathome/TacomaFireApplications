using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgCalendarYearShift))]
	public class dlgCalendarYearShiftViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprGrid.MaxRows = 100;
			this.sprGrid.TabIndex = 0;
			this.sprGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Number of Days (Two 12-hr Shifts) Scheduled Per Year";
			this.sprGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprGrid_Sheet1.SheetName = "Sheet1";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Year";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "A Shift";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 2].Value = "B Shift";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 3].Value = "C Shift";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 4].Value = "D Shift";
			this.sprGrid_Sheet1.Columns.Get(0).Label = "Year";
			this.sprGrid_Sheet1.Columns.Get(0).StyleName = "Static630636234645247228685";
			this.sprGrid_Sheet1.Columns.Get(0).Width = 64F;
			this.sprGrid_Sheet1.Columns.Get(1).Label = "A Shift";
			this.sprGrid_Sheet1.Columns.Get(1).StyleName = "Static630636234645247228685";
			this.sprGrid_Sheet1.Columns.Get(2).Label = "B Shift";
			this.sprGrid_Sheet1.Columns.Get(2).StyleName = "Static630636234645247228685";
			this.sprGrid_Sheet1.Columns.Get(3).Label = "C Shift";
			this.sprGrid_Sheet1.Columns.Get(3).StyleName = "Static630636234645247228685";
			this.sprGrid_Sheet1.Columns.Get(4).Label = "D Shift";
			this.sprGrid_Sheet1.Columns.Get(4).StyleName = "Static630636234645247228685";
			this.sprGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 1;
			this.cmdExit.Text = "Close";
			this.Text = "Calendar Year/Shift Counts";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234645247199393", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234645247209157", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static630636234645247228685");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.dlgCalendarYearShift";
			IsMdiChild = true;
			this.sprGrid.NamedStyles.Add(namedStyle1);
			this.sprGrid.NamedStyles.Add(namedStyle2);
			this.sprGrid.NamedStyles.Add(namedStyle3);
			this.sprGrid.Sheets.Add(this.sprGrid_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprGrid { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprGrid_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}