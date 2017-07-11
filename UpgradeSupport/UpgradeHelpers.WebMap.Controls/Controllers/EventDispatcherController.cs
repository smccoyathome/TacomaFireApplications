using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.BasicViewModels;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Controls.Controllers
{
    /// <summary>
    /// This controller has the operations related with the UltraGrid widget.
    /// </summary>
    public class EventDispatcherController : Controller
    {
        public IViewManager ViewManager { get; set; }

        public System.Web.Mvc.ActionResult ProcessMessage(IStateObject viewFromClient, string eventID)
        {
            if (viewFromClient != null)
                ViewManager.Events.Publish(eventID, viewFromClient, viewFromClient, new EventArgs());
            return new UpgradeHelpers.WebMap.Server.AppChanges();
        }
    }
}
