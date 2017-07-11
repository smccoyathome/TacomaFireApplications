using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface IAsyncBuilderManager
	{
		T Return<T>(Func<T> returnFunc);
		TR Return<T,TR>(Func<T,TR> returnFunc);
		T Continue<T>();
		void Return();
		void LoopBreak();
		void LoopContinue();
		WebMap.Helpers.AsyncBuilder AsyncBuilder(bool topBuilder);
		WebMap.Helpers.AsyncBuilder<T> AsyncBuilder<T>(bool topBuilder);
	}
}
