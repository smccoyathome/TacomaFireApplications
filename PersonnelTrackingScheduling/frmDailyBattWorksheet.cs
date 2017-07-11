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

	public partial class frmDailyBattWorksheet
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailyBattWorksheetViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmDailyBattWorksheet));
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


		private void frmDailyBattWorksheet_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**************************************
		//* Battalion Daily Schedule Worksheet *
		//**************************************
		//ADODB

		public void ClearSpread()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrUnit = "";
			int CurrRow = 0;
			int CurrCol = 0;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.RemoveCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.RemoveCellSpan(0, 0);
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.FontBold = false;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "spSelect_BattalionUnitGridByBattCode " + ViewModel.CurrBatt;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{

				CurrUnit = Convert.ToString(oRec["unit_code"]);
				CurrRow = Convert.ToInt32(oRec["title_row_loc"]);
				CurrCol = Convert.ToInt32(oRec["start_col_loc"]);

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprReport.AddCellSpan(CurrCol, CurrRow, 5, 1);
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = CurrCol;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.Text = CurrUnit;

				oRec.MoveNext();
			};
			ViewModel.sprReport.Row = 33;
			ViewModel.sprReport.Col = 21;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprReport.FontBold = true;
			ViewModel.sprReport.Text = "Notes";


		}

		public void FillSpread()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string Note2 = "", Note1 = "", NoteChar = "";


			ClearSpread();

			string CurrUnit = "";
			int CurrRow = 0;
			int CurrCol = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "spReport_BattalionUnitSchedule '" + ViewModel.CurrDate + "', '" + ViewModel.CurrBatt + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				if (CurrUnit == "")
				{ //First Record
					CurrUnit = Convert.ToString(oRec["unit_code"]);

					CurrRow = Convert.ToInt32(Convert.ToDouble(oRec["title_row_loc"]) + 1);
					CurrCol = Convert.ToInt32(oRec["start_col_loc"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = CurrCol;
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_last"]) + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length));


				}
				else if (CurrUnit == Convert.ToString(oRec["unit_code"]))
				{  //Remain int the same box

					CurrRow++;
					CurrCol = Convert.ToInt32(oRec["start_col_loc"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = CurrCol;
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_last"]) + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length));
				}
				else
				{

					CurrUnit = Convert.ToString(oRec["unit_code"]);

					CurrRow = Convert.ToInt32(Convert.ToDouble(oRec["title_row_loc"]) + 1);
					CurrCol = Convert.ToInt32(oRec["start_col_loc"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = CurrCol;
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["name_last"]) + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length));

				}
				CurrCol++;
				ViewModel.sprReport.Col = CurrCol;

				if (modGlobal.Clean(oRec["LeaveKOT"]) == "")
				{
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["TimeCode"]);
					if (modGlobal.Clean(oRec["TimeCode"]) == "DDF")
					{
						ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CDEBIT);
					}
					else if (modGlobal.Clean(oRec["TimeCode"]) == "TRD")
					{
						ViewModel.sprReport.BackColor = modGlobal.Shared.GREEN;
					}
					else if (modGlobal.Clean(oRec["TimeCode"]) == "OTP")
					{
						ViewModel.sprReport.BackColor = modGlobal.Shared.RED;
					}
					else
					{
						ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
					}
				}
				else
				{
					//logic for Leave
					if (modGlobal.Clean(oRec["LeaveKOT"]) != "TRD")
					{
						ViewModel.sprReport.Text = modGlobal.Clean(oRec["LeaveKOT"]);
						if (Convert.ToString(oRec["LeaveKOT"]).StartsWith("VAC") || Convert.ToString(oRec["LeaveKOT"]).StartsWith("PTO"))
						{
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CVACATION);
						}
						else if (Convert.ToString(oRec["LeaveKOT"]).StartsWith("FHL"))
						{
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CHOLIDAY);
						}
						else if (Convert.ToString(oRec["LeaveKOT"]).StartsWith("KEL"))
						{
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CKELLY);
						}
						else if (Convert.ToString(oRec["LeaveKOT"]).StartsWith("MIL"))
						{
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CMILITARY);
						}
						else
						{
							ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.COTHER);
						}
					}
					else
					{
						ViewModel.sprReport.Text = modGlobal.Clean(oRec["TimeCode"]);
						ViewModel.sprReport.Col = CurrCol + 2;
						ViewModel.sprReport.Text = modGlobal.Clean(oRec["LeaveKOT"]);
						ViewModel.sprReport.BackColor = modGlobal.Shared.GREEN;
					}
					if (modGlobal.Clean(oRec["TimeCode"]) == "DDF" && modGlobal.Clean(oRec["LeaveKOT"]) != "TRD")
					{
						ViewModel.sprReport.Col = CurrCol + 2;
						ViewModel.sprReport.Text = modGlobal.Clean(oRec["TimeCode"]);
						ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.CDEBIT);
					}
				}

				CurrCol++;
				ViewModel.sprReport.Col = CurrCol;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["shift"])) == 1)
				{
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["shift"]);
				}
				else
				{
					ViewModel.sprReport.Text = ".5";
				}

				CurrCol++;
				ViewModel.sprReport.Col = CurrCol;
				if (Convert.ToBoolean(oRec["pay_upgrade"]))
				{
					ViewModel.sprReport.Text = modGlobal.Clean(oRec["job_code_id"]);
					ViewModel.sprReport.Col = CurrCol + 1;
					ViewModel.sprReport.Text = Convert.ToString(oRec["step"]);
				}

				oRec.MoveNext();
			};

			//Retrieve Notes
			oCmd.CommandText = "spReport_GetBattNote '" + ViewModel.CurrDate + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(ViewModel.CurrDate).AddDays(1)) + "','1'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			int x = 34;
			ViewModel.sprReport.Col = 21;

			while(!oRec.EOF)
			{
				Note1 = Convert.ToString(oRec["note"]).Trim();
				for (int L = 1; L <= Strings.Len(Note1); L++)
				{
					NoteChar = Note1.Substring(L - 1, Math.Min(1, Note1.Length - (L - 1)));
					if (Strings.Asc(NoteChar[0]) == 13)
					{
						NoteChar = " ";
						Note2 = Note2 + NoteChar;
						ViewModel.sprReport.Row = x;
						ViewModel.sprReport.Text = Note2;
						Note2 = "";
						x++;
						L++;
					}
					else if (Strings.Len(Note2) > 27 && NoteChar == " ")
					{
						ViewModel.sprReport.Row = x;
						ViewModel.sprReport.Text = Note2;
						Note2 = "";
						x++;
					}
					else if (Strings.Len(Note2) > 34)
					{
						Note2 = Note2 + NoteChar;
						ViewModel.sprReport.Row = x;
						ViewModel.sprReport.Text = Note2;
						Note2 = "";
						x++;
					}
					else
					{
						Note2 = Note2 + NoteChar;
					}
					if (x > 42)
					{
						if (Strings.Len(Note1.Substring(Math.Max(Note1.Length - (Strings.Len(Note1) - L), 0))) > 1)
						{
							ViewModel.sprReport.Col = 24;
							ViewModel.sprReport.Text = "More...";
							break;
						}
					}
				}
				if (x > 42)
				{
					break;
				}
				ViewModel.sprReport.Row = x;
				ViewModel.sprReport.Text = Note2;
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
			ViewModel.sprReport.Col = 21;
			ViewModel.sprReport.Row = 43;
			ViewModel.sprReport.Text = "Printed " + DateTime.Now.ToString("M/d/yy HH:mm");

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Battalion Schedule Workseet - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintGrid was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintGrid(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);
			//    sprReport.PrintUseDataMax = True
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (!Information.IsDate(ViewModel.dtReportDate.Text))
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ShiftDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("M/d/yyyy") + " 7:00AM";
			ViewModel.CurrDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("M/d/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "sp_GetShift '" + ViewModel.ShiftDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.sprReport.Row = 2;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = "Battalion " + ViewModel.CurrBatt + " Daily Worksheet for " + ViewModel.CurrDate;
				ViewModel.sprReport.Col = 11;
				ViewModel.sprReport.Text = "Shift " + Convert.ToString(oRec["shift_code"]).Trim();
				ViewModel.sprReport.Col = 16;
				ViewModel.sprReport.Text = "Debit Group " + Convert.ToString(oRec["debit_group_code"]).Trim();

			}
			FillSpread();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (!Information.IsDate(ViewModel.dtReportDate.Text))
			{
				return;
			}
			if ( ViewModel.FirstTime != 0)
			{
				return;
			}
			ViewModel.ShiftDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("M/d/yyyy") + " 7:00AM";
			ViewModel.CurrDate = DateTime.Parse(ViewModel.dtReportDate.Text).ToString("M/d/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "sp_GetShift '" + ViewModel.ShiftDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.sprReport.Row = 2;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = "Battalion " + ViewModel.CurrBatt + " Daily Worksheet for " + ViewModel.CurrDate;
				ViewModel.sprReport.Col = 11;
				ViewModel.sprReport.Text = "Shift " + Convert.ToString(oRec["shift_code"]).Trim();
				ViewModel.sprReport.Col = 16;
				ViewModel.sprReport.Text = "Debit Group " + Convert.ToString(oRec["debit_group_code"]).Trim();

			}
			FillSpread();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (!Information.IsDate(modGlobal.Shared.gBattSwitchDate))
			{
				ViewModel.ShiftDate = DateTime.Now.ToString("M/d/yyyy") + " 7:00AM";
				ViewModel.CurrDate = DateTime.Now.ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.dtReportDate.Text = modGlobal.Shared.gBattSwitchDate;
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.ShiftDate = ((DateTime.TryParse(modGlobal.Shared.gBattSwitchDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Shared.gBattSwitchDate) + " 7:00AM";
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.CurrDate = (DateTime.TryParse(modGlobal.Shared.gBattSwitchDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : modGlobal.Shared.gBattSwitchDate;
			}

			if (modGlobal.Clean(modGlobal.Shared.gBatt) == "")
			{
				ViewModel.CurrBatt = "1";
				ViewModel.optBatt1.Checked = true;
			}
			else
			{
				ViewModel.CurrBatt = modGlobal.Shared.gBatt;
				if (modGlobal.Shared.gBatt == "1")
				{
					ViewModel.optBatt1.Checked = true;
				}
				else
				{
					ViewModel.optBatt2.Checked = true;
				}
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Get Shift for this Date
			oCmd.CommandText = "sp_GetShift '" + ViewModel.ShiftDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.sprReport.Row = 2;
				ViewModel.sprReport.Col = 1;
				System.DateTime TempDate3 = DateTime.FromOADate(0);
				ViewModel.sprReport.Text = "Battalion " + ViewModel.CurrBatt + " Daily Worksheet for " + ((DateTime.TryParse(
						ViewModel.CurrDate, out TempDate3)) ? TempDate3.ToString("M/d/yyyy") : ViewModel.CurrDate);
				ViewModel.sprReport.Col = 11;
				ViewModel.sprReport.Text = "Shift " + Convert.ToString(oRec["shift_code"]).Trim();
				ViewModel.sprReport.Col = 16;
				ViewModel.sprReport.Text = "Debit Group " + Convert.ToString(oRec["debit_group_code"]).Trim();

			}
			ViewModel.FirstTime = -1;
			FillSpread();
			ViewModel.FirstTime = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void optBatt1_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime != 0)
				{
					return;
				}
				if ( ViewModel.optBatt1.Checked)
				{
					ViewModel.CurrBatt = "1";
				}
				FillSpread();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optBatt2_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime != 0)
				{
					return;
				}
				if ( ViewModel.optBatt2.Checked)
				{
					ViewModel.CurrBatt = "2";
				}
				FillSpread();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmDailyBattWorksheet DefInstance
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

		public static frmDailyBattWorksheet CreateInstance()
		{
			PTSProject.frmDailyBattWorksheet theInstance = Shared.Container.Resolve< frmDailyBattWorksheet>();
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

	public partial class frmDailyBattWorksheet
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailyBattWorksheetViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmDailyBattWorksheet m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}