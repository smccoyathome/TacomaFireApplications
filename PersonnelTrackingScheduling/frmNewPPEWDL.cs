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

	public partial class frmNewPPEWDL
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewPPEWDLViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNewPPEWDL));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmNewPPEWDL_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		//form level variables

		public void AddNewUniform()
		{
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

				try
				{

					//if there is no EmployeeID... should not be here...
					if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
					{
						return ;
					}

					//initialize a PersonnelUniform with what you have so far...
					cUniform.PersUniformEmpID = modGlobal.Clean(ViewModel.lbEmpID.Text);
					cUniform.PersUniformReturnedDate = "";

					if ( ((int)DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0 )
					{
						if ( modGlobal.Shared.gSecurity != "ADM" )
						{
							ViewManager.ShowMessage("Issued Date can not be in the future.", "Issued Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							return ;
						}
						else
						{
							cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy");
						}
					}
					else
					{
						cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy");
					}

					cUniform.UniformType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
					cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNumber.Text);

					cUniform.UniformColorType = 0;
					cUniform.UniformSizeType = 0;
					if ( ViewModel.cboColorSize.Visible )
					{
						if ( ViewModel.cboColorSize.SelectedIndex == -1 )
						{
						//continue
						}
						else
						{
							if ( ViewModel.lblColorSize.Text == "Color" )
							{
								cUniform.UniformColorType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
							}
							else
							{
								cUniform.UniformSizeType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
							}
						}
					}

					//Note:  cUniform.UniformRetiredDate is not being updated here
					cUniform.UniformRetiredDate = "";

					cUniform.UniformManufacturerID = 0;
					if ( ViewModel.cboItemBrand.Visible )
					{
						if ( ViewModel.cboItemBrand.SelectedIndex == -1 )
						{
						//continue
						}
						else
						{
							cUniform.UniformManufacturerID = ViewModel.cboItemBrand.GetItemData(ViewModel.cboItemBrand.SelectedIndex);
						}
					}

					if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked )
					{
						cUniform.UniformManufacturedDate = "";
					}
					else if ( ((int)DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0 )
					{
						ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					else
					{
						cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy");
					}

					if ( cUniform.InsertUniform() != 0 )
					{
						cUniform.PersUniformID = cUniform.UniformID;
						if ( cUniform.InsertPersonnelUniform() != 0 )
						{
							ViewManager.ShowMessage("PPE Item has been successfully inserted.", "Insert New PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
						else
						{
							ViewManager.ShowMessage("Ooops!  Error Adding PersonnelUniform record.  Call Debra Lewandowsky x5068.", "Error Adding PersonnelUniform", UpgradeHelpers.Helpers.BoxButtons.OK);
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
								return ;
							}
				}

			}


		private int DetermineSecurity()
		{
			//int result = 0;
			PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

			//result = 0;
			ViewModel.NoLimitUpdate = false;
			ViewModel.LaunderOnly = false;

			if ( modGlobal.Shared.gSecurity == "ADM" )
			{
				ViewModel.NoLimitUpdate = true;
				return -1;
			}

			if ( cUniform.GetPPEInfoForSecurity(modGlobal.Shared.gUser) != 0 )
			{
				ViewModel.NoLimitUpdate = true;
			}
			else if ( cUniform.GetPPEInfoForLaundering(modGlobal.Shared.gUser) != 0 )
			{
				ViewModel.LaunderOnly = true;
			}
			return -1;

		}



		public void RetireReplaceUniform()
		{
			using ( var async1 = this.Async(true) )
			{
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				UpgradeHelpers.Helpers.DialogResult iResp = (UpgradeHelpers.Helpers.DialogResult)0;
				//int UniformID = 0;

				try
				{
					{

						if ( modGlobal.Clean(ViewModel.lbUniformID.Text) == "" )
						{
							this.Return();
							return ;
						}
						if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
						{
							this.Return();
							return ;
						}

						//Edit Information & gather variables
						cUniform.PersUniformEmpID = modGlobal.Clean(ViewModel.lbEmpID.Text);
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cUniform.UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));

						if ( cUniform.GetUniformByID(cUniform.UniformID) != 0 )
						{
							cUniform.PersUniformID = cUniform.UniformID;
							//uniform exists...
							if ( cUniform.DeleteUniformInventory(cUniform.UniformID) != 0 )
							{
							//all is well either way
							}
						}
						else
						{
							ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}

						cUniform.PersUniformReturnedDate = DateTime.Now.ToString("MM/dd/yyyy");
						if ( cUniform.UpdatePersonnelUniformReturnDate() != 0 )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
									.ShowMessage("Will this item be placed back into Inventory?", "Replacing PPE Item", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									//check to see if item will become part of the inventory or retired
									iResp = tempNormalized1;
								});
							if ( iResp == UpgradeHelpers.Helpers.DialogResult.No )
							{
								cUniform.UniformRetiredDate = DateTime.Now.ToString("MM/dd/yyyy");
								if ( cUniform.UpdateUniform() != 0 )
								{
									//NEED To Get more Information and create
									//UniformReasonRetiredInfo row
									modGlobal
										.Shared.gUniformID = cUniform.UniformID;
									async1.Append(() =>
										{
											ViewManager.NavigateToView(
												dlgRetirePPE.DefInstance, true);
										});
								}
							}
							else
							{
								ViewManager.ShowMessage("You will need to go to the PPE Inventory Management to assign it a station.", "Place PPE Item in Inventory", UpgradeHelpers.Helpers.BoxButtons.OK);
							}
						}
						else
						{
							ViewManager.ShowMessage("Oooops!  There was an error updating PersonnelUniform Return Date. Call Debra Lewandowsky x5068.",
								"Updating PersonnelUniform Return Date", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
						async1.Append(() =>
							{

								//Need to Clear Fields and get ready to add new item
								ViewModel.dtInspection.Text = DateTime.Now.ToString("MM/dd/yy");
								ViewModel.txtInspComment.Text = "";
								ViewModel.dteIssued.Text = DateTime.Now.ToString("MM/dd/yy");
								ViewModel.txtTrackingNumber.Text = "";
								ViewModel.cboColorSize.SelectedIndex = -1;
								ViewModel.cboColorSize.Text = "";
								ViewModel.cboItemBrand.SelectedIndex = -1;
								ViewModel.cboItemBrand.Text = "";
								ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
								ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
								ViewModel.dteManufDate.Visible = false;
								ViewModel.lbUniformID.Text = "";
								ViewModel.cmdEditItem.Tag = "1";
								ViewModel.cmdEditItem.Text = "Add";
								ViewModel.cmdReplaceItem.Enabled = false;
								ViewModel.cmdEditItem.Enabled = true;
								ViewModel.cmdNewItem.Visible = false;
							});
					}
				}
				catch
				{

						if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		public void UpdateSelectedUniform()
		{
			using ( var async1 = this.Async(true) )
			{
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult)0;

				try
				{
					{

						//if there is no UniformID or EmployeeID... should not be here...
						if ( modGlobal.Clean(ViewModel.lbUniformID.Text) == "" )
						{
							this.Return();
							return ;
						}
						if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
						{
							this.Return();
							return ;
						}

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cUniform.UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));

						//Edit Information & gather variables
						if ( cUniform.GetUniformByID(cUniform.UniformID) != 0 )
						{
							cUniform.PersUniformID = cUniform.UniformID;
							cUniform.PersUniformEmpID = modGlobal.Clean(ViewModel.lbEmpID.Text);
							cUniform.PersUniformReturnedDate = "";
							//Get Rid of any UniformInventory record
							if ( cUniform.DeleteUniformInventory(cUniform.UniformID) != 0 )
							{
							//all is well either way
							}
						}
						else
						{
							ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}

						if ( ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex) != cUniform.UniformType )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Do you want to change the PPE Item Type?", "Update PPE Item", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									resp = tempNormalized1;
								});
							async1.Append(() =>
								{
									if ( resp == UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										cUniform.UniformType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
									}
									else
									{
										ViewManager.ShowMessage("If you would like to Add a new type, then click New Item.", "Update PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
										ViewModel.cmdEditItem.Enabled = true;
										this.Return();
										return ;
									}
								});
						}
						async1.Append(() =>
							{

								cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNumber.Text);

								cUniform.UniformColorType = 0;
								cUniform.UniformSizeType = 0;
								if ( ViewModel.cboColorSize.Visible )
								{
									if ( ViewModel.cboColorSize.SelectedIndex == -1 )
									{
									//continue
									}
									else
									{
										if ( ViewModel.lblColorSize.Text == "Color" )
										{
											cUniform.UniformColorType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
										}
										else
										{
											cUniform.UniformSizeType = ViewModel.cboColorSize.GetItemData(ViewModel.cboColorSize.SelectedIndex);
										}
									}
								}

								//Note:  cUniform.UniformRetiredDate is not being updated here
								cUniform.UniformRetiredDate = "";

								cUniform.UniformManufacturerID = 0;
								if ( ViewModel.cboItemBrand.Visible )
								{
									if ( ViewModel.cboItemBrand.SelectedIndex == -1 )
									{
									//continue
									}
									else
									{
										cUniform.UniformManufacturerID = ViewModel.cboItemBrand.GetItemData(ViewModel.cboItemBrand.SelectedIndex);
									}
								}

								if ( ViewModel.chkManufDate.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked )
								{
									cUniform.UniformManufacturedDate = "";
								}
								else if ( ((int)DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0 )
								{
									ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
									this.Return();
									return ;
								}
								else
								{
									cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.dteManufDate.Text).ToString("MM/dd/yyyy");
								}

								if ( ((int)DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0 )
								{
									if ( modGlobal.Shared.gSecurity != "ADM" )
									{
										ViewManager.ShowMessage("Issued Date can not be in the future.", "Issued Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
										this.Return();
										return ;
									}
									else
									{
										cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy");
									}
								}
								else
								{
									cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy");
								}

								if ( cUniform.UpdateUniform() != 0 )
								{

									if ( cUniform.UpdatePersonnelUniform() != 0 )
									{
										ViewManager.ShowMessage("PPE Item has been successfully updated.", "Update PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
									}
									else
									{
										ViewManager.ShowMessage("Ooops!  Error Updating PersonnelUniform record.  Call Debra Lewandowsky x5068.", "Error Updating PersonnelUniform", UpgradeHelpers.Helpers.BoxButtons.OK);
									}
								}
								else
								{
									ViewManager.ShowMessage("Ooops!  Error Updating Uniform record.  Call Debra Lewandowsky x5068.", "Error Updating Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
								}
							});
					}
				}
				catch
				{

								if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		private int AddPPEInspection()
		{
				int result = 0;
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

				result = 0;

				try
				{

					if ( ViewModel.CurrRow == 0 )
					{
					return result;
					}
					ViewModel.sprPPEList.Row = ViewModel.CurrRow;

					//Edit Information & gather variables
					ViewModel.sprPPEList.Col = 10; //uniform_id
					if ( modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
					{
					return result;
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniform.UniformInspectUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));
					ViewModel.sprPPEList.Col = 6; //passed_flag
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
					{
						cUniform.UniformInspectPassedFlag = 1;
					}
					else
					{
						cUniform.UniformInspectPassedFlag = 0;
					}

					if ( !Information.IsDate(ViewModel.dtInspection.Text) )
					{
						ViewManager.ShowMessage("Please enter a Valid Inspection Date", "Update PPE Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewManager.SetCurrent(ViewModel.dtInspection);
					return result;
					}

					cUniform.UniformInspectDate = DateTime.Parse(ViewModel.dtInspection.Text).ToString("MM/dd/yyyy");
					cUniform.UniformInspectedBy = modGlobal.Shared.gUser;

					if ( cUniform.InsertUniformInspection() != 0 )
					{
						result = -1;
					}
					else
					{
					ViewManager.ShowMessage("Oooops!  There was an error adding an inspection record for row " + ViewModel.CurrRow.ToString() + ".  Please " +
							"call Debra Lewandowsky x5068!", "Insert UniformInspection Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
					return result;
							}
				}

			return result;
			}

		private int UpdatePPEInspection()
		{
				int result = 0;
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
				System.DateTime InspectionDate = DateTime.FromOADate(0);

				result = 0;

				try
				{

					if ( ViewModel.CurrRow == 0 )
					{
					return result;
					}
					ViewModel.sprPPEList.Row = ViewModel.CurrRow;

					//Edit Information & gather variables
					ViewModel.sprPPEList.Col = 11; //inspection_id
					if ( modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
					{
					return result;
					}
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cUniform.UniformInspectID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));
					ViewModel.sprPPEList.Col = 6; //passed_flag
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
					{
						cUniform.UniformInspectPassedFlag = 1;
					}
					else
					{
						cUniform.UniformInspectPassedFlag = 0;
					}

					if ( !Information.IsDate(ViewModel.dtInspection.Text) )
					{
						ViewManager.ShowMessage("Please enter a Valid Inspection Date", "Update PPE Inspection", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewManager.SetCurrent(ViewModel.dtInspection);
					return result;
					}

					cUniform.UniformInspectDate = DateTime.Parse(ViewModel.dtInspection.Text).ToString("MM/dd/yyyy");
					cUniform.UniformInspectedBy = modGlobal.Shared.gUser;

					if ( cUniform.UpdateUniformInspection() != 0 )
					{
						result = -1;
					}
					else
					{
					ViewManager.ShowMessage("Oooops!  There was an error updating an inspection record for row " + ViewModel.CurrRow.ToString() + ".  Please " +
							"call Debra Lewandowsky x5068!", "Update UniformInspection Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
					return result;
							}
				}

			return result;
			}

		public void FillLists()
		{
			//'Retrieve & fill Grid lists for Manuactures & Sizes & Color (Helmet only)
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboItemType.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboItemType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboItemType.SetItemData(ViewModel.cboItemType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				oRec.MoveNext();
			};

			}

		public void GetLastPPEInspection()
		{
				//Retrieve and Display Employee PPE Inspection Record
				//for Selected Employee
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				int iRow = 0;
				ViewModel.SkipLogic = true;
				try
				{
					ViewModel.cmdAddNew.Enabled = false;
					ViewModel.sprPPEList.Visible = true;
					ViewModel.cmdInspection.Enabled = true;
					ViewModel.cmdRepair.Enabled = true;
					ViewModel.cmdCleaning.Enabled = true;
					ViewModel.dtInspection.Visible = true;
					ViewModel.Label8.Visible = true;
					ViewModel.cmdAddNew.Text = "Add PPE Inspection";
					ViewModel.cmdAddNew.Tag = "0";
					ViewModel.sprPPEList.MaxRows = 500;

					//Clear Grid
					int tempForVar = ViewModel.sprPPEList.MaxRows;
					for ( int i = 1; i <= tempForVar; i++ )
					{
						ViewModel.sprPPEList.Row = i;
						for ( int x = 1; x <= 13; x++ )
						{
							ViewModel.sprPPEList.Col = x;
							ViewModel.sprPPEList.Text = "";
						}
						for ( int x = 6; x <= 9; x++ )
						{
							ViewModel.sprPPEList.Col = x;
							ViewModel.sprPPEList.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.setTypeCheckText("");
							ViewModel.sprPPEList.TypeCheckCenter = true;
							ViewModel.sprPPEList.Value = 0;
						}
					}

					//Get Employee Last PPE Inspection Information
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

					oCmd.CommandText = "sp_GetEmployeeLastPPEInspection '" + ViewModel.lbEmpID.Text + "','" + ViewModel.dtInspection.Value.Date.ToString("MM/dd/yyyy") + "'";

					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Test to determine that a record was retrieved
					if ( oRec.EOF )
					{
						ViewModel.cmdAddNew.Text = "Add PPE Information";
						ViewModel.cmdAddNew.Tag = "2";
						ViewModel.cmdAddNew.Enabled = true;
						ViewModel.sprPPEList.Visible = false;
						ViewModel.cmdInspection.Enabled = false;
						ViewModel.cmdRepair.Enabled = false;
						ViewModel.cmdCleaning.Enabled = false;
						ViewModel.dtInspection.Visible = false;
						ViewModel.Label8.Visible = false;
						return ;
					}

					if ( ViewModel.GetLastInsp )
					{
						ViewModel.cmdAddNew.Text = "Update PPE Inspection";
						ViewModel.cmdAddNew.Tag = "1";
					}

					//Fill PPE Inspection Info from fields
					iRow = 1;

					while ( !oRec.EOF )
					{
						ViewModel.sprPPEList.Row = iRow;
						ViewModel.sprPPEList.Col = 1; //Item type

						ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["UniformType"]);
						ViewModel.sprPPEList.Col = 2; //Issued Date
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx

						if ( !Convert.IsDBNull(oRec["issued_date"]) )
						{
							ViewModel.sprPPEList.Text = Convert.ToDateTime(oRec["issued_date"]).ToString("MM/dd/yyyy");
						}
						ViewModel.sprPPEList.Col = 3; //Brand Name

						ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["manufacturer_name"]);
						ViewModel.sprPPEList.Col = 4; //Size or Color

						if ( modGlobal.Clean(oRec["SizeCode"]) == "" )
						{
							if ( modGlobal.Clean(oRec["Color"]) == "" )
							{
								ViewModel.sprPPEList.Text = "";
							}
							else
							{
								ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["Color"]);
							}
						}
						else
						{
							ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["SizeCode"]);
						}
						ViewModel.sprPPEList.Col = 5; //Tracking Number

						ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["tracking_number"]);
						ViewModel.sprPPEList.Col = 6; //Inspection Result

						ViewModel.sprPPEList.Value = 0;
						if ( ViewModel.GetLastInsp )
						{
							if ( Convert.ToDouble(oRec["passed_flag"]) == 1 )
							{
								ViewModel.sprPPEList.Value = 1;
							}
						}
						ViewModel.sprPPEList.Col = 7; //Not Inspected box...

						ViewModel.sprPPEList.Value = 0;
						if ( modGlobal.Clean(oRec["inspection_date"]) == "" )
						{
							if ( ViewModel.GetLastInsp )
							{
								ViewModel.sprPPEList.Value = 1;
							}
						}
						ViewModel.sprPPEList.Col = 8; //Repair Button
					//UPGRADE_WARNING: (1068) GetVal(oRec(repair_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx

						if ( Convert.ToDouble(modGlobal.GetVal(oRec["repair_id"])) != 0 )
						{
							ViewModel.sprPPEList.Value = 1;
						}
						else
						{
							ViewModel.sprPPEList.Value = 0;
						}
						ViewModel.sprPPEList.Col = 9; //Needs Cleaned
					//UPGRADE_WARNING: (1068) GetVal(oRec(launder_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx

						if ( Convert.ToDouble(modGlobal.GetVal(oRec["launder_id"])) != 0 )
						{
							ViewModel.sprPPEList.Value = 1;
						}
						else
						{
							ViewModel.sprPPEList.Value = 0;
						}
						ViewModel.sprPPEList.Col = 10; //uniform ID

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
						ViewModel.sprPPEList.Col = 11; //inspection ID

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["inspection_id"]));
						ViewModel.sprPPEList.Col = 12; //Repair ID

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["repair_id"]));
						ViewModel.sprPPEList.Col = 13; //Type Code

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_type"]));

						iRow++;
						oRec.MoveNext();
					}
					;

					if ( ViewModel.GetLastInsp )
					{
						if ( cUniform.GetUniformInspectionCommentByEmpDate(modGlobal.Clean(ViewModel.lbEmpID.Text), DateTime.Parse(ViewModel.dtInspection.Text).ToString("MM/dd/yyyy")) != 0 )
						{
							ViewModel.txtInspComment.Text = cUniform.UniformInspectComment;
						}
					}
					ViewModel.cmdAddNew.Enabled = true;
					ViewModel.sprPPEList.MaxRows = iRow - 1;
					ViewModel.FirstTime = false;
					ViewModel.SkipLogic = false;
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public void FindEmployee()
		{
			//If called from Update Screens bring up selected Employee
			ViewModel.cboEmpList.Text = "";

			for ( int i = 0; i <= ViewModel.cboEmpList.Items.Count - 1; i++ )
			{
				//Come Here - for employee id change
				if ( ViewModel.cboEmpList.GetListItem(i).Substring(Math.Max(ViewModel.cboEmpList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gAssignID )
				{
					ViewModel.cboEmpList.Text = ViewModel.cboEmpList.GetListItem(i);
					break;
				}
			}
			//Come Here - for employee id change
			if ( modGlobal.Clean(ViewModel.cboEmpList.Text) != "" )
			{
				ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			}

		}

		public void FillEmployeeInfo()
		{
				//Retrieve and Display Employee Record
				//for Selected Employee

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string sAssignment = "";
				string sText = "";

				try
				{
						ViewModel.txtWDL.Text = "";
						ViewModel.txtExpireDate.Text = "";
						ViewModel.lblName.Text = "";
						ViewModel.lblEmpNum.Text = "";
						ViewModel.lblAssignment.Text = "";
						ViewModel.lbLicenseID.Text = "";
						ViewModel.lbBirthdate.Text = "";
						ViewModel.lblVerify.Text = "";
						ViewModel.Label9.Text = "";
						ViewModel.txtTrackingNum.Text = "";
						ViewModel.txtInspComment.Text = "";
						ViewModel.dtInspection.Text = DateTime.Now.ToString("MM/dd/yy");
						ViewModel.txtInspComment.Text = "";
						ViewModel.dteIssued.Text = DateTime.Now.ToString("MM/dd/yy");
						ViewModel.txtTrackingNumber.Text = "";
						ViewModel.cboItemType.SelectedIndex = -1;
						ViewModel.cboItemType.Text = "";
						ViewModel.cboColorSize.SelectedIndex = -1;
						ViewModel.cboColorSize.Text = "";
						ViewModel.cboItemBrand.SelectedIndex = -1;
						ViewModel.cboItemBrand.Text = "";
						ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
						ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.dteManufDate.Visible = false;
						ViewModel.lblColorSize.Text = "Size/Color";
						ViewModel.lblBrand.Text = "Brand/Manufacturer";
						ViewModel.cboColorSize.Enabled = true;
						ViewModel.cboColorSize.Visible = true;
						ViewModel.cboItemBrand.Enabled = true;
						ViewModel.cboItemBrand.Visible = true;

						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetEmployeeWDLInfo '" + ViewModel.lbEmpID.Text + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						//Test to determine that a record was retrieved
						if ( oRec.EOF )
						{
							ViewManager.ShowMessage("There was a problem retrieving this Employees record", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							return ;
						}

						//Fill Personnel record form fields
						ViewModel.lblName.Text = modGlobal.Clean(oRec["name_full"]);
						ViewModel.lblEmpNum.Text = ViewModel.lbEmpID.Text;
						System.DateTime TempDate = DateTime.FromOADate(0);
						ViewModel.lbBirthdate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["birthdate"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Clean(oRec["birthdate"]);
						ViewModel.Label9.Text = "(Birthdate: " + ViewModel.lbBirthdate.Text + ")";
						sAssignment = "";
						if ( modGlobal.Clean(oRec["battalion_code"]) != "" )
						{
							if ( modGlobal.Clean(oRec["battalion_code"]) == "1 " )
							{
								sAssignment = "Batt : 1 ";
							}
							else
							{
								if ( modGlobal.Clean(oRec["battalion_code"]) == "2 " )
								{
									sAssignment = "Batt: 2 ";
								}
							}
						}
						if ( modGlobal.Clean(oRec["shift_code"]) != "*" )
						{
							sAssignment = sAssignment + "  Shift: " + modGlobal.Clean(oRec["shift_code"]).TrimEnd() + " ";
						}
						if ( modGlobal.Clean(oRec["unit_code"]) != "" )
						{
							sAssignment = sAssignment + "  Unit/Position: " + modGlobal.Clean(oRec["unit_code"]).TrimEnd() + " / " + modGlobal.Clean(oRec["position_code"]).TrimEnd() + " ";
						}
						ViewModel.lblAssignment.Text = modGlobal.Clean(sAssignment);
						ViewModel.lblVerify.Text = "";
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.lbLicenseID.Text = Convert.ToString(modGlobal.GetVal(oRec["license_id"]));
						ViewModel.txtWDL.Text = modGlobal.Clean(oRec["license_number"]);

						System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.txtExpireDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["expiration_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : modGlobal.Clean(oRec["expiration_date"]);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( ViewModel.txtExpireDate.Text == "" && !Convert.IsDBNull(oRec["birthdate"]) )
						{
							System.DateTime TempDate4 = DateTime.FromOADate(0);
							System.DateTime TempDate3 = DateTime.FromOADate(0);
					ViewModel.txtExpireDate.Text = DateTime.Parse((DateTime.TryParse(modGlobal.Clean(oRec["birthdate"]), out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : modGlobal.Clean(oRec["birthdate"])).Month.ToString() + "/" +
										DateAndTime.Day(DateTime.Parse((DateTime.TryParse(modGlobal.Clean(oRec["birthdate"]), out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : modGlobal.Clean(oRec["birthdate"]))).ToString() + "/";
						}
						if ( modGlobal.Clean(oRec["CheckedBy"]) != "" )
						{
							sText = "Last Verified by " + modGlobal.Clean(oRec["CheckedBy"]).Trim();
							if ( modGlobal.Clean(oRec["last_checked_date"]) != "" )
							{
								System.DateTime TempDate5 = DateTime.FromOADate(0);
						sText = sText + " on " + ((DateTime.TryParse(modGlobal.Clean(oRec["last_checked_date"]), out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : modGlobal.Clean(oRec["last_checked_date"]));
							}
						}
						ViewModel.lblVerify.Visible = true;
						ViewModel.lblVerify.Text = sText;

						if ( !ViewModel.FirstTime )
						{
							if ( ViewModel.txtWDL.Text != "" )
							{
								ViewManager.SetCurrent(ViewModel.txtExpireDate);
								ViewModel.txtExpireDate.SelectionStart = 0;
								ViewModel.txtExpireDate.SelectionLength = Strings.Len(ViewModel.txtExpireDate.Text);
							}
							else
							{
								ViewManager.SetCurrent(ViewModel.txtWDL);
								ViewModel.txtWDL.SelectionStart = 0;
								ViewModel.txtWDL.SelectionLength = Strings.Len(ViewModel.txtWDL.Text);
							}
						}
						ViewModel.FirstTime = true;
								GetLastPPEInspection();
					}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void ClearFields()
		{
			ViewModel.cboEmpList.SelectedIndex = -1;
			ViewModel.txtWDL.Text = "";
			ViewModel.txtExpireDate.Text = "";
			ViewModel.lblName.Text = "";
			ViewModel.lblEmpNum.Text = "";
			ViewModel.lblAssignment.Text = "";
			ViewModel.lbEmpID.Text = "";
			ViewModel.lbLicenseID.Text = "";
			ViewModel.lbBirthdate.Text = "";
			ViewModel.lblVerify.Text = "";
			ViewModel.Label9.Text = "";
			ViewModel.txtTrackingNum.Text = "";
			ViewModel.txtInspComment.Text = "";
			ViewModel.lbUniformID.Text = "";

			//Clear Grid
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				ViewModel.sprPPEList.Row = i;
				for ( int x = 1; x <= 5; x++ )
				{
					ViewModel.sprPPEList.Col = x;
					ViewModel.sprPPEList.Text = "";
				}
				for ( int x = 6; x <= 9; x++ )
				{
					ViewModel.sprPPEList.Col = x;
					ViewModel.sprPPEList.Value = 0;
				}
				for ( int x = 10; x <= 13; x++ )
				{
					ViewModel.sprPPEList.Col = x;
					ViewModel.sprPPEList.Value = "";
				}
			}
			ViewModel.dtInspection.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.txtInspComment.Text = "";
			ViewModel.dteIssued.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.txtTrackingNumber.Text = "";
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			ViewModel.cboColorSize.SelectedIndex = -1;
			ViewModel.cboColorSize.Text = "";
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
			ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.dteManufDate.Visible = false;
			ViewModel.lblColorSize.Text = "Size/Color";
			ViewModel.lblBrand.Text = "Brand/Manufacturer";
			ViewModel.cboColorSize.Enabled = true;
			ViewModel.cboColorSize.Visible = true;
			ViewModel.cboItemBrand.Enabled = true;
			ViewModel.cboItemBrand.Visible = true;

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

					if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked )
					{
						if ( ViewModel.CurrBatt == "" && ViewModel.CurrShift == "" )
						{
							strSQL = "spFullNameList ";
						}
						else if ( ViewModel.CurrBatt != "" && ViewModel.CurrShift == "" )
						{
							strSQL = "spOpNameListbyBattShift '" + ViewModel.CurrBatt + "', NULL ";
						}
						else if ( ViewModel.CurrBatt == "" && ViewModel.CurrShift != "" )
						{
							strSQL = "spOpNameListbyBattShift NULL,'" + ViewModel.CurrShift + "'";
						}
						else
						{
							strSQL = "spOpNameListbyBattShift '" + ViewModel.CurrBatt + "','" + ViewModel.CurrShift + "'";
						}
					}
					else
					{
						strSQL = "spArchiveNameList ";
					}

					oCmd.CommandText = strSQL;
					oRec = ADORecordSetHelper.Open(oCmd, "");

					while ( !oRec.EOF )
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
								return ;
							}
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

				if ( ViewModel.cboEmpList.SelectedIndex == -1 )
				{
					return ;
				}
				//Come Here - for employee id change
				ViewModel.SkipLogic = true;
				ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
				modGlobal.Shared.gAssignID = ViewModel.lbEmpID.Text;
				ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
						FillEmployeeInfo();
						ViewModel.cmdEditItem.Enabled = false;
						ViewModel.cmdReplaceItem.Enabled = false;
						if ( ViewModel.NoLimitUpdate )
						{
							ViewModel.cmdNewItem.Visible = true;
							ViewModel.cmdNewItem.Enabled = true;
						}
						ViewModel.frmPPEItem.Text = "PPE Item";

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboItemType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboItemType.SelectedIndex == -1 )
			{
				return ;
			}
			ViewModel.cmdEditItem.Enabled = true;

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdEditItem.Tag)) == 0 )
			{
				ViewModel.cmdReplaceItem.Enabled = ViewModel.NoLimitUpdate;
			}
			else
			{
				ViewModel.cmdReplaceItem.Enabled = false;
			}

			int iItemType = ViewModel.cboItemType.GetItemData(ViewModel.cboItemType.SelectedIndex);
			ViewModel.cboItemBrand.Items.Clear();
			ViewModel.cboColorSize.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewModel.lblBrand.Text = "";
				ViewModel.cboItemBrand.Enabled = false;
				ViewModel.cboItemBrand.Visible = false;
				ViewModel.cboItemBrand.SelectedIndex = -1;
				ViewModel.cboItemBrand.Text = "";
			}
			else
			{
				ViewModel.lblBrand.Text = "Brand/Manufacturer";
				ViewModel.cboItemBrand.Enabled = true;
				ViewModel.cboItemBrand.Visible = true;

				while ( !oRec.EOF )
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

			if ( oRec.EOF )
			{
				//fill in Color for Selected Uniform Type
				strSQL = "spSelect_UniformColorCodeByItemType " + iItemType.ToString() + " ";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if ( oRec.EOF )
				{
					ViewModel.cboColorSize.Text = "";
					ViewModel.cboColorSize.SelectedIndex = -1;
					ViewModel.cboColorSize.Enabled = false;
					ViewModel.lblColorSize.Text = "";
					ViewModel.cboColorSize.Visible = false;
				}
				else
				{
					ViewModel.lblColorSize.Text = "Color";
					ViewModel.cboColorSize.Enabled = true;
					ViewModel.cboColorSize.Visible = true;

					while ( !oRec.EOF )
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
				ViewModel.lblColorSize.Text = "Size";
				ViewModel.cboColorSize.Enabled = true;
				ViewModel.cboColorSize.Visible = true;

				while ( !oRec.EOF )
				{
					ViewModel.cboColorSize.AddItem(modGlobal.Clean(oRec["description"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboColorSize.SetItemData(ViewModel.cboColorSize.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["size_type"])));
					oRec.MoveNext();
				}
				;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkInactive_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

				if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
				{
					ViewModel.opt181.Checked = false;
					ViewModel.opt182.Checked = false;
					ViewModel.optAll.Checked = true;
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;
					ViewModel.cmdPrintChecklist.Enabled = false;
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
				}
						FillNameList();
						ClearFields();

			}

		[UpgradeHelpers.Events.Handler]
		internal void chkManufDate_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.dteManufDate.Visible = ViewModel.chkManufDate.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddNew_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

				bool ShowRepairInfo = false;
				bool NeedsCleaning = false;
				//bool NotInspected = false;
				bool EditInspectionComment = false;
				using ( var async2 = this.Async() )
				{

					switch ( Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.cmdAddNew.Tag))) )
					{
						case 0: //Add PPE Inspection 

							ViewModel.sprPPEList.Col = 7; //Not Insp Check Box 

							int tempForVar = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									//NotInspected = true;
								}
							}
							ViewModel.sprPPEList.Col = 8; //Repair Check Box 

							int tempForVar2 = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar2; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									ShowRepairInfo = true;
								}
							}
							ViewModel.sprPPEList.Col = 9; //Needs Cleaning Check Box 

							int tempForVar3 = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar3; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									NeedsCleaning = true;
								}
							}
							break;
						case 1: //Update PPE Inspection 

							ViewModel.sprPPEList.Col = 7; //Not Insp Check Box 

							int tempForVar4 = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar4; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									//NotInspected = true;
								}
							}
							ViewModel.sprPPEList.Col = 8; //Repair Check Box 

							int tempForVar5 = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar5; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									ShowRepairInfo = true;
								}
							}
							ViewModel.sprPPEList.Col = 9; //Needs Cleaning Check Box 

							int tempForVar6 = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar6; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									NeedsCleaning = true;
								}
							}
							break;
						case 2: //Add PPE InFormation 

							async2.Append(() =>
								{
									ViewManager.NavigateToView(
										dlgAddPPE.DefInstance, true);
								});
							async2.Append(() =>
								{
									GetLastPPEInspection();
								});
							{
								this.Return();
								return ;
							}
					}
				}
				async1.Append(() =>
					{
						using ( var async3 = this.Async() )
						{

							int tempForVar7 = ViewModel.sprPPEList.MaxRows;
							for (int i = 1; i <= tempForVar7; i++)
								{
										ViewModel.sprPPEList.Row = i;
										ViewModel.sprPPEList.Col = 11; //inspection id

										ViewModel.CurrRow = i;
										//UPGRADE_WARNING: (1068) GetVal(sprPPEList.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
										if ( Convert.ToDouble(modGlobal.GetVal(ViewModel.sprPPEList.Text)) == 0 )
										{ //New Inspection

											ViewModel.sprPPEList.Col = 7;
											if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 0 )
											{
										if (AddPPEInspection() != 0)
													{
															if ( modGlobal.Clean(ViewModel.txtInspComment.Text) != "" )
															{
																EditInspectionComment = true;
															}
														}
											}
										}
										else
										{
											//Update Existing Inspection
											ViewModel.sprPPEList.Col = 7;
											if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 0 )
											{
										if (UpdatePPEInspection() != 0)
													{
															if ( modGlobal.Clean(ViewModel.txtInspComment.Text) != "" )
															{
																EditInspectionComment = true;
															}
														}
											}
										}
									}

										if ( EditInspectionComment )
										{
											if ( modGlobal.Clean(ViewModel.lbEmpID.Text) != "" )
											{
												if ( cUniform.GetUniformInspectionCommentByEmpDate(modGlobal.Clean(ViewModel.lbEmpID.Text), DateTime.Parse(ViewModel.dtInspection.Text).ToString("MM/dd/yyyy")) != 0 )
												{
													cUniform.UniformInspectComment = modGlobal.Clean(ViewModel.txtInspComment.Text);
													if ( cUniform.UpdateUniformInspectionComment() != 0 )
													{
													//continue
													}
													else
													{
														ViewManager.ShowMessage("Ooops!  Error Updating Inspection Comment.  Call Debra Lewandowsky x5068.", "Error Updating Inspection Comment", UpgradeHelpers.Helpers.BoxButtons.OK);
													}
												}
												else
												{
													cUniform.UniformInspCommentEmpID = modGlobal.Clean(ViewModel.lbEmpID.Text);
													cUniform.UniformInspCommentDate = DateTime.Parse(ViewModel.dtInspection.Text).ToString("MM/dd/yyyy");
													cUniform.UniformInspectComment = modGlobal.Clean(ViewModel.txtInspComment.Text);
													if ( cUniform.InsertUniformInspectionComment() != 0 )
													{
													//continue
													}
													else
													{
														ViewManager.ShowMessage("Ooops!  Error Adding Inspection Comment.  Call Debra Lewandowsky x5068.", "Error Adding Inspection Comment", UpgradeHelpers.Helpers.BoxButtons.OK);
													}
												}
											}
										}

										if ( ShowRepairInfo )
										{
								async3.Append(() =>
												{
										//show Repair Info dialog window
										ViewManager.NavigateToView(
											//show Repair Info dialog window
											dlgPPERepair.DefInstance, true);
												});
								async3.Append(() =>
												{
													int tempForVar8 = ViewModel.sprPPEList.MaxRows;
													for ( int x = 1; x <= tempForVar8; x++ )
													{
														ViewModel.sprPPEList.Row = x;
														ViewModel.sprPPEList.Col = 6;
														ViewModel.sprPPEList.Value = 0;
													}
												});
										}

										if ( NeedsCleaning )
										{
								async3.Append(() =>
												{
										//show Cleaning/Laundry Info dialog window
										ViewManager.NavigateToView(
											//show Cleaning/Laundry Info dialog window
											frmPPELaunder.DefInstance, true);
												});
								async3.Append(() =>
												{
													int tempForVar9 = ViewModel.sprPPEList.MaxRows;
													for ( int j = 1; j <= tempForVar9; j++ )
													{
														ViewModel.sprPPEList.Row = j;
														ViewModel.sprPPEList.Col = 6;
														ViewModel.sprPPEList.Value = 0;
													}
												});
										}
							async3.Append(() =>
											{
													//Refresh Grid
													ViewModel.GetLastInsp = true;
															GetLastPPEInspection();
															ViewModel.GetLastInsp = false;
														});
												}
											});
									}

						}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAllOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.FirstTime = true;
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				ViewModel.sprPPEList.Row = i;
				ViewModel.sprPPEList.Col = 1;
				if ( ViewModel.sprPPEList.Text == "" )
				{
					return ;
				}
				else
				{
					ViewModel.sprPPEList.Col = 6;
					ViewModel.sprPPEList.Value = 1;
					ViewModel.sprPPEList.Col = 7;
					ViewModel.sprPPEList.Value = 0;
				}
			}
			ViewModel.FirstTime = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCleaning_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append(() =>
					{
						ViewManager.NavigateToView(

							frmPPELaunder.DefInstance, true);
					});
				async1.Append(() =>
					{

							int tempForVar = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								ViewModel.sprPPEList.Col = 9;
								ViewModel.sprPPEList.Value = 0;
							}
									GetLastPPEInspection();
								});
						}
			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdEditItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string strSQL = "";
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

				if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
				{
					this.Return();
					return ;
				}
				ViewModel.cmdEditItem.Enabled = false;

				if ( modGlobal.Clean(ViewModel.lbUniformID.Text) == "" )
				{ //Item is new or Find Button not clicked
					if ( modGlobal.Clean(ViewModel.txtTrackingNumber.Text) != "" )
					{ //Search by Tracking # / Barcode
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						//fill Manufacturer for Selected Uniform Type
						strSQL = "spSelect_UniformByTrackingNumber '" + modGlobal.Clean(ViewModel.txtTrackingNumber.Text) + "' ";
						oCmd.CommandText = strSQL;
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( oRec.EOF )
						{ //If record doesn't exist then Add
									AddNewUniform();
									ViewModel.cmdEditItem.Tag = "0";
									ViewModel.cmdEditItem.Text = "Update";
						}
						else
						{
							ViewManager.ShowMessage("This Tracking Number / Barcode exists.  Please Click Find... ", "Item Exists, Please Find", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}
					}
					else
					{
								AddNewUniform();
								ViewModel.cmdEditItem.Tag = "0";
								ViewModel.cmdEditItem.Text = "Update";
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal(lbUniformID.Caption) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( cUniform.GetPersonnelUniformByEmpIDUniformID(modGlobal.Clean(ViewModel.lbEmpID.Text), Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text))) != 0 )
					{
						async1.Append(() =>
							{
								UpdateSelectedUniform();
							});
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cUniform.PersUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));
						cUniform.PersUniformEmpID = modGlobal.Clean(ViewModel.lbEmpID.Text);
						cUniform.PersUniformReturnedDate = "";
						cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.dteIssued.Text).ToString("MM/dd/yyyy");
						if ( cUniform.InsertPersonnelUniform() != 0 )
						{
							async1.Append(() =>
								{
									UpdateSelectedUniform();
								});
						}
						else
						{
							ViewManager.ShowMessage("Ooops!  There was an error creating PersonnelUniform record.  Please call Debra " +
								"Lewandowsky x5068.  Thank you.", "Creating PersonnelUniform Record", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
					}
				}
				async1.Append(() =>
					{


						//    If cmdEditItem.Tag = 1 Then
						//        AddNewUniform
						//        cmdEditItem.Tag = 0
						//        cmdEditItem.Caption = "Update"
						//    Else
						//        UpdateSelectedUniform
						//    End If

						//Refresh List... show changes
						GetLastPPEInspection();

						if ( ViewModel.NoLimitUpdate )
						{
							ViewModel.cmdNewItem.Visible = true;
							ViewModel.cmdNewItem.Enabled = true;
						}
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdFind_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!", vbOKOnly, "Locate Inventory Item by Tracking/Barcode Number"
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sMessage = "";


			if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
			{
				ViewManager.ShowMessage("Please Select an active Employee before locating an item in inventory.", "Locate Inventory Item by Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			if ( ViewModel.chkInactive.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				ViewManager.ShowMessage("Please Select an active Employee before locating an item in inventory.", "Locate Inventory Item by Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( modGlobal.Clean(ViewModel.txtTrackingNumber.Text) == "" )
			{
				ViewManager.ShowMessage("Please enter Tracking/Barcode Number.", "Locate Inventory Item by Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformByTrackingNumber '" + modGlobal.Clean(ViewModel.txtTrackingNumber.Text) + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Item could not be found.", "Locate Inventory Item by Tracking/Barcode Number", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			//bool bUniformActiveInventory = true; // True until proven false

			while ( !oRec.EOF )
			{
				if ( modGlobal.Clean(oRec["retired_date"]) == "" )
				{ //Uniform is still active
					if ( modGlobal.Clean(oRec["employee_id"]) == "" )
					{ //Uniform not currently issued to anyone
						if ( modGlobal.Clean(oRec["returned_date"]) == "" )
						{ //Returned_Date is Null

							//fill in the fields - item currently in Inventory
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
							ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
							ViewModel.cboItemType.SelectedIndex = -1;
							ViewModel.cboItemType.Text = "";
							for ( int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++ )
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if ( Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i) )
								{
									ViewModel.cboItemType.SelectedIndex = i;
									break;
								}
							}
							ViewModel.cboColorSize.SelectedIndex = -1;
							ViewModel.cboColorSize.Text = "";
							if ( modGlobal.Clean(oRec["color_type"]) != "" )
							{
								for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if ( Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboColorSize.GetItemData(i) )
									{
										ViewModel.cboColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							else if ( modGlobal.Clean(oRec["size_type"]) != "" )
							{
								for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if ( Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboColorSize.GetItemData(i) )
									{
										ViewModel.cboColorSize.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.cboItemBrand.SelectedIndex = -1;
							ViewModel.cboItemBrand.Text = "";
							if ( modGlobal.Clean(oRec["manufacturer_id"]) != "" )
							{
								for ( int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++ )
								{
									//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
									if ( Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i) )
									{
										ViewModel.cboItemBrand.SelectedIndex = i;
										break;
									}
								}
							}
							ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
							ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
							ViewModel.dteManufDate.Visible = false;
							if ( modGlobal.Clean(oRec["manufactured_date"]) != "" )
							{
								ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								System.DateTime TempDate = DateTime.FromOADate(0);
								ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
								ViewModel.dteManufDate.Visible = true;
							}
						}
						else
						{
							sMessage = "Something is wrong! Call Debra Lewandowsky x5068 and let her know ";
							sMessage = sMessage + "the Tracking/Serial Number you were trying to find.";
							ViewManager.ShowMessage(sMessage, "Searching On Tracking Number!", UpgradeHelpers.Helpers.BoxButtons.OK);
							return ;
						}
					}
					else if ( modGlobal.Clean(oRec["returned_date"]) == "" )
					{ //Uniform is currently issued to someone

						ViewManager.ShowMessage("This item is currently issued to " + modGlobal.Clean(oRec["name_full"]) + ".", "", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					else
					{
						//fill in the fields - item was once assigned, ready to be issued
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));
						ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);
						ViewModel.cboItemType.SelectedIndex = -1;
						ViewModel.cboItemType.Text = "";
						for ( int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++ )
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(uniform_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if ( Convert.ToDouble(modGlobal.GetVal(oRec["uniform_type"])) == ViewModel.cboItemType.GetItemData(i) )
							{
								ViewModel.cboItemType.SelectedIndex = i;
								break;
							}
						}
						ViewModel.cboColorSize.SelectedIndex = -1;
						ViewModel.cboColorSize.Text = "";
						if ( modGlobal.Clean(oRec["color_type"]) != "" )
						{
							for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if ( Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) == ViewModel.cboColorSize.GetItemData(i) )
								{
									ViewModel.cboColorSize.SelectedIndex = i;
									break;
								}
							}
						}
						else if ( modGlobal.Clean(oRec["size_type"]) != "" )
						{
							for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if ( Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) == ViewModel.cboColorSize.GetItemData(i) )
								{
									ViewModel.cboColorSize.SelectedIndex = i;
									break;
								}
							}
						}
						ViewModel.cboItemBrand.SelectedIndex = -1;
						ViewModel.cboItemBrand.Text = "";
						if ( modGlobal.Clean(oRec["manufacturer_id"]) != "" )
						{
							for ( int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++ )
							{
								//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								if ( Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) == ViewModel.cboItemBrand.GetItemData(i) )
								{
									ViewModel.cboItemBrand.SelectedIndex = i;
									break;
								}
							}
						}
						ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.dteManufDate.Text = DateTime.Now.ToString("MM/dd/yy");
						ViewModel.dteManufDate.Visible = false;
						if ( modGlobal.Clean(oRec["manufactured_date"]) != "" )
						{
							ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
							ViewModel.dteManufDate.Visible = true;
						}
					}
				}
				else
				{
					ViewManager.ShowMessage("This Item has been retired.", "Found Retired Item", UpgradeHelpers.Helpers.BoxButtons.OK);
					return ;
				}
				oRec.MoveNext();
			};

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdGlobe_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!  Query Globe Spreadsheet Info.", vbOKOnly, "Globe Uniform Information"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is coming soon!  Query Globe Spreadsheet Info.", vbOKOnly, "Globe Uniform Information"
frmGlobeData.DefInstance);
			/*			frmGlobeData.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdInspection_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!", vbOKOnly, "View Inspection History"
			ViewManager.NavigateToView(
				//    MsgBox "This Feature is coming soon!", vbOKOnly, "View Inspection History"
 frmPPEInspHistory.DefInstance);
			/*			frmPPEInspHistory.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdLastInsp_Click(Object eventSender, System.EventArgs eventArgs)
		{
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();

				if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
				{
					return ;
				}

				if ( cUniform.GetLastUniformInspectionDate(modGlobal.Clean(ViewModel.lbEmpID.Text)) != 0 )
				{
					ViewModel.GetLastInsp = true;
					ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Parse(cUniform.UniformInspectDate).ToString("MM/dd/yyyy"));
							GetLastPPEInspection();
							ViewModel.GetLastInsp = false;
				}
				else
				{
					ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					ViewManager.ShowMessage("There is no inspection information for this employee.", "Get Last Inspection for Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewModel.GetLastInsp = false;
							GetLastPPEInspection();
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdLaundryMgmt_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmLaunderMgmt.DefInstance);
			/*			frmLaunderMgmt.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewItem_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//Clear/Default fields
			ViewModel.lbUniformID.Text = "";
			ViewModel.dteIssued.Text = DateTime.Now.ToString("MM/dd/yy");
			ViewModel.txtTrackingNumber.Text = "";
			ViewModel.cboItemType.SelectedIndex = -1;
			ViewModel.cboItemType.Text = "";
			ViewModel.cboColorSize.SelectedIndex = -1;
			ViewModel.cboColorSize.Text = "";
			ViewModel.cboItemBrand.SelectedIndex = -1;
			ViewModel.cboItemBrand.Text = "";
			ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
			ViewModel.lblColorSize.Text = "Size/Color";
			ViewModel.lblBrand.Text = "Brand/Manufacturer";
			ViewModel.cboColorSize.Enabled = true;
			ViewModel.cboColorSize.Visible = true;
			ViewModel.cboItemBrand.Enabled = true;
			ViewModel.cboItemBrand.Visible = true;
			ViewModel.cmdEditItem.Tag = "1";
			ViewModel.cmdEditItem.Text = "Add";
			ViewModel.cmdReplaceItem.Enabled = false;
			ViewModel.cmdEditItem.Enabled = false;
			ViewModel.frmPPEItem.Text = "New PPE Item";

			if ( modGlobal.Clean(ViewModel.lbEmpID.Text) == "" )
			{
				ViewManager.ShowMessage("Please select an Employee before adding a new item.", "Add New PPE Item", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRepair_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgPPERepair.DefInstance, true);
					});
				async1.Append(() =>
					{
							int tempForVar = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								ViewModel.sprPPEList.Col = 8;
								ViewModel.sprPPEList.Value = 0;
							}
									GetLastPPEInspection();
								});
						}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReplaceItem_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append(() =>
					{
						RetireReplaceUniform();
					});
				async1.Append(() =>
					{

						//Refresh List... show changes
						GetLastPPEInspection();
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSearch_Click(Object eventSender, System.EventArgs eventArgs)
		{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				if ( modGlobal.Clean(ViewModel.txtTrackingNum.Text) == "" )
				{
					ViewManager.ShowMessage("You Must Enter a Barcode OR a Tracking Number", "Search By Tracking Number/Barcode", UpgradeHelpers.Helpers.BoxButtons.OK);
					return ;
				}

				string sTrackingNumber = modGlobal.Clean(ViewModel.txtTrackingNum.Text);

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				string SqlString = "spSelect_EmployeeIDByUniformTrackingNumber '" + sTrackingNumber + "' ";
				oCmd.CommandText = SqlString;
				ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

				//Test to determine that a record was retrieved
				if ( !oRec.EOF )
				{
					ClearFields();
					modGlobal.Shared.gAssignID = Convert.ToString(oRec["employee_id"]);
					ViewModel.lbEmpID.Text = Convert.ToString(oRec["employee_id"]);
					FindEmployee();
					ViewModel.dtInspection.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
							FillEmployeeInfo();
							ViewModel.sprPPEList.Col = 5; //Tracking Number Column
							int tempForVar = ViewModel.sprPPEList.MaxRows;
							for ( int i = 1; i <= tempForVar; i++ )
							{
								ViewModel.sprPPEList.Row = i;
								if ( modGlobal.Clean(ViewModel.sprPPEList.Text) == sTrackingNumber )
								{
									sprPPEList_CellClick(ViewModel.sprPPEList, new Stubs._FarPoint.Win.Spread.CellClickEventArgs( i, 0));
								}
							}
				}
				else
				{
					ViewManager.ShowMessage("Could not locate Employee by Tracking Number.", "Not Found - Search By Tracking #", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
						ViewModel.frmPPEItem.Text = "PPE Item";
		//    'fill Manufacturer for Selected Uniform Type
		//    SqlString = "spSelect_UniformByTrackingNumber '" & sTrackingNumber & "' "
		//    ocmd.CommandText = SqlString
		//    Set orec = ocmd.Execute

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSizes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!  Employee Sizes will be displayed.", vbOKOnly, "Bunker Gear Sizes for Employee"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is coming soon!  Employee Sizes will be displayed.", vbOKOnly, "Bunker Gear Sizes for Employee"
frmEmployeeSizes.DefInstance);
			/*			frmEmployeeSizes.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUniformInventory_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPPEInventory.DefInstance);
			/*			frmPPEInventory.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUniformQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPPEInspQuery.DefInstance);
			/*			frmPPEInspQuery.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdateWDL_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{

				string license_number = "";
				System.DateTime expiration_date = DateTime.FromOADate(0);
				System.DateTime TestDate = DateTime.FromOADate(0);
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				ViewModel.cmdUpdateWDL.Enabled = false;
				System.DateTime last_checked_date = DateTime.Now;
				string last_checked_by = modGlobal.Shared.gUser;
				int license_type = 1; //Washington Driver License
				string employee_id = modGlobal.Clean(ViewModel.lbEmpID.Text);
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				int license_id = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbLicenseID.Text));

				if ( modGlobal.Clean(ViewModel.txtWDL.Text) == "" )
				{
					ViewManager.ShowMessage("Please enter WDL Number.", "Update Employee WDL Information", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewManager.SetCurrent(ViewModel.txtWDL);
					ViewModel.txtWDL.SelectionStart = 0;
					ViewModel.txtWDL.SelectionLength = Strings.Len(ViewModel.txtWDL.Text);
					ViewModel.cmdUpdateWDL.Enabled = true;
					this.Return();
					return ;
				}
				else
				{
					ViewModel.txtWDL.Text = modGlobal.Clean(ViewModel.txtWDL.Text).ToUpper();
					license_number = modGlobal.Clean(ViewModel.txtWDL.Text).ToUpper();
				}

				if ( Information.IsDate(ViewModel.txtExpireDate.Text) )
				{
					TestDate = DateTime.Parse(DateTime.Parse(ViewModel.lbBirthdate.Text).ToString("MM/dd/yyyy"));
					expiration_date = DateTime.Parse(DateTime.Parse(ViewModel.txtExpireDate.Text).ToString("MM/dd/yyyy"));
					if ( TestDate.Month != expiration_date.Month || DateAndTime.Day(TestDate) != DateAndTime.Day(expiration_date) || expiration_date.Year < DateTime.Now.Year )
					{
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
								ViewManager.ShowMessage("Are you sure the Expiration Date is Correct?", "Update Employee WDL Information", UpgradeHelpers.Helpers.BoxButtons.YesNo));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{
								Response = tempNormalized1;
							});
						async1.Append(() =>
							{
								if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
								{
									ViewManager.SetCurrent(ViewModel.txtExpireDate);
									ViewModel.txtExpireDate.SelectionStart = 0;
									ViewModel.txtExpireDate.SelectionLength = Strings.Len(ViewModel.txtExpireDate.Text);
									ViewModel.cmdUpdateWDL.Enabled = true;
									this.Return();
									return ;
								}
							});
					}
				}
				else
				{
					expiration_date = DateTime.Parse("1/1/1900");
				}
				async1.Append(() =>
					{

							//Update Database
							oCmd.Connection = modGlobal.oConn;
							oCmd.CommandType = CommandType.Text;

							//UPGRADE_WARNING: (1068) GetVal(lbLicenseID.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if ( Convert.ToDouble(modGlobal.GetVal(ViewModel.lbLicenseID.Text)) == 0 )
							{
								if ( modGlobal.Clean(expiration_date) == "1/1/1900" )
								{
									oCmd.CommandText = "spInsert_EmployeeLicense '" + employee_id + "'," + license_type.ToString() +
								                   ",'" + license_number + "',Null,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(last_checked_date) +
												"','" + last_checked_by + "' ";
								}
								else
								{
		 oCmd.CommandText = "spInsert_EmployeeLicense '" + employee_id + "'," + license_type.ToString() +
												",'" + license_number + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(expiration_date) + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(last_checked_date) +
												"','" + last_checked_by + "' ";
								}
							}
							else
							{
								if ( modGlobal.Clean(expiration_date) == "1/1/1900" )
								{
		 oCmd.CommandText = "spUpdate_EmployeeLicense " + license_id.ToString() +
												",'" + license_number + "',Null,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(last_checked_date) +
												"','" + last_checked_by + "' ";
								}
								else
								{
		 oCmd.CommandText = "spUpdate_EmployeeLicense " + license_id.ToString() +
												",'" + license_number + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(expiration_date) + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(last_checked_date) +
												"','" + last_checked_by + "' ";
								}
							}

							oCmd.ExecuteNonQuery();
							ViewModel.cmdUpdateWDL.Enabled = true;
									FillEmployeeInfo();
								});
						}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintChecklist_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Print PPE Check List
				if ( ViewModel.CurrBatt == "" )
				{
					ViewManager.ShowMessage("Please select a Battalion.", "Print PPE Inspection Checklist", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				if ( ViewModel.CurrShift == "" )
				{
					ViewManager.ShowMessage("Please select a Shift.", "Print PPE Inspection Checklist", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				modGlobal.Shared.gUniformBatt = ViewModel.CurrBatt;
				modGlobal.Shared.gUniformShift = ViewModel.CurrShift;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(

							frmUniformCheckList.DefInstance, true);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtInspection_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( !ViewModel.SkipLogic )
				{
							GetLastPPEInspection();
				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void dtInspection_Click(Object eventSender, System.EventArgs eventArgs)
		{
				if ( !ViewModel.SkipLogic )
				{
							GetLastPPEInspection();
				}
			}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
				ViewModel.opt181.Checked = false;
				ViewModel.opt182.Checked = false;
				ViewModel.optAll.Checked = true;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.FirstTime = true;
				ViewModel.SkipLogic = false;
				ViewModel.GetLastInsp = false;

				FillLists();
						FillNameList();
							ClearFields();
							if ( modGlobal.Shared.gAssignID != "" )
							{
								FindEmployee();
								if ( ViewModel.lbEmpID.Text != "" )
								{
											FillEmployeeInfo();
								}
							}

									if ( DetermineSecurity() != 0 )
									{
										ViewModel.FirstTime = false;
									}

									if ( ViewModel.NoLimitUpdate )
									{
										ViewModel.cmdUniformInventory.Enabled = true;
										ViewModel.cmdNewItem.Enabled = true;
										ViewModel.cmdFind.Enabled = true;
										ViewModel.cmdGlobe.Enabled = true;
										ViewModel.cmdSizes.Enabled = true;
										ViewModel.cmdLaundryMgmt.Enabled = true;
									}
									else
									{
										ViewModel.cmdUniformInventory.Enabled = false;
										ViewModel.cmdNewItem.Enabled = false;
										ViewModel.cmdUniformInventory.Visible = false;
										ViewModel.cmdNewItem.Visible = false;
										ViewModel.cmdFind.Visible = false;
										ViewModel.cmdFind.Enabled = false;
										ViewModel.cmdGlobe.Visible = false;
										ViewModel.cmdGlobe.Enabled = false;
										ViewModel.cmdSizes.Visible = false;
										ViewModel.cmdSizes.Enabled = false;
										if ( ViewModel.LaunderOnly )
										{
											ViewModel.cmdLaundryMgmt.Enabled = true;
											ViewModel.cmdLaundryMgmt.Visible = true;
										}
										else
										{
											ViewModel.cmdLaundryMgmt.Enabled = false;
											ViewModel.cmdLaundryMgmt.Visible = false;
										}
									}

						}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.opt181.Checked )
					{
						ViewModel.CurrBatt = "1";
						if ( ViewModel.optA.Checked || ViewModel.optB.Checked || ViewModel.optC.Checked || ViewModel.optD.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.opt182.Checked )
					{
						ViewModel.CurrBatt = "2";
						if ( ViewModel.optA.Checked || ViewModel.optB.Checked || ViewModel.optC.Checked || ViewModel.optD.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}
					if ( ViewModel.opt183.Checked )
					{
						ViewModel.CurrBatt = "3";
						if ( ViewModel.optA.Checked || ViewModel.optB.Checked || ViewModel.optC.Checked || ViewModel.optD.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
					}
							FillNameList();
							ClearFields();
				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.optA.Checked )
					{
						ViewModel.CurrShift = "A";
						if ( ViewModel.opt181.Checked || ViewModel.opt182.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
						if ( ViewModel.optAll.Checked )
						{
							ViewModel.optAll.Checked = false;
							ViewModel.CurrBatt = "";
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.optAll.Checked )
					{
						ViewModel.CurrBatt = "";
						ViewModel.CurrShift = "";
						ViewModel.optA.Checked = false;
						ViewModel.optB.Checked = false;
						ViewModel.optC.Checked = false;
						ViewModel.optD.Checked = false;
						ViewModel.cmdPrintChecklist.Enabled = false;
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.optB.Checked )
					{
						ViewModel.CurrShift = "B";
						if ( ViewModel.opt181.Checked || ViewModel.opt182.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
						if ( ViewModel.optAll.Checked )
						{
							ViewModel.optAll.Checked = false;
							ViewModel.CurrBatt = "";
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.optC.Checked )
					{
						ViewModel.CurrShift = "C";
						if ( ViewModel.opt181.Checked || ViewModel.opt182.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
						if ( ViewModel.optAll.Checked )
						{
							ViewModel.optAll.Checked = false;
							ViewModel.CurrBatt = "";
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
				if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
				{
					if ( ViewModel.isInitializingComponent )
					{
						return ;
					}

					if ( ViewModel.optD.Checked )
					{
						ViewModel.CurrShift = "D";
						if ( ViewModel.opt181.Checked || ViewModel.opt182.Checked )
						{
							ViewModel.cmdPrintChecklist.Enabled = true;
						}
						if ( ViewModel.optAll.Checked )
						{
							ViewModel.optAll.Checked = false;
							ViewModel.CurrBatt = "";
						}
					}
							FillNameList();
							ClearFields();

				}
			}

		private void sprPPEList_ButtonClicked(object eventSender, Stubs._FarPoint.Win.Spread.EditorNotifyEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//int ButtonDown = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//int Result = 0;

			if ( ViewModel.FirstTime )
			{
				return ;
			}
			if ( ViewModel.SkipLogic )
			{
				return ;
			}

			if ( Row == 0 )
			{
				return ;
			} //header clicked
			if ( Col != 6 && Col != 7 && Col != 8 )
			{
				return ;
			}
			ViewModel.sprPPEList.Row = Row;
			//If Not Inspected
			if ( Col == 7 )
			{
				ViewModel.sprPPEList.Col = 7;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
				{ //True

					//Make sure OK is False
					ViewModel.sprPPEList.Col = 6;
					ViewModel.sprPPEList.Value = 0;
				}
			}
			else if ( Col == 6 )
			{ //If OK is True

				ViewModel.sprPPEList.Col = 6;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
				{
					//Make sure Not Inspected is False
					ViewModel.sprPPEList.Col = 7;
					ViewModel.sprPPEList.Value = 0;
				}
			}
			ViewModel.sprPPEList.Col = 1;
			if ( modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
			{
				return ;
			} //blank row

			string sUniform = modGlobal.Clean(ViewModel.sprPPEList.Text);
			ViewModel.frmPPEItem.Text = "Edit " + sUniform;
			ViewModel.sprPPEList.Col = 2;
			if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
			{ //issued date
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.dteIssued.Text = (DateTime.TryParse(modGlobal.Clean(ViewModel.sprPPEList.Text), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(ViewModel.sprPPEList.Text);
			}
			ViewModel.sprPPEList.Col = 10;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.lbUniformID.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprPPEList.Text));
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.lbUniformID.Text));


			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_UniformByID " + UniformID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			ViewModel.cmdEditItem.Tag = "0";
			ViewModel.cmdEditItem.Text = "Update";
			ViewModel.cmdEditItem.Enabled = true;
			ViewModel.cmdReplaceItem.Enabled = ViewModel.NoLimitUpdate;

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int iUniformType = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"]));

			for ( int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++ )
			{
				if ( iUniformType == ViewModel.cboItemType.GetItemData(i) )
				{
					ViewModel.cboItemType.SelectedIndex = i;
					break;
				}
			}
			ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);

			if ( modGlobal.Clean(oRec["manufacturer_id"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboItemBrand.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) )
					{
						ViewModel.cboItemBrand.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboItemBrand.SelectedIndex = -1;
			}

			if ( modGlobal.Clean(oRec["size_type"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboColorSize.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) )
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else if ( modGlobal.Clean(oRec["color_type"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboColorSize.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) )
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboColorSize.SelectedIndex = -1;
			}

			if ( modGlobal.Clean(oRec["manufactured_date"]) != "" )
			{
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteManufDate.Visible = true;
			}
			else
			{
				ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteManufDate.Visible = false;
			}


		}

		private void sprPPEList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//int Result = 0;


			if ( ViewModel.FirstTime )
			{
				return ;
			}
			if ( ViewModel.SkipLogic )
			{
				return ;
			}

			if ( Row == 0 )
			{
				return ;
			} //header clicked

			ViewModel.sprPPEList.Row = Row;
			ViewModel.sprPPEList.Col = 1;
			if ( modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
			{
				return ;
			} //blank row

			string sUniform = modGlobal.Clean(ViewModel.sprPPEList.Text);
			ViewModel.frmPPEItem.Text = "Edit " + sUniform;
			ViewModel.sprPPEList.Col = 2;
			if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
			{ //issued date
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.dteIssued.Text = (DateTime.TryParse(modGlobal.Clean(ViewModel.sprPPEList.Text), out TempDate)) ? TempDate.ToString("MM/dd/yy") : modGlobal.Clean(ViewModel.sprPPEList.Text);
			}
			ViewModel.sprPPEList.Col = 10;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int UniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));
			ViewModel.lbUniformID.Text = UniformID.ToString();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_UniformByID " + UniformID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Could not find the Uniform in the Database.", "Find Uniform", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			ViewModel.cmdEditItem.Tag = "0";
			ViewModel.cmdEditItem.Text = "Update";
			ViewModel.cmdEditItem.Enabled = true;
			ViewModel.cmdReplaceItem.Enabled = ViewModel.NoLimitUpdate;

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			int iUniformType = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"]));

			for ( int i = 0; i <= ViewModel.cboItemType.Items.Count - 1; i++ )
			{
				if ( iUniformType == ViewModel.cboItemType.GetItemData(i) )
				{
					ViewModel.cboItemType.SelectedIndex = i;
					break;
				}
			}
			ViewModel.txtTrackingNumber.Text = modGlobal.Clean(oRec["tracking_number"]);

			if ( modGlobal.Clean(oRec["manufacturer_id"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboItemBrand.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(manufacturer_id)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboItemBrand.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["manufacturer_id"])) )
					{
						ViewModel.cboItemBrand.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboItemBrand.SelectedIndex = -1;
			}

			if ( modGlobal.Clean(oRec["size_type"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(size_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboColorSize.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["size_type"])) )
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else if ( modGlobal.Clean(oRec["color_type"]) != "" )
			{
				for ( int i = 0; i <= ViewModel.cboColorSize.Items.Count - 1; i++ )
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(color_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( ViewModel.cboColorSize.GetItemData(i) == Convert.ToDouble(modGlobal.GetVal(oRec["color_type"])) )
					{
						ViewModel.cboColorSize.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				ViewModel.cboColorSize.SelectedIndex = -1;
			}

			if ( modGlobal.Clean(oRec["manufactured_date"]) != "" )
			{
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.dteManufDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["manufactured_date"]), out TempDate2)) ? TempDate2.ToString("MM/dd/yy") : modGlobal.Clean(oRec["manufactured_date"]);
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.dteManufDate.Visible = true;
			}
			else
			{
				ViewModel.dteManufDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yy");
				ViewModel.chkManufDate.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.dteManufDate.Visible = false;
			}




		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmNewPPEWDL DefInstance
		{
			get
			{
					if ( Shared.m_vb6FormDefInstance == null )
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

		public static frmNewPPEWDL CreateInstance()
		{
				PTSProject.frmNewPPEWDL theInstance = Shared.Container.Resolve<frmNewPPEWDL>();
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
			ViewModel.sprPPEList.LifeCycleStartup();
			ViewModel.frmPPEItem.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPPEList.LifeCycleShutdown();
			ViewModel.frmPPEItem.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmNewPPEWDL
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewPPEWDLViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNewPPEWDL m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}