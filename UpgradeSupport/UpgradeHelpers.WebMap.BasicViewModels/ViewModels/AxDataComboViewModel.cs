using System.Collections.Generic;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class AxDataComboViewModel : ComboBoxViewModel
	{
		public new void Build(IIocContainer container)
		{
			CustomText = "";
			// Enabled DefaultValue
			Enabled = true;

			// Visible DefaultValue
			Visible = true;

			// SelectedIndex DefaultValue
			SelectedIndex = 0;

			ComboBoxItems = container.Resolve<IList<ComboBoxItem>>();
		}

		public string BoundText
		{
			get { return ValueMember; }
			set { ValueMember = value; }
		}

		/// <summary>
		/// Returns or sets the name of a field that a data consumer will be bound to.
		/// </summary>
		public virtual string DataField
		{
			get { return DisplayMember; }
			set { DisplayMember = value; }
		}

		/// <summary>
		/// Returns or sets the name of the source field in a Recordset object that is used to supply a data value to another Recordset.
		/// </summary>
		public virtual string BoundColumn
		{
			get { return ValueMember; }
			set { ValueMember = value; }
		}

		[StateManagement(StateManagementValues.None)]
		public virtual string defText
		{
			get { return Text; }
			set { Text = value; }
		}

		[StateManagement(StateManagementValues.None)]
		public virtual string CtlText
		{
			get { return Text; }
			set { Text = value; }
		}
		public virtual string ListField { get; set; }

	}
}
