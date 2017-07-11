using System;
using System.Configuration;

namespace UpgradeHelpers.WebMap.Server.Common.Config
{
	/// <summary>
	/// Defines a configuration section where to WebMAP known types are declared.  Known types
	/// are used to serialize $type element in a shorter way.
	/// </summary>
	public class KnownTypesConfigSection : ConfigurationSection
	{

		/// <summary>
		/// Defines the list of known type elements.
		/// </summary>
		[ConfigurationProperty("knownTypes", IsRequired = true)]
		public KnownTypesCollection KnownTypes
		{
			get
			{
				return this["knownTypes"] as KnownTypesCollection;
			}
		}

		/// <summary>
		/// Enables or disables known types stateManager
		/// </summary>
		[ConfigurationProperty("enabled", IsRequired = false, DefaultValue = true)]
		public Boolean Enabled
		{
			get { return (bool)this["enabled"]; }
		}
	}
}