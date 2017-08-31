using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmStaffingReport))]
	public class frmStaffingReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType14 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle31;
			var textCellType13 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle30;
			FarPoint.ViewModels.NamedStyle namedStyle29;
			FarPoint.ViewModels.NamedStyle namedStyle28;
			FarPoint.ViewModels.NamedStyle namedStyle27;
			var textCellType12 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle26;
			FarPoint.ViewModels.NamedStyle namedStyle25;
			var textCellType11 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle24;
			FarPoint.ViewModels.NamedStyle namedStyle23;
			var textCellType10 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle22;
			FarPoint.ViewModels.NamedStyle namedStyle21;
			var textCellType9 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle20;
			var textCellType8 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle19;
			FarPoint.ViewModels.NamedStyle namedStyle18;
			var textCellType7 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle17;
			FarPoint.ViewModels.NamedStyle namedStyle16;
			FarPoint.ViewModels.NamedStyle namedStyle15;
			FarPoint.ViewModels.NamedStyle namedStyle14;
			var textCellType6 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle13;
			FarPoint.ViewModels.NamedStyle namedStyle12;
			FarPoint.ViewModels.NamedStyle namedStyle11;
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle10;
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
			this.sprCSRs = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprCSRs.MaxRows = 50;
			this.sprCSRs.TabIndex = 21;
			this.sprCSRs.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprCSRs.Visible = false;
			this.sprDetail = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprDetail.MaxRows = 100;
			this.sprDetail.TabIndex = 0;
			this.sprDetail.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReportGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReportGrid.MaxRows = 32;
			this.sprReportGrid.TabIndex = 18;
			this.sprReportGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtTotal = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTotal.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTotal.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotal.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.TabIndex = 9;
			this.txtTotal.Text = "txtTotal";
			this.cboMonth = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMonth
			// 
			this.cboMonth.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMonth.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMonth.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboMonth.Name = "cboMonth";
			this.cboMonth.TabIndex = 4;
			this.cboYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboYear
			// 
			this.cboYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboYear.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboYear.Name = "cboYear";
			this.cboYear.TabIndex = 3;
			this.optCSRs = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optCSRs
			// 
			this.optCSRs.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optCSRs.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.optCSRs.Name = "optCSRs";
			this.optCSRs.TabIndex = 20;
			this.optCSRs.Text = "Display Available CSRs";
			this.optCallback = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optCallback
			// 
			this.optCallback.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optCallback.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.optCallback.Name = "optCallback";
			this.optCallback.TabIndex = 14;
			this.optCallback.Text = "Display Qualified Callback Staff";
			this.optWorking = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optWorking
			// 
			this.optWorking.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optWorking.Checked = true;
			this.optWorking.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.optWorking.Name = "optWorking";
			this.optWorking.TabIndex = 13;
			this.optWorking.Text = "Display Working Staff";
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.MaxRows = 40;
			this.sprReport.TabIndex = 8;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport.Visible = false;
			this.sprCallBackDetail = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprCallBackDetail.MaxRows = 200;
			this.sprCallBackDetail.TabIndex = 17;
			this.sprCallBackDetail.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprCallBackDetail.Visible = false;
			this.lbListNote = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbListNote
			// 
			this.lbListNote.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbListNote.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbListNote.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.lbListNote.Name = "lbListNote";
			this.lbListNote.TabIndex = 19;
			this.lbListNote.Text = "Note:  List does not include those already Scheduled  OR on Leave";
			this.lbListNote.Visible = false;
			this.lbDetailDisplayed = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDetailDisplayed
			// 
			this.lbDetailDisplayed.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbDetailDisplayed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbDetailDisplayed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbDetailDisplayed.Name = "lbDetailDisplayed";
			this.lbDetailDisplayed.TabIndex = 16;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "^^^^^  Click On cell amount to display daily detail below... ^^^^^";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Change Target Staffing Total, then Click button to rerun Report";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Report Month";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Report Year";
			this.sprCallBackDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCallBackDetail_Sheet1.SheetName = "Sheet1";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 0].Value = "Callback #";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 1].Value = "Employee";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 2].Value = "SE";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 3].Value = "Phone #";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 4].Value = "Debit Group";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 5].Value = "Assignment Type";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Cells[0, 6].Value = "Comments";
			this.sprCallBackDetail_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
			this.sprCallBackDetail_Sheet1.Columns.Get(0).Label = "Callback #";
			this.sprCallBackDetail_Sheet1.Columns.Get(0).Width = 64F;
			this.sprCallBackDetail_Sheet1.Columns.Get(1).Label = "Employee";
			this.sprCallBackDetail_Sheet1.Columns.Get(1).Width = 130F;
			this.sprCallBackDetail_Sheet1.Columns.Get(2).Label = "SE";
			this.sprCallBackDetail_Sheet1.Columns.Get(2).Width = 19F;
			this.sprCallBackDetail_Sheet1.Columns.Get(3).Label = "Phone #";
			//this.sprCallBackDetail_Sheet1.Columns.Get(3).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprCallBackDetail_Sheet1.Columns.Get(3).Width = 85F;
			this.sprCallBackDetail_Sheet1.Columns.Get(4).Label = "Debit Group";
			this.sprCallBackDetail_Sheet1.Columns.Get(4).Width = 50F;
			this.sprCallBackDetail_Sheet1.Columns.Get(5).Label = "Assignment Type";
			this.sprCallBackDetail_Sheet1.Columns.Get(5).Width = 65F;
			this.sprCallBackDetail_Sheet1.Columns.Get(6).Label = "Comments";
			this.sprCallBackDetail_Sheet1.Columns.Get(6).Width = 222F;
			this.sprCallBackDetail_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprCallBackDetail_Sheet1.Rows.Get(0).Height = 26F;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
            //ColumnSpan is OBSOLETE
            //this.sprReport_Sheet1.Cells.Get(0, 0).ColumnSpan = 7;
			this.sprReport_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			//this.sprReport_Sheet1.Cells.Get(0, 7).ColumnSpan = 7;
			//this.sprReport_Sheet1.Cells.Get(1, 0).ColumnSpan = 14;
			this.sprReport_Sheet1.Cells.Get(1, 0).Value = "Daily Staffing To Determine Callback Needs";
			//this.sprReport_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 2).Value = "Scheduled BCs";
			this.sprReport_Sheet1.Cells.Get(2, 3).Value = "Scheduled PMs";
			//this.sprReport_Sheet1.Cells.Get(2, 4).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 4).Value = "Scheduled SAFLT";
			//this.sprReport_Sheet1.Cells.Get(2, 6).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 6).Value = "Fireboat Qualified";
			this.sprReport_Sheet1.Cells.Get(2, 7).Value = "Scheduled ISOs";
			//this.sprReport_Sheet1.Cells.Get(2, 8).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 8).Value = "Scheduled Officers";
			this.sprReport_Sheet1.Cells.Get(2, 9).Value = "Incharge Dispatcher";
			//this.sprReport_Sheet1.Cells.Get(2, 10).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 10).Value = "Scheduled PMs";
			//this.sprReport_Sheet1.Cells.Get(2, 12).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 12).Value = "Incharge Dispatcher";
			//this.sprReport_Sheet1.Cells.Get(2, 14).ColumnSpan = 2;
			this.sprReport_Sheet1.Cells.Get(2, 14).Value = "Total Sched Staff";
			this.sprReport_Sheet1.Cells.Get(2, 15).Value = "Total Staff";
			this.sprReport_Sheet1.Cells.Get(3, 0).Value = "Date";
			this.sprReport_Sheet1.Cells.Get(3, 1).Value = "Shift";
			this.sprReport_Sheet1.Cells.Get(3, 2).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 3).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 4).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 5).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 6).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 7).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 8).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 9).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 10).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 11).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 12).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 13).Value = "PM";
			this.sprReport_Sheet1.Cells.Get(3, 14).Value = "AM";
			this.sprReport_Sheet1.Cells.Get(3, 15).Value = "PM";
			this.sprReport_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprReport_Sheet1.Columns.Get(0).Width = 75F;
			this.sprReport_Sheet1.Columns.Get(1).Width = 35F;
			this.sprReport_Sheet1.Columns.Get(2).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(3).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(4).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(5).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(6).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(7).Width = 48F;
			this.sprReport_Sheet1.Columns.Get(8).Width = 52F;
			this.sprReport_Sheet1.Columns.Get(9).Width = 52F;
			this.sprReport_Sheet1.Columns.Get(10).Width = 50F;
			this.sprReport_Sheet1.Columns.Get(11).Width = 50F;
			this.sprReport_Sheet1.Columns.Get(14).Width = 50F;
			this.sprReport_Sheet1.Columns.Get(15).Width = 50F;
			this.sprReport_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReportGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReportGrid_Sheet1.SheetName = "Sheet1";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Date";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shft";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 2].Value = "BC Sched AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 3].Value = "BC Sched PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 4].Value = "SAF03 Sched AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 5].Value = "SAF03 Sched PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 6].Value = "Fire Boat AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 7].Value = "Fire Boat PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 8].Value = "Officer Sched AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 9].Value = "Officer Sched PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 10].Value = "PM Sched AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 11].Value = "PM Sched PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 12].Value = "Disp Inchg AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 13].Value = "Disp Inchg PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 14].Value = "Total Staff AM";
			this.sprReportGrid_Sheet1.ColumnHeader.Cells[0, 15].Value = "Total Staff PM";
			this.sprReportGrid_Sheet1.ColumnHeader.Rows.Get(0).Height = 55F;
			this.sprReportGrid_Sheet1.Columns.Get(0).Label = "Date";
			this.sprReportGrid_Sheet1.Columns.Get(0).Width = 62F;
			this.sprReportGrid_Sheet1.Columns.Get(1).Label = "Shft";
			this.sprReportGrid_Sheet1.Columns.Get(1).Width = 33F;
			this.sprReportGrid_Sheet1.Columns.Get(2).Label = "BC Sched AM";
			this.sprReportGrid_Sheet1.Columns.Get(2).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(3).Label = "BC Sched PM";
			this.sprReportGrid_Sheet1.Columns.Get(3).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(4).Label = "SAF03 Sched AM";
			this.sprReportGrid_Sheet1.Columns.Get(4).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(5).Label = "SAF03 Sched PM";
			this.sprReportGrid_Sheet1.Columns.Get(5).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(6).Label = "Fire Boat AM";
			this.sprReportGrid_Sheet1.Columns.Get(6).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(7).Label = "Fire Boat PM";
			this.sprReportGrid_Sheet1.Columns.Get(7).Width = 48F;
			this.sprReportGrid_Sheet1.Columns.Get(8).Label = "Officer Sched AM";
			this.sprReportGrid_Sheet1.Columns.Get(8).Width = 52F;
			this.sprReportGrid_Sheet1.Columns.Get(9).Label = "Officer Sched PM";
			this.sprReportGrid_Sheet1.Columns.Get(9).Width = 52F;
			this.sprReportGrid_Sheet1.Columns.Get(10).Label = "PM Sched AM";
			this.sprReportGrid_Sheet1.Columns.Get(10).Width = 50F;
			this.sprReportGrid_Sheet1.Columns.Get(11).Label = "PM Sched PM";
			this.sprReportGrid_Sheet1.Columns.Get(11).Width = 50F;
			this.sprReportGrid_Sheet1.Columns.Get(12).Label = "Disp Inchg AM";
			this.sprReportGrid_Sheet1.Columns.Get(12).Width = 50F;
			this.sprReportGrid_Sheet1.Columns.Get(13).Label = "Disp Inchg PM";
			this.sprReportGrid_Sheet1.Columns.Get(13).Width = 50F;
			this.sprReportGrid_Sheet1.Columns.Get(14).Label = "Total Staff AM";
			this.sprReportGrid_Sheet1.Columns.Get(14).Width = 47F;
			this.sprReportGrid_Sheet1.Columns.Get(15).Label = "Total Staff PM";
			this.sprReportGrid_Sheet1.Columns.Get(15).Width = 44F;
			this.sprReportGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDetail_Sheet1.SheetName = "Sheet1";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 0].Value = "Shift Date";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 1].Value = "Unit-Pos";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 2].Value = "Employee";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 3].Value = "Record Created by";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 4].Value = "Created On";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 5].Value = "Time Code";
			this.sprDetail_Sheet1.ColumnHeader.Rows.Get(0).Height = 31F;
			this.sprDetail_Sheet1.Columns.Get(0).Label = "Shift Date";
			this.sprDetail_Sheet1.Columns.Get(0).Width = 79F;
			this.sprDetail_Sheet1.Columns.Get(1).Label = "Unit-Pos";
			this.sprDetail_Sheet1.Columns.Get(1).Width = 66F;
			this.sprDetail_Sheet1.Columns.Get(2).Label = "Employee";
			this.sprDetail_Sheet1.Columns.Get(2).Width = 150F;
			this.sprDetail_Sheet1.Columns.Get(3).Label = "Record Created by";
			this.sprDetail_Sheet1.Columns.Get(3).Width = 155F;
			this.sprDetail_Sheet1.Columns.Get(4).Label = "Created On";
			this.sprDetail_Sheet1.Columns.Get(4).Width = 101F;
			this.sprDetail_Sheet1.Columns.Get(5).Label = "Time Code";
			//this.sprDetail_Sheet1.Columns.Get(5).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprDetail_Sheet1.Columns.Get(5).StyleName = "Static892636234772310557311";
			this.sprDetail_Sheet1.Columns.Get(5).Width = 64F;
			this.sprDetail_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprDetail_Sheet1.Rows.Get(0).Height = 14F;
			this.sprCSRs_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprCSRs_Sheet1.SheetName = "Sheet1";
			this.sprCSRs_Sheet1.ColumnHeader.Cells[0, 0].Value = "Name";
			this.sprCSRs_Sheet1.ColumnHeader.Cells[0, 1].Value = "Type";
			this.sprCSRs_Sheet1.ColumnHeader.Cells[0, 2].Value = "Position";
			this.sprCSRs_Sheet1.ColumnHeader.Cells[0, 3].Value = "Last Worked On";
			this.sprCSRs_Sheet1.ColumnHeader.Cells[0, 4].Value = "Works Next On";
			this.sprCSRs_Sheet1.Columns.Get(0).Label = "Name";
			this.sprCSRs_Sheet1.Columns.Get(0).Width = 178F;
			this.sprCSRs_Sheet1.Columns.Get(2).Label = "Position";
			this.sprCSRs_Sheet1.Columns.Get(2).Width = 70F;
			this.sprCSRs_Sheet1.Columns.Get(3).Label = "Last Worked On";
			this.sprCSRs_Sheet1.Columns.Get(3).Width = 111F;
			this.sprCSRs_Sheet1.Columns.Get(4).Label = "Works Next On";
			this.sprCSRs_Sheet1.Columns.Get(4).Width = 110F;
			this.sprCSRs_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprCSRs_Sheet1.Rows.Get(0).Height = 14F;
			this.cmdPrintDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrintDetail
			// 
			this.cmdPrintDetail.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrintDetail.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrintDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrintDetail.Name = "cmdPrintDetail";
			this.cmdPrintDetail.TabIndex = 15;
			this.cmdPrintDetail.Text = "&Print Detail";
			this.cmdRunReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRunReport
			// 
			this.cmdRunReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRunReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRunReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRunReport.Name = "cmdRunReport";
			this.cmdRunReport.TabIndex = 11;
			this.cmdRunReport.Text = "Run Report";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "&Close";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 1;
			this.cmdPrint.Text = "&Print";
			this.Text = "TFD Daily Staffing - Determine Callback Status";
			this.MinStaff = 0;
			this.OTMonth = 0;
			this.OTYear = 0;
			this.FirstTime = false;
			this.selCol = 0;
			this.selRow = 0;
			this.sShift = "";
			this.sDate = "";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234772208063871", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text257636234772208063871", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 8F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234772310498721", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text337636234772310518251", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static892636234772310557311");
			namedStyle5.CellType = textCellType3;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234771949867506", "DataAreaDefault");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text291636234771949877271", "DataAreaDefault");
			namedStyle7.CellType = textCellType4;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Parent = "DataAreaDefault";
			namedStyle7.Renderer = textCellType4;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1922636234771949945626");
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle9 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234773135172501", "DataAreaDefault");
			namedStyle9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle9.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle9.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle9.Parent = "DataAreaDefault";
			namedStyle9.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle10 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text409636234773135182266", "DataAreaDefault");
			namedStyle10.CellType = textCellType5;
			namedStyle10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle10.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle10.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle10.Parent = "DataAreaDefault";
			namedStyle10.Renderer = textCellType5;
			namedStyle10.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle11 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1754636234773135250621");
			namedStyle11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle11.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle11.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle11.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle12 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1821636234773135250621");
			namedStyle12.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle12.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle12.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle13 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1839636234773135260386");
			namedStyle13.CellType = textCellType6;
			namedStyle13.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle13.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle13.Renderer = textCellType6;
			namedStyle13.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle14 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font3020636234773135416626");
			namedStyle14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle14.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle14.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle14.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle15 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3069636234773135416626");
			namedStyle15.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle15.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle15.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle16 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3145636234773135426391");
			namedStyle16.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle16.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle16.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle17 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3163636234773135436156");
			namedStyle17.CellType = textCellType7;
			namedStyle17.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle17.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle17.Renderer = textCellType7;
			namedStyle17.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle18 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx3229636234773135436156");
			namedStyle18.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle18.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle18.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle19 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static3247636234773135445921");
			namedStyle19.CellType = textCellType8;
			namedStyle19.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle19.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle19.Renderer = textCellType8;
			namedStyle19.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle20 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static88636234773135582631");
			namedStyle20.CellType = textCellType9;
			namedStyle20.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle20.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle20.Renderer = textCellType9;
			namedStyle20.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle21 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx179636234773135602161");
			namedStyle21.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle21.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle21.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle22 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static197636234773135602161");
			namedStyle22.CellType = textCellType10;
			namedStyle22.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle22.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle22.Renderer = textCellType10;
			namedStyle22.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle23 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx330636234773135621691");
			namedStyle23.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle23.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle23.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle24 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static348636234773135631456");
			namedStyle24.CellType = textCellType11;
			namedStyle24.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle24.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle24.Renderer = textCellType11;
			namedStyle24.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle25 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx403636234773135641221");
			namedStyle25.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle25.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle25.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle26 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static421636234773135641221");
			namedStyle26.CellType = textCellType12;
			namedStyle26.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle26.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle26.Renderer = textCellType12;
			namedStyle26.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			namedStyle27 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1330636234773135963466");
			namedStyle27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F);
			namedStyle27.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle27.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle27.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle28 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx1379636234773135963466");
			namedStyle28.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle28.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle28.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle29 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("BorderEx58636234772402231131", "DataAreaDefault");
			namedStyle29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle29.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle29.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle29.Parent = "DataAreaDefault";
			namedStyle29.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle30 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static347636234772402260426", "DataAreaDefault");
			namedStyle30.CellType = textCellType13;
			namedStyle30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle30.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle30.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle30.Parent = "DataAreaDefault";
			namedStyle30.Renderer = textCellType13;
			namedStyle30.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle31 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1219636234772402289721");
			namedStyle31.CellType = textCellType14;
			namedStyle31.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle31.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle31.Renderer = textCellType14;
			namedStyle31.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmStaffingReport";
			IsMdiChild = true;
            cboMonth.Items.Add("January");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 1);
            cboMonth.Items.Add("February");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 2);
            cboMonth.Items.Add("March");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 3);
            cboMonth.Items.Add("April");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 4);
            cboMonth.Items.Add("May");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 5);
            cboMonth.Items.Add("June");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 6);
            cboMonth.Items.Add("July");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 7);
            cboMonth.Items.Add("August");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 8);
            cboMonth.Items.Add("September");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 9);
            cboMonth.Items.Add("October");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 10);
            cboMonth.Items.Add("November");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 11);
            cboMonth.Items.Add("December");
            cboMonth.SetItemData(cboMonth.GetNewIndex(), 12);
            cboYear.Items.Add("1998");
			cboYear.Items.Add("1999");
			cboYear.Items.Add("2000");
			cboYear.Items.Add("2001");
			cboYear.Items.Add("2002");
			cboYear.Items.Add("2003");
			cboYear.Items.Add("2004");
			cboYear.Items.Add("2005");
			this.sprCSRs.NamedStyles.Add(namedStyle1);
			this.sprCSRs.NamedStyles.Add(namedStyle2);
			this.sprCSRs.Sheets.Add(this.sprCSRs_Sheet1);
			this.sprDetail.NamedStyles.Add(namedStyle3);
			this.sprDetail.NamedStyles.Add(namedStyle4);
			this.sprDetail.NamedStyles.Add(namedStyle5);
			this.sprDetail.Sheets.Add(this.sprDetail_Sheet1);
			this.sprReportGrid.NamedStyles.Add(namedStyle6);
			this.sprReportGrid.NamedStyles.Add(namedStyle7);
			this.sprReportGrid.NamedStyles.Add(namedStyle8);
			this.sprReportGrid.Sheets.Add(this.sprReportGrid_Sheet1);
			this.sprReport.NamedStyles.Add(namedStyle9);
			this.sprReport.NamedStyles.Add(namedStyle10);
			this.sprReport.NamedStyles.Add(namedStyle11);
			this.sprReport.NamedStyles.Add(namedStyle12);
			this.sprReport.NamedStyles.Add(namedStyle13);
			this.sprReport.NamedStyles.Add(namedStyle14);
			this.sprReport.NamedStyles.Add(namedStyle15);
			this.sprReport.NamedStyles.Add(namedStyle16);
			this.sprReport.NamedStyles.Add(namedStyle17);
			this.sprReport.NamedStyles.Add(namedStyle18);
			this.sprReport.NamedStyles.Add(namedStyle19);
			this.sprReport.NamedStyles.Add(namedStyle20);
			this.sprReport.NamedStyles.Add(namedStyle21);
			this.sprReport.NamedStyles.Add(namedStyle22);
			this.sprReport.NamedStyles.Add(namedStyle23);
			this.sprReport.NamedStyles.Add(namedStyle24);
			this.sprReport.NamedStyles.Add(namedStyle25);
			this.sprReport.NamedStyles.Add(namedStyle26);
			this.sprReport.NamedStyles.Add(namedStyle27);
			this.sprReport.NamedStyles.Add(namedStyle28);
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
			this.sprCallBackDetail.NamedStyles.Add(namedStyle29);
			this.sprCallBackDetail.NamedStyles.Add(namedStyle30);
			this.sprCallBackDetail.NamedStyles.Add(namedStyle31);
			this.sprCallBackDetail.Sheets.Add(this.sprCallBackDetail_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprCSRs { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprDetail { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReportGrid { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTotal { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMonth { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optCSRs { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optCallback { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optWorking { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprCallBackDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbListNote { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDetailDisplayed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCallBackDetail_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReportGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDetail_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprCSRs_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrintDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRunReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MinStaff { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OTMonth { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 OTYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 selCol { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 selRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sShift { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String sDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}