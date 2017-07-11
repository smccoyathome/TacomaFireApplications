using Newtonsoft.Json.Serialization;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class ClientTypeValueProvider : IValueProvider
	{
		public ClientTypeValueProvider()
		{
		}

		public void SetValue(object target, object value)
		{
		}

		public object GetValue(object target)
		{
			var itarget = target as IStateObject;
			return TypeCacheUtils.GetModelTypedInt(itarget);
		}

	}
}