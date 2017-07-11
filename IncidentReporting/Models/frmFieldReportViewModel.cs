using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmFieldReport))]
	public class frmFieldReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprQuery = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprQuery.MaxRows = 1011;
			this.sprQuery.TabIndex = 2;
			this.sprQuery.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprQuery_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprQuery_Sheet1.SheetName = "Sheet1";
			this.sprQuery_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprQuery_Sheet1.Cells.Get(1, 0).Value = "Incident Reporting System";
			this.sprQuery_Sheet1.Cells.Get(2, 0).Value = "Field Reports";
			this.sprQuery_Sheet1.Cells.Get(3, 0).Value = "Print Date:";
			this.sprQuery_Sheet1.Cells.Get(4, 0).Value = "Report:";
			this.sprQuery_Sheet1.Cells.Get(5, 0).Value = "Selection Details:";
			this.sprQuery_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprQuery_Sheet1.Columns.Get(0).Width = 213F;
			this.sprQuery_Sheet1.Columns.Get(1).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(1).Width = 138F;
			this.sprQuery_Sheet1.Columns.Get(2).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(2).Width = 155F;
			this.sprQuery_Sheet1.Columns.Get(3).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(3).Width = 150F;
			this.sprQuery_Sheet1.Columns.Get(4).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(4).Width = 65F;
			this.sprQuery_Sheet1.Columns.Get(5).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(6).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(7).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.Columns.Get(8).StyleName = "Font793636234560040782481";
			this.sprQuery_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprQuery_Sheet1.Rows.Get(0).Height = 23F;
			this.sprQuery_Sheet1.Rows.Get(1).Height = 23F;
			this.sprQuery_Sheet1.Rows.Get(2).Height = 21F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 0;
			this.cmdPrint.Text = "&Print";
			this.Text = "TFD Incident Reporting System - Field Report ";
			this.PrintOry = UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationDefault();
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234560040733656", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text445636234560040762951", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font793636234560040782481");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font323636234560040860601");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font545636234560040928956");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "TFDIncident.frmFieldReport";
			IsMdiChild = true;
			this.sprQuery.NamedStyles.Add(namedStyle1);
			this.sprQuery.NamedStyles.Add(namedStyle2);
			this.sprQuery.NamedStyles.Add(namedStyle3);
			this.sprQuery.NamedStyles.Add(namedStyle4);
			this.sprQuery.NamedStyles.Add(namedStyle5);
			this.sprQuery.Sheets.Add(this.sprQuery_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprQuery { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprQuery_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeStubs.FPSpread_PrintOrientationConstantsEnum PrintOry { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}