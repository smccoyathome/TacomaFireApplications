using SimmoTech.Utils.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class DataSetSurrogate
    {
        static IList<object> NODATASET_DEPENDENCIES = new object[0];

        public static void SerializeDataSet(object value, BinaryWriter writer, MemoryStream ms, ISurrogateContext context)
        {
            var dataSet = value as DataSet;
            BinaryFastSerializer.SerializeDataSet(context, dataSet, ms);

        }

        public static object DeserializeDataSet(BinaryReader binaryReader, ISurrogateContext context)
        {
            return BinaryFastSerializer.DeserializeDataSet(context, binaryReader.BaseStream);
        }
        public static void RegisterSurrogateForDataset()
        {
            Debug.WriteLine("Registering surrogate for DATASET");
            string signatureDataSet = SurrogatesDirectory.ValidSignature("DATASET");
            SurrogatesDirectory.RegisterSurrogate(
                signature: signatureDataSet,
                supportedType: typeof(DataSet), 
                serializeEx: SerializeDataSet,
                deserializeEx: DeserializeDataSet,
            calculateDependencies: new SurrogateDependencyCalculation[]
            {
                (obj, dependenciesContext) => NODATASET_DEPENDENCIES
            });
        }
    }
}