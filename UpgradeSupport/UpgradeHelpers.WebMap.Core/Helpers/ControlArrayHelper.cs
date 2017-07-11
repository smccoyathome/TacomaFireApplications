using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	public class ControlArrayHelper
	{
        private static IViewManager _viewManager;
        public static IViewManager ViewManager
        {
            get
            {
                if (_viewManager == null)
                {
                    _viewManager = StaticContainer.Instance.Resolve<IViewManager>();
                }
                return _viewManager;
            }
            set
            {
                _viewManager = value;
            }
        }

        /// <summary>
        /// This method returns the index of a given control contained in a list
        /// </summary>
        /// <param name="control">The given control</param>
        /// <returns>The controls index id is not a list element the return value will be -1</returns>
        public static int GetControlIndex(IStateObject control)
        {
            object parent;
            parent = ViewManager.GetParent(control);
            if (parent is System.Collections.IList)
            {
                return ((System.Collections.IList)parent).IndexOf(control);
            }
            else
            {
                return -1;
            }
        }
	}
}
