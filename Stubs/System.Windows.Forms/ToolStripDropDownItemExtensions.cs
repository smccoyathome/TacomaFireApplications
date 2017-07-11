using System;

namespace UpgradeHelpers.Extensions
{

	public static class ToolStripDropDownItemExtensions
	{
        public class ToolStripItemCollectionViewModelStub : UpgradeHelpers.BasicViewModels.ToolStripItemCollectionViewModel
        {
            public System.Collections.IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public static ToolStripItemCollectionViewModelStub Get_DropDownItems(this UpgradeHelpers.BasicViewModels.ToolStripMenuItemViewModel _ToolStripDropDownItem)
		{
			throw new NotImplementedException("This is an automatic generated code, please implement the requested logic.");
		}

		}

}