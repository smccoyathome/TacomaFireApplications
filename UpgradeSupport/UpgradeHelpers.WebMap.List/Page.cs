using System.Collections.Generic;
using System.Threading;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.List
{
	public class Page : IDependentModel, IDependentsContainer, IVirtualPage, UpgradeHelpers.WebMap.Server.NoInterception
	{
		public Page()
		{
			this.StoredObjects = new List<object>();
		}

		public object Parent { get; set; }
        public string ParentType { get; set; }
		public string UniqueID { get; set; }
			
		/// <summary>
		/// This list stores the UniqueID of the elements that the Page stores.
		/// </summary>
		public List<object> StoredObjects { get; set; }
		/// <summary>
		/// Way to handle multiple thread accesses.
		/// </summary>
		ReaderWriterLockSlim _storedObjectsLock = new ReaderWriterLockSlim();

		#region UnSafeOperations
		/// <summary>
		/// Adds an element to the page.
		/// </summary>
		/// <param name="element"></param>
		internal void Add(object element)
		{
			StoredObjects.Add(element);
		}
		/// <summary>
		/// Clears all the elements in the Page.
		/// </summary>
		internal void Clear()
		{
			StoredObjects.Clear();
		}
		/// <summary>
		/// Thread safe way to get an element in the list
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		internal object GetAt(int index)
		{
			return StoredObjects[index];
		}
		/// <summary>
		/// Thread safe access to the StoreObjects collection
		/// </summary>
		/// <returns></returns>
		internal List<object> GetStoredObjects()
		{
			return StoredObjects;
		}
		/// <summary>
		/// Inserts an element to a page
		/// </summary>
		/// <param name="index">Index of the element.</param>
		/// <param name="element">Element to insert.</param>
		internal void Insert(int index, object element)
		{
			StoredObjects.Insert(index, element);
		}
		/// <summary>
		/// Removes an element from the page.
		/// </summary>
		/// <param name="index"></param>
		internal void RemoveAt(int index)
		{
			StoredObjects.RemoveAt(index);
		}
		/// <summary>
		/// Thread safe way to set an element value in the list
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		internal void SetAt(int index, object element)
		{
			StoredObjects[index] = element;
		}
		#endregion

		#region ThreadSafeOperations
		/// <summary>
		/// Thread safe way to add an element to the page.
		/// </summary>
		/// <param name="element"></param>
		internal void AddSafe(object element)
		{
			_storedObjectsLock.EnterUpgradeableReadLock();
			try
			{
				_storedObjectsLock.EnterWriteLock();
				try
				{
					StoredObjects.Add(element);
				}
				finally
				{
					_storedObjectsLock.ExitWriteLock();
				}
			}
			finally
			{
				_storedObjectsLock.ExitUpgradeableReadLock();
			}
		}
		/// <summary>
		/// Thread safe access to the StoreObjects collection
		/// </summary>
		/// <returns></returns>
		internal List<object> GetStoredObjectsSafe()
		{
			List<object> result = null;
			_storedObjectsLock.EnterUpgradeableReadLock();
			try
			{
				_storedObjectsLock.EnterReadLock();
				try
				{
					result = StoredObjects;
				}
				finally
				{
					_storedObjectsLock.ExitReadLock();
				}
			}
			finally
			{
				_storedObjectsLock.ExitUpgradeableReadLock();
			}
			return result;
		}
		/// <summary>
		/// Thread safe way to Insert an element to the page.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="element"></param>
		internal void InsertSafe(int index, object element)
		{
			_storedObjectsLock.EnterUpgradeableReadLock();
			try
			{
				_storedObjectsLock.EnterWriteLock();
				try
				{
					StoredObjects.Insert(index, element);
				}
				finally
				{
					_storedObjectsLock.ExitWriteLock();
				}
			}
			finally
			{
				_storedObjectsLock.ExitUpgradeableReadLock();
			}
		}

		/// <summary>
		/// Removes an element from the page.
		/// </summary>
		/// <param name="index"></param>
		internal void RemoveAtSafe(int index)
		{
			_storedObjectsLock.EnterUpgradeableReadLock();
			try
			{
				_storedObjectsLock.EnterWriteLock();
				try
				{
					StoredObjects.RemoveAt(index);
				}
				finally
				{
					_storedObjectsLock.ExitWriteLock();
				}
			}
			finally
			{
				_storedObjectsLock.ExitUpgradeableReadLock();
			}
		}
		/// <summary>
		/// Thread safe way to get an element in the list
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		internal object GetAtSafe(int index)
		{
				_storedObjectsLock.EnterUpgradeableReadLock();
				try
				{
					_storedObjectsLock.EnterReadLock();
					try
					{
						return StoredObjects[index];
					}
					finally
					{
						_storedObjectsLock.ExitReadLock();
					}
				}
				finally
				{
					_storedObjectsLock.ExitUpgradeableReadLock();
				}
		}
		/// <summary>
		/// Thread safe way to set an element value in the list
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		internal void SetAtSafe(int index, object element)
		{
				_storedObjectsLock.EnterUpgradeableReadLock();
				try
				{
					_storedObjectsLock.EnterWriteLock();
					try
					{
						StoredObjects[index] = element;
					}
					finally
					{
						_storedObjectsLock.ExitWriteLock();
					}
				}
				finally
				{
					_storedObjectsLock.ExitUpgradeableReadLock();
				}
		}

		internal void ClearSafe()
		{
			_storedObjectsLock.EnterUpgradeableReadLock();
			try
			{
				_storedObjectsLock.EnterWriteLock();
				try
				{
					StoredObjects.Clear();
				}
				finally
				{
					_storedObjectsLock.ExitWriteLock();
				}
			}
			finally
			{
				_storedObjectsLock.ExitUpgradeableReadLock();
			}
		}
#endregion

		public List<string> Dependents
		{
			get;
			set;
		}
	}
}
