using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmIndivSchedNoteController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdOK_Click(PTSProject.ViewModels.frmIndivSchedNoteViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdOK_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCancel_Click(PTSProject.ViewModels.frmIndivSchedNoteViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCancel_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmIndivSchedNote logic { get; set; }

	}

}