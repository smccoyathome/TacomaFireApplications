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

	public partial class frmShiftCal
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmShiftCalViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmShiftCal));
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


		private void frmShiftCal_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FillScreen()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CurrCol = 0, CurrMonth = 0, CurrRow = 0;
			ClearScreen();
			ViewModel.sprShift.Col = 28;
			ViewModel.sprShift.Row = 1;
			ViewModel.sprShift.Text = ViewModel.ReportYear;

			string StartDate = "1/1/" + ViewModel.ReportYear;
			string EndDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(StartDate).AddYears(1));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_ShiftCal '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				if (CurrMonth != Convert.ToDouble(oRec["report_month"]))
				{
					CurrCol = Convert.ToInt32((Convert.ToDouble(oRec["report_month"]) * 4) - 3);
					CurrMonth = Convert.ToInt32(oRec["report_month"]);
					CurrRow = 4;
				}
				else
				{
					CurrRow++;
				}
				ViewModel.sprShift.Col = CurrCol;
				ViewModel.sprShift.Row = CurrRow;
				ViewModel.sprShift.Text = modGlobal.Clean(oRec["day_of_week"]);
				ViewModel.sprShift.Col = CurrCol + 1;
				ViewModel.sprShift.Text = modGlobal.Clean(oRec["shift_day"]);
				if (Convert.ToBoolean(oRec["cycle_day_ind"]))
				{
					ViewModel.sprShift.FontBold = true;
					//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				}
				ViewModel.sprShift.Col = CurrCol + 2;
				ViewModel.sprShift.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprShift.Col = CurrCol + 3;
				ViewModel.sprShift.Text = modGlobal.Clean(oRec["debit_group_code"]);
				oRec.MoveNext();
			};

		}

		public void ClearScreen()
		{
			ViewModel.sprShift.Col = 28;
			ViewModel.sprShift.Row = 1;
			ViewModel.sprShift.Text = "";
			ViewModel.sprShift.BlockMode = true;
			ViewModel.sprShift.Col = 1;
			ViewModel.sprShift.Row = 4;
			ViewModel.sprShift.Col2 = 48;
			ViewModel.sprShift.Row2 = 34;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprShift.FontBold = false;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//Re-Draw border around Months
			ViewModel.sprShift.Row = 4;
			ViewModel.sprShift.Row2 = 34;
			ViewModel.sprShift.Col = 1;
			ViewModel.sprShift.Col2 = 4;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 5;
			ViewModel.sprShift.Col2 = 8;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 9;
			ViewModel.sprShift.Col2 = 12;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 13;
			ViewModel.sprShift.Col2 = 16;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 17;
			ViewModel.sprShift.Col2 = 20;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 21;
			ViewModel.sprShift.Col2 = 24;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 25;
			ViewModel.sprShift.Col2 = 28;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 29;
			ViewModel.sprShift.Col2 = 32;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 33;
			ViewModel.sprShift.Col2 = 36;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 37;
			ViewModel.sprShift.Col2 = 40;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 41;
			ViewModel.sprShift.Col2 = 44;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.Col = 45;
			ViewModel.sprShift.Col2 = 48;
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprShift.BlockMode = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.ReportYear = ViewModel.cboYear.Text;
			FillScreen();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Shift Calendar Report
			//Timestamp report and print

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprShift.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprShift.setPrintAbortMsg("Printing Shift Calendar - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprShift.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprShift.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprShift.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprShift.setPrintColor(true);
            //    sprShift.PrintOrientation = 2
            ViewModel.sprShift.PrintSheet(null);
			//ViewModel.sprShift.Action = (FarPoint.ViewModels.FPActionConstants) 32;


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetYearList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.ReportYear = DateTime.Now.Year.ToString();
			ViewModel.cboYear.Text = ViewModel.ReportYear;
			FillScreen();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmShiftCal DefInstance
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

		public static frmShiftCal CreateInstance()
		{
			PTSProject.frmShiftCal theInstance = Shared.Container.Resolve< frmShiftCal>();
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
			ViewModel.sprShift.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprShift.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmShiftCal
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmShiftCalViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmShiftCal m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}