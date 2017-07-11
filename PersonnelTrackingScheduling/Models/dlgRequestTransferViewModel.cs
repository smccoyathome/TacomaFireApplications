using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgRequestTransfer))]
	public class dlgRequestTransferViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.optDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optDelete
			// 
			this.optDelete.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optDelete.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optDelete.Name = "optDelete";
			this.optDelete.TabIndex = 2;
			this.optDelete.Text = "Delete Request";
			this.optRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optRequest
			// 
			this.optRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.optRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optRequest.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optRequest.Name = "optRequest";
			this.optRequest.TabIndex = 1;
			this.optRequest.Text = "Request Transfer";
			this.sprPositions = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPositions.TabIndex = 22;
			this.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this._Label_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprRequests = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRequests.TabIndex = 19;
			this.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 7;
			this.cboNameList.Text = "cboNameList";
			this.cboPriority = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPriority
			// 
			this.cboPriority.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPriority.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPriority.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPriority.Name = "cboPriority";
			this.cboPriority.TabIndex = 5;
			this.cboPriority.Text = "cboPriority";
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 4;
			this.lbPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPosition
			// 
			this.lbPosition.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbPosition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbPosition.Name = "lbPosition";
			this.lbPosition.TabIndex = 12;
			this.lbPosition.Text = "No Position Selected";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 10;
			this.Label5.Text = "Select Priority Ranking";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 9;
			this.lblName.Text = "Select Name";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 8;
			this.Label3.Text = "Add Comment (optional)";
			this.cboDelNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDelNameList
			// 
			this.cboDelNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboDelNameList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboDelNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboDelNameList.Name = "cboDelNameList";
			this.cboDelNameList.TabIndex = 15;
			this.cboDelNameList.Text = "cboDelNameList";
			this.lbRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRequest
			// 
			this.lbRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRequest.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbRequest.Name = "lbRequest";
			this.lbRequest.TabIndex = 20;
			this.lbRequest.Text = "No Request Selected";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 18;
			this.Label6.Text = "Select Name";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 17;
			this.Label1.Text = "lbEmployeeID";
			this.Label1.Visible = false;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Select Transfer Request for Deletion";
			this.sprRequests_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRequests_Sheet1.SheetName = "Sheet1";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 0].Value = "Choice #";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 1].Value = "Position";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 2].Value = "Created On";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 3].Value = "ID";
			this.sprRequests_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
			this.sprRequests_Sheet1.Columns.Get(0).Label = "Choice #";
			this.sprRequests_Sheet1.Columns.Get(0).Width = 72F;
			this.sprRequests_Sheet1.Columns.Get(1).Label = "Position";
            //SortIndicator is OBSOLETE
            //this.sprRequests_Sheet1.Columns.Get(1).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
            this.sprRequests_Sheet1.Columns.Get(1).Width = 114F;
			this.sprRequests_Sheet1.Columns.Get(2).Label = "Created On";
			this.sprRequests_Sheet1.Columns.Get(2).Width = 125F;
			this.sprRequests_Sheet1.Columns.Get(3).Label = "ID";
			this.sprRequests_Sheet1.Columns.Get(3).Visible = false;
			this.sprRequests_Sheet1.Columns.Get(3).Width = 0F;
			this.sprRequests_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPositions_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPositions_Sheet1.SheetName = "Sheet1";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 0].Value = "Unit";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shift";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 2].Value = "Position";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 3].Value = "Date Posted";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 4].Value = "Date Closing";
			this.sprPositions_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprPositions_Sheet1.Columns.Get(0).Label = "Unit";
			this.sprPositions_Sheet1.Columns.Get(0).Width = 35F;
			this.sprPositions_Sheet1.Columns.Get(1).Label = "Shift";
			this.sprPositions_Sheet1.Columns.Get(1).Width = 33F;
			this.sprPositions_Sheet1.Columns.Get(2).Label = "Position";
			this.sprPositions_Sheet1.Columns.Get(2).Width = 97F;
			this.sprPositions_Sheet1.Columns.Get(3).Label = "Date Posted";
			this.sprPositions_Sheet1.Columns.Get(3).Width = 72F;
			this.sprPositions_Sheet1.Columns.Get(4).Label = "Date Closing";
            //SortIndicator is OBSOLETE
            //this.sprPositions_Sheet1.Columns.Get(4).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
            this.sprPositions_Sheet1.Columns.Get(4).Width = 81F;
			this.sprPositions_Sheet1.Columns.Get(5).Label = "ID";
			this.sprPositions_Sheet1.Columns.Get(5).Visible = false;
			this.sprPositions_Sheet1.Columns.Get(5).Width = 0F;
			this.sprPositions_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 13;
			this.CancelButton_Renamed.Text = "Close";
			this.cmdReqDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReqDone
			// 
			this.cmdReqDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReqDone.Enabled = false;
			this.cmdReqDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReqDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReqDone.Name = "cmdReqDone";
			this.cmdReqDone.TabIndex = 6;
			this.cmdReqDone.Text = "Add Request";
			this.cmdDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDelete
			// 
			this.cmdDelete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDelete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 16;
			this.cmdDelete.Text = "Delete Request";
			this.Text = "Request Transfer";
			this.CurrPosition = 0;
			this.CurrEmployee = "";
			this.CurrRequest = 0;
			this.CurrPosRow = 0;
			this.CurrReqRow = 0;
			this.frmRequestTransfer = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmRequestTransfer
			// 
			this.frmRequestTransfer.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmRequestTransfer.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmRequestTransfer.Name = "frmRequestTransfer";
			this.frmRequestTransfer.TabIndex = 3;
			this.frmRequestTransfer.Visible = false;
			this.frmDeleteRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmDeleteRequest
			// 
			this.frmDeleteRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.frmDeleteRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmDeleteRequest.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmDeleteRequest.Name = "frmDeleteRequest";
			this.frmDeleteRequest.TabIndex = 14;
			this.frmDeleteRequest.Visible = false;
			Label = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label[1] = _Label_1;
			Label[0] = _Label_0;
			Label[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			Label[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[1].ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			Label[1].Name = "_Label_1";
			Label[1].TabIndex = 24;
			Label[1].Text = "Note:  Postings end 1200 on Closing Date";
			Label[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			Label[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			Label[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			Label[0].Name = "_Label_0";
			Label[0].TabIndex = 23;
			Label[0].Text = "* = Paramedic Position";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234657736610421", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text325636234657736620186", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234657840080361", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static299636234657840090126", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.dlgRequestTransfer";
			this.sprPositions.NamedStyles.Add(namedStyle1);
			this.sprPositions.NamedStyles.Add(namedStyle2);
			this.sprPositions.Sheets.Add(this.sprPositions_Sheet1);
			this.sprRequests.NamedStyles.Add(namedStyle3);
			this.sprRequests.NamedStyles.Add(namedStyle4);
			this.sprRequests.Sheets.Add(this.sprRequests_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optRequest { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPositions { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label_0 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRequests { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPriority { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDelNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRequests_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPositions_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReqDone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDelete { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPosition { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmployee { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRequest { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrPosRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReqRow { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmRequestTransfer { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmDeleteRequest { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label { get; set; }

	}

}