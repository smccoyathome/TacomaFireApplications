using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmTrainAnnualOTEP
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainAnnualOTEPViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTrainAnnualOTEP));
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


		private void frmTrainAnnualOTEP_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//           Training Annual OTEP Reporting
		//           Filtered by Year, Battalion/Shift
		//*************************************************************

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

			int iGroup = ViewModel.CurrGroup;

			if ( ViewModel.optPM.Checked)
			{
				if (TrainCL.GetPMTrainingAnnualOTEPReport(ViewModel.CurrYear, ViewModel.CurrBatt, ViewModel.CurrShift, iGroup) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("There are no Paramedic/Training Records to report for Year!", "Training Annual OTEPReport", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}

			}
			else
			{
				if (TrainCL.GetTrainingAnnualOTEPReport(ViewModel.CurrYear, ViewModel.CurrBatt, ViewModel.CurrShift, iGroup) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("There are no Employee/Training Records to report for Year!", "Training Annual OTEPReport", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
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
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["state_number"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + "-" + modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(group_number)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (modGlobal.Clean(TrainCL.TrainingRecord["group_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"])) > 0)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"]));
					}
					else
					{
						ViewModel.sprReport.Text = "";
					}

					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) != "")
								{

									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd");
									ViewModel.sprReport.Col = i + 1;

									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["comments"]);
								}
								break;
							}
						}
					}
				}
				else if (sEmployeeName == modGlobal.Clean(TrainCL.TrainingRecord["name_full"]))
				{
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar2 = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar2; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) != "")
								{
									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd");
									ViewModel.sprReport.Col = i + 1;
									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["comments"]);
								}
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
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["state_number"]);
					ViewModel.sprReport.Col = iCurrCol + 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + "-" + modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = iCurrCol + 3;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(group_number)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (modGlobal.Clean(TrainCL.TrainingRecord["group_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"])) > 0)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"]));
					}
					else
					{
						ViewModel.sprReport.Text = "";
					}
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar3 = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar3; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Col = i;
								ViewModel.sprReport.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) != "")
								{
									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("MM/dd");
									if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
									{
									}
									else
									{
									}
									ViewModel.sprReport.Col = i + 1;
									ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["comments"]);
								}
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
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			//    sprReport.BackColor = WHITE
			ViewModel.sprReport.BlockMode = false;

			string sHeading = "Annual OTEP Modules For ";

			sHeading = sHeading + ViewModel.CurrYear.ToString();
			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;

			sHeading = "OTEP Module Reporting For ";
			if ( ViewModel.optPM.Checked)
			{
				if ( ViewModel.CurrShift == "")
				{
					sHeading = sHeading + "Paramedics Only \\ All Shifts";
				}
				else
				{
					sHeading = sHeading + "Paramedics Only \\ Shift " + ViewModel.CurrShift;
				}
				if ( ViewModel.CurrGroup != 0)
				{
					sHeading = sHeading + " \\ Group " + ViewModel.CurrGroup.ToString();
				}
			}
			else
			{
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
					if ( ViewModel.CurrGroup != 0)
					{
						sHeading = sHeading + " \\ Group " + ViewModel.CurrGroup.ToString();
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
					if ( ViewModel.CurrGroup != 0)
					{
						sHeading = sHeading + " \\ Group " + ViewModel.CurrGroup.ToString();
					}
				}
			}
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = "Name";
			ViewModel.sprReport.Col = 2;
			ViewModel.sprReport.Text = "Cert #";
			ViewModel.sprReport.Col = 3;
			ViewModel.sprReport.Text = "Unit";
			ViewModel.sprReport.Col = 4;
			ViewModel.sprReport.Text = "Grp";
			ViewModel.sprReport.Col = 5;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 6;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 7;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 8;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 9;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 10;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 11;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 12;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 13;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 14;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 15;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 16;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 17;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 18;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 19;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 20;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 21;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 22;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 23;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 24;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 25;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 26;
			ViewModel.sprReport.Text = "Skills";
			ViewModel.sprReport.Col = 27;
			ViewModel.sprReport.Text = "Date";
			ViewModel.sprReport.Col = 28;
			ViewModel.sprReport.Text = "Skills";

			if (TrainCL.GetTrainingSchedOTEPByYear(ViewModel.CurrYear) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oh No!  There are no Training Scheduled OTEP Modules set up for Year!", "Training Annual OTEP Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int iCurrRow = 3;
			int iCurrCol = 5;
			int iCodeRow = 6;
			string sSubHeading = "";
			string sModuleName = "";
			int iReportColumn = 1;


			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;
				ViewModel.sprReport.Col = iCurrCol;
				//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(sched_month)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				switch(Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["sched_month"])))
				{
					case 1 :
						sSubHeading = "January";
						break;
					case 2 :
						sSubHeading = "February";
						break;
					case 3 :
						sSubHeading = "March";
						break;
					case 4 :
						sSubHeading = "April";
						break;
					case 5 :
						sSubHeading = "May";
						break;
					case 6 :
						sSubHeading = "June";
						break;
					case 7 :
						sSubHeading = "July";
						break;
					case 8 :
						sSubHeading = "August";
						break;
					case 9 :
						sSubHeading = "September";
						break;
					case 10 :
						sSubHeading = "October";
						break;
					case 11 :
						sSubHeading = "November";
						break;
					case 12 :
						sSubHeading = "December";
						break;
					default:
						sSubHeading = "";
						break;
				}
				ViewModel.sprReport.Text = sSubHeading;
				ViewModel.sprReport.Row = iCurrRow + 1;
				sModuleName = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
				ViewModel.sprReport.Text = sModuleName;
				ViewModel.sprReport.Row = iCodeRow;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
				ViewModel.sprReport.Text = iReportColumn.ToString();

				iCurrCol += 2;
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

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrYear = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboYear.Text));

			FormatHeadings();
			FormatReport();

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
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.optPM.Checked = false;
			ViewModel.optGrp1.Checked = false;
			ViewModel.optGrp2.Checked = false;
			ViewModel.optGrp3.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrGroup = 0;

			FormatHeadings();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Training Quarterly Standards"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Training Annual OTEP Report");
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
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.optGrp1.Checked = false;
			ViewModel.optGrp2.Checked = false;
			ViewModel.optGrp3.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrGroup = 0;
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

				FormatHeadings();
				FormatReport();

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

				FormatHeadings();
				FormatReport();

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

				FormatHeadings();
				FormatReport();
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

				FormatHeadings();
				FormatReport();

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
				ViewModel.CurrGroup = 0;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				ViewModel.optGrp1.Checked = false;
				ViewModel.optGrp2.Checked = false;
				ViewModel.optGrp3.Checked = false;

				FormatHeadings();
				FormatReport();

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

				FormatHeadings();
				FormatReport();

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

				FormatHeadings();
				FormatReport();

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

				FormatHeadings();
				FormatReport();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp1_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				ViewModel.CurrGroup = 1;

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp2_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				ViewModel.CurrGroup = 2;

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp3_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				ViewModel.CurrGroup = 3;

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optPM_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				ViewModel.CurrGroup = 0;
				ViewModel.optAll.Checked = true;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				ViewModel.optGrp1.Checked = false;
				ViewModel.optGrp2.Checked = false;
				ViewModel.optGrp3.Checked = false;

				FormatHeadings();
				FormatReport();

			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTrainAnnualOTEP DefInstance
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

		public static frmTrainAnnualOTEP CreateInstance()
		{
			PTSProject.frmTrainAnnualOTEP theInstance = Shared.Container.Resolve< frmTrainAnnualOTEP>();
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

	public partial class frmTrainAnnualOTEP
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainAnnualOTEPViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTrainAnnualOTEP m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}