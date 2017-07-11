using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgSpecialties
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSpecialtiesViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgSpecialties));
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


		private void dlgSpecialties_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public int CheckEmployeeValid()
		{
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			result = 0;

			if ( ViewModel.optFCCDispatcher.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelSpecialtyByIDType '" + ViewModel.EmployeeID + "', " + "2" + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					result = -1;
				}
			}
			else if ( ViewModel.OptOmitBCList.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelBattCardRemoveListByID " + ViewModel.PersonnelID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					result = -1;
					ViewModel.txtComment.Text = modGlobal.Clean(oRec["comment"]);
					for (int i = 0; i <= ViewModel.cboRemoveCode.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(remove_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["remove_id"])) == ViewModel.cboRemoveCode.GetItemData(i))
						{
							ViewModel.cboRemoveCode.SelectedIndex = i;
							break;
						}
					}
				}
				else
				{
					ViewModel.txtComment.Text = "";
					ViewModel.cboRemoveCode.SelectedIndex = -1;
					ViewModel.cboRemoveCode.Text = "";
				}
			}
			else if ( ViewModel.OptParamedic.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelSpecialtyByIDType '" + ViewModel.EmployeeID + "', " + "1" + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					result = -1;
				}
			}
			else if ( ViewModel.OptTempUpgrade.Checked)
			{
				oCmd.CommandText = "spSelect_PayrollTemporaryUpgradeByID " + ViewModel.PersonnelID.ToString() + " ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					result = -1;
					ViewModel.cboJobCode.Text = modGlobal.Clean(oRec["job_code_id"]);
					ViewModel.cboStep.Text = modGlobal.Clean(oRec["step"]);
				}
				else
				{
					ViewModel.cboJobCode.SelectedIndex = -1;
					ViewModel.cboJobCode.Text = "";
					ViewModel.cboStep.SelectedIndex = -1;
					ViewModel.cboStep.Text = "";
				}
			}



			return result;
		}

		public void DeleteEmployeeRecord()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (modGlobal.Clean(ViewModel.EmployeeID) == "")
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.optFCCDispatcher.Checked)
			{
				oCmd.CommandText = "spDeletePersonnelSpecialty '" + ViewModel.EmployeeID + "', " + "2" + " ";
			}
			else if ( ViewModel.OptOmitBCList.Checked)
			{
				oCmd.CommandText = "spDeletePersonnelBattCardRemove " + ViewModel.PersonnelID.ToString() + " ";
			}
			else if ( ViewModel.OptParamedic.Checked)
			{
				oCmd.CommandText = "spDeletePersonnelSpecialty '" + ViewModel.EmployeeID + "', " + "1" + " ";
			}
			else if ( ViewModel.OptTempUpgrade.Checked)
			{
				oCmd.CommandText = "spDeletePayrollTemporaryUpgrade " + ViewModel.PersonnelID.ToString() + " ";
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

		}

		public void InsertEmployeeRecord()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.optFCCDispatcher.Checked)
			{
				oCmd.CommandText = "spInsertPersonnelSpecialty '" + ViewModel.EmployeeID + "', " + "2" + " ";
			}
			else if ( ViewModel.OptParamedic.Checked)
			{
				oCmd.CommandText = "spInsertPersonnelSpecialty '" + ViewModel.EmployeeID + "', " + "1" + " ";
			}
			else
			{
				return;
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

		}


		public void ClearScreen()
		{
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.sprSpecialtyList.Col = 1;
			ViewModel.sprSpecialtyList.Col2 = ViewModel.sprSpecialtyList.MaxCols;
			ViewModel.sprSpecialtyList.Row = 1;
			ViewModel.sprSpecialtyList.Row2 = ViewModel.sprSpecialtyList.MaxRows;
			ViewModel.sprSpecialtyList.BlockMode = true;
			ViewModel.sprSpecialtyList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprSpecialtyList.BlockMode = false;
			ViewModel.cboJobCode.SelectedIndex = -1;
			ViewModel.cboJobCode.Text = "";
			ViewModel.cboStep.SelectedIndex = -1;
			ViewModel.cboStep.Text = "";
			ViewModel.cboRemoveCode.SelectedIndex = -1;
			ViewModel.cboRemoveCode.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.lbUpgradeName.Text = "";
			ViewModel.lbRemoveName.Text = "";
			ViewModel.PersonnelID = 0;
			ViewModel.EmployeeID = "";
			ViewModel.cmdAdd.Enabled = true;
			ViewModel.cmdRemove.Enabled = true;
			ViewModel.EmployeeRow = 0;
			ViewModel.SpecialtyRow = 0;

		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboJobCode.Items.Clear();
			ViewModel.cboJobCode.SelectedIndex = -1;
			ViewModel.cboJobCode.Text = "";
			ViewModel.cboStep.Items.Clear();
			ViewModel.cboStep.SelectedIndex = -1;
			ViewModel.cboStep.Text = "";
			ViewModel.cboRemoveCode.Items.Clear();
			ViewModel.cboRemoveCode.SelectedIndex = -1;
			ViewModel.cboRemoveCode.Text = "";
			ViewModel.txtComment.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;


			oCmd.CommandText = "spJobCodeList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code list

			while(!oRec.EOF)
			{
				ViewModel.cboJobCode.AddItem(Convert.ToString(oRec["job_code_id"]));
				oRec.MoveNext();
			};

			oCmd.CommandText = "spSelect_RemoveCodeList";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Remove Code list

			while(!oRec.EOF)
			{
				ViewModel.cboRemoveCode.AddItem(modGlobal.Clean(oRec["remove_description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboRemoveCode.SetItemData(ViewModel.cboRemoveCode.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["remove_id"])));
				oRec.MoveNext();
			};

		}

		public void RefreshEmployeeList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.EmployeeRow = 1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spOpNameList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");



			while(!oRec.EOF)
			{
				ViewModel.sprEmployeeList.Row = ViewModel.EmployeeRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["per_sys_id"]);
				(ViewModel.EmployeeRow)++;
				oRec.MoveNext();
			};
			ViewModel.sprEmployeeList.MaxRows = ViewModel.EmployeeRow;
			ViewModel.EmployeeRow = 0;

		}

		public void RefreshGroupList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprSpecialtyList.Row = 1;
			ViewModel.sprSpecialtyList.Row2 = ViewModel.sprSpecialtyList.MaxRows;
			ViewModel.sprSpecialtyList.Col = 1;
			ViewModel.sprSpecialtyList.Col2 = ViewModel.sprSpecialtyList.MaxCols;
			ViewModel.sprSpecialtyList.BlockMode = true;
			ViewModel.sprSpecialtyList.Text = "";
			ViewModel.sprSpecialtyList.BlockMode = false;
			ViewModel.sprSpecialtyList.MaxRows = 500;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.optFCCDispatcher.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelSpecialtyListByType " + "2" + " ";
			}
			else if ( ViewModel.OptOmitBCList.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelBattCardRemoveList ";
			}
			else if ( ViewModel.OptParamedic.Checked)
			{
				oCmd.CommandText = "spSelect_PersonnelSpecialtyListByType " + "1" + " ";
			}
			else if ( ViewModel.OptTempUpgrade.Checked)
			{
				oCmd.CommandText = "spSelect_PayrollTemporaryUpgradeList ";
			}

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.SpecialtyRow = 1;


			while(!oRec.EOF)
			{
				ViewModel.sprSpecialtyList.Row = ViewModel.SpecialtyRow;
				ViewModel.sprSpecialtyList.Col = 1;
				ViewModel.sprSpecialtyList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprSpecialtyList.Col = 2;
				ViewModel.sprSpecialtyList.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprSpecialtyList.Col = 3;
				ViewModel.sprSpecialtyList.Text = modGlobal.Clean(oRec["per_sys_id"]);
				(ViewModel.SpecialtyRow)++;
				oRec.MoveNext();
			};
			ViewModel.sprSpecialtyList.MaxRows = ViewModel.SpecialtyRow;
			ViewModel.SpecialtyRow = 0;


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboJobCode.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.cboStep.Items.Clear();
			ViewModel.cboStep.SelectedIndex = -1;
			ViewModel.cboStep.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "sp_GetStepListByJobCode '" + modGlobal.Clean(ViewModel.cboJobCode.Text) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code lists

			while(!oRec.EOF)
			{
				ViewModel.cboStep.AddItem(Convert.ToString(oRec["step"]));
				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if (modGlobal.Clean(ViewModel.EmployeeID) == "")
			{
				return;
			}
			ViewModel.sprSpecialtyList.Col = 2;
			if (CheckEmployeeValid() != 0)
			{
				int tempForVar = ViewModel.sprSpecialtyList.MaxRows;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprSpecialtyList.Row = i;
					if (modGlobal.Clean(ViewModel.sprSpecialtyList.Text) == (ViewModel.EmployeeID))
					{
						ViewModel.sprEmployeeList.Col = 1;
						ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
						ViewModel.sprEmployeeList.Row = 1;
						ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
						ViewModel.sprEmployeeList.BlockMode = true;
						ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
						ViewModel.sprEmployeeList.BlockMode = false;
						ViewModel.sprSpecialtyList.Col = 1;
						ViewModel.sprSpecialtyList.Col2 = ViewModel.sprSpecialtyList.MaxCols;
						ViewModel.sprSpecialtyList.Row = i;
						ViewModel.sprSpecialtyList.Row2 = i;
						ViewModel.sprSpecialtyList.BlockMode = true;
						ViewModel.sprSpecialtyList.BackColor = modGlobal.Shared.YELLOW;
						ViewModel.sprSpecialtyList.BlockMode = false;
						//ViewModel.sprSpecialtyList.SetSelection(1, i, 3, i);
						ViewModel.cmdAdd.Enabled = false;
						return;
					}
				}
			}
			else
			{
				(
//add some logic to insert record and refresh group list
ViewModel.sprSpecialtyList.MaxRows)++;
				ViewModel.sprSpecialtyList.InsertRows(1, 1);
				ViewModel.sprSpecialtyList.Row = 1;
				ViewModel.SpecialtyRow = 1;
				ViewModel.sprEmployeeList.Row = ViewModel.EmployeeRow;

				for (int i = 1; i <= 3; i++)
				{
					ViewModel.sprEmployeeList.Col = i;
					ViewModel.sprSpecialtyList.Col = i;
					ViewModel.sprSpecialtyList.Text = ViewModel.sprEmployeeList.Text;
				}
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
				ViewModel.sprEmployeeList.Row = 1;
				ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
				ViewModel.sprEmployeeList.BlockMode = true;
				ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprEmployeeList.BlockMode = false;
				ViewModel.sprSpecialtyList.Col = 1;
				ViewModel.sprSpecialtyList.Col2 = ViewModel.sprSpecialtyList.MaxCols;
				ViewModel.sprSpecialtyList.Row = ViewModel.SpecialtyRow;
				ViewModel.sprSpecialtyList.Row2 = ViewModel.SpecialtyRow;
				ViewModel.sprSpecialtyList.BlockMode = true;
				ViewModel.sprSpecialtyList.BackColor = modGlobal.Shared.YELLOW;
				ViewModel.sprSpecialtyList.BlockMode = false;
				//ViewModel.sprSpecialtyList.SetSelection(1, ViewModel.SpecialtyRow, 3, ViewModel.SpecialtyRow);

				if ( ViewModel.frmUpgradeInfo.Visible)
				{
					ViewModel.cmdAdd.Enabled = false;
					ViewModel.cmdRemove.Enabled = false;
					ViewManager.SetCurrent(ViewModel.cboJobCode);
					return;

				}
				else if ( ViewModel.frmRemoveReason.Visible)
				{
					ViewModel.cmdAdd.Enabled = false;
					ViewModel.cmdRemove.Enabled = false;
					ViewManager.SetCurrent(ViewModel.cboRemoveCode);
					return;

				}
				else
				{
					InsertEmployeeRecord();
				}
			}

			RefreshGroupList();
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
			if (modGlobal.Clean(ViewModel.EmployeeID) == "")
			{
				return;
			}

			DeleteEmployeeRecord();
			RefreshGroupList();
			ClearScreen();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSaveReason_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sSQLString = "";

			if (modGlobal.Clean(ViewModel.EmployeeID) == "")
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if (!ViewModel.OptOmitBCList.Checked)
			{
				return;
			}
			if ( ViewModel.cboRemoveCode.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("Please Select A Reason to Remove Employee From the Battalion Payroll List.", "Remove Employee From Battalion Payroll List", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.cmdSaveReason.Enabled = false;

			int ReasonCode = ViewModel.cboRemoveCode.GetItemData(ViewModel.cboRemoveCode.SelectedIndex);
			string sComment = modGlobal.Clean(ViewModel.txtComment.Text);

			oCmd.CommandText = "spSelect_PersonnelBattCardRemoveListByID " + ViewModel.PersonnelID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				sSQLString = "spInsertPersonnelBattCardRemove " + ViewModel.PersonnelID.ToString() + ", " + ReasonCode.ToString();
				if (sComment == "")
				{
					sSQLString = sSQLString + ", NULL ";
				}
				else
				{
					sSQLString = sSQLString + ",'" + sComment + "' ";
				}
			}
			else
			{
				sSQLString = "spUpdatePersonnelBattCardRemove " + ViewModel.PersonnelID.ToString() + ", " + ReasonCode.ToString();
				if (sComment == "")
				{
					sSQLString = sSQLString + ", NULL ";
				}
				else
				{
					sSQLString = sSQLString + ",'" + sComment + "' ";
				}
			}
			oCmd.CommandText = sSQLString;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cmdSaveReason.Enabled = true;
			RefreshGroupList();
			ClearScreen();


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSaveUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sSQLString = "";

			if (modGlobal.Clean(ViewModel.EmployeeID) == "")
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if (!ViewModel.OptTempUpgrade.Checked)
			{
				return;
			}

			if (modGlobal.Clean(ViewModel.cboJobCode.Text) == "")
			{
				ViewManager.ShowMessage("Please Select the Temporary Upgrade PS Group/Job Code.", "Employee Temporary Payroll Upgrade", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if (modGlobal.Clean(ViewModel.cboStep.Text) == "")
			{
				ViewManager.ShowMessage("Please Select the Temporary Upgrade Step.", "Employee Temporary Payroll Upgrade", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.cmdSaveUpdate.Enabled = false;

			string sJobCode = modGlobal.Clean(ViewModel.cboJobCode.Text);
			string sStep = modGlobal.Clean(ViewModel.cboStep.Text);

			oCmd.CommandText = "spSelect_PayrollTemporaryUpgradeByID " + ViewModel.PersonnelID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				sSQLString = "spInsertPayrollTemporaryUpgrade " + ViewModel.PersonnelID.ToString() + ", '";
				sSQLString = sSQLString + sJobCode + "', '" + sStep + "' ";
			}
			else
			{
				sSQLString = "spUpdatePayrollTemporaryUpgrade " + ViewModel.PersonnelID.ToString() + ", '";
				sSQLString = sSQLString + sJobCode + "', '" + sStep + "' ";
			}
			oCmd.CommandText = sSQLString;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cmdSaveUpdate.Enabled = true;
			RefreshGroupList();
			ClearScreen();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			RefreshEmployeeList();

			if (modGlobal.Shared.gSpecialType == "Paramedic")
			{
				ViewModel.OptParamedic.Checked = true;
			}
			else if (modGlobal.Shared.gSpecialType == "Dispatch")
			{
				ViewModel.optFCCDispatcher.Checked = true;
			}
			else
			{
				ViewModel.OptOmitBCList.Checked = true;
			}

			LoadLists();

			//    RefreshGroupList

		}

		[UpgradeHelpers.Events.Handler]
		internal void optFCCDispatcher_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optFCCDispatcher.Checked)
				{
					ViewModel.lbGroup.Text = "FCC Field Relief Dispatcher List";
					ViewModel.frmUpgradeInfo.Visible = false;
					ViewModel.frmRemoveReason.Visible = false;
					ClearScreen();
					RefreshGroupList();
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptOmitBCList_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.OptOmitBCList.Checked)
				{
					ViewModel.lbGroup.Text = "Omitted From Battalion Payroll List";
					ViewModel.frmUpgradeInfo.Visible = false;
					ViewModel.frmRemoveReason.Visible = true;
					ClearScreen();
					RefreshGroupList();
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptParamedic_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.OptParamedic.Checked)
				{
					ViewModel.lbGroup.Text = "Paramadic Specialty List";
					ViewModel.frmUpgradeInfo.Visible = false;
					ViewModel.frmRemoveReason.Visible = false;
					ClearScreen();
					RefreshGroupList();
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptTempUpgrade_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.OptTempUpgrade.Checked)
				{
					ViewModel.lbGroup.Text = "Temporary Payroll Upgrade List";
					ViewModel.frmUpgradeInfo.Visible = true;
					ViewModel.frmRemoveReason.Visible = false;
					ClearScreen();
					RefreshGroupList();
				}

			}
		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if (Row == 0)
			{
				return;
			}

			ClearScreen();
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Row = Row;

			if (modGlobal.Clean(ViewModel.sprEmployeeList.Text) == "")
			{
				return;
			}
			ViewModel.lbRemoveName.Text = ViewModel.sprEmployeeList.Text;
			ViewModel.lbUpgradeName.Text = ViewModel.sprEmployeeList.Text;
			ViewModel.sprEmployeeList.Col = 2;
			ViewModel.EmployeeID = modGlobal.Clean(ViewModel.sprEmployeeList.Text);
			ViewModel.sprEmployeeList.Col = 3;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.PersonnelID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprEmployeeList.Text));
			//ViewModel.sprEmployeeList.SetSelection(1, Row, 2, Row);
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.Row = Row;
			ViewModel.sprEmployeeList.Row2 = Row;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprEmployeeList.BlockMode = false;
			ViewModel.EmployeeRow = Row;

			if (CheckEmployeeValid() != 0)
			{

			}

		}

		private void sprSpecialtyList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if (Row == 0)
			{
				return;
			}

			ClearScreen();
			ViewModel.sprSpecialtyList.Col = 1;
			ViewModel.sprSpecialtyList.Row = Row;

			if (modGlobal.Clean(ViewModel.sprSpecialtyList.Text) == "")
			{
				return;
			}
			ViewModel.lbRemoveName.Text = ViewModel.sprSpecialtyList.Text;
			ViewModel.lbUpgradeName.Text = ViewModel.sprSpecialtyList.Text;
			ViewModel.sprSpecialtyList.Col = 2;
			ViewModel.EmployeeID = modGlobal.Clean(ViewModel.sprSpecialtyList.Text);
			ViewModel.sprSpecialtyList.Col = 3;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.PersonnelID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprSpecialtyList.Text));
			//ViewModel.sprSpecialtyList.SetSelection(1, Row, 2, Row);
			ViewModel.sprSpecialtyList.Col = 1;
			ViewModel.sprSpecialtyList.Col2 = ViewModel.sprSpecialtyList.MaxCols;
			ViewModel.sprSpecialtyList.Row = Row;
			ViewModel.sprSpecialtyList.Row2 = Row;
			ViewModel.sprSpecialtyList.BlockMode = true;
			ViewModel.sprSpecialtyList.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprSpecialtyList.BlockMode = false;
			ViewModel.SpecialtyRow = Row;

			if (CheckEmployeeValid() != 0)
			{

			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgSpecialties DefInstance
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

		public static dlgSpecialties CreateInstance()
		{
			PTSProject.dlgSpecialties theInstance = Shared.Container.Resolve< dlgSpecialties>();
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
			ViewModel.frmRemoveReason.LifeCycleStartup();
			ViewModel.frmUpgradeInfo.LifeCycleStartup();
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.sprSpecialtyList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmRemoveReason.LifeCycleShutdown();
			ViewModel.frmUpgradeInfo.LifeCycleShutdown();
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.sprSpecialtyList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgSpecialties
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSpecialtiesViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgSpecialties m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}