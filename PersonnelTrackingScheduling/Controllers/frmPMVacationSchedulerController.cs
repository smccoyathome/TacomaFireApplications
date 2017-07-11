using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmPMVacationSchedulerController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmPMVacationScheduler_Activated(PTSProject.ViewModels.frmPMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmPMVacationScheduler_Activated(logic.ViewModel, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult frmPMVacationScheduler_Deactivate(PTSProject.ViewModels.frmPMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmPMVacationScheduler_Deactivate(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calYear_Click(PTSProject.ViewModels.frmPMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calYear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmPMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmPMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmPMVacationScheduler logic { get; set; }

	}

}