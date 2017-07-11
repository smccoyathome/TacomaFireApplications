using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;

namespace UpgradeHelpers.WebMap.List.OperationHelper
{
	public abstract class OperationHelperBase
	{
		private object GetLazyObjectFor(object item, IStateManager stateManager, IServerEventAggregator serverAggregator = null)
		{
			if (serverAggregator != null)
				return new LazyObject(item, stateManager, serverAggregator);
			else
				return new LazyObject(item, stateManager);
		}

		private List<object> WakeUpTheLazyObjectsInsideThePage(List<object> storedObjects)
		{
			List<object> result = new List<object>();
			for (var i = 0; i < storedObjects.Count; i++)
			{
				if (storedObjects[i] is LazyObject)
				{
					var obj = (LazyObject)storedObjects[i];
					result.Add(obj.Target);
				}
				else
				{
					result.Add(storedObjects[i]);
				}
			}
			return result;
		}

		protected void ProcessIndexSetterForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index, object value)
		{
			ValidateIndexOutOfRange(ctx.pageIndexes, index);

			// Get the page's unique id that is located the index
			string pageUniqueID = ctx.pageIndexes[index] as string;
			
			// Loads the page from storage or from cache
			Page page = services.Pager.LoadPage(pageUniqueID);
			
			// Get the initial index of the corresponding page
			int pageIndex = ctx.initialIndexDictionary[page.UniqueID];
			
			// Get the real index inside the page
			int indexInsidePage = index - pageIndex;

			// Get the object related with the index
			LazyObject obj = (LazyObject) page.GetAtSafe(indexInsidePage);

            var stateobject = obj.Target as IStateObject;
            if (stateobject != null)
                //Detach the reference
                services.ReferenceManager.UnSubscribe(page, stateobject.UniqueID);

			var elementToSet = value as IStateObject;
			if (elementToSet != null)
			{
				if (!services.StateManager.IsStateObjectAttached(elementToSet))
				{
                    services.StateManager.PromoteObject(elementToSet, services.UniqueIdGenerator.GetPageItemUniqueID());
					page.SetAtSafe(indexInsidePage, GetLazyObjectFor(elementToSet, services.StateManager));
				}
				else if (!services.StateManager.IsStateObjectAllAttached(elementToSet))
				{
					page.SetAtSafe(indexInsidePage, GetLazyObjectFor(elementToSet, services.StateManager));
				}
				else
				{
					//Is all branches attached
					page.SetAtSafe(indexInsidePage, GetLazyObjectFor(elementToSet, services.StateManager));
				}
				//Subscribe to IReferenceManager in order to listen reference changes updates.
				SubscribeToReferenceManager(services.ReferenceManager, page, elementToSet);
			} else
			{
				//Assign the new value
				page.SetAtSafe(indexInsidePage, GetLazyObjectFor(value, services.StateManager));
			}
            services.StateManager.MarkAsDirty(page, "StoredObjects");
		}

		protected object ProcessIndexGetterForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx,int index)
		{
			ValidateIndexOutOfRange(ctx.pageIndexes, index);
			// Get the page's unique id that is located the index
			string pageUniqueID = ctx.pageIndexes[index] as string;
			// Loads the page from storage or from cache
			Page page = services.Pager.LoadPage(pageUniqueID);
			// Get the initial index of the corresponding page
			int pageIndex = ctx.initialIndexDictionary[page.UniqueID];
			// Get the real index inside the page
			int indexInsidePage = index - pageIndex;
			// Get the object related with the index
			LazyObject obj = (LazyObject) page.GetAtSafe(indexInsidePage);
			return obj.Target;
		}
		
		

		protected int ProcessIndexOfForValueType(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			foreach (var pageId in ctx.initialIndexDictionary.Keys)
			{
				Page p = services.Pager.LoadPage(pageId);
				List<object> l = WakeUpTheLazyObjectsInsideThePage(p.GetStoredObjectsSafe());
				int idx = l.IndexOf(item);
				if (idx >= 0)
				{
					int initialIndex = ctx.initialIndexDictionary[p.UniqueID];
					return initialIndex + idx;
				}
			}
			return -1;
		}

		protected int ProcessIndexOfForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			IEnumerable<Page> pages = GivenAnItemGetThePagesThatHoldsAReferenceOfTheItem(services,ctx,item);
			if(pages == null)return -1;
			Page p;
			int idx = FindItemInAllFoundPagesAndReturnTheIndex(item, pages, out p);
			if(idx >= 0)
			{
				int initialIndex = ctx.initialIndexDictionary[p.UniqueID];
				return initialIndex + idx;
			}
			return -1;
		}

		private int FindItemInAllFoundPagesAndReturnTheIndex(object item, IEnumerable<Page> pages, out Page p)
		{
			foreach (var page in pages)
			{
				List<object> l = WakeUpTheLazyObjectsInsideThePage(page.GetStoredObjectsSafe());
				int idx = l.IndexOf(item);
				if (idx >= 0)
				{
					p = page;
					return idx;
				}
			}
			p = null;
			return -1;
		}

		protected bool ProcessContainsForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			IEnumerable<Page> pages = GivenAnItemGetThePagesThatHoldsAReferenceOfTheItem(services,ctx,item);
			if (pages == null) return false;
			else return FindItemInAllFoundPages(item, pages);
			
		}

		private bool FindItemInAllFoundPages(object item, IEnumerable<Page> pages)
		{
			foreach (var page in pages)
			{
				List<object> l = WakeUpTheLazyObjectsInsideThePage(page.GetStoredObjectsSafe());
				if (l.Contains(item))
				{
					return true;
				}
			}
			return false;
		}
		protected bool ProcessContainsForValueType(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			foreach (var pageId in ctx.initialIndexDictionary.Keys)
			{
				Page p = services.Pager.LoadPage(pageId);
				List<object> l = WakeUpTheLazyObjectsInsideThePage(p.GetStoredObjectsSafe());
				bool contains = l.Contains(item);
				if (contains)
				{
					return true;
				}
			}
			return false;
		}
		protected void ProcessRemoveAtForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx, int index)
		{
			ValidateIndexOutOfRange(ctx.pageIndexes, index);

			// Get the page's unique id that is located the index
			string pageUniqueID = ctx.pageIndexes[index] as string;

			// Loads the page from storage or from cache
			Page page = services.Pager.LoadPage(pageUniqueID);

			// Get the initial index of the corresponding page
			int pageIndex = ctx.initialIndexDictionary[page.UniqueID];

			// Get the real index inside the page
			int indexInsidePage = index - pageIndex;

			// Get the object related with the index
			LazyObject obj =(LazyObject) page.GetAtSafe(indexInsidePage);

            var stateobject = obj.Target as IStateObject;
            if (stateobject != null)
                // Unsubscribes the object from the page's reference table
                services.ReferenceManager.UnSubscribe(page, stateobject.UniqueID);

			// Removes the object from the stored objects
			page.RemoveAtSafe(indexInsidePage);

			// Updates the indexes of the Initial Index Dictionary
			UpdateIndexDictionary(page, pageIndex, -1, ctx.pageIndexes, ctx.initialIndexDictionary);
			
			ctx.pageIndexes.RemoveAt(index);

            //Mark the page as dirty in order to be serialized again
            services.StateManager.MarkAsDirty(page, "StoredObjects");
        }
		protected bool ProcessDeletionForValueType(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			foreach (var pageId in ctx.initialIndexDictionary.Keys)
			{
				Page p = services.Pager.LoadPage(pageId);
				List<object> l = WakeUpTheLazyObjectsInsideThePage(p.GetStoredObjectsSafe());
				var idx = l.IndexOf(item);
				bool removed = false;
				if (idx >= 0)
				{
					p.RemoveAtSafe(idx);
					removed = true;
				}
				if (removed)
				{
					UpdateIndexDictionary(p, ctx.pageIndexes.LastIndexOf(p.UniqueID), -1, ctx.pageIndexes, ctx.initialIndexDictionary);
					ctx.pageIndexes.Remove(p.UniqueID);
					services.StateManager.MarkAsDirty(p, "StoredObjects");
					return true;
				}
			}
			return false;
		}

		protected void ProcessInsertionForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx,object item,int index, object parent)
		{
			ValidateIndexOutOfRange(ctx.pageIndexes, index);

			int pageIndex;
			//1.If there is no pages in the list, create a new page, otherwise retrieve the correct page
			Page page = GetPage(ctx.pageIndexes, services.Pager, index, ctx.initialIndexDictionary, out pageIndex, parent);

			//2.Update the Page Indexes array
			UpdatePageIndexesArray(ctx.pageIndexes, index, page);

			//3.Subscribe to IReferenceManager in order to listen reference changes updates.
            SubscribeToReferenceManager(services.ReferenceManager, page, item);

            //4.Insert the IStateObject into the correct position of the array of IStateObject of the Page.
            int InitialIndexOfThePage = GetInitialIndexOfThePage(pageIndex, ctx.initialIndexDictionary, ctx.pageIndexes);
            InsertElementToPage(index, item, page, InitialIndexOfThePage, services.StateManager, services.UniqueIdGenerator,services.ServerEventAggregator);

			//5.Update the Initial Index of all the pages that is located at right of the current page
			UpdateIndexDictionary(page, pageIndex, 1, ctx.pageIndexes, ctx.initialIndexDictionary);
        }
		protected bool ProcessDeletionForMostCases(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			IEnumerable<Page> pages = GivenAnItemGetThePagesThatHoldsAReferenceOfTheItem(services,ctx, item);
			if (pages == null) return false;
			Page p;
			//Delete the item inside the page
			RemoveObjectFromPage(item, pages, services.StateManager, out p);
			if (p != null)
			{
                //Unsubscribe to the ReferenceManager
				UnSubscribeToReferenceManager(services.ReferenceManager, p, item);

				//Update the Dictionary if needed
				UpdateIndexDictionary(p, ctx.pageIndexes.LastIndexOf(p.UniqueID), -1, ctx.pageIndexes, ctx.initialIndexDictionary);

                ctx.pageIndexes.Remove(p.UniqueID);
			}
			else
			{
				//Item nof found in all the pages.
				return false;
			}
			return true;
		}

		private IEnumerable<Page> GivenAnItemGetThePagesThatHoldsAReferenceOfTheItem(IVirtualListServiceDependencies services, IVirtualListContext ctx, object item)
		{
			//Given the value, first we need to retrieve its Reference Table.
			IReferenceTable refTable = services.ReferenceManager.GetReferenceTable(item);
			if (refTable != null)
			{
				//Given a ReferenceTable, returns the page that matches with the item's unique id
				IEnumerable<Page> pages = GetPageFromReferenceTable(refTable, item, ctx.initialIndexDictionary, services.Pager);
				return pages;
			}else
			{
				return null;
			}
		}

		protected void RemoveObjectFromPage(object obj, IEnumerable<Page> pages, IStateManager stateManager, out Page p)
		{
			p = null;
			bool removed = false;
			foreach (var page in pages)
			{
				List<object> l = WakeUpTheLazyObjectsInsideThePage(page.GetStoredObjectsSafe());
				var idx = l.IndexOf(obj);
				if(idx >= 0)
				{
					page.RemoveAtSafe(idx);
					stateManager.MarkAsDirty(page, "StoredObjects");
					removed = true;
				}
				if (removed)
				{
					p = page;
					break;
				}
			}
		}

		protected void ValidateIndexOutOfRange(List<string> pageIndexes, int index)
		{
			//Exception Example:
			//A list of 5 elements, and the index is bigger than 5
			// 5 > 5 would be false, whereas 6 > 5 would be true, so throw the exception.
			if (index > pageIndexes.Count)
			{
				throw new IndexOutOfRangeException();
			}
		}
		protected Page GetPage(List<string> pageIndexes, IPageManager pageManager, int index, Dictionary<string, int> initialIndexDictionary, out int pageIndex, object parent)
		{
			Page page;
			pageIndex = 0;
			if (pageIndexes.Count < 1)
			{
				//If there are no pages, we have to create the first page for the virtual list.
				page = pageManager.CreateNewPage(parent);
				initialIndexDictionary.Add(page.UniqueID, index);
			}
			else
			{
				pageIndex = (index == pageIndexes.Count) ? index - 1 : index;
				page = pageManager.LoadPage(pageIndexes[pageIndex] as string);
			}
			return page;
		}

		protected void UpdatePageIndexesArray(List<string> pageIndexes, int index, Page page)
		{
			// Insert the page's uniqueID into this array in order to retrieve the item easily.
			pageIndexes.Insert(index, page.UniqueID);
		}

		/// <summary>
		/// Insert the element into the correct position of the page
		/// </summary>
		/// <param name="index">This is the index of the list, not the index where the element will be inserted in the page</param>
		/// <param name="item">The item that should be stored into the page</param>
		protected void InsertElementToPage(int index, object item, Page page, int initialPosition, IStateManager stateManager, IUniqueIDGenerator uniqueIDGenerator, IServerEventAggregator serverAggregator)
		{
			int realPageIndex = index - initialPosition;
			var stateObject = item as IStateObject;
			
			//The item is not promoted yet. 
			//We are going to promote the item.
			if (stateObject != null)
			{
				// This means that the stateobject is a temporal object. so it is in the tempcache
				if (!stateManager.IsStateObjectAttached(stateObject))
				{
					stateManager.PromoteObject(stateObject, uniqueIDGenerator.GetPageItemUniqueID());
					page.InsertSafe(realPageIndex, GetLazyObjectFor(item, stateManager));
				}
				else
				{
                    var itemAsStateObject = item as IStateObject;
                    //If the item is in elements to remove
                    //this means that the item has been unsubscribed previously,
                    //so we have to take it out from elements to remove and promote again all its dependants
                    if (stateManager.IsInElementsToRemove(itemAsStateObject.UniqueID))
                    {
                        stateManager.PromoteListItem(itemAsStateObject.UniqueID, item as IStateObject, true,new HashSet<string>());
                    }
					//Is all branches attached
					page.InsertSafe(realPageIndex, GetLazyObjectFor(item, stateManager));
				}
			}else
			{
				page.InsertSafe(realPageIndex, GetLazyObjectFor(item, stateManager));
			}
			stateManager.MarkAsDirty(page, "StoredObjects");
		}

		/// <summary>
		/// Calculates the Initial Index of the current page.
		/// </summary>
		/// <param name="pageIndex">The page index</param>
		/// <param name="index"></param>
		/// <returns></returns>
		protected int GetInitialIndexOfThePage(int pageIndex, Dictionary<string, int> initialIndexDictionary, List<string> pageIndexes)
		{
			return initialIndexDictionary[pageIndexes[pageIndex] as string];
		}

		protected void SubscribeToReferenceManager(IReferenceManager _referenceManager, Page page, object item)
		{
			//Subscribe the item into the page's reference table
			_referenceManager.Subscribe(page, item);
		}

		protected void UnSubscribeToReferenceManager(IReferenceManager _referenceManager, Page page, object item)
		{
            var stateobject = item as IStateObject;
            if (stateobject != null)
                //Subscribe the item into the page's reference table
                _referenceManager.UnSubscribe(page, stateobject.UniqueID);
		}

		/// <summary>
		/// Updates the entries of the dictionary that is at the right of the current page index.
		/// For example, we have three pages, and we inserted in the first page.
		/// So in this method, we will update the initial position of the second and third page.
		/// </summary>
		/// <param name="page">The current page</param>
		/// <param name="pageIndex">the current page index</param>
		/// <param name="value">the value to be updated, it could be +1 or -1</param>
		protected void UpdateIndexDictionary(Page page, int pageIndex, int value, List<string> pageIndexes, Dictionary<string, int> initialIndexDictionary)
		{
			var index = pageIndex + 1;
			string lastUniqueID = "";
			while (index < pageIndexes.Count)
			{
				if (page.UniqueID != pageIndexes[index] as string && lastUniqueID != pageIndexes[index] as string)
				{
					lastUniqueID = pageIndexes[index] as string;
					initialIndexDictionary[lastUniqueID] += value;
				}
				index++;
			}
		}


		protected IEnumerable<Page> GetPageFromReferenceTable(IReferenceTable refTable, object value, Dictionary<string, int> initialIndexDictionary, IPageManager pageManager)
		{
			Page p = null;
			foreach (var i in refTable.References)
			{
				if (initialIndexDictionary.Keys.Contains(i.TargetUniqueID))
				{
					p = pageManager.LoadPage(i.TargetUniqueID);
					yield return p;
				}
			}
		}
	}
}

