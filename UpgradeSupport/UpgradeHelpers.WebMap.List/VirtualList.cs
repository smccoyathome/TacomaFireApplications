// *************************************************************************************
// <copyright  company="Mobilize" file="VirtualList.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.List
{


    public partial class VirtualList<T> : IList<T>, IList, IDependentViewModel, IDependentsContainer, IVirtualListSerializable,
		IInitializable, IInitializable<int>, IInitializable<IEnumerable<T>>, NoInterception, IVirtualListFastOperations
	{
		private IOperationHelper _operationHelper;
		private IPageManager _pageManager;
		private IReferenceManager _referenceManager;
		private ISurrogateManager _surrogateManager;
		private IStateManager _stateManager;
        private IServerEventAggregator _serverEventAggregator;
        private IUniqueIDGenerator _uniqueIdGenerator;
		/// <summary>
		/// This dictionary stores the initial positions of each page.
		/// The first type paremeter corresponds to the string type unique id of the page
		/// The second type parameter corresponds to the integer that indicates the initial position.
		/// The values of the dictionary should be always ordered ascendantly
		/// </summary>
		public Dictionary<string, int> InitialPositionOfEachPage { get; set; }

		/// <summary>
		/// This array stores in each entry the uniqueID of the page which is associated with each entry of the list.
		/// </summary>
		public List<string> PageUniqueIdOfTheIndexes { get; set; }

		public IOperationHelper OperationHelper { get { return this._operationHelper; } }

		public VirtualListTypeEnum ListType { get; set; }

		public IPageManager PageManager { get { return _pageManager; } }

		public VirtualList()
		{
			this.PageUniqueIdOfTheIndexes = new List<string>();
			this.InitialPositionOfEachPage = new Dictionary<string, int>();
		}
		/// <summary>
		/// This constructor is used for Mock Unit Testing purposes
		/// </summary>
		public VirtualList(IStateManager stateManager, IPageManager pageManager, IReferenceManager refManager, ISurrogateManager surManager = null, List<string> idxs = null, Dictionary<string, int> dict = null)
		{
			_stateManager = stateManager;
			_pageManager = pageManager;
			_referenceManager = refManager;
			_surrogateManager = surManager;
			PageUniqueIdOfTheIndexes = idxs ?? new List<string>();
			InitialPositionOfEachPage = dict ?? new Dictionary<string, int>();
			InitializeOperationHelper();
		}
		public void InitializeTheList(IStateManager stateManager, IPageManager pageManager, IReferenceManager refManager, ISurrogateManager surManager,  IUniqueIDGenerator uniqueIdGenerator,IServerEventAggregator serverEventAggregator)
		{
			_stateManager = stateManager;
			_pageManager = pageManager;
			_referenceManager = refManager;
			_surrogateManager = surManager;
			_uniqueIdGenerator = uniqueIdGenerator;
            _serverEventAggregator = serverEventAggregator;
			InitializeOperationHelper();
		}
		#region IInitializable
		void IInitializable.Init()
		{
		}
		
		void IInitializable<IEnumerable<T>>.Init(IEnumerable<T> collection)
		{
            foreach (var item in collection)
                Add(item);
        }

		void IInitializable<int>.Init(int size)
		{
			for (int i = 0; i < size; i++)
				Add(default(T));
		}
		#endregion
		#region MEF Initialization

		/// <summary>
		/// Determines which OperationHelper should use the list manager.
		/// There are now three operation helpers:
		/// 1. ObjectOperationHelper: For IList of Object
		/// 2. SurrogateOperationHelper: For surrogates
		/// 3. ValueTypeOperationHelper: For ValueTypes and Strings
		/// 4. StteObjectOperationHelper: For StateObjects
		/// </summary>
		private void DetermineMyHelper()
		{
			if (this.ListType == VirtualListTypeEnum.None)
			{
				if (typeof(IStateObject).IsAssignableFrom(typeof(T)) 
                    || (typeof(T).IsGenericType && 
                    (typeof(T).GetGenericTypeDefinition() == typeof(IList<>) || typeof(T).GetGenericTypeDefinition() == typeof(IDictionary<,>))))
                    this.ListType = VirtualListTypeEnum.StateObject;
				else if (typeof(T).IsValueType || typeof(string) == typeof(T))
                    this.ListType = VirtualListTypeEnum.ValueType;
				else if (_surrogateManager.IsSurrogateRegistered(typeof(T)))
                    this.ListType = VirtualListTypeEnum.Surrogate;
				else if (typeof(T) == typeof(Object))
                    this.ListType = VirtualListTypeEnum.Object;
			}
			InitializeOperationHelper(this.ListType);
		}

		public void InitializeOperationHelper(VirtualListTypeEnum typeName)
		{
            // Avoid exception when typeName is not supported. i.e. typeName=None
            if (!MEFManager.OperationHelpers.ContainsKey(typeName))
            {
                System.Diagnostics.Debug.Assert(true, "List of Type=None is not supported!");
                this.ListType = VirtualListTypeEnum.Object;
                typeName = this.ListType;
            }
            _operationHelper = MEFManager.OperationHelpers[typeName];
		}

		/// <summary>
		/// Initializes the MEF Componenet in order to be used for the IOperationHelper helpers
		/// </summary>
		public void InitializeOperationHelper()
		{
			if (this._operationHelper == null)
			{
				DetermineMyHelper();
			}
		}
		#endregion

		#region IList Implementation
		public int Add(object value)
		{
			this.Add(value);
			return this.Count;
		}

		public bool Contains(object value)
		{
			return this.Contains((T)value);
		}

		public int IndexOf(object value)
		{
			return this.IndexOf((T)value);
		}

		public void Insert(int index, object value)
		{
			this.Insert(index, (T)value);
		}

		public void Remove(object value)
		{
			this.Remove((T)value);
		}

		public void CopyTo(Array array, int index)
		{
			this.CopyTo((T[])array, index);
		}


		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public object SyncRoot
		{
			get
			{
				return null;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}

			set
			{
				this[index] = (T)value;
			}
		}
		#endregion

		#region IList Generics Implementation
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}
		public T this[int index]
		{
			get
			{
				return (T)this._operationHelper.GetterOperation(this, this , index);
			}

			set
			{
				this._operationHelper.SetterOperation(this , this , index, value);
				_stateManager.MarkAsDirty(this, "Count");
			}
		}

		public int IndexOf(T item)
		{
			return _operationHelper.IndexOfOperation(this , this , item);
		}

		public void RemoveAt(int index)
		{
            _operationHelper.RemoveAtOperation(this , this , index);
            _stateManager.MarkAsDirty(this, "Count");
        }

        /// <summary>
        /// Insert for many kind of object types such as: value type, string type, state object
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
		{
			_operationHelper.InsertOperation(this , this , item, index,  this);
			_stateManager.MarkAsDirty(this, "Count");
		}
		#endregion

		#region ICollection Implementation
		public void Add(T value)
		{
			Insert(PageUniqueIdOfTheIndexes.Count, value);
		}

		public bool Remove(T value)
		{
			_stateManager.MarkAsDirty(this, "Count");
			return _operationHelper.RemoveOperation(this , this , value);
		}

		public void Clear()
		{
			foreach (var pageId in InitialPositionOfEachPage.Keys)
			{
				Page p = _pageManager.LoadPage(pageId);
				foreach (var item in p.GetStoredObjectsSafe())
				{
					var wakeupelement = ((LazyObject)item).Target as IStateObject;
                    if(wakeupelement != null)
                        _referenceManager.UnSubscribe(p, wakeupelement.UniqueID);
                }
				p.ClearSafe();
			}
			PageUniqueIdOfTheIndexes.Clear();
			InitialPositionOfEachPage.Clear();
			_stateManager.MarkAsDirty(this, "Count");
		}

		public void ClearFast()
		{
			foreach (var pageId in InitialPositionOfEachPage.Keys)
			{
				Page p = _pageManager.LoadPage(pageId);
				foreach (var item in p.StoredObjects)
				{
					var wakeupelement = ((LazyObject)item).Target as IStateObject;
                    if(wakeupelement != null)
					_referenceManager.UnSubscribe(p, wakeupelement.UniqueID, true, this.UniqueID);
				}
			}
		}

		public bool Contains(T value)
		{
			return _operationHelper.ContainsOperation(this, this , value);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException();
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException();
			if (this.Count > array.Length)
				throw new ArgumentException();

			for (var index = 0; index < this.Count; index++)
			{
				array[arrayIndex] = this[index];
				arrayIndex++;
			}
		}



		public int Count
		{
			get
			{
				return PageUniqueIdOfTheIndexes.Count;
			}
		}
		#endregion

		#region IEnumerable Implementation
		public IEnumerator<T> GetEnumerator()
		{
			return new VirtualListEnumerator(this);
		}

		internal class VirtualListEnumerator : IEnumerator<T>
		{
			int currentIndex = -1;
			VirtualList<T> parent;

			public VirtualListEnumerator(VirtualList<T> parent)
			{
				this.parent = parent;
			}
			public T Current
			{
				get
				{
					return parent[currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return parent[currentIndex];
				}
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				currentIndex++;
				return currentIndex < parent.Count;
			}

			public void Reset()
			{
				currentIndex = -1;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new VirtualListEnumerator(this);
		}
		#endregion

		#region IDependenViewModel
		public void Build(IIocContainer ctx)
		{
		}
        
        public string UniqueID { get; set; }

		#endregion
	}

    public partial class VirtualList<T> : IVirtualListContext
    {
        Dictionary<string, int> IVirtualListContext.initialIndexDictionary
        {
            get
            {
                return this.InitialPositionOfEachPage;
            }
        }

        List<string> IVirtualListContext.pageIndexes
        {
            get
            {
                return this.PageUniqueIdOfTheIndexes;
            }
        }
    }

    public partial class VirtualList<T> : IVirtualListServiceDependencies
    {
        IServerEventAggregator IVirtualListServiceDependencies.ServerEventAggregator
        {
            get
            {
                return _serverEventAggregator;
            }
        }

        IStateManager IVirtualListServiceDependencies.StateManager
        {
            get
            {
                return _stateManager;
            }
        }

        IUniqueIDGenerator IVirtualListServiceDependencies.UniqueIdGenerator
        {
            get
            {
                return _uniqueIdGenerator;
            }
        }

        IPageManager IVirtualListServiceDependencies.Pager
        {
            get
            {
                return _pageManager;
            }
        }

        IReferenceManager IVirtualListServiceDependencies.ReferenceManager
        {
            get
            {
                return _referenceManager;
            }
        }

        ISurrogateManager IVirtualListServiceDependencies.SurrogateManager
        {
            get
            {
                return _surrogateManager;
            }
        }

		public List<string> Dependents
		{
			get;
			set;
		}
    }

    public enum VirtualListTypeEnum
    {
        None,
        ValueType,
        StateObject,
        Surrogate,
        Object
    }
}
