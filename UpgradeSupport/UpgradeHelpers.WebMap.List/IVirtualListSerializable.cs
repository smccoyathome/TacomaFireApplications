// *************************************************************************************
// <copyright  company="Mobilize" file="IVirtualListSerializable.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.List
{
    public interface IVirtualListSerializable: IWebMapList
	{
		Dictionary<string, int> InitialPositionOfEachPage { get; set; }

		List<string> PageUniqueIdOfTheIndexes { get; set; }

        VirtualListTypeEnum ListType { get; set; }

		void InitializeOperationHelper();

		IPageManager PageManager { get; }

		void InitializeTheList(IStateManager stateManager, IPageManager pageManager, IReferenceManager refManager, ISurrogateManager surManagerprivate, IUniqueIDGenerator _uniqueIdGenerator,IServerEventAggregator serverEventAggregator);

    }

	public interface IVirtualListFastOperations
	{
		void ClearFast();
	}
}
