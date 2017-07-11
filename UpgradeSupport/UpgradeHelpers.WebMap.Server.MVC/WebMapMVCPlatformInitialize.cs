using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using UpgradeHelpers.WebMap.Server;


[Export(typeof(IPlatformInitializer))]
//[ExportMetadata("Name", "MVC")]
public class WebMapMVCPlatformInitialize : IPlatformInitializer
{
    public void Initialize()
    {
        WebMapModelProvider.ContainsPrefixDelegate = WebMapModelProviderDelegates.ContainsPrefix;
        WebMapModelProvider.GetValueDelegate = WebMapModelProviderDelegates.GetValue;

        var routes = System.Web.Routing.RouteTable.Routes;
        routes.MapRoute(
                    name: "ViewManager",
                    url: "WebMapViewManager/{action}/{id}",
                    defaults: new { controller = "WebMapViewManager", id = UrlParameter.Optional }, namespaces: new string[] { typeof(WebMapViewManagerController).Namespace });
        ControllerBuilder.Current.SetControllerFactory(typeof(WebMapControllerFactory));

        //ViewModel syncronization each time that an Http Header is identifier
        ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
        ValueProviderFactories.Factories.Add(new JSONAjaxValueProvider());
        AppState.AppStateDelegate = (x) => StateManager.Current.GenerateCurrentStateAsJSON(x);
        AppChanges.AppChangesDelegate = StateManager.GenerateAppChanges;

    }
}

