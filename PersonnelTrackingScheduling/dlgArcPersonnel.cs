using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgArcPersonnel
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgArcPersonnelViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgArcPersonnel));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgArcPersonnel_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//*******************************************
		//* Dialog to gather info for Inactivating  *
		//* Personnel                               *
		//*******************************************
		//ADODB
		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Cancel Archive Actions
			modGlobal
				.Shared.gTransCancel = -1;
			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gAssignID = "";
			modGlobal.Shared.gDetailEmp = "";
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			string str1 = "";
			string str2 = "";
			int i = 0;

			if ( ViewModel.FirstTime != 0)
			{
				ViewModel.lbInstruct1.Visible = false;
				ViewModel.lbInstruct2.Visible = true;
				ViewModel.lbExit.Visible = true;
				ViewModel.txtExit.Visible = true;
				ViewModel.lbExitType.Visible = true;
				ViewModel.cboExitType.Visible = true;
				ViewModel.txtComments.Visible = true;
				ViewModel.FirstTime = 0;
				return;
			}

			if (Information.IsDate(ViewModel.txtExit.Text))
			{
				//Exit Date OK
				modGlobal
					.Shared.gStartTrans = ViewModel.txtExit.Text;
			}
			else
			{
				ViewManager.ShowMessage("Exit date is Invalid", "Archive Personnel", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				ViewManager.SetCurrent(ViewModel.txtExit);
				ViewModel.txtExit.SelectionStart = 0;
				ViewModel.txtExit.SelectionLength = Strings.Len(ViewModel.txtExit.Text);
				return;
			}

			switch( ViewModel.cboExitType.Text)
			{
				case "Retirement" :
					modGlobal.Shared.gAssignID = "RT";
					break;
				case "Transfer" :
					modGlobal.Shared.gAssignID = "TR";
					break;
				case "Resignation" :
					modGlobal.Shared.gAssignID = "QT";
					break;
				case "Termination" :
					modGlobal.Shared.gAssignID = "TM";
					break;
				default:
					ViewManager.ShowMessage("Please select a Reason for Leaving", "Archive Personnel", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.cboExitType);
					return;
			}

			modGlobal.Shared.gDetailEmp = ViewModel.txtComments.Text.Trim();

			while((modGlobal.Shared.gDetailEmp.IndexOf('\'') + 1) != 0)
			{
				i = (modGlobal.Shared.gDetailEmp.IndexOf('\'') + 1);
				str1 = modGlobal.Shared.gDetailEmp.Substring(0, Math.Min(i - 1, modGlobal.Shared.gDetailEmp.Length));
				str2 = modGlobal.Shared.gDetailEmp.Substring(Math.Max(modGlobal.Shared.gDetailEmp.Length - (Strings.Len(modGlobal.Shared.gDetailEmp) - i), 0));
				modGlobal.Shared.gDetailEmp = str1 + "-" + str2;
			};
			modGlobal.Shared.gDetailEmp = modGlobal.Shared.gDetailEmp.Substring(0, Math.Min(255, modGlobal.Shared.gDetailEmp.Length));

			modGlobal.Shared.gTransCancel = 0;
			ViewManager.DisposeView(this);


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Initialize Modual and Global Variables
			//Used by this dialog
			ViewModel.FirstTime = -1;
			modGlobal.Shared.gTransCancel = -1;
			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gAssignID = "";
			modGlobal.Shared.gDetailEmp = "";

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgArcPersonnel DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null)
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared. m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static dlgArcPersonnel CreateInstance()
		{
			PTSProject.dlgArcPersonnel theInstance = Shared.Container.Resolve< dlgArcPersonnel>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgArcPersonnel
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgArcPersonnelViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

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
			}

			public virtual dlgArcPersonnel m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}