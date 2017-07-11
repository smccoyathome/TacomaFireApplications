using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates
{
    internal class SurrogateByISerializable
	{
        private Type _oType;
		private readonly string _signatureISerializable;
        private BinaryFormatter bFormat = new BinaryFormatter();

        internal SurrogateByISerializable(Type T, string signature)
		{
			_oType = T;
			_signatureISerializable = signature;
		}

        public static IList<object> EMPTY_LIST = new object[0];

        public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            return EMPTY_LIST;
        }

        public void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var serializableArg = instance as ISerializable;
            if (serializableArg != null)
            {
                //ISerializable serialized
                try
                {
                    bFormat.Serialize(ms, serializableArg);
                }
                catch (Exception ex)
                {
                    if (instance is System.Collections.ICollection)
                    {
                        var msg = string.Format("Error persisting Surrogate by its ISerializable implementation. Error message {0}. This object is a collection object. The error could be caused because the elements in the collection do not implement ISerializable. If the elements in the collection are IDependentModels or IDepedentViewModels consider using the XmlReference object. For more information contact Mobilize.net with klun", ex.Message);
                        System.Diagnostics.Trace.TraceError(msg);
                    }
                    else
                    {
                        var msg = string.Format("Error persisting Surrogate by its ISerializable implementation. Error message {0}.", ex.Message);
                        System.Diagnostics.Trace.TraceError(msg);
                    }

                }
            }
        }

        public object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var serializableObj = (ISerializable)bFormat.Deserialize(binaryReader.BaseStream);
            return serializableObj;
        }
    }
}

