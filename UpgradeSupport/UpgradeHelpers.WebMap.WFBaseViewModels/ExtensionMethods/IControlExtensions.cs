using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Extensions
{
	public static class IControlExtensions
	{
		/*********************************************************************Auxiliary****************************************/
		public static Object GetPropertyValue(object obj, string property)
		{
			return obj.GetType().GetProperty(property) != null ? obj.GetType().GetProperty(property).GetValue(obj, null) ?? null : null;
		}
		public static void SetPropertyValue(object obj, string property, object value)
		{
			PropertyInfo prop = obj.GetType().GetProperty(property);
			if (null != prop && prop.CanWrite)
				prop.SetValue(obj, value, null);
		}

		/***********************************************************************************************************************/

		//Top
		public static int GetTop(this IStateObject icontrol)
		{
			return (int)(GetPropertyValue(icontrol, "Top") ?? default(int));
		}
		public static int SetTop(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Top", value);
			return icontrol.GetTop();
		}

		//Bottom
		public static int GetBottom(this IControl icontrol)
		{
			return (int)GetPropertyValue(icontrol, "Bottom");
		}

		public static int SetBottom(this IControl icontrol, int value)
		{
			//SetPropertyValue(icontrol, "Bottom", value); //,MOBILIZE,11/01/2016,TODO,CMS,"MANUALLY CHANGED","Property 'Bottom' has no setter." 
			return icontrol.GetBottom();
		}

		//Right
		public static int GetRight(this IControl icontrol)
		{
			var x = GetPropertyValue(icontrol, "Right");
			return (x != null) ? (int)x : 0;
		}

		public static int SetRight(this IControl icontrol, int value)
		{
			SetPropertyValue(icontrol, "Right", value);
			return icontrol.GetRight();
		}

		//Left
		public static int GetLeft(this IStateObject icontrol)
		{
			return (int)(GetPropertyValue(icontrol, "Left") ?? default(int));
		}
		public static int SetLeft(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Left", value);
			return icontrol.GetLeft();
		}

		//Height
		public static int GetHeight(this object icontrol)
		{
			var wrappedModel = icontrol as ILogicView<IViewModel>;

			if (wrappedModel != null)
			{
				return (int)(GetPropertyValue(wrappedModel.ViewModel, "Height") ?? default(int));
			}

			return (int)(GetPropertyValue(icontrol, "Height") ?? default(int));

		}
		public static int SetHeight(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Height", value);
			return icontrol.GetHeight();
		}

		//Width
		public static int GetWidth(this object icontrol)
		{
			var wrappedModel = icontrol as ILogicView<IViewModel>;

			if (wrappedModel != null)
			{
				return (int)(GetPropertyValue(wrappedModel.ViewModel, "Width") ?? default(int));
			}

			return (int)(GetPropertyValue(icontrol, "Width") ?? default(int));
		}
		public static int SetWidth(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Width", value);
			return icontrol.GetWidth();
		}

		//Location
		public static Point GetLocation(this IControl icontrol)
		{
			return (Point)GetPropertyValue(icontrol, "Location");
		}
		public static Point SetLocation(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Location", value);
			return icontrol.GetLocation();
		}

		//Focused
		public static bool GetFocused(this IStateObject icontrol)
		{
			return (bool)(GetPropertyValue(icontrol, "Focused") ?? default(bool));
		}
		public static bool SetFocused(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Focused", value);
			return icontrol.GetFocused();
		}
		//Bounds
		public static Rectangle GetBounds(this IControl icontrol)
		{
			return (Rectangle)GetPropertyValue(icontrol, "Bounds");
		}
		public static Rectangle SetBounds(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Bounds", value);
			return icontrol.GetBounds();
		}

		//Text 
		public static string GetText(this IStateObject icontrol)
		{
			return (string)GetPropertyValue(icontrol, "Text");
		}
		public static string SetText(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Text", value);
			return icontrol.GetText();
		}

		//ClientSize
		public static Size GetClientSize(this IControl icontrol)
		{
			return (Size)GetPropertyValue(icontrol, "ClientSize");
		}

		public static Size SetClientSize(this IControl icontrol, Size value)
		{
			SetPropertyValue(icontrol, "ClientSize", value);
			return icontrol.GetClientSize();
		}

		//Size
		public static Size GetSize(this IControl icontrol)
		{
			return (Size)GetPropertyValue(icontrol, "Size");
		}
		public static Size SetSize(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Size", value);
			return icontrol.GetSize();
		}
		//

		//Disposing
		public static bool GetDisposing(this IControl icontrol)
		{
			return false;// (bool)GetPropertyValue(icontrol, "Disposing");
		}
		public static bool SetDisposing(this IControl icontrol, object value)
		{
			//SetPropertyValue(icontrol, "Disposing", value);
			return false;// icontrol.GetDisposing();
		}

		//IsDisposed
		public static bool GetIsDisposed(this IStateObject icontrol)
		{
			return false; //(bool)GetPropertyValue(icontrol, "Disposing");
		}
		public static bool SetIsDisposed(this IControl icontrol, object value)
		{
			// SetPropertyValue(icontrol, "Disposing", value);
			return false;// icontrol.GetIsDisposed();
		}


		//MaximumSize
		public static Size GetMaximumSize(this IControl icontrol)
		{
			return (Size)GetPropertyValue(icontrol, "MaximumSize");
		}
		public static Size SetMaximumSize(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "MaximumSize", value);
			return icontrol.GetMaximumSize();
		}
		//MinimumSize
		public static Size GetMinimumSize(this IControl icontrol)
		{
			return (Size)GetPropertyValue(icontrol, "MinimumSize");
		}
		public static Size SetMinimumSize(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "MinimumSize", value);
			return icontrol.GetMinimumSize();
		}

		//PreferredSize
		public static Size GetPreferredSize(this IControl icontrol)
		{
			if (
				(icontrol != null) && (icontrol.GetType() != null) && (icontrol.GetType().Name.Contains("Label"))
				)
			{
				return new Size(43, 17);
			}
			return (Size)GetPropertyValue(icontrol, "PreferredSize");
		}
		public static Size SetPreferredSize(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "PreferredSize", value);
			return icontrol.GetPreferredSize();
		}

		//Margin
		public static Padding GetMargin(this IControl icontrol)
		{
			//MOBILIZE,7/4/2016,TODO,mvega,MANUALLY CHANGED, if null return a Default Padding
			return (Padding)GetPropertyValue(icontrol, "Margin") ?? new Padding(0);
		}
		public static Padding SetMargin(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Margin", value);
			return icontrol.GetMargin();
		}

		//DataBindings
		public static BindingsCollection GetDataBindings(this IControl icontrol)
		{
			return (BindingsCollection)GetPropertyValue(icontrol, "DataBindings");
		}
		public static BindingsCollection SetDataBindings(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "DataBindings", value);
			return icontrol.GetDataBindings();
		}

		//Region
		public static Region GetRegion(this IControl icontrol)
		{
			return (Region)GetPropertyValue(icontrol, "Region");
		}
		public static Region SetRegion(this IControl icontrol, Region value)
		{
			SetPropertyValue(icontrol, "Region", value);
			return icontrol.GetRegion();
		}

		//CreateGraphics()
		public static Graphics CreateGraphics(this IControl icontrol)
		{
			throw (new NotImplementedException());
		}

		//PointToScreen(Point point)
		public static object PointToScreen(this IControl icontrol, Point point)
		{
			throw (new NotImplementedException());
		}
		//PointToClient(object p)
		public static Point PointToClient(this IControl icontrol, object p)
		{
			throw (new NotImplementedException());
		}
		//InvokeRequired
		public static bool GetInvokeRequired(this IStateObject icontrol)
		{
			return (bool)(GetPropertyValue(icontrol, "InvokeRequired") ?? default(bool));
		}
		public static bool SetInvokeRequired(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "InvokeRequired", value);
			return icontrol.GetInvokeRequired();
		}

		//Invoke(Delegate method, params object[] args)
		public static object Invoke(this IControl icontrol, Delegate method, params object[] args)
		{
			throw (new NotImplementedException());
		}

		//Parent
		public static UpgradeHelpers.Helpers.ControlViewModel GetParent(this IControl icontrol) //IControl
		{
			var control = icontrol as IInteractsWithView;
			if (control != null)
			{
				var parent = control.ViewManager.GetControlAncestor(icontrol);
				if (parent != null)
					return parent as ControlViewModel;
			}

			var reflectedParent = (ControlViewModel)GetPropertyValue(icontrol, "Parent");
			return reflectedParent;
		}

        /// <summary>
        /// This method has been created to add  specif exceptions of types that are not containers. In the viewManager is not possible to get the control types.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static IControl GetControlAncestor(this IViewManager vm, IControl ctrl)
        {
            var ancestor = vm.GetParent(ctrl as IStateObject);
            return ancestor as IControl;
        }

        public static IControl SetParent(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Parent", value);
			return icontrol.GetParent();
		}

		// Select()
		public static void Select(this IControl icontrol)
		{
			throw (new NotImplementedException());
		}

		public static void Select(this IControl icontrol, int s, int l)
		{
			throw (new NotImplementedException());
		}

		//TextChanged
		public static EventHandler GetTextChanged(this IControl icontrol)
		{
			return (EventHandler)GetPropertyValue(icontrol, "TextChanged");
		}
		public static EventHandler SetTextChanged(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "TextChanged", value);
			return icontrol.GetTextChanged();
		}


		//Set_Location(Point point)
		public static void Set_Location(this IControl icontrol, Point point)
		{
			throw (new NotImplementedException());
		}
		//TabStop
		public static bool GetTabStop(this IControl icontrol)
		{
			return (bool)GetPropertyValue(icontrol, "TabStop");
		}
		public static bool SetTabStop(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "TabStop", value);
			return icontrol.GetTabStop();
		}

		//Controls
		//public static IList<Control> GetControls(this IControl icontrol)
		//{
		//    return (IList<Control>)GetPropertyValue(icontrol, "Controls");
		//}
		//public static IList<Control> SetControls(this IControl icontrol, object value)
		//{
		//    SetPropertyValue(icontrol, "Controls", value);
		//    return icontrol.GetControls();
		//}

		//GetNextControl(IControl startCtrl, bool p)
		public static IControl GetNextControl(this IControl icontrol, IControl startCtrl, bool p)
		{
			throw (new NotImplementedException());
		}

		//SuspendLayout()
		public static void SuspendLayout(this IControl icontrol)
		{
			throw (new NotImplementedException());
		}

		//ResumeLayout(bool p)
		public static void ResumeLayout(this IControl icontrol, bool b = false)
		{
			throw (new NotImplementedException());
		}

		//BeginUpdate()
		public static void BeginUpdate(this IControl icontrol)
		{
			//throw (new NotImplementedException());
		}

		//EndUpdate()
		public static void EndUpdate(this IControl icontrol)
		{
			//throw (new NotImplementedException());
		}

		//EndUpdate(bool p)
		public static void EndUpdate(this IControl icontrol, bool p)
		{
		}

		//Site
		public static ISite GetSite(this IControl icontrol)
		{
			return (ISite)GetPropertyValue(icontrol, "Site");
		}
		public static ISite SetSite(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "Site", value);
			return icontrol.GetSite();
		}

		//CheckForIllegalCrossThreadCalls
		public static bool GetCheckForIllegalCrossThreadCalls(this IControl icontrol)
		{
			return (bool)GetPropertyValue(icontrol, "CheckForIllegalCrossThreadCalls");
		}
		public static bool SetCheckForIllegalCrossThreadCalls(this IControl icontrol, object value)
		{
			SetPropertyValue(icontrol, "CheckForIllegalCrossThreadCalls", value);
			return icontrol.GetCheckForIllegalCrossThreadCalls();
		}

		//GetChildAtPoint(Point point, GetChildAtPointSkip skip)
		public static IControl GetChildAtPoint(this IControl icontrol, Point point, GetChildAtPointSkip skip)
		{
			throw (new NotImplementedException());
		}

		//Click
		public static EventHandler GetClick(this IControl icontrol)
		{
			return (EventHandler)GetPropertyValue(icontrol, "Click");
		}
		public static EventHandler SetClick(this IControl icontrol, EventHandler value)
		{
			SetPropertyValue(icontrol, "Click", value);
			return icontrol.GetClick();
		}

		//ContextMenu
		//     public static ContextMenu GetContextMenu(this IControl icontrol)
		//     {
		//         return (ContextMenu)GetPropertyValue(icontrol, "ContextMenu");
		//     }
		//     public static ContextMenu SetContextMenu(this IControl icontrol, object value)
		//     {
		//         SetPropertyValue(icontrol, "ContextMenu", value);
		//return icontrol.GetContextMenu();
		//     }

		//RectangleToScreen
		public static Rectangle RectangleToScreen(this IControl icontrol, Rectangle rc)
		{
			throw (new NotImplementedException());
		}

		//Invalidate(Rectangle rc, bool p);
		public static void Invalidate(this IControl icontrol, Rectangle rc = null, bool p = false)
		{
			throw (new NotImplementedException());
		}

		//Invalidate(region rc, bool p);
		public static void Invalidate(this IControl icontrol, Region r, bool p)
		{
			throw (new NotImplementedException());
		}

		//CreateControl();
		public static void CreateControl(this IControl icontrol)
		{
		}

		//Dispose();
		public static void Dispose(this IControl icontrol)
		{
			throw (new NotImplementedException());
		}


		//SetStyle(ControlStyles flag, bool value)
		public static void SetStyle(this IControl icontrol, ControlStyles flag, bool value)
		{
			throw (new NotImplementedException());
		}

		//DoDragDrop(DragItemData dragItemData, DragDropEffects dragDropEffects)
		public static DragDropEffects DoDragDrop(IControl icontrol, DragDropEffects dragDropEffects)
		{
			throw new NotImplementedException();
		}

		public static DragDropEffects DoDragDrop(IControl icontrol, object data, DragDropEffects dragDropEffects)
		{
			throw new NotImplementedException();
		}

		public static UpgradeHelpers.Interfaces.IViewModel FindForm(this IControl icontrol)
		{
			ControlViewModel control = icontrol as ControlViewModel;
			while (control != null && !(control is UpgradeHelpers.Interfaces.IViewModel))
			{
				control = control.ParentInternal;
			}
			return (UpgradeHelpers.Interfaces.IViewModel)control;
		}

		//OnDragDrop(DragEventArgs drgevent)
		public static void OnDragDrop(IControl icontrol, DragEventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		////OnDragEnter(DragEventArgs drgevent)
		public static void OnDragEnter(IControl icontrol, DragEventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		////OnDragLeave(DragEventArgs drgevent)
		public static void OnDragLeave(IControl icontrol, DragEventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		public static void OnMouseDown(this IControl icontrol, UpgradeHelpers.Events.MouseEventArgs e)
		{
			throw (new NotImplementedException());
		}

		public static void RegionChanged(IControl icontrol, EventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		public static void OnLostFocus(IControl icontrol, EventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		#region From Control.cs of UpgradeStubs, review and clean as needed

		public static System.IntPtr Get_Handle(this IStateObject instance)
		{
			return default(System.IntPtr);
		}
		public static void Call_Refresh(this IControl instance)
		{

		}

		public static void SetCursor(this IControl instance, Cursor argName)
		{
		}

		public static System.IntPtr GetHandle(this IControl instance)
		{
			return default(System.IntPtr);
		}

		//public static Cursor GetCursor(this IControl instance)
		//{
		//    return default(Cursor);
		//}

		public static void CallRefresh(this IControl instance)
		{

		}

		public static IControl Get_TopLevelControl(this IControl instance)
		{
			return default(IControl);
		}

		#endregion

		public static void OnMouseDown(IControl icontrol, EventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		public static void OnMouseMove(IControl icontrol, EventArgs drgevent)
		{
			throw new NotImplementedException();
		}

		public static void OnMouseUP(IControl icontrol, EventArgs drgevent)
		{
			throw new NotImplementedException();
		}


		//OnMouseUP(QueryContinueDragEventArgs qcdevent)
		public static void OnQueryContinueDrag(IControl icontrol, QueryContinueDragEventArgs qcdevent)
		{
			throw new NotImplementedException();
		}

		//OnSystemColorsChanged(EventArgs e);
		public static void OnSystemColorsChanged(IControl icontrol, EventArgs e)
		{
			throw new NotImplementedException();
		}

		//OnValidating(CancelEventArgs e);
		public static void OnValidating(IControl icontrol, CancelEventArgs e)
		{
			//throw new NotImplementedException();
		}


		//Point PointToClient(object p);
		public static Point PointToClient(Point p) //void
		{
			throw new NotImplementedException();
		}

		public static void WndProc(object p)
		{
			throw new NotImplementedException();
		}

		public static Rectangle Get_ClientRectangle(this IStateObject instance)
		{
			return new Rectangle();
		}

		public static Rectangle GetClientRectangle(this IControl instance)
		{
			return new Rectangle();
		}

		public static void SetCursor(this IViewModel instance, Cursor cursor)
		{
		}

		public static void SendToBack(this IControl ic)
		{
			//throw new NotImplementedException();
			/* MOBILIZE,04/08/2016,TODO,ISU,"Manually changed", "SendToBack must be defined. Temporarily the control is hiding"*/
			ic.Visible = false;
		}

		public static void Set_ClientSize(this IControl icontrol, object value)
		{
			throw new NotImplementedException();
		}

	}

}
