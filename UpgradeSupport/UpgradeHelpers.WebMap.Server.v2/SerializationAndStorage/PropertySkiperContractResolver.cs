using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.WebMap.Server
{
	internal class PropertySkipperContractResolver : DefaultContractResolver, IWebMapContractResolver
	{

		internal static PropertySkipperContractResolver CommonInstanceDefaults = new PropertySkipperContractResolver(skipObjectProperties: false);

        internal static PropertySkipperContractResolver CommonInstanceServerAndSkipUniqueID = new PropertySkipperContractResolver(skipUniqueId: true, server: true);

        internal static PropertySkipperContractResolver CommonInstanceClient = new PropertySkipperContractResolver(skipUniqueId: false, server: false);
        bool serverSide = false;
		private bool skipUniqueId = false;
		private bool skipObjectProperties = false;
		private PropertySkipperContractResolver(bool skipUniqueId = true, bool server = false, bool skipObjectProperties = true)
			: base()
		{
			serverSide = server;
			this.skipUniqueId = skipUniqueId;
			this.skipObjectProperties = skipObjectProperties;
		}

        static JsonProperty[] EMPTY = new JsonProperty[0];

        bool IWebMapContractResolver.IsServerSide
        {
            get
            {
                return serverSide;
            }
        }

        public override JsonContract ResolveContract(Type type)
        {
            //We do not want two different contracts for the proxy type and the actual type
            if (TypeCacheUtils.IsGeneratedType(type))
            {
                TypeCacheUtils.GetOriginalType(ref type);
            }
            return base.ResolveContract(type);
        }


        protected override JsonContract CreateContract(Type objectType)
        {
            var baseContract = base.CreateContract(objectType);
            if (serverSide)
            {
                foreach (var converter in StorageSerializerUsingJsonnet.settings.Converters)
                {
                    if (converter.CanConvert(objectType))
                    {
                        baseContract.Converter = converter;
                        break;
                    }
                }
            }
            else /*  */
            {
                foreach (var converter in StateManager.convertersForAppChanges)
                {
                    if (converter.CanConvert(objectType))
                    {
                        baseContract.Converter = converter;
                        break;
                    }
                }

            }
            return baseContract;

        }

        protected override List<MemberInfo> GetSerializableMembers(Type type)
        {
            if (TypeCacheUtils.IsAnStructType(type) ||
               (type == typeof(CurrentState)) ||
               (type == typeof(ViewsState)) ||
               (type == typeof(ClientCommand)))
                return base.GetSerializableMembers(type);

            List<MemberInfo> props = new List<MemberInfo>();
            foreach (var propEx in TypePropertiesCache.GetArrayPropertiesOrderedByIndex(type))

            {
                if (propEx!=null && !propEx.IsExcludedPropertyForSerialization(serverSide, skipUniqueId, skipObjectProperties))
                    props.Add(propEx.prop);
            }
            return props;
        }

        static Fasterflect.MethodInvoker nameTableAddInvoker;
        private string AddToNameTable(object nameTable, string propertyName)
        {
            if (nameTableAddInvoker==null)
            {
                nameTableAddInvoker = nameTable.GetType().GetMethod("Add").DelegateForCallMethod();
            }
            return (string)nameTableAddInvoker(nameTable, new object[] { propertyName });
        }


        static MemberGetter getterForNameTable;
        private object GetNameTableFromState(object state)
        {
            if (getterForNameTable==null)
            {
                getterForNameTable = state.GetType().DelegateForGetFieldValue("NameTable");
            }
            return getterForNameTable(state);
        }

        static MethodInfo GetStateMethodInfo = typeof(PropertySkipperContractResolver).GetMethod("GetState", BindingFlags.NonPublic | BindingFlags.Instance);
        static Fasterflect.MethodInvoker getState = GetStateMethodInfo.DelegateForCallMethod();

        private object GetInternalState()
        {
            return getState(this);
        }


    }
}