

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap;
public class DataCommandSurrogate
{

    public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
    {
        var cmd = instance as System.Data.Common.DbCommand;
        if (cmd != null)
        {
            binaryWriter.Write(cmd.GetType().Namespace); //Used for provider
            binaryWriter.Write(cmd.CommandText);
            binaryWriter.Write((Int32)cmd.CommandType);
        }
        throw new ArgumentException("SurrogateSerialize Error: Invalid object type expected System.Data.Common.DbConnection");

    }

    public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
    {
        var connString = binaryReader.ReadString();
        var commandReflectionTypeName = binaryReader.ReadString();

        var providerName = binaryReader.ReadString();
        var commandText = binaryReader.ReadString();
        int commandType = binaryReader.ReadInt32();
        var connectionUniqueId = binaryReader.ReadString();
        DbConnection conn = null;
        conn = context.Dependencies[0] as DbConnection;
        var factory = DbProviderFactories.GetFactory(providerName);
        var cmd = factory.CreateCommand();
        cmd.Connection = conn;
        cmd.CommandText = commandText;
        cmd.CommandType = (System.Data.CommandType)commandType;
        return cmd;
    }

    public static IList<object> EMPTY_LIST = new object[0];

    public static IList<object> CalculateDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
    {
        var cmd = value as System.Data.Common.DbCommand;
        if (cmd.Connection == null)
            return EMPTY_LIST;
        else
            return new object[] { cmd.Connection };
    }
    public static void RegisterSurrogateForCommand()
    {
        Debug.WriteLine("Registering surrogate for DbCommand");
        var signature = SurrogatesDirectory.ValidSignature("cmd");
        SurrogatesDirectory.RegisterSurrogate(
        signature: signature,
        supportedType: typeof(System.Data.Common.DbCommand),
        applyBindingAction: null,
        serializeEx: Serialize,
        deserializeEx: Deserialize,
        calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies });


        Debug.WriteLine("Registering surrogate for OleDbCommand");
        signature = SurrogatesDirectory.ValidSignature("cmd1");
        SurrogatesDirectory.RegisterSurrogate(
        signature: signature,
        supportedType: typeof(System.Data.OleDb.OleDbCommand),
        applyBindingAction: null,
        serializeEx: Serialize,
        deserializeEx: Deserialize,
        calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies }
        );


        Debug.WriteLine("Registering surrogate for OdbcCommand");
        signature = SurrogatesDirectory.ValidSignature("cmd2");
        SurrogatesDirectory.RegisterSurrogate(
            signature: signature,
            supportedType: typeof(System.Data.Odbc.OdbcCommand),
            applyBindingAction: null,
            serializeEx: Serialize,
            deserializeEx: Deserialize,
            calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies }
            );

        signature = SurrogatesDirectory.ValidSignature("cmd3");
        Debug.WriteLine("Registering surrogate for SqlCommand");
        SurrogatesDirectory.RegisterSurrogate(
                    signature: signature,
                    supportedType: typeof(System.Data.SqlClient.SqlCommand),
                    applyBindingAction: null,
                    serializeEx: Serialize,
                    deserializeEx: Deserialize,
                    calculateDependencies: new SurrogateDependencyCalculation[] { CalculateDependencies }
                    );
    }
    
}