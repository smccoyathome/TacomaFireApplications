using System;
using System.Collections.Generic;
using System.Threading;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.List
{
    public class VirtualPageManager : IPageManager
	{
		ReaderWriterLockSlim loadedPagesLock = new ReaderWriterLockSlim();
		IStateManager _stateManager;
		IUniqueIDGenerator _uniqueIdGenerator;
		IIocContainer Container;
		Dictionary<string, Page> _loadedPages;

		public VirtualPageManager(IStateManager st, IUniqueIDGenerator uniqueIDGenerator, IIocContainer container)
		{
			this._stateManager = st;
			this._uniqueIdGenerator = uniqueIDGenerator;
			this.Container = container;
			this._loadedPages = new Dictionary<string, Page>();
        }

        public void CleanUpPages()
        {
            var invalidPages = new List<Page>();
            foreach (var page in _loadedPages.Values)
            {
                var parentAsStateObject = page.Parent as IStateObject;
                //The page is invalid if and only if the list's uniqueID is:
                //  not AllBranchesAttached OR if the list is already in elementsToRemove
                if (parentAsStateObject != null
                && (!this._uniqueIdGenerator.IsAllBranchesAttached(parentAsStateObject.UniqueID) ||
                this._stateManager.IsInElementsToRemove(parentAsStateObject.UniqueID)))
                {
                    invalidPages.Add(page);
                }
            }
            foreach (var invalidPage in invalidPages)
            {
				var list = invalidPage.Parent as IVirtualListFastOperations;
				list.ClearFast();
				_stateManager.RemoveObject(invalidPage.UniqueID, true, true);
            }
        }

		public Page CreateNewPage(object parent)
		{
			var page = new Page();
			page.UniqueID = _uniqueIdGenerator.GetPageUniqueID();
			_stateManager.AddNewObject(page);
			var parentAsStateObject = parent as IStateObject;
			if (parentAsStateObject != null)
				_stateManager.SubscribeReference(parentAsStateObject, page);
			page.Parent = parent;
            page.ParentType = parent.GetType().GenericTypeArguments[0].FullName;
			return page;
		}
		public Page LoadPage(string uniqueID)
		{

			//Let's add loaded pages to a cache.
			Page p = null;
			lock (loadedPagesLock)
			{
				if (_loadedPages.TryGetValue(uniqueID, out p))
					return p;
				//Release to avoid deadlock
				p = _stateManager.GetObject(uniqueID) as Page;
                if (p == null) p = _stateManager.GetObject(uniqueID, includeDeleted:true, getObjectFromTemp: true) as Page;
				if (p != null)
				{
					//We add the page we just retrieved.
					_loadedPages.Add(uniqueID, p);
					foreach (var lazyobject in p.GetStoredObjectsSafe())
					{
						LazyObject obj = lazyobject as LazyObject;
						if (obj != null && obj.StateManager == null)
						{
							obj.StateManager = _stateManager;
						}
					}
					return p;
				}
				else
				{
					return null;
				}
			}
		}

		public void MergePages(List<Page> pages)
		{
			throw new NotImplementedException();
		}

		public bool RemovePage(string uniqueID)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			this._loadedPages = null;
			this._stateManager = null;
			this._uniqueIdGenerator = null;
			this.Container = null;
			this.loadedPagesLock = null;
		}

        /// <summary>
		/// Removes the page from the session and cleans up its item's references.
		/// </summary>
		public void CleanUpPage(IStateManager stateManager, IReferenceManager referenceManager, IVirtualPage page, string rootUniqueID = "", bool isDispose = false)
        {
            if (!isDispose)
            {
                foreach (var item in page.StoredObjects)
                {
                    var lazyItem = item as LazyObject;
                    lazyItem.StateManager = stateManager;
                    if (lazyItem.TargetUniqueID != null)
                    {
                        //Removes the reference between the list items and the Page.
                        referenceManager.UnSubscribe(page, lazyItem.TargetUniqueID, true, rootUniqueID);
                    }
                }
                stateManager.DettachObject(page);
            }
            else
            {
                bool justPromoted;
                stateManager.RemoveObjectReference(page.UniqueID, out justPromoted, removeEntryFromCache: false);
            }
            //Removes the page instance from the storage.

        }

        public void RestorePage(IStateManager stateManager, IReferenceManager referenceManager, IVirtualPage page, HashSet<string> alreadyPromotedHashSet)
        {
            foreach(LazyObject item in page.StoredObjects)
            {
                if (item.TargetUniqueID != null)
                {
                    stateManager.PromoteListItem(item.TargetUniqueID, item.Target as IStateObject, true, alreadyPromotedHashSet);
                }
            }
        }
    }
}
