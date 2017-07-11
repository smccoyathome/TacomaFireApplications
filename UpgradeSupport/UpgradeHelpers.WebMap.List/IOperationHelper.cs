// *************************************************************************************
// <copyright  company="Mobilize" file="IOperationHelper.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace UpgradeHelpers.WebMap.List
{
	public interface IOperationHelper
	{
        void InsertOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item, int index, object parent);

        bool RemoveOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object value);

        void RemoveAtOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index);

        bool ContainsOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item);

        int IndexOfOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item);

        object GetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index);

        void SetterOperation(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value);
    }
}
