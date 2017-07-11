using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Server
{
	public interface IReferenceWatcher
	{
		void UpdateReference(string oldUniqueID, string newUniqueID);
	}
}
