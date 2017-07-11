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

	public partial class frmSrReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSrReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmSrReport));
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


		private void frmSrReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearGrid()
		{
			//Clear Previous Report Data & Formatting
			ViewModel.sprSenior.BlockMode = true;
			ViewModel.sprSenior.Row = 4;
			ViewModel.sprSenior.Row2 = ViewModel.MaxRows;
			ViewModel.sprSenior.Col = 1;
			ViewModel.sprSenior.Col2 = 6;
			//ViewModel.sprSenior.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprSenior.FontSize = 10;
			ViewModel.sprSenior.FontBold = false;
			//ViewModel.sprSenior.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSenior.Col = 2;
			ViewModel.sprSenior.Col2 = 2;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprSenior.BlockMode = false;
			ViewModel.PageNo = 1;

		}

		public void DisplayHeadings()
		{
			//Display Report Headings
			ViewModel.sprSenior.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSenior.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSenior.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprSenior.Row = ViewModel.CurrRow;
			ViewModel.sprSenior.Col = 1;
			ViewModel.sprSenior.Text = "Tacoma Fire Department";
			ViewModel.sprSenior.FontSize = 12;
			ViewModel.sprSenior.FontBold = true;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			(ViewModel.PageNo)++;
			ViewModel.sprSenior.Col = 6;
			ViewModel.sprSenior.Text = "Page " + ViewModel.PageNo.ToString();
			ViewModel.sprSenior.FontSize = 12;
			ViewModel.sprSenior.FontBold = true;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			(ViewModel.CurrRow)++;
			ViewModel.sprSenior.Row = ViewModel.CurrRow;
			ViewModel.sprSenior.Col = 1;
			if ( ViewModel.cboSenior.GetItemData(ViewModel.cboSenior.SelectedIndex) == 1)
			{
				ViewModel.sprSenior.Text = "Seniority Ranking List - Operations";
			}
			else if ( ViewModel.cboSenior.GetItemData(ViewModel.cboSenior.SelectedIndex) == 2)
			{
				ViewModel.sprSenior.Text = "Seniority Ranking List - Civilian";
			}
			else
			{
				ViewModel.sprSenior.Text = "Seniority Ranking List - Paramedic";
			}
			ViewModel.sprSenior.FontSize = 12;
			ViewModel.sprSenior.FontBold = true;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprSenior.Col = 4;
			ViewModel.sprSenior.Text = "Report Calculation Date - " + ViewModel.ReportDate;
			ViewModel.sprSenior.FontSize = 12;
			ViewModel.sprSenior.FontBold = true;
			ViewModel.sprSenior.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			(ViewModel.CurrRow)++;
			ViewModel.sprSenior.Row = ViewModel.CurrRow;
			ViewModel.sprSenior.Col = 1;
			ViewModel.sprSenior.Text = "Ranking";
			ViewModel.sprSenior.Col = 2;
			ViewModel.sprSenior.Text = "Employee";
			ViewModel.sprSenior.Col = 3;
			ViewModel.sprSenior.Text = "Max. Vac.";
			ViewModel.sprSenior.Col = 4;
			ViewModel.sprSenior.Text = "TFD Hire Date";
			ViewModel.sprSenior.Col = 5;
			ViewModel.sprSenior.Text = "COT Serv Date";
			ViewModel.sprSenior.Col = 6;
			ViewModel.sprSenior.Text = "Years of Service";
			ViewModel.sprSenior.BlockMode = true;
			ViewModel.sprSenior.Row2 = ViewModel.CurrRow;
			ViewModel.sprSenior.Col = 1;
			ViewModel.sprSenior.Col2 = 6;
			ViewModel.sprSenior.FontSize = 12;
			//ViewModel.sprSenior.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprSenior.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprSenior.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageRow = 4;

		}

		[UpgradeHelpers.Events.Handler]
		internal void calSrDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.ReportDate = ViewModel.calSrDate.Text;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSenior_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Format Senority Report
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.MaxRows > 4)
			{
				ClearGrid();
			}
			ViewModel.PageNo = 1;
			ViewModel.sprSenior.Row = 1;
			ViewModel.sprSenior.Col = 6;
			ViewModel.sprSenior.Text = "Page " + ViewModel.PageNo.ToString();
			ViewModel.sprSenior.Row = 2;
			ViewModel.sprSenior.Col = 4;
			ViewModel.sprSenior.Text = "Report Calculation Date - " + ViewModel.ReportDate;
			ViewModel.sprSenior.Col = 1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			if ( ViewModel.cboSenior.GetItemData(ViewModel.cboSenior.SelectedIndex) == 1)
			{
				oCmd.CommandText = "spReport_SeniorOp '" + ViewModel.ReportDate + "'";
				ViewModel.sprSenior.Text = "Senority Ranking List - Operations";
			}
			else if ( ViewModel.cboSenior.GetItemData(ViewModel.cboSenior.SelectedIndex) == 2)
			{
				oCmd.CommandText = "spReport_SeniorCiv '" + ViewModel.ReportDate + "'";
				ViewModel.sprSenior.Text = "Civilian";
			}
			else
			{
				oCmd.CommandText = "spReport_SeniorPM '" + ViewModel.ReportDate + "'";
				ViewModel.sprSenior.Text = "Paramedic";
			}
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;
			int RankNo = 1;

			while(!oRec.EOF)
			{
				if ( ViewModel.PageRow == 50)
				{
					DisplayHeadings();
				}
				ViewModel.sprSenior.Row = ViewModel.CurrRow;
				ViewModel.sprSenior.Col = 1;
				ViewModel.sprSenior.Text = RankNo.ToString();
				ViewModel.sprSenior.Col = 2;
				ViewModel.sprSenior.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprSenior.Col = 3;
				ViewModel.sprSenior.Text = modGlobal.Clean(oRec["leave_allowed"]);
				ViewModel.sprSenior.Col = 4;
				ViewModel.sprSenior.Text = modGlobal.Clean(oRec["TFD_hire_date"]);
				ViewModel.sprSenior.Col = 5;
				ViewModel.sprSenior.Text = modGlobal.Clean(oRec["COT_hire_date"]);
				ViewModel.sprSenior.Col = 6;
				ViewModel.sprSenior.Text = modGlobal.Clean(oRec["YearsService"]);
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				RankNo++;
				oRec.MoveNext();
			};
			ViewModel.MaxRows = ViewModel.CurrRow;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Seniority Ranking List

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSenior.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSenior.setPrintAbortMsg("Printing Seniority Ranking List - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSenior.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSenior.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSenior.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSenior.setPrintColor(true);
            //    sprSenior.PrintOrientation = 1
            ViewModel.sprSenior.PrintSheet(null);
			//ViewModel.sprSenior.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.ReportDate = ViewModel.calSrDate.Text;
			ViewModel.MaxRows = 4;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmSrReport DefInstance
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

		public static frmSrReport CreateInstance()
		{
			PTSProject.frmSrReport theInstance = Shared.Container.Resolve< frmSrReport>();
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
			ViewModel.sprSenior.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprSenior.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmSrReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmSrReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmSrReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}