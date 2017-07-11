using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmUniformRepairHistoryController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdFind_Click(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdFind_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkDateIn_CheckStateChanged(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkDateIn_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkDateOut_CheckStateChanged(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkDateOut_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNewItem_Click(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNewItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEdit_Click(PTSProject.ViewModels.frmUniformRepairHistoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdEdit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmUniformRepairHistory logic { get; set; }

	}

}