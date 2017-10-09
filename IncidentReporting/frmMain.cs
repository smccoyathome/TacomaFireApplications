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


namespace TFDIncident
{

    public partial class frmMain
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmMainViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(frmMain));
            if (Shared.m_vb6FormDefInstance == null)
            {
                if (Shared.m_InitializingDefInstance)
                {
                    Shared.
                        m_vb6FormDefInstance = this;
                }
            }
            ReLoadForm(false);
        }



        private void GetHelpText()
        {
            TFDIncident.clsCommonCodes cCommon = Container.Resolve<clsCommonCodes>();

            if (~cCommon.GetHelpText(IncidentMain.Shared.gHelpScreen, IncidentMain.Shared.gHelpControl) != 0)
            {
                ViewModel.txtHelpTitle.Text = "No Help Topic Found for this Screen";
                ViewModel.txtHelpText.Text = "";
                return;
            }
            ViewModel.txtHelpTitle.Text = IncidentMain.Clean(cCommon.HelpText["help_title"]);
            ViewModel.txtHelpText.Text = IncidentMain.Clean(cCommon.HelpText["help_text"]);
            ViewModel.CurrentHelpID = Convert.ToInt32(cCommon.HelpText["help_id"]);
        }

        private void FillHelpList()
        {
            //Fill Help List Tree View Control
            TFDIncident.clsCommonCodes cCommon = Container.Resolve<clsCommonCodes>();
            int ClassIndex = 0;
            int ScreenIndex = 0;


            if (~cCommon.GetHelpList() != 0)
            {
                ViewModel.tvHelpList.Visible = false;
                return;
            }

            string CurrentClass = "";
            int CurrentScreen = 0;


            while (!cCommon.HelpList.EOF)
            {
                if (IncidentMain.Clean(cCommon.HelpList["class_title"]) != CurrentClass)
                {
                    ViewModel.mNode = ViewModel.tvHelpList.Add("");
                    ViewModel.mNode.Text = Convert.ToString(cCommon.HelpList["class_title"]);
                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                    ViewModel.mNode.Set_Tag("0");
                    ClassIndex = ViewModel.mNode.Index + 1;
                    CurrentClass = IncidentMain.Clean(cCommon.HelpList["class_title"]);
                    if (Convert.ToDouble(cCommon.HelpList["screen_id"]) != CurrentScreen)
                    {
                        ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ClassIndex.ToString(), true)[0].Add("");
                        ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
                        //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                        ViewModel.mNode.Set_Tag(Conversion.Str(cCommon.HelpList["help_id"]));
                        ScreenIndex = ViewModel.mNode.Index + 1;
                        CurrentScreen = Convert.ToInt32(cCommon.HelpList["screen_id"]);
                    }
                    else
                    {
                        ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ScreenIndex.ToString(), true)[0].Add("");
                        ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
                        //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                        ViewModel.mNode.Set_Tag(Conversion.Str(cCommon.HelpList["help_id"]));
                    }
                }
                else
                {
                    if (Convert.ToDouble(cCommon.HelpList["screen_id"]) != CurrentScreen)
                    {
                        ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ClassIndex.ToString(), true)[0].Add("");
                        ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
                        //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                        ViewModel.mNode.Set_Tag(Conversion.Str(cCommon.HelpList["help_id"]));
                        ScreenIndex = ViewModel.mNode.Index + 1;
                        CurrentScreen = Convert.ToInt32(cCommon.HelpList["screen_id"]);
                    }
                    else
                    {
                        ViewModel.mNode = ViewModel.tvHelpList.Items.Find(ScreenIndex.ToString(), true)[0].Add("");
                        ViewModel.mNode.Text = IncidentMain.Clean(cCommon.HelpList["help_title"]);
                        //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                        ViewModel.mNode.Set_Tag(Conversion.Str(cCommon.HelpList["help_id"]));
                    }
                }
                cCommon.HelpList.MoveNext();
            }
            ;

        }

        private void GenerateReport()
        {
            //Used to create precanned reports that generally accept a year as a parameter

        }

        private int FillSysReports()
        {
            //Fill SysSpread and sys combo dependant on Action selection
            //For Report System Actions:
            //Find all Reports for selected Incident Number
            //Fill Sys Combo box with Deletable or Status updatable reports
            //Display Info on all reports in sys spreadsheet
            //For Security Actions:

            int result = 0;
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsNotification NotifyCL = Container.Resolve<clsNotification>();
            string NameString = "";

            //Clear sprSysadm
            ViewModel.sprSysAdm.BlockMode = true;
            ViewModel.sprSysAdm.Row = 1;
            ViewModel.sprSysAdm.Row2 = 400;
            ViewModel.sprSysAdm.Col = 1;
            ViewModel.sprSysAdm.Col2 = 8;
            ViewModel.sprSysAdm.Text = "";
            ViewModel.sprSysAdm.BlockMode = false;
            //Clear sprNotify
            ViewModel.sprNotify.BlockMode = true;
            ViewModel.sprNotify.Col = 1;
            ViewModel.sprNotify.Col2 = 2;
            ViewModel.sprNotify.Row = 2;
            ViewModel.sprNotify.Row2 = 100;
            ViewModel.sprNotify.Text = "";
            ViewModel.sprNotify.BlockMode = false;

            if (ViewModel.cboSystemAction.Text == "Delete Report")
            {
                ViewModel.cboSysAdm1.Items.Clear();
            }
            else if (ViewModel.cboSystemAction.Text == "Reset Report Status" || ViewModel.cboSystemAction.Text == "Change EMS Report Type")
            {
                ViewModel.cboSysAdm2.Items.Clear();
            }
            int CurrRow = 1;
            ViewModel.sprSysAdm.Row = CurrRow;
            ViewModel.sprSysAdm.Col = 1;
            if (ViewModel.cboSystemAction.Text == "View Security Listing")
            {
                ViewModel.sprSysAdm.Text = "Employee";
                ViewModel.sprSysAdm.Col = 2;
                ViewModel.sprSysAdm.Text = "Security Type";
                ViewModel.sprSysAdm.SetColWidth(1, 25);
                ViewModel.sprSysAdm.SetColWidth(2, 20);
            }
            else
            {
                ViewModel.sprSysAdm.Text = "Incident #";
                ViewModel.sprSysAdm.Col = 2;
                ViewModel.sprSysAdm.Text = "Report Type";
                ViewModel.sprSysAdm.Col = 3;
                ViewModel.sprSysAdm.Text = "Report Status";
                ViewModel.sprSysAdm.Col = 4;
                ViewModel.sprSysAdm.Text = "Responsible Unit";
                ViewModel.sprSysAdm.Col = 5;
                ViewModel.sprSysAdm.Text = "Patient/Address";
                ViewModel.sprSysAdm.SetColWidth(1, 11.5f);
                ViewModel.sprSysAdm.SetColWidth(2, 17.2f);
            }
            CurrRow++;
            clsFire FireReport = null;
            switch (ViewModel.cboSystemAction.Text)
            {
                case "Change EMS Report Type":
                    if (ReportLog.GetReportLogSysAdm(ViewModel.txtSysAdm1.Text.Trim()) != 0)
                    {

                        while (!ReportLog.ReportLogRS.EOF)
                        {
                            if (Convert.ToDouble(ReportLog.ReportLogRS["rep_type"]) == IncidentMain.EMSBASIC)
                            {
                                result = -1;
                                ViewModel.sprSysAdm.Row = CurrRow;
                                ViewModel.sprSysAdm.Col = 1;
                                ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["incident_number"]);
                                ViewModel.sprSysAdm.Col = 2;
                                ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]);
                                ViewModel.sprSysAdm.Col = 3;
                                ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["report_status_desc"]);
                                ViewModel.sprSysAdm.Col = 4;
                                ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit"]);
                                ViewModel.sprSysAdm.Col = 5;
                                NameString = "";
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(ReportLog.ReportLogRS["name_last"]))
                                {
                                    NameString = IncidentMain.Clean(ReportLog.ReportLogRS["name_last"]) + ", ";
                                    NameString = NameString + IncidentMain.Clean(ReportLog.ReportLogRS["name_first"]);
                                }
                                else if (!Convert.IsDBNull(ReportLog.ReportLogRS["name_first"]))
                                {
                                    NameString = IncidentMain.Clean(ReportLog.ReportLogRS["name_first"]);
                                }
                                else
                                {
                                    NameString = "";
                                }
                                ViewModel.sprSysAdm.Text = NameString;
                                NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + NameString;
                                ViewModel.cboSysAdm2.AddItem(NameString);
                                ViewModel.cboSysAdm2.SetItemData(ViewModel.cboSysAdm2.GetNewIndex(), Convert.ToInt32(ReportLog.ReportLogRS["report_id"]));
                                CurrRow++;
                            }
                            ReportLog.ReportLogRS.MoveNext();
                        };
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case "Delete Report":
                case "Reset Report Status":
                    if (ReportLog.GetReportLogSysAdm(ViewModel.txtSysAdm1.Text.Trim()) != 0)
                    {

                        while (!ReportLog.ReportLogRS.EOF)
                        {
                            ViewModel.sprSysAdm.Row = CurrRow;
                            ViewModel.sprSysAdm.Col = 1;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["incident_number"]);
                            ViewModel.sprSysAdm.Col = 2;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]);
                            ViewModel.sprSysAdm.Col = 3;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["report_status_desc"]);
                            ViewModel.sprSysAdm.Col = 4;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit"]);
                            ViewModel.sprSysAdm.Col = 5;
                            NameString = "";
                            switch (Convert.ToInt32(ReportLog.ReportLogRS["rep_type"]))
                            {
                                case 15:  //EMS Patient 
                                          //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                                    if (!Convert.IsDBNull(ReportLog.ReportLogRS["name_last"]))
                                    {
                                        NameString = IncidentMain.Clean(ReportLog.ReportLogRS["name_last"]) + ", ";
                                        NameString = NameString + IncidentMain.Clean(ReportLog.ReportLogRS["name_first"]);
                                    }
                                    else if (!Convert.IsDBNull(ReportLog.ReportLogRS["name_first"]))
                                    {
                                        NameString = IncidentMain.Clean(ReportLog.ReportLogRS["name_first"]);
                                    }
                                    else
                                    {
                                        NameString = "";
                                    }
                                    break;
                                case 4:
                                case 32:  //FireStructure or FireExposure 
                                          //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                                    if (!Convert.IsDBNull(ReportLog.ReportLogRS["fire_report_id"]))
                                    {
                                        //Look up Fire Exposure Address
                                        FireReport
                                            = Container.Resolve<clsFire>();
                                        if (FireReport.GetFireExposureAddress(Convert.ToInt32(ReportLog.ReportLogRS["fire_report_id"])) != 0)
                                        {
                                            NameString = FireReport.ExpHouseNumber + " " + FireReport.ExpPrefix + " ";
                                            NameString = NameString + FireReport.ExpStreet + " " + FireReport.ExpStreetType + " ";
                                            NameString = NameString + FireReport.ExpSuffix + ", " + FireReport.ExpCityCode;
                                        }
                                        else
                                        {
                                            NameString = "";
                                        }
                                    }
                                    else
                                    {
                                        NameString = "";
                                    }
                                    break;
                            }
                            ViewModel.sprSysAdm.Text = NameString;
                            //Load combo box
                            switch (ViewModel.cboSystemAction.Text)
                            {
                                case "Delete Report":
                                    if (Convert.ToDouble(ReportLog.ReportLogRS["rep_type"]) > 2)
                                    {
                                        switch (Convert.ToInt32(ReportLog.ReportLogRS["rep_type"]))
                                        {
                                            case 1:  //Unit Report 
                                                NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit"]);
                                                break;
                                            case 15:  //EMS Patient 
                                                NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + NameString;
                                                break;
                                            case 4:
                                            case 32:
                                                NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + NameString;
                                                break;
                                            default:
                                                NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]);
                                                break;
                                        }
                                        ViewModel.cboSysAdm1.AddItem(NameString);
                                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), Convert.ToInt32(ReportLog.ReportLogRS["report_id"]));
                                    }
                                    break;
                                default:
                                    switch (Convert.ToInt32(ReportLog.ReportLogRS["rep_type"]))
                                    {
                                        case 1:  //Unit Report 
                                            NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit"]);
                                            break;
                                        case 15:  //EMS Patient 
                                            NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + NameString;
                                            break;
                                        case 4:
                                        case 32:  //Fire Structure,Exposure 
                                            NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]) + "-" + NameString;
                                            break;
                                        default:
                                            NameString = IncidentMain.Clean(ReportLog.ReportLogRS["report_type_desc"]);
                                            break;
                                    }
                                    ViewModel.cboSysAdm2.AddItem(NameString);
                                    ViewModel.cboSysAdm2.SetItemData(ViewModel.cboSysAdm2.GetNewIndex(), Convert.ToInt32(ReportLog.ReportLogRS["report_id"]));
                                    break;
                            }
                            CurrRow++;
                            ReportLog.ReportLogRS.MoveNext();
                        };
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case "View Security Listing":
                    if (IncidentCL.GetSecurityByType(ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex)) != 0)
                    {

                        while (!IncidentCL.IncidentSecurity.EOF)
                        {
                            ViewModel.sprSysAdm.Row = CurrRow;
                            ViewModel.sprSysAdm.Col = 1;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(IncidentCL.IncidentSecurity["name_full"]);
                            ViewModel.sprSysAdm.Col = 2;
                            ViewModel.sprSysAdm.Text = IncidentMain.Clean(IncidentCL.IncidentSecurity["description"]);
                            CurrRow++;
                            IncidentCL.IncidentSecurity.MoveNext();
                        };
                        result = -1;
                    }
                    else
                    {
                        ViewManager.ShowMessage("There are no employees with this Security Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                        return 0;
                    }

                    break;
                case "Manage Notification System":
                    if (NotifyCL.GetNotificationReceiverByType(ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex)) != 0)
                    {
                        CurrRow = 2;

                        while (!NotifyCL.NotificationReceiver.EOF)
                        {
                            ViewModel.sprNotify.Row = CurrRow;
                            ViewModel.sprNotify.Col = 1;
                            ViewModel.sprNotify.Text = IncidentMain.Clean(NotifyCL.NotificationReceiver["description"]);
                            ViewModel.sprNotify.Col = 2;
                            ViewModel.sprNotify.Text = IncidentMain.Clean(NotifyCL.NotificationReceiver["name_full"]);
                            CurrRow++;
                            NotifyCL.NotificationReceiver.MoveNext();
                        };
                    }
                    else
                    {
                        ViewManager.ShowMessage("There are NO Receivers for this List", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }


                    break;
                case "Update Personnel Security":

                    break;
                case "Change Splash Message":
                    break;
            }
            ViewModel.sprSysAdm.Row = 1;
            ViewModel.sprSysAdm.Col = 1;
            ViewModel.sprSysAdm.Action = FarPoint.ViewModels.FPActionConstants.ActionActiveCell;


            return result;
        }

        private void ClearSystemAdmin()
        {
            //    cboSystemAction.ListIndex = -1
            ViewModel.lbSysAdmin1.Visible = false;
            ViewModel.lbSysAdmin2.Visible = false;
            ViewModel.lbSysAdmin3.Visible = false;
            ViewModel.txtSysAdm1.Visible = false;
            ViewModel.txtSysAdm1.Text = "";
            ViewModel.cboSysAdm1.Items.Clear();
            ViewModel.cboSysAdm2.Items.Clear();
            ViewModel.sprSysAdm.Visible = false;
            ViewModel.sprNotify.Visible = false;
            ViewModel.sprSysAdm.BlockMode = false;
            ViewModel.cboSysAdm1.Visible = false;
            ViewModel.cboSysAdm2.Visible = false;
            ViewModel.cmdSysButt1.Visible = false;
            ViewModel.cmdSysButt2.Visible = false;
            ViewModel.cmdSysButt3.Visible = false;
            ViewModel.frmAdmHelp.Visible = false;

        }

        private void LoadSystemAdmin()
        {
            //Load Form Controls for System Administration Tab
            ViewModel.cboSystemAction.Items.Clear();
            ViewModel.cboSystemAction.AddItem("Delete Report");
            ViewModel.cboSystemAction.AddItem("Update Personnel Security");
            ViewModel.cboSystemAction.AddItem("Change Splash Message");
            ViewModel.cboSystemAction.AddItem("Reset Report Status");
            ViewModel.cboSystemAction.AddItem("Change EMS Report Type");
            ViewModel.cboSystemAction.AddItem("View Security Listing");
            ViewModel.cboSystemAction.AddItem("Manage Notification System");
            ViewModel.cboSystemAction.AddItem("Update Help Files");


            LoadFireAdmin();

        }

        private void LoadFireAdmin()
        {
            //Load Admin Inquiry listbox
            TFDIncident.clsInquiry Inquiry = Container.Resolve<clsInquiry>();
            ViewModel.cboInquiryList.Items.Clear();
            Inquiry.GetInquiries(IncidentMain.Shared.gSystemSecurity);

            while (!Inquiry.InquiryManagerRS.EOF)
            {
                ViewModel.cboInquiryList.AddItem(IncidentMain.Clean(Inquiry.InquiryManagerRS["inquiry_display"]));
                ViewModel.cboInquiryList.SetItemData(ViewModel.cboInquiryList.GetNewIndex(), Convert.ToInt32(Inquiry.InquiryManagerRS["inquiry_id"]));
                Inquiry.InquiryManagerRS.MoveNext();
            }
            ;

        }

        private void InitializeQueryForm()
        {
            //Initilize Data Inquiry tab for new Query
            ViewModel.lbCal1.Visible = false;
            ViewModel.lbCal1.Text = "";
            ViewModel.lbCal1.Tag = "";
            ViewModel.lbCal2.Visible = false;
            ViewModel.lbCal2.Text = "";
            ViewModel.lbCal2.Tag = "";
            ViewModel.calInquiry1.Visible = false;
            ViewModel.calInquiry1.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse(DateTime.Now.ToString("M/d/yyyy")), DateTime.Parse(DateTime.Now.ToString("M/d/yyyy")));
            ViewModel.calInquiry2.Visible = false;
            ViewModel.calInquiry2.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse(DateTime.Now.ToString("M/d/yyyy")), DateTime.Parse(DateTime.Now.ToString("M/d/yyyy")));
            ViewModel.sprNoteLog.Visible = false;
            ViewModel.sprNoteLog.BlockMode = true;
            ViewModel.sprNoteLog.Row = 5;
            ViewModel.sprNoteLog.Row2 = 500;
            ViewModel.sprNoteLog.Col = 1;
            ViewModel.sprNoteLog.Col2 = 5;
            ViewModel.sprNoteLog.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
            ViewModel.sprNoteLog.Text = "";
            ViewModel.sprNoteLog.BlockMode = false;
            for (int i = 0; i <= 5; i++)
            {
                ViewModel.txtFilter[i].Visible = false;
                ViewModel.txtFilter[i].Text = "";
                ViewModel.cboFilter[i].Items.Clear();
                ViewModel.cboFilter[i].Visible = false;
                ViewModel.lbFilter[i].Visible = false;
                ViewModel.lbFilter[i].Text = "";
                ViewModel.lbFilter[i].Tag = "";
            }
            ViewModel.cmdView.Text = "View Results";
            ViewModel.cmdView.Enabled = false;

        }

        private void LoadLists()
        {
            //Load Filter ComboBoxes
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            TFDIncident.clsInquiry Inquiry = Container.Resolve<clsInquiry>();


            UnitCL.TFDUnitListRS();
            ViewModel.cboUnit.Items.Clear();
            ViewModel.cboIncUnit.Items.Clear();


            while (!UnitCL.Unit.EOF)
            {
                ViewModel.cboUnit.AddItem(IncidentMain.Clean(UnitCL.Unit["unit_id"]));
                ViewModel.cboIncUnit.AddItem(IncidentMain.Clean(UnitCL.Unit["unit_id"]));
                UnitCL.Unit.MoveNext();
            }
            ;
            //?????????????????? CodeTable Class Replace ????????????

            CommonCodes.GetIncidentTypeClassRS();
            ViewModel.cboType.Items.Clear();
            ViewModel.cboIncType.Items.Clear();


            while (!CommonCodes.IncidentTypeClassRS.EOF)
            {
                ViewModel.cboType.AddItem(IncidentMain.Clean(CommonCodes.IncidentTypeClassRS["description"]));
                ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentTypeClassRS["incident_type_class"]));
                ViewModel.cboIncType.AddItem(IncidentMain.Clean(CommonCodes.IncidentTypeClassRS["description"]));
                ViewModel.cboIncType.SetItemData(ViewModel.cboIncType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentTypeClassRS["incident_type_class"]));
                CommonCodes.IncidentTypeClassRS.MoveNext();
            }
            ;

            //*******************************************************
            //***   Load Field Reports Combo Box                   **
            //*******************************************************
            ViewModel.cboFieldReport.Items.Clear();
            Inquiry.GetFieldReports();

            while (!Inquiry.InquiryManagerRS.EOF)
            {
                ViewModel.cboFieldReport.AddItem(IncidentMain.Clean(Inquiry.InquiryManagerRS["inquiry_display"]));
                ViewModel.cboFieldReport.SetItemData(ViewModel.cboFieldReport.GetNewIndex(), Convert.ToInt32(Inquiry.InquiryManagerRS["inquiry_id"]));
                Inquiry.InquiryManagerRS.MoveNext();
            }
            ;
            System.DateTime TempDate = DateTime.FromOADate(0);
            ViewModel.calFRStart.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse((DateTime.TryParse
               ("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "1/1/" + DateTime.
                       Now.Year.ToString()), DateTime.Parse((DateTime.TryParse("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "1/1/" + DateTime.Now.Year.ToString()));
            System.DateTime TempDate2 = DateTime.FromOADate(0);
            ViewModel.calFREnd.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse((DateTime.TryParse
                        ("12/31/" + DateTime.Now.Year.ToString(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : "12/31/" +
                                DateTime.Now.Year.ToString()), DateTime.Parse((DateTime.TryParse("12/31/" + DateTime.Now.Year
                            .ToString(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : "12/31/" + DateTime.Now.Year.ToString()));
            ViewModel.lbSelection1.Visible = false;
            ViewModel.lbSelection2.Visible = false;
            ViewModel.cboSelection1.Items.Clear();
            ViewModel.cboSelection2.Items.Clear();
            ViewModel.cboSelection1.Visible = false;
            ViewModel.cboSelection2.Visible = false;
            //***********************************************
            //***  Determine Security and Format Tabs     ***
            //***********************************************
            if (IncidentMain.Shared.gSystemSecurity == IncidentMain.ADMINISTRATOR)
            {
                //Display all tabs
                ViewModel.MainTabs.Items[3].Text = "Admin Inquiry";
                ViewModel.MainTabs.Items[4].Text = "System Admin";
                LoadSystemAdmin();
            }
            else if (IncidentMain.Shared.gSystemSecurity == IncidentMain.FIREADMIN || IncidentMain.Shared.gSystemSecurity == IncidentMain.INSPECTOR)
            {
                //Display Admin Inquiry Tab
                ViewModel.MainTabs.Items[3].Text = "Admin Inquiry";
                ViewModel.MainTabs.Items[4].Text = "";
                LoadFireAdmin();
            }
            else if (IncidentMain.Shared.gSystemSecurity == IncidentMain.NOACCESS)
            {
                ViewModel.MainTabs.Items[0].Text = "";
                ViewModel.MainTabs.Items[1].Text = "";
                ViewModel.MainTabs.Items[2].Text = "";
                ViewModel.MainTabs.Items[3].Text = "";
                ViewModel.MainTabs.Items[4].Text = "";
            }
            else
            {
                //Read Only
                //Hide Admin tabs
                ViewModel.MainTabs.Items[3].Text = "";
                ViewModel.MainTabs.Items[4].Text = "";
            }




        }

        public void LoadUnitList()
        {
            //Load UnitList For Selected Date
            TFDIncident.clsUnit UnitResponse = Container.Resolve<clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            UpgradeHelpers.Helpers.Color RowColor = UpgradeHelpers.Helpers.Color.Black;

            string UnitParm = "";
            int StatusParm = 0;
            string BattParm = "";
            int TypeParm = 0;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            int CurrRow = 0;
            //UPGRADE_WARNING: (1068) calUnit.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
            string StartDate = Convert.ToDateTime(ViewModel.calUnit.Value).ToString("MM/dd/yyyy");
            string EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("MM/dd/yyyy");
            if (ViewModel.cboUnit.SelectedIndex != -1)
            {
                UnitParm = ViewModel.cboUnit.Text.Trim();
            }
            else
            {
                UnitParm = "";
                if (ViewModel.optBattalion[0].Checked)
                {
                    BattParm = "1";
                }
                else if (ViewModel.optBattalion[1].Checked)
                {
                    BattParm = "2";
                }
                else if (ViewModel.optBattalion[2].Checked)
                {
                    BattParm = "3";
                }
                else
                {
                    BattParm = "";
                }
            }
            if (ViewModel.cboType.SelectedIndex != -1)
            {
                TypeParm = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
            }
            else
            {
                TypeParm = 0;
            }
            if (ViewModel.cboStatus.SelectedIndex != -1)
            {
                StatusParm = ViewModel.cboStatus.GetItemData(ViewModel.cboStatus.SelectedIndex);
            }
            else
            {
                StatusParm = 0;
            }

            if (~UnitResponse.GetUnitListing(StartDate, EndDate, UnitParm, TypeParm, BattParm, StatusParm) != 0)
            {
                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
                this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
                ViewModel.sprUnitList.Rows = Container.Resolve<Custom.ViewModels.Grid.RowsCollection>();
                return; //no reports
            }
            //Create The IList with a serialized List Class 
            System.Collections.Generic.IList<ItemsUnitGrid> data = Container.Resolve<System.Collections.Generic.IList<ItemsUnitGrid>>();

            while (!UnitResponse.UnitListing.EOF)
            {
                ItemsUnitGrid unitRow = Container.Resolve<ItemsUnitGrid>();
                unitRow.Unit = IncidentMain.Clean(UnitResponse.UnitListing["tfd_unit"]);
                unitRow.Incident_Number = IncidentMain.Clean(UnitResponse.UnitListing["incident_number"]);
                unitRow.Time = Convert.ToDateTime(UnitResponse.UnitListing["actual_time"]).ToString("HH:mm");
                unitRow.Location = IncidentMain.Clean(UnitResponse.UnitListing["location"]);
                unitRow.Type = IncidentMain.Clean(UnitResponse.UnitListing["inc_descript"]);
                unitRow.IncidentId = IncidentMain.Clean(UnitResponse.UnitListing["inc_id"]);
                unitRow.ResportStatus = IncidentMain.Clean(UnitResponse.UnitListing["report_status"]);

                if (Convert.ToDouble(UnitResponse.UnitListing["report_status"]) == IncidentMain.INCOMPLETE)
                {
                    RowColor = IncidentMain.Shared.RED;
                }
                else if (Convert.ToDouble(UnitResponse.UnitListing["report_status"]) == IncidentMain.SAVEDINCOMPLETE)
                {
                    RowColor = IncidentMain.Shared.TEAL;
                }
                else
                {
                    RowColor = IncidentMain.Shared.BLACK;
                }
                data.Add(unitRow);
                UnitResponse.UnitListing.MoveNext();
                //ViewModel.sprUnitList.BackColor = RowColor; Row Color
            }
            ViewModel.sprUnitList.DataSource = data;
            ViewModel.sprUnitList.Columns["ResportStatus"].Hidden = true;
            ViewModel.sprUnitList.Columns["IncidentId"].Hidden = true;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

        }

        private void LoadIncidentList()
        {
            //Load Incident List for Selected Date
            ADORecordSetHelper orec = null;
            string UnitParm = "";
            int TypeParm = 0;
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            UpgradeHelpers.Helpers.Color RowColor = UpgradeHelpers.Helpers.Color.Black;

            //Clear Incident Grid
            ViewModel.sprIncident.MaxRows = 500;
            ViewModel.sprIncident.BlockMode = true;
            ViewModel.sprIncident.Row = 1;
            ViewModel.sprIncident.Row2 = 500;
            ViewModel.sprIncident.Col = 2;
            ViewModel.sprIncident.Col2 = 7;
            ViewModel.sprIncident.Action = FarPoint.ViewModels.FPActionConstants.ActionClearText;
            ViewModel.sprIncident.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.sprIncident.BlockMode = false;
            ViewModel.sprIncident.ClearAllCells();

            int CurrRow = 1;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            //UPGRADE_WARNING: (1068) calIncident.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
            string StartDate = Convert.ToDateTime(ViewModel.calIncident.Value).ToString("MM/dd/yyyy");
            string EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("MM/dd/yyyy");


            if (ViewModel.cboIncUnit.SelectedIndex != -1)
            {
                UnitParm = ViewModel.cboIncUnit.Text;
            }
            else
            {
                UnitParm = "";
            }

            if (ViewModel.cboIncType.SelectedIndex != -1)
            {
                TypeParm = ViewModel.cboIncType.GetItemData(ViewModel.cboIncType.SelectedIndex);
            }
            else
            {
                TypeParm = 0;
            }

            if (IncidentCL.IncidentListRS(StartDate, EndDate, UnitParm, TypeParm) != 0)
            {
                orec = IncidentCL.IncidentRS;


                while (!orec.EOF)
                {
                    ViewModel.sprIncident.Row = CurrRow;
                    ViewModel.sprIncident.Col = 2;
                    ViewModel.sprIncident.Text = Convert.ToString(orec["incident_number"]);
                    ViewModel.sprIncident.Col = 3;
                    ViewModel.sprIncident.Text = Convert.ToDateTime(orec["date_incident_created"]).ToString("HH:mm");
                    ViewModel.sprIncident.Col = 4;
                    ViewModel.sprIncident.Text = IncidentMain.Clean(orec["location"]);
                    ViewModel.sprIncident.Col = 5;
                    ViewModel.sprIncident.Text = IncidentMain.Clean(orec["IType"]);
                    ViewModel.sprIncident.Col = 6;
                    ViewModel.sprIncident.Text = IncidentMain.Clean(orec["resp_unit"]);
                    ViewModel.sprIncident.Col = 7;
                    ViewModel.sprIncident.Text = Convert.ToString(orec["IncidentID"]);

                    if (Convert.ToDouble(orec["report_status"]) == IncidentMain.INCOMPLETE)
                    {
                        RowColor = IncidentMain.Shared.RED;
                    }
                    else if (Convert.ToDouble(orec["report_status"]) == IncidentMain.SAVEDINCOMPLETE)
                    {
                        RowColor = IncidentMain.Shared.TEAL;
                    }
                    else
                    {
                        RowColor = IncidentMain.Shared.BLACK;
                    }
                    ViewModel.sprIncident.BlockMode = true;
                    ViewModel.sprIncident.Col = 1;
                    ViewModel.sprIncident.Col2 = 6;
                    ViewModel.sprIncident.Row2 = CurrRow;
                    ViewModel.sprIncident.ForeColor = RowColor;
                    ViewModel.sprIncident.BlockMode = false;
                    ViewModel.sprIncident.BackColor = RowColor;
                    ViewModel.sprIncident.SetRowHeight(CurrRow, 20.3f);
                    CurrRow++;
                    orec.MoveNext();
                };
            }
            ViewModel.sprIncident.MaxRows = CurrRow;
            ViewModel.sprIncReports.BlockMode = true;
            ViewModel.sprIncReports.Row = 1;
            ViewModel.sprIncReports.Row2 = 20;
            ViewModel.sprIncReports.Col = 1;
            ViewModel.sprIncReports.Col2 = 2;
            ViewModel.sprIncReports.Action = FarPoint.ViewModels.FPActionConstants.ActionClear; //-Clear

            ViewModel.sprIncReports.BlockMode = false;
            ViewModel.sprUnitReports.BlockMode = true;
            ViewModel.sprUnitReports.Row = 1;
            ViewModel.sprUnitReports.Row2 = 20;
            ViewModel.sprUnitReports.Col = 1;
            ViewModel.sprUnitReports.Col2 = 2;
            ViewModel.sprUnitReports.Action = FarPoint.ViewModels.FPActionConstants.ActionClear; //-Clear

            ViewModel.sprUnitReports.BlockMode = false;
            ViewModel.lbIncidentMain.Text = "";
            IncidentCL = null;
            ViewModel.sprIncident.Row = 1;
            ViewModel.sprIncident.Col = 1;
            ViewModel.sprIncident.Action = FarPoint.ViewModels.FPActionConstants.ActionActiveCell;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

        }

        private void FormatIncidentSelector()
        {
            //Format Incident Selector Grids
            //Called at Form Load and whenever
            //Incident Selected
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            int CurrRow = 0;

            //Clear Selector Grids
            ViewModel.sprUnitReports.BlockMode = true;
            ViewModel.sprUnitReports.Row = 1;
            ViewModel.sprUnitReports.Row2 = 20;
            ViewModel.sprUnitReports.Col = 1;
            ViewModel.sprUnitReports.Col2 = 2;
            ViewModel.sprUnitReports.Text = "";
            ViewModel.sprUnitReports.BlockMode = false;
            ViewModel.sprIncReports.BlockMode = true;
            ViewModel.sprIncReports.Row = 1;
            ViewModel.sprIncReports.Row2 = 20;
            ViewModel.sprIncReports.Col = 1;
            ViewModel.sprIncReports.Col2 = 2;
            ViewModel.sprIncReports.Text = "";
            ViewModel.sprIncReports.BlockMode = false;

            if (ViewModel.CurrIncident != 0)
            {
                //Unit Reports
                CurrRow = 2;
                //Get Unit Reports
                if (ReportLog.GetUnitReportRS(ViewModel.CurrIncident) != 0)
                {

                    while (!ReportLog.ReportLogRS.EOF)
                    {
                        ViewModel.sprUnitReports.Row = CurrRow;
                        ViewModel.sprUnitReports.Col = 1;
                        ViewModel.sprUnitReports.Text = Convert.ToString(ReportLog.ReportLogRS["responsible_unit_id"]).Trim();
                        if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == IncidentMain.INCOMPLETE)
                        {
                        }
                        else if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == IncidentMain.SAVEDINCOMPLETE)
                        {
                        }
                        else
                        {
                        }
                        ViewModel.sprUnitReports.Col = 2;
                        ViewModel.sprUnitReports.Text = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                        ReportLog.ReportLogRS.MoveNext();
                        CurrRow++;
                    };
                }
                else
                {
                    ViewManager.ShowMessage("Error Loading Unit Reports", "Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }

                //IncidentReports
                CurrRow = 2;
                ReportLog.GetIncidentEditReports(ViewModel.CurrIncident);

                while (!ReportLog.ReportLogRS.EOF)
                {
                    ViewModel.sprIncReports.Row = CurrRow;
                    ViewModel.sprIncReports.Col = 1;
                    switch (Convert.ToInt32(ReportLog.ReportLogRS["ReportType"]))
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx 
                            if (FireReport.GetFireStructure(Convert.ToInt32(IncidentMain.GetVal(ReportLog.ReportLogRS["report_reference_id"]))) != 0)
                            {
                                if (FireReport.FlagExposure != 0)
                                {
                                    ViewModel.sprIncReports.Text = "Fire Structure Exposure Report" + " - " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                                }
                                else
                                {
                                    ViewModel.sprIncReports.Text = IncidentMain.Clean(ReportLog.ReportLogRS["display_description"]) + " - " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                                }
                            }
                            else
                            {
                                ViewModel.sprIncReports.Text = IncidentMain.Clean(ReportLog.ReportLogRS["display_description"]) + " - " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                            }
                            break;
                        case IncidentMain.EMSBASIC:
                            if (EMSReport.GetEMSPatient(Convert.ToInt32(ReportLog.ReportLogRS["report_reference_id"])) != 0)
                            {
                                ViewModel.sprIncReports.Text = "EMS Patient Report - " + IncidentMain.Clean(EMSReport.NameFirst) + " " + IncidentMain.Clean(EMSReport.NameLast) + " - " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                            }
                            else
                            {
                                ViewModel.sprIncReports.Text = "EMS Patient Report - Basic " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                            }
                            break;
                        case IncidentMain.FSCASUALTY:
                            if (Casualty.GetFSCasualtyName(Convert.ToInt32(ReportLog.ReportLogRS["report_reference_id"])) != "")
                            {
                                ViewModel.sprIncReports.Text = "Fire Service Casualty Report - " + Casualty.GetFSCasualtyName(Convert.ToInt32(ReportLog.ReportLogRS["report_reference_id"]));
                            }
                            else
                            {
                                ViewModel.sprIncReports.Text = "Fire Service Casualty Report - No Name";
                            }
                            break;
                        default:
                            ViewModel.sprIncReports.Text = IncidentMain.Clean(ReportLog.ReportLogRS["display_description"]) + " - " + IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]);
                            break;
                    }
                    if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == IncidentMain.INCOMPLETE)
                    {
                    }
                    else if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == IncidentMain.SAVEDINCOMPLETE)
                    {
                    }
                    else
                    {
                    }
                    ViewModel.sprIncReports.Col = 2;
                    ViewModel.sprIncReports.Text = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                    if (Convert.ToDouble(ReportLog.ReportLogRS["ReportType"]) == IncidentMain.INCIDENTREPORT)
                    {
                        CurrRow += 2;
                    }
                    else
                    {
                        CurrRow++;
                    }
                    ReportLog.ReportLogRS.MoveNext();
                };
                if (IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
                {
                    ViewModel.lbIncidentMain.Text = IncidentCL.IncidentNumber;
                }
                else
                {
                    ViewModel.lbIncidentMain.Text = "";
                }
            }

        }




        //UPGRADE_WARNING: (2074) Calendar event calIncident.Click was upgraded to calIncident.DateChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
        [UpgradeHelpers.Events.Handler]
        internal void calIncident_DateChanged(Object eventSender, Stubs._System.Windows.Forms.DateRangeEventArgs eventArgs)
        {
            LoadIncidentList();
            if (IncidentMain.Shared.gAppCancel != 0)
            {
                return;
            }
            //UPGRADE_WARNING: (1068) calIncident.Value of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
            ViewModel.calUnit.Value = ViewModel.calIncident.Value;
            LoadUnitList();
        }

        //UPGRADE_WARNING: (2074) Calendar event calUnit.Click was upgraded to calUnit.DateChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
        [UpgradeHelpers.Events.Handler]
        internal void calUnit_DateChanged(Object eventSender, Stubs._System.Windows.Forms.DateRangeEventArgs eventArgs)
        {
            LoadUnitList();
            if (IncidentMain.Shared.gAppCancel != 0)
            {
                return;
            }
            //UPGRADE_WARNING: (1068) calUnit.Value of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
            ViewModel.calIncident.Value = ViewModel.calUnit.Value;
            LoadIncidentList();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboFieldReport_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Display or Hide  Selection Controls
            if (ViewModel.cboFieldReport.SelectedIndex == -1)
            {
                return;
            }
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();


            //Reset Parameter controls
            System
                .DateTime TempDate = DateTime.FromOADate(0);
            ViewModel.calFRStart.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse((DateTime.TryParse
             ("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "1/1/" + DateTime.
                     Now.Year.ToString()), DateTime.Parse((DateTime.TryParse("1/1/" + DateTime.Now.Year.ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "1/1/" + DateTime.Now.Year.ToString()));
            System.DateTime TempDate2 = DateTime.FromOADate(0);
            ViewModel.calFREnd.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse((DateTime.TryParse
                        ("12/31/" + DateTime.Now.Year.ToString(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : "12/31/" +
                                DateTime.Now.Year.ToString()), DateTime.Parse((DateTime.TryParse("12/31/" + DateTime.Now.Year
                            .ToString(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : "12/31/" + DateTime.Now.Year.ToString()));
            ViewModel.lbSelection1.Visible = false;
            ViewModel.lbSelection2.Visible = false;
            ViewModel.cboSelection1.Items.Clear();
            ViewModel.cboSelection2.Items.Clear();
            ViewModel.cboSelection1.Visible = false;
            ViewModel.cboSelection2.Visible = false;
            ViewModel.cmdViewReport.Enabled = false;

            int SelectedReport = ViewModel.cboFieldReport.GetItemData(ViewModel.cboFieldReport.SelectedIndex);
            switch (SelectedReport)
            {
                case 2:
                case 4:
                    //OTEP Procedures 
                    //ALS Procedures 
                    ViewModel.lbSelection1.Text = "Select Personnel";
                    PersonnelCL.GetOperationsList();
                    ViewModel.cboSelection1.Items.Clear();

                    while (!PersonnelCL.OperationsList.EOF)
                    {
                        ViewModel.cboSelection1.AddItem(Convert.ToString(PersonnelCL.OperationsList["name_full"]).Trim() + " :" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]));
                        PersonnelCL.OperationsList.MoveNext();
                    }
                    ;
                    ViewModel.lbSelection1.Visible = true;
                    ViewModel.cboSelection1.Visible = true;
                    ViewModel.lbSelection2.Visible = false;
                    ViewModel.cboSelection2.Visible = false;
                    break;
                case 7:
                case 8:
                case 10:
                    //Unit Response Summary Report - 7 
                    //Unit Reporting - 8 
                    //Unit Activity - 10 
                    ViewModel.lbSelection1.Text = "Select Unit";
                    ViewModel.lbSelection2.Text = "Select Shift";
                    UnitCL.TFDUnitListRS();
                    ViewModel.cboSelection1.Items.Clear();
                    ViewModel.cboSelection2.Items.Clear();

                    while (!UnitCL.Unit.EOF)
                    {
                        ViewModel.cboSelection1.AddItem(IncidentMain.Clean(UnitCL.Unit["unit_id"]));
                        UnitCL.Unit.MoveNext();
                    }
                    ;
                    ViewModel.cboSelection2.AddItem("All Shifts");
                    ViewModel.cboSelection2.AddItem("A");
                    ViewModel.cboSelection2.AddItem("B");
                    ViewModel.cboSelection2.AddItem("C");
                    ViewModel.cboSelection2.AddItem("D");
                    ViewModel.lbSelection1.Visible = true;
                    ViewModel.cboSelection1.Visible = true;
                    ViewModel.lbSelection2.Visible = true;
                    ViewModel.cboSelection2.Visible = true;
                    break;
                case 9:
                    //Battalion Incomplete Reports 
                    ViewModel.lbSelection1.Text = "Select Battalion";
                    ViewModel.lbSelection2.Text = "Select Shift";
                    ViewModel.cboSelection1.Items.Clear();
                    ViewModel.cboSelection2.Items.Clear();
                    ViewModel.cboSelection1.AddItem("BC1");
                    ViewModel.cboSelection1.AddItem("BC2");
                    ViewModel.cboSelection1.AddItem("BC3");
                    ViewModel.cboSelection2.AddItem("All Shifts");
                    ViewModel.cboSelection2.AddItem("A");
                    ViewModel.cboSelection2.AddItem("B");
                    ViewModel.cboSelection2.AddItem("C");
                    ViewModel.cboSelection2.AddItem("D");
                    ViewModel.lbSelection1.Visible = true;
                    ViewModel.cboSelection1.Visible = true;
                    ViewModel.lbSelection2.Visible = true;
                    ViewModel.cboSelection2.Visible = true;

                    break;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Reload Incident List
            //First Check for No selection or reset

            if (ViewModel.cboIncType.SelectedIndex == -1)
            {
                return;
            }

            LoadIncidentList();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboIncType.SelectedIndex == -1)
            {
                ViewModel.cboIncType.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Reload Incident List
            //First Check for No selection or reset

            if (ViewModel.cboIncUnit.SelectedIndex == -1)
            {
                return;
            }

            LoadIncidentList();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInquiryList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Load Fields and Filters for selected Query
            TFDIncident.clsInquiry InquiryCL = Container.Resolve<clsInquiry>();
            TFDIncident.clsNotification NotificationCL = Container.Resolve<clsNotification>();
            int CurrRow = 0;

            if (ViewModel.cboInquiryList.SelectedIndex == -1)
            {
                return;
            }
            int InquiryID = ViewModel.cboInquiryList.GetItemData(ViewModel.cboInquiryList.SelectedIndex);
            ViewModel.SummaryReportFlag = 0;
            InitializeQueryForm();
            ViewModel.lstFields.Items.Clear();
            ViewModel.lstFields.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.lstFields.Enabled = true;
            ViewModel.lstFilters.Items.Clear();
            ViewModel.lstFilters.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.lstFilters.Visible = true;
            ViewModel.lbFilterFields.Visible = true;
            ViewModel.lbViewFields.Text = "Select Which Items You Would Like To View";
            ViewModel.lbFilterFields.Text = "Select Which Items You Would Like To Use as Filters";

            InquiryCL.GetInquiryManager(InquiryID);
            if (InquiryCL.InquiryOrderBy == "Summary")
            {
                ViewModel.SummaryReportFlag = -1;
                ViewModel.lbViewFields.Text = "Select Up to 3 Items for Summary Reporting";
                ViewModel.lbFilterFields.Text = "Report Field Order: Select for additional Filtering";
                ViewModel.lbFilterFields.Visible = false;
                ViewModel.lstFilters.Visible = false;
                if (~InquiryCL.GetInquiryFieldsRS(InquiryID) != 0)
                {
                    ViewManager.ShowMessage("Error Retreiving Summary Item Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    return;
                }

                while (!InquiryCL.InquiryFields.EOF)
                {
                    //UPGRADE_WARNING: (1068) GetVal(InquiryCL.InquiryFields(flag_display)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                    if (Convert.ToBoolean(IncidentMain.GetVal(InquiryCL.InquiryFields["flag_display"])))
                    {
                        ViewModel.lstFields.AddItem(IncidentMain.Clean(InquiryCL.InquiryFields["field_display"]));
                        ViewModel.lstFields.SetItemData(ViewModel.lstFields.GetNewIndex(), Convert.ToInt32(InquiryCL.InquiryFields["inquiry_field_id"]));
                    }
                    InquiryCL.InquiryFields.MoveNext();
                }
                ;
            }
            else if (InquiryCL.InquiryView.StartsWith("sp"))
            {
                ViewModel.SummaryReportFlag = 0;
                //stored procedures
                switch (InquiryID)
                {
                    case 11:
                        //List Notification Messages Logged for this employee 
                        if (~NotificationCL.GetNotificationMessagesByReceiver(IncidentMain.Shared.gCurrUser) != 0)
                        {
                            ViewManager.ShowMessage("No Notification Messages Logged", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                            return;
                        }
                        else
                        {
                            ViewModel.sprNoteLog.Visible = true;
                            CurrRow = 5;
                            ViewModel.sprNoteLog.Col = 2;

                            while (!NotificationCL.NotificationMessage.EOF)
                            {
                                ViewModel.sprNoteLog.Row = CurrRow;
                                ViewModel.sprNoteLog.Text = Convert.ToDateTime(NotificationCL.NotificationMessage["date_message_created"]).ToString("M/d/yyyy HH:mm");
                                ViewModel.sprNoteLog.Col = 3;
                                System.DateTime TempDate = DateTime.FromOADate(0);
                                ViewModel.sprNoteLog.Text = (DateTime.TryParse(IncidentMain.Clean(NotificationCL.NotificationMessage["date_message_received"]), out TempDate)) ? TempDate.ToString("M/d/yyyy HH:mm") : IncidentMain.Clean(NotificationCL.NotificationMessage["date_message_received"]);
                                ViewModel.sprNoteLog.Col = 4;
                                ViewModel.sprNoteLog.Text = IncidentMain.Clean(NotificationCL.NotificationMessage["message_text"]);
                                ViewModel.sprNoteLog.Col = 5;
                                ViewModel.sprNoteLog.Text = Convert.ToString(NotificationCL.NotificationMessage["notification_message_id"]);
                                CurrRow++;
                                NotificationCL.NotificationMessage.MoveNext();
                            }
                                ;
                        }

                        break;
                }

            }
            else
            {
                //view
                ViewModel.SummaryReportFlag = 0;
                if (~InquiryCL.GetInquiryFieldsRS(InquiryID) != 0)
                {
                    ViewManager.ShowMessage("Error Retreiving Fields/Filter Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    return;
                }

                while (!InquiryCL.InquiryFields.EOF)
                {
                    //UPGRADE_WARNING: (1068) GetVal(InquiryCL.InquiryFields(flag_display)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                    if (Convert.ToBoolean(IncidentMain.GetVal(InquiryCL.InquiryFields["flag_display"])))
                    {
                        ViewModel.lstFields.AddItem(IncidentMain.Clean(InquiryCL.InquiryFields["field_display"]));
                        ViewModel.lstFields.SetItemData(ViewModel.lstFields.GetNewIndex(), Convert.ToInt32(InquiryCL.InquiryFields["inquiry_field_id"]));
                    }
                    //UPGRADE_WARNING: (1068) GetVal(InquiryCL.InquiryFields(flag_filter)) of type Variant is being forced to bool. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                    if (Convert.ToBoolean(IncidentMain.GetVal(InquiryCL.InquiryFields["flag_filter"])))
                    {
                        ViewModel.lstFilters.AddItem(IncidentMain.Clean(InquiryCL.InquiryFields["field_display"]));
                        ViewModel.lstFilters.SetItemData(ViewModel.lstFilters.GetNewIndex(), Convert.ToInt32(InquiryCL.InquiryFields["inquiry_field_id"]));
                    }
                    InquiryCL.InquiryFields.MoveNext();
                }
;
            }
            ViewModel.cmdView.Enabled = false;
            ViewModel.cmdClearSelections.Visible = false;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInquiryList_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboInquiryList.SelectedIndex == -1)
            {
                ViewModel.cboInquiryList.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboReportList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboReportList.SelectedIndex == -1)
            {
                return;
            }

            InitializeQueryForm();
            switch (ViewModel.cboReportList.Text)
            {
                case "NFPA Survey":
                    ViewModel.lbFilter[0].Text = "Select Report Year";
                    ViewModel.lbFilter[0].Visible = true;
                    ViewModel.cboFilter[0].Items.Clear();
                    ViewModel.cboFilter[0].AddItem("2001");
                    ViewModel.cboFilter[0].AddItem("2002");
                    ViewModel.cboFilter[0].Visible = true;
                    break;
            }
            ViewModel.cmdView.Text = "View Report";
            //    cmdView.Enabled = True
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSelection1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Determine if all required parameters have been selected
            //Toggle View Report button as appropriate
            switch (ViewModel.cboFieldReport.GetItemData(ViewModel.cboFieldReport.SelectedIndex))
            {
                case 2:
                case 4:
                    //1 combobox selection 
                    ViewModel.cmdViewReport.Enabled = ViewModel.cboSelection1.SelectedIndex != -1;
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                    //2 combobox selections 
                    if (ViewModel.cboSelection1.SelectedIndex != -1)
                    {
                        ViewModel.cmdViewReport.Enabled = ViewModel.cboSelection2.SelectedIndex != -1;
                    }
                    else
                    {
                        ViewModel.cmdViewReport.Enabled = false;
                    }
                    break;
                default:
                    ViewModel.cmdViewReport.Enabled = false;
                    break;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSelection2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Determine if all required parameters have been selected
            //Toggle View Report button as appropriate
            switch (ViewModel.cboFieldReport.GetItemData(ViewModel.cboFieldReport.SelectedIndex))
            {
                case 2:
                case 4:
                    //1 combobox selection 
                    ViewModel.cmdViewReport.Enabled = ViewModel.cboSelection1.SelectedIndex != -1;
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                    //2 combobox selections 
                    if (ViewModel.cboSelection1.SelectedIndex != -1)
                    {
                        ViewModel.cmdViewReport.Enabled = ViewModel.cboSelection2.SelectedIndex != -1;
                    }
                    else
                    {
                        ViewModel.cmdViewReport.Enabled = false;
                    }
                    break;
                default:
                    ViewModel.cmdViewReport.Enabled = false;
                    break;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboStatus_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboStatus.SelectedIndex == -1)
            {
                return;
            }

            if (~ViewModel.DontRespond != 0)
            {
                LoadUnitList();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboStatus_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboStatus.SelectedIndex == -1)
            {
                ViewModel.cboStatus.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSystemAction_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Format Sys Admin Selection Controls
            //Based on Action Selection

            if (ViewModel.cboSystemAction.SelectedIndex == -1)
            {
                return;
            }
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            TFDIncident.clsNotification NotifyCL = Container.Resolve<clsNotification>();

            ClearSystemAdmin();


            switch (ViewModel.cboSystemAction.Text)
            {
                case "Delete Report":
                case "Reset Report Status":
                case "Change EMS Report Type":
                    ViewModel.lbSysAdmin1.Text = "Enter Incident Number:";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.txtSysAdm1.Visible = true;
                    ViewModel.txtSysAdm1.Text = "";
                    ViewModel.cmdSysButt3.Text = "Search..";
                    ViewModel.cmdSysButt3.Visible = true;

                    break;
                case "View Security Listing":
                    ViewModel.lbSysAdmin1.Text = "Select Security Type:";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.cboSysAdm2.Items.Clear();
                    CommonCodes.GetSecurityCode();

                    while (!CommonCodes.SecurityCode.EOF)
                    {
                        ViewModel.cboSysAdm2.AddItem(IncidentMain.Clean(CommonCodes.SecurityCode["description"]));
                        ViewModel.cboSysAdm2.SetItemData(ViewModel.cboSysAdm2.GetNewIndex(), Convert.ToInt32(CommonCodes.SecurityCode["security_code"]));
                        CommonCodes.SecurityCode.MoveNext();
                    }
                    ;
                    ViewModel.cboSysAdm2.Visible = true;
                    ViewModel.cmdSysButt3.Text = "Search..";
                    ViewModel.cmdSysButt3.Visible = true;

                    break;
                case "Update Personnel Security":
                    ViewModel.lbSysAdmin1.Text = "Select Personnel:";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.lbSysAdmin2.Text = "Select Security Type:";
                    ViewModel.lbSysAdmin2.Visible = true;
                    ViewModel.cboSysAdm1.Items.Clear();
                    ViewModel.cboSysAdm2.Items.Clear();
                    PersonnelCL.GetAllPersonnelList();

                    while (!PersonnelCL.OperationsList.EOF)
                    {
                        ViewModel.cboSysAdm2.AddItem(IncidentMain.Clean(PersonnelCL.OperationsList["name_full"]) + " -" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]));
                        PersonnelCL.OperationsList.MoveNext();
                    }
                    ;
                    CommonCodes.GetSecurityCode();

                    while (!CommonCodes.SecurityCode.EOF)
                    {
                        ViewModel.cboSysAdm1.AddItem(IncidentMain.Clean(CommonCodes.SecurityCode["description"]));
                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), Convert.ToInt32(CommonCodes.SecurityCode["security_code"]));
                        CommonCodes.SecurityCode.MoveNext();
                    }
                    ;
                    ViewModel.cboSysAdm1.Visible = true;
                    ViewModel.cboSysAdm2.Visible = true;
                    ViewModel.cmdSysButt1.Text = "Update Security";
                    ViewModel.cmdSysButt1.Visible = true;

                    break;
                case "Change Splash Message":
                    ViewModel.lbSysAdmin1.Text = "Enter New Message";
                    ViewModel.txtSysAdm1.Text = "";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.txtSysAdm1.Visible = true;
                    ViewModel.lbSysAdmin2.Text = "OR - Select New Active Message";
                    ViewModel.lbSysAdmin2.Visible = true;
                    CommonCodes.GetIRSMessageRS();
                    ViewModel.cboSysAdm1.Items.Clear();

                    while (!CommonCodes.IRSMessage.EOF)
                    {
                        ViewModel.cboSysAdm1.AddItem(IncidentMain.Clean(CommonCodes.IRSMessage["message_text"]));
                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), Convert.ToInt32(CommonCodes.IRSMessage["message_id"]));
                        CommonCodes.IRSMessage.MoveNext();
                    }
                    ;
                    ViewModel.cboSysAdm1.Visible = true;
                    ViewModel.cmdSysButt1.Visible = true;
                    ViewModel.cmdSysButt1.Text = "Add/Update";
                    ViewModel.cmdSysButt2.Text = "Delete";
                    ViewModel.cmdSysButt2.Visible = true;
                    ViewModel.cmdSysButt3.Visible = false;

                    break;
                case "Manage Notification System":
                    ViewModel.lbSysAdmin1.Text = "Select Notification List:";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.cboSysAdm1.Visible = true;
                    ViewModel.lbSysAdmin2.Text = "Select Notification Receiver:";
                    ViewModel.lbSysAdmin2.Visible = true;
                    ViewModel.cboSysAdm2.Visible = true;
                    ViewModel.cmdSysButt3.Text = "View ...";
                    ViewModel.cmdSysButt3.Visible = true;
                    ViewModel.cmdSysButt1.Visible = true;
                    ViewModel.cmdSysButt1.Text = "Add New Receiver";
                    ViewModel.cmdSysButt2.Visible = true;
                    ViewModel.cmdSysButt2.Text = "Delete Receiver";
                    NotifyCL.GetNotificationReceiverTypeCodes();

                    while (!NotifyCL.NotificationReceiverTypeCode.EOF)
                    {
                        ViewModel.cboSysAdm2.AddItem(IncidentMain.Clean(NotifyCL.NotificationReceiverTypeCode["description"]));
                        ViewModel.cboSysAdm2.SetItemData(ViewModel.cboSysAdm2.GetNewIndex(), Convert.ToInt32(NotifyCL.NotificationReceiverTypeCode["notification_receiver_type"]));
                        NotifyCL.NotificationReceiverTypeCode.MoveNext();
                    }
                    ;
                    PersonnelCL.GetAllPersonnelList();

                    while (!PersonnelCL.OperationsList.EOF)
                    {
                        ViewModel.cboSysAdm1.AddItem(IncidentMain.Clean(PersonnelCL.OperationsList["name_full"]) + " -" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]));
                        PersonnelCL.OperationsList.MoveNext();
                    }
                    ;
                    break;
                case "Update Help Files":
                    FillHelpList();
                    ViewModel.txtHelpTitle.Text = "";
                    ViewModel.txtHelpText.Text = "";
                    ViewModel.frmAdmHelp.Visible = true;
                    ViewModel.cmdSysButt1.Visible = true;
                    ViewModel.cmdSysButt1.Text = "Update Help";

                    break;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboType.SelectedIndex == -1)
            {
                return;
            }
            if (~ViewModel.DontRespond != 0)
            {
                LoadUnitList();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboType.SelectedIndex == -1)
            {
                ViewModel.cboType.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboUnit.SelectedIndex == -1)
            {
                return;
            }

            if (~ViewModel.DontRespond != 0)
            {
                ViewModel.DontRespond = -1;
                ViewModel.optBattalion[0].Checked = false;
                ViewModel.optBattalion[0].Enabled = false;
                ViewModel.optBattalion[1].Checked = false;
                ViewModel.optBattalion[1].Enabled = false;
                ViewModel.optBattalion[2].Checked = false;
                ViewModel.optBattalion[2].Enabled = false;

                LoadUnitList();
                ViewModel.DontRespond = 0;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboUnit_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboUnit.SelectedIndex == -1)
            {
                ViewModel.cboUnit.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClearIncident_Click(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.cboIncUnit.SelectedIndex = -1;
            ViewModel.cboIncType.SelectedIndex = -1;
            LoadIncidentList();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClearSelections_Click(Object eventSender, System.EventArgs eventArgs)
        {
            cboInquiryList_SelectionChangeCommitted(ViewModel.cboInquiryList, new System.EventArgs());
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClearUnit_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Clear all Filters and Reload Grid
            ViewModel.DontRespond = -1;
            ViewModel.cboUnit.SelectedIndex = -1;
            ViewModel.cboUnit.Enabled = true;
            ViewModel.cboType.SelectedIndex = -1;
            ViewModel.cboStatus.SelectedIndex = -1;
            ViewModel.optBattalion[0].Checked = false;
            ViewModel.optBattalion[1].Checked = false;
            ViewModel.optBattalion[2].Checked = false;
            ViewModel.optBattalion[0].Enabled = true;
            ViewModel.optBattalion[1].Enabled = true;
            ViewModel.optBattalion[2].Enabled = true;
            ViewModel.DontRespond = 0;
            LoadUnitList();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdExit2_Click(Object eventSender, System.EventArgs eventArgs)
        {
            Environment.Exit(0);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdExitApp_Click(Object eventSender, System.EventArgs eventArgs)
        {
            Environment.Exit(0);
        }

        //[UpgradeHelpers.Events.Handler]
        //internal void cmdRefreshIncident_Click(Object eventSender, System.EventArgs eventArgs)
        //{
        //    LoadIncidentList();
        //    LoadUnitList();

        //}

        [UpgradeHelpers.Events.Handler]
        internal void cmdRefreshIncList_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //    LoadUnitList
            LoadIncidentList();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRefreshUnit_Click(Object eventSender, System.EventArgs eventArgs)
        {
            LoadUnitList();
            //    LoadIncidentList

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSysButt1_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //Determine Action Based on currently selected activity

                if (ViewModel.cboSystemAction.SelectedIndex == -1)
                {
                    this.Return();
                    return;
                }
                TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
                TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
                TFDIncident.clsNotification NotifyCL = Container.Resolve<clsNotification>();
                string EmpID = "";
                int SecCode = 0;
                int NotifyType = 0;
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

                clsCommonCodes cCommon = null;
                using (var async2 = this.Async())
                {

                    switch (ViewModel.cboSystemAction.Text)
                    {
                        case "Update Personnel Security":
                            if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select Security Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                this.Return();
                                return;
                            }
                            else if (ViewModel.cboSysAdm2.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select Personnel", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                this.Return();
                                return;
                            }
                            else
                            {
                                EmpID = ViewModel.cboSysAdm2.Text.Substring(Math.Max(ViewModel.cboSysAdm2.Text.Length - 5, 0));
                                SecCode = ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex);
                                if (~IncidentCL.UpdateIncidentSecurity(ref EmpID, ref SecCode) != 0)
                                {
                                    ViewManager.ShowMessage("Error Attempting to Update Security", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                            ) => ViewManager.ShowMessage("Security Updated.  Would you like to update additional Personnel Security Settings?", "IRS System Administration"
                                                , UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async2.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.No)
                                            {
                                                ClearSystemAdmin();
                                            }
                                        });
                                }
                            }

                            break;
                        case "Change Splash Message":
                            if (ViewModel.txtSysAdm1.Text == "")
                            {
                                if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                                {
                                    ViewManager.ShowMessage("Please make Selection", "TFD IRS Sys Adm Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                }
                                else
                                {
                                    if (~CommonCodes.UpdateIRSMessage(ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex)) != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Splash Message", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Splash Message Updated", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                    }
                                }
                            }
                            else
                            {
                                if (~CommonCodes.InsertIRSMessage(ViewModel.txtSysAdm1.Text.Trim()) != 0)
                                {
                                    ViewManager.ShowMessage("Error adding new Splash Message", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    this.Return();
                                    return;
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Splash Message Updated", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                }
                            }
                            ClearSystemAdmin();

                            break;
                        case "View Security Listing":
                            //Print Displayed Security Listing 
                            //UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprSysAdm.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                            ViewModel.sprSysAdm.setPrintAbortMsg("Printing Security Listing - Click Cancel to quit");
                            //UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprSysAdm.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                            ViewModel.sprSysAdm.setPrintBorder(false);
                            //UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprSysAdm.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                            ViewModel.sprSysAdm.setPrintColor(true);
                            //UPGRADE_ISSUE: (2064) FPSpread.PrintOrientationConstants property PrintOrientationConstants.PrintOrientationPortrait was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                            //UPGRADE_ISSUE: (2064) FPSpread.vaSpread property sprSysAdm.PrintOrientation was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                            ViewModel.sprSysAdm.setPrintOrientation(UpgradeStubs.FPSpread_PrintOrientationConstants.getPrintOrientationPortrait());
                            ViewModel.sprSysAdm.Action = FarPoint.ViewModels.FPActionConstants.ActionSmartPrint;

                            break;
                        case "Manage Notification System":
                            if (ViewModel.cboSysAdm2.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select a Notification List", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            else if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select a Notification Receiver", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            //Check to make sure that the selected Employee is not already on the list 
                            EmpID = ViewModel.cboSysAdm1.Text.Substring(Math.Max(ViewModel.cboSysAdm1.Text.Length - 5, 0));
                            NotifyType = ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex);
                            if (NotifyCL.GetNotificationReceiver(EmpID) != 0)
                            {

                                while (!NotifyCL.NotificationReceiver.EOF)
                                {
                                    if (Convert.ToDouble(NotifyCL.NotificationReceiver["notification_receiver_type"]) == NotifyType)
                                    {
                                        ViewManager.ShowMessage("Selected Employee is already a member of this Notification list", "IRS System Administration", UpgradeHelpers.Helpers
                                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                        this.Return();
                                        return;
                                    }
                                    NotifyCL.NotificationReceiver.MoveNext();
                                };
                            }
                            //Add New Notification Receiver 
                            if (~NotifyCL.AddNotificationReceiver(EmpID, NotifyType) != 0)
                            {
                                ViewManager.ShowMessage("Error attempting to add new Notification Receiver", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else if (ViewModel.sprNotify.Visible)
                            {
                                FillSysReports();
                            }

                            break;
                        case "Update Help Files":
                            if (IncidentMain.Clean(ViewModel.txtHelpTitle.Text) == "")
                            {
                                ViewManager.ShowMessage("Please Enter Topic Title", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            else if (IncidentMain.Clean(ViewModel.txtHelpText.Text) == "")
                            {
                                ViewManager.ShowMessage("Please Enter Help Text", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            cCommon = Container.Resolve<clsCommonCodes>();
                            if (~cCommon.UpdateIRSHelp(ViewModel.CurrentHelpID, IncidentMain.Clean(ViewModel.txtHelpTitle.Text), IncidentMain.Clean(ViewModel.txtHelpText)) != 0)
                            {
                                ViewManager.ShowMessage("Error attempting to update Help File", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }


                            break;
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSysButt2_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //Determine Action Based on currently selected activity

                if (ViewModel.cboSystemAction.SelectedIndex == -1)
                {
                    this.Return();
                    return;
                }
                TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
                TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
                TFDIncident.clsNotification NotifyCL = Container.Resolve<clsNotification>();
                TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();
                int WorkReport = 0, RefReport = 0;
                int StatusCode = 0;
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                int OldType = 0;
                string sMessage = "", EmpID = "";
                int NotifyType = 0;
                using (var async2 = this.Async())
                {



                    switch (ViewModel.cboSystemAction.Text)
                    {
                        case "Delete Report":
                            if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select Report to Delete", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            sMessage = "You are about to irrevocably delete all records pertaining to this report." + "\n";
                            sMessage = sMessage + "Are you absolutely, positively, without doubts or second thoughts" + "\n";
                            sMessage = sMessage + "Sure that you wish to proceed?";
                            WorkReport = ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex);
                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(sMessage, "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                {
                                    Response = tempNormalized1;
                                });
                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                            {
                                if (~ReportLog.DeleteReport(WorkReport) != 0)
                                {
                                    ViewManager.ShowMessage("Error Attempting to Delete Report", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    this.Return();
                                    return;
                                }
                                else
                                {
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                            => ViewManager.ShowMessage("Report Deleted.  Do you need to delete more reports?", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized2 => tempNormalized2);
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 =>
                                        {
                                            Response = tempNormalized3;
                                        });
                                    async2.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                FillSysReports();
                                            }
                                            else
                                            {
                                                ClearSystemAdmin();
                                            }
                                        });
                                }
                            }
                            break;
                        case "Update Personnel Security":

                            break;
                        case "Change Splash Message":
                            if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please make Selection", "TFD IRS Sys Adm Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                this.Return();
                                return;
                            }
                            else
                            {
                                if (~CommonCodes.DeleteIRSMessage(ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex)) != 0)
                                {
                                    ViewManager.ShowMessage("Error Deleting Splash Message", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Splash Message Deleted", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                                }
                            }
                            ClearSystemAdmin();
                            break;
                        case "Reset Report Status":
                            if (ViewModel.cboSysAdm1.SelectedIndex == -1 || ViewModel.cboSysAdm2.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select Report and New Status", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            WorkReport = ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex);
                            if (~ReportLog.GetReportLog(WorkReport) != 0)
                            {
                                ViewManager.ShowMessage("Error Resetting Report Status", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            else
                            {
                                RefReport = ReportLog.ReportReferenceID;
                                StatusCode = ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex);
                                if (~ReportLog.UpdateStatus(ref WorkReport, RefReport, StatusCode) != 0)
                                {
                                    ViewManager.ShowMessage("Error Attempting to Reset Report Status", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    this.Return();
                                    return;
                                }
                                else
                                {
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                            ) => ViewManager.ShowMessage("Report Status Reset.  Do you need to reset more reports?", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized4 => tempNormalized4);
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized5 =>
                                        {
                                            Response = tempNormalized5;
                                        });
                                    async2.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                FillSysReports();
                                            }
                                            else
                                            {
                                                ClearSystemAdmin();
                                            }
                                        });
                                }
                            }
                            break;
                        case "Change EMS Report Type":
                            if (ViewModel.cboSysAdm1.SelectedIndex == -1 || ViewModel.cboSysAdm2.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select Report and New Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            WorkReport = ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex);
                            if (~ReportLog.GetReportLog(WorkReport) != 0)
                            {
                                ViewManager.ShowMessage("Error Changing EMS Report Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            else
                            {
                                RefReport = ReportLog.ReportReferenceID;
                                StatusCode = ViewModel.cboSysAdm1.GetItemData(ViewModel.cboSysAdm1.SelectedIndex);
                                if (~EMScl.GetEMSPatientContact(RefReport) != 0)
                                {
                                    ViewManager.ShowMessage("Error Changing EMS Report Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    this.Return();
                                    return;
                                }
                                else
                                {
                                    sMessage = "This action could result in the permanent deletion of existing EMS records" + "\n";
                                    sMessage = sMessage + "Related to this report.  You sure you wish to proceed?";
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage(sMessage, "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized6 => tempNormalized6);
                                    async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized7 =>
                                        {
                                            Response = tempNormalized7;
                                        });
                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                    {
                                        OldType = EMScl.ActionTaken;
                                        EMScl.ActionTaken = StatusCode;
                                        if (~EMScl.UpdateEMSPatientContact() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Changing EMS Report Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            this.Return();
                                            return;
                                        }
                                        if (StatusCode == 3 || StatusCode == 4 || StatusCode == 5)
                                        {
                                            //Delete Possible Child records
                                            EMScl.DeleteEMSPatientContactSubReports(ref RefReport);
                                        }
                                        else if (StatusCode == 1 || StatusCode == 7)
                                        {
                                            if (OldType == 2 || OldType == 6 || OldType == 8)
                                            {
                                                //Delete Possible Child Records
                                                EMScl.DeleteEMSProcedureAll(ref RefReport);
                                                EMScl.DeleteEMSCPRPerformerAll(ref RefReport);
                                                EMScl.DeleteEMSCPR(ref RefReport);
                                                EMScl.DeleteEMSMedicationAll(ref RefReport);
                                                EMScl.DeleteEMSTraumaDescriptor(ref RefReport);
                                                EMScl.DeleteEMSPatientTrauma(ref RefReport);
                                                EMScl.DeleteEMSPatientIVLine(ref RefReport);
                                                EMScl.DeleteEMSPatientIVLine(ref RefReport);
                                                if (StatusCode == 1)
                                                {
                                                    EMScl.DeleteEMSPatientTransport(ref RefReport);
                                                }
                                            }
                                        }
                                        else if (StatusCode == 6 || StatusCode == 8)
                                        {
                                            //Delete Possible Transport Record
                                            EMScl.DeleteEMSPatientTransport(ref RefReport);
                                        }
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                ) => ViewManager.ShowMessage("EMS Report Action Type Reset.  Do you need to reset more reports?", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized8 => tempNormalized8);
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized9 =>
                                            {
                                                Response = tempNormalized9;
                                            });
                                        async2.Append(() =>
                                            {
                                                if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                                {
                                                    FillSysReports();
                                                }
                                                else
                                                {
                                                    ClearSystemAdmin();
                                                }
                                            });
                                    }
                                }
                            }

                            break;
                        case "Manage Notification System":
                            if (ViewModel.cboSysAdm2.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select a Notification List", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            else if (ViewModel.cboSysAdm1.SelectedIndex == -1)
                            {
                                ViewManager.ShowMessage("Please Select a Notification Receiver", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            //Check to make sure that the selected Employee is currently on the list 
                            EmpID = ViewModel.cboSysAdm1.Text.Substring(Math.Max(ViewModel.cboSysAdm1.Text.Length - 5, 0));
                            NotifyType = ViewModel.cboSysAdm2.GetItemData(ViewModel.cboSysAdm2.SelectedIndex);
                            if (NotifyCL.GetNotificationReceiver(EmpID) != 0)
                            {

                                while (!NotifyCL.NotificationReceiver.EOF)
                                {
                                    if (Convert.ToDouble(NotifyCL.NotificationReceiver["notification_receiver_type"]) == NotifyType)
                                    {
                                        //Delete Notification Receiver
                                        if (~NotifyCL.DeleteNotificationReceiver(EmpID, NotifyType) != 0)
                                        {
                                            ViewManager.ShowMessage("Error attempting to Delete Notification Receiver", "IRS System Administration", UpgradeHelpers.Helpers.
                                                BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            this.Return();
                                            return;
                                        }
                                        else
                                        {
                                            if (ViewModel.sprNotify.Visible)
                                            {
                                                FillSysReports();
                                            }
                                            this.Return();
                                            return;
                                        }
                                    }
                                    NotifyCL.NotificationReceiver.MoveNext();
                                };
                            }

                            break;
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSysButt3_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Determine Action Based on currently selected activity

            if (ViewModel.cboSystemAction.SelectedIndex == -1)
            {
                return;
            }
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsEMSCodes EMSCodes = Container.Resolve<clsEMSCodes>();


            switch (ViewModel.cboSystemAction.Text)
            {
                case "Delete Report":
                    if (FillSysReports() != 0)
                    {
                        ViewModel.lbSysAdmin2.Text = "Select Report:";
                        ViewModel.lbSysAdmin2.Visible = true;
                        ViewModel.cboSysAdm1.Visible = true;
                        ViewModel.lbSysAdmin3.Text = "Existing Incident Reports:";
                        ViewModel.lbSysAdmin3.Visible = true;
                        ViewModel.sprSysAdm.Visible = true;
                        ViewModel.cmdSysButt2.Text = "Delete";
                        ViewModel.cmdSysButt2.Visible = true;
                    }
                    else
                    {
                        ViewManager.ShowMessage("No Reports Found for this Incident", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }

                    break;
                case "Change EMS Report Type":
                    if (FillSysReports() != 0)
                    {
                        ViewModel.cboSysAdm1.Items.Clear();
                        EMSCodes.GetActionTakenCodes();

                        while (!EMSCodes.ActionTakenCodes.EOF)
                        {
                            ViewModel.cboSysAdm1.AddItem(IncidentMain.Clean(EMSCodes.ActionTakenCodes["action_taken_description"]));
                            ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), Convert.ToInt32(EMSCodes.ActionTakenCodes["action_taken_code"]));
                            EMSCodes.ActionTakenCodes.MoveNext();
                        }
                        ;
                        ViewModel.txtSysAdm1.Visible = false;
                        ViewModel.lbSysAdmin1.Text = "Select Report:";
                        ViewModel.lbSysAdmin1.Visible = true;
                        ViewModel.lbSysAdmin2.Text = "Select New Action Type:";
                        ViewModel.lbSysAdmin2.Visible = true;
                        ViewModel.cboSysAdm1.Visible = true;
                        ViewModel.cboSysAdm2.Visible = true;
                        ViewModel.lbSysAdmin3.Text = "Existing EMS Reports:";
                        ViewModel.lbSysAdmin3.Visible = true;
                        ViewModel.sprSysAdm.Visible = true;
                        ViewModel.cmdSysButt2.Text = "Reset Type";
                        ViewModel.cmdSysButt2.Visible = true;
                    }
                    else
                    {
                        ViewManager.ShowMessage("No Reports Found for this Incident", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }
                    break;
                case "Reset Report Status":
                    ViewModel.lbSysAdmin1.Text = "Select Report:";
                    ViewModel.lbSysAdmin1.Visible = true;
                    ViewModel.lbSysAdmin2.Text = "Select New Status:";
                    ViewModel.lbSysAdmin2.Visible = true;
                    ViewModel.txtSysAdm1.Visible = false;
                    if (FillSysReports() != 0)
                    {
                        ViewModel.cboSysAdm1.Items.Clear();
                        ViewModel.cboSysAdm1.AddItem("INCOMPLETE");
                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), 1);
                        ViewModel.cboSysAdm1.AddItem("SAVED INCOMPLETE");
                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), 2);
                        ViewModel.cboSysAdm1.AddItem("COMPLETE");
                        ViewModel.cboSysAdm1.SetItemData(ViewModel.cboSysAdm1.GetNewIndex(), 3);
                        ViewModel.cboSysAdm1.Visible = true;
                        ViewModel.cboSysAdm2.Visible = true;
                        ViewModel.lbSysAdmin3.Text = "Existing Incident Reports:";
                        ViewModel.lbSysAdmin3.Visible = true;
                        ViewModel.sprSysAdm.Visible = true;
                        ViewModel.cmdSysButt2.Text = "Reset Status";
                        ViewModel.cmdSysButt2.Visible = true;
                    }
                    else
                    {
                        ViewManager.ShowMessage("No Reports Found for this Incident", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }
                    break;
                case "View Security Listing":
                    if (ViewModel.cboSysAdm2.SelectedIndex == -1)
                    {
                        ViewManager.ShowMessage("Please Select a Security Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                        return;
                    }
                    FillSysReports();
                    ViewModel.sprSysAdm.Visible = true;
                    ViewModel.cmdSysButt1.Text = "Print";
                    ViewModel.cmdSysButt1.Visible = true;

                    break;
                case "Manage Notification System":
                    if (ViewModel.cboSysAdm2.SelectedIndex == -1)
                    {
                        ViewManager.ShowMessage("Please Select a Notification List Type", "IRS System Administration", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                        return;
                    }
                    FillSysReports();
                    ViewModel.sprNotify.Visible = true;
                    break;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdView_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Create and Run SQL Select Statement
            //If Results Returned pass to global gQueryRecordset
            //And Open frmQueryResults -
            //Otherwise inform user that no records were returned
            //This Procedure uses a separate ADODB Connection that
            //Has a longer query time out parameter

            //Check to determine if request for viewing query results
            //or a precanned report - if report exit to report function

            //9/20/02 - SM
            //Check for Summarry Report - handle differently to get data and totals

            if (ViewModel.cmdView.Text == "View Report")
            {
                GenerateReport();
                return;
            }

            DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
            ADORecordSetHelper orec = null;
            int InquiryID = 0;
            TFDIncident.clsInquiry InquiryCL = Container.Resolve<clsInquiry>();
            string SqlString = "";
            int FilterCount = 0, CurrFilter = 0;
            int DateFlag = 0;
            string WorkString = "";
            int CodeStart = 0;
            int F2Total = 0, F1Total = 0, F3Total = 0;
            string GroupByClause = "";
            StringBuilder WhereClause = new System.Text.StringBuilder();


            try
            {

                InquiryID = ViewModel.cboInquiryList.GetItemData(ViewModel.cboInquiryList.SelectedIndex);
                InquiryCL.GetInquiryManager(InquiryID);
                ocmd.Connection = IncidentMain.oIncident;
                ocmd.CommandType = CommandType.Text;
                if (~ViewModel.SummaryReportFlag != 0)
                {
                    SqlString = "select ";
                    for (int i = 0; i <= ViewModel.lstFields.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstFields.GetSelected(i))
                        {
                            InquiryCL.GetInquiryFields(ViewModel.lstFields.GetItemData(i));
                            SqlString = SqlString + InquiryCL.FieldName + ",";
                        }
                    }
                    SqlString = SqlString.Substring(0, Math.Min(Strings.Len(SqlString) - 1, SqlString.Length));
                    SqlString = SqlString + " from " + InquiryCL.InquiryView;

                    FilterCount = 0;
                    DateFlag = 0;
                    for (int i = 0; i <= ViewModel.lstFilters.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstFilters.GetSelected(i))
                        {
                            FilterCount++;
                            InquiryCL.GetInquiryFields(ViewModel.lstFilters.GetItemData(i));
                            if (InquiryCL.FlagDate != 0)
                            {
                                DateFlag = -1;
                            }
                        }
                    }

                    if (FilterCount != 0)
                    {
                        if (DateFlag != 0)
                        {
                            if (Information.IsDate(ViewModel.calInquiry1.Value))
                            {
                                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                SqlString = SqlString + " where " + Convert.ToString(ViewModel.lbCal1.Tag) + " >= '";
                                //UPGRADE_WARNING: (1068) calInquiry1.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                SqlString = SqlString + Convert.ToDateTime(ViewModel.calInquiry1.Value).ToString("M/d/yyyy") + "' and ";
                                //UPGRADE_WARNING: (1068) calInquiry2.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                SqlString = SqlString + Convert.ToString(ViewModel.lbCal2.Tag) + " <= '" + Convert.ToDateTime(ViewModel.calInquiry2.Value).AddDays(1).ToString("M/d/yyyy") + "'";
                                FilterCount--;
                                CurrFilter = 0;

                                while (FilterCount != 0)
                                {
                                    if (Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) != "")
                                    {
                                        if (ViewModel.txtFilter[CurrFilter].Visible && IncidentMain.Clean(ViewModel.txtFilter[CurrFilter].Text) != "")
                                        {
                                            SqlString = SqlString + " and ";
                                            SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                            SqlString = SqlString + " like ('%" + ViewModel.txtFilter[CurrFilter].Text + "%')";
                                        }
                                        else if (ViewModel.cboFilter[CurrFilter].SelectedIndex != -1)
                                        {
                                            if (ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex) == 0)
                                            {
                                                SqlString = SqlString + " and ";
                                                SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                                WorkString = ViewModel.cboFilter[CurrFilter].Text;
                                                CodeStart = (WorkString.IndexOf(':') + 1) + 2;
                                                WorkString = WorkString.Substring(CodeStart - 1, Math.Min(Strings.Len(WorkString) - CodeStart + 1, WorkString.Length - (CodeStart - 1)));
                                                SqlString = SqlString + " = '" + WorkString + "'";
                                            }
                                            else
                                            {
                                                SqlString = SqlString + " and ";
                                                SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) + " = ";
                                                SqlString = SqlString + ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex).ToString() + " ";
                                            }
                                        }
                                    }
                                    CurrFilter++;
                                    FilterCount--;
                                };
                            }
                            else
                            {
                                CurrFilter = 0;

                                while (FilterCount != 0)
                                {
                                    if (Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) != "")
                                    {
                                        if (ViewModel.txtFilter[CurrFilter].Visible && IncidentMain.Clean(ViewModel.txtFilter[CurrFilter].Text) != "")
                                        {
                                            if (CurrFilter == 0)
                                            {
                                                SqlString = SqlString + " where ";
                                            }
                                            else
                                            {
                                                SqlString = SqlString + " and ";
                                            }
                                            SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                            SqlString = SqlString + " like ('%" + ViewModel.txtFilter[CurrFilter].Text + "%')";
                                        }
                                        else if (ViewModel.cboFilter[CurrFilter].SelectedIndex != -1)
                                        {
                                            if (ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex) == 0)
                                            {
                                                if (CurrFilter == 0)
                                                {
                                                    SqlString = SqlString + " where ";
                                                }
                                                else
                                                {
                                                    SqlString = SqlString + " and ";
                                                }
                                                SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                                WorkString = ViewModel.cboFilter[CurrFilter].Text;
                                                CodeStart = (WorkString.IndexOf(':') + 1) + 2;
                                                WorkString = WorkString.Substring(CodeStart - 1, Math.Min(Strings.Len(WorkString) - CodeStart + 1, WorkString.Length - (CodeStart - 1)));
                                                SqlString = SqlString + " = '" + WorkString + "'";
                                            }
                                            else
                                            {
                                                if (CurrFilter == 0)
                                                {
                                                    SqlString = SqlString + " where ";
                                                }
                                                else
                                                {
                                                    SqlString = SqlString + " and ";
                                                }
                                                SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) + " = ";
                                                SqlString = SqlString + ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex).ToString() + " ";
                                            }
                                        }
                                    }
                                    CurrFilter++;
                                    FilterCount--;
                                };
                            }
                        }
                        else
                        {
                            CurrFilter = 0;

                            while (FilterCount != 0)
                            {
                                if (Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) != "")
                                {
                                    if (ViewModel.txtFilter[CurrFilter].Visible && IncidentMain.Clean(ViewModel.txtFilter[CurrFilter].Text) != "")
                                    {
                                        if (CurrFilter == 0)
                                        {
                                            SqlString = SqlString + " where ";
                                        }
                                        else
                                        {
                                            SqlString = SqlString + " and ";
                                        }
                                        SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                        SqlString = SqlString + " like ('%" + ViewModel.txtFilter[CurrFilter].Text + "%')";
                                    }
                                    else if (ViewModel.cboFilter[CurrFilter].SelectedIndex != -1)
                                    {
                                        if (ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex) == 0)
                                        {
                                            if (CurrFilter == 0)
                                            {
                                                SqlString = SqlString + " where ";
                                            }
                                            else
                                            {
                                                SqlString = SqlString + " and ";
                                            }
                                            SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag);
                                            WorkString = ViewModel.cboFilter[CurrFilter].Text;
                                            CodeStart = (WorkString.IndexOf(':') + 1) + 2;
                                            WorkString = WorkString.Substring(CodeStart - 1, Math.Min(Strings.Len(WorkString) - CodeStart + 1, WorkString.Length - (CodeStart - 1)));
                                            SqlString = SqlString + " = '" + WorkString + "'";
                                        }
                                        else
                                        {
                                            if (CurrFilter == 0)
                                            {
                                                SqlString = SqlString + " where ";
                                            }
                                            else
                                            {
                                                SqlString = SqlString + " and ";
                                            }
                                            SqlString = SqlString + Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) + " = ";
                                            SqlString = SqlString + ViewModel.cboFilter[CurrFilter].GetItemData(ViewModel.cboFilter[CurrFilter].SelectedIndex).ToString() + " ";
                                        }
                                    }
                                }
                                CurrFilter++;
                                FilterCount--;
                            };
                        }
                    }

                    SqlString = SqlString + " " + InquiryCL.InquiryOrderBy;
                    ocmd.CommandText = SqlString;
                    ocmd.CommandTimeout = 240;
                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
                    this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
                    orec = ADORecordSetHelper.Open(ocmd, "");
                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
                    this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
                    if (orec.EOF)
                    {
                        ViewManager.ShowMessage("There were no records returned from this query", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons
                            .OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }
                    else
                    {
                        IncidentMain.Shared.gQueryRecordset = orec;
                        IncidentMain.Shared.gCurrentQuery = InquiryID;
                        ViewManager.NavigateToView(
                            frmQueryResults.DefInstance);
                    }

                }
                else
                {
                    //Process Summary Report Request
                    SqlString = "SELECT ";
                    WhereClause = new System.Text.StringBuilder(" WHERE ");
                    GroupByClause = "";

                    //First determine if date parameters have been selected
                    DateFlag = 0;
                    IncidentMain.Shared.gQueryStartDate = "";
                    IncidentMain.Shared.gQueryEndDate = "";

                    for (int i = 0; i <= ViewModel.lstFilters.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstFilters.GetSelected(i))
                        {
                            InquiryCL.GetInquiryFields(ViewModel.lstFilters.GetItemData(i));
                            if (InquiryCL.FlagDate != 0)
                            {
                                if (Information.IsDate(ViewModel.calInquiry1.Value))
                                {
                                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                    WhereClause.Append(Convert.ToString(ViewModel.lbCal1.Tag) + " >= '");
                                    //UPGRADE_WARNING: (1068) calInquiry1.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                    WhereClause.Append(Convert.ToDateTime(ViewModel.calInquiry1.Value).ToString("M/d/yyyy") + "' AND ");
                                    //UPGRADE_WARNING: (1068) calInquiry1.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                    IncidentMain.Shared.gQueryStartDate = Convert.ToDateTime(ViewModel.calInquiry1.Value).ToString("M/d/yyyy");
                                    //UPGRADE_WARNING: (1068) calInquiry2.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                    WhereClause.Append(Convert.ToString(ViewModel.lbCal2.Tag) + " <= '" + Convert.ToDateTime(ViewModel.calInquiry2.Value).AddDays(1).ToString("M/d/yyyy") + "' ");
                                    //UPGRADE_WARNING: (1068) calInquiry2.Value of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.MonthCalendar.SelectionStart was not upgraded
                                    IncidentMain.Shared.gQueryEndDate = Convert.ToDateTime(ViewModel.calInquiry2.Value).AddDays(1).ToString("M/d/yyyy");
                                    DateFlag = -1;
                                    break;
                                }
                            }
                        }
                    }
                    //Now Add Selected Fields
                    CurrFilter = 0;
                    for (int i = 0; i <= ViewModel.lstFilters.Items.Count - 1; i++)
                    {
                        InquiryCL.GetInquiryFields(ViewModel.lstFilters.GetItemData(i));
                        if (InquiryCL.FlagDate == 0)
                        {
                            SqlString = SqlString + InquiryCL.FieldName + ",";
                            GroupByClause = GroupByClause + InquiryCL.FieldName + ",";
                            if (ViewModel.lstFilters.GetSelected(i))
                            { //Use Filter
                                if (DateFlag != 0)
                                {
                                    WhereClause.Append(" AND ");
                                }
                                if (Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) != "")
                                {
                                    if (ViewModel.txtFilter[CurrFilter].Visible && IncidentMain.Clean(ViewModel.txtFilter[CurrFilter].Text) != "")
                                    {
                                        WhereClause.Append(Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag));
                                        WhereClause.Append(" like ('%" + ViewModel.txtFilter[CurrFilter].Text + "%')");
                                    }
                                    else if (ViewModel.cboFilter[CurrFilter].SelectedIndex != -1)
                                    {
                                        WhereClause.Append(Convert.ToString(ViewModel.lbFilter[CurrFilter].Tag) + " = '");
                                        WhereClause.Append(ViewModel.cboFilter[CurrFilter].Text + "'");
                                    }
                                }
                                CurrFilter++;
                                DateFlag = -1;
                            }
                        }
                    }
                    GroupByClause = GroupByClause.Substring(0, Math.Min(Strings.Len(GroupByClause) - 1, GroupByClause.Length)); //Remove last comma
                    SqlString = SqlString + "Count(*) AS sum_total "; //Add aggregate
                    SqlString = SqlString + " FROM  " + InquiryCL.InquiryView;
                    if (WhereClause.ToString() != " WHERE ")
                    {
                        SqlString = SqlString + WhereClause.ToString();
                    }
                    SqlString = SqlString + " GROUP BY " + GroupByClause;
                    SqlString = SqlString + " ORDER BY " + GroupByClause;
                    ocmd.CommandText = SqlString;
                    ocmd.CommandTimeout = 240;
                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
                    this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
                    orec = ADORecordSetHelper.Open(ocmd, "");
                    //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
                    this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
                    if (orec.EOF)
                    {
                        ViewManager.ShowMessage("There were no records returned from this query", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons
                            .OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }
                    else
                    {
                        IncidentMain.Shared.gQueryRecordset = orec;
                        IncidentMain.Shared.gCurrentQuery = InquiryID;
                        ViewManager.NavigateToView(
                            frmQueryResults.DefInstance);
                    }
                }
            }
            catch (Exception e)
            {

                //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                if (UpgradeHelpers.Helpers.Information.Err().Number == -2147217871)
                {
                    ViewManager.ShowMessage("Your Query has Timed Out - Please Filter Data Request", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                }
                else
                {
                    ViewManager.ShowMessage("An Error has Occured in Attempting to Process Your Query", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
                UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdViewReport_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            ViewManager.NavigateToView(
                frmFieldReport.DefInstance);
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
        }

        //UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

        private void Form_Load()
        {
            //Initialize Form Level Attributes

            IncidentMain
                .Shared.gAppCancel = 0;
            ViewModel.lbIncidentMain.Text = "";
            LoadLists();
            ViewModel.calUnit.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")), DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));
            LoadUnitList();
            ViewModel.calIncident.SelectionRange = Container.Resolve<UpgradeHelpers.BasicViewModels.SelectionRange>(DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")), DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));
            LoadIncidentList();
            ViewModel.SummaryReportFlag = 0;
        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
            IncidentMain.Shared.gAppCancel = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstFields_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Check to determine if [View Results] button can be enabled
            //Check to load filters if Summary Selections are made
            TFDIncident.clsInquiry InquiryCL = Container.Resolve<clsInquiry>();
            int ItemSelected = 0;
            int InquiryID = 0;

            if (ViewModel.cboInquiryList.SelectedIndex == -1)
            {
                return;
            }

            if (ViewModel.SummaryReportFlag != 0)
            {
                InquiryID = ViewModel.cboInquiryList.GetItemData(ViewModel.cboInquiryList.SelectedIndex);
                if (~InquiryCL.GetInquiryFieldsRS(InquiryID) != 0)
                {
                    ViewManager.ShowMessage("Error Retreiving Summary Item Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    return;
                }
                else
                {
                    ViewModel.cmdClearSelections.Visible = true;
                    ViewModel.lstFilters.Visible = true;
                    ViewModel.lbFilterFields.Visible = true;
                    ViewModel.lstFilters.Items.Clear();
                    for (int i = 0; i <= ViewModel.lstFields.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstFields.GetSelected(i))
                        {
                            InquiryCL.InquiryFields.MoveFirst();

                            while (!InquiryCL.InquiryFields.EOF)
                            {
                                if (Convert.ToDouble(InquiryCL.InquiryFields["inquiry_field_id"]) == ViewModel.lstFields.GetItemData(i))
                                {
                                    ViewModel.lstFilters.AddItem(IncidentMain.Clean(InquiryCL.InquiryFields["field_display"]));
                                    ViewModel.lstFilters.SetItemData(ViewModel.lstFilters.GetNewIndex(), Convert.ToInt32(InquiryCL.InquiryFields["inquiry_field_id"]));
                                    break;
                                }
                                InquiryCL.InquiryFields.MoveNext();
                            };
                        }
                    }
                }
                //Check for Number of fields selected - only allow 2
                ItemSelected = 0;
                for (int i = 0; i <= ViewModel.lstFields.Items.Count - 1; i++)
                {
                    if (ViewModel.lstFields.GetSelected(i))
                    {
                        ItemSelected++;
                    }
                    if (ItemSelected == 3)
                    {
                        ViewModel.lstFields.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                ItemSelected = 0;
                for (int i = 0; i <= ViewModel.lstFields.Items.Count - 1; i++)
                {
                    if (ViewModel.lstFields.GetSelected(i))
                    {
                        for (int x = 0; x <= ViewModel.lstFilters.Items.Count - 1; x++)
                        {
                            if (ViewModel.lstFilters.GetSelected(x))
                            {
                                ItemSelected = -1;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            ViewModel.cmdView.Enabled = ItemSelected != 0;

        }

        [UpgradeHelpers.Events.Handler]
        internal void lstFilters_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Display or Hide Filter Selection Controls
            //Check to determine if [View Results] button can be enabled
            TFDIncident.clsInquiry InquiryCL = Container.Resolve<clsInquiry>();
            int InqFieldID = 0;
            string SqlString = "", CodeString = "";
            DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
            ADORecordSetHelper orec = null;

            int CurrFilter = 0;
            ocmd.Connection = IncidentMain.oIncident;
            ocmd.CommandType = CommandType.Text;

            InitializeQueryForm();

            int ItemSelected = 0;
            for (int i = 0; i <= ViewModel.lstFilters.Items.Count - 1; i++)
            {
                if (ViewModel.lstFilters.GetSelected(i))
                {
                    for (int x = 0; x <= ViewModel.lstFields.Items.Count - 1; x++)
                    {
                        if (ViewModel.lstFields.GetSelected(x))
                        {
                            ItemSelected = -1;
                            break;
                        }
                    }
                    break;
                }
            }
            ViewModel.cmdView.Enabled = ItemSelected != 0;

            for (int i = 0; i <= ViewModel.lstFilters.Items.Count - 1; i++)
            {
                if (ViewModel.lstFilters.GetSelected(i))
                {
                    InqFieldID = ViewModel.lstFilters.GetItemData(i);
                    if (~InquiryCL.GetInquiryFields(InqFieldID) != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Retrieve Filter Information", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    else
                    {
                        if (InquiryCL.FlagDate != 0)
                        {
                            ViewModel.lbCal1.Text = "Starting " + InquiryCL.FieldDisplay + " For Query";
                            ViewModel.lbCal2.Text = "Ending " + InquiryCL.FieldDisplay + " For Query";
                            ViewModel.lbCal1.Visible = true;
                            ViewModel.lbCal2.Visible = true;
                            ViewModel.lbCal1.Tag = InquiryCL.FieldName;
                            ViewModel.lbCal2.Tag = InquiryCL.FieldName;
                            ViewModel.calInquiry1.Visible = true;
                            ViewModel.calInquiry2.Visible = true;
                        }
                        else if (InquiryCL.CodeView != "")
                        {
                            ViewModel.lbFilter[CurrFilter].Text = InquiryCL.FieldDisplay;
                            ViewModel.lbFilter[CurrFilter].Tag = InquiryCL.FieldName;
                            ViewModel.lbFilter[CurrFilter].Visible = true;
                            ocmd.CommandText = "select * from " + InquiryCL.CodeView;
                            orec = ADORecordSetHelper.Open(ocmd, "");
                            if (!orec.EOF)
                            {

                                while (!orec.EOF)
                                {
                                    if (InquiryCL.CodeDataType == "I")
                                    {
                                        ViewModel.cboFilter[CurrFilter].AddItem(IncidentMain.Clean(orec.GetField(1)));
                                        ViewModel.cboFilter[CurrFilter].SetItemData(ViewModel.cboFilter[CurrFilter].GetNewIndex(), Convert.ToInt32(orec[0]));
                                    }
                                    else
                                    {
                                        ViewModel.cboFilter[CurrFilter].AddItem(IncidentMain.Clean(orec.GetField(1)) + ": " + IncidentMain.Clean(orec.GetField(0)));
                                    }
                                    orec.MoveNext();
                                };
                                ViewModel.cboFilter[CurrFilter].Visible = true;
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Retrieving Filter Codes", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            CurrFilter++;
                        }
                        else
                        {
                            ViewModel.lbFilter[CurrFilter].Text = InquiryCL.FieldDisplay;
                            ViewModel.lbFilter[CurrFilter].Tag = InquiryCL.FieldName;
                            ViewModel.lbFilter[CurrFilter].Visible = true;
                            ViewModel.txtFilter[CurrFilter].Visible = true;
                            CurrFilter++;
                        }
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void optBattalion_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                if (~ViewModel.DontRespond != 0)
                {
                    ViewModel.DontRespond = -1;
                    ViewModel.cboUnit.SelectedIndex = -1;
                    ViewModel.cboUnit.Enabled = false;
                    LoadUnitList();
                    ViewModel.DontRespond = 0;
                }
            }
        }


        public void sprIncident_CellDoubleClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
        {
            int Col = eventArgs.Column;
            int Row = eventArgs.Row;
            //Set CurrIncident and Call FormatIncidentSelector
            ViewModel.sprIncident.Row = Row;
            ViewModel.sprIncident.Col = 7;
            ViewModel.CurrIncident = Convert.ToInt32(Conversion.Val(ViewModel.sprIncident.Text));

            FormatIncidentSelector();

        }


        private void sprIncReports_CellDoubleClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
        {
            int Col = eventArgs.Column;
            int Row = eventArgs.Row;
            //Open Selected Report
            //Column 2 holds report_log_id
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            ViewModel.sprIncReports.Row = Row;
            ViewModel.sprIncReports.Col = 2;
            if (ViewModel.sprIncReports.Text == "")
            {
                return;
            }
            IncidentMain.Shared.gEditReportID = Convert.ToInt32(Conversion.Val(ViewModel.sprIncReports.Text));

            //Determine Report Type To Display
            ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID);

            //Check for Report Security
            if (~IncidentMain.CheckReportSecurity(IncidentMain.Shared.gEditReportID) != 0)
            {
                //No Access Security for this report
                ViewManager.ShowMessage("No Security Clearance for this Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                return;
            }
            switch (ReportLog.ReportType)
            {
                case 2:
                case 33:
                    //Incident - Situation Found & Incident Address Correction 
                    ViewManager.NavigateToView(
                        //Incident - Situation Found & Incident Address Correction 
                        frmIncident.DefInstance);
                    IncidentMain.MoveForm(frmIncident.DefInstance);
                    FormatIncidentSelector();
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 11:
                case 12:
                case 13:
                case 14:
                    //Fire or Rupture 
                    ViewManager.NavigateToView(
                        //Fire or Rupture 
                        frmFireReport.DefInstance);
                    IncidentMain.MoveForm(frmFireReport.DefInstance);
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 31:
                    //Hazmat 
                    ViewManager.NavigateToView(
                        //Hazmat 
                        frmHazmatReport.DefInstance);
                    IncidentMain.MoveForm(frmHazmatReport.DefInstance);
                    break;
                case 15:
                    //EMS 
                    ViewManager.NavigateToView(
                        //EMS 
                        frmEMSReport.DefInstance);
                    IncidentMain.MoveForm(frmEMSReport.DefInstance);
                    break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    //All other reports 
                    ViewManager.NavigateToView(
                        //All other reports 
                        frmOtherReports.DefInstance);
                    IncidentMain.MoveForm(frmOtherReports.DefInstance);
                    break;
                case 27:
                    //Show Incendiary Form 
                    break;
                case 28:
                case 29:
                    //Show Juvenile Form 
                    break;
            }

            ReportLog = null;

        }

        internal void sprUnitList_CellDoubleClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                var ActiveRow = ViewModel.sprUnitList.ActiveRow;
                int Col = eventArgs.Column;
                int Row = eventArgs.Row;
                //Test to determine if New Report Wizard Launched
                int ReportID = 0;
                TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
                //ViewModel.sprUnitList.Row = Row;
                //ViewModel.sprUnitList.Col = 7;
                if (Conversion.Val(ViewModel.sprUnitList.Text) == 0)
                {
                    this.Return();
                    return;
                }
                else
                {
                    IncidentMain.Shared.gWizardIncidentID = Convert.ToInt32(Conversion.Val(ViewModel.sprUnitList.Text));
                }
                //ViewModel.sprUnitList.Col = 2;
                IncidentMain.Shared.gWizardUnitID = ViewModel.sprUnitList.Text;

                if (ViewModel.sprUnitList.ForeColor.Value != IncidentMain.Shared.RED.Value)
                {
                    ViewManager.ShowMessage("No Incomplete Reports Outstanding - Please Use Report Editing Tab to Update Existing Reports", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                    this.Return();
                    return;
                }

                if (IncidentMain.CheckUnitSecurity(IncidentMain.Shared.gWizardIncidentID, IncidentMain.Shared.gWizardUnitID) != 0)
                {
                    async1.Append(() =>
                        {
                            ViewManager.NavigateToView(
                                wzdMain.DefInstance, true);
                        });
                    async1.Append(() =>
                    {
                        LoadUnitList();
                    });
                }
                else
                {
                    ViewManager.ShowMessage("No Security Clearance for this Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                }
            }


        }

        private void sprUnitReports_CellDoubleClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
        {
            int Col = eventArgs.Column;
            int Row = eventArgs.Row;
            //Open Selected Report
            //Column 2 holds report_log_id
            ViewModel.sprUnitReports.Row = Row;
            ViewModel.sprUnitReports.Col = 2;

            if (ViewModel.sprUnitReports.Text == "")
            {
                return;
            }
            IncidentMain.Shared.gEditReportID = Convert.ToInt32(Double.Parse(ViewModel.sprUnitReports.Text));
            ViewModel.sprUnitReports.Col = 1;
            IncidentMain.Shared.gCurrUnit = ViewModel.sprUnitReports.Text;
            //Check for Report Security
            if (~IncidentMain.CheckReportSecurity(IncidentMain.Shared.gEditReportID) != 0)
            {
                //No Access Security for this report
                ViewManager.ShowMessage("No Security Clearance for this Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                return;
            }
            ViewManager.NavigateToView(
                frmIncident.DefInstance);
            IncidentMain.MoveForm(frmIncident.DefInstance);

        }


        [UpgradeHelpers.Events.Handler]
        internal void tvHelpList_AfterSelect(Object eventSender, UpgradeHelpers.BasicViewModels.TreeNodeViewModel eventArgs)
        {
            UpgradeHelpers.BasicViewModels.TreeNodeViewModel Node = eventArgs;
            TFDIncident.clsCommonCodes cCommon = Container.Resolve<clsCommonCodes>();
            int HelpID = 0;

            //UPGRADE_WARNING: (1068) Node.Tag of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
            double dbNumericTemp = 0;
            if (Double.TryParse(Convert.ToString(Node.Get_Tag()), NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                //UPGRADE_WARNING: (1068) Node.Tag of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.TreeNode.Tag was not upgraded
                HelpID = Convert.ToInt32(Node.Get_Tag());
                if (HelpID == 0)
                {
                    return;
                } //Report Title Node
                if (cCommon.GetHelpByID(HelpID) != 0)
                {
                    IncidentMain.Shared.gHelpScreen = Convert.ToInt32(cCommon.HelpText["screen_id"]);
                    IncidentMain.Shared.gHelpControl = Convert.ToInt32(cCommon.HelpText["control_id"]);
                }
                else
                {
                    IncidentMain.Shared.gHelpScreen = 0;
                    IncidentMain.Shared.gHelpControl = 0;
                }
            }
            else
            {
                IncidentMain.Shared.gHelpScreen = 0;
                IncidentMain.Shared.gHelpControl = 0;
            }
            GetHelpText();

        }

        [UpgradeHelpers.Events.Handler]
        internal void MainTabs_Selecting(object sender, EventArgs e)
        {
            //Change Tab Colors for Each Tab
            switch (ViewModel.MainTabs.SelectedIndex)
            {
                case 3:
                    if (IncidentMain.Shared.gSystemSecurity != IncidentMain.ADMINISTRATOR)
                    {
                        if (IncidentMain.Shared.gSystemSecurity != IncidentMain.FIREADMIN && IncidentMain.Shared.gSystemSecurity != IncidentMain.INSPECTOR)
                        {
                            ViewModel.MainTabs.SelectedIndex = ViewModel.MainTabs.TabIndex;
                        }
                    }
                    break;
                case 4:
                    if (IncidentMain.Shared.gSystemSecurity != IncidentMain.ADMINISTRATOR)
                    {
                        ViewModel.MainTabs.SelectedIndex = ViewModel.MainTabs.TabIndex;
                    }
                    break;
            }
        }

        public static frmMain DefInstance
        {
            get
            {
                if (Shared.m_vb6FormDefInstance == null)
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

        public static frmMain CreateInstance()
        {
            TFDIncident.frmMain theInstance = Shared.Container.Resolve<frmMain>();
            theInstance.Form_Load();
            //The MDI form in the VB6 project had its
            //AutoShowChildren property set to True
            //To simulate the VB6 behavior, we need to
            //automatically Show the form whenever it
            //is loaded.  If you do not want this behavior
            //then delete the following line of code
            //UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
            Shared.ViewManager.NavigateToView(
                //The MDI form in the VB6 project had its
                //AutoShowChildren property set to True
                //To simulate the VB6 behavior, we need to
                //automatically Show the form whenever it
                //is loaded.  If you do not want this behavior
                //then delete the following line of code
                //UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: http://www.vbtonet.com/ewis/ewi2018.aspx
                theInstance
                );
            return theInstance;
        }

        void ReLoadForm(bool addEvents)
        {
            using (var async1 = this.Async(true))
            {
                async1.Append<TFDIncident.MDIIncident>(() => TFDIncident.MDIIncident.DefInstance);
                //This form is an MDI child.
                //This code simulates the VB6 
                // functionality of automatically
                // loading and showing an MDI
                // child's parent.
                ;
                async1.Append<TFDIncident.MDIIncident>(() =>
                    TFDIncident.MDIIncident.DefInstance);
                async1.Append<TFDIncident.MDIIncident>(tempNormalized1 =>
                    {
                        ViewManager.NavigateToView(tempNormalized1);
                    });
            }
        }

        protected override void ExecuteControlsStartup()
        {
            ViewModel.tabPage5.LifeCycleStartup();
            ViewModel.tabPage4.LifeCycleStartup();
            ViewModel.tabPage3.LifeCycleStartup();
            ViewModel.tabPage2.LifeCycleStartup();
            ViewModel.tabPage1.LifeCycleStartup();
            ViewModel.MainTabs.LifeCycleStartup();
            ViewModel.Shape4.LifeCycleStartup();
            ViewModel.Shape1.LifeCycleStartup();
            ViewModel.Shape3.LifeCycleStartup();
            ViewModel.sprNotify.LifeCycleStartup();
            ViewModel.sprSysAdm.LifeCycleStartup();
            ViewModel.sprNoteLog.LifeCycleStartup();
            ViewModel.sprUnitReports.LifeCycleStartup();
            ViewModel.sprIncReports.LifeCycleStartup();
            ViewModel.sprIncident.LifeCycleStartup();
            ViewModel.sprUnitList.LifeCycleStartup();
            ViewModel.frmAdmHelp.LifeCycleStartup();
            base.ExecuteControlsStartup();
            this.DynamicControlsStartup();
        }

        protected override void ExecuteControlsShutdown()
        {
            ViewModel.tabPage5.LifeCycleShutdown();
            ViewModel.tabPage4.LifeCycleShutdown();
            ViewModel.tabPage3.LifeCycleShutdown();
            ViewModel.tabPage2.LifeCycleShutdown();
            ViewModel.tabPage1.LifeCycleShutdown();
            ViewModel.MainTabs.LifeCycleShutdown();
            ViewModel.Shape4.LifeCycleShutdown();
            ViewModel.Shape1.LifeCycleShutdown();
            ViewModel.Shape3.LifeCycleShutdown();
            ViewModel.sprNotify.LifeCycleShutdown();
            ViewModel.sprSysAdm.LifeCycleShutdown();
            ViewModel.sprNoteLog.LifeCycleShutdown();
            ViewModel.sprUnitReports.LifeCycleShutdown();
            ViewModel.sprIncReports.LifeCycleShutdown();
            ViewModel.sprIncident.LifeCycleShutdown();
            ViewModel.sprUnitList.LifeCycleShutdown();
            ViewModel.frmAdmHelp.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class frmMain
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmMainViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual frmMain m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }


    public class ItemsUnitGrid
    : UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(ItemsUnitGrid));
        }

        public virtual string Unit { get; set; }
        public virtual string Incident_Number { get; set; }
        public virtual string Time { get; set; }
        public virtual string Location { get; set; }
        public virtual string Type { get; set; }
        public virtual string IncidentId { get; set; }
        public virtual string ResportStatus { get; set; }


        public string UniqueID { get; set; }

        public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

        public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

    }

}