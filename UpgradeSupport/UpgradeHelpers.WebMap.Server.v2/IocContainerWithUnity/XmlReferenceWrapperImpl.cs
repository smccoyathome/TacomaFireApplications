using System;
using UpgradeHelpers.Interfaces;
using System.Xml.Schema;
using System.Xml;

namespace UpgradeHelpers.WebMap.Server
{


		[Serializable]
		public class XmlReferenceWrapperImpl : XmlReferenceWrapper, System.Runtime.Serialization.ISerializable
		{
			IStateObject _current;
			object parentCandidate;

			public XmlReferenceWrapperImpl() { 
            }

			public XmlReferenceWrapperImpl(IStateObject current) { 
                _current = current; 
            }

			protected XmlReferenceWrapperImpl(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
				: base(info, context)
			{

			}

			public XmlReferenceWrapperImpl(object parentCandidate, IStateObject obj)
			{
				this.parentCandidate = parentCandidate;
				this._current = obj;
			}

			public override object Value
			{
				get
				{
					return _current;
				}

				set
				{
					_current = value as IStateObject;
				}
			}

			public override XmlSchema GetSchema()
			{
				return null;
			}

			public override void ReadXml(XmlReader reader)
			{
				reader.MoveToContent();
				reader.ReadStartElement();
				var id = reader.ReadElementString("XmlElementWrapper");
				if (!string.IsNullOrWhiteSpace(id))
				{
					_current = StateManager.Current.GetObject(id);
				}
			}

			public override void WriteXml(XmlWriter writer)
			{
				if (_current != null)
				{
					ProcessIfOrphan();
					writer.WriteElementString("XmlElementWrapper", _current.UniqueID);
				}
				else
				{
					writer.WriteElementString("XmlElementWrapper", String.Empty);
				}
			}

			private void ProcessIfOrphan()
			{
				if (!StateManager.AllBranchesAttached(_current.UniqueID))
				{
					//If we enter here we are Orphans :(
					//We asumme we got here because we are inside a surrogate and
					//that means that there is an StateObjectSurrogate associated with the parentObject
					if (parentCandidate == null)
					{
						var typeName = TypeCacheUtils.GetOriginalTypeName(_current.GetType());
						throw new NotSupportedException("The wrapped stated of type " + typeName + "object with ID" + _current.UniqueID + " does not have a valid parent reference");
					}
					var parentSurrogate = StateManager.Current.surrogateManager.GetSurrogateFor(parentCandidate, generateIfNotFound: false);
					if (parentSurrogate == null)
					{
						var typeName = TypeCacheUtils.GetOriginalTypeName(_current.GetType());
						throw new NotSupportedException("The wrapped stated of type " + typeName + "object with ID" + _current.UniqueID + " does not have a valid parent SURROGATE reference");
					}
					AdoptionInformation.StaticAdopt(parentSurrogate, _current);
				}
			}

			protected override void InvokeDeserialization(System.Runtime.Serialization.SerializationInfo info)
			{
				string id = info.GetString("uid");
				if (!string.IsNullOrWhiteSpace(id))
				{
					_current = StateManager.Current.GetObject(id);
				}
			}

			public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			{
				if (_current != null)
				{
					ProcessIfOrphan();
					info.AddValue("uid", _current.UniqueID);
				}
				else
				{
					info.AddValue("uid", String.Empty);
				}

			}
		}
}