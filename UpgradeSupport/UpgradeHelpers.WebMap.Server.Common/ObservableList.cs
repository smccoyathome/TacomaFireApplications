using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UpgradeHelpers.WebMap.Server.Common
{
	/// <summary>
	/// Provides a generic IList implementation that also implements <c>INotifyCollectionChanged</c> in order to 
	/// notify when collection changes.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ObservableList<T> : IList<T>, INotifyCollectionChanged
	{
		private readonly IList<T> _list;

		public ObservableList()
		{
			_list = new List<T>();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public void Add(T item)
		{
			_list.Add(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item);
		}

		public void Clear()
		{
			_list.Clear();
			NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
		}

		public bool Contains(T item)
		{
			return _list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			var remove = _list.Remove(item);
			if (remove)
				NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
			return remove;
		}

		public int Count { get { return _list.Count; } }
		public bool IsReadOnly { get { return _list.IsReadOnly; } }
		public int IndexOf(T item)
		{
			return _list.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item);
		}

		public void RemoveAt(int index)
		{
			if (index < _list.Count && index >= 0)
			{
				var item = _list[index];
				_list.RemoveAt(index);
				NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public T this[int index]
		{
			get { return _list[index]; }
			set { this[index] = value; }
		}

		private void NotifyCollectionChanged(NotifyCollectionChangedAction action)
		{
			if (CollectionChanged != null)
			{
				CollectionChanged.Invoke(this, new NotifyCollectionChangedEventArgs(action));
			}
		}

		private void NotifyCollectionChanged(NotifyCollectionChangedAction action, T item)
		{
			if (CollectionChanged != null)
			{
				CollectionChanged.Invoke(this, new NotifyCollectionChangedEventArgs(action, item));
			}
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;
	}
}
