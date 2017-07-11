using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmIncident))]
	public class frmIncidentViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var _chkCasualty_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkCasualty_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkExposure_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _chkSirenReport_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			var _cmdClearPerson_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdClearPerson_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdEMSUnlock_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			var _cmdUnlock_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cboXSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXSuffix
			// 
			this.cboXSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXSuffix.Enabled = true;
			this.cboXSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXSuffix.Name = "cboXSuffix";
			this.cboXSuffix.TabIndex = 182;
			this.cboXSuffix.Visible = true;
			this.cboXStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXStreetType
			// 
			this.cboXStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXStreetType.Enabled = true;
			this.cboXStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXStreetType.Name = "cboXStreetType";
			this.cboXStreetType.TabIndex = 181;
			this.cboXStreetType.Visible = true;
			this.cboXPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXPrefix
			// 
			this.cboXPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXPrefix.Enabled = true;
			this.cboXPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXPrefix.Name = "cboXPrefix";
			this.cboXPrefix.TabIndex = 180;
			this.cboXPrefix.Visible = true;
			this.txtXStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.txtXStreetName.Name = "txtXStreetName";
			this.txtXStreetName.TabIndex = 179;
			this.txtXHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.txtXHouseNumber.Name = "txtXHouseNumber";
			this.txtXHouseNumber.TabIndex = 178;
			this.cboCityCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCityCode
			// 
			this.cboCityCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCityCode.Enabled = true;
			this.cboCityCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCityCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboCityCode.Name = "cboCityCode";
			this.cboCityCode.TabIndex = 177;
			this.cboCityCode.Visible = true;
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 188;
			this.Label13.Text = "CITY";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 187;
			this.Label12.Text = "SUFFIX";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 186;
			this.Label11.Text = "STREET TYPE";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 185;
			this.Label10.Text = "STREET NAME";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 184;
			this.Label9.Text = "PREFIX";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 183;
			this.Label4.Text = "HOUSE#";
			this._lbFrameTitle_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmIncidentAddressCorrection = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmIncidentAddressCorrection
			// 
			this.frmIncidentAddressCorrection.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmIncidentAddressCorrection.Enabled = true;
			this.frmIncidentAddressCorrection.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmIncidentAddressCorrection.Name = "frmIncidentAddressCorrection";
			this.frmIncidentAddressCorrection.TabIndex = 175;
			this.frmIncidentAddressCorrection.Visible = true;
			this._cboAmendReason_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmendTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.lbDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDispatch
			// 
			this.lbDispatch.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDispatch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDispatch.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbDispatch.Name = "lbDispatch";
			this.lbDispatch.TabIndex = 141;
			this.lbDispatch.Tag = "3";
			this.lbDispatch.Text = "DISPATCH";
			this.lbEnroute = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnroute
			// 
			this.lbEnroute.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEnroute.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEnroute.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbEnroute.Name = "lbEnroute";
			this.lbEnroute.TabIndex = 140;
			this.lbEnroute.Text = "ENROUTE";
			this.lbOnscene = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOnscene
			// 
			this.lbOnscene.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOnscene.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOnscene.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbOnscene.Name = "lbOnscene";
			this.lbOnscene.TabIndex = 139;
			this.lbOnscene.Text = "ONSCENE";
			this.lbTransport = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTransport
			// 
			this.lbTransport.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTransport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTransport.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTransport.Name = "lbTransport";
			this.lbTransport.TabIndex = 138;
			this.lbTransport.Text = "TRANSPORT";
			this.lbTransportComplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTransportComplete
			// 
			this.lbTransportComplete.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTransportComplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTransportComplete.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTransportComplete.Name = "lbTransportComplete";
			this.lbTransportComplete.TabIndex = 137;
			this.lbTransportComplete.Text = "TRANSPORT COMPLETE";
			this.lbAvailable = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailable
			// 
			this.lbAvailable.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAvailable.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAvailable.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAvailable.Name = "lbAvailable";
			this.lbAvailable.TabIndex = 136;
			this.lbAvailable.Text = "AVAILABLE";
			this.lbEventTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEventTitle
			// 
			this.lbEventTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEventTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEventTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbEventTitle.Name = "lbEventTitle";
			this.lbEventTitle.TabIndex = 135;
			this.lbEventTitle.Text = "EVENT";
			this.lbTimeTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTimeTitle
			// 
			this.lbTimeTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTimeTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTimeTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTimeTitle.Name = "lbTimeTitle";
			this.lbTimeTitle.TabIndex = 134;
			this.lbTimeTitle.Text = "TIME";
			this.lbAmendedTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAmendedTitle
			// 
			this.lbAmendedTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAmendedTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAmendedTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAmendedTitle.Name = "lbAmendedTitle";
			this.lbAmendedTitle.TabIndex = 133;
			this.lbAmendedTitle.Text = "AMENDED";
			this.lbAmendedReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAmendedReason
			// 
			this.lbAmendedReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAmendedReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAmendedReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAmendedReason.Name = "lbAmendedReason";
			this.lbAmendedReason.TabIndex = 132;
			this.lbAmendedReason.Text = "REASON";
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.Visible = true;
			this._lbActualTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbURDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbURDate
			// 
			this.lbURDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbURDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 8.4f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbURDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbURDate.Name = "lbURDate";
			this.lbURDate.TabIndex = 125;
			this.lbURDate.Text = "lbURDate";
			this.lbURDate.Visible = false;
			this._cboPersonnel_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 113;
			this.Label6.Text = "PERSONNEL";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 112;
			this.Label5.Text = "POSITION  INJURY";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 111;
			this.Label8.Text = "NON-TFD OPERATIONS PERSONNEL";
			this.lstActionsTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstActionsTaken
			// 
			this.lstActionsTaken.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstActionsTaken.Enabled = true;
			this.lstActionsTaken.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lstActionsTaken.Name = "lstActionsTaken";
			this.lstActionsTaken.TabIndex = 68;
			this.lstActionsTaken.Visible = true;
			this.lstActionsTaken.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstReasonDelay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstReasonDelay
			// 
			this.lstReasonDelay.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstReasonDelay.Enabled = true;
			this.lstReasonDelay.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lstReasonDelay.Name = "lstReasonDelay";
			this.lstReasonDelay.TabIndex = 67;
			this.lstReasonDelay.Visible = true;
			this.lstReasonDelay.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lbActionsTakenTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbActionsTakenTitle
			// 
			this.lbActionsTakenTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbActionsTakenTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbActionsTakenTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbActionsTakenTitle.Name = "lbActionsTakenTitle";
			this.lbActionsTakenTitle.TabIndex = 71;
			this.lbActionsTakenTitle.Text = "UNIT ACTIONS - FIRE INCIDENTS";
			this.lbReasonsDelayTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReasonsDelayTitle
			// 
			this.lbReasonsDelayTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReasonsDelayTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReasonsDelayTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbReasonsDelayTitle.Name = "lbReasonsDelayTitle";
			this.lbReasonsDelayTitle.TabIndex = 70;
			this.lbReasonsDelayTitle.Text = "REASONS FOR DELAY";
			this.lbUnitComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnitComment
			// 
			this.lbUnitComment.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnitComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnitComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbUnitComment.Name = "lbUnitComment";
			this.lbUnitComment.TabIndex = 69;
			this.lbUnitComment.Text = "UNIT COMMENT";
			this._lbFrameTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmUnit
			// 
			this.frmUnit.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			this.frmUnit.Enabled = true;
			this.frmUnit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmUnit.Name = "frmUnit";
			this.frmUnit.TabIndex = 62;
			this.frmUnit.Visible = true;
			this._cboEMSUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._lbPatient_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.txtNumberExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberExposures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberExposures.Name = "txtNumberExposures";
			this.txtNumberExposures.TabIndex = 173;
			this.txtNumberExposures.Visible = false;
			this._cboUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._optServiceReport_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optServiceReport_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optServiceReport_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._cboUnit_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.frmServiceSit = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmServiceSit
			// 
			this.frmServiceSit.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.frmServiceSit.Enabled = true;
			this.frmServiceSit.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmServiceSit.Name = "frmServiceSit";
			this.frmServiceSit.TabIndex = 11;
			this.frmServiceSit.Visible = true;
			this.txtNumberPatients = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberPatients.Enabled = false;
			this.txtNumberPatients.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberPatients.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberPatients.Name = "txtNumberPatients";
			this.txtNumberPatients.TabIndex = 8;
			this.txtNumberCivCasulties = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberCivCasulties.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberCivCasulties.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberCivCasulties.Name = "txtNumberCivCasulties";
			this.txtNumberCivCasulties.TabIndex = 6;
			this.txtNumberCivCasulties.Text = "1";
			this.txtNumberCivCasulties.Visible = false;
			this.lbSirenTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSirenTitle
			// 
			this.lbSirenTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.lbSirenTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSirenTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.lbSirenTitle.Name = "lbSirenTitle";
			this.lbSirenTitle.TabIndex = 192;
			this.lbSirenTitle.Text = "Siren Report";
			this.lbSirenTitle.Visible = false;
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 0, 0);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 143;
			this.Label7.Text = "Saved Reports Are Locked.  If Report Deletion is Required Please Contact Fire IS Staff";
			this.lbEMSTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEMSTitle
			// 
			this.lbEMSTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.lbEMSTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEMSTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.lbEMSTitle.Name = "lbEMSTitle";
			this.lbEMSTitle.TabIndex = 61;
			this.lbEMSTitle.Text = "IRS Report";
			this.lbEMSTitle.Visible = false;
			this._lbFrameTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 32;
			this.Label3.Text = "Unit Responsible for Report";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 31;
			this.Label1.Text = "Select Situation(s) Found";
			this.frmSitFound = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmSitFound
			// 
			this.frmSitFound.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmSitFound.Enabled = true;
			this.frmSitFound.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 14.4f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmSitFound.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmSitFound.Name = "frmSitFound";
			this.frmSitFound.TabIndex = 4;
			this.frmSitFound.Visible = true;
			this.lbLockedMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLockedMessage
			// 
			this.lbLockedMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbLockedMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLockedMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 64, 0);
			this.lbLockedMessage.Name = "lbLockedMessage";
			this.lbLockedMessage.TabIndex = 168;
			this.lbLockedMessage.Text = "READ ONLY - Records Locked";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 142;
			this.lbUnit.Text = "E12";
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 3;
			this.lbIncident.Text = "001230012";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Incident #";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 1;
			this.lbLocation.Text = "lbLocation";
			this.picFireBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picFireBar
			// 
			this.picFireBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.picFireBar.Enabled = true;
			this.picFireBar.Name = "picFireBar";
			this.picFireBar.Visible = true;
			this.cmdAddStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddStaff
			// 
			this.cmdAddStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddStaff.Name = "cmdAddStaff";
			this.cmdAddStaff.TabIndex = 87;
			this.cmdAddStaff.Text = "Additional Staff...";
			this.chkExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkExposures.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkExposures.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkExposures.Enabled = false;
			this.chkExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.chkExposures.Name = "chkExposures";
			this.chkExposures.TabIndex = 174;
			this.chkExposures.Text = "# OF STRUCTURE EXPOSURES";
			this.chkExposures.Visible = false;
			this._chkSitFound_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkCivilianCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkCivilianCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkCivilianCasualty.Enabled = false;
			this.chkCivilianCasualty.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkCivilianCasualty.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.chkCivilianCasualty.Name = "chkCivilianCasualty";
			this.chkCivilianCasualty.TabIndex = 7;
			this.chkCivilianCasualty.Text = "CIVILIAN CASUALTY COUNT";
			this.chkCivilianCasualty.Visible = true;
			this.FDCaresBtn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.FDCaresBtn.Name = "FDCaresBtn";
			this.FDCaresBtn.TabIndex = 210;
			this.cmdViewReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdViewReport
			// 
			this.cmdViewReport.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdViewReport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdViewReport.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdViewReport.Name = "cmdViewReport";
			this.cmdViewReport.TabIndex = 191;
			this.cmdViewReport.Text = "Print";
			this._cmdSave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.Text = "Form1";
			cmdSave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(3);
			cmdSave[2] = _cmdSave_2;
			cmdSave[1] = _cmdSave_1;
			cmdSave[0] = _cmdSave_0;
			cmdSave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[2].Name = "_cmdSave_2";
			cmdSave[2].TabIndex = 171;
			cmdSave[2].Text = "Cancel and Exit";
			cmdSave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[1].Name = "_cmdSave_1";
			cmdSave[1].TabIndex = 170;
			cmdSave[1].Text = "Save as Incomplete";
			cmdSave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[0].Name = "_cmdSave_0";
			cmdSave[0].TabIndex = 169;
			cmdSave[0].Text = "Save as Complete";
			this.CurrIncident = 0;
			this.CurrReportID = 0;
			chkSitFound = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkSitFound[7] = _chkSitFound_7;
			chkSitFound[0] = _chkSitFound_0;
			chkSitFound[1] = _chkSitFound_1;
			chkSitFound[2] = _chkSitFound_2;
			chkSitFound[5] = _chkSitFound_5;
			chkSitFound[6] = _chkSitFound_6;
			chkSitFound[3] = _chkSitFound_3;
			chkSitFound[4] = _chkSitFound_4;
			chkSitFound[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[7].Enabled = true;
			chkSitFound[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[7].Name = "_chkSitFound_7";
			chkSitFound[7].TabIndex = 30;
			chkSitFound[7].Text = "FALSE ALARM";
			chkSitFound[7].Visible = true;
			chkSitFound[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[0].Enabled = true;
			chkSitFound[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[0].Name = "_chkSitFound_0";
			chkSitFound[0].TabIndex = 22;
			chkSitFound[0].Text = "FIRE";
			chkSitFound[0].Visible = true;
			chkSitFound[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[1].Enabled = true;
			chkSitFound[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[1].Name = "_chkSitFound_1";
			chkSitFound[1].TabIndex = 21;
			chkSitFound[1].Text = "RUPTURE/EXPLOSION";
			chkSitFound[1].Visible = true;
			chkSitFound[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[2].Enabled = true;
			chkSitFound[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[2].Name = "_chkSitFound_2";
			chkSitFound[2].TabIndex = 20;
			chkSitFound[2].Text = "HAZMAT";
			chkSitFound[2].Visible = true;
			chkSitFound[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[5].Enabled = true;
			chkSitFound[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[5].Name = "_chkSitFound_5";
			chkSitFound[5].TabIndex = 19;
			chkSitFound[5].Text = "SEARCH AND/OR RESCUE";
			chkSitFound[5].Visible = true;
			chkSitFound[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[6].Enabled = true;
			chkSitFound[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[6].Name = "_chkSitFound_6";
			chkSitFound[6].TabIndex = 18;
			chkSitFound[6].Text = "HAZARDOUS CONDITION";
			chkSitFound[6].Visible = true;
			chkSitFound[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[3].Enabled = true;
			chkSitFound[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[3].Name = "_chkSitFound_3";
			chkSitFound[3].TabIndex = 10;
			chkSitFound[3].Text = "EMS PATIENT (SINGLE)";
			chkSitFound[3].Visible = true;
			chkSitFound[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[4].Enabled = true;
			chkSitFound[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[4].Name = "_chkSitFound_4";
			chkSitFound[4].TabIndex = 9;
			chkSitFound[4].Text = "EMS PATIENTS -  # OF PATIENTS";
			chkSitFound[4].Visible = true;
			cboUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(11);
			cboUnit[7] = _cboUnit_7;
			cboUnit[6] = _cboUnit_6;
			cboUnit[0] = _cboUnit_0;
			cboUnit[1] = _cboUnit_1;
			cboUnit[2] = _cboUnit_2;
			cboUnit[3] = _cboUnit_3;
			cboUnit[5] = _cboUnit_5;
			cboUnit[8] = _cboUnit_8;
			cboUnit[9] = _cboUnit_9;
			cboUnit[10] = _cboUnit_10;
			cboUnit[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[7].Enabled = false;
			cboUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[7].Name = "_cboUnit_7";
			cboUnit[7].TabIndex = 29;
			cboUnit[7].Text = "cboUnit";
			cboUnit[7].Visible = true;
			cboUnit[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[6].Enabled = false;
			cboUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[6].Name = "_cboUnit_6";
			cboUnit[6].TabIndex = 28;
			cboUnit[6].Text = "cboUnit";
			cboUnit[6].Visible = true;
			cboUnit[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[0].Enabled = false;
			cboUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[0].Name = "_cboUnit_0";
			cboUnit[0].TabIndex = 27;
			cboUnit[0].Text = "cboUnit";
			cboUnit[0].Visible = true;
			cboUnit[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[1].Enabled = false;
			cboUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[1].Name = "_cboUnit_1";
			cboUnit[1].TabIndex = 26;
			cboUnit[1].Text = "cboUnit";
			cboUnit[1].Visible = true;
			cboUnit[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[2].Enabled = false;
			cboUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[2].Name = "_cboUnit_2";
			cboUnit[2].TabIndex = 25;
			cboUnit[2].Text = "cboUnit";
			cboUnit[2].Visible = true;
			cboUnit[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[3].Enabled = false;
			cboUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[3].Name = "_cboUnit_3";
			cboUnit[3].TabIndex = 24;
			cboUnit[3].Text = "cboUnit";
			cboUnit[3].Visible = true;
			cboUnit[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[5].Enabled = false;
			cboUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[5].Name = "_cboUnit_5";
			cboUnit[5].TabIndex = 23;
			cboUnit[5].Text = "cboUnit";
			cboUnit[5].Visible = true;
			cboUnit[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[8].Enabled = false;
			cboUnit[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[8].Name = "_cboUnit_8";
			cboUnit[8].TabIndex = 17;
			cboUnit[8].Text = "cboUnit";
			cboUnit[8].Visible = true;
			cboUnit[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[9].Enabled = false;
			cboUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[9].Name = "_cboUnit_9";
			cboUnit[9].TabIndex = 16;
			cboUnit[9].Text = "cboUnit";
			cboUnit[9].Visible = true;
			cboUnit[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[10].Enabled = false;
			cboUnit[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[10].Name = "_cboUnit_10";
			cboUnit[10].TabIndex = 12;
			cboUnit[10].Text = "cboUnit";
			cboUnit[10].Visible = true;
			optServiceReport = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optServiceReport[0] = _optServiceReport_0;
			optServiceReport[1] = _optServiceReport_1;
			optServiceReport[2] = _optServiceReport_2;
			optServiceReport[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[0].Checked = false;
			optServiceReport[0].Enabled = true;
			optServiceReport[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[0].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[0].Name = "_optServiceReport_0";
			optServiceReport[0].TabIndex = 15;
			optServiceReport[0].Text = "INVESTIGATE ONLY";
			optServiceReport[0].Visible = true;
			optServiceReport[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[1].Checked = false;
			optServiceReport[1].Enabled = true;
			optServiceReport[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[1].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[1].Name = "_optServiceReport_1";
			optServiceReport[1].TabIndex = 14;
			optServiceReport[1].Text = "CLEAN UP ONLY";
			optServiceReport[1].Visible = true;
			optServiceReport[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[2].Checked = false;
			optServiceReport[2].Enabled = true;
			optServiceReport[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[2].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[2].Name = "_optServiceReport_2";
			optServiceReport[2].TabIndex = 13;
			optServiceReport[2].Text = "STANDBY/STAGING ONLY";
			optServiceReport[2].Visible = true;
			cboEMSUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(13);
			cboEMSUnit[3] = _cboEMSUnit_3;
			cboEMSUnit[2] = _cboEMSUnit_2;
			cboEMSUnit[1] = _cboEMSUnit_1;
			cboEMSUnit[0] = _cboEMSUnit_0;
			cboEMSUnit[4] = _cboEMSUnit_4;
			cboEMSUnit[5] = _cboEMSUnit_5;
			cboEMSUnit[6] = _cboEMSUnit_6;
			cboEMSUnit[7] = _cboEMSUnit_7;
			cboEMSUnit[8] = _cboEMSUnit_8;
			cboEMSUnit[9] = _cboEMSUnit_9;
			cboEMSUnit[10] = _cboEMSUnit_10;
			cboEMSUnit[11] = _cboEMSUnit_11;
			cboEMSUnit[12] = _cboEMSUnit_12;
			cboEMSUnit[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[3].Enabled = true;
			cboEMSUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[3].Name = "_cboEMSUnit_3";
			cboEMSUnit[3].TabIndex = 47;
			cboEMSUnit[3].Text = "cboEMSUnit";
			cboEMSUnit[3].Visible = false;
			cboEMSUnit[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[2].Enabled = true;
			cboEMSUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[2].Name = "_cboEMSUnit_2";
			cboEMSUnit[2].TabIndex = 46;
			cboEMSUnit[2].Text = "cboEMSUnit";
			cboEMSUnit[2].Visible = false;
			cboEMSUnit[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[1].Enabled = true;
			cboEMSUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[1].Name = "_cboEMSUnit_1";
			cboEMSUnit[1].TabIndex = 45;
			cboEMSUnit[1].Text = "cboEMSUnit";
			cboEMSUnit[1].Visible = false;
			cboEMSUnit[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[0].Enabled = true;
			cboEMSUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[0].Name = "_cboEMSUnit_0";
			cboEMSUnit[0].TabIndex = 44;
			cboEMSUnit[0].Text = "cboEMSUnit";
			cboEMSUnit[0].Visible = false;
			cboEMSUnit[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[4].Enabled = true;
			cboEMSUnit[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[4].Name = "_cboEMSUnit_4";
			cboEMSUnit[4].TabIndex = 43;
			cboEMSUnit[4].Text = "cboEMSUnit";
			cboEMSUnit[4].Visible = false;
			cboEMSUnit[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[5].Enabled = true;
			cboEMSUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[5].Name = "_cboEMSUnit_5";
			cboEMSUnit[5].TabIndex = 42;
			cboEMSUnit[5].Text = "cboEMSUnit";
			cboEMSUnit[5].Visible = false;
			cboEMSUnit[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[6].Enabled = true;
			cboEMSUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[6].Name = "_cboEMSUnit_6";
			cboEMSUnit[6].TabIndex = 41;
			cboEMSUnit[6].Text = "cboEMSUnit";
			cboEMSUnit[6].Visible = false;
			cboEMSUnit[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[7].Enabled = true;
			cboEMSUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[7].Name = "_cboEMSUnit_7";
			cboEMSUnit[7].TabIndex = 40;
			cboEMSUnit[7].Text = "cboEMSUnit";
			cboEMSUnit[7].Visible = false;
			cboEMSUnit[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[8].Enabled = true;
			cboEMSUnit[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[8].Name = "_cboEMSUnit_8";
			cboEMSUnit[8].TabIndex = 39;
			cboEMSUnit[8].Text = "cboEMSUnit";
			cboEMSUnit[8].Visible = false;
			cboEMSUnit[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[9].Enabled = true;
			cboEMSUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[9].Name = "_cboEMSUnit_9";
			cboEMSUnit[9].TabIndex = 38;
			cboEMSUnit[9].Text = "cboEMSUnit";
			cboEMSUnit[9].Visible = false;
			cboEMSUnit[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[10].Enabled = true;
			cboEMSUnit[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[10].Name = "_cboEMSUnit_10";
			cboEMSUnit[10].TabIndex = 37;
			cboEMSUnit[10].Text = "cboEMSUnit";
			cboEMSUnit[10].Visible = false;
			cboEMSUnit[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[11].Enabled = true;
			cboEMSUnit[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[11].Name = "_cboEMSUnit_11";
			cboEMSUnit[11].TabIndex = 36;
			cboEMSUnit[11].Text = "cboEMSUnit";
			cboEMSUnit[11].Visible = false;
			cboEMSUnit[12].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[12].Enabled = true;
			cboEMSUnit[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[12].Name = "_cboEMSUnit_12";
			cboEMSUnit[12].TabIndex = 35;
			cboEMSUnit[12].Text = "cboEMSUnit";
			cboEMSUnit[12].Visible = false;
			this.rtxUnitNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxUnitNarration.Name = "rtxUnitNarration";
			this.rtxUnitNarration.TabIndex = 65;
			cboPersonnel = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboPersonnel[6] = _cboPersonnel_6;
			cboPersonnel[0] = _cboPersonnel_0;
			cboPersonnel[1] = _cboPersonnel_1;
			cboPersonnel[2] = _cboPersonnel_2;
			cboPersonnel[3] = _cboPersonnel_3;
			cboPersonnel[4] = _cboPersonnel_4;
			cboPersonnel[7] = _cboPersonnel_7;
			cboPersonnel[5] = _cboPersonnel_5;
			cboPersonnel[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[6].Enabled = true;
			cboPersonnel[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[6].Name = "_cboPersonnel_6";
			cboPersonnel[6].TabIndex = 76;
			cboPersonnel[6].Visible = false;
			cboPersonnel[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[0].Enabled = true;
			cboPersonnel[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[0].Name = "_cboPersonnel_0";
			cboPersonnel[0].TabIndex = 104;
			cboPersonnel[0].Text = "Williamson-Jensen, Kimberly";
			cboPersonnel[0].Visible = true;
			cboPersonnel[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[1].Enabled = true;
			cboPersonnel[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[1].Name = "_cboPersonnel_1";
			cboPersonnel[1].TabIndex = 103;
			cboPersonnel[1].Visible = true;
			cboPersonnel[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[2].Enabled = true;
			cboPersonnel[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[2].Name = "_cboPersonnel_2";
			cboPersonnel[2].TabIndex = 102;
			cboPersonnel[2].Visible = true;
			cboPersonnel[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[3].Enabled = true;
			cboPersonnel[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[3].Name = "_cboPersonnel_3";
			cboPersonnel[3].TabIndex = 101;
			cboPersonnel[3].Visible = false;
			cboPersonnel[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[4].Enabled = true;
			cboPersonnel[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[4].Name = "_cboPersonnel_4";
			cboPersonnel[4].TabIndex = 100;
			cboPersonnel[4].Visible = false;
			cboPersonnel[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[7].Enabled = true;
			cboPersonnel[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[7].Name = "_cboPersonnel_7";
			cboPersonnel[7].TabIndex = 90;
			cboPersonnel[7].Visible = true;
			cboPersonnel[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[5].Enabled = true;
			cboPersonnel[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[5].Name = "_cboPersonnel_5";
			cboPersonnel[5].TabIndex = 73;
			cboPersonnel[5].Visible = false;
			cboPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(7);
			cboPosition[6] = _cboPosition_6;
			cboPosition[2] = _cboPosition_2;
			cboPosition[1] = _cboPosition_1;
			cboPosition[0] = _cboPosition_0;
			cboPosition[3] = _cboPosition_3;
			cboPosition[4] = _cboPosition_4;
			cboPosition[5] = _cboPosition_5;
			cboPosition[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[6].Enabled = true;
			cboPosition[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[6].Name = "_cboPosition_6";
			cboPosition[6].TabIndex = 77;
			cboPosition[6].Visible = false;
			cboPosition[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[2].Enabled = true;
			cboPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[2].Name = "_cboPosition_2";
			cboPosition[2].TabIndex = 110;
			cboPosition[2].Visible = true;
			cboPosition[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[1].Enabled = true;
			cboPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[1].Name = "_cboPosition_1";
			cboPosition[1].TabIndex = 109;
			cboPosition[1].Visible = true;
			cboPosition[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[0].Enabled = true;
			cboPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[0].Name = "_cboPosition_0";
			cboPosition[0].TabIndex = 108;
			cboPosition[0].Visible = true;
			cboPosition[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[3].Enabled = true;
			cboPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[3].Name = "_cboPosition_3";
			cboPosition[3].TabIndex = 99;
			cboPosition[3].Visible = false;
			cboPosition[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[4].Enabled = true;
			cboPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[4].Name = "_cboPosition_4";
			cboPosition[4].TabIndex = 98;
			cboPosition[4].Visible = false;
			cboPosition[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[5].Enabled = true;
			cboPosition[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[5].Name = "_cboPosition_5";
			cboPosition[5].TabIndex = 74;
			cboPosition[5].Visible = false;
			chkCasualty = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkCasualty[6] = _chkCasualty_6;
			chkCasualty[2] = _chkCasualty_2;
			chkCasualty[1] = _chkCasualty_1;
			chkCasualty[0] = _chkCasualty_0;
			chkCasualty[3] = _chkCasualty_3;
			chkCasualty[4] = _chkCasualty_4;
			chkCasualty[7] = _chkCasualty_7;
			chkCasualty[5] = _chkCasualty_5;
			chkCasualty[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[6].Enabled = true;
			chkCasualty[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[6].Name = "_chkCasualty_6";
			chkCasualty[6].TabIndex = 78;
			chkCasualty[6].Text = "";
			chkCasualty[6].Visible = false;
			chkCasualty[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[2].Enabled = true;
			chkCasualty[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[2].Name = "_chkCasualty_2";
			chkCasualty[2].TabIndex = 107;
			chkCasualty[2].Text = "";
			chkCasualty[2].Visible = true;
			chkCasualty[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[1].Enabled = true;
			chkCasualty[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[1].Name = "_chkCasualty_1";
			chkCasualty[1].TabIndex = 106;
			chkCasualty[1].Text = "";
			chkCasualty[1].Visible = true;
			chkCasualty[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[0].Enabled = true;
			chkCasualty[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[0].Name = "_chkCasualty_0";
			chkCasualty[0].TabIndex = 105;
			chkCasualty[0].Text = "";
			chkCasualty[0].Visible = true;
			chkCasualty[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[3].Enabled = true;
			chkCasualty[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[3].Name = "_chkCasualty_3";
			chkCasualty[3].TabIndex = 97;
			chkCasualty[3].Text = "";
			chkCasualty[3].Visible = false;
			chkCasualty[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[4].Enabled = true;
			chkCasualty[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[4].Name = "_chkCasualty_4";
			chkCasualty[4].TabIndex = 96;
			chkCasualty[4].Text = "";
			chkCasualty[4].Visible = false;
			chkCasualty[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[7].Enabled = true;
			chkCasualty[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[7].Name = "_chkCasualty_7";
			chkCasualty[7].TabIndex = 89;
			chkCasualty[7].Text = "";
			chkCasualty[7].Visible = false;
			chkCasualty[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[5].Enabled = true;
			chkCasualty[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[5].Name = "_chkCasualty_5";
			chkCasualty[5].TabIndex = 75;
			chkCasualty[5].Text = "";
			chkCasualty[5].Visible = false;
			txtAmendTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>>(6);
			txtAmendTime[2] = _txtAmendTime_2;
			txtAmendTime[3] = _txtAmendTime_3;
			txtAmendTime[4] = _txtAmendTime_4;
			txtAmendTime[5] = _txtAmendTime_5;
			txtAmendTime[1] = _txtAmendTime_1;
			txtAmendTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[2].Mask = "##:##";
			txtAmendTime[2].Name = "_txtAmendTime_2";
			txtAmendTime[2].PromptChar = '_';
			txtAmendTime[2].TabIndex = 120;
			txtAmendTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[3].Mask = "##:##";
			txtAmendTime[3].Name = "_txtAmendTime_3";
			txtAmendTime[3].PromptChar = '_';
			txtAmendTime[3].TabIndex = 121;
			txtAmendTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[4].Mask = "##:##";
			txtAmendTime[4].Name = "_txtAmendTime_4";
			txtAmendTime[4].PromptChar = '_';
			txtAmendTime[4].TabIndex = 122;
			txtAmendTime[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[5].Mask = "##:##";
			txtAmendTime[5].Name = "_txtAmendTime_5";
			txtAmendTime[5].PromptChar = '_';
			txtAmendTime[5].TabIndex = 123;
			txtAmendTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[1].Mask = "##:##";
			txtAmendTime[1].Name = "_txtAmendTime_1";
			txtAmendTime[1].PromptChar = '_';
			txtAmendTime[1].TabIndex = 124;
			cboAmendReason = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(6);
			cboAmendReason[5] = _cboAmendReason_5;
			cboAmendReason[4] = _cboAmendReason_4;
			cboAmendReason[3] = _cboAmendReason_3;
			cboAmendReason[2] = _cboAmendReason_2;
			cboAmendReason[1] = _cboAmendReason_1;
			cboAmendReason[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[5].Enabled = true;
			cboAmendReason[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[5].Name = "_cboAmendReason_5";
			cboAmendReason[5].TabIndex = 119;
			cboAmendReason[5].Visible = true;
			cboAmendReason[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[4].Enabled = true;
			cboAmendReason[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[4].Name = "_cboAmendReason_4";
			cboAmendReason[4].TabIndex = 118;
			cboAmendReason[4].Visible = true;
			cboAmendReason[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[3].Enabled = true;
			cboAmendReason[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[3].Name = "_cboAmendReason_3";
			cboAmendReason[3].TabIndex = 117;
			cboAmendReason[3].Visible = true;
			cboAmendReason[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[2].Enabled = true;
			cboAmendReason[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[2].Name = "_cboAmendReason_2";
			cboAmendReason[2].TabIndex = 116;
			cboAmendReason[2].Visible = true;
			cboAmendReason[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[1].Enabled = true;
			cboAmendReason[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[1].Name = "_cboAmendReason_1";
			cboAmendReason[1].TabIndex = 115;
			cboAmendReason[1].Visible = true;
			this.frmSituation = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmSituation
			// 
			this.frmSituation.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmSituation.Enabled = true;
			this.frmSituation.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.frmSituation.Name = "frmSituation";
			this.frmSituation.TabIndex = 5;
			this.frmSituation.Visible = true;
			this.chkSirenSingle = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkSirenSingle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkSirenSingle.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkSirenSingle.Enabled = true;
			this.chkSirenSingle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkSirenSingle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.chkSirenSingle.Name = "chkSirenSingle";
			this.chkSirenSingle.TabIndex = 206;
			this.chkSirenSingle.Text = "SIREN REPORT ?";
			this.chkSirenSingle.Visible = true;
			lbPatient = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(13);
			lbPatient[0] = _lbPatient_0;
			lbPatient[1] = _lbPatient_1;
			lbPatient[2] = _lbPatient_2;
			lbPatient[3] = _lbPatient_3;
			lbPatient[4] = _lbPatient_4;
			lbPatient[5] = _lbPatient_5;
			lbPatient[6] = _lbPatient_6;
			lbPatient[7] = _lbPatient_7;
			lbPatient[8] = _lbPatient_8;
			lbPatient[9] = _lbPatient_9;
			lbPatient[10] = _lbPatient_10;
			lbPatient[11] = _lbPatient_11;
			lbPatient[12] = _lbPatient_12;
			lbPatient[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[0].Name = "_lbPatient_0";
			lbPatient[0].TabIndex = 60;
			lbPatient[0].Text = "PCR";
			lbPatient[0].Visible = false;
			lbPatient[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[1].Name = "_lbPatient_1";
			lbPatient[1].TabIndex = 59;
			lbPatient[1].Text = "PCR";
			lbPatient[1].Visible = false;
			lbPatient[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[2].Name = "_lbPatient_2";
			lbPatient[2].TabIndex = 58;
			lbPatient[2].Text = "PCR";
			lbPatient[2].Visible = false;
			lbPatient[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[3].Name = "_lbPatient_3";
			lbPatient[3].TabIndex = 57;
			lbPatient[3].Text = "PCR";
			lbPatient[3].Visible = false;
			lbPatient[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[4].Name = "_lbPatient_4";
			lbPatient[4].TabIndex = 56;
			lbPatient[4].Text = "PCR";
			lbPatient[4].Visible = false;
			lbPatient[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[5].Name = "_lbPatient_5";
			lbPatient[5].TabIndex = 55;
			lbPatient[5].Text = "PCR";
			lbPatient[5].Visible = false;
			lbPatient[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[6].Name = "_lbPatient_6";
			lbPatient[6].TabIndex = 54;
			lbPatient[6].Text = "PCR";
			lbPatient[6].Visible = false;
			lbPatient[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[7].Name = "_lbPatient_7";
			lbPatient[7].TabIndex = 53;
			lbPatient[7].Text = "PCR";
			lbPatient[7].Visible = false;
			lbPatient[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[8].Name = "_lbPatient_8";
			lbPatient[8].TabIndex = 52;
			lbPatient[8].Text = "PCR";
			lbPatient[8].Visible = false;
			lbPatient[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[9].Name = "_lbPatient_9";
			lbPatient[9].TabIndex = 51;
			lbPatient[9].Text = "PCR";
			lbPatient[9].Visible = false;
			lbPatient[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[10].Name = "_lbPatient_10";
			lbPatient[10].TabIndex = 50;
			lbPatient[10].Text = "PCR";
			lbPatient[10].Visible = false;
			lbPatient[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[11].Name = "_lbPatient_11";
			lbPatient[11].TabIndex = 49;
			lbPatient[11].Text = "PCR";
			lbPatient[11].Visible = false;
			lbPatient[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[12].Name = "_lbPatient_12";
			lbPatient[12].TabIndex = 48;
			lbPatient[12].Text = "PCR";
			lbPatient[12].Visible = false;
			chkSirenReport = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(13);
			chkSirenReport[12] = _chkSirenReport_12;
			chkSirenReport[11] = _chkSirenReport_11;
			chkSirenReport[10] = _chkSirenReport_10;
			chkSirenReport[9] = _chkSirenReport_9;
			chkSirenReport[8] = _chkSirenReport_8;
			chkSirenReport[7] = _chkSirenReport_7;
			chkSirenReport[6] = _chkSirenReport_6;
			chkSirenReport[5] = _chkSirenReport_5;
			chkSirenReport[4] = _chkSirenReport_4;
			chkSirenReport[3] = _chkSirenReport_3;
			chkSirenReport[2] = _chkSirenReport_2;
			chkSirenReport[1] = _chkSirenReport_1;
			chkSirenReport[0] = _chkSirenReport_0;
			chkSirenReport[12].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[12].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[12].Enabled = true;
			chkSirenReport[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[12].Name = "_chkSirenReport_12";
			chkSirenReport[12].TabIndex = 205;
			chkSirenReport[12].Text = "Siren?";
			chkSirenReport[12].Visible = true;
			chkSirenReport[11].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[11].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[11].Enabled = true;
			chkSirenReport[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[11].Name = "_chkSirenReport_11";
			chkSirenReport[11].TabIndex = 204;
			chkSirenReport[11].Text = "Siren?";
			chkSirenReport[11].Visible = true;
			chkSirenReport[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[10].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[10].Enabled = true;
			chkSirenReport[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[10].Name = "_chkSirenReport_10";
			chkSirenReport[10].TabIndex = 203;
			chkSirenReport[10].Text = "Siren?";
			chkSirenReport[10].Visible = true;
			chkSirenReport[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[9].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[9].Enabled = true;
			chkSirenReport[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[9].Name = "_chkSirenReport_9";
			chkSirenReport[9].TabIndex = 202;
			chkSirenReport[9].Text = "Siren?";
			chkSirenReport[9].Visible = true;
			chkSirenReport[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[8].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[8].Enabled = true;
			chkSirenReport[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[8].Name = "_chkSirenReport_8";
			chkSirenReport[8].TabIndex = 201;
			chkSirenReport[8].Text = "Siren?";
			chkSirenReport[8].Visible = true;
			chkSirenReport[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[7].Enabled = true;
			chkSirenReport[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[7].Name = "_chkSirenReport_7";
			chkSirenReport[7].TabIndex = 200;
			chkSirenReport[7].Text = "Siren?";
			chkSirenReport[7].Visible = true;
			chkSirenReport[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[6].Enabled = true;
			chkSirenReport[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[6].Name = "_chkSirenReport_6";
			chkSirenReport[6].TabIndex = 199;
			chkSirenReport[6].Text = "Siren?";
			chkSirenReport[6].Visible = true;
			chkSirenReport[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[5].Enabled = true;
			chkSirenReport[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[5].Name = "_chkSirenReport_5";
			chkSirenReport[5].TabIndex = 198;
			chkSirenReport[5].Text = "Siren?";
			chkSirenReport[5].Visible = true;
			chkSirenReport[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[4].Enabled = true;
			chkSirenReport[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[4].Name = "_chkSirenReport_4";
			chkSirenReport[4].TabIndex = 197;
			chkSirenReport[4].Text = "Siren?";
			chkSirenReport[4].Visible = true;
			chkSirenReport[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[3].Enabled = true;
			chkSirenReport[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[3].Name = "_chkSirenReport_3";
			chkSirenReport[3].TabIndex = 196;
			chkSirenReport[3].Text = "Siren?";
			chkSirenReport[3].Visible = true;
			chkSirenReport[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[2].Enabled = true;
			chkSirenReport[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[2].Name = "_chkSirenReport_2";
			chkSirenReport[2].TabIndex = 195;
			chkSirenReport[2].Text = "Siren?";
			chkSirenReport[2].Visible = true;
			chkSirenReport[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[1].Enabled = true;
			chkSirenReport[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[1].Name = "_chkSirenReport_1";
			chkSirenReport[1].TabIndex = 194;
			chkSirenReport[1].Text = "Siren?";
			chkSirenReport[1].Visible = true;
			chkSirenReport[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[0].Enabled = true;
			chkSirenReport[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[0].Name = "_chkSirenReport_0";
			chkSirenReport[0].TabIndex = 193;
			chkSirenReport[0].Text = "Siren?";
			chkSirenReport[0].Visible = true;
			this.chkAddressCorrection = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAddressCorrection.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAddressCorrection.Enabled = true;
			this.chkAddressCorrection.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAddressCorrection.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.chkAddressCorrection.Name = "chkAddressCorrection";
			this.chkAddressCorrection.TabIndex = 190;
			this.chkAddressCorrection.Text = "   Incident Address          Correction Needed";
			this.chkAddressCorrection.Visible = false;
			this.UnitReportID = 0;
			lbActualTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(6);
			lbActualTime[1] = _lbActualTime_1;
			lbActualTime[2] = _lbActualTime_2;
			lbActualTime[3] = _lbActualTime_3;
			lbActualTime[4] = _lbActualTime_4;
			lbActualTime[5] = _lbActualTime_5;
			lbActualTime[0] = _lbActualTime_0;
			lbActualTime[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[1].Name = "_lbActualTime_1";
			lbActualTime[1].TabIndex = 131;
			lbActualTime[1].Tag = "4";
			lbActualTime[1].Text = "55:55";
			lbActualTime[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[2].Name = "_lbActualTime_2";
			lbActualTime[2].TabIndex = 130;
			lbActualTime[2].Tag = "5";
			lbActualTime[2].Text = "55:55";
			lbActualTime[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[3].Name = "_lbActualTime_3";
			lbActualTime[3].TabIndex = 129;
			lbActualTime[3].Tag = "6";
			lbActualTime[3].Text = "55:55";
			lbActualTime[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[4].Name = "_lbActualTime_4";
			lbActualTime[4].TabIndex = 128;
			lbActualTime[4].Tag = "7";
			lbActualTime[4].Text = "55:55";
			lbActualTime[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[5].Name = "_lbActualTime_5";
			lbActualTime[5].TabIndex = 127;
			lbActualTime[5].Tag = "8";
			lbActualTime[5].Text = "55:55";
			lbActualTime[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[0].Name = "_lbActualTime_0";
			lbActualTime[0].TabIndex = 126;
			lbActualTime[0].Tag = "3";
			lbActualTime[0].Text = "55:55";
			cmdClearPerson = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(8);
			cmdClearPerson[6] = _cmdClearPerson_6;
			cmdClearPerson[0] = _cmdClearPerson_0;
			cmdClearPerson[1] = _cmdClearPerson_1;
			cmdClearPerson[2] = _cmdClearPerson_2;
			cmdClearPerson[3] = _cmdClearPerson_3;
			cmdClearPerson[4] = _cmdClearPerson_4;
			cmdClearPerson[7] = _cmdClearPerson_7;
			cmdClearPerson[5] = _cmdClearPerson_5;
			cmdClearPerson[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[6].Name = "_cmdClearPerson_6";
			cmdClearPerson[6].TabIndex = 166;
			cmdClearPerson[6].Visible = false;
			cmdClearPerson[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[0].Name = "_cmdClearPerson_0";
			cmdClearPerson[0].TabIndex = 86;
			cmdClearPerson[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[1].Name = "_cmdClearPerson_1";
			cmdClearPerson[1].TabIndex = 85;
			cmdClearPerson[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[2].Name = "_cmdClearPerson_2";
			cmdClearPerson[2].TabIndex = 84;
			cmdClearPerson[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[3].Name = "_cmdClearPerson_3";
			cmdClearPerson[3].TabIndex = 83;
			cmdClearPerson[3].Visible = false;
			cmdClearPerson[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[4].Name = "_cmdClearPerson_4";
			cmdClearPerson[4].TabIndex = 82;
			cmdClearPerson[4].Visible = false;
			cmdClearPerson[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[7].Name = "_cmdClearPerson_7";
			cmdClearPerson[7].TabIndex = 81;
			cmdClearPerson[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[5].Name = "_cmdClearPerson_5";
			cmdClearPerson[5].TabIndex = 80;
			cmdClearPerson[5].Visible = false;
			this.DontRespond = 0;
			this.MinPatients = 0;
			this.MinCivCasualty = 0;
			this.MinExposures = 0;
			this.TotalExposures = 0;
			cmdUnlock = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(11);
			cmdUnlock[9] = _cmdUnlock_9;
			cmdUnlock[8] = _cmdUnlock_8;
			cmdUnlock[7] = _cmdUnlock_7;
			cmdUnlock[6] = _cmdUnlock_6;
			cmdUnlock[5] = _cmdUnlock_5;
			cmdUnlock[3] = _cmdUnlock_3;
			cmdUnlock[2] = _cmdUnlock_2;
			cmdUnlock[1] = _cmdUnlock_1;
			cmdUnlock[0] = _cmdUnlock_0;
			cmdUnlock[10] = _cmdUnlock_10;
			cmdUnlock[9].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[9].Name = "_cmdUnlock_9";
			cmdUnlock[9].TabIndex = 152;
			cmdUnlock[9].Visible = false;
			cmdUnlock[8].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[8].Name = "_cmdUnlock_8";
			cmdUnlock[8].TabIndex = 151;
			cmdUnlock[8].Visible = false;
			cmdUnlock[7].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[7].Name = "_cmdUnlock_7";
			cmdUnlock[7].TabIndex = 150;
			cmdUnlock[7].Visible = false;
			cmdUnlock[6].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[6].Name = "_cmdUnlock_6";
			cmdUnlock[6].TabIndex = 149;
			cmdUnlock[6].Visible = false;
			cmdUnlock[5].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[5].Name = "_cmdUnlock_5";
			cmdUnlock[5].TabIndex = 148;
			cmdUnlock[5].Visible = false;
			cmdUnlock[3].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[3].Name = "_cmdUnlock_3";
			cmdUnlock[3].TabIndex = 147;
			cmdUnlock[3].Visible = false;
			cmdUnlock[2].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[2].Name = "_cmdUnlock_2";
			cmdUnlock[2].TabIndex = 146;
			cmdUnlock[2].Visible = false;
			cmdUnlock[1].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[1].Name = "_cmdUnlock_1";
			cmdUnlock[1].TabIndex = 145;
			cmdUnlock[1].Visible = false;
			cmdUnlock[0].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[0].Name = "_cmdUnlock_0";
			cmdUnlock[0].TabIndex = 144;
			cmdUnlock[0].Visible = false;
			cmdUnlock[10].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdUnlock[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdUnlock[10].Name = "_cmdUnlock_10";
			cmdUnlock[10].TabIndex = 172;
			cmdUnlock[10].Visible = false;
			this.frmMultiEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmMultiEMS
			// 
			this.frmMultiEMS.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmMultiEMS.Enabled = true;
			this.frmMultiEMS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmMultiEMS.Name = "frmMultiEMS";
			this.frmMultiEMS.TabIndex = 34;
			this.frmMultiEMS.Visible = false;
			cmdEMSUnlock = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(13);
			cmdEMSUnlock[12] = _cmdEMSUnlock_12;
			cmdEMSUnlock[11] = _cmdEMSUnlock_11;
			cmdEMSUnlock[10] = _cmdEMSUnlock_10;
			cmdEMSUnlock[9] = _cmdEMSUnlock_9;
			cmdEMSUnlock[8] = _cmdEMSUnlock_8;
			cmdEMSUnlock[7] = _cmdEMSUnlock_7;
			cmdEMSUnlock[6] = _cmdEMSUnlock_6;
			cmdEMSUnlock[5] = _cmdEMSUnlock_5;
			cmdEMSUnlock[4] = _cmdEMSUnlock_4;
			cmdEMSUnlock[3] = _cmdEMSUnlock_3;
			cmdEMSUnlock[2] = _cmdEMSUnlock_2;
			cmdEMSUnlock[1] = _cmdEMSUnlock_1;
			cmdEMSUnlock[0] = _cmdEMSUnlock_0;
			cmdEMSUnlock[12].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[12].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[12].Name = "_cmdEMSUnlock_12";
			cmdEMSUnlock[12].TabIndex = 165;
			cmdEMSUnlock[12].Visible = false;
			cmdEMSUnlock[11].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[11].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[11].Name = "_cmdEMSUnlock_11";
			cmdEMSUnlock[11].TabIndex = 164;
			cmdEMSUnlock[11].Visible = false;
			cmdEMSUnlock[10].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[10].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[10].Name = "_cmdEMSUnlock_10";
			cmdEMSUnlock[10].TabIndex = 163;
			cmdEMSUnlock[10].Visible = false;
			cmdEMSUnlock[9].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[9].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[9].Name = "_cmdEMSUnlock_9";
			cmdEMSUnlock[9].TabIndex = 162;
			cmdEMSUnlock[9].Visible = false;
			cmdEMSUnlock[8].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[8].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[8].Name = "_cmdEMSUnlock_8";
			cmdEMSUnlock[8].TabIndex = 161;
			cmdEMSUnlock[8].Visible = false;
			cmdEMSUnlock[7].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[7].Name = "_cmdEMSUnlock_7";
			cmdEMSUnlock[7].TabIndex = 160;
			cmdEMSUnlock[7].Visible = false;
			cmdEMSUnlock[6].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[6].Name = "_cmdEMSUnlock_6";
			cmdEMSUnlock[6].TabIndex = 159;
			cmdEMSUnlock[6].Visible = false;
			cmdEMSUnlock[5].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[5].Name = "_cmdEMSUnlock_5";
			cmdEMSUnlock[5].TabIndex = 158;
			cmdEMSUnlock[5].Visible = false;
			cmdEMSUnlock[4].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[4].Name = "_cmdEMSUnlock_4";
			cmdEMSUnlock[4].TabIndex = 157;
			cmdEMSUnlock[4].Visible = false;
			cmdEMSUnlock[3].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[3].Name = "_cmdEMSUnlock_3";
			cmdEMSUnlock[3].TabIndex = 156;
			cmdEMSUnlock[3].Visible = false;
			cmdEMSUnlock[2].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[2].Name = "_cmdEMSUnlock_2";
			cmdEMSUnlock[2].TabIndex = 155;
			cmdEMSUnlock[2].Visible = false;
			cmdEMSUnlock[1].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[1].Name = "_cmdEMSUnlock_1";
			cmdEMSUnlock[1].TabIndex = 154;
			cmdEMSUnlock[1].Visible = false;
			cmdEMSUnlock[0].BackColor = UpgradeHelpers.Helpers.Color.Red;
			cmdEMSUnlock[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdEMSUnlock[0].Name = "_cmdEMSUnlock_0";
			cmdEMSUnlock[0].TabIndex = 153;
			cmdEMSUnlock[0].Visible = false;
			this.ReportType = 0;
			lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			lbFrameTitle[9] = _lbFrameTitle_9;
			lbFrameTitle[0] = _lbFrameTitle_0;
			lbFrameTitle[2] = _lbFrameTitle_2;
			lbFrameTitle[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			lbFrameTitle[9].Name = "_lbFrameTitle_9";
			lbFrameTitle[9].TabIndex = 189;
			lbFrameTitle[9].Text = "INCIDENT ADDRESS CORRECTION";
			lbFrameTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 18f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbFrameTitle[0].Name = "_lbFrameTitle_0";
			lbFrameTitle[0].TabIndex = 63;
			lbFrameTitle[0].Text = "UNIT RESPONSE REPORT";
			lbFrameTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			lbFrameTitle[2].Name = "_lbFrameTitle_2";
			lbFrameTitle[2].TabIndex = 33;
			lbFrameTitle[2].Text = "INCIDENT SITUATION FOUND REPORT";
			chkExposure = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkExposure[6] = _chkExposure_6;
			chkExposure[0] = _chkExposure_0;
			chkExposure[1] = _chkExposure_1;
			chkExposure[2] = _chkExposure_2;
			chkExposure[3] = _chkExposure_3;
			chkExposure[4] = _chkExposure_4;
			chkExposure[7] = _chkExposure_7;
			chkExposure[5] = _chkExposure_5;
			chkExposure[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[6].Enabled = true;
			chkExposure[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[6].Name = "_chkExposure_6";
			chkExposure[6].TabIndex = 167;
			chkExposure[6].Text = "Check1";
			chkExposure[6].Visible = false;
			chkExposure[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[0].Enabled = true;
			chkExposure[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[0].Name = "_chkExposure_0";
			chkExposure[0].TabIndex = 95;
			chkExposure[0].Text = "Check1";
			chkExposure[0].Visible = false;
			chkExposure[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[1].Enabled = true;
			chkExposure[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[1].Name = "_chkExposure_1";
			chkExposure[1].TabIndex = 94;
			chkExposure[1].Text = "Check1";
			chkExposure[1].Visible = false;
			chkExposure[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[2].Enabled = true;
			chkExposure[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[2].Name = "_chkExposure_2";
			chkExposure[2].TabIndex = 93;
			chkExposure[2].Text = "Check1";
			chkExposure[2].Visible = false;
			chkExposure[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[3].Enabled = true;
			chkExposure[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[3].Name = "_chkExposure_3";
			chkExposure[3].TabIndex = 92;
			chkExposure[3].Text = "Check1";
			chkExposure[3].Visible = false;
			chkExposure[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[4].Enabled = true;
			chkExposure[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[4].Name = "_chkExposure_4";
			chkExposure[4].TabIndex = 91;
			chkExposure[4].Text = "Check1";
			chkExposure[4].Visible = false;
			chkExposure[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[7].Enabled = true;
			chkExposure[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[7].Name = "_chkExposure_7";
			chkExposure[7].TabIndex = 88;
			chkExposure[7].Text = "Check1";
			chkExposure[7].Visible = false;
			chkExposure[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkExposure[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkExposure[5].Enabled = true;
			chkExposure[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkExposure[5].Name = "_chkExposure_5";
			chkExposure[5].TabIndex = 79;
			chkExposure[5].Text = "Check1";
			chkExposure[5].Visible = false;
			this.Name = "TFDIncident.frmIncident";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCityCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmIncidentAddressCorrection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDispatch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnroute { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOnscene { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTransport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTransportComplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEventTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTimeTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAmendedTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAmendedReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbURDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstActionsTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstReasonDelay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbActionsTakenTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReasonsDelayTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnitComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmServiceSit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberPatients { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberCivCasulties { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSirenTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEMSTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmSitFound { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLockedMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picFireBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCivilianCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel FDCaresBtn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdViewReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdSave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkSitFound { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboUnit { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optServiceReport { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboEMSUnit { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxUnitNarration { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboPersonnel { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkCasualty { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel> txtAmendTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboAmendReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmSituation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSirenSingle { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPatient { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkSirenReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAddressCorrection { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 UnitReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbActualTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdClearPerson { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DontRespond { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MinPatients { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MinCivCasualty { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MinExposures { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalExposures { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdUnlock { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmMultiEMS { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdEMSUnlock { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkExposure { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtXStreetName_TextChanged()
		{
			if ( _txtXStreetName_TextChanged != null )
				_txtXStreetName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXStreetName_TextChanged;

		public void OntxtXHouseNumber_TextChanged()
		{
			if ( _txtXHouseNumber_TextChanged != null )
				_txtXHouseNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXHouseNumber_TextChanged;

		public void OntxtNumberExposures_TextChanged()
		{
			if ( _txtNumberExposures_TextChanged != null )
				_txtNumberExposures_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberExposures_TextChanged;

		public void OntxtNumberPatients_TextChanged()
		{
			if ( _txtNumberPatients_TextChanged != null )
				_txtNumberPatients_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberPatients_TextChanged;

		public void OntxtNumberCivCasulties_TextChanged()
		{
			if ( _txtNumberCivCasulties_TextChanged != null )
				_txtNumberCivCasulties_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberCivCasulties_TextChanged;
	}

}