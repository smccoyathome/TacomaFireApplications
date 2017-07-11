using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgVacationRequest))]
	public class dlgVacationRequestViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var buttonCellType2 = ctx.Resolve<FarPoint.ViewModels.ButtonCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle8;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var buttonCellType1 = ctx.Resolve<FarPoint.ViewModels.ButtonCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprGranted = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprGranted.TabIndex = 11;
			this.sprGranted.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.optUpdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optUpdate
			// 
			this.optUpdate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optUpdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optUpdate.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optUpdate.Name = "optUpdate";
			this.optUpdate.TabIndex = 3;
			this.optUpdate.Text = "Update / Schedule Leave ";
			this.optUpdate.Visible = false;
			this.optDelete = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optDelete
			// 
			this.optDelete.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optDelete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optDelete.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optDelete.Name = "optDelete";
			this.optDelete.TabIndex = 2;
			this.optDelete.Text = "Delete Requests/Available Shifts";
			this.optDelete.Visible = false;
			this.optAvailable = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optAvailable
			// 
			this.optAvailable.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optAvailable.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optAvailable.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optAvailable.Name = "optAvailable";
			this.optAvailable.TabIndex = 1;
			this.optAvailable.Text = "Make Shift Available ";
			this.optAvailable.Visible = false;
			this.optRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			// 
			// optRequest
			// 
			this.optRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.optRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optRequest.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.optRequest.Name = "optRequest";
			this.optRequest.TabIndex = 0;
			this.optRequest.Text = "Request Vacation";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 75;
			this.Label21.Text = "Purple = Leave currently scheduled for same date...";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.Blue;
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 62;
			this.Label14.Text = "Blue = Now Past Due";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 61;
			this.Label13.Text = "Green = Created Today";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 60;
			this.Label15.Text = "Red = Shift Wanted/Give Out on Date Clicked";
			this.cboReqNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboReqNameList
			// 
			this.cboReqNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboReqNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboReqNameList.Name = "cboReqNameList";
			this.cboReqNameList.TabIndex = 68;
			this.cboReqNameList.Text = "cboReqNameList";
			this.sprRequests = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprRequests.TabIndex = 76;
			this.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 71;
			this.Label19.Text = "* VAC/HOL Available as cell note ";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 70;
			this.Label18.Text = "* Timestamp Info as cell note";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 66;
			this.Label1.Text = "Filter by Name :";
			this.sprAvailable = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprAvailable.TabIndex = 10;
			this.sprAvailable.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprAvailable.Visible = false;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 7;
			this.txtComment.Text = "txtComment";
			this.lstCurrSched = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstCurrSched
			// 
			this.lstCurrSched.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstCurrSched.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstCurrSched.Name = "lstCurrSched";
			this.lstCurrSched.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstCurrSched.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstCurrSched.TabIndex = 5;
			this.cboNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNameList
			// 
			this.cboNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboNameList.Name = "cboNameList";
			this.cboNameList.TabIndex = 4;
			this.cboNameList.Text = "cboNameList";
			this.lstCurrVAC = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstCurrVAC
			// 
			this.lstCurrVAC.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstCurrVAC.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstCurrVAC.Name = "lstCurrVAC";
			this.lstCurrVAC.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstCurrVAC.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstCurrVAC.TabIndex = 6;
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 69;
			this.Label17.Text = "Available Leave  VAC  /  HOL";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 36;
			this.Label7.Text = "Vacation Shifts";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 35;
			this.Label6.Text = "Scheduled Shifts";
			this.lbHOL = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHOL
			// 
			this.lbHOL.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHOL.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbHOL.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbHOL.Name = "lbHOL";
			this.lbHOL.TabIndex = 34;
			this.lbHOL.Text = "lbHOL";
			this.lbVAC = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVAC
			// 
			this.lbVAC.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVAC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbVAC.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbVAC.Name = "lbVAC";
			this.lbVAC.TabIndex = 33;
			this.lbVAC.Text = "lbVAC";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 19;
			this.Label4.Text = "Add Comment:";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 18;
			this.Label5.Text = "Select Date To Give Up, if you don\'t have leave available:";
			this.lblDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblDate
			// 
			this.lblDate.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lblDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lblDate.Name = "lblDate";
			this.lblDate.TabIndex = 17;
			this.lblDate.Text = "Pick Date/Shift Wanted:";
			this.lblName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblName
			// 
			this.lblName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lblName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 16;
			this.lblName.Text = "Select Name:";
			this.dtpGiveOut = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtpGiveOut.Name = "dtpGiveOut";
			this.dtpGiveOut.TabIndex = 57;
			this.txtAvailComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAvailComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAvailComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtAvailComment.Name = "txtAvailComment";
			this.txtAvailComment.TabIndex = 30;
			this.txtAvailComment.Text = "txtAvailComment";
			this.lbAvailComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailComment
			// 
			this.lbAvailComment.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbAvailComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbAvailComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lbAvailComment.Name = "lbAvailComment";
			this.lbAvailComment.TabIndex = 31;
			this.lbAvailComment.Text = "Add Comment:";
			this.lbExistPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExistPM
			// 
			this.lbExistPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExistPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExistPM.Name = "lbExistPM";
			this.lbExistPM.TabIndex = 38;
			this.lbExistPM.Text = "llbExistPM";
			this.lbExistPM.Visible = false;
			this.lbExistAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExistAM
			// 
			this.lbExistAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExistAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExistAM.Name = "lbExistAM";
			this.lbExistAM.TabIndex = 37;
			this.lbExistAM.Text = "llbExistAM";
			this.lbExistAM.Visible = false;
			this.lbREGam = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGam
			// 
			this.lbREGam.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbREGam.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbREGam.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbREGam.Name = "lbREGam";
			this.lbREGam.TabIndex = 29;
			this.lbREGam.Text = "lbREGam";
			this.lbREGam.Visible = false;
			this.lbREGpm = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbREGpm
			// 
			this.lbREGpm.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbREGpm.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbREGpm.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbREGpm.Name = "lbREGpm";
			this.lbREGpm.TabIndex = 28;
			this.lbREGpm.Text = "lbREGpm";
			this.lbREGpm.Visible = false;
			this.lbSelectAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectAM
			// 
			this.lbSelectAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbSelectAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectAM.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbSelectAM.Name = "lbSelectAM";
			this.lbSelectAM.TabIndex = 27;
			this.lbSelectAM.Text = "lbSelectAM";
			this.lbSelectAM.Visible = false;
			this.lbSelectPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectPM
			// 
			this.lbSelectPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbSelectPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectPM.ForeColor = UpgradeHelpers.Helpers.Color.Aqua;
			this.lbSelectPM.Name = "lbSelectPM";
			this.lbSelectPM.TabIndex = 26;
			this.lbSelectPM.Text = "lbSelectPM";
			this.lbSelectPM.Visible = false;
			this.lbSelectTitle1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSelectTitle1
			// 
			this.lbSelectTitle1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbSelectTitle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectTitle1.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbSelectTitle1.Name = "lbSelectTitle1";
			this.lbSelectTitle1.TabIndex = 25;
			this.lbSelectTitle1.Text = "Scheduled Leave Totals";
			this.lbSelectTitle1.Visible = false;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 58;
			this.Label11.Text = "Give Date Out On:";
			this.cboUpdateNameList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUpdateNameList
			// 
			this.cboUpdateNameList.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUpdateNameList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboUpdateNameList.Name = "cboUpdateNameList";
			this.cboUpdateNameList.TabIndex = 48;
			this.cboUpdateNameList.Text = "cboUpdateNameList";
			this.cboKOT = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboKOT
			// 
			this.cboKOT.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboKOT.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboKOT.Name = "cboKOT";
			this.cboKOT.TabIndex = 47;
			this.cboKOT.Text = "cboKOT";
			this.txtUpdateComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtUpdateComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtUpdateComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtUpdateComment.Name = "txtUpdateComment";
			this.txtUpdateComment.TabIndex = 40;
			this.txtUpdateComment.Text = "txtUpdateComment";
			this.calRequestDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calRequestDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calRequestDate.MaxDate = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calRequestDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calRequestDate.Name = "calRequestDate";
			this.calRequestDate.TabIndex = 43;
			this.calRequestDate.Value = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calGiveUpDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.calGiveUpDate.MaxDate = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
			this.calGiveUpDate.Name = "calGiveUpDate";
			this.calGiveUpDate.TabIndex = 46;
			this.calGiveUpDate.Value = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
			this.calGiveUpDate.Visible = false;
			this.lbUpdateVAC = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUpdateVAC
			// 
			this.lbUpdateVAC.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUpdateVAC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUpdateVAC.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbUpdateVAC.Name = "lbUpdateVAC";
			this.lbUpdateVAC.TabIndex = 74;
			this.lbUpdateVAC.Text = "lbVAC";
			this.lbUpdateHOL = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUpdateHOL
			// 
			this.lbUpdateHOL.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUpdateHOL.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUpdateHOL.ForeColor = UpgradeHelpers.Helpers.Color.Yellow;
			this.lbUpdateHOL.Name = "lbUpdateHOL";
			this.lbUpdateHOL.TabIndex = 73;
			this.lbUpdateHOL.Text = "lbHOL";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 72;
			this.Label20.Text = "Available Leave  VAC  /  HOL";
			this.lbAvailPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailPM
			// 
			this.lbAvailPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAvailPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAvailPM.Name = "lbAvailPM";
			this.lbAvailPM.TabIndex = 56;
			this.lbAvailPM.Text = "lbAvailPM";
			this.lbAvailPM.Visible = false;
			this.lbRequestPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRequestPM
			// 
			this.lbRequestPM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRequestPM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRequestPM.Name = "lbRequestPM";
			this.lbRequestPM.TabIndex = 55;
			this.lbRequestPM.Text = "lbRequestPM";
			this.lbRequestPM.Visible = false;
			this.lbAvailAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailAM
			// 
			this.lbAvailAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAvailAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAvailAM.Name = "lbAvailAM";
			this.lbAvailAM.TabIndex = 54;
			this.lbAvailAM.Text = "lbAvailAM";
			this.lbAvailAM.Visible = false;
			this.lbRequestAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRequestAM
			// 
			this.lbRequestAM.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbRequestAM.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbRequestAM.Name = "lbRequestAM";
			this.lbRequestAM.TabIndex = 53;
			this.lbRequestAM.Text = "lbRequestAM";
			this.lbRequestAM.Visible = false;
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 52;
			this.Label12.Text = "Leave KOT";
			this.lbgiveup = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbgiveup
			// 
			this.lbgiveup.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lbgiveup.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbgiveup.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lbgiveup.Name = "lbgiveup";
			this.lbgiveup.TabIndex = 51;
			this.lbgiveup.Text = "Give Up Date";
			this.lbgiveup.Visible = false;
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 50;
			this.Label10.Text = "Leave Date";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 49;
			this.Label9.Text = "Employee Name";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 42;
			this.Label8.Text = "Update Comment";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 13;
			this.Label2.Text = "Vacation Granted";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 12;
			this.Label3.Text = "Shifts Available";
			this.Label3.Visible = false;
			this.sprAvailable_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAvailable_Sheet1.SheetName = "Sheet1";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 0].Value = " ";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 1].Value = "Shift Available";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 2].Value = "Give Out On";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 3].Value = "Created By";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 4].Value = "Created On";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 6].Value = "EmpID";
			this.sprAvailable_Sheet1.Columns.Get(0).Label = " ";
			this.sprAvailable_Sheet1.Columns.Get(0).StyleName = "Button756636234679007622036";
			this.sprAvailable_Sheet1.Columns.Get(0).Width = 13F;
			this.sprAvailable_Sheet1.Columns.Get(1).Label = "Shift Available";
			this.sprAvailable_Sheet1.Columns.Get(1).Width = 91F;
			this.sprAvailable_Sheet1.Columns.Get(2).Label = "Give Out On";
			this.sprAvailable_Sheet1.Columns.Get(2).Width = 84F;
			this.sprAvailable_Sheet1.Columns.Get(3).Label = "Created By";
			this.sprAvailable_Sheet1.Columns.Get(3).Width = 110F;
			this.sprAvailable_Sheet1.Columns.Get(4).Label = "Created On";
			this.sprAvailable_Sheet1.Columns.Get(4).Width = 74F;
			this.sprAvailable_Sheet1.Columns.Get(5).Label = "ID";
			this.sprAvailable_Sheet1.Columns.Get(5).Visible = false;
			this.sprAvailable_Sheet1.Columns.Get(5).Width = 0F;
			this.sprAvailable_Sheet1.Columns.Get(6).Label = "EmpID";
			this.sprAvailable_Sheet1.Columns.Get(6).Visible = false;
			this.sprAvailable_Sheet1.Columns.Get(6).Width = 0F;
			this.sprAvailable_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
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
            //SortIndicator is OBSOLETE
            //this.sprRequests_Sheet1.Columns.Get(0).SortIndicator = FarPoint.ViewModels.SortIndicator.Descending;
			this.sprRequests_Sheet1.Columns.Get(0).StyleName = "Button711636234676316534511";
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
			this.sprGranted_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprGranted_Sheet1.SheetName = "Sheet1";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee Name";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 1].Value = "New Shift Off";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 2].Value = "Shift Given Up";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 3].Value = "Granted By";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 4].Value = "Date Granted";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 5].Value = "Group";
			this.sprGranted_Sheet1.ColumnHeader.Cells[0, 6].Value = "ID";
			this.sprGranted_Sheet1.Columns.Get(0).Label = "Employee Name";
			this.sprGranted_Sheet1.Columns.Get(0).Width = 105F;
			this.sprGranted_Sheet1.Columns.Get(1).Label = "New Shift Off";
			this.sprGranted_Sheet1.Columns.Get(1).Width = 90F;
			this.sprGranted_Sheet1.Columns.Get(2).Label = "Shift Given Up";
			this.sprGranted_Sheet1.Columns.Get(2).Width = 86F;
			this.sprGranted_Sheet1.Columns.Get(3).Label = "Granted By";
			this.sprGranted_Sheet1.Columns.Get(3).Width = 84F;
			this.sprGranted_Sheet1.Columns.Get(4).Label = "Date Granted";
			this.sprGranted_Sheet1.Columns.Get(4).Width = 88F;
			this.sprGranted_Sheet1.Columns.Get(5).Label = "Group";
			this.sprGranted_Sheet1.Columns.Get(5).Width = 37F;
			this.sprGranted_Sheet1.Columns.Get(6).Label = "ID";
			//this.sprGranted_Sheet1.Columns.Get(6).SortIndicator = FarPoint.ViewModels.SortIndicator.Ascending;
			this.sprGranted_Sheet1.Columns.Get(6).Visible = false;
			this.sprGranted_Sheet1.Columns.Get(6).Width = 0F;
			this.sprGranted_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 9;
			this.CancelButton_Renamed.Text = "Back";
			this.chkHZMOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkHZMOnly
			// 
			this.chkHZMOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkHZMOnly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkHZMOnly.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.chkHZMOnly.Name = "chkHZMOnly";
			this.chkHZMOnly.TabIndex = 78;
			this.chkHZMOnly.Text = "Display Hazmat Only";
			this.chkPMOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPMOnly
			// 
			this.chkPMOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkPMOnly.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.6F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPMOnly.ForeColor = UpgradeHelpers.Helpers.Color.Lime;
			this.chkPMOnly.Name = "chkPMOnly";
			this.chkPMOnly.TabIndex = 77;
			this.chkPMOnly.Text = "Display Paramedics Only";
			this.cmdClearRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearRequest
			// 
			this.cmdClearRequest.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearRequest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearRequest.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearRequest.Name = "cmdClearRequest";
			this.cmdClearRequest.TabIndex = 67;
			this.cmdClearRequest.Text = "Clear Filter / Refresh Grid";
			this.cmdClearAvail = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClearAvail
			// 
			this.cmdClearAvail.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClearAvail.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClearAvail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClearAvail.Name = "cmdClearAvail";
			this.cmdClearAvail.TabIndex = 32;
			this.cmdClearAvail.Text = "Refresh Grid";
			this.cmdClearAvail.Visible = false;
			this.cmdReqDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdReqDone
			// 
			this.cmdReqDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdReqDone.Enabled = false;
			this.cmdReqDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdReqDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdReqDone.Name = "cmdReqDone";
			this.cmdReqDone.TabIndex = 8;
			this.cmdReqDone.Text = "Done";
			this.calAvail = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			this.calAvail.Name = "calAvail";
			this.calAvail.TabIndex = 22;
			this.cmdAvailDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAvailDone
			// 
			this.cmdAvailDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAvailDone.Enabled = false;
			this.cmdAvailDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAvailDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAvailDone.Name = "cmdAvailDone";
			this.cmdAvailDone.TabIndex = 21;
			this.cmdAvailDone.Text = "Done";
			this.cmdUpdateDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdUpdateDone
			// 
			this.cmdUpdateDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdUpdateDone.Enabled = false;
			this.cmdUpdateDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpdateDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdUpdateDone.Name = "cmdUpdateDone";
			this.cmdUpdateDone.TabIndex = 41;
			this.cmdUpdateDone.Text = "Done";
			this.Text = "Vacation Request ";
			this.SelectedDate = "";
			this.chkPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPM
			// 
			this.chkPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkPM.Name = "chkPM";
			this.chkPM.TabIndex = 23;
			this.chkPM.Text = "PM";
			this.chkAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkAM
			// 
			this.chkAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			this.chkAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkAM.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.chkAM.Name = "chkAM";
			this.chkAM.TabIndex = 24;
			this.chkAM.Text = "AM";
			this.SelectedSchedDate = "";
			this.SelectedRequest = 0;
			this.LimitedPower = false;
			this.SelectedAvailable = 0;
			this.SelectedVACDate = "";
			this.Empid = "";
			this.ReqEmpid = "";
			this.chkUpdateAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkUpdateAM
			// 
			this.chkUpdateAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkUpdateAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkUpdateAM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkUpdateAM.Name = "chkUpdateAM";
			this.chkUpdateAM.TabIndex = 45;
			this.chkUpdateAM.Text = "AM";
			this.chkUpdatePM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkUpdatePM
			// 
			this.chkUpdatePM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkUpdatePM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkUpdatePM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkUpdatePM.Name = "chkUpdatePM";
			this.chkUpdatePM.TabIndex = 44;
			this.chkUpdatePM.Text = "PM";
			this.chkGiveUpAM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkGiveUpAM
			// 
			this.chkGiveUpAM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkGiveUpAM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkGiveUpAM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkGiveUpAM.Name = "chkGiveUpAM";
			this.chkGiveUpAM.TabIndex = 63;
			this.chkGiveUpAM.Text = "AM";
			this.chkGiveUpAM.Visible = false;
			this.chkGiveUpPM = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkGiveUpPM
			// 
			this.chkGiveUpPM.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.chkGiveUpPM.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkGiveUpPM.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chkGiveUpPM.Name = "chkGiveUpPM";
			this.chkGiveUpPM.TabIndex = 64;
			this.chkGiveUpPM.Text = "PM";
			this.chkGiveUpPM.Visible = false;
			this.frmRequestVAC = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmRequestVAC
			// 
			this.frmRequestVAC.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmRequestVAC.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmRequestVAC.Name = "frmRequestVAC";
			this.frmRequestVAC.TabIndex = 15;
			this.frmRequestVAC.Visible = false;
			this.frmShiftAvail = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmShiftAvail
			// 
			this.frmShiftAvail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmShiftAvail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmShiftAvail.Name = "frmShiftAvail";
			this.frmShiftAvail.TabIndex = 20;
			this.frmUpdateRequest = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmUpdateRequest
			// 
			this.frmUpdateRequest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmUpdateRequest.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmUpdateRequest.Name = "frmUpdateRequest";
			this.frmUpdateRequest.TabIndex = 39;
			this.frmLegend = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmLegend
			// 
			this.frmLegend.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.frmLegend.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmLegend.Name = "frmLegend";
			this.frmLegend.TabIndex = 59;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234676414018506", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text307636234676414038036", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234676316417331", "DataAreaDefault");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Parent = "DataAreaDefault";
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text315636234676316436861", "DataAreaDefault");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Button711636234676316534511");
			namedStyle5.CellType = buttonCellType1;
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Renderer = buttonCellType1;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234679007592741", "DataAreaDefault");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Parent = "DataAreaDefault";
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text348636234679007602506", "DataAreaDefault");
			namedStyle7.CellType = textCellType3;
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Parent = "DataAreaDefault";
			namedStyle7.Renderer = textCellType3;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle8 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Button756636234679007622036");
			namedStyle8.CellType = buttonCellType2;
			namedStyle8.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle8.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle8.Renderer = buttonCellType2;
			namedStyle8.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.dlgVacationRequest";
			cboKOT.Items.Add("FHL");
			cboKOT.Items.Add("KEL");
			cboKOT.Items.Add("MIL");
			cboKOT.Items.Add("VAC");
			this.sprGranted.NamedStyles.Add(namedStyle1);
			this.sprGranted.NamedStyles.Add(namedStyle2);
			this.sprGranted.Sheets.Add(this.sprGranted_Sheet1);
			this.sprRequests.NamedStyles.Add(namedStyle3);
			this.sprRequests.NamedStyles.Add(namedStyle4);
			this.sprRequests.NamedStyles.Add(namedStyle5);
			this.sprRequests.Sheets.Add(this.sprRequests_Sheet1);
			this.sprAvailable.NamedStyles.Add(namedStyle6);
			this.sprAvailable.NamedStyles.Add(namedStyle7);
			this.sprAvailable.NamedStyles.Add(namedStyle8);
			this.sprAvailable.Sheets.Add(this.sprAvailable_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprGranted { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optUpdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optDelete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel optRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboReqNameList { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprRequests { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstCurrSched { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstCurrVAC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHOL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVAC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblName { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtpGiveOut { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAvailComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExistPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExistAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGam { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbREGpm { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSelectTitle1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUpdateNameList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboKOT { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtUpdateComment { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calRequestDate { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calGiveUpDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUpdateVAC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUpdateHOL { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRequestPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRequestAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbgiveup { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAvailable_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprRequests_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprGranted_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkHZMOnly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPMOnly { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClearAvail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdReqDone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calAvail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAvailDone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdUpdateDone { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAM { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedSchedDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedRequest { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean LimitedPower { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SelectedAvailable { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String SelectedVACDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String Empid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReqEmpid { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkUpdateAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkUpdatePM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkGiveUpAM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkGiveUpPM { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmRequestVAC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmShiftAvail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmUpdateRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmLegend { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}