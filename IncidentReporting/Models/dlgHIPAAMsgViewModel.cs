using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace TFDIncident.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(TFDIncident.dlgHIPAAMsg))]
	public class dlgHIPAAMsgViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.txtReleaseReason = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseReason.Name = "txtReleaseReason";
			this.txtReleaseReason.TabIndex = 4;
			this.txtReleaseAdd2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseAdd2.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtReleaseAdd2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtReleaseAdd2.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtReleaseAdd2.Name = "txtReleaseAdd2";
			this.txtReleaseAdd2.TabIndex = 3;
			this.txtReleaseAdd2.Text = "txtReleaseAdd2";
			this.txtReleaseAdd1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseAdd1.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtReleaseAdd1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtReleaseAdd1.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtReleaseAdd1.Name = "txtReleaseAdd1";
			this.txtReleaseAdd1.TabIndex = 2;
			this.txtReleaseAdd1.Text = "txtReleaseAdd1";
			this.txtReleaseName = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtReleaseName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtReleaseName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.txtReleaseName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtReleaseName.Name = "txtReleaseName";
			this.txtReleaseName.TabIndex = 1;
			this.txtReleaseName.Text = "txtReleaseName";
			this._Label1_3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label1_2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label1_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label1_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.sprHIPAAMsg = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
            this.sprHIPAAMsg.Get_HorizontalScrollBar().Visible = false;
			this.sprHIPAAMsg.MaxCols = 1;
			this.sprHIPAAMsg.MaxRows = 1;
			this.sprHIPAAMsg.TabIndex = 8;
			this.sprHIPAAMsg.Get_VerticalScrollBar().Visible = true;
			this.lbHIPAAMsg = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbHIPAAMsg
			// 
			this.lbHIPAAMsg.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbHIPAAMsg.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Verdana", 13.5f, UpgradeHelpers.
						Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Italic | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbHIPAAMsg.ForeColor = UpgradeHelpers.Helpers.Color.Navy;
			this.lbHIPAAMsg.Name = "lbHIPAAMsg";
			this.lbHIPAAMsg.TabIndex = 13;
			this.lbHIPAAMsg.Text = "HIPAA Policy Information";
			this.sprHIPAAMsg_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			// 
			// sprHIPAAMsg_Sheet1
			// 
			this.sprHIPAAMsg_Sheet1.SheetName = "Sheet1";
			this.cmdOut = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdOut.Name = "cmdOut";
			this.cmdOut.TabIndex = 5;
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 6;
			this.cmdCancel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Visible = false;
			this.Text = "TFD - Incident Reporting System";
			this.AddRequest = 0;
			this.frmReleaseInfo = ctx.Resolve<UpgradeHelpers.BasicViewModels.GroupBoxViewModel>();
			// 
			// frmReleaseInfo
			// 
			this.frmReleaseInfo.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 192);
			this.frmReleaseInfo.Enabled = true;
			this.frmReleaseInfo.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmReleaseInfo.Name = "frmReleaseInfo";
			this.frmReleaseInfo.TabIndex = 0;
			this.frmReleaseInfo.Text = "Release Information";
			this.frmReleaseInfo.Visible = true;
			Label1 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(4);
			Label1[3] = _Label1_3;
			Label1[2] = _Label1_2;
			Label1[1] = _Label1_1;
			Label1[0] = _Label1_0;
			Label1[3].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label1[3].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			Label1[3].Name = "_Label1_3";
			Label1[3].TabIndex = 12;
			Label1[3].Text = "Reason";
			Label1[2].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label1[2].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			Label1[2].Name = "_Label1_2";
			Label1[2].TabIndex = 11;
			Label1[2].Text = "City, State, Zip";
			Label1[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label1[1].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			Label1[1].Name = "_Label1_1";
			Label1[1].TabIndex = 10;
			Label1[1].Text = "Address";
			Label1[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label1[0].ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			Label1[0].Name = "_Label1_0";
			Label1[0].TabIndex = 9;
			Label1[0].Text = "Released To";
			this.Name = "TFDIncident.dlgHIPAAMsg";
			this.sprHIPAAMsg.Sheets.Add(sprHIPAAMsg_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseReason { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseAdd2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseAdd1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtReleaseName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label1_3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label1_2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label1_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label1_0 { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprHIPAAMsg { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbHIPAAMsg { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprHIPAAMsg_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdOut { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCancel { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 AddRequest { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.GroupBoxViewModel frmReleaseInfo { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label1 { get; set; }

		public void OntxtReleaseReason_TextChanged()
		{
			if ( _txtReleaseReason_TextChanged != null )
				_txtReleaseReason_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtReleaseReason_TextChanged;

		public void OntxtReleaseAdd2_TextChanged()
		{
			if ( _txtReleaseAdd2_TextChanged != null )
				_txtReleaseAdd2_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtReleaseAdd2_TextChanged;

		public void OntxtReleaseAdd1_TextChanged()
		{
			if ( _txtReleaseAdd1_TextChanged != null )
				_txtReleaseAdd1_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtReleaseAdd1_TextChanged;

		public void OntxtReleaseName_TextChanged()
		{
			if ( _txtReleaseName_TextChanged != null )
				_txtReleaseName_TextChanged(null, new System.EventArgs());
		}

		private event System.EventHandler _txtReleaseName_TextChanged;
	}

}