using System.Runtime.InteropServices;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace UpgradeSolution1Support.PInvoke.SafeNative
{
	public static class kernel32
	{

		public static void Sleep(int dwMilliseconds)
		{
			UpgradeSolution1Support.PInvoke.UnsafeNative.kernel32.Sleep(dwMilliseconds);
		}
	}
}