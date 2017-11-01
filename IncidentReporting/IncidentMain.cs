using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using System.Configuration;
using TFDIncident.Configuration;

namespace TFDIncident
{

	public static class IncidentMain
	{


		//Public Constants
		//File Paths
		public const string IMAGEPATH = "\\\\TFDSQL1\\tfdapps\\IRS\\Live\\firephotos\\";
		public const string FIREWEBPATH = "\\\\FSTFD\\TFDWebData\\FireReports\\";
		//** Web file test path  ****
		//Public Const FIREWEBPATH = "d:\Dataload\WebTest\"

		//Data transfer constants
		public const string CPFILEPATH = "Z:\\";
		public const string CPFILEBACKUP = "d:\\DataLoad\\DataOut\\CPBackup\\";
		public const string CPFILEARCHIVE = "d:\\Dataload\\DataOut\\CPArchive\\";
		public const string UHFILEPATH = "d:\\DataLoad\\DataOut\\UnitHistorybk\\";
		public const string SIRENFILEPATH = "d:\\DataLoad\\DataOut\\Siren\\";
		public const string SIRENUNITERROR = "d:\\DataLoad\\DataOut\\Siren\\UnitError\\";
		public const int SYNCHRONIZE = 0x100000;
		public const int INFINITE = 0xFFFF;
		public const string DELETESCRIPT = "ftptest2.txt";


		//Return Constants
		public const int FILEPROCESSED = 0;
		public const int PROCESSERROR = 1;
		public const int NOINCIDENT = 2;
		public const int CPBACKUP = 3;

		//Report Constants
		//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
		public const int DONEREPORTING = 999;
		public const int WIZENTRY = 0;
		public const int UNITREPORT = 1;
		public const int INCIDENTREPORT = 2;
		public const int FIRE = 3;
		public const int FIRESTRUCTURE = 4;
		public const int FIREMOBILE = 5;
		public const int FIREOUTSIDE = 6;
		public const int FIREEXPOSURE = 32;
		public const int HAZMAT = 7;
		public const int HAZMATFIXED = 8;
		public const int HAZMATMOBILE = 9;
		public const int HAZMATDL = 10;
		public const int HAZMATDLRELEASE = 31;
		public const int HAZMATDLTYPE = 71;
		public const int RUPTURE = 11;
		public const int RUPTURESTRUCTURE = 12;
		public const int RUPTUREMOBILE = 13;
		public const int RUPTUREOUTSIDE = 14;
		public const int EMSBASIC = 15;
		public const int EXAMONLY = 0;
		public const int EXAMASSIST = 1;
		public const int EXAMTRANSPORT = 2;
		public const int NOEXAM = 3;
		public const int INTERFAC = 4;
		public const int HAZCONDITION = 16;
		public const int SEARCHRESCUE = 17;
		public const int FALSEALARM = 18;
		public const int INVESTIGATION = 19;
		public const int CLEANUP = 20;
		public const int STANDBY = 21;
		public const int EXPOSURE = 22;
		public const int FSCASUALTY = 23;
		public const int CIVILCASUALTY = 24;
		public const int NAME = 25;
		public const int NARRATION = 26;
		public const int INCENDIARY = 27;
		public const int JUVENILE = 28;
		public const int JUVINCIDENT = 29;
		public const int ADDRESSCORRECTION = 33;
		public const int SIRENPCR = 34;


		//EMS Incident Type Codes
		public const int ALS = 67;
		public const int ALSTRANS = 66;
		public const int BLS = 69;
		public const int BLSTRANS = 68;

		public const int NOALARM = 0;
		public const int DETECTORONLY = 1;
		public const int WATERVESSEL = 62;
		public const int PASSENGERVEHICLE = 55;


		public const int NOREPORT = 0;
		public const int INCOMPLETE = 1;
		public const int SAVEDINCOMPLETE = 2;
		public const int COMPLETE = 3;
		public const int READONLYMODE = 0;
		public const int EDITMODE = 2;
		public const int INSERTONLY = 1;

		//Color Constants
		public const int WHITE = 0xFFFFFF;
		public const int PARCHMENT = 0xB1F0FE;
		public const int UNITCOLOR = 0xC7BAA5;
		public const int REPORTCOLOR = 0xAC9D68;
		public const int INQUIRYCOLOR = 0x7D84BF;
		public const int HAZMATCOLOR = 0xACD9E3;



		//Misc Constants
		public const int WIZARDWIDTH = 12400;
		public const int LOCKDATE = 16;
		public const int FIRELOCK = 45;

		//Security Constants
		public const int ADMINISTRATOR = 1;
		public const int FIREADMIN = 2;
		public const int INSPECTOR = 3;
		public const int BATTALIONCHIEF = 4;
		public const int AUTHOR = 6;
		public const int READONLY = 7;
		public const int NOACCESS = 8;

		public const int HIPAARO = 1;
		public const int HIPAAPRINT = 2;
		public const int HIPAACHANGE = 3;
		public const int HIPAACHGPRT = 4;
		public const int HIPAAEDIT = 5;

		//Public Variables
		internal static DbConnection oIncident
		{
			get
			{
				if ( Shared._oIncident == null )
				{
					Shared.
						_oIncident = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}
				return Shared._oIncident;
			}
			set
			{
				Shared.
					_oIncident = value;
			}
		}
		internal static DbConnection oPTSdata
		{
			get
			{
				if ( Shared._oPTSdata == null )
				{
					Shared.
						_oPTSdata = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}
				return Shared._oPTSdata;
			}
			set
			{
				Shared.
					_oPTSdata = value;
			}
		}
		internal static DbConnection oInspection
		{
			get
			{
				if ( Shared._oInspection == null )
				{
					Shared.
						_oInspection = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}
				return Shared._oInspection;
			}
			set
			{
				Shared.
					_oInspection = value;
			}
		}


		//API Functions
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static void Sleep(int dwMilliseconds);


		internal static void CheckNotificationMessages()
		{
			using ( var async1 = Shared.Async(true) )
			{
				//Check for any existing Notification Messages for current user
				//1st check if current user is valid Notification Receiver
				//Then check if any new messages have been recorded
				TFDIncident.clsNotification NotificationCL = Shared.Container.Resolve<clsNotification>();

				if ( NotificationCL.GetNotificationMessagesNew(Shared.gCurrUser) != 0 )
				{
					async1.Append(() =>
						{
							Shared.ViewManager.NavigateToView(
								frmNotification.DefInstance, true);
						});
				}
			}

		}

		//UPGRADE_WARNING: (1047) Application will terminate when Sub Main() finishes. More Information: http://www.vbtonet.com/ewis/ewi1047.aspx
		[STAThread]
		public static void Main(UpgradeHelpers.Interfaces.IIocContainer Container)
		{
			using ( var async1 = Shared.Async(true) )
			{
				var ViewManager = Container.Resolve<UpgradeHelpers.Interfaces.IViewManager>();
                //Check for another instance of application
                //Mobilize: Not supported: [AnGamboa] Get Process
                //Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                //if ( processes.Length > 1 && Process.GetCurrentProcess().StartTime != processes[0].StartTime )
                //{
                //	Shared.ViewManager.ShowMessage("You already have this application running !", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                //	Environment.Exit(0);
                //}
                //Initialize App Level ADO Data Connections
                //Production Data Connections
                //oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL1; Initial Catalog=Incident; Integrated Security=SSPI"
                //UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
                //oIncident.ConnectionString = "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=IncidentTest; User ID=sa; Password=TFDcot911;Persist Security Info=true";
                oIncident.ConnectionString = SettingsManager.GetConnectionString( "Incident");
				oIncident.Open();
                //oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=PTSdata; Integrated Security=SSPI"
                //UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
                //oPTSdata.ConnectionString = "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=PTSTestBackup; User ID=sa; Password=TFDcot911;Persist Security Info=true";
                oPTSdata.ConnectionString = SettingsManager.GetConnectionString("PTSData");
				oPTSdata.Open();
				// oInspection.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=Inspection; Integrated Security=SSPI"
				//Test Data Connections
				//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=IncidentTest; Integrated Security=SSPI"
				//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=PTSdata; Integrated Security=SSPI"

				//New Server Data Connections
				//    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=Incident; Integrated Security=SSPI"
				//    oPTSdata.Open "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=PTSdata; Integrated Security=SSPI"


				DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				string IntroMsg = "";

				ocmd.Connection = oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_IRSMessage";
				ADORecordSetHelper orec = ADORecordSetHelper.Open(ocmd, "");
				if ( !orec.EOF )
				{
					IntroMsg = Convert.ToString(orec["message_text"]).Trim();
					frmSplash.DefInstance.ViewModel.lbHelp.Text = IntroMsg;
				//    Else
				//        IntroMsg = ""
				}

				UpgradeHelpers.Helpers.Cursor.Current = UpgradeHelpers.Helpers.Cursors.WaitCursor;
				
				//Speak Splash Message
				//    If IntroMsg <> "" Then
				//'        Set IRSVoice.Voice = IRSVoice.GetVoices().Item(0)
				//        IRSVoice.Speak IntroMsg
				//    End If
				async1.Append<TFDIncident.MDIIncident>(() => MDIIncident.DefInstance);
				async1.Append<TFDIncident.MDIIncident>(tempNormalized0 =>
					{
						Shared.ViewManager.NavigateToView(tempNormalized0);
                        //Shared.ViewManager.NavigateToView(frmSplash.DefInstance);
                    });
              //  async1.Append(() => Shared.ViewManager.NavigateToView(frmSplash.DefInstance, true));
                async1.Append(() =>
					{
						Shared.ViewManager.NavigateToView(frmMain.DefInstance);
					});
			}

		}

		internal static string ReportMessage(int CurrIncident, UpgradeHelpers.BasicViewModels.ListBoxViewModel lstMessage)
		{
			//Format Message String for Incident Reports
			//For CurrIncident
			TFDIncident.clsReportLog ReportLog = Shared.Container.Resolve<clsReportLog>();
			TFDIncident.clsFire FireReport = Shared.Container.Resolve<clsFire>();

			int FlagDone = -1;
			lstMessage.Items.Clear();
			//Unit Reports
			string sDisplay = "Unit Reports:";
			lstMessage.AddItem(sDisplay);
			sDisplay = "";
			if ( ReportLog.GetUnitReportRS(CurrIncident) != 0 )
			{

				while ( !ReportLog.ReportLogRS.EOF )
				{
					sDisplay = sDisplay + "     " + Clean(ReportLog.ReportLogRS["responsible_unit_id"]) + "  -  ";
					if ( Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == INCOMPLETE )
					{
						sDisplay = sDisplay + "Incomplete";
						lstMessage.AddItem(sDisplay);
						sDisplay = "";
						FlagDone = 0;
					}
					else if ( Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == SAVEDINCOMPLETE )
					{
						sDisplay = sDisplay + "Saved Incomplete";
						lstMessage.AddItem(sDisplay);
						sDisplay = "";
					}
					else
					{
						sDisplay = sDisplay + "Complete";
						lstMessage.AddItem(sDisplay);
						sDisplay = "";
					}
					ReportLog.ReportLogRS.MoveNext();
				};
				}
			else
			{
				sDisplay = sDisplay + "Unable to retrieve Unit ReportLog records for this Incident";
				lstMessage.AddItem(sDisplay);
				sDisplay = "";
				FlagDone = 0;
			}

			//Incident Reports
			lstMessage.AddItem(sDisplay);
			sDisplay = "Incident Reports:";
			lstMessage.AddItem(sDisplay);
			sDisplay = "";
			if ( ReportLog.GetReportLogRS(CurrIncident) != 0 )
			{

				while ( !ReportLog.ReportLogRS.EOF )
				{
					switch ( Convert.ToInt32(ReportLog.ReportLogRS["ReportType"]) )
					{
						case INCIDENTREPORT:
							sDisplay = sDisplay + "Incident Situation Found Report - ";
							break;
						case FIRE : case FIREMOBILE : case FIREOUTSIDE :
							sDisplay = sDisplay + "Fire Report - ";
							break;
						case FIRESTRUCTURE:
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
							if ( FireReport.GetFireStructure(Convert.ToInt32(GetVal(ReportLog.ReportLogRS["report_reference_id"]))) != 0 )
							{
								if ( FireReport.FlagExposure != 0 )
								{
									sDisplay = sDisplay + "Fire Structure Exposure Report - ";
								}
								else
								{
									sDisplay = sDisplay + "Fire Structure Report - ";
								}
							}
							else
							{
								sDisplay = sDisplay + "Fire Report - ";
							}
							break;
						case RUPTURE : case RUPTURESTRUCTURE : case RUPTUREMOBILE : case RUPTUREOUTSIDE :
							sDisplay = sDisplay + "Rupture/Explosion Report - ";
							break;
						case HAZMAT : case HAZMATFIXED : case HAZMATMOBILE : case HAZMATDL :
							sDisplay = sDisplay + "Hazmat Report - ";
							break;
						case EMSBASIC:
							sDisplay = sDisplay + "EMS Patient Contact Report - ";
							break;
						case SIRENPCR:
							sDisplay = sDisplay + "Siren Patient Care Report - ";
							break;
						case HAZCONDITION:
							sDisplay = sDisplay + "Hazardous Condition Report - ";
							break;
						case SEARCHRESCUE:
							sDisplay = sDisplay + "Search and/or Rescue Report - ";
							break;
						case FALSEALARM:
							sDisplay = sDisplay + "False Alarm Report - ";
							break;
						case INVESTIGATION:
							sDisplay = sDisplay + "Investigate Only Report - ";
							break;
						case CLEANUP:
							sDisplay = sDisplay + "Clean Up Only Report - ";
							break;
						case STANDBY:
							sDisplay = sDisplay + "Standby/Staging Only Report - ";
							break;
						case CIVILCASUALTY:
							sDisplay = sDisplay + "Civilian Casualty Report - ";
							break;
						case FSCASUALTY:
							sDisplay = sDisplay + "Fire Service Casualty Report - ";
							break;
						case FIREEXPOSURE:
							sDisplay = sDisplay + "Fire Structure Exposure Report - ";
							break;
						case ADDRESSCORRECTION:
							sDisplay = sDisplay + "Incident Address Correction - ";
							break;
						default:
							sDisplay = sDisplay + "?? Some Weird Report - ";
							break;
					}
					if ( Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == INCOMPLETE )
					{
						sDisplay = sDisplay + "Incomplete";
						FlagDone = 0;
					}
					else if ( Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == SAVEDINCOMPLETE )
					{
						sDisplay = sDisplay + "Saved Incomplete";
					}
					else
					{
						sDisplay = sDisplay + "Complete";
					}
					sDisplay = sDisplay + " - " + Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
					lstMessage.AddItem(sDisplay);
					sDisplay = "";
					ReportLog.ReportLogRS.MoveNext();
				};
				}
			else
			{
				sDisplay = sDisplay + "Unable to retrieve Reportlog records for this Incident";
				FlagDone = 0;
			}

			if ( FlagDone != 0 )
			{
				sDisplay = "";
				lstMessage.AddItem(sDisplay);
				lstMessage.AddItem(sDisplay);
				sDisplay = "Incident Reporting Finished!!";
				lstMessage.AddItem(sDisplay);
			}
			return (true).ToString();

		}

		internal static int CheckReportSecurity(int lReportLogID)
		{
			//Determine if Current User has Security to  Edit Specified Report
			TFDIncident.clsPersonnel PersonnelCL = Shared.Container.Resolve<clsPersonnel>();
			TFDIncident.clsIncident IncidentCL = Shared.Container.Resolve<clsIncident>();
			TFDIncident.clsReportLog ReportLog = Shared.Container.Resolve<clsReportLog>();
			int IncidentID = 0;
			TFDIncident.clsUnit UnitCL = Shared.Container.Resolve<clsUnit>();
			string DateWork = "";
			int HourWork = 0;
			string CurrUnit = "";
			Shared.

				gWizardSecurity = NOACCESS;


			//***************************************************
			//** Note:  For Report Creation and Entry only the
			//** The specific Unit staff or SysAdmin may open from
			//** Unit Response Tab.  FIREADMIN, BATTALIONCHIEF or INSPECTOR may open
			//** Reports from ReportEditing Tab - See CheckUnitSecurity
			//** function in this module
			//****************************************************

			if ( Shared.gSystemSecurity == ADMINISTRATOR )
			{ //Administrator On Deck

				Shared.
					gWizardSecurity = ADMINISTRATOR;
			//-- Done and out - System Administrators
			}
			else if ( Shared.gSystemSecurity == FIREADMIN )
			{
				Shared.
					gWizardSecurity = READONLY;
			//-- Done and out - Fire Administration Staff
			}
			else
			{
				if ( ~ReportLog.GetReportLog(lReportLogID) != 0 )
				{
					return 0;
				}
				IncidentID = ReportLog.RLIncidentID;
				IncidentCL.GetIncident(IncidentID);
				CurrUnit = ReportLog.ResponsibleUnit;


				//*************************************************
				//** Determine BC Status of current user
				//** In relationship to current report
				//*************************************
				if ( Shared.gSystemSecurity == BATTALIONCHIEF )
				{
					if ( ReportLog.ReportType == INCIDENTREPORT || ReportLog.ReportType == UNITREPORT )
					{
						Shared.
							gWizardSecurity = AUTHOR;
					}
					else
					{
						Shared.
							gWizardSecurity = READONLY;
					}
				//-- Done and out - Battalion Chiefs
				}
				else
				{
					//Determine if Current User was a BC on Incident Date
					DateWork = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("MM/dd/yyyy");
					HourWork = DateAndTime.DatePart("h", DateTime.Parse(IncidentCL.DateIncidentCreated), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					if ( HourWork < 7 )
					{
						DateWork = DateTime.Parse(DateWork).AddDays(-1).ToString("MM/dd/yyyy") + " 7:00 PM";
					}
					else if ( HourWork > 19 )
					{
						DateWork = DateWork + " 7:00 PM";
					}
					else
					{
						DateWork = DateWork + " 7:00 AM";
					}
					if ( PersonnelCL.CheckBC(DateWork) != 0 )
					{
						if ( ReportLog.ReportType == INCIDENTREPORT )
						{
							Shared.
								gWizardSecurity = AUTHOR;
						}
						else if ( ReportLog.ReportType == UNITREPORT )
						{
							Shared.
								gWizardSecurity = AUTHOR;
						}
						else
						{
							Shared.
								gWizardSecurity = READONLY;
						}
					//-- Done and out - Acting BC - Day of Incident
					}
					else
					{
						//Determine if Current User is BC Today
						DateWork = DateTime.Now.ToString("MM/dd/yyyy");
						HourWork = DateAndTime.DatePart("h", DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						if ( HourWork < 7 )
						{
							DateWork = DateTime.Parse(DateWork).AddDays(-1).ToString("MM/dd/yyyy") + " 7:00 PM";
						}
						else if ( HourWork > 19 )
						{
							DateWork = DateWork + " 7:00 PM";
						}
						else
						{
							DateWork = DateWork + " 7:00 AM";
						}
						if ( PersonnelCL.CheckBC(DateWork) != 0 )
						{
							if ( ReportLog.ReportType == INCIDENTREPORT )
							{
								Shared.
									gWizardSecurity = AUTHOR;
							}
							else if ( ReportLog.ReportType == UNITREPORT )
							{
								Shared.
									gWizardSecurity = AUTHOR;
							}
							else
							{
								Shared.
									gWizardSecurity = READONLY;
							}
						//-- Done and out - Acting BC today
						}
					}
				}

				if ( Shared.gWizardSecurity == NOACCESS || Shared.gWizardSecurity == READONLY )
				{
					if ( ReportLog.ReportType == INCIDENTREPORT )
					{
						//Determine if Current User was staffed on any responding Unit for this Incident
						if ( UnitCL.GetIncidentUnitPersonnel(IncidentID) != 0 )
						{

							while ( !UnitCL.UnitPersonnel.EOF )
							{
								if ( Convert.ToString(UnitCL.UnitPersonnel["employee_id"]) == Shared.gCurrUser )
								{
									Shared.
										gWizardSecurity = AUTHOR;
									break;
								}
								UnitCL.UnitPersonnel.MoveNext();
							};
							}
						else if ( Shared.gSystemSecurity == BATTALIONCHIEF )
						{
							Shared.
								gWizardSecurity = AUTHOR;
						}
					}
					else if ( ReportLog.ReportType == UNITREPORT )
					{
						if ( IncidentCL.CheckIncidentParticipant(IncidentID, Shared.gCurrUser) != 0 )
						{
							Shared.
								gWizardSecurity = AUTHOR;
							if ( ReportLog.ReportStatus == COMPLETE )
							{
								if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > LOCKDATE )
								{
									Shared.
										gWizardSecurity = READONLY;
								}
							}
						}
						else if ( Shared.gSystemSecurity == BATTALIONCHIEF )
						{
							Shared.
								gWizardSecurity = AUTHOR;
							if ( ReportLog.ReportStatus == COMPLETE )
							{
								if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > LOCKDATE )
								{
									Shared.
										gWizardSecurity = READONLY;
								}
							}
						}
						else
						{
							Shared.
								gWizardSecurity = NOACCESS;
						}
					}
					else
					{
						//************************************************
						//**  Logic to determine if current user was
						//**  Staffed on ANY Unit that responded to
						//**  This report's Incident
						//************************************************
						//Determine if Current User dispatched to Incident

						if ( IncidentCL.CheckIncidentParticipant(IncidentID, Shared.gCurrUser) != 0 )
						{
							Shared.
								gWizardSecurity = AUTHOR;
							if ( ReportLog.ReportStatus == COMPLETE )
							{
								if ( ReportLog.ReportType == EMSBASIC )
								{
									if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > LOCKDATE )
									{
										Shared.
											gWizardSecurity = READONLY;
									}
								}
								else
								{
									if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > FIRELOCK )
									{
										Shared.
											gWizardSecurity = READONLY;
									}
								}
							}
						}
						else if ( Shared.gWizardSecurity == BATTALIONCHIEF )
						{
							Shared.
								gWizardSecurity = READONLY;
						}
						else
						{
							Shared.
								gWizardSecurity = NOACCESS;
						}
					}
					if ( Shared.gWizardSecurity == NOACCESS )
					{
						//Check for Inspector
						if ( Shared.gSystemSecurity == INSPECTOR )
						{
							if ( ReportLog.ReportType == EMSBASIC )
							{
								Shared.
									gWizardSecurity = READONLY;
							}
							else if ( ReportLog.ReportStatus == COMPLETE )
							{
								if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > FIRELOCK )
								{
									Shared.
										gWizardSecurity = READONLY;
								}
								else
								{
									Shared.
										gWizardSecurity = AUTHOR;
								}
							}
							else
							{
								Shared.
									gWizardSecurity = AUTHOR;
							}
						}
						else if ( Shared.gSystemSecurity == BATTALIONCHIEF )
						{
							if ( ReportLog.ReportType == INCIDENTREPORT )
							{
								Shared.
									gWizardSecurity = AUTHOR;
							}
							else if ( ReportLog.ReportType == UNITREPORT )
							{
								Shared.
									gWizardSecurity = AUTHOR;
							}
							else
							{
								Shared.
									gWizardSecurity = READONLY;
							}
						}
					}
				}
			}

			if ( Shared.gWizardSecurity == NOACCESS )
			{
				return 0;
			}
			else
			{
				return -1;
			}

		}

		internal static int CheckUnitSecurity(int lIncidentID, string sUnitID)
		{
			//Determine if Current User has Security to Enter Edit Unit Report
			int result = 0;
			TFDIncident.clsPersonnel PersonnelCL = Shared.Container.Resolve<clsPersonnel>();
			TFDIncident.clsIncident IncidentCL = Shared.Container.Resolve<clsIncident>();
			TFDIncident.clsReportLog ReportLog = Shared.Container.Resolve<clsReportLog>();
			int UnitReportLog = 0;
			TFDIncident.clsUnit UnitCL = Shared.Container.Resolve<clsUnit>();
			string CurrUnit = "";
			int CurrReportID = 0;
			Shared.

				gWizardSecurity = NOACCESS;

			//***************************************************
			//** Note:  For Report Creation and Entry only the
			//** The specific Unit staff or SysAdmin may open from
			//** Unit Response Tab.  FIREADMIN or INSPECTOR may open
			//** Reports from ReportEditing Tab - See CheckReportSecurity
			//** function in this module
			//****************************************************

			if ( Shared.gSystemSecurity == ADMINISTRATOR )
			{ //Administrator On Deck

				Shared.
					gWizardSecurity = ADMINISTRATOR;
			}
			else
			{
				CurrReportID = ReportLog.GetNextIncompleteReport(lIncidentID, sUnitID);
				if ( CurrReportID == 0 )
				{
					return 0;
				}
				ReportLog.GetReportLog(CurrReportID);
				IncidentCL.GetIncident(lIncidentID);
				CurrUnit = ReportLog.ResponsibleUnit;

				//Determine if Current User was staffed on Unit
				UnitReportLog = UnitCL.GetRespUnitRespID(CurrReportID);
				if ( UnitCL.GetUnitPersonnelRS(UnitReportLog) != 0 )
				{

					while ( !UnitCL.UnitPersonnel.EOF )
					{
						if ( Convert.ToString(UnitCL.UnitPersonnel["employee_id"]) == Shared.gCurrUser )
						{
							result = -1;
							Shared.
								gWizardSecurity = AUTHOR;
							if ( ReportLog.ReportStatus == COMPLETE )
							{
								if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(IncidentCL.DateIncidentCreated), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > LOCKDATE )
								{
									Shared.
										gWizardSecurity = READONLY;
								}
							}
							break;
						}
						UnitCL.UnitPersonnel.MoveNext();
					};
					}
				}

			if ( Shared.gWizardSecurity == NOACCESS )
			{
				return 0;
			}
			else
			{
				return -1;
			}
			return result;
		}

		internal static string Clean(object varData)
		{
			//Converts rdoResultset column data to a string
			//Handles Nulls and Empty Values as needed

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( Convert.IsDBNull(varData) )
			{
				return "";
			}
			else if ( Object.Equals(varData, null) )
			{
				return "";
			}
			else
			{
				//UPGRADE_WARNING: (1068) varData of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				return Convert.ToString(varData).Trim();
			}

		}

		internal static object GetVal(object varNumber)
		{
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( Convert.IsDBNull(varNumber) )
			{
				return 0;
			}
			else
			{
				return varNumber;
			}

		}

		//Mobilize: Method not used. Oquesada 20161110
		//      internal static int LoadListbox(Control oList, string SqlString)
		//{
		//	//Load passed combo or listbox control with
		//	//results of passed sql string

		//	DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

		//	ocmd.Connection = oIncident;
		//	ocmd.CommandType = CommandType.Text;
		//	ocmd.CommandText = SqlString;
		//	ADORecordSetHelper orec = ADORecordSetHelper.Open(ocmd, "");
		//	if (orec.EOF)
		//	{
		//		return 0;
		//	}


		//	while(!orec.EOF)
		//	{
		//		//UPGRADE_TODO: (1067) Member AddItem is not defined in type VB.Control. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
		//		oList.AddItem(Clean(orec.GetField(1)));
		//		//UPGRADE_TODO: (1067) Member NewIndex is not defined in type VB.Control. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
		//		//UPGRADE_TODO: (1067) Member ItemData is not defined in type VB.Control. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
		//		oList.ItemData[oList.NewIndex] = orec[0];
		//		orec.MoveNext();
		//	};

		//	return -1;

		//}

		internal static int SetListbox(UpgradeHelpers.Helpers.ControlViewModel oList, int iCode)
		{
			//Set Selected item(s) in passed combo or List box to code value
			UpgradeHelpers.BasicViewModels.ComboBoxViewModel oListTyped = null;
			UpgradeHelpers.BasicViewModels.ListBoxViewModel oListTyped2 = null;
			if ( oList is UpgradeHelpers.BasicViewModels.ComboBoxViewModel )
			{
				oListTyped = (UpgradeHelpers.BasicViewModels.ComboBoxViewModel)oList;
				for ( int i = 0; i <= oListTyped.Items.Count - 1; i++ )
				{
					if ( oListTyped.GetItemData(i) == iCode )
					{
						oListTyped.SelectedIndex = i;
						break;
					}
				}
			}
			else if ( oList is UpgradeHelpers.BasicViewModels.ListBoxViewModel )
			{
				oListTyped2 = (UpgradeHelpers.BasicViewModels.ListBoxViewModel)oList;
				for ( int i = 0; i <= oListTyped2.Items.Count - 1; i++ )
				{
					if ( oListTyped2.GetItemData(i) == iCode )
					{
						UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(oListTyped2, i, true);
					}
				}
			}
			else
			{
				return 0;
			}
			return -1;
		}
		internal static void MoveForm(UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> FormName)
		{
			/*			FormName.SetBounds(0, 0, 0, 0, Stubs				._System.Windows.Forms.BoundsSpecified.X |				Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		internal static void CenterForm(UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> f, UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel> MainForm)
		{
				/*			//Center Form			f.SetBounds(((MainForm.Width * 15 - f.Width			* 15) / 2) / 15, ((MainForm.Height * 15 - f				.Height * 15) / 2) / 15, 0, 0,				Stubs._System.Windows.Forms.BoundsSpecified.				X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//Center Form
			;

		}


		internal static string ProofSQLString(ref string sString)
		{
			//Removes Single quote ' & Comma's , from string values
			//That will be sent to SqlServer

			string WorkString = Strings.Replace(sString, "'", " ", 1, -1, CompareMethod.Binary);
			sString = WorkString;
			WorkString = Strings.Replace(sString, ",", "-", 1, -1, CompareMethod.Binary);
			return WorkString;

		}

		internal static string CleanDate(UpgradeHelpers.DB.ADO.ADOFieldHelper varData)
		{
			//Converts rdoResultset date column data to a string
			//Handles Nulls,Empty Values, no dates as needed

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
			if ( Convert.IsDBNull(varData.Value) )
			{
				return "";
			}
			else if ( varData == null )
			{
				return "";
			}
			else if ( Convert.ToDateTime(varData.Value).ToString("M/d/yyyy") == "1/1/1900" )
			{
				return "";
			}
			else
			{
				return Convert.ToString(varData.Value).Trim();
			}

		}


		internal static int ProcessFDCaresReferral(int lIncidentID, int lPatientID)
		{
			//Process FDCaresReferral request.  If coming from Situation Found forms - no PatientId,
			//If coming from EMS forms there should be a patient id.
			int result = 0;
			TFDIncident.clsEMS EMScl = Shared.Container.Resolve<clsEMS>();

			try
			{
				result = -1;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( Convert.IsDBNull(lIncidentID) )
				{
					return 0;
				}

				EMScl.ReferralIncidentID = lIncidentID;
				EMScl.ReferredBy = Shared.gCurrUser;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( Convert.IsDBNull(lPatientID) )
				{
					EMScl.ReferralPatientID = 0;
				}
				else
				{
					EMScl.ReferralPatientID = lPatientID;
				}
				EMScl.ReferralComment = Shared.gFDCaresComment;

				if ( ~EMScl.AddFDCaresReferral() != 0 )
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public static UpgradeHelpers.Interfaces.IViewManager ViewManager
		{
			get
			{
				return Shared.ViewManager;
			}
		}

		public static UpgradeHelpers.Interfaces.IIocContainer Container
		{
			get
			{
				return Shared.Container;
			}
		}

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
				NULLVALUE = DBNull.Value;
				BLACK = UpgradeHelpers.Helpers.Color.Black;
				DKGRAY = UpgradeHelpers.Helpers.Color.Gray;
				LTGRAY = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
				RED = UpgradeHelpers.Helpers.Color.Red;
				TEAL = UpgradeHelpers.Helpers.Color.Teal;
				SALMON = UpgradeHelpers.Helpers.Color.Salmon;
				SITFOUNDCOLOR = UpgradeHelpers.Helpers.Color.FromArgb(154, 182, 172);
				FIRECOLOR = UpgradeHelpers.Helpers.Color.FromArgb(197, 206, 172);
				RUPTURECOLOR = UpgradeHelpers.Helpers.Color.FromArgb(192, 64, 0);
				RUPTUREFONT = UpgradeHelpers.Helpers.Color.Brown;
				FIREFONT = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
				REQCOLOR = UpgradeHelpers.Helpers.Color.LightBlue;
				EMSCOLOR = UpgradeHelpers.Helpers.Color.White;
				EMSFONT = UpgradeHelpers.Helpers.Color.Navy;
				HAZMATFONT = UpgradeHelpers.Helpers.Color.FromArgb(89, 112, 65);
				SITFOUNDFONT = UpgradeHelpers.Helpers.Color.FromArgb(87, 102, 92);
				ALLINFOFONT = UpgradeHelpers.Helpers.Color.FromArgb(64, 64, 64);
				SERVICEFONT = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 64);
				CIVCSTYFONT = UpgradeHelpers.Helpers.Color.Maroon;
				CIVCSTYCOLOR = UpgradeHelpers.Helpers.Color.FromArgb(143, 154, 169);
				FSCASUALTYFONT = UpgradeHelpers.Helpers.Color.FromArgb(64, 0, 0);
				ADDRESSFONT = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
				gCurrUser = "";
				gCurrUserName = "";
				gSystemSecurity = 0;
				gEMSSecurity = 0;
				gWizardSecurity = 0;
				gEditSecurity = 0;
				gCurrUnit = "";
				_oIncident = null;
				_oPTSdata = null;
				_oInspection = null;
				gEditReportID = 0;
				gNewReportID = 0;
				gPrintReportID = 0;
				gWizardIncidentID = 0;
				gWizardUnitID = "";
				gWizCancel = 0;
				gAppCancel = 0;
				gQueryRecordset = null;
				gCurrentQuery = 0;
				gQueryStartDate = "";
				gQueryEndDate = "";
				gHelpScreen = 0;
				gHelpControl = 0;
				gHIPAAState = 0;
				gHIPAAOK = 0;
				gHIPAAPatientID = 0;
				gFDCaresIncidentID = 0;
				gFDCaresPatientID = 0;
				gFDCaresComment = "";
				gFDCaresOK = 0;
				gExportFlag = 0;
			}

			public virtual object NULLVALUE { get; set; }

			public virtual UpgradeHelpers.Helpers.Color BLACK { get; set; }

			public virtual UpgradeHelpers.Helpers.Color DKGRAY { get; set; }

			public virtual UpgradeHelpers.Helpers.Color LTGRAY { get; set; }

			public virtual UpgradeHelpers.Helpers.Color RED { get; set; }

			public virtual UpgradeHelpers.Helpers.Color TEAL { get; set; }

			public virtual UpgradeHelpers.Helpers.Color SALMON { get; set; }

			public virtual UpgradeHelpers.Helpers.Color SITFOUNDCOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color FIRECOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color RUPTURECOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color RUPTUREFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color FIREFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color REQCOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color EMSCOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color EMSFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color HAZMATFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color SITFOUNDFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color ALLINFOFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color SERVICEFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color CIVCSTYFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color CIVCSTYCOLOR { get; set; }

			public virtual UpgradeHelpers.Helpers.Color FSCASUALTYFONT { get; set; }

			public virtual UpgradeHelpers.Helpers.Color ADDRESSFONT { get; set; }

			public virtual string gCurrUser { get; set; }

			public virtual string gCurrUserName { get; set; }

			public virtual int gSystemSecurity { get; set; }

			public virtual int gEMSSecurity { get; set; }

			public virtual int gWizardSecurity { get; set; }

			public virtual int gEditSecurity { get; set; }

			public virtual string gCurrUnit { get; set; }

			public virtual DbConnection _oIncident { get; set; }

			public virtual DbConnection _oPTSdata { get; set; }

			public virtual DbConnection _oInspection { get; set; }

			public virtual int gEditReportID { get; set; }

			public virtual int gNewReportID { get; set; }

			public virtual int gPrintReportID { get; set; }

			public virtual int gWizardIncidentID { get; set; }

			public virtual string gWizardUnitID { get; set; }

			public virtual int gWizCancel { get; set; }

			public virtual int gAppCancel { get; set; }

			public virtual ADORecordSetHelper gQueryRecordset { get; set; }

			public virtual int gCurrentQuery { get; set; }

			public virtual string gQueryStartDate { get; set; }

			public virtual string gQueryEndDate { get; set; }

			public virtual int gHelpScreen { get; set; }

			public virtual int gHelpControl { get; set; }

			public virtual int gHIPAAState { get; set; }

			public virtual int gHIPAAOK { get; set; }

			public virtual int gHIPAAPatientID { get; set; }

			public virtual int gFDCaresIncidentID { get; set; }

			public virtual int gFDCaresPatientID { get; set; }

			public virtual string gFDCaresComment { get; set; }

			public virtual int gFDCaresOK { get; set; }

			public virtual int gExportFlag { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}