using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmPPEInventoryController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult cmdExit_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboLocation_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboLocation_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboBrand_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboBrand_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClear_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClear_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboType_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboColorSize_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboColorSize_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefresh_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefresh_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkInactive_CheckStateChanged(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkInactive_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdPrint_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdPrint_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNewItem_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNewItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkManufDate_CheckStateChanged(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkManufDate_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboStation_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboStation_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtTrackingNumber_TextChanged(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtTrackingNumber_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dteManufDate_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dteManufDate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEditItem_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdEditItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdFind_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdFind_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRetireItem_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRetireItem_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdReactivate_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdReactivate_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboItemType_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboItemType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboItemColorSize_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboItemColorSize_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboItemBrand_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboItemBrand_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRepair_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRepair_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboReason_SelectionChangeCommitted(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboReason_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult dteRetired_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.dteRetired_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdCleaning_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdCleaning_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdLastInsp_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdLastInsp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdAddNew_Click(PTSProject.ViewModels.frmPPEInventoryViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdAddNew_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public PTSProject.frmPPEInventory logic { get; set; }

	}

}