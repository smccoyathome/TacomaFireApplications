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

	public partial class frmIndPMRecertReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndPMRecertReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndPMRecertReport));
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


		private void frmIndPMRecertReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************************************
		//   TFD Training Individual PM Recertification Classes
		//         By Employee, Begin Date thru End Date
		//          Option to print OTEP Modules only...
		//********************************************************

		public void FillSummaryGrid()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			string sSSN = "";

			ClearGrid();

			if (TrainCL.GetEmployeePMRecertInfoByID(ViewModel.CurrEmp) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Not able to find Employee Information!", "Employee Paramedic Recert Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sReportInfo = "";
			string sCertExpDate = "";
			if (!TrainCL.Employee.EOF)
			{
				sReportInfo = "Name: " + modGlobal.Clean(TrainCL.Employee["name_full"]) + "       ";
				sReportInfo = sReportInfo + "SS#: ";
				if (modGlobal.Clean(TrainCL.Employee["social_security_nbr"]) == "")
				{
					sReportInfo = sReportInfo + "           ";
				}
				else
				{
					sSSN = modGlobal.Clean(TrainCL.Employee["social_security_nbr"]);
					sReportInfo = sReportInfo + "*******" + sSSN.Substring(Math.Max(sSSN.Length - 4, 0));
				}
				sReportInfo = sReportInfo + "       Expiration Date: ";
				if (modGlobal.Clean(TrainCL.Employee["recert_date"]) == "")
				{
					sReportInfo = sReportInfo + "          ";
				}
				else
				{
					sCertExpDate = Convert.ToDateTime(TrainCL.Employee["recert_date"]).ToString("M/d/yyyy");
					sReportInfo = sReportInfo + sCertExpDate;
				}
				sReportInfo = sReportInfo + "    Cert #: ";
				if (modGlobal.Clean(TrainCL.Employee["state_number"]) == "")
				{
					sReportInfo = sReportInfo + " ";
				}
				else
				{
					sReportInfo = sReportInfo + modGlobal.Clean(TrainCL.Employee["state_number"]);
				}
				ViewModel.sprSummary.Row = 3;
				ViewModel.sprSummary.Col = 1;
				ViewModel.sprSummary.Text = sReportInfo;

				if ( ViewModel.DoNotChange)
				{
					//continue without changing the startdate or enddate
				}
				else if (sCertExpDate == "")
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("M/d/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
					ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
				}
				else
				{
					ViewModel.dtStart.Text = Convert.ToDateTime(TrainCL.Employee["StartDate"]).ToString("MM/dd/yyyy");
					ViewModel.dtEnd.Text = DateTime.Parse(ViewModel.dtStart.Text).AddYears(3).AddDays(-1).ToString("MM/dd/yyyy");
				}

				sReportInfo = "";
				sReportInfo = "Period Begins: " + ViewModel.dtStart.Text + "          ";
				sReportInfo = sReportInfo + "Period Ends: " + ViewModel.dtEnd.Text;
				ViewModel.sprSummary.Row = 4;
				ViewModel.sprSummary.Col = 1;
				ViewModel.sprSummary.Text = sReportInfo;
			}

			//Do Formal OTEP Training first...
			if (TrainCL.GetEmployeePMRecertOTEPSummary(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There were no Paramedic Recertification Classes retrieved!", "Employee Paramedic Recert Training", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sSubHeading = "";
			int CurrRow = 7;
			int CurrCol = 0;
			int iRowA = 7;
			int iRowB = 7;
			int iRowC = 7;
			int RowAYear = DateTime.Parse(ViewModel.dtStart.Text).Year;
			int RowBYear = DateTime.Parse(ViewModel.dtStart.Text).Year + 1;
			int RowCYear = DateTime.Parse(ViewModel.dtStart.Text).Year + 2;

			double OTEPTotalHrs = 0;

			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprSummary.BlockMode = true;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Row2 = CurrRow;
					ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprSummary.FontBold = true;
					ViewModel.sprSummary.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.FixedSingle;
					ViewModel.sprSummary.BlockMode = false;

					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.GridShowHoriz was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.setGridShowHoriz(true);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.GridShowVert was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.setGridShowVert(true);
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "";
					ViewModel.sprSummary.Col = 2;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Date";
					ViewModel.sprSummary.Col = 3;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Hours";
					ViewModel.sprSummary.Col = 4;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "";
					ViewModel.sprSummary.Col = 5;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Date";
					ViewModel.sprSummary.Col = 6;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Hours";
					ViewModel.sprSummary.Col = 7;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "";
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Date";
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Hours";

				}

				if (modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 01" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 02" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 03" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 04" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 05" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 06")
				{
					iRowA++;
					ViewModel.sprSummary.Row = iRowA;

					if (modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]) != "")
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						RowAYear = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["YearTaken"]));
					}

					CurrCol = 1;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]);

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						OTEPTotalHrs += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					int tempForVar = ViewModel.sprSummary.MaxCols;
					for (int i = 1; i <= tempForVar; i++)
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprSummary.SetCellBorder(i, iRowA, i, iRowA, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
					}

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 07" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 08" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 09" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 10" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 11" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 12")
				{
					iRowB++;
					ViewModel.sprSummary.Row = iRowB;

					if (modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]) != "")
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						RowBYear = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["YearTaken"]));
					}

					CurrCol = 4;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]);

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						OTEPTotalHrs += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					if (iRowB > iRowA)
					{
						int tempForVar2 = ViewModel.sprSummary.MaxCols;
						for (int i = 1; i <= tempForVar2; i++)
						{
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprSummary.SetCellBorder(i, iRowB, i, iRowB, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
						}
					}
				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 13" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 14" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 15" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 16" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 17" || modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]) == "Mod 18")
				{
					iRowC++;
					ViewModel.sprSummary.Row = iRowC;

					if (modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]) != "")
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						RowCYear = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["YearTaken"]));
					}

					CurrCol = 7;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]);

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						OTEPTotalHrs += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					if (iRowC > iRowA && iRowC > iRowB)
					{
						int tempForVar3 = ViewModel.sprSummary.MaxCols;
						for (int i = 1; i <= tempForVar3; i++)
						{
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprSummary.SetCellBorder(i, iRowC, i, iRowC, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
						}
					}
				}
				else
				{
					//Mod 19

					if (modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]) != "")
					{
						//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(YearTaken)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["YearTaken"])) == RowAYear)
						{
							CurrCol = 1;
							iRowA++;
							CurrRow = iRowA;

							if (iRowA > iRowC && iRowA > iRowB)
							{
								int tempForVar4 = ViewModel.sprSummary.MaxCols;
								for (int i = 1; i <= tempForVar4; i++)
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									ViewModel.sprSummary.SetCellBorder(i, iRowA, i, iRowA, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
								}
							}

						}
						else if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["YearTaken"])) == RowBYear)
						{
							CurrCol = 4;
							iRowB++;
							CurrRow = iRowB;

							if (iRowB > iRowA && iRowB > iRowC)
							{
								int tempForVar5 = ViewModel.sprSummary.MaxCols;
								for (int i = 1; i <= tempForVar5; i++)
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									ViewModel.sprSummary.SetCellBorder(i, iRowB, i, iRowB, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
								}
							}

						}
						else
						{
							//GetVal(TrainCL.TrainingRecord("YearTaken"]) = RowCYear
							CurrCol = 7;
							iRowC++;
							CurrRow = iRowC;

							if (iRowC > iRowA && iRowC > iRowB)
							{
								int tempForVar6 = ViewModel.sprSummary.MaxCols;
								for (int i = 1; i <= tempForVar6; i++)
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									ViewModel.sprSummary.SetCellBorder(i, iRowC, i, iRowC, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
								}
							}

						}
					}
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortOTEPDesc"]);

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}

					CurrCol++;
					ViewModel.sprSummary.Col = CurrCol;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						OTEPTotalHrs += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

			if (iRowA >= iRowB && iRowA >= iRowC)
			{
				CurrRow = iRowA;
			}
			else if (iRowB >= iRowA && iRowB >= iRowC)
			{
				CurrRow = iRowB;
			}
			else
			{
				CurrRow = iRowC;
			}

			CurrRow++;
			int tempForVar7 = ViewModel.sprSummary.MaxCols;
			for (int i = 1; i <= tempForVar7; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			if ( ViewModel.chkOTEPOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				//Do OTEP totals
				CurrRow += 2;
				for (int i = 4; i <= 5; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}
				ViewModel.sprSummary.Row = CurrRow;
				ViewModel.sprSummary.Col = 4;
				ViewModel.sprSummary.BackColor = modGlobal.Shared.GRAY;
				ViewModel.sprSummary.FontBold = true;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Total Hrs";
				ViewModel.sprSummary.Col = 5;
				ViewModel.sprSummary.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprSummary.FontBold = true;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = OTEPTotalHrs.ToString();

				CurrRow++;
				for (int i = 4; i <= 5; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}
				return;
			}

			//*************************************
			//Set up Additional CME headings...
			//*************************************
			CurrRow++;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.BackColor = modGlobal.Shared.GRAY;
			ViewModel.sprSummary.Text = "Additional CME";
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.AddCellSpan(1, CurrRow, ViewModel.sprSummary.MaxCols, 1);

			CurrRow++;
			ViewModel.sprSummary.BlockMode = true;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Row2 = CurrRow;
			ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.FixedSingle;
			ViewModel.sprSummary.BlockMode = false;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = DateTime.Parse(ViewModel.dtStart.Text).Year.ToString();
			ViewModel.sprSummary.Col = 2;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 3;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";
			ViewModel.sprSummary.Col = 4;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = (DateTime.Parse(ViewModel.dtStart.Text).Year + 1).ToString();
			ViewModel.sprSummary.Col = 5;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 6;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";
			ViewModel.sprSummary.Col = 7;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = (DateTime.Parse(ViewModel.dtStart.Text).Year + 2).ToString();
			ViewModel.sprSummary.Col = 8;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 9;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";

			//Do Additional CM Recert Training
			if (TrainCL.GetEmployeePMRecertAdditionalCMEHours(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				//Exit Sub
			}
			//Come Here

			int StartRow = CurrRow;
			CurrRow++;
			iRowA = CurrRow;
			iRowB = CurrRow;
			iRowC = CurrRow;



			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprSummary.Row = StartRow;
				ViewModel.sprSummary.Col = 1;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					//        If Clean(TrainCL.TrainingRecord("SpecificDesc2"]) = "ACLS" Then
					ViewModel.sprSummary.Row = iRowA;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = (Convert.ToString(TrainCL.TrainingRecord["SpecificDesc2"]));
					ViewModel.sprSummary.Col = 2;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 3;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowA++;
				}
				ViewModel.sprSummary.Col = 7;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					//        ElseIf Clean(TrainCL.TrainingRecord("SpecificDesc2"]) = "Airway" Then
					ViewModel.sprSummary.Row = iRowC;
					ViewModel.sprSummary.Col = 7;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = (Convert.ToString(TrainCL.TrainingRecord["SpecificDesc2"]));
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowC++;
				}
				ViewModel.sprSummary.Col = 4;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					//        Else
					ViewModel.sprSummary.Row = iRowB;
					ViewModel.sprSummary.Col = 4;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = (Convert.ToString(TrainCL.TrainingRecord["SpecificDesc2"]));
					ViewModel.sprSummary.Col = 5;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 6;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowB++;

				}

				TrainCL.TrainingRecord.MoveNext();
			}
			;

			if (iRowA > CurrRow)
			{
				CurrRow = iRowA;
			}
			if (iRowB > CurrRow)
			{
				CurrRow = iRowB;
			}
			if (iRowC > CurrRow)
			{
				CurrRow = iRowC;
			}

			for (int x = StartRow; x <= CurrRow - 1; x++)
			{
				int tempForVar8 = ViewModel.sprSummary.MaxCols;
				for (int i = 1; i <= tempForVar8; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, x, i, x, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}
			}
			int tempForVar9 = ViewModel.sprSummary.MaxCols;
			for (int i = 1; i <= tempForVar9; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			//*****************************************
			//Set up the Base Station headings...
			//*****************************************
			CurrRow++;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.BackColor = modGlobal.Shared.GRAY;
			ViewModel.sprSummary.Text = "Base Station Meetings";
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.AddCellSpan(1, CurrRow, ViewModel.sprSummary.MaxCols, 1);

			CurrRow++;
			ViewModel.sprSummary.BlockMode = true;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Row2 = CurrRow;
			ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.FixedSingle;
			ViewModel.sprSummary.BlockMode = false;

			//Keep the Header Row
			StartRow = CurrRow;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = DateTime.Parse(ViewModel.dtStart.Text).Year.ToString();
			ViewModel.sprSummary.Col = 2;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 3;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";
			ViewModel.sprSummary.Col = 4;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = (DateTime.Parse(ViewModel.dtStart.Text).Year + 1).ToString();
			ViewModel.sprSummary.Col = 5;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 6;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";
			ViewModel.sprSummary.Col = 7;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = (DateTime.Parse(ViewModel.dtStart.Text).Year + 2).ToString();
			ViewModel.sprSummary.Col = 8;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Date";
			ViewModel.sprSummary.Col = 9;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Hours";

			//Do Base Station Meetings...
			if (TrainCL.GetEmployeePMRecertBaseStationHours(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				CurrRow += 2;
				ViewModel.sprSummary.BlockMode = true;
				ViewModel.sprSummary.Col = 1;
				ViewModel.sprSummary.Col2 = 9;
				ViewModel.sprSummary.Row = CurrRow;
				ViewModel.sprSummary.Row2 = CurrRow;
				ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprSummary.FontBold = true;
				ViewModel.sprSummary.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.FixedSingle;
				ViewModel.sprSummary.BlockMode = false;
				ViewModel.sprSummary.Row = CurrRow;
				ViewModel.sprSummary.Col = 1;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "OTEP Hrs";
				ViewModel.sprSummary.Col = 2;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "";
				ViewModel.sprSummary.Col = 3;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Total Hrs";
				ViewModel.sprSummary.Col = 4;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "";
				ViewModel.sprSummary.Col = 5;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Total Hrs";
				ViewModel.sprSummary.Col = 6;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "";
				ViewModel.sprSummary.Col = 7;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Total Hrs";
				ViewModel.sprSummary.Col = 8;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "";
				ViewModel.sprSummary.Col = 9;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Total Hrs";

				CurrRow++;
				ViewModel.sprSummary.Row = CurrRow;
				ViewModel.sprSummary.Col = 1;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = OTEPTotalHrs.ToString();
				ViewModel.sprSummary.Col = 2;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Cat 1";
				ViewModel.sprSummary.Col = 4;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Cat 2";
				ViewModel.sprSummary.Col = 6;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Cat 3";
				ViewModel.sprSummary.Col = 8;
				ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprSummary.Text = "Cat 4";

				for (int i = 1; i <= 9; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}

				CurrRow++;
				for (int i = 1; i <= 9; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}

				return;
			}

			CurrRow++;

			iRowA = CurrRow;
			iRowB = CurrRow;
			iRowC = CurrRow;


			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprSummary.Row = StartRow;
				ViewModel.sprSummary.Col = 1;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					ViewModel.sprSummary.Row = iRowA;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortDesc"]);
					ViewModel.sprSummary.Col = 2;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 3;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowA++;

				}
				ViewModel.sprSummary.Col = 4;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					ViewModel.sprSummary.Row = iRowB;
					ViewModel.sprSummary.Col = 4;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortDesc"]);
					ViewModel.sprSummary.Col = 5;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 6;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowB++;
				}
				ViewModel.sprSummary.Col = 7;
				if (modGlobal.Clean(ViewModel.sprSummary.Text) == modGlobal.Clean(TrainCL.TrainingRecord["YearTaken"]))
				{
					ViewModel.sprSummary.Row = iRowC;
					ViewModel.sprSummary.Col = 7;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["ShortDesc"]);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}

					iRowC++;
				}

				TrainCL.TrainingRecord.MoveNext();
			}
			;

			if (iRowA > CurrRow)
			{
				CurrRow = iRowA;
			}
			if (iRowB > CurrRow)
			{
				CurrRow = iRowB;
			}
			if (iRowC > CurrRow)
			{
				CurrRow = iRowC;
			}
			StartRow++;
			for (int x = StartRow; x <= CurrRow - 1; x++)
			{
				int tempForVar10 = ViewModel.sprSummary.MaxCols;
				for (int i = 1; i <= tempForVar10; i++)
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.SetCellBorder(i, x, i, x, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
				}
			}
			int tempForVar11 = ViewModel.sprSummary.MaxCols;
			for (int i = 1; i <= tempForVar11; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			//*****************************
			//  Category Summary Totals
			//*****************************
			CurrRow += 2;
			ViewModel.sprSummary.BlockMode = true;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.Col2 = 9;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Row2 = CurrRow;
			ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.FixedSingle;
			ViewModel.sprSummary.BlockMode = false;

			//Keep the Header Row
			StartRow = CurrRow;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "OTEP Hrs";
			ViewModel.sprSummary.Col = 2;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "";
			ViewModel.sprSummary.Col = 3;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Total Hrs";
			ViewModel.sprSummary.Col = 4;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "";
			ViewModel.sprSummary.Col = 5;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Total Hrs";
			ViewModel.sprSummary.Col = 6;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "";
			ViewModel.sprSummary.Col = 7;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Total Hrs";
			ViewModel.sprSummary.Col = 8;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "";
			ViewModel.sprSummary.Col = 9;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Total Hrs";

			CurrRow++;
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = OTEPTotalHrs.ToString();
			ViewModel.sprSummary.Col = 2;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Cat 1";
			ViewModel.sprSummary.Col = 4;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Cat 2";
			ViewModel.sprSummary.Col = 6;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Cat 3";
			ViewModel.sprSummary.Col = 8;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Cat 4";

			//Do Category Totals...
			if (TrainCL.GetEmployeePMRecertCategoryTotals(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				return;
			}

			double TotalHours = 0;
			for (int i = 1; i <= 9; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			while(!TrainCL.TrainingRecord.EOF)
			{
				if (modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]) == "Cat 1")
				{
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 3;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]) == "Cat 2")
				{
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 5;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]) == "Cat 3")
				{
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 7;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]) == "Cat 4")
				{
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["TotalHours"]));

				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;
			CurrRow++;
			for (int i = 1; i <= 9; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			CurrRow += 2;
			for (int i = 4; i <= 5; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 4;
			ViewModel.sprSummary.BackColor = modGlobal.Shared.GRAY;
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = "Total Hrs";

			TotalHours = OTEPTotalHrs + TotalHours;
			ViewModel.sprSummary.Col = 5;
			ViewModel.sprSummary.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			ViewModel.sprSummary.Text = TotalHours.ToString();

			CurrRow++;
			for (int i = 4; i <= 5; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			//Page Break
			CurrRow++;
			ViewModel.sprSummary.Row = CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setRowPageBreak(true);

			//*****************************************************
			//  CME Detail by Category
			//*****************************************************
			//    CurrRow = CurrRow + 1
			ViewModel.sprSummary.Row = CurrRow;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.BackColor = modGlobal.Shared.GRAY;
			ViewModel.sprSummary.Text = "CME Detail Information";
			ViewModel.sprSummary.FontBold = true;
			ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.AddCellSpan(1, CurrRow, ViewModel.sprSummary.MaxCols, 1);

			//Get CME Detail
			if (TrainCL.GetEmployeeParamedicRecertTraining(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				return;
			}

			sSubHeading = "";
			CurrRow++;


			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = sSubHeading;
					ViewModel.sprSummary.FontBold = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, ViewModel.sprSummary.MaxCols, 1);

					CurrRow++;
					ViewModel.sprSummary.BlockMode = true;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Row2 = CurrRow;
					ViewModel.sprSummary.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprSummary.FontBold = true;
					ViewModel.sprSummary.BlockMode = false;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprSummary.Text = "Topic";
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, 7, 1);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Date";
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Hours";

					CurrRow++;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, 7, 1);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					int tempForVar12 = ViewModel.sprSummary.MaxCols;
					for (int i = 1; i <= tempForVar12; i++)
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
					}

				}
				else if (sSubHeading == modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]))
				{
					CurrRow++;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, 7, 1);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					int tempForVar13 = ViewModel.sprSummary.MaxCols;
					for (int i = 1; i <= tempForVar13; i++)
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
					}

				}
				else
				{
					CurrRow++;
					int tempForVar14 = ViewModel.sprSummary.MaxCols;
					for (int i = 1; i <= tempForVar14; i++)
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
					}

					CurrRow++;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = sSubHeading;
					ViewModel.sprSummary.FontBold = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, ViewModel.sprSummary.MaxCols, 1);

					CurrRow++;
					ViewModel.sprSummary.BlockMode = true;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Row2 = CurrRow;
					ViewModel.sprSummary.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprSummary.FontBold = true;
					ViewModel.sprSummary.BlockMode = false;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprSummary.Text = "Topic";
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, 7, 1);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Date";
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprSummary.Text = "Hours";

					CurrRow++;
					ViewModel.sprSummary.Row = CurrRow;
					ViewModel.sprSummary.Col = 1;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprSummary.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprSummary.AddCellSpan(1, CurrRow, 7, 1);
					ViewModel.sprSummary.Col = 8;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						ViewModel.sprSummary.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yy");
					}
					ViewModel.sprSummary.Col = 9;
					ViewModel.sprSummary.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprSummary.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprSummary.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					int tempForVar15 = ViewModel.sprSummary.MaxCols;
					for (int i = 1; i <= tempForVar15; i++)
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 16, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
					}
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;
			CurrRow++;
			ViewModel.sprSummary.Row = CurrRow;
			int tempForVar16 = ViewModel.sprSummary.MaxCols;
			for (int i = 1; i <= tempForVar16; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.SetCellBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.SetCellBorder(i, CurrRow, i, CurrRow, 4, modGlobal.Shared.BLACK, FarPoint.ViewModels.Cells.CellBorderStyleConstants.CellBorderStyleFineSolid);
			}

			//    '*****************************************
			//     'Get ALS Procedures from IRS...
			//    '*****************************************
			//
			//    If TrainCL.GetEmployeeALSProceduresForPMRecert(CurrEmp, dtStart.Text, dtEnd.Text) Then
			//        'continue
			//    Else
			//        Exit Sub
			//    End If
			//
			//    'Page Break
			//    CurrRow = CurrRow + 2
			//    sprSummary.Row = CurrRow
			//    sprSummary.RowPageBreak = True
			//
			//    ProcedureCount = 0
			//    sSubHeading = ""
			//'    CurrRow = CurrRow + 2
			//    Do Until TrainCL.TrainingRecord.EOF
			//        If sSubHeading = "" Then 'First Time
			//
			//            sprSummary.Row = CurrRow
			//            sprSummary.Col = 1
			//            sprSummary.TypeHAlign = TypeHAlignCenter
			//            sprSummary.Text = "ALS Procedures (IRS)"
			//
			//            sprSummary.Col = 3
			//            sprSummary.TypeHAlign = TypeHAlignCenter
			//            sprSummary.Text = "DateTime"
			//
			//            sprSummary.Col = 4
			//            sprSummary.TypeHAlign = TypeHAlignCenter
			//            sprSummary.Text = ""
			//
			//            sprSummary.Col = 5
			//            sprSummary.TypeHAlign = TypeHAlignCenter
			//            sprSummary.Text = "Incident #"
			//
			//            sprSummary.BlockMode = True
			//            sprSummary.Col = 1
			//            sprSummary.Col2 = sprSummary.MaxCols
			//            sprSummary.Row = CurrRow
			//            sprSummary.Row2 = CurrRow
			//            sprSummary.BackColor = PARCHMENT
			//            sprSummary.BlockMode = False
			//
			//            CurrRow = CurrRow + 1
			//            sprSummary.Row = CurrRow
			//
			//            sprSummary.Col = 1
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sSubHeading = Clean(TrainCL.TrainingRecord("description"])
			//            sprSummary.Text = sSubHeading
			//
			//            sprSummary.Col = 3
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sprSummary.AllowCellOverflow = True
			//            If Clean(TrainCL.TrainingRecord("date_incident_created"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = Format$(TrainCL.TrainingRecord("date_incident_created"), "m/d/yyyy h:nn:ss")
			//            End If
			//
			//            sprSummary.Col = 4
			//            sprSummary.Text = ""
			//
			//            sprSummary.Col = 5
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            If Clean(TrainCL.TrainingRecord("incident_number"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = GetVal(TrainCL.TrainingRecord("incident_number"])
			//            End If
			//
			//            ProcedureCount = ProcedureCount + 1
			//
			//        ElseIf Clean(TrainCL.TrainingRecord("description"]) = sSubHeading Then
			//            CurrRow = CurrRow + 1
			//            sprSummary.Row = CurrRow
			//
			//            sprSummary.Col = 1
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sprSummary.Text = Clean(TrainCL.TrainingRecord("description"])
			//
			//            sprSummary.Col = 3
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sprSummary.AllowCellOverflow = True
			//            If Clean(TrainCL.TrainingRecord("date_incident_created"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = Format$(TrainCL.TrainingRecord("date_incident_created"), "m/d/yyyy h:nn:ss")
			//            End If
			//
			//            sprSummary.Col = 4
			//            sprSummary.Text = ""
			//
			//            sprSummary.Col = 5
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            If Clean(TrainCL.TrainingRecord("incident_number"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = GetVal(TrainCL.TrainingRecord("incident_number"])
			//            End If
			//
			//            ProcedureCount = ProcedureCount + 1
			//
			//        Else
			//            'Add logic for subtotaling...
			//            CurrRow = CurrRow + 1
			//            sprSummary.Row = CurrRow
			//            sprSummary.Col = 1
			//            sprSummary.TypeHAlign = TypeHAlignRight
			//
			//            sprSummary.Text = "Total For " & Clean(sSubHeading) & ": "
			//
			//            sprSummary.BlockMode = True
			//            sprSummary.Col = 1
			//            sprSummary.Col2 = sprSummary.MaxCols
			//            sprSummary.Row = CurrRow
			//            sprSummary.Row2 = CurrRow
			//            sprSummary.BackColor = LT_BLUE
			//            sprSummary.FontBold = True
			//            sprSummary.BlockMode = False
			//
			//            sprSummary.Col = 3
			//            sprSummary.Text = ""
			//
			//            sprSummary.Col = 4
			//            sprSummary.Text = ProcedureCount
			//
			//            sprSummary.Col = 5
			//            sprSummary.Text = ""
			//
			//            'continue
			//            ProcedureCount = 0
			//            CurrRow = CurrRow + 2
			//            sprSummary.Row = CurrRow
			//
			//            sprSummary.Col = 1
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sSubHeading = Clean(TrainCL.TrainingRecord("description"])
			//            sprSummary.Text = sSubHeading
			//
			//            sprSummary.Col = 3
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            sprSummary.AllowCellOverflow = True
			//            If Clean(TrainCL.TrainingRecord("date_incident_created"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = Format$(TrainCL.TrainingRecord("date_incident_created"), "m/d/yyyy h:nn:ss")
			//            End If
			//
			//            sprSummary.Col = 4
			//            sprSummary.Text = ""
			//
			//            sprSummary.Col = 5
			//            sprSummary.TypeHAlign = TypeHAlignLeft
			//            If Clean(TrainCL.TrainingRecord("incident_number"]) = "" Then
			//                sprSummary.Text = ""
			//            Else
			//                sprSummary.Text = GetVal(TrainCL.TrainingRecord("incident_number"])
			//            End If
			//
			//            ProcedureCount = ProcedureCount + 1
			//        End If
			//        TrainCL.TrainingRecord.MoveNext
			//    Loop
			//    ' Now do Total Hours for LAST row...
			//    If ProcedureCount > 0 Then
			//        CurrRow = CurrRow + 1
			//        sprSummary.Row = CurrRow
			//        sprSummary.Col = 1
			//        sprSummary.TypeHAlign = TypeHAlignRight
			//
			//        sprSummary.Text = "Total For " & Clean(sSubHeading) & ": "
			//
			//        sprSummary.BlockMode = True
			//        sprSummary.Col = 1
			//        sprSummary.Col2 = sprSummary.MaxCols
			//        sprSummary.Row = CurrRow
			//        sprSummary.Row2 = CurrRow
			//        sprSummary.BackColor = LT_BLUE
			//        sprSummary.FontBold = True
			//        sprSummary.BlockMode = False
			//
			//        sprSummary.Col = 3
			//        sprSummary.Text = ""
			//
			//        sprSummary.Col = 4
			//        sprSummary.Text = ProcedureCount
			//
			//        sprSummary.Col = 5
			//        sprSummary.Text = ""
			//    End If


		}

		public void FillGrid()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			string sSSN = "";

			ClearGrid();

			if (TrainCL.GetEmployeePMRecertInfoByID(ViewModel.CurrEmp) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Not able to find Employee Information!", "Employee Paramedic Recert Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sReportInfo = "";
			string sCertExpDate = "";
			if (!TrainCL.Employee.EOF)
			{
				sReportInfo = "Name: " + modGlobal.Clean(TrainCL.Employee["name_full"]) + "       ";
				sReportInfo = sReportInfo + "SS#: ";
				if (modGlobal.Clean(TrainCL.Employee["social_security_nbr"]) == "")
				{
					sReportInfo = sReportInfo + "           ";
				}
				else
				{
					sSSN = modGlobal.Clean(TrainCL.Employee["social_security_nbr"]);
					sReportInfo = sReportInfo + "*******" + sSSN.Substring(Math.Max(sSSN.Length - 4, 0));
				}
				sReportInfo = sReportInfo + "       Expiration Date: ";
				if (modGlobal.Clean(TrainCL.Employee["recert_date"]) == "")
				{
					sReportInfo = sReportInfo + "          ";
				}
				else
				{
					sCertExpDate = Convert.ToDateTime(TrainCL.Employee["recert_date"]).ToString("M/d/yyyy");
					sReportInfo = sReportInfo + sCertExpDate;
				}
				ViewModel.sprReport.Row = 3;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = sReportInfo;

				if ( ViewModel.DoNotChange)
				{
					//continue without changing the startdate or enddate
				}
				else if (sCertExpDate == "")
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("M/d/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
					ViewModel.dtEnd.Text = DateTime.Now.ToString("M/d/yyyy");
				}
				else
				{
					ViewModel.dtStart.Text = Convert.ToDateTime(TrainCL.Employee["StartDate"]).ToString("M/d/yyyy");
					ViewModel.dtEnd.Text = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(ViewModel.dtStart.Text).AddYears(3).AddDays(-1));
				}

				sReportInfo = "";
				sReportInfo = "Period Begins: " + ViewModel.dtStart.Text + "          ";
				sReportInfo = sReportInfo + "Period Ends: " + ViewModel.dtEnd.Text;
				ViewModel.sprReport.Row = 4;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = sReportInfo;
			}

			//Do Formal OTEP Training first...
			if (TrainCL.GetEmployeePMRecertOTEPTraining(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There were no Paramedic Recertification Classes retrieved!", "Employee Paramedic Recert Training", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			double TotalHours = 0;
			string sSubHeading = "";
			int CurrRow = 7;

			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = "Taken";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "Hrs";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "Category";
				}

				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
				{
					ViewModel.sprReport.Text = "";
				}
				else
				{
					ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yyyy");
				}
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
				{
					ViewModel.sprReport.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
				}
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["Category"]);

				TrainCL.TrainingRecord.MoveNext();
			}
			;

			// Now do Total Hours for OTEP Modules...
			if (TotalHours > 0)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;
				ViewModel.sprReport.Text = "Total Hours: ";
				ViewModel.sprReport.BlockMode = true;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Row2 = CurrRow;
				ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.BlockMode = false;
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = "";
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = TotalHours.ToString();
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = "";
			}

			if ( ViewModel.chkOTEPOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				return;
			}

			//Do Formal Other Training next...
			if (TrainCL.GetEmployeeParamedicRecertTraining(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				return;
			}


			TotalHours = 0;
			bool Max15 = false;
			sSubHeading = "";
			CurrRow += 2;


			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = "Taken";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "Hrs";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "Prov/Inst";

					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["FlagDisplay"]);

				}
				else if (sSubHeading == modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]))
				{
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["FlagDisplay"]);

				}
				else
				{
					// Now do Total Hours for LAST Other Category Modules...
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;

					if (sSubHeading == "Category I")
					{
						ViewModel.sprReport.Text = "Total Hours: ";
					}
					else
					{
						ViewModel.sprReport.Text = "Total Hours (Max 15hrs) : ";
						Max15 = true;
					}
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 4;
					if (Max15)
					{
						if (TotalHours >= 15)
						{
							ViewModel.sprReport.Text = "15";
						}
						else
						{
							ViewModel.sprReport.Text = TotalHours.ToString();
						}
					}
					else
					{
						ViewModel.sprReport.Text = TotalHours.ToString();
					}
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";

					Max15 = false;
					TotalHours = 0;
					//continue

					CurrRow += 2;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["SecondaryDescription"]);
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = "Taken";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "Hrs";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "Prov/Inst";

					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["SpecificDescription"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						TotalHours += Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
					}
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["FlagDisplay"]);

				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;
			// Now do Total Hours for LAST Other Category Modules...
			if (TotalHours > 0)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;

				if (sSubHeading == "Category I")
				{
					ViewModel.sprReport.Text = "Total Hours: ";
				}
				else
				{
					ViewModel.sprReport.Text = "Total Hours (Max 15hrs) : ";
					Max15 = true;
				}
				ViewModel.sprReport.BlockMode = true;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Row2 = CurrRow;
				ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.BlockMode = false;
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = "";
				ViewModel.sprReport.Col = 4;
				if (Max15)
				{
					if (TotalHours >= 15)
					{
						ViewModel.sprReport.Text = "15";
					}
					else
					{
						ViewModel.sprReport.Text = TotalHours.ToString();
					}
				}
				else
				{
					ViewModel.sprReport.Text = TotalHours.ToString();
				}
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = "";
			}

			//Get ALS Procedures from IRS...
			if (TrainCL.GetEmployeeALSProceduresForPMRecert(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				return;
			}

			int ProcedureCount = 0;
			sSubHeading = "";
			CurrRow += 2;

			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time

					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "ALS Procedures (IRS)";
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "DateTime";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "Incident #";
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprReport.BlockMode = false;

					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.AllowCellOverflow was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.setAllowCellOverflow(true);
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["description"]) == sSubHeading)
				{
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.AllowCellOverflow was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.setAllowCellOverflow(true);
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;

				}
				else
				{
					//Add logic for subtotaling...
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;
					ViewModel.sprReport.Text = "Total For " + modGlobal.Clean(sSubHeading) + ": ";
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = ProcedureCount.ToString();
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.Text = "";

					//continue
					ProcedureCount = 0;
					CurrRow += 2;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.AllowCellOverflow was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.setAllowCellOverflow(true);
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "";
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;
			// Now do Total Hours for LAST row...
			if (ProcedureCount > 0)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;
				ViewModel.sprReport.Text = "Total For " + modGlobal.Clean(sSubHeading) + ": ";
				ViewModel.sprReport.BlockMode = true;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Row2 = CurrRow;
				ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.BlockMode = false;
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = "";
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = ProcedureCount.ToString();
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = "";
			}

		}

		public void ClearGrid()
		{

			//    sprReport.BlockMode = True
			//    sprReport.Row = 3
			//    sprReport.Row2 = 5
			//    sprReport.Col = 1
			//    sprReport.Col2 = sprReport.MaxCols
			//    sprReport.Text = ""
			//    sprReport.BlockMode = False
			//
			//    sprReport.BlockMode = True
			//    sprReport.Row = 7
			//    sprReport.Row2 = sprReport.MaxRows
			//    sprReport.Col = 1
			//    sprReport.Col2 = sprReport.MaxCols
			//    sprReport.AllowCellOverflow = False
			//    sprReport.Text = ""
			//    sprReport.BackColor = WHITE
			//    sprReport.ForeColor = BLACK
			//    sprReport.FontBold = False
			//    sprReport.BlockMode = False
			ViewModel.sprSummary.BlockMode = true;
			ViewModel.sprSummary.Row = 3;
			ViewModel.sprSummary.Row2 = 5;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
			ViewModel.sprSummary.Text = "";
			ViewModel.sprSummary.BlockMode = false;
			ViewModel.sprSummary.BlockMode = true;
			ViewModel.sprSummary.Row = 7;
			ViewModel.sprSummary.Row2 = ViewModel.sprSummary.MaxRows;
			ViewModel.sprSummary.Col = 1;
			ViewModel.sprSummary.Col2 = ViewModel.sprSummary.MaxCols;
			ViewModel.sprSummary.Text = "";
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setRowPageBreak(false);
			ViewModel.sprSummary.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprSummary.FontBold = false;
			ViewModel.sprSummary.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.ClearRange(1, 7, ViewModel.sprSummary.MaxCols, ViewModel.sprSummary.MaxRows, false);

			int tempForVar = ViewModel.sprSummary.MaxRows;
			for (int i = 7; i <= tempForVar; i++)
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.RemoveCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprSummary.RemoveCellSpan(1, i);
			}

		}

		public void LoadList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboEmployee.Text = "";
			ViewModel.cboEmployee.Items.Clear();

			//Load Employee Name combobox
			oCmd.Connection = modGlobal.oConn;

			if (modGlobal.Shared.gSecurity == "RO")
			{
				ViewModel.cboEmployee.AddItem(modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser);
				return;
			}

			//    oCmd.CommandText = "spParamedicFullNameList "
			oCmd.CommandText = "spFullNameList";
			//    oCmd.CommandText = "spOpNameList "

			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			while (!oRec.EOF)
			{
				ViewModel.cboEmployee.AddItem(Convert.ToString(oRec["name_full"]).Trim() + " - " + Convert.ToString(oRec["employee_id"]));
				oRec.MoveNext();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmployee_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Select new employee
			//Refill Grid
			ViewModel.CurrEmp = ViewModel.cboEmployee.Text.Substring(Math.Max(ViewModel.cboEmployee.Text.Length - 5, 0));
			ViewModel.lbEmpName.Text = ViewModel.cboEmployee.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboEmployee.Text) - 8, ViewModel.cboEmployee.Text.Length));

			//    FillGrid
			FillSummaryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkDoNotChange_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkDoNotChange.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.DoNotChange = false;
				ViewModel.chkDoNotChange.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkDoNotChange.Visible = false;
				//        FillGrid
				FillSummaryGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkOTEPOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.CurrEmp == "")
			{
				return;
			}

			//    FillGrid
			FillSummaryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Paramedic Recertification Classes"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintAbortMsg("Printing Individual Training PM Recert Summary Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprSummary.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprSummary.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprSummary.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprSummary.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.DoNotChange = true;
			ViewModel.chkDoNotChange.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.chkDoNotChange.Visible = true;
			//    FillGrid
			FillSummaryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.DoNotChange = true;
			ViewModel.chkDoNotChange.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.chkDoNotChange.Visible = true;
			//    FillGrid
			FillSummaryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.DoNotChange = true;
			ViewModel.chkDoNotChange.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.chkDoNotChange.Visible = true;
			//    FillGrid
			FillSummaryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.DoNotChange = true;
			ViewModel.chkDoNotChange.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.chkDoNotChange.Visible = true;
			//    FillGrid
			FillSummaryGrid();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			ViewModel.DoNotChange = false;
			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
			LoadList();
			ViewModel.FirstTime = false;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmIndPMRecertReport DefInstance
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

		public static frmIndPMRecertReport CreateInstance()
		{
			PTSProject.frmIndPMRecertReport theInstance = Shared.Container.Resolve< frmIndPMRecertReport>();
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
			ViewModel.sprSummary.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			ViewModel.sprSummary.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmIndPMRecertReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndPMRecertReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndPMRecertReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}