// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="SpreadController.cs" >
// //      Copyright (c) 2017 Mobilize, Inc. All Rights Reserved.
// //      All classes are provided for customer use only,
// //      all other use is prohibited without prior written consent from Mobilize.Net.
// //      no warranty express or implied,
// //      use at own risk.
// // </copyright>
// // <summary></summary>
// // ************************************************************************************* 

namespace FarPoint.ViewModels.Controllers
{
    using System.Web.Mvc;
    using System.Web.Script.Services;

    using FarPoint.Converters;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     Kendo Spread Service to load the spread from WebMap
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class SpreadController : Controller
    {
        /// <summary>
        /// Changes the specified unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="spreadName">Name of the spread.</param>
        /// <param name="changes">The changes.</param>
        public JsonResult Change(string uniqueId, string changes)
        {
            var cellChanges = JArray.Parse(changes);
            var spread = GetFpSpreadViewModel(uniqueId);
            if (spread != null)
            {
                foreach (var change in cellChanges)
                {
                    var row = (int)change["row"];
                    var column = (int)change["column"];
                    var value = change["value"]["value"].ToString();
                    spread.ActiveSheet.Cells[row, column].Value = value;
                }
            }
            return new JsonResult { Data = "{\"Status\"=\"Ok\"}" };
        }

        /// <summary>
        ///     Default operation of the service.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="spreadName">Name of the spread.</param>
        /// <returns>a JSON from the WebMapSpread to use in kendo spreadSheet</returns>
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JsonResult Index(string uniqueId)
        {
            JsonResult result = new JsonResult();
            var spread = GetFpSpreadViewModel(uniqueId);
            if (spread != null)
            {
                result = this.Json(
                    JsonConvert.SerializeObject(spread, Formatting.Indented, new KendoSpreadSheetConverter()));
            }

            return result;
        }

        /// <summary>
        /// Gets the farPoint spread view model from WebMap.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="spreadName">Name of the spread.</param>
        /// <returns>an SpreadViewModel of the spreadName</returns>
        private static FpSpreadViewModel GetFpSpreadViewModel(string uniqueId)
        {
            var viewManager = StaticContainer.Instance.Resolve<IViewManager>();
            var spread = viewManager.GetParentViewModel(() => uniqueId);
            //var propertyInfo = formViewModel.GetType().GetProperty(spreadName);
            //var spread = propertyInfo != null ? (FpSpreadViewModel)propertyInfo.GetValue(formViewModel) : null;
            return spread as FpSpreadViewModel;
        }
    }
}