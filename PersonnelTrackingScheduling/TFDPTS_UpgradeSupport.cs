using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class UpgradeSupport
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(UpgradeSupport));
		}

		//UPGRADE_NOTE: (7014) The property 'Word_Global_definst' could be being created from different 'UpgradeSupport' in a multiproject solution More Information: http://www.vbtonet.com/ewis/ewi7014.aspx

		public static Stubs._Microsoft.Office.Interop.Word.Global Word_Global_definst
		{
			get
			{
				if ( Shared._Word_Global_definst == null)
				{
					Shared.
						_Word_Global_definst = new Stubs._Microsoft.Office.Interop.Word.Global();
				}
				return Shared. _Word_Global_definst;
			}
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

		public static SharedState Shared
		{
			get
			{
				return UpgradeHelpers.Helpers.StaticContainer.GetSharedItem<SharedState>();
			}
		}

		[UpgradeHelpers.Helpers.Singleton]
		public class SharedState
			: UpgradeHelpers.Interfaces.IModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.
			Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
		{

			public string UniqueID { get; set; }

			public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

			public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

			void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
			{
				_Word_Global_definst = null;
			}

			public virtual Stubs._Microsoft.Office.Interop.Word.Global _Word_Global_definst { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}