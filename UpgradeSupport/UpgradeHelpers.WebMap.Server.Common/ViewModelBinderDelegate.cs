using System.Web.Mvc;

namespace UpgradeHelpers.WebMap.Server
{
	public delegate object ViewModelBinderDelegate(ControllerContext ctx, ModelBindingContext bindingContext);
}