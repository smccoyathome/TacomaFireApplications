using System;

namespace UpgradeHelpers.Events
{
	public class FormClosedEventArgs : EventArgs
	{
		public CloseReason CloseReason { get; set; }
        public System.Boolean Cancel { get; set; }
	}
}