using System.Configuration;

namespace UpgradeHelpers.WebMap.Server.Common.Config
{
	/// <summary>
	/// Defines a WebMAP known type element.
	/// </summary>
	public class KnownType : ConfigurationElement
	{
		/// <summary>
		/// Name of the class to register
		/// </summary>
		[ConfigurationProperty("fullClassName", IsRequired = true)]
		public string FullClassName
		{
			get { return (string)this["fullClassName"]; }
		}

		/// <summary>
		/// Name of the assembly where the class is declared
		/// </summary>
		[ConfigurationProperty("assemblyName", IsRequired = true)]
		public string AssemblyName
		{
			get { return (string)this["assemblyName"]; }
		}

		/// <summary>
		/// Short name used as stateManager key instead of full class name
		/// </summary>
		[ConfigurationProperty("shortName", IsRequired = true)]
		public string ShortName
		{
			get { return (string)this["shortName"]; }
		}

	}
}