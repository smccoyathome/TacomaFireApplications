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

	public partial class frmPayrollSignOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollSignOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPayrollSignOff));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmPayrollSignOff_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand oCmd3 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "TFD Personnel Payroll Sign Off for " + ViewModel.cboPayPeriod.Text + " ";
			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "";

			if ( ViewModel.optNotSigned.Checked )
			{
				ViewModel.sprReport.Text = "--- Displaying Not Signed Off Only ---";
			}
			else if ( ViewModel.optSigned.Checked )
			{
				ViewModel.sprReport.Text = "--- Displaying Signed Off Only ---";
			}
			else
			{
				ViewModel.sprReport.Text = "--- Displaying Everyone Signed Off/Not Signed Off ---";
			}
			ViewModel.sprEmployeeList.MaxRows = 500;
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;

			oCmd3.Connection = modGlobal.oConn;
			oCmd3.CommandType = CommandType.Text;

			//Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.optEveryone.Checked )
			{
				sStringText = "spReport_PersonnelSignOffForPayperiod ";
			}
			else if ( ViewModel.optSigned.Checked )
			{
				sStringText = "spReport_PersonnelWhoSignOffForPayperiod ";
			}
			else
			{
				sStringText = "spReport_PersonnelNotSignedOffForPayperiod ";
			}

			sStringText = sStringText + modGlobal.Shared.gPayrollYear.ToString() + "," + modGlobal.Shared.gPayPeriod.ToString();

			if ( modGlobal.Clean(ViewModel.CurrBatt) == "" )
			{
				sStringText = sStringText + ", Null";
			}
			else
			{
				sStringText = sStringText + ", '" + modGlobal.Clean(ViewModel.CurrBatt) + "'";
			}

			if ( modGlobal.Clean(ViewModel.CurrShift) == "" )
			{
				sStringText = sStringText + ", Null ";
			}
			else
			{
				sStringText = sStringText + ", '" + modGlobal.Clean(ViewModel.CurrShift) + "' ";
			}

			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;
			int ReportRow = 3;

			while ( !oRec.EOF )
			{
				GridRow++;
				ReportRow++;

				//        sprEmployeeList.MaxRows = GridRow
				ViewModel.sprEmployeeList.Row = GridRow;
				ViewModel.sprReport.Row = ReportRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if ( modGlobal.Clean(oRec["signoff_date"]) == "" )
				{
					ViewModel.sprEmployeeList.Value = 0;
				}
				else
				{
					ViewModel.sprEmployeeList.Value = 1;
				}
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["sap_id"]);
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["sap_id"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprReport.Col = 6;
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if ( modGlobal.Clean(oRec["signoff_date"]) == "" )
				{
					ViewModel.sprEmployeeList.Text = "";
					ViewModel.sprReport.Text = "";
				}
				else
				{
					ViewModel.sprEmployeeList.Text = Convert.ToDateTime(oRec["signoff_date"]).ToString("M/d/yyyy");
					ViewModel.sprReport.Text = Convert.ToDateTime(oRec["signoff_date"]).ToString("M/d/yyyy");
				}

				oRec.MoveNext();
			};

			ReportRow += 3;
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Row = ReportRow;
			ViewModel.sprReport.Text = "Printed on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

			if ( GridRow > 0 )
			{
				ViewModel.sprEmployeeList.MaxRows = GridRow;
			}
			else
			{
				ViewModel.sprEmployeeList.MaxRows = 1;
			}
			ViewModel.lbCount.Text = "List Count: " + GridRow.ToString();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPayPeriod_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Recall start and end dates for Pay Period

			if ( ViewModel.cboPayPeriod.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPPDates " + ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex).ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{
				modGlobal.Shared.gPayPeriod = ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex);
				ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
				ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.CurrStartDate = "";
				ViewModel.CurrEndDate = "";
				ViewManager.ShowMessage("Unable to recall Pay Period Data", "Individual Time Card Reporting", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.cboYear.Text) == modGlobal.Shared.gPayrollYear )
			{
				return ;
			}

			modGlobal.Shared.gPayrollYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while ( !oRec.EOF )
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				oRec.MoveNext();
			};

			modGlobal.Shared.gPayPeriod = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			//    chkNotUploaded.Value = 0
			ViewModel.CurrShift = "";
			ViewModel.CurrBatt = "";
			ViewModel.opt181.Checked = false;
			ViewModel.opt182.Checked = false;
			ViewModel.optAll.Checked = true;
			ViewModel.CurrBatt = "";

			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//    MsgBox "This option is under construction", vbOKOnly, "Print Employee Grid List"
			//Print Employee Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing PTS Payroll Sign Off Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//string strName = "";
			//bool DoThis = false;

			modGlobal.Shared.gPayrollYear = modGlobal.Shared.gCurrentYear;
			ViewModel.FirstTime = true;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + DateTime.Now.ToString("M/d/yyyy") + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
				modGlobal.Shared.gPayPeriod = Convert.ToInt32(oRec["pay_period"]);
			}
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while ( !oRec.EOF )
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				if ( modGlobal.Shared.gPayPeriod == Convert.ToDouble(oRec["pay_period"]) )
				{
					ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
					ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
				}
				oRec.MoveNext();
			};

			if ( modGlobal.Shared.gPayPeriod > 0 )
			{
				for ( int i = 0; i <= ViewModel.cboPayPeriod.Items.Count - 1; i++ )
				{
					if ( ViewModel.cboPayPeriod.GetItemData(i) == modGlobal.Shared.gPayPeriod )
					{
						ViewModel.cboPayPeriod.SelectedIndex = i;
						break;
					}
				}
			}

			oCmd.CommandText = "sp_GetYearList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = modGlobal.Shared.gPayrollYear.ToString();

			FormatReport();
			ViewModel.FirstTime = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "1";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "2";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "3";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "A";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				if ( ViewModel.FirstTime )
				{
					return ;
				}
				if ( ViewModel.optAll.Checked )
				{
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;
				}
				FormatReport();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "B";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "C";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "D";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optEveryone_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optNotSigned_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optSigned_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				FormatReport();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPayrollSignOff DefInstance
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

		public static frmPayrollSignOff CreateInstance()
		{
			PTSProject.frmPayrollSignOff theInstance = Shared.Container.Resolve<frmPayrollSignOff>();
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
			ViewModel.sprReport.LifeCycleStartup();
			ViewModel.sprEmployeeList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPayrollSignOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollSignOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPayrollSignOff m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}