using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Extensions
{
	public static class ControlCollectionExtensions
	{
		/// <summary>
		/// Controls Collection AddControlMethod
		///  Method required to add a Control to a View or UserControl in order to 
		///  execute proper logic. e.g Load methods.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controls">The Controls collection</param>
		/// <param name="control">The control being added to the Controls collection</param>
		public static void AddControl<T, TP>(this IList<T> controls, T control, TP parent)
			where T : ControlViewModel
			where TP : IStateObject
		{
			if (control == null)
				return;

			var wrappedControl = control as ControlViewModel;
			var wrappedParent = parent as ControlViewModel;
			var validParent = false;


			if (controls == null)
			{
				controls = StaticContainer.Instance.Resolve<IList<T>>();
			}
			//If the Control is already there, we should not insert it in the list.
			if (controls.Contains(control))
				return;

			controls.Add(control);

			//  If the collection is attached, the TopLevelObject is a View and that View is loaded
			//then we should call Load method for the control...If exists
			if (parent != null)
			{
				//Sets the control parent
				if (wrappedControl != null && wrappedParent != null)
				{
					wrappedControl._parent = wrappedParent;
					validParent = true;
					if (control != null)
					{
						if (wrappedParent.Visible)
							(control as IControlWithState).VisibleState |= VisibleState.ParentVisible;
						else
							(control as IControlWithState).VisibleState &= ~VisibleState.ParentVisible;
						(control as IControlWithState).NotifyParentVisibility(control, wrappedParent.Visible);
					}
				}
			}

			//The LifeCycle logic is executed for the current control
			var iloadableObj = control as ILifeCycle;
			if (iloadableObj != null)
				iloadableObj.LifeCycleStartup(parent as IControlWithState);

			//Control added event is triggered
			if (validParent)
			{
				wrappedParent.HandleAddControlEvents(wrappedControl);
			}
		}

		public static void RemoveControl<T>(this IList<T> controls, T control)
			where T : IControl
		{
			var wrappedControl = control as ControlViewModel;
			if (wrappedControl != null)
			{
				var parent = wrappedControl.Parent;
				if (parent != null)
				{
					wrappedControl.Controls.Remove(wrappedControl);
					wrappedControl._parent = null;
					parent.HandleRemoveControlEvents(wrappedControl);
				}

			}
		}

		public static System.Collections.Generic.IEnumerable<ControlViewModel> GetControlsIterator<T>(this T control) where T : IControlsContainer
		{
			//Lets retrieve the current instance of ViewManager
			var ViewManager = StaticContainer.Instance.Resolve<IViewManager>();
			var controlIStateObj = control as IStateObject;
			var parentObj = controlIStateObj;
			while (parentObj != null && !(parentObj is IControlContainerIterator))
				parentObj = ViewManager.GetParent(parentObj);

			IControlContainerIterator iterator = null;
			if (parentObj != null)
				iterator = parentObj as IControlContainerIterator;

			if (iterator == null)
				return (controlIStateObj as IControlsContainer).GetControlsSafe();

			// If the Control is the one with the iterator...then it means
			//that we should send null in order to retrieve the root elements.
			if (controlIStateObj == iterator)
				return iterator.GetControlsIterator(null);

			return iterator.GetControlsIterator(controlIStateObj);
		}

		public static System.Collections.Generic.IEnumerable<ControlViewModel> GetControlsSafe(this IControlsContainer control)
		{

			if (control.Controls != null)
				return control.Controls;
			else
				return Enumerable.Empty<ControlViewModel>();

		}

		public static void LifeCycleShutdown(this ILifeCycle instance)
		{
			if (instance != null)
			{
				instance.ExecuteLifeCycleShutdown();
			}
		}

		/// <summary>
		/// Returns Parent control or Form ViewModel
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		public static IStateObject GetParentFromControl(this IStateObject control)
		{
			var ViewManager = StaticContainer.Instance.Resolve<IViewManager>();

			return ViewManager.GetParent(control);
		}
		/// <summary>
		/// Returns the visual parent. The visual parent is that contains the control in its list of controls
		/// </summary>
		/// <param name="control">The control to be searched</param>
		/// <returns></returns>
		public static IStateObject GetVisualParent(this IStateObject control)
		{
			var Parent = control.GetParentFromControl();
			if (Parent == null || !(control is ControlViewModel)) return null;
			IStateObject value = null;
			var VisualParentDictionary = StaticContainer.Instance.Resolve<IViewManager>().GetVisualParentDictionary();
			VisualParentDictionary.TryGetValue(control.UniqueID, out value);
			if (value != null) return value;
			IStateObject visualParent = null;
			if (Parent is IControlsContainer)
			{
				visualParent = FindVisualParent((IControlsContainer)Parent, (ControlViewModel)control, VisualParentDictionary);
			}
			return visualParent == null ? Parent : visualParent;
		}
		/// <summary>
		/// Recursive method to iterate in the controls obtained from the GetControlsIterator
		/// </summary>
		/// <param name="parent">The actual control in the search</param>
		/// <param name="control">The control to be searched</param>
		/// <param name="VisualParentDictionary">Stores the controls and their parent found previously</param>
		/// <returns></returns>
		public static IStateObject FindVisualParent(IControlsContainer parent, ControlViewModel control, Dictionary<string, IStateObject> VisualParentDictionary)
		{
			if (parent == null)
			{
				return null; // GetControlsIterator can return null controls
			}
			var Controls = parent.GetControlsIterator();
			IStateObject VisualParent = null;
			for (var i = 0; i < Controls.Count(); i++)
			{
				var ctl = Controls.ElementAt(i);
				if (ctl == control)
				{
					if (!VisualParentDictionary.ContainsKey(control.UniqueID)) VisualParentDictionary.Add(control.UniqueID, parent);
					return parent as IStateObject;
				}
				else
				{
					VisualParent = FindVisualParent(ctl, control, VisualParentDictionary);
					if (VisualParent != null)
					{
						return VisualParent;
					}
				}
			}
			return VisualParent;
		}
	}
}
