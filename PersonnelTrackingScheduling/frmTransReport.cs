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

	public partial class frmTransReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTransReport));
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


		private void frmTransReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void FillScreen()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ClearScreen();
			ViewModel.sprTrans.Col = 4;
			ViewModel.sprTrans.Row = 2;
			ViewModel.sprTrans.Text = ViewModel.ReportYear;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Transfer " + ViewModel.ReportYear;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;


			while(!oRec.EOF)
			{
				if ( ViewModel.PageRow > 55)
				{
					DisplayHeadings();
				}
				ViewModel.sprTrans.Row = ViewModel.CurrRow;
				ViewModel.sprTrans.Col = 1;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["shift_date"]);
				ViewModel.sprTrans.Col = 2;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["week_day"]);
				ViewModel.sprTrans.Col = 3;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprTrans.Col = 4;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["ytd_shifts_worked"]);
				ViewModel.sprTrans.Col = 5;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["shifts_left"]);
				ViewModel.sprTrans.Col = 6;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["debit_group_code"]);
				ViewModel.sprTrans.Col = 7;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["ytd_debits_worked"]);
				ViewModel.sprTrans.Col = 8;
				ViewModel.sprTrans.Text = modGlobal.Clean(oRec["debits_left"]);
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				oRec.MoveNext();
			};

		}

		public void ClearScreen()
		{
			ViewModel.sprTrans.BlockMode = true;
			ViewModel.sprTrans.Col = 1;
			ViewModel.sprTrans.Row = 4;
			ViewModel.sprTrans.Col2 = 8;
			ViewModel.sprTrans.Row2 = 425;
			//ViewModel.sprTrans.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprTrans.FontBold = false;
			ViewModel.sprTrans.FontSize = 10;
			//ViewModel.sprTrans.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//Re-Color background
			ViewModel.sprTrans.Row = 4;
			ViewModel.sprTrans.Row2 = 425;
			ViewModel.sprTrans.Col = 4;
			ViewModel.sprTrans.Col2 = 4;
			ViewModel.sprTrans.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprTrans.Col = 5;
			ViewModel.sprTrans.Col2 = 5;
			ViewModel.sprTrans.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprTrans.Col = 7;
			ViewModel.sprTrans.Col2 = 7;
			ViewModel.sprTrans.BackColor = modGlobal.Shared.PARCHMENT;
			ViewModel.sprTrans.Col = 8;
			ViewModel.sprTrans.Col2 = 8;
			ViewModel.sprTrans.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprTrans.BlockMode = false;

		}

		public void DisplayHeadings()
		{
			//DisplayHeadings
			ViewModel.sprTrans.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprTrans.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTrans.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprTrans.Row = ViewModel.CurrRow;
			ViewModel.sprTrans.Col = 1;
			ViewModel.sprTrans.Text = "Tacoma Fire Department";
			ViewModel.sprTrans.FontBold = true;
			ViewModel.sprTrans.FontSize = 12;
			ViewModel.sprTrans.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprTrans.Row = ViewModel.CurrRow;
			ViewModel.sprTrans.Text = "Transfer Schedule";
			ViewModel.sprTrans.FontBold = true;
			ViewModel.sprTrans.FontSize = 12;
			ViewModel.sprTrans.SetRowHeight(ViewModel.CurrRow, 15);
			ViewModel.sprTrans.Col = 4;
			ViewModel.sprTrans.Text = ViewModel.ReportYear;
			ViewModel.sprTrans.FontBold = true;
			ViewModel.sprTrans.FontSize = 12;
			ViewModel.sprTrans.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			(ViewModel.CurrRow)++;
			ViewModel.sprTrans.Row = ViewModel.CurrRow;
			ViewModel.sprTrans.Col = 1;
			ViewModel.sprTrans.Text = "Date";
			ViewModel.sprTrans.Col = 2;
			ViewModel.sprTrans.Text = "Wkdy";
			ViewModel.sprTrans.Col = 3;
			ViewModel.sprTrans.Text = "Shift";
			ViewModel.sprTrans.Col = 4;
			ViewModel.sprTrans.Text = "YTD Worked";
			ViewModel.sprTrans.Col = 5;
			ViewModel.sprTrans.Text = "YTD Remain";
			ViewModel.sprTrans.Col = 6;
			ViewModel.sprTrans.Text = "Debit Grp";
			ViewModel.sprTrans.Col = 7;
			ViewModel.sprTrans.Text = "YTD Dbt Worked";
			ViewModel.sprTrans.Col = 8;
			ViewModel.sprTrans.Text = "YTD Dbt Remain";
			ViewModel.sprTrans.BlockMode = true;
			ViewModel.sprTrans.Row2 = ViewModel.CurrRow;
			ViewModel.sprTrans.Col = 1;
			ViewModel.sprTrans.Col2 = 8;
			ViewModel.sprTrans.FontSize = 12;
			//ViewModel.sprTrans.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprTrans.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprTrans.Row = ViewModel.CurrRow - 3;
			ViewModel.sprTrans.Row2 = ViewModel.CurrRow;
			ViewModel.sprTrans.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprTrans.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageRow = 4;

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
			//Print Transfer Schedule Report

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprTrans.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTrans.setPrintAbortMsg("Printing Transfer Schedule - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprTrans.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTrans.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprTrans.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTrans.setPrintColor(true);
            //    sprTrans.PrintOrientation = 1
            ViewModel.sprTrans.PrintSheet(null);

            //ViewModel.sprTrans.Action = (FarPoint.ViewModels.FPActionConstants) 32;


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
			ViewModel.cboYear.Text = DateTime.Now.Year.ToString();
			ViewModel.ReportYear = ViewModel.cboYear.Text;
			FillScreen();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTransReport DefInstance
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

		public static frmTransReport CreateInstance()
		{
			PTSProject.frmTransReport theInstance = Shared.Container.Resolve< frmTransReport>();
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
			ViewModel.sprTrans.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprTrans.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTransReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTransReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}