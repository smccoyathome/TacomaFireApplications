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

	public partial class frmOvertime
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmOvertimeViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmOvertime));
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


		private void frmOvertime_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*********************************
		//* Overtime Detail Report        *
		//*********************************
		//ADODB

		public void ClearGrid()
		{
			//clear Grid
			UpgradeHelpers.Helpers.Color Putty = UpgradeHelpers.Helpers.Color.FromArgb(189, 185, 170);
			ViewModel.sprOT.Col = 8;
			ViewModel.sprOT.Row = 1;
			ViewModel.sprOT.Text = "";
			ViewModel.sprOT.BlockMode = true;
			ViewModel.sprOT.Col = 1;
			ViewModel.sprOT.Row = 5;
			ViewModel.sprOT.Col2 = 20;
			ViewModel.sprOT.Row2 = 37;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 12; //Clear Text

			ViewModel.sprOT.BackColor = modGlobal.Shared.WHITE; //Clear Cell Color

			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Clear Cell Borders

			ViewModel.sprOT.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Put borders around each cell

			//Center cell alignment
			ViewModel.sprOT.Col = 2;
			ViewModel.sprOT.Col2 = 20;
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprOT.Col = 19;
			ViewModel.sprOT.Col2 = 20;
			ViewModel.sprOT.BackColor = Putty;
			ViewModel.sprOT.BlockMode = false;

		}

		public void FillGrid()
		{
			//Fill Grid with Selected Months OT Detail
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string EndDate = "";
			string NewDate = "";

			ClearGrid();
			ViewModel.sprOT.Row = 1;
			ViewModel.sprOT.Col = 8;
			ViewModel.sprOT.Text = ViewModel.cboMonth.Text + " " + ViewModel.cboYear.Text;

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
				ViewManager.ShowMessage("There are no Overtime Records for this month", "Overtime Detail Report", UpgradeHelpers.Helpers.BoxButtons.OK);
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
				ViewModel.sprOT.Row = CurrRow;
				NewDate = Convert.ToDateTime(oRec["shift_date"]).ToString("M/d/yyyy");
				if (NewDate != TestDate)
				{
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Text = NewDate;
					ViewModel.sprOT.Col = 2;
					ViewModel.sprOT.Text = Convert.ToString(oRec["shift"]);
					TestDate = NewDate;
					CurrRow++;
				}
				oRec.MoveNext();
			};
			int TotalRows = CurrRow - 1;

			//Retrieve Officer OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTOfficerPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTOfficerEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTOfficer '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 3;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 4;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Firefighter OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTFFPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTFFEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTFF '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 5;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 6;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Paramedic OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTParamedicPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTParamedicEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTParamedic '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 7;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 8;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve FireBoat Officer OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTFBOffPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTFBOffEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTFBOff '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 9;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 10;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve Pilot OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTPilotPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTPilotEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTPilot '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 11;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 12;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve BC OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTBCPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTBCEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTBC '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 13;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 14;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve ISO OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTAidePlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTAideEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTAide '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 15;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 16;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
					{
						break;
					}
				}
			};

			//Retrieve FCC OT Counts
			if ( ViewModel.cboOption[1].Checked)
			{ //Planned
				oCmd.CommandText = "spReport_OTFCCPlanned '" + StartDate + "','" + EndDate + "'";
			}
			else if ( ViewModel.cboOption[2].Checked)
			{  //EDO
				oCmd.CommandText = "spReport_OTFCCEDO '" + StartDate + "','" + EndDate + "'";
			}
			else
			{
				//Unplanned
				oCmd.CommandText = "spReport_OTFCC '" + StartDate + "','" + EndDate + "'";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 5;
			ViewModel.sprOT.Row = CurrRow;


			while(!oRec.EOF)
			{
				TestDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				ViewModel.sprOT.Col = 1;
				if (TestDate == ViewModel.sprOT.Text)
				{
					if (Convert.ToString(oRec["ampm"]) == "AM")
					{
						ViewModel.sprOT.Col = 17;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					else
					{
						ViewModel.sprOT.Col = 18;
						ViewModel.sprOT.Text = Convert.ToString(oRec["ot_count"]);
					}
					oRec.MoveNext();
				}
				else
				{
					CurrRow++;
					ViewModel.sprOT.Col = 1;
					ViewModel.sprOT.Row = CurrRow;
					if ( ViewModel.sprOT.Text == "")
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
				ViewModel.sprOT.Row = i;
				ViewModel.sprOT.Col = 3;
				T1 = Convert.ToInt32(Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 4;
				T2 = Convert.ToInt32(Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 5;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 6;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 7;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 8;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 9;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 10;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 11;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 12;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 13;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 14;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 15;
				T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 16;
				T2 = Convert.ToInt32(T2 + Conversion.Val(ViewModel.sprOT.Text));
				ViewModel.sprOT.Col = 19;
				ViewModel.sprOT.Text = T1.ToString();
				ViewModel.sprOT.Col = 20;
				ViewModel.sprOT.Text = T2.ToString();
				T1 = 0;
				T2 = 0;
			}

			//Fill in Zeros
			for (int i = 5; i <= TotalRows; i++)
			{
				for (int x = 3; x <= 20; x++)
				{
					ViewModel.sprOT.Row = i;
					ViewModel.sprOT.Col = x;
					if ( ViewModel.sprOT.Text == "")
					{
						ViewModel.sprOT.Text = "0";
					}
				}
			}

			//Calculate Monthly Totals
			CurrRow = TotalRows + 2;
			ViewModel.sprOT.Row = CurrRow;
			ViewModel.sprOT.Col = 1;
			ViewModel.sprOT.Text = "Month Totals";
			for (int i = 3; i <= 20; i++)
			{
				ViewModel.sprOT.Col = i;
				T1 = 0;
				for (int x = 5; x <= TotalRows; x++)
				{
					ViewModel.sprOT.Row = x;
					T1 = Convert.ToInt32(T1 + Conversion.Val(ViewModel.sprOT.Text));
				}
				ViewModel.sprOT.Row = CurrRow;
				ViewModel.sprOT.Text = T1.ToString();
			}

			//Format Totals
			//Total Titles
			ViewModel.sprOT.Row = CurrRow - 1;
			ViewModel.sprOT.Col = 3;
			ViewModel.sprOT.Text = "Officer";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 5;
			ViewModel.sprOT.Text = "Firefighter";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 7;
			ViewModel.sprOT.Text = "Paramedic";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 9;
			ViewModel.sprOT.Text = "Fireboat Officer";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 11;
			ViewModel.sprOT.Text = "Pilot";
			ViewModel.sprOT.Col = 13;
			ViewModel.sprOT.Text = "BC";
			ViewModel.sprOT.Col = 15;
			ViewModel.sprOT.Text = "ISO";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 17;
			//Make Change Here  FCC = TFC
			ViewModel.sprOT.Text = "FCC";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			ViewModel.sprOT.Col = 19;
			ViewModel.sprOT.Text = "Total(Not FCC)";
			ViewModel.sprOT.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;

			//Format Background and Cell borders
			ViewModel.sprOT.BlockMode = true;
			ViewModel.sprOT.Row = CurrRow;
			ViewModel.sprOT.Row2 = CurrRow;
			ViewModel.sprOT.Col = 1;
			ViewModel.sprOT.Col2 = 20;
			ViewModel.sprOT.BackColor = modGlobal.Shared.LT_GRAY;
			ViewModel.sprOT.Col = 1;
			ViewModel.sprOT.Col2 = 2;
			//None - Remove current borders
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

			//Outline
			;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16; //Set Border

			//Total Titles Cell borders
			ViewModel.sprOT.Row = CurrRow - 1;
			ViewModel.sprOT.Row2 = CurrRow - 1;
			ViewModel.sprOT.Col = 3;
			ViewModel.sprOT.Col2 = 4;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 5;
			ViewModel.sprOT.Col2 = 6;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 7;
			ViewModel.sprOT.Col2 = 8;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 9;
			ViewModel.sprOT.Col2 = 10;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 11;
			ViewModel.sprOT.Col2 = 12;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 13;
			ViewModel.sprOT.Col2 = 14;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 15;
			ViewModel.sprOT.Col2 = 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 17;
			ViewModel.sprOT.Col2 = 18;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Col = 19;
			ViewModel.sprOT.Col2 = 20;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.Row = CurrRow + 1;
			ViewModel.sprOT.Row2 = 38;
			ViewModel.sprOT.Col = 1;
			ViewModel.sprOT.Col2 = 20;
			ViewModel.sprOT.BackColor = modGlobal.Shared.WHITE;
			//ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprOT.BlockMode = false;

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
		internal void cboOption_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.sprOT.Col = 1;
				ViewModel.sprOT.Row = 2;
				ViewModel.sprOT.Text = "Overtime Detail Report";

				if ( ViewModel.cboOption[1].Checked)
				{
					ViewModel.sprOT.Text = "Planned Overtime Detail Report";
				}
				else if ( ViewModel.cboOption[2].Checked)
				{
					ViewModel.sprOT.Text = "Education Overtime Detail Report";
				}
				else
				{
					ViewModel.sprOT.Text = "Unplanned Overtime Detail Report";
				}

				if ( ViewModel.cboMonth.SelectedIndex < 0)
				{
					return;
				}
				ViewModel.OTMonth = ViewModel.cboMonth.GetItemData(ViewModel.cboMonth.SelectedIndex);
				ViewModel.OTYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));

				FillGrid();

			}
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

			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintAbortMsg("Printing Overtime Detail Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintColHeaders(false);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintMarginTop was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintMarginTop(720);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintMarginLeft(500);
			//UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprOT.PrintRowHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprOT.setPrintRowHeaders(false);
            //Perform the printing action
            ViewModel.sprOT.PrintSheet(null);
            //ViewModel.sprOT.Action = (FarPoint.ViewModels.FPActionConstants) 32;

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

			//Determine if form called from Daily Staffing
			//If so open form with same month
			//Otherwise Initialize Year Combobox
			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmDailyStaffing")
				{
					ViewModel.cboYear.Text = frmDailyStaffing.DefInstance.ViewModel.cboYear.Text;
					ViewModel.cboMonth.SelectedIndex = frmDailyStaffing.DefInstance.ViewModel.cboMonth.SelectedIndex;
					return;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmOvertime DefInstance
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

		public static frmOvertime CreateInstance()
		{
			PTSProject.frmOvertime theInstance = Shared.Container.Resolve< frmOvertime>();
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
			ViewModel.sprOT.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprOT.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmOvertime
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmOvertimeViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmOvertime m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}