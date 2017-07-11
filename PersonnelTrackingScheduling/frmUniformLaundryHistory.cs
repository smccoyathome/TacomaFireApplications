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

	public partial class frmUniformLaundryHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformLaundryHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUniformLaundryHistory));
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


		private void frmUniformLaundryHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void EditLaundryRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();
			int RecordID = 0;

			if (modGlobal.Clean(ViewModel.lbLaunderID.Text) == "")
			{
				RecordID = 0;
				//The following fields have to be filled in or defaulted
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				UniformCL.UniformLaunderUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
				if ( ViewModel.chkFlagged.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					ViewModel.chkFlagged.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					ViewModel.dteDateFlagged.Text = DateTime.Now.ToString("MM/dd/yyyy");
					ViewModel.dteDateFlagged.Visible = true;

					UniformCL.UniformLaunderFlaggedBy = modGlobal.Shared.gUser;
					UniformCL.UniformLaunderDateFlagged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
				}
				else
				{
					UniformCL.UniformLaunderDateFlagged = DateTime.Parse(ViewModel.dteDateFlagged.Text).ToString("M/d/yyyy");
					if ( ViewModel.cboFlaggedBy.SelectedIndex == -1)
					{
						UniformCL.UniformLaunderFlaggedBy = modGlobal.Shared.gUser;
					}
					else
					{
						UniformCL.UniformLaunderFlaggedBy = ViewModel.cboFlaggedBy.Text.Substring(Math.Max(ViewModel.cboFlaggedBy.Text.Length - 5, 0));
					}
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				RecordID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbLaunderID.Text));
				if (UniformCL.GetUniformLaunderInfoByID(RecordID) != 0)
				{
					//continue...
				}
				else
				{
					ViewManager.ShowMessage("Ooooops!  The UniformLaunderInfo record could not be found!", "Error Could not find Record for Update", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			//edit the rest of the fields
			UniformCL.UniformLaunderComment = modGlobal.Clean(ViewModel.txtComment.Text);

			if ( ViewModel.chkApproved.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				UniformCL.UniformLaunderDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
				UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
			}

			if ( ViewModel.chkCleaned.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				UniformCL.UniformLaunderCleaningComments = modGlobal.Clean(ViewModel.txtLaundryComment.Text);
				UniformCL.UniformLaunderDateCleaned = DateTime.Parse(ViewModel.dteDateCleaned.Text).ToString("M/d/yyyy");
				UniformCL.UniformLaunderCleanedBy = "";
				UniformCL.UniformLaunderVendorCleaned = "N";
				if ( ViewModel.chkVendor.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					if (modGlobal.Clean(ViewModel.cboCleanedBy.Text) != "")
					{
						UniformCL.UniformLaunderCleanedBy = ViewModel.cboCleanedBy.Text.Substring(Math.Max(ViewModel.cboCleanedBy.Text.Length - 5, 0));
					}
				}
				else
				{
					UniformCL.UniformLaunderVendorCleaned = "Y";
				}
			}

			if (RecordID == 0)
			{ //Add
				if (UniformCL.InsertUniformLaunderInfo() != 0)
				{
					RecordID = UniformCL.UniformLaunderID;
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert Laundry Record!", "Error Inserting UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				//Update
				if (UniformCL.UpdateUniformLaunderInfo() != 0)
				{

				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Update Laundry Record!", "Error Updating UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

		}

		public void ClearDetail()
		{
			ViewModel.dteDateFlagged.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteDateCleaned.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dteDateFlagged.Visible = false;
			ViewModel.dteDateCleaned.Visible = false;
			ViewModel.chkFlagged.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkCleaned.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkApproved.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.chkApproved.Text = "PPE Item is ready for Use?";
			ViewModel.cboFlaggedBy.SelectedIndex = -1;
			ViewModel.cboFlaggedBy.Text = "";
			ViewModel.cboCleanedBy.SelectedIndex = -1;
			ViewModel.cboCleanedBy.Text = "";
			ViewModel.cboCleanedBy.Visible = true;
			ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.txtComment.Text = "";
			ViewModel.txtLaundryComment.Text = "";
			ViewModel.lbLaunderID.Text = "";
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprLaunderGrid.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprLaunderGrid.ClearSelection();

		}

		public void FillLaunderGrid()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			if (UniformCL.GetPPELaundryInfoHistoryByItem(modGlobal.Shared.gUniformID) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("This Item has no Laundry/Cleaning History.", "Uniform Laundry/Cleaning History", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprLaunderGrid.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprLaunderGrid.ClearRange(1, 1, ViewModel.sprLaunderGrid.MaxCols, ViewModel.sprLaunderGrid.MaxRows, false);
			ViewModel.iCurrRow = 0;


			while(!UniformCL.UniformLaundry.EOF)
			{
				(ViewModel.iCurrRow)++;
				ViewModel.sprLaunderGrid.Row = ViewModel.iCurrRow;
				ViewModel.sprLaunderGrid.Col = 1;
				ViewModel.sprLaunderGrid.Text = Convert.ToDateTime(UniformCL.UniformLaundry["date_flagged"]).ToString("M/d/yyyy") + " - " +
							modGlobal.Clean(UniformCL.UniformLaundry["FlaggedBy"]);
				ViewModel.sprLaunderGrid.Col = 3;
				if (modGlobal.Clean(UniformCL.UniformLaundry["date_approved"]) == "")
				{
					ViewModel.sprLaunderGrid.Text = "";
				}
				else
				{
					ViewModel.sprLaunderGrid.Text = Convert.ToDateTime(UniformCL.UniformLaundry["date_approved"]).ToString("M/d/yyyy") + " - " +
								modGlobal.Clean(UniformCL.UniformLaundry["ApprovedBy"]);
				}
				ViewModel.sprLaunderGrid.Col = 2;
				if (modGlobal.Clean(UniformCL.UniformLaundry["date_cleaned"]) == "")
				{
					ViewModel.sprLaunderGrid.Text = "";
				}
				else
				{
					if (modGlobal.Clean(UniformCL.UniformLaundry["vendor_cleaned"]) == "N")
					{
						ViewModel.sprLaunderGrid.Text = Convert.ToDateTime(UniformCL.UniformLaundry["date_cleaned"]).ToString("M/d/yyyy") + " - " +
									modGlobal.Clean(UniformCL.UniformLaundry["CleanedBy"]);
					}
					else
					{
						ViewModel.sprLaunderGrid.Text = Convert.ToDateTime(UniformCL.UniformLaundry["date_cleaned"]).ToString("M/d/yyyy") +
								" - Vendor Cleaned";
					}
				}
				ViewModel.sprLaunderGrid.Col = 4;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprLaunderGrid.Text = Convert.ToString(modGlobal.GetVal(UniformCL.UniformLaundry["launder_id"]));

				if (modGlobal.Clean(UniformCL.UniformLaundry["comment"]) != "")
				{
					ViewModel.sprLaunderGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprLaunderGrid.Col = 1;
					ViewModel.sprLaunderGrid.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLaunderGrid.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprLaunderGrid.CellNote = modGlobal.Clean(UniformCL.UniformLaundry["comment"]);
				}

				if (modGlobal.Clean(UniformCL.UniformLaundry["laundry_comment"]) != "")
				{
					ViewModel.sprLaunderGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprLaunderGrid.Col = 2;
					ViewModel.sprLaunderGrid.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLaunderGrid.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprLaunderGrid.CellNote = modGlobal.Clean(UniformCL.UniformLaundry["laundry_comment"]);
				}

				UniformCL.UniformLaundry.MoveNext();
			}
			;



					}

		public void GetUniformDetail()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			if (UniformCL.GetUniformDetailByID(modGlobal.Shared.gUniformID) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops! Can't find any Uniform Information based on ID = " + modGlobal.Shared.gUniformID
					.ToString() + "!  Call Debra Lewandowsky x5068.", "Uniform Repair History", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.lbItem.Text = modGlobal.Clean(UniformCL.Uniform["Item"]);
			ViewModel.lbTrackingNumber.Text = modGlobal.Clean(UniformCL.Uniform["tracking_number"]);
			ViewModel.lbRetiredReason.Text = modGlobal.Clean(UniformCL.Uniform["reason_description"]);

			if (modGlobal.Clean(UniformCL.Uniform["retired_date"]) != "")
			{
				ViewModel.lbRetiredDate.Text = Convert.ToDateTime(UniformCL.Uniform["retired_date"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbRetiredDate.Text = "";
			}

			if (modGlobal.Clean(UniformCL.Uniform["InspDate"]) != "")
			{
				ViewModel.lbLastInspDate.Text = Convert.ToDateTime(UniformCL.Uniform["InspDate"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbLastInspDate.Text = "";
			}
			ViewModel.lbBrand.Text = modGlobal.Clean(UniformCL.Uniform["manufacturer_name"]);

			if (modGlobal.Clean(UniformCL.Uniform["manufactured_date"]) != "")
			{
				ViewModel.lbManufDate.Text = Convert.ToDateTime(UniformCL.Uniform["manufactured_date"]).ToString("M/d/yyyy");
			}
			else
			{
				ViewModel.lbManufDate.Text = "";
			}

			if (modGlobal.Clean(UniformCL.Uniform["ItemSize"]) != "")
			{
				ViewModel.lbColorSize.Text = modGlobal.Clean(UniformCL.Uniform["ItemSize"]);
			}
			else if (modGlobal.Clean(UniformCL.Uniform["ItemColor"]) != "")
			{
				ViewModel.lbColorSize.Text = modGlobal.Clean(UniformCL.Uniform["ItemColor"]);
			}
			else
			{
				ViewModel.lbColorSize.Text = "";
			}

			if (modGlobal.Clean(UniformCL.Uniform["name_full"]) != "")
			{
				ViewModel.lbLocation.Text = "Issued to " + modGlobal.Clean(UniformCL.Uniform["name_full"]);
			}
			else if (modGlobal.Clean(UniformCL.Uniform["station"]) != "")
			{
				ViewModel.lbLocation.Text = "Station " + modGlobal.Clean(UniformCL.Uniform["station"]);
			}
			else
			{
				ViewModel.lbLocation.Text = "";
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(UniformCL.Uniform["uniform_id"]));
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(ViewModel.lbUniformID.Text));

			FillLaunderGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkApproved_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			string sEmployeeName = "";

			if (!ViewModel.bAllowUpdate)
			{
				return;
			}
			if ( ViewModel.chkApproved.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				if (TrainCL.GetEmployee(modGlobal.Shared.gUser) != 0)
				{
					sEmployeeName = modGlobal.Clean(TrainCL.Employee["name_full"]);
					ViewModel.chkApproved.Text = "PPE Item was cleared for use by " + sEmployeeName +
								" on " + DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
					ViewModel.cmdEdit.Enabled = true;
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  You cannot be found in the database", "Personnel Record not found!", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				ViewModel.chkApproved.Text = "PPE Item is ready for Use?";
				ViewModel.cmdEdit.Enabled = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkCleaned_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if (!ViewModel.bAllowUpdate)
			{
				return;
			}

			if ( ViewModel.chkCleaned.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.dteDateCleaned.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.dteDateCleaned.Visible = true;
				ViewModel.cmdEdit.Enabled = true;
				for (int i = 0; i <= ViewModel.cboCleanedBy.Items.Count - 1; i++)
				{
					if ( ViewModel.cboCleanedBy.GetListItem(i).Substring(Math.Max(ViewModel.cboCleanedBy.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gUser)
					{
						ViewModel.cboCleanedBy.Text = ViewModel.cboCleanedBy.GetListItem(i);
						break;
					}
				}
				ViewModel.cmdEdit.Enabled = true;
			}
			else
			{
				ViewModel.dteDateCleaned.Visible = false;
				ViewModel.cmdEdit.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkFlagged_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if (!ViewModel.bAllowUpdate)
			{
				return;
			}
			if ( ViewModel.chkFlagged.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				//default fields...
				for (int i = 0; i <= ViewModel.cboFlaggedBy.Items.Count - 1; i++)
				{
					if ( ViewModel.cboFlaggedBy.GetListItem(i).Substring(Math.Max(ViewModel.cboFlaggedBy.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gUser)
					{
						ViewModel.cboFlaggedBy.Text = ViewModel.cboFlaggedBy.GetListItem(i);
						break;
					}
				}
				ViewModel.dteDateFlagged.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.dteDateFlagged.Visible = true;
				ViewModel.cmdEdit.Enabled = true;
			}
			else
			{
				ViewModel.dteDateFlagged.Visible = false;
				ViewModel.cmdEdit.Enabled = false;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkVendor_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboCleanedBy.Visible = ViewModel.chkVendor.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEdit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is underconstruction.", vbOKOnly, "Adding/Updating Laundry Record"

			if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
			{
				return;
			}
			ViewModel.cmdEdit.Enabled = false;

			//Edit Fields and Add/Update Record
			EditLaundryRecord();

			FillLaunderGrid();

			cmdNewItem_Click(ViewModel.cmdNewItem, new System.EventArgs());

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdFind_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (modGlobal.Clean(ViewModel.txtTrackingNumber.Text) == "")
			{
				return;
			}

			ClearDetail();
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprLaunderGrid.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprLaunderGrid.ClearRange(1, 1, ViewModel.sprLaunderGrid.MaxCols, ViewModel.sprLaunderGrid.MaxRows, false);
			ViewModel.iCurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_UniformByTrackingNumber '" + modGlobal.Clean(ViewModel.txtTrackingNumber.Text) + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Item could not be found.", "Search on Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(ViewModel.lbUniformID.Text));

			GetUniformDetail();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewItem_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ClearDetail();
			ViewModel.cmdEdit.Text = "Add";
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.cmdEdit.Tag = "1";
			ViewModel.bAllowUpdate = true;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Employees
			string strSQL = "spFullNameList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboFlaggedBy.Items.Clear();
			ViewModel.cboCleanedBy.Items.Clear();
			ViewModel.cboFlaggedBy.Text = "";
			ViewModel.cboCleanedBy.Text = "";

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				ViewModel.cboFlaggedBy.AddItem(strName);
				ViewModel.cboCleanedBy.AddItem(strName);

				oRec.MoveNext();
			};
			ViewModel.txtTrackingNumber.Text = "";
			GetUniformDetail();


			ClearDetail();
			ViewModel.cmdEdit.Text = "Add";
			ViewModel.cmdEdit.Enabled = false;
			ViewModel.cmdEdit.Tag = "1";
			ViewModel.bAllowUpdate = true;

		}

		private void sprLaunderGrid_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();


			if (Row == 0)
			{
				return;
			}
			ViewModel.iCurrRow = Row;
			ViewModel.sprLaunderGrid.Row = ViewModel.iCurrRow;
			//ViewModel.sprLaunderGrid.SetSelection(1, ViewModel.iCurrRow, ViewModel.sprLaunderGrid.MaxCols, ViewModel.iCurrRow);
			ViewModel.sprLaunderGrid.Col = 4;
			if (modGlobal.Clean(ViewModel.sprLaunderGrid.Text) == "")
			{
				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.lbLaunderID.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprLaunderGrid.Text));
			}
			ViewModel.bAllowUpdate = false;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (UniformCL.GetUniformLaunderInfoByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbLaunderID.Text))) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops! No Uniform Laundry/Cleaning ecord was found!", "Get Laundry/Cleaning Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.lbLaunderID.Text = UniformCL.UniformLaunderID.ToString();
			if (UniformCL.UniformLaunderDateFlagged == "")
			{
				ViewManager.ShowMessage("Ooooops!  Something is wrong!  Call Debra Lewandowsky x5068.", "Missing Flagged Date!!", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				ViewModel.chkFlagged.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteDateFlagged.Text = UniformCL.UniformLaunderDateFlagged;
				ViewModel.dteDateFlagged.Visible = true;
			}

			if (UniformCL.UniformLaunderDateCleaned == "")
			{
				ViewModel.chkCleaned.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteDateCleaned.Visible = false;
				ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.cboFlaggedBy.Visible = true;
				ViewModel.bAllowUpdate = true;
			}
			else
			{
				ViewModel.chkCleaned.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteDateCleaned.Text = UniformCL.UniformLaunderDateCleaned;
				ViewModel.dteDateCleaned.Visible = true;
			}

			for (int i = 0; i <= ViewModel.cboFlaggedBy.Items.Count - 1; i++)
			{
				if ( ViewModel.cboFlaggedBy.GetListItem(i).Substring(Math.Max(ViewModel.cboFlaggedBy.GetListItem(i).Length - 5, 0)) == UniformCL.UniformLaunderFlaggedBy)
				{
					ViewModel.cboFlaggedBy.Text = ViewModel.cboFlaggedBy.GetListItem(i);
					break;
				}
			}

			if (UniformCL.UniformLaunderVendorCleaned == "N")
			{
				for (int i = 0; i <= ViewModel.cboCleanedBy.Items.Count - 1; i++)
				{
					if ( ViewModel.cboCleanedBy.GetListItem(i).Substring(Math.Max(ViewModel.cboCleanedBy.GetListItem(i).Length - 5, 0)) == UniformCL.UniformLaunderCleanedBy)
					{
						ViewModel.cboCleanedBy.Text = ViewModel.cboCleanedBy.GetListItem(i);
						break;
					}
				}
			}
			else
			{
				ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.cboCleanedBy.Visible = false;
			}
			ViewModel.txtComment.Text = UniformCL.UniformLaunderComment;
			ViewModel.txtLaundryComment.Text = UniformCL.UniformLaunderCleaningComments;

			string sEmployeeName = "";
			if (UniformCL.UniformLaunderApprovedBy != "")
			{
				if (TrainCL.GetEmployee(UniformCL.UniformLaunderApprovedBy) != 0)
				{
					sEmployeeName = modGlobal.Clean(TrainCL.Employee["name_full"]);
				}
			}

			if (UniformCL.UniformLaunderDateApproved != "")
			{
				if (sEmployeeName != "")
				{
					ViewModel.chkApproved.Text = "PPE Item was cleared for use by " + sEmployeeName +
								" on " + UniformCL.UniformLaunderDateApproved;
					ViewModel.chkApproved.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
				else
				{
					ViewModel.chkApproved.Text = "PPE Item was cleared for use on " + UniformCL.UniformLaunderDateApproved;
					ViewModel.chkApproved.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				}
			}
			else
			{
				ViewModel.bAllowUpdate = true;
				ViewModel.chkApproved.Text = "PPE Item is ready for Use?";
				ViewModel.chkApproved.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}

			if ( ViewModel.bAllowUpdate)
			{
				ViewModel.cmdEdit.Enabled = true;
				ViewModel.cmdEdit.Text = "Update";
				ViewModel.cmdEdit.Tag = "0";
			}
			else
			{
				ViewModel.cmdEdit.Enabled = false;
				ViewModel.cmdEdit.Text = "Update";
				ViewModel.cmdEdit.Tag = "0";
			}

		}

		private void sprLaunderGrid_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprLaunderGrid.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprLaunderGrid.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprLaunderGrid.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmUniformLaundryHistory DefInstance
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

		public static frmUniformLaundryHistory CreateInstance()
		{
			PTSProject.frmUniformLaundryHistory theInstance = Shared.Container.Resolve< frmUniformLaundryHistory>();
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
			ViewModel.sprLaunderGrid.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprLaunderGrid.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUniformLaundryHistory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUniformLaundryHistoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUniformLaundryHistory m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}