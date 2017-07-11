using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgScheduleDetailController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult OKButton_Click(PTSProject.ViewModels.dlgScheduleDetailViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.OKButton_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.dlgScheduleDetail logic { get; set; }

	}

}