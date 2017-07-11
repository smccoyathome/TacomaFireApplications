using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmAddressController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cboEmpList_SelectionChangeCommitted(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEmpList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstAddress_SelectedIndexChanged(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstAddress_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdUpdate_Click(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdUpdate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdDelete_Click(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdDelete_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmAddressViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmAddress logic { get; set; }

	}

}