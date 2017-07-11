using System;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Exception triggered when the delegate for the AppState Action Result has not been set.
	/// This must be setup on Application Startup.
	/// This delegate will be called when the ExecutResult method is triggered
	/// </summary>
	public class AppStateResultDelegateHasNotBeenSet : Exception
	{
		public AppStateResultDelegateHasNotBeenSet()
			: base(message: "The static AppStateDelegate must be set on application init")
		{
		}
	}
}
