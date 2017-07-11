using Newtonsoft.Json;
using System;
using UpgradeHelpers.Helpers;
namespace UpgradeHelpers.WebMap.Server
{
    [UpgradeHelpers.Helpers.AppStateJsonConverter(StateConverterKind.Client, Model = typeof(EventPromiseInfoForClient))]
    public class EventPromiseInfoClientConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(EventPromiseInfoForClient).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Encodes the pointer as Json.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var promise = value as EventPromiseInfoForClient;
            var promiseID = promise.StateObjectUniqueId;
            var parentObj = ViewManager.Instance.GetParent(promise);
            
            writer.WriteStartObject();
            //We need to force sending the @k attribute which will be used to 
            //provide client side behaviour
            writer.WritePropertyName("@k");
            writer.WriteValue(5);
            writer.WritePropertyName("EventID");
            writer.WriteValue(promise.ActionID);
            writer.WritePropertyName("UniqueID");
            writer.WriteValue(parentObj.UniqueID);
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
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

    }
}