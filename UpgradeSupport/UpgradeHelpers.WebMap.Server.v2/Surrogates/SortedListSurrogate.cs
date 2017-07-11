using Fasterflect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class SortedlistSurrogate
	{
		public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
		{
			var sortedList = instance as System.Collections.SortedList;
			binaryWriter.Write(sortedList.Count);
			foreach (System.Collections.DictionaryEntry item in sortedList)
			{
				var asStateObject = item.Key as IStateObject;
				//Flag to determine if value is stateobject
				binaryWriter.Write(asStateObject != null);
				//Save Key
				if (asStateObject != null)
				{
					if (!StateManager.AllBranchesAttached(asStateObject.UniqueID))
					{
						var sortedListSurrogate = StateManager.Current.surrogateManager.GetSurrogateFor(sortedList, generateIfNotFound: false);
						AdoptionInformation.StaticAdopt(sortedListSurrogate, asStateObject);
					}

					//TODO this line has to be removed from here when the SaveObject will be generalized
					StateManager.Current.StorageManager.SaveObject(asStateObject);

					foreach (var pair in StateManager.Current.GetDependentItemsInCache(asStateObject.UniqueID))
					{
						StateManager.Current.StorageManager.SaveObject(pair.Value);
					}

					binaryWriter.Write(asStateObject.UniqueID);
				}
				else
				{
					binaryWriter.Write(item.Key.ToString());
				}
				//Save Value
				asStateObject = item.Value as IStateObject;
				binaryWriter.Write(asStateObject != null);
				//Save Key
				if (asStateObject != null)
				{
					if (!StateManager.AllBranchesAttached(asStateObject.UniqueID))
					{
						var sortedListSurrogate = StateManager.Current.surrogateManager.GetSurrogateFor(sortedList, generateIfNotFound: false);
						AdoptionInformation.StaticAdopt(sortedListSurrogate, asStateObject);
					}

					//TODO this line has to be removed from here when the SaveObject will be generalized
					StateManager.Current.StorageManager.SaveObject(asStateObject);

					foreach (var pair in StateManager.Current.GetDependentItemsInCache(asStateObject.UniqueID))
					{
						StateManager.Current.StorageManager.SaveObject(pair.Value);
					}

					binaryWriter.Write(asStateObject.UniqueID);
				}
				else
				{
					binaryWriter.Write(item.Key.ToString());
				}
			}
		}

		public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
		{
			var res = new System.Collections.SortedList();
			var count = binaryReader.ReadInt32();
			for (int i = 0; i < count; i++)
			{
				//Key
				var isStateObject = binaryReader.ReadBoolean();
				var data = binaryReader.ReadString();
				object key;
				if (isStateObject)
					key = context.RestoreStateObject(data);
				else
					key = data;
				//Value

				isStateObject = binaryReader.ReadBoolean();
				data = binaryReader.ReadString();
				object value;
				if (isStateObject)
					value = context.RestoreStateObject(data);
				else
					value = data;
				res.Add(key, value);
			}
			return res;
		}

		public static void RegisterSurrogate()
		{
			string signature = SurrogatesDirectory.ValidSignature("SLIST");
			SurrogatesDirectory.RegisterSurrogate(
				signature: signature,
				supportedType: typeof(System.Collections.SortedList),
				applyBindingAction: null,
				serializeEx: Serialize,
				deserializeEx: Deserialize);
		}
	}
}
