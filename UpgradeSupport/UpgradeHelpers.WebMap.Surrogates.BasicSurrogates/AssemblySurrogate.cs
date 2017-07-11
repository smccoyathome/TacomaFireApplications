using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UpgradeHelpers.Interfaces;
namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class AssemblySurrogate
    {
        public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var assembly = instance as Assembly;
            binaryWriter.Write(assembly.FullName);
        }

        public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var assemblyName = binaryReader.ReadString();
            return Assembly.Load(assemblyName);
        }



        public static void RegisterForAssembly()
        {
            Debug.WriteLine("Registering surrogate for Assembly");
            var signature = SurrogatesDirectory.ValidSignature("asse1");
            SurrogatesDirectory.RegisterSurrogate(
                signature: signature,
                supportedType: typeof(System.Reflection.Assembly),
                applyBindingAction: null,
                serializeEx: Serialize,
                deserializeEx: Deserialize
                );

            var runtimeAssembly = Type.GetType("System.Reflection.RuntimeAssembly");

            Debug.WriteLine("Registering surrogate for RuntimeAssembly");
            signature = SurrogatesDirectory.ValidSignature("asse2");
            SurrogatesDirectory.RegisterSurrogate(signature: signature,
                    supportedType: runtimeAssembly,
                    serializeEx: Serialize,
                    deserializeEx: Deserialize);
        }
    }


}