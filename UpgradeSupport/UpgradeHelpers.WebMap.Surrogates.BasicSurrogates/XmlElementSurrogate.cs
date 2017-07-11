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
    public class XmlElementSurrogate
    {
        public static IList<object> CalculateXmlElementDependencies(object value, ISurrogateDependenciesContext dependenciesContext)
        {
            var document = (value as XmlElement).OwnerDocument;
            return new object[] { document };
        }

        public static void SerializeXmlElement(object obj, BinaryWriter writer, MemoryStream ms, ISurrogateContext context)
        {
            var node = obj as System.Xml.XmlElement;
            var document = node.OwnerDocument;

			string xpath;
			var isFullXpath = XmlElementHelper.FindXPath(node, out xpath);
			writer.Write(isFullXpath);
			writer.Write(xpath);

			if (!isFullXpath)
				//In the case a node is not attached to a document (any node in its hierarchy has a null parent)
				//the node is serialized by itself independently from the document.
				writer.Write(XmlElementHelper.GetTopParentOuterXml(node));
		}

        public static object DeSerializeXmlElement(BinaryReader binaryReader, ISurrogateContext context)
        {
			var doc = context.Dependencies[0] as System.Xml.XmlDocument;
            if (doc == null)
            {
                doc = new XmlDocument();
                ReturnDummy(doc, " doc is null");
            }
			var isFullXpath = binaryReader.ReadBoolean();
			string stringXml = String.Empty;
			var xpath = binaryReader.ReadString();

			if (!isFullXpath)
				stringXml = binaryReader.ReadString();

            if (isFullXpath)
            {
                //The document is attached to the document.
                var node = doc.SelectSingleNode(xpath);
                if (node==null)
                {
                    return ReturnDummy(doc, xpath);
                }
                return node;
            }
            else
            {
                //In the case a node is not attached to a document (any node in its hierarchy has a null parent)
                //the node is serialized by itself independently from the document.
                if (!String.IsNullOrWhiteSpace(stringXml))
                {
                    doc = new XmlDocument();
                    doc.LoadXml(stringXml);
                    if (String.IsNullOrWhiteSpace(xpath))
                        return doc.ChildNodes[0];
                    else
                    {
                        var node = doc.SelectSingleNode(xpath);
                        if (node == null)
                            return ReturnDummy(doc, xpath);
                        return node;
                    }
                }
            }
			return ReturnDummy(doc,xpath);
		}

        private static object ReturnDummy(XmlDocument doc, string xpath)
        {
            System.Diagnostics.Trace.TraceError("XmlElementSurrogate element not found by xpath. Returning dummy " + xpath);
            return doc.CreateElement("DummyXmlSurrogateErrorXmlElementSurrogate");
        }

        public static void RegisterSurrogateForXmlElement()
        {
            string signature = SurrogatesDirectory.ValidSignature("XMLELEM");

            SurrogatesDirectory.RegisterSurrogate(signature: signature, supportedType: typeof(System.Xml.XmlElement),
                calculateDependencies: new SurrogateDependencyCalculation[] { CalculateXmlElementDependencies },
                serializeEx: SerializeXmlElement,
                deserializeEx: DeSerializeXmlElement);

        }
    }
}