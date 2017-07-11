// *************************************************************************************
// <copyright  company="Mobilize" file="IVirtualListManager.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// Interface of IVirtualListManager
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IVirtualListManager<T>
    {
		int Count { get; }

		T this[int index] { get; set; }

		int IndexOf(T item);
	
		void Insert(int index, T item);
		
		void RemoveAt(int index);

		int Add(T value);

		void Clear();

		bool Contains(T value);

		bool Remove(T value);

		void CopyTo(T[] array, int arrayIndex);

		System.Collections.Generic.IEnumerator<T> GetEnumerator();
	}
}
