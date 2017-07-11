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
	[ExportMetadata("Name", "Surrogate")]
	public class SurrogateOperationHelper : OperationHelperBase, IOperationHelper
	{
		public bool ContainsOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
			return ProcessContainsForMostCases(services,ctx,baptizedItem);
		}

		public object GetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			IStateObjectSurrogate item = (IStateObjectSurrogate) ProcessIndexGetterForMostCases(services,ctx,index);
			return item.Value;
		}

		public object GetItemInfoToSerialize(object item)
		{
			IStateObjectSurrogate baptizedItem = (IStateObjectSurrogate)item;
			return baptizedItem.UniqueID;
		}

		public int IndexOfOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
			return ProcessIndexOfForMostCases(services,ctx,baptizedItem);
		}

		public void InsertOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item, int index, object parent )
		{
			//The item is a pure object, which is not yet be encapsulated into a StateObjectSurrogate
			//We are going to baptize the item
			IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);

			//Should I register a Posible orphan for this baptizedItem?
            services.SurrogateManager.AddSurrogateReference(baptizedItem, (IStateObject)parent);

			ProcessInsertionForMostCases(services, ctx, baptizedItem, index, parent);
		}

		public void RemoveAtOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			ProcessRemoveAtForMostCases(services, ctx, index);
		}

		public bool RemoveOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			//The item is a pure object, which is not yet be encapsulated into a StateObjectSurrogate
			//We are going to baptize the item
			IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
			return ProcessDeletionForMostCases(services,ctx,baptizedItem);
		}

		public void SetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value)
		{
			IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(value, true);
			if (baptizedItem != null)
				this.ProcessIndexSetterForMostCases(services,ctx,index, baptizedItem);
		}
	}
}
