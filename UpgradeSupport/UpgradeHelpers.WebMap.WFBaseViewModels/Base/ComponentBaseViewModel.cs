using System;
using System.Collections.Generic;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	public class ComponentBaseViewModel
	{
		//The following method definitions are used to manage the life cycle events,
		//each control should override them with its specific logic.

		#region Miscelaneos
		/// <summary>
		/// Raises the LocationChangedeEnd event.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnLocationChanged(System.EventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		/// Raises the OnResizeEnd event.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnResizeEnd(System.EventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}
		#endregion

		#region Startup Events

		/// <summary>
		/// Raises the Load event.
		/// </summary>
		/// <param name="evArgs">An EventArgs that contains the event data.</param>
		protected virtual void OnLoad(EventArgs evArgs) { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered load handlers.
		/// </summary>
		protected virtual void ExecuteLoadHandlers() { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Invokes the LifeCycleStartup for its static controls.
		/// </summary>
		protected virtual void ExecuteControlsStartup() { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		///  Raises the Visible Changed event.
		/// </summary>
		/// <param name="evArgs">An EventArgs that contains the event data.</param>
		protected virtual void OnVisibleChanged(EventArgs evArgs) { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Visible Changed handlers.
		/// </summary>
		protected virtual void ExecuteVisibleChangedHandlers() { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		///  Raises the Handle Created event.
		/// </summary>
		protected virtual void OnHandleCreated(System.EventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Handle Created handlers.
		/// </summary>
		protected virtual void ExecuteHandleCreatedHandlers() { /*This method is a placeholder, override it to add the desire functionality*/ }

		/// <summary>
		///  Raises the Binding Context Changed event.
		/// </summary>
		protected virtual void OnBindingContextChanged(System.EventArgs e) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Binding Context Changed handlers.
		/// </summary>
		protected virtual void ExecuteBindingContextChangedHandlers() {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		///  Raises the Activated event.
		/// </summary>
		protected virtual void OnActivated(System.EventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Activated handlers.
		/// </summary>
		protected virtual void ExecuteActivatedHandlers() { /*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		///  Raises the Control Added event.
		/// </summary>
		protected virtual void OnControlAdded(ControlEventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		/// Execute the registered Control Added handlers.
		/// </summary>
		protected virtual void ExecuteControlAddedHandlers() { /*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		///  Raises the Control Removed event.
		/// </summary>
		protected virtual void OnControlRemoved(ControlEventArgs e) { /*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		/// Execute the registered Control Removed handlers.
		/// </summary>
		protected virtual void ExecuteControlRemovedHandlers() { /*This method is a placeholder, override it to add the desire functionality*/}

		public virtual void Refresh() { }

		/// <summary>
		/// Triggers the AddControl event chain.
		/// </summary>
		/// <param name="control">The instance of the newly added control</param>
		internal void HandleAddControlEvents(ControlViewModel control)
		{
			this.OnControlAdded(new ControlEventArgs(control));
			ExecuteControlAddedHandlers();
		}
		/// <summary>
		/// Triggers the RemoveControl event chain.
		/// </summary>
		/// <param name="control">The instance of the removed control</param>
		internal void HandleRemoveControlEvents(ControlViewModel control)
		{
			//1. We execute the binding context changed event
			this.OnBindingContextChanged(new System.EventArgs());
			this.ExecuteBindingContextChangedHandlers();

			//2. We execute the control Removed events
			this.OnControlRemoved(new ControlEventArgs(control));
			ExecuteControlRemovedHandlers();
		}

		#endregion

		#region Shutdown Events

		/// <summary>
		///  Raises the Closing event.
		/// </summary>
		protected virtual void OnClosing(CancelEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Closing handlers.
		/// </summary>
		protected virtual void ExecuteClosingHandlers(CancelEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Form Closing handlers.
		/// </summary>
		protected virtual void ExecuteFormClosingHandlers(FormClosingEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		///  Raises the FormClosing event.
		/// </summary>
		protected virtual void OnFormClosing(FormClosingEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}
		/// <summary>
		///  Raises the Closed event.
		/// </summary>
		protected virtual void OnClosed(System.EventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Form Closed handlers.
		/// </summary>
		protected virtual void ExecuteFormClosedHandlers(FormClosedEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		///  Raises the FormClosed event.
		/// </summary>
		protected virtual void OnFormClosed(FormClosedEventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Execute the registered Form Closed handlers.
		/// </summary>
		protected virtual void ExecuteClosedHandlers(EventArgs eventArgs) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Releases the unmanaged resources used by the Component and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">Type: System.Boolean true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing) {/*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Invokes the LifeCycleShutdown for its static controls.
		/// </summary>
		protected virtual void ExecuteControlsShutdown() { /*This method is a placeholder, override it to add the desire functionality*/}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public virtual void Dispose()
		{
			this.Dispose(true);
		}



		/// <summary>
		/// Triggers the life cycle shutdown events for the controls contained in the Controls List.
		/// </summary>
		protected virtual void DynamicControlsShutdown(IList<ControlViewModel> controls)
		{
			if (controls == null) return;
			foreach (var control in controls)
			{
				var wrappedControl = control as ILifeCycle;
				if (wrappedControl != null)
				{
					//Destroys the dynamic controls
					wrappedControl.ExecuteLifeCycleShutdown();
				}
			}
		}

		#endregion

		#region virtual methods

		protected virtual void OnInvalidated(EventArgs e) { }
		protected virtual void OnValidated(EventArgs e) { }
		protected virtual void OnValidating(CancelEventArgs e) { }
		protected virtual void OnLostFocus(EventArgs e) { }
		protected virtual void OnMouseClick(UpgradeHelpers.Events.MouseEventArgs e) { }
		protected virtual void OnMouseEnter(UpgradeHelpers.Events.MouseEventArgs e) { }
		protected virtual void OnMouseDown(UpgradeHelpers.Events.MouseEventArgs e) { }
		protected virtual void OnMouseLeave(UpgradeHelpers.Events.MouseEventArgs e) { }
		protected virtual void OnPaint(EventArgs e) { }
		protected virtual bool ProcessCmdKey(ref Message msg, Keys keyData) { return false; }
		protected virtual bool ProcessDialogChar(char charCode) { return false; }
		protected virtual bool ProcessDialogKey(Keys keyData) { return false; }
		protected virtual void OnKeyDown(UpgradeHelpers.Events.KeyPressEventArgs e) { }
		protected virtual void OnKeyPress(UpgradeHelpers.Events.KeyPressEventArgs e) { }
		protected virtual void OnPreviewKeyDown(UpgradeHelpers.Events.PreviewKeyDownEventArgs e) { }
		protected virtual void OnKeyUp(KeyEventArgs e) { }
		protected virtual void OnDragDrop(DragEventArgs drgevent) { }
		protected virtual void OnDragEnter(DragEventArgs drgevent) { }
		protected virtual void OnDragLeave(EventArgs e) { }
		protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent) { }
		#endregion
	}
}
