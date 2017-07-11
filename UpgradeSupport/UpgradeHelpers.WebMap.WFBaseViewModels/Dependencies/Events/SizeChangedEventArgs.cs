using System;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Events
{
	public class SizeChangedEventArgs : RoutedEventArgs
	{
		public bool HeightChanged { get; set; }
		public Size NewSize { get; set; }
		public Size PreviousSize { get; set; }
		public bool WidthChanged { get; set; }
		protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
		{
			throw new NotImplementedException();
		}
	}
}
