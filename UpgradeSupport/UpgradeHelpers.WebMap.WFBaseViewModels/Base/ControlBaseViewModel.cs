using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	public class ControlBaseViewModel : ComponentBaseViewModel, IControlWithState, ILifeCycle, IDependentViewModel, IControlsContainer, IInteractsWithView, ICreatesObjects
	{
		#region Control State Properties
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual ControlState State { get; set; }

		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual VisibleState VisibleState { get; set; }

		[StateManagement(StateManagementValues.ClientOnly)]
		public virtual bool Enabled
		{
			get
			{
				return this.State.HasFlag(ControlState.Enabled);
			}
			set
			{
				if (value)
					State |= ControlState.Enabled;
				else
					State &= ~ControlState.Enabled;

				if (ViewManager != null)
					ViewManager.Events.Publish("ENABLEDCHANGED", this, new object[] { null, null });
			}
		}
		[StateManagement(StateManagementValues.None)]
		public virtual bool IsHandleCreated
		{
			get
			{
				return this.State.HasFlag(ControlState.IsHandleCreated);
			}
			set
			{
				if (value)
					State |= ControlState.IsHandleCreated;
				else
					State &= ~ControlState.IsHandleCreated;
			}
		}

        	/// <summary>
        	/// Gets a value indicating whether the control has been disposed of.
        	/// </summary>
        	/// <maps><get/><set/></maps> 
		[StateManagement(StateManagementValues.None)]
		public bool IsDisposed
		{
			get
			{
				return this.State.HasFlag(ControlState.IsDisposed);
			}
			set
			{
				if (value)
					State |= ControlState.IsDisposed;
				else
					State &= ~ControlState.IsDisposed;
			}
		}


		[StateManagement(StateManagementValues.ClientOnly)]
		public virtual bool Visible
		{
			get
			{
				return this.VisibleState.HasFlag(VisibleState.Visible) && this.VisibleState.HasFlag(VisibleState.ParentVisible);
			}
			set
			{
				if (value)
				{
					List<ILifeCycle> ControlsThatIsNotLoaded = new List<ILifeCycle>(); ;
					//Condition to trigger change event recursively to the child nodes is:
					// I'm not Visible previously 
					if (!this.VisibleState.HasFlag(VisibleState.Visible) /*&& this.State.HasFlag(ControlState.ParentVisible)*/)
					{
						ControlsThatIsNotLoaded = NotifyParentVisibilityAndReturnNotLoadedControl(this, true);
					}

					VisibleState |= VisibleState.Visible;

					foreach (var control in ControlsThatIsNotLoaded)
					{
						control.LifeCycleStartup();
					}

					var currentAsSpecailVisibility = this as ISpecialVisibilityBehaviour;
					if (currentAsSpecailVisibility != null)
					{
						currentAsSpecailVisibility.HandleVisibility();
					}
				}
				else
				{
					//Condition to trigger change event recursively to the child nodes is:
					//I'm Visible previously
					if (this.VisibleState.HasFlag(VisibleState.Visible) /*&& this.State.HasFlag(ControlState.ParentVisible)*/)
					{
						NotifyParentVisibility(this, false);
					}

					VisibleState &= ~VisibleState.Visible;
				}
			}

		}
		/// <summary>
		/// This is a modified breath first search algorithm to fit with our necessity.
		/// </summary>
		public virtual void NotifyParentVisibility(object node, bool isVisible)
		{
			var controlBase = node as ControlBaseViewModel;
			Queue<ControlBaseViewModel> queue = new Queue<ControlBaseViewModel>();

			//preload the children of the root control.
			foreach (var child in controlBase.GetControlsIterator())
			{
				queue.Enqueue(child);
			}

			while (queue.Count > 0)
			{
				ControlBaseViewModel current = queue.Dequeue();
				if (current == null)
					continue;

				if (!isVisible || current.VisibleState.HasFlag(VisibleState.Visible))
				{
					foreach (var child in current.GetControlsIterator())
					{
						queue.Enqueue(child);
					}
				}

				bool currVisibility = current.Visible;
				if (isVisible)
				{
					current.VisibleState |= VisibleState.ParentVisible;
				}
				else
				{
					current.VisibleState &= ~VisibleState.ParentVisible;
				}
				if (ViewManager != null && currVisibility != current.Visible)
					ViewManager.Events.PublishOrEnqueueEvent("VISIBLECHANGED", current, current, System.EventArgs.Empty);
			}
		}

		protected virtual List<ILifeCycle> NotifyParentVisibilityAndReturnNotLoadedControl(object node, bool isVisible)
		{
			var controlBase = node as ControlBaseViewModel;
			Queue<ControlBaseViewModel> queue = new Queue<ControlBaseViewModel>();
			List<ILifeCycle> controls = new List<ILifeCycle>();
			//preload the children of the root control.
			foreach (var child in controlBase.GetControlsIterator())
			{
				queue.Enqueue(child);
			}

			while (queue.Count > 0)
			{
				ControlBaseViewModel current = queue.Dequeue();
				if (current == null)
					continue;
				if (current.VisibleState.HasFlag(VisibleState.Visible))
				{
					foreach (var child in current.GetControlsIterator())
					{
						queue.Enqueue(child);
					}
				}
				bool currVisibility = current.Visible;
				if (isVisible)
				{
					current.VisibleState |= VisibleState.ParentVisible;
					if (current.Visible && !current.Loaded)
						controls.Add(current);
				}
				else
				{
					current.VisibleState &= ~VisibleState.ParentVisible;
				}
				if (ViewManager != null && currVisibility != current.Visible)
					ViewManager.Events.PublishOrEnqueueEvent("VISIBLECHANGED", current, current, System.EventArgs.Empty);
			}
			return controls;
		}

		[StateManagement(StateManagementValues.None)]
		public bool Loaded
		{
			get
			{
				return this.State.HasFlag(ControlState.Loaded);
			}

			set
			{
				if (value)
					State |= ControlState.Loaded;
				else
					State &= ~ControlState.Loaded;
			}
		}
		#endregion

		#region Control Properties
		/* //, MOBILIZE,09/30/2016,TODO,CEBR,"Manually Changed", unnecesary reference attribute */
		//[UpgradeHelpers.Helpers.Reference]
		public virtual object Tag { get; set; }
		[DefaultValue(null)]
		public virtual Font Font { get; set; }

		public virtual int Top { get; set; }

		public virtual int Left { get; set; }

		public virtual int Right { get; set; }

		public virtual int Height { get; set; }
		public int _width { get; set; }

		public virtual int Width
		{
			get
			{
				if (!this.AutoSize)
					return _width;
				else
					return String.IsNullOrEmpty(this.Text) ? Byte.MinValue : this.Text.Length * 7;
			}

			set
			{
				this._width = value;
			}
		}

		[DefaultValue(false)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public virtual bool AutoSize { get; set; }
		public virtual int TabIndex { get; set; }
		[DefaultValue(null)]
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public virtual Color BackColor { get; set; }
		[DefaultValue(null)]
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public virtual Color ForeColor { get; set; }

		public virtual string Text { get; set; }
		#endregion

		public virtual IList<ControlViewModel> Controls { get; set; }
		public virtual string Name { get; set; }

		public virtual DockStyle Dock { get; set; }

		public virtual Point Location { get; set; }

		public virtual Size Size { get; set; }

		/// <summary>
		/// Gets or sets the tab order of the element in the view that will represent this model 
		/// </summary>       
		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UniqueID { get; set; }

		public virtual void Build(IIocContainer ctx)
		{
			this.Enabled = true;
			this.VisibleState |= VisibleState.Visible;
			this.VisibleState |= VisibleState.ParentVisible;
			this.Loaded = false;
		}

		public IViewManager ViewManager { get; set; }

		public IIocContainer Container{ get; set;}

		/// <summary>
		/// Handles the startup events execution for a control.
		/// </summary>
		/// <param name="parent"></param>
		/// <summary>
		/// Handles the startup events execution for a control.
		/// </summary>
		/// <param name="parent"></param>
		public virtual void LifeCycleStartup(IControlWithState parent = null)
		{
			if (this.Loaded || !this.Visible || (parent != null && !parent.Loaded && !parent.Visible))
			{
				//The control is either already loaded or not ready to be loaded yet.
				return;
			}

			this.Loaded = true;

			//The Events chain is executed for a form startup
			CallHandleCreatedEvent();
			CallBindingContextChanged();
			CallLoadEvents();
			CallVisibleChangedEvents();
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
			this.OnLoad(EventArgs.Empty);
			this.ExecuteLoadHandlers();
		}

		/// <summary>
		/// Executes the binding context changed.
		/// </summary>
		private void CallBindingContextChanged()
		{
			//Handles Binding ContextChanged Event
			this.OnBindingContextChanged(EventArgs.Empty);
			this.ExecuteBindingContextChangedHandlers();
		}

		/// <summary>
		/// Executes the handle created event.
		/// </summary>
		private void CallHandleCreatedEvent()
		{
			//Handles HandleCreated Event
			if (!IsHandleCreated)
			{
				this.IsHandleCreated = true;
				this.OnHandleCreated(EventArgs.Empty);
				this.ExecuteHandleCreatedHandlers();
			}
		}
		/// <summary>
		/// Executed the LifeCycleStatup events for the controls that have been added dynamically.
		/// </summary>
		protected override void ExecuteControlsStartup()
		{
			this.DynamicControlsStartup();
		}

		/// <summary>
		/// Handles the shutdown events execution for a control.
		/// </summary>
		/// <returns>Returns "true". The control shutdown cannot be canceled.</returns>
		public virtual bool ExecuteLifeCycleShutdown()
		{
			Dispose();
			//Control's shutdown cannot be canceled
			return this.IsDisposed;
		}

		public override void Dispose()
		{
			if (!this.IsDisposed)
			{
				ExecuteControlsShutdown();
				if (Controls is IList<ControlViewModel>)
					DynamicControlsShutdown(Controls);
				base.Dispose();
				this.IsDisposed = true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !IsDisposed)
			{
				//if (!Loaded)
				//{
				//	//If the control is disposed it should not be in the pending to load dictionary anymore
				//	PendingState.RemoveNotLoadedControl(this);
				//	PendingState.NotLoadedChildrens.Remove(this);
				//}
				this.IsDisposed = true;
			}
		}

		public void BringToFront()
		{
			this.Visible = true;
		}
		/// <summary>
		/// Triggers the life cycle startup events for the controls contained in the Controls List.
		/// </summary>
		protected virtual void DynamicControlsStartup()
		{
			if (Controls == null) return;
			foreach (var control in Controls)
			{
				var wrappedControl = control as ILifeCycle;
				if (wrappedControl != null)
				{
					//Loads the dynamic controls
					wrappedControl.LifeCycleStartup(this);
				}
			}
		}

		public IDisposable components;
	}
}
