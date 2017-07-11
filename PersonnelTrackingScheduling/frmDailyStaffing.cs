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

	public partial class frmDailyStaffing
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailyStaffingViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmDailyStaffing));
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


		private void frmDailyStaffing_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*****************************************
		//* Daily Staffing Report                 *
		//* Uses Flex Grid - Allows for selection *
		//* of Month & Access to Overtime Report  *
		//*****************************************
		//ADODB

		public void FilterGrid()
		{
			//Populate SpreadSheet with requested Month's Data
			//With Appropriate Shift Filter

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string EndDate = "";
			string NewDate = "";

			int ThisMonthFlag = 0;
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			System.DateTime TempDate = DateTime.FromOADate(0);
			string StartDate = (DateTime.TryParse(ViewModel.ThisMonth.ToString() + "/1/" + ViewModel.ThisYear.ToString()
						, out TempDate)) ? TempDate.ToString("M/d/yyyy") : ViewModel.ThisMonth.ToString() + "/1/" + ViewModel.ThisYear.ToString();
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			System.DateTime ThisDate = DateTime.Parse((DateTime.TryParse(StartDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : StartDate);
			if (ThisDate.Month == DateTime.Now.Month && ThisDate.Year == DateTime.Now.Year)
			{
				EndDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
				ThisMonthFlag = -1;
			}
			else if (DateTime.Now < ThisDate)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Daily Staffing Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				EndDate = DateTime.Parse(StartDate).AddMonths(1).ToString("M/d/yyyy");
			}


			//Clear current grid
			ClearGrid();
			ViewModel.sprDaily.Col = 8;
			ViewModel.sprDaily.Row = 1;
			ViewModel.sprDaily.Text = ViewModel.cboMonth.Text + " " + ViewModel.cboYear.Text;
			int CurrRow = 5;
			string TestDate = "";
			int T1 = 0;
			int T2 = 0;
			int T3 = 0;
			int T4 = 0;
			int TotalRows = 0;
			//Retrieve Date, Shift & Total Staffing counts
			oCmd.CommandText = "spReport_DailyTotalStaffF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Daily Staffing Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			while(!oRec.EOF)
			{
				ViewModel.sprDaily.Row = CurrRow;
				NewDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (Convert.ToString(oRec["ampm"]) == "AM")
				{
					ViewModel.sprDaily.Col = 11;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["total_count"]);
				}
				else
				{
					ViewModel.sprDaily.Col = 12;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["total_count"]);
				}
				if (NewDate != TestDate)
				{
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Text = NewDate;
					ViewModel.sprDaily.Col = 2;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["shift"]);
				}
				else
				{
					CurrRow++;
				}
				TestDate = NewDate;
				oRec.MoveNext();
			};
			TotalRows = CurrRow - 1;
			int TotalDays = TotalRows - 4;

			//Get Working BC for Batt 1 & 2
			oCmd.CommandText = "spReport_DailyBCF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;

			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 23;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_181"]).Trim();
					ViewModel.sprDaily.Col = 24;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_182"]).Trim();
					oRec.MoveNext();
				}
				CurrRow++;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//Get Working BC for Batt 3
			oCmd.CommandText = "spReport_Daily3rdBCF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;

			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 25;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_183"]).Trim();
					oRec.MoveNext();
				}
				CurrRow++;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//Retrieve CSR to FCC counts
			oCmd.CommandText = "spReport_DailyAssignedF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;

			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 3;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_am_count"]);
					ViewModel.sprDaily.Col = 4;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_pm_count"]);
					ViewModel.sprDaily.Col = 19;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_am_count"]);
					if (Convert.ToDouble(oRec["fcc_am_count"]) > 0)
					{
						ViewModel.sprDaily.Col = 11;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_am_count"])).ToString();
					}
					ViewModel.sprDaily.Col = 20;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_pm_count"]);
					if (Convert.ToDouble(oRec["fcc_pm_count"]) > 0)
					{
						ViewModel.sprDaily.Col = 12;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_pm_count"])).ToString();
					}
					oRec.MoveNext();
				}
				CurrRow++;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//If Reporting Current Month look up todays CSR's and Move to FCC
			if (ThisMonthFlag != 0)
			{
				oCmd.CommandText = "spReport_DailyCSR '" + DateTime.Parse(EndDate).AddDays(-1).ToString("M/d/yyyy") + "','" + EndDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					ViewModel.sprDaily.Row = TotalRows;
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 3;
					}
					else
					{
						ViewModel.sprDaily.Col = 4;
					}
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_count"]);
					oRec.MoveNext();
					if (!oRec.EOF)
					{
						if (Convert.ToString(oRec["ampm"]) == "AM")
						{
							ViewModel.sprDaily.Col = 3;
						}
						else
						{
							ViewModel.sprDaily.Col = 4;
						}
						ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_count"]);
					}
				}
				oCmd.CommandText = "spReport_DailyMoveFCC '" + DateTime.Parse(EndDate).AddDays(-1).ToString("M/d/yyyy") + "','" + EndDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					ViewModel.sprDaily.Row = TotalRows;
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 19;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
						ViewModel.sprDaily.Col = 11;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
					}
					else
					{
						ViewModel.sprDaily.Col = 20;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
						ViewModel.sprDaily.Col = 12;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
					}
					oRec.MoveNext();
					if (!oRec.EOF)
					{
						if (Convert.ToString(oRec["ampm"]) == "AM")
						{
							ViewModel.sprDaily.Col = 19;
							ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
							ViewModel.sprDaily.Col = 11;
							ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
						}
						else
						{
							ViewModel.sprDaily.Col = 20;
							ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
							ViewModel.sprDaily.Col = 12;
							ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
						}
					}
				}
			}

			//If Reporting Current Month look up todays Move to FCC


			//Retrieve Scheduled Debit Day Counts
			oCmd.CommandText = "spReport_DailyDDF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 5;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["debit_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 6;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["debit_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve Scheduled Leave Counts
			oCmd.CommandText = "spReport_DailySchLvF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 13;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 14;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve UnScheduled Leave  Counts
			oCmd.CommandText = "spReport_DailySckLvF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 15;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 16;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve Special Assignment
			oCmd.CommandText = "spReport_DailySAF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 17;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["sa_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 18;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["sa_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve Student/Trainee Counts
			oCmd.CommandText = "spReport_DailyStudentF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 7;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["stud_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 8;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["stud_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};


			//    Retrieve OT Counts
			oCmd.CommandText = "spReport_DailyOTF '" + StartDate + "','" + EndDate + "','" + ViewModel.CurrFilter + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 9;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 10;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    '    Retrieve VAC-HOL created on the same day counts
			//    oCmd.CommandText = "spReport_DailySameDayVACHOLF '" & StartDate & "','" & EndDate & "','" & CurrFilter & "'"
			//    Set oRec = oCmd.Execute
			//    CurrRow = 5
			//    sprDaily.Row = CurrRow
			//
			//    Do Until oRec.EOF
			//        TestDate = Format$(oRec("shift_date"), "m/d/yyyy")
			//        sprDaily.Col = 1
			//        If TestDate = sprDaily.Text Then
			//            If oRec("ampm") = "AM" Then
			//                sprDaily.Col = 25
			//                sprDaily.Text = oRec("leave_count")
			//            Else
			//                sprDaily.Col = 26
			//                sprDaily.Text = oRec("leave_count")
			//            End If
			//            oRec.MoveNext
			//        Else
			//            CurrRow = CurrRow + 1
			//            sprDaily.Col = 1
			//            sprDaily.Row = CurrRow
			//            If sprDaily.Text = "" Then Exit Do
			//        End If
			//    Loop

			//   Calculate Actual Staffing Level
			T1 = 0;
			T2 = 0;
			T3 = 0;
			T4 = 0;
			for (int i = 5; i <= TotalRows; i++)
			{
				ViewModel.sprDaily.Row = i;
				ViewModel.sprDaily.Col = 11;
				T1 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 12;
				T2 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 13;
				T3 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 14;
				T4 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 15;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 16;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 17;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 18;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 19;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 20;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = (T1 - T3).ToString();
				ViewModel.sprDaily.Col = 22;
				ViewModel.sprDaily.Text = (T2 - T4).ToString();
			}

			//Fill in Zeros
			for (int i = 5; i <= TotalRows; i++)
			{
				for (int x = 3; x <= 20; x++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = x;
					if ( ViewModel.sprDaily.Text == "")
					{
						ViewModel.sprDaily.Text = "0";
					}
				}
			}

			//    For i = 5 To TotalRows
			//        For x = 25 To 26
			//            sprDaily.Row = i
			//            sprDaily.Col = x
			//            If sprDaily.Text = "" Then
			//                sprDaily.Text = "0"
			//            End If
			//        Next x
			//    Next i

			//Calculate Monthly Averages/Total Overtime
			if (TotalDays > 0)
			{
				CurrRow = TotalRows + 3;
				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 3;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 4;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 5;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 6;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Text = "Monthly Average";
				ViewModel.sprDaily.Col = 3;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 4;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 5;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 6;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 7;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 8;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 11;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 12;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 8;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 12;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 13;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 14;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 15;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 16;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 13;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 14;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 15;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 16;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.##");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;

				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 17;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 18;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 19;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 20;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 17;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 18;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 19;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 20;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				//Overtime Totals

				T1 = 0;
				T2 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 9;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 10;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Text = T1.ToString();
				ViewModel.sprDaily.Col = 10;
				ViewModel.sprDaily.Text = T2.ToString();

				T1 = 0;
				T2 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 21;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 22;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 22;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");

				//Format Totals Section
				ViewModel.sprDaily.Row = CurrRow - 1;
				ViewModel.sprDaily.Col = 3;
				ViewModel.sprDaily.Text = "CSR";
				ViewModel.sprDaily.Col = 5;
				ViewModel.sprDaily.Text = "DD";
				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Text = "Trainees";
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Text = "Total OT";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Text = "Avg Tot Staff";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 13;
				ViewModel.sprDaily.Text = "V&H";
				ViewModel.sprDaily.Col = 15;
				ViewModel.sprDaily.Text = "Sick";
				ViewModel.sprDaily.Col = 17;
				ViewModel.sprDaily.Text = "SA";
				ViewModel.sprDaily.Col = 19;
				//Make Change Here  FCC = TFC
				ViewModel.sprDaily.Text = "FCC";
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = "Avg Actual Staffing";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.BlockMode = true;
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Row2 = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
				ViewModel.sprDaily.BackColor = modGlobal.Shared.LT_GRAY;
				ViewModel.sprDaily.Row = CurrRow + 1;
				ViewModel.sprDaily.Row2 = ViewModel.sprDaily.MaxRows;
				ViewModel.sprDaily.BackColor = modGlobal.Shared.WHITE;
				//None - Remove current borders
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				//Cell Borders Around Total Titles
				//Averages Title - Same row as Totals
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Row2 = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Col2 = 2;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				//Total Titles Above Totals
				ViewModel.sprDaily.Row = CurrRow - 1;
				ViewModel.sprDaily.Row2 = CurrRow - 1;
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Col2 = 12;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Col2 = 8;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Col2 = 10;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.BlockMode = false;
			}
		}

		public void ClearGrid()
		{
			//Clear Grid
			//Reformat with original theme
			UpgradeHelpers.Helpers.Color Putty = UpgradeHelpers.Helpers.Color.FromArgb(189, 185, 170);
			ViewModel.sprDaily.Col = 8;
			ViewModel.sprDaily.Row = 1;
			ViewModel.sprDaily.Text = "";
			ViewModel.sprDaily.Row = 2;
			ViewModel.sprDaily.Text = "";
			ViewModel.sprDaily.BlockMode = true;
			ViewModel.sprDaily.Col = 1;
			ViewModel.sprDaily.Row = 5;
			ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
			ViewModel.sprDaily.Row2 = ViewModel.sprDaily.MaxRows;
			//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprDaily.BackColor = modGlobal.Shared.WHITE; //Clear Cell Color

			//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Clear Cell Borders

			ViewModel.sprDaily.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Put borders around each cell

			//Center cell alignment
			ViewModel.sprDaily.Col = 2;
			ViewModel.sprDaily.Col2 = 22;
			ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			//skip BC Names, but do center cell alignment last two columns
			ViewModel.sprDaily.Col = 25;
			ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
			ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;

			//Color Calculated columns
			ViewModel.sprDaily.Col = 11;
			ViewModel.sprDaily.Col2 = 12;
			ViewModel.sprDaily.BackColor = Putty;
			ViewModel.sprDaily.Col = 9;
			ViewModel.sprDaily.Col2 = 10;
			ViewModel.sprDaily.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprDaily.Col = 21;
			ViewModel.sprDaily.Col2 = 22;
			ViewModel.sprDaily.BackColor = Putty;
			ViewModel.sprDaily.BlockMode = false;

		}

		public void FillGrid()
		{
			//Populate SpreadSheet with requested Month's Data

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string EndDate = "";
			string NewDate = "";

			int ThisMonthFlag = 0;
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			System.DateTime TempDate = DateTime.FromOADate(0);
			string StartDate = (DateTime.TryParse(ViewModel.ThisMonth.ToString() + "/1/" + ViewModel.ThisYear.ToString()
						, out TempDate)) ? TempDate.ToString("M/d/yyyy") : ViewModel.ThisMonth.ToString() + "/1/" + ViewModel.ThisYear.ToString();
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			System.DateTime ThisDate = DateTime.Parse((DateTime.TryParse(StartDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : StartDate);
			if (ThisDate.Month == DateTime.Now.Month && ThisDate.Year == DateTime.Now.Year)
			{
				EndDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
				ThisMonthFlag = -1;
			}
			else if (DateTime.Now < ThisDate)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Daily Staffing Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				EndDate = DateTime.Parse(StartDate).AddMonths(1).ToString("M/d/yyyy");
			}


			//Clear current grid
			ClearGrid();
			ViewModel.sprDaily.Col = 8;
			ViewModel.sprDaily.Row = 1;
			ViewModel.sprDaily.Text = ViewModel.cboMonth.Text + " " + ViewModel.cboYear.Text;
			int CurrRow = 5;
			string TestDate = "";
			int T1 = 0;
			int T2 = 0;
			int T3 = 0;
			int T4 = 0;
			int TotalRows = 0;
			//Retrieve Date, Shift & Total Staffing counts
			oCmd.CommandText = "spReport_DailyTotalStaff '" + StartDate + "','" + EndDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("There are no Staffing Records for this month", "Daily Staffing Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			while(!oRec.EOF)
			{
				ViewModel.sprDaily.Row = CurrRow;
				NewDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (Convert.ToString(oRec["ampm"]) == "AM")
				{
					ViewModel.sprDaily.Col = 11;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["total_count"]);
				}
				else
				{
					ViewModel.sprDaily.Col = 12;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["total_count"]);
				}
				if (NewDate != TestDate)
				{
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Text = NewDate;
					ViewModel.sprDaily.Col = 2;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["shift"]);
				}
				else
				{
					CurrRow++;
				}
				TestDate = NewDate;
				oRec.MoveNext();
			};
			TotalRows = CurrRow - 1;
			int TotalDays = TotalRows - 4;

			//Get Working BC's for Batt 1 & 2
			oCmd.CommandText = "spReport_DailyBC '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;
			ViewModel.sprDaily.Col = 1;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 23;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_181"]).Trim();
					ViewModel.sprDaily.Col = 24;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_182"]).Trim();
					oRec.MoveNext();
				}
				ViewModel.sprDaily.Col = 1;
				if (oRec.EOF)
				{
					break;
				}

				while( ViewModel.sprDaily.Text == Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"));
				{
					oRec.MoveNext();
					if (oRec.EOF)
					{
						break;
					}
				};

				CurrRow++;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//Get Working BC for Batt 3
			oCmd.CommandText = "spReport_Daily3rdBC '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;
			ViewModel.sprDaily.Col = 1;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 25;
					ViewModel.sprDaily.Text = modGlobal.Clean(oRec["bc_183"]).Trim();
					oRec.MoveNext();
				}
				ViewModel.sprDaily.Col = 1;
				if (oRec.EOF)
				{
					break;
				}

				while( ViewModel.sprDaily.Text == Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy"));
				{
					oRec.MoveNext();
					if (oRec.EOF)
					{
						break;
					}
				};

				CurrRow++;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//Retrieve CSR to FCC counts
			oCmd.CommandText = "spReport_DailyAssigned '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;

			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					ViewModel.sprDaily.Col = 3;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_am_count"]);
					ViewModel.sprDaily.Col = 4;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_pm_count"]);
					ViewModel.sprDaily.Col = 19;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_am_count"]);
					if (Convert.ToDouble(oRec["fcc_am_count"]) > 0)
					{
						ViewModel.sprDaily.Col = 11;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_am_count"])).ToString();
					}
					ViewModel.sprDaily.Col = 20;
					ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_pm_count"]);
					if (Convert.ToDouble(oRec["fcc_pm_count"]) > 0)
					{
						ViewModel.sprDaily.Col = 12;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_pm_count"])).ToString();
					}
					oRec.MoveNext();
				}
				CurrRow++;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Row = CurrRow;
				if ( ViewModel.sprDaily.Text == "")
				{
					break;
				}
			};

			//If Reporting Current Month look up todays CSR's and Move to FCC
			if (ThisMonthFlag != 0)
			{
				oCmd.CommandText = "spReport_DailyCSR '" + DateTime.Parse(EndDate).AddDays(-1).ToString("M/d/yyyy") + "','" + EndDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					ViewModel.sprDaily.Row = TotalRows;
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 3;
					}
					else
					{
						ViewModel.sprDaily.Col = 4;
					}
					ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_count"]);
					oRec.MoveNext();
					if (!oRec.EOF)
					{
						if (Convert.ToString(oRec["ampm"]) == "AM")
						{
							ViewModel.sprDaily.Col = 3;
						}
						else
						{
							ViewModel.sprDaily.Col = 4;
						}
						ViewModel.sprDaily.Text = Convert.ToString(oRec["csr_count"]);
					}
				}
				oCmd.CommandText = "spReport_DailyMoveFCC '" + DateTime.Parse(EndDate).AddDays(-1).ToString("M/d/yyyy") + "','" + EndDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					ViewModel.sprDaily.Row = TotalRows;
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 19;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
						ViewModel.sprDaily.Col = 11;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
					}
					else
					{
						ViewModel.sprDaily.Col = 20;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
						ViewModel.sprDaily.Col = 12;
						ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
					}
					oRec.MoveNext();
					if (!oRec.EOF)
					{
						if (Convert.ToString(oRec["ampm"]) == "AM")
						{
							ViewModel.sprDaily.Col = 19;
							ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
							ViewModel.sprDaily.Col = 11;
							ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
						}
						else
						{
							ViewModel.sprDaily.Col = 20;
							ViewModel.sprDaily.Text = Convert.ToString(oRec["fcc_count"]);
							ViewModel.sprDaily.Col = 12;
							ViewModel.sprDaily.Text = (Conversion.Val(ViewModel.sprDaily.Text) + Convert.ToDouble(oRec["fcc_count"])).ToString();
						}
					}
				}
			}

			//If Reporting Current Month look up todays Move to FCC


			//Retrieve Scheduled Debit Day Counts
			oCmd.CommandText = "spReport_DailyDD '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 5;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["debit_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 6;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["debit_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve Scheduled Leave Counts
			oCmd.CommandText = "spReport_DailySchLv '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 13;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 14;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve UnScheduled Leave  Counts
			oCmd.CommandText = "spReport_DailySckLv '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 15;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 16;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["leave_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//    Retrieve Special Assignment
			oCmd.CommandText = "spReport_DailySA '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 17;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["sa_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 18;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["sa_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Student/Trainee Counts
			oCmd.CommandText = "spReport_DailyStudent '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 7;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["stud_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 8;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["stud_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};


			//Retrieve OT Counts
			oCmd.CommandText = "spReport_DailyOT '" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 5;
			ViewModel.sprDaily.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				ViewModel.sprDaily.Col = 1;
				if (TestDate == ViewModel.sprDaily.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprDaily.Col = 9;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprDaily.Col = 10;
						ViewModel.sprDaily.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprDaily.Col = 1;
					ViewModel.sprDaily.Row = CurrRow;
					if ( ViewModel.sprDaily.Text == "")
					{
						break;
					}
				}
			};
			//-- COMMENTING THIS OUT FOR NOW (8/2010)... INFO NOT BEING USED
			//    'Retrieve VAC-HOL created on the Same Day Counts
			//    oCmd.CommandText = "spReport_DailySameDayVACHOL '" & StartDate & "','" & EndDate & "'"
			//    Set oRec = oCmd.Execute
			//    CurrRow = 5
			//    sprDaily.Row = CurrRow
			//
			//    Do Until oRec.EOF
			//        TestDate = Format$(oRec("shift_date"), "m/d/yyyy")
			//        sprDaily.Col = 1
			//        If TestDate = sprDaily.Text Then
			//            If oRec("ampm") = "AM" Then
			//                sprDaily.Col = 25
			//                sprDaily.Text = oRec("leave_count")
			//            Else
			//                sprDaily.Col = 26
			//                sprDaily.Text = oRec("leave_count")
			//            End If
			//            oRec.MoveNext
			//        Else
			//            CurrRow = CurrRow + 1
			//            sprDaily.Col = 1
			//            sprDaily.Row = CurrRow
			//            If sprDaily.Text = "" Then Exit Do
			//        End If
			//    Loop
			//   Calculate Actual Staffing Level
			T1 = 0;
			T2 = 0;
			T3 = 0;
			T4 = 0;
			for (int i = 5; i <= TotalRows; i++)
			{
				ViewModel.sprDaily.Row = i;
				ViewModel.sprDaily.Col = 11;
				T1 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 12;
				T2 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 13;
				T3 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 14;
				T4 = Convert.ToInt32(Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 15;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 16;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 17;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 18;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 19;
				T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 20;
				T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = (T1 - T3).ToString();
				ViewModel.sprDaily.Col = 22;
				ViewModel.sprDaily.Text = (T2 - T4).ToString();
			}

			//Fill in Zeros
			for (int i = 5; i <= TotalRows; i++)
			{
				for (int x = 3; x <= 20; x++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = x;
					if ( ViewModel.sprDaily.Text == "")
					{
						ViewModel.sprDaily.Text = "0";
					}
				}
			}

			//    For i = 5 To TotalRows
			//        For x = 25 To 26
			//            sprDaily.Row = i
			//            sprDaily.Col = x
			//            If sprDaily.Text = "" Then
			//                sprDaily.Text = "0"
			//            End If
			//        Next x
			//    Next i

			//Calculate Monthly Averages/Total Overtime
			if (TotalDays > 0)
			{
				CurrRow = TotalRows + 3;
				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 3;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 4;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 5;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 6;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Text = "Monthly Average";
				ViewModel.sprDaily.Col = 3;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 4;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 5;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 6;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 7;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 8;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 11;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 12;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 8;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 12;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 13;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 14;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 15;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 16;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 13;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 14;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 15;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.##");
				ViewModel.sprDaily.Col = 16;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.##");

				T1 = 0;
				T2 = 0;
				T3 = 0;
				T4 = 0;

				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 17;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 18;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 19;
					T3 = Convert.ToInt32(T3 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 20;
					T4 = Convert.ToInt32(T4 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 17;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 18;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 19;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T3 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 20;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T4 / TotalDays, "##.00");

				//Overtime Totals

				T1 = 0;
				T2 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 9;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 10;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Text = T1.ToString();
				ViewModel.sprDaily.Col = 10;
				ViewModel.sprDaily.Text = T2.ToString();

				T1 = 0;
				T2 = 0;
				for (int i = 5; i <= TotalRows; i++)
				{
					ViewModel.sprDaily.Row = i;
					ViewModel.sprDaily.Col = 21;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprDaily.Text));
					ViewModel.sprDaily.Col = 22;
					T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprDaily.Text));
				}
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T1 / TotalDays, "##.00");
				ViewModel.sprDaily.Col = 22;
				ViewModel.sprDaily.Text = UpgradeHelpers.Helpers.StringsHelper.Format(T2 / TotalDays, "##.00");

				//Format Totals Section
				ViewModel.sprDaily.Row = CurrRow - 1;
				ViewModel.sprDaily.Col = 3;
				ViewModel.sprDaily.Text = "CSR";
				ViewModel.sprDaily.Col = 5;
				ViewModel.sprDaily.Text = "DD";
				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Text = "Trainees";
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Text = "Total OT";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Text = "Avg Tot Staff";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 13;
				ViewModel.sprDaily.Text = "V&H";
				ViewModel.sprDaily.Col = 15;
				ViewModel.sprDaily.Text = "Sick";
				ViewModel.sprDaily.Col = 17;
				ViewModel.sprDaily.Text = "SA";
				ViewModel.sprDaily.Col = 19;
				//Make Change Here  FCC = TFC
				ViewModel.sprDaily.Text = "FCC";
				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Text = "Avg Actual Staffing";
				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.BlockMode = true;
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Row2 = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
				ViewModel.sprDaily.BackColor = modGlobal.Shared.LT_GRAY;
				ViewModel.sprDaily.Row = CurrRow + 1;
				ViewModel.sprDaily.Row2 = ViewModel.sprDaily.MaxRows;
				ViewModel.sprDaily.BackColor = modGlobal.Shared.WHITE;
				//None - Remove current borders
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				//Cell Borders Around Total Titles
				//Averages Title - Same row as Totals
				ViewModel.sprDaily.Row = CurrRow;
				ViewModel.sprDaily.Row2 = CurrRow;
				ViewModel.sprDaily.Col = 1;
				ViewModel.sprDaily.Col2 = 2;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				//Total Titles Above Totals
				ViewModel.sprDaily.Row = CurrRow - 1;
				ViewModel.sprDaily.Row2 = CurrRow - 1;
				ViewModel.sprDaily.Col = 11;
				ViewModel.sprDaily.Col2 = 12;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.Col = 7;
				ViewModel.sprDaily.Col2 = 8;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprDaily.Col = 9;
				ViewModel.sprDaily.Col2 = 10;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.Col = 21;
				ViewModel.sprDaily.Col2 = ViewModel.sprDaily.MaxCols;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16;
				//Outline
				;
				//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

				ViewModel.sprDaily.BlockMode = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboMonth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.ThisMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.ThisYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			if ( ViewModel.CurrFilter == "*")
			{
				FillGrid();
			}
			else
			{
				FilterGrid();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.ThisMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.ThisYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			if ( ViewModel.CurrFilter == "*")
			{
				FillGrid();
			}
			else
			{
				FilterGrid();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAnnualLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gYearReport = ViewModel.ThisYear.ToString();
			ViewManager.NavigateToView(
				frmAnnualLeave.DefInstance);
			/*			frmAnnualLeave.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdFilter_Click(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cmdFilter.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
			//Assign Filter parameter
			switch(Index)
			{
				case 0 :
					ViewModel.CurrFilter = "A";
					break;
				case 1 :
					ViewModel.CurrFilter = "B";
					break;
				case 2 :
					ViewModel.CurrFilter = "C";
					break;
				case 3 :
					ViewModel.CurrFilter = "D";
					break;
				case 4 :
					ViewModel.CurrFilter = "*";
					break;
			}

			if ( ViewModel.cboMonth.SelectedIndex < 0)
			{
				return;
			}
			ViewModel.ThisMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
			ViewModel.ThisYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			if ( ViewModel.CurrFilter == "*")
			{
				FillGrid();
			}
			else
			{
				FilterGrid();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOvertime_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmOvertime.DefInstance);
			/*			frmOvertime.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print SpreadSheet

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintAbortMsg("Printing Daily Staffing Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintMarginTop was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintMarginTop(720);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintMarginLeft(500);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprDaily.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprDaily.setPrintRowHeaders(false);
            //Perform the printing action
            ViewModel.sprDaily.PrintSheet(null);
			//ViewModel.sprDaily.Action = (FarPoint.ViewModels.FPActionConstants) 32;


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
			ViewModel.ThisYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			ViewModel.CurrFilter = "*";

		}

		private void sprDaily_Advance(object eventSender, Stubs._FarPoint.Win.Spread.AdvanceEventArgs eventArgs)
		{
			bool AdvanceNext = eventArgs.AdvanceNext;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmDailyStaffing DefInstance
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

		public static frmDailyStaffing CreateInstance()
		{
			PTSProject.frmDailyStaffing theInstance = Shared.Container.Resolve< frmDailyStaffing>();
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
			ViewModel.sprDaily.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprDaily.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmDailyStaffing
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailyStaffingViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmDailyStaffing m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}