using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident.Controllers
{

	public class frmMainController
		: System.Web.Mvc.Controller
	{
		
		public System.Web.Mvc.ActionResult MainTabs_Selecting(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.MainTabs_Selecting(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSysButt3_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSysButt3_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult calUnit_DateChanged(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calUnit_DateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

        public System.Web.Mvc.ActionResult sprUnitList_DoubleClick(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
        {
                logic.sprUnitList_CellDoubleClick(viewFromClient.sprUnitList, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(0, 0));
                return new UpgradeHelpers.WebMap.Server.AppChanges();
        }

        public System.Web.Mvc.ActionResult sprIncident_DoubleClick(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
        {
            logic.sprIncident_CellDoubleClick(viewFromClient.sprIncident, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(viewFromClient.sprIncident.Row, viewFromClient.sprIncident.Col));
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }

        public System.Web.Mvc.ActionResult optBattalion_CheckedChanged(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender, int index)
		{
			logic.ViewModel = viewFromClient;
			logic.optBattalion_CheckedChanged(logic.ViewModel.optBattalion[index], null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnit_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUnit_Leave(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUnit_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboType_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboType_Leave(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboType_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearUnit_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearUnit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboStatus_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboStatus_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboStatus_Leave(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboStatus_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdExitApp_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExitApp_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefreshUnit_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefreshUnit_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		//public System.Web.Mvc.ActionResult cmdRefreshIncident_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		//{
		//	logic.ViewModel = viewFromClient;
		//	logic.cmdRefreshIncident_Click(null, null);
		//	return new UpgradeHelpers.WebMap.Server.AppChanges();
		//}

		public System.Web.Mvc.ActionResult calIncident_DateChanged(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.calIncident_DateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncUnit_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncUnit_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncType_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncType_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboIncType_Leave(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboIncType_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearIncident_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearIncident_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdExit2_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdExit2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdRefreshIncList_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdRefreshIncList_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboFieldReport_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboFieldReport_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSelection1_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSelection1_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSelection2_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSelection2_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdViewReport_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdViewReport_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInquiryList_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInquiryList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboInquiryList_Leave(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboInquiryList_Leave(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboReportList_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboReportList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstFields_SelectedIndexChanged(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstFields_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult lstFilters_SelectedIndexChanged(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.lstFilters_SelectedIndexChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdView_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdView_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClearSelections_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClearSelections_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboSystemAction_SelectionChangeCommitted(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboSystemAction_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult tvHelpList_AfterSelect(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.tvHelpList_AfterSelect(null, viewFromClient.tvHelpList.SelectedNode);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSysButt1_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSysButt1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdSysButt2_Click(TFDIncident.ViewModels.frmMainViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdSysButt2_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public TFDIncident.frmMain logic { get; set; }

	}

}