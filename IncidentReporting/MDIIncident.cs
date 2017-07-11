using System;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class MDIIncident
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.MDIIncidentViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(MDIIncident));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				Shared.
					m_vb6FormDefInstance = this;
			}
		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			using ( var async1 = this.Async(true) )
			{

				string SecurityWork = "";

				//Get Information on Currently logoned on Employee
				TFDIncident.clsPersonnel Personnel = Container.Resolve< clsPersonnel>();
				TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

				if (Personnel.GetCurrUserInfo() != 0)
				{
					IncidentMain.Shared.gCurrUser = Personnel.CurrentUserID;
					IncidentMain.Shared.gCurrUserName = Personnel.CurrentUserNameFull;
				}
				else
				{
					ViewManager.ShowMessage("You do NOT have proper access to use this application", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					IncidentMain.Shared.gCurrUser = "";
					IncidentMain.Shared.gCurrUserName = "";
				}
				//*************************************
				//**** For Test - User Can Be HardCoded
				//**** ********************************
				//gCurrUser = ""
				//gCurrUserName = ""
				//**************************************

				if (IncidentCL.GetUserSecurity(IncidentMain.Shared.gCurrUser) != 0)
				{
					IncidentMain.Shared.gSystemSecurity = Convert.ToInt32(IncidentCL.IncidentSecurity["system_security"]);
					IncidentMain.Shared.gWizardSecurity = Convert.ToInt32(IncidentCL.IncidentSecurity["system_security"]);
				}
				else
				{
					IncidentMain.Shared.gSystemSecurity = IncidentMain.NOACCESS;
					IncidentMain.Shared.gWizardSecurity = IncidentMain.NOACCESS;
				}
				async1.Append(() =>
					{

						IncidentMain.CheckNotificationMessages();
					});
				async1.Append(() =>
					{
						ViewManager.HideView(
							frmMain.DefInstance);
					});
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			IncidentMain.Shared.gAppCancel = -1;
			UpgradeHelpers.DB.TransactionManager.DeEnlist(IncidentMain.oIncident);
			IncidentMain.oIncident.Close();
			UpgradeHelpers.DB.TransactionManager.DeEnlist(IncidentMain.oPTSdata);
			IncidentMain.oPTSdata.Close();
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		public static MDIIncident DefInstance
		{
			get
			{
				using ( var async1 = Shared.Async< MDIIncident>(true) )
				{
					if ( Shared.m_vb6FormDefInstance == null)
					{
						Shared.
							m_InitializingDefInstance = true;
						async1.Append<TFDIncident.MDIIncident>(() => CreateInstance());
						async1.Append<TFDIncident.MDIIncident, TFDIncident.MDIIncident>(tempNormalized0 => tempNormalized0);
						async1.Append<TFDIncident.MDIIncident>(tempNormalized1 =>
							{
								Shared.
									m_vb6FormDefInstance = tempNormalized1;
							});
						async1.Append(() =>
							{
								Shared.
									m_InitializingDefInstance = false;
							});
					}
					return Shared.Return< MDIIncident>(() => Shared. m_vb6FormDefInstance);
				}
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static MDIIncident CreateInstance()
		{
			using ( var async1 = Shared.Async< MDIIncident>(true) )
			{
				TFDIncident.MDIIncident theInstance = Shared.Container.Resolve< MDIIncident>();
				async1.Append(() =>
					{
						theInstance.Form_Load();
					});
				return Shared.Return< MDIIncident>(() => theInstance);
			}
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.mnuFile.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.mnuFile.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void Form_Unload(int Cancel)
		//{
		//}

	}

	public partial class MDIIncident
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.MDIIncidentViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual MDIIncident m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void Form_Unload(int Cancel)
		//{
		//}

	}
}