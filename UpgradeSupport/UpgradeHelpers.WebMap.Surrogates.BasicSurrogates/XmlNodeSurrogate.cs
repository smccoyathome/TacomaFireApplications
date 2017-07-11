using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{
    public class XmlNodeSurrogate
    {

        public static void SerializeXmlNode(object obj, BinaryWriter writer, MemoryStream ms, ISurrogateContext context)
        {
            var node = obj as System.Xml.XmlNode;
            var document = node.OwnerDocument;
			var path = String.Empty;
			XmlElementHelper.FindXPath(node, out path);

			writer.Write(path);
        }
        public static IList<object> CalculateXmlNodeDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var document = (value as XmlElement).OwnerDocument;
            return new object[] { document };
        }

        public static object DeSerializeXmlNode(BinaryReader binaryReader, ISurrogateContext context)
        {
            var xpath = binaryReader.ReadString();
            var doc = context.Dependencies[0] as XmlDocument;
            var node = doc.SelectSingleNode(xpath);
            if (node != null)
            {
                return doc.SelectSingleNode(xpath);
            }
            else
            {
                System.Diagnostics.Trace.TraceError("SerializeXmlNode element not found by xpath. Returning dummy " + xpath);
                return doc.CreateElement("DummyXmlSurrogateErrorSerializeXmlNode");

            }
        }

        public static void RegisterSurrogateForXmlNode()
        {
            string signature = SurrogatesDirectory.ValidSignature("XMLNODE");
            SurrogatesDirectory.RegisterSurrogate(signature: signature, supportedType: typeof(System.Xml.XmlNode),
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateXmlNodeDependencies },
                serializeEx: SerializeXmlNode,
                deserializeEx: DeSerializeXmlNode);
        }
    }

}