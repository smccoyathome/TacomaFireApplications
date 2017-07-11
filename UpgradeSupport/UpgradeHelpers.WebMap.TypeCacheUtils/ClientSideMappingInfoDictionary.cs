using System;
using System.Collections.Generic;

namespace UpgradeHelpers.WebMap.Server
{
    public class TypeInfoEx
    {
        public int ClientSideTypingID;
    }

	public class ClientSideMappingInfoDictionary : Dictionary<Type, int>
	{
        public ClientSideMappingInfoDictionary() : base() { }
    }
}