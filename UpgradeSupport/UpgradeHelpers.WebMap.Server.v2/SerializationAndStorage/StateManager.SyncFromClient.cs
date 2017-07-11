using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.List;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{

    partial class StateManager
    {
        internal JObject lastRequestFromClient;
        static JsonSerializer syncDirtyModelsSerializer;

        /// <summary>
        /// This is the collection of JsonConverters that are used when populating object from the json 
        /// fragments received from sendAction calls
        /// </summary>
        internal static List<JsonConverter> convertersForAppChanges = new List<JsonConverter>();



        static StateManager()
        {
            convertersForAppChanges.AddRange(new JsonConverter[] { new ViewsStateDeltaConverter(), new VirtualListSerializerClient() });
        }

        /// <summary>
        /// Adds a new JsonConverter that can be used when populating or synching the current state objects with the changes from the 
        /// client
        /// </summary>
        /// <param name="additionalConverter">The new converter instance that will be added to the converter collection</param>
        public static void AddConverter(JsonConverter additionalConverter)
        {
            convertersForAppChanges.Add(additionalConverter);
        }

        internal static void AddConverters()
        {

            foreach (var converter in convertersForAppChanges)
            {
                _serializer.Converters.Add(converter);
                _serializerIndex.Converters.Add(converter);
            }
            _serializer.Converters.Add(new LogicSingletonSerializer(writeUniqueId: false, writeTypeInfo: false));
            _serializer.Converters.Add(new LogicWithViewSerializer());
            _serializerIndex.Converters.Add(new LogicSingletonSerializer(writeTypeInfo: false, writeUniqueId: true));
            _serializerIndex.Converters.Add(new StateObjectSerializerIndex(writeTypeInfo: false, writeUniqueID: true));

        }

        internal void SyncDirtyModel(JToken jobj)
        {
            string uniqueId = ((JProperty)(jobj)).Name;
            IStateObject obj = StateManager.Current.GetObject(uniqueId);
            Debug.Assert(obj != null, "Model to sync was not found ID:" + uniqueId);
            JToken val = jobj.FirstOrDefault();
            if (val != null && (!(val is JArray) || (((JArray)val).Count > 0 && ((JArray)val)[0].HasValues)))
            {
                var type = obj.GetType();
                bool converterUsed = false;
                foreach (var converter in convertersForAppChanges)
                {
                    if (converter.CanConvert(type))
                    {
                        var ns = converter.GetType().Namespace;
                        if (ns != null && ns.Equals("UpgradeHelpers.BasicViewModels.SerializationAndStorage", StringComparison.Ordinal))
                        {

                            using (JsonReader reader = val.CreateReader())
                            {
                                reader.Read();
                                converter.ReadJson(reader, type, obj, syncDirtyModelsSerializer);
                                converterUsed = true;
                                break;
                            }

                        }
                    }
                }
                if (!converterUsed)
                {
                    syncDirtyModelsSerializer.Populate(val.CreateReader(), obj);
                }
            }
        }


        private void SyncDirtyModels(JObject jobj)
        {
            JToken dirty = jobj["dirty"];
            if (dirty != null)
            {

                if (syncDirtyModelsSerializer == null)
                {
                    var settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.None,
                        ContractResolver = PropertySkipperContractResolver.CommonInstanceDefaults,
                        Converters = convertersForAppChanges
                    };
                    syncDirtyModelsSerializer = JsonSerializer.Create(settings);
                }

                ViewManager.Instance.Events.Suspend();
                foreach (JToken viewmodel in dirty)
                {
                    //We are adding robustness to the Client side syncronization
                    //However this might be an indication of either:
                    //a Problems with ViewModel Design
                    //b Session corrupted (which is not that likely)
                    //c Serialization issues
                    try
                    {
                        SyncDirtyModel(viewmodel);
                    }
                    catch (Exception ex)
                    {
                        TraceUtil.TraceError("ViewManager::SyncDirtyModels Problems with sync of viewmodel {0}, Message {1} ", viewmodel, ex.Message);
                    }
                }
                ViewManager.Instance.Events.Resume();
            }
        }


        /// <summary>
        /// Syncs Application State using a JSON of changes.
        /// It the jsonRequest parameter is not given. Json data will be assumed as comming from a web request
        /// </summary>
        /// <param name="jsonRequest"></param>
        internal void SyncronizeWithChangesFromClient(string jsonRequest, Func<TextReader> JsonRequestReaderCallBack)
        {
#if DEBUG
            if (jsonRequest == null && JsonRequestReaderCallBack == null) throw new ArgumentException("jsonRequest and JsonRequestReaderCallBack are null");
#endif
            // now make sure we are dealing with a json request

            TextReader streamReader = null;
            //Was a json provider to this call?
            if (jsonRequest != null)
            {
                streamReader = new StringReader(jsonRequest);
            }
            else
            {
                streamReader = JsonRequestReaderCallBack();
            }

            if (streamReader != null)
            {

                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    jsonReader.ArrayPool = JsonArrayPool.Instance;
                    // tell JSON to read
                    if (!jsonReader.Read())
                        throw new ArgumentException("Error parsing WebMap AppChanges");
                    lastRequestFromClient = JObject.Load(jsonReader);

                    if (lastRequestFromClient != null)
                    {
                        SyncDirtyModels(lastRequestFromClient);
                        ViewManager.Instance.UpdateViewManager(lastRequestFromClient);
                    }
                }
            }
            else
            {
                TraceUtil.WriteLine("ViewManager::SycronizeWithChangesFromClient: It was not posible to read JSON AppChanges from request");
            }



        }
    }
}