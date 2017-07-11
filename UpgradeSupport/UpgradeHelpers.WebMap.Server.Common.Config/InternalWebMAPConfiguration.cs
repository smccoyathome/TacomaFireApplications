using System.Configuration;

namespace UpgradeHelpers.WebMap.Server.Common.Config
{
	/// <summary>
	/// Defines a helper class used to get information about the known type stateManager.
	/// </summary>
	public static class InternalWebMAPConfiguration
	{
		public static KnownTypesConfigSection KnownTypesConfiguration
		{
			get
			{
				var config = (KnownTypesConfigSection)ConfigurationManager.GetSection("WebMAP/knownTypesCache");
				return config;
			}
		}
	}
}