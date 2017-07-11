using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface ILifeCycle : IDisposable
	{
		void LifeCycleStartup(IControlWithState parent = null);
		bool ExecuteLifeCycleShutdown();
	}
}

