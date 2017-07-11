
namespace UpgradeHelpers.WebMap.Server
{
    using Fasterflect;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Reflection;

    public partial class PropertyInfoEx
    {

        static DefaultContractResolver contractResolver = new DefaultContractResolver();
        static MethodInfo SetPropertySettingsFromAttributesMethodInfo = typeof(DefaultContractResolver).GetMethod("SetPropertySettingsFromAttributes", BindingFlags.NonPublic | BindingFlags.Instance);
        static MethodInvoker setPropertySettings = SetPropertySettingsFromAttributesMethodInfo.DelegateForCallMethod();


        static MethodInfo CreateMemberValueProviderMethodInfo = typeof(DefaultContractResolver).GetMethod("CreateMemberValueProvider", BindingFlags.NonPublic | BindingFlags.Instance);
        static MethodInvoker createMemberValueProvider = CreateMemberValueProviderMethodInfo.DelegateForCallMethod();

        static MethodInfo CreateShouldSerializeTest = typeof(DefaultContractResolver).GetMethod("CreateShouldSerializeTest", BindingFlags.NonPublic | BindingFlags.Instance);
        static MethodInvoker createShouldSerializeTest = CreateShouldSerializeTest.DelegateForCallMethod();

        static MethodInfo SetIsSpecifiedActions = typeof(DefaultContractResolver).GetMethod("SetIsSpecifiedActions", BindingFlags.NonPublic | BindingFlags.Instance);
        static MethodInvoker setIsSpecifiedActions = SetIsSpecifiedActions.DelegateForCallMethod();


        public JsonProperty CreateJsonProperty()
        {

            PropertyInfo member = prop;
            MemberSerialization memberSerialization = MemberSerialization.OptOut;
            JsonProperty jsonProperty = new JsonProperty();

            jsonProperty.PropertyType = member.PropertyType;
            jsonProperty.DeclaringType = member.DeclaringType;
            jsonProperty.ValueProvider = (IValueProvider) createMemberValueProvider(contractResolver,new object[] { member });
            jsonProperty.AttributeProvider = new ReflectionAttributeProvider(member);
            bool flag = false;
            object[] parameters = { jsonProperty, member, member.Name, member.DeclaringType, memberSerialization, flag };
            setPropertySettings(contractResolver, parameters);
            flag = (bool) parameters[5];
            jsonProperty.Readable = prop.CanRead && (prop.GetGetMethod(nonPublic:false) != null); 
            jsonProperty.Writable = prop.CanWrite && (prop.GetSetMethod(nonPublic:false) != null);
            jsonProperty.ShouldSerialize = (Predicate<object>) createShouldSerializeTest(contractResolver,new object[] { member });
            setIsSpecifiedActions(contractResolver, new object[] { jsonProperty, member, flag });
            return jsonProperty;
        }

        JsonProperty _jsonProperty;
        public JsonProperty JsonProperty
        {
            get
            {
                if (_jsonProperty==null)
                {
                    _jsonProperty = CreateJsonProperty();
                }
                return _jsonProperty;
            }
        }
    }
}
