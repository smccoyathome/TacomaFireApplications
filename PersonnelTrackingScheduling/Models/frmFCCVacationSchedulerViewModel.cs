using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmFCCVacationScheduler))]
	public class frmFCCVacationSchedulerViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "Close";
			this.cmdRefresh = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdRefresh.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25f, UpgradeHelpers
					.Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.cmdRefresh.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.TabIndex = 0;
			this.cmdRefresh.Text = "Refresh";
			this.calYear = ctx.Resolve<UpgradeHelpers.BasicViewModels.MonthCalendarViewModel>();
			// 
			// calYear
			// 
			this.calYear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 6.75f, UpgradeHelpers.
					Helpers.FontStyle.Bold | UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, 0);
			this.calYear.Name = "calYear";
			this.calYear.TabIndex = 2;
			this.calYear.Width = 809;
			this.Text = "Dispatch Vacation Scheduler";
			this.CalendarLoading = false;
			this.MINWorking = 0;
			this.FirstTime = false;
			this.Name = "PTSProject.frmFCCVacationScheduler";
			IsMdiChild = true;
		}

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdRefresh { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.MonthCalendarViewModel calYear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean CalendarLoading { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		new public virtual System.Boolean Visible { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 MINWorking { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean FirstTime { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}