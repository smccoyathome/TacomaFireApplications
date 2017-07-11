using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class SelectionRange : IDependentViewModel
	{
		public virtual DateTime Start { get; set; }
		public virtual DateTime End { get; set; }

		public string UniqueID { get; set; }

        public void Build(IIocContainer ctx)
        {
        }
    }
	public class MonthCalendarViewModel : DateTimePickerViewModel
	{

		public virtual SelectionRange SelectionRange { get; set; }
	}
}
