using System;
using System.Runtime.Serialization;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// This class is used by the JSON converters when serializing type info.
	/// It provides the oportunity to do some typename contraction to minimize 
	/// </summary>
	internal class TypeNameSerializationBinder : SerializationBinder
	{
		public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			//var longAssemblyName = serializedType.Assembly.FullName;
			if (TypeCacheUtils.IsGeneratedType(serializedType))
			{
				serializedType = serializedType.BaseType;
			}
			TypeCacheUtils.AssemblyQualifiedNameCache(serializedType, out assemblyName, out typeName);
		}

		public override Type BindToType(string assemblyName, string typeName)
		{
			Type type = TypeCacheUtils.GetType(assemblyName, typeName);
			return type;
		}
	}
}