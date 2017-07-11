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

	public partial class frmAnnualLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAnnualLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAnnualLeave));
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


		private void frmAnnualLeave_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*******************************************
		// Annual Leave Report
		// Uses vaSpread Control
		//*******************************************
		//ADODB

		public void ClearGrid()
		{
			//Clear LeaveDays and Color Formatting from Grid
			ViewModel.sprAnnual.BlockMode = true;
			ViewModel.sprAnnual.Col = 3;
			ViewModel.sprAnnual.Col2 = 3;
			ViewModel.sprAnnual.Row = 4;
			ViewModel.sprAnnual.Row2 = 65;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 6;
			ViewModel.sprAnnual.Col2 = 6;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 9;
			ViewModel.sprAnnual.Col2 = 9;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 12;
			ViewModel.sprAnnual.Col2 = 12;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 15;
			ViewModel.sprAnnual.Col2 = 15;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 18;
			ViewModel.sprAnnual.Col2 = 18;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 21;
			ViewModel.sprAnnual.Col2 = 21;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 24;
			ViewModel.sprAnnual.Col2 = 24;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 27;
			ViewModel.sprAnnual.Col2 = 27;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 30;
			ViewModel.sprAnnual.Col2 = 30;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 33;
			ViewModel.sprAnnual.Col2 = 33;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.Col = 36;
			ViewModel.sprAnnual.Col2 = 36;
			ViewModel.sprAnnual.Text = "";
			ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAnnual.BlockMode = false;

			if ( ViewModel.OldCol != 0)
			{
				ViewModel.sprAnnual.Col = ViewModel.OldCol;
				ViewModel.sprAnnual.Row = ViewModel.OldRow;
				if ( ViewModel.OldAMPM == "AM")
				{
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
				}
				else
				{
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.GRAY;
				}
			}
			ViewModel.OldCol = 0;
			ViewModel.OldRow = 0;
			ViewModel.OldAMPM = "";
			ViewModel.SelectedDate = "";
			//Check Leap Year
			if (Information.IsDate("2/29/" + ViewModel.ReportYear))
			{
				ViewModel.sprAnnual.Col = 4;
				ViewModel.sprAnnual.Row = 60;
				ViewModel.sprAnnual.Text = "29";
				ViewModel.sprAnnual.Col = 5;
				ViewModel.sprAnnual.Text = "AM";
				ViewModel.sprAnnual.Row = 61;
				ViewModel.sprAnnual.Text = "PM";
			}
			else
			{
				ViewModel.sprAnnual.Col = 4;
				ViewModel.sprAnnual.Row = 60;
				ViewModel.sprAnnual.Text = "";
				ViewModel.sprAnnual.Col = 5;
				ViewModel.sprAnnual.Text = "";
				ViewModel.sprAnnual.Row = 61;
				ViewModel.sprAnnual.Text = "";
			}

		}

		public void FillSpread()
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int CurrRow = 0, CurrCol = 0;

			ClearGrid();

			string StartDate = "1/1/" + ViewModel.ReportYear;
			string EndDate = DateTime.Parse(StartDate).AddYears(1).ToString("M/d/yyyy");
			ViewModel.sprAnnual.Row = 2;
			ViewModel.sprAnnual.Col = 10;
			ViewModel.sprAnnual.Text = ViewModel.ReportYear;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_AnnualLeave '" + StartDate + "', '" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				CurrCol = Convert.ToInt32(Convert.ToDouble(oRec["month_number"]) * 3);
				if (Convert.ToString(oRec["ampm"]) == "AM")
				{
					CurrRow = Convert.ToInt32((Convert.ToDouble(oRec["day_number"]) * 2) + 2);
				}
				else
				{
					CurrRow = Convert.ToInt32((Convert.ToDouble(oRec["day_number"]) * 2) + 3);
				}
				ViewModel.sprAnnual.Col = CurrCol;
				ViewModel.sprAnnual.Row = CurrRow;
				ViewModel.sprAnnual.Text = Convert.ToString(oRec["total_leave"]);
				if (Convert.ToDouble(oRec["total_leave"]) < 10)
				{
				}
				if (Convert.ToDouble(oRec["flag_hold"]) == 1)
				{
				}
				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.ReportYear = ViewModel.cboYear.Text;
			FillSpread();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdHold_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Place Selected Date on Hold
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			byte HoldFlag = 0;

			if (Information.IsDate(ViewModel.SelectedDate))
			{
				HoldFlag = 1;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUpdate_CalendarHoldFlag '" + ViewModel.SelectedDate + "'," + HoldFlag.ToString();
				oCmd.ExecuteNonQuery();
			}

			FillSpread();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Annual Leave Report to Default Printer

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprAnnual.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAnnual.setPrintAbortMsg("Printing Annual Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprAnnual.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAnnual.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprAnnual.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAnnual.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprAnnual.PrintMarginRight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAnnual.setPrintMarginRight(Convert.ToInt32(0.3d));
            //    sprAnnual.PrintOrientation = 1
            ViewModel.sprAnnual.PrintSheet(null);
			//ViewModel.sprAnnual.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemove_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Remove Hold on Selected Date
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			byte HoldFlag = 0;

			if (Information.IsDate(ViewModel.SelectedDate))
			{
				HoldFlag = 0;
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUpdate_CalendarHoldFlag '" + ViewModel.SelectedDate + "'," + HoldFlag.ToString();
				oCmd.ExecuteNonQuery();
			}

			FillSpread();

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
			ViewModel.cboYear.Text = modGlobal.Shared.gYearReport;
			ViewModel.ReportYear = ViewModel.cboYear.Text;
			FillSpread();

		}



		private void sprAnnual_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//Highlight Selected cell
			//Save Selected Date to Module level variable


			if ( ViewModel.OldCol != 0)
			{
				ViewModel.sprAnnual.Col = ViewModel.OldCol;
				ViewModel.sprAnnual.Row = ViewModel.OldRow;
				if ( ViewModel.OldAMPM == "AM")
				{
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.WHITE;
				}
				else
				{
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.GRAY;
				}
			}
			ViewModel.sprAnnual.Row = Row;

			switch(Col)
			{
				case 1 : case 2 : case 3 :
					if (Col != 2)
					{
						Col = 2;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 1;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "1/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "1/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 4 : case 5 : case 6 :
					if (Col != 5)
					{
						Col = 5;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 4;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "2/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "2/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 7 : case 8 : case 9 :
					if (Col != 8)
					{
						Col = 8;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 7;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "3/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "3/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 10 : case 11 : case 12 :
					if (Col != 11)
					{
						Col = 11;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 10;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "4/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "4/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 13 : case 14 : case 15 :
					if (Col != 14)
					{
						Col = 14;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 13;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "5/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "5/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 16 : case 17 : case 18 :
					if (Col != 17)
					{
						Col = 17;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 16;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "6/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "6/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 19 : case 20 : case 21 :
					if (Col != 20)
					{
						Col = 20;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 19;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "7/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "7/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 22 : case 23 : case 24 :
					if (Col != 23)
					{
						Col = 23;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 22;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "8/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "8/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 25 : case 26 : case 27 :
					if (Col != 26)
					{
						Col = 26;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 25;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "9/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "9/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 28 : case 29 : case 30 :
					if (Col != 29)
					{
						Col = 29;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 28;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "10/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "10/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 31 : case 32 : case 33 :
					if (Col != 32)
					{
						Col = 32;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 31;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "11/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "11/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
				case 34 : case 35 : case 36 :
					if (Col != 35)
					{
						Col = 35;
					}
					ViewModel.sprAnnual.Col = Col;
					ViewModel.sprAnnual.BackColor = modGlobal.Shared.BLUE;
					{
					}
					ViewModel.OldAMPM = ViewModel.sprAnnual.Text.Trim();
					ViewModel.sprAnnual.Col = 34;
					if ( ViewModel.OldAMPM == "AM")
					{
						ViewModel.SelectedDate = "12/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00AM";
					}
					else
					{
						ViewModel.sprAnnual.Row = Row - 1;
						ViewModel.SelectedDate = "12/" + ViewModel.sprAnnual.Text.Trim() + "/" + ViewModel.ReportYear + " 7:00PM";
					}
					ViewModel.OldCol = Col;
					ViewModel.OldRow = Row;
					break;
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAnnualLeave DefInstance
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

		public static frmAnnualLeave CreateInstance()
		{
			PTSProject.frmAnnualLeave theInstance = Shared.Container.Resolve< frmAnnualLeave>();
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
			ViewModel.sprAnnual.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprAnnual.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAnnualLeave
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAnnualLeaveViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAnnualLeave m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}