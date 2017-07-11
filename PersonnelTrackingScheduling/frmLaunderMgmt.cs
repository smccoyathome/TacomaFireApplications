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

	public partial class frmLaunderMgmt
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmLaunderMgmtViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmLaunderMgmt));
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


		private void frmLaunderMgmt_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void UpdateRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			if (UniformCL.GetUniformLaunderInfoByID(Convert.ToInt32(Double.Parse(ViewModel.lbLaunderID.Text))) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("Oooops! Something is Wrong", "Where's the Laundry Record??", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

		}

		public void GetDetail()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			if ( ViewModel.CurrRow == 0)
			{
				return;
			}
			ViewModel.lbLaunderID.Text = "";
			ViewModel.sprList.Row = ViewModel.CurrRow;
			ViewModel.sprList.Col = 12;
			if (modGlobal.Clean(ViewModel.sprList.Text) == "")
			{
				ViewManager.ShowMessage("Oooops! Something is Wrong", "Where's the Launder ID??", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.lbLaunderID.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprList.Text));
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (UniformCL.GetUniformLaunderInfoByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbLaunderID.Text))) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("Oooops! Something is Wrong", "Where's the Laundry Record??", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.txtPPEInfo.Text = "";

			string sText = "PPE Info:  ";
			ViewModel.sprList.Col = 5;
			//Brand
			if (modGlobal.Clean(ViewModel.sprList.Text) != "")
			{
				sText = sText + modGlobal.Clean(ViewModel.sprList.Text) + " ";
			}
			ViewModel.sprList.Col = 2;
			//Type
			if (modGlobal.Clean(ViewModel.sprList.Text) != "")
			{
				sText = sText + modGlobal.Clean(ViewModel.sprList.Text) + " ";
			}
			else
			{
				sText = sText + "Item ";
			}
			ViewModel.sprList.Col = 3;
			//Tracking #
			if (modGlobal.Clean(ViewModel.sprList.Text) != "")
			{
				sText = sText + "- " + modGlobal.Clean(ViewModel.sprList.Text) + "; ";
			}
			ViewModel.sprList.Col = 1;
			//Station
			if (modGlobal.Clean(ViewModel.sprList.Text) != "")
			{
				sText = sText + "Located at Station " + modGlobal.Clean(ViewModel.sprList.Text) + ".  ";
			}
			else
			{
				ViewModel.sprList.Col = 7;
				if (modGlobal.Clean(ViewModel.sprList.Text) != "")
				{
					sText = sText + "Issued to " + modGlobal.Clean(ViewModel.sprList.Text);
					ViewModel.sprList.Col = 6;
					if (modGlobal.Clean(ViewModel.sprList.Text) != "")
					{
						sText = sText + " on " + modGlobal.Clean(ViewModel.sprList.Text) + ".  ";
					}
					else
					{
						sText = sText + ".  ";
					}
				}
			}

			sText = sText + "Was flagged for cleaning on " + UniformCL.UniformLaunderDateFlagged;
			if (UniformCL.UniformLaunderComment == "")
			{
				sText = sText + ".";
			}
			else
			{
				sText = sText + " - " + UniformCL.UniformLaunderComment + ".";
			}
			ViewModel.txtPPEInfo.Text = sText;
			ViewModel.cmdUpdate.Enabled = true;


		}

		public void FillGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int iType = 0;
			int iBrand = 0;
			ViewModel.sprList.Row = 1;
			ViewModel.sprList.Row2 = ViewModel.sprList.MaxRows;
			ViewModel.sprList.Col = 1;
			ViewModel.sprList.Col2 = ViewModel.sprList.MaxCols;
			ViewModel.sprList.BlockMode = true;
			ViewModel.sprList.Text = "";
			ViewModel.sprList.BlockMode = false;
			ViewModel.sprList.MaxRows = 5000;
			ViewModel.lbTotalCount.Text = "List Count:   0";
			ViewModel.sHeadingFilter = "Displaying Uniforms: ";

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

			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				iType = 0;
			}
			else
			{
				iType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
			}

			if ( ViewModel.cboBrand.SelectedIndex == -1)
			{
				iBrand = 0;
			}
			else
			{
				iBrand = ViewModel.cboBrand.GetItemData(ViewModel.cboBrand.SelectedIndex);
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spSelect_PPEUniformLaundryList ";

			if (iType == 0)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iType.ToString() + ", ";
			}
			if (iBrand == 0)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iBrand.ToString() + ", ";
			}
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
				strSQL = strSQL + "NULL ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrShift + "' ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.sprList.MaxRows = 1;
				ViewManager.ShowMessage("No PPE Information was found.", "PPE Query Information", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.sprList.Row = 0;
			int TotalCount = 0;

			while(!oRec.EOF)
			{
				(ViewModel.sprList.Row)++;
				ViewModel.sprList.Col = 1; //Station

				ViewModel.sprList.Text = modGlobal.Clean(oRec["station"]);
				ViewModel.sprList.Col = 2; //Uniform Item

				ViewModel.sprList.Text = modGlobal.Clean(oRec["UniformType"]);
				ViewModel.sprList.Col = 3; //Tracking #

				ViewModel.sprList.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.sprList.Col = 4; //Size/Color

				if (modGlobal.Clean(oRec["SizeCode"]) == "")
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["Color"]);
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["SizeCode"]);
				}
				ViewModel.sprList.Col = 5; //Brand

				ViewModel.sprList.Text = modGlobal.Clean(oRec["manufacturer_name"]);
				ViewModel.sprList.Col = 6; //Issued Date

				if (modGlobal.Clean(oRec["IssuedDate"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["IssuedDate"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 7; //Issued To

				ViewModel.sprList.Text = modGlobal.Clean(oRec["IssuedTo"]);
				ViewModel.sprList.Col = 8; //Last Inspected Date

				if (modGlobal.Clean(oRec["LastInspected"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["LastInspected"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 9; //Out for Repair Date

				if (modGlobal.Clean(oRec["RepairFlagged"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["RepairFlagged"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 10; //Flagged for Cleaning Date

				if (modGlobal.Clean(oRec["LaunderFlagged"]) == "")
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["LaunderFlagged"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 11; //Uniform ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
				ViewModel.sprList.Col = 12; //Launder ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["launder_id"]));


				TotalCount++;
				oRec.MoveNext();
			};
			ViewModel.sprList.MaxRows = TotalCount;
			ViewModel.lbTotalCount.Text = "List Count:  " + TotalCount.ToString();
			//ViewModel.sprList.SetSelection(1, 1, ViewModel.sprList.MaxCols, 1);
			ViewModel.CurrRow = 1;
			GetDetail();


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBrand_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBrand.SelectedIndex == -1)
			{
				return;
			}

			FillGrid();

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
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.cboBrand.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{


				while(!oRec.EOF)
				{
					ViewModel.cboBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboBrand.SetItemData(ViewModel.cboBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				};

			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkVendor_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboName.Visible = ViewModel.chkVendor.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboBrand.Text = "";
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearFields_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//clear update fields
			ViewModel.dteDateCleaned.Text = DateTime.Now.ToString("M/d/yyyy");
			ViewModel.cboName.Text = "";
			ViewModel.cboName.SelectedIndex = -1;
			ViewModel.cboName.Visible = true;
			ViewModel.chkVendor.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.txtLaundryComment.Text = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction.", vbOKOnly, "PPE Inspection Query Grid/List "
			//Print PPE Inspection Query Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintHeader("/lPPE Inspection Query /n" + ViewModel.sHeadingFilter);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintAbortMsg("Printing PPE Inspection Query Grid/List");
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
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction.", vbOKOnly, "Updating Laundry Info"
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			if (modGlobal.Clean(ViewModel.lbLaunderID.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (UniformCL.GetUniformLaunderInfoByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbLaunderID.Text))) != 0)
			{

			}
			else
			{
				ViewManager.ShowMessage("Oooops! Something is Wrong... Record Not Found", "Where's the Laundry Record??", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//edit the rest of the fields
			if ( ViewModel.chkApproveItem.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				UniformCL.UniformLaunderDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
				UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
			}
			else
			{
				UniformCL.UniformLaunderDateApproved = "";
				UniformCL.UniformLaunderApprovedBy = "";
			}

			UniformCL.UniformLaunderCleaningComments = modGlobal.Clean(ViewModel.txtLaundryComment.Text);
			UniformCL.UniformLaunderDateCleaned = DateTime.Parse(ViewModel.dteDateCleaned.Text).ToString("M/d/yyyy");
			UniformCL.UniformLaunderCleanedBy = "";
			UniformCL.UniformLaunderVendorCleaned = "N";
			if ( ViewModel.chkVendor.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				if (modGlobal.Clean(ViewModel.cboName.Text) != "")
				{
					UniformCL.UniformLaunderCleanedBy = ViewModel.cboName.Text.Substring(Math.Max(ViewModel.cboName.Text.Length - 5, 0));
				}
			}
			else
			{
				UniformCL.UniformLaunderVendorCleaned = "Y";
			}

			if (UniformCL.UpdateUniformLaunderInfo() != 0)
			{
				//        dteDateCleaned.Text = Format$(Now(), "m/d/yyyy")
				//        cboName.Text = ""
				//        cboName.ListIndex = -1
				//        txtLaundryComment.Text = ""
				//        chkvendor.Value = 0
				//        cboName.Visible = True
				ViewModel.txtPPEInfo.Text = "";
				ViewModel.lbLaunderID.Text = "";
				ViewModel.cmdUpdate.Enabled = false;
				FillGrid();
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Update Laundry Record!", "Error Updating UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Items.Clear();
			ViewModel.cboType.Text = "";

			while(!oRec.EOF)
			{
				ViewModel.cboType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				oRec.MoveNext();
			};

			//fill dropdown list for Employees
			strSQL = "spFullNameList ";

			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboName.Items.Clear();
			ViewModel.cboName.Text = "";

			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				ViewModel.cboName.AddItem(strName);
				oRec.MoveNext();
			};
			ViewModel.cboName.SelectedIndex = -1;
			ViewModel.txtLaundryComment.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboBrand.Text = "";
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";

			FillGrid();

			for (int i = 0; i <= ViewModel.cboName.Items.Count - 1; i++)
			{
				if ( ViewModel.cboName.GetListItem(i).Substring(Math.Max(ViewModel.cboName.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gUser)
				{
					ViewModel.cboName.Text = ViewModel.cboName.GetListItem(i);
					break;
				}
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
				FillGrid();
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
				FillGrid();
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
				FillGrid();
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
				FillGrid();
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
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				FillGrid();

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
				FillGrid();
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
				FillGrid();
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
				FillGrid();
			}
		}

		private void sprList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//Add logic to fill information
			if (Row == 0)
			{
				return;
			}
			ViewModel.CurrRow = Row;

			GetDetail();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmLaunderMgmt DefInstance
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

		public static frmLaunderMgmt CreateInstance()
		{
			PTSProject.frmLaunderMgmt theInstance = Shared.Container.Resolve< frmLaunderMgmt>();
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
			ViewModel.sprList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmLaunderMgmt
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmLaunderMgmtViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmLaunderMgmt m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}