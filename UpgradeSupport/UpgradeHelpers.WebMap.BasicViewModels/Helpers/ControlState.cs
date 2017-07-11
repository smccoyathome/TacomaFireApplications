using System;
using System.Collections.Generic;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;


public class PendingControlState : IPendingControlState
{
	public static SharedState Shared
	{
		get
		{
			return UpgradeHelpers.Helpers.StaticContainer.GetSharedItem<SharedState>();
		}
	}

	public IDictionary<IControlWithState, IControlWithState> NotLoadedControls
	{
		get
		{
			return Shared.NotLoadedControls;
		}
	}

	public IDictionary<IControlWithState, IList<IControlWithState>> NotLoadedChildrens
	{
		get
		{
			return Shared.NotLoadedChildrens;
		}
	}

	/// <summary>
	/// Stores the not visible controls that were not loaded during the LifeCycleStartup process.
	/// </summary>
	/// <param name="control"></param>
	public void RegisterNotLoadedControl(IControlWithState control, IControlWithState parent)
	{
		if (this.NotLoadedControls.ContainsKey(control))
		{
			this.NotLoadedControls[control] = parent;
		}
		else
		{
			this.NotLoadedControls.Add(control, parent);
		}
	}
	/// <summary>
	/// Removes a control from the pending to load dictionary
	/// The control has been loaded or its parent has been disposed.
	/// </summary>
	/// <param name="control"></param>
	public void RemoveNotLoadedControl(IControlWithState control)
	{
		this.NotLoadedControls.Remove(control);
	}

	public IControlWithState GetNotLoadedParent(IControlWithState control)
	{
		IControlWithState result = null;
		this.NotLoadedControls.TryGetValue(control, out result);
		return result;
	}
	//Adds or updartes the list of child controls that are not yet loaded.
	public void RegisterNotLoadedChildren(IControlWithState parent, IControlWithState control)
	{
		IList<IControlWithState> controls = null;
		this.NotLoadedChildrens.TryGetValue(parent, out controls);
		if(controls == null)
		{
			controls = StaticContainer.Instance.Resolve<IList<IControlWithState>>();
			controls.Add(control);
			this.NotLoadedChildrens.Add(parent, controls);
		}else
		{
			controls.Add(control);
		}
	}
	//Removes the control from the list
	public void RemoveNotLoadedChildren(IControlWithState parent, IControlWithState control)
	{
		IList<IControlWithState> controls = null;
		this.NotLoadedChildrens.TryGetValue(parent, out controls);
		controls.Remove(control);
		if (controls.Count == 0)
		{
			this.NotLoadedChildrens.Remove(parent);
		}
	}

	public IList<IControlWithState> GetNotLoadedChildren(IControlWithState parent)
	{
		IList<IControlWithState> controls = null;
		this.NotLoadedChildrens.TryGetValue(parent, out controls);
		return controls;
	}

	[UpgradeHelpers.Helpers.Singleton()]
	public class SharedState
			: UpgradeHelpers.Interfaces.IModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.
			Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(SharedState));
		}

		public virtual IDictionary<IControlWithState, IControlWithState> _notLoadedControls { get; set; }
		/// <summary>
		/// Contains the controls that where invisible at the time of executing the LifeCycleStartUp and are not ready to be loaded.
		/// </summary>
		public IDictionary<IControlWithState, IControlWithState> NotLoadedControls
		{
			get
			{
				if (this._notLoadedControls == null)
				{
					this._notLoadedControls = Container.Resolve<IDictionary<IControlWithState, IControlWithState>>();
				}
				return _notLoadedControls;
			}
		}

		public virtual IDictionary<IControlWithState, IList<IControlWithState>> _notLoadedChildren { get; set; }
		/// <summary>
		/// Contains the controls that where invisible at the time of executing the LifeCycleStartUp 
		/// and later were set to visible but its parent was not ready and they cannot be loaded yet.
		/// </summary>
		public IDictionary<IControlWithState, IList<IControlWithState>> NotLoadedChildrens
		{
			get
			{
				if (this._notLoadedChildren == null)
				{
					this._notLoadedChildren = Container.Resolve<IDictionary<IControlWithState, IList<IControlWithState>>>();
				}
				return _notLoadedChildren;
			}
		}
	}
}

public interface IPendingControlState
{
	IDictionary<IControlWithState, IControlWithState> NotLoadedControls { get; }
	IDictionary<IControlWithState, IList<IControlWithState>> NotLoadedChildrens { get; }
	void RegisterNotLoadedControl(IControlWithState control, IControlWithState parent);
	void RemoveNotLoadedControl(IControlWithState control);
	void RegisterNotLoadedChildren(IControlWithState parent, IControlWithState control);
	void RemoveNotLoadedChildren(IControlWithState parent, IControlWithState control);
	IControlWithState GetNotLoadedParent(IControlWithState control);
	IList<IControlWithState> GetNotLoadedChildren(IControlWithState parent);
}