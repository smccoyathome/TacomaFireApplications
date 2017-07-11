using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmIndAvailableToWorkController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult calAvail_DateChanged(PTSProject.ViewModels.frmIndAvailableToWorkViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calAvail_DateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(PTSProject.ViewModels.frmIndAvailableToWorkViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.CancelButton_Renamed_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.frmIndAvailableToWorkViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdDelete_Click(PTSProject.ViewModels.frmIndAvailableToWorkViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdDelete_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmIndAvailableToWork logic { get; set; }

	}

}