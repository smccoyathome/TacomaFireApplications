using System;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgTransfer
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTransferViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgTransfer));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgTransfer_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//******************************************
		//* Dialog Requesting Information on       *
		//*      Transfers                         *
		//******************************************
		//No Data Access


		private void calStartDate_CloseUp(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = ViewModel.calStartDate.Value.Date.ToString("MM/dd/yyyy");
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkTemp_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.lbEndDate.Visible = true;
			ViewModel.calEndDate.Visible = true;
			ViewModel.chkTemp.Visible = false;
			ViewManager.SetCurrent(ViewModel.calEndDate);
			modGlobal.Shared.gTempTrans = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gTransCancel = -1;
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cScheduler = Container.Resolve< clsScheduler>();
			//Check for Date Selection
			//exit sub

			int iYear = DateTime.Now.AddYears(1).Year;
			//Get the maximum shift_start year from Schedule... just incase
			if (cScheduler.GetScheduleMaxYear() != 0)
			{
				if (!cScheduler.ScheduleRecord.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iYear = Convert.ToInt32(modGlobal.GetVal(cScheduler.ScheduleRecord["MaxYear"]));
				}
			}

			if (!ViewModel.lbEndDate.Visible)
			{
				//TRANSFER END DATE CHANGE
				System
					.DateTime TempDate = DateTime.FromOADate(0);
				modGlobal.Shared.gEndTrans = (DateTime.TryParse("2/1/" + iYear.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "2/1/" + iYear.ToString();
			}
			else if (modGlobal.Shared.gEndTrans == "")
			{
				modGlobal.Shared.gEndTrans = ViewModel.calEndDate.Value.Date.ToString("MM/dd/yyyy");
			}
			else
			{
				modGlobal.Shared.gEndTrans = ViewModel.calEndDate.Value.Date.ToString("MM/dd/yyyy");
			}


			modGlobal.Shared.gStartTrans = ViewModel.calStartDate.Value.Date.ToString("MM/dd/yyyy");


			modGlobal.Shared.gTransCancel = 0;
			ViewManager.DisposeView(this);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//This dialog form requests Start and End dates
			//for Employee Transfers
			PTSProject.clsScheduler cScheduler = Container.Resolve< clsScheduler>();

			int iYear = DateTime.Now.AddYears(1).Year;
			//Get the maximum shift_start year from Schedule... just incase
			if (cScheduler.GetScheduleMaxYear() != 0)
			{
				if (!cScheduler.ScheduleRecord.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iYear = Convert.ToInt32(modGlobal.GetVal(cScheduler.ScheduleRecord["MaxYear"]));
				}
			}

			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gEndTrans = "";
			modGlobal.Shared.gTempTrans = 0;

			//Set Max and Min Date properties for date controls
			System
				.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.calStartDate.MinDate = DateTime.Parse((DateTime.TryParse("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("M/d/yyyy") : "1/1/" + DateTime.Now.Year.ToString());
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			ViewModel.calEndDate.MinDate = DateTime.Parse((DateTime.TryParse("1/1/" + DateTime.Now.Year.ToString(), out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : "1/1/" + DateTime.Now.Year.ToString());
			//TRANSFER END DATE CHANGE
			ViewModel.calStartDate.MaxDate = DateTime.Parse("2/1/" + iYear.ToString()).AddYears(1);
			//TRANSFER END DATE CHANGE
			ViewModel.calEndDate.MaxDate = DateTime.Parse("2/1/" + iYear.ToString()).AddYears(1);




		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgTransfer DefInstance
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

		public static dlgTransfer CreateInstance()
		{
			PTSProject.dlgTransfer theInstance = Shared.Container.Resolve< dlgTransfer>();
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

	public partial class dlgTransfer
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTransferViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgTransfer m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}