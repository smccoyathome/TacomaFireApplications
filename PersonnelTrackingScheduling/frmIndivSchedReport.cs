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

	public partial class frmIndivSchedReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivSchedReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndivSchedReport));
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


		private void frmIndivSchedReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Text = CurrMonth;
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Text = "Date";
			ViewModel.sprIndiv.Col = 2;
			ViewModel.sprIndiv.Text = "KOT";
			ViewModel.sprIndiv.Col = 3;
			ViewModel.sprIndiv.Text = "Leave";
			ViewModel.sprIndiv.Col = 4;
			ViewModel.sprIndiv.Text = "Pay Upgrade";
			ViewModel.sprIndiv.Col = 5;
			ViewModel.sprIndiv.Text = "Step";
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "Hours";
			ViewModel.sprIndiv.BlockMode = true;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Col2 = 6;
			ViewModel.sprIndiv.Row2 = ViewModel.CurrRow;
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprIndiv.BlockMode = false;
			(ViewModel.CurrRow)++;
		}

		public void LoadList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboNameList.Text = "";
			ViewModel.cboNameList.Items.Clear();

			//Load Employee Name combobox
			oCmd.Connection = modGlobal.oConn;

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				oCmd.CommandText = "spArchiveNameList";
			}
			else
			{
				oCmd.CommandText = "spOpNameList";
			}

			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			while (!oRec.EOF)
			{
				ViewModel.cboNameList.AddItem(Convert.ToString(oRec["name_full"]).Trim() + " - " + Convert.ToString(oRec["employee_id"]));
				oRec.MoveNext();
			}

		}

		public void ClearSpread()
		{
			//Clear SpreadSheet
			ViewModel.sprIndiv.Col = 4;
			ViewModel.sprIndiv.Row = 1;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.Col = 8;
			ViewModel.sprIndiv.Row = 2;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.BlockMode = true;
			//Clear Employee Info
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Col2 = 8;
			ViewModel.sprIndiv.Row = 4;
			ViewModel.sprIndiv.Row2 = 5;
			ViewModel.sprIndiv.Text = "";

			//Clear Leave Info
			//    sprIndiv.Col2 = 6
			ViewModel.sprIndiv.Row = 9;
			ViewModel.sprIndiv.Row2 = ViewModel.LastRow;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.WHITE;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;

			//Clear Debit Info
			//    sprIndiv.Col = 7
			//    sprIndiv.Col2 = 8
			//    sprIndiv.Row = 9
			//    sprIndiv.Row2 = 19
			//    sprIndiv.Text = ""
			//    sprIndiv.CellBorderColor = WHITE
			//    sprIndiv.CellBorderStyle = 6
			//    sprIndiv.CellBorderType = 0
			//    sprIndiv.Action = 16

			//Clear Summary Info
			//    sprIndiv.Col = 7
			//    sprIndiv.Col2 = 8
			//    sprIndiv.Row = 22
			//    sprIndiv.Row2 = 24
			//    sprIndiv.Text = ""
			ViewModel.sprIndiv.BlockMode = false;

		}

		public void FillSpread()
		{
			//Fill Spread Control with data for selected employee

			if ( ViewModel.cboNameList.SelectedIndex < 0)
			{
				return;
			}

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string AssType = "";
			string NewTCLine = "";

			ClearSpread();
			//Come Here - for employee id change
			string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			//    Empid = "04276"
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
				AssType = Convert.ToString(oRec["assignment_type_code"]).Trim();
				ViewModel.sprIndiv.Row = 2;
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = DateTime.Now.ToString("M/d/yyyy");
				ViewModel.sprIndiv.Row = 4;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["name_full"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["employee_id"]);
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["address_full"]);
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["city"]);
				ViewModel.sprIndiv.Col = 7;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["zip_code"]);
				ViewModel.sprIndiv.Row = 5;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["job_title"]);
				ViewModel.sprIndiv.Col = 3;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["unit_code"]);
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["position_code"]);
				ViewModel.sprIndiv.Col = 5;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_code"]);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (!Convert.IsDBNull(oRec["debit_group_code"]))
				{
					ViewModel.sprIndiv.Col = 6;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["debit_group_code"]);
				}
			}
			else
			{
				ViewManager.ShowMessage("No Record for This Employee", "Individual Leave Report Lookup Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			oCmd.CommandText = "spReport_IndYearSched '" + Empid + "','" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 5;
			string TCLine = "";
			float TotalHours = 0;
			string CurrDate = "";
			string CurrMonth = "";


			while(!oRec.EOF)
			{
				if (CurrMonth != Convert.ToString(oRec["schedule_month"]))
				{
					if (CurrDate != "")
					{
						ViewModel.sprIndiv.Col = 6;
						ViewModel.sprIndiv.Row = ViewModel.CurrRow;
						ViewModel.sprIndiv.Text = TotalHours.ToString();
						TotalHours = 0;
						(ViewModel.CurrRow)++;
					}
					MonthHeader(Convert.ToString(oRec["schedule_month"]));
					ViewModel.sprIndiv.Row = ViewModel.CurrRow;
					ViewModel.sprIndiv.Col = 1;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["schedule_date"]);
					ViewModel.sprIndiv.Col = 2;
					ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["sched_time"]);
					ViewModel.sprIndiv.Col = 3;
					//UPGRADE_WARNING: (1068) GetVal(oRec(sick_leave_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["sick_leave_flag"])) == 0)
					{
						ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]) + "*";
					}
					//            sprIndiv.Text = Clean(oRec("leave_time"])
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["pay_upgrade"]))
					{
						if (Convert.ToBoolean(oRec["pay_upgrade"]))
						{
							ViewModel.sprIndiv.Col = 4;
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["job_code_id"]);
							ViewModel.sprIndiv.Col = 5;
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["step"]);
						}
					}
					TotalHours = 12;
					TCLine = modGlobal.Clean(oRec["sched_time"]) + modGlobal.Clean(oRec["leave_time"]) + Convert.ToString(oRec["pay_upgrade"]) + modGlobal.Clean(oRec["job_code_id"]) + modGlobal.Clean(oRec["step"]);
					CurrDate = Convert.ToString(oRec["schedule_date"]);
					CurrMonth = Convert.ToString(oRec["schedule_month"]);

				}
				else if (CurrDate == Convert.ToString(oRec["schedule_date"]))
				{
					NewTCLine = modGlobal.Clean(oRec["sched_time"]) + modGlobal.Clean(oRec["leave_time"]) + Convert.ToString(oRec["pay_upgrade"]) + modGlobal.Clean(oRec["job_code_id"]) + modGlobal.Clean(oRec["step"]);
					if (NewTCLine == TCLine)
					{
						TotalHours += 12;
					}
					else
					{
						ViewModel.sprIndiv.Col = 6;
						ViewModel.sprIndiv.Row = ViewModel.CurrRow;
						ViewModel.sprIndiv.Text = TotalHours.ToString();
						TotalHours = 0;
						(ViewModel.CurrRow)++;
						ViewModel.sprIndiv.Row = ViewModel.CurrRow;
						ViewModel.sprIndiv.Col = 1;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["schedule_date"]);
						ViewModel.sprIndiv.Col = 2;
						ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["sched_time"]);
						ViewModel.sprIndiv.Col = 3;
						//UPGRADE_WARNING: (1068) GetVal(oRec(sick_leave_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["sick_leave_flag"])) == 0)
						{
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]);
						}
						else
						{
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]) + "*";
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["pay_upgrade"]))
						{
							if (Convert.ToBoolean(oRec["pay_upgrade"]))
							{
								ViewModel.sprIndiv.Col = 4;
								ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["job_code_id"]);
								ViewModel.sprIndiv.Col = 5;
								ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["step"]);
							}
						}
						TotalHours = 12;
						TCLine = modGlobal.Clean(oRec["sched_time"]) + modGlobal.Clean(oRec["leave_time"]) + Convert.ToString(oRec["pay_upgrade"]) + modGlobal.Clean(oRec["job_code_id"]) + modGlobal.Clean(oRec["step"]);
					}
				}
				else
				{
					if (CurrDate != "")
					{
						ViewModel.sprIndiv.Col = 6;
						ViewModel.sprIndiv.Row = ViewModel.CurrRow;
						ViewModel.sprIndiv.Text = TotalHours.ToString();
						TotalHours = 0;
						(ViewModel.CurrRow)++;
					}
					ViewModel.sprIndiv.Row = ViewModel.CurrRow;
					ViewModel.sprIndiv.Col = 1;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["schedule_date"]);
					ViewModel.sprIndiv.Col = 2;
					ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["sched_time"]);
					ViewModel.sprIndiv.Col = 3;
					//UPGRADE_WARNING: (1068) GetVal(oRec(sick_leave_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["sick_leave_flag"])) == 0)
					{
						ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]);
					}
					else
					{
						ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["leave_time"]) + "*";
					}
					//            sprIndiv.Text = Clean(oRec("leave_time"])
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["pay_upgrade"]))
					{
						if (Convert.ToBoolean(oRec["pay_upgrade"]))
						{
							ViewModel.sprIndiv.Col = 4;
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["job_code_id"]);
							ViewModel.sprIndiv.Col = 5;
							ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["step"]);
						}
					}
					TotalHours = 12;
					TCLine = modGlobal.Clean(oRec["sched_time"]) + modGlobal.Clean(oRec["leave_time"]) + Convert.ToString(oRec["pay_upgrade"]) + modGlobal.Clean(oRec["job_code_id"]) + modGlobal.Clean(oRec["step"]);
					CurrDate = Convert.ToString(oRec["schedule_date"]);
				}
				oRec.MoveNext();
			};

			//Last record
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = TotalHours.ToString();

			//Leave Totals
			ViewModel.CurrRow += 2;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Text = "Leave/Schedule Totals";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			(ViewModel.CurrRow)++;
			ViewModel.sprIndiv.Row = ViewModel.CurrRow;

			oCmd.CommandText = "spReport_AllLeaveTotals '" + Empid + "', '" + StartDate + "', '" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = ViewModel.CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["time_code_id"]);
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = (Convert.ToDouble(oRec["scheduled_leave"]) / 2d).ToString();
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};
			ViewModel.LastRow = ViewModel.CurrRow;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			ClearSpread();
			FillSpread();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Change report year
			//Refill report with new year
			ViewModel.ReportYear = Convert.ToInt32(Conversion.Val(ViewModel.cboYear.Text));
			ClearSpread();
			FillSpread();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkInactive_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			LoadList();
			ClearSpread();
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
			ViewModel.sprIndiv.setPrintAbortMsg("Printing Individual Schedule Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintBorder(false);
            //    sprIndiv.PrintOrientation = 1
            ViewModel.sprIndiv.PrintSheet(null);
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 13;
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
				ViewModel.cboYear.Text = Conversion.Str(DateTime.Now.Year);
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

		public static frmIndivSchedReport DefInstance
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

		public static frmIndivSchedReport CreateInstance()
		{
			PTSProject.frmIndivSchedReport theInstance = Shared.Container.Resolve< frmIndivSchedReport>();
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

	public partial class frmIndivSchedReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivSchedReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndivSchedReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}