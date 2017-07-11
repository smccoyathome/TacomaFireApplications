using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
	public class XmlDocumentSurrogate
	{
        static IList<object> NO_DEPENDENCIES = new object[0];
        public static void SerializeXmlDocument(object obj, BinaryWriter writer, MemoryStream ms, ISurrogateContext context)
		{
			var doc = obj as System.Xml.XmlDocument;
			var stringToBeSaved = "";
			StringWriter sw = new System.IO.StringWriter();
			XmlTextWriter xtw = new System.Xml.XmlTextWriter(sw);

			xtw.Formatting = Formatting.None;
			doc.WriteContentTo(xtw);
			stringToBeSaved = sw.ToString();
			writer.Write(stringToBeSaved);
		}
        public static IList<object> CalculateXmlDocumentDependencies(object value, ISurrogateDependenciesContext dependenciesContext) { return NO_DEPENDENCIES; }

		public static object DeSerializeXmlNode(BinaryReader binaryReader, ISurrogateContext context)
		{
			string xml = binaryReader.ReadString();
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

			//, MOBILIZE, 09/8/2016,TODO,mvega,"Manually changed", "Support case when xml document has no document loaded (xml is empty), to avoid LoadXml throwing an exception"
			if (!string.IsNullOrEmpty(xml))
			{
				doc.LoadXml(xml);
			}
			return doc;
		}

		public static void RegisterSurrogateForXmlDocument()
		{
			string signature = SurrogatesDirectory.ValidSignature("XMLDOC");
			SurrogatesDirectory.RegisterSurrogate(signature: signature, supportedType: typeof(System.Xml.XmlDocument),

				calculateDependencies: new SurrogateDependencyCalculation[] { CalculateXmlDocumentDependencies },
				serializeEx: SerializeXmlDocument,
                deserializeEx: DeSerializeXmlNode);


		}
	}
}
