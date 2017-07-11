using System.Configuration;

namespace TFDIncident.Configuration
{
    public static class SettingsManager
    {
        public static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}