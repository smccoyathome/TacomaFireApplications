using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmMakeShiftAvailableController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult calAvail_DateChanged(PTSProject.ViewModels.frmMakeShiftAvailableViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calAvail_DateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAvailDone_Click(PTSProject.ViewModels.frmMakeShiftAvailableViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAvailDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmMakeShiftAvailableViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmMakeShiftAvailable logic { get; set; }

	}

}