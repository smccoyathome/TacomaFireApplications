using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmStaffingDiscrepancy))]
	public class frmStaffingDiscrepancyViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 10000;
			this.sprReport.TabIndex = 0;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.dtStartDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStartDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.TabIndex = 1;
			this.dtStartDate.Visible = false;
			this.dtEndDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEndDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.TabIndex = 6;
			this.dtEndDate.Visible = false;
			this.sprReport2 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport2.MaxRows = 10000;
			this.sprReport2.TabIndex = 10;
			this.sprReport2.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport2.Visible = false;
			this.lbTotal = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotal
			// 
			this.lbTotal.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotal.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotal.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.TabIndex = 9;
			this.lbTotal.Text = "lbTotal";
			this.lbTotal.Visible = false;
			this.lbEnd = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnd
			// 
			this.lbEnd.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbEnd.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.TabIndex = 8;
			this.lbEnd.Text = "To";
			this.lbEnd.Visible = false;
			this.lbStart = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStart
			// 
			this.lbStart.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbStart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbStart.Name = "lbStart";
			this.lbStart.TabIndex = 7;
			this.lbStart.Text = "From";
			this.lbStart.Visible = false;
			this.sprReport2_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport2_Sheet1.SheetName = "Sheet1";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 1].Value = "Unit";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 2].Value = "Incident #";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 3].Value = "DateTime";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 4].Value = "Staffed In:";
			this.sprReport2_Sheet1.ColumnHeader.Cells[0, 5].Value = "Record ID";
			this.sprReport2_Sheet1.ColumnHeader.Rows.Get(0).Height = 29F;
			this.sprReport2_Sheet1.Columns.Get(0).Label = "Name";
			this.sprReport2_Sheet1.Columns.Get(0).StyleName = "Static638636234771365276016";
			this.sprReport2_Sheet1.Columns.Get(0).Width = 109F;
			this.sprReport2_Sheet1.Columns.Get(1).Label = "Unit";
			this.sprReport2_Sheet1.Columns.Get(1).StyleName = "Static708636234771365285781";
			this.sprReport2_Sheet1.Columns.Get(1).Width = 40F;
			this.sprReport2_Sheet1.Columns.Get(2).Label = "Incident #";
			this.sprReport2_Sheet1.Columns.Get(2).StyleName = "Static708636234771365285781";
			this.sprReport2_Sheet1.Columns.Get(2).Width = 70F;
			this.sprReport2_Sheet1.Columns.Get(3).Label = "DateTime";
			this.sprReport2_Sheet1.Columns.Get(3).StyleName = "Static708636234771365285781";
			this.sprReport2_Sheet1.Columns.Get(3).Width = 90F;
			this.sprReport2_Sheet1.Columns.Get(4).Label = "Staffed In:";
			this.sprReport2_Sheet1.Columns.Get(4).StyleName = "Static708636234771365285781";
			this.sprReport2_Sheet1.Columns.Get(4).Width = 54F;
			this.sprReport2_Sheet1.Columns.Get(5).Label = "Record ID";
			this.sprReport2_Sheet1.Columns.Get(5).StyleName = "Static708636234771365285781";
			this.sprReport2_Sheet1.Columns.Get(5).Visible = false;
			this.sprReport2_Sheet1.Columns.Get(5).Width = 0F;
			this.sprReport2_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport2_Sheet1.Rows.Get(0).Height = 14F;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Unit";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Incident #";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "DateTime";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Staffed In CAD";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Staffed In PTS";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
			this.sprReport_Sheet1.Columns.Get(0).Label = "Unit";
			this.sprReport_Sheet1.Columns.Get(0).StyleName = "Static620636234771264413331";
			this.sprReport_Sheet1.Columns.Get(1).Label = "Incident #";
			this.sprReport_Sheet1.Columns.Get(1).StyleName = "Static620636234771264413331";
			this.sprReport_Sheet1.Columns.Get(1).Width = 68F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "DateTime";
			this.sprReport_Sheet1.Columns.Get(2).StyleName = "Static620636234771264413331";
			this.sprReport_Sheet1.Columns.Get(2).Width = 84F;
			this.sprReport_Sheet1.Columns.Get(3).Label = "Staffed In CAD";
			this.sprReport_Sheet1.Columns.Get(3).Width = 124F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Staffed In PTS";
			this.sprReport_Sheet1.Columns.Get(4).StyleName = "Static620636234771264413331";
			this.sprReport_Sheet1.Columns.Get(4).Width = 124F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1.Rows.Get(0).Height = 14F;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 5;
			this.cmdPrint.Text = "Print";
			this.chkDateFilter = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDateFilter
			// 
			this.chkDateFilter.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkDateFilter.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.4F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDateFilter.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkDateFilter.Name = "chkDateFilter";
			this.chkDateFilter.TabIndex = 4;
			this.chkDateFilter.Text = "Filter By Dates";
			this.cmdExit = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdExit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.TabIndex = 3;
			this.cmdExit.Text = "Close";
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 2;
			this.cmdRefresh.Text = "Refresh";
			this.Text = "PTS -vs- CAD Staffing Discrepancy";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234771264393801", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234771264403566", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static620636234771264413331");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234771365236956", "DataAreaDefault");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234771365256486", "DataAreaDefault");
			namedStyle5.CellType = textCellType3;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static638636234771365276016");
			namedStyle6.CellType = textCellType4;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static708636234771365285781");
			namedStyle7.CellType = textCellType5;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType5;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmStaffingDiscrepancy";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.NamedStyles.Add(namedStyle3);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
			this.sprReport2.NamedStyles.Add(namedStyle4);
			this.sprReport2.NamedStyles.Add(namedStyle5);
			this.sprReport2.NamedStyles.Add(namedStyle6);
			this.sprReport2.NamedStyles.Add(namedStyle7);
			this.sprReport2.Sheets.Add(this.sprReport2_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStartDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEndDate { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotal { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStart { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport2_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDateFilter { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdExit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}