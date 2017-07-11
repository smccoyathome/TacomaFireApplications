using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmRankedOperationStaff))]
	public class frmRankedOperationStaffViewModel
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
			this.cboGroup = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboGroup
			// 
			this.cboGroup.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGroup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGroup.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.TabIndex = 2;
			this.cboGroup.Text = "cboGroup";
			this.lbCount = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCount
			// 
			this.lbCount.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCount.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbCount.Name = "lbCount";
			this.lbCount.TabIndex = 5;
			this.lbCount.Text = "List Count:  ";
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.TabIndex = 6;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Rank";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Emp Number";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Name";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Batt";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Unit";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 5].Value = "Shift";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 6].Value = "Position";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 7].Value = "Group";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 37F;
			this.sprReport_Sheet1.Columns.Get(0).Label = "Rank";
			//this.sprReport_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprReport_Sheet1.Columns.Get(0).Width = 65F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Emp Number";
			this.sprReport_Sheet1.Columns.Get(1).Width = 79F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Name";
			this.sprReport_Sheet1.Columns.Get(2).Width = 174F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Unit";
			this.sprReport_Sheet1.Columns.Get(4).Width = 45F;
			this.sprReport_Sheet1.Columns.Get(5).Label = "Shift";
			this.sprReport_Sheet1.Columns.Get(5).Width = 47F;
			this.sprReport_Sheet1.Columns.Get(6).Label = "Position";
			this.sprReport_Sheet1.Columns.Get(6).Width = 73F;
			this.sprReport_Sheet1.Columns.Get(7).Label = "Group";
			this.sprReport_Sheet1.Columns.Get(7).Width = 54F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 4;
			this.cmdPrint.Text = "Print List";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 3;
			this.cmdExit.Text = "Exit";
			this.chkSelectAll = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkSelectAll
			// 
			this.chkSelectAll.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkSelectAll.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkSelectAll.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkSelectAll.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.TabIndex = 1;
			this.chkSelectAll.Text = " Or Select All (Clear Group Filter";
			this.Text = "Ranked Operation Staff List";
			this.CurrRow = 0;
			this.sGroup = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234762952601571", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234762952621101", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1140636234762952679691");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmRankedOperationStaff";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGroup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCount { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSelectAll { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sGroup { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}