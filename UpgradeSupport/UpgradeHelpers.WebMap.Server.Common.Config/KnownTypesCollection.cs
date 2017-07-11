using System.Configuration;

namespace UpgradeHelpers.WebMap.Server.Common.Config
{
	/// <summary>
	/// Defines a collection of known types.
	/// </summary>
	public class KnownTypesCollection : ConfigurationElementCollection
	{
		public KnownTypesConfigSection this[int index]
		{
			get
			{
				return BaseGet(index) as KnownTypesConfigSection;
			}
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}

		public new KnownTypesConfigSection this[string name]
		{
			get
			{
				return BaseGet(name) as KnownTypesConfigSection;
			}
			set
			{
				int index = -1;
				if (BaseGet(name) != null)
				{
					index = BaseIndexOf(BaseGet(name));
					BaseRemove(name);
				}

				if (index == -1)
				{
					BaseAdd(value);
				}
				else
				{
					BaseAdd(index, value);
				}
			}
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new KnownType();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((KnownType)element).FullClassName;
		}
	}
}