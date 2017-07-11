using System.Web.Mvc;
using UpgradeHelpers.WebMap.Server;

namespace WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ViewManagerRequestStartAndEndActionFilter() { Order = 1 });
            filters.Add(new SessionExpireFilterAttribute());
            filters.Add(new PromisesActionFilter());
        }
    }
}