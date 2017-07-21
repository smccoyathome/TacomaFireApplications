using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
	public class RowScrollRegion: IDependentModel
	{
		public string UniqueID { get; set; }

		public virtual UltraGridRow FirstRow { get; set; }
	}
}
