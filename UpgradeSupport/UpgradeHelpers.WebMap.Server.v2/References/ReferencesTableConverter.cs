using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server.References
{
	[UpgradeHelpers.Helpers.AppStateJsonConverter(StateConverterKind.Server, Model = typeof(ReferencesTableConverter))]
	public class ReferencesTableConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(ReferencesTable).IsAssignableFrom(objectType);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteValueStateObject(JsonWriter writer, object val)
		{
			var stateObjectVal = ((CollectionStateObjectReference)val).TargetUniqueID;
			writer.WriteValue(stateObjectVal);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static CollectionStateObjectReference ReadInputAsStateObject(string value)
		{
			return new CollectionStateObjectReference(value);
		}

		/// <summary>
		/// Encodes the pointer as Json.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var table = value as ReferencesTable;
			table.ValidateReferences(validateUnAttached: true);//Lets make sure all the references are OK
            writer.WriteStartArray();
            writer.WriteValue(table.AttachedToParent ? 1 : 0);
            writer.WriteValue(table.IsReferencedObjectAnIDisposableDependencyControl ? 1 : 0);
            if (table._references != null)
            {
                lock (table._referencesLock)
                {
                    var refs = table._references;
                    for (int i = 0; i < refs.Count; i++)
                        WriteValueStateObject(writer, refs[i]);
                }
            }
			writer.WriteEndArray();
			writer.Flush();
		}

		/// <summary>
		/// It is not used. 
		/// Deserealization for StateObjectPointers is internal and is performed by the
		/// StorageSerializerUsingJsonnet
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="objectType"></param>
		/// <param name="existingValue"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var instance = existingValue as ReferencesTable;
			if (reader.TokenType == JsonToken.StartArray)
			{
				//reader.Read();//Reads Start Array [
                reader.Read(); 
                var attachedToParent = (long)reader.Value;
                reader.Read();//Not sure why
                instance.AttachedToParent = attachedToParent == 1 ? true : false;
                var IsReferencedObjectAnIDisposableDependencyControl = (long)reader.Value;
                reader.Read();
                instance.IsReferencedObjectAnIDisposableDependencyControl = IsReferencedObjectAnIDisposableDependencyControl == 1 ? true : false;
                if (reader.TokenType != JsonToken.EndArray)
                {
                    var references = instance.References;
                    
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        string value = (string)reader.Value;
                        references.Add(ReadInputAsStateObject(value));
                        reader.Read(); //Move next
                    }
                }
			}
			return instance;
		}

	}
}
