using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal interface IAsyncBuilder : IDisposable
	{
		List<DelegateOrPromise> Delegates { get; set; }
		string FamilyId { get; set; }
		string UniqueId { get; set; }
		bool HasAppendedPromises { get; set; }
		IAsyncBuilder Parent { get; set; }
		event UpgradeHelpers.WebMap.Server.AsyncBuilderUtils.OnDiposeBuilder DisposeBuilder;
		IExceptionManager ExceptionManager { get; }
		bool HasExceptionManager();
	}
}
