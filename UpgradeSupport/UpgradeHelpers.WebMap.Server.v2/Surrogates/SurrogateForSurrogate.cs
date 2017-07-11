using System;
using System.Collections.Generic;
using System.IO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
namespace UpgradeHelpers.WebMap
{
    public class SurrogateForSurrogate
    {
        public static void Serialize(object instance, BinaryWriter binaryWriter, MemoryStream ms, ISurrogateContext context)
        {
            var surrogate = instance as StateObjectSurrogate;
            if (surrogate != null)
            {
                //RefCount
                binaryWriter.Write((Int32)surrogate.objectRefs.Count);
                //Refs
                foreach (var v in surrogate.objectRefs)
                {
                    binaryWriter.Write(v.UniqueID);
                }
            }
            else
                throw new ArgumentException("SurrogateSerialize Error: Invalid object type expected Surrogate");        
        }

        public static object Deserialize(BinaryReader binaryReader, ISurrogateContext context)
        {
            var surrogate = new StateObjectSurrogate
            {
                UniqueID = context.SurrogateUniqueID,
                
            };
            var refCount = binaryReader.ReadInt32();
            ///This cast is assumed to be valid because we are inside the v2 implementation assembly
            var surrogateManager = ((UpgradeHelpers.WebMap.Server.Surrogates.SurrogateContext)context)._surrogateManager;

            for (int i = 0; i < refCount; i++)
            {
                var referenceId = binaryReader.ReadString();
                surrogateManager.AddSurrogateReference(surrogate, referenceId);
            }
            return surrogate;        
        }

        public static void RegisterSurrogateForSurrogate()
        {
            var signature = SurrogatesDirectory.ValidSignature("surr");
            SurrogatesDirectory.RegisterSurrogate(
                signature: signature,
                supportedType: typeof(StateObjectSurrogate),
                applyBindingAction: null,
                serializeEx: Serialize,
                deserializeEx: Deserialize);
        }
    }
}
