using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgTrade
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTradeViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgTrade));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgTrade_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//*****************************************
		//* Dialog to gather info for Staff Trade *
		//*****************************************
		//ADODB
		[UpgradeHelpers.Events.Handler]
		internal void cboFullList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Come Here - for employee id change
			modGlobal
				.Shared.gTradeEmp = ViewModel.cboFullList.Text.Substring(Math.Max(ViewModel.cboFullList.Text.Length - 5, 0));

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkAMPM_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkAMPM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gFullShift = 0;
			}
			else
			{
				modGlobal.Shared.gFullShift = -1;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Re-initialize global variables
			modGlobal
				.Shared.gTradeEmp = "";
			modGlobal.Shared.gFullShift = 0;
			modGlobal.Shared.gSType = "";
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkAMPM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				modGlobal.Shared.gFullShift = 0;
			}
			else
			{
				modGlobal.Shared.gFullShift = -1;
			}
			modGlobal.Shared.gSType = "";
			ViewManager.DisposeView(this);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Trade Employee List Box
			//Display Schedule both Shifts chkbox if indicated
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			//Fill All Staff listbox
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spOpNameList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboFullList.Items.Clear();


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				this.ViewModel.cboFullList.AddItem(strName);
				oRec.MoveNext();
			};


			if (modGlobal.Shared.gSType == "Cancel")
			{
				dlgTrade.DefInstance.ViewModel.Text = "Cancel Trade";
				ViewModel.lbTitle.Text = "Select Originally Scheduled Employee";
			}
			else if (modGlobal.Shared.gSType == "New")
			{
				dlgTrade.DefInstance.ViewModel.Text = "Schedule Employee";
			}

			if (modGlobal.Shared.gFullShift != 0)
			{
				ViewModel.boxAMPM.Visible = true;
				ViewModel.chkAMPM.Visible = true;
				ViewModel.lbAMPM.Visible = true;
				modGlobal.Shared.gFullShift = 0;
			}
			else
			{
				ViewModel.boxAMPM.Visible = false;
				ViewModel.chkAMPM.Visible = false;
				ViewModel.lbAMPM.Visible = false;
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgTrade DefInstance
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

		public static dlgTrade CreateInstance()
		{
			PTSProject.dlgTrade theInstance = Shared.Container.Resolve< dlgTrade>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.boxAMPM.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.boxAMPM.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgTrade
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTradeViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgTrade m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}