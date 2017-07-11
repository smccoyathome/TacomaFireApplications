using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmInsteadOfSCKLeaveController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult dtStart_Click(PTSProject.ViewModels.frmInsteadOfSCKLeaveViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtStart_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmInsteadOfSCKLeaveViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtEnd_Click(PTSProject.ViewModels.frmInsteadOfSCKLeaveViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtEnd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmInsteadOfSCKLeaveViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmInsteadOfSCKLeave logic { get; set; }

	}

}