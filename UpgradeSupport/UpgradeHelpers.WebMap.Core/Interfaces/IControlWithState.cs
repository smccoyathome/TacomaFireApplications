using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Interfaces
{
	public interface IControlWithState : IControl
	{
		/// <summary>
		/// This is a flag enum that indicates whether a control is Enabled, Loaded, HandleCreated, Disposed
		/// </summary>
		Helpers.ControlState State { get; set; }

		/// <summary>
		/// This is a flag enum that indicates whether a I am Visible or My Parent is visible
		/// </summary>
		Helpers.VisibleState VisibleState { get; set; }

		/// <summary>
		/// Indicates if I am loaded or not
		/// </summary>
		bool Loaded { get; set; }
		/// <summary>
		/// Notifies the visibility of the current node
		/// by breath first search algorithm to all the children from the current node.
		/// </summary>
		void NotifyParentVisibility(object node, bool isVisible);
	}
}

