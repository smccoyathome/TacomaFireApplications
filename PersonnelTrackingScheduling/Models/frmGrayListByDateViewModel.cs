using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmGrayListByDate))]
	public class frmGrayListByDateViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprEmployeeGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprEmployeeGrid.MaxRows = 20;
			this.sprEmployeeGrid.TabIndex = 0;
			this.sprEmployeeGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprEmployeeGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprEmployeeGrid_Sheet1.SheetName = "Sheet1";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "Batt";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 2].Value = "Unit";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 3].Value = "Position";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 4].Value = "EmpID";
			this.sprEmployeeGrid_Sheet1.ColumnHeader.Cells[0, 5].Value = "PerSysID";
			this.sprEmployeeGrid_Sheet1.Columns.Get(0).Label = "Name";
			this.sprEmployeeGrid_Sheet1.Columns.Get(0).Width = 168F;
			this.sprEmployeeGrid_Sheet1.Columns.Get(1).Label = "Batt";
			this.sprEmployeeGrid_Sheet1.Columns.Get(1).StyleName = "Static695636234713941123851";
			this.sprEmployeeGrid_Sheet1.Columns.Get(2).Label = "Unit";
			this.sprEmployeeGrid_Sheet1.Columns.Get(2).StyleName = "Static695636234713941123851";
			this.sprEmployeeGrid_Sheet1.Columns.Get(2).Width = 58F;
			this.sprEmployeeGrid_Sheet1.Columns.Get(3).Label = "Position";
			this.sprEmployeeGrid_Sheet1.Columns.Get(3).StyleName = "Static695636234713941123851";
			this.sprEmployeeGrid_Sheet1.Columns.Get(4).Label = "EmpID";
			this.sprEmployeeGrid_Sheet1.Columns.Get(4).StyleName = "Static695636234713941123851";
			this.sprEmployeeGrid_Sheet1.Columns.Get(4).Visible = false;
			this.sprEmployeeGrid_Sheet1.Columns.Get(4).Width = 0F;
			this.sprEmployeeGrid_Sheet1.Columns.Get(5).Label = "PerSysID";
			this.sprEmployeeGrid_Sheet1.Columns.Get(5).StyleName = "Static695636234713941123851";
			this.sprEmployeeGrid_Sheet1.Columns.Get(5).Visible = false;
			this.sprEmployeeGrid_Sheet1.Columns.Get(5).Width = 0F;
			this.sprEmployeeGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprEmployeeGrid_Sheet1.Rows.Get(0).Height = 19F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.Text = "Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "Exit";
			this.Text = "Sick Leave Grayed For";
			this.sShiftDate = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234713941094556", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text333636234713941114086", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static695636234713941123851");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1150636234713941319151");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmGrayListByDate";
			IsMdiChild = true;
			this.sprEmployeeGrid.NamedStyles.Add(namedStyle1);
			this.sprEmployeeGrid.NamedStyles.Add(namedStyle2);
			this.sprEmployeeGrid.NamedStyles.Add(namedStyle3);
			this.sprEmployeeGrid.NamedStyles.Add(namedStyle4);
			this.sprEmployeeGrid.Sheets.Add(this.sprEmployeeGrid_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprEmployeeGrid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprEmployeeGrid_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sShiftDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}