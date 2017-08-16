using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.wzdMain))]
	public class wzdMainViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
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
			this.cboCityCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCityCode
			// 
			this.cboCityCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCityCode.Enabled = true;
			this.cboCityCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCityCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboCityCode.Name = "cboCityCode";
			this.cboCityCode.TabIndex = 309;
			this.cboCityCode.Visible = true;
			this.txtXHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.txtXHouseNumber.Name = "txtXHouseNumber";
			this.txtXHouseNumber.TabIndex = 304;
			this.txtXStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.txtXStreetName.Name = "txtXStreetName";
			this.txtXStreetName.TabIndex = 306;
			this.cboXPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXPrefix
			// 
			this.cboXPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXPrefix.Enabled = true;
			this.cboXPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXPrefix.Name = "cboXPrefix";
			this.cboXPrefix.TabIndex = 305;
			this.cboXPrefix.Visible = true;
			this.cboXStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXStreetType
			// 
			this.cboXStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXStreetType.Enabled = true;
			this.cboXStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXStreetType.Name = "cboXStreetType";
			this.cboXStreetType.TabIndex = 307;
			this.cboXStreetType.Visible = true;
			this.cboXSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXSuffix
			// 
			this.cboXSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXSuffix.Enabled = true;
			this.cboXSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.cboXSuffix.Name = "cboXSuffix";
			this.cboXSuffix.TabIndex = 308;
			this.cboXSuffix.Visible = true;
			this.Label34 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label34
			// 
			this.Label34.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label34.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label34.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label34.Name = "Label34";
			this.Label34.TabIndex = 315;
			this.Label34.Text = "HOUSE#";
			this.Label33 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label33
			// 
			this.Label33.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label33.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label33.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label33.Name = "Label33";
			this.Label33.TabIndex = 314;
			this.Label33.Text = "PREFIX";
			this.Label32 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label32
			// 
			this.Label32.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label32.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label32.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label32.Name = "Label32";
			this.Label32.TabIndex = 313;
			this.Label32.Text = "STREET NAME";
			this.Label27 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label27
			// 
			this.Label27.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label27.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label27.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label27.Name = "Label27";
			this.Label27.TabIndex = 312;
			this.Label27.Text = "STREET TYPE";
			this.Label26 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label26
			// 
			this.Label26.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label26.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label26.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label26.Name = "Label26";
			this.Label26.TabIndex = 311;
			this.Label26.Text = "SUFFIX";
			this.Label25 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label25
			// 
			this.Label25.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label25.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label25.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			this.Label25.Name = "Label25";
			this.Label25.TabIndex = 310;
			this.Label25.Text = "CITY";
			this._lbFrameTitle_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmIncidentAddressCorrection = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmIncidentAddressCorrection
			// 
			this.frmIncidentAddressCorrection.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmIncidentAddressCorrection.Enabled = true;
			this.frmIncidentAddressCorrection.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmIncidentAddressCorrection.Name = "frmIncidentAddressCorrection";
			this.frmIncidentAddressCorrection.TabIndex = 302;
			this.frmIncidentAddressCorrection.Visible = true;
			this.lstPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPPE
			// 
			this.lstPPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstPPE.Enabled = true;
			this.lstPPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstPPE.Name = "lstPPE";
			this.lstPPE.TabIndex = 296;
			this.lstPPE.Visible = true;
			this.lstPPE.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.cboFPEProblem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEProblem
			// 
			this.cboFPEProblem.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEProblem.Enabled = true;
			this.cboFPEProblem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEProblem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEProblem.Name = "cboFPEProblem";
			this.cboFPEProblem.TabIndex = 289;
			this.cboFPEProblem.Text = "cboFPEProblem";
			this.cboFPEProblem.Visible = true;
			this.cboFPEEquipment = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEEquipment
			// 
			this.cboFPEEquipment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEEquipment.Enabled = true;
			this.cboFPEEquipment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEEquipment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEEquipment.Name = "cboFPEEquipment";
			this.cboFPEEquipment.TabIndex = 279;
			this.cboFPEEquipment.Text = "cboFPEEquipment";
			this.cboFPEEquipment.Visible = true;
			this.cboFPEStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEStatus
			// 
			this.cboFPEStatus.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEStatus.Enabled = true;
			this.cboFPEStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEStatus.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEStatus.Name = "cboFPEStatus";
			this.cboFPEStatus.TabIndex = 278;
			this.cboFPEStatus.Text = "cboFPEStatus";
			this.cboFPEStatus.Visible = true;
			this.Label24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label24
			// 
			this.Label24.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label24.Name = "Label24";
			this.Label24.TabIndex = 298;
			this.Label24.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS";
			this.Label31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label31
			// 
			this.Label31.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label31.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label31.Name = "Label31";
			this.Label31.TabIndex = 287;
			this.Label31.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS";
			this.Label30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label30
			// 
			this.Label30.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label30.Name = "Label30";
			this.Label30.TabIndex = 285;
			this.Label30.Text = "SELECT PPE EQUIPMENT ";
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 283;
			this.Label29.Text = "INDICATE EQUIPMENT STATUS";
			this.Label28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label28
			// 
			this.Label28.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label28.Name = "Label28";
			this.Label28.TabIndex = 281;
			this.Label28.Text = "SELECT EQUIPMENT PROBLEM";
			this.frmFPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFPE
			// 
			this.frmFPE.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.frmFPE.Enabled = true;
			this.frmFPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFPE.Name = "frmFPE";
			this.frmFPE.TabIndex = 277;
			this.frmFPE.Visible = false;
			this.lbNavMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNavMessage
			// 
			this.lbNavMessage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNavMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbNavMessage.Name = "lbNavMessage";
			this.lbNavMessage.TabIndex = 276;
			this.lbNavMessage.Text = "";
			this.Label23 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label23
			// 
			this.Label23.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 275;
			this.Label23.Text = "Wizard Navigation Bar";
			this.NavBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// NavBar
			// 
			this.NavBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.NavBar.Enabled = true;
			this.NavBar.Name = "NavBar";
			this.NavBar.Visible = true;
			this.cboLocationAtInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLocationAtInjury
			// 
			this.cboLocationAtInjury.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboLocationAtInjury.Enabled = true;
			this.cboLocationAtInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboLocationAtInjury.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboLocationAtInjury.Name = "cboLocationAtInjury";
			this.cboLocationAtInjury.TabIndex = 288;
			this.cboLocationAtInjury.Text = "cboLocationAtInjury";
			this.cboLocationAtInjury.Visible = true;
			this.cboInjuryCausedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryCausedBy
			// 
			this.cboInjuryCausedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryCausedBy.Enabled = true;
			this.cboInjuryCausedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryCausedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjuryCausedBy.Name = "cboInjuryCausedBy";
			this.cboInjuryCausedBy.TabIndex = 286;
			this.cboInjuryCausedBy.Text = "cboInjuryCausedBy";
			this.cboInjuryCausedBy.Visible = true;
			this.cboWhereOccured = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboWhereOccured
			// 
			this.cboWhereOccured.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboWhereOccured.Enabled = true;
			this.cboWhereOccured.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboWhereOccured.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboWhereOccured.Name = "cboWhereOccured";
			this.cboWhereOccured.TabIndex = 284;
			this.cboWhereOccured.Text = "cboWhereOccured";
			this.cboWhereOccured.Visible = true;
			this.cboActivity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboActivity
			// 
			this.cboActivity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboActivity.Enabled = true;
			this.cboActivity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboActivity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboActivity.Name = "cboActivity";
			this.cboActivity.TabIndex = 282;
			this.cboActivity.Text = "cboActivity";
			this.cboActivity.Visible = true;
			this.lbLocationAtInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocationAtInjury
			// 
			this.lbLocationAtInjury.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocationAtInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocationAtInjury.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.lbLocationAtInjury.Name = "lbLocationAtInjury";
			this.lbLocationAtInjury.TabIndex = 262;
			this.lbLocationAtInjury.Text = "LOCATION AT TIME OF INJURY";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 261;
			this.Label14.Text = "INJURY CAUSED BY";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 260;
			this.Label13.Text = "WHERE DID INJURY OCCUR";
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 259;
			this.Label12.Text = "ACTIVITY AT TIME OF INJURY";
			this.cboInjurySeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjurySeverity
			// 
			this.cboInjurySeverity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjurySeverity.Enabled = true;
			this.cboInjurySeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjurySeverity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjurySeverity.Name = "cboInjurySeverity";
			this.cboInjurySeverity.TabIndex = 290;
			this.cboInjurySeverity.Text = "cboInjurySeverity";
			this.cboInjurySeverity.Visible = true;
			this.cboBodyPart = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBodyPart
			// 
			this.cboBodyPart.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBodyPart.Enabled = true;
			this.cboBodyPart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboBodyPart.Name = "cboBodyPart";
			this.cboBodyPart.TabIndex = 293;
			this.cboBodyPart.Text = "cboBodyPart";
			this.cboBodyPart.Visible = true;
			this.cboInjuryType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryType
			// 
			this.cboInjuryType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryType.Enabled = true;
			this.cboInjuryType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjuryType.Name = "cboInjuryType";
			this.cboInjuryType.TabIndex = 295;
			this.cboInjuryType.Text = "cboInjuryType";
			this.cboInjuryType.Visible = true;
			this.lstContributingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContributingFactors
			// 
			this.lstContributingFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstContributingFactors.Enabled = true;
			this.lstContributingFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstContributingFactors.Name = "lstContributingFactors";
			this.lstContributingFactors.TabIndex = 297;
			this.lstContributingFactors.Visible = true;
			this.lstContributingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 257;
			this.Label11.Text = "INJURY SEVERITY";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 256;
			this.Label10.Text = "BODY PART INJURED";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 255;
			this.Label16.Text = "TYPE OF INJURY";
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 254;
			this.Label17.Text = "CONTRIBUTING FACTORS";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 271;
			this.Label22.Text = "FIRE SERVICE CASUALTY REPORT";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 270;
			this.Label15.Text = "DETAILED NARRATIVE";
			this.lbEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmployee
			// 
			this.lbEmployee.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmployee.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbEmployee.Name = "lbEmployee";
			this.lbEmployee.TabIndex = 269;
			this.lbEmployee.Text = "lbEmployee";
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 268;
			this.lbIncident.Text = "lbIncident";
			this.lbCasualtyDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCasualtyDate
			// 
			this.lbCasualtyDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCasualtyDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCasualtyDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbCasualtyDate.Name = "lbCasualtyDate";
			this.lbCasualtyDate.TabIndex = 267;
			this.lbCasualtyDate.Text = "lbCasualtyDate";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 266;
			this.Label18.Text = "Employee:";
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 265;
			this.Label19.Text = "Incident:";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 264;
			this.Label20.Text = "Date:";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 263;
			this.Label21.Text = "RECOMMENDATIONS FOR PREVENTION";
			this.frmFSCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFSCasualty
			// 
			this.frmFSCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.frmFSCasualty.Enabled = true;
			this.frmFSCasualty.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFSCasualty.Name = "frmFSCasualty";
			this.frmFSCasualty.TabIndex = 252;
			this.frmFSCasualty.Visible = false;
			this._lbFrameTitle_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.frmNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmNarration
			// 
			this.frmNarration.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmNarration.Enabled = true;
			this.frmNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNarration.Name = "frmNarration";
			this.frmNarration.TabIndex = 191;
			this.frmNarration.Tag = "7";
			this.frmNarration.Visible = false;
			this.cboRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRace
			// 
			this.cboRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRace.Enabled = true;
			this.cboRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboRace.Name = "cboRace";
			this.cboRace.TabIndex = 130;
			this.cboRace.Text = "cboRace";
			this.cboRace.Visible = true;
			this.cboRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRole
			// 
			this.cboRole.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRole.Enabled = true;
			this.cboRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboRole.Name = "cboRole";
			this.cboRole.TabIndex = 129;
			this.cboRole.Text = "cboRole";
			this.cboRole.Visible = true;
			this.txtMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtMI.Name = "txtMI";
			this.txtMI.TabIndex = 128;
			this.txtMI.Text = "txtMI";
			this.txtLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.TabIndex = 127;
			this.txtLastName.Text = "txtLastName";
			this.txtFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.TabIndex = 126;
			this.txtFirstName.Text = "txtFirstName";
			this.cboState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboState
			// 
			this.cboState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboState.Enabled = true;
			this.cboState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboState.Name = "cboState";
			this.cboState.TabIndex = 125;
			this.cboState.Text = "cboState";
			this.cboState.Visible = true;
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 124;
			this.txtCity.Text = "txtCity";
			this.cboSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSuffix
			// 
			this.cboSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSuffix.Enabled = true;
			this.cboSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSuffix.Name = "cboSuffix";
			this.cboSuffix.TabIndex = 123;
			this.cboSuffix.Text = "cboSuffix";
			this.cboSuffix.Visible = true;
			this.cboStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStreetType
			// 
			this.cboStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStreetType.Enabled = true;
			this.cboStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboStreetType.Name = "cboStreetType";
			this.cboStreetType.TabIndex = 122;
			this.cboStreetType.Text = "cboStreetType";
			this.cboStreetType.Visible = true;
			this.cboPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrefix
			// 
			this.cboPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPrefix.Enabled = true;
			this.cboPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPrefix.Name = "cboPrefix";
			this.cboPrefix.TabIndex = 121;
			this.cboPrefix.Text = "cboPrefix";
			this.cboPrefix.Visible = true;
			this.txtStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtStreetName.Name = "txtStreetName";
			this.txtStreetName.TabIndex = 120;
			this.txtStreetName.Text = "txtStreetName";
			this.txtHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtHouseNumber.Name = "txtHouseNumber";
			this.txtHouseNumber.TabIndex = 119;
			this.txtHouseNumber.Text = "txtHouseNumber";
			this.txtWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPlace.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtWorkPlace.Name = "txtWorkPlace";
			this.txtWorkPlace.TabIndex = 118;
			this.txtWorkPlace.Text = "txtWorkPlace";
			this.txtHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHomePhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtHomePhone.Name = "txtHomePhone";
			this.txtHomePhone.TabIndex = 117;
			this.txtHomePhone.Text = "txtHomePhone";
			this.txtWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtWorkPhone.Name = "txtWorkPhone";
			this.txtWorkPhone.TabIndex = 116;
			this.txtWorkPhone.Text = "txtWorkPhone";
			this._optGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtBirthdate.Mask = "##/##/####";
			this.txtBirthdate.Name = "txtBirthdate";
			this.txtBirthdate.PromptChar = '_';
			this.txtBirthdate.TabIndex = 109;
			this._imgMain_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this._lbFrameTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPlace
			// 
			this.lbWorkPlace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbWorkPlace.Name = "lbWorkPlace";
			this.lbWorkPlace.TabIndex = 153;
			this.lbWorkPlace.Text = "WORK PLACE";
			this.lbWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPhone
			// 
			this.lbWorkPhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbWorkPhone.Name = "lbWorkPhone";
			this.lbWorkPhone.TabIndex = 152;
			this.lbWorkPhone.Text = "WORK PHONE";
			this.lbHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHomePhone
			// 
			this.lbHomePhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHomePhone.Name = "lbHomePhone";
			this.lbHomePhone.TabIndex = 151;
			this.lbHomePhone.Text = "HOME PHONE";
			this.lbBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBirthdate
			// 
			this.lbBirthdate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBirthdate.Name = "lbBirthdate";
			this.lbBirthdate.TabIndex = 150;
			this.lbBirthdate.Text = "BIRTHDATE";
			this.lbEthnicity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEthnicity
			// 
			this.lbEthnicity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEthnicity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEthnicity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbEthnicity.Name = "lbEthnicity";
			this.lbEthnicity.TabIndex = 149;
			this.lbEthnicity.Text = "ETHNICITY";
			this.lbRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRace
			// 
			this.lbRace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRace.Name = "lbRace";
			this.lbRace.TabIndex = 148;
			this.lbRace.Text = "RACE";
			this.lbGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGender
			// 
			this.lbGender.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbGender.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbGender.Name = "lbGender";
			this.lbGender.TabIndex = 147;
			this.lbGender.Text = "GENDER";
			this.lbRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRole
			// 
			this.lbRole.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRole.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRole.Name = "lbRole";
			this.lbRole.TabIndex = 146;
			this.lbRole.Text = "ROLE";
			this.lbLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastName
			// 
			this.lbLastName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbLastName.Name = "lbLastName";
			this.lbLastName.TabIndex = 145;
			this.lbLastName.Text = "LAST NAME";
			this.lbFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFirstName
			// 
			this.lbFirstName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFirstName.Name = "lbFirstName";
			this.lbFirstName.TabIndex = 144;
			this.lbFirstName.Text = "FIRST NAME";
			this.lbState = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbState
			// 
			this.lbState.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbState.Name = "lbState";
			this.lbState.TabIndex = 143;
			this.lbState.Text = "STATE";
			this.lbCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCity
			// 
			this.lbCity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbCity.Name = "lbCity";
			this.lbCity.TabIndex = 141;
			this.lbCity.Text = "CITY";
			this.lbSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSuffix
			// 
			this.lbSuffix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSuffix.Name = "lbSuffix";
			this.lbSuffix.TabIndex = 137;
			this.lbSuffix.Text = "SUFFIX";
			this.lbStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetType
			// 
			this.lbStreetType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lbStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbStreetType.Name = "lbStreetType";
			this.lbStreetType.TabIndex = 136;
			this.lbStreetType.Text = "TYPE";
			this.lbStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetName
			// 
			this.lbStreetName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbStreetName.Name = "lbStreetName";
			this.lbStreetName.TabIndex = 135;
			this.lbStreetName.Text = "STREET NAME";
			this.lbPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPrefix
			// 
			this.lbPrefix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbPrefix.Name = "lbPrefix";
			this.lbPrefix.TabIndex = 134;
			this.lbPrefix.Text = "PREFIX";
			this.lbHouseNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHouseNum
			// 
			this.lbHouseNum.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHouseNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHouseNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHouseNum.Name = "lbHouseNum";
			this.lbHouseNum.TabIndex = 133;
			this.lbHouseNum.Text = "HOUSE #";
			this.lbMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMI
			// 
			this.lbMI.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbMI.Name = "lbMI";
			this.lbMI.TabIndex = 132;
			this.lbMI.Text = "M.I.";
			this.frmName = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmName
			// 
			this.frmName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmName.Enabled = true;
			this.frmName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmName.Name = "frmName";
			this.frmName.TabIndex = 108;
			this.frmName.Tag = "3";
			this.frmName.Visible = true;
			this.cboSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSeverity
			// 
			this.cboSeverity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSeverity.Enabled = true;
			this.cboSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSeverity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSeverity.Name = "cboSeverity";
			this.cboSeverity.TabIndex = 243;
			this.cboSeverity.Visible = true;
			this.cboInjuryCause = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryCause
			// 
			this.cboInjuryCause.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryCause.Enabled = true;
			this.cboInjuryCause.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryCause.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboInjuryCause.Name = "cboInjuryCause";
			this.cboInjuryCause.TabIndex = 242;
			this.cboInjuryCause.Visible = true;
			this.cboCCLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCCLocation
			// 
			this.cboCCLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCCLocation.Enabled = true;
			this.cboCCLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCCLocation.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCCLocation.Name = "cboCCLocation";
			this.cboCCLocation.TabIndex = 241;
			this.cboCCLocation.Visible = true;
			this.txtFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFloor.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtFloor.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFloor.Name = "txtFloor";
			this.txtFloor.TabIndex = 240;
			this.lbSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSeverity
			// 
			this.lbSeverity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSeverity.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbSeverity.Name = "lbSeverity";
			this.lbSeverity.TabIndex = 247;
			this.lbSeverity.Text = "INJURY SEVERITY";
			this.lbInjuryCause = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInjuryCause
			// 
			this.lbInjuryCause.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInjuryCause.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbInjuryCause.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbInjuryCause.Name = "lbInjuryCause";
			this.lbInjuryCause.TabIndex = 246;
			this.lbInjuryCause.Text = "INJURY CAUSED BY";
			this.lbFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFloor
			// 
			this.lbFloor.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFloor.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbFloor.Name = "lbFloor";
			this.lbFloor.TabIndex = 245;
			this.lbFloor.Text = "FLOOR";
			this.lbCCLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCCLocation
			// 
			this.lbCCLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCCLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCCLocation.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbCCLocation.Name = "lbCCLocation";
			this.lbCCLocation.TabIndex = 244;
			this.lbCCLocation.Text = "LOCATION AT INJURY";
			this.cboEMSPatient = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEMSPatient
			// 
			this.cboEMSPatient.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEMSPatient.Enabled = false;
			this.cboEMSPatient.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboEMSPatient.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEMSPatient.Name = "cboEMSPatient";
			this.cboEMSPatient.TabIndex = 237;
			this.cboEMSPatient.Visible = true;
			this.lbEMSPatient = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEMSPatient
			// 
			this.lbEMSPatient.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEMSPatient.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEMSPatient.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbEMSPatient.Name = "lbEMSPatient";
			this.lbEMSPatient.TabIndex = 238;
			this.lbEMSPatient.Text = "SELECT EMS PATIENT";
			this.lstContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContribFactors
			// 
			this.lstContribFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstContribFactors.Enabled = true;
			this.lstContribFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstContribFactors.Name = "lstContribFactors";
			this.lstContribFactors.TabIndex = 106;
			this.lstContribFactors.Visible = true;
			this.lstContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstHumanContribFactors
			// 
			this.lstHumanContribFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstHumanContribFactors.Enabled = true;
			this.lstHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstHumanContribFactors.Name = "lstHumanContribFactors";
			this.lstHumanContribFactors.TabIndex = 104;
			this.lstHumanContribFactors.Visible = true;
			this.lstHumanContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lbContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFactors
			// 
			this.lbContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbContribFactors.Name = "lbContribFactors";
			this.lbContribFactors.TabIndex = 105;
			this.lbContribFactors.Text = "CONTRIBUTING FACTORS";
			this.lbHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHumanContribFactors
			// 
			this.lbHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHumanContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbHumanContribFactors.Name = "lbHumanContribFactors";
			this.lbHumanContribFactors.TabIndex = 103;
			this.lbHumanContribFactors.Text = "HUMAN CONTRIBUTING FACTORS";
			this._imgMain_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.lbCivCasualtyTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCivCasualtyTitle
			// 
			this.lbCivCasualtyTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCivCasualtyTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCivCasualtyTitle.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbCivCasualtyTitle.Name = "lbCivCasualtyTitle";
			this.lbCivCasualtyTitle.TabIndex = 101;
			this.lbCivCasualtyTitle.Text = "Civilian Casualty Report";
			this.frmCivilianCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmCivilianCasualty
			// 
			this.frmCivilianCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(143, 154, 169);
			this.frmCivilianCasualty.Enabled = true;
			this.frmCivilianCasualty.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.frmCivilianCasualty.Name = "frmCivilianCasualty";
			this.frmCivilianCasualty.TabIndex = 98;
			this.frmCivilianCasualty.Tag = "6";
			this.frmCivilianCasualty.Visible = false;
			this.txtAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAllInfo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtAllInfo1.Name = "txtAllInfo1";
			this.txtAllInfo1.TabIndex = 97;
			this.txtAllInfo1.Text = "txtAllInfo1";
			this.cboAllInfo3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo3
			// 
			this.cboAllInfo3.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo3.Enabled = true;
			this.cboAllInfo3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo3.Name = "cboAllInfo3";
			this.cboAllInfo3.TabIndex = 95;
			this.cboAllInfo3.Text = "cboAllInfo3";
			this.cboAllInfo3.Visible = true;
			this.cboAllInfo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo2
			// 
			this.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo2.Enabled = true;
			this.cboAllInfo2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo2.Name = "cboAllInfo2";
			this.cboAllInfo2.TabIndex = 93;
			this.cboAllInfo2.Text = "cboAllInfo2";
			this.cboAllInfo2.Visible = true;
			this.cboAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo1
			// 
			this.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo1.Enabled = true;
			this.cboAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo1.Name = "cboAllInfo1";
			this.cboAllInfo1.TabIndex = 92;
			this.cboAllInfo1.Text = "cboAllInfo1";
			this.cboAllInfo1.Visible = true;
			this.lbAllInfo4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo4
			// 
			this.lbAllInfo4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo4.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo4.Name = "lbAllInfo4";
			this.lbAllInfo4.TabIndex = 107;
			this.lbAllInfo4.Text = "lbAllInfo4";
			this.lbAllInfo3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo3
			// 
			this.lbAllInfo3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo3.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo3.Name = "lbAllInfo3";
			this.lbAllInfo3.TabIndex = 96;
			this.lbAllInfo3.Text = "lbAllInfo3";
			this.lbAllInfo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo2
			// 
			this.lbAllInfo2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo2.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo2.Name = "lbAllInfo2";
			this.lbAllInfo2.TabIndex = 94;
			this.lbAllInfo2.Text = "lbAllInfo2";
			this.lbAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo1
			// 
			this.lbAllInfo1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo1.Name = "lbAllInfo1";
			this.lbAllInfo1.TabIndex = 91;
			this.lbAllInfo1.Text = "lbAllInfo1";
			this._imgMain_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.lbAllInfoTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfoTitle
			// 
			this.lbAllInfoTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfoTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfoTitle.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfoTitle.Name = "lbAllInfoTitle";
			this.lbAllInfoTitle.TabIndex = 90;
			this.lbAllInfoTitle.Text = "FALSE ALARM REPORT";
			this.frmAllInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmAllInfo
			// 
			this.frmAllInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(153, 166, 187);
			this.frmAllInfo.Enabled = true;
			this.frmAllInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmAllInfo.Name = "frmAllInfo";
			this.frmAllInfo.TabIndex = 102;
			this.frmAllInfo.Tag = "5";
			this.frmAllInfo.Visible = false;
			this.txtNumberSafePlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberSafePlace.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberSafePlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberSafePlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.txtNumberSafePlace.Name = "txtNumberSafePlace";
			this.txtNumberSafePlace.TabIndex = 140;
			this.txtNumberSafePlace.Text = "txtStandbyHours";
			this.txtNumberSafePlace.Visible = false;
			this.cboServiceType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboServiceType
			// 
			this.cboServiceType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboServiceType.Enabled = true;
			this.cboServiceType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboServiceType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.cboServiceType.Name = "cboServiceType";
			this.cboServiceType.TabIndex = 138;
			this.cboServiceType.Text = "cboServiceType";
			this.cboServiceType.Visible = true;
			this.txtStandbyHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStandbyHours.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStandbyHours.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtStandbyHours.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.txtStandbyHours.Name = "txtStandbyHours";
			this.txtStandbyHours.TabIndex = 139;
			this.txtStandbyHours.Text = "txtStandbyHours";
			this.txtStandbyHours.Visible = false;
			this.lbSafePlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSafePlace
			// 
			this.lbSafePlace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSafePlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSafePlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbSafePlace.Name = "lbSafePlace";
			this.lbSafePlace.TabIndex = 230;
			this.lbSafePlace.Text = "NUMBER OF SAFEPLACE JUVENILES";
			this.lbSafePlace.Visible = false;
			this.lbServiceProvided = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServiceProvided
			// 
			this.lbServiceProvided.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbServiceProvided.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbServiceProvided.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbServiceProvided.Name = "lbServiceProvided";
			this.lbServiceProvided.TabIndex = 157;
			this.lbServiceProvided.Text = "SERVICE PROVIDED";
			this.lbStandbyHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStandbyHours
			// 
			this.lbStandbyHours.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStandbyHours.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStandbyHours.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbStandbyHours.Name = "lbStandbyHours";
			this.lbStandbyHours.TabIndex = 156;
			this.lbStandbyHours.Text = "STANDBY HOURS";
			this.lbStandbyHours.Visible = false;
			this.lbServiceTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServiceTitle
			// 
			this.lbServiceTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbServiceTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbServiceTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbServiceTitle.Name = "lbServiceTitle";
			this.lbServiceTitle.TabIndex = 42;
			this.lbServiceTitle.Text = "Frame Title";
			this._imgMain_13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.frmService = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmService
			// 
			this.frmService.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(172, 168, 119);
			this.frmService.Enabled = true;
			this.frmService.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmService.Name = "frmService";
			this.frmService.TabIndex = 142;
			this.frmService.Tag = "13";
			this.frmService.Visible = false;
			this.lstMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMessage
			// 
			this.lstMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lstMessage.Enabled = true;
			this.lstMessage.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lstMessage.Name = "lstMessage";
			this.lstMessage.TabIndex = 272;
			this.lstMessage.Visible = true;
			this.lstMessage.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 209;
			this.Label7.Text = "ASSIGNMENT:";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 208;
			this.Label6.Text = "REPORTS FOR THIS INCIDENT:";
			this.lbRSCurrReportType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSCurrReportType
			// 
			this.lbRSCurrReportType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSCurrReportType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSCurrReportType.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSCurrReportType.Name = "lbRSCurrReportType";
			this.lbRSCurrReportType.TabIndex = 207;
			this.lbRSCurrReportType.Text = "Unit Report";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 206;
			this.Label5.Text = "CURRENT REPORT:";
			this.lbRSShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSShift
			// 
			this.lbRSShift.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lbRSShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSShift.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSShift.Name = "lbRSShift";
			this.lbRSShift.TabIndex = 89;
			this.lbRSShift.Text = "D Shift";
			this.lbRSUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSUnit
			// 
			this.lbRSUnit.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lbRSUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSUnit.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSUnit.Name = "lbRSUnit";
			this.lbRSUnit.TabIndex = 88;
			this.lbRSUnit.Text = "E10";
			this.lbRSPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSPosition
			// 
			this.lbRSPosition.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lbRSPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSPosition.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSPosition.Name = "lbRSPosition";
			this.lbRSPosition.TabIndex = 87;
			this.lbRSPosition.Text = "Officer";
			this.lbRSEmployeeID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSEmployeeID
			// 
			this.lbRSEmployeeID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSEmployeeID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSEmployeeID.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSEmployeeID.Name = "lbRSEmployeeID";
			this.lbRSEmployeeID.TabIndex = 86;
			this.lbRSEmployeeID.Text = "02341";
			this.lbRSReportedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSReportedBy
			// 
			this.lbRSReportedBy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSReportedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSReportedBy.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSReportedBy.Name = "lbRSReportedBy";
			this.lbRSReportedBy.TabIndex = 85;
			this.lbRSReportedBy.Text = "Hilderbrand, Robert";
			this.lbReportByTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReportByTitle
			// 
			this.lbReportByTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReportByTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReportByTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbReportByTitle.Name = "lbReportByTitle";
			this.lbReportByTitle.TabIndex = 84;
			this.lbReportByTitle.Text = "REPORT BY:";
			this.lbRSIncidentNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSIncidentNumber
			// 
			this.lbRSIncidentNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSIncidentNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSIncidentNumber.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSIncidentNumber.Name = "lbRSIncidentNumber";
			this.lbRSIncidentNumber.TabIndex = 83;
			this.lbRSIncidentNumber.Text = "001230056";
			this.lbIncidentNumberTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNumberTitle
			// 
			this.lbIncidentNumberTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNumberTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNumberTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbIncidentNumberTitle.Name = "lbIncidentNumberTitle";
			this.lbIncidentNumberTitle.TabIndex = 81;
			this.lbIncidentNumberTitle.Text = "INCIDENT #";
			this._imgMain_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.lbRSFrameTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSFrameTitle
			// 
			this.lbRSFrameTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSFrameTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSFrameTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbRSFrameTitle.Name = "lbRSFrameTitle";
			this.lbRSFrameTitle.TabIndex = 41;
			this.lbRSFrameTitle.Text = "INCIDENT REPORT STATUS";
			this.frmReportStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmReportStatus
			// 
			this.frmReportStatus.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmReportStatus.Enabled = true;
			this.frmReportStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmReportStatus.Name = "frmReportStatus";
			this.frmReportStatus.TabIndex = 234;
			this.frmReportStatus.Tag = "1";
			this.frmReportStatus.Visible = false;

			this.txtNumberCivCasulties = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
            this.txtNumberCivCasulties.Enabled = false;
			this.txtNumberCivCasulties.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberCivCasulties.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberCivCasulties.Name = "txtNumberCivCasulties";
			this.txtNumberCivCasulties.TabIndex = 51;
			//this.txtNumberCivCasulties.Text = "1";

			this.txtNumberPatients = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberPatients.Enabled = false;
			this.txtNumberPatients.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberPatients.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberPatients.Name = "txtNumberPatients";
			this.txtNumberPatients.TabIndex = 55;
			this._cboUnit_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._optServiceReport_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optServiceReport_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optServiceReport_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._cboUnit_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.Frame2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// Frame2
			// 
			this.Frame2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame2.Name = "Frame2";
			this.Frame2.TabIndex = 183;
			this.Frame2.Visible = true;
			this._cboUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboEMSUnit_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._lbPatient_12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbPatient_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbSirenTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSirenTitle
			// 
			this.lbSirenTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.lbSirenTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSirenTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.lbSirenTitle.Name = "lbSirenTitle";
			this.lbSirenTitle.TabIndex = 325;
			this.lbSirenTitle.Text = "Siren Report";
			this.lbSirenTitle.Visible = false;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 198;
			this.Label2.Text = "Select Situation(s) Found";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 197;
			this.Label1.Text = "Unit Responsible for Report";

            // 
            // lbEMSReportingUnit
            // 
            this.lbEMSReportingUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbEMSReportingUnit.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.lbEMSReportingUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEMSReportingUnit.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.lbEMSReportingUnit.Name = "lbEMSReportingUnit";
			this.lbEMSReportingUnit.TabIndex = 229;
			this.lbEMSReportingUnit.Text = "Multiple Patient Assignments";
			this.lbEMSReportingUnit.Visible = false;
			this._lbFrameTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmSitFound = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmSitFound
			// 
			this.frmSitFound.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmSitFound.Enabled = true;
			this.frmSitFound.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			this.frmSitFound.Name = "frmSitFound";
			this.frmSitFound.TabIndex = 82;
			this.frmSitFound.Tag = "2";
			this.frmSitFound.Visible = false;
			this._cboPosition_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPersonnel_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboPosition_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 217;
			this.Label8.Text = "NON-TFD OPERATIONS PERSONNEL";

            // 
            // Label4
            // 
            this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 204;
			this.Label4.Text = "POSITION";

            //
            // lbInjury
            //
            this.lbInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbInjury.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
            this.lbInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
                    Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
            this.lbInjury.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
            this.lbInjury.Name = "lbInjury";
            this.lbInjury.TabIndex = 204;
            this.lbInjury.Text = "INJURY";
            // 
            // Label3
            // 
            this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 203;
			this.Label3.Text = "PERSONNEL";
			this._cboAmendReason_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._cboAmendReason_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			this._txtAmendTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this._txtAmendTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.lbURDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbURDate
			// 
			this.lbURDate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbURDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 8.4f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbURDate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbURDate.Name = "lbURDate";
			this.lbURDate.TabIndex = 216;
			this.lbURDate.Text = "lbURDate";
			this.lbURDate.Visible = false;
			this._lbActualTime_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._lbActualTime_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.Line1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Line1
			// 
			this.Line1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.Line1.Enabled = false;
			this.Line1.Name = "Line1";
			this.Line1.Visible = true;
			this.lbAmendedReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAmendedReason
			// 
			this.lbAmendedReason.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAmendedReason.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAmendedReason.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAmendedReason.Name = "lbAmendedReason";
			this.lbAmendedReason.TabIndex = 168;
			this.lbAmendedReason.Text = "REASON";
			this.lbAmendedTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAmendedTitle
			// 
			this.lbAmendedTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAmendedTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAmendedTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAmendedTitle.Name = "lbAmendedTitle";
			this.lbAmendedTitle.TabIndex = 167;
			this.lbAmendedTitle.Text = "AMENDED";
			this.lbTimeTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTimeTitle
			// 
			this.lbTimeTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTimeTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTimeTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTimeTitle.Name = "lbTimeTitle";
			this.lbTimeTitle.TabIndex = 166;
			this.lbTimeTitle.Text = "TIME";
			this.lbEventTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEventTitle
			// 
			this.lbEventTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEventTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEventTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbEventTitle.Name = "lbEventTitle";
			this.lbEventTitle.TabIndex = 165;
			this.lbEventTitle.Text = "EVENT";
			this.lbAvailable = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAvailable
			// 
			this.lbAvailable.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAvailable.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAvailable.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbAvailable.Name = "lbAvailable";
			this.lbAvailable.TabIndex = 164;
			this.lbAvailable.Text = "AVAILABLE";
			this.lbTransportComplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTransportComplete
			// 
			this.lbTransportComplete.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTransportComplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTransportComplete.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTransportComplete.Name = "lbTransportComplete";
			this.lbTransportComplete.TabIndex = 163;
			this.lbTransportComplete.Text = "TRANSPORT COMPLETE";
			this.lbTransport = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTransport
			// 
			this.lbTransport.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTransport.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTransport.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbTransport.Name = "lbTransport";
			this.lbTransport.TabIndex = 162;
			this.lbTransport.Text = "TRANSPORT";
			this.lbOnscene = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOnscene
			// 
			this.lbOnscene.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOnscene.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOnscene.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbOnscene.Name = "lbOnscene";
			this.lbOnscene.TabIndex = 161;
			this.lbOnscene.Text = "ONSCENE";
			this.lbEnroute = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEnroute
			// 
			this.lbEnroute.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEnroute.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEnroute.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbEnroute.Name = "lbEnroute";
			this.lbEnroute.TabIndex = 160;
			this.lbEnroute.Text = "ENROUTE";
			this.lbDispatch = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbDispatch
			// 
			this.lbDispatch.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbDispatch.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbDispatch.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbDispatch.Name = "lbDispatch";
			this.lbDispatch.TabIndex = 159;
			this.lbDispatch.Tag = "3";
			this.lbDispatch.Text = "DISPATCH";
			this.lstReasonDelay = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstReasonDelay
			// 
			this.lstReasonDelay.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstReasonDelay.Enabled = true;
			this.lstReasonDelay.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lstReasonDelay.Name = "lstReasonDelay";
			this.lstReasonDelay.TabIndex = 36;
			this.lstReasonDelay.Visible = true;
			this.lstReasonDelay.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstActionsTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstActionsTaken
			// 
			this.lstActionsTaken.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstActionsTaken.Enabled = true;
			this.lstActionsTaken.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lstActionsTaken.Name = "lstActionsTaken";
			this.lstActionsTaken.TabIndex = 38;
			this.lstActionsTaken.Visible = true;
			this.lstActionsTaken.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lbUnitComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnitComment
			// 
			this.lbUnitComment.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnitComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnitComment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbUnitComment.Name = "lbUnitComment";
			this.lbUnitComment.TabIndex = 202;
			this.lbUnitComment.Text = "UNIT COMMENT";
			this.lbReasonsDelayTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReasonsDelayTitle
			// 
			this.lbReasonsDelayTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReasonsDelayTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReasonsDelayTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbReasonsDelayTitle.Name = "lbReasonsDelayTitle";
			this.lbReasonsDelayTitle.TabIndex = 201;
			this.lbReasonsDelayTitle.Text = "REASONS FOR DELAY";
			this.lbActionsTakenTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbActionsTakenTitle
			// 
			this.lbActionsTakenTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbActionsTakenTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbActionsTakenTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			this.lbActionsTakenTitle.Name = "lbActionsTakenTitle";
			this.lbActionsTakenTitle.TabIndex = 200;
			this.lbActionsTakenTitle.Text = "UNIT ACTIONS - FIRE INCIDENTS";
			this.lbActionTaken = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbActionTaken
			// 
			this.lbActionTaken.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbActionTaken.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbActionTaken.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.lbActionTaken.Name = "lbActionTaken";
			this.lbActionTaken.TabIndex = 43;
			this.lbActionTaken.Text = "ACTIONS TAKEN";
			this._lbFrameTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmUnitReport = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmUnitReport
			// 
			this.frmUnitReport.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			this.frmUnitReport.Enabled = true;
			this.frmUnitReport.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.frmUnitReport.Name = "frmUnitReport";
			this.frmUnitReport.TabIndex = 39;
			this.frmUnitReport.Tag = "0";
			this.frmUnitReport.Visible = false;
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 249;
			this.Label9.Text = "Loading First Report........";
			this.lbIncidentNoTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNoTitle
			// 
			this.lbIncidentNoTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNoTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNoTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbIncidentNoTitle.Name = "lbIncidentNoTitle";
			this.lbIncidentNoTitle.TabIndex = 180;
			this.lbIncidentNoTitle.Text = "Incident #:";
			this.lbUnitTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnitTitle
			// 
			this.lbUnitTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnitTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnitTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbUnitTitle.Name = "lbUnitTitle";
			this.lbUnitTitle.TabIndex = 179;
			this.lbUnitTitle.Text = "Unit:";
			this.lbUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbUnit.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.TabIndex = 178;
			this.lbUnit.Text = "E4";
			this.lbIncidentNo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNo
			// 
			this.lbIncidentNo.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNo.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncidentNo.Name = "lbIncidentNo";
			this.lbIncidentNo.TabIndex = 177;
			this.lbIncidentNo.Text = "T002410042";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 176;
			this.lbLocation.Text = "1200 Martin Luther King Jr Wy, TAC";
			this.lbLocationTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocationTitle
			// 
			this.lbLocationTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocationTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocationTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbLocationTitle.Name = "lbLocationTitle";
			this.lbLocationTitle.TabIndex = 175;
			this.lbLocationTitle.Text = "Location:";
			this.cmdRemovePPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemovePPE
			// 
			this.cmdRemovePPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemovePPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemovePPE.Name = "cmdRemovePPE";
			this.cmdRemovePPE.TabIndex = 294;
			this.cmdRemovePPE.Text = "Remove Selection from List";
			this.cmdAddPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddPPE
			// 
			this.cmdAddPPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddPPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddPPE.Name = "cmdAddPPE";
			this.cmdAddPPE.TabIndex = 292;
			this.cmdAddPPE.Text = "Add Selections to List";
			this._NavButton_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.chkFPEProblem = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkFPEProblem.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.chkFPEProblem.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkFPEProblem.Enabled = true;
			this.chkFPEProblem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkFPEProblem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.chkFPEProblem.Name = "chkFPEProblem";
			this.chkFPEProblem.TabIndex = 280;
			this.chkFPEProblem.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS?";
			this.chkFPEProblem.Visible = true;
			this.chkEMR = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkEMR.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.chkEMR.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkEMR.Enabled = true;
			this.chkEMR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkEMR.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.chkEMR.Name = "chkEMR";
			this.chkEMR.TabIndex = 236;
			this.chkEMR.Text = "EMS PATIENT REPORT COMPLETED?";
			this.chkEMR.Visible = true;
			this.chkIC = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkIC.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.chkIC.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkIC.Enabled = true;
			this.chkIC.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkIC.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.chkIC.Name = "chkIC";
			this.chkIC.TabIndex = 273;
			this.chkIC.Text = "WILL ASSUME INCIDENT REPORTING RESPONSIBLITY";
			this.chkIC.Visible = false;
			this.cmdAbandon = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAbandon
			// 
			this.cmdAbandon.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAbandon.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAbandon.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAbandon.Name = "cmdAbandon";
			this.cmdAbandon.TabIndex = 233;
			this.cmdAbandon.Text = "Exit WITHOUT Saving Report";
			this.cmdSaveIncomplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveIncomplete
			// 
			this.cmdSaveIncomplete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveIncomplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSaveIncomplete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveIncomplete.Name = "cmdSaveIncomplete";
			this.cmdSaveIncomplete.TabIndex = 232;
			this.cmdSaveIncomplete.Text = "Save Report as Incomplete";
			this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSave
			// 
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 231;
			this.cmdSave.Text = "Save Report as Complete";
			this.chkAddressCorrection = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAddressCorrection.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAddressCorrection.Enabled = true;
			this.chkAddressCorrection.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAddressCorrection.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.chkAddressCorrection.Name = "chkAddressCorrection";
			this.chkAddressCorrection.TabIndex = 317;
			this.chkAddressCorrection.Text = "   Incident Address          Correction Needed";
			this.chkAddressCorrection.Visible = false;
			this.chkCivilianCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkCivilianCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkCivilianCasualty.Enabled = false;
			this.chkCivilianCasualty.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkCivilianCasualty.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.chkCivilianCasualty.Name = "chkCivilianCasualty";
			this.chkCivilianCasualty.TabIndex = 50;
			this.chkCivilianCasualty.Text = "CIVILIAN CASUALTY COUNT";
			this.chkCivilianCasualty.Visible = true;
			this._chkSitFound_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkSitFound_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.FDCaresBtn = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.FDCaresBtn.Name = "FDCaresBtn";
			this.FDCaresBtn.TabIndex = 339;
			this._cmdClearPerson_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._chkCasualty_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._cmdClearPerson_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdClearPerson_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdAddStaff = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddStaff
			// 
			this.cmdAddStaff.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddStaff.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.6f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddStaff.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddStaff.Name = "cmdAddStaff";
			this.cmdAddStaff.TabIndex = 9;
			this.cmdAddStaff.Text = "Additional Staff...";
			this._chkCasualty_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._chkCasualty_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.rtxUnitNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxUnitNarration.Name = "rtxUnitNarration";
			this.rtxUnitNarration.TabIndex = 33;
			this.Text = "TFD Incident Reporting System - Report Entry Wizard";
			this.CurrIncident = 0;
			this.CurrReportLogID = 0;
			this.DontRespond = 0;
			this.CurrReportID = 0;
			cboPersonnel = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(8);
			cboPersonnel[6] = _cboPersonnel_6;
			cboPersonnel[5] = _cboPersonnel_5;
			cboPersonnel[7] = _cboPersonnel_7;
			cboPersonnel[4] = _cboPersonnel_4;
			cboPersonnel[3] = _cboPersonnel_3;
			cboPersonnel[2] = _cboPersonnel_2;
			cboPersonnel[1] = _cboPersonnel_1;
			cboPersonnel[0] = _cboPersonnel_0;
			cboPersonnel[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[6].Enabled = true;
			cboPersonnel[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[6].Name = "_cboPersonnel_6";
			cboPersonnel[6].TabIndex = 19;
			cboPersonnel[6].Visible = false;
			cboPersonnel[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[5].Enabled = true;
			cboPersonnel[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[5].Name = "_cboPersonnel_5";
			cboPersonnel[5].TabIndex = 16;
			cboPersonnel[5].Visible = false;
			cboPersonnel[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[7].Enabled = true;
			cboPersonnel[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[7].Name = "_cboPersonnel_7";
			cboPersonnel[7].TabIndex = 32;
			cboPersonnel[7].Visible = true;
			cboPersonnel[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[4].Enabled = true;
			cboPersonnel[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[4].Name = "_cboPersonnel_4";
			cboPersonnel[4].TabIndex = 13;
			cboPersonnel[4].Visible = false;
			cboPersonnel[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[3].Enabled = true;
			cboPersonnel[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[3].Name = "_cboPersonnel_3";
			cboPersonnel[3].TabIndex = 10;
			cboPersonnel[3].Visible = false;
			cboPersonnel[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[2].Enabled = true;
			cboPersonnel[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[2].Name = "_cboPersonnel_2";
			cboPersonnel[2].TabIndex = 6;
			cboPersonnel[2].Visible = true;
			cboPersonnel[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[1].Enabled = true;
			cboPersonnel[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[1].Name = "_cboPersonnel_1";
			cboPersonnel[1].TabIndex = 3;
			cboPersonnel[1].Visible = true;
			cboPersonnel[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPersonnel[0].Enabled = true;
			cboPersonnel[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPersonnel[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPersonnel[0].Name = "_cboPersonnel_0";
			cboPersonnel[0].TabIndex = 0;
			cboPersonnel[0].Visible = true;
			cboPosition = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(7);
			cboPosition[6] = _cboPosition_6;
			cboPosition[5] = _cboPosition_5;
			cboPosition[4] = _cboPosition_4;
			cboPosition[3] = _cboPosition_3;
			cboPosition[0] = _cboPosition_0;
			cboPosition[1] = _cboPosition_1;
			cboPosition[2] = _cboPosition_2;
			cboPosition[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[6].Enabled = true;
			cboPosition[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[6].Name = "_cboPosition_6";
			cboPosition[6].TabIndex = 20;
			cboPosition[6].Visible = false;
			cboPosition[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[5].Enabled = true;
			cboPosition[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[5].Name = "_cboPosition_5";
			cboPosition[5].TabIndex = 17;
			cboPosition[5].Visible = false;
			cboPosition[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[4].Enabled = true;
			cboPosition[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[4].Name = "_cboPosition_4";
			cboPosition[4].TabIndex = 14;
			cboPosition[4].Visible = false;
			cboPosition[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[3].Enabled = true;
			cboPosition[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[3].Name = "_cboPosition_3";
			cboPosition[3].TabIndex = 11;
			cboPosition[3].Visible = false;
			cboPosition[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[0].Enabled = true;
			cboPosition[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[0].Name = "_cboPosition_0";
			cboPosition[0].TabIndex = 1;
			cboPosition[0].Visible = true;
			cboPosition[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[1].Enabled = true;
			cboPosition[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[1].Name = "_cboPosition_1";
			cboPosition[1].TabIndex = 4;
			cboPosition[1].Visible = true;
			cboPosition[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboPosition[2].Enabled = true;
			cboPosition[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboPosition[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			cboPosition[2].Name = "_cboPosition_2";
			cboPosition[2].TabIndex = 7;
			cboPosition[2].Visible = true;
			chkCasualty = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkCasualty[6] = _chkCasualty_6;
			chkCasualty[5] = _chkCasualty_5;
			chkCasualty[7] = _chkCasualty_7;
			chkCasualty[4] = _chkCasualty_4;
			chkCasualty[3] = _chkCasualty_3;
			chkCasualty[0] = _chkCasualty_0;
			chkCasualty[1] = _chkCasualty_1;
			chkCasualty[2] = _chkCasualty_2;
			chkCasualty[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[6].Enabled = true;
			chkCasualty[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[6].Name = "_chkCasualty_6";
			chkCasualty[6].TabIndex = 21;
			chkCasualty[6].Text = "";
			chkCasualty[6].Visible = false;
			chkCasualty[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[5].Enabled = true;
			chkCasualty[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[5].Name = "_chkCasualty_5";
			chkCasualty[5].TabIndex = 18;
			chkCasualty[5].Text = "";
			chkCasualty[5].Visible = false;
			chkCasualty[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[7].Enabled = true;
			chkCasualty[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[7].Name = "_chkCasualty_7";
			chkCasualty[7].TabIndex = 34;
			chkCasualty[7].Text = "";
			chkCasualty[7].Visible = false;
			chkCasualty[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[4].Enabled = true;
			chkCasualty[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[4].Name = "_chkCasualty_4";
			chkCasualty[4].TabIndex = 15;
			chkCasualty[4].Text = "";
			chkCasualty[4].Visible = false;
			chkCasualty[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[3].Enabled = true;
			chkCasualty[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[3].Name = "_chkCasualty_3";
			chkCasualty[3].TabIndex = 12;
			chkCasualty[3].Text = "";
			chkCasualty[3].Visible = false;
			chkCasualty[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[0].Enabled = true;
			chkCasualty[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[0].Name = "_chkCasualty_0";
			chkCasualty[0].TabIndex = 2;
			chkCasualty[0].Text = "";
			chkCasualty[0].Visible = true;
			chkCasualty[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[1].Enabled = true;
			chkCasualty[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[1].Name = "_chkCasualty_1";
			chkCasualty[1].TabIndex = 5;
			chkCasualty[1].Text = "";
			chkCasualty[1].Visible = true;
			chkCasualty[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(165, 186, 199);
			chkCasualty[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkCasualty[2].Enabled = true;
			chkCasualty[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			chkCasualty[2].Name = "_chkCasualty_2";
			chkCasualty[2].TabIndex = 8;
			chkCasualty[2].Text = "";
			chkCasualty[2].Visible = true;
			txtAmendTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>>(6);
			txtAmendTime[2] = _txtAmendTime_2;
			txtAmendTime[3] = _txtAmendTime_3;
			txtAmendTime[4] = _txtAmendTime_4;
			txtAmendTime[5] = _txtAmendTime_5;
			txtAmendTime[1] = _txtAmendTime_1;
			txtAmendTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[2].Mask = "##:##";
			txtAmendTime[2].Name = "_txtAmendTime_2";
			txtAmendTime[2].PromptChar = '_';
			txtAmendTime[2].TabIndex = 24;
			txtAmendTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[3].Mask = "##:##";
			txtAmendTime[3].Name = "_txtAmendTime_3";
			txtAmendTime[3].PromptChar = '_';
			txtAmendTime[3].TabIndex = 26;
			txtAmendTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[4].Mask = "##:##";
			txtAmendTime[4].Name = "_txtAmendTime_4";
			txtAmendTime[4].PromptChar = '_';
			txtAmendTime[4].TabIndex = 28;
			txtAmendTime[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[5].Mask = "##:##";
			txtAmendTime[5].Name = "_txtAmendTime_5";
			txtAmendTime[5].PromptChar = '_';
			txtAmendTime[5].TabIndex = 30;
			txtAmendTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			txtAmendTime[1].Mask = "##:##";
			txtAmendTime[1].Name = "_txtAmendTime_1";
			txtAmendTime[1].PromptChar = '_';
			txtAmendTime[1].TabIndex = 22;
			cboAmendReason = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(6);
			cboAmendReason[1] = _cboAmendReason_1;
			cboAmendReason[2] = _cboAmendReason_2;
			cboAmendReason[3] = _cboAmendReason_3;
			cboAmendReason[4] = _cboAmendReason_4;
			cboAmendReason[5] = _cboAmendReason_5;
			cboAmendReason[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[1].Enabled = true;
			cboAmendReason[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[1].Name = "_cboAmendReason_1";
			cboAmendReason[1].TabIndex = 23;
			cboAmendReason[1].Visible = true;
			cboAmendReason[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[2].Enabled = true;
			cboAmendReason[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[2].Name = "_cboAmendReason_2";
			cboAmendReason[2].TabIndex = 25;
			cboAmendReason[2].Visible = true;
			cboAmendReason[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[3].Enabled = true;
			cboAmendReason[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[3].Name = "_cboAmendReason_3";
			cboAmendReason[3].TabIndex = 27;
			cboAmendReason[3].Visible = true;
			cboAmendReason[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[4].Enabled = true;
			cboAmendReason[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[4].Name = "_cboAmendReason_4";
			cboAmendReason[4].TabIndex = 29;
			cboAmendReason[4].Visible = true;
			cboAmendReason[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboAmendReason[5].Enabled = true;
			cboAmendReason[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboAmendReason[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			cboAmendReason[5].Name = "_cboAmendReason_5";
			cboAmendReason[5].TabIndex = 31;
			cboAmendReason[5].Visible = true;
			this.DontResponse = 0;
			this.rtxNarrative = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxNarrative.Name = "rtxNarrative";
			this.rtxNarrative.TabIndex = 299;
			this.rtxRecommend = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxRecommend.Name = "rtxRecommend";
			this.rtxRecommend.TabIndex = 300;
			this.CurrReport = 0;
			this.rtxFalseAlarmComment = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxFalseAlarmComment.Name = "rtxFalseAlarmComment";
			this.rtxFalseAlarmComment.TabIndex = 99;
			this.rtxFalseAlarmComment.Visible = false;
			chkSitFound = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(8);
			chkSitFound[4] = _chkSitFound_4;
			chkSitFound[3] = _chkSitFound_3;
			chkSitFound[6] = _chkSitFound_6;
			chkSitFound[5] = _chkSitFound_5;
			chkSitFound[2] = _chkSitFound_2;
			chkSitFound[1] = _chkSitFound_1;
			chkSitFound[0] = _chkSitFound_0;
			chkSitFound[7] = _chkSitFound_7;
			chkSitFound[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[4].Enabled = true;
			chkSitFound[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[4].Name = "_chkSitFound_4";
			chkSitFound[4].TabIndex = 54;
			chkSitFound[4].Text = "EMS PATIENTS -  # OF PATIENTS";
			chkSitFound[4].Visible = true;
			chkSitFound[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[3].Enabled = true;
			chkSitFound[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[3].Name = "_chkSitFound_3";
			chkSitFound[3].TabIndex = 52;
			chkSitFound[3].Text = "EMS PATIENT (SINGLE)";
			chkSitFound[3].Visible = true;
			chkSitFound[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[6].Enabled = true;
			chkSitFound[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[6].Name = "_chkSitFound_6";
			chkSitFound[6].TabIndex = 58;
			chkSitFound[6].Text = "HAZARDOUS CONDITION";
			chkSitFound[6].Visible = true;
			chkSitFound[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[5].Enabled = true;
			chkSitFound[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[5].Name = "_chkSitFound_5";
			chkSitFound[5].TabIndex = 56;
			chkSitFound[5].Text = "SEARCH AND/OR RESCUE";
			chkSitFound[5].Visible = true;
			chkSitFound[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[2].Enabled = true;
			chkSitFound[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[2].Name = "_chkSitFound_2";
			chkSitFound[2].TabIndex = 48;
			chkSitFound[2].Text = "HAZMAT";
			chkSitFound[2].Visible = true;
			chkSitFound[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[1].Enabled = true;
			chkSitFound[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[1].Name = "_chkSitFound_1";
			chkSitFound[1].TabIndex = 46;
			chkSitFound[1].Text = "RUPTURE/EXPLOSION";
			chkSitFound[1].Visible = true;
			chkSitFound[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[0].Enabled = true;
			chkSitFound[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[0].Name = "_chkSitFound_0";
			chkSitFound[0].TabIndex = 44;
			chkSitFound[0].Text = "FIRE";
			chkSitFound[0].Visible = true;
			chkSitFound[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSitFound[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSitFound[7].Enabled = true;
			chkSitFound[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSitFound[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			chkSitFound[7].Name = "_chkSitFound_7";
			chkSitFound[7].TabIndex = 60;
			chkSitFound[7].Text = "FALSE ALARM";
			chkSitFound[7].Visible = true;
			cboUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(12);
			cboUnit[11] = _cboUnit_11;
			cboUnit[10] = _cboUnit_10;
			cboUnit[9] = _cboUnit_9;
			cboUnit[5] = _cboUnit_5;
			cboUnit[3] = _cboUnit_3;
			cboUnit[2] = _cboUnit_2;
			cboUnit[1] = _cboUnit_1;
			cboUnit[0] = _cboUnit_0;
			cboUnit[6] = _cboUnit_6;
			cboUnit[7] = _cboUnit_7;
			cboUnit[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[11].Enabled = false;
			cboUnit[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[11].Name = "_cboUnit_11";
			cboUnit[11].TabIndex = 67;
			cboUnit[11].Text = "cboUnit";
			cboUnit[11].Visible = true;
			cboUnit[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[10].Enabled = false;
			cboUnit[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[10].Name = "_cboUnit_10";
			cboUnit[10].TabIndex = 65;
			cboUnit[10].Text = "cboUnit";
			cboUnit[10].Visible = true;
			cboUnit[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[9].Enabled = false;
			cboUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[9].Name = "_cboUnit_9";
			cboUnit[9].TabIndex = 63;
			cboUnit[9].Text = "cboUnit";
			cboUnit[9].Visible = true;
			cboUnit[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[5].Enabled = false;
			cboUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[5].Name = "_cboUnit_5";
			cboUnit[5].TabIndex = 57;
			cboUnit[5].Text = "cboUnit";
			cboUnit[5].Visible = true;
			cboUnit[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[3].Enabled = false;
			cboUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[3].Name = "_cboUnit_3";
			cboUnit[3].TabIndex = 53;
			cboUnit[3].Text = "cboUnit";
			cboUnit[3].Visible = true;
			cboUnit[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[2].Enabled = false;
			cboUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[2].Name = "_cboUnit_2";
			cboUnit[2].TabIndex = 49;
			cboUnit[2].Text = "cboUnit";
			cboUnit[2].Visible = true;
			cboUnit[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[1].Enabled = false;
			cboUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[1].Name = "_cboUnit_1";
			cboUnit[1].TabIndex = 47;
			cboUnit[1].Text = "cboUnit";
			cboUnit[1].Visible = true;
			cboUnit[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[0].Enabled = false;
			cboUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[0].Name = "_cboUnit_0";
			cboUnit[0].TabIndex = 45;
			cboUnit[0].Text = "cboUnit";
			cboUnit[0].Visible = true;
			cboUnit[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[6].Enabled = false;
			cboUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[6].Name = "_cboUnit_6";
			cboUnit[6].TabIndex = 59;
			cboUnit[6].Text = "cboUnit";
			cboUnit[6].Visible = true;
			cboUnit[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboUnit[7].Enabled = false;
			cboUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboUnit[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboUnit[7].Name = "_cboUnit_7";
			cboUnit[7].TabIndex = 61;
			cboUnit[7].Text = "cboUnit";
			cboUnit[7].Visible = true;
			this.chkSirenSingle = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkSirenSingle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.chkSirenSingle.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkSirenSingle.Enabled = true;
			this.chkSirenSingle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkSirenSingle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.chkSirenSingle.Name = "chkSirenSingle";
			this.chkSirenSingle.TabIndex = 324;
			this.chkSirenSingle.Text = "SIREN REPORT ?";
			this.chkSirenSingle.Visible = true;
			cboEMSUnit = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>>(13);
			cboEMSUnit[12] = _cboEMSUnit_12;
			cboEMSUnit[11] = _cboEMSUnit_11;
			cboEMSUnit[10] = _cboEMSUnit_10;
			cboEMSUnit[9] = _cboEMSUnit_9;
			cboEMSUnit[8] = _cboEMSUnit_8;
			cboEMSUnit[7] = _cboEMSUnit_7;
			cboEMSUnit[6] = _cboEMSUnit_6;
			cboEMSUnit[5] = _cboEMSUnit_5;
			cboEMSUnit[4] = _cboEMSUnit_4;
			cboEMSUnit[0] = _cboEMSUnit_0;
			cboEMSUnit[1] = _cboEMSUnit_1;
			cboEMSUnit[2] = _cboEMSUnit_2;
			cboEMSUnit[3] = _cboEMSUnit_3;
			cboEMSUnit[12].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[12].Enabled = true;
			cboEMSUnit[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[12].Name = "_cboEMSUnit_12";
			cboEMSUnit[12].TabIndex = 80;
			cboEMSUnit[12].Text = "cboEMSUnit";
			cboEMSUnit[12].Visible = false;
			cboEMSUnit[11].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[11].Enabled = true;
			cboEMSUnit[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[11].Name = "_cboEMSUnit_11";
			cboEMSUnit[11].TabIndex = 79;
			cboEMSUnit[11].Text = "cboEMSUnit";
			cboEMSUnit[11].Visible = false;
			cboEMSUnit[10].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[10].Enabled = true;
			cboEMSUnit[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[10].Name = "_cboEMSUnit_10";
			cboEMSUnit[10].TabIndex = 78;
			cboEMSUnit[10].Text = "cboEMSUnit";
			cboEMSUnit[10].Visible = false;
			cboEMSUnit[9].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[9].Enabled = true;
			cboEMSUnit[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[9].Name = "_cboEMSUnit_9";
			cboEMSUnit[9].TabIndex = 77;
			cboEMSUnit[9].Text = "cboEMSUnit";
			cboEMSUnit[9].Visible = false;
			cboEMSUnit[8].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[8].Enabled = true;
			cboEMSUnit[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[8].Name = "_cboEMSUnit_8";
			cboEMSUnit[8].TabIndex = 76;
			cboEMSUnit[8].Text = "cboEMSUnit";
			cboEMSUnit[8].Visible = false;
			cboEMSUnit[7].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[7].Enabled = true;
			cboEMSUnit[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[7].Name = "_cboEMSUnit_7";
			cboEMSUnit[7].TabIndex = 75;
			cboEMSUnit[7].Text = "cboEMSUnit";
			cboEMSUnit[7].Visible = false;
			cboEMSUnit[6].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[6].Enabled = true;
			cboEMSUnit[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[6].Name = "_cboEMSUnit_6";
			cboEMSUnit[6].TabIndex = 74;
			cboEMSUnit[6].Text = "cboEMSUnit";
			cboEMSUnit[6].Visible = false;
			cboEMSUnit[5].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[5].Enabled = true;
			cboEMSUnit[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[5].Name = "_cboEMSUnit_5";
			cboEMSUnit[5].TabIndex = 73;
			cboEMSUnit[5].Text = "cboEMSUnit";
			cboEMSUnit[5].Visible = false;
			cboEMSUnit[4].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[4].Enabled = true;
			cboEMSUnit[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[4].Name = "_cboEMSUnit_4";
			cboEMSUnit[4].TabIndex = 72;
			cboEMSUnit[4].Text = "cboEMSUnit";
			cboEMSUnit[4].Visible = false;
			cboEMSUnit[0].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[0].Enabled = true;
			cboEMSUnit[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[0].Name = "_cboEMSUnit_0";
			cboEMSUnit[0].TabIndex = 68;
			cboEMSUnit[0].Text = "cboEMSUnit";
			cboEMSUnit[0].Visible = false;
			cboEMSUnit[1].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[1].Enabled = true;
			cboEMSUnit[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[1].Name = "_cboEMSUnit_1";
			cboEMSUnit[1].TabIndex = 69;
			cboEMSUnit[1].Text = "cboEMSUnit";
			cboEMSUnit[1].Visible = false;
			cboEMSUnit[2].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[2].Enabled = true;
			cboEMSUnit[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[2].Name = "_cboEMSUnit_2";
			cboEMSUnit[2].TabIndex = 70;
			cboEMSUnit[2].Text = "cboEMSUnit";
			cboEMSUnit[2].Visible = false;
			cboEMSUnit[3].BackColor = UpgradeHelpers.Helpers.Color.White;
			cboEMSUnit[3].Enabled = true;
			cboEMSUnit[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cboEMSUnit[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			cboEMSUnit[3].Name = "_cboEMSUnit_3";
			cboEMSUnit[3].TabIndex = 71;
			cboEMSUnit[3].Text = "cboEMSUnit";
			cboEMSUnit[3].Visible = false;
			lbPatient = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(13);
			lbPatient[12] = _lbPatient_12;
			lbPatient[11] = _lbPatient_11;
			lbPatient[10] = _lbPatient_10;
			lbPatient[9] = _lbPatient_9;
			lbPatient[8] = _lbPatient_8;
			lbPatient[7] = _lbPatient_7;
			lbPatient[6] = _lbPatient_6;
			lbPatient[5] = _lbPatient_5;
			lbPatient[4] = _lbPatient_4;
			lbPatient[3] = _lbPatient_3;
			lbPatient[2] = _lbPatient_2;
			lbPatient[1] = _lbPatient_1;
			lbPatient[0] = _lbPatient_0;
			lbPatient[12].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[12].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[12].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[12].Name = "_lbPatient_12";
			lbPatient[12].TabIndex = 228;
			lbPatient[12].Text = "PCR";
			lbPatient[12].Visible = false;
			lbPatient[11].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[11].Name = "_lbPatient_11";
			lbPatient[11].TabIndex = 227;
			lbPatient[11].Text = "PCR";
			lbPatient[11].Visible = false;
			lbPatient[10].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[10].Name = "_lbPatient_10";
			lbPatient[10].TabIndex = 226;
			lbPatient[10].Text = "PCR";
			lbPatient[10].Visible = false;
			lbPatient[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[9].Name = "_lbPatient_9";
			lbPatient[9].TabIndex = 196;
			lbPatient[9].Text = "PCR";
			lbPatient[9].Visible = false;
			lbPatient[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[8].Name = "_lbPatient_8";
			lbPatient[8].TabIndex = 195;
			lbPatient[8].Text = "PCR";
			lbPatient[8].Visible = false;
			lbPatient[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[7].Name = "_lbPatient_7";
			lbPatient[7].TabIndex = 194;
			lbPatient[7].Text = "PCR";
			lbPatient[7].Visible = false;
			lbPatient[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[6].Name = "_lbPatient_6";
			lbPatient[6].TabIndex = 193;
			lbPatient[6].Text = "PCR";
			lbPatient[6].Visible = false;
			lbPatient[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[5].Name = "_lbPatient_5";
			lbPatient[5].TabIndex = 192;
			lbPatient[5].Text = "PCR";
			lbPatient[5].Visible = false;
			lbPatient[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[4].Name = "_lbPatient_4";
			lbPatient[4].TabIndex = 190;
			lbPatient[4].Text = "PCR";
			lbPatient[4].Visible = false;
			lbPatient[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[3].Name = "_lbPatient_3";
			lbPatient[3].TabIndex = 188;
			lbPatient[3].Text = "PCR";
			lbPatient[3].Visible = false;
			lbPatient[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[2].Name = "_lbPatient_2";
			lbPatient[2].TabIndex = 186;
			lbPatient[2].Text = "PCR";
			lbPatient[2].Visible = false;
			lbPatient[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[1].Name = "_lbPatient_1";
			lbPatient[1].TabIndex = 185;
			lbPatient[1].Text = "PCR";
			lbPatient[1].Visible = false;
			lbPatient[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbPatient[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbPatient[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			lbPatient[0].Name = "_lbPatient_0";
			lbPatient[0].TabIndex = 184;
			lbPatient[0].Text = "PCR";
			lbPatient[0].Visible = false;
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
			chkSirenReport[12].TabIndex = 338;
			chkSirenReport[12].Text = "Siren?";
			chkSirenReport[12].Visible = true;
			chkSirenReport[11].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[11].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[11].Enabled = true;
			chkSirenReport[11].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[11].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[11].Name = "_chkSirenReport_11";
			chkSirenReport[11].TabIndex = 337;
			chkSirenReport[11].Text = "Siren?";
			chkSirenReport[11].Visible = true;
			chkSirenReport[10].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[10].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[10].Enabled = true;
			chkSirenReport[10].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[10].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[10].Name = "_chkSirenReport_10";
			chkSirenReport[10].TabIndex = 336;
			chkSirenReport[10].Text = "Siren?";
			chkSirenReport[10].Visible = true;
			chkSirenReport[9].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[9].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[9].Enabled = true;
			chkSirenReport[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[9].Name = "_chkSirenReport_9";
			chkSirenReport[9].TabIndex = 335;
			chkSirenReport[9].Text = "Siren?";
			chkSirenReport[9].Visible = true;
			chkSirenReport[8].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[8].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[8].Enabled = true;
			chkSirenReport[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[8].Name = "_chkSirenReport_8";
			chkSirenReport[8].TabIndex = 334;
			chkSirenReport[8].Text = "Siren?";
			chkSirenReport[8].Visible = true;
			chkSirenReport[7].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[7].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[7].Enabled = true;
			chkSirenReport[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[7].Name = "_chkSirenReport_7";
			chkSirenReport[7].TabIndex = 333;
			chkSirenReport[7].Text = "Siren?";
			chkSirenReport[7].Visible = true;
			chkSirenReport[6].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[6].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[6].Enabled = true;
			chkSirenReport[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[6].Name = "_chkSirenReport_6";
			chkSirenReport[6].TabIndex = 332;
			chkSirenReport[6].Text = "Siren?";
			chkSirenReport[6].Visible = true;
			chkSirenReport[5].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[5].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[5].Enabled = true;
			chkSirenReport[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[5].Name = "_chkSirenReport_5";
			chkSirenReport[5].TabIndex = 331;
			chkSirenReport[5].Text = "Siren?";
			chkSirenReport[5].Visible = true;
			chkSirenReport[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[4].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[4].Enabled = true;
			chkSirenReport[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[4].Name = "_chkSirenReport_4";
			chkSirenReport[4].TabIndex = 330;
			chkSirenReport[4].Text = "Siren?";
			chkSirenReport[4].Visible = true;
			chkSirenReport[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[3].Enabled = true;
			chkSirenReport[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[3].Name = "_chkSirenReport_3";
			chkSirenReport[3].TabIndex = 329;
			chkSirenReport[3].Text = "Siren?";
			chkSirenReport[3].Visible = true;
			chkSirenReport[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[2].Enabled = true;
			chkSirenReport[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[2].Name = "_chkSirenReport_2";
			chkSirenReport[2].TabIndex = 328;
			chkSirenReport[2].Text = "Siren?";
			chkSirenReport[2].Visible = true;
			chkSirenReport[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[1].Enabled = true;
			chkSirenReport[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[1].Name = "_chkSirenReport_1";
			chkSirenReport[1].TabIndex = 327;
			chkSirenReport[1].Text = "Siren?";
			chkSirenReport[1].Visible = true;
			chkSirenReport[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			chkSirenReport[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			chkSirenReport[0].Enabled = true;
			chkSirenReport[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			chkSirenReport[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			chkSirenReport[0].Name = "_chkSirenReport_0";
			chkSirenReport[0].TabIndex = 326;
			chkSirenReport[0].Text = "Siren?";
			chkSirenReport[0].Visible = true;
			optServiceReport = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optServiceReport[2] = _optServiceReport_2;
			optServiceReport[1] = _optServiceReport_1;
			optServiceReport[0] = _optServiceReport_0;
			optServiceReport[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[2].Checked = false;
			optServiceReport[2].Enabled = true;
			optServiceReport[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[2].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[2].Name = "_optServiceReport_2";
			optServiceReport[2].TabIndex = 66;
			optServiceReport[2].Text = "STANDBY/STAGING ONLY";
			optServiceReport[2].Visible = true;
			optServiceReport[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[1].Checked = false;
			optServiceReport[1].Enabled = true;
			optServiceReport[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[1].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[1].Name = "_optServiceReport_1";
			optServiceReport[1].TabIndex = 64;
			optServiceReport[1].Text = "CLEAN UP ONLY";
			optServiceReport[1].Visible = true;
			optServiceReport[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			optServiceReport[0].Checked = false;
			optServiceReport[0].Enabled = true;
			optServiceReport[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optServiceReport[0].ForeColor = UpgradeHelpers.Helpers.Color.White;
			optServiceReport[0].Name = "_optServiceReport_0";
			optServiceReport[0].TabIndex = 62;
			optServiceReport[0].Text = "INVESTIGATE ONLY";
			optServiceReport[0].Visible = true;
			this.SituatationSaved = 0;
			this.UnitReportUpdated = 0;
			lbActualTime = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(6);
			lbActualTime[0] = _lbActualTime_0;
			lbActualTime[5] = _lbActualTime_5;
			lbActualTime[4] = _lbActualTime_4;
			lbActualTime[3] = _lbActualTime_3;
			lbActualTime[2] = _lbActualTime_2;
			lbActualTime[1] = _lbActualTime_1;
			lbActualTime[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[0].Name = "_lbActualTime_0";
			lbActualTime[0].TabIndex = 215;
			lbActualTime[0].Tag = "3";
			lbActualTime[0].Text = "55:55";
			lbActualTime[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[5].Name = "_lbActualTime_5";
			lbActualTime[5].TabIndex = 214;
			lbActualTime[5].Tag = "8";
			lbActualTime[5].Text = "55:55";
			lbActualTime[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[4].Name = "_lbActualTime_4";
			lbActualTime[4].TabIndex = 213;
			lbActualTime[4].Tag = "7";
			lbActualTime[4].Text = "55:55";
			lbActualTime[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[3].Name = "_lbActualTime_3";
			lbActualTime[3].TabIndex = 212;
			lbActualTime[3].Tag = "6";
			lbActualTime[3].Text = "55:55";
			lbActualTime[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[2].Name = "_lbActualTime_2";
			lbActualTime[2].TabIndex = 211;
			lbActualTime[2].Tag = "5";
			lbActualTime[2].Text = "55:55";
			lbActualTime[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbActualTime[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbActualTime[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbActualTime[1].Name = "_lbActualTime_1";
			lbActualTime[1].TabIndex = 210;
			lbActualTime[1].Tag = "4";
			lbActualTime[1].Text = "55:55";
			NavButton = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(5);
			NavButton[0] = _NavButton_0;
			NavButton[4] = _NavButton_4;
			NavButton[1] = _NavButton_1;
			NavButton[2] = _NavButton_2;
			NavButton[3] = _NavButton_3;
			NavButton[0].Name = "_NavButton_0";
			NavButton[0].TabIndex = 319;
            NavButton[0].Visible = true;
			NavButton[4].Name = "_NavButton_4";
			NavButton[4].TabIndex = 318;
            NavButton[4].Visible = false;
            NavButton[1].Name = "_NavButton_1";
			NavButton[1].TabIndex = 320;
            NavButton[1].Visible = false;
            NavButton[2].Name = "_NavButton_2";
			NavButton[2].TabIndex = 321;
            NavButton[2].Visible = false;
            NavButton[3].Name = "_NavButton_3";
			NavButton[3].TabIndex = 322;
            NavButton[3].Visible = false;
            this.PPEFlag = 0;
			this.UnitICStatus = 0;
			cmdClearPerson = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(8);
			cmdClearPerson[6] = _cmdClearPerson_6;
			cmdClearPerson[5] = _cmdClearPerson_5;
			cmdClearPerson[7] = _cmdClearPerson_7;
			cmdClearPerson[4] = _cmdClearPerson_4;
			cmdClearPerson[3] = _cmdClearPerson_3;
			cmdClearPerson[2] = _cmdClearPerson_2;
			cmdClearPerson[1] = _cmdClearPerson_1;
			cmdClearPerson[0] = _cmdClearPerson_0;
			cmdClearPerson[6].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[6].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[6].Name = "_cmdClearPerson_6";
			cmdClearPerson[6].TabIndex = 251;
			cmdClearPerson[6].Visible = false;
			cmdClearPerson[5].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[5].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[5].Name = "_cmdClearPerson_5";
			cmdClearPerson[5].TabIndex = 224;
			cmdClearPerson[5].Visible = false;
			cmdClearPerson[7].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[7].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[7].Name = "_cmdClearPerson_7";
			cmdClearPerson[7].TabIndex = 223;
			cmdClearPerson[4].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[4].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[4].Name = "_cmdClearPerson_4";
			cmdClearPerson[4].TabIndex = 222;
			cmdClearPerson[4].Visible = false;
			cmdClearPerson[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[3].Name = "_cmdClearPerson_3";
			cmdClearPerson[3].TabIndex = 221;
			cmdClearPerson[3].Visible = false;
			cmdClearPerson[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[2].Name = "_cmdClearPerson_2";
			cmdClearPerson[2].TabIndex = 220;
			cmdClearPerson[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[1].Name = "_cmdClearPerson_1";
			cmdClearPerson[1].TabIndex = 219;
			cmdClearPerson[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdClearPerson[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdClearPerson[0].Name = "_cmdClearPerson_0";
			cmdClearPerson[0].TabIndex = 218;
			
			this.CurrFrame = null;
			this.MiscReportUpdated = 0;
			imgMain = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>>(14);
			imgMain[7] = _imgMain_7;
			imgMain[3] = _imgMain_3;
			imgMain[6] = _imgMain_6;
			imgMain[5] = _imgMain_5;
			imgMain[13] = _imgMain_13;
			imgMain[1] = _imgMain_1;
			imgMain[7].Enabled = true;
			imgMain[7].Name = "_imgMain_7";
			imgMain[7].Tag = "7";
			imgMain[7].Visible = true;
			imgMain[3].Enabled = true;
			imgMain[3].Name = "_imgMain_3";
			imgMain[3].Visible = true;
			imgMain[6].Enabled = true;
			imgMain[6].Name = "_imgMain_6";
			imgMain[6].Visible = true;
			imgMain[5].Enabled = true;
			imgMain[5].Name = "_imgMain_5";
			imgMain[5].Visible = true;
			imgMain[13].Enabled = true;
			imgMain[13].Name = "_imgMain_13";
			imgMain[13].Visible = true;
			imgMain[1].Enabled = true;
			imgMain[1].Name = "_imgMain_1";
			imgMain[1].Visible = true;
			this.ShowAddress = 0;

            // 
            // frmMultiEMS
            // 
            this.frmMultiEMS = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			this.frmMultiEMS.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
			this.frmMultiEMS.Enabled = true;
			this.frmMultiEMS.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmMultiEMS.Name = "frmMultiEMS";
			this.frmMultiEMS.TabIndex = 181;
			this.frmMultiEMS.Visible = false;

            // 
            // rtxNarration
            // 
            this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Enabled = true;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 187;
			this.FormOpening = 0;
			this.frmOpen = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmOpen
			// 
			//this.frmOpen.BackColor = UpgradeHelpers.Helpers.Color.Gray;
			//this.frmOpen.Enabled = true;
			//this.frmOpen.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 14.4f, UpgradeHelpers.
			//			Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			//this.frmOpen.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmOpen.Name = "frmOpen";
			//this.frmOpen.TabIndex = 248;
			//this.frmOpen.Text = "Wizard Startup";
			//this.frmOpen.Visible = true;
			optGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optGender[0] = _optGender_0;
			optGender[1] = _optGender_1;
			optGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optGender[0].Checked = false;
			optGender[0].Enabled = true;
			optGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optGender[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optGender[0].Name = "_optGender_0";
			optGender[0].TabIndex = 115;
			optGender[0].Text = "MALE";
			optGender[0].Visible = true;
			optGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optGender[1].Checked = false;
			optGender[1].Enabled = true;
			optGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optGender[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optGender[1].Name = "_optGender_1";
			optGender[1].TabIndex = 114;
			optGender[1].Text = "FEMALE";
			optGender[1].Visible = true;
			optEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEthnicity[0] = _optEthnicity_0;
			optEthnicity[1] = _optEthnicity_1;
			optEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optEthnicity[0].Checked = false;
			optEthnicity[0].Enabled = true;
			optEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optEthnicity[0].Name = "_optEthnicity_0";
			optEthnicity[0].TabIndex = 112;
			optEthnicity[0].Text = "HISPANIC";
			optEthnicity[0].Visible = true;
			optEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optEthnicity[1].Checked = false;
			optEthnicity[1].Enabled = true;
			optEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optEthnicity[1].Name = "_optEthnicity_1";
			optEthnicity[1].TabIndex = 111;
			optEthnicity[1].Text = "NON-HISPANIC";
			optEthnicity[1].Visible = true;
			lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			lbFrameTitle[9] = _lbFrameTitle_9;
			lbFrameTitle[7] = _lbFrameTitle_7;
			lbFrameTitle[3] = _lbFrameTitle_3;
			lbFrameTitle[2] = _lbFrameTitle_2;
			lbFrameTitle[0] = _lbFrameTitle_0;
			lbFrameTitle[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			lbFrameTitle[9].Name = "_lbFrameTitle_9";
			lbFrameTitle[9].TabIndex = 316;
			lbFrameTitle[9].Text = "INCIDENT ADDRESS CORRECTION";
			lbFrameTitle[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 0);
			lbFrameTitle[7].Name = "_lbFrameTitle_7";
			lbFrameTitle[7].TabIndex = 155;
			lbFrameTitle[7].Text = "REPORT NARRATION";
			lbFrameTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 18f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbFrameTitle[3].Name = "_lbFrameTitle_3";
			lbFrameTitle[3].TabIndex = 154;
			lbFrameTitle[3].Text = "Frame Title";
			lbFrameTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 18f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
			lbFrameTitle[2].Name = "_lbFrameTitle_2";
			lbFrameTitle[2].TabIndex = 40;
			lbFrameTitle[2].Text = "INCIDENT SITUATION FOUND REPORT";
			lbFrameTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 18f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
			lbFrameTitle[0].Name = "_lbFrameTitle_0";
			lbFrameTitle[0].TabIndex = 37;
			lbFrameTitle[0].Text = "UNIT RESPONSE REPORT";
			this.Name = "TFDIncident.wzdMain";
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCityCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label34 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label33 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label32 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label27 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label26 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label25 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmIncidentAddressCorrection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEProblem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEEquipment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNavMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel NavBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLocationAtInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryCausedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboWhereOccured { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboActivity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocationAtInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjurySeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBodyPart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContributingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCasualtyDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFSCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEthnicity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHouseNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryCause { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCCLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInjuryCause { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCCLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEMSPatient { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEMSPatient { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCivCasualtyTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmCivilianCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfoTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmAllInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberSafePlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboServiceType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStandbyHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSafePlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServiceProvided { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStandbyHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServiceTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmService { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSCurrReportType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSEmployeeID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSReportedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReportByTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSIncidentNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNumberTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSFrameTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmReportStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberCivCasulties { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberPatients { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optServiceReport_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel Frame2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboEMSUnit_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbPatient_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSirenTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEMSReportingUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmSitFound { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPersonnel_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboPosition_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInjury { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel _cboAmendReason_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel _txtAmendTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbURDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbActualTime_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Line1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAmendedReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAmendedTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTimeTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEventTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAvailable { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTransportComplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTransport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOnscene { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEnroute { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbDispatch { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstReasonDelay { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstActionsTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnitComment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReasonsDelayTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbActionsTakenTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbActionTaken { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmUnitReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNoTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnitTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocationTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemovePPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkFPEProblem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkEMR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkIC { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAbandon { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveIncomplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAddressCorrection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkCivilianCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkSitFound_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel FDCaresBtn { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdClearPerson_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddStaff { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _chkCasualty_2 { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxUnitNarration { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReportLogID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DontRespond { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboPersonnel { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboPosition { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkCasualty { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel> txtAmendTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboAmendReason { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DontResponse { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarrative { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxRecommend { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxFalseAlarmComment { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkSitFound { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkSirenSingle { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ComboBoxViewModel> cboEMSUnit { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbPatient { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> chkSirenReport { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optServiceReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 SituatationSaved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 UnitReportUpdated { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbActualTime { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> NavButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PPEFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 UnitICStatus { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdClearPerson { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual dynamic CurrFrame { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MiscReportUpdated { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel> imgMain { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean Visible { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ShowAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmMultiEMS { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FormOpening { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmOpen { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		public void OntxtXHouseNumber_TextChanged()
		{
			if ( _txtXHouseNumber_TextChanged != null )
				_txtXHouseNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXHouseNumber_TextChanged;

		public void OntxtXStreetName_TextChanged()
		{
			if ( _txtXStreetName_TextChanged != null )
				_txtXStreetName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtXStreetName_TextChanged;

		public void OntxtAllInfo1_TextChanged()
		{
			if ( _txtAllInfo1_TextChanged != null )
				_txtAllInfo1_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAllInfo1_TextChanged;

		public void OntxtNumberSafePlace_TextChanged()
		{
			if ( _txtNumberSafePlace_TextChanged != null )
				_txtNumberSafePlace_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberSafePlace_TextChanged;

		public void OntxtStandbyHours_TextChanged()
		{
			if ( _txtStandbyHours_TextChanged != null )
				_txtStandbyHours_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtStandbyHours_TextChanged;

		public void OntxtNumberCivCasulties_TextChanged()
		{
			if ( _txtNumberCivCasulties_TextChanged != null )
				_txtNumberCivCasulties_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberCivCasulties_TextChanged;

		public void OntxtNumberPatients_TextChanged()
		{
			if ( _txtNumberPatients_TextChanged != null )
				_txtNumberPatients_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberPatients_TextChanged;
	}

}