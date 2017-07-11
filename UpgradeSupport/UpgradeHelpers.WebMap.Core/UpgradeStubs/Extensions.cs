using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Utils
{
	public static partial class Extensions
	{
		public static string resources_GetObject(this IViewModel view, string name)
		{
			//AIS-TODO: Image must be converted to string?
			return null;
		}

		public static void LoadControl<T>(this ILogicWithViewModel<IViewModel> logic, string name, int index)
		{
			//throw new NotImplementedException();
		}

        public static int GetControlIndex(this ILogicWithViewModel<IViewModel> logic)
		{
			throw new NotImplementedException();
		}


	}
}
