using System;
using Newtonsoft.Json;

namespace UpgradeHelpers.WebMap.Server
{

	/// <summary>
	/// Serializes StateObjectPointer and StateObjectPointerReference instances.
	/// 
	/// It is only use for writing Json out, it is not expected to read json 
	/// because StateObjectPointers can only be created on the server side.
	/// 
	/// Deserialization is done by StorageSerializerUsingJsonnet
	/// </summary>
    public class StateObjectPointerConverter : JsonConverter
    {

			public bool _isServer = false;
			public StateObjectPointerConverter(bool isServer=true)
			{
				this._isServer = isServer;
			}

		/// <summary>
		/// Encodes the pointer as Json.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			bool isAReference = value is StateObjectPointerReference;
			bool isForClientSide = !_isServer;
			var pointer = (StateObjectPointer) value;
			writer.WriteStartObject();
			if (isForClientSide && isAReference)
			{
				//We need to force sending the @k attribute which will be used to 
				//provide client side behaviour
				//In this case it identifies this json object as being a pointer
				// it will format the json object as 
				// {
				//      @k=2,
				//      p["->property#object1#2","proper2#panel1#2"]
				//      }
				writer.WritePropertyName("@k");
				writer.WriteValue(2);

				var supervalue = value as StateObjectPointerReferenceSuperValue;
				if (supervalue != null)
				{
                    
                    if (supervalue is StateObjectPointerReferenceSuperStruct)
                    {
                        writer.WritePropertyName("u");
                        writer.WriteStartArray();
                        writer.WriteValue(pointer.UniqueID);
                        var structAsString = JsonConvert.SerializeObject(supervalue.SuperTarget);
                        writer.WriteValue(structAsString);
                        writer.WriteEndArray();

                    }
                    else
                    {
                        writer.WritePropertyName("v");
                        writer.WriteStartArray();
                        writer.WriteValue(pointer.UniqueID);
                        writer.WriteValue(supervalue.SuperTarget);
                        writer.WriteEndArray();
                    }
				}
				else
				{
					var surrogate = value as StateObjectPointerReferenceSuperSurrogate;
					if (surrogate != null)
					{
						writer.WritePropertyName("s");
						if (surrogate.SuperTarget == null)
						{
							writer.WriteValue((string) null);
						}
						else
						{
							writer.WriteValue(((StateObjectSurrogate)surrogate.SuperTarget).UniqueID);
						}
					}
					else if (value is StateObjectPointerReferenceSerializable)
					{
						var valueS = value as StateObjectPointerReferenceSerializable;
						writer.WritePropertyName("d");
						serializer.Serialize(writer, valueS.SuperTarget);
					}
					else
					{
						writer.WritePropertyName("p");
						writer.WriteStartArray();
						writer.WriteValue(pointer.UniqueID);
						writer.WriteValue(pointer.Target.UniqueID);
						writer.WriteEndArray();
					}
				}
			}
			else
			{
				var supervalue = value as StateObjectPointerReferenceSuperValue;
				if (supervalue != null)
				{
                    var type = supervalue.SuperTarget.GetType();
                    if (supervalue is StateObjectPointerReferenceSuperStruct)
                        writer.WritePropertyName("u");
                    else
                        writer.WritePropertyName("v");

					writer.WriteStartArray();
					writer.WriteValue(supervalue.SuperTarget == null
						? typeof (Object).AssemblyQualifiedNameCache()
						: type.AssemblyQualifiedNameCache());
                    if (supervalue is StateObjectPointerReferenceSuperStruct)
                    {
                        var structSerializedAsJson = JsonConvert.SerializeObject(supervalue.SuperTarget);
                        writer.WriteValue(structSerializedAsJson);
                    }
                    else
					    writer.WriteValue(supervalue.SuperTarget);
					writer.WriteEndArray();
				}
				else if (value is StateObjectPointerReferenceSerializable)
				{
					var valueS = value as StateObjectPointerReferenceSerializable;
					writer.WritePropertyName("d");
					serializer.Serialize(writer, valueS.SuperTarget);
				}
				else
				{
					var surrogate = value as StateObjectPointerReferenceSuperSurrogate;
					if (surrogate != null)
					{
						writer.WritePropertyName("s");
						if (surrogate.SuperTarget == null)
						{
							writer.WriteValue((string)null);
						}
						else
						{
							writer.WriteValue(((StateObjectSurrogate)surrogate.SuperTarget).UniqueID);
						}
					}
					else
					{
						writer.WritePropertyName("p");
						writer.WriteValue(pointer.Target.UniqueID);
					}
				}
			}
			writer.WriteEndObject();

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
				public override
				object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
					StateObjectPointer pointer = (StateObjectPointer)existingValue;
					reader.Read();
					var propertyName = reader.Value.ToString();

					if (propertyName == "p")
					{
						var uniqueIdforReferencedObject = reader.ReadAsString();
						pointer._targetUniqueId = uniqueIdforReferencedObject;
						return pointer;
					}
					if (propertyName == "d")
					{
						reader.Read();
						var value = serializer.Deserialize(reader);
						((StateObjectPointerReferenceSerializable)pointer).SuperTarget = value;
						return pointer;
					}
					if (propertyName == "v" || propertyName == "u")
					{
						reader.Read();
						var type = TypeCacheUtils.GetType(reader.ReadAsString());
						if (type==typeof(object))
						{
							return new StateObjectPointerReferenceSuperValue();
						}
						else
						{
                            var str = reader.ReadAsString();
							object value = null;
                            if (type.IsEnum)
                                value = Enum.Parse(type, str, true);
                            else if (typeof(decimal) == type)
                                value = decimal.Parse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                            else if (typeof(double) == type)
                                value = double.Parse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                            else
                            {
                                if (TypeCacheUtils.IsAnUserStructType(type))
                                {
                                    value = JsonConvert.DeserializeObject(str, type);
                                }
                                else 
                                    value = System.Convert.ChangeType(str, type);
                            }
								
							((StateObjectPointerReferenceSuperValue)pointer).SuperTarget = value;
							return pointer;
						}
					}
					if (propertyName == "s")
					{
						//TODO surrogate
						var uniqueIDSurrogate = reader.ReadAsString();
						var superSurrogate = pointer as StateObjectPointerReferenceSuperSurrogate;
						superSurrogate._targetSurrogateUniqueId = uniqueIDSurrogate;
						return pointer;

					}

					throw new NotSupportedException();
        }

			/// <summary>
			/// Returns true when the object is an instance of StateObjectPointer or its descendants like
			/// StateObjectReference
			/// </summary>
			/// <param name="objectType"></param>
			/// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
					return typeof(StateObjectPointer).IsAssignableFrom(objectType);
        }
    }
}