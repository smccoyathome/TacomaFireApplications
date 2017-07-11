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

	public partial class frmDailySCKLeaveReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailySCKLeaveReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmDailySCKLeaveReport));
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


		private void frmDailySCKLeaveReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void UndoPreviousInsert()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			DbCommand oCmdDelete = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmdDelete.Connection = modGlobal.oConn;
			oCmdDelete.CommandType = CommandType.Text;

			if ( ViewModel.LastMoveUpdateReport)
			{
				oCmd.CommandText = "spSelect_LeaveReportUpdateByDate '" + ViewModel.ReportDate + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				//delete the LeaveReportUpdate record for ReportDate

				while(!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					oCmdDelete.CommandText = "spDelete_LeaveReportUpdate " + Convert.ToString(modGlobal.GetVal(oRec["report_id"])) + " ";
					oCmdDelete.ExecuteNonQuery();

					oRec.MoveNext();
				};
			}
			else if (modGlobal.Clean(ViewModel.CurrEmpID) != "")
			{
				oCmd.CommandText = "spSelect_LeaveReturnByDateEmpID '" + ViewModel.ReportDate + "', '" + modGlobal.Clean(ViewModel.CurrEmpID) + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				//delete the LeaveReturn records for Employee/ReturnDate just inserted...

				while(!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					oCmdDelete.CommandText = "spDelete_LeaveReturn " + Convert.ToString(modGlobal.GetVal(oRec["return_id"])) + " ";
					oCmdDelete.ExecuteNonQuery();

					oRec.MoveNext();
				};
				ViewModel.CurrEmpID = "";
			}
			else
			{
				//need to determine next move...
				oCmd.CommandText = "spSelect_LastLeaveReturnIDByDateCreatedBy '" + ViewModel.ReportDate + "', '" + modGlobal.Clean(modGlobal.Shared.gUser) + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["last_return_id"]) != "")
					{
						//delete last LeaveReturn record entered by user
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						oCmdDelete.CommandText = "spDelete_LeaveReturn " + Convert.ToString(modGlobal.GetVal(oRec["last_return_id"])) + " ";
						oCmdDelete.ExecuteNonQuery();
					}
					else
					{
						oCmd.CommandText = "spSelect_LeaveReportUpdateByDate '" + ViewModel.ReportDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						//delete the LeaveReportUpdate record for ReportDate

						while(!oRec.EOF)
						{
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							oCmdDelete.CommandText = "spDelete_LeaveReportUpdate " + Convert.ToString(modGlobal.GetVal(oRec["report_id"])) + " ";
							oCmdDelete.ExecuteNonQuery();

							oRec.MoveNext();
						};
						ViewModel.cmdUndo.Enabled = false;
					}
				}
				else
				{
					oCmd.CommandText = "spSelect_LeaveReportUpdateByDate '" + ViewModel.ReportDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					//delete the LeaveReportUpdate record for ReportDate

					while(!oRec.EOF)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						oCmdDelete.CommandText = "spDelete_LeaveReportUpdate " + Convert.ToString(modGlobal.GetVal(oRec["report_id"])) + " ";
						oCmdDelete.ExecuteNonQuery();

						oRec.MoveNext();
					};
					ViewModel.cmdUndo.Enabled = false;
				}
			}

		}

		public void RefreshLeaveManagement()
		{
			//Format Daily Sick Leave Report
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			int EmpRow = 0;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployee.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployee.ClearSelection();
			ViewModel.sprEmployee.MaxRows = 100;
			ViewModel.sprEmployee.Row = 1;
			ViewModel.sprEmployee.Row2 = ViewModel.sprEmployee.MaxRows;
			ViewModel.sprEmployee.Col = 1;
			ViewModel.sprEmployee.Col2 = ViewModel.sprEmployee.MaxCols;
			ViewModel.sprEmployee.BlockMode = true;
			ViewModel.sprEmployee.Text = "";
			ViewModel.sprEmployee.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.bYesterday)
			{
				oCmd.CommandText = "spSelect_EmployeeNamesOnSickLeavebyDate '" + ViewModel.ReportDate + "', 'T' ";
			}
			else
			{
				oCmd.CommandText = "spSelect_EmployeeNamesOnSickLeavebyDate '" + ViewModel.ReportDate + "', 'F' ";
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				//fill EmployeeList
				EmpRow++;
				ViewModel.sprEmployee.Row = EmpRow;
				ViewModel.sprEmployee.Col = 1;
				ViewModel.sprEmployee.Text = modGlobal.Clean(oRec["Employee"]);
				ViewModel.sprEmployee.Col = 2;
				ViewModel.sprEmployee.Text = modGlobal.Clean(oRec["ShiftCode"]);
				ViewModel.sprEmployee.Col = 3;
				ViewModel.sprEmployee.Text = modGlobal.Clean(oRec["LeaveType"]);
				ViewModel.sprEmployee.Col = 4;
				ViewModel.sprEmployee.Text = modGlobal.Clean(oRec["EmplID"]);

				oRec.MoveNext();
			};
			ViewModel.sprEmployee.MaxRows = EmpRow;

		}

		public void ClearGrid()
		{

			//    sprNewReport.Row = 4
			//    sprNewReport.Col = 13
			//    sprNewReport.Text = Format$(ReportDate, "m/d/yy")
			ViewModel.sprNewReport.Row = 5;
			ViewModel.sprNewReport.Row2 = ViewModel.sprNewReport.MaxRows;
			ViewModel.sprNewReport.Col = 1;
			ViewModel.sprNewReport.Col2 = ViewModel.sprNewReport.MaxCols;
			ViewModel.sprNewReport.BlockMode = true;
			ViewModel.sprNewReport.Text = "";
			ViewModel.sprNewReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprNewReport.BlockMode = false;
			ViewModel.sprNewReport.Row = 4;
			ViewModel.sprNewReport.Col = 17;
			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.sprNewReport.Text = (DateTime.TryParse(ViewModel.ReportDate, out TempDate)) ? TempDate.ToString("M/d/yy") : ViewModel.ReportDate;
			ViewModel.txtNameSearch.Text = "";

		}

		public void FormatReport()
		{
			//Format Daily Sick Leave Report
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string CurrShift = "";
			int MaxRow = 0;
			ViewModel.bYesterday = false;
			ViewModel.AShift = 5;
			ViewModel.BShift = 5;
			ViewModel.CShift = 5;
			ViewModel.DShift = 5;

			int iColumn = 0;
			ViewModel.CurrRow = 5;
			int DaysOut = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Check for Leave Report Update
			oCmd.CommandText = "spReport_CheckLeaveReportUpdate '" + ViewModel.ReportDate + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				ViewModel.chkStaff.Enabled = true;
				ViewModel.chkStaff.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				//No longer matters... if there's not LeaveReportDone Recored...
				//        If LimitedPower Then
				ViewModel.cmdApproved.Enabled = false;
				//        Else
				//            cmdApproved.Enabled = True
				//        End If
				ViewModel.sprNewReport.Col = 2;
				ViewModel.sprNewReport.Row = 1;
				ViewModel.sprNewReport.Text = "Tacoma Fire Department - Leave Report";
				ViewModel.bYesterday = true;
				ViewModel.LastMoveUpdateReport = false;
			}
			else
			{
				ViewModel.chkStaff.Enabled = false;
				ViewModel.chkStaff.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.cmdApproved.Enabled = !ViewModel.LimitedPower;
				ViewModel.sprNewReport.Col = 2;
				ViewModel.sprNewReport.Row = 1;
				ViewModel.sprNewReport.Text = "Tacoma Fire Department - Updated Leave Report";
			}

			if ( ViewModel.bYesterday)
			{
				oCmd.CommandText = "spReport_ListEmployeesOnSickLeaveByDate '" + ViewModel.ReportDate + "', 'T' ";
			}
			else
			{
				oCmd.CommandText = "spReport_ListEmployeesOnSickLeaveByDate '" + ViewModel.ReportDate + "', 'F' ";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.Part2 = false;
			ViewModel.OtherAShift = 26;
			ViewModel.OtherBShift = 26;
			ViewModel.OtherCShift = 26;
			ViewModel.OtherDShift = 26;
			ViewModel.StudentAShift = 41;
			ViewModel.StudentBShift = 41;
			ViewModel.StudentCShift = 41;
			ViewModel.StudentDShift = 41;

			bool Sort1FirstTime = true;
			bool Sort2FirstTime = true;
			bool Sort3FirstTime = true;


			while(!oRec.EOF)
			{
				CurrShift = modGlobal.Clean(oRec["ShiftCode"]);
				// SortOrder = 1 = Field Group Leave
				//UPGRADE_WARNING: (1068) GetVal(oRec(SortOrder)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["SortOrder"])) == 1)
				{
					if (Sort1FirstTime)
					{
						MaxRow = 0;
						Sort1FirstTime = false;
					}
					switch(CurrShift)
					{
						case "A" :
							iColumn = 1;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.AShift;
							(ViewModel.AShift)++;
							if (MaxRow < ViewModel.AShift)
							{
								MaxRow = ViewModel.AShift;
							}

							break;
						case "B" :
							iColumn = 5;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.BShift;
							(ViewModel.BShift)++;
							if (MaxRow < ViewModel.BShift)
							{
								MaxRow = ViewModel.BShift;
							}

							break;
						case "C" :
							iColumn = 9;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.CShift;
							(ViewModel.CShift)++;
							if (MaxRow < ViewModel.CShift)
							{
								MaxRow = ViewModel.CShift;
							}

							break;
						case "D" :
							iColumn = 13;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.DShift;
							(ViewModel.DShift)++;
							if (MaxRow < ViewModel.DShift)
							{
								MaxRow = ViewModel.DShift;
							}
							break;
					}

					// SortOrder = 2 = Other Than Field Group Leave
				}
				else if (Convert.ToDouble(modGlobal.GetVal(oRec["SortOrder"])) == 2)
				{

					if (Sort2FirstTime)
					{
						MaxRow += 5;
						ViewModel.sprNewReport.Col = 1;
						ViewModel.sprNewReport.Col2 = 16;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.sprNewReport.Row2 = MaxRow;
						ViewModel.sprNewReport.BlockMode = true;
						ViewModel.sprNewReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
						ViewModel.sprNewReport.BlockMode = false;
						ViewModel.sprNewReport.Col = 1;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.sprNewReport.Text = "Other...";
						MaxRow++;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.OtherAShift = MaxRow;
						ViewModel.OtherBShift = MaxRow;
						ViewModel.OtherCShift = MaxRow;
						ViewModel.OtherDShift = MaxRow;
						Sort2FirstTime = false;
					}
					switch(CurrShift)
					{
						case "A" :
							iColumn = 1;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.OtherAShift;
							(ViewModel.OtherAShift)++;
							if (MaxRow < ViewModel.OtherAShift)
							{
								MaxRow = ViewModel.OtherAShift;
							}

							break;
						case "B" :
							iColumn = 5;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.OtherBShift;
							(ViewModel.OtherBShift)++;
							if (MaxRow < ViewModel.OtherBShift)
							{
								MaxRow = ViewModel.OtherBShift;
							}

							break;
						case "C" :
							iColumn = 9;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.OtherCShift;
							(ViewModel.OtherCShift)++;
							if (MaxRow < ViewModel.OtherCShift)
							{
								MaxRow = ViewModel.OtherCShift;
							}

							break;
						case "D" :
							iColumn = 13;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.OtherDShift;
							(ViewModel.OtherDShift)++;
							if (MaxRow < ViewModel.OtherDShift)
							{
								MaxRow = ViewModel.OtherDShift;
							}
							break;
					}

					// SortOrder = 3 = Medic Students S/A
				}
				else if (Convert.ToDouble(modGlobal.GetVal(oRec["SortOrder"])) == 3)
				{
					if (Sort3FirstTime)
					{
						MaxRow += 5;
						ViewModel.sprNewReport.Col = 1;
						ViewModel.sprNewReport.Col2 = 12;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.sprNewReport.Row2 = MaxRow;
						ViewModel.sprNewReport.BlockMode = true;
						ViewModel.sprNewReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
						ViewModel.sprNewReport.BlockMode = false;
						ViewModel.sprNewReport.Col = 1;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.sprNewReport.Text = "Medic Students";
						MaxRow++;
						ViewModel.sprNewReport.Row = MaxRow;
						ViewModel.StudentAShift = MaxRow;
						ViewModel.StudentBShift = MaxRow;
						ViewModel.StudentCShift = MaxRow;
						ViewModel.StudentDShift = MaxRow;
						Sort3FirstTime = false;
					}
					switch(CurrShift)
					{
						case "A" :
							iColumn = 1;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.StudentAShift;
							(ViewModel.StudentAShift)++;
							if (MaxRow < ViewModel.StudentAShift)
							{
								MaxRow = ViewModel.StudentAShift;
							}

							break;
						case "B" :
							iColumn = 5;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.StudentBShift;
							(ViewModel.StudentBShift)++;
							if (MaxRow < ViewModel.StudentBShift)
							{
								MaxRow = ViewModel.StudentBShift;
							}

							break;
						case "C" :
							iColumn = 9;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.StudentCShift;
							(ViewModel.StudentCShift)++;
							if (MaxRow < ViewModel.StudentCShift)
							{
								MaxRow = ViewModel.StudentCShift;
							}

							break;
						case "D" :
							iColumn = 13;
							ViewModel.sprNewReport.Col = iColumn;
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
							ViewModel.sprNewReport.Row = ViewModel.StudentDShift;
							(ViewModel.StudentDShift)++;
							if (MaxRow < ViewModel.StudentDShift)
							{
								MaxRow = ViewModel.StudentDShift;
							}
							break;
					}
				}

				if (modGlobal.Clean(oRec["Transitional"]) == "Y")
				{
				}
				else if (modGlobal.Clean(oRec["Military"]) == "Y")
				{
				}
				else if (DaysOut > 30)
				{
				}
				else
				{
				}
				ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["Employee"]);

				if (modGlobal.Clean(oRec["LastShiftDate"]) == modGlobal.Clean(oRec["FirstShiftDate"]))
				{
					ViewModel.sprNewReport.Col = iColumn + 1;
					ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["LeaveType"]) + "*";
					ViewModel.sprNewReport.Col = iColumn + 2;
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToDateTime(oRec["FirstShiftDate"]).ToString("HH")) > 12)
					{
						ViewModel.sprNewReport.Text = Convert.ToDateTime(oRec["FirstShiftDate"]).ToString("M/d/yy") + "p";
					}
					else
					{
						ViewModel.sprNewReport.Text = Convert.ToDateTime(oRec["FirstShiftDate"]).ToString("M/d/yy") + "a";
					}
					ViewModel.sprNewReport.Col = iColumn + 3;
					ViewModel.sprNewReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprNewReport.Text = "(" + Convert.ToString(modGlobal.GetVal(oRec["ShiftsOut"])) + ")";
				}
				else
				{
					ViewModel.sprNewReport.Col = iColumn + 1;
					ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["LeaveType"]);
					ViewModel.sprNewReport.Col = iColumn + 2;
					ViewModel.sprNewReport.Text = Convert.ToDateTime(oRec["FirstShiftDate"]).ToString("M/d/yy");
					ViewModel.sprNewReport.Col = iColumn + 3;
					ViewModel.sprNewReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprNewReport.Text = "(" + Convert.ToString(modGlobal.GetVal(oRec["ShiftsOut"])) + ")";
				}

				oRec.MoveNext();
			};


			if ( ViewModel.bYesterday)
			{
				oCmd.CommandText = "spReport_ListEmployeesOnTransitionalAssignmentByDate '" + ViewModel.ReportDate + "', 'T' ";
			}
			else
			{
				oCmd.CommandText = "spReport_ListEmployeesOnTransitionalAssignmentByDate '" + ViewModel.ReportDate + "', 'F' ";
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");

			MaxRow += 5;
			ViewModel.sprNewReport.Col = 1;
			ViewModel.sprNewReport.Col2 = 16;
			ViewModel.sprNewReport.Row = MaxRow;
			ViewModel.sprNewReport.Row2 = MaxRow;
			ViewModel.sprNewReport.BlockMode = true;
			ViewModel.sprNewReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.PEACH);
			ViewModel.sprNewReport.BlockMode = false;
			ViewModel.sprNewReport.Col = 1;
			ViewModel.sprNewReport.Row = MaxRow;
			ViewModel.sprNewReport.Text = "Transitional...";
			MaxRow++;
			ViewModel.sprNewReport.Row = MaxRow;
			ViewModel.OtherAShift = MaxRow;
			ViewModel.OtherBShift = MaxRow;
			ViewModel.OtherCShift = MaxRow;
			ViewModel.OtherDShift = MaxRow;



			while(!oRec.EOF)
			{
				CurrShift = modGlobal.Clean(oRec["ShiftCode"]);
				switch(CurrShift)
				{
					case "A" :
						iColumn = 1;
						ViewModel.sprNewReport.Col = iColumn;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
						DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
						ViewModel.sprNewReport.Row = ViewModel.OtherAShift;
						(ViewModel.OtherAShift)++;
						if (MaxRow < ViewModel.OtherAShift)
						{
							MaxRow = ViewModel.OtherAShift;
						}

						break;
					case "B" :
						iColumn = 5;
						ViewModel.sprNewReport.Col = iColumn;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
						DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
						ViewModel.sprNewReport.Row = ViewModel.OtherBShift;
						(ViewModel.OtherBShift)++;
						if (MaxRow < ViewModel.OtherBShift)
						{
							MaxRow = ViewModel.OtherBShift;
						}

						break;
					case "C" :
						iColumn = 9;
						ViewModel.sprNewReport.Col = iColumn;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
						DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
						ViewModel.sprNewReport.Row = ViewModel.OtherCShift;
						(ViewModel.OtherCShift)++;
						if (MaxRow < ViewModel.OtherCShift)
						{
							MaxRow = ViewModel.OtherCShift;
						}

						break;
					case "D" :
						iColumn = 13;
						ViewModel.sprNewReport.Col = iColumn;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
						DaysOut = Convert.ToInt32(modGlobal.GetVal(oRec["DaysOut"]));
						ViewModel.sprNewReport.Row = ViewModel.OtherDShift;
						(ViewModel.OtherDShift)++;
						if (MaxRow < ViewModel.OtherDShift)
						{
							MaxRow = ViewModel.OtherDShift;
						}
						break;
				}
				ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["Employee"]);
				ViewModel.sprNewReport.Col = iColumn + 1;
				ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["LeaveType"]);
				ViewModel.sprNewReport.Col = iColumn + 2;
				ViewModel.sprNewReport.Text = Convert.ToDateTime(oRec["FirstShiftDate"]).ToString("M/d/yy");

				oRec.MoveNext();
			};


			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_LeaveReturnByDate '" + ViewModel.ReportDate + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.Part2 = true;
				ViewModel.sprNewReport.Row = ViewModel.CurrRow;
				ViewModel.sprNewReport.Col = 17;
				ViewModel.sprNewReport.Text = modGlobal.Clean(oRec["Employee"]);
				(ViewModel.CurrRow)++;
				oRec.MoveNext();
			};

			RefreshLeaveManagement();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkStaff_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.sprNewReport.Col = 2;
			ViewModel.sprNewReport.Row = 1;
			if ( ViewModel.sprNewReport.Text == "Tacoma Fire Department - Leave Report")
			{
				ViewModel.cmdApproved.Enabled = ViewModel.chkStaff.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdApproved_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cLeave = Container.Resolve< clsScheduler>();
			ViewModel.LastMoveUpdateReport = false;
			if (cLeave.GetLeaveReportUpdateByDate(ViewModel.ReportDate) != 0)
			{
				//update
				cLeave.LeaveReportUpdateUpdatedBy = modGlobal.Shared.gUser;
				cLeave.LeaveReportUpdateUpdatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				if (cLeave.UpdateLeaveReportUpdate() != 0)
				{
					//successful
					ViewModel.LastMoveUpdateReport = true;
				}
				else
				{

				}
			}
			else
			{
				ViewModel.chkStaff.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				cLeave.LeaveReportUpdateDate = ViewModel.ReportDate;
				cLeave.LeaveReportUpdateUpdatedBy = modGlobal.Shared.gUser;
				cLeave.LeaveReportUpdateUpdatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				if (cLeave.InsertLeaveReportUpdate() != 0)
				{
					ViewModel.LastMoveUpdateReport = true;
					//successful
				}
				else
				{

				}
			}

			ClearGrid();
			FormatReport();
			ViewModel.cmdUndo.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.txtNameSearch.Text = "";
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEdit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cLeave = Container.Resolve< clsScheduler>();

			if (modGlobal.Clean(ViewModel.CurrEmpID) == "")
			{
				return;
			}
			//load the variables...
			cLeave.LeaveReturnEmployeeID = modGlobal.Clean(ViewModel.CurrEmpID);
			cLeave.LeaveReturnDate = DateTime.Parse(ViewModel.dteReturnDate.Text).ToString("MM/dd/yyyy");
			cLeave.LeaveReturnCreatedBy = modGlobal.Shared.gUser;
			cLeave.LeaveReturnCreatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			cLeave.LeaveReturnComments = modGlobal.Clean(ViewModel.txtComment.Text);

			if (cLeave.InsertLeaveReturn() != 0)
			{
				ViewModel.LastMoveUpdateReport = false;
				//successful
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something wrong with inserting the record!", "Insert LeaveReturn Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			ClearGrid();
			FormatReport();
			ViewModel.cmdUndo.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print new Daily Sick Leave Report

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprNewReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprNewReport.setPrintAbortMsg("Printing Daily Sick Leave Report - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprNewReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprNewReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprNewReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprNewReport.setPrintFooter("Printed On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprNewReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprNewReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprNewReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprNewReport.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprNewReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprNewReport.PrintSheet(null);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ClearGrid();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUndo_Click(Object eventSender, System.EventArgs eventArgs)
		{

			UndoPreviousInsert();

			ClearGrid();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//    Screen.MousePointer = vbHourglass
			//
			ViewModel.ReportDate = ViewModel.dtReportDate.Value.Date.ToString("MM/dd/yyyy");
			//    Me.Caption = "Manage Leave Returns for " & ReportDate
			//
			//    ClearGrid
			//    FormatReport
			//
			//    Screen.MousePointer = vbDefault
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtReportDate_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ViewModel.ReportDate = ViewModel.dtReportDate.Value.Date.ToString("MM/dd/yyyy");
			this.ViewModel.Text = "Manage Leave Returns for " + ViewModel.ReportDate;

			ClearGrid();
			FormatReport();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			this.ViewModel.Text = "Manage Leave Returns For " + DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dtReportDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteReturnDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.txtComment.Text = "";
			ViewModel.ReportDate = ViewModel.dtReportDate.Text;
			ViewModel.txtNameSearch.Text = "";
			ViewModel.cmdApproved.Enabled = false;
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.LimitedPower = true;
			if (modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID")
			{
				//    If gUserBatt = "1" Or gSecurity = "ADM" Then
				ViewModel.LimitedPower = false;
				ViewModel.cmdApproved.Enabled = true;
				//    End If
			}

			ViewModel.dtReportDate.MaxDate = DateTime.Parse(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy"));
			ClearGrid();
			FormatReport();
			ViewModel.cmdUndo.Enabled = false;

		}



		private void sprEmployee_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if (Row == 0)
			{
				return;
			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployee.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployee.ClearSelection();
			ViewModel.sprEmployee.Row = 1;
			ViewModel.sprEmployee.Row2 = ViewModel.sprEmployee.MaxRows;
			ViewModel.sprEmployee.Col = 1;
			ViewModel.sprEmployee.Col2 = ViewModel.sprEmployee.MaxCols;
			ViewModel.sprEmployee.BlockMode = true;
			ViewModel.sprEmployee.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployee.BlockMode = false;
			//ViewModel.sprEmployee.SetSelection(1, Row, 3, Row);
			ViewModel.sprEmployee.Row = Row;
			ViewModel.sprEmployee.Row2 = Row;
			ViewModel.sprEmployee.Col = 1;
			ViewModel.sprEmployee.Col2 = 3;
			ViewModel.sprEmployee.BlockMode = true;
			ViewModel.sprEmployee.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprEmployee.BlockMode = false;
			ViewModel.sprEmployee.Row = Row;
			ViewModel.sprEmployee.Col = 4;
			ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.sprEmployee.Text);

			if ( ViewModel.LimitedPower)
			{
				ViewModel.cmdEdit.Enabled = false;
			}
			else
			{
				ViewModel.cmdEdit.Enabled = true;
				ViewManager.SetCurrent(ViewModel.cmdEdit);
			}

		}

		private void sprNewReport_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			string sName = "";

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployee.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployee.ClearSelection();
			ViewModel.sprEmployee.Row = 1;
			ViewModel.sprEmployee.Row2 = ViewModel.sprEmployee.MaxRows;
			ViewModel.sprEmployee.Col = 1;
			ViewModel.sprEmployee.Col2 = ViewModel.sprEmployee.MaxCols;
			ViewModel.sprEmployee.BlockMode = true;
			ViewModel.sprEmployee.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployee.BlockMode = false;
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.txtComment.Text = "";

			if (Row < 5)
			{
				return;
			}
			if (Col > 16)
			{
				return;
			}
			ViewModel.sprNewReport.Row = Row;
			ViewModel.sprNewReport.Col = Col;
			if (modGlobal.Clean(ViewModel.sprNewReport.Text) == "")
			{
				return;
			}


			switch(Col)
			{
				case 1 : case 2 : case 3 : case 4 :
					ViewModel.sprNewReport.Col = 1;
					sName = modGlobal.Clean(ViewModel.sprNewReport.Text);
					if (sName == "")
					{
						return;
					}

					break;
				case 5 : case 6 : case 7 : case 8 :
					ViewModel.sprNewReport.Col = 5;
					sName = modGlobal.Clean(ViewModel.sprNewReport.Text);
					if (sName == "")
					{
						return;
					}

					break;
				case 9 : case 10 : case 11 : case 12 :
					ViewModel.sprNewReport.Col = 9;
					sName = modGlobal.Clean(ViewModel.sprNewReport.Text);
					if (sName == "")
					{
						return;
					}

					break;
				case 13 : case 14 : case 15 : case 16 :
					ViewModel.sprNewReport.Col = 13;
					sName = modGlobal.Clean(ViewModel.sprNewReport.Text);
					if (sName == "")
					{
						return;
					}

					break;
				default:
					return;
			}

			int tempForVar = ViewModel.sprEmployee.DataRowCnt;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprEmployee.Col = 1;
				ViewModel.sprEmployee.Row = i;
				if (modGlobal.Clean(ViewModel.sprEmployee.Text) == sName)
				{
					//ViewModel.sprEmployee.SetSelection(1, i, 3, i);
					ViewModel.sprEmployee.Row = i;
					ViewModel.sprEmployee.Row2 = i;
					ViewModel.sprEmployee.Col = 1;
					ViewModel.sprEmployee.Col2 = 3;
					ViewModel.sprEmployee.BlockMode = true;
					ViewModel.sprEmployee.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprEmployee.BlockMode = false;
					ViewModel.sprEmployee.Row = i;
					ViewModel.sprEmployee.Col = 4;
					ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.sprEmployee.Text);

					if ( ViewModel.LimitedPower)
					{
						ViewModel.cmdEdit.Enabled = false;
					}
					else
					{
						ViewModel.cmdEdit.Enabled = true;
						ViewManager.SetCurrent(ViewModel.cmdEdit);
					}
					return;
				}
			}

		}

		private void sprNewReport_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprNewReport.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprNewReport.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprNewReport.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployee.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployee.ClearSelection();
			ViewModel.sprEmployee.Row = 1;
			ViewModel.sprEmployee.Row2 = ViewModel.sprEmployee.MaxRows;
			ViewModel.sprEmployee.Col = 1;
			ViewModel.sprEmployee.Col2 = ViewModel.sprEmployee.MaxCols;
			ViewModel.sprEmployee.BlockMode = true;
			ViewModel.sprEmployee.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployee.BlockMode = false;

			int iLength = Strings.Len(ViewModel.txtNameSearch.Text);
			if (iLength == 0)
			{
				return;
			}

			int tempForVar = ViewModel.sprEmployee.DataRowCnt;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprEmployee.Col = 1;
				ViewModel.sprEmployee.Row = i;
				if ( ViewModel.sprEmployee.Text.Substring(0, Math.Min(iLength, ViewModel.sprEmployee.Text.Length)).ToUpper() == modGlobal.Clean(ViewModel.txtNameSearch.Text).ToUpper())
				{
					//ViewModel.sprEmployee.SetSelection(1, i, 3, i);
					ViewModel.sprEmployee.Row = i;
					ViewModel.sprEmployee.Row2 = i;
					ViewModel.sprEmployee.Col = 1;
					ViewModel.sprEmployee.Col2 = 3;
					ViewModel.sprEmployee.BlockMode = true;
					ViewModel.sprEmployee.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprEmployee.BlockMode = false;
					ViewModel.sprEmployee.Row = i;
					ViewModel.sprEmployee.Col = 4;
					ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.sprEmployee.Text);
					ViewModel.cmdEdit.Enabled = !ViewModel.LimitedPower;
					return;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmDailySCKLeaveReport DefInstance
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

		public static frmDailySCKLeaveReport CreateInstance()
		{
			PTSProject.frmDailySCKLeaveReport theInstance = Shared.Container.Resolve< frmDailySCKLeaveReport>();
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
			ViewModel.sprEmployee.LifeCycleStartup();
			ViewModel.sprNewReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployee.LifeCycleShutdown();
			ViewModel.sprNewReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmDailySCKLeaveReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmDailySCKLeaveReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmDailySCKLeaveReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}