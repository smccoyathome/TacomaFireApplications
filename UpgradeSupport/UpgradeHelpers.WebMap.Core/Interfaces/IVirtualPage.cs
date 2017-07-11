using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface IVirtualPage : IStateObject
	{
		object Parent { get; set; }

        List<object> StoredObjects { get; set; }
    }
}
