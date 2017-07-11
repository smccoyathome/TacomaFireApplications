using UpgradeHelpers.Interfaces;
namespace WebSite
{
    public partial class Startup
    {
        public static void EntryPoint(IIocContainer container)
        {
            TFDIncident.IncidentMain.Main(container);
        }
    }
}

