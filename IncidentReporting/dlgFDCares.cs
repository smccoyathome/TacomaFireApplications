using System;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public partial class dlgFDCares
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.dlgFDCaresViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgFDCares));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgFDCares_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			IncidentMain.Shared.gFDCaresComment = "";
			IncidentMain.Shared.gFDCaresOK = 0;
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();

			if (EMScl.GetFDCaresIncident(IncidentMain.Shared.gFDCaresIncidentID) != 0)
			{
				if (EMScl.GetFDCaresIncidentPatient(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresPatientID) != 0)
				{
					ViewModel.txtReferComment.Text = IncidentMain.Clean(EMScl.FDCaresReferral["comment"]);
				}
				else
				{
					ViewModel.txtReferComment.Text = IncidentMain.Clean(EMScl.FDCaresReferral["comment"]);
				}
			}
			else
			{
				ViewModel.txtReferComment.Text = "";
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			IncidentMain.Shared.gFDCaresComment = ViewModel.txtReferComment.Text;
			IncidentMain.Shared.gFDCaresOK = -1;
			ViewManager.DisposeView(this);

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgFDCares DefInstance
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

		public static dlgFDCares CreateInstance()
		{
			TFDIncident.dlgFDCares theInstance = Shared.Container.Resolve< dlgFDCares>();
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

	public partial class dlgFDCares
		: UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.dlgFDCaresViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgFDCares m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}