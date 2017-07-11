// *************************************************************************************
// <copyright  company="Mobilize" file="IPageManager.cs">
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

namespace UpgradeHelpers.WebMap.List
{
    public interface IPageManager
	{
		/// <summary>
		/// Creates and retrieves the new page
		/// </summary>
		/// <returns></returns>
		Page CreateNewPage(object parentUniqueID);
		
		/// <summary>
		/// Merges the list of pages into only one page
		/// </summary>
		/// <param name="pages">A list of pages that will be merged</param>
		void MergePages(List<Page> pages);
		
		/// <summary>
		/// Removes a specific page based on the UniqueID
		/// </summary>
		/// <param name="uniqueID">The unique id of the page that we want to remove</param>
		/// <returns></returns>
		bool RemovePage(string uniqueID);

		/// <summary>
		/// Load a page from storage based on its unique id
		/// The page maybe loaded from cache or from storage
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		Page LoadPage(string uniqueID);

        /// <summary>
		/// Removes the page from the session and cleans up its item's references.
		/// </summary>
		void CleanUpPage(IStateManager stateManager, IReferenceManager referenceManager, IVirtualPage page, string rootUniqueID = "", bool isDispose = false);

		/// <summary>
		/// Restores the page's item taking it out from the elementsToRemove collection
		/// </summary>
        void RestorePage(IStateManager stateManager, IReferenceManager referenceManager, IVirtualPage page, HashSet<string> alreadyPromotedHashSet);
    }
}
