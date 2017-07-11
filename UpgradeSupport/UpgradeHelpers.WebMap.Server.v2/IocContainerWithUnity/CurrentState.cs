using System.Collections.Generic;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
    internal class CurrentState
	{
		public ViewsState VD;
		public IList<IStateObject> MD;
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object MDT;
		public string NV;
	}
}