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

	public partial class frmPPEInventory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInventoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPPEInventory));
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


		private void frmPPEInventory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void SaveUniformInspection()
		{
			PTSProject.clsUniform cUniformInspUpdate = Container.Resolve< clsUniform>();

			//    MsgBox "This feature is currently under construction!", vbOKOnly, "PPE Inventory"
			//First Add/Update UniformInspection
			if (modGlobal.Clean(ViewModel.lbInspID.Text) != "")
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (cUniformInspUpdate.GetUniformInspectByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbInspID.Text))) != 0)
				{
					cUniformInspUpdate.UniformInspectedBy = modGlobal.Shared.gUser;
					if ( ViewModel.chkPassed.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
					{
						cUniformInspUpdate.UniformInspectPassedFlag = 1;
					}
					else
					{
						cUniformInspUpdate.UniformInspectPassedFlag = 0;
					}
					if (cUniformInspUpdate.UpdateUniformInspection() != 0)
					{
						//successful
					}
					else
					{
						ViewManager.ShowMessage("Oooops! Something went wrong with Uniform Inspection Update!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
						return;
					}
				}
				else
				{
					ViewManager.ShowMessage("Could not find the last Uniform Inspection for Update!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUniformInspUpdate.UniformInspectUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
				cUniformInspUpdate.UniformInspectDate = ViewModel.dtInspection.Value.Date.ToString("MM/dd/yyyy");
				cUniformInspUpdate.UniformInspectedBy = modGlobal.Shared.gUser;
				if ( ViewModel.chkPassed.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
				{
					cUniformInspUpdate.UniformInspectPassedFlag = 1;
				}
				else
				{
					cUniformInspUpdate.UniformInspectPassedFlag = 0;
				}
				if (cUniformInspUpdate.InsertUniformInspection() != 0)
				{
					//successful
					ViewModel.lbInspID.Text = cUniformInspUpdate.UniformInspectID.ToString();
				}
				else
				{
					ViewManager.ShowMessage("Oooops! Something went wrong with Uniform Inspection Insert!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			//Now Add/Update/Delete UniformCommentForInspection
			if (modGlobal.Clean(ViewModel.lbInspID.Text) != "")
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (cUniformInspUpdate.GetUniformCommentForInspectionByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbInspID.Text))) != 0)
				{
					if (modGlobal.Clean(ViewModel.txtInspComment.Text) == "")
					{ //Delete Comment
						if (cUniformInspUpdate.DeleteUniformCommentForInspection() != 0)
						{
							//successful
						}
						else
						{
							ViewManager.ShowMessage("Oooops! Something went wrong with Inspection Comment Delete!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
							return;
						}
					}
					else
					{
						cUniformInspUpdate.UniformComment = modGlobal.Clean(ViewModel.txtInspComment.Text);
						cUniformInspUpdate.UniformCommentUpdatedBy = modGlobal.Shared.gUser;
						cUniformInspUpdate.UniformCommentUpdatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
						//Need to Update UniformCommentForInspection
						if (cUniformInspUpdate.UpdateUniformCommentForInspection())
						{
							//successful
						}
						else
						{
							ViewManager.ShowMessage("Oooops! Something went wrong with Inspection Comment Update!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
							return;
						}
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniformInspUpdate.UniformCommentInspID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbInspID.Text));
					cUniformInspUpdate.UniformComment = modGlobal.Clean(ViewModel.txtInspComment.Text);
					cUniformInspUpdate.UniformCommentCreatedBy = modGlobal.Shared.gUser;
					cUniformInspUpdate.UniformCommentCreatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
					//Need to Insert UniformCommentForInspection
					if (cUniformInspUpdate.AddUniformCommentForInspection())
					{
						//continue
					}
					else
					{
						ViewManager.ShowMessage("Oooops! Something went wrong with Inspection Comment Insert!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
						return;
					}
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUniformInspUpdate.UniformCommentInspID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbInspID.Text));
				cUniformInspUpdate.UniformComment = modGlobal.Clean(ViewModel.txtInspComment.Text);
				cUniformInspUpdate.UniformCommentCreatedBy = modGlobal.Shared.gUser;
				cUniformInspUpdate.UniformCommentCreatedDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				//Need to Insert UniformCommentForInspection
				if (cUniformInspUpdate.AddUniformCommentForInspection())
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("Oooops! Something went wrong with Inspection Comment Insert!!", "Save Uniform Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

		}

		public void RefreshGridRow()
		{
			//Retrieve and Display Uniform Inventory List
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();
			//int iStation = 0;
			//int iType = 0;
			//int iManufId = 0;
			//int iColor = 0;
			//int iSize = 0;

			try
			{
				ViewModel.bRetireItem = false;
				//iStation = 0;
				//iType = 0;
				//iManufId = 0;
				//iColor = 0;
				//iSize = 0;

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (cUniform.GetRefreshedUniformInventoryRow(Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text))) != 0)
				{
					if (cUniform.Uniform.EOF)
					{
						ViewManager.ShowMessage("Oooops! Something went wrong with refreshing the grid row!", "Refreshing Inventory Grid", UpgradeHelpers.Helpers.BoxButtons.OK);
						return;
					}
				}


				//Fill PPE Repair Info from fields

				while(!cUniform.Uniform.EOF)
				{
					ViewModel.sprPPEList.Row = ViewModel.CurrRow;
					ViewModel.sprPPEList.Col = 1; //Station
					//UPGRADE_WARNING: (1068) GetVal(cUniform.Uniform(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx

					if (modGlobal.Clean(cUniform.Uniform["station"]) == "")
					{
						ViewModel.sprPPEList.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(cUniform.Uniform["station"])) == 0)
					{
						ViewModel.sprPPEList.Text = "";
					}
					else
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["station"]);
					}
					ViewModel.sprPPEList.Col = 2; //Item Description

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["TypeDescription"]);
					ViewModel.sprPPEList.Col = 3; //Tracking/Serial Number

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["tracking_number"]);
					ViewModel.sprPPEList.Col = 4; //Alternate Tracking Number

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["tracking_number"]);
					ViewModel.sprPPEList.Col = 5; //Color/Size

					if (modGlobal.Clean(cUniform.Uniform["SizeDescription"]) != "")
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["SizeDescription"]);
					}
					else if (modGlobal.Clean(cUniform.Uniform["ColorDescription"]) != "")
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["ColorDescription"]);
					}
					else
					{
						ViewModel.sprPPEList.Text = "";
					}
					ViewModel.sprPPEList.Col = 6; //Manufacturer

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["manufacturer_name"]);
					ViewModel.sprPPEList.Col = 7; //Manufactured Date

					if (modGlobal.Clean(cUniform.Uniform["manufactured_date"]) == "")
					{
						ViewModel.sprPPEList.Value = "";
					}
					else
					{
						ViewModel.sprPPEList.Value = Convert.ToDateTime(cUniform.Uniform["manufactured_date"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprPPEList.Col = 8; //Last Inspected Date

					if (modGlobal.Clean(cUniform.Uniform["LastInspected"]) == "")
					{
						ViewModel.sprPPEList.Value = "";
					}
					else
					{
						ViewModel.sprPPEList.Value = Convert.ToDateTime(cUniform.Uniform["LastInspected"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprPPEList.Col = 9; //System ID

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(cUniform.Uniform["uniform_id"]));

					cUniform.Uniform.MoveNext();
				}
				;
				ViewModel.lbCount.Text = "List Count: " + ViewModel.sprPPEList.MaxRows.ToString();

				//Select the refreshed row
				//ViewModel.sprPPEList.SetSelection(1, ViewModel.CurrRow, ViewModel.sprPPEList.MaxCols, ViewModel.CurrRow);

				FormatReport();
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		public void AddNewUniform()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			try
			{

				if (modGlobal.Clean(ViewModel.lbUniformID.Text) != "")
				{
					return;
				} //should not be here
				if ( ViewModel.cboStation.SelectedIndex == -1)
				{
					ViewManager.ShowMessage("Please enter the Station for this inventory item.", "Adding New Inventory Item", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}

				cUniform.UniformType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
				cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNumber.Text);
				cUniform.UniformAlternateNum = modGlobal.Clean(ViewModel.txtAlternate.Text);

				cUniform.UniformColorType = 0;
				cUniform.UniformSizeType = 0;
				if ( ViewModel.cboItemColorSize.Visible)
				{
					if ( ViewModel.cboItemColorSize.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						if ( ViewModel.lbItemColorSize.Text == "Color")
						{
							cUniform.UniformColorType = ViewModel.cboItemColorSize.GetItemData(ViewModel.cboItemColorSize.SelectedIndex);
						}
						else
						{
							cUniform.UniformSizeType = ViewModel.cboItemColorSize.GetItemData(ViewModel.cboItemColorSize.SelectedIndex);
						}
					}
				}

				//Note:  cUniform.UniformRetiredDate is not being updated here
				cUniform.UniformRetiredDate = "";

				cUniform.UniformManufacturerID = 0;
				if ( ViewModel.cboItemBrand.Visible)
				{
					if ( ViewModel.cboItemBrand.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						cUniform.UniformManufacturerID = ViewModel.cboItemBrand.GetItemData(ViewModel.cboItemBrand.SelectedIndex);
					}
				}

				if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					cUniform.UniformManufacturedDate = "";
				}
				else if (((int) DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
				{
					ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy");
				}

				if (cUniform.InsertUniform() != 0)
				{
					cUniform.UniformInventoryStation = ViewModel.cboStation.GetItemData(ViewModel.cboStation.SelectedIndex).ToString();
					cUniform.UniformInventoryUniformID = cUniform.UniformID;
					ViewModel.lbUniformID.Text = cUniform.UniformID.ToString();
					if (cUniform.InsertUniformInventory() != 0)
					{
						ViewManager.ShowMessage("PPE Item has been successfully inserted.", "Insert New PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewManager.ShowMessage("Ooops!  Error Adding UniformInventory record.  Call Debra Lewandowsky x5068.", "Error Adding UniformInventory", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				else
				{
					ViewManager.ShowMessage("Ooops!  Error Adding Uniform record.  Call Debra Lewandowsky x5068.", "Error Adding Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		public void UpdateSelectedUniform()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			try
			{

				//if there is no UniformID... should not be here...
				if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
				{
					return;
				}

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				cUniform.UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));

				//Edit Information & gather variables
				if (cUniform.GetUniformByID(cUniform.UniformID) != 0)
				{
					//uniform exists...
					if (cUniform.DeleteUniformInventory(cUniform.UniformID) != 0)
					{
						//all is well either way
					}
				}
				else
				{
					ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}

				if ( ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex) != cUniform.UniformType)
				{
					ViewManager.ShowMessage("You can not change the PPE type.  If you would like to Add a new type, then click New Item.", "Update PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewModel.cmdEditItem.Enabled = true;
					return;
				}

				cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNumber.Text);
				cUniform.UniformAlternateNum = modGlobal.Clean(ViewModel.txtAlternate.Text);

				cUniform.UniformColorType = 0;
				cUniform.UniformSizeType = 0;
				if ( ViewModel.cboItemColorSize.Visible)
				{
					if ( ViewModel.cboItemColorSize.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						if ( ViewModel.lbItemColorSize.Text == "Color")
						{
							cUniform.UniformColorType = ViewModel.cboItemColorSize.GetItemData(ViewModel.cboItemColorSize.SelectedIndex);
						}
						else
						{
							cUniform.UniformSizeType = ViewModel.cboItemColorSize.GetItemData(ViewModel.cboItemColorSize.SelectedIndex);
						}
					}
				}

				cUniform.UniformManufacturerID = 0;
				if ( ViewModel.cboItemBrand.Visible)
				{
					if ( ViewModel.cboItemBrand.SelectedIndex == -1)
					{
						//continue
					}
					else
					{
						cUniform.UniformManufacturerID = ViewModel.cboItemBrand.GetItemData(ViewModel.cboItemBrand.SelectedIndex);
					}
				}

				if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					cUniform.UniformManufacturedDate = "";
				}
				else if (((int) DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
				{
					ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy");
				}

				//Note:  cUniform.UniformRetiredDate is being updated here... depending
				cUniform.UniformRetiredDate = "";

				if (cUniform.GetUniformReasonRetiredByID(cUniform.UniformID) != 0)
				{
					if (cUniform.DeleteUniformReasonRetiredByUniformID(cUniform.UniformID) != 0)
					{
						//continue
					}
					else
					{
						ViewManager.ShowMessage("Ooops!  There was a problem deleting the RetiredReason Info!", "Delete UniformReasonRetiredInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
						return;
					}
				}

				if ( ViewModel.bRetireItem)
				{
					//the retired date is part of the Uniform Record
					cUniform.UniformRetiredDate = DateTime.Parse(ViewModel.dteRetired.Text).ToString("M/d/yyyy");

					//the following is part of the UniformReasonRetired infor
					cUniform.UniformReasonRetiredUniformID = cUniform.UniformID;
					cUniform.UniformReasonRetiredReasonID = 0;
					if ( ViewModel.cboReason.SelectedIndex != -1)
					{
						cUniform.UniformReasonRetiredReasonID = ViewModel.cboReason.GetItemData(ViewModel.cboReason.SelectedIndex);
					}
					cUniform.UniformReasonRetiredComment = modGlobal.Clean(ViewModel.txtComment.Text);
					cUniform.UniformReasonRetiredCreatedBy = modGlobal.Shared.gUser;
					cUniform.UniformReasonRetiredCreatedDate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
					if (cUniform.InsertUniformReasonRetiredInfo() != 0)
					{
						ViewManager.ShowMessage("PPE Item / Retired Info has been successfully updated.", "Update PPE Item Retired Info", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewManager.ShowMessage("Ooops!  Error Updating PersonnelUniform record.  Call Debra Lewandowsky x5068.", "Error Updating PersonnelUniform", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}

				if (cUniform.UpdateUniform() != 0)
				{
					//cboStation
					if ( ViewModel.cboStation.SelectedIndex != -1)
					{
						cUniform.UniformInventoryStation = ViewModel.cboStation.GetItemData(ViewModel.cboStation.SelectedIndex).ToString();
						cUniform.UniformInventoryUniformID = cUniform.UniformID;
						if (cUniform.InsertUniformInventory() != 0)
						{
							ViewManager.ShowMessage("PPE Item has been successfully updated.", "Update New PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
						else
						{
							ViewManager.ShowMessage("Ooops!  Error Adding UniformInventory record.  Call Debra Lewandowsky x5068.", "Error Adding UniformInventory", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
					}
				}
				else
				{
					ViewManager.ShowMessage("Ooops!  Error Updating Uniform record.  Call Debra Lewandowsky x5068.", "Error Updating Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}


		private int EnableOKButton()
		{

			int result = 0;
			result = 0;

			//If there's no type... there's no use continuing...
			if ( ViewModel.cboItemType.SelectedIndex == -1)
			{
				return result;
			}
			if ( ViewModel.cboItemType.Text == "")
			{
				return result;
			}

			//everything needs a tracking number too...
			if (modGlobal.Clean(ViewModel.txtTrackingNumber.Text) == "")
			{
				return result;
			}

			if ( ViewModel.cmdRetireItem.Visible)
			{ //item is active... needs location
				if ( ViewModel.cboStation.SelectedIndex == -1)
				{
					return result;
				}
			}
			else
			{
				if ( ViewModel.cboReason.SelectedIndex == -1)
				{
					return result;
				}
				if (!Information.IsDate(ViewModel.dteRetired.Text))
				{
					return result;
				}
			}

			if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				if (!Information.IsDate(ViewModel.dteManufDate.Text))
				{
					return result;
				}
				else
				{
					if (((int) DateAndTime.DateDiff("d", DateTime.Parse(ViewModel.dteManufDate.Text), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) < 0)
					{
						return result;
					}
				}
			}

			//    cboItemColorSize.ListIndex = -1
			//    cboItemColorSize.Text = ""
			//
			//    cboItemBrand.ListIndex = -1
			//    cboItemBrand.Text = ""

			return -1;

		}

		public void FormatReport()
		{
			//Retrieve and Display Uniform Inventory List

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Clear Grid
			ViewModel.sprReport.MaxRows = 10000;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			int rCurrRow = 0;

			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for (int i = 1; i <= tempForVar; i++)
			{
				//Fill sprReport with data from sprPPEList
				rCurrRow = i;
				ViewModel.sprPPEList.Row = rCurrRow;
				ViewModel.sprReport.Row = rCurrRow;

				//Station
				ViewModel.sprReport.Col = 1;
				ViewModel.sprPPEList.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Item Description
				ViewModel.sprReport.Col = 2;
				ViewModel.sprPPEList.Col = 2;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Tracking/Serial Number
				ViewModel.sprReport.Col = 3;
				ViewModel.sprPPEList.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Alternate Tracking Number
				ViewModel.sprReport.Col = 4;
				ViewModel.sprPPEList.Col = 4;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Color/Size
				ViewModel.sprReport.Col = 5;
				ViewModel.sprPPEList.Col = 5;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Manufacturer
				ViewModel.sprReport.Col = 6;
				ViewModel.sprPPEList.Col = 6;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Manufactured Date
				ViewModel.sprReport.Col = 7;
				ViewModel.sprPPEList.Col = 7;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//Last Inspected Date
				ViewModel.sprReport.Col = 8;
				ViewModel.sprPPEList.Col = 8;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;

				//System ID
				ViewModel.sprReport.Col = 9;
				ViewModel.sprPPEList.Col = 9;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ViewModel.sprPPEList.Text;
			}

		}

		public void ClearDetailFields()
		{
			ViewModel.sprPPEList.Row = 1;
			ViewModel.sprPPEList.Row2 = ViewModel.sprPPEList.MaxRows;
			ViewModel.sprPPEList.Col = 1;
			ViewModel.sprPPEList.Col2 = ViewModel.sprPPEList.MaxCols;
			ViewModel.sprPPEList.BlockMode = true;
			ViewModel.sprPPEList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprPPEList.BlockMode = false;
			ViewModel.cboStation.SelectedIndex = -1;
			ViewModel.cboStation.Text = "";
			ViewModel.txtTrackingNumber.Text = "";
			ViewModel.txtAlternate.Text = "";
			ViewModel.lbUniformID.Text = "";
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.cmdRetireItem.Enabled = true;
			ViewModel.cmdRetireItem.Visible = true;
			ViewModel.bRetireItem = false;
			ViewModel.dteRetired.Visible = false;
			ViewModel.cboReason.Visible = false;
			ViewModel.txtComment.Visible = false;
			ViewModel.lbReason.Visible = false;
			ViewModel.lbRetiredDate.Visible = false;
			ViewModel.lbRetireComment.Visible = false;
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			ViewModel.cboItemColorSize.SelectedIndex = -1;
			ViewModel.cboItemColorSize.Text = "";
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.dteManufDate.Visible = false;
			ViewModel.dtInspection.Text = DateTime.Now.ToString("MM/dd/yyyy");
			ViewModel.dtInspection.Enabled = true;
			ViewModel.txtInspComment.Text = "";
			ViewModel.chkPassed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.lbInspID.Text = "";
			ViewModel.cmdLastInsp.Tag = "0";
			ViewModel.cmdLastInsp.Text = "Get Last Inspection";
			ViewModel.cmdAddNew.Tag = "0";
			ViewModel.cmdAddNew.Text = "Add Inspection";


		}

		public void FillLists()
		{
			//Retrieve & fill Grid lists for Manuactures & Sizes & Color (Helmet only)
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboItemType.Items.Clear();
			ViewModel.cboType.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboItemType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboItemType.SetItemData(ViewModel.cboItemType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				ViewModel.cboType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));

				oRec.MoveNext();
			};

			//fill dropdown list for Uniform Inventory Stations
			strSQL = "spSelect_TFDFacilityList ";

			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboLocation.Items.Clear();
			ViewModel.cboStation.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboLocation.AddItem(modGlobal.Clean(oRec["facility_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboLocation.SetItemData(ViewModel.cboLocation.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["facility"])));
				ViewModel.cboStation.AddItem(modGlobal.Clean(oRec["facility_name"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboStation.SetItemData(ViewModel.cboStation.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["facility"])));
				oRec.MoveNext();
			};

			//fill dropdown list for Uniform Retirement Reason
			strSQL = "spSelect_UniformRetirementReasonList ";

			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboReason.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboReason.AddItem(modGlobal.Clean(oRec["reason_description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboReason.SetItemData(ViewModel.cboReason.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["reason_id"])));
				oRec.MoveNext();
			};

			//these dropdowns are filled after an PPE Item Type is selected...
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboItemColorSize.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();


		}

		public void FillInventoryGrid()
		{
			//Retrieve and Display Uniform Inventory List
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();
			int rCurrRow = 0;
			int iStation = 0;
			int iType = 0;
			int iManufId = 0;
			int iColor = 0;
			int iSize = 0;

			try
			{

				ClearDetailFields();
				ViewModel.bRetireItem = false;
				iStation = 0;
				iType = 0;
				iManufId = 0;
				iColor = 0;
				iSize = 0;

				if ( ViewModel.cboLocation.SelectedIndex > -1)
				{
					iStation = ViewModel.cboLocation.GetItemData(ViewModel.cboLocation.SelectedIndex);
				}

				if ( ViewModel.cboItemType.SelectedIndex > -1)
				{
					iType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
				}

				if ( ViewModel.cboType.SelectedIndex > -1)
				{
					iType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
				}

				if (modGlobal.Clean(ViewModel.lbBrand.Text) != "")
				{
					if ( ViewModel.cboBrand.SelectedIndex > -1)
					{
						iManufId = ViewModel.cboBrand.GetItemData(ViewModel.cboBrand.SelectedIndex);
					}
				}

				if (modGlobal.Clean(ViewModel.lbColorSize.Text) == "Size")
				{
					if ( ViewModel.cboColorSize.SelectedIndex > -1)
					{
						iSize = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
					}
				}
				else if (modGlobal.Clean(ViewModel.lbColorSize.Text) == "Color")
				{
					if ( ViewModel.cboColorSize.SelectedIndex > -1)
					{
						iColor = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
					}
				}

				//Clear Grid
				ViewModel.sprPPEList.MaxRows = 10000;
				ViewModel.sprPPEList.Row = 1;
				ViewModel.sprPPEList.Row2 = ViewModel.sprPPEList.MaxRows;
				ViewModel.sprPPEList.Col = 1;
				ViewModel.sprPPEList.Col2 = ViewModel.sprPPEList.MaxCols;
				ViewModel.sprPPEList.BlockMode = true;
				ViewModel.sprPPEList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprPPEList.Text = "";
				ViewModel.sprPPEList.BlockMode = false;


				rCurrRow = 0;
				ViewModel.lbCount.Text = "List Count: ";

				if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					if (cUniform.GetUniformInventoryList(iStation, iType, iManufId, iColor, iSize) != 0)
					{

					}
					else
					{
						ViewModel.sprPPEList.MaxRows = 1;
						return;
					}
				}
				else
				{
					if (cUniform.GetInactiveUniformInventoryList(iStation, iType, iManufId, iColor, iSize) != 0)
					{

					}
					else
					{
						ViewModel.sprPPEList.MaxRows = 1;
						return;
					}
				}

				//Fill PPE Repair Info from fields

				while(!cUniform.Uniform.EOF)
				{
					rCurrRow++;
					ViewModel.sprPPEList.Row = rCurrRow;
					ViewModel.sprPPEList.Col = 1; //Station
					//UPGRADE_WARNING: (1068) GetVal(cUniform.Uniform(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (modGlobal.Clean(cUniform.Uniform["station"]) == "")
					{
						ViewModel.sprPPEList.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(cUniform.Uniform["station"])) == 0)
					{
						ViewModel.sprPPEList.Text = "";
					}
					else
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["station"]);
					}
					ViewModel.sprPPEList.Col = 2; //Item Description

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["TypeDescription"]);
					ViewModel.sprPPEList.Col = 3; //Tracking/Serial Number

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["tracking_number"]);
					ViewModel.sprPPEList.Col = 4; //Alternate Tracking #

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["alternate_num"]);
					ViewModel.sprPPEList.Col = 5; //Color/Size
					if (modGlobal.Clean(cUniform.Uniform["SizeDescription"]) != "")
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["SizeDescription"]);
					}
					else if (modGlobal.Clean(cUniform.Uniform["ColorDescription"]) != "")
					{
						ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["ColorDescription"]);
					}
					else
					{
						ViewModel.sprPPEList.Text = "";
					}
					ViewModel.sprPPEList.Col = 6; //Manufacturer

					ViewModel.sprPPEList.Text = modGlobal.Clean(cUniform.Uniform["manufacturer_name"]);
					ViewModel.sprPPEList.Col = 7; //Manufactured Date
					if (modGlobal.Clean(cUniform.Uniform["manufactured_date"]) == "")
					{
						ViewModel.sprPPEList.Value = "";
					}
					else
					{
						ViewModel.sprPPEList.Value = Convert.ToDateTime(cUniform.Uniform["manufactured_date"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprPPEList.Col = 8; //Last Inspected Date
					if (modGlobal.Clean(cUniform.Uniform["LastInspected"]) == "")
					{
						ViewModel.sprPPEList.Value = "";
					}
					else
					{
						ViewModel.sprPPEList.Value = Convert.ToDateTime(cUniform.Uniform["LastInspected"]).ToString("MM/dd/yyyy");
					}
					ViewModel.sprPPEList.Col = 9; //System ID

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(cUniform.Uniform["uniform_id"]));

					cUniform.Uniform.MoveNext();
				};
				ViewModel.lbCount.Text = "List Count: " + rCurrRow.ToString();
				ViewModel.sprPPEList.MaxRows = rCurrRow;

				if ( ViewModel.FirstTime)
				{
					sprPPEList_CellClick(ViewModel.sprPPEList, new Stubs._FarPoint.Win.Spread.CellClickEventArgs(1, 1));
				}

				FormatReport();
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBrand_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboColorSize_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboItemBrand_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboItemColorSize_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboItemType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboItemType.SelectedIndex == -1)
			{
				return;
			}

			int iItemType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboItemColorSize.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbItemBrand.Text = "";
				ViewModel.cboItemBrand.Enabled = false;
				ViewModel.cboItemBrand.Visible = false;
				ViewModel.cboItemBrand.SelectedIndex = -1;
				ViewModel.cboItemBrand.Text = "";
			}
			else
			{
				ViewModel.lbItemBrand.Text = "Brand/Manufacturer";
				ViewModel.cboItemBrand.Enabled = true;
				ViewModel.cboItemBrand.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboItemBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboItemBrand.SetItemData(ViewModel.cboItemBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				}
				;
							}

							//fill in Size  for Selected Uniform Type
							strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
							oCmd.CommandText = strSQL;
							oRec = ADORecordSetHelper.Open(oCmd, "");

							if (oRec.EOF)
							{
								//fill in Color for Selected Uniform Type
								strSQL = "spSelect_UniformColorCodeByItemType " + iItemType.ToString() + " ";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if (oRec.EOF)
								{
					ViewModel.cboItemColorSize.Text = "";
					ViewModel.cboItemColorSize.SelectedIndex = -1;
					ViewModel.cboItemColorSize.Enabled = false;
					ViewModel.lbItemColorSize.Text = "";
					ViewModel.cboItemColorSize.Visible = false;
				}
				else
				{
					ViewModel.lbItemColorSize.Text = "Color";
					ViewModel.cboItemColorSize.Enabled = true;
					ViewModel.cboItemColorSize.Visible = true;

					while(!oRec.EOF)
					{
						ViewModel.cboItemColorSize.AddItem(modGlobal.Clean(oRec["description"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.cboItemColorSize.SetItemData(ViewModel.cboItemColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["color_type"])));
						oRec.MoveNext();
					}
					;
									}

								}
								else
								{
				ViewModel.lbItemColorSize.Text = "Size";
				ViewModel.cboItemColorSize.Enabled = true;
				ViewModel.cboItemColorSize.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboItemColorSize.AddItem(modGlobal.Clean(oRec["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboItemColorSize.SetItemData(ViewModel.cboItemColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
					oRec.MoveNext();
				}
				;
							}
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboReason_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboStation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
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
			ViewModel.cboColorSize.Items.Clear();

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
				ViewModel.lbItemBrand.Text = "Manufacturer";
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

							//fill in Size  for Selected Uniform Type
							strSQL = "spSelect_UniformSizeCodeByItemType " + iItemType.ToString() + " ";
							oCmd.CommandText = strSQL;
							oRec = ADORecordSetHelper.Open(oCmd, "");

							if (oRec.EOF)
							{
								//fill in Color for Selected Uniform Type
								strSQL = "spSelect_UniformColorCodeByItemType " + iItemType.ToString() + " ";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if (oRec.EOF)
								{
					ViewModel.cboColorSize.Text = "";
					ViewModel.cboColorSize.SelectedIndex = -1;
					ViewModel.cboColorSize.Enabled = false;
					ViewModel.lbColorSize.Text = "";
					ViewModel.cboColorSize.Visible = false;
				}
				else
				{
					ViewModel.lbColorSize.Text = "Color";
					ViewModel.cboColorSize.Enabled = true;
					ViewModel.cboColorSize.Visible = true;

					while(!oRec.EOF)
					{
						ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["color_type"])));
						oRec.MoveNext();
					}
					;
									}

								}
								else
								{
				ViewModel.lbColorSize.Text = "Size";
				ViewModel.cboColorSize.Enabled = true;
				ViewModel.cboColorSize.Visible = true;

				while(!oRec.EOF)
				{
					ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
					oRec.MoveNext();
				}
				;
							}

							FillInventoryGrid();

						}

		[UpgradeHelpers.Events.Handler]
		internal void chkInactive_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkManufDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
				ViewModel.dteManufDate.Visible = true;
			}
			else
			{
				ViewModel.dteManufDate.Visible = false;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddNew_Click(Object eventSender, System.EventArgs eventArgs)
		{
			SaveUniformInspection();
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCleaning_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
			{
				return;
			}
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.lbUniformID.Text)));
			ViewManager.NavigateToView(
				frmUniformLaundryHistory.DefInstance);
			/*			frmUniformLaundryHistory.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Uniform Item Launder/Cleaning History"
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboLocation.SelectedIndex = -1;
			ViewModel.cboLocation.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboType.Text = "";
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();
			ViewModel.lbColorSize.Text = "Color / Size";

			FillInventoryGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEditItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = false;

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdEditItem.Tag)) == 1)
			{
				//Edit Fields and Add New Item
				AddNewUniform();
				ViewModel.cmdEditItem.Tag = "0";
				ViewModel.cmdEditItem.Text = "Update";
				ViewModel.CurrRow = 1;
				(ViewModel.sprPPEList.MaxRows)++;
				ViewModel.sprPPEList.InsertRows(1, 1);
				if (modGlobal.Clean(ViewModel.lbUniformID.Text) != "")
				{
					RefreshGridRow();
				}
			}
			else
			{
				UpdateSelectedUniform();
				FillInventoryGrid();
			}

			cmdNewItem_Click(ViewModel.cmdNewItem, new System.EventArgs());

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdFind_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cmdCleaning.Enabled = false;
			ViewModel.cmdRepair.Enabled = false;

			if (modGlobal.Clean(ViewModel.txtTrackingNumber.Text) == "")
			{
				ViewManager.ShowMessage("Please enter Tracking/Barcode Number.", "Search on Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

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
			ViewModel.cmdCleaning.Enabled = true;
			ViewModel.cmdRepair.Enabled = true;

			bool bUniformActiveInventory = true; // True until proven false

			while(!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
				ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
				if (modGlobal.Clean(oRec["retired_date"]) == "")
				{ //Uniform is still active
					if (modGlobal.Clean(oRec["employee_id"]) == "")
					{ //Uniform not currently issued to anyone
						if (modGlobal.Clean(oRec["returned_date"]) != "")
						{ //Uniform has been returned

							//fill in the fields
							ViewModel.cboStation.SelectedIndex = -1;
							ViewModel.cboStation.Text = "";
							if (modGlobal.Clean(oRec["station"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
									{
										ViewModel.cboStation.SelectedIndex = i;
										break;
									}
								}
							}
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
							ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
							ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
							ViewModel.cboReason.SelectedIndex = -1;
							ViewModel.cboReason.Text = "";
							ViewModel.txtComment.Text = "";
							ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
							ViewModel.cmdRetireItem.Enabled = true;
							ViewModel.cmdRetireItem.Visible = true;
							ViewModel.dteRetired.Visible = false;
							ViewModel.cboReason.Visible = false;
							ViewModel.txtComment.Visible = false;
							ViewModel.lbReason.Visible = false;
							ViewModel.lbRetiredDate.Visible = false;
							ViewModel.lbRetireComment.Visible = false;
							ViewModel.cboItemType.SelectedIndex = -1;
							ViewModel.cboItemType.Text = "";
							for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
								{
									ViewModel.cboItemType.SelectedIndex = i;
									break;
								}
							}
							ViewModel.cboItemColorSize.SelectedIndex = -1;
							ViewModel.cboItemColorSize.Text = "";
							if (modGlobal.Clean(oRec["color_type"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
									{
										ViewModel.cboItemColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							else if (modGlobal.Clean(oRec["size_type"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
									{
										ViewModel.cboItemColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.cboItemBrand.SelectedIndex = -1;
							ViewModel.cboItemBrand.Text = "";
							if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
									{
										ViewModel.cboItemBrand.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
							ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
							ViewModel.dteManufDate.Visible = false;
							if (modGlobal.Clean(oRec["manufactured_date"]) != "")
							{
								ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								System.DateTime TempDate = DateTime.FromOADate(0);
								ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
								ViewModel.dteManufDate.Visible = true;
							}
						}
						else
						{
							//here
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
							ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
							ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
							ViewModel.cmdRetireItem.Enabled = true;
							ViewModel.cmdRetireItem.Visible = true;
							ViewModel.bRetireItem = false;
							ViewModel.txtComment.Text = "";
							ViewModel.cboReason.SelectedIndex = -1;
							ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
							ViewModel.dteRetired.Visible = false;
							ViewModel.cboReason.Visible = false;
							ViewModel.txtComment.Visible = false;
							ViewModel.lbReason.Visible = false;
							ViewModel.lbRetiredDate.Visible = false;
							ViewModel.lbRetireComment.Visible = false;
							ViewModel.cboStation.SelectedIndex = -1;
							ViewModel.cboStation.Text = "";
							if (modGlobal.Clean(oRec["station"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
									{
										ViewModel.cboStation.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.cboItemType.SelectedIndex = -1;
							ViewModel.cboItemType.Text = "";
							for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
								{
									ViewModel.cboItemType.SelectedIndex = i;
									break;
								}
							}
							ViewModel.cboItemColorSize.SelectedIndex = -1;
							ViewModel.cboItemColorSize.Text = "";
							if (modGlobal.Clean(oRec["color_type"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
									{
										ViewModel.cboItemColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							else if (modGlobal.Clean(oRec["size_type"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
									{
										ViewModel.cboItemColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.cboItemBrand.SelectedIndex = -1;
							ViewModel.cboItemBrand.Text = "";
							if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
							{
								for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
									{
										ViewModel.cboItemBrand.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
							ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
							ViewModel.dteManufDate.Visible = false;
							if (modGlobal.Clean(oRec["manufactured_date"]) != "")
							{
								ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								System.DateTime TempDate2 = DateTime.FromOADate(0);
								ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
								ViewModel.dteManufDate.Visible = true;
							}
						}
					}
					else if (modGlobal.Clean(oRec["returned_date"]) == "")
					{  //Uniform is currently issued to someone

						ViewManager.ShowMessage("This item is currently issued to " + modGlobal.Clean(oRec["name_full"]) + ".", "", UpgradeHelpers.Helpers.BoxButtons.OK);
						return;
					}
					else
					{
						ViewModel.cmdRetireItem.Enabled = true;
						ViewModel.cmdRetireItem.Visible = true;
						ViewModel.bRetireItem = false;
						ViewModel.txtComment.Text = "";
						ViewModel.cboReason.SelectedIndex = -1;
						ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
						ViewModel.dteRetired.Visible = false;
						ViewModel.cboReason.Visible = false;
						ViewModel.txtComment.Visible = false;
						ViewModel.lbReason.Visible = false;
						ViewModel.lbRetiredDate.Visible = false;
						ViewModel.lbRetireComment.Visible = false;
						ViewModel.cboStation.SelectedIndex = -1;
						ViewModel.cboStation.Text = "";
						if (modGlobal.Clean(oRec["station"]) != "")
						{
							for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
								{
									ViewModel.cboStation.SelectedIndex = i;
									break;
								}
							}
						}

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
						ViewModel.cboItemType.SelectedIndex = -1;
						ViewModel.cboItemType.Text = "";
						for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
							{
								ViewModel.cboItemType.SelectedIndex = i;
								break;
							}
						}
						ViewModel.cboItemColorSize.SelectedIndex = -1;
						ViewModel.cboItemColorSize.Text = "";
						if (modGlobal.Clean(oRec["color_type"]) != "")
						{
							for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
								{
									ViewModel.cboItemColorSize.SelectedIndex = i;
									break;
								}
							}
						}
						else if (modGlobal.Clean(oRec["size_type"]) != "")
						{
							for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
								{
									ViewModel.cboItemColorSize.SelectedIndex = i;
									break;
								}
							}
						}
						ViewModel.cboItemBrand.SelectedIndex = -1;
						ViewModel.cboItemBrand.Text = "";
						if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
						{
							for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
								{
									ViewModel.cboItemBrand.SelectedIndex = i;
									break;
								}
							}
						}
						ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
						ViewModel.dteManufDate.Visible = false;
						if (modGlobal.Clean(oRec["manufactured_date"]) != "")
						{
							ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							System.DateTime TempDate3 = DateTime.FromOADate(0);
							ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate3)) ? TempDate3.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
							ViewModel.dteManufDate.Visible = true;
						}
					}
				}
				else
				{
					bUniformActiveInventory = false;
					//fill in the fields
					ViewModel.cboStation.SelectedIndex = -1;
					ViewModel.cboStation.Text = "";
					if (modGlobal.Clean(oRec["station"]) != "")
					{
						for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
							{
								ViewModel.cboStation.SelectedIndex = i;
								break;
							}
						}
					}

					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
					ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
					ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
					ViewModel.cboReason.SelectedIndex = -1;
					ViewModel.cboReason.Text = "";
					ViewModel.txtComment.Text = "";
					ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
					if (bUniformActiveInventory)
					{
						ViewModel.cmdRetireItem.Enabled = true;
						ViewModel.cmdRetireItem.Visible = true;
						ViewModel.dteRetired.Visible = false;
						ViewModel.cboReason.Visible = false;
						ViewModel.txtComment.Visible = false;
						ViewModel.lbReason.Visible = false;
						ViewModel.lbRetiredDate.Visible = false;
						ViewModel.lbRetireComment.Visible = false;
					}
					else
					{
						ViewModel.cmdRetireItem.Enabled = false;
						ViewModel.cmdRetireItem.Visible = false;
						ViewModel.bRetireItem = true;
						ViewModel.txtComment.Text = modGlobal.Clean(oRec["comment"]);
						if (modGlobal.Clean(oRec["reason_id"]) != "")
						{
							for (int i = 0; i <= ViewModel.cboReason.Items.Count - 1; i++)
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(reason_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if (Convert.ToDouble(modGlobal.GetVal(oRec["reason_id"])) == ViewModel.cboReason.GetItemData(i))
								{
									ViewModel.cboReason.SelectedIndex = i;
									break;
								}
							}
						}
						if (modGlobal.Clean(oRec["retired_date"]) != "")
						{
							System.DateTime TempDate4 = DateTime.FromOADate(0);
							ViewModel.dteRetired.Text = (DateTime.TryParse(modGlobal.Clean(oRec["retired_date"]), out TempDate4)) ? TempDate4.ToString("MM/dd/yy") : modGlobal.Clean(oRec["retired_date"]);
						}
						ViewModel.dteRetired.Visible = true;
						ViewModel.cboReason.Visible = true;
						ViewModel.txtComment.Visible = true;
						ViewModel.lbReason.Visible = true;
						ViewModel.lbRetiredDate.Visible = true;
						ViewModel.lbRetireComment.Visible = true;
					}
					ViewModel.cboItemType.SelectedIndex = -1;
					ViewModel.cboItemType.Text = "";
					for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
						{
							ViewModel.cboItemType.SelectedIndex = i;
							break;
						}
					}
					ViewModel.cboItemColorSize.SelectedIndex = -1;
					ViewModel.cboItemColorSize.Text = "";
					if (modGlobal.Clean(oRec["color_type"]) != "")
					{
						for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
							{
								ViewModel.cboItemColorSize.SelectedIndex = i;
								break;
							}
						}
					}
					else if (modGlobal.Clean(oRec["size_type"]) != "")
					{
						for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
							{
								ViewModel.cboItemColorSize.SelectedIndex = i;
								break;
							}
						}
					}
					ViewModel.cboItemBrand.SelectedIndex = -1;
					ViewModel.cboItemBrand.Text = "";
					if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
					{
						for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
							{
								ViewModel.cboItemBrand.SelectedIndex = i;
								break;
							}
						}
					}
					ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
					ViewModel.dteManufDate.Visible = false;
					if (modGlobal.Clean(oRec["manufactured_date"]) != "")
					{
						ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
						System.DateTime TempDate5 = DateTime.FromOADate(0);
						ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate5)) ? TempDate5.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
						ViewModel.dteManufDate.Visible = true;
					}
				}
				oRec.MoveNext();
			};

			if (bUniformActiveInventory)
			{
				ViewModel.cmdReactivate.Visible = false;
				ViewModel.cmdReactivate.Enabled = false;
			}
			else
			{
				ViewModel.cmdReactivate.Visible = true;
				ViewModel.cmdReactivate.Enabled = true;
			}
			ViewModel.cmdEditItem.Enabled = true;
			ViewModel.cmdEditItem.Text = "Update";
			ViewModel.cmdEditItem.Tag = "0";

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdLastInsp_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			//    if there is no UniformID... should not be here...
			if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int CurrUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
			ViewModel.lbInspID.Text = "";

			//    MsgBox "This feature is currently under construction!", vbOKOnly, "PPE Inventory"
			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdLastInsp.Tag)) == 0)
			{
				if (cUniform.GetLastUniformInspectionForItem(CurrUniformID) != 0)
				{
					ViewModel.lbInspID.Text = cUniform.UniformInspectID.ToString();
					ViewModel.dtInspection.Value = DateTime.Parse(cUniform.UniformInspectDate);
					ViewModel.dtInspection.Enabled = false;
					if (cUniform.UniformInspectPassedFlag == 1)
					{
						ViewModel.chkPassed.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkPassed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
					ViewModel.txtInspComment.Text = cUniform.UniformComment;
					ViewModel.cmdAddNew.Tag = "1";
					ViewModel.cmdAddNew.Text = "Update Inspection";
				}
				else
				{
					ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					ViewModel.dtInspection.Enabled = true;
					ViewModel.txtInspComment.Text = "";
					ViewModel.chkPassed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.cmdAddNew.Tag = "0";
					ViewModel.cmdAddNew.Text = "Add Inspection";
				}
				ViewModel.cmdLastInsp.Tag = "1";
				ViewModel.cmdLastInsp.Text = "Clear Insp Fields";
			}
			else
			{
				ViewModel.cmdLastInsp.Tag = "0";
				ViewModel.cmdLastInsp.Text = "Get Last Inspection";
				ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
				ViewModel.dtInspection.Enabled = true;
				ViewModel.txtInspComment.Text = "";
				ViewModel.chkPassed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.cmdAddNew.Tag = "0";
				ViewModel.cmdAddNew.Text = "Add Inspection";
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Clear/Default fields
			ViewModel.cboStation.SelectedIndex = -1;
			ViewModel.cboStation.Text = "";
			ViewModel.txtTrackingNumber.Text = "";
			ViewModel.txtAlternate.Text = "";
			ViewModel.lbUniformID.Text = "";
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			ViewModel.cboItemColorSize.Items.Clear();
			ViewModel.cboItemColorSize.SelectedIndex = -1;
			ViewModel.cboItemColorSize.Text = "";
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
			ViewModel.dteManufDate.Visible = false;
			ViewModel.lbItemColorSize.Text = "Size/Color";
			ViewModel.lbItemBrand.Text = "Brand/Manufacturer";
			ViewModel.cboItemColorSize.Enabled = true;
			ViewModel.cboItemColorSize.Visible = true;
			ViewModel.cboItemBrand.Enabled = true;
			ViewModel.cboItemBrand.Visible = true;
			ViewModel.cmdEditItem.Tag = "1";
			ViewModel.cmdEditItem.Text = "Add";
			ViewModel.cmdRetireItem.Enabled = false;
			ViewModel.cmdEditItem.Enabled = false;
			ViewModel.bRetireItem = false;
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.dteRetired.Visible = false;
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Visible = false;
			ViewModel.txtComment.Text = "";
			ViewModel.txtComment.Visible = false;
			ViewModel.lbReason.Visible = false;
			ViewModel.lbRetiredDate.Visible = false;
			ViewModel.lbRetireComment.Visible = false;
			ViewModel.cmdCleaning.Enabled = false;
			ViewModel.cmdRepair.Enabled = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{

			FormatReport();
			//MsgBox "This option is under construction", vbOKOnly, "Print PPE Inventory List"
			//Print PPE Inventory Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintHeader("/lPPE Station Inventory /rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing PPE Inventory List");
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

			//    sprPPEList.PrintHeader = "/lPPE Station Inventory /rPage /p of /pc"
			//    sprPPEList.PrintFooter = "/nPrinted on " & Format$(Now(), "mm/dd/yyyy hh:nn:ss")
			//    sprPPEList.PrintAbortMsg = "Printing PPE Inventory List"
			//    sprPPEList.PrintColor = True
			//    sprPPEList.PrintBorder = False
			//    sprPPEList.PrintColHeaders = True
			//    sprPPEList.PrintSmartPrint = True
			//
			//    sprPPEList.PrintSheet

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReactivate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Reactivate Uniform Item"

			if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			UniformCL.UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));

			if (UniformCL.GetUniformReasonRetiredByID(UniformCL.UniformID) != 0)
			{
				if (UniformCL.DeleteUniformReasonRetiredByUniformID(UniformCL.UniformID) != 0)
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("Ooops!  There was a problem deleting the RetiredReason Info!", "Delete UniformReasonRetiredInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			if (UniformCL.GetUniformByID(UniformCL.UniformID) != 0)
			{
				UniformCL.UniformRetiredDate = "";
				if (UniformCL.UpdateUniform() != 0)
				{
					ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
					ViewModel.dteRetired.Visible = false;
					ViewModel.cboReason.SelectedIndex = -1;
					ViewModel.cboReason.Visible = false;
					ViewModel.txtComment.Text = "";
					ViewModel.txtComment.Visible = false;
					ViewModel.lbReason.Visible = false;
					ViewModel.lbRetiredDate.Visible = false;
					ViewModel.lbRetireComment.Visible = false;
					ViewModel.cmdReactivate.Enabled = false;
					ViewModel.cmdReactivate.Visible = false;
					ViewModel.cmdRetireItem.Visible = true;
					ViewModel.cmdRetireItem.Enabled = true;
					ViewModel.bRetireItem = false;
					ViewModel.cboStation.Enabled = true;
				}
				else
				{
					ViewManager.ShowMessage("Ooops!  There was a problem updating Retired Date.", "Reactivate Uniform Item", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				ViewManager.ShowMessage("Ooops!  There was a problem retrieving finding Uniform Item in database.", "Get Uniform Item", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
			FillInventoryGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRepair_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if (modGlobal.Clean(ViewModel.lbUniformID.Text) == "")
			{
				return;
			}
			modGlobal.Shared.gUniformID = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.lbUniformID.Text)));
			ViewManager.NavigateToView(
				frmUniformRepairHistory.DefInstance);
			/*			frmUniformRepairHistory.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Uniform Item Repair History"
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRetireItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Coming Soon"
			ViewModel.cmdRetireItem.Enabled = false;
			ViewModel.cmdRetireItem.Visible = false;
			ViewModel.cmdReactivate.Enabled = false;
			ViewModel.cmdReactivate.Visible = false;
			ViewModel.bRetireItem = true;
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.dteRetired.Visible = true;
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Visible = true;
			ViewModel.txtComment.Text = "";
			ViewModel.txtComment.Visible = true;
			ViewModel.lbReason.Visible = true;
			ViewModel.lbRetiredDate.Visible = true;
			ViewModel.lbRetireComment.Visible = true;
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void dteManufDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		[UpgradeHelpers.Events.Handler]
		internal void dteRetired_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			FillLists();
			ViewModel.cboLocation.SelectedIndex = -1;
			ViewModel.cboLocation.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboType.Text = "";
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();
			ViewModel.lbColorSize.Text = "Color / Size";
			ViewModel.lbUniformID.Text = "";
			ViewModel.FirstTime = true;
			FillInventoryGrid();
			ViewModel.FirstTime = false;

		}


		//UPGRADE_WARNING: (2050) FPSpreadADO.fpSpread Event sprPPEList.AfterUserSort was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		private void sprPPEList_AfterUserSort(int Col)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strSQL = "";
			ViewModel.CurrRow = 1;
			ViewModel.sprPPEList.Row = ViewModel.CurrRow;
			ViewModel.sprPPEList.Col = 9;

			//there is no uniform selected... no need to go on
			if (modGlobal.Clean(ViewModel.sprPPEList.Text) == "")
			{
				return;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));
			ClearDetailFields();
			ViewModel.sprPPEList.Row = ViewModel.CurrRow;
			ViewModel.sprPPEList.Row2 = ViewModel.CurrRow;
			ViewModel.sprPPEList.Col = 1;
			ViewModel.sprPPEList.Col2 = ViewModel.sprPPEList.MaxCols;
			ViewModel.sprPPEList.BlockMode = true;
			ViewModel.sprPPEList.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprPPEList.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				strSQL = "spSelect_UniformInventoryDetail " + UniformID.ToString() + " ";
			}
			else
			{
				strSQL = "spSelect_RetiredUniformDetail " + UniformID.ToString() + " ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("No Uniform Information could be found!", "Something is Wrong!", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.cboStation.SelectedIndex = -1;
			ViewModel.cboStation.Text = "";
			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.cboStation.Enabled = true;
				if (modGlobal.Clean(oRec["station"]) != "")
				{
					for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
						{
							ViewModel.cboStation.SelectedIndex = i;
							break;
						}
					}
				}
			}
			else
			{
				ViewModel.cboStation.Enabled = false;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
			ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
			ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.cmdRetireItem.Enabled = true;
				ViewModel.cmdRetireItem.Visible = true;
				ViewModel.dteRetired.Visible = false;
				ViewModel.cboReason.Visible = false;
				ViewModel.txtComment.Visible = false;
				ViewModel.lbReason.Visible = false;
				ViewModel.lbRetiredDate.Visible = false;
				ViewModel.lbRetireComment.Visible = false;
				ViewModel.cmdReactivate.Visible = false;
				ViewModel.cmdReactivate.Enabled = false;
			}
			else
			{
				ViewModel.cmdRetireItem.Enabled = false;
				ViewModel.cmdRetireItem.Visible = false;
				ViewModel.cmdReactivate.Visible = true;
				ViewModel.cmdReactivate.Enabled = true;
				ViewModel.bRetireItem = true;
				ViewModel.txtComment.Text = modGlobal.Clean(oRec["comment"]);
				if (modGlobal.Clean(oRec["reason_id"]) != "")
				{
					for (int i = 0; i <= ViewModel.cboReason.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(reason_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["reason_id"])) == ViewModel.cboReason.GetItemData(i))
						{
							ViewModel.cboReason.SelectedIndex = i;
							break;
						}
					}
				}
				if (modGlobal.Clean(oRec["retired_date"]) != "")
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					ViewModel.dteRetired.Text = (DateTime.TryParse(modGlobal.Clean(oRec["retired_date"]), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(oRec["retired_date"]);
				}
				ViewModel.dteRetired.Visible = true;
				ViewModel.cboReason.Visible = true;
				ViewModel.txtComment.Visible = true;
				ViewModel.lbReason.Visible = true;
				ViewModel.lbRetiredDate.Visible = true;
				ViewModel.lbRetireComment.Visible = true;

			}
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
			{
				//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
				{
					ViewModel.cboItemType.SelectedIndex = i;
					break;
				}
			}
			ViewModel.cboItemColorSize.SelectedIndex = -1;
			ViewModel.cboItemColorSize.Text = "";
			if (modGlobal.Clean(oRec["color_type"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
					{
						ViewModel.cboItemColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else if (modGlobal.Clean(oRec["size_type"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
					{
						ViewModel.cboItemColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
					{
						ViewModel.cboItemBrand.SelectedIndex = i;
						break;
					}
				}
			}
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.dteManufDate.Visible = false;
			if (modGlobal.Clean(oRec["manufactured_date"]) != "")
			{
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
				ViewModel.dteManufDate.Visible = true;
			}
			ViewModel.cmdEditItem.Enabled = true;
			ViewModel.cmdEditItem.Text = "Update";
			ViewModel.cmdEditItem.Tag = "0";
			ViewModel.cmdCleaning.Enabled = true;
			ViewModel.cmdRepair.Enabled = true;

		}

		private void sprPPEList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strSQL = "";

			if (Row < 1)
			{
				return;
			} //headers were clicked

			ViewModel.CurrRow = Row;
			ViewModel.sprPPEList.Row = ViewModel.CurrRow;
			ViewModel.sprPPEList.Col = 9;

			//there is no uniform selected... no need to go on
			if (modGlobal.Clean(ViewModel.sprPPEList.Text) == "")
			{
				return;
			}
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));

			ClearDetailFields();
			ViewModel.sprPPEList.Row = ViewModel.CurrRow;
			ViewModel.sprPPEList.Row2 = ViewModel.CurrRow;
			ViewModel.sprPPEList.Col = 1;
			ViewModel.sprPPEList.Col2 = ViewModel.sprPPEList.MaxCols;
			ViewModel.sprPPEList.BlockMode = true;
			ViewModel.sprPPEList.BackColor = modGlobal.Shared.YELLOW;
			ViewModel.sprPPEList.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				strSQL = "spSelect_UniformInventoryDetail " + UniformID.ToString() + " ";
			}
			else
			{
				strSQL = "spSelect_RetiredUniformDetail " + UniformID.ToString() + " ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("No Uniform Information could be found!", "Something is Wrong!", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.cboStation.SelectedIndex = -1;
			ViewModel.cboStation.Text = "";
			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.cboStation.Enabled = true;
				if (modGlobal.Clean(oRec["station"]) != "")
				{
					for (int i = 0; i <= ViewModel.cboStation.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(station)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["station"])) == ViewModel.cboStation.GetItemData(i))
						{
							ViewModel.cboStation.SelectedIndex = i;
							break;
						}
					}
				}
			}
			else
			{
				ViewModel.cboStation.Enabled = false;
			}

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
			ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
			ViewModel.txtAlternate.Text = modGlobal.Clean(oRec["alternate_num"]);
			ViewModel.cboReason.SelectedIndex = -1;
			ViewModel.cboReason.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.dteRetired.Text = DateTime.Now.ToString("MM/dd/yy");
			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				ViewModel.cmdRetireItem.Enabled = true;
				ViewModel.cmdRetireItem.Visible = true;
				ViewModel.dteRetired.Visible = false;
				ViewModel.cboReason.Visible = false;
				ViewModel.txtComment.Visible = false;
				ViewModel.lbReason.Visible = false;
				ViewModel.lbRetiredDate.Visible = false;
				ViewModel.lbRetireComment.Visible = false;
				ViewModel.cmdReactivate.Visible = false;
				ViewModel.cmdReactivate.Enabled = false;
			}
			else
			{
				ViewModel.cmdRetireItem.Enabled = false;
				ViewModel.cmdRetireItem.Visible = false;
				ViewModel.cmdReactivate.Visible = true;
				ViewModel.cmdReactivate.Enabled = true;
				ViewModel.bRetireItem = true;
				ViewModel.txtComment.Text = modGlobal.Clean(oRec["comment"]);
				if (modGlobal.Clean(oRec["reason_id"]) != "")
				{
					for (int i = 0; i <= ViewModel.cboReason.Items.Count - 1; i++)
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(reason_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if (Convert.ToDouble(modGlobal.GetVal(oRec["reason_id"])) == ViewModel.cboReason.GetItemData(i))
						{
							ViewModel.cboReason.SelectedIndex = i;
							break;
						}
					}
				}
				if (modGlobal.Clean(oRec["retired_date"]) != "")
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					ViewModel.dteRetired.Text = (DateTime.TryParse(modGlobal.Clean(oRec["retired_date"]), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(oRec["retired_date"]);
				}
				ViewModel.dteRetired.Visible = true;
				ViewModel.cboReason.Visible = true;
				ViewModel.txtComment.Visible = true;
				ViewModel.lbReason.Visible = true;
				ViewModel.lbRetiredDate.Visible = true;
				ViewModel.lbRetireComment.Visible = true;

			}
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			for (int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++)
			{
				//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i))
				{
					ViewModel.cboItemType.SelectedIndex = i;
					break;
				}
			}
			ViewModel.cboItemColorSize.SelectedIndex = -1;
			ViewModel.cboItemColorSize.Text = "";
			if (modGlobal.Clean(oRec["color_type"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
					{
						ViewModel.cboItemColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else if (modGlobal.Clean(oRec["size_type"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemColorSize.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboItemColorSize.GetItemData(i))
					{
						ViewModel.cboItemColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			if (modGlobal.Clean(oRec["manufacturer_id"]) != "")
			{
				for (int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++)
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i))
					{
						ViewModel.cboItemBrand.SelectedIndex = i;
						break;
					}
				}
			}
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.dteManufDate.Visible = false;
			if (modGlobal.Clean(oRec["manufactured_date"]) != "")
			{
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
				ViewModel.dteManufDate.Visible = true;
			}
			ViewModel.cmdEditItem.Enabled = true;
			ViewModel.cmdEditItem.Text = "Update";
			ViewModel.cmdEditItem.Tag = "0";
			ViewModel.cmdCleaning.Enabled = true;
			ViewModel.cmdRepair.Enabled = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtTrackingNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdEditItem.Enabled = EnableOKButton() != 0;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPPEInventory DefInstance
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

		public static frmPPEInventory CreateInstance()
		{
			PTSProject.frmPPEInventory theInstance = Shared.Container.Resolve< frmPPEInventory>();
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
			ViewModel.sprPPEList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			ViewModel.sprPPEList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPPEInventory
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInventoryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPPEInventory m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}