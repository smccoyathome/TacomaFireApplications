using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

    public partial class frmIncident
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmIncidentViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(frmIncident));
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


        private void frmIncident_Activated(System.Object eventSender, System.EventArgs eventArgs)
        {
            if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
            {
                UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
            }
    }

        private int CheckComplete()
        {
            int result = 0;
            result = -1;
            if ( ViewModel.txtXHouseNumber.Text == "")
            {
                ViewModel.txtXHouseNumber.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                result = 0;
        }
        else
        {
                ViewModel.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtXHouseNumber.ForeColor = IncidentMain.Shared.ADDRESSFONT;
            }

            if ( ViewModel.cboXPrefix.SelectedIndex == -1)
            {
                if ( ViewModel.cboXSuffix.SelectedIndex != -1)
                {
                    ViewModel.cboXPrefix.SelectedIndex = -1;
                }
        }
        else
        {
                ViewModel.cboXSuffix.SelectedIndex = -1;
            }

            if ( ViewModel.txtXStreetName.Text == "")
            {
                ViewModel.txtXStreetName.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtXStreetName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                result = 0;
        }
        else
        {
                ViewModel.txtXStreetName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtXStreetName.ForeColor = IncidentMain.Shared.ADDRESSFONT;
            }

            if ( ViewModel.cboCityCode.SelectedIndex == -1)
            {
                ViewModel.cboCityCode.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboCityCode.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                result = 0;
        }
        else
        {
                ViewModel.cboCityCode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboCityCode.ForeColor = IncidentMain.Shared.ADDRESSFONT;
            }
            ViewModel.cmdSave[0].Enabled = result != 0;

            return result;
    }


        private int SaveAddressCorrection(int UType)
        {
            //Save Incident Address correction
            int result = 0;
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

            result = -1;
            IncidentCL.IACIncidentID = ViewModel.CurrIncident;
            IncidentCL.IACHouseNumber = IncidentMain.Clean(ViewModel.txtXHouseNumber.Text);
            if ( ViewModel.cboXPrefix.SelectedIndex != -1)
            {
                IncidentCL.IACPrefix = ViewModel.cboXPrefix.Text;
            }
            else
            {
                IncidentCL.IACPrefix = "";
            }

            IncidentCL.IACStreet = IncidentMain.Clean(ViewModel.txtXStreetName.Text);
            if ( ViewModel.cboXStreetType.SelectedIndex != -1)
            {
                IncidentCL.IACStreetType = ViewModel.cboXStreetType.Text;
            }
            else
            {
                IncidentCL.IACStreetType = "";
            }
            if ( ViewModel.cboXSuffix.SelectedIndex != -1)
            {
                IncidentCL.IACSuffix = ViewModel.cboXSuffix.Text;
            }
            else
            {
                IncidentCL.IACSuffix = "";
            }
            if ( ViewModel.cboCityCode.SelectedIndex == -1)
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
                                ViewModel.CurrReportID = p1;
                                return ret;
                            }, ViewModel.CurrReportID) != 0)
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
                                ViewModel.CurrReportID = p1;
                                return ret;
                            }, ViewModel.CurrReportID) != 0)
                    {
                        ViewManager.ShowMessage("Error Updating ReportLog", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
            }
    }

    return result;
}


        private void LoadAddressCorrection()
        {
            //Load Address Correction Frame
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            string sDisplay = "";
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
        }
            ;

            CommonCodes.GetAddressVerification("S");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboXStreetType.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
        }
            ;
            CommonCodes.GetCityCode();

            while (!CommonCodes.CityCode.EOF)
            {
                sDisplay = Convert.ToString(CommonCodes.CityCode["city_code"]);
                if (Strings.Len(sDisplay) < 3)
                {
                    sDisplay = sDisplay + " ";
                }
                sDisplay = sDisplay + ": " + IncidentMain.Clean(CommonCodes.CityCode["city_name"]);
                ViewModel.cboCityCode.AddItem(sDisplay);
                CommonCodes.CityCode.MoveNext();
        }
            ;

            if (~IncidentCL.GetAddressCorrection(ViewModel.CurrIncident) != 0)
            {
                ViewManager.ShowMessage("Error Attempting to Retrieve Address Correction Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            else
            {
                //Load Address Correction Record
                ViewModel.txtXHouseNumber.Text = IncidentCL.IACHouseNumber;
                if (IncidentCL.IACPrefix != "")
                {
                    for (int i = 0; i <= ViewModel.cboXPrefix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXPrefix.GetListItem(i) == IncidentCL.IACPrefix)
                        {
                            ViewModel.cboXPrefix.SelectedIndex = i;
                            break;
                    }
            }
    }
                ViewModel.txtXStreetName.Text = IncidentCL.IACStreet;

                if (IncidentCL.IACStreetType != "")
                {
                    for (int i = 0; i <= ViewModel.cboXStreetType.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXStreetType.GetListItem(i) == IncidentCL.IACStreetType)
                        {
                            ViewModel.cboXStreetType.SelectedIndex = i;
                            break;
                    }
            }
    }
                if (IncidentCL.IACSuffix != "")
                {
                    for (int i = 0; i <= ViewModel.cboXSuffix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXSuffix.GetListItem(i) == IncidentCL.IACSuffix)
                        {
                            ViewModel.cboXSuffix.SelectedIndex = i;
                            break;
                    }
            }
    }
                for (int i = 0; i <= ViewModel.cboCityCode.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboCityCode.GetListItem(i).StartsWith(IncidentCL.IACCityCode))
                    {
                        ViewModel.cboCityCode.SelectedIndex = i;
                        break;
                }
        }
}

}

        private int RemoveFSCasualty(string EmpID)
        {
            using ( var async1 = this.Async< int>(true) )
            {
                //Delete FSCasualty Record and update Reportlog for
                //De-selected Personnel Injury
                int result = 0;
                TFDIncident.clsCasualty CasualtyCL = Container.Resolve< clsCasualty>();
                TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

                result = -1;
                //Determine if Record Exists
                if (ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.FSCASUALTY) != 0)
                {
                    async1.AppendWhile(() =>
                        {
                            return !ReportLog.MultiLogRS.EOF;
                        }, () =>
                        {
                            using ( var async2 = this.Async() )
                            {
                                if (CasualtyCL.GetFSCasualty(Convert.ToInt32(ReportLog.MultiLogRS["report_reference_id"])) != 0)
                                {
                                    if (CasualtyCL.EmployeeID == EmpID)
                                    {
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>((
                                                ) => ViewManager.ShowMessage("Do you wish to delete existing Fire Service Casualty Report?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                        async2.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                            {
                                                //prompt for permission
                                                Response = tempNormalized1;
                                            });
                                        async2.Append< int>(() =>
                                            {
                                                if (Response == UpgradeHelpers.Helpers.DialogResult.No)
                                                {
                                                    return this.Return< int>(() => 0);
                                                }
                                                else
                                                {
                                                    //Delete Existing FS Casualty Records
                                                    int tempRefParam = CasualtyCL.CasualtyID;
                                                    if (~CasualtyCL.DeleteFireServiceCasualty(ref tempRefParam) != 0)
                                                    {
                                                        ViewManager.ShowMessage("Error Attempting to Remove Fire Service Casualty Report", "TFD Incident Reporting System", UpgradeHelpers.
                                                            Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                        return this.Return< int>(() => 0);
                                                    }
                                                    else
                                                    {
                                                        //Update Reportlog
                                                        int tempRefParam2 = Convert.ToInt32(ReportLog.MultiLogRS["report_log_id"]);
                                                        if (~ReportLog.UpdateStatus(ref tempRefParam2, 0, IncidentMain.NOREPORT) != 0)
                                                        {
                                                            ViewManager.ShowMessage("Error Attempting to Update Reportlog Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                            result = 0;
                                                    }
                                                    else
                                                    {
                                                            return this.Return< int>(() => result);
                                                        }
                                                }
                                        }
                                                return this.Continue< int>();
                                            });
                                    }
                            }
                                async2.Append(() =>
                                    {
                                        ReportLog.MultiLogRS.MoveNext();
                                    });
                                }
                        });
                    async1.Append(() =>
                        {
                            ;
                        });
                                        }

                                        return this.Return< int>(() => result);
            }
        }

        private void LockScreen()
        {
            //Lock up SitFound Frame
            for (int i = 0; i <= 7; i++)
            {
                ViewModel.chkSitFound[i].Enabled = false;
                if (i != 4)
                {
                    //UPGRADE_ISSUE: (2064) ComboBox property cboUnit.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    ViewModel.cboUnit[i].setLocked(true);
                }
        }
            ViewModel.chkCivilianCasualty.Enabled = false;
            ViewModel.txtNumberCivCasulties.Enabled = false;
            ViewModel.txtNumberPatients.Enabled = false;
            for (int i = 0; i <= 2; i++)
            {
                ViewModel.optServiceReport[i].Enabled = false;
            }
            for (int i = 0; i <= 12; i++)
            {
                //UPGRADE_ISSUE: (2064) ComboBox property cboEMSUnit.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboEMSUnit[i].setLocked(true);
            }
            ViewModel.cmdSave[0].Enabled = false;
            ViewModel.cmdSave[1].Enabled = false;
            ViewModel.cmdSave[0].Visible = false;
            ViewModel.cmdSave[1].Visible = false;
            ViewModel.FDCaresBtn.Enabled = false;

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
            ViewModel.cmdSave[0].Enabled = false;
            ViewModel.cmdSave[1].Enabled = false;
            ViewModel.cmdSave[0].Visible = false;
            ViewModel.cmdSave[1].Visible = false;

        }

        private void CheckSitComplete()
        {
            //Toggle Save Button as needed
            if (!ViewModel.frmSituation.Enabled)
            {
                return;
            }
            ViewModel.cmdSave[0].Enabled = true;
            if ( ViewModel.txtNumberCivCasulties.BackColor.Equals(IncidentMain.Shared.REQCOLOR))
            {
                ViewModel.cmdSave[0].Enabled = false;
            }
            if ( ViewModel.txtNumberPatients.BackColor.Equals(IncidentMain.Shared.REQCOLOR))
            {
                ViewModel.cmdSave[0].Enabled = false;
            }

    }

        private int SaveSituationFound(int UpdateType)
        {
            using ( var async1 = this.Async< int>(true) )
            {
                //Save Incident Record Fields,
                //Update Incident Situation Found ReportLog status
                //Delete any existing Reportlogs (other than Unit & Sit Found)
                //Created any new Reportlogs as needed
                int result = 0;
                TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
                TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
                TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();
                TFDIncident.clsEPCR EPCRcl = Container.Resolve< clsEPCR>();
                int x = 0;
                int ExposureCount = 0;
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

                result = -1;
                int PrimarySit = 0;
                int NumberOfPatients = 0;
                int IncidentReportLogID = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, 2);
                if ( ViewModel.frmSituation.Enabled)
                {
                    for (int i = 7; i >= 0; i--)
                    {
                        if ( ViewModel.chkSitFound[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                        {
                            //Create or Update ReportLog record and Set Primary Situation Found
                            switch (i)
                            {
                                case 0:
                                    PrimarySit = 1;  //Fire 
                                    if ( ViewModel.cboUnit[i].Enabled)
                                    {
                                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.FIRE) == (0))
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
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                        }
                        break;
                case 1:
                        PrimarySit = 2;  //Rupture/Explosion 
                        if ( ViewModel.cboUnit[i].Enabled)
                                    {
                                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.RUPTURE) == (0))
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
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                        }
                        break;
                case 2:
                        PrimarySit = 3;  //Hazmat 
                        if ( ViewModel.cboUnit[i].Enabled)
                                    {
                                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.HAZMAT) == (0))
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
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                        }
                        break;
                case 3:
                        PrimarySit = 4;  //Single EMSPatient 
                        if ( ViewModel.cboUnit[i].Enabled)
                                    {
                                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.EMSBASIC) == (0))
                                        {
                                            if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.SIRENPCR) == (0))
                                            {
                                                //Add New
                                                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                                ReportLog.ReportReferenceID = 0;
                                                if ( ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
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
                                    else
                                    {
                                            //Update SirenEPCR info
                                            ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                                if ( ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                                                {
                                                    ReportLog.ReportType = IncidentMain.EMSBASIC;
                                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                                }
                                                if (~ReportLog.UpDate() != 0)
                                                {
                                                    ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                    result = 0;
                                            }
                                    }
                            }
                            else
                            {
                                    //Update
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                            if ( ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                            {
                                                ReportLog.ReportType = IncidentMain.SIRENPCR;
                                                ReportLog.ReportStatus = IncidentMain.COMPLETE;
                                            }
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                        }
                        break;
                case 4:
                        PrimarySit = 4;  //Multiple EMS Patients 
                        for (x = 0; x <= 12; x++)
                        {
                                if ( ViewModel.cboEMSUnit[x].Visible && ViewModel.cboEMSUnit[x].Enabled)
                                        {
                                            if (~ReportLog.GetReportLog(Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbPatient[x].Tag)))) != 0)
                                            {
                                                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                                ReportLog.ReportReferenceID = 0;
                                                if ( ViewModel.chkSirenReport[x].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
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
                                    else
                                    {
                                            //update
                                            ReportLog.ResponsibleUnit = ViewModel.cboEMSUnit[x].Text;
                                                if ( ViewModel.chkSirenReport[x].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                                {
                                                    ReportLog.ReportType = IncidentMain.SIRENPCR;
                                                    ReportLog.ReportStatus = IncidentMain.COMPLETE;
                                                }
                                                else
                                                {
                                                    ReportLog.ReportType = IncidentMain.EMSBASIC;
                                                    ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                                }
                                                if (~ReportLog.UpDate() != 0)
                                                {
                                                    ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                    result = 0;
                                            }
                                    }
                            }
                            else if (Convert.ToString(ViewModel.lbPatient[x].Tag) != "" && !ViewModel.cboEMSUnit[x].Visible)
                                        {
                                            int tempRefParam = Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbPatient[x].Tag)));
                                            if (~ReportLog.UpdateStatus(ref tempRefParam, 0, IncidentMain.NOREPORT) != 0)
                                            {
                                                ViewManager.ShowMessage("Error Removing Situation Found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            }
                                            else
                                            {
                                                ViewModel.lbPatient[x].Tag = "";
                                            }
                                    }
                            }
                            NumberOfPatients = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberPatients.Text));

                                    break;
                            case 5:
                                    PrimarySit = 6;  //Search/Rescue 
                                    if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.SEARCHRESCUE) == (0))
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
                            else
                            {
                                    //Update
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                        if (~ReportLog.UpDate() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                    }
                            }
                            break;
                    case 6:
                            PrimarySit = 5;  //Hazardous Condition 
                            if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.HAZCONDITION) == (0))
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
                            else
                            {
                                    //Update
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                        if (~ReportLog.UpDate() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                    }
                            }
                            break;
                    case 7:
                            PrimarySit = 7;  //False Alarm 
                            if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.FALSEALARM) == (0))
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
                            else
                            {
                                    //Update
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[i].Text;
                                        if (~ReportLog.UpDate() != 0)
                                        {
                                            ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                            result = 0;
                                    }
                            }
                            break;
            }
    }
    else
    {
            //Delete Report
            if ( ViewModel.chkSitFound[i].Enabled)
                            {
                                if (i != 4)
                                {
                                    if (Convert.ToString(ViewModel.chkSitFound[i].Tag) != "")
                                    {
                                        //Inactivate existing Reportlog
                                        int tempRefParam2 = Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.chkSitFound[i].Tag)));
                                        if (~ReportLog.UpdateStatus(ref tempRefParam2, 0, IncidentMain.NOREPORT) != 0)
                                        {
                                            ViewManager.ShowMessage("Error Removing Situation Found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        }
                                        else
                                        {
                                            ViewModel.chkSitFound[i].Tag = "";
                                        }
                                }
                        }
                }
        }
}


if (PrimarySit == 0)
{
        for (int i = 0; i <= 2; i++)
        {
                if ( ViewModel.optServiceReport[i].Checked)
                            {
                                switch (i)
                                {
                                    case 0:
                                        PrimarySit = 9;  //Investigate Only 
                                        if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.INVESTIGATION) == (0))
                                        {
                                            ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                            ReportLog.ReportReferenceID = 0;
                                            ReportLog.ReportType = IncidentMain.INVESTIGATION;
                                            ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                            ReportLog.ResponsibleUnit = ViewModel.cboUnit[8].Text;
                                            if (~ReportLog.AddNew() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[8].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                break;
                        case 1:
                                PrimarySit = 8;  //CleanUp Only 
                                if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.CLEANUP) == (0))
                                {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.CLEANUP;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[9].Text;
                                            if (~ReportLog.AddNew() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[9].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                break;
                        case 2:
                                PrimarySit = 10;  //Standby/Staging 
                                if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.STANDBY) == (0))
                                {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.STANDBY;
                                        ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[10].Text;
                                            if (~ReportLog.AddNew() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation Found", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                else
                                {
                                        //Update
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[10].Text;
                                            if (~ReportLog.UpDate() != 0)
                                            {
                                                ViewManager.ShowMessage("Error Updating Situation found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                result = 0;
                                        }
                                }
                                break;
                }
                break;
        }
        else
        {
                if (Convert.ToString(ViewModel.optServiceReport[i].Tag) != "")
                                {
                                    //Inactivate existing Reportlog
                                    int tempRefParam3 = Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.optServiceReport[i].Tag)));
                                    if (~ReportLog.UpdateStatus(ref tempRefParam3, 0, IncidentMain.NOREPORT) != 0)
                                    {
                                        ViewManager.ShowMessage("Error Removing Situation Found", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    else
                                    {
                                        ViewModel.optServiceReport[i].Tag = "";
                                    }
                            }
                    }
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
                            result = 0;
                    }
            }
    }

    //Check for CivilianCasualty

    if ( ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                {
                    if ( ViewModel.chkCivilianCasualty.Enabled)
                    {
                        if (~ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.CIVILCASUALTY) != 0)
                        {
                            double tempForVar = Conversion.Val(ViewModel.txtNumberCivCasulties.Text);
                            for (int i = 1; i <= tempForVar; i++)
                            {
                                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                ReportLog.ReportReferenceID = 0;
                                ReportLog.ReportType = IncidentMain.CIVILCASUALTY;
                                ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                if ( ViewModel.cboUnit[0].Enabled)
                                {
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[0].Text;
                                }
                                else if ( ViewModel.cboUnit[1].Enabled)
                                {
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[1].Text;
                                }
                                else
                                {
                                    ReportLog.ResponsibleUnit = ViewModel.cboUnit[2].Text;
                                }
                                if (~ReportLog.AddNew() != 0)
                                {
                                    ViewManager.ShowMessage("Error Adding Civilian Casualty Reportlog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    result = 0;
                            }
                    }
            }
    }
    else
    {
            //Existing Reports
            NumberOfPatients = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberCivCasulties.Text));
                        x = 0;
                        if (ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.CIVILCASUALTY) != 0)
                        {

                            while (!ReportLog.MultiLogRS.EOF)
                            {
                                x++;
                                if (x > NumberOfPatients)
                                {
                                    if (Convert.ToDouble(ReportLog.MultiLogRS["report_status_id"]) == IncidentMain.INCOMPLETE)
                                    {
                                        int tempRefParam4 = Convert.ToInt32(ReportLog.MultiLogRS["report_log_id"]);
                                        if (~ReportLog.UpdateStatus(ref tempRefParam4, 0, IncidentMain.NOREPORT) != 0)
                                        {
                                            ViewManager.ShowMessage("Error Removing Civilian Casualty ReportLog Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        }
                                }
                        }
                        ReportLog.MultiLogRS.MoveNext();
                };
                if (x < NumberOfPatients)
                {
                        //Add additional Records
                        for (int i = x; i <= NumberOfPatients; i++)
                        {
                                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                ReportLog.ReportReferenceID = 0;
                                ReportLog.ReportType = IncidentMain.CIVILCASUALTY;
                                ReportLog.ReportStatus = IncidentMain.INCOMPLETE;
                                if ( ViewModel.cboUnit[0].Enabled)
                                    {
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[0].Text;
                                    }
                                    else if ( ViewModel.cboUnit[1].Enabled)
                                    {
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[1].Text;
                                    }
                                    else
                                    {
                                        ReportLog.ResponsibleUnit = ViewModel.cboUnit[2].Text;
                                    }
                                    if (~ReportLog.AddNew() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Adding Civilian Casualty Reportlog Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        result = 0;
                                }
                        }
                }
        }
        else
        {
                            ViewManager.ShowMessage("Error Retrieving Existing Civilian Casualty Reportlog Records", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            result = 0;
                    }
            }
    }
    //Check for Fire Structure Exposures
    if ( ViewModel.chkExposures.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                {
                    ExposureCount = 0;
                    if (ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.FIREEXPOSURE) != 0)
                    {

                        while (!ReportLog.MultiLogRS.EOF)
                        {
                            ExposureCount++;
                            ReportLog.MultiLogRS.MoveNext();
                        };
                    }
                    if (FireReport.GetExposureCount(ViewModel.CurrIncident) != 0)
                    {
                        ExposureCount += FireReport.GetExposureCount(ViewModel.CurrIncident);
                    }
                    if (ExposureCount < Conversion.Val(ViewModel.txtNumberExposures.Text))
                    {
                        //Add new ReportLogRecord
                        for (int i = 1; i <= Conversion.Val(ViewModel.txtNumberExposures.Text) - ExposureCount; i++)
                        {
                            ReportLog.RLIncidentID = ViewModel.CurrIncident;
                            ReportLog.ReportReferenceID = 0;
                            ReportLog.ReportType = IncidentMain.FIREEXPOSURE;
                            ReportLog.ReportStatus = 1;
                            ReportLog.ResponsibleUnit = ViewModel.cboUnit[0].Text;
                            ReportLog.AddNew();
                    }
            }
            else
            {
                    if (ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.FIREEXPOSURE) != 0)
                    {
                            for (int i = 1; i <= ExposureCount - Conversion.Val(ViewModel.txtNumberExposures.Text); i++)
                            {
                                int tempRefParam5 = Convert.ToInt32(ReportLog.MultiLogRS["report_log_id"]);
                                ReportLog.UpdateStatus(ref tempRefParam5, 0, IncidentMain.NOREPORT);
                                ReportLog.MultiLogRS.MoveNext();
                                if (ReportLog.MultiLogRS.EOF)
                                {
                                    break;
                                }
                            }
                    }
            }
    }

    //Check for Incident Address Correction
    if ( ViewModel.chkAddressCorrection.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
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
                            async1.Append< int>(() =>
                                {
                                    if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                    {
                                        UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                            {
                                                var ret =
                                                        IncidentCL.DeleteIncidentAddressCorrection(ref p1);
                                                ViewModel.CurrIncident = p1;
                                                return this.Return< int>(() => ret);
                                            }, ViewModel.CurrIncident);
                                        int tempRefParam6 = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION);
                                        ReportLog.UpdateStatus(ref tempRefParam6, 0, IncidentMain.NOREPORT);
                                }
                                    return this.Continue< int>();
                                });
                        }
                        else
                        {
                            int tempRefParam7 = ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION);
                            ReportLog.UpdateStatus(ref tempRefParam7, 0, IncidentMain.NOREPORT);
                        }
                }
        }

        return this.Return< int>(() => result);
            }
        }


        private int SaveCasualty(string EmpID, string sUnit)
        {
            //Create ReportLog record and FSCasualty Record
            int result = 0;
            TFDIncident.clsCasualty CasualtyCL = Container.Resolve< clsCasualty>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

            result = -1;
            //Determine if Record Exists
            if (ReportLog.GetMultiReportLogs(ViewModel.CurrIncident, IncidentMain.FSCASUALTY) != 0)
            {

                while (!ReportLog.MultiLogRS.EOF)
                {
                    if (CasualtyCL.GetFSCasualty(Convert.ToInt32(ReportLog.MultiLogRS["report_reference_id"])) != 0)
                    {
                        if (CasualtyCL.EmployeeID == EmpID)
                        {
                            //Record already exists for this employee
                            return result;
                        }
                    }
                    ReportLog.MultiLogRS.MoveNext();
                };
            }


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
                ViewManager.ShowMessage("Error Attempting to Create Fire Service Casualty Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            else
            {
                result = -1;
                //-------- Create ReportLog Record -------------
                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                ReportLog.ReportReferenceID = CasualtyCL.CasualtyID;
                ReportLog.ReportType = IncidentMain.FSCASUALTY;
                ReportLog.ReportStatus = IncidentMain.SAVEDINCOMPLETE;
                ReportLog.ResponsibleUnit = sUnit;
                if (~ReportLog.AddNew() != 0)
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Attempting to Create ReportLog Record for FS Casualty", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
        }

        return result;
}

        private SaveUnitReportStruct SaveUnitReport(int iUpdateType)
        {
            using ( var async1 = this.Async< SaveUnitReportStruct>(true) )
            {
                //Save Unit Report and Update ReportLog
                int result = 0;
                TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
                TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
                string DateWork = "", HourWork = "";
                string UnitWork = "";
                int StatusWork = 0;
                //Updates made, save report fields
                if (ReportLog.GetReportLog(ViewModel.CurrReportID) != 0)
                {
                    StatusWork = ReportLog.ReportStatus;
                    if (UnitCL.GetUnitResponse(ViewModel.UnitReportID) != 0)
                    {
                        UnitWork = IncidentMain.Clean(UnitCL.URUnitID);
                        //Update Delay
                        UnitCL.DeleteUnitDelay();
                        for (int x = 0; x <= ViewModel.lstReasonDelay.Items.Count - 1; x++)
                        {
                            if ( ViewModel.lstReasonDelay.GetSelected(x))
                            {
                                UnitCL.UDUnitResponseID = UnitCL.UnitResponseID;
                                UnitCL.Delay = ViewModel.lstReasonDelay.GetItemData(x);
                                UnitCL.AddUnitDelay();
                        }
                }

                //Update Action
                UnitCL.DeleteUnitAction();
                for (int x = 0; x <= ViewModel.lstActionsTaken.Items.Count - 1; x++)
                        {
                            if ( ViewModel.lstActionsTaken.GetSelected(x))
                            {
                                UnitCL.UAUnitResponseID = UnitCL.UnitResponseID;
                                UnitCL.Action = ViewModel.lstActionsTaken.GetItemData(x);
                                UnitCL.AddUnitAction();
                        }
                }

                //Update Times
                for (int x = 1; x <= 5; x++)
                {
                        if ( ViewModel.txtAmendTime[x].Text != "__:__" && !ViewModel.txtAmendTime[x].BackColor.Equals
                                    (IncidentMain.Shared.REQCOLOR) && !ViewModel.cboAmendReason[x].BackColor.Equals(IncidentMain.Shared.REQCOLOR))
                            {
                                if (UnitCL.GetUnitTime(UnitCL.UnitResponseID, Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbActualTime[x].Tag)))) != 0)
                                {
                                    //Existing Record - Update UnitResponseTime
                                    DateWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("MM/dd/yyyy");
                                    HourWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("HH:mm");
                                    if (String.CompareOrdinal(ViewModel.txtAmendTime[x].Text, HourWork) < 0)
                                    {
                                        DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
                                    }

                                    UnitCL.AmendedTime = DateWork + " " + ViewModel.txtAmendTime[x].Text;
                                    UnitCL.ReasonAmended = ViewModel.cboAmendReason[x].GetNullableItemData(ViewModel.cboAmendReason[x].SelectedIndex);
                                    if (~UnitCL.UpdateUnitTimes() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Update Unit Time", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewManager.SetCurrent(ViewModel.txtAmendTime[x]);
                                        return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
                                    }
                            }
                            else
                            {
                                    //Add New Record
                                    UnitCL.UTUnitResponseID = UnitCL.UnitResponseID;
                                    UnitCL.ResponseTime = Convert.ToInt32(Conversion.Val(Convert.ToString(ViewModel.lbActualTime[x].Tag)));
                                    UnitCL.ActualTime = "";
                                    DateWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("MM/dd/yyyy");
                                    HourWork = DateTime.Parse(ViewModel.lbURDate.Text).ToString("HH:mm");
                                    if (String.CompareOrdinal(ViewModel.txtAmendTime[x].Text, HourWork) < 0)
                                    {
                                        DateWork = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Parse(DateWork).AddDays(1));
                                    }

                                    UnitCL.AmendedTime = DateWork + " " + ViewModel.txtAmendTime[x].Text;
                                    UnitCL.ReasonAmended = ViewModel.cboAmendReason[x].GetNullableItemData(ViewModel.cboAmendReason[x].SelectedIndex);
                                    if (~UnitCL.AddUnitTimes() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Add New Unit Time", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewManager.SetCurrent(ViewModel.txtAmendTime[x]);
                                        return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
                                    }
                            }
                    }
            }

            //Update Personnel
            //First Delete all Existing Records the Add Current Selections
            int tempRefParam = UnitCL.UnitResponseID;
            UnitCL.DeleteUnitPersonnel(ref tempRefParam);int i = default(System.Int32);
                        async1.AppendFor(() =>
                            {
                                i = 0;
                            }, () =>
                            {
                                return i <= 6;
                            }, () =>
                            {
                                using ( var async2 = this.Async< SaveUnitReportStruct>() )
                                {
                                    if ( ViewModel.cboPersonnel[i].SelectedIndex != -1 && ViewModel.cboPosition[i].SelectedIndex != -1)
                                    {
                                        //Add UnitResponsePersonnel Record
                                        UnitCL.UPUnitResponseID = UnitCL.UnitResponseID;
                                        UnitCL.EmployeeID = ViewModel.cboPersonnel[i].Text.Substring(Math.Max(ViewModel.cboPersonnel[i].Text.Length - 5, 0));
                                        UnitCL.Position = ViewModel.cboPosition[i].Text;
                                        if ( ViewModel.chkCasualty[i].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                        {
                                            UnitCL.CasualtyFlag = 1;
                                            if (~SaveCasualty(UnitCL.EmployeeID, UnitWork) != 0)
                                            {
                                                //Error Messages Displayed by SaveCasualty function
                                            }
                                        }
                                        else
                                        {
                                            async2.Append<System.Int32>(() => RemoveFSCasualty(UnitCL.EmployeeID));
                                            async2.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
                                            async2.Append<System.Int32>(tempNormalized1 =>
                                                {
                                                    if ( tempNormalized1 != 0)
                                                    {
                                                        UnitCL.CasualtyFlag = 0;
                                                    }
                                                    else
                                                    {
                                                        UnitCL.CasualtyFlag = 1;
                                                    }
                                                });
                                            }
                                        async2.Append< SaveUnitReportStruct>(() =>
                                            {

                                                //No Exposure Info collected at this time
                                                //                    If chkExposure(i).Value = 1 Then
                                                //                        UnitCL.ExposureFlag = 1
                                                //                    Else
                                                UnitCL.ExposureFlag = 0;
                                                //                    End If
                                                if (~UnitCL.AddUnitPersonnel() != 0)
                                                {
                                                    ViewManager.ShowMessage("Error Attempting to Add Unit Personnel", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons
                                                        .OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                    ViewManager.SetCurrent(ViewModel.cboPersonnel[i]);
                                                    return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
                                                }
                                                return this.Continue< SaveUnitReportStruct>();
                                            });
                                    }
                            }
                            }, () =>
                            {
                                i++;
                            });
                        async1.Append< SaveUnitReportStruct>(() =>
                            {

                                if ( ViewModel.cboPersonnel[7].SelectedIndex != -1)
                                {
                                    UnitCL.UPUnitResponseID = UnitCL.UnitResponseID;
                                    UnitCL.EmployeeID = ViewModel.cboPersonnel[7].Text.Substring(Math.Max(ViewModel.cboPersonnel[7].Text.Length - 5, 0));
                                    UnitCL.Position = "NOTOP";
                                    if ( ViewModel.chkCasualty[7].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                    {
                                        UnitCL.CasualtyFlag = 1;
                                    }
                                    else
                                    {
                                        UnitCL.CasualtyFlag = 0;
                                    }

                                    //No Exposure Info collected at this time
                                    //                If chkExposure(6).Value = 1 Then
                                    //                    UnitCL.ExposureFlag = 1
                                    //                Else
                                    UnitCL.ExposureFlag = 0;
                                    //                End If
                                    if (~UnitCL.AddUnitPersonnel() != 0)
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Add Unit Personnel", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewManager.SetCurrent(ViewModel.cboPersonnel[7]);
                                        return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
                                    }
                            }

                            //Update UnitResponse Record
                            UnitCL.UnitNarrative = ViewModel.rtxUnitNarration.Text;
                                if (UnitCL.UpdateUnitResponse() != 0)
                                {
                                    result = -1;
                                }
                                else
                                {
                                    result = 0;
                                    ViewManager.ShowMessage("Error Attempting to Save Unit Response Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
                                }

                                //Update ReportLog
                                if (IncidentMain.Shared.gWizardSecurity == IncidentMain.BATTALIONCHIEF)
                                {
                                    if (UnitWork == "182" || UnitWork == "181" || UnitWork == "183")
                                    {
                                        //Do nothing BC reporting on own unit
                                    }
                                    else
                                    {
                                        iUpdateType = StatusWork; //- leave status as it was found
                                    }
                                }
                                else if (IncidentMain.Shared.gWizardSecurity == IncidentMain.ADMINISTRATOR)
                                {
                                    //Keep current save status
                                    iUpdateType = StatusWork; //- leave status as it was found
                                }

                                if ( UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                                        {
                                            int ret = ReportLog.UpdateStatus(ref p1, ViewModel.UnitReportID, iUpdateType);
                                            ViewModel.CurrReportID = p1;
                                            return this.Return< int>(() => ret);
                                        }, ViewModel.CurrReportID) != 0)
                                {
                                    result = -1;
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error updating ReportLog Status", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    result = 0;
                            }
                                return this.Continue< SaveUnitReportStruct>();
                            });
                    }
                    else
                    {
                        ViewManager.ShowMessage("Unable to retrieve UnitResponse record, Update failed", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
            }
            else
            {
                    ViewManager.ShowMessage("Unable to retrieve ReportLog record, Update failed", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }

                return this.Return< SaveUnitReportStruct>(() => new TFDIncident.frmIncident.SaveUnitReportStruct() { returnValue = result, iUpdateType = iUpdateType, });
            }
        }

        private void LoadUnit()
        {
            //Load Unit Response Report frame
            //with data for Unit Response passed from Main Application
            TFDIncident.clsUnit UnitRes = Container.Resolve< clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
            int x = 0;
            string sList = "";
            string CurrUnit = "";

            if (~ReportLog.GetReportLog(ViewModel.CurrReportID) != 0)
            {
                //Unable to retrieve ReportLog record
                ViewManager.ShowMessage("Error Retrieving Unit Response Reportlog record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }
            else
            {
                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                ViewModel.UnitReportID = Convert.ToInt32(IncidentMain.GetVal(ReportLog.ReportReferenceID));
                CurrUnit = ReportLog.ResponsibleUnit;
                IncidentCL.GetIncident(ViewModel.CurrIncident);
        }

            if ( ViewModel.UnitReportID == 0)
            {
                //No Reference to Unit Response Report found in ReportLog
                ViewManager.ShowMessage("Error Retrieving Unit Response Reportlog record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }
            else if (~UnitRes.GetUnitResponse(ViewModel.UnitReportID) != 0)
            {
                //Unable to retrieve UnitResponse record
                ViewManager.ShowMessage("Error Retrieving Unit Response record", "TFD Unit Response Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
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
            //Retreive Unit Action & Delay Records
            if (UnitRes.GetUnitActionRS(ViewModel.UnitReportID) != 0)
            {

                while (!UnitRes.UnitAction.EOF)
                {
                    for (int i = 0; i <= ViewModel.lstActionsTaken.Items.Count - 1; i++)
                    {
                        if (Convert.ToDouble(UnitRes.UnitAction["unit_action_code"]) == ViewModel.lstActionsTaken.GetItemData(i))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstActionsTaken, i, true);
                            break;
                    }
            }
            UnitRes.UnitAction.MoveNext();
    };
}
            if (UnitRes.GetUnitDelayRS(ViewModel.UnitReportID) != 0)
            {

                while (!UnitRes.UnitDelay.EOF)
                {
                    for (int i = 0; i <= ViewModel.lstReasonDelay.Items.Count - 1; i++)
                    {
                        if (Convert.ToDouble(UnitRes.UnitDelay["delay_code"]) == ViewModel.lstReasonDelay.GetItemData(i))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstReasonDelay, i, true);
                            break;
                    }
            }
            UnitRes.UnitDelay.MoveNext();
    };
}

            //Unit Personnel Fields
            //Load Combo and Listboxes
            for (int i = 0; i <= 7; i++)
            {
                ViewModel.cboPersonnel[i].Items.Clear();
                if (i < 7)
                {
                    ViewModel.cboPosition[i].Items.Clear();
                    ViewModel.chkCasualty[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                }
        }
            //Operations Staff
            PersonnelCL.GetOperationsList();
            if (!PersonnelCL.OperationsList.EOF)
            {

                while (!PersonnelCL.OperationsList.EOF)
                {
                    sList = IncidentMain.Clean(PersonnelCL.OperationsList["name_full"]) + " :" + Convert.ToString(PersonnelCL.OperationsList["employee_id"]);
                    for (int i = 0; i <= 6; i++)
                    {
                        ViewModel.cboPersonnel[i].AddItem(sList);
                    }
                    PersonnelCL.OperationsList.MoveNext();
            };
    }

            if (PersonnelCL.GetPositionList(IncidentMain.Shared.gCurrUnit) != 0)
            {
                if (!PersonnelCL.PositionList.EOF)
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
}
else
{
        PersonnelCL.GetPositionListAll();
        if (!PersonnelCL.PositionList.EOF)
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

            for (int i = 0; i <= 7; i++)
            {
                ViewModel.cboPersonnel[i].SelectedIndex = -1;
                if (i < 7)
                {
                    ViewModel.cboPosition[i].SelectedIndex = -1;
                }
        }

            if (UnitRes.GetUnitPersonnelRS(ViewModel.UnitReportID) != 0)
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
                            if ( ViewModel.cboPersonnel[x].GetListItem(i).Substring(Math.Max(ViewModel.cboPersonnel[x].GetListItem(i).Length - 5, 0)) == Convert.ToString(UnitRes.UnitPersonnel["employee_id"]))
                            {
                                ViewModel.cboPersonnel[x].SelectedIndex = i;
                                ViewModel.cboPersonnel[x].Visible = true;
                                ViewModel.cboPosition[x].Visible = true;
                                ViewModel.cmdClearPerson[x].Visible = true;
                                ViewModel.chkCasualty[x].Visible = true;
                                if (x == 4)
                                {
                                    ViewModel.cmdAddStaff.Visible = false;
                                }
                                //                       chkExposure(x).Visible = True
                                break;
                        }
                }
                for (int i = 0; i <= ViewModel.cboPosition[x].Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboPosition[x].GetListItem(i) == IncidentMain.Clean(UnitRes.UnitPersonnel["position"]))
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
                            if ( ViewModel.cboPersonnel[7].Text.Substring(Math.Max(ViewModel.cboPersonnel[7].Text.Length - 5, 0)) == Convert.ToString(UnitRes.UnitPersonnel["employee_id"]))
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
                    UnitRes.UnitPersonnel.MoveNext();
                    x++;
                //Make sure that Unit Staff Array is not exceeded
                //            If X > 4 Then
                //                MsgBox "Unit Staff Exceeded 5 - Unable to display all Unit Staffing", vbCritical, "Incident Report System"
                //                Exit Do
                //            End If
            };
    }
    else
    {
                ViewManager.ShowMessage("No Unit Staffing Available", "Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
            }

            //Unit Times
            for (int i = 0; i <= 5; i++)
            {
                ViewModel.lbActualTime[i].Text = "";
            }
            ViewModel.lbURDate.Text = DateTime.Parse(IncidentCL.DateIncidentCreated).ToString("MM/dd/yyyy HH:mm");

            if (UnitRes.GetUnitTimesRS(ViewModel.UnitReportID) != 0)
            {

                while (!UnitRes.UnitTimes.EOF)
                {
                    switch (Convert.ToInt32(UnitRes.UnitTimes["response_time_code"]))
                    {
                        case 3:  //Dispatch 

                            ViewModel.lbURDate.Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("MM/dd/yyyy HH:mm");
                            ViewModel.lbActualTime[0].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            break;
                    case 4:  //Enroute 

                            ViewModel.lbActualTime[1].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                            if (!Convert.IsDBNull(UnitRes.UnitTimes["amended_time"]))
                            {
                                ViewModel.txtAmendTime[1].Text = Convert.ToDateTime(UnitRes.UnitTimes["amended_time"]).ToString("HH:mm");
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(UnitRes.UnitTimes["reason_amended_code"]))
                                {
                                    for (int i = 0; i <= ViewModel.cboAmendReason[1].Items.Count - 1; i++)
                                    {
                                        if ( ViewModel.cboAmendReason[1].GetItemData(i) == Convert.ToDouble(UnitRes.UnitTimes["reason_amended_code"]))
                                        {
                                            ViewModel.cboAmendReason[1].SelectedIndex = i;
                                            break;
                                    }
                            }
                    }
            }
                            break;
                    case 5:  //Onscene 

                            ViewModel.lbActualTime[2].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                            if (!Convert.IsDBNull(UnitRes.UnitTimes["amended_time"]))
                            {
                                ViewModel.txtAmendTime[2].Text = Convert.ToDateTime(UnitRes.UnitTimes["amended_time"]).ToString("HH:mm");
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(UnitRes.UnitTimes["reason_amended_code"]))
                                {
                                    for (int i = 0; i <= ViewModel.cboAmendReason[2].Items.Count - 1; i++)
                                    {
                                        if ( ViewModel.cboAmendReason[2].GetItemData(i) == Convert.ToDouble(UnitRes.UnitTimes["reason_amended_code"]))
                                        {
                                            ViewModel.cboAmendReason[2].SelectedIndex = i;
                                            break;
                                    }
                            }
                    }
            }
                            break;
                    case 6:  //Transport 

                            ViewModel.lbActualTime[3].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                            if (!Convert.IsDBNull(UnitRes.UnitTimes["amended_time"]))
                            {
                                ViewModel.txtAmendTime[3].Text = Convert.ToDateTime(UnitRes.UnitTimes["amended_time"]).ToString("HH:mm");
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(UnitRes.UnitTimes["reason_amended_code"]))
                                {
                                    for (int i = 0; i <= ViewModel.cboAmendReason[3].Items.Count - 1; i++)
                                    {
                                        if ( ViewModel.cboAmendReason[3].GetItemData(i) == Convert.ToDouble(UnitRes.UnitTimes["reason_amended_code"]))
                                        {
                                            ViewModel.cboAmendReason[3].SelectedIndex = i;
                                            break;
                                    }
                            }
                    }
            }
                            break;
                    case 7:  //Transport Complete 

                            ViewModel.lbActualTime[4].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                            if (!Convert.IsDBNull(UnitRes.UnitTimes["amended_time"]))
                            {
                                ViewModel.txtAmendTime[4].Text = Convert.ToDateTime(UnitRes.UnitTimes["amended_time"]).ToString("HH:mm");
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(UnitRes.UnitTimes["reason_amended_code"]))
                                {
                                    for (int i = 0; i <= ViewModel.cboAmendReason[4].Items.Count - 1; i++)
                                    {
                                        if ( ViewModel.cboAmendReason[4].GetItemData(i) == Convert.ToDouble(UnitRes.UnitTimes["reason_amended_code"]))
                                        {
                                            ViewModel.cboAmendReason[4].SelectedIndex = i;
                                            break;
                                    }
                            }
                    }
            }
                            break;
                    case 8:
                            ViewModel.lbActualTime[5].Text = Convert.ToDateTime(UnitRes.UnitTimes["actual_time"]).ToString("HH:mm");
                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx 
                            if (!Convert.IsDBNull(UnitRes.UnitTimes["amended_time"]))
                            {
                                ViewModel.txtAmendTime[5].Text = Convert.ToDateTime(UnitRes.UnitTimes["amended_time"]).ToString("HH:mm");
                                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                                if (!Convert.IsDBNull(UnitRes.UnitTimes["reason_amended_code"]))
                                {
                                    for (int i = 0; i <= ViewModel.cboAmendReason[5].Items.Count - 1; i++)
                                    {
                                        if ( ViewModel.cboAmendReason[5].GetItemData(i) == Convert.ToDouble(UnitRes.UnitTimes["reason_amended_code"]))
                                        {
                                            ViewModel.cboAmendReason[5].SelectedIndex = i;
                                            break;
                                    }
                            }
                    }
            }
                            break;
            }
            UnitRes.UnitTimes.MoveNext();
    };
    if (!IncidentMain.Shared.gCurrUnit.StartsWith("R"))
    {
            if ( ViewModel.lbActualTime[3].Text == "")
                    {
                        ViewModel.txtAmendTime[3].Enabled = false;
                        ViewModel.cboAmendReason[3].Enabled = false;
                    }
                    if ( ViewModel.lbActualTime[4].Text == "")
                    {
                        ViewModel.txtAmendTime[4].Enabled = false;
                        ViewModel.cboAmendReason[4].Enabled = false;
                    }
            }
    }
    else
    {
                ViewManager.ShowMessage("No Unit Response Times Available", "Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
            }
            if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
            {
                LockUnitScreen();
            }
    }

        private void LoadSitFound()
        {
            //Load Form Controls for Situation Found Frame
            TFDIncident.clsUnit UnitCL = Container.Resolve< clsUnit>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            TFDIncident.clsEPCR EPCR = Container.Resolve< clsEPCR>();
            TFDIncident.clsEMS EMScl = Container.Resolve< clsEMS>();
            string RespUnit = "";
            int EMSCount = 0;
            int CivCount = 0;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            ViewModel.DontRespond = -1;
            ViewModel.MinPatients = 0;
            ViewModel.MinCivCasualty = 0;
            ViewModel.MinExposures = 0;
            for (int i = 0; i <= 10; i++)
            {
                if (i != 4)
                {
                    ViewModel.cboUnit[i].Items.Clear();
                }
        }
            for (int i = 0; i <= 7; i++)
            {
                ViewModel.chkSitFound[i].Tag = "";
            }
            for (int i = 0; i <= 2; i++)
            {
                ViewModel.optServiceReport[i].Tag = "";
            }
            for (int i = 0; i <= 12; i++)
            {
                ViewModel.cboEMSUnit[i].Items.Clear();
                ViewModel.lbPatient[i].Tag = "";
                ViewModel.chkSirenReport[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            }
            if (UnitCL.GetIncidentTFDUnitResponses(ViewModel.CurrIncident) != 0)
            {

                while (!UnitCL.UnitResponse.EOF)
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        if (i != 4)
                        {
                            ViewModel.cboUnit[i].AddItem(IncidentMain.Clean(UnitCL.UnitResponse["tfd_unit"]));
                        }
                }
                for (int i = 0; i <= 12; i++)
                {
                        ViewModel.cboEMSUnit[i].AddItem(IncidentMain.Clean(UnitCL.UnitResponse["tfd_unit"]));
                    }
                    UnitCL.UnitResponse.MoveNext();
            };
    }
    else
    {
                ViewManager.ShowMessage("Error Retrieving Dispatched Units", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }


            //Load Clearing Unit as default choice
            if (ReportLog.GetReportLog(ViewModel.CurrReportID) != 0)
            {
                RespUnit = IncidentMain.Clean(ReportLog.ResponsibleUnit);
                for (int x = 0; x <= 10; x++)
                {
                    if (x != 4)
                    {
                        for (int i = 0; i <= ViewModel.cboUnit[x].Items.Count - 1; i++)
                        {
                            ViewModel.cboUnit[x].SelectedIndex = i;
                            if ( ViewModel.cboUnit[x].Text == RespUnit)
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
                        if ( ViewModel.cboEMSUnit[x].Text == RespUnit)
                        {
                            break;
                        }
                }
        }
        EMSCount = 0;
        CivCount = 0;
                ViewModel.TotalExposures = 0;
                ReportLog.GetReportLogRS(ViewModel.CurrIncident);

                while (!ReportLog.ReportLogRS.EOF)
                {
                    switch (Convert.ToInt32(ReportLog.ReportLogRS["ReportType"]))
                    {
                        case IncidentMain.FIRE:
                        case IncidentMain.FIRESTRUCTURE:
                        case IncidentMain.FIREMOBILE:
                        case IncidentMain.FIREOUTSIDE:
                            ViewModel.chkSitFound[0].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[0].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            ViewModel.chkCivilianCasualty.Enabled = true;
                            ViewModel.chkExposures.Enabled = true;
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[0].Enabled = false;
                                ViewModel.cboUnit[0].Enabled = false;
                                ViewModel.cmdUnlock[0].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                                //                        cmdUnlock(9).Visible = True
                            }
                            else
                            {
                                ViewModel.chkSitFound[0].Enabled = true;
                                ViewModel.cboUnit[0].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[0].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[0].SelectedIndex = i;
                                if ( ViewModel.cboUnit[0].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            if (Convert.ToDouble(ReportLog.ReportLogRS["ReportType"]) == IncidentMain.FIRESTRUCTURE)
                            {
                                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                if (FireReport.GetFireStructure(Convert.ToInt32(IncidentMain.GetVal(ReportLog.ReportLogRS["report_reference_id"]))) != 0)
                                {
                                    if (FireReport.FlagExposure != 0)
                                    {
                                        ViewModel.chkExposures.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                        ViewModel.chkExposures.Enabled = false;
                                        ViewModel.txtNumberExposures.Visible = true;
                                        ViewModel.txtNumberExposures.Text = (Conversion.Val(ViewModel.txtNumberExposures.Text) + 1).ToString();
                                        (ViewModel.TotalExposures)++;
                                        (ViewModel.MinExposures)++;
                                    }
                            }
                    }
                            break;
                    case IncidentMain.FIREEXPOSURE:
                            ViewModel.chkExposures.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.txtNumberExposures.Visible = true;
                            ViewModel.txtNumberExposures.Text = (Conversion.Val(ViewModel.txtNumberExposures.Text) + 1).ToString();
                            (ViewModel.TotalExposures)++;

                            break;
                    case IncidentMain.RUPTURE:
                    case IncidentMain.RUPTURESTRUCTURE:
                    case IncidentMain.RUPTUREMOBILE:
                    case IncidentMain.RUPTUREOUTSIDE:
                            ViewModel.chkSitFound[1].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[1].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            ViewModel.chkCivilianCasualty.Enabled = true;
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[1].Enabled = false;
                                ViewModel.cboUnit[1].Enabled = false;
                                ViewModel.cmdUnlock[1].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                                //                        cmdUnlock(9).Visible = True
                            }
                            else
                            {
                                ViewModel.chkSitFound[1].Enabled = true;
                                ViewModel.cboUnit[1].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[1].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[1].SelectedIndex = i;
                                if ( ViewModel.cboUnit[1].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.HAZMAT:
                    case IncidentMain.HAZMATFIXED:
                    case IncidentMain.HAZMATMOBILE:
                    case IncidentMain.HAZMATDL:
                            ViewModel.chkSitFound[2].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[2].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            ViewModel.chkCivilianCasualty.Enabled = true;
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[2].Enabled = false;
                                ViewModel.cboUnit[2].Enabled = false;
                                ViewModel.cmdUnlock[2].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                                //                        cmdUnlock(9).Visible = True
                            }
                            else
                            {
                                ViewModel.chkSitFound[2].Enabled = true;
                                ViewModel.cboUnit[2].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[2].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[2].SelectedIndex = i;
                                if ( ViewModel.cboUnit[2].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.EMSBASIC:
                    case IncidentMain.SIRENPCR:
                            EMSCount++;
                            if (EMSCount > 1)
                            {
                                if ( ViewModel.chkSitFound[3].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                {
                                    ViewModel.chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                                    ViewModel.frmMultiEMS.Visible = true;
                                    ViewModel.lbEMSTitle.Visible = true;
                                    ViewModel.lbSirenTitle.Visible = true;
                                    ViewModel.cboEMSUnit[0].Visible = true;
                                    ViewModel.lbPatient[0].Visible = true;
                                    ViewModel.chkSirenReport[0].Visible = true;
                                    ViewModel.lbPatient[0].Tag = Convert.ToString(ViewModel.chkSitFound[3].Tag);
                                    if ( ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                    {
                                        ViewModel.chkSirenReport[0].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                        ViewModel.chkSirenSingle.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                                    }
                                    ViewModel.chkSitFound[4].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                    if (!ViewModel.chkSitFound[3].Enabled)
                                    {
                                        ViewModel.chkSitFound[4].Enabled = false;
                                        ViewModel.cboEMSUnit[0].Enabled = false;
                                        ViewModel.cmdEMSUnlock[0].Visible = true;
                                        ViewModel.cmdUnlock[3].Visible = false;
                                    }
                                    else
                                    {
                                        ViewModel.chkSitFound[3].Enabled = false;
                                        ViewModel.cboUnit[3].Enabled = false;
                                        ViewModel.chkSirenSingle.Enabled = false;
                                    }
                                    for (int i = 0; i <= ViewModel.cboEMSUnit[0].Items.Count - 1; i++)
                                    {
                                        ViewModel.cboEMSUnit[0].SelectedIndex = i;
                                        if ( ViewModel.cboEMSUnit[0].Text == ViewModel.cboUnit[3].Text)
                                        {
                                            break;
                                        }
                                }
                        }
                                ViewModel.cboEMSUnit[EMSCount - 1].Visible = true;
                                ViewModel.lbPatient[EMSCount - 1].Visible = true;
                                ViewModel.chkSirenReport[EMSCount - 1].Visible = true;
                                ViewModel.lbPatient[EMSCount - 1].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                                for (int i = 0; i <= ViewModel.cboEMSUnit[EMSCount - 1].Items.Count - 1; i++)
                                {
                                    ViewModel.cboEMSUnit[EMSCount - 1].SelectedIndex = i;
                                    if ( ViewModel.cboEMSUnit[EMSCount - 1].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                    {
                                        break;
                                    }
                            }
                            if (Convert.ToDouble(ReportLog.ReportLogRS["ReportType"]) == IncidentMain.SIRENPCR)
                            {
                                    ViewModel.chkSirenReport[EMSCount - 1].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                    ViewModel.cboEMSUnit[EMSCount - 1].Enabled = true;
                                    (ViewModel.MinPatients)++;
                                }
                                else
                                {
                                    if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                                    {
                                        ViewModel.cboEMSUnit[EMSCount - 1].Enabled = false;
                                        ViewModel.cmdEMSUnlock[EMSCount - 1].Visible = true;
                                        ViewModel.chkSitFound[4].Enabled = false;
                                        (ViewModel.MinPatients)++;
                                    }
                                    else
                                    {
                                        ViewModel.cboEMSUnit[EMSCount - 1].Enabled = true;
                                    }
                            }
                                ViewModel.txtNumberPatients.Text = EMSCount.ToString();
                                //UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                                ViewModel.txtNumberPatients.SelectionLength = Marshal.SizeOf(EMSCount);
                                ViewModel.txtNumberPatients.SelectionStart = 1;
                                ViewModel.txtNumberPatients.Enabled = true;

                            }
                            else
                            {
                                //1st Patient
                                ViewModel.chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                ViewModel.chkSitFound[3].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                                if (Convert.ToDouble(ReportLog.ReportLogRS["ReportType"]) == IncidentMain.SIRENPCR)
                                {
                                    ViewModel.chkSirenSingle.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                    (ViewModel.MinPatients)++;
                                    ViewModel.chkSitFound[3].Enabled = true;
                                    ViewModel.cboUnit[3].Enabled = true;
                                }
                                else
                                {
                                    if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                                    {
                                        ViewModel.chkSitFound[3].Enabled = false;
                                        ViewModel.cboUnit[3].Enabled = false;
                                        ViewModel.cmdUnlock[3].Visible = true;
                                        ViewModel.frmServiceSit.Enabled = false;
                                        (ViewModel.MinPatients)++;
                                    }
                                    else
                                    {
                                        ViewModel.chkSitFound[3].Enabled = true;
                                        ViewModel.cboUnit[3].Enabled = true;
                                    }
                            }
                                for (int i = 0; i <= ViewModel.cboUnit[3].Items.Count - 1; i++)
                                {
                                    if ( ViewModel.cboUnit[3].GetListItem(i) == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                    {
                                        ViewModel.cboUnit[3].SelectedIndex = i;
                                        break;
                                }
                        }
                }

                break;
        case IncidentMain.SEARCHRESCUE:
                            ViewModel.chkSitFound[5].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[5].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[5].Enabled = false;
                                ViewModel.cboUnit[5].Enabled = false;
                                ViewModel.cmdUnlock[5].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                            }
                            else
                            {
                                ViewModel.chkSitFound[5].Enabled = true;
                                ViewModel.cboUnit[5].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[5].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[5].SelectedIndex = i;
                                if ( ViewModel.cboUnit[5].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.HAZCONDITION:
                            ViewModel.chkSitFound[6].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[6].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[6].Enabled = false;
                                ViewModel.cboUnit[6].Enabled = false;
                                ViewModel.cmdUnlock[6].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                            }
                            else
                            {
                                ViewModel.chkSitFound[6].Enabled = true;
                                ViewModel.cboUnit[6].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[6].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[6].SelectedIndex = i;
                                if ( ViewModel.cboUnit[6].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.FALSEALARM:
                            ViewModel.chkSitFound[7].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.chkSitFound[7].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkSitFound[7].Enabled = false;
                                ViewModel.cboUnit[7].Enabled = false;
                                ViewModel.cmdUnlock[7].Visible = true;
                                ViewModel.frmServiceSit.Enabled = false;
                            }
                            else
                            {
                                ViewModel.chkSitFound[7].Enabled = true;
                                ViewModel.cboUnit[7].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[7].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[7].SelectedIndex = i;
                                if ( ViewModel.cboUnit[7].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.INVESTIGATION:
                            ViewModel.optServiceReport[0].Checked = true;
                            ViewModel.optServiceReport[0].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.frmSituation.Enabled = false;
                                ViewModel.cmdSave[0].Enabled = false;
                                ViewModel.cmdUnlock[8].Visible = true;
                            }
                            else
                            {
                                ViewModel.cboUnit[8].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[8].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[8].SelectedIndex = i;
                                if ( ViewModel.cboUnit[8].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.CLEANUP:
                            ViewModel.optServiceReport[1].Checked = true;
                            ViewModel.optServiceReport[1].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.frmSituation.Enabled = false;
                                ViewModel.cmdSave[0].Enabled = false;
                                ViewModel.cmdUnlock[9].Visible = true;
                            }
                            else
                            {
                                ViewModel.cboUnit[9].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[9].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[9].SelectedIndex = i;
                                if ( ViewModel.cboUnit[9].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.STANDBY:
                            ViewModel.optServiceReport[2].Checked = true;
                            ViewModel.optServiceReport[2].Tag = Convert.ToString(ReportLog.ReportLogRS["report_log_id"]);
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) == IncidentMain.COMPLETE)
                            {
                                ViewModel.frmSituation.Enabled = false;
                                ViewModel.cmdSave[0].Enabled = false;
                                ViewModel.cmdUnlock[10].Visible = true;
                            }
                            else
                            {
                                ViewModel.cboUnit[10].Enabled = true;
                            }
                            for (int i = 0; i <= ViewModel.cboUnit[10].Items.Count - 1; i++)
                            {
                                ViewModel.cboUnit[10].SelectedIndex = i;
                                if ( ViewModel.cboUnit[10].Text == IncidentMain.Clean(ReportLog.ReportLogRS["responsible_unit_id"]))
                                {
                                    break;
                                }
                        }
                            break;
                    case IncidentMain.CIVILCASUALTY:
                            CivCount++;
                            ViewModel.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                            ViewModel.txtNumberCivCasulties.Visible = true;
                            ViewModel.txtNumberCivCasulties.Text = CivCount.ToString();
                            if (Convert.ToDouble(ReportLog.ReportLogRS["report_status_id"]) != IncidentMain.INCOMPLETE)
                            {
                                ViewModel.chkCivilianCasualty.Enabled = false;
                                (ViewModel.MinCivCasualty)++;
                            }
                            break;
            }
            ReportLog.ReportLogRS.MoveNext();
    };
}
else
{
                ViewManager.ShowMessage("Unable to retrieve Incident Situation Found ReportLog record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }

            // Check to see if FDCaresReferral record already exists
            ViewModel.FDCaresBtn.Enabled = !(EMScl.GetFDCaresIncident(ViewModel.CurrIncident) != 0);

            if (IncidentCL.GetAddressCorrection(ViewModel.CurrIncident) != 0)
            {
                ViewModel.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else if (ReportLog.GetIncidentReportLogByType(ViewModel.CurrIncident, IncidentMain.ADDRESSCORRECTION) != 0)
            {
                ViewModel.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else
            {
                ViewModel.chkAddressCorrection.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            }
            ViewModel.DontRespond = 0;
            if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
            {
                LockScreen();
            }
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAmendReason_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.cboAmendReason.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
            if ( ViewModel.cboAmendReason[Index].SelectedIndex == -1)
            {
                return;
            }

            if ( ViewModel.txtAmendTime[Index].Text == "__:__")
            {
                ViewModel.txtAmendTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtAmendTime[Index].BackColor = IncidentMain.Shared.REQCOLOR;
            }
            ViewModel.cboAmendReason[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            ViewModel.cboAmendReason[Index].ForeColor = IncidentMain.Shared.BLACK;
            ViewModel.cmdSave[0].Enabled = true;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAmendReason_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.cboAmendReason.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
            if ( ViewModel.cboAmendReason[Index].SelectedIndex == -1)
            {
                ViewModel.cboAmendReason[Index].Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboCityCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEMSUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }
            ViewModel.cmdSave[0].Enabled = true;
            CheckSitComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboPersonnel_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.cboPersonnel.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
            if ( ViewModel.cboPersonnel[Index].SelectedIndex == -1)
            {
                ViewModel.cboPersonnel[Index].Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboPosition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.cboPosition.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel) eventSender);
            if ( ViewModel.cboPosition[Index].SelectedIndex == -1)
            {
                ViewModel.cboPosition[Index].Text = "";
            }
    }

        //UPGRADE_NOTE: (7001) The following declaration (cboSirenUnit_Change) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
        //private void cboSirenUnit_Change(int Index)
        //{
        //if (DontRespond != 0)
        //{
        //return;
        //}
        //
        //cmdSave[0].Enabled = true;
        //CheckSitComplete();
        //
        //}
        [UpgradeHelpers.Events.Handler]
        internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }
            ViewModel.cmdSave[0].Enabled = true;
            CheckSitComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXStreetType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkCivilianCasualty_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }

            //Show Number of Casualty controls
            if ( ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.txtNumberCivCasulties.Visible = true;
                if ( ViewModel.txtNumberCivCasulties.Text == "")
                {
                    ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberCivCasulties.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
                ViewManager.ShowMessage("Please Identify an EMS Patient Report for Each Civilian Casualty", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                    .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
            }
            else
            {
                ViewModel.DontRespond = -1;
                ViewModel.txtNumberCivCasulties.Text = "";
                ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                ViewModel.txtNumberCivCasulties.Visible = false;
                ViewModel.DontRespond = 0;
            }

            CheckSitComplete();

    }

        [UpgradeHelpers.Events.Handler]
        internal void chkExposures_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Show Number of Casualty controls
            ViewModel.txtNumberExposures.Visible = ViewModel.chkExposures.CheckState == UpgradeHelpers.Helpers.CheckState.Checked;

        }

        [UpgradeHelpers.Events.Handler]
        internal void chkSitFound_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.chkSitFound.IndexOf((UpgradeHelpers.BasicViewModels.CheckBoxViewModel) eventSender);
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }

            //Format Frame as needed
            ViewModel.DontRespond = -1;

            if ( ViewModel.chkSitFound[Index].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
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
                    ViewModel.lbEMSTitle.Visible = false;
                    ViewModel.lbSirenTitle.Visible = false;
                    ViewModel.chkSitFound[3].Enabled = true;
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
                for (int i = 8; i <= 10; i++)
                {
                    ViewModel.cboUnit[i].Enabled = false;
                }
                if (Index == 4)
                { //Multiple EMS Patients

                    ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberPatients.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberPatients.Enabled = true;
                    ViewModel.DontRespond = 0;
                    ViewModel.txtNumberPatients.Text = "1";
                    ViewModel.DontRespond = -1;
                    ViewModel.txtNumberPatients.Text = "";
                    ViewManager.SetCurrent(ViewModel.txtNumberPatients);
                    if ( ViewModel.chkSitFound[3].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        if (!ViewModel.chkSitFound[3].Enabled)
                        {
                            ViewModel.lbPatient[0].Tag = Convert.ToString(ViewModel.chkSitFound[3].Tag);
                            ViewModel.cboEMSUnit[0].Enabled = false;
                            ViewModel.cmdEMSUnlock[0].Visible = true;
                            ViewModel.chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        }
                        else if ( ViewModel.chkSitFound[3].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                        {
                            ViewModel.lbPatient[0].Tag = Convert.ToString(ViewModel.chkSitFound[3].Tag);
                            ViewModel.chkSitFound[3].Tag = "";
                            ViewModel.cboUnit[3].Enabled = false;
                            ViewModel.chkSitFound[3].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                            if ( ViewModel.chkSirenSingle.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                ViewModel.chkSirenReport[0].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                                ViewModel.chkSirenSingle.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                            }
                    }
            }
    }
    else
    {
                    ViewModel.cboUnit[Index].Enabled = true;
                }
        }

        if ( ViewModel.chkSitFound[0].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked && ViewModel
                    .chkSitFound[1].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked && ViewModel.chkSitFound[2].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
            {
                if ( ViewModel.chkCivilianCasualty.Enabled)
                {
                    ViewModel.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                    ViewModel.chkCivilianCasualty.Enabled = false;
                    ViewModel.txtNumberCivCasulties.Text = "";
                    ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDCOLOR;
                    ViewModel.txtNumberCivCasulties.Visible = false;
                }
        }
        else
        {
                if (!ViewModel.chkCivilianCasualty.Enabled && ViewModel.chkCivilianCasualty.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                {
                    ViewModel.chkCivilianCasualty.Enabled = true;
                }
        }
            //********************************************************************
            //Fire Exposure Reports Now Generated off of Fire Report Screens 1/1/2005
            //    If chkSitFound(0).Value = 1 Then
            //        chkExposures.Enabled = True
            //    Else
            //        chkExposures.Enabled = False
            //        chkExposures.Value = 0
            //        txtNumberExposures.Text = 0
            //        txtNumberExposures.BackColor = WHITE
            //        txtNumberExposures.ForeColor = SITFOUNDCOLOR
            //        txtNumberExposures.Visible = False
            //    End If
            ViewModel.DontRespond = 0;
            CheckSitComplete();
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
        internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                int Index =this.ViewModel.cmdSave.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
                //Save Reports
                int UpdateType = 0;
                if (Index == 0)
                {
                    UpdateType = IncidentMain.COMPLETE;
                }
                else if (Index == 1)
                {
                    UpdateType = IncidentMain.SAVEDINCOMPLETE;
                }

                if (Index == 0 || Index == 1)
                {
                    using ( var async2 = this.Async() )
                    {
                        switch ( ViewModel.ReportType)
                        {
                            case IncidentMain.UNITREPORT:
                                async2.Append(() => SaveUnitReport(UpdateType));
                                async2.Append<SaveUnitReportStruct>((tempReturnValue) =>
                                    {
                                        var returningMetodValue519 = tempReturnValue;
                                        if (returningMetodValue519.returnValue != 0)
                                        {


                                            UpdateType = returningMetodValue519.iUpdateType;
                                            ViewManager.ShowMessage("Unit Report Successfully Updated", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        }
                                    });
                                break;
                        case IncidentMain.INCIDENTREPORT:
                                async2.Append<System.Int32>(() => SaveSituationFound(UpdateType));
                                async2.Append<System.Int32, System.Int32>(tempNormalized2 => tempNormalized2);
                                async2.Append<System.Int32>(tempNormalized3 =>
                                    {
                                        if ( tempNormalized3 != 0)
                                        {
                                            ViewManager.ShowMessage("Situation Found Report Successfully Updated", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        }
                                        else
                                        {
                                            ViewManager.ShowMessage("Error attempting to Update Situation Found Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        }
                                    });
                                break;
                        case IncidentMain.ADDRESSCORRECTION:
                                if (SaveAddressCorrection(UpdateType) != 0)
                                {
                                    ViewManager.ShowMessage("Incident Address Correction Successfully Updated", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Update Incident Address Correction", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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

        [UpgradeHelpers.Events.Handler]
        internal void cmdViewReport_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Determine printed report type
            switch ( ViewModel.ReportType)
            {
                case IncidentMain.UNITREPORT:
                    ViewManager.ShowMessage("Unit Report under construction", "TFD IRS", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    break;
            default:
                    ViewManager.NavigateToView(
                        frmReportIncd.DefInstance);
                    break;
    }
}

        [UpgradeHelpers.Events.Handler]
        internal void FDCaresBtn_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
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

        //UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

        private void Form_Load()
        {
            //Determine Whether Unit or Incident Report
            //Format Screen
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            ViewModel.CurrReportID = IncidentMain.Shared.gEditReportID;
            ReportLog.GetReportLog(ViewModel.CurrReportID);
            ViewModel.CurrIncident = ReportLog.RLIncidentID;
            ViewModel.lbUnit.Text = ReportLog.ResponsibleUnit;
            ViewModel.ReportType = ReportLog.ReportType;

            if (~IncidentCL.GetIncident(ViewModel.CurrIncident) != 0)
            {
                ViewManager.ShowMessage("Error Attempting to Retrieve Incident Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
            }
            else
            {
                ViewModel.lbIncident.Text = IncidentCL.IncidentNumber;
                ViewModel.lbLocation.Text = IncidentCL.Location;
            }


            switch ( ViewModel.ReportType)
            {
                case IncidentMain.UNITREPORT:
                    ViewModel.frmUnit.Visible = true;
                    ViewModel.frmUnit.Left = 0;
                    ViewModel.frmSitFound.Visible = false;
                    ViewModel.frmIncidentAddressCorrection.Visible = false;
                    LoadUnit();
                    break;
            case IncidentMain.INCIDENTREPORT:
                    ViewModel.frmSitFound.Visible = true;
                    ViewModel.frmSitFound.Left = 0;
                    ViewModel.frmUnit.Visible = false;
                    ViewModel.frmIncidentAddressCorrection.Visible = false;
                    ViewModel.cmdSave[0].Enabled = true;
                    ViewModel.cmdSave[1].Enabled = false;
                    ViewModel.cmdSave[2].Enabled = true;
                    LoadSitFound();
                    break;
            case IncidentMain.ADDRESSCORRECTION:
                    ViewModel.frmIncidentAddressCorrection.Visible = true;
                    ViewModel.frmIncidentAddressCorrection.Left = 0;
                    ViewModel.frmSitFound.Visible = false;
                    ViewModel.frmUnit.Visible = false;
                    LoadAddressCorrection();

                    break;
    }


}

        [UpgradeHelpers.Events.Handler]
        internal void optServiceReport_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index =this.ViewModel.optServiceReport.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
                //Remove all Non Service Report Changes
                if ( ViewModel.DontRespond != 0)
                {
                    return;
                }
                ViewModel.DontRespond = -1;

                for (int i = 0; i <= 7; i++)
                {
                    if ( ViewModel.chkSitFound[i].Enabled)
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
                            ViewModel.frmMultiEMS.Visible = false;
                            ViewModel.lbEMSTitle.Visible = false;
                            ViewModel.lbSirenTitle.Visible = false;
                            for (int x = 0; x <= 12; x++)
                            {
                                ViewModel.lbPatient[x].Visible = false;
                                ViewModel.cboEMSUnit[x].Visible = false;
                                ViewModel.chkSirenReport[x].Visible = false;
                            }
                    }
                        ViewModel.chkSitFound[i].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                    }
            }
                ViewModel.chkCivilianCasualty.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.chkCivilianCasualty.Enabled = false;
                ViewModel.cboUnit[Index + 8].Enabled = true;
                ViewModel.DontRespond = 0;
                ViewModel.cmdSave[0].Enabled = true;
                CheckSitComplete();

        }
}

        [UpgradeHelpers.Events.Handler]
        internal void txtAmendTime_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.txtAmendTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel) eventSender);
            if ( ViewModel.txtAmendTime[Index].Text == "__:__")
            {
                ViewModel.cboAmendReason[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboAmendReason[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtAmendTime[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.cboAmendReason[Index].SelectedIndex = -1;
                ViewModel.cmdSave[0].Enabled = true;
            }
            else
            {
                ViewModel.txtAmendTime[Index].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtAmendTime[Index].ForeColor = IncidentMain.Shared.BLACK;

                if ( ViewModel.cboAmendReason[Index].SelectedIndex == -1)
                {
                    ViewModel.cboAmendReason[Index].BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.cboAmendReason[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.cmdSave[0].Enabled = false;
                }

        }

}

        [UpgradeHelpers.Events.Handler]
        internal void txtAmendTime_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            int Index =this.ViewModel.txtAmendTime.IndexOf((UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel) eventSender);
            //Edit TimeEntry
            //Don't edit if empty
            if ( ViewModel.txtAmendTime[Index].Text == "__:__")
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
                ViewModel.txtAmendTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                ViewModel.txtAmendTime[Index].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
        TimeWork = HourWork + ":" + MinWork;
            ViewModel.txtAmendTime[Index].Text = TimeWork;

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberCivCasulties_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }
            //Make Sure that a number is entered
            ViewModel.DontRespond = -1;

            double dbNumericTemp = 0;
            if ( ViewModel.txtNumberCivCasulties.Text == "")
            {
                if ( ViewModel.MinCivCasualty > 0)
                {
                    ViewModel.txtNumberCivCasulties.Text = ViewModel.MinCivCasualty.ToString();
                    ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                }
                else
                {
                    ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberCivCasulties.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
        }
        else if (!Double.TryParse(ViewModel.txtNumberCivCasulties.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                if ( ViewModel.MinCivCasualty > 0)
                {
                    ViewModel.txtNumberCivCasulties.Text = ViewModel.MinCivCasualty.ToString();
                    ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                }
                else
                {
                    ViewModel.txtNumberCivCasulties.Text = "";
                    ViewModel.txtNumberCivCasulties.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberCivCasulties.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
        }
        else if ( ViewModel.MinCivCasualty > Conversion.Val(ViewModel.txtNumberCivCasulties.Text))
            {
                ViewModel.txtNumberCivCasulties.Text = ViewModel.MinCivCasualty.ToString();
                ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
            }
            else
            {
                ViewModel.txtNumberCivCasulties.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberCivCasulties.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
            }
            ViewModel.DontRespond = 0;

            CheckSitComplete();

    }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberExposures_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Make Sure that a number is entered
            CheckSitComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberExposures_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if (Conversion.Val(ViewModel.txtNumberExposures.Text) < ViewModel.MinExposures)
            {
                ViewModel.txtNumberExposures.Text = ViewModel.MinExposures.ToString();
            }

    }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberPatients_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.DontRespond != 0)
            {
                return;
            }

            int NumberOfPatients = 0;
            ViewModel.DontRespond = -1;
            ViewModel.frmMultiEMS.Visible = false;
            ViewModel.lbEMSTitle.Visible = false;

            for (int i = 0; i <= 12; i++)
            {
                ViewModel.lbPatient[i].Visible = false;
                ViewModel.cboEMSUnit[i].Visible = false;
            }

            double dbNumericTemp = 0;
            if ( ViewModel.txtNumberPatients.Text == "")
            {
                if ( ViewModel.MinPatients > 0)
                {
                    ViewModel.txtNumberPatients.Text = ViewModel.MinPatients.ToString();
                    //UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                    ViewModel.txtNumberPatients.SelectionLength = Marshal.SizeOf(ViewModel.MinPatients);
                    ViewModel.txtNumberPatients.SelectionStart = 1;
                    ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                }
                else
                {
                    ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberPatients.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
        }
        else if (!Double.TryParse(ViewModel.txtNumberPatients.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                if ( ViewModel.MinPatients > 0)
                {
                    ViewModel.txtNumberPatients.Text = ViewModel.MinPatients.ToString();
                    //UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                    ViewModel.txtNumberPatients.SelectionLength = Marshal.SizeOf(ViewModel.MinPatients);
                    ViewModel.txtNumberPatients.SelectionStart = 1;
                    ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
                }
                else
                {
                    ViewModel.txtNumberPatients.Text = "";
                    ViewModel.txtNumberPatients.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberPatients.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                }
        }
        else if ( ViewModel.MinPatients > Conversion.Val(ViewModel.txtNumberPatients.Text))
            {
                ViewModel.txtNumberPatients.Text = ViewModel.MinPatients.ToString();
                //UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                ViewModel.txtNumberPatients.SelectionLength = Marshal.SizeOf(ViewModel.MinPatients);
                ViewModel.txtNumberPatients.SelectionStart = 1;
                ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
            }
            else
            {
                ViewModel.txtNumberPatients.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberPatients.ForeColor = IncidentMain.Shared.SITFOUNDFONT;
            }

            if (Conversion.Val(ViewModel.txtNumberPatients.Text) > 0)
            {
                if (Conversion.Val(ViewModel.txtNumberPatients.Text) > 13)
                {
                    ViewModel.txtNumberPatients.Text = "13";
                    ViewManager.ShowMessage("System Current Only Allows for 13 Patients per Incident", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                }
                ViewModel.frmMultiEMS.Visible = true;
                ViewModel.lbEMSTitle.Visible = true;
                NumberOfPatients = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberPatients.Text));
                for (int i = 0; i <= NumberOfPatients - 1; i++)
                {
                    ViewModel.lbPatient[i].Visible = true;
                    ViewModel.cboEMSUnit[i].Visible = true;
                }
        }
            ViewModel.DontRespond = 0;
            CheckSitComplete();

    }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberPatients_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            //    If DontRespond Then Exit Sub
            //
            //    Dim NumberOfPatients As Integer
            //    Dim i As Integer
            //
            //    DontRespond = True
            //    frmMultiEMS.Visible = False
            //    lbEMSTitle.Visible = False
            //
            //    For i = 0 To 12
            //        lbPatient(i).Visible = False
            //        cboEMSUnit(i).Visible = False
            //    Next i
            //
            //    If txtNumberPatients.Text = "" Then
            //        If MinPatients > 0 Then
            //            txtNumberPatients.Text = MinPatients
            //            txtNumberPatients.BackColor = WHITE
            //            txtNumberPatients.ForeColor = SITFOUNDFONT
            //        Else
            //            txtNumberPatients.BackColor = REQCOLOR
            //            txtNumberPatients.ForeColor = WHITE
            //        End If
            //    ElseIf Not IsNumeric(txtNumberPatients.Text) Then
            //        If MinPatients > 0 Then
            //            txtNumberPatients.Text = MinPatients
            //            txtNumberPatients.BackColor = WHITE
            //            txtNumberPatients.ForeColor = SITFOUNDFONT
            //        Else
            //            txtNumberPatients.Text = ""
            //            txtNumberPatients.BackColor = REQCOLOR
            //            txtNumberPatients.ForeColor = WHITE
            //        End If
            //    ElseIf MinPatients > Val(txtNumberPatients.Text) Then
            //        txtNumberPatients.Text = MinPatients
            //        txtNumberPatients.BackColor = WHITE
            //        txtNumberPatients.ForeColor = SITFOUNDFONT
            //    Else
            //        txtNumberPatients.BackColor = WHITE
            //        txtNumberPatients.ForeColor = SITFOUNDFONT
            //    End If
            //
            //    If Val(txtNumberPatients.Text) > 0 Then
            //        If Val(txtNumberPatients.Text) > 13 Then
            //            txtNumberPatients.Text = "13"
            //            MsgBox "System Current Only Allows for 13 Patients per Incident", vbInformation, "TFD Incident Reporting System"
            //        End If
            //        frmMultiEMS.Visible = True
            //        lbEMSTitle.Visible = True
            //        NumberOfPatients = Val(txtNumberPatients.Text)
            //        For i = 0 To NumberOfPatients - 1
            //            lbPatient(i).Visible = True
            //            cboEMSUnit(i).Visible = True
            //        Next i
            //    End If
            //
            //    DontRespond = False
            //    CheckSitComplete

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXStreetName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
        }

        public struct SaveUnitReportStruct
        {
            public int returnValue;
            public int iUpdateType;
        }

        public static frmIncident DefInstance
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

        public static frmIncident CreateInstance()
        {
            TFDIncident.frmIncident theInstance = Shared.Container.Resolve< frmIncident>();
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
            using ( var async1 = this.Async(true) )
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
            ViewModel.picFireBar.LifeCycleStartup();
            ViewModel.frmSitFound.LifeCycleStartup();
            ViewModel.frmSituation.LifeCycleStartup();
            ViewModel.frmServiceSit.LifeCycleStartup();
            ViewModel.frmMultiEMS.LifeCycleStartup();
            ViewModel.frmUnit.LifeCycleStartup();
            ViewModel.frmIncidentAddressCorrection.LifeCycleStartup();
            base.ExecuteControlsStartup();
            this.DynamicControlsStartup();
        }

        protected override void ExecuteControlsShutdown()
        {
            ViewModel.picFireBar.LifeCycleShutdown();
            ViewModel.frmSitFound.LifeCycleShutdown();
            ViewModel.frmSituation.LifeCycleShutdown();
            ViewModel.frmServiceSit.LifeCycleShutdown();
            ViewModel.frmMultiEMS.LifeCycleShutdown();
            ViewModel.frmUnit.LifeCycleShutdown();
            ViewModel.frmIncidentAddressCorrection.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class frmIncident
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmIncidentViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual frmIncident m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }
}