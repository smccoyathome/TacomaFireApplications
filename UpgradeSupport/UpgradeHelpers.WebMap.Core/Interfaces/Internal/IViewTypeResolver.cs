using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Interfaces
{
	public interface IViewTypeResolver
	{
		Type GetLogicTypeFromAttribute(IViewModel topLevelViewModel);
	}
}
