using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
	public class GenericViewModelBinder : System.Web.Mvc.IModelBinder
	{
		public static ViewModelBinderDelegate GenericViewModelBinderDelegate;

		#region IModelBinder Members

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (val != null)
			{
				object value = val.RawValue;
				//TODO
				return GenericViewModelBinderDelegate(controllerContext, bindingContext);
			}
			return null;
		}

		#endregion
	}
}