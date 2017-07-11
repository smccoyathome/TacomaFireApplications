using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Extensions
{
	public static class RectangleExtensions
	{
		[Obsolete("Extension only provided for compilation purposes")]
		public static Rectangle Get_ClientRectangle(this IViewModel instance)
		{
			return new Rectangle();
		}

		[Obsolete("Extension only provided for compilation purposes")]
		public static Rectangle GetClientRectangle(this IViewModel instance)
		{
			return new Rectangle();
		}

	}
}
