using System;

namespace UpgradeHelpers.Events
{
	public class ConvertEventArgs: EventArgs
    {
		#region Constructors

		public ConvertEventArgs(object value, System.Type desiredType){
		}
		
		#endregion

		#region Fields
		#endregion

		#region Events
		#endregion

		#region Properties
		public object Value{
			get{ return default(object);}
			set{}
		}
		
		public System.Type DesiredType{
			get{ return default(System.Type);}
			set{}
		}
		
		#endregion

		#region Methods
		#endregion
    }
}
