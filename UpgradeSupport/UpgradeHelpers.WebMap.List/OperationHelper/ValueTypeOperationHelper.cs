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
	[ExportMetadata("Name", "ValueType")]
	internal class ValueTypeOperationHelper : OperationHelperBase, IOperationHelper
	{
		public bool ContainsOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			return ProcessContainsForValueType(services, ctx, item);
		}

		public object GetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			object item = (object)ProcessIndexGetterForMostCases(services,ctx,index);
			return item;
		}

		public object GetItemInfoToSerialize(object item)
		{
			return item;
		}

		public int IndexOfOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			return ProcessIndexOfForValueType(services, ctx, item);
		}

		public void InsertOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item, int index, object parent)
		{
			ProcessInsertionForMostCases(services, ctx, item, index,parent);
		}

		public void RemoveAtOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			ProcessRemoveAtForMostCases(services, ctx, index);
		}

		public bool RemoveOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			return ProcessDeletionForValueType(services, ctx, item);
		}

		public void SetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value)
		{
			this.ProcessIndexSetterForMostCases(services, ctx, index, value);
		}
	}
}
