using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class dlgHIPAAMsg
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.dlgHIPAAMsgViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgHIPAAMsg));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void dlgHIPAAMsg_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void CheckComplete()
		{
			//Determine if Release Info complete - Enable/Disable Submit button appropriately

			int ReleaseComplete = -1;
			ViewModel.cmdOut.Enabled = false;
			if (Strings.Len(IncidentMain.Clean(ViewModel.txtReleaseName.Text)) == 0)
			{
				ReleaseComplete = 0;
				ViewModel.txtReleaseName.BackColor = IncidentMain.Shared.REQCOLOR;
			}
			else
			{
				ViewModel.txtReleaseName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
			}
			if (Strings.Len(IncidentMain.Clean(ViewModel.txtReleaseAdd1.Text)) == 0)
			{
				ReleaseComplete = 0;
				ViewModel.txtReleaseAdd1.BackColor = IncidentMain.Shared.REQCOLOR;
			}
			else
			{
				ViewModel.txtReleaseAdd1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
			}
			if (Strings.Len(IncidentMain.Clean(ViewModel.txtReleaseAdd2.Text)) == 0)
			{
				ReleaseComplete = 0;
				ViewModel.txtReleaseAdd2.BackColor = IncidentMain.Shared.REQCOLOR;
			}
			else
			{
				ViewModel.txtReleaseAdd2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
			}
			if (Strings.Len(IncidentMain.Clean(ViewModel.txtReleaseReason.Text)) == 0)
			{
				ReleaseComplete = 0;
				ViewModel.txtReleaseReason.BackColor = IncidentMain.Shared.REQCOLOR;
			}
			else
			{
				ViewModel.txtReleaseReason.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
			}
			ViewModel.cmdOut.Enabled = ReleaseComplete == (-1);


		}

		private void RetrieveMsg()
		{
			//Retrieve HIPAA msg
			TFDIncident.clsHIPAA cHIPAA = Container.Resolve< clsHIPAA>();
			ViewModel.sprHIPAAMsg.Row = 1;
			ViewModel.sprHIPAAMsg.Col = 1;

			if (cHIPAA.GetSystemHIPAAMsg() != 0)
			{
				ViewModel.sprHIPAAMsg.Text = IncidentMain.Clean(cHIPAA.SystemHIPAAMsg["message_text"]);
			}
			else
			{
				ViewModel.sprHIPAAMsg.Text = "Unable to Retrieve HIPAA Message from Database";
			}


		}

		private int SaveRelease()
		{
			//Save Release Record
			TFDIncident.clsHIPAA cHIPAA = Container.Resolve< clsHIPAA>();

			cHIPAA.HIPAAPatientID = IncidentMain.Shared.gHIPAAPatientID;
			cHIPAA.AccessDate = DateTime.Now.ToString("M/d/yyyy HH:mm");
			cHIPAA.AccessBy = IncidentMain.Shared.gCurrUser;
			cHIPAA.RecordsAccessType = IncidentMain.Shared.gHIPAAState;
			cHIPAA.ReleasedToName = Strings.Replace(IncidentMain.Clean(ViewModel.txtReleaseName.Text), "'", "''", 1, -1, CompareMethod.Binary);
			cHIPAA.ReleasedToAddress1 = Strings.Replace(IncidentMain.Clean(ViewModel.txtReleaseAdd1.Text), "'", "''", 1, -1, CompareMethod.Binary);
			cHIPAA.ReleasedToAddress2 = Strings.Replace(IncidentMain.Clean(ViewModel.txtReleaseAdd2.Text), "'", "''", 1, -1, CompareMethod.Binary);
			cHIPAA.ReleasedReason = Strings.Replace(IncidentMain.Clean(ViewModel.txtReleaseReason.Text), "'", "''", 1, -1, CompareMethod.Binary);
			if (~cHIPAA.AddEMSRecordsAccess() != 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}


		}

		//UPGRADE_NOTE: (7001) The following declaration (cmdOK_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void cmdOK_Click()
		//{
			//this.Close();
		//}
		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.AddRequest != 0)
			{
				//Switch to record entry frame
			}
			else
			{
				IncidentMain.Shared.gHIPAAOK = 0;
				ViewManager.DisposeView(this);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOut_Click(Object eventSender, System.EventArgs eventArgs)
		{
			switch(IncidentMain.Shared.gHIPAAState)
			{
				case 1 : case 3 :
					//Accept - Exit dialog 
					IncidentMain
						.Shared.gHIPAAOK = -1;
					ViewManager.DisposeView(this);
					break;
				case 2 : case 4 :
					//Save Release Record and exit 
					if (SaveRelease() != 0)
					{
						IncidentMain.Shared.gHIPAAOK = -1;
						ViewManager.DisposeView(this);
					}
					else
					{
						IncidentMain.Shared.gHIPAAOK = 0;
						CheckComplete();
						if ( ViewModel.cmdOut.Enabled)
						{
							ViewManager.ShowMessage("Error attempting to Save HIPAA Release Information" + "\n" +
								"Please cancel print request and report problem", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
						//Return to dialog - user must complete Release record or cancel
					}
					break;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAMsg.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHIPAAMsg.setPrintAbortMsg("Printing HIPAA Policy Message - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAMsg.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHIPAAMsg.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAMsg.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHIPAAMsg.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprHIPAAMsg.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprHIPAAMsg.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
			ViewModel.sprHIPAAMsg.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//On Form Open determine if Info Msg or Release Info Frame should be displayed
			switch(IncidentMain.Shared.gHIPAAState)
			{
				case 1 : case 3 :
					//Read or Change - display Msg 
					ViewModel.lbHIPAAMsg.Text = "HIPAA Policy Information";
					ViewModel.sprHIPAAMsg.Visible = true;
					ViewModel.frmReleaseInfo.Visible = false;
					ViewModel.cmdOut.Text = "ACCEPT";
					ViewModel.cmdOut.Enabled = true;
					ViewModel.cmdCancel.Visible = true;
					ViewModel.cmdCancel.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.cmdCancel.Text = "ADD RELEASE";
					ViewModel.AddRequest = -1;
					ViewModel.cmdPrint.Visible = true;
					RetrieveMsg();
					break;
				case 2 : case 4 :
					//Print 
					ViewModel.lbHIPAAMsg.Text = "HIPAA Release Information";
					ViewModel.sprHIPAAMsg.Visible = false;
					ViewModel.frmReleaseInfo.Visible = true;
					ViewModel.cmdOut.Text = "SUBMIT";
					ViewModel.cmdOut.Enabled = false;
					ViewModel.cmdCancel.Visible = true;
					ViewModel.cmdCancel.BackColor = IncidentMain.Shared.RED;
					ViewModel.cmdCancel.Text = "CANCEL PRINT REQUEST";
					ViewModel.AddRequest = 0;
					ViewModel.cmdPrint.Visible = false;
					ViewModel.txtReleaseName.Text = "";
					ViewModel.txtReleaseName.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtReleaseAdd1.Text = "";
					ViewModel.txtReleaseAdd1.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtReleaseAdd2.Text = "";
					ViewModel.txtReleaseAdd2.BackColor = IncidentMain.Shared.REQCOLOR;
					ViewModel.txtReleaseReason.Text = "";
					ViewModel.txtReleaseReason.BackColor = IncidentMain.Shared.REQCOLOR;
					break;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtReleaseAdd1_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtReleaseAdd2_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtReleaseName_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtReleaseReason_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			CheckComplete();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgHIPAAMsg DefInstance
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

		public static dlgHIPAAMsg CreateInstance()
		{
			TFDIncident.dlgHIPAAMsg theInstance = Shared.Container.Resolve< dlgHIPAAMsg>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprHIPAAMsg.LifeCycleStartup();
			ViewModel.frmReleaseInfo.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprHIPAAMsg.LifeCycleShutdown();
			ViewModel.frmReleaseInfo.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgHIPAAMsg
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.dlgHIPAAMsgViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgHIPAAMsg m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}