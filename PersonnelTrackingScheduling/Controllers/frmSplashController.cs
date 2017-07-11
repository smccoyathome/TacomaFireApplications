using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject.Controllers
{

	public class frmSplashController
		: System.Web.Mvc.Controller
	{

		public System.Web.Mvc.ActionResult frmSplash_KeyPress(PTSProject.ViewModels.frmSplashViewModel viewFromClient, object eventSender, int keyCode)
		{
			logic.ViewModel = viewFromClient;
			var charCode = (char)keyCode;
			logic.frmSplash_KeyPress(null, new UpgradeHelpers.Events.KeyPressEventArgs(charCode));
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Frame1_Click(PTSProject.ViewModels.frmSplashViewModel viewFromClient, object eventSender)
		{
			logic.ViewModel = viewFromClient;
			logic.Frame1_Click(null, null);
			return new UpgradeHelpers.WebMap.Server.AppChanges();
		}

		public System.Web.Mvc.ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

        public System.Web.Mvc.ActionResult frmSplash_Close(PTSProject.ViewModels.frmSplashViewModel viewFromClient, object eventSender)
        {
            logic.ViewModel = viewFromClient;
            logic.Closed(0);
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }

        public PTSProject.frmSplash logic { get; set; }

	}

}