using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgTimeCodes))]
	public class dlgTimeCodesViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle9;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprJobCode = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprJobCode.MaxRows = 200;
			this.sprJobCode.TabIndex = 7;
			this.sprJobCode.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.optLeaveAllowed = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optLeaveAllowed
			// 
			this.optLeaveAllowed.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optLeaveAllowed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optLeaveAllowed.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optLeaveAllowed.Name = "optLeaveAllowed";
			this.optLeaveAllowed.TabIndex = 8;
			this.optLeaveAllowed.Text = "Leave Allowed";
			this.optJobCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optJobCode
			// 
			this.optJobCode.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optJobCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optJobCode.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optJobCode.Name = "optJobCode";
			this.optJobCode.TabIndex = 6;
			this.optJobCode.Text = "PS Groups(Job Code)";
			this.optOrderCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optOrderCode
			// 
			this.optOrderCode.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optOrderCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optOrderCode.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optOrderCode.Name = "optOrderCode";
			this.optOrderCode.TabIndex = 4;
			this.optOrderCode.Text = "Work Order Codes";
			this.optTimeCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optTimeCode
			// 
			this.optTimeCode.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optTimeCode.Checked = true;
			this.optTimeCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optTimeCode.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optTimeCode.Name = "optTimeCode";
			this.optTimeCode.TabIndex = 3;
			this.optTimeCode.Text = "KOT/ A A Type Codes";
			this.sprTimeCode = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprTimeCode.TabIndex = 1;
			this.sprTimeCode.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprOrderCode = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprOrderCode.TabIndex = 5;
			this.sprOrderCode.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprLeaveAllowed = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprLeaveAllowed.MaxRows = 27;
			this.sprLeaveAllowed.TabIndex = 9;
			this.sprLeaveAllowed.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprLeaveAllowed_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprLeaveAllowed_Sheet1.SheetName = "Sheet1";
			this.sprLeaveAllowed_Sheet1.ColumnHeader.Cells[0, 0].Value = "Years Of Service";
			this.sprLeaveAllowed_Sheet1.ColumnHeader.Cells[0, 1].Value = "Leave Allowed (12-hr Shifts)";
			this.sprLeaveAllowed_Sheet1.Columns.Get(0).Label = "Years Of Service";
			this.sprLeaveAllowed_Sheet1.Columns.Get(0).StyleName = "Static637636234663136587066";
			this.sprLeaveAllowed_Sheet1.Columns.Get(0).Width = 136F;
			this.sprLeaveAllowed_Sheet1.Columns.Get(1).Label = "Leave Allowed (12-hr Shifts)";
			this.sprLeaveAllowed_Sheet1.Columns.Get(1).StyleName = "Static637636234663136587066";
			this.sprLeaveAllowed_Sheet1.Columns.Get(1).Width = 235F;
			this.sprLeaveAllowed_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprOrderCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprOrderCode_Sheet1.SheetName = "Sheet1";
			this.sprOrderCode_Sheet1.ColumnHeader.Cells[0, 0].Value = "Order Number";
			this.sprOrderCode_Sheet1.ColumnHeader.Cells[0, 1].Value = "Description";
			this.sprOrderCode_Sheet1.ColumnHeader.Cells[0, 2].Value = "SysID";
			this.sprOrderCode_Sheet1.Columns.Get(0).Label = "Order Number";
			this.sprOrderCode_Sheet1.Columns.Get(0).Width = 118F;
			this.sprOrderCode_Sheet1.Columns.Get(1).Label = "Description";
			this.sprOrderCode_Sheet1.Columns.Get(1).Width = 271F;
			this.sprOrderCode_Sheet1.Columns.Get(2).Label = "SysID";
			this.sprOrderCode_Sheet1.Columns.Get(2).Visible = false;
			this.sprOrderCode_Sheet1.Columns.Get(2).Width = 0F;
			this.sprOrderCode_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprTimeCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprTimeCode_Sheet1.SheetName = "Sheet1";
			this.sprTimeCode_Sheet1.ColumnHeader.Cells[0, 0].Value = "KOT";
			this.sprTimeCode_Sheet1.ColumnHeader.Cells[0, 1].Value = "A/A Type";
			this.sprTimeCode_Sheet1.ColumnHeader.Cells[0, 2].Value = "Civ A/A";
			this.sprTimeCode_Sheet1.ColumnHeader.Cells[0, 3].Value = "Description";
			this.sprTimeCode_Sheet1.ColumnHeader.Cells[0, 4].Value = "SysID";
			this.sprTimeCode_Sheet1.Columns.Get(0).Label = "KOT";
			this.sprTimeCode_Sheet1.Columns.Get(0).Width = 64F;
			this.sprTimeCode_Sheet1.Columns.Get(2).Label = "Civ A/A";
            //SortIndicator is OBSOLETE
            //this.sprTimeCode_Sheet1.Columns.Get(2).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprTimeCode_Sheet1.Columns.Get(3).Label = "Description";
			this.sprTimeCode_Sheet1.Columns.Get(3).Width = 194F;
			this.sprTimeCode_Sheet1.Columns.Get(4).Label = "SysID";
			this.sprTimeCode_Sheet1.Columns.Get(4).Visible = false;
			this.sprTimeCode_Sheet1.Columns.Get(4).Width = 0F;
			this.sprTimeCode_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprTimeCode_Sheet1.Rows.Get(0).Height = 14F;
			this.sprJobCode_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprJobCode_Sheet1.SheetName = "Sheet1";
			this.sprJobCode_Sheet1.ColumnHeader.Cells[0, 0].Value = "PS Group";
			this.sprJobCode_Sheet1.ColumnHeader.Cells[0, 1].Value = "Description";
			this.sprJobCode_Sheet1.Columns.Get(0).Label = "PS Group";
			this.sprJobCode_Sheet1.Columns.Get(0).Width = 76F;
			this.sprJobCode_Sheet1.Columns.Get(1).Label = "Description";
            //SortIndicator is OBSOLETE
            //this.sprJobCode_Sheet1.Columns.Get(1).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
            this.sprJobCode_Sheet1.Columns.Get(1).Width = 313F;
			this.sprJobCode_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprJobCode_Sheet1.Rows.Get(0).Height = 14F;
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 0;
			this.CancelButton_Renamed.Text = "Exit";
			this.Text = "Payroll Time Card Codes";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234662228979141", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234662228988906", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234662725060671", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234662725070436", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234662833217811", "DataAreaDefault");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234662833247106", "DataAreaDefault");
			namedStyle6.CellType = textCellType3;
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.Renderer = textCellType3;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234663136567536", "DataAreaDefault");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Parent = "DataAreaDefault";
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text298636234663136577301", "DataAreaDefault");
			namedStyle8.CellType = textCellType4;
			namedStyle8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Parent = "DataAreaDefault";
			namedStyle8.Renderer = textCellType4;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static637636234663136587066");
			namedStyle9.CellType = textCellType5;
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Renderer = textCellType5;
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.dlgTimeCodes";
			IsMdiChild = true;
			this.sprJobCode.NamedStyles.Add(namedStyle1);
			this.sprJobCode.NamedStyles.Add(namedStyle2);
			this.sprJobCode.Sheets.Add(this.sprJobCode_Sheet1);
			this.sprTimeCode.NamedStyles.Add(namedStyle3);
			this.sprTimeCode.NamedStyles.Add(namedStyle4);
			this.sprTimeCode.Sheets.Add(this.sprTimeCode_Sheet1);
			this.sprOrderCode.NamedStyles.Add(namedStyle5);
			this.sprOrderCode.NamedStyles.Add(namedStyle6);
			this.sprOrderCode.Sheets.Add(this.sprOrderCode_Sheet1);
			this.sprLeaveAllowed.NamedStyles.Add(namedStyle7);
			this.sprLeaveAllowed.NamedStyles.Add(namedStyle8);
			this.sprLeaveAllowed.NamedStyles.Add(namedStyle9);
			this.sprLeaveAllowed.Sheets.Add(this.sprLeaveAllowed_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optLeaveAllowed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optJobCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optOrderCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optTimeCode { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprTimeCode { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprOrderCode { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprLeaveAllowed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprLeaveAllowed_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprOrderCode_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprTimeCode_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprJobCode_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}