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
	[ExportMetadata("Name", "Object")]
	public class ObjectOperationHelper : OperationHelperBase, IOperationHelper
	{
		public bool ContainsOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			if (typeof(IStateObject).IsAssignableFrom(item.GetType()))
			{
				return ProcessContainsForMostCases(services,ctx,item);
			}
			else if (item.GetType().IsValueType || item.GetType() == typeof(String))
			{
				return ProcessContainsForValueType(services,ctx,item);
			}
			else if (services.SurrogateManager.IsSurrogateRegistered(item.GetType()))
			{
				IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
				return ProcessContainsForMostCases(services,ctx,baptizedItem);
			}
			else
			{
				throw new NotSupportedException();
			}
		}

		public object GetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			object item = ProcessIndexGetterForMostCases(services,ctx,index);
			
			if (typeof(IStateObjectSurrogate).IsAssignableFrom(item.GetType()))
			{
				return ((IStateObjectSurrogate)item).Value;
			}
			else
				return item;
		}

		public object GetItemInfoToSerialize(object item)
		{
			if (typeof(IStateObject).IsAssignableFrom(item.GetType()))
			{
				return (item as IStateObject).UniqueID;
			}
			else if (item.GetType().IsValueType || item.GetType() == typeof(String))
			{
				return item;
			}
			else if (typeof(IStateObjectSurrogate).IsAssignableFrom(item.GetType()))
			{
				return (item as IStateObjectSurrogate).UniqueID;
			}
			return null;
		}

		public int IndexOfOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			if (typeof(IStateObject).IsAssignableFrom(item.GetType()))
			{
				return ProcessIndexOfForMostCases(services,ctx, item);
			}
			else if (item.GetType().IsValueType || item.GetType() == typeof(String))
			{
				return ProcessIndexOfForValueType(services,ctx, item);
			}
			else if (services.SurrogateManager.IsSurrogateRegistered(item.GetType()))
			{
				IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
				return ProcessIndexOfForMostCases(services,ctx,baptizedItem);
			}
			else
			{
				throw new NotSupportedException();
			}
		}

		public void InsertOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item,int index, object parent)
		{
            if (services.SurrogateManager.IsSurrogateRegistered(item.GetType()))
            {
                IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
                services.SurrogateManager.AddSurrogateReference(baptizedItem, (IStateObject)parent);
                ProcessInsertionForMostCases(services, ctx, baptizedItem, index, parent);

            }
            else
                ProcessInsertionForMostCases(services, ctx, item, index, parent);
		}

		public void RemoveAtOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
            ProcessRemoveAtForMostCases(services, ctx, index);
		}

		public bool RemoveOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			bool removed = false;
			if (typeof(IStateObject).IsAssignableFrom(item.GetType()))
			{
				removed = ProcessDeletionForMostCases(services,ctx,item);
			}
			else if (item.GetType().IsValueType || item.GetType() == typeof(String))
			{
				removed = ProcessDeletionForValueType(services,ctx,item);
			}
			else if (services.SurrogateManager.IsSurrogateRegistered(item.GetType()))
			{
				IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(item, true);
				if(baptizedItem != null)
					removed = ProcessDeletionForMostCases(services,ctx,baptizedItem);
				else
					throw new Exception();
			}
			else
			{
				throw new NotSupportedException();
			}
			return removed;
		}

		public void SetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value)
		{
			if (services.SurrogateManager.IsSurrogateRegistered(value.GetType()))
			{
				IStateObjectSurrogate baptizedItem = services.SurrogateManager.GetStateObjectSurrogate(value, true);
				if (baptizedItem != null)
					ProcessIndexSetterForMostCases(services, ctx,index, baptizedItem);
			}
			else
			{
				ProcessIndexSetterForMostCases(services,ctx,index, value);

			}
		}
	}
}
