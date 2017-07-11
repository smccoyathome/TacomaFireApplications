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

	public partial class frmDebitReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDebitReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmDebitReport));
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


		private void frmDebitReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*******************************************
		// Debit Day Groups Report
		// Uses vaSpread Control
		//*******************************************
		//ADODB

		public void DisplayHeadings()
		{
			(ViewModel.CurrRow)++;
			ViewModel.sprDebit.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDebit.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDebit.setRowPageBreak(true);
			//    CurrRow = CurrRow + 1
			ViewModel.sprDebit.Row = ViewModel.CurrRow;
			ViewModel.sprDebit.Col = 1;
			ViewModel.sprDebit.Text = "Tacoma Fire Department";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDebit.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprDebit.Row = ViewModel.CurrRow;
			ViewModel.sprDebit.Text = "Debit Day Groups";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDebit.SetRowHeight(ViewModel.CurrRow, 15);
			(ViewModel.CurrRow)++;
			ViewModel.sprDebit.Row = ViewModel.CurrRow;
			ViewModel.sprDebit.Col = 1;
			ViewModel.sprDebit.Text = "Group";
			ViewModel.sprDebit.FontBold = false;
			ViewModel.sprDebit.Col = 2;
			ViewModel.sprDebit.Text = "Unit";
			ViewModel.sprDebit.Col = 3;
			ViewModel.sprDebit.Text = "Position";
			ViewModel.sprDebit.Col = 4;
			ViewModel.sprDebit.Text = "A Shift";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprDebit.Col = 5;
			ViewModel.sprDebit.Text = "B Shift";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprDebit.Col = 6;
			ViewModel.sprDebit.Text = "C Shift";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprDebit.Col = 7;
			ViewModel.sprDebit.Text = "D Shift";
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprDebit.BlockMode = true;
			ViewModel.sprDebit.Col = 1;
			ViewModel.sprDebit.Col2 = 7;
			ViewModel.sprDebit.Row2 = ViewModel.CurrRow;
			//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDebit.FontSize = 12;
			ViewModel.sprDebit.BlockMode = false;
			(ViewModel.CurrRow)++;
		}


		public void FillSpread()
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CurrGroup = 0;
			int ATot = 0, BTot = 0;
			int CTot = 0, DTot = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_DDGroups";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprDebit.Row = 1;
			ViewModel.sprDebit.Col = 7;
			ViewModel.sprDebit.Text = DateTime.Now.ToString("M/d/yyyy HH:mm");
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;

			while(!oRec.EOF)
			{
				if (CurrGroup != Convert.ToDouble(oRec["debit_group"]))
				{
					if (ATot > 0)
					{
						//Group Totals
						ViewModel.sprDebit.Row = ViewModel.CurrRow;
						ViewModel.sprDebit.Col = 2;
						ViewModel.sprDebit.Text = "Group " + CurrGroup.ToString() + " Totals";
						ViewModel.sprDebit.Col = 4;
						ViewModel.sprDebit.Text = ATot.ToString();
						ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						ATot = 0;
						ViewModel.sprDebit.Col = 5;
						ViewModel.sprDebit.Text = BTot.ToString();
						ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						BTot = 0;
						ViewModel.sprDebit.Col = 6;
						ViewModel.sprDebit.Text = CTot.ToString();
						ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						CTot = 0;
						ViewModel.sprDebit.Col = 7;
						ViewModel.sprDebit.Text = DTot.ToString();
						ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
						DTot = 0;
						ViewModel.sprDebit.BlockMode = true;
						ViewModel.sprDebit.Col = 1;
						ViewModel.sprDebit.Col2 = 7;
						ViewModel.sprDebit.Row2 = ViewModel.CurrRow;
						//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
						//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
						ViewModel.sprDebit.BackColor = modGlobal.Shared.LT_GRAY;
						ViewModel.sprDebit.FontBold = true;
						ViewModel.sprDebit.BlockMode = false;
						(ViewModel.CurrRow)++;
						(ViewModel.PageRow)++;
					}
					if (Convert.ToDouble(oRec["debit_group"]) == 5 || Convert.ToDouble(oRec["debit_group"]) == 10)
					{
						DisplayHeadings();
					}
					ViewModel.sprDebit.Row = ViewModel.CurrRow;
					ViewModel.sprDebit.Col = 1;
					ViewModel.sprDebit.Text = Convert.ToString(oRec["debit_group"]);
					ViewModel.sprDebit.BackColor = modGlobal.Shared.LT_GRAY;
					CurrGroup = Convert.ToInt32(oRec["debit_group"]);
				}
				ViewModel.sprDebit.Row = ViewModel.CurrRow;
				ViewModel.sprDebit.Col = 2;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["u_code"]);
				ViewModel.sprDebit.Col = 3;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["p_code"]);
				ViewModel.sprDebit.Col = 4;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["ashift"]);
				if (String.CompareOrdinal(ViewModel.sprDebit.Text, "") > 0)
				{
					ATot++;
				}
				ViewModel.sprDebit.Col = 5;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["bshift"]);
				if (String.CompareOrdinal(ViewModel.sprDebit.Text, "") > 0)
				{
					BTot++;
				}
				ViewModel.sprDebit.Col = 6;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["cshift"]);
				if (String.CompareOrdinal(ViewModel.sprDebit.Text, "") > 0)
				{
					CTot++;
				}
				ViewModel.sprDebit.Col = 7;
				ViewModel.sprDebit.Text = modGlobal.Clean(oRec["dshift"]);
				if (String.CompareOrdinal(ViewModel.sprDebit.Text, "") > 0)
				{
					DTot++;
				}
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				oRec.MoveNext();
			};
			//Group Totals for last Group
			ViewModel.sprDebit.Row = ViewModel.CurrRow;
			ViewModel.sprDebit.Col = 2;
			ViewModel.sprDebit.Text = "Group " + CurrGroup.ToString() + " Totals";
			ViewModel.sprDebit.Col = 4;
			ViewModel.sprDebit.Text = ATot.ToString();
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ATot = 0;
			ViewModel.sprDebit.Col = 5;
			ViewModel.sprDebit.Text = BTot.ToString();
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			BTot = 0;
			ViewModel.sprDebit.Col = 6;
			ViewModel.sprDebit.Text = CTot.ToString();
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			CTot = 0;
			ViewModel.sprDebit.Col = 7;
			ViewModel.sprDebit.Text = DTot.ToString();
			ViewModel.sprDebit.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			DTot = 0;
			ViewModel.sprDebit.BlockMode = true;
			ViewModel.sprDebit.Col = 1;
			ViewModel.sprDebit.Col2 = 7;
			ViewModel.sprDebit.Row2 = ViewModel.CurrRow;
			//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDebit.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprDebit.FontBold = true;
			ViewModel.sprDebit.BlockMode = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Assignment Report to Default Printer

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDebit.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDebit.setPrintAbortMsg("Printing Assignment Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDebit.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDebit.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDebit.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDebit.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprDebit.PrintMarginRight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDebit.setPrintMarginRight(Convert.ToInt32(0.5d));
            //    sprDebit.PrintOrientation = 2
            ViewModel.sprDebit.PrintSheet(null);
            //ViewModel.sprDebit.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillSpread();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmDebitReport DefInstance
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

		public static frmDebitReport CreateInstance()
		{
			PTSProject.frmDebitReport theInstance = Shared.Container.Resolve< frmDebitReport>();
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
			ViewModel.sprDebit.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprDebit.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmDebitReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDebitReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmDebitReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}