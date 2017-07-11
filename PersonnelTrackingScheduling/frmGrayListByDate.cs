using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmGrayListByDate
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmGrayListByDateViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmGrayListByDate));
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


		private void frmGrayListByDate_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void FillGrid()
		{
			//Get List of Employees On Sick Leave Report prior to Report Done...
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sName = "";

			//set up variables

			int CurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_GetBattScheduleGrayList '" + ViewModel.sShiftDate + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There were no records.", "Fill Grid List", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}


			while(!oRec.EOF)
			{
				sName = "";
				CurrRow++;
				ViewModel.sprEmployeeGrid.Row = CurrRow;

				sName = modGlobal.Clean(oRec["name_last"]) + ", " + modGlobal.Clean(oRec["name_first"]);
				ViewModel.sprEmployeeGrid.Col = 1;
				ViewModel.sprEmployeeGrid.Text = sName;
				ViewModel.sprEmployeeGrid.Col = 2;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeGrid.Col = 3;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeGrid.Col = 4;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprEmployeeGrid.Col = 5;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprEmployeeGrid.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeGrid.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));

				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintAbortMsg("Printing Employees Grayed On Batt Schedule List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeGrid.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeGrid.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeGrid.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprEmployeeGrid.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "List Grayed Staff by Date"
			ViewModel.sShiftDate = modGlobal.Shared.gStartTrans;

			System.DateTime TempDate = DateTime.FromOADate(0);
			this.ViewModel.Text = "Sick Leave Report - Grayed for " + ((DateTime.TryParse(ViewModel.sShiftDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.sShiftDate);
			FillGrid();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmGrayListByDate DefInstance
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

		public static frmGrayListByDate CreateInstance()
		{
			PTSProject.frmGrayListByDate theInstance = Shared.Container.Resolve< frmGrayListByDate>();
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
			ViewModel.sprEmployeeGrid.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeGrid.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmGrayListByDate
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmGrayListByDateViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmGrayListByDate m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}