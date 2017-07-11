using Microsoft.VisualBasic;
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

	public partial class frmIndAnnualPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndAnnualPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndAnnualPayroll));
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


		private void frmIndAnnualPayroll_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************
		//* Individual Leave Report      *
		//********************************
		//ADODB

		public void MonthHeader(string CurrMonth)
		{
			ViewModel.CurrRow += 2;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = CurrMonth;
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Payroll Date";
			ViewModel.sprIndiv.Col = 2;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "A/A Type";
			ViewModel.sprIndiv.Col = 3;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "PS Goup";
			ViewModel.sprIndiv.Col = 4;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Level";
			ViewModel.sprIndiv.Col = 5;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Hours";
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Status";
			ViewModel.sprIndiv.Col = 7;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Approved by";
			ViewModel.sprIndiv.Col = 8;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Approved On";
			(ViewModel.CurrRow)++;

		}

		public void ClearSpread()
		{
			ViewModel.sprIndiv.BlockMode = true;
			//Clear Employee Info
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Col2 = ViewModel.sprIndiv.MaxCols;
			ViewModel.sprIndiv.Row = 4;
			ViewModel.sprIndiv.Row2 = ViewModel.sprIndiv.MaxRows;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.FontBold = false;
			ViewModel.sprIndiv.BlockMode = false;
			ViewModel.sprIndiv.MaxRows = 500;

		}

		public void FillSpread()
		{
			//Fill Spread Control with data for selected employee

			if ( ViewModel.cboNameList.SelectedIndex < 0)
			{
				return;
			}

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			ClearSpread();
			//Come Here - for employee id change
			string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			string StartDate = "1/1/" + ViewModel.ReportYear.ToString();
			string EndDate = DateTime.Parse(StartDate).AddYears(1).ToString("M/d/yyyy");
			ViewModel.sprIndiv.Row = 1;
			ViewModel.sprIndiv.Col = 4;
			ViewModel.sprIndiv.Text = ViewModel.ReportYear.ToString();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Employee '" + Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = 2;
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = DateTime.Now.ToString("M/d/yyyy");
				ViewModel.sprIndiv.Row = 4;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["name_full"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["employee_id"]);
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["address_full"]).TrimEnd() + "  " +
										modGlobal.Clean(oRec["city"]).TrimEnd() + "   " + modGlobal.Clean(oRec["zip_code"]).TrimEnd();
				ViewModel.sprIndiv.Row = 5;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["job_title"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["unit_code"]);
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["position_code"]);
				ViewModel.sprIndiv.Col = 5;
				ViewModel.sprIndiv.FontBold = true;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_code"]);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (!Convert.IsDBNull(oRec["debit_group_code"]))
				{
					ViewModel.sprIndiv.Col = 6;
					ViewModel.sprIndiv.FontBold = true;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["debit_group_code"]);
				}
			}
			else
			{
				ViewManager.ShowMessage("No Record for This Employee", "Individual Leave Report Lookup Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			oCmd.CommandText = "spReport_IndYearPayroll '" + Empid + "', " + ViewModel.ReportYear.ToString() + " ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 5;
			string CurrDate = "";
			string CurrMonth = "";


			while(!oRec.EOF)
			{
				if (CurrMonth != Convert.ToString(oRec["payroll_month"]))
				{
					MonthHeader(Convert.ToString(oRec["payroll_month"]));
				}
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToDateTime(oRec["payroll_date"]).ToString("MM/dd/yyyy");
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["a_a_type"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["exception_job_code"]);
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["exception_step"]);
				ViewModel.sprIndiv.Col = 5;
				ViewModel.sprIndiv.Text = Math.Round((double) Convert.ToDouble(oRec["hours"]), 2).ToString();
				//        TotalHours = TotalHours + Round(CDbl(orec("hours"]), 2)
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["payroll_status_code"]);
				ViewModel.sprIndiv.Col = 7;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["approved_by"]);
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = Convert.ToDateTime(oRec["last_update_date"]).ToString("MM/dd/yyyy");
				CurrDate = Convert.ToString(oRec["payroll_date"]);
				CurrMonth = Convert.ToString(oRec["payroll_month"]);
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};

			//Leave Totals
			ViewModel.CurrRow += 2;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.FontBold = true;
			ViewModel.sprIndiv.Text = "Leave Totals";
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;

			oCmd.CommandText = "spReport_AllPayrollTotals '" + Empid + "', " + ViewModel.ReportYear.ToString() + " ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["a_a_type"]);
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = Math.Round((double) Convert.ToDouble(oRec["scheduled_leave"]), 2).ToString();
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			ViewModel.LastRow = ViewModel.CurrRow;
			ViewModel.sprIndiv.MaxRows = ViewModel.CurrRow;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FillSpread();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Change report year
			//Refill report with new year
			ViewModel.ReportYear = Convert.ToInt32(Conversion.Val(ViewModel.cboYear.Text));
			FillSpread();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintAbortMsg("Printing Individual Annual Payroll Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintJobName was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintJobName("PTS Individual Payroll Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintMarginLeft(360);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//Mobilize: Not supported: sprIndiv.setPrintOrientation(FPSpreadADO.PrintOrientationConstants.PrintOrientationPortrait);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprIndiv.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprIndiv.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Create Form Level RDO Connection object
			//Fill Spreadsheet with Requested Data

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			string Empid = "";
			//int CleanOpen = 0;

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
			ViewModel.LastRow = 10;


			oCmd.CommandText = "spOpNameList";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (modGlobal.Shared.gSecurity != "RO" && modGlobal.Shared.gSecurity != "CPT")
			{

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					this.ViewModel.cboNameList.AddItem(strName);
					oRec.MoveNext();
				};
			}
			else
			{
				strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
				this.ViewModel.cboNameList.AddItem(strName);
			}

			if (modGlobal.Shared.gReportYear != 0)
			{
				ViewModel.ReportYear = modGlobal.Shared.gReportYear;
				ViewModel.cboYear.Text = Conversion.Str(ViewModel.ReportYear);
			}
			else
			{
				//  Add logic to get current Payroll Calendar Year
				oCmd.CommandText = "spSelect_PayrollYearForToday ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.ReportYear = Convert.ToInt32(Double.Parse(Convert.ToString(oRec["calendar_year"]).Trim()));
				ViewModel.cboYear.Text = Conversion.Str(ViewModel.ReportYear);
			}

			if (modGlobal.Shared.gReportUser != "")
			{
				Empid = modGlobal.Shared.gReportUser;
				modGlobal.Shared.gReportUser = "";
				for (int x = 0; x <= ViewModel.cboNameList.Items.Count - 1; x++)
				{
					//Come Here - for employee id change
					if (Empid == ViewModel.cboNameList.GetListItem(x).Substring(Math.Max(ViewModel.cboNameList.GetListItem(x).Length - 5, 0)))
					{
						//Setting List Index will trigger list click event
						//This event will call FillSpread subroutine
						ViewModel.cboNameList.SelectedIndex = x;
						break;
					}
				}
			}


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//Clear Global ReportYear variable
			modGlobal
				.Shared.gReportYear = 0;
		}

		public static frmIndAnnualPayroll DefInstance
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

		public static frmIndAnnualPayroll CreateInstance()
		{
			PTSProject.frmIndAnnualPayroll theInstance = Shared.Container.Resolve< frmIndAnnualPayroll>();
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
			ViewModel.sprIndiv.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprIndiv.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmIndAnnualPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndAnnualPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndAnnualPayroll m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}