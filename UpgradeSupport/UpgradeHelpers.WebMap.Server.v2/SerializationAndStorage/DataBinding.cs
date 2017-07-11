using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{


		public class DataBinding
		{
			internal string _objReferenceUID;
			private IStateObject _objReference;

			internal IStateObject ObjReference
			{
				get
				{
					if (_objReference == null && _objReferenceUID != null)
					{
						_objReference = StateManager.Current.GetObject(_objReferenceUID) as IStateObject;
					}
					return _objReference;
				}
				set
				{
					_objReference = value;
					if (_objReference != null)
					{
						_objReferenceUID = _objReference.UniqueID;
					}
					else
					{
						_objReferenceUID = null;
					}
				}
			}

			internal string ObjProperty;
			internal IStateObject DataSourceReference;

		/// <summary>
		/// Sets the data source reference. 
		/// If is not an IStateObject tries with a surrogate
		/// </summary>
		/// <param name="value">The value.</param>
		internal void SetDataSourceReference(object value)
			{
				var iStateValue = value as IStateObject;
				if (iStateValue != null)
					DataSourceReference = iStateValue;
				else
					DataSourceReference = StateManager.Current.surrogateManager.GetSurrogateFor(value, false);
			}

			internal string DataSourceProperty;
			internal string NextBinding { get; set; }
			internal string PreviousBinding { get; set; }

			internal string ReferencedUniqueID
			{
				get { return _objReferenceUID; }
				set { _objReferenceUID = value; }
			}
		}
}