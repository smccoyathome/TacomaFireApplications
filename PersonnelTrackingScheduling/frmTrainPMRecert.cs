using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmTrainPMRecert
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainPMRecertViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTrainPMRecert));
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


		private void frmTrainPMRecert_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//           TFD Training Paramedic Recertification
		//       Paramedics Filtered by DateRane, Battalion/Shift
		//*************************************************************

		private void FormatReport()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			bool bDisplay = false;

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport2.Row = 6;
			ViewModel.sprReport2.Row2 = ViewModel.sprReport2.MaxRows;
			ViewModel.sprReport2.Col = 1;
			ViewModel.sprReport2.Col2 = ViewModel.sprReport2.MaxCols;
			ViewModel.sprReport2.BlockMode = true;
			ViewModel.sprReport2.Text = "";
			ViewModel.sprReport2.BlockMode = false;

			if (TrainCL.GetTrainingPMRecertificationReport(ViewModel.dtStart.Text, ViewModel.dtEnd.Text, ViewModel.CurrBatt, ViewModel.CurrShift, ViewModel.CurrGroup) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There are no Employee/Training Records to report!", "Training Paramedic Recertification", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sEmployeeName = "";
			int iCodeRow = 5;
			int iCurrRow = 6;
			int iCurrCol = 1;

			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport2.Row = iCurrRow;
				ViewModel.sprReport2.Col = iCurrCol;
				bDisplay = false;
				if (sEmployeeName == "")
				{ //first time
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport2.Text = sEmployeeName;
					ViewModel.sprReport2.Col = iCurrCol + 1;
					if (modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]) == "")
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					}
					else if (modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]) == "*")
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					}
					else
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + " " +
									modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					}
					ViewModel.sprReport2.Col = iCurrCol + 2;
					ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["group_number"]);
					ViewModel.sprReport2.Col = iCurrCol + 3;
					if (modGlobal.Clean(TrainCL.TrainingRecord["recert_date"]) == "")
					{
						ViewModel.sprReport2.Text = "";
					}
					else
					{
						ViewModel.sprReport2.Text = Convert.ToDateTime(TrainCL.TrainingRecord["recert_date"]).ToString("M/d/yyyy");
					}
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						ViewModel.sprReport2.Row = iCodeRow;
						int tempForVar = ViewModel.sprReport2.MaxCols;
						for (int i = 5; i <= tempForVar; i++)
						{
							ViewModel.sprReport2.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport2.Text))
							{
								ViewModel.sprReport2.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal(sprReport2.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport2.Text)) == 3)
								{
									bDisplay = true;
								}
								ViewModel.sprReport2.Col = i;
								ViewModel.sprReport2.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]) != "")
								{
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]);
									ViewModel.sprReport2.Col = i + 1;
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["TotalHours"]);
									//                            If bDisplay Then
									//                                sprReport2.Col = i + 2
									//                                sprReport2.Text = Clean(TrainCL.TrainingRecord("FlagComment"])
									//                            End If
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
						ViewModel.sprReport2.Row = iCodeRow;
						int tempForVar2 = ViewModel.sprReport2.MaxCols;
						for (int i = 5; i <= tempForVar2; i++)
						{
							ViewModel.sprReport2.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport2.Text))
							{
								ViewModel.sprReport2.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal(sprReport2.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport2.Text)) == 3)
								{
									bDisplay = true;
								}
								ViewModel.sprReport2.Col = i;
								ViewModel.sprReport2.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]) != "")
								{
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]);
									ViewModel.sprReport2.Col = i + 1;
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["TotalHours"]);
									//                            If bDisplay Then
									//                                sprReport2.Col = i + 2
									//                                sprReport2.Text = Clean(TrainCL.TrainingRecord("FlagComment"])
									//                            End If
								}

								break;
							}
						}
					}
				}
				else
				{
					iCurrRow++;
					ViewModel.sprReport2.Row = iCurrRow;
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport2.Text = sEmployeeName;
					ViewModel.sprReport2.Col = iCurrCol + 1;
					if (modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]) == "")
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					}
					else if (modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]) == "*")
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
					}
					else
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + " " +
									modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					}
					ViewModel.sprReport2.Col = iCurrCol + 2;
					if (modGlobal.Clean(TrainCL.TrainingRecord["group_number"]) == "0")
					{
						ViewModel.sprReport2.Text = "";
					}
					else
					{
						ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["group_number"]);
					}
					ViewModel.sprReport2.Col = iCurrCol + 3;
					if (modGlobal.Clean(TrainCL.TrainingRecord["recert_date"]) == "")
					{
						ViewModel.sprReport2.Text = "";
					}
					else
					{
						ViewModel.sprReport2.Text = Convert.ToDateTime(TrainCL.TrainingRecord["recert_date"]).ToString("M/d/yyyy");
					}
					if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) != "")
					{
						ViewModel.sprReport2.Row = iCodeRow;
						int tempForVar3 = ViewModel.sprReport2.MaxCols;
						for (int i = 5; i <= tempForVar3; i++)
						{
							ViewModel.sprReport2.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["report_column"]) == modGlobal.Clean(ViewModel.sprReport2.Text))
							{
								ViewModel.sprReport2.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal(sprReport2.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(ViewModel.sprReport2.Text)) == 3)
								{
									bDisplay = true;
								}
								ViewModel.sprReport2.Col = i;
								ViewModel.sprReport2.Row = iCurrRow;
								if (modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]) != "")
								{
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["LatestDate"]);
									ViewModel.sprReport2.Col = i + 1;
									ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["TotalHours"]);
									if (bDisplay)
									{
										ViewModel.sprReport2.Col = i + 2;
										ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["FlagComment"]);
									}
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

		private void FormatHeadings()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport2.Row = 3;
			ViewModel.sprReport2.Row2 = 5;
			ViewModel.sprReport2.Col = 1;
			ViewModel.sprReport2.Col2 = ViewModel.sprReport2.MaxCols;
			ViewModel.sprReport2.BlockMode = true;
			ViewModel.sprReport2.Text = "";
			ViewModel.sprReport2.BlockMode = false;

			string sHeading = "Paramedic Recertification Report From ";
			sHeading = sHeading + ViewModel.dtStart.Text + " Thru " + ViewModel.dtEnd.Text;
			ViewModel.sprReport2.Row = 2;
			ViewModel.sprReport2.Col = 1;
			ViewModel.sprReport2.Text = sHeading;
			ViewModel.sprReport2.Row = 3;
			ViewModel.sprReport2.Col = 1;
			ViewModel.sprReport2.Text = "Name";
			ViewModel.sprReport2.Col = 2;
			ViewModel.sprReport2.Text = "Unit Shift";
			ViewModel.sprReport2.Col = 3;
			ViewModel.sprReport2.Text = "Grp";
			ViewModel.sprReport2.Col = 4;
			ViewModel.sprReport2.Text = "Certification Expiration";

			//ACLS
			ViewModel.sprReport2.Row = 4;
			ViewModel.sprReport2.Col = 5;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 6;
			ViewModel.sprReport2.Text = "Hrs";

			//Airway - PAM
			ViewModel.sprReport2.Col = 7;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 8;
			ViewModel.sprReport2.Text = "Hrs";

			//Airway - R1
			ViewModel.sprReport2.Col = 9;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 10;
			ViewModel.sprReport2.Text = "Hrs";

			//Airway - R2
			ViewModel.sprReport2.Col = 11;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 12;
			ViewModel.sprReport2.Text = "Hrs";

			//PHTLS
			ViewModel.sprReport2.Col = 13;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 14;
			ViewModel.sprReport2.Text = "Hrs";

			//Trauma
			ViewModel.sprReport2.Col = 15;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 16;
			ViewModel.sprReport2.Text = "Hrs";

			//AMLS
			ViewModel.sprReport2.Col = 17;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 18;
			ViewModel.sprReport2.Text = "Hrs";

			//Medical
			ViewModel.sprReport2.Col = 19;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 20;
			ViewModel.sprReport2.Text = "Hrs";

			//PALS
			ViewModel.sprReport2.Col = 21;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 22;
			ViewModel.sprReport2.Text = "Hrs";

			//Pediatrics
			ViewModel.sprReport2.Col = 23;
			ViewModel.sprReport2.Text = "Year";
			ViewModel.sprReport2.Col = 24;
			ViewModel.sprReport2.Text = "Hrs";

			if (TrainCL.GetTrainingParamedicRecertClasses() != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oh No! There are no Training Paramedic Recertification Class for Report!", "Training Annual OTEP Report", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			int iCurrRow = 3;
			int iCodeRow = 5;
			int iReportColumn = 1;


			while(!TrainCL.TrainingRecord.EOF)
			{

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				iReportColumn = Convert.ToInt32(modGlobal.GetVal(TrainCL.TrainingRecord["report_column"]));
				ViewModel.sprReport2.Row = iCurrRow;
				ViewModel.sprReport2.Col = iReportColumn;
				ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
				ViewModel.sprReport2.Row = iCodeRow;
				ViewModel.sprReport2.Text = iReportColumn.ToString();
				ViewModel.sprReport2.Col = iReportColumn + 1;
				ViewModel.sprReport2.Text = modGlobal.Clean(TrainCL.TrainingRecord["number_of_cols"]);

				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Set Defaults
			System
				.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
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
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintAbortMsg("Printing Training Paramedic Recertification Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport2.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport2.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport2.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport2.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FormatHeadings();
			FormatReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FormatHeadings();
			FormatReport();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;

			//Set Defaults
			System
				.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.optGrp1.Checked = false;
			ViewModel.optGrp2.Checked = false;
			ViewModel.optGrp3.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
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

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTrainPMRecert DefInstance
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

		public static frmTrainPMRecert CreateInstance()
		{
			PTSProject.frmTrainPMRecert theInstance = Shared.Container.Resolve< frmTrainPMRecert>();
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
			ViewModel.sprReport2.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			ViewModel.sprReport2.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTrainPMRecert
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainPMRecertViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTrainPMRecert m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}