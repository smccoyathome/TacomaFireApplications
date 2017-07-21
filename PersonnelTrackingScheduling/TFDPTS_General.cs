using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using TFDPTSData.Configuration;

namespace PTSProject
{

    public static class modGlobal
    {


        //****************************************************
        //modGlobal contains application wide constants and
        //variables
        //It also contains an application wide Error Handling
        //function (ErrorControl)that is called by all
        //procedure error handlers
        //****************************************************
        //Global Constants
        //****************************************************
        public const int LEFT_BUTTON = 1;
        public const int RIGHT_BUTTON = 2;
        public const int MAXLEAVEX = 2;
        public const int MAXLEAVEREG = 10;
        public const int MAXHOLX = 6;
        public const int MAXHOLREG = 5;
        public const double MAXMIL = 7.5d;
        public const double newMAXMIL = 10.5d;
        public const int MAXKEL = 6;
        public const int MAXDEBIT = 10;

        //********************************************************
        //Constants for static Assignment ID Keys
        //for Annual Schedule generation
        //********************************************************
        public const int ASGN181ROV = 559;
        public const int ASGN182ROV = 560;
        public const int ASGN181DBT = 561;
        public const int ASGN182DBT = 562;
        public const int ASGN184ROV = 1167;
        public const int ASGN183ROV = 1283;
        public const int ASGN183DBT = 1284;



        //********************************************************
        //Schedule Constants used to calculate
        //Stylesets for Individual Leave Calendar control
        //********************************************************
        public const string REGSCHED = "";
        public const string DEBAM = "9";
        public const string DEBPM = "99";
        public const string DEBFULL = "999";
        public const string NOSCHED = "N";
        public const string VACAM = "1";
        public const string VACPM = "2";
        public const string VACFULL = "12";
        public const string HOLAM = "3";
        public const string HOLPM = "4";
        public const string HOLFULL = "34";
        public const string MILAM = "5";
        public const string MILPM = "6";
        public const string MILFULL = "56";
        public const string KELAM = "7";
        public const string KELPM = "8";
        public const string KELFULL = "78";
        public const string VACHOL = "14";
        public const string VACMIL = "16";
        public const string VACKEL = "18";
        public const string HOLVAC = "32";
        public const string MILVAC = "52";
        public const string KELVAC = "72";
        public const string HOLMIL = "36";
        public const string HOLKEL = "38";
        public const string MILHOL = "54";
        public const string KELHOL = "74";
        public const string MILKEL = "58";
        public const string KELMIL = "76";
        public const string OTHAM = "10";
        public const string OTHPM = "20";
        public const string OTHFULL = "1020";
        public const string OTHVAC = "102";
        public const string OTHHOL = "104";
        public const string OTHMIL = "106";
        public const string OTHKEL = "108";
        public const string VACOTH = "120";
        public const string HOLOTH = "320";
        public const string MILOTH = "520";
        public const string KELOTH = "720";
        public const string TRDAM = "A";
        public const string TRDPM = "B";

        //new styleset constants
        public const string EDUAM = "C";
        public const string EDUPM = "D";
        public const string EDUFULL = "CD";
        public const string TRDEDU = "AD";
        public const string EDUTRD = "CB";
        public const string EDUVAC = "C2";
        public const string VACEDU = "1D";
        public const string DEBEDU = "9D";
        public const string EDUDEB = "C99";
        public const string EDUHOL = "C4";
        public const string HOLEDU = "3D";
        public const string KELEDU = "7D";
        public const string EDUKEL = "C8";
        public const string MILEDU = "5D";
        public const string EDUMIL = "C6";
        public const string EDUOTH = "C10";
        public const string OTHEDU = "20D";


        //********************************************************
        //Error Handling Constants
        //********************************************************
        public const int eFATALERROR = 99;
        public const int eRESUME = 1;
        public const int eRESUMENEXT = 2;

        //********************************************************
        //Color Constansts
        //*******************************************************
        public const int CVACATION = 0xC0; //RED
        public const int CHOLIDAY = 0x80FFFF; //YELLOW
        public const int CMILITARY = 0x4080; //BROWN
        public const int COVERTIME = 0xFF00FF; //PINK
        public const int CKELLY = 0x80FF; //ORANGE
        public const int CDEFAULT = 0xFFFFFF; //WHITE
        public const int CREGULAR = 0xC00000; //BLUE
        public const int CDEBIT = 0xC0C000; //LT BLUE
        public const int COTHER = 0x800080; //PURPLE
        public const int CTRADE = 0xFF00; //LT GREEN
        public const int CNOTES = 0xFFC0C0; //LT PURPLE
        //Global Const BLACK = &H0
        public const int LT_BLUE = 0xFFFFC0;
        public const int LT_GREEN = 0x80FF80;
        public const int ORANGE = 0x80FF;
        public const int PEACH = 0x80C0FF;
        public const int PUMPKIN = 0x80FF;
        public const int DK_YELLOW = 0xC0C0;

        public const int TrainingGreen = 0x80FF80;
        public const int TrainingBlue = 0xFFFF80;
        public const int TrainingYellow = 0x80FFFF;
        public const int TrainingPeach = 0x80C0FF;
        public const int TrainingPurple = 0xFF8080;

        //File Paths
        //********************************************************
        public const string IMAGEPATH = "\\\\tfdsql1\\tfdapps\\pts\\live\\images\\";
        //Global Const IMAGEPATH = "\\TFDNM01\tfdapps\pts\live\images\"
        //********************************************************
        // UNCOMMENT FOR PRODUCTION
        // COMMENT WHEN TESTING NEW PICTURES
        //********************************************************
        public const string PICTUREPATH = "\\\\tfdsql1\\tfdapps\\pts\\live\\pictures\\";
        //Global Const PICTUREPATH = "\\TFDNM01\tfdapps\pts\live\pictures\"
        //********************************************************
        // COMMENT FOR PRODUCTION
        // UNCOMMENT WHEN TESTING NEW PICTURES
        //********************************************************
        //Global Const PICTUREPATH = "\\fstfd1\TFD-Pictures\Fire Personnel Pictures\PTSPictures\"

        //********************************************************
        //Global Data Access Variables
        //********************************************************
        public static DbConnection oConn
        {
            get
            {
                if (Shared._oConn == null)
                {
                    Shared._oConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
                }
                return Shared._oConn;
            }
            set
            {
                Shared._oConn = value;
            }
        }
        public static DbConnection oIncident
        {
            get
            {
                if (Shared._oIncident == null)
                {
                    Shared._oIncident = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
                }
                return Shared._oIncident;
            }
            set
            {
                Shared._oIncident = value;
            }
        }


        //********************************************************
        // More Global Variables
        //********************************************************

        //For Exporting to Excel

        //********************************************************
        //API Functions
        //********************************************************
        //UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
        //[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //extern public static void Sleep(int dwMilliseconds);

        //UPGRADE_WARNING: (1047) Application will terminate when Sub Main() finishes. More Information: http://www.vbtonet.com/ewis/ewi1047.aspx
        /*WEBMAP_UPGRADE_ISSUE: (1106) The async nesting depth reached to 1.*/
        [STAThread]
        public static void Main(UpgradeHelpers.Interfaces.IIocContainer Container)
        {
            using (var async1 = Shared.Async(true))
            {

                var ViewManager = Container.Resolve<UpgradeHelpers.Interfaces.IViewManager>();
                //********************************************************
                //Opening subroutine
                //Display splash screen and load program
                //********************************************************
                //Mobilize: Not supported: [AnGamboa] Get Process
                //Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                //if ( processes.Length > 1 && Process.GetCurrentProcess().StartTime != processes[0].StartTime )
                //{
                //	Shared.ViewManager.ShowMessage("You already have this application running !", "TFD Personnel Tracking System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                //	Environment.Exit(0);
                //}

                //********************************************************
                //Create instance of Application ADO Connection          *
                //Test Database -                                        *
                //****** Comment out both connection and global TestMode *
                //****** variable for Production executable              *
                //    '********************************************************
                //    oConn.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=PTSTestBackup; Integrated Security=SSPI"
                //    gTestMode = True

                //********************************************************
                //*** Production Database -                              *
                //****** Comment out both connection and global TestMode *
                //****** variable for Test executable                    *
                //********************************************************
                //UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx

                oConn.ConnectionString = SettingsManager.GetConnectionString("PTSData");
                oConn.Open();
                //oConn.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=PTSData; Integrated Security=SSPI"
                Shared.gTestMode = 0;

                //********************************************************
                //    'TESTING FOR SQL UPGRADE
                //    oConn.Open "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=PTSData; Integrated Security=SSPI"
                //    oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=Incident; Integrated Security=SSPI"
                //    gTestMode = False
                //********************************************************
                //UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
                oIncident.ConnectionString = SettingsManager.GetConnectionString("Incident");
                oIncident.Open();
                //oIncident.Open "Provider=SQLOLEDB; Data Source=TFDSQL1;  Initial Catalog=Incident; Integrated Security=SSPI"
                UpgradeHelpers.Helpers.Cursor.Current = UpgradeHelpers.Helpers.Cursors.WaitCursor;
                async1.Append<PTSProject.MDIForm1>(() => MDIForm1.DefInstance);
                async1.Append<PTSProject.MDIForm1>(tempNormalized0 =>
                {
                    Shared.ViewManager.NavigateToView(tempNormalized0);
                });
                // don't display the splash screen!
                //async1.Append(() => Shared.ViewManager.NavigateToView(frmSplash.DefInstance, true));
                //async1.Append(() =>
                //{
                //    using (var async2 = Shared.Async())
                //    {
                //        //UpgradeSolution1Support.PInvoke.SafeNative.kernel32.Sleep(5000);
                //        async2.Append<PTSProject.MDIForm1>(() => MDIForm1.DefInstance);
                //        async2.Append<PTSProject.MDIForm1>(tempNormalized0 =>
                //        {
                //            Shared.ViewManager.NavigateToView(tempNormalized0);
                //        });
                //        //async2.Append(() =>
                //        //{

                //        //    UpgradeHelpers.Helpers.Cursor.Current = UpgradeHelpers.Helpers.Cursors.Arrow;
                //        //   // Shared.ViewManager.DisposeView(frmSplash.DefInstance);
                //        //});
                //    }
                //});

            }

        }



        internal static bool CheckPayLock(string CheckDate, string CurrBatt)
        {
            //Check if Date is Locked
            bool result = false;
            DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

            oCmd.Connection = oConn;
            oCmd.CommandType = CommandType.Text;

            oCmd.CommandText = "sp_GetSignOff '" + CheckDate + "','" + CurrBatt + "'";
            ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
            if (!oRec.EOF)
            {
                if (Convert.ToBoolean(oRec["shift_status"]))
                {
                    result = true;
                }
            }

            return result;
        }

        internal static string Clean(object varData)
        {
            //********************************************************
            //Converts rdoResultset column data to a string
            //Handles Nulls and Empty Values as needed
            //********************************************************

            //UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
            if (Convert.IsDBNull(varData))
            {
                return "";
            }
            else if (Object.Equals(varData, null))
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
            //********************************************************
            //Processes Null values for numeric recordset fields
            //********************************************************
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
            if (Convert.IsDBNull(varNumber))
            {
                return 0;
            }
            else
            {
                return varNumber;
            }

        }

        internal static int ErrorControl()
        {
            //********************************************************
            //Global Error handling routine
            //returns error results to procedure error handlers
            //********************************************************
            string Msg = "";
            Microsoft.VisualBasic.MsgBoxStyle msgType = Microsoft.VisualBasic.MsgBoxStyle.Exclamation;
            //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
            int switchVar = UpgradeHelpers.Helpers.Information.Err().Number;
            if (switchVar == 424)
            {
                return eRESUMENEXT;
            }
            else if (switchVar == 32755)
            {
                return eRESUMENEXT;
            }
            else if (switchVar > 3)
            {
                Msg = "Uh-Oh Something went wrong!!";
                Msg = Msg + "\r" + "Please contact Debra Lewandowsky and tell her";
                Msg = Msg + "\r" + "That - " + UpgradeHelpers.Helpers.Information.Err().Description;
                //UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                //UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                //MOBILIZE-NOASYNC
                Interaction.MsgBox(Msg, msgType, "TFDPTS Error");

                return eFATALERROR;
            }
            else
            {
                Msg = "Uh-Oh Something went wrong!!";
                Msg = Msg + "\r" + "Please contact Debra Lewandowsky and tell her";
                Msg = Msg + "\r" + "That - " + UpgradeHelpers.Helpers.Information.Err().Description;
                //UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                //UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: http://www.vbtonet.com/ewis/ewi1046.aspx
                //MOBILIZE-NOASYNC
                Interaction.MsgBox(Msg, msgType, "TFDPTS Error");

                return eFATALERROR;
            }

        }

        internal static void RefreshActiveForm()
        {

            switch (MDIForm1.DefInstance.ViewModel.ActiveMdiChild.ViewModel.Name)
            {
                case "frmIndSched":
                    frmIndSched.DefInstance.GetLeaveTotals();
                    frmIndSched.DefInstance.FillSchedule();
                    frmIndSched.DefInstance.GetDailyTotals();

                    break;
                case "frmBattSched3":
                case "frmBattSched4":
                    //            frmBattSched3.ClearSchedule 
                    //            frmBattSched3.GetBattSchedule 
                    //            frmBattSched3.FillLists 

                    break;
                case "frmWeekly":
                    frmWeekly.DefInstance.GetSchedule();

                    break;
                case "frmDispatchScheduler":
                    frmDispatchScheduler.DefInstance.GetSchedule();

                    break;
                case "frmNewEMS":
                    frmNewEMS.DefInstance.GetSchedule();

                    break;
                case "frmEMSDailySched":
                    frmEMSDailySched.DefInstance.ClearSchedule();
                    frmEMSDailySched.DefInstance.GetSchedule();
                    frmEMSDailySched.DefInstance.FillLists();

                    break;
                case "frmVacationScheduler":
                    frmVacationScheduler.DefInstance.CreateStyleSets();
                    //            frmVacationScheduler.SetCalendarShifts 

                    break;
                case "frmPMVacationScheduler":
                    frmPMVacationScheduler.DefInstance.CreateStyleSets();
                    //            frmVacationScheduler.SetCalendarShifts 

                    break;
                case "frmHZMVacationScheduler":
                    frmHZMVacationScheduler.DefInstance.CreateStyleSets();
                    //            frmVacationScheduler.SetCalendarShifts 

                    break;
                case "frmFCCVacationScheduler":
                    frmFCCVacationScheduler.DefInstance.CreateStyleSets();
                    //            frmVacationScheduler.SetCalendarShifts 

                    break;
            }

        }
        public static ExtendLeaveStruct ExtendLeave(string Empid)
        {
            using (var async1 = Shared.Async<ExtendLeaveStruct>(true))
            {
                //********************************************************
                //ExtendLeave Function returns:
                //True if ALL Leave was processed
                //False if Leave Request was cancelled
                //********************************************************
                DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                DbCommand oCmdInsert = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                DbCommand oCmdDelete = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                ADORecordSetHelper oRec1 = null;
                ADORecordSetHelper orec2 = null;
                int Response = 0;
                string LeaveDate = "";
                string JobCode = "";
                int Step = 0;
                Shared.
                    GivingUpShift = false;
                oCmdInsert.Connection = oConn;
                oCmdInsert.CommandType = CommandType.Text;
                oCmdDelete.Connection = oConn;
                oCmdDelete.CommandType = CommandType.Text;
                oCmd.Connection = oConn;
                oCmd.CommandType = CommandType.Text;
                oCmdInsert.CommandText = "sp_GetIndSchedule '" + Empid + "','" + Shared.gStartTrans + "','" + Shared.gEndTrans + "'";
                ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmdInsert, "");
                string sMessage = "";
                async1.AppendWhile(() =>
                {
                    return !oRec.EOF;
                }, () =>
                {
                    using (var async2 = Shared.Async())
                    {
                        //No Leave is Scheduled...  but they may be working a Trade...
                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                        if (Convert.IsDBNull(oRec["leave_time"]))
                        {
                            LeaveDate = Convert.ToString(oRec["ShiftStart"]).Trim();
                            if (Clean(oRec["TimeType"]) != "TRD")
                            {
                                // If not working a TRD...  then Schedule the Leave...
                                if (Convert.ToBoolean(oRec["pay_upgrade"]))
                                {
                                    //Get current Job Code & Step
                                    JobCode = GetJobCode(Empid);
                                    Step = Convert.ToInt32(Double.Parse(GetStep(Empid)));
                                    //Remove Payupgrade
                                    oCmdUpdate.Connection = oConn;
                                    oCmdUpdate.CommandType = CommandType.StoredProcedure;
                                    oCmdUpdate.CommandText = "spUpdateSchedulePay";
                                    oCmdUpdate.ExecuteNonQuery(new object[]{ Empid, LeaveDate, 0, JobCode, Step, DateTime.Now, Shared.gUser });
                                }
                                async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => ScheduleLeave(Empid, LeaveDate));
                                async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized1 =>
                                {
                                    var returningMetodValue76 = tempNormalized1;
                                
                                    Response = returningMetodValue76.returnValue;
                                    Empid = returningMetodValue76.Empid;
                                    LeaveDate = returningMetodValue76.LeaveDate;
                                    if (Response != 0)
                                    {
                                    }
                                    else
                                    {
                                        sMessage = "Ooops!! Insert " + Shared.gLeaveType + " for " + Convert.ToString(oRec["schedule_date"]).Trim() + " " + Convert.ToString(oRec["AMPM"]).Trim() + " didn't work !!";
                                        Shared.ViewManager.ShowMessage(sMessage, "Insert Leave Error", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                });
                            }
                            else
                            {
                                //If working a Trade...  display trade information
                                oCmd.CommandText = "sp_GetTradeRecord '" + Empid + "','" + LeaveDate + "'";
                                oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                if (oRec1.EOF)
                                {
                                    Shared.ViewManager.ShowMessage("Ooops!!  Problem Retrieving the TRD for " + Convert.ToString(oRec["schedule_date"]).Trim()
                                        + " " + Convert.ToString(oRec["AMPM"]).Trim(), "Trade Detail Error", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    sMessage = Convert.ToString(oRec1["WorkingEmployee"]).Trim() + " is working for " + Convert.ToString(oRec1["ScheduledEmployee"]).Trim() + " on " + Convert.ToString(oRec["schedule_date"]).Trim() + " " + Convert.ToString(oRec["AMPM"]).Trim() + "." + ("\r") + ("\n") + "Cancel Trade to Schedule Leave";
                                    Shared.ViewManager.ShowMessage(sMessage, "Trade Detail", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            //Leave is scheduled...
                            LeaveDate = Convert.ToString(oRec["ShiftStart"]).Trim();
                            //If scheduled leave is not the same as that being scheduled...
                            if (Clean(oRec["leave_time"]) != Shared.gLeaveType)
                            {
                                //If it is not a TRD...
                                if (Clean(oRec["TimeType"]) != "TRD")
                                {
                                    sMessage = Clean(oRec["TimeType"]) + " is already scheduled for " + Convert.ToString(oRec["schedule_date"]).Trim() +
                                                " " + Convert.ToString(oRec["AMPM"]).Trim() + ("\r") + ("\n") + "Do you want to replace with " + Shared.gLeaveType + "?";
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared.ViewManager.ShowMessage(sMessage, "Replace Leave ?", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, System.Int32>(tempNormalized3 => (int)tempNormalized3);
                                    async2.Append<System.Int32>(tempNormalized4 =>
                                    {
                                        Response = tempNormalized4;
                                    });
                                    if (Response != ((int)UpgradeHelpers.Helpers.DialogResult.Cancel))
                                    {
                                        //ADD PAYROLL LOGIC HERE
                                        System
                                            .DateTime TempDate = DateTime.FromOADate(0);
                                        if (~modPTSPayroll.CheckPayrollForLeaveDelete(Empid, (DateTime.TryParse(LeaveDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : LeaveDate, Shared.gLeaveType) != 0)
                                        {
                                            sMessage = "Ooops!! Payroll may have been Uploaded.  Delete payroll record first.  If you " + "experience any problems, please call Debra Lewandowsky x5068... Thanks";
                                            Shared.ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        }
                                        else
                                        {
                                            //Delete Leave Record and Schedule Leave
                                            oCmdDelete.CommandText = "spDeleteLeave '" + Empid + "','" + LeaveDate + "'";
                                            orec2 = ADORecordSetHelper.Open(oCmdDelete, "");
                                            async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => ScheduleLeave(Empid, LeaveDate));
                                            async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized6 =>
                                            {
                                                var returningMetodValue116 = tempNormalized6;
                                            
                                                Response = returningMetodValue116.returnValue;
                                                Empid = returningMetodValue116.Empid;
                                                LeaveDate = returningMetodValue116.LeaveDate;
                                                if (Response != 0)
                                                {
                                                }
                                                else
                                                {
                                                    sMessage = "Ooops!! Insert " + Shared.gLeaveType + " for " + Convert.ToString(oRec["schedule_date"]).Trim() + " " + Convert.ToString(oRec["AMPM"]).Trim() + " didn't work !!";
                                                    Shared.ViewManager.ShowMessage(sMessage, "Insert Leave Error", UpgradeHelpers.Helpers.BoxButtons.OK);
                                                }
                                            });
                                        }
                                    }
                                }
                                else
                                {
                                    oCmd.CommandText = "sp_GetTradeRecord '" + Empid + "','" + LeaveDate + "'";
                                    oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                    if (oRec1.EOF)
                                    {
                                        Shared.ViewManager.ShowMessage("Ooops!!  Problem Retrieving the TRD for " + Convert.ToString(oRec["schedule_date"]).Trim()
                                            + " " + Convert.ToString(oRec["AMPM"]).Trim(), "Trade Detail Error", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        sMessage = Convert.ToString(oRec1["WorkingEmployee"]).Trim() + " is working for " + Convert.ToString(oRec1["ScheduledEmployee"]).Trim() + " on " + Convert.ToString(oRec["schedule_date"]).Trim() + " " + Convert.ToString(oRec["AMPM"]).Trim() + "." + ("\r") + ("\n") + "Cancel Trade to Schedule Leave";
                                        Shared.ViewManager.ShowMessage(sMessage, "Trade Detail", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                }
                            }
                        }
                        async2.Append(() =>
                        {

                            oRec.MoveNext();
                        });
                    }
                });
                async1.Append(() =>
                {

                    ;
                    Shared.
                        gExtendLeave = 0;
                    RefreshActiveForm();
                });
                return Shared.Return<ExtendLeaveStruct>(() => new PTSProject.modGlobal.ExtendLeaveStruct() { returnValue = 0, Empid = Empid, });
            }
        }
        public static ScheduleLeaveStruct ScheduleLeave(string Empid, string LeaveDate)
        {
            using (var async1 = Shared.Async<ScheduleLeaveStruct>(true))
            {
                //********************************************************
                //ScheduleLeave function returns:
                //True if leave scheduled
                //False if leave request canceled
                //-----------------------------------------
                //Schedule requested leave
                //Test to determine if Leave already scheduled for this date
                //Test to determine if Leave has been payrolled for this date
                //Test to determine if Employee is scheduled to work on this date
                //Test to determine if Max amount of employees on leave for
                //this date has been exceded
                //Test to determine if individual will exceed Max amount of
                //requested type of leave
                //Add new leave record
                //ADODB
                //********************************************************
                int result = 0;
                string ShiftDate = "", AType = "";
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                float TotalVac = 0;
                string BeginDate = "", EndDate = "";
                float RegCount = 0;
                string EmpPos = "";
                System.DateTime TestDate = DateTime.FromOADate(0);
                System.DateTime TodaysDate = DateTime.FromOADate(0);
                int BankOpen = 0;
                byte VBankFlag = 0;
                int FourtyHourPosition = 0;
                DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                DbCommand oCmdInsert = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
                ADORecordSetHelper oRec1 = null;
                ADORecordSetHelper orec2 = null;
                float TotHolOverride = 0;
                string sMessage = "";
                string JobCode = "";
                int Step = 0;
                bool bUseNewMILMAX = false;
                System.DateTime TempDate = DateTime.FromOADate(0);
                System.DateTime newEffectiveDate = DateTime.Parse((DateTime.TryParse("6/12/2008", out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "6/12/2008");
                try
                {
                    {
                        result = -1;
                        TotHolOverride = 0;
                        System.DateTime TempDate2 = DateTime.FromOADate(0);
                        TestDate = DateTime.Parse((DateTime.TryParse(LeaveDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : LeaveDate);
                        TodaysDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
                        FourtyHourPosition = 0;
                        bUseNewMILMAX = false;
                        // MODIFY MIL LOGIC HERE ~ DKL May 2008
                        if (DateTime.Parse(LeaveDate).Year >= 2008)
                        {
                            if (DateTime.Parse(LeaveDate) >= newEffectiveDate)
                            {
                                bUseNewMILMAX = true;
                            }
                        }

                        if (Shared.gSCKFlag != 1)
                        {
                            Shared.
                                gSCKFlag = 0;
                        }

                        //ADODB
                        oCmd.Connection = oConn;
                        oCmd.CommandType = CommandType.Text;
                        oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + LeaveDate + "' ";
                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                        if (!oRec1.EOF)
                        {
                            //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                            Shared.
                                gMAXLEAVE = Convert.ToInt32(GetVal(oRec1["max_leave_allowed"]));
                        }
                        else
                        {
                            Shared.
                                gMAXLEAVE = 10;
                        }

                        //Determine employees assignment type
                        oCmd.CommandText = "sp_GetAssType '" + Empid + "'";
                        oCmd.CommandType = CommandType.Text;
                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                        AType = Clean(oRec1["assignment_type_code"]).Trim();
                        EmpPos = Clean(oRec1["position_code"]).Trim();
                        FourtyHourPosition = Convert.ToInt32(oRec1["fourty_hour_flag"]);
                        //Determine if Employee is already scheduled for Leave on this date
                        BeginDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(LeaveDate).AddHours(-1));
                        EndDate = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(BeginDate).AddHours(12));
                        oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + Empid + "', '" + Shared.gCurrentYear.ToString() + "'";
                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                        if (!oRec1.EOF)
                        {
                            TotHolOverride = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(oRec1["holiday_max"], "##.0"));
                        }

                        oCmd.CommandText = "sp_GetEmpLeave '" + Empid + "', '" + BeginDate + "', '" + EndDate + "'";
                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                        if (!oRec1.EOF)
                        {
                            if (Clean(Clean(oRec1["time_code_id"])) == "TRD")
                            {
                                Shared.ViewManager.ShowMessage("Employee has Traded this date, Cancel Trade to Schedule Leave on " + LeaveDate, "Individual Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                Shared.ViewManager.ShowMessage("Employee is already scheduled for Leave on this date - " + LeaveDate, "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }

                            return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                        }

                        //Determine if Employee is scheduled to work on this date
                        oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + LeaveDate + "'";
                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                        if (oRec1.EOF)
                        {
                            async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared.
                                    ViewManager.ShowMessage("Requested Leave Date (" + LeaveDate + ") is not scheduled as a Work Day." + "Proceed anyway?", "Schedule Leave"
                            , UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                            async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                            async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                            {
                                Response = tempNormalized1;
                            });
                            async1.Append<ScheduleLeaveStruct>(() =>
                            {
                                if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                {
                                    return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                }
                                return Shared.Continue<ScheduleLeaveStruct>();
                            });
                        }
                        else
                        {
                            //Check if employee has a pay upgrade...
                            if (Convert.ToBoolean(oRec1["pay_upgrade"]))
                            {
                                async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared
                                        .ViewManager.ShowMessage("Employee is scheduled for PayUpgrade on " + LeaveDate + ".  Do you want to keep it?", "Pay Upgrade", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
                                async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
                                {
                                    Response = tempNormalized3;
                                });
                                async1.Append(() =>
                                {
                                    if (Response == UpgradeHelpers.Helpers.DialogResult.No)
                                    {
                                        //Get current Job Code & Step
                                        JobCode = GetJobCode(Empid);
                                        Step = Convert.ToInt32(Double.Parse(GetStep(Empid)));
                                        oCmdUpdate.Connection = oConn;
                                        oCmdUpdate.CommandType = CommandType.StoredProcedure;
                                        oCmdUpdate.CommandText = "spUpdateSchedulePay"; 
                                        oCmdUpdate.ExecuteNonQuery(new object[] { Empid, LeaveDate, 0, JobCode, Step, DateTime.Now, Shared.gUser });
                                    }
                                });
                            }
                        }

                        if (AType != "")
                        {
                            oCmd.CommandText = "spSelect_WorkingStaffCountByTypeShiftStart '" + LeaveDate + "' ,'" + AType + "' ";
                            oRec1 = ADORecordSetHelper.Open(oCmd, "");
                            if (!oRec1.EOF)
                            {
                                if (Conversion.Val(GetVal(oRec1["off_count"])) > Conversion.Val(GetVal(oRec1["min_staff"])))
                                {
                                    //continue
                                }
                                else
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared.ViewManager.ShowMessage
                                            (AType + " Staffing is currently = " + Clean(oRec1["off_count"]) + ".  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
                                    {
                                        Response = tempNormalized5;
                                    });
                                    async1.Append<ScheduleLeaveStruct>(() =>
                                    {
                                        if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                        {
                                            return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                        }
                                        return Shared.Continue<ScheduleLeaveStruct>();
                                    });
                                }
                            }
                        }
                        async1.Append<ScheduleLeaveStruct>(() =>
                        {
                            using (var async2 = Shared.Async())
                            {

                                //Determine if Kelly Day selected for non Communications Staff
                                if ((Shared.gLeaveType == "KEL" || Shared.gLeaveType == "KLI") && AType != "FCC")
                                {
                                    Shared.ViewManager.ShowMessage("You can only schedule Kelly Days for Communications Staff", "Schedule Kelly Day Error", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                }

                                //Determine if Max number of employees schedule for leave
                                //on this date will be exceded
                                if (Shared.gLeaveType == "VAC" || Shared.gLeaveType == "PTO" || Shared.gLeaveType == "FHL" ||
                                        Shared.gLeaveType == "MIL" || Shared.gLeaveType == "VACFML" || Shared.gLeaveType == "FHLFML" || Shared.gLeaveType == "PTOFML")
                                {
                                    oCmd.CommandText = "sp_GetLeaveCounts '" + AType + "', '" + LeaveDate + "'";
                                    oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                    if (!oRec1.EOF)
                                    {
                                        if (AType == "REG")
                                        {
                                            RegCount = Convert.ToSingle(oRec1["total_leave"]);
                                            if (RegCount >= Shared.gMAXLEAVE)
                                            {
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared.ViewManager
                                                        .ShowMessage(RegCount.ToString() + " Employees scheduled for Leave on " + LeaveDate + ".  Proceed anyway?"
                                                , "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized6 => tempNormalized6);
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized7 =>
                                                {
                                                    Response = tempNormalized7;
                                                });
                                                async2.Append<ScheduleLeaveStruct>(() =>
                                                {
                                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                    {
                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                    }
                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                });
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDouble(oRec1["total_leave"]) >= MAXLEAVEX)
                                            {
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => Shared.ViewManager.ShowMessage
                                                        (Convert.ToString(oRec1["total_leave"]) + " Employees scheduled for Leave on " + LeaveDate
                                                        + ".  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized8 => tempNormalized8);
                                                async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized9 =>
                                                {
                                                    Response = tempNormalized9;
                                                });
                                                async2.Append<ScheduleLeaveStruct>(() =>
                                                {
                                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                    {
                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                    }
                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                });
                                            }
                                        }
                                    }
                                }
                                async2.Append(() =>
                                {
                                    using (var async3 = Shared.Async())
                                    {

                                        //This section checks to determine if Employee is about to
                                        //Exceed individual max allowed leave for requested leave type
                                        BeginDate = "1/1/" + Shared.gCurrentYear.ToString();
                                        EndDate = DateTime.Parse(BeginDate).AddYears(1).ToString("M/d/yyyy");
                                        oCmd.CommandText = "sp_GetLeaveTotals";
                                        oCmd.CommandType = CommandType.StoredProcedure;
                                        {
                                            oCmd.ExecuteNonQuery(new object[] { Empid, BeginDate, EndDate, Shared.gLeaveType });
                                        }

                                        //UPGRADE_WARNING: (2081) Array has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                                        oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                        if (!oRec1.EOF)
                                        {
                                            if ((((Shared.gLeaveType == "VAC" || Shared.gLeaveType == "VACFML") ? -1 : 0) & ~Shared.gVacBank) != 0)
                                            {
                                                oCmd.CommandText = "spVacationEarned '" + Empid + "', '1/1/" + Shared.gCurrentYear.ToString() + "'";
                                                oCmd.CommandType = CommandType.Text;
                                                orec2 = ADORecordSetHelper.Open(oCmd, "");
                                                if (AType == "FCC")
                                                {
                                                    TotalVac = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format((Convert.ToDouble(orec2["leave_allowed"]) / 3) * 2, "##.0"));
                                                }
                                                else
                                                {
                                                    TotalVac = Single.Parse(UpgradeHelpers.Helpers.StringsHelper.Format(orec2["leave_allowed"], "##.0"));
                                                }

                                                if (!Shared.GivingUpShift)
                                                {
                                                    if (TotalVac <= Convert.ToDouble(oRec1["scheduled_leave"]))
                                                    {
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Vacation" +
                                                                    "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized10 => tempNormalized10);
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized11 =>
                                                        {
                                                            Response = tempNormalized11;
                                                        });
                                                        async3.Append<ScheduleLeaveStruct>(() =>
                                                        {
                                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                            {
                                                                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                            }
                                                            return Shared.Continue<ScheduleLeaveStruct>();
                                                        });
                                                    }
                                                    else if (TotalVac - Convert.ToDouble(oRec1["scheduled_leave"]) < 1)
                                                    {
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Vacation" +
                                                                    "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized12 => tempNormalized12);
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized13 =>
                                                        {
                                                            Response = tempNormalized13;
                                                        });
                                                        async3.Append<ScheduleLeaveStruct>(() =>
                                                        {
                                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                            {
                                                                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                            }
                                                            return Shared.Continue<ScheduleLeaveStruct>();
                                                        });
                                                    }
                                                }
                                            }
                                            else if ((((Shared.gLeaveType == "VAC" || Shared.gLeaveType == "VACFML") ? -1 : 0) & Shared.gVacBank) != 0)
                                            {
                                                if (TestDate > TodaysDate)
                                                {
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                            => Shared.ViewManager.ShowMessage("Policy does not allow for future scheduling of Banked Vacation. " + "Proceed anyway?"
                                                                , "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized14 => tempNormalized14);
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized15 =>
                                                    {
                                                        Response = tempNormalized15;
                                                    });
                                                    async3.Append<ScheduleLeaveStruct>(() =>
                                                    {
                                                        if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                        {
                                                            return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                        }
                                                        return Shared.Continue<ScheduleLeaveStruct>();
                                                    });
                                                }
                                                async3.Append<ScheduleLeaveStruct>(() =>
                                                {
                                                    using (var async4 = Shared.Async<ScheduleLeaveStruct>())
                                                    {

                                                        oCmd.CommandText = "sp_GetVacBalance '" + Empid + "'";
                                                        oCmd.CommandType = CommandType.Text;
                                                        orec2 = ADORecordSetHelper.Open(oCmd, "");
                                                        if (!orec2.EOF)
                                                        {
                                                            BankOpen = Convert.ToInt32(orec2["vacation_balance"]);
                                                        }
                                                        else
                                                        {
                                                            //Somehow a Vacation Bank was scheduled without a
                                                            //Vacation_Balance record for this employee
                                                            //Theoretically this should NEVER happen
                                                            //- Display error message -
                                                            Shared.ViewManager.ShowMessage(
                                                                "Serious Database Error - No Vacation Balance Record exists for this employee! Please Report to System Admin at once!", "Delete Leave Error",
                                                                UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                            return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = result, Empid = Empid, LeaveDate = LeaveDate, });
                                                        }

                                                        if (BankOpen < 1)
                                                        {
                                                            async4.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
                                                                    Shared.ViewManager.ShowMessage("Employee does not have any Banked Vacation Available " + "Proceed anyway?",
                                                                        "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                            async4.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized16 => tempNormalized16);
                                                            async4.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized17 =>
                                                            {
                                                                Response = tempNormalized17;
                                                            });
                                                            async4.Append<ScheduleLeaveStruct>(() =>
                                                            {
                                                                if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                                {
                                                                    return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                                }
                                                                return Shared.Continue<ScheduleLeaveStruct>();
                                                            });
                                                        }
                                                    }
                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                });
                                            }
                                            else if (Shared.gLeaveType == "FHL" || Shared.gLeaveType == "FHLFML")
                                            {
                                                if (!Shared.GivingUpShift)
                                                {
                                                    if (TotHolOverride != 0)
                                                    {
                                                        if (TotHolOverride <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                        {
                                                            async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                    => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Holiday" +
                                                                        "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                            async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized18 => tempNormalized18);
                                                            async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized19 =>
                                                            {
                                                                Response = tempNormalized19;
                                                            });
                                                            async3.Append<ScheduleLeaveStruct>(() =>
                                                            {
                                                                if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                                {
                                                                    return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                                }
                                                                return Shared.Continue<ScheduleLeaveStruct>();
                                                            });
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (AType == "REG" || AType == "FCC" || AType == "MRN")
                                                        {
                                                            if (MAXHOLREG <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                            {
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                        => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Holiday" +
                                                                            "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized20 => tempNormalized20);
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized21 =>
                                                                {
                                                                    Response = tempNormalized21;
                                                                });
                                                                async3.Append<ScheduleLeaveStruct>(() =>
                                                                {
                                                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                                    {
                                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                                    }
                                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                                });
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (MAXHOLX <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                            {
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                        => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Holiday" +
                                                                            "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized22 => tempNormalized22);
                                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized23 =>
                                                                {
                                                                    Response = tempNormalized23;
                                                                });
                                                                async3.Append<ScheduleLeaveStruct>(() =>
                                                                {
                                                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                                    {
                                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                                    }
                                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                                });
                                                            }
                                                        }
                                                    }
                                                }
                                                // MODIFY MIL LOGIC HERE ~ DKL May 2008
                                            }
                                            else if (Shared.gLeaveType == "MIL" && FourtyHourPosition == (0))
                                            {
                                                if (bUseNewMILMAX)
                                                {
                                                    if (newMAXMIL <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                    {
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Military" +
                                                                    "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized24 => tempNormalized24);
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized25 =>
                                                        {
                                                            Response = tempNormalized25;
                                                        });
                                                        async3.Append<ScheduleLeaveStruct>(() =>
                                                        {
                                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                            {
                                                                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                            }
                                                            return Shared.Continue<ScheduleLeaveStruct>();
                                                        });
                                                    }
                                                }
                                                else
                                                {
                                                    if (MAXMIL <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                    {
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                                => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Military" +
                                                                    "Leave of this Employee.  Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized26 => tempNormalized26);
                                                        async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized27 =>
                                                        {
                                                            Response = tempNormalized27;
                                                        });
                                                        async3.Append<ScheduleLeaveStruct>(() =>
                                                        {
                                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                            {
                                                                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                            }
                                                            return Shared.Continue<ScheduleLeaveStruct>();
                                                        });
                                                    }
                                                }
                                            }
                                            else if (Shared.gLeaveType == "KEL" || Shared.gLeaveType == "KLI")
                                            {
                                                if (MAXKEL <= Convert.ToDouble(oRec1["scheduled_leave"]) / 2)
                                                {
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                            => Shared.ViewManager.ShowMessage("You will be exceeding the Authorized Kelly Day" +
                                                                " Leave of this Employee. Proceed anyway?", "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized28 => tempNormalized28);
                                                    async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized29 =>
                                                    {
                                                        Response = tempNormalized29;
                                                    });
                                                    async3.Append<ScheduleLeaveStruct>(() =>
                                                    {
                                                        if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                        {
                                                            return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                        }
                                                        return Shared.Continue<ScheduleLeaveStruct>();
                                                    });
                                                }
                                            }
                                        }
                                        else if ((((Shared.gLeaveType == "VAC" || Shared.gLeaveType == "VACFML") ? -1 : 0) & Shared.gVacBank) != 0)
                                        {
                                            if (TestDate > TodaysDate)
                                            {
                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                                        => Shared.ViewManager.ShowMessage("Policy does not allow for future scheduling of Banked Vacation. " + "Proceed anyway?"
                                                            , "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                async3.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized30 => tempNormalized30);
                                                async3.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized31 =>
                                                {
                                                    Response = tempNormalized31;
                                                });
                                                async3.Append<ScheduleLeaveStruct>(() =>
                                                {
                                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                    {
                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                    }
                                                    return Shared.Continue<ScheduleLeaveStruct>();
                                                });
                                            }
                                            async3.Append<ScheduleLeaveStruct>(() =>
                                            {
                                                using (var async5 = Shared.Async<ScheduleLeaveStruct>())
                                                {

                                                    oCmd.CommandText = "sp_GetVacBalance '" + Empid + "'";
                                                    oCmd.CommandType = CommandType.Text;
                                                    orec2 = ADORecordSetHelper.Open(oCmd, "");
                                                    if (!orec2.EOF)
                                                    {
                                                        BankOpen = Convert.ToInt32(orec2["vacation_balance"]);
                                                    }
                                                    else
                                                    {
                                                        //Somehow a Vacation Bank was scheduled without a
                                                        //Vacation_Balance record for this employee
                                                        //Theoretically this should NEVER happen
                                                        //- Display error message -
                                                        Shared.ViewManager.ShowMessage(
                                                            "Serious Database Error - No Vacation Balance Record exists for this employee! Please Report to System Admin at once!", "Delete Leave Error", UpgradeHelpers
                                                            .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = result, Empid = Empid, LeaveDate = LeaveDate, });
                                                    }

                                                    if (BankOpen < 1)
                                                    {
                                                        async5.Append<UpgradeHelpers.Helpers.DialogResult>(() =>
                                                                Shared.ViewManager.ShowMessage("Employee does not have any Banked Vacation Available " + "Proceed anyway?",
                                                                    "Schedule Leave", UpgradeHelpers.Helpers.BoxButtons.OKCancel));
                                                        async5.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized32 => tempNormalized32);
                                                        async5.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized33 =>
                                                        {
                                                            Response = tempNormalized33;
                                                        });
                                                        async5.Append<ScheduleLeaveStruct>(() =>
                                                        {
                                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
                                                            {
                                                                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = 0, Empid = Empid, LeaveDate = LeaveDate, });
                                                            }
                                                            return Shared.Continue<ScheduleLeaveStruct>();
                                                        });
                                                    }
                                                }
                                                return Shared.Continue<ScheduleLeaveStruct>();
                                            });
                                        }
                                        async3.Append(() =>
                                        {

                                            //Add new leave record
                                            if (Shared.gVacBank != 0)
                                            {
                                                VBankFlag = 1;
                                            }
                                            else
                                            {
                                                VBankFlag = 0;
                                            }

                                            ShiftDate = UpgradeHelpers.Helpers.StringsHelper.Format(DateTime.Now, "m/d/yyyy h:nnAM/PM");
                                            oCmdInsert.Connection = oConn;
                                            oCmdInsert.CommandText = "spInsertLeave";
                                            oCmdInsert.CommandType = CommandType.StoredProcedure;
                                            oCmdInsert.ExecuteNonQuery(new object[] { Empid, LeaveDate, Shared.gLeaveType, ShiftDate, Shared.gUser, VBankFlag, Shared.gSCKFlag });

                                            //    'Adjust Vacation Bank if needed
                                            //    If gVacBank Then
                                            //        BankOpen = BankOpen - 1
                                            //        ocmd.CommandText = "spUpdateVacBalance '" & Empid & "', " & BankOpen
                                            //        ocmd.CommandType = adCmdText
                                            //        ocmd.Execute
                                            //        gVacBank = False
                                            //    End If
                                            //Insert Personnel Schedule Note if needed
                                            if (Shared.gLeaveNotes != "")
                                            {
                                                oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + Empid + "','" + LeaveDate + "','" + Shared.gLeaveNotes + "','" + Shared.gUser + "' ";
                                                oCmd.CommandType = CommandType.Text;
                                                oCmd.ExecuteNonQuery();
                                                Shared.
                                                    gLeaveNotes = "";
                                            }

                                            //Update VacationRequests if needed
                                            int RequestID = 0;
                                            string GiveUpDate = "";
                                            int AssignID = 0;
                                            string SqlString = "";
                                            oCmd.CommandText = "spSelect_VacationRequestByEmployeeDate '" + Empid + "', '" + LeaveDate + "' ";
                                            oCmd.CommandType = CommandType.Text;
                                            oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                            if (!oRec1.EOF)
                                            {
                                                RequestID = Convert.ToInt32(oRec1["request_id"]);
                                                GiveUpDate = Clean(oRec1["giveup_shift_start"]);
                                                oCmd.CommandText = "spUpdateVacationRequestGrantedInfo " + RequestID.ToString() + " ,'" + Shared.gUser + "','" + ShiftDate + "' ";
                                                oCmd.CommandType = CommandType.Text;
                                                oCmd.ExecuteNonQuery();
                                                if (GiveUpDate != "")
                                                {
                                                    //*******************************
                                                    oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "', '" + GiveUpDate + "'";
                                                    oRec1 = ADORecordSetHelper.Open(oCmd, "");
                                                    if (!oRec1.EOF)
                                                    {
                                                        AssignID = Convert.ToInt32(oRec1["assignment_id"]);
                                                        if (DuplicateAssignment(Empid, AssignID, GiveUpDate))
                                                        {
                                                            if (Clean(oRec1["time_code_id"]) == "DDF" || Clean(oRec1["time_code_id"]) == "UDD")
                                                            {
                                                                if (Convert.ToString(oRec1["battalion_code"]) == "2")
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN182DBT.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                                else if (Convert.ToString(oRec1["battalion_code"]) == "3")
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN183DBT.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                                else
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN181DBT.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToString(oRec1["battalion_code"]) == "2")
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN182ROV.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                                else if (Convert.ToString(oRec1["battalion_code"]) == "3")
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN183ROV.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                                else
                                                                {
                                                                    SqlString = "spUpdateScheduleAssign '" + Empid + "','" + GiveUpDate + "'," + ASGN181ROV.ToString() + ",'";
                                                                    SqlString = SqlString + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + Shared.gUser + "'";
                                                                    oCmd.CommandText = SqlString;
                                                                    oCmd.ExecuteNonQuery();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    //*******************************
                                                    //ADD PAYROLL LOGIC HERE
                                                    System
                                                                        .DateTime TempDate3 = DateTime.FromOADate(0);
                                                    if (~modPTSPayroll.CheckPayrollForLeaveDelete(Empid, (DateTime.TryParse(GiveUpDate, out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : GiveUpDate, Shared.gLeaveType) != 0)
                                                    {
                                                        sMessage = "Ooops!! Payroll may have been Uploaded.  Delete payroll record first.  If you " + "experience any problems, please call Debra Lewandowsky x5068... Thanks";
                                                        Shared.ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);
                                                    }
                                                    else
                                                    {
                                                        if (Shared.gLeaveType == "VAC" || Shared.gLeaveType == "FHL" || Shared.gLeaveType == "VACFML" || Shared.gLeaveType == "FHLFML")
                                                        {
                                                            oCmd.CommandText = "spDeleteLeave '" + Empid + "','" + GiveUpDate + "'";
                                                            oCmd.CommandType = CommandType.Text;
                                                            oCmd.ExecuteNonQuery();
                                                        }
                                                    }
                                                }
                                            }
                                        });
                                    }
                                });
                            }
                            return Shared.Continue<ScheduleLeaveStruct>();
                        });
                    }
                }
                catch
                {
                    if (ErrorControl() == eFATALERROR)
                    {
                        return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = result, Empid = Empid, LeaveDate = LeaveDate, });
                    }
                }

                return Shared.Return<ScheduleLeaveStruct>(() => new PTSProject.modGlobal.ScheduleLeaveStruct() { returnValue = result, Empid = Empid, LeaveDate = LeaveDate, });
            }
        }
        public static string GetJobCode(string Empid)
        {
            //********************************************************
            // Returns Employee's Job Code from Personnel Table
            //********************************************************
            string result = "";
            DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

            oCmd.Connection = oConn;
            oCmd.CommandType = CommandType.Text;
            oCmd.CommandText = "sp_GetJobCode '" + Empid + "'";
            ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
            result = Convert.ToString(oRec["job_code_id"]).Trim();
            Shared.
                gFourtyHourJobCode = Convert.ToInt32(oRec["fourty_hour_flag"]);
            return result;

        }

        public static string GetStep(string Empid)
        {
            //********************************************************
            //Returns Employee's Job Step from Personnel Table
            //********************************************************
            DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

            oCmd.Connection = oConn;
            oCmd.CommandType = CommandType.Text;
            oCmd.CommandText = "sp_GetJobCode '" + Empid + "'";
            ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
            return Convert.ToString(oRec["step"]).Trim();

        }

        public static string ProofSQLString(string sString)
        {
            //********************************************************
            //Replaces one single quote with 2 single quotes from string values
            //That will be sent to SqlServer
            //********************************************************

            string WorkString = Strings.Replace(sString, "'", "''", 1, -1, CompareMethod.Binary);
            return WorkString;

        }

        internal static int ViewScheduleDetail(string Empid, string EmpName, string LeaveDate)
        {
            using (var async1 = Shared.Async<int>(true))
            {
                //    Dim oCmd As New ADODB.Command
                //    Dim oRec As ADODB.Recordset
                //    Dim sMessage As String

                //    oCmd.ActiveConnection = oConn
                //    oCmd.CommandType = adCmdText

                System
                    .DateTime TempDate = DateTime.FromOADate(0);
                Shared.
                    gStartTrans = (DateTime.TryParse(LeaveDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : LeaveDate;
                Shared.
                    gEndTrans = DateTime.Parse(Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
                Shared.
                    gEmployeeId = Empid;
                Shared.
                    gEmployeeName = EmpName;
                async1.Append(() =>
                {
                    Shared.ViewManager.NavigateToView(

                        dlgScheduleDetail.DefInstance, true);
                });


                //    oCmd.CommandText = "sp_GetIndLeaveSchedDetail '" & EmpID & "','" & gStartTrans & "','" & gEndTrans & "'"
                //    Set oRec = oCmd.Execute
                //    sMessage = ""
                //
                //    Do Until oRec.EOF
                //        sMessage = sMessage & (Chr(13)) & (Chr(10)) _
                //'                & "The " & Trim$(oRec("AMPM"]) & " schedule for " & EmpName _
                //'                & " was last updated on " _
                //'                & Trim$(oRec("ScheduleUpdateDate"]) & " by " _
                //'                & Trim$(oRec("UpdatedbyName"])
                //        sMessage = sMessage & (Chr(13)) & (Chr(10))
                //        oRec.MoveNext
                //    Loop
                //
                //    MsgBox sMessage, vbOKOnly, "Employee Schedule Detail"


                return
                Shared.Return<int>(() => 0);
            }
        }

        internal static int ViewLeaveDetail(string Empid, string EmpName, string LeaveDate)
        {
            using (var async1 = Shared.Async<int>(true))
            {
                //    Dim oCmd As New ADODB.Command
                //    Dim oRec As ADODB.Recordset
                //    Dim sMessage As String
                //
                //    oCmd.ActiveConnection = oConn
                //    oCmd.CommandType = adCmdText

                System
                    .DateTime TempDate = DateTime.FromOADate(0);
                Shared.
                    gStartTrans = (DateTime.TryParse(LeaveDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : LeaveDate;
                Shared.
                    gEndTrans = DateTime.Parse(Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
                Shared.
                    gEmployeeId = Empid;
                Shared.
                    gEmployeeName = EmpName;
                async1.Append(() =>
                {
                    Shared.ViewManager.NavigateToView(

                        dlgScheduleDetail.DefInstance, true);
                });

                //    gStartTrans = Format$(LeaveDate, "m/d/yyyy") & " 7:00AM"
                //    gEndTrans = Format$(DateAdd("d", 1, gStartTrans), "m/d/yyyy")

                //    oCmd.CommandText = "sp_GetIndLeaveSchedDetail '" & EmpID & "','" & gStartTrans & "','" & gEndTrans & "'"
                //    Set oRec = oCmd.Execute
                //    sMessage = ""
                //
                //    Do Until oRec.EOF
                //        sMessage = sMessage & (Chr(13)) & (Chr(10)) _
                //'                & Clean(oRec("AMPM"]) & " " & Clean(oRec("TimeType"]) _
                //'                & " Leave for " & EmpName & " was created on " _
                //'                & Clean(oRec("LeaveCreateDate"]) & " by " _
                //'                & Clean(oRec("CreatedbyName"]) & " and last updated on " _
                //'                & Clean(oRec("LeaveUpdateDate"]) & " by " _
                //'                & Clean(oRec("UpdatedbyName"])
                //        sMessage = sMessage & (Chr(13)) & (Chr(10))
                //        oRec.MoveNext
                //    Loop
                //
                //    MsgBox sMessage, vbOKOnly, "Employee Leave Detail"
                return
                Shared.Return<int>(() => 0);
            }
        }

        internal static bool DuplicateAssignment(string Empid, int AssignID, string ThisShift)
        {
            //Check for more than one person scheduled for this date
            //ADODB
            bool result = false;
            DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
            ADORecordSetHelper oRec = null;

            //Check for Assignments that allow duplicates

            try
            {
                result = true;

                oCmd.Connection = oConn;
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandText = "sp_FindUnit " + AssignID.ToString();
                oRec = ADORecordSetHelper.Open(oCmd, "");
                switch (Convert.ToString(oRec["unit_code"]).Trim())
                {
                    case "OPER":
                        return false;
                    case "BC01":
                        if (Convert.ToString(oRec["position_code"]).Trim() == "DBT181")
                        {
                            return false;
                        }
                        else if (Convert.ToString(oRec["position_code"]).Trim() == "ROV181")
                        {
                            return false;
                        }
                        break;
                    case "BC02":
                        if (Convert.ToString(oRec["position_code"]).Trim() == "DBT182")
                        {
                            return false;
                        }
                        else if (Convert.ToString(oRec["position_code"]).Trim() == "ROV182")
                        {
                            return false;
                        }
                        break;
                    default:
                        result = true;
                        break;
                }

                oCmd.CommandText = "sp_FindDuplicateSched " + AssignID.ToString() + ",'" + ThisShift + "', '" + Empid + "'";
                oRec = ADORecordSetHelper.Open(oCmd, "");
                if (oRec.EOF)
                {
                    result = false;
                }
            }
            catch
            {

                if (ErrorControl() == eFATALERROR)
                {
                    return result;
                }
            }

            return result;
        }
        public struct ExtendLeaveStruct
        {
            public int returnValue;
            public string Empid;
        }
        public struct ScheduleLeaveStruct
        {
            public int returnValue;
            public string Empid;
            public string LeaveDate;
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
                REQUIRED = UpgradeHelpers.Helpers.Color.FromArgb(128, 128, 255);
                REQCOLOR = UpgradeHelpers.Helpers.Color.Blue;
                GRAY = UpgradeHelpers.Helpers.Color.Silver;
                WINE = UpgradeHelpers.Helpers.Color.FromArgb(128, 64, 64);
                WHITE = UpgradeHelpers.Helpers.Color.White;
                BLACK = UpgradeHelpers.Helpers.Color.Black;
                YELLOW = UpgradeHelpers.Helpers.Color.FromArgb(255, 255, 128);
                LT_GRAY = UpgradeHelpers.Helpers.Color.FromArgb(224, 224, 224);
                MED_GRAY = UpgradeHelpers.Helpers.Color.Gray;
                PARCHMENT = UpgradeHelpers.Helpers.Color.FromArgb(255, 224, 192);
                RED = UpgradeHelpers.Helpers.Color.Red;
                BLUE = UpgradeHelpers.Helpers.Color.FromArgb(0, 0, 192);
                GREEN = UpgradeHelpers.Helpers.Color.Green;
                MDIProdColor = UpgradeHelpers.Helpers.Color.FromArgb(0, 64, 64);
                MDITestColor = UpgradeHelpers.Helpers.Color.FromArgb(192, 192, 255);
                _oConn = null;
                _oIncident = null;
                gTestMode = 0;
                gUser = "";
                gUserLogon = "";
                gUserBatt = "";
                gSecurity = "";
                gComputer = "";
                gUserType = "";
                gLeaveUpdate = 0;
                gOldEmp = "";
                gOldRov = 0;
                gLeaveType = "";
                gVacBank = 0;
                gSCKFlag = 0;
                gPayType = "";
                gType = "";
                gBatt = "";
                gGoToBatt = "";
                gRBatt = "";
                gRType = "";
                gLType = "";
                gSType = "";
                gFullShift = 0;
                gExtendLeave = 0;
                gNoteDate = "";
                gYearReport = "";
                gReportYear = 0;
                gAssignID = "";
                gEmployeeId = "";
                gEmployeeName = "";
                gCurrentYear = 0;
                gPayrollYear = 0;
                gTransCancel = 0;
                gStartTrans = "";
                gEndTrans = "";
                gShape = null;
                gAltShift = null;
                gTempTrans = 0;
                gDebitDefault = 0;
                UnschedDebit = false;
                gTradeDefault = 0;
                gOTimeDefault = 0;
                gAssignment = 0;
                gReportUser = "";
                gDetailEmp = "";
                gDetailDate = "";
                gTradeEmp = "";
                gUserName = "";
                gPayPeriod = 0;
                gPayRollBatt = "";
                gPayRollShift = "";
                gLeaveNotes = "";
                gFourtyHourJobCode = 0;
                gBattSwitchDate = "";
                gDaysWorking = 0;
                gParamedicSchedule = false;
                gHazmatSchedule = false;
                gFCCSchedule = false;
                gSpecialType = "";
                gMaxhoursOp = 0;
                gMaxhoursFCC = 0;
                gAMShift = false;
                gPMShift = false;
                gSecondaryID = 0;
                gMessageText = "";
                gMAXLEAVE = 0;
                TempSecurity = false;
                GivingUpShift = false;
                BattDateChange = 0;
                gAvailVAC = 0;
                gAvailHOL = 0;
                gUniformID = 0;
                gUniformBatt = "";
                gUniformShift = "";
                gExcelPath = "";
            }

            public virtual UpgradeHelpers.Helpers.Color REQUIRED { get; set; }

            public virtual UpgradeHelpers.Helpers.Color REQCOLOR { get; set; }

            public virtual UpgradeHelpers.Helpers.Color GRAY { get; set; }

            public virtual UpgradeHelpers.Helpers.Color WINE { get; set; }

            public virtual UpgradeHelpers.Helpers.Color WHITE { get; set; }

            public virtual UpgradeHelpers.Helpers.Color BLACK { get; set; }

            public virtual UpgradeHelpers.Helpers.Color YELLOW { get; set; }

            public virtual UpgradeHelpers.Helpers.Color LT_GRAY { get; set; }

            public virtual UpgradeHelpers.Helpers.Color MED_GRAY { get; set; }

            public virtual UpgradeHelpers.Helpers.Color PARCHMENT { get; set; }

            public virtual UpgradeHelpers.Helpers.Color RED { get; set; }

            public virtual UpgradeHelpers.Helpers.Color BLUE { get; set; }

            public virtual UpgradeHelpers.Helpers.Color GREEN { get; set; }

            public virtual UpgradeHelpers.Helpers.Color MDIProdColor { get; set; }

            public virtual UpgradeHelpers.Helpers.Color MDITestColor { get; set; }

            public virtual DbConnection _oConn { get; set; }

            public virtual DbConnection _oIncident { get; set; }

            public virtual int gTestMode { get; set; }

            public virtual string gUser { get; set; }

            public virtual string gUserLogon { get; set; }

            public virtual string gUserBatt { get; set; }

            public virtual string gSecurity { get; set; }

            public virtual string gComputer { get; set; }

            public virtual string gUserType { get; set; }

            public virtual int gLeaveUpdate { get; set; }

            public virtual string gOldEmp { get; set; }

            public virtual int gOldRov { get; set; }

            public virtual string gLeaveType { get; set; }

            public virtual int gVacBank { get; set; }

            public virtual int gSCKFlag { get; set; }

            public virtual string gPayType { get; set; }

            public virtual string gType { get; set; }

            public virtual string gBatt { get; set; }

            public virtual string gGoToBatt { get; set; }

            public virtual string gRBatt { get; set; }

            public virtual string gRType { get; set; }

            public virtual string gLType { get; set; }

            public virtual string gSType { get; set; }

            public virtual int gFullShift { get; set; }

            public virtual int gExtendLeave { get; set; }

            public virtual string gNoteDate { get; set; }

            public virtual string gYearReport { get; set; }

            public virtual int gReportYear { get; set; }

            public virtual string gAssignID { get; set; }

            public virtual string gEmployeeId { get; set; }

            public virtual string gEmployeeName { get; set; }

            public virtual int gCurrentYear { get; set; }

            public virtual int gPayrollYear { get; set; }

            public virtual int gTransCancel { get; set; }

            public virtual string gStartTrans { get; set; }

            public virtual string gEndTrans { get; set; }

            public virtual UpgradeHelpers.Helpers.ControlViewModel gShape { get; set; }

            public virtual UpgradeHelpers.Helpers.ControlViewModel gAltShift { get; set; }

            public virtual int gTempTrans { get; set; }

            public virtual int gDebitDefault { get; set; }

            public virtual bool UnschedDebit { get; set; }

            public virtual int gTradeDefault { get; set; }

            public virtual int gOTimeDefault { get; set; }

            public virtual int gAssignment { get; set; }

            public virtual string gReportUser { get; set; }

            public virtual string gDetailEmp { get; set; }

            public virtual string gDetailDate { get; set; }

            public virtual string gTradeEmp { get; set; }

            public virtual string gUserName { get; set; }

            public virtual int gPayPeriod { get; set; }

            public virtual string gPayRollBatt { get; set; }

            public virtual string gPayRollShift { get; set; }

            public virtual string gLeaveNotes { get; set; }

            public virtual int gFourtyHourJobCode { get; set; }

            public virtual string gBattSwitchDate { get; set; }

            public virtual int gDaysWorking { get; set; }

            public virtual bool gParamedicSchedule { get; set; }

            public virtual bool gHazmatSchedule { get; set; }

            public virtual bool gFCCSchedule { get; set; }

            public virtual string gSpecialType { get; set; }

            public virtual float gMaxhoursOp { get; set; }

            public virtual float gMaxhoursFCC { get; set; }

            public virtual bool gAMShift { get; set; }

            public virtual bool gPMShift { get; set; }

            public virtual int gSecondaryID { get; set; }

            public virtual string gMessageText { get; set; }

            public virtual int gMAXLEAVE { get; set; }

            public virtual bool TempSecurity { get; set; }

            public virtual bool GivingUpShift { get; set; }

            public virtual int BattDateChange { get; set; }

            public virtual float gAvailVAC { get; set; }

            public virtual float gAvailHOL { get; set; }

            public virtual int gUniformID { get; set; }

            public virtual string gUniformBatt { get; set; }

            public virtual string gUniformShift { get; set; }

            public virtual string gExcelPath { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }
    }

}
