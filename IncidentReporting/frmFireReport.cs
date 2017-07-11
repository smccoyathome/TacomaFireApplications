using Microsoft.VisualBasic;
using System;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

    public partial class frmFireReport
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmFireReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
    {

        void UpgradeHelpers.Interfaces.IInitializable.Init()
        {
            this.CallBaseInit(typeof(frmFireReport));
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



        private void FlipToRupture()
        {
            //Change Control Colors to Rupture Colors
            //Hide used controls and change label captions as needed


            //mobilize: tabFire.ApplyTo = TabproLib.enumApplyTo.ApplyToDefault;
            ViewModel.tabFire.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.tabFire.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            //mobilize: tabFire.ApplyTo = TabproLib.enumApplyTo.ApplyToTab;
            //Common Tabs
            ViewModel.frmNar1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.frmNarrSelect.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.lbNarTitle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbNarrSelTitle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.frmName1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.lbNameTitle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
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
            ViewModel.lbZip.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbRole.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbBirthdate.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbGender.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.frmGender.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optGender[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optGender[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.optGender[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optGender[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbRace.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbEthnicity.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.frmEthnicity.BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optEthnicity[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optEthnicity[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.optEthnicity[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
            ViewModel.optEthnicity[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbHomePhone.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbWorkPhone.ForeColor = IncidentMain.Shared.RUPTUREFONT;
            ViewModel.lbWorkPlace.ForeColor = IncidentMain.Shared.RUPTUREFONT;

            switch ( ViewModel.ReportType)
            {
                case IncidentMain.RUPTURESTRUCTURE:
                case IncidentMain.RUPTUREMOBILE:
                    ViewModel.frmBI1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmAlarm.Visible = false;
                    ViewModel.frmExtinguish.Visible = false;
                    ViewModel.chkRental.Visible = false;
                    ViewModel.lbNumberOfUnits.Visible = false;
                    ViewModel.txtNumberOfUnits.Visible = false;
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
                    ViewModel.frmFireInfo1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmFireOnly.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmFloor.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbFlOfOrigin.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.optFloor[0].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optFloor[1].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optFloor[0].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.optFloor[1].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.optFloor[2].BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.optFloor[2].ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbAreaOrigin.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHeatSource.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbHeatSource.Text = "RUPTURE/EXPLOSION TYPE";
                    ViewModel.lbFirstIgnited.Visible = false;
                    ViewModel.cboFirstItemIgnited.Visible = false;
                    ViewModel.lbGenCauseOfIgnition.Visible = false;
                    ViewModel.cboGenCauseOfIgnition.Visible = false;
                    ViewModel.lbSpecCauseIgnition.Visible = false;
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
                    ViewModel.lbEquipInvolvIgnition[0].Visible = false;
                    ViewModel.lstEquipInvolvIgnition.Visible = false;
                    ViewModel.frmFireLoss.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmPropLoss.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbSqFtBurned.Visible = false;
                    ViewModel.txtSqFtBurned.Visible = false;
                    ViewModel.lbSqFtSmokeDamage.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbSqFtSmokeDamage.Text = "SQ FOOT DAMAGED";
                    ViewModel.lbNoBusinessDisplaced.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbNoPeopleDisplaced.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbJobsLost.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbPropLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbContentLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.frmMobile1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmVehicle.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.frmVehicle.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.frmMobile1.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbMobilePropType.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbMobilePropValue.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVesselLength.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    //            frmPassengerVehicleInfo.ForeColor = RUPTUREFONT 
                    ViewModel.lbOtherMake.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleMake.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleModel.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVehicleYear.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVIN.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbLicenseSt.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbVYearMes.ForeColor = IncidentMain.Shared.RUPTUREFONT;

                    break;
            case IncidentMain.RUPTUREOUTSIDE:
                    ViewModel.frmOSType.Visible = false;
                    ViewModel.frmOSMain.BackColor = IncidentMain.Shared.RUPTURECOLOR;
                    ViewModel.lbOSHeatSource.Visible = false;
                    ViewModel.cboOSHeatSource.Visible = false;
                    ViewModel.lbOSCauseOfIgnition.Visible = false;
                    ViewModel.cboOSCauseOfIgnition.Visible = false;
                    ViewModel.lbOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSSpecCauseOfIgnition.Text = "RUPTURE/EXPLOSION TYPE";
                    ViewModel.lbOSContentLoss.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSAreaAffected.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSAreaUnits.ForeColor = IncidentMain.Shared.RUPTUREFONT;
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;
                    break;
    }

}

        private void GetRuptureData()
        {
            //Retreive Rupture Report Data and populate Controls
            int PropClass = 0;
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsRupture RuptureReport = Container.Resolve< clsRupture>();
            int FTSwitchOn = 0;

            //Retrieve Rupture Report Data
            if (~RuptureReport.GetRupture(ViewModel.RuptureReportID) != 0)
            {
                ViewManager.ShowMessage("Error Retrieving Rupture Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            int AreaOfOrigin = RuptureReport.RuptureAreaOfOrigin;
            int PropUse = RuptureReport.RupturePropertyUseCode;

            //Set Rupture Type - uses HeatSource Combo
            for (int i = 0; i <= ViewModel.cboHeatSource.Items.Count - 1; i++)
            {
                if ( ViewModel.cboHeatSource.GetItemData(i) == RuptureReport.RuptureIncidentType)
                {
                    ViewModel.cboHeatSource.SelectedIndex = i;
                    break;
            }
    }
    //Set remaining textbox values
    if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE)
            {
                ViewModel.txtPropValue.Text = RuptureReport.RupturePropertyValue.ToString();
            }
            else
            {
                ViewModel.txtMobilePropValue.Text = RuptureReport.RupturePropertyValue.ToString();
            }
            ViewModel.txtPropLoss.Text = RuptureReport.RupturePropertyLoss.ToString();
            ViewModel.txtContentLoss.Text = RuptureReport.RuptureContentLoss.ToString();

            //Load Dependent Property Use, AoO Listboxes and Set Values in dependent and master combo
            ViewModel.cboSpecificPropertyUse.Items.Clear();
            ViewModel.cboMobilePropType.Items.Clear();
            ViewModel.cboAreaOfOrigin.Items.Clear();
            //Property Use
            if (FireCodes.GetPropertyUseByCode(PropUse) != 0)
            {
                FireCodes.PropertyUse.Open();
                if (!FireCodes.PropertyUse.EOF)
                {
                    PropClass = Convert.ToInt32(FireCodes.PropertyUse["property_use_class"]);
                    if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE)
                    {
                        while (!FireCodes.PropertyUse.EOF)
                        {
                            ViewModel.cboSpecificPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                            ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                            FireCodes.PropertyUse.MoveNext();
                    };
                    //Set Values
                    for (int i = 0; i <= ViewModel.cboGeneralPropertyUse.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboGeneralPropertyUse.GetItemData(i) == PropClass)
                            {
                                ViewModel.cboGeneralPropertyUse.SelectedIndex = i;
                                break;
                        }
                }
                for (int i = 0; i <= ViewModel.cboSpecificPropertyUse.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboSpecificPropertyUse.GetItemData(i) == PropUse)
                            {
                                ViewModel.cboSpecificPropertyUse.SelectedIndex = i;
                                break;
                        }
                }
        }
        else
        {

                while (!FireCodes.PropertyUse.EOF)
                {
                            ViewModel.cboMobilePropType.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                            ViewModel.cboMobilePropType.SetItemData(ViewModel.cboMobilePropType.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                            FireCodes.PropertyUse.MoveNext();
                    };
                    //Set Values
                    for (int i = 0; i <= ViewModel.cboMobilePropType.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboMobilePropType.GetItemData(i) == PropUse)
                            {
                                ViewModel.cboMobilePropType.SelectedIndex = i;
                                break;
                        }
                }
        }
}
}
//Area of Origin

while (!FireCodes.AreaOfOrigin.EOF)
{
                ViewModel.cboAreaOfOrigin.AddItem(Convert.ToString(FireCodes.AreaOfOrigin["description"]));
                ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                FireCodes.AreaOfOrigin.MoveNext();
        };
        //Set Values
        for (int i = 0; i <= ViewModel.cboAreaOfOrigin.Items.Count - 1; i++)
            {
                if ( ViewModel.cboAreaOfOrigin.GetItemData(i) == AreaOfOrigin)
                {
                    ViewModel.cboAreaOfOrigin.SelectedIndex = i;
                    break;
            }
    }

    //Set Values Supporting Tables
    //Physical Contributing Factors
    if (RuptureReport.GetRupturePhysicalContributingFactor(ViewModel.RuptureReportID) != 0)
    {

            while (!RuptureReport.RupturePhysicalContributingFactor.EOF)
            {
                    for (int i = 0; i <= ViewModel.lstPhysicalContribFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstPhysicalContribFactors.GetItemData(i) == Convert.ToDouble(RuptureReport.RupturePhysicalContributingFactor["physical_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPhysicalContribFactors, i, true);
                            break;
                    }
            }
            RuptureReport.RupturePhysicalContributingFactor.MoveNext();
    };
}

//Human Contributing Factors
if (RuptureReport.GetRuptureHumanContributingFactor(ViewModel.RuptureReportID) != 0)
{

    while (!RuptureReport.RuptureHumanContributingFactor.EOF)
    {
            for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstHumanContribFactors.GetItemData(i) == Convert.ToDouble(RuptureReport.RuptureHumanContributingFactor["human_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstHumanContribFactors, i, true);
                            break;
                    }
            }
            RuptureReport.RuptureHumanContributingFactor.MoveNext();
    };
}

//Suppression Factors
if (RuptureReport.GetRuptureSuppressionFactor(ViewModel.RuptureReportID) != 0)
{

    while (!RuptureReport.RuptureSuppressionFactor.EOF)
    {
            for (int i = 0; i <= ViewModel.lstSuppressionFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstSuppressionFactors.GetItemData(i) == Convert.ToDouble(RuptureReport.RuptureSuppressionFactor["suppression_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstSuppressionFactors, i, true);
                            break;
                    }
            }
            RuptureReport.RuptureSuppressionFactor.MoveNext();
    };
}

//Retrieve RuptureStructure Data
if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE)
            {
                if (~RuptureReport.GetRuptureStructure(ViewModel.RuptureReportID) != 0)
                {
                    ViewManager.ShowMessage("Error Retrieving Rupture/Explosion Structure Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewManager.DisposeView(this);
                }

                //Set Building Status Code
                for (int i = 0; i <= ViewModel.cboBuildingStatus.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboBuildingStatus.GetItemData(i) == RuptureReport.BuildingStatus)
                    {
                        ViewModel.cboBuildingStatus.SelectedIndex = i;
                        break;
                }
        }
        //Set Construction Type Code
        for (int i = 0; i <= ViewModel.cboConstructionType.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboConstructionType.GetItemData(i) == RuptureReport.ConstructionType)
                    {
                        ViewModel.cboConstructionType.SelectedIndex = i;
                        break;
                }
        }

        //Set remaining textbox values
        if (RuptureReport.SpecialFloor == 1)
        {
                    ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                }
                else if (RuptureReport.SpecialFloor == 2)
                {
                    ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                }
                else if (RuptureReport.SpecialFloor == 3)
                {
                    ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                }
                ViewModel.txtFloorOfOrigin.Text = RuptureReport.FloorOfOrigin.ToString();
                ViewModel.txtNumberOfStories.Text = RuptureReport.NumberOfStories.ToString();
                ViewModel.txtBasementLevels.Text = RuptureReport.BasementLevels.ToString();
                ViewModel.txtTotalSqFootage.Text = RuptureReport.TotalSqFootage.ToString();
                ViewModel.txtNumberOfOccupants.Text = RuptureReport.NumberPeopleOccuping.ToString();
                ViewModel.txtNumberOfBusinesses.Text = RuptureReport.NumberBusinessOccuping.ToString();
                ViewModel.txtSqFtSmokeDamage.Text = RuptureReport.SqFootDamaged.ToString();
                ViewModel.txtNoPeopleDisplaced.Text = RuptureReport.PeopleDisplaced.ToString();
                ViewModel.txtNoBusinessDisplaced.Text = RuptureReport.BusinessesDisplaced.ToString();
                ViewModel.txtJobsLost.Text = RuptureReport.JobsLost.ToString();
            }
            else
            {
                //RuptureMobile
                if (~RuptureReport.GetRuptureMobileProperty(ViewModel.RuptureReportID) != 0)
                {
                    ViewManager.ShowMessage("Error retrieving Rupture/Explosion Mobile Property Data ", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                        BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewManager.DisposeView(this);
                }

                if ( ViewModel.cboMobilePropType.SelectedIndex != -1)
                {
                    if ( ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex) == IncidentMain.WATERVESSEL)
                    {
                        ViewModel.lbVesselLength.Visible = true;
                        ViewModel.txtVesselLength.Visible = true;
                        ViewModel.txtVesselLength.Text = RuptureReport.WaterVesseLength.ToString();
                    }
                    else
                    {
                        ViewModel.lbVesselLength.Visible = false;
                        ViewModel.txtVesselLength.Visible = false;
                    }
            }
            else
            {
                    ViewModel.lbVesselLength.Visible = false;
                    ViewModel.txtVesselLength.Visible = false;
                }

                if ( ViewModel.FirstTime != 0)
                {
                    FTSwitchOn = -1;
                }
                else
                {
                    FTSwitchOn = 0;
                    ViewModel.FirstTime = -1;
                }

                for (int i = 0; i <= ViewModel.cboMobileMake.Items.Count - 1; i++)
                {
                    ViewModel.cboMobileMake.SelectedIndex = i;
                    if ( ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == RuptureReport.MobileMake)
                    {
                        if (RuptureReport.MobileMake == "00")
                        {
                            ViewModel.txtVehicleMake.Visible = true;
                            ViewModel.lbOtherMake.Visible = true;
                            ViewModel.txtVehicleMake.Text = RuptureReport.VehicleMake;
                        }
                        else
                        {
                            ViewModel.txtVehicleMake.Visible = false;
                            ViewModel.lbOtherMake.Visible = false;
                        }
                        break;
                }
        }
                ViewModel.cboLicenseState.SelectedIndex = -1;
                for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboState.GetListItem(i) == RuptureReport.LicenseState)
                    {
                        ViewModel.cboState.SelectedIndex = i;
                        ViewModel.cboLicenseState.SelectedIndex = i;
                        break;
                }
        }

        if (~FTSwitchOn != 0)
        {
                    ViewModel.FirstTime = 0;
                }
                ViewModel.txtVehicleModel.Text = RuptureReport.VehicleModel;
                ViewModel.txtVIN.Text = RuptureReport.VehicleVin;
                ViewModel.txtVehicleYear.Text = RuptureReport.VehicleYear;
            }

    }

        private void GetRuptureOutsideData()
        {
            //Load all appropriate Outside Fire Data
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsRupture RuptureReport = Container.Resolve< clsRupture>();
            if (~RuptureReport.GetRuptureOutside(ViewModel.RuptureReportID) != 0)
            {
                ViewManager.ShowMessage("Error retrieving Outside Rupture/Explosion Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            //Set Rupture Type - uses OS Spec Cause of Ignition Combo
            for (int i = 0; i <= ViewModel.cboOSSpecCauseOfIgnition.Items.Count - 1; i++)
            {
                if ( ViewModel.cboOSSpecCauseOfIgnition.GetItemData(i) == RuptureReport.ROIncidentType)
                {
                    ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex = i;
                    break;
            }
    }
            ViewModel.txtOSLoss.Text = RuptureReport.ROContentLoss.ToString();
            ViewModel.txtOSAreaAffected.Text = RuptureReport.ROAreaAffected.ToString();
            for (int i = 0; i <= ViewModel.cboOSAreaUnits.Items.Count - 1; i++)
            {
                if ( ViewModel.cboOSAreaUnits.GetItemData(i) == RuptureReport.ROAreaUnit)
                {
                    ViewModel.cboOSAreaUnits.SelectedIndex = i;
                    break;
            }
    }
}

        private void LockScreen()
        {
            //Lock controls from update for ReadOnly access
            ViewModel.cmdSave[0].Enabled = false;
            ViewModel.cmdSave[1].Enabled = false;
            ViewModel.cmdSave[0].Visible = false;
            ViewModel.cmdSave[1].Visible = false;
            ViewModel.txtFirstName.Enabled = false;
            ViewModel.txtLastName.Enabled = false;
            ViewModel.txtMI.Enabled = false;
            ViewModel.txtHouseNumber.Enabled = false;
            //UPGRADE_ISSUE: (2064) ComboBox property cboPrefix.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboPrefix.setLocked(true);
            ViewModel.txtStreetName.Enabled = false;
            //UPGRADE_ISSUE: (2064) ComboBox property cboStreetType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboStreetType.setLocked(true);
            //UPGRADE_ISSUE: (2064) ComboBox property cboSuffix.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboSuffix.setLocked(true);
            ViewModel.txtCity.Enabled = false;
            ViewModel.txtZipcode.Enabled = false;
            //UPGRADE_ISSUE: (2064) ComboBox property cboState.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboState.setLocked(true);
            //UPGRADE_ISSUE: (2064) ComboBox property cboRole.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboRole.setLocked(true);
            ViewModel.txtBirthdate.Enabled = false;
            ViewModel.optGender[0].Enabled = false;
            ViewModel.optGender[1].Enabled = false;
            //UPGRADE_ISSUE: (2064) ComboBox property cboRace.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            ViewModel.cboRace.setLocked(true);
            ViewModel.optEthnicity[0].Enabled = false;
            ViewModel.optEthnicity[1].Enabled = false;
            ViewModel.txtHomePhone.Enabled = false;
            ViewModel.txtWorkPhone.Enabled = false;
            ViewModel.txtWorkPlace.Enabled = false;
            ViewModel.cmdMoreNames.Enabled = false;
            ViewModel.cmdAddNarration.Visible = false;


            switch ( ViewModel.ReportType)
            {
                case IncidentMain.FIREOUTSIDE:
                case IncidentMain.RUPTUREOUTSIDE:
                    ViewModel.optOSType[0].Enabled = false;
                    ViewModel.optOSType[1].Enabled = false;
                    ViewModel.optOSType[2].Enabled = false;
                    //UPGRADE_ISSUE: (2064) ComboBox property cboOSHeatSource.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboOSHeatSource.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboOSCauseOfIgnition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboOSCauseOfIgnition.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboOSSpecCauseOfIgnition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboOSSpecCauseOfIgnition.setLocked(true);
                    ViewModel.txtOSLoss.Enabled = false;
                    ViewModel.txtOSAreaAffected.Enabled = false;
                    //UPGRADE_ISSUE: (2064) ComboBox property cboOSAreaUnits.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboOSAreaUnits.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboOSMaterialInvolved.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboOSMaterialInvolved.setLocked(true);
                    break;
            case IncidentMain.FIREMOBILE:
            case IncidentMain.RUPTUREMOBILE:
                    //UPGRADE_ISSUE: (2064) ComboBox property cboMobilePropType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboMobilePropType.setLocked(true);
                    ViewModel.txtMobilePropValue.Enabled = false;
                    ViewModel.txtVesselLength.Enabled = false;
                    ViewModel.txtVehicleMake.Enabled = false;
                    ViewModel.txtVehicleModel.Enabled = false;
                    ViewModel.txtVehicleYear.Enabled = false;
                    ViewModel.txtVIN.Enabled = false;
                    break;
            case IncidentMain.FIRESTRUCTURE:
            case IncidentMain.RUPTURESTRUCTURE:
                    //UPGRADE_ISSUE: (2064) ComboBox property cboGeneralPropertyUse.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboGeneralPropertyUse.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboSpecificPropertyUse.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboSpecificPropertyUse.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboBuildingStatus.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboBuildingStatus.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboConstructionType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboConstructionType.setLocked(true);
                    frmFireReport.DefInstance.ViewModel.chkRental.Enabled = false;
                    ViewModel.txtTotalSqFootage.Enabled = false;
                    ViewModel.txtNumberOfStories.Enabled = false;
                    ViewModel.txtNumberOfUnits.Enabled = false;
                    ViewModel.txtNumberOfOccupants.Enabled = false;
                    ViewModel.txtNumberOfBusinesses.Enabled = false;
                    ViewModel.txtPropValue.Enabled = false;
                    ViewModel.optAlarmType[0].Enabled = false;
                    ViewModel.optAlarmType[1].Enabled = false;
                    ViewModel.optAlarmType[2].Enabled = false;
                    ViewModel.chkAlarmOperation.Enabled = false;
                    //UPGRADE_ISSUE: (2064) ComboBox property cboAlarmType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboAlarmType.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboInitiatingDevice.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboInitiatingDevice.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboEffectiveness.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboEffectiveness.setLocked(true);
                    ViewModel.lstAlarmFailure.Enabled = false;
                    ViewModel.optExtinguish[0].Enabled = false;
                    ViewModel.optExtinguish[1].Enabled = false;
                    //UPGRADE_ISSUE: (2064) ComboBox property cboSysType.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboSysType.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboExtEffectiveness.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboExtEffectiveness.setLocked(true);
                    ViewModel.lstExtFailure.Enabled = false;
                    ViewModel.txtFloorOfOrigin.Enabled = false;
                    ViewModel.optFloor[0].Enabled = false;
                    ViewModel.optFloor[1].Enabled = false;
                    ViewModel.optFloor[2].Enabled = false;
                    //UPGRADE_ISSUE: (2064) ComboBox property cboBurnDamage.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboBurnDamage.setLocked(true);
                    //UPGRADE_ISSUE: (2064) ComboBox property cboSmokeDamage.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx 
                    ViewModel.cboSmokeDamage.setLocked(true);
                    ViewModel.lstItemContribFireSpread.Enabled = false;
                    ViewModel.lstEquipInvolvIgnition.Enabled = false;
                    ViewModel.txtSqFtBurned.Enabled = false;
                    ViewModel.txtSqFtSmokeDamage.Enabled = false;
                    ViewModel.txtNoBusinessDisplaced.Enabled = false;
                    ViewModel.txtNoPeopleDisplaced.Enabled = false;
                    ViewModel.txtJobsLost.Enabled = false;
                    break;
    }

            if ( ViewModel.ReportType != IncidentMain.FIREOUTSIDE && ViewModel.ReportType != IncidentMain.RUPTUREOUTSIDE)
            {
                //UPGRADE_ISSUE: (2064) ComboBox property cboAreaOfOrigin.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboAreaOfOrigin.setLocked(true);
                //UPGRADE_ISSUE: (2064) ComboBox property cboHeatSource.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboHeatSource.setLocked(true);
                //UPGRADE_ISSUE: (2064) ComboBox property cboFirstItemIgnited.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboFirstItemIgnited.setLocked(true);
                //UPGRADE_ISSUE: (2064) ComboBox property cboGenCauseOfIgnition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboGenCauseOfIgnition.setLocked(true);
                //UPGRADE_ISSUE: (2064) ComboBox property cboSpecCauseOfIgnition.Locked was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                ViewModel.cboSpecCauseOfIgnition.setLocked(true);
                ViewModel.lstPhysicalContribFactors.Enabled = false;
                ViewModel.lstHumanContribFactors.Enabled = false;
                ViewModel.lstSuppressionFactors.Enabled = false;
                ViewModel.txtPropLoss.Enabled = false;
                ViewModel.txtContentLoss.Enabled = false;
            }


            if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
            {
                ViewModel.rtxNarration.Enabled = false;
            }

    }

        private void SaveNarration()
        {
            //determine if Insert or Update
            //Save Incident Narration Record
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            IncidentCL.NarrationIncidentID = ViewModel.CurrIncident;
            IncidentCL.ReportType = ViewModel.ReportType;
            IncidentCL.NarrationText = ViewModel.rtxNarration.Text;
            IncidentCL.NarrationBy = IncidentMain.Shared.gCurrUser;
            IncidentCL.NarrationLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
            int NarrID = Convert.ToInt32(Conversion.Val(ViewModel.lbNarrID.Text));
            if (NarrID == 0)
            {
                if (~IncidentCL.AddNarration() != 0)
                {
                    ViewManager.ShowMessage("Error attempting to save Narration Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
                else
                {
                    ViewModel.NarrationUpdated = 0;
                }
        }
        else
        {
                IncidentCL.NarrationID = NarrID;
                if (IncidentCL.GetNarrationSecurity(NarrID, IncidentMain.Shared.gCurrUser) != 0)
                {
                    if (~IncidentCL.UpdateNarration() != 0)
                    {
                        ViewManager.ShowMessage("Error attempting to update Narration Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    else
                    {
                        ViewModel.NarrationUpdated = 0;
                    }
            }
    }

}

        private void LoadNarration(int lNarrID)
        {
            //Load Narration combo and display requested narration
            //**** Change to display narration of current user *****
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            string SaveText = "";
            string SaveAuthor = "";
            int SaveID = 0;
            int CurrNarr = 0;
            ViewModel.FirstTime = -1;
            ViewModel.rtxNarration.Text = "";
            ViewModel.lbNarrID.Text = "";
            ViewModel.lbNarrAuthor.Text = "";
            ViewModel.cboNarrList.Items.Clear();


            if (IncidentCL.NarrationListRS(ViewModel.CurrIncident, ViewModel.ReportType) != 0)
            {
                SaveID = Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]);
                SaveAuthor = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
                SaveText = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);

                while (!IncidentCL.IncidentNarration.EOF)
                {
                    ViewModel.cboNarrList.AddItem(IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]));
                    ViewModel.cboNarrList.SetItemData(ViewModel.cboNarrList.GetNewIndex(), Convert.ToInt32(IncidentCL.IncidentNarration["narration_id"]));

                    if (lNarrID == Convert.ToDouble(IncidentCL.IncidentNarration["narration_id"]))
                    {
                        ViewModel.lbNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
                        ViewModel.rtxNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
                        ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
                        if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) != IncidentMain.Shared.gCurrUser)
                        {
                            ViewModel.rtxNarration.Enabled = false;
                        }
                        CurrNarr = ViewModel.cboNarrList.GetNewIndex();
                    }
                    else if (IncidentMain.Clean(IncidentCL.IncidentNarration["narration_by"]) == IncidentMain.Shared.gCurrUser)
                    {
                        ViewModel.cmdAddNarration.Enabled = false;
                        if (lNarrID == 0)
                        {
                            ViewModel.lbNarrID.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_id"]);
                            ViewModel.rtxNarration.Text = Convert.ToString(IncidentCL.IncidentNarration["narration_text"]);
                            ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(IncidentCL.IncidentNarration["name_full"]);
                            ViewModel.rtxNarration.Enabled = true;
                            CurrNarr = ViewModel.cboNarrList.GetNewIndex();
                        }
                }
                    IncidentCL.IncidentNarration.MoveNext();
            };
            if ( ViewModel.lbNarrID.Text == "")
                {
                    ViewModel.lbNarrID.Text = SaveID.ToString();
                    ViewModel.lbNarrAuthor.Text = SaveAuthor;
                    ViewModel.rtxNarration.Text = SaveText;
                    ViewModel.rtxNarration.Enabled = false;
                    ViewModel.cboNarrList.SelectedIndex = 0;
                }
                else
                {
                    ViewModel.cboNarrList.SelectedIndex = CurrNarr;
                }
        }
            ViewModel.FirstTime = 0;
            ViewModel.NarrationUpdated = 0;


        }

        private void CheckNameComplete()
        {
            //Check Required Fields for Save Status of current name record
            if (IncidentMain.Shared.gWizardSecurity != IncidentMain.READONLY)
            {
                ViewModel.cmdMoreNames.Enabled = true;
            }

            if ( ViewModel.cboRole.SelectedIndex < 0)
            {
                ViewModel.cboRole.BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.cboRole.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cmdMoreNames.Enabled = false;
            }
            else
            {
                ViewModel.cboRole.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.cboRole.ForeColor = IncidentMain.Shared.FIREFONT;
            }
            if ( ViewModel.txtBusinessName.Text == "")
            {
                if ( ViewModel.txtFirstName.Text == "" && ViewModel.txtLastName.Text == "")
                {
                    ViewModel.txtBusinessName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtBusinessName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
            if ( ViewModel.txtFirstName.Text == "")
            {
                if ( ViewModel.txtBusinessName.Text == "")
                {
                    ViewModel.txtFirstName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtFirstName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
            if ( ViewModel.txtLastName.Text == "")
            {
                if ( ViewModel.txtBusinessName.Text == "")
                {
                    ViewModel.txtLastName.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtLastName.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
            if ( ViewModel.optGender[0].Checked)
            {
                ViewModel.optGender[0].BackColor = IncidentMain.Shared.FIRECOLOR;
                ViewModel.optGender[0].ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.optGender[1].BackColor = IncidentMain.Shared.FIRECOLOR;
                ViewModel.optGender[1].ForeColor = IncidentMain.Shared.FIREFONT;
            }
            else if ( ViewModel.optGender[1].Checked)
            {
                ViewModel.optGender[0].BackColor = IncidentMain.Shared.FIRECOLOR;
                ViewModel.optGender[0].ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.optGender[1].BackColor = IncidentMain.Shared.FIRECOLOR;
                ViewModel.optGender[1].ForeColor = IncidentMain.Shared.FIREFONT;
            }
            else
            {
                ViewModel.optGender[0].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.optGender[0].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                ViewModel.optGender[1].BackColor = IncidentMain.Shared.REQCOLOR;
                ViewModel.optGender[1].ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
            }

            //Check valid birthdate
            if ( ViewModel.txtBirthdate.Text != "__/__/____")
            {
                if (!Information.IsDate(ViewModel.txtBirthdate.Text))
                {
                    ViewModel.txtBirthdate.Text = "__/__/____";
                    ViewManager.ShowMessage("Invalid Date Entry Found in Birthdate Field", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
        }


}

        private void ClearName()
        {
            //Clear all name fields
            ViewModel.lbNameID.Text = "";
            ViewModel.txtFirstName.Text = "";
            ViewModel.txtLastName.Text = "";
            ViewModel.txtMI.Text = "";
            ViewModel.txtBusinessName.Text = "";
            ViewModel.txtHouseNumber.Text = "";
            ViewModel.txtStreetName.Text = "";
            ViewModel.txtCity.Text = "Tacoma";
            ViewModel.txtZipcode.Text = "";
            ViewModel.txtBirthdate.Text = "__/__/____";
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
            //Default to Washington
            for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
            {
                if ( ViewModel.cboState.GetListItem(i) == "WA")
                {
                    ViewModel.cboState.SelectedIndex = i;
                    break;
            }
    }
            ViewModel.cboRace.SelectedIndex = -1;
            ViewModel.cboRole.SelectedIndex = -1;

        }

        private void LoadNames(int lNameID)
        {
            //Load Names Listbox and Display
            //Requested Name Record
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            string sListDisplay = "";
            ViewModel.FirstTime = -1;
            int DisplayIndex = 0;
            ViewModel.cboNameList.Items.Clear();
            ClearName();
            if (IncidentCL.NameListRS(ViewModel.CurrIncident) != 0)
            {
                //If no specific record requested
                if (lNameID == 0)
                {
                    //Display First Name in List
                    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    ViewModel.lbNameID.Text = Convert.ToString(IncidentCL.IncidentName["name_id"]);
                    ViewModel.txtFirstName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_first"]);
                    ViewModel.txtLastName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_last"]);
                    ViewModel.txtMI.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_mi"]);
                    ViewModel.txtBusinessName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_business"]);
                    ViewModel.txtHouseNumber.Text = IncidentMain.Clean(IncidentCL.IncidentName["addr_house_number"]);
                    ViewModel.txtStreetName.Text = IncidentMain.Clean(IncidentCL.IncidentName["addr_street_name"]);
                    ViewModel.txtCity.Text = IncidentMain.Clean(IncidentCL.IncidentName["city"]);
                    ViewModel.txtZipcode.Text = IncidentMain.Clean(IncidentCL.IncidentName["zipcode"]);
                    if (Information.IsDate(IncidentCL.IncidentName["birthdate"]))
                    {
                        ViewModel.txtBirthdate.Text = Convert.ToDateTime(IncidentCL.IncidentName["birthdate"]).ToString("MM/dd/yyyy");
                    }
                    ViewModel.txtHomePhone.Text = IncidentMain.Clean(IncidentCL.IncidentName["home_phone"]);
                    ViewModel.txtWorkPhone.Text = IncidentMain.Clean(IncidentCL.IncidentName["work_phone"]);
                    ViewModel.txtWorkPlace.Text = IncidentMain.Clean(IncidentCL.IncidentName["work_place"]);
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["gender"]))
                    {
                        if (Convert.ToDouble(IncidentCL.IncidentName["gender"]) == 1)
                        {
                            ViewModel.optGender[0].Checked = true;
                        }
                        else
                        {
                            ViewModel.optGender[1].Checked = true;
                        }
                }
                else
                {
                        ViewModel.optGender[0].Checked = false;
                        ViewModel.optGender[1].Checked = false;
                    }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["ethnicity_code"]))
                    {
                        if (Convert.ToDouble(IncidentCL.IncidentName["ethnicity_code"]) == 3)
                        {
                            ViewModel.optEthnicity[0].Checked = true;
                        }
                        else
                        {
                            ViewModel.optEthnicity[1].Checked = true;
                        }
                }
                else
                {
                        ViewModel.optEthnicity[0].Checked = false;
                        ViewModel.optEthnicity[1].Checked = false;
                    }
                    //Set combo boxes
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_prefix"]))
                    {
                        for (int i = 0; i <= ViewModel.cboPrefix.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboPrefix.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_prefix"]))
                            {
                                ViewModel.cboPrefix.SelectedIndex = i;
                                break;
                        }
                }
                if ( ViewModel.cboPrefix.SelectedIndex != -1)
                        {
                            ViewModel.cboSuffix.SelectedIndex = -1;
                        }
                }
                else if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_suffix"]))
                {
                        for (int i = 0; i <= ViewModel.cboSuffix.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboSuffix.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_suffix"]))
                            {
                                ViewModel.cboSuffix.SelectedIndex = i;
                                break;
                        }
                }
                if ( ViewModel.cboSuffix.SelectedIndex != -1)
                        {
                            ViewModel.cboPrefix.SelectedIndex = -1;
                        }
                }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_street_type"]))
                    {
                        for (int i = 0; i <= ViewModel.cboStreetType.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboStreetType.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_street_type"]))
                            {
                                ViewModel.cboStreetType.SelectedIndex = i;
                                break;
                        }
                }
        }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["state_code"]))
                    {
                        for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboState.GetListItem(i) == Convert.ToString(IncidentCL.IncidentName["state_code"]))
                            {
                                ViewModel.cboState.SelectedIndex = i;
                                break;
                        }
                }
        }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["race_code"]))
                    {
                        for (int i = 0; i <= ViewModel.cboRace.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboRace.GetItemData(i) == Convert.ToDouble(IncidentCL.IncidentName["race_code"]))
                            {
                                ViewModel.cboRace.SelectedIndex = i;
                                break;
                        }
                }
        }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["incident_role_code"]))
                    {
                        for (int i = 0; i <= ViewModel.cboRole.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboRole.GetItemData(i) == Convert.ToDouble(IncidentCL.IncidentName["incident_role_code"]))
                            {
                                ViewModel.cboRole.SelectedIndex = i;
                                break;
                        }
                }
        }
}
//Load Names Combo box

while (!IncidentCL.IncidentName.EOF)
{
        sListDisplay = IncidentMain.Clean(IncidentCL.IncidentName["name_last"]) + ", " + IncidentMain.Clean(IncidentCL.IncidentName["name_first"]);
        if (sListDisplay == ", ")
        {
                sListDisplay = IncidentMain.Clean(IncidentCL.IncidentName["name_business"]);
        }
                    ViewModel.cboNameList.AddItem(sListDisplay);
                    ViewModel.cboNameList.SetItemData(ViewModel.cboNameList.GetNewIndex(), Convert.ToInt32(IncidentCL.IncidentName["name_id"]));
                    if (Convert.ToDouble(IncidentCL.IncidentName["name_id"]) == lNameID)
                    {
                        //Display this Name Record
                        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        DisplayIndex = ViewModel.cboNameList.GetNewIndex();
                        ViewModel.lbNameID.Text = Convert.ToString(IncidentCL.IncidentName["name_id"]);
                        ViewModel.txtFirstName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_first"]);
                        ViewModel.txtLastName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_last"]);
                        ViewModel.txtMI.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_mi"]);
                        ViewModel.txtBusinessName.Text = IncidentMain.Clean(IncidentCL.IncidentName["name_business"]);
                        ViewModel.txtHouseNumber.Text = IncidentMain.Clean(IncidentCL.IncidentName["addr_house_number"]);
                        ViewModel.txtStreetName.Text = IncidentMain.Clean(IncidentCL.IncidentName["addr_street_name"]);
                        ViewModel.txtCity.Text = IncidentMain.Clean(IncidentCL.IncidentName["city"]);
                        ViewModel.txtZipcode.Text = IncidentMain.Clean(IncidentCL.IncidentName["zipcode"]);
                        System.DateTime TempDate = DateTime.FromOADate(0);
                        ViewModel.txtBirthdate.Text = (DateTime.TryParse(IncidentMain.Clean(IncidentCL.IncidentName["birthdate"]), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : IncidentMain.Clean(IncidentCL.IncidentName["birthdate"]);
                        ViewModel.txtHomePhone.Text = IncidentMain.Clean(IncidentCL.IncidentName["home_phone"]);
                        ViewModel.txtWorkPhone.Text = IncidentMain.Clean(IncidentCL.IncidentName["work_phone"]);
                        ViewModel.txtWorkPlace.Text = IncidentMain.Clean(IncidentCL.IncidentName["work_place"]);
                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                        if (!Convert.IsDBNull(IncidentCL.IncidentName["gender"]))
                        {
                            if (Convert.ToDouble(IncidentCL.IncidentName["gender"]) == 1)
                            {
                                ViewModel.optGender[0].Checked = true;
                            }
                            else
                            {
                                ViewModel.optGender[1].Checked = true;
                            }
                    }
                    else
                    {
                            ViewModel.optGender[0].Checked = false;
                            ViewModel.optGender[1].Checked = false;
                        }
                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                        if (!Convert.IsDBNull(IncidentCL.IncidentName["ethnicity_code"]))
                        {
                            if (Convert.ToDouble(IncidentCL.IncidentName["ethnicity_code"]) == 3)
                            {
                                ViewModel.optEthnicity[0].Checked = true;
                            }
                            else
                            {
                                ViewModel.optEthnicity[1].Checked = true;
                            }
                    }
                    else
                    {
                            ViewModel.optEthnicity[0].Checked = false;
                            ViewModel.optEthnicity[1].Checked = false;
                        }
                        //Set combo boxes
                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                        if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_prefix"]))
                        {
                            for (int i = 0; i <= ViewModel.cboPrefix.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboPrefix.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_prefix"]))
                                {
                                    ViewModel.cboPrefix.SelectedIndex = i;
                                    break;
                            }
                    }
                    if ( ViewModel.cboPrefix.SelectedIndex != -1)
                            {
                                ViewModel.cboSuffix.SelectedIndex = -1;
                            }
                    }
                    else if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_suffix"]))
                    {
                            for (int i = 0; i <= ViewModel.cboSuffix.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboSuffix.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_suffix"]))
                                {
                                    ViewModel.cboSuffix.SelectedIndex = i;
                                    break;
                            }
                    }
                    if ( ViewModel.cboSuffix.SelectedIndex != -1)
                            {
                                ViewModel.cboPrefix.SelectedIndex = -1;
                            }
                    }
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
                    if (!Convert.IsDBNull(IncidentCL.IncidentName["addr_street_type"]))
                    {
                            for (int i = 0; i <= ViewModel.cboStreetType.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboStreetType.GetListItem(i) == IncidentMain.Clean(IncidentCL.IncidentName["addr_street_type"]))
                                {
                                    ViewModel.cboStreetType.SelectedIndex = i;
                                    break;
                            }
                    }
            }
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
            if (!Convert.IsDBNull(IncidentCL.IncidentName["state_code"]))
            {
                    for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboState.GetListItem(i) == Convert.ToString(IncidentCL.IncidentName["state_code"]))
                                {
                                    ViewModel.cboState.SelectedIndex = i;
                                    break;
                            }
                    }
            }
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
            if (!Convert.IsDBNull(IncidentCL.IncidentName["race_code"]))
            {
                    for (int i = 0; i <= ViewModel.cboRace.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboRace.GetItemData(i) == Convert.ToDouble(IncidentCL.IncidentName["race_code"]))
                                {
                                    ViewModel.cboRace.SelectedIndex = i;
                                    break;
                            }
                    }
            }
            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
            if (!Convert.IsDBNull(IncidentCL.IncidentName["incident_role_code"]))
            {
                    for (int i = 0; i <= ViewModel.cboRole.Items.Count - 1; i++)
                            {
                                if ( ViewModel.cboRole.GetItemData(i) == Convert.ToDouble(IncidentCL.IncidentName["incident_role_code"]))
                                {
                                    ViewModel.cboRole.SelectedIndex = i;
                                    break;
                            }
                    }
            }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    }
    IncidentCL.IncidentName.MoveNext();
};
                ViewModel.cboNameList.SelectedIndex = DisplayIndex;
            }
            ViewModel.FirstTime = 0;
            CheckNameComplete();
            ViewModel.NameUpdated = 0;

        }

        private int SaveName()
        {
            //Save Currently Displayed Name Record
            //Determine if Insert (new record) or Update needed
            int result = 0;
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();


            int NameID = Convert.ToInt32(Conversion.Val(ViewModel.lbNameID.Text));
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
            string Birthdate = DateTime.Parse(ViewModel.txtBirthdate.Text).ToString("MM/dd/yyyy");
            if (Information.IsDate(Birthdate))
            {
                IncidentCL.Birthdate = Birthdate;
            }
            else
            {
                IncidentCL.Birthdate = "";
            }
            string tempRefParam5 = IncidentMain.Clean(ViewModel.txtHomePhone.Text);
            IncidentCL.HomePhone = IncidentMain.ProofSQLString(ref tempRefParam5);
            string tempRefParam6 = IncidentMain.Clean(ViewModel.txtWorkPhone.Text);
            IncidentCL.WorkPhone = IncidentMain.ProofSQLString(ref tempRefParam6);
            string tempRefParam7 = IncidentMain.Clean(ViewModel.txtWorkPlace.Text);
            IncidentCL.WorkPlace = IncidentMain.ProofSQLString(ref tempRefParam7);
            if ( ViewModel.optGender[0].Checked)
            {
                IncidentCL.Gender = 1;
            }
            else if ( ViewModel.optGender[1].Checked)
            {
                IncidentCL.Gender = 2;
            }
            else
            {
                IncidentCL.Gender = 0;
            }
            if ( ViewModel.cboRace.SelectedIndex != -1)
            {
                IncidentCL.RaceCode = ViewModel.cboRace.GetItemData(ViewModel.cboRace.SelectedIndex);
            }
            else
            {
                IncidentCL.RaceCode = 0;
            }
            if ( ViewModel.optEthnicity[0].Checked)
            {
                IncidentCL.EthnicityCode = 3;
            }
            else if ( ViewModel.optEthnicity[1].Checked)
            {
                IncidentCL.EthnicityCode = 4;
            }
            else
            {
                IncidentCL.EthnicityCode = 0;
            }
            IncidentCL.HouseNumber = IncidentMain.Clean(ViewModel.txtHouseNumber.Text);
            if ( ViewModel.cboPrefix.SelectedIndex != -1)
            {
                IncidentCL.Prefix = ViewModel.cboPrefix.Text;
            }
            else
            {
                IncidentCL.Prefix = "";
            }
            IncidentCL.Street = IncidentMain.Clean(ViewModel.txtStreetName.Text);
            if ( ViewModel.cboStreetType.SelectedIndex != -1)
            {
                IncidentCL.StreetType = ViewModel.cboStreetType.Text;
            }
            else
            {
                IncidentCL.StreetType = "";
            }
            if ( ViewModel.cboSuffix.SelectedIndex != -1)
            {
                IncidentCL.Suffix = ViewModel.cboSuffix.Text;
            }
            else
            {
                IncidentCL.Suffix = "";
            }
            IncidentCL.City = IncidentMain.Clean(ViewModel.txtCity.Text);
            IncidentCL.Zipcode = IncidentMain.Clean(ViewModel.txtZipcode.Text);
            if ( ViewModel.cboState.SelectedIndex != -1)
            {
                IncidentCL.StateCode = ViewModel.cboState.Text;
            }
            else
            {
                IncidentCL.StateCode = "";
            }
            if ( ViewModel.cboRole.SelectedIndex != -1)
            {
                IncidentCL.IncidentRoleCode = ViewModel.cboRole.GetItemData(ViewModel.cboRole.SelectedIndex);
            }
            else
            {
                IncidentCL.IncidentRoleCode = 0;
            }
            IncidentCL.NameLastUpdate = DateTime.Now.ToString("MM/dd/yyyy");
            IncidentCL.LastUpdateBy = IncidentMain.Shared.gCurrUser;

            if (NameID != 0)
            { // Update Existing Record
                IncidentCL.NameID = NameID;
                if (IncidentCL.UpdateName() != 0)
                {
                    result = -1;
                    ViewModel.NameUpdated = 0;
                }
                else
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Saving Current Incident Name Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
        }
        else
        {
                //Insert New Record
                if (IncidentCL.AddName() != 0)
                {
                    result = -1;
                    ViewModel.NameUpdated = 0;
                }
                else
                {
                    result = 0;
                    ViewManager.ShowMessage("Error Adding New Name Record", "Edit Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                }
        }

        return result;
}


        private int CheckComplete()
        {
            //Check for Entries in Required Fields
            //Flip Colors as needed
            int result = 0;
            if ( ViewModel.FirstTime != 0)
            {
                return result;
            }
            int PropValue = 0, PeopleOut = 0;
            int BusOut = 0, TotalSq = 0;
            int Floors = 0, Basement = 0;
            double NumWork = 0;

            result = -1;
            if ((ViewModel.ADDRESSCORRECTION | ViewModel.AddressUpdated) != 0)
            {
                if ( ViewModel.txtXHouseNumber.Text == "")
                {
                    ViewModel.txtXHouseNumber.BackColor = IncidentMain.Shared.REQCOLOR;
                    ViewModel.txtXHouseNumber.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    result = 0;
            }
            else
            {
                    ViewModel.txtXHouseNumber.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                    ViewModel.txtXHouseNumber.ForeColor = IncidentMain.Shared.FIREFONT;
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
                    ViewModel.txtXStreetName.ForeColor = IncidentMain.Shared.FIREFONT;
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
                    ViewModel.cboCityCode.ForeColor = IncidentMain.Shared.FIREFONT;
                }
        }

        switch ( ViewModel.ReportType)
        {
                case IncidentMain.FIRE:
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.FIREMOBILE:
                case IncidentMain.FIREOUTSIDE:
                    switch ( ViewModel.ReportType)
                    {
                        case IncidentMain.FIRESTRUCTURE:
                            if ( ViewModel.cboGeneralPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboSpecificPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboBuildingStatus.SelectedIndex < 0)
                            {
                                ViewModel.cboBuildingStatus.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBuildingStatus.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboConstructionType.SelectedIndex < 0)
                            {
                                ViewModel.cboConstructionType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboConstructionType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboConstructionType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboBurnDamage.SelectedIndex < 0)
                            {
                                ViewModel.cboBurnDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBurnDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboBurnDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBurnDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboSmokeDamage.SelectedIndex < 0)
                            {
                                ViewModel.cboSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboFirstItemIgnited.SelectedIndex < 0)
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboFirstItemIgnited.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboGenCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGenCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp = 0;
                            if ( ViewModel.txtTotalSqFootage.Text == "")
                            {
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtTotalSqFootage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                            {
                                ViewModel.txtTotalSqFootage.Text = "";
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtTotalSqFootage.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Total Sq Footage", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtTotalSqFootage.Text = "";
                                    ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfStories.Text == "")
                            {
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfStories.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                            {
                                ViewModel.txtNumberOfStories.Text = "";
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfStories.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Stories", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfStories.Text = "";
                                    ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtBasementLevels.Text == "")
                            {
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtBasementLevels.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                            {
                                ViewModel.txtBasementLevels.Text = "";
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtBasementLevels.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Basement Levels", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtBasementLevels.Text = "";
                                    ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfUnits.Text == "")
                            {
                                ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfUnits.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
                            {
                                ViewModel.txtNumberOfUnits.Text = "";
                                ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfUnits.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Units/Suites", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfUnits.Text = "";
                                    ViewModel.txtNumberOfUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.txtNumberOfUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtNumberOfUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                        }
                        double dbNumericTemp5 = 0;
                        if ( ViewModel.txtNumberOfOccupants.Text == "")
                            {
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfOccupants.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
                            {
                                ViewModel.txtNumberOfOccupants.Text = "";
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfOccupants.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Occupants", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfOccupants.Text = "";
                                    ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfBusinesses.Text == "")
                            {
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfBusinesses.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp6))
                            {
                                ViewModel.txtNumberOfBusinesses.Text = "";
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfBusinesses.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Businesses", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfBusinesses.Text = "";
                                    ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp7))
                            {
                                ViewModel.txtPropValue.Text = "";
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtPropValue.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtPropValue.Text = "";
                                    ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtFloorOfOrigin.Text == "")
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtFloorOfOrigin.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp8))
                            {
                                ViewModel.txtFloorOfOrigin.Text = "";
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Floors)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                        else if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Basement)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtSqFtBurned.Text == "")
                            {
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtSqFtBurned.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp9))
                            {
                                ViewModel.txtSqFtBurned.Text = "";
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtBurned.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtBurned.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtBurned.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Burned May NOT Exceed Total Sq Footage", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtBurned.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtBurned.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp10 = 0;
                            if ( ViewModel.txtSqFtSmokeDamage.Text == "")
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtSqFtSmokeDamage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp10))
                            {
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Smoke Damaged May NOT Exceed Total Sq Footage", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                                    BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp11 = 0;
                            if ( ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp11))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp12 = 0;
                            if ( ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp12))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            //Check other loss fields for numeric and value 
                            if ( ViewModel.txtNoBusinessDisplaced.Text != "")
                            {
                                double dbNumericTemp13 = 0;
                                if (!Double.TryParse(ViewModel.txtNoBusinessDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp13))
                                {
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoBusinessDisplaced.Text)) > BusOut)
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtNoPeopleDisplaced.Text != "")
                            {
                                double dbNumericTemp14 = 0;
                                if (!Double.TryParse(ViewModel.txtNoPeopleDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp14))
                                {
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoPeopleDisplaced.Text)) > PeopleOut)
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtJobsLost.Text != "")
                            {
                                double dbNumericTemp15 = 0;
                                if (!Double.TryParse(ViewModel.txtJobsLost.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp15))
                                {
                                    ViewModel.txtJobsLost.Text = "";
                                }
                        }
                        if ( ViewModel.optAlarmType[1].Checked)
                            {
                                if ( ViewModel.cboAlarmType.SelectedIndex < 0)
                                {
                                    ViewModel.cboAlarmType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboAlarmType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.cboAlarmType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if ( ViewModel.cboEffectiveness.SelectedIndex < 0)
                                {
                                    if ( ViewModel.chkAlarmOperation.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                                    {
                                        ViewModel.cboEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboEffectiveness.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                        else if ( ViewModel.optAlarmType[2].Checked)
                            {
                                if ( ViewModel.cboAlarmType.SelectedIndex < 0)
                                {
                                    ViewModel.cboAlarmType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboAlarmType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.cboAlarmType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if ( ViewModel.cboEffectiveness.SelectedIndex < 0)
                                {
                                    if ( ViewModel.chkAlarmOperation.CheckState != UpgradeHelpers.Helpers.CheckState.Unchecked)
                                    {
                                        ViewModel.cboEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.cboEffectiveness.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                                if ( ViewModel.cboInitiatingDevice.SelectedIndex < 0)
                                {
                                    ViewModel.cboInitiatingDevice.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboInitiatingDevice.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.optExtinguish[1].Checked)
                            {
                                if ( ViewModel.cboSysType.SelectedIndex < 0)
                                {
                                    ViewModel.cboSysType.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboSysType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.cboSysType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.cboSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                                }
                                if ( ViewModel.cboExtEffectiveness.SelectedIndex < 0)
                                {
                                    ViewModel.cboExtEffectiveness.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboExtEffectiveness.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.HumansAFactor != 0)
                            {
                                ViewModel.frmHFDetail.Visible = true;
                                ViewModel.lstHumanContribFactors.Width = 309;
                                double dbNumericTemp16 = 0;
                                if ( ViewModel.txtHFAge.Text == "")
                                {
                                    ViewModel.txtHFAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtHFAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else if (!Double.TryParse(ViewModel.txtHFAge.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp16))
                                {
                                    ViewModel.txtHFAge.Text = "";
                                    ViewModel.txtHFAge.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtHFAge.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                                ViewModel.lstHumanContribFactors.Width = 393;
                            }

                            break;
                    case IncidentMain.FIREMOBILE:
                            if ( ViewModel.cboMobilePropType.SelectedIndex == -1)
                            {
                                ViewModel.cboMobilePropType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobilePropType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboMobileMake.SelectedIndex == -1)
                            {
                                ViewModel.cboMobileMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobileMake.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboMobileMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                if ( ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == "00")
                                { //Other make selected
                                    if ( ViewModel.txtVehicleMake.Text == "")
                                    {
                                        ViewModel.txtVehicleMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtVehicleMake.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtVehicleYear.Text == "")
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtVehicleYear.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp17))
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtVehicleYear.Text = "";
                                result = 0;
                                ViewModel.lbVYearMes.Visible = true;
                            }
                            else if (Strings.Len(ViewModel.txtVehicleYear.Text) != 4)
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtMobilePropValue.Text == "")
                            {
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtMobilePropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp18))
                            {
                                ViewModel.txtMobilePropValue.Text = "";
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtMobilePropValue.Text);
                                if (NumWork > 2000000)
                                { //2 Million max for vehicles

                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtMobilePropValue.Text = "";
                                    ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.txtMobilePropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PropValue = Convert.ToInt32(NumWork);
                            }
                    }
                    if ( ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboFirstItemIgnited.SelectedIndex < 0)
                            {
                                ViewModel.cboFirstItemIgnited.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboFirstItemIgnited.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboFirstItemIgnited.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboFirstItemIgnited.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboGenCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboGenCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGenCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboGenCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGenCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp19 = 0;
                            if ( ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp19))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp20 = 0;
                            if ( ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp20))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }

                            break;
                    case IncidentMain.FIREOUTSIDE:
                            if ( ViewModel.cboOSHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboOSHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSHeatSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboOSCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboOSCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboOSAreaUnits.SelectedIndex < 0)
                            {
                                ViewModel.cboOSAreaUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp21 = 0;
                            if ( ViewModel.txtOSLoss.Text == "")
                            {
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp21))
                            {
                                ViewModel.txtOSLoss.Text = "";
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtOSLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp22 = 0;
                            if ( ViewModel.txtOSAreaAffected.Text == "")
                            {
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp22))
                            {
                                ViewModel.txtOSAreaAffected.Text = "";
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtOSAreaAffected.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSAreaAffected.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboOSMaterialInvolved.Visible)
                            {
                                if ( ViewModel.cboOSMaterialInvolved.SelectedIndex == -1)
                                {
                                    ViewModel.cboOSMaterialInvolved.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.cboOSMaterialInvolved.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
        //********************************************************************* 
        //***   Rupture / Explosion 
        //********************************************************************* 
        break;
case IncidentMain.RUPTURE:
case IncidentMain.RUPTURESTRUCTURE:
case IncidentMain.RUPTUREMOBILE:
case IncidentMain.RUPTUREOUTSIDE:
        switch ( ViewModel.ReportType)
        {
                case IncidentMain.RUPTURESTRUCTURE:
                        if ( ViewModel.cboGeneralPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboGeneralPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboGeneralPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboGeneralPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboGeneralPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboSpecificPropertyUse.SelectedIndex < 0)
                            {
                                ViewModel.cboSpecificPropertyUse.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboSpecificPropertyUse.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboSpecificPropertyUse.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboSpecificPropertyUse.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboBuildingStatus.SelectedIndex < 0)
                            {
                                ViewModel.cboBuildingStatus.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboBuildingStatus.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboBuildingStatus.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboBuildingStatus.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboConstructionType.SelectedIndex < 0)
                            {
                                ViewModel.cboConstructionType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboConstructionType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboConstructionType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboConstructionType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp23 = 0;
                            if ( ViewModel.txtTotalSqFootage.Text == "")
                            {
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtTotalSqFootage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp23))
                            {
                                ViewModel.txtTotalSqFootage.Text = "";
                                ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtTotalSqFootage.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Total Sq Footage", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtTotalSqFootage.Text = "";
                                    ViewModel.txtTotalSqFootage.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtTotalSqFootage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfStories.Text == "")
                            {
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfStories.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp24))
                            {
                                ViewModel.txtNumberOfStories.Text = "";
                                ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfStories.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Stories", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfStories.Text = "";
                                    ViewModel.txtNumberOfStories.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfStories.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtBasementLevels.Text == "")
                            {
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtBasementLevels.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp25))
                            {
                                ViewModel.txtBasementLevels.Text = "";
                                ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtBasementLevels.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Basement Levels", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtBasementLevels.Text = "";
                                    ViewModel.txtBasementLevels.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtBasementLevels.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfOccupants.Text == "")
                            {
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfOccupants.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp26))
                            {
                                ViewModel.txtNumberOfOccupants.Text = "";
                                ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfOccupants.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Occupants", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfOccupants.Text = "";
                                    ViewModel.txtNumberOfOccupants.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfOccupants.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtNumberOfBusinesses.Text == "")
                            {
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtNumberOfBusinesses.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp27))
                            {
                                ViewModel.txtNumberOfBusinesses.Text = "";
                                ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtNumberOfBusinesses.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Number of Businesses", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtNumberOfBusinesses.Text = "";
                                    ViewModel.txtNumberOfBusinesses.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNumberOfBusinesses.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                    if ( ViewModel.txtPropValue.Text == "")
                            {
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp28))
                            {
                                ViewModel.txtPropValue.Text = "";
                                ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                NumWork = Double.Parse(ViewModel.txtPropValue.Text);
                                if (NumWork > 2147483647)
                                {
                                    ViewManager.ShowMessage("You have Entered an Unreasonable Number in Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    ViewModel.txtPropValue.Text = "";
                                    ViewModel.txtPropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtPropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    result = 0;
                            }
                            else
                            {
                                    ViewModel.txtPropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                    ViewModel.txtPropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                    PropValue = Convert.ToInt32(NumWork);
                            }
                    }
                    double dbNumericTemp29 = 0;
                    if ( ViewModel.txtFloorOfOrigin.Text == "")
                            {
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtFloorOfOrigin.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp29))
                            {
                                ViewModel.txtFloorOfOrigin.Text = "";
                                ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Floors)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                        else if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                            {
                                if (Conversion.Val(ViewModel.txtFloorOfOrigin.Text) > Basement)
                                {
                                    ViewModel.txtFloorOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtFloorOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtSqFtSmokeDamage.Text == "")
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtSqFtSmokeDamage.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp30))
                            {
                                ViewModel.txtSqFtSmokeDamage.Text = "";
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text)) > TotalSq)
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtSqFtSmokeDamage.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Sq Foot Damaged May NOT Exceed Total Sq Footage", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtSqFtSmokeDamage.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtSqFtSmokeDamage.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp31 = 0;
                            if ( ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp31))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp32 = 0;
                            if ( ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp32))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            //Check other loss fields for numeric and value 
                            if ( ViewModel.txtNoBusinessDisplaced.Text != "")
                            {
                                double dbNumericTemp33 = 0;
                                if (!Double.TryParse(ViewModel.txtNoBusinessDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp33))
                                {
                                    ViewModel.txtNoBusinessDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoBusinessDisplaced.Text)) > BusOut)
                                {
                                    ViewModel.txtNoBusinessDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoBusinessDisplaced.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtNoPeopleDisplaced.Text != "")
                            {
                                double dbNumericTemp34 = 0;
                                if (!Double.TryParse(ViewModel.txtNoPeopleDisplaced.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp34))
                                {
                                    ViewModel.txtNoPeopleDisplaced.Text = "";
                                }
                                else if (Convert.ToInt32(Double.Parse(ViewModel.txtNoPeopleDisplaced.Text)) > PeopleOut)
                                {
                                    ViewModel.txtNoPeopleDisplaced.BackColor = IncidentMain.Shared.REQCOLOR;
                                    ViewModel.txtNoPeopleDisplaced.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
                            if ( ViewModel.txtJobsLost.Text != "")
                            {
                                double dbNumericTemp35 = 0;
                                if (!Double.TryParse(ViewModel.txtJobsLost.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp35))
                                {
                                    ViewModel.txtJobsLost.Text = "";
                                }
                        }
                        break;
                case IncidentMain.RUPTUREMOBILE:
                        if ( ViewModel.cboMobilePropType.SelectedIndex < 0)
                            {
                                ViewModel.cboMobilePropType.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobilePropType.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboMobilePropType.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobilePropType.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboMobileMake.SelectedIndex == -1)
                            {
                                ViewModel.cboMobileMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboMobileMake.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboMobileMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboMobileMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                if ( ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == "00")
                                { //Other make selected
                                    if ( ViewModel.txtVehicleMake.Text == "")
                                    {
                                        ViewModel.txtVehicleMake.BackColor = IncidentMain.Shared.REQCOLOR;
                                        ViewModel.txtVehicleMake.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        result = 0;
                                }
                                else
                                {
                                        ViewModel.txtVehicleMake.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                        ViewModel.txtVehicleMake.ForeColor = IncidentMain.Shared.FIREFONT;
                                    }
                            }
                    }
                    if ( ViewModel.txtVehicleYear.Text == "")
                            {
                                ViewModel.txtVehicleYear.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtVehicleYear.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtVehicleYear.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtVehicleYear.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp36 = 0;
                            if ( ViewModel.txtMobilePropValue.Text == "")
                            {
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtMobilePropValue.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp36))
                            {
                                ViewModel.txtMobilePropValue.Text = "";
                                ViewModel.txtMobilePropValue.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtMobilePropValue.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtMobilePropValue.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtMobilePropValue.ForeColor = IncidentMain.Shared.FIREFONT;
                                PropValue = Convert.ToInt32(Conversion.Val(ViewModel.txtMobilePropValue.Text));
                            }
                            if ( ViewModel.cboAreaOfOrigin.SelectedIndex < 0)
                            {
                                ViewModel.cboAreaOfOrigin.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboAreaOfOrigin.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboAreaOfOrigin.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboAreaOfOrigin.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboHeatSource.SelectedIndex < 0)
                            {
                                ViewModel.cboHeatSource.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboHeatSource.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboHeatSource.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboHeatSource.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp37 = 0;
                            if ( ViewModel.txtPropLoss.Text == "")
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp37))
                            {
                                ViewModel.txtPropLoss.Text = "";
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (Conversion.Val(ViewModel.txtPropLoss.Text) > PropValue)
                            {
                                ViewModel.txtPropLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtPropLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                                ViewManager.ShowMessage("Property Loss May NOT Exceed Property Value", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                            }
                            else
                            {
                                ViewModel.txtPropLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtPropLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp38 = 0;
                            if ( ViewModel.txtContentLoss.Text == "")
                            {
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp38))
                            {
                                ViewModel.txtContentLoss.Text = "";
                                ViewModel.txtContentLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtContentLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtContentLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtContentLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }

                            break;
                    case IncidentMain.RUPTUREOUTSIDE:
                            if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex < 0)
                            {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSSpecCauseOfIgnition.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSSpecCauseOfIgnition.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            if ( ViewModel.cboOSAreaUnits.SelectedIndex < 0)
                            {
                                ViewModel.cboOSAreaUnits.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.cboOSAreaUnits.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.cboOSAreaUnits.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.cboOSAreaUnits.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp39 = 0;
                            if ( ViewModel.txtOSLoss.Text == "")
                            {
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp39))
                            {
                                ViewModel.txtOSLoss.Text = "";
                                ViewModel.txtOSLoss.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSLoss.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else
                        {
                                ViewModel.txtOSLoss.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                ViewModel.txtOSLoss.ForeColor = IncidentMain.Shared.FIREFONT;
                            }
                            double dbNumericTemp40 = 0;
                            if ( ViewModel.txtOSAreaAffected.Text == "")
                            {
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
                                result = 0;
                        }
                        else if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp40))
                            {
                                ViewModel.txtOSAreaAffected.Text = "";
                                ViewModel.txtOSAreaAffected.BackColor = IncidentMain.Shared.REQCOLOR;
                                ViewModel.txtOSAreaAffected.ForeColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(IncidentMain.WHITE);
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
if (result != 0)
{
                ViewModel.cmdSave[0].Enabled = true;
            }
            else
            {
                ViewModel.cmdSave[0].Enabled = false;
                if ( ViewModel.ReportType == IncidentMain.FIREMOBILE)
                {
                    ViewModel.cmdSave[1].Enabled = ViewModel.cboMobilePropType.SelectedIndex != -1;
                }
        }

        return result;
}

        private void GetCommonData()
        {

            int CauseClass = 0;
            int PropClass = 0;
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();


            //Retrieve Fire Report Data
            if (~FireReport.GetFireReport(ViewModel.FireReportID) != 0)
            {
                ViewManager.ShowMessage("Error Retrieving Fire Report", "Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            int AreaOfOrigin = FireReport.AreaOfOrigin;
            int CauseOfIgnition = FireReport.CauseOfIgnition;
            int PropUse = FireReport.PropertyUse;

            //Set Heat Source Code
            for (int i = 0; i <= ViewModel.cboHeatSource.Items.Count - 1; i++)
            {
                if ( ViewModel.cboHeatSource.GetItemData(i) == FireReport.HeatSource)
                {
                    ViewModel.cboHeatSource.SelectedIndex = i;
                    break;
            }
    }
    //Set First Item Ignited Code
    for (int i = 0; i <= ViewModel.cboFirstItemIgnited.Items.Count - 1; i++)
            {
                if ( ViewModel.cboFirstItemIgnited.GetItemData(i) == FireReport.FirstItemIgnited)
                {
                    ViewModel.cboFirstItemIgnited.SelectedIndex = i;
                    break;
            }
    }
    //Set remaining textbox values
    if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
            {
                ViewModel.txtPropValue.Text = FireReport.PropertyValue.ToString();
            }
            else
            {
                ViewModel.txtMobilePropValue.Text = FireReport.PropertyValue.ToString();
            }
            ViewModel.txtPropLoss.Text = FireReport.PropertyLoss.ToString();
            ViewModel.txtContentLoss.Text = FireReport.ContentLoss.ToString();

            //Load Dependent Listboxes and Set Values in dependent and master combos
            //Property Use - Cause of Ignition - Area of Origin
            //    cboSpecificPropertyUse.Clear
            //    cboMobilePropType.Clear
            //    cboSpecCauseOfIgnition.Clear
            //    cboAreaOfOrigin.Clear
            //Property Use
            if (FireCodes.GetPropertyUseByCode(PropUse) != 0)
            {
                FireCodes.PropertyUse.Open();
                if (!FireCodes.PropertyUse.EOF)
                {
                    PropClass = Convert.ToInt32(FireCodes.PropertyUse["property_use_class"]);
                    if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
                    {
                        ViewModel.cboSpecificPropertyUse.Items.Clear();

                        while (!FireCodes.PropertyUse.EOF)
                        {
                            ViewModel.cboSpecificPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                            ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                            FireCodes.PropertyUse.MoveNext();
                    }
                        ;
                        //Set Values
                        for (int i = 0; i <= ViewModel.cboGeneralPropertyUse.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboGeneralPropertyUse.GetItemData(i) == PropClass)
                            {
                                ViewModel.cboGeneralPropertyUse.SelectedIndex = i;
                                break;
                        }
                }
                        for (int i = 0; i <= ViewModel.cboSpecificPropertyUse.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboSpecificPropertyUse.GetItemData(i) == PropUse)
                            {
                                ViewModel.cboSpecificPropertyUse.SelectedIndex = i;
                                break;
                        }
                }
        }
        else
        {
                //Set Values
                for (int i = 0; i <= ViewModel.cboMobilePropType.Items.Count - 1; i++)
                        {
                            if ( ViewModel.cboMobilePropType.GetItemData(i) == PropUse)
                            {
                                ViewModel.cboMobilePropType.SelectedIndex = i;
                                break;
                        }
                }
        }
}
}

            //Area of Origin
            ViewModel.cboAreaOfOrigin.Items.Clear();

            while (!FireCodes.AreaOfOrigin.EOF)
            {
                ViewModel.cboAreaOfOrigin.AddItem(Convert.ToString(FireCodes.AreaOfOrigin["description"]));
                ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                FireCodes.AreaOfOrigin.MoveNext();
        };
        //Set Values
        for (int i = 0; i <= ViewModel.cboAreaOfOrigin.Items.Count - 1; i++)
            {
                if ( ViewModel.cboAreaOfOrigin.GetItemData(i) == AreaOfOrigin)
                {
                    ViewModel.cboAreaOfOrigin.SelectedIndex = i;
                    break;
            }
    }

            //Cause of Ignition
            ViewModel.cboSpecCauseOfIgnition.Items.Clear();
            FireCodes.GetCauseOfIgnitionByCode(CauseOfIgnition);
            if (!FireCodes.CauseOfIgnition.EOF)
            {
                CauseClass = Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_class"]);

                while (!FireCodes.CauseOfIgnition.EOF)
                {
                    //            If FireCodes.CauseOfIgnition("cause_of_ignition_code") <> 35 Then
                    ViewModel.cboSpecCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnition["description"]));
                    ViewModel.cboSpecCauseOfIgnition.SetItemData(ViewModel.cboSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_code"]));
                    //            End If
                    FireCodes.CauseOfIgnition.MoveNext();
            };
    }
    else
    {
            CauseClass = 0;
    }

    while (!FireCodes.CauseOfIgnition.EOF)
    {
                ViewModel.cboSpecCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnition["description"]));
                ViewModel.cboSpecCauseOfIgnition.SetItemData(ViewModel.cboSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_code"]));
                FireCodes.CauseOfIgnition.MoveNext();
        };
        //Set Values
        for (int i = 0; i <= ViewModel.cboGenCauseOfIgnition.Items.Count - 1; i++)
            {
                if ( ViewModel.cboGenCauseOfIgnition.GetItemData(i) == CauseClass)
                {
                    ViewModel.cboGenCauseOfIgnition.SelectedIndex = i;
                    break;
            }
    }
    for (int i = 0; i <= ViewModel.cboSpecCauseOfIgnition.Items.Count - 1; i++)
            {
                if ( ViewModel.cboSpecCauseOfIgnition.GetItemData(i) == CauseOfIgnition)
                {
                    ViewModel.cboSpecCauseOfIgnition.SelectedIndex = i;
                    break;
            }
    }

    //Set Values Supporting Tables
    //Physical Contributing Factors
    if (FireReport.GetFirePhysicalContributingFactor(ViewModel.FireReportID))
    {

            while (!FireReport.PhysicalContributingFactor.EOF)
            {
                    for (int i = 0; i <= ViewModel.lstPhysicalContribFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstPhysicalContribFactors.GetItemData(i) == Convert.ToDouble(FireReport.PhysicalContributingFactor["physical_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstPhysicalContribFactors, i, true);
                            break;
                    }
            }
            FireReport.PhysicalContributingFactor.MoveNext();
    };
}

//Human Contributing Factors
if (FireReport.GetFireHumanContributingFactor(ViewModel.FireReportID) != 0)
{

    while (!FireReport.HumanContributingFactor.EOF)
    {
            for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstHumanContribFactors.GetItemData(i) == Convert.ToDouble(FireReport.HumanContributingFactor["human_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstHumanContribFactors, i, true);
                            if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
                            {
                                ViewModel.lstHumanContribFactors.Width = 309;
                                ViewModel.frmHFDetail.Visible = true;
                                if (Convert.ToDouble(FireReport.HumanContributingFactor["hf_gender"]) == 2)
                                {
                                    ViewModel.optHFGender[1].Checked = true;
                                }
                                //UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                ViewModel.txtHFAge.Text = Convert.ToString(IncidentMain.GetVal(FireReport.HumanContributingFactor["hf_age"]));
                                ViewModel.HumansAFactor = -1;
                            }
                            break;
                    }
            }
            FireReport.HumanContributingFactor.MoveNext();
    };
}

//Suppression Factors
if (FireReport.GetFireSuppressionFactor(ViewModel.FireReportID))
{

    while (!FireReport.FireSuppressionFactor.EOF)
    {
            for (int i = 0; i <= ViewModel.lstSuppressionFactors.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstSuppressionFactors.GetItemData(i) == Convert.ToDouble(FireReport.FireSuppressionFactor["suppression_factor_code"]))
                        {
                            UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstSuppressionFactors, i, true);
                            break;
                    }
            }
            FireReport.FireSuppressionFactor.MoveNext();
    };
}
if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
            {
                //Items Contributing to Fire Spread

                if (FireReport.GetFireItemContributingFireSpread(ViewModel.FireReportID))
                {

                    while (!FireReport.ItemContributingFireSpread.EOF)
                    {
                        for (int i = 0; i <= ViewModel.lstItemContribFireSpread.Items.Count - 1; i++)
                        {
                            if ( ViewModel.lstItemContribFireSpread.GetItemData(i) == Convert.ToDouble(FireReport.ItemContributingFireSpread["item_contributing_fire_spread_code"]))
                            {
                                UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstItemContribFireSpread, i, true);
                                break;
                        }
                }
                FireReport.ItemContributingFireSpread.MoveNext();
        };
}
//Equipment Involved in Ignition

if (FireReport.GetFireEquipmentInvolved(ViewModel.FireReportID) != 0)
{

        while (!FireReport.FireEquipmentInvolved.EOF)
        {
                for (int i = 0; i <= ViewModel.lstEquipInvolvIgnition.Items.Count - 1; i++)
                        {
                            if ( ViewModel.lstEquipInvolvIgnition.GetItemData(i) == Convert.ToDouble(FireReport.FireEquipmentInvolved["equipment_involved_code"]))
                            {
                                UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstEquipInvolvIgnition, i, true);
                                break;
                        }
                }
                FireReport.FireEquipmentInvolved.MoveNext();
        };
}
}

}

        private void GetStructureData()
        {
            //Retrieve Current Structure Report Data
            //Load Data into Controls
            //Load dependent combos and set selections in both dependent
            //and master combos
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();

            GetCommonData();

            //Retrieve FireStructure Data
            if (~FireReport.GetFireStructure(ViewModel.FireReportID) != 0)
            {
                ViewManager.ShowMessage("Error Retrieving Fire Structure Record", "Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            //Set Building Status Code
            for (int i = 0; i <= ViewModel.cboBuildingStatus.Items.Count - 1; i++)
            {
                if ( ViewModel.cboBuildingStatus.GetItemData(i) == FireReport.BuildingStatus)
                {
                    ViewModel.cboBuildingStatus.SelectedIndex = i;
                    break;
            }
    }
            //Set Burn Damage Code
            for (int i = 0; i <= ViewModel.cboBurnDamage.Items.Count - 1; i++)
            {
                if ( ViewModel.cboBurnDamage.GetItemData(i) == FireReport.BurnDamage)
                {
                    ViewModel.cboBurnDamage.SelectedIndex = i;
                    break;
            }
    }
            //Set Smoke Damage Code
            for (int i = 0; i <= ViewModel.cboSmokeDamage.Items.Count - 1; i++)
            {
                if ( ViewModel.cboSmokeDamage.GetItemData(i) == FireReport.SmokeDamage)
                {
                    ViewModel.cboSmokeDamage.SelectedIndex = i;
                    break;
            }
    }
            //Set Construction Type Code
            for (int i = 0; i <= ViewModel.cboConstructionType.Items.Count - 1; i++)
            {
                if ( ViewModel.cboConstructionType.GetItemData(i) == FireReport.ConstructionType)
                {
                    ViewModel.cboConstructionType.SelectedIndex = i;
                    break;
            }
    }

            //Set remaining textbox values
            if (FireReport.SpecialFloor == 1)
            {
                ViewModel.optFloor[0].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else if (FireReport.SpecialFloor == 2)
            {
                ViewModel.optFloor[1].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else if (FireReport.SpecialFloor == 3)
            {
                ViewModel.optFloor[2].CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            ViewModel.txtFloorOfOrigin.Text = FireReport.FloorOfOrigin.ToString();
            ViewModel.txtNumberOfStories.Text = FireReport.NumberOfStories.ToString();
            ViewModel.txtBasementLevels.Text = FireReport.BasementLevels.ToString();
            ViewModel.txtTotalSqFootage.Text = FireReport.TotalSqFootage.ToString();
            ViewModel.txtNumberOfOccupants.Text = FireReport.PeopleOccuping.ToString();
            ViewModel.txtNumberOfBusinesses.Text = FireReport.BusinessesOccuping.ToString();
            ViewModel.txtSqFtBurned.Text = FireReport.SqFootBurned.ToString();
            ViewModel.txtSqFtSmokeDamage.Text = FireReport.SqFootSmokeDamaged.ToString();
            ViewModel.txtNoPeopleDisplaced.Text = FireReport.PeopleDisplaced.ToString();
            ViewModel.txtNoBusinessDisplaced.Text = FireReport.BusinessesDisplaced.ToString();
            ViewModel.txtJobsLost.Text = FireReport.JobsLost.ToString();
            ViewModel.txtNumberOfUnits.Text = FireReport.NumberOfUnits.ToString();
            if (FireReport.FlagRental != 0)
            {
                ViewModel.chkRental.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
            }
            else
            {
                ViewModel.chkRental.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
            }


            //Alarm System Formating
            if (~FireReport.FlagNoAlarm != 0)
            {
                ViewModel.chkAlarmOperation.Enabled = true;
                ViewModel.chkAlarmOperation.ForeColor = IncidentMain.Shared.FIREFONT;
                if (FireReport.FlagAlarmOperation != 0)
                {
                    ViewModel.chkAlarmOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                }
                else
                {
                    ViewModel.chkAlarmOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                }
                ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.cboEffectiveness.Enabled = true;
                ViewModel.cboEffectiveness.Items.Clear();
                ViewModel.lbAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.cboAlarmType.Enabled = true;
                ViewModel.cboAlarmType.Items.Clear();
                if (FireReport.FireAlarmType == IncidentMain.DETECTORONLY)
                {
                    //Unit Detectors Only
                    ViewModel.optAlarmType[1].Checked = true;
                    //Alarm Type Combo is Used for Detector Power Code
                    ViewModel.lbAlarmType.Text = "DETECTOR POWER";
                    //Fill combo boxes
                    FireCodes.GetEffectiveness("D");

                    while (!FireCodes.Effectiveness.EOF)
                    {
                        ViewModel.cboEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                        ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                        FireCodes.Effectiveness.MoveNext();
                }
                    ;
                    FireCodes.GetDetectorPowerCodes();
                    //Detector Power

                    while (!FireCodes.DetectorPower.EOF)
                    {
                        ViewModel.cboAlarmType.AddItem(Convert.ToString(FireCodes.DetectorPower["description"]));
                        ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.DetectorPower["detector_power_code"]));
                        FireCodes.DetectorPower.MoveNext();
                }
                    ;
                    //Set values
                    for (int i = 0; i <= ViewModel.cboEffectiveness.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboEffectiveness.GetItemData(i) == FireReport.AlarmEffectiveness)
                        {
                            ViewModel.cboEffectiveness.SelectedIndex = i;
                            break;
                    }
            }
                    //Detector Power
                    for (int i = 0; i <= ViewModel.cboAlarmType.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboAlarmType.GetItemData(i) == FireReport.DetectorPower)
                        {
                            ViewModel.cboAlarmType.SelectedIndex = i;
                            break;
                    }
            }
    }
    else
    {
                    //Alarm System
                    ViewModel.optAlarmType[2].Checked = true;
                    ViewModel.lbInitiatingDevice.Visible = true;
                    ViewModel.cboInitiatingDevice.Visible = true;
                    ViewModel.cboInitiatingDevice.Items.Clear();
                    ViewModel.lbReasonFailure.Visible = true;
                    ViewModel.lstAlarmFailure.Visible = true;
                    ViewModel.lstAlarmFailure.Items.Clear();
                    //Fill combo boxes
                    FireCodes.GetEffectiveness("A");

                    while (!FireCodes.Effectiveness.EOF)
                    {
                        ViewModel.cboEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                        ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                        FireCodes.Effectiveness.MoveNext();
                }
                    ;
                    FireCodes.GetFireSystemType("A");

                    while (!FireCodes.FireSystemType.EOF)
                    {
                        ViewModel.cboAlarmType.AddItem(Convert.ToString(FireCodes.FireSystemType["description"]));
                        ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                        FireCodes.FireSystemType.MoveNext();
                }
                    ;
                    FireCodes.GetSystemFailure("A");

                    while (!FireCodes.SystemFailure.EOF)
                    {
                        ViewModel.lstAlarmFailure.AddItem(Convert.ToString(FireCodes.SystemFailure["description"]));
                        ViewModel.lstAlarmFailure.SetItemData(ViewModel.lstAlarmFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure["system_failure_code"]));
                        FireCodes.SystemFailure.MoveNext();
                }
                    ;
                    FireCodes.GetAlarmDevice();
                    while (!FireCodes.AlarmDevice.EOF)
                    {
                        ViewModel.cboInitiatingDevice.AddItem(Convert.ToString(FireCodes.AlarmDevice["description"]));
                        ViewModel.cboInitiatingDevice.SetItemData(ViewModel.cboInitiatingDevice.GetNewIndex(), Convert.ToInt32(FireCodes.AlarmDevice["alarm_device_code"]));
                        FireCodes.AlarmDevice.MoveNext();
                }
                    ;
                    //Set Values
                    for (int i = 0; i <= ViewModel.cboEffectiveness.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboEffectiveness.GetItemData(i) == FireReport.AlarmEffectiveness)
                        {
                            ViewModel.cboEffectiveness.SelectedIndex = i;
                            break;
                    }
            }
                    for (int i = 0; i <= ViewModel.cboAlarmType.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboAlarmType.GetItemData(i) == FireReport.FireAlarmType)
                        {
                            ViewModel.cboAlarmType.SelectedIndex = i;
                            break;
                    }
            }
                    for (int i = 0; i <= ViewModel.cboInitiatingDevice.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboInitiatingDevice.GetItemData(i) == FireReport.InitiatingDevice)
                        {
                            ViewModel.cboInitiatingDevice.SelectedIndex = i;
                            break;
                    }
            }
                    //Retrieve System Failure Codes
                    if (FireReport.GetFireSystemsFailure(ViewModel.FireReportID, "A") != 0)
                    {

                        while (!FireReport.FireSystemsFailure.EOF)
                        {
                            for (int i = 0; i <= ViewModel.lstAlarmFailure.Items.Count - 1; i++)
                            {
                                if ( ViewModel.lstAlarmFailure.GetItemData(i) == Convert.ToDouble(FireReport.FireSystemsFailure["sys_code"]))
                                {
                                    UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstAlarmFailure, i, true);
                                    break;
                            }
                    }
                    FireReport.FireSystemsFailure.MoveNext();
            };
    }
}
}
else
{
                ViewModel.optAlarmType[0].Checked = true;
            }

            //Extinguishing System
            if (~FireReport.FlagNoExtinguishSystem != 0)
            {
                //Extinguishing System Data Present
                ViewModel.optExtinguish[1].Checked = true;
                ViewModel.chkExtOperation.Enabled = true;
                ViewModel.chkExtOperation.ForeColor = IncidentMain.Shared.FIREFONT;
                if (FireReport.FlagExtinguishOperation != 0)
                {
                    ViewModel.chkExtOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
                }
                else
                {
                    ViewModel.chkExtOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                }
                ViewModel.lbSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.cboSysType.Enabled = true;
                ViewModel.cboSysType.Items.Clear();
                ViewModel.lbExtEffective.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.cboExtEffectiveness.Enabled = true;
                ViewModel.cboExtEffectiveness.Items.Clear();
                ViewModel.lbSysReasonFailure.ForeColor = IncidentMain.Shared.FIREFONT;
                ViewModel.lstExtFailure.Enabled = true;
                ViewModel.lstExtFailure.Items.Clear();
                //Fill combo boxes
                FireCodes.GetEffectiveness("E");

                while (!FireCodes.Effectiveness.EOF)
                {
                    ViewModel.cboExtEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                    ViewModel.cboExtEffectiveness.SetItemData(ViewModel.cboExtEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                    FireCodes.Effectiveness.MoveNext();
            }
                ;
                FireCodes.GetFireSystemType("E");

                while (!FireCodes.FireSystemType.EOF)
                {
                    ViewModel.cboSysType.AddItem(Convert.ToString(FireCodes.FireSystemType["description"]));
                    ViewModel.cboSysType.SetItemData(ViewModel.cboSysType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType[0]));
                    FireCodes.FireSystemType.MoveNext();
            }
                ;
                FireCodes.GetSystemFailure("E");

                while (!FireCodes.SystemFailure.EOF)
                {
                    ViewModel.lstExtFailure.AddItem(Convert.ToString(FireCodes.SystemFailure["description"]));
                    ViewModel.lstExtFailure.SetItemData(ViewModel.lstExtFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure[0]));
                    FireCodes.SystemFailure.MoveNext();
            }
                ;
                //Set Values
                for (int i = 0; i <= ViewModel.cboExtEffectiveness.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboExtEffectiveness.GetItemData(i) == FireReport.ExtinguishEffectiveness)
                    {
                        ViewModel.cboExtEffectiveness.SelectedIndex = i;
                        break;
                }
        }
                for (int i = 0; i <= ViewModel.cboSysType.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboSysType.GetItemData(i) == FireReport.ExtinguishType)
                    {
                        ViewModel.cboSysType.SelectedIndex = i;
                        break;
                }
        }
                //Retrieve System Failure Codes
                if (FireReport.GetFireSystemsFailure(ViewModel.FireReportID, "E") != 0)
                {

                    while (!FireReport.FireSystemsFailure.EOF)
                    {
                        for (int i = 0; i <= ViewModel.lstExtFailure.Items.Count - 1; i++)
                        {
                            if ( ViewModel.lstExtFailure.GetItemData(i) == Convert.ToDouble(FireReport.FireSystemsFailure["sys_code"]))
                            {
                                UpgradeHelpers.Helpers.ListBoxHelper.SetSelected(ViewModel.lstExtFailure, i, true);
                                break;
                        }
                }
                FireReport.FireSystemsFailure.MoveNext();
        };
}
}
else
{
                ViewModel.optExtinguish[0].Checked = true;
            }

            if (FireReport.FlagExposure != 0)
            {
                ViewModel.ExposureOccured = -1;
                ViewModel.lbExposure1.Visible = true;
                ViewModel.lbExposure2.Visible = true;
                //cboHeatSource.Enabled = False
                ViewModel.cboGenCauseOfIgnition.Enabled = false;
                ViewModel.cboSpecCauseOfIgnition.Enabled = false;
            }
            else
            {
                ViewModel.ExposureOccured = 0;
            }


    }

        private void GetMobileData()
        {
            //Retrieve Current Mobile Property Report Data
            //Load Data into Controls
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();


            GetCommonData();

            if (~FireReport.GetFireMobileProperty(ViewModel.FireReportID) != 0)
            {
                ViewManager.ShowMessage("Error retrieving Fire Mobile Property Data ", "Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            if ( ViewModel.cboMobilePropType.SelectedIndex != -1)
            {
                if ( ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex) == IncidentMain.WATERVESSEL)
                {
                    ViewModel.lbVesselLength.Visible = true;
                    ViewModel.txtVesselLength.Visible = true;
                    ViewModel.txtVesselLength.Text = FireReport.WaterVesselLength.ToString();
                }
                else
                {
                    ViewModel.lbVesselLength.Visible = false;
                    ViewModel.txtVesselLength.Visible = false;
                }
        }
        else
        {
                ViewModel.lbVesselLength.Visible = false;
                ViewModel.txtVesselLength.Visible = false;
            }

            int FTSwitchOn = 0;
            if ( ViewModel.FirstTime == (0))
            {
                ViewModel.FirstTime = -1;
            }
            else
            {
                FTSwitchOn = -1;
            }
            for (int i = 0; i <= ViewModel.cboMobileMake.Items.Count - 1; i++)
            {
                ViewModel.cboMobileMake.SelectedIndex = i;
                if ( ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == FireReport.MobileMake)
                {
                    if (FireReport.MobileMake == "00")
                    {
                        ViewModel.txtVehicleMake.Visible = true;
                        ViewModel.lbOtherMake.Visible = true;
                        ViewModel.txtVehicleMake.Text = FireReport.VehicleMake;
                    }
                    else
                    {
                        ViewModel.txtVehicleMake.Visible = false;
                        ViewModel.lbOtherMake.Visible = false;
                    }
                    break;
            }
    }
            ViewModel.cboLicenseState.SelectedIndex = -1;
            for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
            {
                if ( ViewModel.cboState.GetListItem(i) == FireReport.LicenseState)
                {
                    ViewModel.cboState.SelectedIndex = i;
                    ViewModel.cboLicenseState.SelectedIndex = i;
                    break;
            }
    }

            if (~FTSwitchOn != 0)
            {
                ViewModel.FirstTime = 0;
            }
            ViewModel.txtVehicleModel.Text = FireReport.VehicleModel;
            ViewModel.txtVIN.Text = FireReport.VehicleVin;
            ViewModel.txtVehicleYear.Text = FireReport.VehicleYear;

            //    CheckComplete

        }

        private void GetOutsideData()
        {
            //Load all appropriate Outside Fire Data
            int CauseClass = 0;
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();


            if (~FireReport.GetFireOutside(ViewModel.FireReportID) != 0)
            {
                ViewManager.ShowMessage("Error retrieving Outside Fire Record", "Fire Report", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }

            switch (FireReport.FOIncidentType)
            {
                case 11:  //Grass/Brush/Trees 

                    ViewModel.optOSType[0].Checked = true;
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;
                    break;
            case 10:  //Dumpster 

                    ViewModel.optOSType[1].Checked = true;
                    ViewModel.lbOSMaterialInvolved.Visible = false;
                    ViewModel.cboOSMaterialInvolved.Visible = false;
                    break;
            case 13:  //Other Outside Fire 

                    ViewModel.optOSType[2].Checked = true;
                    ViewModel.lbOSMaterialInvolved.Visible = true;
                    ViewModel.cboOSMaterialInvolved.Visible = true;
                    break;
    }

    //Set Heat Source Combo
    for (int i = 0; i <= ViewModel.cboOSHeatSource.Items.Count - 1; i++)
            {
                if ( ViewModel.cboOSHeatSource.GetItemData(i) == FireReport.FOHeatSource)
                {
                    ViewModel.cboOSHeatSource.SelectedIndex = i;
                    break;
            }
    }

    //Fill Specific Cause of Ignition combo box
    FireCodes.GetCauseOfIgnitionByCode(FireReport.FOCauseOfIgnition);
    if (!FireCodes.CauseOfIgnition.EOF)
    {
            CauseClass = Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_class"]);

            while (!FireCodes.CauseOfIgnition.EOF)
            {
                    ViewModel.cboOSSpecCauseOfIgnition.AddItem(IncidentMain.Clean(FireCodes.CauseOfIgnition["description"]));
                    ViewModel.cboOSSpecCauseOfIgnition.SetItemData(ViewModel.cboOSSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_code"]));
                    FireCodes.CauseOfIgnition.MoveNext();
            };

            //Set Cause of Ignition combos
            for (int i = 0; i <= ViewModel.cboOSSpecCauseOfIgnition.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboOSSpecCauseOfIgnition.GetItemData(i) == FireReport.FOCauseOfIgnition)
                    {
                        ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex = i;
                        break;
                }
        }
        for (int i = 0; i <= ViewModel.cboOSCauseOfIgnition.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboOSCauseOfIgnition.GetItemData(i) == CauseClass)
                    {
                        ViewModel.cboOSCauseOfIgnition.SelectedIndex = i;
                        break;
                }
        }
}
            ViewModel.txtOSLoss.Text = FireReport.FOContentLoss.ToString();
            ViewModel.txtOSAreaAffected.Text = FireReport.AreaAffected.ToString();
            for (int i = 0; i <= ViewModel.cboOSAreaUnits.Items.Count - 1; i++)
            {
                if ( ViewModel.cboOSAreaUnits.GetItemData(i) == FireReport.AreaUnit)
                {
                    ViewModel.cboOSAreaUnits.SelectedIndex = i;
                    break;
            }
    }
    if ( ViewModel.optOSType[2].Checked)
            {
                for (int i = 0; i <= ViewModel.cboOSMaterialInvolved.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboOSMaterialInvolved.GetItemData(i) == FireReport.MaterialType)
                    {
                        ViewModel.cboOSMaterialInvolved.SelectedIndex = i;
                        break;
                }
        }
}

}

        private void LoadLists()
        {
            //Load all appropriate combo and listboxes for
            //Current Report Type
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
            TFDIncident.clsCommonCodes CommonCodes = Container.Resolve< clsCommonCodes>();
            string sDisplay = "";
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            //Names
            ViewModel.cboPrefix.Items.Clear();
            ViewModel.cboSuffix.Items.Clear();
            ViewModel.cboStreetType.Items.Clear();
            ViewModel.cboState.Items.Clear();
            ViewModel.cboRole.Items.Clear();
            ViewModel.cboRace.Items.Clear();
            ViewModel.txtXHouseNumber.Text = "";
            ViewModel.cboXPrefix.Items.Clear();
            ViewModel.txtXStreetName.Text = "";
            ViewModel.cboXStreetType.Items.Clear();
            ViewModel.cboXSuffix.Items.Clear();
            ViewModel.cboCityCode.Items.Clear();
            ViewModel.cboLicenseState.Items.Clear();
            ViewModel.cboMobileMake.Items.Clear();
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
                if ( ViewModel.cboState.GetListItem(i) == "WA")
                {
                    ViewModel.cboState.SelectedIndex = i;
                    break;
            }
    }
            for (int i = 0; i <= ViewModel.cboLicenseState.Items.Count - 1; i++)
            {
                if ( ViewModel.cboLicenseState.GetListItem(i) == "WA")
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

            switch ( ViewModel.ReportType)
            {
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.FIREMOBILE:
                case IncidentMain.FIREOUTSIDE:
                    //Common Lists - Structure and Mobile 
                    if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE || ViewModel.ReportType == IncidentMain.FIREMOBILE)
                    {
                        ViewModel.cboAreaOfOrigin.Items.Clear();
                        ViewModel.cboHeatSource.Items.Clear();
                        ViewModel.cboGenCauseOfIgnition.Items.Clear();
                        ViewModel.cboSpecCauseOfIgnition.Items.Clear();
                        ViewModel.cboFirstItemIgnited.Items.Clear();
                        ViewModel.lstPhysicalContribFactors.Items.Clear();
                        ViewModel.lstHumanContribFactors.Items.Clear();
                        ViewModel.lstSuppressionFactors.Items.Clear();

                        //Heat Source Code
                        FireCodes.GetHeatSourceCodes();

                        while (!FireCodes.HeatSource.EOF)
                        {
                            ViewModel.cboHeatSource.AddItem(Convert.ToString(FireCodes.HeatSource["description"]));
                            ViewModel.cboHeatSource.SetItemData(ViewModel.cboHeatSource.GetNewIndex(), Convert.ToInt32(FireCodes.HeatSource["heat_source_code"]));
                            FireCodes.HeatSource.MoveNext();
                    }
                        ;
                        FireCodes.GetCauseOfIgnitionClass();
                        //General Cause of Ignition Combo

                        while (!FireCodes.CauseOfIgnitionClassRS.EOF)
                        {
                            ViewModel.cboGenCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnitionClassRS["description"]));
                            ViewModel.cboGenCauseOfIgnition.SetItemData(ViewModel.cboGenCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnitionClassRS["cause_of_ignition_class"]));
                            FireCodes.CauseOfIgnitionClassRS.MoveNext();
                    }
                        ;
                        FireCodes.GetFirstItemIgnitedCodes();
                        //First Item Ignited combo

                        while (!FireCodes.FirstItemIgnited.EOF)
                        {
                            ViewModel.cboFirstItemIgnited.AddItem(Convert.ToString(FireCodes.FirstItemIgnited["description"]));
                            ViewModel.cboFirstItemIgnited.SetItemData(ViewModel.cboFirstItemIgnited.GetNewIndex(), Convert.ToInt32(FireCodes.FirstItemIgnited["first_item_ignited_code"]));
                            FireCodes.FirstItemIgnited.MoveNext();
                    }
                        ;
                        FireCodes.GetPhysicalFactorCodes();
                        //Physical Contributing Factors listbox

                        while (!FireCodes.PhysicalFactor.EOF)
                        {
                            ViewModel.lstPhysicalContribFactors.AddItem(Convert.ToString(FireCodes.PhysicalFactor["description"]));
                            ViewModel.lstPhysicalContribFactors.SetItemData(ViewModel.lstPhysicalContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.PhysicalFactor["physical_factor_code"]));
                            FireCodes.PhysicalFactor.MoveNext();
                    }
                        ;
                        FireCodes.GetHumanFactorCodes();
                        //Human Contributing Factors listbox

                        while (!FireCodes.HumanFactor.EOF)
                        {
                            ViewModel.lstHumanContribFactors.AddItem(Convert.ToString(FireCodes.HumanFactor["description"]));
                            ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.HumanFactor["human_factor_code"]));
                            FireCodes.HumanFactor.MoveNext();
                    }
                        ;
                        //Suppression Factors listbox
                        FireCodes.GetSuppressionFactorCodes();

                        while (!FireCodes.SuppressionFactor.EOF)
                        {
                            ViewModel.lstSuppressionFactors.AddItem(Convert.ToString(FireCodes.SuppressionFactor["description"]));
                            ViewModel.lstSuppressionFactors.SetItemData(ViewModel.lstSuppressionFactors.GetNewIndex(), Convert.ToInt32(FireCodes.SuppressionFactor["suppression_factor_code"]));
                            FireCodes.SuppressionFactor.MoveNext();
                    }
                        ;
                                            }

                                            //Structure - Building Info 
                                            if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
                    {
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
                        //General Occupancy Combo
                        FireCodes.GetPropertyUseClass();

                        while (!FireCodes.PropertyUseClassRS.EOF)
                        {
                            ViewModel.cboGeneralPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUseClassRS["class_description"]));
                            ViewModel.cboGeneralPropertyUse.SetItemData(ViewModel.cboGeneralPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
                            FireCodes.PropertyUseClassRS.MoveNext();
                    }
                        ;

                        FireCodes.GetBuildingStatusCodes();
                        //Building Status Combo

                        while (!FireCodes.BuildingStatus.EOF)
                        {
                            ViewModel.cboBuildingStatus.AddItem(Convert.ToString(FireCodes.BuildingStatus["description"]));
                            ViewModel.cboBuildingStatus.SetItemData(ViewModel.cboBuildingStatus.GetNewIndex(), Convert.ToInt32(FireCodes.BuildingStatus["building_status_code"]));
                            FireCodes.BuildingStatus.MoveNext();
                    }
                        ;
                        FireCodes.GetConstructionTypeCodes();
                        //Construction Type Combo

                        while (!FireCodes.ConstructionType.EOF)
                        {
                            ViewModel.cboConstructionType.AddItem(Convert.ToString(FireCodes.ConstructionType["description"]));
                            ViewModel.cboConstructionType.SetItemData(ViewModel.cboConstructionType.GetNewIndex(), Convert.ToInt32(FireCodes.ConstructionType["construction_type_code"]));
                            FireCodes.ConstructionType.MoveNext();
                    }
                        ;
                        //Burn Damage & Smoke Damage
                        FireCodes.GetBurnDamageCodes();

                        while (!FireCodes.BurnDamage.EOF)
                        {
                            ViewModel.cboBurnDamage.AddItem(Convert.ToString(FireCodes.BurnDamage["description"]));
                            ViewModel.cboBurnDamage.SetItemData(ViewModel.cboBurnDamage.GetNewIndex(), Convert.ToInt32(FireCodes.BurnDamage["burn_damage_code"]));
                            ViewModel.cboSmokeDamage.AddItem(Convert.ToString(FireCodes.BurnDamage["description"]));
                            ViewModel.cboSmokeDamage.SetItemData(ViewModel.cboSmokeDamage.GetNewIndex(), Convert.ToInt32(FireCodes.BurnDamage["burn_damage_code"]));
                            FireCodes.BurnDamage.MoveNext();
                    }
                        ;
                        FireCodes.GetFirstItemIgnitedCodes();
                        //Items contributing to fire spread listbox

                        while (!FireCodes.FirstItemIgnited.EOF)
                        {
                            ViewModel.lstItemContribFireSpread.AddItem(Convert.ToString(FireCodes.FirstItemIgnited["description"]));
                            ViewModel.lstItemContribFireSpread.SetItemData(ViewModel.lstItemContribFireSpread.GetNewIndex(), Convert.ToInt32(FireCodes.FirstItemIgnited["first_item_ignited_code"]));
                            FireCodes.FirstItemIgnited.MoveNext();
                    }
                        ;
                        //Equipment Involved listbox
                        FireCodes.GetEquipmentInvolvedCodes();

                        while (!FireCodes.EquipmentInvolved.EOF)
                        {
                            ViewModel.lstEquipInvolvIgnition.AddItem(Convert.ToString(FireCodes.EquipmentInvolved["description"]));
                            ViewModel.lstEquipInvolvIgnition.SetItemData(ViewModel.lstEquipInvolvIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.EquipmentInvolved["equipment_involved_code"]));
                            FireCodes.EquipmentInvolved.MoveNext();
                    }
                        ;
                                            }

                                            //Mobile Specific Property Use 
                                            if ( ViewModel.ReportType == IncidentMain.FIREMOBILE)
                    {
                        ViewModel.cboMobilePropType.Items.Clear();
                        FireCodes.GetPropertyUseByClass(7);
                        //-load Area of origin here - comment out listbox clear in getcommon sub
                        FireCodes.PropertyUse.Open();

                        while (!FireCodes.PropertyUse.EOF)
                        {
                            ViewModel.cboMobilePropType.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                            ViewModel.cboMobilePropType.SetItemData(ViewModel.cboMobilePropType.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                            FireCodes.PropertyUse.MoveNext();
                    }
                        ;
                        ViewModel.cboMobileMake.Items.Clear();
                        FireCodes.GetMobileMakeCode();

                        while (!FireCodes.MobileMakeCode.EOF)
                        {
                            ViewModel.cboMobileMake.AddItem(IncidentMain.Clean(FireCodes.MobileMakeCode["description"]) + ": " + IncidentMain.Clean(FireCodes.MobileMakeCode["mobile_make_code"]));
                            FireCodes.MobileMakeCode.MoveNext();
                    }
                        ;

                        //Hide Structure Only Controls
                        ViewModel.frmFireOnly.Visible = false;
                        ViewModel.frmFireLoss.Visible = false;

                    }

                    //Outside Fire 
                    if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE)
                    {
                        ViewModel.cboOSHeatSource.Items.Clear();
                        ViewModel.cboOSCauseOfIgnition.Items.Clear();
                        ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
                        ViewModel.cboOSAreaUnits.Items.Clear();
                        ViewModel.cboOSMaterialInvolved.Items.Clear();
                        FireCodes.GetHeatSourceCodes();
                        //Heat Source Code

                        while (!FireCodes.HeatSource.EOF)
                        {
                            ViewModel.cboOSHeatSource.AddItem(Convert.ToString(FireCodes.HeatSource["description"]));
                            ViewModel.cboOSHeatSource.SetItemData(ViewModel.cboOSHeatSource.GetNewIndex(), Convert.ToInt32(FireCodes.HeatSource["heat_source_code"]));
                            FireCodes.HeatSource.MoveNext();
                    }
                        ;

                        //General Cause of Ignition combo
                        FireCodes.GetCauseOfIgnitionClass();

                        while (!FireCodes.CauseOfIgnitionClassRS.EOF)
                        {
                            ViewModel.cboOSCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnitionClassRS["description"]));
                            ViewModel.cboOSCauseOfIgnition.SetItemData(ViewModel.cboOSCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnitionClassRS["cause_of_ignition_class"]));
                            FireCodes.CauseOfIgnitionClassRS.MoveNext();
                    }
                        ;
                        CommonCodes.GetAreaUnits();
                        //Area Units combo

                        while (!CommonCodes.AreaUnits.EOF)
                        {
                            ViewModel.cboOSAreaUnits.AddItem(Convert.ToString(CommonCodes.AreaUnits["area_description"]));
                            ViewModel.cboOSAreaUnits.SetItemData(ViewModel.cboOSAreaUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
                            CommonCodes.AreaUnits.MoveNext();
                    }
                        ;
                        FireCodes.GetMaterialTypeCodes();
                        //Material Involved combo

                        while (!FireCodes.MaterialType.EOF)
                        {
                            ViewModel.cboOSMaterialInvolved.AddItem(Convert.ToString(FireCodes.MaterialType["description"]));
                            ViewModel.cboOSMaterialInvolved.SetItemData(ViewModel.cboOSMaterialInvolved.GetNewIndex(), Convert.ToInt32(FireCodes.MaterialType["material_type_code"]));
                            FireCodes.MaterialType.MoveNext();
                    }
                        ;
                                            }

                                            //************************************************************************** 
                                            //***   Rupture / Explosion 
                                            //************************************************************************** 
                                            break;
                                        default:
                                            if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE || ViewModel.ReportType == IncidentMain.RUPTUREMOBILE)
                    {
                        ViewModel.cboAreaOfOrigin.Items.Clear();
                        ViewModel.cboHeatSource.Items.Clear();
                        ViewModel.lstPhysicalContribFactors.Items.Clear();
                        ViewModel.lstHumanContribFactors.Items.Clear();
                        ViewModel.lstSuppressionFactors.Items.Clear();

                        //Rupture/Explosion Type - Uses Heat Source Combo
                        CommonCodes.GetIncidentTypeCodeByClass(2); //Rupture/Explosion

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboHeatSource.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboHeatSource.SetItemData(ViewModel.cboHeatSource.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                    }
                        ;
                        FireCodes.GetPhysicalFactorCodes();
                        //Physical Contributing Factors listbox

                        while (!FireCodes.PhysicalFactor.EOF)
                        {
                            ViewModel.lstPhysicalContribFactors.AddItem(Convert.ToString(FireCodes.PhysicalFactor["description"]));
                            ViewModel.lstPhysicalContribFactors.SetItemData(ViewModel.lstPhysicalContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.PhysicalFactor["physical_factor_code"]));
                            FireCodes.PhysicalFactor.MoveNext();
                    }
                        ;
                        FireCodes.GetHumanFactorCodes();
                        //Human Contributing Factors listbox

                        while (!FireCodes.HumanFactor.EOF)
                        {
                            ViewModel.lstHumanContribFactors.AddItem(Convert.ToString(FireCodes.HumanFactor["description"]));
                            ViewModel.lstHumanContribFactors.SetItemData(ViewModel.lstHumanContribFactors.GetNewIndex(), Convert.ToInt32(FireCodes.HumanFactor["human_factor_code"]));
                            FireCodes.HumanFactor.MoveNext();
                    }
                        ;
                        //Suppression Factors listbox
                        FireCodes.GetSuppressionFactorCodes();

                        while (!FireCodes.SuppressionFactor.EOF)
                        {
                            ViewModel.lstSuppressionFactors.AddItem(Convert.ToString(FireCodes.SuppressionFactor["description"]));
                            ViewModel.lstSuppressionFactors.SetItemData(ViewModel.lstSuppressionFactors.GetNewIndex(), Convert.ToInt32(FireCodes.SuppressionFactor["suppression_factor_code"]));
                            FireCodes.SuppressionFactor.MoveNext();
                    }
                        ;
                                            }
                                            //Structure - Building Info 
                                            if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE)
                    {
                        ViewModel.cboGeneralPropertyUse.Items.Clear();
                        ViewModel.cboSpecificPropertyUse.Items.Clear();
                        ViewModel.cboBuildingStatus.Items.Clear();
                        ViewModel.cboConstructionType.Items.Clear();
                        //General Occupancy Combo
                        FireCodes.GetPropertyUseClass();

                        while (!FireCodes.PropertyUseClassRS.EOF)
                        {
                            ViewModel.cboGeneralPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUseClassRS["class_description"]));
                            ViewModel.cboGeneralPropertyUse.SetItemData(ViewModel.cboGeneralPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUseClassRS["property_use_class"]));
                            FireCodes.PropertyUseClassRS.MoveNext();
                    }
                        ;

                        FireCodes.GetBuildingStatusCodes();
                        //Building Status Combo

                        while (!FireCodes.BuildingStatus.EOF)
                        {
                            ViewModel.cboBuildingStatus.AddItem(Convert.ToString(FireCodes.BuildingStatus["description"]));
                            ViewModel.cboBuildingStatus.SetItemData(ViewModel.cboBuildingStatus.GetNewIndex(), Convert.ToInt32(FireCodes.BuildingStatus["building_status_code"]));
                            FireCodes.BuildingStatus.MoveNext();
                    }
                        ;
                        FireCodes.GetConstructionTypeCodes();
                        //Construction Type Combo

                        while (!FireCodes.ConstructionType.EOF)
                        {
                            ViewModel.cboConstructionType.AddItem(Convert.ToString(FireCodes.ConstructionType["description"]));
                            ViewModel.cboConstructionType.SetItemData(ViewModel.cboConstructionType.GetNewIndex(), Convert.ToInt32(FireCodes.ConstructionType["construction_type_code"]));
                            FireCodes.ConstructionType.MoveNext();
                    }
                        ;
                                            }
                                            //Mobile Specific Property Use 
                                            if ( ViewModel.ReportType == IncidentMain.RUPTUREMOBILE)
                    {
                        ViewModel.cboMobilePropType.Items.Clear();
                        FireCodes.GetPropertyUseByClass(7);
                        FireCodes.PropertyUse.Open();

                        while (!FireCodes.PropertyUse.EOF)
                        {
                            ViewModel.cboMobilePropType.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                            ViewModel.cboMobilePropType.SetItemData(ViewModel.cboMobilePropType.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                            FireCodes.PropertyUse.MoveNext();
                    }
                        ;
                        ViewModel.cboMobileMake.Items.Clear();
                        FireCodes.GetMobileMakeCode();

                        while (!FireCodes.MobileMakeCode.EOF)
                        {
                            ViewModel.cboMobileMake.AddItem(IncidentMain.Clean(FireCodes.MobileMakeCode["description"]) + ": " + IncidentMain.Clean(FireCodes.MobileMakeCode["mobile_make_code"]));
                            FireCodes.MobileMakeCode.MoveNext();
                    }
                        ;

                        //Hide Structure Only Controls
                        ViewModel.frmFireOnly.Visible = false;
                        ViewModel.frmFireLoss.Visible = false;
                    }
                    //Outside Fire 
                    if ( ViewModel.ReportType == IncidentMain.RUPTUREOUTSIDE)
                    {
                        ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
                        ViewModel.cboOSAreaUnits.Items.Clear();
                        //Rupture/Explosion Type - Uses Specific Cause of Ign Combo
                        CommonCodes.GetIncidentTypeCodeByClass(2); //Rupture/Explosion

                        while (!CommonCodes.IncidentType.EOF)
                        {
                            ViewModel.cboOSSpecCauseOfIgnition.AddItem(IncidentMain.Clean(CommonCodes.IncidentType["description"]));
                            ViewModel.cboOSSpecCauseOfIgnition.SetItemData(ViewModel.cboOSSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(CommonCodes.IncidentType["incident_type_code"]));
                            CommonCodes.IncidentType.MoveNext();
                    }
                        ;
                        CommonCodes.GetAreaUnits();
                        //Area Units combo

                        while (!CommonCodes.AreaUnits.EOF)
                        {
                            ViewModel.cboOSAreaUnits.AddItem(Convert.ToString(CommonCodes.AreaUnits["area_description"]));
                            ViewModel.cboOSAreaUnits.SetItemData(ViewModel.cboOSAreaUnits.GetNewIndex(), Convert.ToInt32(CommonCodes.AreaUnits["area_unit_code"]));
                            CommonCodes.AreaUnits.MoveNext();
                    }
                        ;
                                            }
                                            break;
                                    }

            FireCodes = null;
            CommonCodes = null;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);
        }
        private void LoadReportData()
        {
            //Obtain Basic Report Info
            //Format Tabs
            //Load applicable Lists
            //Retrieve Report Data and Load Controls
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();

            if (~ReportLog.GetReportLog(IncidentMain.Shared.gEditReportID) != 0)
            {
                ViewManager.ShowMessage("Error Retrieving Report Info", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                ViewManager.DisposeView(this);
            }
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.WaitCursor);
            ViewModel.CurrIncident = ReportLog.RLIncidentID;
            ViewModel.ReportingUnit = IncidentMain.Clean(ReportLog.ResponsibleUnit);
            ViewModel.ReportType = ReportLog.ReportType;
            switch ( ViewModel.ReportType)
            {
                case IncidentMain.FIRE:
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.FIREMOBILE:
                case IncidentMain.FIREOUTSIDE:
                    ViewModel.FireReportID = ReportLog.ReportReferenceID;
                    break;
            default:
                    ViewModel.RuptureReportID = ReportLog.ReportReferenceID;
                    break;
    }
            ViewModel.cmdSave[0].Enabled = ReportLog.ReportStatus == 3;

            switch ( ViewModel.ReportType)
            {
                case IncidentMain.FIRESTRUCTURE:  //Structure Fire 

                    ViewModel.tabFire.Items[1].Text = "";
                    ViewModel.tabFire.Items[4].Text = "";
                    if (FireReport.GetFireStructure(ViewModel.FireReportID) != 0)
                    {
                        if (FireReport.FlagExposure != 0)
                        {
                            ViewModel.ExposureOccured = -1;
                        }
                }
                    LoadLists();
                    GetStructureData();
                    ViewModel.tabFire.SelectedIndex = 0;
                    IncidentMain.Shared.gHelpScreen = 1;

                    break;
            case IncidentMain.FIREMOBILE:  //Mobile Property Fire 

                    ViewModel.tabFire.Items[0].Text = "";
                    ViewModel.tabFire.Items[4].Text = "";

                    LoadLists();
                    GetMobileData();
                    ViewModel.tabFire.SelectedIndex = 1;
                    IncidentMain.Shared.gHelpScreen = 2;

                    break;
            case IncidentMain.FIREOUTSIDE:  //Outside Fire 

                    ViewModel.tabFire.Items[0].Text = "";
                    ViewModel.tabFire.Items[1].Text = "";
                    ViewModel.tabFire.Items[2].Text = "";
                    ViewModel.tabFire.Items[3].Text = "";

                    LoadLists();
                    GetOutsideData();
                    ViewModel.tabFire.SelectedIndex = 4;
                    IncidentMain.Shared.gHelpScreen = 5;

                    break;
            case IncidentMain.RUPTURESTRUCTURE:
                    ViewModel.tabFire.Items[1].Text = "";
                    ViewModel.tabFire.Items[4].Text = "";
                    ViewModel.tabFire.Items[2].Text = "Rupture Info";

                    FlipToRupture();
                    LoadLists();
                    GetRuptureData();
                    ViewModel.tabFire.SelectedIndex = 0;
                    IncidentMain.Shared.gHelpScreen = 1;

                    break;
            case IncidentMain.RUPTUREMOBILE:
                    ViewModel.tabFire.Items[0].Text = "";
                    ViewModel.tabFire.Items[4].Text = "";

                    FlipToRupture();
                    LoadLists();
                    GetRuptureData();
                    ViewModel.tabFire.SelectedIndex = 1;
                    IncidentMain.Shared.gHelpScreen = 2;

                    break;
            case IncidentMain.RUPTUREOUTSIDE:
                    ViewModel.tabFire.Items[0].Text = "";
                    ViewModel.tabFire.Items[1].Text = "";
                    ViewModel.tabFire.Items[2].Text = "";
                    ViewModel.tabFire.Items[3].Text = "";
                    ViewModel.tabFire.Items[4].Text = "Outside Rupture";

                    FlipToRupture();
                    LoadLists();
                    GetRuptureOutsideData();
                    ViewModel.tabFire.SelectedIndex = 4;
                    IncidentMain.Shared.gHelpScreen = 5;

                    break;
            default:
                    ViewManager.ShowMessage("No Saved Report Found - Please Use Entry System to Create Report", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    IncidentMain.Shared.gHelpScreen = 0;
                    break;
    }

            LoadNarration(0);
            LoadNames(0);
            if (FireReport.GetFireExposureAddress(ViewModel.FireReportID) != 0)
            {
                ViewModel.ADDRESSCORRECTION = -1;
                ViewModel.FirstTime = -1;
                ViewModel.txtXHouseNumber.Text = FireReport.ExpHouseNumber;
                if (FireReport.ExpPrefix != "")
                {
                    for (int i = 0; i <= ViewModel.cboXPrefix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXPrefix.GetListItem(i) == FireReport.ExpPrefix)
                        {
                            ViewModel.cboXPrefix.SelectedIndex = i;
                            break;
                    }
            }
    }
                ViewModel.txtXStreetName.Text = FireReport.ExpStreet;

                if (FireReport.ExpStreetType != "")
                {
                    for (int i = 0; i <= ViewModel.cboXStreetType.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXStreetType.GetListItem(i) == FireReport.ExpStreetType)
                        {
                            ViewModel.cboXStreetType.SelectedIndex = i;
                            break;
                    }
            }
    }
                if (FireReport.ExpSuffix != "")
                {
                    for (int i = 0; i <= ViewModel.cboXSuffix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboXSuffix.GetListItem(i) == FireReport.ExpSuffix)
                        {
                            ViewModel.cboXSuffix.SelectedIndex = i;
                            break;
                    }
            }
    }
                for (int i = 0; i <= ViewModel.cboCityCode.Items.Count - 1; i++)
                {
                    if ( ViewModel.cboCityCode.GetListItem(i).StartsWith(FireReport.ExpCityCode))
                    {
                        ViewModel.cboCityCode.SelectedIndex = i;
                        break;
                }
        }
                ViewModel.AddressUpdated = 0;
                ViewModel.FirstTime = 0;
            }
            else
            {
                ViewModel.ADDRESSCORRECTION = 0;
                ViewModel.AddressUpdated = 0;
            }


            //Display Current Incident Basic Info
            IncidentCL.GetIncident(ViewModel.CurrIncident);
            ViewModel.lbIncident.Text = IncidentCL.IncidentNumber;
            ViewModel.lbLocation.Text = IncidentCL.Location;
            //WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.Cursor was not upgraded
            this.Set_Cursor(UpgradeHelpers.Helpers.Cursors.Arrow);

        }

        private int SaveFireRecord(int UpdateType)
        {
            //If Exit without Saving then get out

            int result = 0;
            if (UpdateType == IncidentMain.NOREPORT)
            {
                return -1;
            }
            TFDIncident.clsFire FireReport = Container.Resolve< clsFire>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

            result = -1;

            //Save Changes
            if ( ViewModel.ReportType == IncidentMain.FIREOUTSIDE)
            {
                //Refresh existing report data
                FireReport.GetFireOutside(ViewModel.FireReportID);
                if ( ViewModel.optOSType[0].Checked)
                {
                    FireReport.FOIncidentType = 11;
                    FireReport.MaterialType = 1;
                }
                else if ( ViewModel.optOSType[1].Checked)
                {
                    FireReport.FOIncidentType = 10;
                    FireReport.MaterialType = 2;
                }
                else
                {
                    FireReport.FOIncidentType = 13;
                    if ( ViewModel.cboOSMaterialInvolved.SelectedIndex != -1)
                    {
                        FireReport.MaterialType = ViewModel.cboOSMaterialInvolved.GetItemData(ViewModel.cboOSMaterialInvolved.SelectedIndex);
                    }
                    else
                    {
                        FireReport.MaterialType = 0;
                    }
            }
            if ( ViewModel.cboOSHeatSource.SelectedIndex != -1)
                {
                    FireReport.FOHeatSource = ViewModel.cboOSHeatSource.GetItemData(ViewModel.cboOSHeatSource.SelectedIndex);
                }
                else
                {
                    FireReport.FOHeatSource = 0;
                }
                if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    FireReport.FOCauseOfIgnition = ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    FireReport.FOCauseOfIgnition = 0;
                }

                double dbNumericTemp = 0;
                if (!Double.TryParse(ViewModel.txtOSLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    FireReport.FOContentLoss = 0;
                }
                else
                {
                    FireReport.FOContentLoss = Double.Parse(ViewModel.txtOSLoss.Text);
                }
                double dbNumericTemp2 = 0;
                if (!Double.TryParse(ViewModel.txtOSAreaAffected.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                {
                    FireReport.AreaAffected = 0;
                }
                else
                {
                    FireReport.AreaAffected = Convert.ToInt32(Double.Parse(ViewModel.txtOSAreaAffected.Text));
                }
                if ( ViewModel.cboOSAreaUnits.SelectedIndex != -1)
                {
                    FireReport.AreaUnit = ViewModel.cboOSAreaUnits.GetItemData(ViewModel.cboOSAreaUnits.SelectedIndex);
                }
                else
                {
                    FireReport.AreaUnit = 0;
                }
                if (FireReport.UpdateFireOutside() != 0)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                }
        }
        else
        {
                //FireStructure or FireMobileProperty - Save FireReport first
                FireReport.GetFireReport(ViewModel.FireReportID);
                if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
                {
                    if ( ViewModel.cboSpecificPropertyUse.SelectedIndex != -1)
                    {
                        FireReport.PropertyUse = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
                    }
                    else
                    {
                        FireReport.PropertyUse = 0;
                    }
                    FireReport.PropertyValue = Conversion.Val(ViewModel.txtPropValue.Text);
                }
                else
                {
                    if ( ViewModel.cboMobilePropType.SelectedIndex != -1)
                    {
                        FireReport.PropertyUse = ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex);
                    }
                    else
                    {
                        FireReport.PropertyUse = 0;
                    }
                    FireReport.PropertyValue = Conversion.Val(ViewModel.txtMobilePropValue.Text);
                }
                if ( ViewModel.cboAreaOfOrigin.SelectedIndex != -1)
                {
                    FireReport.AreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
                }
                else
                {
                    FireReport.AreaOfOrigin = 0;
                }
                if ( ViewModel.cboHeatSource.SelectedIndex != -1)
                {
                    FireReport.HeatSource = ViewModel.cboHeatSource.GetItemData(ViewModel.cboHeatSource.SelectedIndex);
                }
                else
                {
                    FireReport.HeatSource = 0;
                }
                if ( ViewModel.cboFirstItemIgnited.SelectedIndex != -1)
                {
                    FireReport.FirstItemIgnited = ViewModel.cboFirstItemIgnited.GetItemData(ViewModel.cboFirstItemIgnited.SelectedIndex);
                }
                else
                {
                    FireReport.FirstItemIgnited = 0;
                }
                if ( ViewModel.cboSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    FireReport.CauseOfIgnition = ViewModel.cboSpecCauseOfIgnition.GetItemData(ViewModel.cboSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    FireReport.CauseOfIgnition = 0;
                }
                double dbNumericTemp3 = 0;
                if (!Double.TryParse(ViewModel.txtPropLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                {
                    FireReport.PropertyLoss = 0;
                }
                else
                {
                    FireReport.PropertyLoss = Double.Parse(ViewModel.txtPropLoss.Text);
                }
                double dbNumericTemp4 = 0;
                if (!Double.TryParse(ViewModel.txtContentLoss.Text, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4))
                {
                    FireReport.ContentLoss = 0;
                }
                else
                {
                    FireReport.ContentLoss = Double.Parse(ViewModel.txtContentLoss.Text);
                }
                if (FireReport.UpdateFireReport() != 0)
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
                                //Save Physical, Human and Suppression Factors
                                FireReport.DeleteFireHumanContributingFactor(ref p1);
                        ViewModel.FireReportID = p1;
                        return ret;
                    }, ViewModel.FireReportID);
                FireReport.HFFireReportID = ViewModel.FireReportID;
                FireReport.HFAge = 0;
                FireReport.HFGender = 0;
                for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                {
                    if ( ViewModel.lstHumanContribFactors.GetSelected( i))
                    {
                        FireReport.HumanFactor = ViewModel.lstHumanContribFactors.GetItemData(i);
                        FireReport.HFAge = Convert.ToInt32(Conversion.Val(ViewModel.txtHFAge.Text));
                        if (FireReport.HFAge != 0)
                        {
                            if ( ViewModel.optHFGender[0].Checked)
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
                    if ( ViewModel.lstPhysicalContribFactors.GetSelected( i))
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
                    if ( ViewModel.lstSuppressionFactors.GetSelected( i))
                    {
                        FireReport.SuppressionFactor = ViewModel.lstSuppressionFactors.GetItemData(i);
                        FireReport.AddFireSuppressionFactor();
                }
        }
        //Save Fire Mobile Report
        if ( ViewModel.ReportType == IncidentMain.FIREMOBILE)
                {
                    //Refresh FireMobile Private Class Variables
                    FireReport.GetFireMobileProperty(ViewModel.FireReportID);
                    FireReport.VehicleModel = IncidentMain.Clean(ViewModel.txtVehicleModel.Text);
                    FireReport.VehicleVin = IncidentMain.Clean(ViewModel.txtVIN.Text);
                    FireReport.VehicleYear = IncidentMain.Clean(ViewModel.txtVehicleYear.Text);
                    FireReport.WaterVesselLength = Convert.ToInt32(Conversion.Val(ViewModel.txtVesselLength.Text));
                    if ( ViewModel.cboMobileMake.SelectedIndex != -1)
                    {
                        FireReport.MobileMake = ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0));
                        if (FireReport.MobileMake == "00")
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
                        FireReport.MobileMake = "00";
                        FireReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                    }
                    if ( ViewModel.cboLicenseState.SelectedIndex != -1)
                    {
                        FireReport.LicenseState = ViewModel.cboLicenseState.Text;
                    }
                    else
                    {
                        FireReport.LicenseState = "WA";
                    }

                    if (FireReport.UpdateFireMobileProperty() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
            }
            else
            {
                    //Save Fire Structure Report
                    //Refresh FireStructure Report
                    FireReport.GetFireStructure(ViewModel.FireReportID);
                    if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 1;
                    }
                    else if ( ViewModel.optFloor[1].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 2;
                    }
                    else if ( ViewModel.optFloor[2].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        FireReport.SpecialFloor = 3;
                    }
                    else
                    {
                        FireReport.SpecialFloor = 4;
                    }
                    FireReport.FloorOfOrigin = Convert.ToInt32(Conversion.Val(ViewModel.txtFloorOfOrigin.Text));
                    if ( ViewModel.cboBuildingStatus.SelectedIndex != -1)
                    {
                        FireReport.BuildingStatus = ViewModel.cboBuildingStatus.GetItemData(ViewModel.cboBuildingStatus.SelectedIndex);
                    }
                    else
                    {
                        FireReport.BuildingStatus = 0;
                    }
                    if ( ViewModel.cboBurnDamage.SelectedIndex != -1)
                    {
                        FireReport.BurnDamage = ViewModel.cboBurnDamage.GetItemData(ViewModel.cboBurnDamage.SelectedIndex);
                    }
                    else
                    {
                        FireReport.BurnDamage = 0;
                    }
                    if ( ViewModel.cboSmokeDamage.SelectedIndex != -1)
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
                                    FireReport.DeleteFireSystemsFailure(ref p1);
                            ViewModel.FireReportID = p1;
                            return ret;
                        }, ViewModel.FireReportID);
                    if ( ViewModel.optAlarmType[0].Checked)
                    { //No Alarm Involved
                        FireReport.FlagNoAlarm = 1;
                        FireReport.FireAlarmType = 0;
                        FireReport.DetectorPower = 0;
                        FireReport.InitiatingDevice = 0;
                        FireReport.AlarmEffectiveness = 0;
                        FireReport.FlagAlarmOperation = 0;
                        //delete all alarm problems
                    }
                    else if ( ViewModel.optAlarmType[1].Checked)
                    {  //Detector Units Only
                        FireReport.FlagNoAlarm = 0;
                        FireReport.FireAlarmType = 1;
                        if ( ViewModel.cboAlarmType.SelectedIndex != -1)
                        {
                            FireReport.DetectorPower = ViewModel.cboAlarmType.GetItemData(ViewModel.cboAlarmType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.DetectorPower = 0;
                        }
                        FireReport.InitiatingDevice = 0;
                        if ( ViewModel.cboEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.AlarmEffectiveness = ViewModel.cboEffectiveness.GetItemData(ViewModel.cboEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.AlarmEffectiveness = 0;
                        }
                        FireReport.FlagAlarmOperation = (byte)ViewModel.chkAlarmOperation.CheckState;
                        //delete all alarm problems
                    }
                    else
                    {
                        // Alarm System
                        FireReport.FlagNoAlarm = 0;
                        if ( ViewModel.cboAlarmType.SelectedIndex != -1)
                        {
                            FireReport.FireAlarmType = ViewModel.cboAlarmType.GetItemData(ViewModel.cboAlarmType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.FireAlarmType = 0;
                        }
                        FireReport.DetectorPower = 0;
                        if ( ViewModel.cboInitiatingDevice.SelectedIndex != -1)
                        {
                            FireReport.InitiatingDevice = ViewModel.cboInitiatingDevice.GetItemData(ViewModel.cboInitiatingDevice.SelectedIndex);
                        }
                        else
                        {
                            FireReport.InitiatingDevice = 0;
                        }
                        if ( ViewModel.cboEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.AlarmEffectiveness = ViewModel.cboEffectiveness.GetItemData(ViewModel.cboEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.AlarmEffectiveness = 0;
                        }
                        FireReport.FlagAlarmOperation = (byte)ViewModel.chkAlarmOperation.CheckState;
                        //save all alarm problems
                        FireReport.FSysFireReportID = ViewModel.FireReportID;
                        for (int i = 0; i <= ViewModel.lstAlarmFailure.Items.Count - 1; i++)
                        {
                            if ( ViewModel.lstAlarmFailure.GetSelected( i))
                            {
                                FireReport.SystemFailure = ViewModel.lstAlarmFailure.GetItemData(i);
                                FireReport.AddFireSystemsFailure();
                        }
                }
        }
        if ( ViewModel.optExtinguish[0].Checked)
                    { //No Extinguishing System
                        FireReport.FlagNoExtinguishSystem = 1;
                        FireReport.ExtinguishType = 0;
                        FireReport.ExtinguishEffectiveness = 0;
                        FireReport.FlagExtinguishOperation = 0;
                        //delete all Ext - system failure records
                    }
                    else
                    {
                        //Extinguishing System
                        FireReport.FlagNoExtinguishSystem = 0;
                        if ( ViewModel.cboSysType.SelectedIndex != -1)
                        {
                            FireReport.ExtinguishType = ViewModel.cboSysType.GetItemData(ViewModel.cboSysType.SelectedIndex);
                        }
                        else
                        {
                            FireReport.ExtinguishType = 0;
                        }
                        if ( ViewModel.cboExtEffectiveness.SelectedIndex != -1)
                        {
                            FireReport.ExtinguishEffectiveness = ViewModel.cboExtEffectiveness.GetItemData(ViewModel.cboExtEffectiveness.SelectedIndex);
                        }
                        else
                        {
                            FireReport.ExtinguishEffectiveness = 0;
                        }
                        FireReport.FlagExtinguishOperation = (byte)ViewModel.chkExtOperation.CheckState;
                        FireReport.FSysFireReportID = ViewModel.FireReportID;
                        for (int i = 0; i <= ViewModel.lstExtFailure.Items.Count - 1; i++)
                        {
                            if ( ViewModel.lstExtFailure.GetSelected( i))
                            {
                                FireReport.SystemFailure = ViewModel.lstExtFailure.GetItemData(i);
                                FireReport.AddFireSystemsFailure();
                        }
                }
        }
        FireReport.NumberOfStories = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfStories.Text));
                    FireReport.BasementLevels = Convert.ToInt32(Conversion.Val(ViewModel.txtBasementLevels.Text));
                    if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        FireReport.ConstructionType = ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex);
                    }
                    else
                    {
                        FireReport.ConstructionType = 0;
                    }
                    FireReport.TotalSqFootage = Convert.ToInt32(Conversion.Val(ViewModel.txtTotalSqFootage.Text));
                    FireReport.PeopleOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfOccupants.Text));
                    FireReport.BusinessesOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfBusinesses.Text));
                    FireReport.SqFootBurned = Convert.ToInt32(Conversion.Val(ViewModel.txtSqFtBurned.Text));
                    FireReport.SqFootSmokeDamaged = Convert.ToInt32(Conversion.Val(ViewModel.txtSqFtSmokeDamage.Text));
                    FireReport.PeopleDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoPeopleDisplaced.Text));
                    FireReport.BusinessesDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoBusinessDisplaced.Text));
                    FireReport.JobsLost = Convert.ToInt32(Conversion.Val(ViewModel.txtJobsLost.Text));
                    FireReport.NumberOfUnits = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfUnits.Text));
                    FireReport.FlagRental = (byte)ViewModel.chkRental.CheckState;
                    if ( ViewModel.ExposureOccured != 0)
                    {
                        FireReport.FlagExposure = 1;
                    }
                    else
                    {
                        FireReport.FlagExposure = 0;
                    }
                    if (FireReport.UpdateFireStructure() != 0)
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
                                    //save Equip Involved and Items Contributing
                                    FireReport.DeleteFireEquipmentInvolved(ref p1);
                            ViewModel.FireReportID = p1;
                            return ret;
                        }, ViewModel.FireReportID);
                    FireReport.FEFireReportID = ViewModel.FireReportID;
                    for (int i = 0; i <= ViewModel.lstEquipInvolvIgnition.Items.Count - 1; i++)
                    {
                        if ( ViewModel.lstEquipInvolvIgnition.GetSelected( i))
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
                        if ( ViewModel.lstItemContribFireSpread.GetSelected( i))
                        {
                            FireReport.ItemContributing = ViewModel.lstItemContribFireSpread.GetItemData(i);
                            FireReport.AddFireItemContributingFireSpread();
                    }
            }
    }
}
//Names
if ( ViewModel.NameUpdated != 0)
            {
                SaveName();
            }
            if ( ViewModel.NarrationUpdated != 0)
            {
                SaveNarration();
            }

            //SaveExposureAddress
            if ( ViewModel.AddressUpdated != 0)
            {
                FireReport.FExpFireReportID = ViewModel.FireReportID;
                FireReport.ExpHouseNumber = IncidentMain.Clean(ViewModel.txtXHouseNumber.Text);
                if ( ViewModel.cboXPrefix.SelectedIndex != -1)
                {
                    FireReport.ExpPrefix = ViewModel.cboXPrefix.Text;
                }
                else
                {
                    FireReport.ExpPrefix = "";
                }

                FireReport.ExpStreet = IncidentMain.Clean(ViewModel.txtXStreetName.Text);
                if ( ViewModel.cboXStreetType.SelectedIndex != -1)
                {
                    FireReport.ExpStreetType = ViewModel.cboXStreetType.Text;
                }
                else
                {
                    FireReport.ExpStreetType = "";
                }
                if ( ViewModel.cboXSuffix.SelectedIndex != -1)
                {
                    FireReport.ExpSuffix = ViewModel.cboXSuffix.Text;
                }
                else
                {
                    FireReport.ExpSuffix = "";
                }
                if ( ViewModel.cboCityCode.SelectedIndex == -1)
                {
                    FireReport.ExpCityCode = "";
                }
                else
                {
                    FireReport.ExpCityCode = ViewModel.cboCityCode.Text.Substring(0, Math.Min(3, ViewModel.cboCityCode.Text.Length));
                }
                if (~ViewModel.ADDRESSCORRECTION != 0)
                {
                    if (~FireReport.AddFireExposureAddress() != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Add Address Correction", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
            }
            else
            {
                    if (~FireReport.UpdateFireExposureAddress() != 0)
                    {
                        ViewManager.ShowMessage("Error Attempting to Update Address Correction", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
            }
    }

    //Update ReportLog
    if (result != 0)
    {
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                ReportLog.UpdateStatus(ref p1, ViewModel.FireReportID, UpdateType);
                        IncidentMain.Shared.gEditReportID = p1;
                        return ret;
                    }, IncidentMain.Shared.gEditReportID);
                ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident);
        }


        return result;
}

        private int SaveRuptureRecord(int UpdateType)
        {
            //If Exit without Saving then get out

            int result = 0;
            if (UpdateType == IncidentMain.NOREPORT)
            {
                return -1;
            }
            TFDIncident.clsRupture RuptureReport = Container.Resolve< clsRupture>();
            TFDIncident.clsReportLog ReportLog = Container.Resolve< clsReportLog>();

            result = -1;

            //Save Changes
            if ( ViewModel.ReportType == IncidentMain.RUPTUREOUTSIDE)
            {
                //Refresh existing report data
                RuptureReport.GetRuptureOutside(ViewModel.RuptureReportID);
                if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex != -1)
                {
                    RuptureReport.ROIncidentType = ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex);
                }
                else
                {
                    RuptureReport.ROIncidentType = 0;
                }

                RuptureReport.ROContentLoss = Convert.ToInt32(Conversion.Val(ViewModel.txtOSLoss.Text));
                RuptureReport.ROAreaAffected = Convert.ToInt32(Conversion.Val(ViewModel.txtOSAreaAffected.Text));
                if ( ViewModel.cboOSAreaUnits.SelectedIndex != -1)
                {
                    RuptureReport.ROAreaUnit = ViewModel.cboOSAreaUnits.GetItemData(ViewModel.cboOSAreaUnits.SelectedIndex);
                }
                else
                {
                    RuptureReport.ROAreaUnit = 0;
                }
                if (RuptureReport.UpdateRuptureOutside() != 0)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                }
        }
        else
        {
                //RuptureStructure or RuptureMobileProperty - Save RuptureExplosion Record first
                RuptureReport.GetRupture(ViewModel.RuptureReportID);
                if ( ViewModel.ReportType == IncidentMain.RUPTURESTRUCTURE)
                {
                    if ( ViewModel.cboSpecificPropertyUse.SelectedIndex != -1)
                    {
                        RuptureReport.RupturePropertyUseCode = ViewModel.cboSpecificPropertyUse.GetItemData(ViewModel.cboSpecificPropertyUse.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.RupturePropertyUseCode = 0;
                    }
                    RuptureReport.RupturePropertyValue = Convert.ToInt32(Conversion.Val(ViewModel.txtPropValue.Text));
                }
                else
                {
                    if ( ViewModel.cboMobilePropType.SelectedIndex != -1)
                    {
                        RuptureReport.RupturePropertyUseCode = ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.RupturePropertyUseCode = 0;
                    }
                    RuptureReport.RupturePropertyValue = Convert.ToInt32(Conversion.Val(ViewModel.txtMobilePropValue.Text));
                }
                if ( ViewModel.cboAreaOfOrigin.SelectedIndex != -1)
                {
                    RuptureReport.RuptureAreaOfOrigin = ViewModel.cboAreaOfOrigin.GetItemData(ViewModel.cboAreaOfOrigin.SelectedIndex);
                }
                else
                {
                    RuptureReport.RuptureAreaOfOrigin = 0;
                }
                if ( ViewModel.cboHeatSource.SelectedIndex != -1)
                { //** Rupture Incident Type
                    RuptureReport.RuptureIncidentType = ViewModel.cboHeatSource.GetItemData(ViewModel.cboHeatSource.SelectedIndex);
                }
                else
                {
                    RuptureReport.RuptureIncidentType = 0;
                }
                RuptureReport.RupturePropertyLoss = Convert.ToInt32(Conversion.Val(ViewModel.txtPropLoss.Text));
                RuptureReport.RuptureContentLoss = Convert.ToInt32(Conversion.Val(ViewModel.txtContentLoss.Text));
                if (RuptureReport.UpdateRupture() != 0)
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
                                //Save Physical, Human and Suppression Factors
                                RuptureReport.DeleteRuptureHumanContributingFactor(ref p1);
                        ViewModel.RuptureReportID = p1;
                        return ret;
                    }, ViewModel.RuptureReportID);
                RuptureReport.RHCRuptureID = ViewModel.RuptureReportID;
                for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                {
                    if ( ViewModel.lstHumanContribFactors.GetSelected( i))
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
                    if ( ViewModel.lstPhysicalContribFactors.GetSelected( i))
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
                    if ( ViewModel.lstSuppressionFactors.GetSelected( i))
                    {
                        RuptureReport.RSuppressionFactor = ViewModel.lstSuppressionFactors.GetItemData(i);
                        RuptureReport.AddRuptureSuppressionFactor();
                }
        }
        //Save Fire Mobile Report
        if ( ViewModel.ReportType == IncidentMain.RUPTUREMOBILE)
                {
                    //Refresh RuptureMobile Private Class Variables
                    RuptureReport.GetRuptureMobileProperty(ViewModel.RuptureReportID);
                    RuptureReport.VehicleModel = IncidentMain.Clean(ViewModel.txtVehicleModel.Text);
                    RuptureReport.VehicleVin = IncidentMain.Clean(ViewModel.txtVIN.Text);
                    RuptureReport.VehicleYear = IncidentMain.Clean(ViewModel.txtVehicleYear.Text);
                    RuptureReport.WaterVesseLength = Convert.ToInt32(Conversion.Val(ViewModel.txtVesselLength.Text));
                    if ( ViewModel.cboMobileMake.SelectedIndex != -1)
                    {
                        RuptureReport.MobileMake = ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0));
                        if (RuptureReport.MobileMake == "00")
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
                        RuptureReport.MobileMake = "00";
                        RuptureReport.VehicleMake = IncidentMain.Clean(ViewModel.txtVehicleMake.Text);
                    }
                    if ( ViewModel.cboLicenseState.SelectedIndex != -1)
                    {
                        RuptureReport.LicenseState = ViewModel.cboLicenseState.Text;
                    }
                    else
                    {
                        RuptureReport.LicenseState = "WA";
                    }
                    if (RuptureReport.UpdateRuptureMobile() != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
            }
            else
            {
                    //Save Rupture Structure Report
                    //Refresh RuptureStructure Report
                    RuptureReport.GetRuptureStructure(ViewModel.RuptureReportID);
                    if ( ViewModel.optFloor[0].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 1;
                    }
                    else if ( ViewModel.optFloor[1].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 2;
                    }
                    else if ( ViewModel.optFloor[2].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
                    {
                        RuptureReport.SpecialFloor = 3;
                    }
                    else
                    {
                        RuptureReport.SpecialFloor = 4;
                    }
                    RuptureReport.FloorOfOrigin = Convert.ToInt32(Conversion.Val(ViewModel.txtFloorOfOrigin.Text));
                    if ( ViewModel.cboBuildingStatus.SelectedIndex != -1)
                    {
                        RuptureReport.BuildingStatus = ViewModel.cboBuildingStatus.GetItemData(ViewModel.cboBuildingStatus.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.BuildingStatus = 0;
                    }
                    RuptureReport.NumberOfStories = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfStories.Text));
                    RuptureReport.BasementLevels = Convert.ToInt32(Conversion.Val(ViewModel.txtBasementLevels.Text));
                    if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        RuptureReport.ConstructionType = ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex);
                    }
                    else
                    {
                        RuptureReport.ConstructionType = 0;
                    }
                    RuptureReport.TotalSqFootage = Convert.ToInt32(Conversion.Val(ViewModel.txtTotalSqFootage.Text));
                    RuptureReport.NumberPeopleOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfOccupants.Text));
                    RuptureReport.NumberBusinessOccuping = Convert.ToInt32(Conversion.Val(ViewModel.txtNumberOfBusinesses.Text));
                    RuptureReport.SqFootDamaged = Convert.ToInt32(Conversion.Val(ViewModel.txtSqFtSmokeDamage.Text));
                    RuptureReport.PeopleDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoPeopleDisplaced.Text));
                    RuptureReport.BusinessesDisplaced = Convert.ToInt32(Conversion.Val(ViewModel.txtNoBusinessDisplaced.Text));
                    RuptureReport.JobsLost = Convert.ToInt32(Conversion.Val(ViewModel.txtJobsLost.Text));
                    if (RuptureReport.UpdateRuptureStructure() != 0)
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
    if ( ViewModel.NameUpdated != 0)
            {
                SaveName();
            }
            if ( ViewModel.NarrationUpdated != 0)
            {
                SaveNarration();
            }

            //Update ReportLog
            if (result != 0)
            {
                UpgradeHelpers.Helpers.ByRefUtils.WithReturn<System.Int32, System.Int32>((p1) =>
                    {
                        var ret =
                                ReportLog.UpdateStatus(ref p1, ViewModel.RuptureReportID, UpdateType);
                        IncidentMain.Shared.gEditReportID = p1;
                        return ret;
                    }, IncidentMain.Shared.gEditReportID);
                ReportLog.UpdateNFIRSLog(ViewModel.CurrIncident);
        }

        return result;
}

        [UpgradeHelpers.Events.Handler]
        internal void cboAlarmType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAlarmType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboAlarmType.SelectedIndex == -1)
            {
                ViewModel.cboAlarmType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboAreaOfOrigin_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboAreaOfOrigin_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboAreaOfOrigin.SelectedIndex == -1)
            {
                ViewModel.cboAreaOfOrigin.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboBuildingStatus_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBuildingStatus_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboBuildingStatus.SelectedIndex == -1)
            {
                ViewModel.cboBuildingStatus.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboBurnDamage_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboBurnDamage_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboBurnDamage.SelectedIndex == -1)
            {
                ViewModel.cboBurnDamage.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboCityCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckComplete();
            ViewModel.AddressUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboCityCode_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboCityCode.SelectedIndex == -1)
            {
                ViewModel.cboCityCode.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboConstructionType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                if ( ViewModel.cboConstructionType.SelectedIndex == -1)
                {
                    this.Return();
                    return ;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                //Test For Property Value Calculation
                if ( ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if ( ViewModel.txtTotalSqFootage.Text != "")
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if ( ViewModel.txtPropValue.Text == "" || Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) == 0)
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
        internal void cboConstructionType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboConstructionType.SelectedIndex == -1)
            {
                ViewModel.cboConstructionType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboEffectiveness_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboEffectiveness_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboEffectiveness.SelectedIndex == -1)
            {
                ViewModel.cboEffectiveness.Text = "";
            }
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
        internal void cboFirstItemIgnited_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboFirstItemIgnited.SelectedIndex == -1)
            {
                ViewModel.cboFirstItemIgnited.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboGenCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Reset Specific Cause of Ignition
            //Check to make sure that a change has been made
            int CauseType = 0;
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

            if ( ViewModel.FirstTime != 0)
            {
                return;
            } // Don't run for Field Initialization

            if ( ViewModel.cboGenCauseOfIgnition.SelectedIndex == -1)
            { //No Gen Prop Selected

                ViewModel.cboSpecCauseOfIgnition.Items.Clear();
                ViewManager.ShowMessage("Specific Cause of Fire Has Been Cleared" + "\n" + "Select General Cause of Fire to Reload Values", "Fire Report Edit", UpgradeHelpers.Helpers.BoxButtons.OK);
                return;
        }
        else
        {
                CauseType = ViewModel.cboGenCauseOfIgnition.GetItemData(ViewModel.cboGenCauseOfIgnition.SelectedIndex);
            }

            //Check to determine if General Prop Changed
            if ( ViewModel.cboSpecCauseOfIgnition.SelectedIndex > -1)
            {
                FireCodes.GetCauseOfIgnitionByCode(ViewModel.cboSpecCauseOfIgnition.GetItemData(ViewModel.cboSpecCauseOfIgnition.SelectedIndex));
                if (Convert.ToDouble(FireCodes.CauseOfIgnition["cause_of_ignition_class"]) == CauseType)
                {
                    return;
                }
        }
            ViewModel.cboSpecCauseOfIgnition.Items.Clear();
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


        CheckComplete();

}

        [UpgradeHelpers.Events.Handler]
        internal void cboGenCauseOfIgnition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboGenCauseOfIgnition.SelectedIndex == -1)
            {
                ViewModel.cboGenCauseOfIgnition.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboGeneralPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                //General Property Use has been changed
                //Reload Specific Property Use and Area of Origin
                //Notify User that this data has been changed
                int GenType = 0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

                if ( ViewModel.FirstTime != 0)
                {
                    this.Return();
                    return ;
                } // Don't run for Field Initialization

                if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
                { //No Gen Prop Selected

                    ViewModel.cboSpecificPropertyUse.Items.Clear();
                    ViewModel.cboAreaOfOrigin.Items.Clear();
                    ViewManager.ShowMessage("Specific Property Use & Area of Origin Have Been Cleared" + "\n" + "Select General Property to Reload Values",
                        "Fire Report Edit", UpgradeHelpers.Helpers.BoxButtons.OK);
                    this.Return();
                    return ;
                }
                else
                {
                    GenType = ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse.SelectedIndex);
                }

                //Check to determine if General Prop Changed
                //    If cboSpecificPropertyUse.ListIndex > -1 Then
                //        FireCodes.GetCauseOfIgnitionByCode cboSpecificPropertyUse.ItemData(cboSpecificPropertyUse.ListIndex)
                //        If FireCodes.CauseOfIgnition("cause_of_ignition_class") = GenType Then Exit Sub  'No Changes
                //    End If
                ViewModel.cboSpecificPropertyUse.Items.Clear();
                ViewModel.cboAreaOfOrigin.Items.Clear();
                FireCodes.GetPropertyUseByClass(GenType);
                FireCodes.PropertyUse.Open();

                while (!FireCodes.PropertyUse.EOF)
                {
                    ViewModel.cboSpecificPropertyUse.AddItem(Convert.ToString(FireCodes.PropertyUse["description"]));
                    ViewModel.cboSpecificPropertyUse.SetItemData(ViewModel.cboSpecificPropertyUse.GetNewIndex(), Convert.ToInt32(FireCodes.PropertyUse["property_use_code"]));
                    FireCodes.PropertyUse.MoveNext();
            };


            while (!FireCodes.AreaOfOrigin.EOF)
            {
                    ViewModel.cboAreaOfOrigin.AddItem(Convert.ToString(FireCodes.AreaOfOrigin["description"]));
                    ViewModel.cboAreaOfOrigin.SetItemData(ViewModel.cboAreaOfOrigin.GetNewIndex(), Convert.ToInt32(FireCodes.AreaOfOrigin["area_of_origin_code"]));
                    FireCodes.AreaOfOrigin.MoveNext();
            };


            //Test For Property Value Calculation
            if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                {
                    if ( ViewModel.txtTotalSqFootage.Text != "")
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if ( ViewModel.txtPropValue.Text == "" || Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) == 0)
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
        internal void cboGeneralPropertyUse_Enter(Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_ISSUE: (2064) ComboBox property cboGeneralPropertyUse.HelpContextID was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            IncidentMain
                .Shared.gHelpControl = ViewModel.cboGeneralPropertyUse.getHelpContextID();

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboGeneralPropertyUse_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboGeneralPropertyUse.SelectedIndex == -1)
            {
                ViewModel.cboGeneralPropertyUse.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboHeatSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboHeatSource_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboHeatSource.SelectedIndex == -1)
            {
                ViewModel.cboHeatSource.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboInitiatingDevice_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboInitiatingDevice_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboInitiatingDevice.SelectedIndex == -1)
            {
                ViewModel.cboInitiatingDevice.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboMobileMake_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            if ( ViewModel.cboMobileMake.SelectedIndex != -1)
            {
                if ( ViewModel.cboMobileMake.Text.Substring(Math.Max(ViewModel.cboMobileMake.Text.Length - 2, 0)) == "00")
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
            ViewModel.FirstTime = -1;
            //Check for Display of Passenger or WaterVessel Controls
            switch ( ViewModel.cboMobilePropType.GetItemData(ViewModel.cboMobilePropType.SelectedIndex))
            {
                case 62:  //Water Vessel 

                    ViewModel.lbVesselLength.Visible = true;
                    ViewModel.txtVesselLength.Visible = true;
                    break;
            default:
                    ViewModel.lbVesselLength.Visible = false;
                    ViewModel.txtVesselLength.Visible = false;
                    break;
    }
            ViewModel.FirstTime = 0;
            CheckComplete();

    }

        [UpgradeHelpers.Events.Handler]
        internal void cboMobilePropType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboMobilePropType.SelectedIndex == -1)
            {
                ViewModel.cboMobilePropType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboNameList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Display Selected Name
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();

            if ( ViewModel.FirstTime != 0)
            {
                return;
            } //Don't run for Initialization

            if ( ViewModel.cboNameList.SelectedIndex == -1)
            {
                return;
            }

            //Check For Changes on Currently Displayed Name
            if ( ViewModel.NameUpdated != 0)
            {
                SaveName();
            }

            ClearName();
            if (IncidentCL.GetName(ViewModel.cboNameList.GetItemData(ViewModel.cboNameList.SelectedIndex)) != 0)
            {
                //Display Selected Name
                ViewModel.lbNameID.Text = IncidentCL.NameID.ToString();
                ViewModel.txtFirstName.Text = IncidentCL.NameFirst;
                ViewModel.txtLastName.Text = IncidentCL.NameLast;
                ViewModel.txtMI.Text = IncidentCL.NameMI;
                ViewModel.txtBusinessName.Text = IncidentCL.NameBusiness;
                ViewModel.txtHouseNumber.Text = IncidentCL.HouseNumber;
                ViewModel.txtStreetName.Text = IncidentCL.Street;
                ViewModel.txtCity.Text = IncidentCL.City;
                ViewModel.txtZipcode.Text = IncidentCL.Zipcode;
                if (Information.IsDate(IncidentCL.Birthdate))
                {
                    ViewModel.txtBirthdate.Text = DateTime.Parse(IncidentCL.Birthdate).ToString("MM/dd/yyyy");
                }
                ViewModel.txtHomePhone.Text = IncidentCL.HomePhone;
                ViewModel.txtWorkPhone.Text = IncidentCL.WorkPhone;
                ViewModel.txtWorkPlace.Text = IncidentCL.WorkPlace;
                if (IncidentCL.Gender != 0)
                {
                    if (IncidentCL.Gender == 1)
                    {
                        ViewModel.optGender[0].Checked = true;
                    }
                    else
                    {
                        ViewModel.optGender[1].Checked = true;
                    }
            }
            else
            {
                    ViewModel.optGender[0].Checked = false;
                    ViewModel.optGender[1].Checked = false;
                }
                if (IncidentCL.EthnicityCode != 0)
                {
                    if (IncidentCL.EthnicityCode == 3)
                    {
                        ViewModel.optEthnicity[0].Checked = true;
                    }
                    else
                    {
                        ViewModel.optEthnicity[1].Checked = true;
                    }
            }
            else
            {
                    ViewModel.optEthnicity[0].Checked = false;
                    ViewModel.optEthnicity[1].Checked = false;
                }
                //Set combo boxes
                if (IncidentCL.Prefix != "")
                {
                    for (int i = 0; i <= ViewModel.cboPrefix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboPrefix.GetListItem(i) == IncidentCL.Prefix)
                        {
                            ViewModel.cboPrefix.SelectedIndex = i;
                            break;
                    }
            }
            if ( ViewModel.cboPrefix.SelectedIndex != -1)
                    {
                        ViewModel.cboSuffix.SelectedIndex = -1;
                    }
            }
            else
            {
                    ViewModel.cboPrefix.SelectedIndex = -1;
                }
                if (IncidentCL.Suffix != "")
                {
                    for (int i = 0; i <= ViewModel.cboSuffix.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboSuffix.GetListItem(i) == IncidentCL.Suffix)
                        {
                            ViewModel.cboSuffix.SelectedIndex = i;
                            break;
                    }
            }
            if ( ViewModel.cboSuffix.SelectedIndex != -1)
                    {
                        ViewModel.cboPrefix.SelectedIndex = -1;
                    }
            }
            else
            {
                    ViewModel.cboSuffix.SelectedIndex = -1;
                }
                if (IncidentCL.StreetType != "")
                {
                    for (int i = 0; i <= ViewModel.cboStreetType.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboStreetType.GetListItem(i) == IncidentCL.StreetType)
                        {
                            ViewModel.cboStreetType.SelectedIndex = i;
                            break;
                    }
            }
    }
    else
    {
                    ViewModel.cboStreetType.SelectedIndex = -1;
                }
                if (IncidentCL.StateCode != "")
                {
                    for (int i = 0; i <= ViewModel.cboState.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboState.GetListItem(i) == IncidentCL.StateCode)
                        {
                            ViewModel.cboState.SelectedIndex = i;
                            break;
                    }
            }
    }
    else
    {
                    ViewModel.cboState.SelectedIndex = -1;
                }
                if (IncidentCL.RaceCode != 0)
                {
                    for (int i = 0; i <= ViewModel.cboRace.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboRace.GetItemData(i) == IncidentCL.RaceCode)
                        {
                            ViewModel.cboRace.SelectedIndex = i;
                            break;
                    }
            }
    }
    else
    {
                    ViewModel.cboRace.SelectedIndex = -1;
                }
                if (IncidentCL.IncidentRoleCode != 0)
                {
                    for (int i = 0; i <= ViewModel.cboRole.Items.Count - 1; i++)
                    {
                        if ( ViewModel.cboRole.GetItemData(i) == IncidentCL.IncidentRoleCode)
                        {
                            ViewModel.cboRole.SelectedIndex = i;
                            break;
                    }
            }
    }
    else
    {
                    ViewModel.cboRace.SelectedIndex = -1;
                }
        }
            CheckNameComplete();
            ViewModel.NameUpdated = 0;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboNameList_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboNameList.SelectedIndex == -1)
            {
                ViewModel.cboNameList.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboNarrList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Retrieve Selected Narration

            if ( ViewModel.cboNarrList.SelectedIndex == -1)
            {
                return;
            }
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            TFDIncident.clsIncident IncidentCL = Container.Resolve< clsIncident>();
            TFDIncident.clsPersonnel PersonnelCL = Container.Resolve< clsPersonnel>();

            if ( ViewModel.NarrationUpdated != 0)
            {
                SaveNarration();
            }
            ViewModel.rtxNarration.Text = "";
            ViewModel.lbNarrID.Text = "";
            ViewModel.lbNarrAuthor.Text = "";
            int NarrID = ViewModel.cboNarrList.GetItemData(ViewModel.cboNarrList.SelectedIndex);

            if (IncidentCL.GetNarration(NarrID) != 0)
            {
                ViewModel.lbNarrID.Text = IncidentCL.NarrationID.ToString();
                if (PersonnelCL.GetEmployeeRecord(IncidentMain.Clean(IncidentCL.NarrationBy)) != 0)
                {
                    ViewModel.lbNarrAuthor.Text = IncidentMain.Clean(PersonnelCL.Employee["name_full"]);
                }
                ViewModel.rtxNarration.Text = IncidentMain.Clean(IncidentCL.NarrationText);
                ViewModel.rtxNarration.Enabled = !(IncidentCL.NarrationBy != IncidentMain.Shared.gCurrUser);
                ViewModel.NarrationUpdated = 0;
            }

    }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSAreaUnits_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSAreaUnits_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboOSAreaUnits.SelectedIndex == -1)
            {
                ViewModel.cboOSAreaUnits.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            //Reset OS Specific Cause of Ignition
            //Check to make sure that a change has been made
            int CauseType = 0;
            TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

            if ( ViewModel.FirstTime != 0)
            {
                return;
            } // Don't run for Field Initialization

            if ( ViewModel.cboOSCauseOfIgnition.SelectedIndex == -1)
            { //No Gen Prop Selected

                ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
                ViewManager.ShowMessage("Specific Cause of Fire Has Been Cleared" + "\n" + "Select General Cause of Fire to Reload Values", "Fire Report Edit", UpgradeHelpers.Helpers.BoxButtons.OK);
                return;
        }
        else
        {
                CauseType = ViewModel.cboOSCauseOfIgnition.GetItemData(ViewModel.cboOSCauseOfIgnition.SelectedIndex);
            }

            //Check to determine if General Prop Changed
            if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex > -1)
            {
                FireCodes.GetCauseOfIgnitionByCode(ViewModel.cboOSSpecCauseOfIgnition.GetItemData(ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex));
                if (Convert.ToDouble(FireCodes.CauseOfIgnition["cause_of_ignition_class"]) == CauseType)
                {
                    return;
                } //No Changes
        }
            ViewModel.cboOSSpecCauseOfIgnition.Items.Clear();
            FireCodes.GetCauseOfIgnitionByClass(CauseType);

            while (!FireCodes.CauseOfIgnition.EOF)
            {
                ViewModel.cboOSSpecCauseOfIgnition.AddItem(Convert.ToString(FireCodes.CauseOfIgnition["description"]));
                ViewModel.cboOSSpecCauseOfIgnition.SetItemData(ViewModel.cboOSSpecCauseOfIgnition.GetNewIndex(), Convert.ToInt32(FireCodes.CauseOfIgnition["cause_of_ignition_code"]));
                FireCodes.CauseOfIgnition.MoveNext();
        };


        CheckComplete();

}

        [UpgradeHelpers.Events.Handler]
        internal void cboOSCauseOfIgnition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboOSCauseOfIgnition.SelectedIndex == -1)
            {
                ViewModel.cboOSCauseOfIgnition.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSHeatSource_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSHeatSource_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboOSHeatSource.SelectedIndex == -1)
            {
                ViewModel.cboOSHeatSource.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSMaterialInvolved_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSMaterialInvolved_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboOSMaterialInvolved.SelectedIndex == -1)
            {
                ViewModel.cboOSMaterialInvolved.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSSpecCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboOSSpecCauseOfIgnition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboOSSpecCauseOfIgnition.SelectedIndex == -1)
            {
                ViewModel.cboOSSpecCauseOfIgnition.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboPrefix_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboPrefix.SelectedIndex == -1)
            {
                ViewModel.cboPrefix.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboRace_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRace_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboRace.SelectedIndex == -1)
            {
                ViewModel.cboRace.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboRole_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckNameComplete();
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboRole_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboRole.SelectedIndex == -1)
            {
                ViewModel.cboRole.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboSmokeDamage_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSmokeDamage_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboSmokeDamage.SelectedIndex == -1)
            {
                ViewModel.cboSmokeDamage.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecCauseOfIgnition_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecCauseOfIgnition_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboSpecCauseOfIgnition.SelectedIndex == -1)
            {
                ViewModel.cboSpecCauseOfIgnition.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecificPropertyUse_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSpecificPropertyUse_Enter(Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_ISSUE: (2064) ComboBox property cboSpecificPropertyUse.HelpContextID was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            IncidentMain
                .Shared.gHelpControl = ViewModel.cboSpecificPropertyUse.getHelpContextID();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboState_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboState_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboState.SelectedIndex == -1)
            {
                ViewModel.cboState.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboStreetType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboStreetType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboStreetType.SelectedIndex == -1)
            {
                ViewModel.cboStreetType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSuffix_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboSuffix.SelectedIndex == -1)
            {
                ViewModel.cboSuffix.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboSysType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void cboSysType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboSysType.SelectedIndex == -1)
            {
                ViewModel.cboSysType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXPrefix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            if ( ViewModel.cboXPrefix.SelectedIndex != -1)
            {
                ViewModel.FirstTime = -1;
                ViewModel.cboXSuffix.SelectedIndex = -1;
                ViewModel.FirstTime = 0;
                CheckComplete();
                ViewModel.AddressUpdated = -1;
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXPrefix_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboXPrefix.SelectedIndex == -1)
            {
                ViewModel.cboXPrefix.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXStreetType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.AddressUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void cboXStreetType_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboXStreetType.SelectedIndex == -1)
            {
                ViewModel.cboXStreetType.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXSuffix_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            if ( ViewModel.cboXSuffix.SelectedIndex != -1)
            {
                ViewModel.FirstTime = -1;
                ViewModel.cboXPrefix.SelectedIndex = -1;
                ViewModel.FirstTime = 0;
                CheckComplete();
                ViewModel.AddressUpdated = -1;
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void cboXSuffix_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.cboXSuffix.SelectedIndex == -1)
            {
                ViewModel.cboXSuffix.Text = "";
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void chkAlarmOperation_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            //    If chkAlarmOperation.Value = 0 Then
            //        cboEffectiveness.Enabled = False
            //        lbEffectiveness.ForeColor = DKGRAY
            //    Else
            //        cboEffectiveness.Enabled = True
            //        lbEffectiveness.ForeColor = FIREFONT
            //    End If
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkExposures_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.chkExposures.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
            {
                ViewModel.txtNumberExposures.Visible = false;
                ViewModel.lbNumExp.Visible = false;
            }
            else
            {
                ViewModel.txtNumberExposures.Visible = true;
                ViewModel.lbNumExp.Visible = true;
            }

    }

        [UpgradeHelpers.Events.Handler]
        internal void chkExtOperation_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void chkMobileInvolved_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
        {
            TFDIncident.clsReportLog ReportCL = Container.Resolve< clsReportLog>();
            TFDIncident.clsFire FireCL = Container.Resolve< clsFire>();
            int NewReportID = 0;

            if ( ViewModel.chkMobileInvolved.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
            {
                //Add new FireReport
                FireCL.IncidentID = ViewModel.CurrIncident;
                FireCL.IncidentType = 12; //Mobile
                FireCL.PropertyUse = 0;
                FireCL.PropertyValue = 0;
                FireCL.AreaOfOrigin = 0;
                FireCL.HeatSource = 0;
                FireCL.FirstItemIgnited = 0;
                FireCL.CauseOfIgnition = 0;
                FireCL.PropertyLoss = 0;
                FireCL.ContentLoss = 0;
                if (~FireCL.AddFireReport() != 0)
                {
                    ViewManager.ShowMessage("Error Attempting to Create Fire Report Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewModel.chkMobileInvolved.Enabled = false;
                    return;
            }
            else
            {
                    NewReportID = FireCL.FireReportID;
            }
            //Add new Mobile Property Fire Report
            FireCL.FMFireReportID = NewReportID;
            FireCL.VehicleMake = "";
            FireCL.VehicleModel = "";
            FireCL.VehicleYear = "";
            FireCL.VehicleVin = "";
            FireCL.WaterVesselLength = 0;
            FireCL.MobileMake = "";
            FireCL.LicenseState = "";
            if (~FireCL.AddFireMobileProperty() != 0)
            {
                    ViewManager.ShowMessage("Error Attempting to Create Mobile Property Fire Report Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers
                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    ViewModel.chkMobileInvolved.Enabled = false;
                    return;
            }
            else
            {
                    //Add new ReportLogRecord
                    ReportCL.RLIncidentID = ViewModel.CurrIncident;
                    ReportCL.ReportReferenceID = NewReportID;
                    ReportCL.ReportType = IncidentMain.FIREMOBILE;
                    ReportCL.ReportStatus = 2;
                    ReportCL.ResponsibleUnit = ViewModel.ReportingUnit;
                    if (~ReportCL.AddNew() != 0)
                    {
                        ViewManager.ShowMessage("Error attempting to create Mobile Fire Report Log Record", "TFD Incident Reporting System", UpgradeHelpers.Helpers.
                            BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                    }
                    else
                    {
                        ViewManager.ShowMessage("When Finished Editing Re-Select Incident from Report Editing Tab to Access Mobile Property Report", "TFD Incident Reporting System"
                            , UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    }
            }
    }
}

        [UpgradeHelpers.Events.Handler]
        internal void cmdAddNarration_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Determine Command Mode - Add New (1) or Save New (2)
            switch (Convert.ToString(ViewModel.cmdAddNarration.Tag))
            {
                case "1":
                    //    Clear Screen for New Narration 
                    if ( ViewModel.NarrationUpdated != 0)
                    {
                        SaveNarration();
                    }
                    ViewModel.lbNarrID.Text = "";
                    ViewModel.lbNarrAuthor.Text = IncidentMain.Shared.gCurrUserName;
                    ViewModel.rtxNarration.Text = "";
                    ViewModel.rtxNarration.Enabled = true;
                    ViewManager.SetCurrent(ViewModel.rtxNarration);
                    ViewModel.cmdAddNarration.Tag = "2";
                    ViewModel.cmdAddNarration.Text = "Save New Narration";
                    break;
            case "2":
                    //   Save New Narration 
                    SaveNarration();
                    LoadNarration(0);
                    ViewModel.cmdAddNarration.Tag = "1";
                    ViewModel.cmdAddNarration.Text = "Add New Narration";

                    break;
    }


}

        [UpgradeHelpers.Events.Handler]
        internal void cmdCancelExit_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Exit Canceling Changes
            ViewManager.DisposeView(this);
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdHelp_Click(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                if (IncidentMain.Shared.gHelpScreen == 0)
                {
                    ViewManager.ShowMessage("There is no help available for this screen", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Information);
                    this.Return();
                    return ;
                }
                else
                {
                    async1.Append(() =>
                        {
                            ViewManager.NavigateToView(
                                frmHelp.DefInstance, true);
                        });
                }
            }
        }

        [UpgradeHelpers.Events.Handler]
        internal void cmdMoreNames_Click(Object eventSender, System.EventArgs eventArgs)
        {
            //Check Tag Property to determine if
            //Add New or Save New requested
            //Flip Button to other mode

            if (Convert.ToString(ViewModel.cmdMoreNames.Tag) == "1")
            {
                if ( ViewModel.NameUpdated != 0)
                {
                    SaveName();
                }
                ClearName();
                ViewModel.cmdMoreNames.Text = "Save New Name Record";
                ViewModel.cmdMoreNames.Tag = "2";
            }
            else
            {
                if (SaveName() != 0)
                {
                    LoadNames(Convert.ToInt32(Conversion.Val(ViewModel.lbNameID.Text)));
                    ViewModel.cmdMoreNames.Text = "Add New Name Record";
                    ViewModel.cmdMoreNames.Tag = "1";
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
            using ( var async1 = this.Async(true) )
            {
                int Index =this.ViewModel.cmdSave.IndexOf((UpgradeHelpers.BasicViewModels.ButtonViewModel) eventSender);
                //Exit With Requested Saving Option
                int UpdateType = 0;

                switch (Index)
                {
                    case 0:
                        UpdateType = IncidentMain.COMPLETE;
                        using ( var async3 = this.Async() )
                        {
                            switch ( ViewModel.ReportType)
                            {
                                case IncidentMain.FIRE:
                                case IncidentMain.FIRESTRUCTURE:
                                case IncidentMain.FIREMOBILE:
                                case IncidentMain.FIREOUTSIDE:
                                    if (SaveFireRecord(UpdateType) != 0)
                                    {
                                        ViewManager.ShowMessage("Fire Report Successfully Saved", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                        IncidentMain.Shared.gExportFlag = 1;
                                        IncidentMain.Shared.gPrintReportID = ViewModel.FireReportID;
                                        async3.Append(() =>
                                            {
                                                ViewManager.NavigateToView(
                                                    frmReportFire.DefInstance, true);
                                            });
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save FireReport - Contact Sheila McCoy Immediately", "TFD Incident Reporting System", UpgradeHelpers
                                            .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }

                                    break;
                            default:
                                    if (SaveRuptureRecord(UpdateType) != 0)
                                    {
                                        ViewManager.ShowMessage("Rupture/Explosion Report Successfully Saved", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                    }
                                    else
                                    {
                                        ViewManager.ShowMessage("Error Attempting to Save RuptureReport - Contact Sheila McCoy Immediately", "TFD Incident Reporting System", UpgradeHelpers
                                            .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                    }
                                    break;
                    }
                        }
                    break;
            case 1:
                    UpdateType = IncidentMain.SAVEDINCOMPLETE;
                    switch ( ViewModel.ReportType)
                    {
                            case IncidentMain.FIRE:
                            case IncidentMain.FIRESTRUCTURE:
                            case IncidentMain.FIREMOBILE:
                            case IncidentMain.FIREOUTSIDE:
                                    if (SaveFireRecord(UpdateType) != 0)
                                    {
                                    ViewManager.ShowMessage("Fire Report Successfully Saved", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save FireReport - Contact Ralph Johns Immediately", "TFD Incident Reporting System", UpgradeHelpers.
                                        Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                        default:
                                if (SaveRuptureRecord(UpdateType) != 0)
                                {
                                    ViewManager.ShowMessage("Rupture/Explosion Report Successfully Saved", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.OK);
                                }
                                else
                                {
                                    ViewManager.ShowMessage("Error Attempting to Save RuptureReport - Contact Ralph Johns Immediately", "TFD Incident Reporting System", UpgradeHelpers
                                        .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                }
                                break;
                }
                break;
}

if (Index != 3)
{
                    ViewManager.DisposeView(this);
                }
                else
                {
                    using ( var async4 = this.Async() )
                    {
                        //Print Preview Report
                        switch ( ViewModel.ReportType)
                        {
                            case IncidentMain.FIRE:
                            case IncidentMain.FIRESTRUCTURE:
                            case IncidentMain.FIREMOBILE:
                            case IncidentMain.FIREOUTSIDE:
                                IncidentMain.Shared.gExportFlag = 0;
                                IncidentMain.Shared.gPrintReportID = ViewModel.FireReportID;
                                async4.Append(() =>
                                    {
                                        ViewManager.NavigateToView(
                                            frmReportFire.DefInstance, true);
                                    });

                                break;
                        default:
                                IncidentMain.Shared.gPrintReportID = ViewModel.RuptureReportID;
                                async4.Append(() =>
                                    {
                                        ViewManager.NavigateToView(
                                            frmReportRupture.DefInstance, true);
                                    });
                                break;
                }
                    }
        }
            }

}

        //UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

        private void Form_Load()
        {
            //Initialize Form
            IncidentMain
                .Shared.gHelpScreen = 0;
            IncidentMain.Shared.gHelpControl = 0;
            ViewModel.NameUpdated = 0;
            ViewModel.NarrationUpdated = 0;
            ViewModel.ADDRESSCORRECTION = 0;
            ViewModel.FirstTime = -1;
            ViewModel.HumansAFactor = 0;
            ViewModel.ExposureOccured = 0;

            LoadReportData();
            ViewModel.FirstTime = 0;

            IncidentMain.Shared.gExportFlag = 0;
            CheckComplete();

            if (IncidentMain.Shared.gWizardSecurity == IncidentMain.READONLY)
            {
                LockScreen();
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void lstHumanContribFactors_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
        {
            ViewModel.HumansAFactor = 0;
            if ( ViewModel.ReportType == IncidentMain.FIRESTRUCTURE)
            {
                for (int i = 0; i <= ViewModel.lstHumanContribFactors.Items.Count - 1; i++)
                {
                    if ( ViewModel.lstHumanContribFactors.GetSelected( i))
                    {
                        ViewModel.HumansAFactor = -1;
                    }
            }
    }
            CheckComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void optAlarmType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index =this.ViewModel.optAlarmType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
                //Clear and reformat as necessary
                if ( ViewModel.FirstTime != 0)
                {
                    return;
                }
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                switch (Index)
                {
                    case 0:  //No Alarm Involved 

                        ViewModel.lbInitiatingDevice.Visible = false;
                        ViewModel.cboInitiatingDevice.Visible = false;
                        ViewModel.lbReasonFailure.Visible = false;
                        ViewModel.lstAlarmFailure.Visible = false;
                        ViewModel.chkAlarmOperation.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.chkAlarmOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.chkAlarmOperation.Enabled = false;
                        ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboEffectiveness.Enabled = false;
                        ViewModel.lbAlarmType.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboAlarmType.Enabled = false;
                        break;
                case 1:  //Unit Detectors Only 

                        ViewModel.lbInitiatingDevice.Visible = false;
                        ViewModel.cboInitiatingDevice.Visible = false;
                        ViewModel.lbReasonFailure.Visible = false;
                        ViewModel.lstAlarmFailure.Visible = false;
                        ViewModel.chkAlarmOperation.Enabled = true;
                        ViewModel.chkAlarmOperation.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.chkAlarmOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboEffectiveness.Enabled = true;
                        ViewModel.cboEffectiveness.Items.Clear();
                        ViewModel.lbAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboAlarmType.Enabled = true;
                        ViewModel.cboAlarmType.Items.Clear();
                        ViewModel.lbAlarmType.Text = "DETECTOR POWER";
                        //Fill combo boxes 
                        FireCodes.GetEffectiveness("D");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboEffectiveness.AddItem(Convert.ToString(FireCodes.Effectiveness["description"]));
                            ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                    }
                        ;
                        FireCodes.GetDetectorPowerCodes();
                        //Detector Power 

                        while (!FireCodes.DetectorPower.EOF)
                        {
                            ViewModel.cboAlarmType.AddItem(IncidentMain.Clean(FireCodes.DetectorPower["description"]));
                            ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.DetectorPower["detector_power_code"]));
                            FireCodes.DetectorPower.MoveNext();
                    }
                        ;
                        //            cboEffectiveness.Enabled = False 
                        //            lbEffectiveness.ForeColor = DKGRAY 
                        break;
                case 2:  //Alarm System 

                        ViewModel.lbInitiatingDevice.Visible = true;
                        ViewModel.cboInitiatingDevice.Visible = true;
                        ViewModel.cboInitiatingDevice.Items.Clear();
                        ViewModel.chkAlarmOperation.Enabled = true;
                        ViewModel.chkAlarmOperation.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.chkAlarmOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.lbEffectiveness.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboEffectiveness.Enabled = true;
                        ViewModel.cboEffectiveness.Items.Clear();
                        ViewModel.lbAlarmType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboAlarmType.Enabled = true;
                        ViewModel.cboAlarmType.Items.Clear();
                        ViewModel.lbAlarmType.Text = "SYSTEM TYPE";
                        ViewModel.lbReasonFailure.Visible = true;
                        ViewModel.lstAlarmFailure.Visible = true;
                        ViewModel.lstAlarmFailure.Items.Clear();
                        //Fill combo boxes 
                        FireCodes.GetEffectiveness("A");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboEffectiveness.AddItem(IncidentMain.Clean(FireCodes.Effectiveness["description"]));
                            ViewModel.cboEffectiveness.SetItemData(ViewModel.cboEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                    }
                        ;
                        FireCodes.GetFireSystemType("A");

                        while (!FireCodes.FireSystemType.EOF)
                        {
                            ViewModel.cboAlarmType.AddItem(IncidentMain.Clean(FireCodes.FireSystemType["description"]));
                            ViewModel.cboAlarmType.SetItemData(ViewModel.cboAlarmType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                            FireCodes.FireSystemType.MoveNext();
                    }
                        ;
                        FireCodes.GetSystemFailure("A");

                        while (!FireCodes.SystemFailure.EOF)
                        {
                            ViewModel.lstAlarmFailure.AddItem(IncidentMain.Clean(FireCodes.SystemFailure["description"]));
                            ViewModel.lstAlarmFailure.SetItemData(ViewModel.lstAlarmFailure.GetNewIndex(), Convert.ToInt32(FireCodes.SystemFailure["system_failure_code"]));
                            FireCodes.SystemFailure.MoveNext();
                    }
                        ;
                        FireCodes.GetAlarmDevice();

                        while (!FireCodes.AlarmDevice.EOF)
                        {
                            ViewModel.cboInitiatingDevice.AddItem(IncidentMain.Clean(FireCodes.AlarmDevice["description"]));
                            ViewModel.cboInitiatingDevice.SetItemData(ViewModel.cboInitiatingDevice.GetNewIndex(), Convert.ToInt32(FireCodes.AlarmDevice["alarm_device_code"]));
                            FireCodes.AlarmDevice.MoveNext();
                    }
                        ;
                        //            cboEffectiveness.Enabled = False 
                        //            lbEffectiveness.ForeColor = DKGRAY 
                        break;
        }

        CheckComplete();

}
}

        [UpgradeHelpers.Events.Handler]
        internal void optEthnicity_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                if ( ViewModel.FirstTime != 0)
                {
                    return;
                }
                ViewModel.NameUpdated = -1;
            }
    }

        [UpgradeHelpers.Events.Handler]
        internal void optExtinguish_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index =this.ViewModel.optExtinguish.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
                //Clear and reformat as necessary
                if ( ViewModel.FirstTime != 0)
                {
                    return;
                }
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                switch (Index)
                {
                    case 0:  //No Extinguishing System Involved 

                        ViewModel.chkExtOperation.Enabled = false;
                        ViewModel.chkExtOperation.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.chkExtOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.lbSysType.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboSysType.Enabled = false;
                        ViewModel.cboSysType.Items.Clear();
                        ViewModel.lbExtEffective.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.cboExtEffectiveness.Enabled = false;
                        ViewModel.cboExtEffectiveness.Items.Clear();
                        ViewModel.lbSysReasonFailure.ForeColor = IncidentMain.Shared.DKGRAY;
                        ViewModel.lstExtFailure.Enabled = false;
                        ViewModel.lstExtFailure.Items.Clear();

                        break;
                case 1:  //Extinguishing System Involved 

                        ViewModel.chkExtOperation.Enabled = true;
                        ViewModel.chkExtOperation.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.chkExtOperation.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
                        ViewModel.lbSysType.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboSysType.Enabled = true;
                        ViewModel.cboSysType.Items.Clear();
                        ViewModel.lbExtEffective.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.cboExtEffectiveness.Enabled = true;
                        ViewModel.cboExtEffectiveness.Items.Clear();
                        ViewModel.lbSysReasonFailure.ForeColor = IncidentMain.Shared.FIREFONT;
                        ViewModel.lstExtFailure.Enabled = true;
                        ViewModel.lstExtFailure.Items.Clear();
                        //Fill combo boxes 
                        FireCodes.GetEffectiveness("E");

                        while (!FireCodes.Effectiveness.EOF)
                        {
                            ViewModel.cboExtEffectiveness.AddItem(IncidentMain.Clean(FireCodes.Effectiveness["description"]));
                            ViewModel.cboExtEffectiveness.SetItemData(ViewModel.cboExtEffectiveness.GetNewIndex(), Convert.ToInt32(FireCodes.Effectiveness["effectiveness_code"]));
                            FireCodes.Effectiveness.MoveNext();
                    }
                        ;
                        FireCodes.GetFireSystemType("E");

                        while (!FireCodes.FireSystemType.EOF)
                        {
                            ViewModel.cboSysType.AddItem(IncidentMain.Clean(FireCodes.FireSystemType["description"]));
                            ViewModel.cboSysType.SetItemData(ViewModel.cboSysType.GetNewIndex(), Convert.ToInt32(FireCodes.FireSystemType["system_type_code"]));
                            FireCodes.FireSystemType.MoveNext();
                    }
                        ;
                        FireCodes.GetSystemFailure("E");

                        while (!FireCodes.SystemFailure.EOF)
                        {
                            ViewModel.lstExtFailure.AddItem(IncidentMain.Clean(FireCodes.SystemFailure["description"]));
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
            int Index =this.ViewModel.optFloor.IndexOf((UpgradeHelpers.BasicViewModels.CheckBoxViewModel) eventSender);

            if ( ViewModel.optFloor[Index].CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
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
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index =this.ViewModel.optGender.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
                if ( ViewModel.FirstTime != 0)
                {
                    return;
                }
                CheckNameComplete();
                if ( ViewModel.optGender[Index].Checked)
                {
                    ViewModel.NameUpdated = -1;
                }

        }
}

        [UpgradeHelpers.Events.Handler]
        internal void optOSType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked)
            {
                if ( ViewModel.isInitializingComponent)
                {
                    return;
                }
                int Index =this.ViewModel.optOSType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
                //Reformat Screen as Needed
                switch (Index)
                {
                    case 0:
                    case 1:
                        ViewModel.lbOSMaterialInvolved.Visible = false;
                        ViewModel.cboOSMaterialInvolved.Visible = false;
                        break;
                case 2:
                        ViewModel.lbOSMaterialInvolved.Visible = true;
                        ViewModel.cboOSMaterialInvolved.Visible = true;
                        break;
        }

        CheckComplete();

}
}

        private void rtxNarration_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NarrationUpdated = -1;

        }

        [UpgradeHelpers.Events.Handler]
        internal void tabFire_Selecting(object sender, EventArgs e)
        {
            //Ignore Tabs that don't apply to current report type
            //Mobilize_Note: angamboa. We need test this code in Runtime [SelectedIndex] and [e.Cancel] 
            bool cancelAction = false;

            switch (ViewModel.ReportType)
            {
                case IncidentMain.FIRESTRUCTURE:
                case IncidentMain.RUPTURESTRUCTURE:
                    if (ViewModel.tabFire.SelectedIndex == 1 || ViewModel.tabFire.SelectedIndex == 4)
                    {
                        ViewModel.tabFire.SelectedIndex = ViewModel.tabFire.TabIndex;
                        cancelAction = true;
                    }
                    break;
                case IncidentMain.FIREMOBILE:
                case IncidentMain.RUPTUREMOBILE:
                    if (ViewModel.tabFire.SelectedIndex == 0 || ViewModel.tabFire.SelectedIndex == 4)
                    {
                        ViewModel.tabFire.SelectedIndex = ViewModel.tabFire.TabIndex;
                        cancelAction = true;
                    }
                    break;
                case IncidentMain.FIREOUTSIDE:
                case IncidentMain.RUPTUREOUTSIDE:
                    if (ViewModel.tabFire.SelectedIndex < 4)
                    {
                        ViewModel.tabFire.SelectedIndex = ViewModel.tabFire.TabIndex;
                    }
                    break;
            }
            if (cancelAction == false)
            {
                switch (ViewModel.tabFire.SelectedIndex)
                {
                    case 0:
                        IncidentMain.Shared.gHelpScreen = 1;
                        break;
                    case 1:
                        IncidentMain.Shared.gHelpScreen = 2;
                        break;
                    case 2:
                        IncidentMain.Shared.gHelpScreen = 3;
                        break;
                    case 3:
                        IncidentMain.Shared.gHelpScreen = 4;
                        break;
                    case 4:
                        IncidentMain.Shared.gHelpScreen = 5;
                        break;
                    case 5:
                        IncidentMain.Shared.gHelpScreen = 6;
                        break;
                    case 6:
                        IncidentMain.Shared.gHelpScreen = 7;
                        break;
                    case 7:
                        IncidentMain.Shared.gHelpScreen = 8;
                        break;
                    default:
                        IncidentMain.Shared.gHelpScreen = 0;
                        break;
                }
            }
            IncidentMain.Shared.gHelpControl = 0;
        }

        //Mobilize: Replaced by tabFire_Selecting
        //      private void tabFire_TabPageActivate(Object eventSender, AxTabproLib._DTabEvents_TabPageActivateEvent eventArgs)
        //{
        //	//Ignore Tabs that don't apply to current report type

        //	switch(ReportType)
        //	{
        //		case IncidentMain.FIRESTRUCTURE : case IncidentMain.RUPTURESTRUCTURE : 
        //			if (eventArgs.tabToActivate == 1 || eventArgs.tabToActivate == 4)
        //			{
        //				eventArgs.tabToActivate = -1;
        //			} 
        //			break;
        //		case IncidentMain.FIREMOBILE : case IncidentMain.RUPTUREMOBILE : 
        //			if (eventArgs.tabToActivate == 0 || eventArgs.tabToActivate == 4)
        //			{
        //				eventArgs.tabToActivate = -1;
        //			} 
        //			break;
        //		case IncidentMain.FIREOUTSIDE : case IncidentMain.RUPTUREOUTSIDE : 
        //			if (eventArgs.tabToActivate < 4)
        //			{
        //				eventArgs.tabToActivate = -1;
        //			} 
        //			break;
        //	}
        //	switch(eventArgs.tabToActivate)
        //	{
        //		case 0 : 
        //			IncidentMain.gHelpScreen = 1; 
        //			break;
        //		case 1 : 
        //			IncidentMain.gHelpScreen = 2; 
        //			break;
        //		case 2 : 
        //			IncidentMain.gHelpScreen = 3; 
        //			break;
        //		case 3 : 
        //			IncidentMain.gHelpScreen = 4; 
        //			break;
        //		case 4 : 
        //			IncidentMain.gHelpScreen = 5; 
        //			break;
        //		case 5 : 
        //			IncidentMain.gHelpScreen = 6; 
        //			break;
        //		case 6 : 
        //			IncidentMain.gHelpScreen = 7; 
        //			break;
        //		case 7 : 
        //			IncidentMain.gHelpScreen = 8; 
        //			break;
        //		default:
        //			IncidentMain.gHelpScreen = 0; 
        //			break;
        //	}
        //	IncidentMain.gHelpControl = 0;

        //}
        [UpgradeHelpers.Events.Handler]
        internal void txtBirthdate_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBusinessName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtBusinessName_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckNameComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void txtCity_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtContentLoss_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFirstName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFirstName_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckNameComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void txtFloorOfOrigin_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtFloorOfOrigin_Leave(Object eventSender, System.EventArgs eventArgs)
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
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtLastName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtLastName_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckNameComplete();
    }

        [UpgradeHelpers.Events.Handler]
        internal void txtMI_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtMobilePropValue_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
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
        internal void txtOSAreaAffected_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtOSLoss_Leave(Object eventSender, System.EventArgs eventArgs)
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
        internal void txtPropValue_Enter(Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_ISSUE: (2064) MSMask.MaskEdBox property txtPropValue.HelpContextID was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            IncidentMain
                .Shared.gHelpControl = ViewModel.txtPropValue.getHelpContextID();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtBurned_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtSqFtBurned_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                if ( ViewModel.txtSqFtBurned.Text == "")
                {
                    this.Return();
                    return ;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                //Test For Property Value Calculation
                if ( ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyLoss(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtSqFtBurned.Text))) != 0)
                        {
                            if ( ViewModel.txtPropLoss.Text == "" || Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) == 0)
                            {
                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) != FireCodes.PropLossCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Loss has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropLossCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
            using ( var async1 = this.Async(true) )
            {
                if ( ViewModel.ReportType != IncidentMain.RUPTURESTRUCTURE)
                {
                    this.Return();
                    return ;
                }
                if ( ViewModel.txtSqFtSmokeDamage.Text == "")
                {
                    this.Return();
                    return ;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                //Test For Property Value Calculation
                if ( ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyLoss(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtSqFtSmokeDamage.Text))) != 0)
                        {
                            if ( ViewModel.txtPropLoss.Text == "" || Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) == 0)
                            {
                                ViewModel.txtPropLoss.Text = FireCodes.PropLossCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropLoss.Text)) != FireCodes.PropLossCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Loss has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropLossCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTotalSqFootage_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            CheckComplete();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTotalSqFootage_Enter(Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_ISSUE: (2064) MSMask.MaskEdBox property txtTotalSqFootage.HelpContextID was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            IncidentMain
                .Shared.gHelpControl = ViewModel.txtTotalSqFootage.getHelpContextID();
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtTotalSqFootage_Leave(Object eventSender, System.EventArgs eventArgs)
        {
            using ( var async1 = this.Async(true) )
            {
                if ( ViewModel.txtTotalSqFootage.Text == "")
                {
                    this.Return();
                    return ;
                }
                UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
                TFDIncident.clsFireCodes FireCodes = Container.Resolve< clsFireCodes>();

                //Test For Property Value Calculation
                if ( ViewModel.cboGeneralPropertyUse.SelectedIndex != -1)
                {
                    if ( ViewModel.cboConstructionType.SelectedIndex != -1)
                    {
                        if (FireCodes.CalculatePropertyValue(ViewModel.cboGeneralPropertyUse.GetItemData(ViewModel.cboGeneralPropertyUse
                                    .SelectedIndex), ViewModel.cboConstructionType.GetItemData(ViewModel.cboConstructionType.SelectedIndex), Convert.ToInt32(Double.Parse(ViewModel.txtTotalSqFootage.Text))) != 0)
                        {
                            if ( ViewModel.txtPropValue.Text == "" || Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) == 0)
                            {
                                ViewModel.txtPropValue.Text = FireCodes.PropValueCalc.ToString();
                            }
                            else
                            {
                                if (Convert.ToInt32(Double.Parse(ViewModel.txtPropValue.Text)) != FireCodes.PropValueCalc)
                                {
                                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Property Value has been estimated at " +
                                            UpgradeHelpers.Helpers.StringsHelper.Format(FireCodes.PropValueCalc, "#,###"
                                                ) + "\n" + "Would you like to use this Calculation?", "TFD Incident Reporting System", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtWorkPlace_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXHouseNumber_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckComplete();
            ViewModel.AddressUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtXStreetName_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            CheckComplete();
            ViewModel.AddressUpdated = -1;
        }

        [UpgradeHelpers.Events.Handler]
        internal void txtZipcode_TextChanged(Object eventSender, System.EventArgs eventArgs)
        {
            if ( ViewModel.FirstTime != 0)
            {
                return;
            }
            ViewModel.NameUpdated = -1;
        }

        internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
        {
        }

        public static frmFireReport DefInstance
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

        public static frmFireReport CreateInstance()
        {
            TFDIncident.frmFireReport theInstance = Shared.Container.Resolve< frmFireReport>();
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
            ViewModel.tabPage8.LifeCycleStartup();
            ViewModel.tabPage7.LifeCycleStartup();
            ViewModel.tabPage6.LifeCycleStartup();
            ViewModel.tabPage5.LifeCycleStartup();
            ViewModel.tabPage4.LifeCycleStartup();
            ViewModel.tabPage3.LifeCycleStartup();
            ViewModel.tabPage2.LifeCycleStartup();
            ViewModel.tabPage1.LifeCycleStartup();
            ViewModel.picFireBar.LifeCycleStartup();
            ViewModel.tabFire.LifeCycleStartup();
            ViewModel.frmAlarm.LifeCycleStartup();
            ViewModel.frmExtinguish.LifeCycleStartup();
            ViewModel.frmFireOnly.LifeCycleStartup();
            ViewModel.frmFloor.LifeCycleStartup();
            ViewModel.frmFireLoss.LifeCycleStartup();
            ViewModel.frmVehicle.LifeCycleStartup();
            ViewModel.frmOSType.LifeCycleStartup();
            ViewModel.frmOSMain.LifeCycleStartup();
            ViewModel.frmNar1.LifeCycleStartup();
            ViewModel.frmName1.LifeCycleStartup();
            ViewModel.frmEthnicity.LifeCycleStartup();
            ViewModel.frmGender.LifeCycleStartup();
            ViewModel.frmPropLoss.LifeCycleStartup();
            ViewModel.frmFireInfo1.LifeCycleStartup();
            ViewModel.frmHFDetail.LifeCycleStartup();
            ViewModel.frmMobile1.LifeCycleStartup();
            ViewModel.frmBI1.LifeCycleStartup();
            ViewModel.frmNarrSelect.LifeCycleStartup();
            base.ExecuteControlsStartup();
            this.DynamicControlsStartup();
        }

        protected override void ExecuteControlsShutdown()
        {
            ViewModel.tabPage8.LifeCycleShutdown();
            ViewModel.tabPage7.LifeCycleShutdown();
            ViewModel.tabPage6.LifeCycleShutdown();
            ViewModel.tabPage5.LifeCycleShutdown();
            ViewModel.tabPage4.LifeCycleShutdown();
            ViewModel.tabPage3.LifeCycleShutdown();
            ViewModel.tabPage2.LifeCycleShutdown();
            ViewModel.tabPage1.LifeCycleShutdown();
            ViewModel.picFireBar.LifeCycleShutdown();
            ViewModel.tabFire.LifeCycleShutdown();
            ViewModel.frmAlarm.LifeCycleShutdown();
            ViewModel.frmExtinguish.LifeCycleShutdown();
            ViewModel.frmFireOnly.LifeCycleShutdown();
            ViewModel.frmFloor.LifeCycleShutdown();
            ViewModel.frmFireLoss.LifeCycleShutdown();
            ViewModel.frmVehicle.LifeCycleShutdown();
            ViewModel.frmOSType.LifeCycleShutdown();
            ViewModel.frmOSMain.LifeCycleShutdown();
            ViewModel.frmNar1.LifeCycleShutdown();
            ViewModel.frmName1.LifeCycleShutdown();
            ViewModel.frmEthnicity.LifeCycleShutdown();
            ViewModel.frmGender.LifeCycleShutdown();
            ViewModel.frmPropLoss.LifeCycleShutdown();
            ViewModel.frmFireInfo1.LifeCycleShutdown();
            ViewModel.frmHFDetail.LifeCycleShutdown();
            ViewModel.frmMobile1.LifeCycleShutdown();
            ViewModel.frmBI1.LifeCycleShutdown();
            ViewModel.frmNarrSelect.LifeCycleShutdown();
            base.ExecuteControlsShutdown();
        }

        protected override void OnClosed(System.EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
        }

    }

    public partial class frmFireReport
        : UpgradeHelpers.Helpers.FormBase<TFDIncident.ViewModels.frmFireReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

            public virtual frmFireReport m_vb6FormDefInstance { get; set; }

            public virtual bool m_InitializingDefInstance { get; set; }

            void UpgradeHelpers.Interfaces.IInitializable.Init()
            {
                this.CallBaseInit(typeof(SharedState));
            }

        }

    }
}