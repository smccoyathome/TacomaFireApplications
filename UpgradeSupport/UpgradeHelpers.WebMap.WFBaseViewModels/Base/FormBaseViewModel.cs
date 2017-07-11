using System.Collections.Generic;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	public class FormBaseViewModel : IViewModel, IControlWithState, IControlsContainer
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

		[StateManagement(StateManagementValues.ClientOnly)]
		public virtual bool Visible
		{
			get
			{
				return this.VisibleState.HasFlag(VisibleState.Visible);
			}

			set
			{
				if (value)
				{
					NotifyParentVisibility(this, true);
					VisibleState |= VisibleState.Visible;
				}
				else
				{
					NotifyParentVisibility(this, false);
					VisibleState &= ~VisibleState.Visible;
				}
			}
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
		[Reference]
		public virtual object Tag { get; set; }

		public virtual Font Font { get; set; }

		public virtual int Top { get; set; }

		public virtual int Left { get; set; }

		public virtual int Height { get; set; }

		public virtual int Width { get; set; }

		public virtual int TabIndex { get; set; }

		public virtual Color BackColor { get; set; }

		public virtual Color ForeColor { get; set; }

		public virtual string Text { get; set; }
		#endregion
		public virtual IList<ControlViewModel> Controls { get; set; }
		public virtual string Name { get; set; }

		public string UniqueID { get; set; }

		public bool IsDisposing { get; set; }

		public virtual void Build(IIocContainer ctx)
		{
			this.Enabled = true;
			this.Loaded = false;
		}
		public void BringToFront() {/*Does nothing	*/}

		public virtual Point Location { get; set; }
		[StateManagement(StateManagementValues.ClientOnly)]
		public virtual Size Size
		{
			get
			{
				return new Size(this.Width, this.Height);
			}
			set
			{
				if (value != null)
				{
					Height = value.Height;
					Width = value.Width;
				}
			}
		}

		public virtual ImageLayout BackgroundImageLayout { get; set; }

		/// <summary>
		/// This is a modified breath first search algorithm to fit with our necessity.
		/// </summary>
		public void NotifyParentVisibility(object node, bool isVisible)
		{
			var formBase = node as UpgradeHelpers.Interfaces.IControlContainerIterator;
			if (formBase != null)
			{
				Queue<ControlBaseViewModel> queue = new Queue<ControlBaseViewModel>();

				//Preload the children of the root control.
				foreach (var child in formBase.GetControlsIterator())
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

					if (isVisible)
					{
						current.VisibleState |= VisibleState.ParentVisible;
						var currentAsSpecailVisibility = current as ISpecialVisibilityBehaviour;
						if (currentAsSpecailVisibility != null)
						{
							currentAsSpecailVisibility.HandleVisibility();
						}
					}
					else
					{
						current.VisibleState &= ~VisibleState.ParentVisible;
					}
				}
			}
		}
	}
}
