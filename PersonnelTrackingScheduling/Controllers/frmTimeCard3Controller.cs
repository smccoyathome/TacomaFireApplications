using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmTimeCard3Controller
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrintAll_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrintAll_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdExcept_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExcept_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdLeave_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdLeave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calDate_Click(PTSProject.ViewModels.frmTimeCard3ViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmTimeCard3 logic { get; set; }

	}

}