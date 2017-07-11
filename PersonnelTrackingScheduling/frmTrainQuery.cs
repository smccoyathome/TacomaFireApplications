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

	public partial class frmTrainQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTrainQuery));
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


		private void frmTrainQuery_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//Training Query Screen
		//   Filtered by Battalion/Shift/Unit
		//   Primary/Secondary/Specific Traing Codes
		//   Employee Name (like statement)
		//
		//*************************************************************


		public void RefreshEmployeeList()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			int iPrimary = 0;
			int lSecondary = 0;
			int lSpecific = 0;
			string sUnit = "";
			byte sFlag = 0;

			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.SkipLogic)
			{
				return;
			}

			int CurrRow = 0;
			ViewModel.sprReport.MaxRows = 500000;

			string sStartDate = DateTime.Parse(ViewModel.dtStart.Text).ToString("M/d/yyyy");
			string sEndDate = DateTime.Parse(ViewModel.dtEnd.Text).AddDays(1).ToString("M/d/yyyy");
			ViewModel.sHeadingFilter = "Displaying ";

			if ( ViewModel.optPM.Checked)
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Paramedic ";
			}

			string sName = modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary));
			string sComment = modGlobal.Clean(Strings.Replace(ViewModel.txtCommentSearch.Text, "'", "''", 1, -1, CompareMethod.Binary));

			if ( ViewModel.OptYes.Checked)
			{
				sFlag = 1;
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Training Attended; ";
			}
			else
			{
				sFlag = 0;
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Training Not Attended; ";
			}


			if ( ViewModel.CurrBatt != "")
			{
				if ( ViewModel.CurrShift != "")
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Batt\\Shift= " + ViewModel.CurrBatt + "\\" + ViewModel.CurrShift + "; ";
				}
			}
			else if ( ViewModel.CurrShift != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Shift= " + ViewModel.CurrShift + "; ";
			}

			if ( ViewModel.cboUnit.ListIndex == -1)
			{
				sUnit = "";
			}
			else
			{
				sUnit = modGlobal.Clean(ViewModel.cboUnit.Text);
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Unit = " + ViewModel.cboUnit.Text + "; ";
			}
			ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "from " + sStartDate + " To " + sEndDate + "; ";

			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				iPrimary = 0;
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				iPrimary = ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex);
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.cboPrimary.Text + "; ";
			}

			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				lSecondary = 0;
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				lSecondary = ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex);
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.cboSecondary.Text + "; ";
			}

			if ( ViewModel.lstSpecific.SelectedIndex == -1)
			{
				lSpecific = 0;
			}
			else
			{
				for (int i = 0; i <= ViewModel.lstSpecific.Items.Count - 1; i++)
				{
					if ( ViewModel.lstSpecific.SelectedIndices.Contains(i))
					{
						//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						lSpecific = ViewModel.lstSpecific.ItemData(i);
						ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.cboSecondary.Text + "; ";
					}
				}
			}


			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.ClearRange(1, 1, ViewModel.sprReport.MaxCols, ViewModel.sprReport.MaxRows, false);

			if ( ViewModel.optPM.Checked)
			{
				if (TrainCL.GetPMTrainingQueryFiltered(sStartDate, sEndDate, iPrimary, lSecondary, lSpecific, ViewModel.CurrShift, sUnit, ViewModel.CurrBatt, sName, sComment, sFlag) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("There were no records returned.  Try changing the filters.", "New PTS Training Query", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			else if (modGlobal.Shared.gSecurity == "ADM")
			{
				if (TrainCL.GetTrainingQueryFiltered(sStartDate, sEndDate, iPrimary, lSecondary, lSpecific, ViewModel.CurrShift, sUnit, ViewModel.CurrBatt, sName, sComment, sFlag) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("There were no records returned.  Try changing the filters.", "New PTS Training Query", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			else
			{
				if (TrainCL.GetTrainingQueryFilteredForField(sStartDate, sEndDate, iPrimary, lSecondary, lSpecific, ViewModel.CurrShift, sUnit, ViewModel.CurrBatt, sName, sComment, sFlag) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("There were no records returned.  Try changing the filters.", "New PTS Training Query", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			while(!TrainCL.TrainingRecord.EOF)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["battalion_code"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["primary_code"]);
				ViewModel.sprReport.Col = 6;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["secondary_code"]);
				ViewModel.sprReport.Col = 7;
				ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["specific_code"]);

				//comment
				if (modGlobal.Clean(TrainCL.TrainingRecord["comments"]) != "")
				{
					ViewModel.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprReport.Col = 7;
					ViewModel.sprReport.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.CellNote = modGlobal.Clean(TrainCL.TrainingRecord["comments"]);
				}
				ViewModel.sprReport.Col = 8;
				if (modGlobal.Clean(TrainCL.TrainingRecord["training_date"]) == "")
				{
					ViewModel.sprReport.Text = "";
				}
				else if (Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("M/d/yyyy") == "1/1/1900")
				{
					ViewModel.sprReport.Text = "";
				}
				else
				{
					ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["training_date"]).ToString("M/d/yyyy");
				}

				//comment
				if (modGlobal.Clean(TrainCL.TrainingRecord["FlagComment"]) != "")
				{
					ViewModel.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprReport.Col = 8;
					ViewModel.sprReport.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.CellNote = modGlobal.Clean(TrainCL.TrainingRecord["FlagComment"]);
				}
				ViewModel.sprReport.Col = 9;
				if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "")
				{
					ViewModel.sprReport.Text = "";
				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["training_hours"]) == "0")
				{
					ViewModel.sprReport.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["training_hours"]));
				}

				if (modGlobal.Clean(TrainCL.TrainingRecord["pass_fail"]) == "F")
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.BlockMode = false;
				}
				else
				{
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.BlockMode = false;
				}

				TrainCL.TrainingRecord.MoveNext();
			}
			;
			ViewModel.lbCount.Text = "Total Count: " + ViewModel.sprReport.DataRowCnt.ToString();
			ViewModel.sprReport.MaxRows = ViewModel.sprReport.DataRowCnt;

		}

		public void FillLists()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			ViewModel.cboUnit.Clear();
			UnitCL.TFDUnitListRS();
			//cboUnit.ADDItem "CSRD"

			while(!UnitCL.Unit.EOF)
			{
				ViewModel.cboUnit.AddItem(modGlobal.Clean(UnitCL.Unit["unit_code"]));
				UnitCL.Unit.MoveNext();
			}
			;
			ViewModel.cboPrimary.Clear();
			TrainCL.GetPrimaryCodes();

			while(!TrainCL.TrainingPrimaryCode.EOF)
			{
				ViewModel.cboPrimary.AddItem(modGlobal.Clean(TrainCL.TrainingPrimaryCode["description"]));
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.cboPrimary.setItemData(Convert.ToInt32(TrainCL.TrainingPrimaryCode["trn_primary_code"]), ViewModel.cboPrimary.getNewIndex());
				TrainCL.TrainingPrimaryCode.MoveNext();
			}
			;


					}

		public void ClearFilters()
		{
			ViewModel.SkipLogic = true;
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.cboUnit.Text = "";
			ViewModel.cboUnit.ListIndex = -1;
			ViewModel.cboPrimary.Text = "";
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.cboSecondary.Text = "";
			ViewModel.cboSecondary.Clear();
			ViewModel.lstSpecific.Text = "";
			ViewModel.lstSpecific.Items.Clear();
			ViewModel.txtNameSearch.Text = "";
			ViewModel.txtCommentSearch.Text = "";
			ViewModel.OptYes.Checked = true;
			ViewModel.SkipLogic = false;
			if ( ViewModel.FirstTime)
			{
				return;
			}

			//    RefreshEmployeeList

		}

		private void cboPrimary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPrimary.Clicked)
			{
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.cboPrimary.ListIndex == -1)
				{
					return;
				}
				ViewModel.cboSecondary.ListIndex = -1;
				ViewModel.cboSecondary.Clear();
				ViewModel.lstSpecific.Items.Clear();

				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.GetSecondaryCodesByPrimary(ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex));


				while(!TrainCL.TrainingSecondaryCode.EOF)
				{
					ViewModel.cboSecondary.AddItem(modGlobal.Clean(TrainCL.TrainingSecondaryCode["description"]));
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboSecondary.setItemData(Convert.ToInt32(TrainCL.TrainingSecondaryCode["trn_secondary_code"]), ViewModel.cboSecondary.getNewIndex());
					TrainCL.TrainingSecondaryCode.MoveNext();
				}
				;
								//    RefreshEmployeeList

							}

			ViewModel.cboPrimary.Clicked = false;
		}

		private void cboSecondary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSecondary.Clicked)
			{
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.cboSecondary.ListIndex == -1)
				{
					return;
				}
				ViewModel.lstSpecific.Items.Clear();
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.GetSpecificCodesBySecondary(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex));


				while(!TrainCL.TrainingSpecificCode.EOF)
				{
					//UPGRADE_WARNING: (2081) AddItem has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
					ViewModel.lstSpecific.Items.Add(modGlobal.Clean(TrainCL.TrainingSpecificCode["description"]));
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.lstSpecific.setItemData(Convert.ToInt32(TrainCL.TrainingSpecificCode["trn_specific_code"]), ViewModel.lstSpecific.getNewIndex());
					TrainCL.TrainingSpecificCode.MoveNext();
				}
				;
								//    RefreshEmployeeList

							}

			ViewModel.cboSecondary.Clicked = false;
		}

		private void cboUnit_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUnit.Clicked)
			{
				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.cboUnit.ListIndex == -1)
				{
					return;
				}
				//    RefreshEmployeeList
			}

			ViewModel.cboUnit.Clicked = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ClearFilters();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintHeader("/lPTS Training Query /n" + ViewModel.sHeadingFilter);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Training Query Grid");
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{

			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			//    RefreshEmployeeList
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			//    RefreshEmployeeList
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sShift = "";
			ViewModel.FirstTime = true;
			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStart.Text = (DateTime.TryParse(DateTime.Now.Month.ToString() + "/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : DateTime.Now.Month.ToString() + "/1/" + DateTime.Now.Year.ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");

			FillLists();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string ShiftDate = DateTime.Now.ToString("M/d/yyyy") + " 7:00AM";
			oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				sShift = modGlobal.Clean(oRec["shift_code"]);
			}

			ClearFilters();

			//    If gUserBatt = "1" Then
			//        CurrBatt = "1"
			//        opt181.Value = True
			//    ElseIf gUserBatt = "2" Then
			//        CurrBatt = "2"
			//        opt182.Value = True
			//    ElseIf gUserBatt = "3" Then
			//        CurrBatt = "3"
			//        opt183.Value = True
			//    End If
			//
			if ( ViewModel.CurrBatt != "")
			{
				if (sShift != "")
				{
					if (sShift == "A")
					{
						ViewModel.optA.Checked = true;
					}
					else if (sShift == "B")
					{
						ViewModel.optB.Checked = true;
					}
					else if (sShift == "C")
					{
						ViewModel.optC.Checked = true;
					}
					else if (sShift == "D")
					{
						ViewModel.optD.Checked = true;
					}
				}
			}
			ViewModel.FirstTime = false;
			//    RefreshEmployeeList

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstSpecific_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
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

				//    RefreshEmployeeList
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptNo_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				//    RefreshEmployeeList
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
				ViewModel.opt181.Checked = false;
				ViewModel.opt182.Checked = false;
				ViewModel.opt183.Checked = false;
				ViewModel.optAll.Checked = false;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;

				//    RefreshEmployeeList
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptYes_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
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
				//    RefreshEmployeeList
			}
		}

		private void sprReport_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprReport.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprReport.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtCommentSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			//    RefreshEmployeeList
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			//    RefreshEmployeeList
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTrainQuery DefInstance
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

		public static frmTrainQuery CreateInstance()
		{
			PTSProject.frmTrainQuery theInstance = Shared.Container.Resolve< frmTrainQuery>();
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

	public partial class frmTrainQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrainQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTrainQuery m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}