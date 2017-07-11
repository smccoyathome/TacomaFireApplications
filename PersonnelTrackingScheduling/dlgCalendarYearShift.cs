using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgCalendarYearShift
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgCalendarYearShiftViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgCalendarYearShift));
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


		private void dlgCalendarYearShift_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		private void FillGrids()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprGrid.BlockMode = true;
			ViewModel.sprGrid.Row = 1;
			ViewModel.sprGrid.Row2 = ViewModel.sprGrid.MaxRows;
			ViewModel.sprGrid.Col = 1;
			ViewModel.sprGrid.Col2 = ViewModel.sprGrid.MaxCols;
			ViewModel.sprGrid.Text = "";
			ViewModel.sprGrid.FontBold = false;
			ViewModel.sprGrid.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_CalendarYearShiftTotals ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int i = 0;
			string sYear = "";

			while(!oRec.EOF)
			{
				ViewModel.sprGrid.Row = i;
				if (sYear != modGlobal.Clean(oRec["Year"]))
				{
					i++;
					ViewModel.sprGrid.Row = i;
					ViewModel.sprGrid.Col = 1;
					ViewModel.sprGrid.Text = modGlobal.Clean(oRec["Year"]);
					sYear = modGlobal.Clean(oRec["Year"]);
					if (DateTime.Now.Year == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(sYear))
					{
						ViewModel.sprGrid.FontBold = true;
					}
					else
					{
						ViewModel.sprGrid.FontBold = false;
					}
				}


				if (modGlobal.Clean(oRec["shift_code"]) == "A")
				{
					ViewModel.sprGrid.Col = 2;
				}
				else if (modGlobal.Clean(oRec["shift_code"]) == "B")
				{
					ViewModel.sprGrid.Col = 3;
				}
				else if (modGlobal.Clean(oRec["shift_code"]) == "C")
				{
					ViewModel.sprGrid.Col = 4;
				}
				else if (modGlobal.Clean(oRec["shift_code"]) == "D")
				{
					ViewModel.sprGrid.Col = 5;
				}

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprGrid.Text = Convert.ToString(modGlobal.GetVal(oRec["NumOfDays"]));

				if (DateTime.Now.Year == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(sYear))
				{
					ViewModel.sprGrid.FontBold = true;
				}
				else
				{
					ViewModel.sprGrid.FontBold = false;
				}

				oRec.MoveNext();
			};


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillGrids();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgCalendarYearShift DefInstance
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

		public static dlgCalendarYearShift CreateInstance()
		{
			PTSProject.dlgCalendarYearShift theInstance = Shared.Container.Resolve< dlgCalendarYearShift>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
			ViewManager.NavigateToView(
				PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprGrid.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprGrid.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgCalendarYearShift
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgCalendarYearShiftViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgCalendarYearShift m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}