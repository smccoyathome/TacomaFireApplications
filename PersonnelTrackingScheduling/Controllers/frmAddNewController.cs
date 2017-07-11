using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmAddNewController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult txtSAPEmpID_Leave(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtSAPEmpID_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSwitch_Click(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSwitch_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtMName_Leave(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtMName_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboJobCode_SelectionChangeCommitted(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboJobCode_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtSex_TextChanged(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtSex_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAdd_Click(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAdd_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAssign_Click(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAssign_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmAddNewViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmAddNew logic { get; set; }

	}

}