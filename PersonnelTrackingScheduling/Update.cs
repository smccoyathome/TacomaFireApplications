using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmUpdate
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUpdateViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		//******************************************************
		//Update Personnel Information Form
		//- Update or Delete Personnel Records
		//- Access New Promotion and Assign Position Forms
		//-  for selected employee
		//******************************************************
		//ADODB
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUpdate));
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



		public int GetNewID(string Empid)
		{
			//Create unique PersonnelArchive Key
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string WorkID = "";
			int WorkInc = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_FindArcPersonnel '" + Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				return Convert.ToInt32(Conversion.Val("1" + Empid));
			}
			else
			{
				WorkInc = 1;
				WorkID = Conversion.Str(WorkInc) + Empid;

				while(!oRec.EOF)
				{
					if (Convert.ToDouble(oRec["per_archive_id"]) == Conversion.Val(WorkID))
					{
						WorkInc++;
						for (int i = WorkInc; i <= 9; i++)
						{
							WorkID = Conversion.Str(i) + Empid;
							if (Convert.ToDouble(oRec["per_archive_id"]) != Conversion.Val(WorkID))
							{
								WorkInc = i;
								break;
							}
							else
							{
								WorkID = "";
							}
						}
						if (WorkID == "")
						{
							return 0;
						}
					}
					oRec.MoveNext();
				};
				return Convert.ToInt32(Conversion.Val(WorkID));
			}

		}

		public void SetSecurity()
		{
			//Disable any controls not accessable by current user
			if (modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "PER")
			{
				if (modGlobal.Shared.gSecurity == "PER")
				{
					ViewModel.cmdNote.Enabled = false;
				}
				//All controls accessible... except Personnel Notes only for ADM
			}
			else
			{
				ViewModel.cmdAssign.Enabled = false;
				ViewModel.cmdNewPromo.Enabled = false;
				ViewModel.cmdDelete.Enabled = false;
				ViewModel.cmdNote.Enabled = false;
				ViewModel.txtSSN.Enabled = false;
				ViewModel.txtSSN.Visible = false;
				ViewModel.txtCOT.Enabled = false;
				ViewModel.txtTFD.Enabled = false;
				ViewModel.cboBenefit.Enabled = false;
				ViewModel.txtUnion.Enabled = false;
				ViewModel.txtExceptDay.Enabled = false;
				ViewModel.chkStatus.Enabled = false;
				ViewModel.cboJobCode.Enabled = false;
				ViewModel.txtStep.Enabled = false;
				ViewModel.cmdSwitch.Visible = false;
				ViewModel.cmdSwitch.Tag = "3";
				ViewModel.Label15.Visible = false;
				ViewModel.Label16.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label17.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label18.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label19.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label1.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label3.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbStep.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbUnion.ForeColor = modGlobal.Shared.LT_GRAY;
			}

		}


		public void ClearForm()
		{
			//Clear all fields on form following Delete
			ViewModel.lbEmpID.Text = "";
			ViewModel.lbJobCode.Text = "";
			ViewModel.cboJobCode.SelectedIndex = -1;
			ViewModel.cboJobCode.Text = "";
			ViewModel.txtFName.Text = "";
			ViewModel.txtMName.Text = "";
			ViewModel.txtLName.Text = "";
			ViewModel.txtSName.Text = "";
			ViewModel.txtNameKnownBy.Text = "";
			ViewModel.txtBDay.Text = "";
			ViewModel.txtSex.Text = "";
			ViewModel.txtPhone.Text = "";
			ViewModel.txtAddress.Text = "";
			ViewModel.txtCity.Text = "";
			ViewModel.txtZip.Text = "";
			ViewModel.txtSSN.Text = "";
			ViewModel.txtCOT.Text = "";
			ViewModel.txtTFD.Text = "";
			ViewModel.txtUnion.Text = "";
			ViewModel.txtExceptDay.Text = "";
			ViewModel.txtState.Text = "";
			ViewModel.txtStep.Text = "";
			ViewModel.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(0);
			ViewModel.picEmp.Visible = false;
			ViewModel.lbExit.Visible = false;
			ViewModel.lbExitType.Visible = false;
			ViewModel.txtExit.Visible = false;
			ViewModel.txtExit.Text = "";
			ViewModel.cboExitType.Visible = false;
			ViewModel.cboExitType.SelectedIndex = -1;
			ViewModel.cboExitType.Text = "";
			ViewModel.lbExitComments.Visible = false;
			ViewModel.txtExitComments.Visible = false;
			ViewModel.txtExitComments.Text = "";
			ViewModel.lbUnion.Visible = true;
			ViewModel.txtUnion.Visible = true;
			ViewModel.chkStatus.Visible = true;
			ViewModel.lbStatus.Visible = true;
			ViewModel.lbStep.Visible = true;
			ViewModel.txtStep.Visible = true;
			ViewModel.lbWarning.Visible = false;
			ViewModel.txtWDL.Text = "";
			ViewModel.txtWDLDate.Text = "";
			ViewModel.lbVerified.Visible = false;
			ViewModel.lbVerified.Text = "";
			ViewModel.cmdVerify.Enabled = false;
			ViewModel.txtCostCenter.Text = "";
			ViewModel.cmdChangeCC.Visible = false;
			ViewModel.cmdChangeCC.Tag = "0";
			ViewModel.cmdChangeCC.Text = "Cost Center";
			ViewModel.txtCostCenter.Enabled = false;
			ViewModel.iLicenseID = 0;
			ViewModel.sLicenseNumber = "";
			ViewModel.dLicenseExpDate = "";
			ViewModel.dVerifyDate = "";
			ViewModel.sVerifyBy = "";
			ViewModel.lPersSysID = 0;

		}

		public void FillNameList()
		{
			//Fill Employee Name List

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";

			try
			{

				frmUpdate.DefInstance.ViewModel.cboEmpList.Items.Clear();

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				switch(modGlobal.Shared.gSecurity)
				{
					case "HAZ" :
						oCmd.CommandText = "sp_FillXList 'HZM'";
						break;
					case "ADM" : case "PER" :
						if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
						{
							oCmd.CommandText = "spFullNameList";
						}
						else if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "2")
						{
							oCmd.CommandText = "spArchiveNameList";
						}
						break;
					case "BAT" : case "AID" :
						oCmd.CommandText = "spOpNameList";
						break;
					default:
						oCmd.CommandText = "sp_FillXList '" + modGlobal.Shared.gSecurity + "'";
						break;
				}
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					strName = modGlobal.Clean(oRec["name_full"]) + "  :" + Convert.ToString(oRec["employee_id"]);
					frmUpdate.DefInstance.ViewModel.cboEmpList.AddItem(strName);
					if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "2")
					{
						frmUpdate.DefInstance.ViewModel.cboEmpList.SetItemData(frmUpdate.DefInstance.ViewModel.cboEmpList.GetNewIndex(), Convert.ToInt32(oRec["per_archive_id"]));
															//TODO tempNormalized6.SetItemData(tempNormalized10, Convert.ToInt32(oRec["per_archive_id"]));
					}
					oRec.MoveNext();
				};
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		public void DisplayRecord()
		{
			//Retrieve and Display Employee Record
			//for Selected Employee

			string Empid = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			int ArcID = 0;

			try
			{
				//Come Here - for employee id change
				Empid = frmUpdate.DefInstance.ViewModel.cboEmpList.Text.Substring(Math.Max(frmUpdate.DefInstance.ViewModel.cboEmpList.Text.Length - 5, 0));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (Strings.Len(Empid) < 5 || Convert.IsDBNull(Empid) || Empid == "")
				{
					return;
				}
				else
				{
					modGlobal.Shared.gAssignID = Empid;
				}

				// Load Employee Photo if exists
				ViewModel.picEmp.Visible = true;
				if (FileSystem.Dir(modGlobal.PICTUREPATH + Empid + ".bmp", FileAttribute.Normal) != "")
				{
				}
				else
				{
					ViewModel.picEmp.Visible = false;
				}

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
				{
					oCmd.CommandText = "sp_GetPersonnelDetail '" + Empid + "'";
				}
				else if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "2")
				{
					ArcID = frmUpdate.DefInstance.ViewModel.cboEmpList.GetItemData(frmUpdate.DefInstance.ViewModel.cboEmpList.SelectedIndex);
										//TODO async2.Append<System.Int32, System.Int32>(tempNormalized9 => tempNormalized6.GetItemData(tempNormalized9));
					oCmd.CommandText = "sp_GetArcPersonnelDetail " + ArcID.ToString();
				}
				else
				{
					oCmd.CommandText = "sp_GetPersonnelDetail '" + Empid + "'";
				}
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//Test to determine that a record was retrieved
				if (oRec.EOF)
				{
					ViewManager.ShowMessage("There was a problem retrieving this Employees record", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
					return;
				}

				//Fill Personnel record form fields
				frmUpdate.DefInstance.ViewModel.txtFName.Text = modGlobal.Clean(oRec["name_first"]);
				frmUpdate.DefInstance.ViewModel.txtMName.Text = modGlobal.Clean(oRec["name_middle_initial"]);
				frmUpdate.DefInstance.ViewModel.txtLName.Text = modGlobal.Clean(oRec["name_last"]);
				frmUpdate.DefInstance.ViewModel.lbEmpID.Text = Convert.ToString(oRec["employee_id"]);
				ViewModel.txtSName.Text = modGlobal.Clean(oRec["name_suffix"]);
				ViewModel.txtNameKnownBy.Text = modGlobal.Clean(oRec["nameknownby"]);
				System.DateTime TempDate = DateTime.FromOADate(0);
				ViewModel.txtBDay.Text = (DateTime.TryParse(modGlobal.Clean(oRec["birthdate"]), out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Clean(oRec["birthdate"]);
				ViewModel.txtPhone.Text = modGlobal.Clean(oRec["home_phone"]);
				ViewModel.txtSex.Text = modGlobal.Clean(oRec["sex"]);
				ViewModel.txtAddress.Text = modGlobal.Clean(oRec["address_full"]);
				ViewModel.txtCity.Text = modGlobal.Clean(oRec["city"]);
				ViewModel.txtState.Text = modGlobal.Clean(oRec["state"]);
				ViewModel.txtZip.Text = modGlobal.Clean(oRec["zip_code"]);
				ViewModel.txtSSN.Text = modGlobal.Clean(oRec["social_security_nbr"]);
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				ViewModel.txtCOT.Text = (DateTime.TryParse(modGlobal.Clean(oRec["COT_hire_date"]), out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : modGlobal.Clean(oRec["COT_hire_date"]);
				System.DateTime TempDate3 = DateTime.FromOADate(0);
				ViewModel.txtTFD.Text = (DateTime.TryParse(modGlobal.Clean(oRec["TFD_hire_date"]), out TempDate3)) ? TempDate3.ToString("M/d/yyyy") : modGlobal.Clean(oRec["TFD_hire_date"]);
				ViewModel.txtExceptDay.Text = modGlobal.Clean(oRec["exception_days"]);

				switch(modGlobal.Clean(oRec["benefit_program"]))
				{
					case "COT" :
						ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(0);
						break;
					case "CF1" :
						ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(1);
						break;
					case "CF2" :
						ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(2);
						break;
					default:
						ViewModel.cboBenefit.SelectedIndex = -1;
						break;
				}

				//Different Fields for Current/Archived Personnel
				string sText = "";
				if (Convert.ToString(ViewModel.cmdSwitch.Tag) != "2")
				{
					//Current Personnel
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.lPersSysID = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));
					ViewModel.cmdChangeCC.Visible = true;
					ViewModel.cmdChangeCC.Enabled = modGlobal.Shared.gSecurity == "ADM";
					ViewModel.txtCostCenter.Visible = true;
					//        lblCostCenter.Visible = True
					ViewModel.txtWDL.Visible = true;
					ViewModel.txtWDLDate.Visible = true;
					ViewModel.cmdVerify.Visible = true;
					ViewModel.cmdVerify.Enabled = true;
					ViewModel.Label23.Visible = true;
					ViewModel.lbVerified.Visible = true; //not ready yet

					ViewModel.txtCostCenter.Text = modGlobal.Clean(oRec["cost_center"]);
					ViewModel.txtWDL.Text = modGlobal.Clean(oRec["license_number"]);
					System.DateTime TempDate4 = DateTime.FromOADate(0);
					ViewModel.txtWDLDate.Text = (DateTime.TryParse(modGlobal.Clean(oRec["expiration_date"]), out TempDate4)) ? TempDate4.ToString("M/d/yyyy") : modGlobal.Clean(oRec["expiration_date"]);
					if ( ViewModel.txtWDL.Text != "")
					{

						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.iLicenseID = Convert.ToInt32(modGlobal.GetVal(oRec["license_id"]));
						ViewModel.sLicenseNumber = ViewModel.txtWDL.Text;
						if ( ViewModel.txtWDLDate.Text != "")
						{
							ViewModel.dLicenseExpDate = ViewModel.txtWDLDate.Text;
						}
						sText = "";
						if (modGlobal.Clean(oRec["CheckedBy"]) != "")
						{
							sText = "Last Verified by " + modGlobal.Clean(oRec["CheckedBy"]).Trim();
							if (modGlobal.Clean(oRec["last_checked_date"]) != "")
							{
								System.DateTime TempDate5 = DateTime.FromOADate(0);
								sText = sText + " on " + ((DateTime.TryParse(modGlobal.Clean(oRec["last_checked_date"]), out TempDate5)) ? TempDate5.ToString("M/d/yyyy") : modGlobal.Clean(oRec["last_checked_date"]));
							}
						}
						ViewModel.lbVerified.Text = sText;
					}
					ViewModel.txtUnion.Text = modGlobal.Clean(oRec["union_code"]);
					ViewModel.txtStep.Text = modGlobal.Clean(oRec["step"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["job_code_id"]))
					{
						ViewModel.lbJobCode.Text = Convert.ToString(oRec["job_code_id"]);
						for (int i = 0; i <= ViewModel.cboJobCode.Items.Count - 1; i++)
						{
							if ( ViewModel.cboJobCode.GetListItem(i).Substring(Math.Max(ViewModel.cboJobCode.GetListItem(i).Length - 5, 0)) == Convert.ToString(oRec["job_code_id"]))
							{
								ViewModel.cboJobCode.SelectedIndex = i;
								break;
							}
						}
					}
					else
					{
						ViewModel.lbJobCode.Text = "";
						ViewModel.cboJobCode.Text = (ViewModel.cboJobCode.SelectedIndex == -1).ToString();
					}

					if (Convert.ToBoolean(oRec["status"]))
					{
						ViewModel.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkStatus.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
				}
				else
				{
					//Archived Personnel
					ViewModel.lPersSysID = 0;
					ViewModel.lbPerArcID.Text = Convert.ToString(oRec["per_archive_id"]);
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if (!Convert.IsDBNull(oRec["last_job_code"]))
					{
						ViewModel.lbJobCode.Text = Convert.ToString(oRec["last_job_code"]);
						for (int i = 0; i <= ViewModel.cboJobCode.Items.Count - 1; i++)
						{
							if ( ViewModel.cboJobCode.GetListItem(i).Substring(Math.Max(ViewModel.cboJobCode.GetListItem(i).Length - 5, 0)) == Convert.ToString(oRec["last_job_code"]))
							{
								ViewModel.cboJobCode.SelectedIndex = i;
								break;
							}
						}
					}
					else
					{
						ViewModel.lbJobCode.Text = "";
						ViewModel.cboJobCode.Text = (ViewModel.cboJobCode.SelectedIndex == -1).ToString();
					}

					//don't show the following fields
					ViewModel.txtWDL.Visible = false;
					ViewModel.txtWDLDate.Visible = false;
					ViewModel.cmdVerify.Visible = false;
					ViewModel.Label23.Visible = false;
					ViewModel.lbVerified.Visible = false;
					ViewModel.txtCostCenter.Visible = false;
					//        lblCostCenter.Visible = False
					ViewModel.cmdChangeCC.Visible = false;
					ViewModel.lbUnion.Visible = false;
					ViewModel.txtUnion.Visible = false;
					ViewModel.lbStep.Visible = false;
					ViewModel.txtStep.Visible = false;
					ViewModel.chkStatus.Visible = false;
					ViewModel.lbStatus.Visible = false;
					//**************************
					ViewModel.lbExit.Visible = true;
					System.DateTime TempDate6 = DateTime.FromOADate(0);
					ViewModel.txtExit.Text = (DateTime.TryParse(modGlobal.Clean(oRec["TFD_leave_date"]), out TempDate6)) ? TempDate6.ToString("M/d/yyyy") : modGlobal.Clean(oRec["TFD_leave_date"]);
					ViewModel.txtExit.Visible = true;
					ViewModel.lbExitType.Visible = true;
					ViewModel.cboExitType.Visible = true;
					switch(modGlobal.Clean(oRec["leave_status"]))
					{
						case "RT" :
							ViewModel.cboExitType.Text = ViewModel.cboExitType.GetListItem(0);
							break;
						case "TR" :
							ViewModel.cboExitType.Text = ViewModel.cboExitType.GetListItem(1);
							break;
						case "QT" :
							ViewModel.cboExitType.Text = ViewModel.cboExitType.GetListItem(2);
							break;
						case "TM" :
							ViewModel.cboExitType.Text = ViewModel.cboExitType.GetListItem(3);
							break;
						default:
							ViewModel.cboExitType.Text = ViewModel.cboExitType.GetListItem(-1);
							break;
					}
					ViewModel.lbExitComments.Visible = true;
					ViewModel.txtExitComments.Visible = true;
					ViewModel.txtExitComments.Text = modGlobal.Clean(oRec["comment"]);


				}
				ViewModel.lbWarning.Visible = ViewModel.cboJobCode.SelectedIndex == -1 && modGlobal.Clean(ViewModel.lbJobCode.Text) != "";
				ViewManager.SetCurrent(ViewModel.txtFName);
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
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Employee selected
			ClearForm();
			DisplayRecord();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Set Job Code label with selected Job Title


			if ( ViewModel.cboJobCode.SelectedIndex < 0)
			{
				return;
			}
			string sJobCode = ViewModel.cboJobCode.GetListItem(ViewModel.cboJobCode.SelectedIndex).Substring(Math.Max(ViewModel.cboJobCode.GetListItem(ViewModel.cboJobCode.SelectedIndex).Length - 5, 0));

			//    sJobCode = Right$(cboJobCode.Text, 5)
			ViewModel.lbJobCode.Text = sJobCode;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddress_Click(Object eventSender, System.EventArgs eventArgs)
		{
			// MsgBox "This is currently under construction !", vbOKOnly, "Additional Addresses"

			modGlobal
				.Shared.gAssignID = ViewModel.lbEmpID.Text;
			ViewManager.NavigateToView(
				frmAddress.DefInstance);
			/*			frmAddress.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Open frmAssign - pass currently selected employee_id

			modGlobal
				.Shared.gAssignID = ViewModel.lbEmpID.Text;
			ViewManager.NavigateToView(
				frmAssign.DefInstance);
			/*			frmAssign.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdChangeCC_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//int resp = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if (Convert.ToString(ViewModel.cmdChangeCC.Tag) == "0")
			{
				ViewModel.txtCostCenter.Enabled = true;
				if (modGlobal.Clean(ViewModel.txtCostCenter.Text) == "")
				{
					ViewModel.cmdChangeCC.Text = "Add";
				}
				else
				{
					ViewModel.cmdChangeCC.Text = "Update";
				}
				ViewModel.cmdChangeCC.Tag = "1";
				return;
			}

			//field edits
			if ( ViewModel.lPersSysID == 0)
			{
				ViewManager.ShowMessage("Changing the Cost Center is not possible, please select the employee again.", "Cost Center Change", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			if (modGlobal.Clean(ViewModel.txtCostCenter.Text) == "")
			{
				ViewManager.ShowMessage("You need to enter a Cost Center for this employee.", "Cost Center Change", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			//Add Insert/Update logic here
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "";

			if ( ViewModel.cmdChangeCC.Text == "Add")
			{
				oCmd.CommandText = "spInsert_PersonnelCostCenter " + ViewModel.lPersSysID.ToString() + ", '" +
								modGlobal.Clean(ViewModel.txtCostCenter.Text) + "' ";
			}
			else
			{
				oCmd.CommandText = "spUpdate_PersonnelCostCenter " + ViewModel.lPersSysID.ToString() + ", '" +
								modGlobal.Clean(ViewModel.txtCostCenter.Text) + "' ";
			}
			oCmd.ExecuteNonQuery();

			oCmd.CommandText = "spSelect_PersonnelCostCenterByPerSysID " + ViewModel.lPersSysID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (oRec.EOF)
			{
				ViewManager.ShowMessage("ooops! Something is wrong!  Call Debra Lewandowsky x5068!", "Selecting Cost Center", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewModel.txtCostCenter.Text = modGlobal.Clean(oRec["cost_center"]);
				ViewManager.ShowMessage("Cost Center has been changed.", "Change Cost Center Successful", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			ViewModel.cmdChangeCC.Tag = "0";
			ViewModel.cmdChangeCC.Text = "Cost Center";
			ViewModel.txtCostCenter.Enabled = false;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close Update Personnel form
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Delete Currently Selected Employee
				//User strongly warned of severity of this action
				//All related Leave, Schedule and Promotion records
				//also deleted

				//const int sEmpID = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				string NameWork = "";
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				string Msg = "";

				try
				{
					{

						//Warn user about severity of Delete action

						Msg = "Deleting this Employee will permanately remove Personnel data and all associated" + "\r";
						Msg = Msg + "Schedule, Leave and Promotion Records!" + "\r";
						Msg = Msg + "If employee has transfered or quit you should uncheck Active Status!" + "\r";
						Msg = Msg + "Would you like to cancel Delete request?";
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(Msg, "Delete Employee Warning", UpgradeHelpers.Helpers.BoxButtons.YesNo));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{

								Response = tempNormalized1;
							});
						async1.Append(() =>
							{
								if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
								{
									this.Return();
									return ;
								}

								//Format full name for Delete Complete Message
								NameWork = modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtLName.Text));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(ViewModel.txtSName.Text) && Strings.Len(ViewModel.txtSName.Text) > 0)
								{
									NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtSName.Text);
								}
								NameWork = NameWork + "," + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
								if (!Convert.IsDBNull(ViewModel.txtMName.Text) && Strings.Len(ViewModel.txtMName.Text) > 0)
								{
									NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtMName.Text) + ".";
								}

								//Call spDeletePersonnel stored procedure
								//this sp will delete Personnel, Leave, Schedule & Promotion
								//records for specified employee_id
								oCmd.Connection = modGlobal.oConn;
								oCmd.CommandType = CommandType.Text;
								if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
								{
									oCmd.CommandText = "spDeletePersonnel '" + ViewModel.lbEmpID.Text + "'";
								}
								else
								{
									oCmd.CommandText = "spDeleteArcPersonnel '" + ViewModel.lbEmpID.Text + "'";
								}
								oCmd.ExecuteNonQuery();

								if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
								{
									oCmd.CommandText = "spDeletePersonnelByPerSysID " + ViewModel.lPersSysID.ToString() + " ";
								}

								//Refresh Name List and clear form fields
								FillNameList();
								ClearForm();
								ViewManager.ShowMessage(NameWork + " successfully Deleted", "Update Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdEmergency_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(

				frmEmergencyContact.DefInstance);
			/*			frmEmergencyContact.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewPromo_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//Open New Promotion Form
			//pass currently selected employee_id

			if (modGlobal.Shared.gAssignID == "")
			{
				ViewManager.ShowMessage("You must select an Employee first!", "New Promotion Request", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewManager.NavigateToView(

				frmNewPromo.DefInstance);
			/*			frmNewPromo.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNote_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gAssignID = ViewModel.lbEmpID.Text;
			ViewManager.NavigateToView(

				frmEmployeeNotes.DefInstance);
			/*			frmEmployeeNotes.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPhone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPhone.DefInstance);
			/*			frmPhone.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSwitch_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Change from Current to Archived Personnel
			if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
			{
				ViewModel.cmdSwitch.Tag = "2";
				ViewModel.cmdSwitch.Text = "&View Current Personnel";
				ClearForm();
				FillNameList();
				ViewModel.cmdAssign.Enabled = false;
				ViewModel.cmdNewPromo.Enabled = false;
				ViewModel.cmdPhone.Enabled = false;
				ViewModel.cmdPhone.Visible = false;
				ViewModel.cmdEmergency.Enabled = false;
				ViewModel.cmdEmergency.Visible = false;
				ViewModel.cmdAddress.Enabled = false;
				ViewModel.cmdAddress.Visible = false;
				ViewModel.txtWDL.Visible = false;
				ViewModel.txtWDLDate.Visible = false;
				ViewModel.cmdVerify.Visible = false;
				ViewModel.Label23.Visible = false;
				ViewModel.lbVerified.Visible = false; //not ready yet
			}
			else
			{
				ViewModel.cmdSwitch.Tag = "1";
				ViewModel.cmdSwitch.Text = "&View Archived Personnel";
				ClearForm();
				FillNameList();
				ViewModel.cmdAssign.Enabled = true;
				ViewModel.cmdNewPromo.Enabled = true;
				ViewModel.cmdPhone.Enabled = true;
				ViewModel.cmdPhone.Visible = true;
				ViewModel.cmdEmergency.Enabled = true;
				ViewModel.cmdEmergency.Visible = true;
				ViewModel.cmdAddress.Enabled = true;
				ViewModel.cmdAddress.Visible = true;
				ViewModel.txtWDL.Visible = true;
				ViewModel.txtWDLDate.Visible = true;
				ViewModel.cmdVerify.Visible = true;
				ViewModel.Label23.Visible = true;
				ViewModel.lbVerified.Visible = false; //not ready yet
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUndo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Refresh form to cancel any changes to form controls
			ClearForm();
			DisplayRecord();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{

				//Update Employee Information
				//Form data is checked for required fields and field lengths
				//SQLServer spUpdatePersonnel stored procedure is called to update record
				//If Status has been unchecked, Archive this Employees Personnel Records

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				byte Status = 0;
				string NameWork = "";
				string strSQL = "";
				string LeaveStatus = "";
				int ArcID = 0;
				string str1 = "", str2 = "";
				int i = 0;
				System.DateTime TestDate = DateTime.FromOADate(0);
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;

				try
				{
					{

						if ( ViewModel.cboJobCode.SelectedIndex < 0)
						{
							ViewManager.ShowMessage("Please select a Job Title/Code from the list.", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.cboJobCode);
							this.Return();
							return ;
						}

						//Edit Name Fields
						if (modGlobal.Clean(ViewModel.txtFName.Text) == "")
						{
							ViewManager.ShowMessage("First Name must be entered", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtFName);
							ViewModel.txtFName.SelectionStart = 0;
							ViewModel.txtFName.SelectionLength = Strings.Len(ViewModel.txtFName.Text);
							this.Return();
							return ;
						}

						if (modGlobal.Clean(ViewModel.txtLName.Text) == "")
						{
							ViewManager.ShowMessage("Last Name must be entered", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtLName);
							ViewModel.txtLName.SelectionStart = 0;
							ViewModel.txtLName.SelectionLength = Strings.Len(ViewModel.txtLName.Text);
							this.Return();
							return ;
						}
						ViewModel.txtNameKnownBy.Text = modGlobal.Clean(ViewModel.txtNameKnownBy.Text);

						//Edit Sex
						if ( ViewModel.txtSex.Text == "M" || ViewModel.txtSex.Text == "F")
						{
							//Sex field OK
						}
						else
						{
							ViewManager.ShowMessage("Sex must be M or F", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtSex);
							ViewModel.txtSex.SelectionStart = 0;
							ViewModel.txtSex.SelectionLength = Strings.Len(ViewModel.txtSex.Text);
							this.Return();
							return ;
						}

						if (modGlobal.Clean(ViewModel.txtSSN.Text) != "")
						{
							if (Strings.Len(ViewModel.txtSSN.Text) < 11)
							{
								ViewManager.ShowMessage("Please format SSN (###-##-####).", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
								ViewManager.SetCurrent(ViewModel.txtSSN);
								ViewModel.txtSSN.SelectionStart = 0;
								ViewModel.txtSSN.SelectionLength = Strings.Len(ViewModel.txtSSN.Text);
								this.Return();
								return ;
							}
						}

						//Edit Date Fields
						if (Information.IsDate(ViewModel.txtBDay.Text))
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtBDay.Text).ToString("M/d/yyyy"));
							if (TestDate > DateTime.Now)
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
										.ShowMessage("Birthdate is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
									{
										Response = tempNormalized1;
									});
								async1.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.No)
										{
											ViewManager.ShowMessage("Please Correct Birthdate using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
											ViewManager.SetCurrent(ViewModel.txtCOT);
											ViewModel.txtCOT.SelectionStart = 0;
											ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtBDay.Text);
											this.Return();
											return ;
										}
									});
									}
									else
									{
								//Birthdate OK
								ViewModel.txtBDay.Text = DateTime.Parse(ViewModel.txtBDay.Text).ToString("M/d/yyyy");
							}
						}
						else
						{
							ViewManager.ShowMessage("Birthday is invalid", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtBDay);
							ViewModel.txtBDay.SelectionStart = 0;
							ViewModel.txtBDay.SelectionLength = Strings.Len(ViewModel.txtBDay.Text);
							this.Return();
							return ;
						}

						if (Information.IsDate(ViewModel.txtCOT.Text))
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtCOT.Text).ToString("M/d/yyyy"));
							if (TestDate > DateTime.Now)
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("COT Service Date is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
									{
										Response = tempNormalized3;
									});
								async1.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.No)
										{
											ViewManager.ShowMessage("Please Correct COT Service Date using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
											ViewManager.SetCurrent(ViewModel.txtCOT);
											ViewModel.txtCOT.SelectionStart = 0;
											ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtCOT.Text);
											this.Return();
											return ;
										}
									});
									}
									else
									{
								//COT Service date OK
								ViewModel.txtCOT.Text = DateTime.Parse(ViewModel.txtCOT.Text).ToString("M/d/yyyy");
							}
						}
						else
						{
							ViewManager.ShowMessage("COT Service Date is invalid", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtCOT);
							ViewModel.txtCOT.SelectionStart = 0;
							ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtCOT.Text);
							this.Return();
							return ;
						}

						if (Information.IsDate(ViewModel.txtTFD.Text))
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtTFD.Text).ToString("M/d/yyyy"));
							if (TestDate > DateTime.Now)
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("TFD Hire Date is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
									{
										Response = tempNormalized5;
									});
								async1.Append(() =>
									{
										if (Response == UpgradeHelpers.Helpers.DialogResult.No)
										{
											ViewManager.ShowMessage("Please Correct TFD Hire Date using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
											ViewManager.SetCurrent(ViewModel.txtCOT);
											ViewModel.txtCOT.SelectionStart = 0;
											ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtTFD.Text);
											this.Return();
											return ;
										}
									});
									}
									else
									{
								//TFD hire date OK
								ViewModel.txtTFD.Text = DateTime.Parse(ViewModel.txtTFD.Text).ToString("M/d/yyyy");
							}
						}
						else
						{
							ViewManager.ShowMessage("TFD Hire Date is invalid", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtTFD);
							ViewModel.txtTFD.SelectionStart = 0;
							ViewModel.txtTFD.SelectionLength = Strings.Len(ViewModel.txtTFD.Text);
							this.Return();
							return ;
						}

						//Archive Edits
						if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "2")
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if (Information.IsDate(ViewModel.txtExit.Text))
							{
								TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtExit.Text).ToString("M/d/yyyy"));
								if (TestDate > DateTime.Now)
								{
									async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
											ViewManager.ShowMessage("Exit Date is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
									async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized6 => tempNormalized6);
									async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized7 =>
										{
											Response = tempNormalized7;
										});
									async1.Append(() =>
										{
											if (Response == UpgradeHelpers.Helpers.DialogResult.No)
											{
												ViewManager.ShowMessage("Please Correct Exit Date using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
												ViewManager.SetCurrent(ViewModel.txtCOT);
												ViewModel.txtCOT.SelectionStart = 0;
												ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtExit.Text);
												this.Return();
												return ;
											}
										});
										}
										else
										{
									//TFD hire date OK
									ViewModel.txtExit.Text = DateTime.Parse(ViewModel.txtExit.Text).ToString("M/d/yyyy");
								}
							}
							else if (Convert.IsDBNull(ViewModel.txtExit.Text) || ViewModel.txtExit.Text == "")
							{
								//TFD Exit date blank
							}
							else
							{
								ViewManager.ShowMessage("TFD Exit Date is invalid", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtExit);
								ViewModel.txtExit.SelectionStart = 0;
								ViewModel.txtExit.SelectionLength = Strings.Len(ViewModel.txtExit.Text);
								this.Return();
								return ;
							}
							async1.Append(() =>
								{
									ArcID = Convert.ToInt32(Conversion.Val(ViewModel.lbPerArcID.Text));
									switch( ViewModel.cboExitType.Text)
									{
										case "Retirement" :
											LeaveStatus = "RT";
											break;
										case "Transfer" :
											LeaveStatus = "TR";
											break;
										case "Resignation" :
											LeaveStatus = "QT";
											break;
										case "Termination" :
											LeaveStatus = "TM";
											break;
										default:
											LeaveStatus = "";
											break;
									}

									while((ViewModel.txtExitComments.Text.IndexOf('\'') + 1) != 0)
									{
										i = (ViewModel.txtExitComments.Text.IndexOf('\'') + 1);
										str1 = ViewModel.txtExitComments.Text.Substring(0, Math.Min(i - 1, ViewModel.txtExitComments.Text.Length));
										str2 = ViewModel.txtExitComments.Text.Substring(Math.Max(ViewModel.txtExitComments.Text.Length - (Strings.Len(ViewModel.txtExitComments.Text) - i), 0));
										ViewModel.txtExitComments.Text = str1 + "-" + str2;
									};
									ViewModel.txtExitComments.Text = ViewModel.txtExitComments.Text.Substring(0, Math.Min(255, ViewModel.txtExitComments.Text.Length));
								});
						}
						else
						{
							//Current Personnel Only Edits
							//Insert Logic to edit for valid step for current job_code_id
							double dbNumericTemp = 0;
							if (!Double.TryParse(ViewModel.txtStep.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
							{
								ViewManager.ShowMessage("Invalid Step", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtStep);
								ViewModel.txtStep.SelectionStart = 0;
								ViewModel.txtStep.SelectionLength = Strings.Len(ViewModel.txtStep.Text);
								this.Return();
								return ;
							}
						}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									double dbNumericTemp2 = 0;
									if (!Double.TryParse(ViewModel.txtExceptDay.Text, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
										if (Convert.IsDBNull(ViewModel.txtExceptDay.Text) || ViewModel.txtExceptDay.Text == "")
										{
											ViewModel.txtExceptDay.Text = "0";
										}
										else
										{
											ViewManager.ShowMessage("Exception Days must be numeric", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
											ViewManager.SetCurrent(ViewModel.txtExceptDay);
											ViewModel.txtExceptDay.SelectionStart = 0;
											ViewModel.txtExceptDay.SelectionLength = Strings.Len(ViewModel.txtExceptDay.Text);
											this.Return();
											return ;
										}
									}

									//Format name_full field
									NameWork = modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtLName.Text));
									if (modGlobal.Clean(ViewModel.txtSName.Text) != "")
									{
										NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtSName.Text);
									}
									NameWork = NameWork + ", " + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text));
									if (modGlobal.Clean(ViewModel.txtMName.Text) != "")
									{
										NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtMName.Text) + ".";
									}

									//Edits ok, update record
									if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "1")
									{
										if (((int)ViewModel.chkStatus.CheckState) == ((int)UpgradeHelpers.Helpers.CheckState.Checked))
										{
											Status = 1;
										}
										else
										{
											Status = 0;
										}
									}
									else if (Convert.ToString(ViewModel.cmdSwitch.Tag) == "3")
									{
										Status = 1;
									}

									if (Convert.ToString(ViewModel.cmdSwitch.Tag) != "2")
									{
										strSQL = "spUpdatePersonnel '";
										strSQL = strSQL + modGlobal.Clean(ViewModel.lbEmpID.Text) + "','" + modGlobal.Clean(ViewModel.lbJobCode.Text) + "'," + Conversion.Val(ViewModel.txtStep.Text).ToString() + ",'";
										strSQL = strSQL + modGlobal.Clean(NameWork) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(
															ViewModel.txtLName.Text)) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text)) + "','";
										strSQL = strSQL + modGlobal.Clean(ViewModel.txtMName.Text) + "','" + modGlobal.Clean(ViewModel.txtSName.Text) + "','" + ViewModel.txtSex.Text + "','";
										strSQL = strSQL + ViewModel.txtSSN.Text + "','" + ViewModel.txtUnion.Text + "','" + ViewModel.cboBenefit.Text + "','";
										strSQL = strSQL + Strings.Replace(ViewModel.txtAddress.Text, "'", "''", 1, -1, CompareMethod
													.Binary) + "','" + ViewModel.txtCity.Text + "','" + ViewModel.txtState.Text + "','" + ViewModel.txtZip.Text + "','";
										strSQL = strSQL + ViewModel.txtPhone.Text + "','" + ViewModel.txtBDay.Text + "','" + ViewModel.txtCOT.Text + "','";
										strSQL = strSQL + ViewModel.txtTFD.Text + "'," + Conversion.Val(ViewModel.txtExceptDay.Text).ToString() + ",'" + DateTime.Now.ToString("M/d/yyyy");
										strSQL = strSQL + "'," + Status.ToString() + ",'" + ViewModel.txtNameKnownBy.Text + "'";
									}
									else
									{
										strSQL = "spUpdateArcPersonnel " + ArcID.ToString() + ",'";
										strSQL = strSQL + ViewModel.lbJobCode.Text + "','";
										strSQL = strSQL + modGlobal.Clean(NameWork) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(
															ViewModel.txtLName.Text)) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text)) + "','";
										strSQL = strSQL + modGlobal.Clean(ViewModel.txtMName.Text) + "','" + modGlobal.Clean(ViewModel.txtSName.Text) + "','" + ViewModel.txtSex.Text + "','";
										strSQL = strSQL + ViewModel.txtSSN.Text + "','" + ViewModel.cboBenefit.Text + "','";
										strSQL = strSQL + Strings.Replace(ViewModel.txtAddress.Text, "'", "''", 1, -1, CompareMethod.Binary) + "','" + ViewModel.txtCity.Text + "','";
										strSQL = strSQL + ViewModel.txtState.Text + "','" + ViewModel.txtZip.Text + "','";
										strSQL = strSQL + ViewModel.txtPhone.Text + "','" + ViewModel.txtBDay.Text + "','" + ViewModel.txtCOT.Text + "','";
										strSQL = strSQL + ViewModel.txtTFD.Text + "','" + ViewModel.txtExit.Text + "','" + LeaveStatus + "',";
										strSQL = strSQL + Conversion.Val(ViewModel.txtExceptDay.Text).ToString() + ",'" + ViewModel.txtExitComments.Text + "'";
									}



									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;
									oCmd.CommandText = strSQL;
									oCmd.ExecuteNonQuery();
									if (Convert.ToString(ViewModel.cmdSwitch.Tag) != "2")
									{
										if (((int)ViewModel.chkStatus.CheckState) == ((int)UpgradeHelpers.Helpers.CheckState.Unchecked))
										{
											//Archive this Employees Personnel records
											modGlobal
												.Shared.gTransCancel = -1;
											ViewManager.DisposeView(
												dlgArcPersonnel.DefInstance);
											async2.Append(() =>
												{
													ViewManager.NavigateToView(
														dlgArcPersonnel.DefInstance, true);
												});
											async2.Append(() =>
												{
													if (modGlobal.Shared.gTransCancel != 0)
													{
														Status = 1;
														strSQL = "spUpdatePersonnel '";
														strSQL = strSQL + modGlobal.Clean(ViewModel.lbEmpID.Text) + "','" + modGlobal.Clean(ViewModel.lbJobCode.Text) + "'," + Conversion.Val(ViewModel.txtStep.Text).ToString() + ",'";
														strSQL = strSQL + modGlobal.Clean(NameWork) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(
																			ViewModel.txtLName.Text)) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text)) + "','";
														strSQL = strSQL + modGlobal.Clean(ViewModel.txtMName.Text) + "','" + modGlobal.Clean(ViewModel.txtSName.Text) + "','" + ViewModel.txtSex.Text + "','";
														strSQL = strSQL + ViewModel.txtSSN.Text + "','" + ViewModel.txtUnion.Text + "','" + ViewModel.cboBenefit.Text + "','";
														strSQL = strSQL + Strings.Replace(ViewModel.txtAddress.Text, "'", "''", 1, -1, CompareMethod
																	.Binary) + "','" + ViewModel.txtCity.Text + "','" + ViewModel.txtState.Text + "','" + ViewModel.txtZip.Text + "','";
														strSQL = strSQL + ViewModel.txtPhone.Text + "','" + ViewModel.txtBDay.Text + "','" + ViewModel.txtCOT.Text + "','";
														strSQL = strSQL + ViewModel.txtTFD.Text + "'," + Conversion.Val(ViewModel.txtExceptDay.Text).ToString() + ",'" + DateTime.Now.ToString("M/d/yyyy");
														strSQL = strSQL + "'," + Status.ToString() + ",'" + ViewModel.txtNameKnownBy.Text + "'";
														oCmd.CommandText = strSQL;
														oCmd.ExecuteNonQuery();
														ClearForm();
														DisplayRecord();
													}
													else
													{
														ArcID = GetNewID(ViewModel.lbEmpID.Text);
														if (ArcID == 0)
														{
															ViewManager.ShowMessage("Unable to Archive Employee's Records.  Please Contact System Programmer.", "Update Employee", UpgradeHelpers
																.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
															this.Return();
															return ;
														}
														oCmd.CommandText = "spArchivePersonnel '" + ViewModel.lbEmpID.Text + "'," + ArcID.ToString() + ",'"
																	+ modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gAssignID + "','" + modGlobal.Shared.gDetailEmp + "'";
														oCmd.ExecuteNonQuery();
														oCmd.CommandText = "spArchivePromotions " + ArcID.ToString();
														oCmd.ExecuteNonQuery();
														oCmd.CommandText = "spDeletePersonnel_forArchive '" + ViewModel.lbEmpID.Text + "'";
														oCmd.ExecuteNonQuery();
														oCmd.CommandText = "spDeletePersonnelByPerSysID_forArchive " + ViewModel.lPersSysID.ToString() + " ";
														oCmd.ExecuteNonQuery();
														NameWork = modGlobal.Clean(ViewModel.txtLName.Text) + ", " + modGlobal.Clean(ViewModel.txtFName.Text);
														FillNameList();
														ClearForm();
														ViewManager.ShowMessage(NameWork + " successfully Archived", "Update Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
													}
												});
												}
												else
												{
													NameWork = modGlobal.Clean(ViewModel.txtLName.Text) + ", " + modGlobal.Clean(ViewModel.txtFName.Text);
											ViewManager.ShowMessage(NameWork + " successfully Updated", "Update Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
										}
									}
									else
									{
										NameWork = modGlobal.Clean(ViewModel.txtLName.Text) + ", " + modGlobal.Clean(ViewModel.txtFName.Text);
										ViewManager.ShowMessage(NameWork + " successfully Updated", "Update Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
									}
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdVerify_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmNewPPEWDL.DefInstance);
			/*			frmNewPPEWDL.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		public void Form_Load()
		{

			//Load Update Employee Form
			//Fill Benefit List and Job Title List
			//Set RDO environment and connection properties for data access

			string strName = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				//Fill Benefit Combo Box list
				ViewModel.cboBenefit.AddItem("COT"); // Add each item to list.

				ViewModel.cboBenefit.AddItem("CF1");
				ViewModel.cboBenefit.AddItem("CF2");
				ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(0); // Display first item.

				//Fill Job Title List box

				frmUpdate.DefInstance.ViewModel.cboJobCode.Items.Clear();
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_JobCodeList ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					strName = modGlobal.Clean(oRec["job_title"]) + "  :" + Convert.ToString(oRec["job_code_id"]);
					frmUpdate.DefInstance.ViewModel.cboJobCode.AddItem(strName);
					oRec.MoveNext();
				}
				;

				//Load Name Listbox
				FillNameList();
				SetSecurity();
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//Reset global variables, remove form rdoConnection

			modGlobal
				.Shared.gAssignID = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtMName_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			//Upper case Middle Initial
			ViewModel.txtMName.Text = ViewModel.txtMName.Text.ToUpper();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtSex_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Upper case Sex field
			ViewModel.txtSex.Text = ViewModel.txtSex.Text.Substring(0, Math.Min(1, ViewModel.txtSex.Text.Length)).ToUpper();

		}

		public static frmUpdate DefInstance
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

		public static frmUpdate CreateInstance()
		{
			PTSProject.frmUpdate theInstance = Shared.Container.Resolve< frmUpdate>();
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
			ViewModel.Shape2.LifeCycleStartup();
			ViewModel.Shape4.LifeCycleStartup();
			ViewModel.Shape3.LifeCycleStartup();
			ViewModel.Shape5.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape2.LifeCycleShutdown();
			ViewModel.Shape4.LifeCycleShutdown();
			ViewModel.Shape3.LifeCycleShutdown();
			ViewModel.Shape5.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUpdate
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUpdateViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUpdate m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}