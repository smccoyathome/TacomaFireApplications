using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.frmOtherReports))]
	public class frmOtherReportsViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cboFPEStatus = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEStatus
			// 
			this.cboFPEStatus.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEStatus.Enabled = true;
			this.cboFPEStatus.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEStatus.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEStatus.Name = "cboFPEStatus";
			this.cboFPEStatus.TabIndex = 104;
			this.cboFPEStatus.Text = "cboFPEStatus";
			this.cboFPEStatus.Visible = true;
			this.cboFPEEquipment = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEEquipment
			// 
			this.cboFPEEquipment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEEquipment.Enabled = true;
			this.cboFPEEquipment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEEquipment.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEEquipment.Name = "cboFPEEquipment";
			this.cboFPEEquipment.TabIndex = 103;
			this.cboFPEEquipment.Text = "cboFPEEquipment";
			this.cboFPEEquipment.Visible = true;
			this.cboFPEProblem = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboFPEProblem
			// 
			this.cboFPEProblem.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboFPEProblem.Enabled = true;
			this.cboFPEProblem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboFPEProblem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboFPEProblem.Name = "cboFPEProblem";
			this.cboFPEProblem.TabIndex = 102;
			this.cboFPEProblem.Text = "cboFPEProblem";
			this.cboFPEProblem.Visible = true;
			this.lstPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstPPE
			// 
			this.lstPPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstPPE.Enabled = true;
			this.lstPPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstPPE.Name = "lstPPE";
			this.lstPPE.TabIndex = 99;
			this.lstPPE.Visible = true;
			this.lstPPE.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Single;
			this.Label28 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label28
			// 
			this.Label28.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label28.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label28.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label28.Name = "Label28";
			this.Label28.TabIndex = 109;
			this.Label28.Text = "SELECT EQUIPMENT PROBLEM";
			this.Label29 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label29
			// 
			this.Label29.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label29.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label29.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label29.Name = "Label29";
			this.Label29.TabIndex = 108;
			this.Label29.Text = "INDICATE EQUIPMENT STATUS";
			this.Label30 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label30
			// 
			this.Label30.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label30.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label30.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label30.Name = "Label30";
			this.Label30.TabIndex = 107;
			this.Label30.Text = "SELECT PPE EQUIPMENT ";
			this.Label31 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label31
			// 
			this.Label31.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label31.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label31.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label31.Name = "Label31";
			this.Label31.TabIndex = 106;
			this.Label31.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS";
			this.Label24 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label24
			// 
			this.Label24.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label24.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label24.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label24.Name = "Label24";
			this.Label24.TabIndex = 105;
			this.Label24.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS";
			this.frmFPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFPE
			// 
			this.frmFPE.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.frmFPE.Enabled = true;
			this.frmFPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFPE.Name = "frmFPE";
			this.frmFPE.TabIndex = 98;
			this.frmFPE.Visible = true;
			this.lstContributingFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContributingFactors
			// 
			this.lstContributingFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstContributingFactors.Enabled = true;
			this.lstContributingFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstContributingFactors.Name = "lstContributingFactors";
			this.lstContributingFactors.TabIndex = 80;
			this.lstContributingFactors.Visible = true;
			this.lstContributingFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboInjuryType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryType
			// 
			this.cboInjuryType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryType.Enabled = true;
			this.cboInjuryType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjuryType.Name = "cboInjuryType";
			this.cboInjuryType.TabIndex = 79;
			this.cboInjuryType.Text = "cboInjuryType";
			this.cboInjuryType.Visible = true;
			this.cboBodyPart = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboBodyPart
			// 
			this.cboBodyPart.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboBodyPart.Enabled = true;
			this.cboBodyPart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboBodyPart.Name = "cboBodyPart";
			this.cboBodyPart.TabIndex = 78;
			this.cboBodyPart.Text = "cboBodyPart";
			this.cboBodyPart.Visible = true;
			this.cboInjurySeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjurySeverity
			// 
			this.cboInjurySeverity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjurySeverity.Enabled = true;
			this.cboInjurySeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjurySeverity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjurySeverity.Name = "cboInjurySeverity";
			this.cboInjurySeverity.TabIndex = 77;
			this.cboInjurySeverity.Text = "cboInjurySeverity";
			this.cboInjurySeverity.Visible = true;
			this.Label17 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label17
			// 
			this.Label17.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label17.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label17.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label17.Name = "Label17";
			this.Label17.TabIndex = 84;
			this.Label17.Text = "CONTRIBUTING FACTORS";
			this.Label16 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label16
			// 
			this.Label16.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label16.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label16.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label16.Name = "Label16";
			this.Label16.TabIndex = 83;
			this.Label16.Text = "TYPE OF INJURY";
			this.Label10 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label10
			// 
			this.Label10.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label10.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label10.Name = "Label10";
			this.Label10.TabIndex = 82;
			this.Label10.Text = "BODY PART INJURED";
			this.Label11 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label11
			// 
			this.Label11.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label11.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label11.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label11.Name = "Label11";
			this.Label11.TabIndex = 81;
			this.Label11.Text = "INJURY SEVERITY";
			this.cboActivity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboActivity
			// 
			this.cboActivity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboActivity.Enabled = true;
			this.cboActivity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboActivity.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboActivity.Name = "cboActivity";
			this.cboActivity.TabIndex = 71;
			this.cboActivity.Text = "cboActivity";
			this.cboActivity.Visible = true;
			this.cboWhereOccured = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboWhereOccured
			// 
			this.cboWhereOccured.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboWhereOccured.Enabled = true;
			this.cboWhereOccured.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboWhereOccured.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboWhereOccured.Name = "cboWhereOccured";
			this.cboWhereOccured.TabIndex = 70;
			this.cboWhereOccured.Text = "cboWhereOccured";
			this.cboWhereOccured.Visible = true;
			this.cboInjuryCausedBy = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryCausedBy
			// 
			this.cboInjuryCausedBy.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryCausedBy.Enabled = true;
			this.cboInjuryCausedBy.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryCausedBy.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboInjuryCausedBy.Name = "cboInjuryCausedBy";
			this.cboInjuryCausedBy.TabIndex = 69;
			this.cboInjuryCausedBy.Text = "cboInjuryCausedBy";
			this.cboInjuryCausedBy.Visible = true;
			this.cboLocationAtInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboLocationAtInjury
			// 
			this.cboLocationAtInjury.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboLocationAtInjury.Enabled = true;
			this.cboLocationAtInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboLocationAtInjury.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.cboLocationAtInjury.Name = "cboLocationAtInjury";
			this.cboLocationAtInjury.TabIndex = 68;
			this.cboLocationAtInjury.Text = "cboLocationAtInjury";
			this.cboLocationAtInjury.Visible = true;
			this.Label12 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label12
			// 
			this.Label12.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label12.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label12.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label12.Name = "Label12";
			this.Label12.TabIndex = 75;
			this.Label12.Text = "ACTIVITY AT TIME OF INJURY";
			this.Label13 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label13
			// 
			this.Label13.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label13.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label13.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label13.Name = "Label13";
			this.Label13.TabIndex = 74;
			this.Label13.Text = "WHERE DID INJURY OCCUR";
			this.Label14 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label14
			// 
			this.Label14.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label14.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label14.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label14.Name = "Label14";
			this.Label14.TabIndex = 73;
			this.Label14.Text = "INJURY CAUSED BY";
			this.lbLocationAtInjury = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocationAtInjury
			// 
			this.lbLocationAtInjury.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocationAtInjury.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocationAtInjury.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.lbLocationAtInjury.Name = "lbLocationAtInjury";
			this.lbLocationAtInjury.TabIndex = 72;
			this.lbLocationAtInjury.Text = "LOCATION AT TIME OF INJURY";
			this.Label21 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label21
			// 
			this.Label21.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label21.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label21.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label21.Name = "Label21";
			this.Label21.TabIndex = 97;
			this.Label21.Text = "RECOMMENDATIONS FOR PREVENTION";
			this.Label20 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label20
			// 
			this.Label20.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label20.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label20.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label20.Name = "Label20";
			this.Label20.TabIndex = 96;
			this.Label20.Text = "Date:";
			this.Label19 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label19
			// 
			this.Label19.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label19.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label19.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label19.Name = "Label19";
			this.Label19.TabIndex = 95;
			this.Label19.Text = "Incident:";
			this.Label18 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label18
			// 
			this.Label18.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label18.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label18.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label18.Name = "Label18";
			this.Label18.TabIndex = 94;
			this.Label18.Text = "Employee:";
			this.lbCasualtyDate = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCasualtyDate
			// 
			this.lbCasualtyDate.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCasualtyDate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCasualtyDate.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbCasualtyDate.Name = "lbCasualtyDate";
			this.lbCasualtyDate.TabIndex = 93;
			this.lbCasualtyDate.Text = "lbCasualtyDate";
			this.lbFSCasualtyIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFSCasualtyIncident
			// 
			this.lbFSCasualtyIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFSCasualtyIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFSCasualtyIncident.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbFSCasualtyIncident.Name = "lbFSCasualtyIncident";
			this.lbFSCasualtyIncident.TabIndex = 92;
			this.lbFSCasualtyIncident.Text = "lbIncident";
			this.lbEmployee = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbEmployee
			// 
			this.lbEmployee.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbEmployee.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9.6f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbEmployee.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbEmployee.Name = "lbEmployee";
			this.lbEmployee.TabIndex = 91;
			this.lbEmployee.Text = "lbEmployee";
			this.Label15 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label15
			// 
			this.Label15.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label15.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label15.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label15.Name = "Label15";
			this.Label15.TabIndex = 90;
			this.Label15.Text = "DETAILED NARRATIVE";
			this.Label22 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label22
			// 
			this.Label22.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label22.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label22.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.Label22.Name = "Label22";
			this.Label22.TabIndex = 89;
			this.Label22.Text = "FIRE SERVICE CASUALTY REPORT";
			this.frmFSCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmFSCasualty
			// 
			this.frmFSCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.frmFSCasualty.Enabled = true;
			this.frmFSCasualty.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmFSCasualty.Name = "frmFSCasualty";
			this.frmFSCasualty.TabIndex = 65;
			this.frmFSCasualty.Visible = true;
			this.cboCivNarrList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCivNarrList
			// 
			this.cboCivNarrList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCivNarrList.Enabled = true;
			this.cboCivNarrList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCivNarrList.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCivNarrList.Name = "cboCivNarrList";
			this.cboCivNarrList.TabIndex = 120;
			this.cboCivNarrList.Visible = true;
			this.lstHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstHumanContribFactors
			// 
			this.lstHumanContribFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstHumanContribFactors.Enabled = true;
			this.lstHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstHumanContribFactors.Name = "lstHumanContribFactors";
			this.lstHumanContribFactors.TabIndex = 42;
			this.lstHumanContribFactors.Visible = true;
			this.lstHumanContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.lstContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.ListBoxViewModel>();
			// 
			// lstContribFactors
			// 
			this.lstContribFactors.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.lstContribFactors.Enabled = true;
			this.lstContribFactors.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.lstContribFactors.Name = "lstContribFactors";
			this.lstContribFactors.TabIndex = 41;
			this.lstContribFactors.Visible = true;
			this.lstContribFactors.SelectionMode = UpgradeHelpers.BasicViewModels.SelectionMode.Multiple;
			this.cboEMSPatient = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboEMSPatient
			// 
			this.cboEMSPatient.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboEMSPatient.Enabled = false;
			this.cboEMSPatient.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboEMSPatient.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboEMSPatient.Name = "cboEMSPatient";
			this.cboEMSPatient.TabIndex = 38;
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
			this.lbEMSPatient.TabIndex = 40;
			this.lbEMSPatient.Text = "SELECT EMS PATIENT";
			this.txtFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtFloor.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtFloor.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtFloor.Name = "txtFloor";
			this.txtFloor.TabIndex = 32;
			this.cboCCLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboCCLocation
			// 
			this.cboCCLocation.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboCCLocation.Enabled = true;
			this.cboCCLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboCCLocation.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboCCLocation.Name = "cboCCLocation";
			this.cboCCLocation.TabIndex = 31;
			this.cboCCLocation.Visible = true;
			this.cboInjuryCause = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboInjuryCause
			// 
			this.cboInjuryCause.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboInjuryCause.Enabled = true;
			this.cboInjuryCause.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboInjuryCause.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboInjuryCause.Name = "cboInjuryCause";
			this.cboInjuryCause.TabIndex = 30;
			this.cboInjuryCause.Visible = true;
			this.cboSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboSeverity
			// 
			this.cboSeverity.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboSeverity.Enabled = true;
			this.cboSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboSeverity.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboSeverity.Name = "cboSeverity";
			this.cboSeverity.TabIndex = 29;
			this.cboSeverity.Visible = true;
			this.lbCCLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCCLocation
			// 
			this.lbCCLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCCLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCCLocation.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbCCLocation.Name = "lbCCLocation";
			this.lbCCLocation.TabIndex = 36;
			this.lbCCLocation.Text = "LOCATION AT INJURY";
			this.lbFloor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbFloor
			// 
			this.lbFloor.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbFloor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbFloor.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbFloor.Name = "lbFloor";
			this.lbFloor.TabIndex = 35;
			this.lbFloor.Text = "FLOOR";
			this.lbInjuryCause = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbInjuryCause
			// 
			this.lbInjuryCause.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbInjuryCause.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbInjuryCause.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbInjuryCause.Name = "lbInjuryCause";
			this.lbInjuryCause.TabIndex = 34;
			this.lbInjuryCause.Text = "INJURY CAUSED BY";
			this.lbSeverity = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSeverity
			// 
			this.lbSeverity.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSeverity.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSeverity.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbSeverity.Name = "lbSeverity";
			this.lbSeverity.TabIndex = 33;
			this.lbSeverity.Text = "INJURY SEVERITY";
			this.Label9 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label9
			// 
			this.Label9.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label9.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label9.Name = "Label9";
			this.Label9.TabIndex = 121;
			this.Label9.Text = "SELECT NARRATION AUTHOR";
			this.lbCCAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCCAuthor
			// 
			this.lbCCAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbCCAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCCAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbCCAuthor.Name = "lbCCAuthor";
			this.lbCCAuthor.TabIndex = 61;
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 60;
			this.Label5.Text = "Narrations may only be edited by Original Author";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 53;
			this.Label3.Text = "INCIDENT NARRATION - Author:";
			this.lbCivilNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCivilNarrID
			// 
			this.lbCivilNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbCivilNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbCivilNarrID.Name = "lbCivilNarrID";
			this.lbCivilNarrID.TabIndex = 57;
			this.lbCivilNarrID.Visible = false;
			this.lbCivCasualtyTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbCivCasualtyTitle
			// 
			this.lbCivCasualtyTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbCivCasualtyTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbCivCasualtyTitle.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbCivCasualtyTitle.Name = "lbCivCasualtyTitle";
			this.lbCivCasualtyTitle.TabIndex = 45;
			this.lbCivCasualtyTitle.Text = "Civilian Casualty Report";
			this.lbHumanContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHumanContribFactors
			// 
			this.lbHumanContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHumanContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f,
					UpgradeHelpers.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHumanContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbHumanContribFactors.Name = "lbHumanContribFactors";
			this.lbHumanContribFactors.TabIndex = 44;
			this.lbHumanContribFactors.Text = "HUMAN CONTRIBUTING FACTORS";
			this.lbContribFactors = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbContribFactors
			// 
			this.lbContribFactors.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbContribFactors.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbContribFactors.ForeColor = UpgradeHelpers.Helpers.Color.Maroon;
			this.lbContribFactors.Name = "lbContribFactors";
			this.lbContribFactors.TabIndex = 43;
			this.lbContribFactors.Text = "CONTRIBUTING FACTORS";
			this.frmCivilianCasualty = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmCivilianCasualty
			// 
			this.frmCivilianCasualty.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(143, 154, 169);
			this.frmCivilianCasualty.Enabled = true;
			this.frmCivilianCasualty.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.frmCivilianCasualty.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
			this.frmCivilianCasualty.Name = "frmCivilianCasualty";
			this.frmCivilianCasualty.TabIndex = 27;
			this.frmCivilianCasualty.Tag = "6";
			this.frmCivilianCasualty.Visible = true;
			this.cboServiceNarrList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboServiceNarrList
			// 
			this.cboServiceNarrList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboServiceNarrList.Enabled = true;
			this.cboServiceNarrList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboServiceNarrList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.cboServiceNarrList.Name = "cboServiceNarrList";
			this.cboServiceNarrList.TabIndex = 117;
			this.cboServiceNarrList.Text = "cboServNarrList";
			this.cboServiceNarrList.Visible = true;
			this.txtStandbyHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtStandbyHours.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtStandbyHours.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtStandbyHours.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.txtStandbyHours.Name = "txtStandbyHours";
			this.txtStandbyHours.TabIndex = 22;
			this.txtStandbyHours.Text = "txtStandbyHours";
			this.txtStandbyHours.Visible = false;
			this.cboServiceType = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboServiceType
			// 
			this.cboServiceType.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboServiceType.Enabled = true;
			this.cboServiceType.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboServiceType.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.cboServiceType.Name = "cboServiceType";
			this.cboServiceType.TabIndex = 21;
			this.cboServiceType.Text = "cboServiceType";
			this.cboServiceType.Visible = true;
			this.txtNumberSafePlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtNumberSafePlace.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtNumberSafePlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtNumberSafePlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.txtNumberSafePlace.Name = "txtNumberSafePlace";
			this.txtNumberSafePlace.TabIndex = 20;
			this.txtNumberSafePlace.Text = "txtStandbyHours";
			this.txtNumberSafePlace.Visible = false;
			this.Label8 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label8
			// 
			this.Label8.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label8.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label8.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label8.Name = "Label8";
			this.Label8.TabIndex = 116;
			this.Label8.Text = "SELECT NARRATION AUTHOR";
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 63;
			this.Label7.Text = "Narrations may only be edited by Original Author";
			this.lbServNarrAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServNarrAuthor
			// 
			this.lbServNarrAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbServNarrAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbServNarrAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbServNarrAuthor.Name = "lbServNarrAuthor";
			this.lbServNarrAuthor.TabIndex = 62;
			this.lbServiceNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServiceNarrID
			// 
			this.lbServiceNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbServiceNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbServiceNarrID.Name = "lbServiceNarrID";
			this.lbServiceNarrID.TabIndex = 55;
			this.lbServiceNarrID.Visible = false;
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 54;
			this.Label4.Text = "INCIDENT NARRATION - Author:";
			this.lbServiceTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServiceTitle
			// 
			this.lbServiceTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbServiceTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 19.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbServiceTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbServiceTitle.Name = "lbServiceTitle";
			this.lbServiceTitle.TabIndex = 26;
			this.lbServiceTitle.Text = "Frame Title";
			this.lbStandbyHours = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbStandbyHours
			// 
			this.lbStandbyHours.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbStandbyHours.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbStandbyHours.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbStandbyHours.Name = "lbStandbyHours";
			this.lbStandbyHours.TabIndex = 25;
			this.lbStandbyHours.Text = "STANDBY HOURS";
			this.lbStandbyHours.Visible = false;
			this.lbServiceProvided = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbServiceProvided
			// 
			this.lbServiceProvided.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbServiceProvided.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbServiceProvided.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbServiceProvided.Name = "lbServiceProvided";
			this.lbServiceProvided.TabIndex = 24;
			this.lbServiceProvided.Text = "SERVICE PROVIDED";
			this.lbSafePlace = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbSafePlace
			// 
			this.lbSafePlace.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbSafePlace.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbSafePlace.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
			this.lbSafePlace.Name = "lbSafePlace";
			this.lbSafePlace.TabIndex = 23;
			this.lbSafePlace.Text = "NUMBER OF SAFEPLACE JUVENILES";
			this.lbSafePlace.Visible = false;
			this.frmService = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmService
			// 
			this.frmService.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(172, 168, 119);
			this.frmService.Enabled = true;
			this.frmService.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmService.Name = "frmService";
			this.frmService.TabIndex = 19;
			this.frmService.Tag = "13";
			this.frmService.Visible = true;
			this.cboNarrList = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboNarrList
			// 
			this.cboNarrList.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboNarrList.Enabled = true;
			this.cboNarrList.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboNarrList.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboNarrList.Name = "cboNarrList";
			this.cboNarrList.TabIndex = 114;
			this.cboNarrList.Text = "cboNarrList";
			this.cboNarrList.Visible = true;
			this.cboAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo1
			// 
			this.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo1.Enabled = true;
			this.cboAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo1.Name = "cboAllInfo1";
			this.cboAllInfo1.TabIndex = 13;
			this.cboAllInfo1.Text = "cboAllInfo1";
			this.cboAllInfo1.Visible = true;
			this.cboAllInfo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo2
			// 
			this.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo2.Enabled = true;
			this.cboAllInfo2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo2.Name = "cboAllInfo2";
			this.cboAllInfo2.TabIndex = 12;
			this.cboAllInfo2.Text = "cboAllInfo2";
			this.cboAllInfo2.Visible = true;
			this.cboAllInfo3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboAllInfo3
			// 
			this.cboAllInfo3.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboAllInfo3.Enabled = true;
			this.cboAllInfo3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cboAllInfo3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.cboAllInfo3.Name = "cboAllInfo3";
			this.cboAllInfo3.TabIndex = 11;
			this.cboAllInfo3.Text = "cboAllInfo3";
			this.cboAllInfo3.Visible = true;
			this.txtAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtAllInfo1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
			this.txtAllInfo1.Name = "txtAllInfo1";
			this.txtAllInfo1.TabIndex = 10;
			this.txtAllInfo1.Text = "txtAllInfo1";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 113;
			this.Label6.Text = "Select Narration Author";
			this.lbAllNarrAuthor = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllNarrAuthor
			// 
			this.lbAllNarrAuthor.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
			this.lbAllNarrAuthor.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllNarrAuthor.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAllNarrAuthor.Name = "lbAllNarrAuthor";
			this.lbAllNarrAuthor.TabIndex = 59;
			this.lbNarrMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbNarrMessage
			// 
			this.lbNarrMessage.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbNarrMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbNarrMessage.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbNarrMessage.Name = "lbNarrMessage";
			this.lbNarrMessage.TabIndex = 58;
			this.lbNarrMessage.Text = "Narrations may only be edited by Original Author";
			this.lbAllNarrID = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllNarrID
			// 
			this.lbAllNarrID.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.lbAllNarrID.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.lbAllNarrID.Name = "lbAllNarrID";
			this.lbAllNarrID.TabIndex = 56;
			this.lbAllNarrID.Visible = false;
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 52;
			this.Label1.Text = "INCIDENT NARRATION - Author:";
			this.lbAllInfoTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfoTitle
			// 
			this.lbAllInfoTitle.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfoTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.8f, UpgradeHelpers
						.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfoTitle.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfoTitle.Name = "lbAllInfoTitle";
			this.lbAllInfoTitle.TabIndex = 18;
			this.lbAllInfoTitle.Text = "FALSE ALARM REPORT";
			this.lbAllInfo1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo1
			// 
			this.lbAllInfo1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo1.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo1.Name = "lbAllInfo1";
			this.lbAllInfo1.TabIndex = 17;
			this.lbAllInfo1.Text = "lbAllInfo1";
			this.lbAllInfo2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo2
			// 
			this.lbAllInfo2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo2.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo2.Name = "lbAllInfo2";
			this.lbAllInfo2.TabIndex = 16;
			this.lbAllInfo2.Text = "lbAllInfo2";
			this.lbAllInfo3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo3
			// 
			this.lbAllInfo3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo3.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo3.Name = "lbAllInfo3";
			this.lbAllInfo3.TabIndex = 15;
			this.lbAllInfo3.Text = "lbAllInfo3";
			this.lbAllInfo4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbAllInfo4
			// 
			this.lbAllInfo4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbAllInfo4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbAllInfo4.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbAllInfo4.Name = "lbAllInfo4";
			this.lbAllInfo4.TabIndex = 14;
			this.lbAllInfo4.Text = "lbAllInfo4";
			this.frmAllInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmAllInfo
			// 
			this.frmAllInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(153, 166, 187);
			this.frmAllInfo.Enabled = true;
			this.frmAllInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmAllInfo.Name = "frmAllInfo";
			this.frmAllInfo.TabIndex = 7;
			this.frmAllInfo.Visible = true;
			this.lbLockedMessage = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLockedMessage
			// 
			this.lbLockedMessage.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.lbLockedMessage.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLockedMessage.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 64, 0);
			this.lbLockedMessage.Name = "lbLockedMessage";
			this.lbLockedMessage.TabIndex = 64;
			this.lbLockedMessage.Text = "READ ONLY - Records Locked";
			this.lbLocation = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbLocation
			// 
			this.lbLocation.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbLocation.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbLocation.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.TabIndex = 6;
			this.lbLocation.Text = "lbLocation";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Incident #";
			this.lbIncident = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbIncident
			// 
			this.lbIncident.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbIncident.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbIncident.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.lbIncident.Name = "lbIncident";
			this.lbIncident.TabIndex = 4;
			this.lbIncident.Text = "001230012";
			this.picEMSBar = ctx.Resolve<UpgradeHelpers.BasicViewModels.PictureBoxViewModel>();
			// 
			// picEMSBar
			// 
			this.picEMSBar.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 0);
			this.picEMSBar.Enabled = true;
			this.picEMSBar.Name = "picEMSBar";
			this.picEMSBar.Visible = true;
			this.cmdDone = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdDone
			// 
			this.cmdDone.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdDone.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdDone.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.TabIndex = 111;
			this.cmdDone.Text = "DONE";
			this.cmdAddPPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddPPE
			// 
			this.cmdAddPPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddPPE.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddPPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddPPE.Name = "cmdAddPPE";
			this.cmdAddPPE.TabIndex = 101;
			this.cmdAddPPE.Text = "Add Selections to List";
			this.cmdRemovePPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRemovePPE
			// 
			this.cmdRemovePPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRemovePPE.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRemovePPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRemovePPE.Name = "cmdRemovePPE";
			this.cmdRemovePPE.TabIndex = 100;
			this.cmdRemovePPE.Text = "Remove Selection from List";
			this.cmdEDITFPE = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdEDITFPE
			// 
			this.cmdEDITFPE.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdEDITFPE.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdEDITFPE.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdEDITFPE.Name = "cmdEDITFPE";
			this.cmdEDITFPE.TabIndex = 110;
			this.cmdEDITFPE.Text = "EDIT";

			this.chkFPEProblem = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkFPEProblem.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(159, 135, 113);
			this.chkFPEProblem.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkFPEProblem.Enabled = true;
			this.chkFPEProblem.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkFPEProblem.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
			this.chkFPEProblem.Name = "chkFPEProblem";
			this.chkFPEProblem.TabIndex = 66;
			this.chkFPEProblem.Text = "PERSONAL PROTECTIVE EQUIPMENT PROBLEMS?";
			this.chkFPEProblem.Visible = true;
			this.cmdCivAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCivAddNarration
			// 
			this.cmdCivAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCivAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 12f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCivAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCivAddNarration.Name = "cmdCivAddNarration";
			this.cmdCivAddNarration.TabIndex = 119;
			this.cmdCivAddNarration.Tag = "1";
			this.cmdCivAddNarration.Text = "ADD NEW NARRATION";
			this.rtxCivilNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxCivilNarration.Enabled = true;
			this.rtxCivilNarration.Name = "rtxCivilNarration";
			this.rtxCivilNarration.TabIndex = 48;
			this.chkEMR = ctx.Resolve<UpgradeHelpers.BasicViewModels.CheckBoxViewModel>();
			this.chkEMR.BackColor = UpgradeHelpers.Helpers.Color.Blue;
			this.chkEMR.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			this.chkEMR.Enabled = true;
			this.chkEMR.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.2f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.chkEMR.ForeColor = UpgradeHelpers.Helpers.Color.White;
			this.chkEMR.Name = "chkEMR";
			this.chkEMR.TabIndex = 39;
			this.chkEMR.Text = "EMS PATIENT REPORT COMPLETED?";
			this.chkEMR.Visible = true;
			this.cmdServAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdServAddNarration
			// 
			this.cmdServAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdServAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdServAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdServAddNarration.Name = "cmdServAddNarration";
			this.cmdServAddNarration.TabIndex = 118;
			this.cmdServAddNarration.Tag = "1";
			this.cmdServAddNarration.Text = "Add New Narration";
			this.rtxServiceNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxServiceNarration.Enabled = true;
			this.rtxServiceNarration.Name = "rtxServiceNarration";
			this.rtxServiceNarration.TabIndex = 46;
			this.cmdAddNarration = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdAddNarration
			// 
			this.cmdAddNarration.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdAddNarration.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdAddNarration.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdAddNarration.Name = "cmdAddNarration";
			this.cmdAddNarration.TabIndex = 115;
			this.cmdAddNarration.Tag = "1";
			this.cmdAddNarration.Text = "Add New Narration";
			this.rtxAllNarration = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxAllNarration.Enabled = true;
			this.rtxAllNarration.Name = "rtxAllNarration";
			this.rtxAllNarration.TabIndex = 50;
			this._cmdSave_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this._cmdSave_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.Text = "Form1";
			this.CurrReport = 0;
			this.CurrIncident = 0;
			this.NarrationUpdated = 0;
			this.FirstTime = 0;
			this.CurrReportID = 0;
			this.rtxNarrative = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxNarrative.Enabled = true;
			this.rtxNarrative.Name = "rtxNarrative";
			this.rtxNarrative.TabIndex = 88;
			this.rtxRecommend = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxRecommend.Enabled = true;
			this.rtxRecommend.Name = "rtxRecommend";
			this.rtxRecommend.TabIndex = 87;
			this.ReportLogID = 0;
			this.DontRespond = 0;
			this.rtxFalseAlarmComment = ctx.Resolve<Stubs._System.Windows.Forms.RichTextBox>();
			this.rtxFalseAlarmComment.Enabled = true;
			this.rtxFalseAlarmComment.Name = "rtxFalseAlarmComment";
			this.rtxFalseAlarmComment.TabIndex = 9;
			this.rtxFalseAlarmComment.Visible = false;
			cmdSave = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel>>(4);
			cmdSave[3] = _cmdSave_3;
			cmdSave[2] = _cmdSave_2;
			cmdSave[1] = _cmdSave_1;
			cmdSave[0] = _cmdSave_0;
			cmdSave[3].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[3].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[3].Name = "_cmdSave_3";
			cmdSave[3].TabIndex = 112;
			cmdSave[3].Text = "Print";
			cmdSave[2].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[2].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[2].Name = "_cmdSave_2";
			cmdSave[2].TabIndex = 3;
			cmdSave[2].Text = "Cancel and Exit";
			cmdSave[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[1].Name = "_cmdSave_1";
			cmdSave[1].TabIndex = 2;
			cmdSave[1].Text = "Save as Incomplete";
			cmdSave[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			cmdSave[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 10.8f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			cmdSave[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			cmdSave[0].Name = "_cmdSave_0";
			cmdSave[0].TabIndex = 1;
			cmdSave[0].Text = "Save as Complete";
			this.PPEFlag = 0;
			this.Name = "TFDIncident.frmOtherReports";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEStatus { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEEquipment { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboFPEProblem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label28 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label29 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label30 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label31 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label24 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContributingFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboBodyPart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjurySeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label17 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label16 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label10 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label11 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboActivity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboWhereOccured { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryCausedBy { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboLocationAtInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label12 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label13 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label14 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocationAtInjury { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label21 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label20 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label19 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label18 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCasualtyDate { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFSCasualtyIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEmployee { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label15 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label22 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmFSCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCivNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ListBoxViewModel lstContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboEMSPatient { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbEMSPatient { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboCCLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboInjuryCause { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboSeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCCLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbFloor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbInjuryCause { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSeverity { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label9 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCCAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCivilNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbCivCasualtyTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHumanContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbContribFactors { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmCivilianCasualty { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboServiceNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtStandbyHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboServiceType { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtNumberSafePlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label8 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServNarrAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServiceNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServiceTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbStandbyHours { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbServiceProvided { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbSafePlace { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmService { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboNarrList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboAllInfo3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllNarrAuthor { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbNarrMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllNarrID { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfoTitle { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbAllInfo4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmAllInfo { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLockedMessage { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbLocation { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbIncident { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PictureBoxViewModel picEMSBar { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdDone { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddPPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRemovePPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdEDITFPE { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkFPEProblem { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCivAddNarration { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxCivilNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.CheckBoxViewModel chkEMR { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdServAddNarration { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxServiceNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdAddNarration { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxAllNarration { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel _cmdSave_0 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReport { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrIncident { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 NarrationUpdated { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrReportID { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxNarrative { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxRecommend { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 ReportLogID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 DontRespond { get; set; }

		public virtual Stubs._System.Windows.Forms.RichTextBox rtxFalseAlarmComment { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.ButtonViewModel> cmdSave { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 PPEFlag { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

		public void OntxtStandbyHours_TextChanged()
		{
			if ( _txtStandbyHours_TextChanged != null )
				_txtStandbyHours_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtStandbyHours_TextChanged;

		public void OntxtNumberSafePlace_TextChanged()
		{
			if ( _txtNumberSafePlace_TextChanged != null )
				_txtNumberSafePlace_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtNumberSafePlace_TextChanged;

		public void OntxtAllInfo1_TextChanged()
		{
			if ( _txtAllInfo1_TextChanged != null )
				_txtAllInfo1_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtAllInfo1_TextChanged;
	}

}