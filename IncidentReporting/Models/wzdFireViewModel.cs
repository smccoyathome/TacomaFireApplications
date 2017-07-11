using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;
using System;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.wzdFire))]
	public class wzdFireViewModel
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
			this.Label23.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label23.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.Label23.Name = "Label23";
			this.Label23.TabIndex = 238;
			this.Label23.Text = "Wizard Navigation Bar";
			this.lbNavMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNavMessage
			// 
			this.lbNavMessage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNavMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbNavMessage.Name = "lbNavMessage";
			this.lbNavMessage.TabIndex = 237;
			this.lbNavMessage.Text = "Make Selection";
			this.NavBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// NavBar
			// 
			this.NavBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.NavBar.Enabled = true;
			this.NavBar.Name = "NavBar";
			this.NavBar.Visible = true;
			this.cboCityCode = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCityCode
			// 
			this.cboCityCode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboCityCode.Enabled = true;
			this.cboCityCode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCityCode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboCityCode.Name = "cboCityCode";
			this.cboCityCode.TabIndex = 227;
			this.cboCityCode.Visible = true;
			this.txtXHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtXHouseNumber.Name = "txtXHouseNumber";
			this.txtXHouseNumber.TabIndex = 222;
			this.txtXStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtXStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtXStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtXStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtXStreetName.Name = "txtXStreetName";
			this.txtXStreetName.TabIndex = 224;
			this.cboXPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXPrefix
			// 
			this.cboXPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXPrefix.Enabled = true;
			this.cboXPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboXPrefix.Name = "cboXPrefix";
			this.cboXPrefix.TabIndex = 223;
			this.cboXPrefix.Visible = true;
			this.cboXStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXStreetType
			// 
			this.cboXStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXStreetType.Enabled = true;
			this.cboXStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboXStreetType.Name = "cboXStreetType";
			this.cboXStreetType.TabIndex = 225;
			this.cboXStreetType.Visible = true;
			this.cboXSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboXSuffix
			// 
			this.cboXSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboXSuffix.Enabled = true;
			this.cboXSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboXSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboXSuffix.Name = "cboXSuffix";
			this.cboXSuffix.TabIndex = 226;
			this.cboXSuffix.Visible = true;
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 233;
			this.Label2.Text = "HOUSE#";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 232;
			this.Label3.Text = "PREFIX";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 231;
			this.Label4.Text = "STREET NAME";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 230;
			this.Label5.Text = "STREET TYPE";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 229;
			this.Label6.Text = "SUFFIX";
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 228;
			this.Label8.Text = "CITY";
			this._lbFrameTitle_9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmExposureAddress
            // 
            this.frmExposureAddress = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            //this.frmExposureAddress.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmExposureAddress.Enabled = true;
			this.frmExposureAddress.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmExposureAddress.Name = "frmExposureAddress";
			this.frmExposureAddress.TabIndex = 219;
			this.frmExposureAddress.Visible = false;
			this.lstMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstMessage
			// 
			//this.lstMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lstMessage.Enabled = true;
			this.lstMessage.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lstMessage.Name = "lstMessage";
			this.lstMessage.TabIndex = 234;
			this.lstMessage.Visible = true;
			this.lstMessage.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 235;
			this.Label1.Text = "REPORTS FOR THIS INCIDENT";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 210;
			this.Label9.Text = "CURRENT REPORT:";
			this.lbRSCurrReportType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRSCurrReportType
			// 
			this.lbRSCurrReportType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRSCurrReportType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRSCurrReportType.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbRSCurrReportType.Name = "lbRSCurrReportType";
			this.lbRSCurrReportType.TabIndex = 209;
			this.lbRSCurrReportType.Text = "Mobile Property Fire Report";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 185;
			this.Label7.Text = "ASSIGNMENT:";
			this._lbFrameTitle_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._imgMain_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this.lbIncidentNumberTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncidentNumberTitle
			// 
			this.lbIncidentNumberTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncidentNumberTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncidentNumberTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbIncidentNumberTitle.Name = "lbIncidentNumberTitle";
			this.lbIncidentNumberTitle.TabIndex = 164;
			this.lbIncidentNumberTitle.Text = "INCIDENT #:";
			this.lblIncidentNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblIncidentNumber
			// 
			this.lblIncidentNumber.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblIncidentNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblIncidentNumber.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lblIncidentNumber.Name = "lblIncidentNumber";
			this.lblIncidentNumber.TabIndex = 163;
			this.lblIncidentNumber.Text = "001230056";
			this.lbReportByTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReportByTitle
			// 
			this.lbReportByTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReportByTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReportByTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbReportByTitle.Name = "lbReportByTitle";
			this.lbReportByTitle.TabIndex = 162;
			this.lbReportByTitle.Text = "REPORTED BY:";
			this.lbReportedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbReportedBy
			// 
			this.lbReportedBy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbReportedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbReportedBy.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lbReportedBy.Name = "lbReportedBy";
			this.lbReportedBy.TabIndex = 161;
			this.lbReportedBy.Text = "Hilderbrand, Robert";
			this.lblEmployeeID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblEmployeeID
			// 
			this.lblEmployeeID.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblEmployeeID.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblEmployeeID.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lblEmployeeID.Name = "lblEmployeeID";
			this.lblEmployeeID.TabIndex = 160;
			this.lblEmployeeID.Text = "02341";
			this.lblPosition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblPosition
			// 
			this.lblPosition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblPosition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblPosition.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.TabIndex = 159;
			this.lblPosition.Text = "Officer";
			this.lblUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblUnit
			// 
			this.lblUnit.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblUnit.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.TabIndex = 158;
			this.lblUnit.Text = "E10";
			this.lblShift = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblShift
			// 
			this.lblShift.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblShift.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblShift.ForeColor = UpgradeHelpers.Helpers.Color.Purple;
			this.lblShift.Name = "lblShift";
			this.lblShift.TabIndex = 157;
			this.lblShift.Text = "D Shift";
			this.frmReportStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmReportStatus
			// 
			//this.frmReportStatus.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmReportStatus.Enabled = true;
			this.frmReportStatus.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmReportStatus.Name = "frmReportStatus";
			this.frmReportStatus.TabIndex = 153;
			this.frmReportStatus.Tag = "2";
			this.frmReportStatus.Visible = false;
			this.cboOSHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSHeatSource
			// 
			this.cboOSHeatSource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSHeatSource.Enabled = true;
			this.cboOSHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOSHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOSHeatSource.Name = "cboOSHeatSource";
			this.cboOSHeatSource.TabIndex = 46;
			this.cboOSHeatSource.Text = " cboOSHeatSource";
			this.cboOSHeatSource.Visible = true;

            // 
            // cboOSSpecCauseOfIgnition
            // 
            this.cboOSSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSSpecCauseOfIgnition.Enabled = true;
			this.cboOSSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOSSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOSSpecCauseOfIgnition.Name = "cboOSSpecCauseOfIgnition";
			this.cboOSSpecCauseOfIgnition.TabIndex = 48;
			this.cboOSSpecCauseOfIgnition.Text = " cboOSSpecCauseOfIgnition";
			this.cboOSSpecCauseOfIgnition.Visible = true;

            // 
            // cboOSMaterialInvolved
            // 
            this.cboOSMaterialInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboOSMaterialInvolved.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSMaterialInvolved.Enabled = true;
			this.cboOSMaterialInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOSMaterialInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOSMaterialInvolved.Name = "cboOSMaterialInvolved";
			this.cboOSMaterialInvolved.TabIndex = 52;
			this.cboOSMaterialInvolved.Text = " cboOSMaterialInvolved";
			this.cboOSMaterialInvolved.Visible = false;
			this.cboOSAreaUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSAreaUnits
			// 
			this.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSAreaUnits.Enabled = true;
			this.cboOSAreaUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOSAreaUnits.Name = "cboOSAreaUnits";
			this.cboOSAreaUnits.TabIndex = 50;
			this.cboOSAreaUnits.Text = " cboOSAreaUnits";
			this.cboOSAreaUnits.Visible = true;
			this.cboOSCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboOSCauseOfIgnition
			// 
			this.cboOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboOSCauseOfIgnition.Enabled = true;
			this.cboOSCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboOSCauseOfIgnition.Name = "cboOSCauseOfIgnition";
			this.cboOSCauseOfIgnition.TabIndex = 47;
			this.cboOSCauseOfIgnition.Text = " cboOSGenCauseOfIgnition";
			this.cboOSCauseOfIgnition.Visible = true;
			this.txtOSLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOSLoss.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtOSLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtOSLoss.Name = "txtOSLoss";
			this.txtOSLoss.TabIndex = 49;
			this.txtOSLoss.Text = "0";
			this.txtOSAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtOSAreaAffected.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtOSAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtOSAreaAffected.Name = "txtOSAreaAffected";
			this.txtOSAreaAffected.TabIndex = 51;
			this.txtOSAreaAffected.Text = " txtOSAreaAffected";
			this.lbOSHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSHeatSource
			// 
			this.lbOSHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSHeatSource.Name = "lbOSHeatSource";
			this.lbOSHeatSource.TabIndex = 182;
			this.lbOSHeatSource.Text = "HEAT SOURCE";
			this.lbSpecOSCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecOSCauseOfIgnition
			// 
			this.lbSpecOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecOSCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSpecOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSpecOSCauseOfIgnition.Name = "lbSpecOSCauseOfIgnition";
			this.lbSpecOSCauseOfIgnition.TabIndex = 174;
			this.lbSpecOSCauseOfIgnition.Text = "SPECIFIC CAUSE OF IGNITION";
			this.lbOSCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSCauseOfIgnition
			// 
			this.lbOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSCauseOfIgnition.Name = "lbOSCauseOfIgnition";
			this.lbOSCauseOfIgnition.TabIndex = 124;
			this.lbOSCauseOfIgnition.Text = "GENERAL CAUSE OF IGNITION";
			this.lbOSAreaAffected = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSAreaAffected
			// 
			this.lbOSAreaAffected.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSAreaAffected.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSAreaAffected.Name = "lbOSAreaAffected";
			this.lbOSAreaAffected.TabIndex = 123;
			this.lbOSAreaAffected.Text = "AREA AFFECTED";
			this.lbOSContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSContentLoss
			// 
			this.lbOSContentLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSContentLoss.Name = "lbOSContentLoss";
			this.lbOSContentLoss.TabIndex = 122;
			this.lbOSContentLoss.Text = "CONTENT LOSS";
			this.lbOSAreaUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSAreaUnits
			// 
			this.lbOSAreaUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSAreaUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSAreaUnits.Name = "lbOSAreaUnits";
			this.lbOSAreaUnits.TabIndex = 121;
			this.lbOSAreaUnits.Text = "AREA UNITS";
			this.lbOSMaterialInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbOSMaterialInvolved
			// 
			this.lbOSMaterialInvolved.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOSMaterialInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOSMaterialInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOSMaterialInvolved.Name = "lbOSMaterialInvolved";
			this.lbOSMaterialInvolved.TabIndex = 120;
			this.lbOSMaterialInvolved.Text = "MATERIAL INVOLVED";
			this.lbOSMaterialInvolved.Visible = false;
			this._lbFrameTitle_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmOutsideInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmOutsideInfo
			// 
			//this.frmOutsideInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmOutsideInfo.Enabled = true;
			this.frmOutsideInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmOutsideInfo.Name = "frmOutsideInfo";
			this.frmOutsideInfo.TabIndex = 118;
			this.frmOutsideInfo.Tag = "1";
			this.frmOutsideInfo.Visible = false;
			this.txtHFAge = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHFAge.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHFAge.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtHFAge.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtHFAge.Name = "txtHFAge";
			this.txtHFAge.TabIndex = 62;
			this.txtHFAge.Text = "Text1";
			this._optHFGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optHFGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 254;
			this.Label11.Text = "AGE";
			this.frmHFDetail = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmHFDetail
			// 
			this.frmHFDetail.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(181, 189, 100);
			this.frmHFDetail.Enabled = true;
			this.frmHFDetail.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmHFDetail.Name = "frmHFDetail";
			this.frmHFDetail.TabIndex = 253;
			this.frmHFDetail.Visible = false;

            // 
            // cboSpecCauseOfIgnition
            // 
            this.cboSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecCauseOfIgnition.Enabled = true;
			this.cboSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSpecCauseOfIgnition.Name = "cboSpecCauseOfIgnition";
			this.cboSpecCauseOfIgnition.TabIndex = 57;
			this.cboSpecCauseOfIgnition.Text = " cboSpecCauseOfIgnition";
			this.cboSpecCauseOfIgnition.Visible = true;
			
            // 
            // cboGenCauseOfIgnition
            // 
            this.cboGenCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGenCauseOfIgnition.Enabled = true;
			this.cboGenCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboGenCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboGenCauseOfIgnition.Name = "cboGenCauseOfIgnition";
			this.cboGenCauseOfIgnition.TabIndex = 56;
			this.cboGenCauseOfIgnition.Text = " cboGenCauseOfIgnition";
			this.cboGenCauseOfIgnition.Visible = true;

            // 
            // lstSuppressionFactors
            // 
            this.lstSuppressionFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
            this.lstSuppressionFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstSuppressionFactors.Enabled = true;
			this.lstSuppressionFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstSuppressionFactors.Name = "lstSuppressionFactors";
			this.lstSuppressionFactors.TabIndex = 63;
			this.lstSuppressionFactors.Visible = true;
			this.lstSuppressionFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboFirstItemIgnited = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFirstItemIgnited
			// 
			this.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboFirstItemIgnited.Enabled = true;
			this.cboFirstItemIgnited.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFirstItemIgnited.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboFirstItemIgnited.Name = "cboFirstItemIgnited";
			this.cboFirstItemIgnited.TabIndex = 55;
			this.cboFirstItemIgnited.Text = " cboFirstItemIgnited";
			this.cboFirstItemIgnited.Visible = true;
			this.txtFloorOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFloorOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtFloorOfOrigin.Name = "txtFloorOfOrigin";
			this.txtFloorOfOrigin.TabIndex = 64;
			this.txtFloorOfOrigin.Text = "txtFloorOfOrigin";
			this.lbFlOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFlOfOrigin
			// 
			this.lbFlOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFlOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFlOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFlOfOrigin.Name = "lbFlOfOrigin";
			this.lbFlOfOrigin.TabIndex = 184;
			this.lbFlOfOrigin.Text = "FLOOR OF ORIGIN";
			this.frmBsmtorAttic = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmBsmtorAttic
			// 
			//this.frmBsmtorAttic.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmBsmtorAttic.Enabled = true;
			this.frmBsmtorAttic.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmBsmtorAttic.Name = "frmBsmtorAttic";
			this.frmBsmtorAttic.TabIndex = 183;
			this.frmBsmtorAttic.Visible = true;
			this.cboBurnDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBurnDamage
			// 
			this.cboBurnDamage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboBurnDamage.Enabled = true;
			this.cboBurnDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboBurnDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboBurnDamage.Name = "cboBurnDamage";
			this.cboBurnDamage.TabIndex = 68;
			this.cboBurnDamage.Text = " cboBurnDamage";
			this.cboBurnDamage.Visible = true;
			this.lstEquipInvolvIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstEquipInvolvIgnition
			// 
			this.lstEquipInvolvIgnition.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstEquipInvolvIgnition.Enabled = true;
			this.lstEquipInvolvIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstEquipInvolvIgnition.Name = "lstEquipInvolvIgnition";
			this.lstEquipInvolvIgnition.TabIndex = 71;
			this.lstEquipInvolvIgnition.Visible = true;
			this.lstEquipInvolvIgnition.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstItemContribFireSpread = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstItemContribFireSpread
			// 
			this.lstItemContribFireSpread.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstItemContribFireSpread.Enabled = true;
			this.lstItemContribFireSpread.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstItemContribFireSpread.Name = "lstItemContribFireSpread";
			this.lstItemContribFireSpread.TabIndex = 70;
			this.lstItemContribFireSpread.Visible = true;
			this.lstItemContribFireSpread.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSmokeDamage
			// 
			this.cboSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSmokeDamage.Enabled = true;
			this.cboSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSmokeDamage.Name = "cboSmokeDamage";
			this.cboSmokeDamage.TabIndex = 69;
			this.cboSmokeDamage.Text = " cboSmokeDamage";
			this.cboSmokeDamage.Visible = true;
			this.lbBurnDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBurnDamage
			// 
			this.lbBurnDamage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBurnDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBurnDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBurnDamage.Name = "lbBurnDamage";
			this.lbBurnDamage.TabIndex = 170;
			this.lbBurnDamage.Text = "BURN DAMAGE";
			this.lbSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSmokeDamage
			// 
			this.lbSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSmokeDamage.Name = "lbSmokeDamage";
			this.lbSmokeDamage.TabIndex = 145;
			this.lbSmokeDamage.Text = "SMOKE DAMAGE";
			this.lbEquipInvolvIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEquipInvolvIgnition
			// 
			this.lbEquipInvolvIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEquipInvolvIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEquipInvolvIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbEquipInvolvIgnition.Name = "lbEquipInvolvIgnition";
			this.lbEquipInvolvIgnition.TabIndex = 144;
			this.lbEquipInvolvIgnition.Text = "EQUIPMENT INVOLVED IN IGNITION";
			this.lbContribFireSpread = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFireSpread
			// 
			this.lbContribFireSpread.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContribFireSpread.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContribFireSpread.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbContribFireSpread.Name = "lbContribFireSpread";
			this.lbContribFireSpread.TabIndex = 143;
			this.lbContribFireSpread.Text = "ITEMS CONTRIBUTING TO FIRE SPREAD";
			this.cboAreaOfOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAreaOfOrigin
			// 
			this.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAreaOfOrigin.Enabled = true;
			this.cboAreaOfOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAreaOfOrigin.Name = "cboAreaOfOrigin";
			this.cboAreaOfOrigin.TabIndex = 53;
			this.cboAreaOfOrigin.Text = " cboAreaOfOrigin";
			this.cboAreaOfOrigin.Visible = true;
			this.cboHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboHeatSource
			// 
			this.cboHeatSource.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboHeatSource.Enabled = true;
			this.cboHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboHeatSource.Name = "cboHeatSource";
			this.cboHeatSource.TabIndex = 54;
			this.cboHeatSource.Text = " cboHeatSource";
			this.cboHeatSource.Visible = true;
			this.lstPhysicalContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPhysicalContribFactors
			// 
			this.lstPhysicalContribFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstPhysicalContribFactors.Enabled = true;
			this.lstPhysicalContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstPhysicalContribFactors.Name = "lstPhysicalContribFactors";
			this.lstPhysicalContribFactors.TabIndex = 58;
			this.lstPhysicalContribFactors.Visible = true;
			this.lstPhysicalContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstHumanContribFactors
			// 
			this.lstHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.lstHumanContribFactors.Enabled = true;
			this.lstHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstHumanContribFactors.Name = "lstHumanContribFactors";
			this.lstHumanContribFactors.TabIndex = 59;
			this.lstHumanContribFactors.Visible = true;
			this.lstHumanContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lbSpecCauseOfIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecCauseOfIgnition
			// 
			this.lbSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecCauseOfIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSpecCauseOfIgnition.Name = "lbSpecCauseOfIgnition";
			this.lbSpecCauseOfIgnition.TabIndex = 173;
			this.lbSpecCauseOfIgnition.Text = "SPECIFIC CAUSE OF IGNITION";
			this.lbGenCauseIgnition = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenCauseIgnition
			// 
			this.lbGenCauseIgnition.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenCauseIgnition.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbGenCauseIgnition.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbGenCauseIgnition.Name = "lbGenCauseIgnition";
			this.lbGenCauseIgnition.TabIndex = 172;
			this.lbGenCauseIgnition.Text = "GENERAL CAUSE OF IGNITION";
			this.lbSuppressFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSuppressFactors
			// 
			this.lbSuppressFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSuppressFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSuppressFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSuppressFactors.Name = "lbSuppressFactors";
			this.lbSuppressFactors.TabIndex = 171;
			this.lbSuppressFactors.Text = "SUPPRESSION FACTORS";
			this.lbFirstIgnited = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFirstIgnited
			// 
			this.lbFirstIgnited.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFirstIgnited.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFirstIgnited.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFirstIgnited.Name = "lbFirstIgnited";
			this.lbFirstIgnited.TabIndex = 169;
			this.lbFirstIgnited.Text = "FIRST ITEM IGNITED";
			this.lbHeatSource = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHeatSource
			// 
			this.lbHeatSource.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHeatSource.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHeatSource.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHeatSource.Name = "lbHeatSource";
			this.lbHeatSource.TabIndex = 117;
			this.lbHeatSource.Text = "HEAT SOURCE";
			this.lbAreaOrigin = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAreaOrigin
			// 
			this.lbAreaOrigin.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAreaOrigin.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAreaOrigin.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbAreaOrigin.Name = "lbAreaOrigin";
			this.lbAreaOrigin.TabIndex = 116;
			this.lbAreaOrigin.Text = "AREA OF ORIGIN";
			this.lbPhyContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPhyContribFactors
			// 
			this.lbPhyContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPhyContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPhyContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbPhyContribFactors.Name = "lbPhyContribFactors";
			this.lbPhyContribFactors.TabIndex = 115;
			this.lbPhyContribFactors.Text = "PHYSICAL CONTRIBUTING FACTORS";
			this.lbHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHumanContribFactors
			// 
			this.lbHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHumanContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHumanContribFactors.Name = "lbHumanContribFactors";
			this.lbHumanContribFactors.TabIndex = 114;
			this.lbHumanContribFactors.Text = "HUMAN CONTRIBUTING FACTORS";
			this._lbFrameTitle_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmFireInfo
            // 
            this.frmFireInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            //this.frmFireInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmFireInfo.Enabled = true;
			this.frmFireInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireInfo.Name = "frmFireInfo";
			this.frmFireInfo.TabIndex = 112;
			this.frmFireInfo.Visible = false;
			this.txtBusinessName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBusinessName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBusinessName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtBusinessName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtBusinessName.Name = "txtBusinessName";
			this.txtBusinessName.TabIndex = 189;
			this.txtZipcode = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtZipcode.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtZipcode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtZipcode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtZipcode.Name = "txtZipcode";
			this.txtZipcode.TabIndex = 197;
			this.txtZipcode.Text = "txtZipcode";

            // 
            // calBirthdate
            // 
            this.calBirthdate = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
            this.calBirthdate.AllowDrop = true;
            this.calBirthdate.MaxDate = DateTime.Now;
            this.calBirthdate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.calBirthdate.Name = "calBirthdate";
            this.calBirthdate.TabIndex = 199;

            this._optEthnicity_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optEthnicity_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optGender_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.txtWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWorkPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtWorkPhone.Name = "txtWorkPhone";
			this.txtWorkPhone.TabIndex = 206;
			this.txtWorkPhone.Text = "txtWorkPhone";
			this.txtHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHomePhone.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtHomePhone.Name = "txtHomePhone";
			this.txtHomePhone.TabIndex = 205;
			this.txtHomePhone.Text = "txtHomePhone";
			this.txtWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtWorkPlace.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtWorkPlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtWorkPlace.Name = "txtWorkPlace";
			this.txtWorkPlace.TabIndex = 207;
			this.txtWorkPlace.Text = "txtWorkPlace";
			this.txtHouseNumber = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtHouseNumber.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtHouseNumber.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtHouseNumber.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtHouseNumber.Name = "txtHouseNumber";
			this.txtHouseNumber.TabIndex = 190;
			this.txtHouseNumber.Text = "txtHouseNumber";
			this.txtStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStreetName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtStreetName.Name = "txtStreetName";
			this.txtStreetName.TabIndex = 192;
			this.txtStreetName.Text = "txtStreetName";
			this.cboPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPrefix
			// 
			this.cboPrefix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboPrefix.Enabled = true;
			this.cboPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboPrefix.Name = "cboPrefix";
			this.cboPrefix.TabIndex = 191;
			this.cboPrefix.Text = "cboPrefix";
			this.cboPrefix.Visible = true;
			this.cboStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboStreetType
			// 
			this.cboStreetType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboStreetType.Enabled = true;
			this.cboStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboStreetType.Name = "cboStreetType";
			this.cboStreetType.TabIndex = 193;
			this.cboStreetType.Text = "cboStreetType";
			this.cboStreetType.Visible = true;
			this.cboSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSuffix
			// 
			this.cboSuffix.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSuffix.Enabled = true;
			this.cboSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSuffix.Name = "cboSuffix";
			this.cboSuffix.TabIndex = 194;
			this.cboSuffix.Text = "cboSuffix";
			this.cboSuffix.Visible = true;
			this.txtCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtCity.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtCity.Name = "txtCity";
			this.txtCity.TabIndex = 195;
			this.txtCity.Text = "txtCity";
			this.cboState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboState
			// 
			this.cboState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboState.Enabled = true;
			this.cboState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboState.Name = "cboState";
			this.cboState.TabIndex = 196;
			this.cboState.Text = "cboState";
			this.cboState.Visible = true;
			this.txtFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFirstName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.TabIndex = 186;
			this.txtFirstName.Text = "txtFirstName";
			this.txtLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtLastName.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.TabIndex = 187;
			this.txtLastName.Text = "txtLastName";
			this.txtMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtMI.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtMI.Name = "txtMI";
			this.txtMI.TabIndex = 188;
			this.txtMI.Text = "txtMI";
			this.cboRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRole
			// 
			this.cboRole.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRole.Enabled = true;
			this.cboRole.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboRole.Name = "cboRole";
			this.cboRole.TabIndex = 198;
			this.cboRole.Text = "cboRole";
			this.cboRole.Visible = true;
			this.cboRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboRace
			// 
			this.cboRace.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboRace.Enabled = true;
			this.cboRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboRace.Name = "cboRace";
			this.cboRace.TabIndex = 202;
			this.cboRace.Text = "cboRace";
			this.cboRace.Visible = true;
			this.lbBusinessName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBusinessName
			// 
			this.lbBusinessName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBusinessName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBusinessName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBusinessName.Name = "lbBusinessName";
			this.lbBusinessName.TabIndex = 239;
			this.lbBusinessName.Text = "BUSINESS NAME";
			this.lblZipcode = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lblZipcode
			// 
			this.lblZipcode.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lblZipcode.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lblZipcode.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lblZipcode.Name = "lblZipcode";
			this.lblZipcode.TabIndex = 181;
			this.lblZipcode.Text = "ZIPCODE";
			this.lbMI = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMI
			// 
			this.lbMI.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMI.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMI.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbMI.Name = "lbMI";
			this.lbMI.TabIndex = 133;
			this.lbMI.Text = "M.I.";
			this.lbHouseNum = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHouseNum
			// 
			this.lbHouseNum.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHouseNum.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHouseNum.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHouseNum.Name = "lbHouseNum";
			this.lbHouseNum.TabIndex = 108;
			this.lbHouseNum.Text = "HOUSE#";
			this.lbPrefix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPrefix
			// 
			this.lbPrefix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPrefix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPrefix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbPrefix.Name = "lbPrefix";
			this.lbPrefix.TabIndex = 107;
			this.lbPrefix.Text = "PREFIX";
			this.lbStreetName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetName
			// 
			this.lbStreetName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStreetName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbStreetName.Name = "lbStreetName";
			this.lbStreetName.TabIndex = 106;
			this.lbStreetName.Text = "STREET NAME";
			this.lbStreetType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStreetType
			// 
			this.lbStreetType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStreetType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStreetType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbStreetType.Name = "lbStreetType";
			this.lbStreetType.TabIndex = 105;
			this.lbStreetType.Text = "TYPE";
			this.lbSuffix = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSuffix
			// 
			this.lbSuffix.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSuffix.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSuffix.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSuffix.Name = "lbSuffix";
			this.lbSuffix.TabIndex = 104;
			this.lbSuffix.Text = "SUFFIX";
			this.lbCity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCity
			// 
			this.lbCity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbCity.Name = "lbCity";
			this.lbCity.TabIndex = 103;
			this.lbCity.Text = "CITY";
			this.lbState = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbState
			// 
			this.lbState.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbState.Name = "lbState";
			this.lbState.TabIndex = 102;
			this.lbState.Text = "STATE";
			this.lbFirstName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFirstName
			// 
			this.lbFirstName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFirstName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFirstName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFirstName.Name = "lbFirstName";
			this.lbFirstName.TabIndex = 101;
			this.lbFirstName.Text = "FIRST NAME";
			this.lbLastName = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLastName
			// 
			this.lbLastName.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLastName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLastName.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbLastName.Name = "lbLastName";
			this.lbLastName.TabIndex = 100;
			this.lbLastName.Text = "LAST NAME";
			this.lbRole = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRole
			// 
			this.lbRole.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRole.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRole.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRole.Name = "lbRole";
			this.lbRole.TabIndex = 99;
			this.lbRole.Text = "ROLE";
			this.lbGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGender
			// 
			this.lbGender.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGender.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbGender.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbGender.Name = "lbGender";
			this.lbGender.TabIndex = 98;
			this.lbGender.Text = "GENDER";
			this.lbRace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbRace
			// 
			this.lbRace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbRace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbRace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbRace.Name = "lbRace";
			this.lbRace.TabIndex = 97;
			this.lbRace.Text = "RACE";
			this.lbEthnicity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEthnicity
			// 
			this.lbEthnicity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEthnicity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEthnicity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbEthnicity.Name = "lbEthnicity";
			this.lbEthnicity.TabIndex = 96;
			this.lbEthnicity.Text = "ETHNICITY";
			this.lbBirthdate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBirthdate
			// 
			this.lbBirthdate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBirthdate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBirthdate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBirthdate.Name = "lbBirthdate";
			this.lbBirthdate.TabIndex = 95;
			this.lbBirthdate.Text = "BIRTHDATE";
			this.lbHomePhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHomePhone
			// 
			this.lbHomePhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHomePhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHomePhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbHomePhone.Name = "lbHomePhone";
			this.lbHomePhone.TabIndex = 94;
			this.lbHomePhone.Text = "HOME PHONE";
			this.lbWorkPhone = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPhone
			// 
			this.lbWorkPhone.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPhone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWorkPhone.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbWorkPhone.Name = "lbWorkPhone";
			this.lbWorkPhone.TabIndex = 93;
			this.lbWorkPhone.Text = "WORK PHONE";
			this.lbWorkPlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbWorkPlace
			// 
			this.lbWorkPlace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbWorkPlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbWorkPlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbWorkPlace.Name = "lbWorkPlace";
			this.lbWorkPlace.TabIndex = 92;
			this.lbWorkPlace.Text = "WORK PLACE";
			this._lbFrameTitle_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();

            // 
            // frmName
            // 
            this.frmName = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
            //this.frmName.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmName.Enabled = true;
			this.frmName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmName.Name = "frmName";
			this.frmName.TabIndex = 89;
			this.frmName.Tag = "3";
			this.frmName.Visible = false;

            // 
            // cboLicenseState
            // 
            this.cboLicenseState = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboLicenseState.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboLicenseState.Enabled = true;
			this.cboLicenseState.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboLicenseState.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboLicenseState.Name = "cboLicenseState";
			this.cboLicenseState.TabIndex = 251;
			this.cboLicenseState.Text = "WA";
			this.cboLicenseState.Visible = true;

            // 
            // cboMobileMake
            // 
            this.cboMobileMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboMobileMake.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMobileMake.Enabled = true;
			this.cboMobileMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboMobileMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboMobileMake.Name = "cboMobileMake";
			this.cboMobileMake.TabIndex = 29;
			this.cboMobileMake.Text = " cboMobileMake";
			this.cboMobileMake.Visible = true;

			this.txtVehicleMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleMake.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtVehicleMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtVehicleMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtVehicleMake.Name = "txtVehicleMake";
			this.txtVehicleMake.TabIndex = 30;
			this.txtVehicleMake.Text = "txtVehicleMake";
			this.txtVehicleMake.Visible = true;

			this.txtVehicleYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleYear.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtVehicleYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtVehicleYear.Name = "txtVehicleYear";
			this.txtVehicleYear.TabIndex = 32;
			this.txtVehicleYear.Text = "txtVehicleYear";
			this.txtVehicleModel = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVehicleModel.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVehicleModel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtVehicleModel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtVehicleModel.Name = "txtVehicleModel";
			this.txtVehicleModel.TabIndex = 31;
			this.txtVehicleModel.Text = "txtVehicleModel";
			this.txtVIN = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVIN.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVIN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtVIN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtVIN.Name = "txtVIN";
			this.txtVIN.TabIndex = 33;
			this.txtVIN.Text = " txtVIN";
			this.lbLicenseSt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLicenseSt
			// 
			this.lbLicenseSt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLicenseSt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLicenseSt.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbLicenseSt.Name = "lbLicenseSt";
			this.lbLicenseSt.TabIndex = 250;
			this.lbLicenseSt.Text = "LICENSE STATE";

            // 
            // lbOtherMake
            // 
            this.lbOtherMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbOtherMake.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbOtherMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbOtherMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbOtherMake.Name = "lbOtherMake";
			this.lbOtherMake.TabIndex = 249;
			this.lbOtherMake.Text = "OTHER MAKE";
            this.lbOtherMake.Visible = true;

            // 
            // lbVIN
            // 
            this.lbVIN = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbVIN.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVIN.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVIN.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbVIN.Name = "lbVIN";
			this.lbVIN.TabIndex = 150;
			this.lbVIN.Text = "VIN #";
			this.lbVehicleMake = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleMake
			// 
			this.lbVehicleMake.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleMake.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVehicleMake.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbVehicleMake.Name = "lbVehicleMake";
			this.lbVehicleMake.TabIndex = 149;
			this.lbVehicleMake.Text = "MAKE";
			this.lbVehicleModel = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleModel
			// 
			this.lbVehicleModel.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleModel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVehicleModel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbVehicleModel.Name = "lbVehicleModel";
			this.lbVehicleModel.TabIndex = 148;
			this.lbVehicleModel.Text = "MODEL";
			this.lbVehicleYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVehicleYear
			// 
			this.lbVehicleYear.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVehicleYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVehicleYear.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbVehicleYear.Name = "lbVehicleYear";
			this.lbVehicleYear.TabIndex = 147;
			this.lbVehicleYear.Text = "YEAR";
			this.cboMobilePropType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboMobilePropType
			// 
			this.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboMobilePropType.Enabled = true;
			this.cboMobilePropType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboMobilePropType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboMobilePropType.Name = "cboMobilePropType";
			this.cboMobilePropType.TabIndex = 26;
			this.cboMobilePropType.Text = " cboMobilePropType";
			this.cboMobilePropType.Visible = true;
			this.txtVesselLength = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtVesselLength.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtVesselLength.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtVesselLength.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtVesselLength.Name = "txtVesselLength";
			this.txtVesselLength.TabIndex = 28;
			this.txtVesselLength.Text = "txtVesselLength";
			this.txtVesselLength.Visible = false;
			this.txtMobilePropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtMobilePropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtMobilePropValue.Name = "txtMobilePropValue";
			this.txtMobilePropValue.PromptChar = '_';
			this.txtMobilePropValue.TabIndex = 27;
			this.lbVYearMes = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVYearMes
			// 
			this.lbVYearMes.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVYearMes.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 16.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVYearMes.ForeColor = UpgradeHelpers.Helpers.Color.Red;
			this.lbVYearMes.Name = "lbVYearMes";
			this.lbVYearMes.TabIndex = 255;
			this.lbVYearMes.Text = "4 digit Year required If unknown make best guess";
			this.lbVYearMes.Visible = false;
			this.lbMobilePropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMobilePropValue
			// 
			this.lbMobilePropValue.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMobilePropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMobilePropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbMobilePropValue.Name = "lbMobilePropValue";
			this.lbMobilePropValue.TabIndex = 111;
			this.lbMobilePropValue.Text = "PROPERTY VALUE";
			this.lbMobilePropType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbMobilePropType
			// 
			this.lbMobilePropType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbMobilePropType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbMobilePropType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbMobilePropType.Name = "lbMobilePropType";
			this.lbMobilePropType.TabIndex = 110;
			this.lbMobilePropType.Text = "TYPE OF MOBILE PROPERTY";
			this.lbVesselLength = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbVesselLength
			// 
			this.lbVesselLength.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbVesselLength.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbVesselLength.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbVesselLength.Name = "lbVesselLength";
			this.lbVesselLength.TabIndex = 109;
			this.lbVesselLength.Text = "WATER VESSEL LENGTH";
			this.lbVesselLength.Visible = false;
			this._lbFrameTitle_8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmMobileProp = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmMobileProp
			// 
			//this.frmMobileProp.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmMobileProp.Enabled = true;
			this.frmMobileProp.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmMobileProp.Name = "frmMobileProp";
			this.frmMobileProp.TabIndex = 42;
			this.frmMobileProp.Tag = "8";
			this.frmMobileProp.Visible = false;
			this._lbFrameTitle_7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmNarration
			// 
			//this.frmNarration.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmNarration.Enabled = true;
			this.frmNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmNarration.Name = "frmNarration";
			this.frmNarration.TabIndex = 40;
			this.frmNarration.Tag = "7";
			this.frmNarration.Visible = false;
			this.txtJobsLost = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtJobsLost.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtJobsLost.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtJobsLost.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtJobsLost.Name = "txtJobsLost";
			this.txtJobsLost.TabIndex = 79;
			this.txtJobsLost.Text = "txtJobsLost";
			this.txtNoPeopleDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNoPeopleDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNoPeopleDisplaced.Name = "txtNoPeopleDisplaced";
			this.txtNoPeopleDisplaced.TabIndex = 78;
			this.txtNoPeopleDisplaced.Text = "txtNoPeopleDisplaced";
			this.txtNoBusinessDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNoBusinessDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNoBusinessDisplaced.Name = "txtNoBusinessDisplaced";
			this.txtNoBusinessDisplaced.TabIndex = 77;
			this.txtNoBusinessDisplaced.Text = "txtNoBusinessDisplaced";
			this.txtSqFtBurned = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtSqFtBurned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtSqFtBurned.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtSqFtBurned.Name = "txtSqFtBurned";
			this.txtSqFtBurned.PromptChar = '_';
			this.txtSqFtBurned.TabIndex = 75;
			this.txtSqFtSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtSqFtSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtSqFtSmokeDamage.Name = "txtSqFtSmokeDamage";
			this.txtSqFtSmokeDamage.PromptChar = '_';
			this.txtSqFtSmokeDamage.TabIndex = 76;
			this.lbSqFtSmokeDamage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSqFtSmokeDamage
			// 
			this.lbSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSqFtSmokeDamage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSqFtSmokeDamage.Name = "lbSqFtSmokeDamage";
			this.lbSqFtSmokeDamage.TabIndex = 180;
			this.lbSqFtSmokeDamage.Text = "SQ FT SMOKE DAMAGED";
			this.lbSqFtBurned = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSqFtBurned
			// 
			this.lbSqFtBurned.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSqFtBurned.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSqFtBurned.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSqFtBurned.Name = "lbSqFtBurned";
			this.lbSqFtBurned.TabIndex = 179;
			this.lbSqFtBurned.Text = "SQ FT BURNED";
			this.lbNoBusinessDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoBusinessDisplaced
			// 
			this.lbNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoBusinessDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNoBusinessDisplaced.Name = "lbNoBusinessDisplaced";
			this.lbNoBusinessDisplaced.TabIndex = 178;
			this.lbNoBusinessDisplaced.Text = "NUMBER OF BUSINESSES DISPLACED";
			this.lbNoPeopleDisplaced = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoPeopleDisplaced
			// 
			this.lbNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoPeopleDisplaced.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNoPeopleDisplaced.Name = "lbNoPeopleDisplaced";
			this.lbNoPeopleDisplaced.TabIndex = 177;
			this.lbNoPeopleDisplaced.Text = "NUMBER OF PEOPLE DISPLACED";
			this.lbJobsLost = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbJobsLost
			// 
			this.lbJobsLost.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbJobsLost.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbJobsLost.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbJobsLost.Name = "lbJobsLost";
			this.lbJobsLost.TabIndex = 176;
			this.lbJobsLost.Text = "JOBS LOST";
			this.frmPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmPropLoss
			// 
			//this.frmPropLoss.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmPropLoss.Enabled = true;
			this.frmPropLoss.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmPropLoss.Name = "frmPropLoss";
			this.frmPropLoss.TabIndex = 175;
			this.frmPropLoss.Visible = true;
			this.txtPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtPropLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtPropLoss.Name = "txtPropLoss";
			this.txtPropLoss.PromptChar = '_';
			this.txtPropLoss.TabIndex = 80;
			this.txtContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtContentLoss.Name = "txtContentLoss";
			this.txtContentLoss.PromptChar = '_';
			this.txtContentLoss.TabIndex = 81;
			this.lbContentLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContentLoss
			// 
			this.lbContentLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContentLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContentLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbContentLoss.Name = "lbContentLoss";
			this.lbContentLoss.TabIndex = 126;
			this.lbContentLoss.Text = "CONTENT LOSS";
			this.lbPropLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPropLoss
			// 
			this.lbPropLoss.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPropLoss.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPropLoss.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbPropLoss.Name = "lbPropLoss";
			this.lbPropLoss.TabIndex = 125;
			this.lbPropLoss.Text = "PROPERTY LOSS";
			this._lbFrameTitle_6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmLoss = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmLoss
			// 
			//this.frmLoss.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmLoss.Enabled = true;
			this.frmLoss.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmLoss.Name = "frmLoss";
			this.frmLoss.TabIndex = 38;
			this.frmLoss.Tag = "6";
			this.frmLoss.Visible = false;
			this.txtNumberExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberExposures.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.txtNumberExposures.Name = "txtNumberExposures";
			this.txtNumberExposures.TabIndex = 247;
			this.txtNumberExposures.Visible = false;
			this._optType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optType_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lbFireType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireType
			// 
			this.lbFireType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFireType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireType.Name = "lbFireType";
			this.lbFireType.TabIndex = 217;
			this.lbFireType.Text = "SELECT FIRE TYPE";
			this.lbNumExp = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNumExp
			// 
			this.lbNumExp.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNumExp.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNumExp.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNumExp.Name = "lbNumExp";
			this.lbNumExp.TabIndex = 248;
			this.lbNumExp.Text = "# OF EXPOSURES";
			this.lbNumExp.Visible = false;
			this._imgMain_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			this._lbFrameTitle_5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmFireType = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFireType
			// 
			//this.frmFireType.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmFireType.Enabled = true;
			this.frmFireType.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireType.Name = "frmFireType";
			this.frmFireType.TabIndex = 36;
			this.frmFireType.Tag = "5";
			this.frmFireType.Visible = false;
			this.txtBasementLevels = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtBasementLevels.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBasementLevels.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.txtBasementLevels.Name = "txtBasementLevels";
			this.txtBasementLevels.TabIndex = 7;
			this.txtPropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtPropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtPropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtPropValue.Name = "txtPropValue";
			this.txtPropValue.PromptChar = '_';
			this.txtPropValue.TabIndex = 11;
			this._optExtinguish_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optExtinguish_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstExtFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstExtFailure
			// 
			this.lstExtFailure.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstExtFailure.Enabled = false;
			this.lstExtFailure.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstExtFailure.Name = "lstExtFailure";
			this.lstExtFailure.TabIndex = 25;
			this.lstExtFailure.Visible = true;
			this.lstExtFailure.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;

            // 
            // cboExtEffectiveness
            // 
            this.cboExtEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboExtEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboExtEffectiveness.Enabled = true;
			this.cboExtEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboExtEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboExtEffectiveness.Name = "cboExtEffectiveness";
			this.cboExtEffectiveness.TabIndex = 24;
			this.cboExtEffectiveness.Text = " cboExtEffectiveness";
			this.cboExtEffectiveness.Visible = false;
			this.cboSysType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSysType
			// 
			this.cboSysType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSysType.Enabled = true;
			this.cboSysType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSysType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSysType.Name = "cboSysType";
			this.cboSysType.TabIndex = 23;
			this.cboSysType.Text = " cboSysType";
			this.cboSysType.Visible = false;
			this.lbExtProblems = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExtProblems
			// 
			//this.lbExtProblems.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.lbExtProblems.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExtProblems.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbExtProblems.Name = "lbExtProblems";
			this.lbExtProblems.TabIndex = 168;
			this.lbExtProblems.Text = "PROBLEMS";
			this.lbExtEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExtEffectiveness
			// 
			this.lbExtEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExtEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExtEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbExtEffectiveness.Name = "lbExtEffectiveness";
			this.lbExtEffectiveness.TabIndex = 141;
			this.lbExtEffectiveness.Text = "EFFECTIVENESS";
			this.lbExtSysType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbExtSysType
			// 
			this.lbExtSysType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbExtSysType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbExtSysType.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbExtSysType.Name = "lbExtSysType";
			this.lbExtSysType.TabIndex = 140;
			this.lbExtSysType.Text = "SYSTEM TYPE";
			this._optAlarmType_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optAlarmType_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optAlarmType_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.lstAlarmFailure = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstAlarmFailure
			// 
			this.lstAlarmFailure.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstAlarmFailure.Enabled = true;
			this.lstAlarmFailure.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lstAlarmFailure.Name = "lstAlarmFailure";
			this.lstAlarmFailure.TabIndex = 19;
			this.lstAlarmFailure.Visible = false;
			this.lstAlarmFailure.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboInitiatingDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInitiatingDevice
			// 
			this.cboInitiatingDevice.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboInitiatingDevice.Enabled = true;
			this.cboInitiatingDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInitiatingDevice.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboInitiatingDevice.Name = "cboInitiatingDevice";
			this.cboInitiatingDevice.TabIndex = 17;
			this.cboInitiatingDevice.Text = " cboInitiatingDevice";
			this.cboInitiatingDevice.Visible = false;

            // 
            // cboEffectiveness
            // 
            this.cboEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboEffectiveness.Enabled = true;
			this.cboEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboEffectiveness.Name = "cboEffectiveness";
			this.cboEffectiveness.TabIndex = 18;
			this.cboEffectiveness.Text = " cboEffectiveness";
			this.cboEffectiveness.Visible = false;

            // 
            // cboAlarmType
            // 
            this.cboAlarmType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboAlarmType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboAlarmType.Enabled = true;
			this.cboAlarmType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAlarmType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAlarmType.Name = "cboAlarmType";
			this.cboAlarmType.TabIndex = 16;
			this.cboAlarmType.Text = " cboAlarmType";
			this.cboAlarmType.Visible = true;

            // 
            // lbAlarmProblems
            // 
            this.lbAlarmProblems = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
            this.lbAlarmProblems.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAlarmProblems.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAlarmProblems.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbAlarmProblems.Name = "lbAlarmProblems";
			this.lbAlarmProblems.TabIndex = 138;
			this.lbAlarmProblems.Text = "PROBLEMS";
			this.lbAlarmProblems.Visible = false;
			this.lbInitiatingDevice = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInitiatingDevice
			// 
			this.lbInitiatingDevice.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInitiatingDevice.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbInitiatingDevice.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbInitiatingDevice.Name = "lbInitiatingDevice";
			this.lbInitiatingDevice.TabIndex = 137;
			this.lbInitiatingDevice.Text = "INITIATING DEVICE";
			this.lbInitiatingDevice.Visible = false;
			this.lbEffectiveness = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEffectiveness
			// 
			this.lbEffectiveness.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEffectiveness.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEffectiveness.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbEffectiveness.Name = "lbEffectiveness";
			this.lbEffectiveness.TabIndex = 136;
			this.lbEffectiveness.Text = "EFFECTIVENESS";
			this.lbSystemType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSystemType
			// 
			this.lbSystemType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSystemType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSystemType.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.lbSystemType.Name = "lbSystemType";
			this.lbSystemType.TabIndex = 135;
			this.lbSystemType.Text = "SYSTEM TYPE";

            // 
            // cboGeneralPropertyUse
            // 
            this.cboGeneralPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboGeneralPropertyUse.Enabled = true;
			this.cboGeneralPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboGeneralPropertyUse.Name = "cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.TabIndex = 0;
			this.cboGeneralPropertyUse.Text = " cboGeneralPropertyUse";
			this.cboGeneralPropertyUse.Visible = true;

            // 
            // cboSpecificPropertyUse
            // 
            this.cboSpecificPropertyUse = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
            this.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboSpecificPropertyUse.Enabled = true;
			this.cboSpecificPropertyUse.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboSpecificPropertyUse.Name = "cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.TabIndex = 1;
			this.cboSpecificPropertyUse.Text = " cboSpecificPropertyUse";
			this.cboSpecificPropertyUse.Visible = true;
			this.cboBuildingStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBuildingStatus
			// 
			this.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboBuildingStatus.Enabled = true;
			this.cboBuildingStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboBuildingStatus.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboBuildingStatus.Name = "cboBuildingStatus";
			this.cboBuildingStatus.TabIndex = 2;
			this.cboBuildingStatus.Text = " cboBuildingStatus";
			this.cboBuildingStatus.Visible = true;
			this.cboConstructionType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboConstructionType
			// 
			this.cboConstructionType.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.cboConstructionType.Enabled = true;
			this.cboConstructionType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboConstructionType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboConstructionType.Name = "cboConstructionType";
			this.cboConstructionType.TabIndex = 3;
			this.cboConstructionType.Text = " cboConstructionType";
			this.cboConstructionType.Visible = true;
			this.txtNumberOfBusinesses = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfBusinesses.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfBusinesses.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNumberOfBusinesses.Name = "txtNumberOfBusinesses";
			this.txtNumberOfBusinesses.TabIndex = 10;
			this.txtNumberOfBusinesses.Text = "txtNumberOfBusinesses";
			this.txtNumberOfOccupants = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfOccupants.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfOccupants.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNumberOfOccupants.Name = "txtNumberOfOccupants";
			this.txtNumberOfOccupants.TabIndex = 9;
			this.txtNumberOfOccupants.Text = "txtNumberOfOccupied";
			this.txtNumberOfUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfUnits.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNumberOfUnits.Name = "txtNumberOfUnits";
			this.txtNumberOfUnits.TabIndex = 8;
			this.txtNumberOfUnits.Text = "txtNumberOfUnits";
			this.txtNumberOfStories = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberOfStories.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.txtNumberOfStories.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtNumberOfStories.Name = "txtNumberOfStories";
			this.txtNumberOfStories.TabIndex = 6;
			this.txtNumberOfStories.Text = "txtNumberOfStories";
			this.txtTotalSqFootage = ctx.Resolve<UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel>();
			this.txtTotalSqFootage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtTotalSqFootage.Name = "txtTotalSqFootage";
			this.txtTotalSqFootage.PromptChar = '_';
			this.txtTotalSqFootage.TabIndex = 5;
			this.lbBasementLevel = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBasementLevel
			// 
			this.lbBasementLevel.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBasementLevel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBasementLevel.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBasementLevel.Name = "lbBasementLevel";
			this.lbBasementLevel.TabIndex = 252;
			this.lbBasementLevel.Text = "BASEMENT LEVELS";
			this.lbNumberOfUnits = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNumberOfUnits
			// 
			this.lbNumberOfUnits.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNumberOfUnits.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNumberOfUnits.Name = "lbNumberOfUnits";
			this.lbNumberOfUnits.TabIndex = 132;
			this.lbNumberOfUnits.Text = "NUMBER OF UNITS/SUITES ";
			this.lbGenOccupancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbGenOccupancy
			// 
			this.lbGenOccupancy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbGenOccupancy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbGenOccupancy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbGenOccupancy.Name = "lbGenOccupancy";
			this.lbGenOccupancy.TabIndex = 87;
			this.lbGenOccupancy.Text = "GENERAL OCCUPANCY";
			this.lbSpecificOccupancy = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSpecificOccupancy
			// 
			this.lbSpecificOccupancy.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSpecificOccupancy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSpecificOccupancy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbSpecificOccupancy.Name = "lbSpecificOccupancy";
			this.lbSpecificOccupancy.TabIndex = 86;
			this.lbSpecificOccupancy.Text = "SPECIFIC OCCUPANCY";
			this.lbBldgStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbBldgStatus
			// 
			this.lbBldgStatus.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbBldgStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbBldgStatus.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbBldgStatus.Name = "lbBldgStatus";
			this.lbBldgStatus.TabIndex = 85;
			this.lbBldgStatus.Text = "BUILDING STATUS";
			this.lbConstructionType = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbConstructionType
			// 
			this.lbConstructionType.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbConstructionType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbConstructionType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbConstructionType.Name = "lbConstructionType";
			this.lbConstructionType.TabIndex = 84;
			this.lbConstructionType.Text = "CONSTRUCTION TYPE";
			this.lbTotSqFt = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTotSqFt
			// 
			this.lbTotSqFt.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbTotSqFt.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbTotSqFt.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbTotSqFt.Name = "lbTotSqFt";
			this.lbTotSqFt.TabIndex = 83;
			this.lbTotSqFt.Text = "TOTAL SQ. FOOTAGE";
			this.lbNoStories = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoStories
			// 
			this.lbNoStories.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoStories.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNoStories.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNoStories.Name = "lbNoStories";
			this.lbNoStories.TabIndex = 82;
			this.lbNoStories.Text = "STORIES";
			this.lbNoOccupants = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoOccupants
			// 
			this.lbNoOccupants.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoOccupants.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNoOccupants.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNoOccupants.Name = "lbNoOccupants";
			this.lbNoOccupants.TabIndex = 74;
			this.lbNoOccupants.Text = "NUMBER OF OCCUPANTS ";
			this.lbNoBusinesses = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNoBusinesses
			// 
			this.lbNoBusinesses.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNoBusinesses.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNoBusinesses.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbNoBusinesses.Name = "lbNoBusinesses";
			this.lbNoBusinesses.TabIndex = 73;
			this.lbNoBusinesses.Text = "NUMBER OF BUSINESSES ";
			this.lbPropValue = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbPropValue
			// 
			this.lbPropValue.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbPropValue.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbPropValue.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbPropValue.Name = "lbPropValue";
			this.lbPropValue.TabIndex = 72;
			this.lbPropValue.Text = "PROPERTY VALUE";
			this._lbFrameTitle_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.frmBldgInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmBldgInfo
			// 
			//this.frmBldgInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmBldgInfo.Enabled = true;
			this.frmBldgInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmBldgInfo.Name = "frmBldgInfo";
			this.frmBldgInfo.TabIndex = 34;
			this.frmBldgInfo.Tag = "4";
			this.frmBldgInfo.Visible = false;
			this.lbFireUnit = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireUnit
			// 
			this.lbFireUnit.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireUnit.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireUnit.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbFireUnit.Name = "lbFireUnit";
			this.lbFireUnit.TabIndex = 131;
			this.lbFireUnit.Text = "E2";
			this.lbFireIncNo = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireIncNo
			// 
			this.lbFireIncNo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireIncNo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireIncNo.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbFireIncNo.Name = "lbFireIncNo";
			this.lbFireIncNo.TabIndex = 130;
			this.lbFireIncNo.Text = "T002310042";
			this.lbFireIncTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireIncTitle
			// 
			this.lbFireIncTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireIncTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireIncTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbFireIncTitle.Name = "lbFireIncTitle";
			this.lbFireIncTitle.TabIndex = 129;
			this.lbFireIncTitle.Text = "Incident #: ";
			this.lbFireLocationTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireLocationTitle
			// 
			this.lbFireLocationTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireLocationTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireLocationTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.lbFireLocationTitle.Name = "lbFireLocationTitle";
			this.lbFireLocationTitle.TabIndex = 128;
			this.lbFireLocationTitle.Text = "Location:";
			this.lbFireLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFireLocation
			// 
			this.lbFireLocation.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.lbFireLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFireLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbFireLocation.Name = "lbFireLocation";
			this.lbFireLocation.TabIndex = 127;
			this.lbFireLocation.Text = "901 Fawcett Av, TAC";
			this.LbUnitTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// LbUnitTitle
			// 
			this.LbUnitTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.LbUnitTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.LbUnitTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.LbUnitTitle.Name = "LbUnitTitle";
			this.LbUnitTitle.TabIndex = 45;
			this.LbUnitTitle.Text = "Unit:";
			this._NavButton_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._NavButton_4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdSave = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSave
			// 
			this.cmdSave.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSave.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSave.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 156;
			this.cmdSave.Text = "Save Report as Complete";
			this.cmdSaveIncomplete = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdSaveIncomplete
			// 
			this.cmdSaveIncomplete.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdSaveIncomplete.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdSaveIncomplete.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdSaveIncomplete.Name = "cmdSaveIncomplete";
			this.cmdSaveIncomplete.TabIndex = 155;
			this.cmdSaveIncomplete.Text = "Save Report as Incomplete";
			this.cmdAbandon = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAbandon
			// 
			this.cmdAbandon.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAbandon.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAbandon.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAbandon.Name = "cmdAbandon";
			this.cmdAbandon.TabIndex = 154;
			this.cmdAbandon.Text = "Exit WITHOUT Saving Report";
			this._optFloor_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._optFloor_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this._optFloor_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.cmdAddNewName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNewName
			// 
			this.cmdAddNewName.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNewName.Enabled = false;
			this.cmdAddNewName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddNewName.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNewName.Name = "cmdAddNewName";
			this.cmdAddNewName.TabIndex = 208;
			this.cmdAddNewName.Tag = "1";
			this.cmdAddNewName.Text = "More Names...";

            // 
            // cmdAddNames
            // 
            this.cmdAddNames = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
            this.cmdAddNames.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNames.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddNames.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNames.Name = "cmdAddNames";
			this.cmdAddNames.TabIndex = 88;
			this.cmdAddNames.Text = "NAMES";


            // 
            // rtxNarration
            // 
            this.rtxNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
            this.rtxNarration.BackColor = UpgradeHelpers.Helpers.Color.White;
			this.rtxNarration.Name = "rtxNarration";
			this.rtxNarration.TabIndex = 91;
			this.chkExposures = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			//this.chkExposures.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.chkExposures.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkExposures.Enabled = true;
			this.chkExposures.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkExposures.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.chkExposures.Name = "chkExposures";
			this.chkExposures.TabIndex = 245;
			this.chkExposures.Text = "STRUCTURE EXPOSURES?";
			this.chkExposures.Visible = false;
			this.chkAddressCorrection = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			//this.chkAddressCorrection.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAddressCorrection.Enabled = true;
			this.chkAddressCorrection.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAddressCorrection.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.chkAddressCorrection.Name = "chkAddressCorrection";
			this.chkAddressCorrection.TabIndex = 218;
			this.chkAddressCorrection.Text = "Address Correction Needed";
			this.chkAddressCorrection.Visible = false;

			this.chkAlarmOperated = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkAlarmOperated.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkAlarmOperated.Enabled = false;
			this.chkAlarmOperated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkAlarmOperated.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.chkAlarmOperated.Name = "chkAlarmOperated";
			this.chkAlarmOperated.TabIndex = 15;
			this.chkAlarmOperated.Text = "DETECTOR/ALARM OPERATED";
			this.chkAlarmOperated.Visible = true;
			this.Text = "TFD Incident Reporting System - Report Entry Wizard";
			this.CurrReport = 0;
			this.CurrIncident = 0;
			optType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(5);
			optType[0] = _optType_0;
			optType[1] = _optType_1;
			optType[2] = _optType_2;
			optType[3] = _optType_3;
			optType[4] = _optType_4;
			//optType[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optType[0].Checked = false;
			optType[0].Enabled = true;
			optType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optType[0].Name = "_optType_0";
			optType[0].TabIndex = 212;
			optType[0].Text = "STRUCTURE";
			optType[0].Visible = true;
			//optType[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optType[1].Checked = false;
			optType[1].Enabled = true;
			optType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optType[1].Name = "_optType_1";
			optType[1].TabIndex = 213;
			optType[1].Text = "MOBILE";
			optType[1].Visible = true;
			//optType[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optType[2].Checked = false;
			optType[2].Enabled = true;
			optType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optType[2].Name = "_optType_2";
			optType[2].TabIndex = 214;
			optType[2].Text = "BRUSH/GRASS/TREES";
			optType[2].Visible = true;
			//optType[3].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optType[3].Checked = false;
			optType[3].Enabled = true;
			optType[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optType[3].Name = "_optType_3";
			optType[3].TabIndex = 215;
			optType[3].Text = "DUMPSTER";
			optType[3].Visible = true;
			//optType[4].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optType[4].Checked = false;
			optType[4].Enabled = true;
			optType[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optType[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optType[4].Name = "_optType_4";
			optType[4].TabIndex = 216;
			optType[4].Text = "OTHER OUTSIDE FIRE";
			optType[4].Visible = true;
			this.FireReportID = 0;
			optHFGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optHFGender[1] = _optHFGender_1;
			optHFGender[0] = _optHFGender_0;
			optHFGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(181, 189, 100);
			optHFGender[1].Checked = false;
			optHFGender[1].Enabled = true;
			optHFGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optHFGender[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optHFGender[1].Name = "_optHFGender_1";
			optHFGender[1].TabIndex = 61;
			optHFGender[1].Text = "FEMALE";
			optHFGender[1].Visible = true;
			optHFGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(181, 189, 100);
			optHFGender[0].Checked = true;
			optHFGender[0].Enabled = true;
			optHFGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optHFGender[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optHFGender[0].Name = "_optHFGender_0";
			optHFGender[0].TabIndex = 60;
			optHFGender[0].Text = "MALE";
			optHFGender[0].Visible = true;
			optFloor = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>>(3);
			optFloor[0] = _optFloor_0;
			optFloor[1] = _optFloor_1;
			optFloor[2] = _optFloor_2;
			//optFloor[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			optFloor[0].Enabled = true;
			optFloor[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optFloor[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optFloor[0].Name = "_optFloor_0";
			optFloor[0].TabIndex = 65;
			optFloor[0].Text = "BASEMENT";
			optFloor[0].Visible = true;
			//optFloor[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			optFloor[1].Enabled = true;
			optFloor[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optFloor[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optFloor[1].Name = "_optFloor_1";
			optFloor[1].TabIndex = 66;
			optFloor[1].Text = "ATTIC";
			optFloor[1].Visible = true;
			//optFloor[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			optFloor[2].Enabled = true;
			optFloor[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optFloor[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optFloor[2].Name = "_optFloor_2";
			optFloor[2].TabIndex = 67;
			optFloor[2].Text = "ROOF";
			optFloor[2].Visible = true;
			optAlarmType = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(3);
			optAlarmType[0] = _optAlarmType_0;
			optAlarmType[1] = _optAlarmType_1;
			optAlarmType[2] = _optAlarmType_2;
			//optAlarmType[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optAlarmType[0].Checked = true;
			optAlarmType[0].Enabled = true;
			optAlarmType[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optAlarmType[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optAlarmType[0].Name = "_optAlarmType_0";
			optAlarmType[0].TabIndex = 12;
			optAlarmType[0].Text = "NO ALARM INVOLVED";
			optAlarmType[0].Visible = true;
			//optAlarmType[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optAlarmType[1].Checked = false;
			optAlarmType[1].Enabled = true;
			optAlarmType[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optAlarmType[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optAlarmType[1].Name = "_optAlarmType_1";
			optAlarmType[1].TabIndex = 13;
			optAlarmType[1].Text = "UNIT DETECTORS ONLY (RESIDENTIAL)";
			optAlarmType[1].Visible = true;
			//optAlarmType[2].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optAlarmType[2].Checked = false;
			optAlarmType[2].Enabled = true;
			optAlarmType[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optAlarmType[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optAlarmType[2].Name = "_optAlarmType_2";
			optAlarmType[2].TabIndex = 14;
			optAlarmType[2].Text = "ALARM SYSTEM";
			optAlarmType[2].Visible = true;
			optExtinguish = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optExtinguish[1] = _optExtinguish_1;
			optExtinguish[0] = _optExtinguish_0;
			//optExtinguish[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optExtinguish[1].Checked = false;
			optExtinguish[1].Enabled = true;
			optExtinguish[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optExtinguish[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optExtinguish[1].Name = "_optExtinguish_1";
			optExtinguish[1].TabIndex = 21;
			optExtinguish[1].Text = "EXTINGUISHING SYSTEM INVOLVED";
			optExtinguish[1].Visible = true;
			//optExtinguish[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optExtinguish[0].Checked = true;
			optExtinguish[0].Enabled = true;
			optExtinguish[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optExtinguish[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optExtinguish[0].Name = "_optExtinguish_0";
			optExtinguish[0].TabIndex = 20;
			optExtinguish[0].Text = "NO EXTINGUISHING SYSTEM INVOLVED";
			optExtinguish[0].Visible = true;
			this.chkExtOperated = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			//this.chkExtOperated.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.chkExtOperated.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkExtOperated.Enabled = false;
			this.chkExtOperated.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkExtOperated.ForeColor = UpgradeHelpers.Helpers.Color.Gray;
			this.chkExtOperated.Name = "chkExtOperated";
			this.chkExtOperated.TabIndex = 22;
			this.chkExtOperated.Text = "EXTINGUISHING SYSTEM OPERATED";
			this.chkExtOperated.Visible = true;
			this.chkRental = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			//this.chkRental.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.chkRental.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkRental.Enabled = true;
			this.chkRental.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkRental.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.chkRental.Name = "chkRental";
			this.chkRental.TabIndex = 4;
			this.chkRental.Text = "RENTAL?";
			this.chkRental.Visible = true;
			this.ExposureOccured = 0;
			this.NameUpdated = 0;
			this.ADDRESSCORRECTION = 0;
			this.CurrUnit = "";
			this.RuptureReportID = 0;
			optGender = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optGender[1] = _optGender_1;
			optGender[0] = _optGender_0;
			//optGender[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optGender[1].Checked = false;
			optGender[1].Enabled = true;
			optGender[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optGender[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optGender[1].Name = "_optGender_1";
			optGender[1].TabIndex = 201;
			optGender[1].Text = "FEMALE";
			optGender[1].Visible = true;
			//optGender[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optGender[0].Checked = false;
			optGender[0].Enabled = true;
			optGender[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optGender[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optGender[0].Name = "_optGender_0";
			optGender[0].TabIndex = 200;
			optGender[0].Text = "MALE";
			optGender[0].Visible = true;
			optEthnicity = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optEthnicity[1] = _optEthnicity_1;
			optEthnicity[0] = _optEthnicity_0;
			//optEthnicity[1].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optEthnicity[1].Checked = false;
			optEthnicity[1].Enabled = true;
			optEthnicity[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optEthnicity[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optEthnicity[1].Name = "_optEthnicity_1";
			optEthnicity[1].TabIndex = 204;
			optEthnicity[1].Text = "NON-HISPANIC";
			optEthnicity[1].Visible = true;
			//optEthnicity[0].BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			optEthnicity[0].Checked = false;
			optEthnicity[0].Enabled = true;
			optEthnicity[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			optEthnicity[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			optEthnicity[0].Name = "_optEthnicity_0";
			optEthnicity[0].TabIndex = 203;
			optEthnicity[0].Text = "HISPANIC";
			optEthnicity[0].Visible = true;
			this.FirstTime = 0;
			this.HumansAFactor = 0;

            // 
            // frmFireOnly
            // 
            this.frmFireOnly = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            //this.frmFireOnly.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmFireOnly.Enabled = true;
			this.frmFireOnly.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFireOnly.Name = "frmFireOnly";
			this.frmFireOnly.TabIndex = 142;
			this.frmFireOnly.Visible = true;
			this.CurrFrame = null;
			lbFrameTitle = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(10);
			lbFrameTitle[9] = _lbFrameTitle_9;
			lbFrameTitle[2] = _lbFrameTitle_2;
			lbFrameTitle[1] = _lbFrameTitle_1;
			lbFrameTitle[0] = _lbFrameTitle_0;
			lbFrameTitle[3] = _lbFrameTitle_3;
			lbFrameTitle[8] = _lbFrameTitle_8;
			lbFrameTitle[7] = _lbFrameTitle_7;
			lbFrameTitle[6] = _lbFrameTitle_6;
			lbFrameTitle[5] = _lbFrameTitle_5;
			lbFrameTitle[4] = _lbFrameTitle_4;
			lbFrameTitle[9].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[9].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[9].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[9].Name = "_lbFrameTitle_9";
			lbFrameTitle[9].TabIndex = 220;
			lbFrameTitle[9].Text = "FIRE - ADDRESS CORRECTION";
			lbFrameTitle[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[2].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[2].Name = "_lbFrameTitle_2";
			lbFrameTitle[2].TabIndex = 165;
			lbFrameTitle[2].Tag = "2";
			lbFrameTitle[2].Text = "FIRE REPORT STATUS";
			lbFrameTitle[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[1].Name = "_lbFrameTitle_1";
			lbFrameTitle[1].TabIndex = 119;
			lbFrameTitle[1].Tag = "1";
			lbFrameTitle[1].Text = "OUTSIDE FIRE";
			lbFrameTitle[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[0].Name = "_lbFrameTitle_0";
			lbFrameTitle[0].TabIndex = 113;
			lbFrameTitle[0].Text = "FIRE INFORMATION";
			lbFrameTitle[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[3].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[3].Name = "_lbFrameTitle_3";
			lbFrameTitle[3].TabIndex = 90;
			lbFrameTitle[3].Text = "NAMES";
			lbFrameTitle[8].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[8].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[8].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[8].Name = "_lbFrameTitle_8";
			lbFrameTitle[8].TabIndex = 43;
			lbFrameTitle[8].Text = "MOBILE PROPERTY INFORMATION";
			lbFrameTitle[7].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[7].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[7].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[7].Name = "_lbFrameTitle_7";
			lbFrameTitle[7].TabIndex = 41;
			lbFrameTitle[7].Text = "NARRATION";
			lbFrameTitle[6].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[6].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[6].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[6].Name = "_lbFrameTitle_6";
			lbFrameTitle[6].TabIndex = 39;
			lbFrameTitle[6].Text = "FIRE LOSS";
			lbFrameTitle[5].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[5].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[5].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[5].Name = "_lbFrameTitle_5";
			lbFrameTitle[5].TabIndex = 37;
			lbFrameTitle[5].Text = "FIRE TYPE";
			lbFrameTitle[4].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			lbFrameTitle[4].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			lbFrameTitle[4].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			lbFrameTitle[4].Name = "_lbFrameTitle_4";
			lbFrameTitle[4].TabIndex = 35;
			lbFrameTitle[4].Text = "BUILDING INFORMATION";
			NavButton = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(5);
			NavButton[0] = _NavButton_0;
			NavButton[1] = _NavButton_1;
			NavButton[2] = _NavButton_2;
			NavButton[3] = _NavButton_3;
			NavButton[4] = _NavButton_4;
			NavButton[0].Name = "_NavButton_0";
			NavButton[0].TabIndex = 240;
			NavButton[1].Name = "_NavButton_1";
			NavButton[1].TabIndex = 241;
			NavButton[2].Name = "_NavButton_2";
			NavButton[2].TabIndex = 242;
			NavButton[3].Name = "_NavButton_3";
			NavButton[3].TabIndex = 243;
			NavButton[4].Name = "_NavButton_4";
			NavButton[4].TabIndex = 244;
			this.ReportStarted = 0;

            // 
            // Frame1
            // 
            this.Frame1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            //this.Frame1.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.Frame1.Name = "Frame1";
			this.Frame1.TabIndex = 211;
			this.Frame1.Visible = true;

            // 
            // frmAlarmInfo
            // 
            this.frmAlarmInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            // this.frmAlarmInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmAlarmInfo.Enabled = true;
			this.frmAlarmInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmAlarmInfo.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.frmAlarmInfo.Name = "frmAlarmInfo";
			this.frmAlarmInfo.TabIndex = 134;
			this.frmAlarmInfo.Visible = true;

            // 
            // frmExtinguishingSysInfo
            // 
            this.frmExtinguishingSysInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            //this.frmExtinguishingSysInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmExtinguishingSysInfo.Enabled = true;
			this.frmExtinguishingSysInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmExtinguishingSysInfo.ForeColor = UpgradeHelpers.Helpers.Color.Black;
			this.frmExtinguishingSysInfo.Name = "frmExtinguishingSysInfo";
			this.frmExtinguishingSysInfo.TabIndex = 139;
			this.frmExtinguishingSysInfo.Visible = true;

            // 
            // frmPassengerVehicleInfo
            // 
            this.frmPassengerVehicleInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
            //this.frmPassengerVehicleInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
            this.frmPassengerVehicleInfo.Enabled = true;
			this.frmPassengerVehicleInfo.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmPassengerVehicleInfo.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.frmPassengerVehicleInfo.Name = "frmPassengerVehicleInfo";
			this.frmPassengerVehicleInfo.TabIndex = 146;
			this.frmPassengerVehicleInfo.Text = " Vehicle Information";
			this.frmPassengerVehicleInfo.Visible = true;
			this.frmGender = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmGender
			// 
			//this.frmGender.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmGender.Enabled = true;
			this.frmGender.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmGender.Name = "frmGender";
			this.frmGender.TabIndex = 151;
			this.frmGender.Visible = true;
			this.frmEthnicity = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmEthnicity
			// 
			//this.frmEthnicity.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.frmEthnicity.Enabled = true;
			this.frmEthnicity.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmEthnicity.Name = "frmEthnicity";
			this.frmEthnicity.TabIndex = 152;
			this.frmEthnicity.Visible = true;
			imgMain = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>>(6);
			imgMain[2] = _imgMain_2;
			imgMain[5] = _imgMain_5;
			imgMain[2].Enabled = true;
			imgMain[2].Name = "_imgMain_2";
			imgMain[2].Tag = "2";
			imgMain[2].Visible = true;
			imgMain[5].Enabled = true;
			imgMain[5].Name = "_imgMain_5";
			imgMain[5].Visible = true;
			this.PrevReport = 0;
			this.chkMobileInvolved = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			//this.chkMobileInvolved.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
			this.chkMobileInvolved.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkMobileInvolved.Enabled = true;
			this.chkMobileInvolved.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkMobileInvolved.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.chkMobileInvolved.Name = "chkMobileInvolved";
			this.chkMobileInvolved.TabIndex = 246;
			this.chkMobileInvolved.Text = "MOBILE PROPERTY INVOLVED?";
			this.chkMobileInvolved.Visible = false;
			this.MobileInvolved = 0;
			this.MobileReportID = 0;
			this.Name = "TFDIncident.wzdFire";
			lstSuppressionFactors.Items.Add("lstSuppressionFactors ");
			lstEquipInvolvIgnition.Items.Add("lstEquipInvolvIgnition ");
			lstItemContribFireSpread.Items.Add("lstItemContribFireSpread");
			lstPhysicalContribFactors.Items.Add("lstPhysicalContribFactors ");
			lstHumanContribFactors.Items.Add("lstHumanContribFactors ");
			lstExtFailure.Items.Add("lstExtFailure");
			lstAlarmFailure.Items.Add("lstAlarmFailure");
		}

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label23 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNavMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel NavBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCityCode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtXStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboXSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmExposureAddress { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRSCurrReportType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncidentNumberTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblIncidentNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReportByTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbReportedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblEmployeeID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblPosition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblShift { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmReportStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSMaterialInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSAreaUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboOSCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOSLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtOSAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecOSCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSAreaAffected { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSAreaUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOSMaterialInvolved { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmOutsideInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHFAge { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optHFGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optHFGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmHFDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGenCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstSuppressionFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFirstItemIgnited { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFloorOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFlOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmBsmtorAttic { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBurnDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstEquipInvolvIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstItemContribFireSpread { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBurnDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEquipInvolvIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFireSpread { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAreaOfOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPhysicalContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecCauseOfIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenCauseIgnition { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSuppressFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFirstIgnited { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHeatSource { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAreaOrigin { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPhyContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFireInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBusinessName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtZipcode { get; set; }

        public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calBirthdate { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optEthnicity_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optGender_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtHouseNumber { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBusinessName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lblZipcode { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMI { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHouseNum { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPrefix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStreetType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSuffix { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFirstName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLastName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRole { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbRace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEthnicity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBirthdate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHomePhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPhone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbWorkPlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLicenseState { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMobileMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVehicleModel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVIN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLicenseSt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbOtherMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVIN { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleMake { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleModel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVehicleYear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboMobilePropType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtVesselLength { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtMobilePropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVYearMes { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMobilePropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbMobilePropType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbVesselLength { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmMobileProp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtJobsLost { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNoPeopleDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNoBusinessDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtSqFtBurned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtSqFtSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSqFtSmokeDamage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSqFtBurned { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoBusinessDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoPeopleDisplaced { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbJobsLost { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContentLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPropLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmLoss { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optType_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNumExp { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel _imgMain_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFireType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtBasementLevels { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtPropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optExtinguish_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optExtinguish_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstExtFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboExtEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSysType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExtProblems { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExtEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbExtSysType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optAlarmType_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstAlarmFailure { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInitiatingDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAlarmType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAlarmProblems { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInitiatingDevice { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEffectiveness { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSystemType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboGeneralPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSpecificPropertyUse { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBuildingStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboConstructionType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfBusinesses { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfOccupants { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberOfStories { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel txtTotalSqFootage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBasementLevel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNumberOfUnits { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbGenOccupancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSpecificOccupancy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbBldgStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbConstructionType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTotSqFt { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoStories { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoOccupants { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNoBusinesses { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbPropValue { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _lbFrameTitle_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmBldgInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireUnit { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireIncNo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireIncTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireLocationTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFireLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel LbUnitTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _NavButton_4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSave { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdSaveIncomplete { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAbandon { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel _optFloor_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNewName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNames { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExposures { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAddressCorrection { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkAlarmOperated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean isInitializingComponent { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optType { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FireReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optHFGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.CheckBoxViewModel> optFloor { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optAlarmType { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optExtinguish { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkExtOperated { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkRental { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ExposureOccured { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NameUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ADDRESSCORRECTION { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrUnit { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 RuptureReportID { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optGender { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optEthnicity { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 HumansAFactor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmFireOnly { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel CurrFrame { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> lbFrameTitle { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> NavButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportStarted { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel Frame1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmAlarmInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmExtinguishingSysInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmPassengerVehicleInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmGender { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmEthnicity { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.PictureBoxViewModel> imgMain { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PrevReport { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkMobileInvolved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MobileInvolved { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MobileReportID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

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

		public void OntxtOSLoss_TextChanged()
		{
			if ( _txtOSLoss_TextChanged != null )
				_txtOSLoss_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtOSLoss_TextChanged;

		public void OntxtOSAreaAffected_TextChanged()
		{
			if ( _txtOSAreaAffected_TextChanged != null )
				_txtOSAreaAffected_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtOSAreaAffected_TextChanged;

		public void OntxtHFAge_TextChanged()
		{
			if ( _txtHFAge_TextChanged != null )
				_txtHFAge_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHFAge_TextChanged;

		public void OntxtFloorOfOrigin_TextChanged()
		{
			if ( _txtFloorOfOrigin_TextChanged != null )
				_txtFloorOfOrigin_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtFloorOfOrigin_TextChanged;

		public void OntxtBusinessName_TextChanged()
		{
			if ( _txtBusinessName_TextChanged != null )
				_txtBusinessName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBusinessName_TextChanged;

		public void OntxtZipcode_TextChanged()
		{
			if ( _txtZipcode_TextChanged != null )
				_txtZipcode_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtZipcode_TextChanged;

		public void OntxtWorkPhone_TextChanged()
		{
			if ( _txtWorkPhone_TextChanged != null )
				_txtWorkPhone_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtWorkPhone_TextChanged;

		public void OntxtHomePhone_TextChanged()
		{
			if ( _txtHomePhone_TextChanged != null )
				_txtHomePhone_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHomePhone_TextChanged;

		public void OntxtWorkPlace_TextChanged()
		{
			if ( _txtWorkPlace_TextChanged != null )
				_txtWorkPlace_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtWorkPlace_TextChanged;

		public void OntxtHouseNumber_TextChanged()
		{
			if ( _txtHouseNumber_TextChanged != null )
				_txtHouseNumber_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtHouseNumber_TextChanged;

		public void OntxtStreetName_TextChanged()
		{
			if ( _txtStreetName_TextChanged != null )
				_txtStreetName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtStreetName_TextChanged;

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

		public void OntxtMI_TextChanged()
		{
			if ( _txtMI_TextChanged != null )
				_txtMI_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtMI_TextChanged;

		public void OntxtVehicleMake_TextChanged()
		{
			if ( _txtVehicleMake_TextChanged != null )
				_txtVehicleMake_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtVehicleMake_TextChanged;

		public void OntxtJobsLost_TextChanged()
		{
			if ( _txtJobsLost_TextChanged != null )
				_txtJobsLost_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtJobsLost_TextChanged;

		public void OntxtNoPeopleDisplaced_TextChanged()
		{
			if ( _txtNoPeopleDisplaced_TextChanged != null )
				_txtNoPeopleDisplaced_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNoPeopleDisplaced_TextChanged;

		public void OntxtNoBusinessDisplaced_TextChanged()
		{
			if ( _txtNoBusinessDisplaced_TextChanged != null )
				_txtNoBusinessDisplaced_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNoBusinessDisplaced_TextChanged;

		public void OntxtNumberExposures_TextChanged()
		{
			if ( _txtNumberExposures_TextChanged != null )
				_txtNumberExposures_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberExposures_TextChanged;

		public void OntxtBasementLevels_TextChanged()
		{
			if ( _txtBasementLevels_TextChanged != null )
				_txtBasementLevels_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtBasementLevels_TextChanged;

		public void OntxtNumberOfBusinesses_TextChanged()
		{
			if ( _txtNumberOfBusinesses_TextChanged != null )
				_txtNumberOfBusinesses_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfBusinesses_TextChanged;

		public void OntxtNumberOfOccupants_TextChanged()
		{
			if ( _txtNumberOfOccupants_TextChanged != null )
				_txtNumberOfOccupants_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfOccupants_TextChanged;

		public void OntxtNumberOfUnits_TextChanged()
		{
			if ( _txtNumberOfUnits_TextChanged != null )
				_txtNumberOfUnits_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfUnits_TextChanged;

		public void OntxtNumberOfStories_TextChanged()
		{
			if ( _txtNumberOfStories_TextChanged != null )
				_txtNumberOfStories_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberOfStories_TextChanged;
	}

}