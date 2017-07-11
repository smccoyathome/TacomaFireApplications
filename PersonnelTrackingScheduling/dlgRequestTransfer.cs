using System;
using System.Data;
using System.Data.Common;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgRequestTransfer
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgRequestTransferViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgRequestTransfer));
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


		private void dlgRequestTransfer_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**********************************************
		//***  dlgRequestTransfer Screen             ***
		//**********************************************
		//*** This screen is available to anyone     ***
		//*** from the Individulal Scheduler.  If    ***
		//*** Security is RO... then only person in  ***
		//*** drop down employee lists is yourself.  ***
		//**********************************************

		private void EnableButtons()
		{

			if ( ViewModel.optRequest.Checked)
			{
				ViewModel.cmdReqDone.Enabled = ViewModel.CurrPosition != 0 && ViewModel.CurrEmployee != "" && ViewModel.cboPriority.SelectedIndex != -1;
			}
			else if ( ViewModel.optDelete.Checked)
			{
				ViewModel.cmdDelete.Enabled = ViewModel.CurrRequest != 0 && ViewModel.CurrEmployee != "";
			}

			//     If CurrPosition <> 0 Then
			//        sprPositions.Row = CurrPosRow
			//        sprPositions.Row2 = CurrPosRow
			//        sprPositions.Col = 1
			//        sprPositions.Col = sprPositions.MaxCols
			//        sprPositions.BlockMode = True
			//        sprPositions.BackColor = LT_BLUE
			//        sprPositions.BlockMode = False
			//    End If
			//
			//    If CurrRequest <> 0 Then
			//        sprRequests.Row = CurrReqRow
			//        sprRequests.Row2 = CurrReqRow
			//        sprRequests.Col = 1
			//        sprRequests.Col = sprRequests.MaxCols
			//        sprRequests.BlockMode = True
			//        sprRequests.BackColor = YELLOW
			//        sprRequests.BlockMode = False
			//    End If

		}

		private void FillRequestGrid()
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			StringBuilder sText = new System.Text.StringBuilder();
			ViewModel.sprRequests.Row = 1;
			ViewModel.sprRequests.Row2 = ViewModel.sprRequests.MaxRows;
			ViewModel.sprRequests.Col = 1;
			ViewModel.sprRequests.Col2 = ViewModel.sprRequests.MaxCols;
			ViewModel.sprRequests.BlockMode = true;
			ViewModel.sprRequests.Text = "";
			ViewModel.sprRequests.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprRequests.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearSelection();

			int CurrRow = 0;
			if ( ViewModel.CurrEmployee == "")
			{
				return;
			}
			if (cTransfer.GetActiveTransferRequestsForEmployee(ViewModel.CurrEmployee) != 0)
			{


				while(!cTransfer.TransferRequest.EOF)
				{
					CurrRow++;
					ViewModel.sprRequests.Row = CurrRow;
					ViewModel.sprRequests.Col = 1;
					ViewModel.sprRequests.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprRequests.Text = Convert.ToString(modGlobal.GetVal(cTransfer.TransferRequest["priority_value"]));
					ViewModel.sprRequests.Col = 2;
					sText = new System.Text.StringBuilder(modGlobal.Clean(cTransfer.TransferRequest["unit_code"]));
					sText.Append(modGlobal.Clean(cTransfer.TransferRequest["shift_code"]));
					sText.Append(" " + modGlobal.Clean(cTransfer.TransferRequest["position_code"]));
					ViewModel.sprRequests.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprRequests.Text = sText.ToString();
					ViewModel.sprRequests.Col = 3;
					ViewModel.sprRequests.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprRequests.Text = Convert.ToDateTime(cTransfer.TransferRequest["created_date"]).ToString("M/d/yyyy HH:mm:ss");
					ViewModel.sprRequests.Col = 4;
					ViewModel.sprRequests.Text = Convert.ToInt32(cTransfer.TransferRequest["request_id"]).ToString();

					cTransfer.TransferRequest.MoveNext();
				};
			}

		}

		private void FillPositionGrid()
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			int CurrRow = 0;
			string sText = "";
			ViewModel.sprPositions.Row = 1;
			ViewModel.sprPositions.Row2 = ViewModel.sprPositions.MaxRows;
			ViewModel.sprPositions.Col = 1;
			ViewModel.sprPositions.Col2 = ViewModel.sprPositions.MaxCols;
			ViewModel.sprPositions.BlockMode = true;
			ViewModel.sprPositions.Text = "";
			ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprPositions.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPositions.ClearSelection();

			if (cTransfer.GetTransferPositionActiveList() != 0)
			{

				while(!cTransfer.TransferPosition.EOF)
				{
					CurrRow++;
					ViewModel.sprPositions.Row = CurrRow;

					sText = "";
					ViewModel.sprPositions.Col = 1;
					ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					sText = modGlobal.Clean(cTransfer.TransferPosition["unit_code"]);
					if (modGlobal.Clean(cTransfer.TransferPosition["paramedic_only"]) == "Y")
					{
						sText = "*" + sText;
					}
					ViewModel.sprPositions.Text = sText;
					ViewModel.sprPositions.Col = 2;
					ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprPositions.Text = modGlobal.Clean(cTransfer.TransferPosition["shift_code"]);
					ViewModel.sprPositions.Col = 3;
					ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprPositions.Text = modGlobal.Clean(cTransfer.TransferPosition["position_code"]);
					ViewModel.sprPositions.Col = 4;
					ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_open"]).ToString("M/d/yyyy");
					ViewModel.sprPositions.Col = 5;
					ViewModel.sprPositions.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprPositions.Text = Convert.ToDateTime(cTransfer.TransferPosition["date_closed"]).ToString("M/d/yyyy");
					ViewModel.sprPositions.Col = 6;
					ViewModel.sprPositions.Text = Convert.ToInt32(cTransfer.TransferPosition["position_id"]).ToString();

					cTransfer.TransferPosition.MoveNext();
				};
			}

		}

		private void FillLists()
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
			ViewModel.cboDelNameList.Items.Clear();
			ViewModel.cboNameList.Items.Clear();

			if (modGlobal.Shared.gSecurity != "RO" && modGlobal.Shared.gSecurity != "CPT")
			{

				oCmd.CommandText = "spOpNameList";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					ViewModel.cboNameList.AddItem(strName);
					ViewModel.cboDelNameList.AddItem(strName);
					oRec.MoveNext();
				};
				ViewModel.cboNameList.SelectedIndex = -1;
				ViewModel.cboDelNameList.SelectedIndex = -1;

				if (modGlobal.Shared.gReportUser != "")
				{
					ViewModel.CurrEmployee = modGlobal.Shared.gReportUser;
					modGlobal.Shared.gReportUser = "";
					for (int x = 0; x <= ViewModel.cboNameList.Items.Count - 1; x++)
					{
						if ( ViewModel.CurrEmployee == ViewModel.cboNameList.GetListItem(x).Substring(Math.Max(ViewModel.cboNameList.GetListItem(x).Length - 5, 0)))
						{
							ViewModel.cboNameList.SelectedIndex = x;
							ViewModel.cboDelNameList.SelectedIndex = x;
							ViewModel.Text = "Transfer for " + modGlobal.Clean(ViewModel.cboNameList.Text);
							break;
						}
					}
				}

			}
			else
			{
				strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
				ViewModel.cboNameList.AddItem(strName);
				ViewModel.cboNameList.SelectedIndex = 0;
				ViewModel.cboDelNameList.AddItem(strName);
				ViewModel.cboDelNameList.SelectedIndex = 0;
				ViewModel.CurrEmployee = modGlobal.Shared.gUser;
				ViewModel.Text = "Transfer for " + modGlobal.Clean(ViewModel.cboNameList.Text);
			}

			if ( ViewModel.CurrEmployee != "")
			{
				FillRequestGrid();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDelNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboDelNameList.SelectedIndex == -1)
			{
				return;
			}

			if ( ViewModel.cboNameList.Items.Count > 0)
			{
				ViewModel.cboNameList.SelectedIndex = ViewModel.cboDelNameList.SelectedIndex;
			}
			ViewModel.CurrEmployee = ViewModel.cboDelNameList.Text.Substring(Math.Max(ViewModel.cboDelNameList.Text.Length - 5, 0));

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPositions.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPositions.ClearSelection();
			ViewModel.CurrPosition = 0;
			ViewModel.lbPosition.Text = "No Position Selected";

			if ( ViewModel.CurrPosRow != 0)
			{
				ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
				int tempForVar = ViewModel.sprPositions.MaxRows;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprPositions.Col = i;
					ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrPosRow = 0;
			}

			if ( ViewModel.CurrReqRow != 0)
			{
				ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
				int tempForVar2 = ViewModel.sprRequests.MaxRows;
				for (int i = 1; i <= tempForVar2; i++)
				{
					ViewModel.sprRequests.Col = i;
					ViewModel.sprRequests.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrReqRow = 0;
			}

			if ( ViewModel.optDelete.Checked)
			{
				ViewModel.Text = "Delete Request for " + modGlobal.Clean(ViewModel.cboDelNameList.Text);
				ViewModel.CurrRequest = 0;
				ViewModel.lbPosition.Text = "No Request Selected";
				FillRequestGrid();
			}

			EnableButtons();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboNameList.SelectedIndex == -1)
			{
				return;
			}

			if ( ViewModel.cboDelNameList.Items.Count > 0)
			{
				ViewModel.cboDelNameList.SelectedIndex = ViewModel.cboNameList.SelectedIndex;
			}
			ViewModel.CurrEmployee = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearSelection();
			ViewModel.CurrRequest = 0;
			ViewModel.lbRequest.Text = "No Request Selected";

			if ( ViewModel.CurrPosRow != 0)
			{
				ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
				int tempForVar = ViewModel.sprPositions.MaxRows;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprPositions.Col = i;
					ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrPosRow = 0;
			}

			if ( ViewModel.CurrReqRow != 0)
			{
				ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
				int tempForVar2 = ViewModel.sprRequests.MaxRows;
				for (int i = 1; i <= tempForVar2; i++)
				{
					ViewModel.sprRequests.Col = i;
					ViewModel.sprRequests.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrReqRow = 0;
			}

			if ( ViewModel.optRequest.Checked)
			{
				ViewModel.Text = "Transfer for " + modGlobal.Clean(ViewModel.cboNameList.Text);
				FillRequestGrid();
			}
			EnableButtons();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPriority_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			EnableButtons();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			//    MsgBox "This feature is under construction!", vbOKOnly, "Coming Soon"
			if (modGlobal.Clean(ViewModel.CurrEmployee) == "")
			{
				return;
			}
			if ( ViewModel.CurrRequest == 0)
			{
				return;
			}

			cTransfer.TransferRequestID = ViewModel.CurrRequest;

			if (cTransfer.DeleteTransferRequest() != 0)
			{
				//success
			}
			else
			{
				ViewManager.ShowMessage("Ooooops! Something went wrong with deleting Transfer Request!", "Delete Transfer Request", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.CurrRequest = 0;
			if ( ViewModel.CurrReqRow != 0)
			{
				ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
				int tempForVar = ViewModel.sprRequests.MaxCols;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprRequests.Col = i;
					ViewModel.sprRequests.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrReqRow = 0;
			}
			ViewModel.lbRequest.Text = "";
			FillRequestGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReqDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
			//    MsgBox "This feature is under construction!", vbOKOnly, "Coming Soon"

			if (modGlobal.Clean(ViewModel.CurrEmployee) == "")
			{
				return;
			}
			if ( ViewModel.CurrPosition == 0)
			{
				return;
			}
			if ( ViewModel.cboPriority.SelectedIndex == -1)
			{
				return;
			}

			if (~cTransfer.CheckIfTransferClosed(ViewModel.CurrPosition) != 0)
			{
				ViewManager.ShowMessage("It''s too late to request a transfer for this position.", "Request Transfer", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			// Add logic to see if employee has already requested position or priority

			cTransfer.TransferRequestEmployeeID = modGlobal.Clean(ViewModel.CurrEmployee);
			cTransfer.TransferRequestPositionID = ViewModel.CurrPosition;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			cTransfer.TransferRequestPriorityCode = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboPriority.GetItemData(ViewModel.cboPriority.SelectedIndex)));
			cTransfer.TransferRequestCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cTransfer.TransferRequestCreatedBy = modGlobal.Shared.gUser;
			cTransfer.TransferRequestComment = modGlobal.Clean(ViewModel.txtComment.Text);

			if (cTransfer.CheckRequestForPositionPriority() != 0)
			{
				ViewManager.ShowMessage("You have already have a request for Position or Priority.", "Request Transfer", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if (cTransfer.InsertTransferRequest())
			{

			}
			else
			{
				ViewManager.ShowMessage("Ooooops! Something went wrong with Adding the Transfer Request!", "Insert Transfer Request", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.CurrPosition = 0;
			if ( ViewModel.CurrPosRow != 0)
			{
				ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
				int tempForVar = ViewModel.sprPositions.MaxCols;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprPositions.Col = i;
					ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
				}
				ViewModel.CurrPosRow = 0;
			}
			ViewModel.lbPosition.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.cboPriority.SelectedIndex = -1;

			FillRequestGrid();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;
			//string strName = "";
			//int x = 0;

			//default fields
			ViewModel.optRequest.Checked = true;
			ViewModel.frmRequestTransfer.Visible = true;
			ViewModel.frmDeleteRequest.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.lbPosition.Text = "No Position Selected";
			ViewModel.lbRequest.Text = "No Request Selected";
			ViewModel.CurrEmployee = "";
			ViewModel.CurrPosition = 0;

			FillLists();
			FillPositionGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void optDelete_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.frmRequestTransfer.Visible = false;
				ViewModel.frmDeleteRequest.Visible = true;

				if ( ViewModel.CurrEmployee == "")
				{
					ViewModel.cboDelNameList.SelectedIndex = -1;
					this.ViewModel.Text = "Delete Transfer Request";
				}

				if ( ViewModel.CurrRequest == 0)
				{
					ViewModel.lbRequest.Text = "No Request Selected";
				}

				EnableButtons();

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
				ViewModel.frmRequestTransfer.Visible = true;
				ViewModel.frmDeleteRequest.Visible = false;


				if ( ViewModel.cboPriority.Items.Count > 0)
				{
					ViewModel.cboPriority.SelectedIndex = 0;
				}
				ViewModel.txtComment.Text = "";

				if ( ViewModel.CurrEmployee == "")
				{
					ViewModel.cboNameList.SelectedIndex = -1;
					this.ViewModel.Text = "Request Transfer";
				}

				if ( ViewModel.CurrPosition == 0)
				{
					ViewModel.lbPosition.Text = "No Position Selected";
				}

				EnableButtons();

			}
		}

		private void sprPositions_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();

			if ( ViewModel.CurrPosRow != 0)
			{
				ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
				int tempForVar = ViewModel.sprPositions.MaxCols;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprPositions.Col = i;
					ViewModel.sprPositions.BackColor = modGlobal.Shared.WHITE;
				}
			}

			if (Row == 0)
			{
				return;
			}
			ViewModel.lbPosition.Text = "";
			ViewModel.CurrPosition = 0;
			ViewModel.CurrPosRow = Row;
			ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
			ViewModel.sprPositions.Col = 6;
			if (modGlobal.Clean(ViewModel.sprPositions.Text) == "")
			{
				ViewModel.CurrPosition = 0;
				ViewModel.CurrPosRow = 0;
			}
			else
			{
				ViewModel.CurrPosition = Convert.ToInt32(Double.Parse(ViewModel.sprPositions.Text));
			}

			if ( ViewModel.CurrPosition == 0)
			{
				ViewModel.CurrPosRow = 0;
				return;
			}

			if (~cTransfer.GetTransferPositionByID(ViewModel.CurrPosition) != 0)
			{
				ViewManager.ShowMessage("Oooops!  Can't find Position Record... Try Again!", "Get Position Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.CurrPosition = 0;
				ViewModel.CurrPosRow = 0;
				return;
			}
			ViewModel.sprPositions.Col = 1;
			string sText = modGlobal.Clean(ViewModel.sprPositions.Text);
			ViewModel.sprPositions.Col = 2;
			sText = sText + modGlobal.Clean(ViewModel.sprPositions.Text);
			ViewModel.sprPositions.Col = 3;
			sText = sText + " " + modGlobal.Clean(ViewModel.sprPositions.Text);
			ViewModel.lbPosition.Text = sText;

			if ( ViewModel.CurrPosRow != 0)
			{
				ViewModel.sprPositions.Row = ViewModel.CurrPosRow;
				int tempForVar2 = ViewModel.sprPositions.MaxCols;
				for (int i = 1; i <= tempForVar2; i++)
				{
					ViewModel.sprPositions.Col = i;
					ViewModel.sprPositions.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				}
			}

			EnableButtons();

		}

		private void sprRequests_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();

			if ( ViewModel.CurrReqRow != 0)
			{
				ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
				int tempForVar = ViewModel.sprRequests.MaxRows;
				for (int i = 1; i <= tempForVar; i++)
				{
					ViewModel.sprRequests.Col = i;
					ViewModel.sprRequests.BackColor = modGlobal.Shared.WHITE;
				}
			}

			if (Row == 0)
			{
				return;
			}
			ViewModel.lbRequest.Text = "";
			ViewModel.CurrRequest = 0;
			ViewModel.CurrReqRow = Row;
			ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
			ViewModel.sprRequests.Col = 4;
			if (modGlobal.Clean(ViewModel.sprRequests.Text) == "")
			{
				ViewModel.CurrRequest = 0;
				ViewModel.CurrReqRow = 0;
			}
			else
			{
				ViewModel.CurrRequest = Convert.ToInt32(Double.Parse(ViewModel.sprRequests.Text));
			}

			if ( ViewModel.CurrRequest == 0)
			{
				ViewModel.CurrReqRow = 0;
				return;
			}

			if (~cTransfer.GetTransferRequestByID(ViewModel.CurrRequest) != 0)
			{
				ViewManager.ShowMessage("Oooops!  Can't find Request Record... Try Again!", "Get Request Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.CurrRequest = 0;
				ViewModel.CurrReqRow = 0;
				return;
			}
			ViewModel.sprRequests.Col = 2;
			ViewModel.lbRequest.Text = modGlobal.Clean(ViewModel.sprRequests.Text);

			if ( ViewModel.CurrReqRow != 0)
			{
				ViewModel.sprRequests.Row = ViewModel.CurrReqRow;
				int tempForVar2 = ViewModel.sprRequests.MaxRows;
				for (int i = 1; i <= tempForVar2; i++)
				{
					ViewModel.sprRequests.Col = i;
					ViewModel.sprRequests.BackColor = modGlobal.Shared.YELLOW;
				}
			}

			EnableButtons();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgRequestTransfer DefInstance
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

		public static dlgRequestTransfer CreateInstance()
		{
			PTSProject.dlgRequestTransfer theInstance = Shared.Container.Resolve< dlgRequestTransfer>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.frmDeleteRequest.LifeCycleStartup();
			ViewModel.frmRequestTransfer.LifeCycleStartup();
			ViewModel.sprRequests.LifeCycleStartup();
			ViewModel.sprPositions.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmDeleteRequest.LifeCycleShutdown();
			ViewModel.frmRequestTransfer.LifeCycleShutdown();
			ViewModel.sprRequests.LifeCycleShutdown();
			ViewModel.sprPositions.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgRequestTransfer
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgRequestTransferViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgRequestTransfer m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}