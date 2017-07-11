using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmTrainQuarterlyReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainQuarterlyReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTrainQuarterlyReport));
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


		private void frmTrainQuarterlyReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//Training Minimum Standards Drills Quarterly Report
		//   Filtered by Battalion/Shift
		//*************************************************************

		public void FormatHeadings2()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;

			//Set colors...
			//Green
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			switch( ViewModel.CurrType)
			{
				case 1 :  //Daily Drills 

					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingGreen);
					break;
				case 2 :  //Individual 

					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingBlue);
					break;
				case 3 :  //Engine 

					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingYellow);
					break;
				case 4 :  //Ladder 

					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingPeach);
					break;
				case 8 :  //Hazmat 

					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingPurple);
					break;
			}
			ViewModel.sprReport.BlockMode = false;

			string sHeading = "";
			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}

			sHeading = ViewModel.CurrYear.ToString() + " - " + modGlobal.Clean(ViewModel.cboType.Text);
			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;

			sHeading = "Required Drills And Assignments For ";
			if ( ViewModel.CurrBatt == "")
			{
				if ( ViewModel.CurrShift == "")
				{
					sHeading = sHeading + "All Battalions \\ Shifts";
				}
				else
				{
					sHeading = sHeading + "All Battalions \\ Shift " + ViewModel.CurrShift;
				}
			}
			else
			{
				sHeading = sHeading + "Battalion " + ViewModel.CurrBatt + " ";
				if ( ViewModel.CurrShift == "")
				{
					sHeading = sHeading + "\\ All Shifts";
				}
				else
				{
					sHeading = sHeading + "\\ Shift " + ViewModel.CurrShift;
				}
			}
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "Name";
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "Unit";
			ViewModel.sprReport.Col = 3;
			ViewModel.sprReport.Text = "Shift";
			ViewModel.sprReport.Col = 4;
			ViewModel.sprReport.Text = "Batt";

			if (TrainCL.GetTrainingDrillsByYearType(ViewModel.CurrYear, ViewModel.CurrType) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oh No!  There are no Required Drills set up for Year/Type!", "Training Minimum Standard Drill Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int iCurrRow = 4;
			int iCurrCol = 5;
			string sSubHeading = "";
			int iReportColumn = 1;


			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;
				ViewModel.sprReport.Col = iCurrCol;
				if (sSubHeading == "")
				{ //first time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]);
					ViewModel.sprReport.Text = sSubHeading;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
					ViewModel.sprReport.Row = iCurrRow + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Row = iCurrRow + 2;
					ViewModel.sprReport.Text = iReportColumn.ToString();
					iCurrCol++;
				}
				else if (sSubHeading == modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]))
				{
					ViewModel.sprReport.Row = iCurrRow + 1;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(report_column)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (iReportColumn == Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"])))
					{
						ViewModel.sprReport.Col = iReportColumn;
						ViewModel.sprReport.Text = modGlobal.Clean(ViewModel.sprReport.Text) + " / " + modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
						ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
						ViewModel.sprReport.Row = iCurrRow + 2;
						ViewModel.sprReport.Text = iReportColumn.ToString();
						iCurrCol++;
					}
				}
				else
				{
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Row = iCurrRow + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Row = iCurrRow + 2;
					ViewModel.sprReport.Text = iReportColumn.ToString();
					iCurrCol++;
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}


		public void FormatReport()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 7;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			if (TrainCL.GetTrainingQuarterlyStandardReport(ViewModel.CurrYear, ViewModel.CurrQuarter, ViewModel.CurrBatt, ViewModel.CurrShift) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There are no Employee/Training Records to report for Year/Quarter!", "Training Quarterly Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sEmployeeName = "";
			int iCodeRow = 6;
			int iCurrRow = 7;
			int iCurrCol = 1;

			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;
				ViewModel.sprReport.Col = iCurrCol;
				if (sEmployeeName == "")
				{ //first time
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = iCurrCol + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["battalion_code"]);
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				else if (sEmployeeName == modGlobal.Clean(TrainCL.TrainingRecord["name_full"]))
				{
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				else
				{
					iCurrRow++;
					ViewModel.sprReport.Row = iCurrRow;
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = iCurrCol + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["battalion_code"]);
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}

		public void FormatReport2()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 7;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			if (TrainCL.GetTrainingAnnualStandardReportByType(ViewModel.CurrYear, ViewModel.CurrType, ViewModel.CurrBatt, ViewModel.CurrShift) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There are no Employee/Training Records to report for Year/Type!", "Training Minimum Standard Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sEmployeeName = "";
			int iCodeRow = 6;
			int iCurrRow = 7;
			int iCurrCol = 1;

			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;
				ViewModel.sprReport.Col = iCurrCol;
				if (sEmployeeName == "")
				{ //first time
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = iCurrCol + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["battalion_code"]);
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				else if (sEmployeeName == modGlobal.Clean(TrainCL.TrainingRecord["name_full"]))
				{
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				else
				{
					iCurrRow++;
					ViewModel.sprReport.Row = iCurrRow;
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = iCurrCol + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["battalion_code"]);
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						//            If Clean(TrainCL.TrainingRecord("trn_specific_code"]) <> "" Then
						ViewModel.sprReport.Row = iCodeRow;
						for (int i = 5; i <= 18; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								//                    If Clean(TrainCL.TrainingRecord("trn_specific_code"]) = Clean(sprReport.Text) Then
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurances"]));
								break;
							}
						}
					}
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}

		public void FormatHeadings()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;

			//Set colors...
			//Green
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Col2 = 6;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingGreen);
			ViewModel.sprReport.BlockMode = false;

			//Blue
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 7;
			ViewModel.sprReport.Col2 = 9;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingBlue);
			ViewModel.sprReport.BlockMode = false;

			//Yellow
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 10;
			ViewModel.sprReport.Col2 = 12;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingYellow);
			ViewModel.sprReport.BlockMode = false;

			//Peach
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 13;
			ViewModel.sprReport.Col2 = 15;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingPeach);
			ViewModel.sprReport.BlockMode = false;

			//Purple
			ViewModel.sprReport.Row = 4;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 16;
			ViewModel.sprReport.Col2 = 18;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.TrainingPurple);
			ViewModel.sprReport.BlockMode = false;


			string sHeading = "";

			sHeading = ViewModel.CurrYear.ToString() + " - ";
			switch( ViewModel.CurrQuarter)
			{
				case 4 :
					sHeading = sHeading + "4th Quarter Report";
					break;
				case 3 :
					sHeading = sHeading + "3rd Quarter Report";
					break;
				case 2 :
					sHeading = sHeading + "2nd Quarter Report";
					break;
				default:
					sHeading = sHeading + "1st Quarter Report";
					break;
			}
			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;

			sHeading = "Required Drills And Assignments For ";
			if ( ViewModel.CurrBatt == "")
			{
				if ( ViewModel.CurrShift == "")
				{
					sHeading = sHeading + "All Battalions \\ Shifts";
				}
				else
				{
					sHeading = sHeading + "All Battalions \\ Shift " + ViewModel.CurrShift;
				}
			}
			else
			{
				sHeading = sHeading + "Battalion " + ViewModel.CurrBatt + " ";
				if ( ViewModel.CurrShift == "")
				{
					sHeading = sHeading + "\\ All Shifts";
				}
				else
				{
					sHeading = sHeading + "\\ Shift " + ViewModel.CurrShift;
				}
			}
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "Name";
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "Unit";
			ViewModel.sprReport.Col = 3;
			ViewModel.sprReport.Text = "Shift";
			ViewModel.sprReport.Col = 4;
			ViewModel.sprReport.Text = "Batt";

			if (TrainCL.GetTrainingDrillsByYearQuarter(ViewModel.CurrYear, ViewModel.CurrQuarter) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oh No!  There are no Required Drills set up for Year/Quarter!", "Training Quarterly Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int iCurrRow = 4;
			int iCurrCol = 5;
			string sSubHeading = "";
			int iReportColumn = 1;


			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;
				ViewModel.sprReport.Col = iCurrCol;
				if (sSubHeading == "")
				{ //first time
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]);
					ViewModel.sprReport.Text = sSubHeading;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
					ViewModel.sprReport.Row = iCurrRow + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Row = iCurrRow + 2;
					ViewModel.sprReport.Text = iReportColumn.ToString();
					//            sprReport.Text = Clean(TrainCL.TrainingRecord("trn_specific_code"])
					iCurrCol++;
				}
				else if (sSubHeading == modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]))
				{
					ViewModel.sprReport.Row = iCurrRow + 1;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(report_column)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (iReportColumn == Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"])))
					{
						ViewModel.sprReport.Col = iReportColumn + 4;
						ViewModel.sprReport.Text = modGlobal.Clean(ViewModel.sprReport.Text) + " / " + modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
						ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
						ViewModel.sprReport.Row = iCurrRow + 2;
						ViewModel.sprReport.Text = iReportColumn.ToString();
						//                sprReport.Text = Clean(TrainCL.TrainingRecord("trn_specific_code"])
						iCurrCol++;
					}
				}
				else
				{
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Row = iCurrRow + 1;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Row = iCurrRow + 2;
					ViewModel.sprReport.Text = iReportColumn.ToString();
					//            sprReport.Text = Clean(TrainCL.TrainingRecord("trn_specific_code"])
					iCurrCol++;
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}

		public void LoadLists()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			ViewModel.cboYear.Items.Clear();
			if (TrainCL.GetTrainingStandardYearList() != 0)
			{

				while(!TrainCL.TrainingRecord.EOF)
				{
					ViewModel.cboYear.AddItem(modGlobal.Clean(TrainCL.TrainingRecord["trn_year"]));
					TrainCL.TrainingRecord.MoveNext();
				};
			}
			ViewModel.cboType.Items.Clear();
			if (TrainCL.GetTrainingStandardCodeList() != 0)
			{

				while(!TrainCL.TrainingRecord.EOF)
				{
					ViewModel.cboType.AddItem(modGlobal.Clean(TrainCL.TrainingRecord["standard_description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["standard_type"])));
					TrainCL.TrainingRecord.MoveNext();
				};
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.CurrQuarter = 0;
			for (int i = 0; i <= 3; i++)
			{
				ViewModel.OptQuarter[i].Checked = false;
			}
			ViewModel.CurrType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);

			FormatHeadings2();
			FormatReport2();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrYear = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboYear.Text));

			if ( ViewModel.CurrQuarter != 0)
			{
				FormatHeadings();
				FormatReport();
			}
			else if ( ViewModel.CurrType != 0)
			{
				FormatHeadings2();
				FormatReport2();
			}
			else
			{
				ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//Set Defaults
			if (DateTime.Now.Month == 1)
			{
				ViewModel.CurrYear = DateTime.Now.Year - 1;
			}
			else
			{
				ViewModel.CurrYear = DateTime.Now.Year;
			}
			ViewModel.cboYear.Text = ViewModel.CurrYear.ToString();
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboType.Text = "";
			ViewModel.CurrType = 0;

			switch(DateTime.Now.Month)
			{
				case 12 : case 11 : case 1 :
					ViewModel.OptQuarter[3].Checked = true;
					ViewModel.CurrQuarter = 4;
					break;
				case 10 : case 9 : case 8 :
					ViewModel.OptQuarter[2].Checked = true;
					ViewModel.CurrQuarter = 3;
					break;
				case 7 : case 6 : case 5 :
					ViewModel.OptQuarter[1].Checked = true;
					ViewModel.CurrQuarter = 2;
					break;
				default:
					ViewModel.OptQuarter[0].Checked = true;
					ViewModel.CurrQuarter = 1;
					break;
			}
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";

			FormatHeadings();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				modGlobal.Shared.gExcelPath = "";
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgExport.DefInstance, true);
					});
				async1.Append(() =>
					{
						if (modGlobal.Shared.gExcelPath == "")
						{
							this.Return();
							return ;
						}

						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ExportToExcel was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						if (!ViewModel.sprReport.ExportToExcel(modGlobal.Shared.gExcelPath, "TFD Quarterly Report", ""))
						{
							ViewManager.ShowMessage("Error attempting to export Excel file", "PTS Training Tracker", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					});
			}
					}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Training Quarterly Standards"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Training Minimum Standards Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			LoadLists();

			//Set Defaults
			if (DateTime.Now.Month == 1)
			{
				ViewModel.CurrYear = DateTime.Now.Year - 1;
			}
			else
			{
				ViewModel.CurrYear = DateTime.Now.Year;
			}
			ViewModel.cboYear.Text = ViewModel.CurrYear.ToString();

			switch(DateTime.Now.Month)
			{
				case 12 : case 11 : case 1 :
					ViewModel.OptQuarter[3].Checked = true;
					ViewModel.CurrQuarter = 4;
					break;
				case 10 : case 9 : case 8 :
					ViewModel.OptQuarter[2].Checked = true;
					ViewModel.CurrQuarter = 3;
					break;
				case 7 : case 6 : case 5 :
					ViewModel.OptQuarter[1].Checked = true;
					ViewModel.CurrQuarter = 2;
					break;
				default:
					ViewModel.OptQuarter[0].Checked = true;
					ViewModel.CurrQuarter = 1;
					break;
			}
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrType = 0;
			ViewModel.FirstTime = false;
			FormatHeadings();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "1";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "2";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "3";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "A";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "B";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "C";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "D";

				if ( ViewModel.CurrQuarter != 0)
				{
					FormatHeadings();
					FormatReport();
				}
				else if ( ViewModel.CurrType != 0)
				{
					FormatHeadings2();
					FormatReport2();
				}
				else
				{
					ViewManager.ShowMessage("Please Select Quarter or Standard Type.", "Minimum Standard Drills Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptQuarter_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				int Index =this.ViewModel.OptQuarter.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);

				if ( ViewModel.FirstTime)
				{
					return;
				}

				switch(Index)
				{
					case 3 :
						ViewModel.CurrQuarter = 4;
						break;
					case 2 :
						ViewModel.CurrQuarter = 3;
						break;
					case 1 :
						ViewModel.CurrQuarter = 2;
						break;
					default:
						ViewModel.CurrQuarter = 1;
						break;
				}
				ViewModel.cboType.SelectedIndex = -1;
				ViewModel.cboType.Text = "";
				ViewModel.CurrType = 0;

				FormatHeadings();
				FormatReport();

			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTrainQuarterlyReport DefInstance
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

		public static frmTrainQuarterlyReport CreateInstance()
		{
			PTSProject.frmTrainQuarterlyReport theInstance = Shared.Container.Resolve< frmTrainQuarterlyReport>();
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

	public partial class frmTrainQuarterlyReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainQuarterlyReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTrainQuarterlyReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}