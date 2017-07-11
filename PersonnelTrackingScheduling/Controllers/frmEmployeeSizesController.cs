using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmEmployeeSizesController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult optBunker_CheckedChanged(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optBunker_CheckedChanged(logic.ViewModel.optBunker, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult optUniform_CheckedChanged(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.optUniform_CheckedChanged(logic.ViewModel.optUniform, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdClose_Click(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdClose_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboEmpList_SelectionChangeCommitted(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboEmpList_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkChangeDate_CheckStateChanged(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkChangeDate_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEditUniformSize_Click(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdEditUniformSize_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cboUniformItem_SelectionChangeCommitted(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cboUniformItem_SelectionChangeCommitted(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult txtItemSizeDesc_TextChanged(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.txtItemSizeDesc_TextChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdNewRecord_Click(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.cmdNewRecord_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult chkInDate_CheckStateChanged(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.chkInDate_CheckStateChanged(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult cmdEdit_Click(PTSProject.ViewModels.frmEmployeeSizesViewModel viewFromClient, object eventSender)
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

		public PTSProject.frmEmployeeSizes logic { get; set; }

	}

}