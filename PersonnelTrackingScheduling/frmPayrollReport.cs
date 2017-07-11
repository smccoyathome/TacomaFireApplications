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

	public partial class frmPayrollReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPayrollReport));
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


		private void frmPayrollReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FormatReport()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.FontBold = false;
			ViewModel.sprReport.BlockMode = false;

			int tempForVar = ViewModel.sprReport.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprReport.SetCellBorder(5, i, 5, i, 0, UpgradeHelpers.Helpers.Color.Empty, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleDefault);
			}
			ViewModel.sprReport.MaxRows = 5000;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string SqlString = "spReport_PayrollFilterReport '" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "',";
			if ( ViewModel.CurrBatt == "")
			{
				SqlString = SqlString + " Null,";
			}
			else
			{
				SqlString = SqlString + "'" + ViewModel.CurrBatt + "',";
			}
			if ( ViewModel.CurrShift == "")
			{
				SqlString = SqlString + " Null ";
			}
			else
			{
				SqlString = SqlString + "'" + ViewModel.CurrShift + "' ";
			}
			oCmd.CommandText = SqlString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int CurrRow = 1;
			int LineCount = 0;
			int CurrEmployee = 0;
			float TotalHours = 0;
			float GrandTotalHrs = 0;


			while(!oRec.EOF)
			{

				//UPGRADE_WARNING: (1068) GetVal(oRec(EmployeeID)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (CurrEmployee != Convert.ToDouble(modGlobal.GetVal(oRec["EmployeeID"])))
				{
					if (TotalHours != 0)
					{
						ViewModel.sprReport.Row = CurrRow;
						ViewModel.sprReport.Col = 5;
						ViewModel.sprReport.FontBold = true;
						ViewModel.sprReport.Text = Math.Round((double) TotalHours, 2).ToString();

						GrandTotalHrs += TotalHours;
						//add logic to display last employee's total hours
						TotalHours = 0;

						if (LineCount < 2)
						{
							CurrRow++;
						}

					}

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					CurrEmployee = Convert.ToInt32(modGlobal.GetVal(oRec["EmployeeID"]));
					CurrRow += 2;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.FontBold = true;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(oRec["EmployeeID"]));
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["EmployeeName"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Payroll Date";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "A/A Type";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Hours";
					ViewModel.sprReport.Col = 6;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "PS Group";
					ViewModel.sprReport.Col = 7;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Level";
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Activity";
					ViewModel.sprReport.Col = 9;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Order";
					ViewModel.sprReport.Col = 10;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "WBS Element";
					ViewModel.sprReport.Col = 11;
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.Text = "Cost Center";
					ViewModel.sprReport.Row = CurrRow + 1;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.FontBold = false;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.FontBold = false;
					//UPGRADE_WARNING: (1068) GetVal(oRec(step)) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprReport.Text = "PS Group / Step: " + modGlobal.Clean(oRec["job_code_id"]) + " / " + Convert.ToString(modGlobal.GetVal(oRec["step"]));
					ViewModel.sprReport.Row = CurrRow + 2;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.FontBold = false;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.FontBold = false;
					ViewModel.sprReport.Text = "Unit / Shift: " + modGlobal.Clean(oRec["unit_code"]) + " / " + modGlobal.Clean(oRec["shift_code"]);

					TotalHours = 0;
					LineCount = 1;
					CurrRow++;
				}
				LineCount++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = Convert.ToDateTime(oRec["PayrollDate"]).ToString("MM/dd/yyyy");
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["AAType"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = Math.Round((double) Convert.ToDouble(oRec["Hours"]), 2).ToString();
				TotalHours = (float) (TotalHours + Math.Round((double) Convert.ToDouble(oRec["Hours"]), 2));
				ViewModel.sprReport.Col = 6;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["PSGroup"]);
				ViewModel.sprReport.Col = 7;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["Level"]);
				ViewModel.sprReport.Col = 8;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["Activity"]);
				ViewModel.sprReport.Col = 9;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["Order"]);
				ViewModel.sprReport.Col = 10;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["WBSElement"]);
				ViewModel.sprReport.Col = 11;
				ViewModel.sprReport.FontBold = false;
				ViewModel.sprReport.Text = modGlobal.Clean(oRec["CostCenter"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Col2 = 11;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Row2 = CurrRow;
				ViewModel.sprReport.BlockMode = true;

				if (modGlobal.Clean(oRec["StatusCode"]) == "S")
				{
				}
				else if (modGlobal.Clean(oRec["StatusCode"]) == "D")
				{
				}
				else if (modGlobal.Clean(oRec["StatusCode"]) == "N")
				{
				}
				else
				{
					//Payroll Record Failed
					;
				}
				ViewModel.sprReport.BlockMode = false;
				CurrRow++;
				oRec.MoveNext();
			};
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.FontBold = true;
			ViewModel.sprReport.Text = Math.Round((double) TotalHours, 2).ToString();

			CurrRow += 3;
			ViewModel.sprReport.Row = CurrRow;
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.FontBold = true;
			ViewModel.sprReport.Text = "Total Hours Entered:  ";
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.FontBold = true;
			ViewModel.sprReport.Text = Math.Round((double) GrandTotalHrs, 2).ToString();
			ViewModel.sprReport.MaxRows = CurrRow;

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

			if ( ViewModel.cboPayPeriod.SelectedIndex < 0)
			{
				return;
			} //no selection

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPPDates " + ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex).ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				modGlobal.Shared.gPayPeriod = ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex);
				ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
				ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Row = 1;
				ViewModel.sprReport.Text = "Payroll Payperiod Report For " + ViewModel.CurrStartDate + " To " + DateTime.Parse(ViewModel.CurrEndDate).AddDays(-1).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.CurrStartDate = "";
				ViewModel.CurrEndDate = "";
				ViewManager.ShowMessage("Unable to recall Pay Period Data", "Individual Time Card Reporting", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return;
			}
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.cboYear.Text) == modGlobal.Shared.gPayrollYear)
			{
				return;
			}

			modGlobal.Shared.gPayrollYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
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

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing PTS/SAP Payroll Audit Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintJobName was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintJobName("PTS SAP Payroll Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintMarginLeft(360);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//Mobilize: Not supported: sprReport.setPrintOrientation(FPSpreadADO.PrintOrientationConstants.PrintOrientationLandscape);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);
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
			if (!oRec.EOF)
			{
				modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
				modGlobal.Shared.gPayPeriod = Convert.ToInt32(oRec["pay_period"]);
			}
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				if (modGlobal.Shared.gPayPeriod == Convert.ToDouble(oRec["pay_period"]))
				{
					ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
					ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Row = 1;
					ViewModel.sprReport.Text = "Payroll Payperiod Report For " + ViewModel.CurrStartDate + " To " + DateTime.Parse(ViewModel.CurrEndDate).AddDays(-1).ToString("M/d/yyyy");
				}
				oRec.MoveNext();
			};

			if (modGlobal.Shared.gPayPeriod > 0)
			{
				for (int i = 0; i <= ViewModel.cboPayPeriod.Items.Count - 1; i++)
				{
					if ( ViewModel.cboPayPeriod.GetItemData(i) == modGlobal.Shared.gPayPeriod)
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

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = modGlobal.Shared.gPayrollYear.ToString();
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Text = "Payroll Payperiod Report For " + ViewModel.CurrStartDate + " To " + DateTime.Parse(ViewModel.CurrEndDate).AddDays(-1).ToString("M/d/yyyy");

			FormatReport();
			ViewModel.FirstTime = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrBatt = "1";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrBatt = "2";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrBatt = "3";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrShift = "A";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.optAll.Checked)
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
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrShift = "B";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrShift = "C";
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrShift = "D";
				FormatReport();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPayrollReport DefInstance
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

		public static frmPayrollReport CreateInstance()
		{
			PTSProject.frmPayrollReport theInstance = Shared.Container.Resolve< frmPayrollReport>();
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
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPayrollReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPayrollReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}