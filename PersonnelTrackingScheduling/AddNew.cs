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

	public partial class frmAddNew
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddNewViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAddNew));
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


		//******************************************************
		//Add New Employee Form
		//******************************************************
		//ADODB

		public void ClearForm()
		{
			string gsnull_str = "";
			//This procedure is written to clear controls on Add New form
			ViewModel.cboJobCode.Text = "";
			ViewModel.cboJobCode.SelectedIndex = -1;
			ViewModel.lbJobCode.Text = gsnull_str;
			ViewModel.txtStep.Visible = true;
			ViewModel.lbStep.Visible = true;
			ViewModel.txtStep.Text = "1";
			ViewModel.txtFName.Text = gsnull_str;
			ViewModel.txtMName.Text = gsnull_str;
			ViewModel.txtLName.Text = gsnull_str;
			ViewModel.txtSAPEmpID.Text = gsnull_str;
			ViewModel.txtEmpID.Text = gsnull_str;
			ViewModel.txtSName.Text = gsnull_str;
			ViewModel.txtNameKnownBy.Text = gsnull_str;
			ViewModel.txtSSN.Text = gsnull_str;
			ViewModel.txtBDay.Text = gsnull_str;
			ViewModel.txtPhone.Text = gsnull_str;
			ViewModel.txtSex.Text = gsnull_str;
			ViewModel.txtAddress.Text = gsnull_str;
			ViewModel.txtCity.Text = gsnull_str;
			ViewModel.txtZip.Text = gsnull_str;
			ViewModel.txtUnion.Text = gsnull_str;
			ViewModel.txtCOT.Text = gsnull_str;
			ViewModel.txtTFD.Text = gsnull_str;
			ViewModel.cmdAssign.Enabled = false;
			ViewModel.chkStatus.Visible = true;
			ViewModel.txtUnion.Visible = true;
			ViewModel.lbUnion.Visible = true;
			ViewModel.lbExit.Visible = false;
			ViewModel.txtExit.Visible = false;
			ViewModel.txtExit.TabIndex = Convert.ToInt32(Double.Parse(gsnull_str));
			ViewModel.lbExitType.Visible = false;
			ViewModel.cboExitType.Visible = false;
			ViewModel.cboExitType.SelectedIndex = -1;
			ViewModel.cboExitType.Text = "";
			ViewModel.lbExitComments.Visible = false;
			ViewModel.txtExitComments.Visible = false;
			ViewModel.txtExitComments.Text = gsnull_str;
			ViewModel.cmdSwitch.Tag = "1";
			ViewModel.cmdSwitch.Text = "Add New Archived Employee";
			ViewManager.SetCurrent(ViewModel.txtSAPEmpID);

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
			if ( oRec.EOF )
			{
				return Convert.ToInt32(Conversion.Val("1" + Empid));
			}
			else
			{
				WorkInc = 1;
				WorkID = Conversion.Str(WorkInc) + Empid;

				while ( !oRec.EOF )
				{
					if ( Convert.ToDouble(oRec["per_archive_id"]) == Conversion.Val(WorkID) )
					{
						WorkInc++;
						for ( int i = WorkInc; i <= 9; i++ )
						{
							WorkID = Conversion.Str(i) + Empid;
							if ( Convert.ToDouble(oRec["per_archive_id"]) != Conversion.Val(WorkID) )
							{
								WorkInc = i;
								break;
							}
							else
							{
								WorkID = "";
							}
						}
						if ( WorkID == "" )
						{
							return 0;
						}
					}
					oRec.MoveNext();
				};
				return Convert.ToInt32(Conversion.Val(WorkID));
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Job Code textbox with selected Job Title

			if ( ViewModel.cboJobCode.SelectedIndex < 0 )
			{
				return ;
			}

			string sJobCode = ViewModel.cboJobCode.GetListItem(ViewModel.cboJobCode.SelectedIndex).Substring(Math.Max(ViewModel.cboJobCode.GetListItem(ViewModel.cboJobCode.SelectedIndex).Length - 5, 0));
			//    sJobCode = cboJobCode.ItemData(cboJobCode.ListIndex)
			//    If Len(sJobCode) < 5 Then
			//        If Len(sJobCode) = 2 Then
			//            sJobCode = "000" & sJobCode
			//        ElseIf Len(sJobCode) = 3 Then
			//            sJobCode = "00" & sJobCode
			//        ElseIf Len(sJobCode) = 4 Then
			//            sJobCode = "0" & sJobCode
			//        End If
			//    End If
			ViewModel.lbJobCode.Text = sJobCode;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				dynamic txtExceptDay = null;

				//Add New Employee Record
				//Form data is checked for required fields and field lengths
				//SQLServer spInsertPersonnel stored procedure is called to insert record

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string strSQL = "";
				string NameWork = "";
				byte Status = 0;
				int ArcID = 0;
				string LeaveStatus = "";
				System.DateTime TestDate = DateTime.FromOADate(0);
				string str1 = "", str2 = "";
				int i = 0;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				string TYear = "";
				int iPersID = 0;

				try
				{
					{

						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;

						//Edits
						//SAP Employee ID number
						double dbNumericTemp = 0;
						if ( !Double.TryParse(ViewModel.txtSAPEmpID.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
						{
							ViewManager.ShowMessage("Invalid Employee Id", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtSAPEmpID);
							ViewModel.txtSAPEmpID.SelectionStart = 0;
							ViewModel.txtSAPEmpID.SelectionLength = Strings.Len(ViewModel.txtSAPEmpID.Text);
							this.Return();
							return ;
						}
						else
						{
							//check for existing employee_id
							if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
							{
								strSQL = "spSelect_SAPConversionBySapID " + ViewModel.txtSAPEmpID.Text + " ";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if ( !oRec.EOF )
								{
									ViewManager.ShowMessage("Duplicate Employee Id", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
									ViewManager.SetCurrent(ViewModel.txtSAPEmpID);
									ViewModel.txtSAPEmpID.SelectionStart = 0;
									ViewModel.txtSAPEmpID.SelectionLength = Strings.Len(ViewModel.txtSAPEmpID.Text);
									this.Return();
									return ;
								}
							}
							else
							{
								ArcID = GetNewID(ViewModel.txtSAPEmpID.Text);
							}
						}

						//TFD Employee ID number
						//    If Not IsNumeric(txtEmpID) Then
						//        MsgBox "Invalid Employee Id", vbOKOnly, "Add New Employee Error"
						//        txtEmpID.SetFocus
						//        txtEmpID.SelStart = 0
						//        txtEmpID.SelLength = Len(txtEmpID.Text)
						//        Exit Sub
						//    Else
						if ( Strings.Len(ViewModel.txtEmpID.Text) != 5 )
						{
							ViewManager.ShowMessage("Invalid Employee Id", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtEmpID);
							ViewModel.txtEmpID.SelectionStart = 0;
							ViewModel.txtEmpID.SelectionLength = Strings.Len(ViewModel.txtEmpID.Text);
							this.Return();
							return ;
						}
						else
						{
							//check for existing employee_id
							if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
							{
								strSQL = "spSelect_PersonnelByEmpID '" + ViewModel.txtEmpID.Text + "'";
								oCmd.CommandText = strSQL;
								oRec = ADORecordSetHelper.Open(oCmd, "");
								if ( !oRec.EOF )
								{
									ViewManager.ShowMessage("Duplicate Employee Id", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
									ViewManager.SetCurrent(ViewModel.txtEmpID);
									ViewModel.txtEmpID.SelectionStart = 0;
									ViewModel.txtEmpID.SelectionLength = Strings.Len(ViewModel.txtEmpID.Text);
									this.Return();
									return ;
								}
							}
							else
							{
								ArcID = GetNewID(ViewModel.txtEmpID.Text);
							}
						}

						//Name Fields
						if ( modGlobal.Clean(ViewModel.txtFName.Text) == "" )
						{
							ViewManager.ShowMessage("First Name must be entered", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtFName);
							ViewModel.txtFName.SelectionStart = 0;
							ViewModel.txtFName.SelectionLength = Strings.Len(ViewModel.txtFName.Text);
							this.Return();
							return ;
						}

						if ( modGlobal.Clean(ViewModel.txtLName.Text) == "" )
						{
							ViewManager.ShowMessage("Last Name must be entered", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtLName);
							ViewModel.txtLName.SelectionStart = 0;
							ViewModel.txtLName.SelectionLength = Strings.Len(ViewModel.txtLName.Text);
							this.Return();
							return ;
						}

						//job code
						if ( ViewModel.cboJobCode.SelectedIndex < 0 )
						{
							ViewManager.ShowMessage("Please select a Job Title/Code from the list.", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.cboJobCode);
							this.Return();
							return ;
						}

						//Sex
						if ( ViewModel.txtSex.Text == "M" || ViewModel.txtSex.Text == "F" )
						{
						//sex entered correctly
						}
						else
						{
							ViewManager.ShowMessage("Sex must be M or F", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtSex);
							ViewModel.txtSex.SelectionStart = 0;
							ViewModel.txtSex.SelectionLength = Strings.Len(ViewModel.txtSex.Text);
							this.Return();
							return ;
						}
						ViewModel.txtNameKnownBy.Text = modGlobal.Clean(ViewModel.txtNameKnownBy.Text);

						//Exception Days
						double dbNumericTemp2 = 0;
						if ( !Double.TryParse(ViewModel.txtException.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2) )
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
							if ( Convert.IsDBNull(ViewModel.txtException.Text) || ViewModel.txtException.Text == "" )
							{
								ViewModel.txtException.Text = "0";
							}
							else
							{
								ViewManager.ShowMessage("Exception Days must be numeric", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
								ViewManager.SetCurrent(ViewModel.txtException);
								ViewModel.txtException.SelectionStart = 0;
								//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
								ViewModel.txtException.SelectionLength = Strings.Len(Convert.ToString(txtExceptDay.Text));
								this.Return();
								return ;
							}
						}

						//Date Fields
						if ( Information.IsDate(ViewModel.txtBDay.Text) )
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtBDay.Text).ToString("M/d/yyyy"));
							if ( TestDate > DateTime.Now )
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("The Birthdate is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
									{
										Response = tempNormalized1;
									});
								async1.Append(() =>
									{
										if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
										{
											ViewManager.ShowMessage("Please Correct the Birthdate using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
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
							ViewManager.ShowMessage("Birthday is invalid", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtBDay);
							ViewModel.txtBDay.SelectionStart = 0;
							ViewModel.txtBDay.SelectionLength = Strings.Len(ViewModel.txtBDay.Text);
							this.Return();
							return ;
						}

						if ( Information.IsDate(ViewModel.txtCOT.Text) )
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtCOT.Text).ToString("M/d/yyyy"));
							if ( TestDate > DateTime.Now )
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
										using ( var async2 = this.Async() )
										{
											if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
											{
												ViewManager.ShowMessage("Please Correct COT Service Date using 4 digit Year", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
												ViewManager.SetCurrent(ViewModel.txtCOT);
												ViewModel.txtCOT.SelectionStart = 0;
												ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtCOT.Text);
												this.Return();
												return ;
											}
											TYear = DateTime.Parse(ViewModel.txtCOT.Text).ToString("yyyy");
											if ( Strings.Len(TYear) == 2 )
											{
												TYear = "20" + TYear;
												TYear = DateTime.Parse(ViewModel.txtCOT.Text).ToString("M/d/") + TYear;
												ViewModel.txtCOT.Text = TYear;
												async2.Append<UpgradeHelpers.Helpers.DialogResult>((
														) => ViewManager.ShowMessage("COT Service Date Corrected for 4 digit Year, Keep Correction?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
												async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
												async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
													{
														Response = tempNormalized5;
													});
												async2.Append(() =>
													{
														if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
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
							ViewManager.ShowMessage("COT Service Date is invalid", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtCOT);
							ViewModel.txtCOT.SelectionStart = 0;
							ViewModel.txtCOT.SelectionLength = Strings.Len(ViewModel.txtCOT.Text);
							this.Return();
							return ;
						}

						if ( Information.IsDate(ViewModel.txtTFD.Text) )
						{
							TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtTFD.Text).ToString("M/d/yyyy"));
							if ( TestDate > DateTime.Now )
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
										ViewManager.ShowMessage("TFD Hire Date is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized6 => tempNormalized6);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized7 =>
									{
										Response = tempNormalized7;
									});
								async1.Append(() =>
									{
										if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
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
							ViewManager.ShowMessage("TFD Hire Date is invalid", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtTFD);
							ViewModel.txtTFD.SelectionStart = 0;
							ViewModel.txtTFD.SelectionLength = Strings.Len(ViewModel.txtTFD.Text);
							this.Return();
							return ;
						}

						if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "2" )
						{
							//Adding New Archived Employee
							if ( Information.IsDate(ViewModel.txtExit.Text) )
							{
								TestDate = DateTime.Parse(DateTime.Parse(ViewModel.txtExit.Text).ToString("M/d/yyyy"));
								if ( TestDate > DateTime.Now )
								{
									async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
											ViewManager.ShowMessage("Exit Date is in the future. Is this correct?", "Add New Personnel", UpgradeHelpers.Helpers.BoxButtons.YesNo));
									async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized8 => tempNormalized8);
									async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized9 =>
										{
											Response = tempNormalized9;
										});
									async1.Append(() =>
										{
											if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
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
							else
							{
								ViewManager.ShowMessage("TFD Exit Date is invalid", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK);
								ViewManager.SetCurrent(ViewModel.txtTFD);
								ViewModel.txtTFD.SelectionStart = 0;
								ViewModel.txtTFD.SelectionLength = Strings.Len(ViewModel.txtExit.Text);
								this.Return();
								return ;
							}
							async1.Append(() =>
								{

									switch ( ViewModel.cboExitType.Text )
									{
										case "Retirement":
											LeaveStatus = "RT";
											break;
										case "Transfer":
											LeaveStatus = "TR";
											break;
										case "Resignation":
											LeaveStatus = "QT";
											break;
										case "Termination":
											LeaveStatus = "TM";
											break;
										default:
											LeaveStatus = "";
											break;
									}

									while ( (ViewModel.txtExitComments.Text.IndexOf('\'') + 1) != 0 )
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
							//Adding New Regular Employee
							double dbNumericTemp3 = 0;
							if ( !Double.TryParse(ViewModel.txtStep.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3) )
							{
								ViewManager.ShowMessage("Invalid Step", "Add New Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								ViewManager.SetCurrent(ViewModel.txtStep);
								ViewModel.txtStep.SelectionStart = 0;
								ViewModel.txtStep.SelectionLength = Strings.Len(ViewModel.txtStep.Text);
								this.Return();
								return ;
							}
							if ( ((int)ViewModel.chkStatus.CheckState) == ((int)UpgradeHelpers.Helpers.CheckState.Checked) )
							{
								Status = 1;
							}
							else
							{
								Status = 0;
							}
						}
						async1.Append(() =>
							{


								//Format name_full field
								NameWork = modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtLName.Text));
								if ( modGlobal.Clean(ViewModel.txtSName.Text) != "" )
								{
									NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtSName.Text);
								}
								NameWork = NameWork + ", " + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text));
								if ( modGlobal.Clean(ViewModel.txtMName.Text) != "" )
								{
									NameWork = NameWork + " " + modGlobal.Clean(ViewModel.txtMName.Text) + ".";
								}

								//Edits ok, insert record
								if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
								{
									strSQL = "spInsertPersonnel '" + modGlobal.Clean(ViewModel.txtEmpID.Text) + "',0,'" + modGlobal.Clean(ViewModel.lbJobCode.Text) + "'," + Conversion.Val(ViewModel.txtStep.Text).ToString() + ",'";
									strSQL = strSQL + modGlobal.Clean(NameWork) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel
														.txtLName.Text)) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text)) + "','";
									strSQL = strSQL + modGlobal.Clean(ViewModel.txtMName.Text) + "','" + modGlobal.Clean(ViewModel.txtSName.Text) + "','" + ViewModel.txtSex.Text + "','";
									strSQL = strSQL + ViewModel.txtSSN.Text + "','" + ViewModel.txtUnion.Text + "','" + ViewModel.cboBenefit.Text + "','";
									strSQL = strSQL + ViewModel.txtAddress.Text + "','" + ViewModel.txtCity.Text + "','" + ViewModel.txtState.Text + "','" + ViewModel.txtZip.Text + "','";
									strSQL = strSQL + ViewModel.txtPhone.Text + "','" + ViewModel.txtBDay.Text + "','" + ViewModel.txtCOT.Text + "','";
									strSQL = strSQL + ViewModel.txtTFD.Text + "'," + Conversion.Val(ViewModel.txtException.Text).ToString() + ",'" + DateTime.Now.ToString("M/d/yyyy");
									strSQL = strSQL + "'," + Status.ToString() + ",'" + ViewModel.txtNameKnownBy.Text + "'";
								}
								else
								{
									strSQL = "spInsertArcPersonnel " + ArcID.ToString() + ",'" + modGlobal.Clean(ViewModel.txtEmpID.Text) + "','" + modGlobal.Clean(ViewModel.lbJobCode.Text) + "','";
									strSQL = strSQL + modGlobal.Clean(NameWork) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel
														.txtLName.Text)) + "','" + modGlobal.Clean(modGlobal.ProofSQLString(ViewModel.txtFName.Text)) + "','";
									strSQL = strSQL + modGlobal.Clean(ViewModel.txtMName.Text) + "','" + modGlobal.Clean(ViewModel.txtSName.Text) + "','" + ViewModel.txtSex.Text + "','";
									strSQL = strSQL + ViewModel.txtSSN.Text + "','" + ViewModel.cboBenefit.Text + "','";
									strSQL = strSQL + ViewModel.txtAddress.Text + "','" + ViewModel.txtCity.Text + "','" + ViewModel.txtState.Text + "','" + ViewModel.txtZip.Text + "','";
									strSQL = strSQL + ViewModel.txtPhone.Text + "','" + ViewModel.txtBDay.Text + "','" + ViewModel.txtCOT.Text + "','";
									strSQL = strSQL + ViewModel.txtTFD.Text + "','" + ViewModel.txtExit.Text + "','" + LeaveStatus + "'," + Conversion.Val(ViewModel.txtException.Text).ToString();
									strSQL = strSQL + ",'" + ViewModel.txtExitComments.Text + "'";
								}

								oCmd.CommandType = CommandType.Text;
								oCmd.CommandText = strSQL;
								oCmd.ExecuteNonQuery();

								//Vacation Balance record for new employee
								oCmd.CommandText = "spInsertVacationBalance '" + ViewModel.txtEmpID.Text + "',0,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
								oCmd.ExecuteNonQuery();

								if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
								{
									modGlobal.Shared.gAssignID = ViewModel.txtEmpID.Text;
									ViewModel.cmdAssign.Enabled = true;
									NameWork = modGlobal.Clean(ViewModel.txtLName.Text) + ", " + modGlobal.Clean(ViewModel.txtFName.Text);
									ViewManager.ShowMessage(NameWork + " successfully Added", "Add New Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
									ViewManager.SetCurrent(ViewModel.cmdAssign);
								}
								else
								{
									NameWork = modGlobal.Clean(ViewModel.txtLName.Text) + ", " + modGlobal.Clean(ViewModel.txtFName.Text);
									ViewManager.ShowMessage(NameWork + " successfully Added to Archived Personnel", "Add New Archived Employee", UpgradeHelpers.Helpers.BoxButtons.OK);
									ClearForm();
								}

								//Add SAPConversion Record
								if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
								{
									strSQL = "spSelect_PersonnelSystemIDByEmpID '" + ViewModel.txtEmpID.Text + "' ";
									oCmd.CommandType = CommandType.Text;
									oCmd.CommandText = strSQL;
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if ( !oRec.EOF )
									{
										//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
										iPersID = Convert.ToInt32(modGlobal.GetVal(oRec["per_sys_id"]));


										//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
										strSQL = "spInsertSAPConversion " + iPersID.ToString() + ", " + Convert.ToString(modGlobal.GetVal(ViewModel.txtSAPEmpID.Text)) + " ";
										oCmd.CommandType = CommandType.Text;
										oCmd.CommandText = strSQL;
										oCmd.ExecuteNonQuery();

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
		internal void cmdAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Show assignment form
 //This button enabled only after successful add
			ViewManager.NavigateToView(
				//Show assignment form
				//This button enabled only after successful add

 frmAssign.DefInstance);
			/*			frmAssign.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{

			ClearForm();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close Add New Employee form
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSwitch_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( Convert.ToString(ViewModel.cmdSwitch.Tag) == "1" )
			{
				ViewModel.chkStatus.Visible = false;
				ViewModel.lbStep.Visible = false;
				ViewModel.txtStep.Visible = false;
				ViewModel.txtUnion.Visible = false;
				ViewModel.lbUnion.Visible = false;
				ViewModel.lbExit.Visible = true;
				ViewModel.txtExit.Visible = true;
				ViewModel.lbExitType.Visible = true;
				ViewModel.cboExitType.Visible = true;
				ViewModel.lbExitComments.Visible = true;
				ViewModel.txtExitComments.Visible = true;
				ViewModel.cmdSwitch.Tag = "2";
				ViewModel.cmdSwitch.Text = "Add New Regular Employee";
			}
			else
			{
				ViewModel.chkStatus.Visible = true;
				ViewModel.lbStep.Visible = true;
				ViewModel.txtStep.Visible = true;
				ViewModel.txtUnion.Visible = true;
				ViewModel.lbUnion.Visible = true;
				ViewModel.lbExit.Visible = false;
				ViewModel.txtExit.Visible = false;
				ViewModel.lbExitType.Visible = false;
				ViewModel.cboExitType.Visible = false;
				ViewModel.lbExitComments.Visible = false;
				ViewModel.txtExitComments.Visible = false;
				ViewModel.cmdSwitch.Tag = "1";
				ViewModel.cmdSwitch.Text = "Add New Archived Employee";
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

				//Load Add New Employee Form
				//Fill Job Title List

				string strName = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				try
				{
						ViewModel.cmdAssign.Enabled = false;
				frmAddNew.DefInstance.ViewModel.cboJobCode.Items.Clear();

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;
									oCmd.CommandText = "spSelect_JobCodeList ";
									oRec = ADORecordSetHelper.Open(oCmd, "");


				while(!oRec.EOF)
										{
												strName = modGlobal.Clean(oRec["job_title"]) + "  :" + Convert.ToString(oRec["job_code_id"]);
					frmAddNew.DefInstance.ViewModel.cboJobCode.AddItem(strName);
														oRec.MoveNext();
											}
											;

											//Fill Benefit List
											ViewModel.cboBenefit.AddItem("COT"); // Add each item to list.

											ViewModel.cboBenefit.AddItem("CF1");
											ViewModel.cboBenefit.AddItem("CF2");
											ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(0);
								}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//Close Add New Employee Form

			modGlobal
				.Shared.gAssignID = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtMName_Leave(Object eventSender, System.EventArgs eventArgs)
		{
			//Upper Case Middle Initial
			ViewModel.txtMName.Text = ViewModel.txtMName.Text.ToUpper();

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtSAPEmpID_Leave(Object eventSender, System.EventArgs eventArgs)
		{
		//Get Next TFD Employee #

		}

		[UpgradeHelpers.Events.Handler]
		internal void txtSex_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//Upper Case Sex
			ViewModel.txtSex.Text = ViewModel.txtSex.Text.Substring(0, Math.Min(1, ViewModel.txtSex.Text.Length)).ToUpper();

		}

		public static frmAddNew DefInstance
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

		public static frmAddNew CreateInstance()
		{
				PTSProject.frmAddNew theInstance = Shared.Container.Resolve<frmAddNew>();
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
			ViewModel.Shape5.LifeCycleStartup();
			ViewModel.Picture1.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape5.LifeCycleShutdown();
			ViewModel.Picture1.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAddNew
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAddNewViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAddNew m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}