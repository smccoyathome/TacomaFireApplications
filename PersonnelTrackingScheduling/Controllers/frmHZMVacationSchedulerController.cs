using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmHZMVacationSchedulerController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmHZMVacationScheduler_Activated(PTSProject.ViewModels.frmHZMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmHZMVacationScheduler_Activated(logic.ViewModel, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult frmHZMVacationScheduler_Deactivate(PTSProject.ViewModels.frmHZMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.frmHZMVacationScheduler_Deactivate(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calYear_Click(PTSProject.ViewModels.frmHZMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calYear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmHZMVacationSchedulerViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmHZMVacationSchedulerViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmHZMVacationScheduler logic { get; set; }

	}

}