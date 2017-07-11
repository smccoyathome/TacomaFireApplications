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

	public partial class frmTCEdit
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTCEditViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTCEdit));
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


		private void frmTCEdit_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}
		//*************************************
		// Displays TimeCard detail for Date  *
		// Selected on Individual Scheduler   *
		//*************************************
		//ADODB

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Clear lists
			for ( int i = 0; i <= 7; i++ )
			{
				ViewModel.cboKOT[i].Items.Clear();
				ViewModel.cboKOT[i].SelectedIndex = -1;
				ViewModel.cboKOT[i].Text = "";
				ViewModel.cboAAType[i].Items.Clear();
				ViewModel.cboAAType[i].SelectedIndex = -1;
				ViewModel.cboAAType[i].Text = "";
				ViewModel.cboLeave[i].Items.Clear();
				ViewModel.cboLeave[i].SelectedIndex = -1;
				ViewModel.cboLeave[i].Text = "";
				ViewModel.cboLeaveAA[i].Items.Clear();
				ViewModel.cboLeaveAA[i].SelectedIndex = -1;
				ViewModel.cboLeaveAA[i].Text = "";
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spJobCodeList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code lists

			while ( !oRec.EOF )
			{
				for ( int i = 0; i <= 7; i++ )
				{
					ViewModel.cboJobCode[i].AddItem(Convert.ToString(oRec["job_code_id"]));
				}
				oRec.MoveNext();
			};

			//Schedule Time Codes
			oCmd.CommandText = "spSelect_ScheduleTimeCodes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				for ( int i = 0; i <= 7; i++ )
				{
					ViewModel.cboKOT[i].AddItem(modGlobal.Clean(oRec["TimeCode"]));
					//UPGRADE_WARNING: (1068) GetVal(oRec(timecode_sys_id)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboKOT[i].SetItemData(ViewModel.cboKOT[i].GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
					ViewModel.cboAAType[i].AddItem(modGlobal.Clean(oRec["AAType"]));
					//UPGRADE_WARNING: (1068) GetVal(oRec(timecode_sys_id)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboAAType[i].SetItemData(ViewModel.cboAAType[i].GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
				}
				oRec.MoveNext();
			};

			//Leave Time Codes
			oCmd.CommandText = "spSelect_LeaveTimeCodes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				for ( int i = 0; i <= 7; i++ )
				{
					ViewModel.cboLeave[i].AddItem(modGlobal.Clean(oRec["TimeCode"]));
					//UPGRADE_WARNING: (1068) GetVal(oRec(timecode_sys_id)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboLeave[i].SetItemData(ViewModel.cboLeave[i].GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
					ViewModel.cboLeaveAA[i].AddItem(modGlobal.Clean(oRec["AAType"]));
					//UPGRADE_WARNING: (1068) GetVal(oRec(timecode_sys_id)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboLeaveAA[i].SetItemData(ViewModel.cboLeaveAA[i].GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
				}
				oRec.MoveNext();
			};

			}

		public void GetDetail()
		{
			//Select Employee Name and Schedule/Leave records for specificed date
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRecStep = null;
			string SQLScript = "";
			ViewModel.cmdTrade.Visible = false;
			ViewModel.cmdTrade.Enabled = false;
			ViewModel.txtNote.Text = "";
			ViewModel.DisplayNotes = false;
			ViewModel.Empid = modGlobal.Shared.gDetailEmp;
			ViewModel.StartDate = modGlobal.Shared.gDetailDate;
			ViewModel.EndDate = DateTime.Parse(ViewModel.StartDate).AddDays(1).ToString("M/d/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_Employee '" + ViewModel.Empid + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				return ;
			}

			if ( !oRec.EOF )
			{
				ViewModel.lbEmpName.Text = Convert.ToString(oRec["name_full"]).Trim();
				ViewModel.lbDate.Text = ViewModel.StartDate;
			}
			else
			{
				ViewManager.ShowMessage("Error retrieving Employee Details ", "Schedule Details Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			//Clear Display
			for ( int i = 0; i <= 7; i++ )
			{
				ViewModel.chkSCKFlag[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
				ViewModel.cboKOT[i].SelectedIndex = -1;
				ViewModel.cboAAType[i].SelectedIndex = -1;
				ViewModel.cboLeave[i].SelectedIndex = -1;
				ViewModel.cboLeaveAA[i].SelectedIndex = -1;
				ViewModel.cboJobCode[i].SelectedIndex = -1;
				ViewModel.cboStep[i].Items.Clear();
				ViewModel.txtHours[i].Text = "";
				ViewModel.lbUnit[i].Text = "";
				ViewModel.lbPosition[i].Text = "";
			}
			ViewModel.StartDate = ViewModel.StartDate + " 7:00AM";
			ViewModel.EndDate = ViewModel.EndDate + " 7:00AM";
			oCmd.CommandText = "sp_GetIndSchedule '" + ViewModel.Empid + "','" + ViewModel.StartDate + "','" + ViewModel.EndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			int CurrRow = 0;
			string TCLine = "";
			string NewTCLine = "";


			while ( !oRec.EOF )
			{
				if ( modGlobal.Clean(oRec["sched_time"]) == "TRD" )
				{
					ViewModel.cmdTrade.Visible = true;
					ViewModel.cmdTrade.Enabled = true;
				}
				if ( modGlobal.Clean(oRec["leave_time"]) == "TRD" )
				{
					ViewModel.cmdTrade.Visible = true;
					ViewModel.cmdTrade.Enabled = true;
				}
				NewTCLine = modGlobal.Clean(oRec["sick_leave_flag"]) + modGlobal.Clean(oRec["sched_time"]) + modGlobal.Clean(oRec["leave_time"]) + Convert.ToString(oRec["pay_upgrade"]) + modGlobal.Clean(oRec["job_code"]) + modGlobal.Clean(oRec["step"]) + modGlobal.Clean(oRec["unit_code"]) + modGlobal.Clean(oRec["position_code"]);
				if ( NewTCLine == TCLine )
				{
					ViewModel.txtHours[CurrRow - 1].Text = (Conversion.Val(ViewModel.txtHours[CurrRow - 1].Text) + 12).ToString();
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(sick_leave_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( Convert.ToDouble(modGlobal.GetVal(oRec["sick_leave_flag"])) == 1 )
					{
						ViewModel.chkSCKFlag[CurrRow].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
					}
					else
					{
						ViewModel.chkSCKFlag[CurrRow].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
					ViewModel.cboKOT[CurrRow].Text = modGlobal.Clean(oRec["sched_time"]);
					for ( int x = 0; x <= ViewModel.cboKOT[CurrRow].Items.Count - 1; x++ )
					{
						//UPGRADE_WARNING: (1068) GetVal(oRec(SchedTimeCodeID)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( ViewModel.cboKOT[CurrRow].GetItemData(x) == Convert.ToDouble(modGlobal.GetVal(oRec["SchedTimeCodeID"])) )
						{
							ViewModel.cboKOT[CurrRow].SelectedIndex = x;
							break;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if ( !Convert.IsDBNull(oRec["leave_time"]) )
					{
						ViewModel.cboLeave[CurrRow].Text = modGlobal.Clean(oRec["leave_time"]);
						for ( int x = 0; x <= ViewModel.cboLeave[CurrRow].Items.Count - 1; x++ )
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(TimeCodeID)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if ( ViewModel.cboLeave[CurrRow].GetItemData(x) == Convert.ToDouble(modGlobal.GetVal(oRec["TimeCodeID"])) )
							{
								ViewModel.cboLeave[CurrRow].SelectedIndex = x;
								break;
							}
						}
					}
					//UPGRADE_WARNING: (1068) GetVal(oRec(pay_upgrade)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( Convert.ToBoolean(modGlobal.GetVal(oRec["pay_upgrade"])) )
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( !Convert.IsDBNull(oRec["job_code"]) )
						{
							ViewModel.cboJobCode[CurrRow].Text = modGlobal.Clean(oRec["job_code"]);
							ViewModel.cboStep[CurrRow].Text = modGlobal.Clean(oRec["step"]);
							oCmd.CommandText = "sp_GetSteps '" + Convert.ToString(oRec["job_code"]) + "'";
							oRecStep = ADORecordSetHelper.Open(oCmd, "");
							UpgradeHelpers.DB.ADO.ADOFieldHelper tempForVar = oRecStep.GetField("no_steps");
							for ( int i = 1; i <= Convert.ToDouble(tempForVar.Value); i++ )
							{
								ViewModel.cboStep[CurrRow].AddItem(i.ToString());
							}

						}
					}
					ViewModel.txtHours[CurrRow].Text = "12";
					ViewModel.lbUnit[CurrRow].Text = modGlobal.Clean(oRec["unit_code"]).Trim();
					ViewModel.lbPosition[CurrRow].Text = modGlobal.Clean(oRec["position_code"]).Trim();
					CurrRow++;
					TCLine = NewTCLine;
				}
				oRec.MoveNext();
			};
			ViewModel.TotalLines = CurrRow;
			ViewModel.UpdateFlag = 0;
			ViewModel.lbWarn.Visible = false;

			if ( ViewModel.cboKOT[0].Text != "" )
			{
				if ( modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "CPT" )
				{
					ViewModel.cmdNotes.Visible = false;
					ViewModel.cmdDeleteNotes.Visible = false;
					ViewModel.txtNote.Visible = false;
					ViewModel.DisplayNotes = false;
				}
				else
				{
					if ( modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID" )
					{
						ViewModel.cmdNotes.Visible = true;
						ViewModel.cmdNotes.Enabled = true;
						ViewModel.txtNote.Visible = true;
						ViewModel.txtNote.Enabled = true;
						ViewModel.txtNote.BackColor = modGlobal.Shared.WHITE;
						ViewModel.DisplayNotes = true;
					}
					else
					{
						ViewModel.txtNote.Visible = true;
						ViewModel.txtNote.BackColor = modGlobal.Shared.LT_GRAY;
						ViewModel.txtNote.Enabled = false;
						ViewModel.cmdNotes.Enabled = false;
						ViewModel.DisplayNotes = true;
					}
				}
			}
			else if ( ViewModel.cboLeave[0].Text != "" )
			{
				if ( modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "CPT" )
				{
					ViewModel.cmdNotes.Visible = false;
					ViewModel.cmdDeleteNotes.Visible = false;
					ViewModel.txtNote.Visible = false;
					ViewModel.DisplayNotes = false;
				}
				else
				{
					if ( modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID" )
					{
						ViewModel.cmdNotes.Visible = true;
						ViewModel.cmdNotes.Enabled = true;
						ViewModel.txtNote.Visible = true;
						ViewModel.txtNote.Enabled = true;
						ViewModel.txtNote.BackColor = modGlobal.Shared.WHITE;
						ViewModel.DisplayNotes = true;
					}
					else
					{
						ViewModel.txtNote.Visible = true;
						ViewModel.txtNote.BackColor = modGlobal.Shared.LT_GRAY;
						ViewModel.txtNote.Enabled = false;
						ViewModel.cmdNotes.Enabled = false;
						ViewModel.DisplayNotes = true;
					}
				}
			}

			if ( ViewModel.DisplayNotes )
			{
				SQLScript = "Select * from PersonnelScheduleNotes Where employee_id = '";
				SQLScript = SQLScript + ViewModel.Empid + "' and datediff(day,'";
				System.DateTime TempDate = DateTime.FromOADate(0);
				SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.StartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.StartDate);
				SQLScript = SQLScript + "',shift_start) >= 0 and datediff(day,'";
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.EndDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ViewModel.EndDate);
				SQLScript = SQLScript + "',shift_start) < 0";

				oCmd.CommandText = SQLScript;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if ( !oRec.EOF )
				{
					ViewModel.txtNote.Text = "";
					ViewModel.cmdDeleteNotes.Visible = true;

					while ( !oRec.EOF )
					{
						ViewModel.txtNote.Text = modGlobal.Clean(ViewModel.txtNote.Text) + modGlobal.Clean(oRec["note"]).Trim() + ";  ";
						oRec.MoveNext();
					}
					;
				}
			}


			if ( ViewModel.txtNote.Text == "" )
			{
				ViewModel.cmdNotes.Text = "Add Notes";
				ViewModel.cmdNotes.Tag = "1";
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAAType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboAAType.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboAAType[Index].SelectedIndex == -1 )
			{
				return ;
			}


			for ( int i = 0; i <= ViewModel.cboKOT[Index].Items.Count - 1; i++ )
			{
				if ( ViewModel.cboKOT[Index].GetItemData(i) == ViewModel.cboAAType[Index].GetItemData(ViewModel.cboAAType[Index].SelectedIndex) )
				{
					ViewModel.cboKOT[Index].SelectedIndex = i;
					break;
				}
			}

			//Flag Change
			ViewModel.UpdateFlag = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboJobCode.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboJobCode[Index].SelectedIndex == -1 )
			{
				return ;
			}

			//Flag Change
			ViewModel.UpdateFlag = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboKOT_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboKOT.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboKOT[Index].SelectedIndex == -1 )
			{
				return ;
			}


			for ( int i = 0; i <= ViewModel.cboAAType[Index].Items.Count - 1; i++ )
			{
				if ( ViewModel.cboAAType[Index].GetItemData(i) == ViewModel.cboKOT[Index].GetItemData(ViewModel.cboKOT[Index].SelectedIndex) )
				{
					ViewModel.cboAAType[Index].SelectedIndex = i;
					break;
				}
			}

			//Flag Change
			ViewModel.UpdateFlag = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLeave_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboLeave.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboLeave[Index].SelectedIndex == -1 )
			{
				return ;
			}


			for ( int i = 0; i <= ViewModel.cboLeaveAA[Index].Items.Count - 1; i++ )
			{
				if ( ViewModel.cboLeaveAA[Index].GetItemData(i) == ViewModel.cboLeave[Index].GetItemData(ViewModel.cboLeave[Index].SelectedIndex) )
				{
					ViewModel.cboLeaveAA[Index].SelectedIndex = i;
					break;
				}
			}


			//Flag Change
			ViewModel.UpdateFlag = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLeaveAA_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboLeaveAA.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboLeaveAA[Index].SelectedIndex == -1 )
			{
				return ;
			}


			for ( int i = 0; i <= ViewModel.cboLeave[Index].Items.Count - 1; i++ )
			{
				if ( ViewModel.cboLeave[Index].GetItemData(i) == ViewModel.cboLeaveAA[Index].GetItemData(ViewModel.cboLeaveAA[Index].SelectedIndex) )
				{
					ViewModel.cboLeave[Index].SelectedIndex = i;
					break;
				}
			}

			//Flag Change
			ViewModel.UpdateFlag = -1;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboStep_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboStep.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//If no change selected
			if ( ViewModel.cboStep[Index].SelectedIndex == -1 )
			{
				return ;
			}

			//Flag Change
			ViewModel.UpdateFlag = -1;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				if ( ViewModel.UpdateFlag != 0 )
				{
				//Update Fields

				}

				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdNotes.Tag)) == 1 && ViewModel.txtNote.Text != "" )
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
							.ShowMessage("The Schedule Notes have not been saved." + "\n" + "\n" + "Did you want to exit now?", "Add Employee Schedule Notes", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
							{
								ViewManager.SetCurrent(ViewModel.cmdNotes);
								this.Return();
								return ;
							}
						});
				}
				async1.Append(() =>
					{
						ViewManager.DisposeView(this);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDeleteNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Function is coming soon!!", vbOKOnly, "Delete Personnel Schedule Notes"
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper orec2 = null;
			//string sqlscript2 = "";

			if ( !ViewModel.DisplayNotes )
			{
				return ;
			}

			if ( ViewModel.txtNote.Text == "" )
			{
				return ;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;

			string SQLScript = "Select * from PersonnelScheduleNotes Where employee_id = '";
			SQLScript = SQLScript + ViewModel.Empid + "' and datediff(day,'";
			System.DateTime TempDate = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.StartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.StartDate);
			SQLScript = SQLScript + "',shift_start) >= 0 and datediff(day,'";
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.EndDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ViewModel.EndDate);
			SQLScript = SQLScript + "',shift_start) <= 0";

			oCmd.CommandText = SQLScript;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{
				ViewModel.txtNote.Text = "";
				ViewModel.cmdDeleteNotes.Visible = false;

				while ( !oRec.EOF )
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ocmd2.CommandText = "spDeletePersonnelScheduleNotes " + Convert.ToString(modGlobal.GetVal(oRec["note_id"]));
					ocmd2.CommandType = CommandType.Text;
					ocmd2.ExecuteNonQuery();
					oRec.MoveNext();
				}
				;
			}
			ViewModel.cmdNotes.Text = "Add Note";
			ViewModel.cmdNotes.Tag = "1";
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( !ViewModel.DisplayNotes )
			{
				return ;
			}

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.cmdNotes.Tag)) == 0 )
			{
				ViewModel.txtNote.Text = "";
				ViewModel.cmdNotes.Text = "Add Note";
				ViewModel.cmdNotes.Tag = "1";
				return ;
			}

			if ( ViewModel.txtNote.Text == "" )
			{
				return ;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + ViewModel.Empid + "','" + ViewModel.StartDate + "','" + modGlobal.Clean(ViewModel.txtNote.Text) + "','" + modGlobal.Shared.gUser + "' ";
			oCmd.CommandType = CommandType.Text;
			oCmd.ExecuteNonQuery();

			string SQLScript = "Select * from PersonnelScheduleNotes Where employee_id = '";
			SQLScript = SQLScript + ViewModel.Empid + "' and datediff(day,'";
			System.DateTime TempDate = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.StartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.StartDate);
			SQLScript = SQLScript + "',shift_start) >= 0 and datediff(day,'";
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			SQLScript = SQLScript + ((DateTime.TryParse(ViewModel.EndDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ViewModel.EndDate);
			SQLScript = SQLScript + "',shift_start) <= 0";

			oCmd.CommandText = SQLScript;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{
				ViewModel.txtNote.Text = "";
				ViewModel.cmdDeleteNotes.Visible = true;

				while ( !oRec.EOF )
				{
					ViewModel.txtNote.Text = modGlobal.Clean(ViewModel.txtNote.Text) + modGlobal.Clean(oRec["note"]).Trim() + ";  ";
					oRec.MoveNext();
				}
				;
			}
			ViewModel.cmdNotes.Text = "New Note";
			ViewModel.cmdNotes.Tag = "0";
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSchedule_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				async1.Append<System.Int32>(() => modGlobal.ViewScheduleDetail(ViewModel.Empid, ViewModel.lbEmpName.Text, modGlobal.Shared.gDetailDate));
				async1.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
				async1.Append<System.Int32>(tempNormalized1 =>
					{
						if ( tempNormalized1 != 0 )
						{
						}
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdTrade_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			string sMessage = "";
			System.DateTime TempDate = DateTime.FromOADate(0);
			System.DateTime dBeginDate = DateTime.Parse((DateTime.TryParse(ViewModel.StartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.StartDate);

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetTradeDetail '" + ViewModel.Empid + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(dBeginDate) + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{

				sMessage = sMessage + ("\r") + ("\n") + Convert.ToString(oRec["WorkingEmployee"]).Trim() + " is working for " + Convert.ToString(oRec["ScheduledEmployee"]).Trim() + " - " + Convert.ToString(oRec["ShiftTime"]).Trim();
				sMessage = sMessage + ("\r") + ("\n") + "(Updated By: " + Convert.ToString(oRec["UpdatedBy"]).Trim() + " on " + Convert.ToString(oRec["UpdatedOn"]).Trim() + ")";
				sMessage = sMessage + ("\r") + ("\n");
				oRec.MoveNext();
			};
			ViewManager.ShowMessage(sMessage, "Trade Detail", UpgradeHelpers.Helpers.BoxButtons.OK);


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Select Employee Name and Schedule/Leave records for specificed date
			//int i = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;

			//    oCmd.ActiveConnection = oConn
			//    oCmd.CommandType = adCmdText


			LoadLists();

			GetDetail();

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
			//Clear Global Variables
			modGlobal
				.Shared.gDetailEmp = "";
			modGlobal.Shared.gDetailDate = "";
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtHours_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.UpdateFlag = -1;
		}

		public static frmTCEdit DefInstance
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
				return Shared.m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmTCEdit CreateInstance()
		{
			PTSProject.frmTCEdit theInstance = Shared.Container.Resolve<frmTCEdit>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
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

	public partial class frmTCEdit
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTCEditViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTCEdit m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}