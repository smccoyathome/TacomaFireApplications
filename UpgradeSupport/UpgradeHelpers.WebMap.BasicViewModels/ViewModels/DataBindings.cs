using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class DataBindings : IDependentViewModel
	{
		public void Build(IIocContainer ctx)
		{
			Bindings = ctx.Resolve<Bindings>();
		}

		#region Data Members
		public string UniqueID { get; set; }

		/// <summary>
		/// Class containing the list of Bindings attached to the control/form/view that contains this DataBindings.
		/// </summary>
		public virtual Bindings Bindings { get; set; }
		#endregion

		#region Methods
		/// <summary>
		/// Adds a new DataBinding with its corresponding parameters.
		/// </summary>
		/// <param name="dataBinding">The new instance to add to the bindings.</param>
		/// <param name="controlName">The name of the control to attach this binding.</param>
		/// <param name="propertyName">The name of property in the control to attach this binding.</param>
		/// <param name="dataSource">The data source (ADORecordset) being attached in this binding.</param>
		/// <param name="dataMember">The name of the member in the data source to assing in the corresponding bound control.</param>
		public void Add(DataBinding dataBinding, string controlName, string propertyName, object dataSource, string dataMember)
		{
			dataBinding.ControlName = controlName;
			dataBinding.PropertyName = propertyName;
			dataBinding.DataSource = dataSource;
			dataBinding.MemberName = dataMember;
			Bindings.Items.Add(dataBinding);
		}

		/// <summary>
		/// Syncronize the list of binding contained in this DataBindings.
		/// </summary>
		/// <param name="container">The control/form/view that contains the bound control</param>
		/// <param name="rs">Optional parameter that contains the data source (ADORecordsetHelper) being bound</param>
		public void Bind(IViewModel container, Object rs = null)
		{
			Debug.Assert(container != null, "DataBinding.myContainer is null");
			foreach (DataBinding binding in Bindings.Items)
			{
				var ctrl = GetControlProp(container, binding.ControlName);
				Debug.Assert(ctrl != null, "DataBinding.ctrl is null");
				var prop = ctrl.GetType().GetProperty(binding.PropertyName);
				Debug.Assert(prop != null, "DataBinding.prop is null");
				prop.SetValue(ctrl, Convert.ChangeType(binding.GetDataSourceValue(rs), prop.PropertyType), null);
			}
		}

		private object GetControlProp(IViewModel container, string ctrlName)
		{
			string[] partsStr = ctrlName.Split('_');
			int i;
			if (partsStr.Length == 3 && partsStr[0] == "" && Int32.TryParse(partsStr[2], out i))
			{
				var ctrlArrPI = container.GetType().GetProperty(partsStr[1]);
				Debug.Assert(ctrlArrPI != null, "DataBinding.ctrlArrPI is null");
				var ctrlArr = ctrlArrPI.GetValue(container, null);
				Debug.Assert(ctrlArr != null, "DataBinding.ctrlArr is null");
				var indexer = ctrlArr.GetType().GetProperty("Item");
				Debug.Assert(indexer != null, "DataBinding.indexer is null");
				return indexer.GetValue(ctrlArr, new object[] { i });
			}
			else
			{
				var ctrlPI = container.GetType().GetProperty(ctrlName);
				Debug.Assert(ctrlPI != null, "DataBinding.ctrlPI is null");
				return ctrlPI.GetValue(container, null);
			}
		}
		#endregion

	}

	public class Bindings : IDependentViewModel
	{
		public string UniqueID { get; set; }

		public virtual IList<DataBinding> Items { get; set; }

		public void Build(IIocContainer ctx) {
			Items = ctx.Resolve<IList<DataBinding>>();
		}
	}

	public class DataBinding : IDependentViewModel
	{
		public void Build(IIocContainer ctx)
		{
		}

		public virtual string UniqueID { get; set; }

		/// <summary>
		/// The name of the control to attach this binding.
		/// </summary>
		public virtual string ControlName { get; set; }
		/// <summary>
		/// The name of property in the control to attach this binding.
		/// </summary>
		public virtual string PropertyName { get; set; }
		/// <summary>
		/// The data source (ADORecordset) being attached in this binding.
		/// </summary>
		public virtual object DataSource { get; set; }
		/// <summary>
		/// The name of the member in the data source to assing in the corresponding bound control.
		/// </summary>
		public virtual string MemberName { get; set; }

		/// <summary>
		/// Obtains the value of the current row in the data source corresponding to the member name
		/// </summary>
		/// <param name="eventRs">The data source (ADORecordsetHelper) to get the value</param>
		/// <returns></returns>
		public object GetDataSourceValue(object eventRs)
		{
			try
			{
				/*var rsPI = DataSource.GetType().GetProperty("Recordset");
				Debug.Assert(rsPI != null, "DataBinding.rs is null");
				var rs = rsPI.GetValue(DataSource, null);
				Debug.Assert(rs != null, "DataBinding.rs is null");*/
				var rs = DataSource;
				//TODO: Using eventRs bc rs was not desearialized correctly.
				if (eventRs != null)
					rs = eventRs;
				Debug.Assert(rs != null, "DataBinding.indexer is null");
				var indexer = rs.GetType().GetProperty("Item", new Type[] { typeof(string) });
				return indexer.GetValue(rs, new string[] { MemberName });
			}
			catch
			{
			}
			return MemberName;
		}
	}
}
