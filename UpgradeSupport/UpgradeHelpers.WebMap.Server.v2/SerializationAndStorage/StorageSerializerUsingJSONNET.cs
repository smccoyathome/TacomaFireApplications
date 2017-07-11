using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common.Config;
using System.Text.RegularExpressions;
using UpgradeHelpers.WebMap.Server.Common;
using System.Text;
using UpgradeHelpers.WebMap.List;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	///     This class is used to serialize the view models using json as representation
	/// </summary>
	internal class StorageSerializerUsingJsonnet : IStorageSerializer
	{


		internal static readonly JsonSerializerSettings settings = new JsonSerializerSettings
		{
			Binder = new TypeNameSerializationBinder(),
			TypeNameHandling = TypeNameHandling.Auto,
			TypeNameAssemblyFormat = FormatterAssemblyStyle.Full,
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
			ContractResolver = PropertySkipperContractResolver.CommonInstanceServerAndSkipUniqueID,
			Converters = new JsonConverter[] {
                new VirtualListSerializer(),
                new PageSerializer(),
                new StateObjectPointerConverter(), 
				new StateObjectSurrogateConverter(), 
				new LogicWithViewSerializer(),
				new ObservableDictionaryExSerializer(),
				new IEnumerableSerializer()
			    }
		};

        internal static readonly JsonSerializer sessionStorageSerializer;


        /// <summary>
        /// Because this code is in an Static Constructor, we assume that all Converters are loaded before the first serialization happens
        /// </summary>
        static StorageSerializerUsingJsonnet()
        {
            var list = new List<JsonConverter>(settings.Converters);

            foreach (var converter in StateManager.serverSideConverters)
            {
                list.Add(converter);
            }
            settings.Converters = list;
            sessionStorageSerializer = JsonSerializer.Create(settings);
        }



        public object ObjectToRaw(object obj)
		{
            var builderObjectToRaw = new StringBuilder(500);
			using (var writerObjectToRaw = new StringWriter(builderObjectToRaw))
			{
				var type = obj.GetType();
				//No longer necessary TypeCacheUtils typeMarks make the mark of the 
				//UnIntercepted and InterceptedTypes equal
				//if (TypeCacheUtils.IsGeneratedType(type))
				//{
				//    TypeCacheUtils.GetOriginalType(ref type);
				//}
				//builderObjectToRaw.Clear();
				string typeMark = null;
				if (TypeCacheUtils.ISSAFETOSHORTENALLTYPES && TypeCacheUtils.SHORTENTYPENAME)
				{
					typeMark = TypeCacheUtils.AssemblyQualifiedNameCache(type);
				}
#pragma warning disable 0162
				else
				{
					typeMark = TypeCacheUtils.AssemblyQualifiedNameCache(type);
				}
#pragma warning restore 0162
				builderObjectToRaw.Append(typeMark);
				var depentdsC = obj as IDependentsContainer;
				if (depentdsC != null && depentdsC.Dependents != null)
				{
					builderObjectToRaw.Append(string.Join(",", depentdsC.Dependents));
				}
				builderObjectToRaw.Append("?");
				using (JsonTextWriter jw = new JsonTextWriter(writerObjectToRaw))
				{
					jw.ArrayPool = JsonArrayPool.Instance;
					sessionStorageSerializer.Serialize(writerObjectToRaw, obj, type);
				}
			}
			return builderObjectToRaw.ToString();
		}

        static Regex regex = new Regex(@"(T[a-zA-Z0-9]+)");


        public object RawToObject(string uniqueId, object rawData)
		{
			if (rawData != null)
			{

				string raw = (string)rawData;
                string typeName;
                if (TypeCacheUtils.ISSAFETOSHORTENALLTYPES && TypeCacheUtils.SHORTENTYPENAME)
                {
                    typeName = raw.Substring(0, TypeCacheUtils.PADDEDCONTRACTEDTYPENAME);
                }
#pragma warning disable 0162
                else
                {
                    var match = regex.Match(raw);
                    if (!match.Success)
                    {
                        TraceUtil.TraceError("Error in StorageSerializerUsingJSONNET.rawToData while retrieve Type Descriptor from raw string. Aborting deserialization and returning null for UniqueId {0}", uniqueId);
                        return null;
                    }
                    typeName = match.Groups[1].Value;
                }
#pragma warning restore 0162
                //At this point type still contains padding spaces
				int offset = typeName.Length;
				List<string> dependents = null;
				if (raw[typeName.Length] != '?')
				{
					var endOfDependentsIndex = raw.IndexOf('?');
					var dependentsStr = raw.Substring(typeName.Length, endOfDependentsIndex - offset);
					dependents = dependentsStr.Split(',').ToList();
					offset += dependentsStr.Length + 1;
				}
				else
				{
					offset += 1;
				}
				raw = raw.Substring(offset);
                //Remove padding spaces
                var type = TypeCacheUtils.GetType(typeName);
                object actualRes = null;
                var interceptionCurrentValue = LazyBehaviour.DisableInterception;
                try
				{
					LazyBehaviour.DisableInterception = true;
                    actualRes = IocContainerImplWithUnity.Current.Resolve(type, null, IIocContainerFlags.RecoveredFromStorage);
                    var contract = sessionStorageSerializer.ContractResolver.ResolveContract(type);
                    var jsonConverter = contract.Converter;
                    if (jsonConverter != null)
                    {
                        using (StringReader strReader = new StringReader(raw))
                        using (JsonTextReader reader = new JsonTextReader(strReader))
                        {
                            reader.ArrayPool = JsonArrayPool.Instance;
                            reader.Read();
                            jsonConverter.ReadJson(reader, type, actualRes, sessionStorageSerializer);
                        }
                    }
					else
					{
                        //None of the preset JSONConverters where used
                        //1. First check if the raw value is a JSON
                        if (raw.Length > 1)
                            if (raw[0] == '{')
                            {
                                using (JsonTextReader jsonReader = new JsonTextReader(new StringReader(raw)))
                                {
                                    jsonReader.ArrayPool = JsonArrayPool.Instance;
                                    sessionStorageSerializer.Populate(jsonReader, actualRes);
                                }
                            }
                            else
                            {
                                System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(actualRes.GetType());
                                if (converter.CanConvertFrom(typeof(string)))
                                {
                                    actualRes = converter.ConvertFrom(raw.Trim('"'));
                                }
                            }
					}
                    //Once we have the uniqueID we need to make sure that the UniqueID is set
                    IStateObject asIStableObject = actualRes as IStateObject;
					if (asIStableObject!=null)
					{
						asIStableObject.UniqueID = uniqueId;
					}
				}
				finally
				{
					LazyBehaviour.DisableInterception = interceptionCurrentValue;
				}
				if (dependents != null)
				{
					var dependentsC = actualRes as IDependentsContainer;
					dependentsC.Dependents = dependents;
				}
				return actualRes;
			}
			return null;
		}

	}
}

