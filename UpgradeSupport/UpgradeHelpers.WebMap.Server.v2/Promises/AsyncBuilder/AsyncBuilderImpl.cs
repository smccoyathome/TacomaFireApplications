using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	internal class AsyncBuilderImpl : AsyncBuilderImplBase
	{
		protected override void ValidateDelegates()
		{
			ValidateLastPromise();
		}
		/// <summary>
		/// Validates that the last promise does not return a value.
		/// </summary>
		private void ValidateLastPromise()
		{
			var last = Delegates.LastOrDefault();
			
			//The last Promise must not return a value
			if (last != null)
			{
				var lastDelegate = last.Delegate;
				if (lastDelegate != null)
				{
					var methodInfo = lastDelegate.GetMethodInfo();
					if (methodInfo.ReturnType != AsyncBuilderUtils.TYPE_OF_VOID)
					{
                        string AdditionalInfo = "";
#if DEBUG
                        if (last.CreatedPromise != null)
                        {
                            AdditionalInfo += "Check inconsistency for promise: " + ((BasePromiseInfo)(last.CreatedPromise)).UserCodeInfo;
                        }
#endif
                        var message = string.Format("Invalid promises chain. This async block need an Action but an function returning {0} is being appened. {1}", methodInfo.ReturnType.FullName, AdditionalInfo);
                        throw new InvalidOperationException(message);
					}
				}
			}
		}
	}
}
