using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.BasicViewModels
{
	public enum dbiMonthConst
	{
		dbiJanuary = 1,
		dbiFebruary = 2,
		dbiMarch = 3,
		dbiApril = 4,
		dbiMay = 5,
		dbiJune = 6,
		dbiJuly = 7,
		dbiAugust = 8,
		dbiSeptember = 9,
		dbiOctober = 10,
		dbiNovember = 11,
		dbiDecember = 12,
	}

	public class InternalData : IInternalData
	{
		public IList Data = new ArrayList();

		public IListSource DataSource;
	}

	public class TDBDateViewModel : DateTimePickerViewModel
	{
		public InternalData Source;
		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			//
			Value = DateTime.Now;
		}
		public virtual string CtlText { get; set; }
		/// <summary>
		/// Sets/returns which of the control's data properties will be bound to the data source.
		/// 0 - Value Property (Default)
		/// 1 - Number Property
		/// </summary>
		public virtual int DataProperty { get; set; }
		/// <summary>
		/// The FirstMonth property determines the base month for the fiscal year, and is used only when the YearType property is set to 1- Fiscal Year.
		/// </summary>
		public virtual int FirstMonth { get; set; }
		/// <summary>
		/// The PromptChar property allows you to define an SBCS character to use as a prompt when inputting dates with the input mask set in the Format property
		/// </summary>
		public virtual string PromptChar { get; set; }
		/// <summary>
		/// The format is specified by creating a mask using keywords and literals. Note that the input mask must not exist only with literals.
		/// </summary>
		public virtual string Format { get; set; }

		public virtual string BoundColumn { get; set; }

		public virtual string DisplayText { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IListSource DataSource
		{
			get { return Source.DataSource; }
			set
			{
				if (value != null)
				{
					foreach (DataRow r in ((DataTable)value).Rows)
					{
						Value = DateTime.Parse(r[BoundColumn].ToString());
					}
				}

				//
				if (Source == null)
					Source = new InternalData();
				Source.DataSource = value;
			}
		}

		[StateManagement(StateManagementValues.None)]
		public  dbiMonthConst Month {
			get
			{
				return (dbiMonthConst)((DateTime) this.Value).Month;
			}
		}

		[StateManagement(StateManagementValues.None)]
		public virtual int Day {
			get { return ((DateTime) this.Value).Day; }
		}

		[StateManagement(StateManagementValues.None)]
		public virtual int Year
		{
			get { return ((DateTime)this.Value).Year; }
		}
	}
}
