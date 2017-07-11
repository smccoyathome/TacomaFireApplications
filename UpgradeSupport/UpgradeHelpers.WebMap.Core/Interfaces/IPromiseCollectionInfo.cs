using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Interfaces
{
	public interface IPromiseCollectionInfo<T> : IDependentModel
	{
		int Current { get; set; }
		IList<T> List { get; set; }
		bool LoopCondition();
		void Next();
		T Item();
	}
}
