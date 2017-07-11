using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface IExceptionManager : IDisposable
	{
		void AppendFinally(Action action);
		void HandleException<T>(T ex) where T : Exception;
		void ExecuteFinally();
		void AppendCatch<T>(Action<T> action) where T : Exception;
	}
}
