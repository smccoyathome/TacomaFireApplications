using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Helpers;

namespace TFDIncident
{

    public partial class wzdFire
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdFireViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(wzdFire));
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


        private void wzdFire_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

        //Counts

        private void LoadReportStatus()
        {
            //Format ReportStatus frame
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve<clsPersonnel>();
            ViewModel.lblIncidentNumber.Text = ViewModel.lbFireIncNo.Text;
            ViewModel.lbReportedBy.Text = IncidentMain.Shared.gCurrUserName;
            ViewModel.lblEmployeeID.Text = IncidentMain.Shared.gCurrUser;

            switch (ViewModel.CurrReport)
            {
                case IncidentMain.FIRESTRUCTURE:
                    ViewModel.lbRSCurrReportType.Text = "Structure Fire Report";
                    break;
                case IncidentMain.FIREMOBILE:
                    ViewModel.lbRSCurrReportType.Text = "Mobile Property Fire Report";
                    break;
                case IncidentMain.FIREOUTSIDE:
                    ViewModel.lbRSCurrReportType.Text = "Outside Fire Report";
                    break;
                case IncidentMain.RUPTURESTRUCTURE:
                    ViewModel.lbRSCurrReportType.Text = "Structure Rupture Report";
                    break;
                case IncidentMain.RUPTUREMOBILE:
                    ViewModel.lbRSCurrReportType.Text = "Mobile Property Rupture Report";
                    break;
                case IncidentMain.RUPTUREOUTSIDE:
                    ViewModel.lbRSCurrReportType.Text = "Outside Rupture Report";
                    break;
                default:
                    ViewModel.lbRSCurrReportType.Text = "";
                    break;
            }

            if (PersonnelCL.GetEmployeeRecord(IncidentMain.Shared.gCurrUser) != 0)
            {
                ViewModel.lblPosition.Text = IncidentMain.Clean(PersonnelCL.Employee["job_title"]);
                ViewModel.lblUnit.Text = IncidentMain.Clean(PersonnelCL.Employee["unit_code"]);
                ViewModel.lblShift.Text = IncidentMain.Clean(PersonnelCL.Employee["shift_code"]) + " Shift";
            }
            else
            {
                ViewModel.lblPosition.Text = "Unknown";
                ViewModel.lblUnit.Text = "Unknown";
                ViewModel.lblShift.Text = "Unknown";
            }
            CheckComplete();

            IncidentMain.ReportMessage(ViewModel.CurrIncident, ViewModel.lstMessage);
        }



        private int SaveFireRecord(int UpdateType)
        {
            //if Exit without Saving then Get out

            int result = 0;
            if (UpdateType == IncidentMain.NOREPORT)
            {
                return -1;
            }
            TFDIncident.clsFire FireReport = Container.Resolve<clsFire>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            string NumberWork = "";


            result = -1;
            //Save Changes
            if (ViewModel.CurrReport == IncidentMain.FIREOUTSIDE)
            {
                //Grass, Brush, Trees fire
                if (ViewModel.optType[2].Checked)
                {
                    FireReport.FOIncidentType = 11;
                    FireReport.MaterialType = 1;
                }
                else if (ViewModel.optType[3].Checked)
                {
                    FireReport.FOIncidentType = 10;
                    FireReport.MaterialType = 2;
                }
                else
                {
                    FireReport.FOIncidentType = 13;
                    if (ViewModel.cboOSMaterialInvolved.SelectedIndex != -1)
                    {
                        FireReport.MaterialType = ViewModel.cboOSMaterialInvolved.GetItemData(ViewModel.cboOSMaterialInvolved.SelectedIndex);
                    }
                    else
                    {
                        FireReport.MaterialType = 0;
                    }
                }
                //set incident_id
                FireReport.FOIncidentID = ViewModel.CurrIncident;
                if (ViewModel.cboOSHeatSource.SelectedIndex != -1)
                {
                    FireReport.FOHeatSource = ViewModel.cboOSHeatSource.GetItemData(ViewModel.cboOSHeatSource.SelectedIndex);
                }
                else
                {
                    FireReport.FOHeatSource = 0;
                }
                if (ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    FireReport.FOCauseOfIgnition = ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    FireReport.FOCauseOfIgnition = 0;
                }
                //    NumberWork = Format(txtOSLoss.Text, "####")
                double dbNumericTemp = 0;
                if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    FireReport.FOContentLoss = 0;
                }
                else
                {
                    FireReport.FOContentLoss = Double.Parse(ViewModel.txtOSLoss.Text);
                }
                //    NumberWork = Format(txtOSAreaAffected.Text, "####")
                double dbNumericTemp2 = 0;
                if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                {
                    FireReport.AreaAffected = 0;
                }
                else
                {
                    FireReport.AreaAffected = Convert.ToInt32(Double.Parse(ViewModel.txtOSAreaAffected.Text));
                }
                if (ViewModel.cboOSAreaUnits.SelectedIndex != -1)
                {
                    FireReport.AreaUnit = ViewModel.cboOSAreaUnits.GetItemData(ViewModel.cboOSAreaUnits.SelectedIndex);
                }
                else
                {
                    FireReport.AreaUnit = 0;
                }
                if (FireReport.AddFireOutside() != 0)
                {
                    result = -1;
                    ViewModel.FireReportID = FireReport.FireOutsideID;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                //Fire Structure or Fire Mobile Property - Save FireReport first
                //set incident_id
                FireReport.IncidentID = ViewModel.CurrIncident;
                if (ViewModel.CurrReport == IncidentMain.FIRESTRUCTURE)
                {
                    if (ViewModel.cboSpecificPropertyUse.SelectedIndex != -1)
                    {
                        FireReport.PropertyUse = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
                    }
                    else
                    {
                        FireReport.PropertyUse = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtPropValue.Text, "####");
                    FireReport.PropertyValue = Conversion.Val(NumberWork);
                    FireReport.IncidentType = 14;
                }
                else
                {
                    if (ViewModel.cboMobilePropType.SelectedIndex != -1)
                    {
                        FireReport.PropertyUse = ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex);
                    }
                    else
                    {
                        FireReport.PropertyUse = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtMobilePropValue.Text, "####");
                    FireReport.PropertyValue = Conversion.Val(NumberWork);
                    FireReport.IncidentType = 12;
                }
                if (ViewModel.cboAreaOfOrigin.SelectedIndex != -1)
                {
                    FireReport.AreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
                }
                else
                {
                    FireReport.AreaOfOrigin = 0;
                }
                if (ViewModel.cboHeatSource.SelectedIndex != -1)
                {
                    FireReport.HeatSource = ViewModel.cboHeatSource.GetItemData(ViewModel.cboHeatSource.SelectedIndex);
                }
                else
                {
                    FireReport.HeatSource = 0;
                }
                if (ViewModel.cboFirstItemIgnited.SelectedIndex != -1)
                {
                    FireReport.FirstItemIgnited = ViewModel.cboFirstItemIgnited.GetItemData(ViewModel.cboFirstItemIgnited.SelectedIndex);
                }
                else
                {
                    FireReport.FirstItemIgnited = 0;
                }
                if (ViewModel.cboSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    FireReport.CauseOfIgnition = ViewModel.cboSpecCauseOfIgnition.GetItemData(ViewModel.cboSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    FireReport.CauseOfIgnition = 0;
                }
                //    NumberWork = Format(txtPropLoss.Text, "####")
                double dbNumericTemp3 = 0;
                if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                {
                    FireReport.PropertyLoss = 0;
                }
                else
                {
                    FireReport.PropertyLoss = Double.Parse(ViewModel.txtPropLoss.Text);
                }
                //    NumberWork = Format(txtContentLoss.Text, "####")
                double dbNumericTemp4 = 0;
                if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
                {
                    FireReport.ContentLoss = 0;
                }
                else
                {
                    FireReport.ContentLoss = Double.Parse(ViewModel.txtContentLoss.Text);
                }
                if (FireReport.AddFireReport() != 0)
                {
                    result = -1;
                    ViewModel.FireReportID = FireReport.FireReportID;
                }
                else
                {
                    result = 0;
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =

 //Save Physical, Human, and Suppression Factors
 FireReport.DeleteFireHumanContributingFactor(ref p1);
                        ViewModel.FireReportID = p1;
                        return ret;
                    }, ViewModel.FireReportID);
                FireReport.HFFireReportID = ViewModel.FireReportID;
                FireReport.HFAge = 0;
                FireReport.HFGender = 0;
                for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstHumanContribFactors.GetSelected(i))
                    {
                        FireReport.HumanFactor = ViewModel.lstHumanContribFactors.GetItemData(i);
                        FireReport.HFAge = Convert.ToInt32(Conversion.Val(ViewModel.txtHFAge.Text));
                        if (FireReport.HFAge != 0)
                        {
                            if (ViewModel.optHFGender[0].Checked)
                            {
                                FireReport.HFGender = 1;
                            }
                            else
                            {
                                FireReport.HFGender = 2;
                            }
                        }
                        else
                        {
                            FireReport.HFGender = 0;
                        }
                        FireReport.AddFireHumanContributingFactor();
                    }
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                FireReport.DeleteFirePhysicalContributingFactor(ref p1);
                        ViewModel.FireReportID = p1;
                        return ret;
                    }, ViewModel.FireReportID);
                FireReport.PCFireReportID = ViewModel.FireReportID;
                for (int i = 0; i <= ViewModel.lstPhysicalContribFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstPhysicalContribFactors.GetSelected(i))
                    {
                        FireReport.PhysicalFactor = ViewModel.lstPhysicalContribFactors.GetItemData(i);
                        FireReport.AddFirePhysicalContributingFactor();
                    }
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                FireReport.DeleteFireSuppressionFactor(ref p1);
                        ViewModel.FireReportID = p1;
                        return ret;
                    }, ViewModel.FireReportID);
                FireReport.SFFireReportID = ViewModel.FireReportID;
                for (int i = 0; i <= ViewModel.lstSuppressionFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstSuppressionFactors.GetSelected(i))
                    {
                        FireReport.SuppressionFactor = ViewModel.lstSuppressionFactors.GetItemData(i);
                        FireReport.AddFireSuppressionFactor();
                    }
                }
                //Save Fire Mobile Report
                if (ViewModel.CurrReport == IncidentMain.FIREMOBILE)
                {
                    FireReport.FMFireReportID = ViewModel.FireReportID;
                    FireReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                    FireReport.VehicleModel = IncidentMain.Clean(ViewModel.txtVehicleModel.Text);
                    FireReport.VehicleYear = IncidentMain.Clean(ViewModel.txtVehicleYear.Text);
                    FireReport.VehicleVin = IncidentMain.Clean(ViewModel.txtVIN.Text);
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtVesselLength.Text, "####");
                    FireReport.WaterVesselLength = Convert.ToInt32(Conversion.Val(NumberWork));
                    if (ViewModel.cboMobileMake.SelectedIndex != -1)
                    {
                        FireReport.MobileMake = ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0));
                        if (FireReport.MobileMake == "OO")
                        {
                            FireReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                        }
                        else
                        {
                            FireReport.VehicleMake = "";
                        }
                    }
                    else
                    {
                        FireReport.MobileMake = "OO";
                        FireReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                    }
                    if (ViewModel.cboLicenseState.SelectedIndex != -1)
                    {
                        FireReport.LicenseState = ViewModel.cboLicenseState.Text;
                    }
                    else
                    {
                        FireReport.LicenseState = "WA";
                    }

                    if (FireReport.AddFireMobileProperty() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                    //Save Fire Structure Report
                }
                else
                {
                    FireReport.FSFireReportID = ViewModel.FireReportID;
                    FireReport.FloorOfOrigin = Convert.ToInt32(Conversion.Val(ViewModel.txtFloorOfOrigin.Text));
                    if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 1;
                    }
                    else if (ViewModel.optFloor[1].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 2;
                    }
                    else if (ViewModel.optFloor[2].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 3;
                    }
                    else
                    {
                        FireReport.SpecialFloor = 4;
                    }
                    if (ViewModel.cboBuildingStatus.SelectedIndex != -1)
                    {
                        FireReport.BuildingStatus = ViewModel.cboBuildingStatus.GetItemData(ViewModel.cboBuildingStatus.SelectedIndex);
                    }
                    else
                    {
                        FireReport.BuildingStatus = 0;
                    }
                    if (ViewModel.cboBurnDamage.SelectedIndex != -1)
                    {
                        FireReport.BurnDamage = ViewModel.cboBurnDamage.GetItemData(ViewModel.cboBurnDamage.SelectedIndex);
                    }
                    else
                    {
                        FireReport.BurnDamage = 0;
                    }
                    if (ViewModel.cboSmokeDamage.SelectedIndex != -1)
                    {
                        FireReport.SmokeDamage = ViewModel.cboSmokeDamage.GetItemData(ViewModel.cboSmokeDamage.SelectedIndex);
                    }
                    else
                    {
                        FireReport.SmokeDamage = 0;
                    }
                    UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret =
//Fire Systems
FireReport.DeleteFireSystemsFailure(ref p1);
                            ViewModel.FireReportID = p1;
                            return ret;
                        }, ViewModel.FireReportID);
                    if (ViewModel.optAlarmType[0].Checked)
                    { //No alarm involved
                        FireReport.FlagNoAlarm = 1;
                        FireReport.FireAlarmType = 0;
                        FireReport.DetectorPower = 0;
                        FireReport.InitiatingDevice = 0;
                        FireReport.AlarmEffectiveness = 0;
                        FireReport.FlagAlarmOperation = 0;
                        //delete all alarm problems
                    }
                    else if (ViewModel.optAlarmType[1].Checked)
                    { //detector units only
                        FireReport.FlagNoAlarm = 0;
                        FireReport.FireAlarmType = 1;
                        if (ViewModel.cboAlarmType.SelectedIndex != -1)
                        {
                            FireReport.DetectorPower = ViewModel.cboAlarmType.GetItemData(ViewModel.cboAlarmType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.DetectorPower = 0;
                        }
                        FireReport.InitiatingDevice = 0;
                        if (ViewModel.cboEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.AlarmEffectiveness = ViewModel.cboEffectiveness.GetItemData(ViewModel.cboEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.AlarmEffectiveness = 0;
                        }
                        FireReport.FlagAlarmOperation = (byte)ViewModel.chkAlarmOperated.CheckState;
                        //delete all alarm problems
                    }
                    else
                    {
                        //Alarm system
                        FireReport.FlagNoAlarm = 0;
                        if (ViewModel.cboAlarmType.SelectedIndex != -1)
                        {
                            FireReport.FireAlarmType = ViewModel.cboAlarmType.GetItemData(ViewModel.cboAlarmType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.FireAlarmType = 0;
                        }
                        FireReport.DetectorPower = 0;
                        if (ViewModel.cboInitiatingDevice.SelectedIndex != -1)
                        {
                            FireReport.InitiatingDevice = ViewModel.cboInitiatingDevice.GetItemData(ViewModel.cboInitiatingDevice.SelectedIndex);
                        }
                        else
                        {
                            FireReport.InitiatingDevice = 0;
                        }
                        if (ViewModel.cboEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.AlarmEffectiveness = ViewModel.cboEffectiveness.GetItemData(ViewModel.cboEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.AlarmEffectiveness = 0;
                        }
                        FireReport.FlagAlarmOperation = (byte)ViewModel.chkAlarmOperated.CheckState;
                        //Save all alarm problems
                        FireReport.FSysFireReportID = ViewModel.FireReportID;
                        for (int i = 0; i <= ViewModel.lstAlarmFailure.Items.Count - 1; i++)
                        {
                            if (ViewModel.lstAlarmFailure.GetSelected(i))
                            {
                                FireReport.SystemFailure = ViewModel.lstAlarmFailure.GetItemData(i);
                                FireReport.AddFireSystemsFailure();
                            }
                        }
                    }
                    if (ViewModel.optExtinguish[0].Checked)
                    { //No Extinguishing System
                        FireReport.FlagNoExtinguishSystem = 1;
                        FireReport.ExtinguishType = 0;
                        FireReport.ExtinguishEffectiveness = 0;
                        FireReport.FlagExtinguishOperation = 0;
                        //delete all Ext. System failure records
                    }
                    else
                    {
                        //Extinguishing System
                        FireReport.FlagNoExtinguishSystem = 0;
                        if (ViewModel.cboSysType.SelectedIndex != -1)
                        {
                            FireReport.ExtinguishType = ViewModel.cboSysType.GetItemData(ViewModel.cboSysType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.ExtinguishType = 0;
                        }
                        if (ViewModel.cboExtEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.ExtinguishEffectiveness = ViewModel.cboExtEffectiveness.GetItemData(ViewModel.cboExtEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.ExtinguishEffectiveness = 0;
                        }
                        FireReport.FlagExtinguishOperation = (byte)ViewModel.chkExtOperated.CheckState;
                        FireReport.FSysFireReportID = ViewModel.FireReportID;
                        for (int i = 0; i <= ViewModel.lstExtFailure.Items.Count - 1; i++)
                        {
                            if (ViewModel.lstExtFailure.GetSelected(i))
                            {
                                FireReport.SystemFailure = ViewModel.lstExtFailure.GetItemData(i);
                                FireReport.AddFireSystemsFailure();
                            }
                        }
                    }
                    FireReport.NumberOfStories = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfStories.Text));
                    FireReport.BasementLevels = Convert.ToInt32(Conversion.Val(ViewModel.txtBasementLevels.Text));
                    if (ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        FireReport.ConstructionType = ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex);
                    }
                    else
                    {
                        FireReport.ConstructionType = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtTotalSqFootage.Text, "####");
                    FireReport.TotalSqFootage = Convert.ToInt32(Conversion.Val(NumberWork));
                    FireReport.PeopleOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfOccupants.Text));
                    FireReport.BusinessesOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfBusinesses.Text));
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtSqFtBurned.Text, "####");
                    FireReport.SqFootBurned = Convert.ToInt32(Conversion.Val(NumberWork));
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtSqFtSmokeDamage.Text, "####");
                    FireReport.SqFootSmokeDamaged = Convert.ToInt32(Conversion.Val(NumberWork));
                    FireReport.PeopleDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoPeopleDisplaced.Text));
                    FireReport.BusinessesDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoBusinessDisplaced.Text));
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtJobsLost.Text, "####");
                    FireReport.JobsLost = Convert.ToInt32(Conversion.Val(NumberWork));
                    FireReport.NumberOfUnits = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfUnits.Text));
                    FireReport.FlagRental = (byte)ViewModel.chkRental.CheckState;
                    if (ViewModel.ExposureOccured != 0)
                    {
                        FireReport.FlagExposure = 1;
                    }
                    else
                    {
                        FireReport.FlagExposure = 0;
                    }
                    if (FireReport.AddFireStructure() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                    UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret =
 //Save Equip Involved and Items Contributing
 FireReport.DeleteFireEquipmentInvolved(ref p1);
                            ViewModel.FireReportID = p1;
                            return ret;
                        }, ViewModel.FireReportID);
                    FireReport.FEFireReportID = ViewModel.FireReportID;
                    for (int i = 0; i <= ViewModel.lstEquipInvolvIgnition.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstEquipInvolvIgnition.GetSelected(i))
                        {
                            FireReport.FireEquipment = ViewModel.lstEquipInvolvIgnition.GetItemData(i);
                            FireReport.AddFireEquipmentInvolved();
                        }
                    }
                    UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                        {
                            var ret =
                                    FireReport.DeleteFireItemContributingFireSpread(ref p1);
                            ViewModel.FireReportID = p1;
                            return ret;
                        }, ViewModel.FireReportID);
                    FireReport.ICFireReportID = ViewModel.FireReportID;
                    for (int i = 0; i <= ViewModel.lstItemContribFireSpread.Items.Count - 1; i++)
                    {
                        if (ViewModel.lstItemContribFireSpread.GetSelected(i))
                        {
                            FireReport.ItemContributing = ViewModel.lstItemContribFireSpread.GetItemData(i);
                            FireReport.AddFireItemContributingFireSpread();
                        }
                    }
                }
            }
            //Names
            //SaveName
            if (ViewModel.NameUpdated != 0)
            {
                SaveName();
            }

            //Narration
            if (ViewModel.rtxNarration.Text != "")
            {
                IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
                IncidentCL.ReportType = ViewModel.CurrReport;
                IncidentCL.NarrationText = ViewModel.rtxNarration.Text;
                IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
                IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
                if (~IncidentCL.AddNarration() != 0)
                {
                    ViewManager.ShowMessage("Error attempting to save Narration Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            //SaveExposureAddress
            if (ViewModel.ADDRESSCORRECTION != 0)
            {
                FireReport.FExpFireReportID = ViewModel.FireReportID;
                FireReport.ExpHouseNumber = IncidentMain.Clean(ViewModel.txtXHouseNumber.Text);
                if (ViewModel.cboXPrefix.SelectedIndex != -1)
                {
                    FireReport.ExpPrefix = ViewModel.cboXPrefix.Text;
                }
                else
                {
                    FireReport.ExpPrefix = "";
                }

                FireReport.ExpStreet = IncidentMain.Clean(ViewModel.txtXStreetName.Text);
                if (ViewModel.cboXStreetType.SelectedIndex != -1)
                {
                    FireReport.ExpStreetType = ViewModel.cboXStreetType.Text;
                }
                else
                {
                    FireReport.ExpStreetType = "";
                }
                if (ViewModel.cboXSuffix.SelectedIndex != -1)
                {
                    FireReport.ExpSuffix = ViewModel.cboXSuffix.Text;
                }
                else
                {
                    FireReport.ExpSuffix = "";
                }
                if (ViewModel.cboCityCode.SelectedIndex == -1)
                {
                    FireReport.ExpCityCode = "";
                }
                else
                {
                    FireReport.ExpCityCode = ViewModel.cboCityCode.Text.Substring(0, Math.Min(3, ViewModel.cboCityCode.Text.Length));
                }
                if (~FireReport.AddFireExposureAddress() != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Add Address Correction", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                ViewModel.ADDRESSCORRECTION = 0;
            }

            //Update Reportlog
            if (result != 0)
            {
                ReportLog.ReportLogID = IncidentMain.Shared.gNewReportID;
                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                ReportLog.ReportReferenceID = ViewModel.FireReportID;
                ReportLog.ReportType = ViewModel.CurrReport;
                ReportLog.ReportStatus = UpdateType;
                ReportLog.ResponsibleUnit = ViewModel.CurrUnit;
                ReportLog.UpDate();
                IncidentMain.Shared.gEditReportID = IncidentMain.Shared.gNewReportID;
            }

            FireReport = null;
            ReportLog = null;
            ViewModel.ExposureOccured = 0;
            ViewModel.ADDRESSCORRECTION = 0;


            return result;
        }

        private int SaveRuptureRecord(int UpdateType)
        {
            //if Exit without Saving then Get out

            int result = 0;
            if (UpdateType == IncidentMain.NOREPORT)
            {
                return -1;
            }
            TFDIncident.clsRupture RuptureReport = Container.Resolve<clsRupture>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            string NumberWork = "";


            result = -1;
            //Save Changes
            if (ViewModel.CurrReport == IncidentMain.RUPTUREOUTSIDE)
            {
                //set incident_id
                RuptureReport.ROIncidentID = ViewModel.CurrIncident;
                if (ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    RuptureReport.ROIncidentType = ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    RuptureReport.ROIncidentType = 0;
                }
                NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtOSLoss.Text, "####");
                RuptureReport.ROContentLoss = Convert.ToInt32(Conversion.Val(NumberWork));
                NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtOSAreaAffected.Text, "####");
                RuptureReport.ROAreaAffected = Convert.ToInt32(Conversion.Val(NumberWork));
                if (ViewModel.cboOSAreaUnits.SelectedIndex != -1)
                {
                    RuptureReport.ROAreaUnit = ViewModel.cboOSAreaUnits.GetItemData(ViewModel.cboOSAreaUnits.SelectedIndex);
                }
                else
                {
                    RuptureReport.ROAreaUnit = 0;
                }
                if (RuptureReport.AddRuptureOutside() != 0)
                {
                    result = -1;
                    ViewModel.RuptureReportID = RuptureReport.RuptureOutsideID;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                //Rupture Structure or Rupture Mobile Property - Save Rupture Report first
                //set incident_id
                RuptureReport.RuptureIncidentID = ViewModel.CurrIncident;
                if (ViewModel.CurrReport == IncidentMain.RUPTURESTRUCTURE)
                {
                    if (ViewModel.cboSpecificPropertyUse.SelectedIndex != -1)
                    {
                        RuptureReport.RupturePropertyUseCode = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.RupturePropertyUseCode = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtPropValue.Text, "####");
                    RuptureReport.RupturePropertyValue = Convert.ToInt32(Conversion.Val(NumberWork));
                }
                else
                {
                    if (ViewModel.cboMobilePropType.SelectedIndex != -1)
                    {
                        RuptureReport.RupturePropertyUseCode = ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.RupturePropertyUseCode = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtMobilePropValue.Text, "####");
                    RuptureReport.RupturePropertyValue = Convert.ToInt32(Conversion.Val(NumberWork));
                }
                if (ViewModel.cboAreaOfOrigin.SelectedIndex != -1)
                {
                    RuptureReport.RuptureAreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
                }
                else
                {
                    RuptureReport.RuptureAreaOfOrigin = 0;
                }
                if (ViewModel.cboHeatSource.SelectedIndex != -1)
                {
                    RuptureReport.RuptureIncidentType = ViewModel.cboHeatSource.GetItemData(ViewModel.cboHeatSource.SelectedIndex);
                }
                else
                {
                    RuptureReport.RuptureIncidentType = 0;
                }
                NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtPropLoss.Text, "####");
                RuptureReport.RupturePropertyLoss = Convert.ToInt32(Conversion.Val(NumberWork));
                NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtContentLoss.Text, "####");
                RuptureReport.RuptureContentLoss = Convert.ToInt32(Conversion.Val(NumberWork));
                if (RuptureReport.AddRupture() != 0)
                {
                    result = -1;
                    ViewModel.RuptureReportID = RuptureReport.RuptureID;
                }
                else
                {
                    result = 0;
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =

 //Save Physical, Human, and Suppression Factors
 RuptureReport.DeleteRuptureHumanContributingFactor(ref p1);
                        ViewModel.RuptureReportID = p1;
                        return ret;
                    }, ViewModel.RuptureReportID);
                RuptureReport.RHCRuptureID = ViewModel.RuptureReportID;
                for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstHumanContribFactors.GetSelected(i))
                    {
                        RuptureReport.RHumanFactor = ViewModel.lstHumanContribFactors.GetItemData(i);
                        RuptureReport.AddRuptureHumanContributingFactor();
                    }
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                RuptureReport.DeleteRupturePhysicalContributingFactor(ref p1);
                        ViewModel.RuptureReportID = p1;
                        return ret;
                    }, ViewModel.RuptureReportID);
                RuptureReport.RPCRuptureID = ViewModel.RuptureReportID;
                for (int i = 0; i <= ViewModel.lstPhysicalContribFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstPhysicalContribFactors.GetSelected(i))
                    {
                        RuptureReport.RPhysicalFactor = ViewModel.lstPhysicalContribFactors.GetItemData(i);
                        RuptureReport.AddRupturePhysicalContributingFactor();
                    }
                }
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                RuptureReport.DeleteRuptureSuppressionFactor(ref p1);
                        ViewModel.RuptureReportID = p1;
                        return ret;
                    }, ViewModel.RuptureReportID);
                RuptureReport.RSFRuptureID = ViewModel.RuptureReportID;
                for (int i = 0; i <= ViewModel.lstSuppressionFactors.Items.Count - 1; i++)
                {
                    if (ViewModel.lstSuppressionFactors.GetSelected(i))
                    {
                        RuptureReport.RSuppressionFactor = ViewModel.lstSuppressionFactors.GetItemData(i);
                        RuptureReport.AddRuptureSuppressionFactor();
                    }
                }
                //Save Rupture Mobile Report
                if (ViewModel.CurrReport == IncidentMain.RUPTUREMOBILE)
                {
                    RuptureReport.RuptureMobileRuptureID = ViewModel.RuptureReportID;
                    RuptureReport.VehicleModel = IncidentMain.Clean(ViewModel.txtVehicleModel.Text);
                    RuptureReport.VehicleYear = IncidentMain.Clean(ViewModel.txtVehicleYear.Text);
                    RuptureReport.VehicleVin = IncidentMain.Clean(ViewModel.txtVIN.Text);
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtVesselLength.Text, "####");
                    RuptureReport.WaterVesseLength = Convert.ToInt32(Conversion.Val(NumberWork));
                    if (ViewModel.cboMobileMake.SelectedIndex != -1)
                    {
                        RuptureReport.MobileMake = ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0));
                        if (RuptureReport.MobileMake == "OO")
                        {
                            RuptureReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                        }
                        else
                        {
                            RuptureReport.VehicleMake = "";
                        }
                    }
                    else
                    {
                        RuptureReport.MobileMake = "OO";
                        RuptureReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                    }
                    if (ViewModel.cboLicenseState.SelectedIndex != -1)
                    {
                        RuptureReport.LicenseState = ViewModel.cboLicenseState.Text;
                    }
                    else
                    {
                        RuptureReport.LicenseState = "WA";
                    }
                    if (RuptureReport.AddRuptureMobile() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                    //Save Fire Structure Report
                }
                else
                {
                    RuptureReport.RuptureStructureRuptureID = ViewModel.RuptureReportID;
                    RuptureReport.FloorOfOrigin = Convert.ToInt32(Conversion.Val(ViewModel.txtFloorOfOrigin.Text));
                    RuptureReport.RSFRuptureID = ViewModel.FireReportID;
                    RuptureReport.FloorOfOrigin = Convert.ToInt32(Conversion.Val(ViewModel.txtFloorOfOrigin.Text));
                    if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 1;
                    }
                    else if (ViewModel.optFloor[1].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 2;
                    }
                    else if (ViewModel.optFloor[2].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 3;
                    }
                    else
                    {
                        RuptureReport.SpecialFloor = 4;
                    }
                    if (ViewModel.cboBuildingStatus.SelectedIndex != -1)
                    {
                        RuptureReport.BuildingStatus = ViewModel.cboBuildingStatus.GetItemData(ViewModel.cboBuildingStatus.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.BuildingStatus = 0;
                    }
                    RuptureReport.NumberOfStories = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfStories.Text));
                    RuptureReport.BasementLevels = Convert.ToInt32(Conversion.Val(ViewModel.txtBasementLevels.Text));
                    if (ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        RuptureReport.ConstructionType = ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.ConstructionType = 0;
                    }
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtTotalSqFootage.Text, "####");
                    RuptureReport.TotalSqFootage = Convert.ToInt32(Conversion.Val(NumberWork));
                    RuptureReport.NumberPeopleOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfOccupants.Text));
                    RuptureReport.NumberBusinessOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfBusinesses.Text));
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtSqFtSmokeDamage.Text, "####");
                    RuptureReport.SqFootDamaged = Convert.ToInt32(Conversion.Val(NumberWork));
                    RuptureReport.PeopleDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoPeopleDisplaced.Text));
                    RuptureReport.BusinessesDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoBusinessDisplaced.Text));
                    NumberWork = UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtJobsLost.Text, "####");
                    RuptureReport.JobsLost = Convert.ToInt32(Conversion.Val(NumberWork));
                    if (RuptureReport.AddRuptureStructure() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
            }
            //Names
            //SaveName
            if (ViewModel.NameUpdated != 0)
            {
                SaveName();
            }

            //Narration
            if (ViewModel.rtxNarration.Text != "")
            {
                IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
                IncidentCL.ReportType = ViewModel.CurrReport;
                IncidentCL.NarrationText = ViewModel.rtxNarration.Text;
                IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
                IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
                if (~IncidentCL.AddNarration() != 0)
                {
                    ViewManager.ShowMessage("Error attempting to save Narration Record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            //Update Reportlog
            if (result != 0)
            {
                ReportLog.ReportLogID = IncidentMain.Shared.gNewReportID;
                ReportLog.RLIncidentID = ViewModel.CurrIncident;
                ReportLog.ReportReferenceID = ViewModel.RuptureReportID;
                ReportLog.ReportType = ViewModel.CurrReport;
                ReportLog.ReportStatus = UpdateType;
                ReportLog.ResponsibleUnit = IncidentMain.Shared.gWizardUnitID;
                ReportLog.UpDate();
            }


            return result;
        }

        private int SaveName()
        {
            //Save Currently Displayed Name Record
            //Determine if Insert (new record) or Update needed
            int result = 0;
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();
            string Birthdate = "";

            if (ViewModel.NameUpdated != 0)
            {
                //Set Incident Class Private Variables
                IncidentCL.NameIncidentID = ViewModel.CurrIncident;
                string tempRefParam = IncidentMain.Clean(ViewModel.txtFirstName.Text);
                IncidentCL.NameFirst = IncidentMain.ProofSQLString(ref tempRefParam);
                string tempRefParam2 = IncidentMain.Clean(ViewModel.txtLastName.Text);
                IncidentCL.NameLast = IncidentMain.ProofSQLString(ref tempRefParam2);
                string tempRefParam3 = IncidentMain.Clean(ViewModel.txtMI.Text);
                IncidentCL.NameMI = IncidentMain.ProofSQLString(ref tempRefParam3);
                string tempRefParam4 = IncidentMain.Clean(ViewModel.txtBusinessName.Text);
                IncidentCL.NameBusiness = IncidentMain.ProofSQLString(ref tempRefParam4);
                if (ViewModel.calBirthdate.MaxDate != ViewModel.calBirthdate.Value)
                {
                    Birthdate = ViewModel.calBirthdate.Value.Date.ToString("MM/dd/yyyy");
                    if (Microsoft.VisualBasic.Information.IsDate(Birthdate))
                    {
                        IncidentCL.Birthdate = Birthdate;
                    }
                    else
                    {
                        IncidentCL.Birthdate = "";
                    }
                }
                else
                {
                    IncidentCL.Birthdate = "";
                }
                IncidentCL.HomePhone = IncidentMain.Clean(ViewModel.txtHomePhone.Text);
                string tempRefParam5 = IncidentMain.Clean(ViewModel.txtWorkPhone.Text);
                IncidentCL.WorkPhone = IncidentMain.ProofSQLString(ref tempRefParam5);
                string tempRefParam6 = IncidentMain.Clean(ViewModel.txtWorkPlace.Text);
                IncidentCL.WorkPlace = IncidentMain.ProofSQLString(ref tempRefParam6);
                if (ViewModel.optGender[0].Checked)
                {
                    IncidentCL.Gender = 1;
                }
                else if (ViewModel.optGender[1].Checked)
                {
                    IncidentCL.Gender = 2;
                }
                else
                {
                    IncidentCL.Gender = 0;
                }
                if (ViewModel.cboRace.SelectedIndex != -1)
                {
                    IncidentCL.RaceCode = ViewModel.cboRace.GetItemData(ViewModel.cboRace.SelectedIndex);
                }
                else
                {
                    IncidentCL.RaceCode = 0;
                }
                if (ViewModel.optEthnicity[0].Checked)
                {
                    IncidentCL.EthnicityCode = 3;
                }
                else if (ViewModel.optEthnicity[1].Checked)
                {
                    IncidentCL.EthnicityCode = 4;
                }
                else
                {
                    IncidentCL.EthnicityCode = 0;
                }
                IncidentCL.HouseNumber = IncidentMain.Clean(ViewModel.txtHouseNumber.Text);
                if (ViewModel.cboPrefix.SelectedIndex != -1)
                {
                    IncidentCL.Prefix = ViewModel.cboPrefix.Text;
                }
                else
                {
                    IncidentCL.Prefix = "";
                }
                IncidentCL.Street = IncidentMain.Clean(ViewModel.txtStreetName.Text);
                if (ViewModel.cboStreetType.SelectedIndex != -1)
                {
                    IncidentCL.StreetType = ViewModel.cboStreetType.Text;
                }
                else
                {
                    IncidentCL.StreetType = "";
                }
                if (ViewModel.cboSuffix.SelectedIndex != -1)
                {
                    IncidentCL.Suffix = ViewModel.cboSuffix.Text;
                }
                else
                {
                    IncidentCL.Suffix = "";
                }
                IncidentCL.City = IncidentMain.Clean(ViewModel.txtCity.Text);
                IncidentCL.Zipcode = IncidentMain.Clean(ViewModel.txtZipcode.Text);
                if (ViewModel.cboState.SelectedIndex != -1)
                {
                    IncidentCL.StateCode = ViewModel.cboState.Text;
                }
                else
                {
                    IncidentCL.StateCode = "";
                }
                if (ViewModel.cboRole.SelectedIndex != -1)
                {
                    IncidentCL.IncidentRoleCode = ViewModel.cboRole.GetItemData(ViewModel.cboRole.SelectedIndex);
                }
                else
                {
                    IncidentCL.IncidentRoleCode = 0;
                }
                IncidentCL.NameLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
                IncidentCL.LastUpdateBy = IncidentMain.Shared.gCurrUser;

                //Insert New Record
                if (IncidentCL.AddName() != 0)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Adding New Name Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            return result;
        }


        private int CheckExposureAddress()
        {
            int result = 0;
            if (ViewModel.FirstTime != 0)
            {
                return result;
            }
            result = -1;
            if (ViewModel.txtXHouseNumber.Text == "")
            {
                ViewModel.txtXHouseNumber.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtXHouseNumber.ForeColor = IncidentMain.Shared.BLACK;
                result = 0;
            }
            else
            {
                ViewModel.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtXHouseNumber.ForeColor = IncidentMain.Shared.FIREFONT;
            }

            if (ViewModel.cboXPrefix.SelectedIndex == -1)
            {
                if (ViewModel.cboXSuffix.SelectedIndex != -1)
                {
                    ViewModel.cboXPrefix.SelectedIndex = -1;
                }
            }
            else
            {
                ViewModel.cboXSuffix.SelectedIndex = -1;
            }

            if (ViewModel.txtXStreetName.Text == "")
            {
                ViewModel.txtXStreetName.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtXStreetName.ForeColor = IncidentMain.Shared.BLACK;
                result = 0;
            }
            else
            {
                ViewModel.txtXStreetName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtXStreetName.ForeColor = IncidentMain.Shared.FIREFONT;
            }

            if (ViewModel.cboCityCode.SelectedIndex == -1)
            {
                ViewModel.cboCityCode.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboCityCode.ForeColor = IncidentMain.Shared.BLACK;
                result = 0;
            }
            else
            {
                ViewModel.cboCityCode.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboCityCode.ForeColor = IncidentMain.Shared.FIREFONT;
            }

            return result;
        }


        private int CheckComplete()
        {
            //Check for Entries in Required Fields
            //Flip Colors as needed
            //If FirstTime Then Exit Function
            int result = 0;
            int PropValue = 0, PeopleOut = 0;
            int BusOut = 0, TotalSq = 0;
            double NumWork = 0;
            int Floors = 0, Basement = 0;

            if (ViewModel.FirstTime != 0)
            {
                return result;
            }

            result = -1;
            if (ViewModel.ADDRESSCORRECTION != 0)
            {
                if (~CheckExposureAddress() != 0)
                {
                    result = 0;
                }
            }

            switch (ViewModel.CurrReport)
            {
                case IncidentMain.FIRE:
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.FIREMOBILE:
                case IncidentMain.FIREOUTSIDE:
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            if (ViewModel.cboGeneralPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboSpecificPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboBuildingStatus.SelectedIndex < 0)
                            {
                                ViewModel.cboBuildingStatus.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboConstructionType.SelectedIndex < 0)
                            {
                                ViewModel.cboConstructionType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboConstructionType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboBurnDamage.SelectedIndex < 0)
                            {
                                ViewModel.cboBurnDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBurnDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboBurnDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBurnDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboSmokeDamage.SelectedIndex < 0)
                            {
                                ViewModel.cboSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboFirstItemIgnited.SelectedIndex < 0)
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboGenCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp = 0;
                            if (ViewModel.txtTotalSqFootage.Text == "")
                            {
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtTotalSqFootage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                            {
                                ViewModel.txtTotalSqFootage.Text = "";
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtTotalSqFootage.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Total Sq Footage", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtTotalSqFootage.Text = "";
                                    ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtTotalSqFootage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.FIREFONT;
                                    TotalSq = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp2 = 0;
                            if (ViewModel.txtNumberOfStories.Text == "")
                            {
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfStories.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                            {
                                ViewModel.txtNumberOfStories.Text = "";
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfStories.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Stories", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfStories.Text = "";
                                    ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfStories.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.FIREFONT;
                                    Floors = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp3 = 0;
                            if (ViewModel.txtBasementLevels.Text == "")
                            {
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtBasementLevels.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                            {
                                ViewModel.txtBasementLevels.Text = "";
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtBasementLevels.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Basement Levels", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtBasementLevels.Text = "";
                                    ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtBasementLevels.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.FIREFONT;
                                    Basement = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp4 = 0;
                            if (ViewModel.txtNumberOfUnits.Text == "")
                            {
                                ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfUnits.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfUnits.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
                            {
                                ViewModel.txtNumberOfUnits.Text = "";
                                ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfUnits.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfUnits.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Units/Suites", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfUnits.Text = "";
                                    ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfUnits.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            double dbNumericTemp5 = 0;
                            if (ViewModel.txtNumberOfOccupants.Text == "")
                            {
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfOccupants.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
                            {
                                ViewModel.txtNumberOfOccupants.Text = "";
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfOccupants.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Occupants", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfOccupants.Text = "";
                                    ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfOccupants.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PeopleOut = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp6 = 0;
                            if (ViewModel.txtNumberOfBusinesses.Text == "")
                            {
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfBusinesses.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6))
                            {
                                ViewModel.txtNumberOfBusinesses.Text = "";
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfBusinesses.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Businesses", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfBusinesses.Text = "";
                                    ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfBusinesses.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.FIREFONT;
                                    BusOut = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp7 = 0;
                            if (ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7))
                            {
                                ViewModel.txtPropValue.Text = "";
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtPropValue.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtPropValue.Text = "";
                                    ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtPropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PropValue = Convert.ToInt32(NumWork);
                                }
                            }

                            //Floor of Origin and Special Floor Indicator 
                            double dbNumericTemp8 = 0;
                            if (ViewModel.txtFloorOfOrigin.Text == "")
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtFloorOfOrigin.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8))
                            {
                                ViewModel.txtFloorOfOrigin.Text = "";
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Floors)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                    ViewManager.ShowMessage("Floor of Origin May NOT Exceed Number of Stories", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Basement)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                    ViewManager.ShowMessage("Below grade Floor of Origin May NOT Exceed Basement Levels", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }

                            double dbNumericTemp9 = 0;
                            if (ViewModel.txtSqFtBurned.Text == "")
                            {
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtSqFtBurned.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp9))
                            {
                                ViewModel.txtSqFtBurned.Text = "";
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtBurned.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtSqFtBurned.Text = "";
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Burned May NOT Exceed Total Sq Footage", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtBurned.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtBurned.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp10 = 0;
                            if (ViewModel.txtSqFtSmokeDamage.Text == "")
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtSqFtSmokeDamage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp10))
                            {
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Smoke Damaged May NOT Exceed Total Sq Footage", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp11 = 0;
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp11))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtPropLoss.Text = "";
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp12 = 0;
                            if (ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp12))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            //Check other loss fields for numeric and value 
                            if (ViewModel.txtNoBusinessDisplaced.Text != "")
                            {
                                double dbNumericTemp13 = 0;
                                if (!Double.TryParse(ViewModel.txtNoBusinessDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp13))
                                {
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoBusinessDisplaced.Text)) > BusOut)
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.BLACK;
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                    result = 0;
                                    ViewManager.ShowMessage("Businesses Displaced May NOT Exceed Businesses Occuping", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.txtNoPeopleDisplaced.Text != "")
                            {
                                double dbNumericTemp14 = 0;
                                if (!Double.TryParse(ViewModel.txtNoPeopleDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp14))
                                {
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoPeopleDisplaced.Text)) > PeopleOut)
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.BLACK;
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                    result = 0;
                                    ViewManager.ShowMessage("People Displaced May NOT Exceed People Occuping", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.txtJobsLost.Text != "")
                            {
                                double dbNumericTemp15 = 0;
                                if (!Double.TryParse(ViewModel.txtJobsLost.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp15))
                                {
                                    ViewModel.txtJobsLost.Text = "";
                                }
                            }
                            if (ViewModel.optAlarmType[1].Checked)
                            {
                                if (ViewModel.cboAlarmType.SelectedIndex < 0)
                                {
                                    ViewModel.cboAlarmType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboAlarmType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if (ViewModel.cboEffectiveness.SelectedIndex < 0)
                                {
                                    if (ViewModel.chkAlarmOperated.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                                    {
                                        ViewModel.cboEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.BLACK;
                                        result = 0;
                                    }
                                    else
                                    {
                                        ViewModel.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                                    }
                                }
                                else
                                {
                                    ViewModel.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else if (ViewModel.optAlarmType[2].Checked)
                            {
                                if (ViewModel.cboAlarmType.SelectedIndex < 0)
                                {
                                    ViewModel.cboAlarmType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboAlarmType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if (ViewModel.cboEffectiveness.SelectedIndex < 0)
                                {
                                    ViewModel.cboEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if (ViewModel.cboInitiatingDevice.SelectedIndex < 0)
                                {
                                    ViewModel.cboInitiatingDevice.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboInitiatingDevice.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboInitiatingDevice.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboInitiatingDevice.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.cboAlarmType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                                ViewModel.cboEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                                ViewModel.cboInitiatingDevice.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboInitiatingDevice.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.optExtinguish[1].Checked)
                            {
                                if (ViewModel.cboSysType.SelectedIndex < 0)
                                {
                                    ViewModel.cboSysType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboSysType.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboSysType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if (ViewModel.cboExtEffectiveness.SelectedIndex < 0)
                                {
                                    ViewModel.cboExtEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboExtEffectiveness.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboExtEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboExtEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.cboSysType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                                ViewModel.cboExtEffectiveness.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboExtEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.HumansAFactor != 0)
                            {
                                ViewModel.frmHFDetail.Visible = true;
                                ViewModel.lstHumanContribFactors.Width = 332;
                                double dbNumericTemp16 = 0;
                                if (ViewModel.txtHFAge.Text == "")
                                {
                                    ViewModel.txtHFAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtHFAge.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else if (!Double.TryParse(ViewModel.txtHFAge.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp16))
                                {
                                    ViewModel.txtHFAge.Text = "";
                                    ViewModel.txtHFAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtHFAge.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtHFAge.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtHFAge.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.frmHFDetail.Visible = false;
                                ViewModel.lstHumanContribFactors.Width = 400;
                            }

                            break;
                        case IncidentMain.FIREMOBILE:
                            if (ViewModel.cboMobilePropType.SelectedIndex < 0)
                            {
                                ViewModel.cboMobilePropType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboMobileMake.SelectedIndex == -1)
                            {
                                ViewModel.cboMobileMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;

                            }
                            else
                            {
                                ViewModel.cboMobileMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                var makeCode = ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0));
                                if (makeCode == "OO")
                                { //Other make selected
                                    if (ViewModel.txtVehicleMake.Text == "")
                                    {
                                        ViewModel.txtVehicleMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtVehicleMake.ForeColor = IncidentMain.Shared.BLACK;
                                        result = 0;
                                    }
                                    else
                                    {
                                        ViewModel.txtVehicleMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtVehicleMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                    }
                                }
                            }
                            double dbNumericTemp17 = 0;
                            if (ViewModel.txtVehicleYear.Text == "")
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtVehicleYear.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp17))
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtVehicleYear.Text = "";
                                result = 0;
                                ViewModel.lbVYearMes.Visible = true;
                            }
                            else if (Strings.Len(ViewModel.txtVehicleYear.Text) != 4)
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtVehicleYear.Text = "";
                                result = 0;
                                ViewModel.lbVYearMes.Visible = true;
                            }
                            else
                            {
                                ViewModel.txtVehicleYear.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.FIREFONT;
                                ViewModel.lbVYearMes.Visible = false;
                            }
                            double dbNumericTemp18 = 0;
                            if (ViewModel.txtMobilePropValue.Text == "")
                            {
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtMobilePropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp18))
                            {
                                ViewModel.txtMobilePropValue.Text = "";
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtMobilePropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                PropValue = Convert.ToInt32(Conversion.Val(ViewModel.txtMobilePropValue.Text));
                            }
                            if (ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboFirstItemIgnited.SelectedIndex < 0)
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboGenCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp19 = 0;
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp19))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Conversion.Val(ViewModel.txtPropLoss.Text) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp20 = 0;
                            if (ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp20))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }

                            break;
                        case IncidentMain.FIREOUTSIDE:
                            if (ViewModel.cboOSHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboOSHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSHeatSource.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboOSCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboOSCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboOSAreaUnits.SelectedIndex < 0)
                            {
                                ViewModel.cboOSAreaUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp21 = 0;
                            if (ViewModel.txtOSLoss.Text == "")
                            {
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp21))
                            {
                                ViewModel.txtOSLoss.Text = "";
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtOSLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp22 = 0;
                            if (ViewModel.txtOSAreaAffected.Text == "")
                            {
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp22))
                            {
                                ViewModel.txtOSAreaAffected.Text = "";
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtOSAreaAffected.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboOSMaterialInvolved.Visible)
                            {
                                if (ViewModel.cboOSMaterialInvolved.SelectedIndex == -1)
                                {
                                    ViewModel.cboOSMaterialInvolved.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboOSMaterialInvolved.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.cboOSMaterialInvolved.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboOSMaterialInvolved.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            break;
                    }

                    //**************************************************************************** 
                    //***     RUPTURE / EXPLOSION 
                    //**************************************************************************** 

                    break;
                default:
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            if (ViewModel.cboGeneralPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboSpecificPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboBuildingStatus.SelectedIndex < 0)
                            {
                                ViewModel.cboBuildingStatus.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboConstructionType.SelectedIndex < 0)
                            {
                                ViewModel.cboConstructionType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboConstructionType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboHeatSource.SelectedIndex == -1)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp23 = 0;
                            if (ViewModel.txtTotalSqFootage.Text == "")
                            {
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtTotalSqFootage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp23))
                            {
                                ViewModel.txtTotalSqFootage.Text = "";
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtTotalSqFootage.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Total Sq Footage", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtTotalSqFootage.Text = "";
                                    ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtTotalSqFootage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtTotalSqFootage.ForeColor = IncidentMain.Shared.FIREFONT;
                                    TotalSq = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp24 = 0;
                            if (ViewModel.txtNumberOfStories.Text == "")
                            {
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfStories.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp24))
                            {
                                ViewModel.txtNumberOfStories.Text = "";
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfStories.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Stories", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfStories.Text = "";
                                    ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfStories.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfStories.ForeColor = IncidentMain.Shared.FIREFONT;
                                    Floors = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp25 = 0;
                            if (ViewModel.txtBasementLevels.Text == "")
                            {
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtBasementLevels.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp25))
                            {
                                ViewModel.txtBasementLevels.Text = "";
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtBasementLevels.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Basement Levels", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtBasementLevels.Text = "";
                                    ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtBasementLevels.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtBasementLevels.ForeColor = IncidentMain.Shared.FIREFONT;
                                    Basement = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp26 = 0;
                            if (ViewModel.txtNumberOfOccupants.Text == "")
                            {
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfOccupants.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp26))
                            {
                                ViewModel.txtNumberOfOccupants.Text = "";
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfOccupants.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Occupants", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfOccupants.Text = "";
                                    ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfOccupants.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfOccupants.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PeopleOut = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp27 = 0;
                            if (ViewModel.txtNumberOfBusinesses.Text == "")
                            {
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtNumberOfBusinesses.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp27))
                            {
                                ViewModel.txtNumberOfBusinesses.Text = "";
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtNumberOfBusinesses.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Businesses", "TFD Incident Reporting Wizard", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfBusinesses.Text = "";
                                    ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtNumberOfBusinesses.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfBusinesses.ForeColor = IncidentMain.Shared.FIREFONT;
                                    BusOut = Convert.ToInt32(NumWork);
                                }
                            }
                            double dbNumericTemp28 = 0;
                            if (ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp28))
                            {
                                ViewModel.txtPropValue.Text = "";
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                NumWork = Double.Parse(ViewModel.txtPropValue.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtPropValue.Text = "";
                                    ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                }
                                else
                                {
                                    ViewModel.txtPropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PropValue = Convert.ToInt32(NumWork);
                                }
                            }

                            //Floor of Origin and Special Floor Indicator 
                            double dbNumericTemp29 = 0;
                            if (ViewModel.txtFloorOfOrigin.Text == "")
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtFloorOfOrigin.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp29))
                            {
                                ViewModel.txtFloorOfOrigin.Text = "";
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Floors)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                    ViewManager.ShowMessage("Floor of Origin May NOT Exceed Number of Stories", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else if (ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Basement)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                    result = 0;
                                    ViewManager.ShowMessage("Below grade Floor of Origin May NOT Exceed Basement Levels", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtFloorOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp30 = 0;
                            if (ViewModel.txtSqFtSmokeDamage.Text == "")
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtSqFtSmokeDamage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp30))
                            {
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Damaged May NOT Exceed Total Sq Footage", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp31 = 0;
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp31))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                ViewModel.txtPropLoss.Text = "";
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp32 = 0;
                            if (ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp32))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            //Check other loss fields for numeric and value 
                            if (ViewModel.txtNoBusinessDisplaced.Text != "")
                            {
                                double dbNumericTemp33 = 0;
                                if (!Double.TryParse(ViewModel.txtNoBusinessDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp33))
                                {
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoBusinessDisplaced.Text)) > BusOut)
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.BLACK;
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                    result = 0;
                                    ViewManager.ShowMessage("Businesses Displaced May NOT Exceed Businesses Occuping", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtNoBusinessDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtNoBusinessDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.txtNoPeopleDisplaced.Text != "")
                            {
                                double dbNumericTemp34 = 0;
                                if (!Double.TryParse(ViewModel.txtNoPeopleDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp34))
                                {
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoPeopleDisplaced.Text)) > PeopleOut)
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.BLACK;
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                    result = 0;
                                    ViewManager.ShowMessage("People Displaced May NOT Exceed People Occuping", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                else
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                            }
                            else
                            {
                                ViewModel.txtNoPeopleDisplaced.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtNoPeopleDisplaced.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.txtJobsLost.Text != "")
                            {
                                double dbNumericTemp35 = 0;
                                if (!Double.TryParse(ViewModel.txtJobsLost.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp35))
                                {
                                    ViewModel.txtJobsLost.Text = "";
                                }
                            }
                            break;
                        case IncidentMain.RUPTUREMOBILE:
                            if (ViewModel.cboMobilePropType.SelectedIndex < 0)
                            {
                                ViewModel.cboMobilePropType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboMobileMake.SelectedIndex == -1)
                            {
                                ViewModel.cboMobileMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboMobileMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                if (ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == "OO")
                                { //Other make selected
                                    if (ViewModel.txtVehicleMake.Text == "")
                                    {
                                        ViewModel.txtVehicleMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtVehicleMake.ForeColor = IncidentMain.Shared.BLACK;
                                        result = 0;
                                    }
                                    else
                                    {
                                        ViewModel.txtVehicleMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtVehicleMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                    }
                                }
                            }
                            if (ViewModel.txtVehicleYear.Text == "")
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtVehicleYear.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp36 = 0;
                            if (ViewModel.txtMobilePropValue.Text == "")
                            {
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtMobilePropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp36))
                            {
                                ViewModel.txtMobilePropValue.Text = "";
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtMobilePropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                PropValue = Convert.ToInt32(Conversion.Val(ViewModel.txtMobilePropValue.Text));
                            }
                            if (ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp37 = 0;
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp37))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (Conversion.Val(ViewModel.txtPropLoss.Text) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp38 = 0;
                            if (ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp38))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }

                            break;
                        case IncidentMain.RUPTUREOUTSIDE:
                            if (ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex == -1)
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if (ViewModel.cboOSAreaUnits.SelectedIndex < 0)
                            {
                                ViewModel.cboOSAreaUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp39 = 0;
                            if (ViewModel.txtOSLoss.Text == "")
                            {
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp39))
                            {
                                ViewModel.txtOSLoss.Text = "";
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtOSLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp40 = 0;
                            if (ViewModel.txtOSAreaAffected.Text == "")
                            {
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp40))
                            {
                                ViewModel.txtOSAreaAffected.Text = "";
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.BLACK;
                                result = 0;
                            }
                            else
                            {
                                ViewModel.txtOSAreaAffected.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            break;
                    }
                    break;
            }

            //Determine Status of Save Buttons
            ViewModel.cmdSave.Enabled = result != 0;

            return result;
        }

        private int CheckNameComplete()
        {
            //Check Required Fields for Save Status of current name record

            int result = 0;
            if (ViewModel.FirstTime != 0)
            {
                return result;
            }

            result = -1;
            if (ViewModel.cboRole.SelectedIndex < 0)
            {
                ViewModel.cboRole.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboRole.ForeColor = IncidentMain.Shared.BLACK;
                result = 0;
            }
            else
            {
                ViewModel.cboRole.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboRole.ForeColor = IncidentMain.Shared.FIREFONT;
            }
            if (ViewModel.txtBusinessName.Text == "")
            {
                if (ViewModel.txtFirstName.Text == "" && ViewModel.txtLastName.Text == "")
                {
                    ViewModel.txtBusinessName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtBusinessName.ForeColor = IncidentMain.Shared.BLACK;
                    result = 0;
                }
                else
                {
                    ViewModel.txtBusinessName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtBusinessName.ForeColor = IncidentMain.Shared.FIREFONT;
                }
            }
            else
            {
                ViewModel.txtBusinessName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtBusinessName.ForeColor = IncidentMain.Shared.FIREFONT;
            }
            if (ViewModel.txtFirstName.Text == "")
            {
                if (ViewModel.txtBusinessName.Text == "")
                {
                    ViewModel.txtFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtFirstName.ForeColor = IncidentMain.Shared.BLACK;
                    result = 0;
                }
                else
                {
                    ViewModel.txtFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtFirstName.ForeColor = IncidentMain.Shared.FIREFONT;
                }
            }
            else
            {
                ViewModel.txtFirstName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtFirstName.ForeColor = IncidentMain.Shared.FIREFONT;
            }
            if (ViewModel.txtLastName.Text == "")
            {
                if (ViewModel.txtBusinessName.Text == "")
                {
                    ViewModel.txtLastName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtLastName.ForeColor = IncidentMain.Shared.BLACK;
                    result = 0;
                }
                else
                {
                    ViewModel.txtLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtLastName.ForeColor = IncidentMain.Shared.FIREFONT;
                }
            }
            else
            {
                ViewModel.txtLastName.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtLastName.ForeColor = IncidentMain.Shared.FIREFONT;
            }
            if (ViewModel.optGender[0].Checked)
            {
                ViewModel.optGender[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.optGender[0].ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.optGender[1].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.optGender[1].ForeColor = IncidentMain.Shared.FIREFONT;
            }
            else if (ViewModel.optGender[1].Checked)
            {
                ViewModel.optGender[0].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.optGender[0].ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.optGender[1].BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.optGender[1].ForeColor = IncidentMain.Shared.FIREFONT;
            }
            else
            {
                ViewModel.optGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.optGender[0].ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.optGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.optGender[1].ForeColor = IncidentMain.Shared.BLACK;
            }

            ViewModel.cmdAddNewName.Enabled = result != 0;

            return result;
        }

        private void LoadLists()
        {
            //Load all appropriate combo and listboxes for
            //Current Fire Report Type
            //Stored Procedures may bring back multiple resultsets
            TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            string sDisplay = "";
            ViewModel.FirstTime = -1;
            //Common fields
            ViewModel.rtxNarration.Text = "";
            //Names
            ClearName();
            ViewModel.cboAreaOfOrigin.Items.Clear();
            ViewModel.cboHeatSource.Items.Clear();
            ViewModel.cboGenCauseOfIgnition.Items.Clear();
            ViewModel.cboSpecCauseOfIgnition.Items.Clear();
            ViewModel.cboFirstItemIgnited.Items.Clear();
            ViewModel.lstPhysicalContribFactors.Items.Clear();
            ViewModel.lstHumanContribFactors.Items.Clear();
            ViewModel.lstSuppressionFactors.Items.Clear();
            ViewModel.cboGeneralPropertyUse.Items.Clear();
            ViewModel.cboSpecificPropertyUse.Items.Clear();
            ViewModel.cboBuildingStatus.Items.Clear();
            ViewModel.cboConstructionType.Items.Clear();
            ViewModel.cboEffectiveness.Items.Clear();
            ViewModel.cboAlarmType.Items.Clear();
            ViewModel.cboInitiatingDevice.Items.Clear();
            ViewModel.lstAlarmFailure.Items.Clear();
            ViewModel.cboSysType.Items.Clear();
            ViewModel.cboExtEffectiveness.Items.Clear();
            ViewModel.lstExtFailure.Items.Clear();
            ViewModel.cboBurnDamage.Items.Clear();
            ViewModel.cboSmokeDamage.Items.Clear();
            ViewModel.lstItemContribFireSpread.Items.Clear();
            ViewModel.lstEquipInvolvIgnition.Items.Clear();
            ViewModel.txtFloorOfOrigin.Text = "";
            ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.txtTotalSqFootage.Text = "";
            ViewModel.txtNumberOfStories.Text = "";
            ViewModel.txtNumberOfUnits.Text = "";
            ViewModel.txtNumberOfOccupants.Text = "";
            ViewModel.txtNumberOfBusinesses.Text = "";
            ViewModel.txtPropValue.Text = "";
            ViewModel.txtContentLoss.Text = "";
            ViewModel.txtJobsLost.Text = "";
            ViewModel.txtNoBusinessDisplaced.Text = "";
            ViewModel.txtNoPeopleDisplaced.Text = "";
            ViewModel.txtPropLoss.Text = "";
            ViewModel.txtSqFtBurned.Text = "";
            ViewModel.txtSqFtSmokeDamage.Text = "";
            ViewModel.txtOSAreaAffected.Text = "";
            ViewModel.txtOSLoss.Text = "";
            ViewModel.lbVesselLength.Visible = false;
            ViewModel.txtVesselLength.Visible = false;
            //    frmPassengerVehicleInfo.Visible = False
            ViewModel.cboMobilePropType.Items.Clear();
            ViewModel.cboAreaOfOrigin.Items.Clear();
            ViewModel.txtMobilePropValue.Text = "";
            ViewModel.txtVesselLength.Text = "";
            ViewModel.cboMobileMake.Items.Clear();
            ViewModel.cboLicenseState.Items.Clear();
            ViewModel.txtVehicleMake.Text = "";
            ViewModel.txtVehicleModel.Text = "";
            ViewModel.txtVehicleYear.Text = "";
            ViewModel.txtVIN.Text = "";
            ViewModel.cboOSHeatSource.Items.Clear();
            ViewModel.cboOSCauseOfIgnition.Items.Clear();
            ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
            ViewModel.cboOSAreaUnits.Items.Clear();
            ViewModel.cboOSMaterialInvolved.Items.Clear();
            ViewModel.txtXHouseNumber.Text = "";
            ViewModel.cboXPrefix.Items.Clear();
            ViewModel.txtXStreetName.Text = "";
            ViewModel.cboXStreetType.Items.Clear();
            ViewModel.cboXSuffix.Items.Clear();
            ViewModel.cboCityCode.Items.Clear();


            CommonCodes.GetAddressVerification("X");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboPrefix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboSuffix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboXPrefix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboXSuffix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            }
            ;

            CommonCodes.GetAddressVerification("S");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboStreetType.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboXStreetType.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            }
            ;

            CommonCodes.GetStateCode();

            while (!CommonCodes.StateRS.EOF)
            {
                ViewModel.cboState.AddItem(Convert.ToString(CommonCodes.StateRS["state_code"]));
                ViewModel.cboLicenseState.AddItem(Convert.ToString(CommonCodes.StateRS["state_code"]));
                CommonCodes.StateRS.MoveNext();
            }
            ;
            //Default to Washington
            for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
            {
                if (ViewModel.cboState.GetListItem(i) == "WA")
                {
                    ViewModel.cboState.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i <= ViewModel.cboLicenseState.Items.Count - 1; i++)
            {
                if (ViewModel.cboLicenseState.GetListItem(i) == "WA")
                {
                    ViewModel.cboLicenseState.SelectedIndex = i;
                    break;
                }
            }
            //City Code
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
            //Default to Tacoma
            ViewModel.txtCity.Text = "Tacoma";
            for (int i = 0; i <= ViewModel.cboCityCode.Items.Count - 1; i++)
            {
                if (ViewModel.cboCityCode.GetListItem(i).StartsWith("TAC"))
                {
                    ViewModel.cboCityCode.SelectedIndex = i;
                    break;
                }
            }

            CommonCodes.GetPeopleDescriptor("R");

            while (!CommonCodes.PeopleDescriptor.EOF)
            {
                ViewModel.cboRace.AddItem(Convert.ToString(CommonCodes.PeopleDescriptor["description"]));
                ViewModel.cboRace.SetItemData(ViewModel.cboRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
                CommonCodes.PeopleDescriptor.MoveNext();
            }
            ;

            CommonCodes.GetIncidentRole();

            while (!CommonCodes.IncidentRole.EOF)
            {
                ViewModel.cboRole.AddItem(Convert.ToString(CommonCodes.IncidentRole["description"]));
                ViewModel.cboRole.SetItemData(ViewModel.cboRole.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentRole["incident_role_code"]));
                CommonCodes.IncidentRole.MoveNext();
            }
            ;

            //Common Lists - Structure and Mobile
            if (ViewModel.CurrReport == IncidentMain.FIRESTRUCTURE || ViewModel.CurrReport == IncidentMain.FIREMOBILE)
            {

                //Heat Source Code
                FireCodes.GetHeatSourceCodes();

                while (!FireCodes.HeatSource.EOF)
                {
                    ViewModel.cboHeatSource.AddItem(Convert.ToString(FireCodes.HeatSource["description"]));
                    ViewModel.cboHeatSource.SetItemData(ViewModel.cboHeatSource.GetNewIndex(), Convert.ToInt32(FireCodes.HeatSource["heat_source_code"]));
                    FireCodes.HeatSource.MoveNext();
                };
                if (ViewModel.ExposureOccured != 0)
                {
                    for (int i = 0; i <= ViewModel.cboHeatSource.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboHeatSource.GetItemData(i) == 15)
                        { //Other

                            ViewModel.cboHeatSource.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //General Cause of Ignition Combo
                FireCodes.GetCauseOfIgnitionClass();

                while (!FireCodes.CauseOfIgnitionClassRS.EOF)
                {
                    ViewModel.cboGenCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnitionClassRS["description"]));
                    ViewModel.cboGenCauseOfIgnition.SetItemData(ViewModel.cboGenCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnitionClassRS["cause_of_ignition_class"]));
                    FireCodes.CauseOfIgnitionClassRS.MoveNext();
                };

                if (ViewModel.ExposureOccured != 0)
                {
                    for (int i = 0; i <= ViewModel.cboGenCauseOfIgnition.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboGenCauseOfIgnition.GetItemData(i) == 9)
                        { //Other

                            ViewModel.cboGenCauseOfIgnition.SelectedIndex = i;
                            break;
                        }
                    }
                    ViewModel.cboGenCauseOfIgnition.Enabled = false;
                    for (int i = 0; i <= ViewModel.cboSpecCauseOfIgnition.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboSpecCauseOfIgnition.GetItemData(i) == 35)
                        { //Exposure

                            ViewModel.cboSpecCauseOfIgnition.SelectedIndex = i;
                            break;
                        }
                    }
                    ViewModel.cboSpecCauseOfIgnition.Enabled = false;
                }

                //First Item Ignited combo
                FireCodes.GetFirstItemIgnitedCodes();

                while (!FireCodes.FirstItemIgnited.EOF)
                {
                    ViewModel.cboFirstItemIgnited.AddItem(Convert.ToString(FireCodes.FirstItemIgnited["description"]));
                    ViewModel.cboFirstItemIgnited.SetItemData(ViewModel.cboFirstItemIgnited.GetNewIndex(), Convert.ToInt32(FireCodes.FirstItemIgnited["first_item_ignited_code"]));
                    FireCodes.FirstItemIgnited.MoveNext();
                };


                //Physical Contributing Factors listbox
                FireCodes.GetPhysicalFactorCodes();

                while (!FireCodes.PhysicalFactor.EOF)
                {
                    ViewModel.lstPhysicalContribFactors.AddItem(Convert.ToString(FireCodes.PhysicalFactor["description"]));
                    ViewModel.lstPhysicalContribFactors.SetItemData(ViewModel.lstPhysicalContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.PhysicalFactor["physical_factor_code"]));
                    FireCodes.PhysicalFactor.MoveNext();
                };


                //Human Contributing Factors listbox
                FireCodes.GetHumanFactorCodes();

                while (!FireCodes.HumanFactor.EOF)
                {
                    ViewModel.lstHumanContribFactors.AddItem(Convert.ToString(FireCodes.HumanFactor["description"]));
                    ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.HumanFactor["human_factor_code"]));
                    FireCodes.HumanFactor.MoveNext();
                };


                //Suppression Factors listbox
                FireCodes.GetSuppressionFactorCodes();

                while (!FireCodes.SuppressionFactor.EOF)
                {
                    ViewModel.lstSuppressionFactors.AddItem(Convert.ToString(FireCodes.SuppressionFactor["description"]));
                    ViewModel.lstSuppressionFactors.SetItemData(ViewModel.lstSuppressionFactors.GetNewIndex(), Convert.ToInt32(FireCodes.SuppressionFactor["suppression_factor_code"]));
                    FireCodes.SuppressionFactor.MoveNext();
                };
            }

            //Structure - Building Info
            if (ViewModel.CurrReport == IncidentMain.FIRESTRUCTURE)
            {
                //General Occupancy Combo
                FireCodes.GetPropertyUseClass();

                while (!FireCodes.PropertyUseClassRS.EOF)
                {
                    ViewModel.cboGeneralPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUseClassRS["class_description"]));
                    ViewModel.cboGeneralPropertyUse.SetItemData(ViewModel.cboGeneralPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
                    FireCodes.PropertyUseClassRS.MoveNext();
                };

                //Building Status Combo
                FireCodes.GetBuildingStatusCodes();

                while (!FireCodes.BuildingStatus.EOF)
                {
                    ViewModel.cboBuildingStatus.AddItem(Convert.ToString(FireCodes.BuildingStatus["description"]));
                    ViewModel.cboBuildingStatus.SetItemData(ViewModel.cboBuildingStatus.GetNewIndex(), Convert.ToInt32(FireCodes.BuildingStatus["building_status_code"]));
                    FireCodes.BuildingStatus.MoveNext();
                };

                //Construction Type Combo
                FireCodes.GetConstructionTypeCodes();

                while (!FireCodes.ConstructionType.EOF)
                {
                    ViewModel.cboConstructionType.AddItem(Convert.ToString(FireCodes.ConstructionType["description"]));
                    ViewModel.cboConstructionType.SetItemData(ViewModel.cboConstructionType.GetNewIndex(), Convert.ToInt32(FireCodes.ConstructionType["construction_type_code"]));
                    FireCodes.ConstructionType.MoveNext();
                };


                //Extinguishing System System Type Combo
                FireCodes.GetFireSystemType("E");

                while (!FireCodes.FireSystemType.EOF)
                {
                    ViewModel.cboSysType.AddItem(Convert.ToString(FireCodes.FireSystemType["description"]));
                    ViewModel.cboSysType.SetItemData(ViewModel.cboSysType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                    FireCodes.FireSystemType.MoveNext();
                };

                //Extinguishing System Effectiveness Combo
                FireCodes.GetEffectiveness("E");

                while (!FireCodes.Effectiveness.EOF)
                {
                    ViewModel.cboExtEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                    ViewModel.cboExtEffectiveness.SetItemData(ViewModel.cboExtEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                    FireCodes.Effectiveness.MoveNext();
                };

                //Extinguishing System Problems listbox
                FireCodes.GetSystemFailure("E");

                while (!FireCodes.SystemFailure.EOF)
                {
                    ViewModel.lstExtFailure.AddItem(Convert.ToString(FireCodes.SystemFailure["description"]));
                    ViewModel.lstExtFailure.SetItemData(ViewModel.lstExtFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure["system_failure_code"]));
                    FireCodes.SystemFailure.MoveNext();
                };

                //Burn Damage & Smoke Damage
                FireCodes.GetBurnDamageCodes();

                while (!FireCodes.BurnDamage.EOF)
                {
                    ViewModel.cboBurnDamage.AddItem(Convert.ToString(FireCodes.BurnDamage["description"]));
                    ViewModel.cboBurnDamage.SetItemData(ViewModel.cboBurnDamage.GetNewIndex(), Convert.ToInt32(FireCodes.BurnDamage["burn_damage_code"]));
                    ViewModel.cboSmokeDamage.AddItem(Convert.ToString(FireCodes.BurnDamage["description"]));
                    ViewModel.cboSmokeDamage.SetItemData(ViewModel.cboSmokeDamage.GetNewIndex(), Convert.ToInt32(FireCodes.BurnDamage["burn_damage_code"]));
                    FireCodes.BurnDamage.MoveNext();
                };

                //Items contributing to fire spread listbox
                FireCodes.GetFirstItemIgnitedCodes();

                while (!FireCodes.FirstItemIgnited.EOF)
                {
                    ViewModel.lstItemContribFireSpread.AddItem(Convert.ToString(FireCodes.FirstItemIgnited["description"]));
                    ViewModel.lstItemContribFireSpread.SetItemData(ViewModel.lstItemContribFireSpread.GetNewIndex(), Convert.ToInt32(FireCodes.FirstItemIgnited["first_item_ignited_code"]));
                    FireCodes.FirstItemIgnited.MoveNext();
                };

                //Equipment Involved listbox
                FireCodes.GetEquipmentInvolvedCodes();

                while (!FireCodes.EquipmentInvolved.EOF)
                {
                    ViewModel.lstEquipInvolvIgnition.AddItem(Convert.ToString(FireCodes.EquipmentInvolved["description"]));
                    ViewModel.lstEquipInvolvIgnition.SetItemData(ViewModel.lstEquipInvolvIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.EquipmentInvolved["equipment_involved_code"]));
                    FireCodes.EquipmentInvolved.MoveNext();
                };
            }

            //Mobile Specific Property Use
            if (ViewModel.CurrReport == IncidentMain.FIREMOBILE)
            {
                FireCodes.GetMobileMakeCode();

                while (!FireCodes.MobileMakeCode.EOF)
                {
                    ViewModel.cboMobileMake.AddItem(IncidentMain.Clean(FireCodes.MobileMakeCode["description"]) + ": " + IncidentMain.Clean(FireCodes.MobileMakeCode["mobile_make_code"]));
                    FireCodes.MobileMakeCode.MoveNext();
                };

                FireCodes.GetPropertyUseByClass(7);
                FireCodes.PropertyUse.Open();

                while (!FireCodes.PropertyUse.EOF)
                {
                    ViewModel.cboMobilePropType.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                    ViewModel.cboMobilePropType.SetItemData(ViewModel.cboMobilePropType.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                    FireCodes.PropertyUse.MoveNext();
                };


                while (!FireCodes.AreaOfOrigin.EOF)
                {
                    ViewModel.cboAreaOfOrigin.AddItem(IncidentMain.Clean(FireCodes.AreaOfOrigin["description"]));
                    ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                    FireCodes.AreaOfOrigin.MoveNext();
                };
                //Hide Structure Only Controls
                ViewModel.frmFireOnly.Visible = false;
                ViewModel.frmPropLoss.Visible = false;
            }

            //Outside Fire
            if (ViewModel.CurrReport == IncidentMain.FIREOUTSIDE)
            {

                //Heat Source Code
                FireCodes.GetHeatSourceCodes();

                while (!FireCodes.HeatSource.EOF)
                {
                    ViewModel.cboOSHeatSource.AddItem(Convert.ToString(FireCodes.HeatSource["description"]).Trim());
                    ViewModel.cboOSHeatSource.SetItemData(ViewModel.cboOSHeatSource.GetNewIndex(), Convert.ToInt32(FireCodes.HeatSource["heat_source_code"]));
                    FireCodes.HeatSource.MoveNext();
                };

                //General Cause of Ignition combo
                FireCodes.GetCauseOfIgnitionClass();

                while (!FireCodes.CauseOfIgnitionClassRS.EOF)
                {
                    ViewModel.cboOSCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnitionClassRS["description"]).Trim());
                    ViewModel.cboOSCauseOfIgnition.SetItemData(ViewModel.cboOSCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnitionClassRS["cause_of_ignition_class"]));
                    FireCodes.CauseOfIgnitionClassRS.MoveNext();
                };

                //Area Units combo
                CommonCodes.GetAreaUnits();

                while (!CommonCodes.AreaUnits.EOF)
                {
                    ViewModel.cboOSAreaUnits.AddItem(Convert.ToString(CommonCodes.AreaUnits["area_description"]).Trim());
                    ViewModel.cboOSAreaUnits.SetItemData(ViewModel.cboOSAreaUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
                    CommonCodes.AreaUnits.MoveNext();
                };

                //Material Involved combo
                FireCodes.GetMaterialTypeCodes();

                while (!FireCodes.MaterialType.EOF)
                {
                    ViewModel.cboOSMaterialInvolved.AddItem(Convert.ToString(FireCodes.MaterialType["description"]).Trim());
                    ViewModel.cboOSMaterialInvolved.SetItemData(ViewModel.cboOSMaterialInvolved.GetNewIndex(), Convert.ToInt32(FireCodes.MaterialType["material_type_code"]));
                    FireCodes.MaterialType.MoveNext();
                };

                if (ViewModel.optType[2].Checked)
                {
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;
                    for (int i = 0; i <= ViewModel.cboOSMaterialInvolved.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboOSMaterialInvolved.GetItemData(i) == 1)
                        { //Vegetation

                            ViewModel.cboOSMaterialInvolved.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else if (ViewModel.optType[3].Checked)
                {
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;
                    for (int i = 0; i <= ViewModel.cboOSMaterialInvolved.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboOSMaterialInvolved.GetItemData(i) == 2)
                        { //Dumpster

                            ViewModel.cboOSMaterialInvolved.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    ViewModel.lbOSMaterialInvolved.Visible = true;
                    ViewModel.cboOSMaterialInvolved.Visible = true;
                }
            }

            FireCodes = null;
            CommonCodes = null;
            ViewModel.FirstTime = 0;
            CheckComplete();
            //CheckNameComplete();
        }

        private void LoadRuptureLists()
        {
            //Load all appropriate combo and listboxes for
            //Current Rupture Report Type
            //Stored Procedures may bring back multiple resultsets
            TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve<clsCommonCodes>();
            ViewModel.FirstTime = -1;
            //Common fields
            ViewModel.rtxNarration.Text = "";
            //Names
            ClearName();
            ViewModel.cboAreaOfOrigin.Items.Clear();
            ViewModel.lstPhysicalContribFactors.Items.Clear();
            ViewModel.lstHumanContribFactors.Items.Clear();
            ViewModel.lstSuppressionFactors.Items.Clear();
            ViewModel.cboGeneralPropertyUse.Items.Clear();
            ViewModel.cboSpecificPropertyUse.Items.Clear();
            ViewModel.cboBuildingStatus.Items.Clear();
            ViewModel.cboConstructionType.Items.Clear();
            ViewModel.cboHeatSource.Items.Clear();
            ViewModel.txtFloorOfOrigin.Text = "";
            ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            ViewModel.txtTotalSqFootage.Text = "";
            ViewModel.txtNumberOfStories.Text = "";
            ViewModel.txtNumberOfOccupants.Text = "";
            ViewModel.txtNumberOfBusinesses.Text = "";
            ViewModel.txtPropValue.Text = "";
            ViewModel.txtContentLoss.Text = "";
            ViewModel.txtJobsLost.Text = "";
            ViewModel.txtNoBusinessDisplaced.Text = "";
            ViewModel.txtNoPeopleDisplaced.Text = "";
            ViewModel.txtPropLoss.Text = "";
            ViewModel.txtSqFtSmokeDamage.Text = "";
            ViewModel.lbVesselLength.Visible = false;
            ViewModel.txtVesselLength.Visible = false;
            //    frmPassengerVehicleInfo.Visible = False
            ViewModel.cboMobilePropType.Items.Clear();
            ViewModel.cboAreaOfOrigin.Items.Clear();
            ViewModel.cboMobileMake.Items.Clear();
            ViewModel.cboLicenseState.Items.Clear();
            ViewModel.txtMobilePropValue.Text = "";
            ViewModel.txtVesselLength.Text = "";
            ViewModel.txtVehicleMake.Text = "";
            ViewModel.txtVehicleModel.Text = "";
            ViewModel.txtVehicleYear.Text = "";
            ViewModel.txtVIN.Text = "";
            ViewModel.txtOSAreaAffected.Text = "";
            ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
            ViewModel.cboOSAreaUnits.Items.Clear();

            CommonCodes.GetAddressVerification("X");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboPrefix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                ViewModel.cboSuffix.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            }
            ;

            CommonCodes.GetAddressVerification("S");

            while (!CommonCodes.AddressVerification.EOF)
            {
                ViewModel.cboStreetType.AddItem(IncidentMain.Clean(CommonCodes.AddressVerification["address_code"]));
                CommonCodes.AddressVerification.MoveNext();
            }
            ;

            CommonCodes.GetStateCode();

            while (!CommonCodes.StateRS.EOF)
            {
                ViewModel.cboState.AddItem(Convert.ToString(CommonCodes.StateRS["state_code"]));
                ViewModel.cboLicenseState.AddItem(Convert.ToString(CommonCodes.StateRS["state_code"]));
                CommonCodes.StateRS.MoveNext();
            }
            ;
            //Default to Washington
            for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
            {
                if (ViewModel.cboState.GetListItem(i) == "WA")
                {
                    ViewModel.cboState.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i <= ViewModel.cboLicenseState.Items.Count - 1; i++)
            {
                if (ViewModel.cboLicenseState.GetListItem(i) == "WA")
                {
                    ViewModel.cboLicenseState.SelectedIndex = i;
                    break;
                }
            }

            CommonCodes.GetPeopleDescriptor("R");

            while (!CommonCodes.PeopleDescriptor.EOF)
            {
                ViewModel.cboRace.AddItem(Convert.ToString(CommonCodes.PeopleDescriptor["description"]));
                ViewModel.cboRace.SetItemData(ViewModel.cboRace.GetNewIndex(), Convert.ToInt32(CommonCodes.PeopleDescriptor["people_descriptor_code"]));
                CommonCodes.PeopleDescriptor.MoveNext();
            }
            ;

            CommonCodes.GetIncidentRole();

            while (!CommonCodes.IncidentRole.EOF)
            {
                ViewModel.cboRole.AddItem(Convert.ToString(CommonCodes.IncidentRole["description"]));
                ViewModel.cboRole.SetItemData(ViewModel.cboRole.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentRole["incident_role_code"]));
                CommonCodes.IncidentRole.MoveNext();
            }
            ;

            //Common Lists - Structure and Mobile
            if (ViewModel.CurrReport == IncidentMain.RUPTURESTRUCTURE || ViewModel.CurrReport == IncidentMain.RUPTUREMOBILE)
            {
                //Rupture/Explosion Type
                CommonCodes.GetIncidentTypeCodeByClass(2); //Rupture

                while (!CommonCodes.IncidentType.EOF)
                {
                    ViewModel.cboHeatSource.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                    ViewModel.cboHeatSource.SetItemData(ViewModel.cboHeatSource.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                    CommonCodes.IncidentType.MoveNext();
                };

                //Physical Contributing Factors listbox
                FireCodes.GetPhysicalFactorCodes();

                while (!FireCodes.PhysicalFactor.EOF)
                {
                    ViewModel.lstPhysicalContribFactors.AddItem(Convert.ToString(FireCodes.PhysicalFactor["description"]));
                    ViewModel.lstPhysicalContribFactors.SetItemData(ViewModel.lstPhysicalContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.PhysicalFactor["physical_factor_code"]));
                    FireCodes.PhysicalFactor.MoveNext();
                };


                //Human Contributing Factors listbox
                FireCodes.GetHumanFactorCodes();

                while (!FireCodes.HumanFactor.EOF)
                {
                    ViewModel.lstHumanContribFactors.AddItem(Convert.ToString(FireCodes.HumanFactor["description"]));
                    ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.HumanFactor["human_factor_code"]));
                    FireCodes.HumanFactor.MoveNext();
                };


                //Suppression Factors listbox
                FireCodes.GetSuppressionFactorCodes();

                while (!FireCodes.SuppressionFactor.EOF)
                {
                    ViewModel.lstSuppressionFactors.AddItem(Convert.ToString(FireCodes.SuppressionFactor["description"]));
                    ViewModel.lstSuppressionFactors.SetItemData(ViewModel.lstSuppressionFactors.GetNewIndex(), Convert.ToInt32(FireCodes.SuppressionFactor["suppression_factor_code"]));
                    FireCodes.SuppressionFactor.MoveNext();
                };
            }

            //Structure - Building Info
            if (ViewModel.CurrReport == IncidentMain.RUPTURESTRUCTURE)
            {
                //General Occupancy Combo
                FireCodes.GetPropertyUseClass();

                while (!FireCodes.PropertyUseClassRS.EOF)
                {
                    ViewModel.cboGeneralPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUseClassRS["class_description"]));
                    ViewModel.cboGeneralPropertyUse.SetItemData(ViewModel.cboGeneralPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
                    FireCodes.PropertyUseClassRS.MoveNext();
                };

                //Building Status Combo
                FireCodes.GetBuildingStatusCodes();

                while (!FireCodes.BuildingStatus.EOF)
                {
                    ViewModel.cboBuildingStatus.AddItem(Convert.ToString(FireCodes.BuildingStatus["description"]));
                    ViewModel.cboBuildingStatus.SetItemData(ViewModel.cboBuildingStatus.GetNewIndex(), Convert.ToInt32(FireCodes.BuildingStatus["building_status_code"]));
                    FireCodes.BuildingStatus.MoveNext();
                };

                //Construction Type Combo
                FireCodes.GetConstructionTypeCodes();

                while (!FireCodes.ConstructionType.EOF)
                {
                    ViewModel.cboConstructionType.AddItem(Convert.ToString(FireCodes.ConstructionType["description"]));
                    ViewModel.cboConstructionType.SetItemData(ViewModel.cboConstructionType.GetNewIndex(), Convert.ToInt32(FireCodes.ConstructionType["construction_type_code"]));
                    FireCodes.ConstructionType.MoveNext();
                };
            }
            //Mobile Specific Property Use
            if (ViewModel.CurrReport == IncidentMain.RUPTUREMOBILE)
            {
                FireCodes.GetMobileMakeCode();

                while (!FireCodes.MobileMakeCode.EOF)
                {
                    ViewModel.cboMobileMake.AddItem(IncidentMain.Clean(FireCodes.MobileMakeCode["description"]) + ": " + IncidentMain.Clean(FireCodes.MobileMakeCode["mobile_make_code"]));
                    FireCodes.MobileMakeCode.MoveNext();
                };
                FireCodes.GetPropertyUseByClass(7);
                FireCodes.PropertyUse.Open();

                while (!FireCodes.PropertyUse.EOF)
                {
                    ViewModel.cboMobilePropType.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                    ViewModel.cboMobilePropType.SetItemData(ViewModel.cboMobilePropType.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                    FireCodes.PropertyUse.MoveNext();
                };

                while (!FireCodes.AreaOfOrigin.EOF)
                {
                    ViewModel.cboAreaOfOrigin.AddItem(IncidentMain.Clean(FireCodes.AreaOfOrigin["description"]));
                    ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                    FireCodes.AreaOfOrigin.MoveNext();
                };
                //Hide Structure Only Controls
                ViewModel.frmFireOnly.Visible = false;
                ViewModel.frmPropLoss.Visible = false;
            }

            //Outside Fire
            if (ViewModel.CurrReport == IncidentMain.RUPTUREOUTSIDE)
            {
                //Rupture/Explosion Type
                CommonCodes.GetIncidentTypeCodeByClass(2); //Rupture

                while (!CommonCodes.IncidentType.EOF)
                {
                    ViewModel.cboOSSpecCauseOfIgnition.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                    ViewModel.cboOSSpecCauseOfIgnition.SetItemData(ViewModel.cboOSSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                    CommonCodes.IncidentType.MoveNext();
                };
                //Area Units combo
                CommonCodes.GetAreaUnits();

                while (!CommonCodes.AreaUnits.EOF)
                {
                    ViewModel.cboOSAreaUnits.AddItem(Convert.ToString(CommonCodes.AreaUnits["area_description"]).Trim());
                    ViewModel.cboOSAreaUnits.SetItemData(ViewModel.cboOSAreaUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
                    CommonCodes.AreaUnits.MoveNext();
                };
            }

            FireCodes = null;
            CommonCodes = null;
            ViewModel.FirstTime = 0;
            CheckComplete();
            //CheckNameComplete();

        }

        public void FormatFrame()
        {
            //If Multiple Use Frame Then Format Controls

            //    CheckReportStatus
            string switchVar = ViewModel.CurrFrame.Name;
            if (switchVar == "frmFireType")
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.FIRE:
                        ViewModel.optType[0].Text = "Structure";
                        ViewModel.optType[1].Text = "Mobile Property";
                        ViewModel.optType[2].Text = "Grass/Brush/Trees";
                        ViewModel.optType[3].Text = "Dumpster";
                        ViewModel.optType[4].Text = "Other Outside Fire";
                        ViewModel.lbFireType.Text = "SELECT FIRE TYPE";
                        break;
                    case IncidentMain.RUPTURE:
                        ViewModel.optType[0].Text = "Structure";
                        ViewModel.optType[1].Text = "Mobile Property";
                        ViewModel.optType[2].Text = "Other Outside Rupture/Explosion";
                        ViewModel.optType[3].Visible = false;
                        ViewModel.optType[4].Visible = false;
                        ViewModel.lbFireType.Text = "SELECT RUPTURE/EXPLOSION TYPE";
                        break;
                    case IncidentMain.FIREEXPOSURE:
                        ViewModel.CurrReport = IncidentMain.FIRESTRUCTURE;
                        ViewModel.ADDRESSCORRECTION = -1;
                        ViewModel.ExposureOccured = -1;
                        ViewModel.lbFrameTitle[9].Text = "FIRE EXPOSURE ADDRESS";
                        StepNext();
                        return;
                }
            }
            else if (switchVar == "frmReportStatus")
            {
                LoadReportStatus();
                FlipImage();


            }

            //Display Current Frame
            ViewModel.CurrFrame.Visible = true;


            //Set Navigation Buttons
            switch (ViewModel.CurrFrame.Name)
            {
                case "frmFireType":
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = false;
                    if (ViewModel.ReportStarted != 0)
                    {
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                    }
                    else
                    {
                        ViewModel.NavButton[2].Visible = false;
                        ViewModel.lbNavMessage.Visible = true;
                        ViewModel.lbNavMessage.Text = "Make Selection";
                    }
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = false;
                    break;
                case "frmReportStatus":
                    ViewModel.NavButton[0].Visible = false;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = false;
                    ViewModel.lbNavMessage.Visible = true;
                    ViewModel.lbNavMessage.Text = "Save Report!";
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = false;
                    break;
                case "frmExposureAddress":
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.lbNavMessage.Visible = false;
                    ViewModel.NavButton[3].Visible = false;
                    ViewModel.NavButton[4].Visible = false;
                    break;
                default:
                    ViewModel.NavButton[0].Visible = true;
                    ViewModel.NavButton[1].Visible = true;
                    ViewModel.NavButton[2].Visible = true;
                    ViewModel.lbNavMessage.Visible = false;
                    ViewModel.NavButton[3].Visible = true;
                    ViewModel.NavButton[4].Visible = false;

                    break;
            }
            //Set starting cursor position
            switch (ViewModel.CurrFrame.Name)
            {
                case "frmBldgInfo":
                    ViewManager.SetCurrent(ViewModel.cboGeneralPropertyUse);
                    break;
                case "frmFireInfo":
                    ViewManager.SetCurrent(ViewModel.cboAreaOfOrigin);
                    //Case "frmLoss" 
                    // txtSqFtBurned.SetFocus 
                    break;
                case "frmNarration":
                    ViewManager.SetCurrent(ViewModel.rtxNarration);
                    break;
                case "frmName":
                    ViewManager.SetCurrent(ViewModel.txtFirstName);
                    CheckNameComplete();
                    break;
                case "frmOutsideInfo":
                    ViewManager.SetCurrent(ViewModel.cboOSHeatSource);
                    break;
                case "frmMobileProp":
                    ViewManager.SetCurrent(ViewModel.cboMobilePropType);
                    break;
                case "frmExposureAddress":
                    //            txtXHouseNumber.SetFocus 
                    break;
            }

            //Test for Rupture formating
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.RUPTURE:
                case IncidentMain.RUPTURESTRUCTURE:
                case IncidentMain.RUPTUREMOBILE:
                case IncidentMain.RUPTUREOUTSIDE:
                    FlipRuptureColors();
                    break;
            }
            //Don't display Fire Type frame for Fire Structure Exposure
        }

        private void FlipRuptureColors()
        {
            //Flip Frame Colors and Visible Fields for Rupture

            switch (ViewModel.CurrFrame.Name)
            {
                case "frmFireType":
                    //ViewModel.frmFireType.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.Frame1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[5].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[5].Text = "RUPTURE/EXPLOSION TYPE";
                    ViewModel.lbFireType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    for (int i = 0; i <= 4; i++)
                    {
                        ViewModel.optType[i].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                        //ViewModel.optType[i].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    }
                    ViewModel.chkAddressCorrection.Visible = false;
                    break;
                case "frmBldgInfo":
                    //ViewModel.frmBldgInfo.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmAlarmInfo.Visible = false;
                    ViewModel.frmExtinguishingSysInfo.Visible = false;
                    ViewModel.chkRental.Visible = false;
                    ViewModel.lbNumberOfUnits.Visible = false;
                    ViewModel.txtNumberOfUnits.Visible = false;
                    ViewModel.lbFrameTitle[4].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbGenOccupancy.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSpecificOccupancy.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbBldgStatus.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbConstructionType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbTotSqFt.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbNoStories.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbBasementLevel.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbNoOccupants.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbNoBusinesses.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbPropValue.ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
                case "frmMobileProp":
                    //ViewModel.frmMobileProp.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.frmPassengerVehicleInfo.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[8].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbMobilePropType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbMobilePropValue.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVesselLength.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.frmPassengerVehicleInfo.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOtherMake.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleMake.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleModel.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleYear.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVIN.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbLicenseSt.ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
                case "frmFireInfo":
                    //ViewModel.frmFireInfo.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.frmFireOnly.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.frmBsmtorAttic.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.optFloor[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.optFloor[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optFloor[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.optFloor[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //ViewModel.optFloor[2].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optFloor[2].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[0].Text = "RUPTURE/EXPLOSION INFORMATION";
                    ViewModel.lbAreaOrigin.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHeatSource.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHeatSource.Text = "RUPTURE/EXPLOSION TYPE";
                    ViewModel.lbFirstIgnited.Visible = false;
                    ViewModel.cboFirstItemIgnited.Visible = false;
                    ViewModel.lbGenCauseIgnition.Visible = false;
                    ViewModel.cboGenCauseOfIgnition.Visible = false;
                    ViewModel.lbSpecCauseOfIgnition.Visible = false;
                    ViewModel.cboSpecCauseOfIgnition.Visible = false;
                    ViewModel.lbPhyContribFactors.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHumanContribFactors.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSuppressFactors.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFlOfOrigin.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbBurnDamage.Visible = false;
                    ViewModel.cboBurnDamage.Visible = false;
                    ViewModel.lbSmokeDamage.Visible = false;
                    ViewModel.cboSmokeDamage.Visible = false;
                    ViewModel.lbContribFireSpread.Visible = false;
                    ViewModel.lstItemContribFireSpread.Visible = false;
                    ViewModel.lbEquipInvolvIgnition.Visible = false;
                    ViewModel.lstEquipInvolvIgnition.Visible = false;

                    break;
                case "frmOutsideInfo":
                    //ViewModel.frmOutsideInfo.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[1].Text = "OUTSIDE RUPTURE/EXPLOSION";
                    ViewModel.lbOSHeatSource.Visible = false;
                    ViewModel.cboOSHeatSource.Visible = false;
                    ViewModel.lbOSCauseOfIgnition.Visible = false;
                    ViewModel.cboOSCauseOfIgnition.Visible = false;
                    ViewModel.lbSpecOSCauseOfIgnition.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSpecOSCauseOfIgnition.Text = "RUPTURE/EXPLOSION TYPE";
                    ViewModel.lbOSContentLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSAreaAffected.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSAreaUnits.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;

                    break;
                case "frmLoss":
                    //ViewModel.frmLoss.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.frmPropLoss.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[6].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[6].Text = "RUPTURE/EXPLOSION LOSS";
                    ViewModel.lbSqFtBurned.Visible = false;
                    ViewModel.txtSqFtBurned.Visible = false;
                    ViewModel.lbSqFtSmokeDamage.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSqFtSmokeDamage.Text = "SQ FOOT DAMAGED";
                    ViewModel.lbNoBusinessDisplaced.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbNoPeopleDisplaced.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbJobsLost.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbPropLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbContentLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
                case "frmNarration":
                    //ViewModel.frmNarration.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[7].ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
                case "frmName":
                    //ViewModel.frmName.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[3].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFirstName.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbLastName.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbMI.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHouseNum.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbPrefix.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbStreetName.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbStreetType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSuffix.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbCity.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbState.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblZipcode.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbRole.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbBirthdate.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbGender.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //ViewModel.frmGender.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.optGender[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optGender[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //ViewModel.optGender[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optGender[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbRace.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbEthnicity.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //ViewModel.frmEthnicity.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    //ViewModel.optEthnicity[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optEthnicity[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //ViewModel.optEthnicity[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optEthnicity[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHomePhone.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbWorkPhone.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbWorkPlace.ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
                case "frmReportStatus":
                    //ViewModel.frmReportStatus.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFrameTitle[2].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbFrameTitle[2].Text = "RUPTURE REPORT STATUS";
                    ViewModel.lbIncidentNumberTitle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.Label9.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbReportByTitle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.Label7.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblIncidentNumber.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbRSCurrReportType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbReportedBy.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblEmployeeID.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblPosition.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblUnit.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lblShift.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lstMessage.ForeColor = IncidentMain.Shared.RUPTUREFONT;


                    break;
            }

        }

        public void FlipImage()
        {
            //Generate random image pick

            VBMath.Randomize();
            int ImageNumber = Convert.ToInt32(Math.Floor((double)(35 * VBMath.Rnd() + 1)));
            string ImageFile = IncidentMain.IMAGEPATH + ImageNumber.ToString() + ".jpg";

        }


        private void ClearName()
        {
            //Clear all name fields
            ViewModel.txtFirstName.Text = "";
            ViewModel.txtLastName.Text = "";
            ViewModel.txtMI.Text = "";
            ViewModel.txtBusinessName.Text = "";
            ViewModel.txtHouseNumber.Text = "";
            ViewModel.txtStreetName.Text = "";
            ViewModel.txtCity.Text = "Tacoma";
            ViewModel.txtZipcode.Text = "";
            ViewModel.calBirthdate.Value = DateTime.Now;
            //Start Max is currentdate
            ViewModel.calBirthdate.MaxDate = ViewModel.calBirthdate.Value.Date;
            ViewModel.txtHomePhone.Text = "";
            ViewModel.txtWorkPhone.Text = "";
            ViewModel.txtWorkPlace.Text = "";
            ViewModel.optGender[0].Checked = false;
            ViewModel.optGender[1].Checked = false;
            ViewModel.optEthnicity[0].Checked = false;
            ViewModel.optEthnicity[1].Checked = true;
            ViewModel.cboPrefix.Items.Clear();
            ViewModel.cboSuffix.Items.Clear();
            ViewModel.cboStreetType.Items.Clear();
            ViewModel.cboState.Items.Clear();
            ViewModel.cboRace.Items.Clear();
            ViewModel.cboRole.Items.Clear();


        }

        public void StepBack()
        {
            //Navigate to Previous Frame
            ViewModel.CurrFrame.Visible = false;

            if (ViewModel.CurrReport == IncidentMain.FIRE || ViewModel.CurrReport == IncidentMain.FIRESTRUCTURE || ViewModel.CurrReport == IncidentMain.FIREMOBILE || ViewModel.CurrReport == IncidentMain.FIREOUTSIDE)
            {
                //Determine Current Frame and set for next frame
                string switchVar = ViewModel.CurrFrame.Name;
                if (switchVar == "frmExposureAddress")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar == "frmBldgInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar == "frmFireInfo")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmBldgInfo;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            break;
                    }
                }
                else if (switchVar == "frmLoss")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmFireInfo;
                            ViewModel.frmFireOnly.Visible = true;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmFireInfo;
                            break;
                    }
                }
                else if (switchVar == "frmMobileProp")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar == "frmOutsideInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar == "frmNarration")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmPropLoss.Visible = true;
                            break;
                        case IncidentMain.FIREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmPropLoss.Visible = false;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmOutsideInfo;
                            break;
                    }
                }
                else if (switchVar == "frmName")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar == "frmReportStatus")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else
                {
                    //Where are we?? - I guess we'll take the default!
                    ViewManager.ShowMessage("Error determining next report step", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                //Rupture/Explosion Report - Select next frame
                string switchVar_2 = ViewModel.CurrFrame.Name;
                if (switchVar_2 == "frmBldgInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar_2 == "frmFireInfo")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmBldgInfo;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            break;
                    }
                }
                else if (switchVar_2 == "frmLoss")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmFireInfo;
                            ViewModel.frmFireOnly.Visible = true;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmFireInfo;
                            break;
                    }
                }
                else if (switchVar_2 == "frmMobileProp")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar_2 == "frmOutsideInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireType;
                }
                else if (switchVar_2 == "frmNarration")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmPropLoss.Visible = true;
                            break;
                        case IncidentMain.RUPTUREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmPropLoss.Visible = false;
                            break;
                        default:
                            ViewModel.CurrFrame = ViewModel.frmOutsideInfo;
                            break;
                    }
                }
                else if (switchVar_2 == "frmName")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar_2 == "frmReportStatus")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else
                {
                    //Where are we?? - I guess we'll take the default!
                    ViewManager.ShowMessage("Error determining next report step", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            FormatFrame();


        }

        public void StepNext()
        {
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            //Navigate to Next Reporting Step
            //Or Initialize Unit Report on Startup
            ViewModel.CurrFrame.Visible = false;

            //Select Type of Report (Fire or Rupture)
            if (ViewModel.CurrReport == IncidentMain.FIRE || ViewModel.CurrReport == IncidentMain.FIRESTRUCTURE || ViewModel.CurrReport == IncidentMain.FIREMOBILE || ViewModel.CurrReport == IncidentMain.FIREOUTSIDE)
            {
                //Determine Current Frame and set for next frame
                string switchVar = ViewModel.CurrFrame.Name;
                if (switchVar == "frmFireType")
                {
                    //Fire Report - Select Fire Type
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            if (ViewModel.ADDRESSCORRECTION != 0)
                            {
                                ViewModel.CurrFrame = ViewModel.frmExposureAddress;
                            }
                            else
                            {
                                ViewModel.CurrFrame = ViewModel.frmBldgInfo;
                            }
                            //Check for Fire Structure Exposures 
                            if (ViewModel.chkExposures.Visible)
                            {
                                if (ViewModel.chkExposures.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                {
                                    //Add new ReportLogRecord
                                    double tempForVar = Conversion.Val(ViewModel.txtNumberExposures.Text);
                                    for (int i = 1; i <= tempForVar; i++)
                                    {
                                        ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                        ReportLog.ReportReferenceID = 0;
                                        ReportLog.ReportType = IncidentMain.FIREEXPOSURE;
                                        ReportLog.ReportStatus = 1;
                                        ReportLog.ResponsibleUnit = ViewModel.CurrUnit;
                                        ReportLog.AddNew();
                                    }
                                }
                            }
                            //Check for Mobile involved 
                            if (ViewModel.chkMobileInvolved.Visible)
                            {
                                if (ViewModel.chkMobileInvolved.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                                {
                                    //Add new ReportLogRecord
                                    ReportLog.RLIncidentID = ViewModel.CurrIncident;
                                    ReportLog.ReportReferenceID = 0;
                                    ReportLog.ReportType = IncidentMain.FIREMOBILE;
                                    ReportLog.ReportStatus = 1;
                                    ReportLog.ResponsibleUnit = ViewModel.CurrUnit;
                                    if (ReportLog.AddNew() != 0)
                                    {
                                        ViewModel.MobileInvolved = -1;
                                        ViewModel.MobileReportID = ReportLog.ReportLogID;
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error attempting to create Mobile Fire Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                        ViewModel.MobileInvolved = 0;
                                    }
                                }
                                else
                                {
                                    ViewModel.MobileInvolved = 0;
                                }
                            }
                            else
                            {
                                ViewModel.MobileInvolved = 0;
                            }


                            break;
                        case IncidentMain.FIREMOBILE:
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            if (ViewModel.ADDRESSCORRECTION != 0)
                            {
                                ViewModel.CurrFrame = ViewModel.frmExposureAddress;
                            }
                            else
                            {
                                ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            }
                            break;
                        case IncidentMain.FIREOUTSIDE:
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            if (ViewModel.ADDRESSCORRECTION != 0)
                            {
                                ViewModel.CurrFrame = ViewModel.frmExposureAddress;
                            }
                            else
                            {
                                ViewModel.CurrFrame = ViewModel.frmOutsideInfo;
                            }
                            break;
                    }
                }
                else if (switchVar == "frmExposureAddress")
                {
                    ViewModel.ADDRESSCORRECTION = 0;
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmBldgInfo;
                            break;
                        case IncidentMain.FIREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            break;
                        case IncidentMain.FIREOUTSIDE:
                            ViewModel.CurrFrame = ViewModel.frmOutsideInfo;
                            break;
                    }
                }
                else if (switchVar == "frmBldgInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireInfo;
                    ViewModel.frmFireOnly.Visible = true;
                }
                else if (switchVar == "frmMobileProp")
                {
                    if (ViewModel.cboMobilePropType.SelectedIndex == -1)
                    {
                        ViewManager.ShowMessage("You must select Mobile Property Type to continue", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                        ViewModel.CurrFrame = ViewModel.frmMobileProp;

                    }
                    else
                    {
                        ViewModel.CurrFrame = ViewModel.frmFireInfo;
                        ViewModel.frmFireOnly.Visible = false;
                    }
                }
                else if (switchVar == "frmFireInfo")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmLoss.Visible = true;
                            ViewModel.frmPropLoss.Visible = true;
                            break;
                        case IncidentMain.FIREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmLoss.Visible = true;
                            break;
                    }
                }
                else if (switchVar == "frmLoss")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar == "frmMobileProp")
                {
                    ViewModel.CurrFrame = ViewModel.frmLoss;
                    ViewModel.frmLoss.Visible = true;
                }
                else if (switchVar == "frmOutsideInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar == "frmName")
                {
                    ViewModel.CurrFrame = ViewModel.frmReportStatus;
                }
                else if (switchVar == "frmNarration")
                {
                    ViewModel.CurrFrame = ViewModel.frmReportStatus;
                    // Put image on frame
                    FlipImage();
                }
                else if (switchVar == "frmReportStatus")
                {
                    if (ViewModel.MobileInvolved != 0)
                    {
                        if (ReportLog.GetReportLog(ViewModel.MobileReportID) != 0)
                        {
                            ViewModel.CurrReport = ReportLog.ReportType;
                            ViewModel.CurrIncident = ReportLog.RLIncidentID;
                            ViewModel.CurrUnit = ReportLog.ResponsibleUnit;
                            LoadLists();
                            ViewModel.PrevReport = ViewModel.CurrReport;
                            ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            ViewModel.MobileInvolved = 0;
                            IncidentMain.Shared.gNewReportID = ViewModel.MobileReportID;
                            ViewModel.MobileReportID = 0;
                        }
                        else
                        {
                            ViewManager.ShowMessage("Error Retrieving Mobile Fire Report log record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            // Unload Me
                        }
                    }

                }
                else
                {
                    //Where are we?? - I guess we'll take the default!
                    ViewManager.ShowMessage("Error determining next report step", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
            else
            {
                //Rupture/Explosion Report - Select next frame
                string switchVar_2 = ViewModel.CurrFrame.Name;
                if (switchVar_2 == "frmFireType")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmBldgInfo;
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadRuptureLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadRuptureLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            break;
                        case IncidentMain.RUPTUREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmMobileProp;
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadRuptureLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadRuptureLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            break;
                        case IncidentMain.RUPTUREOUTSIDE:
                            ViewModel.CurrFrame = ViewModel.frmOutsideInfo;
                            if (~ViewModel.ReportStarted != 0)
                            {
                                LoadRuptureLists();
                                ViewModel.ReportStarted = -1;
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            else if (ViewModel.PrevReport != ViewModel.CurrReport)
                            {
                                LoadRuptureLists();
                                ViewModel.PrevReport = ViewModel.CurrReport;
                            }
                            break;
                    }
                }
                else if (switchVar_2 == "frmBldgInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireInfo;
                    ViewModel.frmFireOnly.Visible = true;
                }
                else if (switchVar_2 == "frmMobileProp")
                {
                    ViewModel.CurrFrame = ViewModel.frmFireInfo;
                    ViewModel.frmFireOnly.Visible = false;
                }
                else if (switchVar_2 == "frmFireInfo")
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.RUPTURESTRUCTURE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmLoss.Visible = true;
                            ViewModel.frmPropLoss.Visible = true;
                            break;
                        case IncidentMain.RUPTUREMOBILE:
                            ViewModel.CurrFrame = ViewModel.frmLoss;
                            ViewModel.frmLoss.Visible = true;
                            break;
                    }
                }
                else if (switchVar_2 == "frmLoss")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar_2 == "frmMobileProp")
                {
                    ViewModel.CurrFrame = ViewModel.frmLoss;
                    ViewModel.frmLoss.Visible = true;
                }
                else if (switchVar_2 == "frmOutsideInfo")
                {
                    ViewModel.CurrFrame = ViewModel.frmNarration;
                }
                else if (switchVar_2 == "frmName")
                {
                    ViewModel.CurrFrame = ViewModel.frmReportStatus;
                }
                else if (switchVar_2 == "frmNarration")
                {
                    ViewModel.CurrFrame = ViewModel.frmReportStatus;
                    // Put image on frame
                    FlipImage();
                }
                else
                {
                    //Where are we?? - I guess we'll take the default!
                    ViewManager.ShowMessage("Error determining next report step", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }

            FormatFrame();

        }

        public void StepQuit()
        {
            using (var async1 = this.Async(true))
            {
                //Determine Reporting Status
                //And Exit Saving or Exit Not Saving or Cancel Finish Request

                if (CheckComplete() != 0)
                {
                    using (var async2 = this.Async())
                    {
                        switch (ViewModel.CurrReport)
                        {
                            case IncidentMain.FIRE:
                            case IncidentMain.FIRESTRUCTURE:
                            case IncidentMain.FIREMOBILE:
                            case IncidentMain.FIREOUTSIDE:
                                if (SaveFireRecord(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    IncidentMain.Shared.gExportFlag = 1;
                                    IncidentMain.Shared.gPrintReportID = ViewModel.FireReportID;
                                    async2.Append(() =>
                                        {
                                            ViewManager.NavigateToView(
                                                frmReportFire.DefInstance, true);
                                        });

                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                            default:
                                if (SaveRuptureRecord(IncidentMain.COMPLETE) != 0)
                                {
                                    ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRE:
                        case IncidentMain.FIRESTRUCTURE:
                        case IncidentMain.FIREMOBILE:
                        case IncidentMain.FIREOUTSIDE:
                            if (SaveFireRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        default:
                            if (SaveRuptureRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                    }
                }
                async1.Append(() =>
                    {

                        IncidentMain.Shared.gWizCancel = -1;
                        ViewManager.DisposeView(this);
                    });
            }


        }

        public void StepFinish()
        {
            //Determine Reporting Status
            //And Exit Saving or Exit Not Saving or Cancel Finish Request

            if (CheckComplete() != 0)
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.FIRE:
                    case IncidentMain.FIRESTRUCTURE:
                    case IncidentMain.FIREMOBILE:
                    case IncidentMain.FIREOUTSIDE:
                        if (SaveFireRecord(IncidentMain.COMPLETE) != 0)
                        {
                            ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                        }
                        else
                        {
                            ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                        break;
                    default:
                        if (SaveRuptureRecord(IncidentMain.COMPLETE) != 0)
                        {
                            ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                        }
                        else
                        {
                            ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                        break;
                }
            }
            else
            {
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.FIRE:
                    case IncidentMain.FIRESTRUCTURE:
                    case IncidentMain.FIREMOBILE:
                    case IncidentMain.FIREOUTSIDE:
                        if (SaveFireRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                        {
                            ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                        }
                        else
                        {
                            ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                        break;
                    default:
                        if (SaveRuptureRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                        {
                            ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                        }
                        else
                        {
                            ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                        }
                        break;
                }
            }

            IncidentMain.Shared.gWizCancel = 0;
            ViewManager.DisposeView(this);

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAlarmType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAreaOfOrigin_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBuildingStatus_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBurnDamage_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboCityCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboCityCode.SelectedIndex == -1)
            {
                return;
            }
            CheckExposureAddress();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboConstructionType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {

                if (ViewModel.cboConstructionType.SelectedIndex == -1)
                {
                    this.Return();
                    return;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();

                //Test For Property Value Calculation
                if (ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if (ViewModel.txtTotalSqFootage.Text != "")
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if (ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async1.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                                            }
                                            else
                                            {
                                                CheckComplete();
                                            }
                                        });
                                }
                                else
                                {
                                    CheckComplete();
                                }
                            }
                        }
                        else
                        {
                            CheckComplete();
                        }
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    CheckComplete();
                }
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEffectiveness_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboExtEffectiveness_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboFirstItemIgnited_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboGenCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //General Cause of Ignition has been chosen
            //Load Specific Cause of Ignition
            //Notify User that this data has been changed
            TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
            int CauseClass = 0;

            if (ViewModel.cboGenCauseOfIgnition.SelectedIndex == -1)
            {
                return;
            }

            int CauseType = ViewModel.cboGenCauseOfIgnition.GetItemData(ViewModel.cboGenCauseOfIgnition.SelectedIndex);

            if (ViewModel.cboSpecCauseOfIgnition.SelectedIndex > -1)
            {
                FireCodes.GetCauseOfIgnitionByCode(ViewModel.cboSpecCauseOfIgnition.GetItemData(ViewModel.cboSpecCauseOfIgnition.SelectedIndex));
                if (Convert.ToDouble(FireCodes.CauseOfIgnition["cause_of_ignition_class"]) == CauseType)
                {
                    return;
                } //No Changes
            }
            ViewModel.cboSpecCauseOfIgnition.Items.Clear();
            ViewModel.cboSpecCauseOfIgnition.Enabled = true;

            if (ViewModel.ExposureOccured != 0)
            {
                ViewModel.cboSpecCauseOfIgnition.AddItem("Exposure Fire");
                ViewModel.cboSpecCauseOfIgnition.SetItemData(ViewModel.cboSpecCauseOfIgnition.GetNewIndex(), 35);
                ViewModel.cboSpecCauseOfIgnition.Enabled = false;
            }
            else
            {
                FireCodes.GetCauseOfIgnitionByClass(CauseType);

                while (!FireCodes.CauseOfIgnition.EOF)
                {
                    //Non Exposure Fire - don't list exposure as a specific cause
                    if (Convert.ToDouble(FireCodes.CauseOfIgnition["cause_of_ignition_code"]) != 35)
                    {
                        ViewModel.cboSpecCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnition["description"]));
                        ViewModel.cboSpecCauseOfIgnition.SetItemData(ViewModel.cboSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_code"]));
                    }
                    FireCodes.CauseOfIgnition.MoveNext();
                };

                ViewModel.cboSpecCauseOfIgnition.SelectedIndex = -1;
            }
            FireCodes = null;
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboGeneralPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //General Property Use has been chosen
                //Load Specific Property Use and Area of Origin
                //Notify User that this data has been changed
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

                if (ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
                {
                    this.Return();
                    return;
                }

                int GenType = ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse.SelectedIndex);

                //Check to determine if General Prop Changed
                //    If cboSpecificPropertyUse.ListIndex > -1 Then
                //        FireCodes.GetPropertyUseByCode cboSpecificPropertyUse.ItemData(cboSpecificPropertyUse.ListIndex)
                //        If FireCodes.PropertyUse("property_use_class") = GenType Then Exit Sub   'No Changes
                //    End If
                //clear specific property use and area of origin combo boxes
                ViewModel.cboSpecificPropertyUse.Items.Clear();
                ViewModel.cboAreaOfOrigin.Items.Clear();


                FireCodes.GetPropertyUseByClass(GenType);

                while (!FireCodes.PropertyUse.EOF)
                {
                    ViewModel.cboSpecificPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                    ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                    FireCodes.PropertyUse.MoveNext();
                }
                ;


                while (!FireCodes.AreaOfOrigin.EOF)
                {
                    ViewModel.cboAreaOfOrigin.AddItem(Convert.ToString(FireCodes.AreaOfOrigin["description"]));
                    ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                    FireCodes.AreaOfOrigin.MoveNext();
                }
                ;

                //Test For Property Value Calculation
                if (ViewModel.cboConstructionType.SelectedIndex != -1)
                {
                    if (ViewModel.txtTotalSqFootage.Text != "")
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if (ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async1.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                                            }
                                            else
                                            {
                                                CheckComplete();
                                            }
                                        });
                                }
                                else
                                {
                                    CheckComplete();
                                }
                            }
                        }
                        else
                        {
                            CheckComplete();
                        }
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    CheckComplete();
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboHeatSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInitiatingDevice_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMobileMake_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboMobileMake.SelectedIndex != -1)
            {
                if (ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == "OO")
                { //Other Make

                    ViewModel.lbOtherMake.Visible = true;
                    ViewModel.txtVehicleMake.Visible = true;
                }
                else
                {
                    ViewModel.lbOtherMake.Visible = false;
                    ViewModel.txtVehicleMake.Visible = false;
                    ViewModel.txtVehicleMake.Text = "";
                }
            }
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboMobilePropType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Check for Display of Passenger or WaterVessel Controls
            ViewModel.lbVesselLength.Visible = false;
            ViewModel.txtVesselLength.Visible = false;
            //  frmPassengerVehicleInfo.Visible = False
            switch (ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex))
            {
                //        Case 55 'Passenger Vehicle
                //            frmPassengerVehicleInfo.Visible = True
                case 62: //Water Vessel 

                    ViewModel.lbVesselLength.Visible = true;
                    ViewModel.txtVesselLength.Visible = true;
                    //            frmPassengerVehicleInfo.Visible = False 
                    break;
            }

            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSAreaUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //General Cause of Ignition has been chosen
            //Load Specific Cause of Ignition
            //Notify User that this data has been changed
            DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
            ADORecordSetHelper oRec = null;
            ADORecordSetHelper oRecClass = null;
            int CauseClass = 0;
            if (ViewModel.cboOSCauseOfIgnition.SelectedIndex == -1)
            {
                return;
            }

            int CauseType = ViewModel.cboOSCauseOfIgnition.GetItemData(ViewModel.cboOSCauseOfIgnition.SelectedIndex);
            oCmd.Connection = IncidentMain.oIncident;
            oCmd.CommandType = CommandType.Text;

            if (ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex > -1)
            {
                oCmd.CommandText = "spSelect_CauseOfIgnitionCodeByCode " + ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex).ToString();
                oRec = ADORecordSetHelper.Open(oCmd, "");
                if (Convert.ToDouble(oRec["cause_of_ignition_class"]) == CauseType)
                {
                    return;
                } //No Changes
            }
            ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
            oCmd.CommandText = "spSelect_CauseOfIgnitionCodeByClass " + CauseType.ToString();
            oRec = ADORecordSetHelper.Open(oCmd, "");

            while (!oRec.EOF)
            {
                ViewModel.cboOSSpecCauseOfIgnition.AddItem(IncidentMain.Clean(oRec["description"]));
                ViewModel.cboOSSpecCauseOfIgnition.SetItemData(ViewModel.cboOSSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(oRec["cause_of_ignition_code"]));
                oRec.MoveNext();
            };
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSHeatSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSMaterialInvolved_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSSpecCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboPrefix.SelectedIndex != -1)
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboRace.SelectedIndex != -1)
            {
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRole_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboRole.SelectedIndex != -1)
            {
                CheckNameComplete();
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSmokeDamage_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecificPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboStreetType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboStreetType.SelectedIndex != -1)
            {
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboSuffix.SelectedIndex != -1)
            {
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSysType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboXPrefix.SelectedIndex != -1)
            {
                ViewModel.FirstTime = -1;
                ViewModel.cboXSuffix.SelectedIndex = -1;
                ViewModel.FirstTime = 0;
                CheckExposureAddress();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.cboXSuffix.SelectedIndex != -1)
            {
                ViewModel.cboXPrefix.SelectedIndex = -1;
                CheckExposureAddress();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkAddressCorrection_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkAddressCorrection.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.ADDRESSCORRECTION = -1;
                ViewModel.lbFrameTitle[9].Text = "FIRE - ADDRESS CORRECTION";
            }
            else
            {
                ViewModel.ADDRESSCORRECTION = 0;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkAlarmOperated_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //Comes in with unchecked state regardless of whether it's checked or not.

            if (ViewModel.chkAlarmOperated.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
            {
                ViewModel.cboEffectiveness.Visible = false;
                ViewModel.lbEffectiveness.Visible = false;
            }
            else
            {
                ViewModel.cboEffectiveness.Visible = true;
                ViewModel.lbEffectiveness.Visible = true;
            }

            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkExposures_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.chkExposures.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                ViewModel.lbNumExp.Visible = true;
                ViewModel.txtNumberExposures.Visible = true;
                double dbNumericTemp = 0;
                if (ViewModel.txtNumberExposures.Text == "")
                {
                    ViewModel.txtNumberExposures.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.BLACK;
                    ViewModel.NavButton[2].Enabled = false;
                }
                else if (!Double.TryParse(ViewModel.txtNumberExposures.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    ViewModel.txtNumberExposures.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.BLACK;
                    ViewModel.txtNumberExposures.Text = "";
                    ViewModel.NavButton[2].Enabled = false;
                }
                else
                {
                    ViewModel.txtNumberExposures.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.FIREFONT;
                    ViewModel.NavButton[2].Enabled = true;
                }
            }
            else
            {
                ViewModel.lbNumExp.Visible = false;
                ViewModel.txtNumberExposures.Visible = false;
                ViewModel.NavButton[2].Enabled = true;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAbandon_Click(Object eventSender, System.EventArgs eventArgs)
        {
            ViewManager.ShowMessage("All Changes Abandoned - Better Luck Next Time!", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
            IncidentMain.Shared.gWizCancel = -1;
            ViewManager.DisposeView(this);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddNames_Click(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.CurrFrame.Visible = false;
            ViewModel.CurrFrame = ViewModel.frmName;
            ViewModel.NameUpdated = 0;
            FormatFrame();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddNewName_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //SaveName

            if (ViewModel.NameUpdated != 0)
            {
                if (SaveName() != 0)
                {
                    ViewModel.FirstTime = -1;
                    ViewModel.txtFirstName.Text = "";
                    ViewModel.txtLastName.Text = "";
                    ViewModel.txtMI.Text = "";
                    ViewModel.txtBusinessName.Text = "";
                    ViewModel.txtHouseNumber.Text = "";
                    ViewModel.txtStreetName.Text = "";
                    ViewModel.txtCity.Text = "Tacoma";
                    ViewModel.txtZipcode.Text = "";
                    ViewModel.calBirthdate.Value = ViewModel.calBirthdate.MaxDate;
                    ViewModel.txtHomePhone.Text = "";
                    ViewModel.txtWorkPhone.Text = "";
                    ViewModel.txtWorkPlace.Text = "";
                    ViewModel.optGender[0].Checked = false;
                    ViewModel.optGender[1].Checked = false;
                    ViewModel.optEthnicity[0].Checked = false;
                    ViewModel.optEthnicity[1].Checked = true;
                    ViewModel.cboPrefix.SelectedIndex = -1;
                    ViewModel.cboSuffix.SelectedIndex = -1;
                    ViewModel.cboStreetType.SelectedIndex = -1;
                    ViewModel.cboState.SelectedIndex = -1;
                    ViewModel.cboRace.SelectedIndex = -1;
                    ViewModel.cboRole.SelectedIndex = -1;
                    //Default to Washington
                    for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
                    {
                        if (ViewModel.cboState.GetListItem(i) == "WA")
                        {
                            ViewModel.cboState.SelectedIndex = i;
                            break;
                        }
                    }
                    //Default to Tacoma
                    ViewModel.txtCity.Text = "Tacoma";
                    ViewModel.NameUpdated = 0;
                    ViewModel.FirstTime = 0;
                    CheckNameComplete();
                }
                else
                {
                    ViewManager.ShowMessage("Error attempting to save Incident Name Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                //Save Current Report
                int i = 0;
                using (var async2 = this.Async())
                {

                    switch (ViewModel.CurrReport)
                    {
                        case IncidentMain.FIRE:
                        case IncidentMain.FIRESTRUCTURE:
                        case IncidentMain.FIREMOBILE:
                        case IncidentMain.FIREOUTSIDE:
                            if (SaveFireRecord(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                                IncidentMain.Shared.gExportFlag = 1;
                                IncidentMain.Shared.gPrintReportID = ViewModel.FireReportID;
                                async2.Append(() =>
                                    {
                                        ViewManager.NavigateToView(
                                            frmReportFire.DefInstance, true);
                                    });
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                        default:
                            if (SaveRuptureRecord(IncidentMain.COMPLETE) != 0)
                            {
                                ViewManager.ShowMessage("Report Saved as Complete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                            }
                            else
                            {
                                ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            break;
                    }
                }
                async1.Append(() =>
                    {
                        if (ViewModel.MobileInvolved != 0)
                        {
                            StepNext();
                        }
                        else
                        {
                            ViewManager.DisposeView(this);
                        }
                    });
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdSaveIncomplete_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Save Current Report as Incomplete
            switch (ViewModel.CurrReport)
            {
                case IncidentMain.FIRE:
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.FIREMOBILE:
                case IncidentMain.FIREOUTSIDE:
                    if (SaveFireRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                    {
                        ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                    }
                    else
                    {
                        ViewManager.ShowMessage("Error attempting to save Fire Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    break;
                default:
                    if (SaveRuptureRecord(IncidentMain.SAVEDINCOMPLETE) != 0)
                    {
                        ViewManager.ShowMessage("Report Saved as Incomplete", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK);
                    }
                    else
                    {
                        ViewManager.ShowMessage("Error attempting to save Rupture Report", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    break;
            }

            if (ViewModel.MobileInvolved != 0)
            {
                StepNext();
            }
            else
            {
                ViewManager.DisposeView(this);
            }
        }

        //UPGRADE_NOTE: (7001) The following declaration(SaveNarration) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
        //private void SaveNarration()
        //      {
        //          //Test routine for saving Narration text

        //          clsIncident IncidentCL = new clsIncident();

        //          IncidentCL.NarrationIncidentID = CurrIncident;
        //          IncidentCL.ReportType = CurrReport;
        //          IncidentCL.NarrationText = rtxNarration.Text;
        //          IncidentCL.NarrationBy = IncidentMain.gCurrUser;
        //          IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        //          if (~IncidentCL.AddNarration() != 0)
        //          {
        //              MessageBox.Show("Error Attempting to Add Narration Record", "TFD Incident Reporting Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //          }

        //      }

        private void Form_Load()
        {
            //Load Incident Reporting Wizard
            TFDIncident.clsReportLog ReportLog = Container.Resolve<clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve<clsIncident>();


            //Capture These from Global Entry variables
            //*** Hard Coded for Testing *******
            ViewModel.ReportStarted = 0;
            if (ReportLog.GetReportLog(IncidentMain.Shared.gNewReportID) != 0)
            {
                ViewModel.CurrReport = ReportLog.ReportType;
                ViewModel.CurrIncident = ReportLog.RLIncidentID;
                ViewModel.CurrUnit = ReportLog.ResponsibleUnit;
            }
            else
            {
                ViewManager.ShowMessage("Error retrieving report log record", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            IncidentCL.GetIncident(ViewModel.CurrIncident);
            ViewModel.lbFireLocation.Text = IncidentCL.Location;
            ViewModel.lbFireIncNo.Text = IncidentCL.IncidentNumber;
            ViewModel.lbFireUnit.Text = IncidentMain.Shared.gWizardUnitID;
            ViewModel.MobileInvolved = 0;
            ViewModel.HumansAFactor = 0;
            ViewModel.ExposureOccured = 0;
            ViewModel.ADDRESSCORRECTION = 0;
            ViewModel.CurrFrame = ViewModel.frmFireType;
            ViewModel.PrevReport = 0;
            FlipImage();
            FormatFrame();
            IncidentMain.MoveForm(wzdFire.DefInstance);
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstAlarmFailure_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstEquipInvolvIgnition_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstExtFailure_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstHumanContribFactors_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.HumansAFactor = 0;
            for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
            {
                if (ViewModel.lstHumanContribFactors.GetSelected(i))
                {
                    ViewModel.HumansAFactor = -1;
                }
            }
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstItemContribFireSpread_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstPhysicalContribFactors_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void lstSuppressionFactors_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
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
                        case 3: //Quit 

                            async2.Append(() =>
                                {
                                    StepQuit();
                                });
                            break;
                        case 4: //Finish 
                            StepFinish();
                            break;
                    }
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void optAlarmType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index = this.ViewModel.optAlarmType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                //Clear and reformat as necessary
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
                ViewModel.chkAlarmOperated.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.cboAlarmType.Items.Clear();
                ViewModel.cboInitiatingDevice.Items.Clear();
                ViewModel.cboEffectiveness.Items.Clear();
                ViewModel.lstAlarmFailure.Items.Clear();

                switch (Index)
                {
                    case 0: //No alarm 

                        ViewModel.chkAlarmOperated.Enabled = false;
                        ViewModel.chkAlarmOperated.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.chkAlarmOperated.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.lbSystemType.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboAlarmType.Visible = false;
                        ViewModel.lbInitiatingDevice.Visible = false;
                        ViewModel.cboInitiatingDevice.Visible = false;
                        ViewModel.lbEffectiveness.Visible = false;
                        ViewModel.cboEffectiveness.Visible = false;
                        ViewModel.lbAlarmProblems.Visible = false;
                        ViewModel.lstAlarmFailure.Visible = false;
                        break;
                    case 1: //Detector only 

                        ViewModel.lbSystemType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbSystemType.Text = "DETECTOR POWER";
                        ViewModel.cboAlarmType.Visible = true;
                        ViewModel.chkAlarmOperated.Enabled = true;
                        ViewModel.chkAlarmOperated.ForeColor = IncidentMain.Shared.FIREFONT;
                        if (ViewModel.chkAlarmOperated.Checked)
                        {
                            ViewModel.lbEffectiveness.Visible = true;
                            ViewModel.cboEffectiveness.Visible = true;
                        }
                        else
                        {
                            ViewModel.lbEffectiveness.Visible = false;
                            ViewModel.cboEffectiveness.Visible = false;
                        }

                        ViewModel.lbInitiatingDevice.Visible = false;
                        ViewModel.cboInitiatingDevice.Visible = false;
                        ViewModel.lbAlarmProblems.Visible = false;
                        ViewModel.lstAlarmFailure.Visible = false;
                        //Fill combo boxes 
                        FireCodes.GetEffectiveness("D");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                            ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                        }
                        ;

                        //Detector Power 
                        FireCodes.GetDetectorPowerCodes();

                        while (!FireCodes.DetectorPower.EOF)
                        {
                            ViewModel.cboAlarmType.AddItem(Convert.ToString(FireCodes.DetectorPower["description"]));
                            ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.DetectorPower["detector_power_code"]));
                            FireCodes.DetectorPower.MoveNext();
                        }
                        ;
                        //ViewModel.cboEffectiveness.Visible = true;
                        //ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.DKGRAY;
                        break;
                    case 2: //Alarm 

                        ViewModel.lbSystemType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbSystemType.Text = "SYSTEM TYPE";
                        ViewModel.cboAlarmType.Visible = true;
                        ViewModel.chkAlarmOperated.Enabled = true;
                        ViewModel.chkAlarmOperated.Visible = true;
                        ViewModel.lbInitiatingDevice.Visible = true;
                        ViewModel.cboInitiatingDevice.Visible = true;
                        if (ViewModel.chkAlarmOperated.Checked)
                        {
                            ViewModel.lbEffectiveness.Visible = true;
                            ViewModel.cboEffectiveness.Visible = true;
                        }
                        else
                        {
                            ViewModel.lbEffectiveness.Visible = false;
                            ViewModel.cboEffectiveness.Visible = false;
                        }
                        ViewModel.lbAlarmProblems.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbAlarmProblems.Visible = true;
                        ViewModel.lstAlarmFailure.Visible = true;
                        //Fill combo boxes 
                        //Alarm System Type Combo 
                        FireCodes.GetFireSystemType("A");

                        while (!FireCodes.FireSystemType.EOF)
                        {
                            ViewModel.cboAlarmType.AddItem(Convert.ToString(FireCodes.FireSystemType["description"]));
                            ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                            FireCodes.FireSystemType.MoveNext();
                        }
                        ;

                        //Initiating Device Combo 
                        FireCodes.GetAlarmDevice();

                        while (!FireCodes.AlarmDevice.EOF)
                        {
                            ViewModel.cboInitiatingDevice.AddItem(Convert.ToString(FireCodes.AlarmDevice["description"]));
                            ViewModel.cboInitiatingDevice.SetItemData(ViewModel.cboInitiatingDevice.GetNewIndex(), Convert.ToInt32(FireCodes.AlarmDevice["alarm_device_code"]));
                            FireCodes.AlarmDevice.MoveNext();
                        }
                        ;

                        //Alarm System Effectiveness Combo 
                        FireCodes.GetEffectiveness("A");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                            ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                        }
                        ;

                        //Alarm Failure Combo 
                        FireCodes.GetSystemFailure("A");

                        while (!FireCodes.SystemFailure.EOF)
                        {
                            ViewModel.lstAlarmFailure.AddItem(Convert.ToString(FireCodes.SystemFailure["description"]));
                            ViewModel.lstAlarmFailure.SetItemData(ViewModel.lstAlarmFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure["system_failure_code"]));
                            FireCodes.SystemFailure.MoveNext();
                        }
                        ;
                        //ViewModel.cboEffectiveness.Visible = true;
                        //ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.DKGRAY;
                        break;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optExtinguish_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index = this.ViewModel.optExtinguish.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();
                ViewModel.cboExtEffectiveness.Items.Clear();
                ViewModel.lstExtFailure.Items.Clear();
                ViewModel.chkExtOperated.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                ViewModel.cboSysType.Items.Clear();

                switch (Index)
                {
                    case 0:
                        ViewModel.chkExtOperated.Enabled = false;
                        ViewModel.lbExtSysType.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboSysType.Visible = false;
                        ViewModel.lbExtEffectiveness.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboExtEffectiveness.Visible = false;
                        ViewModel.lbExtProblems.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.lstExtFailure.Enabled = false;
                        break;
                    case 1:
                        ViewModel.chkExtOperated.Enabled = true;
                        ViewModel.chkExtOperated.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lbExtSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboSysType.Visible = true;
                        ViewModel.lbExtEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboExtEffectiveness.Visible = true;
                        ViewModel.lbExtProblems.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lstExtFailure.Enabled = true;

                        //Extinguishing System System Type Combo 
                        FireCodes.GetFireSystemType("E");

                        while (!FireCodes.FireSystemType.EOF)
                        {
                            ViewModel.cboSysType.AddItem(Convert.ToString(FireCodes.FireSystemType["description"]));
                            ViewModel.cboSysType.SetItemData(ViewModel.cboSysType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                            FireCodes.FireSystemType.MoveNext();
                        }
                        ;

                        //Extinguishing System Effectiveness Combo 
                        FireCodes.GetEffectiveness("E");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboExtEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                            ViewModel.cboExtEffectiveness.SetItemData(ViewModel.cboExtEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                        }
                        ;

                        //Extinguishing System Problems listbox 
                        FireCodes.GetSystemFailure("E");

                        while (!FireCodes.SystemFailure.EOF)
                        {
                            ViewModel.lstExtFailure.AddItem(Convert.ToString(FireCodes.SystemFailure["description"]));
                            ViewModel.lstExtFailure.SetItemData(ViewModel.lstExtFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure["system_failure_code"]));
                            FireCodes.SystemFailure.MoveNext();
                        }
                        ;
                        break;
                }
                CheckComplete();
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optFloor_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            int Index = this.ViewModel.optFloor.IndexOf((UpgradeHelpers.BasicViewModels.CheckBoxViewModel)eventSender);
            if (ViewModel.optFloor[Index].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                switch (Index)
                {
                    case 0:
                        ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        break;
                    case 1:
                        ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        break;
                    case 2:
                        ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        break;
                }
            }

            CheckComplete();
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
                int Index = this.ViewModel.optGender.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                if (ViewModel.optGender[Index].Checked)
                {
                    ViewModel.NameUpdated = -1;
                }
                CheckNameComplete();

            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void optType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if (ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index = this.ViewModel.optType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
                int i = 0;
                ViewModel.PrevReport = ViewModel.CurrReport;
                switch (ViewModel.CurrReport)
                {
                    case IncidentMain.FIRE:
                    case IncidentMain.FIRESTRUCTURE:
                    case IncidentMain.FIREMOBILE:
                    case IncidentMain.FIREOUTSIDE:
                        switch (Index)
                        {
                            case 0:
                                ViewModel.CurrReport = IncidentMain.FIRESTRUCTURE;
                                ViewModel.chkExposures.Visible = true;
                                ViewModel.lbNumExp.Visible = true;
                                ViewModel.txtNumberExposures.Visible = true;
                                ViewModel.chkMobileInvolved.Visible = true;
                                break;
                            case 1:
                                ViewModel.CurrReport = IncidentMain.FIREMOBILE;
                                ViewModel.chkExposures.Visible = false;
                                ViewModel.lbNumExp.Visible = false;
                                ViewModel.txtNumberExposures.Visible = false;
                                ViewModel.chkMobileInvolved.Visible = false;
                                break;
                            case 2:
                            case 3:
                            case 4:
                                ViewModel.CurrReport = IncidentMain.FIREOUTSIDE;
                                ViewModel.chkExposures.Visible = false;
                                ViewModel.lbNumExp.Visible = false;
                                ViewModel.txtNumberExposures.Visible = false;
                                ViewModel.chkMobileInvolved.Visible = false;
                                break;
                        }
                        //enable next button 
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        break;
                    case IncidentMain.RUPTURE:
                    case IncidentMain.RUPTURESTRUCTURE:
                    case IncidentMain.RUPTUREMOBILE:
                    case IncidentMain.RUPTUREOUTSIDE:
                        switch (Index)
                        {
                            case 0:
                                ViewModel.CurrReport = IncidentMain.RUPTURESTRUCTURE;
                                break;
                            case 1:
                                ViewModel.CurrReport = IncidentMain.RUPTUREMOBILE;
                                break;
                            case 2:
                                ViewModel.CurrReport = IncidentMain.RUPTUREOUTSIDE;
                                break;
                        }
                        ViewModel.NavButton[2].Visible = true;
                        ViewModel.lbNavMessage.Visible = false;
                        break;
                }
            }
        }
        [UpgradeHelpers.Events.Handler]
        internal void rtxNarration_Click(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBasementLevels_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void calBirthdate_Click(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.calBirthdate.MaxDate != ViewModel.calBirthdate.Value.Date)
            {
                CheckNameComplete();
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBusinessName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtBusinessName.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }
            CheckNameComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtContentLoss_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtFirstName.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }
            CheckNameComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFloorOfOrigin_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtHFAge_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtHomePhone_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtHomePhone.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtHouseNumber.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtJobsLost_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtLastName.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }
            CheckNameComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtMI_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtMI.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtMobilePropValue_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNoBusinessDisplaced_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNoPeopleDisplaced_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberExposures_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (ViewModel.txtNumberExposures.Text == "")
            {
                ViewModel.txtNumberExposures.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.NavButton[2].Enabled = false;
            }
            else if (!Double.TryParse(ViewModel.txtNumberExposures.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                ViewModel.txtNumberExposures.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.BLACK;
                ViewModel.txtNumberExposures.Text = "";
                ViewModel.NavButton[2].Enabled = false;
            }
            else
            {
                ViewModel.txtNumberExposures.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.txtNumberExposures.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.NavButton[2].Enabled = true;
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberOfBusinesses_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberOfOccupants_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberOfStories_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtNumberOfUnits_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtOSAreaAffected_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtOSLoss_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPropLoss_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtPropValue_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtBurned_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtBurned_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                if (ViewModel.txtSqFtBurned.Text == "")
                {
                    this.Return();
                    return;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();

                //Test For Property Value Calculation
                if (ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if (ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyLoss(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtSqFtBurned.Text))) != 0)
                        {
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) != FireCodes.PropLossCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Loss has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropLossCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async1.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                                            }
                                            else
                                            {
                                                CheckComplete();
                                            }
                                        });
                                }
                                else
                                {
                                    CheckComplete();
                                }
                            }
                        }
                        else
                        {
                            CheckComplete();
                        }
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    CheckComplete();
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtSmokeDamage_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtSmokeDamage_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                if (ViewModel.CurrReport != IncidentMain.RUPTURESTRUCTURE)
                {
                    this.Return();
                    return;
                }
                if (ViewModel.txtSqFtSmokeDamage.Text == "")
                {
                    this.Return();
                    return;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();

                //Test For Property Value Calculation
                if (ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if (ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyLoss(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text))) != 0)
                        {
                            if (ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) != FireCodes.PropLossCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Loss has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropLossCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async1.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                                            }
                                            else
                                            {
                                                CheckComplete();
                                            }
                                        });
                                }
                                else
                                {
                                    CheckComplete();
                                }
                            }
                        }
                        else
                        {
                            CheckComplete();
                        }
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    CheckComplete();
                }
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtStreetName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtStreetName.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTotalSqFootage_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {

            CheckComplete();

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTotalSqFootage_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            using (var async1 = this.Async(true))
            {
                if (ViewModel.txtTotalSqFootage.Text == "")
                {
                    this.Return();
                    return;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve<clsFireCodes>();

                //Test For Property Value Calculation
                if (ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if (ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if (ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting Wizard", UpgradeHelpers.Helpers.BoxButtons.YesNo));
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
                                        {
                                            Response = tempNormalized1;
                                        });
                                    async1.Append(() =>
                                        {
                                            if (Response == UpgradeHelpers.Helpers.DialogResult.Yes)
                                            {
                                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                                            }
                                            else
                                            {
                                                CheckComplete();
                                            }
                                        });
                                }
                                else
                                {
                                    CheckComplete();
                                }
                            }
                        }
                        else
                        {
                            CheckComplete();
                        }
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    CheckComplete();
                }
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtVehicleMake_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtVehicleYear_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtWorkPhone_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtWorkPhone.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtWorkPlace_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtWorkPlace.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (~ViewModel.FirstTime != 0)
            {
                CheckExposureAddress();
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXStreetName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (~ViewModel.FirstTime != 0)
            {
                CheckExposureAddress();
            }

        }

        [UpgradeHelpers.Events.Handler]
        internal void txtZipcode_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (ViewModel.txtZipcode.Text != "")
            {
                ViewModel.NameUpdated = -1;
            }
        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
        }

        public static wzdFire DefInstance
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

        public static wzdFire CreateInstance()
        {
            TFDIncident.wzdFire theInstance = Shared.Container.Resolve<wzdFire>();
            theInstance.Form_Load();
            return theInstance;
        }

        void ReLoadForm(bool addEvents)
        {
        }

        protected override void ExecuteControlsStartup()
        {
            ViewModel.frmBldgInfo.LifeCycleStartup();
            ViewModel.frmAlarmInfo.LifeCycleStartup();
            ViewModel.frmExtinguishingSysInfo.LifeCycleStartup();
            ViewModel.frmFireType.LifeCycleStartup();
            ViewModel.Frame1.LifeCycleStartup();
            ViewModel.frmLoss.LifeCycleStartup();
            ViewModel.frmPropLoss.LifeCycleStartup();
            ViewModel.frmNarration.LifeCycleStartup();
            ViewModel.frmMobileProp.LifeCycleStartup();
            ViewModel.frmPassengerVehicleInfo.LifeCycleStartup();
            ViewModel.frmName.LifeCycleStartup();
            ViewModel.frmGender.LifeCycleStartup();
            ViewModel.frmEthnicity.LifeCycleStartup();
            ViewModel.frmFireInfo.LifeCycleStartup();
            ViewModel.frmFireOnly.LifeCycleStartup();
            ViewModel.frmBsmtorAttic.LifeCycleStartup();
            ViewModel.frmHFDetail.LifeCycleStartup();
            ViewModel.frmOutsideInfo.LifeCycleStartup();
            ViewModel.frmReportStatus.LifeCycleStartup();
            ViewModel.frmExposureAddress.LifeCycleStartup();
            ViewModel.NavBar.LifeCycleStartup();
            base.ExecuteControlsStartup();
            this.DynamicControlsStartup();
        }

        protected override void ExecuteControlsShutdown()
        {
            ViewModel.frmBldgInfo.LifeCycleShutdown();
            ViewModel.frmAlarmInfo.LifeCycleShutdown();
            ViewModel.frmExtinguishingSysInfo.LifeCycleShutdown();
            ViewModel.frmFireType.LifeCycleShutdown();
            ViewModel.Frame1.LifeCycleShutdown();
            ViewModel.frmLoss.LifeCycleShutdown();
            ViewModel.frmPropLoss.LifeCycleShutdown();
            ViewModel.frmNarration.LifeCycleShutdown();
            ViewModel.frmMobileProp.LifeCycleShutdown();
            ViewModel.frmPassengerVehicleInfo.LifeCycleShutdown();
            ViewModel.frmName.LifeCycleShutdown();
            ViewModel.frmGender.LifeCycleShutdown();
            ViewModel.frmEthnicity.LifeCycleShutdown();
            ViewModel.frmFireInfo.LifeCycleShutdown();
            ViewModel.frmFireOnly.LifeCycleShutdown();
            ViewModel.frmBsmtorAttic.LifeCycleShutdown();
            ViewModel.frmHFDetail.LifeCycleShutdown();
            ViewModel.frmOutsideInfo.LifeCycleShutdown();
            ViewModel.frmReportStatus.LifeCycleShutdown();
            ViewModel.frmExposureAddress.LifeCycleShutdown();
            ViewModel.NavBar.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class wzdFire
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.wzdFireViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual wzdFire m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }
}