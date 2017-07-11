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

	public partial class frmExtraDaysOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmExtraDaysOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmExtraDaysOff));
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


		private void frmExtraDaysOff_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*********************************
		//* Extra Days Off Report         *
		//*********************************
		//ADODB

		public void ClearGrid()
		{
			//clear Grid
			UpgradeHelpers.Helpers.Color Putty = UpgradeHelpers.Helpers.Color.FromArgb(189, 185, 170);
			ViewModel.sprDaysOff.Col = 8;
			ViewModel.sprDaysOff.Row = 1;
			ViewModel.sprDaysOff.Text = "";
			ViewModel.sprDetail.Col = 1;
			ViewModel.sprDetail.Col2 = ViewModel.sprDetail.MaxCols;
			ViewModel.sprDetail.Row = 1;
			ViewModel.sprDetail.Row2 = ViewModel.sprDetail.MaxRows;
			ViewModel.sprDetail.BlockMode = true;
			ViewModel.sprDetail.Text = "";
			ViewModel.sprDetail.BlockMode = false;
			ViewModel.sprDaysOff.BlockMode = true;
			ViewModel.sprDaysOff.Col = 1;
			ViewModel.sprDaysOff.Row = 5;
			ViewModel.sprDaysOff.Col2 = ViewModel.sprDaysOff.MaxCols;
			ViewModel.sprDaysOff.Row2 = ViewModel.sprDaysOff.MaxRows;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprDaysOff.BackColor = modGlobal.Shared.WHITE; //Clear Cell Color

			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Clear Cell Borders

			ViewModel.sprDaysOff.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Put borders around each cell

			//Center cell alignment
			ViewModel.sprDaysOff.Col = 2;
			ViewModel.sprDaysOff.Col2 = ViewModel.sprDaysOff.MaxCols;
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprDaysOff.Col = 13;
			ViewModel.sprDaysOff.Col2 = 14;
			ViewModel.sprDaysOff.BackColor = Putty;
			ViewModel.sprDaysOff.BlockMode = false;

		}

		public void FillGrid()
		{
			//Fill Grid with Selected Months OT Detail
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string EndDate = "";
			string NewDate = "";

			ClearGrid();
			ViewModel.sprDaysOff.Row = 1;
			ViewModel.sprDaysOff.Col = 8;
			ViewModel.sprDaysOff.Text = ViewModel.cboMonth.Text + " " + ViewModel.cboYear.Text;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//int ThisMonthFlag = 0;
			System.DateTime TempDate = DateTime.FromOADate(0);
			string StartDate = (DateTime.TryParse(ViewModel.OTMonth.ToString() + "/1/" + ViewModel.OTYear.ToString()
						, out TempDate)) ? TempDate.ToString("M/d/yyyy") : ViewModel.OTMonth.ToString() + "/1/" + ViewModel.OTYear.ToString();
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			System.DateTime ThisDate = DateTime.Parse((DateTime.TryParse(StartDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : StartDate);
			if (ThisDate.Month == DateTime.Now.Month && ThisDate.Year == DateTime.Now.Year)
			{
				EndDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
				//ThisMonthFlag = -1;
			}
			else if (DateTime.Now < ThisDate)
			{
				ViewManager.ShowMessage("There are no Unplanned Extra Days Off for this month", "Overtime Detail Report", UpgradeHelpers.Helpers.BoxButtons.OK);

				return;
			}
			else
			{
				EndDate = DateTime.Parse(StartDate).AddMonths(1).ToString("M/d/yyyy");
			}

			int CurrRow = 5;
			string TestDate = "";

			oCmd.CommandText = "spReport_DailyTotalStaff '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Overtime Detail Report", UpgradeHelpers.Helpers.BoxButtons.OK);

				return;
			}


			while(!oRec.EOF)
			{
				ViewModel.sprDaysOff.Row = CurrRow;
				NewDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (NewDate != TestDate)
				{
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Text = NewDate;
					ViewModel.sprDaysOff.Col = 2;
					ViewModel.sprDaysOff.Text = Convert.ToString(oRec["shift"]);
					TestDate = NewDate;
					CurrRow++;
				}
				oRec.MoveNext();
			};
			int TotalRows = CurrRow - 1;

			//Retrieve Vacation Scheduled Same Day Counts
			oCmd.CommandText = "spReport_ExtraDaysOffVacation '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprDaysOff.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprDaysOff.Col = 1;
				if (TestDate == ViewModel.sprDaysOff.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaysOff.Col = 3;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprDaysOff.Col = 4;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Row = CurrRow;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Holidays Scheduled Same Day Counts
			oCmd.CommandText = "spReport_ExtraDaysOffHoliday '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprDaysOff.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprDaysOff.Col = 1;
				if (TestDate == ViewModel.sprDaysOff.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaysOff.Col = 5;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprDaysOff.Col = 6;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Row = CurrRow;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Banked VAC Scheduled Same Day Counts
			oCmd.CommandText = "spReport_ExtraDaysOffBanked '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprDaysOff.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprDaysOff.Col = 1;
				if (TestDate == ViewModel.sprDaysOff.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaysOff.Col = 7;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprDaysOff.Col = 8;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Row = CurrRow;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Personnel where Sched was deleted
			oCmd.CommandText = "spReport_ExtraDaysOffSchedDeleted '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprDaysOff.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprDaysOff.Col = 1;
				if (TestDate == ViewModel.sprDaysOff.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaysOff.Col = 9;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprDaysOff.Col = 10;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Row = CurrRow;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Personnel Scheduled for Spec Assignment
			oCmd.CommandText = "spReport_ExtraDaysOffSpecAssign '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprDaysOff.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprDaysOff.Col = 1;
				if (TestDate == ViewModel.sprDaysOff.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaysOff.Col = 11;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					else
					{
						ViewModel.sprDaysOff.Col = 12;
						ViewModel.sprDaysOff.Text = Convert.ToString(oRec["off_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaysOff.Col = 1;
					ViewModel.sprDaysOff.Row = CurrRow;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						break;
					}
				}
			};

			//Calculate Daily OT Totals
			int T1 = 0;
			int T2 = 0;
			for (int i = 5; i <= TotalRows; i++)
			{
				ViewModel.sprDaysOff.Row = i;
				ViewModel.sprDaysOff.Col = 3;
				T1 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 4;
				T2 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 5;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 6;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 7;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 8;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 9;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 10;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 11;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 12;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaysOff.Text));
				ViewModel.sprDaysOff.Col = 13;
				ViewModel.sprDaysOff.Text = T1.ToString();
				ViewModel.sprDaysOff.Col = 14;
				ViewModel.sprDaysOff.Text = T2.ToString();
				T1 = 0;
				T2 = 0;
			}

			//Fill in Zeros
			for (int i = 5; i <= TotalRows; i++)
			{
				int tempForVar = ViewModel.sprDaysOff.MaxCols;
				for (int x = 3; x <= tempForVar; x++)
				{
					ViewModel.sprDaysOff.Row = i;
					ViewModel.sprDaysOff.Col = x;
					if ( ViewModel.sprDaysOff.Text == "")
					{
						ViewModel.sprDaysOff.Text = "0";
					}
				}
			}

			//Calculate Monthly Totals
			CurrRow = TotalRows + 2;
			ViewModel.sprDaysOff.Row = CurrRow;
			ViewModel.sprDaysOff.Col = 1;
			ViewModel.sprDaysOff.Text = "Month Totals";
			int tempForVar2 = ViewModel.sprDaysOff.MaxCols;
			for (int i = 3; i <= tempForVar2; i++)
			{
				ViewModel.sprDaysOff.Col = i;
				T1 = 0;
				for (int x = 5; x <= TotalRows; x++)
				{
					ViewModel.sprDaysOff.Row = x;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaysOff.Text));
				}
				ViewModel.sprDaysOff.Row = CurrRow;
				ViewModel.sprDaysOff.Text = T1.ToString();
			}

			//Format Totals
			//Total Titles
			ViewModel.sprDaysOff.Row = CurrRow - 1;
			ViewModel.sprDaysOff.Col = 3;
			ViewModel.sprDaysOff.Text = "VAC (same day)";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDaysOff.Col = 5;
			ViewModel.sprDaysOff.Text = "HOL (same day)";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDaysOff.Col = 7;
			ViewModel.sprDaysOff.Text = "Banked VAC (same day)";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDaysOff.Col = 9;
			ViewModel.sprDaysOff.Text = "Sched Taken Off PTS";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDaysOff.Col = 11;
			ViewModel.sprDaysOff.Text = "Special Assignment";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprDaysOff.Col = 13;
			ViewModel.sprDaysOff.Text = "Total";
			ViewModel.sprDaysOff.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;

			//Format Background and Cell borders
			ViewModel.sprDaysOff.BlockMode = true;
			ViewModel.sprDaysOff.Row = CurrRow;
			ViewModel.sprDaysOff.Row2 = CurrRow;
			ViewModel.sprDaysOff.Col = 1;
			ViewModel.sprDaysOff.Col2 = ViewModel.sprDaysOff.MaxCols;
			ViewModel.sprDaysOff.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprDaysOff.Col = 1;
			ViewModel.sprDaysOff.Col2 = 2;
			//None - Remove current borders
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

			//Outline
			;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

			//Total Titles Cell borders
			ViewModel.sprDaysOff.Row = CurrRow - 1;
			ViewModel.sprDaysOff.Row2 = CurrRow - 1;
			ViewModel.sprDaysOff.Col = 3;
			ViewModel.sprDaysOff.Col2 = 4;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Col = 5;
			ViewModel.sprDaysOff.Col2 = 6;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Col = 7;
			ViewModel.sprDaysOff.Col2 = 8;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Col = 9;
			ViewModel.sprDaysOff.Col2 = 10;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Col = 11;
			ViewModel.sprDaysOff.Col2 = 12;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Col = 13;
			ViewModel.sprDaysOff.Col2 = 14;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.Row = CurrRow + 1;
			ViewModel.sprDaysOff.Row2 = ViewModel.sprDaysOff.MaxRows;
			ViewModel.sprDaysOff.Col = 1;
			ViewModel.sprDaysOff.Col2 = 20;
			ViewModel.sprDaysOff.BackColor = modGlobal.Shared.WHITE;
			//ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprDaysOff.BlockMode = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMonth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.OTMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.OTYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.OTMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.OTYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print SpreadSheet

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintAbortMsg("Printing Extra Days Off Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintMarginTop was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintMarginTop(720);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintMarginLeft(500);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaysOff.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaysOff.setPrintRowHeaders(false);
            //Perform the printing action
            ViewModel.sprDaysOff.PrintSheet(null);
            //ViewModel.sprDaysOff.Action = (FarPoint.ViewModels.FPActionConstants) 32;

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

		}



		private void sprDaysOff_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			string sDate = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			int iCol = 0;
			int iRow = 0;

			//clear sprDetail grid
			ViewModel.sprDetail.Col = 1;
			ViewModel.sprDetail.Col2 = ViewModel.sprDetail.MaxCols;
			ViewModel.sprDetail.Row = 1;
			ViewModel.sprDetail.Row2 = ViewModel.sprDetail.MaxRows;
			ViewModel.sprDetail.BlockMode = true;
			ViewModel.sprDetail.Text = "";
			ViewModel.sprDetail.BlockMode = false;

			//If report headers clicked... then exit
			if (Row < 5)
			{

				return;
			}
			if (Col == 1 || Col == 2 || Col == 13 || Col == 14)
			{
				return;
			}
			ViewModel.sprDaysOff.Col = 2;
			ViewModel.sprDaysOff.Row = Row;
			if (modGlobal.Clean(ViewModel.sprDaysOff.Text) != "A" && modGlobal.Clean(ViewModel.sprDaysOff.Text)
						!= "B" && modGlobal.Clean(ViewModel.sprDaysOff.Text) != "C" && modGlobal.Clean(ViewModel.sprDaysOff.Text) != "D")
			{

				return;
			}
			ViewModel.sprDaysOff.Col = 1;
			if (!Information.IsDate(ViewModel.sprDaysOff.Text))
			{

				return;
			}
			else
			{
				sDate = DateTime.Parse(ViewModel.sprDaysOff.Text).ToString("M/d/yyyy");
			}

			iCol = Col;
			iRow = Row;
			ViewModel.sprDaysOff.Col = iCol;
			ViewModel.sprDaysOff.Row = iRow;
			if (modGlobal.Clean(ViewModel.sprDaysOff.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal(sprDaysOff.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprDaysOff.Text)) == 0)
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			switch(iCol)
			{
				case 3 : case 4 :  //VAC scheduled same day 
					oCmd.CommandText = "spSelect_ExtraDaysOffVacationbyDate '" + sDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					break;
				case 5 : case 6 :  //HOL scheduled same day 
					oCmd.CommandText = "spSelect_ExtraDaysOffHolidaybyDate '" + sDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					break;
				case 7 : case 8 :  //Banked VAC scheduled same day 
					oCmd.CommandText = "spSelect_ExtraDaysOffBankedbyDate '" + sDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					break;
				case 9 : case 10 :  //Personnel Sched Take Off PTS 
					oCmd.CommandText = "spSelect_ExtraDaysOffDeleteSchedbyDate '" + sDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					break;
				case 11 : case 12 :  //Personnel on Spec Assign 
					oCmd.CommandText = "spSelect_ExtraDaysOffSpecAssignbyDate '" + sDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					break;
				default:
					return;
			}

			int CurrRow = 0;

			while(!oRec.EOF)
			{
				CurrRow++;
				ViewModel.sprDetail.Row = CurrRow;
				ViewModel.sprDetail.Col = 1;
				ViewModel.sprDetail.Text = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy HH:mm");
				ViewModel.sprDetail.Col = 2;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["EmployeeName"]);
				ViewModel.sprDetail.Col = 3;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["CreatorName"]);
				ViewModel.sprDetail.Col = 4;
				if (modGlobal.Clean(oRec["update_date"]) == "")
				{
					ViewModel.sprDetail.Text = "";
				}
				else
				{
					ViewModel.sprDetail.Text = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy HH:mm:ss");
				}
				ViewModel.sprDetail.Col = 5;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["note"]);

				oRec.MoveNext();
			};

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmExtraDaysOff DefInstance
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

		public static frmExtraDaysOff CreateInstance()
		{
			PTSProject.frmExtraDaysOff theInstance = Shared.Container.Resolve< frmExtraDaysOff>();
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
			ViewModel.sprDetail.LifeCycleStartup();
			ViewModel.sprDaysOff.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprDetail.LifeCycleShutdown();
			ViewModel.sprDaysOff.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmExtraDaysOff
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmExtraDaysOffViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmExtraDaysOff m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}