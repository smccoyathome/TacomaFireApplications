using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgCalcPMCSR))]
	public class dlgCalcPMCSRViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.dtStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtStart.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.dtStart.MinDate = System.DateTime.Parse("1990/1/1");
			this.dtStart.Name = "dtStart";
			this.dtStart.TabIndex = 2;
			this.dtEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.dtEnd.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9f, UpgradeHelpers.Helpers
					.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.dtEnd.MinDate = System.DateTime.Parse("1990/1/1");
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.TabIndex = 3;
			this._Label3_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this._Label3_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			this.lbResult = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbResult
			// 
			this.lbResult.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.lbResult.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 13.5f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.lbResult.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 192, 0);
			this.lbResult.Name = "lbResult";
			this.lbResult.TabIndex = 7;
			this.lbResult.Text = "lbResult";
			this.CancelButton_Renamed = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// CancelButton_Renamed
			// 
			this.CancelButton_Renamed.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.CancelButton_Renamed.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.CancelButton_Renamed.TabIndex = 6;
			this.CancelButton_Renamed.Text = "Exit";
			this.cmdCalculate = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdCalculate
			// 
			this.cmdCalculate.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdCalculate.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdCalculate.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdCalculate.Name = "cmdCalculate";
			this.cmdCalculate.TabIndex = 0;
			this.cmdCalculate.Text = "Calculate the % of shifts worked by Paramedic CSRs that were on a Medic Unit or ALS Engine";
			this.Text = "Paramedic CSR Calculator";
			Label3 = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel>>(2);
			Label3[0] = _Label3_0;
			Label3[1] = _Label3_1;
			Label3[0].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[0].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 255);
			Label3[0].Name = "_Label3_0";
			Label3[0].TabIndex = 5;
			Label3[0].Text = "Start:";
			Label3[1].BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			Label3[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			Label3[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 255);
			Label3[1].Name = "_Label3_1";
			Label3[1].TabIndex = 4;
			Label3[1].Text = "End:";
			this.Name = "PTSProject.dlgCalcPMCSR";
			IsMdiChild = true;
		}

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel dtEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel _Label3_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbResult { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel CancelButton_Renamed { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdCalculate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.LabelViewModel> Label3 { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}