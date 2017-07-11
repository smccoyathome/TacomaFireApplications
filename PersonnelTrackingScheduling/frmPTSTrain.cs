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

	public partial class frmPTSTrain
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPTSTrainViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPTSTrain));
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


		private void frmPTSTrain_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		private void LoadLists()
		{
			//Load Lists
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			ViewModel.cboUnitList.Items.Clear();
			UnitCL.TFDUnitListRS();
			//        cboUnitList.ADDItem "OPER"

			while(!UnitCL.Unit.EOF)
			{
				ViewModel.cboUnitList.AddItem(modGlobal.Clean(UnitCL.Unit["unit_code"]));
				UnitCL.Unit.MoveNext();
			};
			ViewModel.cboAllStaff.Items.Clear();
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if (modGlobal.Shared.gSecurity != "ADM")
			{
				oCmd.CommandText = "spOpNameListForField";
			}
			else
			{
				//            oCmd.CommandText = "spOpNameList"
				oCmd.CommandText = "spFullNameList";
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				this.ViewModel.cboAllStaff.AddItem(strName);
				oRec.MoveNext();
			};
			ViewModel.cboPrimary.Clear();
			TrainCL.GetPrimaryCodesForField();

			while(!TrainCL.TrainingPrimaryCode.EOF)
			{
				ViewModel.cboPrimary.AddItem(modGlobal.Clean(TrainCL.TrainingPrimaryCode["description"]));
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.cboPrimary.setItemData(Convert.ToInt32(TrainCL.TrainingPrimaryCode["trn_primary_code"]), ViewModel.cboPrimary.getNewIndex());
				TrainCL.TrainingPrimaryCode.MoveNext();
			};

		}

		private int DetermineSecurity()
		{
			int result = 0;
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			//Opening up to everyone...
			result = -1;
			ViewModel.NoLimitUpdate = true;
			ViewModel.PreventionOnly = false;
			ViewModel.FieldOnly = false;

			if (modGlobal.Shared.gSecurity == "ADM")
			{
				//        NoLimitUpdate = True
				//        DetermineSecurity = True
				//        Exit Function
				if ( ViewModel.FirstTime)
				{
					ViewModel.cboPrimary.AddItem("Formal Training");
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboPrimary.setItemData(1, ViewModel.cboPrimary.getNewIndex());
					ViewModel.cboPrimary.AddItem("Paramedic Additional Training");
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboPrimary.setItemData(16, ViewModel.cboPrimary.getNewIndex());
					ViewModel.cboPrimary.AddItem("Prevention and Preparedness Bureau");
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboPrimary.setItemData(10, ViewModel.cboPrimary.getNewIndex());

				}
				return result;
			}

			//    If TrainCL.GetTrainingInfoForSecurity(gUser, Format$(calTrainDate.Value, "m/d/yyyy")); Then
			if (TrainCL.GetTrainingInfoForSecurity(modGlobal.Shared.gUser, ViewModel.calTrainDate.SelectionRange.Start.ToString("M/d/yyyy")) != 0)
			{
				if (modGlobal.Clean(TrainCL.TrainingRecord["AssignPosition"]) == "DFM" || modGlobal.Clean(TrainCL.TrainingRecord["CurrPosition"]) == "DFM")
				{
					ViewModel.PreventionOnly = true;
					//            DetermineSecurity = True
					if ( ViewModel.FirstTime)
					{
						//                cboPrimary.Clear
						ViewModel.cboPrimary.AddItem("Prevention and Preparedness Bureau");
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboPrimary.setItemData(10, ViewModel.cboPrimary.getNewIndex());
					}
				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["AssignUnit"]) == "TRN" || modGlobal.Clean(TrainCL.TrainingRecord["CurrUnit"]) == "TRN")
				{
					//                NoLimitUpdate = True
					//                DetermineSecurity = True
					if ( ViewModel.FirstTime)
					{
						//                   cboPrimary.Clear
						ViewModel.cboPrimary.AddItem("Formal Training");
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboPrimary.setItemData(1, ViewModel.cboPrimary.getNewIndex());
						ViewModel.cboPrimary.AddItem("Paramedic Additional Training");
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.cboPrimary.setItemData(16, ViewModel.cboPrimary.getNewIndex());
					}
				}
				else
				{
					//        ElseIf Clean(TrainCL.TrainingRecord("AssignUnit"]) = Clean(cboUnitList) Or _
					//'            Clean(TrainCL.TrainingRecord("CurrUnit"]) = Clean(cboUnitList) Then
					ViewModel.FieldOnly = true;
					//            DetermineSecurity = True
					//        Else
					//            DetermineSecurity = False
					//            Exit Function
				}
			}
			else
			{
				//        DetermineSecurity = False
				return result;
			}

			return result;
		}

		private void LoadHours()
		{
			ViewModel.cboHours.Items.Clear();
			ViewModel.cboHours.AddItem("0.25");
			ViewModel.cboHours.AddItem("0.5");
			ViewModel.cboHours.AddItem("0.75");
			ViewModel.cboHours.AddItem("1");
			ViewModel.cboHours.AddItem("1.25");
			ViewModel.cboHours.AddItem("1.5");
			ViewModel.cboHours.AddItem("1.75");
			ViewModel.cboHours.AddItem("2");
			ViewModel.cboHours.AddItem("2.25");
			ViewModel.cboHours.AddItem("2.5");
			ViewModel.cboHours.AddItem("2.75");
			ViewModel.cboHours.AddItem("3");
			ViewModel.cboHours.AddItem("3.25");
			ViewModel.cboHours.AddItem("3.5");
			ViewModel.cboHours.AddItem("3.75");
			ViewModel.cboHours.AddItem("4");
			ViewModel.cboHours.AddItem("4.25");
			ViewModel.cboHours.AddItem("4.5");
			ViewModel.cboHours.AddItem("4.75");
			ViewModel.cboHours.AddItem("5");
			ViewModel.cboHours.AddItem("5.25");
			ViewModel.cboHours.AddItem("5.5");
			ViewModel.cboHours.AddItem("5.75");
			ViewModel.cboHours.AddItem("6");
			ViewModel.cboHours.AddItem("6.25");
			ViewModel.cboHours.AddItem("6.5");
			ViewModel.cboHours.AddItem("6.75");
			ViewModel.cboHours.AddItem("7");
			ViewModel.cboHours.AddItem("7.25");
			ViewModel.cboHours.AddItem("7.5");
			ViewModel.cboHours.AddItem("7.75");
			ViewModel.cboHours.AddItem("8");
			ViewModel.cboHours.SelectedIndex = -1;
		}

		private void ClearScreen()
		{
			//Clear Variables for new unit/date
			ViewModel.lstUnitStaff.Items.Clear();
			ViewModel.lstTrainStaff.Items.Clear();
			ViewModel.lstTrainStaff.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboUnitList.SelectedIndex = -1;
			ViewModel.cboAllStaff.Text = "";
			ViewModel.cboAllStaff.SelectedIndex = -1;
			ViewModel.cboPrimary.Text = "";
			ViewModel.cboPrimary.ListIndex = -1;
			ViewModel.cboPrimary.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboSecondary.Text = "";
			ViewModel.cboSecondary.Clear();
			ViewModel.cboSecondary.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.lstSpecific.Items.Clear();
			ViewModel.lstSpecific.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.cboHours.SelectedIndex = -1;
			ViewModel.cboHours.BackColor = modGlobal.Shared.REQCOLOR;
			ViewModel.txtComments.Text = "";
			ViewModel.frmPassFail.Visible = false;
			ViewModel.optPass.Checked = false;
			ViewModel.optFail.Checked = false;
			ViewModel.chkInstructor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkProvider.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmProvInst.Visible = false;
			ViewModel.frmCategories.Visible = false;
			ViewModel.OptCat1.Checked = false;
			ViewModel.OptCat2.Checked = false;
			ViewModel.OptCat3.Checked = false;
			ViewModel.OptCat4.Checked = false;
			ViewModel.cmdSave.Enabled = false;

		}

		private void CheckForSave()
		{
			//Check to determine if enough info entered to enable save button

			if (~DetermineSecurity() != 0)
			{
				return;
			}
			int SaveOk = -1;
			//    If cboUnitList.ListIndex = -1 Then
			//        SaveOk = False
			//        cboUnitList.BackColor = REQCOLOR
			//        cboUnitList.ForeColor = WHITE
			//    Else
			//        cboUnitList.BackColor = WHITE
			//        cboUnitList.ForeColor = BLACK
			//    End If
			if ( ViewModel.lstTrainStaff.Items.Count == 0)
			{
				SaveOk = 0;
				ViewModel.lstTrainStaff.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.lstTrainStaff.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.lstTrainStaff.BackColor = modGlobal.Shared.WHITE;
				ViewModel.lstTrainStaff.ForeColor = modGlobal.Shared.BLACK;
			}

			if ( ViewModel.cboPrimary.ListIndex == -1)
			{
				SaveOk = 0;
				ViewModel.cboPrimary.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.cboPrimary.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.cboPrimary.BackColor = modGlobal.Shared.WHITE;
				ViewModel.cboPrimary.ForeColor = modGlobal.Shared.BLACK;
			}

			if ( ViewModel.cboSecondary.ListIndex == -1)
			{
				SaveOk = 0;
				ViewModel.cboSecondary.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.cboSecondary.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.cboSecondary.BackColor = modGlobal.Shared.WHITE;
				ViewModel.cboSecondary.ForeColor = modGlobal.Shared.BLACK;
			}

			int SpecificSelected = 0;
			for (int i = 0; i <= ViewModel.lstSpecific.Items.Count - 1; i++)
			{
				if ( ViewModel.lstSpecific.SelectedIndices.Contains(i))
				{
					SpecificSelected = -1;
					//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.lSpecificID = ViewModel.lstSpecific.ItemData(i);
				}
			}
			if (SpecificSelected != 0)
			{
				ViewModel.lstSpecific.BackColor = modGlobal.Shared.WHITE;
				ViewModel.lstSpecific.ForeColor = modGlobal.Shared.BLACK;
			}
			else
			{
				ViewModel.lstSpecific.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.lstSpecific.ForeColor = modGlobal.Shared.WHITE;
				SaveOk = 0;
			}

			if ( ViewModel.cboHours.Visible)
			{
				if ( ViewModel.cboHours.Text == "")
				{
					SaveOk = 0;
					ViewModel.cboHours.BackColor = modGlobal.Shared.REQCOLOR;
					ViewModel.cboHours.ForeColor = modGlobal.Shared.WHITE;
				}
				else
				{
					ViewModel.cboHours.BackColor = modGlobal.Shared.WHITE;
					ViewModel.cboHours.ForeColor = modGlobal.Shared.BLACK;
				}
			}
			ViewModel.cmdSave.Enabled = SaveOk != 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void calTrainDate_MouseUp(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			//Get Staff for Selected Unit / Date
			string ListString = "";
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			string TrainDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(ViewModel.calTrainDate.SelectionRange.Start);
			TrainDate = TrainDate + " 8:00AM";
			if ( ViewModel.cboUnitList.SelectedIndex == -1)
			{
				return;
			}

			string TrainUnit = modGlobal.Clean(ViewModel.cboUnitList.Text);
			ViewModel.lstUnitStaff.Items.Clear();
			if (UnitCL.GetPTSPersonnel(TrainUnit, TrainDate) != 0)
			{

				while(!UnitCL.UnitPersonnel.EOF)
				{
					ListString = modGlobal.Clean(UnitCL.UnitPersonnel["emp_id"]);
					if (TrainCL.GetEmployee(ListString) != 0)
					{
						ListString = modGlobal.Clean(TrainCL.Employee["name_full"]) + " :" + Convert.ToString(TrainCL.Employee["employee_id"]);
						ViewModel.lstUnitStaff.AddItem(ListString);
					}
					UnitCL.UnitPersonnel.MoveNext();
				};
			}

		}

		//UPGRADE_WARNING: (2074) ComboBox event cboHours.Change was upgraded to cboHours.TextChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void cboHours_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.isInitializingComponent)
			{
				return;
			}
			//Check of valid entry
			if ( ViewModel.cboHours.SelectedIndex == -1)
			{
				ViewModel.cboHours.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.cboHours.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.cboHours.BackColor = modGlobal.Shared.WHITE;
				ViewModel.cboHours.ForeColor = modGlobal.Shared.BLACK;
				CheckForSave();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboHours_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Check of valid entry
			if ( ViewModel.cboHours.SelectedIndex == -1)
			{
				ViewModel.cboHours.BackColor = modGlobal.Shared.REQCOLOR;
				ViewModel.cboHours.ForeColor = modGlobal.Shared.WHITE;
			}
			else
			{
				ViewModel.cboHours.BackColor = modGlobal.Shared.WHITE;
				ViewModel.cboHours.ForeColor = modGlobal.Shared.BLACK;
				CheckForSave();
			}
		}

		private void cboPrimary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPrimary.Clicked)
			{
				//Load cboSecondary combobox
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.cboPrimary.ListIndex == -1)
				{
					return;
				}
				ViewModel.cboHours.Text = "";
				ViewModel.frmProvInst.Visible = false;
				ViewModel.chkInstructor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkProvider.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.frmCategories.Visible = false;
				ViewModel.OptCat1.Checked = false;
				ViewModel.OptCat2.Checked = false;
				ViewModel.OptCat3.Checked = false;
				ViewModel.OptCat4.Checked = false;
				ViewModel.frmPassFail.Visible = false;
				ViewModel.optPass.Checked = false;
				ViewModel.optFail.Checked = false;
				ViewModel.cboSecondary.ListIndex = -1;
				ViewModel.cboSecondary.Clear();
				ViewModel.lstSpecific.Items.Clear();
				if ( ViewModel.FieldOnly)
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					if (TrainCL.GetSecondaryCodesForField(ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex)) != 0)
					{
						//continue
					}
					else
					{
						return;
					}
				}
				else
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboPrimary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					if (TrainCL.GetSecondaryCodesByPrimary(ViewModel.cboPrimary.ItemData(ViewModel.cboPrimary.ListIndex)) != 0)
					{
						//continue
					}
					else
					{
						return;
					}
				}


				while(!TrainCL.TrainingSecondaryCode.EOF)
				{
					ViewModel.cboSecondary.AddItem(modGlobal.Clean(TrainCL.TrainingSecondaryCode["description"]));
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.cboSecondary.setItemData(Convert.ToInt32(TrainCL.TrainingSecondaryCode["trn_secondary_code"]), ViewModel.cboSecondary.getNewIndex());
					TrainCL.TrainingSecondaryCode.MoveNext();
				}
				;
				CheckForSave();
			}
			ViewModel.cboPrimary.Clicked = false;
		}

		private void cboSecondary_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboSecondary.Clicked)
			{
				//Load lst combobox
				PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

				if ( ViewModel.cboSecondary.ListIndex == -1)
				{
					return;
				}
				ViewModel.lstSpecific.Items.Clear();
				ViewModel.frmProvInst.Visible = false;
				ViewModel.chkInstructor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkProvider.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.frmCategories.Visible = false;
				ViewModel.OptCat1.Checked = false;
				ViewModel.OptCat2.Checked = false;
				ViewModel.OptCat3.Checked = false;
				ViewModel.OptCat4.Checked = false;
				ViewModel.frmPassFail.Visible = false;
				ViewModel.optPass.Checked = false;
				ViewModel.optFail.Checked = false;
				if ( ViewModel.FieldOnly)
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					if (TrainCL.GetSpecificCodesForField(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex)) != 0)
					{
						//continue
					}
					else
					{
						return;
					}
				}
				else
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					if (TrainCL.GetSpecificCodesBySecondary(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex)) != 0)
					{
						//continue
					}
					else
					{
						return;
					}
				}

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
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.CheckForAffirmationDisplay(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex));
				if (!TrainCL.TrainingSpecificCode.EOF)
				{
					//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					modGlobal
						.Shared.gSecondaryID = ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex);
					modGlobal.Shared.gMessageText = modGlobal.Clean(TrainCL.TrainingSpecificCode["message_txt"]);
				}
				else
				{
					modGlobal.Shared.gSecondaryID = 0;
					modGlobal.Shared.gMessageText = "";
				}
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboSecondary.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				TrainCL.GetSecondaryCodeByID(ViewModel.cboSecondary.ItemData(ViewModel.cboSecondary.ListIndex));
				if (!TrainCL.TrainingSpecificCode.EOF)
				{
					if (Convert.ToDouble(TrainCL.TrainingSpecificCode["track_hours_flag"]) == 0)
					{
						ViewModel.cboHours.Visible = false;
						ViewModel.cboHours.SelectedIndex = -1;
						ViewModel.lbHours.Visible = false;
					}
					else
					{
						ViewModel.cboHours.Visible = true;
						ViewModel.lbHours.Visible = true;
					}
				}
				else
				{
					ViewModel.cboHours.Visible = true;
					ViewModel.lbHours.Visible = true;
				}
				CheckForSave();
			}
			ViewModel.cboSecondary.Clicked = false;
		}

		//Mobilize: Not supported: UPGRADE_WARNING: (2050) LpADOLib.fpComboAdo Event cboSecondary.TextTipFetch was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx
		//private void cboSecondary_TextTipFetch(int ColOrGrp, int Row, LpADOLib.MultiLineConstants MultiLine, ref float TipWidth, LpADOLib.AlignHConstants AlignH, float OffsetX, float OffsetY, string TipText, ref bool ShowTip)
		//{
		//	ShowTip = true;
		//	TipWidth = 3000;
		//}
		[UpgradeHelpers.Events.Handler]
		internal void cboUnitList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Get Staff for Selected Unit / Date
			string ListString = "";
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.cboUnitList.SelectedIndex == -1)
			{
				return;
			}

			string TrainUnit = ViewModel.cboUnitList.Text;
			string TrainDate = ViewModel.calTrainDate.SelectionRange.Start.ToString("MM/dd/yyyy") + " 8:00AM";
			//    ClearScreen
			if (UnitCL.GetPTSPersonnel(TrainUnit, TrainDate) != 0)
			{

				while(!UnitCL.UnitPersonnel.EOF)
				{
					ListString = modGlobal.Clean(UnitCL.UnitPersonnel["emp_id"]);
					if (TrainCL.GetEmployee(ListString) != 0)
					{
						ListString = modGlobal.Clean(TrainCL.Employee["name_full"]) + " :" + Convert.ToString(TrainCL.Employee["employee_id"]);
						ViewModel.lstUnitStaff.AddItem(ListString);
					}
					UnitCL.UnitPersonnel.MoveNext();
				};
			}
			//   CheckForSave
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cmdAdd.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
			//Add selected names to lstTrainStaff listbox
			string TestString = "";

			switch(Index)
			{
				case 0 :  //Add Selected Employee 
					for (int i = 0; i <= ViewModel.lstUnitStaff.Items.Count - 1; i++)
					{
						if ( ViewModel.lstUnitStaff.GetSelected( i))
						{
							TestString = ViewModel.lstUnitStaff.GetListItem(i);
							ViewModel.lstTrainStaff.AddItem(TestString);
							ViewModel.lstUnitStaff.RemoveItem(i);
							break;
						}
					}
					break;
				case 1 :  //Add All Employees listed 
					for (int i = 0; i <= ViewModel.lstUnitStaff.Items.Count - 1; i++)
					{
						ViewModel.lstTrainStaff.AddItem(ViewModel.lstUnitStaff.GetListItem(i));
					}
					ViewModel.lstUnitStaff.Items.Clear();
					break;
				case 2 :  //Add other staff 
					if ( ViewModel.cboAllStaff.SelectedIndex == -1)
					{
						return;
					}
					ViewModel.lstTrainStaff.AddItem(ViewModel.cboAllStaff.Text);
					ViewModel.cboAllStaff.SelectedIndex = -1;
					break;
			}
			CheckForSave();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ClearScreen();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRemove_Click(Object eventSender, System.EventArgs eventArgs)
		{
			int Index =this.ViewModel.cmdRemove.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
			//Remove selected names from lstTrainStaff listbox and add back to lstUnitStaff listbox
			string TestString = "";

			switch(Index)
			{
				case 0 :  //Move Selected Employee 
					for (int i = 0; i <= ViewModel.lstTrainStaff.Items.Count - 1; i++)
					{
						if ( ViewModel.lstTrainStaff.GetSelected( i))
						{
							TestString = ViewModel.lstTrainStaff.GetListItem(i);
							ViewModel.lstUnitStaff.AddItem(TestString);
							ViewModel.lstTrainStaff.RemoveItem(i);
							return;
						}
					}
					break;
				case 1 :  //Remove All Employees listed 
					for (int i = 0; i <= ViewModel.lstTrainStaff.Items.Count - 1; i++)
					{
						ViewModel.lstUnitStaff.AddItem(ViewModel.lstTrainStaff.GetListItem(i));
					}
					ViewModel.lstTrainStaff.Items.Clear();
					break;
			}
			CheckForSave();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Save Training Record
				PTSProject.clsTraining cTraining = Container.Resolve< clsTraining>();

				if ( ViewModel.lSpecificID == 0)
				{
					ViewManager.ShowMessage("Please Select Specific Training Type.", "Save Training Record(s)", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				ViewModel.cmdSave.Enabled = false;

				if (modGlobal.Shared.gSecondaryID != 0)
				{
					async1.Append(() =>
						{
							ViewManager.NavigateToView(
								dlgMessage.DefInstance, true);
						});
					async1.Append(() =>
						{
							if (modGlobal.Shared.gMessageText == "")
							{
								ViewModel.cmdSave.Enabled = false;
								ClearScreen();
								this.Return();
								return ;
							}
						});
						}
				async1.Append(() =>
					{

						if (modGlobal.Clean(ViewModel.txtComments.Text) == "")
						{
							cTraining.RecordComments = "";
						}
						else
						{
							cTraining.RecordComments = modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtComments.Text));
						}

						cTraining.RecordSpecificCode = ViewModel.lSpecificID;
						cTraining.RecordTrainingDate = DateTime.Parse(ViewModel.calTrainDate.SelectionRange.Start.ToString("M/d/yyyy"));
						if ( ViewModel.cboHours.Visible)
						{
							cTraining.RecordHours = (float) Double.Parse(ViewModel.cboHours.Text);
						}
						else
						{
							cTraining.RecordHours = 0;
						}

						cTraining.RecordCreateBy = modPTSPayroll.Shared.gUserSAPid;

						cTraining.RecordProviderFlag = 0;
						cTraining.RecordInstructorFlag = 0;

						if ( ViewModel.frmProvInst.Visible)
						{
							if ( ViewModel.chkProvider.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
							{
								cTraining.RecordProviderFlag = 1;
							}
						}

						if ( ViewModel.frmProvInst.Visible)
						{
							if ( ViewModel.chkInstructor.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
							{
								cTraining.RecordInstructorFlag = 1;
							}
						}

						cTraining.RecordPassFail = "";
						if ( ViewModel.frmPassFail.Visible)
						{
							if ( ViewModel.optPass.Checked)
							{
								cTraining.RecordPassFail = "P";
							}
							else if ( ViewModel.optFail.Checked)
							{
								cTraining.RecordPassFail = "F";
							}
						}

						if ( ViewModel.frmCategories.Visible)
						{
							if ( ViewModel.OptCat1.Checked)
							{
								cTraining.RecordCategoryID = 1;
							}
							else if ( ViewModel.OptCat2.Checked)
							{
								cTraining.RecordCategoryID = 2;
							}
							else if ( ViewModel.OptCat3.Checked)
							{
								cTraining.RecordCategoryID = 3;
							}
							else if ( ViewModel.OptCat4.Checked)
							{
								cTraining.RecordCategoryID = 4;
							}
							else
							{
								cTraining.RecordCategoryID = 0;
							}
						}
						else
						{
							cTraining.RecordCategoryID = 0;
						}

						//will need to loop through the lstTrainStaff
						for (int i = 0; i <= ViewModel.lstTrainStaff.Items.Count - 1; i++)
						{
							cTraining.RecordEmployeeID = ViewModel.lstTrainStaff.GetListItem(i).Substring(Math.Max(ViewModel.lstTrainStaff.GetListItem(i).Length - 5, 0));
							if (~cTraining.AddTrainingRecord() != 0)
							{
								ViewManager.ShowMessage("Ooops! Something is wrong!!  Training Record was not saved.", "Add New Training Record", UpgradeHelpers.Helpers.BoxButtons.OK);
								ViewModel.cmdSave.Enabled = true;
							}
						}
						ViewModel.lbSaveMsg.Visible = true;
						UpgradeSolution1Support.PInvoke.SafeNative.kernel32.Sleep(1500);
						ViewModel.lbSaveMsg.Visible = false;
						ViewModel.cmdSave.Enabled = false;
					});
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			LoadHours();
			ViewModel.calTrainDate.SelectionRange.Start = DateTime.Now;
			ViewModel.calTrainDate.SelectionRange.End = DateTime.Now;
			//        calTrainDate.Value = Now()
			LoadLists();
			ClearScreen();
			ViewModel.FirstTime = true;
			if (DetermineSecurity() != 0)
			{
				ViewModel.FirstTime = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstSpecific_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			//If lstSpecific.ListIndex = -1 Then Exit Sub
			ViewModel.chkProvider.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkInstructor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.OptCat1.Checked = false;
			ViewModel.OptCat2.Checked = false;
			ViewModel.OptCat3.Checked = false;
			ViewModel.OptCat4.Checked = false;
			ViewModel.frmCategories.Visible = false;
			ViewModel.frmProvInst.Visible = false;
			ViewModel.frmPassFail.Visible = false;

			//UPGRADE_ISSUE: (2064) LpADOLib.fpListAdo property lstSpecific.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if (TrainCL.GetSpecificCodeByID(ViewModel.lstSpecific.ItemData(ViewModel.lstSpecific.SelectedIndex)) != 0)
			{
				//continue
			}
			else
			{
				return;
			}
			if (!TrainCL.TrainingSpecificCode.EOF)
			{
				if (Convert.ToDouble(TrainCL.TrainingSpecificCode["display_box"]) == 0)
				{
					if (Convert.ToDouble(TrainCL.TrainingSpecificCode["display_score"]) == 0)
					{
						if (Convert.ToDouble(TrainCL.TrainingSpecificCode["display_cat"]) != 0)
						{
							ViewModel.frmCategories.Visible = true;
						}
					}
					else
					{
						ViewModel.frmPassFail.Visible = true;
						ViewModel.optPass.Checked = true;
					}
				}
				else
				{
					ViewModel.frmProvInst.Visible = true;
				}
			}

			CheckForSave();
		}

		//Mobilize: Not supported: UPGRADE_WARNING: (2050) LpADOLib.fpListAdo Event lstSpecific.TextTipFetch was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx
		//private void lstSpecific_TextTipFetch(int ColOrGrp, int Row, LpADOLib.MultiLineConstants MultiLine, ref float TipWidth, LpADOLib.AlignHConstants AlignH, float OffsetX, float OffsetY, string TipText, ref bool ShowTip)
		//{
		//	ShowTip = true;
		//	TipWidth = 3000;
		//}
		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPTSTrain DefInstance
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

		public static frmPTSTrain CreateInstance()
		{
			PTSProject.frmPTSTrain theInstance = Shared.Container.Resolve< frmPTSTrain>();
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
			ViewModel.frmProvInst.LifeCycleStartup();
			ViewModel.frmPassFail.LifeCycleStartup();
			ViewModel.frmCategories.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmProvInst.LifeCycleShutdown();
			ViewModel.frmPassFail.LifeCycleShutdown();
			ViewModel.frmCategories.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPTSTrain
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPTSTrainViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPTSTrain m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}