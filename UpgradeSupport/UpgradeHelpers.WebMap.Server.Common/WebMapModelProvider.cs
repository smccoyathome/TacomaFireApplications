using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// Whenever you need to bind a controller parameter with a view model
    /// you can use this attribute.
    /// You only need to decorate the argument.
    /// 
    /// For example
    /// ActionResult button1_click([WebMapModel] ButtonViewModel btn) {
    /// }
    /// 
    /// When the action is called from the client side invoke it with something like:
    /// 
    /// app.sendAction({...,parameters: { btn: ViewModel.button1.UniqueID } };
    /// </summary>
    public class WebMapModelProvider : Attribute,IValueProvider, IModelBinder
    {

        /// <summary>
        /// This delegate is setup on the WebMap Server Helpers Bootstrapping
        /// </summary>
        internal static Func<string, bool> ContainsPrefixDelegate;

        internal static Func<string, ValueProviderResult> GetValueDelegate;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = GetValueDelegate(bindingContext.ModelName);
            if (valueProvider!=null)
            {
                return valueProvider.RawValue;
            }
            return null; 
        }

        /// <summary>
        /// validate if requested key is exist or not
        /// </summary>
        public bool ContainsPrefix(string prefix)
        {
            return ContainsPrefixDelegate(prefix);
        }

        /// <summary>
        /// return ValueProviderResult
        /// </summary>
        public ValueProviderResult GetValue(string key)
        {
            return GetValueDelegate(key);
        }
    }
}
