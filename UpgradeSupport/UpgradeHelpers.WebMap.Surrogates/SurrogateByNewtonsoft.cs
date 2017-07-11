using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace UpgradeHelpers.WebMap.Surrogates
{
	internal class SurrogateByNewtonsoft
	{
		private Type _oType;
		private readonly string _signatureNewtonsoft;
		public SurrogateByNewtonsoft(Type T, string signature)
		{
			_oType = T;
			_signatureNewtonsoft = signature;
		}

		internal object SerializeAction(object obj)
		{
			var ms = new MemoryStream();
			var binaryWriter = new BinaryWriter(ms);
			//Signature
			binaryWriter.Write(_signatureNewtonsoft);
			var msObject = new MemoryStream();
			var objectWriter = new BinaryWriter(msObject);
			var res = JsonConvert.SerializeObject(obj);
			objectWriter.Write(res);
			binaryWriter.Write(msObject.ToArray());
			return ms.ToArray();
		}

		internal object DeserializeAction(System.IO.BinaryReader binaryReader)
		{
			var objectReader = new BinaryReader(binaryReader.BaseStream);
			var json = objectReader.ReadString();
			var res = JsonConvert.DeserializeObject(json);
			return res;
		}
	}
}
