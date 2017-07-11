using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmMissingFromSchedule))]
	public class frmMissingFromScheduleViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprMissing = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprMissing.TabIndex = 3;
			this.sprMissing.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 1;
			this.Label1.Text = "To Assign employee to Schedule, select name and click Add to Scheduler...";
			this.sprMissing_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprMissing_Sheet1.SheetName = "Sheet1";
			this.sprMissing_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprMissing_Sheet1.Columns.Get(0).Width = 160F;
			this.sprMissing_Sheet1.Columns.Get(1).Visible = false;
			this.sprMissing_Sheet1.Columns.Get(1).Width = 0F;
			this.sprMissing_Sheet1.Columns.Get(2).Visible = false;
			this.sprMissing_Sheet1.Columns.Get(2).Width = 0F;
			this.sprMissing_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "Add to Scheduler";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 0;
			this.CancelButton_Renamed.Text = "Done";
			this.Text = "Missing From the Schedule?";
			this.JobCode = "";
			this.Empid = "";
			this.Step = 0;
			this.AMShiftStart = "";
			this.AssignID = 0;
			this.TimeCode = "";
			this.PayUp = 0;
			this.PMShiftStart = "";
			this.SelectedRow = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234735927983601", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text333636234735928003131", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmMissingFromSchedule";
			this.sprMissing.NamedStyles.Add(namedStyle1);
			this.sprMissing.NamedStyles.Add(namedStyle2);
			this.sprMissing.Sheets.Add(this.sprMissing_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprMissing { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprMissing_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String JobCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String Empid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 Step { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String AMShiftStart { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 AssignID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String TimeCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PayUp { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String PMShiftStart { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}