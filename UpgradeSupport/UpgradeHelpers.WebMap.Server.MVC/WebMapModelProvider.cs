using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// Implements the delegates for the WebMapModel 
    /// </summary>
    internal static class WebMapModelProviderDelegates 
    {

        internal static bool ContainsPrefix(string prefix)
        {
            var jobj = StateManager.Current.lastRequestFromClient;
            if (jobj != null && jobj[prefix] != null)
            {
                return true;
            }
            return false;
        }
        public static ValueProviderResult GetValue(string key)
        {
            var jobj = StateManager.Current.lastRequestFromClient;
            if (jobj != null)
            { }
            JToken tok = jobj[key];
            string modelUID = tok != null ? tok.Value<string>() : null;
            if (modelUID != null)
            {
                var actualObject = StateManager.Current.GetObject(modelUID);
                // lets update the container of controller logic with view model context
                return new ValueProviderResult(actualObject, "json", CultureInfo.CurrentCulture);
            }
            return null;
        }

    }
}