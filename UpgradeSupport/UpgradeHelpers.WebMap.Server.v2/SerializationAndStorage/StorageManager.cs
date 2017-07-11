using System.Collections;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal interface IStorageManager
	{
		ICollection GetAllItems();
		/// <summary>
		/// Gets children for the object identified by given unique id
		/// </summary>
		/// <param name="uniqueId">The id of the object to get children for</param>
		/// <returns>An enumeration with object children</returns>
		List<string> GetChildren(string uniqueId);
		IStateObject GetObject(string uniqueID);

		bool HasObject(string uniqueId);

		void SaveObject(IStateObject obj);
		void RemoveObject(string uniqueId);
		void SaveRaw(string uniqueId, object rawData);
		object GetRaw(string uniqueId);
		void SaveSurrogate(StateObjectSurrogate surrogate);
		void SendToSurrogatesToBePersisted(StateObjectSurrogate surrogate);
		void PersistSurrogates();
		void SwitchUniqueIDsFrom(string itemUID, string lastUID);
		int printValues();

		void Dispose();
	}

}