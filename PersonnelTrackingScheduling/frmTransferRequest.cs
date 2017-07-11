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

	public partial class frmTransferRequest
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransferRequestViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTransferRequest));
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


		private void frmTransferRequest_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**********************************************
		//***  frmTransferRequest/Management Screen  ***
		//**********************************************
		//*** This screen will only be available to  ***
		//*** Admin Security only will use this      ***
		//*** Screen.  The dlgRequestTransfer screen ***
		//*** will allow field personnel to request  ***
		//*** transfers.                             ***
		//**********************************************

		public void RefreshPositionLists()
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			string sText = "";
			ViewModel.cboPositionList.Items.Clear();
			ViewModel.lstAvailPositions.Items.Clear();
			ViewModel.cboReqPositionList.Items.Clear();

			if (cTransfer.GetTransferPositionActiveList() != 0)
			{

				while(!cTransfer.TransferPosition.EOF)
				{
					sText = modGlobal.Clean(cTransfer.TransferPosition["unit_code"]);
					sText = sText + modGlobal.Clean(cTransfer.TransferPosition["shift_code"]);
					sText = sText + " " + modGlobal.Clean(cTransfer.TransferPosition["position_code"]);
					if (modGlobal.Clean(cTransfer.TransferPosition["paramedic_only"]) == "Y")
					{
						sText = sText + " (Paramedic)";
					}
					ViewModel.cboPositionList.AddItem(sText);
					ViewModel.lstAvailPositions.AddItem(sText);
					ViewModel.cboReqPositionList.AddItem(sText);
					ViewModel.cboPositionList.SetItemData(ViewModel.cboPositionList.GetNewIndex(), Convert.ToInt32(cTransfer.TransferPosition["position_id"]));
					ViewModel.lstAvailPositions.SetItemData(ViewModel.lstAvailPositions.GetNewIndex(), Convert.ToInt32(cTransfer.TransferPosition["position_id"]));
					ViewModel.cboReqPositionList.SetItemData(ViewModel.cboReqPositionList.GetNewIndex(), Convert.ToInt32(cTransfer.TransferPosition["position_id"]));

					cTransfer.TransferPosition.MoveNext();
				};
			}

		}

		public void FillGrids()
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			string sText = "";
			int lPositionID = 0;

			if ( ViewModel.NoRefresh)
			{
				return;
			}
			ViewModel.sprRequests.MaxRows = 1000;
			ViewModel.sprPositions.MaxRows = 1000;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearRange(1, 1, ViewModel.sprRequests.MaxCols, ViewModel.sprRequests.MaxRows, false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPositions.ClearRange(1, 1, ViewModel.sprPositions.MaxCols, ViewModel.sprPositions.MaxRows, false);

			int CurrRow = 0;
			if ( ViewModel.chkActiveOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				if (cTransfer.GetTransferPositionActiveList() != 0)
				{

					while(!cTransfer.TransferPosition.EOF)
					{
						CurrRow++;
						ViewModel.sprPositions.Row = CurrRow;
						ViewModel.sprPositions.Col = 1;
						sText = modGlobal.Clean(cTransfer.TransferPosition["unit_code"]);
						sText = sText + modGlobal.Clean(cTransfer.TransferPosition["shift_code"]);
						sText = sText + " " + modGlobal.Clean(cTransfer.TransferPosition["position_code"]);
						if (modGlobal.Clean(cTransfer.TransferPosition["paramedic_only"]) == "Y")
						{
							sText = sText + " (Paramedic)";
						}
						ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprPositions.Text = sText;

						if (modGlobal.Clean(cTransfer.TransferPosition["CurrentlyAssigned"]) != "")
						{
							ViewModel.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
							ViewModel.sprPositions.Col = 1;
							ViewModel.sprPositions.CellNoteIndicator = true;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPositions.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPositions.CellNote = modGlobal.Clean(cTransfer.TransferPosition["CurrentlyAssigned"]) + " is currently Assigned";
						}
						ViewModel.sprPositions.Col = 2;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_open"]).ToString("M/d/yyyy");
						ViewModel.sprPositions.Col = 3;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_closed"]).ToString("M/d/yyyy");
						ViewModel.sprPositions.Col = 4;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPositions.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferPosition["NumberOfRequests"]));
						ViewModel.sprPositions.Col = 5;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["created_date"]).ToString("M/d/yyyy HH:mm:ss");

						sText = "Created By " + modGlobal.Clean(cTransfer.TransferPosition["CreatedByName"]);
						ViewModel.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
						ViewModel.sprPositions.Col = 3;
						ViewModel.sprPositions.CellNoteIndicator = true;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPositions.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprPositions.CellNote = sText;
						ViewModel.sprPositions.Col = 6;
						ViewModel.sprPositions.Text = Convert.ToInt32(cTransfer.TransferPosition["position_id"]).ToString();
						ViewModel.sprPositions.Row = CurrRow;
						ViewModel.sprPositions.Row2 = CurrRow;
						ViewModel.sprPositions.Col = 1;
						ViewModel.sprPositions.Col2 = ViewModel.sprPositions.MaxCols;
						ViewModel.sprPositions.BlockMode = true;
						ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
						ViewModel.sprPositions.BlockMode = false;

						cTransfer.TransferPosition.MoveNext();
					};
				}
			}
			else
			{
				if (cTransfer.GetTransferPositionList() != 0)
				{

					while(!cTransfer.TransferPosition.EOF)
					{
						CurrRow++;
						ViewModel.sprPositions.Row = CurrRow;
						ViewModel.sprPositions.Col = 1;
						sText = modGlobal.Clean(cTransfer.TransferPosition["unit_code"]);
						sText = sText + modGlobal.Clean(cTransfer.TransferPosition["shift_code"]);
						sText = sText + " " + modGlobal.Clean(cTransfer.TransferPosition["position_code"]);
						if (modGlobal.Clean(cTransfer.TransferPosition["paramedic_only"]) == "Y")
						{
							sText = sText + " (Paramedic)";
						}
						ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
						ViewModel.sprPositions.Text = sText;

						if (modGlobal.Clean(cTransfer.TransferPosition["CurrentlyAssigned"]) != "")
						{
							ViewModel.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
							ViewModel.sprPositions.Col = 1;
							ViewModel.sprPositions.CellNoteIndicator = true;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPositions.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPositions.CellNote = modGlobal.Clean(cTransfer.TransferPosition["CurrentlyAssigned"]) + " is currently Assigned";
						}
						ViewModel.sprPositions.Col = 2;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_open"]).ToString("M/d/yyyy");
						ViewModel.sprPositions.Col = 3;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_closed"]).ToString("M/d/yyyy");
						ViewModel.sprPositions.Col = 4;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPositions.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferPosition["NumberOfRequests"]));
						ViewModel.sprPositions.Col = 5;
						ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["created_date"]).ToString("M/d/yyyy HH:mm:ss");

						sText = "Created By " + modGlobal.Clean(cTransfer.TransferPosition["CreatedByName"]);
						ViewModel.sprPositions.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
						ViewModel.sprPositions.Col = 3;
						ViewModel.sprPositions.CellNoteIndicator = true;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPositions.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprPositions.CellNote = sText;
						ViewModel.sprPositions.Col = 6;
						ViewModel.sprPositions.Text = Convert.ToInt32(cTransfer.TransferPosition["position_id"]).ToString();

						if (Convert.ToString(cTransfer.TransferPosition["active_flag"]) == "Y")
						{
							ViewModel.sprPositions.Row = CurrRow;
							ViewModel.sprPositions.Row2 = CurrRow;
							ViewModel.sprPositions.Col = 1;
							ViewModel.sprPositions.Col2 = ViewModel.sprPositions.MaxCols;
							ViewModel.sprPositions.BlockMode = true;
							ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
							ViewModel.sprPositions.BlockMode = false;
						}
						else
						{
							ViewModel.sprPositions.Row = CurrRow;
							ViewModel.sprPositions.Row2 = CurrRow;
							ViewModel.sprPositions.Col = 1;
							ViewModel.sprPositions.Col2 = ViewModel.sprPositions.MaxCols;
							ViewModel.sprPositions.BlockMode = true;
							ViewModel.sprPositions.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
							ViewModel.sprPositions.BlockMode = false;
						}

						cTransfer.TransferPosition.MoveNext();
					};
				}
			}
			ViewModel.sprPositions.MaxRows = CurrRow + 1;

			if ( ViewModel.cboReqPositionList.SelectedIndex == -1)
			{
				lPositionID = 0;
			}
			else
			{
				lPositionID = ViewModel.cboReqPositionList.GetItemData(ViewModel.cboReqPositionList.SelectedIndex);
			}

			CurrRow = 0;
			if (cTransfer.GetTransferRequestActiveList(modGlobal.Clean(ViewModel.FilterEmployee), lPositionID) != 0)
			{

				while(!cTransfer.TransferRequest.EOF)
				{
					CurrRow++;
					ViewModel.sprRequests.Row = CurrRow;
					ViewModel.sprRequests.Col = 1;
					ViewModel.sprRequests.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprRequests.Text = modGlobal.Clean(cTransfer.TransferRequest["EmployeeName"]);
					ViewModel.sprRequests.Col = 2;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprRequests.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferRequest["priority_value"]));
					ViewModel.sprRequests.Col = 3;
					sText = modGlobal.Clean(cTransfer.TransferRequest["unit_code"]);
					sText = sText + modGlobal.Clean(cTransfer.TransferRequest["shift_code"]);
					sText = sText + " " + modGlobal.Clean(cTransfer.TransferRequest["position_code"]);
					ViewModel.sprRequests.Text = sText;

					sText = "Created on ";
					sText = sText + Convert.ToDateTime(cTransfer.TransferRequest["created_date"]).ToString("M/d/yyyy HH:mm:ss");
					sText = sText + " by " + modGlobal.Clean(cTransfer.TransferRequest["CreatedByName"]);
					ViewModel.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprRequests.Col = 3;
					ViewModel.sprRequests.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.CellNote = sText;
					ViewModel.sprRequests.Col = 4;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprRequests.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferRequest["ranking"]));
					ViewModel.sprRequests.Col = 5;
					if (modGlobal.Clean(cTransfer.TransferRequest["PromotionDate"]) == "")
					{
						ViewModel.sprRequests.Text = Convert.ToDateTime(cTransfer.TransferRequest["AdjustedHireDate"]).ToString("M/d/yyyy");
					}
					else
					{
						ViewModel.sprRequests.Text = Convert.ToDateTime(cTransfer.TransferRequest["PromotionDate"]).ToString("M/d/yyyy");
					}
					ViewModel.sprRequests.Col = 6;
					ViewModel.sprRequests.Text = modGlobal.Clean(cTransfer.TransferRequest["CurrentAssign"]);
					ViewModel.sprRequests.Col = 7;
					ViewModel.sprRequests.Text = Convert.ToInt32(cTransfer.TransferRequest["request_id"]).ToString();
					ViewModel.sprRequests.Col = 8;
					ViewModel.sprRequests.Text = modGlobal.Clean(cTransfer.TransferRequest["employee_id"]);
					ViewModel.sprRequests.Col = 9;
					if (modGlobal.Clean(cTransfer.TransferRequest["LastChange"]) == "")
					{
						ViewModel.sprRequests.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprRequests.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferRequest["NumOfAssign"]));

						sText = "Assignment Last Changed On ";
						sText = sText + Convert.ToDateTime(cTransfer.TransferRequest["LastChange"]).ToString("M/d/yyyy");
						ViewModel.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
						ViewModel.sprRequests.Col = 9;
						ViewModel.sprRequests.CellNoteIndicator = true;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprRequests.CellNote = sText;
					}


					cTransfer.TransferRequest.MoveNext();
				};
			}
			ViewModel.sprRequests.MaxRows = CurrRow + 1;



		}

		public void ClearFields()
		{
			ViewModel.dteOpenDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteCloseDate.Text = DateTime.Now.AddDays(30).ToString("MM/dd/yyyy");
			ViewModel.cboUnitList.SelectedIndex = -1;
			ViewModel.cboPositionList.Items.Clear();
			ViewModel.cboShiftList.Items.Clear();
			ViewModel.cboNameList.SelectedIndex = -1;
			ViewModel.cboPriority.SelectedIndex = -1;
			ViewModel.txtComment.Text = "";

			for (int i = 0; i <= ViewModel.lstAvailPositions.Items.Count - 1; i++)
			{
				UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstAvailPositions, i, false);
			}

		}

		public void FillLists()
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";
			ViewModel.cboPriority.Items.Clear();
			if (cTransfer.GetTransferPriorityCodeList() != 0)
			{

				while(!cTransfer.TransferPriorityCode.EOF)
				{
					ViewModel.cboPriority.AddItem(modGlobal.Clean(cTransfer.TransferPriorityCode["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboPriority.SetItemData(ViewModel.cboPriority.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(cTransfer.TransferPriorityCode["priority_code"])));
					cTransfer.TransferPriorityCode.MoveNext();
				};
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Fill Employee Name Lists
			ViewModel.cboReqNameList.Items.Clear();
			ViewModel.cboNameList.Items.Clear();

			if (modGlobal.Shared.gSecurity != "RO")
			{

				oCmd.CommandText = "spOpNameList";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					ViewModel.cboNameList.AddItem(strName);
					ViewModel.cboReqNameList.AddItem(strName);
					oRec.MoveNext();
				};
				ViewModel.cboNameList.SelectedIndex = -1;
				ViewModel.cboReqNameList.SelectedIndex = -1;
			}
			ViewModel.cboReqPositionList.Items.Clear();
			ViewModel.cboPositionList.Items.Clear();
			ViewModel.cboShiftList.Items.Clear();
			ViewModel.cboUnitList.Items.Clear();
			oCmd.CommandText = "spUnitList";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnitList.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboUnitList.AddItem(Convert.ToString(oRec["unit_code"]));
				oRec.MoveNext();
			}
			;


					}

		private void EnableButton()
		{

			if ( ViewModel.optRequest.Checked)
			{
				if ( ViewModel.cboNameList.SelectedIndex != -1 && ViewModel.cboPriority.SelectedIndex != -1 && ViewModel.lstAvailPositions.SelectedIndex != -1)
				{
					ViewModel.cmdReqDone.Enabled = true;
				}
			}
			else if ( ViewModel.optNewPosition.Checked)
			{
				if ( ViewModel.cboUnitList.SelectedIndex != -1 && ViewModel.cboPositionList.SelectedIndex != -1 && ViewModel.cboShiftList.SelectedIndex != -1)
				{
					ViewModel.cmdAddPosition.Enabled = true;
				}
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboNameList.SelectedIndex == -1)
			{
				return;
			}

			RefreshPositionLists();
			ViewModel.CurrEmployee = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));

			EnableButton();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPositionList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPositionList.SelectedIndex == -1)
			{
				return;
			}

			EnableButton();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPriority_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboPriority.SelectedIndex == -1)
			{
				return;
			}
			EnableButton();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboReqNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboReqNameList.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.FilterEmployee = ViewModel.cboReqNameList.Text.Substring(Math.Max(ViewModel.cboReqNameList.Text.Length - 5, 0));
			FillGrids();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboReqPositionList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboReqPositionList.SelectedIndex == -1)
			{
				return;
			}
			FillGrids();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboShiftList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboShiftList.SelectedIndex == -1)
			{
				return;
			}

			EnableButton();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnitList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Position List with valid Positions
			//for selected Unit
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboUnitList.SelectedIndex == -1)
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spPositionList '" + ViewModel.cboUnitList.Text + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboPositionList.Items.Clear();


			while(!oRec.EOF)
			{
				ViewModel.cboPositionList.AddItem(modGlobal.Clean(oRec["position_code"]));
				oRec.MoveNext();
			};
			if ( ViewModel.cboPositionList.Items.Count == 1)
			{
				ViewModel.cboPositionList.SelectedIndex = 0;
			}

			oCmd.CommandText = "spSelect_ShiftListByUnit '" + ViewModel.cboUnitList.Text + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboShiftList.Items.Clear();


			while(!oRec.EOF)
			{
				ViewModel.cboShiftList.AddItem(modGlobal.Clean(oRec["shift_code"]));
				oRec.MoveNext();
			};
			if ( ViewModel.cboShiftList.Items.Count == 1)
			{
				ViewModel.cboShiftList.SelectedIndex = 0;
			}


			EnableButton();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkActiveOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillGrids();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddPosition_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//check assignment selections to determine if valid
			//combination of unit, position & shift have been selected
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int AssignmentID = 0;
			ViewModel.cmdAddPosition.Enabled = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string SqlString = "sp_GetAssign '" + modGlobal.Clean(ViewModel.cboUnitList.Text) + "','";
			SqlString = SqlString + modGlobal.Clean(ViewModel.cboPositionList.Text) + "','" + modGlobal.Clean(ViewModel.cboShiftList.Text) + "'";
			oCmd.CommandText = SqlString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Invalid assignment - Please check shift selection", "Assignment Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				AssignmentID = Convert.ToInt32(modGlobal.GetVal(oRec["assignment_id"]));
			}

			cTransfer.TransferPositionAssignmentID = AssignmentID.ToString();
			cTransfer.TransferPositionDateOpen = DateTime.Parse(ViewModel.dteOpenDate.Text).ToString("M/d/yyyy");
			cTransfer.TransferPositionDateClosed = DateTime.Parse(ViewModel.dteCloseDate.Text).ToString("M/d/yyyy");
			//cTransfer.TransferPositionDateClosed = Format$(dteCloseDate.Text, "m/d/yyyy") & " 12:00:00"
			cTransfer.TransferPositionActiveFlag = "Y";
			cTransfer.TransferPositionDateCreated = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cTransfer.TransferPositionCreatedBy = modGlobal.Shared.gUser;
			cTransfer.TransferPositionStatusChanged = "";
			cTransfer.TransferPositionChangedBy = "";

			if ( ViewModel.chkPMOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				cTransfer.TransferPositionParamedicOnly = "Y";
			}
			else
			{
				cTransfer.TransferPositionParamedicOnly = "N";
			}

			if (cTransfer.InsertTransferPosition())
			{

			}
			else
			{
				ViewManager.ShowMessage("Ooooops! Something went wrong with Adding the Transfer Position!", "Insert Transfer Position", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

			FillGrids();
			RefreshPositionLists();
			ClearFields();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Open frmAssign - pass currently selected employee_id

			modGlobal
				.Shared.gAssignID = ViewModel.FilterEmployee;
			ViewManager.NavigateToView(
				frmAssign.DefInstance);
			/*			frmAssign.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearRequest_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboReqNameList.SelectedIndex = -1;
			ViewModel.cboReqPositionList.SelectedIndex = -1;
			ViewModel.FilterEmployee = "";
			ViewModel.NoRefresh = false;

			FillGrids();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDisplay_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(

				frmTransfReqAssign.DefInstance);
			/*			frmTransfReqAssign.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdInactivate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult) 0;
				ViewModel.cmdInactivate.Enabled = false;

				if ( ViewModel.CurrPosition == 0)
				{
					this.Return();
					return ;
				}
				if (cTransfer.GetTransferPositionByID(ViewModel.CurrPosition) != 0)
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(()
							=> ViewManager.ShowMessage("Are you sure you want to Inactivate this Posted Position?", "Inactivate Posted Position", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							resp = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (resp != UpgradeHelpers.Helpers.DialogResult.Yes)
							{
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprPositions.ClearSelection();
								ViewModel.CurrPosition = 0;
								this.Return();
								return ;
							}
						});
						}
						else
						{
					ViewManager.ShowMessage("Ooooops!  There was a problem finding the record in the database.  Try Again", "Find Position Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPositions.ClearSelection();
					ViewModel.CurrPosition = 0;
					this.Return();
					return ;
				}
				async1.Append(() =>
					{

						//If you're here... then procede in updating the record and refreshing the list...

						cTransfer.TransferPositionActiveFlag = "N";
						cTransfer.TransferPositionStatusChanged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
						cTransfer.TransferPositionChangedBy = modGlobal.Shared.gUser;

						if (cTransfer.UpdateTransferPosition())
						{
							//success!!
						}
						else
						{
							ViewManager.ShowMessage("Ooooops!  Something went wrong updating the Position Record!", "Update Position Record", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
						ViewModel.cboReqNameList.SelectedIndex = -1;
						ViewModel.FilterEmployee = "";
						ViewModel.cboReqPositionList.SelectedIndex = -1;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprPositions.ClearSelection();
						ViewModel.CurrPosition = 0;
						RefreshPositionLists();
						FillGrids();
					});
			}

					}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Print Transfer Request List"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintAbortMsg("Printing Transfer Request List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprRequests.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReqDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			//int i = 0;

			//the following should never happen...
			if (modGlobal.Clean(ViewModel.CurrEmployee) == "")
			{
				return;
			}
			if ( ViewModel.lstAvailPositions.SelectedIndex == -1)
			{
				return;
			}
			if ( ViewModel.cboPriority.SelectedIndex == -1)
			{
				return;
			}

			cTransfer.TransferRequestEmployeeID = modGlobal.Clean(ViewModel.CurrEmployee);
			cTransfer.TransferRequestPositionID = ViewModel.lstAvailPositions.GetItemData(ViewModel.lstAvailPositions.SelectedIndex);
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			cTransfer.TransferRequestPriorityCode = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboPriority.GetItemData(ViewModel.cboPriority.SelectedIndex)));
			cTransfer.TransferRequestCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cTransfer.TransferRequestCreatedBy = modGlobal.Shared.gUser;
			cTransfer.TransferRequestComment = modGlobal.Clean(ViewModel.txtComment.Text);

			if (cTransfer.InsertTransferRequest())
			{

			}
			else
			{
				ViewManager.ShowMessage("Ooooops! Something went wrong with Adding the Transfer Request!", "Insert Transfer Request", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.lstAvailPositions.RemoveItem(ViewModel.lstAvailPositions.SelectedIndex);
			UpgradeHelpers.Helpers.ListBoxHelper.SetSelectedIndex(ViewModel.lstAvailPositions, -1);
			ViewModel.cboPriority.SelectedIndex = -1;
			ViewModel.txtComment.Text = "";

			FillGrids();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dteOpenDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.dteCloseDate.Text = DateTime.Parse(ViewModel.dteOpenDate.Text).AddDays(30).ToString("MM/dd/yyyy");

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			//default fields
			ViewModel.FilterEmployee = "";
			ViewModel.CurrEmployee = "";
			ViewModel.NoRefresh = false;
			ViewModel.CurrPosition = 0;
			ViewModel.optNewPosition.Checked = true;
			ViewModel.frmRequest.Visible = false;
			ViewModel.frmAddPosition.Visible = true;

			FillLists();
			RefreshPositionLists();
			ClearFields();
			FillGrids();

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstAvailPositions_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.lstAvailPositions.SelectedIndex == -1)
			{
				return;
			}
			EnableButton();
		}

		[UpgradeHelpers.Events.Handler]
		internal void optNewPosition_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.frmAddPosition.Visible = true;
				ViewModel.frmRequest.Visible = false;

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optRequest_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.frmAddPosition.Visible = false;
				ViewModel.frmRequest.Visible = true;
				RefreshPositionLists();
			}
		}

		private void sprPositions_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//Need to Edit Position...
			//int i = 0;
			ViewModel.cmdInactivate.Enabled = false;

			if (Row == 0)
			{
				return;
			}
			ViewModel.sprPositions.Row = Row;
			ViewModel.sprPositions.Col = 6;
			if (modGlobal.Clean(ViewModel.sprPositions.Text) == "")
			{
				return;
			}
			if ( ViewModel.sprPositions.BackColor == UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE))
			{
				return;
			}
			ViewModel.CurrPosition = Convert.ToInt32(Double.Parse(ViewModel.sprPositions.Text));
			ViewModel.cmdInactivate.Enabled = true;

		}

		private void sprPositions_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprPositions.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprPositions.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		private void sprRequests_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;

			if (Row == 0)
			{
				return;
			}
			ViewModel.sprRequests.Row = Row;
			ViewModel.sprRequests.Col = 8;
			if (modGlobal.Clean(ViewModel.sprRequests.Text) == "")
			{
				return;
			}

			string Empid = modGlobal.Clean(ViewModel.sprRequests.Text);
			for (int i = 0; i <= ViewModel.cboReqNameList.Items.Count - 1; i++)
			{
				if (Empid == ViewModel.cboReqNameList.GetListItem(i).Substring(Math.Max(ViewModel.cboReqNameList.GetListItem(i).Length - 5, 0)))
				{
					ViewModel.NoRefresh = true;
					ViewModel.cboReqNameList.SelectedIndex = i;
					break;
				}
			}
			ViewModel.NoRefresh = false;
		}

		private void sprRequests_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprRequests.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprRequests.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTransferRequest DefInstance
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

		public static frmTransferRequest CreateInstance()
		{
			PTSProject.frmTransferRequest theInstance = Shared.Container.Resolve< frmTransferRequest>();
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
			ViewModel.frmRequest.LifeCycleStartup();
			ViewModel.frmAddPosition.LifeCycleStartup();
			ViewModel.sprPositions.LifeCycleStartup();
			ViewModel.sprRequests.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmRequest.LifeCycleShutdown();
			ViewModel.frmAddPosition.LifeCycleShutdown();
			ViewModel.sprPositions.LifeCycleShutdown();
			ViewModel.sprRequests.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTransferRequest
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTransferRequestViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTransferRequest m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}