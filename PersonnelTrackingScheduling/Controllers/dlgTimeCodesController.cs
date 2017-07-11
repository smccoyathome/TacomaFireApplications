using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class dlgTimeCodesController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optTimeCode_CheckedChanged(PTSProject.ViewModels.dlgTimeCodesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optTimeCode_CheckedChanged(logic.ViewModel.optTimeCode, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optJobCode_CheckedChanged(PTSProject.ViewModels.dlgTimeCodesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optJobCode_CheckedChanged(logic.ViewModel.optJobCode, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optOrderCode_CheckedChanged(PTSProject.ViewModels.dlgTimeCodesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optOrderCode_CheckedChanged(logic.ViewModel.optOrderCode, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optLeaveAllowed_CheckedChanged(PTSProject.ViewModels.dlgTimeCodesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optLeaveAllowed_CheckedChanged(logic.ViewModel.optLeaveAllowed, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(PTSProject.ViewModels.dlgTimeCodesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.CancelButton_Renamed_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.dlgTimeCodes logic { get; set; }

	}

}