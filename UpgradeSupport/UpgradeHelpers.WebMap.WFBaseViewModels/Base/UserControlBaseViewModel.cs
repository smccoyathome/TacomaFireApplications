using System;
using System.Collections;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers
{
	/// <summary>
	///     This class defines the base usercontrol class for compilation purposes only.
	/// </summary>
	[StateManagementDefaultValue(StateManagementValues.ServerOnly)]
	public class UserControlBaseViewModel : UpgradeHelpers.Helpers.ContainerControl, IDependentViewModel, ICreatesObjects, IUserControl
	{


		#region properties
		/// <summary>
		/// Gets the rendered height of this element.
		/// </summary>
		public virtual double ActualHeight { get; set; }
		/// <summary>
		/// Gets the rendered width of this element.
		/// </summary>
		public virtual double ActualWidth { get; set; }
		/// <summary>
		/// Gets a value that indicates whether at least one touch is captured to this element.
		/// </summary>
		public virtual bool AreAnyTouchesCaptured { get; set; }
		/// <summary>
		/// Gets a value that indicates whether at least one touch is captured to this element or to any child elements in its visual tree.
		/// </summary>
		public virtual bool AreAnyTouchesCapturedWithin { get; set; }
		/// <summary>
		/// Gets a value that indicates whether at least one touch is pressed over this element.
		/// </summary>
		public virtual bool AreAnyTouchesDirectlyOver { get; set; }
		/// <summary>
		/// Gets a value that indicates whether at least one touch is pressed over this element or any child elements in its visual tree.
		/// </summary>
		public virtual bool AreAnyTouchesOver { get; set; }
		/// <summary>
		/// Gets or sets a brush that describes the background of a control.
		/// </summary>
		public virtual object Background { get; set; }
		/// <summary>
		/// Gets or sets the BindingGroup that is used for the element.
		/// </summary>
		public virtual object BindingGroup { get; set; }
		/// <summary>
		/// Gets or sets a brush that describes the border background of a control.
		/// </summary>
		public virtual object BorderBrush { get; set; }

		//      /// <summary>
		///// Gets or sets the background image displayed in the control.
		///// </summary>
		//public virtual object BackgroundImage { get; set; }



		/// Gets or sets the border style of the user control.
		/// </summary>
		[StateManagement(StateManagementValues.Both)]
		public virtual UpgradeHelpers.Helpers.BorderStyle BorderStyle { get; set; }

		/// <summary>
		/// Gets or sets if the element is ReadOnly
		/// </summary>
		[StateManagement(StateManagementValues.Both)]
		public virtual bool ReadOnly { get; set; }
		/// <summary>
		/// Gets or sets the FlowDirection property
		/// </summary>
		public virtual object FlowDirection { get; set; }
		public virtual bool WrapContents { get; set; }
		public virtual UpgradeHelpers.Helpers.SelectionRules SelectionRules { get; set; }
		public object IndeterminateAppearance { get; set; }



		#endregion
		#region Methods
		public virtual UpgradeHelpers.Helpers.Size ArrangeOverride(UpgradeHelpers.Helpers.Size arrangeSize)
		{
			return arrangeSize;
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> ParentForm
		{
			get
			{
				return ViewManager.GetTopLevelForm(this);
			}
		}

		public event EventHandler Closed;

		[Obsolete("This event handler is useless, check for ILoadable interface")]
		public event EventHandler LoadEvent;

		public event UpgradeHelpers.Events.FormClosedEventHandler FormClosed;
		protected override bool ProcessDialogChar(char charCode)
		{
			return false;
		}

		protected override void OnSizeChanged(System.EventArgs e)
		{
		}

		protected virtual void OnGotFocus(object e)
		{
		}

		protected virtual void OnKeyDown(object e)
		{
		}
		protected virtual void OnKeyPress(object e)
		{
		}
		protected virtual void OnKeyUp(object e)
		{
		}
		protected virtual void OnLeave(object e)
		{
		}
		protected virtual void OnInitializeLayout(object e)
		{
		}
		protected virtual void OnMouseEnter(object e)
		{
		}
		protected virtual void OnMouseLeave(object e)
		{
		}
		protected virtual void OnMouseMove(object e)
		{
		}
		protected virtual void OnMouseUp(object e)
		{
		}
		protected virtual void OnMouseWheel(object e)
		{
		}
		protected virtual void OnOpened(object e)
		{
		}
		protected virtual void OnOpening(object e)
		{
		}
		protected virtual void OnPaint(object e)
		{
		}
		protected virtual void OnParentChanged(object e)
		{
		}
		protected virtual void OnPopup(object e)
		{
		}
		protected virtual void OnPreviewKeyDown(object e)
		{
		}
		protected virtual void OnSelectionChanged(object e)
		{
		}
		protected virtual void OnSystemChanged(object e)
		{
		}
		protected virtual void OnTextChanged(object e)
		{
			ViewManager.Events.Publish("TEXTCHANGED", this, this, e);
		}
		protected virtual void OnDeactivate(System.EventArgs e)
		{
		}
		protected virtual void OnDoubleClick(object e)
		{
		}
		protected virtual void OnEnabledChanged(EventArgs e)
		{
		}
		protected virtual void OnEnter(object e)
		{
		}
		protected virtual void OnFontChanged(object e)
		{
		}
		protected virtual void OnClick(object e)
		{
		}
		protected virtual void OnCheckedValueChanged(object e)
		{
		}

		protected virtual void PreFilterProperties(object properties)
		{
		}

		public virtual void InitializeNewComponent(IDictionary defaultValues)
		{
		}

		public virtual void Initialize(object component)
		{
		}

		protected virtual void InitAppearance(ref object appearance, ref object requestedProps)
		{
		}

		protected virtual void WndProc(ref object m)
		{
		}

		protected virtual void DrawForeground(ref object drawParams)
		{
		}

		protected virtual Type[] CreateNewItemTypes()
		{
			throw new NotImplementedException();
		}

		protected override void OnValidating(Events.CancelEventArgs e)
		{
			base.OnValidating(e);
		}

		public void OnValidatingUtil(Events.CancelEventArgs cea)
		{
			this.OnValidating(cea);
		}

		#endregion

		public IIocContainer Container { get; set; }
	}
}
