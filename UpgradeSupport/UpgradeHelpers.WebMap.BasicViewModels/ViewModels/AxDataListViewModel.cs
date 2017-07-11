using System.Data;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.BasicViewModels
{
	public class AxDataListViewModel : ListBoxViewModel
	{
		public ComboBoxViewModel.ComboBoxData InternalData;

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
			get { return DisplayMember; }
			set { DisplayMember = value; }
		}
		[Reference]
		[StateManagement(StateManagementValues.None)]
		public object DataSource
		{
			get { return InternalData.DataSource; }
			set
			{
				if (value != null)
				{
					foreach (DataRow r in ((DataTable)value).Rows)
					{
						var item = StaticContainer.Instance.Resolve<ListBoxItem>();
						item.Text = r[DisplayMember].ToString();
						item.Value = r[ValueMember];
						item.Item = r[DisplayMember].ToString();
						ListBoxItems.Add(item);
					}
				}

				//
				if (InternalData == null)
					InternalData = new ComboBoxViewModel.ComboBoxData();
				InternalData.DataSource = value;
			}
		}

	}
}
