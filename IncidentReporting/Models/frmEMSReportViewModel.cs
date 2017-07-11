using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmEMSReport))]
	public class frmEMSReportViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this._cboGauge_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboSite_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboRate_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboSite_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboRate_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboSite_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboRate_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboSite_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboRate_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboGauge_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboSite_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmount_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboRate_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboRoute_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._lbIVID_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbIVID_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbIVID_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbIVID_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbIVID_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSite_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAmount_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRate_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGauge_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRoute_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSite_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAmount_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRate_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGauge_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRoute_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSite_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAmount_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRate_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGauge_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRoute_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSite_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAmount_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRate_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGauge_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRoute_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSite_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbAmount_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRate_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGauge_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRoute_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.vaTabPro2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.vaTabPro2.Name = "vaTabPro2";
			this.vaTabPro2.SelectedIndex = 0;
			this.vaTabPro2.TabIndex = 231;
			this._cboECG_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboMotor_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbOxy1_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbECG_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbMotor_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVerbal_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbEyes_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGCS_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulseOxy_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGlucose_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDiastolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSystolic_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRespiration_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulse_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsID_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbOxy1_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame20
			// 
			this.Frame20.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame20.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame20.Name = "Frame20";
			this.Frame20.TabIndex = 402;
			this._cboECG_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboMotor_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbOxy1_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbECG_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbMotor_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVerbal_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbEyes_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGCS_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulseOxy_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGlucose_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDiastolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSystolic_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRespiration_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulse_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsID_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbOxy1_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame19
			// 
			this.Frame19.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame19.Enabled = false;
			this.Frame19.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame19.Name = "Frame19";
			this.Frame19.TabIndex = 386;
			this._cboECG_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboMotor_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPerOxy_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._cboVitalsPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtDiastolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbOxy1_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbECG_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulseOxy_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGlucose_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbMotor_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVerbal_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbEyes_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGCS_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbOxy1_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDiastolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSystolic_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRespiration_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulse_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsID_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame18
			// 
			this.Frame18.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame18.Enabled = false;
			this.Frame18.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame18.Name = "Frame18";
			this.Frame18.TabIndex = 370;
			this._cboECG_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboMotor_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVerbal_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEyes_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboVitalsPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtPulseOxy_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtGlucose_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtDiastolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtSystolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtRespiration_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPulse_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtPerOxy_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this._txtTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbOxy1_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbECG_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbMotor_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVerbal_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbEyes_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGCS_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulseOxy_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGlucose_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDiastolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSystolic_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRespiration_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulse_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsID_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbOxy1_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame17
			// 
			this.Frame17.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame17.Enabled = false;
			this.Frame17.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame17.Name = "Frame17";
			this.Frame17.TabIndex = 5;
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
			this._txtTime_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._lbOxy1_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbOxy1_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbECG_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulseOxy_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGlucose_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbDiastolic_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbSystolic_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbRespiration_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPulse_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsTime_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbMotor_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVerbal_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbEyes_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbGCS_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbVitalsID_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame15
			// 
			this.Frame15.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame15.Enabled = false;
			this.Frame15.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame15.Name = "Frame15";
			this.Frame15.TabIndex = 328;
			this.tabVitals = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.tabVitals.Name = "tabVitals";
			this.tabVitals.SelectedIndex = 0;
			this.tabVitals.TabIndex = 228;
			this.txtBMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBMI.Enabled = false;
			this.txtBMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBMI.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBMI.Name = "txtBMI";
			this.txtBMI.TabIndex = 441;
			this.txtBMI.Text = "txtMI";
			this.txtBLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBLastName.Enabled = false;
			this.txtBLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBLastName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBLastName.Name = "txtBLastName";
			this.txtBLastName.TabIndex = 440;
			this.txtBLastName.Text = "txtBLastName";
			this.txtBFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBFirstName.Enabled = false;
			this.txtBFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBFirstName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBFirstName.Name = "txtBFirstName";
			this.txtBFirstName.TabIndex = 439;
			this.txtBFirstName.Text = "txtBFirstName";
			this.txtBHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBHomePhone.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBHomePhone.Enabled = false;
			this.txtBHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBHomePhone.Name = "txtBHomePhone";
			this.txtBHomePhone.TabIndex = 438;
			this.txtBHomePhone.Text = "txtHomePhone";
			this._lbPInfo_34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Frame21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame21
			// 
			this.Frame21.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.Frame21.Enabled = false;
			this.Frame21.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame21.Name = "Frame21";
			this.Frame21.TabIndex = 424;
			this._optSeverity_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optSeverity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optSeverity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optRespiratoryEffort_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.cboNarrList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNarrList
			// 
			this.cboNarrList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboNarrList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboNarrList.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboNarrList.Name = "cboNarrList";
			this.cboNarrList.TabIndex = 202;
			this.cboNarrList.Text = "cboNarrList";
			this._lbPInfo_65 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_56 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbNarrMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrMessage
			// 
			this.lbNarrMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.lbNarrMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, ((UpgradeHelpers
						.Helpers.FontStyle)((UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic))), UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrMessage.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbNarrMessage.Name = "lbNarrMessage";
			this.lbNarrMessage.TabIndex = 353;
			this.lbNarrMessage.Text = "Narrations may only be edited by Original Author";
			this.lbNarrAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrAuthor
			// 
			this.lbNarrAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lbNarrAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbNarrAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrAuthor.Name = "lbNarrAuthor";
			this.lbNarrAuthor.TabIndex = 352;
			this.lbNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrID
			// 
			this.lbNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbNarrID.Name = "lbNarrID";
			this.lbNarrID.TabIndex = 345;
			this.lbNarrID.Visible = false;
			this._lbPInfo_55 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtIncidentZipcode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtIncidentZipcode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtIncidentZipcode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtIncidentZipcode.Name = "txtIncidentZipcode";
			this.txtIncidentZipcode.TabIndex = 199;
			this.cboResearchCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboResearchCode
			// 
			this.cboResearchCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboResearchCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboResearchCode.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboResearchCode.Name = "cboResearchCode";
			this.cboResearchCode.TabIndex = 201;
			this.cboResearchCode.Text = "cboResearchCode";
			this.cboIncidentSetting = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentSetting
			// 
			this.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncidentSetting.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboIncidentSetting.Name = "cboIncidentSetting";
			this.cboIncidentSetting.TabIndex = 200;
			this.cboIncidentSetting.Text = "cboIncidentSetting";
			this.cboIncidentLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboIncidentLocation
			// 
			this.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboIncidentLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboIncidentLocation.Name = "cboIncidentLocation";
			this.cboIncidentLocation.TabIndex = 198;
			this.cboIncidentLocation.Text = "cboIncidentLocation";
			this._lbPInfo_54 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_57 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_58 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_59 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboServiceProvided = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboServiceProvided
			// 
			this.cboServiceProvided.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboServiceProvided.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboServiceProvided.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboServiceProvided.Name = "cboServiceProvided";
			this.cboServiceProvided.TabIndex = 197;
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
			this.cboEMSRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboEMSRace.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboEMSRace.Name = "cboEMSRace";
			this.cboEMSRace.TabIndex = 194;
			this.cboEMSRace.Text = "cboEMSRace";
			this.cboAgeUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAgeUnits
			// 
			this.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAgeUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboAgeUnits.Name = "cboAgeUnits";
			this.cboAgeUnits.TabIndex = 191;
			this.cboAgeUnits.Text = "cboAgeUnits";
			this.txtAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAge.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAge.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtAge.Name = "txtAge";
			this.txtAge.TabIndex = 190;
			this.txtBBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBBirthdate.Mask = "##/##/####";
			this.txtBBirthdate.Name = "txtBBirthdate";
			this.txtBBirthdate.TabIndex = 436;
			this._lbPInfo_64 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line2_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._optArrestToCPR_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToCPR_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToCPR
			// 
			this.frmArrestToCPR.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmArrestToCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToCPR.Name = "frmArrestToCPR";
			this.frmArrestToCPR.TabIndex = 313;
			this._optArrestToALS_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToALS_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToALS = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToALS
			// 
			this.frmArrestToALS.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmArrestToALS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToALS.Name = "frmArrestToALS";
			this.frmArrestToALS.TabIndex = 312;
			this._optArrestToShock_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optArrestToShock_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmArrestToShock = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmArrestToShock
			// 
			this.frmArrestToShock.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmArrestToShock.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmArrestToShock.Name = "frmArrestToShock";
			this.frmArrestToShock.TabIndex = 311;
			this.lstCPRPerformedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstCPRPerformedBy
			// 
			this.lstCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstCPRPerformedBy.Name = "lstCPRPerformedBy";
			this.lstCPRPerformedBy.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstCPRPerformedBy.TabIndex = 175;
			this.cboCPRPerformedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCPRPerformedBy
			// 
			this.cboCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCPRPerformedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboCPRPerformedBy.Name = "cboCPRPerformedBy";
			this.cboCPRPerformedBy.TabIndex = 171;
			this.cboCPRPerformedBy.Text = "cboCPRPerformedBy";
			this.Shape1 = ctx.Resolve<VB6Helpers.ViewModels.ShapeHelperViewModel>();
			this.Shape1.Enabled = false;
			this.Shape1.Name = "Shape1";
			this.Shape1.TabIndex = 349;
			this._lbPInfo_50 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_51 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_49 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_53 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_52 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lstTrauma3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrauma3
			// 
			this.lstTrauma3.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma3.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstTrauma3.Name = "lstTrauma3";
			this.lstTrauma3.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma3.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma3.TabIndex = 170;
			this.lstTrauma2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrauma2
			// 
			this.lstTrauma2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma2.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstTrauma2.Name = "lstTrauma2";
			this.lstTrauma2.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma2.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma2.TabIndex = 169;
			this.lstTrauma1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstTrauma1
			// 
			this.lstTrauma1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstTrauma1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstTrauma1.Name = "lstTrauma1";
			this.lstTrauma1.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma1.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstTrauma1.TabIndex = 168;
			this.cboProtectiveDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboProtectiveDevice
			// 
			this.cboProtectiveDevice.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboProtectiveDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboProtectiveDevice.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboProtectiveDevice.Name = "cboProtectiveDevice";
			this.cboProtectiveDevice.TabIndex = 166;
			this.cboProtectiveDevice.Text = "cboProtectiveDevice";
			this.cboPatientLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPatientLocation
			// 
			this.cboPatientLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPatientLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPatientLocation.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboPatientLocation.Name = "cboPatientLocation";
			this.cboPatientLocation.TabIndex = 167;
			this.cboPatientLocation.Text = "cboPatientLocation";
			this.txtTraumaID = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtTraumaID.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtTraumaID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtTraumaID.Name = "txtTraumaID";
			this.txtTraumaID.TabIndex = 165;
			this._lbPInfo_44 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_43 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_45 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_46 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_48 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_47 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboTransportTo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportTo
			// 
			this.cboTransportTo.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportTo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportTo.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboTransportTo.Name = "cboTransportTo";
			this.cboTransportTo.TabIndex = 160;
			this.cboTransportTo.Text = "cboTransportTo";
			this.cboTransportBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportBy
			// 
			this.cboTransportBy.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportBy.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboTransportBy.Name = "cboTransportBy";
			this.cboTransportBy.TabIndex = 159;
			this.cboTransportBy.Text = "cboTransportBy";
			this.cboTransportFrom = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTransportFrom
			// 
			this.cboTransportFrom.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboTransportFrom.Enabled = false;
			this.cboTransportFrom.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTransportFrom.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboTransportFrom.Name = "cboTransportFrom";
			this.cboTransportFrom.TabIndex = 161;
			this.cboTransportFrom.Text = "cboTransportFrom";
			this.txtMileage = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMileage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMileage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMileage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMileage.Name = "txtMileage";
			this.txtMileage.TabIndex = 162;
			this.cboHospitalChosenBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHospitalChosenBy
			// 
			this.cboHospitalChosenBy.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHospitalChosenBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboHospitalChosenBy.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboHospitalChosenBy.Name = "cboHospitalChosenBy";
			this.cboHospitalChosenBy.TabIndex = 164;
			this.cboHospitalChosenBy.Text = "cboHospitalChosenBy";
			this.cboBaseStationContact = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBaseStationContact
			// 
			this.cboBaseStationContact.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBaseStationContact.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBaseStationContact.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboBaseStationContact.Name = "cboBaseStationContact";
			this.cboBaseStationContact.TabIndex = 155;
			this.cboBaseStationContact.Text = "cboBaseStationContact";
			this._optMDorRN_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optMDorRN_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optMDorRN_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._lbPInfo_39 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_38 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_40 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_41 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_42 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_37 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboTreatmentAuth = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboTreatmentAuth
			// 
			this.cboTreatmentAuth.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboTreatmentAuth.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboTreatmentAuth.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboTreatmentAuth.Name = "cboTreatmentAuth";
			this.cboTreatmentAuth.TabIndex = 121;
			this.cboTreatmentAuth.Text = "cboTreatmentAuthorization";
			this.txtExtricationTime = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtExtricationTime.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtExtricationTime.Name = "txtExtricationTime";
			this.txtExtricationTime.TabIndex = 123;
			this._lbPInfo_36 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtOtherALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOtherALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOtherALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOtherALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtOtherALSProcedures.Name = "txtOtherALSProcedures";
			this.txtOtherALSProcedures.TabIndex = 117;
			this.txtOtherALSProcedures.Visible = false;
			this.cboALSPersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboALSPersonnel
			// 
			this.cboALSPersonnel.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboALSPersonnel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboALSPersonnel.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboALSPersonnel.Name = "cboALSPersonnel";
			this.cboALSPersonnel.TabIndex = 118;
			this.cboALSPersonnel.Text = "cboALSPersonnel";
			this.txtAttempts = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAttempts.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAttempts.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtAttempts.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtAttempts.Name = "txtAttempts";
			this.txtAttempts.TabIndex = 115;
			this._lbPInfo_31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lstALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstALSProcedures
			// 
			this.lstALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstALSProcedures.Name = "lstALSProcedures";
			this.lstALSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstALSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstALSProcedures.TabIndex = 120;
			this.cboALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboALSProcedures
			// 
			this.cboALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboALSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboALSProcedures.Name = "cboALSProcedures";
			this.cboALSProcedures.TabIndex = 114;
			this.cboALSProcedures.Text = "cboALSProcedures";
			this._lbPInfo_29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtOtherBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOtherBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtOtherBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtOtherBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtOtherBLSProcedures.Name = "txtOtherBLSProcedures";
			this.txtOtherBLSProcedures.TabIndex = 109;
			this.txtOtherBLSProcedures.Visible = false;
			this.lstBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstBLSProcedures
			// 
			this.lstBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstBLSProcedures.Name = "lstBLSProcedures";
			this.lstBLSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstBLSProcedures.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstBLSProcedures.TabIndex = 112;
			this.cboBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBLSProcedures
			// 
			this.cboBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBLSProcedures.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboBLSProcedures.Name = "cboBLSProcedures";
			this.cboBLSProcedures.TabIndex = 108;
			this.cboBLSProcedures.Text = "cboBLSProcedures";
			this.lstBLSPersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstBLSPersonnel
			// 
			this.lstBLSPersonnel.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstBLSPersonnel.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstBLSPersonnel.Name = "lstBLSPersonnel";
			this.lstBLSPersonnel.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstBLSPersonnel.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstBLSPersonnel.TabIndex = 110;
			this._lbPInfo_26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboMechCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMechCode
			// 
			this.cboMechCode.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMechCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMechCode.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboMechCode.Name = "cboMechCode";
			this.cboMechCode.TabIndex = 23;
			this._lbPInfo_20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtZipCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZipCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtZipCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtZipCode.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtZipCode.Name = "txtZipCode";
			this.txtZipCode.TabIndex = 10;
			this.txtHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHomePhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtHomePhone.Name = "txtHomePhone";
			this.txtHomePhone.TabIndex = 11;
			this.txtBillingAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBillingAddress.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBillingAddress.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtBillingAddress.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtBillingAddress.Name = "txtBillingAddress";
			this.txtBillingAddress.TabIndex = 7;
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 8;
			this.cboState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboState
			// 
			this.cboState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboState.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboState.Name = "cboState";
			this.cboState.TabIndex = 9;
			this.cboState.Text = "cboState";
			this.txtFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtFirstName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.TabIndex = 2;
			this.txtLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtLastName.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.TabIndex = 3;
			this.txtMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtMI.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtMI.Name = "txtMI";
			this.txtMI.TabIndex = 4;
			this.mskSSN = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.mskSSN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.mskSSN.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.mskSSN.Mask = "###-##-####";
			this.mskSSN.Name = "mskSSN";
			this.mskSSN.TabIndex = 6;
			this._lbPInfo_18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lstPriorMedicalHistory = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPriorMedicalHistory
			// 
			this.lstPriorMedicalHistory.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstPriorMedicalHistory.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstPriorMedicalHistory.Name = "lstPriorMedicalHistory";
			this.lstPriorMedicalHistory.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstPriorMedicalHistory.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstPriorMedicalHistory.TabIndex = 21;
			this.lstPossibleFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPossibleFactors
			// 
			this.lstPossibleFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstPossibleFactors.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstPossibleFactors.Name = "lstPossibleFactors";
			this.lstPossibleFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstPossibleFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstPossibleFactors.TabIndex = 22;
			this._lbPInfo_15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRace
			// 
			this.cboRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboRace.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboRace.Name = "cboRace";
			this.cboRace.TabIndex = 17;
			this.cboRace.Text = "cboRace";
			this.lstMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMedications
			// 
			this.lstMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstMedications.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstMedications.Name = "lstMedications";
			this.lstMedications.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.lstMedications.TabIndex = 127;
			this.cboMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMedications
			// 
			this.cboMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboMedications.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboMedications.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboMedications.Name = "cboMedications";
			this.cboMedications.TabIndex = 124;
			this.cboMedications.Text = "cboMedications";
			this.txtDosage = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtDosage.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtDosage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtDosage.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtDosage.Name = "txtDosage";
			this.txtDosage.TabIndex = 125;
			this._lbPInfo_35 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboInjuryType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryType
			// 
			this.cboInjuryType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboInjuryType.Name = "cboInjuryType";
			this.cboInjuryType.TabIndex = 24;
			this.cboInjuryType.Text = "cboInjuryType";
			this.cboBodyPart = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBodyPart
			// 
			this.cboBodyPart.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBodyPart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboBodyPart.Name = "cboBodyPart";
			this.cboBodyPart.TabIndex = 25;
			this.cboBodyPart.Text = "cboBodyPart";
			this._lbPInfo_21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.cboPrimaryIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrimaryIllness
			// 
			this.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPrimaryIllness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPrimaryIllness.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboPrimaryIllness.Name = "cboPrimaryIllness";
			this.cboPrimaryIllness.TabIndex = 27;
			this.cboPrimaryIllness.Text = "cboPrimaryIllness";
			this._optPupils_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optPupils_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLevelOfConsciouness_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLevelOfConsciouness_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optLevelOfConsciouness_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstSecondaryIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstSecondaryIllness
			// 
			this.lstSecondaryIllness.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstSecondaryIllness.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lstSecondaryIllness.Name = "lstSecondaryIllness";
			this.lstSecondaryIllness.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstSecondaryIllness.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstSecondaryIllness.TabIndex = 28;
			this.txtPatientAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtPatientAge.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtPatientAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.txtPatientAge.Name = "txtPatientAge";
			this.txtPatientAge.TabIndex = 13;
			this.cboPatientAgeUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPatientAgeUnits
			// 
			this.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPatientAgeUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.cboPatientAgeUnits.Name = "cboPatientAgeUnits";
			this.cboPatientAgeUnits.TabIndex = 14;
			this.cboPatientAgeUnits.Text = "cboPatientAgeUnits";
			this.mskBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.mskBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.mskBirthdate.Mask = "##/##/####";
			this.mskBirthdate.Name = "mskBirthdate";
			this.mskBirthdate.TabIndex = 12;
			this._Line2_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Line1_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._optGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._lbPInfo_63 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_62 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_61 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_60 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbExamDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExamDate
			// 
			this.lbExamDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbExamDate.Enabled = false;
			this.lbExamDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbExamDate.Name = "lbExamDate";
			this.lbExamDate.TabIndex = 265;
			this.lbExamDate.Visible = false;
			this._lbPInfo_23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPInfo_24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbVitals = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVitals
			// 
			this.lbVitals.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVitals.Enabled = false;
			this.lbVitals.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbVitals.Name = "lbVitals";
			this.lbVitals.TabIndex = 227;
			this.lbVitals.Text = "VITALS";
			this.tabEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabControlViewModel>();
			this.tabEMS.Name = "tabEMS";
			this.tabEMS.SelectedIndex = 0;
			this.tabEMS.TabIndex = 211;
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 210;
			this.lbIncident.Text = "001230012";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 209;
			this.Label2.Text = "Incident #";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 207;
			this.lbLocation.Text = "lbLocation";
			this.lbLockedMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLockedMessage
			// 
			this.lbLockedMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbLockedMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.lbLockedMessage.Name = "lbLockedMessage";
			this.lbLockedMessage.TabIndex = 354;
			this.lbLockedMessage.Text = "READ ONLY - Records Locked";
			this.picEMSBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picEMSBar
			// 
			this.picEMSBar.BackColor = UpgradeHelpers.Helpers.Color.Navy;
			this.picEMSBar.Name = "picEMSBar";
			this._chkPalp_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkPalp_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkNoVitals = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkNoVitals
			// 
			this.chkNoVitals.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkNoVitals.Enabled = false;
			this.chkNoVitals.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkNoVitals.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.chkNoVitals.Name = "chkNoVitals";
			this.chkNoVitals.TabIndex = 429;
			this.chkNoVitals.Text = "Unable to Take Vitals ...see narrative";
			this.chkMajTrauma = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkMajTrauma
			// 
			this.chkMajTrauma.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkMajTrauma.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkMajTrauma.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkMajTrauma.Name = "chkMajTrauma";
			this.chkMajTrauma.TabIndex = 26;
			this.chkMajTrauma.Text = "MAJOR TRAUMA?";
			this.cmdRemoveALSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveALSProcedures
			// 
			this.cmdRemoveALSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveALSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveALSProcedures.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveALSProcedures.Name = "cmdRemoveALSProcedures";
			this.cmdRemoveALSProcedures.TabIndex = 122;
			this.cmdRemoveALSProcedures.Text = "REMOVE ALS PROCEDURES";
			this.cmdAddALS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddALS
			// 
			this.cmdAddALS.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddALS.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddALS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddALS.Name = "cmdAddALS";
			this.cmdAddALS.TabIndex = 119;
			this.cmdAddALS.Text = "ADD ALS PROCEDURES";
			this.cmdRemoveBLSProcedures = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveBLSProcedures
			// 
			this.cmdRemoveBLSProcedures.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveBLSProcedures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveBLSProcedures.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveBLSProcedures.Name = "cmdRemoveBLSProcedures";
			this.cmdRemoveBLSProcedures.TabIndex = 113;
			this.cmdRemoveBLSProcedures.Text = "REMOVE BLS PROCEDURES";
			this.cmdAddBLS = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddBLS
			// 
			this.cmdAddBLS.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddBLS.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddBLS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddBLS.Name = "cmdAddBLS";
			this.cmdAddBLS.TabIndex = 111;
			this.cmdAddBLS.Text = "ADD BLS PROCEDURES";
			this.chkCPRPerformed = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCPRPerformed
			// 
			this.chkCPRPerformed.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkCPRPerformed.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCPRPerformed.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkCPRPerformed.Name = "chkCPRPerformed";
			this.chkCPRPerformed.TabIndex = 107;
			this.chkCPRPerformed.Text = "CPR Performed?";
			this.cmdRemoveMedication = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveMedication
			// 
			this.cmdRemoveMedication.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveMedication.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveMedication.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveMedication.Name = "cmdRemoveMedication";
			this.cmdRemoveMedication.TabIndex = 128;
			this.cmdRemoveMedication.Text = "REMOVE MEDICATION";
			this.cmdAddMedications = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddMedications
			// 
			this.cmdAddMedications.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddMedications.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddMedications.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddMedications.Name = "cmdAddMedications";
			this.cmdAddMedications.TabIndex = 126;
			this.cmdAddMedications.Text = "ADD MEDICATION";
			this.cmdClear1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear1
			// 
			this.cmdClear1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear1.Name = "cmdClear1";
			this.cmdClear1.TabIndex = 348;
			this.cmdClear1.Text = "Clear";
			this.cmdClear2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear2
			// 
			this.cmdClear2.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear2.Name = "cmdClear2";
			this.cmdClear2.TabIndex = 347;
			this.cmdClear2.Text = "Clear";
			this.cmdClear3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear3
			// 
			this.cmdClear3.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear3.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear3.Name = "cmdClear3";
			this.cmdClear3.TabIndex = 346;
			this.cmdClear3.Text = "Clear";
			this.cmdRemoveCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemoveCPR
			// 
			this.cmdRemoveCPR.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemoveCPR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemoveCPR.Name = "cmdRemoveCPR";
			this.cmdRemoveCPR.TabIndex = 176;
			this.cmdRemoveCPR.Text = "REMOVE CPR PERFORMER";
			this.cmdAddCPR = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddCPR
			// 
			this.cmdAddCPR.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddCPR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddCPR.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddCPR.Name = "cmdAddCPR";
			this.cmdAddCPR.TabIndex = 174;
			this.cmdAddCPR.Text = "ADD CPR PERFORMER";
			this.FDCaresBtn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.FDCaresBtn.Name = "FDCaresBtn";
			this.FDCaresBtn.TabIndex = 449;
			this.cmdAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNarration
			// 
			this.cmdAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNarration.Name = "cmdAddNarration";
			this.cmdAddNarration.TabIndex = 203;
			this.cmdAddNarration.Tag = "1";
			this.cmdAddNarration.Text = "ADD NEW NARRATION";
			
			this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			// 
			// rtxNarration
			// 
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 204;
			this.rtxNarration.Text = "";
			this.cmdHIPAAInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdHIPAAInfo.Name = "cmdHIPAAInfo";
			this.cmdHIPAAInfo.TabIndex = 448;
			this._cmdSave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.tabPage1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Text = "Patient";
			this.tabPage2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Text = "Exam";
			this.tabPage3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Text = "Procedure";
			this.tabPage4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Text = "Treatment";
			this.tabPage5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Text = "Transport";
			this.tabPage6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Text = "Trauma";
			this.tabPage7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Text = "CPR";
			this.tabPage8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Text = "Basic";
			this.tabPage9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Text = "Narration";
			this.tabPage10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Text = "First";
			this.tabPage11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Text = "Second";
			this.tabPage12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Text = "Third";
			this.tabPage13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Text = "Forth";
			this.tabPage14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Text = "More.";
			this.tabPage15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Text = "First";
			this.tabPage16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Text = "Second";
			this.tabPage17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage17.Name = "tabPage17";
			this.tabPage17.Text = "Third";
			this.tabPage18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage18.Name = "tabPage18";
			this.tabPage18.Text = "Fourth";
			this.tabPage19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TabPageViewModel>();
			this.tabPage19.Name = "tabPage19";
			this.tabPage19.Text = "More.";
			this.Text = "Form1";
			this.PatientID = 0;
			this.FirstTime = 0;
			this.CurrIncident = 0;
			this.NarrationUpdated = 0;
			cmdSave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(4);
			cmdSave[3] = _cmdSave_3;
			cmdSave[0] = _cmdSave_0;
			cmdSave[1] = _cmdSave_1;
			cmdSave[2] = _cmdSave_2;
			cmdSave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[3].Name = "_cmdSave_3";
			cmdSave[3].TabIndex = 427;
			cmdSave[3].Text = "Print";
			cmdSave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[0].Name = "_cmdSave_0";
			cmdSave[0].TabIndex = 206;
			cmdSave[0].Text = "Save as Complete";
			cmdSave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[1].Name = "_cmdSave_1";
			cmdSave[1].TabIndex = 208;
			cmdSave[1].Text = "Save as Incomplete";
			cmdSave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cmdSave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[2].Name = "_cmdSave_2";
			cmdSave[2].TabIndex = 1;
			cmdSave[2].Text = "Cancel and Exit";
			this.ActionTaken = 0;
			optEMSGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEMSGender[0] = _optEMSGender_0;
			optEMSGender[1] = _optEMSGender_1;
			optEMSGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEMSGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSGender[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSGender[0].Name = "_optEMSGender_0";
			optEMSGender[0].TabIndex = 192;
			optEMSGender[0].Text = "MALE";
			optEMSGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEMSGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSGender[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSGender[1].Name = "_optEMSGender_1";
			optEMSGender[1].TabIndex = 193;
			optEMSGender[1].Text = "FEMALE";
			optEMSEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEMSEthnicity[0] = _optEMSEthnicity_0;
			optEMSEthnicity[1] = _optEMSEthnicity_1;
			optEMSEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEMSEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSEthnicity[0].Name = "_optEMSEthnicity_0";
			optEMSEthnicity[0].TabIndex = 195;
			optEMSEthnicity[0].Text = "HISPANIC";
			optEMSEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEMSEthnicity[1].Checked = true;
			optEMSEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEMSEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEMSEthnicity[1].Name = "_optEMSEthnicity_1";
			optEMSEthnicity[1].TabIndex = 196;
			optEMSEthnicity[1].Text = "NON-HISPANIC";
			optGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optGender[0] = _optGender_0;
			optGender[1] = _optGender_1;
			optGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGender[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optGender[0].Name = "_optGender_0";
			optGender[0].TabIndex = 15;
			optGender[0].Text = "MALE";
			optGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optGender[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optGender[1].Name = "_optGender_1";
			optGender[1].TabIndex = 16;
			optGender[1].Text = "FEMALE";
			optEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEthnicity[0] = _optEthnicity_0;
			optEthnicity[1] = _optEthnicity_1;
			optEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEthnicity[0].Name = "_optEthnicity_0";
			optEthnicity[0].TabIndex = 18;
			optEthnicity[0].Text = "HISPANIC";
			optEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optEthnicity[1].Checked = true;
			optEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optEthnicity[1].Name = "_optEthnicity_1";
			optEthnicity[1].TabIndex = 19;
			optEthnicity[1].Text = "NON-HISPANIC";
			this.chkDNR = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDNR
			// 
			this.chkDNR.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkDNR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDNR.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkDNR.Name = "chkDNR";
			this.chkDNR.TabIndex = 20;
			this.chkDNR.Text = "DO NOT RESUSCITATE ORDER";
			optPupils = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optPupils[1] = _optPupils_1;
			optPupils[0] = _optPupils_0;
			optPupils[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optPupils[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optPupils[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optPupils[1].Name = "_optPupils_1";
			optPupils[1].TabIndex = 30;
			optPupils[1].Text = "NOT EQUAL";
			optPupils[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optPupils[0].Checked = true;
			optPupils[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optPupils[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optPupils[0].Name = "_optPupils_0";
			optPupils[0].TabIndex = 29;
			optPupils[0].Text = "EQUAL";
			optLevelOfConsciouness = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optLevelOfConsciouness[0] = _optLevelOfConsciouness_0;
			optLevelOfConsciouness[1] = _optLevelOfConsciouness_1;
			optLevelOfConsciouness[2] = _optLevelOfConsciouness_2;
			optLevelOfConsciouness[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optLevelOfConsciouness[0].Checked = true;
			optLevelOfConsciouness[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optLevelOfConsciouness[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optLevelOfConsciouness[0].Name = "_optLevelOfConsciouness_0";
			optLevelOfConsciouness[0].TabIndex = 31;
			optLevelOfConsciouness[0].Text = "NORMAL";
			optLevelOfConsciouness[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optLevelOfConsciouness[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optLevelOfConsciouness[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optLevelOfConsciouness[1].Name = "_optLevelOfConsciouness_1";
			optLevelOfConsciouness[1].TabIndex = 32;
			optLevelOfConsciouness[1].Text = "CONFUSED/COMBATIVE";
			optLevelOfConsciouness[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optLevelOfConsciouness[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optLevelOfConsciouness[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optLevelOfConsciouness[2].Name = "_optLevelOfConsciouness_2";
			optLevelOfConsciouness[2].TabIndex = 33;
			optLevelOfConsciouness[2].Text = "NONE";
			optRespiratoryEffort = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optRespiratoryEffort[0] = _optRespiratoryEffort_0;
			optRespiratoryEffort[1] = _optRespiratoryEffort_1;
			optRespiratoryEffort[2] = _optRespiratoryEffort_2;
			optRespiratoryEffort[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optRespiratoryEffort[0].Checked = true;
			optRespiratoryEffort[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optRespiratoryEffort[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optRespiratoryEffort[0].Name = "_optRespiratoryEffort_0";
			optRespiratoryEffort[0].TabIndex = 422;
			optRespiratoryEffort[0].Text = "NORMAL";
			optRespiratoryEffort[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optRespiratoryEffort[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optRespiratoryEffort[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optRespiratoryEffort[1].Name = "_optRespiratoryEffort_1";
			optRespiratoryEffort[1].TabIndex = 421;
			optRespiratoryEffort[1].Text = "LABORED";
			optRespiratoryEffort[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optRespiratoryEffort[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optRespiratoryEffort[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optRespiratoryEffort[2].Name = "_optRespiratoryEffort_2";
			optRespiratoryEffort[2].TabIndex = 420;
			optRespiratoryEffort[2].Text = "< 10 or > 30 or INTUB.";
			optSeverity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optSeverity[2] = _optSeverity_2;
			optSeverity[1] = _optSeverity_1;
			optSeverity[0] = _optSeverity_0;
			optSeverity[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optSeverity[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optSeverity[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optSeverity[2].Name = "_optSeverity_2";
			optSeverity[2].TabIndex = 106;
			optSeverity[2].Text = "NON-URGENT";
			optSeverity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optSeverity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optSeverity[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optSeverity[1].Name = "_optSeverity_1";
			optSeverity[1].TabIndex = 105;
			optSeverity[1].Text = "URGENT";
			optSeverity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optSeverity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optSeverity[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optSeverity[0].Name = "_optSeverity_0";
			optSeverity[0].TabIndex = 104;
			optSeverity[0].Text = "FULL ARREST";
			txtTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>>(5);
			txtTime[4] = _txtTime_4;
			txtTime[3] = _txtTime_3;
			txtTime[2] = _txtTime_2;
			txtTime[1] = _txtTime_1;
			txtTime[0] = _txtTime_0;
			txtTime[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtTime[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtTime[0].Mask = "##:##";
			txtTime[0].Name = "_txtTime_0";
			txtTime[0].TabIndex = 34;
			txtTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtTime[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtTime[1].Mask = "##:##";
			txtTime[1].Name = "_txtTime_1";
			txtTime[1].TabIndex = 48;
			txtTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtTime[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtTime[2].Mask = "##:##";
			txtTime[2].Name = "_txtTime_2";
			txtTime[2].TabIndex = 62;
			txtTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtTime[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtTime[3].Mask = "##:##";
			txtTime[3].Name = "_txtTime_3";
			txtTime[3].TabIndex = 76;
			txtTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtTime[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtTime[4].Mask = "##:##";
			txtTime[4].Name = "_txtTime_4";
			txtTime[4].TabIndex = 90;
			cboVitalsPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboVitalsPosition[4] = _cboVitalsPosition_4;
			cboVitalsPosition[3] = _cboVitalsPosition_3;
			cboVitalsPosition[2] = _cboVitalsPosition_2;
			cboVitalsPosition[1] = _cboVitalsPosition_1;
			cboVitalsPosition[0] = _cboVitalsPosition_0;
			cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVitalsPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVitalsPosition[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVitalsPosition[0].Name = "_cboVitalsPosition_0";
			cboVitalsPosition[0].TabIndex = 35;
			cboVitalsPosition[0].Text = "cboVitalsPosition";
			cboVitalsPosition[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVitalsPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVitalsPosition[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVitalsPosition[1].Name = "_cboVitalsPosition_1";
			cboVitalsPosition[1].TabIndex = 49;
			cboVitalsPosition[1].Text = "cboVitalsPosition";
			cboVitalsPosition[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVitalsPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVitalsPosition[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVitalsPosition[2].Name = "_cboVitalsPosition_2";
			cboVitalsPosition[2].TabIndex = 63;
			cboVitalsPosition[2].Text = "cboVitalsPosition";
			cboVitalsPosition[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVitalsPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVitalsPosition[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVitalsPosition[3].Name = "_cboVitalsPosition_3";
			cboVitalsPosition[3].TabIndex = 77;
			cboVitalsPosition[3].Text = "cboVitalsPosition";
			cboVitalsPosition[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVitalsPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVitalsPosition[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVitalsPosition[4].Name = "_cboVitalsPosition_4";
			cboVitalsPosition[4].TabIndex = 91;
			cboVitalsPosition[4].Text = "cboVitalsPosition";
			txtPulse = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtPulse[4] = _txtPulse_4;
			txtPulse[3] = _txtPulse_3;
			txtPulse[2] = _txtPulse_2;
			txtPulse[1] = _txtPulse_1;
			txtPulse[0] = _txtPulse_0;
			txtPulse[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulse[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulse[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulse[0].Name = "_txtPulse_0";
			txtPulse[0].TabIndex = 37;
			txtPulse[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulse[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulse[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulse[1].Name = "_txtPulse_1";
			txtPulse[1].TabIndex = 51;
			txtPulse[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulse[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulse[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulse[2].Name = "_txtPulse_2";
			txtPulse[2].TabIndex = 65;
			txtPulse[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulse[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulse[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulse[3].Name = "_txtPulse_3";
			txtPulse[3].TabIndex = 79;
			txtPulse[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulse[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulse[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulse[4].Name = "_txtPulse_4";
			txtPulse[4].TabIndex = 93;
			txtRespiration = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtRespiration[4] = _txtRespiration_4;
			txtRespiration[3] = _txtRespiration_3;
			txtRespiration[2] = _txtRespiration_2;
			txtRespiration[1] = _txtRespiration_1;
			txtRespiration[0] = _txtRespiration_0;
			txtRespiration[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtRespiration[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtRespiration[0].Name = "_txtRespiration_0";
			txtRespiration[0].TabIndex = 36;
			txtRespiration[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtRespiration[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtRespiration[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtRespiration[1].Name = "_txtRespiration_1";
			txtRespiration[1].TabIndex = 50;
			txtRespiration[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtRespiration[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtRespiration[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtRespiration[2].Name = "_txtRespiration_2";
			txtRespiration[2].TabIndex = 64;
			txtRespiration[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtRespiration[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtRespiration[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtRespiration[3].Name = "_txtRespiration_3";
			txtRespiration[3].TabIndex = 78;
			txtRespiration[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtRespiration[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtRespiration[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtRespiration[4].Name = "_txtRespiration_4";
			txtRespiration[4].TabIndex = 92;
			txtSystolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtSystolic[4] = _txtSystolic_4;
			txtSystolic[3] = _txtSystolic_3;
			txtSystolic[2] = _txtSystolic_2;
			txtSystolic[1] = _txtSystolic_1;
			txtSystolic[0] = _txtSystolic_0;
			txtSystolic[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtSystolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtSystolic[0].Name = "_txtSystolic_0";
			txtSystolic[0].TabIndex = 39;
			txtSystolic[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtSystolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtSystolic[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtSystolic[1].Name = "_txtSystolic_1";
			txtSystolic[1].TabIndex = 53;
			txtSystolic[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtSystolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtSystolic[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtSystolic[2].Name = "_txtSystolic_2";
			txtSystolic[2].TabIndex = 67;
			txtSystolic[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtSystolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtSystolic[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtSystolic[3].Name = "_txtSystolic_3";
			txtSystolic[3].TabIndex = 81;
			txtSystolic[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtSystolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtSystolic[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtSystolic[4].Name = "_txtSystolic_4";
			txtSystolic[4].TabIndex = 95;
			txtDiastolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtDiastolic[4] = _txtDiastolic_4;
			txtDiastolic[3] = _txtDiastolic_3;
			txtDiastolic[2] = _txtDiastolic_2;
			txtDiastolic[1] = _txtDiastolic_1;
			txtDiastolic[0] = _txtDiastolic_0;
			txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtDiastolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtDiastolic[0].Name = "_txtDiastolic_0";
			txtDiastolic[0].TabIndex = 40;
			txtDiastolic[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtDiastolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtDiastolic[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtDiastolic[1].Name = "_txtDiastolic_1";
			txtDiastolic[1].TabIndex = 54;
			txtDiastolic[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtDiastolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtDiastolic[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtDiastolic[2].Name = "_txtDiastolic_2";
			txtDiastolic[2].TabIndex = 68;
			txtDiastolic[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtDiastolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtDiastolic[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtDiastolic[3].Name = "_txtDiastolic_3";
			txtDiastolic[3].TabIndex = 82;
			txtDiastolic[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtDiastolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtDiastolic[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtDiastolic[4].Name = "_txtDiastolic_4";
			txtDiastolic[4].TabIndex = 96;
			chkPalp = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(5);
			chkPalp[4] = _chkPalp_4;
			chkPalp[3] = _chkPalp_3;
			chkPalp[2] = _chkPalp_2;
			chkPalp[1] = _chkPalp_1;
			chkPalp[0] = _chkPalp_0;
			chkPalp[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			chkPalp[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			chkPalp[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			chkPalp[0].Name = "_chkPalp_0";
			chkPalp[0].TabIndex = 41;
			chkPalp[0].Text = "OR PALP";
			chkPalp[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			chkPalp[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			chkPalp[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			chkPalp[1].Name = "_chkPalp_1";
			chkPalp[1].TabIndex = 55;
			chkPalp[1].Text = "OR PALP";
			chkPalp[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			chkPalp[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			chkPalp[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			chkPalp[2].Name = "_chkPalp_2";
			chkPalp[2].TabIndex = 69;
			chkPalp[2].Text = "OR PALP";
			chkPalp[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			chkPalp[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			chkPalp[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			chkPalp[3].Name = "_chkPalp_3";
			chkPalp[3].TabIndex = 83;
			chkPalp[3].Text = "OR PALP";
			chkPalp[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			chkPalp[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			chkPalp[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			chkPalp[4].Name = "_chkPalp_4";
			chkPalp[4].TabIndex = 97;
			chkPalp[4].Text = "OR PALP";
			txtGlucose = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtGlucose[4] = _txtGlucose_4;
			txtGlucose[3] = _txtGlucose_3;
			txtGlucose[2] = _txtGlucose_2;
			txtGlucose[1] = _txtGlucose_1;
			txtGlucose[0] = _txtGlucose_0;
			txtGlucose[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtGlucose[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtGlucose[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtGlucose[0].Name = "_txtGlucose_0";
			txtGlucose[0].TabIndex = 42;
			txtGlucose[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtGlucose[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtGlucose[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtGlucose[1].Name = "_txtGlucose_1";
			txtGlucose[1].TabIndex = 56;
			txtGlucose[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtGlucose[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtGlucose[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtGlucose[2].Name = "_txtGlucose_2";
			txtGlucose[2].TabIndex = 70;
			txtGlucose[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtGlucose[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtGlucose[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtGlucose[3].Name = "_txtGlucose_3";
			txtGlucose[3].TabIndex = 84;
			txtGlucose[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtGlucose[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtGlucose[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtGlucose[4].Name = "_txtGlucose_4";
			txtGlucose[4].TabIndex = 98;
			txtPulseOxy = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtPulseOxy[4] = _txtPulseOxy_4;
			txtPulseOxy[3] = _txtPulseOxy_3;
			txtPulseOxy[2] = _txtPulseOxy_2;
			txtPulseOxy[1] = _txtPulseOxy_1;
			txtPulseOxy[0] = _txtPulseOxy_0;
			txtPulseOxy[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulseOxy[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulseOxy[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulseOxy[0].Name = "_txtPulseOxy_0";
			txtPulseOxy[0].TabIndex = 43;
			txtPulseOxy[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulseOxy[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulseOxy[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulseOxy[1].Name = "_txtPulseOxy_1";
			txtPulseOxy[1].TabIndex = 57;
			txtPulseOxy[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulseOxy[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulseOxy[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulseOxy[2].Name = "_txtPulseOxy_2";
			txtPulseOxy[2].TabIndex = 71;
			txtPulseOxy[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulseOxy[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulseOxy[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulseOxy[3].Name = "_txtPulseOxy_3";
			txtPulseOxy[3].TabIndex = 85;
			txtPulseOxy[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPulseOxy[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPulseOxy[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtPulseOxy[4].Name = "_txtPulseOxy_4";
			txtPulseOxy[4].TabIndex = 99;
			txtPerOxy = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtPerOxy[4] = _txtPerOxy_4;
			txtPerOxy[3] = _txtPerOxy_3;
			txtPerOxy[2] = _txtPerOxy_2;
			txtPerOxy[1] = _txtPerOxy_1;
			txtPerOxy[0] = _txtPerOxy_0;
			txtPerOxy[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPerOxy[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			txtPerOxy[0].Name = "_txtPerOxy_0";
			txtPerOxy[0].TabIndex = 44;
			txtPerOxy[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPerOxy[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPerOxy[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			txtPerOxy[1].Name = "_txtPerOxy_1";
			txtPerOxy[1].TabIndex = 58;
			txtPerOxy[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPerOxy[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPerOxy[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			txtPerOxy[2].Name = "_txtPerOxy_2";
			txtPerOxy[2].TabIndex = 72;
			txtPerOxy[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPerOxy[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPerOxy[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			txtPerOxy[3].Name = "_txtPerOxy_3";
			txtPerOxy[3].TabIndex = 86;
			txtPerOxy[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtPerOxy[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtPerOxy[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			txtPerOxy[4].Name = "_txtPerOxy_4";
			txtPerOxy[4].TabIndex = 100;
			cboECG = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboECG[4] = _cboECG_4;
			cboECG[3] = _cboECG_3;
			cboECG[2] = _cboECG_2;
			cboECG[1] = _cboECG_1;
			cboECG[0] = _cboECG_0;
			cboECG[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboECG[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboECG[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboECG[0].Name = "_cboECG_0";
			cboECG[0].TabIndex = 38;
			cboECG[0].Text = "cboECG";
			cboECG[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboECG[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboECG[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboECG[1].Name = "_cboECG_1";
			cboECG[1].TabIndex = 52;
			cboECG[1].Text = "cboECG";
			cboECG[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboECG[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboECG[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboECG[2].Name = "_cboECG_2";
			cboECG[2].TabIndex = 66;
			cboECG[2].Text = "cboECG";
			cboECG[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboECG[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboECG[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboECG[3].Name = "_cboECG_3";
			cboECG[3].TabIndex = 80;
			cboECG[3].Text = "cboECG";
			cboECG[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboECG[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboECG[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboECG[4].Name = "_cboECG_4";
			cboECG[4].TabIndex = 94;
			cboECG[4].Text = "cboECG";
			cboEyes = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboEyes[4] = _cboEyes_4;
			cboEyes[3] = _cboEyes_3;
			cboEyes[2] = _cboEyes_2;
			cboEyes[1] = _cboEyes_1;
			cboEyes[0] = _cboEyes_0;
			cboEyes[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboEyes[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboEyes[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboEyes[0].Name = "_cboEyes_0";
			cboEyes[0].TabIndex = 45;
			cboEyes[0].Text = "cboEyes";
			cboEyes[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboEyes[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboEyes[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboEyes[1].Name = "_cboEyes_1";
			cboEyes[1].TabIndex = 59;
			cboEyes[1].Text = "cboEyes";
			cboEyes[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboEyes[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboEyes[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboEyes[2].Name = "_cboEyes_2";
			cboEyes[2].TabIndex = 73;
			cboEyes[2].Text = "cboEyes";
			cboEyes[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboEyes[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboEyes[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboEyes[3].Name = "_cboEyes_3";
			cboEyes[3].TabIndex = 87;
			cboEyes[3].Text = "cboEyes";
			cboEyes[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboEyes[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboEyes[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboEyes[4].Name = "_cboEyes_4";
			cboEyes[4].TabIndex = 101;
			cboEyes[4].Text = "cboEyes";
			cboVerbal = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboVerbal[4] = _cboVerbal_4;
			cboVerbal[3] = _cboVerbal_3;
			cboVerbal[2] = _cboVerbal_2;
			cboVerbal[1] = _cboVerbal_1;
			cboVerbal[0] = _cboVerbal_0;
			cboVerbal[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVerbal[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVerbal[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVerbal[0].Name = "_cboVerbal_0";
			cboVerbal[0].TabIndex = 46;
			cboVerbal[0].Text = "cboVerbal";
			cboVerbal[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVerbal[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVerbal[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVerbal[1].Name = "_cboVerbal_1";
			cboVerbal[1].TabIndex = 60;
			cboVerbal[1].Text = "cboVerbal";
			cboVerbal[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVerbal[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVerbal[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVerbal[2].Name = "_cboVerbal_2";
			cboVerbal[2].TabIndex = 74;
			cboVerbal[2].Text = "cboVerbal";
			cboVerbal[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVerbal[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVerbal[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVerbal[3].Name = "_cboVerbal_3";
			cboVerbal[3].TabIndex = 88;
			cboVerbal[3].Text = "cboVerbal";
			cboVerbal[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboVerbal[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboVerbal[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboVerbal[4].Name = "_cboVerbal_4";
			cboVerbal[4].TabIndex = 102;
			cboVerbal[4].Text = "cboVerbal";
			cboMotor = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboMotor[4] = _cboMotor_4;
			cboMotor[3] = _cboMotor_3;
			cboMotor[2] = _cboMotor_2;
			cboMotor[1] = _cboMotor_1;
			cboMotor[0] = _cboMotor_0;
			cboMotor[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboMotor[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboMotor[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboMotor[0].Name = "_cboMotor_0";
			cboMotor[0].TabIndex = 47;
			cboMotor[0].Text = "cboMotor";
			cboMotor[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboMotor[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboMotor[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboMotor[1].Name = "_cboMotor_1";
			cboMotor[1].TabIndex = 61;
			cboMotor[1].Text = "cboMotor";
			cboMotor[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboMotor[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboMotor[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboMotor[2].Name = "_cboMotor_2";
			cboMotor[2].TabIndex = 75;
			cboMotor[2].Text = "cboMotor";
			cboMotor[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboMotor[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboMotor[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboMotor[3].Name = "_cboMotor_3";
			cboMotor[3].TabIndex = 89;
			cboMotor[3].Text = "cboMotor";
			cboMotor[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboMotor[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboMotor[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboMotor[4].Name = "_cboMotor_4";
			cboMotor[4].TabIndex = 103;
			cboMotor[4].Text = "cboMotor";
			this.chkSuccessful = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkSuccessful
			// 
			this.chkSuccessful.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkSuccessful.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkSuccessful.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkSuccessful.Name = "chkSuccessful";
			this.chkSuccessful.TabIndex = 116;
			this.chkSuccessful.Text = "SUCCESSFUL?";
			this.chkSalineLock = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkSalineLock
			// 
			this.chkSalineLock.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkSalineLock.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkSalineLock.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkSalineLock.Name = "chkSalineLock";
			this.chkSalineLock.TabIndex = 426;
			this.chkSalineLock.Text = "SALINE LOCK?";
			cboGauge = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboGauge[4] = _cboGauge_4;
			cboGauge[3] = _cboGauge_3;
			cboGauge[2] = _cboGauge_2;
			cboGauge[1] = _cboGauge_1;
			cboGauge[0] = _cboGauge_0;
			cboGauge[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboGauge[0].Enabled = false;
			cboGauge[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboGauge[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboGauge[0].Name = "_cboGauge_0";
			cboGauge[0].TabIndex = 129;
			cboGauge[0].Text = "cboGauge";
			cboGauge[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboGauge[1].Enabled = false;
			cboGauge[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboGauge[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboGauge[1].Name = "_cboGauge_1";
			cboGauge[1].TabIndex = 134;
			cboGauge[1].Text = "cboGauge";
			cboGauge[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboGauge[2].Enabled = false;
			cboGauge[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboGauge[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboGauge[2].Name = "_cboGauge_2";
			cboGauge[2].TabIndex = 139;
			cboGauge[2].Text = "cboGauge";
			cboGauge[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboGauge[3].Enabled = false;
			cboGauge[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboGauge[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboGauge[3].Name = "_cboGauge_3";
			cboGauge[3].TabIndex = 144;
			cboGauge[3].Text = "cboGauge";
			cboGauge[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboGauge[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboGauge[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboGauge[4].Name = "_cboGauge_4";
			cboGauge[4].TabIndex = 149;
			cboGauge[4].Text = "cboGauge";
			cboRoute = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboRoute[4] = _cboRoute_4;
			cboRoute[3] = _cboRoute_3;
			cboRoute[2] = _cboRoute_2;
			cboRoute[1] = _cboRoute_1;
			cboRoute[0] = _cboRoute_0;
			cboRoute[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRoute[0].Enabled = false;
			cboRoute[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRoute[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRoute[0].Name = "_cboRoute_0";
			cboRoute[0].TabIndex = 130;
			cboRoute[0].Text = "cboRoute";
			cboRoute[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRoute[1].Enabled = false;
			cboRoute[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRoute[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRoute[1].Name = "_cboRoute_1";
			cboRoute[1].TabIndex = 135;
			cboRoute[1].Text = "cboRoute";
			cboRoute[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRoute[2].Enabled = false;
			cboRoute[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRoute[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRoute[2].Name = "_cboRoute_2";
			cboRoute[2].TabIndex = 140;
			cboRoute[2].Text = "cboRoute";
			cboRoute[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRoute[3].Enabled = false;
			cboRoute[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRoute[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRoute[3].Name = "_cboRoute_3";
			cboRoute[3].TabIndex = 145;
			cboRoute[3].Text = "cboRoute";
			cboRoute[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRoute[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRoute[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRoute[4].Name = "_cboRoute_4";
			cboRoute[4].TabIndex = 150;
			cboRoute[4].Text = "cboRoute";
			cboRate = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboRate[4] = _cboRate_4;
			cboRate[3] = _cboRate_3;
			cboRate[2] = _cboRate_2;
			cboRate[1] = _cboRate_1;
			cboRate[0] = _cboRate_0;
			cboRate[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRate[0].Enabled = false;
			cboRate[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRate[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRate[0].Name = "_cboRate_0";
			cboRate[0].TabIndex = 131;
			cboRate[0].Text = "cboRate";
			cboRate[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRate[1].Enabled = false;
			cboRate[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRate[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRate[1].Name = "_cboRate_1";
			cboRate[1].TabIndex = 136;
			cboRate[1].Text = "cboRate";
			cboRate[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRate[2].Enabled = false;
			cboRate[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRate[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRate[2].Name = "_cboRate_2";
			cboRate[2].TabIndex = 141;
			cboRate[2].Text = "cboRate";
			cboRate[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRate[3].Enabled = false;
			cboRate[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRate[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRate[3].Name = "_cboRate_3";
			cboRate[3].TabIndex = 146;
			cboRate[3].Text = "cboRate";
			cboRate[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboRate[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboRate[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboRate[4].Name = "_cboRate_4";
			cboRate[4].TabIndex = 151;
			cboRate[4].Text = "cboRate";
			txtAmount = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel>>(5);
			txtAmount[4] = _txtAmount_4;
			txtAmount[3] = _txtAmount_3;
			txtAmount[2] = _txtAmount_2;
			txtAmount[1] = _txtAmount_1;
			txtAmount[0] = _txtAmount_0;
			txtAmount[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtAmount[0].Enabled = false;
			txtAmount[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtAmount[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtAmount[0].Name = "_txtAmount_0";
			txtAmount[0].TabIndex = 132;
			txtAmount[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtAmount[1].Enabled = false;
			txtAmount[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtAmount[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtAmount[1].Name = "_txtAmount_1";
			txtAmount[1].TabIndex = 137;
			txtAmount[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtAmount[2].Enabled = false;
			txtAmount[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtAmount[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtAmount[2].Name = "_txtAmount_2";
			txtAmount[2].TabIndex = 142;
			txtAmount[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtAmount[3].Enabled = false;
			txtAmount[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtAmount[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtAmount[3].Name = "_txtAmount_3";
			txtAmount[3].TabIndex = 147;
			txtAmount[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			txtAmount[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			txtAmount[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			txtAmount[4].Name = "_txtAmount_4";
			txtAmount[4].TabIndex = 152;
			cboSite = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(5);
			cboSite[4] = _cboSite_4;
			cboSite[3] = _cboSite_3;
			cboSite[2] = _cboSite_2;
			cboSite[1] = _cboSite_1;
			cboSite[0] = _cboSite_0;
			cboSite[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboSite[0].Enabled = false;
			cboSite[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboSite[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboSite[0].Name = "_cboSite_0";
			cboSite[0].TabIndex = 133;
			cboSite[0].Text = "cboSite";
			cboSite[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboSite[1].Enabled = false;
			cboSite[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboSite[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboSite[1].Name = "_cboSite_1";
			cboSite[1].TabIndex = 138;
			cboSite[1].Text = "cboSite";
			cboSite[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboSite[2].Enabled = false;
			cboSite[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboSite[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboSite[2].Name = "_cboSite_2";
			cboSite[2].TabIndex = 143;
			cboSite[2].Text = "cboSite";
			cboSite[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboSite[3].Enabled = false;
			cboSite[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboSite[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboSite[3].Name = "_cboSite_3";
			cboSite[3].TabIndex = 148;
			cboSite[3].Text = "cboSite";
			cboSite[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			cboSite[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			cboSite[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			cboSite[4].Name = "_cboSite_4";
			cboSite[4].TabIndex = 153;
			cboSite[4].Text = "cboSite";
			optMDorRN = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optMDorRN[1] = _optMDorRN_1;
			optMDorRN[0] = _optMDorRN_0;
			optMDorRN[2] = _optMDorRN_2;
			optMDorRN[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optMDorRN[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optMDorRN[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optMDorRN[1].Name = "_optMDorRN_1";
			optMDorRN[1].TabIndex = 157;
			optMDorRN[1].Text = "RN";
			optMDorRN[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optMDorRN[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optMDorRN[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optMDorRN[0].Name = "_optMDorRN_0";
			optMDorRN[0].TabIndex = 156;
			optMDorRN[0].Text = "MD";
			optMDorRN[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optMDorRN[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optMDorRN[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optMDorRN[2].Name = "_optMDorRN_2";
			optMDorRN[2].TabIndex = 158;
			optMDorRN[2].Text = "OTHER";
			this.chkDiverted = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkDiverted
			// 
			this.chkDiverted.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkDiverted.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkDiverted.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkDiverted.Name = "chkDiverted";
			this.chkDiverted.TabIndex = 163;
			this.chkDiverted.Text = "DIVERTED?";
			this.chkCPRTrained = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkCPRTrained
			// 
			this.chkCPRTrained.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkCPRTrained.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkCPRTrained.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkCPRTrained.Name = "chkCPRTrained";
			this.chkCPRTrained.TabIndex = 172;
			this.chkCPRTrained.Text = "CPR TRAINED?";
			this.chkWitnessedArrest = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkWitnessedArrest
			// 
			this.chkWitnessedArrest.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkWitnessedArrest.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkWitnessedArrest.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.chkWitnessedArrest.Name = "chkWitnessedArrest";
			this.chkWitnessedArrest.TabIndex = 173;
			this.chkWitnessedArrest.Text = "WITNESSED ARREST?";
			this.chkPulseRestored = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			// 
			// chkPulseRestored
			// 
			this.chkPulseRestored.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.chkPulseRestored.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.chkPulseRestored.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.chkPulseRestored.Name = "chkPulseRestored";
			this.chkPulseRestored.TabIndex = 189;
			this.chkPulseRestored.Text = "PULSE RESTORED?";
			optArrestToCPR = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optArrestToCPR[3] = _optArrestToCPR_3;
			optArrestToCPR[2] = _optArrestToCPR_2;
			optArrestToCPR[1] = _optArrestToCPR_1;
			optArrestToCPR[0] = _optArrestToCPR_0;
			optArrestToCPR[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToCPR[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToCPR[3].Name = "_optArrestToCPR_3";
			optArrestToCPR[3].TabIndex = 180;
			optArrestToCPR[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToCPR[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToCPR[2].Name = "_optArrestToCPR_2";
			optArrestToCPR[2].TabIndex = 179;
			optArrestToCPR[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToCPR[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToCPR[1].Name = "_optArrestToCPR_1";
			optArrestToCPR[1].TabIndex = 178;
			optArrestToCPR[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToCPR[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optArrestToCPR[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToCPR[0].Name = "_optArrestToCPR_0";
			optArrestToCPR[0].TabIndex = 177;
			optArrestToCPR[0].Text = "ARREST TO CPR";
			optArrestToALS = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optArrestToALS[0] = _optArrestToALS_0;
			optArrestToALS[1] = _optArrestToALS_1;
			optArrestToALS[2] = _optArrestToALS_2;
			optArrestToALS[3] = _optArrestToALS_3;
			optArrestToALS[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToALS[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optArrestToALS[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToALS[0].Name = "_optArrestToALS_0";
			optArrestToALS[0].TabIndex = 181;
			optArrestToALS[0].Text = "ARREST TO ALS";
			optArrestToALS[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToALS[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToALS[1].Name = "_optArrestToALS_1";
			optArrestToALS[1].TabIndex = 182;
			optArrestToALS[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToALS[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToALS[2].Name = "_optArrestToALS_2";
			optArrestToALS[2].TabIndex = 183;
			optArrestToALS[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToALS[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToALS[3].Name = "_optArrestToALS_3";
			optArrestToALS[3].TabIndex = 184;
			optArrestToShock = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(4);
			optArrestToShock[3] = _optArrestToShock_3;
			optArrestToShock[2] = _optArrestToShock_2;
			optArrestToShock[1] = _optArrestToShock_1;
			optArrestToShock[0] = _optArrestToShock_0;
			optArrestToShock[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToShock[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToShock[3].Name = "_optArrestToShock_3";
			optArrestToShock[3].TabIndex = 188;
			optArrestToShock[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToShock[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToShock[2].Name = "_optArrestToShock_2";
			optArrestToShock[2].TabIndex = 187;
			optArrestToShock[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToShock[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToShock[1].Name = "_optArrestToShock_1";
			optArrestToShock[1].TabIndex = 186;
			optArrestToShock[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			optArrestToShock[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optArrestToShock[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			optArrestToShock[0].Name = "_optArrestToShock_0";
			optArrestToShock[0].TabIndex = 185;
			optArrestToShock[0].Text = "ARREST TO SHOCK";
			this.EMSType = 0;
			this.ReportLogID = 0;
			this.ExtricationSwitch = 0;
			lbVitalsID = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbVitalsID[4] = _lbVitalsID_4;
			lbVitalsID[3] = _lbVitalsID_3;
			lbVitalsID[2] = _lbVitalsID_2;
			lbVitalsID[1] = _lbVitalsID_1;
			lbVitalsID[0] = _lbVitalsID_0;
			lbVitalsID[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbVitalsID[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbVitalsID[0].Name = "_lbVitalsID_0";
			lbVitalsID[0].TabIndex = 329;
			lbVitalsID[0].Visible = false;
			lbVitalsID[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbVitalsID[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbVitalsID[1].Name = "_lbVitalsID_1";
			lbVitalsID[1].TabIndex = 356;
			lbVitalsID[1].Visible = false;
			lbVitalsID[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbVitalsID[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbVitalsID[2].Name = "_lbVitalsID_2";
			lbVitalsID[2].TabIndex = 371;
			lbVitalsID[2].Visible = false;
			lbVitalsID[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbVitalsID[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbVitalsID[3].Name = "_lbVitalsID_3";
			lbVitalsID[3].TabIndex = 388;
			lbVitalsID[3].Visible = false;
			lbVitalsID[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbVitalsID[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbVitalsID[4].Name = "_lbVitalsID_4";
			lbVitalsID[4].TabIndex = 404;
			lbVitalsID[4].Visible = false;
			lbIVID = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbIVID[4] = _lbIVID_4;
			lbIVID[3] = _lbIVID_3;
			lbIVID[2] = _lbIVID_2;
			lbIVID[1] = _lbIVID_1;
			lbIVID[0] = _lbIVID_0;
			lbIVID[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbIVID[0].Enabled = false;
			lbIVID[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbIVID[0].Name = "_lbIVID_0";
			lbIVID[0].TabIndex = 260;
			lbIVID[0].Visible = false;
			lbIVID[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbIVID[1].Enabled = false;
			lbIVID[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbIVID[1].Name = "_lbIVID_1";
			lbIVID[1].TabIndex = 261;
			lbIVID[1].Visible = false;
			lbIVID[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbIVID[2].Enabled = false;
			lbIVID[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbIVID[2].Name = "_lbIVID_2";
			lbIVID[2].TabIndex = 262;
			lbIVID[2].Visible = false;
			lbIVID[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbIVID[3].Enabled = false;
			lbIVID[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbIVID[3].Name = "_lbIVID_3";
			lbIVID[3].TabIndex = 263;
			lbIVID[3].Visible = false;
			lbIVID[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			lbIVID[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			lbIVID[4].Name = "_lbIVID_4";
			lbIVID[4].TabIndex = 264;
			lbIVID[4].Visible = false;
			this.TraumaSwitch = 0;
			this.CPRSwitch = 0;
			this.NarrationRequired = 0;
			lbPInfo = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(66);
			lbPInfo[34] = _lbPInfo_34;
			lbPInfo[65] = _lbPInfo_65;
			lbPInfo[56] = _lbPInfo_56;
			lbPInfo[55] = _lbPInfo_55;
			lbPInfo[54] = _lbPInfo_54;
			lbPInfo[57] = _lbPInfo_57;
			lbPInfo[58] = _lbPInfo_58;
			lbPInfo[59] = _lbPInfo_59;
			lbPInfo[64] = _lbPInfo_64;
			lbPInfo[0] = _lbPInfo_0;
			lbPInfo[4] = _lbPInfo_4;
			lbPInfo[3] = _lbPInfo_3;
			lbPInfo[2] = _lbPInfo_2;
			lbPInfo[1] = _lbPInfo_1;
			lbPInfo[50] = _lbPInfo_50;
			lbPInfo[51] = _lbPInfo_51;
			lbPInfo[49] = _lbPInfo_49;
			lbPInfo[53] = _lbPInfo_53;
			lbPInfo[52] = _lbPInfo_52;
			lbPInfo[44] = _lbPInfo_44;
			lbPInfo[43] = _lbPInfo_43;
			lbPInfo[45] = _lbPInfo_45;
			lbPInfo[46] = _lbPInfo_46;
			lbPInfo[48] = _lbPInfo_48;
			lbPInfo[47] = _lbPInfo_47;
			lbPInfo[39] = _lbPInfo_39;
			lbPInfo[38] = _lbPInfo_38;
			lbPInfo[40] = _lbPInfo_40;
			lbPInfo[41] = _lbPInfo_41;
			lbPInfo[42] = _lbPInfo_42;
			lbPInfo[37] = _lbPInfo_37;
			lbPInfo[36] = _lbPInfo_36;
			lbPInfo[32] = _lbPInfo_32;
			lbPInfo[31] = _lbPInfo_31;
			lbPInfo[29] = _lbPInfo_29;
			lbPInfo[28] = _lbPInfo_28;
			lbPInfo[30] = _lbPInfo_30;
			lbPInfo[26] = _lbPInfo_26;
			lbPInfo[25] = _lbPInfo_25;
			lbPInfo[27] = _lbPInfo_27;
			lbPInfo[20] = _lbPInfo_20;
			lbPInfo[18] = _lbPInfo_18;
			lbPInfo[7] = _lbPInfo_7;
			lbPInfo[17] = _lbPInfo_17;
			lbPInfo[19] = _lbPInfo_19;
			lbPInfo[9] = _lbPInfo_9;
			lbPInfo[16] = _lbPInfo_16;
			lbPInfo[5] = _lbPInfo_5;
			lbPInfo[6] = _lbPInfo_6;
			lbPInfo[8] = _lbPInfo_8;
			lbPInfo[15] = _lbPInfo_15;
			lbPInfo[14] = _lbPInfo_14;
			lbPInfo[35] = _lbPInfo_35;
			lbPInfo[33] = _lbPInfo_33;
			lbPInfo[21] = _lbPInfo_21;
			lbPInfo[22] = _lbPInfo_22;
			lbPInfo[11] = _lbPInfo_11;
			lbPInfo[10] = _lbPInfo_10;
			lbPInfo[12] = _lbPInfo_12;
			lbPInfo[13] = _lbPInfo_13;
			lbPInfo[63] = _lbPInfo_63;
			lbPInfo[62] = _lbPInfo_62;
			lbPInfo[61] = _lbPInfo_61;
			lbPInfo[60] = _lbPInfo_60;
			lbPInfo[23] = _lbPInfo_23;
			lbPInfo[24] = _lbPInfo_24;
			lbPInfo[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[11].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[11].Name = "_lbPInfo_11";
			lbPInfo[11].TabIndex = 218;
			lbPInfo[11].Text = "OR";
			lbPInfo[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[10].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[10].Name = "_lbPInfo_10";
			lbPInfo[10].TabIndex = 217;
			lbPInfo[10].Text = "BIRTHDATE";
			lbPInfo[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[12].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[12].Name = "_lbPInfo_12";
			lbPInfo[12].TabIndex = 216;
			lbPInfo[12].Text = "AGE";
			lbPInfo[13].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[13].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[13].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[13].Name = "_lbPInfo_13";
			lbPInfo[13].TabIndex = 215;
			lbPInfo[13].Text = "AGE UNITS";
			lbPInfo[18].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[18].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[18].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[18].Name = "_lbPInfo_18";
			lbPInfo[18].TabIndex = 279;
			lbPInfo[18].Text = "SSN#";
			lbPInfo[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[7].Name = "_lbPInfo_7";
			lbPInfo[7].TabIndex = 278;
			lbPInfo[7].Text = "BILLING ADDRESS";
			lbPInfo[17].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[17].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[17].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[17].Name = "_lbPInfo_17";
			lbPInfo[17].TabIndex = 277;
			lbPInfo[17].Text = "ZIPCODE";
			lbPInfo[19].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[19].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[19].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[19].Name = "_lbPInfo_19";
			lbPInfo[19].TabIndex = 276;
			lbPInfo[19].Text = "M.I.";
			lbPInfo[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[9].Name = "_lbPInfo_9";
			lbPInfo[9].TabIndex = 275;
			lbPInfo[9].Text = "CITY";
			lbPInfo[16].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[16].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[16].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[16].Name = "_lbPInfo_16";
			lbPInfo[16].TabIndex = 274;
			lbPInfo[16].Text = "STATE";
			lbPInfo[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[5].Name = "_lbPInfo_5";
			lbPInfo[5].TabIndex = 273;
			lbPInfo[5].Text = "FIRST NAME";
			lbPInfo[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[6].Name = "_lbPInfo_6";
			lbPInfo[6].TabIndex = 272;
			lbPInfo[6].Text = "LAST NAME";
			lbPInfo[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[8].Name = "_lbPInfo_8";
			lbPInfo[8].TabIndex = 271;
			lbPInfo[8].Text = "HOME PHONE";
			lbPInfo[15].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[15].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[15].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[15].Name = "_lbPInfo_15";
			lbPInfo[15].TabIndex = 269;
			lbPInfo[15].Text = "POSSIBLE FACTORS IMPACTING CARE";
			lbPInfo[14].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[14].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[14].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[14].Name = "_lbPInfo_14";
			lbPInfo[14].TabIndex = 268;
			lbPInfo[14].Text = "PRIOR MEDICAL HISTORY";
			lbPInfo[21].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[21].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[21].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[21].Name = "_lbPInfo_21";
			lbPInfo[21].TabIndex = 226;
			lbPInfo[21].Text = "INJURY TYPE";
			lbPInfo[22].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[22].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[22].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[22].Name = "_lbPInfo_22";
			lbPInfo[22].TabIndex = 225;
			lbPInfo[22].Text = "BODY PART";
			lbPInfo[20].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[20].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[20].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[20].Name = "_lbPInfo_20";
			lbPInfo[20].TabIndex = 281;
			lbPInfo[20].Text = "MECH CODE";
			lbPInfo[24].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[24].Enabled = false;
			lbPInfo[24].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[24].Name = "_lbPInfo_24";
			lbPInfo[24].TabIndex = 229;
			lbPInfo[24].Text = "ALS PROCEDURES";
			lbPInfo[23].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[23].Enabled = false;
			lbPInfo[23].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[23].Name = "_lbPInfo_23";
			lbPInfo[23].TabIndex = 230;
			lbPInfo[23].Text = "BLS PROCEDURES";
			lbPInfo[31].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[31].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[31].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[31].Name = "_lbPInfo_31";
			lbPInfo[31].TabIndex = 288;
			lbPInfo[31].Text = "ATTEMPTS";
			lbPInfo[29].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[29].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[29].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[29].Name = "_lbPInfo_29";
			lbPInfo[29].TabIndex = 291;
			lbPInfo[29].Text = "Enter Other ALS Procedures";
			lbPInfo[29].Visible = false;
			lbPInfo[28].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[28].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[28].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[28].Name = "_lbPInfo_28";
			lbPInfo[28].TabIndex = 290;
			lbPInfo[28].Text = "Select ALS Procedures";
			lbPInfo[30].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[30].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[30].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[30].Name = "_lbPInfo_30";
			lbPInfo[30].TabIndex = 289;
			lbPInfo[30].Text = "Select ALS Personnel";
			lbPInfo[26].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[26].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[26].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[26].Name = "_lbPInfo_26";
			lbPInfo[26].TabIndex = 285;
			lbPInfo[26].Text = "Enter Other BLS Procedures";
			lbPInfo[26].Visible = false;
			lbPInfo[25].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[25].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[25].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[25].Name = "_lbPInfo_25";
			lbPInfo[25].TabIndex = 284;
			lbPInfo[25].Text = "Select BLS OTEP Procedure";
			lbPInfo[27].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[27].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[27].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[27].Name = "_lbPInfo_27";
			lbPInfo[27].TabIndex = 283;
			lbPInfo[27].Text = "Select BLS Personnel";
			lbPInfo[34].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[34].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			lbPInfo[34].Name = "_lbPInfo_34";
			lbPInfo[34].TabIndex = 425;
			lbPInfo[34].Text = "IV LINES";
			lbPInfo[36].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[36].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[36].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[36].Name = "_lbPInfo_36";
			lbPInfo[36].TabIndex = 294;
			lbPInfo[36].Text = "TREATMENT AUTHORIZATION";
			lbPInfo[32].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[32].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[32].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[32].Name = "_lbPInfo_32";
			lbPInfo[32].TabIndex = 293;
			lbPInfo[32].Text = "Extrication Time (MIN)";
			lbPInfo[35].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[35].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			lbPInfo[35].Name = "_lbPInfo_35";
			lbPInfo[35].TabIndex = 259;
			lbPInfo[35].Text = "MEDICATION";
			lbPInfo[33].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[33].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[33].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[33].Name = "_lbPInfo_33";
			lbPInfo[33].TabIndex = 258;
			lbPInfo[33].Text = "DOSAGE ADMINISTERED";
			lbPInfo[39].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[39].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[39].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[39].Name = "_lbPInfo_39";
			lbPInfo[39].TabIndex = 350;
			lbPInfo[39].Text = "TRANSPORT TO";
			lbPInfo[38].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[38].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[38].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[38].Name = "_lbPInfo_38";
			lbPInfo[38].TabIndex = 349;
			lbPInfo[38].Text = "TRANSPORT BY";
			lbPInfo[40].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[40].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[40].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[40].Name = "_lbPInfo_40";
			lbPInfo[40].TabIndex = 300;
			lbPInfo[40].Text = "TRANSPORT FROM";
			lbPInfo[41].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[41].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[41].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[41].Name = "_lbPInfo_41";
			lbPInfo[41].TabIndex = 299;
			lbPInfo[41].Text = "MILEAGE";
			lbPInfo[42].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[42].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[42].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[42].Name = "_lbPInfo_42";
			lbPInfo[42].TabIndex = 298;
			lbPInfo[42].Text = "HOSPITAL CHOSEN BY";
			lbPInfo[37].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[37].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[37].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[37].Name = "_lbPInfo_37";
			lbPInfo[37].TabIndex = 297;
			lbPInfo[37].Text = "BASE STATION CONTACT";
			lbPInfo[44].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[44].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[44].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[44].Name = "_lbPInfo_44";
			lbPInfo[44].TabIndex = 307;
			lbPInfo[44].Text = "STEP III - BIOMECHANICS/OTHER RISK FACTORS";
			lbPInfo[43].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[43].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[43].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[43].Name = "_lbPInfo_43";
			lbPInfo[43].TabIndex = 306;
			lbPInfo[43].Text = "PATIENT LOCATION";
			lbPInfo[45].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[45].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[45].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[45].Name = "_lbPInfo_45";
			lbPInfo[45].TabIndex = 305;
			lbPInfo[45].Text = "PROTECTIVE DEVICE";
			lbPInfo[46].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[46].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[46].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[46].Name = "_lbPInfo_46";
			lbPInfo[46].TabIndex = 304;
			lbPInfo[46].Text = "TRAUMA ID#";
			lbPInfo[48].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[48].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[48].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[48].Name = "_lbPInfo_48";
			lbPInfo[48].TabIndex = 303;
			lbPInfo[48].Text = "STEP II - ANATOMY OF INJURY";
			lbPInfo[47].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[47].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[47].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[47].Name = "_lbPInfo_47";
			lbPInfo[47].TabIndex = 302;
			lbPInfo[47].Text = "STEP I - VITAL SIGNS";
			lbPInfo[50].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[50].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[50].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[50].Name = "_lbPInfo_50";
			lbPInfo[50].TabIndex = 316;
			lbPInfo[50].Text = "TIMES IN MINUTES";
			lbPInfo[51].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[51].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[51].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[51].Name = "_lbPInfo_51";
			lbPInfo[51].TabIndex = 315;
			lbPInfo[51].Text = "<4     4-8   8-15 >15";
			lbPInfo[49].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[49].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[49].Name = "_lbPInfo_49";
			lbPInfo[49].TabIndex = 314;
			lbPInfo[49].Text = "CPR PATIENT INFORMATION";
			lbPInfo[53].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[53].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[53].Name = "_lbPInfo_53";
			lbPInfo[53].TabIndex = 310;
			lbPInfo[53].Text = "CPR DETAIL INFORMATION";
			lbPInfo[52].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[52].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[52].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[52].Name = "_lbPInfo_52";
			lbPInfo[52].TabIndex = 309;
			lbPInfo[52].Text = "SELECT INDIVIDUALS WHO PERFORMED CPR";
			lbPInfo[61].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[61].Enabled = false;
			lbPInfo[61].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[61].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[61].Name = "_lbPInfo_61";
			lbPInfo[61].TabIndex = 443;
			lbPInfo[61].Text = "FIRST NAME";
			lbPInfo[62].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[62].Enabled = false;
			lbPInfo[62].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[62].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[62].Name = "_lbPInfo_62";
			lbPInfo[62].TabIndex = 444;
			lbPInfo[62].Text = "LAST NAME";
			lbPInfo[60].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[60].Enabled = false;
			lbPInfo[60].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[60].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[60].Name = "_lbPInfo_60";
			lbPInfo[60].TabIndex = 442;
			lbPInfo[60].Text = "M.I.";
			lbPInfo[63].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[63].Enabled = false;
			lbPInfo[63].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[63].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[63].Name = "_lbPInfo_63";
			lbPInfo[63].TabIndex = 445;
			lbPInfo[63].Text = "HOME PHONE";
			lbPInfo[64].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[64].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[64].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[64].Name = "_lbPInfo_64";
			lbPInfo[64].TabIndex = 446;
			lbPInfo[64].Text = "OR";
			lbPInfo[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPInfo[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[0].Name = "_lbPInfo_0";
			lbPInfo[0].TabIndex = 437;
			lbPInfo[0].Text = "BIRTHDATE";
			lbPInfo[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[4].Name = "_lbPInfo_4";
			lbPInfo[4].TabIndex = 323;
			lbPInfo[4].Text = "SERVICE PROVIDED";
			lbPInfo[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[3].Name = "_lbPInfo_3";
			lbPInfo[3].TabIndex = 322;
			lbPInfo[3].Text = "RACE";
			lbPInfo[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[2].Name = "_lbPInfo_2";
			lbPInfo[2].TabIndex = 321;
			lbPInfo[2].Text = "AGE UNITS";
			lbPInfo[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[1].Name = "_lbPInfo_1";
			lbPInfo[1].TabIndex = 320;
			lbPInfo[1].Text = "AGE";
			lbPInfo[54].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[54].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[54].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[54].Name = "_lbPInfo_54";
			lbPInfo[54].TabIndex = 428;
			lbPInfo[54].Text = "INCIDENT ZIPCODE";
			lbPInfo[57].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[57].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[57].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[57].Name = "_lbPInfo_57";
			lbPInfo[57].TabIndex = 327;
			lbPInfo[57].Text = "RESEARCH CODE";
			lbPInfo[58].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[58].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[58].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[58].Name = "_lbPInfo_58";
			lbPInfo[58].TabIndex = 326;
			lbPInfo[58].Text = "INCIDENT SETTING";
			lbPInfo[59].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[59].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[59].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[59].Name = "_lbPInfo_59";
			lbPInfo[59].TabIndex = 325;
			lbPInfo[59].Text = "INCIDENT LOCATION";
			lbPInfo[65].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[65].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[65].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[65].Name = "_lbPInfo_65";
			lbPInfo[65].TabIndex = 447;
			lbPInfo[56].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[56].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[56].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[56].Name = "_lbPInfo_56";
			lbPInfo[56].TabIndex = 435;
			lbPInfo[56].Text = "Select Narration Author";
			lbPInfo[55].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbPInfo[55].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPInfo[55].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPInfo[55].Name = "_lbPInfo_55";
			lbPInfo[55].TabIndex = 344;
			lbPInfo[55].Text = "EMS PATIENT CONTACT NARRATION - Author:";
			this.ReqNarrString = "";
			this.frmBasicGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmBasicGender
			// 
			this.frmBasicGender.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmBasicGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmBasicGender.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmBasicGender.Name = "frmBasicGender";
			this.frmBasicGender.TabIndex = 318;
			this.frmBasicGender.Text = "GENDER";
			this.frmGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmGender
			// 
			this.frmGender.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmGender.Enabled = false;
			this.frmGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmGender.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmGender.Name = "frmGender";
			this.frmGender.TabIndex = 213;
			this.frmGender.Text = "GENDER";
			this.NoVitals = 0;
			this.frmSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmSeverity
			// 
			this.frmSeverity.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmSeverity.Enabled = false;
			this.frmSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmSeverity.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmSeverity.Name = "frmSeverity";
			this.frmSeverity.TabIndex = 423;
			this.frmSeverity.Text = "Severity";
			this.IVSwitch = 0;
			this.cmdMore = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMore
			// 
			this.cmdMore.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMore.Enabled = false;
			this.cmdMore.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdMore.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMore.Name = "cmdMore";
			this.cmdMore.TabIndex = 413;
			this.cmdMore.Text = "More...";
			this.cmdMoreIVs = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdMoreIVs
			// 
			this.cmdMoreIVs.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdMoreIVs.Enabled = false;
			this.cmdMoreIVs.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdMoreIVs.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdMoreIVs.Name = "cmdMoreIVs";
			this.cmdMoreIVs.TabIndex = 154;
			this.cmdMoreIVs.Text = "More...";
			this.ExtricationTime = 0;
			this.frmALSAttempts = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmALSAttempts
			// 
			this.frmALSAttempts.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmALSAttempts.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmALSAttempts.Name = "frmALSAttempts";
			this.frmALSAttempts.TabIndex = 287;
			this.frmALSAttempts.Visible = false;
			this.frmInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmInjury
			// 
			this.frmInjury.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmInjury.Enabled = false;
			this.frmInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmInjury.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmInjury.Name = "frmInjury";
			this.frmInjury.TabIndex = 223;
			this.frmInjury.Text = "Injury";
			this.frmIllness = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmIllness
			// 
			this.frmIllness.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			this.frmIllness.Enabled = false;
			this.frmIllness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.frmIllness.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.frmIllness.Name = "frmIllness";
			this.frmIllness.TabIndex = 222;
			this.frmIllness.Text = "Primary Illness";
			lbVitalsTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbVitalsTime[4] = _lbVitalsTime_4;
			lbVitalsTime[3] = _lbVitalsTime_3;
			lbVitalsTime[2] = _lbVitalsTime_2;
			lbVitalsTime[1] = _lbVitalsTime_1;
			lbVitalsTime[0] = _lbVitalsTime_0;
			lbVitalsTime[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsTime[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsTime[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsTime[0].Name = "_lbVitalsTime_0";
			lbVitalsTime[0].TabIndex = 334;
			lbVitalsTime[0].Text = "TIME";
			lbVitalsTime[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsTime[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsTime[1].Name = "_lbVitalsTime_1";
			lbVitalsTime[1].TabIndex = 357;
			lbVitalsTime[1].Text = "TIME";
			lbVitalsTime[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsTime[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsTime[2].Name = "_lbVitalsTime_2";
			lbVitalsTime[2].TabIndex = 372;
			lbVitalsTime[2].Text = "TIME";
			lbVitalsTime[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsTime[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsTime[3].Name = "_lbVitalsTime_3";
			lbVitalsTime[3].TabIndex = 389;
			lbVitalsTime[3].Text = "TIME";
			lbVitalsTime[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsTime[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsTime[4].Name = "_lbVitalsTime_4";
			lbVitalsTime[4].TabIndex = 405;
			lbVitalsTime[4].Text = "TIME";
			lbVitalsPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbVitalsPosition[4] = _lbVitalsPosition_4;
			lbVitalsPosition[3] = _lbVitalsPosition_3;
			lbVitalsPosition[2] = _lbVitalsPosition_2;
			lbVitalsPosition[1] = _lbVitalsPosition_1;
			lbVitalsPosition[0] = _lbVitalsPosition_0;
			lbVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsPosition[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsPosition[0].Name = "_lbVitalsPosition_0";
			lbVitalsPosition[0].TabIndex = 342;
			lbVitalsPosition[0].Text = "VITALS POSITION";
			lbVitalsPosition[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsPosition[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsPosition[1].Name = "_lbVitalsPosition_1";
			lbVitalsPosition[1].TabIndex = 364;
			lbVitalsPosition[1].Text = "VITALS POSITION";
			lbVitalsPosition[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsPosition[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsPosition[2].Name = "_lbVitalsPosition_2";
			lbVitalsPosition[2].TabIndex = 377;
			lbVitalsPosition[2].Text = "VITALS POSITION";
			lbVitalsPosition[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsPosition[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsPosition[3].Name = "_lbVitalsPosition_3";
			lbVitalsPosition[3].TabIndex = 396;
			lbVitalsPosition[3].Text = "VITALS POSITION";
			lbVitalsPosition[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVitalsPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVitalsPosition[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVitalsPosition[4].Name = "_lbVitalsPosition_4";
			lbVitalsPosition[4].TabIndex = 412;
			lbVitalsPosition[4].Text = "VITALS POSITION";
			lbVerbal = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbVerbal[4] = _lbVerbal_4;
			lbVerbal[3] = _lbVerbal_3;
			lbVerbal[2] = _lbVerbal_2;
			lbVerbal[1] = _lbVerbal_1;
			lbVerbal[0] = _lbVerbal_0;
			lbVerbal[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVerbal[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVerbal[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVerbal[0].Name = "_lbVerbal_0";
			lbVerbal[0].TabIndex = 332;
			lbVerbal[0].Text = "VERBAL";
			lbVerbal[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVerbal[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVerbal[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVerbal[1].Name = "_lbVerbal_1";
			lbVerbal[1].TabIndex = 367;
			lbVerbal[1].Text = "VERBAL";
			lbVerbal[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVerbal[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVerbal[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVerbal[2].Name = "_lbVerbal_2";
			lbVerbal[2].TabIndex = 381;
			lbVerbal[2].Text = "VERBAL";
			lbVerbal[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVerbal[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVerbal[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVerbal[3].Name = "_lbVerbal_3";
			lbVerbal[3].TabIndex = 399;
			lbVerbal[3].Text = "VERBAL";
			lbVerbal[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbVerbal[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbVerbal[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbVerbal[4].Name = "_lbVerbal_4";
			lbVerbal[4].TabIndex = 416;
			lbVerbal[4].Text = "VERBAL";
			lbSystolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbSystolic[4] = _lbSystolic_4;
			lbSystolic[3] = _lbSystolic_3;
			lbSystolic[2] = _lbSystolic_2;
			lbSystolic[1] = _lbSystolic_1;
			lbSystolic[0] = _lbSystolic_0;
			lbSystolic[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSystolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSystolic[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSystolic[0].Name = "_lbSystolic_0";
			lbSystolic[0].TabIndex = 337;
			lbSystolic[0].Text = "SYSTOLIC";
			lbSystolic[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSystolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSystolic[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSystolic[1].Name = "_lbSystolic_1";
			lbSystolic[1].TabIndex = 360;
			lbSystolic[1].Text = "SYSTOLIC";
			lbSystolic[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSystolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSystolic[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSystolic[2].Name = "_lbSystolic_2";
			lbSystolic[2].TabIndex = 375;
			lbSystolic[2].Text = "SYSTOLIC";
			lbSystolic[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSystolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSystolic[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSystolic[3].Name = "_lbSystolic_3";
			lbSystolic[3].TabIndex = 392;
			lbSystolic[3].Text = "SYSTOLIC";
			lbSystolic[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbSystolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSystolic[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSystolic[4].Name = "_lbSystolic_4";
			lbSystolic[4].TabIndex = 408;
			lbSystolic[4].Text = "SYSTOLIC";
			lbSite = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbSite[4] = _lbSite_4;
			lbSite[3] = _lbSite_3;
			lbSite[2] = _lbSite_2;
			lbSite[1] = _lbSite_1;
			lbSite[0] = _lbSite_0;
			lbSite[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbSite[0].Enabled = false;
			lbSite[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSite[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSite[0].Name = "_lbSite_0";
			lbSite[0].TabIndex = 236;
			lbSite[0].Text = "SITE";
			lbSite[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbSite[1].Enabled = false;
			lbSite[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSite[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSite[1].Name = "_lbSite_1";
			lbSite[1].TabIndex = 241;
			lbSite[1].Text = "SITE";
			lbSite[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbSite[2].Enabled = false;
			lbSite[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSite[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSite[2].Name = "_lbSite_2";
			lbSite[2].TabIndex = 246;
			lbSite[2].Text = "SITE";
			lbSite[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbSite[3].Enabled = false;
			lbSite[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSite[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSite[3].Name = "_lbSite_3";
			lbSite[3].TabIndex = 251;
			lbSite[3].Text = "SITE";
			lbSite[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbSite[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbSite[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbSite[4].Name = "_lbSite_4";
			lbSite[4].TabIndex = 256;
			lbSite[4].Text = "SITE";
			lbRoute = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbRoute[4] = _lbRoute_4;
			lbRoute[3] = _lbRoute_3;
			lbRoute[2] = _lbRoute_2;
			lbRoute[1] = _lbRoute_1;
			lbRoute[0] = _lbRoute_0;
			lbRoute[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRoute[0].Enabled = false;
			lbRoute[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRoute[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRoute[0].Name = "_lbRoute_0";
			lbRoute[0].TabIndex = 232;
			lbRoute[0].Text = "ROUTE";
			lbRoute[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRoute[1].Enabled = false;
			lbRoute[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRoute[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRoute[1].Name = "_lbRoute_1";
			lbRoute[1].TabIndex = 237;
			lbRoute[1].Text = "ROUTE";
			lbRoute[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRoute[2].Enabled = false;
			lbRoute[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRoute[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRoute[2].Name = "_lbRoute_2";
			lbRoute[2].TabIndex = 242;
			lbRoute[2].Text = "ROUTE";
			lbRoute[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRoute[3].Enabled = false;
			lbRoute[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRoute[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRoute[3].Name = "_lbRoute_3";
			lbRoute[3].TabIndex = 247;
			lbRoute[3].Text = "ROUTE";
			lbRoute[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRoute[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRoute[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRoute[4].Name = "_lbRoute_4";
			lbRoute[4].TabIndex = 252;
			lbRoute[4].Text = "ROUTE";
			lbRespiration = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbRespiration[4] = _lbRespiration_4;
			lbRespiration[3] = _lbRespiration_3;
			lbRespiration[2] = _lbRespiration_2;
			lbRespiration[1] = _lbRespiration_1;
			lbRespiration[0] = _lbRespiration_0;
			lbRespiration[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbRespiration[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRespiration[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRespiration[0].Name = "_lbRespiration_0";
			lbRespiration[0].TabIndex = 336;
			lbRespiration[0].Text = "RESPIRATION";
			lbRespiration[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbRespiration[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRespiration[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRespiration[1].Name = "_lbRespiration_1";
			lbRespiration[1].TabIndex = 359;
			lbRespiration[1].Text = "RESPIRATION";
			lbRespiration[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbRespiration[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRespiration[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRespiration[2].Name = "_lbRespiration_2";
			lbRespiration[2].TabIndex = 374;
			lbRespiration[2].Text = "RESPIRATION";
			lbRespiration[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbRespiration[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRespiration[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRespiration[3].Name = "_lbRespiration_3";
			lbRespiration[3].TabIndex = 391;
			lbRespiration[3].Text = "RESPIRATION";
			lbRespiration[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbRespiration[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRespiration[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRespiration[4].Name = "_lbRespiration_4";
			lbRespiration[4].TabIndex = 407;
			lbRespiration[4].Text = "RESPIRATION";
			lbRate = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbRate[4] = _lbRate_4;
			lbRate[3] = _lbRate_3;
			lbRate[2] = _lbRate_2;
			lbRate[1] = _lbRate_1;
			lbRate[0] = _lbRate_0;
			lbRate[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRate[0].Enabled = false;
			lbRate[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRate[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRate[0].Name = "_lbRate_0";
			lbRate[0].TabIndex = 234;
			lbRate[0].Text = "RATE";
			lbRate[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRate[1].Enabled = false;
			lbRate[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRate[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRate[1].Name = "_lbRate_1";
			lbRate[1].TabIndex = 239;
			lbRate[1].Text = "RATE";
			lbRate[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRate[2].Enabled = false;
			lbRate[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRate[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRate[2].Name = "_lbRate_2";
			lbRate[2].TabIndex = 244;
			lbRate[2].Text = "RATE";
			lbRate[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRate[3].Enabled = false;
			lbRate[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRate[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRate[3].Name = "_lbRate_3";
			lbRate[3].TabIndex = 249;
			lbRate[3].Text = "RATE";
			lbRate[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbRate[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbRate[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbRate[4].Name = "_lbRate_4";
			lbRate[4].TabIndex = 254;
			lbRate[4].Text = "RATE";
			lbPulseOxy = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbPulseOxy[4] = _lbPulseOxy_4;
			lbPulseOxy[3] = _lbPulseOxy_3;
			lbPulseOxy[2] = _lbPulseOxy_2;
			lbPulseOxy[1] = _lbPulseOxy_1;
			lbPulseOxy[0] = _lbPulseOxy_0;
			lbPulseOxy[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulseOxy[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulseOxy[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulseOxy[0].Name = "_lbPulseOxy_0";
			lbPulseOxy[0].TabIndex = 340;
			lbPulseOxy[0].Text = "PULSE OXY";
			lbPulseOxy[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulseOxy[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulseOxy[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulseOxy[1].Name = "_lbPulseOxy_1";
			lbPulseOxy[1].TabIndex = 363;
			lbPulseOxy[1].Text = "PULSE OXY";
			lbPulseOxy[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulseOxy[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulseOxy[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulseOxy[2].Name = "_lbPulseOxy_2";
			lbPulseOxy[2].TabIndex = 384;
			lbPulseOxy[2].Text = "PULSE OXY";
			lbPulseOxy[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulseOxy[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulseOxy[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulseOxy[3].Name = "_lbPulseOxy_3";
			lbPulseOxy[3].TabIndex = 395;
			lbPulseOxy[3].Text = "PULSE OXY";
			lbPulseOxy[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulseOxy[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulseOxy[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulseOxy[4].Name = "_lbPulseOxy_4";
			lbPulseOxy[4].TabIndex = 411;
			lbPulseOxy[4].Text = "PULSE OXY";
			lbPulse = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbPulse[4] = _lbPulse_4;
			lbPulse[3] = _lbPulse_3;
			lbPulse[2] = _lbPulse_2;
			lbPulse[1] = _lbPulse_1;
			lbPulse[0] = _lbPulse_0;
			lbPulse[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulse[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulse[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulse[0].Name = "_lbPulse_0";
			lbPulse[0].TabIndex = 335;
			lbPulse[0].Text = "PULSE";
			lbPulse[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulse[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulse[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulse[1].Name = "_lbPulse_1";
			lbPulse[1].TabIndex = 358;
			lbPulse[1].Text = "PULSE";
			lbPulse[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulse[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulse[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulse[2].Name = "_lbPulse_2";
			lbPulse[2].TabIndex = 373;
			lbPulse[2].Text = "PULSE";
			lbPulse[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulse[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulse[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulse[3].Name = "_lbPulse_3";
			lbPulse[3].TabIndex = 390;
			lbPulse[3].Text = "PULSE";
			lbPulse[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPulse[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbPulse[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbPulse[4].Name = "_lbPulse_4";
			lbPulse[4].TabIndex = 406;
			lbPulse[4].Text = "PULSE";
			lbOxy1 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			lbOxy1[4] = _lbOxy1_4;
			lbOxy1[9] = _lbOxy1_9;
			lbOxy1[3] = _lbOxy1_3;
			lbOxy1[8] = _lbOxy1_8;
			lbOxy1[2] = _lbOxy1_2;
			lbOxy1[7] = _lbOxy1_7;
			lbOxy1[1] = _lbOxy1_1;
			lbOxy1[6] = _lbOxy1_6;
			lbOxy1[0] = _lbOxy1_0;
			lbOxy1[5] = _lbOxy1_5;
			lbOxy1[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[0].Name = "_lbOxy1_0";
			lbOxy1[0].TabIndex = 430;
			lbOxy1[0].Text = "%ON";
			lbOxy1[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[5].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[5].Name = "_lbOxy1_5";
			lbOxy1[5].TabIndex = 351;
			lbOxy1[5].Text = "Liters";
			lbOxy1[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[1].Name = "_lbOxy1_1";
			lbOxy1[1].TabIndex = 431;
			lbOxy1[1].Text = "%ON";
			lbOxy1[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[6].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[6].Name = "_lbOxy1_6";
			lbOxy1[6].TabIndex = 355;
			lbOxy1[6].Text = "Liters";
			lbOxy1[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[2].Name = "_lbOxy1_2";
			lbOxy1[2].TabIndex = 432;
			lbOxy1[2].Text = "%ON";
			lbOxy1[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[7].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[7].Name = "_lbOxy1_7";
			lbOxy1[7].TabIndex = 378;
			lbOxy1[7].Text = "Liters";
			lbOxy1[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[3].Name = "_lbOxy1_3";
			lbOxy1[3].TabIndex = 433;
			lbOxy1[3].Text = "%ON";
			lbOxy1[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[8].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[8].Name = "_lbOxy1_8";
			lbOxy1[8].TabIndex = 387;
			lbOxy1[8].Text = "Liters";
			lbOxy1[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[4].Name = "_lbOxy1_4";
			lbOxy1[4].TabIndex = 434;
			lbOxy1[4].Text = "%ON";
			lbOxy1[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbOxy1[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Italic, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbOxy1[9].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbOxy1[9].Name = "_lbOxy1_9";
			lbOxy1[9].TabIndex = 403;
			lbOxy1[9].Text = "Liters";
			lbMotor = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbMotor[4] = _lbMotor_4;
			lbMotor[3] = _lbMotor_3;
			lbMotor[2] = _lbMotor_2;
			lbMotor[1] = _lbMotor_1;
			lbMotor[0] = _lbMotor_0;
			lbMotor[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbMotor[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbMotor[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbMotor[0].Name = "_lbMotor_0";
			lbMotor[0].TabIndex = 333;
			lbMotor[0].Text = "MOTOR";
			lbMotor[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbMotor[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbMotor[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbMotor[1].Name = "_lbMotor_1";
			lbMotor[1].TabIndex = 368;
			lbMotor[1].Text = "MOTOR";
			lbMotor[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbMotor[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbMotor[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbMotor[2].Name = "_lbMotor_2";
			lbMotor[2].TabIndex = 382;
			lbMotor[2].Text = "MOTOR";
			lbMotor[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbMotor[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbMotor[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbMotor[3].Name = "_lbMotor_3";
			lbMotor[3].TabIndex = 400;
			lbMotor[3].Text = "MOTOR";
			lbMotor[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbMotor[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbMotor[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbMotor[4].Name = "_lbMotor_4";
			lbMotor[4].TabIndex = 417;
			lbMotor[4].Text = "MOTOR";
			lbGlucose = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbGlucose[4] = _lbGlucose_4;
			lbGlucose[3] = _lbGlucose_3;
			lbGlucose[2] = _lbGlucose_2;
			lbGlucose[1] = _lbGlucose_1;
			lbGlucose[0] = _lbGlucose_0;
			lbGlucose[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGlucose[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGlucose[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGlucose[0].Name = "_lbGlucose_0";
			lbGlucose[0].TabIndex = 339;
			lbGlucose[0].Text = "GLUCOSE";
			lbGlucose[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGlucose[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGlucose[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGlucose[1].Name = "_lbGlucose_1";
			lbGlucose[1].TabIndex = 362;
			lbGlucose[1].Text = "GLUCOSE";
			lbGlucose[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGlucose[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGlucose[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGlucose[2].Name = "_lbGlucose_2";
			lbGlucose[2].TabIndex = 383;
			lbGlucose[2].Text = "GLUCOSE";
			lbGlucose[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGlucose[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGlucose[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGlucose[3].Name = "_lbGlucose_3";
			lbGlucose[3].TabIndex = 394;
			lbGlucose[3].Text = "GLUCOSE";
			lbGlucose[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGlucose[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGlucose[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGlucose[4].Name = "_lbGlucose_4";
			lbGlucose[4].TabIndex = 410;
			lbGlucose[4].Text = "GLUCOSE";
			lbGauge = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbGauge[4] = _lbGauge_4;
			lbGauge[3] = _lbGauge_3;
			lbGauge[2] = _lbGauge_2;
			lbGauge[1] = _lbGauge_1;
			lbGauge[0] = _lbGauge_0;
			lbGauge[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbGauge[0].Enabled = false;
			lbGauge[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGauge[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGauge[0].Name = "_lbGauge_0";
			lbGauge[0].TabIndex = 233;
			lbGauge[0].Text = "GAUGE";
			lbGauge[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbGauge[1].Enabled = false;
			lbGauge[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGauge[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGauge[1].Name = "_lbGauge_1";
			lbGauge[1].TabIndex = 238;
			lbGauge[1].Text = "GAUGE";
			lbGauge[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbGauge[2].Enabled = false;
			lbGauge[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGauge[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGauge[2].Name = "_lbGauge_2";
			lbGauge[2].TabIndex = 243;
			lbGauge[2].Text = "GAUGE";
			lbGauge[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbGauge[3].Enabled = false;
			lbGauge[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGauge[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGauge[3].Name = "_lbGauge_3";
			lbGauge[3].TabIndex = 248;
			lbGauge[3].Text = "GAUGE";
			lbGauge[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbGauge[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbGauge[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbGauge[4].Name = "_lbGauge_4";
			lbGauge[4].TabIndex = 253;
			lbGauge[4].Text = "GAUGE";
			lbGCS = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbGCS[4] = _lbGCS_4;
			lbGCS[3] = _lbGCS_3;
			lbGCS[2] = _lbGCS_2;
			lbGCS[1] = _lbGCS_1;
			lbGCS[0] = _lbGCS_0;
			lbGCS[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGCS[0].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbGCS[0].Name = "_lbGCS_0";
			lbGCS[0].TabIndex = 330;
			lbGCS[0].Text = "GCS";
			lbGCS[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGCS[1].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbGCS[1].Name = "_lbGCS_1";
			lbGCS[1].TabIndex = 365;
			lbGCS[1].Text = "GCS";
			lbGCS[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGCS[2].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbGCS[2].Name = "_lbGCS_2";
			lbGCS[2].TabIndex = 379;
			lbGCS[2].Text = "GCS";
			lbGCS[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGCS[3].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbGCS[3].Name = "_lbGCS_3";
			lbGCS[3].TabIndex = 397;
			lbGCS[3].Text = "GCS";
			lbGCS[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbGCS[4].ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			lbGCS[4].Name = "_lbGCS_4";
			lbGCS[4].TabIndex = 414;
			lbGCS[4].Text = "GCS";
			lbEyes = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbEyes[4] = _lbEyes_4;
			lbEyes[3] = _lbEyes_3;
			lbEyes[2] = _lbEyes_2;
			lbEyes[1] = _lbEyes_1;
			lbEyes[0] = _lbEyes_0;
			lbEyes[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbEyes[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEyes[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbEyes[0].Name = "_lbEyes_0";
			lbEyes[0].TabIndex = 331;
			lbEyes[0].Text = "EYES";
			lbEyes[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbEyes[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEyes[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbEyes[1].Name = "_lbEyes_1";
			lbEyes[1].TabIndex = 366;
			lbEyes[1].Text = "EYES";
			lbEyes[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbEyes[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEyes[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbEyes[2].Name = "_lbEyes_2";
			lbEyes[2].TabIndex = 380;
			lbEyes[2].Text = "EYES";
			lbEyes[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbEyes[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEyes[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbEyes[3].Name = "_lbEyes_3";
			lbEyes[3].TabIndex = 398;
			lbEyes[3].Text = "EYES";
			lbEyes[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbEyes[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbEyes[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbEyes[4].Name = "_lbEyes_4";
			lbEyes[4].TabIndex = 415;
			lbEyes[4].Text = "EYES";
			lbECG = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbECG[4] = _lbECG_4;
			lbECG[3] = _lbECG_3;
			lbECG[2] = _lbECG_2;
			lbECG[1] = _lbECG_1;
			lbECG[0] = _lbECG_0;
			lbECG[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbECG[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbECG[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbECG[0].Name = "_lbECG_0";
			lbECG[0].TabIndex = 341;
			lbECG[0].Text = "ECG";
			lbECG[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbECG[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbECG[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbECG[1].Name = "_lbECG_1";
			lbECG[1].TabIndex = 369;
			lbECG[1].Text = "ECG";
			lbECG[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbECG[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbECG[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbECG[2].Name = "_lbECG_2";
			lbECG[2].TabIndex = 385;
			lbECG[2].Text = "ECG";
			lbECG[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbECG[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbECG[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbECG[3].Name = "_lbECG_3";
			lbECG[3].TabIndex = 401;
			lbECG[3].Text = "ECG";
			lbECG[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbECG[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbECG[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbECG[4].Name = "_lbECG_4";
			lbECG[4].TabIndex = 418;
			lbECG[4].Text = "ECG";
			lbDiastolic = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbDiastolic[4] = _lbDiastolic_4;
			lbDiastolic[3] = _lbDiastolic_3;
			lbDiastolic[2] = _lbDiastolic_2;
			lbDiastolic[1] = _lbDiastolic_1;
			lbDiastolic[0] = _lbDiastolic_0;
			lbDiastolic[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbDiastolic[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDiastolic[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbDiastolic[0].Name = "_lbDiastolic_0";
			lbDiastolic[0].TabIndex = 338;
			lbDiastolic[0].Text = "DIASTOLIC";
			lbDiastolic[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbDiastolic[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDiastolic[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbDiastolic[1].Name = "_lbDiastolic_1";
			lbDiastolic[1].TabIndex = 361;
			lbDiastolic[1].Text = "DIASTOLIC";
			lbDiastolic[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbDiastolic[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDiastolic[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbDiastolic[2].Name = "_lbDiastolic_2";
			lbDiastolic[2].TabIndex = 376;
			lbDiastolic[2].Text = "DIASTOLIC";
			lbDiastolic[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbDiastolic[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDiastolic[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbDiastolic[3].Name = "_lbDiastolic_3";
			lbDiastolic[3].TabIndex = 393;
			lbDiastolic[3].Text = "DIASTOLIC";
			lbDiastolic[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbDiastolic[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbDiastolic[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbDiastolic[4].Name = "_lbDiastolic_4";
			lbDiastolic[4].TabIndex = 409;
			lbDiastolic[4].Text = "DIASTOLIC";
			lbAmount = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			lbAmount[4] = _lbAmount_4;
			lbAmount[3] = _lbAmount_3;
			lbAmount[2] = _lbAmount_2;
			lbAmount[1] = _lbAmount_1;
			lbAmount[0] = _lbAmount_0;
			lbAmount[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbAmount[0].Enabled = false;
			lbAmount[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbAmount[0].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbAmount[0].Name = "_lbAmount_0";
			lbAmount[0].TabIndex = 235;
			lbAmount[0].Text = "AMOUNT";
			lbAmount[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbAmount[1].Enabled = false;
			lbAmount[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbAmount[1].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbAmount[1].Name = "_lbAmount_1";
			lbAmount[1].TabIndex = 240;
			lbAmount[1].Text = "AMOUNT";
			lbAmount[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbAmount[2].Enabled = false;
			lbAmount[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbAmount[2].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbAmount[2].Name = "_lbAmount_2";
			lbAmount[2].TabIndex = 245;
			lbAmount[2].Text = "AMOUNT";
			lbAmount[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbAmount[3].Enabled = false;
			lbAmount[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbAmount[3].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbAmount[3].Name = "_lbAmount_3";
			lbAmount[3].TabIndex = 250;
			lbAmount[3].Text = "AMOUNT";
			lbAmount[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(166)))), ((int)(((byte)(187)))));
			lbAmount[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			lbAmount[4].ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			lbAmount[4].Name = "_lbAmount_4";
			lbAmount[4].TabIndex = 255;
			lbAmount[4].Text = "AMOUNT";
			Line3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(5);
			Line3[4] = _Line3_4;
			Line3[3] = _Line3_3;
			Line3[2] = _Line3_2;
			Line3[1] = _Line3_1;
			Line3[0] = _Line3_0;
			Line3[0].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[0].Enabled = false;
			Line3[0].Name = "_Line3_0";
			Line3[0].TabIndex = 431;
			Line3[1].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[1].Enabled = false;
			Line3[1].Name = "_Line3_1";
			Line3[1].TabIndex = 432;
			Line3[2].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[2].Enabled = false;
			Line3[2].Name = "_Line3_2";
			Line3[2].TabIndex = 433;
			Line3[3].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[3].Enabled = false;
			Line3[3].Name = "_Line3_3";
			Line3[3].TabIndex = 434;
			Line3[4].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line3[4].Enabled = false;
			Line3[4].Name = "_Line3_4";
			Line3[4].TabIndex = 435;
			Line2 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Line2[1] = _Line2_1;
			Line2[0] = _Line2_0;
			Line2[0].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line2[0].Enabled = false;
			Line2[0].Name = "_Line2_0";
			Line2[0].TabIndex = 15;
			Line2[1].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line2[1].Enabled = false;
			Line2[1].Name = "_Line2_1";
			Line2[1].TabIndex = 448;
			Line1 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Line1[1] = _Line1_1;
			Line1[0] = _Line1_0;
			Line1[0].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line1[0].Enabled = false;
			Line1[0].Name = "_Line1_0";
			Line1[0].TabIndex = 16;
			Line1[1].BackColor = UpgradeHelpers.Helpers.Color.Navy;
			Line1[1].Enabled = false;
			Line1[1].Name = "_Line1_1";
			Line1[1].TabIndex = 447;
			this.Name = "TFDIncident.frmEMSReport";
			IsMdiChild = true;
			vaTabPro2.Items.Add(tabPage10);
			vaTabPro2.Items.Add(tabPage11);
			vaTabPro2.Items.Add(tabPage12);
			vaTabPro2.Items.Add(tabPage13);
			vaTabPro2.Items.Add(tabPage14);
			tabVitals.Items.Add(tabPage15);
			tabVitals.Items.Add(tabPage16);
			tabVitals.Items.Add(tabPage17);
			tabVitals.Items.Add(tabPage18);
			tabVitals.Items.Add(tabPage19);
			tabEMS.Items.Add(tabPage1);
			tabEMS.Items.Add(tabPage2);
			tabEMS.Items.Add(tabPage3);
			tabEMS.Items.Add(tabPage4);
			tabEMS.Items.Add(tabPage5);
			tabEMS.Items.Add(tabPage6);
			tabEMS.Items.Add(tabPage7);
			tabEMS.Items.Add(tabPage8);
			tabEMS.Items.Add(tabPage9);
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboGauge_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboSite_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtAmount_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRate_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboRoute_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbIVID_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbIVID_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbIVID_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbIVID_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbIVID_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSite_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAmount_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRate_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGauge_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRoute_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSite_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAmount_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRate_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGauge_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRoute_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSite_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAmount_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRate_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGauge_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRoute_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSite_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAmount_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRate_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGauge_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRoute_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSite_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbAmount_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRate_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGauge_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRoute_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel vaTabPro2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbECG_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbMotor_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVerbal_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEyes_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGCS_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulseOxy_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGlucose_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDiastolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSystolic_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRespiration_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulse_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsID_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbECG_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbMotor_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVerbal_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEyes_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGCS_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulseOxy_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGlucose_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDiastolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSystolic_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRespiration_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulse_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsID_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbECG_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulseOxy_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGlucose_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbMotor_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVerbal_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEyes_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGCS_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDiastolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSystolic_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRespiration_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulse_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsID_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboECG_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboMotor_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVerbal_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEyes_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboVitalsPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulseOxy_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtGlucose_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtDiastolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtSystolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtRespiration_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPulse_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel _txtPerOxy_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbECG_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbMotor_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVerbal_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEyes_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGCS_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulseOxy_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGlucose_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDiastolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSystolic_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRespiration_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulse_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsID_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame17 { get; set; }

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

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtTime_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbOxy1_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbECG_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulseOxy_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGlucose_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbDiastolic_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbSystolic_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbRespiration_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPulse_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsTime_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbMotor_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVerbal_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbEyes_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbGCS_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbVitalsID_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel tabVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optSeverity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optRespiratoryEffort_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_65 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_56 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_55 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtIncidentZipcode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboResearchCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentSetting { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboIncidentLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_54 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_57 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_58 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_59 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboServiceProvided { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEMSGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEMSRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAgeUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtBBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_64 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line2_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToCPR_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToALS_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToALS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optArrestToShock_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmArrestToShock { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstCPRPerformedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCPRPerformedBy { get; set; }

		public virtual VB6Helpers.ViewModels.ShapeHelperViewModel Shape1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_50 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_51 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_49 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_53 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_52 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstTrauma1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboProtectiveDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPatientLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtTraumaID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_44 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_43 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_45 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_46 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_48 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_47 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportTo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTransportFrom { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMileage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHospitalChosenBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBaseStationContact { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optMDorRN_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_39 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_38 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_40 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_41 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_42 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_37 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboTreatmentAuth { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtExtricationTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_36 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOtherALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboALSPersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAttempts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOtherBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstBLSPersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMechCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZipCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBillingAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel mskSSN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPriorMedicalHistory { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPossibleFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtDosage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_35 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBodyPart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrimaryIllness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optPupils_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optPupils_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optLevelOfConsciouness_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSecondaryIllness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtPatientAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPatientAgeUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel mskBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line2_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Line1_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_63 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_62 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_61 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_60 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExamDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPInfo_24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabControlViewModel tabEMS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLockedMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picEMSBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkPalp_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkNoVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkMajTrauma { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveALSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddALS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveBLSProcedures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddBLS { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCPRPerformed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveMedication { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddMedications { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemoveCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddCPR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel FDCaresBtn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNarration { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdHIPAAInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TabPageViewModel tabPage19 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PatientID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationUpdated { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdSave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ActionTaken { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEMSGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEMSEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDNR { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optPupils { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optLevelOfConsciouness { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optRespiratoryEffort { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optSeverity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel> txtTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboVitalsPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPulse { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtRespiration { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtSystolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtDiastolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkPalp { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtGlucose { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPulseOxy { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtPerOxy { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboECG { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboEyes { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboVerbal { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboMotor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSuccessful { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSalineLock { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboGauge { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboRoute { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboRate { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.TextBoxViewModel> txtAmount { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboSite { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optMDorRN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkDiverted { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCPRTrained { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkWitnessedArrest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkPulseRestored { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToCPR { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToALS { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optArrestToShock { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 EMSType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportLogID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ExtricationSwitch { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVitalsID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbIVID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TraumaSwitch { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CPRSwitch { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationRequired { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPInfo { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String ReqNarrString { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmBasicGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmGender { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NoVitals { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmSeverity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 IVSwitch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMore { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdMoreIVs { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ExtricationTime { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmALSAttempts { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmIllness { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVitalsTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVitalsPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbVerbal { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSystolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbSite { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbRoute { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbRespiration { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbRate { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPulseOxy { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPulse { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbOxy1 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbMotor { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbGlucose { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbGauge { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbGCS { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbEyes { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbECG { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbDiastolic { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbAmount { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line3 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line2 { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Line1 { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtPatientAge_TextChanged()
		{
			if ( _txtPatientAge_TextChanged != null )
				_txtPatientAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtPatientAge_TextChanged;

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

		public void OntxtAttempts_TextChanged()
		{
			if ( _txtAttempts_TextChanged != null )
				_txtAttempts_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAttempts_TextChanged;

		public void OntxtOtherBLSProcedures_TextChanged()
		{
			if ( _txtOtherBLSProcedures_TextChanged != null )
				_txtOtherBLSProcedures_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtOtherBLSProcedures_TextChanged;

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

		public void OntxtMileage_TextChanged()
		{
			if ( _txtMileage_TextChanged != null )
				_txtMileage_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtMileage_TextChanged;

		public void OntxtTraumaID_TextChanged()
		{
			if ( _txtTraumaID_TextChanged != null )
				_txtTraumaID_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtTraumaID_TextChanged;

		public void OntxtBFirstName_TextChanged()
		{
			if ( _txtBFirstName_TextChanged != null )
				_txtBFirstName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBFirstName_TextChanged;

		public void OntxtBLastName_TextChanged()
		{
			if ( _txtBLastName_TextChanged != null )
				_txtBLastName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBLastName_TextChanged;

		public void OntxtAge_TextChanged()
		{
			if ( _txtAge_TextChanged != null )
				_txtAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAge_TextChanged;

		public void OntxtIncidentZipcode_TextChanged()
		{
			if ( _txtIncidentZipcode_TextChanged != null )
				_txtIncidentZipcode_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtIncidentZipcode_TextChanged;
	}

}