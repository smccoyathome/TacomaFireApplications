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

	public partial class frmPPEInspHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInspHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPPEInspHistory));
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


		private void frmPPEInspHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FillNotInspectedGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprList.Row = 1;
			ViewModel.sprList.Row2 = ViewModel.sprList.MaxRows;
			ViewModel.sprList.Col = 1;
			ViewModel.sprList.Col2 = ViewModel.sprList.MaxCols;
			ViewModel.sprList.BlockMode = true;
			ViewModel.sprList.Text = "";
			ViewModel.sprList.BlockMode = false;

			//default check box to unchecked
			ViewModel.sprList.Col = 8;
			int tempForVar = ViewModel.sprList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprList.Row = i;
				ViewModel.sprList.Value = 0;
			}
			ViewModel.lbTotalCount.Text = "List Count:   0";
			ViewModel.sprList.MaxRows = 5000;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			if ( ViewModel.opt6Month.Checked)
			{
				ViewModel.iMonth = 6;
			}
			else
			{
				//12 month option
				ViewModel.iMonth = 12;
			}

			strSQL = "spSelect_UniformsNotInspectedFiltered ";
			if ( ViewModel.CurrBatt == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrBatt + "', ";
			}
			if ( ViewModel.CurrShift == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrShift + "', ";
			}
			strSQL = strSQL + ViewModel.iMonth.ToString() + ", ";
			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex).ToString() + ", ";
			}
			if ( ViewModel.cboBrand.SelectedIndex == -1)
			{
				strSQL = strSQL + "NULL ";
			}
			else
			{
				strSQL = strSQL + ViewModel.cboBrand.GetItemData(ViewModel.cboBrand.SelectedIndex).ToString() + " ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.sprList.MaxRows = 1;
				ViewManager.ShowMessage("No Inspection Information was found.", "PPE Inspection Information", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.sprList.Row = 0;
			int TotalCount = 0;

			while(!oRec.EOF)
			{
				(ViewModel.sprList.Row)++;
				ViewModel.sprList.Col = 1; //Inspection Date

				if (modGlobal.Clean(oRec["inspection_date"]) == "")
				{
					ViewModel.sprList.Text = "N/A";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["inspection_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 2; //Issued To

				ViewModel.sprList.Text = modGlobal.Clean(oRec["emp_name"]);
				ViewModel.sprList.Col = 3; //Inspected By

				if (modGlobal.Clean(oRec["InspectedBy"]) == "")
				{
					ViewModel.sprList.Text = "N/A";
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["InspectedBy"]);
				}
				ViewModel.sprList.Col = 4; //Uniform Item

				ViewModel.sprList.Text = modGlobal.Clean(oRec["UniformType"]);
				ViewModel.sprList.Col = 5; //Tracking #

				ViewModel.sprList.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.sprList.Col = 6; //Brand

				ViewModel.sprList.Text = modGlobal.Clean(oRec["manufacturer_name"]);
				ViewModel.sprList.Col = 7; //Inspected By

				if (modGlobal.Clean(oRec["SizeCode"]) == "")
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["Color"]);
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["SizeCode"]);
				}
				ViewModel.sprList.Col = 8; //Passed Flag
				//UPGRADE_WARNING: (1068) GetVal(oRec(passed_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx

				if (Convert.ToDouble(modGlobal.GetVal(oRec["passed_flag"])) == 0)
				{
					ViewModel.sprList.Value = 0;
				}
				else
				{
					ViewModel.sprList.Value = 1;
				}
				ViewModel.sprList.Col = 9; //Returned Date

				if (modGlobal.Clean(oRec["returned_date"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["returned_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 10; //Retired Date

				if (modGlobal.Clean(oRec["retired_date"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["retired_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 11; //Uniform ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
				ViewModel.sprList.Col = 12; //Inspection ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["inspection_id"]));

				TotalCount++;
				oRec.MoveNext();
			};
			ViewModel.sprList.MaxRows = TotalCount;
			ViewModel.lbTotalCount.Text = "List Count:  " + TotalCount.ToString();

		}

		public void FillInspectedGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprList.Row = 1;
			ViewModel.sprList.Row2 = ViewModel.sprList.MaxRows;
			ViewModel.sprList.Col = 1;
			ViewModel.sprList.Col2 = ViewModel.sprList.MaxCols;
			ViewModel.sprList.BlockMode = true;
			ViewModel.sprList.Text = "";
			ViewModel.sprList.BlockMode = false;

			//default check box to unchecked
			ViewModel.sprList.Col = 8;
			int tempForVar = ViewModel.sprList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprList.Row = i;
				ViewModel.sprList.Value = 0;
			}
			ViewModel.lbTotalCount.Text = "List Count:   0   ";
			ViewModel.sprList.MaxRows = 500;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			if ( ViewModel.sFilter == "Employee")
			{
				strSQL = "spSelect_EmployeeUniformInspectionHistory '" + modGlobal.Clean(ViewModel.lbEmpID.Text) + "' ";
			}
			else
			{
				//Tracking Number
				strSQL = "spSelect_UniformInspectionHistoryByTrackingNum '" + modGlobal.Clean(ViewModel.txtTrackingNum.Text) + "' ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.sprList.MaxRows = 1;
				ViewManager.ShowMessage("No Inspection Information was found.", "PPE Inspection Information", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.sprList.Row = 0;
			int TotalCount = 0;

			while(!oRec.EOF)
			{
				(ViewModel.sprList.Row)++;
				ViewModel.sprList.Col = 1; //Inspection Date

				if (modGlobal.Clean(oRec["inspection_date"]) == "")
				{
					ViewModel.sprList.Text = "N/A";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["inspection_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 2; //Issued To

				ViewModel.sprList.Text = modGlobal.Clean(oRec["emp_name"]);
				ViewModel.sprList.Col = 3; //Inspected By

				if (modGlobal.Clean(oRec["InspectedBy"]) == "")
				{
					ViewModel.sprList.Text = "N/A";
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["InspectedBy"]);
				}
				ViewModel.sprList.Col = 4; //Uniform Item

				ViewModel.sprList.Text = modGlobal.Clean(oRec["UniformType"]);
				ViewModel.sprList.Col = 5; //Tracking #

				ViewModel.sprList.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.sprList.Col = 6; //Brand

				ViewModel.sprList.Text = modGlobal.Clean(oRec["manufacturer_name"]);
				ViewModel.sprList.Col = 7; //Inspected By

				if (modGlobal.Clean(oRec["SizeCode"]) == "")
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["Color"]);
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["SizeCode"]);
				}
				ViewModel.sprList.Col = 8; //Passed Flag
				//UPGRADE_WARNING: (1068) GetVal(oRec(passed_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx

				if (Convert.ToDouble(modGlobal.GetVal(oRec["passed_flag"])) == 0)
				{
					ViewModel.sprList.Value = 0;
				}
				else
				{
					ViewModel.sprList.Value = 1;
				}
				ViewModel.sprList.Col = 9; //Returned Date

				if (modGlobal.Clean(oRec["returned_date"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["returned_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 10; //Retired Date

				if (modGlobal.Clean(oRec["retired_date"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["retired_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 11; //Uniform ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
				ViewModel.sprList.Col = 12; //Inspection ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["inspection_id"]));

				TotalCount++;
				oRec.MoveNext();
			};
			ViewModel.sprList.MaxRows = TotalCount;
			ViewModel.lbTotalCount.Text = "List Count:  " + TotalCount.ToString();

		}

		public void FindEmployee()
		{
			//If called from Update Screens bring up selected Employee
			ViewModel.cboEmpList.Text = "";

			for (int i = 0; i <= ViewModel.cboEmpList.Items.Count - 1; i++)
			{
				//Come Here - for employee id change
				if ( ViewModel.cboEmpList.GetListItem(i).Substring(Math.Max(ViewModel.cboEmpList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gAssignID)
				{
					ViewModel.cboEmpList.Text = ViewModel.cboEmpList.GetListItem(i);
					break;
				}
			}

			//Come Here - for employee id change
			if (modGlobal.Clean(ViewModel.cboEmpList.Text) != "")
			{
				ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			}

		}

		public void FillNameList()
		{
			//Fill Employee Name List

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";
			string strSQL = "";

			try
			{
				ViewModel.cboEmpList.Items.Clear();

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				strSQL = "";

				if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					strSQL = "spFullNameList ";
				}
				else
				{
					strSQL = "spArchiveNameList ";
				}

				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					ViewModel.cboEmpList.AddItem(strName);
					oRec.MoveNext();
				}
				;
							}
							catch
							{

								if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
								{
									return;
								}
							}

						}

		//UPGRADE_NOTE: (7001) The following declaration (CancelButton_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void CancelButton_Click()
		//{
			//this.Close();
		//}
		[UpgradeHelpers.Events.Handler]
		internal void cboBrand_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FillNotInspectedGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}

			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			modGlobal.Shared.gAssignID = ViewModel.lbEmpID.Text;
			ViewModel.txtTrackingNum.Text = "";
			ViewModel.sFilter = "Employee";
			FillInspectedGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}

			int iItemType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
			ViewModel.cboBrand.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbBrand.Text = "";
				ViewModel.cboBrand.Enabled = false;
				ViewModel.cboBrand.Visible = false;
				ViewModel.cboBrand.SelectedIndex = -1;
				ViewModel.cboBrand.Text = "";
			}
			else
			{
				ViewModel.lbBrand.Text = "Manufacturer";
				ViewModel.cboBrand.Enabled = true;
				ViewModel.cboBrand.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboBrand.SetItemData(ViewModel.cboBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				}
				;
							}
							FillNotInspectedGrid();

						}

		[UpgradeHelpers.Events.Handler]
		internal void chkDisplayOption_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.sprList.Row = 1;
			ViewModel.sprList.Row2 = ViewModel.sprList.MaxRows;
			ViewModel.sprList.Col = 1;
			ViewModel.sprList.Col2 = ViewModel.sprList.MaxCols;
			ViewModel.sprList.BlockMode = true;
			ViewModel.sprList.Text = "";
			ViewModel.sprList.BlockMode = false;

			//default check box to unchecked
			ViewModel.sprList.Col = 8;
			int tempForVar = ViewModel.sprList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprList.Row = i;
				ViewModel.sprList.Value = 0;
			}
			ViewModel.lbTotalCount.Text = "";

			if ( ViewModel.chkDisplayOption.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.frmNotInspectedOptions.Visible = false;
				//Clear Inspected Option fields
				ViewModel.lbEmpID.Text = "";
				ViewModel.cboEmpList.Text = "";
				ViewModel.cboEmpList.SelectedIndex = -1;
				ViewModel.txtTrackingNum.Text = "";
				ViewModel.frmInpectedOptions.Visible = true;
			}
			else
			{
				ViewModel.frmInpectedOptions.Visible = false;
				//Clear Inspected Option fields
				ViewModel.optAll.Checked = true;
				ViewModel.opt6Month.Checked = true;
				ViewModel.cboType.SelectedIndex = -1;
				ViewModel.cboType.Text = "";
				ViewModel.cboBrand.SelectedIndex = -1;
				ViewModel.cboBrand.Text = "";
				ViewModel.cboBrand.Items.Clear();
				ViewModel.frmNotInspectedOptions.Visible = true;
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.iMonth = 6;
				FillNotInspectedGrid();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkInactive_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboEmpList.SelectedIndex = -1;
			ViewModel.cboEmpList.Text = "";
			ViewModel.lbEmpID.Text = "";

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.txtTrackingNum.Text = "";
			}

			FillNameList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.opt6Month.Checked = true;
			ViewModel.iMonth = 6;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboType.Text = "";
			ViewModel.cboBrand.Text = "";

			FillNotInspectedGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintList_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction.", vbOKOnly, "Print Inspection History"
			//Print PPE Inventory Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintHeader("/lPPE Inspection History /rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintAbortMsg("Printing PPE nspection History List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprList.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSearchNum_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.lbEmpID.Text = "";
			ViewModel.cboEmpList.Text = "";
			ViewModel.cboEmpList.SelectedIndex = -1;
			ViewModel.sFilter = "TrackingNum";
			FillInspectedGrid();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				oRec.MoveNext();
			};
			ViewModel.frmNotInspectedOptions.Visible = false;
			ViewModel.frmInpectedOptions.Visible = true;
			ViewModel.txtTrackingNum.Text = "";
			FillNameList();

			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
				if ( ViewModel.lbEmpID.Text != "")
				{
					ViewModel.sFilter = "Employee";
					FillInspectedGrid();
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt12Month_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.iMonth = 12;
				FillNotInspectedGrid();
			}
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
				FillNotInspectedGrid();
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
				FillNotInspectedGrid();
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
				FillNotInspectedGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt6Month_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.iMonth = 6;
				FillNotInspectedGrid();
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
				FillNotInspectedGrid();
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
				ViewModel.opt181.Checked = false;
				ViewModel.opt182.Checked = false;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";

				FillNotInspectedGrid();

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
				FillNotInspectedGrid();
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
				FillNotInspectedGrid();
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
				FillNotInspectedGrid();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPPEInspHistory DefInstance
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

		public static frmPPEInspHistory CreateInstance()
		{
			PTSProject.frmPPEInspHistory theInstance = Shared.Container.Resolve< frmPPEInspHistory>();
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
			ViewModel.frmInpectedOptions.LifeCycleStartup();
			ViewModel.frmNotInspectedOptions.LifeCycleStartup();
			ViewModel.sprList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmInpectedOptions.LifeCycleShutdown();
			ViewModel.frmNotInspectedOptions.LifeCycleShutdown();
			ViewModel.sprList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPPEInspHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInspHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPPEInspHistory m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}