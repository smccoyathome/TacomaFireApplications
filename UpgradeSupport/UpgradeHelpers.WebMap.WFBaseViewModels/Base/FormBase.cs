using System;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{

	public class FormBase<T> : ComponentBaseViewModel, UpgradeHelpers.Interfaces.ILogicView<T>, ILifeCycle, IInitializable where T : FormBaseViewModel
	{

		public T ViewModel { get; set; }

		public IViewManager ViewManager { get; set; }

		public IIocContainer Container { get; set; }

		/// <summary>
		/// Handles the startup events execution for a form.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="parent"></param>
		public virtual void LifeCycleStartup(IControlWithState parent = null)
		{
			if (this.ViewModel.Loaded)
			{
				//If the from is already loaded the activated event is the only one that is called.
				CallActivated();
				return;
			}
			this.ViewModel.Loaded = true;

			//The Events chain is executed for a form startup
			CallHandleCreatedEvents();
			CallBindingContextChangedEvents();
			CallLoadEvents();
			CallVisibleChangedEvents();
			CallActivated();
		}

		/// <summary>
		/// Executes the visible changed events.
		/// </summary>
		private void CallVisibleChangedEvents()
		{
			//Handles Visible Changed Event
			this.OnVisibleChanged(EventArgs.Empty);
			this.ExecuteVisibleChangedHandlers();
		}

		/// <summary>
		/// Executes the load events.
		/// </summary>
		private void CallLoadEvents()
		{
			//Handles the Load event
			this.ExecuteControlsStartup();
			this.DynamicControlsStartup();
			this.OnLoad(EventArgs.Empty);
			this.ExecuteLoadHandlers();
		}

		/// <summary>
		/// Executes the binding context changed events.
		/// </summary>
		private void CallBindingContextChangedEvents()
		{
			//Handles Binding ContextChanged Event
			this.OnBindingContextChanged(EventArgs.Empty);
			this.ExecuteBindingContextChangedHandlers();
		}

		/// <summary>
		/// Executes the handle created events.
		/// </summary>
		private void CallHandleCreatedEvents()
		{
			//Handles HandleCreated Event
			if (!ViewModel.IsHandleCreated)
			{
				ViewModel.IsHandleCreated = true;
				this.OnHandleCreated(EventArgs.Empty);
				this.ExecuteHandleCreatedHandlers();
			}
		}

		/// <summary>
		/// Executes the activated.
		/// </summary>
		private void CallActivated()
		{
			//Handles Activated Event. The activated is triggered 
			this.OnActivated(EventArgs.Empty);
			this.ExecuteActivatedHandlers();
		}

		/// <summary>
		/// Handles the shutdown events execution for a control.
		/// </summary>
		/// <returns>Returns whether or not the form was fully closed. The form closing can be canceled.</returns>
		public virtual bool ExecuteLifeCycleShutdown()
		{
			var cancelled = CallFormClosingEvents();

			if (cancelled)
				//The close execution was canceled by flagging the cancel property.
				return false;

			CallFormCloseEvents();
			return true;
		}

		/// <summary>
		/// Executes the form closing events.
		/// </summary>
		/// <returns>If the closing of the form was canceled</returns>
		private bool CallFormClosingEvents()
		{
			//Executes OnClosing
			var closingEventArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);

			this.OnClosing((CancelEventArgs)closingEventArgs);
			//Execute FormClosing event
			this.ExecuteClosingHandlers(closingEventArgs);

			OnFormClosing(closingEventArgs);
			//Execute FormClosing event
			this.ExecuteFormClosingHandlers(closingEventArgs);

			return closingEventArgs.Cancel;
		}

		/// <summary>
		/// Executes the form close events.
		/// </summary>
		private void CallFormCloseEvents()
		{
			//Executes OnClose
			this.OnClosed(EventArgs.Empty);
			//Executes FormClosed event
			this.ExecuteClosedHandlers(EventArgs.Empty);

			var formClosedArgs = new FormClosedEventArgs() { CloseReason = CloseReason.UserClosing };
			//Executes OnFormClosed
			this.OnFormClosed(formClosedArgs);
			//Executes FormClosed event
			this.ExecuteFormClosedHandlers(formClosedArgs);
			//the form was completely closed.
		}

		public override void Refresh()
		{
			ViewManager.Events.Publish("PAINT", this.ViewModel as IStateObject, new object[] { this.ViewModel, null });

			var iterator = this.ViewModel as IControlContainerIterator;
			if (iterator == null) return;
			foreach (ControlViewModel childControl in iterator.GetControlsIterator())
			{
				if (childControl != null)
				{
					childControl.Refresh();
				}
			}

		}

		public override void Dispose()
		{
			//Dispose inner controls
			this.ExecuteControlsShutdown();
			this.DynamicControlsShutdown(ViewModel.Controls);

			base.Dispose();
		}
		protected override void Dispose(bool disposing)
		{
			if (!disposing) return;
		}

		/// <summary>
		/// Triggers the life cycle startup events for the controls contained in the Controls List.
		/// </summary>
		protected virtual void DynamicControlsStartup()
		{
			if (ViewModel.Controls == null) return;
			foreach (var control in ViewModel.Controls)
			{
				var wrappedControl = control as ILifeCycle;
				if (wrappedControl != null)
				{
					//Loads the dynamic controls
					wrappedControl.LifeCycleStartup(this.ViewModel);
				}
			}
		}

		public IDisposable components;

		#region Virtual Methods
		protected virtual bool ProcessTabKey(bool forward) { return false; }

		void IInitializable.Init()
		{
			//When the automation of the GetControlIterators is done, 
			//this condition should be removed.
			if (this.ViewModel is UpgradeHelpers.Interfaces.IControlContainerIterator)
				this.ViewModel.Visible = false;
		}
		#endregion

		public virtual Color BackColor { get; set; }
	}
}
