using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

    public partial class wzdEms
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdEmsViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(wzdEms));
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


        private void wzdEms_Activated(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
            {
                UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
            }
        }
        //TFD Incident Reporting System - Development Prototype
        //Incident Report Entry Wizard Experimental Prototype

        //Current Focus Objects


        //Report Status - from Global Constants
        //0-NOREPORT, 1-INCOMPLETE, 2-SAVEDINCOMPLETE, 3-COMPLETE

        private void EditBirthdate()
        {
            //Edit Birthdate
            string sBirthDate = "";
            System.DateTime dBirthDate = DateTime.FromOADate(0);
            int Age = 0;
            ViewModel.FirstTime = -1;

            if (!Information.IsDate(ViewModel.mskBirthdate.Text))
            {
                ViewModel.mskBirthdate.Text = "__/__/____";
                ViewModel.txtPatientAge.Text = "";
                ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
            }
            else
            {
                sBirthDate = ViewModel.mskBirthdate.Text;
                System.DateTime TempDate = DateTime.FromOADate(0);
                dBirthDate = DateTime.Parse((DateTime.TryParse(sBirthDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : sBirthDate);
                if (dBirthDate > DateTime.Now)
                {
                    ViewModel.mskBirthdate.Text = "__/__/____";
                    return;
                }
                Age = (int)DateAndTime.DateDiff("d", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                if (Age < 30)
                {
                    ViewModel.txtPatientAge.Text = Age.ToString();
                    for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboPatientAgeUnits.GetItemData(i) == 3)
                        { //Age Unit - Days

                            ViewModel.cboPatientAgeUnits.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    Age = (int)DateAndTime.DateDiff("m", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                    if (Age < 12)
                    {
                        if (dBirthDate.AddMonths(Age) > DateTime.Now)
                        {
                            Age--;
                        }
                        ViewModel.txtPatientAge.Text = Age.ToString();
                        for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
                        {
                            if (ViewModel.cboPatientAgeUnits.GetItemData(i) == 2)
                            { //AgeUnit - Months

                                ViewModel.cboPatientAgeUnits.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Age = (int)DateAndTime.DateDiff("yyyy", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                        if (dBirthDate.AddYears(Age) > DateTime.Now)
                        {
                            Age--;
                        }
                        if (Age > 150)
                        {
                            ViewManager.ShowMessage("You Have Indicated an Unreasonable Age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            ViewModel.mskBirthdate.Text = "__/__/____";
                        }
                        else
                        {
                            ViewModel.txtPatientAge.Text = Age.ToString();
                            for (int i = 0; i <= ViewModel.cboPatientAgeUnits.Items.Count - 1; i++)
                            {
                                if (ViewModel.cboPatientAgeUnits.GetItemData(i) == 1)
                                { //AgeUnit - Years

                                    ViewModel.cboPatientAgeUnits.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            ViewModel.FirstTime = 0;

        }

        private void EditBasicBirthdate()
        {
            //Edit Birthdate
            string sBirthDate = "";
            System.DateTime dBirthDate = DateTime.FromOADate(0);
            int Age = 0;
            ViewModel.FirstTime = -1;

            if (!Information.IsDate(ViewModel.txtBBirthdate.Text))
            {
                ViewModel.txtBBirthdate.Text = "__/__/____";
                ViewModel.txtAge.Text = "";
                ViewModel.cboAgeUnits.SelectedIndex = -1;
            }
            else
            {
                sBirthDate = ViewModel.txtBBirthdate.Text;
                System.DateTime TempDate = DateTime.FromOADate(0);
                dBirthDate = DateTime.Parse((DateTime.TryParse(sBirthDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : sBirthDate);
                if (dBirthDate > DateTime.Now)
                {
                    ViewModel.txtBBirthdate.Text = "__/__/____";
                    return;
                }
                Age = (int)DateAndTime.DateDiff("d", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                if (Age < 30)
                {
                    ViewModel.txtAge.Text = Age.ToString();
                    for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboAgeUnits.GetItemData(i) == 3)
                        { //Age Unit - Days

                            ViewModel.cboAgeUnits.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    Age = (int)DateAndTime.DateDiff("m", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                    if (Age < 12)
                    {
                        if (dBirthDate.AddMonths(Age) > DateTime.Now)
                        {
                            Age--;
                        }
                        ViewModel.txtAge.Text = Age.ToString();
                        for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
                        {
                            if (ViewModel.cboAgeUnits.GetItemData(i) == 2)
                            { //AgeUnit - Months

                                ViewModel.cboAgeUnits.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Age = (int)DateAndTime.DateDiff("yyyy", DateTime.Parse(sBirthDate), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                        if (dBirthDate.AddYears(Age) > DateTime.Now)
                        {
                            Age--;
                        }
                        if (Age > 150)
                        {
                            ViewManager.ShowMessage("You Have Indicated an Unreasonable Age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            ViewModel.txtBBirthdate.Text = "__/__/____";
                        }
                        else
                        {
                            ViewModel.txtAge.Text = Age.ToString();
                            for (int i = 0; i <= ViewModel.cboAgeUnits.Items.Count - 1; i++)
                            {
                                if (ViewModel.cboAgeUnits.GetItemData(i) == 1)
                                { //AgeUnit - Years

                                    ViewModel.cboAgeUnits.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            ViewModel.FirstTime = 0;

        }

        private void LoadReportStatus()
        {
            //Format ReportStatus frame
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            ViewModel.lbRSIncidentNumber.Text = ViewModel.lbIncidentNo.Text;
            ViewModel.lbRSReportedBy.Text = IncidentMain.Shared.gCurrUserName;
            ViewModel.lbRSEmployeeID.Text = IncidentMain.Shared.gCurrUser;

            switch (ViewModel.CurrReport)
            {
                case IncidentMain.NOEXAM:
                    ViewModel.lbRSCurrReportType.Text = "No Exam - EMS Patient Contact Report";
                    break;
                case IncidentMain.EXAMONLY:
                    ViewModel.lbRSCurrReportType.Text = "Exam Only - EMS Patient Contact Report";
                    break;
                case IncidentMain.EXAMASSIST:
                    ViewModel.lbRSCurrReportType.Text = "Exam/Assist - EMS Patient Contact Report";
                    break;
                case IncidentMain.EXAMTRANSPORT:
                    ViewModel.lbRSCurrReportType.Text = "Exam/Assist/Transport - EMS Patient Contact Report";
                    break;
                case IncidentMain.INTERFAC:
                    ViewModel.lbRSCurrReportType.Text = "Interfacility Transfer - EMS Patient Contact Report";
                    break;
                default:
                    ViewModel.lbRSCurrReportType.Text = "";
                    break;
            }

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
            CheckComplete();

            IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);
        }


        private void LoadALSProcedures()
        {
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string sDisplay = "";
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            ViewModel.lstALSProcedures.Items.Clear();
            ViewModel.IVPerformed = 0;
            if (EMSReport.GetEMSProcedureByType(ViewModel.PatientID, "A") != 0)
            {

                while (!EMSReport.EMSProcedure.EOF)
                {
                    sDisplay = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]) + " - ";
                    sDisplay = sDisplay + IncidentMain.Clean(EMSReport.EMSProcedure["description"]);
                    ViewModel.lstALSProcedures.AddItem(sDisplay);
                    ViewModel.lstALSProcedures.SetItemData(ViewModel.lstALSProcedures.GetNewIndex(), Convert.ToInt32(EMSReport.EMSProcedure["procedure_id"]));
                    if (Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 14 || Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 15 || Convert.ToDouble(EMSReport.EMSProcedure["proc_code"]) == 16)
                    {
                        ViewModel.IVPerformed = -1;
                    }
                    EMSReport.EMSProcedure.MoveNext();
                };
                // Save incident type as ALSTRANS or ALS
                if (ViewModel.cboTransportTo.SelectedIndex != -1)
                {
                    if (ViewModel.cboTransportBy.SelectedIndex != -1)
                    {
                        if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) != "")
                        {
                            if (UnitCL.GetTranportUnitALSFlag(ViewModel.cboTransportBy.Text) != 0)
                            {
                                ViewModel.EMSType = IncidentMain.ALSTRANS;
                            }
                            else
                            {
                                ViewModel.EMSType = IncidentMain.BLSTRANS;
                            }
                        }
                        else
                        {
                            ViewModel.EMSType = IncidentMain.BLSTRANS;
                        }
                    }
                    else
                    {
                        ViewModel.EMSType = IncidentMain.ALSTRANS;
                    }
                }
                else
                {
                    ViewModel.EMSType = IncidentMain.ALS;
                }
                // Save Treatment Authorization, Level of Care and Severity
                EMSReport.LevelOfCareAlsBls = "A";
                if (ViewModel.cboTreatmentAuth.SelectedIndex != -1)
                {
                    EMSReport.TreatmentAuthorization = ViewModel.cboTreatmentAuth.GetItemData(ViewModel.cboTreatmentAuth.SelectedIndex);
                }
                for (int i = 0; i <= 2; i++)
                {
                    EMSReport.Severity = (ViewModel.optSeverity[i].Checked) ? -1 : 0;
                }
                ViewModel.cmdRemoveALSProcedures.Enabled = true;
            }
            else
            {
                ViewModel.cmdRemoveALSProcedures.Enabled = false;
            }
            ViewModel.txtAttempts.Text = "";
            ViewModel.cboALSProcedures.SelectedIndex = -1;

            CheckComplete();
        }


        private void LoadBLSProcedures()
        {
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string sDisplay = "";
            ViewModel.ExtricationPerformed = 0;
            ViewModel.FirstTime = -1;
            ViewModel.lstBLSProcedures.Items.Clear();
            if (EMSReport.GetEMSProcedureByType(ViewModel.PatientID, "B") != 0)
            {

                while (!EMSReport.EMSProcedure.EOF)
                {
                    sDisplay = IncidentMain.Clean(EMSReport.EMSProcedure["name_full"]) + " - ";
                    sDisplay = sDisplay + IncidentMain.Clean(EMSReport.EMSProcedure["description"]);
                    ViewModel.lstBLSProcedures.AddItem(sDisplay);
                    ViewModel.lstBLSProcedures.SetItemData(ViewModel.lstBLSProcedures.GetNewIndex(), Convert.ToInt32(EMSReport.EMSProcedure["procedure_id"]));
                    switch (Convert.ToInt32(EMSReport.EMSProcedure["proc_code"]))
                    {
                        case 3:
                        case 5:
                        case 33:
                        case 34:
                        case 35:  //Extrication 

                            ViewModel.ExtricationPerformed = -1;
                            break;
                        case 8:
                        case 31:  //CPR performed 

                            ViewModel.chkCPRPerformed.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            break;
                    }
                    EMSReport.EMSProcedure.MoveNext();
                };
                ViewModel.cmdRemoveBLSProcedures.Enabled = true;
            }
            else
            {
                ViewModel.cmdRemoveBLSProcedures.Enabled = false;
            }
            EMSReport.Severity = 3; //Urgent

            EMSReport.LevelOfCareAlsBls = "B";
            ViewModel.FirstTime = 0;
            CheckComplete();

        }

        private void LoadCPRPerformedBy()
        {
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string sDisplay = "";
            ViewModel.lstCPRPerformedBy.Items.Clear();
            if (EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
            {

                while (!EMSReport.EMSCPRPerformer.EOF)
                {
                    sDisplay = IncidentMain.Clean(EMSReport.EMSCPRPerformer["description"]);
                    ViewModel.lstCPRPerformedBy.AddItem(sDisplay);
                    ViewModel.lstCPRPerformedBy.SetItemData(ViewModel.lstCPRPerformedBy.GetNewIndex(), Convert.ToInt32(EMSReport.EMSCPRPerformer["cpr_id"]));
                    EMSReport.EMSCPRPerformer.MoveNext();
                };
            }
            CheckComplete();

        }

        private void LoadMedications()
        {
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string sDisplay = "";
            ViewModel.lstMedications.Items.Clear();
            if (EMSReport.GetEMSMedicationRS(ViewModel.PatientID) != 0)
            {

                while (!EMSReport.EMSMedication.EOF)
                {
                    sDisplay = IncidentMain.Clean(EMSReport.EMSMedication["description"]) + " - " + Convert.ToString(EMSReport.EMSMedication["administered_dosage"]);
                    ViewModel.lstMedications.AddItem(sDisplay);
                    ViewModel.lstMedications.SetItemData(ViewModel.lstMedications.GetNewIndex(), Convert.ToInt32(EMSReport.EMSMedication["med_code"]));
                    EMSReport.EMSMedication.MoveNext();
                };
                ViewModel.cmdRemoveMedication.Enabled = true;
            }
            else
            {
                ViewModel.cmdRemoveMedication.Enabled = false;
            }
            ViewModel.cboMedications.SelectedIndex = -1;
        }

        private void InitialSave()
        {
            //save incomplete EMS Patient Contact record
            //capture new PatientID
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            TFDIncident.clsIncident cIncident = Container.Resolve<clsIncident>();

            EMSReport.IncidentID = ViewModel.CurrIncident;
            EMSReport.ActionTaken = ViewModel.ActionTaken;
            if (cIncident.GetIncident(ViewModel.CurrIncident) != 0)
            {
                int iType;
                if (int.TryParse(cIncident.CADFinalType, out iType))
                {
                    switch (iType)
                    {
                        case 91:
                            EMSReport.IncidentType = 66;
                            break;
                        case 92:
                            EMSReport.IncidentType = 67;
                            break;
                        case 93:
                            EMSReport.IncidentType = 68;
                            break;
                        case 94:
                            EMSReport.IncidentType = 69;
                            break;
                        default:
                            EMSReport.IncidentType = 0;
                            break;
                    }
                }
                else {
                    EMSReport.IncidentType = 0;
                }

            }
            EMSReport.Gender = 0;
            EMSReport.Age = 0;
            EMSReport.AgeUnit = 0;
            EMSReport.Race = 0;
            EMSReport.Ethnicity = 0;
            EMSReport.IncidentLocation = 0;
            EMSReport.IncidentZipcode = "";
            EMSReport.IncidentSetting = 0;
            EMSReport.Severity = 0;
            EMSReport.DispatchedAlsBls = ViewModel.DispatchedAs;
            EMSReport.LevelOfCareAlsBls = "0";
            EMSReport.TreatmentAuthorization = 0;
            EMSReport.ResearchCode = 0;
            if (ViewModel.ReportSaved != 0)
            {
                if (~EMSReport.UpdateEMSPatientContact() != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Update EMS Patient Contact", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                //Create new report
                if (EMSReport.AddEMSPatientContact() != 0)
                {
                    ViewModel.PatientID = EMSReport.PatientID;
                    ViewModel.ReportSaved = -1;
                }
                else
                {
                    ViewManager.ShowMessage("Error attempting initial save", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

        }

        private int CheckComplete()
        {
            //Check for Entries in Required Fields
            //Flip Colors as needed

            int result = 0;
            if (ViewModel.FirstTime != 0)
            {
                return result;
            }

            int OptCheck = 0;
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            string UnitCheck = "";
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            int Age = 0;
            string AgeType = "";
            ViewModel.FirstTime = -1;
            result = -1;
            if (ViewModel.cboIncidentLocation.SelectedIndex == -1)
            {
                ViewModel.cboIncidentLocation.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboIncidentLocation.Text = "";
                result = 0;
            }
            else
            {
                ViewModel.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboIncidentLocation.ForeColor = IncidentMain.Shared.EMSFONT;
            }
            double dbNumericTemp = 0;
            if (ViewModel.txtIncidentZipcode.Text == "")
            {
                ViewModel.txtIncidentZipcode.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                result = 0;
            }
            else if (!Double.TryParse(ViewModel.txtIncidentZipcode.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtIncidentZipcode.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtIncidentZipcode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtIncidentZipcode.Text = "";
                result = 0;
            }
            else
            {
                ViewModel.txtIncidentZipcode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtIncidentZipcode.ForeColor = IncidentMain.Shared.EMSFONT;
            }
            if (ViewModel.cboIncidentSetting.SelectedIndex == -1)
            {
                ViewModel.cboIncidentSetting.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboIncidentSetting.Text = "";
                result = 0;
            }
            else
            {
                ViewModel.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboIncidentSetting.ForeColor = IncidentMain.Shared.EMSFONT;
            }

            if (ViewModel.NarrationRequired != 0)
            {
                if (IncidentMain.Clean(ViewModel.rtxNarration.Text) == "")
                {
                    ViewModel.rtxNarration.BackColor = IncidentMain.Shared.REQCOLOR;
                    result = 0;
                }
                else
                {
                    ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
            }
            else
            {
                ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            }

            switch (ViewModel.CurrReport)
            {
                case IncidentMain.NOEXAM:
                    //No exam, refused treatment, or DOA 
                    if (ViewModel.txtBFirstName.Text == "")
                    {
                        ViewModel.txtBFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtBFirstName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        result = 0;
                    }
                    else
                    {
                        ViewModel.txtBFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtBFirstName.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.txtBLastName.Text == "")
                    {
                        ViewModel.txtBLastName.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtBLastName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        result = 0;
                    }
                    else
                    {
                        ViewModel.txtBLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtBLastName.ForeColor = IncidentMain.Shared.EMSFONT;
                    }

                    if (ViewModel.txtBBirthdate.Text == "__/__/____")
                    {
                        double dbNumericTemp2 = 0;
                        if (ViewModel.txtAge.Text == "")
                        {
                            ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboAgeUnits.SelectedIndex = -1;
                            ViewModel.cboAgeUnits.Text = "";
                            ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtAge.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                        {
                            ViewModel.txtAge.Text = "";
                            ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboAgeUnits.SelectedIndex = -1;
                            ViewModel.cboAgeUnits.Text = "";
                            ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (Conversion.Val(ViewModel.txtAge.Text) > 150)
                        {
                            ViewManager.ShowMessage("You have indicated an unreasonable age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            ViewModel.txtAge.Text = "";
                            ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboAgeUnits.SelectedIndex = -1;
                            ViewModel.cboAgeUnits.Text = "";
                            ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtBBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
                            ViewModel.txtBBirthdate.Text = "__/__/____";
                            ViewModel.txtAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtAge.ForeColor = IncidentMain.Shared.EMSFONT;
                            Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
                            if (ViewModel.cboAgeUnits.SelectedIndex == -1)
                            {
                                ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAgeUnits.Text = "";
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
                                AgeType = ViewModel.cboAgeUnits.Text.Trim();
                                if (Age > 11)
                                {
                                    if (AgeType == "Months")
                                    {
                                        ViewManager.ShowMessage("Months Can NOT be Selected if Greater than 11", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewModel.txtAge.Text = "";
                                        ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboAgeUnits.SelectedIndex = -1;
                                        result = 0;
                                    }
                                    if (Age > 29)
                                    {
                                        if (AgeType == "Days")
                                        {
                                            ViewManager.ShowMessage("Days Can NOT be Selected if Greater than 29", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                                BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            ViewModel.txtAge.Text = "";
                                            ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                            ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                            ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                            ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                            ViewModel.cboAgeUnits.SelectedIndex = -1;
                                            result = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!Information.IsDate(ViewModel.txtBBirthdate.Text))
                    {
                        ViewModel.txtBBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtBBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtBBirthdate.Text = "__/__/____";
                        ViewModel.txtAge.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtAge.Text = "";
                        ViewModel.cboAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAgeUnits.SelectedIndex = -1;
                    }
                    else
                    {
                        ViewModel.txtBBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtBBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtAge.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
                        EditBasicBirthdate();
                        ViewModel.FirstTime = -1;
                    }
                    if (!ViewModel.optEMSGender[0].Checked && !ViewModel.optEMSGender[1].Checked)
                    {
                        //frmBasicGender.BackColor = REQCOLOR
                        ViewModel.frmBasicGender.Font = ViewModel.frmBasicGender.Font.Change(name: IncidentMain.WHITE.ToString());
                        ViewModel.optEMSGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optEMSGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optEMSGender[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.optEMSGender[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    }
                    else
                    {
                        ViewModel.optEMSGender[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optEMSGender[1].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optEMSGender[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.optEMSGender[1].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboEMSRace.SelectedIndex < 0)
                    {
                        ViewModel.cboEMSRace.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboEMSRace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboEMSRace.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboEMSRace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboEMSRace.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboServiceProvided.SelectedIndex < 0)
                    {
                        ViewModel.cboServiceProvided.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboServiceProvided.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboServiceProvided.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboServiceProvided.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboServiceProvided.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboIncidentLocation.SelectedIndex == -1)
                    {
                        ViewModel.cboIncidentLocation.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboIncidentLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboIncidentLocation.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboIncidentLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboIncidentLocation.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboIncidentSetting.SelectedIndex == -1)
                    {
                        ViewModel.cboIncidentSetting.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboIncidentSetting.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboIncidentSetting.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboIncidentSetting.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboIncidentSetting.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    break;
            }
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.EXAMONLY:
                case IncidentMain.EXAMASSIST:
                case IncidentMain.EXAMTRANSPORT:
                case IncidentMain.INTERFAC:
                    //all common fields 
                    if (ViewModel.txtFirstName.Text == "")
                    {
                        ViewModel.txtFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtFirstName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        result = 0;
                    }
                    else
                    {
                        ViewModel.txtFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtFirstName.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.txtLastName.Text == "")
                    {
                        ViewModel.txtLastName.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtLastName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        result = 0;
                    }
                    else
                    {
                        ViewModel.txtLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtLastName.ForeColor = IncidentMain.Shared.EMSFONT;
                    }

                    if (!ViewModel.optGender[0].Checked && !ViewModel.optGender[1].Checked)
                    {
                        //frmGender.BackColor = REQCOLOR
                        ViewModel.frmGender.Font = ViewModel.frmGender.Font.Change(name: IncidentMain.WHITE.ToString());
                        ViewModel.optGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optGender[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.optGender[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    }
                    else
                    {
                        ViewModel.optGender[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optGender[1].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optGender[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.optGender[1].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboRace.SelectedIndex == -1)
                    {
                        ViewModel.cboRace.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboRace.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboRace.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboRace.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboRace.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    //Must enter either birthdate OR age and age units 
                    if (ViewModel.mskBirthdate.Text == "__/__/____")
                    {
                        double dbNumericTemp3 = 0;
                        if (ViewModel.txtPatientAge.Text == "")
                        {
                            ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                            ViewModel.cboPatientAgeUnits.Text = "";
                            ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPatientAge.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                        {
                            ViewModel.txtPatientAge.Text = "";
                            ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                            ViewModel.cboPatientAgeUnits.Text = "";
                            ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (Conversion.Val(ViewModel.txtPatientAge.Text) > 150)
                        {
                            ViewManager.ShowMessage("You have indicated an unreasonable age", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            ViewModel.txtPatientAge.Text = "";
                            ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                            ViewModel.cboPatientAgeUnits.Text = "";
                            ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.mskBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.mskBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
                            ViewModel.mskBirthdate.Text = "__/__/____";
                            ViewModel.txtPatientAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtPatientAge.ForeColor = IncidentMain.Shared.EMSFONT;
                            Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
                            if (ViewModel.cboPatientAgeUnits.SelectedIndex == -1)
                            {
                                ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboPatientAgeUnits.Text = "";
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboPatientAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
                                AgeType = ViewModel.cboPatientAgeUnits.Text.Trim();
                                if (Age > 11)
                                {
                                    if (AgeType == "Months")
                                    {
                                        ViewManager.ShowMessage("Months Can NOT be Selected if Greater than 11", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewModel.txtPatientAge.Text = "";
                                        ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                                        result = 0;
                                    }
                                    if (Age > 29)
                                    {
                                        if (AgeType == "Days")
                                        {
                                            ViewManager.ShowMessage("Days Can NOT be Selected if Greater than 29", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                                BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            ViewModel.txtPatientAge.Text = "";
                                            ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                            ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                            ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                            ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                            ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                                            result = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!Information.IsDate(ViewModel.mskBirthdate.Text))
                    {
                        ViewModel.mskBirthdate.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.mskBirthdate.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.mskBirthdate.Text = "__/__/____";
                        ViewModel.txtPatientAge.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.txtPatientAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtPatientAge.Text = "";
                        ViewModel.cboPatientAgeUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboPatientAgeUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboPatientAgeUnits.SelectedIndex = -1;
                    }
                    else
                    {
                        ViewModel.mskBirthdate.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.mskBirthdate.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtPatientAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtPatientAge.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboPatientAgeUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboPatientAgeUnits.ForeColor = IncidentMain.Shared.EMSFONT;
                        EditBirthdate();
                        ViewModel.FirstTime = -1;
                    }
                    break;
            }
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.EXAMONLY:
                case IncidentMain.EXAMASSIST:
                case IncidentMain.EXAMTRANSPORT:
                    if (ViewModel.cboMechCode.SelectedIndex == -1)
                    {
                        ViewModel.cboMechCode.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboMechCode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboMechCode.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboMechCode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboMechCode.ForeColor = IncidentMain.Shared.EMSFONT;
                        switch (ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex))
                        {
                            case 1: //No Mech Code 

                                ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
                                break;
                            case 3:
                            case 4:
                            case 7:
                            case 12:
                            case 13:
                            case 19:
                            case 22:
                            case 23:
                            case 24:
                            case 27:
                            case 29:  //Medical 
                                if (ViewModel.cboPrimaryIllness.SelectedIndex == -1)
                                {
                                    ViewModel.cboPrimaryIllness.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboPrimaryIllness.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboPrimaryIllness.Text = "";
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
                                    ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
                                    ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
                                }

                                break;
                            default: //Injury 
                                if (ViewModel.cboInjuryType.SelectedIndex == -1)
                                {
                                    ViewModel.cboInjuryType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboInjuryType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboInjuryType.Text = "";
                                    ViewModel.cboBodyPart.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
                                    ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
                                    if (ViewModel.cboBodyPart.SelectedIndex == -1)
                                    {
                                        ViewModel.cboBodyPart.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboBodyPart.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboBodyPart.Text = "";
                                        result = 0;
                                    }
                                    else
                                    {
                                        ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
                                    }
                                }
                                break;
                        }
                    }
                    OptCheck = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (ViewModel.optPupils[i].Checked)
                        {
                            OptCheck = -1;
                            for (int x = 0; x <= 1; x++)
                            {
                                ViewModel.optPupils[x].BackColor = IncidentMain.Shared.EMSCOLOR;
                                ViewModel.optPupils[x].ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                            break;
                        }
                    }
                    if (~OptCheck != 0)
                    {
                        result = 0;
                        for (int i = 0; i <= 1; i++)
                        {
                            ViewModel.optPupils[i].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.optPupils[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        }
                    }
                    OptCheck = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (ViewModel.optLevelOfConsciouness[i].Checked)
                        {
                            OptCheck = -1;
                            for (int x = 0; x <= 2; x++)
                            {
                                ViewModel.optLevelOfConsciouness[x].BackColor = IncidentMain.Shared.EMSCOLOR;
                                ViewModel.optLevelOfConsciouness[x].ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                            break;
                        }
                    }
                    if (~OptCheck != 0)
                    {
                        result = 0;
                        for (int i = 0; i <= 2; i++)
                        {
                            ViewModel.optLevelOfConsciouness[i].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.optLevelOfConsciouness[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        }
                    }
                    OptCheck = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (ViewModel.optRespiratoryEffort[i].Checked)
                        {
                            OptCheck = -1;
                            for (int x = 0; x <= 2; x++)
                            {
                                ViewModel.optRespiratoryEffort[x].BackColor = IncidentMain.Shared.EMSCOLOR;
                                ViewModel.optRespiratoryEffort[x].ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                            break;
                        }
                    }
                    if (~OptCheck != 0)
                    {
                        result = 0;
                        for (int i = 0; i <= 2; i++)
                        {
                            ViewModel.optRespiratoryEffort[i].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.optRespiratoryEffort[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        }
                    }
                    if (~ViewModel.NoVitals != 0)
                    {
                        if (ViewModel.txtTime[0].Text == "__:__")
                        {
                            ViewModel.txtTime[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtTime[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtTime[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtTime[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        double dbNumericTemp4 = 0;
                        if (ViewModel.txtPulse[0].Text == "")
                        {
                            ViewModel.txtPulse[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtPulse[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPulse[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
                        {
                            ViewModel.txtPulse[0].Text = "";
                            ViewModel.txtPulse[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtPulse[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtPulse[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtPulse[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        double dbNumericTemp5 = 0;
                        if (ViewModel.txtRespiration[0].Text == "")
                        {
                            ViewModel.txtRespiration[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtRespiration[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
                        {
                            ViewModel.txtRespiration[0].Text = "";
                            ViewModel.txtRespiration[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtRespiration[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtRespiration[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtRespiration[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        double dbNumericTemp6 = 0;
                        if (ViewModel.txtSystolic[0].Text == "")
                        {
                            ViewModel.txtSystolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtSystolic[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6))
                        {
                            ViewModel.txtSystolic[0].Text = "";
                            ViewModel.txtSystolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtSystolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtSystolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtSystolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.txtDiastolic[0].Text == "")
                        {
                            if (((int)ViewModel.chkPalp[0].CheckState) == ((int)UpgradeHelpers.Helpers.CheckState.Unchecked))
                            {
                                ViewModel.txtDiastolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.chkPalp[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.txtDiastolic[0].Text = "";
                                ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                                ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                        }
                        else
                        {
                            double dbNumericTemp7 = 0;
                            if (!Double.TryParse(ViewModel.txtDiastolic[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7))
                            {
                                ViewModel.txtDiastolic[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtDiastolic[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtDiastolic[0].Text = "";
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                                ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.chkPalp[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                            }
                        }
                        double dbNumericTemp8 = 0;
                        if (!Double.TryParse(ViewModel.txtGlucose[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8))
                        {
                            ViewModel.txtGlucose[0].Text = "";
                        }
                        double dbNumericTemp9 = 0;
                        if (!Double.TryParse(ViewModel.txtPulseOxy[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp9))
                        {
                            ViewModel.txtPulseOxy[0].Text = "";
                        }
                        else
                        {
                            if (ViewModel.txtPulseOxy[0].Text != "")
                            {
                                double dbNumericTemp10 = 0;
                                if (ViewModel.txtPerOxy[0].Text == "")
                                {
                                    ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                                }
                                else if (!Double.TryParse(ViewModel.txtPerOxy[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp10))
                                {
                                    ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPerOxy[0].Text = "";
                                    result = 0;
                                }
                                else if (Conversion.Val(ViewModel.txtPerOxy[0].Text) > 100)
                                {
                                    ViewModel.txtPerOxy[0].BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPerOxy[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPerOxy[0].Text = "";
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtPerOxy[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPerOxy[0].ForeColor = IncidentMain.Shared.EMSFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtPerOxy[0].Text = "";
                            }
                        }
                        double dbNumericTemp11 = 0;
                        if (!Double.TryParse(ViewModel.txtPerOxy[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp11))
                        {
                            ViewModel.txtPerOxy[0].Text = "";
                        }
                        else if (Conversion.Val(ViewModel.txtPerOxy[0].Text) > 100)
                        {
                            ViewModel.txtPerOxy[0].Text = "";
                        }
                        //Validate Additional Vitals
                        for (int i = 1; i <= 4; i++)
                        {
                            double dbNumericTemp12 = 0;
                            if (!Double.TryParse(ViewModel.txtPulse[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp12))
                            {
                                ViewModel.txtPulse[i].Text = "";
                            }
                            double dbNumericTemp13 = 0;
                            if (!Double.TryParse(ViewModel.txtRespiration[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp13))
                            {
                                ViewModel.txtRespiration[i].Text = "";
                            }
                            double dbNumericTemp14 = 0;
                            if (!Double.TryParse(ViewModel.txtSystolic[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp14))
                            {
                                ViewModel.txtSystolic[i].Text = "";
                            }
                            double dbNumericTemp15 = 0;
                            if (!Double.TryParse(ViewModel.txtDiastolic[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp15))
                            {
                                ViewModel.txtDiastolic[i].Text = "";
                            }
                            double dbNumericTemp16 = 0;
                            if (!Double.TryParse(ViewModel.txtGlucose[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp16))
                            {
                                ViewModel.txtGlucose[i].Text = "";
                            }
                            double dbNumericTemp17 = 0;
                            if (!Double.TryParse(ViewModel.txtPulseOxy[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp17))
                            {
                                ViewModel.txtPulseOxy[i].Text = "";
                            }
                            else
                            {
                                if (ViewModel.txtPulseOxy[i].Text != "")
                                {
                                    double dbNumericTemp18 = 0;
                                    if (ViewModel.txtPerOxy[i].Text == "")
                                    {
                                        ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        result = 0;
                                    }
                                    else if (!Double.TryParse(ViewModel.txtPerOxy[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp18))
                                    {
                                        ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtPerOxy[i].Text = "";
                                        result = 0;
                                    }
                                    else if (Conversion.Val(ViewModel.txtPerOxy[i].Text) > 100)
                                    {
                                        ViewModel.txtPerOxy[i].BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtPerOxy[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtPerOxy[i].Text = "";
                                        result = 0;
                                    }
                                    else
                                    {
                                        ViewModel.txtPerOxy[i].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtPerOxy[i].ForeColor = IncidentMain.Shared.EMSFONT;
                                    }
                                }
                                else
                                {
                                    ViewModel.txtPerOxy[i].Text = "";
                                }
                            }
                            double dbNumericTemp19 = 0;
                            if (!Double.TryParse(ViewModel.txtPerOxy[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp19))
                            {
                                ViewModel.txtPerOxy[i].Text = "";
                            }
                            else if (Conversion.Val(ViewModel.txtPerOxy[i].Text) > 100)
                            {
                                ViewModel.txtPerOxy[i].Text = "";
                            }
                        }
                        if (ViewModel.cboVitalsPosition[0].SelectedIndex == -1)
                        {
                            ViewModel.cboVitalsPosition[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboVitalsPosition[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboVitalsPosition[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboVitalsPosition[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboEyes[0].SelectedIndex == -1)
                        {
                            ViewModel.cboEyes[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboEyes[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboEyes[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboEyes[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboEyes[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboVerbal[0].SelectedIndex == -1)
                        {
                            ViewModel.cboVerbal[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboVerbal[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboVerbal[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboVerbal[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboVerbal[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboMotor[0].SelectedIndex == -1)
                        {
                            ViewModel.cboMotor[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboMotor[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboMotor[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboMotor[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboMotor[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                    }
                    else
                    {
                        ViewModel.txtTime[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtTime[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtPulse[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtPulse[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtRespiration[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtRespiration[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtSystolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtSystolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtDiastolic[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtDiastolic[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.chkPalp[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.chkPalp[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.chkPalp[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.cboVitalsPosition[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboVitalsPosition[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboEyes[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboEyes[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboVerbal[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboVerbal[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboMotor[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboMotor[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        if (ViewModel.rtxNarration.Text == "")
                        {
                            ViewModel.rtxNarration.BackColor = IncidentMain.Shared.REQCOLOR;
                            result = 0;
                        }
                        else
                        {
                            ViewModel.rtxNarration.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        }
                    }
                    if (!ViewModel.optSeverity[0].Checked && !ViewModel.optSeverity[1].Checked && !ViewModel.optSeverity[2].Checked)
                    {
                        //frmSeverity.BackColor = REQCOLOR
                        ViewModel.frmSeverity.Font = ViewModel.frmSeverity.Font.Change(name: IncidentMain.WHITE.ToString());
                        ViewModel.optSeverity[0].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optSeverity[1].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optSeverity[2].BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.optSeverity[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.optSeverity[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.optSeverity[2].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    }
                    else
                    {
                        ViewModel.optSeverity[0].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optSeverity[1].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optSeverity[2].BackColor = IncidentMain.Shared.EMSCOLOR;
                        ViewModel.optSeverity[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.optSeverity[1].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.optSeverity[2].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.TraumaSwitch != 0)
                    {
                        double dbNumericTemp20 = 0;
                        if (ViewModel.txtTraumaID.Text == "")
                        {
                            ViewModel.txtTraumaID.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtTraumaID.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp20))
                        {
                            ViewModel.txtTraumaID.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtTraumaID.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtTraumaID.Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtTraumaID.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtTraumaID.ForeColor = IncidentMain.Shared.EMSFONT;
                            if (Strings.Len(ViewModel.txtTraumaID.Text) > 7)
                            {
                                ViewModel.txtTraumaID.Text = ViewModel.txtTraumaID.Text.Substring(0, Math.Min(7, ViewModel.txtTraumaID.Text.Length));
                            }
                        }
                        if (ViewModel.cboProtectiveDevice.SelectedIndex == -1)
                        {
                            ViewModel.cboProtectiveDevice.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboProtectiveDevice.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboProtectiveDevice.Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboProtectiveDevice.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboProtectiveDevice.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboPatientLocation.SelectedIndex == -1)
                        {
                            ViewModel.cboPatientLocation.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboPatientLocation.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientLocation.Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboPatientLocation.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboPatientLocation.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        //Trauma steps
                        OptCheck = 0;
                        for (int i = 0; i <= ViewModel.lstTrauma1.Items.Count - 1; i++)
                        {
                            // not showing it selected!  why?
                            if (ViewModel.lstTrauma1.GetSelected(i))
                            {
                                OptCheck = -1;
                                break;
                            }
                        }
                        if (~OptCheck != 0)
                        {
                            for (int i = 0; i <= ViewModel.lstTrauma2.Items.Count - 1; i++)
                            {
                                if (ViewModel.lstTrauma2.GetSelected(i))
                                {
                                    OptCheck = -1;
                                    break;
                                }
                            }
                        }
                        if (~OptCheck != 0)
                        {
                            for (int i = 0; i <= ViewModel.lstTrauma3.Items.Count - 1; i++)
                            {
                                if (ViewModel.lstTrauma3.GetSelected(i))
                                {
                                    OptCheck = -1;
                                    break;
                                }
                            }
                        }
                        if (~OptCheck != 0)
                        {
                            ViewModel.lstTrauma1.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.lstTrauma1.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.lstTrauma2.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.lstTrauma2.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.lstTrauma3.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.lstTrauma3.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.lstTrauma1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.lstTrauma1.ForeColor = IncidentMain.Shared.EMSFONT;
                            ViewModel.lstTrauma2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.lstTrauma2.ForeColor = IncidentMain.Shared.EMSFONT;
                            ViewModel.lstTrauma3.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.lstTrauma3.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                    }
                    break;
            }
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.EXAMASSIST:
                case IncidentMain.EXAMTRANSPORT:
                    //            If lbProcs(1).Visible = True Then 
                    //                If txtOtherBLSProcedures.Text = "" Then 
                    //                    txtOtherBLSProcedures.BackColor = REQCOLOR 
                    //                    txtOtherBLSProcedures.ForeColor = WHITE 
                    //                    CheckComplete = False 
                    //                Else 
                    //                    txtOtherBLSProcedures.BackColor = WHITE 
                    //                    txtOtherBLSProcedures.ForeColor = EMSFONT 
                    //                End If 
                    //            End If 
                    if (ViewModel.cboTreatmentAuth.SelectedIndex == -1)
                    {
                        ViewModel.cboTreatmentAuth.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboTreatmentAuth.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboTreatmentAuth.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboTreatmentAuth.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboTreatmentAuth.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.ExtricationPerformed != 0)
                    {
                        double dbNumericTemp21 = 0;
                        if (ViewModel.txtExtricationTime.Text == "")
                        {
                            ViewModel.txtExtricationTime.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtExtricationTime.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp21))
                        {
                            ViewModel.txtExtricationTime.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtExtricationTime.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtExtricationTime.Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtExtricationTime.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                    }
                    else
                    {
                        ViewModel.txtExtricationTime.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtExtricationTime.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboALSProcedures.SelectedIndex != -1)
                    {
                        switch (ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
                        {
                            case 12:
                            case 14:
                            case 15:
                            case 16:
                            case 26:
                            case 27:  //IV or Intub 
                                double dbNumericTemp22 = 0;
                                if (ViewModel.txtAttempts.Text == "")
                                {
                                    ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                                }
                                else if (!Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp22))
                                {
                                    ViewModel.txtAttempts.Text = "";
                                    ViewModel.txtAttempts.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtAttempts.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtAttempts.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtAttempts.ForeColor = IncidentMain.Shared.EMSFONT;
                                }
                                break;
                        }
                    }
                    else
                    {
                        ViewModel.txtAttempts.Text = "";
                        ViewModel.txtAttempts.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtAttempts.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    }

                    if (ViewModel.IVPerformed != 0)
                    {
                        if (ViewModel.cboGauge[0].SelectedIndex == -1)
                        {
                            ViewModel.cboGauge[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboGauge[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboGauge[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboGauge[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboGauge[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboRoute[0].SelectedIndex == -1)
                        {
                            ViewModel.cboRoute[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboRoute[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboRoute[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboRoute[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboRoute[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        if (ViewModel.cboRate[0].SelectedIndex == -1)
                        {
                            ViewModel.cboRate[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboRate[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboRate[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboRate[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboRate[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        double dbNumericTemp23 = 0;
                        if (ViewModel.txtAmount[0].Text == "")
                        {
                            ViewModel.txtAmount[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtAmount[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtAmount[0].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp23))
                        {
                            ViewModel.txtAmount[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtAmount[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtAmount[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtAmount[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtAmount[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        for (int i = 1; i <= 4; i++)
                        {
                            if (ViewModel.txtAmount[i].Text != "")
                            {
                                double dbNumericTemp24 = 0;
                                if (!Double.TryParse(ViewModel.txtAmount[i].Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp24))
                                {
                                    ViewModel.txtAmount[i].Text = "";
                                }
                            }
                        }
                        if (ViewModel.cboSite[0].SelectedIndex == -1)
                        {
                            ViewModel.cboSite[0].BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboSite[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboSite[0].Text = "";
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboSite[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboSite[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                    }
                    else
                    {
                        ViewModel.cboGauge[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboGauge[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboRoute[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboRoute[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboRate[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboRate[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.txtAmount[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtAmount[0].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboSite[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboSite[0].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboMedications.SelectedIndex != -1)
                    {
                        double dbNumericTemp25 = 0;
                        if (ViewModel.txtDosage.Text == "")
                        {
                            ViewModel.txtDosage.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtDosage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp25))
                        {
                            ViewModel.txtDosage.Text = "";
                            ViewModel.txtDosage.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.txtDosage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.txtDosage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.txtDosage.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                    }
                    else
                    {
                        ViewModel.txtDosage.Text = "";
                        ViewModel.txtDosage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.txtDosage.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.CPRSwitch != 0)
                    {
                        if (~EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
                        {
                            ViewModel.cboCPRPerformedBy.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboCPRPerformedBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            result = 0;
                        }
                        else
                        {
                            ViewModel.cboCPRPerformedBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboCPRPerformedBy.ForeColor = IncidentMain.Shared.EMSFONT;
                        }
                        //CPR option buttons
                        //button 1
                        OptCheck = 0;
                        for (int i = 0; i <= 3; i++)
                        {
                            if (ViewModel.optArrestToCPR[i].Checked)
                            {
                                for (int x = 0; x <= 3; x++)
                                {
                                    ViewModel.optArrestToCPR[x].BackColor = IncidentMain.Shared.EMSCOLOR;
                                    ViewModel.optArrestToCPR[x].ForeColor = IncidentMain.Shared.EMSFONT;
                                    OptCheck = -1;
                                }
                                break;
                            }
                        }
                        //if none are checked then...
                        if (~OptCheck != 0)
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                ViewModel.optArrestToCPR[i].BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.optArrestToCPR[i].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            }
                            result = 0;
                        }
                        OptCheck = 0;
                    }

                    //if base station contact, optMDorRN is required 
                    break;
            }
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.EXAMTRANSPORT:
                case IncidentMain.INTERFAC:
                    if (ViewModel.cboTransportTo.SelectedIndex == -1)
                    {
                        ViewModel.cboTransportTo.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboTransportTo.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboTransportTo.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboTransportTo.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboTransportTo.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    if (ViewModel.cboTransportBy.Enabled)
                    {
                        ViewModel.txtMileage.Enabled = true;
                        ViewModel.chkDiverted.Enabled = true;
                        ViewModel.lbTrans[4].ForeColor = IncidentMain.Shared.EMSFONT;
                        if (ViewModel.cboTransportBy.SelectedIndex == -1)
                        {
                            ViewModel.cboTransportBy.BackColor = IncidentMain.Shared.REQCOLOR;
                            ViewModel.cboTransportBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboTransportTo.Text = "";
                            result = 0;
                            double dbNumericTemp26 = 0;
                            if (ViewModel.txtMileage.Text == "")
                            {
                                ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            }
                            else if (ViewModel.txtMileage.Text == ".")
                            {
                                ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                            else if (!Double.TryParse(ViewModel.txtMileage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp26))
                            {
                                ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.Text = "";
                            }
                            else
                            {
                                ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                        }
                        else
                        {
                            ViewModel.cboTransportBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                            ViewModel.cboTransportBy.ForeColor = IncidentMain.Shared.EMSFONT;
                            //*** Check for TFD Unit
                            UnitCheck = ViewModel.cboTransportBy.Text;
                            UnitCheck = UnitCL.GetTFDUnit(UnitCheck);
                            double dbNumericTemp27 = 0;
                            if (UnitCheck == "")
                            {
                                ViewModel.txtMileage.Text = "";
                                ViewModel.txtMileage.Enabled = false;
                                ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
                                ViewModel.lbTrans[4].ForeColor = IncidentMain.Shared.DKGRAY;
                                ViewModel.chkDiverted.Enabled = false;
                            }
                            else if (ViewModel.txtMileage.Text == "")
                            {
                                ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                            }
                            else if (ViewModel.txtMileage.Text == ".")
                            {
                                ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                            else if (!Double.TryParse(ViewModel.txtMileage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp27))
                            {
                                ViewModel.txtMileage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMileage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.Text = "";
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtMileage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMileage.ForeColor = IncidentMain.Shared.EMSFONT;
                            }
                        }
                    }
                    else
                    {
                        ViewModel.txtMileage.Text = "";
                        ViewModel.txtMileage.Enabled = false;
                        ViewModel.chkDiverted.Enabled = false;
                        ViewModel.lbTrans[4].BackColor = IncidentMain.Shared.DKGRAY;
                    }
                    if (ViewModel.cboHospitalChosenBy.SelectedIndex == -1)
                    {
                        ViewModel.cboHospitalChosenBy.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboHospitalChosenBy.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboHospitalChosenBy.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboHospitalChosenBy.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboHospitalChosenBy.ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    break;
            }
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.INTERFAC:
                    if (ViewModel.cboTransportFrom.SelectedIndex == -1)
                    {
                        ViewModel.cboTransportFrom.BackColor = IncidentMain.Shared.REQCOLOR;
                        ViewModel.cboTransportFrom.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.cboTransportFrom.Text = "";
                        result = 0;
                    }
                    else
                    {
                        ViewModel.cboTransportFrom.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                        ViewModel.cboTransportFrom.ForeColor = IncidentMain.Shared.EMSFONT;
                        ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    break;
                default:
                    ViewModel.cboTransportFrom.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboTransportFrom.ForeColor = IncidentMain.Shared.EMSFONT;
                    ViewModel.cboTransportFrom.SelectedIndex = -1;
                    ViewModel.cboTransportFrom.Enabled = false;
                    ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.DKGRAY;

                    break;
            }
            ViewModel.FirstTime = 0;

            return result;
        }

        private void FormatFrame()
        {
            
            //If Multiple Use Frame Then Format Controls
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();

            switch (ViewModel.CurrFrame.Name)
            {
                //Enable SAVE buttons
                case "frmReportStatus":
                    ViewModel.cmdSave.Enabled = CheckComplete() != 0;
                    LoadReportStatus();
                    IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = false;
                    ViewModel.NavButton[3].Visible = true;
                    ViewModel.NavButton[4].Visible = false;

                    // Enable Navigation buttons 
                    break;
                case "frmActionTaken":
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = false;
                    if (ViewModel.ReportSaved != 0)
                    {
                        ViewModel.NavButton[2].Visible = true;
                    }
                    else
                    {
                        ViewModel.NavButton[2].Visible = false;
                    }
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = false;
                    //Test for allowing transport selection 
                    ViewModel.optActionTaken[2].Enabled = UnitCL.GetIncidentTransportResponses(ViewModel.CurrIncident) != 0;
                    break;
                default:
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.NavButton[3].Visible = true;
                    ViewModel.NavButton[4].Visible = false;
                    break;
            }

            //Set starting cursor position
            switch (ViewModel.CurrFrame.Name)
            {
                case "frmNoExamInfo":
                    ViewManager.SetCurrent(ViewModel.txtBFirstName);
                    break;
                case "frmPatientInformation":
                    ViewManager.SetCurrent(ViewModel.txtFirstName);
                    break;
                case "frmExamInfo":
                    //ViewManager.SetCurrent(ViewModel.cboMechCode);
                    break;
                case "frmProceduresPerformed":
                    ViewManager.SetCurrent(ViewModel.cboBLSProcedures);
                    break;
                case "frmTreatmentInfo":
                    ViewManager.SetCurrent(ViewModel.cboTreatmentAuth);
                    break;
                case "frmTransportInfo":
                    ViewManager.SetCurrent(ViewModel.cboTransportBy);
                    break;
                case "frmTrauma":
                    ViewManager.SetCurrent(ViewModel.txtTraumaID);
                    break;
                case "frmCPR":
                    ViewManager.SetCurrent(ViewModel.cboCPRPerformedBy);
                    break;
                case "frmNarration":
                    if (ViewModel.NarrationRequired != 0)
                    {
                        ViewModel.lbNarr[3].Text = ViewModel.ReqNarrString;
                        ViewModel.lbNarr[3].ForeColor = IncidentMain.Shared.RED;
                    }
                    else
                    {
                        ViewModel.lbNarr[3].Text = "Narrative";
                        ViewModel.lbNarr[3].ForeColor = IncidentMain.Shared.EMSFONT;
                    }
                    ViewManager.SetCurrent(ViewModel.cboIncidentLocation);
                    break;
                case "frmReportStatus":
                    if (ViewModel.cmdSave.Enabled)
                    {
                        ViewManager.SetCurrent(ViewModel.cmdSave);
                    }
                    else
                    {
                        ViewManager.SetCurrent(ViewModel.cmdSaveIncomplete);
                    }
                    break;
            }
            //Display Current Frame
            ViewModel.CurrFrame.Visible = true;

        }

        private void LoadLists()
        {
            //Load all appropriate combo and listboxes for
            //Current Report Type
            //Stored Procedures may bring back multiple resultsets
            TFDIncident.clsEMSCodes EMSCodes = Container.Resolve<clsEMSCodes>();
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();
            TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

            if (ViewModel.ListsLoaded != 0)
            {
                return;
            }

            //CLEAR FIELDS
            ViewModel.FirstTime = -1;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            ViewModel.TraumaSwitch = 0;
            ViewModel.CPRSwitch = 0;
            ViewModel.ExtricationPerformed = 0;

            //No Exam
            ViewModel.txtBFirstName.Text = "";
            ViewModel.txtBLastName.Text = "";
            ViewModel.txtBMI.Text = "";
            ViewModel.txtBHomePhone.Text = "";
            ViewModel.txtBBirthdate.Text = "__/__/____";
            ViewModel.txtAge.Text = "";
            ViewModel.cboAgeUnits.Items.Clear();
            ViewModel.cboEMSRace.Items.Clear();
            ViewModel.cboServiceProvided.Items.Clear();
            //Patient Information
            ViewModel.txtFirstName.Text = "";
            ViewModel.txtLastName.Text = "";
            ViewModel.txtMI.Text = "";
            ViewModel.mskSSN.Text = "___-__-____";
            ViewModel.txtBillingAddress.Text = "";
            ViewModel.cboState.Items.Clear();
            ViewModel.txtCity.Text = "";
            ViewModel.txtZipCode.Text = "";
            ViewModel.txtHomePhone.Text = "";
            ViewModel.mskBirthdate.Text = "__/__/____";
            ViewModel.txtPatientAge.Text = "";
            ViewModel.cboPatientAgeUnits.Items.Clear();
            ViewModel.cboRace.Items.Clear();
            ViewModel.lstPriorMedicalHistory.Items.Clear();
            ViewModel.lstPossibleFactors.Items.Clear();
            //Exam Information
            ViewModel.cboMechCode.Items.Clear();
            ViewModel.cboInjuryType.Items.Clear();
            ViewModel.cboBodyPart.Items.Clear();
            ViewModel.cboPrimaryIllness.Items.Clear();
            ViewModel.lstSecondaryIllness.Items.Clear();
            ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            for (int i = 0; i <= 4; i++)
            {
                ViewModel.chkPalp[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.txtTime[i].Text = "__:__";
                ViewModel.txtPulse[i].Text = "";
                ViewModel.txtRespiration[i].Text = "";
                ViewModel.txtSystolic[i].Text = "";
                ViewModel.txtDiastolic[i].Text = "";
                ViewModel.txtGlucose[i].Text = "";
                ViewModel.txtPulseOxy[i].Text = "";
                ViewModel.cboECG[i].Items.Clear();
                ViewModel.cboEyes[i].Items.Clear();
                ViewModel.cboVerbal[i].Items.Clear();
                ViewModel.cboMotor[i].Items.Clear();
                ViewModel.cboVitalsPosition[i].Items.Clear();
            }
            //Procedures Performed
            ViewModel.lstBLSPersonnel.Items.Clear();
            ViewModel.cboBLSProcedures.Items.Clear();
            ViewModel.cboALSPersonnel.Items.Clear();
            ViewModel.cboALSProcedures.Items.Clear();
            ViewModel.lstBLSProcedures.Items.Clear();
            ViewModel.lstALSProcedures.Items.Clear();
            ViewModel.txtOtherBLSProcedures.Text = "";
            ViewModel.txtOtherALSProcedures.Text = "";
            ViewModel.txtAttempts.Text = "";
            //Treatment Information
            ViewModel.cboTreatmentAuth.Items.Clear();
            ViewModel.txtExtricationTime.Text = "";
            ViewModel.chkSalineLock.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            for (int i = 0; i <= 4; i++)
            {
                ViewModel.cboGauge[i].Items.Clear();
            }
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.cboRoute[i].Items.Clear();
            }
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.cboRate[i].Items.Clear();
            }
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.cboSite[i].Items.Clear();
            }
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.txtAmount[i].Text = "";
            }
            ViewModel.cboMedications.Items.Clear();
            ViewModel.txtDosage.Text = "";
            ViewModel.lstMedications.Items.Clear();
            //Transport Information
            ViewModel.txtMileage.Text = "";
            ViewModel.cboTransportTo.Items.Clear();
            ViewModel.cboTransportFrom.Items.Clear();
            ViewModel.cboTransportBy.Items.Clear();
            ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.EMSFONT;
            ViewModel.cboHospitalChosenBy.Items.Clear();
            ViewModel.cboBaseStationContact.Items.Clear();
            for (int i = 0; i <= 2; i++)
            {
                ViewModel.optMDorRN[i].Checked = false;
            }
            ViewModel.chkDiverted.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            //CPR information
            ViewModel.cboCPRPerformedBy.Items.Clear();
            ViewModel.lstCPRPerformedBy.Items.Clear();
            ViewModel.chkCPRTrained.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.chkWitnessedArrest.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.optArrestToCPR[i].Checked = false;
                ViewModel.optArrestToALS[i].Checked = false;
                ViewModel.optArrestToShock[i].Checked = false;
            }
            ViewModel.chkPulseRestored.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            //Trauma Information
            ViewModel.txtTraumaID.Text = "";
            ViewModel.cboProtectiveDevice.Items.Clear();
            ViewModel.cboPatientLocation.Items.Clear();
            ViewModel.lstTrauma1.Items.Clear();
            ViewModel.lstTrauma2.Items.Clear();
            ViewModel.lstTrauma3.Items.Clear();
            //Narration
            ViewModel.cboIncidentLocation.Items.Clear();
            ViewModel.cboIncidentSetting.Items.Clear();
            ViewModel.cboResearchCode.Items.Clear();
            ViewModel.rtxNarration.Text = "";

            //LOAD LIST BOXES, etc.
            //No Exam Info

            CommonCodes.GetAgeUnit();

            while (!CommonCodes.AgeUnit.EOF)
            {
                ViewModel.cboAgeUnits.AddItem(IncidentMain.Clean(CommonCodes.AgeUnit["description"]));
                ViewModel.cboAgeUnits.SetItemData(ViewModel.cboAgeUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AgeUnit["age_unit_code"]));
                CommonCodes.AgeUnit.MoveNext();
            }
            ;
            CommonCodes.GetStateCode();

            while (!CommonCodes.StateRS.EOF)
            {
                ViewModel.cboState.AddItem(Convert.ToString(CommonCodes.StateRS["state_code"]));
                CommonCodes.StateRS.MoveNext();
            }
            ;
            for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
            {
                if (ViewModel.cboState.GetListItem(i) == "WA")
                {
                    ViewModel.cboState.SelectedIndex = i;
                    break;
                }
            }

            EMSCodes.GetServiceProvidedCodes();

            while (!EMSCodes.ServiceProvidedCodes.EOF)
            {
                ViewModel.cboServiceProvided.AddItem(IncidentMain.Clean(EMSCodes.ServiceProvidedCodes["description"]));
                ViewModel.cboServiceProvided.SetItemData(ViewModel.cboServiceProvided.GetNewIndex(), Convert.ToInt32(EMSCodes.ServiceProvidedCodes["service_provided_code"]));
                EMSCodes.ServiceProvidedCodes.MoveNext();
            }
            ;
            //Patient Information
            CommonCodes.GetAgeUnit();

            while (!CommonCodes.AgeUnit.EOF)
            {
                ViewModel.cboPatientAgeUnits.AddItem(IncidentMain.Clean(CommonCodes.AgeUnit["description"]));
                ViewModel.cboPatientAgeUnits.SetItemData(ViewModel.cboPatientAgeUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AgeUnit["age_unit_code"]));
                CommonCodes.AgeUnit.MoveNext();
            }
            ;
            CommonCodes.GetPeopleDescriptor("R");

            while (!CommonCodes.PeopleDescriptor.EOF)
            {
                //Patient Information
                ViewModel.cboRace.AddItem(IncidentMain.Clean(CommonCodes.PeopleDescriptor["description"]));
                ViewModel.cboRace.SetItemData(ViewModel.cboRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
                //Ems Basic Incident
                ViewModel.cboEMSRace.AddItem(IncidentMain.Clean(CommonCodes.PeopleDescriptor["description"]));
                ViewModel.cboEMSRace.SetItemData(ViewModel.cboEMSRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
                CommonCodes.PeopleDescriptor.MoveNext();
            }
            ;
            EMSCodes.GetPreExistingConditionCodes();

            while (!EMSCodes.PreExistingConditionCodes.EOF)
            {
                ViewModel.lstPriorMedicalHistory.AddItem(IncidentMain.Clean(EMSCodes.PreExistingConditionCodes["description"]));
                ViewModel.lstPriorMedicalHistory.SetItemData(ViewModel.lstPriorMedicalHistory.GetNewIndex(), Convert.ToInt32(EMSCodes.PreExistingConditionCodes["pre_existing_condition_code"]));
                EMSCodes.PreExistingConditionCodes.MoveNext();
            }
            ;
            EMSCodes.GetContributingFactorCodes();

            while (!EMSCodes.EMSContributingFactorCodes.EOF)
            {
                ViewModel.lstPossibleFactors.AddItem(IncidentMain.Clean(EMSCodes.EMSContributingFactorCodes["description"]));
                ViewModel.lstPossibleFactors.SetItemData(ViewModel.lstPossibleFactors.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSContributingFactorCodes["ems_contributing_factor_code"]));
                EMSCodes.EMSContributingFactorCodes.MoveNext();
            }
            ;

            //Patient Exam
            EMSCodes.GetMechCodes();

            while (!EMSCodes.MechCodes.EOF)
            {
                ViewModel.cboMechCode.AddItem(IncidentMain.Clean(EMSCodes.MechCodes["description"]));
                ViewModel.cboMechCode.SetItemData(ViewModel.cboMechCode.GetNewIndex(), Convert.ToInt32(EMSCodes.MechCodes["Mech_code"]));
                EMSCodes.MechCodes.MoveNext();
            }
            ;
            //Fill Injury Type
            EMSCodes.GetInjuryDetailCodesByType("I");

            while (!EMSCodes.InjuryDetailCodes.EOF)
            {
                ViewModel.cboInjuryType.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
                ViewModel.cboInjuryType.SetItemData(ViewModel.cboInjuryType.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
                EMSCodes.InjuryDetailCodes.MoveNext();
            }
            ;
            //Fill Body part
            EMSCodes.GetInjuryDetailCodesByType("B");

            while (!EMSCodes.InjuryDetailCodes.EOF)
            {
                ViewModel.cboBodyPart.AddItem(IncidentMain.Clean(EMSCodes.InjuryDetailCodes["description"]));
                ViewModel.cboBodyPart.SetItemData(ViewModel.cboBodyPart.GetNewIndex(), Convert.ToInt32(EMSCodes.InjuryDetailCodes["injury_detail_descriptor"]));
                EMSCodes.InjuryDetailCodes.MoveNext();
            }
            ;
            EMSCodes.GetIllnessTypeCodes();

            while (!EMSCodes.IllnessTypeCodes.EOF)
            {
                ViewModel.cboPrimaryIllness.AddItem(IncidentMain.Clean(EMSCodes.IllnessTypeCodes["description"]));
                ViewModel.cboPrimaryIllness.SetItemData(ViewModel.cboPrimaryIllness.GetNewIndex(), Convert.ToInt32(EMSCodes.IllnessTypeCodes["illness_type_code"]));
                EMSCodes.IllnessTypeCodes.MoveNext();
            }
            ;
            EMSCodes.GetIllnessTypeCodes();

            while (!EMSCodes.IllnessTypeCodes.EOF)
            {
                ViewModel.lstSecondaryIllness.AddItem(IncidentMain.Clean(EMSCodes.IllnessTypeCodes["description"]));
                ViewModel.lstSecondaryIllness.SetItemData(ViewModel.lstSecondaryIllness.GetNewIndex(), Convert.ToInt32(EMSCodes.IllnessTypeCodes["illness_type_code"]));
                EMSCodes.IllnessTypeCodes.MoveNext();
            }
            ;
            EMSCodes.GetECGCodes();

            while (!EMSCodes.EMS_ECGCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboECG[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_ECGCodes["description"]));
                    ViewModel.cboECG[i].SetItemData(ViewModel.cboECG[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_ECGCodes["ecg_code"]));
                }
                EMSCodes.EMS_ECGCodes.MoveNext();
            }
            ;
            //vitals position here
            EMSCodes.GetExamCodesByType("V");

            while (!EMSCodes.ExamCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboVitalsPosition[i].AddItem(IncidentMain.Clean(EMSCodes.ExamCodes["description"]));
                    ViewModel.cboVitalsPosition[i].SetItemData(ViewModel.cboVitalsPosition[i].GetNewIndex(), Convert.ToInt32(EMSCodes.ExamCodes["exam_code"]));
                }
                EMSCodes.ExamCodes.MoveNext();
            }
            ;
            EMSCodes.GetGCSCodesByType("E");

            while (!EMSCodes.EMS_GCSCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboEyes[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
                    ViewModel.cboEyes[i].SetItemData(ViewModel.cboEyes[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
                }
                EMSCodes.EMS_GCSCodes.MoveNext();
            }
            ;
            EMSCodes.GetGCSCodesByType("V");

            while (!EMSCodes.EMS_GCSCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboVerbal[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
                    ViewModel.cboVerbal[i].SetItemData(ViewModel.cboVerbal[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
                }
                EMSCodes.EMS_GCSCodes.MoveNext();
            }
            ;
            EMSCodes.GetGCSCodesByType("M");

            while (!EMSCodes.EMS_GCSCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboMotor[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_GCSCodes["description"]));
                    ViewModel.cboMotor[i].SetItemData(ViewModel.cboMotor[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_GCSCodes["gcs_code"]));
                }
                EMSCodes.EMS_GCSCodes.MoveNext();
            }
            ;

            //Procedures performed
            EMSCodes.GetProcedureCodesByType("B");

            while (!EMSCodes.EMSProcedureCodes.EOF)
            {
                ViewModel.cboBLSProcedures.AddItem(IncidentMain.Clean(EMSCodes.EMSProcedureCodes["description"]));
                ViewModel.cboBLSProcedures.SetItemData(ViewModel.cboBLSProcedures.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSProcedureCodes["EMS_procedure_code"]));
                EMSCodes.EMSProcedureCodes.MoveNext();
            }
            ;
            EMSCodes.GetProcedureCodesByType("A");

            while (!EMSCodes.EMSProcedureCodes.EOF)
            {
                ViewModel.cboALSProcedures.AddItem(IncidentMain.Clean(EMSCodes.EMSProcedureCodes["description"]));
                ViewModel.cboALSProcedures.SetItemData(ViewModel.cboALSProcedures.GetNewIndex(), Convert.ToInt32(EMSCodes.EMSProcedureCodes["EMS_procedure_code"]));
                EMSCodes.EMSProcedureCodes.MoveNext();
            }
            ;
            if (EMSReport.GetEMSALSStaffing(ViewModel.CurrIncident) != 0)
            {

                while (!EMSReport.EMSIncidentStaffing.EOF)
                {
                    ViewModel.cboALSPersonnel.AddItem(IncidentMain.Clean(EMSReport.EMSIncidentStaffing["name_full"]) + ": " + Convert.ToString(EMSReport.EMSIncidentStaffing["emp_id"]));
                    EMSReport.EMSIncidentStaffing.MoveNext();
                };
            }
            else
            {
                //Disable ALS Procedures Controls
                ViewModel.frmALSProcedures.Visible = false;
            }
            if (EMSReport.GetEMSIncidentStaffing(ViewModel.CurrIncident) != 0)
            {

                while (!EMSReport.EMSIncidentStaffing.EOF)
                {
                    ViewModel.lstBLSPersonnel.AddItem(IncidentMain.Clean(EMSReport.EMSIncidentStaffing["name_full"]) + ": " + Convert.ToString(EMSReport.EMSIncidentStaffing["emp_id"]));
                    EMSReport.EMSIncidentStaffing.MoveNext();
                };
            }
            //CPR Information
            EMSCodes.GetPerformedByCodes();

            while (!EMSCodes.PerformedByCodes.EOF)
            {
                ViewModel.cboCPRPerformedBy.AddItem(IncidentMain.Clean(EMSCodes.PerformedByCodes["description"]));
                ViewModel.cboCPRPerformedBy.SetItemData(ViewModel.cboCPRPerformedBy.GetNewIndex(), Convert.ToInt32(EMSCodes.PerformedByCodes["performed_by_code"]));
                EMSCodes.PerformedByCodes.MoveNext();
            }
            ;
            //Treatment information
            EMSCodes.GetTreatmentAuthorizationCodes();

            while (!EMSCodes.TreatmentAuthorizationCodes.EOF)
            {
                ViewModel.cboTreatmentAuth.AddItem(IncidentMain.Clean(EMSCodes.TreatmentAuthorizationCodes["description"]));
                ViewModel.cboTreatmentAuth.SetItemData(ViewModel.cboTreatmentAuth.GetNewIndex(), Convert.ToInt32(EMSCodes.TreatmentAuthorizationCodes["treatment_authorization_code"]));
                EMSCodes.TreatmentAuthorizationCodes.MoveNext();
            }
            ;
            EMSCodes.GetMedicationCodes();

            while (!EMSCodes.MedicationCodes.EOF)
            {
                ViewModel.cboMedications.AddItem(IncidentMain.Clean(EMSCodes.MedicationCodes["description"]));
                ViewModel.cboMedications.SetItemData(ViewModel.cboMedications.GetNewIndex(), Convert.ToInt32(EMSCodes.MedicationCodes["medication_code"]));
                EMSCodes.MedicationCodes.MoveNext();
            }
            ;
            EMSCodes.GetIVCodesByType("G");

            while (!EMSCodes.EMS_IVCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboGauge[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
                    ViewModel.cboGauge[i].SetItemData(ViewModel.cboGauge[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
                }
                EMSCodes.EMS_IVCodes.MoveNext();
            }
            ;
            EMSCodes.GetIVCodesByType("R");

            while (!EMSCodes.EMS_IVCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboRoute[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
                    ViewModel.cboRoute[i].SetItemData(ViewModel.cboRoute[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
                }
                EMSCodes.EMS_IVCodes.MoveNext();
            }
            ;
            EMSCodes.GetIVCodesByType("T");

            while (!EMSCodes.EMS_IVCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboRate[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
                    ViewModel.cboRate[i].SetItemData(ViewModel.cboRate[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
                }
                EMSCodes.EMS_IVCodes.MoveNext();
            }
            ;
            EMSCodes.GetIVCodesByType("S");

            while (!EMSCodes.EMS_IVCodes.EOF)
            {
                for (int i = 0; i <= 3; i++)
                {
                    ViewModel.cboSite[i].AddItem(IncidentMain.Clean(EMSCodes.EMS_IVCodes["description"]));
                    ViewModel.cboSite[i].SetItemData(ViewModel.cboSite[i].GetNewIndex(), Convert.ToInt32(EMSCodes.EMS_IVCodes["iv_code"]));
                }
                EMSCodes.EMS_IVCodes.MoveNext();
            }
            ;

            //Transport information
            EMSCodes.GetHospitalChosenByCodes();

            while (!EMSCodes.HospitalChosenByCodes.EOF)
            {
                ViewModel.cboHospitalChosenBy.AddItem(IncidentMain.Clean(EMSCodes.HospitalChosenByCodes["description"]));
                ViewModel.cboHospitalChosenBy.SetItemData(ViewModel.cboHospitalChosenBy.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalChosenByCodes["hospital_chosen_by_code"]));
                EMSCodes.HospitalChosenByCodes.MoveNext();
            }
            ;
            EMSCodes.GetHospitalCodes();

            while (!EMSCodes.HospitalCodes.EOF)
            {
                ViewModel.cboBaseStationContact.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
                ViewModel.cboBaseStationContact.SetItemData(ViewModel.cboBaseStationContact.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
                ViewModel.cboTransportTo.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
                ViewModel.cboTransportTo.SetItemData(ViewModel.cboTransportTo.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
                ViewModel.cboTransportFrom.AddItem(IncidentMain.Clean(EMSCodes.HospitalCodes["facility_name"]));
                ViewModel.cboTransportFrom.SetItemData(ViewModel.cboTransportFrom.GetNewIndex(), Convert.ToInt32(EMSCodes.HospitalCodes["hospital_code"]));
                EMSCodes.HospitalCodes.MoveNext();
            }
            ;
            if (UnitCL.GetIncidentTransportResponses(ViewModel.CurrIncident) != 0)
            {

                while (!UnitCL.UnitResponse.EOF)
                {
                    ViewModel.cboTransportBy.AddItem(IncidentMain.Clean(UnitCL.UnitResponse["unit_code"]));
                    UnitCL.UnitResponse.MoveNext();
                };
            }
            else
            {
                ViewModel.optActionTaken[2].Enabled = false;
                ViewModel.cboTransportBy.Enabled = false;
                ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.DKGRAY;
            }


            //Narration
            EMSCodes.GetIncidentLocationCodes();

            while (!EMSCodes.IncidentLocationCodes.EOF)
            {
                ViewModel.cboIncidentLocation.AddItem(IncidentMain.Clean(EMSCodes.IncidentLocationCodes["description"]));
                ViewModel.cboIncidentLocation.SetItemData(ViewModel.cboIncidentLocation.GetNewIndex(), Convert.ToInt32(EMSCodes.IncidentLocationCodes["incident_location_code"]));
                EMSCodes.IncidentLocationCodes.MoveNext();
            }
            ;
            EMSCodes.GetIncidentSettingCodes();

            while (!EMSCodes.IncidentSettingCodes.EOF)
            {
                ViewModel.cboIncidentSetting.AddItem(IncidentMain.Clean(EMSCodes.IncidentSettingCodes["description"]));
                ViewModel.cboIncidentSetting.SetItemData(ViewModel.cboIncidentSetting.GetNewIndex(), Convert.ToInt32(EMSCodes.IncidentSettingCodes["incident_setting_code"]));
                EMSCodes.IncidentSettingCodes.MoveNext();
            }
            ;
            //Set default
            for (int i = 0; i <= ViewModel.cboIncidentSetting.Items.Count - 1; i++)
            {
                if (ViewModel.cboIncidentSetting.GetItemData(i) == 1)
                { //Urban

                    ViewModel.cboIncidentSetting.SelectedIndex = i;
                    break;
                }
            }

            EMSCodes.GetResearchCodes();

            while (!EMSCodes.ResearchCodes.EOF)
            {
                ViewModel.cboResearchCode.AddItem(IncidentMain.Clean(EMSCodes.ResearchCodes["description"]));
                ViewModel.cboResearchCode.SetItemData(ViewModel.cboResearchCode.GetNewIndex(), Convert.ToInt32(EMSCodes.ResearchCodes["research_code"]));
                EMSCodes.ResearchCodes.MoveNext();
            }
            ;


            //Trauma information
            EMSCodes.GetTraumaLocationCodes();

            while (!EMSCodes.TraumaLocationCodes.EOF)
            {
                ViewModel.cboPatientLocation.AddItem(IncidentMain.Clean(EMSCodes.TraumaLocationCodes["description"]));
                ViewModel.cboPatientLocation.SetItemData(ViewModel.cboPatientLocation.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaLocationCodes["trauma_location_code"]));
                EMSCodes.TraumaLocationCodes.MoveNext();
            }
            ;
            EMSCodes.GetProtectiveDeviceCodes();

            while (!EMSCodes.ProtectiveDeviceCodes.EOF)
            {
                ViewModel.cboProtectiveDevice.AddItem(IncidentMain.Clean(EMSCodes.ProtectiveDeviceCodes["description"]));
                ViewModel.cboProtectiveDevice.SetItemData(ViewModel.cboProtectiveDevice.GetNewIndex(), Convert.ToInt32(EMSCodes.ProtectiveDeviceCodes["protective_device_code"]));
                EMSCodes.ProtectiveDeviceCodes.MoveNext();
            }
            ;
            EMSCodes.GetTraumaTypeCodesByClass(1);

            while (!EMSCodes.TraumaTypeCodes.EOF)
            {
                ViewModel.lstTrauma1.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
                ViewModel.lstTrauma1.SetItemData(ViewModel.lstTrauma1.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
                EMSCodes.TraumaTypeCodes.MoveNext();
            }
            ;
            EMSCodes.GetTraumaTypeCodesByClass(2);

            while (!EMSCodes.TraumaTypeCodes.EOF)
            {
                ViewModel.lstTrauma2.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
                ViewModel.lstTrauma2.SetItemData(ViewModel.lstTrauma2.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
                EMSCodes.TraumaTypeCodes.MoveNext();
            }
            ;
            EMSCodes.GetTraumaTypeCodesByClass(3);

            while (!EMSCodes.TraumaTypeCodes.EOF)
            {
                ViewModel.lstTrauma3.AddItem(IncidentMain.Clean(EMSCodes.TraumaTypeCodes["description"]));
                ViewModel.lstTrauma3.SetItemData(ViewModel.lstTrauma3.GetNewIndex(), Convert.ToInt32(EMSCodes.TraumaTypeCodes["trauma_type_code"]));
                EMSCodes.TraumaTypeCodes.MoveNext();
            }
            ;

            //Narration
            ViewModel.FirstTime = 0;
            CheckComplete();
            ViewModel.ListsLoaded = -1;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

        }

        private void FlipImage()
        {
            //Generate random image pick

            VBMath.Randomize();
            int ImageNumber = Convert.ToInt32(Math.Floor((double)(35 * VBMath.Rnd() + 1)));
            string ImageFile = IncidentMain.IMAGEPATH + ImageNumber.ToString() + ".jpg";

        }

        private void StepBack()
        {
            ViewModel.CurrFrame.Visible = false;
            //Navigate to Previous Reporting Step
            if (ViewModel.CurrFrame.Name == "frmNoExamInfo")
            {
                ViewModel.CurrFrame = ViewModel.frmActionTaken;
            }
            else if (ViewModel.CurrFrame.Name == "frmPatientInformation")
            {
                ViewModel.CurrFrame = ViewModel.frmActionTaken;
                ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.chkCPRPerformed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                FlipImage();
            }
            else if (ViewModel.CurrFrame.Name == "frmExamInfo")
            {
                ViewModel.CurrFrame = ViewModel.frmPatientInformation;
            }
            else if (ViewModel.CurrFrame.Name == "frmProceduresPerformed")
            {
                ViewModel.CurrFrame = ViewModel.frmExamInfo;
            }
            else if (ViewModel.CurrFrame.Name == "frmTreatmentInfo")
            {
                ViewModel.CurrFrame = ViewModel.frmProceduresPerformed;
                if (ViewModel.CPRSwitch != 0)
                {
                    ViewModel.CurrFrame = ViewModel.frmCPR;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmCPR")
            {
                ViewModel.CurrFrame = ViewModel.frmProceduresPerformed;
            }
            else if (ViewModel.CurrFrame.Name == "frmTransportInfo")
            {
                if (ViewModel.CurrReport == IncidentMain.INTERFAC)
                {
                    ViewModel.CurrFrame = ViewModel.frmPatientInformation;
                }
                else
                {
                    ViewModel.CurrFrame = ViewModel.frmTreatmentInfo;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmTrauma")
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.EXAMONLY:
                        ViewModel.CurrFrame = ViewModel.frmExamInfo;
                        break;
                    default:
                        ViewModel.CurrFrame = ViewModel.frmTransportInfo;
                        break;
                }
                //        Select Case CurrFrame.NAME
            }
            else if (ViewModel.CurrFrame.Name == "frmNarration")
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.INTERFAC:
                    case IncidentMain.EXAMTRANSPORT:
                        ViewModel.CurrFrame = ViewModel.frmTransportInfo;
                        if (ViewModel.TraumaSwitch != 0)
                        {
                            ViewModel.CurrFrame = ViewModel.frmTrauma;
                        }
                        break;
                    case IncidentMain.EXAMONLY:
                        ViewModel.CurrFrame = ViewModel.frmExamInfo;
                        break;
                    case IncidentMain.EXAMASSIST:
                        ViewModel.CurrFrame = ViewModel.frmTreatmentInfo;
                        break;
                    case IncidentMain.NOEXAM:
                        ViewModel.CurrFrame = ViewModel.frmNoExamInfo;
                        break;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmReportStatus")
            {
                ViewModel.CurrFrame = ViewModel.frmNarration;
            }
            else
            {
                //Where are we?? - I guess we'll take the default!
                ViewManager.ShowMessage("Error determining next report step", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            FormatFrame();

        }

        //UPGRADE_NOTE: (7001) The following declaration (SetCurrFrame) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
        //private void SetCurrFrame(string sNextFrame)
        //{
        //Loop thru controls collect to find frame
        //Set CurrFrame to passed param - sNextFrame
        //
        //Set Current Frame
        ////UPGRADE_WARNING: (2065) Form property wzdEms.Controls has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
        //foreach (NestedControlEnumerator vControl in ContainerHelper.Controls(this))
        //{
        //if (ReflectionHelper.GetMember<string>(vControl, "NAME") == sNextFrame)
        //{
        //CurrFrame = vControl;
        //break;
        //}
        //}
        //
        //}

        private void StepNext()
        {
            //Navigate to Next Reporting Step
            //Or Initialize Unit Report on Startup
            ViewModel.CurrFrame.Visible = false;

            //Select Type of Report (EXAM,EXAMASSIST,EXAMTRANSPORT,NOEXAM,INTERFAC)
            if (ViewModel.CurrFrame.Name == "frmActionTaken")
            {
                InitialSave();
                LoadLists();
                //EMS Report - Select EMS Action Taken
                switch (ViewModel.CurrReport)
                {
                    //No exam, go to basic incident form
                    case IncidentMain.NOEXAM:
                        ViewModel.CurrFrame = ViewModel.frmNoExamInfo;
                        break;
                    default:
                        ViewModel.CurrFrame = ViewModel.frmPatientInformation;
                        break;
                }
                CheckComplete();
            }
            else if (ViewModel.CurrFrame.Name == "frmNoExamInfo")
            {
                ViewModel.CurrFrame = ViewModel.frmNarration;
            }
            else if (ViewModel.CurrFrame.Name == "frmPatientInformation")
            {
                //Interfacility transfers need transport information
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.INTERFAC:
                        ViewModel.CurrFrame = ViewModel.frmTransportInfo;
                        //otherwise get exam info 
                        break;
                    default:
                        ViewModel.CurrFrame = ViewModel.frmExamInfo;
                        break;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmExamInfo")
            {
                //if no procedures performed,  next form is narration or trauma
                if (ViewModel.CurrReport == IncidentMain.EXAMONLY)
                {
                    if (ViewModel.TraumaSwitch != 0)
                    {
                        ViewModel.CurrFrame = ViewModel.frmTrauma;
                    }
                    else
                    {
                        ViewModel.CurrFrame = ViewModel.frmNarration;
                    }
                }
                else
                {
                    ViewModel.CurrFrame = ViewModel.frmProceduresPerformed;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmProceduresPerformed")
            {
                if (ViewModel.CPRSwitch != 0)
                {
                    ViewModel.CurrFrame = ViewModel.frmCPR;
                }
                else
                {
                    ViewModel.CurrFrame = ViewModel.frmTreatmentInfo;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmCPR")
            {
                ViewModel.CurrFrame = ViewModel.frmTreatmentInfo;
            }
            else if (ViewModel.CurrFrame.Name == "frmTreatmentInfo")
            {
                //if no transport, next frame is narration
                if (ViewModel.CurrReport == IncidentMain.EXAMTRANSPORT)
                {
                    ViewModel.CurrFrame = ViewModel.frmTransportInfo;
                }
                else if (ViewModel.TraumaSwitch != 0)
                {
                    ViewModel.CurrFrame = ViewModel.frmTrauma;
                }
                else
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmTransportInfo")
            {
                if (ViewModel.TraumaSwitch != 0)
                {
                    ViewModel.CurrFrame = ViewModel.frmTrauma;
                }
                else
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
            }
            else if (ViewModel.CurrFrame.Name == "frmTrauma")
            {
                ViewModel.CurrFrame = ViewModel.frmNarration;
            }
            else if (ViewModel.CurrFrame.Name == "frmNarration")
            {
                ViewModel.CurrFrame = ViewModel.frmReportStatus;
                FlipImage();
            }

            FormatFrame();

        }

        private void StepQuit()
        {
            //Determine Reporting Status
            //And Exit Saving or Exit Not Saving or Cancel Finish Request


            if (CheckComplete() != 0)
            {
                if (~SaveEMSRecord(IncidentMain.COMPLETE) != 0)
                {
                    ViewManager.ShowMessage("Error Saving EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                else
                {
                    ViewManager.ShowMessage("EMS Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                }
            }
            else
            {
                if (~SaveEMSRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                {
                    ViewManager.ShowMessage("Error Saving EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                else
                {
                    ViewManager.ShowMessage("EMS Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                }
            }
            IncidentMain.Shared.gWizCancel = -1;
            ViewManager.DisposeView(this);
        }

        private void StepFinish()
        {
            //Determine Reporting Status
            //And Exit Saving or Exit Not Saving or Cancel Finish Request
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();

            if (CheckComplete() != 0)
            {
                if (~SaveEMSRecord(IncidentMain.COMPLETE) != 0)
                {
                    ViewManager.ShowMessage("Error Saving EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewManager.DisposeView(this);
                }
                else
                {
                    UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret =
                                    ReportLog.UpdateStatus(ref p1, ViewModel.PatientID, IncidentMain.COMPLETE);
                            IncidentMain.Shared.gNewReportID = p1;
                            return ret;
                        }, IncidentMain.Shared.gNewReportID);
                    IncidentMain.Shared.gWizCancel = 0;
                    ViewManager.DisposeView(this);
                }
            }
            else
            {
                if (~SaveEMSRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                {
                    ViewManager.ShowMessage("Error Saving EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewManager.DisposeView(this);
                }
                else
                {
                    UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret =
                                    ReportLog.UpdateStatus(ref p1, ViewModel.PatientID, IncidentMain.SAVEDINCOMPLETE);
                            IncidentMain.Shared.gNewReportID = p1;
                            return ret;
                        }, IncidentMain.Shared.gNewReportID);
                    IncidentMain.Shared.gWizCancel = 0;
                    ViewManager.DisposeView(this);
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAgeUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAgeUnits_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboAgeUnits.SelectedIndex == -1)
            {
                ViewModel.cboAgeUnits.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboALSPersonnel_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            int i = 0;

            if (ViewModel.cboALSPersonnel.SelectedIndex == -1)
            {
                return;
            }

            int ProcSelect = 0;
            if (ViewModel.cboALSProcedures.SelectedIndex != -1)
            {
                ProcSelect = -1;
            }
            if (ProcSelect != 0)
            {
                if (ViewModel.frmALSAttempts.Visible)
                {
                    ViewModel.cmdAddALS.Enabled = !ViewModel.txtAttempts.BackColor.Equals(IncidentMain.Shared.REQCOLOR);
                }
                else
                {
                    ViewModel.cmdAddALS.Enabled = true;
                }
            }
            else
            {
                ViewModel.cmdAddALS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboALSPersonnel_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboALSPersonnel.SelectedIndex == -1)
            {
                ViewModel.cboALSPersonnel.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboALSProcedures_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            int i = 0;
            if (ViewModel.cboALSProcedures.SelectedIndex == -1)
            {
                return;
            }

            switch (ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
            {
                case 13:
                case 15:
                case 16:
                case 21:
                case 22:
                case 26:
                case 27:
                case 55:
                case 56:
                    ViewModel.frmALSAttempts.Visible = true;
                    break;
                default:
                    ViewModel.frmALSAttempts.Visible = false;
                    break;
            }
            CheckComplete();
            int ProcSelect = 0;
            if (ViewModel.cboALSPersonnel.SelectedIndex != -1)
            {
                ProcSelect = -1;
            }
            if (ProcSelect != 0)
            {
                if (ViewModel.frmALSAttempts.Visible)
                {
                    ViewModel.cmdAddALS.Enabled = !ViewModel.txtAttempts.BackColor.Equals(IncidentMain.Shared.REQCOLOR);
                }
                else
                {
                    ViewModel.cmdAddALS.Enabled = true;
                }
            }
            else
            {
                ViewModel.cmdAddALS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboALSProcedures_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboALSProcedures.SelectedIndex == -1)
            {
                ViewModel.cboALSProcedures.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBaseStationContact_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboBaseStationContact.SelectedIndex == -1)
            {
                ViewModel.cboBaseStationContact.Text = "";
            }
            else
            {
                ViewModel.frmBaseStationContact.Visible = true;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBaseStationContact_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboBaseStationContact.SelectedIndex == -1)
            {
                ViewModel.cboBaseStationContact.Text = "";
            }


        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBLSProcedures_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {

            if (ViewModel.cboBLSProcedures.SelectedIndex != -1)
            {
                if (ViewModel.cboBLSProcedures.GetItemData(ViewModel.cboBLSProcedures.SelectedIndex) == 24)
                { //Other BLS Procedures

                    ViewModel.lbProcs[1].Visible = true;
                    ViewModel.txtOtherBLSProcedures.Visible = true;
                    ViewModel.txtOtherBLSProcedures.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtOtherBLSProcedures.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
                else
                {
                    ViewModel.lbProcs[1].Visible = false;
                    ViewModel.txtOtherBLSProcedures.Visible = false;
                    ViewModel.txtOtherBLSProcedures.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtOtherBLSProcedures.ForeColor = IncidentMain.Shared.EMSFONT;
                }
            }
            else
            {
                ViewModel.cboBLSProcedures.Text = "";
                return;
            }

            CheckComplete();

            int ProcSelect = 0;
            for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSPersonnel.GetSelected(i))
                {
                    ProcSelect = -1;
                    break;
                }
            }
            if (ProcSelect != 0)
            {
                ViewModel.cmdAddBLS.Enabled = ViewModel.cboBLSProcedures.SelectedIndex != -1;
            }
            else
            {
                ViewModel.cmdAddBLS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBLSProcedures_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboBLSProcedures.SelectedIndex == -1)
            {
                ViewModel.cboBLSProcedures.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBodyPart_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBodyPart_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboBodyPart.SelectedIndex == -1)
            {
                ViewModel.cboBodyPart.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboCPRPerformedBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboCPRPerformedBy.SelectedIndex == -1)
            {
                ViewModel.cboCPRPerformedBy.Text = "";
            }
            else
            {
                CheckComplete();
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboCPRPerformedBy_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboCPRPerformedBy.SelectedIndex == -1)
            {
                ViewModel.cboCPRPerformedBy.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboECG_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboECG.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboECG[Index].SelectedIndex == -1)
            {
                ViewModel.cboECG[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEMSRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEMSRace_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboEMSRace.SelectedIndex == -1)
            {
                ViewModel.cboEMSRace.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEyes_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEyes_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboEyes.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboEyes[Index].SelectedIndex == -1)
            {
                ViewModel.cboEyes[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboGauge_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboGauge_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboGauge.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboGauge[Index].SelectedIndex == -1)
            {
                ViewModel.cboGauge[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboHospitalChosenBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboHospitalChosenBy_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboHospitalChosenBy.SelectedIndex == -1)
            {
                ViewModel.cboHospitalChosenBy.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncidentLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboIncidentLocation.SelectedIndex == -1)
            {
                ViewModel.cboIncidentLocation.Text = "";
            }
            else
            {
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncidentLocation_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboIncidentLocation.SelectedIndex == -1)
            {
                ViewModel.cboIncidentLocation.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncidentSetting_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboIncidentSetting.SelectedIndex == -1)
            {
                ViewModel.cboIncidentSetting.Text = "";
            }
            else
            {
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboIncidentSetting_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboIncidentSetting.SelectedIndex == -1)
            {
                ViewModel.cboIncidentSetting.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInjuryType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInjuryType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboInjuryType.SelectedIndex == -1)
            {
                ViewModel.cboInjuryType.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMechCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.NarrationRequired = 0;
            if (ViewModel.cboMechCode.SelectedIndex == -1)
            {
                ViewModel.cboMechCode.Text = "";
                ViewModel.cboPrimaryIllness.SelectedIndex = -1;
                ViewModel.cboInjuryType.SelectedIndex = -1;
                ViewModel.cboBodyPart.SelectedIndex = -1;
                ViewModel.cboPrimaryIllness.Enabled = false;
                ViewModel.cboInjuryType.Enabled = false;
                ViewModel.cboBodyPart.Enabled = false;
                ViewModel.chkMajTrauma.Enabled = false;
                CheckComplete();
                return;
            }
            ViewModel.FirstTime = -1;
            ViewModel.TraumaSwitch = 0;
            ViewModel.cboInjuryType.SelectedIndex = -1;
            ViewModel.cboBodyPart.SelectedIndex = -1;
            ViewModel.cboPrimaryIllness.SelectedIndex = -1;
            ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            switch (ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex))
            {
                case 1:
                    ViewModel.frmInjury.Enabled = false;
                    ViewModel.frmIllness.Enabled = false;
                    ViewModel.cboInjuryType.Enabled = false;
                    ViewModel.cboBodyPart.Enabled = false;
                    ViewModel.chkMajTrauma.Enabled = false;
                    ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
                    ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
                    ViewModel.cboPrimaryIllness.Enabled = false;
                    ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
                    break;
                case 3:
                case 4:
                case 7:
                case 12:
                case 13:
                case 19:
                case 22:
                case 23:
                case 24:
                case 27:
                case 29:  //Medical 

                    ViewModel.frmIllness.Enabled = true;
                    ViewModel.frmInjury.Enabled = false;
                    ViewModel.cboPrimaryIllness.Enabled = true;
                    ViewModel.cboInjuryType.Enabled = false;
                    ViewModel.cboBodyPart.Enabled = false;
                    ViewModel.chkMajTrauma.Enabled = false;
                    ViewModel.cboInjuryType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboInjuryType.ForeColor = IncidentMain.Shared.EMSFONT;
                    ViewModel.cboBodyPart.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboBodyPart.ForeColor = IncidentMain.Shared.EMSFONT;
                    break;
                default: //Injury 

                    ViewModel.frmInjury.Enabled = true;
                    ViewModel.frmIllness.Enabled = false;
                    ViewModel.cboInjuryType.Enabled = true;
                    ViewModel.cboBodyPart.Enabled = true;
                    ViewModel.chkMajTrauma.Enabled = true;
                    ViewModel.cboPrimaryIllness.Enabled = false;
                    ViewModel.cboPrimaryIllness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cboPrimaryIllness.ForeColor = IncidentMain.Shared.EMSFONT;
                    ViewModel.NarrationRequired = -1;
                    break;
            }
            ViewModel.FirstTime = 0;

            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMechCode_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboMechCode.SelectedIndex == -1)
            {
                ViewModel.cboMechCode.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMedications_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {

            if (ViewModel.cboMedications.SelectedIndex != -1)
            {
                if (ViewModel.txtDosage.Text != "")
                {
                    double dbNumericTemp = 0;
                    ViewModel.cmdAddMedications.Enabled = Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp);
                }
                else
                {
                    ViewModel.cmdAddMedications.Enabled = false;
                }

            }
            else
            {
                ViewModel.cmdAddMedications.Enabled = false;
                ViewModel.cboMedications.Text = "";
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMedications_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboMedications.SelectedIndex == -1)
            {
                ViewModel.cboMedications.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMotor_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMotor_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboMotor.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboMotor[Index].SelectedIndex == -1)
            {
                ViewModel.cboMotor[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPatientAgeUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPatientAgeUnits_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboPatientAgeUnits.SelectedIndex == -1)
            {
                ViewModel.cboPatientAgeUnits.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPatientLocation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPatientLocation_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboPatientLocation.SelectedIndex == -1)
            {
                ViewModel.cboPatientLocation.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPrimaryIllness_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPrimaryIllness_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboPrimaryIllness.SelectedIndex == -1)
            {
                ViewModel.cboPrimaryIllness.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboProtectiveDevice_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboProtectiveDevice_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboProtectiveDevice.SelectedIndex == -1)
            {
                ViewModel.cboProtectiveDevice.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRace_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboRace.SelectedIndex == -1)
            {
                ViewModel.cboRace.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRate_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRate_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboRate.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboRate[Index].SelectedIndex == -1)
            {
                ViewModel.cboRate[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboResearchCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboResearchCode.SelectedIndex == -1)
            {
                ViewModel.cboResearchCode.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboResearchCode_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboResearchCode.SelectedIndex == -1)
            {
                ViewModel.cboResearchCode.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRoute_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRoute_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboRoute.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboRoute[Index].SelectedIndex == -1)
            {
                ViewModel.cboRoute[Index].Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboServiceProvided_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboServiceProvided_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboServiceProvided.SelectedIndex == -1)
            {
                ViewModel.cboServiceProvided.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSite_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSite_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboSite.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboSite[Index].SelectedIndex == -1)
            {
                ViewModel.cboSite[Index].Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboState_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboState.SelectedIndex == -1)
            {
                ViewModel.cboState.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportBy_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();

            // Save record as ALS w/Transport or BLS w/Transport
            if (ViewModel.cboTransportBy.SelectedIndex != -1)
            {
                if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) != "")
                {
                    if (UnitCL.GetTranportUnitALSFlag(ViewModel.cboTransportBy.Text) != 0)
                    {
                        ViewModel.EMSType = IncidentMain.ALSTRANS;
                    }
                    else
                    {
                        ViewModel.EMSType = IncidentMain.BLSTRANS;
                    }
                }
                else
                {
                    ViewModel.EMSType = IncidentMain.BLSTRANS;
                }
                CheckComplete();
            }
            else
            {
                ViewModel.cboTransportBy.Text = "";
            }


        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportBy_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboTransportBy.SelectedIndex == -1)
            {
                ViewModel.cboTransportBy.Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportFrom_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportFrom_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboTransportFrom.SelectedIndex == -1)
            {
                ViewModel.cboTransportFrom.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportTo_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            TFDIncident.clsUnit UnitCL = Container.Resolve<clsUnit>();

            // Save record as ALS w/Transport or BLS w/Transport
            if (ViewModel.cboTransportTo.SelectedIndex != -1)
            {
                if (ViewModel.cboTransportBy.SelectedIndex != -1)
                {
                    if (UnitCL.GetTFDUnit(ViewModel.cboTransportBy.Text) != "")
                    {
                        if (UnitCL.GetTranportUnitALSFlag(ViewModel.cboTransportBy.Text) != 0)
                        {
                            ViewModel.EMSType = IncidentMain.ALSTRANS;
                        }
                        else
                        {
                            ViewModel.EMSType = IncidentMain.BLSTRANS;
                        }
                    }
                    else
                    {
                        ViewModel.EMSType = IncidentMain.BLSTRANS;
                    }
                }
                else
                {
                    ViewModel.EMSType = IncidentMain.ALSTRANS;
                }
                CheckComplete();
            }
            else
            {
                ViewModel.cboTransportTo.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTransportTo_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboTransportTo.SelectedIndex == -1)
            {
                ViewModel.cboTransportTo.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTreatmentAuth_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboTreatmentAuth_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboTreatmentAuth.SelectedIndex == -1)
            {
                ViewModel.cboTreatmentAuth.Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboVerbal_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboVerbal_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboVerbal.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboVerbal[Index].SelectedIndex == -1)
            {
                ViewModel.cboVerbal[Index].Text = "";
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboVitalsPosition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboVitalsPosition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.cboVitalsPosition.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
            if (ViewModel.cboVitalsPosition[Index].SelectedIndex == -1)
            {
                ViewModel.cboVitalsPosition[Index].Text = "";
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkCPRPerformed_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkCPRPerformed.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.CPRSwitch = -1;
            }
            else
            {
                ViewModel.CPRSwitch = 0;
                LoadBLSProcedures();
            }

            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkMajTrauma_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkMajTrauma.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.TraumaSwitch = 1;
            }
            else
            {
                ViewModel.TraumaSwitch = 0;
            }

            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkNoVitals_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkNoVitals.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.NoVitals = -1;
            }
            else
            {
                ViewModel.NoVitals = 0;
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkPalp_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAbandon_Click(Object eventSender, System.EventArgs eventArgs)
        {
            int Response = 0;
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();

            if (ViewModel.ReportSaved != 0)
            {
                //Delete Temp Records
                if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                       {
                           var ret = EMSReport.DeleteEMSPatientContact(ref p1);
                           ViewModel.PatientID = p1;
                           return ret;
                       }, ViewModel.PatientID) != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Remove EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            IncidentMain.Shared.gWizCancel = -1;
            ViewManager.ShowMessage("All Changes Abandoned - Better Luck Next Time!", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
            ViewManager.DisposeView(this);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddALS_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //add als procedure record here
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            ViewModel.IVPerformed = 0;

            string EmpID = ViewModel.cboALSPersonnel.Text.Substring(Math.Max(ViewModel.cboALSPersonnel.Text.Length - 5, 0));
            EMSReport.ProcedurePatientID = ViewModel.PatientID;
            EMSReport.Procedure = ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex);
            EMSReport.PerformedBy = EmpID;
            if (ViewModel.txtAttempts.Text != "")
            {
                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                EMSReport.Attempts = Convert.ToInt32(IncidentMain.GetVal(ViewModel.txtAttempts.Text));
            }
            else
            {
                EMSReport.Attempts = 0;
            }
            if (ViewModel.chkSuccessful.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                EMSReport.FlagSuccessful = 1;
            }
            else
            {
                EMSReport.FlagSuccessful = 0;
            }
            EMSReport.OtherProcedureDescription = IncidentMain.Clean(ViewModel.txtOtherALSProcedures.Text);
            switch (ViewModel.cboALSProcedures.GetItemData(ViewModel.cboALSProcedures.SelectedIndex))
            {
                case 14:
                case 15:
                case 16:  //IV 

                    ViewModel.IVPerformed = -1;
                    break;
            }
            if (~EMSReport.AddEMSProcedure() != 0)
            {
                ViewManager.ShowMessage("Error in addding ALS Procedures", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

            //Clean fields when done
            ViewModel.txtAttempts.Text = "";
            ViewModel.chkSuccessful.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.txtOtherALSProcedures.Text = "";
            ViewModel.cboALSProcedures.SelectedIndex = -1;
            //  cboALSPersonnel.ListIndex = -1

            LoadALSProcedures();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddBLS_Click(Object eventSender, System.EventArgs eventArgs)
        {
            // add bls procedure record here
            string EmpID = "";
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSPersonnel.GetSelected(i))
                {
                    UpgradeHelpers.Helpers.ListBoxHelper.SetSelectedIndex(ViewModel.lstBLSPersonnel, i);
                    EmpID = ViewModel.lstBLSPersonnel.Text.Substring(Math.Max(ViewModel.lstBLSPersonnel.Text.Length - 5, 0));
                    EMSReport.ProcedurePatientID = ViewModel.PatientID;
                    EMSReport.Procedure = ViewModel.cboBLSProcedures.GetItemData(ViewModel.cboBLSProcedures.SelectedIndex);
                    EMSReport.PerformedBy = EmpID;
                    EMSReport.Attempts = 0;
                    EMSReport.FlagSuccessful = 1;
                    EMSReport.OtherProcedureDescription = ViewModel.txtOtherBLSProcedures.Text;
                    if (~EMSReport.AddEMSProcedure() != 0)
                    {
                        ViewManager.ShowMessage("Error in addding BLS Procedures", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                }
            }
            //clear items
            ViewModel.lbProcs[1].Visible = false;
            ViewModel.txtOtherBLSProcedures.Visible = false;
            ViewModel.txtOtherBLSProcedures.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.txtOtherBLSProcedures.ForeColor = IncidentMain.Shared.EMSFONT;

            //    cboBLSProcedures.ListIndex = -1

            LoadBLSProcedures();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddCPR_Click(Object eventSender, System.EventArgs eventArgs)
        {
            // add CPR Performed By record
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();

            EMSReport.CPRPerfPatientID = ViewModel.PatientID;
            EMSReport.CPRPerformedBy = ViewModel.cboCPRPerformedBy.GetItemData(ViewModel.cboCPRPerformedBy.SelectedIndex);

            if (~EMSReport.AddEMSCPRPerformer() != 0)
            {
                ViewManager.ShowMessage("Error in adding CPR Performed By", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            CheckComplete();
            // clear items
            UpgradeHelpers.Helpers.ListBoxHelper.SetSelectedIndex(ViewModel.lstCPRPerformedBy, -1);
            LoadCPRPerformedBy();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddMedications_Click(Object eventSender, System.EventArgs eventArgs)
        {
            // add medication record
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();

            int MedCode = ViewModel.cboMedications.GetItemData(ViewModel.cboMedications.SelectedIndex);
            if (~EMSReport.GetEMSMedication(ViewModel.PatientID, MedCode) != 0)
            {
                EMSReport.MedPatientID = ViewModel.PatientID;
                EMSReport.Medication = MedCode;
                EMSReport.AdministeredDosage = Convert.ToInt32(Conversion.Val(ViewModel.txtDosage.Text));
                if (~EMSReport.AddEMSMedication() != 0)
                {
                    ViewManager.ShowMessage("Error in adding Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                //update
                EMSReport.MedPatientID = ViewModel.PatientID;
                EMSReport.Medication = MedCode;
                EMSReport.AdministeredDosage = Convert.ToInt32(Convert.ToDouble(EMSReport.EMSMedication["administered_dosage"]) + Conversion.Val(ViewModel.txtDosage.Text));
                if (!EMSReport.UpdateEMSMedication())
                {
                    ViewManager.ShowMessage("Error in updating Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            // clear items
            ViewModel.txtDosage.Text = "";
            // move next line to loadMedications
            //   cboMedications.ListIndex = -1

            LoadMedications();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClear1_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Clear all option button selections
            ViewModel.FirstTime = -1;
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.optArrestToCPR[i].Checked = false;
            }
            ViewModel.FirstTime = 0;
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClear2_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Clear all option button selections
            ViewModel.FirstTime = -1;
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.optArrestToALS[i].Checked = false;
            }
            ViewModel.FirstTime = 0;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdClear3_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Clear all option button selections
            ViewModel.FirstTime = -1;
            for (int i = 0; i <= 3; i++)
            {
                ViewModel.optArrestToShock[i].Checked = false;
            }
            ViewModel.FirstTime = 0;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRemoveALSProcedures_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //remove als procedure records here
            //check to make sure that item has been selected
            TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

            int ProcSelect = 0;
            for (int i = 0; i <= ViewModel.lstALSProcedures.Items.Count - 1; i++)
            {
                if (ViewModel.lstALSProcedures.GetSelected(i))
                {
                    ProcSelect = -1;
                    break;
                }
            }

            if (~ProcSelect != 0)
            {
                return;
            } //no items selected

            for (int i = 0; i <= ViewModel.lstALSProcedures.Items.Count - 1; i++)
            {
                if (ViewModel.lstALSProcedures.GetSelected(i))
                {
                    ProcSelect = ViewModel.lstALSProcedures.GetItemData(i);
                    if (~EMScl.DeleteEMSProcedure(ref ProcSelect) != 0)
                    {
                        ViewManager.ShowMessage("Error deleting ALS Procedure", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        break;
                    }
                }
            }

            LoadALSProcedures();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRemoveBLSProcedures_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //remove bls procedure records here
            //check to make sure that item has been selected
            TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

            int ProcSelect = 0;
            for (int i = 0; i <= ViewModel.lstBLSProcedures.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSProcedures.GetSelected(i))
                {
                    ProcSelect = -1;
                    break;
                }
            }

            if (~ProcSelect != 0)
            {
                return;
            } //no items selected

            for (int i = 0; i <= ViewModel.lstBLSProcedures.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSProcedures.GetSelected(i))
                {
                    ProcSelect = ViewModel.lstBLSProcedures.GetItemData(i);
                    if (~EMScl.DeleteEMSProcedure(ref ProcSelect) != 0)
                    {
                        ViewManager.ShowMessage("Error deleting BLS Procedure", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        break;
                    }
                }
            }

            LoadBLSProcedures();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRemoveCPR_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Remove Selected CPR Performer Record
            //check to make sure that item has been selected
            TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

            int CPRSelect = 0;
            for (int i = 0; i <= ViewModel.lstCPRPerformedBy.Items.Count - 1; i++)
            {
                if (ViewModel.lstCPRPerformedBy.GetSelected(i))
                {
                    CPRSelect = -1;
                    break;
                }
            }


            if (~CPRSelect != 0)
            {
                return;
            } //no items selected

            for (int i = 0; i <= ViewModel.lstCPRPerformedBy.Items.Count - 1; i++)
            {
                if (ViewModel.lstCPRPerformedBy.GetSelected(i))
                {
                    int tempRefParam = ViewModel.lstCPRPerformedBy.GetItemData(i);
                    if (~EMScl.DeleteEMSCPRPerformer(ref tempRefParam) != 0)
                    {
                        ViewManager.ShowMessage("Error deleting CPR Performer", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        break;
                    }
                }
            }

            LoadCPRPerformedBy();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdRemoveMedication_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //remove record here
            //check to make sure that item has been selected
            TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

            int MedSelect = 0;
            for (int i = 0; i <= ViewModel.lstMedications.Items.Count - 1; i++)
            {
                if (ViewModel.lstMedications.GetSelected(i))
                {
                    MedSelect = -1;
                    break;
                }
            }

            if (~MedSelect != 0)
            {
                return;
            } //no items selected

            for (int i = 0; i <= ViewModel.lstMedications.Items.Count - 1; i++)
            {
                if (ViewModel.lstMedications.GetSelected(i))
                {
                    MedSelect = ViewModel.lstMedications.GetItemData(i);
                    if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                           {
                               var ret = EMScl.DeleteEMSMedication(ref p1, ref MedSelect);
                               ViewModel.PatientID = p1;
                               return ret;
                           }, ViewModel.PatientID) != 0)
                    {
                        ViewManager.ShowMessage("Error deleting Medications", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        break;
                    }
                }
            }

            LoadMedications();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Save Current Report
            if (SaveEMSRecord(IncidentMain.COMPLETE) != 0)
            {
                ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
            }
            else
            {
                ViewManager.ShowMessage("Error attempting to save EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            ViewManager.DisposeView(this);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSaveIncomplete_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Save Current Report as Incomplete
            if (SaveEMSRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
            {
                ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
            }
            else
            {
                ViewManager.ShowMessage("Error attempting to save EMS Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            ViewManager.DisposeView(this);
        }

        private int SaveEMSRecord(int UpdateType)
        {

            //if Exit without Saving then Get out
            int result = 0;
            if (UpdateType == IncidentMain.NOREPORT)
            {
                return -1;
            }
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            TFDIncident.clsEMSCodes EMSCodes = Container.Resolve<clsEMSCodes>();
            string DateWork = "", HourWork = "";

            result = -1;

            //**********************************************************************
            // EMS Patient Contact Record
            //**********************************************************************
            //Common Fields
            EMSReport.PatientID = ViewModel.PatientID;
            EMSReport.IncidentID = ViewModel.CurrIncident;
            EMSReport.ActionTaken = ViewModel.ActionTaken;
            //If no EMSType has ever been selected load a default type of
            //69 - BLS No Transport
            if (ViewModel.EMSType == 0)
            {
                ViewModel.EMSType = 69;
            }

            EMSReport.IncidentType = ViewModel.EMSType;
            //If no Dispatched As indication load default of BLS
            if (ViewModel.DispatchedAs != "A" && ViewModel.DispatchedAs != "B")
            {
                ViewModel.DispatchedAs = "B";
            }
            EMSReport.DispatchedAlsBls = ViewModel.DispatchedAs;


            // default Severity is non-urgent, No treatment authorization, Level of Care is BLS
            EMSReport.Severity = 4;
            EMSReport.TreatmentAuthorization = 1; //Followed standard protocol
                                                  //If no Levelofcare captured default to BLS
            if (ViewModel.LevelOfCare != "A" && ViewModel.LevelOfCare != "B")
            {
                ViewModel.LevelOfCare = "B";
            }
            EMSReport.LevelOfCareAlsBls = "B";

            if (ViewModel.cboIncidentLocation.SelectedIndex != -1)
            {
                EMSReport.IncidentLocation = ViewModel.cboIncidentLocation.GetItemData(ViewModel.cboIncidentLocation.SelectedIndex);
            }
            else
            {
                EMSReport.IncidentLocation = 0;
            }
            EMSReport.IncidentZipcode = IncidentMain.Clean(ViewModel.txtIncidentZipcode.Text);
            if (ViewModel.cboIncidentSetting.SelectedIndex != -1)
            {
                EMSReport.IncidentSetting = ViewModel.cboIncidentSetting.GetItemData(ViewModel.cboIncidentSetting.SelectedIndex);
            }
            else
            {
                EMSReport.IncidentSetting = 0;
            }
            if (ViewModel.cboResearchCode.SelectedIndex != -1)
            {
                EMSReport.ResearchCode = ViewModel.cboResearchCode.GetItemData(ViewModel.cboResearchCode.SelectedIndex);
            }
            else
            {
                EMSReport.ResearchCode = 0;
            }

            //EMS Basic Incident - No Exam, Refused Treatment, or DOA
            if (ViewModel.ActionTaken == 3 || ViewModel.ActionTaken == 4 || ViewModel.ActionTaken == 5)
            {
                if (ViewModel.optEMSGender[0].Checked)
                {
                    EMSReport.Gender = 1;
                }
                else
                {
                    EMSReport.Gender = 2;
                }
                EMSReport.Age = Convert.ToInt32(Conversion.Val(ViewModel.txtAge.Text));
                if (ViewModel.cboAgeUnits.SelectedIndex != -1)
                {
                    EMSReport.AgeUnit = ViewModel.cboAgeUnits.GetItemData(ViewModel.cboAgeUnits.SelectedIndex);
                }
                else
                {
                    EMSReport.AgeUnit = 0;
                }
                if (ViewModel.cboEMSRace.SelectedIndex != -1)
                {
                    EMSReport.Race = ViewModel.cboEMSRace.GetItemData(ViewModel.cboEMSRace.SelectedIndex);
                }
                else
                {
                    EMSReport.Race = 0;
                }
                if (ViewModel.optEMSEthnicity[0].Checked)
                {
                    EMSReport.Ethnicity = 3; //Hispanic
                }
                else
                {
                    EMSReport.Ethnicity = 4; //Non-Hispanic
                }
                if (ViewModel.cboServiceProvided.SelectedIndex != -1)
                {
                    EMSReport.ServiceProvided = ViewModel.cboServiceProvided.GetItemData(ViewModel.cboServiceProvided.SelectedIndex);
                }
                else
                {
                    EMSReport.ServiceProvided = 0;
                }
                EMSReport.Severity = 4;
            }
            else
            {
                //get patient stuff for non-basic
                EMSReport.Age = Convert.ToInt32(Conversion.Val(ViewModel.txtPatientAge.Text));
                if (ViewModel.cboPatientAgeUnits.SelectedIndex != -1)
                {
                    EMSReport.AgeUnit = ViewModel.cboPatientAgeUnits.GetItemData(ViewModel.cboPatientAgeUnits.SelectedIndex);
                }
                else
                {
                    EMSReport.AgeUnit = 0;
                }
                if (ViewModel.optGender[0].Checked)
                {
                    EMSReport.Gender = 1;
                }
                else
                {
                    EMSReport.Gender = 2;
                }
                if (ViewModel.cboRace.SelectedIndex != -1)
                {
                    EMSReport.Race = ViewModel.cboRace.GetItemData(ViewModel.cboRace.SelectedIndex);
                }
                else
                {
                    EMSReport.Race = 0;
                }
                if (ViewModel.optEthnicity[0].Checked)
                {
                    EMSReport.Ethnicity = 3;
                }
                else
                {
                    EMSReport.Ethnicity = 4;
                }
                if (ViewModel.optSeverity[0].Checked)
                {
                    EMSReport.Severity = 1;
                }
                else if (ViewModel.optSeverity[1].Checked)
                {
                    EMSReport.Severity = 3;
                }
                else if (ViewModel.optSeverity[2].Checked)
                {
                    EMSReport.Severity = 4;
                }
                else
                {
                    EMSReport.Severity = 0;
                }
            }
            //------------- Save patient contact report ---------------
            if (~EMSReport.UpdateEMSPatientContact() != 0)
            {
                //get out if record didn't save
                return 0;
            }
            else
            {
                //Update ReportLog
                //Save Narration
                SaveEMSNarration();
                if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                       {
                           var ret = ReportLog.UpdateStatus(ref p1, ViewModel.PatientID, UpdateType);
                           ViewModel.ReportLogID = p1;
                           return ret;
                       }, ViewModel.ReportLogID) != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Update ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            //------------- If Basic incident Save EMSPatient Record and get out ----------------
            if (ViewModel.ActionTaken == 3 || ViewModel.ActionTaken == 4 || ViewModel.ActionTaken == 5)
            {
                //Save EMSPatient Record if First or Last Name Fields Completed
                if (IncidentMain.Clean(ViewModel.txtBFirstName.Text) != "")
                {
                    EMSReport.EMSPatientID = ViewModel.PatientID;
                    EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtBFirstName.Text);
                    EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtBLastName.Text);
                    EMSReport.NameMI = IncidentMain.Clean(ViewModel.txtBMI.Text);
                    EMSReport.Phone = IncidentMain.Clean(ViewModel.txtBHomePhone.Text);
                    if (Information.IsDate(ViewModel.txtBBirthdate.Text))
                    {
                        EMSReport.Birthdate = DateTime.Parse(ViewModel.txtBBirthdate.Text).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        EMSReport.Birthdate = "";
                    }
                    EMSReport.SocialSecurityNumber = "";
                    EMSReport.BillingAddress = "";
                    EMSReport.City = "";
                    EMSReport.State = "";
                    EMSReport.FlagDNRO = 0;
                    //- Save Abreviated Patient report ------
                    if (~EMSReport.AddEMSPatient() != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        result = 0;
                    }
                }
                else if (IncidentMain.Clean(ViewModel.txtBLastName.Text) != "")
                {
                    EMSReport.EMSPatientID = ViewModel.PatientID;
                    EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtBFirstName.Text);
                    EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtBLastName.Text);
                    EMSReport.NameMI = IncidentMain.Clean(ViewModel.txtBMI.Text);
                    EMSReport.Phone = IncidentMain.Clean(ViewModel.txtBHomePhone.Text);
                    if (Information.IsDate(ViewModel.txtBBirthdate.Text))
                    {
                        EMSReport.Birthdate = DateTime.Parse(ViewModel.txtBBirthdate.Text).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        EMSReport.Birthdate = "";
                    }
                    EMSReport.SocialSecurityNumber = "";
                    EMSReport.BillingAddress = "";
                    EMSReport.City = "";
                    EMSReport.State = "";
                    EMSReport.FlagDNRO = 0;
                    //- Save Abreviated Patient report ------
                    if (~EMSReport.AddEMSPatient() != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Add New EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        result = 0;
                    }
                }
                return result;
            }

            //*******************************************************************
            // EMS Transport Record
            //*******************************************************************
            if (ViewModel.ActionTaken == 7 || ViewModel.ActionTaken == 2)
            {
                EMSReport.TransPatientID = ViewModel.PatientID;
                if (ViewModel.cboBaseStationContact.SelectedIndex != -1)
                {
                    EMSReport.BaseStation = ViewModel.cboBaseStationContact.GetItemData(ViewModel.cboBaseStationContact.SelectedIndex);
                }
                else
                {
                    EMSReport.BaseStation = 0;
                }
                if (ViewModel.cboHospitalChosenBy.SelectedIndex != -1)
                {
                    EMSReport.HospitalChosenBy = ViewModel.cboHospitalChosenBy.GetItemData(ViewModel.cboHospitalChosenBy.SelectedIndex);
                }
                else
                {
                    EMSReport.HospitalChosenBy = 0;
                }
                if (ViewModel.optMDorRN[0].Checked)
                {
                    EMSReport.HospitalStaffType = 1; //MD
                }
                else if (ViewModel.optMDorRN[1].Checked)
                {
                    EMSReport.HospitalStaffType = 2; //RN
                }
                else if (ViewModel.optMDorRN[2].Checked)
                {
                    EMSReport.HospitalStaffType = 3; //Other
                }
                else
                {
                    EMSReport.HospitalStaffType = 0;
                }
                if (ViewModel.chkDiverted.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                {
                    EMSReport.FlagDiverted = (byte)ViewModel.chkDiverted.CheckState;
                }
                EMSReport.Mileage = (float)Conversion.Val(ViewModel.txtMileage.Text);
                if (ViewModel.cboTransportTo.SelectedIndex != -1)
                {
                    EMSReport.TransportedTo = ViewModel.cboTransportTo.GetItemData(ViewModel.cboTransportTo.SelectedIndex);
                }
                else
                {
                    EMSReport.TransportedTo = 0;
                }
                if (ViewModel.cboTransportFrom.SelectedIndex != -1)
                {
                    EMSReport.TransportedFrom = ViewModel.cboTransportFrom.GetItemData(ViewModel.cboTransportFrom.SelectedIndex);
                }
                else
                {
                    EMSReport.TransportedFrom = 0;
                }
                if (ViewModel.cboTransportBy.SelectedIndex != -1)
                {
                    EMSReport.TransportBy = ViewModel.cboTransportBy.Text;
                }
                else
                {
                    EMSReport.TransportBy = "";
                }
                //------------- Save Transport report ---------------
                if (~EMSReport.AddEMSPatientTransport() != 0)
                {
                    return 0;
                }
            }


            //*******************************************************************
            // EMS Patient Record
            //*******************************************************************
            //Get Patient Information for Exam, ExamAssist, Transport, Refused Transport, Interfacility transfer
            EMSReport.EMSPatientID = ViewModel.PatientID;
            EMSReport.NameFirst = IncidentMain.Clean(ViewModel.txtFirstName.Text);
            EMSReport.NameLast = IncidentMain.Clean(ViewModel.txtLastName.Text);
            EMSReport.NameMI = IncidentMain.Clean(ViewModel.txtMI.Text);
            if (ViewModel.mskSSN.Text == "___-__-____")
            {
                EMSReport.SocialSecurityNumber = "";
            }
            else
            {
                EMSReport.SocialSecurityNumber = IncidentMain.Clean(ViewModel.mskSSN.Text);
            }
            EMSReport.BillingAddress = IncidentMain.Clean(ViewModel.txtBillingAddress.Text);
            EMSReport.City = IncidentMain.Clean(ViewModel.txtCity.Text);
            if (ViewModel.cboState.SelectedIndex != -1)
            {
                EMSReport.State = ViewModel.cboState.Text;
            }
            else
            {
                EMSReport.State = "";
            }
            double dbNumericTemp = 0;
            if (Double.TryParse(ViewModel.txtZipCode.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                EMSReport.Zipcode = IncidentMain.Clean(ViewModel.txtZipCode.Text);
            }
            else
            {
                EMSReport.Zipcode = "0";
            }
            EMSReport.Phone = IncidentMain.Clean(ViewModel.txtHomePhone.Text);
            if (Information.IsDate(ViewModel.mskBirthdate.Text))
            {
                EMSReport.Birthdate = DateTime.Parse(ViewModel.mskBirthdate.Text).ToString("MM/dd/yyyy");
            }
            else
            {
                EMSReport.Birthdate = "";
            }

            EMSReport.FlagDNRO = (byte)ViewModel.chkDNR.CheckState;

            //------------- Save Patient report ---------------

            if (~EMSReport.AddEMSPatient() != 0)
            {
                //get out if record didn't save
                return 0;
            }
            UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                {
                    var ret =

 //*******************************************************************
 // EMS PreExisting Condition Record
 //*******************************************************************
 EMSReport.DeleteEMSPreExistingCondition(ref p1);
                    ViewModel.PatientID = p1;
                    return ret;
                }, ViewModel.PatientID);
            EMSReport.PreExistPatientID = ViewModel.PatientID;
            for (int i = 0; i <= ViewModel.lstPriorMedicalHistory.Items.Count - 1; i++)
            {
                if (ViewModel.lstPriorMedicalHistory.GetSelected(i))
                {
                    EMSReport.PreExistingCondition = ViewModel.lstPriorMedicalHistory.GetItemData(i);
                    EMSReport.AddEMSPreExistingCondition();
                }
            }
            UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                {
                    var ret =


 //*******************************************************************
 // EMS Possible Factors Impacting Care Record
 //*******************************************************************
 EMSReport.DeleteEMSContributingFactor(ref p1);
                    ViewModel.PatientID = p1;
                    return ret;
                }, ViewModel.PatientID);
            EMSReport.CFPatientID = ViewModel.PatientID;
            for (int i = 0; i <= ViewModel.lstPossibleFactors.Items.Count - 1; i++)
            {
                if (ViewModel.lstPossibleFactors.GetSelected(i))
                {
                    EMSReport.EMSContributingFactorCode = ViewModel.lstPossibleFactors.GetItemData(i);
                    EMSReport.AddEMSContributingFactor();
                }
            }


            if (ViewModel.ActionTaken == 7)
            {
                return result;
            }

            //*******************************************************************
            // EMS Patient Exam Record
            //*******************************************************************
            // Get Patient exam info for all but ActionTaken = 7, interfacility transfer
            //       or No Exam (3,4,5)
            EMSReport.ExamPatientID = ViewModel.PatientID;
            if (ViewModel.cboMechCode.SelectedIndex != -1)
            {
                EMSReport.MechCode = ViewModel.cboMechCode.GetItemData(ViewModel.cboMechCode.SelectedIndex);
            }
            else
            {
                EMSReport.MechCode = 0;
            }
            if (ViewModel.cboInjuryType.SelectedIndex != -1 && ViewModel.cboBodyPart.SelectedIndex != -1)
            {
                EMSReport.InjuryType = EMSCodes.GetInjuryTypeCode(ViewModel.cboBodyPart.GetItemData(ViewModel.cboBodyPart
                            .SelectedIndex), ViewModel.cboInjuryType.GetItemData(ViewModel.cboInjuryType.SelectedIndex));
            }
            else
            {
                EMSReport.InjuryType = 0;
            }
            if (ViewModel.cboPrimaryIllness.SelectedIndex != -1)
            {
                EMSReport.PrimaryIllness = ViewModel.cboPrimaryIllness.GetItemData(ViewModel.cboPrimaryIllness.SelectedIndex);
            }
            else
            {
                EMSReport.PrimaryIllness = 0;
            }
            UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                {
                    var ret =
                            EMSReport.DeleteEMSSecondaryIllness(ref p1);
                    ViewModel.PatientID = p1;
                    return ret;
                }, ViewModel.PatientID);
            EMSReport.SecIllPatientID = ViewModel.PatientID;
            for (int i = 0; i <= ViewModel.lstSecondaryIllness.Items.Count - 1; i++)
            {
                if (ViewModel.lstSecondaryIllness.GetSelected(i))
                {
                    EMSReport.SecondaryIllnessCode = ViewModel.lstSecondaryIllness.GetItemData(i);
                    EMSReport.AddEMSSecondaryIllness();
                }
            }
            if (ViewModel.optPupils[0].Checked)
            {
                EMSReport.Pupils = 1; //equal
            }
            else if (ViewModel.optPupils[1].Checked)
            {
                EMSReport.Pupils = 2; //no equal
            }
            else
            {
                EMSReport.Pupils = 0;
            }
            if (ViewModel.optLevelOfConsciouness[0].Checked)
            {
                EMSReport.LevelOfConsciousness = 3; //normal
            }
            else if (ViewModel.optLevelOfConsciouness[1].Checked)
            {
                EMSReport.LevelOfConsciousness = 4; //confused
            }
            else if (ViewModel.optLevelOfConsciouness[2].Checked)
            {
                EMSReport.LevelOfConsciousness = 5; //none
            }
            else
            {
                EMSReport.LevelOfConsciousness = 0;
            }
            if (ViewModel.optRespiratoryEffort[0].Checked)
            {
                EMSReport.RespiratoryEffort = 6; //normal
            }
            else if (ViewModel.optRespiratoryEffort[1].Checked)
            {
                EMSReport.RespiratoryEffort = 7; //labored
            }
            else if (ViewModel.optRespiratoryEffort[2].Checked)
            {
                EMSReport.RespiratoryEffort = 8; // <10, > 30, Intubation
            }
            else
            {
                EMSReport.RespiratoryEffort = 0;
            }
            if (ViewModel.txtExtricationTime.Text != "")
            {
                EMSReport.FlagExtricationRequired = 1;
                EMSReport.ExtricationTime = Convert.ToInt32(Conversion.Val(ViewModel.txtExtricationTime.Text));
            }
            else
            {
                EMSReport.FlagExtricationRequired = 0;
                EMSReport.ExtricationTime = 0;
            }

            //------------- Save Patient Exam record -----------
            if (~EMSReport.AddEMSPatientExam() != 0)
            {
                return 0;
            }

            //*******************************************************************
            // EMS Patient Vitals Record
            //*******************************************************************
            //get patient id first
            if (~ViewModel.NoVitals != 0)
            {
                for (int i = 0; i <= 4; i++)
                {
                    EMSReport.VitalPatientID = ViewModel.PatientID;
                    //Test for some entries
                    if (ViewModel.txtTime[i].Text != "__:__" || ViewModel.cboEyes[i].SelectedIndex != -1 || ViewModel.txtPulse[i].Text != "")
                    {
                        if (ViewModel.txtTime[i].Text != "__:__")
                        {
                            DateWork = DateTime.Parse(ViewModel.lbExamDate.Text).ToString("MM/dd/yyyy");
                            HourWork = DateTime.Parse(ViewModel.lbExamDate.Text).ToString("HH:mm");
                            if (String.CompareOrdinal(ViewModel.txtTime[i].Text, HourWork) < 0)
                            {
                                DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
                            }
                            if (Information.IsDate(DateWork + " " + ViewModel.txtTime[i].Text))
                            {
                                EMSReport.VitalsTime = DateWork + " " + ViewModel.txtTime[i].Text;
                            }
                            else
                            {
                                EMSReport.VitalsTime = "";
                            }
                        }
                        else
                        {
                            EMSReport.VitalsTime = "";
                        }
                        if (ViewModel.txtPulse[i].Text == "")
                        {
                            EMSReport.Pulse = -1;
                        }
                        else
                        {
                            EMSReport.Pulse = Convert.ToInt32(Conversion.Val(ViewModel.txtPulse[i].Text));
                        }
                        if (ViewModel.txtRespiration[i].Text == "")
                        {
                            EMSReport.RespirationRate = -1;
                        }
                        else
                        {
                            EMSReport.RespirationRate = Convert.ToInt32(Conversion.Val(ViewModel.txtRespiration[i].Text));
                        }
                        if (ViewModel.txtSystolic[i].Text == "")
                        {
                            EMSReport.Systolic = -1;
                        }
                        else
                        {
                            EMSReport.Systolic = Convert.ToInt32(Conversion.Val(ViewModel.txtSystolic[i].Text));
                        }
                        if (ViewModel.txtDiastolic[i].Text == "")
                        {
                            EMSReport.Diastolic = -1;
                        }
                        else
                        {
                            EMSReport.Diastolic = Convert.ToInt32(Conversion.Val(ViewModel.txtDiastolic[i].Text));
                        }
                        if (ViewModel.chkPalp[i].CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                        {
                            EMSReport.FlagDiastolicPalp = 1;
                        }
                        else
                        {
                            EMSReport.FlagDiastolicPalp = 0;
                        }
                        if (ViewModel.txtGlucose[i].Text == "")
                        {
                            EMSReport.BloodGlucose = -1;
                        }
                        else
                        {
                            EMSReport.BloodGlucose = Convert.ToInt32(Conversion.Val(ViewModel.txtGlucose[i].Text));
                        }
                        if (ViewModel.txtPulseOxy[i].Text == "")
                        {
                            EMSReport.PulseOxygen = -1;
                        }
                        else
                        {
                            EMSReport.PulseOxygen = Convert.ToInt32(Conversion.Val(ViewModel.txtPulseOxy[i].Text));
                        }
                        if (ViewModel.txtPerOxy[i].Text == "")
                        {
                            EMSReport.PercentOxygen = -1;
                        }
                        else
                        {
                            EMSReport.PercentOxygen = Convert.ToInt32(Conversion.Val(ViewModel.txtPerOxy[i].Text));
                        }
                        if (ViewModel.cboECG[i].SelectedIndex != -1)
                        {
                            EMSReport.ECG = ViewModel.cboECG[i].GetItemData(ViewModel.cboECG[i].SelectedIndex);
                        }
                        else
                        {
                            EMSReport.ECG = 0;
                        }

                        if (ViewModel.cboVitalsPosition[i].SelectedIndex != -1)
                        {
                            EMSReport.VitalsPosition = ViewModel.cboVitalsPosition[i].GetItemData(ViewModel.cboVitalsPosition[i].SelectedIndex);
                        }
                        else
                        {
                            EMSReport.VitalsPosition = 0;
                        }

                        if (ViewModel.cboEyes[i].SelectedIndex != -1)
                        {
                            EMSReport.GCSEyes = ViewModel.cboEyes[i].GetItemData(ViewModel.cboEyes[i].SelectedIndex);
                        }
                        else
                        {
                            EMSReport.GCSEyes = 0;
                        }

                        if (ViewModel.cboVerbal[i].SelectedIndex != -1)
                        {
                            EMSReport.GCSVerbal = ViewModel.cboVerbal[i].GetItemData(ViewModel.cboVerbal[i].SelectedIndex);
                        }
                        else
                        {
                            EMSReport.GCSVerbal = 0;
                        }

                        if (ViewModel.cboMotor[i].SelectedIndex != -1)
                        {
                            EMSReport.GCSMotor = ViewModel.cboMotor[i].GetItemData(ViewModel.cboMotor[i].SelectedIndex);
                        }
                        else
                        {
                            EMSReport.GCSMotor = 0;
                        }

                        //------------- Save Patient Vitals record -----------

                        if (~EMSReport.AddEMSPatientVitals() != 0)
                        {
                            return 0;
                        }
                    }
                }
            }

            //*******************************************************************
            // EMS Patient IV Line Record
            //*******************************************************************
            EMSReport.IVPatientID = ViewModel.PatientID;
            for (int i = 0; i <= 4; i++)
            {
                if (ViewModel.cboGauge[i].SelectedIndex != -1 || ViewModel.cboRoute[i].SelectedIndex != -1 || ViewModel.txtAmount[i].Text != "")
                {
                    if (ViewModel.cboGauge[i].SelectedIndex != -1)
                    {
                        EMSReport.IVGauge = ViewModel.cboGauge[i].GetItemData(ViewModel.cboGauge[i].SelectedIndex);
                    }
                    else
                    {
                        EMSReport.IVGauge = 0;
                    }
                    if (ViewModel.cboRate[i].SelectedIndex != -1)
                    {
                        EMSReport.IVRate = ViewModel.cboRate[i].GetItemData(ViewModel.cboRate[i].SelectedIndex);
                    }
                    else
                    {
                        EMSReport.IVRate = 0;
                    }
                    if (ViewModel.cboRoute[i].SelectedIndex != -1)
                    {
                        EMSReport.IVRoute = ViewModel.cboRoute[i].GetItemData(ViewModel.cboRoute[i].SelectedIndex);
                    }
                    else
                    {
                        EMSReport.IVRoute = 0;
                    }
                    if (ViewModel.cboSite[i].SelectedIndex != -1)
                    {
                        EMSReport.IVSite = ViewModel.cboSite[i].GetItemData(ViewModel.cboSite[i].SelectedIndex);
                    }
                    else
                    {
                        EMSReport.IVSite = 0;
                    }
                    if (ViewModel.txtAmount[i].Text != "")
                    {
                        EMSReport.IVAmount = Convert.ToInt32(Conversion.Val(ViewModel.txtAmount[i].Text));
                    }
                    else
                    {
                        EMSReport.IVAmount = 0;
                    }
                    if (ViewModel.chkSalineLock.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                    {
                        EMSReport.FlagSalineLock = 1;
                    }

                    //------------- Save Patient IV Lines record -----------

                    if (~EMSReport.AddEMSPatientIVLine() != 0)
                    {
                        result = 0;
                    }
                }
            }

            if (ViewModel.chkCPRPerformed.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                EMSReport.CPRPatientID = ViewModel.PatientID;
                if (ViewModel.optArrestToCPR[0].Checked)
                {
                    EMSReport.TimeArrestToCPR = 1;
                }
                else if (ViewModel.optArrestToCPR[1].Checked)
                {
                    EMSReport.TimeArrestToCPR = 2;
                }
                else if (ViewModel.optArrestToCPR[2].Checked)
                {
                    EMSReport.TimeArrestToCPR = 3;
                }
                else if (ViewModel.optArrestToCPR[3].Checked)
                {
                    EMSReport.TimeArrestToCPR = 4;
                }
                else
                {
                    EMSReport.TimeArrestToCPR = 0;
                }
                if (ViewModel.optArrestToALS[0].Checked)
                {
                    EMSReport.TimeArrestToAls = 1;
                }
                else if (ViewModel.optArrestToALS[1].Checked)
                {
                    EMSReport.TimeArrestToAls = 2;
                }
                else if (ViewModel.optArrestToALS[2].Checked)
                {
                    EMSReport.TimeArrestToAls = 3;
                }
                else if (ViewModel.optArrestToALS[3].Checked)
                {
                    EMSReport.TimeArrestToAls = 4;
                }
                else
                {
                    EMSReport.TimeArrestToAls = 0;
                }
                if (ViewModel.optArrestToShock[0].Checked)
                {
                    EMSReport.TimeArrestToShock = 1;
                }
                else if (ViewModel.optArrestToShock[1].Checked)
                {
                    EMSReport.TimeArrestToShock = 2;
                }
                else if (ViewModel.optArrestToShock[2].Checked)
                {
                    EMSReport.TimeArrestToShock = 3;
                }
                else if (ViewModel.optArrestToShock[3].Checked)
                {
                    EMSReport.TimeArrestToShock = 4;
                }
                else
                {
                    EMSReport.TimeArrestToShock = 0;
                }
                if (ViewModel.chkPulseRestored.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                {
                    EMSReport.FlagPulseRestored = ((byte)255);
                }

                //------------- Save CPR record -----------

                if (~EMSReport.AddEMSCPR() != 0)
                {
                    return 0;
                }
            }
            else if (EMSReport.GetEMSCPRPerformerRS(ViewModel.PatientID) != 0)
            {
                EMSReport.CPRPatientID = ViewModel.PatientID;
                if (ViewModel.optArrestToCPR[0].Checked)
                {
                    EMSReport.TimeArrestToCPR = 1;
                }
                else if (ViewModel.optArrestToCPR[1].Checked)
                {
                    EMSReport.TimeArrestToCPR = 2;
                }
                else if (ViewModel.optArrestToCPR[2].Checked)
                {
                    EMSReport.TimeArrestToCPR = 3;
                }
                else if (ViewModel.optArrestToCPR[3].Checked)
                {
                    EMSReport.TimeArrestToCPR = 4;
                }
                else
                {
                    EMSReport.TimeArrestToCPR = 0;
                }
                if (ViewModel.optArrestToALS[0].Checked)
                {
                    EMSReport.TimeArrestToAls = 1;
                }
                else if (ViewModel.optArrestToALS[1].Checked)
                {
                    EMSReport.TimeArrestToAls = 2;
                }
                else if (ViewModel.optArrestToALS[2].Checked)
                {
                    EMSReport.TimeArrestToAls = 3;
                }
                else if (ViewModel.optArrestToALS[3].Checked)
                {
                    EMSReport.TimeArrestToAls = 4;
                }
                else
                {
                    EMSReport.TimeArrestToAls = 0;
                }
                if (ViewModel.optArrestToShock[0].Checked)
                {
                    EMSReport.TimeArrestToShock = 1;
                }
                else if (ViewModel.optArrestToShock[1].Checked)
                {
                    EMSReport.TimeArrestToShock = 2;
                }
                else if (ViewModel.optArrestToShock[2].Checked)
                {
                    EMSReport.TimeArrestToShock = 3;
                }
                else if (ViewModel.optArrestToShock[3].Checked)
                {
                    EMSReport.TimeArrestToShock = 4;
                }
                else
                {
                    EMSReport.TimeArrestToShock = 0;
                }
                if (ViewModel.chkPulseRestored.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                {
                    EMSReport.FlagPulseRestored = ((byte)255);
                }

                //------------- Save CPR record -----------

                if (~EMSReport.AddEMSCPR() != 0)
                {
                    return 0;
                }
            }

            //*******************************************************************
            // EMS CPR Performed By Record
            //*******************************************************************
            // move this code to click event or step next? record written when form is exitted.
            //            If Not cboCPRPerformedBy.ListIndex = -1 Then
            //                EMSReport.CPRPerformedBy = cboCPRPerformedBy.ItemData(cboCPRPerformedBy)
            //            Else
            //                EMSReport.CPRPerformedBy = 0
            //            End If
            //            If chkCPRTrained Then EMSReport.FlagCPRTrained = True
            //            If chkWitnessedArrest Then EMSReport.FlagArrestWitnessed = True

            //*******************************************************************
            // EMS Trauma Record
            //*******************************************************************

            if (ViewModel.TraumaSwitch != 0)
            {
                EMSReport.TraumaPatientID = ViewModel.PatientID;
                if (ViewModel.txtTraumaID.Text != "")
                {
                    EMSReport.TraumaID = ViewModel.txtTraumaID.Text;
                }
                else
                {
                    EMSReport.TraumaID = "0";
                }
                if (ViewModel.cboProtectiveDevice.SelectedIndex != -1)
                {
                    EMSReport.ProtectiveDevice = ViewModel.cboProtectiveDevice.GetItemData(ViewModel.cboProtectiveDevice.SelectedIndex);
                }
                else
                {
                    EMSReport.ProtectiveDevice = 0;
                }
                if (ViewModel.cboPatientLocation.SelectedIndex != -1)
                {
                    EMSReport.TraumaLocation = ViewModel.cboPatientLocation.GetItemData(ViewModel.cboPatientLocation.SelectedIndex);
                }
                else
                {
                    EMSReport.TraumaLocation = 0;
                }
                EMSReport.RevisedTraumaScore = EMSReport.GetRevisedTraumaScore(ViewModel.PatientID);


                //------------- Save Trauma record -----------

                if (~EMSReport.AddEMSPatientTrauma() != 0)
                {
                    return 0;
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =

 //*******************************************************************
 // EMS Trauma Descriptor Record
 //*******************************************************************
 EMSReport.DeleteEMSTraumaDescriptor(ref p1);
                        ViewModel.PatientID = p1;
                        return ret;
                    }, ViewModel.PatientID);
                EMSReport.TraumaDescrPatientID = ViewModel.PatientID;
                for (int i = 0; i <= ViewModel.lstTrauma1.Items.Count - 1; i++)
                {
                    if (ViewModel.lstTrauma1.GetSelected(i))
                    {
                        EMSReport.TraumaType = ViewModel.lstTrauma1.GetItemData(i);
                        EMSReport.AddEMSTraumaDescriptor();
                    }
                }
                for (int i = 0; i <= ViewModel.lstTrauma2.Items.Count - 1; i++)
                {
                    if (ViewModel.lstTrauma2.GetSelected(i))
                    {
                        EMSReport.TraumaType = ViewModel.lstTrauma2.GetItemData(i);
                        EMSReport.AddEMSTraumaDescriptor();
                    }
                }
                for (int i = 0; i <= ViewModel.lstTrauma3.Items.Count - 1; i++)
                {
                    if (ViewModel.lstTrauma3.GetSelected(i))
                    {
                        EMSReport.TraumaType = ViewModel.lstTrauma3.GetItemData(i);
                        EMSReport.AddEMSTraumaDescriptor();
                    }
                }

            }


            return result;
        }

        private void SaveEMSNarration()
        {
            //sub routine for saving  EMS Narration text

            if (ViewModel.rtxNarration.Text == "")
            {
                return;
            }
            TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
            EMSReport.NarrPatientID = ViewModel.PatientID;
            EMSReport.NarrationText = ViewModel.rtxNarration.Text;
            EMSReport.NarrationBy = IncidentMain.Shared.gCurrUser;
            EMSReport.NarrationDate = DateTime.Now.ToString("MM/dd/yyyy");

            if (~EMSReport.AddEMSPatientNarration() != 0)
            {
                ViewManager.ShowMessage("Error Attempting to Add Narration Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void FDCaresBtn_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                TFDIncident.clsEMS EMScl = Container.Resolve<clsEMS>();

                IncidentMain.Shared.gFDCaresIncidentID = ViewModel.CurrIncident;
                IncidentMain.Shared.gFDCaresPatientID = ViewModel.PatientID;
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
                            if (EMScl.GetFDCaresIncident(IncidentMain.Shared.gFDCaresIncidentID) != 0)
                            {
                                if (~EMScl.UpdateFDCaresReferral(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresPatientID, IncidentMain.Shared.gFDCaresComment) != 0)
                                {
                                    ViewManager.ShowMessage("Unable to process FDCares Referral", System.Diagnostics.FileVersionInfo.GetVersionInfo(System
                                        .Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Incident Referred to FDCares", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
                                        Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                            }
                            else
                            {
                                if (~IncidentMain.ProcessFDCaresReferral(IncidentMain.Shared.gFDCaresIncidentID, IncidentMain.Shared.gFDCaresIncidentID) != 0)
                                {
                                    ViewManager.ShowMessage("Unable to process FDCares Referral", System.Diagnostics.FileVersionInfo.GetVersionInfo(System
                                        .Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Incident Referred to FDCares", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.
                                        Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                            }
                            ViewModel.FDCaresBtn.Enabled = false;
                        }
                    });
            }
        }

        //UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

        private void Form_Load()
        {
            //Load EMS Reporting Wizard
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            

            if (ReportLog.GetReportLog(IncidentMain.Shared.gNewReportID) != 0)
            {
                ViewModel.CurrIncident = ReportLog.RLIncidentID;
                ViewModel.ReportLogID = ReportLog.ReportLogID;
            }
            else
            {
                ViewManager.ShowMessage("Error Retrieving ReportLog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
                return;
            }

            if (IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
            {
                ViewModel.lbLocation.Text = IncidentMain.Clean(IncidentCL.Location);
                ViewModel.lbIncidentNo.Text = IncidentMain.Clean(IncidentCL.IncidentNumber);
                ViewModel.lbExamDate.Text = IncidentMain.Clean(DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("MM/dd/yyyy HH:mm"));
                switch (IncidentMain.Clean(IncidentCL.CADInitialType))
                {
                    case "91":
                        ViewModel.DispatchedAs = "A";
                        ViewModel.EMSType = 66;
                        break;
                    case "92":
                        ViewModel.DispatchedAs = "A";
                        ViewModel.EMSType = 67;
                        break;
                    case "93":
                        ViewModel.EMSType = 68;
                        ViewModel.DispatchedAs = "B";
                        break;
                    case "94":
                        ViewModel.EMSType = 69;
                        ViewModel.DispatchedAs = "B";
                        break;
                    default:
                        ViewModel.EMSType = 0;
                        ViewModel.DispatchedAs = "B";
                        break;
                }
                switch (IncidentMain.Clean(IncidentCL.CADFinalType))
                {
                    case "91":
                        ViewModel.LevelOfCare = "A";
                        ViewModel.EMSType = 66;
                        break;
                    case "92":
                        ViewModel.LevelOfCare = "A";
                        ViewModel.EMSType = 67;
                        break;
                    case "93":
                        ViewModel.LevelOfCare = "B";
                        ViewModel.EMSType = 68;
                        break;
                    case "94":
                        ViewModel.LevelOfCare = "B";
                        ViewModel.EMSType = 69;
                        break;
                    default:
                        ViewModel.LevelOfCare = "B";
                        ViewModel.EMSType = 0;
                        break;
                }
            }
            else
            {
                ViewManager.ShowMessage("Error Retrieving Incident Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            ViewModel.lbUnit.Text = IncidentMain.Shared.gWizardUnitID;
            ViewModel.TraumaSwitch = 0;
            ViewModel.CPRSwitch = 0;
            ViewModel.IVPerformed = 0;
            ViewModel.ReportSaved = 0;
            ViewModel.ExtricationPerformed = 0;
            ViewModel.ListsLoaded = 0;
            ViewModel.NoVitals = 0;
            ViewModel.NarrationRequired = 0;
            ViewModel.ReqNarrString = "Describe the Event or Situation Involving Reported Death or Injury";
            ViewModel.ReqNarrString = ViewModel.ReqNarrString + " - Required";
            ViewModel.chkMajTrauma.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.chkCPRPerformed.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.CurrFrame = ViewModel.frmActionTaken;
            ViewModel.CurrFrame.Visible = true;
            FlipImage();
            ViewModel.lbFrameTitle[Convert.ToInt32(Conversion.Val(ViewModel.CurrFrame.Tag.ToString()))].Text = "EMS INCIDENT CONTACT TYPE";

            //Determine Current Patient Report Order for this Unit
            int ReportOrder = ReportLog.GetReportOrder(ViewModel.CurrIncident, ReportLog.ReportType, IncidentMain.Shared.gWizardUnitID);
            switch (ReportOrder)
            {
                case 0:
                    ViewModel.lbReptNumMessage.Visible = false;
                    break;
                case 1:
                    ViewModel.lbReptNumMessage.Text = "First Patient Report";
                    break;
                case 2:
                    ViewModel.lbReptNumMessage.Text = "Second Patient Report";
                    break;
                case 3:
                    ViewModel.lbReptNumMessage.Text = "Third Patient Report";
                    break;
                case 4:
                    ViewModel.lbReptNumMessage.Text = "Forth Patient Report";
                    break;
                case 5:
                    ViewModel.lbReptNumMessage.Text = "Fifth Patient Report";
                    break;
                case 6:
                    ViewModel.lbReptNumMessage.Text = "Sixth Patient Report";
                    break;
                case 7:
                    ViewModel.lbReptNumMessage.Text = "Seventh Patient Report";
                    break;
                case 8:
                    ViewModel.lbReptNumMessage.Text = "Eighth Patient Report";
                    break;
                case 9:
                    ViewModel.lbReptNumMessage.Text = "Nineth Patient Report";
                    break;
                case 10:
                    ViewModel.lbReptNumMessage.Text = "Tenth Patient Report";
                    break;
                case 11:
                    ViewModel.lbReptNumMessage.Text = "Eleventh Patient Report";
                    break;
                case 12:
                    ViewModel.lbReptNumMessage.Text = "Twelfth Patient Report";
                    break;
                case 13:
                    ViewModel.lbReptNumMessage.Text = "Thirteenth Patient Report";
                    break;
            }


            IncidentMain.MoveForm(wzdEms.DefInstance);

            FormatFrame();

        }

        [UpgradeHelpers.Events.Handler]
        internal void lstBLSPersonnel_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {

            int ProcSelect = 0;
            for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSPersonnel.GetSelected(i))
                {
                    ProcSelect = -1;
                    break;
                }
            }
            if (ProcSelect != 0)
            {
                if (ViewModel.cboBLSProcedures.SelectedIndex != -1)
                {
                    ViewModel.cmdAddBLS.Enabled = !ViewModel.txtExtricationTime.BackColor.Equals(IncidentMain.Shared.REQCOLOR);
                }
                else
                {
                    ViewModel.cmdAddBLS.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddBLS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void lstTrauma1_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstTrauma2_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstTrauma3_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void mskBirthdate_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            EditBirthdate();
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void NavButton_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                int Index = this.ViewModel.NavButton.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel)eventSender);
                //Navigation Button Pressed
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsEMS EMSReport = Container.Resolve<clsEMS>();
                using (var async2 = this.Async())
                {

                    switch (Index)
                    {
                        case 0: //Cancel 

                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                    => ViewManager.ShowMessage("Do you wish to Exit Without Saving any Changes?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                            async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                            async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                {
                                    Response = tempNormalized1;
                                });
                            async2.Append(() =>
                                {
                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                    {
                                        if (ViewModel.ReportSaved != 0)
                                        {
                                            //Delete Temp Records
                                            if (~UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                                   {
                                                       var ret = EMSReport.DeleteEMSPatientContact(ref p1);
                                                       ViewModel.PatientID = p1;
                                                       this.Return(() => ret);
                                                       return 0;
                                                   }, ViewModel.PatientID) != 0)
                                            {
                                                ViewManager.ShowMessage("Error Attempting to Remove EMS Patient Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            }
                                        }
                                        IncidentMain.Shared.gWizCancel = -1;
                                        ViewManager.DisposeView(this);
                                    }
                                    else
                                    {
                                        this.Return();
                                        return;
                                    }
                                });
                            break;
                        case 1: //Back 
                            StepBack();
                            break;
                        case 2: //Next 
                            StepNext();
                            break;
                        case 3: //Quit and Save 
                            StepQuit();
                            break;
                        case 4: //Finish 
                            StepFinish();
                            break;
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void optActionTaken_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index = this.ViewModel.optActionTaken.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                ViewModel.NarrationRequired = 0;
                if (ViewModel.optActionTaken[Index].Checked)
                {
                    switch (Index)
                    {
                        case 0:
                            ViewModel.CurrReport = IncidentMain.EXAMONLY; //exam only 

                            ViewModel.ActionTaken = 1;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            break;
                        case 1:
                            ViewModel.CurrReport = IncidentMain.EXAMASSIST; //exam assist only 

                            ViewModel.ActionTaken = 6;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            break;
                        case 2:
                            ViewModel.CurrReport = IncidentMain.EXAMTRANSPORT; //exam assist transport 

                            ViewModel.ActionTaken = 2;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            ViewModel.cboTransportFrom.Enabled = false;
                            ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.DKGRAY;
                            break;
                        case 3:
                            ViewModel.CurrReport = IncidentMain.EXAMASSIST; //refused transport 

                            ViewModel.ActionTaken = 8;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            break;
                        case 4:
                            ViewModel.CurrReport = IncidentMain.NOEXAM; //no exam needed 

                            ViewModel.ActionTaken = 3;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            break;
                        case 5:
                            ViewModel.CurrReport = IncidentMain.NOEXAM; //refused treatment 

                            ViewModel.ActionTaken = 4;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            break;
                        case 6:
                            ViewModel.CurrReport = IncidentMain.NOEXAM; //dead on arrival 

                            ViewModel.ActionTaken = 5;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            ViewModel.NarrationRequired = -1;
                            break;
                        case 7:
                            ViewModel.CurrReport = IncidentMain.INTERFAC; //interfacility transfer 

                            ViewModel.ActionTaken = 7;
                            //enable next button 
                            ViewModel.NavButton[2].Visible = true;
                            ViewModel.cboTransportFrom.Enabled = true;
                            ViewModel.lbTrans[2].ForeColor = IncidentMain.Shared.EMSFONT;
                            break;
                    }
                }

            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optArrestToALS_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optArrestToCPR_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optArrestToShock_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optEMSGender_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optGender_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optLevelOfConsciouness_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optPupils_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optRespiratoryEffort_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optSeverity_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                CheckComplete();
            }
        }




        private void rtxNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.rtxNarration.BackColor.Equals(IncidentMain.Shared.REQCOLOR))
            {
                if (ViewModel.rtxNarration.Text != "")
                {
                    CheckComplete();
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAttempts_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
            if (ViewModel.cboALSProcedures.SelectedIndex != -1)
            {
                if (ViewModel.txtAttempts.Text != "")
                {
                    double dbNumericTemp = 0;
                    ViewModel.cmdAddALS.Enabled = Double.TryParse(ViewModel.txtAttempts.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp);
                }
                else
                {
                    ViewModel.cmdAddALS.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddALS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBBirthdate_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            EditBasicBirthdate();
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtDosage_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
            if (ViewModel.cboMedications.SelectedIndex != -1)
            {
                if (ViewModel.txtDosage.Text != "")
                {
                    double dbNumericTemp = 0;
                    ViewModel.cmdAddMedications.Enabled = Double.TryParse(ViewModel.txtDosage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp);
                }
                else
                {
                    ViewModel.cmdAddMedications.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddMedications.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAge_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtAmount_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtDiastolic_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.txtDiastolic.IndexOf((UpgradeHelpers.BasicViewModels.TextBoxViewModel)eventSender);
            ViewModel.chkPalp[Index].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtExtricationTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();

            int ProcSelect = 0;
            for (int i = 0; i <= ViewModel.lstBLSPersonnel.Items.Count - 1; i++)
            {
                if (ViewModel.lstBLSPersonnel.GetSelected(i))
                {
                    ProcSelect = -1;
                    break;
                }
            }
            if (ProcSelect != 0)
            {
                if (ViewModel.cboBLSProcedures.SelectedIndex != -1)
                {
                    ViewModel.cmdAddBLS.Enabled = !ViewModel.txtExtricationTime.BackColor.Equals(IncidentMain.Shared.REQCOLOR);
                }
                else
                {
                    ViewModel.cmdAddBLS.Enabled = false;
                }
            }
            else
            {
                ViewModel.cmdAddBLS.Enabled = false;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtGlucose_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtIncidentZipcode_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtMileage_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtOtherBLSProcedures_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPatientAge_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPerOxy_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPulse_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPulseOxy_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtRespiration_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSystolic_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTime_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.txtTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel)eventSender);
            if (ViewModel.txtTime[Index].Text == "__:__")
            {
                return;
            }

            if (ViewModel.FirstTime != 0)
            {
                return;
            }

            string HourWork = "", MinWork = "";

            string TimeWork = ViewModel.txtTime[Index].Text;
            TimeWork = Strings.Replace(TimeWork, "_", "0", 1, -1, CompareMethod.Binary);
            int TimeCheck = Convert.ToInt32(Conversion.Val(TimeWork.Substring(0, Math.Min(2, TimeWork.Length))));
            if (TimeCheck > 23)
            {
                if (UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.txtTime[Index]) == 0)
                {
                    ViewModel.txtTime[Index].Text = "__:__";
                    ViewModel.txtTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewManager.SetCurrent(ViewModel.txtTime[Index]);
                }
                else
                {
                    ViewModel.txtTime[Index].Text = "__:__";
                    ViewManager.SetCurrent(ViewModel.txtTime[Index]);
                }
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
                if (UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.txtTime[Index]) == 0)
                {
                    ViewModel.txtTime[Index].Text = "__:__";
                    ViewModel.txtTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewManager.SetCurrent(ViewModel.txtTime[Index]);
                }
                else
                {
                    ViewModel.txtTime[Index].Text = "__:__";
                    ViewManager.SetCurrent(ViewModel.txtTime[Index]);
                }
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
            ViewModel.FirstTime = -1;
            TimeWork = HourWork + ":" + MinWork;
            ViewModel.txtTime[Index].Text = TimeWork;
            ViewModel.FirstTime = 0;


        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTraumaID_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtZipCode_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(ViewModel.txtZipCode.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtZipCode.Text = "";
            }
            CheckComplete();
        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
        }

        public static wzdEms DefInstance
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

        public static wzdEms CreateInstance()
        {
            TFDIncident.wzdEms theInstance = Shared.Container.Resolve<wzdEms>();
            theInstance.Form_Load();
            return theInstance;
        }

        void ReLoadForm(bool addEvents)
        {
        }

        protected override void ExecuteControlsStartup()
        {
            ViewModel.tabPage5.LifeCycleStartup();
            ViewModel.tabPage4.LifeCycleStartup();
            ViewModel.tabPage3.LifeCycleStartup();
            ViewModel.tabPage2.LifeCycleStartup();
            ViewModel.tabPage1.LifeCycleStartup();
            ViewModel.Shape1.LifeCycleStartup();
            ViewModel.frmReportStatus.LifeCycleStartup();
            ViewModel.frmNarration.LifeCycleStartup();
            ViewModel.frmActionTaken.LifeCycleStartup();
            ViewModel.frmExamInfo.LifeCycleStartup();
            ViewModel.frmInjury.LifeCycleStartup();
            ViewModel.frmIllness.LifeCycleStartup();
            ViewModel.frmSeverity.LifeCycleStartup();
            ViewModel.tabVitals.LifeCycleStartup();
            ViewModel.frmProceduresPerformed.LifeCycleStartup();
            ViewModel.frmALSProcedures.LifeCycleStartup();
            ViewModel.frmALSAttempts.LifeCycleStartup();
            ViewModel.frmTrauma.LifeCycleStartup();
            ViewModel.frmNoExamInfo.LifeCycleStartup();
            ViewModel.frmBasicGender.LifeCycleStartup();
            ViewModel.frmPatientInformation.LifeCycleStartup();
            ViewModel.frmGender.LifeCycleStartup();
            ViewModel.frmCPR.LifeCycleStartup();
            ViewModel.Shape2.LifeCycleStartup();
            ViewModel.frmArrestToCPR.LifeCycleStartup();
            ViewModel.frmArrestToALS.LifeCycleStartup();
            ViewModel.frmArrestToShock.LifeCycleStartup();
            ViewModel.frmTreatmentInfo.LifeCycleStartup();
            ViewModel.shpMedications.LifeCycleStartup();
            ViewModel.frmExtrication.LifeCycleStartup();
            ViewModel.frmTransportInfo.LifeCycleStartup();
            ViewModel.frmBaseStationContact.LifeCycleStartup();
            ViewModel.NavBar.LifeCycleStartup();
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
            ViewModel.Shape1.LifeCycleShutdown();
            ViewModel.frmReportStatus.LifeCycleShutdown();
            ViewModel.frmNarration.LifeCycleShutdown();
            ViewModel.frmActionTaken.LifeCycleShutdown();
            ViewModel.frmExamInfo.LifeCycleShutdown();
            ViewModel.frmInjury.LifeCycleShutdown();
            ViewModel.frmIllness.LifeCycleShutdown();
            ViewModel.frmSeverity.LifeCycleShutdown();
            ViewModel.tabVitals.LifeCycleShutdown();
            ViewModel.frmProceduresPerformed.LifeCycleShutdown();
            ViewModel.frmALSProcedures.LifeCycleShutdown();
            ViewModel.frmALSAttempts.LifeCycleShutdown();
            ViewModel.frmTrauma.LifeCycleShutdown();
            ViewModel.frmNoExamInfo.LifeCycleShutdown();
            ViewModel.frmBasicGender.LifeCycleShutdown();
            ViewModel.frmPatientInformation.LifeCycleShutdown();
            ViewModel.frmGender.LifeCycleShutdown();
            ViewModel.frmCPR.LifeCycleShutdown();
            ViewModel.Shape2.LifeCycleShutdown();
            ViewModel.frmArrestToCPR.LifeCycleShutdown();
            ViewModel.frmArrestToALS.LifeCycleShutdown();
            ViewModel.frmArrestToShock.LifeCycleShutdown();
            ViewModel.frmTreatmentInfo.LifeCycleShutdown();
            ViewModel.shpMedications.LifeCycleShutdown();
            ViewModel.frmExtrication.LifeCycleShutdown();
            ViewModel.frmTransportInfo.LifeCycleShutdown();
            ViewModel.frmBaseStationContact.LifeCycleShutdown();
            ViewModel.NavBar.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class wzdEms
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdEmsViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual wzdEms m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }
}