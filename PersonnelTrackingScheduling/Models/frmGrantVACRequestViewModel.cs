using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmGrantVACRequest))]
	public class frmGrantVACRequestViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var buttonCellType1 = ctx.Resolve<FarPoint.ViewModels.ButtonCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtUpdateComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtUpdateComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtUpdateComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtUpdateComment.Name = "txtUpdateComment";
			this.txtUpdateComment.TabIndex = 15;
			this.txtUpdateComment.Text = "txtUpdateComment";
			this.cboKOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboKOT
			// 
			this.cboKOT.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboKOT.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboKOT.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboKOT.Name = "cboKOT";
			this.cboKOT.TabIndex = 11;
			this.cboKOT.Text = "cboKOT";
			this.cboUpdateNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUpdateNameList
			// 
			this.cboUpdateNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUpdateNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUpdateNameList.Name = "cboUpdateNameList";
			this.cboUpdateNameList.TabIndex = 10;
			this.cboUpdateNameList.Text = "cboUpdateNameList";
			this.calRequestDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calRequestDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calRequestDate.MaxDate = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calRequestDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calRequestDate.Name = "calRequestDate";
			this.calRequestDate.TabIndex = 16;
			this.calRequestDate.Value = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calGiveUpDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calGiveUpDate.MaxDate = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calGiveUpDate.Name = "calGiveUpDate";
			this.calGiveUpDate.TabIndex = 17;
			this.calGiveUpDate.Value = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate.Visible = false;
			this.lbRequestAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRequestAM
			// 
			this.lbRequestAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRequestAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRequestAM.Name = "lbRequestAM";
			this.lbRequestAM.TabIndex = 26;
			this.lbRequestAM.Text = "lbRequestAM";
			this.lbRequestAM.Visible = false;
			this.lbAvailAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailAM
			// 
			this.lbAvailAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAvailAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAvailAM.Name = "lbAvailAM";
			this.lbAvailAM.TabIndex = 25;
			this.lbAvailAM.Text = "lbAvailAM";
			this.lbAvailAM.Visible = false;
			this.lbRequestPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRequestPM
			// 
			this.lbRequestPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRequestPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRequestPM.Name = "lbRequestPM";
			this.lbRequestPM.TabIndex = 24;
			this.lbRequestPM.Text = "lbRequestPM";
			this.lbRequestPM.Visible = false;
			this.lbAvailPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailPM
			// 
			this.lbAvailPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAvailPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAvailPM.Name = "lbAvailPM";
			this.lbAvailPM.TabIndex = 23;
			this.lbAvailPM.Text = "lbAvailPM";
			this.lbAvailPM.Visible = false;
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 22;
			this.Label8.Text = "Comment";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 21;
			this.Label9.Text = "Employee Name";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 20;
			this.Label10.Text = "Leave Date";
			this.lbgiveup = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbgiveup
			// 
			this.lbgiveup.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbgiveup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbgiveup.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lbgiveup.Name = "lbgiveup";
			this.lbgiveup.TabIndex = 19;
			this.lbgiveup.Text = "Give Up Date";
			this.lbgiveup.Visible = false;
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 18;
			this.Label12.Text = "Leave KOT";
			this.cboReqNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReqNameList
			// 
			this.cboReqNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboReqNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReqNameList.Name = "cboReqNameList";
			this.cboReqNameList.TabIndex = 2;
			this.cboReqNameList.Text = "cboReqNameList";
			this.sprRequests = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRequests.TabIndex = 3;
			this.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 6;
			this.Label19.Text = "* VAC/HOL Available as cell note ";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 5;
			this.Label18.Text = "* Timestamp Info as cell note";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Filter by Name :";
			this.sprRequests_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprRequests_Sheet1.SheetName = "Sheet1";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 0].Value = " ";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 1].Value = "Employee Name";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 2].Value = "TFD Hire Date";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 3].Value = "Shift Wanted";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 4].Value = "Shift to Give Up";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprRequests_Sheet1.ColumnHeader.Cells[0, 6].Value = "EmpID";
			this.sprRequests_Sheet1.Columns.Get(0).Label = " ";
			//this.sprRequests_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprRequests_Sheet1.Columns.Get(0).StyleName = "Button711636234713693639691";
			this.sprRequests_Sheet1.Columns.Get(0).Width = 13F;
			this.sprRequests_Sheet1.Columns.Get(1).Label = "Employee Name";
			this.sprRequests_Sheet1.Columns.Get(1).Width = 115F;
			this.sprRequests_Sheet1.Columns.Get(3).Label = "Shift Wanted";
			this.sprRequests_Sheet1.Columns.Get(3).Width = 98F;
			this.sprRequests_Sheet1.Columns.Get(4).Label = "Shift to Give Up";
			this.sprRequests_Sheet1.Columns.Get(4).Width = 101F;
			this.sprRequests_Sheet1.Columns.Get(5).Label = "ID";
			this.sprRequests_Sheet1.Columns.Get(5).Visible = false;
			this.sprRequests_Sheet1.Columns.Get(5).Width = 0F;
			this.sprRequests_Sheet1.Columns.Get(6).Label = "EmpID";
			this.sprRequests_Sheet1.Columns.Get(6).Visible = false;
			this.sprRequests_Sheet1.Columns.Get(6).Width = 0F;
			this.sprRequests_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.Text = "Grant Vacation Request ";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234713693620161", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text315636234713693629926", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Button711636234713693639691");
			namedStyle3.CellType = buttonCellType1;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = buttonCellType1;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmGrantVACRequest";
			cboKOT.Items.Add("FHL");
			cboKOT.Items.Add("KEL");
			cboKOT.Items.Add("MIL");
			cboKOT.Items.Add("VAC");
			this.sprRequests.NamedStyles.Add(namedStyle1);
			this.sprRequests.NamedStyles.Add(namedStyle2);
			this.sprRequests.NamedStyles.Add(namedStyle3);
			this.sprRequests.Sheets.Add(this.sprRequests_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtUpdateComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboKOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUpdateNameList { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calRequestDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calGiveUpDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRequestAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRequestPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbgiveup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReqNameList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRequests { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRequests_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}