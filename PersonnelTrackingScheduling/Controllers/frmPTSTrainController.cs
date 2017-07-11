using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmPTSTrainController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult calTrainDate_MouseUp(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calTrainDate_MouseUp(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnitList_SelectionChangeCommitted(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnitList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(logic.ViewModel.cmdAdd[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemove_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemove_Click(logic.ViewModel.cmdRemove[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstSpecific_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstSpecific_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboHours_SelectionChangeCommitted(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboHours_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboHours_TextChanged(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboHours_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSave_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSave_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmPTSTrainViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmPTSTrain logic { get; set; }

	}

}