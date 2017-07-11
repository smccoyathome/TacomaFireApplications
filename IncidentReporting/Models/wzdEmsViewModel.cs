using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.wzdEms))]
	public class wzdEmsViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, ((UpgradeHelpers.Helpers
					.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 446;
			this.Label23.Text = "Wizard Navigation Bar";
			this.NavBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// NavBar
			// 
			this.NavBar.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavBar.Name = "NavBar";
			this.cboTransportBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportBy
			// 
			this.cboTransportBy.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboTransportBy.Name = "cboTransportBy";
			this.cboTransportBy.TabIndex = 238;
			this.cboTransportBy.Text = "cboTransportBy";
			this.cboTransportTo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportTo
			// 
			this.cboTransportTo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportTo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportTo.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboTransportTo.Name = "cboTransportTo";
			this.cboTransportTo.TabIndex = 239;
			this.cboTransportTo.Text = "cboTransportTo";
			this.cboTransportFrom = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportFrom
			// 
			this.cboTransportFrom.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportFrom.Enabled = false;
			this.cboTransportFrom.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportFrom.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboTransportFrom.Name = "cboTransportFrom";
			this.cboTransportFrom.TabIndex = 240;
			this.cboTransportFrom.Text = "cboTransportFrom";
			this.txtMileage = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMileage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMileage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMileage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMileage.Name = "txtMileage";
			this.txtMileage.TabIndex = 241;
			this.txtMileage.Text = "txtMileage";
			this.cboHospitalChosenBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHospitalChosenBy
			// 
			this.cboHospitalChosenBy.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHospitalChosenBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboHospitalChosenBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboHospitalChosenBy.Name = "cboHospitalChosenBy";
			this.cboHospitalChosenBy.TabIndex = 243;
			this.cboHospitalChosenBy.Text = "cboHospitalChosenBy";
			this.cboBaseStationContact = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBaseStationContact
			// 
			this.cboBaseStationContact.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBaseStationContact.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBaseStationContact.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboBaseStationContact.Name = "cboBaseStationContact";
			this.cboBaseStationContact.TabIndex = 234;
			this.cboBaseStationContact.Text = "cboBaseStationContact";
			this._optMDorRN_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optMDorRN_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optMDorRN_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._lbTrans_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmTransportInfo
            // 
            this.frmTransportInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmTransportInfo.Enabled = true;
            this.frmTransportInfo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmTransportInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmTransportInfo.Name = "frmTransportInfo";
			this.frmTransportInfo.TabIndex = 232;
			this.frmTransportInfo.Tag = "7";
            this.frmTransportInfo.Visible = false;

			this._cboRoute_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRate_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboSite_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRate_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboSite_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRate_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboSite_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRate_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboSite_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRate_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboSite_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._lbTreatment_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

			this.vaTabPro2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.vaTabPro2.Name = "vaTabPro2";
			this.vaTabPro2.SelectedIndex = 0;
			this.vaTabPro2.TabIndex = 332;
            
            this.txtExtricationTime = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExtricationTime.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtExtricationTime.Name = "txtExtricationTime";
			this.txtExtricationTime.TabIndex = 334;
			this.txtExtricationTime.Text = "txtExtricationTime";
			this._lbTreatment_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmExtrication = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmExtrication
			// 
			this.frmExtrication.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmExtrication.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmExtrication.Name = "frmExtrication";
			this.frmExtrication.TabIndex = 393;
			this.lstMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMedications
			// 
			this.lstMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstMedications.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstMedications.Name = "lstMedications";
			this.lstMedications.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstMedications.TabIndex = 338;
			this.cboMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMedications
			// 
			this.cboMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMedications.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMedications.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboMedications.Name = "cboMedications";
			this.cboMedications.TabIndex = 335;
			this.cboMedications.Text = "cboMedications";
			this.txtDosage = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtDosage.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDosage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDosage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtDosage.Name = "txtDosage";
			this.txtDosage.TabIndex = 336;
			this.txtDosage.Text = "txtDosage";
			this.cboTreatmentAuth = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTreatmentAuth
			// 
			this.cboTreatmentAuth.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboTreatmentAuth.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTreatmentAuth.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboTreatmentAuth.Name = "cboTreatmentAuth";
			this.cboTreatmentAuth.TabIndex = 333;
			this.cboTreatmentAuth.Text = "cboTreatmentAuthorization";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 391;
			this.Label1.Text = "IV LINES";
			this._lbTreatment_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTreatment_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.shpMedications = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.shpMedications.Enabled = false;
			this.shpMedications.Name = "shpMedications";
			this.shpMedications.TabIndex = 394;

            // 
            // frmTreatmentInfo
            // 
            this.frmTreatmentInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmTreatmentInfo.Enabled = true;
            this.frmTreatmentInfo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmTreatmentInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmTreatmentInfo.Name = "frmTreatmentInfo";
			this.frmTreatmentInfo.TabIndex = 229;
            this.frmTreatmentInfo.Visible = false;

			this._optArrestToShock_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToShock = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToShock
			// 
			this.frmArrestToShock.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmArrestToShock.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToShock.Name = "frmArrestToShock";
			this.frmArrestToShock.TabIndex = 0;
			this._optArrestToALS_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToALS = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToALS
			// 
			this.frmArrestToALS.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmArrestToALS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToALS.Name = "frmArrestToALS";
			this.frmArrestToALS.TabIndex = 225;
			this._optArrestToCPR_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToCPR
			// 
			this.frmArrestToCPR.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmArrestToCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToCPR.Name = "frmArrestToCPR";
			this.frmArrestToCPR.TabIndex = 220;
			this.lstCPRPerformedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstCPRPerformedBy
			// 
			this.lstCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstCPRPerformedBy.Name = "lstCPRPerformedBy";
			this.lstCPRPerformedBy.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstCPRPerformedBy.TabIndex = 145;
			this.cboCPRPerformedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCPRPerformedBy
			// 
			this.cboCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCPRPerformedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboCPRPerformedBy.Name = "cboCPRPerformedBy";
			this.cboCPRPerformedBy.TabIndex = 141;
			this.cboCPRPerformedBy.Text = "cboCPRPerformedBy";
			this.Shape2 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape2.Enabled = false;
			this.Shape2.Name = "Shape2";
			this.Shape2.TabIndex = 398;
			this._lbCPR_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbCPR_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbCPR_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbCPRPatientInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCPRPatientInfo
			// 
			this.lbCPRPatientInfo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbCPRPatientInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbCPRPatientInfo.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbCPRPatientInfo.Name = "lbCPRPatientInfo";
			this.lbCPRPatientInfo.TabIndex = 221;
			this.lbCPRPatientInfo.Text = "CPR PATIENT INFORMATION";
			this._lbCPR_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmCPR
            // 
            this.frmCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmCPR.Enabled = true;
            this.frmCPR.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmCPR.Name = "frmCPR";
			this.frmCPR.TabIndex = 217;
            this.frmCPR.Visible = false;

            // 
            // lstPriorMedicalHistory
            // 
            this.lstPriorMedicalHistory = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            this.lstPriorMedicalHistory.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstPriorMedicalHistory.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstPriorMedicalHistory.Name = "lstPriorMedicalHistory";
			this.lstPriorMedicalHistory.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstPriorMedicalHistory.TabIndex = 39;
			this.lstPossibleFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPossibleFactors
			// 
			this.lstPossibleFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstPossibleFactors.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstPossibleFactors.Name = "lstPossibleFactors";
			this.lstPossibleFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstPossibleFactors.TabIndex = 40;
			this.cboPatientAgeUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPatientAgeUnits
			// 
			this.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPatientAgeUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboPatientAgeUnits.Name = "cboPatientAgeUnits";
			this.cboPatientAgeUnits.TabIndex = 32;
			this.cboPatientAgeUnits.Text = "cboPatientAgeUnits";
			this.txtPatientAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPatientAge.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPatientAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtPatientAge.Name = "txtPatientAge";
			this.txtPatientAge.TabIndex = 31;
			this.txtPatientAge.Text = "txtPatientAge";
			this.txtZipCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZipCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtZipCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtZipCode.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtZipCode.Name = "txtZipCode";
			this.txtZipCode.TabIndex = 28;
			this.txtZipCode.Text = "txtZipCode";
			this._optEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHomePhone.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtHomePhone.Name = "txtHomePhone";
			this.txtHomePhone.TabIndex = 29;
			this.txtHomePhone.Text = "txtHomePhone";
			this.txtBillingAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBillingAddress.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBillingAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBillingAddress.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBillingAddress.Name = "txtBillingAddress";
			this.txtBillingAddress.TabIndex = 25;
			this.txtBillingAddress.Text = "txtBillingAddress";
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 26;
			this.txtCity.Text = "txtCity";
			this.cboState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboState
			// 
			this.cboState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboState.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboState.Name = "cboState";
			this.cboState.TabIndex = 27;
			this.cboState.Text = "cboState";
			this.txtFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFirstName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.TabIndex = 21;
			this.txtFirstName.Text = "txtFirstName";
			this.txtLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtLastName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.TabIndex = 22;
			this.txtLastName.Text = "txtLastName";
			this.txtMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMI.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtMI.Name = "txtMI";
			this.txtMI.TabIndex = 23;
			this.txtMI.Text = "txtMI";
			this.cboRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRace
			// 
			this.cboRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRace.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboRace.Name = "cboRace";
			this.cboRace.TabIndex = 35;
			this.cboRace.Text = "cboRace";
			this.mskBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.mskBirthdate.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.mskBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.mskBirthdate.Mask = "##/##/####";
			this.mskBirthdate.Name = "mskBirthdate";
			this.mskBirthdate.TabIndex = 30;
			this.mskSSN = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.mskSSN.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.mskSSN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.mskSSN.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.mskSSN.Mask = "###-##-####";
			this.mskSSN.Name = "mskSSN";
			this.mskSSN.TabIndex = 24;
			this._lbPInfo_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbBillingAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBillingAddress
			// 
			this.lbBillingAddress.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBillingAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbBillingAddress.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbBillingAddress.Name = "lbBillingAddress";
			this.lbBillingAddress.TabIndex = 213;
			this.lbBillingAddress.Text = "BILLING ADDRESS";
			this._lbPInfo_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmPatientInformation
            // 
            this.frmPatientInformation = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmPatientInformation.Enabled = true;
            this.frmPatientInformation.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmPatientInformation.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmPatientInformation.Name = "frmPatientInformation";
			this.frmPatientInformation.TabIndex = 187;
			//this.frmPatientInformation.Tag = "3";
            this.frmPatientInformation.Visible = false;

			this.txtBMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBMI.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBMI.Name = "txtBMI";
			this.txtBMI.TabIndex = 5;
			this.txtBMI.Text = "txtMI";
			this.txtBLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBLastName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBLastName.Name = "txtBLastName";
			this.txtBLastName.TabIndex = 4;
			this.txtBLastName.Text = "txtBLastName";
			this.txtBFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBFirstName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBFirstName.Name = "txtBFirstName";
			this.txtBFirstName.TabIndex = 3;
			this.txtBFirstName.Text = "txtBFirstName";
			this.txtBHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBHomePhone.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBHomePhone.Name = "txtBHomePhone";
			this.txtBHomePhone.TabIndex = 6;
			this.txtBHomePhone.Text = "txtBHomePhone";
			this.cboServiceProvided = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboServiceProvided
			// 
			this.cboServiceProvided.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboServiceProvided.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboServiceProvided.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboServiceProvided.Name = "cboServiceProvided";
			this.cboServiceProvided.TabIndex = 15;
			this.cboServiceProvided.Text = "cboServiceProvided";
			this._optEMSEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEMSEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEMSGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEMSGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboEMSRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEMSRace
			// 
			this.cboEMSRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboEMSRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEMSRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEMSRace.Name = "cboEMSRace";
			this.cboEMSRace.TabIndex = 12;
			this.cboEMSRace.Text = "cboEMSRace";
			this.cboAgeUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAgeUnits
			// 
			this.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAgeUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboAgeUnits.Name = "cboAgeUnits";
			this.cboAgeUnits.TabIndex = 9;
			this.cboAgeUnits.Text = "cboAgeUnits";
			this.txtAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAge.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAge.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAge.Name = "txtAge";
			this.txtAge.TabIndex = 8;
			this.txtAge.Text = "txtAge";
			this.txtBBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBBirthdate.Mask = "##/##/####";
			this.txtBBirthdate.Name = "txtBBirthdate";
			this.txtBBirthdate.TabIndex = 7;
			this._lbPInfo_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbBasic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbBasic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbBasic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbBasic_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmNoExamInfo
            // 
            this.frmNoExamInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmNoExamInfo.Enabled = true;
            this.frmNoExamInfo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmNoExamInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNoExamInfo.Name = "frmNoExamInfo";
			this.frmNoExamInfo.TabIndex = 181;
            this.frmNoExamInfo.Visible = false;

            // 
            // lstTrauma3
            // 
            this.lstTrauma3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            this.lstTrauma3.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstTrauma3.Name = "lstTrauma3";
			this.lstTrauma3.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstTrauma3.TabIndex = 166;
			this.lstTrauma2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrauma2
			// 
			this.lstTrauma2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstTrauma2.Name = "lstTrauma2";
			this.lstTrauma2.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstTrauma2.TabIndex = 165;
			this.lstTrauma1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrauma1
			// 
			this.lstTrauma1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstTrauma1.Name = "lstTrauma1";
			this.lstTrauma1.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstTrauma1.TabIndex = 164;
			this.cboProtectiveDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboProtectiveDevice
			// 
			this.cboProtectiveDevice.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboProtectiveDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboProtectiveDevice.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboProtectiveDevice.Name = "cboProtectiveDevice";
			this.cboProtectiveDevice.TabIndex = 162;
			this.cboProtectiveDevice.Text = "cboProtectiveDevice";
			this.cboPatientLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPatientLocation
			// 
			this.cboPatientLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPatientLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPatientLocation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboPatientLocation.Name = "cboPatientLocation";
			this.cboPatientLocation.TabIndex = 163;
			this.cboPatientLocation.Text = "cboPatientLocation";
			this.txtTraumaID = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTraumaID.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTraumaID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtTraumaID.Name = "txtTraumaID";
			this.txtTraumaID.TabIndex = 161;
			this.txtTraumaID.Text = "txtTraumaID";
			this._lbTrans_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbTrans_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmTrauma = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            // 
            // frmTrauma
            // 
            this.frmTrauma = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmTrauma.Enabled = true;
            this.frmTrauma.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmTrauma.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmTrauma.Name = "frmTrauma";
			this.frmTrauma.TabIndex = 172;
            this.frmTrauma.Visible = false;

			this.txtOtherBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOtherBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOtherBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOtherBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtOtherBLSProcedures.Name = "txtOtherBLSProcedures";
			this.txtOtherBLSProcedures.TabIndex = 409;
			this.txtOtherBLSProcedures.Text = "txtOtherBLSProcedures";
			this.txtOtherBLSProcedures.Visible = false;
			this.lstBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstBLSProcedures
			// 
			this.lstBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstBLSProcedures.Name = "lstBLSProcedures";
			this.lstBLSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstBLSProcedures.TabIndex = 412;
			this.cboBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBLSProcedures
			// 
			this.cboBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboBLSProcedures.Name = "cboBLSProcedures";
			this.cboBLSProcedures.TabIndex = 408;
			this.cboBLSProcedures.Text = "cboBLSProcedures";
			this.lstBLSPersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstBLSPersonnel
			// 
			this.lstBLSPersonnel.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstBLSPersonnel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstBLSPersonnel.Name = "lstBLSPersonnel";
			this.lstBLSPersonnel.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstBLSPersonnel.TabIndex = 410;
			this._lbProcs_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbProcs_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbProcs_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboALSProcedures
			// 
			this.cboALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboALSProcedures.Name = "cboALSProcedures";
			this.cboALSProcedures.TabIndex = 414;
			this.cboALSProcedures.Text = "cboALSProcedures";
			this.lstALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstALSProcedures
			// 
			this.lstALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstALSProcedures.Name = "lstALSProcedures";
			this.lstALSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstALSProcedures.TabIndex = 420;
			this.txtAttempts = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAttempts.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAttempts.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAttempts.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAttempts.Name = "txtAttempts";
			this.txtAttempts.TabIndex = 415;
			this.txtAttempts.Text = "txtAttempts";
			this._lbProcs_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboALSPersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboALSPersonnel
			// 
			this.cboALSPersonnel.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboALSPersonnel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboALSPersonnel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboALSPersonnel.Name = "cboALSPersonnel";
			this.cboALSPersonnel.TabIndex = 418;
			this.cboALSPersonnel.Text = "cboALSPersonnel";
			this.txtOtherALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOtherALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOtherALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOtherALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtOtherALSProcedures.Name = "txtOtherALSProcedures";
			this.txtOtherALSProcedures.TabIndex = 417;
			this.txtOtherALSProcedures.Text = "txtOtherALSProcedures";
			this.txtOtherALSProcedures.Visible = false;
			this._lbProcs_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbProcs_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbProcs_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmProceduresPerformed
            // 
            this.frmProceduresPerformed = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmProceduresPerformed.Enabled = true;
            this.frmProceduresPerformed.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmProceduresPerformed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmProceduresPerformed.Name = "frmProceduresPerformed";
			this.frmProceduresPerformed.TabIndex = 140;
            this.frmProceduresPerformed.Visible = false;

			this._txtPerOxy_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboVitalsPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboECG_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboECG_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboECG_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboECG_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboECG_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulse_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtTime_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbVital_70 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_55 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_69 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_54 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_59 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_58 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_57 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_56 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_61 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_64 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_68 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_67 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_66 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_65 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_62 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_63 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_60 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_74 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_73 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_72 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVital_71 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.tabVitals = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.tabVitals.Name = "tabVitals";
			this.tabVitals.SelectedIndex = 0;
			this.tabVitals.TabIndex = 265;
			this._optSeverity_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optSeverity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optSeverity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstSecondaryIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSecondaryIllness
			// 
			this.lstSecondaryIllness.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstSecondaryIllness.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lstSecondaryIllness.Name = "lstSecondaryIllness";
			this.lstSecondaryIllness.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstSecondaryIllness.TabIndex = 46;
			this._optLevelOfConsciouness_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLevelOfConsciouness_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLevelOfConsciouness_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optPupils_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optPupils_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboPrimaryIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrimaryIllness
			// 
			this.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPrimaryIllness.Enabled = false;
			this.cboPrimaryIllness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPrimaryIllness.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboPrimaryIllness.Name = "cboPrimaryIllness";
			this.cboPrimaryIllness.TabIndex = 45;
			this.cboPrimaryIllness.Text = "cboPrimaryIllness";
			this.cboBodyPart = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBodyPart
			// 
			this.cboBodyPart.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBodyPart.Enabled = false;
			this.cboBodyPart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboBodyPart.Name = "cboBodyPart";
			this.cboBodyPart.TabIndex = 43;
			this.cboBodyPart.Text = "cboBodyPart";
			this.cboInjuryType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryType
			// 
			this.cboInjuryType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryType.Enabled = false;
			this.cboInjuryType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboInjuryType.Name = "cboInjuryType";
			this.cboInjuryType.TabIndex = 42;
			this.cboInjuryType.Text = "cboInjuryType";
			this._lbExam_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this._lbExam_BodyPart = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            this.cboMechCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMechCode
			// 
			this.cboMechCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMechCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMechCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboMechCode.Name = "cboMechCode";
			this.cboMechCode.TabIndex = 41;
			this.cboMechCode.Text = "cboMechCode";
			this.lbExamDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExamDate
			// 
			this.lbExamDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExamDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExamDate.Name = "lbExamDate";
			this.lbExamDate.TabIndex = 392;
			this.lbExamDate.Visible = false;
			this._lbVitals_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbExam_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmExamInfo
            // 
            this.frmExamInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmExamInfo.Enabled = true;
            this.frmExamInfo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmExamInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmExamInfo.Name = "frmExamInfo";
			this.frmExamInfo.TabIndex = 137;
            this.frmExamInfo.Visible = false;

			this._optActionTaken_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optActionTaken_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lbReptNumMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReptNumMessage
			// 
			this.lbReptNumMessage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbReptNumMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8F, ((
						UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbReptNumMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbReptNumMessage.Name = "lbReptNumMessage";
			this.lbReptNumMessage.TabIndex = 447;
			this.lbReptNumMessage.Text = "First Patient Report";
			this._imgMain_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this._lbFrameTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmActionTaken
            // 
            this.frmActionTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmActionTaken.Enabled = true;
            this.frmActionTaken.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmActionTaken.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmActionTaken.Name = "frmActionTaken";
			this.frmActionTaken.TabIndex = 135;
            this.frmActionTaken.Visible = true;

			this.txtIncidentZipcode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtIncidentZipcode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtIncidentZipcode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtIncidentZipcode.Name = "txtIncidentZipcode";
			this.txtIncidentZipcode.TabIndex = 168;
			this.cboResearchCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboResearchCode
			// 
			this.cboResearchCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboResearchCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboResearchCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboResearchCode.Name = "cboResearchCode";
			this.cboResearchCode.TabIndex = 170;
			this.cboResearchCode.Text = "cboResearchCode";
			this.cboIncidentSetting = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentSetting
			// 
			this.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncidentSetting.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboIncidentSetting.Name = "cboIncidentSetting";
			this.cboIncidentSetting.TabIndex = 169;
			this.cboIncidentSetting.Text = "cboIncidentSetting";
			this.cboIncidentLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentLocation
			// 
			this.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncidentLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboIncidentLocation.Name = "cboIncidentLocation";
			this.cboIncidentLocation.TabIndex = 167;
			this.cboIncidentLocation.Text = "cboIncidentLocation";
			this._lbNarr_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbNarr_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbNarr_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbNarr_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbFrameTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmNarration
            // 
            this.frmNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmNarration.Enabled = true;
            this.frmNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNarration.Name = "frmNarration";
			this.frmNarration.TabIndex = 133;
			this.frmNarration.Tag = "4";
            this.frmNarration.Visible = false;

            // 
            // lstMessage
            // 
            this.lstMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            this.lstMessage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lstMessage.Name = "lstMessage";
			this.lstMessage.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstMessage.TabIndex = 443;
			this._lbReport_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbReport_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbRSCurrReportType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSCurrReportType
			// 
			this.lbRSCurrReportType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSCurrReportType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSCurrReportType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSCurrReportType.Name = "lbRSCurrReportType";
			this.lbRSCurrReportType.TabIndex = 262;
			this.lbRSCurrReportType.Text = "Exam/Assist/Transport - EMS Patient Contact Report";
			this._lbReport_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbRSShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSShift
			// 
			this.lbRSShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSShift.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSShift.Name = "lbRSShift";
			this.lbRSShift.TabIndex = 260;
			this.lbRSShift.Text = "D Shift";
			this.lbRSUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSUnit
			// 
			this.lbRSUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSUnit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSUnit.Name = "lbRSUnit";
			this.lbRSUnit.TabIndex = 259;
			this.lbRSUnit.Text = "E10";
			this.lbRSPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSPosition
			// 
			this.lbRSPosition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSPosition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSPosition.Name = "lbRSPosition";
			this.lbRSPosition.TabIndex = 258;
			this.lbRSPosition.Text = "Officer";
			this.lbRSEmployeeID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSEmployeeID
			// 
			this.lbRSEmployeeID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSEmployeeID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSEmployeeID.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSEmployeeID.Name = "lbRSEmployeeID";
			this.lbRSEmployeeID.TabIndex = 257;
			this.lbRSEmployeeID.Text = "02341";
			this.lbRSReportedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSReportedBy
			// 
			this.lbRSReportedBy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSReportedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSReportedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSReportedBy.Name = "lbRSReportedBy";
			this.lbRSReportedBy.TabIndex = 256;
			this.lbRSReportedBy.Text = "Hilderbrand, Robert";
			this._lbReport_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbRSIncidentNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSIncidentNumber
			// 
			this.lbRSIncidentNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSIncidentNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbRSIncidentNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbRSIncidentNumber.Name = "lbRSIncidentNumber";
			this.lbRSIncidentNumber.TabIndex = 254;
			this.lbRSIncidentNumber.Text = "001230056";
			this._lbReport_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this._lbFrameTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmReportStatus
            // 
            this.frmReportStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            this.frmReportStatus.Enabled = true;
            this.frmReportStatus.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmReportStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmReportStatus.Name = "frmReportStatus";
			this.frmReportStatus.TabIndex = 1;
			this.frmReportStatus.Tag = "1";
            this.frmReportStatus.Visible = false;


            // 
            // lbLocationTitle
            // 
            this.lbLocationTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbLocationTitle.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbLocationTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocationTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbLocationTitle.Name = "lbLocationTitle";
			this.lbLocationTitle.TabIndex = 132;
			this.lbLocationTitle.Text = "Location:";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 131;
			this.lbLocation.Text = "1200 Martin Luther King Jr Wy, TAC";
			this.lbIncidentNo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNo
			// 
			this.lbIncidentNo.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbIncidentNo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncidentNo.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncidentNo.Name = "lbIncidentNo";
			this.lbIncidentNo.TabIndex = 130;
			this.lbIncidentNo.Text = "T002410042";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 129;
			this.lbUnit.Text = "E4";
			this.lbUnitTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnitTitle
			// 
			this.lbUnitTitle.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbUnitTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbUnitTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbUnitTitle.Name = "lbUnitTitle";
			this.lbUnitTitle.TabIndex = 20;
			this.lbUnitTitle.Text = "Unit:";
			this.lbIncidentNoTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNoTitle
			// 
			this.lbIncidentNoTitle.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbIncidentNoTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbIncidentNoTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lbIncidentNoTitle.Name = "lbIncidentNoTitle";
			this.lbIncidentNoTitle.TabIndex = 19;
			this.lbIncidentNoTitle.Text = "Incident #:";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.TabIndex = 445;
			this._NavButton_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdRemoveMedication = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveMedication
			// 
			this.cmdRemoveMedication.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveMedication.Enabled = false;
			this.cmdRemoveMedication.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveMedication.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveMedication.Name = "cmdRemoveMedication";
			this.cmdRemoveMedication.TabIndex = 339;
			this.cmdRemoveMedication.Text = "REMOVE MEDICATION";
			this.cmdAddMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddMedications
			// 
			this.cmdAddMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddMedications.Enabled = false;
			this.cmdAddMedications.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddMedications.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddMedications.Name = "cmdAddMedications";
			this.cmdAddMedications.TabIndex = 337;
			this.cmdAddMedications.Text = "ADD MEDICATION";
			this.cmdClear3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear3
			// 
			this.cmdClear3.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear3.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear3.Name = "cmdClear3";
			this.cmdClear3.TabIndex = 397;
			this.cmdClear3.Text = "Clear";
			this.cmdClear2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear2
			// 
			this.cmdClear2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear2.Name = "cmdClear2";
			this.cmdClear2.TabIndex = 396;
			this.cmdClear2.Text = "Clear";
			this.cmdClear1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear1
			// 
			this.cmdClear1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear1.Name = "cmdClear1";
			this.cmdClear1.TabIndex = 395;
			this.cmdClear1.Text = "Clear";
			this.cmdRemoveCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveCPR
			// 
			this.cmdRemoveCPR.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveCPR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveCPR.Name = "cmdRemoveCPR";
			this.cmdRemoveCPR.TabIndex = 146;
			this.cmdRemoveCPR.Text = "REMOVE CPR PERFORMER";
			this.cmdAddCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddCPR
			// 
			this.cmdAddCPR.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddCPR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddCPR.Name = "cmdAddCPR";
			this.cmdAddCPR.TabIndex = 144;
			this.cmdAddCPR.Text = "ADD CPR PERFORMER";
			this.cmdAddBLS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddBLS
			// 
			this.cmdAddBLS.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddBLS.Enabled = false;
			this.cmdAddBLS.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddBLS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddBLS.Name = "cmdAddBLS";
			this.cmdAddBLS.TabIndex = 411;
			this.cmdAddBLS.Text = "ADD BLS PROCEDURES";
			this.cmdRemoveBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveBLSProcedures
			// 
			this.cmdRemoveBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveBLSProcedures.Enabled = false;
			this.cmdRemoveBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveBLSProcedures.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveBLSProcedures.Name = "cmdRemoveBLSProcedures";
			this.cmdRemoveBLSProcedures.TabIndex = 413;
			this.cmdRemoveBLSProcedures.Text = "REMOVE BLS PROCEDURES";
			this.chkCPRPerformed = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCPRPerformed
			// 
			this.chkCPRPerformed.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkCPRPerformed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCPRPerformed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkCPRPerformed.Name = "chkCPRPerformed";
			this.chkCPRPerformed.TabIndex = 407;
			this.chkCPRPerformed.Text = "CPR Performed?";
			this.cmdAddALS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddALS
			// 
			this.cmdAddALS.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddALS.Enabled = false;
			this.cmdAddALS.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddALS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddALS.Name = "cmdAddALS";
			this.cmdAddALS.TabIndex = 419;
			this.cmdAddALS.Text = "ADD ALS PROCEDURES";
			this.cmdRemoveALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveALSProcedures
			// 
			this.cmdRemoveALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveALSProcedures.Enabled = false;
			this.cmdRemoveALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveALSProcedures.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveALSProcedures.Name = "cmdRemoveALSProcedures";
			this.cmdRemoveALSProcedures.TabIndex = 421;
			this.cmdRemoveALSProcedures.Text = "REMOVE ALS PROCEDURES";
			this._chkPalp_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkNoVitals = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkNoVitals
			// 
			this.chkNoVitals.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkNoVitals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkNoVitals.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.chkNoVitals.Name = "chkNoVitals";
			this.chkNoVitals.TabIndex = 448;
			this.chkNoVitals.Text = "Unable to Take Vitals ...see narrative";
			this.chkMajTrauma = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkMajTrauma
			// 
			this.chkMajTrauma.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkMajTrauma.Enabled = false;
			this.chkMajTrauma.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkMajTrauma.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkMajTrauma.Name = "chkMajTrauma";
			this.chkMajTrauma.TabIndex = 44;
			this.chkMajTrauma.Text = "MAJOR TRAUMA?";

			this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			// 
			// rtxNarration
			// 
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 171;
			this.rtxNarration.Text = "rtxNarration";
			this.FDCaresBtn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// FDCaresBtn
			// 
			this.FDCaresBtn.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(117)))), ((int)(((byte)(103)))));
			this.FDCaresBtn.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.FDCaresBtn.Name = "FDCaresBtn";
			this.FDCaresBtn.TabIndex = 460;
			this.FDCaresBtn.Text = "FDCares Referral";
			this.cmdAbandon = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAbandon
			// 
			this.cmdAbandon.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAbandon.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAbandon.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAbandon.Name = "cmdAbandon";
			this.cmdAbandon.TabIndex = 17;
			this.cmdAbandon.Text = "Exit WITHOUT Saving Report";
			this.cmdSaveIncomplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveIncomplete
			// 
			this.cmdSaveIncomplete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveIncomplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSaveIncomplete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveIncomplete.Name = "cmdSaveIncomplete";
			this.cmdSaveIncomplete.TabIndex = 16;
			this.cmdSaveIncomplete.Text = "Save Report as Incomplete";
			this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSave
			// 
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 2;
			this.cmdSave.Text = "Save Report as Complete";
			this.tabPage1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Text = "First";
			this.tabPage2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Text = "Second";
			this.tabPage3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Text = "Third";
			this.tabPage4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Text = "Fourth";
			this.tabPage5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Text = "More.";
            this.tabLine1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
            this.tabLine1.Name = "tabLine1";
            this.tabLine1.Text = "1st Line";
            this.tabLine2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
            this.tabLine2.Name = "tabLine2";
            this.tabLine2.Text = "2nd Line";
            this.tabLine3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
            this.tabLine3.Name = "tabLine3";
            this.tabLine3.Text = "3rd Line";
            this.tabLine4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
            this.tabLine4.Name = "tabLine1";
            this.tabLine4.Text = "4th Line";
            this.Text = "TFD Incident Reporting System - Report Entry Wizard";
			this.FirstTime = 0;
			this.CurrReport = 0;
			this.CurrIncident = 0;
			this.IVPerformed = 0;
			this.PatientID = 0;
			this.EMSType = 0;
            this.optSeverity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			this.optSeverity[2] = _optSeverity_2;
			this.optSeverity[1] = _optSeverity_1;
			this.optSeverity[0] = _optSeverity_0;
			this.optSeverity[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optSeverity[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optSeverity[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optSeverity[2].Name = "_optSeverity_2";
			this.optSeverity[2].TabIndex = 128;
			this.optSeverity[2].Text = "NON-URGENT";
			this.optSeverity[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optSeverity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optSeverity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optSeverity[1].Name = "_optSeverity_1";
            this.optSeverity[1].TabIndex = 127;
			this.optSeverity[1].Text = "URGENT";
			this.optSeverity[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optSeverity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optSeverity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optSeverity[0].Name = "_optSeverity_0";
			this.optSeverity[0].TabIndex = 126;
			this.optSeverity[0].Text = "FULL ARREST";
			this.ExtricationPerformed = 0;
			this.ActionTaken = 0;
			this.DispatchedAs = "";
			this.ReportSaved = 0;
			this.NarrationRequired = 0;
            this.optEMSGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			this.optEMSGender[0] = _optEMSGender_0;
			this.optEMSGender[1] = _optEMSGender_1;
			this.optEMSGender[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optEMSGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optEMSGender[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optEMSGender[0].Name = "_optEMSGender_0";
            this.optEMSGender[0].TabIndex = 10;
			this.optEMSGender[0].Text = "MALE";
			this.optEMSGender[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optEMSGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optEMSGender[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optEMSGender[1].Name = "_optEMSGender_1";
			this.optEMSGender[1].TabIndex = 11;
			this.optEMSGender[1].Text = "FEMALE";
			this.frmBasicGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmBasicGender
			// 
			this.frmBasicGender.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmBasicGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmBasicGender.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmBasicGender.Name = "frmBasicGender";
			this.frmBasicGender.TabIndex = 214;
			this.frmBasicGender.Text = "GENDER";
            this.optGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			this.optGender[1] = _optGender_1;
			this.optGender[0] = _optGender_0;
			this.optGender[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optGender[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optGender[1].Name = "_optGender_1";
            this.optGender[1].TabIndex = 34;
			this.optGender[1].Text = "FEMALE";
			this.optGender[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optGender[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optGender[0].Name = "_optGender_0";
			this.optGender[0].TabIndex = 33;
			this.optGender[0].Text = "MALE";
			this.frmGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmGender
			// 
			this.frmGender.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmGender.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmGender.Name = "frmGender";
			this.frmGender.TabIndex = 188;
			this.frmGender.Text = "GENDER";
            this.optPupils = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			this.optPupils[0] = _optPupils_0;
			this.optPupils[1] = _optPupils_1;
			this.optPupils[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optPupils[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optPupils[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optPupils[0].Name = "_optPupils_0";
            this.optPupils[0].TabIndex = 47;
			this.optPupils[0].Text = "EQUAL";
			this.optPupils[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optPupils[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optPupils[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optPupils[1].Name = "_optPupils_1";
			this.optPupils[1].TabIndex = 48;
            this.optPupils[1].Text = "NOT EQUAL";
			this.optLevelOfConsciouness = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			this.optLevelOfConsciouness[2] = _optLevelOfConsciouness_2;
			this.optLevelOfConsciouness[1] = _optLevelOfConsciouness_1;
			this.optLevelOfConsciouness[0] = _optLevelOfConsciouness_0;
			this.optLevelOfConsciouness[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optLevelOfConsciouness[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.optLevelOfConsciouness[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optLevelOfConsciouness[2].Name = "_optLevelOfConsciouness_2";
			this.optLevelOfConsciouness[2].TabIndex = 51;
			this.optLevelOfConsciouness[2].Text = "NONE";
			this.optLevelOfConsciouness[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optLevelOfConsciouness[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optLevelOfConsciouness[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optLevelOfConsciouness[1].Name = "_optLevelOfConsciouness_1";
			this.optLevelOfConsciouness[1].TabIndex = 50;
			this.optLevelOfConsciouness[1].Text = "CONFUSED/COMBATIVE";
			this.optLevelOfConsciouness[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optLevelOfConsciouness[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optLevelOfConsciouness[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optLevelOfConsciouness[0].Name = "_optLevelOfConsciouness_0";
            this.optLevelOfConsciouness[0].TabIndex = 49;
			this.optLevelOfConsciouness[0].Text = "NORMAL";
			this.optRespiratoryEffort = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			this.optRespiratoryEffort[2] = _optRespiratoryEffort_2;
			this.optRespiratoryEffort[1] = _optRespiratoryEffort_1;
			this.optRespiratoryEffort[0] = _optRespiratoryEffort_0;
			this.optRespiratoryEffort[2].BackColor = UpgradeHelpers.Helpers.Color.White;
            this.optRespiratoryEffort[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optRespiratoryEffort[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optRespiratoryEffort[2].Name = "_optRespiratoryEffort_2";
			this.optRespiratoryEffort[2].TabIndex = 54;
			this.optRespiratoryEffort[2].Text = "< 10 or > 30 or INTUBATION";
			this.optRespiratoryEffort[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optRespiratoryEffort[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.optRespiratoryEffort[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optRespiratoryEffort[1].Name = "_optRespiratoryEffort_1";
			this.optRespiratoryEffort[1].TabIndex = 53;
			this.optRespiratoryEffort[1].Text = "LABORED";
			this.optRespiratoryEffort[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optRespiratoryEffort[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optRespiratoryEffort[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optRespiratoryEffort[0].Name = "_optRespiratoryEffort_0";
			this.optRespiratoryEffort[0].TabIndex = 52;
			this.optRespiratoryEffort[0].Text = "NORMAL";
			this.NoVitals = 0;
			this.txtTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>>(5);
			this.txtTime[0] = _txtTime_0;
			this.txtTime[1] = _txtTime_1;
            this.txtTime[2] = _txtTime_2;
			this.txtTime[3] = _txtTime_3;
			this.txtTime[4] = _txtTime_4;
			this.txtTime[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime[0].Mask = "##:##";
			this.txtTime[0].Name = "_txtTime_0";
			this.txtTime[0].TabIndex = 55;
            this.txtTime[1].Enabled = false;
			this.txtTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime[1].Mask = "##:##";
			this.txtTime[1].Name = "_txtTime_1";
			this.txtTime[1].TabIndex = 69;
			this.txtTime[2].Enabled = false;
			this.txtTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime[2].Mask = "##:##";
			this.txtTime[2].Name = "_txtTime_2";
			this.txtTime[2].TabIndex = 83;
			this.txtTime[3].Enabled = false;
			this.txtTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime[3].Mask = "##:##";
			this.txtTime[3].Name = "_txtTime_3";
            this.txtTime[3].TabIndex = 97;
			this.txtTime[4].Enabled = false;
			this.txtTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime[4].Mask = "##:##";
			this.txtTime[4].Name = "_txtTime_4";
			this.txtTime[4].TabIndex = 111;
			this.txtPulse = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
            this.txtPulse[0] = _txtPulse_0;
			this.txtPulse[2] = _txtPulse_2;
			this.txtPulse[3] = _txtPulse_3;
			this.txtPulse[4] = _txtPulse_4;
			this.txtPulse[1] = _txtPulse_1;
			this.txtPulse[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulse[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtPulse[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulse[0].Name = "_txtPulse_0";
			this.txtPulse[0].TabIndex = 58;
			this.txtPulse[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulse[1].Enabled = false;
			this.txtPulse[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulse[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPulse[1].Name = "_txtPulse_1";
			this.txtPulse[1].TabIndex = 72;
			this.txtPulse[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulse[2].Enabled = false;
			this.txtPulse[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulse[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulse[2].Name = "_txtPulse_2";
            this.txtPulse[2].TabIndex = 86;
			this.txtPulse[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulse[3].Enabled = false;
			this.txtPulse[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulse[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulse[3].Name = "_txtPulse_3";
			this.txtPulse[3].TabIndex = 100;
            this.txtPulse[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulse[4].Enabled = false;
			this.txtPulse[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulse[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulse[4].Name = "_txtPulse_4";
			this.txtPulse[4].TabIndex = 114;
			this.txtRespiration = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
            this.txtRespiration[0] = _txtRespiration_0;
			this.txtRespiration[1] = _txtRespiration_1;
			this.txtRespiration[2] = _txtRespiration_2;
			this.txtRespiration[3] = _txtRespiration_3;
			this.txtRespiration[4] = _txtRespiration_4;
			this.txtRespiration[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtRespiration[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtRespiration[0].Name = "_txtRespiration_0";
			this.txtRespiration[0].TabIndex = 57;
			this.txtRespiration[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtRespiration[1].Enabled = false;
			this.txtRespiration[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtRespiration[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRespiration[1].Name = "_txtRespiration_1";
			this.txtRespiration[1].TabIndex = 71;
			this.txtRespiration[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtRespiration[2].Enabled = false;
			this.txtRespiration[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtRespiration[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtRespiration[2].Name = "_txtRespiration_2";
            this.txtRespiration[2].TabIndex = 85;
			this.txtRespiration[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtRespiration[3].Enabled = false;
			this.txtRespiration[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtRespiration[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtRespiration[3].Name = "_txtRespiration_3";
			this.txtRespiration[3].TabIndex = 99;
            this.txtRespiration[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtRespiration[4].Enabled = false;
			this.txtRespiration[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtRespiration[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtRespiration[4].Name = "_txtRespiration_4";
			this.txtRespiration[4].TabIndex = 113;
			this.txtSystolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
            this.txtSystolic[0] = _txtSystolic_0;
			this.txtSystolic[1] = _txtSystolic_1;
			this.txtSystolic[2] = _txtSystolic_2;
			this.txtSystolic[3] = _txtSystolic_3;
			this.txtSystolic[4] = _txtSystolic_4;
			this.txtSystolic[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSystolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSystolic[0].Name = "_txtSystolic_0";
			this.txtSystolic[0].TabIndex = 60;
			this.txtSystolic[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSystolic[1].Enabled = false;
			this.txtSystolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSystolic[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSystolic[1].Name = "_txtSystolic_1";
			this.txtSystolic[1].TabIndex = 74;
			this.txtSystolic[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSystolic[2].Enabled = false;
			this.txtSystolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSystolic[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSystolic[2].Name = "_txtSystolic_2";
            this.txtSystolic[2].TabIndex = 88;
			this.txtSystolic[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSystolic[3].Enabled = false;
			this.txtSystolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSystolic[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSystolic[3].Name = "_txtSystolic_3";
			this.txtSystolic[3].TabIndex = 102;
            this.txtSystolic[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtSystolic[4].Enabled = false;
			this.txtSystolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtSystolic[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSystolic[4].Name = "_txtSystolic_4";
			this.txtSystolic[4].TabIndex = 116;
			this.txtDiastolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
            this.txtDiastolic[0] = _txtDiastolic_0;
			this.txtDiastolic[1] = _txtDiastolic_1;
			this.txtDiastolic[2] = _txtDiastolic_2;
			this.txtDiastolic[3] = _txtDiastolic_3;
			this.txtDiastolic[4] = _txtDiastolic_4;
			this.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDiastolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtDiastolic[0].Name = "_txtDiastolic_0";
			this.txtDiastolic[0].TabIndex = 61;
			this.txtDiastolic[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDiastolic[1].Enabled = false;
			this.txtDiastolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiastolic[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDiastolic[1].Name = "_txtDiastolic_1";
			this.txtDiastolic[1].TabIndex = 75;
			this.txtDiastolic[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDiastolic[2].Enabled = false;
			this.txtDiastolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiastolic[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtDiastolic[2].Name = "_txtDiastolic_2";
            this.txtDiastolic[2].TabIndex = 89;
			this.txtDiastolic[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDiastolic[3].Enabled = false;
			this.txtDiastolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiastolic[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtDiastolic[3].Name = "_txtDiastolic_3";
			this.txtDiastolic[3].TabIndex = 103;
            this.txtDiastolic[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDiastolic[4].Enabled = false;
			this.txtDiastolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiastolic[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtDiastolic[4].Name = "_txtDiastolic_4";
			this.txtDiastolic[4].TabIndex = 117;
			this.chkPalp = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(5);
            this.chkPalp[0] = _chkPalp_0;
			this.chkPalp[1] = _chkPalp_1;
			this.chkPalp[2] = _chkPalp_2;
			this.chkPalp[3] = _chkPalp_3;
			this.chkPalp[4] = _chkPalp_4;
			this.chkPalp[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPalp[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.chkPalp[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkPalp[0].Name = "_chkPalp_0";
			this.chkPalp[0].TabIndex = 62;
			this.chkPalp[0].Text = "OR PALP";
			this.chkPalp[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPalp[1].Enabled = false;
			this.chkPalp[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.chkPalp[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkPalp[1].Name = "_chkPalp_1";
			this.chkPalp[1].TabIndex = 76;
			this.chkPalp[1].Text = "OR PALP";
			this.chkPalp[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPalp[2].Enabled = false;
			this.chkPalp[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.chkPalp[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkPalp[2].Name = "_chkPalp_2";
			this.chkPalp[2].TabIndex = 90;
			this.chkPalp[2].Text = "OR PALP";
			this.chkPalp[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPalp[3].Enabled = false;
			this.chkPalp[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.chkPalp[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkPalp[3].Name = "_chkPalp_3";
			this.chkPalp[3].TabIndex = 104;
			this.chkPalp[3].Text = "OR PALP";
			this.chkPalp[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPalp[4].Enabled = false;
			this.chkPalp[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.chkPalp[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkPalp[4].Name = "_chkPalp_4";
			this.chkPalp[4].TabIndex = 118;
			this.chkPalp[4].Text = "OR PALP";
			this.txtGlucose = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			this.txtGlucose[0] = _txtGlucose_0;
			this.txtGlucose[1] = _txtGlucose_1;
            this.txtGlucose[2] = _txtGlucose_2;
			this.txtGlucose[3] = _txtGlucose_3;
			this.txtGlucose[4] = _txtGlucose_4;
			this.txtGlucose[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtGlucose[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtGlucose[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtGlucose[0].Name = "_txtGlucose_0";
            this.txtGlucose[0].TabIndex = 63;
			this.txtGlucose[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtGlucose[1].Enabled = false;
			this.txtGlucose[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtGlucose[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtGlucose[1].Name = "_txtGlucose_1";
			this.txtGlucose[1].TabIndex = 77;
            this.txtGlucose[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtGlucose[2].Enabled = false;
			this.txtGlucose[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtGlucose[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtGlucose[2].Name = "_txtGlucose_2";
			this.txtGlucose[2].TabIndex = 91;
			this.txtGlucose[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.txtGlucose[3].Enabled = false;
			this.txtGlucose[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtGlucose[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtGlucose[3].Name = "_txtGlucose_3";
			this.txtGlucose[3].TabIndex = 105;
			this.txtGlucose[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtGlucose[4].Enabled = false;
            this.txtGlucose[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtGlucose[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtGlucose[4].Name = "_txtGlucose_4";
			this.txtGlucose[4].TabIndex = 119;
			this.txtPulseOxy = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			this.txtPulseOxy[0] = _txtPulseOxy_0;
			this.txtPulseOxy[1] = _txtPulseOxy_1;
            this.txtPulseOxy[2] = _txtPulseOxy_2;
			this.txtPulseOxy[3] = _txtPulseOxy_3;
			this.txtPulseOxy[4] = _txtPulseOxy_4;
			this.txtPulseOxy[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulseOxy[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulseOxy[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulseOxy[0].Name = "_txtPulseOxy_0";
            this.txtPulseOxy[0].TabIndex = 64;
			this.txtPulseOxy[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulseOxy[1].Enabled = false;
			this.txtPulseOxy[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulseOxy[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulseOxy[1].Name = "_txtPulseOxy_1";
			this.txtPulseOxy[1].TabIndex = 78;
            this.txtPulseOxy[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulseOxy[2].Enabled = false;
			this.txtPulseOxy[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulseOxy[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulseOxy[2].Name = "_txtPulseOxy_2";
			this.txtPulseOxy[2].TabIndex = 92;
			this.txtPulseOxy[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.txtPulseOxy[3].Enabled = false;
			this.txtPulseOxy[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulseOxy[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulseOxy[3].Name = "_txtPulseOxy_3";
			this.txtPulseOxy[3].TabIndex = 106;
			this.txtPulseOxy[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPulseOxy[4].Enabled = false;
            this.txtPulseOxy[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPulseOxy[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPulseOxy[4].Name = "_txtPulseOxy_4";
			this.txtPulseOxy[4].TabIndex = 120;
			this.txtPerOxy = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			this.txtPerOxy[4] = _txtPerOxy_4;
			this.txtPerOxy[3] = _txtPerOxy_3;
            this.txtPerOxy[2] = _txtPerOxy_2;
			this.txtPerOxy[1] = _txtPerOxy_1;
			this.txtPerOxy[0] = _txtPerOxy_0;
			this.txtPerOxy[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPerOxy[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPerOxy[0].Name = "_txtPerOxy_0";
            this.txtPerOxy[0].TabIndex = 65;
			this.txtPerOxy[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPerOxy[1].Enabled = false;
			this.txtPerOxy[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPerOxy[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPerOxy[1].Name = "_txtPerOxy_1";
			this.txtPerOxy[1].TabIndex = 79;
            this.txtPerOxy[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPerOxy[2].Enabled = false;
			this.txtPerOxy[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPerOxy[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPerOxy[2].Name = "_txtPerOxy_2";
			this.txtPerOxy[2].TabIndex = 93;
			this.txtPerOxy[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.txtPerOxy[3].Enabled = false;
			this.txtPerOxy[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPerOxy[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPerOxy[3].Name = "_txtPerOxy_3";
			this.txtPerOxy[3].TabIndex = 107;
			this.txtPerOxy[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtPerOxy[4].Enabled = false;
            this.txtPerOxy[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPerOxy[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtPerOxy[4].Name = "_txtPerOxy_4";
			this.txtPerOxy[4].TabIndex = 121;
			this.cboVitalsPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboVitalsPosition[0] = _cboVitalsPosition_0;
			this.cboVitalsPosition[1] = _cboVitalsPosition_1;
            this.cboVitalsPosition[2] = _cboVitalsPosition_2;
			this.cboVitalsPosition[3] = _cboVitalsPosition_3;
			this.cboVitalsPosition[4] = _cboVitalsPosition_4;
			this.cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVitalsPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVitalsPosition[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVitalsPosition[0].Name = "_cboVitalsPosition_0";
            this.cboVitalsPosition[0].TabIndex = 56;
			this.cboVitalsPosition[0].Text = "cboVitalsPosition";
			this.cboVitalsPosition[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVitalsPosition[1].Enabled = false;
			this.cboVitalsPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVitalsPosition[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVitalsPosition[1].Name = "_cboVitalsPosition_1";
            this.cboVitalsPosition[1].TabIndex = 70;
			this.cboVitalsPosition[1].Text = "cboVitalsPosition";
			this.cboVitalsPosition[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVitalsPosition[2].Enabled = false;
			this.cboVitalsPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVitalsPosition[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVitalsPosition[2].Name = "_cboVitalsPosition_2";
            this.cboVitalsPosition[2].TabIndex = 84;
			this.cboVitalsPosition[2].Text = "cboVitalsPosition";
			this.cboVitalsPosition[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVitalsPosition[3].Enabled = false;
			this.cboVitalsPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVitalsPosition[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVitalsPosition[3].Name = "_cboVitalsPosition_3";
            this.cboVitalsPosition[3].TabIndex = 98;
			this.cboVitalsPosition[3].Text = "cboVitalsPosition";
			this.cboVitalsPosition[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVitalsPosition[4].Enabled = false;
			this.cboVitalsPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVitalsPosition[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVitalsPosition[4].Name = "_cboVitalsPosition_4";
            this.cboVitalsPosition[4].TabIndex = 112;
			this.cboVitalsPosition[4].Text = "cboVitalsPosition";
			this.cboEyes = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboEyes[0] = _cboEyes_0;
			this.cboEyes[1] = _cboEyes_1;
			this.cboEyes[2] = _cboEyes_2;
			this.cboEyes[3] = _cboEyes_3;
            this.cboEyes[4] = _cboEyes_4;
			this.cboEyes[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEyes[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEyes[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEyes[0].Name = "_cboEyes_0";
			this.cboEyes[0].TabIndex = 66;
			this.cboEyes[0].Text = "cboEyes";
            this.cboEyes[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEyes[1].Enabled = false;
			this.cboEyes[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEyes[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEyes[1].Name = "_cboEyes_1";
			this.cboEyes[1].TabIndex = 80;
			this.cboEyes[1].Text = "cboEyes";
            this.cboEyes[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEyes[2].Enabled = false;
			this.cboEyes[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEyes[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEyes[2].Name = "_cboEyes_2";
			this.cboEyes[2].TabIndex = 94;
			this.cboEyes[2].Text = "cboEyes";
            this.cboEyes[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEyes[3].Enabled = false;
			this.cboEyes[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEyes[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEyes[3].Name = "_cboEyes_3";
			this.cboEyes[3].TabIndex = 108;
			this.cboEyes[3].Text = "cboEyes";
            this.cboEyes[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEyes[4].Enabled = false;
			this.cboEyes[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEyes[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboEyes[4].Name = "_cboEyes_4";
			this.cboEyes[4].TabIndex = 122;
			this.cboEyes[4].Text = "cboEyes";
            this.cboVerbal = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboVerbal[0] = _cboVerbal_0;
			this.cboVerbal[1] = _cboVerbal_1;
			this.cboVerbal[2] = _cboVerbal_2;
			this.cboVerbal[3] = _cboVerbal_3;
			this.cboVerbal[4] = _cboVerbal_4;
			this.cboVerbal[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboVerbal[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVerbal[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVerbal[0].Name = "_cboVerbal_0";
			this.cboVerbal[0].TabIndex = 67;
			this.cboVerbal[0].Text = "cboVerbal";
			this.cboVerbal[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVerbal[1].Enabled = false;
            this.cboVerbal[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVerbal[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVerbal[1].Name = "_cboVerbal_1";
			this.cboVerbal[1].TabIndex = 81;
			this.cboVerbal[1].Text = "cboVerbal";
			this.cboVerbal[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVerbal[2].Enabled = false;
            this.cboVerbal[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVerbal[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVerbal[2].Name = "_cboVerbal_2";
			this.cboVerbal[2].TabIndex = 95;
			this.cboVerbal[2].Text = "cboVerbal";
			this.cboVerbal[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVerbal[3].Enabled = false;
            this.cboVerbal[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVerbal[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVerbal[3].Name = "_cboVerbal_3";
			this.cboVerbal[3].TabIndex = 109;
			this.cboVerbal[3].Text = "cboVerbal";
			this.cboVerbal[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboVerbal[4].Enabled = false;
            this.cboVerbal[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboVerbal[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboVerbal[4].Name = "_cboVerbal_4";
			this.cboVerbal[4].TabIndex = 123;
			this.cboVerbal[4].Text = "cboVerbal";
			this.cboMotor = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboMotor[0] = _cboMotor_0;
            this.cboMotor[1] = _cboMotor_1;
			this.cboMotor[2] = _cboMotor_2;
			this.cboMotor[3] = _cboMotor_3;
			this.cboMotor[4] = _cboMotor_4;
			this.cboMotor[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMotor[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMotor[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMotor[0].Name = "_cboMotor_0";
			this.cboMotor[0].TabIndex = 68;
			this.cboMotor[0].Text = "cboMotor";
			this.cboMotor[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMotor[1].Enabled = false;
			this.cboMotor[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMotor[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMotor[1].Name = "_cboMotor_1";
			this.cboMotor[1].TabIndex = 82;
			this.cboMotor[1].Text = "cboMotor";
			this.cboMotor[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMotor[2].Enabled = false;
			this.cboMotor[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMotor[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMotor[2].Name = "_cboMotor_2";
			this.cboMotor[2].TabIndex = 96;
			this.cboMotor[2].Text = "cboMotor";
			this.cboMotor[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMotor[3].Enabled = false;
			this.cboMotor[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMotor[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMotor[3].Name = "_cboMotor_3";
			this.cboMotor[3].TabIndex = 110;
			this.cboMotor[3].Text = "cboMotor";
			this.cboMotor[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMotor[4].Enabled = false;
			this.cboMotor[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMotor[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboMotor[4].Name = "_cboMotor_4";
			this.cboMotor[4].TabIndex = 124;
			this.cboMotor[4].Text = "cboMotor";
			this.frmSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmSeverity
			// 
			this.frmSeverity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmSeverity.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmSeverity.Name = "frmSeverity";
			this.frmSeverity.TabIndex = 207;
			this.frmSeverity.Text = "Severity";
			this.TraumaSwitch = 0;
            this.cboGauge = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboGauge[0] = _cboGauge_0;
			this.cboGauge[1] = _cboGauge_1;
			this.cboGauge[2] = _cboGauge_2;
			this.cboGauge[3] = _cboGauge_3;
			this.cboGauge[4] = _cboGauge_4;
			this.cboGauge[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboGauge[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGauge[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboGauge[0].Name = "_cboGauge_0";
			this.cboGauge[0].TabIndex = 340;
			this.cboGauge[0].Text = "cboGauge";
			this.cboGauge[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGauge[1].Enabled = false;
            this.cboGauge[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGauge[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboGauge[1].Name = "_cboGauge_1";
			this.cboGauge[1].TabIndex = 345;
			this.cboGauge[1].Text = "cboGauge";
			this.cboGauge[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGauge[2].Enabled = false;
            this.cboGauge[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGauge[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboGauge[2].Name = "_cboGauge_2";
			this.cboGauge[2].TabIndex = 350;
			this.cboGauge[2].Text = "cboGauge";
			this.cboGauge[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGauge[3].Enabled = false;
            this.cboGauge[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGauge[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboGauge[3].Name = "_cboGauge_3";
			this.cboGauge[3].TabIndex = 355;
			this.cboGauge[3].Text = "cboGauge";
			this.cboGauge[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboGauge[4].Enabled = false;
            this.cboGauge[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboGauge[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboGauge[4].Name = "_cboGauge_4";
			this.cboGauge[4].TabIndex = 360;
			this.cboGauge[4].Text = "cboGauge";
			this.cboRoute = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboRoute[0] = _cboRoute_0;
            this.cboRoute[1] = _cboRoute_1;
			this.cboRoute[2] = _cboRoute_2;
			this.cboRoute[3] = _cboRoute_3;
			this.cboRoute[4] = _cboRoute_4;
			this.cboRoute[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRoute[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRoute[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoute[0].Name = "_cboRoute_0";
			this.cboRoute[0].TabIndex = 341;
			this.cboRoute[0].Text = "cboRoute";
			this.cboRoute[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRoute[1].Enabled = false;
			this.cboRoute[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRoute[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoute[1].Name = "_cboRoute_1";
			this.cboRoute[1].TabIndex = 346;
			this.cboRoute[1].Text = "cboRoute";
			this.cboRoute[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRoute[2].Enabled = false;
			this.cboRoute[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRoute[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoute[2].Name = "_cboRoute_2";
			this.cboRoute[2].TabIndex = 351;
			this.cboRoute[2].Text = "cboRoute";
			this.cboRoute[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRoute[3].Enabled = false;
			this.cboRoute[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRoute[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoute[3].Name = "_cboRoute_3";
			this.cboRoute[3].TabIndex = 356;
			this.cboRoute[3].Text = "cboRoute";
			this.cboRoute[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRoute[4].Enabled = false;
			this.cboRoute[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRoute[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoute[4].Name = "_cboRoute_4";
			this.cboRoute[4].TabIndex = 361;
			this.cboRoute[4].Text = "cboRoute";
			this.cboRate = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboRate[0] = _cboRate_0;
			this.cboRate[1] = _cboRate_1;
			this.cboRate[2] = _cboRate_2;
            this.cboRate[3] = _cboRate_3;
			this.cboRate[4] = _cboRate_4;
			this.cboRate[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRate[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRate[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboRate[0].Name = "_cboRate_0";
			this.cboRate[0].TabIndex = 342;
            this.cboRate[0].Text = "cboRate";
			this.cboRate[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRate[1].Enabled = false;
			this.cboRate[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRate[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboRate[1].Name = "_cboRate_1";
			this.cboRate[1].TabIndex = 347;
            this.cboRate[1].Text = "cboRate";
			this.cboRate[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRate[2].Enabled = false;
			this.cboRate[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRate[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboRate[2].Name = "_cboRate_2";
			this.cboRate[2].TabIndex = 352;
            this.cboRate[2].Text = "cboRate";
			this.cboRate[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRate[3].Enabled = false;
			this.cboRate[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRate[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboRate[3].Name = "_cboRate_3";
			this.cboRate[3].TabIndex = 357;
            this.cboRate[3].Text = "cboRate";
			this.cboRate[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboRate[4].Enabled = false;
			this.cboRate[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRate[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboRate[4].Name = "_cboRate_4";
			this.cboRate[4].TabIndex = 362;
            this.cboRate[4].Text = "cboRate";
			this.txtAmount = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			this.txtAmount[0] = _txtAmount_0;
			this.txtAmount[1] = _txtAmount_1;
			this.txtAmount[2] = _txtAmount_2;
			this.txtAmount[3] = _txtAmount_3;
			this.txtAmount[4] = _txtAmount_4;
            this.txtAmount[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAmount[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAmount[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAmount[0].Name = "_txtAmount_0";
			this.txtAmount[0].TabIndex = 343;
			this.txtAmount[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAmount[1].Enabled = false;
            this.txtAmount[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAmount[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAmount[1].Name = "_txtAmount_1";
			this.txtAmount[1].TabIndex = 348;
			this.txtAmount[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAmount[2].Enabled = false;
			this.txtAmount[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAmount[2].Name = "_txtAmount_2";
			this.txtAmount[2].TabIndex = 353;
			this.txtAmount[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAmount[3].Enabled = false;
			this.txtAmount[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAmount[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAmount[3].Name = "_txtAmount_3";
			this.txtAmount[3].TabIndex = 358;
			this.txtAmount[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAmount[4].Enabled = false;
			this.txtAmount[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAmount[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAmount[4].Name = "_txtAmount_4";
            this.txtAmount[4].TabIndex = 364;
			this.cboSite = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboSite[0] = _cboSite_0;
			this.cboSite[1] = _cboSite_1;
			this.cboSite[2] = _cboSite_2;
			this.cboSite[3] = _cboSite_3;
			this.cboSite[4] = _cboSite_4;
            this.cboSite[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSite[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSite[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboSite[0].Name = "_cboSite_0";
			this.cboSite[0].TabIndex = 344;
			this.cboSite[0].Text = "cboSite";
			this.cboSite[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboSite[1].Enabled = false;
			this.cboSite[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSite[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboSite[1].Name = "_cboSite_1";
			this.cboSite[1].TabIndex = 349;
			this.cboSite[1].Text = "cboSite";
			this.cboSite[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboSite[2].Enabled = false;
			this.cboSite[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSite[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboSite[2].Name = "_cboSite_2";
			this.cboSite[2].TabIndex = 354;
			this.cboSite[2].Text = "cboSite";
			this.cboSite[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboSite[3].Enabled = false;
			this.cboSite[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSite[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboSite[3].Name = "_cboSite_3";
			this.cboSite[3].TabIndex = 359;
			this.cboSite[3].Text = "cboSite";
			this.cboSite[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboSite[4].Enabled = false;
			this.cboSite[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboSite[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboSite[4].Name = "_cboSite_4";
			this.cboSite[4].TabIndex = 365;
			this.cboSite[4].Text = "cboSite";
			this.CPRSwitch = 0;
            this.optArrestToCPR = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			this.optArrestToCPR[3] = _optArrestToCPR_3;
			this.optArrestToCPR[2] = _optArrestToCPR_2;
			this.optArrestToCPR[1] = _optArrestToCPR_1;
			this.optArrestToCPR[0] = _optArrestToCPR_0;
			this.optArrestToCPR[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToCPR[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optArrestToCPR[3].Name = "_optArrestToCPR_3";
			this.optArrestToCPR[3].TabIndex = 150;
			this.optArrestToCPR[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToCPR[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToCPR[2].Name = "_optArrestToCPR_2";
			this.optArrestToCPR[2].TabIndex = 149;
			this.optArrestToCPR[1].BackColor = UpgradeHelpers.Helpers.Color.White;
            this.optArrestToCPR[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToCPR[1].Name = "_optArrestToCPR_1";
			this.optArrestToCPR[1].TabIndex = 148;
			this.optArrestToCPR[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToCPR[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optArrestToCPR[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToCPR[0].Name = "_optArrestToCPR_0";
			this.optArrestToCPR[0].TabIndex = 147;
			this.optArrestToCPR[0].Text = "ARREST TO CPR";
			this.chkDiverted = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDiverted
			// 
			this.chkDiverted.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkDiverted.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDiverted.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkDiverted.Name = "chkDiverted";
			this.chkDiverted.TabIndex = 242;
			this.chkDiverted.Text = "DIVERTED?";
            this.lbTrans = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(12);
			this.lbTrans[1] = _lbTrans_1;
			this.lbTrans[2] = _lbTrans_2;
			this.lbTrans[3] = _lbTrans_3;
			this.lbTrans[4] = _lbTrans_4;
			this.lbTrans[5] = _lbTrans_5;
			this.lbTrans[0] = _lbTrans_0;
            this.lbTrans[11] = _lbTrans_11;
			this.lbTrans[7] = _lbTrans_7;
			this.lbTrans[6] = _lbTrans_6;
			this.lbTrans[9] = _lbTrans_9;
			this.lbTrans[10] = _lbTrans_10;
			this.lbTrans[8] = _lbTrans_8;
			this.lbTrans[1].BackColor = UpgradeHelpers.Helpers.Color.White;
            this.lbTrans[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[1].Name = "_lbTrans_1";
			this.lbTrans[1].TabIndex = 432;
			this.lbTrans[1].Text = "TRANSPORT BY";
			this.lbTrans[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbTrans[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrans[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[2].Name = "_lbTrans_2";
			this.lbTrans[2].TabIndex = 248;
			this.lbTrans[2].Text = "TRANSPORT TO";
			this.lbTrans[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbTrans[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.lbTrans[3].Name = "_lbTrans_3";
			this.lbTrans[3].TabIndex = 247;
			this.lbTrans[3].Text = "TRANSPORT FROM";
			this.lbTrans[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbTrans[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[4].Name = "_lbTrans_4";
            this.lbTrans[4].TabIndex = 246;
			this.lbTrans[4].Text = "MILEAGE";
			this.lbTrans[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbTrans[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[5].Name = "_lbTrans_5";
			this.lbTrans[5].TabIndex = 245;
            this.lbTrans[5].Text = "HOSPITAL CHOSEN BY";
			this.lbTrans[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbTrans[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[0].Name = "_lbTrans_0";
			this.lbTrans[0].TabIndex = 244;
			this.lbTrans[0].Text = "BASE STATION CONTACT";
            this.lbTrans[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrans[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[11].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[11].Name = "_lbTrans_11";
			this.lbTrans[11].TabIndex = 180;
			this.lbTrans[11].Text = "PATIENT LOCATION";
			this.lbTrans[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
            this.lbTrans[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[7].Name = "_lbTrans_7";
			this.lbTrans[7].TabIndex = 179;
			this.lbTrans[7].Text = "PROTECTIVE DEVICE";
			this.lbTrans[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrans[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrans[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[6].Name = "_lbTrans_6";
			this.lbTrans[6].TabIndex = 178;
			this.lbTrans[6].Text = "TRAUMA ID#";
			this.lbTrans[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrans[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.lbTrans[9].Name = "_lbTrans_9";
			this.lbTrans[9].TabIndex = 177;
			this.lbTrans[9].Text = "STEP III - BIOMECHANICS/OTHER RISK FACTORS";
			this.lbTrans[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrans[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[10].Name = "_lbTrans_10";
            this.lbTrans[10].TabIndex = 176;
			this.lbTrans[10].Text = "STEP II - ANATOMY OF INJURY";
			this.lbTrans[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTrans[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTrans[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbTrans[8].Name = "_lbTrans_8";
			this.lbTrans[8].TabIndex = 175;
            this.lbTrans[8].Text = "STEP I - VITAL SIGNS";
			this.CurrFrame = null;
			this.NavButton = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(5);
			this.NavButton[0] = _NavButton_0;
			this.NavButton[1] = _NavButton_1;
			this.NavButton[2] = _NavButton_2;
			this.NavButton[3] = _NavButton_3;
            this.NavButton[4] = _NavButton_4;
			this.NavButton[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(12)))));
			this.NavButton[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavButton[0].Name = "_NavButton_0";
			this.NavButton[0].TabIndex = 455;
			this.NavButton[0].Text = "Cancel";
			this.NavButton[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(12)))));
            this.NavButton[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavButton[1].Name = "_NavButton_1";
			this.NavButton[1].TabIndex = 456;
			this.NavButton[1].Text = "Back";
			this.NavButton[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(12)))));
			this.NavButton[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavButton[2].Name = "_NavButton_2";
            this.NavButton[2].TabIndex = 457;
			this.NavButton[2].Text = "Next";
			this.NavButton[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(12)))));
			this.NavButton[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavButton[3].Name = "_NavButton_3";
			this.NavButton[3].TabIndex = 458;
			this.NavButton[3].Text = "Save-Quit";
            this.NavButton[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(12)))));
			this.NavButton[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.NavButton[4].Name = "_NavButton_4";
			this.NavButton[4].TabIndex = 459;
			this.NavButton[4].Text = "Finish";
			this.optActionTaken = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(8);
			this.optActionTaken[0] = _optActionTaken_0;
            this.optActionTaken[1] = _optActionTaken_1;
			this.optActionTaken[2] = _optActionTaken_2;
			this.optActionTaken[4] = _optActionTaken_4;
			this.optActionTaken[5] = _optActionTaken_5;
			this.optActionTaken[6] = _optActionTaken_6;
			this.optActionTaken[7] = _optActionTaken_7;
			this.optActionTaken[3] = _optActionTaken_3;
            this.optActionTaken[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[0].Name = "_optActionTaken_0";
			this.optActionTaken[0].TabIndex = 406;
			this.optActionTaken[0].Text = "EXAM ONLY";
			this.optActionTaken[1].BackColor = UpgradeHelpers.Helpers.Color.White;
            this.optActionTaken[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[1].Name = "_optActionTaken_1";
			this.optActionTaken[1].TabIndex = 405;
			this.optActionTaken[1].Text = "EXAM/ASSIST ONLY";
			this.optActionTaken[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.optActionTaken[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[2].Name = "_optActionTaken_2";
			this.optActionTaken[2].TabIndex = 404;
			this.optActionTaken[2].Text = "EXAM /ASSIST/TRANSPORT";
			this.optActionTaken[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optActionTaken[4].Name = "_optActionTaken_4";
			this.optActionTaken[4].TabIndex = 403;
			this.optActionTaken[4].Text = "NO EXAM NEEDED";
			this.optActionTaken[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[5].Name = "_optActionTaken_5";
            this.optActionTaken[5].TabIndex = 402;
			this.optActionTaken[5].Text = "REFUSED TREATMENT";
			this.optActionTaken[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[6].Name = "_optActionTaken_6";
			this.optActionTaken[6].TabIndex = 401;
            this.optActionTaken[6].Text = "DEAD ON ARRIVAL";
			this.optActionTaken[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[7].Enabled = false;
			this.optActionTaken[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[7].Name = "_optActionTaken_7";
			this.optActionTaken[7].TabIndex = 400;
            this.optActionTaken[7].Text = "INTERFACILITY TRANSFER";
			this.optActionTaken[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optActionTaken[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optActionTaken[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optActionTaken[3].Name = "_optActionTaken_3";
			this.optActionTaken[3].TabIndex = 399;
			this.optActionTaken[3].Text = "REFUSED TRANSPORT";
            this.lbNarr = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(4);
			this.lbNarr[3] = _lbNarr_3;
			this.lbNarr[2] = _lbNarr_2;
			this.lbNarr[1] = _lbNarr_1;
			this.lbNarr[0] = _lbNarr_0;
			this.lbNarr[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbNarr[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.lbNarr[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbNarr[3].Name = "_lbNarr_3";
			this.lbNarr[3].TabIndex = 454;
			this.lbNarr[3].Text = "Narrative";
			this.lbNarr[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbNarr[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarr[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.lbNarr[2].Name = "_lbNarr_2";
			this.lbNarr[2].TabIndex = 228;
			this.lbNarr[2].Text = "RESEARCH CODE";
			this.lbNarr[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbNarr[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarr[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbNarr[1].Name = "_lbNarr_1";
            this.lbNarr[1].TabIndex = 227;
			this.lbNarr[1].Text = "INCIDENT SETTING";
			this.lbNarr[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lbNarr[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarr[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbNarr[0].Name = "_lbNarr_0";
			this.lbNarr[0].TabIndex = 226;
			this.lbNarr[0].Text = "INCIDENT LOCATION                                     INCIDENT ZIPCODE ";
			this.ReqNarrString = "";
			this.ListsLoaded = 0;
            this.cboECG = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			this.cboECG[0] = _cboECG_0;
			this.cboECG[1] = _cboECG_1;
			this.cboECG[2] = _cboECG_2;
			this.cboECG[3] = _cboECG_3;
			this.cboECG[4] = _cboECG_4;
			this.cboECG[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.cboECG[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboECG[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboECG[0].Name = "_cboECG_0";
			this.cboECG[0].TabIndex = 59;
			this.cboECG[0].Text = "cboECG";
			this.cboECG[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboECG[1].Enabled = false;
            this.cboECG[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboECG[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboECG[1].Name = "_cboECG_1";
			this.cboECG[1].TabIndex = 73;
			this.cboECG[1].Text = "cboECG";
			this.cboECG[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboECG[2].Enabled = false;
            this.cboECG[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboECG[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboECG[2].Name = "_cboECG_2";
			this.cboECG[2].TabIndex = 87;
			this.cboECG[2].Text = "cboECG";
			this.cboECG[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboECG[3].Enabled = false;
            this.cboECG[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboECG[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboECG[3].Name = "_cboECG_3";
			this.cboECG[3].TabIndex = 101;
			this.cboECG[3].Text = "cboECG";
			this.cboECG[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboECG[4].Enabled = false;
            this.cboECG[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboECG[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cboECG[4].Name = "_cboECG_4";
			this.cboECG[4].TabIndex = 115;
			this.cboECG[4].Text = "cboECG";
			this.chkSalineLock = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkSalineLock
			// 
			this.chkSalineLock.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkSalineLock.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkSalineLock.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkSalineLock.Name = "chkSalineLock";
			this.chkSalineLock.TabIndex = 252;
			this.chkSalineLock.Text = "SALINE LOCK?";
            this.optMDorRN = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			this.optMDorRN[1] = _optMDorRN_1;
			this.optMDorRN[0] = _optMDorRN_0;
			this.optMDorRN[2] = _optMDorRN_2;
			this.optMDorRN[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optMDorRN[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optMDorRN[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optMDorRN[1].Name = "_optMDorRN_1";
			this.optMDorRN[1].TabIndex = 236;
			this.optMDorRN[1].Text = "RN";
			this.optMDorRN[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optMDorRN[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optMDorRN[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optMDorRN[0].Name = "_optMDorRN_0";
            this.optMDorRN[0].TabIndex = 235;
			this.optMDorRN[0].Text = "MD";
			this.optMDorRN[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optMDorRN[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optMDorRN[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optMDorRN[2].Name = "_optMDorRN_2";
			this.optMDorRN[2].TabIndex = 237;
			this.optMDorRN[2].Text = "OTHER";
			this.chkCPRTrained = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCPRTrained
			// 
			this.chkCPRTrained.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkCPRTrained.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCPRTrained.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkCPRTrained.Name = "chkCPRTrained";
			this.chkCPRTrained.TabIndex = 142;
			this.chkCPRTrained.Text = "CPR TRAINED?";
			this.chkWitnessedArrest = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkWitnessedArrest
			// 
			this.chkWitnessedArrest.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkWitnessedArrest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkWitnessedArrest.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkWitnessedArrest.Name = "chkWitnessedArrest";
			this.chkWitnessedArrest.TabIndex = 143;
			this.chkWitnessedArrest.Text = "WITNESSED ARREST?";
            this.optArrestToALS = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			this.optArrestToALS[0] = _optArrestToALS_0;
			this.optArrestToALS[1] = _optArrestToALS_1;
			this.optArrestToALS[2] = _optArrestToALS_2;
			this.optArrestToALS[3] = _optArrestToALS_3;
			this.optArrestToALS[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToALS[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this.optArrestToALS[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToALS[0].Name = "_optArrestToALS_0";
			this.optArrestToALS[0].TabIndex = 151;
			this.optArrestToALS[0].Text = "ARREST TO ALS";
			this.optArrestToALS[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToALS[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToALS[1].Name = "_optArrestToALS_1";
            this.optArrestToALS[1].TabIndex = 152;
			this.optArrestToALS[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToALS[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToALS[2].Name = "_optArrestToALS_2";
			this.optArrestToALS[2].TabIndex = 153;
			this.optArrestToALS[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToALS[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this.optArrestToALS[3].Name = "_optArrestToALS_3";
			this.optArrestToALS[3].TabIndex = 154;
			this.optArrestToShock = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			this.optArrestToShock[3] = _optArrestToShock_3;
			this.optArrestToShock[2] = _optArrestToShock_2;
			this.optArrestToShock[1] = _optArrestToShock_1;
			this.optArrestToShock[0] = _optArrestToShock_0;
            this.optArrestToShock[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToShock[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToShock[3].Name = "_optArrestToShock_3";
			this.optArrestToShock[3].TabIndex = 158;
			this.optArrestToShock[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToShock[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToShock[2].Name = "_optArrestToShock_2";
            this.optArrestToShock[2].TabIndex = 157;
			this.optArrestToShock[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToShock[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToShock[1].Name = "_optArrestToShock_1";
			this.optArrestToShock[1].TabIndex = 156;
			this.optArrestToShock[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			this.optArrestToShock[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.optArrestToShock[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.optArrestToShock[0].Name = "_optArrestToShock_0";
			this.optArrestToShock[0].TabIndex = 155;
			this.optArrestToShock[0].Text = "ARREST TO SHOCK";
			this.chkPulseRestored = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPulseRestored
			// 
			this.chkPulseRestored.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkPulseRestored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPulseRestored.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkPulseRestored.Name = "chkPulseRestored";
			this.chkPulseRestored.TabIndex = 159;
			this.chkPulseRestored.Text = "PULSE RESTORED?";
			this.frmALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmALSProcedures
			// 
			this.frmALSProcedures.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmALSProcedures.Name = "frmALSProcedures";
			this.frmALSProcedures.TabIndex = 422;
			this.frmALSProcedures.Text = "ALS PROCEDURES";
            this.imgMain = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>>(2);
			this.imgMain[0] = _imgMain_0;
			this.imgMain[1] = _imgMain_1;
			this.imgMain[0].Name = "_imgMain_0";
			this.imgMain[1].Name = "_imgMain_1";

            // 
            // frmALSAttempts
            // 
            this.frmALSAttempts = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            this.frmALSAttempts.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmALSAttempts.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmALSAttempts.Name = "frmALSAttempts";
			this.frmALSAttempts.TabIndex = 423;
			this.frmBaseStationContact = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmBaseStationContact
			// 
			this.frmBaseStationContact.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmBaseStationContact.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmBaseStationContact.Name = "frmBaseStationContact";
			this.frmBaseStationContact.TabIndex = 233;
			this.frmBaseStationContact.Visible = false;
            this.lbProcs = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(7);
			lbProcs[2] = _lbProcs_2;
			lbProcs[0] = _lbProcs_0;
			lbProcs[1] = _lbProcs_1;
			lbProcs[6] = _lbProcs_6;
			lbProcs[5] = _lbProcs_5;
			lbProcs[3] = _lbProcs_3;
            lbProcs[4] = _lbProcs_4;
			lbProcs[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbProcs[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[2].Name = "_lbProcs_2";
			lbProcs[2].TabIndex = 431;
			lbProcs[2].Text = "Select BLS Personnel";
            lbProcs[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbProcs[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[0].Name = "_lbProcs_0";
			lbProcs[0].TabIndex = 430;
			lbProcs[0].Text = "Select BLS OTEP Procedures";
			lbProcs[1].BackColor = UpgradeHelpers.Helpers.Color.White;
            lbProcs[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[1].Name = "_lbProcs_1";
			lbProcs[1].TabIndex = 429;
			lbProcs[1].Text = "Enter Other BLS Procedures";
			lbProcs[1].Visible = false;
			lbProcs[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
            lbProcs[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[6].Name = "_lbProcs_6";
			lbProcs[6].TabIndex = 424;
			lbProcs[6].Text = "ATTEMPTS";
			lbProcs[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbProcs[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbProcs[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[5].Name = "_lbProcs_5";
			lbProcs[5].TabIndex = 427;
			lbProcs[5].Text = "Select ALS Personnel";
			lbProcs[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbProcs[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            lbProcs[3].Name = "_lbProcs_3";
			lbProcs[3].TabIndex = 426;
			lbProcs[3].Text = "Select ALS Procedures";
			lbProcs[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbProcs[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbProcs[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbProcs[4].Name = "_lbProcs_4";
            lbProcs[4].TabIndex = 425;
			lbProcs[4].Text = "Enter Other ALS Procedures";
			lbProcs[4].Visible = false;
			this.frmInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmInjury
			// 
			this.frmInjury.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmInjury.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmInjury.Name = "frmInjury";
			this.frmInjury.TabIndex = 199;
			this.frmInjury.Text = "Injury";
			this.frmIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmIllness
			// 
			this.frmIllness.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.frmIllness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmIllness.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmIllness.Name = "frmIllness";
			this.frmIllness.TabIndex = 202;
			this.frmIllness.Text = "Primary Illness";
			this.chkSuccessful = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkSuccessful
			// 
			this.chkSuccessful.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkSuccessful.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkSuccessful.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkSuccessful.Name = "chkSuccessful";
			this.chkSuccessful.TabIndex = 416;
			this.chkSuccessful.Text = "SUCCESSFUL?";
			this.LevelOfCare = "";
            this.optEMSEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEMSEthnicity[0] = _optEMSEthnicity_0;
			optEMSEthnicity[1] = _optEMSEthnicity_1;
			optEMSEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			optEMSEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSEthnicity[0].Name = "_optEMSEthnicity_0";
			optEMSEthnicity[0].TabIndex = 13;
            optEMSEthnicity[0].Text = "HISPANIC";
			optEMSEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			optEMSEthnicity[1].Checked = true;
			optEMSEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSEthnicity[1].Name = "_optEMSEthnicity_1";
			optEMSEthnicity[1].TabIndex = 14;
			optEMSEthnicity[1].Text = "NON-HISPANIC";
            this.optEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEthnicity[1] = _optEthnicity_1;
			optEthnicity[0] = _optEthnicity_0;
			optEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			optEthnicity[1].Checked = true;
			optEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEthnicity[1].Name = "_optEthnicity_1";
            optEthnicity[1].TabIndex = 37;
			optEthnicity[1].Text = "NON-HISPANIC";
			optEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			optEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEthnicity[0].Name = "_optEthnicity_0";
			optEthnicity[0].TabIndex = 36;
			optEthnicity[0].Text = "HISPANIC";
			this.ReportLogID = 0;
			this.chkDNR = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDNR
			// 
			this.chkDNR.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.chkDNR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDNR.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkDNR.Name = "chkDNR";
			this.chkDNR.TabIndex = 38;
			this.chkDNR.Text = "DO NOT RESUSCITATE ORDER";
            this.lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(11);
			lbFrameTitle[7] = _lbFrameTitle_7;
			lbFrameTitle[5] = _lbFrameTitle_5;
			lbFrameTitle[9] = _lbFrameTitle_9;
			lbFrameTitle[3] = _lbFrameTitle_3;
			lbFrameTitle[10] = _lbFrameTitle_10;
			lbFrameTitle[8] = _lbFrameTitle_8;
			lbFrameTitle[6] = _lbFrameTitle_6;
            lbFrameTitle[2] = _lbFrameTitle_2;
			lbFrameTitle[0] = _lbFrameTitle_0;
			lbFrameTitle[4] = _lbFrameTitle_4;
			lbFrameTitle[1] = _lbFrameTitle_1;
			lbFrameTitle[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            lbFrameTitle[7].Name = "_lbFrameTitle_7";
			lbFrameTitle[7].TabIndex = 249;
			lbFrameTitle[7].Text = "TRANSPORT INFORMATION";
			lbFrameTitle[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[5].Name = "_lbFrameTitle_5";
            lbFrameTitle[5].TabIndex = 231;
			lbFrameTitle[5].Text = "TREATMENT INFORMATION";
			lbFrameTitle[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[9].Name = "_lbFrameTitle_9";
			lbFrameTitle[9].TabIndex = 218;
            lbFrameTitle[9].Text = "CPR INFORMATION";
			lbFrameTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[3].Name = "_lbFrameTitle_3";
			lbFrameTitle[3].TabIndex = 190;
			lbFrameTitle[3].Text = "PATIENT INFORMATION";
            lbFrameTitle[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbFrameTitle[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[10].Name = "_lbFrameTitle_10";
			lbFrameTitle[10].TabIndex = 182;
			lbFrameTitle[10].Text = "EMS BASIC INCIDENT INFORMATION";
			lbFrameTitle[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[8].Name = "_lbFrameTitle_8";
			lbFrameTitle[8].TabIndex = 174;
			lbFrameTitle[8].Text = "MAJOR TRAUMA";
			lbFrameTitle[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[6].Name = "_lbFrameTitle_6";
			lbFrameTitle[6].TabIndex = 160;
			lbFrameTitle[6].Text = "PROCEDURES PERFORMED";
			lbFrameTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[2].Name = "_lbFrameTitle_2";
			lbFrameTitle[2].TabIndex = 138;
			lbFrameTitle[2].Text = "PATIENT EXAM";
			lbFrameTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 22.2F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[0].Name = "_lbFrameTitle_0";
			lbFrameTitle[0].TabIndex = 136;
			lbFrameTitle[0].Text = "EMS INCIDENT CONTACT TYPE";
			lbFrameTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[4].Name = "_lbFrameTitle_4";
			lbFrameTitle[4].TabIndex = 134;
			lbFrameTitle[4].Text = "EMS NARRATION";
			lbFrameTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8F, ((
					UpgradeHelpers.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            lbFrameTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbFrameTitle[1].Name = "_lbFrameTitle_1";
			lbFrameTitle[1].TabIndex = 18;
			lbFrameTitle[1].Text = "EMS PATIENT - REPORT STATUS";
			this.lbVitals = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			lbVitals[1] = _lbVitals_1;
            lbVitals[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitals[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitals[1].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVitals[1].Name = "_lbVitals_1";
			lbVitals[1].TabIndex = 331;
			lbVitals[1].Text = "VITALS";
            this.lbVital = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(75);
			lbVital[70] = _lbVital_70;
			lbVital[55] = _lbVital_55;
			lbVital[40] = _lbVital_40;
			lbVital[25] = _lbVital_25;
			lbVital[10] = _lbVital_10;
			lbVital[69] = _lbVital_69;
			lbVital[54] = _lbVital_54;
			lbVital[39] = _lbVital_39;
			lbVital[24] = _lbVital_24;
			lbVital[9] = _lbVital_9;
			lbVital[1] = _lbVital_1;
            lbVital[4] = _lbVital_4;
			lbVital[8] = _lbVital_8;
			lbVital[7] = _lbVital_7;
			lbVital[6] = _lbVital_6;
			lbVital[5] = _lbVital_5;
			lbVital[2] = _lbVital_2;
			lbVital[3] = _lbVital_3;
			lbVital[0] = _lbVital_0;
			lbVital[14] = _lbVital_14;
			lbVital[13] = _lbVital_13;
			lbVital[12] = _lbVital_12;
			lbVital[11] = _lbVital_11;
            lbVital[16] = _lbVital_16;
			lbVital[19] = _lbVital_19;
			lbVital[23] = _lbVital_23;
			lbVital[22] = _lbVital_22;
			lbVital[21] = _lbVital_21;
			lbVital[20] = _lbVital_20;
			lbVital[17] = _lbVital_17;
			lbVital[18] = _lbVital_18;
			lbVital[15] = _lbVital_15;
			lbVital[29] = _lbVital_29;
			lbVital[28] = _lbVital_28;
			lbVital[27] = _lbVital_27;
            lbVital[26] = _lbVital_26;
			lbVital[31] = _lbVital_31;
			lbVital[34] = _lbVital_34;
			lbVital[38] = _lbVital_38;
			lbVital[37] = _lbVital_37;
			lbVital[36] = _lbVital_36;
			lbVital[35] = _lbVital_35;
			lbVital[32] = _lbVital_32;
			lbVital[33] = _lbVital_33;
			lbVital[30] = _lbVital_30;
			lbVital[44] = _lbVital_44;
			lbVital[43] = _lbVital_43;
            lbVital[42] = _lbVital_42;
			lbVital[41] = _lbVital_41;
			lbVital[46] = _lbVital_46;
			lbVital[49] = _lbVital_49;
			lbVital[53] = _lbVital_53;
			lbVital[52] = _lbVital_52;
			lbVital[51] = _lbVital_51;
			lbVital[50] = _lbVital_50;
			lbVital[47] = _lbVital_47;
			lbVital[48] = _lbVital_48;
			lbVital[45] = _lbVital_45;
			lbVital[59] = _lbVital_59;
            lbVital[58] = _lbVital_58;
			lbVital[57] = _lbVital_57;
			lbVital[56] = _lbVital_56;
			lbVital[61] = _lbVital_61;
			lbVital[64] = _lbVital_64;
			lbVital[68] = _lbVital_68;
			lbVital[67] = _lbVital_67;
			lbVital[66] = _lbVital_66;
			lbVital[65] = _lbVital_65;
			lbVital[62] = _lbVital_62;
			lbVital[63] = _lbVital_63;
			lbVital[60] = _lbVital_60;
			lbVital[74] = _lbVital_74;
			lbVital[73] = _lbVital_73;
			lbVital[72] = _lbVital_72;
			lbVital[71] = _lbVital_71;
			lbVital[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[10].Name = "_lbVital_10";
			lbVital[10].TabIndex = 438;
			lbVital[10].Text = "Liters";
			lbVital[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[9].Name = "_lbVital_9";
			lbVital[9].TabIndex = 433;
			lbVital[9].Text = "%ON";
			lbVital[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[1].Name = "_lbVital_1";
			lbVital[1].TabIndex = 330;
			lbVital[1].Text = "VITALS POSITION";
			lbVital[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[4].Name = "_lbVital_4";
			lbVital[4].TabIndex = 329;
			lbVital[4].Text = "ECG";
			lbVital[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[8].Name = "_lbVital_8";
			lbVital[8].TabIndex = 328;
			lbVital[8].Text = "PULSE OXY";
			lbVital[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[7].Name = "_lbVital_7";
			lbVital[7].TabIndex = 327;
			lbVital[7].Text = "GLUCOSE";
			lbVital[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[6].Name = "_lbVital_6";
			lbVital[6].TabIndex = 326;
			lbVital[6].Text = "DIASTOLIC";
			lbVital[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[5].Name = "_lbVital_5";
			lbVital[5].TabIndex = 325;
			lbVital[5].Text = "SYSTOLIC";
			lbVital[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[2].Name = "_lbVital_2";
			lbVital[2].TabIndex = 324;
			lbVital[2].Text = "RESPIRATION";
			lbVital[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[3].Name = "_lbVital_3";
			lbVital[3].TabIndex = 323;
			lbVital[3].Text = "PULSE";
			lbVital[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[0].Name = "_lbVital_0";
			lbVital[0].TabIndex = 322;
			lbVital[0].Text = "TIME";
			lbVital[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[14].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[14].Name = "_lbVital_14";
			lbVital[14].TabIndex = 321;
			lbVital[14].Text = "MOTOR";
			lbVital[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[13].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[13].Name = "_lbVital_13";
			lbVital[13].TabIndex = 320;
			lbVital[13].Text = "VERBAL";
			lbVital[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[12].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[12].Name = "_lbVital_12";
			lbVital[12].TabIndex = 319;
			lbVital[12].Text = "EYES";
			lbVital[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[11].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVital[11].Name = "_lbVital_11";
			lbVital[11].TabIndex = 318;
			lbVital[11].Text = "GCS";
			lbVital[24].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[24].Enabled = false;
			lbVital[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[24].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[24].Name = "_lbVital_24";
			lbVital[24].TabIndex = 434;
			lbVital[24].Text = "%ON";
			lbVital[25].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[25].Enabled = false;
			lbVital[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[25].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[25].Name = "_lbVital_25";
			lbVital[25].TabIndex = 439;
			lbVital[25].Text = "Liters";
			lbVital[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[16].Enabled = false;
			lbVital[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[16].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[16].Name = "_lbVital_16";
			lbVital[16].TabIndex = 317;
			lbVital[16].Text = "VITALS POSITION";
			lbVital[19].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[19].Enabled = false;
			lbVital[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[19].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[19].Name = "_lbVital_19";
			lbVital[19].TabIndex = 316;
			lbVital[19].Text = "ECG";
			lbVital[23].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[23].Enabled = false;
			lbVital[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[23].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[23].Name = "_lbVital_23";
			lbVital[23].TabIndex = 315;
			lbVital[23].Text = "PULSE OXY";
			lbVital[22].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[22].Enabled = false;
			lbVital[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[22].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[22].Name = "_lbVital_22";
			lbVital[22].TabIndex = 314;
			lbVital[22].Text = "GLUCOSE";
			lbVital[21].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[21].Enabled = false;
			lbVital[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[21].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[21].Name = "_lbVital_21";
			lbVital[21].TabIndex = 313;
			lbVital[21].Text = "DIASTOLIC";
			lbVital[20].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[20].Enabled = false;
			lbVital[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[20].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[20].Name = "_lbVital_20";
			lbVital[20].TabIndex = 312;
			lbVital[20].Text = "SYSTOLIC";
			lbVital[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[17].Enabled = false;
			lbVital[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[17].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[17].Name = "_lbVital_17";
			lbVital[17].TabIndex = 311;
			lbVital[17].Text = "RESPIRATION";
			lbVital[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[18].Enabled = false;
			lbVital[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[18].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[18].Name = "_lbVital_18";
			lbVital[18].TabIndex = 310;
			lbVital[18].Text = "PULSE";
			lbVital[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[15].Enabled = false;
			lbVital[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[15].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[15].Name = "_lbVital_15";
			lbVital[15].TabIndex = 309;
			lbVital[15].Text = "TIME";
			lbVital[29].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[29].Enabled = false;
			lbVital[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[29].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[29].Name = "_lbVital_29";
			lbVital[29].TabIndex = 308;
			lbVital[29].Text = "MOTOR";
			lbVital[28].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[28].Enabled = false;
			lbVital[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[28].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[28].Name = "_lbVital_28";
			lbVital[28].TabIndex = 307;
			lbVital[28].Text = "VERBAL";
			lbVital[27].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[27].Enabled = false;
			lbVital[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[27].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[27].Name = "_lbVital_27";
			lbVital[27].TabIndex = 306;
			lbVital[27].Text = "EYES";
			lbVital[26].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[26].Enabled = false;
			lbVital[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[26].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVital[26].Name = "_lbVital_26";
			lbVital[26].TabIndex = 305;
			lbVital[26].Text = "GCS";
			lbVital[41].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[41].Enabled = false;
			lbVital[41].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[41].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVital[41].Name = "_lbVital_41";
			lbVital[41].TabIndex = 292;
			lbVital[41].Text = "GCS";
			lbVital[42].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[42].Enabled = false;
			lbVital[42].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[42].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[42].Name = "_lbVital_42";
			lbVital[42].TabIndex = 293;
			lbVital[42].Text = "EYES";
			lbVital[43].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[43].Enabled = false;
			lbVital[43].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[43].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[43].Name = "_lbVital_43";
			lbVital[43].TabIndex = 294;
			lbVital[43].Text = "VERBAL";
			lbVital[44].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[44].Enabled = false;
			lbVital[44].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[44].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[44].Name = "_lbVital_44";
			lbVital[44].TabIndex = 295;
			lbVital[44].Text = "MOTOR";
			lbVital[30].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[30].Enabled = false;
			lbVital[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[30].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[30].Name = "_lbVital_30";
			lbVital[30].TabIndex = 296;
			lbVital[30].Text = "TIME";
			lbVital[33].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[33].Enabled = false;
			lbVital[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[33].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[33].Name = "_lbVital_33";
			lbVital[33].TabIndex = 297;
			lbVital[33].Text = "PULSE";
			lbVital[32].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[32].Enabled = false;
			lbVital[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[32].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[32].Name = "_lbVital_32";
			lbVital[32].TabIndex = 298;
			lbVital[32].Text = "RESPIRATION";
			lbVital[35].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[35].Enabled = false;
			lbVital[35].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[35].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[35].Name = "_lbVital_35";
			lbVital[35].TabIndex = 299;
			lbVital[35].Text = "SYSTOLIC";
			lbVital[36].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[36].Enabled = false;
			lbVital[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[36].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[36].Name = "_lbVital_36";
			lbVital[36].TabIndex = 300;
			lbVital[36].Text = "DIASTOLIC";
			lbVital[37].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[37].Enabled = false;
			lbVital[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[37].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[37].Name = "_lbVital_37";
			lbVital[37].TabIndex = 301;
			lbVital[37].Text = "GLUCOSE";
			lbVital[38].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[38].Enabled = false;
			lbVital[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[38].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[38].Name = "_lbVital_38";
			lbVital[38].TabIndex = 302;
			lbVital[38].Text = "PULSE OXY";
			lbVital[34].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[34].Enabled = false;
			lbVital[34].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[34].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[34].Name = "_lbVital_34";
			lbVital[34].TabIndex = 303;
			lbVital[34].Text = "ECG";
			lbVital[31].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[31].Enabled = false;
			lbVital[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[31].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[31].Name = "_lbVital_31";
			lbVital[31].TabIndex = 304;
			lbVital[31].Text = "VITALS POSITION";
			lbVital[39].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[39].Enabled = false;
			lbVital[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[39].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[39].Name = "_lbVital_39";
			lbVital[39].TabIndex = 435;
			lbVital[39].Text = "%ON";
			lbVital[40].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[40].Enabled = false;
			lbVital[40].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[40].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[40].Name = "_lbVital_40";
			lbVital[40].TabIndex = 440;
			lbVital[40].Text = "Liters";
			lbVital[55].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[55].Enabled = false;
			lbVital[55].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[55].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[55].Name = "_lbVital_55";
			lbVital[55].TabIndex = 441;
			lbVital[55].Text = "Liters";
			lbVital[54].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[54].Enabled = false;
			lbVital[54].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[54].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[54].Name = "_lbVital_54";
			lbVital[54].TabIndex = 436;
			lbVital[54].Text = "%ON";
			lbVital[46].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[46].Enabled = false;
			lbVital[46].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[46].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[46].Name = "_lbVital_46";
			lbVital[46].TabIndex = 291;
			lbVital[46].Text = "VITALS POSITION";
			lbVital[49].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[49].Enabled = false;
			lbVital[49].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[49].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[49].Name = "_lbVital_49";
			lbVital[49].TabIndex = 290;
			lbVital[49].Text = "ECG";
			lbVital[53].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[53].Enabled = false;
			lbVital[53].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[53].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[53].Name = "_lbVital_53";
			lbVital[53].TabIndex = 289;
			lbVital[53].Text = "PULSE OXY";
			lbVital[52].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[52].Enabled = false;
			lbVital[52].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[52].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[52].Name = "_lbVital_52";
			lbVital[52].TabIndex = 288;
			lbVital[52].Text = "GLUCOSE";
			lbVital[51].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[51].Enabled = false;
			lbVital[51].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[51].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[51].Name = "_lbVital_51";
			lbVital[51].TabIndex = 287;
			lbVital[51].Text = "DIASTOLIC";
			lbVital[50].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[50].Enabled = false;
			lbVital[50].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[50].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[50].Name = "_lbVital_50";
			lbVital[50].TabIndex = 286;
			lbVital[50].Text = "SYSTOLIC";
			lbVital[47].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[47].Enabled = false;
			lbVital[47].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[47].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[47].Name = "_lbVital_47";
			lbVital[47].TabIndex = 285;
			lbVital[47].Text = "RESPIRATION";
			lbVital[48].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[48].Enabled = false;
			lbVital[48].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[48].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[48].Name = "_lbVital_48";
			lbVital[48].TabIndex = 284;
			lbVital[48].Text = "PULSE";
			lbVital[45].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[45].Enabled = false;
			lbVital[45].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[45].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[45].Name = "_lbVital_45";
			lbVital[45].TabIndex = 283;
			lbVital[45].Text = "TIME";
			lbVital[59].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[59].Enabled = false;
			lbVital[59].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[59].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[59].Name = "_lbVital_59";
			lbVital[59].TabIndex = 282;
			lbVital[59].Text = "MOTOR";
			lbVital[58].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[58].Enabled = false;
			lbVital[58].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[58].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[58].Name = "_lbVital_58";
			lbVital[58].TabIndex = 281;
			lbVital[58].Text = "VERBAL";
			lbVital[57].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[57].Enabled = false;
			lbVital[57].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[57].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[57].Name = "_lbVital_57";
			lbVital[57].TabIndex = 280;
			lbVital[57].Text = "EYES";
			lbVital[56].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[56].Enabled = false;
			lbVital[56].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[56].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVital[56].Name = "_lbVital_56";
			lbVital[56].TabIndex = 279;
			lbVital[56].Text = "GCS";
			lbVital[70].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[70].Enabled = false;
			lbVital[70].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[70].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[70].Name = "_lbVital_70";
			lbVital[70].TabIndex = 442;
			lbVital[70].Text = "Liters";
			lbVital[69].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[69].Enabled = false;
			lbVital[69].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[69].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[69].Name = "_lbVital_69";
			lbVital[69].TabIndex = 437;
			lbVital[69].Text = "%ON";
			lbVital[61].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[61].Enabled = false;
			lbVital[61].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[61].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[61].Name = "_lbVital_61";
			lbVital[61].TabIndex = 278;
			lbVital[61].Text = "VITALS POSITION";
			lbVital[64].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[64].Enabled = false;
			lbVital[64].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[64].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[64].Name = "_lbVital_64";
			lbVital[64].TabIndex = 277;
			lbVital[64].Text = "ECG";
			lbVital[68].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[68].Enabled = false;
			lbVital[68].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[68].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[68].Name = "_lbVital_68";
			lbVital[68].TabIndex = 276;
			lbVital[68].Text = "PULSE OXY";
			lbVital[67].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[67].Enabled = false;
			lbVital[67].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[67].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[67].Name = "_lbVital_67";
			lbVital[67].TabIndex = 275;
			lbVital[67].Text = "GLUCOSE";
			lbVital[66].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[66].Enabled = false;
			lbVital[66].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[66].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[66].Name = "_lbVital_66";
			lbVital[66].TabIndex = 274;
			lbVital[66].Text = "DIASTOLIC";
			lbVital[65].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[65].Enabled = false;
			lbVital[65].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[65].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[65].Name = "_lbVital_65";
			lbVital[65].TabIndex = 273;
			lbVital[65].Text = "SYSTOLIC";
			lbVital[62].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[62].Enabled = false;
			lbVital[62].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[62].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[62].Name = "_lbVital_62";
			lbVital[62].TabIndex = 272;
			lbVital[62].Text = "RESPIRATION";
			lbVital[63].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[63].Enabled = false;
			lbVital[63].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[63].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[63].Name = "_lbVital_63";
			lbVital[63].TabIndex = 271;
			lbVital[63].Text = "PULSE";
			lbVital[60].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[60].Enabled = false;
			lbVital[60].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[60].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[60].Name = "_lbVital_60";
			lbVital[60].TabIndex = 270;
			lbVital[60].Text = "TIME";
			lbVital[74].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[74].Enabled = false;
			lbVital[74].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[74].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[74].Name = "_lbVital_74";
			lbVital[74].TabIndex = 269;
			lbVital[74].Text = "MOTOR";
			lbVital[73].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[73].Enabled = false;
			lbVital[73].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[73].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[73].Name = "_lbVital_73";
			lbVital[73].TabIndex = 268;
			lbVital[73].Text = "VERBAL";
			lbVital[72].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[72].Enabled = false;
			lbVital[72].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[72].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVital[72].Name = "_lbVital_72";
			lbVital[72].TabIndex = 267;
			lbVital[72].Text = "EYES";
			lbVital[71].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVital[71].Enabled = false;
			lbVital[71].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVital[71].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbVital[71].Name = "_lbVital_71";
			lbVital[71].TabIndex = 266;
			lbVital[71].Text = "GCS";
			this.lbTreatment = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(30);
			lbTreatment[6] = _lbTreatment_6;
			lbTreatment[5] = _lbTreatment_5;
			lbTreatment[7] = _lbTreatment_7;
			lbTreatment[8] = _lbTreatment_8;
			lbTreatment[9] = _lbTreatment_9;
			lbTreatment[11] = _lbTreatment_11;
			lbTreatment[10] = _lbTreatment_10;
			lbTreatment[12] = _lbTreatment_12;
			lbTreatment[13] = _lbTreatment_13;
			lbTreatment[14] = _lbTreatment_14;
			lbTreatment[16] = _lbTreatment_16;
			lbTreatment[15] = _lbTreatment_15;
			lbTreatment[17] = _lbTreatment_17;
			lbTreatment[18] = _lbTreatment_18;
			lbTreatment[19] = _lbTreatment_19;
			lbTreatment[21] = _lbTreatment_21;
			lbTreatment[20] = _lbTreatment_20;
			lbTreatment[22] = _lbTreatment_22;
			lbTreatment[23] = _lbTreatment_23;
			lbTreatment[24] = _lbTreatment_24;
			lbTreatment[26] = _lbTreatment_26;
			lbTreatment[25] = _lbTreatment_25;
			lbTreatment[27] = _lbTreatment_27;
			lbTreatment[28] = _lbTreatment_28;
			lbTreatment[29] = _lbTreatment_29;
			lbTreatment[1] = _lbTreatment_1;
			lbTreatment[3] = _lbTreatment_3;
			lbTreatment[2] = _lbTreatment_2;
			lbTreatment[0] = _lbTreatment_0;
			lbTreatment[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[1].Name = "_lbTreatment_1";
			lbTreatment[1].TabIndex = 394;
			lbTreatment[1].Text = "Extrication Time (MIN)";
			lbTreatment[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[3].Name = "_lbTreatment_3";
			lbTreatment[3].TabIndex = 251;
			lbTreatment[3].Text = "DOSAGES ADMINISTERED";
			lbTreatment[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[2].Name = "_lbTreatment_2";
			lbTreatment[2].TabIndex = 250;
			lbTreatment[2].Text = "MEDICATIONS";
			lbTreatment[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[0].Name = "_lbTreatment_0";
			lbTreatment[0].TabIndex = 230;
			lbTreatment[0].Text = "TREATMENT AUTHORIZATION";
			lbTreatment[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[6].Name = "_lbTreatment_6";
			lbTreatment[6].TabIndex = 390;
			lbTreatment[6].Text = "ROUTE";
			lbTreatment[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[5].Name = "_lbTreatment_5";
			lbTreatment[5].TabIndex = 389;
			lbTreatment[5].Text = "GAUGE";
			lbTreatment[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[7].Name = "_lbTreatment_7";
			lbTreatment[7].TabIndex = 388;
			lbTreatment[7].Text = "RATE";
			lbTreatment[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[8].Name = "_lbTreatment_8";
			lbTreatment[8].TabIndex = 387;
			lbTreatment[8].Text = "AMOUNT";
			lbTreatment[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[9].Name = "_lbTreatment_9";
			lbTreatment[9].TabIndex = 386;
			lbTreatment[9].Text = "SITE";
			lbTreatment[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[11].Enabled = false;
			lbTreatment[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[11].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[11].Name = "_lbTreatment_11";
			lbTreatment[11].TabIndex = 385;
			lbTreatment[11].Text = "ROUTE";
			lbTreatment[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[10].Enabled = false;
			lbTreatment[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[10].Name = "_lbTreatment_10";
			lbTreatment[10].TabIndex = 384;
			lbTreatment[10].Text = "GAUGE";
			lbTreatment[12].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[12].Enabled = false;
			lbTreatment[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[12].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[12].Name = "_lbTreatment_12";
			lbTreatment[12].TabIndex = 383;
			lbTreatment[12].Text = "RATE";
			lbTreatment[13].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[13].Enabled = false;
			lbTreatment[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[13].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[13].Name = "_lbTreatment_13";
			lbTreatment[13].TabIndex = 382;
			lbTreatment[13].Text = "AMOUNT";
			lbTreatment[14].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[14].Enabled = false;
			lbTreatment[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[14].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[14].Name = "_lbTreatment_14";
			lbTreatment[14].TabIndex = 381;
			lbTreatment[14].Text = "SITE";
			lbTreatment[16].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[16].Enabled = false;
			lbTreatment[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[16].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[16].Name = "_lbTreatment_16";
			lbTreatment[16].TabIndex = 380;
			lbTreatment[16].Text = "ROUTE";
			lbTreatment[15].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[15].Enabled = false;
			lbTreatment[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[15].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[15].Name = "_lbTreatment_15";
			lbTreatment[15].TabIndex = 379;
			lbTreatment[15].Text = "GAUGE";
			lbTreatment[17].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[17].Enabled = false;
			lbTreatment[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[17].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[17].Name = "_lbTreatment_17";
			lbTreatment[17].TabIndex = 378;
			lbTreatment[17].Text = "RATE";
			lbTreatment[18].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[18].Enabled = false;
			lbTreatment[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[18].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[18].Name = "_lbTreatment_18";
			lbTreatment[18].TabIndex = 377;
			lbTreatment[18].Text = "AMOUNT";
			lbTreatment[19].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[19].Enabled = false;
			lbTreatment[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[19].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[19].Name = "_lbTreatment_19";
			lbTreatment[19].TabIndex = 376;
			lbTreatment[19].Text = "SITE";
			lbTreatment[21].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[21].Enabled = false;
			lbTreatment[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[21].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[21].Name = "_lbTreatment_21";
			lbTreatment[21].TabIndex = 375;
			lbTreatment[21].Text = "ROUTE";
			lbTreatment[20].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[20].Enabled = false;
			lbTreatment[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[20].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[20].Name = "_lbTreatment_20";
			lbTreatment[20].TabIndex = 374;
			lbTreatment[20].Text = "GAUGE";
			lbTreatment[22].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[22].Enabled = false;
			lbTreatment[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[22].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[22].Name = "_lbTreatment_22";
			lbTreatment[22].TabIndex = 373;
			lbTreatment[22].Text = "RATE";
			lbTreatment[23].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[23].Enabled = false;
			lbTreatment[23].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[23].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[23].Name = "_lbTreatment_23";
			lbTreatment[23].TabIndex = 372;
			lbTreatment[23].Text = "AMOUNT";
			lbTreatment[24].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[24].Enabled = false;
			lbTreatment[24].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[24].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[24].Name = "_lbTreatment_24";
			lbTreatment[24].TabIndex = 371;
			lbTreatment[24].Text = "SITE";
			lbTreatment[26].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[26].Enabled = false;
			lbTreatment[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[26].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[26].Name = "_lbTreatment_26";
			lbTreatment[26].TabIndex = 370;
			lbTreatment[26].Text = "ROUTE";
			lbTreatment[25].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[25].Enabled = false;
			lbTreatment[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[25].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[25].Name = "_lbTreatment_25";
			lbTreatment[25].TabIndex = 369;
			lbTreatment[25].Text = "GAUGE";
			lbTreatment[27].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[27].Enabled = false;
			lbTreatment[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[27].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[27].Name = "_lbTreatment_27";
			lbTreatment[27].TabIndex = 368;
			lbTreatment[27].Text = "RATE";
			lbTreatment[28].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[28].Enabled = false;
			lbTreatment[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[28].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[28].Name = "_lbTreatment_28";
			lbTreatment[28].TabIndex = 366;
			lbTreatment[28].Text = "AMOUNT";
			lbTreatment[29].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbTreatment[29].Enabled = false;
			lbTreatment[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbTreatment[29].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbTreatment[29].Name = "_lbTreatment_29";
			lbTreatment[29].TabIndex = 363;
			lbTreatment[29].Text = "SITE";
			this.lbReport = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbReport[3] = _lbReport_3;
			lbReport[4] = _lbReport_4;
			lbReport[1] = _lbReport_1;
			lbReport[2] = _lbReport_2;
			lbReport[0] = _lbReport_0;
			lbReport[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbReport[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbReport[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbReport[3].Name = "_lbReport_3";
			lbReport[3].TabIndex = 264;
			lbReport[3].Text = "ASSIGNMENT:";
			lbReport[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbReport[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbReport[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbReport[4].Name = "_lbReport_4";
			lbReport[4].TabIndex = 263;
			lbReport[4].Text = "REPORTS FOR THIS INCIDENT:";
			lbReport[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbReport[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbReport[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbReport[1].Name = "_lbReport_1";
			lbReport[1].TabIndex = 261;
			lbReport[1].Text = "CURRENT REPORT:";
			lbReport[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbReport[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbReport[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbReport[2].Name = "_lbReport_2";
			lbReport[2].TabIndex = 255;
			lbReport[2].Text = "REPORT BY:";
			lbReport[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbReport[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbReport[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbReport[0].Name = "_lbReport_0";
			lbReport[0].TabIndex = 253;
			lbReport[0].Text = "INCIDENT #";
			this.lbPInfo = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(19);
			lbPInfo[3] = _lbPInfo_3;
			lbPInfo[12] = _lbPInfo_12;
			lbPInfo[11] = _lbPInfo_11;
			lbPInfo[10] = _lbPInfo_10;
			lbPInfo[9] = _lbPInfo_9;
			lbPInfo[4] = _lbPInfo_4;
			lbPInfo[2] = _lbPInfo_2;
			lbPInfo[6] = _lbPInfo_6;
			lbPInfo[5] = _lbPInfo_5;
			lbPInfo[0] = _lbPInfo_0;
			lbPInfo[1] = _lbPInfo_1;
			lbPInfo[13] = _lbPInfo_13;
			lbPInfo[8] = _lbPInfo_8;
			lbPInfo[7] = _lbPInfo_7;
			lbPInfo[18] = _lbPInfo_18;
			lbPInfo[17] = _lbPInfo_17;
			lbPInfo[16] = _lbPInfo_16;
			lbPInfo[15] = _lbPInfo_15;
			lbPInfo[14] = _lbPInfo_14;
			lbPInfo[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[3].Name = "_lbPInfo_3";
			lbPInfo[3].TabIndex = 216;
			lbPInfo[3].Text = "SSN#";
			lbPInfo[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[12].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[12].Name = "_lbPInfo_12";
			lbPInfo[12].TabIndex = 212;
			lbPInfo[12].Text = "POSSIBLE FACTORS IMPACTING CARE";
			lbPInfo[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[11].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[11].Name = "_lbPInfo_11";
			lbPInfo[11].TabIndex = 211;
			lbPInfo[11].Text = "PRIOR MEDICAL HISTORY";
			lbPInfo[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[10].Name = "_lbPInfo_10";
			lbPInfo[10].TabIndex = 210;
			lbPInfo[10].Text = "AGE UNITS";
			lbPInfo[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[9].Name = "_lbPInfo_9";
			lbPInfo[9].TabIndex = 209;
			lbPInfo[9].Text = "AGE";
			lbPInfo[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[4].Name = "_lbPInfo_4";
			lbPInfo[4].TabIndex = 208;
			lbPInfo[4].Text = "ZIPCODE";
			lbPInfo[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[2].Name = "_lbPInfo_2";
			lbPInfo[2].TabIndex = 198;
			lbPInfo[2].Text = "M.I.";
			lbPInfo[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[6].Name = "_lbPInfo_6";
			lbPInfo[6].TabIndex = 197;
			lbPInfo[6].Text = "CITY";
			lbPInfo[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[5].Name = "_lbPInfo_5";
			lbPInfo[5].TabIndex = 196;
			lbPInfo[5].Text = "STATE";
			lbPInfo[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[0].Name = "_lbPInfo_0";
			lbPInfo[0].TabIndex = 195;
			lbPInfo[0].Text = "FIRST NAME";
			lbPInfo[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[1].Name = "_lbPInfo_1";
			lbPInfo[1].TabIndex = 194;
			lbPInfo[1].Text = "LAST NAME";
			lbPInfo[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[13].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[13].Name = "_lbPInfo_13";
			lbPInfo[13].TabIndex = 193;
			lbPInfo[13].Text = "RACE";
			lbPInfo[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[8].Name = "_lbPInfo_8";
			lbPInfo[8].TabIndex = 192;
			lbPInfo[8].Text = "BIRTHDATE         OR";
			lbPInfo[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[7].Name = "_lbPInfo_7";
			lbPInfo[7].TabIndex = 191;
			lbPInfo[7].Text = "HOME PHONE";
			lbPInfo[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[18].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[18].Name = "_lbPInfo_18";
			lbPInfo[18].TabIndex = 453;
			lbPInfo[18].Text = "HOME PHONE";
			lbPInfo[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[17].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[17].Name = "_lbPInfo_17";
			lbPInfo[17].TabIndex = 452;
			lbPInfo[17].Text = "BIRTHDATE         OR";
			lbPInfo[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[16].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[16].Name = "_lbPInfo_16";
			lbPInfo[16].TabIndex = 451;
			lbPInfo[16].Text = "LAST NAME";
			lbPInfo[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[15].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[15].Name = "_lbPInfo_15";
			lbPInfo[15].TabIndex = 450;
			lbPInfo[15].Text = "FIRST NAME";
			lbPInfo[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[14].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[14].Name = "_lbPInfo_14";
			lbPInfo[14].TabIndex = 449;
			lbPInfo[14].Text = "M.I.";
			this.lbExam = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			lbExam[1] = _lbExam_1;
			lbExam[0] = _lbExam_0;
			lbExam[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbExam[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbExam[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbExam[1].Name = "_lbExam_1";
			lbExam[1].TabIndex = 201;
			lbExam[1].Text = "INJURY TYPE";
            this._lbExam_BodyPart.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
            this._lbExam_BodyPart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
            this._lbExam_BodyPart.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
            this._lbExam_BodyPart.Name = "_lbExam_BodyPart";
            //this._lbExam_BodyPart.TabIndex = 201;
            this._lbExam_BodyPart.Text = "BODY PART";
            lbExam[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbExam[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbExam[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbExam[0].Name = "_lbExam_0";
			lbExam[0].TabIndex = 139;
			lbExam[0].Text = "MECH CODE";
			this.lbCPR = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(4);
			lbCPR[2] = _lbCPR_2;
			lbCPR[3] = _lbCPR_3;
			lbCPR[0] = _lbCPR_0;
			lbCPR[1] = _lbCPR_1;
			lbCPR[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbCPR[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbCPR[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbCPR[2].Name = "_lbCPR_2";
			lbCPR[2].TabIndex = 224;
			lbCPR[2].Text = "TIMES IN MINUTES";
			lbCPR[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbCPR[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbCPR[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbCPR[3].Name = "_lbCPR_3";
			lbCPR[3].TabIndex = 223;
			lbCPR[3].Text = "< 4   4-8  8-15 >15";
			lbCPR[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbCPR[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbCPR[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbCPR[0].Name = "_lbCPR_0";
			lbCPR[0].TabIndex = 222;
			lbCPR[0].Text = "CPR DETAIL INFORMATION";
			lbCPR[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbCPR[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbCPR[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbCPR[1].Name = "_lbCPR_1";
			lbCPR[1].TabIndex = 219;
			lbCPR[1].Text = "SELECT INDIVIDUALS WHO PERFORMED CPR";
			this.lbBasic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(4);
			lbBasic[3] = _lbBasic_3;
			lbBasic[2] = _lbBasic_2;
			lbBasic[1] = _lbBasic_1;
			lbBasic[0] = _lbBasic_0;
			lbBasic[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbBasic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbBasic[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbBasic[3].Name = "_lbBasic_3";
			lbBasic[3].TabIndex = 186;
			lbBasic[3].Text = "SERVICE PROVIDED";
			lbBasic[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbBasic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbBasic[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbBasic[2].Name = "_lbBasic_2";
			lbBasic[2].TabIndex = 185;
			lbBasic[2].Text = "RACE";
			lbBasic[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbBasic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbBasic[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbBasic[1].Name = "_lbBasic_1";
			lbBasic[1].TabIndex = 184;
			lbBasic[1].Text = "AGE UNITS";
			lbBasic[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			lbBasic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbBasic[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbBasic[0].Name = "_lbBasic_0";
			lbBasic[0].TabIndex = 183;
			lbBasic[0].Text = "AGE";
			this.Line3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			Line3[0] = _Line3_0;
			Line3[1] = _Line3_1;
			Line3[2] = _Line3_2;
			Line3[3] = _Line3_3;
			Line3[4] = _Line3_4;
			Line3[0].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[0].Enabled = false;
			Line3[0].Name = "_Line3_0";
			Line3[0].TabIndex = 443;
			Line3[1].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[1].Enabled = false;
			Line3[1].Name = "_Line3_1";
			Line3[1].TabIndex = 444;
			Line3[2].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[2].Enabled = false;
			Line3[2].Name = "_Line3_2";
			Line3[2].TabIndex = 445;
			Line3[3].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[3].Enabled = false;
			Line3[3].Name = "_Line3_3";
			Line3[3].TabIndex = 446;
			Line3[4].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[4].Enabled = false;
			Line3[4].Name = "_Line3_4";
			Line3[4].TabIndex = 447;
			this.Name = "TFDIncident.wzdEms";
			lstMedications.Items.Add("lstMedications");
			lstCPRPerformedBy.Items.Add("lstCPRPerformedBy");
			lstBLSProcedures.Items.Add("lstBLSProcedures");
			lstBLSPersonnel.Items.Add("lstBLSPersonnel");
			lstALSProcedures.Items.Add("lstALSProcedures");
			tabVitals.Items.Add(tabPage1);
			tabVitals.Items.Add(tabPage2);
			tabVitals.Items.Add(tabPage3);
			tabVitals.Items.Add(tabPage4);
			tabVitals.Items.Add(tabPage5);
            vaTabPro2.Items.Add(tabLine1);
            vaTabPro2.Items.Add(tabLine2);
            vaTabPro2.Items.Add(tabLine3);
            vaTabPro2.Items.Add(tabLine4);
            lstSecondaryIllness.Items.Add("lstSecondaryIllness");
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel NavBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportTo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportFrom { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMileage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHospitalChosenBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBaseStationContact { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmTransportInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel vaTabPro2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExtricationTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmExtrication { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtDosage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTreatmentAuth { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTreatment_0 { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel shpMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmTreatmentInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToShock { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToALS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstCPRPerformedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCPRPerformedBy { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbCPR_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbCPR_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbCPR_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCPRPatientInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbCPR_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPriorMedicalHistory { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPossibleFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPatientAgeUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPatientAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZipCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBillingAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel mskBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel mskSSN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBillingAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmPatientInformation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboServiceProvided { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEMSRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAgeUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtBBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbBasic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbBasic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbBasic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbBasic_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmNoExamInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboProtectiveDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPatientLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTraumaID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbTrans_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmTrauma { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOtherBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstBLSPersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAttempts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboALSPersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOtherALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbProcs_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmProceduresPerformed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_70 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_55 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_69 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_54 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_50 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_59 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_58 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_57 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_56 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_61 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_64 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_68 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_67 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_66 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_65 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_62 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_63 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_60 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_74 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_73 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_72 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVital_71 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel tabVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSecondaryIllness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optPupils_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optPupils_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrimaryIllness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBodyPart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbExam_1 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbExam_BodyPart { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMechCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExamDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitals_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbExam_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmExamInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optActionTaken_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReptNumMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmActionTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtIncidentZipcode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboResearchCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentSetting { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbNarr_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbNarr_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbNarr_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbNarr_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbReport_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbReport_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSCurrReportType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbReport_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSEmployeeID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSReportedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbReport_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSIncidentNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbReport_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmReportStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocationTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnitTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNoTitle { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveMedication { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddBLS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCPRPerformed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddALS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkNoVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkMajTrauma { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel FDCaresBtn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAbandon { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveIncomplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage5 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabLine1 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabLine2 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabLine3 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabLine4 { get; set; }

        [UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 IVPerformed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PatientID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 EMSType { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optSeverity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ExtricationPerformed { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ActionTaken { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String DispatchedAs { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportSaved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationRequired { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEMSGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmBasicGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optPupils { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optLevelOfConsciouness { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optRespiratoryEffort { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NoVitals { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel> txtTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPulse { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtRespiration { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtSystolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtDiastolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkPalp { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtGlucose { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPulseOxy { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPerOxy { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboVitalsPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboEyes { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboVerbal { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboMotor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmSeverity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TraumaSwitch { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboGauge { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboRoute { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboRate { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtAmount { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboSite { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CPRSwitch { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDiverted { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbTrans { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel CurrFrame { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> NavButton { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optActionTaken { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbNarr { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReqNarrString { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ListsLoaded { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboECG { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSalineLock { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optMDorRN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCPRTrained { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkWitnessedArrest { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToALS { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToShock { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPulseRestored { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmALSProcedures { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel> imgMain { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmALSAttempts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmBaseStationContact { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbProcs { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmIllness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSuccessful { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String LevelOfCare { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEMSEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportLogID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDNR { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVitals { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVital { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbTreatment { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbReport { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPInfo { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbExam { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbCPR { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbBasic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line3 { get; set; }

		public void OntxtMileage_TextChanged()
		{
			if ( _txtMileage_TextChanged != null )
				_txtMileage_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtMileage_TextChanged;

		public void OntxtExtricationTime_TextChanged()
		{
			if ( _txtExtricationTime_TextChanged != null )
				_txtExtricationTime_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtExtricationTime_TextChanged;

		public void OntxtDosage_TextChanged()
		{
			if ( _txtDosage_TextChanged != null )
				_txtDosage_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtDosage_TextChanged;

		public void OntxtAmount_TextChanged()
		{
			if ( _txtAmount_TextChanged != null )
				_txtAmount_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAmount_TextChanged;

		public void OntxtPatientAge_TextChanged()
		{
			if ( _txtPatientAge_TextChanged != null )
				_txtPatientAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPatientAge_TextChanged;

		public void OntxtZipCode_TextChanged()
		{
			if ( _txtZipCode_TextChanged != null )
				_txtZipCode_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtZipCode_TextChanged;

		public void OntxtFirstName_TextChanged()
		{
			if ( _txtFirstName_TextChanged != null )
				_txtFirstName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtFirstName_TextChanged;

		public void OntxtLastName_TextChanged()
		{
			if ( _txtLastName_TextChanged != null )
				_txtLastName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtLastName_TextChanged;

		public void OntxtBLastName_TextChanged()
		{
			if ( _txtBLastName_TextChanged != null )
				_txtBLastName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBLastName_TextChanged;

		public void OntxtBFirstName_TextChanged()
		{
			if ( _txtBFirstName_TextChanged != null )
				_txtBFirstName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBFirstName_TextChanged;

		public void OntxtAge_TextChanged()
		{
			if ( _txtAge_TextChanged != null )
				_txtAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAge_TextChanged;

		public void OntxtTraumaID_TextChanged()
		{
			if ( _txtTraumaID_TextChanged != null )
				_txtTraumaID_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtTraumaID_TextChanged;

		public void OntxtOtherBLSProcedures_TextChanged()
		{
			if ( _txtOtherBLSProcedures_TextChanged != null )
				_txtOtherBLSProcedures_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtOtherBLSProcedures_TextChanged;

		public void OntxtAttempts_TextChanged()
		{
			if ( _txtAttempts_TextChanged != null )
				_txtAttempts_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAttempts_TextChanged;

		public void OntxtPerOxy_TextChanged()
		{
			if ( _txtPerOxy_TextChanged != null )
				_txtPerOxy_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPerOxy_TextChanged;

		public void OntxtPulseOxy_TextChanged()
		{
			if ( _txtPulseOxy_TextChanged != null )
				_txtPulseOxy_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPulseOxy_TextChanged;

		public void OntxtGlucose_TextChanged()
		{
			if ( _txtGlucose_TextChanged != null )
				_txtGlucose_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtGlucose_TextChanged;

		public void OntxtDiastolic_TextChanged()
		{
			if ( _txtDiastolic_TextChanged != null )
				_txtDiastolic_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtDiastolic_TextChanged;

		public void OntxtSystolic_TextChanged()
		{
			if ( _txtSystolic_TextChanged != null )
				_txtSystolic_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtSystolic_TextChanged;

		public void OntxtRespiration_TextChanged()
		{
			if ( _txtRespiration_TextChanged != null )
				_txtRespiration_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtRespiration_TextChanged;

		public void OntxtPulse_TextChanged()
		{
			if ( _txtPulse_TextChanged != null )
				_txtPulse_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPulse_TextChanged;

		public void OntxtIncidentZipcode_TextChanged()
		{
			if ( _txtIncidentZipcode_TextChanged != null )
				_txtIncidentZipcode_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtIncidentZipcode_TextChanged;
	}

}