using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Helpers;

namespace TFDIncident
{

    public partial class wzdMain
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdMainViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        //TFD Incident Reporting System - Report Entry Wizard - Development Prototype

        //*****************************
        //** Module Level Variables  **
        //*****************************

        //Current Focus Objects
        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(wzdMain));
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


        //*******************************
        //** Module Level Subroutines  **
        //** And Functions             **
        //*******************************

        private int SaveAddressCorrection(int UType)
        {
            //Save Incident Address correction
            int result = 0;
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

            result = -1;
            IncidentCL.IACIncidentID = ViewModel.CurrIncident;
            IncidentCL.IACHouseNumber = IncidentMain.Clean(ViewModel.txtXHouseNumber.Text);
            if (ViewModel.cboXPrefix.SelectedIndex != -1)
            {
                IncidentCL.IACPrefix = ViewModel.cboXPrefix.Text;
            }
            else
            {
                IncidentCL.IACPrefix = "";
            }

            IncidentCL.IACStreet = IncidentMain.Clean(ViewModel.txtXStreetName.Text);
            if (ViewModel.cboXStreetType.SelectedIndex != -1)
            {
                IncidentCL.IACStreetType = ViewModel.cboXStreetType.Text;
            }
            else
            {
                IncidentCL.IACStreetType = "";
            }
            if (ViewModel.cboXSuffix.SelectedIndex != -1)
            {
                IncidentCL.IACSuffix = ViewModel.cboXSuffix.Text;
            }
            else
            {
                IncidentCL.IACSuffix = "";
            }
            if (ViewModel.cboCityCode.SelectedIndex == -1)
            {
                IncidentCL.IACCityCode = "";
            }
            else
            {
                IncidentCL.IACCityCode = ViewModel.cboCityCode.Text.Substring(0, Math.Min(3, ViewModel.cboCityCode.Text.Length));
            }
            string WorkString = IncidentCL.IACHouseNumber + " ";
            if (IncidentCL.IACPrefix != "")
            {
                WorkString = WorkString + IncidentCL.IACPrefix + " ";
            }
            WorkString = WorkString + IncidentCL.IACStreet + " ";
            WorkString = WorkString + IncidentCL.IACStreetType + " ";
            if (IncidentCL.IACSuffix != "")
            {
                WorkString = WorkString + IncidentCL.IACSuffix;
            }
            if (IncidentCL.IACCityCode != "")
            {
                WorkString = WorkString + " ," + IncidentCL.IACCityCode;
            }
            IncidentCL.IACAmendedLocation = WorkString;

            if (IncidentCL.GetAddressCorrection(ViewModel.CurrIncident) != 0)
            {
                if (~IncidentCL.UpdateIncidentAddressCorrection() != 0)
                {
                    result = 0;
                }
                else
                {
                    //Update Reportlog
                    if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                            {
                                var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UType);
                                ViewModel.CurrReportLogID = p1;
                                return ret;
                            }, ViewModel.CurrReportLogID) != 0)
                    {
                        ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                }
            }
            else
            {
                if (~IncidentCL.AddIncidentAddressCorrection() != 0)
                {
                    result = 0;
                }
                else
                {
                    //Update Reportlog
                    if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                            {
                                var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UType);
                                ViewModel.CurrReportLogID = p1;
                                return ret;
                            }, ViewModel.CurrReportLogID) != 0)
                    {
                        ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                }
            }

            return result;
        }

        private void LoadAddressCorrection()
        {
            object sDisplay = null;
            //Load Address Correction Frame
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            ViewModel.DontRespond = -1;
            ViewModel.txtXHouseNumber.Text = "";
            ViewModel.cboXPrefix.Items.Clear();
            ViewModel.txtXStreetName.Text = "";
            ViewModel.cboXStreetType.Items.Clear();
            ViewModel.cboXSuffix.Items.Clear();
            ViewModel.cboCityCode.Items.Clear();

            CommonCodes.GetAddressVerification("X");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboXPrefix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboXSuffix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            };

            CommonCodes.GetAddressVerification("S");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboXStreetType.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            };
            CommonCodes.GetCityCode();

            while (!CommonCodes.CityCode.EOF)
            {
                sDisplay = CommonCodes.CityCode["city_code"];
                //UPGRADE_WARNING: (1068) sDisplay of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                if (Strings.Len(Convert.ToString(sDisplay)) < 3)
                {
                    //UPGRADE_WARNING: (1068) sDisplay of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                    sDisplay = Convert.ToString(sDisplay) + " ";
                }
                //UPGRADE_WARNING: (1068) sDisplay of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                sDisplay = Convert.ToString(sDisplay) + ": " + IncidentMain.Clean(CommonCodes.CityCode["city_name"]);
                //UPGRADE_WARNING: (1068) sDisplay of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                ViewModel.cboCityCode.AddItem(Convert.ToString(sDisplay));
                CommonCodes.CityCode.MoveNext();
            };
            //Default to Tacoma
            for (int i = 0; i <= ViewModel.cboCityCode.Items.Count - 1; i++)
            {
                if (ViewModel.cboCityCode.GetListItem(i).StartsWith("TAC"))
                {
                    ViewModel.cboCityCode.SelectedIndex = i;
                    break;
                }
            }
            ViewModel.DontRespond = 0;

        }

        private void LoadPPEList()
        {
            //Load Listbox with FSCasualtyFailedEquipment Records
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            string sDisplay = "";
            ViewModel.cmdRemovePPE.Enabled = false;
            ViewModel.lstPPE.Items.Clear();
            if (Casualty.GetFSCasualtyFailedEquipment(ViewModel.CurrReportID) != 0)
            {

                while (!Casualty.FSCasualtyFailedEquipment.EOF)
                {
                    sDisplay = IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["equip_descrip"]) + " - ";
                    sDisplay = sDisplay + IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["status_descrip"]) + " - ";
                    sDisplay = sDisplay + IncidentMain.Clean(Casualty.FSCasualtyFailedEquipment["problem_descrip"]);
                    ViewModel.lstPPE.AddItem(sDisplay);
                    ViewModel.lstPPE.SetItemData(ViewModel.lstPPE.GetNewIndex(), Convert.ToInt32(Casualty.FSCasualtyFailedEquipment["FPE_failure_id"]));
                    Casualty.FSCasualtyFailedEquipment.MoveNext();
                };
                ViewModel.cmdRemovePPE.Enabled = true;
                ViewModel.chkFPEProblem.Enabled = false;
            }
            else
            {
                ViewModel.chkFPEProblem.Enabled = true;
            }

            CheckComplete();

        }

        private void LockUnitScreen()
        {
            //Disable Data Entry Controls if user is not Author or Admin
            ViewModel.lstActionsTaken.Enabled = false;
            ViewModel.lstReasonDelay.Enabled = false;
            ViewModel.rtxUnitNarration.Enabled = false;
            ViewModel.cmdAddStaff.Enabled = false;
            for (int i = 0; i <= 6; i++)
            {
                ViewModel.cboPersonnel[i].Enabled = false;
                ViewModel.cboPosition[i].Enabled = false;
                ViewModel.chkCasualty[i].Enabled = false;
            }
            ViewModel.cboPersonnel[7].Enabled = false;
            ViewModel.chkCasualty[7].Enabled = false;

            for (int i = 1; i <= 5; i++)
            {
                ViewModel.txtAmendTime[i].Enabled = false;
                ViewModel.cboAmendReason[i].Enabled = false;
            }

        }

        private int SaveCivilianCasualty(int UpdateType)
        {
            //Create New Civilian Casualty Report Record
            //Update ReportLog
            int result = 0;
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

            result = -1;
            Casualty.CivIncidentID = ViewModel.CurrIncident;
            if (ViewModel.cboEMSPatient.SelectedIndex != -1)
            {
                Casualty.CivPatientID = ViewModel.cboEMSPatient.GetItemData(ViewModel.cboEMSPatient.SelectedIndex);
            }
            else
            {
                Casualty.CivPatientID = 0;
            }

            if (ViewModel.cboSeverity.SelectedIndex != -1)
            {
                Casualty.CivInjurySeverity = ViewModel.cboSeverity.GetItemData(ViewModel.cboSeverity.SelectedIndex);
            }
            else
            {
                Casualty.CivInjurySeverity = 0;
            }

            if (ViewModel.cboInjuryCause.SelectedIndex != -1)
            {
                Casualty.CivInjuryCausedBy = ViewModel.cboInjuryCause.GetItemData(ViewModel.cboInjuryCause.SelectedIndex);
            }
            else
            {
                Casualty.CivInjuryCausedBy = 0;
            }

            if (ViewModel.cboCCLocation.SelectedIndex != -1)
            {
                Casualty.CivInjuryLocation = ViewModel.cboCCLocation.GetItemData(ViewModel.cboCCLocation.SelectedIndex);
            }
            else
            {
                Casualty.CivInjuryLocation = 0;
            }
            Casualty.CivInjuryFloor = Convert.ToInt32(Conversion.Val(ViewModel.txtFloor.Text));

            if (~Casualty.AddCivilianCasualty() != 0)
            {
                return 0;
            }
            //Save Sub Tables
            int tempRefParam = Casualty.CivCasualtyID;
            Casualty.DeleteCivContributingFactor(ref tempRefParam);
            Casualty.CFCasualtyID = Casualty.CivCasualtyID;
            for (int i = 0; i <= ViewModel.lstContribFactors.Items.Count - 1; i++)
            {
                if (ViewModel.lstContribFactors.GetSelected(i))
                {
                    Casualty.CFContributingFactor = ViewModel.lstContribFactors.GetItemData(i);
                    Casualty.AddCivContributingFactor();
                }
            }

            int tempRefParam2 = Casualty.CivCasualtyID;
            Casualty.DeleteCivHumanFactor(ref tempRefParam2);
            Casualty.CHCasualtyID = Casualty.CivCasualtyID;
            for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
            {
                if (ViewModel.lstHumanContribFactors.GetSelected(i))
                {
                    Casualty.CHHumanFactor = ViewModel.lstHumanContribFactors.GetItemData(i);
                    Casualty.AddCivHumanFactor();
                }
            }

            //Save Narration - if any
            SaveNarration();
            //Update ReportLog
            if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret = ReportLog.UpdateStatus(ref p1, Casualty.CivCasualtyID, UpdateType);
                        ViewModel.CurrReportLogID = p1;
                        return ret;
                    }, ViewModel.CurrReportLogID) != 0)
            {
                ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                result = 0;
            }

            return result;
        }

        private void LoadFSCasualty()
        {
            //Load List and combos for FS Casualty & FPE frames
            //Retrieve Existing record and display data
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            TFDIncident.clsEMSCodes EMSCodes = Container.Resolve<clsEMSCodes>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            ViewModel.DontResponse = -1;
            ViewModel.rtxNarrative.Text = "";
            ViewModel.rtxRecommend.Text = "";
            ViewModel.chkFPEProblem.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.cboActivity.Items.Clear();
            Casualty.GetActivityCode();

            while (!Casualty.ActivityCode.EOF)
            {
                ViewModel.cboActivity.AddItem(IncidentMain.Clean(Casualty.ActivityCode["description"]));
                ViewModel.cboActivity.SetItemData(ViewModel.cboActivity.GetNewIndex(), Convert.ToInt32(Casualty.ActivityCode["activity_code"]));
                Casualty.ActivityCode.MoveNext();
            }
            ;
            ViewModel.cboWhereOccured.Items.Clear();
            Casualty.GetWhereOccuredCode();

            while (!Casualty.WhereOccuredCode.EOF)
            {
                ViewModel.cboWhereOccured.AddItem(IncidentMain.Clean(Casualty.WhereOccuredCode["description"]));
                ViewModel.cboWhereOccured.SetItemData(ViewModel.cboWhereOccured.GetNewIndex(), Convert.ToInt32(Casualty.WhereOccuredCode["where_occured_code"]));
                Casualty.WhereOccuredCode.MoveNext();
            }
            ;
            ViewModel.cboInjuryCausedBy.Items.Clear();
            Casualty.GetInjuryCausedByCode();

            while (!Casualty.InjuryCausedByCode.EOF)
            {
                ViewModel.cboInjuryCausedBy.AddItem(IncidentMain.Clean(Casualty.InjuryCausedByCode["description"]));
                ViewModel.cboInjuryCausedBy.SetItemData(ViewModel.cboInjuryCausedBy.GetNewIndex(), Convert.ToInt32(Casualty.InjuryCausedByCode["injury_caused_by_code"]));
                Casualty.InjuryCausedByCode.MoveNext();
            }
            ;
            ViewModel.cboLocationAtInjury.Items.Clear();
            Casualty.GetInjuryLocationCode();

            while (!Casualty.InjuryLocationCode.EOF)
            {
                ViewModel.cboLocationAtInjury.AddItem(IncidentMain.Clean(Casualty.InjuryLocationCode["description"]));
                ViewModel.cboLocationAtInjury.SetItemData(ViewModel.cboLocationAtInjury.GetNewIndex(), Convert.ToInt32(Casualty.InjuryLocationCode["injury_location_code"]));
                Casualty.InjuryLocationCode.MoveNext();
            }
            ;
            ViewModel.cboInjurySeverity.Items.Clear();
            Casualty.GetInjurySeverity();

            while (!Casualty.InjurySeverityCode.EOF)
            {
                ViewModel.cboInjurySeverity.AddItem(IncidentMain.Clean(Casualty.InjurySeverityCode["description"]));
                ViewModel.cboInjurySeverity.SetItemData(ViewModel.cboInjurySeverity.GetNewIndex(), Convert.ToInt32(Casualty.InjurySeverityCode["injury_severity_code"]));
                Casualty.InjurySeverityCode.MoveNext();
            }
            ;
            ViewModel.cboBodyPart.Items.Clear();
            EMSCodes.GetInjuryDetailCodesByType("B");

            while (!EMSCodes.InjuryDetailCodes.EOF)
            {
                ViewModel.cboBodyPart.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
                ViewModel.cboBodyPart.SetItemData(ViewModel.cboBodyPart.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
                EMSCodes.InjuryDetailCodes.MoveNext();
            }
            ;
            ViewModel.cboInjuryType.Items.Clear();
            EMSCodes.GetInjuryDetailCodesByType("I");

            while (!EMSCodes.InjuryDetailCodes.EOF)
            {
                ViewModel.cboInjuryType.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
                ViewModel.cboInjuryType.SetItemData(ViewModel.cboInjuryType.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
                EMSCodes.InjuryDetailCodes.MoveNext();
            }
            ;
            ViewModel.lstContributingFactors.Items.Clear();
            Casualty.GetFSCasualtyContributingFactorCode();

            while (!Casualty.FSCasualtyContributingFactorCode.EOF)
            {
                ViewModel.lstContributingFactors.AddItem(IncidentMain.Clean(Casualty.FSCasualtyContributingFactorCode["description"]));
                ViewModel.lstContributingFactors.SetItemData(ViewModel.lstContributingFactors.GetNewIndex(), Convert.ToInt32(Casualty.FSCasualtyContributingFactorCode["fs_casualty_contributing_factor_code"]));
                Casualty.FSCasualtyContributingFactorCode.MoveNext();
            }
            ;
            ViewModel.cboFPEEquipment.Items.Clear();
            ViewModel.cboFPEStatus.Items.Clear();
            ViewModel.cboFPEProblem.Items.Clear();
            ViewModel.lstPPE.Items.Clear();
            ViewModel.cmdAddPPE.Enabled = false;
            ViewModel.cmdRemovePPE.Enabled = false;

            Casualty.GetFPECodeRS();

            while (!Casualty.FPECodeRS.EOF)
            {
                ViewModel.cboFPEEquipment.AddItem(IncidentMain.Clean(Casualty.FPECodeRS["Description"]));
                ViewModel.cboFPEEquipment.SetItemData(ViewModel.cboFPEEquipment.GetNewIndex(), Convert.ToInt32(Casualty.FPECodeRS["FPE_Code_ID"]));
                Casualty.FPECodeRS.MoveNext();
            }
            ;

            //Retrieve Existing Record
            if (~Casualty.GetFSCasualty(ViewModel.CurrReportID) != 0)
            {
                ViewManager.ShowMessage("Error Attempting to Retrieve Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            else
            {
                PersonnelCL.GetEmployeeRecord(Casualty.EmployeeID);
                ViewModel.lbEmployee.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
                IncidentCL.GetIncident(Casualty.IncidentID);
                ViewModel.lbIncident.Text = IncidentCL.IncidentNumber;
                ViewModel.lbCasualtyDate.Text = DateTime.Parse(Casualty.CasualtyDate).ToString("M/d/yyyy");
            }
            ViewModel.DontResponse = 0;

        }

        private void LoadCivilianCasualty()
        {
            //Load list and combo boxes for Civilian Casualty frame
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string ListDisplay = "";
            ViewModel.cboEMSPatient.Items.Clear();
            if (EMSReport.GetIncidentEMSPatients(ViewModel.CurrIncident) != 0)
            {

                while (!EMSReport.IncidentEMSPatients.EOF)
                {
                    ListDisplay = IncidentMain.Clean(EMSReport.IncidentEMSPatients["name_last"]) + ", " + IncidentMain.Clean(EMSReport.IncidentEMSPatients["name_first"]);
                    if (ListDisplay == ", ")
                    {
                        ListDisplay = "No Patient Name Available";
                    }
                    ViewModel.cboEMSPatient.AddItem(ListDisplay);
                    ViewModel.cboEMSPatient.SetItemData(ViewModel.cboEMSPatient.GetNewIndex(), Convert.ToInt32(EMSReport.IncidentEMSPatients["pat_id"]));
                    EMSReport.IncidentEMSPatients.MoveNext();
                };
            }
            ViewModel.cboSeverity.Items.Clear();
            Casualty.GetInjurySeverity();

            while (!Casualty.InjurySeverityCode.EOF)
            {
                ViewModel.cboSeverity.AddItem(IncidentMain.Clean(Casualty.InjurySeverityCode["description"]));
                ViewModel.cboSeverity.SetItemData(ViewModel.cboSeverity.GetNewIndex(), Convert.ToInt32(Casualty.InjurySeverityCode["injury_severity_code"]));
                Casualty.InjurySeverityCode.MoveNext();
            }
            ;
            ViewModel.cboInjuryCause.Items.Clear();
            Casualty.GetInjuryCausedByCode();

            while (!Casualty.InjuryCausedByCode.EOF)
            {
                ViewModel.cboInjuryCause.AddItem(IncidentMain.Clean(Casualty.InjuryCausedByCode["description"]));
                ViewModel.cboInjuryCause.SetItemData(ViewModel.cboInjuryCause.GetNewIndex(), Convert.ToInt32(Casualty.InjuryCausedByCode["injury_caused_by_code"]));
                Casualty.InjuryCausedByCode.MoveNext();
            }
            ;
            ViewModel.cboCCLocation.Items.Clear();
            Casualty.GetInjuryLocationCode();

            while (!Casualty.InjuryLocationCode.EOF)
            {
                ViewModel.cboCCLocation.AddItem(IncidentMain.Clean(Casualty.InjuryLocationCode["description"]));
                ViewModel.cboCCLocation.SetItemData(ViewModel.cboCCLocation.GetNewIndex(), Convert.ToInt32(Casualty.InjuryLocationCode["injury_location_code"]));
                Casualty.InjuryLocationCode.MoveNext();
            }
            ;
            ViewModel.lstHumanContribFactors.Items.Clear();
            Casualty.GetCivilianHumanFactorCode();

            while (!Casualty.CivilianHumanFactorCode.EOF)
            {
                ViewModel.lstHumanContribFactors.AddItem(IncidentMain.Clean(Casualty.CivilianHumanFactorCode["description"]));
                ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(Casualty.CivilianHumanFactorCode["civilian_human_factor_code"]));
                Casualty.CivilianHumanFactorCode.MoveNext();
            }
            ;
            ViewModel.lstContribFactors.Items.Clear();
            Casualty.GetCasualtyContributingFactorCode();

            while (!Casualty.CasualtyContributingFactorCode.EOF)
            {
                ViewModel.lstContribFactors.AddItem(IncidentMain.Clean(Casualty.CasualtyContributingFactorCode["description"]));
                ViewModel.lstContribFactors.SetItemData(ViewModel.lstContribFactors.GetNewIndex(), Convert.ToInt32(Casualty.CasualtyContributingFactorCode["casualty_contributing_factor_code"]));
                Casualty.CasualtyContributingFactorCode.MoveNext();
            }
            ;

        }

        private int SaveCasualty(string EmpID, string sUnit, int UType)
        {
            //Create ReportLog record and FSCasualty Record
            int result = 0;
            TFDIncident.clsCasualty CasualtyCL = Container.Resolve<clsCasualty>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsNotification NotificationCL = Container.Resolve<clsNotification>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            string NoteMsg = "";

            result = -1;
            if (ViewModel.CurrReport != IncidentMain.FSCASUALTY)
            {
                //Add New Fire Service Casualty Record and ReportLog record
                CasualtyCL.IncidentID = ViewModel.CurrIncident;
                CasualtyCL.EmployeeID = EmpID;
                CasualtyCL.CasualtyDate = ViewModel.lbURDate.Text;
                CasualtyCL.Activity = 0;
                CasualtyCL.WhereOccurred = 0;
                CasualtyCL.InjuryCausedBy = 0;
                CasualtyCL.InjurySeverity = 0;
                CasualtyCL.BodyPartInjured = 0;
                CasualtyCL.InjuryType = 0;
                CasualtyCL.InjuryLocation = 0;
                CasualtyCL.FlagProtEquipCaused = 0;
                CasualtyCL.DetailedNarrative = "";
                CasualtyCL.RecommendationsForPrevention = "";
                if (~CasualtyCL.AddFSCasualty() != 0)
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Attempting to Create Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                else
                {
                    result = -1;
                    NoteMsg = "Fire Service Casualty Occurance:" + "\n";
                    NoteMsg = NoteMsg + "Date: " + CasualtyCL.CasualtyDate + "\n";
                    IncidentCL.GetIncident(CasualtyCL.IncidentID);
                    NoteMsg = NoteMsg + "Incident#: " + IncidentCL.IncidentNumber + "\n";
                    PersonnelCL.GetEmployeeRecord(CasualtyCL.EmployeeID);
                    NoteMsg = NoteMsg + "Employee: " + IncidentMain.Clean(PersonnelCL.Employee["name_full"]) + "\n";
                    NoteMsg = NoteMsg + "Unit: " + sUnit + "\n";
                    PersonnelCL.GetEmployeeRecord(IncidentMain.Shared.gCurrUser);
                    NoteMsg = NoteMsg + "Reported By: " + IncidentMain.Clean(PersonnelCL.Employee["name_full"]);

                    //-------- Create ReportLog Record -------------
                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                    ReportLog.ReportReferenceID = CasualtyCL.CasualtyID;
                    ReportLog.ReportType = IncidentMain.FSCASUALTY;
                    ReportLog.ReportStatus = UType;
                    ReportLog.ResponsibleUnit = sUnit;
                    if (~ReportLog.AddNew() != 0)
                    {
                        result = 0;
                        ViewManager.ShowMessage("Error Attempting to Create ReportLog Record for FS Casualty", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    //--------- Create Notification Record -------------
                    if (NotificationCL.GetNotificationReceiverByType(1) != 0)
                    { //FS Casualty Notification List

                        while (!NotificationCL.NotificationReceiver.EOF)
                        {
                            NotificationCL.MessageEmployeeID = Convert.ToString(NotificationCL.NotificationReceiver["empid"]);
                            NotificationCL.MessageText = NoteMsg;
                            NotificationCL.FlagReceived = 0;
                            NotificationCL.DateMessageCreated = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                            NotificationCL.AddNotificationMessage();
                            NotificationCL.NotificationReceiver.MoveNext();
                        };
                    }
                }
            }
            else
            {
                //Update Fire Service Casualty Record & ReportLog
                if (~CasualtyCL.GetFSCasualty(ViewModel.CurrReportID) != 0)
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Attempting to Update Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                else
                {
                    if (ViewModel.cboActivity.SelectedIndex == -1)
                    {
                        CasualtyCL.Activity = 0;
                    }
                    else
                    {
                        CasualtyCL.Activity = ViewModel.cboActivity.GetItemData(ViewModel.cboActivity.SelectedIndex);
                    }
                    if (ViewModel.cboWhereOccured.SelectedIndex == -1)
                    {
                        CasualtyCL.WhereOccurred = 0;
                    }
                    else
                    {
                        CasualtyCL.WhereOccurred = ViewModel.cboWhereOccured.GetItemData(ViewModel.cboWhereOccured.SelectedIndex);
                    }
                    if (ViewModel.cboInjuryCausedBy.SelectedIndex == -1)
                    {
                        CasualtyCL.InjuryCausedBy = 0;
                    }
                    else
                    {
                        CasualtyCL.InjuryCausedBy = ViewModel.cboInjuryCausedBy.GetItemData(ViewModel.cboInjuryCausedBy.SelectedIndex);
                    }
                    if (ViewModel.cboInjurySeverity.SelectedIndex == -1)
                    {
                        CasualtyCL.InjurySeverity = 0;
                    }
                    else
                    {
                        CasualtyCL.InjurySeverity = ViewModel.cboInjurySeverity.GetItemData(ViewModel.cboInjurySeverity.SelectedIndex);
                    }
                    if (ViewModel.cboBodyPart.SelectedIndex == -1)
                    {
                        CasualtyCL.BodyPartInjured = 0;
                    }
                    else
                    {
                        CasualtyCL.BodyPartInjured = ViewModel.cboBodyPart.GetItemData(ViewModel.cboBodyPart.SelectedIndex);
                    }
                    if (ViewModel.cboInjuryType.SelectedIndex == -1)
                    {
                        CasualtyCL.InjuryType = 0;
                    }
                    else
                    {
                        CasualtyCL.InjuryType = ViewModel.cboInjuryType.GetItemData(ViewModel.cboInjuryType.SelectedIndex);
                    }
                    if (ViewModel.cboLocationAtInjury.SelectedIndex == -1)
                    {
                        CasualtyCL.InjuryLocation = 0;
                    }
                    else
                    {
                        CasualtyCL.InjuryLocation = ViewModel.cboLocationAtInjury.GetItemData(ViewModel.cboLocationAtInjury.SelectedIndex);
                    }
                    if (ViewModel.chkFPEProblem.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                    {
                        CasualtyCL.FlagProtEquipCaused = 0;
                    }
                    else
                    {
                        CasualtyCL.FlagProtEquipCaused = 1;
                    }
                    CasualtyCL.DetailedNarrative = ViewModel.rtxNarrative.Text;
                    CasualtyCL.RecommendationsForPrevention = ViewModel.rtxRecommend.Text;
                    if (~CasualtyCL.UpdateFSCasualty() != 0)
                    {
                        result = 0;
                        ViewManager.ShowMessage("Error Attempting to Update Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    else
                    {
                        result = -1;
                        UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                            {
                                var ret =
                                        //------Contributing Factors
                                        CasualtyCL.DeleteFSCasualtyContributingFactor(ref p1);
                                ViewModel.CurrReportID = p1;
                                return ret;
                            }, ViewModel.CurrReportID);
                        CasualtyCL.FSCasualtyID = ViewModel.CurrReportID;
                        for (int i = 0; i <= ViewModel.lstContributingFactors.Items.Count - 1; i++)
                        {
                            if (ViewModel.lstContributingFactors.GetSelected(i))
                            {
                                CasualtyCL.FSCasualtyContributingFactor = ViewModel.lstContributingFactors.GetItemData(i);
                                CasualtyCL.AddFSCasualtyContributingFactor();
                            }
                        }
                        //----------Update Reportlog ----------------
                        if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                {
                                    var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrReportID, UType);
                                    ViewModel.CurrReportLogID = p1;
                                    return ret;
                                }, ViewModel.CurrReportLogID) != 0)
                        {
                            ViewManager.ShowMessage("Error Updating ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                    }
                }
            }
            return result;
        }

        private int SaveServiceReport(int UpdateType)
        {
            //Create New Service Report Record
            //Update ReportLog
            int result = 0;
            TFDIncident.clsMiscReports ServiceReport = Container.Resolve<clsMiscReports>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

            result = -1;
            ServiceReport.ServiceIncidentID = ViewModel.CurrIncident;
            if (ViewModel.cboServiceType.SelectedIndex != -1)
            {
                ServiceReport.ServiceType = ViewModel.cboServiceType.GetItemData(ViewModel.cboServiceType.SelectedIndex);
            }
            else
            {
                ServiceReport.ServiceType = 0;
            }
            ServiceReport.ServiceStandbyHours = Convert.ToInt32(Conversion.Val(ViewModel.txtStandbyHours.Text));
            ServiceReport.ServiceNumberSafeplace = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberSafePlace.Text));
            if (~ServiceReport.AddServiceReport() != 0)
            {
                result = 0;
            }
            else
            {
                //Save Narration - if any
                SaveNarration();
                //Update ReportLog
                if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
                            ViewModel.CurrReportLogID = p1;
                            return ret;
                        }, ViewModel.CurrReportLogID) != 0)
                {
                    ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    result = 0;
                }
            }

            return result;
        }

        private int SaveAllInfo(int UpdateType)
        {
            //Create New Service Report Record
            //Update ReportLog
            int result = 0;
            TFDIncident.clsMiscReports MiscReport = Container.Resolve<clsMiscReports>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

            result = -1;
            //Save Narration - if any
            SaveNarration();

            switch (ViewModel.CurrReport)
            {
                case IncidentMain.HAZCONDITION:
                    MiscReport.HCIncidentID = ViewModel.CurrIncident;
                    if (ViewModel.cboAllInfo1.SelectedIndex != -1)
                    {
                        MiscReport.HCIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.HCIncidentType = 0;
                    }
                    if (ViewModel.cboAllInfo2.SelectedIndex != -1)
                    {
                        MiscReport.HCPropertyTypeClass = ViewModel.cboAllInfo2.GetItemData(ViewModel.cboAllInfo2.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.HCPropertyTypeClass = 0;
                    }
                    if (~MiscReport.AddHazardousCondition() != 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        //Update ReportLog
                        if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                {
                                    var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
                                    ViewModel.CurrReportLogID = p1;
                                    return ret;
                                }, ViewModel.CurrReportLogID) != 0)
                        {
                            ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            result = 0;
                        }
                    }
                    break;
                case IncidentMain.SEARCHRESCUE:
                    MiscReport.SRIncidentID = ViewModel.CurrIncident;
                    if (ViewModel.cboAllInfo1.SelectedIndex != -1)
                    {
                        MiscReport.SRIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.SRIncidentType = 0;
                    }
                    MiscReport.SRNumberRescued = Convert.ToInt32(Conversion.Val(ViewModel.txtAllInfo1.Text));
                    if (~MiscReport.AddSearchRescue() != 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        //Update ReportLog
                        if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                {
                                    var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
                                    ViewModel.CurrReportLogID = p1;
                                    return ret;
                                }, ViewModel.CurrReportLogID) != 0)
                        {
                            ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            result = 0;
                        }
                    }
                    break;
                case IncidentMain.FALSEALARM:
                    MiscReport.FAIncidentID = ViewModel.CurrIncident;
                    if (ViewModel.cboAllInfo1.SelectedIndex != -1)
                    {
                        MiscReport.FAIncidentType = ViewModel.cboAllInfo1.GetItemData(ViewModel.cboAllInfo1.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.FAIncidentType = 0;
                    }
                    if (ViewModel.cboAllInfo2.SelectedIndex != -1)
                    {
                        MiscReport.FAAlarmSentBy = ViewModel.cboAllInfo2.GetItemData(ViewModel.cboAllInfo2.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.FAAlarmSentBy = 0;
                    }
                    if (ViewModel.cboAllInfo3.SelectedIndex != -1)
                    {
                        MiscReport.FAMalfunctionDevice = ViewModel.cboAllInfo3.GetItemData(ViewModel.cboAllInfo3.SelectedIndex);
                    }
                    else
                    {
                        MiscReport.FAMalfunctionDevice = 0;
                    }
                    MiscReport.FAComment = ViewModel.rtxFalseAlarmComment.Text;
                    if (~MiscReport.AddFalseAlarm() != 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        //Update ReportLog
                        if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                {
                                    var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, UpdateType);
                                    ViewModel.CurrReportLogID = p1;
                                    return ret;
                                }, ViewModel.CurrReportLogID) != 0)
                        {
                            ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            result = 0;
                        }
                    }
                    break;
            }


            return result;
        }

        private int SaveSituationFound(int UpdateType)
        {
            using (var async1 = this.Async<int>(true))
            {
                int result = 0;
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                bool SaveSitutionFound = false;
                //Save Incident Record Fields,
                //Update Incident Situation Found ReportLog status
                //Delete any existing Reportlogs (other than Unit & Sit Found)
                //Created any new Reportlogs as needed
                TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
                TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
                TFDIncident.clsEPCR EPCRcl = Container.Resolve<clsEPCR>();

                result = -1;
                int PrimarySit = 0;
                int NumberOfPatients = 0;
                if (~ReportLog.ClearReportLog(ViewModel.CurrIncident) != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Clear ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                int IncidentReportLogID = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, 2);
                for (int i = 7; i >= 0; i--)
                {
                    if (ViewModel.chkSitFound[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        //Create ReportLog record and Set Primary Situation Found
                        switch (i)
                        {
                            case 0:
                                PrimarySit = 1;  //Fire 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.FIRE) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.FIRE;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 1:
                                PrimarySit = 2;  //Rupture/Explosion 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.RUPTURE) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.RUPTURE;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 2:
                                PrimarySit = 3;  //Hazmat 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.HAZMAT) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.HAZMAT;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 3:
                                PrimarySit = 4;  //EMSPatient 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.EMSBASIC) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    if (ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                                    {
                                        ReportLog.ReportType = IncidentMain.EMSBASIC;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    }
                                    else
                                    {
                                        ReportLog.ReportType = IncidentMain.SIRENPCR;
                                        ReportLog.ReportStatus = IncidentMain.COMPLETE;
                                    }
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    NumberOfPatients = 1;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 4:
                                PrimarySit = 4;  //Multiple EMS Patients 
                                for (int x = 0; x <= 12; x++)
                                {
                                    if (ViewModel.cboEMSUnit[x].Visible)
                                    {
                                        if (~ReportLog.GetReportLog(Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbPatient[x].Tag)))) != 0)
                                        {
                                            ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                            ReportLog.ReportReferenceID = 0;
                                            if (ViewModel.chkSirenReport[x].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                                            {
                                                ReportLog.ReportType = IncidentMain.EMSBASIC;
                                                ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                            }
                                            else
                                            {
                                                ReportLog.ReportType = IncidentMain.SIRENPCR;
                                                ReportLog.ReportStatus = IncidentMain.COMPLETE;
                                            }
                                            ReportLog.ResponsibleUnit = ViewModel.cboEMSUnit[x].Text;
                                            if (~ReportLog.AddNew() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                            }
                                        }
                                    }
                                }
                                NumberOfPatients = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberPatients.Text));
                                break;
                            case 5:
                                PrimarySit = 6;  //Search/Rescue 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.SEARCHRESCUE) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.SEARCHRESCUE;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 6:
                                PrimarySit = 5;  //Hazardous Condition 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.HAZCONDITION) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.HAZCONDITION;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                            case 7:
                                PrimarySit = 7;  //False Alarm 
                                if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.FALSEALARM) != 0)
                                {
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.FALSEALARM;
                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                    }
                                }
                                break;
                        }
                    }
                }

                if (PrimarySit == 0)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (ViewModel.optServiceReport[i].Checked)
                        {
                            switch (i)
                            {
                                case 0:
                                    PrimarySit = 9;  //Investigate Only 
                                    if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.INVESTIGATION) != 0)
                                    {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.INVESTIGATION;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[9].Text;
                                        if (~ReportLog.AddNew() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                        }
                                    }
                                    break;
                                case 1:
                                    PrimarySit = 8;  //CleanUp Only 
                                    if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.CLEANUP) != 0)
                                    {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.CLEANUP;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[10].Text;
                                        if (~ReportLog.AddNew() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                        }
                                    }
                                    break;
                                case 2:
                                    PrimarySit = 10;  //Standby/Staging 
                                    if (~ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.STANDBY) != 0)
                                    {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.STANDBY;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[11].Text;
                                        if (~ReportLog.AddNew() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                        }
                                    }
                                    break;
                            }
                            break;
                        }
                    }
                }

                //Update Incident Record
                if ((((PrimarySit != 0) ? -1 : 0) & result) != 0)
                {
                    IncidentCL.IncidentID = ViewModel.CurrIncident;
                    IncidentCL.FinalIncidentType = PrimarySit;
                    IncidentCL.NumberOfPatients = NumberOfPatients;
                    if (~IncidentCL.UpdateFinalType() != 0)
                    {
                        ViewManager.ShowMessage("Error Updating Incident Final Type", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        result = 0;
                    }
                    else
                    {
                        if (~ReportLog.UpdateStatus(ref IncidentReportLogID, ViewModel.CurrIncident, IncidentMain.COMPLETE) != 0)
                        {
                            ViewManager.ShowMessage("Error Updating Incident Situation Found ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            SaveSitutionFound = false;
                        }
                        else
                        {
                            ViewModel.SituatationSaved = -1;
                        }
                    }
                }

                //Check for Fire Structure Exposures
                //    If chkExposures.Enabled Then
                //        If chkExposures.Value = 1 Then
                //            'Add new ReportLogRecord
                //            For i = 1 To Val(txtNumberExposures.Text)
                //                ReportLog.RLIncidentID = CurrIncident
                //                ReportLog.ReportReferenceID = 0
                //                ReportLog.ReportType = FIREEXPOSURE
                //                ReportLog.ReportStatus = 1
                //                ReportLog.ResponsibleUnit = cboUnit(0).Text
                //                ReportLog.AddNew
                //            Next
                //        End If
                //    End If

                //Check for CivilianCasualty
                if (ViewModel.chkCivilianCasualty.Enabled)
                {
                    if (ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        double tempForVar = Conversion.Val(ViewModel.txtNumberCivCasulties.Text);
                        for (int i = 1; i <= tempForVar; i++)
                        {
                            ReportLog.RLIncidentID = ViewModel.CurrIncident;
                            ReportLog.ReportReferenceID = 0;
                            ReportLog.ReportType = IncidentMain.CIVILCASUALTY;
                            ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                            if (ViewModel.cboUnit[0].Enabled)
                            {
                                ReportLog.ResponsibleUnit = ViewModel.cboUnit[0].Text;
                            }
                            else if (ViewModel.cboUnit[1].Enabled)
                            {
                                ReportLog.ResponsibleUnit = ViewModel.cboUnit[1].Text;
                            }
                            else
                            {
                                ReportLog.ResponsibleUnit = ViewModel.cboUnit[2].Text;
                            }
                            if (~ReportLog.AddNew() != 0)
                            {
                                ViewManager.ShowMessage("Error Adding Civilian Casualty Reportlog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                result = 0;
                            }
                        }
                    }
                }

                //Check for Incident Address Correction
                if (ViewModel.chkAddressCorrection.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                {
                    //Check For Existing Record - if none add ReportLog Record
                    if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION) == (0))
                    {
                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                        ReportLog.ReportReferenceID = ViewModel.CurrIncident;
                        ReportLog.ReportType = IncidentMain.ADDRESSCORRECTION;
                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                        ReportLog.ResponsibleUnit = IncidentMain.Clean(ViewModel.lbUnit.Text);
                        if (~ReportLog.AddNew() != 0)
                        {
                            ViewManager.ShowMessage("Error Adding Incident Address Correction Reportlog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                    }
                }
                else
                {
                    //Check for existing record - if one exists then prompt for delete
                    if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION) != 0)
                    {
                        if (IncidentCL.GetAddressCorrection(ViewModel.CurrIncident) != 0)
                        {
                            async1.Append<UpgradeHelpers.Helpers.DialogResult>((
                                    ) => ViewManager.ShowMessage("Do you wish to delete existing Incident Address Correction Record?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                            async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                            async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                {
                                    Response = tempNormalized1;
                                });
                            async1.Append<int>(() =>
                               {
                                   if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                   {
                                       UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                           {
                                               var ret =
                                                       IncidentCL.DeleteIncidentAddressCorrection(ref p1);
                                               ViewModel.CurrIncident = p1;
                                               return this.Return<int>(() => ret);
                                           }, ViewModel.CurrIncident);
                                       int tempRefParam = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION);
                                       ReportLog.UpdateStatus(ref tempRefParam, 0, IncidentMain.NOREPORT);
                                   }
                                   return this.Continue<int>();
                               });
                        }
                        else
                        {
                            int tempRefParam2 = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION);
                            ReportLog.UpdateStatus(ref tempRefParam2, 0, IncidentMain.NOREPORT);
                        }
                    }
                }

                return this.Return<int>(() => result);
            }
        }

        private void LoadSituationFound()
        {
            //Load Form Controls for Situation Found Frame
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            string RespUnit = "";

            for (int i = 0; i <= 11; i++)
            {
                if (i != 4 && i != 8)
                {
                    ViewModel.cboUnit[i].Items.Clear();
                }
            }
            for (int i = 0; i <= 12; i++)
            {
                ViewModel.cboEMSUnit[i].Items.Clear();
            }
            if (UnitCL.GetIncidentTFDUnitResponses(ViewModel.CurrIncident) != 0)
            {

                while (!UnitCL.UnitResponse.EOF)
                {
                    for (int i = 0; i <= 11; i++)
                    {
                        if (i != 4 && i != 8)
                        {
                            ViewModel.cboUnit[i].AddItem(IncidentMain.Clean(UnitCL.UnitResponse["tfd_unit"]));
                        }
                    }
                    UnitCL.UnitResponse.MoveNext();
                };
            }
            else
            {
                ViewManager.ShowMessage("Error Retrieving Dispatched Units", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

            if (UnitCL.GetIncidentUnitResponses(ViewModel.CurrIncident) != 0)
            {

                while (!UnitCL.UnitResponse.EOF)
                {
                    for (int i = 0; i <= 12; i++)
                    {
                        ViewModel.cboEMSUnit[i].AddItem(IncidentMain.Clean(UnitCL.UnitResponse["unit_id"]));
                    }
                    UnitCL.UnitResponse.MoveNext();
                };
            }
            else
            {
                ViewManager.ShowMessage("Error Retrieving Dispatched Units", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

            //Load Clearing Unit as default choice
            if (ReportLog.GetReportLog(ViewModel.CurrReportLogID) != 0)
            {
                RespUnit = IncidentMain.Clean(ReportLog.ResponsibleUnit);
                for (int x = 0; x <= 11; x++)
                {
                    if (x != 4 && x != 8)
                    {
                        for (int i = 0; i <= ViewModel.cboUnit[x].Items.Count - 1; i++)
                        {
                            ViewModel.cboUnit[x].SelectedIndex = i;
                            if (ViewModel.cboUnit[x].Text == RespUnit)
                            {
                                break;
                            }
                        }
                    }
                }
                for (int x = 0; x <= 12; x++)
                {
                    for (int i = 0; i <= ViewModel.cboEMSUnit[x].Items.Count - 1; i++)
                    {
                        ViewModel.cboEMSUnit[x].SelectedIndex = i;
                        if (ViewModel.cboEMSUnit[x].Text == RespUnit)
                        {
                            break;
                        }
                    }
                }
                //Change SitFound Status back to incomplete
                if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrIncident, IncidentMain.INCOMPLETE);
                            ViewModel.CurrReportLogID = p1;
                            return ret;
                        }, ViewModel.CurrReportLogID) != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Update Situation Found ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                ViewManager.ShowMessage("Unable to retrieve Incident Situation Found ReportLog record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            ViewModel.SituatationSaved = 0;
            //Check For Existing Address Correction
            if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION) != (0))
            {
                ViewModel.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else
            {
                ViewModel.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            }

        }

        private int SaveUnitReport(int iUpdateType)
        {
            //Save Unit Report and Update ReportLog
            int result = 0;
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            string DateWork = "", HourWork = "";
            string UnitWork = "";

            result = -1;

            if (~ViewModel.UnitReportUpdated != 0)
            { //No updates - Save Status
                if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrReportID, iUpdateType);
                            ViewModel.CurrReportLogID = p1;
                            return ret;
                        }, ViewModel.CurrReportLogID) != 0)
                {
                    ViewManager.ShowMessage("Error Updating ReportLog Status", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    result = 0;
                }
                return result;
            }
            //Updates made, save report fields
            if (ReportLog.GetReportLog(ViewModel.CurrReportLogID) != 0)
            {
                if (UnitCL.GetUnitResponse(ViewModel.CurrReportID) != 0)
                {
                    UnitWork = IncidentMain.Clean(UnitCL.URUnitID);
                    //Update Delay
                    UnitCL.DeleteUnitDelay();
                    for (int i = 0; i <= ViewModel.lstReasonDelay.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstReasonDelay.GetSelected(i))
                        {
                            UnitCL.UDUnitResponseID = UnitCL.UnitResponseID;
                            UnitCL.Delay = ViewModel.lstReasonDelay.GetItemData(i);
                            UnitCL.AddUnitDelay();
                        }
                    }
                    //Update Action
                    UnitCL.DeleteUnitAction();
                    for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstActionsTaken.GetSelected(i))
                        {
                            UnitCL.UAUnitResponseID = UnitCL.UnitResponseID;
                            UnitCL.Action = ViewModel.lstActionsTaken.GetItemData(i);
                            UnitCL.AddUnitAction();
                        }
                    }
                    //Update Times
                    for (int i = 1; i <= 5; i++)
                    {
                        if (ViewModel.txtAmendTime[i].Text != "__:__" && !ViewModel.txtAmendTime[i].BackColor.Equals
                                (IncidentMain.Shared.REQCOLOR) && !ViewModel.cboAmendReason[i].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                        {
                            if (UnitCL.GetUnitTime(UnitCL.UnitResponseID, Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbActualTime[i].Tag)))) != 0)
                            {
                                //Existing Record - Update UnitResponseTime
                                DateWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("MM/dd/yyyy");
                                HourWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("HH:mm");
                                if (String.CompareOrdinal(ViewModel.txtAmendTime[i].Text, HourWork) < 0)
                                {
                                    DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
                                }
                                UnitCL.AmendedTime = DateWork + " " + ViewModel.txtAmendTime[i].Text;
                                UnitCL.ReasonAmended = ViewModel.cboAmendReason[i].GetNullableItemData(ViewModel.cboAmendReason[i].SelectedIndex);
                                if (~UnitCL.UpdateUnitTimes() != 0)
                                {
                                    ViewManager.ShowMessage("Error Attempting to Update Unit Time", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewManager.SetCurrent(ViewModel.txtAmendTime[i]);
                                    return result;
                                }
                            }
                            else
                            {
                                //Add New Record
                                UnitCL.UTUnitResponseID = UnitCL.UnitResponseID;
                                UnitCL.ResponseTime = Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbActualTime[i].Tag)));
                                UnitCL.ActualTime = "";
                                DateWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("MM/dd/yyyy");
                                HourWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("HH:mm");
                                if (String.CompareOrdinal(ViewModel.txtAmendTime[i].Text, HourWork) < 0)
                                {
                                    DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
                                }
                                UnitCL.AmendedTime = DateWork + " " + ViewModel.txtAmendTime[i].Text;
                                UnitCL.ReasonAmended = ViewModel.cboAmendReason[i].GetNullableItemData(ViewModel.cboAmendReason[i].SelectedIndex);
                                if (~UnitCL.AddUnitTimes() != 0)
                                {
                                    ViewManager.ShowMessage("Error Attempting to Add New Unit Time", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewManager.SetCurrent(ViewModel.txtAmendTime[i]);
                                    return result;
                                }
                            }
                        }
                    }
                    //Update Personnel
                    //First Delete all Existing Records the Add Current Selections
                    int tempRefParam = UnitCL.UnitResponseID;
                    UnitCL.DeleteUnitPersonnel(ref tempRefParam);
                    for (int i = 0; i <= 6; i++)
                    {
                        if (ViewModel.cboPersonnel[i].SelectedIndex != -1 && ViewModel.cboPosition[i].SelectedIndex != -1)
                        {
                            //Add UnitResponsePersonnel Record
                            UnitCL.UPUnitResponseID = UnitCL.UnitResponseID;
                            UnitCL.EmployeeID = ViewModel.cboPersonnel[i].Text.Substring(Math.Max(ViewModel.cboPersonnel[i].Text.Length - 5, 0));
                            UnitCL.Position = ViewModel.cboPosition[i].Text;
                            if (ViewModel.chkCasualty[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                UnitCL.CasualtyFlag = 1;
                                if (~SaveCasualty(UnitCL.EmployeeID, UnitWork, IncidentMain.INCOMPLETE) != 0)
                                {
                                    //Error Messages Displayed by SaveCasualty function
                                }
                            }
                            else
                            {
                                UnitCL.CasualtyFlag = 0;
                            }
                            //No Exposure Info collected at this time                       
                            UnitCL.ExposureFlag = 0;
                         
                            if (~UnitCL.AddUnitPersonnel() != 0)
                            {
                                ViewManager.ShowMessage("Error Attempting to Add Unit Personnel", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                ViewManager.SetCurrent(ViewModel.cboPersonnel[i]);
                                return result;
                            }
                        }
                    }
                    if (ViewModel.cboPersonnel[7].SelectedIndex != -1)
                    {
                        UnitCL.UPUnitResponseID = UnitCL.UnitResponseID;
                        UnitCL.EmployeeID = ViewModel.cboPersonnel[7].Text.Substring(Math.Max(ViewModel.cboPersonnel[7].Text.Length - 5, 0));
                        UnitCL.Position = "NOTOP";
                        if (ViewModel.chkCasualty[6].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                        {
                            UnitCL.CasualtyFlag = 1;
                        }
                        else
                        {
                            UnitCL.CasualtyFlag = 0;
                        }
                        //No Exposure Info collected at this time
                        UnitCL.ExposureFlag = 0;

                        if (~UnitCL.AddUnitPersonnel() != 0)
                        {
                            ViewManager.ShowMessage("Error Attempting to Add Unit Personnel", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            ViewManager.SetCurrent(ViewModel.cboPersonnel[7]);
                            return result;
                        }
                    }

                    //Update UnitResponse Record
                    UnitCL.UnitNarrative = ViewModel.rtxUnitNarration.Text;
                    if (~UnitCL.UpdateUnitResponse() != 0)
                    {
                        result = 0;
                        ViewManager.ShowMessage("Error Attempting to Save Unit Response Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        return result;
                    }

                    //Update ReportLog
                    if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                            {
                                var ret = ReportLog.UpdateStatus(ref p1, ViewModel.CurrReportID, iUpdateType);
                                ViewModel.CurrReportLogID = p1;
                                return ret;
                            }, ViewModel.CurrReportLogID) != 0)
                    {
                        ViewManager.ShowMessage("Error updating ReportLog Status", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        result = 0;
                    }

                }
                else
                {
                    ViewManager.ShowMessage("Unable to retrieve UnitResponse record, Update failed", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                ViewManager.ShowMessage("Unable to retrieve ReportLog record, Update failed", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }


            return result;
        }

        private void LoadReportStatus()
        {
            //Load Information about Current Report
            //On ReportStatus Frame
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            ViewModel.lbRSIncidentNumber.Text = ViewModel.lbIncidentNo.Text;
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.UNITREPORT:
                    ViewModel.lbRSCurrReportType.Text = "Unit Report";
                    ViewModel.lbRSFrameTitle.Text = "UNIT REPORT - REPORT STATUS";
                    break;
                case IncidentMain.HAZCONDITION:
                    ViewModel.lbRSCurrReportType.Text = "Hazardous Condition Report";
                    ViewModel.lbRSFrameTitle.Text = "HAZARDOUS CONDITION - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.SEARCHRESCUE:
                    ViewModel.lbRSCurrReportType.Text = "Search and/or Rescue Report";
                    ViewModel.lbRSFrameTitle.Text = "SEARCH/RESCUE - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.FALSEALARM:
                    ViewModel.lbRSCurrReportType.Text = "False Alarm Report";
                    ViewModel.lbRSFrameTitle.Text = "FALSE ALARM - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.INVESTIGATION:
                    ViewModel.lbRSCurrReportType.Text = "Investigate Only Report";
                    ViewModel.lbRSFrameTitle.Text = "INVESTIGATE - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.CLEANUP:
                    ViewModel.lbRSCurrReportType.Text = "Cleanup Only Report";
                    ViewModel.lbRSFrameTitle.Text = "CLEANUP - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.STANDBY:
                    ViewModel.lbRSCurrReportType.Text = "Standby/Staging Report";
                    ViewModel.lbRSFrameTitle.Text = "STANDBY/STAGING - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.FSCASUALTY:
                    ViewModel.lbRSCurrReportType.Text = "Fire Service Casualty Report";
                    ViewModel.lbRSFrameTitle.Text = "FIRE SERVICE CASUALTY - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.CIVILCASUALTY:
                    ViewModel.lbRSCurrReportType.Text = "Civilian Casualty Report";
                    ViewModel.lbRSFrameTitle.Text = "CIVILIAN CASUALTY - REPORT STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
                case IncidentMain.ADDRESSCORRECTION:
                    ViewModel.lbRSCurrReportType.Text = "Incident Address Correction";
                    ViewModel.lbRSFrameTitle.Text = "ADDRESS CORRECTION - STATUS";
                    ViewModel.chkIC.Visible = false;
                    break;
            }
            ViewModel.lbRSReportedBy.Text = IncidentMain.Shared.gCurrUserName;
            ViewModel.lbRSEmployeeID.Text = IncidentMain.Shared.gCurrUser;
            if (PersonnelCL.GetEmployeeRecord(IncidentMain.Shared.gCurrUser) != 0)
            {
                ViewModel.lbRSPosition.Text = IncidentMain.Clean(PersonnelCL.Employee["job_title"]);
                ViewModel.lbRSUnit.Text = IncidentMain.Clean(PersonnelCL.Employee["unit_code"]);
                ViewModel.lbRSShift.Text = IncidentMain.Clean(PersonnelCL.Employee["shift_code"]) + " Shift";
            }
            else
            {
                ViewModel.lbRSPosition.Text = "Unknown";
                ViewModel.lbRSUnit.Text = "Unknown";
                ViewModel.lbRSShift.Text = "Unknown";
            }

            if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
            {
                ViewModel.lbReportByTitle.Text = "CURRENT REVIEWER:";
                ViewModel.cmdSave.Enabled = false;
                ViewModel.cmdSaveIncomplete.Enabled = false;
                ViewModel.cmdAbandon.Enabled = false;
            }
            else
            {
                ViewModel.lbReportByTitle.Text = "REPORT BY:";
                CheckComplete();
            }

            IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);



        }

        private int CheckComplete()
        {
            //Check Entry Screens for SaveComplete or SaveIncomplete for ReportStatus frame

            int result = 0;
            int ReportComplete = -1;
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.UNITREPORT:
                    //If amended time entered -make sure reason selected
                    for (int i = 1; i <= 5; i++)
                    {
                        if (ViewModel._txtAmendTime_1.Text != null) ; // donothing
                        if (ViewModel.txtAmendTime[i].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                        {
                            ReportComplete = 0;
                        }
                        if (ViewModel.cboAmendReason[i].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                        {
                            ReportComplete = 0;
                        }
                    }

                    for (int i = 0; i <= 7; i++)
                    {
                        if (ViewModel.cboPersonnel[i].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                        {
                            ReportComplete = 0;
                        }
                        if (i < 7)
                        {
                            if (ViewModel.cboPosition[i].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                            {
                                ReportComplete = 0;
                            }
                        }
                    }
                    break;
                case IncidentMain.INCIDENTREPORT:
                    ReportComplete = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (ViewModel.optServiceReport[i].Checked)
                        {
                            ReportComplete = -1;
                            break;
                        }
                    }
                    for (int i = 0; i <= 7; i++)
                    {
                        if (ViewModel.chkSitFound[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                        {
                            ReportComplete = -1;
                            break;
                        }
                    }
                    if (ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        double dbNumericTemp = 0;
                        if (ViewModel.txtNumberCivCasulties.Text == "")
                        {
                            ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.BLACK;
                            ReportComplete = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberCivCasulties.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                        {
                            ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.BLACK;
                            ViewModel.txtNumberCivCasulties.Text = "";
                            ReportComplete = 0;
                        }
                        else
                        {
                            ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.FIREFONT;
                        }
                    }

                    //            If chkExposures.Value = 1 Then 
                    //                If txtNumberExposures.Text = "" Then 
                    //                    txtNumberExposures.BackColor = REQCOLOR 
                    //                    txtNumberExposures.ForeColor = WHITE 
                    //                    ReportComplete = False 
                    //                ElseIf Not IsNumeric(txtNumberExposures.Text) Then 
                    //                    txtNumberExposures.BackColor = REQCOLOR 
                    //                    txtNumberExposures.ForeColor = WHITE 
                    //                    txtNumberExposures.Text = "" 
                    //                    ReportComplete = False 
                    //                Else 
                    //                    txtNumberExposures.BackColor = WHITE 
                    //                    txtNumberExposures.ForeColor = FIREFONT 
                    //                End If 
                    //            End If 
                    if (~ReportComplete != 0)
                    {
                        ViewModel.NavButton[2].Visible = false;
                        ViewModel.NavButton[4].Visible = false;
                    }
                    break;
                case IncidentMain.INVESTIGATION:
                case IncidentMain.CLEANUP:
                    if (ViewModel.cboServiceType.SelectedIndex == -1)
                    {
                        ViewModel.cboServiceType.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboServiceType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.SERVICEFONT;
                    }
                    break;
                case IncidentMain.STANDBY:
                    if (ViewModel.cboServiceType.SelectedIndex == -1)
                    {
                        ViewModel.cboServiceType.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboServiceType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboServiceType.ForeColor = IncidentMain.Shared.SERVICEFONT;
                    }
                    double dbNumericTemp2 = 0;
                    if (ViewModel.txtStandbyHours.Text == "")
                    {
                        ViewModel.txtStandbyHours.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtStandbyHours.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else if (!Double.TryParse(ViewModel.txtStandbyHours.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                    {
                        ViewModel.txtStandbyHours.Text = "";
                        ViewModel.txtStandbyHours.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtStandbyHours.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.txtStandbyHours.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtStandbyHours.ForeColor = IncidentMain.Shared.SERVICEFONT;
                    }
                    if (ViewModel.txtNumberSafePlace.Visible)
                    {
                        double dbNumericTemp3 = 0;
                        if (ViewModel.txtNumberSafePlace.Text == "")
                        {
                            ViewModel.txtNumberSafePlace.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.BLACK;
                            ReportComplete = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberSafePlace.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                        {
                            ViewModel.txtNumberSafePlace.Text = "";
                            ViewModel.txtNumberSafePlace.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.BLACK;
                            ReportComplete = 0;
                        }
                        else
                        {
                            ViewModel.txtNumberSafePlace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.SERVICEFONT;
                        }
                    }
                    break;
                case IncidentMain.HAZCONDITION:
                    if (ViewModel.cboAllInfo1.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                    }
                    if (ViewModel.cboAllInfo2.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo2.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
                    }
                    break;
                case IncidentMain.SEARCHRESCUE:
                    if (ViewModel.cboAllInfo1.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                    }

                    break;
                case IncidentMain.FALSEALARM:
                    if (ViewModel.cboAllInfo1.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo1.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboAllInfo2.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo2.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboAllInfo3.SelectedIndex == -1)
                    {
                        ViewModel.cboAllInfo3.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAllInfo3.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboAllInfo3.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
                    }

                    break;
                //UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
                //case IncidentMain.INVESTIGATION : 
                //break;
                //UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
                //case IncidentMain.CLEANUP : 
                //break;
                //UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
                //case IncidentMain.STANDBY : 
                //if (cboServiceType.SelectedIndex == -1)
                //{
                //cboServiceType.BackColor = IncidentMain.REQCOLOR;
                //cboServiceType.ForeColor = ColorTranslator.FromOle(IncidentMain.WHITE);
                //ReportComplete = 0;
                //}
                //else
                //{
                //cboServiceType.BackColor = ColorTranslator.FromOle(IncidentMain.WHITE);
                //cboServiceType.ForeColor = IncidentMain.SERVICEFONT;
                //} 
                // 
                //break;
                case IncidentMain.FSCASUALTY:
                    if (ViewModel.cboActivity.SelectedIndex == -1)
                    {
                        ViewModel.cboActivity.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboActivity.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboActivity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboActivity.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                    }
                    if (ViewModel.cboWhereOccured.SelectedIndex == -1)
                    {
                        ViewModel.cboWhereOccured.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboWhereOccured.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboWhereOccured.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboWhereOccured.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                    }
                    if (ViewModel.cboInjuryCausedBy.SelectedIndex == -1)
                    {
                        ViewModel.cboInjuryCausedBy.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboInjuryCausedBy.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboInjuryCausedBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboInjuryCausedBy.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                    }
                    if (ViewModel.cboLocationAtInjury.SelectedIndex == -1)
                    {
                        ViewModel.cboLocationAtInjury.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboLocationAtInjury.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboLocationAtInjury.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboLocationAtInjury.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                    }
                    if (ViewModel.cboInjurySeverity.SelectedIndex == -1)
                    {
                        ViewModel.cboInjurySeverity.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboInjurySeverity.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboInjurySeverity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboInjurySeverity.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                    }
                    if (ViewModel.PPEFlag != 0)
                    {
                        if (ViewModel.lstPPE.Items.Count == 0)
                        {
                            ViewModel.cboFPEEquipment.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboFPEEquipment.ForeColor = IncidentMain.Shared.BLACK;
                            ViewModel.cboFPEStatus.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboFPEStatus.ForeColor = IncidentMain.Shared.BLACK;
                            ViewModel.cboFPEProblem.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboFPEProblem.ForeColor = IncidentMain.Shared.BLACK;
                            ViewModel.cmdRemovePPE.Enabled = false;
                            ReportComplete = 0;
                        }
                        else
                        {
                            ViewModel.cboFPEEquipment.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboFPEEquipment.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                            ViewModel.cboFPEStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboFPEStatus.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                            ViewModel.cboFPEProblem.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboFPEProblem.ForeColor = IncidentMain.Shared.FSCASUALTYFONT;
                            ViewModel.cmdRemovePPE.Enabled = true;
                        }
                    }
                    break;
                case IncidentMain.CIVILCASUALTY:
                    if (ViewModel.chkEMR.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        ViewModel.chkEMR.BackColor = IncidentMain.Shared.CIVCSTYCOLOR;
                        ViewModel.chkEMR.ForeColor = IncidentMain.Shared.CIVCSTYFONT;
                        ViewModel.cboEMSPatient.Enabled = true;
                        if (ViewModel.cboEMSPatient.SelectedIndex == -1)
                        {
                            ViewModel.cboEMSPatient.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboEMSPatient.ForeColor = IncidentMain.Shared.BLACK;
                            ReportComplete = 0;
                        }
                        else
                        {
                            ViewModel.cboEMSPatient.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboEMSPatient.ForeColor = IncidentMain.Shared.BLACK;
                        }
                    }
                    else
                    {
                        ViewModel.chkEMR.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.chkEMR.ForeColor = IncidentMain.Shared.BLACK;
                        ViewModel.cboEMSPatient.Enabled = false;
                        ReportComplete = 0;
                    }
                    if (ViewModel.cboSeverity.SelectedIndex == -1)
                    {
                        ViewModel.cboSeverity.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboSeverity.ForeColor = IncidentMain.Shared.BLACK;
                        ReportComplete = 0;
                    }
                    else
                    {
                        ViewModel.cboSeverity.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboSeverity.ForeColor = IncidentMain.Shared.BLACK;
                    }
                    //        Case ADDRESSCORRECTION 
                    //            If txtXHouseNumber.Text = "" Then 
                    //                txtXHouseNumber.BackColor = REQCOLOR 
                    //                txtXHouseNumber.ForeColor = WHITE 
                    //                ReportComplete = False 
                    //            ElseIf Not IsNumeric(txtXHouseNumber.Text) Then 
                    //                txtXHouseNumber.BackColor = REQCOLOR 
                    //                txtXHouseNumber.ForeColor = WHITE 
                    //                ReportComplete = False 
                    //            Else 
                    //                txtXHouseNumber.BackColor = WHITE 
                    //                txtXHouseNumber.ForeColor = ADDRESSFONT 
                    //            End If 
                    // 
                    //            If cboXPrefix.ListIndex = -1 Then 
                    //                If cboXSuffix.ListIndex <> -1 Then 
                    //                    cboXPrefix.ListIndex = -1 
                    //                End If 
                    //            Else 
                    //                cboXSuffix.ListIndex = -1 
                    //            End If 
                    // 
                    //            If txtXStreetName.Text = "" Then 
                    //                txtXStreetName.BackColor = REQCOLOR 
                    //                txtXStreetName.ForeColor = WHITE 
                    //                ReportComplete = False 
                    //            Else 
                    //                txtXStreetName.BackColor = WHITE 
                    //                txtXStreetName.ForeColor = ADDRESSFONT 
                    //            End If 
                    // 
                    //            If cboCityCode.ListIndex = -1 Then 
                    //                cboCityCode.BackColor = REQCOLOR 
                    //                cboCityCode.ForeColor = WHITE 
                    //                ReportComplete = False 
                    //            Else 
                    //                cboCityCode.BackColor = WHITE 
                    //                cboCityCode.ForeColor = ADDRESSFONT 
                    //            End If 

                    break;
            }

            if (ReportComplete != 0)
            {
                result = -1;
                ViewModel.cmdSave.Enabled = true;
                //        If CurrReport <> ADDRESSCORRECTION Then
                //            NavButton(4).Visible = True
                //        End If
            }
            else
            {
                result = 0;
                ViewModel.cmdSave.Enabled = false;
                ViewModel.NavButton[4].Visible = false;
            }

            return result;
        }

        private void LoadUnitReport()
        {
            //Load Unit Response Report frame
            //with data for Unit Response passed from Main Application
            TFDIncident.clsUnit UnitRes = Container.Resolve<clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            int x = 0;
            string sList = "";
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            ViewModel.UnitICStatus = 0;
            if (~ReportLog.GetReportLog(ViewModel.CurrReportLogID) != 0)
            {
                //Unable to retrieve ReportLog record
                ViewManager.ShowMessage("Error Retrieving New Unit Response Reportlog record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }
            else
            {
                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                ViewModel.CurrReport = Convert.ToInt32(IncidentMain.GetVal(ReportLog.ReportType));
                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                ViewModel.CurrReportID = Convert.ToInt32(IncidentMain.GetVal(ReportLog.ReportReferenceID));
                IncidentCL.GetIncident(ViewModel.CurrIncident);
            }

            if (ViewModel.CurrReportID == 0)
            {
                //No Reference to Unit Response Report found in ReportLog
                ViewManager.ShowMessage("Error Retrieving New Unit Response Reportlog record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }
            else if (~UnitRes.GetUnitResponse(ViewModel.CurrReportID) != 0)
            {
                //Unable to retrieve UnitResponse record
                ViewManager.ShowMessage("Error Retrieving New Unit Response Record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            //Determine Incident Reporting Responsibility
            ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.INCIDENTREPORT);
            if (ReportLog.ResponsibleUnit == IncidentMain.Shared.gWizardUnitID)
            {
                ViewModel.chkIC.Visible = false;
            }
            else if (ReportLog.ReportStatus == IncidentMain.COMPLETE)
            {
                ViewModel.chkIC.Visible = false;
            }
            else
            {
                ViewModel.chkIC.Visible = true;
            }
            ViewModel.rtxUnitNarration.Text = UnitRes.UnitNarrative;

            //Load ActionsTaken and ReasonDelay Listboxes
            ViewModel.lstActionsTaken.Items.Clear();
            ViewModel.lstReasonDelay.Items.Clear();
            CommonCodes.GetUnitActionCodeByClass(1); //Fire Actions

            while (!CommonCodes.UnitAction.EOF)
            {
                ViewModel.lstActionsTaken.AddItem(IncidentMain.Clean(CommonCodes.UnitAction["description"]));
                ViewModel.lstActionsTaken.SetItemData(ViewModel.lstActionsTaken.GetNewIndex(), Convert.ToInt32(CommonCodes.UnitAction["unit_action_code"]));
                CommonCodes.UnitAction.MoveNext();
            }
            ;
            CommonCodes.GetUnitActionCodeByClass(3); //Search/Rescue Actions

            while (!CommonCodes.UnitAction.EOF)
            {
                ViewModel.lstActionsTaken.AddItem(IncidentMain.Clean(CommonCodes.UnitAction["description"]));
                ViewModel.lstActionsTaken.SetItemData(ViewModel.lstActionsTaken.GetNewIndex(), Convert.ToInt32(CommonCodes.UnitAction["unit_action_code"]));
                CommonCodes.UnitAction.MoveNext();
            }
            ;
            CommonCodes.GetUnitActionCodeByClass(7); //Search/Rescue Actions

            while (!CommonCodes.UnitAction.EOF)
            {
                ViewModel.lstActionsTaken.AddItem(IncidentMain.Clean(CommonCodes.UnitAction["description"]));
                ViewModel.lstActionsTaken.SetItemData(ViewModel.lstActionsTaken.GetNewIndex(), Convert.ToInt32(CommonCodes.UnitAction["unit_action_code"]));
                CommonCodes.UnitAction.MoveNext();
            }
            ;

            CommonCodes.GetDelayCodes();

            while (!CommonCodes.Delay.EOF)
            {
                ViewModel.lstReasonDelay.AddItem(IncidentMain.Clean(CommonCodes.Delay["description"]));
                ViewModel.lstReasonDelay.SetItemData(ViewModel.lstReasonDelay.GetNewIndex(), Convert.ToInt32(CommonCodes.Delay["delay_code"]));
                CommonCodes.Delay.MoveNext();
            }
            ;
            CommonCodes.GetReasonAmendedCode();

            while (!CommonCodes.ReasonAmended.EOF)
            {
                for (int i = 1; i <= 5; i++)
                {
                    ViewModel.cboAmendReason[i].AddItem(IncidentMain.Clean(CommonCodes.ReasonAmended["description"]));
                    ViewModel.cboAmendReason[i].SetItemData(ViewModel.cboAmendReason[i].GetNewIndex(), Convert.ToInt32(CommonCodes.ReasonAmended["reason_amended_code"]));
                }
                CommonCodes.ReasonAmended.MoveNext();
            }
            ;

            //Unit Personnel Fields
            //Load Combo and Listboxes
            for (int i = 0; i <= 7; i++)
            {
                ViewModel.cboPersonnel[i].Items.Clear();
                if (i < 7)
                {
                    ViewModel.cboPosition[i].Items.Clear();
                }
            }
            //Operations Staff
            PersonnelCL.GetOperationsList();

            while (!PersonnelCL.OperationsList.EOF)
            {
                sList = IncidentMain.Clean(PersonnelCL.OperationsList["name_full"]) + " :" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]);
                for (int i = 0; i <= 6; i++)
                {
                    ViewModel.cboPersonnel[i].AddItem(sList);
                }
                PersonnelCL.OperationsList.MoveNext();
            }
            ;


            if (PersonnelCL.GetPositionList(IncidentMain.Shared.gWizardUnitID) != 0)
            {

                while (!PersonnelCL.PositionList.EOF)
                {
                    sList = IncidentMain.Clean(PersonnelCL.PositionList["position_code"]);
                    for (int i = 0; i <= 6; i++)
                    {
                        ViewModel.cboPosition[i].AddItem(sList);
                    }
                    PersonnelCL.PositionList.MoveNext();
                };
            }

            //Non-Operations Staff
            PersonnelCL.GetNonOperationsList();

            while (!PersonnelCL.OperationsList.EOF)
            {
                sList = IncidentMain.Clean(PersonnelCL.OperationsList["name_full"]) + " :" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]);
                ViewModel.cboPersonnel[7].AddItem(sList);
                PersonnelCL.OperationsList.MoveNext();
            }
            ;

            if (UnitRes.GetUnitPersonnelRS(ViewModel.CurrReportID) != 0)
            {
                x = 0;

                while (!UnitRes.UnitPersonnel.EOF)
                {

                    if (IncidentMain.Clean(UnitRes.UnitPersonnel["position"]) != "NOTOP")
                    {
                        //Make sure that Unit Staff Array is not exceeded
                        if (x > 6)
                        {
                            ViewManager.ShowMessage("Unit Staff Exceeded 7 - Unable to display all Unit Staffing", "Incident Report Wizard", UpgradeHelpers.Helpers.
                                BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            break;
                        }

                        for (int i = 0; i <= ViewModel.cboPersonnel[x].Items.Count - 1; i++)
                        {
                            if (ViewModel.cboPersonnel[x].GetListItem(i).Substring(Math.Max(ViewModel.cboPersonnel[x].GetListItem(i).Length - 5, 0)) == Convert.ToString(UnitRes.UnitPersonnel["employee_id"]))
                            {
                                ViewModel.cboPersonnel[x].Visible = true;
                                ViewModel.cboPosition[x].Visible = true;
                                ViewModel.cmdClearPerson[x].Visible = true;
                                ViewModel.chkCasualty[x].Visible = true;
                                ViewModel.cboPersonnel[x].SelectedIndex = i;
                                break;
                            }
                        }
                        for (int i = 0; i <= ViewModel.cboPosition[x].Items.Count - 1; i++)
                        {

                            if (ViewModel.cboPosition[x].GetListItem(i) == IncidentMain.Clean(UnitRes.UnitPersonnel["position"]))
                            {
                                ViewModel.cboPosition[x].SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= ViewModel.cboPersonnel[7].Items.Count - 1; i++)
                        {
                            ViewModel.cboPersonnel[7].SelectedIndex = i;
                            if (ViewModel.cboPersonnel[7].Text.Substring(Math.Max(ViewModel.cboPersonnel[7].Text.Length - 5, 0)) == Convert.ToString(UnitRes.UnitPersonnel["employee_id"]))
                            {
                                break;
                            }
                        }
                    }
                    if (Convert.ToBoolean(UnitRes.UnitPersonnel["casualty_flag"]))
                    {
                        ViewModel.chkCasualty[x].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                    }
                    else
                    {
                        ViewModel.chkCasualty[x].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                    }
                    //if (Convert.ToBoolean(UnitRes.UnitPersonnel["exposure_flag"]))
                    //{
                    //    ViewModel.chkExposure[x].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                    //}
                    //else
                    //{
                        //ViewModel.chkCasualty[x].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                    //}
                    UnitRes.UnitPersonnel.MoveNext();
                    x++;
                };
                if (ViewModel.cboPersonnel[5].Visible)
                {
                    ViewModel.cmdAddStaff.Visible = false;
                }
            }
            else
            {
                ViewManager.ShowMessage("Unable to Retrieve Unit Staffing", "Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

            //Unit Times
            for (int i = 0; i <= 5; i++)
            {
                ViewModel.lbActualTime[i].Text = "";
            }
            ViewModel.lbURDate.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("MM/dd/yyyy HH:mm");

            if (UnitRes.GetUnitTimesRS(ViewModel.CurrReportID) != 0)
            {

                while (!UnitRes.UnitTimes.EOF)
                {
                    switch (Convert.ToInt32(UnitRes.UnitTimes["response_time_code"]))
                    {
                        case 3:  //Dispatch 
                            if (UnitRes.UnitTimes["actual_time"] != null) {
                            ViewModel.lbURDate.Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("MM/dd/yyyy HH:mm");
                            ViewModel.lbActualTime[0].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;
                        case 4:  //Enroute 
                            if (UnitRes.UnitTimes["actual_time"] != null)
                            {
                                ViewModel.lbActualTime[1].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;

                        case 5:  //Onscene 
                            if (UnitRes.UnitTimes["actual_time"] != null)
                            {
                                ViewModel.lbActualTime[2].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;
                        case 6:  //Transport 
                            if (UnitRes.UnitTimes["actual_time"] != null)
                            {
                                ViewModel.lbActualTime[3].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;
                        case 7:  //Transport Complete 
                            if (UnitRes.UnitTimes["actual_time"] != null)
                            {
                                ViewModel.lbActualTime[4].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;
                        case 8:
                            if (UnitRes.UnitTimes["actual_time"] != null)
                            {
                                ViewModel.lbActualTime[5].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            }
                            break;
                    }
                    UnitRes.UnitTimes.MoveNext();
                };
                if (!IncidentMain.Shared.gWizardUnitID.StartsWith("M"))
                {
                    if (ViewModel.lbActualTime[3].Text == "")
                    {
                        ViewModel.txtAmendTime[3].Enabled = false;
                        ViewModel.cboAmendReason[3].Enabled = false;
                    }
                    if (ViewModel.lbActualTime[4].Text == "")
                    {
                        ViewModel.txtAmendTime[4].Enabled = false;
                        ViewModel.cboAmendReason[4].Enabled = false;
                    }
                }
            }
            else
            {
                ViewManager.ShowMessage("Unable to Retrieve Unit Response Times", "Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
        }

        private void FormatFrame()
        {
            //If Multiple Use Frame Then Format Controls
            TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();

            string switchVar = ViewModel.CurrFrame.Name;
            if (switchVar == "frmUnitReport")
            {
                //************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                LoadUnitReport();
                ViewModel.UnitReportUpdated = 0;
                if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
                {
                    LockUnitScreen();
                }
                else
                {
                    ViewManager.SetCurrent(ViewModel.cboPersonnel[0]);
                }
                //************************************************************************************
            }
            else if (switchVar == "frmReportStatus")
            {
                //************************************************************************************
                if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
                {
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.lbNavMessage.Visible = false;
                    ViewModel.lbNavMessage.Visible = false;
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = true;
                }
                else
                {
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = false;
                    ViewModel.lbNavMessage.Visible = true;
                    ViewModel.lbNavMessage.Text = "Save Report!";
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = false;
                }
                LoadReportStatus();
                FlipImage();
                //************************************************************************************
            }
            else if (switchVar == "frmSitFound")
            {
                //************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = false;
                ViewModel.lbNavMessage.Visible = true;
                ViewModel.lbNavMessage.Text = "Make Selection";
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                LoadSituationFound();

                //*******************************************************************************************
            }
            else if (switchVar == "frmAllInfo")
            {
                //*******************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = true;
                ViewModel.NavButton[2].Visible = false;
                ViewModel.lbNavMessage.Visible = true;
                ViewModel.lbNavMessage.Text = "Make Selection";
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                FlipImage();

                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.HAZCONDITION:
                        //ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.FIRECOLOR;
                        ViewModel.lbAllInfoTitle.Text = "HAZARDOUS CONDITION REPORT";
                        //ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.ALLINFOFONT;
                        ViewModel.lbAllInfo1.Text = "Hazardous Condition Situation";
                        //ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbAllInfo1.Visible = true;
                        ViewModel.lbAllInfo2.Text = "General Property Use";
                        ViewModel.lbAllInfo2.Visible = true;
                        //ViewModel.lbAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbAllInfo3.Visible = false;
                        ViewModel.lbAllInfo4.Visible = false;
                        ViewModel.cboAllInfo1.Visible = true;
                        //ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboAllInfo1.Items.Clear();
                        ViewModel.cboAllInfo2.Visible = true;
                        //ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboAllInfo2.Items.Clear();
                        ViewModel.cboAllInfo3.Visible = false;
                        ViewModel.txtAllInfo1.Visible = false;
                        ViewModel.rtxFalseAlarmComment.Visible = false;
                        CommonCodes.GetIncidentTypeCodeByClass(5);  //Hazardous Condition 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;
                        FireCodes.GetPropertyUseClass();

                        while (!FireCodes.PropertyUseClassRS.EOF)
                        {
                            ViewModel.cboAllInfo2.AddItem(IncidentMain.Clean(FireCodes.PropertyUseClassRS["class_description"]));
                            ViewModel.cboAllInfo2.SetItemData(ViewModel.cboAllInfo2.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
                            FireCodes.PropertyUseClassRS.MoveNext();
                        }
                        ;

                        break;
                    case IncidentMain.SEARCHRESCUE:
                        //ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.TEAL;
                        ViewModel.lbAllInfoTitle.Text = "SEARCH AND/OR RESCUE REPORT";
                        //ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.SALMON;
                        ViewModel.lbAllInfo1.Text = "TYPE OF SEARCH AND/OR RESCUE REPORT";
                        //ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.SALMON;
                        ViewModel.lbAllInfo1.Visible = true;
                        ViewModel.lbAllInfo2.Visible = false;
                        ViewModel.lbAllInfo3.Visible = false;
                        ViewModel.lbAllInfo4.Text = "NUMBER RESCUED";
                        //ViewModel.lbAllInfo4.ForeColor = IncidentMain.Shared.SALMON;
                        ViewModel.lbAllInfo4.Visible = true;
                        ViewModel.cboAllInfo1.Visible = true;
                        //ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboAllInfo1.Items.Clear();
                        ViewModel.cboAllInfo2.Visible = false;
                        ViewModel.cboAllInfo3.Visible = false;
                        ViewModel.txtAllInfo1.Visible = true;
                        ViewModel.txtAllInfo1.Text = "0";
                        //ViewModel.txtAllInfo1.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.rtxFalseAlarmComment.Visible = false;
                        CommonCodes.GetIncidentTypeCodeByClass(6);  //Search/Rescue 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;

                        break;
                    case IncidentMain.FALSEALARM:
                        //ViewModel.frmAllInfo.BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.lbAllInfoTitle.Text = "FALSE ALARM REPORT";
                        //ViewModel.lbAllInfoTitle.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.lbAllInfo1.Text = "WHY ALARM ACTIVATED";
                        //ViewModel.lbAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.lbAllInfo1.Visible = true;
                        ViewModel.lbAllInfo2.Text = "ALARM SENT BY";
                        ViewModel.lbAllInfo2.Visible = true;
                        //ViewModel.lbAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.lbAllInfo3.Visible = true;
                        ViewModel.lbAllInfo3.Text = "DEVICE INITIATING FALSE ALARM";
                        //ViewModel.lbAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.lbAllInfo4.Visible = true;
                        ViewModel.lbAllInfo4.Text = "FALSE ALARM COMMENT";
                        //ViewModel.lbAllInfo4.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboAllInfo1.Visible = true;
                        //ViewModel.cboAllInfo1.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboAllInfo1.Items.Clear();
                        ViewModel.cboAllInfo2.Visible = true;
                        //ViewModel.cboAllInfo2.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboAllInfo2.Items.Clear();
                        ViewModel.cboAllInfo3.Visible = true;
                        //ViewModel.cboAllInfo3.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboAllInfo3.Items.Clear();
                        ViewModel.txtAllInfo1.Visible = false;
                        //ViewModel.rtxFalseAlarmComment.Visible = true;
                        //ViewModel.rtxFalseAlarmComment.Text = "";
                        //False Alarm Incident Type Codes 
                        CommonCodes.GetIncidentTypeCodeByClass(7);  //False Alarm 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboAllInfo1.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboAllInfo1.SetItemData(ViewModel.cboAllInfo1.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;
                        //Alarm Sent By 
                        CommonCodes.GetAlarmSentBy();

                        while (!CommonCodes.AlarmSentBy.EOF)
                        {
                            ViewModel.cboAllInfo2.AddItem(IncidentMain.Clean(CommonCodes.AlarmSentBy["description"]));
                            ViewModel.cboAllInfo2.SetItemData(ViewModel.cboAllInfo2.GetNewIndex(), Convert.ToInt32(CommonCodes.AlarmSentBy["alarm_sent_by_code"]));
                            CommonCodes.AlarmSentBy.MoveNext();
                        }
                        ;
                        //Device Initiating False Alarm 
                        FireCodes.GetAlarmDevice();

                        while (!FireCodes.AlarmDevice.EOF)
                        {
                            ViewModel.cboAllInfo3.AddItem(IncidentMain.Clean(FireCodes.AlarmDevice["description"]));
                            ViewModel.cboAllInfo3.SetItemData(ViewModel.cboAllInfo3.GetNewIndex(), Convert.ToInt32(FireCodes.AlarmDevice["alarm_device_code"]));
                            FireCodes.AlarmDevice.MoveNext();
                        }
                        ;

                        break;
                }
                CheckComplete();
                //********************************************************************************************
            }
            else if (switchVar == "frmService")
            {
                //********************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = true;
                ViewModel.NavButton[2].Visible = false;
                ViewModel.lbNavMessage.Visible = true;
                ViewModel.lbNavMessage.Text = "Make Selection";
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                ViewModel.MiscReportUpdated = 0;
                FlipImage();
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.INVESTIGATION:
                        ViewModel.lbServiceTitle.Text = "INVESTIGATION ONLY - REPORT";
                        ViewModel.lbServiceProvided.Text = "TYPE OF INVESTIGATION";
                        ViewModel.cboServiceType.Items.Clear();
                        ViewModel.lbStandbyHours.Visible = false;
                        ViewModel.txtStandbyHours.Visible = false;
                        ViewModel.txtStandbyHours.Text = "";
                        ViewModel.lbSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Text = "";
                        CommonCodes.GetIncidentTypeCodeByClass(9);  //Investigate Only 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;

                        break;
                    case IncidentMain.CLEANUP:
                        ViewModel.lbServiceTitle.Text = "CLEAN UP ONLY - REPORT";
                        ViewModel.lbServiceProvided.Text = "TYPE OF CLEAN UP";
                        ViewModel.cboServiceType.Items.Clear();
                        ViewModel.lbStandbyHours.Visible = false;
                        ViewModel.txtStandbyHours.Visible = false;
                        ViewModel.txtStandbyHours.Text = "";
                        ViewModel.lbSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Text = "";
                        CommonCodes.GetIncidentTypeCodeByClass(8);  //Cleanup Only 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;

                        break;
                    case IncidentMain.STANDBY:
                        ViewModel.lbServiceTitle.Text = "STANDBY/STAGING ONLY - REPORT";
                        ViewModel.lbServiceProvided.Text = "TYPE OF STANDBY/STAGING";
                        ViewModel.cboServiceType.Items.Clear();
                        ViewModel.lbStandbyHours.Visible = true;
                        ViewModel.txtStandbyHours.Visible = true;
                        ViewModel.txtNumberSafePlace.Text = "";
                        ViewModel.lbSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Visible = false;
                        ViewModel.txtNumberSafePlace.Text = "";
                        CommonCodes.GetIncidentTypeCodeByClass(10);  //Standby/Staging Only 

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboServiceType.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboServiceType.SetItemData(ViewModel.cboServiceType.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                        }
                        ;

                        break;
                }
                CheckComplete();
                //*************************************************************************************
            }
            else if (switchVar == "frmNarration")
            {
                //*************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = true;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                FlipImage();
                //*************************************************************************************
            }
            else if (switchVar == "frmFSCasualty")
            {
                //*************************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = true;
                ViewModel.NavButton[4].Visible = false;
                LoadFSCasualty();
                CheckComplete();
            }
            else if (switchVar == "frmFPE")
            {
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = true;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = true;
                ViewModel.NavButton[4].Visible = false;
                //*************************************************************************************
            }
            else if (switchVar == "frmCivilianCasualty")
            {
                //*************************************************************************************
                //**     Civilian Casualty Form
                //-------------------------------------------------------------------------------------
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = true;
                ViewModel.NavButton[4].Visible = false;
                LoadCivilianCasualty();
                CheckComplete();
                FlipImage();
                //*****************************************************************************
            }
            else if (switchVar == "frmIncidentAddressCorrection")
            {
                //********************************************************************************
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
                LoadAddressCorrection();
                CheckComplete();
                ViewManager.SetCurrent(ViewModel.txtXHouseNumber);
            }

            //Display Current Frame
            ViewModel.CurrFrame.Visible = true;

        }

        public void FlipImage()
        {
            //Generate random image pick

            VBMath.Randomize();
            int ImageNumber = Convert.ToInt32(Math.Floor((double)(35 * VBMath.Rnd() + 1)));
            string ImageFile = IncidentMain.IMAGEPATH + ImageNumber.ToString() + ".jpg";

        }

        public int CheckReportStatus()
        {
            //Check ReportLog to determine next Incomplete Report
            //For This Unit
            int result = 0;
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            var currLog = ReportLog.GetNextIncompleteReport(ViewModel.CurrIncident, IncidentMain.Shared.gWizardUnitID);
            ViewModel.CurrReportLogID = currLog;
            if (ViewModel.CurrReportLogID == 0)
            {
                if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
                {
                    if (IncidentMain.Shared.gSystemSecurity == IncidentMain.BATTALIONCHIEF)
                    {
                        ViewModel.CurrReportLogID = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.INCIDENTREPORT);
                    }
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                if (ReportLog.GetReportLog(ViewModel.CurrReportLogID) != 0)
                {
                    if (ReportLog.ReportType != IncidentMain.ADDRESSCORRECTION)
                    {
                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION) != (0))
                        {
                            if (ReportLog.ReportStatus == 1)
                            {
                                ViewModel.CurrReportLogID = ReportLog.ReportLogID;
                                ViewModel.CurrReportID = ReportLog.ReportReferenceID;
                                ViewModel.CurrReport = ReportLog.ReportType;
                                result = -1;
                            }
                            else
                            {
                                ReportLog.GetReportLog(ViewModel.CurrReportLogID);
                                ViewModel.CurrReportID = ReportLog.ReportReferenceID;
                                ViewModel.CurrReport = ReportLog.ReportType;
                                result = -1;
                            }
                        }
                        else
                        {
                            ViewModel.CurrReportID = ReportLog.ReportReferenceID;
                            ViewModel.CurrReport = ReportLog.ReportType;
                            result = -1;
                        }
                    }
                    else
                    {
                        ViewModel.CurrReportID = ReportLog.ReportReferenceID;
                        ViewModel.CurrReport = ReportLog.ReportType;
                        result = -1;
                    }
                }
                else
                {
                    ViewManager.ShowMessage("Error Retrieving Next Incomplete Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    result = 0;
                }
            }

            return result;
        }

        public void StepBack()
        {
            //Navigate to Previous Reporting Step
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            ViewModel.CurrFrame.Left = IncidentMain.WIZARDWIDTH / 15;
            string switchVar = ViewModel.CurrFrame.Name;
            if (switchVar == "frmReportStatus")
            {
                //Check for the current report
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.UNITREPORT:
                        ViewModel.CurrFrame = ViewModel.frmUnitReport;
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[1].Visible = false;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = true;
                        break;
                    case IncidentMain.FSCASUALTY:
                        if (ViewModel.PPEFlag != 0)
                        {
                            ViewModel.CurrFrame = ViewModel.frmFPE;
                            ViewModel.NavButton[1].Visible = true;
                        }
                        else
                        {
                            ViewModel.CurrFrame = ViewModel.frmFSCasualty;
                            ViewModel.NavButton[1].Visible = false;
                        }
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = false;
                        //                Case ADDRESSCORRECTION 
                        //                    Set CurrFrame = frmIncidentAddressCorrection 
                        //                    NavButton(0).Visible = True 
                        //                    NavButton(1).Visible = True 
                        //                    NavButton(2).Visible = True 
                        //                    lbNavMessage.Visible = False 
                        //                    lbNavMessage.Visible = False 
                        //                    NavButton(3).Visible = True 
                        //                    NavButton(4).Visible = False 
                        break;
                    default:
                        ViewModel.CurrFrame = ViewModel.frmNarration;
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[1].Visible = true;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = false;
                        break;
                }
            }
            else if (switchVar == "frmNarration")
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.INVESTIGATION:
                    case IncidentMain.CLEANUP:
                    case IncidentMain.STANDBY:
                        ViewModel.CurrFrame = ViewModel.frmService;
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[1].Visible = true;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = false;
                        break;
                    case IncidentMain.HAZCONDITION:
                    case IncidentMain.SEARCHRESCUE:
                    case IncidentMain.FALSEALARM:
                        ViewModel.CurrFrame = ViewModel.frmAllInfo;
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[1].Visible = true;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = false;
                        break;
                    case IncidentMain.CIVILCASUALTY:
                        ViewModel.CurrFrame = ViewModel.frmCivilianCasualty;
                        ViewModel.NavButton[0].Visible = true;
                        ViewModel.NavButton[1].Visible = false;
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.lbNavMessage.Visible = false;
                        ViewModel.NavButton[3].Visible = true;
                        ViewModel.NavButton[4].Visible = false;
                        break;
                }
            }
            else if (switchVar == "frmService" || switchVar == "frmAllInfo")
            {
                //            If ShowAddress Then
                //                Set CurrFrame = frmIncidentAddressCorrection
                //                NavButton(0).Visible = True
                //                NavButton(1).Visible = True
                //                NavButton(2).Visible = True
                //                lbNavMessage.Visible = False
                //                lbNavMessage.Visible = False
                //                NavButton(3).Visible = True
                //                NavButton(4).Visible = False
                //            Else
                ViewModel.CurrFrame = ViewModel.frmSitFound;
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = true;
                ViewModel.NavButton[4].Visible = false;
                ViewModel.CurrReport = IncidentMain.INCIDENTREPORT;
                ViewModel.CurrReportLogID = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, ViewModel.CurrReport);
                LoadSituationFound();
                //            End If
            }
            else if (switchVar == "frmFPE")
            {
                ViewModel.CurrFrame = ViewModel.frmFSCasualty;
                ViewModel.NavButton[0].Visible = true;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.NavButton[3].Visible = true;
                ViewModel.NavButton[4].Visible = false;
                //        Case "frmIncidentAddressCorrection"
                //            Set CurrFrame = frmSitFound
                //            NavButton(0).Visible = True
                //            NavButton(1).Visible = False
                //            NavButton(2).Visible = True
                //            lbNavMessage.Visible = False
                //            lbNavMessage.Visible = False
                //            NavButton(3).Visible = True
                //            NavButton(4).Visible = False
                //            CurrReport = INCIDENTREPORT
                //            CurrReportLogID = ReportLog.GetIncidentReportLogByType(CurrIncident, CurrReport)
                //            LoadSituationFound
            }

            ViewModel.CurrFrame.Left = 0;

        }

        public void StepNext()
        {
            using (var async1 = this.Async(true))
            {
                //Navigate to Next Reporting Step
                TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

                IncidentMain.Shared.gWizCancel = 0;
                int ShowFrame = -1;
               // ViewModel.CurrFrame.Left = IncidentMain.WIZARDWIDTH / 15;
                ViewModel.CurrFrame.Visible = false;
                if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
                {
                    //if ( ViewModel.CurrFrame.Name == "frmOpen")
                    //{
                    //	ViewModel.CurrReport = IncidentMain.INCIDENTREPORT;
                    //	ViewModel.CurrFrame = ViewModel.frmSitFound;
                    //	FormatFrame();
                    //}
                    //else
                    //{
                    async1.Append<System.Int32>(() => SaveSituationFound(IncidentMain.COMPLETE));
                    async1.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                    async1.Append<System.Int32, System.Int32>(tempNormalized1 => ~tempNormalized1);
                    async1.Append<System.Int32>(tempNormalized2 =>
                        {
                            if (tempNormalized2 != 0)
                            {
                                ViewManager.ShowMessage("Error Saving Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                        });
                    async1.Append(() =>
                        {
                            StepFinish();
                        });
                }
                //}
                else if (CheckReportStatus() != 0)
                {
                    if (ViewModel.CurrReport == IncidentMain.UNITREPORT)
                    {
                        switch ((string)ViewModel.CurrFrame.Name)
                        {
                            case "frmOpen":
                                ViewModel.CurrFrame = ViewModel.frmUnitReport;
                                break;
                            case "frmUnitReport":
                                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                break;
                        }
                        FormatFrame();
                    }
                    else if (ViewModel.CurrReport == IncidentMain.INCIDENTREPORT)
                    {
                        using (var async2 = this.Async())
                        {
                            switch ((string)ViewModel.CurrFrame.Name)
                            {
                                case "frmSitFound":
                                    async2.Append<System.Int32>(() => SaveSituationFound(IncidentMain.COMPLETE));
                                    async2.Append<System.Int32, System.Int32>(tempNormalized3 => tempNormalized3);
                                    async2.Append<System.Int32, System.Int32>(tempNormalized4 => ~tempNormalized4);
                                    async2.Append<System.Int32>(tempNormalized5 =>
                                        {
                                            if (tempNormalized5 != 0)
                                            {
                                                ViewManager.ShowMessage("Error Saving Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            }
                                        });
                                    async2.Append(() =>
                                        {
                                            ShowFrame = 0;
                                        });
                                    break;
                                default:
                                    ViewModel.CurrFrame = ViewModel.frmSitFound;
                                    FormatFrame();
                                    break;
                            }
                        }
                        //                FormatFrame
                    }
                    else if (ViewModel.CurrReport == IncidentMain.FIRE)
                    {
                        IncidentMain.Shared.gNewReportID = ViewModel.CurrReportLogID;
                        this.ViewModel.Visible = false;
                        IncidentMain.Shared.gWizCancel = 0;
                        async1.Append(() =>
                            {
                                ViewManager.NavigateToView(
                                    wzdFire.DefInstance, true);
                            });
                        async1.Append(() =>
                            {
                                this.ViewModel.Visible = true;
                                ShowFrame = 0;
                            });
                    }
                    else if (ViewModel.CurrReport == IncidentMain.FIREEXPOSURE)
                    {
                        IncidentMain.Shared.gNewReportID = ViewModel.CurrReportLogID;
                        this.ViewModel.Visible = false;
                        async1.Append(() =>
                            {
                                ViewManager.NavigateToView(
                                    wzdFire.DefInstance, true);
                            });
                        async1.Append(() =>
                            {
                                this.ViewModel.Visible = true;
                                ShowFrame = 0;
                            });
                    }
                    else if (ViewModel.CurrReport == IncidentMain.RUPTURE)
                    {
                        IncidentMain.Shared.gNewReportID = ViewModel.CurrReportLogID;
                        this.ViewModel.Visible = false;
                        IncidentMain.Shared.gWizCancel = 0;
                        async1.Append(() =>
                            {
                                ViewManager.NavigateToView(
                                    wzdFire.DefInstance, true);
                            });
                        async1.Append(() =>
                            {
                                this.ViewModel.Visible = true;
                                ShowFrame = 0;
                            });
                    }
                    else if (ViewModel.CurrReport == IncidentMain.HAZMAT)
                    {
                        IncidentMain.Shared.gNewReportID = ViewModel.CurrReportLogID;
                        this.ViewModel.Visible = false;
                        IncidentMain.Shared.gWizCancel = 0;
                        async1.Append(() =>
                            {
                                ViewManager.NavigateToView(
                                    wzdHazmat.DefInstance, true);
                            });
                        async1.Append(() =>
                            {
                                this.ViewModel.Visible = true;
                                ShowFrame = 0;
                            });
                    }
                    else if (ViewModel.CurrReport == IncidentMain.EMSBASIC)
                    {
                        IncidentMain.Shared.gNewReportID = ViewModel.CurrReportLogID;
                        this.ViewModel.Visible = false;
                        IncidentMain.Shared.gWizCancel = 0;
                        async1.Append(() =>
                            {
                                //UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: http://www.vbtonet.com/ewis/ewi7009.aspx
                                ViewManager.NavigateToView(                   
                                    wzdEms.DefInstance, true);
                            });
                        async1.Append(() =>
                            {
                                this.ViewModel.Visible = true;
                                ShowFrame = 0;
                            });
                    }
                    else if (ViewModel.CurrReport == IncidentMain.HAZCONDITION || ViewModel.CurrReport == IncidentMain.SEARCHRESCUE || ViewModel.CurrReport == IncidentMain.FALSEALARM)
                    {
                        switch ((string)ViewModel.CurrFrame.Name)
                        {
                            case "frmAllInfo":
                                ViewModel.CurrFrame = ViewModel.frmNarration;
                                break;
                            case "frmNarration":
                                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                break;
                            default:
                                ViewModel.CurrFrame = ViewModel.frmAllInfo;
                                break;
                        }
                        FormatFrame();
                    }
                    else if (ViewModel.CurrReport == IncidentMain.INVESTIGATION || ViewModel.CurrReport == IncidentMain.CLEANUP || ViewModel.CurrReport == IncidentMain.STANDBY)
                    {
                        switch ((string)ViewModel.CurrFrame.Name)
                        {
                            case "frmService":
                                ViewModel.CurrFrame = ViewModel.frmNarration;
                                break;
                            case "frmNarration":
                                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                break;
                            default:
                                ViewModel.CurrFrame = ViewModel.frmService;
                                break;
                        }
                        FormatFrame();
                    }
                    else if (ViewModel.CurrReport == IncidentMain.FSCASUALTY)
                    {
                        switch ((string)ViewModel.CurrFrame.Name)
                        {
                            case "frmFSCasualty":
                                if (ViewModel.PPEFlag != 0)
                                {
                                    ViewModel.CurrFrame = ViewModel.frmFPE;
                                }
                                else
                                {
                                    ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                }
                                break;
                            case "frmFPE":
                                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                break;
                            default:
                                ViewModel.CurrFrame = ViewModel.frmFSCasualty;
                                break;
                        }
                        FormatFrame();
                    }
                    else if (ViewModel.CurrReport == IncidentMain.CIVILCASUALTY)
                    {
                        switch ((string)ViewModel.CurrFrame.Name)
                        {
                            case "frmCivilianCasualty":
                                ViewModel.CurrFrame = ViewModel.frmNarration;
                                break;
                            case "frmNarration":
                                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                                break;
                            default:
                                ViewModel.CurrFrame = ViewModel.frmCivilianCasualty;
                                break;
                        }
                        FormatFrame();
                        //            Case ADDRESSCORRECTION
                        //                Select Case CurrFrame.NAME
                        //                    Case "frmIncidentAddressCorrection"
                        //                        Set CurrFrame = frmReportStatus
                        //                    Case Else
                        //                        Set CurrFrame = frmIncidentAddressCorrection
                        //                End Select
                        //                FormatFrame
                    }
                    if (IncidentMain.Shared.gWizCancel != 0)
                    {
                        async1.Append(() =>
                            {
                                StepFinish();
                            });
                    }
                    else if (ShowFrame == 0)
                    {
                        async1.Append(() =>
                            {
                                StepNext();
                            });
                    }
                }
                else
                {
                    async1.Append(() =>
                        {
                            StepFinish();
                        });

                }
            }

        }

        public void StepQuit()
        {
            using (var async1 = this.Async(true))
            {
                //Display Save as Incomplete msgbox
                //And Exit
                string msg = "";

                if (CheckComplete() != 0)
                {
                    using (var async2 = this.Async())
                    {
                        switch (ViewModel.CurrReport)
                        {
                            case IncidentMain.UNITREPORT:
                                //Save UnitReport 
                                if (SaveUnitReport(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Unit Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save Unit Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.INCIDENTREPORT:
                                async2.Append<System.Int32>(() => SaveSituationFound(IncidentMain.COMPLETE));
                                async2.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                                async2.Append<System.Int32>(tempNormalized1 =>
                                    {
                                        //Save Incident Situation Found Data 
                                        if (tempNormalized1 != 0)
                                        {
                                            ViewManager.ShowMessage("Incident Situation Found Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        }
                                        else
                                        {
                                            ViewManager.ShowMessage("Error Attempting to Save Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        }
                                    });
                                break;
                            case IncidentMain.INVESTIGATION:
                            case IncidentMain.CLEANUP:
                            case IncidentMain.STANDBY:
                                //Save Service Report 
                                if (ViewModel.CurrReport == IncidentMain.INVESTIGATION)
                                {
                                    msg = "Investigation Only Report ";
                                }
                                else if (ViewModel.CurrReport == IncidentMain.CLEANUP)
                                {
                                    msg = "Clean Up Only Report ";
                                }
                                else
                                {
                                    msg = "Standby/Staging Report ";
                                }
                                if (SaveServiceReport(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage(msg + "Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.HAZCONDITION:
                            case IncidentMain.SEARCHRESCUE:
                            case IncidentMain.FALSEALARM:
                                //Save Reports from AllInfo Form 
                                if (ViewModel.CurrReport == IncidentMain.HAZCONDITION)
                                {
                                    msg = "Hazardous Condition Report ";
                                }
                                else if (ViewModel.CurrReport == IncidentMain.SEARCHRESCUE)
                                {
                                    msg = "Search/Rescue Report ";
                                }
                                else
                                {
                                    msg = "False Alarm Report ";
                                }
                                if (SaveAllInfo(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage(msg + "Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.CIVILCASUALTY:
                                if (SaveCivilianCasualty(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Civilian Casualty Report Saved as Complete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save Civilian Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.FSCASUALTY:
                                if (SaveCasualty("", "", IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Fire Service Casualty Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    //Error Msgs displayed by subroutine
                                }
                                break;
                        }
                    }
                }
                else
                {
                    using (var async3 = this.Async())
                    {
                        switch (ViewModel.CurrReport)
                        {
                            case IncidentMain.UNITREPORT:
                                //Save UnitReport 
                                if (SaveUnitReport(IncidentMain.SAVEDINCOMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save Unit Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    this.Return();
                                    return;
                                }
                                break;
                            case IncidentMain.INCIDENTREPORT:
                                async3.Append<System.Int32>(() => SaveSituationFound(IncidentMain.SAVEDINCOMPLETE));
                                async3.Append<System.Int32, System.Int32>(tempNormalized2 => tempNormalized2);
                                async3.Append<System.Int32>(tempNormalized3 =>
                                    {
                                        //Save Incident Situation Found Data 
                                        if (tempNormalized3 != 0)
                                        {
                                            ViewManager.ShowMessage("Incident Situation Found Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        }
                                        else
                                        {
                                            ViewManager.ShowMessage("Error Attempting to Save Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            this.Return();
                                            return;
                                        }
                                    });
                                break;
                            case IncidentMain.INVESTIGATION:
                            case IncidentMain.CLEANUP:
                            case IncidentMain.STANDBY:
                                //Save Service Report 
                                if (ViewModel.CurrReport == IncidentMain.INVESTIGATION)
                                {
                                    msg = "Investigation Only Report ";
                                }
                                else if (ViewModel.CurrReport == IncidentMain.CLEANUP)
                                {
                                    msg = "Clean Up Only Report ";
                                }
                                else
                                {
                                    msg = "Standby/Staging Report ";
                                }
                                if (SaveServiceReport(IncidentMain.SAVEDINCOMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage(msg + "Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.HAZCONDITION:
                            case IncidentMain.SEARCHRESCUE:
                            case IncidentMain.FALSEALARM:
                                //Save Reports from AllInfo Form 
                                if (ViewModel.CurrReport == IncidentMain.HAZCONDITION)
                                {
                                    msg = "Hazardous Condition Report ";
                                }
                                else if (ViewModel.CurrReport == IncidentMain.SEARCHRESCUE)
                                {
                                    msg = "Search/Rescue Report ";
                                }
                                else
                                {
                                    msg = "False Alarm Report ";
                                }
                                if (SaveAllInfo(IncidentMain.SAVEDINCOMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage(msg + "Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.CIVILCASUALTY:
                                if (SaveCivilianCasualty(IncidentMain.SAVEDINCOMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Civilian Casualty Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save Civilian Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            case IncidentMain.FSCASUALTY:
                                if (SaveCasualty("", "", IncidentMain.SAVEDINCOMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Fire Service Casualty Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    //Error Msgs displayed by subroutine
                                }

                                break;
                        }
                    }
                }
                async1.Append(() =>
                    {
                        ViewManager.DisposeView(this);
                    });
            }

        }

        public void StepFinish()
        {
            using (var async1 = this.Async(true))
            {
                string msg = "";
                //Determine Reporting Status
                //And Exit Saving or Exit Not Saving or Cancel Finish Request
                int SaveStatus = 0;

                if (ViewModel.CurrReportLogID == 0)
                {
                    ViewManager.ShowMessage("Thanks for using the TFD Incident Reporting Wizard", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                    ViewManager.DisposeView(this);
                }
                else if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
                {
                    ViewManager.DisposeView(this);
                }
                else
                {
                    if (~IncidentMain.Shared.gWizCancel != 0)
                    {
                        CheckComplete();
                        if (ViewModel.cmdSave.Enabled)
                        {
                            SaveStatus = IncidentMain.COMPLETE;
                        }
                        else
                        {
                            SaveStatus = IncidentMain.SAVEDINCOMPLETE;
                        }
                        using (var async2 = this.Async())
                        {
                            switch (ViewModel.CurrReport)
                            {
                                case IncidentMain.UNITREPORT:
                                    //Save UnitReport 
                                    if (SaveUnitReport(SaveStatus) != 0)
                                    {
                                        ViewManager.ShowMessage("Unit Report Saved", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save Unit Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    break;
                                case IncidentMain.INCIDENTREPORT:
                                    async2.Append<System.Int32>(() => SaveSituationFound(SaveStatus));
                                    async2.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                                    async2.Append<System.Int32>(tempNormalized1 =>
                                        {
                                            //Save Incident Situation Found Data 
                                            if (tempNormalized1 != 0)
                                            {
                                                ViewManager.ShowMessage("Incident Situation Found Report Saved", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                            }
                                            else
                                            {
                                                ViewManager.ShowMessage("Error Attempting to Save Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                                    Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            }
                                        });
                                    break;
                                case IncidentMain.INVESTIGATION:
                                case IncidentMain.CLEANUP:
                                case IncidentMain.STANDBY:
                                    //Save Service Report 
                                    if (ViewModel.CurrReport == IncidentMain.INVESTIGATION)
                                    {
                                        msg = "Investigation Only Report ";
                                    }
                                    else if (ViewModel.CurrReport == IncidentMain.CLEANUP)
                                    {
                                        msg = "Clean Up Only Report ";
                                    }
                                    else
                                    {
                                        msg = "Standby/Staging Report ";
                                    }
                                    if (SaveServiceReport(SaveStatus) != 0)
                                    {
                                        ViewManager.ShowMessage(msg + "Saved", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    break;
                                case IncidentMain.HAZCONDITION:
                                case IncidentMain.SEARCHRESCUE:
                                case IncidentMain.FALSEALARM:
                                    //Save Reports from AllInfo Form 
                                    if (ViewModel.CurrReport == IncidentMain.HAZCONDITION)
                                    {
                                        msg = "Hazardous Condition Report ";
                                    }
                                    else if (ViewModel.CurrReport == IncidentMain.SEARCHRESCUE)
                                    {
                                        msg = "Search/Rescue Report ";
                                    }
                                    else
                                    {
                                        msg = "False Alarm Report ";
                                    }
                                    if (SaveAllInfo(SaveStatus) != 0)
                                    {
                                        ViewManager.ShowMessage(msg + "Saved", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    break;
                            }
                        }
                    }
                    async1.Append(() =>
                        {
                            ViewManager.DisposeView(this);
                        });
                }
            }



        }

        [UpgradeHelpers.Events.Handler]
        internal void cboActivity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAllInfo1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //If selection made enable Next button
            CheckComplete();
            if (ViewModel.cboAllInfo1.SelectedIndex == -1)
            {
                return;
            }
            ViewModel.NavButton[2].Visible = true;
            ViewModel.lbNavMessage.Visible = false;
            ViewModel.NavButton[3].Visible = true;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAllInfo2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAllInfo3_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAmendReason_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboAmendReason.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboAmendReason[Index].SelectedIndex == -1)
            {
                return;
            }

            if (ViewModel.txtAmendTime[Index].Text == "__:__")
            {
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtAmendTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
            }
            ViewModel.cboAmendReason[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.cboAmendReason[Index].ForeColor = IncidentMain.Shared.BLACK;
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboCityCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEMSPatient_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboFPEEquipment_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();

            //if EquipmentSelected then Load Status and Problem Lists
            if (ViewModel.cboFPEEquipment.SelectedIndex != -1)
            {
                ViewModel.DontRespond = -1;
                ViewModel.cboFPEStatus.Items.Clear();
                ViewModel.cboFPEProblem.Items.Clear();
                Casualty.GetFPEStatusByCode(ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex));

                while (!Casualty.FPEStatusCode.EOF)
                {
                    ViewModel.cboFPEStatus.AddItem(IncidentMain.Clean(Casualty.FPEStatusCode["Description"]));
                    ViewModel.cboFPEStatus.SetItemData(ViewModel.cboFPEStatus.GetNewIndex(), Convert.ToInt32(Casualty.FPEStatusCode["fpe_status_code"]));
                    Casualty.FPEStatusCode.MoveNext();
                }
                ;
                Casualty.GetFPEProblemByCode(ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex));

                while (!Casualty.FPEProblemCode.EOF)
                {
                    ViewModel.cboFPEProblem.AddItem(IncidentMain.Clean(Casualty.FPEProblemCode["Description"]));
                    ViewModel.cboFPEProblem.SetItemData(ViewModel.cboFPEProblem.GetNewIndex(), Convert.ToInt32(Casualty.FPEProblemCode["fpe_problem_code"]));
                    Casualty.FPEProblemCode.MoveNext();
                }
                ;
                ViewModel.DontRespond = 0;
            }
            ViewModel.cmdAddPPE.Enabled = false;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboFPEProblem_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            //Check for Selections to Enable Add Button
            if (ViewModel.cboFPEEquipment.SelectedIndex != -1)
            {
                if (ViewModel.cboFPEStatus.SelectedIndex != -1)
                {
                    ViewModel.cmdAddPPE.Enabled = ViewModel.cboFPEProblem.SelectedIndex != -1;
                }
                else
                {
                    ViewModel.cmdAddPPE.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddPPE.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboFPEStatus_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            //Check for Selections to Enable Add Button
            if (ViewModel.cboFPEEquipment.SelectedIndex != -1)
            {
                if (ViewModel.cboFPEStatus.SelectedIndex != -1)
                {
                    ViewModel.cmdAddPPE.Enabled = ViewModel.cboFPEProblem.SelectedIndex != -1;
                }
                else
                {
                    ViewModel.cmdAddPPE.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddPPE.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInjuryCausedBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInjurySeverity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboLocationAtInjury_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPersonnel_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPosition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboServiceType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //If selection made enable Next Button
            //Check for Standby Hours and Safeplace

            CheckComplete();
            if (ViewModel.cboServiceType.SelectedIndex == -1)
            {
                return;
            }
            ViewModel.NavButton[2].Visible = true;
            ViewModel.lbNavMessage.Visible = false;
            ViewModel.NavButton[3].Visible = true;


            if (ViewModel.CurrReport != IncidentMain.STANDBY)
            {
                return;
            }


            int iType = ViewModel.cboServiceType.GetItemData(ViewModel.cboServiceType.SelectedIndex);
            if (iType == 63)
            { //SafePlace

                ViewModel.txtNumberSafePlace.Visible = true;
                ViewModel.lbSafePlace.Visible = true;
                ViewModel.txtNumberSafePlace.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.BLACK;
            }
            else
            {
                ViewModel.txtNumberSafePlace.Visible = false;
                ViewModel.lbSafePlace.Visible = false;
                ViewModel.txtNumberSafePlace.Text = "";
                ViewModel.txtNumberSafePlace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberSafePlace.ForeColor = IncidentMain.Shared.SERVICEFONT;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSeverity_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboWhereOccured_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXStreetType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkAddressCorrection_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkAddressCorrection.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.ShowAddress = -1;
            }
            else
            {
                ViewModel.ShowAddress = 0;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkCasualty_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkCivilianCasualty_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Show Number of Casualty controls
            if (ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                //ViewModel.txtNumberCivCasulties.Visible = true;
                ViewManager.ShowMessage("Please Identify an EMS Patient Report for Each Civilian Casualty", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                    .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtNumberCivCasulties.Enabled = true;
                ViewManager.SetCurrent(ViewModel.txtNumberCivCasulties);
            }
            else
            {
                ViewModel.txtNumberCivCasulties.Visible = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void chkEMR_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        //[UpgradeHelpers.Events.Handler]
        //internal void chkExposure_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        //{
        //    //    UnitReportUpdated = True

        //}

        //Private Sub chkExposures_Click()
        //    'Show Number of Casualty controls
        //    If chkExposures.Value = 1 Then
        //        txtNumberExposures.Visible = True
        //    Else
        //        txtNumberExposures.Visible = False
        //    End If
        //
        //
        //End Sub
        [UpgradeHelpers.Events.Handler]
        internal void chkFPEProblem_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }

            if (ViewModel.chkFPEProblem.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.PPEFlag = -1;
            }
            else
            {
                ViewModel.PPEFlag = 0;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void chkIC_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();

            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.INCIDENTREPORT);
            ReportLog.ResponsibleUnit = IncidentMain.Shared.gWizardUnitID;
            ReportLog.UpDate();
            UnitCL.GetUnitResponse(ViewModel.CurrReportID);
            UnitCL.FlagICUnit = 1;
            UnitCL.UpdateUnitResponse();
            IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);
            ViewModel.chkIC.Visible = false;
            if (~CheckReportStatus() != 0)
            {
                //No Pending Reports
                ViewModel.NavButton[0].Visible = false;
                ViewModel.NavButton[1].Visible = false;
                ViewModel.NavButton[2].Visible = false;
                ViewModel.lbNavMessage.Visible = true;
                ViewModel.lbNavMessage.Text = "You're Done!";
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = true;
                ViewModel.cmdSave.Enabled = false;
                ViewModel.cmdSaveIncomplete.Enabled = false;
                ViewModel.cmdAbandon.Enabled = false;
            }
            else
            {
                ViewModel.NavButton[0].Visible = false;
                ViewModel.NavButton[1].Visible = false;
                if (ViewModel.CurrReport == IncidentMain.UNITREPORT)
                {
                    ViewModel.NavButton[2].Visible = false;
                    ViewModel.lbNavMessage.Visible = true;
                    ViewModel.lbNavMessage.Text = "Save Report!";
                }
                else
                {
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.lbNavMessage.Visible = false;
                }
                ViewModel.NavButton[3].Visible = false;
                ViewModel.NavButton[4].Visible = false;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkSitFound_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.chkSitFound.IndexOf((UpgradeHelpers.BasicViewModels.CheckBoxViewModel)eventSender);
            if (ViewModel.DontRespond != 0)
            {
                return;
            }

            //Format Frame as needed
            ViewModel.DontRespond = -1;

            if (ViewModel.chkSitFound[Index].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
            {
                if (Index != 4)
                {
                    ViewModel.cboUnit[Index].Enabled = false;
                }
                else
                {
                    //Unchecked Multiple EMS Patients
                    ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                    ViewModel.txtNumberPatients.Enabled = false;
                    ViewModel.txtNumberPatients.Text = "";
                    ViewModel.frmMultiEMS.Visible = false;
                    ViewModel.lbEMSReportingUnit.Visible = false;
                    for (int i = 0; i <= 12; i++)
                    {
                        ViewModel.lbPatient[i].Visible = false;
                        ViewModel.cboEMSUnit[i].Visible = false;
                        ViewModel.chkSirenReport[i].Visible = false;
                    }
                }
            }
            else
            {
                //Shutdown ServiceReport Options
                for (int i = 0; i <= 2; i++)
                {
                    ViewModel.optServiceReport[i].Checked = false;
                }
                for (int i = 9; i <= 11; i++)
                {
                    ViewModel.cboUnit[i].Enabled = false;
                }
                if (Index == 4)
                { //Multiple EMS Patients

                    ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.BLACK;
                    ViewModel.txtNumberPatients.Enabled = true;
                    ViewManager.SetCurrent(ViewModel.txtNumberPatients);
                }
                else
                {
                    ViewModel.cboUnit[Index].Enabled = true;
                }
            }
            ViewModel.NavButton[2].Visible = false;
            ViewModel.lbNavMessage.Visible = true;
            ViewModel.lbNavMessage.Text = "Make Selection";
            ViewModel.chkCivilianCasualty.Enabled = false;
            //    chkExposures.Enabled = False


            //Check something selected:
            //If so enable Next Button
            //Also check for allow Civilian Casualty
            //And Multiple Patients (make sure single patient unchecked)
            for (int i = 0; i <= 7; i++)
            {
                if (ViewModel.chkSitFound[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                {
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.lbNavMessage.Visible = false;
                    ViewModel.lbNavMessage.Visible = false;
                    //            If i = 0 Then
                    //                chkExposures.Enabled = True
                    //            End If
                    if (i == 0 || i == 1 || i == 2)
                    {
                        ViewModel.chkCivilianCasualty.Enabled = true;
                    }
                    if (i == 4)
                    {
                        ViewModel.chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.cboUnit[3].Enabled = false;
                    }
                }
            }
            if (!ViewModel.chkCivilianCasualty.Enabled)
            {
                ViewModel.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.NavButton[2].Visible = false;
                for (int i = 3; i <= 7; i++)
                {
                    if (ViewModel.chkSitFound[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                    }
                }
            }
            else if (ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                if (ViewModel.txtNumberCivCasulties.BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                {
                    ViewModel.NavButton[2].Visible = false;
                }
            }

            //    If chkExposures.Enabled = False Then
            //        chkExposures.Value = 0
            //        txtNumberExposures.Visible = False
            //    ElseIf chkExposures.Value = 1 Then
            //        If txtNumberExposures.BackColor = REQCOLOR Then
            //            NavButton(2).Visible = False
            //        End If
            //    End If
            ViewModel.DontRespond = 0;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAbandon_Click(Object eventSender, System.EventArgs eventArgs)
        {
            ViewManager.ShowMessage("All Changes Abandoned - Better Luck Next Time!", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
            ViewManager.DisposeView(this);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddPPE_Click(Object eventSender, System.EventArgs eventArgs)
        {
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();
            int i = 0;

            //Add new Personal Protective Equipment Problem Record

            if (ViewModel.cboFPEEquipment.SelectedIndex != -1)
            {
                Casualty.FE_FPECode = ViewModel.cboFPEEquipment.GetItemData(ViewModel.cboFPEEquipment.SelectedIndex);
                if (ViewModel.cboFPEStatus.SelectedIndex != -1)
                {
                    Casualty.FE_FPEStatus = ViewModel.cboFPEStatus.GetItemData(ViewModel.cboFPEStatus.SelectedIndex);
                    if (ViewModel.cboFPEProblem.SelectedIndex != -1)
                    {
                        Casualty.FE_FPEProblem = ViewModel.cboFPEProblem.GetItemData(ViewModel.cboFPEProblem.SelectedIndex);
                        Casualty.FECasualtyID = ViewModel.CurrReportID;
                        Casualty.Manufacturer = "";
                        Casualty.Model = "";
                        Casualty.SerialNumber = "";
                        if (~Casualty.AddFSCasualtyFailedEquipment() != 0)
                        {
                            ViewManager.ShowMessage("Error Attempting to Add PPE Problem Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                        LoadPPEList();
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddStaff_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Display Remaining Available Personnel Controls

            for (int i = 3; i <= 6; i++)
            {
                ViewModel.cboPersonnel[i].Visible = true;
                ViewModel.cboPosition[i].Visible = true;
                ViewModel.cmdClearPerson[i].Visible = true;
                ViewModel.chkCasualty[i].Visible = true;
                //No Exposure Info collected at this time
                //        chkExposure(i).Visible = True
            }

            ViewModel.cmdAddStaff.Visible = false;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClearPerson_Click(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cmdClearPerson.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel)eventSender);
            //Clear Personnel and Position Selections
            if (Index < 6)
            {
                //        cboPosition(Index).ListIndex = -1
                //        chkCasualty(Index).Value = 0
            }

            ViewModel.cboPersonnel[Index].SelectedIndex = -1;

            //No Exposure Info collected at this time
            //    chkExposure(Index).Value = 0
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRemovePPE_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Check For a Selected Entry
            //Delete Selected Record
            TFDIncident.clsCasualty Casualty = Container.Resolve<clsCasualty>();

            int ItemSelected = 0;
            for (int i = 0; i <= ViewModel.lstPPE.Items.Count - 1; i++)
            {
                if (ViewModel.lstPPE.GetSelected(i))
                {
                    ItemSelected = -1;
                    break;
                }
            }
            if (~ItemSelected != 0)
            {
                return;
            }

            for (int i = 0; i <= ViewModel.lstPPE.Items.Count - 1; i++)
            {
                if (ViewModel.lstPPE.GetSelected(i))
                {
                    int tempRefParam = ViewModel.lstPPE.GetItemData(i);
                    if (~Casualty.DeleteFSCasualtyFailedEquipment(ref tempRefParam) != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Delete PPE Problem Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                }
            }

            LoadPPEList();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //Save Current Report as Complete
                string msg = "";
                using (var async2 = this.Async())
                {


                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.UNITREPORT:
                            //Save UnitReport 
                            if (SaveUnitReport(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Unit Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Unit Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.INCIDENTREPORT:
                            async2.Append<System.Int32>(() => SaveSituationFound(IncidentMain.COMPLETE));
                            async2.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                            async2.Append<System.Int32>(tempNormalized1 =>
                                {
                                    //Save Incident Situation Found Data 
                                    if (tempNormalized1 != 0)
                                    {
                                        ViewManager.ShowMessage("Incident Situation Found Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                });
                            break;
                        case IncidentMain.INVESTIGATION:
                        case IncidentMain.CLEANUP:
                        case IncidentMain.STANDBY:
                            //Save Service Report 
                            if (ViewModel.CurrReport == IncidentMain.INVESTIGATION)
                            {
                                msg = "Investigation Only Report ";
                            }
                            else if (ViewModel.CurrReport == IncidentMain.CLEANUP)
                            {
                                msg = "Clean Up Only Report ";
                            }
                            else
                            {
                                msg = "Standby/Staging Report ";
                            }
                            if (SaveServiceReport(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage(msg + "Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.HAZCONDITION:
                        case IncidentMain.SEARCHRESCUE:
                        case IncidentMain.FALSEALARM:
                            //Save Reports from AllInfo Form 
                            if (ViewModel.CurrReport == IncidentMain.HAZCONDITION)
                            {
                                msg = "Hazardous Condition Report ";
                            }
                            else if (ViewModel.CurrReport == IncidentMain.SEARCHRESCUE)
                            {
                                msg = "Search/Rescue Report ";
                            }
                            else
                            {
                                msg = "False Alarm Report ";
                            }
                            if (SaveAllInfo(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage(msg + "Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.CIVILCASUALTY:
                            if (SaveCivilianCasualty(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Civilian Casualty Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Civilian Casualty Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.FSCASUALTY:
                            if (SaveCasualty("", "", IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Fire Service Casualty Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Fire Service Casualty Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            //        Case ADDRESSCORRECTION 
                            //            If SaveAddressCorrection(COMPLETE) Then 
                            //                MsgBox "Incident Address Correction Saved as Complete", vbOKOnly, "TFD Incident Reporting Wizard" 
                            //            Else 
                            //                MsgBox "Error Attempting to Save Incident Address Correction", vbCritical, "TFD Incident Reporting Wizard" 
                            //            End If 
                            break;
                    }
                }
                async1.Append(() =>
                    {

                        IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);


                        if (~CheckReportStatus() != 0)
                        {
                            //No Pending Reports
                            ViewModel.NavButton[0].Visible = false;
                            ViewModel.NavButton[1].Visible = false;
                            ViewModel.NavButton[2].Visible = false;
                            ViewModel.NavButton[3].Visible = false;
                            ViewModel.NavButton[4].Visible = true;
                            ViewModel.lbNavMessage.Text = "You're Done!";
                            ViewModel.cmdSave.Enabled = false;
                            ViewModel.cmdSaveIncomplete.Enabled = false;
                            ViewModel.cmdAbandon.Enabled = false;
                        }
                        else
                        {
                            ViewModel.NavButton[0].Visible = false;
                            ViewModel.NavButton[1].Visible = false;
                            ViewModel.NavButton[2].Visible = true;
                            ViewModel.lbNavMessage.Visible = false;
                            ViewModel.lbNavMessage.Visible = false;
                            ViewModel.NavButton[3].Visible = false;
                            ViewModel.NavButton[4].Visible = false;
                        }
                    });
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSaveIncomplete_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //Save Current Report as Incomplete
                string msg = "";
                using (var async2 = this.Async())
                {

                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.UNITREPORT:
                            //Save UnitReport 
                            if (SaveUnitReport(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Unit Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                this.Return();
                                return;
                            }
                            break;
                        case IncidentMain.INCIDENTREPORT:
                            async2.Append<System.Int32>(() => SaveSituationFound(IncidentMain.SAVEDINCOMPLETE));
                            async2.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                            async2.Append<System.Int32>(tempNormalized1 =>
                                {
                                    //Save Incident Situation Found Data 
                                    if (tempNormalized1 != 0)
                                    {
                                        ViewManager.ShowMessage("Incident Situation Found Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save Incident Situation Found Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        this.Return();
                                        return;
                                    }
                                });
                            break;
                        case IncidentMain.INVESTIGATION:
                        case IncidentMain.CLEANUP:
                        case IncidentMain.STANDBY:
                            //Save Service Report 
                            if (ViewModel.CurrReport == IncidentMain.INVESTIGATION)
                            {
                                msg = "Investigation Only Report ";
                            }
                            else if (ViewModel.CurrReport == IncidentMain.CLEANUP)
                            {
                                msg = "Clean Up Only Report ";
                            }
                            else
                            {
                                msg = "Standby/Staging Report ";
                            }
                            if (SaveServiceReport(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage(msg + "Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.HAZCONDITION:
                        case IncidentMain.SEARCHRESCUE:
                        case IncidentMain.FALSEALARM:
                            //Save Reports from AllInfo Form 
                            if (ViewModel.CurrReport == IncidentMain.HAZCONDITION)
                            {
                                msg = "Hazardous Condition Report ";
                            }
                            else if (ViewModel.CurrReport == IncidentMain.SEARCHRESCUE)
                            {
                                msg = "Search/Rescue Report ";
                            }
                            else
                            {
                                msg = "False Alarm Report ";
                            }
                            if (SaveAllInfo(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage(msg + "Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save " + msg, "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.CIVILCASUALTY:
                            if (SaveCivilianCasualty(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Civilian Casualty Report Saved as Incomplete", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Civilian Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.FSCASUALTY:
                            if (SaveCasualty("", "", IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Fire Service Casualty Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Fire Service Casualty Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        case IncidentMain.ADDRESSCORRECTION:
                            if (SaveAddressCorrection(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Incident Address Correction Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error Attempting to Save Incident Address Correction", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                    }
                }
                async1.Append(() =>
                    {

                        IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);


                        if (~CheckReportStatus() != 0)
                        {
                            //No Pending Reports
                            ViewModel.NavButton[0].Visible = false;
                            ViewModel.NavButton[1].Visible = false;
                            ViewModel.NavButton[2].Visible = false;
                            ViewModel.NavButton[3].Visible = false;
                            ViewModel.NavButton[4].Visible = true;
                            ViewModel.lbNavMessage.Text = "You're Done!";
                            ViewModel.cmdSave.Enabled = false;
                            ViewModel.cmdSaveIncomplete.Enabled = false;
                            ViewModel.cmdAbandon.Enabled = false;
                        }
                        else
                        {
                            ViewModel.NavButton[0].Visible = false;
                            ViewModel.NavButton[1].Visible = false;
                            ViewModel.NavButton[2].Visible = true;
                            ViewModel.lbNavMessage.Visible = false;
                            ViewModel.lbNavMessage.Visible = false;
                            ViewModel.NavButton[3].Visible = false;
                            ViewModel.NavButton[4].Visible = false;
                        }
                    });
            }

        }

        private void SaveNarration()
        {
            //Save Narration Record
            if (ViewModel.rtxNarration.Text == "")
            {
                return;
            }
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();

            IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
            IncidentCL.ReportType = ViewModel.CurrReport;
            string tempRefParam = ViewModel.rtxNarration.Text;
            IncidentCL.NarrationText = IncidentMain.ProofSQLString(ref tempRefParam);
            IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
            IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
            if (~IncidentCL.AddNarration() != 0)
            {
                ViewManager.ShowMessage("Error attempting to save Narration Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void FDCaresBtn_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                IncidentMain.Shared.gFDCaresIncidentID = ViewModel.CurrIncident;
                IncidentMain.Shared.gFDCaresPatientID = 0;
                IncidentMain.Shared.gFDCaresComment = "";
                IncidentMain.Shared.gFDCaresOK = -1;
                async1.Append(() =>
                    {
                        ViewManager.NavigateToView(
                            dlgFDCares.DefInstance, true);
                    });
                async1.Append(() =>
                    {
                        if (IncidentMain.Shared.gFDCaresOK != 0)
                        {
                            if (~IncidentMain.ProcessFDCaresReferral(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresPatientID) != 0)
                            {
                                ViewManager.ShowMessage("Unable to process FDCares Referral", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
                                    Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Incident Referred to FDCares", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
                                    Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            ViewModel.FDCaresBtn.Enabled = false;
                        }
                    });
            }

        }

        internal void wzdMain_Activated(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                if (UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
                {
                    UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
                    //    If gWizCancel Then Unload Me
                    if (ViewModel.FormOpening != 0)
                    {
                        ViewModel.FormOpening = 0;
                        async1.Append(() =>
                            {
                                StepNext();
                            });
                    }

                }
            }
        }

        //UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

        private void Form_Load()
        {
            //Entrance for New Report Wizard
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            int ShowFrame = 0;
            ViewModel.CurrIncident = IncidentMain.Shared.gWizardIncidentID;
            CheckReportStatus();
            if (~IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
            {
                //Unable to Retrieve Incident Record - don't open Wizard
                ViewManager.ShowMessage("Error Retrieving Incident Record - Unable to Start Incident Report Wizard", "TFD Incident Report Wizard", UpgradeHelpers.Helpers
                    .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
                return;
            }
            ViewModel.lbLocation.Text = IncidentCL.Location;
            ViewModel.lbIncidentNo.Text = IncidentCL.IncidentNumber;
            ViewModel.lbUnit.Text = IncidentMain.Shared.gWizardUnitID;
            IncidentMain.MoveForm(wzdMain.DefInstance);
            ViewModel.CurrFrame = ViewModel.frmOpen;
            IncidentMain.Shared.gWizCancel = 0;
            ViewModel.FormOpening = -1;
            ViewModel.DontRespond = 0;
            ViewModel.ShowAddress = -1;

        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
            //    frmMain.LoadUnitList
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstActionsTaken_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void lstReasonDelay_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void NavButton_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                int Index = this.ViewModel.NavButton.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel)eventSender);
                //Navigation Button Pressed
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                using (var async2 = this.Async())
                {

                    switch (Index)
                    {
                        case 0:  //Cancel 

                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                    => ViewManager.ShowMessage("Do you wish to Exit Without Saving any Changes?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                {
                                    Response = tempNormalized1;
                                });
                            async2.Append(() =>
                                {
                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                    {
                                        ViewManager.DisposeView(this);
                                    }
                                    else
                                    {
                                        this.Return();
                                        return;
                                    }
                                });
                            break;
                        case 1:  //Back 
                            StepBack();
                            break;
                        case 2:  //Next 

                            async2.Append(() =>
                                {
                                    StepNext();
                                });
                            break;
                        case 3:  //Quit & Save 

                            async2.Append(() =>
                                {
                                    StepQuit();
                                });
                            break;
                        case 4:  //Finish 

                            async2.Append(() =>
                                {
                                    StepFinish();
                                });
                            break;
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void optServiceReport_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index = this.ViewModel.optServiceReport.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                //Remove all Non Service Report Changes
                if (ViewModel.DontRespond != 0)
                {
                    return;
                }
                ViewModel.DontRespond = -1;

                for (int i = 0; i <= 7; i++)
                {
                    if (i != 4)
                    {
                        ViewModel.cboUnit[i].Enabled = false;
                    }
                    else
                    {
                        ViewModel.txtNumberPatients.Text = "";
                        ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                    }
                    ViewModel.chkSitFound[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                }
                ViewModel.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.chkCivilianCasualty.Enabled = false;
                //    chkExposures.Value = 0
                //    chkExposures.Enabled = False
                ViewModel.frmMultiEMS.Visible = false;
                for (int i = 0; i <= 12; i++)
                {
                    ViewModel.lbPatient[i].Visible = false;
                    ViewModel.cboEMSUnit[i].Visible = false;
                    ViewModel.chkSirenReport[i].Visible = false;
                }
                ViewModel.cboUnit[Index + 9].Enabled = true;
                ViewModel.NavButton[2].Visible = true;
                ViewModel.lbNavMessage.Visible = false;
                ViewModel.DontRespond = 0;

            }
        }



        private void rtxUnitNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.UnitReportUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAllInfo1_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Check for Numerics
            if (ViewModel.txtAllInfo1.Text == "")
            {
                return;
            }

            double dbNumericTemp = 0;
            if (!Double.TryParse(ViewModel.txtAllInfo1.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtAllInfo1.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAmendTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.txtAmendTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel)eventSender);
            //int Index = 1;
         

            //for (int i = 1; i <= 5; i++) { 

               
            //    {

            //    }

            // }
            if (ViewModel.txtAmendTime[Index].Text == "__:__")
            {
                ViewModel.cboAmendReason[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboAmendReason[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtAmendTime[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.cboAmendReason[Index].SelectedIndex = -1;
            }
            else
            {
                ViewModel.txtAmendTime[Index].BackColor = Color.White;
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;

                if (ViewModel.cboAmendReason[Index].SelectedIndex == -1)
                {
                    ViewModel.cboAmendReason[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.cboAmendReason[Index].ForeColor = IncidentMain.Shared.BLACK;
                }
            }
            ViewModel.UnitReportUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAmendTime_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.txtAmendTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel)eventSender);
            //Edit TimeEntry
            //Don't edit if empty
            if (ViewModel.txtAmendTime[Index].Text == "__:__")
            {
                return;
            }

            string HourWork = "", MinWork = "";

            string TimeWork = ViewModel.txtAmendTime[Index].Text;
            TimeWork = Strings.Replace(TimeWork, "_", "0", 1, -1, CompareMethod.Binary);
            int TimeCheck = Convert.ToInt32(Conversion.Val(TimeWork.Substring(0, Math.Min(2, TimeWork.Length))));
            if (TimeCheck > 23)
            {
                ViewModel.txtAmendTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewManager.SetCurrent(ViewModel.txtAmendTime[Index]);
                return;
            }
            if (TimeCheck < 10)
            {
                HourWork = "0" + TimeCheck.ToString();
            }
            else
            {
                HourWork = TimeCheck.ToString();
            }
            TimeCheck = Convert.ToInt32(Conversion.Val(TimeWork.Substring(Math.Max(TimeWork.Length - 2, 0))));
            if (TimeCheck > 59)
            {
                ViewModel.txtAmendTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewManager.SetCurrent(ViewModel.txtAmendTime[Index]);
                return;
            }
            if (TimeCheck < 10)
            {
                MinWork = "0" + TimeCheck.ToString();
            }
            else
            {
                MinWork = TimeCheck.ToString();
            }
            bool FirstTime = true;
            TimeWork = HourWork + ":" + MinWork;
            ViewModel.txtAmendTime[Index].Text = TimeWork;
            FirstTime = false;

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberCivCasulties_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Make Sure that a number is entered
            double dbNumericTemp = 0;
            if (ViewModel.txtNumberCivCasulties.Text == "")
            {
                ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.NavButton[2].Visible = false;
            }
            else if (!Double.TryParse(ViewModel.txtNumberCivCasulties.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtNumberCivCasulties.Text = "";
            }
            else
            {
                ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.NavButton[2].Visible = false;
            }

        }

        //Private Sub txtNumberExposures_Change()
        //    'Make Sure that a number is entered
        //    CheckComplete
        //End Sub
        [UpgradeHelpers.Events.Handler]
        internal void txtNumberPatients_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }

            int NumberOfPatients = 0;
            ViewModel.frmMultiEMS.Visible = false;
            ViewModel.lbEMSReportingUnit.Visible = false;
            for (int i = 0; i <= 12; i++)
            {
                ViewModel.lbPatient[i].Visible = false;
                ViewModel.cboEMSUnit[i].Visible = false;
                ViewModel.chkSirenReport[1].Visible = false;
            }

            double dbNumericTemp = 0;
            if (ViewModel.txtNumberPatients.Text == "")
            {
                ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.BLACK;
            }
            else if (!Double.TryParse(ViewModel.txtNumberPatients.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtNumberPatients.Text = "";
                ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.BLACK;
            }
            else
            {
                ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                ViewModel.frmMultiEMS.Visible = true;
                ViewModel.lbEMSReportingUnit.Visible = true;
                if (Conversion.Val(ViewModel.txtNumberPatients.Text) > 13)
                {
                    ViewModel.txtNumberPatients.Text = "13";
                    ViewManager.ShowMessage("System Current Only Allows for 13 Patients per Incident", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                }
                NumberOfPatients = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberPatients.Text));
                for (int i = 0; i <= NumberOfPatients - 1; i++)
                {
                    ViewModel.lbPatient[i].Visible = true;
                    ViewModel.cboEMSUnit[i].Visible = true;
                    ViewModel.chkSirenReport[i].Visible = true;
                }
            }


        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberSafePlace_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtNumberSafePlace.Text != "")
            {
                double dbNumericTemp = 0;
                if (!Double.TryParse(ViewModel.txtNumberSafePlace.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    ViewModel.txtNumberSafePlace.Text = "";
                    ViewManager.SetCurrent(ViewModel.txtNumberSafePlace);
                }
                else
                {
                    ViewModel.txtNumberSafePlace.Text = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberSafePlace.Text)).ToString();
                }
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtStandbyHours_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtStandbyHours.Text != "")
            {
                double dbNumericTemp = 0;
                if (!Double.TryParse(ViewModel.txtStandbyHours.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    ViewModel.txtStandbyHours.Text = "";
                    ViewManager.SetCurrent(ViewModel.txtStandbyHours);
                }
                else
                {
                    ViewModel.txtStandbyHours.Text = Convert.ToInt32(Conversion.Val(ViewModel.txtStandbyHours.Text)).ToString();
                }
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXStreetName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.DontRespond != 0)
            {
                return;
            }
            CheckComplete();
        }

        public static wzdMain DefInstance
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

        public static wzdMain CreateInstance()
        {
            TFDIncident.wzdMain theInstance = Shared.Container.Resolve<wzdMain>();
            theInstance.Form_Load();
            return theInstance;
        }

        void ReLoadForm(bool addEvents)
        {
        }

        protected override void ExecuteControlsStartup()
        {
            //ViewModel.frmOpen.LifeCycleStartup();
            ViewModel.frmUnitReport.LifeCycleStartup();
            ViewModel.frmSitFound.LifeCycleStartup();
            ViewModel.frmMultiEMS.LifeCycleStartup();
            ViewModel.Frame2.LifeCycleStartup();
            ViewModel.frmReportStatus.LifeCycleStartup();
            ViewModel.frmService.LifeCycleStartup();
            ViewModel.frmAllInfo.LifeCycleStartup();
            ViewModel.frmCivilianCasualty.LifeCycleStartup();
            ViewModel.frmName.LifeCycleStartup();
            ViewModel.frmNarration.LifeCycleStartup();
            ViewModel.frmFSCasualty.LifeCycleStartup();
            ViewModel.NavBar.LifeCycleStartup();
            ViewModel.frmFPE.LifeCycleStartup();
            ViewModel.frmIncidentAddressCorrection.LifeCycleStartup();
            base.ExecuteControlsStartup();
            this.DynamicControlsStartup();
        }

        protected override void ExecuteControlsShutdown()
        {
            //ViewModel.frmOpen.LifeCycleShutdown();
            ViewModel.frmUnitReport.LifeCycleShutdown();
            ViewModel.frmSitFound.LifeCycleShutdown();
            ViewModel.frmMultiEMS.LifeCycleShutdown();
            ViewModel.Frame2.LifeCycleShutdown();
            ViewModel.frmReportStatus.LifeCycleShutdown();
            ViewModel.frmService.LifeCycleShutdown();
            ViewModel.frmAllInfo.LifeCycleShutdown();
            ViewModel.frmCivilianCasualty.LifeCycleShutdown();
            ViewModel.frmName.LifeCycleShutdown();
            ViewModel.frmNarration.LifeCycleShutdown();
            ViewModel.frmFSCasualty.LifeCycleShutdown();
            ViewModel.NavBar.LifeCycleShutdown();
            ViewModel.frmFPE.LifeCycleShutdown();
            ViewModel.frmIncidentAddressCorrection.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class wzdMain
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdMainViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual wzdMain m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }
}