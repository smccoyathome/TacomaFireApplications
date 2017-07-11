using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace UpgradeHelpers.WebMap.List
{
    public static class MEFManager
	{

		public static Dictionary<VirtualListTypeEnum, IOperationHelper> OperationHelpers = LoadOperations();

		public static Dictionary<VirtualListTypeEnum, IOperationHelper> LoadOperations()
		{
			Dictionary<VirtualListTypeEnum, IOperationHelper> operationHelperDict = new Dictionary<VirtualListTypeEnum, IOperationHelper>();
			CompositionContainer _container;
			//An aggregate catalog that combines multiple catalogs
			var catalog = new AggregateCatalog();
			//Adds all the parts found in the same assembly as the Program class
			catalog.Catalogs.Add(new AssemblyCatalog(typeof(VirtualList<>).Assembly));

			//Create the CompositionContainer with the parts in the catalog
			_container = new CompositionContainer(catalog);
			//Fill the imports of this object
			try
			{
					foreach(var i in _container.GetExports<IOperationHelper, OperationTypeName>())
					{
						var key = (VirtualListTypeEnum) Enum.Parse(typeof(VirtualListTypeEnum),i.Metadata.Name);
						var value = i.Value;
						operationHelperDict.Add(key, value);
					}
					return operationHelperDict;
			}
			catch (CompositionException compositionException)
			{
				Console.WriteLine(compositionException.ToString());
			}
			return null;
		}

		
	}
}
