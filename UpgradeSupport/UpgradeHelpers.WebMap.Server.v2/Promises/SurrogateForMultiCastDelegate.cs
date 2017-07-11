using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Promises
{
    internal class SurrogateForMultiCastDelegate
    {

        private Type _oType;
        private readonly string _signature;
        internal SurrogateForMultiCastDelegate(Type T, string signature)
        {
            _oType = T;
            _signature = signature;
        }


        public void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var delegateObj = ((MulticastDelegate)instance);
            binaryWriter.Write(delegateObj.Method.DeclaringType.AssemblyQualifiedNameCache());
            binaryWriter.Write(delegateObj.Method.Name);
        }

        public IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var delegateObj = ((MulticastDelegate)value);
            return new object[] { delegateObj.Target };
        }

        public object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var declaringTypeAsString = binaryReader.ReadString();
            var declaringType = TypeCacheUtils.GetType(declaringTypeAsString);
            var methodName = binaryReader.ReadString();

            var target = context.Dependencies[0];

            var methodInfo = declaringType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return PromiseUtils.CreateDelegateFromMethodInfo(target, methodInfo);
        }

    }
}