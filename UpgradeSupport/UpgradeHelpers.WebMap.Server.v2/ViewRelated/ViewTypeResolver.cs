using System;
using System.Reflection;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal class ViewTypeResolver : IViewTypeResolver
	{
		public Type GetLogicTypeFromAttribute(IViewModel topLevelViewModel)
		{
			var topLevelViewModelType = topLevelViewModel.GetType();
			var logicAttribute = topLevelViewModelType.GetCustomAttribute(typeof(LogicAttribute)) as LogicAttribute;
			if (logicAttribute == null) throw new InvalidOperationException(string.Format("The view model class {0} does not have a Logic attribute. Add an attribute like '[LogicType = typeof(LogicClass))]'", topLevelViewModelType.FullName));
			var logicType = logicAttribute.Type;
			return logicType;
		}

	}
}
