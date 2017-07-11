using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgSpecialtiesController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult OptParamedic_CheckedChanged(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.OptParamedic_CheckedChanged(logic.ViewModel.OptParamedic, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optFCCDispatcher_CheckedChanged(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optFCCDispatcher_CheckedChanged(logic.ViewModel.optFCCDispatcher, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult OptTempUpgrade_CheckedChanged(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.OptTempUpgrade_CheckedChanged(logic.ViewModel.OptTempUpgrade, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult OptOmitBCList_CheckedChanged(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.OptOmitBCList_CheckedChanged(logic.ViewModel.OptOmitBCList, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRemove_Click(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRemove_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSaveUpdate_Click(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSaveUpdate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboJobCode_SelectionChangeCommitted(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboJobCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSaveReason_Click(PTSProject.ViewModels.dlgSpecialtiesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSaveReason_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.dlgSpecialties logic { get; set; }

	}

}