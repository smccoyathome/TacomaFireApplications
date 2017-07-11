using System;

namespace UpgradeHelpers.Helpers
{
	[Flags]
	public enum BoxButtons
	{
		OK = 0,
		OKCancel = 1,
		AbortRetryIgnore = 2,
		YesNoCancel = 3,
		YesNo = 4,
		RetryCancel = 5,
	}
}
