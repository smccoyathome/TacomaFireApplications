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

	public partial class frmImmunization
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmImmunization));
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


		private void frmImmunization_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**************************************
		// Manage TFD Employee Immunizations   *
		// - restricted only to special EMS    *
		//   personnel (AC Duggan, MSO Mueller,*
		//   EMS Educator Lisa Breitinger, etc)*
		//**************************************

		public void UpdateRecord()
		{
			PTSProject.clsEMSInformation cImmunization = Container.Resolve< clsEMSInformation>();

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrRecord = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRecordID.Text));
			//UPGRADE_WARNING: (1068) GetVal(CurrRecord) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.CurrRecord)) == 0)
			{
				ViewManager.ShowMessage("No Record ID!??!", "Update Immunization Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (cImmunization.GetEMSPersonnelImmunizationsByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.CurrRecord))) != 0)
			{
				//continue with edit
			}
			else
			{
				ViewManager.ShowMessage("Immunization Record can't be found.", "Update Immunization Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if ( ViewModel.chkImmuneDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmunization.EMSImmunizeDate = "";
			}
			else
			{
				cImmunization.EMSImmunizeDate = DateTime.Parse(ViewModel.dteShotDate.Text).ToString("M/d/yyyy");
			}

			if ( ViewModel.chkResults.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmunization.EMSResultflag = "";
			}
			else if ( ViewModel.optPositive.Checked)
			{
				cImmunization.EMSResultflag = "P";
			}
			else
			{
				cImmunization.EMSResultflag = "N";
			}

			cImmunization.EMSComments = modGlobal.Clean(ViewModel.txtComments.Text);

			if (cImmunization.UpdateEMSPersonnelImmunizations() != 0)
			{
				ViewManager.ShowMessage("The immunization record was successfully updated.", "Update Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong.  Record was not updated.", "Update Immunization Error", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		public void AddNewRecord()
		{
			PTSProject.clsEMSInformation cImmunization = Container.Resolve< clsEMSInformation>();

			cImmunization.EMSEmployeeID = modGlobal.Clean(ViewModel.CurrEmpID);
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			cImmunization.EMSImmunizeID = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex)));

			if ( ViewModel.chkImmuneDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmunization.EMSImmunizeDate = "";
			}
			else
			{
				cImmunization.EMSImmunizeDate = DateTime.Parse(ViewModel.dteShotDate.Text).ToString("M/d/yyyy");
			}

			cImmunization.EMSCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cImmunization.EMSCreatedBy = modGlobal.Shared.gUser;

			if ( ViewModel.chkResults.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cImmunization.EMSResultflag = "";
			}
			else if ( ViewModel.optPositive.Checked)
			{
				cImmunization.EMSResultflag = "P";
			}
			else
			{
				cImmunization.EMSResultflag = "N";
			}

			cImmunization.EMSComments = modGlobal.Clean(ViewModel.txtComments.Text);

			if (cImmunization.InsertEMSPersonnelImmunizations() != 0)
			{
				ViewManager.ShowMessage("An immunization record was successfully added.", "Add New Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong.  Record was not added.", "Add New Record Error", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		public void DeleteRecord()
		{
			PTSProject.clsEMSInformation cImmunization = Container.Resolve< clsEMSInformation>();

			if (cImmunization.DeleteEMSPersonnelImmunizations(ViewModel.CurrRecord) != 0)
			{
				ViewManager.ShowMessage("The immunization record was successfully deleted.", "Delete Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong.  Record was not deleted.", "Delete Record Error", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}


		public void GetImmunizations()
		{
			PTSProject.clsEMSInformation cImmunization = Container.Resolve< clsEMSInformation>();

			//clear grid / fields
			ViewModel.sprImmunizationList.MaxRows = 500;
			ViewModel.sprImmunizationList.Row = 1;
			ViewModel.sprImmunizationList.Row2 = ViewModel.sprImmunizationList.MaxRows;
			ViewModel.sprImmunizationList.Col = 1;
			ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
			ViewModel.sprImmunizationList.BlockMode = true;
			ViewModel.sprImmunizationList.Text = "";
			ViewModel.sprImmunizationList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprImmunizationList.BlockMode = false;
			ViewModel.sprReport.MaxRows = 500;
			ViewModel.sprReport.Row = 5;
			ViewModel.sprReport.Row2 = ViewModel.sprImmunizationList.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprImmunizationList.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprImmunizationList.ClearRange(1, 1, ViewModel.sprImmunizationList.MaxCols, ViewModel.sprImmunizationList.MaxRows, false);
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.lbRecordID.Text = "0";
			ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteShotDate.Visible = false;
			ViewModel.dteShotDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmResults.Visible = false;
			ViewModel.optNegative.Checked = true;
			ViewModel.txtComments.Text = "";

			int CurrRow = 0;
			int ReportRow = 4; // which is the grid header

			if (modGlobal.Clean(ViewModel.CurrEmpID) == "")
			{
				return;
			}
			ViewModel.cmdAdd.Enabled = true;
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdAdd.Text = "Add";
			ViewModel.cmdDelete.Enabled = false;
			ViewModel.cmdNewRecord.Enabled = false;

			if (~cImmunization.GetEMSPersonnelImmunizationsByEmp(ViewModel.CurrEmpID) != 0)
			{

				return;
			}
			// Filling both grid and report

			while(!cImmunization.EMSPersonnelImmunizations.EOF)
			{
				CurrRow++;
				ViewModel.sprImmunizationList.Row = CurrRow;

				ReportRow++;
				ViewModel.sprReport.Row = ReportRow;
				ViewModel.sprImmunizationList.Col = 1;
				ViewModel.sprImmunizationList.Text = modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["immunize_type"]);
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["immunize_type"]);

				if (modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["result_flag"]) != "")
				{
					ViewModel.sprImmunizationList.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprImmunizationList.Col = 1;
					ViewModel.sprImmunizationList.CellNoteIndicator = true;
					if (modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["result_flag"]) == "P")
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprImmunizationList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprImmunizationList.CellNote ="Positive";
					}
					else
					{
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprImmunizationList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprImmunizationList.CellNote = "Negative";
					}
				}
				ViewModel.sprImmunizationList.Col = 2;
				if (modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["immunize_date"]) == "")
				{
					ViewModel.sprImmunizationList.Text = "";
				}
				else
				{
					ViewModel.sprImmunizationList.Text = Convert.ToDateTime(cImmunization.EMSPersonnelImmunizations["immunize_date"]).ToString("MM/dd/yyyy");
				}
				ViewModel.sprReport.Col = 2;
				if (modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["immunize_date"]) == "")
				{
					ViewModel.sprReport.Text = "";
				}
				else
				{
					ViewModel.sprReport.Text = Convert.ToDateTime(cImmunization.EMSPersonnelImmunizations["immunize_date"]).ToString("MM/dd/yyyy");
				}
				ViewModel.sprImmunizationList.Col = 3;
				ViewModel.sprImmunizationList.Text = Convert.ToDateTime(cImmunization.EMSPersonnelImmunizations["created_date"]).ToString("MM/dd/yyyy HH:mm:ss");
				ViewModel.sprImmunizationList.Col = 4;
				ViewModel.sprImmunizationList.Text = modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["CreatedBy"]);

				//        sprReport.Col = 4
				//        sprReport.Text = _
				//'            Clean(cImmunization.EMSPersonnelImmunizations("CreatedBy"])
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["comments"]);
				ViewModel.sprImmunizationList.Col = 5;
				ViewModel.sprImmunizationList.Text = modGlobal.Clean(cImmunization.EMSPersonnelImmunizations["comments"]);
				ViewModel.sprImmunizationList.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprImmunizationList.Text = Convert.ToString(modGlobal.GetVal(cImmunization.EMSPersonnelImmunizations["per_immunize_id"]));

				cImmunization.EMSPersonnelImmunizations.MoveNext();
			}
			;
			ViewModel.sprImmunizationList.MaxRows = CurrRow;
			ViewModel.sprReport.MaxRows = ReportRow;
			ViewModel.lbRecordID.Text = "0";


		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Fill Assignment Type List box
			oCmd.CommandText = "spSelect_AssignmentTypeList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAssignmentCode.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboAssignmentCode.AddItem(modGlobal.Clean(oRec["assignment_type_code"]));
				oRec.MoveNext();
			};

			//Fill Unit List box
			oCmd.CommandText = "spUnitList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnit.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboUnit.AddItem(Convert.ToString(oRec["unit_code"]));
				oRec.MoveNext();
			};

			//Fill Immunization List box
			oCmd.CommandText = "spSelect_EMSImmunizationTypeList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboType.AddItem(Convert.ToString(oRec["immunize_type"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["immunize_id"])));
				oRec.MoveNext();
			};

		}

		private int DetermineSecurity()
		{
			//int result = 0;
			PTSProject.clsEMSInformation cImmunizations = Container.Resolve< clsEMSInformation>();
			//This should always be NoLimitUpdate = True... because
			//GetEMSForSecurity is done before loading the screen...

			//result = 0;
			ViewModel.NoLimitUpdate = false;

			if (cImmunizations.GetEMSForSecurity(modGlobal.Shared.gUser) != 0)
			{
				ViewModel.NoLimitUpdate = true;
			}

			return -1;

		}

		public void ClearFields()
		{

			//clear Immunizations grid / fields
			ViewModel.sprImmunizationList.MaxRows = 50;
			ViewModel.sprImmunizationList.Row = 1;
			ViewModel.sprImmunizationList.Row2 = ViewModel.sprImmunizationList.MaxRows;
			ViewModel.sprImmunizationList.Col = 1;
			ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
			ViewModel.sprImmunizationList.BlockMode = true;
			ViewModel.sprImmunizationList.Text = "";
			ViewModel.sprImmunizationList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprImmunizationList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprImmunizationList.ClearSelection();
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteShotDate.Visible = false;
			ViewModel.dteShotDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmResults.Visible = false;
			ViewModel.optNegative.Checked = true;
			ViewModel.txtComments.Text = "";
			ViewModel.cmdAdd.Enabled = false;
			ViewModel.cmdAdd.Text = "Add";
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdDelete.Enabled = false;
			ViewModel.cmdNewRecord.Enabled = true;
			ViewModel.lbRecordID.Text = "0";
			ViewModel.cboAssignmentCode.Text = "";
			ViewModel.cboUnit.Text = "";
			ViewModel.cboAssignmentCode.SelectedIndex = -1;
			ViewModel.cboUnit.SelectedIndex = -1;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.opt181.Checked = false;
			ViewModel.opt182.Checked = false;
			ViewModel.optAll.Checked = true;
			ViewModel.txtNameSearch.Text = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrUnit = "";
			ViewModel.CurrGroupCode = "";
			ViewModel.CurrBatt = "";

		}

		public void RefreshEmployeeList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Clear Employee Immunization Grid/Detail
			ViewModel.sprImmunizationList.MaxRows = 50;
			ViewModel.sprImmunizationList.Row = 1;
			ViewModel.sprImmunizationList.Row2 = ViewModel.sprImmunizationList.MaxRows;
			ViewModel.sprImmunizationList.Col = 1;
			ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
			ViewModel.sprImmunizationList.BlockMode = true;
			ViewModel.sprImmunizationList.Text = "";
			ViewModel.sprImmunizationList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprImmunizationList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprImmunizationList.ClearSelection();
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteShotDate.Visible = false;
			ViewModel.dteShotDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmResults.Visible = false;
			ViewModel.optNegative.Checked = true;
			ViewModel.txtComments.Text = "";
			ViewModel.cmdAdd.Enabled = false;
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdAdd.Text = "Add";
			ViewModel.cmdDelete.Enabled = false;
			ViewModel.cmdNewRecord.Enabled = true;

			//Clear Employee Grid
			ViewModel.sprEmployeeList.MaxRows = 500;
			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			//    'Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.chkArchiveOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				sStringText = "spSelect_EMSPersonnelGridList ";
				if (modGlobal.Clean(ViewModel.CurrBatt) == "")
				{
					sStringText = sStringText + "NULL, ";
				}
				else
				{
					sStringText = sStringText + "'" + ViewModel.CurrBatt + "', ";
				}
				if (modGlobal.Clean(ViewModel.CurrUnit) == "")
				{
					sStringText = sStringText + "NULL, ";
				}
				else
				{
					sStringText = sStringText + "'" + ViewModel.CurrUnit + "', ";
				}
				if (modGlobal.Clean(ViewModel.CurrShift) == "")
				{
					sStringText = sStringText + "NULL, ";
				}
				else
				{
					sStringText = sStringText + "'" + ViewModel.CurrShift + "', ";
				}
				if (modGlobal.Clean(ViewModel.CurrGroupCode) == "")
				{
					sStringText = sStringText + "NULL, ";
				}
				else
				{
					sStringText = sStringText + "'" + ViewModel.CurrGroupCode + "', ";
				}
				if (modGlobal.Clean(ViewModel.txtNameSearch.Text) != "")
				{
					sStringText = sStringText + "'" + modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";
				}
				else
				{
					sStringText = sStringText + "NULL ";
				}
			}
			else
			{
				sStringText = "spSelect_ArchivedPersonnelGridList ";
				if (modGlobal.Clean(ViewModel.txtNameSearch.Text) != "")
				{
					sStringText = sStringText + "'" + modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";
				}
				else
				{
					sStringText = sStringText + "NULL ";
				}
			}
			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;

			while(!oRec.EOF)
			{
				GridRow++;
				ViewModel.sprEmployeeList.MaxRows = GridRow;
				ViewModel.sprEmployeeList.Row = GridRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["rank_code"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["group_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Text = Convert.ToDateTime(oRec["TFD_hire_date"]).ToString("MM/dd/yyyy");

				oRec.MoveNext();
			};

			if (GridRow > 0)
			{
				ViewModel.sprEmployeeList.MaxRows = GridRow;
			}
			else
			{
				ViewModel.sprEmployeeList.MaxRows = 1;
			}
			ViewModel.lbCount.Text = "List Count: " + GridRow.ToString();
			ViewModel.sprEmployeeList.Protect = true;
			ViewModel.FirstTime = false;
			ViewModel.CurrPersID = 0;
			ViewModel.SelectedEmpRow = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAssignmentCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAssignmentCode.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrGroupCode = modGlobal.Clean(ViewModel.cboAssignmentCode.Text);
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUnit.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrUnit = modGlobal.Clean(ViewModel.cboUnit.Text);
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkArchiveOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkImmuneDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.dteShotDate.Visible = ViewModel.chkImmuneDate.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkResults_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.frmResults.Visible = ViewModel.chkResults.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if (modGlobal.Clean(ViewModel.CurrEmpID) == "")
			{
				ViewManager.ShowMessage("Please select an employee.", "Add Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				ViewManager.ShowMessage("Please select an immunization type.", "Add Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.cmdAdd.Enabled = false;

			if (Convert.ToString(ViewModel.cmdAdd.Tag) == "1")
			{
				AddNewRecord();
			}
			else
			{
				//        MsgBox "This feature is under construction.", vbOKOnly, "Update Immunization Record"
				UpdateRecord();
			}
			GetImmunizations();
			ViewModel.cmdNewRecord.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddMuliple_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmAddImmunizations.DefInstance);
			/*			frmAddImmunizations.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ClearFields();
			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if (modGlobal.Clean(ViewModel.CurrEmpID) == "")
			{
				ViewManager.ShowMessage("Please select an employee.", "Delete Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//UPGRADE_WARNING: (1068) GetVal(lbRecordID.Caption) of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToString(modGlobal.GetVal(ViewModel.lbRecordID.Text)) == "0")
			{
				ViewManager.ShowMessage("Please select an immunization record.", "Delete Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrRecord = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRecordID.Text));
			DeleteRecord();
			GetImmunizations();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewRecord_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteShotDate.Visible = false;
			ViewModel.dteShotDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.frmResults.Visible = false;
			ViewModel.optNegative.Checked = true;
			ViewModel.txtComments.Text = "";
			ViewModel.cmdAdd.Enabled = true;
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdAdd.Text = "Add";
			ViewModel.lbRecordID.Text = "0";
			ViewModel.cmdDelete.Enabled = false;
			ViewModel.cmdNewRecord.Enabled = false;


			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprImmunizationList.ClearSelection();
			ViewModel.sprImmunizationList.Row = 1;
			ViewModel.sprImmunizationList.Row2 = ViewModel.sprImmunizationList.MaxRows;
			ViewModel.sprImmunizationList.Col = 1;
			ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
			ViewModel.sprImmunizationList.BlockMode = true;
			ViewModel.sprImmunizationList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprImmunizationList.BlockMode = false;


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "Printing the Individual Immunization Record is under construction.", vbOKOnly, "Printing Immunization Record"
			//    gEmployeeId = Clean(CurrEmpID)
			//    frmImmunizationRecord.Show
			//    frmImmunizationRecord.Move 0, 0
			//    'MDIForm1.Arrange vbCascade

			//    sprReport.PrintHeader = "/lImmunization Query /n" & sHeadingFilter
			//    sprReport.PrintFooter = "/nPrinted on " & Format$(Now(), "mm/dd/yyyy hh:nn:ss") & "/r Page /p of /pc"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Individual Immunization Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//    sprReport.PrintColHeaders = True
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
			//    MsgBox "Query Immunization Records is under construction.", vbOKOnly, "Query Immunization Info"
			ViewManager.NavigateToView(
				//    MsgBox "Query Immunization Records is under construction.", vbOKOnly, "Query Immunization Info"
				frmImmunizationQuery.DefInstance);
			/*			frmImmunizationQuery.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			LoadLists();
			ClearFields();
			DetermineSecurity();
			RefreshEmployeeList();

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
				ViewModel.CurrBatt = "1";
				RefreshEmployeeList();
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
				ViewModel.CurrBatt = "2";
				RefreshEmployeeList();
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
				ViewModel.CurrBatt = "3";
				RefreshEmployeeList();
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
				ViewModel.CurrShift = "A";
				RefreshEmployeeList();
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
				if ( ViewModel.optAll.Checked)
				{
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;
					RefreshEmployeeList();
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
				ViewModel.CurrShift = "B";
				RefreshEmployeeList();
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
				ViewModel.CurrShift = "C";
				RefreshEmployeeList();
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
				ViewModel.CurrShift = "D";
				RefreshEmployeeList();
			}
		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//Header was clicked... exit sub
			if (Row == 0)
			{
				return;
			}

			//Blank Row was clicked... exit sub
			ViewModel.sprEmployeeList.Row = Row;
			ViewModel.sprEmployeeList.Col = 1;
			if (modGlobal.Clean(ViewModel.sprEmployeeList.Text) == "")
			{
				return;
			}

			//Clear the previous selection
			if ( ViewModel.SelectedEmpRow != 0)
			{
				ViewModel.sprEmployeeList.Row = ViewModel.SelectedEmpRow;
				ViewModel.sprEmployeeList.Row2 = ViewModel.SelectedEmpRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
				ViewModel.sprEmployeeList.BlockMode = true;
				ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprEmployeeList.BlockMode = false;
			}
			ViewModel.SelectedEmpRow = Row;
			ViewModel.sprEmployeeList.Row = ViewModel.SelectedEmpRow;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.sprEmployeeList.Text);
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Row = 3;
			ViewModel.sprEmployeeList.Col = 2;
			ViewModel.sprReport.Text = "NAME:   " + ViewModel.sprEmployeeList.Text;
			ViewModel.sprReport.Col = 3;
			ViewModel.sprReport.Row = 3;
			ViewModel.sprEmployeeList.Col = 8;
			ViewModel.sprReport.Text = "TFD HIRE DATE:   " + ViewModel.sprEmployeeList.Text;

			//Set background color of selected row to Yellow...
			if ( ViewModel.SelectedEmpRow != 0)
			{
				ViewModel.sprEmployeeList.Row = ViewModel.SelectedEmpRow;
				ViewModel.sprEmployeeList.Row2 = ViewModel.SelectedEmpRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
				ViewModel.sprEmployeeList.BlockMode = true;
				ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
				ViewModel.sprEmployeeList.BlockMode = false;
			}

			GetImmunizations();

		}

		private void sprImmunizationList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			PTSProject.clsEMSInformation cImmunization = Container.Resolve< clsEMSInformation>();

			//Header was clicked... exit sub
			if (Row == 0)
			{
				return;
			}

			//Blank Row was clicked... exit sub
			ViewModel.sprImmunizationList.Row = Row;
			ViewModel.sprImmunizationList.Col = 1;
			if (modGlobal.Clean(ViewModel.sprImmunizationList.Text) == "")
			{
				return;
			}

			//Clear the previous selection
			if ( ViewModel.SelectedRecordRow != 0)
			{
				ViewModel.sprImmunizationList.Row = ViewModel.SelectedRecordRow;
				ViewModel.sprImmunizationList.Row2 = ViewModel.SelectedRecordRow;
				ViewModel.sprImmunizationList.Col = 1;
				ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
				ViewModel.sprImmunizationList.BlockMode = true;
				ViewModel.sprImmunizationList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprImmunizationList.BlockMode = false;
			}
			ViewModel.SelectedRecordRow = Row;
			ViewModel.sprImmunizationList.Row = ViewModel.SelectedRecordRow;
			ViewModel.sprImmunizationList.Col = 6;
			ViewModel.CurrRecord = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.sprImmunizationList.Text)));

			//Set background color of selected row to Yellow...
			if ( ViewModel.SelectedRecordRow != 0)
			{
				ViewModel.sprImmunizationList.Row = ViewModel.SelectedRecordRow;
				ViewModel.sprImmunizationList.Row2 = ViewModel.SelectedRecordRow;
				ViewModel.sprImmunizationList.Col = 1;
				ViewModel.sprImmunizationList.Col2 = ViewModel.sprImmunizationList.MaxCols;
				ViewModel.sprImmunizationList.BlockMode = true;
				ViewModel.sprImmunizationList.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprImmunizationList.BlockMode = false;
			}

			//UPGRADE_WARNING: (1068) GetVal(CurrRecord) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.CurrRecord)) != 0)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (cImmunization.GetEMSPersonnelImmunizationsByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.CurrRecord))) != 0)
				{
					ViewModel.lbRecordID.Text = cImmunization.EMSPerImmunizeID.ToString();
					if (cImmunization.EMSImmunizeDate != "")
					{
						ViewModel.dteShotDate.Text = cImmunization.EMSImmunizeDate;
						ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
						ViewModel.dteShotDate.Visible = true;
					}
					else
					{
						ViewModel.chkImmuneDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.dteShotDate.Visible = false;
						ViewModel.dteShotDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
					}
					if (cImmunization.EMSResultflag != "")
					{
						ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
						ViewModel.frmResults.Visible = true;
						if (cImmunization.EMSResultflag == "P")
						{
							ViewModel.optPositive.Checked = true;
						}
						else
						{
							ViewModel.optNegative.Checked = true;
						}
					}
					else
					{
						ViewModel.chkResults.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.frmResults.Visible = false;
						ViewModel.optNegative.Checked = true;
					}
					for (int i = 0; i <= ViewModel.cboType.Items.Count - 1; i++)
					{
						if ( ViewModel.cboType.GetItemData(i) == cImmunization.EMSImmunizeID)
						{
							ViewModel.cboType.SelectedIndex = i;
							break;
						}
					}
					ViewModel.txtComments.Text = cImmunization.EMSComments;
					ViewModel.cmdAdd.Enabled = true;
					ViewModel.cmdAdd.Tag = "0";
					ViewModel.cmdAdd.Text = "Update";
					ViewModel.cmdNewRecord.Enabled = true;
					ViewModel.cmdDelete.Enabled = true;
				}
				else
				{
					ViewManager.ShowMessage("Ooooops!  Error trying to find selected record.", "Find Selected Immunization Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

		}

		private void sprImmunizationList_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprImmunizationList.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprImmunizationList.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprImmunizationList.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			RefreshEmployeeList();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmImmunization DefInstance
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

		public static frmImmunization CreateInstance()
		{
			PTSProject.frmImmunization theInstance = Shared.Container.Resolve< frmImmunization>();
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
			ViewModel.sprImmunizationList.LifeCycleStartup();
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.frmResults.LifeCycleStartup();
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprImmunizationList.LifeCycleShutdown();
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.frmResults.LifeCycleShutdown();
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmImmunization
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmImmunization m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}