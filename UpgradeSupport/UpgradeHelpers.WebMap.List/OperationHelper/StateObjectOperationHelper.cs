using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;

namespace UpgradeHelpers.WebMap.List.OperationHelper
{
	[Export(typeof(IOperationHelper))]
	[ExportMetadata("Name", "StateObject")]
	public class StateObjectOperationHelper : OperationHelperBase, IOperationHelper
	{
		public bool ContainsOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			return ProcessContainsForMostCases(services,ctx,item);
		}

		public object GetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			object item = ProcessIndexGetterForMostCases(services,ctx,index);
			return item;
		}

		public object GetItemInfoToSerialize(object item)
		{
			IStateObject stateobject = (IStateObject)item;
			return stateobject.UniqueID;
		}

		public int IndexOfOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			return ProcessIndexOfForMostCases(services,ctx,item);
		}

		public void InsertOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item, int index, object parent)
		{
            ProcessInsertionForMostCases(services, ctx, item, index, parent);
		}

		public void RemoveAtOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			ProcessRemoveAtForMostCases(services,ctx,index);
		}
		
		public bool RemoveOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object value)
		{
			return ProcessDeletionForMostCases(services,ctx,value);
		}

		public void SetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value)
		{
			this.ProcessIndexSetterForMostCases(services,ctx, index, value);
		}
	}
}
