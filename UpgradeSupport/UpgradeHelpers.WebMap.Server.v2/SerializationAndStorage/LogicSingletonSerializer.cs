using System;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{

	internal class LogicWithViewSerializer : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(ILogicWithViewModel<IViewModel>).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jobj = JObject.Load(reader);
			// We get the logic type info to instantiate the new logic obj
			var assemblyQualifiedType = jobj["$type"].Value<string>();
			Type targetType = Type.GetType(assemblyQualifiedType, false, false);
			//Retrieve UniqueID of the viewModel for the Logic object, all state is in the viewModel instance 
			var uid = jobj["UniqueID"].Value<string>();
			var viewmodel = StateManager.Current.GetObject(uid);
			if (viewmodel == null)
			{
				//If the viewmode can not be found it means that the window was closed
				return null;
			}
			//We put together the viewmodel and logic and return the new instance
			object newInstance = IocContainerImplWithUnity.Current.Resolve(targetType,null,IIocContainerFlags.NoView);
			newInstance.SetPropertyValue("ViewModel", viewmodel);
			return newInstance;

		}



		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("$type");
			var valueType = value.GetType();
			if (TypeCacheUtils.IsGeneratedType(valueType))
			{
				valueType = valueType.BaseType;
			}
			if (valueType != null)
			{
				var assemblyQualifiedName = valueType.AssemblyQualifiedName;
				writer.WriteValue(assemblyQualifiedName);
			}
			var viewmodel = (IStateObject)value.GetPropertyValue("ViewModel");
			var uid = viewmodel.UniqueID;
			writer.WritePropertyName("UniqueID");
			writer.WriteValue(uid);
			writer.WriteEndObject();
		}
	}


	internal class LogicSingletonSerializer : JsonConverter
	{
		private readonly bool _writeTypeInfo;
		private readonly bool _writeUniqueId;

		public LogicSingletonSerializer(bool writeTypeInfo, bool writeUniqueId)
		{
			_writeTypeInfo = writeTypeInfo;
			_writeUniqueId = writeUniqueId;
		}

		public LogicSingletonSerializer()
			: this(true, true)
		{
		}


		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("@#IModel");
			writer.WriteValue("0");
			if (_writeTypeInfo)
			{
				writer.WritePropertyName("__type");
				var valueType = value.GetType();
				if (TypeCacheUtils.IsGeneratedType(valueType))
				{
					valueType = valueType.BaseType;
				}
				if (valueType != null)
				{
					var assemblyQualifiedName = valueType.AssemblyQualifiedName;
					writer.WriteValue(assemblyQualifiedName);
				}
			}
			foreach (PropertyInfo prop in value.GetType().GetProperties())
			{
				if (TypeCacheUtils.IsExcludedProperty(prop))
					continue;
				//This check might be innecessary if we are serializing Deltas because the delta should not include the UniqueID
				if (!_writeUniqueId && string.Equals(prop.Name,"UniqueID")) continue;
				writer.WritePropertyName(prop.Name);
				serializer.Serialize(writer, prop.GetValue(value, null));
			}
			writer.WriteEndObject();
		}


		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jobj = JObject.Load(reader);
			var assemblyQualifiedType = jobj["__type"].Value<string>();
			Type targetType = Type.GetType(assemblyQualifiedType, false, false);
			object newInstance = IocContainerImplWithUnity.Current.ResolveUnPrepared(targetType);
			foreach (JProperty prop in jobj.Properties().ToList())
			{
				if (string.Equals(prop.Name,"__type")) continue;
				if (string.Equals(prop.Name,"@#IModel")) continue;
				PropertyInfo reflectedProperty = targetType.Property(prop.Name);
				object adapterValue = Convert.ChangeType(((Newtonsoft.Json.Linq.JValue)(prop.Value)).Value, reflectedProperty.PropertyType);
				reflectedProperty.SetValue(newInstance, adapterValue, null);
			}
			return newInstance;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IModel).IsAssignableFrom(objectType);
		}



	}
}