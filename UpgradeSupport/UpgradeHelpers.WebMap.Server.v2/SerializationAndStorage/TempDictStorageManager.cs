using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{

	public class TestStorageInfo
	{
		public Hashtable data;
		public int storageSize;
		public int keyCount;
		public int keysSize;
		public int valuesSize;
	}
	internal class TempDictStorageManager : IStorageManager
	{
		private StorageSerializerUsingJsonnet _serializer;
		internal Hashtable table = new Hashtable();
		private HashSet<StateObjectSurrogate> _surrogatesToBePersisted;


		internal const string WM_PREFIX = "WM@";


		public TempDictStorageManager()
		{
			_serializer = new StorageSerializerUsingJsonnet();
			_surrogatesToBePersisted = new HashSet<StateObjectSurrogate>();
		}

		#region IStorageManager Members

		public ICollection GetAllItems()
		{
			return table.Keys;
		}

		public List<string> GetChildren(string uniqueId)
		{
			//foreach (var id in GetAllItems())
			//{
			//	if (id.EndsWith(uniqueId,StringComparison.Ordinal))
			//		yield return id;
			//}
			return null;
		}


		public IStateObject GetObject(string uniqueID)
		{
			object rawData = table[uniqueID];
			if (rawData == null)
				return null;

			object res = _serializer.RawToObject(uniqueID, rawData);
			return res as IStateObject;
		}

		public void SaveObject(IStateObject obj)
		{
			object rawData = _serializer.ObjectToRaw(obj);
			table[obj.UniqueID] = rawData;
		}

		public void RemoveObject(string uniqueId)
		{
			table.Remove(uniqueId);
		}


		public void SwitchUniqueIDsFrom(string itemUID, string lastUID)
		{
			var tmp = table[itemUID];
			table[lastUID] = tmp;
		}

		#endregion





		internal TestStorageInfo Dump(TextWriter writer)
		{
			writer.WriteLine("STORAGE");
			writer.WriteLine("=================================");
			writer.WriteLine("Entries:" + table.Count);
			TestStorageInfo info = new TestStorageInfo();
			info.data = table;
			foreach (string key in table.Keys)
			{
				info.keysSize += (key.Length * 2);
				var value = table [key];
				if (value != null)
				{
					if (value is string)
						info.valuesSize += ( ((string)value).Length * 2);
					else if (value is byte[])
						info.valuesSize += ((byte[])value).Length;
				}
				if (value is string)
					writer.WriteLine("[ {0}, {1} ]", key, table[key]);
				else if (value is byte[])
					writer.WriteLine("[ {0}, surrogate ]", key);
				else
					writer.WriteLine("[ {0}, unsupporteddump ]", key);
				info.keyCount++;
			}
			writer.WriteLine ("STORAGE SiZE: " + (info.storageSize = (info.keysSize + info.valuesSize)));
			writer.WriteLine ("STORAGE KEYS   SIZE: " + info.keysSize );
			writer.WriteLine ("STORAGE VALUES SIZE: " + info.valuesSize );
			return info;

		}


        public void SaveRaw(string uniqueId, object rawData)
        {
				table[uniqueId] = rawData;
			
        }

        public object GetRaw(string uniqueId)
        {
			if (table.ContainsKey (uniqueId))
				return table;
			return null;
        }

        public void SaveSurrogate(StateObjectSurrogate surrogate)
        {
			//Save surrogate header
            var surrogateContext = StateManager.Current.surrogateManager.GetSurrogateContext(surrogate.UniqueID,surrogate);
			var raw = SurrogatesDirectory.ObjectToRaw(surrogate, surrogateContext);
			SaveRaw(surrogate.UniqueID, raw);

            //Save surrogate value
            var uid = UniqueIDGenerator.GetRelativeUniqueID(surrogate, StateObjectSurrogate.VALUE_PREFIX);
            surrogateContext = StateManager.Current.surrogateManager.GetSurrogateContext(uid, surrogate.Value);
            raw = SurrogatesDirectory.ObjectToRaw(surrogate.Value, surrogateContext);
            SaveRaw(uid, raw);
        }


		public void SendToSurrogatesToBePersisted(StateObjectSurrogate surrogate)
		{
			_surrogatesToBePersisted.Add(surrogate);
		}

		public void PersistSurrogates()
		{
			foreach (var surrogate in _surrogatesToBePersisted)
				SaveSurrogate(surrogate);
		}

		public void AddSurrogateHolder(StateObjectSurrogate value)
		{
			throw new NotImplementedException();
		}

		public bool HasObject(string uniqueId)
		{
			return table.ContainsKey(uniqueId);
		}

        public void EndRequest()
        {
            throw new NotImplementedException();
		}


		public int printValues()
		{
			throw new NotImplementedException();
		}



		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}