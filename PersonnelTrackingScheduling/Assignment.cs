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

	public partial class frmAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmAssign));
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


		//*******************************************************
		//       Assign Position Form
		//   Called from...
		//           Add New Employee
		//           Update Employee
		//           Main Menu
		//   Form Load procedure determines if form should
		//   display Assignment data for a specific employee
		//       (not opened from main menu)
		//*******************************************************
		//ADODB

		public int ApproveTransfer(string Empid, int OldPos, int NewPos)
		{
			using ( var async1 = this.Async< int>(true) )
			{
				//Produce and display transfer Report Form
				//Receive OK or Cancel from Report Form
				//Return Value True if OK, False if Cancel Transfer

				int result = 0;
				result = -1;
				ViewManager.HideView(
					frmTransferReport.DefInstance);
				frmTransferReport.DefInstance.ViewModel.OldPos = OldPos;
				frmTransferReport.DefInstance.ViewModel.NewPos = NewPos;
				frmTransferReport.DefInstance.ViewModel.Empid = Empid;

				if (!frmTransferReport.DefInstance.FillSpread())
				{
					ViewManager.ShowMessage("Unable to produce Transfer Report - Transfer has been Canceled by System", "Assignment Transfer", UpgradeHelpers.Helpers
						.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					return this.Return< int>(() => 0);
				}
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							frmTransferReport.DefInstance, true);
					});
				async1.Append< int>(() =>
					{
						if (modGlobal.Shared.gTransCancel != 0)
						{
							return this.Return< int>(() => 0);
						}
						else
						{
							return this.Return< int>(() => -1);
						}
                        // Unreachable code
						//return this.Continue< int>(); 
					});

				return this.Return< int>(() => result);
			}
		}

		public void FindAssignment()
		{
			//Get Assignment Information for selected Employee

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			int Assignment = 0;

			try
			{

				//Initialize Assignment Detail Labels
				ViewModel.lbBatt.Text = "";
				ViewModel.lbUnit.Text = "";
				ViewModel.lbPosition.Text = "";
				ViewModel.lbShift.Text = "";
				ViewModel.lbAAssign.Text = "";

				//Retrieve assignment_id and assignment_status from Personnel record
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_PersonnelByEmpID '" + ViewModel.lbEmpID.Text + "' ";
				//    oCmd.CommandText = "SELECT * from Personnel WHERE employee_id ='" & lbEmpID & "'"
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//Determine if employee has current assignment
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (Convert.IsDBNull(oRec["assignment_id"]) || Convert.ToDouble(oRec["assignment_id"]) == 0)
				{
					return;
				}

				//Set assignment_id and assignment_status variables
				Assignment = Convert.ToInt32(oRec["assignment_id"]);
				if (Convert.ToBoolean(oRec["assignment_status"]))
				{
					ViewModel.lbAAssign.Text = "Active";
				}
				else
				{
					ViewModel.lbAAssign.Text = "Inactive";
				}

				//Retrieve Assignment Detail from Assignment record
				oCmd.CommandText = "spSelect_AssignmentByID " + Assignment.ToString() + " ";
				//    oCmd.CommandText = "select assignment_id, battalion_code, _
				//unit_code, position_code, shift_code from Assignment _
				//Where assignment_id = " & Assignment"
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if (!Convert.IsDBNull(oRec["battalion_code"]))
				{
					ViewModel.lbBatt.Text = Convert.ToString(oRec["battalion_code"]);
				}
				ViewModel.lbUnit.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.lbPosition.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.lbShift.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.lbAssign.Text = Convert.ToString(oRec["assignment_id"]);

				//Enable cmdAdjust control if Shift personnel
				ViewModel.cmdAdjust.Enabled = ViewModel.lbShift.Text != "*";
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
			//Assignment Form launched from Add New or Update Forms
			//Locate Active Employee and set NameList box
			//This will trigger FindAssignment and Fill PositionList


			for (int i = 0; i <= ViewModel.cboNameList.Items.Count - 1; i++)
			{
				//Come Here - for employee id change
				if ( ViewModel.cboNameList.GetListItem(i).Substring(Math.Max(ViewModel.cboNameList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gAssignID)
				{
					ViewModel.cboNameList.Text = ViewModel.cboNameList.GetListItem(i);
					break;
				}
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			FindAssignment();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Employee selected
			//Set employee_id label and global variables
			//call FindAssignment procedure to display

			if ( ViewModel.cboNameList.SelectedIndex == 0)
			{
				return;
			}
			//Come Here - for employee id change
			ViewModel.lbEmpID.Text = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));

			modGlobal.Shared.gAssignID = ViewModel.lbEmpID.Text;
			FindAssignment();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnitList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Position List with valid Positions
			//for selected Unit

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
            // Value never used
			//const int strUnit = 0;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spPositionList '" + ViewModel.cboUnitList.Text + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboPositionList.Items.Clear();


				while(!oRec.EOF)
				{
					ViewModel.cboPositionList.AddItem(Convert.ToString(oRec["position_code"]));
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

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdjust_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//If Employee Selected then display Adjust Assignment Form

			if (modGlobal.Shared.gAssignID == "")
			{
				ViewManager.ShowMessage("You must select an Employee first !", "Adjust Assignment Request", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewManager.NavigateToView(

				frmAdjustAssign.DefInstance);
			/*			frmAdjustAssign.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close form
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewPromo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//If Employee Selected then display New Promotion Form

			if (modGlobal.Shared.gAssignID == "")
			{
				ViewManager.ShowMessage("You must select an Employee first !", "New Promotion Request", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}
			ViewManager.NavigateToView(

				frmNewPromo.DefInstance);
			/*			frmNewPromo.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//refresh data Assignment Data for currently
			//selected employee

			if (modGlobal.Shared.gAssignID != "")
			{
				FindEmployee();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Update selected employee's assignment
				//check assignment selections to determine if valid
				//combination of unit, position & shift have been selected
				//test to determine if duplicate shift position
				int PerAssign = 0, Assignment = 0, CurrAssign = 0;
				string Msg = "";
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
                // Value Never Used
                //string Empid = "";
				int Dup = 0;
				int FourtyHourPosition = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdInsert = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
                // Value Never Used
                //object TransferDate = null;
				string JobCode = "";
				int Step = 0;
				string BattCode = "";
                // Values Never Used
                //int PENFlag = 0, TranFlag = 0;
                int CSRFlag = 0;

                bool IsSquad13 = false;
                CSRFlag = 0;
                // Value Never Used
				//string SchedDate = "";
				PTSProject.clsScheduler cTransfer = Container.Resolve< clsScheduler>();
				string s40hrPosition = "";
				string ShiftCode = "", strSQL = "", DebitGroup = "";
				bool IsParamedic = false;
				bool IsDispatcher = false;

				try
				{
					{

						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetAssign '" + ViewModel.cboUnitList.Text + "','" + ViewModel.cboPositionList.Text + "','" + ViewModel.cboShiftList.Text + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						//Test to verify valid assignment selection
						if (oRec.EOF)
						{
							ViewManager.ShowMessage("Invalid assignment - Please check shift selection", "Assignment Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}
						else
						{
							if ( ViewModel.cboUnitList.Text.Trim() == "BC01")
							{
								if ( ViewModel.cboPositionList.Text.StartsWith("ROV"))
								{
									Assignment = modGlobal.ASGN181ROV;
								}
								else
								{
									Assignment = Convert.ToInt32(oRec["assignment_id"]);
								}
							}
							else if ( ViewModel.cboUnitList.Text.Trim() == "BC02")
							{
								if ( ViewModel.cboPositionList.Text.StartsWith("ROV"))
								{
									Assignment = modGlobal.ASGN182ROV;
								}
								else
								{
									Assignment = Convert.ToInt32(oRec["assignment_id"]);
								}
							}
							else if ( ViewModel.cboUnitList.Text.Trim() == "BC03")
							{
								if ( ViewModel.cboPositionList.Text.StartsWith("ROV"))
								{
									Assignment = modGlobal.ASGN183ROV;
								}
								else
								{
									Assignment = Convert.ToInt32(oRec["assignment_id"]);
								}
							}
							else
							{
								Assignment = Convert.ToInt32(oRec["assignment_id"]);
							}
							PerAssign = Convert.ToInt32(oRec["assignment_id"]);
							ShiftCode = ViewModel.cboShiftList.Text;
							DebitGroup = modGlobal.Clean(oRec["debit_group_code"]);
							BattCode = modGlobal.Clean(oRec["battalion_code"]).Trim();

							if ( ViewModel.cboUnitList.Text.StartsWith("CSR"))
							{
								CSRFlag = -1;
							}
							else
							{
								CSRFlag = 0;
							}

							if (modGlobal.Clean(ViewModel.cboUnitList.Text) == "SQ13")
							{
								IsSquad13 = true;
								ViewManager.ShowMessage("No Schedule Created... call Debra Lewandowsky for help!", "Creating SQ13 Schedule", UpgradeHelpers.Helpers.BoxButtons.OK);
							}
							else
							{
								IsSquad13 = false;
							}
						}

						//Flag Dispatchers
						//Make Change Here  FCC = TFC
						if ( ViewModel.cboUnitList.Text.StartsWith("FCC"))
						{
							IsDispatcher = true;
						}
						else if ( ViewModel.cboUnitList.Text.StartsWith("CSRD"))
						{
							IsDispatcher = true;
						}
						else
						{
							IsDispatcher = false;
						}

						// Flag new 40 hour Positions
						FourtyHourPosition = 0;
						if ( ViewModel.cboPositionList.Text.StartsWith("FCCCP"))
						{
							FourtyHourPosition = -1;
							IsDispatcher = true;
							s40hrPosition = ViewModel.cboPositionList.Text.Substring(0, Math.Min(5, ViewModel.cboPositionList.Text.Length));
						}

						if ( ViewModel.cboPositionList.Text.StartsWith("FFDISP5") || ViewModel.cboPositionList.Text.StartsWith("FCCCP") || ViewModel.cboPositionList.Text.StartsWith("FCCCTO"))
						{
							FourtyHourPosition = -1;
							IsDispatcher = true;
							s40hrPosition = ViewModel.cboPositionList.Text.Substring(0, Math.Min(7, ViewModel.cboPositionList.Text.Length));
						}

						IsParamedic = false;
						//    check to see if this person is a Paramedic...
						oCmd.CommandText = "spSelect_PersonnelPMSpecialtyByEmployee '" + ViewModel.lbEmpID.Text + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							IsParamedic = true;
						}


						//Test for DuplicateAssignment
						//and to determine if employee is already assigned
						//to requested position
						oCmd.CommandText = "spSelect_PersonnelByAssignID " + PerAssign.ToString();
						oRec = ADORecordSetHelper.Open(oCmd, "");

						Dup = 0;
						if (!oRec.EOF && ShiftCode != "*")
						{

							while(!oRec.EOF)
							{
								if (Convert.ToString(oRec["employee_id"]) == ViewModel.lbEmpID.Text)
								{
									ViewManager.ShowMessage("This is already the Current Assignment", "Assignment Error", UpgradeHelpers.Helpers.BoxButtons.OK);
									this.Return();
									return ;
								}
								if (Convert.ToBoolean(oRec["assignment_status"]))
								{
									Dup = -1;
									break;
								}
								oRec.MoveNext();
							};
						}

						//If Duplicate Assignment with some other Employee as active
						//Give User choice to continue
						if (Dup != 0)
						{
							Msg = "This is a Duplicate Assignment.  Do you wish to Continue?";
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(Msg, "Assignment Error", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async1.Append(() =>
								{
									if (Response == UpgradeHelpers.Helpers.DialogResult.No)
									{
										this.Return();
										return ;
									}
								});
								}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									//Request transfer date, test for transfer request cancel
									modGlobal
										.Shared.gTransCancel = -1;
									modGlobal.Shared.gAssignID = ViewModel.lbEmpID.Text;
									async2.Append(() =>
										{
											ViewManager.NavigateToView(
												dlgTransfer.DefInstance, true);
										});
									async2.Append(() =>
										{
											using ( var async3 = this.Async() )
											{
												if (modGlobal.Shared.gTransCancel != 0)
												{
													this.Return();
													return ;
												}

												CurrAssign = Convert.ToInt32(Conversion.Val(ViewModel.lbAssign.Text));
												async3.Append<System.Int32>(() => ApproveTransfer(ViewModel.lbEmpID.Text, CurrAssign, PerAssign));
												async3.Append<System.Int32, System.Int32>(tempNormalized2 => tempNormalized2);
												async3.Append<System.Int32, System.Int32>(tempNormalized3 => ~tempNormalized3);
												async3.Append<System.Int32>(tempNormalized4 =>
													{

														//Call Function to produce Transfer Report and get final ok
														if ( tempNormalized4 != 0)
														{
															this.Return();
															return ;
														}
													});
												async3.Append(() =>
													{

														//if Perm Assignment, Update Assignment in Personnel record
														//if Temp Assignment, Update Assignment status in Personnel record

														if (ShiftCode == "*")
														{
															if (modGlobal.Shared.gTempTrans != 0)
															{
																oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + CurrAssign.ToString() + ",1,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
																oCmd.ExecuteNonQuery();
															}
															else
															{
																oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + PerAssign.ToString() + ",1,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
																oCmd.ExecuteNonQuery();
															}
														}
														else if (modGlobal.Shared.gTempTrans != 0)
														{
															if (Dup != 0)
															{
																oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + CurrAssign.ToString() + ",0,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
																oCmd.ExecuteNonQuery();
															}
															else
															{
																oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + CurrAssign.ToString() + ",1,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
																oCmd.ExecuteNonQuery();
															}
														}
														else if (Dup != 0)
														{
															oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + PerAssign.ToString() + ",0,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
															oCmd.ExecuteNonQuery();
														}
														else
														{
															oCmd.CommandText = "spUpdatePersonnelAssignment '" + ViewModel.lbEmpID.Text + "', " + PerAssign.ToString() + ",1,'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'";
															oCmd.ExecuteNonQuery();
														}

														//Check TransferPosition/TransferRequest -- NEW 10/2007
														if (~modGlobal.Shared.gTempTrans != 0)
														{
															if (cTransfer.CheckTransferRequestForEmployee(ViewModel.lbEmpID.Text, PerAssign) != 0)
															{
																//success...
															}
															else
															{
																//nothing...  the position can be inactivated manually
															}
														}

														//If old position was field position
														//Remove all future trades
														oCmd.CommandText = "sp_GetCancelTradeDetails '" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "','" + ViewModel.lbEmpID.Text + "'";
														oRec = ADORecordSetHelper.Open(oCmd, "");

														while(!oRec.EOF)
														{
															//Delete Scheduled Employees Trade Leave Record
															oCmd.CommandText = "spDeleteLeave '" + Convert.ToString(oRec["scheduled_emp"]) + "','" + Convert.ToString(oRec["trade_date"]) + "'";
															oCmd.ExecuteNonQuery();
															//Update Scheduled Employees Assignment to Current Working employees Assignment
															oCmd.CommandText = "spUpdateScheduleAssign '" + Convert.ToString(oRec["scheduled_emp"]) + "','" + Convert.ToString(
																					oRec["trade_date"]) + "'," + Convert.ToString(oRec["curr_assign"]) + ",'" +
																		UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
															oCmd.ExecuteNonQuery();
															//Delete Working Employees Schedule Record
															oCmd.CommandText = "spDeleteSchedule '" + Convert.ToString(oRec["working_emp"]) + "','" + Convert.ToString(oRec["trade_date"]) + "'";
															oCmd.ExecuteNonQuery();
															//Delete TradeHistory Record (Working Emps Schedule record will be deleted in next step)
															oCmd.CommandText = "spDeleteTradeHistory " + Convert.ToString(oRec["trade_id"]);
															oCmd.ExecuteNonQuery();
															oRec.MoveNext();
														};
														
														if (IsDispatcher && ShiftCode != "*")
														{
															oCmd.CommandText = "spDeleteFutureSchedule '" + ViewModel.lbEmpID.Text + "', '" + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "' ";
														}
														else if (IsParamedic && ShiftCode != "*")
														{
															oCmd.CommandText = "spDeleteFuturePMSchedule '" + ViewModel.lbEmpID.Text + "', '" + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', '" + ShiftCode + "' ";
														}
														else if (DebitGroup == "" && ShiftCode != "*")
														{
															oCmd.CommandText = "spDeleteFuturePMSchedule '" + ViewModel.lbEmpID.Text + "', '" + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', '" + ShiftCode + "' ";
														}
														else
														{
															oCmd.CommandText = "spDeleteFutureSchedule '" + ViewModel.lbEmpID.Text + "', '" + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "' ";
														}
														oCmd.ExecuteNonQuery();

														//Enable cmdAdjust for Shift positions
														ViewModel.cmdAdjust.Enabled = ShiftCode != "*";

														//If the position is already filled...
														//place person in appropiate Debit/Rover list
														//before creating new schedule records
														if (BattCode == "1")
														{

															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN181ROV.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN181DBT.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

														}
														else if (BattCode == "2")
														{
															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN182ROV.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN182DBT.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

														}
														else if (BattCode == "3")
														{

															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN183ROV.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN183DBT.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

														}
														else if (BattCode == "4")
														{
															strSQL = "spUpdate_ScheduleAssignmentsForTransfer " + modGlobal.ASGN184ROV.ToString() + ", '";
															strSQL = strSQL + modGlobal.Shared.gStartTrans + "', '" + modGlobal.Shared.gEndTrans + "', ";
															strSQL = strSQL + Assignment.ToString() + ", '" + ViewModel.lbEmpID.Text + "' ";
															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

														}

														//Retrieve Employee Data
														oCmd.CommandText = "sp_GetPersonnelDetail '" + ViewModel.lbEmpID.Text + "'";
														oRec = ADORecordSetHelper.Open(oCmd, "");
														JobCode = Convert.ToString(oRec["job_code_id"]);
														Step = Convert.ToInt32(oRec["step"]);

														//Insert New Reg or Rov Schedule Records
														if ((~CSRFlag & ~FourtyHourPosition & ((!IsSquad13) ? -1 : 0)) != 0)
														{
															strSQL = "spSelect_CalendarScheduleByShift '" + modGlobal.Shared.gStartTrans + "', '";
															strSQL = strSQL + modGlobal.Shared.gEndTrans + "', '" + ShiftCode + "' ";

															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");
															oCmdInsert.Connection = modGlobal.oConn;
															oCmdInsert.CommandType = CommandType.Text;


															while(!oRec.EOF)
															{
																oCmdInsert.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + ViewModel.lbEmpID.Text +
																						"'," + Assignment.ToString() + ",'REG',0,'" + JobCode + "'," + Step.ToString() +
																			",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																oCmdInsert.ExecuteNonQuery();
																oRec.MoveNext();
															};
														}

														//Insert New 40 Hour Schedules
														if (FourtyHourPosition != 0)
														{
															oCmd.CommandText = "sp_GetAM40HourSchedule '" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "'";
															oRec = ADORecordSetHelper.Open(oCmd, "");
															oCmdInsert.Connection = modGlobal.oConn;
															oCmdInsert.CommandType = CommandType.Text;


															while(!oRec.EOF)
															{
																oCmdInsert.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + ViewModel.lbEmpID.Text +
																						"'," + Assignment.ToString() + ",'REG',0,'" + JobCode + "'," + Step.ToString() +
																			",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																oCmdInsert.ExecuteNonQuery();
																oRec.MoveNext();
															};

															//Now anyones schedule assignment to Rov181 position who occupied spot
															oCmd.CommandText = "spUpdate_FCCAM40HourScheduleForTransfer '" + s40hrPosition + "', '" + modGlobal.Shared.
																		gStartTrans + "','" + modGlobal.Shared.gEndTrans + "', '" + ViewModel.lbEmpID.Text + "' ";
															oRec = ADORecordSetHelper.Open(oCmd, "");
															oCmdInsert.Connection = modGlobal.oConn;
															oCmdInsert.CommandType = CommandType.Text;

														}

														if (IsParamedic)
														{
															DebitGroup = "";
														}


														if (IsSquad13)
														{
															DebitGroup = "";
														}

														//Insert New Debit Schedule Records
														if (DebitGroup != "")
														{
															strSQL = "spSelect_CalendarScheduleByDebitGrp '" + modGlobal.Shared.gStartTrans + "', '";
															strSQL = strSQL + modGlobal.Shared.gEndTrans + "', '" + DebitGroup + "' ";

															oCmd.CommandText = strSQL;
															oRec = ADORecordSetHelper.Open(oCmd, "");

															while(!oRec.EOF)
															{
																if (BattCode == "3")
																{
																	oCmdInsert.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + ViewModel.lbEmpID.Text + "',"
																							+ modGlobal.ASGN183DBT.ToString() + ",'DDF',0,'" + JobCode + "'," + Step.ToString() +
																				",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																	oCmdInsert.ExecuteNonQuery();
																}
																else if (BattCode == "2")
																{
																	oCmdInsert.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + ViewModel.lbEmpID.Text + "',"
																							+ modGlobal.ASGN182DBT.ToString() + ",'DDF',0,'" + JobCode + "'," + Step.ToString() +
																				",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																	oCmdInsert.ExecuteNonQuery();
																}
																else
																{
																	oCmdInsert.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + ViewModel.lbEmpID.Text + "',"
																							+ modGlobal.ASGN181DBT.ToString() + ",'DDF',0,'" + JobCode + "'," + Step.ToString() +
																				",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																	oCmdInsert.ExecuteNonQuery();
																}
																oRec.MoveNext();
															};
														}

														FindAssignment();
														ViewManager.ShowMessage("Assignment Successfully Updated", "Update Assignment", UpgradeHelpers.Helpers.BoxButtons.OK);
													});
											}
										});
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		public void Form_Load()
		{
			//Determine if Form Load request from Add New or Update Form
			//If so set to current Employee (loaded in gAssignID global variable)
			//Fill Employee, Unit and Shift List boxes

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strName = "";

			try
			{

				//Establish data connection for Assignment Form access

				//Fill Shift list box
				ViewModel.cboShiftList.Items.Clear();
				ViewModel.cboShiftList.AddItem("A");
				ViewModel.cboShiftList.AddItem("B");
				ViewModel.cboShiftList.AddItem("C");
				ViewModel.cboShiftList.AddItem("D");
				ViewModel.cboShiftList.AddItem("*");
				ViewModel.cboShiftList.Text = ViewModel.cboShiftList.GetListItem(0); // Display first item.

				//Fill Unit List box

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spUnitList";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboUnitList.Items.Clear();

				while(!oRec.EOF)
				{
					ViewModel.cboUnitList.AddItem(Convert.ToString(oRec["unit_code"]));
					oRec.MoveNext();
				}
				;

				//Fill Name List Box
				oCmd.CommandText = "spFullNameList ";
				//    oCmd.CommandText = "Select employee_id, name_full from Personnel _
				//order by name_full"
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.cboNameList.Items.Clear();

				while(!oRec.EOF)
				{
					strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
					frmAssign.DefInstance.ViewModel.cboNameList.AddItem(strName);
					oRec.MoveNext();
				}
				;

				//If Specific employee fill current assignment data
				if (modGlobal.Shared.gAssignID != "")
				{
					FindEmployee();
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

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmAssign DefInstance
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

		public static frmAssign CreateInstance()
		{
			PTSProject.frmAssign theInstance = Shared.Container.Resolve< frmAssign>();
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
			ViewModel.Picture3.LifeCycleStartup();
			ViewModel.Picture2.LifeCycleStartup();
			ViewModel.Picture1.LifeCycleStartup();
			ViewModel.Shape2.LifeCycleStartup();
			ViewModel.Shape6.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Picture3.LifeCycleShutdown();
			ViewModel.Picture2.LifeCycleShutdown();
			ViewModel.Picture1.LifeCycleShutdown();
			ViewModel.Shape2.LifeCycleShutdown();
			ViewModel.Shape6.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmAssign m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}