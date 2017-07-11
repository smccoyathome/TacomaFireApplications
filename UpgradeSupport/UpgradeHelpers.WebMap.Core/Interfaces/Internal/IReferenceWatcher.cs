using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server
{
	internal interface IReferenceWatcher
	{
		void UpdateReference(string oldUniqueID, string newUniqueID);
	}
}
