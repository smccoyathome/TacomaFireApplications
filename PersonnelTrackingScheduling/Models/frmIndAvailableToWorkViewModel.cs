using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmIndAvailableToWork))]
	public class frmIndAvailableToWorkViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprAvailable = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprAvailable.TabIndex = 10;
			this.sprAvailable.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 4;
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Add Comment (optional)";
			this.sprAvailable_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAvailable_Sheet1.SheetName = "Sheet1";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 0].Value = "Date Shift";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 1].Value = "Created On";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 2].Value = "Comment";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 3].Value = "ID";
			this.sprAvailable_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
			this.sprAvailable_Sheet1.Columns.Get(0).Label = "Date Shift";
			//this.sprAvailable_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprAvailable_Sheet1.Columns.Get(0).Width = 100F;
			this.sprAvailable_Sheet1.Columns.Get(1).Label = "Created On";
			this.sprAvailable_Sheet1.Columns.Get(1).Width = 114F;
			this.sprAvailable_Sheet1.Columns.Get(2).Label = "Comment";
			this.sprAvailable_Sheet1.Columns.Get(2).Width = 215F;
			this.sprAvailable_Sheet1.Columns.Get(3).Label = "ID";
			this.sprAvailable_Sheet1.Columns.Get(3).Visible = false;
			this.sprAvailable_Sheet1.Columns.Get(3).Width = 0F;
			this.sprAvailable_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 9;
			this.cmdDelete.Text = "Delete Available Date Record";
			this.cmdAdd = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAdd
			// 
			this.cmdAdd.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAdd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAdd.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 7;
			this.cmdAdd.Text = "Add Date Available Record";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 6;
			this.CancelButton_Renamed.Text = "Exit";
			this.calAvail = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			// 
			// calAvail
			// 
			this.calAvail.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calAvail.Name = "calAvail";
			this.calAvail.TabIndex = 1;
			this.Text = "Dates Available To Work";
			this.CurrEmployee = "";
			this.CurrRow = 0;
			this.SelectedDate = "";
			this.chkAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkAM
			// 
			this.chkAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkAM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkAM.Name = "chkAM";
			this.chkAM.TabIndex = 2;
			this.chkAM.Text = "AM";
			this.chkPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPM
			// 
			this.chkPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkPM.Name = "chkPM";
			this.chkPM.TabIndex = 3;
			this.chkPM.Text = "PM";
			this.CurrRecordID = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234722347695171", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static299636234722347704936", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.frmIndAvailableToWork";
			IsMdiChild = true;
			this.sprAvailable.NamedStyles.Add(namedStyle1);
			this.sprAvailable.NamedStyles.Add(namedStyle2);
			this.sprAvailable.Sheets.Add(this.sprAvailable_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAvailable_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAdd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calAvail { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRecordID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}