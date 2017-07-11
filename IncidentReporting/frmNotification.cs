using System;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class frmNotification
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmNotificationViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNotification));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmNotification_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		private void GetNextMessage()
		{
			//Retrieve and Display Next Notification Message
			//Mark Message as received
			//Test for additional messages and toggle Next button appropriately
			TFDIncident.clsNotification NotificationCL = Container.Resolve<clsNotification>();

			if ( ~NotificationCL.GetNotificationMessagesNew(IncidentMain.Shared.gCurrUser) != 0 )
			{
				ViewModel.lbDateMessageCreated.Text = "No More Messages";
				ViewModel.lbMessageText.Visible = false;
				ViewModel.cmdNext.Enabled = false;
			}
			else
			{
				ViewModel.lbDateMessageCreated.Text = Convert.ToDateTime(NotificationCL.NotificationMessage["date_message_created"]).ToString("M/d/yyyy HH:mm");
				ViewModel.lbMessageText.Text = IncidentMain.Clean(NotificationCL.NotificationMessage["message_text"]);
				if ( ~NotificationCL.UpdateNotificationMessage(Convert.ToInt32(NotificationCL.NotificationMessage["notification_message_id"]), 1, DateTime.Now.ToString("MM/dd/yyyy HH:mm")) != 0 )
				{
					ViewManager.ShowMessage("Error attempting to update message received status", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return ;
				}
				ViewModel.cmdNext.Enabled = !(~NotificationCL.GetNotificationMessagesNew(IncidentMain.Shared.gCurrUser) != 0);
			}

		}
        //Mobilize_Note: angamboa. this is a manual change to support the cursor , test in Runtime
        UpgradeHelpers.Helpers.Cursor CurrCursor;

        [UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(CurrCursor);
			ViewManager.HideView(this);
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNext_Click(Object eventSender, System.EventArgs eventArgs)
		{
			GetNextMessage();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Display First Message for Current Receiver
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			CurrCursor = this.Get_Cursor();
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
			this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
			GetNextMessage();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmNotification DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null )
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared.m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmNotification CreateInstance()
		{
			TFDIncident.frmNotification theInstance = Shared.Container.Resolve<frmNotification>();
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

	public partial class frmNotification
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmNotificationViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNotification m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}