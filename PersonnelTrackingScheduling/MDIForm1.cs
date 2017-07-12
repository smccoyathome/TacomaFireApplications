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

	public partial class MDIForm1
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.MDIForm1ViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		//*************************************************
		//Main Parent Window for
		//Personnel Tracking and Scheduling Application
		//Menu System:
		//--------------------------------------------
		//System -
		//   Exit - Closes Application
		//------------
		//Personnel -
		//   Add New Employee - Displays frmAddNew
		//   Update Employee - Displays frmUpdate
		//   Assign Employee Position - Displays frmAssign
		//   Manage Phone List - Displays frmPhone
		//   Manage Address List - Displays frmAddress
		//   Manage Emergency Contacts - Displays frmEmergencyContact
		//   Update Promotion Lists - Displays frmUpdatePromo
		//   Senority Ranking Inquiry - Displays frmSenority
		//------------
		//Scheduling -
		//   Individual Schedule - Displays frmIndSched
		//   Battalion 1 Schedule - Displays frmNewBattSched
		//   Battalion 2 Schedule - Displays frmNewBattSched2
		//   Battalion 4 Schedule - Displays frmNewBattSched3
		//   EMS Schedule - Displays frmNewEMS
		//   HazMat Schedule - Displays frmWeekly
		//   Battalion Staff Schedule - Displays frmWeekly
		//   Dispatch Schedule - Displays frmDispatchScheduler
		//------------
		//Reports -
		//   Personnel -
		//       Assignments - Displays frmAssignReport
		//       Roster - Displays  frmRoster
		//       Public Roster - Displays frmRosterPublic
		//       Debit Day Groups - Displays frmDebitReport
		//       Promotion Lists - Displays frmPromoReport
		//       Senority Ranking List - Displays frmSeniority
		//       CF1 Benefit Listing - Displays CF1Report
		//   Schedule -
		//       Battalion TimeCard Worksheets -
		//           Batt 1 - Displays frmTimeCard1
		//           Batt 2 - Displays frmTimeCard2
		//       Payroll Worksheets -
		//           EMS - Displays frmTimeCardX
		//           HazMat - Displays frmTimeCardX
		//           Marine - Displays frmWeekly
		//           Battalion Staff - Displays frmTimeCardX
		//           Dispatch Staff - Displays frmWeekly
		//       Individual Time Cards - Displays frmIndTimeCard
		//       Individual Yearly Schedule - Displays frmIndivSchedReport
		//       Daily Staffing Report - Displays frmDailyStaffing
		//       Overtime Detail Report - Displays frmOvertime
		//       Shift Calendar - Displays frmShiftCal
		//       Transfer Schedule - Displays frmTransReport
		//   Leave -
		//       Daily Leave - Displays frmLeave
		//       Annual Leave - Displays frmAnnualLeave
		//       Individual Leave - Displays frmIndivReport
		//   Training -
		//       Training Class Attendance Query - Displays frmSrReport
		//----------------
		//Utilities -
		//   Pay Roll -
		//       Review Pay Period - Displays frmNotify
		//       Review Individual Time Cards - Displays frmIndTimeCard
		//   Table Management -
		//       Manage Resource Table - Not Implemented
		//       Manage Code Tables - Not Implemented
		//       Manage Schedule/Calendar Records - Displays frmUtility
		//   Security Management - Displays frmSecurity
		//   Calendar Management - (Disabled) - Not Implemented
		//----------------
		//Window -
		//----------------
		//Help -
		//   About PTS - Displays frmAbout
		//****************************************************
		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(MDIForm1));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				Shared.
					m_vb6FormDefInstance = this;
			}
			ReLoadForm(false);
		}



		public bool GroupOK(string UserID)
		{
			//Determine if current user is in PTSUpdate Group
			//In PTSdata database
			//ADODB
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandText = "sp_getgroup '" + UserID + "'";
			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				if (Convert.ToString(oRec["Group_Name"]).Trim() != "public")
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}

		}

		public void SetSecurity()
		{
			//Enable or Disable Menu choices based on users
			//Security Level
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();

			//Utilities Menu available for Administrators & Personnel security only
			if (modGlobal.Shared.gSecurity != "ADM" && modGlobal.Shared.gSecurity != "PER")
			{
				ViewModel.mnuUtil.Enabled = false;
				ViewModel.mnuPhone.Enabled = false;
				ViewModel.mnuAddress.Enabled = false;
				ViewModel.mnuPMCerts.Enabled = false;
			}

			//Utilities - Table, Security and Calendar Management
			//Available for Administrators only
			if (modGlobal.Shared.gSecurity != "ADM")
			{
				ViewModel.mnuTable.Enabled = false;
				ViewModel.mnuSecure.Enabled = false;
				ViewModel.mnu_transfer_req.Enabled = false;
				ViewModel.mnuFRoster.Enabled = false;
				ViewModel.mnuPhoneList.Enabled = false;
			}

			//Read/Only access
			if (modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "CPT")
			{
				ViewModel.mnuAddnew.Enabled = false;
				ViewModel.mnuEmpInfo.Enabled = false;
				ViewModel.mnuPosition.Enabled = false;
				ViewModel.mnuPromoli.Enabled = false;
				ViewModel.mnuRoster.Enabled = false;
				ViewModel.mnuPhone.Enabled = false;
				ViewModel.mnuAddress.Enabled = false;
				ViewModel.mnuTimeCard.Enabled = false;
				ViewModel.mnuPPE.Enabled = false;
				ViewModel.mnu_Battalion.Enabled = false;
				ViewModel.mnuPayrollReports.Enabled = false;
				ViewModel.mnuImmune.Enabled = false;
				if (cUniform.GetPPEInfoForSecurity(modGlobal.Shared.gUser) != 0)
				{
					ViewModel.mnuPPE.Enabled = true;
				}
				else if (cUniform.GetPPEInfoForLaundering(modGlobal.Shared.gUser) != 0)
				{
					ViewModel.mnuPPE.Enabled = true;
				}
			}

			//Battalion , Paramedic Supervisor Access
			if (modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "PM" || modGlobal.Shared.gSecurity == "AID")
			{
				ViewModel.mnuAddnew.Enabled = false;
				ViewModel.mnuPosition.Enabled = false;
				ViewModel.mnuPromoli.Enabled = false;
			}

			//Hazmat, Marine, Communications Supervisor Access
			if (modGlobal.Shared.gSecurity == "HAZ" || modGlobal.Shared.gSecurity == "MRN" || modGlobal.Shared.gSecurity == "DSP")
			{
				ViewModel.mnuAddnew.Enabled = false;
				ViewModel.mnuPosition.Enabled = false;
				ViewModel.mnuPromoli.Enabled = false;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		public void Form_Load()
		{
			//Initialize AppOpen variable so Form Activate event
			//is not triggered on AppOpen
			ViewModel.AppOpen = -1;

			//Initialize all Global Variables
			modGlobal.Shared.gOldEmp = "";
			modGlobal.Shared.gOldRov = 0;
			modGlobal.Shared.gLeaveType = "";
			modGlobal.Shared.gPayType = "";
			modGlobal.Shared.gType = "";
			modGlobal.Shared.gBatt = "";
			modGlobal.Shared.gRBatt = "";
			modGlobal.Shared.gRType = "";
			modGlobal.Shared.gLType = "";
			modGlobal.Shared.gFullShift = 0;
			modGlobal.Shared.gNoteDate = "";
			modGlobal.Shared.gAssignID = "";
			modGlobal.Shared.gYearReport = "";
			modGlobal.Shared.gUser = "";
			modGlobal.Shared.gUserBatt = "";
			modGlobal.Shared.gSecurity = "";
			modGlobal.Shared.gComputer = "";
			modGlobal.Shared.gCurrentYear = 0;
			modGlobal.Shared.gLeaveUpdate = 0;
			modGlobal.Shared.gTransCancel = 0;
			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gEndTrans = "";

			string TodaysDate = "";
			string GreetingMsg = "";
			string TodaySecurity = "";
			string YesterdaySecurity = "";
			int NoUpdateFlag = 0;

			try
			{

				//ADODB data access
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				oCmd.Connection = modGlobal.oConn;

				//Capture current user_id, employee_id and security level
				oCmd.CommandText = "sp_getuser";
				oCmd.CommandType = CommandType.StoredProcedure;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				modGlobal.Shared.gUserLogon = Convert.ToString(oRec["user_id"]);
				modGlobal.Shared.gUser = modGlobal.Shared.gUserLogon.ToUpper();
				oCmd.CommandText = "sp_GetUserInfo '" + modGlobal.Shared.gUser + "'";
				oCmd.CommandType = CommandType.Text;
				oRec = ADORecordSetHelper.Open(oCmd, "");
				modGlobal.Shared.gUser = Convert.ToString(oRec["EmpID"]);
				modGlobal.Shared.gUserBatt = Convert.ToString(oRec["battalion_code"]).Trim();
				modGlobal.Shared.gSecurity = Convert.ToString(oRec["security_code"]).Trim();
				modGlobal.Shared.gUserType = modGlobal.Clean(oRec["assignment_type_code"]).Trim();
				modGlobal.Shared.gUserName = modGlobal.Clean(oRec["name_first"]).Trim() + " " + modGlobal.Clean(oRec["name_last"]).Trim();
				modPTSPayroll.Shared.gUserSAPid = Convert.ToInt32(Double.Parse(modGlobal.Clean(oRec["sap_id"]).Trim()));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				modGlobal.Shared.gDaysWorking = Convert.ToInt32(modGlobal.GetVal(oRec["DaysWorking"]));

				modGlobal.Shared.gBattSwitchDate = DateTime.Now.ToString("MM/dd/yyyy");
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "05044"
				//    gSecurity = "ADM"
				//    gUserType = "CIV"
				//    gUserBatt = ""
				//    gUserName = "Dundas, Peggy"
				//    gUserLogon = "PDUNDAS"
				//    gUserSAPid = 5044
				//    gDaysWorking = 5671
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "12106"
				//    gSecurity = "RO"
				//    gUserType = "PM"
				//    gUserBatt = "3"
				//    gUserName = "Anderson, Ryan"
				//    gUserLogon = "RANDERSO"
				//    gUserSAPid = 12106
				//    gDaysWorking = 3782
				//    '**************************
				//    '**************************
				//for test purposes
				//    gUser = "07303"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "1"
				//    gUserName = "Spoonemore, Tom"
				//    gUserLogon = "TSPOONEM"
				//    gUserSAPid = 207303
				//    '**************************
				//    '**************************
				//for test purposes
				//    gUser = "19079"
				//    gSecurity = "CPT"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Dougherty, Brian"
				//    gUserLogon = "BDOUGHER"
				//    gUserSAPid = 19079
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "04986"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Becker, James"
				//    gUserLogon = "JBECKER"
				//    gUserSAPid = 204986
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "80366"
				//    gSecurity = "AID"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Sollars, Chris"
				//    gUserLogon = "CSOLLARS"
				//    gUserSAPid = 80366
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "70725"
				//    gSecurity = "PER"
				//    gUserType = "FPB"
				//    gUserBatt = ""
				//    gUserName = "Pickford, Tom"
				//    gUserLogon = "TPICKFOR"
				//    gUserSAPid = 70725
				//    '**************************
				//    '**************************
				//for test purposes
				//    gUser = "67098"
				//    gSecurity = "AID"
				//    gUserType = "BAT"
				//    gUserBatt = "2"
				//    gUserName = "Owen, Thomas"
				//    gUserLogon = "TOWEN"
				//    gUserSAPid = 67098
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "38275"
				//    gSecurity = "RO"
				//    gUserType = "PM"
				//    gUserBatt = ""
				//    gUserName = "Hupp, Lowell"
				//    gUserLogon = "LHUPP"
				//    gUserSAPid = 38275
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "22222"
				//    gSecurity = "PER"
				//    gUserType = "VOL"
				//    gUserBatt = ""
				//    gUserName = "Harris, Tami"
				//    gUserLogon = "THARRIS"
				//    gUserSAPid = 22222
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "36400"
				//    gSecurity = "ADM"
				//    gUserType = "ADM"
				//    gUserBatt = ""
				//    gUserName = "Hilderbrand, Robert"
				//    gUserLogon = "RHILDERB"
				//    gUserSAPid = 36400
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "16529"
				//    gSecurity = "PER"
				//    gUserType = "FPB"
				//    gUserBatt = ""
				//    gUserName = "Curley, Mike"
				//    gUserLogon = "MCurley"
				//    gUserSAPid = 16529
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "12494"
				//    gSecurity = "AID"
				//    gUserType = "ADM"
				//    gUserBatt = ""
				//    gUserName = "Caillier, Kevin"
				//    gUserLogon = "KCAILLIE"
				//    gUserSAPid = 12494
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "95380"
				//    gSecurity = "PER"
				//    gUserType = "CIV"
				//    gUserBatt = ""
				//    gUserName = "Woody, Diane"
				//    gUserLogon = "DWOODY"
				//    gUserSAPid = 95380
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "13185"
				//    gSecurity = "ADM"
				//    gUserType = "ADM"
				//    gUserBatt = ""
				//    gUserName = "Chaffey,Jonathan E."
				//    gUserLogon = "JCHAFFEY"
				//    gUserSAPid = 13185
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "10919"
				//    gSecurity = "RO"
				//    gUserType = "PM"
				//    gUserBatt = "2"
				//    gUserName = "Reid, Lee"
				//    gUserLogon = "'LREID'"
				//    gUserSAPid = 10919
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "81699"
				//    gSecurity = "AID"
				//    gUserType = "TRN"
				//    gUserBatt = "*"
				//    gUserName = "Stock,Stephen "
				//    gUserLogon = "SSTOCK"
				//    gUserSAPid = 81699
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "81225"
				//    gSecurity = "ADM"
				//    gUserType = "BAT"
				//    gUserBatt = "2"
				//    gUserName = "Steinhoff, Gary"
				//    gUserLogon = "GSTEINHO"
				//    gUserSAPid = 81225
				//    '**************************
				//    '**************************
				//for test purposes
				//    gUser = "71758"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "1"
				//    gUserName = "Pray ,Rodney K."
				//    gUserLogon = "RPRAY"
				//    gUserSAPid = 71758
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "13150"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "1"
				//    gUserName = "Casebolt, Scott"
				//    gUserLogon = "SCASEBOL"
				//    gUserSAPid = 13150
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "15243"
				//    gSecurity = "AID"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Colwell,William"
				//    gUserLogon = "BCOLWELL"
				//    gUserSAPid = 15243
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "56370"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "1"
				//    gUserName = "McRoberts,David"
				//    gUserLogon = "DMCROBER"
				//    gUserSAPid = 56370
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "11437"
				//    gSecurity = "AID"
				//    gUserType = "HZM"
				//    gUserBatt = "2"
				//    gUserName = "Buck,Kenneth M."
				//    gUserLogon = "KBUCK"
				//    gUserSAPid = 11437
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "69972"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Perry, Christopher E."
				//    gUserLogon = "CPERRY"
				//    gUserSAPid = 69972
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "01565"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Nighswonger,Jeffrey W."
				//    gUserLogon = "JNIGHSWONGER"
				//    gUserSAPid = 201565
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "29490"
				//    gSecurity = "ADM"
				//    gUserType = "BAT"
				//    gUserBatt = "1"
				//    gUserName = "Fudge Jr., Dyre "
				//    gUserLogon = "DFUDGE"
				//    gUserSAPid = 29490
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "05040"
				//    gSecurity = "PER"
				//    gUserType = "CIV"
				//    gUserBatt = ""
				//    gUserName = "Yvonne Chisa"
				//    gUserLogon = "YCHISA"
				//    gUserSAPid = 5040
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "56352"
				//    gSecurity = "PER"
				//    gUserType = "CIV"
				//    gUserBatt = ""
				//    gUserName = "Patti McQuillin"
				//    gUserLogon = "PMCQUILL"
				//    gUserSAPid = 56352
				//    '**************************

				//    '**************************
				//    'for test purposes
				//    gUser = "19159"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "1"
				//    gUserName = "John Dower"
				//    gUserLogon = "JDOWER"

				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "34621"
				//    gSecurity = "RO"
				//    gUserType = "REG"
				//    gUserBatt = "2"
				//    gUserName = "Hardy, Brian M."
				//    gUserLogon = "BHARDY"
				//    gUserSAPid = 34621
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "45437"
				//    gSecurity = "BAT"
				//    gUserType = "BAT"
				//    gUserBatt = "1"
				//    gUserName = "Jackson, David B."
				//    gUserLogon = "DJACKSON"
				//    gUserSAPid = 45437
				//    '**************************
				//    '**************************
				//    'for test purposes
				//    gUser = "58173"
				//    gSecurity = "AID"
				//    gUserType = "BAT"
				//    gUserBatt = "1"
				//    gUserName = "Janus Moorehead"
				//    gUserLogon = "JMOOREHE"
				//    gUserSAPid = 58173
				//    '**************************
				//    '**************************
				//'    'for test purposes
				//    gUser = "80628"
				//    gSecurity = "AID"
				//    gUserType = "BAT"
				//    gUserBatt = "1"
				//    gUserLogon = "WSPENCER"
				//    gUserName = "Spencer, William E."
				//    gUserSAPid = 80628
				//    '**************************

				modGlobal
					.Shared.TempSecurity = modGlobal.Shared.gSecurity == "RO";

				//Check to determine if user is currently working
				//in a position that needs a different security level
				//AM Assignment
				TodaysDate = DateTime.Now.ToString("M/d/yyyy") + " 7:00AM";
				NoUpdateFlag = 0;
				oCmd.CommandText = "sp_GetAssSecurity '" + modGlobal.Shared.gUser + "', '" + TodaysDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					TodaySecurity = Convert.ToString(oRec["security_code"]);
					if (modGlobal.Shared.gUserBatt != "1" && modGlobal.Clean(oRec["battalion_code"]) == "1")
					{
								modGlobal.Shared.gUserBatt = modGlobal.Clean(oRec["battalion_code"]);
					}
				}
				TodaysDate = DateTime.Now.AddDays(-1).ToString("M/d/yyyy") + " 7:00AM";
				oCmd.CommandText = "sp_GetAssSecurity '" + modGlobal.Shared.gUser + "', '" + TodaysDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					YesterdaySecurity = Convert.ToString(oRec["security_code"]);
					if (modGlobal.Shared.gUserBatt != "1" && modGlobal.Clean(oRec["battalion_code"]) == "1")
					{
								modGlobal.Shared.gUserBatt = modGlobal.Clean(oRec["battalion_code"]);
					}
				}

				if (modGlobal.Shared.gSecurity == "ADM")
				{
					//Skip Security update - already highest
				}
				else if (TodaySecurity == "BAT" || YesterdaySecurity == "BAT")
				{
					if (GroupOK(modGlobal.Shared.gUserLogon))
					{
						modGlobal.Shared.gSecurity = "BAT";
					}
					else
					{
						NoUpdateFlag = -1;
					}
				}
				else if (TodaySecurity == "AID" || YesterdaySecurity == "AID")
				{
					if (modGlobal.Shared.gSecurity != "BAT")
					{
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "AID";
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "HAZ" || YesterdaySecurity == "HAZ")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "HAZ";
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "MRN" || YesterdaySecurity == "MRN")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "MRN";
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "CPT" || YesterdaySecurity == "CPT")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "CPT";
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}

				//PM Assignment
				TodaysDate = DateTime.Now.ToString("M/d/yyyy") + " 7:00PM";
				NoUpdateFlag = 0;
				oCmd.CommandText = "sp_GetAssSecurity '" + modGlobal.Shared.gUser + "', '" + TodaysDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					TodaySecurity = Convert.ToString(oRec["security_code"]);
					if (modGlobal.Shared.gUserBatt != "1" && modGlobal.Clean(oRec["battalion_code"]) == "1")
					{
								modGlobal.Shared.gUserBatt = modGlobal.Clean(oRec["battalion_code"]);
					}
				}
				TodaysDate = DateTime.Now.AddDays(-1).ToString("M/d/yyyy") + " 7:00PM";
				oCmd.CommandText = "sp_GetAssSecurity '" + modGlobal.Shared.gUser + "', '" + TodaysDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					YesterdaySecurity = Convert.ToString(oRec["security_code"]);
					if (modGlobal.Shared.gUserBatt != "1" && modGlobal.Clean(oRec["battalion_code"]) == "1")
					{
								modGlobal.Shared.gUserBatt = modGlobal.Clean(oRec["battalion_code"]);
					}
				}

				if (modGlobal.Shared.gSecurity == "ADM")
				{
					//Skip Security update - already highest
				}
				else if (TodaySecurity == "BAT" || YesterdaySecurity == "BAT")
				{
					if (GroupOK(modGlobal.Shared.gUserLogon))
					{
						modGlobal.Shared.gSecurity = "BAT";
						NoUpdateFlag = 0;
					}
					else
					{
						NoUpdateFlag = -1;
					}
				}
				else if (TodaySecurity == "AID" || YesterdaySecurity == "AID")
				{
					if (modGlobal.Shared.gSecurity != "BAT")
					{
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "AID";
							NoUpdateFlag = 0;
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "HAZ" || YesterdaySecurity == "HAZ")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "HAZ";
							NoUpdateFlag = 0;
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "MRN" || YesterdaySecurity == "MRN")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "MRN";
							NoUpdateFlag = 0;
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}
				else if (TodaySecurity == "CPT" || YesterdaySecurity == "CPT")
				{
					if (modGlobal.Shared.gSecurity != "BAT" && modGlobal.Shared.gSecurity != "AID")
					{
						//Check to see if user has Update Security
						if (GroupOK(modGlobal.Shared.gUserLogon))
						{
							modGlobal.Shared.gSecurity = "CPT";
						}
						else
						{
							NoUpdateFlag = -1;
						}
					}
				}

				if (modGlobal.Shared.gTestMode != 0)
				{
					MDIForm1.DefInstance.ViewModel.BackColor = modGlobal.Shared.MDITestColor;
				}
				else
				{
					MDIForm1.DefInstance.ViewModel.BackColor = modGlobal.Shared.MDIProdColor;
				}

				if (modGlobal.Shared.gDaysWorking < 366 && modGlobal.Shared.gSecurity == "RO")
				{
					ViewModel.mnuTraining.Enabled = true;
					ViewModel.mnu_trainingtracker.Enabled = false;
				}
				else
				{
					ViewModel.mnuTraining.Enabled = true;
					ViewModel.mnu_trainingtracker.Enabled = true;
				}

				//    'Capture current computer
				//    oCmd.CommandText = "sp_getcomputer"
				//    oCmd.CommandType = adCmdStoredProc
				//    Set oRec = oCmd.Execute
				//    gComputer = Trim$(oRec("computer"])
				//    gComputer = UCase(gComputer)

				modGlobal
					.Shared.gCurrentYear = DateTime.Now.Year;
				modGlobal.Shared.gBattSwitchDate = DateTime.Now.ToString("MM/dd/yyyy");

				SetSecurity();
				if (DateAndTime.Hour(DateTime.Now) >= 12)
				{
					if (DateAndTime.Hour(DateTime.Now) > 18)
					{
						GreetingMsg = "Good Evening ";
					}
					else
					{
						GreetingMsg = "Good Afternoon ";
					}
				}
				else
				{
					GreetingMsg = "Good Morning ";
				}

				GreetingMsg = GreetingMsg + modGlobal.Shared.gUserName + "\n";
				GreetingMsg = GreetingMsg + "You have been logged in with ";
				switch(modGlobal.Shared.gSecurity)
				{
					case "RO" :
						GreetingMsg = GreetingMsg + "Read Only Security";
						break;
					case "PER" :
						GreetingMsg = GreetingMsg + "Personnel Update Security";
						break;
					case "BAT" : case "AID" :
						GreetingMsg = GreetingMsg + "Battalion Scheduling Security";
						break;
					case "ADM" :
						GreetingMsg = GreetingMsg + "Administrative Security";
						break;
					case "DSP" :
						GreetingMsg = GreetingMsg + "Dispatch Scheduling Security";
						break;
					case "HAZ" :
						GreetingMsg = GreetingMsg + "HazMat Scheduling Security";
						break;
					case "PM" :
						GreetingMsg = GreetingMsg + "Paramedic Scheduling Security";
						break;
					case "MRN" :
						GreetingMsg = GreetingMsg + "Marine Scheduling Security";
						break;
					case "CPT" :
						GreetingMsg = GreetingMsg + "Captain Security";
						break;
				}
				if (NoUpdateFlag != 0)
				{
					GreetingMsg = GreetingMsg + "\n" + "You do not have appropriate Database Security for Your Current Position!";
					GreetingMsg = GreetingMsg + "\n" + "Contact Debra Lewandowsky for necessary Security updates";
				}
                ViewManager.ShowMessage(GreetingMsg, "Welcome to TFD Personnel Tracking & Scheduling", UpgradeHelpers.Helpers.BoxButtons.OK);
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
			//Close ADODB Connection instance
			ViewManager.DisposeView(
				//Close ADODB Connection instance
				frmNewBattSched.DefInstance);
			ViewManager.DisposeView(
				frmNewBattSched2.DefInstance);
			ViewManager.DisposeView(
				frmNewBattSched3.DefInstance);

			UpgradeHelpers.DB.TransactionManager.DeEnlist(modGlobal.oConn);
			modGlobal.oConn.Close();
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_Annual_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Processes and Displays Annual Leave Report
			// ***Note  Annual Leave report prints for the current year!!
			modGlobal
				.Shared.gYearReport = DateTime.Now.Year.ToString();
			ViewManager.NavigateToView(
				frmAnnualLeave.DefInstance);
			/*			frmAnnualLeave.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_BCApprovedTC_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmBCApprovedPayroll.DefInstance);
			/*			frmBCApprovedPayroll.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_daily_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Displays Daily Leave Report
			ViewManager.NavigateToView(
				//Displays Daily Leave Report
				frmLeave.DefInstance);
			/*			frmLeave.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_dailysickleave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmDailySCKLeaveReport.DefInstance);
			/*			frmDailySCKLeaveReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_DDGroups_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmDebitReport.DefInstance);
			/*			frmDebitReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_emp_facility_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmEmployeeListByStation.DefInstance);
			/*			frmEmployeeListByStation.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_EmpNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if (modGlobal.Shared.gSecurity != "ADM")
			{
				ViewManager.ShowMessage("You do not have the proper security.", "Adding Employee Notes", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			modGlobal.Shared.gAssignID = "";
			ViewManager.NavigateToView(
				frmEmployeeNotes.DefInstance);
			/*			frmEmployeeNotes.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_FCCMinDrills_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrainFCCQuarterly.DefInstance);
			/*			frmTrainFCCQuarterly.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_FCCVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Dispatch Vacation Scheduler 5/2013
			ViewManager.NavigateToView(
				//Display new Dispatch Vacation Scheduler 5/2013
				frmFCCVacationScheduler.DefInstance);
			/*			frmFCCVacationScheduler.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HelpPrntScrn_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPrintScreenHelp.DefInstance);
			/*			frmPrintScreenHelp.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HZMLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmHazmatLeave.DefInstance);
			/*			frmHazmatLeave.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HZMVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Hazmat Vacation Scheduler 3/2012
			ViewManager.NavigateToView(
				//Display new Hazmat Vacation Scheduler 3/2012
				frmHZMVacationScheduler.DefInstance);
			/*			frmHZMVacationScheduler.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndPMRecert_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is currently under construction...", vbOKOnly, "Individual PM Recert Report"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is currently under construction...", vbOKOnly, "Individual PM Recert Report"
				frmIndPMRecertReport.DefInstance);
			/*			frmIndPMRecertReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_LeaveNoSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmLeaveNoSched.DefInstance);
			/*			frmLeaveNoSched.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_OTEPReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrainAnnualOTEP.DefInstance);
			/*			frmTrainAnnualOTEP.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMBaseStaReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrnBaseStation.DefInstance);
			/*			frmTrnBaseStation.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMCSRCalc_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgCalcPMCSR.DefInstance);
			/*			dlgCalcPMCSR.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMRecertReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrainPMRecert.DefInstance);
			/*			frmTrainPMRecert.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Paramedic Vacation Scheduler 3/2012
			ViewManager.NavigateToView(
				//Display new Paramedic Vacation Scheduler 3/2012
				frmPMVacationScheduler.DefInstance);
			/*			frmPMVacationScheduler.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PPEQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPPEInspQuery.DefInstance);
			/*			frmPPEInspQuery.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_rankedops_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmRankedOperationStaff.DefInstance);
			/*			frmRankedOperationStaff.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_ReadingAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrainReqReading.DefInstance);
			/*			frmTrainReqReading.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_sa_report_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmSpecialAssignReport.DefInstance);
			/*			frmSpecialAssignReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_SchedNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmSchedNoteQuery.DefInstance);
			/*			frmSchedNoteQuery.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_sick_usage_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmSickLeaveUsage.DefInstance);
			/*			frmSickLeaveUsage.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_staffdiscrepancy_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmStaffingDiscrepancy.DefInstance);
			/*			frmStaffingDiscrepancy.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_TrainingQueryTool_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
				frmTrainQuery.DefInstance);
			/*			frmTrainQuery.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_watch_duty_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmWatchDutyAssignment.DefInstance);
			/*			frmWatchDutyAssignment.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu183_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display TimeCard Worksheet Report form
			modGlobal
				.Shared.gRBatt = "3";
			ViewManager.NavigateToView(
				frmTimeCard3.DefInstance);
			/*			frmTimeCard3.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuALSProc_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmIndALSProcReport.DefInstance);
			/*			frmIndALSProcReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void MnuAuditDDHOL_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Debit/Holiday Audit form
			ViewManager.NavigateToView(
				//Display Debit/Holiday Audit form
				frmDebitHoliday.DefInstance);
			/*			frmDebitHoliday.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion4_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Battalion 5 Scheduler

			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched3")
				{
					ViewManager.DisposeView(
						frmBattSched3.DefInstance);
					break;
				}
			}
			ViewManager.NavigateToView(

				frmBattSched4.DefInstance);
			/*			frmBattSched4.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCalendarHelp_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgCalendarYearShift.DefInstance);
			/*			dlgCalendarYearShift.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCBStaffing_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display TFD Staffing To Determine Callbacks
			ViewManager.NavigateToView(
				//Display TFD Staffing To Determine Callbacks
				frmStaffingReport.DefInstance);
			/*			frmStaffingReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;


		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCycleHrs_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmWorkingHoursByCycle.DefInstance);
			/*			frmWorkingHoursByCycle.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatchLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmDispatchLeave.DefInstance);
			/*			frmDispatchLeave.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuExtraOff_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Unplanned Days Off Report form
			ViewManager.NavigateToView(
				//Display Unplanned Days Off Report form
				frmExtraDaysOff.DefInstance);
			/*			frmExtraDaysOff.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_Individual_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display frmIndivReport
			//There will be no Current Employee Displayed
			modGlobal
				.Shared.gReportYear = DateTime.Now.Year;
			ViewManager.NavigateToView(
				frmIndivReport.DefInstance);
			/*			frmIndivReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndivPayrollSO_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgSignOff.DefInstance);
			/*			dlgSignOff.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndLegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgIndSchedLegend.DefInstance);
			/*			dlgIndSchedLegend.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndTrainReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmIndTrainReport.DefInstance);
			/*			frmIndTrainReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_legend_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgBattLegend.DefInstance);
			/*			dlgBattLegend.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payrolllegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgPayRollLegend.DefInstance);
			/*			dlgPayRollLegend.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payup_calc_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgEmployeePayCalc.DefInstance);
			/*			dlgEmployeePayCalc.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_personnelsignoff_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPayrollSignOff.DefInstance);
			/*			frmPayrollSignOff.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmParamedicLeave.DefInstance);
			/*			frmParamedicLeave.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_QuarterlyMinimumDrill_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmTrainQuarterlyReport.DefInstance);
			/*			frmTrainQuarterlyReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_ReportPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPayrollReport.DefInstance);
			/*			frmPayrollReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_timecodes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgTimeCodes.DefInstance);
			/*			dlgTimeCodes.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_TrainingQuerynew_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
				frmTrainQuery.DefInstance);
			/*			frmTrainQuery.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_trainingtracker_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "TFD Training Tracker"
			ViewManager.NavigateToView(
				//    MsgBox "This Feature is coming soon!!", vbOKOnly, "TFD Training Tracker"
				frmPTSTrain.DefInstance);
			/*			frmPTSTrain.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_transfer_req_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!", vbOKOnly, "Posted Positions / Transfer Request Mgmt"
			ViewManager.NavigateToView(
				//    MsgBox "This Feature is coming soon!", vbOKOnly, "Posted Positions / Transfer Request Mgmt"
				frmTransferRequest.DefInstance);
			/*			frmTransferRequest.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_Vacation_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new TFD Vacation Scheduler 9/2004
			ViewManager.NavigateToView(
				//Display new TFD Vacation Scheduler 9/2004
				frmVacationScheduler.DefInstance);
			/*			frmVacationScheduler.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu181_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display TimeCard Worksheet Report form
			modGlobal
				.Shared.gRBatt = "1";
			ViewManager.NavigateToView(
				frmTimeCard1.DefInstance);
			/*			frmTimeCard1.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu182_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display TimeCard Worksheet Report form
			modGlobal
				.Shared.gRBatt = "2";
			ViewManager.NavigateToView(
				frmTimeCard2.DefInstance);
			/*			frmTimeCard2.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAbout_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Displays About form
			ViewManager.NavigateToView(
				//Displays About form
				frmAbout.DefInstance);
			/*			frmAbout.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAddnew_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(frmAddNew.DefInstance);
		}

		//UPGRADE_NOTE: (7001) The following declaration (mnuArchSched_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void mnuArchSched_Click()
		//{
			//Underconstruction - update from RDO
			//MessageBox.Show("Under Construction, Check back Later", "PTS Utilities", MessageBoxButtons.OK);
		//}
		[UpgradeHelpers.Events.Handler]
		internal void mnuAddress_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmAddress.DefInstance);
			/*			frmAddress.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmAssignReport.DefInstance);
			/*			frmAssignReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Battalion 1 Scheduler
			//int i = 0;
			ViewManager.NavigateToView(

				frmNewBattSched.DefInstance);
			ViewManager.SetCurrentView(
				frmNewBattSched.DefInstance.ViewModel);
			/*			frmNewBattSched.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Battalion 2 Scheduler

			ViewManager.NavigateToView(

				frmNewBattSched2.DefInstance);
			ViewManager.SetCurrentView(
				frmNewBattSched2.DefInstance.ViewModel);
			/*			frmNewBattSched2.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion3_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Battalion 4 Scheduler

			for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
			{
				if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched4")
				{
					ViewManager.DisposeView(
						frmBattSched4.DefInstance);
					break;
				}
			}
			ViewManager.NavigateToView(

				frmBattSched3.DefInstance);
			/*			frmBattSched3.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattStaff_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			modGlobal
				.Shared.gType = "BAT";
			ViewManager.NavigateToView(
				frmWeekly.DefInstance);
			/*			frmWeekly.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBatWeekly_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Dialog box to select report parameters
			modGlobal
				.Shared.gRType = "BAT";
			ViewManager.NavigateToView(
				frmTimeCardX.DefInstance);
			/*			frmTimeCardX.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBenefit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmCF1Report.DefInstance);
			/*			frmCF1Report.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCalendar_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Year Selection dialog box
			//for Shift Calendar report
			ViewManager.NavigateToView(
				//Display Year Selection dialog box
				//for Shift Calendar report
				frmShiftCal.DefInstance);
			/*			frmShiftCal.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCascade_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Cascade visible child windows
			MDIForm1.DefInstance.LayoutMdi(Stubs._System.Windows.Forms.MdiLayout.Cascade);
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCon_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("Help files under construction, not currently available", "Help Menu", UpgradeHelpers.Helpers.BoxButtons.OK);
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDailyStaffing_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Daily Staffing Report Form
			ViewManager.NavigateToView(
				//Display Daily Staffing Report Form
				frmDailyStaffing.DefInstance);
			/*			frmDailyStaffing.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatch_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			modGlobal
				.Shared.gType = "FCC";
			ViewManager.NavigateToView(
				frmDispatchScheduler.DefInstance);
			/*			frmDispatchScheduler.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispWeekly_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Dialog box to select report parameters
			modGlobal
				.Shared.gRType = "FCC";
			ViewManager.NavigateToView(
				frmTimeCardX.DefInstance);
			/*			frmTimeCardX.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEmpInfo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Update Employee Info form
			ViewManager.NavigateToView(
				//Display Update Employee Info form
				frmUpdate.DefInstance);
			/*			frmUpdate.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEMS_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			ViewManager.NavigateToView(
				//Display Weekly Scheduler form
				frmNewEMS.DefInstance);
			/*			frmNewEMS.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEMSDaily_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			ViewManager.NavigateToView(
				//Display Weekly Scheduler form
				frmEMSDailySched.DefInstance);
			/*			frmEMSDailySched.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEMSWeekly_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Dialog box to select report parameters
			modGlobal
				.Shared.gRType = "PM";
			ViewManager.NavigateToView(
				frmTimeCardX.DefInstance);
			/*			frmTimeCardX.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Exit Application
			ViewManager.DisposeView(
				//Exit Application

				frmNewBattSched.DefInstance);
			ViewManager.DisposeView(
				frmNewBattSched2.DefInstance);
			ViewManager.DisposeView(
				frmNewBattSched3.DefInstance);
			ViewManager.DisposeView(this);
			Environment.Exit(0);
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuFRoster_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmRosterFiltered.DefInstance);
			/*			frmRosterFiltered.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuHazmat_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			modGlobal
				.Shared.gType = "HZM";
			ViewManager.NavigateToView(
				frmWeekly.DefInstance);
			/*			frmWeekly.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuHZMWeekly_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Dialog box to select report parameters
			modGlobal
				.Shared.gRType = "HZM";
			ViewManager.NavigateToView(
				frmTimeCardX.DefInstance);
			/*			frmTimeCardX.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuImmune_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Manage Employee Immunizations"
			PTSProject.clsEMSInformation cEMSSecurity = Container.Resolve< clsEMSInformation>();

			if (cEMSSecurity.GetEMSForSecurity(modGlobal.Shared.gUser) != 0)
			{
				ViewManager.NavigateToView(
					frmImmunization.DefInstance);
				/*				frmImmunization.DefInstance.SetBounds(0, 0, 0					, 0, Stubs._System.Windows.Forms.					BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

			}
			else
			{
				ViewManager.ShowMessage("You are not authorized to view/edit this information.", "Manage Employee Immunizations", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndAnnualPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmIndAnnualPayroll.DefInstance);
			/*			frmIndAnnualPayroll.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndSchedule_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Individual Leave Scheduling form
			ViewManager.NavigateToView(
				//Display Individual Leave Scheduling form
				frmIndSched.DefInstance);
			/*			frmIndSched.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//This is the only place this window shows right now
			modGlobal
				.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gPayRollBatt = "";
			ViewManager.NavigateToView(
				frmPayroll.DefInstance);
			/*			frmPayroll.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndTimeCard2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
			ViewManager.NavigateToView(
				frmIndTimeCard.DefInstance);
			/*			frmIndTimeCard.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndYearSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gReportYear = DateTime.Now.Year;
			ViewManager.NavigateToView(
				frmIndivSchedReport.DefInstance);
			/*			frmIndivSchedReport.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuInsteadOfSCKLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmInsteadOfSCKLeave.DefInstance);
			/*			frmInsteadOfSCKLeave.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuMarine_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Weekly Scheduler form
			modGlobal
				.Shared.gType = "MRN";
			ViewManager.NavigateToView(
				frmWeekly.DefInstance);
			/*			frmWeekly.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuMRNWeekly_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Dialog box to select report parameters
			modGlobal
				.Shared.gRType = "MRN";
			ViewManager.NavigateToView(
				frmTimeCardX.DefInstance);
			/*			frmTimeCardX.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuMakeNewSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmUtility.DefInstance);
			/*			frmUtility.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewBatt1_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmBattSchedNew.DefInstance);
			ViewManager.SetCurrentView(
				frmBattSchedNew.DefInstance.ViewModel);
			/*			frmBattSchedNew.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewBatt2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmBatt2SchedNew.DefInstance);
			ViewManager.SetCurrentView(
				frmBatt2SchedNew.DefInstance.ViewModel);
			/*			frmBatt2SchedNew.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewBatt3_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "New Battalion 3"
			ViewManager.NavigateToView(
				//    MsgBox "This feature is coming soon!", vbOKOnly, "New Battalion 3"

				frmNewBattSched3.DefInstance);
			ViewManager.SetCurrentView(
				frmNewBattSched3.DefInstance.ViewModel);
			/*			frmNewBattSched3.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewTrainQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
			ViewManager.NavigateToView(
				//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
				frmNewQClass.DefInstance);
			/*			frmNewQClass.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuOtherPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("This is under construction... coming soon!", "PTS Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
			//    frmPayrollOthers.Show
			//    frmPayrollOthers.Move 0, 0
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuOvertime_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Overtime Report form
			ViewManager.NavigateToView(
				//Display Overtime Report form
				frmOvertime.DefInstance);
			/*			frmOvertime.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPersonnelCodes_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "Under Construction, Check back Later", vbOKOnly, "PTS Utilities"
			ViewManager.NavigateToView(
				//    MsgBox "Under Construction, Check back Later", vbOKOnly, "PTS Utilities"
				dlgSpecialties.DefInstance);
			/*			dlgSpecialties.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPhone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPhone.DefInstance);
			/*			frmPhone.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEmergency_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmEmergencyContact.DefInstance);
			/*			frmEmergencyContact.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPhoneList_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmMasterPhoneLists.DefInstance);
			/*			frmMasterPhoneLists.DefInstance.SetBounds(0, 0,				0, 0, Stubs._System.Windows.Forms				.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPMCerts_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPMCertification.DefInstance);
			/*			frmPMCertification.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPosition_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Assign Position form
			ViewManager.NavigateToView(
				//Display Assign Position form
				frmAssign.DefInstance);
			/*			frmAssign.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPPAudit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPayrollReport.DefInstance);
			/*			frmPayrollReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmNewPPEWDL.DefInstance);
			/*			frmNewPPEWDL.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		//[UpgradeHelpers.Events.Handler]
		//internal void mnuPrintScreen_Click(Object eventSender, System.EventArgs eventArgs)
		//{
		//	//    MsgBox "This feature is coming soon!", vbOKOnly, "Screen Print Any Form"

		//	object i = null;
		//	ViewModel.mnuPrintScreen.Enabled = false;
		//	Stubs._Microsoft.Office.Interop.Word.Application wdApp = new Stubs._Microsoft.Office.Interop.Word.Application();
		//	int lOrigTop = wdApp.Top;
		//	wdApp.WindowState = Stubs._Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateNormal;

		//	// Create a new document.
		//	object tempRefParam = Type.Missing;
		//	object tempRefParam2 = Type.Missing;
		//	object tempRefParam3 = Type.Missing;
		//	object tempRefParam4 = Type.Missing;
		//	Stubs._Microsoft.Office.Interop.Word.Document docNew = wdApp.Documents.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4);
		//	Stubs._Microsoft.Office.Interop.Word.PageSetup withVar = null;
		//	withVar = docNew.PageSetup;
		//	withVar.LineNumbering.Active = 0;
		//	withVar.Orientation = Stubs._Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
		//	withVar.TopMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
		//	withVar.BottomMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
		//	withVar.LeftMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
		//	withVar.RightMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
		//	withVar.Gutter = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
		//	withVar.HeaderDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
		//	withVar.FooterDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
		//	withVar.PageWidth = UpgradeSupport.Word_Global_definst.InchesToPoints(11);
		//	withVar.PageHeight = UpgradeSupport.Word_Global_definst.InchesToPoints(8.5f);
		//	withVar.FirstPageTray = Stubs._Microsoft.Office.Interop.Word.WdPaperTray.wdPrinterDefaultBin;
		//	withVar.OtherPagesTray = Stubs._Microsoft.Office.Interop.Word.WdPaperTray.wdPrinterDefaultBin;
		//	withVar.SectionStart = Stubs._Microsoft.Office.Interop.Word.WdSectionStart.wdSectionNewPage;
		//	withVar.OddAndEvenPagesHeaderFooter = 0;
		//	withVar.DifferentFirstPageHeaderFooter = 0;
		//	withVar.VerticalAlignment = Stubs._Microsoft.Office.Interop.Word.WdVerticalAlignment.wdAlignVerticalTop;
		//	withVar.SuppressEndnotes = 0;
		//	withVar.MirrorMargins = 0;
		//	withVar.TwoPagesOnOne = false;
		//	withVar.GutterPos = Stubs._Microsoft.Office.Interop.Word.WdGutterStyle.wdGutterPosLeft;

		//	//print screen
		//	wdApp.Selection.Paste();
		//	//    docNew.PrintPreview
		//	//    docNew.PrintOut
		//	//    docNew.ClosePrintPreview

		//	//    DoEvents
		//	//    Sleep 10000

		//	//    For i = 1 To 150000   ' Start loop.
		//	//        If i = 1000 = 0 Then
		//	//            DoEvents   ' Yield to operating system.
		//	//        End If
		//	//    Next i   ' Increment loop counter.

		//	object tempRefParam5 = true;
		//	object tempRefParam6 = null;
		//	object tempRefParam7 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintAllDocument;
		//	object tempRefParam8 = null;
		//	object tempRefParam9 = null;
		//	object tempRefParam10 = null;
		//	object tempRefParam11 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutItem.wdPrintDocumentContent;
		//	object tempRefParam12 = 1;
		//	object tempRefParam13 = "";
		//	object tempRefParam14 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutPages.wdPrintAllPages;
		//	object tempRefParam15 = false;
		//	object tempRefParam16 = true;
		//	object tempRefParam17 = "";
		//	object tempRefParam18 = null;
		//	object tempRefParam19 = null;
		//	object tempRefParam20 = 0;
		//	object tempRefParam21 = 0;
		//	object tempRefParam22 = 0;
		//	object tempRefParam23 = 0;
		//	wdApp.PrintOut(ref tempRefParam5, ref tempRefParam6, ref tempRefParam7, ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13, ref tempRefParam14, ref tempRefParam15, ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21, ref tempRefParam22, ref tempRefParam23);
		//	UpgradeSolution1Support.PInvoke.SafeNative.kernel32.Sleep(7000);

		//	//    For i = 1 To 150000   ' Start loop.
		//	//        If i = 1000 = 0 Then
		//	//            DoEvents   ' Yield to operating system.
		//	//        End If
		//	//    Next i   ' Increment loop counter.


		//	object tempRefParam24 = Stubs._Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
		//	object tempRefParam25 = Type.Missing;
		//	object tempRefParam26 = Type.Missing;
		//	wdApp.Quit(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26);
		//	wdApp = null;
		//	ViewModel.mnuPrintScreen.Enabled = true;

		//}

		//[UpgradeHelpers.Events.Handler]
		//internal void mnuPrintSetup_Click(Object eventSender, System.EventArgs eventArgs)
		//{
		//	//Displays Printer Common Dialog Box for Printer selection and print parameters

		//	int BeginPage = 0;
		//	int EndPage = 0;
		//	int NumCopies = 0;
		//	int test1 = 0;

		//	try
		//	{

		//		//Printer Default is set to True
		//		//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CmDialog1.PrinterDefault was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
		//		//ViewModel.CmDialog1.setPrinterDefault(true);

		//		//Display Printer Dialog Box
		//		//ViewModel.CmDialog1Print.ShowDialog();

		//		//Printer Dialog Box Selections
		//		BeginPage = ViewModel.CmDialog1Print.PrinterSettings.FromPage;
		//		EndPage = ViewModel.CmDialog1Print.PrinterSettings.ToPage;
		//		NumCopies = ViewModel.CmDialog1Print.PrinterSettings.Copies;

		//		for (int i = 1; i <= NumCopies; i++)
		//		{
		//			//Place code here to send data to the printer
		//		}
		//	}
		//	catch
		//	{

		//		return;
		//	}
		//}

		[UpgradeHelpers.Events.Handler]
		internal void mnuProlist_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPromoReport.DefInstance);
			/*			frmPromoReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPromoli_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Update Promotions form
			ViewManager.NavigateToView(
				//Display Update Promotions form
				frmUpdatePromo.DefInstance);
			/*			frmUpdatePromo.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPublicRoster_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmPublicRoster.DefInstance);
			/*			frmPublicRoster.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuResource_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("Under Construction, Check back Later", "PTS Utilities", UpgradeHelpers.Helpers.BoxButtons.OK);

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuReviewPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmNotify.DefInstance);
			/*			frmNotify.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuRoster_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmRoster.DefInstance);
			/*			frmRoster.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSecure_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Security Update/Insert form
			ViewManager.NavigateToView(
				//Display Security Update/Insert form
				frmSecurity.DefInstance);
			/*			frmSecurity.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSenior_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				frmSrReport.DefInstance);
			/*			frmSrReport.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSeniorInq_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Show Seniority Ranking Form
			ViewManager.NavigateToView(
				//Show Seniority Ranking Form
				frmSenority.DefInstance);
			/*			frmSenority.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
			ViewManager.NavigateToView(
				frmIndTimeCard.DefInstance);
			/*			frmIndTimeCard.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTrainCodeHelp_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.NavigateToView(
				dlgTrainingCodes.DefInstance);
			/*			dlgTrainingCodes.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTrainQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
			ViewManager.NavigateToView(
				//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
				frmQclass.DefInstance);
			/*			frmQclass.DefInstance.SetBounds(0, 0, 0,				0, Stubs._System.Windows.Forms.BoundsSpecified				.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTransfer_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display  Transfer Schedule report
			ViewManager.NavigateToView(
				//Display  Transfer Schedule report
				frmTransReport.DefInstance);
			/*			frmTransReport.DefInstance.SetBounds(0, 0, 0				, 0, Stubs._System.Windows.Forms.				BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//     'MDIForm1.Arrange vbCascade
		}

		public static MDIForm1 DefInstance
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

		public static MDIForm1 CreateInstance()
		{
			PTSProject.MDIForm1 theInstance = Shared.Container.Resolve< MDIForm1>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.mnuHelp.LifeCycleStartup();
			ViewModel.mnuWindow.LifeCycleStartup();
			ViewModel.mnuUtil.LifeCycleStartup();
			ViewModel.mnuTable.LifeCycleStartup();
			ViewModel.mnuCodes.LifeCycleStartup();
			ViewModel.mnuPayroll.LifeCycleStartup();
			ViewModel.mnuTraining.LifeCycleStartup();
			ViewModel.mnu_Queries.LifeCycleStartup();
			ViewModel.mnuTrnReports.LifeCycleStartup();
			ViewModel.mnuReports.LifeCycleStartup();
			ViewModel.mnu_TrainingReports.LifeCycleStartup();
			ViewModel.mnuPayrollReports.LifeCycleStartup();
			ViewModel.mnu_Battalion.LifeCycleStartup();
			ViewModel.mnu_Leave.LifeCycleStartup();
			ViewModel.mnuSchedul.LifeCycleStartup();
			ViewModel.mnuWeek.LifeCycleStartup();
			ViewModel.mnuBDWork.LifeCycleStartup();
			ViewModel.mnuPerson[0].LifeCycleStartup();
			ViewModel.mnuSchedule.LifeCycleStartup();
			ViewModel.mnu_old.LifeCycleStartup();
			ViewModel.mnuPersonnel[0].LifeCycleStartup();
			ViewModel.mnuSystem.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.mnuHelp.LifeCycleShutdown();
			ViewModel.mnuWindow.LifeCycleShutdown();
			ViewModel.mnuUtil.LifeCycleShutdown();
			ViewModel.mnuTable.LifeCycleShutdown();
			ViewModel.mnuCodes.LifeCycleShutdown();
			ViewModel.mnuPayroll.LifeCycleShutdown();
			ViewModel.mnuTraining.LifeCycleShutdown();
			ViewModel.mnu_Queries.LifeCycleShutdown();
			ViewModel.mnuTrnReports.LifeCycleShutdown();
			ViewModel.mnuReports.LifeCycleShutdown();
			ViewModel.mnu_TrainingReports.LifeCycleShutdown();
			ViewModel.mnuPayrollReports.LifeCycleShutdown();
			ViewModel.mnu_Battalion.LifeCycleShutdown();
			ViewModel.mnu_Leave.LifeCycleShutdown();
			ViewModel.mnuSchedul.LifeCycleShutdown();
			ViewModel.mnuWeek.LifeCycleShutdown();
			ViewModel.mnuBDWork.LifeCycleShutdown();
			ViewModel.mnuPerson[0].LifeCycleShutdown();
			ViewModel.mnuSchedule.LifeCycleShutdown();
			ViewModel.mnu_old.LifeCycleShutdown();
			ViewModel.mnuPersonnel[0].LifeCycleShutdown();
			ViewModel.mnuSystem.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void Form_Unload(int Cancel)
		//{
		//}

	}

	public partial class MDIForm1
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.MDIForm1ViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual MDIForm1 m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void Form_Unload(int Cancel)
		//{
		//}

	}
}