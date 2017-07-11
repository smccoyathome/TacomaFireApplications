using System;

namespace UpgradeHelpers.Helpers
{
	public class Visual : DependencyObject
    {
        protected void AddVisualChild(Visual child) { throw new NotImplementedException(); }

        protected virtual int VisualChildrenCount { get { throw new NotSupportedException(); } }
    }
}
