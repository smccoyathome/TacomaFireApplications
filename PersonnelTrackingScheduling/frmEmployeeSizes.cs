using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmEmployeeSizes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeSizesViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEmployeeSizes));
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


		private void frmEmployeeSizes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void EditEmployeeUniformSizeDetail()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();
			int lRecordID = 0;

			//    MsgBox "This feature is under construction!", vbOKOnly, "Edit Uniform Size Record"

			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}
			if ( ViewModel.cboUniformItem.SelectedIndex == -1)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.txtItemSizeDesc.Text) == "")
			{
				return;
			}

			if ( ViewModel.lbRecordID.Text != "")
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				lRecordID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbRecordID.Text));
			}
			else
			{
				lRecordID = 0;
			}

			bool RecordExists = false;
			if (lRecordID != 0)
			{
				if (cUniform.GetPersonnelUniformSizesByID(lRecordID) != 0)
				{
					RecordExists = true;
				}
			}

			cUniform.PersonnelUniformSizesEmployeeID = ViewModel.CurrEmpID;
			cUniform.PersonnelUniformSizesUniformType = ViewModel.cboUniformItem.GetItemData(ViewModel.cboUniformItem.SelectedIndex);
			cUniform.PersonnelUniformSizesDateSized = DateTime.Parse(ViewModel.dteDateSized.Text).ToString("M/d/yyyy");
			cUniform.PersonnelUniformSizesSizeDescription = modGlobal.Clean(ViewModel.txtItemSizeDesc.Text);
			cUniform.PersonnelUniformSizesCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			cUniform.PersonnelUniformSizesCreatedBy = modGlobal.Shared.gUser;

			if (RecordExists)
			{
				if (cUniform.UpdatePersonnelUniformSizes() != 0)
				{
					FillUniformGrid();
					FindEmployee();
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Error Updating PersonnelUniformSizes.", "Error Updating PersonnelUniformSizes", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				if (cUniform.InsertPersonnelUniformSizes() != 0)
				{
					FillUniformGrid();
					FindEmployee();
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Error Adding PersonnelUniformSizes.", "Error Adding PersonnelUniformSizes", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

		}

		public void GetEmployeeUniformSizeDetail()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			if ( ViewModel.sprUniformList.DataRowCnt == 0)
			{
				return;
			}
			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}
			if ( ViewModel.cboUniformItem.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbRecordID.Text = "";

			int iItemType = ViewModel.cboUniformItem.GetItemData(ViewModel.cboUniformItem.SelectedIndex);

			if (cUniform.GetPersonnelUniformSizesByEmpItem(ViewModel.CurrEmpID, iItemType) != 0)
			{
				//continue
			}
			else
			{
				ViewModel.cmdEditUniformSize.Text = "Add";
				ViewModel.cmdEditUniformSize.Tag = "1";
				ViewModel.cmdEditUniformSize.Enabled = modGlobal.Clean(ViewModel.txtItemSizeDesc.Text) != "";
				return;
			}
			ViewModel.lbRecordID.Text = cUniform.PersonnelUniformSizesID.ToString();
			ViewModel.dteDateSized.Value = DateTime.Parse(cUniform.PersonnelUniformSizesDateSized);
			ViewModel.txtItemSizeDesc.Text = cUniform.PersonnelUniformSizesSizeDescription;
			ViewModel.cmdEditUniformSize.Text = "Update";
			ViewModel.cmdEditUniformSize.Tag = "0";
			ViewModel.cmdEditUniformSize.Enabled = true;

		}

		public void LocateUniformSizeInfo()
		{

			if ( ViewModel.sprUniformList.DataRowCnt == 0)
			{
				return;
			}
			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}
			bool InfoFound = false;
			ViewModel.sprUniformList.Col = 6;
			int tempForVar = ViewModel.sprUniformList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprUniformList.Row = i;
				if (modGlobal.Clean(ViewModel.sprUniformList.Text) == modGlobal.Clean(ViewModel.CurrEmpID))
				{
					//ViewModel.sprUniformList.SetSelection(1, i, ViewModel.sprUniformList.MaxCols, i);
					ViewModel.sprUniformList.Row = i;
					ViewModel.sprUniformList.Col = 1;
					ViewModel.sprUniformList.Row2 = i;
					ViewModel.sprUniformList.Col2 = ViewModel.sprUniformList.MaxCols;
					ViewModel.sprUniformList.BlockMode = true;
					ViewModel.sprUniformList.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprUniformList.BlockMode = false;
					InfoFound = true;
					break;
				}
			}
			ViewModel.lbRecordID.Text = "";
			ViewModel.cmdEditUniformSize.Enabled = false;

			if (!InfoFound)
			{
				ViewManager.ShowMessage("No Uniform Size Information found.  Add new record.", "No Employee Uniform Size Information Found", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.cmdEditUniformSize.Text = "Add";
				ViewModel.cmdEditUniformSize.Tag = "1";
			}


		}

		public void FillUniformGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprUniformList.MaxRows = 500;
			ViewModel.sprUniformList.Row = 1;
			ViewModel.sprUniformList.Col = 1;
			ViewModel.sprUniformList.Row2 = ViewModel.sprUniformList.MaxRows;
			ViewModel.sprUniformList.Col2 = ViewModel.sprUniformList.MaxCols;
			ViewModel.sprUniformList.BlockMode = true;
			ViewModel.sprUniformList.Text = "";
			ViewModel.sprUniformList.BlockMode = false;

			int CurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spSelect_PersonnelUniformSizesList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				CurrRow++;
				ViewModel.sprUniformList.Row = CurrRow;
				ViewModel.sprUniformList.Col = 1;
				ViewModel.sprUniformList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprUniformList.Col = 2;
				ViewModel.sprUniformList.Text = modGlobal.Clean(oRec["TShirtSize"]);
				ViewModel.sprUniformList.Col = 3;
				ViewModel.sprUniformList.Text = modGlobal.Clean(oRec["PoloSize"]);
				ViewModel.sprUniformList.Col = 4;
				ViewModel.sprUniformList.Text = modGlobal.Clean(oRec["ShirtSize"]);
				ViewModel.sprUniformList.Col = 5;
				ViewModel.sprUniformList.Text = modGlobal.Clean(oRec["PantSize"]);
				ViewModel.sprUniformList.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprUniformList.Text = Convert.ToString(modGlobal.GetVal(oRec["employee_id"]));

				oRec.MoveNext();
			};

			if ( ViewModel.sprUniformList.DataRowCnt > 0)
			{
				ViewModel.sprUniformList.MaxRows = ViewModel.sprUniformList.DataRowCnt;
			}
			else
			{
				ViewModel.sprUniformList.MaxRows = 1;
			}
			ViewModel.lbTotalCount.Text = "List Count: " + ViewModel.sprUniformList.DataRowCnt.ToString();

		}

		public void EditEmployeeBunkerSizeInfo()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();
			bool RecordExists = false;

			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}

			if (cUniform.GetUniformEmployeePPESizesByID(ViewModel.CurrEmpID) != 0)
			{
				RecordExists = true;
			}
			else
			{
				RecordExists = false;
				cUniform.EmployeeUniformSizeEmployeeID = ViewModel.CurrEmpID;
			}

			if ( ViewModel.chkInDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				cUniform.EmployeeUniformSizeInDate = "";
			}
			else
			{
				cUniform.EmployeeUniformSizeInDate = DateTime.Parse(ViewModel.dteInDate.Text).ToString("MM/dd/yyyy");
			}

			if ( ViewModel.cboPantSize.SelectedIndex == -1)
			{
				cUniform.EmployeeUniformSizePantSizeCode = 0;
				cUniform.EmployeeUniformSizePantSizeDesc = "";
			}
			else
			{
				cUniform.EmployeeUniformSizePantSizeCode = ViewModel.cboPantSize.GetItemData(ViewModel.cboPantSize.SelectedIndex);
				cUniform.EmployeeUniformSizePantSizeDesc = modGlobal.Clean(ViewModel.cboPantSize.Text);
			}

			cUniform.EmployeeUniformSizeCoatSpreadDesc = modGlobal.Clean(ViewModel.txtCoatSizeDesc.Text);
			if ( ViewModel.cboCoatSize.SelectedIndex == -1)
			{
				cUniform.EmployeeUniformSizeCoatSizeCode = 0;
				cUniform.EmployeeUniformSizeCoatSizeDesc = "";
			}
			else
			{
				cUniform.EmployeeUniformSizeCoatSizeCode = ViewModel.cboCoatSize.GetItemData(ViewModel.cboCoatSize.SelectedIndex);
				cUniform.EmployeeUniformSizeCoatSizeDesc = modGlobal.Clean(ViewModel.cboCoatSize.Text);
			}

			cUniform.EmployeeUniformSizeBootSpreadDesc = modGlobal.Clean(ViewModel.txtBootSizeDesc.Text);
			if ( ViewModel.cboBootSize.SelectedIndex == -1)
			{
				cUniform.EmployeeUniformSizeBootSizeCode = 0;
				cUniform.EmployeeUniformSizeBootSizeDesc = "";
			}
			else
			{
				cUniform.EmployeeUniformSizeBootSizeCode = ViewModel.cboBootSize.GetItemData(ViewModel.cboBootSize.SelectedIndex);
				cUniform.EmployeeUniformSizeBootSizeDesc = modGlobal.Clean(ViewModel.cboBootSize.Text);
			}

			if ( ViewModel.cboBootBrand.SelectedIndex == -1)
			{
				cUniform.EmployeeUniformSizeBootManufID = 0;
				cUniform.EmployeeUniformSizeBootManufDesc = "";
			}
			else
			{
				cUniform.EmployeeUniformSizeBootManufID = ViewModel.cboBootBrand.GetItemData(ViewModel.cboBootBrand.SelectedIndex);
				cUniform.EmployeeUniformSizeBootManufDesc = modGlobal.Clean(ViewModel.cboBootBrand.Text);
			}

			if ( ViewModel.cboGloveSize.SelectedIndex == -1)
			{
				cUniform.EmployeeUniformSizeGloveSizeCode = 0;
				cUniform.EmployeeUniformSizeGloveSizeDesc = "";
			}
			else
			{
				cUniform.EmployeeUniformSizeGloveSizeCode = ViewModel.cboGloveSize.GetItemData(ViewModel.cboGloveSize.SelectedIndex);
				cUniform.EmployeeUniformSizeGloveSizeDesc = modGlobal.Clean(ViewModel.cboGloveSize.Text);
			}

			if (RecordExists)
			{
				if (cUniform.UpdateUniformEmployeePPESizes() != 0)
				{
					FillBunkerGrid();
					FindEmployee();
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Error updating UniformEmployeePPESizes.", "Error Updating UniformEmployeePPESizes", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				if (cUniform.InsertUniformEmployeePPESizes() != 0)
				{
					FillBunkerGrid();
					FindEmployee();
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Error adding UniformEmployeePPESizes.", "Error Adding UniformEmployeePPESizes", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}


		}

		public void ClearFields()
		{
			ViewModel.lbEmpID.Text = "";

			if ( ViewModel.optBunker.Checked)
			{
				ViewModel.chkInDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteInDate.Visible = true;
				ViewModel.dteInDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.cboCoatSize.SelectedIndex = -1;
				ViewModel.txtCoatSizeDesc.Text = "";
				ViewModel.cboPantSize.SelectedIndex = -1;
				ViewModel.cboGloveSize.SelectedIndex = -1;
				ViewModel.cboBootBrand.SelectedIndex = -1;
				ViewModel.cboBootSize.SelectedIndex = -1;
				ViewModel.txtBootSizeDesc.Text = "";
			}
			else
			{
				ViewModel.chkChangeDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteDateSized.Text = DateTime.Now.ToString("MM/dd/yyyy");
				ViewModel.cboUniformItem.SelectedIndex = -1;
				ViewModel.txtItemSizeDesc.Text = "";
				ViewModel.lbRecordID.Text = "";
			}


		}

		public void FillDropDowns()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboCoatSize.Items.Clear();
			ViewModel.cboPantSize.Items.Clear();
			ViewModel.cboGloveSize.Items.Clear();
			ViewModel.cboBootSize.Items.Clear();
			ViewModel.cboBootBrand.Items.Clear();
			ViewModel.cboUniformItem.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Boot Brands
			int iItemType = 4;
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboBootBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboBootBrand.SetItemData(ViewModel.cboBootBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
				oRec.MoveNext();
			};

			//fill in Size  for  Uniform Type - Boots
			strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboBootSize.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboBootSize.SetItemData(ViewModel.cboBootSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
				oRec.MoveNext();
			};

			//fill in Size  for  Uniform Type - Gloves
			iItemType = 7;
			strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboGloveSize.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboGloveSize.SetItemData(ViewModel.cboGloveSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
				oRec.MoveNext();
			};

			//fill in Size  for  Uniform Type - Coat
			iItemType = 1;
			strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboCoatSize.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboCoatSize.SetItemData(ViewModel.cboCoatSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
				oRec.MoveNext();
			};

			//fill in Size  for  Uniform Type - Pants
			iItemType = 2;
			strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboPantSize.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboPantSize.SetItemData(ViewModel.cboPantSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
				oRec.MoveNext();
			};

			//fill in Item Types for PersonnelUniformSizes
			strSQL = "spSelect_UniformEmployeeSizeItemType ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboUniformItem.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboUniformItem.SetItemData(ViewModel.cboUniformItem.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				oRec.MoveNext();
			};

		}

		public void GetEmployeeBunkerSizeDetail()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			if ( ViewModel.sprBunkerList.DataRowCnt == 0)
			{
				return;
			}
			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}

			if (cUniform.GetUniformEmployeePPESizesByID(ViewModel.CurrEmpID) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Ooops! There was a problem retrieving UniformEmployeePPESizes.", "Error Getting UniformEmployeePPESizes", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if (cUniform.EmployeeUniformSizeInDate != "")
			{
				ViewModel.chkInDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteInDate.Visible = true;
				ViewModel.dteInDate.Text = cUniform.EmployeeUniformSizeInDate;
			}
			else
			{
				ViewModel.chkInDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteInDate.Visible = false;
			}
			ViewModel.txtCoatSizeDesc.Text = cUniform.EmployeeUniformSizeCoatSpreadDesc;
			ViewModel.txtBootSizeDesc.Text = cUniform.EmployeeUniformSizeBootSpreadDesc;

			if (cUniform.EmployeeUniformSizeCoatSizeCode != 0)
			{
				for (int i = 0; i <= ViewModel.cboCoatSize.Items.Count - 1; i++)
				{
					if (cUniform.EmployeeUniformSizeCoatSizeCode == ViewModel.cboCoatSize.GetItemData(i))
					{
						ViewModel.cboCoatSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboCoatSize.SelectedIndex = -1;
			}


			if (cUniform.EmployeeUniformSizePantSizeCode != 0)
			{
				for (int i = 0; i <= ViewModel.cboPantSize.Items.Count - 1; i++)
				{
					if (cUniform.EmployeeUniformSizePantSizeCode == ViewModel.cboPantSize.GetItemData(i))
					{
						ViewModel.cboPantSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboPantSize.SelectedIndex = -1;
			}

			if (cUniform.EmployeeUniformSizeBootSizeCode != 0)
			{
				for (int i = 0; i <= ViewModel.cboBootSize.Items.Count - 1; i++)
				{
					if (cUniform.EmployeeUniformSizeBootSizeCode == ViewModel.cboBootSize.GetItemData(i))
					{
						ViewModel.cboBootSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboBootSize.SelectedIndex = -1;
			}

			if (cUniform.EmployeeUniformSizeGloveSizeCode != 0)
			{
				for (int i = 0; i <= ViewModel.cboGloveSize.Items.Count - 1; i++)
				{
					if (cUniform.EmployeeUniformSizeGloveSizeCode == ViewModel.cboGloveSize.GetItemData(i))
					{
						ViewModel.cboGloveSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboGloveSize.SelectedIndex = -1;
			}

			if (cUniform.EmployeeUniformSizeBootManufID != 0)
			{
				for (int i = 0; i <= ViewModel.cboBootBrand.Items.Count - 1; i++)
				{
					if (cUniform.EmployeeUniformSizeBootManufID == ViewModel.cboBootBrand.GetItemData(i))
					{
						ViewModel.cboBootBrand.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboBootBrand.SelectedIndex = -1;
			}
			ViewModel.cmdEdit.Text = "Update";
			ViewModel.cmdEdit.Tag = "0";
			ViewModel.cmdEdit.Enabled = true;

		}

		public void FillBunkerGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprBunkerList.MaxRows = 500;
			ViewModel.sprBunkerList.Row = 1;
			ViewModel.sprBunkerList.Col = 1;
			ViewModel.sprBunkerList.Row2 = ViewModel.sprBunkerList.MaxRows;
			ViewModel.sprBunkerList.Col2 = ViewModel.sprBunkerList.MaxCols;
			ViewModel.sprBunkerList.BlockMode = true;
			ViewModel.sprBunkerList.Text = "";
			ViewModel.sprBunkerList.BlockMode = false;

			int CurrRow = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spSelect_UniformEmployeePPESizesList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				CurrRow++;
				ViewModel.sprBunkerList.Row = CurrRow;
				ViewModel.sprBunkerList.Col = 1;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprBunkerList.Col = 2;
				if (modGlobal.Clean(oRec["in_date"]) == "")
				{
					ViewModel.sprBunkerList.Text = "";
				}
				else
				{
					ViewModel.sprBunkerList.Text = Convert.ToDateTime(oRec["in_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprBunkerList.Col = 3;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["Pants"]);
				ViewModel.sprBunkerList.Col = 4;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["Coat"]);
				ViewModel.sprBunkerList.Col = 5;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["BootManuf"]);
				ViewModel.sprBunkerList.Col = 6;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["Boots"]);
				ViewModel.sprBunkerList.Col = 7;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["Gloves"]);
				ViewModel.sprBunkerList.Col = 8;
				ViewModel.sprBunkerList.Text = modGlobal.Clean(oRec["emp_id"]);

				oRec.MoveNext();
			};

			if ( ViewModel.sprBunkerList.DataRowCnt > 0)
			{
				ViewModel.sprBunkerList.MaxRows = ViewModel.sprBunkerList.DataRowCnt;
			}
			else
			{
				ViewModel.sprBunkerList.MaxRows = 1;
			}
			ViewModel.lbTotalCount.Text = "List Count: " + ViewModel.sprBunkerList.DataRowCnt.ToString();

		}

		public void LocateBunkerSizeInfo()
		{

			if ( ViewModel.sprBunkerList.DataRowCnt == 0)
			{
				return;
			}
			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}
			bool InfoFound = false;
			ViewModel.sprBunkerList.Col = 8;
			int tempForVar = ViewModel.sprBunkerList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				ViewModel.sprBunkerList.Row = i;
				if (modGlobal.Clean(ViewModel.sprBunkerList.Text) == modGlobal.Clean(ViewModel.CurrEmpID))
				{
					//ViewModel.sprBunkerList.SetSelection(1, i, ViewModel.sprBunkerList.MaxCols, i);
					ViewModel.sprBunkerList.Row = i;
					ViewModel.sprBunkerList.Col = 1;
					ViewModel.sprBunkerList.Row2 = i;
					ViewModel.sprBunkerList.Col2 = ViewModel.sprBunkerList.MaxCols;
					ViewModel.sprBunkerList.BlockMode = true;
					ViewModel.sprBunkerList.BackColor = modGlobal.Shared.YELLOW;
					ViewModel.sprBunkerList.BlockMode = false;
					InfoFound = true;
					break;
				}
			}
			ViewModel.cmdEdit.Enabled = false;
			if (InfoFound)
			{
				GetEmployeeBunkerSizeDetail();
			}
			else
			{
				ViewManager.ShowMessage("No PPE Size Information found.  Click New Record to Infomation.", "No Employee PPE Size Information Found", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.cmdEdit.Text = "Add";
				ViewModel.cmdEdit.Tag = "1";
			}

		}

		public void FindEmployee()
		{

			//    cboEmpList.Text = ""

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
				ViewModel.CurrEmpID = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			}

			if ( ViewModel.optBunker.Checked)
			{
				LocateBunkerSizeInfo();
			}
			else
			{
				LocateUniformSizeInfo();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}

			ClearFields();
			ViewModel.CurrEmpID = "";
			ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0)));
			ViewModel.lbEmpID.Text = ViewModel.CurrEmpID;

			if ( ViewModel.optBunker.Checked)
			{
				ViewModel.sprBunkerList.Row = 1;
				ViewModel.sprBunkerList.Col = 1;
				ViewModel.sprBunkerList.Row2 = ViewModel.sprBunkerList.MaxRows;
				ViewModel.sprBunkerList.Col2 = ViewModel.sprBunkerList.MaxCols;
				ViewModel.sprBunkerList.BlockMode = true;
				ViewModel.sprBunkerList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprBunkerList.BlockMode = false;

				LocateBunkerSizeInfo();
			}
			else
			{
				ViewModel.sprUniformList.Row = 1;
				ViewModel.sprUniformList.Col = 1;
				ViewModel.sprUniformList.Row2 = ViewModel.sprBunkerList.MaxRows;
				ViewModel.sprUniformList.Col2 = ViewModel.sprBunkerList.MaxCols;
				ViewModel.sprUniformList.BlockMode = true;
				ViewModel.sprUniformList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprUniformList.BlockMode = false;

				LocateUniformSizeInfo();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUniformItem_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Need to find latest record for this type... if it exists
			if ( ViewModel.cboUniformItem.SelectedIndex == -1)
			{
				return;
			}

			GetEmployeeUniformSizeDetail();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkChangeDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkChangeDate.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				if (modGlobal.Clean(ViewModel.lbRecordID.Text) != "")
				{
					ViewModel.cmdEditUniformSize.Text = "Add";
					ViewModel.cmdEditUniformSize.Tag = "1";
					ViewModel.lbRecordID.Text = "";
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkInDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkInDate.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.dteInDate.Visible = true;
				ViewModel.dteInDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			}
			else
			{
				ViewModel.dteInDate.Visible = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEdit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is currently under construction.", vbOKOnly, "Edit UniformEmployeePPESize Info"
			EditEmployeeBunkerSizeInfo();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEditUniformSize_Click(Object eventSender, System.EventArgs eventArgs)
		{

			EditEmployeeUniformSizeDetail();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewRecord_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.CurrEmpID == "")
			{
				return;
			}
			ClearFields();
			ViewModel.cmdEdit.Enabled = true;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			ViewModel.CurrEmpID = "";
			ViewModel.cboEmpList.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spFullNameList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				ViewModel.cboEmpList.AddItem(strName);
				oRec.MoveNext();
			};

			FillDropDowns();
			FillBunkerGrid();
			FillUniformGrid();

			ClearFields();
			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void optBunker_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.sprUniformList.Row = 1;
				ViewModel.sprUniformList.Col = 1;
				ViewModel.sprUniformList.Row2 = ViewModel.sprBunkerList.MaxRows;
				ViewModel.sprUniformList.Col2 = ViewModel.sprBunkerList.MaxCols;
				ViewModel.sprUniformList.BlockMode = true;
				ViewModel.sprUniformList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprUniformList.BlockMode = false;

				if ( ViewModel.optBunker.Checked)
				{
					ViewModel.frmBunkerDetail.Visible = true;
					ViewModel.sprBunkerList.Visible = true;
					ViewModel.frmUniformDetail.Visible = false;
					ViewModel.sprUniformList.Visible = false;
					ViewModel.chkInDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					ViewModel.dteInDate.Visible = true;
					ViewModel.dteInDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
					ViewModel.cboCoatSize.SelectedIndex = -1;
					ViewModel.txtCoatSizeDesc.Text = "";
					ViewModel.cboPantSize.SelectedIndex = -1;
					ViewModel.cboGloveSize.SelectedIndex = -1;
					ViewModel.cboBootBrand.SelectedIndex = -1;
					ViewModel.cboBootSize.SelectedIndex = -1;
					ViewModel.txtBootSizeDesc.Text = "";

					if ( ViewModel.CurrEmpID != "")
					{
						FindEmployee();
					}
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optUniform_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.sprBunkerList.Row = 1;
				ViewModel.sprBunkerList.Col = 1;
				ViewModel.sprBunkerList.Row2 = ViewModel.sprBunkerList.MaxRows;
				ViewModel.sprBunkerList.Col2 = ViewModel.sprBunkerList.MaxCols;
				ViewModel.sprBunkerList.BlockMode = true;
				ViewModel.sprBunkerList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprBunkerList.BlockMode = false;

				if ( ViewModel.optUniform.Checked)
				{
					ViewModel.frmUniformDetail.Visible = true;
					ViewModel.sprUniformList.Visible = true;
					ViewModel.frmBunkerDetail.Visible = false;
					ViewModel.sprBunkerList.Visible = false;
					ViewModel.chkChangeDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.dteDateSized.Text = DateTime.Now.ToString("MM/dd/yyyy");
					ViewModel.cboUniformItem.SelectedIndex = -1;
					ViewModel.txtItemSizeDesc.Text = "";
					ViewModel.lbRecordID.Text = "";

					if ( ViewModel.CurrEmpID != "")
					{
						FindEmployee();
					}
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtItemSizeDesc_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if (modGlobal.Clean(ViewModel.txtItemSizeDesc.Text) != "")
			{
				if (modGlobal.Clean(ViewModel.cboUniformItem.Text) != "")
				{
					ViewModel.cmdEditUniformSize.Enabled = true;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmEmployeeSizes DefInstance
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

		public static frmEmployeeSizes CreateInstance()
		{
			PTSProject.frmEmployeeSizes theInstance = Shared.Container.Resolve< frmEmployeeSizes>();
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
			ViewModel.sprBunkerList.LifeCycleStartup();
			ViewModel.frmBunkerDetail.LifeCycleStartup();
			ViewModel.frmUniformDetail.LifeCycleStartup();
			ViewModel.sprUniformList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprBunkerList.LifeCycleShutdown();
			ViewModel.frmBunkerDetail.LifeCycleShutdown();
			ViewModel.frmUniformDetail.LifeCycleShutdown();
			ViewModel.sprUniformList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmEmployeeSizes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeSizesViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmEmployeeSizes m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}