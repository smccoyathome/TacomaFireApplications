using Newtonsoft.Json;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	public class ClientCommand
	{
        [JsonIgnore]
        internal bool isOneWay;

        public string id { get; set; }
		public string UniqueID { get; set; }
		public string Continuation_UniqueID { get; set; }
		public object parameters {get;set;}
    }
}