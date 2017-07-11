using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgVacationRequest
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgVacationRequestViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgVacationRequest));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgVacationRequest_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************************
		//*** dlgVacationRequest/Management Screen ***
		//********************************************
		//*** ReadOnly Employees can request a VAC ***
		//*** Or Holiday Off for themselves only.  ***
		//*** BC and/or ISOs can request Leave for  **
		//*** anyone.  Only BC/ISOs for Batt 1 can **
		//*** actually schedule vacation or make a ***
		//*** day available.                       ***
		//********************************************

		public object GetIndividualAvailLeave(string sEmpID)
		{
			//Fill the values for gAvailVAC and gAvailHOL for
			//selected employee

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			float TAuthLeave = 0;
			float TVacation = 0;

			float TotHolOverride = 0;
			modGlobal.Shared.gAvailVAC = 0;
			modGlobal.Shared.gAvailHOL = 0;

			string JobCode = modGlobal.GetJobCode(sEmpID);
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + sEmpID + "', '" + modGlobal.Shared.gCurrentYear.ToString() + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				TotHolOverride = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec["holiday_max"], "##.0"));
			}

			//Determine total Authorized Vacation Leave for selected employee
			oCmd.CommandText = "spVacationEarned '" + sEmpID + "', '" + "1/1/" + modGlobal.Shared.gCurrentYear.ToString() + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			string AssignType = modGlobal.Clean(Convert.ToString(oRec["assignment_type_code"]).Trim());
			if (AssignType == "FCC")
			{
				TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 3, "##.0"));
			}
			else
			{
				TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 2, "##.0"));
			}

			//Select Leave Totals for each type of Leave for
			//selected employee
			string BeginDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
			string EndDate = DateTime.Parse(BeginDate).AddYears(1).ToString("M/d/yyyy");

			oCmd.CommandText = "sp_GetIndLeaveTot '" + sEmpID + "', '" + BeginDate + "', '" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (TotHolOverride != 0)
			{
				modGlobal.Shared.gAvailHOL = TotHolOverride;
			}
			else if (AssignType == "REG" || AssignType == "FCC" || AssignType == "MRN")
			{
				modGlobal.Shared.gAvailHOL = modGlobal.MAXHOLREG;
			}
			else
			{
				modGlobal.Shared.gAvailHOL = modGlobal.MAXHOLX;
			}

			modGlobal.Shared.gAvailVAC = TAuthLeave;

			//Fill Leave Totals labels will Query results

			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["time_code_id"]) == "VAC")
				{
					TVacation = ((float) (Convert.ToDouble(oRec["scheduled_leave"]) / 2));
					modGlobal.Shared.gAvailVAC = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(TAuthLeave - TVacation, "##.0"));
					if (Conversion.Val(modGlobal.Shared.gAvailVAC.ToString()) < 0)
					{
						modGlobal.Shared.gAvailVAC = 0;
					}
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "FHL")
				{
					if (TotHolOverride != 0)
					{
						modGlobal.Shared.gAvailHOL = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(TotHolOverride - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0"));
					}
					else if (AssignType == "REG" || AssignType == "FCC" || AssignType == "MRN")
					{
						modGlobal.Shared.gAvailHOL = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLREG - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0"));
					}
					else
					{
						modGlobal.Shared.gAvailHOL = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLX - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0"));
					}
					if (Conversion.Val(modGlobal.Shared.gAvailHOL.ToString()) < 0)
					{
						modGlobal.Shared.gAvailHOL = 0;
					}
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "ML1")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "ML2")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "KEL")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "KLI")
				{
				}
				oRec.MoveNext();
			};




			return null;
		}


		public void AddAvailableShift()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			if (!Information.IsDate(ViewModel.SelectedDate))
			{
				return;
			}
			if ( ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked && ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				return;
			}
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.lbExistAM.Text == "NA")
			{
				ViewModel.SelectedSchedDate = ViewModel.SelectedDate.Trim() + " 7:00 AM";
				SqlString = "spInsertVacationAvailable '" + ViewModel.SelectedSchedDate + "','";
				SqlString = SqlString + ViewModel.dtpGiveOut.Text + "', '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',";
				SqlString = SqlString + " NULL, NULL, '" + modGlobal.Clean(Strings.Replace(ViewModel.txtAvailComment.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				SqlString = "";
			}

			if ( ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.lbExistPM.Text == "NA")
			{
				ViewModel.SelectedSchedDate = ViewModel.SelectedDate.Trim() + " 7:00 PM";
				SqlString = "spInsertVacationAvailable '" + ViewModel.SelectedSchedDate + "','";
				SqlString = SqlString + ViewModel.dtpGiveOut.Text + "', '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',";
				SqlString = SqlString + " NULL, NULL, '" + modGlobal.Clean(Strings.Replace(ViewModel.txtAvailComment.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				SqlString = "";
			}

		}

		public void DeleteVacationRequestRecord()
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				int RecordID = 0;
				string SelectedEmployee = "";
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult) 0;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				if ( ViewModel.SelectedRequest == 0)
				{
					this.Return();
					return ;
				}
				if ( ViewModel.LimitedPower)
				{ //check record selected

					ViewModel.sprRequests.Col = 7;
					ViewModel.sprRequests.Row = ViewModel.SelectedRequest;
					if (modGlobal.Shared.gUser != ViewModel.sprRequests.Text)
					{
						if (modGlobal.Shared.gSecurity == "AID" || modGlobal.Shared.gSecurity == "BC")
						{
							//for now... let them pass
						}
						else
						{
							ViewManager.ShowMessage("You can only delete your own requests.", "No Delete", UpgradeHelpers.Helpers.BoxButtons.OK);
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprRequests.ClearSelection();
							this.Return();
							return ;
						}
					}
				}
				ViewModel.sprRequests.Row = ViewModel.SelectedRequest;
				ViewModel.sprRequests.Col = 6;

				//UPGRADE_WARNING: (1068) GetVal(Clean(sprRequests.Text)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(modGlobal.Clean(ViewModel.sprRequests.Text))) > 0)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					RecordID = Convert.ToInt32(modGlobal.GetVal(modGlobal.Clean(ViewModel.sprRequests.Text)));
					ViewModel.sprRequests.Col = 2;
					SelectedEmployee = modGlobal.Clean(ViewModel.sprRequests.Text);
					ViewModel.sprRequests.Col = 4;
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Do you want to Delete the Request Shift record for " +
											SelectedEmployee + " for " + modGlobal.Clean(ViewModel.sprRequests.Text) + "?", "Delete Available Shift Record", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							resp = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (resp == UpgradeHelpers.Helpers.DialogResult.Yes)
							{
								oCmd.CommandText = "spDeleteVacationRequest " + RecordID.ToString();
								oCmd.ExecuteNonQuery();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprRequests.ClearSelection();
							}
							else
							{
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprRequests.ClearSelection();
							}
						});
						}
				async1.Append(() =>
					{

						FillVacationRequestGrid();
					});
			}


					}

		public void DeleteShiftsAvailableRecord()
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				int RecordID = 0;
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult) 0;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				if ( ViewModel.SelectedAvailable == 0)
				{
					this.Return();
					return ;
				}
				if ( ViewModel.LimitedPower)
				{
					ViewManager.ShowMessage("You do not have the authority to delete this record.", "No Delete", UpgradeHelpers.Helpers.BoxButtons.OK);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					this.Return();
					return ;
				}
				ViewModel.sprAvailable.Row = ViewModel.SelectedAvailable;
				ViewModel.sprAvailable.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal(Clean(sprAvailable.Text)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(modGlobal.Clean(ViewModel.sprAvailable.Text))) > 0)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					RecordID = Convert.ToInt32(modGlobal.GetVal(modGlobal.Clean(ViewModel.sprAvailable.Text)));
					ViewModel.sprAvailable.Col = 2;
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Do you want to Delete the Available Shift record for " +
										modGlobal.Clean(ViewModel.sprAvailable.Text) + "?", "Delete Available Shift Record", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							resp = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (resp == UpgradeHelpers.Helpers.DialogResult.Yes)
							{
								oCmd.CommandText = "spDeleteVacationAvailable " + RecordID.ToString();
								oCmd.ExecuteNonQuery();
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprAvailable.ClearSelection();
							}
							else
							{
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprAvailable.ClearSelection();
							}
						});
						}
				async1.Append(() =>
					{

						FillVacationAvailableGrid();
					});
			}

					}

		public void GetLeaveTotals()
		{
			//Load leave scheduled and leave available labels for
			//currently selected employee
			//If employee does not have an assigned debit group
			//load total number of scheduled debit days
			//ADODB

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string Empid = "";
			float TAuthLeave = 0;
			float TVacation = 0;

			//Come Here - for employee id change
			if ( ViewModel.optUpdate.Checked)
			{
				//Come Here - for employee id change
				Empid = ViewModel.cboUpdateNameList.Text.Substring(Math.Max(ViewModel.cboUpdateNameList.Text.Length - 5, 0));
			}
			else
			{
				//Come Here - for employee id change
				Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			}
			//Test to determine if a Selected Employee exists
			double dbNumericTemp = 0;
			if (Empid == "")
			{
				return;
			}
			else if (Double.TryParse(Empid, NumberStyles.Float , CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				//continue
			}
			else
			{
				return;
			}

			float TotHolOverride = 0;

			string JobCode = modGlobal.GetJobCode(Empid);
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + Empid + "', '" + modGlobal.Shared.gCurrentYear.ToString() + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				TotHolOverride = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec["holiday_max"], "##.0"));
			}


			//Determine total Authorized Vacation Leave for selected employee
			oCmd.CommandText = "spVacationEarned '" + Empid + "', '" + "1/1/" + modGlobal.Shared.gCurrentYear.ToString() + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			string AssignType = modGlobal.Clean(Convert.ToString(oRec["assignment_type_code"]).Trim());
			if (AssignType == "FCC")
			{
				TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 3, "##.0"));
			}
			else
			{
				TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 2, "##.0"));
			}

			//Select Leave Totals for each type of Leave for
			//selected employee
			string BeginDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
			string EndDate = DateTime.Parse(BeginDate).AddYears(1).ToString("M/d/yyyy");

			oCmd.CommandText = "sp_GetIndLeaveTot '" + Empid + "', '" + BeginDate + "', '" + EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			//Clear Leave Totals labels
			//Load Leave available labels with
			//Max available for each leave type
			ViewModel.lbVAC.Text = "0";
			ViewModel.lbHOL.Text = "0";
			ViewModel.lbUpdateVAC.Text = "0";
			ViewModel.lbUpdateHOL.Text = "0";

			if (TotHolOverride != 0)
			{
				ViewModel.lbHOL.Text = TotHolOverride.ToString();
				ViewModel.lbUpdateHOL.Text = TotHolOverride.ToString();
			}
			else if (AssignType == "REG" || AssignType == "FCC" || AssignType == "MRN")
			{
				ViewModel.lbHOL.Text = modGlobal.MAXHOLREG.ToString();
				ViewModel.lbUpdateHOL.Text = modGlobal.MAXHOLREG.ToString();
			}
			else
			{
				ViewModel.lbHOL.Text = modGlobal.MAXHOLX.ToString();
				ViewModel.lbUpdateHOL.Text = modGlobal.MAXHOLX.ToString();
			}
			ViewModel.lbVAC.Text = TAuthLeave.ToString();
			ViewModel.lbUpdateVAC.Text = TAuthLeave.ToString();

			//Fill Leave Totals labels will Query results

			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["time_code_id"]) == "VAC")
				{
					TVacation = ((float) (Convert.ToDouble(oRec["scheduled_leave"]) / 2));
					ViewModel.lbVAC.Text = UpgradeHelpers.Helpers.StringsHelper.Format(TAuthLeave - TVacation, "##.0");
					ViewModel.lbUpdateVAC.Text = UpgradeHelpers.Helpers.StringsHelper.Format(TAuthLeave - TVacation, "##.0");
					if (Conversion.Val(ViewModel.lbVAC.Text) < 0)
					{
						ViewModel.lbVAC.Text = "0";
						ViewModel.lbUpdateVAC.Text = "0";
					}
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "FHL")
				{
					if (TotHolOverride != 0)
					{
						ViewModel.lbHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(TotHolOverride - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
						ViewModel.lbUpdateHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(TotHolOverride - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
					}
					else if (AssignType == "REG" || AssignType == "FCC" || AssignType == "MRN")
					{
						ViewModel.lbHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLREG - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
						ViewModel.lbUpdateHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLREG - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
					}
					else
					{
						ViewModel.lbHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLX - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
						ViewModel.lbUpdateHOL.Text = UpgradeHelpers.Helpers.StringsHelper.Format(modGlobal.MAXHOLX - (Convert.ToDouble(oRec["scheduled_leave"]) / 2), "##.0");
					}
					if (Conversion.Val(ViewModel.lbHOL.Text) < 0)
					{
						ViewModel.lbHOL.Text = "0";
						ViewModel.lbUpdateHOL.Text = "0";
					}
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "ML1")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "ML2")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "KEL")
				{
				}
				else if (modGlobal.Clean(oRec["time_code_id"]) == "KLI")
				{
				}
				oRec.MoveNext();
			};



		}


		public void AddVacationRequest()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			StringBuilder SqlString = new System.Text.StringBuilder();
			ViewModel.SelectedSchedDate = "";
			ViewModel.SelectedVACDate = "";
			bool NeedToGiveUpVAC = false;

			double AvailableShifts = Double.Parse(ViewModel.lbVAC.Text) + Double.Parse(ViewModel.lbHOL.Text);
			AvailableShifts += (ViewModel.lstCurrVAC.SelectedItems.Count / 2d);
			double RequestShifts = ViewModel.lstCurrSched.SelectedItems.Count / 2d;

			if (RequestShifts > AvailableShifts)
			{
				ViewManager.ShowMessage("You must select a Vacation Shift to Give Up.", "PTS Vacation Request", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.cmdReqDone.Enabled = true;
				return;
			}

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.lbVAC.Text) == 0 && UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.lbHOL.Text) == 0)
			{
				NeedToGiveUpVAC = true;
				if ( ViewModel.lstCurrVAC.SelectedItems.Count == 0)
				{
					ViewManager.ShowMessage("You must select a Vacation Shift to Give Up.", "PTS Vacation Request", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewModel.cmdReqDone.Enabled = true;
					return;
				}
				if ( ViewModel.lstCurrSched.SelectedItems.Count != ViewModel.lstCurrVAC.SelectedItems.Count)
				{
					ViewManager.ShowMessage("You must select a Vacation Shift to Give Up for every corresponding Scheduled Shift selected.", "PTS Vacation Request", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewModel.cmdReqDone.Enabled = true;
					return;
				}
			}
			else
			{
				if ( ViewModel.lstCurrVAC.SelectedItems.Count > 0)
				{
					NeedToGiveUpVAC = true;
					if ( ViewModel.lstCurrVAC.SelectedItems.Count > ViewModel.lstCurrSched.SelectedItems.Count)
					{
						ViewManager.ShowMessage("You must select a Vacation Shift to Give Up for every corresponding Scheduled Shift selected.", "PTS Vacation Request", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewModel.cmdReqDone.Enabled = true;
		
						return;
					}
				}
				else
				{
					NeedToGiveUpVAC = false;
				}
			}

			for (int i = 0; i <= ViewModel.lstCurrSched.Items.Count - 1; i++)
			{
				if ( ViewModel.lstCurrSched.GetSelected( i))
				{
					ViewModel.SelectedSchedDate = ViewModel.lstCurrSched.GetListItem(i);
					if ( ViewModel.lstCurrVAC.SelectedItems.Count > 0)
					{
						for (int x = 0; x <= ViewModel.lstCurrVAC.Items.Count - 1; x++)
						{
							if ( ViewModel.lstCurrVAC.GetSelected( x))
							{
								ViewModel.SelectedVACDate = ViewModel.lstCurrVAC.GetListItem(x);
								//                        If Right$(SelectedVACDate, 2) = Right$(SelectedSchedDate, 2) Then
								ViewModel.lstCurrVAC.RemoveItem(x);
								break;
								//                        Else
								//                            SelectedVACDate = ""
								//                        End If
							}
						}
					}
					else
					{
						ViewModel.SelectedVACDate = "";
					}

					if ( ViewModel.SelectedSchedDate.Substring(Math.Max(ViewModel.SelectedSchedDate.Length - 2, 0)) == "AM")
					{
						ViewModel.SelectedSchedDate = ViewModel.SelectedSchedDate.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.SelectedSchedDate) - 2, ViewModel.SelectedSchedDate.Trim().Length)) +
								"7:00 AM";
					}
					else
					{
						ViewModel.SelectedSchedDate = ViewModel.SelectedSchedDate.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.SelectedSchedDate) - 2, ViewModel.SelectedSchedDate.Trim().Length)) +
								"7:00 PM";
					}

					if ( ViewModel.SelectedVACDate != "")
					{
						if ( ViewModel.SelectedVACDate.Substring(Math.Max(ViewModel.SelectedVACDate.Length - 2, 0)) == "AM")
						{
							ViewModel.SelectedVACDate = ViewModel.SelectedVACDate.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.SelectedVACDate) - 2, ViewModel.SelectedVACDate.Trim().Length)) +
									"7:00 AM";
						}
						else
						{
							ViewModel.SelectedVACDate = ViewModel.SelectedVACDate.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.SelectedVACDate) - 2, ViewModel.SelectedVACDate.Trim().Length)) +
									"7:00 PM";
						}
					}

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

					if (NeedToGiveUpVAC && ViewModel.SelectedVACDate == "")
					{
						ViewManager.ShowMessage("Had trouble find a match for Requested VAC date and date willing to give up.  Try again", "PTS Vacation Request", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewModel.cmdReqDone.Enabled = true;
						
						return;
					}

					SqlString = new System.Text.StringBuilder("spInsertVacationRequest '" + ViewModel.Empid + "', '");
					SqlString.Append(ViewModel.SelectedSchedDate + "',");
					if ( ViewModel.SelectedVACDate == "")
					{
						SqlString.Append("NULL,NULL,NULL, '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'");
					}
					else
					{
						SqlString.Append("'" + ViewModel.SelectedVACDate + "', NULL, NULL, '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'");
					}
					SqlString.Append(",'" + modGlobal.Clean(Strings.Replace(ViewModel.txtComment.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ");

					oCmd.CommandText = SqlString.ToString();
					oRec = ADORecordSetHelper.Open(oCmd, "");
				}
			}


		}

		public void GetDailyTotals()
		{
			//This subroutine runs when a day is selected on Month Calendar
			//The AM & PM total scheduled personnel for selected date are
			//displayed in label controls below calendar

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Initialize Leave Total Labels
			ViewModel.lbREGam.Text = "";
			ViewModel.lbREGpm.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + ViewModel.SelectedDate + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				modGlobal
					.Shared.gMAXLEAVE = Convert.ToInt32(modGlobal.GetVal(oRec["max_leave_allowed"]));
			}
			else
			{
				modGlobal.Shared.gMAXLEAVE = 10;
			}

			//Select AM Leave Totals for selected date
			string NewDate = ViewModel.SelectedDate + " 7:00AM";
			ViewModel.lbSelectAM.Text = NewDate;
			oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbREGam.Text = "0";
				ViewModel.lbExistAM.Text = "NA";
			}


			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV")
				{

				}
				else
				{
					ViewModel.lbREGam.Text = Convert.ToString(oRec["total_leave"]);
					ViewModel.lbExistAM.Text = modGlobal.Clean(oRec["Available"]);
				}
				oRec.MoveNext();
			};

			//Select PM Leave Totals for selected date
			NewDate = ViewModel.SelectedDate + " 7:00PM";
			ViewModel.lbSelectPM.Text = NewDate;
			oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbREGpm.Text = "0";
				ViewModel.lbExistPM.Text = "NA";
			}




			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV")
				{

				}
				else
				{
					ViewModel.lbREGpm.Text = Convert.ToString(oRec["total_leave"]);
					ViewModel.lbExistPM.Text = modGlobal.Clean(oRec["Available"]);
				}
				oRec.MoveNext();
			};


			//UPGRADE_WARNING: (1068) GetVal(lbREGam.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbREGam.Text)) >= modGlobal.Shared.gMAXLEAVE)
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			//UPGRADE_WARNING: (1068) GetVal(lbREGpm.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbREGpm.Text)) >= modGlobal.Shared.gMAXLEAVE)
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}

			if ( ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked || ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.cmdAvailDone.Enabled = true;
				ViewModel.txtAvailComment.Text = "";
				ViewModel.lbAvailComment.Visible = true;
				ViewModel.txtAvailComment.Visible = true;
			}
			else
			{
				ViewModel.cmdAvailDone.Enabled = false;
				ViewModel.lbAvailComment.Visible = false;
				ViewModel.txtAvailComment.Visible = false;
			}
			ViewModel.lbSelectAM.Visible = true;
			ViewModel.lbSelectPM.Visible = true;
			ViewModel.lbREGam.Visible = true;
			ViewModel.lbREGpm.Visible = true;


		}

		public void FillVacationGrantedGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprGranted.MaxRows = 500;

			ViewModel.sprGranted.BlockMode = true;
			ViewModel.sprGranted.Row = 1;
			ViewModel.sprGranted.Row2 = ViewModel.sprAvailable.MaxRows;
			ViewModel.sprGranted.Col = 2;
			ViewModel.sprGranted.Col2 = ViewModel.sprAvailable.MaxCols;
			//ViewModel.sprGranted.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprGranted.BlockMode = false;

			int CurrRow = 1;
			bool ChangeFont = false;
			string FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_AnnualVacationRequestList '" + modGlobal.Shared.gDetailDate + "' ";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprGranted.Row = CurrRow;

				//requested by employee name
				ViewModel.sprGranted.Col = 1;
				ViewModel.sprGranted.Text = modGlobal.Clean(oRec["requested_by"]);

				//shift date recieved
				ViewModel.sprGranted.Col = 2;
				ViewModel.sprGranted.Text = Convert.ToDateTime(oRec["req_shift_date"]).ToString("MM/dd/yyyy") + " - " +
							modGlobal.Clean(oRec["req_AMPM"]);

				//shift date given up
				ViewModel.sprGranted.Col = 3;
				if (String.CompareOrdinal(modGlobal.Clean(oRec["giveup_shift_date"]), "") > 0)
				{
					ViewModel.sprGranted.Text = Convert.ToDateTime(oRec["giveup_shift_date"]).ToString("MM/dd/yyyy") + " - " +
								modGlobal.Clean(oRec["giveup_AMPM"]);
				}
				else
				{
					ViewModel.sprGranted.Text = "";
				}

				//granted by
				ViewModel.sprGranted.Col = 4;
				ViewModel.sprGranted.Text = modGlobal.Clean(oRec["granted_by"]);


				//Date granted
				ViewModel.sprGranted.Col = 5;
				ViewModel.sprGranted.Text = Convert.ToDateTime(oRec["granted_date"]).ToString("MM/dd/yyyy HH:mm");
				if (Convert.ToDateTime(oRec["granted_date"]).ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
				{
					ChangeFont = true;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.GREEN).ToString();
				}
				else
				{
					ChangeFont = false;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
				}
				ViewModel.sprGranted.Col = 6;
				ViewModel.sprGranted.Text = modGlobal.Clean(oRec["group_code"]);

				//ID
				ViewModel.sprGranted.Col = 7;
				ViewModel.sprGranted.Text = modGlobal.Clean(oRec["request_id"]);

				if (ChangeFont)
				{
					ViewModel.sprGranted.BlockMode = true;
					ViewModel.sprGranted.Row = CurrRow;
					ViewModel.sprGranted.Row2 = CurrRow;
					ViewModel.sprGranted.Col = 2;
					ViewModel.sprGranted.Col2 = ViewModel.sprGranted.MaxCols;
					ViewModel.sprGranted.FontBold = false;
					ViewModel.sprGranted.BlockMode = false;
				}
				else
				{
					ViewModel.sprGranted.BlockMode = true;
					ViewModel.sprGranted.Row = CurrRow;
					ViewModel.sprGranted.Row2 = CurrRow;
					ViewModel.sprGranted.Col = 2;
					ViewModel.sprGranted.Col2 = ViewModel.sprGranted.MaxCols;
					ViewModel.sprGranted.FontBold = false;
					ViewModel.sprGranted.BlockMode = false;
				}

				CurrRow++;
				oRec.MoveNext();
			};
			ViewModel.sprGranted.MaxRows = CurrRow;

		}

		public void FillVacationRequestGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";
			string sComment = "";
			ViewModel.sprRequests.MaxRows = 1000;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearRange(2, 1, ViewModel.sprRequests.MaxCols, ViewModel.sprRequests.MaxRows, false);
			ViewModel.sprRequests.BlockMode = true;
			ViewModel.sprRequests.Row = 1;
			ViewModel.sprRequests.Row2 = ViewModel.sprAvailable.MaxRows;
			ViewModel.sprRequests.Col = 2;
			ViewModel.sprRequests.Col2 = ViewModel.sprAvailable.MaxCols;
			//ViewModel.sprRequests.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprRequests.BlockMode = false;

			int CurrRow = 1;
			bool ChangeFont = false;
			string FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
			string sEmpID = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			if ( ViewModel.chkPMOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				SqlString = "spSelect_VacationRequestPMFilteredList '" + modGlobal.Shared.gDetailDate + "',";
			}
			else if ( ViewModel.chkHZMOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				SqlString = "spSelect_VacationRequestHZMFilteredList '" + modGlobal.Shared.gDetailDate + "',";
			}
			else
			{
				SqlString = "spSelect_VacationRequestFilteredList '" + modGlobal.Shared.gDetailDate + "',";
			}
			if (modGlobal.Clean(ViewModel.ReqEmpid) == "")
			{
				SqlString = SqlString + "Null ";
			}
			else
			{
				SqlString = SqlString + "'" + ViewModel.ReqEmpid + "' ";
			}
			oCmd.CommandText = SqlString;

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprRequests.Row = CurrRow;

				//requested by employee name
				ViewModel.sprRequests.Col = 2;
				ViewModel.sprRequests.Text = modGlobal.Clean(oRec["requested_by"]);

				sComment = "";
				if (modGlobal.Clean(oRec["LeaveDatetime"]) != "")
				{
					sComment = modGlobal.Clean(oRec["LeaveTimeCode"]) + " is scheduled for " +
					           Convert.ToDateTime(oRec["LeaveDateTime"]).ToString("M/d/yyyy HH:mm") + "... " +
					           modGlobal.Clean(oRec["comment"]);
					ChangeFont = true;
					FontColor = modGlobal.COTHER.ToString();
				}
				else if (modGlobal.Clean(oRec["comment"]) != "")
				{
					sComment = modGlobal.Clean(oRec["comment"]);
					ChangeFont = false;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
				}

				//comment
				if (modGlobal.Clean(sComment) != "")
				{
					ViewModel.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprRequests.Col = 2;
					ViewModel.sprRequests.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.CellNote = modGlobal.Clean(sComment);
				}
				else
				{
					ChangeFont = false;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
				}

				//TFD hire date
				ViewModel.sprRequests.Col = 3;
				ViewModel.sprRequests.Text = Convert.ToDateTime(oRec["TFD_hire_date"]).ToString("MM/dd/yyyy");

				//shift date wanted
				System
					.DateTime TempDate = DateTime.FromOADate(0);
				if (((DateTime.TryParse(modGlobal.Shared.gDetailDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gDetailDate) == Convert.ToDateTime(oRec["req_shift_date"]).ToString("MM/dd/yyyy"))
				{
					ChangeFont = true;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED).ToString();
				}
				else if (!ChangeFont)
				{
					ChangeFont = false;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
				}
				ViewModel.sprRequests.Col = 4;
				ViewModel.sprRequests.Text = Convert.ToDateTime(oRec["req_shift_date"]).ToString("MM/dd/yyyy") + " - " +
							modGlobal.Clean(oRec["req_AMPM"]);

				//comment
				if (modGlobal.Clean(oRec["created_by"]) != "")
				{
					ViewModel.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprRequests.Col = 4;
					ViewModel.sprRequests.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.CellNote = "Created On " + modGlobal.Clean(oRec["created_on"]) + " By " +
								modGlobal.Clean(oRec["created_by"]);
				}

				//give up date
				ViewModel.sprRequests.Col = 5;
				if (String.CompareOrdinal(modGlobal.Clean(oRec["giveup_shift_date"]), "") > 0)
				{
					ViewModel.sprRequests.Text = Convert.ToDateTime(oRec["giveup_shift_date"]).ToString("MM/dd/yyyy") + " - " +
								modGlobal.Clean(oRec["giveup_AMPM"]);
					if (String.CompareOrdinal(Convert.ToDateTime(oRec["giveup_shift_date"]).ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")) < 0 || String.CompareOrdinal(Convert.ToDateTime(oRec["req_shift_date"]).ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")) < 0)
					{
						ChangeFont = true;
						FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLUE).ToString();
					}
				}
				else
				{
					ViewModel.sprRequests.Text = "";
					if (modGlobal.Clean(oRec["employee_id"]) != sEmpID)
					{
						sEmpID = modGlobal.Clean(oRec["employee_id"]);
						//Add logic to retreive VAC/HOL Shifts Available and display as a cell note
						GetIndividualAvailLeave(modGlobal.Clean(oRec["employee_id"]));
						ViewModel.sprRequests.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
						ViewModel.sprRequests.Col = 5;
						ViewModel.sprRequests.CellNoteIndicator = true;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprRequests.CellNote = "Available VAC = " + modGlobal.Shared.gAvailVAC.ToString() + "     Available HOL = " + modGlobal.Shared.gAvailHOL.ToString();
					}
				}

				//ID
				ViewModel.sprRequests.Col = 6;
				ViewModel.sprRequests.Text = modGlobal.Clean(oRec["request_id"]);

				//Employee Id
				ViewModel.sprRequests.Col = 7;
				ViewModel.sprRequests.Text = modGlobal.Clean(oRec["employee_id"]);


				if (Convert.ToDateTime(oRec["created_on"]).ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
				{
					if (!ChangeFont)
					{
						ChangeFont = true;
						FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.GREEN).ToString();
					}
				}

				if (ChangeFont)
				{
					ViewModel.sprRequests.BlockMode = true;
					ViewModel.sprRequests.Row = CurrRow;
					ViewModel.sprRequests.Row2 = CurrRow;
					ViewModel.sprRequests.Col = 2;
					ViewModel.sprRequests.Col2 = ViewModel.sprRequests.MaxCols;
					ViewModel.sprRequests.FontBold = false;
					ViewModel.sprRequests.BlockMode = false;
				}
				else
				{
					ViewModel.sprRequests.BlockMode = true;
					ViewModel.sprRequests.Row = CurrRow;
					ViewModel.sprRequests.Row2 = CurrRow;
					ViewModel.sprRequests.Col = 2;
					ViewModel.sprRequests.Col2 = ViewModel.sprRequests.MaxCols;
					ViewModel.sprRequests.FontBold = false;
					ViewModel.sprRequests.BlockMode = false;
				}

				CurrRow++;
				oRec.MoveNext();
			};
			ViewModel.sprRequests.MaxRows = CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearSelection();

		}

		public void FillVacationAvailableGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprAvailable.MaxRows = 500;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAvailable.ClearRange(2, 1, ViewModel.sprAvailable.MaxCols, ViewModel.sprAvailable.MaxRows, false);
			ViewModel.sprAvailable.BlockMode = true;
			ViewModel.sprAvailable.Row = 1;
			ViewModel.sprAvailable.Row2 = ViewModel.sprAvailable.MaxRows;
			ViewModel.sprAvailable.Col = 2;
			ViewModel.sprAvailable.Col2 = ViewModel.sprAvailable.MaxCols;
			//ViewModel.sprAvailable.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			ViewModel.sprAvailable.BlockMode = false;

			int CurrRow = 1;
			bool ChangeFont = false;
			string FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_VacationAvailableList '" + modGlobal.Shared.gDetailDate + "' ";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprAvailable.Row = CurrRow;

				//Shift Available
				ViewModel.sprAvailable.Col = 2;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(oRec["shift_date"]).ToString("MM/dd/yyyy") + " - " +
							modGlobal.Clean(oRec["AMPM"]);

				//comment
				if (modGlobal.Clean(oRec["comment"]) != "")
				{
					ViewModel.sprAvailable.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprAvailable.Col = 2;
					ViewModel.sprAvailable.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprAvailable.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.CellNote = modGlobal.Clean(oRec["comment"]);
				}

				//Give Out On
				System
					.DateTime TempDate = DateTime.FromOADate(0);
				if (((DateTime.TryParse(modGlobal.Shared.gDetailDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gDetailDate) == Convert.ToDateTime(oRec["given_to"]).ToString("MM/dd/yyyy"))
				{
					ChangeFont = true;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED).ToString();
				}
				else
				{
					ChangeFont = false;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK).ToString();
				}
				ViewModel.sprAvailable.Col = 3;
				if (modGlobal.Clean(oRec["given_to"]) != "")
				{
					ViewModel.sprAvailable.Text = Convert.ToDateTime(oRec["given_to"]).ToString("MM/dd/yyyy");
				}
				else
				{
					ViewModel.sprAvailable.Text = "";
				}

				//Created By
				ViewModel.sprAvailable.Col = 4;
				ViewModel.sprAvailable.Text = modGlobal.Clean(oRec["created_by"]);

				//Created On
				ViewModel.sprAvailable.Col = 5;
				if (String.CompareOrdinal(modGlobal.Clean(oRec["create_date"]), "") > 0)
				{
					ViewModel.sprAvailable.Text = Convert.ToDateTime(oRec["create_date"]).ToString("MM/dd/yyyy");
					if (Convert.ToDateTime(oRec["create_date"]).ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
					{
						if (!ChangeFont)
						{
							ChangeFont = true;
							FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.GREEN).ToString();
						}
					}
				}
				else
				{
					ViewModel.sprAvailable.Text = "";
				}

				if (String.CompareOrdinal(Convert.ToDateTime(oRec["given_to"]).ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")) < 0 || String.CompareOrdinal(Convert.ToDateTime(oRec["shift_date"]).ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")) < 0)
				{
					ChangeFont = true;
					FontColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLUE).ToString();
				}


				//ID
				ViewModel.sprAvailable.Col = 6;
				ViewModel.sprAvailable.Text = modGlobal.Clean(oRec["available_id"]);

				//Given To Employee Id
				ViewModel.sprAvailable.Col = 7;
				ViewModel.sprAvailable.Text = modGlobal.Clean(oRec["employee_id"]);

				if (ChangeFont)
				{
					ViewModel.sprAvailable.BlockMode = true;
					ViewModel.sprAvailable.Row = CurrRow;
					ViewModel.sprAvailable.Row2 = CurrRow;
					ViewModel.sprAvailable.Col = 2;
					ViewModel.sprAvailable.Col2 = ViewModel.sprAvailable.MaxCols;
					ViewModel.sprAvailable.FontBold = false;
					ViewModel.sprAvailable.BlockMode = false;
				}
				else
				{
					ViewModel.sprAvailable.BlockMode = true;
					ViewModel.sprAvailable.Row = CurrRow;
					ViewModel.sprAvailable.Row2 = CurrRow;
					ViewModel.sprAvailable.Col = 2;
					ViewModel.sprAvailable.Col2 = ViewModel.sprAvailable.MaxCols;
					ViewModel.sprAvailable.FontBold = false;
					ViewModel.sprAvailable.BlockMode = false;
				}

				CurrRow++;
				oRec.MoveNext();
			};
			ViewModel.sprAvailable.MaxRows = CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAvailable.ClearSelection();
		}

		public void FillCurrVACList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			ViewModel.lstCurrVAC.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_EmployeeFutureVAC '" + ViewModel.Empid + "','" + modGlobal.Shared.gDetailDate + "' ";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["shift_date"]).Trim() + "  " + Convert.ToString(oRec["AMPM"]).Trim();
				ViewModel.lstCurrVAC.AddItem(strName);
				oRec.MoveNext();
			};

		}

		public void FillCurrShiftList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			ViewModel.lstCurrSched.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_EmployeeFutureSchedule '" + ViewModel.Empid + "','" + modGlobal.Shared.gDetailDate + "' ";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				strName = Convert.ToString(oRec["shift_date"]).Trim() + "  " + Convert.ToString(oRec["AMPM"]).Trim();
				ViewModel.lstCurrSched.AddItem(strName);
				oRec.MoveNext();
			};

		}

		//UPGRADE_WARNING: (2074) SSMonth event calAvail.Click was upgraded to calAvail.DateChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void calAvail_DateChanged(Object eventSender, Stubs._System.Windows.Forms.DateRangeEventArgs eventArgs)
		{
			string SelDate = eventArgs.End.ToString();
			//string OldSelDate = "";
			int Selected = 1;
			//int RtnCancel = 0;
			if (~Selected != 0)
			{
				return;
			}

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.SelectedDate = (DateTime.TryParse(SelDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : SelDate;
			ViewModel.dtpGiveOut.Text = DateTime.Parse(ViewModel.SelectedDate).AddDays(-14).ToString("MM/dd/yyyy");
			GetDailyTotals();

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2074) ComboBox event cboKOT.Change was upgraded to cboKOT.TextChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void cboKOT_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.isInitializingComponent)
			{
				return;
			}
			if (!ViewModel.optUpdate.Checked)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.cboUpdateNameList.Text) != "" && modGlobal.Clean(ViewModel.cboKOT.Text) != "")
			{
				ViewModel.cmdUpdateDone.Enabled = true;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboKOT_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if (modGlobal.Clean(ViewModel.cboUpdateNameList.Text) != "" && modGlobal.Clean(ViewModel.cboKOT.Text) != "")
			{
				ViewModel.cmdUpdateDone.Enabled = true;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboNameList.SelectedIndex == -1)
			{
				return;
			}
			//Come Here - for employee id change
			ViewModel.Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));

			//Load Current Vacation List for selected employee
			FillCurrVACList();
			FillCurrShiftList();
			GetLeaveTotals();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboReqNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboReqNameList.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.ReqEmpid = ViewModel.cboReqNameList.Text.Substring(Math.Max(ViewModel.cboReqNameList.Text.Length - 5, 0));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if (Strings.Len(ViewModel.ReqEmpid) < 5 || Convert.IsDBNull(ViewModel.ReqEmpid) || ViewModel.ReqEmpid == "")
			{
				ViewModel.ReqEmpid = "";
				return;
			}
			FillVacationRequestGrid();
		}

		//UPGRADE_WARNING: (2074) ComboBox event cboUpdateNameList.Change was upgraded to cboUpdateNameList.TextChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void cboUpdateNameList_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.isInitializingComponent)
			{
				return;
			}
			if (!ViewModel.optUpdate.Checked)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.cboUpdateNameList.Text) != "" && modGlobal.Clean(ViewModel.cboKOT.Text) != "")
			{
				ViewModel.cmdUpdateDone.Enabled = true;
			}
			//Come Here - for employee id change
			ViewModel.Empid = ViewModel.cboUpdateNameList.Text.Substring(Math.Max(ViewModel.cboUpdateNameList.Text.Length - 5, 0));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if (Strings.Len(ViewModel.Empid) < 5 || Convert.IsDBNull(ViewModel.Empid) || ViewModel.Empid == "")
			{
				return;
			}
			GetLeaveTotals();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUpdateNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if (!ViewModel.optUpdate.Checked)
			{
				return;
			}
			if (modGlobal.Clean(ViewModel.cboUpdateNameList.Text) != "" && modGlobal.Clean(ViewModel.cboKOT.Text) != "")
			{
				ViewModel.cmdUpdateDone.Enabled = true;
			}
			//Come Here - for employee id change
			ViewModel.Empid = ViewModel.cboUpdateNameList.Text.Substring(Math.Max(ViewModel.cboUpdateNameList.Text.Length - 5, 0));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if (Strings.Len(ViewModel.Empid) < 5 || Convert.IsDBNull(ViewModel.Empid) || ViewModel.Empid == "")
			{
				return;
			}
			GetLeaveTotals();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkHZMOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.chkHZMOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.chkPMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			FillVacationRequestGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkPMOnly_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkPMOnly.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.chkHZMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			FillVacationRequestGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAvailDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdAvailDone.Enabled = false;
			if ( ViewModel.optAvailable.Checked)
			{
				AddAvailableShift();
			}
			ViewModel.txtAvailComment.Text = "";
			FillVacationAvailableGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearAvail_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprAvailable.ClearSelection();
			FillVacationAvailableGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClearRequest_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprRequests.ClearSelection();
			ViewModel.cboReqNameList.SelectedIndex = -1;
			ViewModel.cboReqNameList.Text = "";
			ViewModel.ReqEmpid = "";
			FillVacationRequestGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReqDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdReqDone.Enabled = false;
			if ( ViewModel.optRequest.Checked)
			{
				AddVacationRequest();
			}
			ViewModel.txtComment.Text = "";
			GetLeaveTotals();
			FillCurrShiftList();
			FillCurrVACList();
			FillVacationRequestGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdateDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				//string NoSched1 = "";
				int Response = 0;
				int AssignID = 0;
				string sMessage = "";

				if (!ViewModel.optUpdate.Checked)
				{
					this.Return();
					return ;
				}
				if ( ViewModel.Empid == "")
				{
					this.Return();
					return ;
				}

				modGlobal.Shared.GivingUpShift = false;

				GetLeaveTotals();
				double AvailableHoliday = Double.Parse(ViewModel.lbHOL.Text);
				double AvailableVacation = Double.Parse(ViewModel.lbVAC.Text);

				string AMShiftDate = "";
				string PMShiftDate = "";
				string AMGiveUpShiftDate = "";
				string PMGiveUpShiftDate = "";
				modGlobal.Shared.gSCKFlag = 0;

				//Fill in gLeaveNotes & gLeaveType with the KOT
				//Then call 'ScheduleLeave(EmpID As String, LeaveDate As String)
				modGlobal
					.Shared.gLeaveType = modGlobal.Clean(ViewModel.cboKOT.Text);
				modGlobal.Shared.gLeaveNotes = modGlobal.Clean(ViewModel.txtUpdateComment.Text);

				if (AvailableHoliday <= 0 && AvailableVacation <= 0)
				{
					if ( ViewModel.calGiveUpDate.Visible)
					{
						//continue - everything will equal out
						modGlobal
							.Shared.GivingUpShift = true;
					}
					else
					{
						ViewManager.ShowMessage("There is not enough available Leave to grant this request.", "No Available Leave", UpgradeHelpers.Helpers.BoxButtons.OK);

						this.Return();
						return ;
					}
				}

				//Check to make sure that the correct KOT Leave is used
				if (modGlobal.Shared.gLeaveType == "VAC" && AvailableVacation <= 0)
				{
					if ( ViewModel.calGiveUpDate.Visible)
					{
						//continue - everything will equal out
						modGlobal
							.Shared.GivingUpShift = true;
					}
					else
					{
						if (AvailableHoliday >= 1)
						{
							ViewModel.cboKOT.Text = "FHL";
							modGlobal.Shared.gLeaveType = "FHL";
						}
						else
						{
							if ( ViewModel.chkUpdateAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.chkUpdatePM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
							{
								ViewManager.ShowMessage("There is not enough available Leave to grant this request.", "No Available Leave", UpgradeHelpers.Helpers.BoxButtons.OK);

								this.Return();
								return ;
							}
						}
					}
				}

				if (modGlobal.Shared.gLeaveType == "FHL" && AvailableHoliday <= 0)
				{
					if ( ViewModel.calGiveUpDate.Visible)
					{
						//continue - everything will equal out
						modGlobal
							.Shared.GivingUpShift = true;
					}
					else
					{
						if (AvailableVacation >= 1)
						{
							ViewModel.cboKOT.Text = "VAC";
							modGlobal.Shared.gLeaveType = "VAC";
						}
						else
						{
							if ( ViewModel.chkUpdateAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.chkUpdatePM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
							{
								ViewManager.ShowMessage("There is not enough available Leave to grant this request.", "No Available Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
								
								this.Return();
								return ;
							}
						}
					}
				}

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				string SqlString = "";

				if ( ViewModel.calGiveUpDate.Visible)
				{
					if ( ViewModel.chkGiveUpAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
					{
						AMGiveUpShiftDate = ViewModel.calGiveUpDate.Text.Trim() + " 7:00 AM";
					}
					if ( ViewModel.chkGiveUpPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
					{
						PMGiveUpShiftDate = ViewModel.calGiveUpDate.Text.Trim() + " 7:00 PM";
					}
				}
				else
				{
					AMGiveUpShiftDate = "";
					PMGiveUpShiftDate = "";
				}

				if ( ViewModel.chkUpdateAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
				{
					if (AMGiveUpShiftDate != "")
					{
						//find out KOT for date giving up
						oCmd.CommandText = "sp_GetIndLeave '" + AMGiveUpShiftDate + "','" + ViewModel.Empid + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(oRec["time_code_id"]);
							if (modGlobal.Shared.gLeaveType != ViewModel.cboKOT.Text)
							{
								ViewModel.cboKOT.Text = modGlobal.Shared.gLeaveType;
							}
						}
						else
						{
							ViewManager.ShowMessage("Could Not Find the Date To Give Up!!", "Vacation Request Failed", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							
							this.Return();
							return ;
						}
					}
					else if (PMGiveUpShiftDate != "")
					{
						//find out KOT for date giving up
						oCmd.CommandText = "sp_GetIndLeave '" + PMGiveUpShiftDate + "','" + ViewModel.Empid + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(oRec["time_code_id"]);
							if (modGlobal.Shared.gLeaveType != ViewModel.cboKOT.Text)
							{
								ViewModel.cboKOT.Text = modGlobal.Shared.gLeaveType;
							}
						}
						else
						{
							ViewManager.ShowMessage("Could Not Find the Date To Give Up!!", "Vacation Request Failed", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							
							this.Return();
							return ;
						}
					}
					AMShiftDate = ViewModel.calRequestDate.Text.Trim() + " 7:00 AM";
					async1.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(ViewModel.Empid, AMShiftDate));
					async1.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized1 =>
						{
							var returningMetodValue = tempNormalized1;
							Response = returningMetodValue.returnValue;
							ViewModel.Empid = returningMetodValue.Empid;

							AMShiftDate = returningMetodValue.LeaveDate;
							if (Response != 0)
							{
								//continue
							}
							else
							{
								ViewManager.ShowMessage("The Leave for " + AMShiftDate + " failed.", "Schedule AM Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
								
								this.Return();
								return ;
							}
						});
						}
						if ( ViewModel.chkUpdatePM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
				{
					if (PMGiveUpShiftDate != "")
					{
						//find out KOT for date giving up
						oCmd.CommandText = "sp_GetIndLeave '" + PMGiveUpShiftDate + "','" + ViewModel.Empid + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(oRec["time_code_id"]);
							if (modGlobal.Shared.gLeaveType != ViewModel.cboKOT.Text)
							{
								ViewModel.cboKOT.Text = modGlobal.Shared.gLeaveType;
							}
						}
						else
						{
							ViewManager.ShowMessage("Could Not Find the Date To Give Up!!", "Vacation Request Failed", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);

							this.Return();
							return ;
						}
					}
					else if (AMGiveUpShiftDate != "")
					{
						//find out KOT for date giving up
						oCmd.CommandText = "sp_GetIndLeave '" + AMGiveUpShiftDate + "','" + ViewModel.Empid + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(oRec["time_code_id"]);
							if (modGlobal.Shared.gLeaveType != ViewModel.cboKOT.Text)
							{
								ViewModel.cboKOT.Text = modGlobal.Shared.gLeaveType;
							}
						}
						else
						{
							ViewManager.ShowMessage("Could Not Find the Date To Give Up!!", "Vacation Request Failed", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);

							this.Return();
							return ;
						}
					}
					PMShiftDate = ViewModel.calRequestDate.Text.Trim() + " 7:00 PM";
					async1.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(ViewModel.Empid, PMShiftDate));
					async1.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized3 =>
						{
                            var returningMetodValue = tempNormalized3;
							Response = returningMetodValue.returnValue;
							ViewModel.Empid = returningMetodValue.Empid;

							PMShiftDate = returningMetodValue.LeaveDate;
							if (Response != 0)
							{
								//continue
							}
							else
							{
								ViewManager.ShowMessage("The Leave for " + PMShiftDate + " failed.", "Schedule PM Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
								
								this.Return();
								return ;
							}
						});
						}
				async1.Append(() =>
					{

						//ADD PAYROLL LOGIC HERE
						System
							.DateTime TempDate = DateTime.FromOADate(0);
						if (~modPTSPayroll.CheckPayrollForLeaveDelete(ViewModel.Empid, (DateTime.TryParse(AMGiveUpShiftDate, out
								TempDate)) ? TempDate.ToString("MM/dd/yyyy") : AMGiveUpShiftDate, ViewModel.cboKOT.Text) != 0)
						{
							sMessage = "Ooops!! Payroll may have been Uploaded to SAP.  Delete payroll record first.  If you " + "experience any problems, please call Debra Lewandowsky x5068... Thanks";
							ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);

						}
						else
						{
							//Then Update VacationRequest Record(s)
							if (modGlobal.Clean(ViewModel.lbRequestAM.Text) != "")
							{
								//If Giveup date... Check to see if someone is already in the shift/position
								//DuplicateAssignment(EmpID As String, AssignID As Long, ThisShift As String)
								//if true change assignment to the appropriate Rover/Debit
								//then Delete Leave
								if (AMGiveUpShiftDate != "")
								{
									oCmd.CommandText = "sp_GetSchedAssign '" + ViewModel.Empid + "', '" + AMGiveUpShiftDate + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if (!oRec.EOF)
									{
										AssignID = Convert.ToInt32(oRec["assignment_id"]);
										if (modGlobal.DuplicateAssignment(ViewModel.Empid, AssignID, AMGiveUpShiftDate))
										{
											if (modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD")
											{
												if (Convert.ToString(oRec["battalion_code"]) == "2")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN182DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else if (Convert.ToString(oRec["battalion_code"]) == "1")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN181DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else
												{
													// batt = 3
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN183DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
											}
											else
											{
												if (Convert.ToString(oRec["battalion_code"]) == "2")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN182ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else if (Convert.ToString(oRec["battalion_code"]) == "1")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN181ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else
												{
													// batt = 3
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "'," + modGlobal.ASGN183ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
											}
										}
										oCmd.CommandText = "spDeleteLeave '" + ViewModel.Empid + "','" + AMGiveUpShiftDate + "' ";
										oCmd.ExecuteNonQuery();
									}
								}
							}
							if (modGlobal.Clean(ViewModel.lbRequestPM.Text) != "")
							{
								//If Giveup date... Check to see if someone is already in the shift/position
								//DuplicateAssignment(EmpID As String, AssignID As Long, ThisShift As String)
								//if true change assignment to the appropriate Rover/Debit
								//then Delete Leave
								if (PMGiveUpShiftDate != "")
								{
									oCmd.CommandText = "sp_GetSchedAssign '" + ViewModel.Empid + "', '" + PMGiveUpShiftDate + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if (!oRec.EOF)
									{
										AssignID = Convert.ToInt32(oRec["assignment_id"]);
										if (modGlobal.DuplicateAssignment(ViewModel.Empid, AssignID, PMGiveUpShiftDate))
										{
											if (modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD")
											{
												if (Convert.ToString(oRec["battalion_code"]) == "2")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN182DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else if (Convert.ToString(oRec["battalion_code"]) == "1")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN181DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else
												{
													// Batt = 3
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN183DBT.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
											}
											else
											{
												if (Convert.ToString(oRec["battalion_code"]) == "2")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN182ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else if (Convert.ToString(oRec["battalion_code"]) == "1")
												{
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN181ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
												else
												{
													// Batt = 3
													SqlString = "spUpdateScheduleAssign '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "'," + modGlobal.ASGN183ROV.ToString() + ",'";
													SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
													oCmd.CommandText = SqlString;
													oCmd.ExecuteNonQuery();
												}
											}
										}
										oCmd.CommandText = "spDeleteLeave '" + ViewModel.Empid + "','" + PMGiveUpShiftDate + "' ";
										oCmd.ExecuteNonQuery();
									}
								}
							}
						}

						FillVacationAvailableGrid();
						FillVacationRequestGrid();
						FillVacationGrantedGrid();
						modGlobal.Shared.GivingUpShift = false;
	
					});
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			//Fill Employee Name List
			//ADODB

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			//int UDays = 0;
			string strName = "";
			// Not adding logic for gFCCSchedule right now...
			if (modGlobal.Shared.gParamedicSchedule)
			{
				ViewModel.chkPMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
				ViewModel.chkHZMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else if (modGlobal.Shared.gHazmatSchedule)
			{
				ViewModel.chkPMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkHZMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			else
			{
				ViewModel.chkPMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.chkHZMOnly.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			ViewModel.txtComment.Text = "";
			ViewModel.txtAvailComment.Text = "";
			ViewModel.txtUpdateComment.Text = "";
			ViewModel.cboKOT.Text = "";
			ViewModel.cboUpdateNameList.Text = "";
			ViewModel.ReqEmpid = "";
			ViewModel.lbVAC.Text = "0";
			ViewModel.lbHOL.Text = "0";
			ViewModel.lbUpdateVAC.Text = "0";
			ViewModel.lbUpdateHOL.Text = "0";
			ViewModel.frmRequestVAC.Visible = true;
			ViewModel.frmShiftAvail.Visible = false;
			ViewModel.frmUpdateRequest.Visible = false;
			ViewModel.optRequest.Checked = true;

			//Load Employee name list with Operations staff
			ViewModel.cboNameList.Items.Clear();
			ViewModel.cboReqNameList.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if (modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID")
			{

				//        If gUserBatt = "1" Or gSecurity = "ADM" Then
				ViewModel.LimitedPower = false;
				ViewModel.optDelete.Visible = true;
				ViewModel.optRequest.Visible = true;
				ViewModel.optUpdate.Visible = true;
				//        ElseIf gUserBatt = "2" Then
				//            LimitedPower = False
				//'            optAvailable.Visible = False
				//            optDelete.Visible = True
				//            optRequest.Visible = True
				//            optUpdate.Visible = True
				//        Else
				//            LimitedPower = True
				//'            optAvailable.Visible = False
				//            optDelete.Visible = True
				//            optRequest.Visible = True
				//            optUpdate.Visible = False
				//        End If

				oCmd.CommandText = "spOpNameList";
				oRec = ADORecordSetHelper.Open(oCmd, "");


				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					ViewModel.cboNameList.AddItem(strName);
					ViewModel.cboUpdateNameList.AddItem(strName);
					ViewModel.cboReqNameList.AddItem(strName);
					oRec.MoveNext();
				}
				;
				ViewModel.cboNameList.SelectedIndex = -1;
				ViewModel.cboUpdateNameList.SelectedIndex = -1;
				ViewModel.cboReqNameList.SelectedIndex = -1;
				ViewModel.cboKOT.SelectedIndex = -1;

				if (modGlobal.Shared.gReportUser != "")
				{
					ViewModel.Empid = modGlobal.Shared.gReportUser;
					modGlobal.Shared.gReportUser = "";
					for (int x = 0; x <= ViewModel.cboNameList.Items.Count - 1; x++)
					{
						//Come Here - for employee id change
						if ( ViewModel.Empid == ViewModel.cboNameList.GetListItem(x).Substring(Math.Max(ViewModel.cboNameList.GetListItem(x).Length - 5, 0)))
						{
							//Setting List Index will trigger list click event
							//This event will call FillSpread subroutine
							ViewModel.cboNameList.SelectedIndex = x;
							break;
						}
					}
				}

			}
			else
			{
				ViewModel.LimitedPower = true;
				//        optAvailable.Visible = False
				ViewModel.optDelete.Visible = true;
				ViewModel.optRequest.Visible = true;
				ViewModel.optUpdate.Visible = false;

				strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
				ViewModel.cboNameList.AddItem(strName);
				ViewModel.cboNameList.SelectedIndex = 0;
				ViewModel.cboUpdateNameList.AddItem(strName);
				ViewModel.cboReqNameList.AddItem(strName);
				ViewModel.cboUpdateNameList.SelectedIndex = 0;
				ViewModel.Empid = modGlobal.Shared.gUser;
				ViewModel.ReqEmpid = modGlobal.Shared.gUser;
				FillCurrVACList();
				FillCurrShiftList();

				modGlobal.Shared.gDetailDate = DateTime.Now.ToString("MM/dd/yyyy");

			}
			ViewModel.Text = ViewModel.Text + " for " + modGlobal.Shared.gDetailDate;
			FillVacationAvailableGrid();
			FillVacationRequestGrid();
			FillVacationGrantedGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void lstCurrSched_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdReqDone.Enabled = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAvailable_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.LimitedPower)
				{ //you shouldn't even see this option

					ViewModel.optAvailable.Checked = false;
					return;
				}
				if ( ViewModel.optAvailable.Checked)
				{
					ViewModel.frmShiftAvail.Visible = true;
					ViewModel.sprGranted.Visible = false;
					ViewModel.frmLegend.Visible = false;
					ViewModel.frmRequestVAC.Visible = false;
					ViewModel.frmUpdateRequest.Visible = false;
					ViewModel.calAvail.SelectionRange.Start = DateTime.Parse(modGlobal.Shared.gDetailDate);
					ViewModel.calAvail.SelectionRange.End = DateTime.Parse(modGlobal.Shared.gDetailDate);
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.ClearSelection();
				}

			}
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

				if ( ViewModel.optDelete.Checked)
				{
					ViewModel.frmRequestVAC.Visible = false;
					ViewModel.frmShiftAvail.Visible = false;
					ViewModel.frmUpdateRequest.Visible = false;
					ViewModel.sprGranted.Visible = true;
					ViewModel.frmLegend.Visible = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.ClearSelection();
					ViewModel.SelectedAvailable = 0;
					ViewModel.SelectedRequest = 0;
				}

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

				if ( ViewModel.optRequest.Checked)
				{
					ViewModel.frmRequestVAC.Visible = true;
					ViewModel.frmShiftAvail.Visible = false;
					ViewModel.frmUpdateRequest.Visible = false;
					ViewModel.sprGranted.Visible = true;
					ViewModel.frmLegend.Visible = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.ClearSelection();
					ViewModel.lbVAC.Text = "0";
					ViewModel.lbHOL.Text = "0";
				}

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optUpdate_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}

				if ( ViewModel.LimitedPower)
				{ //you shouldn't even see this option

					ViewModel.optUpdate.Checked = false;
					return;
				}
				if ( ViewModel.optUpdate.Checked)
				{
					ViewModel.frmRequestVAC.Visible = false;
					ViewModel.frmShiftAvail.Visible = false;
					ViewModel.frmUpdateRequest.Visible = true;
					ViewModel.cmdUpdateDone.Enabled = false;
					ViewModel.sprGranted.Visible = true;
					ViewModel.frmLegend.Visible = true;
					ViewModel.cboKOT.Text = "VAC";
					ViewModel.cboUpdateNameList.Text = "";
					ViewModel.calRequestDate.Text = modGlobal.Shared.gDetailDate;
					ViewModel.calGiveUpDate.Text = modGlobal.Shared.gDetailDate;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.ClearSelection();
					ViewModel.txtUpdateComment.Text = "";
					ViewModel.SelectedDate = "";
					ViewModel.SelectedAvailable = 0;
					ViewModel.SelectedRequest = 0;
					ViewModel.lbUpdateVAC.Text = "0";
					ViewModel.lbUpdateHOL.Text = "0";
				}

			}
		}

		private void sprAvailable_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Col = eventArgs.Column;
				int Row = eventArgs.Row;
				//if the headers were clicked exit
				if (Row == 0)
				{
					this.Return();
					return ;
				}
				ViewModel.sprAvailable.Row = Row;
				ViewModel.sprAvailable.Col = 2;
				if (modGlobal.Clean(ViewModel.sprAvailable.Text) == "")
				{

					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprAvailable.ClearSelection();
					this.Return();
					return ;
				}

				if ( ViewModel.sprAvailable.SelModeSelected)
				{
					if ( ViewModel.optDelete.Checked)
					{
						ViewModel.SelectedAvailable = Row;
						async1.Append(() =>
							{
								DeleteShiftsAvailableRecord();
							});
							}
							else if ( ViewModel.optUpdate.Checked)
					{
						ViewModel.SelectedAvailable = Row;

						//start filling in the frmUpdate field
						ViewModel.sprAvailable.Col = 2;
						ViewModel.calRequestDate.Text = ViewModel.sprAvailable.Text.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.sprAvailable.Text) - 5, ViewModel.sprAvailable.Text.Trim().Length));
						if ( ViewModel.SelectedDate == ViewModel.calRequestDate.Text)
						{
							if ( ViewModel.sprAvailable.Text.Trim().Substring(Math.Max(ViewModel.sprAvailable.Text.Trim().Length - 2, 0)) == "AM")
							{
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprAvailable.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbAvailAM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprAvailable.Text));
							}
							else
							{
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprAvailable.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbAvailPM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprAvailable.Text));
							}
						}
						else
						{
							ViewModel.SelectedDate = ViewModel.calRequestDate.Text;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprAvailable.ClearSelection();
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprRequests.ClearSelection();
							ViewModel.lbRequestAM.Text = "";
							ViewModel.lbRequestPM.Text = "";
							ViewModel.sprAvailable.Row = Row;
							ViewModel.sprAvailable.SelModeSelected = true;
							ViewModel.sprAvailable.Col = 2;
							if ( ViewModel.sprAvailable.Text.Trim().Substring(Math.Max(ViewModel.sprAvailable.Text.Trim().Length - 2, 0)) == "AM")
							{
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprAvailable.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbAvailAM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprAvailable.Text));
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
								ViewModel.lbAvailPM.Text = "";
							}
							else
							{
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprAvailable.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbAvailPM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprAvailable.Text));
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
								ViewModel.lbAvailAM.Text = "";
							}
						}
					}
				}
				else if ( ViewModel.optUpdate.Checked)
				{
					//un-selecting...
					ViewModel.sprAvailable.Col = 2;
					if ( ViewModel.sprAvailable.Text.Trim().Substring(Math.Max(ViewModel.sprAvailable.Text.Trim().Length - 2, 0)) == "AM")
					{
						ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.lbAvailAM.Text = "";
					}
					else
					{
						ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.lbAvailPM.Text = "";
					}
				}
			}


			}

		private void sprAvailable_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprAvailable.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprAvailable.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}

		}

		private void sprRequests_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Col = eventArgs.Column;
				int Row = eventArgs.Row;
				string sName = "";

				//if the headers were clicked exit
				if (Row == 0)
				{
					this.Return();
					return ;
				}
				ViewModel.sprRequests.Row = Row;
				ViewModel.sprRequests.Col = 2;
				if (modGlobal.Clean(ViewModel.sprRequests.Text) == "")
				{
					ViewModel.cboUpdateNameList.Text = "";
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprRequests.ClearSelection();
					this.Return();
					return ;
				}

				if ( ViewModel.sprRequests.SelModeSelected)
				{
					if ( ViewModel.optDelete.Checked)
					{
						ViewModel.SelectedRequest = Row;
						async1.Append(() =>
							{
								DeleteVacationRequestRecord();
							});
							}
							else if ( ViewModel.optUpdate.Checked)
					{
						ViewModel.SelectedRequest = Row;
						//start filling in the frmUpdate fields
						//name field
						ViewModel.sprRequests.Col = 2;
						sName = modGlobal.Clean(ViewModel.sprRequests.Text);
						//comment
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprRequests.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.txtUpdateComment.Text = modGlobal.Clean(ViewModel.sprRequests.CellNote);
						//employee id
						ViewModel.sprRequests.Col = 7;
						sName = sName + "  :" + modGlobal.Clean(ViewModel.sprRequests.Text);
						ViewModel.cboUpdateNameList.Text = sName;
						//request date
						ViewModel.sprRequests.Col = 4;
						ViewModel.calRequestDate.Text = ViewModel.sprRequests.Text.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.sprRequests.Text) - 5, ViewModel.sprRequests.Text.Trim().Length));
						//giveup date
						ViewModel.sprRequests.Col = 5;
						if (modGlobal.Clean(ViewModel.sprRequests.Text) != "")
						{
							ViewModel.lbgiveup.Visible = true;
							ViewModel.calGiveUpDate.Visible = true;
							ViewModel.chkGiveUpAM.Visible = true;
							ViewModel.chkGiveUpPM.Visible = true;
							ViewModel.calGiveUpDate.Text = ViewModel.sprRequests.Text.Trim().Substring(0, Math.Min(Strings.Len(ViewModel.sprRequests.Text) - 5, ViewModel.sprRequests.Text.Trim().Length));
							if ( ViewModel.sprRequests.Text.Trim().Substring(Math.Max(ViewModel.sprRequests.Text.Trim().Length - 2, 0)) == "AM")
							{
								ViewModel.chkGiveUpAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							}
							if ( ViewModel.sprRequests.Text.Trim().Substring(Math.Max(ViewModel.sprRequests.Text.Trim().Length - 2, 0)) == "PM")
							{
								ViewModel.chkGiveUpPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							}
						}
						else
						{
							ViewModel.lbgiveup.Visible = false;
							ViewModel.calGiveUpDate.Visible = false;
							ViewModel.chkGiveUpAM.Visible = false;
							ViewModel.chkGiveUpPM.Visible = false;
							ViewModel.calGiveUpDate.Text = modGlobal.Shared.gDetailDate;
						}
						if ( ViewModel.SelectedDate == ViewModel.calRequestDate.Text)
						{
							//request date
							ViewModel.sprRequests.Col = 4;
							if ( ViewModel.sprRequests.Text.Trim().Substring(Math.Max(ViewModel.sprRequests.Text.Trim().Length - 2, 0)) == "AM")
							{
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprRequests.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbRequestAM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprRequests.Text));
							}
							else
							{
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprRequests.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbRequestPM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprRequests.Text));
							}
						}
						else
						{
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprRequests.ClearSelection();
							ViewModel.lbAvailAM.Text = "";
							ViewModel.lbAvailPM.Text = "";
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprAvailable.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprAvailable.ClearSelection();
							ViewModel.sprRequests.Row = Row;
							ViewModel.sprRequests.SelModeSelected = true;
							ViewModel.SelectedDate = ViewModel.calRequestDate.Text;
							//request date
							ViewModel.sprRequests.Col = 4;
							if ( ViewModel.sprRequests.Text.Trim().Substring(Math.Max(ViewModel.sprRequests.Text.Trim().Length - 2, 0)) == "AM")
							{
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprRequests.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbRequestAM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprRequests.Text));
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
								ViewModel.lbRequestPM.Text = "";
							}
							else
							{
								ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
								ViewModel.sprRequests.Col = 6;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.lbRequestPM.Text = Convert.ToString(modGlobal.GetVal(ViewModel.sprRequests.Text));
								ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
								ViewModel.lbRequestAM.Text = "";
							}
						}
					}
				}
				else if ( ViewModel.optUpdate.Checked)
				{
					//un-selecting...
					ViewModel.sprRequests.Row = Row;
					ViewModel.sprRequests.Col = 4;
					if ( ViewModel.sprRequests.Text.Trim().Substring(Math.Max(ViewModel.sprRequests.Text.Trim().Length - 2, 0)) == "AM")
					{
						ViewModel.chkUpdateAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.lbRequestAM.Text = "";
					}
					else
					{
						ViewModel.chkUpdatePM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.lbRequestPM.Text = "";
					}
				}
			}

			}



		private void sprRequests_TextTipFetch(object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprRequests.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprRequests.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprRequests.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgVacationRequest DefInstance
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

		public static dlgVacationRequest CreateInstance()
		{
			PTSProject.dlgVacationRequest theInstance = Shared.Container.Resolve< dlgVacationRequest>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.frmUpdateRequest.LifeCycleStartup();
			ViewModel.frmShiftAvail.LifeCycleStartup();
			ViewModel.frmRequestVAC.LifeCycleStartup();
			ViewModel.sprAvailable.LifeCycleStartup();
			ViewModel.sprRequests.LifeCycleStartup();
			ViewModel.frmLegend.LifeCycleStartup();
			ViewModel.sprGranted.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmUpdateRequest.LifeCycleShutdown();
			ViewModel.frmShiftAvail.LifeCycleShutdown();
			ViewModel.frmRequestVAC.LifeCycleShutdown();
			ViewModel.sprAvailable.LifeCycleShutdown();
			ViewModel.sprRequests.LifeCycleShutdown();
			ViewModel.frmLegend.LifeCycleShutdown();
			ViewModel.sprGranted.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgVacationRequest
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgVacationRequestViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgVacationRequest m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}