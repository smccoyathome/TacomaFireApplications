using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmSchedNoteQueryController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdExit_Click(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtStartDate_Click(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtStartDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtStartDate_ValueChanged(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtStartDate_ValueChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtEndDate_Click(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtEndDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dtEndDate_ValueChanged(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dtEndDate_ValueChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtCommentSearch_TextChanged(PTSProject.ViewModels.frmSchedNoteQueryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtCommentSearch_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmSchedNoteQuery logic { get; set; }

	}

}