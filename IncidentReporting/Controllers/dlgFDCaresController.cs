using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class dlgFDCaresController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult OKButton_Click(TFDIncident.ViewModels.dlgFDCaresViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.OKButton_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult CancelButton_Renamed_Click(TFDIncident.ViewModels.dlgFDCaresViewModel viewFromClient, object eventSender)
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

		public TFDIncident.dlgFDCares logic { get; set; }

	}

}