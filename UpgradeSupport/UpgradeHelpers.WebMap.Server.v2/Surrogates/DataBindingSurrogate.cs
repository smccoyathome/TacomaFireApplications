
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
namespace UpgradeHelpers.WebMap
{
    public class DataBindingSurrogate
    {

        public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var databinding = instance as UpgradeHelpers.WebMap.Server.DataBinding;
            if (databinding != null)
            {
                //DataSourceProperty
                binaryWriter.Write(databinding.DataSourceProperty);
                //Next
                binaryWriter.Write(databinding.NextBinding ?? "");
                //Previous
                binaryWriter.Write(databinding.PreviousBinding ?? "");
				//ObjectProperty
				binaryWriter.Write(databinding.ObjProperty);
				return;
            }
            throw new NotImplementedException("SurrogateSerialize Error: Invalid object type expected StateManager.DataBinding");
        }

        public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var dataBinding = new DataBinding();

            dataBinding.SetDataSourceReference(context.Dependencies[0]);
            //DataSourceProperty
            dataBinding.DataSourceProperty = binaryReader.ReadString();
            //Object
            dataBinding.ObjReference = context.Dependencies[1] as IStateObject;
            //Next
            var next = binaryReader.ReadString();
            dataBinding.NextBinding = next == "" ? null : next;
            //Previous
            var previous = binaryReader.ReadString();
            dataBinding.PreviousBinding = previous == "" ? null : previous;
			//ObjectProperty
			dataBinding.ObjProperty = binaryReader.ReadString();
			return dataBinding;
        }

        public static IList<object> EMPTY_LIST = new object[0];

        public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var dataBinding = value as DataBinding;
            return new object[] { dataBinding.DataSourceReference, dataBinding.ObjReference };
        }

        public static void RegisterSurrogateForDataBinding()
        {
            var signature = SurrogatesDirectory.ValidSignature("dbin");

            SurrogatesDirectory.RegisterSurrogate(
                signature: signature,
                supportedType: typeof(UpgradeHelpers.WebMap.Server.DataBinding),
                applyBindingAction: null,
                serializeEx: Serialize,
                deserializeEx: Deserialize,
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies }
                );
        }
                                                                                        
                                                                                        
    }
}