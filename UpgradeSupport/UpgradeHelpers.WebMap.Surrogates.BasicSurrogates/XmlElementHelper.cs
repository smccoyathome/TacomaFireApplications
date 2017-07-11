using System;
using System.Text;
using System.Xml;

namespace UpgradeHelpers.WebMap.Server
{
	public class XmlElementHelper
	{
		public static bool FindXPath(XmlNode node, out string xpath)
		{
			StringBuilder builder = new StringBuilder();
			while (node != null)
			{
				switch (node.NodeType)
				{
					case XmlNodeType.Attribute:
						builder.Insert(0, "/@" + node.Name);
						node = ((XmlAttribute)node).OwnerElement;
						break;
					case XmlNodeType.Element:
						int index = FindElementIndex((XmlElement)node);
						if (index == -1)
						{
							//If no parent is found and the node is not the XmlDocument
							//it means it has been removed from the Document or has not been added yet
							//in any case the xpath is built up to this node
							builder.Insert(0, "/" + node.Name + "[1]");
							xpath = builder.ToString();
							return false;
						}
						builder.Insert(0, "/" + node.Name + "[" + index + "]");
						node = node.ParentNode;
						break;
					case XmlNodeType.Document:
						xpath = builder.ToString();
						return true;
					default:
						throw new ArgumentException("Only elements and attributes are supported");
				}
			}
			throw new ArgumentException("Node was not in a document");
		}

		private static int FindElementIndex(XmlElement element)
		{
			XmlNode parentNode = element.ParentNode;
			if (parentNode is XmlDocument)
			{
				return 1;
			}
			else if (parentNode == null)
				return -1; // No parent has been found for this node so the index cannot be calculated directly.

			XmlElement parent = (XmlElement)parentNode;
			int index = 1;
			foreach (XmlNode candidate in parent.ChildNodes)
			{
				if (candidate is XmlElement && candidate.Name == element.Name)
				{
					if (candidate == element)
					{
						return index;
					}
					index++;
				}
			}
			throw new ArgumentException("Couldn't find element within parent");
		}
		/// <summary>
		/// Returns the outer xml from the top node parent
		/// </summary>
		public static string GetTopParentOuterXml(XmlNode node)
		{
			if (node.ParentNode == null)
				return node.OuterXml;
			else
				return GetTopParentOuterXml(node.ParentNode);
		}
	}
}
