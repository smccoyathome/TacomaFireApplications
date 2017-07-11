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

	public partial class frmIndivReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndivReport));
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


		private void frmIndivReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

			//Clear Scheduled Leave Info
			ViewModel.sprIndiv.Col2 = 3;
			ViewModel.sprIndiv.Row = 9;
			ViewModel.sprIndiv.Row2 = ViewModel.LastRow;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.WHITE;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;

			//Clear Leave Info
			ViewModel.sprIndiv.Col2 = 6;
			ViewModel.sprIndiv.Row = 9;
			ViewModel.sprIndiv.Row2 = 33;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.WHITE;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;

			//Clear Debit Info
			ViewModel.sprIndiv.Col = 7;
			ViewModel.sprIndiv.Col2 = 8;
			ViewModel.sprIndiv.Row = 9;
			ViewModel.sprIndiv.Row2 = 33;
			ViewModel.sprIndiv.Text = "";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.WHITE;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;

			//Clear Summary Info
			ViewModel.sprIndiv.Col = 7;
			ViewModel.sprIndiv.Col2 = 8;
			ViewModel.sprIndiv.Row = 22;
			ViewModel.sprIndiv.Row2 = 24;
			ViewModel.sprIndiv.Text = "";
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
			string NewType = "";
			float BankTot = 0;
			float TotVacBank = 0, TotVac = 0, TotFhl = 0;
			//    Dim TotMil As Single
			float TotKel = 0;
			float TotMil1 = 0;
			float TotMil2 = 0;
			string JobCode = "";


			ClearSpread();
			//Come Here - for employee id change
			string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			string StartDate = "1/1/" + ViewModel.ReportYear.ToString();
			string EndDate = DateTime.Parse(StartDate).AddYears(1).ToString("M/d/yyyy");
			ViewModel.sprIndiv.Row = 1;
			ViewModel.sprIndiv.Col = 4;
			ViewModel.sprIndiv.Text = ViewModel.ReportYear.ToString();
			float TotHolOverride = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + Empid + "', '" + ViewModel.ReportYear.ToString() + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				TotHolOverride = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec["holiday_max"], "##.0"));
			}

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				JobCode = modGlobal.GetJobCode(Empid);
			}

			oCmd.CommandText = "spReport_Employee '" + Empid + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

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

			oCmd.CommandText = "spReport_EmpSchLv '" + Empid + "','" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			int CurrRow = 7;
			string CurrType = "";
			string CurrDate = "";
			float LeaveTot = 0;
			int KELFlag = 0;

			while(!oRec.EOF)
			{
				if (Convert.ToDouble(oRec["vacation_bank_flag"]) != 0)
				{
					NewType = "VACBANK";
				}
				else if (Convert.ToDouble(oRec["sick_leave_flag"]) != 0)
				{
					NewType = modGlobal.Clean(oRec["time_code_id"]) + "*";
				}
				else
				{
					NewType = modGlobal.Clean(oRec["time_code_id"]);
				}
				if (NewType != CurrType)
				{
					//Totals
					if (LeaveTot > 0)
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 1;
						ViewModel.sprIndiv.Text = "Total " + CurrType;
						ViewModel.sprIndiv.Col = 2;
						ViewModel.sprIndiv.Text = LeaveTot.ToString();
						switch(CurrType)
						{
							case "VAC" : case "VACFML" :
								TotVac += LeaveTot;
								break;
							case "VACBANK" :
								TotVacBank = LeaveTot;
								break;
							case "FHL" : case "FHLFML" :
								TotFhl += LeaveTot;
								//                    Case "MIL" 
								//                        TotMil = LeaveTot 
								break;
							case "ML1" :
								TotMil1 = LeaveTot;
								break;
							case "ML2" :
								TotMil2 = LeaveTot;
								break;
							case "KEL" : case "KLI" :
								TotKel += LeaveTot;
								KELFlag = -1;
								break;
						}
						ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
						//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
						LeaveTot = 0;
					}
					CurrRow += 2;
					ViewModel.sprIndiv.Row = CurrRow;
					ViewModel.sprIndiv.Col = 1;
					ViewModel.sprIndiv.Text = NewType;
					CurrType = NewType;
				}
				if (Convert.ToString(oRec["shift_date"]) != CurrDate)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 2;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					else
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 3;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					CurrDate = Convert.ToString(oRec["shift_date"]);
					CurrRow++;
				}
				else
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Col = 2;
					}
					else
					{
						ViewModel.sprIndiv.Col = 3;
					}
					ViewModel.sprIndiv.Row = CurrRow - 1;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
					LeaveTot = (float) (LeaveTot + 0.5d);
				}
				oRec.MoveNext();
			};
			if (LeaveTot > 0)
			{
				ViewModel.sprIndiv.Row = CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.Text = "Total " + CurrType;
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.Text = LeaveTot.ToString();
				switch(CurrType)
				{
					case "VAC" : case "VACFML" :
						TotVac += LeaveTot;
						break;
					case "VACBANK" :
						TotVacBank = LeaveTot;
						break;
					case "FHL" : case "FHLFML" :
						TotFhl += LeaveTot;
						//            Case "MIL" 
						//                TotMil = LeaveTot 
						break;
					case "ML1" :
						TotMil1 = LeaveTot;
						break;
					case "ML2" :
						TotMil2 = LeaveTot;
						break;
					case "KEL" : case "KLI" :
						TotKel += LeaveTot;
						KELFlag = -1;
						break;
				}
				ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
				//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			}

			oCmd.CommandText = "spSelect_EmployeeScheduleNotes '" + Empid + "','" + ViewModel.cboYear.Text.Trim() + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow += 5;
			ViewModel.sprIndiv.Row = CurrRow;
			ViewModel.sprIndiv.Col = 1;
			ViewModel.sprIndiv.Text = "Leave Notes:";
			ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
			//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			CurrRow++;

			while(!oRec.EOF)
			{
				ViewModel.sprIndiv.Row = CurrRow;
				ViewModel.sprIndiv.Col = 1;
				ViewModel.sprIndiv.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprIndiv.Text = Convert.ToDateTime(oRec["shift_start"]).ToString("MM/dd/yyyy");
				ViewModel.sprIndiv.Col = 2;
				ViewModel.sprIndiv.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprIndiv.Text = Convert.ToString(oRec["note"]).Trim();

				CurrRow++;
				oRec.MoveNext();
			};
			ViewModel.LastRow = CurrRow;

			oCmd.CommandText = "spReport_EmpSckLv '" + Empid + "','" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			CurrRow = 7;
			CurrType = "";
			CurrDate = "";
			LeaveTot = 0;


			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["time_code_id"]) != CurrType)
				{
					//Totals
					if (LeaveTot > 0)
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 4;
						ViewModel.sprIndiv.Text = "Total " + CurrType;
						ViewModel.sprIndiv.Col = 5;
						ViewModel.sprIndiv.Text = LeaveTot.ToString();
						ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
                        //ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
                        LeaveTot = 0;
					}
					CurrRow += 2;
					ViewModel.sprIndiv.Row = CurrRow;
					ViewModel.sprIndiv.Col = 4;
					ViewModel.sprIndiv.Text = modGlobal.Clean(oRec["time_code_id"]);
					CurrType = modGlobal.Clean(oRec["time_code_id"]);
				}
				if (Convert.ToString(oRec["shift_date"]) != CurrDate)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 5;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					else
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 6;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					CurrDate = Convert.ToString(oRec["shift_date"]);
					CurrRow++;
				}
				else
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Col = 5;
					}
					else
					{
						ViewModel.sprIndiv.Col = 6;
					}
					ViewModel.sprIndiv.Row = CurrRow - 1;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
					LeaveTot = (float) (LeaveTot + 0.5d);
				}
				oRec.MoveNext();
			};
			if (LeaveTot > 0)
			{
				ViewModel.sprIndiv.Row = CurrRow;
				ViewModel.sprIndiv.Col = 4;
				ViewModel.sprIndiv.Text = "Total " + CurrType;
				ViewModel.sprIndiv.Col = 5;
				ViewModel.sprIndiv.Text = LeaveTot.ToString();
				ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
				//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			}
			if (CurrRow > ViewModel.LastRow)
			{
				ViewModel.LastRow = CurrRow;
			}

			oCmd.CommandText = "spReport_EmpDebit '" + Empid + "','" + StartDate + "','" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			CurrRow = 9;
			CurrDate = "";
			LeaveTot = 0;


			while(!oRec.EOF)
			{
				if (Convert.ToString(oRec["shift_date"]) != CurrDate)
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 7;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					else
					{
						ViewModel.sprIndiv.Row = CurrRow;
						ViewModel.sprIndiv.Col = 8;
						ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
						LeaveTot = (float) (LeaveTot + 0.5d);
					}
					CurrDate = Convert.ToString(oRec["shift_date"]);
					CurrRow++;
				}
				else
				{
					if (Convert.ToString(oRec["AMPM"]) == "AM")
					{
						ViewModel.sprIndiv.Col = 7;
					}
					else
					{
						ViewModel.sprIndiv.Col = 8;
					}
					ViewModel.sprIndiv.Row = CurrRow - 1;
					ViewModel.sprIndiv.Text = Convert.ToString(oRec["shift_date"]);
					LeaveTot = (float) (LeaveTot + 0.5d);
				}
				oRec.MoveNext();
			};
			if (LeaveTot > 0)
			{
				ViewModel.sprIndiv.Row = CurrRow;
				ViewModel.sprIndiv.Col = 7;
				ViewModel.sprIndiv.Text = "Total Debit";
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = LeaveTot.ToString();
				ViewModel.sprIndiv.CellBorderColor = modGlobal.Shared.BLACK;
				//ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			}
			if (CurrRow > ViewModel.LastRow)
			{
				ViewModel.LastRow = CurrRow;
			}

			//Compute Available Leave Summary
			oCmd.CommandText = "spVacationEarned '" + Empid + "','" + StartDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				LeaveTot = 0;
			}
			else if (AssType == "FCC")
			{
				LeaveTot = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 3, "##.0"));
			}
			else
			{
				LeaveTot = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 2, "##.0"));
			}

			oCmd.CommandText = "sp_GetVacBalance '" + Empid + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				BankTot = (float) (Convert.ToDouble(oRec["vacation_balance"]) / 2);
			}
			else
			{
				BankTot = 0;
			}
			ViewModel.sprIndiv.Row = 36;
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "VAC";
			ViewModel.sprIndiv.Col = 7;
			ViewModel.sprIndiv.Text = UpgradeHelpers.Helpers.StringsHelper.Format(LeaveTot, "##.0");
			ViewModel.sprIndiv.Col = 8;
			if (LeaveTot - TotVac < 0)
			{
				ViewModel.sprIndiv.Text = "0";
			}
			else
			{
				ViewModel.sprIndiv.Text = UpgradeHelpers.Helpers.StringsHelper.Format(LeaveTot - TotVac, "##.0");
			}
			ViewModel.sprIndiv.Row = 37;
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "FHL";
			ViewModel.sprIndiv.Col = 7;
			if (TotHolOverride != 0)
			{
				ViewModel.sprIndiv.Text = TotHolOverride.ToString();
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = (TotHolOverride - TotFhl).ToString();
			}
			else if (AssType == "REG" || AssType == "FCC" || AssType == "MRN")
			{
				ViewModel.sprIndiv.Text = modGlobal.MAXHOLREG.ToString();
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = (modGlobal.MAXHOLREG - TotFhl).ToString();
			}
			else
			{
				ViewModel.sprIndiv.Text = modGlobal.MAXHOLX.ToString();
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = (modGlobal.MAXHOLX - TotFhl).ToString();
			}

			// MODIFY MIL LOGIC HERE ~ DKL 2008
			ViewModel.sprIndiv.Row = 38;
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "ML1/ML2";
			ViewModel.sprIndiv.Col = 7;
			if ( ViewModel.bUseNewMILMAX)
			{
				ViewModel.sprIndiv.Text = modGlobal.newMAXMIL.ToString() + "/" + modGlobal.newMAXMIL.ToString();
			}
			else if ( ViewModel.bBothMILMAX)
			{
				ViewModel.sprIndiv.Text = modGlobal.newMAXMIL.ToString() + "/" + modGlobal.newMAXMIL.ToString();
			}
			else
			{
				ViewModel.sprIndiv.Text = modGlobal.MAXMIL.ToString() + "/" + modGlobal.MAXMIL.ToString();
			}
			ViewModel.sprIndiv.Col = 8;
			if ( ViewModel.bUseNewMILMAX)
			{
				ViewModel.sprIndiv.Text = (modGlobal.newMAXMIL - TotMil1).ToString() + "/" + (modGlobal.newMAXMIL - TotMil2).ToString();
			}
			else if ( ViewModel.bBothMILMAX)
			{
				ViewModel.sprIndiv.Text = (modGlobal.newMAXMIL - TotMil1).ToString() + "/" + (modGlobal.newMAXMIL - TotMil2).ToString();
			}
			else
			{
				ViewModel.sprIndiv.Text = (modGlobal.MAXMIL - TotMil1).ToString() + "/" + (modGlobal.MAXMIL - TotMil2).ToString();
			}

			if (KELFlag != 0)
			{
				ViewModel.sprIndiv.Row = 39;
				ViewModel.sprIndiv.Col = 6;
				ViewModel.sprIndiv.Text = "KEL";
				ViewModel.sprIndiv.Col = 7;
				ViewModel.sprIndiv.Text = modGlobal.MAXKEL.ToString();
				ViewModel.sprIndiv.Col = 8;
				ViewModel.sprIndiv.Text = (modGlobal.MAXKEL - TotKel).ToString();
			}
			ViewModel.sprIndiv.Row = 40;
			ViewModel.sprIndiv.Col = 6;
			ViewModel.sprIndiv.Text = "VACBANK";
			ViewModel.sprIndiv.Row = 41;
			ViewModel.sprIndiv.Col = 7;
			ViewModel.sprIndiv.Text = TotVacBank.ToString();
			ViewModel.sprIndiv.Col = 8;
			ViewModel.sprIndiv.Text = BankTot.ToString();

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
			// MODIFY MIL LOGIC HERE ~ DKL May 2008
			ViewModel.ReportYear = Convert.ToInt32(Conversion.Val(ViewModel.cboYear.Text));
			ViewModel.bUseNewMILMAX = false;
			ViewModel.bBothMILMAX = false;
			if ( ViewModel.ReportYear >= 2008)
			{
				ViewModel.bUseNewMILMAX = true;
			}
			else if ( ViewModel.ReportYear == 2008)
			{
				ViewModel.bBothMILMAX = true;
			}
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
			ViewModel.sprIndiv.setPrintAbortMsg("Printing Individual Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprIndiv.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprIndiv.setPrintBorder(false);
            //    sprIndiv.PrintOrientation = 1
            ViewModel.sprIndiv.PrintSheet(null);
            //ViewModel.sprIndiv.Action = (FarPoint.ViewModels.FPActionConstants) 32;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Create Form Level RDO Connection object
			//Fill Spreadsheet with Requested Data

			//int i = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			string Empid = "";
			//int CleanOpen = 0;
			ViewModel.LastRow = 10;

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
			ViewModel.bUseNewMILMAX = false;
			ViewModel.bBothMILMAX = false;
			oCmd.CommandText = "spOpNameList";
			//    ocmd.CommandText = "spArchiveNameList"
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

			// MODIFY MIL LOGIC HERE ~ DKL May 2008
			//UPGRADE_WARNING: (1068) GetVal(cboYear.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.cboYear.Text)) > 2008)
			{
				ViewModel.bUseNewMILMAX = true;
			}
			else if (Convert.ToDouble(modGlobal.GetVal(ViewModel.cboYear.Text)) == 2008)
			{
				ViewModel.bBothMILMAX = true;
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

		public static frmIndivReport DefInstance
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

		public static frmIndivReport CreateInstance()
		{
			PTSProject.frmIndivReport theInstance = Shared.Container.Resolve< frmIndivReport>();
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

	public partial class frmIndivReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndivReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}