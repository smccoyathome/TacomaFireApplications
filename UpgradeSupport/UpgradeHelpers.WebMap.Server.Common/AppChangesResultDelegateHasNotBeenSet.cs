using System;

namespace UpgradeHelpers.WebMap.Server
{

	/// <summary>
	/// Exeption triggered when the delegate for the AppChanges Action Result has not been set.
	/// This must be setup on Application Startup.
	/// This delegate will be called when the ExecutResult method is triggered
	/// </summary>
	public class AppChangesResultDelegateHasNotBeenSet : Exception
	{
		public AppChangesResultDelegateHasNotBeenSet() : base(message: "The static AppChangesDelegate must be set on application init")
		{
		}
	}
}