using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Fasterflect;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.Linq.Expressions;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UpgradeHelpers.WebMap.Server
{

    internal interface IReturnWholeObjectAsDelta
    {

    }

    /// <summary>
    ///     The representation of a object of change
    /// </summary>
    public class Delta : Dictionary<string, object>
    {
        public void Print(TextWriter writer, int indentSize = 0)
        {
            var indent = new string(' ', indentSize);
            writer.WriteLine(indent + "{");
            foreach (var pair in this)
            {
                writer.Write(indent + "\"" + pair.Key + "\" = ");
                object value = pair.Value;
                if (value is Delta)
                {
                    writer.WriteLine();
                    ((Delta)(value)).Print(writer, indentSize + 4);
                }
                else
                {
                    writer.WriteLine("\"" + pair.Value + "\",");
                }
            }
            writer.WriteLine(indent + "}");
        }

        public Delta() : base(StringComparer.Ordinal) { }
    }

    /// <summary>
    ///     The Class responsible of the Tracking of Deltas
    /// </summary>
    public partial class DeltaTracker
    {
        internal static HashSet<Tuple<Type, AppStateJsonConverter>> deltaTrackerConverters = new HashSet<Tuple<Type, AppStateJsonConverter>>();
        static Dictionary<int, Fasterflect.MethodInvoker> converters = new Dictionary<int, Fasterflect.MethodInvoker>();
        internal static Fasterflect.MethodInvoker GetConverter(int modelId)
        {
            Fasterflect.MethodInvoker converter = null;
            converters.TryGetValue(modelId, out converter);
            return converter;
        }

        internal static void RegisterDeltaTrackerConverter(Type converterType, AppStateJsonConverter att)
        {
            var modelTypeID = TypeCacheUtils.GetModelTypedInt(att.Model);
            if (modelTypeID <= 0) throw new ArgumentException("A Delta Tracker Converter cannot be registered for type " + att.Model);
            var converter = converterType.DelegateForCallMethod("ProcessDelta", new Type[] { typeof(object), typeof(object) });

            converters.Add(modelTypeID, converter);
        }


		private object bitArraysLock = new ReaderWriterLockSlim();

		class WatchedInfoEx
		{
			public List<byte[]> watchedFieldsMark;
			public List<byte[]> watchedPropertiesMark;

			public WatchedInfoEx(WatcherInfo winfo, object watchedObject)
			{
				if (winfo.Fields.Count > 0)
				{
					watchedFieldsMark = new List<byte[]>(winfo.Fields.Count);
					foreach (var f in winfo.Fields)
					{
						watchedFieldsMark.Add(f.watcher.GetAsBytes(f.field.GetValue(watchedObject)));
					}
				}
				if (winfo.Properties.Count > 0)
				{
					watchedPropertiesMark = new List<byte[]>(winfo.Properties.Count);
					foreach (var p in winfo.Properties)
					{
						watchedPropertiesMark.Add(p.watcher.GetAsBytes(p.property.GetValue(watchedObject)));
					}
				}
			}


			public bool ShouldMarkAsDirty(WatcherInfo winfo, object watchedObject)
			{
				if (watchedFieldsMark != null)
				{
					int index = 0;
					foreach (var mark in watchedFieldsMark)
					{
						var currentField = winfo.Fields[index];
						var currentBytes = currentField.watcher.GetAsBytes(currentField.field.GetValue(watchedObject));
						for (int i = 0; i < currentBytes.Length; i++)
						{
							if (currentBytes[i] != mark[i]) return true;
						}
						index++;
					}
				}

				if (watchedPropertiesMark != null)
				{
					int index = 0;
					foreach (var mark in watchedPropertiesMark)
					{
						var currentProperty = winfo.Properties[index];
						var currentBytes = currentProperty.watcher.GetAsBytes(currentProperty.property.GetValue(watchedObject));
						for (int i = 0; i < currentBytes.Length; i++)
						{
							if (currentBytes[i] != mark[i]) return true;
						}
						index++;
					}
				}
				return false;
			}
		}

		Dictionary<IStateObject, WatchedInfoEx> watchedInfoEx;
		private object watchedInfoExLock = new object();

		internal Dictionary<IStateObject, BitArray> bitArrays = new Dictionary<IStateObject, BitArray>(ComparerByReference.CommonInstance);






        /// <summary>
        /// Returns a list of DirtyEntry which hold the vlaue and the Delta from the original value
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
		public List<IStateObject> getModifiedObjects(Func<IStateObject, IStateManager, bool> filters)
        {
			CheckWatchedFieldsAndPropertiesEx();
			var modifiedObjects = new List<IStateObject>();
            foreach (var element in bitArrays.Keys)
            {
                if (filters(element, stateManager))
                {
                    modifiedObjects.Add(element);
                }
            }
            return modifiedObjects;
        }

		/// <summary>
		/// Returns a list of DirtyEntry which hold the vlaue and the Delta from the original value
		/// </summary>
		/// <param name="filters"></param>
		/// <returns></returns>
		public List<DirtyEntry> getModifiedObjectDeltas(Func<IStateObject, IStateManager, bool> filters)
		{
			CheckWatchedFieldsAndPropertiesEx();
			var modifiedObjects = new List<DirtyEntry>();
			foreach (var element in bitArrays.Keys)
			{
				if (filters(element, stateManager))
				{
					var delta = GetDeltas(element);
					if (delta != null)
					{
						if (element is WebMap.List.IVirtualListSerializable)
							modifiedObjects.Add(new DirtyEntry(element, element, true));
						else
							modifiedObjects.Add(new DirtyEntry(element, delta));
					}
				}
			}
			return modifiedObjects;
		}

		private bool _checkWatchedFieldsAndPropertiesEx = false;
		private void CheckWatchedFieldsAndPropertiesEx()
        {
			if (_checkWatchedFieldsAndPropertiesEx || watchedInfoEx == null) return;
			_checkWatchedFieldsAndPropertiesEx = true;
			lock (bitArraysLock)
				{
					
					//Check watches
					foreach (IStateObject obj in this.watchedInfoEx.Keys)
					{
						if (!stateManager.IsNewObject(obj))
						{
							WatchedInfoEx watchedInfo = watchedInfoEx[obj];
							if (watchedInfo.ShouldMarkAsDirty(DeltaTracker.WatcherInfoPerType[obj.GetType()], obj))
								stateManager.AddNewJustPromotedObject(obj);
						}
					}
				}
		}






		public class WatcherInfo
        {
			public class FieldInfoAndWatcherInfo
            {
				internal FieldInfo field;
				internal IDeltaWatcher watcher;
			}

			public class PropertyInfoAndWatcherInfo
			{
				internal PropertyInfo property;
				internal IDeltaWatcher watcher;
			}

			public List<FieldInfoAndWatcherInfo> Fields;
			public List<PropertyInfoAndWatcherInfo> Properties;

			public WatcherInfo(bool noinfo = false)
			{
				if (!noinfo)
				{
					Fields = new List<FieldInfoAndWatcherInfo>();
					Properties = new List<PropertyInfoAndWatcherInfo>();
				}
			}
		}

		static WatcherInfo NOINFO = new WatcherInfo(noinfo: true);
		static Dictionary<Type, WatcherInfo> WatcherInfoPerType = new Dictionary<Type, WatcherInfo>();
		static object WatcherInfoPerTypeLock = new object();


        /// <summary>
        /// Load the internal cache table with information about watched fields
        /// </summary>
        /// <param name="modelType"></param>
        public static WatcherInfo LoadWatcherInfo(Type modelType)
        {
            WatcherInfo winfo;
			lock (WatcherInfoPerTypeLock)
			{
				if (!WatcherInfoPerType.TryGetValue(modelType, out winfo))
				{
					var fields = modelType.Fields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
					var fieldsWithWatches = from field in fields
											let att = field.GetCustomAttribute(typeof(Watchable), true) as Watchable
											where att != null
											select new { Field = field, WatcherType = att.WatcherType };
					foreach (var f in fieldsWithWatches)
					{
						var field = f.Field;
						ValidateWatcherType(field);
						var isStruct = field.FieldType.IsValueType && !field.FieldType.IsPrimitive && !field.FieldType.IsEnum;
						if (isStruct)
						{
							if (winfo == null)
								winfo = new WatcherInfo();
							winfo.Fields.Add(new WatcherInfo.FieldInfoAndWatcherInfo() { field = field, watcher = (IDeltaWatcher)Activator.CreateInstance(f.WatcherType) });
						}
					}

					var props = modelType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
					var propertiesWithWatches = from p in props
												let att = p.GetCustomAttributes(typeof(Watchable), true).FirstOrDefault() as Watchable
												where att != null
												select new { Property = p, WatcherType = att.WatcherType };
					foreach (var p in propertiesWithWatches)
					{
						var prop = p.Property;
						ValidateWatcherType(prop);
						if (winfo == null)
							winfo = new WatcherInfo();
						winfo.Properties.Add(new WatcherInfo.PropertyInfoAndWatcherInfo() { property = prop, watcher = (IDeltaWatcher)Activator.CreateInstance(p.WatcherType) });
					}
					if (winfo == null) winfo = NOINFO;

					WatcherInfoPerType.Add(modelType, winfo);
				}
			}
            return winfo;
        }

		private void RegisterWatchablePropertiesAndFieldsEx(IStateObject model)
        {
			var modelType = model.GetType();
            var winfo = LoadWatcherInfo(modelType);
            //It this type has no watchers, just exit.
			if (Object.ReferenceEquals(winfo, NOINFO)) return;
            //If the type has watchers then the delta tracker associated the model with its watchers info
			watchedInfoEx = watchedInfoEx ?? new Dictionary<IStateObject, WatchedInfoEx>(ComparerByReference.CommonInstance);
			if (!watchedInfoEx.ContainsKey(model))
			{
				lock (watchedInfoExLock)
				{
					watchedInfoEx.Add(model, new WatchedInfoEx(winfo, model));
				}
		}
		}




        /// <summary>
        /// Watchers can not be applied on IStateObjects. So we need to validate that
        /// </summary>
        /// <param name="type"></param>
        private static void ValidateWatcherType(MemberInfo memInfo)
        {
            Type type = null;
            string elementName = memInfo.Name;
            if (memInfo is FieldInfo)
            {
                var finfo = (FieldInfo)memInfo;
                type = finfo.FieldType;
#if DEBUG
                Debug.Assert(!typeof(IStateObject).IsAssignableFrom(type),
                            string.Format("DeltaTracker::ValidateWatcherType Error: The watcher attribute on {0}.{1} is wrong " +
                                          "because watcher attributes are meant to be used on fields that have a FieldType is not an IStateObject",
                                          TypeCacheUtils.GetOriginalTypeName(finfo.DeclaringType), elementName));
#endif
            }
            else if (memInfo is PropertyInfo)
            {
                var pinfo = (PropertyInfo)memInfo;
                type = pinfo.PropertyType;
                var isVirtual = pinfo.GetGetMethod().IsVirtual;
				Debug.Assert(!typeof(IStateObject).IsAssignableFrom(type) && !isVirtual,
					string.Format("DeltaTracker::ValidateWatcherType Error: The watcher attribute on {0}.{1} is wrong because watcher attributes are meant to be used on non-virtual properties of types that are not an IStateObject",
					TypeCacheUtils.GetOriginalTypeName(pinfo.DeclaringType), elementName));

            }
        }



        public bool NoMoreAttachments = false;
        /// <summary>
        ///     It tries to subscribe to given model to the list of subscribed models
        ///     If it succeeds, it resets the given model and adds a bit array of its properties
        /// </summary>
        /// <param name="model">The instance of IChangesTrackeable</param>
        public void AttachModel(IStateObject model)
		{
			RegisterWatchablePropertiesAndFieldsEx(model);
        }

        /// <summary>
        ///     It tries to removes the given model of the list of the subscribed models and the
        ///     bit array of the data arrays
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True if is succeeds, false otherwise</returns>
        public void DetachModel(IStateObject model)
        {
            // Removing model from list of models
			lock (bitArraysLock)
			{
				bitArrays.Remove(model);
			}
        }

        public void Reset()
		{
			lock (bitArraysLock)
			{
				bitArrays.Clear();
			}
		}

        public bool IsDirtyModel(IStateObject model)
		{
            return stateManager.IsNewObject(model);
        }



        public bool IsModified(IStateObject instance)
        {
            BitArray data;
            if (bitArrays.TryGetValue(instance, out data))
			{
                return true;
            }
			return false;
		}

        /// <summary>
        ///     It collects all the delta objects int the given instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <returns>The changes found in the instance</returns>
        public object GetDeltas(IStateObject instance)
        {
            //  Arrayway
            BitArray bitArray;
            Delta delta = null;
            // if model has been subscribed to any delta tracker
            if (bitArrays.TryGetValue(instance, out bitArray))
            {
				if (bitArray == null)
					return null;
				if (instance is IReturnWholeObjectAsDelta)
				{
					return instance;
				}
                var propertiesMatchingBitArrays = TypePropertiesCache.GetArrayPropertiesOrderedByIndex(instance.GetType());
                var dataCount = bitArray.Count;
                for (var bitArrayPosition = 0; bitArrayPosition < dataCount; bitArrayPosition++)
                {
                    if (bitArray.Get(bitArrayPosition))
                    {
                        var propertyInfoEx = propertiesMatchingBitArrays[bitArrayPosition];
                        if (!propertyInfoEx.mustIgnoreMemberForClient)
                        {
                            object propValue = propertyInfoEx.prop.GetValue(instance);
                            if (delta == null) delta = new Delta();
                            delta.Add(propertyInfoEx.prop.Name, propValue);
                        }
                    }
                }
            }
            if (delta != null)
			{
                //We are including the UniqueID in the delta
                if (delta.Count > 0)
				{
                    delta["UniqueID"] = instance.UniqueID;
				}
			}
            return delta;
		}





		/// <summary>
        ///     The oposite of Reset Deltas, it sets every property of the instance as if it was changed
		/// </summary>
        /// <param name="instance">The instance implementing the IchangesTrackeable Interface </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MarkAllAsModified(IStateObject instance)
		{
            BitArray data;
            // if model has been subscribed to any delta tracker
            if (bitArrays.TryGetValue(instance, out data))
			{
                bitArrays.Remove(instance);
			}
            AttachModel(instance);
        }

		/// <summary>
		///     The oposite of Reset Deltas, it sets every property of the instance as if it was changed
		/// </summary>
		/// <param name="instance">The instance implementing the IchangesTrackeable Interface </param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void MarkEntityForPersist(IStateObject instance)
		{
			if (instance.UniqueID == null
				|| IsDirtyModel(instance)
				|| !StateManager.AllBranchesAttached(instance)) return;
			BitArray data;
			lock (modifiedLock)
			{
				if (!bitArrays.TryGetValue(instance, out data))
				{
					bitArrays.Add(instance, null);
				}
			}
		}


		/// <summary>
		///     Given the instance it tries to add the bit array to the dictionary of bit arrays
		///     representing the state (modified or not) of the model properties.
		/// </summary>
		/// <param name="model">The instance of IChangesTrackeable</param>
		public void AddsBitArray(IStateObject model)
		{
			BitArray data;
			if (!bitArrays.TryGetValue(model, out data))
			{
				var props = TypePropertiesCache.GetArrayPropertiesOrderedByIndex(model.GetType());
				bitArrays.Add(model, new BitArray(props.Count));
		}
			else
		{
				data.SetAll(false);
			}
		}

        /// <summary>
        ///     Given the property name and its instance, it sets in the corresponding bit array at
        ///     the corresponding index (of the property) the value to true (modified)
        ///     Assumming that model is not a dirty model
        /// </summary>
        /// <param name="model">The instance of IChangesTrackeable</param>
        /// <param name="property">The name of the property</param>
        public void MarkAsModified(IStateObject model, string property)
        {
			
			if (model.UniqueID == null
				|| IsDirtyModel(model)
				|| !StateManager.AllBranchesAttached(model)) return;

			PropertiesExDictionary typeProperties = TypePropertiesCache.GetPropertiesIndexPositionOfType(model.GetType());
            int propertyIndex;
            if (!typeProperties.TryGetValue(property, out propertyIndex))
			{
                return;
			}
            BitArray data;
            lock (modifiedLock)
            {
                if (!bitArrays.TryGetValue(model, out data))
                {
                    bitArrays.Add(model, data = new BitArray(typeProperties.PropertiesList.Count));
                }
				if (data == null)
					bitArrays[model] = data = new BitArray(typeProperties.PropertiesList.Count);
            }
            data.Set(propertyIndex, true);
        }

        private Object modifiedLock = new Object();
		private IStateManager stateManager;

		public DeltaTracker(IStateManager stateManager)
		{
			// TODO: Complete member initialization
			this.stateManager = stateManager;
		}
		/// <summary>
		///     Given the property Index and its instance, it sets in the corresponding bit array at
		///     the corresponding index (of the property) the value to true (modified)
		///     Assumming that model is not a dirty model
		/// </summary>
		/// <param name="model">The instance of IChangesTrackeable</param>
		/// <param name="property">The name of the property</param>
		public void MarkAsModified(IStateObject model, int index)
		{
			if (model.UniqueID == null
				|| IsDirtyModel(model)
				|| !StateManager.AllBranchesAttached(model)) return;
			BitArray data;
			lock (modifiedLock)
			{

				if (!bitArrays.TryGetValue(model, out data))
				{
					int typePropertiesLength = TypePropertiesCache.GetArrayPropertiesCount(model.GetType());
					bitArrays.Add(model, data = new BitArray(typePropertiesLength));
				}
				if (data == null)
				{
					int typePropertiesLength = TypePropertiesCache.GetArrayPropertiesCount(model.GetType());
					bitArrays[model] = data = new BitArray(typePropertiesLength);
				}
			}
			data.Set(index, true);
		}


		internal void Dispose()
		{
			this.bitArrays = null;
			this.watchedInfoEx = null;
		}
	}


}