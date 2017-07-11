using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmAdjustAssignController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult opbEmp_CheckedChanged(PTSProject.ViewModels.frmAdjustAssignViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.opbEmp_CheckedChanged(logic.ViewModel.opbEmp[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdDone_Click(PTSProject.ViewModels.frmAdjustAssignViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdDone_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmAdjustAssign logic { get; set; }

	}

}