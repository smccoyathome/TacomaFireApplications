using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class frmHelpController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult tvHelpList_AfterSelect(TFDIncident.ViewModels.frmHelpViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.tvHelpList_AfterSelect(null, viewFromClient.tvHelpList.SelectedNode);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(TFDIncident.ViewModels.frmHelpViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCode_Click(TFDIncident.ViewModels.frmHelpViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCode_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.frmHelp logic { get; set; }

	}

}