using System;
using System.Collections.Generic;
using System.IO;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Promises
{
    class SurrogateForDisplayClass 
    {
        private string oTypeName;
        private Type _oType;
		private readonly string _signatureISerializable;
        internal SurrogateForDisplayClass(Type T, string signature)
		{
			_oType = T;
			_signatureISerializable = signature;
            oTypeName = _oType.FullName;
		}

        public void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            Type outType = null;
            IStateObject model = null;
            PromiseUtils.SerializeStateForDelegate(StateManager.Current, instance, binaryWriter, _oType, out outType, out model);
        }

        public static IList<object> EMPTY_LIST = new object[0];

        public IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            IList<object> dependencies = null;
            PromiseUtils.CalculateDependencies(value,_oType,ref dependencies);
            if (dependencies==null)
            {
                dependencies = EMPTY_LIST;
            }
            return dependencies;
        }

        public object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            string fieldName = null;
            var delegateHiddenClass = Activator.CreateInstance(_oType);
            PromiseUtils.DeserializeStateForDelegate(binaryReader, _oType, delegateHiddenClass, ref fieldName);
            return delegateHiddenClass;
        }

        public void WriteSignature(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(_signatureISerializable);
        }
       
    }
}
