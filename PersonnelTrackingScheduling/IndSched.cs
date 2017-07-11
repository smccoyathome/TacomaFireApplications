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

	public partial class frmIndSched
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndSchedViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		//*************************************************************
		//Update Individual Leave Form
		//This form allows for Adding, Updating and deleting Leave
		//for Operations field staff
		//Form displays Individuals personnel and assignment info
		//Leave scheduled and remaining leave balances
		//Number of staff scheduled for leave on a selected date
		//is displayed.
		//Senority Ranking Inquiry can be accessed from this form
		//*************************************************************
		//ADODB
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndSched));
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



		public void CheckForUpgrade()
		{
			using ( var async1 = this.Async(true) )
			{

				string AMDate = "";
				string PMDate = "";
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				if ( ViewModel.FirstTime != 0 )
				{
					this.Return();
					return ;
				}
				//Come Here - for employee id change
				string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
				{
					AMDate = ViewModel.calLeaveDate.Text + " 7:00AM";
					PMDate = ViewModel.calLeaveDate.Text + " 7:00PM";
				}
				else if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
				{
					AMDate = ViewModel.calLeaveDate.Text + " 7:00AM";
					PMDate = "";
				}
				else if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
				{
					PMDate = ViewModel.calLeaveDate.Text + " 7:00PM";
					AMDate = "";
				}
				else
				{
					ViewManager.ShowMessage("You must check AM and/or PM", "Individual Leave Scheduler ", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				//Get current Job Code & Step
				string JobCode = modGlobal.GetJobCode(Empid);
				int Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

				//Get Employee's Schedule
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				if ( AMDate != "" )
				{
					oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + AMDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
									ViewManager.ShowMessage("Employee is scheduled for PayUpgrade.  Do you want to keep it?", "Pay Upgrade", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async1.Append(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
									{
										oCmdUpdate.Connection = modGlobal.oConn;
										oCmdUpdate.CommandType = CommandType.StoredProcedure;
										oCmdUpdate.CommandText = "spUpdateSchedulePay";
										oCmdUpdate.ExecuteNonQuery(new object[] { Empid, AMDate, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
									}
								});
						}
					}
				}

				if ( PMDate != "" )
				{
					oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + PMDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
									ViewManager.ShowMessage("Employee is scheduled for PayUpgrade.  Do you want to keep it?", "Pay Upgrade", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
								{
									Response = tempNormalized3;
								});
							async1.Append(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
									{
										oCmdUpdate.Connection = modGlobal.oConn;
										oCmdUpdate.CommandType = CommandType.StoredProcedure;
										oCmdUpdate.CommandText = "spUpdateSchedulePay";
										oCmdUpdate.ExecuteNonQuery(new object[] { Empid, PMDate, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
									}
								});
						}
					}
				}
			}

		}

		public void SetAnnualCycleDays()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.Constants_SelectionType property Constants_SelectionType.ssSelectionTypeMultiSelect was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.SelectionType was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//ViewModel.calSched.setSelectionType(UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionType.getssSelectionTypeMultiSelect());
			ViewModel.SkipProcess = -1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_AnnualCalendarCycleDays '" + modGlobal.Shared.gCurrentYear.ToString() + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				return ;
			}
			else
			{
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calSched.getX().SelectedDays.RemoveAll();
			}


			while ( !oRec.EOF )
			{
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calSched.getX().SelectedDays.Add(Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy"));
				oRec.MoveNext();
        };

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			for ( int i = 0; i <= Convert.ToDouble(ViewModel.calSched.getX().SelectedDays.Count) - 1; i++ )
			{
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calSched.getX().SelectedDays(i).Caption = "*";
			}

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().SelectedDays.RemoveAll();
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.Constants_SelectionType property Constants_SelectionType.ssSelectionTypeSingleSelect was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.SelectionType was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.calSched.setSelectionType(UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionType.getssSelectionTypeSingleSelect());
			ViewModel.SkipProcess = 0;

			if ( modGlobal.Shared.gCurrentYear == DateTime.Now.Year )
			{
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calSched.getX().SelectedDays.Add(DateTime.Now.ToString("M/d/yyyy"));
				ViewModel.calLeaveDate.Value = DateTime.Parse(DateTime.Now.ToString("M/d/yyyy"));
			}

		}

		public void CreateVacBankStyleSets()
		{

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBank").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBank").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBank").Picture = modGlobal.IMAGEPATH + "amVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankTRD").Picture = modGlobal.IMAGEPATH + "amVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankOT").Picture = modGlobal.IMAGEPATH + "amVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBank").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankTRD").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankOT").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankNote").Picture = modGlobal.IMAGEPATH + "amVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankNote").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankNote").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankTRD").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBank").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankNote").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankTRD").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankOT").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacBankOT").Font.Bold = true;

			//Vacation (Red)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBank").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalf").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalf").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalf").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalf").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOth").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOth").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHol").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHol").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMil").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMil").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKel").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKel").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrd").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrd").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDeb").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDeb").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedu").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedu").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankNote").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdNote").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthNote").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolNote").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilNote").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelNote").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebNote").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfNote").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfNote").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedunote").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankedunote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankOT").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdOT").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankTrdOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthOT").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolOT").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilOT").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelOT").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebOT").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfOT").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfOT").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduOT").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankTRD").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthTRD").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankOthTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolTRD").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankHolTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilTRD").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankMilTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelTRD").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankKelTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebTRD").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacBankDebTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfTRD").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacBankHalfTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfTRD").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacBankHalfTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduTRD").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacBankeduTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBank").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankNote").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankOT").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankTRD").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBank").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankNote").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankTRD").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankOT").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBank").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankNote").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankOT").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankTRD").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBank").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankNote").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankNote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankTRD").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankTRD").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankOT").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBank").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBank").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBank").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBank").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBanknote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBanknote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBanknote").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBanknote").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankOT").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankOT").Font.Bold = true;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankTRD").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacBankTRD").Font.Bold = true;

		}

		public void CreateLeaveStyleSets()
		{

			//Other Leave (Purple)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Other").BackColor = modGlobal.COTHER;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Other").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Other").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalf").Picture = modGlobal.IMAGEPATH + "pmothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalf").Picture = modGlobal.IMAGEPATH + "amothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVac").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHol").Picture = modGlobal.IMAGEPATH + "OthHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMil").Picture = modGlobal.IMAGEPATH + "OthMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKel").Picture = modGlobal.IMAGEPATH + "Othkel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDeb").Picture = modGlobal.IMAGEPATH + "OthDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrd").Picture = modGlobal.IMAGEPATH + "Othtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrd").Font.Bold = false;

			//Added this 7/28/2015... rarely used
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdTRD").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdTRD").Picture = modGlobal.IMAGEPATH + "Othtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedu").Picture = modGlobal.IMAGEPATH + "othedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherNote").BackColor = modGlobal.COTHER;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacNote").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdNote").Picture = modGlobal.IMAGEPATH + "Othtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolNote").Picture = modGlobal.IMAGEPATH + "OthHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilNote").Picture = modGlobal.IMAGEPATH + "OthMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelNote").Picture = modGlobal.IMAGEPATH + "Othkel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebNote").Picture = modGlobal.IMAGEPATH + "OthDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfNote").Picture = modGlobal.IMAGEPATH + "amothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfNote").Picture = modGlobal.IMAGEPATH + "pmothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedunote").Picture = modGlobal.IMAGEPATH + "othedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("othedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherTRD").BackColor = modGlobal.COTHER;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacTRD").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolTRD").Picture = modGlobal.IMAGEPATH + "OthHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilTRD").Picture = modGlobal.IMAGEPATH + "OthMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelTRD").Picture = modGlobal.IMAGEPATH + "Othkel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebTRD").Picture = modGlobal.IMAGEPATH + "OthDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfTRD").Picture = modGlobal.IMAGEPATH + "amothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfTRD").Picture = modGlobal.IMAGEPATH + "pmothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduTRD").Picture = modGlobal.IMAGEPATH + "othedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherOT").BackColor = modGlobal.COTHER;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OtherOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacOT").Picture = modGlobal.IMAGEPATH + "OthVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdOT").Picture = modGlobal.IMAGEPATH + "Othtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdOT ").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolOT").Picture = modGlobal.IMAGEPATH + "OthHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilOT").Picture = modGlobal.IMAGEPATH + "OthMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelOT").Picture = modGlobal.IMAGEPATH + "Othkel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebOT").Picture = modGlobal.IMAGEPATH + "OthDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("OthDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfOT").Picture = modGlobal.IMAGEPATH + "amothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfOT").Picture = modGlobal.IMAGEPATH + "pmothhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduOT").Picture = modGlobal.IMAGEPATH + "othedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("otheduOT").Font.Bold = false;

			//Vacation (Red)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Vacation").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Vacation").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Vacation").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalf").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalf").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOth").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHol").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMil").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKel").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrd").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDeb").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedu").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationNote").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdNote").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthNote").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolNote").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilNote").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelNote").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebNote").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfNote").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfNote").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedunote").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vacedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationOT").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdOT").Picture = modGlobal.IMAGEPATH + "vactrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthOT").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolOT").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilOT").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelOT").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebOT").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfOT").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfOT").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduOT").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationTRD").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED); //RGB(255, 0, 0)

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacationTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthTRD").Picture = modGlobal.IMAGEPATH + "VacOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolTRD").Picture = modGlobal.IMAGEPATH + "VacHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilTRD").Picture = modGlobal.IMAGEPATH + "VacMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelTRD").Picture = modGlobal.IMAGEPATH + "VacKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebTRD").Picture = modGlobal.IMAGEPATH + "VacDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("VacDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfTRD").Picture = modGlobal.IMAGEPATH + "amvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfTRD").Picture = modGlobal.IMAGEPATH + "pmvachalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduTRD").Picture = modGlobal.IMAGEPATH + "vacedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("vaceduTRD").Font.Bold = false;


			//Holiday (Yellow)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Holiday").BackColor = modGlobal.CHOLIDAY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Holiday").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Holiday").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalf").Picture = modGlobal.IMAGEPATH + "amholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalf").Picture = modGlobal.IMAGEPATH + "pmholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOth").Picture = modGlobal.IMAGEPATH + "HolOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVac").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMil").Picture = modGlobal.IMAGEPATH + "HolMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKel").Picture = modGlobal.IMAGEPATH + "HolKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDeb").Picture = modGlobal.IMAGEPATH + "HolDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrd").Picture = modGlobal.IMAGEPATH + "holtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedu").Picture = modGlobal.IMAGEPATH + "holedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayNote").BackColor = modGlobal.CHOLIDAY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdNote").Picture = modGlobal.IMAGEPATH + "holtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacNote").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthNote").Picture = modGlobal.IMAGEPATH + "HolOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilNote").Picture = modGlobal.IMAGEPATH + "HolMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelNote").Picture = modGlobal.IMAGEPATH + "HolKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebNote").Picture = modGlobal.IMAGEPATH + "HolDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfNote").Picture = modGlobal.IMAGEPATH + "amholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfNote").Picture = modGlobal.IMAGEPATH + "pmholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedunote").Picture = modGlobal.IMAGEPATH + "holedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayOT").BackColor = modGlobal.CHOLIDAY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdOT").Picture = modGlobal.IMAGEPATH + "holtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacOT").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthOT").Picture = modGlobal.IMAGEPATH + "HolOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilOT").Picture = modGlobal.IMAGEPATH + "HolMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelOT").Picture = modGlobal.IMAGEPATH + "HolKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebOT").Picture = modGlobal.IMAGEPATH + "HolDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfOT").Picture = modGlobal.IMAGEPATH + "amholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfOT").Picture = modGlobal.IMAGEPATH + "pmholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduOT").Picture = modGlobal.IMAGEPATH + "holedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayTRD").BackColor = modGlobal.CHOLIDAY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolidayTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacTRD").Picture = modGlobal.IMAGEPATH + "HolVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthTRD").Picture = modGlobal.IMAGEPATH + "HolOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilTRD").Picture = modGlobal.IMAGEPATH + "HolMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelTRD").Picture = modGlobal.IMAGEPATH + "HolKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebTRD").Picture = modGlobal.IMAGEPATH + "HolDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("HolDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfTRD").Picture = modGlobal.IMAGEPATH + "amholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfTRD").Picture = modGlobal.IMAGEPATH + "pmholhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduTRD").Picture = modGlobal.IMAGEPATH + "holedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("holeduTRD").Font.Bold = false;


			//Kelly (Orange)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Kelly").BackColor = modGlobal.CKELLY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Kelly").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Kelly").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalf").Picture = modGlobal.IMAGEPATH + "pmkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalf").Picture = modGlobal.IMAGEPATH + "amkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOth").Picture = modGlobal.IMAGEPATH + "KelOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVac").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHol").Picture = modGlobal.IMAGEPATH + "KelHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMil").Picture = modGlobal.IMAGEPATH + "KelMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDeb").Picture = modGlobal.IMAGEPATH + "KelDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrd").Picture = modGlobal.IMAGEPATH + "KelTrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledu").Picture = modGlobal.IMAGEPATH + "keledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdNote").Picture = modGlobal.IMAGEPATH + "KelTrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthNote").Picture = modGlobal.IMAGEPATH + "KelOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyNote").BackColor = modGlobal.CKELLY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacNote").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolNote").Picture = modGlobal.IMAGEPATH + "KelHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilNote").Picture = modGlobal.IMAGEPATH + "KelMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebNote").Picture = modGlobal.IMAGEPATH + "KelDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfNote").Picture = modGlobal.IMAGEPATH + "amkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfNote").Picture = modGlobal.IMAGEPATH + "pmkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledunote").Picture = modGlobal.IMAGEPATH + "keledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keledunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyTRD").BackColor = modGlobal.CKELLY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfTRD").Picture = modGlobal.IMAGEPATH + "pmkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfTRD").Picture = modGlobal.IMAGEPATH + "amkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthTRD").Picture = modGlobal.IMAGEPATH + "KelOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacTRD").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolTRD").Picture = modGlobal.IMAGEPATH + "KelHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilTRD").Picture = modGlobal.IMAGEPATH + "KelMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebTRD").Picture = modGlobal.IMAGEPATH + "KelDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduTRD").Picture = modGlobal.IMAGEPATH + "keledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyOT").BackColor = modGlobal.CKELLY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KellyOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfOT").Picture = modGlobal.IMAGEPATH + "pmkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfOT").Picture = modGlobal.IMAGEPATH + "amkelhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthOT").Picture = modGlobal.IMAGEPATH + "KelOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacOT").Picture = modGlobal.IMAGEPATH + "KelVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolOT").Picture = modGlobal.IMAGEPATH + "KelHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilOT").Picture = modGlobal.IMAGEPATH + "KelMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebOT").Picture = modGlobal.IMAGEPATH + "KelDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdOT").Picture = modGlobal.IMAGEPATH + "KelTrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("KelTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduOT").Picture = modGlobal.IMAGEPATH + "keledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("keleduOT").Font.Bold = false;


			//Military (Brown)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Military").BackColor = modGlobal.CMILITARY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Military").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Military").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalf").Picture = modGlobal.IMAGEPATH + "pmmilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalf").Picture = modGlobal.IMAGEPATH + "ammilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOth").Picture = modGlobal.IMAGEPATH + "MilOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVac").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHol").Picture = modGlobal.IMAGEPATH + "MilHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKel").Picture = modGlobal.IMAGEPATH + "MilKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDeb").Picture = modGlobal.IMAGEPATH + "MilDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrd").Picture = modGlobal.IMAGEPATH + "Miltrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledu").Picture = modGlobal.IMAGEPATH + "miledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdNote").Picture = modGlobal.IMAGEPATH + "Miltrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdOT").Picture = modGlobal.IMAGEPATH + "Miltrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthNote").Picture = modGlobal.IMAGEPATH + "MilOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthOT").Picture = modGlobal.IMAGEPATH + "MilOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthTRD").Picture = modGlobal.IMAGEPATH + "MilOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryNote").BackColor = modGlobal.CMILITARY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryOT").BackColor = modGlobal.CMILITARY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryTRD").BackColor = modGlobal.CMILITARY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilitaryTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolNote").Picture = modGlobal.IMAGEPATH + "MilHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolOT").Picture = modGlobal.IMAGEPATH + "MilHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolTRD").Picture = modGlobal.IMAGEPATH + "MilHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacNote").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelNote").Picture = modGlobal.IMAGEPATH + "MilKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebNote").Picture = modGlobal.IMAGEPATH + "MilDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfNote").Picture = modGlobal.IMAGEPATH + "ammilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfNote").Picture = modGlobal.IMAGEPATH + "pmmilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledunote").Picture = modGlobal.IMAGEPATH + "miledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("miledunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduOT").Picture = modGlobal.IMAGEPATH + "miledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduTRD").Picture = modGlobal.IMAGEPATH + "miledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("mileduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacOT").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelOT").Picture = modGlobal.IMAGEPATH + "MilKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebOT").Picture = modGlobal.IMAGEPATH + "MilDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfOT").Picture = modGlobal.IMAGEPATH + "ammilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfOT").Picture = modGlobal.IMAGEPATH + "pmmilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacTRD").Picture = modGlobal.IMAGEPATH + "MilVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelTRD").Picture = modGlobal.IMAGEPATH + "MilKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebTRD").Picture = modGlobal.IMAGEPATH + "MilDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("MilDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfTRD").Picture = modGlobal.IMAGEPATH + "ammilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfTRD").Picture = modGlobal.IMAGEPATH + "pmmilhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilHalfTRD").Font.Bold = false;

		}

		public void CreateStyleSets()
		{

			//Defaults (White)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Default").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Default").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Default").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Default").Picture = "";

			//Regular Schedule (Blue)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amReg").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amReg").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amReg").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amReg").Picture = modGlobal.IMAGEPATH + "amreg.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamReg").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamReg").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamReg").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamReg").Picture = modGlobal.IMAGEPATH + "amreg.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRegNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRegNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRegNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRegNote").Picture = modGlobal.IMAGEPATH + "amreg.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmReg").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmReg").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmReg").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmReg").Picture = modGlobal.IMAGEPATH + "pmreg.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmReg").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmReg").Picture = modGlobal.IMAGEPATH + "pmreg.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmReg").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmReg").ForeColor = modGlobal.CTRADE; //Trade font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRegNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRegNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRegNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRegNote").Picture = modGlobal.IMAGEPATH + "pmreg.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Regular").BackColor = modGlobal.CREGULAR;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Regular").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Regular").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Reverse").BackColor = modGlobal.CREGULAR;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Reverse").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Reverse").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseNote").BackColor = modGlobal.CREGULAR;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDeb").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDeb").Picture = modGlobal.IMAGEPATH + "amdeb.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDeb").Picture = modGlobal.IMAGEPATH + "amdeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDeb").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDeb").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebNote").Picture = modGlobal.IMAGEPATH + "amdeb.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDeb").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDeb").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDeb").Picture = modGlobal.IMAGEPATH + "pmdeb.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDeb").Picture = modGlobal.IMAGEPATH + "pmdeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDeb").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDeb").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebNote").BackColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebNote").Picture = modGlobal.IMAGEPATH + "pmdeb.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOth").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOth").Picture = modGlobal.IMAGEPATH + "amOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthOT").Picture = modGlobal.IMAGEPATH + "amOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthTRD").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthTRD").Picture = modGlobal.IMAGEPATH + "amOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOth").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOth").Picture = modGlobal.IMAGEPATH + "pmOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthOT").Picture = modGlobal.IMAGEPATH + "pmOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthTRD").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthTRD").Picture = modGlobal.IMAGEPATH + "pmOth.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVac").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVac").Picture = modGlobal.IMAGEPATH + "amVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacTRD").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacTRD").Picture = modGlobal.IMAGEPATH + "amVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacOT").Picture = modGlobal.IMAGEPATH + "amVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVac").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVac").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacTRD").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacTRD").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacOT").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHol").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHol").Picture = modGlobal.IMAGEPATH + "amhol.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHol").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHol").Picture = modGlobal.IMAGEPATH + "pmHol.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrd").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrd").Picture = modGlobal.IMAGEPATH + "amTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdOT").Picture = modGlobal.IMAGEPATH + "amTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdNote").Picture = modGlobal.IMAGEPATH + "amTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrd").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrd").Picture = modGlobal.IMAGEPATH + "pmTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdOT").Picture = modGlobal.IMAGEPATH + "pmTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdNote").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdNote").Picture = modGlobal.IMAGEPATH + "pmTrd.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKel").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKel").Picture = modGlobal.IMAGEPATH + "amKel.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKel").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKel").Picture = modGlobal.IMAGEPATH + "pmKel.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMil").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMil").Picture = modGlobal.IMAGEPATH + "amMil.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMil").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMil").Picture = modGlobal.IMAGEPATH + "pmMil.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedu").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedu").Picture = modGlobal.IMAGEPATH + "amedu.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedu").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedu").Picture = modGlobal.IMAGEPATH + "pmedu.bmp";

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseOT").BackColor = modGlobal.CREGULAR;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ReverseOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDebOT").Picture = modGlobal.IMAGEPATH + "amdeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDebOT").Font.Bold = false;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDebOT").Picture = modGlobal.IMAGEPATH + "pmdeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamRegOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamRegOT").Picture = modGlobal.IMAGEPATH + "amreg.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamRegOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevamRegOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmRegOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmRegOT").Picture = modGlobal.IMAGEPATH + "pmreg.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmRegOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevpmRegOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthNote").Picture = modGlobal.IMAGEPATH + "amOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthNote").Picture = modGlobal.IMAGEPATH + "pmOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacNote").Picture = modGlobal.IMAGEPATH + "amVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacNote").Picture = modGlobal.IMAGEPATH + "pmVac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolNote").Picture = modGlobal.IMAGEPATH + "amhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolOT").Picture = modGlobal.IMAGEPATH + "amhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolTRD").Picture = modGlobal.IMAGEPATH + "amhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolNote").Picture = modGlobal.IMAGEPATH + "pmHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolTRD").Picture = modGlobal.IMAGEPATH + "pmHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolOT").Picture = modGlobal.IMAGEPATH + "pmHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilNote").Picture = modGlobal.IMAGEPATH + "amMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").Picture = modGlobal.IMAGEPATH + "pmMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilOT").Picture = modGlobal.IMAGEPATH + "amMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilTRD").Picture = modGlobal.IMAGEPATH + "amMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").Picture = modGlobal.IMAGEPATH + "pmMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilOT").Picture = modGlobal.IMAGEPATH + "pmMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilTRD").Picture = modGlobal.IMAGEPATH + "pmMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelNote").Picture = modGlobal.IMAGEPATH + "amKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelTRD").Picture = modGlobal.IMAGEPATH + "amKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelOT").Picture = modGlobal.IMAGEPATH + "amKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelNote").Picture = modGlobal.IMAGEPATH + "pmKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelOT").Picture = modGlobal.IMAGEPATH + "pmKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelTRD").Picture = modGlobal.IMAGEPATH + "pmKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedunote").Picture = modGlobal.IMAGEPATH + "amedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduTRD").Picture = modGlobal.IMAGEPATH + "amedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduOT").Picture = modGlobal.IMAGEPATH + "amedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("ameduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedunote").Picture = modGlobal.IMAGEPATH + "pmedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduOT").Picture = modGlobal.IMAGEPATH + "pmedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduTRD").Picture = modGlobal.IMAGEPATH + "pmedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmeduTRD").Font.Bold = false;


			//Debit (Lt Blue)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Debit").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Debit").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Debit").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDeb").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDeb").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebOT").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebNote").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("RevDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalf").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalf").Picture = modGlobal.IMAGEPATH + "amdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalf").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalf").Picture = modGlobal.IMAGEPATH + "pmdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalf").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalf").Picture = modGlobal.IMAGEPATH + "amdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalf").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalf").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalf").Picture = modGlobal.IMAGEPATH + "pmdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalf").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalfOT").Picture = modGlobal.IMAGEPATH + "amdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amRevHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalfOT").Picture = modGlobal.IMAGEPATH + "pmdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmRevHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalfNote").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalfNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalfNote").Picture = modGlobal.IMAGEPATH + "amdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amDebHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalfNote").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalfNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalfNote").Picture = modGlobal.IMAGEPATH + "pmdebhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmDebHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMil").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMil").Picture = modGlobal.IMAGEPATH + "DebMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHol").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHol").Picture = modGlobal.IMAGEPATH + "DebHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVac").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVac").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKel").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKel").Picture = modGlobal.IMAGEPATH + "DebKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOth").BackColor = modGlobal.CDEBIT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOth").Picture = modGlobal.IMAGEPATH + "DebOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrd").Picture = modGlobal.IMAGEPATH + "Debtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedu").Picture = modGlobal.IMAGEPATH + "debedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilNote").Picture = modGlobal.IMAGEPATH + "DebMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolNote").Picture = modGlobal.IMAGEPATH + "DebHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacNote").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelNote").Picture = modGlobal.IMAGEPATH + "DebKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthNote").Picture = modGlobal.IMAGEPATH + "DebOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdNote").Picture = modGlobal.IMAGEPATH + "Debtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedunote").Picture = modGlobal.IMAGEPATH + "debedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilTRD").Picture = modGlobal.IMAGEPATH + "DebMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolTRD").Picture = modGlobal.IMAGEPATH + "DebHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacTRD").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelTRD").Picture = modGlobal.IMAGEPATH + "DebKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthTRD").Picture = modGlobal.IMAGEPATH + "DebOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduTRD").Picture = modGlobal.IMAGEPATH + "debedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilOT").Picture = modGlobal.IMAGEPATH + "DebMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolOT").Picture = modGlobal.IMAGEPATH + "DebHol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacOT").Picture = modGlobal.IMAGEPATH + "Debvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelOT").Picture = modGlobal.IMAGEPATH + "DebKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthOT").Picture = modGlobal.IMAGEPATH + "DebOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdOT").Picture = modGlobal.IMAGEPATH + "Debtrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("DebTrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduOT").Picture = modGlobal.IMAGEPATH + "debedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("debeduOT").Font.Bold = false;

			//Trade (Lt Green)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Trade").BackColor = modGlobal.CTRADE;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Trade").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("Trade").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalf").Picture = modGlobal.IMAGEPATH + "amtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalf").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalf").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalf").Picture = modGlobal.IMAGEPATH + "pmtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalf").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOth").Picture = modGlobal.IMAGEPATH + "trdOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDeb").Picture = modGlobal.IMAGEPATH + "trdDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVac").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHol").Picture = modGlobal.IMAGEPATH + "trdhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMil").Picture = modGlobal.IMAGEPATH + "trdMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKel").Picture = modGlobal.IMAGEPATH + "trdKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedu").Picture = modGlobal.IMAGEPATH + "trdedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolNote").Picture = modGlobal.IMAGEPATH + "trdhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilNote").Picture = modGlobal.IMAGEPATH + "trdMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelNote").Picture = modGlobal.IMAGEPATH + "trdKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacNote").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeNote").BackColor = modGlobal.CTRADE;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfNote").Picture = modGlobal.IMAGEPATH + "amtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfNote").Picture = modGlobal.IMAGEPATH + "pmtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthNote").Picture = modGlobal.IMAGEPATH + "trdOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebNote").Picture = modGlobal.IMAGEPATH + "trdDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebNote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedunote").Picture = modGlobal.IMAGEPATH + "trdedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdedunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfTRD").Picture = modGlobal.IMAGEPATH + "amtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfTRD").Picture = modGlobal.IMAGEPATH + "pmtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthTRD").Picture = modGlobal.IMAGEPATH + "trdOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebTRD").Picture = modGlobal.IMAGEPATH + "trdDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacTRD").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolTRD").Picture = modGlobal.IMAGEPATH + "trdhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilTRD").Picture = modGlobal.IMAGEPATH + "trdMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelTRD").Picture = modGlobal.IMAGEPATH + "trdKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduTRD").Picture = modGlobal.IMAGEPATH + "trdedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeOT").BackColor = modGlobal.CTRADE;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TradeOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfOT").Picture = modGlobal.IMAGEPATH + "amtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amTrdHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfOT").Picture = modGlobal.IMAGEPATH + "pmtrdhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmTrdHalfOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthOT").Picture = modGlobal.IMAGEPATH + "trdOth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdOthOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebOT").Picture = modGlobal.IMAGEPATH + "trdDeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdDebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacOT").Picture = modGlobal.IMAGEPATH + "trdvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdVacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolOT").Picture = modGlobal.IMAGEPATH + "trdhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdHolOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilOT").Picture = modGlobal.IMAGEPATH + "trdMil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdMilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelOT").Picture = modGlobal.IMAGEPATH + "trdKel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("TrdKelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduOT").Picture = modGlobal.IMAGEPATH + "trdedu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("trdeduOT").Font.Bold = false;

			//Education (Pink)
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledu").Picture = modGlobal.IMAGEPATH + "fulledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudeb").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudeb").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudeb").Picture = modGlobal.IMAGEPATH + "edudeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudeb").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvac").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvac").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvac").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvac").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduhol").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduhol").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduhol").Picture = modGlobal.IMAGEPATH + "eduhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduhol").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukel").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukel").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukel").Picture = modGlobal.IMAGEPATH + "edukel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukel").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumil").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumil").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumil").Picture = modGlobal.IMAGEPATH + "edumil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumil").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduoth").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduoth").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduoth").Picture = modGlobal.IMAGEPATH + "eduoth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduoth").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrd").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrd").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrd").Picture = modGlobal.IMAGEPATH + "edutrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrd").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledunote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledunote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledunote").Picture = modGlobal.IMAGEPATH + "fulledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulledunote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholnote").Picture = modGlobal.IMAGEPATH + "eduhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelnote").Picture = modGlobal.IMAGEPATH + "edukel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilnote").Picture = modGlobal.IMAGEPATH + "edumil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothnote").Picture = modGlobal.IMAGEPATH + "eduoth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdnote").Picture = modGlobal.IMAGEPATH + "edutrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebnote").Picture = modGlobal.IMAGEPATH + "edudeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacnote").ForeColor = modGlobal.CNOTES; //Notes Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacnote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacnote").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacnote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduOT").Picture = modGlobal.IMAGEPATH + "fulledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebOT").Picture = modGlobal.IMAGEPATH + "edudeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacOT").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholOT").Picture = modGlobal.IMAGEPATH + "eduhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelOT").Picture = modGlobal.IMAGEPATH + "edukel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilOT").Picture = modGlobal.IMAGEPATH + "edumil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothOT").Picture = modGlobal.IMAGEPATH + "eduoth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdOT").Picture = modGlobal.IMAGEPATH + "edutrd.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edutrdOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduTRD").Picture = modGlobal.IMAGEPATH + "fulledu.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("fulleduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebTRD").Picture = modGlobal.IMAGEPATH + "edudeb.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edudebTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacTRD").Picture = modGlobal.IMAGEPATH + "eduvac.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduvacTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholTRD").Picture = modGlobal.IMAGEPATH + "eduhol.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduholTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelTRD").Picture = modGlobal.IMAGEPATH + "edukel.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edukelTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilTRD").Picture = modGlobal.IMAGEPATH + "edumil.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("edumilTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothTRD").Picture = modGlobal.IMAGEPATH + "eduoth.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("eduothTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfedu").Picture = modGlobal.IMAGEPATH + "ameduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfedu").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfedu").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.BLACK);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfedu").Picture = modGlobal.IMAGEPATH + "pmeduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfedu").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduOT").Picture = modGlobal.IMAGEPATH + "ameduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduOT").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduOT").ForeColor = modGlobal.COVERTIME; //OT Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduOT").Picture = modGlobal.IMAGEPATH + "pmeduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduOT").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduNote").Picture = modGlobal.IMAGEPATH + "ameduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduNote").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduNote").ForeColor = modGlobal.CNOTES; //Note Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduNote").Picture = modGlobal.IMAGEPATH + "pmeduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduNote").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduTRD").Picture = modGlobal.IMAGEPATH + "ameduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("amhalfeduTRD").Font.Bold = false;

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduTRD").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduTRD").ForeColor = modGlobal.CTRADE; //Trade Font

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduTRD").Picture = modGlobal.IMAGEPATH + "pmeduhalf.bmp";
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calSched.getX().StyleSets("pmhalfeduTRD").Font.Bold = false;

		}

		public void DisplayDetails(string ThisDate)
		{
			//Display Details for this date
			ViewManager.ShowMessage("Display Details for " + ThisDate, System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName);

		}

		public ScheduleTimeStruct ScheduleTime(string Oper, string TimeType)
		{
			using ( var async1 = this.Async<ScheduleTimeStruct>(true) )
			{
				//Time Scheduling Requested
				//- receives: Oper param , ADD if Add or Update button
				//                         DEL if Delete button
				//- TimeType param, Debit (DDF) or Regular (REG) or Education (EDU) or Unsched Debit (UDD)
				//ADODB
				string AMDate = "";
				string PMDate = "";
				string AMKOT = "";
				string PMKOT = "";
				string Empid = "";
				string TimeCode = "";
				int AssignID = 0;
				int PayUp = 0;
				string JobCode = "";
				int Step = 0;
				float TotalDebits = 0;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				try
				{
					{
						if ( ViewModel.FirstTime != 0 )
						{
							return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                { TimeType = TimeType, });
						}

						//Come Here - for employee id change
						Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
						if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
						{
							AMDate = ViewModel.calLeaveDate.Text + " 7:00AM";
							PMDate = ViewModel.calLeaveDate.Text + " 7:00PM";
						}
						else if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
						{
							AMDate = ViewModel.calLeaveDate.Text + " 7:00AM";
							PMDate = "";
						}
						else if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
						{
							PMDate = ViewModel.calLeaveDate.Text + " 7:00PM";
							AMDate = "";
						}
						else
						{
							ViewManager.ShowMessage("You must check AM and/or PM", "Individual Leave Scheduler ", UpgradeHelpers.Helpers.BoxButtons.OK);
							return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                { TimeType = TimeType, });
						}

						if ( ViewModel.lbDebit.Text == "Total Debits" )
						{
							TotalDebits = (float)Conversion.Val(ViewModel.lbTotalDebits.Text);
						}
						else
						{
							TotalDebits = 0;
						}

						//Determine if Employee is already scheduled for this date
						//Create rdoConnection
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						if ( AMDate != "" )
						{
							oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + AMDate + "'";
							oRec = ADORecordSetHelper.Open(oCmd, "");
							if ( !oRec.EOF )
							{
								AMKOT = modGlobal.Clean(oRec["time_code_id"]);
							//            If AMKOT = "UDD" Then
							//                AMKOT = "DDF"
							//            End If
							}
							else
							{
								AMKOT = "";
							}
						}

						if ( PMDate != "" )
						{
							oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + PMDate + "'";
							oRec = ADORecordSetHelper.Open(oCmd, "");
							if ( !oRec.EOF )
							{
								PMKOT = modGlobal.Clean(oRec["time_code_id"]);
							//            If PMKOT = "UDD" Then
							//                PMKOT = "DDF"
							//            End If
							}
							else
							{
								PMKOT = "";
							}
						}

						//Get current Job Code & Step
						JobCode = modGlobal.GetJobCode(Empid);
						Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
						PayUp = 0;
						oCmdUpdate.Connection = modGlobal.oConn;
						oCmdUpdate.CommandType = CommandType.StoredProcedure;
						using ( var async2 = this.Async<ScheduleTimeStruct>() )
						{
							switch ( Oper )
							{
								case "ADD":
									if ( AMDate != "" )
									{
										if ( TimeType == AMKOT )
										{
											return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                { TimeType = TimeType, });
										}

										if ( AMKOT != "" )
										{
											//Update Schedule time_code
											oCmdUpdate.CommandText = "spUpdateScheduleTime";
											oCmdUpdate.ExecuteNonQuery(new object[] { Empid, AMDate, TimeType, DateTime.Now, modGlobal.Shared.gUser });

											if ( TimeType == "DDF" || TimeType == "UDD" )
											{
												TotalDebits = (float)(TotalDebits + 0.5d);
											}
											else
											{
												TotalDebits = (float)(TotalDebits - 0.5d);
											}
										}
										else
										{
											//Add new Schedule record
											if ( TimeType == "DDF" || TimeType == "UDD" )
											{
												if ( ViewModel.lbBatt.Text.Trim() == "3" )
												{
													AssignID = modGlobal.ASGN183DBT;
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "2" )
												{
													AssignID = modGlobal.ASGN182DBT;
												}
												else
												{
													AssignID = modGlobal.ASGN181DBT;
												}

												//                        TimeCode = "DDF"
												TimeCode = TimeType;
												TotalDebits = (float)(TotalDebits + 0.5d);
											}
											else
											{
												if ( ViewModel.lbBatt.Text.Trim() == "3" )
												{
                                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                            ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 3 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
													async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
													async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
														{
															Response = tempNormalized1;
														});
													async2.Append<ScheduleTimeStruct>(() =>
														{
															if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
															{
																return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                    { TimeType = TimeType, });
															}
															else
															{
																AssignID = modGlobal.ASGN183ROV;
															}
															return this.Continue<ScheduleTimeStruct>();
														});
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "2" )
												{
                                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                            ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 2 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
													async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
													async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
														{
															Response = tempNormalized3;
														});
													async2.Append<ScheduleTimeStruct>(() =>
														{
															if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
															{
																return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                    { TimeType = TimeType, });
															}
															else
															{
																AssignID = modGlobal.ASGN182ROV;
															}
															return this.Continue<ScheduleTimeStruct>();
														});
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "4" )
												{
                                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                            ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 4 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
													async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
													async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
														{
															Response = tempNormalized5;
														});
													async2.Append<ScheduleTimeStruct>(() =>
														{
															if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
															{
																return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                    { TimeType = TimeType, });
															}
															else
															{
																AssignID = modGlobal.ASGN184ROV;
															}
															return this.Continue<ScheduleTimeStruct>();
														});
												}
												else
												{
                                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                            ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 1 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
													async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized6 => tempNormalized6);
													async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized7 =>
														{
															Response = tempNormalized7;
														});
													async2.Append<ScheduleTimeStruct>(() =>
														{
															if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
															{
																return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                    { TimeType = TimeType, });
															}
															else
															{
																AssignID = modGlobal.ASGN181ROV;
															}
															return this.Continue<ScheduleTimeStruct>();
														});
												}
												async2.Append(() =>
													{

														if ( TimeType == "" )
														{
															TimeCode = "REG";
														}
														else
														{
															TimeCode = TimeType;
														}
													});
											}
											async2.Append(() =>
												{

													oCmdUpdate.CommandText = "spInsertSchedule";
													oCmdUpdate.ExecuteNonQuery(new object[] { AMDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
												});
										}
									}

									if ( PMDate != "" )
									{
										if ( TimeType == PMKOT )
										{
											return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                { TimeType = TimeType, });
										}

										if ( PMKOT != "" )
										{
											//Update Schedule time_code
											oCmdUpdate.CommandText = "spUpdateScheduleTime";
											oCmdUpdate.ExecuteNonQuery(new object[] { Empid, PMDate, TimeType, DateTime.Now, modGlobal.Shared.gUser });

											if ( TimeType == "DDF" || TimeType == "UDD" )
											{
												TotalDebits = (float)(TotalDebits + 0.5d);
											}
											else
											{
												TotalDebits = (float)(TotalDebits - 0.5d);
											}
										}
										else
										{
											//Add new Schedule record
											if ( TimeType == "DDF" || TimeType == "UDD" )
											{
												if ( ViewModel.lbBatt.Text.Trim() == "3" )
												{
													AssignID = modGlobal.ASGN183DBT;
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "2" )
												{
													AssignID = modGlobal.ASGN182DBT;
												}
												else
												{
													AssignID = modGlobal.ASGN181DBT;
												}

												//                        TimeCode = "DDF"
												TimeCode = TimeType;
												TotalDebits = (float)(TotalDebits + 0.5d);
											}
											else
											{
												if ( ViewModel.lbBatt.Text.Trim() == "3" )
												{
													if ( ((int)Response) == 0 )
													{
                                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                                ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 1 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
														async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized8 => tempNormalized8);
														async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized9 =>
															{
																Response = tempNormalized9;
															});
														async2.Append<ScheduleTimeStruct>(() =>
															{
																if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
																{
																	return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                        { TimeType = TimeType, });
																}
																else
																{
																	AssignID = modGlobal.ASGN183ROV;
																}
																return this.Continue<ScheduleTimeStruct>();
															});
													}
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "2" )
												{
													if ( ((int)Response) == 0 )
													{
                                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => ViewManager.ShowMessage("Employee will be scheduled as Batt 2 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
														async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized10 => tempNormalized10);
														async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized11 =>
															{
																Response = tempNormalized11;
															});
														async2.Append<ScheduleTimeStruct>(() =>
															{
																if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
																{
																	return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                        { TimeType = TimeType, });
																}
																else
																{
																	AssignID = modGlobal.ASGN182ROV;
																}
																return this.Continue<ScheduleTimeStruct>();
															});
													}
												}
												else if ( ViewModel.lbBatt.Text.Trim() == "4" )
												{
													if ( ((int)Response) == 0 )
													{
                                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => ViewManager.ShowMessage("Employee will be scheduled as Batt 4 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
														async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized12 => tempNormalized12);
														async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized13 =>
															{
																Response = tempNormalized13;
															});
														async2.Append<ScheduleTimeStruct>(() =>
															{
																if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
																{
																	return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                        { TimeType = TimeType, });
																}
																else
																{
																	AssignID = modGlobal.ASGN184ROV;
																}
																return this.Continue<ScheduleTimeStruct>();
															});
													}
												}
												else
												{
													if ( ((int)Response) == 0 )
													{
                                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                                ) => ViewManager.ShowMessage("Employee will be scheduled as Battalion 1 Rover", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
														async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized14 => tempNormalized14);
														async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized15 =>
															{
																Response = tempNormalized15;
															});
														async2.Append<ScheduleTimeStruct>(() =>
															{
																if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
																{
																	return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                                        { TimeType = TimeType, });
																}
																else
																{
																	AssignID = modGlobal.ASGN181ROV;
																}
																return this.Continue<ScheduleTimeStruct>();
															});
													}
												}
												async2.Append(() =>
													{

														if ( TimeType == "" )
														{
															TimeCode = "REG";
														}
														else
														{
															TimeCode = TimeType;
														}
													});
											}
											async2.Append(() =>
												{

													oCmdUpdate.CommandText = "spInsertSchedule";
													oCmdUpdate.ExecuteNonQuery(new object[] { PMDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
												});
										}
									}

									break;
								case "DEL":
									if ( AMDate != "" )
									{
										if ( TimeType != AMKOT )
										{
											return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                { TimeType = TimeType, });
										}

										if ( TimeType == "DDF" || TimeType == "UDD" )
										{
                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
                                                    ViewManager.ShowMessage("Change Scheduled Debit to Regular Time?", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
											async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized16 => tempNormalized16);
											async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized17 =>
												{
													Response = tempNormalized17;
												});
											async2.Append<ScheduleTimeStruct>(() =>
												{
													if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
													{
														oCmdUpdate.CommandText = "spUpdateScheduleTime";
														oCmdUpdate.ExecuteNonQuery(new object[] { Empid, AMDate, "REG", DateTime.Now, modGlobal.Shared.gUser });

														TotalDebits = (float)(TotalDebits - 0.5d);
													}
													else if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
													{
														oCmdUpdate.CommandText = "spDeleteSchedule";
														oCmdUpdate.ExecuteNonQuery(new object[] { Empid, AMDate });

														TotalDebits = (float)(TotalDebits - 0.5d);
													}
													else
													{
														return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                            { TimeType = TimeType, });
													}
													return this.Continue<ScheduleTimeStruct>();
												});
										}
										else
										{
											oCmdUpdate.CommandText = "spDeleteSchedule";
											oCmdUpdate.ExecuteNonQuery(new object[] { Empid, AMDate });
										}
									}

									if ( PMDate != "" )
									{
										if ( TimeType != PMKOT )
										{
											return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                { TimeType = TimeType, });
										}

										if ( TimeType == "DDF" || TimeType == "UDD" )
										{
											if ( ((int)Response) == 0 )
											{
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
                                                        ViewManager.ShowMessage("Change Scheduled Debit to Regular Time?", "Individual Leave Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
												async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized18 => tempNormalized18);
												async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized19 =>
													{
														Response = tempNormalized19;
													});
											}
											async2.Append<ScheduleTimeStruct>(() =>
												{

													if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
													{
														oCmdUpdate.CommandText = "spUpdateScheduleTime";
														oCmdUpdate.ExecuteNonQuery(new object[] { Empid, PMDate, "REG", DateTime.Now, modGlobal.Shared.gUser });

														TotalDebits = (float)(TotalDebits - 0.5d);
													}
													else if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
													{
														oCmdUpdate.CommandText = "spDeleteSchedule";
														oCmdUpdate.ExecuteNonQuery(new object[] { Empid, PMDate });

														TotalDebits = (float)(TotalDebits - 0.5d);
													}
													else
													{
														return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                                                            { TimeType = TimeType, });
													}
													return this.Continue<ScheduleTimeStruct>();
												});
										}
										else
										{
											oCmdUpdate.CommandText = "spDeleteSchedule";
											oCmdUpdate.ExecuteNonQuery(new object[] { Empid, PMDate });
										}
									}

									break;
							}
						}
						async1.Append(() =>
							{

									if ( ViewModel.lbDebit.Text == "Total Debits" )
									{
										ViewModel.lbTotalDebits.Text = TotalDebits.ToString();
									}

											FillSchedule();
										});
								}
					}
				catch
				{
                                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                            { TimeType = TimeType, });
							}
				}

				return this.Return<ScheduleTimeStruct>(() => new PTSProject.frmIndSched.ScheduleTimeStruct()
                    { TimeType = TimeType, });
			}
		}


		public void SetSecurity()
		{
			//Disable any controls not accessable by current user
			if ( modGlobal.Shared.gSecurity == "RO" )
			{
				ViewModel.cmdAdd.Enabled = false;
				ViewModel.cmdDelete.Enabled = false;
				ViewModel.cmdUpdate.Enabled = false;
				ViewModel.cmdPrint.Enabled = true;
				ViewModel.lbCity.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbPhone.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbCOThire.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbAddress.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbZip.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label6.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label1.ForeColor = modGlobal.Shared.LT_GRAY;
				return ;
			}
			if ( modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "CPT" )
			{
				ViewModel.cmdAdd.Enabled = false;
				ViewModel.cmdDelete.Enabled = false;
				ViewModel.cmdUpdate.Enabled = false;
				ViewModel.cmdPrint.Enabled = true;
				ViewModel.lbCity.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbPhone.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbCOThire.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbAddress.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.lbZip.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label6.ForeColor = modGlobal.Shared.LT_GRAY;
				ViewModel.Label1.ForeColor = modGlobal.Shared.LT_GRAY;
				//        chkLaunderTurnOuts.Enabled = False
				return ;
			}
			ViewModel.cmdCallBack.Visible = false;
			if ( modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID" )
			{
				//        If gUserBatt = "2" Or gSecurity = "ADM" Then
				ViewModel.cmdCallBack.Visible = true;
				ViewModel.cmdCallBack.Enabled = true;
			//        End If
			}

			ViewModel.cmdNotes.Visible = modGlobal.Shared.gSecurity == "ADM";

		}

		public void GetDailyTotals()
		{
				//This subroutine runs when a day is selected on Year Calendar
				//The AM & PM total scheduled personnel for selected date are
				//displayed in label controls below calendar
				//ADODB

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string NewDate = "";
				string StartDate = "", EndDate = "";

				try
				{

					//If subroutine triggered during Form Load event - exit
					if ( ViewModel.FirstTime != 0 )
					{
						ViewModel.FirstTime = 0;
						return ;
					}

					//Initialize Leave Total Labels
					ViewModel.lbREGam.Text = "";
					ViewModel.lbREGpm.Text = "";
					ViewModel.lbPMam.Text = "";
					ViewModel.lbPMpm.Text = "";
					ViewModel.lbHZMam.Text = "";
					ViewModel.lbHZMpm.Text = "";
					ViewModel.lbMRNam.Text = "";
					ViewModel.lbMRNpm.Text = "";
					ViewModel.lbMRNpm.Text = "";
					ViewModel.lbBATam.Text = "";
					ViewModel.lbBATpm.Text = "";
					ViewModel.lbFCCam.Text = "";
					ViewModel.lbFCCpm.Text = "";

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

					//Select AM Leave Totals for selected date
					NewDate = ViewModel.calLeaveDate.Text + " 7:00AM";
					ViewModel.lbSelectAM.Text = NewDate;
					oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");


					while ( !oRec.EOF )
					{
						if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM" )
						{
							ViewModel.lbPMam.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM" )
						{
							ViewModel.lbHZMam.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN" )
						{
							ViewModel.lbMRNam.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC" )
						{
							ViewModel.lbFCCam.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "BAT" )
						{
						//            lbBATam.Caption = oRec("total_leave")
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV" )
						{
						//dont count Reserve Staff
						}
						else
						{
							ViewModel.lbREGam.Text = Convert.ToString(oRec["total_leave"]);
						}
						oRec.MoveNext();
            };

					//Select PM Leave Totals for selected date
					NewDate = ViewModel.calLeaveDate.Text + " 7:00PM";
					ViewModel.lbSelectPM.Text = NewDate;
					oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");


					while ( !oRec.EOF )
					{
						if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM" )
						{
							ViewModel.lbPMpm.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM" )
						{
							ViewModel.lbHZMpm.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN" )
						{
							ViewModel.lbMRNpm.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC" )
						{
							ViewModel.lbFCCpm.Text = Convert.ToString(oRec["total_leave"]);
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "BAT" )
						{
						//            lbBATpm.Caption = oRec("total_leave")
						}
						else if ( modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV" )
						{
						//dont count Reserve Staff
						}
						else
						{
							ViewModel.lbREGpm.Text = Convert.ToString(oRec["total_leave"]);
						}
						oRec.MoveNext();
            };

					//Get Battalion Leave Counts
					StartDate = DateTime.Parse(ViewModel.calLeaveDate.Text).ToString("M/d/yyyy");
					EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("M/d/yyyy");
					oCmd.CommandText = "spReport_DailyBCSummary '" + StartDate + "', '" + EndDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					while ( !oRec.EOF )
					{
						if ( Convert.ToString(oRec["AMPM"]) == "AM" )
						{
							ViewModel.lbBATam.Text = Convert.ToString(oRec["leave_count"]);
						}
						else
						{
							ViewModel.lbBATpm.Text = Convert.ToString(oRec["leave_count"]);
						}
						oRec.MoveNext();
            };


					//Display Leave Total labels
					ViewModel.lbSelectTitle1.Visible = true;
					ViewModel.lbSelectTitle2.Visible = true;
					ViewModel.lbSelectTitle3.Visible = true;
					ViewModel.lbSelectTitle4.Visible = true;
					ViewModel.lbSelectTitle5.Visible = true;
					ViewModel.lbSelectTitle6.Visible = true;
					ViewModel.lbSelectTitle7.Visible = true;
					ViewModel.lbSelectAM.Visible = true;
					ViewModel.lbSelectPM.Visible = true;
					ViewModel.lbREGam.Visible = true;
					ViewModel.lbREGpm.Visible = true;
					ViewModel.lbPMam.Visible = true;
					ViewModel.lbPMpm.Visible = true;
					ViewModel.lbHZMam.Visible = true;
					ViewModel.lbHZMpm.Visible = true;
					ViewModel.lbMRNam.Visible = true;
					ViewModel.lbMRNpm.Visible = true;
					ViewModel.lbMRNpm.Visible = true;
					ViewModel.lbBATam.Visible = true;
					ViewModel.lbBATpm.Visible = true;
					ViewModel.lbFCCam.Visible = true;
					ViewModel.lbFCCpm.Visible = true;
				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void ResetSchedCal()
		{
			//Initialize Year Calendar, removing any Leave StyleSets
			//currently displayed


			string StartDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
			string EndDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(StartDate).AddYears(1));


			while ( StartDate != EndDate )
			{
				System.DateTime TempDate = DateTime.FromOADate(0);
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calSched.getX().Day((DateTime.TryParse(StartDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : StartDate).StyleSet = "Default";
				StartDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(StartDate).AddDays(1));
            };

			}

		public string SetStyleType(string TimeType)
		{
			//This function returns a Styleset for the
			//requested type of Leave - TimeType parameter

			string strStyle = "";

			switch ( TimeType )
			{
				case modGlobal.REGSCHED:
					strStyle = "Regular";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "ReverseNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "Reverse";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "ReverseOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.VACAM:
					strStyle = "amVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "amVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case modGlobal.VACPM:
					strStyle = "pmVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "pmVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case modGlobal.VACFULL:
					strStyle = "Vacation";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacationNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacationBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacationBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacationTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacationBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacationOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacationBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "199": //VACAM DEBPM 
					strStyle = "VacDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacDebNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankDebNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankDeb";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacDebTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankDebTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacDebOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankDebOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "92": //DEBAM VACPM 
					strStyle = "DebVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "DebVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "DebVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "DebVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "DebVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "DebVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "1N": //VACAM only 
					strStyle = "amVacHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amVacHalfNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankHalfNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "amVacBankHalf";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amVacHalfTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankHalfTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amVacHalfOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "amVacBankHalfOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "N2": //VACPM only 
					strStyle = "pmVacHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmVacHalfNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankHalfNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "pmVacBankHalf";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmVacHalfTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankHalfTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmVacHalfOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "pmVacBankHalfOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case modGlobal.HOLAM:
					strStyle = "amHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.HOLPM:
					strStyle = "pmHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "34": //Full Holiday 
					strStyle = "Holiday";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolidayNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolidayTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolidayOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "399": //HOLAM DEBPM 
					strStyle = "HolDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolDebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "94": //DEBAM HOLPM 
					strStyle = "DebHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "DebHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "3N": //HOLAM only 
					strStyle = "amHolHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amHolHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amHolHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amHolHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "N4": //HOLPM only 
					strStyle = "pmHolHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmHolHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmHolHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmHolHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.MILAM:
					strStyle = "amMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.MILPM:
					strStyle = "pmMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "56": //Full Military 
					strStyle = "Military";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilitaryNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilitaryTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilitaryOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "599": //MILAM DEBPM 
					strStyle = "MilDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilDebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "96": //DEBAM MILPM 
					strStyle = "DebMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "DebMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "5N": //MILAM only 
					strStyle = "amMilHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amMilHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amMilHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amMilHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "N6": //MILPM only 
					strStyle = "pmMilHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmMilHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmMilHalTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmMilHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.KELAM:
					strStyle = "amKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.KELPM:
					strStyle = "pmKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "78": //Full Kelly 
					strStyle = "Kelly";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KellyNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KellyTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KellyOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "799": //KELAM DEBPM 
					strStyle = "KelDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelDebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "98": //DEBAM KELPM 
					strStyle = "DebKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "DebKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "7N": //KELAM only 
					strStyle = "amKelHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amKelHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amKelHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amKelHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "N8": //KELPM only 
					strStyle = "pmKelHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmKelHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmKelHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmKelHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "14": //VACAM HOLPM 
					strStyle = "VacHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacHolNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankHolNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacHolTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankHolTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankHol";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacHolOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankHolOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "16": //VACAM MILPM 
					strStyle = "VacMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacMilNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankMilNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacMilTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankMilTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankMil";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacMilOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankMilOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "18": //VACAM KELPM 
					strStyle = "VacKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacKelNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankKelNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacKelTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankKelTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankKel";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacKelOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankKelOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "32": //HOLAM VACPM 
					strStyle = "HolVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "HolVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "HolVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "HolVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "HolVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "52": //MILAM VACPM 
					strStyle = "MilVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "MilVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "MilVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "MilVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "MilVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "72": //KELAM VACPM 
					strStyle = "KelVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "KelVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "KelVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "KelVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "KelVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "36": //HOLAM MILPM 
					strStyle = "HolMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "38": //HOLAM KELPM 
					strStyle = "HolKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "54": //MILAM HOLPM 
					strStyle = "MilHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "74": //KELAM HOLPM 
					strStyle = "KelHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "58": //MILAM KELPM 
					strStyle = "MilKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "76": //KELAM MILPM 
					strStyle = "KelMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.OTHAM:
					strStyle = "amOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.OTHPM:
					strStyle = "pmOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.OTHFULL:
					strStyle = "Other";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OtherNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OtherTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OtherOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "1099": //OTHERAM DEBPM 
					strStyle = "OthDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthDebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "920": //DEBAM OTHERPM 
					strStyle = "DebOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "DebOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "10N": //OTHERAM only 
					strStyle = "amOthHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amOthHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amOthHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amOthHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "N20": //OTHERPM only 
					strStyle = "pmOthHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmOthHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmOthHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmOthHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "102": //OTHERAM VACPM 
					strStyle = "OthVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "OthVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "OthVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "OthVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "OthVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "104": //OTHERAM HOLPM 
					strStyle = "OthHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "106": //OTHERAM MILPM 
					strStyle = "OthMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "108": //OTHERAM KELPM 
					strStyle = "OthKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "120": //VACAM OTHERPM 
					strStyle = "VacOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacOthNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankOthNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankOth";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "VacOthTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankOthTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacOthOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankOthOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "320": //HOLAM OTHERPM 
					strStyle = "HolOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "HolOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "520": //MILAM OTHERPM 
					strStyle = "MilOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "MilOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "720": //KELAM OTHERPM 
					strStyle = "KelOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.DEBAM:
					strStyle = "amDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "RevamDeb";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "RevamDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.DEBPM:
					strStyle = "pmDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "RevpmDeb";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "RevpmDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "9N": //DEBAM only 
					strStyle = "amDebHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amDebHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amRevHalf";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amRevHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "N99": //DEBPM only 
					strStyle = "pmDebHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmDebHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmRevHalf";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmRevOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.DEBFULL: //Full DEBIT 
					strStyle = "Debit";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "RevDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "RevDeb";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "RevDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.NOSCHED: //REGPM only 
					strStyle = "pmReg";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmRegNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "RevpmReg";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "RevpmRegOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A": //TRDAM only 
					strStyle = "amTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "B": //TRDPM only 
					strStyle = "pmTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "AB": //Full TRD 
					strStyle = "Trade";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TradeNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TradeOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "AN": //TRDAM only 
					strStyle = "amTrdHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amTrdHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amTrdHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amTrdHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "NB": //TRDPM only 
					strStyle = "pmTrdHalf";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmTrdHalfNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmTrdHalfTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmTrdHalfOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A2": //TRDAM VACPM 
					strStyle = "TrdVac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdVacNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "TrdVacBankNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "TrdVacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdVacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "TrdVacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdVacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "TrdVacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "1B": //VACAM TRDPM 
					strStyle = "VacTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "VacTrdNote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankTrdNote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "VacBankTrd";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "VacTrdOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "VacBankTrdOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "A4": //TRDAM HOLPM 
					strStyle = "TrdHol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdHolNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdHolTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdHolOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "3B": //HOLAM TRDPM 
					strStyle = "HolTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "HolTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "HolTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A6": //TRDAM MILPM 
					strStyle = "TrdMil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdMilNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdMilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdMilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "5B": //MILAM TRDPM 
					strStyle = "MilTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "MilTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "MilTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A8": //TRDAM KELPM 
					strStyle = "TrdKel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdKelNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdKelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdKelOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "7B": //KELAM TRDPM 
					strStyle = "KelTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "KelTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "KelTrdTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "KelTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A20": //TRDAM OTHERPM 
					strStyle = "TrdOth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdOthNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdOthTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdOthOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "10B": //OTHERAM TRDPM 
					strStyle = "OthTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "OthTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "OthTrdTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "OthTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "A99": //TRDAM DEBPM 
					strStyle = "TrdDeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "TrdDebNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "TrdDebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "TrdDebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "9B": //DEBAM TRDPM 
					strStyle = "DebTrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "DebTrdNote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "DebTrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.EDUAM:
					strStyle = "amedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "ameduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "ameduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "CN": //EDUAM only 
					strStyle = "amhalfedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "amhalfedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "amhalfeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "amhalfeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "ND": //EDUPM only 
					strStyle = "pmhalfedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmhalfedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmhalfeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmhalfeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case modGlobal.EDUPM:
					strStyle = "pmedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "pmedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "pmeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "pmeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "CD": //Full Education 
					strStyle = "fulledu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "fulledunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "fulleduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "fulleduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "AD": //TRDAM EDUPM 
					strStyle = "trdedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "trdedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "trdeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "trdeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "CB": //EDUAM TRDPM 
					strStyle = "edutrd";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "edutrdnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "edutrdOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C2": //EDUAM VACPM 
					strStyle = "eduvac";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "eduvacnote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "eduvacBanknote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "eduvacBank";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "eduvacTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "eduvacBankTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "eduvacOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "eduvacBankOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "1D": //VACAM EDUPM 
					strStyle = "vacedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "vacedunote";
						ViewModel.NoteFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "vacBankedunote";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.BankFlag )
					{
						strStyle = "vacBankedu";
						ViewModel.BankFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "vaceduTRD";
						ViewModel.TrdFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "vacBankeduTRD";
							ViewModel.BankFlag = false;
						}
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "vaceduOT";
						ViewModel.OTFlag = false;
						if ( ViewModel.BankFlag )
						{
							strStyle = "vacBankeduOT";
							ViewModel.BankFlag = false;
						}
					}
					break;
				case "9D": //DEBAM EDUPM 
					strStyle = "debedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "debedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "debeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "debeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C99": //EDUAM DEBPM 
					strStyle = "edudeb";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "edudebnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "edudebTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "edudebOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "20D": //OTHERAM EDUPM 
					strStyle = "othedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "othedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "otheduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "otheduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C10": //EDUAM OTHERPM 
					strStyle = "eduoth";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "eduothnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "eduothTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "eduothOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "5D": //MILAM EDUPM 
					strStyle = "miledu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "miledunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "mileduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "mileduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C6": //EDUAM MILPM 
					strStyle = "edumil";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "edumilnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "edumilTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "edumilOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "3D": //HOLAM EDUPM 
					strStyle = "holedu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "holedunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "holeduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "holeduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C4": //EDUAM HOLPM 
					strStyle = "eduhol";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "eduholnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "eduholTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "eduholOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "7D": //KELAM EDUPM 
					strStyle = "keledu";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "keledunote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "keleduTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "keleduOT";
						ViewModel.OTFlag = false;
					}
					break;
				case "C8": //EDUAM KELPM 
					strStyle = "edukel";
					if ( ViewModel.NoteFlag )
					{
						strStyle = "edukelnote";
						ViewModel.NoteFlag = false;
					}
					if ( ViewModel.TrdFlag )
					{
						strStyle = "edukelTRD";
						ViewModel.TrdFlag = false;
					}
					if ( ViewModel.OTFlag )
					{
						strStyle = "edukelOT";
						ViewModel.OTFlag = false;
					}
					break;
				default:
					strStyle = "Default";
					break;
			}
			return strStyle;

		}

		public void GetLeaveTotals()
		{
				//Load leave scheduled and leave available labels for
				//currently selected employee
				//If employee does not have an assigned debit group
				//load total number of scheduled debit days
				//ADODB

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				//On Error GoTo ErrHandler

				if ( ViewModel.FirstTime != 0 )
				{
					return ;
				}

				//Come Here - for employee id change
				string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				//Test to determine if a Selected Employee exists
				if ( Empid == "" )
				{
					return ;
				}


				//    If Empid = "" Then
				//        Exit Sub
				//    ElseIf IsNumeric(Empid) Then
				//        'continue
				//    Else
				//        Exit Sub
				//    End If

				bool GotMax = false;
				ViewModel.TotMil1 = 0;
				ViewModel.TotMil2 = 0;
				ViewModel.TotKel = 0;
				ViewModel.TotHolOverride = 0;
				bool FourtyHour = false;
				float TAuthLeave = 0;
				float TVacation = 0;
				float THoliday = 0;
				float TDebits = 0;

				string JobCode = modGlobal.GetJobCode(Empid);
				if ( modGlobal.Shared.gFourtyHourJobCode != 0 )
				{
					FourtyHour = true;
				}
				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + Empid + "', '" + modGlobal.Shared.gCurrentYear.ToString() + "'";
				ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
				if ( !oRec.EOF )
				{
					GotMax = true;
					ViewModel.TotHolOverride = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec["holiday_max"], "##.0"));
				}


				//Determine total Authorized Vacation Leave for selected employee
				oCmd.CommandText = "spVacationEarned '" + Empid + "', '" + "1/1/" + modGlobal.Shared.gCurrentYear.ToString() + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if ( !oRec.EOF )
				{
					if ( !FourtyHour )
					{
						if ( ViewModel.lbType.Text.Trim() == "FCC" )
						{
							TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 3, "##.0"));
						}
						else
						{
							TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(Convert.ToDouble(oRec["leave_allowed"]) / 2, "##.0"));
						}
					}
					else
					{
						TAuthLeave = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec["leave_allowed"], "##.0"));
					}
				}

				//Select Leave Totals for each type of Leave for
				//selected employee
				string BeginDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
				string EndDate = DateTime.Parse(BeginDate).AddYears(1).ToString("M/d/yyyy");

				oCmd.CommandText = "sp_GetIndLeaveTot '" + Empid + "', '" + BeginDate + "', '" + EndDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				ViewModel.lbVacBank.Text = "";
				ViewModel.lbVacBankOpen.Text = "";

				//Select Vacation Bank Leave Taken for
				//selected employee
				oCmd.CommandText = "sp_GetBankTotal '" + Empid + "', '" + BeginDate + "', '" + EndDate + "'";
				ADORecordSetHelper oRecVBank = ADORecordSetHelper.Open(oCmd, "");
				if ( !oRecVBank.EOF )
				{
					if ( Convert.ToDouble(oRecVBank["vacbank_leave"]) > 0 )
					{
						if ( FourtyHour )
						{
							ViewModel.lbVacBank.Text = Convert.ToString(oRecVBank["vacbank_leave"]);
						}
						else
						{
							ViewModel.lbVacBank.Text = (Convert.ToDouble(oRecVBank["vacbank_leave"]) / 2).ToString();
						}
					}
					else
					{
						ViewModel.lbVacBank.Text = "0";
					}
				}
				else
				{
					ViewModel.lbVacBank.Text = "0";
				}

				//Select Vacation Bank Balance for selected Employee
				oCmd.CommandText = "sp_GetVacBalance '" + Empid + "'";
				oRecVBank = ADORecordSetHelper.Open(oCmd, "");
				if ( !oRecVBank.EOF )
				{
					if ( Convert.ToDouble(oRecVBank["vacation_balance"]) > 0 )
					{
						if ( FourtyHour )
						{
							ViewModel.lbVacBankOpen.Text = Convert.ToString(oRecVBank["vacation_balance"]);
						}
						else
						{
							ViewModel.lbVacBankOpen.Text = (Convert.ToDouble(oRecVBank["vacation_balance"]) / 2).ToString();
						}
					}
					else
					{
						ViewModel.lbVacBankOpen.Text = "0";
					}
				}
				else
				{
					ViewModel.lbVacBankOpen.Text = "0";
				}

				//Clear Leave Totals labels
				//Load Leave available labels with
				//Max available for each leave type
				ViewModel.lbVacation.Text = "";
				ViewModel.lbHoliday.Text = "";
				ViewModel.lbMilitary.Text = "";
				ViewModel.lbKelly.Text = "";

				if ( ViewModel.TotHolOverride != 0 )
				{
					ViewModel.lbHolOpen.Text = ViewModel.TotHolOverride.ToString();
				}
				else if ( GotMax )
				{
					ViewModel.lbHolOpen.Text = ViewModel.TotHolOverride.ToString();
				}
				else if ( ViewModel.lbType.Text.Trim() == "REG" || ViewModel.lbType.Text.Trim() == "FCC" || ViewModel.lbType.Text.Trim() == "MRN" )
				{
					ViewModel.lbHolOpen.Text = modGlobal.MAXHOLREG.ToString();
				}
				else
				{
					ViewModel.lbHolOpen.Text = modGlobal.MAXHOLX.ToString();
				}

				//    lbMILInfo.Visible = False
				// MODIFY MIL LOGIC HERE ~ DKL May 2008
				if ( ViewModel.bUseNewMILMAX )
				{
					ViewModel.lbMilOpen.Text = modGlobal.newMAXMIL.ToString() + "/" + modGlobal.newMAXMIL.ToString();
				}
				else if ( ViewModel.bBothMILMAX )
				{
					ViewModel.lbMilOpen.Text = modGlobal.newMAXMIL.ToString() + "/" + modGlobal.newMAXMIL.ToString();
				}
				else
				{
					ViewModel.lbMilOpen.Text = modGlobal.MAXMIL.ToString() + "/" + modGlobal.MAXMIL.ToString();
				}
				ViewModel.lbKelOpen.Text = modGlobal.MAXKEL.ToString();
				ViewModel.lbVacOpen.Text = TAuthLeave.ToString();


				if ( ViewModel.lbType.Text.Trim() == "FCC" && !FourtyHour )
				{
					ViewModel.lbKellyTitle.Visible = true;
					ViewModel.lbKelly.Visible = true;
					ViewModel.lbKelOpen.Visible = true;
				}
				else
				{
					ViewModel.lbKellyTitle.Visible = false;
					ViewModel.lbKelly.Visible = false;
					ViewModel.lbKelOpen.Visible = false;
				}

				//Fill Leave Totals labels will Query results

				while ( !oRec.EOF )
				{
                if (modGlobal.Clean(oRec["time_code_id"]) == "VAC" || modGlobal.Clean(oRec["time_code_id"]) == "PTO" || modGlobal.Clean(oRec["time_code_id"]) == "VACFML" || modGlobal.Clean(oRec["time_code_id"]) == "PTOFML")
					{
						if ( FourtyHour )
						{
							TVacation = (float)(TVacation + Convert.ToDouble(oRec["scheduled_leave"]));
						}
						else
						{
							TVacation = (float)(TVacation + (Convert.ToDouble(oRec["scheduled_leave"]) / 2));
						}
						ViewModel.lbVacation.Text = TVacation.ToString();
						ViewModel.lbVacOpen.Text = UpgradeHelpers.Helpers.StringsHelper.Format(TAuthLeave - TVacation, "##.0");
						if ( Conversion.Val(ViewModel.lbVacOpen.Text) < 0 )
						{
							ViewModel.lbVacOpen.Text = "0";
						}
					}
					else if ( modGlobal.Clean(oRec["time_code_id"]) == "FHL" || modGlobal.Clean(oRec["time_code_id"]) == "FHLFML" )
					{
						THoliday = (float)(THoliday + Convert.ToDouble(oRec["scheduled_leave"]) / 2);
						ViewModel.lbHoliday.Text = THoliday.ToString();
						if ( ViewModel.TotHolOverride != 0 )
						{
							ViewModel.lbHolOpen.Text = (ViewModel.TotHolOverride - THoliday).ToString();
						}
						else if ( ViewModel.lbType.Text.Trim() == "REG" || ViewModel.lbType.Text.Trim() == "FCC" || ViewModel.lbType.Text.Trim() == "MRN" )
						{
							ViewModel.lbHolOpen.Text = (modGlobal.MAXHOLREG - THoliday).ToString();
						}
						else
						{
							ViewModel.lbHolOpen.Text = (modGlobal.MAXHOLX - THoliday).ToString();
						}
						if ( Conversion.Val(ViewModel.lbHolOpen.Text) < 0 )
						{
							ViewModel.lbHolOpen.Text = "0";
						}
					}
					else if ( modGlobal.Clean(oRec["time_code_id"]) == "ML1" )
					{
						ViewModel.TotMil1 = (float)(Convert.ToDouble(oRec["scheduled_leave"]) / 2);
					}
					else if ( modGlobal.Clean(oRec["time_code_id"]) == "ML2" )
					{
						ViewModel.TotMil2 = (float)(Convert.ToDouble(oRec["scheduled_leave"]) / 2);
					}
					else if ( modGlobal.Clean(oRec["time_code_id"]) == "KEL" )
					{
						ViewModel.TotKel = (float)(ViewModel.TotKel + (Convert.ToDouble(oRec["scheduled_leave"]) / 2));
						ViewModel.lbKelly.Text = ViewModel.TotKel.ToString();
						ViewModel.lbKelOpen.Text = (modGlobal.MAXKEL - ViewModel.TotKel).ToString();
						if ( Conversion.Val(ViewModel.lbKelOpen.Text) < 0 )
						{
							ViewModel.lbKelOpen.Text = "0";
						}
						ViewModel.lbKelly.Visible = true;
						ViewModel.lbKelOpen.Visible = true;
					}
					else if ( modGlobal.Clean(oRec["time_code_id"]) == "KLI" )
					{
						ViewModel.TotKel = (float)(ViewModel.TotKel + (Convert.ToDouble(oRec["scheduled_leave"]) / 2));
						ViewModel.lbKelly.Text = ViewModel.TotKel.ToString();
						ViewModel.lbKelOpen.Text = (modGlobal.MAXKEL - ViewModel.TotKel).ToString();
						if ( Conversion.Val(ViewModel.lbKelOpen.Text) < 0 )
						{
							ViewModel.lbKelOpen.Text = "0";
						}
						ViewModel.lbKelly.Visible = true;
						ViewModel.lbKelOpen.Visible = true;
					}
					oRec.MoveNext();
        };

				// BEGIN NEW LOGIC FOR MILITARY LEAVE    Debra 12/2001
				// MODIFY MIL LOGIC HERE ~ DKL May 2008
				if ( Conversion.Val(ViewModel.TotMil1.ToString()) < 0 )
				{
					ViewModel.TotMil1 = 0;
				}
				if ( Conversion.Val(ViewModel.TotMil2.ToString()) < 0 )
				{
					ViewModel.TotMil2 = 0;
				}
				ViewModel.lbMilitary.Text = ViewModel.TotMil1.ToString() + " / " + ViewModel.TotMil2.ToString();

				if ( ViewModel.bUseNewMILMAX )
				{
					if ( (modGlobal.newMAXMIL - ViewModel.TotMil1) < 0 )
					{
						if ( (modGlobal.newMAXMIL - ViewModel.TotMil2) < 0 )
						{
							ViewModel.lbMilOpen.Text = "0 / 0";
						}
						else
						{
							ViewModel.lbMilOpen.Text = "0 / " + ((modGlobal.newMAXMIL - ViewModel.TotMil2).ToString());
						}
					}
					else
					{
						if ( (modGlobal.newMAXMIL - ViewModel.TotMil2) < 0 )
						{
							ViewModel.lbMilOpen.Text = ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + " / 0";
						}
						else
						{
							ViewModel.lbMilOpen.Text = ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + " / " + ((modGlobal.newMAXMIL - ViewModel.TotMil2).ToString());
						}
					}
				}
				else if ( ViewModel.bBothMILMAX )
				{
					if ( (modGlobal.newMAXMIL - ViewModel.TotMil1) <= 0 )
					{
						if ( (modGlobal.newMAXMIL - ViewModel.TotMil2) <= 0 )
						{
							ViewModel.lbMilOpen.Text = "0 / 0";
						}
						else
						{
							ViewModel.lbMilOpen.Text = "0 / " + ((modGlobal.newMAXMIL - ViewModel.TotMil2).ToString());
						}
					}
					else
					{
						if ( (modGlobal.newMAXMIL - ViewModel.TotMil2) <= 0 )
						{
							if ( ViewModel.TotMil1 > 0 )
							{
								ViewModel.lbMilOpen.Text = "*" + ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + "/ 0";
							//                    lbMILInfo.Visible = True
							}
							else
							{
								ViewModel.lbMilOpen.Text = ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + "/ 0";
							}
						}
						else
						{
							if ( ViewModel.TotMil1 > 0 )
							{
								ViewModel.lbMilOpen.Text = "*" + ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + "/ " + ((modGlobal.newMAXMIL - ViewModel.TotMil2).ToString());
							//                    lbMILInfo.Visible = True
							}
							else
							{
								ViewModel.lbMilOpen.Text = ((modGlobal.newMAXMIL - ViewModel.TotMil1).ToString()) + "/ " + ((modGlobal.newMAXMIL - ViewModel.TotMil2).ToString());
							}
						}
					}
				}
				else
				{
					if ( (modGlobal.MAXMIL - ViewModel.TotMil1) < 0 )
					{
						if ( (modGlobal.MAXMIL - ViewModel.TotMil2) < 0 )
						{
							ViewModel.lbMilOpen.Text = "0 / 0";
						}
						else
						{
							ViewModel.lbMilOpen.Text = "0 / " + ((modGlobal.MAXMIL - ViewModel.TotMil2).ToString());
						}
					}
					else
					{
						if ( (modGlobal.MAXMIL - ViewModel.TotMil2) < 0 )
						{
							ViewModel.lbMilOpen.Text = ((modGlobal.MAXMIL - ViewModel.TotMil1).ToString()) + " / 0";
						}
						else
						{
							ViewModel.lbMilOpen.Text = ((modGlobal.MAXMIL - ViewModel.TotMil1).ToString()) + " / " + ((modGlobal.MAXMIL - ViewModel.TotMil2).ToString());
						}
					}
				}

				if ( DateTime.Parse(BeginDate).Year < 2001 )
				{
					ViewModel.lbMilitary.Text = ViewModel.TotMil1.ToString();
					ViewModel.lbMilOpen.Text = ((modGlobal.MAXMIL - ViewModel.TotMil1).ToString());
				}

				// END OF NEW LOGIC

				//If Employee does not belong to assigned Debit Group
				//Determine total number of scheduled debit days
				if ( ViewModel.lbDebit.Text == "Total Debits" )
				{
					oCmd.CommandText = "sp_GetIndDebitTot '" + Empid + "', '" + BeginDate + "', '" + EndDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					if ( !oRec.EOF )
					{
						TDebits = (float)(Convert.ToDouble(oRec["total_debits"]) / 2);
						ViewModel.lbTotalDebits.Text = TDebits.ToString();
					}
					else
					{
						ViewModel.lbTotalDebits.Text = "0";
					}
				}

				return ;


     //   if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		return ;
					//	}

			}

		[UpgradeHelpers.Events.Handler]
		internal void calSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Come Here - for employee id change
            modGlobal
                .Shared.gDetailEmp = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			ViewModel.chkSCKflag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			modGlobal.Shared.gSCKFlag = 0;

			//If no current Employee selected exit sub
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( Strings.Len(modGlobal.Shared.gDetailEmp) < 5 || Convert.IsDBNull(modGlobal.Shared.gDetailEmp) || modGlobal.Shared.gDetailEmp == "" )
			{
				return ;
			}

			modGlobal.Shared.gDetailDate = ViewModel.calLeaveDate.Text;

			if ( modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "CPT" )
			{
				return ;
			}
			else if ( ViewModel.lbType.Text.Trim() == "CIV" || ViewModel.lbType.Text.Trim() == "VOL" )
			{
				ViewManager.ShowMessage("Not able to schedule CIV/VOL staff at this time...", "Personnel Tracking System", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			//    ElseIf Trim$(lbType) = "BAT" And gSecurity <> "ADM" Then
			//        If Trim$(lbPos.Caption) = "ISO" And gSecurity = "BAT" Then
			//            'added logic... ISO now has same scheduling restrictions as BCs... per T.Henderson
			//            If Format(gDetailDate, "m/d/yyyy") = Format(Now(), "m/d/yyyy") Or _
			//'                Format(gDetailDate, "m/d/yyyy") = Format(DateAdd("d", -1, Now()), "m/d/yyyy") Or _
			//'                Format(gDetailDate, "m/d/yyyy") = Format(DateAdd("d", 1, Now()), "m/d/yyyy") Then
			//                cmdAdd.Enabled = True
			//                cmdDelete.Enabled = True
			//                cmdUpdate.Enabled = True
			//            Else
			//                cmdAdd.Enabled = False
			//                cmdDelete.Enabled = False
			//                cmdUpdate.Enabled = False
			//            End If
			//        Else
			//            If Format(gDetailDate, "m/d/yyyy") = Format(Now(), "m/d/yyyy") Or _
			//'                Format(gDetailDate, "m/d/yyyy") = Format(DateAdd("d", -1, Now()), "m/d/yyyy") Or _
			//'                Format(gDetailDate, "m/d/yyyy") = Format(DateAdd("d", 1, Now()), "m/d/yyyy") Then
			//                cmdAdd.Enabled = True
			//                cmdUpdate.Enabled = True
			//                cmdDelete.Enabled = True
			//            Else
			//                cmdAdd.Enabled = False
			//                cmdDelete.Enabled = False
			//                cmdUpdate.Enabled = False
			//            End If
			//        End If
			}
			else
			{
				if ( modGlobal.Shared.TempSecurity )
				{
					if ( modGlobal.Shared.gUser == modGlobal.Shared.gDetailEmp )
					{
						ViewModel.cmdAdd.Enabled = false;
						ViewModel.cmdDelete.Enabled = false;
						ViewModel.cmdUpdate.Enabled = false;
						ViewManager.ShowMessage("You are not authorized to change your own schedule.", "PTS Schedule Update", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
					else
					{
						ViewModel.cmdAdd.Enabled = true;
						ViewModel.cmdDelete.Enabled = true;
						ViewModel.cmdUpdate.Enabled = true;
					}
				}
				else
				{
					ViewModel.cmdAdd.Enabled = true;
					ViewModel.cmdDelete.Enabled = true;
					ViewModel.cmdUpdate.Enabled = true;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void calSched_DoubleClick(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Call DisplayDetails subroutine with selected date
				//Come Here - for employee id change
                modGlobal
                    .Shared.gDetailEmp = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));

				//If no current Employee selected exit sub
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( Strings.Len(modGlobal.Shared.gDetailEmp) < 5 || Convert.IsDBNull(modGlobal.Shared.gDetailEmp) || modGlobal.Shared.gDetailEmp == "" )
				{
					this.Return();
					return ;
				}

				modGlobal.Shared.gDetailDate = ViewModel.calLeaveDate.Text;
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            frmTCEdit.DefInstance, true);
					});
				async1.Append(() =>
					{

						GetLeaveTotals();
						FillSchedule();
						GetDailyTotals();
					});
			}

		}

		//UPGRADE_WARNING: (2050) SSCalendarWidgets_A.SSYear Event calSched.InitYear was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		private void calSched_InitYear(int YearNum, int RtnCancel)
		{
				//Calendar moved to new year
				//Reload Schedule and Annual Leave Totals
				ViewModel.bUseNewMILMAX = false;
				ViewModel.bBothMILMAX = false;

				// MODIFY MIL LOGIC HERE ~ DKL May 2008
            modGlobal
                .Shared.gCurrentYear = YearNum;
				//    lbMILInfo.Visible = False
				if ( YearNum > 2001 )
				{
					ViewModel.lbYear.Text = "Oct " + (YearNum - 1).ToString() + "/Oct " + YearNum.ToString();
					//New MIL Maximums beginning Oct 2007 - Oct 2008
					if ( YearNum > 2008 )
					{
						ViewModel.bUseNewMILMAX = true;
					}
					else if ( YearNum == 2008 )
					{
						ViewModel.bBothMILMAX = true;
					}
				}
				else if ( YearNum == 2001 )
				{
					ViewModel.lbYear.Text = "Jan 2001/Oct 2001";
				}
				else
				{
					ViewModel.lbYear.Text = " ";
				}
				ViewModel.calLeaveDate.Text = "01/01/" + YearNum.ToString();
				modGlobal.Shared.gDetailDate = ViewModel.calLeaveDate.Text;

				SetAnnualCycleDays();
						GetLeaveTotals();
						FillSchedule();

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
				//Employee has been selected from the Name combobox
				//Employee detail fields are filled
				//Call GetLeaveTotals and FillSchedule subroutines
				//ADODB

				string Empid = "";
				string AddressString = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
				PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();

				try
				{

						//If subroutine triggered during Form Load event - exit
						//Come Here - for employee id change
						Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
						//    Empid = "01579" ' for archived employee
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( Strings.Len(Empid) < 5 || Convert.IsDBNull(Empid) || Empid == "" )
						{
							return ;
						}

						//Clear Employee Detail labels
						ViewModel.lbTitle.Text = "";
						ViewModel.lbType.Text = "";
						ViewModel.lbAddress.Text = "";
						ViewModel.lbCity.Text = "";
						ViewModel.lbZip.Text = "";
						ViewModel.lbPhone.Text = "";
						ViewModel.lbCOThire.Text = "";
						ViewModel.lbTFDhire.Text = "";
						ViewModel.lbBatt.Text = "";
						ViewModel.lbShift.Text = "";
						ViewModel.lbUnit.Text = "";
						ViewModel.lbPos.Text = "";
						ViewModel.lbTotalDebits.Text = "";
						ViewModel.lbCallBackNum.Text = "";
						ViewModel.lbSpecEvent.Text = "";
						ViewModel.lbDebit.Text = "Debit Group";
						ViewModel.FirstTime = -1;
						ViewModel.chkRecert.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						ViewModel.cmdAvailable.Visible = false;

						modGlobal.Shared.gDetailDate = DateTime.Now.ToString("MM/dd/yyyy");
						ViewModel.TrdFlag = false;
						ViewModel.chkSCKflag.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						modGlobal.Shared.gSCKFlag = 0;

						//    If chkLaunderTurnOuts.Value = 1 Then
						//        chkLaunderTurnOuts.Value = 0
						//        chkLaunderTurnOuts.Enabled = True
						//    End If

						//    If cUniform.GetTurnOutLastLaunderedInfo(Empid) Then
						//        If Clean(cUniform.UniformEmployee("LastDateCleaned"]) = "" Then
						//             lbLastLaundered.Caption = "The last laundered date is not available"
						//        Else
						//            lbLastLaundered.Caption = "Turnouts were last laundered on " & _
						//'                Format$(cUniform.UniformEmployee("LastDateCleaned"), "m/d/yyyy")
						//        End If
						//    Else
						//        lbLastLaundered.Caption = "No Turnout launder information exists"
						//    End If

						//Select Employee personnel and assignment detail
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "spReport_Employee '" + Empid + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( oRec.EOF )
						{
							ViewModel.cmdAdd.Enabled = false;
							ViewModel.cmdDelete.Enabled = false;
							ViewModel.cmdUpdate.Enabled = false;
							ViewModel.cmdPrint.Enabled = false;
							ViewModel.cmdSenority.Enabled = false;
							ViewModel.cmdSchedReport.Enabled = false;
							ViewModel.cmdTimeCard.Enabled = false;
							ViewModel.cmdRequestVAC.Enabled = false;
							ViewModel.cmdReqTransfer.Enabled = false;

							return ;
						}

						//Fill Employee Detail labels with Query results
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( Convert.IsDBNull(oRec["nameknownby"]) )
						{
							ViewModel.lbTitle.Text = Convert.ToString(oRec["job_title"]);
						}
						else
						{
							ViewModel.lbTitle.Text = Convert.ToString(oRec["job_title"]).Trim() + "          AKA:  " + Convert.ToString(oRec["nameknownby"]).Trim();
						}
						ViewModel.lbType.Text = modGlobal.Clean(oRec["assignment_type_code"]).Trim();
						ViewModel.cmdReqTransfer.Enabled = true;
						if ( ViewModel.lbType.Text.Trim() == "REG" || ViewModel.lbType.Text.Trim() == "MRN" || ViewModel.lbType.Text.Trim() == "PM" || ViewModel.lbType.Text.Trim() == "HZM" )
						{
							ViewModel.cmdRequestVAC.Enabled = !ViewModel.lbUnit.Text.StartsWith("CSR");
						}
						else
						{
							ViewModel.cmdRequestVAC.Enabled = false;
						}
						AddressString = modGlobal.Clean(Convert.ToString(oRec["address_full"]).Trim());
						AddressString = AddressString + " " + modGlobal.Clean(oRec["city"]).Trim();
						if ( AddressString == " " )
						{
							AddressString = "";
						}
						else
						{
							AddressString = AddressString + ", " + modGlobal.Clean(oRec["zip_code"]).Trim();
						}
						ViewModel.lbAddress.Text = AddressString;
						if ( modGlobal.Clean(oRec["phone_number"]) != "" )
						{
							ViewModel.lbPhone.Text = "Home/Cell: " + modGlobal.Clean(oRec["home_phone"]) + " / " + modGlobal.Clean(oRec["phone_number"]);
						}
						else
						{
							ViewModel.lbPhone.Text = "Home: " + modGlobal.Clean(oRec["home_phone"]);
						}
						ViewModel.lbCOThire.Text = modGlobal.Clean(oRec["COT_hire_date"]);
						ViewModel.lbTFDhire.Text = modGlobal.Clean(oRec["TFD_hire_date"]);
						ViewModel.lbBatt.Text = modGlobal.Clean(oRec["battalion_code"]);
						ViewModel.lbShift.Text = modGlobal.Clean(oRec["shift_code"]);
						ViewModel.lbUnit.Text = modGlobal.Clean(oRec["unit_code"]);
						ViewModel.lbPos.Text = modGlobal.Clean(oRec["position_code"]);
						ViewModel.lbTotalDebits.Text = modGlobal.Clean(oRec["debit_group_code"]);
						if ( ViewModel.lbTotalDebits.Text == "" )
						{
							ViewModel.lbDebit.Text = "Total Debits";
							ViewModel.lbTotalDebits.Text = "0";
						}
						if ( modGlobal.Clean(oRec["call_back_number"]) != "" )
						{
							ViewModel.lbCallBackNum.Text = "CallBack# = " + modGlobal.Clean(oRec["call_back_number"]);
						}
						//    If Clean(oRec("special_event"]) <> "" Then
						//        If Clean(oRec("special_event"]) = "N" Then
						//            lbSpecEvent.Caption = "Not Available For Special Events"
						//        ElseIf Clean(oRec("special_event"]) = "Y" Then
						//            lbSpecEvent.Caption = "Available For Special Events"
						//        End If
						//    End If
						if ( modGlobal.Clean(oRec["special_event"]) != "" )
						{
							if ( modGlobal.Clean(oRec["medic_flag"]) != "" )
							{
								if ( modGlobal.Clean(oRec["medic_flag"]) == "N" )
								{
									if ( modGlobal.Clean(oRec["special_event"]) == "N" )
									{
										ViewModel.lbSpecEvent.Text = "Not Available For Special Events";
									}
									else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
									{
										ViewModel.lbSpecEvent.Text = "Available For Special Events";
									}
								}
								else
								{
									//Clean(oRec("special_event"]) = "Y"
									if ( modGlobal.Clean(oRec["special_event"]) == "N" )
									{
										ViewModel.lbSpecEvent.Text = "Just Available For Medic 6";
									}
									else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
									{
										ViewModel.lbSpecEvent.Text = "Available For Special Events / Medic 6";
									}
								}
							}
							else
							{
								if ( modGlobal.Clean(oRec["special_event"]) == "N" )
								{
									ViewModel.lbSpecEvent.Text = "Not Available For Special Events";
								}
								else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
								{
									ViewModel.lbSpecEvent.Text = "Available For Special Events";
								}
							}
						}


						if ( modGlobal.Clean(oRec["recert_flag"]) != "" )
						{
							//UPGRADE_WARNING: (1068) GetVal(oRec(recert_flag)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							if ( Convert.ToDouble(modGlobal.GetVal(oRec["recert_flag"])) == 1 )
							{
								ViewModel.chkRecert.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
							}
							else
							{
								ViewModel.chkRecert.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
							}
						}
						else
						{
							ViewModel.chkRecert.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
						}

						if ( modGlobal.Clean(oRec["CSR_Flag"]) == "Y" )
						{
							ViewModel.cmdAvailable.Visible = true;
							ViewModel.cmdAvailable.Enabled = false;
						}
						else
						{
							ViewModel.cmdAvailable.Visible = false;
							ViewModel.cmdAvailable.Enabled = false;
						}
						ViewModel.FirstTime = 0;

								GetLeaveTotals();
								FillSchedule();

								if ( modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity == "CPT" )
								{
									if ( modGlobal.Shared.gUser == Empid && ViewModel.cmdAvailable.Visible )
									{
										ViewModel.cmdAvailable.Enabled = true;
									}
								//    ElseIf Trim$(lbType) = "BAT" And gSecurity <> "ADM" Then
								//        If cmdAvailable.Visible = True Then
								//            cmdAvailable.Enabled = True
								//        End If
								//        If Trim$(lbPos.Caption) = "ISO" And gSecurity = "BAT" Then
								//            cmdAdd.Enabled = True
								//            cmdDelete.Enabled = True
								//            cmdUpdate.Enabled = True
								//            cmdAdd.SetFocus
								//        Else
								//            cmdAdd.Enabled = False
								//            cmdDelete.Enabled = False
								//            cmdUpdate.Enabled = False
								//        End If
								}
								else
								{
									if ( ViewModel.cmdAvailable.Visible )
									{
										ViewModel.cmdAvailable.Enabled = true;
									}
									if ( modGlobal.Shared.TempSecurity )
									{
										if ( modGlobal.Shared.gUser == Empid )
										{
											ViewModel.cmdAdd.Enabled = false;
											ViewModel.cmdDelete.Enabled = false;
											ViewModel.cmdUpdate.Enabled = false;
										}
										else
										{
											ViewModel.cmdAdd.Enabled = true;
											ViewModel.cmdDelete.Enabled = true;
											ViewModel.cmdUpdate.Enabled = true;
											ViewManager.SetCurrent(ViewModel.cmdAdd);
										}
									}
									else
									{
										ViewModel.cmdAdd.Enabled = true;
										ViewModel.cmdDelete.Enabled = true;
										ViewModel.cmdUpdate.Enabled = true;
										ViewManager.SetCurrent(ViewModel.cmdAdd);
									}
								}

								if ( ViewModel.cmdCallBack.Visible )
								{
									ViewModel.cmdCallBack.Enabled = true;
								}

								if ( modGlobal.Shared.gSecurity == "ADM" )
								{
									if ( ViewModel.cmdAvailable.Visible )
									{
										ViewModel.cmdAvailable.Enabled = true;
									}
									ViewModel.cmdAdjustHOLMax.Visible = true;
									ViewModel.cmdAdjustHOLMax.Enabled = true;
									ViewModel.chkRecert.Visible = true;
								}

								//Civilians and Volunteer schedules are read only for now...
								if ( modGlobal.Clean(ViewModel.lbType.Text) == "CIV" || modGlobal.Clean(ViewModel.lbType.Text) == "VOL" )
								{
									ViewModel.cmdAdd.Enabled = false;
									ViewModel.cmdDelete.Enabled = false;
									ViewModel.cmdUpdate.Enabled = false;
									ViewModel.cmdPrint.Enabled = false;
									ViewModel.cmdSenority.Enabled = false;
									ViewModel.cmdSchedReport.Enabled = false;
									ViewModel.cmdTimeCard.Enabled = false;
									ViewModel.cmdRequestVAC.Enabled = false;
									ViewModel.cmdReqTransfer.Enabled = false;
									ViewModel.cmdAdjustHOLMax.Enabled = false;
									ViewModel.cmdCallBack.Enabled = false;
								}
								else
								{
									ViewModel.cmdPrint.Enabled = true;
									ViewModel.cmdSenority.Enabled = true;
									ViewModel.cmdSchedReport.Enabled = true;
									ViewModel.cmdTimeCard.Enabled = true;
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

		//UPGRADE_NOTE: (7001) The following declaration (chkLaunderTurnOuts_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void chkLaunderTurnOuts_Click()
		//{
		//clsUniform cUniform = new clsUniform();
		//clsUniform cUniformUpdate = new clsUniform();
		//
		//string Empid = cboNameList.Text.Substring(Math.Max(cboNameList.Text.Length - 5, 0));
		//if (Empid == "")
		//{
		//return;
		//}
		//
		//    If Not cUniform.GetTurnOutForLaundering(Empid) Then
		//        MsgBox "No Turnouts Assigned for this Employee.", vbOKOnly, "Get Turnout Information"
		//        chkLaunderTurnOuts.Enabled = False
		//        Exit Sub
		//    End If
		////
		//    If chkLaunderTurnOuts.Value <> 1 Then
		//        Exit Sub
		//    End If
		////
		//    Do Until cUniform.UniformEmployee.EOF
		//        'If launder_id is null... then Insert record
		//        If Clean(cUniform.UniformEmployee("launder_id"]) = "" Then
		//            cUniformUpdate.UniformLaunderUniformID = Clean(cUniform.UniformEmployee("uniform_id"])
		//            cUniformUpdate.UniformLaunderDateFlagged = Format$(Now(), "m/d/yyyy")
		//            cUniformUpdate.UniformLaunderFlaggedBy = gUser
		//            cUniformUpdate.UniformLaunderDateApproved = Format$(Now(), "m/d/yyyy")
		//            cUniformUpdate.UniformLaunderApprovedBy = gUser
		//            cUniformUpdate.UniformLaunderDateCleaned = Format$(Now(), "m/d/yyyy")
		//            cUniformUpdate.UniformLaunderCleanedBy = gUser
		//            cUniformUpdate.UniformLaunderComment = ""
		//            cUniformUpdate.UniformLaunderVendorCleaned = "N"
		//            cUniformUpdate.UniformLaunderCleaningComments = "Record Inserted Automatically on PTS Individual Scheduler"
		//            If cUniformUpdate.InsertUniformLaunderInfo Then
		//                MsgBox "Turnout Launder Record Successfully Inserted.", vbOKOnly, "Insert UniformLaunderInfo"
		//            Else
		//                MsgBox "Ooops! Error inserting Turnout Launder Record.", vbOKOnly, "Insert UniformLaunderInfo Error"
		//            End If
		//        Else 'launder_id is not null
		//            'date_approved is null or u2.date_cleaned is null then Insert record
		//            If Clean(cUniform.UniformEmployee("date_approved"]) = "" Or _
		//'               Clean(cUniform.UniformEmployee("date_cleaned"]) = "" Then
		//                cUniformUpdate.UniformLaunderUniformID = Clean(cUniform.UniformEmployee("uniform_id"])
		//                cUniformUpdate.UniformLaunderDateFlagged = Format$(Now(), "m/d/yyyy")
		//                cUniformUpdate.UniformLaunderFlaggedBy = gUser
		//                cUniformUpdate.UniformLaunderDateApproved = Format$(Now(), "m/d/yyyy")
		//                cUniformUpdate.UniformLaunderApprovedBy = gUser
		//                cUniformUpdate.UniformLaunderDateCleaned = Format$(Now(), "m/d/yyyy")
		//                cUniformUpdate.UniformLaunderCleanedBy = gUser
		//                cUniformUpdate.UniformLaunderComment = ""
		//                cUniformUpdate.UniformLaunderVendorCleaned = ""
		//                cUniformUpdate.UniformLaunderCleaningComments = "Record Inserted Automatically on PTS Individual Scheduler"
		//                If cUniformUpdate.InsertUniformLaunderInfo Then
		//                    MsgBox "Turnout Launder Record Successfully Inserted.", vbOKOnly, "Insert UniformLaunderInfo"
		//                Else
		//                    MsgBox "Ooops! Error inserting Turnout Launder Record.", vbOKOnly, "Insert UniformLaunderInfo Error"
		//                End If
		//            Else
		//                If cUniformUpdate.GetUniformLaunderInfoByID(GetVal(cUniform.UniformEmployee("launder_id"])) Then
		//                    If cUniformUpdate.UniformLaunderDateApproved = "" Then
		//                        cUniformUpdate.UniformLaunderDateApproved = Format$(Now(), "m/d/yyyy")
		//                        cUniformUpdate.UniformLaunderApprovedBy = gUser
		//                    End If
		//                    cUniformUpdate.UniformLaunderDateCleaned = Format$(Now(), "m/d/yyyy")
		//                    cUniformUpdate.UniformLaunderCleanedBy = gUser
		//                    cUniformUpdate.UniformLaunderCleaningComments = "Record Updated Automatically on PTS Individual Scheduler"
		//                    If cUniformUpdate.UpdateUniformLaunderInfo Then
		//                        MsgBox "Turnout Launder Record Successfully Updated.", vbOKOnly, "Update UniformLaunderInfo"
		//                    Else
		//                        MsgBox "Ooops! Error updating Turnout Launder Record.", vbOKOnly, "Update UniformLaunderInfo Error"
		//                    End If
		//                Else
		//                    MsgBox "Ooops! Error retrieving Turnout Launder Record.", vbOKOnly, "Error Retrieving UniformLaunderInfo"
		//                End If
		//            End If
		//        End If
		//        cUniform.UniformEmployee.MoveNext
		//    Loop
		////
		//    If cUniform.GetTurnOutLastLaunderedInfo(Empid) Then
		//        If Clean(cUniform.UniformEmployee("LastDateCleaned"]) = "" Then
		//             lbLastLaundered.Caption = "The last laundered date is not available"
		//        Else
		//            lbLastLaundered.Caption = "Turnouts were last laundered on " & _
		//'                Format$(cUniform.UniformEmployee("LastDateCleaned"), "m/d/yyyy")
		//        End If
		//    Else
		//        lbLastLaundered.Caption = "No Turnout launder information exists"
		//    End If
		//
		//}
		[UpgradeHelpers.Events.Handler]
		internal void chkRecert_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			int RecertFlag = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;

			if ( ViewModel.FirstTime != 0 )
			{
				return ;
			}
			if ( modGlobal.Shared.gSecurity != "ADM" )
			{
				return ;
			}

			string Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( Strings.Len(Empid) < 5 || Convert.IsDBNull(Empid) || Empid == "" )
			{
				return ;
			}

			if ( ViewModel.chkRecert.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				RecertFlag = 1;
			}
			else
			{
				RecertFlag = 0;
			}

			//Add Update logic here
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "";

			oCmd.CommandText = "spUpdatePersonnelRecertFlag '" + Empid + "', " + RecertFlag.ToString() + " ";
			oCmd.ExecuteNonQuery();

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkSCKflag_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.chkSCKflag.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				modGlobal.Shared.gSCKFlag = 1;
			}
			else
			{
				modGlobal.Shared.gSCKFlag = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Add new Leave Record requested
				//Collect needed info (Employee ID, Leave Date, Leave Type)
				//And call global ScheduleLeave function
				//Call GetLeaveTotals, FillSchedule and GetDailyTotals
				//To refresh form data
				//ADODB

				string Empid = "";
				//string TimeCode = "";
				int Response = 0;
				string LeaveDate = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				float RegCount = 0;
				//string AssignType = "";


				try
				{
					{
						//Come Here - for employee id change
						Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
						// Add button clicked w/ no Employee Selected
						if ( Empid == "" )
						{
							this.Return();
							return ;
						}

						modGlobal.Shared.GivingUpShift = false;
						//Determine Type of Leave
						if ( (((ViewModel.optLeaveType[0].Checked) ? -1 : 0) | ((ViewModel.optLeaveType[6].Checked) ? -1 : 0)) != 0 )
						{
							modGlobal.Shared.gLeaveType = "VAC";
							if ( ViewModel.optLeaveType[6].Checked )
							{
								modGlobal.Shared.gVacBank = -1;
							}
							else
							{
								modGlobal.Shared.gVacBank = 0;
							}
						}
						else if ( ViewModel.optLeaveType[1].Checked )
						{
							modGlobal.Shared.gLeaveType = "FHL";
						}
						else if ( ViewModel.optLeaveType[2].Checked )
						{
							modGlobal.Shared.gLeaveType = "MIL";
						}
						else if ( ViewModel.optLeaveType[7].Checked )
						{
							modGlobal.Shared.gLeaveType = "PTO";
						}
						else if ( ViewModel.optLeaveType[3].Checked )
						{
							//If Leave requested is other
							//display Leave Type dialog box
                            modGlobal
                                .Shared.gStartTrans = ViewModel.calLeaveDate.Value.Date.ToString("M/d/yyyy");
							modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
							//Add LEFF 1/2 Code
                            modGlobal
                                .Shared.gLType = "L";
							modGlobal.Shared.gSCKFlag = 0;
							modGlobal.Shared.gEmployeeId = Empid;
                            ViewManager.DisposeView(
                                dlgTime.DefInstance);
                            async1.Append(() =>
								{
                                    ViewManager.NavigateToView(
                                        dlgTime.DefInstance, true);
								});
							async1.Append(() =>
								{
									ViewModel.optLeaveType[6].Checked = modGlobal.Shared.gVacBank != 0;
									//If leave request canceled
									if ( modGlobal.Shared.gLeaveType == "" )
									{
										this.Return();
										return ;
									}

									if ( (modGlobal.Shared.gLeaveType == "KEL" || modGlobal.Shared.gLeaveType == "KLI") && ViewModel.lbType.Text.Trim() != "FCC" )
									{
										ViewManager.ShowMessage("You can only schedule FCC assigned staff for Kelly Day Leave", "Add Kelly Day Error", UpgradeHelpers.Helpers.BoxButtons.OK);
										this.Return();
										return ;
									}
									if ( modGlobal.Shared.gLeaveType == "KLI" )
									{
										ViewManager.ShowMessage("You can only use KLI when Updating a scheduled Kelly Day.", "Add KLI Error", UpgradeHelpers.Helpers.BoxButtons.OK);
										this.Return();
										return ;
									}
								});
						}
						else if ( ViewModel.optLeaveType[4].Checked )
						{
							string tempRefParam = "DDF";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized1 =>
								{
                                    var returningMetodValue4223 = tempNormalized1;
								
									tempRefParam = returningMetodValue4223.TimeType;
								});
							this.Return();
							return ;
						}
						else if ( ViewModel.optLeaveType[8].Checked )
						{
							string tempRefParam2 = "UDD";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam2));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized3 =>
								{
                                   var returningMetodValue4224 = tempNormalized3;
								
									tempRefParam2 = returningMetodValue4224.TimeType;
								});
							this.Return();
							return ;
						}
						else
						{
							string tempRefParam3 = "REG";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam3));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized5 =>
								{
                                    var returningMetodValue4225 = tempNormalized5;
								
									tempRefParam3 = returningMetodValue4225.TimeType;
								});
							this.Return();
							return ;
						}

						//Determine Date(s) for Leave Request
						//Call ScheduleLeave Function

						if ( modGlobal.Shared.gExtendLeave != 0 )
						{
							var ExtendLeaveReturningValue = default(PTSProject.modGlobal.ExtendLeaveStruct);
							async1.Append<PTSProject.modGlobal.ExtendLeaveStruct>(() => modGlobal.ExtendLeave(Empid));
                            async1.Append<PTSProject.modGlobal.ExtendLeaveStruct, PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized6 => tempNormalized6);
                            async1.Append<PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized7 =>
								{
                                    ExtendLeaveReturningValue = tempNormalized7;
								});
							async1.Append(() =>
								{

									Response = ExtendLeaveReturningValue.returnValue;

									Empid = ExtendLeaveReturningValue.Empid;
									if ( Response != 0 )
									{
									}
									else
									{
									}
								});
							this.Return();
							return ;
						}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									//ADODB
									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;

									//    CheckForUpgrade
									if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
									{
										LeaveDate = ViewModel.calLeaveDate.Text + " 7:00AM";
										if ( !modGlobal.CheckPayLock(LeaveDate, ViewModel.lbBatt.Text.Trim()) )
										{
											async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, LeaveDate));
                                            async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized9 =>
												{
                                                    var returningMetodValue = tempNormalized9;
												

													Response = returningMetodValue.returnValue;

													Empid = returningMetodValue.Empid;

													LeaveDate = returningMetodValue.LeaveDate;
													//Check for Schedule Leave failure
													if ( ~Response != 0 )
													{
														this.Return();
														return ;
													}
												});
										}
										else
										{
											if ( ViewModel.lbBatt.Text.Trim() == "1" )
											{
												ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else if ( ViewModel.lbBatt.Text.Trim() == "2" )
											{
												ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else
											{
												ViewManager.ShowMessage("Battalion 3 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											this.Return();
											return ;
										}
									}
									if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
									{
										LeaveDate = ViewModel.calLeaveDate.Text + " 7:00PM";

										if ( !modGlobal.CheckPayLock(LeaveDate, ViewModel.lbBatt.Text.Trim()) )
										{
											if ( ViewModel.optLeaveType[6].Checked )
											{
												modGlobal.Shared.gVacBank = -1;
											}
											else
											{
												modGlobal.Shared.gVacBank = 0;
											}
											async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, LeaveDate));
                                            async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized11 =>
												{
                                                    var returningMetodValue = tempNormalized11;
												


													Response = returningMetodValue.returnValue;

													Empid = returningMetodValue.Empid;

													LeaveDate = returningMetodValue.LeaveDate;
													//Check for Schedule Leave failure
													if ( ~Response != 0 )
													{
														this.Return();
														return ;
													}
												});
										}
										else
										{
											if ( ViewModel.lbBatt.Text.Trim() == "1" )
											{
												ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else if ( ViewModel.lbBatt.Text.Trim() == "2" )
											{
												ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else
											{
												ViewManager.ShowMessage("Battalion 3 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											this.Return();
											return ;
										}
									}
									async2.Append(() =>
										{


											GetLeaveTotals();
											FillSchedule();
											GetDailyTotals();

											//ADODB
											oCmd.Connection = modGlobal.oConn;
											oCmd.CommandType = CommandType.Text;

											oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + LeaveDate + "' ";
											oRec = ADORecordSetHelper.Open(oCmd, "");

											if ( !oRec.EOF )
											{
												//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                                modGlobal
                                                    .Shared.gMAXLEAVE = Convert.ToInt32(modGlobal.GetVal(oRec["max_leave_allowed"]));
											}
											else
											{
												modGlobal.Shared.gMAXLEAVE = 10;
											}

											//This section tests to determine if the Max Leave allowed
											//on this date has been reached
											oCmd.CommandText = "sp_GetLeaveCounts '" + ViewModel.lbType.Text + "', '" + LeaveDate + "'";
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( !oRec.EOF )
											{
												RegCount = Convert.ToSingle(oRec["total_leave"]);
												if ( ViewModel.lbType.Text.Trim() == "REG" || ViewModel.lbType.Text.Trim() == "BAT" )
												{
													//            If Trim$(lbType) <> "REG" Then
													//                oCmd.CommandText = "sp_GetLeaveCounts 'BAT', '" & LeaveDate & "'"
													//                Set oRec = oCmd.Execute
													//                If Not oRec.EOF Then
													//                    RegCount = RegCount + oRec("total_leave")
													//                End If
													//            Else
													//                oCmd.CommandText = "sp_GetLeaveCounts 'REG', '" & LeaveDate & "'"
													//                Set oRec = oCmd.Execute
													//                If Not oRec.EOF Then
													//                    RegCount = RegCount + oRec("total_leave")
													//                End If
													//            End If
													if ( RegCount >= modGlobal.Shared.gMAXLEAVE )
													{
														ViewManager.ShowMessage(RegCount.ToString() + "  Employees are now " + "scheduled for Leave on " + LeaveDate, "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
													}
												}
												else
												{
													if ( RegCount >= modGlobal.MAXLEAVEX )
													{
                                                        ViewManager.ShowMessage(Convert.ToString(oRec["total_leave"]) +
                                                            "  Employees are now scheduled " + "for Leave on " + LeaveDate, "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
													}
												}
											}
										});
								}
							});

					//ADD LOGIC FOR Trim$(lbType) = "FCC" TO REPORT IF AT OR BELOW MINIMUM STAFFING OF 4
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
		internal void cmdAddress_Click(Object eventSender, System.EventArgs eventArgs)
		{
				if ( modGlobal.Shared.gUser != "99999" )
				{
					modGlobal.Shared.gAssignID = modGlobal.Shared.gUser;
				}
            ViewManager.NavigateToView(

                frmAddress.DefInstance);
            /*            frmAddress.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdjustHOLMax_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//    MsgBox "This Function is coming soon!!", vbOKOnly, "Change Holiday Max Total"
				//Come Here - for employee id change
                modGlobal
                    .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				modGlobal.Shared.gReportYear = modGlobal.Shared.gCurrentYear;
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(

                            dlgChangeMaxHoliday.DefInstance, true);
					});
				async1.Append(() =>
					{

									GetLeaveTotals();
									FillSchedule();
									GetDailyTotals();
		
								});
						}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAvailable_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//frmIndAvailableToWork
            modGlobal
                .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
            ViewManager.NavigateToView(
                frmIndAvailableToWork.DefInstance);
			/*            frmIndAvailableToWork.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;

		//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCallBack_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				modGlobal.Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				string Empid = modGlobal.Shared.gReportUser;
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(

                            frmChangeCallBackNum.DefInstance, true);
					});
				async1.Append(() =>
					{

						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "spReport_Employee '" + Empid + "'";
						ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

						if ( oRec.EOF )
						{
							this.Return();
							return ;
						}
						else
						{
							ViewModel.lbCallBackNum.Text = "";
							ViewModel.lbSpecEvent.Text = "";
						}

						if ( modGlobal.Clean(oRec["call_back_number"]) != "" )
						{
							ViewModel.lbCallBackNum.Text = "CallBack# = " + modGlobal.Clean(oRec["call_back_number"]);
						}
						if ( modGlobal.Clean(oRec["special_event"]) != "" )
						{
							if ( modGlobal.Clean(oRec["medic_flag"]) != "" )
							{
								if ( modGlobal.Clean(oRec["medic_flag"]) == "N" )
								{
									if ( modGlobal.Clean(oRec["special_event"]) == "N" )
									{
										ViewModel.lbSpecEvent.Text = "Not Available For Special Events";
									}
									else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
									{
										ViewModel.lbSpecEvent.Text = "Available For Special Events";
									}
								}
								else
								{
									//Clean(oRec("special_event"]) = "Y"
									if ( modGlobal.Clean(oRec["special_event"]) == "N" )
									{
										ViewModel.lbSpecEvent.Text = "Just Available For Medic 6";
									}
									else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
									{
										ViewModel.lbSpecEvent.Text = "Available For Special Events / Medic 6";
									}
								}
							}
							else
							{
								if ( modGlobal.Clean(oRec["special_event"]) == "N" )
								{
									ViewModel.lbSpecEvent.Text = "Not Available For Special Events";
								}
								else if ( modGlobal.Clean(oRec["special_event"]) == "Y" )
								{
									ViewModel.lbSpecEvent.Text = "Available For Special Events";
								}
							}
						}

					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Unload Individual Leave Schedule form
			//Triggers Form unload event
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdContacts_Click(Object eventSender, System.EventArgs eventArgs)
		{

				if ( modGlobal.Shared.gUser != "99999" )
				{
					modGlobal.Shared.gAssignID = modGlobal.Shared.gUser;
				}
            ViewManager.NavigateToView(

                frmEmergencyContact.DefInstance);
            /*            frmEmergencyContact.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Delete Leave requested
				//Check for existing Leave record and then Delete
				//If leave was wellness update Wellness balance
				//Call GetLeaveTotals,FillSchedule and GetDailyTotals
				//To refresh form data
				//ADODB

				string Empid = "";
				string NewDate = "";
				string TimeCode = "";
				int VacBal = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				DbCommand oCmdDelete = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				string StartDate = "";
				string EndDate = "";
				string AMShift = "", PMShift = "";
				int AssignID = 0;
				string NoSched1 = "", NoSched2 = "";
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				//int NewBalance = 0;
				string sMessage = "";
				PTSProject.clsScheduler cScheduler = Container.Resolve<clsScheduler>();
				bool bMakeAvailable = false;

				try
				{
					{

						//Delete button clicked w/ no Employee Selected
						//Come Here - for employee id change
						Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
						if ( Empid == "" )
						{
							this.Return();
							return ;
						}


						//Determine Date(s) for Delete Leave Request
						if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
						{
							StartDate = ViewModel.calLeaveDate.Text + " 6:00AM";
							AMShift = ViewModel.calLeaveDate.Text + " 7:00AM";
							EndDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(StartDate).AddDays(1));
							PMShift = ViewModel.calLeaveDate.Text + " 7:00PM";
						}
						else if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
						{
							StartDate = ViewModel.calLeaveDate.Text + " 6:00AM";
							AMShift = ViewModel.calLeaveDate.Text + " 7:00AM";
							EndDate = ViewModel.calLeaveDate.Text + " 6:00PM";
							PMShift = "";
						}
						else if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
						{
							StartDate = ViewModel.calLeaveDate.Text + " 6:00PM";
							AMShift = "";
							EndDate = ViewModel.calLeaveDate.Text + " 8:00PM";
							PMShift = ViewModel.calLeaveDate.Text + " 7:00PM";
						}
						else
						{
							ViewManager.ShowMessage("You must check AM and/or PM", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}

						//Test to determine that Leave record(s) exists
						//and what type of Leave
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetEmpLeave '" + Empid + "', '" + StartDate + "', '" + EndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						//Check for Delete Schedule request
						if ( ViewModel.optLeaveType[4].Checked )
						{
							if ( oRec.EOF )
							{
								string tempRefParam = "DDF";
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam));
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized1 =>
									{
										var returningMetodValue4313 = tempNormalized1;
									
										tempRefParam = returningMetodValue4313.TimeType;
									});
								this.Return();
								return ;
							}
							else if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
							{
								ViewManager.ShowMessage("This Debit Day has been traded, Record was NOT Deleted", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								this.Return();
								return ;
							}
							else
							{
                                async1.Append<UpgradeHelpers.Helpers.DialogResult>((
                                        ) => ViewManager.ShowMessage("This Date has Leave Scheduled. Do you still want to delete Schedule?", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
									{
										Response = tempNormalized3;
									});
								if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
								{
									string tempRefParam2 = "DDF";
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam2));
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized5 =>
										{
											var returningMetodValue4318 = tempNormalized5;
										
											tempRefParam2 = returningMetodValue4318.TimeType;
										});
								}
								else
								{
									this.Return();
									return ;
								}
							}
						}
						else if ( ViewModel.optLeaveType[8].Checked )
						{
							if ( oRec.EOF )
							{
								string tempRefParam3 = "UDD";
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam3));
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized7 =>
									{
										var returningMetodValue4319 = tempNormalized7;
									
										tempRefParam3 = returningMetodValue4319.TimeType;
									});
								this.Return();
								return ;
							}
							else if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
							{
								ViewManager.ShowMessage("This Debit Day has been traded, Record was NOT Deleted", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								this.Return();
								return ;
							}
							else
							{
                                async1.Append<UpgradeHelpers.Helpers.DialogResult>((
                                        ) => ViewManager.ShowMessage("This Date has Leave Scheduled. Do you still want to delete Schedule?", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized8 => tempNormalized8);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized9 =>
									{
										Response = tempNormalized9;
									});
								if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
								{
									string tempRefParam4 = "UDD";
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam4));
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized11 =>
										{
											var returningMetodValue4324 = tempNormalized11;
										
											tempRefParam4 = returningMetodValue4324.TimeType;
										});
								}
								else
								{
									this.Return();
									return ;
								}
							}
						}
						else if ( ViewModel.optLeaveType[5].Checked )
						{
							if ( oRec.EOF )
							{
								string tempRefParam5 = "REG";
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam5));
								async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized13 =>
									{
										var returningMetodValue4325 = tempNormalized13;
									
										tempRefParam5 = returningMetodValue4325.TimeType;
									});
								this.Return();
								return ;
							}
							else if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
							{
                                ViewManager.ShowMessage("This Regular Scheduled Day has been traded, Record was NOT Deleted", "Individual Scheduler", UpgradeHelpers.Helpers
                                    .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								this.Return();
								return ;
							}
							else
							{
                                async1.Append<UpgradeHelpers.Helpers.DialogResult>((
                                        ) => ViewManager.ShowMessage("This Date has Leave Scheduled. Do you still want to delete Schedule?", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNo));
								async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized14 => tempNormalized14);
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized15 =>
									{
										Response = tempNormalized15;
									});
								if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
								{
									string tempRefParam6 = "REG";
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("DEL", tempRefParam6));
									async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized17 =>
										{
											var returningMetodValue4330 = tempNormalized17;
										
											tempRefParam6 = returningMetodValue4330.TimeType;
										});
								}
								else
								{
									this.Return();
									return ;
								}
							}
						}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									if ( oRec.EOF )
									{
										ViewManager.ShowMessage("Employee is not scheduled for leave on this date", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
										this.Return();
										return ;
									}
									else if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
									{
                                        ViewManager.ShowMessage("You must cancel Trades from the Battalion Scheduler, Leave Record was NOT Deleted", "Individual Scheduler", UpgradeHelpers
                                            .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										this.Return();
										return ;
									}
									else if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
									{
										TimeCode = modGlobal.Clean(oRec["time_code_id"]);
										if ( TimeCode == "VAC" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
										{
											VacBal = 1;
										}
										else
										{
											VacBal = 0;
										}
										if ( TimeCode == "VACFML" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
										{
											VacBal++;
										}
										if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
										{
											oRec.MoveNext();
											if ( oRec.EOF )
											{
												ViewManager.ShowMessage("Employee is not scheduled for both AM & PM leave " + "on this date", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
												this.Return();
												return ;
											}
											else
											{
												TimeCode = modGlobal.Clean(oRec["time_code_id"]);
												if ( (TimeCode == "VAC" || TimeCode == "VACFML") && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
												{
													VacBal++;
												}
											}
										}
									}
									else
									{
										TimeCode = modGlobal.Clean(oRec["time_code_id"]);
										if ( (TimeCode == "VAC" || TimeCode == "VACFML") && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
										{
											VacBal = 1;
										}
										else
										{
											VacBal = 0;
										}
									}

									//Check for Schedule Lock
									//Check for Schedule Conflicts
									if ( AMShift != "" )
									{
										if ( !modGlobal.CheckPayLock(AMShift, ViewModel.lbBatt.Text.Trim()) )
										{
											oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + AMShift + "'";
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( !oRec.EOF )
											{
												AssignID = Convert.ToInt32(oRec["assignment_id"]);
                                                if (modGlobal.DuplicateAssignment(Empid, AssignID, AMShift))
													{
																if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
																{
																	if ( Convert.ToString(oRec["battalion_code"]) == "3" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 3 Debit -";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized18 => tempNormalized18);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized19 =>
																			{
																				Response = tempNormalized19;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN183DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "2" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 2 Debit";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized20 => tempNormalized20);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized21 =>
																			{
																				Response = tempNormalized21;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN182DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 1 Debit";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized22 => tempNormalized22);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized23 =>
																			{
																				Response = tempNormalized23;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN181DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																}
																else
																{
																	if ( Convert.ToString(oRec["battalion_code"]) == "3" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 3 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized24 => tempNormalized24);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized25 =>
																			{
																				Response = tempNormalized25;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN183ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "2" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 2 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized26 => tempNormalized26);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized27 =>
																			{
																				Response = tempNormalized27;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN182ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "4" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 4 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized28 => tempNormalized28);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized29 =>
																			{
																				Response = tempNormalized29;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN184ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});

																	}
																	else
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for AM Shift as Batt 1 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized30 => tempNormalized30);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized31 =>
																			{
																				Response = tempNormalized31;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + AMShift + "'," + modGlobal.ASGN181ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																}
															}
														}
											}
										else
										{
											if ( ViewModel.lbBatt.Text.Trim() == "1" )
											{
												ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else
											{
												ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											this.Return();
											return ;
										}
									}
									if ( PMShift != "" )
									{
										if ( !modGlobal.CheckPayLock(PMShift, ViewModel.lbBatt.Text.Trim()) )
										{
											oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + PMShift + "'";
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( !oRec.EOF )
											{
												AssignID = Convert.ToInt32(oRec["assignment_id"]);
                                                if (modGlobal.DuplicateAssignment(Empid, AssignID, PMShift))
													{
																if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
																{
																	if ( Convert.ToString(oRec["battalion_code"]) == "3" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 3 Debit -";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized32 => tempNormalized32);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized33 =>
																			{
                                                                    Response = tempNormalized33;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN183DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "2" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 2 Debit";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized34 => tempNormalized34);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized35 =>
																			{
                                                                    Response = tempNormalized35;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN182DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 1 Debit";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized36 => tempNormalized36);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized37 =>
																			{
                                                                    Response = tempNormalized37;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN181DBT.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																}
																else
																{
																	if ( Convert.ToString(oRec["battalion_code"]) == "3" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 3 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized38 => tempNormalized38);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized39 =>
																			{
                                                                    Response = tempNormalized39;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN183ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "2" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 2 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized40 => tempNormalized40);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized41 =>
																			{
                                                                    Response = tempNormalized41;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN182ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else if ( Convert.ToString(oRec["battalion_code"]) == "4" )
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 4 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized42 => tempNormalized42);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized43 =>
																			{
                                                                    Response = tempNormalized43;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN184ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																	else
																	{
																		NoSched2 = "Due to Scheduling Conflict Employee will be scheduled for PM Shift as Batt 1 Rover";
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized44 => tempNormalized44);
                                                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized45 =>
																			{
                                                                    Response = tempNormalized45;
																			});
                                                            async2.Append(() =>
																			{
																				if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
																				{
																					NoSched1 = "spUpdateScheduleAssign '" + Empid + "','" + PMShift + "'," + modGlobal.ASGN181ROV.ToString() + ",'";
																					NoSched1 = NoSched1 + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																					oCmd.CommandText = NoSched1;
																					oCmd.ExecuteNonQuery();
																				}
																				else
																				{
																					ViewManager.ShowMessage("Delete PM Leave Canceled", "Delete Leave Request", UpgradeHelpers.Helpers.BoxButtons.OK);
																					this.Return();
																					return ;
																				}
																			});
																	}
																}
															}
														}
											}
										else
										{
											if ( ViewModel.lbBatt.Text.Trim() == "1" )
											{
												ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											else
											{
												ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
											}
											this.Return();
											return ;
										}
									}
									async2.Append(() =>
										{
                                            using ( var async3 = this.Async() )
											{

												bMakeAvailable = false;
												modGlobal.Shared.gAMShift = false;
												modGlobal.Shared.gPMShift = true;
												//ADD PAYROLL LOGIC HERE
												if ( ~modPTSPayroll.CheckPayrollForLeaveDelete(Empid, DateTime.Parse(ViewModel.calLeaveDate.Text).ToString("MM/dd/yyyy"), TimeCode) != 0 )
												{
													sMessage = "Ooops!! Payroll may have been Uploaded.  Delete payroll record first.  If you " + "experience any problems, please call Debra Lewandowsky x5068... Thanks";
													ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);

												}
												else
												{
													//Delete Leave record(s)
													oCmdDelete.Connection = modGlobal.oConn;
													oCmdDelete.CommandType = CommandType.StoredProcedure;
													oCmdDelete.CommandText = "spDeleteLeave";

													if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
													{
														NewDate = ViewModel.calLeaveDate.Text + " 7:00AM";
														oCmdDelete.ExecuteNonQuery(new object[] { Empid, NewDate });
														//            'Not Making Vacation Request Active again... commented out for now
														//            ocmd.CommandType = adCmdText
														//            ocmd.CommandText = "Select * From VacationRequest where " & _
														//'                "req_shift_start = '" & NewDate & "' And employee_id = '" & _
														//'                Empid & "' "
														//            Set orec = ocmd.Execute
														//            If Not orec.EOF Then
														//                ocmd.CommandType = adCmdText
														//                ocmd.CommandText = "Update VacationRequest set granted_by = Null, " & _
														//'                    "granted_date = Null where " & _
														//'                    "req_shift_start = '" & NewDate & "' And employee_id = '" & _
														//'                    Empid & "' "
														//                Set orec = ocmd.Execute
														//            End If
														if ( cScheduler.CheckForDateShiftAvailable(Empid, NewDate) != 0 )
														{
															System.DateTime TempDate = DateTime.FromOADate(0);
															modGlobal.Shared.gDetailDate = (DateTime.TryParse(NewDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : NewDate;
															modGlobal.Shared.gAMShift = true;
															bMakeAvailable = true;
														}
													}


													if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
													{
														NewDate = ViewModel.calLeaveDate.Text + " 7:00PM";
														oCmdDelete.ExecuteNonQuery(new object[] { Empid, NewDate });
														//            'Not Making Vacation Request Active again... commented out for now
														//            ocmd.CommandType = adCmdText
														//            ocmd.CommandText = "Select * From VacationRequest where " & _
														//'                "req_shift_start = '" & NewDate & "' And employee_id = '" & _
														//'                Empid & "' "
														//            Set orec = ocmd.Execute
														//            If Not orec.EOF Then
														//                ocmd.CommandType = adCmdText
														//                ocmd.CommandText = "Update VacationRequest set granted_by = Null, " & _
														//'                    "granted_date = Null where " & _
														//'                    "req_shift_start = '" & NewDate & "' And employee_id = '" & _
														//'                    Empid & "' "
														//                Set orec = ocmd.Execute
														//            End If
														if ( cScheduler.CheckForDateShiftAvailable(Empid, NewDate) != 0 )
														{
															System.DateTime TempDate2 = DateTime.FromOADate(0);
															modGlobal.Shared.gDetailDate = (DateTime.TryParse(NewDate, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : NewDate;
															modGlobal.Shared.gPMShift = true;
															bMakeAvailable = true;
														}
													}

													//        'Update Vacation Balance
													//        If VacBal > 0 Then
													//            ocmd.CommandType = adCmdText
													//            ocmd.CommandText = "sp_GetVacBalance '" & Empid & "'"
													//            Set orec = ocmd.Execute
													//            If Not orec.EOF Then
													//                NewBalance = orec("vacation_balance")
													//                NewBalance = NewBalance + VacBal
													//                ocmd.CommandType = adCmdStoredProc
													//                ocmd.CommandText = "spUpdateVacBalance"
													//                ocmd.Execute , Array(Empid, NewBalance)
													//            Else
													//            'Somehow a Vacation Bank was scheduled without a
													//            'Vacation_Balance record for this employee
													//            'Theoretically this should NEVER happen
													//            '- Display error message -
													//                MsgBox "Serious Database Error - No Vacation Balance Record exists for this employee! Please Report to System Admin at once!", vbCritical, "Delete Leave Error"
													//            End If
													//        End If


													if ( bMakeAvailable )
													{
														//ADD NEW LOGIC TO SEE IF THERE ARE REQUESTS FOR THIS DATE TIME
														NoSched2 = "There are Vacation Requests for " + modGlobal.Shared.gDetailDate;
														if ( modGlobal.Shared.gAMShift )
														{
															if ( modGlobal.Shared.gPMShift )
															{
																NoSched2 = NoSched2 + " AM/PM.  Would you like to grant the request?";
															}
															else
															{
																NoSched2 = NoSched2 + " AM.  Would you like to grant the request?";
															}
														}
														else
														{
															NoSched2 = NoSched2 + " PM.  Would you like to grant the request?";
														}
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(NoSched2, "Grant Vacation Request", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized46 => tempNormalized46);
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized47 =>
															{

                                                                Response = tempNormalized47;
															});
														if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
														{
															modGlobal.Shared.gParamedicSchedule = false;
															modGlobal.Shared.gHazmatSchedule = false;
															modGlobal.Shared.gFCCSchedule = false;
															modGlobal.Shared.gReportUser = "";
                                                            async3.Append(() =>
																{
                                                                    ViewManager.NavigateToView(
                                                                        dlgVacationRequest.DefInstance, true);
																});
														}
													}

												}
                                                async3.Append(() =>
													{
																	GetLeaveTotals();
																	FillSchedule();
																	GetDailyTotals();

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

		public void FillSchedule()
		{
				//Load Schedule control with Employees Regular and
				//Debit Days Scheduled by changing StyleSet for scheduled dates
				//ADODB

				string Empid = "";
				object BeginDate = null;
				string EndDate = "";
				string TimeType = "";
				string StyleType = "";

				object WorkDate = null;
				System.DateTime SaveDate = DateTime.FromOADate(0);
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				try
				{

					//If subroutine triggered by Form Load event - exit
					//Come Here - for employee id change
					Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
					//    Empid = "01579" ' for archived employee
					if ( Empid == "" )
					{
						return ;
					}

					//Re-initialize Year Calendar control
					ResetSchedCal();

					BeginDate = "1/1/" + modGlobal.Shared.gCurrentYear.ToString();
					//UPGRADE_WARNING: (1068) BeginDate of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					EndDate = Convert.ToDateTime(BeginDate).AddYears(1).ToString("M/d/yyyy");

					//Get Employees Schedule from Schedule table
					//Change Stylesets on Year Calendar for these dates
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					//UPGRADE_WARNING: (1068) BeginDate of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					oCmd.CommandText = "sp_GetIndYearSched '" + Empid + "', '" + Convert.ToString(BeginDate) + "', '" + EndDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//If no schedule or leave records exist for employee exit
					if ( oRec.EOF )
					{
						return ;
					}

					WorkDate = oRec["schedule_date"];
					SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["schedule_date"]).ToString("M/d/yyyy"));
					ViewModel.TrdFlag = false;
					ViewModel.OTFlag = false;
					ViewModel.NoteFlag = false;
					ViewModel.BankFlag = false;


					while ( !oRec.EOF )
					{
						if ( Convert.ToString(oRec["AMPM"]) == "AM" )
						{
							switch ( modGlobal.Clean(oRec["TimeType"]) )
							{
								case "REG":
								case "CTE":
								case "UCN":
									TimeType = modGlobal.REGSCHED;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "OTP":
								case "DOT":
								case "EOT":
								case "EDT":
								case "OTC":
								case "OTS":
								case "TID":
									TimeType = modGlobal.REGSCHED;
									ViewModel.OTFlag = true;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "DDF":
								case "UDD":
									TimeType = modGlobal.DEBAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "VAC":
								case "PTO":
								case "VACFML":
								case "PTOFML":
									TimeType = modGlobal.VACAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["VacBank"]) == "Y" )
									{
										ViewModel.BankFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "FHL":
								case "FHLFML":
									TimeType = modGlobal.HOLAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "MIL":
									TimeType = modGlobal.MILAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									//DNT = Duty Not There... new Code for non-FCC personnel 
									break;
								case "KEL":
								case "KLI":
								case "DNT":
									TimeType = modGlobal.KELAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "EDU":
								case "EDO":
									TimeType = modGlobal.EDUAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["TimeType"]) == "EDO" )
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "TRD": //Either Working or OFF 
									if ( modGlobal.Clean(oRec["leave_type"]) == "TRD" )
									{ //OFF

										ViewModel.TrdFlag = true;
									}
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "DDF" || modGlobal.Clean(oRec["schedule_type"]) == "UDD" )
									{
										TimeType = modGlobal.DEBAM; //OFF
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDU" )
									{
										TimeType = modGlobal.EDUAM;
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDO" )
									{
										TimeType = modGlobal.EDUAM;
										ViewModel.OTFlag = true;
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										TimeType = modGlobal.TRDAM;
									}
									else
									{
										TimeType = modGlobal.REGSCHED;
										if ( modGlobal.Clean(oRec["schedule_type"]) == "REG" || modGlobal.Clean(oRec["schedule_type"]) == "CTE" )
										{
										//continue
										}
										else
										{
											ViewModel.OTFlag = true;
										}
									}
									break;
								default:
									TimeType = modGlobal.OTHAM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
							}
							oRec.MoveNext();
							if ( oRec.EOF )
							{
								if ( TimeType == modGlobal.REGSCHED )
								{
									StyleType = "amReg";
									if ( ViewModel.OTFlag )
									{
										StyleType = "RevamRegOT";
										ViewModel.OTFlag = false;
									}
									if ( ViewModel.TrdFlag )
									{
										StyleType = "RevamReg";
										ViewModel.TrdFlag = false;
									}
									if ( ViewModel.NoteFlag )
									{
										StyleType = "amRegNote";
										ViewModel.NoteFlag = false;
									}
								}
								else
								{
									TimeType = TimeType + modGlobal.NOSCHED;
									StyleType = SetStyleType(TimeType);
								}
								//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
								ViewModel.calSched.getX().Day(SaveDate).StyleSet = StyleType;
								break;
							}
							if ( oRec["schedule_date"] == WorkDate )
							{
								switch ( modGlobal.Clean(oRec["TimeType"]) )
								{
									case "REG":
									case "CTE":
									case "UCN":
										TimeType = TimeType + modGlobal.REGSCHED;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										break;
									case "OTP":
									case "DOT":
									case "EOT":
									case "EDT":
									case "OTC":
									case "OTS":
									case "TID":
										TimeType = TimeType + modGlobal.REGSCHED;
										ViewModel.OTFlag = true;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										break;
									case "DDF":
									case "UDD":
										TimeType = TimeType + modGlobal.DEBPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										break;
									case "VAC":
									case "PTO":
									case "VACFML":
									case "PTOFML":
										TimeType = TimeType + modGlobal.VACPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["VacBank"]) == "Y" )
										{
											ViewModel.BankFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											ViewModel.TrdFlag = true;
										}
                                    else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
										{
											ViewModel.OTFlag = true;
										}
										break;
									case "FHL":
									case "FHLFML":
										TimeType = TimeType + modGlobal.HOLPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											ViewModel.TrdFlag = true;
										}
                                    else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
										{
											ViewModel.OTFlag = true;
										}
										break;
									case "MIL":
										TimeType = TimeType + modGlobal.MILPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											ViewModel.TrdFlag = true;
										}
                                    else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
										{
											ViewModel.OTFlag = true;
										}
										//DNT = Duty Not There... new Code for non-FCC personnel 
										break;
									case "KEL":
									case "KLI":
									case "DNT":
										TimeType = TimeType + modGlobal.KELPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											ViewModel.TrdFlag = true;
										}
                                    else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
										{
											ViewModel.OTFlag = true;
										}
										break;
									case "EDU":
									case "EDO":
										TimeType = TimeType + modGlobal.EDUPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["TimeType"]) == "EDO" )
										{
											ViewModel.OTFlag = true;
										}
										break;
									case "TRD": //Either Working or OFF 
										if ( modGlobal.Clean(oRec["leave_type"]) == "TRD" )
										{ //OFF

											ViewModel.TrdFlag = true;
										}
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "DDF" || modGlobal.Clean(oRec["schedule_type"]) == "UDD" )
										{
											TimeType = TimeType + modGlobal.DEBPM; //OFF
										}
										else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDU" )
										{
											TimeType = TimeType + modGlobal.EDUPM;
										}
										else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDO" )
										{
											TimeType = TimeType + modGlobal.EDUPM;
											ViewModel.OTFlag = true;
										}
										else if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											TimeType = TimeType + modGlobal.TRDPM;
										}
										else
										{
											TimeType = TimeType + modGlobal.REGSCHED;
											if ( modGlobal.Clean(oRec["schedule_type"]) == "REG" || modGlobal.Clean(oRec["schedule_type"]) == "CTE" )
											{
											//continue
											}
											else
											{
												ViewModel.OTFlag = true;
											}
										}
										break;
									default:
										TimeType = TimeType + modGlobal.OTHPM;
										if ( modGlobal.Clean(oRec["notes"]) == "Y" )
										{
											ViewModel.NoteFlag = true;
										}
										if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
										{
											ViewModel.TrdFlag = true;
										}
                                    else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
										{
											ViewModel.OTFlag = true;
										}
										break;
								}
								StyleType = SetStyleType(TimeType);
								//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
								ViewModel.calSched.getX().Day(SaveDate).StyleSet = StyleType;
								oRec.MoveNext();
								if ( !oRec.EOF )
								{
									WorkDate = oRec["schedule_date"];
									SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["schedule_date"]).ToString("M/d/yyyy"));
									StyleType = "";
									TimeType = "";
								}
							}
							else
							{
								if ( TimeType == modGlobal.REGSCHED )
								{
									StyleType = "amReg";
									if ( ViewModel.OTFlag )
									{
										StyleType = "RevamRegOT";
										ViewModel.OTFlag = false;
									}
									if ( ViewModel.TrdFlag )
									{
										StyleType = "RevamReg";
										ViewModel.TrdFlag = false;
									}
									if ( ViewModel.NoteFlag )
									{
										StyleType = "amRegNote";
										ViewModel.NoteFlag = false;
									}
								}
								else
								{
									TimeType = TimeType + modGlobal.NOSCHED;
									StyleType = SetStyleType(TimeType);
								}
								//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
								ViewModel.calSched.getX().Day(SaveDate).StyleSet = StyleType;
								TimeType = "";
								StyleType = "";
								WorkDate = oRec["schedule_date"];
								SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["schedule_date"]).ToString("M/d/yyyy"));
							}
						}
						else
						{
							TimeType = modGlobal.NOSCHED;
							switch ( modGlobal.Clean(oRec["TimeType"]) )
							{
								case "REG":
								case "CTE":
								case "UCN":
									TimeType = TimeType + modGlobal.REGSCHED;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "OTP":
								case "DOT":
								case "EOT":
								case "EDT":
								case "OTC":
								case "OTS":
								case "TID":
									TimeType = TimeType + modGlobal.REGSCHED;
									ViewModel.OTFlag = true;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "DDF":
								case "UDD":
									TimeType = TimeType + modGlobal.DEBPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									break;
								case "VAC":
								case "PTO":
								case "VACFML":
								case "PTOFML":
									TimeType = TimeType + modGlobal.VACPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["VacBank"]) == "Y" )
									{
										ViewModel.BankFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "FHL":
								case "FHLFML":
									TimeType = TimeType + modGlobal.HOLPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "MIL":
									TimeType = TimeType + modGlobal.MILPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									//DNT = Duty Not There... new Code for non-FCC personnel 
									break;
								case "KEL":
								case "KLI":
								case "DNT":
									TimeType = TimeType + modGlobal.KELPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "EDU":
								case "EDO":
									TimeType = TimeType + modGlobal.EDUPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["TimeType"]) == "EDO" )
									{
										ViewModel.OTFlag = true;
									}
									break;
								case "TRD": //Either Working or OFF 
									if ( modGlobal.Clean(oRec["leave_type"]) == "TRD" )
									{ //OFF

										ViewModel.TrdFlag = true;
									}
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}

									if ( modGlobal.Clean(oRec["schedule_type"]) == "DDF" || modGlobal.Clean(oRec["schedule_type"]) == "UDD" )
									{
										TimeType = TimeType + modGlobal.DEBPM;
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDU" )
									{
										TimeType = TimeType + modGlobal.EDUPM;
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "EDO" )
									{
										TimeType = TimeType + modGlobal.EDUPM;
										ViewModel.OTFlag = true;
									}
									else if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										TimeType = TimeType + modGlobal.TRDPM;
									}
									else
									{
										TimeType = TimeType + modGlobal.REGSCHED;
										if ( modGlobal.Clean(oRec["schedule_type"]) == "REG" || modGlobal.Clean(oRec["schedule_type"]) == "CTE" )
										{
										//continue
										}
										else
										{
											ViewModel.OTFlag = true;
										}
									}
									break;
								default:
									TimeType = TimeType + modGlobal.OTHPM;
									if ( modGlobal.Clean(oRec["notes"]) == "Y" )
									{
										ViewModel.NoteFlag = true;
									}
									if ( modGlobal.Clean(oRec["schedule_type"]) == "TRD" )
									{
										ViewModel.TrdFlag = true;
									}
                                else if (modGlobal.Clean(oRec["schedule_type"]) == "OTP" || modGlobal.Clean(oRec["schedule_type"]) == "DOT" || modGlobal.Clean(oRec["schedule_type"]) == "EOT" || modGlobal.Clean(oRec["schedule_type"]) == "EDT" || modGlobal.Clean(oRec["schedule_type"]) == "OTC" || modGlobal.Clean(oRec["schedule_type"]) == "OTS" || modGlobal.Clean(oRec["schedule_type"]) == "TID" || modGlobal.Clean(oRec["schedule_type"]) == "EDO")
									{
										ViewModel.OTFlag = true;
									}
									break;
							}
							StyleType = SetStyleType(TimeType);
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calSched.getX().Day(SaveDate).StyleSet = StyleType;
							oRec.MoveNext();
							if ( !oRec.EOF )
							{
								WorkDate = oRec["schedule_date"];
								SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["schedule_date"]).ToString("M/d/yyyy"));
								TimeType = "";
								StyleType = "";
							}
						}
        };
				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		//UPGRADE_WARNING: (2050) SSCalendarWidgets_A.SSYear Event calSched.SelChange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		public void calSched_SelChange(string SelDate, string OldSelDate, int Selected, int RtnCancel)
		{

				//This event occurs if a day on the calSched control is selected.
				//If the day is being deselected the subroutine is exited.
				//If the day is being selected a subroutine is called
				//to determine leave totals for
				//that date.  These totals are then displayed.
				//Selected Date in removed from the Selected Days collection
				//so any Stylesets for this day display correctly

				if ( ~Selected != 0 )
				{
					return ;
				}
				if ( ViewModel.SkipProcess != 0 )
				{
					return ;
				}
				ViewModel.calLeaveDate.Value = DateTime.Parse(SelDate);
						GetDailyTotals();
						if ( ViewModel.SkipProcess != 0 )
						{
							return ;
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calSched.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calSched.getX().SelectedDays.RemoveAll();
						}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gAssignID = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
            ViewManager.NavigateToView(

                frmEmployeeNotes.DefInstance);
			/*            frmEmployeeNotes.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPhone_Click(Object eventSender, System.EventArgs eventArgs)
		{

				if ( modGlobal.Shared.gUser != "99999" )
				{
					modGlobal.Shared.gAssignID = modGlobal.Shared.gUser;
				}
            ViewManager.NavigateToView(

                frmPhone.DefInstance);
            /*            frmPhone.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display frmIndivReport
			//Report will default to selected Employee
			//Come Here - for employee id change
            modGlobal
                .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			modGlobal.Shared.gReportYear = modGlobal.Shared.gCurrentYear;
            ViewManager.NavigateToView(
                frmIndivReport.DefInstance);
			/*            frmIndivReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReqTransfer_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//    MsgBox "This Feature is coming soon!", vbOKOnly, "New Request Transfer Screen"
				if ( !Information.IsDate(modGlobal.Shared.gDetailDate) )
				{
					modGlobal.Shared.gDetailDate = DateTime.Now.ToString("MM/dd/yyyy");
				}
				//Come Here - for employee id change
                modGlobal
                    .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            dlgRequestTransfer.DefInstance, true);
					});
				async1.Append(() =>
					{
						modGlobal.Shared.gDetailDate = "";
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRequestVAC_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				if ( !Information.IsDate(modGlobal.Shared.gDetailDate) )
				{
					modGlobal.Shared.gDetailDate = DateTime.Now.ToString("MM/dd/yyyy");
				}
				//Come Here - for employee id change
				if ( ViewModel.lbType.Text.Trim() == "PM" )
				{
					modGlobal.Shared.gParamedicSchedule = true;
					modGlobal.Shared.gHazmatSchedule = false;
					modGlobal.Shared.gFCCSchedule = false;
				}
				else if ( ViewModel.lbType.Text.Trim() == "HZM" )
				{
					modGlobal.Shared.gHazmatSchedule = true;
					modGlobal.Shared.gParamedicSchedule = false;
					modGlobal.Shared.gFCCSchedule = false;
				}
				else
				{
					modGlobal.Shared.gParamedicSchedule = false;
					modGlobal.Shared.gHazmatSchedule = false;
					modGlobal.Shared.gFCCSchedule = false;
				}
				modGlobal.Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            dlgVacationRequest.DefInstance, true);
					});
				async1.Append(() =>
					{
						modGlobal.Shared.gDetailDate = "";
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSchedReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Come Here - for employee id change
            modGlobal
                .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			modGlobal.Shared.gReportYear = modGlobal.Shared.gCurrentYear;
            ViewManager.NavigateToView(
                frmIndivSchedReport.DefInstance);
			/*            frmIndivSchedReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSenority_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Load Senority Ranking Inquiry Form
            ViewManager.NavigateToView(
                //Load Senority Ranking Inquiry Form

 frmSenority.DefInstance);
            /*            frmSenority.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display frmIndTimeCard
			//Report will default to selected Employee
			//Come Here - for employee id change
            modGlobal
                .Shared.gReportUser = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Determine if there is an existing Leave Record
				//Test Leave request to determine if Leave Maximum's
				//will be exceeded
				//Update Leave record  as needed
				//Call GetLeaveTotals, FillSchedule and GetDailyTotals
				//To refresh Form data

				string Empid = "";
				string NewDate = "";
				string TimeCode = "";
				int Response = 0;
				string StartDate = "";
				string EndDate = "";
				System.DateTime TestDate = DateTime.FromOADate(0);
				System.DateTime TodaysDate = DateTime.FromOADate(0);
				//int BankHold = 0;
				int NewBalance = 0;
				int CurrBank = 0;
				//int EffectiveDate = 0;
				byte VBankFlag = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				ADORecordSetHelper orec2 = null;

				try
				{
					{

						//Add button clicked w/ no Employee Selected - exit
						//Come Here - for employee id change
						Empid = ViewModel.cboNameList.Text.Substring(Math.Max(ViewModel.cboNameList.Text.Length - 5, 0));
						if ( Empid == "" )
						{
							this.Return();
							return ;
						}

						//Determine Type of Leave
						if ( (((ViewModel.optLeaveType[0].Checked) ? -1 : 0) | ((ViewModel.optLeaveType[6].Checked) ? -1 : 0)) != 0 )
						{
							TimeCode = "VAC";
						}
						else if ( ViewModel.optLeaveType[1].Checked )
						{
							TimeCode = "FHL";
						}
						else if ( ViewModel.optLeaveType[2].Checked )
						{
							TimeCode = "MIL";
						}
						else if ( ViewModel.optLeaveType[7].Checked )
						{
							TimeCode = "PTO";
						}
						else if ( ViewModel.optLeaveType[3].Checked )
						{

							//********************************************************
							//Other Leave requested - display Leave Type dialog
							//********************************************************
                            modGlobal
                                .Shared.gPayType = "";
							modGlobal.Shared.gLeaveType = "";
							modGlobal.Shared.gSCKFlag = 0;
							modGlobal.Shared.gVacBank = 0;
							modGlobal.Shared.gStartTrans = ViewModel.calLeaveDate.Value.Date.ToString("M/d/yyyy");
							modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
							//Add LEFF 1/2 Code
                            modGlobal
                                .Shared.gLType = "L";
							modGlobal.Shared.gEmployeeId = Empid;
                            async1.Append(() =>
								{
                                    ViewManager.NavigateToView(
                                        dlgTime.DefInstance, true);
								});
							async1.Append(() =>
								{
									if ( modGlobal.Shared.gLeaveType == "" )
									{
										this.Return();
										return ;
									}

									TimeCode = modGlobal.Shared.gLeaveType;
									if ( (TimeCode == "KEL" || TimeCode == "KLI") && ViewModel.lbType.Text.Trim() != "FCC" )
									{
										ViewManager.ShowMessage("You can only schedule FCC assigned staff for Kelly Day Leave", "Add Kelly Day Error", UpgradeHelpers.Helpers.BoxButtons.OK);
										this.Return();
										return ;
									}
								});


						}
						else if ( ViewModel.optLeaveType[4].Checked )
						{
							string tempRefParam = "DDF";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized1 =>
								{
                                    var returningMetodValue4962 = tempNormalized1;
								
									tempRefParam = returningMetodValue4962.TimeType;
								});
							this.Return();
							return ;
						}
						else if ( ViewModel.optLeaveType[8].Checked )
						{
							string tempRefParam2 = "UDD";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam2));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized3 =>
								{
                                   var returningMetodValue4963 = tempNormalized3;
								
									tempRefParam2 = returningMetodValue4963.TimeType;
								});
							this.Return();
							return ;
						}
						else
						{
							string tempRefParam3 = "REG";
							async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(() => ScheduleTime("ADD", tempRefParam3));
                            async1.Append<PTSProject.frmIndSched.ScheduleTimeStruct>(tempNormalized5 =>
								{
                                   var returningMetodValue4964 = tempNormalized5;
								
								   tempRefParam3 = returningMetodValue4964.TimeType;
								});
							this.Return();
							return ;
						}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									//Determine Date(s) for Leave Request
									if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
									{
										StartDate = ViewModel.calLeaveDate.Text + " 6:00AM";
										NewDate = ViewModel.calLeaveDate.Text + " 7:00AM";
										EndDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(StartDate).AddDays(1));
									}
									else
									{
										if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
										{
											StartDate = ViewModel.calLeaveDate.Text + " 6:00AM";
											NewDate = ViewModel.calLeaveDate.Text + " 7:00AM";
											EndDate = ViewModel.calLeaveDate.Text + " 6:00PM";
										}
										else
										{
											if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
											{
												StartDate = ViewModel.calLeaveDate.Text + " 6:00PM";
												NewDate = ViewModel.calLeaveDate.Text + " 7:00PM";
												EndDate = ViewModel.calLeaveDate.Text + " 8:00PM";
											}
											else
											{
												//Neither AM or PM checked - exit sub
												ViewManager.ShowMessage("You must check AM and/or PM", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
												this.Return();
												return ;
											}
										}
									}

									TestDate = DateTime.Parse(ViewModel.calLeaveDate.Text);
									TodaysDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));

									if ( modGlobal.Shared.gExtendLeave != 0 )
									{
										var ExtendLeaveReturningValue = default(PTSProject.modGlobal.ExtendLeaveStruct);
										async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(() => modGlobal.ExtendLeave(Empid));
                                        async2.Append<PTSProject.modGlobal.ExtendLeaveStruct, PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized6 => tempNormalized6);
                                        async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized7 =>
											{
                                                ExtendLeaveReturningValue = tempNormalized7;
											});
										async2.Append(() =>
											{

												Response = ExtendLeaveReturningValue.returnValue;

												Empid = ExtendLeaveReturningValue.Empid;
												if ( Response != 0 )
												{
												}
												else
												{
												}
											});
										this.Return();
										return ;
									}
									async2.Append(() =>
										{
											using ( var async3 = this.Async() )
											{

												//This section tests to make sure date is already
												//scheduled for leave
												oCmd.Connection = modGlobal.oConn;
												oCmd.CommandType = CommandType.Text;
												oCmd.CommandText = "sp_GetEmpLeave '" + Empid + "', '" + StartDate + "', '" + EndDate + "'";
												oRec = ADORecordSetHelper.Open(oCmd, "");

												if ( oRec.EOF )
												{
													ViewManager.ShowMessage("Employee is not scheduled for leave on this date, " + "Use 'Add Leave' to Schedule", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
													this.Return();
													return ;
												}
												else if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													if ( modGlobal.Shared.gSCKFlag == 1 )
													{

													}
													else
													{
                                                        ViewManager.ShowMessage("You must update Trades from the Battalion Scheduler, Leave Record was NOT Updated", "Individual Scheduler", UpgradeHelpers
                                                            .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
														this.Return();
														return ;
													}
												}
												else
												{
													if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
													{
														if ( modGlobal.Clean(oRec["time_code_id"]) == "VAC" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
														{
															CurrBank = 1;
														}
														else
														{
															CurrBank = 0;
														}
														if ( modGlobal.Clean(oRec["time_code_id"]) == "VACFML" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
														{
															CurrBank++;
														}
														if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
														{
															oRec.MoveNext();
															if ( oRec.EOF )
															{
                                                                ViewManager.ShowMessage("Employee is not scheduled for leave on both AM & PM, " +
                                                                    "Use 'Add Leave' to Schedule or Select appropriate half shift", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
																this.Return();
																return ;
															}
															else
															{
																if ( modGlobal.Clean(oRec["time_code_id"]) == "VAC" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
																{
																	CurrBank++;
																}
																if ( modGlobal.Clean(oRec["time_code_id"]) == "VACFML" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
																{
																	CurrBank++;
																}
															}
														}
													}
													else
													{
														if ( modGlobal.Clean(oRec["time_code_id"]) == "VAC" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
														{
															CurrBank = 1;
														}
														else
														{
															CurrBank = 0;
														}
														if ( modGlobal.Clean(oRec["time_code_id"]) == "VACFML" && Convert.ToDouble(oRec["vacation_bank_flag"]) != 0 )
														{
															CurrBank++;
														}
													}
												}

												string sMessage = "";
												//Check for Payroll... delete if not uploaded and give a warning here too
												if ( ~modPTSPayroll.CheckPayrollForLeaveDelete(Empid, DateTime.Parse(ViewModel.calLeaveDate.Text).ToString("MM/dd/yyyy"), modGlobal.Clean(oRec["time_code_id"])) != 0 )
												{
                                                    sMessage = "WARNING! A payroll record for " + modGlobal.Clean(oRec["time_code_id"]) + " on " + DateTime.Parse(ViewModel.calLeaveDate.Text).ToString("MM/dd/yyyy") +
                                                            " exists!!  Please contact your BC or Peggy Dundas... Thanks";
													ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
													this.Return();
													return ;
												}

												//LOGIC for new KLI TimeCode...
												if ( TimeCode == "KLI" && modGlobal.Clean(oRec["time_code_id"]) != "KEL" )
												{
													Response = (int)ViewManager.ShowMessage("You can only schedule KLI on a Kelly Day. ", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK).ResolvedValue;
													this.Return();
													return ;
												}

												//This section checks to determine if Employee is about to
												//Exceed amount of authorized Leave for the requested Type

												if ( (((TimeCode == "VAC" || TimeCode == "VACFML") ? -1 : 0) & ((ViewModel.optLeaveType[0].Checked) ? -1 : 0)) != 0 )
												{
													if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
													{
														if ( Conversion.Val(ViewModel.lbVacOpen.Text) < 1 )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Vacation " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized8 => tempNormalized8);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized9 => (int)tempNormalized9);
                                                            async3.Append<System.Int32>(tempNormalized10 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized10;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}
													else
													{
														if ( Conversion.Val(ViewModel.lbVacOpen.Text) < 0.5d )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Vacation " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized11 => tempNormalized11);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized12 => (int)tempNormalized12);
                                                            async3.Append<System.Int32>(tempNormalized13 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized13;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}

												}
												else if ( ViewModel.optLeaveType[6].Checked )
												{
													if ( TestDate > TodaysDate )
													{
                                                        async3.Append<Microsoft.VisualBasic.MsgBoxResult>(() =>
                                                                Interaction.MsgBox("Policy does not allow for future scheduling of Banked Vacation " + "\n" + "Proceed anyway?", (Microsoft
                                                            .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                        async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized14 => tempNormalized14);
                                                        async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized15 => (int)tempNormalized15);
                                                        async3.Append<System.Int32>(tempNormalized16 =>
															{
																//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                Response = tempNormalized16;
															});
														async3.Append(() =>
															{
																if ( Response == 2 )
																{
																	this.Return();
																	return ;
																}
															});
													}
													async3.Append(() =>
														{
															using ( var async4 = this.Async() )
															{
																oCmd.CommandType = CommandType.Text;
																oCmd.CommandText = "sp_GetVacBalance '" + Empid + "'";
																orec2 = ADORecordSetHelper.Open(oCmd, "");
																if ( !orec2.EOF )
																{
																	NewBalance = Convert.ToInt32(orec2["vacation_balance"]);
																	if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
																	{
																		if ( NewBalance < 2 )
																		{
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                                    => Interaction.MsgBox("You will be exceeding the Vacation Balance " + "of this Employee.  Proceed anyway?", (Microsoft
                                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized17 => tempNormalized17);
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized18 => (int)tempNormalized18);
                                                                            async4.Append<System.Int32>(tempNormalized19 =>
																				{
																					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                                    Response = tempNormalized19;
																				});
																			async4.Append(() =>
																				{
																					if ( Response == 2 )
																					{
																						this.Return();
																						return ;
																					}
																				});
																		}
																	}
																	else
																	{
																		if ( NewBalance < 1 )
																		{
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                                    => Interaction.MsgBox("You will be exceeding the Vacation Balance " + "of this Employee.  Proceed anyway?", (Microsoft
                                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized20 => tempNormalized20);
                                                                            async4.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized21 => (int)tempNormalized21);
                                                                            async4.Append<System.Int32>(tempNormalized22 =>
																				{
																					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                                    Response = tempNormalized22;
																				});
																			async4.Append(() =>
																				{
																					if ( Response == 2 )
																					{
																						this.Return();
																						return ;
																					}
																				});
																		}
																	}
																}
																else
																{
																	//Somehow a Vacation Bank was scheduled without a
																	//Vacation_Balance record for this employee
																	//Theoretically this should NEVER happen
																	//- Display error message -
                                                                    ViewManager.ShowMessage("Serious Database Error - No Vacation Balance Record exists for this employee! Please Report to System Admin at once!"
                                                                        , "Delete Leave Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
																	this.Return();
																	return ;
																}
															}
														});

												}
												else if ( TimeCode == "FHL" || TimeCode == "FHLFML" )
												{
													if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
													{
														if ( Conversion.Val(ViewModel.lbHolOpen.Text) < 1 )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Holiday " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized23 => tempNormalized23);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized24 => (int)tempNormalized24);
                                                            async3.Append<System.Int32>(tempNormalized25 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized25;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}
													else
													{
														if ( Conversion.Val(ViewModel.lbHolOpen.Text) < 0.5d )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Holiday " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized26 => tempNormalized26);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized27 => (int)tempNormalized27);
                                                            async3.Append<System.Int32>(tempNormalized28 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized28;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}

												}
												else if ( TimeCode == "MIL" )
												{
													if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
													{
														//               If Val(lbMilOpen) < 1 Then
														//                   Response = MsgBox("You will be exceeding the Authorized Military " _
														//'                   & "Leave of this Employee.  Proceed anyway?", 289, "Schedule Leave")
														//                   If Response = 2 Then
														//                        Exit Sub
														//                   End If
														//               End If
														if ( DateTime.Parse(NewDate).Month > 9 )
														{
															if ( Conversion.Val(ViewModel.TotMil2.ToString()) < 1 )
															{
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                        => Interaction.MsgBox("You will be exceeding the Authorized Military " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                    .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized29 => tempNormalized29);
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized30 => (int)tempNormalized30);
                                                                async3.Append<System.Int32>(tempNormalized31 =>
																	{
																		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                        Response = tempNormalized31;
																	});
																async3.Append(() =>
																	{
																		if ( Response == 2 )
																		{
																			this.Return();
																			return ;
																		}
																	});
															}
														}
														else
														{
															if ( Conversion.Val(ViewModel.TotMil1.ToString()) < 1 )
															{
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                        => Interaction.MsgBox("You will be exceeding the Authorized Military " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                    .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized32 => tempNormalized32);
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized33 => (int)tempNormalized33);
                                                                async3.Append<System.Int32>(tempNormalized34 =>
																	{
																		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                        Response = tempNormalized34;
																	});
																async3.Append(() =>
																	{
																		if ( Response == 2 )
																		{
																			this.Return();
																			return ;
																		}
																	});
															}
														}
													}
													else
													{
														//               If Val(lbMilOpen) < 0.5 Then
														//                   Response = MsgBox("You will be exceeding the Authorized Military " _
														//'                   & "Leave of this Employee. Proceed anyway?", 289, "Schedule Leave")
														//                   If Response = 2 Then
														//                       Exit Sub
														//                   End If
														//               End If
														//           End If
														if ( DateTime.Parse(NewDate).Month > 9 )
														{
															if ( Conversion.Val(ViewModel.TotMil2.ToString()) < 0.5d )
															{
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                        => Interaction.MsgBox("You will be exceeding the Authorized Military " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                    .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized35 => tempNormalized35);
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized36 => (int)tempNormalized36);
                                                                async3.Append<System.Int32>(tempNormalized37 =>
																	{
																		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                        Response = tempNormalized37;
																	});
																async3.Append(() =>
																	{
																		if ( Response == 2 )
																		{
																			this.Return();
																			return ;
																		}
																	});
															}
														}
														else
														{
															if ( Conversion.Val(ViewModel.TotMil1.ToString()) < 0.5d )
															{
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                        => Interaction.MsgBox("You will be exceeding the Authorized Military " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                    .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized38 => tempNormalized38);
                                                                async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized39 => (int)tempNormalized39);
                                                                async3.Append<System.Int32>(tempNormalized40 =>
																	{
																		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																		//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                        Response = tempNormalized40;
																	});
																async3.Append(() =>
																	{
																		if ( Response == 2 )
																		{
																			this.Return();
																			return ;
																		}
																	});
															}
														}
													}
												}
												else if ( TimeCode == "KEL" || TimeCode == "KLI" )
												{
													if ( (((int)ViewModel.chkAM.CheckState) & ((int)ViewModel.chkPM.CheckState)) != 0 )
													{
														if ( Conversion.Val(ViewModel.lbKelOpen.Text) < 1 )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Kelly Day " + "Leave of this Employee.  Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized41 => tempNormalized41);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized42 => (int)tempNormalized42);
                                                            async3.Append<System.Int32>(tempNormalized43 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized43;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}
													else
													{
														if ( Conversion.Val(ViewModel.lbKelOpen.Text) < 0.5d )
														{
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult>(()
                                                                    => Interaction.MsgBox("You will be exceeding the Authorized Kelly Day " + "Leave of this Employee. Proceed anyway?", (Microsoft
                                                                .VisualBasic.MsgBoxStyle)289, "Schedule Leave"));
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, Microsoft.VisualBasic.MsgBoxResult>(tempNormalized44 => tempNormalized44);
                                                            async3.Append<Microsoft.VisualBasic.MsgBoxResult, System.Int32>(tempNormalized45 => (int)tempNormalized45);
                                                            async3.Append<System.Int32>(tempNormalized46 =>
																{
																	//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
																	//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                                                                    Response = tempNormalized46;
																});
															async3.Append(() =>
																{
																	if ( Response == 2 )
																	{
																		this.Return();
																		return ;
																	}
																});
														}
													}
												}
												async3.Append(() =>
													{

															//Update leave record
															oCmdUpdate.Connection = modGlobal.oConn;
															oCmdUpdate.CommandType = CommandType.StoredProcedure;
															oCmdUpdate.CommandText = "spUpdateLeave";

															if ( ViewModel.optLeaveType[6].Checked )
															{
																VBankFlag = 1;
															}
															else
															{
																VBankFlag = 0;
															}

															if ( ViewModel.chkAM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
															{
																NewDate = ViewModel.calLeaveDate.Text + " 7:00AM";
																if ( !modGlobal.CheckPayLock(NewDate, ViewModel.lbBatt.Text.Trim()) )
																{
																	oCmdUpdate.ExecuteNonQuery(new object[] { Empid, NewDate, TimeCode, DateTime.Now, modGlobal.Shared.gUser, VBankFlag, modGlobal.Shared.gSCKFlag });
																}
																else
																{
																	if ( ViewModel.lbBatt.Text.Trim() == "1" )
																	{
																		ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	else if ( ViewModel.lbBatt.Text.Trim() == "2" )
																	{
																		ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	else
																	{
																		ViewManager.ShowMessage("Battalion 3 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	this.Return();
																	return ;
																}
															}

															if ( ViewModel.chkPM.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked )
															{
																NewDate = ViewModel.calLeaveDate.Text + " 7:00PM";
																if ( !modGlobal.CheckPayLock(NewDate, ViewModel.lbBatt.Text.Trim()) )
																{
																	oCmdUpdate.ExecuteNonQuery(new object[] { Empid, NewDate, TimeCode, DateTime.Now, modGlobal.Shared.gUser, VBankFlag, modGlobal.Shared.gSCKFlag });
																}
																else
																{
																	if ( ViewModel.lbBatt.Text.Trim() == "1" )
																	{
																		ViewManager.ShowMessage("Battalion 1 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	else if ( ViewModel.lbBatt.Text.Trim() == "2" )
																	{
																		ViewManager.ShowMessage("Battalion 2 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	else
																	{
																		ViewManager.ShowMessage("Battalion 3 Locked for this Date - Unable to process update request", "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
																	}
																	this.Return();
																	return ;
																}
															}

															//Insert Personnel Schedule Note if needed
															if ( modGlobal.Shared.gLeaveNotes != "" )
															{
																oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + Empid + "','" + NewDate + "','" + modGlobal.Shared.gLeaveNotes + "','" + modGlobal.Shared.gUser + "' ";
																oCmd.CommandType = CommandType.Text;
																oCmd.ExecuteNonQuery();
																modGlobal.Shared.gLeaveNotes = "";
															}

																	//    'If Old Leave Record was Vacation Balance then update Vacation_Balance
																	//    If CurrBank > 0 Then
																	//            ocmd.CommandType = adCmdText
																	//            ocmd.CommandText = "sp_GetVacBalance '" & Empid & "'"
																	//            Set orec = ocmd.Execute
																	//            If Not orec.EOF Then
																	//                BankHold = orec("vacation_balance")
																	//                BankHold = BankHold + CurrBank
																	//                oCmdUpdate.CommandText = "spUpdateVacBalance "
																	//                oCmdUpdate.Execute , Array(Empid, BankHold)
																	//            Else
																	//
																	//            End If
																	//    End If

																	//    'If new Leave is Vacation Bank then update Vacation_Balance
																	//    If optLeaveType(6) Then
																	//            If chkAM And chkPM Then
																	//                NewBalance = NewBalance - 2
																	//            Else
																	//                NewBalance = NewBalance - 1
																	//            End If
																	//            If NewBalance < 0 Then
																	//                NewBalance = 0
																	//            End If
																	//            oCmdUpdate.CommandText = "spUpdateVacBalance '" & Empid & "', " & NewBalance
																	//            oCmdUpdate.Execute , Array(Empid, NewBalance)
																	//    End If

																	GetLeaveTotals();
																	FillSchedule();
																	GetDailyTotals();
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

		internal void frmIndSched_Activated(Object eventSender, System.EventArgs eventArgs)
		{
				if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
				{
					UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
					//Call Global Refresh Form subroutine
					//to refresh displayed data on open forms
					if ( ViewModel.FirstTime != 0 )
					{
						return ;
					}

							modGlobal.RefreshActiveForm();

				}
			}

		//UPGRADE_WARNING: (2065) Form event frmIndSched.Deactivate has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
		[UpgradeHelpers.Events.Handler]
		internal void frmIndSched_Deactivate(Object eventSender, System.EventArgs eventArgs)
		{
			//Call Global Refresh Form subroutine
			//to refresh displayed data on open forms
			if ( ViewModel.FirstTime != 0 )
			{
				return ;
			}
		//    RefreshActiveForm

		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		public void Form_Load()
		{

				//Load up operations for Individual Scheduling Form
				//Fill Employee Name List
				//ADODB

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				//int UDays = 0;
				string strName = "";

				try
				{

					//Set Form Load FirstTime indicator to true
					//Subroutines associated with data from a selected employee
					//that are triggered by Form Load activity will detect this
					//and not run their processing
					ViewModel.FirstTime = -1;
					ViewModel.lbCallBackNum.Text = "";
					ViewModel.lbSpecEvent.Text = "";

					//Load Employee name list with Operations staff
					this.ViewModel.cboNameList.Items.Clear();
					ViewModel.cmdAdjustHOLMax.Visible = false;
					ViewModel.chkRecert.Visible = false;

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

                if (modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "PER" || modGlobal.Shared.gSecurity
                        == "CPT" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "AID")
					{
						//        oCmd.CommandText = "spOpNameList"
						oCmd.CommandText = "spFullNameList";
						oRec = ADORecordSetHelper.Open(oCmd, "");
					}
					else if ( modGlobal.Shared.gSecurity == "HAZ" )
					{
						//Select all Hazmat Employees
						oCmd.CommandText = "sp_FillXList 'HZM'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
					}
					else
					{
						oCmd.CommandText = "sp_FillXList '" + modGlobal.Shared.gSecurity + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
					}

					if ( modGlobal.Shared.gSecurity != "RO" )
					{

						while ( !oRec.EOF )
						{
							strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
							this.ViewModel.cboNameList.AddItem(strName);
							oRec.MoveNext();
                };
						}
					else
					{
						strName = modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser;
						this.ViewModel.cboNameList.AddItem(strName);
					}
					ViewModel.bUseNewMILMAX = false;
					ViewModel.bBothMILMAX = false;
					//    lbMILInfo.Visible = False
					// MODIFY MIL LOGIC HERE ~ DKL May 2008
					if ( DateTime.Now.Year > 2001 )
					{
						ViewModel.lbYear.Text = "Oct " + (DateTime.Now.Year - 1).ToString() + "/Oct " + DateTime.Now.Year.ToString();
						if ( DateTime.Now.Year > 2008 )
						{
							ViewModel.bUseNewMILMAX = true;
						}
						else if ( DateTime.Now.Year == 2008 )
						{
							ViewModel.bBothMILMAX = true;
						}
					}
					else if ( DateTime.Now.Year == 2001 )
					{
						ViewModel.lbYear.Text = "Jan 2001/Oct 2001";
					}
					else
					{
						ViewModel.lbYear.Text = " ";
					}

					//Create StyleSets used by Year Calendar control
                    //Support This for 
					//CreateStyleSets();
					//CreateLeaveStyleSets();
					//CreateVacBankStyleSets();


					SetSecurity();
					SetAnnualCycleDays();
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
		}

		public struct ScheduleTimeStruct
		{
			public string TimeType;
		}

		public static frmIndSched DefInstance
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

		public static frmIndSched CreateInstance()
		{
				PTSProject.frmIndSched theInstance = Shared.Container.Resolve<frmIndSched>();
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
			ViewModel.Shape3.LifeCycleStartup();
			ViewModel.Shape1.LifeCycleStartup();
			ViewModel.Shape4.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape2.LifeCycleShutdown();
			ViewModel.Shape3.LifeCycleShutdown();
			ViewModel.Shape1.LifeCycleShutdown();
			ViewModel.Shape4.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmIndSched
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndSchedViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndSched m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}