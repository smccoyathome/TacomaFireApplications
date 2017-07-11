using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmTransferRequest))]
	public class frmTransferRequestViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
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
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 2;
			this.Label14.Text = "Blue Backgroud = Inactive Position";
			this.optNewPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optNewPosition
			// 
			this.optNewPosition.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optNewPosition.Checked = true;
			this.optNewPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optNewPosition.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optNewPosition.Name = "optNewPosition";
			this.optNewPosition.TabIndex = 41;
			this.optNewPosition.Text = "Post New Position";
			this.optRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optRequest
			// 
			this.optRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optRequest.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optRequest.Name = "optRequest";
			this.optRequest.TabIndex = 40;
			this.optRequest.Text = "Request Transfer";
			this.cboReqPositionList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReqPositionList
			// 
			this.cboReqPositionList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboReqPositionList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboReqPositionList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReqPositionList.Name = "cboReqPositionList";
			this.cboReqPositionList.TabIndex = 9;
			this.cboReqPositionList.Text = "cboReqPositionList";
			this.cboReqNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReqNameList
			// 
			this.cboReqNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboReqNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboReqNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReqNameList.Name = "cboReqNameList";
			this.cboReqNameList.TabIndex = 4;
			this.cboReqNameList.Text = "cboReqNameList";
			this.sprRequests = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRequests.MaxRows = 1000;
			this.sprRequests.TabIndex = 7;
			this.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprPositions = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPositions.MaxRows = 1000;
			this.sprPositions.TabIndex = 12;
			this.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboShiftList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboShiftList
			// 
			this.cboShiftList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboShiftList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboShiftList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboShiftList.Name = "cboShiftList";
			this.cboShiftList.TabIndex = 19;
			this.cboShiftList.Text = "cboShiftList";
			this.cboPositionList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPositionList
			// 
			this.cboPositionList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPositionList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPositionList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPositionList.Name = "cboPositionList";
			this.cboPositionList.TabIndex = 18;
			this.cboPositionList.Text = "cboPositionList";
			this.cboUnitList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUnitList
			// 
			this.cboUnitList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboUnitList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboUnitList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUnitList.Name = "cboUnitList";
			this.cboUnitList.TabIndex = 17;
			this.cboUnitList.Text = "cboUnitList";
			this.dteOpenDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteOpenDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteOpenDate.Name = "dteOpenDate";
			this.dteOpenDate.TabIndex = 15;
			this.dteCloseDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dteCloseDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.dteCloseDate.Name = "dteCloseDate";
			this.dteCloseDate.TabIndex = 20;
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 25;
			this.Label6.Text = " Position";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 24;
			this.Label7.Text = "Unit";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 23;
			this.Label8.Text = "Shift";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 22;
			this.Label9.Text = "Post Date";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 21;
			this.Label10.Text = "Close Date";
			this.lstAvailPositions = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstAvailPositions
			// 
			this.lstAvailPositions.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstAvailPositions.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstAvailPositions.Name = "lstAvailPositions";
			this.lstAvailPositions.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstAvailPositions.TabIndex = 31;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 30;
			this.cboNameList.Text = "cboNameList";
			this.cboPriority = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPriority
			// 
			this.cboPriority.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPriority.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPriority.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPriority.Name = "cboPriority";
			this.cboPriority.TabIndex = 28;
			this.cboPriority.Text = "cboPriority";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 27;
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 35;
			this.Label5.Text = "Select Priority Ranking";
			this.lblDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblDate
			// 
			this.lblDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lblDate.Name = "lblDate";
			this.lblDate.TabIndex = 34;
			this.lblDate.Text = "Select Desired Positon";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 33;
			this.lblName.Text = "Select Name";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 32;
			this.Label3.Text = "Add Comment (optional)";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Filter by Position:";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Posted Positions";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Filter by Name:";
			this.sprPositions_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPositions_Sheet1.SheetName = "Sheet1";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 0].Value = "Position";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date Posted";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 2].Value = "Date Closing";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 3].Value = "# Of Requests";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 4].Value = "Date Created";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprPositions_Sheet1.ColumnHeader.Rows.Get(0).Height = 27F;
			this.sprPositions_Sheet1.Columns.Get(0).Label = "Position";
            //SortIndicator is OBSOLETE
            //this.sprPositions_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprPositions_Sheet1.Columns.Get(0).Width = 136F;
			this.sprPositions_Sheet1.Columns.Get(1).Label = "Date Posted";
			this.sprPositions_Sheet1.Columns.Get(1).Width = 84F;
			this.sprPositions_Sheet1.Columns.Get(2).Label = "Date Closing";
			this.sprPositions_Sheet1.Columns.Get(2).Width = 83F;
			this.sprPositions_Sheet1.Columns.Get(3).Label = "# Of Requests";
			this.sprPositions_Sheet1.Columns.Get(3).Width = 57F;
			this.sprPositions_Sheet1.Columns.Get(4).Label = "Date Created";
			this.sprPositions_Sheet1.Columns.Get(4).Width = 104F;
			this.sprPositions_Sheet1.Columns.Get(5).Label = "ID";
			this.sprPositions_Sheet1.Columns.Get(5).Visible = false;
			this.sprPositions_Sheet1.Columns.Get(5).Width = 0F;
			this.sprPositions_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPositions_Sheet1.Rows.Get(0).Height = 14F;
			this.sprRequests_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRequests_Sheet1.SheetName = "Sheet1";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee Name";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 1].Value = "Choice #";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 2].Value = "Position Requested";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 3].Value = "Rank";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 4].Value = "Last Appt Date";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 5].Value = "Current Position";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 6].Value = "ID";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 7].Value = "EmpID";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 8].Value = "Assign Changes This Year";
			this.sprRequests_Sheet1.ColumnHeader.Rows.Get(0).Height = 47F;
			this.sprRequests_Sheet1.Columns.Get(0).Label = "Employee Name";
			this.sprRequests_Sheet1.Columns.Get(0).Width = 115F;
			this.sprRequests_Sheet1.Columns.Get(1).Label = "Choice #";
			//this.sprRequests_Sheet1.Columns.Get(1).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprRequests_Sheet1.Columns.Get(1).Width = 46F;
			this.sprRequests_Sheet1.Columns.Get(2).Label = "Position Requested";
			this.sprRequests_Sheet1.Columns.Get(2).Width = 69F;
			this.sprRequests_Sheet1.Columns.Get(3).Label = "Rank";
			this.sprRequests_Sheet1.Columns.Get(3).Width = 35F;
			this.sprRequests_Sheet1.Columns.Get(4).Label = "Last Appt Date";
			this.sprRequests_Sheet1.Columns.Get(4).Width = 74F;
			this.sprRequests_Sheet1.Columns.Get(5).Label = "Current Position";
			this.sprRequests_Sheet1.Columns.Get(5).Width = 61F;
			this.sprRequests_Sheet1.Columns.Get(6).Label = "ID";
			this.sprRequests_Sheet1.Columns.Get(6).Visible = false;
			this.sprRequests_Sheet1.Columns.Get(6).Width = 0F;
			this.sprRequests_Sheet1.Columns.Get(7).Label = "EmpID";
			this.sprRequests_Sheet1.Columns.Get(7).Visible = false;
			this.sprRequests_Sheet1.Columns.Get(7).Width = 0F;
			this.sprRequests_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprRequests_Sheet1.Rows.Get(0).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(1).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(2).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(3).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(4).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(5).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(6).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(7).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(8).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(9).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(10).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(11).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(12).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(13).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(14).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(15).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(16).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(17).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(18).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(19).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(20).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(21).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(22).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(23).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(24).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(25).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(26).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(27).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(28).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(29).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(30).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(31).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(32).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(33).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(34).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(35).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(36).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(37).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(38).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(39).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(40).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(41).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(42).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(43).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(44).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(45).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(46).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(47).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(48).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(49).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(50).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(51).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(52).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(53).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(54).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(55).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(56).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(57).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(58).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(59).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(60).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(61).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(62).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(63).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(64).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(65).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(66).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(67).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(68).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(69).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(70).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(71).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(72).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(73).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(74).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(75).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(76).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(77).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(78).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(79).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(80).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(81).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(82).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(83).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(84).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(85).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(86).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(87).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(88).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(89).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(90).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(91).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(92).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(93).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(94).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(95).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(96).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(97).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(98).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(99).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(100).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(101).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(102).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(103).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(104).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(105).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(106).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(107).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(108).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(109).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(110).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(111).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(112).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(113).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(114).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(115).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(116).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(117).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(118).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(119).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(120).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(121).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(122).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(123).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(124).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(125).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(126).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(127).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(128).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(129).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(130).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(131).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(132).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(133).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(134).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(135).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(136).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(137).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(138).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(139).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(140).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(141).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(142).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(143).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(144).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(145).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(146).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(147).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(148).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(149).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(150).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(151).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(152).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(153).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(154).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(155).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(156).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(157).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(158).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(159).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(160).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(161).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(162).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(163).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(164).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(165).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(166).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(167).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(168).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(169).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(170).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(171).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(172).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(173).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(174).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(175).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(176).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(177).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(178).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(179).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(180).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(181).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(182).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(183).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(184).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(185).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(186).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(187).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(188).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(189).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(190).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(191).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(192).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(193).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(194).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(195).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(196).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(197).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(198).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(199).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(200).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(201).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(202).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(203).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(204).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(205).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(206).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(207).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(208).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(209).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(210).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(211).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(212).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(213).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(214).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(215).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(216).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(217).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(218).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(219).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(220).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(221).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(222).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(223).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(224).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(225).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(226).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(227).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(228).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(229).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(230).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(231).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(232).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(233).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(234).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(235).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(236).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(237).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(238).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(239).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(240).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(241).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(242).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(243).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(244).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(245).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(246).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(247).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(248).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(249).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(250).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(251).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(252).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(253).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(254).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(255).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(256).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(257).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(258).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(259).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(260).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(261).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(262).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(263).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(264).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(265).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(266).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(267).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(268).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(269).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(270).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(271).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(272).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(273).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(274).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(275).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(276).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(277).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(278).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(279).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(280).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(281).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(282).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(283).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(284).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(285).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(286).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(287).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(288).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(289).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(290).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(291).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(292).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(293).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(294).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(295).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(296).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(297).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(298).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(299).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(300).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(301).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(302).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(303).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(304).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(305).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(306).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(307).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(308).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(309).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(310).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(311).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(312).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(313).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(314).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(315).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(316).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(317).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(318).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(319).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(320).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(321).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(322).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(323).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(324).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(325).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(326).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(327).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(328).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(329).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(330).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(331).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(332).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(333).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(334).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(335).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(336).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(337).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(338).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(339).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(340).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(341).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(342).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(343).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(344).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(345).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(346).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(347).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(348).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(349).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(350).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(351).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(352).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(353).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(354).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(355).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(356).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(357).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(358).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(359).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(360).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(361).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(362).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(363).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(364).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(365).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(366).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(367).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(368).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(369).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(370).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(371).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(372).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(373).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(374).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(375).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(376).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(377).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(378).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(379).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(380).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(381).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(382).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(383).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(384).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(385).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(386).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(387).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(388).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(389).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(390).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(391).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(392).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(393).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(394).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(395).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(396).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(397).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(398).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(399).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(400).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(401).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(402).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(403).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(404).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(405).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(406).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(407).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(408).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(409).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(410).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(411).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(412).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(413).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(414).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(415).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(416).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(417).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(418).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(419).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(420).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(421).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(422).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(423).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(424).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(425).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(426).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(427).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(428).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(429).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(430).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(431).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(432).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(433).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(434).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(435).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(436).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(437).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(438).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(439).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(440).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(441).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(442).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(443).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(444).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(445).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(446).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(447).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(448).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(449).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(450).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(451).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(452).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(453).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(454).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(455).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(456).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(457).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(458).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(459).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(460).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(461).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(462).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(463).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(464).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(465).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(466).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(467).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(468).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(469).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(470).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(471).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(472).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(473).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(474).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(475).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(476).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(477).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(478).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(479).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(480).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(481).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(482).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(483).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(484).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(485).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(486).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(487).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(488).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(489).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(490).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(491).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(492).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(493).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(494).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(495).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(496).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(497).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(498).Height = 13F;
			this.sprRequests_Sheet1.Rows.Get(499).Height = 13F;
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 0;
			this.CancelButton_Renamed.Text = "Exit";
			this.cmdDisplay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDisplay
			// 
			this.cmdDisplay.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDisplay.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDisplay.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDisplay.Name = "cmdDisplay";
			this.cmdDisplay.TabIndex = 42;
			this.cmdDisplay.Text = "Display List of Assign Changes This Year";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 37;
			this.cmdPrint.Text = "Print List";
			this.cmdInactivate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdInactivate
			// 
			this.cmdInactivate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdInactivate.Enabled = false;
			this.cmdInactivate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdInactivate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdInactivate.Name = "cmdInactivate";
			this.cmdInactivate.TabIndex = 36;
			this.cmdInactivate.Text = "Inactivate Record";
			this.chkActiveOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkActiveOnly
			// 
			this.chkActiveOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkActiveOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkActiveOnly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.
					Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkActiveOnly.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.chkActiveOnly.Name = "chkActiveOnly";
			this.chkActiveOnly.TabIndex = 13;
			this.chkActiveOnly.Text = "Display Open Only";
			this.cmdAssign = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAssign
			// 
			this.cmdAssign.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAssign.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAssign.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAssign.Name = "cmdAssign";
			this.cmdAssign.TabIndex = 11;
			this.cmdAssign.Text = "Assign Selected Employee";
			this.cmdClearRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearRequest
			// 
			this.cmdClearRequest.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearRequest.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearRequest.Name = "cmdClearRequest";
			this.cmdClearRequest.TabIndex = 5;
			this.cmdClearRequest.Text = "Clear Filter / Refresh Grid";
			this.cmdAddPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddPosition
			// 
			this.cmdAddPosition.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddPosition.Enabled = false;
			this.cmdAddPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddPosition.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddPosition.Name = "cmdAddPosition";
			this.cmdAddPosition.TabIndex = 16;
			this.cmdAddPosition.Text = "Add Position";
			this.cmdReqDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReqDone
			// 
			this.cmdReqDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReqDone.Enabled = false;
			this.cmdReqDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReqDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReqDone.Name = "cmdReqDone";
			this.cmdReqDone.TabIndex = 29;
			this.cmdReqDone.Text = "Add Request";
			this.Text = "Transfer Postings / Requests";
			this.NoRefresh = false;
			this.FilterEmployee = "";
			this.CurrEmployee = "";
			this.chkPMOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPMOnly
			// 
			this.chkPMOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkPMOnly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPMOnly.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.chkPMOnly.Name = "chkPMOnly";
			this.chkPMOnly.TabIndex = 38;
			this.chkPMOnly.Text = "Paramedic";
			this.CurrPosition = 0;
			this.frmRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmRequest
			// 
			this.frmRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmRequest.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmRequest.Name = "frmRequest";
			this.frmRequest.TabIndex = 26;
			this.frmRequest.Visible = false;
			this.frmAddPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmAddPosition
			// 
			this.frmAddPosition.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmAddPosition.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmAddPosition.Name = "frmAddPosition";
			this.frmAddPosition.TabIndex = 14;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234782427624621", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static299636234782427624621", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1354636234782427663681");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234782507443731", "DataAreaDefault");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static299636234782507453496", "DataAreaDefault");
			namedStyle5.CellType = textCellType3;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1129636234782507492556");
			namedStyle6.CellType = textCellType4;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			this.Name = "PTSProject.frmTransferRequest";
			IsMdiChild = true;
			this.sprRequests.NamedStyles.Add(namedStyle1);
			this.sprRequests.NamedStyles.Add(namedStyle2);
			this.sprRequests.NamedStyles.Add(namedStyle3);
			this.sprRequests.Sheets.Add(this.sprRequests_Sheet1);
			this.sprPositions.NamedStyles.Add(namedStyle4);
			this.sprPositions.NamedStyles.Add(namedStyle5);
			this.sprPositions.NamedStyles.Add(namedStyle6);
			this.sprPositions.Sheets.Add(this.sprPositions_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optNewPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReqPositionList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReqNameList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRequests { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPositions { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboShiftList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPositionList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUnitList { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteOpenDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dteCloseDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstAvailPositions { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPriority { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPositions_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRequests_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDisplay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdInactivate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkActiveOnly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAssign { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReqDone { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean NoRefresh { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String FilterEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPMOnly { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmAddPosition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}