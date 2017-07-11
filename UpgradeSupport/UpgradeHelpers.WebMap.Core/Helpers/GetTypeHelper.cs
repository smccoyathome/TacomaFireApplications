using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Extensions
{
	public static class GetTypeHelper
	{
		public static Type GetObjectType(this object element)
		{
			if (element is IStateObject && element.GetType().Name.StartsWith("Wrapped_"))
			{
				return element.GetType().BaseType;
			}
			return element.GetType();
		}
	}
}
