using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.wzdHazmat))]
	public class wzdHazmatViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
            // Label23
            // 
            this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 174;
            this.Label23.Text = "Wizard Navigation Bar";
            // 
            // NavBar
            //
            this.NavBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>(); 
			this.NavBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.NavBar.Enabled = true;
			this.NavBar.Name = "NavBar";
			this.NavBar.Visible = true;
			this._optType_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstActionsTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstActionsTaken
			// 
			this.lstActionsTaken.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstActionsTaken.Enabled = true;
			this.lstActionsTaken.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstActionsTaken.Name = "lstActionsTaken";
			this.lstActionsTaken.TabIndex = 159;
			this.lstActionsTaken.Visible = true;
			this.lstActionsTaken.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;

            // 
            // cboHazmatIDSource
            // 
            this.cboHazmatIDSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboHazmatIDSource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHazmatIDSource.Enabled = true;
			this.cboHazmatIDSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboHazmatIDSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboHazmatIDSource.Name = "cboHazmatIDSource";
			this.cboHazmatIDSource.TabIndex = 158;
			this.cboHazmatIDSource.Text = " cboHazmatIDSource";
			this.cboHazmatIDSource.Visible = true;

            // 
            // Label6
            // 
            this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 149;
			this.Label6.Text = "HAZMAT ACTIONS TAKEN";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 148;
			this.Label5.Text = "HAZARDOUS MATERIAL ID SOURCE";
			this._lbFrameTitle_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();

            // 
            // frmHazmatType
            // 
            this.frmHazmatType = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			this.frmHazmatType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmHazmatType.Enabled = true;
			this.frmHazmatType.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmHazmatType.Name = "frmHazmatType";
			this.frmHazmatType.TabIndex = 0;
			this.frmHazmatType.Tag = "6";
			this.frmHazmatType.Visible = true;

            // 
            // lstMessage
            // 
            this.lstMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			this.lstMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.lstMessage.Enabled = true;
			this.lstMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstMessage.Name = "lstMessage";
			this.lstMessage.TabIndex = 172;
			this.lstMessage.Visible = true;
			this.lstMessage.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lbIncidentNumberTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNumberTitle
			// 
			this.lbIncidentNumberTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNumberTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNumberTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbIncidentNumberTitle.Name = "lbIncidentNumberTitle";
			this.lbIncidentNumberTitle.TabIndex = 171;
			this.lbIncidentNumberTitle.Text = "INCIDENT #";
			this.lbRSIncidentNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSIncidentNumber
			// 
			this.lbRSIncidentNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSIncidentNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSIncidentNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSIncidentNumber.Name = "lbRSIncidentNumber";
			this.lbRSIncidentNumber.TabIndex = 170;
			this.lbRSIncidentNumber.Text = "001230056";
			this.lbReportByTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReportByTitle
			// 
			this.lbReportByTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReportByTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReportByTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbReportByTitle.Name = "lbReportByTitle";
			this.lbReportByTitle.TabIndex = 169;
			this.lbReportByTitle.Text = "REPORT BY:";
			this.lbRSReportedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSReportedBy
			// 
			this.lbRSReportedBy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSReportedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSReportedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSReportedBy.Name = "lbRSReportedBy";
			this.lbRSReportedBy.TabIndex = 168;
			this.lbRSReportedBy.Text = "Hilderbrand, Robert";
			this.lbRSEmployeeID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSEmployeeID
			// 
			this.lbRSEmployeeID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSEmployeeID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSEmployeeID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSEmployeeID.Name = "lbRSEmployeeID";
			this.lbRSEmployeeID.TabIndex = 167;
			this.lbRSEmployeeID.Text = "02341";
			this.lbRSPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSPosition
			// 
			this.lbRSPosition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSPosition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSPosition.Name = "lbRSPosition";
			this.lbRSPosition.TabIndex = 166;
			this.lbRSPosition.Text = "Officer";
			this.lbRSUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSUnit
			// 
			this.lbRSUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSUnit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSUnit.Name = "lbRSUnit";
			this.lbRSUnit.TabIndex = 165;
			this.lbRSUnit.Text = "E10";
			this.lbRSShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSShift
			// 
			this.lbRSShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSShift.Name = "lbRSShift";
			this.lbRSShift.TabIndex = 164;
			this.lbRSShift.Text = "D Shift";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 163;
			this.Label9.Text = "CURRENT REPORT:";
			this.lbRSCurrReportType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSCurrReportType
			// 
			this.lbRSCurrReportType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSCurrReportType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSCurrReportType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRSCurrReportType.Name = "lbRSCurrReportType";
			this.lbRSCurrReportType.TabIndex = 162;
			this.lbRSCurrReportType.Text = "Unit Report";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 161;
			this.Label8.Text = "REPORTS FOR THIS INCIDENT:";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 160;
			this.Label7.Text = "ASSIGNMENT:";
			this._lbFrameTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.frmReportStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmReportStatus
			// 
			this.frmReportStatus.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmReportStatus.Enabled = true;
			this.frmReportStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmReportStatus.Name = "frmReportStatus";
			this.frmReportStatus.TabIndex = 126;
			this.frmReportStatus.Tag = "1";
			this.frmReportStatus.Visible = false;
			this.lstOutsideResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstOutsideResource
			// 
			this.lstOutsideResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstOutsideResource.Enabled = true;
			this.lstOutsideResource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstOutsideResource.Name = "lstOutsideResource";
			this.lstOutsideResource.TabIndex = 67;
			this.lstOutsideResource.Visible = true;
			this.lstOutsideResource.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboResourceUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboResourceUse
			// 
			this.cboResourceUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboResourceUse.Enabled = true;
			this.cboResourceUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboResourceUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboResourceUse.Name = "cboResourceUse";
			this.cboResourceUse.TabIndex = 64;
			this.cboResourceUse.Text = " cboResourceUse";
			this.cboResourceUse.Visible = true;
			this.cboOutsideResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOutsideResource
			// 
			this.cboOutsideResource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOutsideResource.Enabled = true;
			this.cboOutsideResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOutsideResource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOutsideResource.Name = "cboOutsideResource";
			this.cboOutsideResource.TabIndex = 63;
			this.cboOutsideResource.Text = " cboOutsideResource";
			this.cboOutsideResource.Visible = true;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 147;
			this.Label4.Text = "USED FOR:";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 146;
			this.Label3.Text = "RESOURCE:";
			this.cboDisposition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDisposition
			// 
			this.cboDisposition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboDisposition.Enabled = true;
			this.cboDisposition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboDisposition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboDisposition.Name = "cboDisposition";
			this.cboDisposition.TabIndex = 62;
			this.cboDisposition.Text = " cboDisposition";
			this.cboDisposition.Visible = true;
			this._lbFrameTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbDispOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDispOfRelease
			// 
			this.lbDispOfRelease.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDispOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDispOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbDispOfRelease.Name = "lbDispOfRelease";
			this.lbDispOfRelease.TabIndex = 143;
			this.lbDispOfRelease.Text = "DISPOSITION OF HAZMAT INCIDENT";
			this._lbFrameTitle_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.frmNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmNarration
			// 
			this.frmNarration.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmNarration.Enabled = true;
			this.frmNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNarration.Name = "frmNarration";
			this.frmNarration.TabIndex = 106;
			this.frmNarration.Tag = "7";
			this.frmNarration.Visible = false;

            // 
            // lstMaterialUsed
            // 
            this.lstMaterialUsed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            this.lstMaterialUsed.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstMaterialUsed.Enabled = true;
			this.lstMaterialUsed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstMaterialUsed.Name = "lstMaterialUsed";
			this.lstMaterialUsed.TabIndex = 57;
			this.lstMaterialUsed.Visible = true;
			this.lstMaterialUsed.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboDrugLabType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboDrugLabType
			// 
			this.cboDrugLabType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboDrugLabType.Enabled = true;
			this.cboDrugLabType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboDrugLabType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboDrugLabType.Name = "cboDrugLabType";
			this.cboDrugLabType.TabIndex = 54;
			this.cboDrugLabType.Text = " cboDrugLabType";
			this.cboDrugLabType.Visible = true;
			this.txtQuantity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtQuantity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtQuantity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtQuantity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.TabIndex = 56;
			this.cboMaterialUsed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMaterialUsed
			// 
			this.cboMaterialUsed.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMaterialUsed.Enabled = true;
			this.cboMaterialUsed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboMaterialUsed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboMaterialUsed.Name = "cboMaterialUsed";
			this.cboMaterialUsed.TabIndex = 55;
			this.cboMaterialUsed.Text = "  cboMaterialUsed";
			this.cboMaterialUsed.Visible = true;
			this.lbDrugLabType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDrugLabType
			// 
			this.lbDrugLabType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDrugLabType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDrugLabType.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbDrugLabType.Name = "lbDrugLabType";
			this.lbDrugLabType.TabIndex = 51;
			this.lbDrugLabType.Text = "DRUG LAB TYPE";
			this.lbFireServiceMaterialTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireServiceMaterialTitle
			// 
			this.lbFireServiceMaterialTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFireServiceMaterialTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireServiceMaterialTitle.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbFireServiceMaterialTitle.Name = "lbFireServiceMaterialTitle";
			this.lbFireServiceMaterialTitle.TabIndex = 50;
			this.lbFireServiceMaterialTitle.Text = "FIRE SERVICE MATERIAL USED:";
			this.lbQuantity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbQuantity
			// 
			this.lbQuantity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbQuantity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbQuantity.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbQuantity.Name = "lbQuantity";
			this.lbQuantity.TabIndex = 49;
			this.lbQuantity.Text = "QUANTITY";
			this._imgMain_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this._lbFrameTitle_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmDrugLab = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmDrugLab
			// 
			this.frmDrugLab.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmDrugLab.Enabled = true;
			this.frmDrugLab.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmDrugLab.Name = "frmDrugLab";
			this.frmDrugLab.TabIndex = 77;
			this.frmDrugLab.Tag = "12";
			this.frmDrugLab.Visible = false;
			this.cboAmountReleasedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAmountReleasedUnits
			// 
			this.cboAmountReleasedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAmountReleasedUnits.Enabled = true;
			this.cboAmountReleasedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAmountReleasedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAmountReleasedUnits.Name = "cboAmountReleasedUnits";
			this.cboAmountReleasedUnits.TabIndex = 40;
			this.cboAmountReleasedUnits.Text = " cboAmountReleasedUnits";
			this.cboAmountReleasedUnits.Visible = true;
			this.cboCommonChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCommonChemicals
			// 
			this.cboCommonChemicals.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCommonChemicals.Enabled = true;
			this.cboCommonChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCommonChemicals.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboCommonChemicals.Name = "cboCommonChemicals";
			this.cboCommonChemicals.TabIndex = 34;
			this.cboCommonChemicals.Text = " cboCommonChemicals";
			this.cboCommonChemicals.Visible = true;
			this.cboChemicalName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboChemicalName
			// 
			this.cboChemicalName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboChemicalName.Enabled = true;
			this.cboChemicalName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboChemicalName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboChemicalName.Name = "cboChemicalName";
			this.cboChemicalName.TabIndex = 35;
			this.cboChemicalName.Text = " cboChemicalName";
			this.cboChemicalName.Visible = true;
			this.cboUN = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboUN
			// 
			this.cboUN.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboUN.Enabled = true;
			this.cboUN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboUN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboUN.Name = "cboUN";
			this.cboUN.TabIndex = 36;
			this.cboUN.Text = " cboUN";
			this.cboUN.Visible = true;
			this.lbChemicalID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbChemicalID
			// 
			this.lbChemicalID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbChemicalID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbChemicalID.Name = "lbChemicalID";
			this.lbChemicalID.TabIndex = 150;
			this.lbChemicalID.Visible = false;
			this.lbChemicalName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbChemicalName
			// 
			this.lbChemicalName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbChemicalName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbChemicalName.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbChemicalName.Name = "lbChemicalName";
			this.lbChemicalName.TabIndex = 141;
			this.lbChemicalName.Text = "CHEMICAL NAME";
			this.lbCommonChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCommonChemicals
			// 
			this.lbCommonChemicals.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCommonChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCommonChemicals.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbCommonChemicals.Name = "lbCommonChemicals";
			this.lbCommonChemicals.TabIndex = 139;
			this.lbCommonChemicals.Text = "COMMON CHEMICALS";
			this.lbUN = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUN
			// 
			this.lbUN.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUN.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbUN.Name = "lbUN";
			this.lbUN.TabIndex = 138;
			this.lbUN.Text = "UN #";
			this.txtEstContainerCapacity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEstContainerCapacity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtEstContainerCapacity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtEstContainerCapacity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtEstContainerCapacity.Name = "txtEstContainerCapacity";
			this.txtEstContainerCapacity.TabIndex = 39;
			this.cboContainerCapacityUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboContainerCapacityUnits
			// 
			this.cboContainerCapacityUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboContainerCapacityUnits.Enabled = true;
			this.cboContainerCapacityUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboContainerCapacityUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboContainerCapacityUnits.Name = "cboContainerCapacityUnits";
			this.cboContainerCapacityUnits.TabIndex = 38;
			this.cboContainerCapacityUnits.Text = " cboContainerCapacityUnits";
			this.cboContainerCapacityUnits.Visible = true;
			this.cboContainerType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboContainerType
			// 
			this.cboContainerType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboContainerType.Enabled = true;
			this.cboContainerType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboContainerType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboContainerType.Name = "cboContainerType";
			this.cboContainerType.TabIndex = 37;
			this.cboContainerType.Text = " cboContainerType";
			this.cboContainerType.Visible = true;
			this.cboSecondaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSecondaryReleasedInto
			// 
			this.cboSecondaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSecondaryReleasedInto.Enabled = true;
			this.cboSecondaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSecondaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSecondaryReleasedInto.Name = "cboSecondaryReleasedInto";
			this.cboSecondaryReleasedInto.TabIndex = 45;
			this.cboSecondaryReleasedInto.Text = " cboSecondaryReleasedInto";
			this.cboSecondaryReleasedInto.Visible = true;
			this.cboPrimaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrimaryReleasedInto
			// 
			this.cboPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPrimaryReleasedInto.Enabled = true;
			this.cboPrimaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPrimaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPrimaryReleasedInto.Name = "cboPrimaryReleasedInto";
			this.cboPrimaryReleasedInto.TabIndex = 44;
			this.cboPrimaryReleasedInto.Text = " cboPrimaryReleasedInto";
			this.cboPrimaryReleasedInto.Visible = true;
			this.cboPhysicalStateReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPhysicalStateReleased
			// 
			this.cboPhysicalStateReleased.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPhysicalStateReleased.Enabled = true;
			this.cboPhysicalStateReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPhysicalStateReleased.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPhysicalStateReleased.Name = "cboPhysicalStateReleased";
			this.cboPhysicalStateReleased.TabIndex = 43;
			this.cboPhysicalStateReleased.Text = " cboPhysicalStateReleased";
			this.cboPhysicalStateReleased.Visible = true;
			this.cboPhysicalStateStored = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPhysicalStateStored
			// 
			this.cboPhysicalStateStored.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPhysicalStateStored.Enabled = true;
			this.cboPhysicalStateStored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPhysicalStateStored.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPhysicalStateStored.Name = "cboPhysicalStateStored";
			this.cboPhysicalStateStored.TabIndex = 42;
			this.cboPhysicalStateStored.Text = " cboPhysicalStateStored";
			this.cboPhysicalStateStored.Visible = true;
			this.txtEstAmountReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtEstAmountReleased.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtEstAmountReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtEstAmountReleased.Name = "txtEstAmountReleased";
			this.txtEstAmountReleased.TabIndex = 41;

            // 
            // Label1
            // 
            this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 142;
			this.Label1.Text = "AMOUNT RELEASED UNITS";

            // 
            // lbSecondReleasedInto
            // 
            this.lbSecondReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbSecondReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSecondReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSecondReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbSecondReleasedInto.Name = "lbSecondReleasedInto";
			this.lbSecondReleasedInto.TabIndex = 48;
			this.lbSecondReleasedInto.Text = "SECONDARY RELEASED INTO";
			this.lbPrimaryReleasedInto = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPrimaryReleasedInto
			// 
			this.lbPrimaryReleasedInto.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPrimaryReleasedInto.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPrimaryReleasedInto.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPrimaryReleasedInto.Name = "lbPrimaryReleasedInto";
			this.lbPrimaryReleasedInto.TabIndex = 47;
			this.lbPrimaryReleasedInto.Text = "PRIMARY RELEASED INTO";
			this.lbPhyStateReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyStateReleased
			// 
			this.lbPhyStateReleased.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyStateReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPhyStateReleased.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPhyStateReleased.Name = "lbPhyStateReleased";
			this.lbPhyStateReleased.TabIndex = 33;
			this.lbPhyStateReleased.Text = "PHYSICAL STATE RELEASED";
			this.lbPhyStateStored = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyStateStored
			// 
			this.lbPhyStateStored.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyStateStored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPhyStateStored.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPhyStateStored.Name = "lbPhyStateStored";
			this.lbPhyStateStored.TabIndex = 32;
			this.lbPhyStateStored.Text = "PHYSICAL STATE STORED";
			this.lbEstContainerCap = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEstContainerCap
			// 
			this.lbEstContainerCap.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEstContainerCap.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEstContainerCap.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEstContainerCap.Name = "lbEstContainerCap";
			this.lbEstContainerCap.TabIndex = 31;
			this.lbEstContainerCap.Text = "EST. CONTAINER CAPACITY";
			this.lbContainerCapUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContainerCapUnits
			// 
			this.lbContainerCapUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContainerCapUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContainerCapUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContainerCapUnits.Name = "lbContainerCapUnits";
			this.lbContainerCapUnits.TabIndex = 30;
			this.lbContainerCapUnits.Text = "CONTAINER CAPACITY UNITS";
			this.lbContainerType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContainerType
			// 
			this.lbContainerType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContainerType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContainerType.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContainerType.Name = "lbContainerType";
			this.lbContainerType.TabIndex = 29;
			this.lbContainerType.Text = "CONTAINER TYPE";
			this.lbEstAmountReleased = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEstAmountReleased
			// 
			this.lbEstAmountReleased.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEstAmountReleased.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEstAmountReleased.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEstAmountReleased.Name = "lbEstAmountReleased";
			this.lbEstAmountReleased.TabIndex = 28;
			this.lbEstAmountReleased.Text = "EST. AMOUNT RELEASED";
			this._lbFrameTitle_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmChemicalDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmChemicalDetail
			// 
			this.frmChemicalDetail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmChemicalDetail.Enabled = true;
			this.frmChemicalDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmChemicalDetail.Name = "frmChemicalDetail";
			this.frmChemicalDetail.TabIndex = 140;
			this.frmChemicalDetail.Tag = "11";
			this.frmChemicalDetail.Visible = false;
			this.cboIncidentType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentType
			// 
			this.cboIncidentType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboIncidentType.Enabled = true;
			this.cboIncidentType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboIncidentType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboIncidentType.Name = "cboIncidentType";
			this.cboIncidentType.TabIndex = 151;
			this.cboIncidentType.Text = " cboIncidentType";
			this.cboIncidentType.Visible = true;
			this.txtBuildingsEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBuildingsEvacuated.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBuildingsEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtBuildingsEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtBuildingsEvacuated.Name = "txtBuildingsEvacuated";
			this.txtBuildingsEvacuated.TabIndex = 21;
			this.txtPeopleEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPeopleEvacuated.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPeopleEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtPeopleEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtPeopleEvacuated.Name = "txtPeopleEvacuated";
			this.txtPeopleEvacuated.TabIndex = 20;
			this.cboPopulationDensity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPopulationDensity
			// 
			this.cboPopulationDensity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPopulationDensity.Enabled = true;
			this.cboPopulationDensity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPopulationDensity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPopulationDensity.Name = "cboPopulationDensity";
			this.cboPopulationDensity.TabIndex = 19;
			this.cboPopulationDensity.Text = " cboPopulationDensity";
			this.cboPopulationDensity.Visible = true;
			this.cboAreaEvacuatedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaEvacuatedUnits
			// 
			this.cboAreaEvacuatedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaEvacuatedUnits.Enabled = true;
			this.cboAreaEvacuatedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAreaEvacuatedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAreaEvacuatedUnits.Name = "cboAreaEvacuatedUnits";
			this.cboAreaEvacuatedUnits.TabIndex = 17;
			this.cboAreaEvacuatedUnits.Text = " cboAraEvacuatedUnit";
			this.cboAreaEvacuatedUnits.Visible = true;
			this.cboAreaAffectedUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaAffectedUnits
			// 
			this.cboAreaAffectedUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaAffectedUnits.Enabled = true;
			this.cboAreaAffectedUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAreaAffectedUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAreaAffectedUnits.Name = "cboAreaAffectedUnits";
			this.cboAreaAffectedUnits.TabIndex = 15;
			this.cboAreaAffectedUnits.Text = " cboAreaAffectedUnits";
			this.cboAreaAffectedUnits.Visible = true;
			this.txtAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAreaAffected.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtAreaAffected.Name = "txtAreaAffected";
			this.txtAreaAffected.TabIndex = 16;
			this.txtAreaEvacuated = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAreaEvacuated.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAreaEvacuated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtAreaEvacuated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtAreaEvacuated.Name = "txtAreaEvacuated";
			this.txtAreaEvacuated.TabIndex = 18;
			this.lstMitigatingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMitigatingFactors
			// 
			this.lstMitigatingFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstMitigatingFactors.Enabled = true;
			this.lstMitigatingFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstMitigatingFactors.Name = "lstMitigatingFactors";
			this.lstMitigatingFactors.TabIndex = 11;
			this.lstMitigatingFactors.Visible = true;
			this.lstMitigatingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this._optOccurredFirst_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOccurredFirst_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optOccurredFirst_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstEquipmentInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstEquipmentInvolved
			// 
			this.lstEquipmentInvolved.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstEquipmentInvolved.Enabled = true;
			this.lstEquipmentInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.lstEquipmentInvolved.Name = "lstEquipmentInvolved";
			this.lstEquipmentInvolved.TabIndex = 22;
			this.lstEquipmentInvolved.Visible = true;
			this.lstEquipmentInvolved.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstContributingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContributingFactors
			// 
			this.lstContributingFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstContributingFactors.Enabled = true;
			this.lstContributingFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.lstContributingFactors.Name = "lstContributingFactors";
			this.lstContributingFactors.TabIndex = 10;
			this.lstContributingFactors.Visible = true;
			this.lstContributingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.txtReleaseFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseFloor.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtReleaseFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtReleaseFloor.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtReleaseFloor.Name = "txtReleaseFloor";
			this.txtReleaseFloor.TabIndex = 8;
			this.cboAreaOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaOfOrigin
			// 
			this.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaOfOrigin.Enabled = true;
			this.cboAreaOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAreaOfOrigin.Name = "cboAreaOfOrigin";
			this.cboAreaOfOrigin.TabIndex = 6;
			this.cboAreaOfOrigin.Text = " cboAreaOfOrigin";
			this.cboAreaOfOrigin.Visible = true;
			this.cboCauseOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCauseOfRelease
			// 
			this.cboCauseOfRelease.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCauseOfRelease.Enabled = true;
			this.cboCauseOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCauseOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboCauseOfRelease.Name = "cboCauseOfRelease";
			this.cboCauseOfRelease.TabIndex = 7;
			this.cboCauseOfRelease.Text = " cboCauseOfRelease";
			this.cboCauseOfRelease.Visible = true;
			this.cboStreetClass = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStreetClass
			// 
			this.cboStreetClass.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStreetClass.Enabled = true;
			this.cboStreetClass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboStreetClass.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboStreetClass.Name = "cboStreetClass";
			this.cboStreetClass.TabIndex = 9;
			this.cboStreetClass.Text = " cboStreetClass";
			this.cboStreetClass.Visible = true;

            // 
            // cboGeneralPropertyUse
            // 
            this.cboGeneralPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGeneralPropertyUse.Enabled = true;
			this.cboGeneralPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboGeneralPropertyUse.Name = "cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.TabIndex = 4;
			this.cboGeneralPropertyUse.Text = " cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.Visible = true;

            // 
            // cboSpecificPropertyUse
            // 
            this.cboSpecificPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecificPropertyUse.Enabled = true;
			this.cboSpecificPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSpecificPropertyUse.Name = "cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.TabIndex = 5;
			this.cboSpecificPropertyUse.Text = " cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.Visible = true;

            // 
            // Label2
            // 
            this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 152;
			this.Label2.Text = "HAZMAT RELEASE TYPE";
			this.lbPeopleEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPeopleEvac
			// 
			this.lbPeopleEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPeopleEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPeopleEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPeopleEvac.Name = "lbPeopleEvac";
			this.lbPeopleEvac.TabIndex = 136;
			this.lbPeopleEvac.Text = "PEOPLE EVACUATED";
			this.lbBldgEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBldgEvac
			// 
			this.lbBldgEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBldgEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBldgEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbBldgEvac.Name = "lbBldgEvac";
			this.lbBldgEvac.TabIndex = 135;
			this.lbBldgEvac.Text = "BUILDINGS EVACUATED";
			this.lbPopDensity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPopDensity
			// 
			this.lbPopDensity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPopDensity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPopDensity.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbPopDensity.Name = "lbPopDensity";
			this.lbPopDensity.TabIndex = 134;
			this.lbPopDensity.Text = "POPULATION DENSITY";
			this.lbAreaEvac = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaEvac
			// 
			this.lbAreaEvac.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaEvac.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaEvac.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaEvac.Name = "lbAreaEvac";
			this.lbAreaEvac.TabIndex = 133;
			this.lbAreaEvac.Text = "AREA EVACUATED";
			this.lbAreaEvacUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaEvacUnits
			// 
			this.lbAreaEvacUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaEvacUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaEvacUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaEvacUnits.Name = "lbAreaEvacUnits";
			this.lbAreaEvacUnits.TabIndex = 132;
			this.lbAreaEvacUnits.Text = "AREA EVACUATED UNITS";
			this.lbAreaAffect = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaAffect
			// 
			this.lbAreaAffect.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaAffect.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaAffect.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaAffect.Name = "lbAreaAffect";
			this.lbAreaAffect.TabIndex = 131;
			this.lbAreaAffect.Text = "AREA AFFECTED";
			this.lbAreaAffectUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaAffectUnits
			// 
			this.lbAreaAffectUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaAffectUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaAffectUnits.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaAffectUnits.Name = "lbAreaAffectUnits";
			this.lbAreaAffectUnits.TabIndex = 130;
			this.lbAreaAffectUnits.Text = "AREA AFFECTED UNITS";
			this.lbMitigatingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMitigatingFactors
			// 
			this.lbMitigatingFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMitigatingFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMitigatingFactors.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbMitigatingFactors.Name = "lbMitigatingFactors";
			this.lbMitigatingFactors.TabIndex = 129;
			this.lbMitigatingFactors.Text = "MITIGATING FACTORS";
			this.lbEquipInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEquipInvolved
			// 
			this.lbEquipInvolved.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEquipInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEquipInvolved.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbEquipInvolved.Name = "lbEquipInvolved";
			this.lbEquipInvolved.TabIndex = 71;
			this.lbEquipInvolved.Text = "EQUIPMENT INVOLVED";
			this.lbContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFactors
			// 
			this.lbContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbContribFactors.Name = "lbContribFactors";
			this.lbContribFactors.TabIndex = 70;
			this.lbContribFactors.Text = "CONTRIBUTING FACTORS";
			this.lbReleaseFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReleaseFloor
			// 
			this.lbReleaseFloor.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReleaseFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReleaseFloor.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbReleaseFloor.Name = "lbReleaseFloor";
			this.lbReleaseFloor.TabIndex = 61;
			this.lbReleaseFloor.Text = "RELEASE FLOOR";
			this.lbReleaseFloor.Visible = false;
			this.lbAreaOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaOrigin
			// 
			this.lbAreaOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaOrigin.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbAreaOrigin.Name = "lbAreaOrigin";
			this.lbAreaOrigin.TabIndex = 60;
			this.lbAreaOrigin.Text = "AREA OF ORIGIN";
			this.lbStreetClass = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetClass
			// 
			this.lbStreetClass.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetClass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStreetClass.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbStreetClass.Name = "lbStreetClass";
			this.lbStreetClass.TabIndex = 53;
			this.lbStreetClass.Text = "STREET CLASS";
			this.lbCauseOfRelease = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCauseOfRelease
			// 
			this.lbCauseOfRelease.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCauseOfRelease.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCauseOfRelease.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbCauseOfRelease.Name = "lbCauseOfRelease";
			this.lbCauseOfRelease.TabIndex = 52;
			this.lbCauseOfRelease.Text = "CAUSE OF RELEASE";
			this.lbGenPropUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenPropUse
			// 
			this.lbGenPropUse.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenPropUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbGenPropUse.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbGenPropUse.Name = "lbGenPropUse";
			this.lbGenPropUse.TabIndex = 27;
			this.lbGenPropUse.Text = "GENERAL PROPERTY USE";
			this.lbSpecPropUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecPropUse
			// 
			this.lbSpecPropUse.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecPropUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSpecPropUse.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.lbSpecPropUse.Name = "lbSpecPropUse";
			this.lbSpecPropUse.TabIndex = 26;
			this.lbSpecPropUse.Text = "SPECIFIC PROPERTY USE";
			this._lbFrameTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmHazReleaseInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmHazReleaseInfo
			// 
			this.frmHazReleaseInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			this.frmHazReleaseInfo.Enabled = true;
			this.frmHazReleaseInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmHazReleaseInfo.Name = "frmHazReleaseInfo";
			this.frmHazReleaseInfo.TabIndex = 95;
			this.frmHazReleaseInfo.Tag = "4";
			this.frmHazReleaseInfo.Visible = false;
			this.lbLocationTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocationTitle
			// 
			this.lbLocationTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocationTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocationTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbLocationTitle.Name = "lbLocationTitle";
			this.lbLocationTitle.TabIndex = 75;
			this.lbLocationTitle.Text = "Location:";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 74;
			this.lbUnit.Text = "E2";
			this.lbIncidentNo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNo
			// 
			this.lbIncidentNo.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNo.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncidentNo.Name = "lbIncidentNo";
			this.lbIncidentNo.TabIndex = 73;
			this.lbIncidentNo.Text = "T002310042";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 72;
			this.lbLocation.Text = "1500 MARTIN LUTHER KING JR WY, TAC";
			this.lbUnitTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnitTitle
			// 
			this.lbUnitTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnitTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnitTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbUnitTitle.Name = "lbUnitTitle";
			this.lbUnitTitle.TabIndex = 25;
			this.lbUnitTitle.Text = "Unit:";
			this.lbIncidentNoTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNoTitle
			// 
			this.lbIncidentNoTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNoTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNoTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbIncidentNoTitle.Name = "lbIncidentNoTitle";
			this.lbIncidentNoTitle.TabIndex = 24;
			this.lbIncidentNoTitle.Text = "Incident #:";
			this._NavButton_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();

            // 
            // cmdSave
            // 
            this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 92;
			this.cmdSave.Text = "Save Report as Complete";
			this.cmdSaveIncomplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveIncomplete
			// 
			this.cmdSaveIncomplete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveIncomplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSaveIncomplete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveIncomplete.Name = "cmdSaveIncomplete";
			this.cmdSaveIncomplete.TabIndex = 93;
			this.cmdSaveIncomplete.Text = "Save Report as Incomplete";
			this.cmdAbandon = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAbandon
			// 
			this.cmdAbandon.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAbandon.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAbandon.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAbandon.Name = "cmdAbandon";
			this.cmdAbandon.TabIndex = 94;
			this.cmdAbandon.Text = "Exit WITHOUT Saving Report";
			this.cmdRemoveResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveResource
			// 
			this.cmdRemoveResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveResource.Enabled = false;
			this.cmdRemoveResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRemoveResource.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveResource.Name = "cmdRemoveResource";
			this.cmdRemoveResource.TabIndex = 66;
			this.cmdRemoveResource.Text = "Remove Resource";
			this.cmdAddResource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddResource
			// 
			this.cmdAddResource.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddResource.Enabled = false;
			this.cmdAddResource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddResource.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddResource.Name = "cmdAddResource";
			this.cmdAddResource.TabIndex = 65;
			this.cmdAddResource.Text = "Add Resource";

			this.cmdRemoveMaterial = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveMaterial
			// 
			this.cmdRemoveMaterial.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveMaterial.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRemoveMaterial.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveMaterial.Name = "cmdRemoveMaterial";
			this.cmdRemoveMaterial.TabIndex = 59;
			this.cmdRemoveMaterial.Text = "Remove Material";
			this.cmdAddMaterial = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddMaterial
			// 
			this.cmdAddMaterial.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddMaterial.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddMaterial.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddMaterial.Name = "cmdAddMaterial";
			this.cmdAddMaterial.TabIndex = 58;
			this.cmdAddMaterial.Text = "Add Material";
			this.cmdMoreChemicals = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMoreChemicals
			// 
			this.cmdMoreChemicals.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMoreChemicals.Enabled = false;
			this.cmdMoreChemicals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdMoreChemicals.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMoreChemicals.Name = "cmdMoreChemicals";
			this.cmdMoreChemicals.TabIndex = 46;
			this.cmdMoreChemicals.Text = "ADD ADDITIONAL CHEMICALS...";
			this.Text = "TFD Incident Reporting System - Report Entry Wizard";
			this.CurrReport = 0;
			this.CurrIncident = 0;
			this.ChemicalsLoaded = 0;
			this.HazmatID = 0;
			this.FirstTime = 0;
			this.SaveChemical = 0;
			this.HazmatDLID = 0;
			optOccurredFirst = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optOccurredFirst[1] = _optOccurredFirst_1;
			optOccurredFirst[0] = _optOccurredFirst_0;
			optOccurredFirst[2] = _optOccurredFirst_2;
			optOccurredFirst[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optOccurredFirst[1].Checked = false;
			optOccurredFirst[1].Enabled = true;
			optOccurredFirst[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optOccurredFirst[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optOccurredFirst[1].Name = "_optOccurredFirst_1";
			optOccurredFirst[1].TabIndex = 13;
			optOccurredFirst[1].Text = "EXPLOSION";
			optOccurredFirst[1].Visible = true;
			optOccurredFirst[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optOccurredFirst[0].Checked = false;
			optOccurredFirst[0].Enabled = true;
			optOccurredFirst[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optOccurredFirst[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optOccurredFirst[0].Name = "_optOccurredFirst_0";
			optOccurredFirst[0].TabIndex = 12;
			optOccurredFirst[0].Text = "FIRE";
			optOccurredFirst[0].Visible = true;
			optOccurredFirst[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optOccurredFirst[2].Checked = false;
			optOccurredFirst[2].Enabled = true;
			optOccurredFirst[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optOccurredFirst[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optOccurredFirst[2].Name = "_optOccurredFirst_2";
			optOccurredFirst[2].TabIndex = 14;
			optOccurredFirst[2].Text = "HAZMAT RELEASE";
			optOccurredFirst[2].Visible = true;
			this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			// 
			// rtxNarration
			// 
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Enabled = true;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 68;
			this.ReportLogID = 0;
			this.CurrFrame = null;
			NavButton = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(5);
			NavButton[0] = _NavButton_0;
			NavButton[1] = _NavButton_1;
			NavButton[2] = _NavButton_2;
			NavButton[3] = _NavButton_3;
			NavButton[4] = _NavButton_4;
			NavButton[0].Name = "_NavButton_0";
			NavButton[0].TabIndex = 176;
			NavButton[1].Name = "_NavButton_1";
			NavButton[1].TabIndex = 177;
			NavButton[2].Name = "_NavButton_2";
			NavButton[2].TabIndex = 178;
			NavButton[3].Name = "_NavButton_3";
			NavButton[3].TabIndex = 179;
			NavButton[4].Name = "_NavButton_4";
			NavButton[4].TabIndex = 180;
			imgMain = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>>(13);
			imgMain[6] = _imgMain_6;
			imgMain[1] = _imgMain_1;
			imgMain[7] = _imgMain_7;
			imgMain[12] = _imgMain_12;
			imgMain[6].Enabled = true;
			imgMain[6].Name = "_imgMain_6";
			imgMain[6].Tag = "6";
			imgMain[6].Visible = true;
			imgMain[1].Enabled = true;
			imgMain[1].Name = "_imgMain_1";
			imgMain[1].Visible = true;
			imgMain[7].Enabled = true;
			imgMain[7].Name = "_imgMain_7";
			imgMain[7].Visible = true;

			imgMain[12].Enabled = true;
			imgMain[12].Name = "_imgMain_12";
			imgMain[12].Visible = true;
			this.ReportSaved = 0;
			optType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optType[3] = _optType_3;
			optType[2] = _optType_2;
			optType[1] = _optType_1;
			optType[0] = _optType_0;
			optType[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optType[3].Checked = false;
			optType[3].Enabled = true;
			optType[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[3].Name = "_optType_3";
			optType[3].TabIndex = 157;
			optType[3].Text = "HAZMAT DRUG LAB WITH RELEASE";
			optType[3].Visible = true;
			optType[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optType[2].Checked = false;
			optType[2].Enabled = true;
			optType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[2].Name = "_optType_2";
			optType[2].TabIndex = 156;
			optType[2].Text = "HAZMAT DRUG LAB";
			optType[2].Visible = true;
			optType[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optType[1].Checked = false;
			optType[1].Enabled = true;
			optType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[1].Name = "_optType_1";
			optType[1].TabIndex = 155;
			optType[1].Text = "HAZMAT TRANSPORTATION RELEASE";
			optType[1].Visible = true;
			optType[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(227, 217, 172);
			optType[0].Checked = false;
			optType[0].Enabled = true;
			optType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			optType[0].Name = "_optType_0";
			optType[0].TabIndex = 154;
			optType[0].Text = "HAZMAT FIXED PROPERTY RELEASE";
			optType[0].Visible = true;
			lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(13);
			lbFrameTitle[6] = _lbFrameTitle_6;
			lbFrameTitle[1] = _lbFrameTitle_1;
			lbFrameTitle[0] = _lbFrameTitle_0;
			lbFrameTitle[7] = _lbFrameTitle_7;
			//lbFrameTitle[3] = _lbFrameTitle_3;
			lbFrameTitle[12] = _lbFrameTitle_12;
			lbFrameTitle[11] = _lbFrameTitle_11;
			lbFrameTitle[4] = _lbFrameTitle_4;
			lbFrameTitle[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[6].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[6].Name = "_lbFrameTitle_6";
			lbFrameTitle[6].TabIndex = 1;
			lbFrameTitle[6].Text = "HAZMAT INCIDENT TYPE";
			lbFrameTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbFrameTitle[1].Name = "_lbFrameTitle_1";
			lbFrameTitle[1].TabIndex = 127;
			lbFrameTitle[1].Text = "HAZMAT REPORT - REPORT STATUS";
			lbFrameTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[0].Name = "_lbFrameTitle_0";
			lbFrameTitle[0].TabIndex = 144;
			lbFrameTitle[0].Text = "HAZMAT INCIDENT SUMMARY ";
			lbFrameTitle[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[7].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[7].Name = "_lbFrameTitle_7";
			lbFrameTitle[7].TabIndex = 125;
			lbFrameTitle[7].Text = "HAZMAT NARRATION";
			//lbFrameTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			//lbFrameTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 18f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			//lbFrameTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			//lbFrameTitle[3].Name = "_lbFrameTitle_3";
			//lbFrameTitle[3].TabIndex = 105;
			//lbFrameTitle[3].Text = "Frame Title";
			lbFrameTitle[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[12].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[12].Name = "_lbFrameTitle_12";
			lbFrameTitle[12].TabIndex = 23;
			lbFrameTitle[12].Text = "HAZMAT DRUG LAB INFORMATION";
			lbFrameTitle[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[11].ForeColor = UpgradeHelpers.Helpers.Color.Black;
			lbFrameTitle[11].Name = "_lbFrameTitle_11";
			lbFrameTitle[11].TabIndex = 3;
			lbFrameTitle[11].Text = "CHEMICAL DETAIL";
			lbFrameTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbFrameTitle[4].Name = "_lbFrameTitle_4";
			lbFrameTitle[4].TabIndex = 2;
			lbFrameTitle[4].Text = "HAZMAT RELEASE INFORMATION";
			this.Name = "TFDIncident.wzdHazmat";
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNavMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel NavBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstActionsTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHazmatIDSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmHazmatType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNumberTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSIncidentNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReportByTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSReportedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSEmployeeID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSCurrReportType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmReportStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstOutsideResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboResourceUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOutsideResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDisposition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDispOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMaterialUsed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboDrugLabType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtQuantity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMaterialUsed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDrugLabType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireServiceMaterialTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbQuantity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmDrugLab { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAmountReleasedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCommonChemicals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboChemicalName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboUN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbChemicalID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbChemicalName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCommonChemicals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEstContainerCapacity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboContainerCapacityUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboContainerType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSecondaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrimaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPhysicalStateReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPhysicalStateStored { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtEstAmountReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSecondReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPrimaryReleasedInto { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyStateReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyStateStored { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEstContainerCap { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContainerCapUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContainerType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEstAmountReleased { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmChemicalDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBuildingsEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPeopleEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPopulationDensity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaEvacuatedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaAffectedUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAreaEvacuated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMitigatingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optOccurredFirst_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstEquipmentInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContributingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCauseOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStreetClass { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGeneralPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecificPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPeopleEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBldgEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPopDensity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaEvac { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaEvacUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaAffect { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaAffectUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMitigatingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEquipInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReleaseFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetClass { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCauseOfRelease { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenPropUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecPropUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmHazReleaseInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocationTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnitTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNoTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveIncomplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAbandon { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddResource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveMaterial { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddMaterial { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMoreChemicals { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ChemicalsLoaded { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HazmatID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SaveChemical { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HazmatDLID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optOccurredFirst { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportLogID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel CurrFrame { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> NavButton { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel> imgMain { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportSaved { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		public void OntxtQuantity_TextChanged()
		{
			if ( _txtQuantity_TextChanged != null )
				_txtQuantity_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtQuantity_TextChanged;

		public void OntxtEstContainerCapacity_TextChanged()
		{
			if ( _txtEstContainerCapacity_TextChanged != null )
				_txtEstContainerCapacity_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtEstContainerCapacity_TextChanged;

		public void OntxtEstAmountReleased_TextChanged()
		{
			if ( _txtEstAmountReleased_TextChanged != null )
				_txtEstAmountReleased_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtEstAmountReleased_TextChanged;

		public void OntxtBuildingsEvacuated_TextChanged()
		{
			if ( _txtBuildingsEvacuated_TextChanged != null )
				_txtBuildingsEvacuated_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBuildingsEvacuated_TextChanged;

		public void OntxtPeopleEvacuated_TextChanged()
		{
			if ( _txtPeopleEvacuated_TextChanged != null )
				_txtPeopleEvacuated_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPeopleEvacuated_TextChanged;

		public void OntxtAreaAffected_TextChanged()
		{
			if ( _txtAreaAffected_TextChanged != null )
				_txtAreaAffected_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAreaAffected_TextChanged;

		public void OntxtAreaEvacuated_TextChanged()
		{
			if ( _txtAreaEvacuated_TextChanged != null )
				_txtAreaEvacuated_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAreaEvacuated_TextChanged;

		public void OntxtReleaseFloor_TextChanged()
		{
			if ( _txtReleaseFloor_TextChanged != null )
				_txtReleaseFloor_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtReleaseFloor_TextChanged;
	}

}