using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmInsteadOfSCKLeave))]
	public class frmInsteadOfSCKLeaveViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.TabIndex = 0;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtStart.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 3;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dtEnd.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 4;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 6;
			this.Label4.Text = "Thru:";
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 1].Value = "Batt";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 2].Value = "Unit";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 3].Value = "Shift";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 4].Value = "Position";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 5].Value = "Debit Group";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 6].Value = "Shift Date/Time";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 7].Value = "Leave KOT";
			this.sprReport_Sheet1.ColumnHeader.Cells[0, 8].Value = "EmpID";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 27F;
			this.sprReport_Sheet1.Columns.Get(0).Label = "Name";
			this.sprReport_Sheet1.Columns.Get(0).Width = 133F;
			this.sprReport_Sheet1.Columns.Get(1).Label = "Batt";
			this.sprReport_Sheet1.Columns.Get(1).Width = 40F;
			this.sprReport_Sheet1.Columns.Get(2).Label = "Unit";
			//this.sprReport_Sheet1.Columns.Get(2).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprReport_Sheet1.Columns.Get(2).Width = 36F;
			this.sprReport_Sheet1.Columns.Get(3).Label = "Shift";
			this.sprReport_Sheet1.Columns.Get(3).Width = 43F;
			this.sprReport_Sheet1.Columns.Get(4).Label = "Position";
			this.sprReport_Sheet1.Columns.Get(4).Width = 54F;
			this.sprReport_Sheet1.Columns.Get(5).Label = "Debit Group";
			this.sprReport_Sheet1.Columns.Get(5).Width = 43F;
			this.sprReport_Sheet1.Columns.Get(6).Label = "Shift Date/Time";
			this.sprReport_Sheet1.Columns.Get(6).Width = 111F;
			this.sprReport_Sheet1.Columns.Get(7).Label = "Leave KOT";
			this.sprReport_Sheet1.Columns.Get(7).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(8).Label = "EmpID";
			this.sprReport_Sheet1.Columns.Get(8).Visible = false;
			this.sprReport_Sheet1.Columns.Get(8).Width = 0F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 1;
			this.cmdPrint.Text = "Print Report";
			this.Text = "Employees Using the \"Instead Of Sick Leave\" Flag";
			this.FirstTime = false;
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(1);
			Label3[0] = _Label3_0;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 5;
			Label3[0].Text = "From:";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234729006815256", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234729006834786", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmInsteadOfSCKLeave";
			IsMdiChild = true;
			this.sprReport.NamedStyles.Add(namedStyle1);
			this.sprReport.NamedStyles.Add(namedStyle2);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}