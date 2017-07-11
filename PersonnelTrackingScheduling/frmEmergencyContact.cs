using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmEmergencyContact
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmergencyContactViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEmergencyContact));
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


		private void frmEmergencyContact_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void GetContactDetail()
		{
			//Get Contact Detail

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//clear contact detail information
			ViewModel.txtName.Text = "";
			ViewModel.cboRelationship.Text = "";
			ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetContactDetail '" + ViewModel.lbContactID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to retrieve record !", "Get Contact Detail", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.txtName.Text = Convert.ToString(oRec["contact_name"]).Trim();
			ViewModel.cboRelationship.Text = Convert.ToString(oRec["relationship"]).Trim();
			if (Convert.ToBoolean(oRec["primary_flag"]))
			{
				ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			else
			{
				ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}


		}

		public void GetContactPhoneDetail()
		{
			//Get Contact Phone Detail

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//clear contact detail information
			ViewModel.txtPhone.Text = "";
			ViewModel.cboPhoneType.Text = "";
			ViewModel.cboBestTime.Text = "";
			ViewModel.txtComment.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetContactPhoneDetail '" + ViewModel.lbPhoneID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to retrieve record !", "Get Phone Detail", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewModel.txtPhone.Text = Convert.ToString(oRec["phone_number"]).Trim();

			for (int i = 0; i <= ViewModel.cboPhoneType.Items.Count - 1; i++)
			{
				if ( ViewModel.cboPhoneType.GetListItem(i) == Convert.ToString(oRec["phone_type"]).Trim())
				{
					ViewModel.cboPhoneType.Text = ViewModel.cboPhoneType.GetListItem(i);
					break;
				}
			}

			for (int i = 0; i <= ViewModel.cboBestTime.Items.Count - 1; i++)
			{
				if ( ViewModel.cboBestTime.GetListItem(i) == Convert.ToString(oRec["time_of_day"]).Trim())
				{
					ViewModel.cboBestTime.Text = ViewModel.cboBestTime.GetListItem(i);
					break;
				}
			}
			ViewModel.txtComment.Text = Convert.ToString(oRec["comment"]).Trim();

		}

		public void LoadDropDownLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Clear the lists...
			ViewModel.cboRelationship.Items.Clear();
			ViewModel.cboPhoneType.Items.Clear();
			ViewModel.cboBestTime.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//Fill cboRelationship
			oCmd.CommandText = "sp_GetRelationshipTypes ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboRelationship.AddItem(Convert.ToString(oRec["relationship"]).Trim());
				oRec.MoveNext();
			};

			//Fill cboPhoneType
			oCmd.CommandText = "sp_GetContactPhoneTypes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboPhoneType.AddItem(Convert.ToString(oRec["phone_type"]).Trim());
				oRec.MoveNext();
			};

			//Fill cboBestTime
			oCmd.CommandText = "sp_GetTimeOfDayTypes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.cboBestTime.AddItem(Convert.ToString(oRec["time_of_day"]).Trim());
				oRec.MoveNext();
			};

		}

		public void LoadContactPhoneList()
		{
			//Load lstPhone for Selected Contact

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			//clear the phone fields...
			ViewModel.lstPhone.Items.Clear();
			ViewModel.txtPhone.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.cboPhoneType.Text = "";
			ViewModel.cboBestTime.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetContactPhone '" + ViewModel.lbContactID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["phone_number"]).Trim() + "  " + Convert.ToString(oRec["phone_type"]).Trim() + "  " + Convert.ToString(oRec["time_of_day"]).Trim();
				ViewModel.lstPhone.AddItem(strName);
				ViewModel.lstPhone.SetItemData(ViewModel.lstPhone.GetNewIndex(), Convert.ToInt32(oRec["contact_phone_id"]));
				//default phone detail to the top line
				if ( ViewModel.lstPhone.GetNewIndex() == 0)
				{
					ViewModel.txtPhone.Text = Convert.ToString(oRec["phone_number"]).Trim();
					ViewModel.cboPhoneType.Text = Convert.ToString(oRec["phone_type"]).Trim();
					ViewModel.cboBestTime.Text = Convert.ToString(oRec["time_of_day"]).Trim();
				}
				oRec.MoveNext();
			};

			if ( ViewModel.lstPhone.GetListItem(0) != "")
			{
				ViewModel.lbPhoneID.Text = ViewModel.lstPhone.GetItemData(0).ToString();
				UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPhone, 0, true);
			}
			else
			{
				ViewModel.lstPhone.AddItem("No Phone Numbers Exist", 0);
				ViewModel.lbPhoneID.Text = "0";
			}

		}

		public void LoadContactList()
		{
			// Load lstContacts for Employee

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";

			//Clear contact/phone fields...
			ViewModel.lstContacts.Items.Clear();
			ViewModel.lstPhone.Items.Clear();
			ViewModel.txtName.Text = "";
			ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cboRelationship.Text = "";
			ViewModel.txtPhone.Text = "";
			ViewModel.txtComment.Text = "";
			ViewModel.cboPhoneType.Text = "";
			ViewModel.cboBestTime.Text = "";
			ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetContactList '" + ViewModel.lbEmpID.Text + "'";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["contact_name"]).Trim() + " - " + Convert.ToString(oRec["relationship"]).Trim();
				//Add Primary Contact to the top...  and default fields
				if (Convert.ToBoolean(oRec["primary_flag"]))
				{
					ViewModel.lstContacts.AddItem(strName, 0);
					ViewModel.txtName.Text = Convert.ToString(oRec["contact_name"]).Trim();
					ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;

					for (int i = 0; i <= ViewModel.cboRelationship.Items.Count - 1; i++)
					{
						if ( ViewModel.cboRelationship.GetListItem(i) == Convert.ToString(oRec["relationship"]).Trim())
						{
							ViewModel.cboRelationship.Text = ViewModel.cboRelationship.GetListItem(i);
							break;
						}
					}

				}
				else
				{
					ViewModel.lstContacts.AddItem(strName);
				}
				ViewModel.lstContacts.SetItemData(ViewModel.lstContacts.GetNewIndex(), Convert.ToInt32(oRec["contact_id"]));
				oRec.MoveNext();
			};

			if ( ViewModel.lstContacts.GetListItem(0) != "")
			{
				//highlight the default...
				ViewModel.lbContactID.Text = ViewModel.lstContacts.GetItemData(0).ToString();
				UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstContacts, 0, true);
				//set command buttons appropriately...
				ViewModel.cmdUpdate.Visible = true;
				ViewModel.cmdDelete.Visible = true;
				ViewModel.cmdDelPhone.Visible = true;
				ViewModel.cmdAddPhone.Tag = "1";
				ViewModel.cmdAddPhone.Text = "&New Phone";
				ViewModel.cmdAddPhone.Visible = true;
				ViewModel.cmdAdd.Tag = "1";
				ViewModel.cmdAdd.Text = "New &Contact";
				ViewModel.cmdAdd.Visible = true;
				//Load the lstPhone
				LoadContactPhoneList();
			}
			else
			{
				//load the lstContacts and lstPhone to indicate no records exist...
				ViewModel.lstContacts.AddItem("No Contacts Exist", 0);
				ViewModel.lbContactID.Text = "0";
				ViewModel.lstPhone.AddItem("No Phone Numbers Exist", 0);
				ViewModel.lbPhoneID.Text = "0";
				ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				//set command buttons appropriately...
				ViewModel.cmdUpdate.Visible = false;
				ViewModel.cmdDelete.Visible = false;
				ViewModel.cmdDelPhone.Visible = false;
				ViewModel.cmdAddPhone.Visible = false;
				ViewModel.cmdAdd.Tag = "2";
				ViewModel.cmdAdd.Text = "&Add New Contact";
				ViewModel.cmdAdd.Visible = true;

			}

		}

		public void FillNameList()
		{
			//Fill Employee Name List

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";

			try
			{
				ViewModel.cboEmpList.Items.Clear();

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				switch(modGlobal.Shared.gSecurity)
				{
					case "HAZ" :
						oCmd.CommandText = "sp_FillXList 'HZM'";
						break;
					case "ADM" : case "PER" :
						oCmd.CommandText = "spFullNameList";
						break;
					case "BAT" : case "AID" :
						oCmd.CommandText = "spOpNameList";
						break;
					case "RO" :
						strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
						this.ViewModel.cboEmpList.AddItem(strName);
						return;
					default:
						oCmd.CommandText = "sp_FillXList '" + modGlobal.Shared.gSecurity + "'";
						break;
				}

				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (modGlobal.Shared.gSecurity != "RO")
				{

					while(!oRec.EOF)
					{
						strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
						ViewModel.cboEmpList.AddItem(strName);
						oRec.MoveNext();
					};
				}
				else
				{
					strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
					ViewModel.cboEmpList.AddItem(strName);
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

		public void FindEmployee()
		{
			//If called from Update Screens bring up selected Employee


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
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Contact listbox for selected Employee

			if ( ViewModel.cboEmpList.SelectedIndex == -1)
			{
				return;
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
			ViewModel.lbContactID.Text = "";
			ViewModel.lbPhoneID.Text = "";

			//Load lstContacts
			LoadContactList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				//ADORecordSetHelper oRec = null;
				string str1 = "", str2 = "";
				int i = 0;

				//Check cmdAdd.Tag to see if fields need cleared...
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdAdd.Tag)) == 1)
				{

					//Unselect row in Contact List Box
					for (i = 0; i <= ViewModel.lstContacts.Items.Count - 1; i++)
					{
						UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstContacts, i, false);
					}

					//Unselect row in Contact Phone List Box
					for (i = 0; i <= ViewModel.lstPhone.Items.Count - 1; i++)
					{
						UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPhone, i, false);
					}

					//Clear Fields...
					ViewModel.lbContactID.Text = "0";
					ViewModel.lbPhoneID.Text = "0";
					ViewModel.txtName.Text = "";
					ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					ViewModel.cboRelationship.Text = "";
					ViewModel.txtPhone.Text = "";
					ViewModel.txtComment.Text = "";
					ViewModel.cboPhoneType.Text = "";
					ViewModel.cboBestTime.Text = "";
					ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;

					//Reset Buttons...
					ViewModel.cmdAdd.Tag = "2";
					ViewModel.cmdAdd.Text = "&Add New Contact";
					ViewModel.cmdDelete.Visible = false;
					ViewModel.cmdDelPhone.Visible = false;
					ViewModel.cmdUpdate.Visible = false;
					ViewModel.cmdAddPhone.Visible = false;

					//Set Focus
					ViewManager.SetCurrent(

//Set Focus
ViewModel.txtName);
					this.Return();
					return ;
				}

				//Edit Fields
				ViewModel.txtName.Text = ViewModel.txtName.Text.Trim();
				if ( ViewModel.txtName.Text == "")
				{
					ViewManager.ShowMessage("You must enter a Contact Name !!", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtName);
					this.Return();
					return ;
				}
				ViewModel.cboRelationship.Text = ViewModel.cboRelationship.Text.Trim();
				if ( ViewModel.cboRelationship.Text == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
							ViewManager.ShowMessage("No Relationship was selected. Default to 'Unknown' " + "?? ", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								this.Return();
								return ;
							}
							else
							{
								ViewModel.cboRelationship.Text = "Unknown";
							}
						});
						}
				async1.Append(() =>
					{
						using ( var async2 = this.Async() )
						{
							ViewModel.txtPhone.Text = ViewModel.txtPhone.Text.Trim();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if ( ViewModel.txtPhone.Text == "" || Convert.IsDBNull(ViewModel.txtPhone.Text))
							{
								ViewManager.ShowMessage("You must enter a phone number !! ", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							else if (Strings.Len(ViewModel.txtPhone.Text) < 14)
							{
								ViewManager.ShowMessage("Phone Number must be in this format - '(###) ###-####' ", "Insert Emergency Contact", UpgradeHelpers.Helpers.
									BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							else if (Strings.Len(ViewModel.txtPhone.Text) > 30)
							{
								ViewManager.ShowMessage("Phone Number too long (30 character limit) ", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							ViewModel.cboPhoneType.Text = ViewModel.cboPhoneType.Text.Trim();
							if ( ViewModel.cboPhoneType.Text == "")
							{
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("No Phone Type was selected. Default to 'Unknown' " + "?? ", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
								async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
									{
										Response = tempNormalized3;
									});
								async2.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
										{
											this.Return();
											return ;
										}
										else
										{
											ViewModel.cboPhoneType.Text = "Unknown";
										}
									});
									}
							async2.Append(() =>
								{
									using ( var async3 = this.Async() )
									{
										ViewModel.cboBestTime.Text = ViewModel.cboBestTime.Text.Trim();
										if ( ViewModel.cboBestTime.Text == "")
										{
											async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
													=> ViewManager.ShowMessage("No Time Available was selected. Default to 'AM/PM' " + "?? ", "Insert Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
											async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
											async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
												{
													Response = tempNormalized5;
												});
											async3.Append(() =>
												{
													if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
													{
														this.Return();
														return ;
													}
													else
													{
														ViewModel.cboBestTime.Text = "AM/PM";
													}
												});
												}
										async3.Append(() =>
											{

												string CommStr = ViewModel.txtComment.Text.Trim();

												while((CommStr.IndexOf('\'') + 1) != 0)
												{
													i = (CommStr.IndexOf('\'') + 1);
													str1 = CommStr.Substring(0, Math.Min(i - 1, CommStr.Length));
													str2 = CommStr.Substring(Math.Max(CommStr.Length - (Strings.Len(CommStr) - i), 0));
													CommStr = str1 + "-" + str2;
												};
												ViewModel.txtComment.Text = CommStr.Substring(0, Math.Min(255, CommStr.Length));

												//Execute spInsertEmergencyContact
												oCmd.Connection = modGlobal.oConn;
												oCmd.CommandType = CommandType.Text;

												oCmd.CommandText = "spInsertEmergencyContact '" + ViewModel.lbEmpID.Text + "','" + modGlobal.Clean(
																									modGlobal.ProofSQLString(ViewModel.txtName.Text)) + "','" + ViewModel.cboRelationship.Text + "',"
																					+ ((int)ViewModel.chkPrimary.CheckState).ToString() + ",'" + ViewModel.
																	cboPhoneType.Text + "','" + ViewModel.txtPhone.Text + "','" + ViewModel.cboBestTime.Text + "','" + ViewModel.txtComment.Text + "'";
												oCmd.ExecuteNonQuery();

												//Refresh Screen
												LoadContactList();
											});
									}
								});
						}
					});
			}

											}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddPhone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				string str1 = "", str2 = "";
				int i = 0;

				//Check cmdAddPhone.Tag to see if fields need cleared...
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdAddPhone.Tag)) == 1)
				{
					//Unselect row in Contact Phone List Box
					for (i = 0; i <= ViewModel.lstPhone.Items.Count - 1; i++)
					{
						UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPhone, i, false);
					}

					//Clear Fields
					ViewModel.lbPhoneID.Text = "0";
					ViewModel.txtPhone.Text = "";
					ViewModel.txtComment.Text = "";
					ViewModel.cboPhoneType.Text = "";
					ViewModel.cboBestTime.Text = "";

					//Reset Buttons...
					ViewModel.cmdAddPhone.Tag = "2";
					ViewModel.cmdAddPhone.Text = "Add &New Phone";
					ViewModel.cmdAddPhone.Visible = true;
					ViewModel.cmdDelPhone.Visible = false;
					ViewModel.cmdUpdate.Visible = false;
					ViewManager.SetCurrent(ViewModel.txtPhone);
					this.Return();
					return ;
				}

				//Edit Fields
				ViewModel.txtPhone.Text = ViewModel.txtPhone.Text.Trim();
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( ViewModel.txtPhone.Text == "" || Convert.IsDBNull(ViewModel.txtPhone.Text))
				{
					ViewManager.ShowMessage("You must enter a phone number !! ", "Add Contact Phone", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtPhone);
					ViewModel.txtPhone.SelectionStart = 0;
					ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
					this.Return();
					return ;
				}
				else if (Strings.Len(ViewModel.txtPhone.Text) < 14)
				{
					ViewManager.ShowMessage("Phone Number must be in this format - '(###) ###-####' ", "Add Contact Phone", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtPhone);
					ViewModel.txtPhone.SelectionStart = 0;
					ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
					this.Return();
					return ;
				}
				else if (Strings.Len(ViewModel.txtPhone.Text) > 30)
				{
					ViewManager.ShowMessage("Phone Number too long (30 character limit) ", "Add Contact Phone", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtPhone);
					ViewModel.txtPhone.SelectionStart = 0;
					ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
					this.Return();
					return ;
				}
				ViewModel.cboPhoneType.Text = ViewModel.cboPhoneType.Text.Trim();
				if ( ViewModel.cboPhoneType.Text == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
							.ShowMessage("No Phone Type was selected. Default to 'Unknown' " + "?? ", "Add Contact Phone", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								this.Return();
								return ;
							}
							else
							{
								ViewModel.cboPhoneType.Text = "Unknown";
							}
						});
						}
				async1.Append(() =>
					{
						using ( var async2 = this.Async() )
						{
							ViewModel.cboBestTime.Text = ViewModel.cboBestTime.Text.Trim();
							if ( ViewModel.cboBestTime.Text == "")
							{
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("No Time Available was selected. Default to 'AM/PM'" + "?? ", "Add Contact Phone", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
								async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
									{
										Response = tempNormalized3;
									});
								async2.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
										{
											this.Return();
											return ;
										}
										else
										{
											ViewModel.cboBestTime.Text = "AM/PM";
										}
									});
									}
							async2.Append(() =>
								{

									string CommStr = ViewModel.txtComment.Text.Trim();

									while((CommStr.IndexOf('\'') + 1) != 0)
									{
										i = (CommStr.IndexOf('\'') + 1);
										str1 = CommStr.Substring(0, Math.Min(i - 1, CommStr.Length));
										str2 = CommStr.Substring(Math.Max(CommStr.Length - (Strings.Len(CommStr) - i), 0));
										CommStr = str1 + "-" + str2;
									};
									ViewModel.txtComment.Text = CommStr.Substring(0, Math.Min(255, CommStr.Length));

									//Execute spInsertContactPhoneNumber
									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;

									oCmd.CommandText = "spInsertContactPhoneNumber '" + ViewModel.lbContactID.Text + "','" + ViewModel.cboPhoneType.
														Text + "','" + ViewModel.txtPhone.Text + "','" + ViewModel.cboBestTime.Text + "','" + ViewModel.txtComment.Text + "'";
									oCmd.ExecuteNonQuery();

									//Refresh Screen
									LoadContactList();
								});
						}
					});
			}

								}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;

			if ( ViewModel.lbContactID.Text == "0")
			{
				return;
			}

			//Execute spDeleteEmergencyContact
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spDeleteEmergencyContact '" + ViewModel.lbEmpID.Text + "','" + ViewModel.lbContactID.Text + "'";
			oCmd.ExecuteNonQuery();

			//Refresh Screen
			LoadContactList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelPhone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.lbContactID.Text == "0" || UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.lbPhoneID.Text) == 0)
			{
				return;
			}

			//Check to see if Contact has another phone, if not send Message - that Contact must have one phone number
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "sp_GetContactPhoneCount '" + ViewModel.lbPhoneID.Text + "','" + ViewModel.lbContactID.Text + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewManager.ShowMessage("Unable to retrieve record !", "Get Phone Count", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//If no other phone exist for Contact, give message and exit sub
			if (Convert.ToDouble(oRec["PhoneCount"]) < 1)
			{
				ViewManager.ShowMessage("Contact must have at least one phone number !!", "Delete Failed", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//If another number exists, Execute spDeleteContactPhoneNumber
			oCmd.CommandText = "spDeleteContactPhoneNumber '" + ViewModel.lbPhoneID.Text + "'";
			oCmd.ExecuteNonQuery();

			//Refresh Screen
			LoadContactList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				string str1 = "", str2 = "";
				int i = 0;

				//Edit Fields
				ViewModel.txtName.Text = ViewModel.txtName.Text.Trim();
				if ( ViewModel.txtName.Text == "")
				{
					ViewManager.ShowMessage("You must enter a Contact Name !!", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtName);
					this.Return();
					return ;
				}

				if ( ViewModel.cboRelationship.Text == "")
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
							ViewManager.ShowMessage("No Relationship was selected. Default to 'Unknown' " + "?? ", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								this.Return();
								return ;
							}
							else
							{
								ViewModel.cboRelationship.Text = "Unknown";
							}
						});
						}
				async1.Append(() =>
					{
						using ( var async2 = this.Async() )
						{
							ViewModel.txtPhone.Text = ViewModel.txtPhone.Text.Trim();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if ( ViewModel.txtPhone.Text == "" || Convert.IsDBNull(ViewModel.txtPhone.Text))
							{
								ViewManager.ShowMessage("You must enter a phone number !! ", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							else if (Strings.Len(ViewModel.txtPhone.Text) < 14)
							{
								ViewManager.ShowMessage("Phone Number must be in this format - '(###) ###-####' ", "Update Emergency Contact", UpgradeHelpers.Helpers.
									BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							else if (Strings.Len(ViewModel.txtPhone.Text) > 30)
							{
								ViewManager.ShowMessage("Phone Number too long (30 character limit) ", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtPhone);
								ViewModel.txtPhone.SelectionStart = 0;
								ViewModel.txtPhone.SelectionLength = Strings.Len(ViewModel.txtPhone.Text);
								this.Return();
								return ;
							}
							ViewModel.cboPhoneType.Text = ViewModel.cboPhoneType.Text.Trim();
							if ( ViewModel.cboPhoneType.Text == "")
							{
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("No Phone Type was selected. Default to 'Unknown' " + "?? ", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
								async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
								async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
									{
										Response = tempNormalized3;
									});
								async2.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
										{
											this.Return();
											return ;
										}
										else
										{
											ViewModel.cboPhoneType.Text = "Unknown";
										}
									});
									}
							async2.Append(() =>
								{
									using ( var async3 = this.Async() )
									{
										ViewModel.cboBestTime.Text = ViewModel.cboBestTime.Text.Trim();
										if ( ViewModel.cboBestTime.Text == "")
										{
											async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
													=> ViewManager.ShowMessage("No Time Available was selected. Default to 'AM/PM' " + "?? ", "Update Emergency Contact", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
											async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
											async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
												{
													Response = tempNormalized5;
												});
											async3.Append(() =>
												{
													if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
													{
														this.Return();
														return ;
													}
													else
													{
														ViewModel.cboBestTime.Text = "AM/PM";
													}
												});
												}
										async3.Append(() =>
											{

												string CommStr = ViewModel.txtComment.Text.Trim();

												while((CommStr.IndexOf('\'') + 1) != 0)
												{
													i = (CommStr.IndexOf('\'') + 1);
													str1 = CommStr.Substring(0, Math.Min(i - 1, CommStr.Length));
													str2 = CommStr.Substring(Math.Max(CommStr.Length - (Strings.Len(CommStr) - i), 0));
													CommStr = str1 + "-" + str2;
												};
												ViewModel.txtComment.Text = CommStr.Substring(0, Math.Min(255, CommStr.Length));

												//Execute spUpdateEmergencyContact
												oCmd.Connection = modGlobal.oConn;
												oCmd.CommandType = CommandType.Text;

												oCmd.CommandText = "spUpdateEmergencyContact '" + ViewModel.lbContactID.Text + "','" + ViewModel.lbPhoneID.Text +
																													"','" + ViewModel.lbEmpID.Text + "','" + modGlobal.Clean(modGlobal.ProofSQLString
																									(ViewModel.txtName.Text)) + "','" + ViewModel.cboRelationship.Text + "'," +
																								((int)ViewModel.chkPrimary.CheckState).ToString() + ",'" + ViewModel.cboPhoneType
																	.Text + "','" + ViewModel.txtPhone.Text + "','" + ViewModel.cboBestTime.Text + "','" + ViewModel.txtComment.Text + "'";
												oCmd.ExecuteNonQuery();

												//Refresh Screen
												LoadContactList();
											});
									}
								});
						}
					});
			}

											}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			// Set to Current Employee if called from Update Screen

			FillNameList();
			LoadDropDownLists();

			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
				LoadContactList();
			}
			else
			{
				ViewModel.txtName.Text = "";
				ViewModel.txtPhone.Text = "";
				ViewModel.txtComment.Text = "";
				ViewModel.chkPrimary.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}



		}

		[UpgradeHelpers.Events.Handler]
		internal void lstContacts_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Load lstPhone for new Contact

			if ( ViewModel.lstContacts.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbContactID.Text = ViewModel.lstContacts.GetItemData(ViewModel.lstContacts.SelectedIndex).ToString();
			ViewModel.lbPhoneID.Text = "";

			//Get Contact Detail
			GetContactDetail();
			//Load lstPhone
			LoadContactPhoneList();

			//Reset Buttons
			ViewModel.cmdUpdate.Visible = true;
			ViewModel.cmdDelete.Visible = true;
			ViewModel.cmdUpdate.Visible = true;
			ViewModel.cmdDelPhone.Visible = true;
			ViewModel.cmdAddPhone.Visible = true;
			ViewModel.cmdAdd.Tag = "1";
			ViewModel.cmdAdd.Text = "New &Contact";
			ViewModel.cmdAdd.Visible = true;


		}

		[UpgradeHelpers.Events.Handler]
		internal void lstPhone_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Change lbPhoneID to new ID

			if ( ViewModel.lstPhone.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.lbPhoneID.Text = ViewModel.lstPhone.GetItemData(ViewModel.lstPhone.SelectedIndex).ToString();

			//Get Phone Detail
			GetContactPhoneDetail();

			//Reset Buttons
			ViewModel.cmdAddPhone.Tag = "1";
			ViewModel.cmdAddPhone.Text = "&New Phone";
			ViewModel.cmdAddPhone.Visible = true;
			ViewModel.cmdUpdate.Visible = true;
			ViewModel.cmdDelPhone.Visible = true;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmEmergencyContact DefInstance
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

		public static frmEmergencyContact CreateInstance()
		{
			PTSProject.frmEmergencyContact theInstance = Shared.Container.Resolve< frmEmergencyContact>();
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
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmEmergencyContact
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmergencyContactViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmEmergencyContact m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}