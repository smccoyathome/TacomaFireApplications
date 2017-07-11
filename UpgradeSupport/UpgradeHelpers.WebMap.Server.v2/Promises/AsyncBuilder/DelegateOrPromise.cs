using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal class DelegateOrPromise
	{
		public Delegate @Delegate;
		public IPromise Promise;
		public IPromise CreatedPromise;
	}
}
