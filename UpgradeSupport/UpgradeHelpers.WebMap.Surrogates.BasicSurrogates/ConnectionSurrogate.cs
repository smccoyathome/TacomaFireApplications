using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using UpgradeHelpers.Interfaces;
namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class SurrogateForConnection
    {
        public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var conn = instance as System.Data.Common.DbConnection;
            if (conn != null)
            {
                binaryWriter.Write(conn.GetType().Namespace); //Used for provider
                binaryWriter.Write(conn.ConnectionString);
                binaryWriter.Write((Int32)conn.State);
				return;
            }
            throw new ArgumentException("SurrogateSerialize Error: Invalid object type expected System.Data.Common.DbConnection");
        }

        public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var providerName = binaryReader.ReadString();
            var factory = DbProviderFactories.GetFactory(providerName);
            var conn = factory.CreateConnection();
            var connString = binaryReader.ReadString();
            var state = (System.Data.ConnectionState)binaryReader.ReadInt32();
            conn.ConnectionString = connString;
            if (state == System.Data.ConnectionState.Open)
                conn.Open();
            return conn;
        }

        public static IList<object> EMPTY_LIST = new object[0];

        public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            return EMPTY_LIST;
        }

        public static void RegisterForConnection()
        {
            Debug.WriteLine("Registering surrogate for DbConnection");
            var signature = SurrogatesDirectory.ValidSignature("conn");
            SurrogatesDirectory.RegisterSurrogate(
                signature: signature,
                supportedType: typeof(System.Data.Common.DbConnection),
                applyBindingAction: null,
                serializeEx: Serialize,
                deserializeEx: Deserialize,
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies }
                );

            Debug.WriteLine("Registering surrogate for OleDbConnection");
            signature = SurrogatesDirectory.ValidSignature("conn2");
            SurrogatesDirectory.RegisterSurrogate(signature:signature,
                    supportedType:typeof(System.Data.OleDb.OleDbConnection),
                    calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies },
                    serializeEx: Serialize,
                    deserializeEx: Deserialize);

            Debug.WriteLine("Registering surrogate for OdbcConnection");
            signature = SurrogatesDirectory.ValidSignature("conn3");
            SurrogatesDirectory.RegisterSurrogate(signature: signature,
                    supportedType: typeof(System.Data.Odbc.OdbcConnection),
                    calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies },
                    serializeEx: Serialize,
                    deserializeEx: Deserialize);

            Debug.WriteLine("Registering surrogate for SqlConnection");
            signature = SurrogatesDirectory.ValidSignature("conn4");
            SurrogatesDirectory.RegisterSurrogate(signature: signature,
            supportedType: typeof(System.Data.SqlClient.SqlConnection),
            calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies },
            serializeEx: Serialize,
            deserializeEx: Deserialize);

        }
    }


}