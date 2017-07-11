using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
	internal abstract class SessionStorageManagerBase : IStorageManager
    {
		internal StorageSerializerUsingJsonnet _serializer;
		internal ChildrenTracker storageCache = null;
		internal Hashtable _surrogatesToBePersisted;
		internal IStateManager _stateManager;
		internal SurrogateManager _surrogateManager;
		public SessionStorageManagerBase(IStateManager stateManager, SurrogateManager surrogateManager)
        {
            _stateManager = stateManager;
            _surrogateManager = surrogateManager;
            _serializer = new StorageSerializerUsingJsonnet();
            _surrogatesToBePersisted = new Hashtable();
		}
		public abstract ICollection GetAllItems();
		public abstract List<string> GetChildren(string uniqueID);
		public abstract IStateObject GetObject(string uniqueID);
		public abstract void SaveObject(IStateObject obj);
		public abstract void RemoveObject(string uniqueId);
		public abstract void SaveRaw(string uniqueId, object rawData);
		public abstract object GetRaw(string uniqueId);
		public void PersistSurrogates()
		{
			foreach (StateObjectSurrogate surrogate in _surrogatesToBePersisted.Values)
			{
				try
				{
					SaveSurrogate(surrogate);
				}
				catch (Exception ex)
            {
					Debug.WriteLine("Error while persisting Surrogate " + surrogate.UniqueID + " SurrogateType " + surrogate.Value.GetType().FullName);
					Debug.WriteLine(ex.Message + " stacktrace " + ex.StackTrace.ToString());
            }
        }
			_surrogatesToBePersisted.Clear();

		}
		public void SendToSurrogatesToBePersisted(StateObjectSurrogate surrogate)
        {
			_surrogatesToBePersisted[surrogate.UniqueID] = surrogate;
        }
		public void SaveSurrogate(StateObjectSurrogate surrogate)
        {
			//Saving surrogate header
			var surrogatecontext = _surrogateManager.GetSurrogateContext(surrogate.UniqueID, surrogate);
			var raw = SurrogatesDirectory.ObjectToRaw(surrogate, surrogatecontext);
			SaveRaw(surrogate.UniqueID, raw);
			//Saving surrogateValue
			if (surrogate.ShouldSerializeValue)
            {
				var uid = UniqueIDGenerator.GetRelativeUniqueID(surrogate, StateObjectSurrogate.VALUE_PREFIX);
				surrogatecontext = _surrogateManager.GetSurrogateContext(uid, surrogate.Value);
				raw = SurrogatesDirectory.ObjectToRaw(surrogate.Value, surrogatecontext);
				SaveRaw(uid, raw);
			}
		}
		public abstract void SwitchUniqueIDsFrom(string itemUID, string lastUID);
		public abstract bool HasObject(string uniqueId);
		public void Dispose()
		{
			this._serializer = null;
			this._stateManager = null;
			this._surrogateManager = null;
			this._surrogatesToBePersisted = null;
			if (storageCache != null)
                {
				this.storageCache.Dispose();
				this.storageCache = null;
			}
                }
		public abstract int printValues();
	}
	internal class SessionStorageManager : SessionStorageManagerBase
	{
		private HttpSessionState _session;
		/// <summary>
		/// The lifecycle of the cache is expected to be of a single request, so there's no need to track changes made in the storage.
		/// </summary>
		public SessionStorageManager(IStateManager stateManager, SurrogateManager surrogateManager)
			: base(stateManager, surrogateManager)
                {
			_session = HttpContext.Current.Session;
            }

		#region IStorageManager Members

		public override ICollection GetAllItems()
		{
			return _session.Keys;
        }

		public override List<string> GetChildren(string uniqueId)
        {
            // If the storageCache is null, then loop through all the items and create the cache.
            // The lifecycle of the cache is expected to be of a single request, so there's no need to track changes made in the storage.
			List<string> result = new List<string>();
			if (storageCache == null)
			{
				storageCache = new ChildrenTracker(_stateManager);
				var uniqueIdToCheck = UniqueIDGenerator.UniqueIdSeparator + uniqueId;
				foreach (string id in GetAllItems())
				{
					// No need to remove the WM_PREFIX, as the method GetAllItems already does
					// var trimmedId = id.StartsWith(WM_PREFIX) ? id.Substring(3) : id;
					storageCache.Add(id);
				}
			}
            return storageCache.GetAllDependentKeys(uniqueId);
        }

		public override IStateObject GetObject(string uniqueID)
        {
            object rawData = GetRaw(uniqueID);
            if (rawData == null) return null;
            return _serializer.RawToObject(uniqueID, rawData) as IStateObject;
        }

		public override void SaveObject(IStateObject obj)
        {
            try
            {
                object rawData = _serializer.ObjectToRaw(obj);
                SaveRaw(obj.UniqueID, rawData);
            }
            catch (Exception ex)
            {
                TraceUtil.TraceError("SessionStorageManager::SaveObject id:{0} type:{1} Exception {2}", obj.UniqueID, obj.GetType(), ex.Message);
            }
        }

		public override void RemoveObject(string uniqueId)
        {
			_session.Remove(uniqueId);
        }

		public override void SaveRaw(string uniqueId, object rawData)
        {
			_session[uniqueId] = rawData;
        }

		public override object GetRaw(string uniqueId)
        {
			if (_session != null)
				return _session[uniqueId];
            else
                return null;
        }

		public override void SwitchUniqueIDsFrom(string itemUID, string lastUID)
        {
			object tmp = _session[itemUID];
			_session[lastUID] = tmp;
        }

		#endregion


		public override bool HasObject(string uniqueId)
		{
			return _session[uniqueId] != null;
		}

		public override int printValues()
		{
			string path = @"D:\Temp\cache" + System.DateTime.Now.TimeOfDay.ToString().Replace(":", "") + ".csv";
			// Create a file to write to.
			File.WriteAllText(path, string.Empty);
			int bytesCount = 0;
			using (StreamWriter sw = File.AppendText(path))
			{
				foreach (string item in _session.Keys)
        {
					var value = _session[item];
					if (value is byte[])
            {
						sw.WriteLine(item + ", " + (value as byte[]).Length);
						bytesCount += (value as byte[]).Length;
					}
					else if (value is string)
                {
						sw.WriteLine(item + ", " + System.Text.ASCIIEncoding.ASCII.GetByteCount(value as string));
						bytesCount += System.Text.ASCIIEncoding.ASCII.GetByteCount(value as string);
					}
				}
				sw.WriteLine("Total Bytes: " + bytesCount);
			}
			return bytesCount;
		}
                }
	internal class SessionStorageManagerInproc : SessionStorageManagerBase
	{
		const string WM_PREFIX = "WM@";
		private Dictionary<string, object> _sessionCollectionItems = null;
		/// <summary>
		/// The lifecycle of the cache is expected to be of a single request, so there's no need to track changes made in the storage.
		/// </summary>
		public SessionStorageManagerInproc(IStateManager stateManager, SurrogateManager surrogateManager)
			: base(stateManager, surrogateManager)
		{
			if (HttpContext.Current.Session != null)
				InitSessionCollectionItems();
			else
                {
				TraceUtil.TraceError("There is no current session. No persistence will be performed");
				_sessionCollectionItems = new Dictionary<string, object>(StringComparer.Ordinal);
                }
            }

		#region IStorageManager Members

		public override ICollection GetAllItems()
		{
			lock (_sessionCollectionItems)
			{
				return _sessionCollectionItems.Keys;
			}
        }

		private void InitSessionCollectionItems()
        {
			if (_sessionCollectionItems == null)
            {
				var sessionValue = HttpContext.Current.Session[WM_PREFIX];
				if (sessionValue != null)
					_sessionCollectionItems = (Dictionary<string, object>)sessionValue;
				else
					_sessionCollectionItems = (Dictionary<string, object>)(HttpContext.Current.Session[WM_PREFIX] = new Dictionary<string, object>(50000, StringComparer.Ordinal));
            }
        }

		public override List<string> GetChildren(string uniqueId)
		{
			// If the storageCache is null, then loop through all the items and create the cache.
			// The lifecycle of the cache is expected to be of a single request, so there's no need to track changes made in the storage.
			List<string> result = new List<string>();
			if (storageCache == null)
			{
				storageCache = new ChildrenTracker(_stateManager);
				var uniqueIdToCheck = UniqueIDGenerator.UniqueIdSeparator + uniqueId;
				foreach (string id in GetAllItems())
				{
					// No need to remove the WM_PREFIX, as the method GetAllItems already does
					// var trimmedId = id.StartsWith(WM_PREFIX) ? id.Substring(3) : id;
					storageCache.Add(id);
				}
			}
			return storageCache.GetAllDependentKeys(uniqueId);
		}

		public override IStateObject GetObject(string uniqueID)
        {
			object rawData = GetRaw(uniqueID);
			if (rawData == null) return null;
			return _serializer.RawToObject(uniqueID, rawData) as IStateObject;
        }

		public override void SaveObject(IStateObject obj)
		{
			try
			{
				object rawData = _serializer.ObjectToRaw(obj);
				SaveRaw(obj.UniqueID, rawData);
			}
			catch (Exception ex)
			{
				TraceUtil.TraceError("SessionStorageManager::SaveObject id:{0} type:{1} Exception {2}", obj.UniqueID, obj.GetType(), ex.Message);
			}
		}

		public override void RemoveObject(string uniqueId)
		{
			_sessionCollectionItems.Remove(uniqueId);
		}

		public override void SaveRaw(string uniqueId, object rawData)
        {
			_sessionCollectionItems[uniqueId] = rawData;
        }

		public override object GetRaw(string uniqueId)
		{
			if (_sessionCollectionItems != null)
        {
				object res;
				_sessionCollectionItems.TryGetValue(uniqueId, out res);
				return res;
			}
			else
				return null;
		}
		public override void SwitchUniqueIDsFrom(string itemUID, string lastUID)
		{
			object tmp;
			_sessionCollectionItems.TryGetValue(itemUID, out tmp);
			_sessionCollectionItems.Remove(itemUID);
			_sessionCollectionItems[lastUID] = tmp;
		}

		#endregion

		public override bool HasObject(string uniqueId)
        {
			return _sessionCollectionItems.ContainsKey(uniqueId);
        }
		public override int printValues()
        {
            string path = @"D:\Temp\cache" + System.DateTime.Now.TimeOfDay.ToString().Replace(":", "") + ".csv";
            // Create a file to write to.
            File.WriteAllText(path, string.Empty);
            int bytesCount = 0;
            using (StreamWriter sw = File.AppendText(path))
            {
				foreach (var item in this._sessionCollectionItems.Keys)
                {
					var value = _sessionCollectionItems[item];
                    if (value is byte[])
                    {
                        sw.WriteLine(item + ", " + (value as byte[]).Length);
                        bytesCount += (value as byte[]).Length;
                    }
                    else if (value is string)
                    {
                        sw.WriteLine(item + ", "+ System.Text.ASCIIEncoding.ASCII.GetByteCount(value as string));
                        bytesCount += System.Text.ASCIIEncoding.ASCII.GetByteCount(value as string);
                    }
                }
                sw.WriteLine("Total Bytes: " + bytesCount);
            }
            return bytesCount;
        }

    }
}
